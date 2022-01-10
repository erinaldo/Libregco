Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Bitmap
Imports System.Net.Mail
Imports System.Net
Imports System.Text.RegularExpressions
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class frm_subtotales_compras
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim RutaDocumento As String
    Dim cmds As Boolean = False
    Dim sp As Point
    Dim AutoFillTotales As Integer

    Sub ResetPicImage()
        Try
            PicDocumento.Width = PanelPic.Width
            PicDocumento.Height = PanelPic.Height
            PicDocumento.Location = New Point(0, 0)
            PicDocumento.Image = My.Resources.No_Image

        Catch ex As Exception
        End Try
    End Sub

    Sub FillTipoPagos()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT * FROM TipoPago606 where Nulo=0 ORDER BY idTipoPago606 ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoPago606")
            cbxTipoPago.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("TipoPago606")
            For Each Fila As DataRow In Tabla.Rows
                cbxTipoPago.Items.Add(Fila.Item("TipoPago"))
            Next

            If Tabla.Rows.Count > 0 Then
                'If Me.Owner.Name = frm_registro_compras.Name Then
                '    cbxTipoNCF.Text = frm_registro_compras.CbxTipoComprobante.Text
                'ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
                '    cbxTipoNCF.Text = frm_factura_cxp.CbxTipoComprobante.Text

                'End If

            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillTipoISR()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT * FROM RetencionISR where Nulo=0 ORDER BY TipoRetencion ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "RetencionISR")
            cbxTipoRetencionISR.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("RetencionISR")
            For Each Fila As DataRow In Tabla.Rows
                cbxTipoRetencionISR.Items.Add(Fila.Item("TipoRetencion"))
            Next

            If Tabla.Rows.Count > 0 Then
                'If Me.Owner.Name = frm_registro_compras.Name Then
                '    cbxTipoNCF.Text = frm_registro_compras.CbxTipoComprobante.Text
                'ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
                '    cbxTipoNCF.Text = frm_factura_cxp.CbxTipoComprobante.Text

                'End If

            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub SetConfiguracion()
        ConMixta.Open()

        'Rellenar totales básicos en la verificación de subtotales
        cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion Where IDConfiguracion=184", ConMixta)
        AutoFillTotales = Convert.ToString(cmd.ExecuteScalar())

        ConMixta.Close()
    End Sub

    Private Sub frm_subtotales_compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim IDCompra As New Label

        Me.CenterToParent()
        ResetPicImage()
        CargarLibregco()
        SetConfiguracion
        AccordionControlElement2.Expanded = True
        AccordionControlElement3.Expanded = True
        AccordionControlElement4.Expanded = True
        AccordionControlElement9.Expanded = True
        AccordionControlElement5.Expanded = False
        AccordionControlElement6.Expanded = False
        AccordionControlElement7.Expanded = False

        FillCondicion()
        FillGastos()
        FillComprobanteFiscal()
        FillMonedas()
        FillTipoPagos
        FillTipoISR

        If Me.Owner.Name = frm_registro_compras.Name Then
            IDCompra.Text = frm_registro_compras.txtIDCompra.Text

        ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
            IDCompra.Text = frm_factura_cxp.txtIDCompra.Text

        ElseIf Me.Owner.name = frm_consulta_compras.name Then
            IDCompra.Text = frm_consulta_compras.GridView1.GetFocusedRowCellValue("ID").ToString

        ElseIf Me.Owner.name = frm_consulta_facturas_cxp.name Then
            IDCompra.Text = frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("ID").ToString
        End If

        Dim dstemp As New DataSet

        ConMixta.Open()
        cmd = New MySqlCommand("SELECT Compras.Fecha,Compras.FechaFactura,Compras.IDSuplidor,Suplidor.Suplidor,Suplidor.RNC,Compras.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Compras.NCF,Compras.IDCondicion,Condicion.Condicion,Compras.IDTipoGasto,TipoGasto.TipoGasto,Compras.IDMoneda,TipoMoneda.Texto,Compras.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,SubtotalLlenado,SubtotalBienes,SubtotalServicios,ItbisFacturado,ItbisRetenido,ItbisProporcionalidad,ItbisalCosto,ItbisAdelantar,ItbisPercibidoenCompras,Compras.IDISRTipoRetencion,RetencionISR.TipoRetencion,ISRPercibido,ISRMontoRetencion,ISCTotal,PropinaLegal,OtrosImpuestos,Compras.IDTipoPago,TipoPago606.TipoPago,RutaDocumento FROM" & SysName.Text & "Compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion INNER JOIN Libregco.ComprobanteFiscal on Compras.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.TipoMoneda on Compras.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.TipoGasto on Compras.IDTipoGasto=TipoGasto.IDGasto INNER JOIN Libregco.TipoPago606 on Compras.IDTipoPago=TipoPago606.idTipoPago606 INNER JOIN Libregco.RetencionISR on Compras.IDISRTipoRetencion=RetencionISR.idRetencionISR Where Compras.IDCompra='" + IDCompra.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Compras")
        ConMixta.Close()

        Dim Tabla As DataTable = dstemp.Tables("Compras")

        If Tabla.Rows.Count > 0 Then
            lblRazon.Text = Tabla.Rows(0).Item("Suplidor").ToString.ToUpper
            lblRNC.Text = Tabla.Rows(0).Item("RNC").ToString.ToUpper
            dtpFecha.Value = CDate(Tabla.Rows(0).Item("FechaFactura"))
            cbxCondicion.Text = Tabla.Rows(0).Item("Condicion")
            cbxCondicion.Tag = Tabla.Rows(0).Item("IDCondicion")
            cbxTipoNCF.Text = Tabla.Rows(0).Item("TipoComprobante")
            cbxTipoNCF.Tag = Tabla.Rows(0).Item("IDComprobanteFiscal")
            txtNCF.Text = Tabla.Rows(0).Item("NCF")
            LUEMoneda.EditValue = Tabla.Rows(0).Item("IDMoneda")
            LUEGasto.EditValue = Tabla.Rows(0).Item("IDTipoGasto")

            If Tabla.Rows(0).Item("SubtotalLlenado") = 0 Then
                If AutoFillTotales = 1 Then
                    txtSubtotalBienesN.EditValue = CDbl(Tabla.Rows(0).Item("SubtotalBienes"))
                    txtSubtotalServiciosN.EditValue = CDbl(Tabla.Rows(0).Item("SubtotalServicios"))
                    txtMontoFacturado.Text = CDbl(CDbl(txtSubtotalBienesN.EditValue) + CDbl(txtSubtotalServiciosN.EditValue))
                    txtItbisFacturado.EditValue = CDbl(Tabla.Rows(0).Item("ItbisFacturado"))
                    txtItbisRetenido.Text = CDbl(Tabla.Rows(0).Item("ItbisRetenido")).ToString("C")
                    txtItbisSujetoProp.Text = CDbl(Tabla.Rows(0).Item("ItbisProporcionalidad")).ToString("C")
                    txtItbisalCosto.Text = CDbl(Tabla.Rows(0).Item("ItbisalCosto")).ToString("C")
                    txtItbisporAdelantar.Text = CDbl(Tabla.Rows(0).Item("ItbisAdelantar")).ToString("C")
                    txtItbisPercibido.Text = CDbl(Tabla.Rows(0).Item("ItbisPercibidoenCompras")).ToString("C")
                    txtISRPercibido.Text = CDbl(Tabla.Rows(0).Item("ISRPercibido")).ToString("C")
                    txtISRRetencionRenta.Text = CDbl(Tabla.Rows(0).Item("ISRMontoRetencion")).ToString("C")
                    txtTotalISC.Text = CDbl(Tabla.Rows(0).Item("ISCTotal")).ToString("C")
                    txtOtrosImpuestos.Text = CDbl(Tabla.Rows(0).Item("OtrosImpuestos")).ToString("C")
                    txtPropinaLegal.Text = CDbl(Tabla.Rows(0).Item("PropinaLegal")).ToString("C")
                Else
                    txtSubtotalBienesN.EditValue = CDbl(0)
                    txtSubtotalServiciosN.EditValue = CDbl(0)
                    txtMontoFacturado.Text = CDbl(0).ToString("C")
                    txtItbisFacturado.EditValue = CDbl(0)
                    txtItbisRetenido.Text = CDbl(0).ToString("C")
                    txtItbisSujetoProp.Text = CDbl(0).ToString("C")
                    txtItbisalCosto.Text = CDbl(0).ToString("C")
                    txtItbisporAdelantar.Text = CDbl(0).ToString("C")
                    txtItbisPercibido.Text = CDbl(0).ToString("C")
                    txtISRPercibido.Text = CDbl(0).ToString("C")
                    txtISRRetencionRenta.Text = CDbl(0).ToString("C")
                    txtTotalISC.Text = CDbl(0).ToString("C")
                    txtOtrosImpuestos.Text = CDbl(0).ToString("C")
                    txtPropinaLegal.Text = CDbl(0).ToString("C")
                End If

                cbxTipoRetencionISR.SelectedIndex = 0

                If Me.Owner.Name = frm_registro_compras.Name Then
                    If frm_registro_compras.lblDiasCondicion.Text = 0 Then
                        cbxTipoPago.Text = "01 - EFECTIVO"
                    Else
                        cbxTipoPago.Text = "04 - COMPRA A CRÉDITO"
                    End If

                ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
                    If frm_factura_cxp.lblDiasCondicion.Text = 0 Then
                        cbxTipoPago.Text = "01 - EFECTIVO"
                    Else
                        cbxTipoPago.Text = "04 - COMPRA A CRÉDITO"
                    End If


                ElseIf Me.Owner.Name = frm_consulta_compras.name Then
                    If frm_consulta_compras.GridView1.GetFocusedRowCellValue("IDCondicion") = 1 Then
                        cbxTipoPago.Text = "01 - EFECTIVO"
                    Else
                        cbxTipoPago.Text = "04 - COMPRA A CRÉDITO"
                    End If

                ElseIf Me.Owner.Name = frm_consulta_facturas_cxp.name Then
                    If frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("IDCondicion") = 1 Then
                        cbxTipoPago.Text = "01 - EFECTIVO"
                    Else
                        cbxTipoPago.Text = "04 - COMPRA A CRÉDITO"
                    End If
                End If

            Else
                txtSubtotalBienesN.EditValue = CDbl(Tabla.Rows(0).Item("SubtotalBienes"))
                txtSubtotalServiciosN.EditValue = CDbl(Tabla.Rows(0).Item("SubtotalServicios"))
                txtMontoFacturado.Text = CDbl(CDbl(txtSubtotalBienesN.EditValue) + CDbl(txtSubtotalServiciosN.EditValue)).ToString("C")
                txtItbisFacturado.EditValue = CDbl(Tabla.Rows(0).Item("ItbisFacturado"))
                txtItbisRetenido.Text = CDbl(Tabla.Rows(0).Item("ItbisRetenido")).ToString("C")
                txtItbisSujetoProp.Text = CDbl(Tabla.Rows(0).Item("ItbisProporcionalidad")).ToString("C")
                txtItbisalCosto.Text = CDbl(Tabla.Rows(0).Item("ItbisalCosto")).ToString("C")
                txtItbisporAdelantar.Text = CDbl(Tabla.Rows(0).Item("ItbisAdelantar")).ToString("C")
                txtItbisPercibido.Text = CDbl(Tabla.Rows(0).Item("ItbisPercibidoenCompras")).ToString("C")
                txtISRPercibido.Text = CDbl(Tabla.Rows(0).Item("ISRPercibido")).ToString("C")
                txtISRRetencionRenta.Text = CDbl(Tabla.Rows(0).Item("ISRMontoRetencion")).ToString("C")
                txtTotalISC.Text = CDbl(Tabla.Rows(0).Item("ISCTotal")).ToString("C")
                txtOtrosImpuestos.Text = CDbl(Tabla.Rows(0).Item("OtrosImpuestos")).ToString("C")
                txtPropinaLegal.Text = CDbl(Tabla.Rows(0).Item("PropinaLegal")).ToString("C")

                cbxTipoPago.Text = Tabla.Rows(0).Item("TipoPago")
                cbxTipoRetencionISR.Text = Tabla.Rows(0).Item("TipoRetencion")
            End If

            RutaDocumento = Tabla.Rows(0).Item("RutaDocumento")

            If System.IO.File.Exists(RutaDocumento) = True Then
                Dim wFile As System.IO.FileStream
                wFile = New FileStream(RutaDocumento, FileMode.Open, FileAccess.Read)
                PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                wFile.Close()
                Label7.Visible = False
                Label25.Visible = False
            Else
                PicDocumento.Image = My.Resources.FormatoFactura
                Label7.Visible = True
                Label25.Visible = True
            End If
        End If
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Sub FillCondicion()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Condicion FROM Libregco.Condicion Where Nulo=0 ORDER BY Orden ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Condicion")
            cbxCondicion.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Condicion")

            For Each Fila As DataRow In Tabla.Rows
                cbxCondicion.Items.Add(Fila.Item("Condicion"))
            Next
            If Tabla.Rows.Count > 0 Then
                If Me.Owner.Name = frm_registro_compras.Name Then
                    cbxCondicion.Text = frm_registro_compras.cbxCondicion.Text
                ElseIf Me.Owner.Name = frm_factura_cxp.name Then
                    cbxCondicion.Text = frm_factura_cxp.cbxCondicion.Text
                End If

            Else
                MessageBox.Show("No se pudo cargar ninguna condición para definirla en la factura ya que no se encontraron resultados en la base de datos. Cree condiciones de ventas." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub

    Sub FillGastos()
        Try
            Dim dstemp As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDGasto,TipoGasto FROM libregco.tipogasto where Nulo=0 ORDER BY IDGASTO ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "TipoGasto")
            LUEGasto.Properties.DataSource = Nothing
            ConLibregco.Close()

            Dim Tabla As DataTable = dstemp.Tables("TipoGasto")

            LUEGasto.Properties.DataSource = Tabla
            LUEGasto.Properties.ValueMember = "IDGasto"
            LUEGasto.Properties.DisplayMember = "TipoGasto"

            LUEGasto.Properties.PopulateColumns()
            LUEGasto.Properties.Columns(LUEGasto.Properties.ValueMember).Visible = False


            If Tabla.Rows.Count > 0 Then
                If Me.Owner.Name = frm_registro_compras.Name Then
                    LUEGasto.EditValue = frm_registro_compras.LUEGasto.EditValue
                ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
                    LUEGasto.EditValue = frm_factura_cxp.cbxGasto.Tag.ToString
                End If

            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub FillMonedas()
        Dim dstemp As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM libregco.tipomoneda order by IDTipoMoneda ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Moneda")
        LUEMoneda.Properties.DataSource = Nothing
        ConLibregco.Close()

        Dim Tabla As DataTable = dstemp.Tables("Moneda")
        LUEMoneda.Properties.DataSource = Tabla
        LUEMoneda.Properties.ValueMember = "IDTipoMoneda"
        LUEMoneda.Properties.DisplayMember = "Texto"

        LUEMoneda.Properties.PopulateColumns()
        LUEMoneda.Properties.Columns(LUEMoneda.Properties.ValueMember).Visible = False

        If Tabla.Rows.Count > 0 Then
            If Me.Owner.Name = frm_registro_compras.Name Then
                LUEMoneda.EditValue = frm_registro_compras.LUEMoneda.EditValue
            ElseIf Me.Owner.Name = frm_factura_cxp.name Then
                LUEMoneda.EditValue = frm_factura_cxp.cbxMoneda.Tag.ToString
            End If

        End If
    End Sub

    Sub FillComprobanteFiscal()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT * FROM comprobantefiscal where IDContexto=1 ORDER BY TipoComprobante ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "ComprobanteFiscal")
            cbxTipoNCF.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")
            For Each Fila As DataRow In Tabla.Rows
                cbxTipoNCF.Items.Add(Fila.Item("TipoComprobante"))
            Next

            If Tabla.Rows.Count > 0 Then
                If Me.Owner.Name = frm_registro_compras.Name Then
                    cbxTipoNCF.Text = frm_registro_compras.CbxTipoComprobante.Text
                ElseIf Me.Owner.Name = frm_factura_cxp.name Then
                    cbxTipoNCF.Text = frm_factura_cxp.CbxTipoComprobante.Text

                End If

            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCondicion FROM Libregco.Condicion WHERE Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        cbxCondicion.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        If Me.Owner.Name = frm_registro_compras.Name Then
            frm_registro_compras.cbxCondicion.Text = cbxCondicion.Text
        ElseIf Me.Owner.Name = frm_factura_cxp.name Then
            cbxCondicion.Text = frm_factura_cxp.cbxCondicion.Text
        End If

    End Sub

    Private Sub cbxTipoNCF_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoNCF.SelectedIndexChanged
        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT * from" & SysName.Text & "ComprobanteFiscal Where TipoComprobante='" + cbxTipoNCF.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Comprobantes")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds.Tables("Comprobantes")
        cbxTipoNCF.Tag = Tabla.Rows(0).Item("IDComprobanteFiscal")

        If Me.Owner.Name = frm_registro_compras.Name Then
            frm_registro_compras.CbxTipoComprobante.Text = cbxTipoNCF.Text

            If frm_registro_compras.txtIDCompra.Text = "" Then
                If Tabla.Rows(0).Item("ImposicionCompra") = 1 Then
                    If DTConfiguracion.Rows(75 - 1).Item("Value2Int") = 1 Then
                        txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                        txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                        frm_registro_compras.txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                        frm_registro_compras.txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                    ElseIf DTConfiguracion.Rows(75 - 1).Item("Value2Int") = 2 Then
                        txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                        txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                        frm_registro_compras.txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                        frm_registro_compras.txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                    ElseIf DTConfiguracion.Rows(75 - 1).Item("Value2Int") = 3 Then
                        txtNCF.Mask = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF") & "00000000"
                        txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                        frm_registro_compras.txtNCF.Mask = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF") & "00000000"
                        frm_registro_compras.txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                    End If
                Else
                    If DTConfiguracion.Rows(75 - 1).Item("Value2Int") = 1 Then
                        txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                        txtNCF.Text = ""
                    ElseIf DTConfiguracion.Rows(75 - 1).Item("Value2Int") = 2 Then
                        txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                        txtNCF.Text = ""
                    ElseIf DTConfiguracion.Rows(75 - 1).Item("Value2Int") = 3 Then
                        txtNCF.Mask = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF") & "00000000"
                        txtNCF.Text = ""
                    End If
                End If

            Else
                txtNCF.Mask = ""
            End If

            txtNCF.Text = frm_registro_compras.txtNCF.Text

        ElseIf Me.Owner.Name = frm_factura_cxp.name Then

            frm_factura_cxp.CbxTipoComprobante.Text = cbxTipoNCF.Text

            If frm_factura_cxp.txtIDCompra.Text = "" Then
                If Tabla.Rows(0).Item("ImposicionCompra") = 1 Then
                    If frm_factura_cxp.TypeOfMetod = 1 Then
                        txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                        txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                        frm_factura_cxp.txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                        frm_factura_cxp.txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                    ElseIf frm_factura_cxp.TypeOfMetod = 2 Then
                        txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                        txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                        frm_factura_cxp.txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                        frm_factura_cxp.txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                    ElseIf frm_factura_cxp.TypeOfMetod = 3 Then
                        txtNCF.Mask = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF") & "00000000"
                        txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                        frm_factura_cxp.txtNCF.Mask = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF") & "00000000"
                        frm_factura_cxp.txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                    End If
                Else
                    If frm_factura_cxp.TypeOfMetod = 1 Then
                        txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                        txtNCF.Text = ""
                    ElseIf frm_factura_cxp.TypeOfMetod = 2 Then
                        txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                        txtNCF.Text = ""
                    ElseIf frm_factura_cxp.TypeOfMetod = 3 Then
                        txtNCF.Mask = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF") & "00000000"
                        txtNCF.Text = ""
                    End If
                End If

            Else
                txtNCF.Mask = ""
            End If

            txtNCF.Text = frm_factura_cxp.txtNCF.Text


        ElseIf Me.Owner.Name = frm_consulta_compras.name Then

            ConMixta.Open()
            cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=75", ConMixta)
            Dim TypeOfMetod As Integer = Convert.ToString(cmd.ExecuteScalar())
            ConMixta.Close()

            If Tabla.Rows(0).Item("ImposicionCompra") = 1 Then
                If TypeOfMetod = 1 Then
                    txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                    txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")

                ElseIf TypeOfMetod = 2 Then
                    txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                    txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")

                ElseIf TypeOfMetod = 3 Then
                    txtNCF.Mask = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF") & "00000000"
                    txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")

                End If
            Else
                If TypeOfMetod = 1 Then
                    txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                    txtNCF.Text = ""
                ElseIf TypeOfMetod = 2 Then
                    txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                    txtNCF.Text = ""
                ElseIf TypeOfMetod = 3 Then
                    txtNCF.Mask = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF") & "00000000"
                    txtNCF.Text = ""
                End If
            End If
        End If

    End Sub

    Private Sub txtItbisRetenido_Enter(sender As Object, e As EventArgs) Handles txtItbisRetenido.Enter
        If txtItbisRetenido.Text = "" Then
        Else
            txtItbisRetenido.Text = CDbl(txtItbisRetenido.Text)
        End If
    End Sub

    Private Sub txtItbisSujetoProp_Enter(sender As Object, e As EventArgs) Handles txtItbisSujetoProp.Enter
        If txtItbisSujetoProp.Text = "" Then
        Else
            txtItbisSujetoProp.Text = CDbl(txtItbisSujetoProp.Text)
        End If
    End Sub

    Private Sub txtItbisalCosto_Enter(sender As Object, e As EventArgs) Handles txtItbisalCosto.Enter
        If txtItbisalCosto.Text = "" Then
        Else
            txtItbisalCosto.Text = CDbl(txtItbisalCosto.Text)
        End If
    End Sub

    Private Sub txtItbisporAdelantar_Enter(sender As Object, e As EventArgs) Handles txtItbisporAdelantar.Enter
        If txtItbisporAdelantar.Text = "" Then
        Else
            txtItbisporAdelantar.Text = CDbl(txtItbisporAdelantar.Text)
        End If
    End Sub

    Private Sub txtItbisPercibido_Enter(sender As Object, e As EventArgs) Handles txtItbisPercibido.Enter
        If txtItbisPercibido.Text = "" Then
        Else
            txtItbisPercibido.Text = CDbl(txtItbisPercibido.Text)
        End If
    End Sub

    Private Sub txtMontoRetencionRenta_Enter(sender As Object, e As EventArgs) Handles txtISRRetencionRenta.Enter
        If txtISRRetencionRenta.Text = "" Then
        Else
            txtISRRetencionRenta.Text = CDbl(txtISRRetencionRenta.Text)
        End If
    End Sub

    Private Sub txtISRPercibido_Enter(sender As Object, e As EventArgs) Handles txtISRPercibido.Enter
        If txtISRPercibido.Text = "" Then
        Else
            txtISRPercibido.Text = CDbl(txtISRPercibido.Text)
        End If
    End Sub

    Private Sub txtPropinaLegal_Enter(sender As Object, e As EventArgs) Handles txtPropinaLegal.Enter
        If txtPropinaLegal.Text = "" Then
        Else
            txtPropinaLegal.Text = CDbl(txtPropinaLegal.Text)
        End If
    End Sub

    Private Sub txtTotalISC_Enter(sender As Object, e As EventArgs) Handles txtTotalISC.Enter
        If txtTotalISC.Text = "" Then
        Else
            txtTotalISC.Text = CDbl(txtTotalISC.Text)
        End If
    End Sub

    Private Sub txtOtrosImpuestos_Enter(sender As Object, e As EventArgs) Handles txtOtrosImpuestos.Enter
        If txtOtrosImpuestos.Text = "" Then
        Else
            txtOtrosImpuestos.Text = CDbl(txtOtrosImpuestos.Text)
        End If
    End Sub

    Private Sub txtItbisRetenido_Leave(sender As Object, e As EventArgs) Handles txtItbisRetenido.Leave
        Try
            If txtItbisRetenido.Text = "" Then
                txtItbisRetenido.Text = CDbl(0).ToString("C")
            Else

                txtItbisRetenido.Text = CDbl(txtItbisRetenido.Text).ToString("C")
            End If

        Catch ex As Exception
            txtItbisRetenido.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtItbisSujetoProp_Leave(sender As Object, e As EventArgs) Handles txtItbisSujetoProp.Leave
        Try
            If txtItbisSujetoProp.Text = "" Then
                txtItbisSujetoProp.Text = CDbl(0).ToString("C")
            Else

                txtItbisSujetoProp.Text = CDbl(txtItbisSujetoProp.Text).ToString("C")
            End If

        Catch ex As Exception
            txtItbisSujetoProp.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtItbisalCosto_Leave(sender As Object, e As EventArgs) Handles txtItbisalCosto.Leave
        Try
            If txtItbisalCosto.Text = "" Then
                txtItbisalCosto.Text = CDbl(0).ToString("C")
            Else

                txtItbisalCosto.Text = CDbl(txtItbisalCosto.Text).ToString("C")
            End If

        Catch ex As Exception
            txtItbisalCosto.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtItbisporAdelantar_Leave(sender As Object, e As EventArgs) Handles txtItbisporAdelantar.Leave
        Try
            If txtItbisporAdelantar.Text = "" Then
                txtItbisporAdelantar.Text = CDbl(0).ToString("C")
            Else

                txtItbisporAdelantar.Text = CDbl(txtItbisporAdelantar.Text).ToString("C")
            End If

        Catch ex As Exception
            txtItbisporAdelantar.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtItbisPercibido_Leave(sender As Object, e As EventArgs) Handles txtItbisPercibido.Leave
        Try
            If txtItbisPercibido.Text = "" Then
                txtItbisPercibido.Text = CDbl(0).ToString("C")
            Else

                txtItbisPercibido.Text = CDbl(txtItbisPercibido.Text).ToString("C")
            End If

        Catch ex As Exception
            txtItbisPercibido.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtMontoRetencionRenta_Leave(sender As Object, e As EventArgs) Handles txtISRRetencionRenta.Leave
        Try
            If txtISRRetencionRenta.Text = "" Then
                txtISRRetencionRenta.Text = CDbl(0).ToString("C")
            Else

                txtISRRetencionRenta.Text = CDbl(txtISRRetencionRenta.Text).ToString("C")
            End If

        Catch ex As Exception
            txtISRRetencionRenta.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtISRPercibido_Leave(sender As Object, e As EventArgs) Handles txtISRPercibido.Leave
        Try
            If txtISRPercibido.Text = "" Then
                txtISRPercibido.Text = CDbl(0).ToString("C")
            Else

                txtISRPercibido.Text = CDbl(txtISRPercibido.Text).ToString("C")
            End If

        Catch ex As Exception
            txtISRPercibido.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtTotalISC_Leave(sender As Object, e As EventArgs) Handles txtTotalISC.Leave
        Try
            If txtTotalISC.Text = "" Then
                txtTotalISC.Text = CDbl(0).ToString("C")
            Else

                txtTotalISC.Text = CDbl(txtTotalISC.Text).ToString("C")
            End If

        Catch ex As Exception
            txtTotalISC.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtOtrosImpuestos_Leave(sender As Object, e As EventArgs) Handles txtOtrosImpuestos.Leave
        Try
            If txtOtrosImpuestos.Text = "" Then
                txtOtrosImpuestos.Text = CDbl(0).ToString("C")
            Else

                txtOtrosImpuestos.Text = CDbl(txtOtrosImpuestos.Text).ToString("C")
            End If

        Catch ex As Exception
            txtOtrosImpuestos.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtPropinaLegal_Leave(sender As Object, e As EventArgs) Handles txtPropinaLegal.Leave
        Try
            If txtPropinaLegal.Text = "" Then
                txtPropinaLegal.Text = CDbl(0).ToString("C")
            Else

                txtPropinaLegal.Text = CDbl(txtPropinaLegal.Text).ToString("C")
            End If

        Catch ex As Exception
            txtPropinaLegal.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtSubtotalBienesN_TextChanged(sender As Object, e As EventArgs) Handles txtSubtotalBienesN.EditValueChanged
        Try
            txtMontoFacturado.Text = CDbl(CDbl(txtSubtotalBienesN.EditValue) + CDbl(txtSubtotalServiciosN.EditValue)).ToString("C")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSubtotalServiciosN_TextChanged(sender As Object, e As EventArgs) Handles txtSubtotalServiciosN.EditValueChanged
        Try
            txtMontoFacturado.Text = CDbl(CDbl(txtSubtotalBienesN.EditValue) + CDbl(txtSubtotalServiciosN.EditValue)).ToString("C")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtItbisRetenido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItbisRetenido.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtItbisRetenido.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtItbisSujetoProp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItbisSujetoProp.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtItbisSujetoProp.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtItbisalCosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItbisalCosto.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtItbisalCosto.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtItbisporAdelantar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItbisporAdelantar.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtItbisporAdelantar.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtItbisPercibido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItbisPercibido.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtItbisPercibido.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtMontoRetencionRenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtISRRetencionRenta.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtISRRetencionRenta.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtISRPercibido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtISRPercibido.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtISRPercibido.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalISC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalISC.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtTotalISC.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtOtrosImpuestos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOtrosImpuestos.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtOtrosImpuestos.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPropinaLegal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPropinaLegal.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtPropinaLegal.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbxMoneda_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Me.Owner.Name = frm_registro_compras.Name Then
            frm_registro_compras.LueMoneda.EditValue = LUEMoneda.EditValue

        ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
            frm_factura_cxp.cbxMoneda.Tag = LUEMoneda.EditValue
        End If

    End Sub

    Private Sub txtNCF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNCF.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "AB0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNCF_Leave(sender As Object, e As EventArgs) Handles txtNCF.Leave
        If cbxTipoNCF.Text <> "" Then

            If txtNCF.MaskFull = False And frm_registro_compras.ImponerEscrituradeNCF = 1 Then
                MessageBox.Show("No se ha completado la numeración del comprobante fiscal de la factura de compra. Por favor complete el registro.", "Numeración no completada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                txtNCF.Text = txtNCF.Text.ToUpper

                If Me.Owner.Name = frm_registro_compras.Name Then
                    frm_registro_compras.txtNCF.Text = txtNCF.Text.ToUpper
                ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
                    frm_factura_cxp.txtNCF.Text = txtNCF.Text.ToUpper
                End If

                LUEGasto.Focus()

            End If
        End If


    End Sub

    Private Sub cbxTipoNCF_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbxTipoNCF.SelectionChangeCommitted
        txtNCF.Focus()
    End Sub

    Private Sub cbxMoneda_SelectionChangeCommitted(sender As Object, e As EventArgs)
        txtSubtotalBienesN.Focus()
        txtSubtotalBienesN.SelectAll()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Try

            If Me.Owner.Name = frm_registro_compras.Name Then
            sqlQ = "UPDATE Compras SET IDTipoGasto='" + LUEGasto.EditValue.ToString + "',IDComprobanteFiscal='" + cbxTipoNCF.Tag.ToString + "',NCF='" + txtNCF.Text + "',SubtotalLlenado=1,SubtotalBienes='" + CDbl(txtSubtotalBienesN.EditValue).ToString + "',SubtotalServicios='" + CDbl(txtSubtotalServiciosN.EditValue).ToString + "',ItbisFacturado='" + CDbl(txtItbisFacturado.EditValue).ToString + "',ItbisRetenido='" + CDbl(txtItbisRetenido.Text).ToString + "',ItbisProporcionalidad='" + CDbl(txtItbisSujetoProp.Text).ToString + "',ItbisalCosto='" + CDbl(txtItbisalCosto.Text).ToString + "',ItbisAdelantar='" + CDbl(txtItbisporAdelantar.Text).ToString + "',ItbisPercibidoenCompras='" + CDbl(txtItbisPercibido.Text).ToString + "',IDISRTipoRetencion='" + cbxTipoRetencionISR.Tag.ToString + "',OtrosImpuestos='" + CDbl(txtOtrosImpuestos.Text).ToString + "',ISRPercibido='" + CDbl(txtISRPercibido.Text).ToString + "',ISRMontoRetencion='" + CDbl(txtISRRetencionRenta.Text).ToString + "',PropinaLegal='" + CDbl(txtPropinaLegal.Text).ToString + "',IDTipoPago='" + cbxTipoPago.Tag.ToString + "' WHERE IDCompra= (" + frm_registro_compras.txtIDCompra.Text + ")"
            GuardarDatos()

                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

            ElseIf Me.Owner.Name = frm_factura_cxp.name Then
            sqlQ = "UPDATE Compras SET  IDTipoGasto='" + LUEGasto.EditValue.ToString + "',IDComprobanteFiscal='" + cbxTipoNCF.Tag.ToString + "',NCF='" + txtNCF.Text + "',SubtotalLlenado=1,SubtotalBienes='" + CDbl(txtSubtotalBienesN.EditValue).ToString + "',SubtotalServicios='" + CDbl(txtSubtotalServiciosN.EditValue).ToString + "',ItbisFacturado='" + CDbl(txtItbisFacturado.EditValue).ToString + "',ItbisRetenido='" + CDbl(txtItbisRetenido.Text).ToString + "',ItbisProporcionalidad='" + CDbl(txtItbisSujetoProp.Text).ToString + "',ItbisalCosto='" + CDbl(txtItbisalCosto.Text).ToString + "',ItbisAdelantar='" + CDbl(txtItbisporAdelantar.Text).ToString + "',ItbisPercibidoenCompras='" + CDbl(txtItbisPercibido.Text).ToString + "',IDISRTipoRetencion='" + cbxTipoRetencionISR.Tag.ToString + "',OtrosImpuestos='" + CDbl(txtOtrosImpuestos.Text).ToString + "',ISRPercibido='" + CDbl(txtISRPercibido.Text).ToString + "',ISRMontoRetencion='" + CDbl(txtISRRetencionRenta.Text).ToString + "',PropinaLegal='" + CDbl(txtPropinaLegal.Text).ToString + "',IDTipoPago='" + cbxTipoPago.Tag.ToString + "' WHERE IDCompra= (" + frm_factura_cxp.txtIDCompra.Text + ")"
            GuardarDatos()

                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

            ElseIf Me.Owner.Name = frm_consulta_compras.Name Then
            sqlQ = "UPDATE Compras SET  IDTipoGasto='" + LUEGasto.EditValue.ToString + "',IDComprobanteFiscal='" + cbxTipoNCF.Tag.ToString + "',NCF='" + txtNCF.Text + "',SubtotalLlenado=1,SubtotalBienes='" + CDbl(txtSubtotalBienesN.EditValue).ToString + "',SubtotalServicios='" + CDbl(txtSubtotalServiciosN.EditValue).ToString + "',ItbisFacturado='" + CDbl(txtItbisFacturado.EditValue).ToString + "',ItbisRetenido='" + CDbl(txtItbisRetenido.Text).ToString + "',ItbisProporcionalidad='" + CDbl(txtItbisSujetoProp.Text).ToString + "',ItbisalCosto='" + CDbl(txtItbisalCosto.Text).ToString + "',ItbisAdelantar='" + CDbl(txtItbisporAdelantar.Text).ToString + "',ItbisPercibidoenCompras='" + CDbl(txtItbisPercibido.Text).ToString + "',IDISRTipoRetencion='" + cbxTipoRetencionISR.Tag.ToString + "',OtrosImpuestos='" + CDbl(txtOtrosImpuestos.Text).ToString + "',ISRPercibido='" + CDbl(txtISRPercibido.Text).ToString + "',ISRMontoRetencion='" + CDbl(txtISRRetencionRenta.Text).ToString + "',PropinaLegal='" + CDbl(txtPropinaLegal.Text).ToString + "',IDTipoPago='" + cbxTipoPago.Tag.ToString + "' WHERE IDCompra= (" + frm_consulta_compras.GridView1.GetFocusedRowCellValue("ID").ToString + ")"
            GuardarDatos()

                Dim myRow() As DataRow
                myRow = frm_consulta_compras.TableCompras.Select("ID = '" + frm_consulta_compras.GridView1.GetFocusedRowCellValue("ID").ToString + "'")
                myRow(0)("SubTotalVerificadoValue") = 1

                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

            ElseIf Me.Owner.Name = frm_consulta_facturas_cxp.Name Then
            sqlQ = "UPDATE Compras SET  IDTipoGasto='" + LUEGasto.EditValue.ToString + "',IDComprobanteFiscal='" + cbxTipoNCF.Tag.ToString + "',NCF='" + txtNCF.Text + "',SubtotalLlenado=1,SubtotalBienes='" + CDbl(txtSubtotalBienesN.EditValue).ToString + "',SubtotalServicios='" + CDbl(txtSubtotalServiciosN.EditValue).ToString + "',ItbisFacturado='" + CDbl(txtItbisFacturado.EditValue).ToString + "',ItbisRetenido='" + CDbl(txtItbisRetenido.Text).ToString + "',ItbisProporcionalidad='" + CDbl(txtItbisSujetoProp.Text).ToString + "',ItbisalCosto='" + CDbl(txtItbisalCosto.Text).ToString + "',ItbisAdelantar='" + CDbl(txtItbisporAdelantar.Text).ToString + "',ItbisPercibidoenCompras='" + CDbl(txtItbisPercibido.Text).ToString + "',IDISRTipoRetencion='" + cbxTipoRetencionISR.Tag.ToString + "',OtrosImpuestos='" + CDbl(txtOtrosImpuestos.Text).ToString + "',ISRPercibido='" + CDbl(txtISRPercibido.Text).ToString + "',ISRMontoRetencion='" + CDbl(txtISRRetencionRenta.Text).ToString + "',PropinaLegal='" + CDbl(txtPropinaLegal.Text).ToString + "',IDTipoPago='" + cbxTipoPago.Tag.ToString + "' WHERE IDCompra= (" + frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("ID").ToString + ")"
            GuardarDatos()

                Dim myRow() As DataRow
                myRow = frm_consulta_facturas_cxp.TableCompras.Select("ID = '" + frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("ID").ToString + "'")
                myRow(0)("SubTotalVerificadoValue") = 1

                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))
            End If

        Me.Close()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString)
        'End Try
    End Sub

    Private Sub cbxTipoPago_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbxTipoPago.SelectionChangeCommitted
        Button1.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
            Con.Close()
        End Try
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        If Me.Owner.Name = frm_registro_compras.Name Then
            frm_registro_compras.DtpFechaFact.Value = dtpFecha.Value

        ElseIf Me.Owner.Name = frm_factura_cxp.name Then
            frm_factura_cxp.DtpFechaFact.Value = dtpFecha.Value
        End If
    End Sub

    Private Sub PicDocumento_LoadCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles PicDocumento.LoadCompleted
        PicDocumento.Location = New Point(0, 0)
        PicDocumento.Enabled = True
    End Sub

    Private Sub PicDocumento_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDocumento.MouseDown
        Try

            If RutaDocumento <> "" Then
                cmds = True
                sp = e.Location
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub PicDocumento_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDocumento.MouseMove
        Try
            If RutaDocumento <> "" Then
                If cmds Then
                    PicDocumento.Location = PicDocumento.Location - sp + e.Location
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If RutaDocumento = "" Then
        Else
            PicDocumento.Width += 100%
            PicDocumento.Height += 100%
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If RutaDocumento = "" Then
        Else
            PicDocumento.Width -= 100%
            PicDocumento.Height -= 100%
        End If
    End Sub

    Private Sub PicDocumento_MouseUp(sender As Object, e As MouseEventArgs) Handles PicDocumento.MouseUp
        cmds = False
    End Sub

    Private Sub cbxTipoPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoPago.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT idTipoPago606 FROM TipoPago606 WHERE TipoPago= '" + cbxTipoPago.SelectedItem + "'", ConLibregco)
        cbxTipoPago.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub cbxTipoRetencionISR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoRetencionISR.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT idRetencionISR FROM RetencionISR WHERE TipoRetencion= '" + cbxTipoRetencionISR.SelectedItem + "'", ConLibregco)
        cbxTipoRetencionISR.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub LUEGasto_EditValueChanged(sender As Object, e As EventArgs) Handles LUEGasto.EditValueChanged
        If Me.Owner.Name = frm_registro_compras.Name Then
            frm_registro_compras.LUEGasto.EditValue = LUEGasto.EditValue
        ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
            frm_factura_cxp.cbxGasto.Tag = LUEGasto.EditValue
        End If

    End Sub
End Class