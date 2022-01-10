Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports DevExpress.XtraGrid.Views.Grid

Public Class frm_recibo_pagos
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim HeaderIncluir As New CheckBox
    Friend lblDescuento, lbltotalAbono, lblTransaccion, lblSumaLetra, lblMoneda, lblDireccion, lblTelefono, lblIdentificacion, DefaultCurrency, LiberarControles As New Label
    Dim Permisos, IDDescuentoAplicado As New ArrayList
    Friend AccionesModulosAutorizadas As New ArrayList

    Friend DTFacturas As New DataTable
    Friend DTPagares As New DataTable

    Private Sub frm_recibo_pagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        CargarConfiguracion()
        Permisos = PasarPermisos(Me.Tag)
        AddHeaderCheckBox()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub ControlRapido()
        Try
            If DTConfiguracion.Rows(102 - 1).Item("Value2Int").ToString = "1" Then
                If Me.WindowState = FormWindowState.Maximized Then
                    If frm_accesos_rapidos_clientes.Visible = True Then
                        frm_accesos_rapidos_clientes.Close()
                    End If
                Else
                        If SearchingFast = False Then
                        If Me.WindowState = FormWindowState.Normal Then
                            If frm_accesos_rapidos_clientes.Visible = True Then
                                If frm_accesos_rapidos_clientes.Owner.Name <> Me.Name Then
                                    frm_accesos_rapidos_clientes.Close()
                                    frm_accesos_rapidos_clientes.Show(Me)
                                End If
                            Else
                                frm_accesos_rapidos_clientes.Show(Me)
                            End If

                            frm_accesos_rapidos_clientes.Location = New Point(Me.Location.X + Me.Size.Width - 12, Me.Location.Y)
                        Else
                            If frm_accesos_rapidos_clientes.Visible = True Then
                                frm_accesos_rapidos_clientes.Close()
                            End If
                        End If
                    End If
                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarConfiguracion()
        Try
            Con.Open()
            ConLibregco.Open()

            If DTConfiguracion.Rows(63 - 1).Item("Value2Int") = 1 Then
                txtFechaPago.Enabled = True
                txtHora.Enabled = True
            Else
                txtFechaPago.Enabled = False
                txtHora.Enabled = False
            End If

            'Permitir pagos con tarjeta
            'cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=154", Con)
            'PermitirPagosTarjeta.Text = DTConfiguracion.Rows(154 - 1).Item("Value2Int")

            ''Usar formatos largos
            'cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=165", Con)
            'UseLongFormat.Text = DTConfiguracion.Rows(165 - 1).Item("Value2Int")

            'Moneda predeterminada
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=209", Con)
            DefaultCurrency.Text = CInt(Convert.ToString(cmd.ExecuteScalar()))

            Con.Close()
            ConLibregco.Close()

            FillTipoDocumentos()

            AddHandler RepositoryItemTextEdit1.Enter, AddressOf Enter_Handler
            AddHandler RepositoryItemTextEdit2.Enter, AddressOf Enter_Handler
            AddHandler RepositoryItemTextEdit3.Enter, AddressOf Enter_Handler
            AddHandler RepositoryItemTextEdit1.EditValueChanged, AddressOf PostChanges_Handler
            AddHandler RepositoryItemTextEdit2.EditValueChanged, AddressOf PostChanges_Handler
            AddHandler RepositoryItemTextEdit3.EditValueChanged, AddressOf PostChanges_Handler
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub Enter_Handler(ByVal sender As Object, ByVal e As EventArgs)
        Dim textEdit As XtraEditors.TextEdit = TryCast(sender, XtraEditors.TextEdit)
        If textEdit IsNot Nothing Then textEdit.SelectAll()
    End Sub


    Private Sub PostChanges_Handler(ByVal sender As Object, ByVal e As EventArgs)
        AdvBandedGridView1.PostEditor()

    End Sub

    Private Sub FillTipoDocumentos()
        Dim dstemp As New DataSet

        Con.Open()
        cmd = New MySqlCommand("Select IDTipoDocumento,Documento FROM TipoDocumento", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "TipoDocumento")
        Con.Close()

        Dim TablaTipoDocumento As DataTable = dstemp.Tables("TipoDocumento")

        RepositoryItemLookUpEdit1.DataSource = TablaTipoDocumento
        RepositoryItemLookUpEdit1.ValueMember = "IDTipoDocumento"
        RepositoryItemLookUpEdit1.DisplayMember = "Documento"

        RepositoryItemLookUpEdit1.PopulateColumns()
        RepositoryItemLookUpEdit1.Columns(RepositoryItemLookUpEdit1.ValueMember).Visible = False
        RepositoryItemLookUpEdit1.ShowHeader = False
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        HabilitarMontoAplicado()
        ControlRapido()
        lblSumaLetra.Text = ""
        lblTransaccion.Text = ""
        lblDireccion.Text = ""
        lblTelefono.Text = ""
        lblIdentificacion.Text = ""
        lblStatusBar.ForeColor = Color.Black
        lblStatusBar.Text = "Listo"
        GPCliente.Text = " Información general"
        PicImagen.Image = My.Resources.no_photo
        ControlSuperClave = 1
        LiberarControles.Text = 0
        txtFechaPago.Value = Today
        lblDescuento.Text = 0
        lbltotalAbono.Text = 0
        cbxMoneda.EditValue = CInt(DefaultCurrency.Text)
        ChkNulo.Checked = False
        HeaderIncluir.Checked = False
        RepositoryItemTextEdit1.ReadOnly = False
        RepositoryItemTextEdit2.ReadOnly = False
        GbAplicado.Visible = True
        AdvBandedGridView1.IndicatorWidth = 6
        ResetHeaderCheckBoxLocation(AdvBandedGridView1.Columns("Incluir").ColIndex, -1)
        cbxMoneda.Properties.Items.Clear()
        DTFacturas.Rows.Clear()
        btnBuscarCliente.Focus()
        Hora.Enabled = True
    End Sub

    Private Sub AddHeaderCheckBox()
        HeaderIncluir = New CheckBox()
        HeaderIncluir.Name = "HeaderIncluir"
        HeaderIncluir.Size = New Size(14, 14)
        HeaderIncluir.ThreeState = False
        HeaderIncluir.FlatStyle = FlatStyle.Standard
        GridControl1.Controls.Add(HeaderIncluir)

        AddHandler HeaderIncluir.CheckedChanged, AddressOf HeaderIncluir_CheckedChanged
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
        lblUsuario.Text = frm_inicio.lblNombre.Text
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Value = DateTime.Now
    End Sub

    Private Sub AdvBandedGridView1_RowCellStyle(sender As Object, e As XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles AdvBandedGridView1.RowCellStyle
        'Marcar facturas vencidas
        Dim currentView As GridView = TryCast(sender, GridView)
        If e.Column.FieldName = "FechaVencimiento" Then
            If CDate(currentView.GetRowCellValue(e.RowHandle, "FechaVencimiento")) < Today Then
                e.Appearance.ForeColor = Color.Red
                e.Appearance.Font = New Font("Tahoma", 8, FontStyle.Regular Or FontStyle.Underline)
            End If

        ElseIf e.Column.FieldName = "EstadoFactura" Then
            e.Appearance.ForeColor = Color.FromArgb(currentView.GetRowCellValue(e.RowHandle, "ColorColumn"))
        End If
    End Sub

    Sub VerifyBalances()
        If DTFacturas.Rows.Count = 0 Then
            For Each itm As DevExpress.XtraEditors.Controls.ImageComboBoxItem In cbxMoneda.Properties.Items
                If cbxMoneda.EditValue <> itm.Value Then
                    cbxMoneda.EditValue = CInt(itm.Value)
                End If

                If DTFacturas.Rows.Count > 0 Then
                    Exit For
                End If
            Next
        End If
    End Sub

    Sub RefrescarTablaFacturas()
        Try
            If txtIDCliente.Text <> "" Then
                Dim DsFactura As New DataSet

                DTFacturas = GetDataTable("SELECT '' as IDDetalleAbono,FacturaDatos.NombreFactura,IDFacturaDatos,SecondID,FacturaDatos.IDTipoDocumento,FacturaDatos.Fecha,FechaVencimiento,if(FacturaDatos.Fecha<Now(),DATEDIFF(now(),FacturaDatos.Fecha),0) as DiasVencidos,TotalNeto,Balance,Cargos as CargosFactura,EstadoFactura,EstadoFactura.Color as ColorColumn,FacturaDatos.Balance as Final,0.00 as CargosExcento,'0' as Incluir,0.00 as Cargos,0.00 as Aplicar,0.00 as Descuento,1 as Info FROM" & SysName.Text & "FacturaDatos INNER JOIN Libregco.EstadoFactura ON FacturaDatos.IDEstadoFactura=EstadoFactura.IDEstadoFactura LEFT JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion WHERE IDCliente='" + txtIDCliente.Text + "' and FacturaDatos.Balance>0 AND Transaccion.IDMoneda='" + cbxMoneda.EditValue.ToString + "' and FacturaDatos.Nulo=0", ConMixta)
                DTFacturas.TableName = "Facturas"

                DsFactura.Tables.Add(DTFacturas)

                If DTConfiguracion.Rows(73 - 1).Item("Value2Int") = 1 Then
                    DTPagares = GetDataTable("Select IDPagare,IDFactura as IDFacturaDatos,Concat(NoPagare,'/',Pagares.Cantidad) as NoPagare,NoPagare as Numero,TIMESTAMP(Pagares.FechaVencimiento,FacturaDatos.Hora) AS FechaVencimiento,datediff(now(),Pagares.FechaVencimiento) as DiasVencidos,Monto,Pagares.Balance,Nombre,Descripcion from" & SysName.Text & "pagares INNER JOIN" & SysName.Text & "empleados On pagares.IDEmpleado=Empleados.IDEmpleado  INNER JOIN Libregco.StatusPagare On Pagares.IDStatusPagare=StatusPagare.IDStatusPagare INNER JOIN" & SysName.Text & "FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos LEFT JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion WHERE Pagares.Balance>0 and FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and FacturaDatos.Balance>0 AND Transaccion.IDMoneda='" + cbxMoneda.EditValue.ToString + "' and FacturaDatos.Nulo=0 ORDER BY FechaVencimiento ASC", ConMixta)
                    DTPagares.TableName = "Pagares"

                    DsFactura.Tables.Add(DTPagares)

                    DsFactura.Relations.Add("IDFacturaDatos", DTFacturas.Columns("IDFacturaDatos"), DTPagares.Columns("IDFacturaDatos"), False)
                End If


                AddHandler RepositoryItemCheckEdit1.EditValueChanged, AddressOf OnEditValueChanged


                GridControl1.DataSource = DsFactura
                GridControl1.DataMember = "Facturas"

                CheckCargos()

                If DTFacturas.Rows.Count < 10 Then
                    AdvBandedGridView1.IndicatorWidth = 25
                Else
                    AdvBandedGridView1.IndicatorWidth = 35
                End If

                AdvBandedGridView1.ClearSelection()
            End If

            ResetHeaderCheckBoxLocation(AdvBandedGridView1.Columns("Incluir").ColIndex, -1)

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " RefrescarTablaFacturas")
        End Try

    End Sub

    Private Sub OnEditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        AdvBandedGridView1.PostEditor()

    End Sub

    Sub BuscarNotasDescuentos()
        Try
            Dim ds As New DataSet
            Dim Tabla As DataTable
            Dim ValorFacturadesdeNota As Double
            Dim FechadeNota As String

            ConMixta.Open()

            For Each rw As DataRow In DTFacturas.Rows
                Ds.Clear()
                cmd = New MySqlCommand("SELECT IDFacturaDatos,NombreFactura,Inicial,(select coalesce(sum(total),0) from" & SysName.Text & "DetalleAbonos where DetalleAbonos.IDFactura=FacturaDatos.IDFacturaDatos) as MontoPagado,NotaContado,CondicionContado FROM" & SysName.Text & "facturadatos where IDFacturaDatos= '" + rw.Item("IDFacturaDatos").ToString + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "FacturaDatos")

                Tabla = Ds.Tables("FacturaDatos")

                If Tabla.Rows.Count > 0 Then
                    If Tabla.Rows(0).Item("NotaContado") = "1" Then
                        ValorFacturadesdeNota = CDbl(After(Tabla.Rows(0).Item("CondicionContado"), "$"))
                        FechadeNota = CDate(Between(Tabla.Rows(0).Item("CondicionContado"), "del ", " sólo"))

                        If CDate(FechadeNota) >= Today Then
                            Dim NotificacionMessage As New NotifyIcon
                            NotificacionMessage.Icon = My.Resources.Libregco_Icon
                            NotificacionMessage.Visible = True

                            AddHandler NotificacionMessage.BalloonTipClicked, AddressOf GotoMessage
                            AddHandler NotificacionMessage.Click, AddressOf GotoMessage
                            AddHandler NotificacionMessage.BalloonTipClosed, AddressOf DisposeMessage

                            NotificacionMessage.Tag = rw.Item("IDFacturaDatos")
                            NotificacionMessage.Text = "Validez de nota de contado"
                            NotificacionMessage.ShowBalloonTip(10, "Validez de nota de contado", "Realiza el saldo de la factura " & rw.Item("SecondID") & " con tan solo " & CDbl(CDbl(ValorFacturadesdeNota) - CDbl(Tabla.Rows(0).Item("Inicial")) - CDbl(Tabla.Rows(0).Item("MontoPagado"))).ToString("C") & "." & vbNewLine & "Da click aquí para aplicar", ToolTipIcon.Info)
                        End If
                    End If
                End If
            Next

            ConMixta.Close()


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DisposeMessage(sendr As Object, e As EventArgs)
        DirectCast(sendr, NotifyIcon).Visible = False
        DirectCast(sendr, NotifyIcon).Dispose()
    End Sub

    Private Sub GotoMessage(Sendr As Object, e As EventArgs)
        Dim DsTemp As New DataSet
        Dim ValorFacturadesdeNota As Double
        Dim FechadeNota As String

        Dim IDFactura As String = DirectCast(Sendr, NotifyIcon).Tag

        DsTemp.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDFacturaDatos,NombreFactura,Inicial,(select coalesce(sum(total),0) from" & SysName.Text & "DetalleAbonos where DetalleAbonos.IDFactura=FacturaDatos.IDFacturaDatos) as MontoPagado,NotaContado,CondicionContado FROM" & SysName.Text & "facturadatos where IDFacturaDatos= '" + IDFactura + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "FacturaDatos")
        ConMixta.Close()

        Dim Tabla As DataTable = DsTemp.Tables("FacturaDatos")

        ValorFacturadesdeNota = CDbl(After(Tabla.Rows(0).Item("CondicionContado"), "$"))
        FechadeNota = CDate(Between(Tabla.Rows(0).Item("CondicionContado"), "del ", " sólo"))

        For Each rw As DataRow In DTFacturas.Rows
            If rw.Item("IDFacturaDatos") = IDFactura Then

                If Not IDDescuentoAplicado.Contains(IDFactura) Then
                    IDDescuentoAplicado.Add(IDFactura)
                End If

                rw.Item("Aplicar") = CDbl(CDbl(ValorFacturadesdeNota) - CDbl(Tabla.Rows(0).Item("Inicial")) - CDbl(Tabla.Rows(0).Item("MontoPagado")))
                RepositoryItemTextEdit1.ReadOnly = True

                rw.Item("Descuento") = CDbl(rw.Item("Balance")) - (CDbl(CDbl(ValorFacturadesdeNota) - CDbl(Tabla.Rows(0).Item("Inicial")) - CDbl(Tabla.Rows(0).Item("MontoPagado"))))
                RepositoryItemTextEdit2.ReadOnly = True
                rw.Item("EstadoFactura") = "Saldo con nota"
                btnAplicarMonto.Enabled = False

            End If
        Next
    End Sub

    Sub CheckCargos()
        If DTFacturas.Rows.Count > 0 Then
            Dim CargosAcumulados As Double = 0
            For Each row As DataRow In DTFacturas.Rows
                CargosAcumulados = CDbl(row.Item("CargosFactura")) + CDbl(row.Item("Cargos")) + CargosAcumulados
            Next

            If CargosAcumulados = 0 Then
                Cargos.Visible = False
                CargosFactura.Visible = False
                Cargos.OptionsColumn.ReadOnly = True
            Else
                Cargos.Visible = True
                CargosFactura.Visible = True
                Cargos.OptionsColumn.ReadOnly = False
            End If
        Else
            Cargos.Visible = True
            CargosFactura.Visible = True
            Cargos.OptionsColumn.ReadOnly = False
        End If

    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub txtMontoAplicar_Leave(sender As Object, e As EventArgs) Handles txtMontoAplicar.Leave
        Try
            If txtMontoAplicar.EditValue = 0 Then
                LimpiarAplicados()
                txtConceptoPago.Text = ""
            End If

        Catch ex As Exception
            txtMontoAplicar.EditValue = CDbl(0)
            txtConceptoPago.Text = ""
            LimpiarAplicados()
        End Try
    End Sub

    Private Sub VerificarTransf()
        Try
            Dim SumaCargo As Double = 0
            Dim SumaBalance As Double = 0
            Dim SumaDescuento As Double = 0

            For Each Rows As DataRow In DTFacturas.Rows
                SumaBalance = SumaBalance + CDbl(Rows.Item("Balance"))
                SumaCargo = SumaCargo + CDbl(Rows.Item("CargosFactura"))
                SumaDescuento = SumaDescuento + CDbl(Rows.Item("Descuento"))
            Next

            If CDbl(txtMontoAplicar.EditValue) + SumaDescuento > SumaBalance + SumaCargo Then
                MessageBox.Show("El monto aplicado es mayor al balance de los pagos tomando en cuenta los descuentos que serán aplicados." & vbNewLine & "Aplicado: " & txtMontoAplicar.Text & " + Descuento: " & SumaDescuento.ToString("C") & " > " & "Balance y Cargos: " & (SumaBalance + SumaCargo).ToString("C"), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ControlSuperClave = 1
            Else
                ControlSuperClave = 0
            End If

        Catch ex As Exception
            txtMontoAplicar.EditValue = CDbl(0)
        End Try
    End Sub

    Sub LimpiarAplicados()

        For Each Rows As DataRow In DTFacturas.Rows
            Rows.Item("Cargos") = CDbl(0)
            Rows.Item("Aplicar") = CDbl(0)
        Next

    End Sub

    Sub ConceptoPago()
        Try

            Dim Abono, Saldo As New ArrayList
            Dim TextosAbono, TextosSaldos, Espacio As String

            '--------------------------------------------------------------

            For Each row As DataRow In DTFacturas.Rows
                If CDbl(row.Item("Cargos")) + CDbl(row.Item("Aplicar")) + CDbl(row.Item("Descuento")) > 0 Then
                    If CDbl(row.Item("Aplicar")) + CDbl(row.Item("Descuento")) < CDbl(row.Item("Balance")) Then
                        Abono.Add(CStr(row.Item("SecondID")))
                    ElseIf CDbl(row.Item("Aplicar")) + CDbl(row.Item("Descuento")) = CDbl(row.Item("Balance")) Then
                        Saldo.Add(CStr(row.Item("SecondID")))
                    End If
                End If
            Next

            '------------------------------------------------------------

            If Abono.Count > 0 Then
                Dim i As Integer = 0
                For Each itm As String In Abono
                    i += 1
                    TextosAbono = TextosAbono & itm

                    If i < Abono.Count Then
                        TextosAbono = TextosAbono & ";"
                    End If
                Next

                TextosAbono = "Abono a: " & TextosAbono
            Else
                TextosAbono = ""
            End If

            '------------------------------------------------------------

            If Saldo.Count > 0 Then
                Dim a As Integer = 0
                For Each itx As String In Saldo
                    a += 1
                    TextosSaldos = TextosSaldos & itx

                    If a < Saldo.Count Then
                        TextosSaldos = TextosSaldos & ";"
                    End If
                Next

                TextosSaldos = "Saldo a: " & TextosSaldos
            Else
                TextosSaldos = ""
            End If

            If TextosAbono <> "" And TextosSaldos <> "" Then
                Espacio = ","
            Else
                Espacio = ""
            End If

            txtConceptoPago.Text = TextosAbono & Espacio & TextosSaldos
            txtConceptoPago.Text = txtConceptoPago.Text.Substring(0, 255)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LimpiarDatos()
        txtCobrador.Clear()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtBalanceGral.Clear()
        txtBalanceGeneralCargos.Clear()
        txtUltimoPago.Clear()
        lblCalificacion.Text = ""
        txtConceptoPago.Clear()
        txtMontoAplicar.EditValue = 0
        txtIDPago.Clear()
        txtSecondID.Clear()
        DTPagares.Rows.Clear()
        DTFacturas.Rows.Clear()
        IDDescuentoAplicado.Clear()
        AccionesModulosAutorizadas.Clear()
        ILbcBalances.Items.Clear()
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=3", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE Abonos SET SecondID='" + lblSecondID.Text + "' WHERE IDAbono='" + txtIDPago.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=3"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardarDatos()
        Try

            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message & " Desde Guardar Datos")
        End Try
    End Sub

    Private Sub UltPago()
        Try

            If txtIDPago.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDAbono from Abonos where IDAbono= (Select Max(IDAbono) from Abonos)", Con)
                txtIDPago.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()
            Else
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "UltPago")
        End Try
    End Sub

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            DeshabilitarControles()
        Else
            HabilitarControles()
        End If
    End Sub

    Sub DeshabilitarControles()
        PicImagen.Enabled = False
        GbAplicado.Enabled = False
        GridControl1.Enabled = False
        txtConceptoPago.Enabled = False
        btnGuardarC.Enabled = False
        btnBuscarCliente.Enabled = False
        ILbcBalances.Enabled = False
    End Sub

    Sub HabilitarControles()
        PicImagen.Enabled = True
        GbAplicado.Enabled = True
        GridControl1.Enabled = True
        txtConceptoPago.Enabled = True
        btnGuardarC.Enabled = True
        btnBuscarCliente.Enabled = True
        ILbcBalances.Enabled = True
    End Sub

    Private Sub SumarDescuentos()
        Dim y As Integer = 0
        Dim Descuento As Double

Inicio:
        If y = DTFacturas.Rows.Count Then
            GoTo Fin

        End If

        Descuento = Descuento + CDbl(DTFacturas.Rows(y).Item("Descuento"))
        y = y + 1
        GoTo Inicio
Fin:
        lblDescuento.Text = Descuento
        lbltotalAbono.Text = CDbl(txtMontoAplicar.EditValue) + CDbl(lblDescuento.Text)

    End Sub

    Private Sub CalcularBalances()
        FunctCalcBcesFact(txtIDCliente.Text)
        FunctCalcBceGral(txtIDCliente.Text)
    End Sub

    Private Sub ImprimirDocumento()

        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDPago.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            'Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el Recibo de Ingreso?", "Imprimir Recibo de Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            'If Result = MsgBoxResult.Yes Then
            frm_impresiones_directas.ShowDialog(Me)
            'End If
        End If
    End Sub

    Private Sub HabilitarMontoAplicado()
        If txtIDCliente.Text = "" Or txtMontoAplicar.EditValue = CDbl(0) Then
            btnAplicarMonto.Enabled = False
        Else
            btnAplicarMonto.Enabled = True
        End If
    End Sub

    Private Sub txtIDCliente_TextChanged(sender As Object, e As EventArgs) Handles txtIDCliente.TextChanged
        HabilitarMontoAplicado()
    End Sub

    Private Sub txtMontoAplicar_EditValueChanged(sender As Object, e As EventArgs) Handles txtMontoAplicar.EditValueChanged
        HabilitarMontoAplicado()
        lblSumaLetra.Text = ConvertNumbertoString(txtMontoAplicar.EditValue, lblMoneda.Text)

        If txtMontoAplicar.EditValue = 0 Then
            txtMontoAplicar.SelectAll()
        End If
    End Sub

    Private Sub InsertDetalleAbono()
        Try
            Con.Open()

            For i As Integer = 0 To AdvBandedGridView1.DataRowCount - 1
                If CStr(AdvBandedGridView1.GetRowCellValue(i, "IDDetalleAbono")) = "" Then
                    If CDbl(CDbl(AdvBandedGridView1.GetRowCellValue(i, "Cargos")) + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Aplicar")) + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Descuento"))) = 0 Then
                    Else
                        cmd = New MySqlCommand("Insert into DetalleAbonos (IDAbono,IDFactura,BalanceAnterior,DiasVencidos,Debito,Descuento,Total,Cargos,CargosAnterior,CargosExcento) Values ('" + txtIDPago.Text + "','" + AdvBandedGridView1.GetRowCellValue(i, "IDFacturaDatos").ToString + "','" + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Balance")).ToString + "','" + AdvBandedGridView1.GetRowCellValue(i, "DiasVencidos").ToString + "','" + Math.Round(CDbl(AdvBandedGridView1.GetRowCellValue(i, "Aplicar")), 2).ToString + "','" + Math.Round(CDbl(AdvBandedGridView1.GetRowCellValue(i, "Descuento")), 2).ToString + "','" + Math.Round(CDbl(CDbl(AdvBandedGridView1.GetRowCellValue(i, "Cargos")) + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Aplicar")) + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Descuento"))), 2).ToString + "','" + Math.Round(CDbl(AdvBandedGridView1.GetRowCellValue(i, "Cargos")), 2).ToString + "','" + Math.Round(CDbl(AdvBandedGridView1.GetRowCellValue(i, "CargosFactura")), 2).ToString + "','" + Math.Round(CDbl(AdvBandedGridView1.GetRowCellValue(i, "CargosExcento")), 2).ToString + "')", Con)
                        cmd.ExecuteNonQuery()

                        cmd = New MySqlCommand("Select IDDetalleAbono from detalleabonos where IDDetalleAbono= (Select Max(IDDetalleAbono) from detalleabonos)", Con)
                        AdvBandedGridView1.SetRowCellValue(i, "IDDetalleAbono", Convert.ToString(cmd.ExecuteScalar()))
                    End If

                Else
                    If CDbl(CDbl(AdvBandedGridView1.GetRowCellValue(i, "Cargos")) + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Aplicar")) + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Descuento"))) = 0 Then     'Si el total del existente es 0 entonces lo elimino.
                        cmd = New MySqlCommand("Delete from DetalleAbonos Where IDDetalleAbono= '" + AdvBandedGridView1.GetRowCellValue(i, "IDDetalleAbono").ToString + "'", Con)
                        cmd.ExecuteNonQuery()
                    Else            'Si el total es diferente a 0 entonces actualizo sus datos.
                        cmd = New MySqlCommand("UPDATE DetalleAbonos SET BalanceAnterior='" + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Balance")).ToString + "',DiasVencidos='" + AdvBandedGridView1.GetRowCellValue(i, "DiasVencidos").ToString + "',Debito='" + Math.Round(CDbl(AdvBandedGridView1.GetRowCellValue(i, "Aplicar")), 2).ToString + "',Descuento='" + Math.Round(CDbl(AdvBandedGridView1.GetRowCellValue(i, "Descuento")), 2).ToString + "',Total='" + Math.Round(CDbl(CDbl(AdvBandedGridView1.GetRowCellValue(i, "Cargos")) + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Aplicar")) + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Descuento"))), 2).ToString + "',Cargos='" + Math.Round(CDbl(AdvBandedGridView1.GetRowCellValue(i, "Cargos")), 2).ToString + "',CargosAnterior='" + Math.Round(CDbl(AdvBandedGridView1.GetRowCellValue(i, "CargosFactura")), 2).ToString + "',CargosExcento='" + Math.Round(CDbl(AdvBandedGridView1.GetRowCellValue(i, "CargosExcento")), 2).ToString + "' WHERE IDDetalleAbono= '" + CDbl(AdvBandedGridView1.GetRowCellValue(i, "IDDetalleAbono")).ToString + "'", Con)
                        cmd.ExecuteNonQuery()
                    End If
                End If
            Next

            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " Desde Insertar Detalle Abono.")
        End Try
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarCliente.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub RecibosEmitidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecibosEmitidoToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnDesactivar.PerformClick()
    End Sub

    Private Sub frm_recibo_pagos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Control.ModifierKeys = Keys.Control Then
            If e.KeyCode = Keys.A Then
                e.Handled = True
                txtMontoAplicar.Focus()
            End If
        End If
    End Sub

    'Private Sub DgvFacturas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
    '    Try
    '        If e.ColumnIndex = Me.DgvFacturas.Columns(2).Index AndAlso (e.Value IsNot Nothing) Then
    '            If e.RowIndex >= 0 Then
    '                Ds.Clear()
    '                Con.Open()
    '                cmd = New MySqlCommand("Select Fecha,Hora,Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,FechaVencimiento,CondicionContado,SubTotal,Descuento,Itbis,Flete,TotalNeto from FacturaDatos where IDFacturaDatos= '" + DgvFacturas.Rows(e.RowIndex).Cells(1).Value.ToString + "'", Con)
    '                Adaptador = New MySqlDataAdapter(cmd)
    '                Adaptador.Fill(Ds, "FacturaDatos")
    '                Con.Close()

    '                Dim Tabla As DataTable = Ds.Tables("FacturaDatos")

    '                Me.DgvFacturas.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Fecha Factura: " & Convert.ToDateTime(Tabla.Rows(0).Item("Fecha")) & vbNewLine _
    '            & "Inicial: " & CDbl((Tabla.Rows(0).Item("Inicial"))).ToString("C") & vbNewLine _
    '            & "Cantidad Pagos: " & (Tabla.Rows(0).Item("CantidadPagos")) & vbNewLine _
    '            & "Montos Pagos: " & CDbl((Tabla.Rows(0).Item("MontoPagos"))).ToString("C") & vbNewLine _
    '             & "Adicional: " & CDbl((Tabla.Rows(0).Item("PagoAdicional"))).ToString("C") & vbNewLine _
    '                & "Fecha Adicional: " & (Tabla.Rows(0).Item("FechaAdicional")) & vbNewLine _
    '            & "Fecha Vencimiento: " & (Tabla.Rows(0).Item("FechaVencimiento")) & vbNewLine _
    '            & "Condición Contado: " & (Tabla.Rows(0).Item("CondicionContado")) & vbNewLine _
    '                 & "SubTotal: " & CDbl((Tabla.Rows(0).Item("SubTotal"))).ToString("C") & vbNewLine _
    '                 & "Descuento: " & CDbl((Tabla.Rows(0).Item("Descuento"))).ToString("C") & vbNewLine _
    '                 & "Itbis: " & CDbl((Tabla.Rows(0).Item("Itbis"))).ToString("C") & vbNewLine _
    '                 & "Flete: " & CDbl((Tabla.Rows(0).Item("Flete"))).ToString("C") & vbNewLine _
    '            & "Total Neto: " & CDbl((Tabla.Rows(0).Item("TotalNeto"))).ToString("C") & vbNewLine

    '            End If


    '        ElseIf e.ColumnIndex = Me.DgvFacturas.Columns(6).Index AndAlso (e.Value IsNot Nothing) Then
    '            If UseLongFormat.Text = "0" Then
    '                Me.DgvFacturas.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = CalcularFecha(Date.ParseExact(DgvFacturas.Rows(e.RowIndex).Cells(4).Value, "dd/MM/yyyy", Globalization.CultureInfo.InvariantCulture), Today)
    '            End If
    '        End If

    '    Catch ex As Exception
    '        InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
    '    End Try
    'End Sub



    Private Sub EstadoDeCuentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadoDeCuentaToolStripMenuItem.Click
        SimpleButton1.PerformClick()
    End Sub

    Private Sub HeaderIncluir_CheckedChanged(sender As Object, e As EventArgs)
        Try
            Dim Status As String = Convert.ToString(Convert.ToInt16(HeaderIncluir.Checked))

            For Each Rows As DataRow In DTFacturas.Rows
                Rows.Item("Incluir") = Status

                If HeaderIncluir.Checked Then
                    Rows.Item("Cargos") = CDbl(Rows.Item("CargosFactura"))
                    Rows.Item("Aplicar") = CDbl(CDbl(Rows.Item("Balance")) - CDbl(Rows.Item("Descuento")))
                    Rows.Item("Final") = CDbl(0)
                Else
                    Rows.Item("Cargos") = CDbl(0)
                    Rows.Item("Aplicar") = CDbl(0)
                    Rows.Item("Final") = CDbl(CDbl(Rows.Item("Balance")) - CDbl(Rows.Item("Descuento")))
                End If
            Next

            CompararEntradas()
            ConceptoPago()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CompararEntradas()
        AdvBandedGridView1.PostEditor()
        Dim AplicadoValue As Double = 0

        For i = 0 To AdvBandedGridView1.RowCount - 1
            AplicadoValue = AplicadoValue + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Cargos")) + CDbl(AdvBandedGridView1.GetRowCellValue(i, "Aplicar"))
        Next

        If txtMontoAplicar.EditValue = 0 Then
            txtMontoAplicar.EditValue = AplicadoValue
        ElseIf AplicadoValue <> CDbl(txtMontoAplicar.EditValue) Then
            txtMontoAplicar.EditValue = AplicadoValue
        End If
    End Sub

    Sub RefrescarBalances()
        Try
            If txtIDCliente.Text <> "" Then
                Dim ds As New DataSet

                ConMixta.Open()

                cbxMoneda.Properties.Items.Clear()
                ILbcBalances.Items.Clear()

                cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto,Signo,Balance,MonedaImagen,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos LEFT JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda and FacturaDatos.IDCliente=Clientes_Balances.IDCliente) as CargosCliente FROM Libregco.tipomoneda INNER JOIN Libregco.Clientes_Balances on TipoMoneda.IDTipoMoneda=Clientes_Balances.IDMoneda Where Clientes_Balances.IDCliente='" + txtIDCliente.Text + "' Order by Balance DESC", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds, "tipomoneda")

                For Each Fila As DataRow In ds.Tables("tipomoneda").Rows
                    Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem
                    If CDbl(Fila.Item("CargosCliente")) = 0 Then
                        nvmoneda.Description = Fila.Item("Texto") & " " & CDbl(Fila.Item("Balance")).ToString("C") & "."
                    Else
                        nvmoneda.Description = Fila.Item("Texto") & " " & CDbl(Fila.Item("Balance")).ToString("C") & " (+) más cargos acumulados por " & CDbl(Fila.Item("CargosCliente")).ToString("C") & "."
                    End If

                    nvmoneda.Value = Fila.Item("IDTipoMoneda")

                    If Fila.Item("IDTipoMoneda") = 1 Then
                        nvmoneda.ImageIndex = 0
                    ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                        nvmoneda.ImageIndex = 1
                    ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                        nvmoneda.ImageIndex = 2
                    End If

                    cbxMoneda.Properties.Items.Add(nvmoneda)

                    Dim itm As New DevExpress.XtraEditors.Controls.ImageListBoxItem
                    Dim wFile As System.IO.FileStream

                    itm.Value = Fila.Item("IDTipoMoneda")

                    If CDbl(Fila.Item("CargosCliente")) = 0 Then
                        itm.Description = Fila.Item("Signo") & " " & CDbl(Fila.Item("Balance")).ToString("C")
                    Else
                        itm.Description = Fila.Item("Signo") & " " & CDbl(CDbl(Fila.Item("Balance")) + CDbl(Fila.Item("CargosCliente"))).ToString("C")
                    End If

                    If Fila.Item("MonedaImagen") <> "" Then
                        If System.IO.File.Exists(Fila.Item("MonedaImagen")) Then
                            wFile = New FileStream(Fila.Item("MonedaImagen"), FileMode.Open, FileAccess.Read)
                            itm.ImageOptions.Image = ResizeImage(System.Drawing.Image.FromStream(wFile), 18)
                        Else
                            itm.ImageOptions.Image = ResizeImage(My.Resources.no_photo, 18)
                        End If
                    Else
                        itm.ImageOptions.Image = ResizeImage(My.Resources.no_photo, 18)
                    End If

                    ILbcBalances.Items.Add(itm)
                Next

                ds.Dispose()
                ConMixta.Close()
            End If

            cbxMoneda.EditValue = CInt(DefaultCurrency.Text)


            Dim dstemp As New DataSet

            Con.Open()
            cmd = New MySqlCommand("SELECT Balance,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos LEFT JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda and FacturaDatos.IDCliente=Clientes_Balances.IDCliente) as CargosCliente,TipoMoneda.Moneda FROM Libregco.tipomoneda INNER JOIN Libregco.Clientes_Balances on TipoMoneda.IDTipoMoneda=Clientes_Balances.IDMoneda Where Clientes_Balances.IDCliente='" + txtIDCliente.Text + "' and Clientes_Balances.IDMoneda='" + cbxMoneda.EditValue.ToString + "' Order by Balance ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "tipomoneda")
            Con.Close()

            If dstemp.Tables("tipomoneda").Rows.Count > 0 Then
                txtBalanceGral.Text = CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("Balance")).ToString("C")
                txtBalanceGeneralCargos.Text = CDbl(CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("CargosCliente")) + CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("Balance"))).ToString("C")
                lblMoneda.Text = dstemp.Tables("tipomoneda").Rows(0).Item("Moneda")
            End If

            dstemp.Dispose()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        Dim SumAplicar As Double = 0
        For Each Rows As DataRow In DTFacturas.Rows
            SumAplicar = SumAplicar + CDbl(Rows.Item("Aplicar")) + CDbl(Rows.Item("Cargos"))
        Next

        VerificarFechaSistema()

        If txtIDCliente.Text = "" Then
            MessageBox.Show("No se ha seleccionado el cliente para iniciar el proceso de pago.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtMontoAplicar.EditValue = CDbl(0) Then
            MessageBox.Show("El monto a aplicar en el abono debe ser nayor a cero.", "Monto a Aplicar es 0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMontoAplicar.Focus()
            Exit Sub
        ElseIf txtMontoAplicar.Text = "" Then
            MessageBox.Show("Escriba el monto a aplicar en el recibo.", "No se especificó monto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMontoAplicar.Focus()
            Exit Sub
        ElseIf SumAplicar = 0 Then
            MessageBox.Show("No se ha específicado el detalle del abono en las facturas.", "Escriba los montos a aplicar en las facturas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtConceptoPago.Text = "" Then
            Dim Concept As MsgBoxResult = MessageBox.Show("El concepto del pago está vacío. Desearía generarlo automáticamente?", "Concepto en blanco", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Concept = MsgBoxResult.Yes Then
                ConceptoPago()
            End If
        End If

        If txtIDPago.Text = "" Then 'Si no hay pago
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo recibo de pago a nombre del cliente " & txtNombre.Text & " [ " & txtIDCliente.Text & " ] en la base de datos?", "Guardar Nuevo Recibo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            'If Result = MsgBoxResult.Yes Then

            If IsIntegratedBalance(txtIDCliente.Text, CDbl(txtBalanceGral.Text), cbxMoneda.EditValue.ToString) = False Then
                    Exit Sub
                End If

                'Buscar limite de descuentos
                If DTConfiguracion.Rows(8 - 1).Item("Value2Int") = 1 Then
                    Dim DescuentosAplicados As Double = 0

                    For Each row As DataRow In DTFacturas.Rows
                        If IDDescuentoAplicado.Contains(CStr(row.Item("IDFacturaDatos"))) Then
                        Else
                            DescuentosAplicados = DescuentosAplicados + CDbl(row.Item("Descuento"))
                        End If
                    Next

                    If DescuentosAplicados > CDbl(DTConfiguracion.Rows(56 - 1).Item("Value3Double")) Then
                        If Not AccionesModulosAutorizadas.Contains("95") Then
                            ControlSuperClave = 1
                            MessageBox.Show("Ha superado el límite máximo del monto de descuentos autorizado." & vbNewLine & vbNewLine & "Por favor verifique la información suministrada en el recibo y proceda a introducir la superclave para continuar.", "Se ha excedido el monto de descuento máximo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                            frm_superclave.IDAccion.Text = 95
                            frm_superclave.ShowDialog(Me)
                        Else
                            ControlSuperClave = 0
                        End If


                        If ControlSuperClave = 1 Then
                            Exit Sub
                        End If
                    End If
                End If

                'Buscar similitudes
                FindSimilarities(3, txtIDCliente.Text, txtMontoAplicar.EditValue, CDate(txtFechaPago.Text))
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                VerificarSaldosconCargos()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                VerificarSaldos()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                CompararEntradas()
                SumarDescuentos()

                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                sqlQ = "INSERT INTO Abonos (IDSucursal,IDAlmacen,IDEquipo,IDTipoDocumento,IDTransaccion,IDEmpleado,IDCliente,Fecha,Hora,BalanceAnterior,Concepto,Debito,Descuento,Total,SumaLetra,Nulo,Impreso) VALUES ('" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',3,'" + lblTransaccion.Text + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "','" + txtIDCliente.Text + "',CURDATE(),CURTIME(),'" + CDbl(txtBalanceGeneralCargos.Text).ToString + "','" + txtConceptoPago.Text + "','" + CDbl(txtMontoAplicar.EditValue).ToString + "','" + CDbl(lblDescuento.Text).ToString + "','" + CDbl(lbltotalAbono.Text).ToString + "','" + lblSumaLetra.Text + "','" + Convert.ToInt16(ChkNulo.Checked).ToString + "',0)"
                GuardarDatos()
                UltPago()
                InsertDetalleAbono()
                SetSecondID()
                CalcularBalances()
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))
                ImprimirDocumento()

                'Verificando eventos especiales
                If CheckEventosBoleteriaActuales(2) = True Then
                    lblStatusBar.ForeColor = Color.Purple
                    lblStatusBar.Text = "Se han encontrado eventos especiales aplicables en cuentas por cobrar."

                    GenerateBoletosEventos(2, lblTransaccion.Text, CDbl(txtMontoAplicar.EditValue), txtNombre.Text, lblDireccion.Text, lblDireccion.Text.ToUpper, lblTelefono.Text)
                End If

                DeshabilitarControles()
                Hora.Enabled = False
                'End If
            Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            'If Result = MsgBoxResult.Yes Then
            frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                SumarDescuentos()
                sqlQ = "UPDATE Abonos SET Fecha='" + txtFechaPago.Value.ToString("yyyy-MM-dd") + "',Hora='" + txtHora.Value.ToString("HH:mm:ss") + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDTransaccion='" + lblTransaccion.Text + "',IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',Concepto='" + txtConceptoPago.Text + "',Debito='" + CDbl(txtMontoAplicar.EditValue).ToString + "',Descuento='" + lblDescuento.Text + "',Total='" + lbltotalAbono.Text + "',SumaLetra='" + lblSumaLetra.Text + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDAbono= (" + txtIDPago.Text + ")"
                GuardarDatos()
                InsertDetalleAbono()
                CalcularBalances()
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))
                ImprimirDocumento()
                DeshabilitarControles()
                Hora.Enabled = False
                'End If
            End If
    End Sub

    Private Sub AdvBandedGridView1_CellValueChanged(sender As Object, e As XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AdvBandedGridView1.CellValueChanged
        Try
            If e.RowHandle >= 0 Then

                If e.Column.FieldName = "Aplicar" Then
                    If CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Balance")) > CDbl(e.Value) Then
                        AdvBandedGridView1.SetFocusedRowCellValue("Incluir", "0")
                    End If

                    If CDbl(e.Value) > CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Balance")) Then
                        AdvBandedGridView1.SetFocusedRowCellValue("Aplicar", AdvBandedGridView1.GetFocusedRowCellValue("Balance"))
                    End If


                    If CDbl(CDbl(e.Value) + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Descuento"))) = CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Balance")) Then
                        If CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cargos")) < CDbl(AdvBandedGridView1.GetFocusedRowCellValue("CargosFactura")) Then
                            AdvBandedGridView1.SetFocusedRowCellValue("CargosExcento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("CargosFactura")) - CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cargos")))
                        Else
                            AdvBandedGridView1.SetFocusedRowCellValue("CargosExcento", 0)
                        End If
                    Else
                        AdvBandedGridView1.SetFocusedRowCellValue("CargosExcento", 0)
                    End If

                ElseIf e.Column.FieldName = "Cargos" Then
                    If CDbl(CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Aplicar")) + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Descuento"))) = CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Balance")) Then
                        If CDbl(e.Value) < CDbl(AdvBandedGridView1.GetFocusedRowCellValue("CargosFactura")) Then
                            AdvBandedGridView1.SetFocusedRowCellValue("CargosExcento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("CargosFactura")) - CDbl(e.Value))
                        Else
                            AdvBandedGridView1.SetFocusedRowCellValue("CargosExcento", 0)
                        End If
                    Else
                        AdvBandedGridView1.SetFocusedRowCellValue("CargosExcento", 0)
                    End If
                End If




                If CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cargos")) > CDbl(AdvBandedGridView1.GetFocusedRowCellValue("CargosFactura")) Then
                    AdvBandedGridView1.SetFocusedRowCellValue("Cargos", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("CargosFactura")))
                End If


                'If CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Final")) = CDbl(0) Then
                '    AdvBandedGridView1.SetFocusedRowCellValue("CargosExcento", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("CargosFactura")) - CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Cargos")))
                'Else
                '    AdvBandedGridView1.SetFocusedRowCellValue("CargosExcento", 0)
                'End If

                CompararEntradas()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Function GetColumnBounds(ByVal column As XtraGrid.Columns.GridColumn) As Rectangle
        Dim gridInfo As ViewInfo.GridViewInfo = CType(column.View.GetViewInfo(), ViewInfo.GridViewInfo)
        Dim colInfo As XtraGrid.Drawing.GridColumnInfoArgs = gridInfo.ColumnsInfo(column)
        If Not colInfo Is Nothing Then
            Return colInfo.Bounds
        Else
            Return Rectangle.Empty
        End If
    End Function


    Private Sub btnAplicarMonto_Click(sender As Object, e As EventArgs) Handles btnAplicarMonto.Click
        Try
            Dim x As Integer = 0
            Dim AplicadoValue As Double = txtMontoAplicar.EditValue

            VerificarTransf()
            If ControlSuperClave = 1 Then
                Exit Sub
            End If
Inicio:
            If x = DTFacturas.Rows.Count Then
                GoTo Fin
            End If

            If AplicadoValue > CDbl(DTFacturas.Rows(x).Item("CargosFactura")) Then
                DTFacturas.Rows(x).Item("Cargos") = CDbl(DTFacturas.Rows(x).Item("CargosFactura"))
            ElseIf AplicadoValue < CDbl(DTFacturas.Rows(x).Item("CargosFactura")) Then
                DTFacturas.Rows(x).Item("Cargos") = AplicadoValue
            ElseIf AplicadoValue = CDbl(DTFacturas.Rows(x).Item("CargosFactura")) Then
                DTFacturas.Rows(x).Item("Cargos") = AplicadoValue
            End If

            AplicadoValue = AplicadoValue - CDbl(DTFacturas.Rows(x).Item("Cargos"))

            If AplicadoValue > CDbl(DTFacturas.Rows(x).Item("Balance")) Then
                DTFacturas.Rows(x).Item("Aplicar") = CDbl(CDbl(DTFacturas.Rows(x).Item("Balance")) - CDbl(DTFacturas.Rows(x).Item("Descuento")))
            ElseIf AplicadoValue < CDbl(DTFacturas.Rows(x).Item("Balance")) Then
                DTFacturas.Rows(x).Item("Aplicar") = AplicadoValue
            ElseIf AplicadoValue = CDbl(DTFacturas.Rows(x).Item("Balance")) Then
                DTFacturas.Rows(x).Item("Aplicar") = CDbl(CDbl(DTFacturas.Rows(x).Item("Balance")) - CDbl(DTFacturas.Rows(x).Item("Descuento")))
            End If


            AplicadoValue = AplicadoValue - CDbl(DTFacturas.Rows(x).Item("Aplicar"))
            x = x + 1
            GoTo Inicio
Fin:

            For Each Rows As DataRow In DTFacturas.Rows
                Rows.Item("Final") = CDbl(CDbl(Rows.Item("Balance")) - CDbl(Rows.Item("Aplicar")) - CDbl(Rows.Item("Descuento")))
            Next

            ConceptoPago()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub frm_recibo_pagos_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ResetHeaderCheckBoxLocation(AdvBandedGridView1.Columns("Incluir").ColIndex, -1)
    End Sub
    Private Sub AdvBandedGridView1_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles AdvBandedGridView1.ShowingEditor
        If AdvBandedGridView1.FocusedColumn.FieldName = "Info" Then
            e.Cancel = True

            'ElseIf AdvBandedGridView1.FocusedColumn.FieldName = "Arts" Then
            'e.Cancel = True
        End If
    End Sub

    Private Sub AdvBandedGridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles AdvBandedGridView1.RowCellClick
        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Info" Then

                Dim PermisosImpresionFactura As New ArrayList
                PermisosImpresionFactura = PasarPermisos(46)

                If PermisosImpresionFactura(3) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If AdvBandedGridView1.GetFocusedRowCellValue("IDTipoDocumento") = 2 Then
                    Dim DsSP As New DataSet
                    Dim cmdSP As New MySqlCommand
                    Dim AdaptadorSP As MySqlDataAdapter

                    If ConMixta.State = ConnectionState.Open Then
                        ConMixta.Close()
                    End If

                    ConMixta.Open()

                    cmd = New MySqlCommand("SELECT Path FROM" & SysName.Text & "reportes where Menustring='Facturación' and Activo=1 ORDER BY NoOrden ASC LIMIT 1", ConMixta)
                    Dim PathReport As String = Convert.ToString(cmd.ExecuteScalar())

                    If TypeConnection.Text = 1 Then
                        frm_reportView.ObjRpt.Load("\\" & PathServidor.Text & PathReport)
                    Else
                        frm_reportView.ObjRpt.Load("C:" & PathReport.Replace("\Libregco\Libregco.net", ""))
                    End If

                    cmd = New MySqlCommand("SELECT ModoDuplicado FROM" & SysName.Text & "reportes where Menustring='Facturación' and Activo=1 ORDER BY NoOrden ASC LIMIT 1", ConMixta)
                    Dim Duplicado As Integer = Convert.ToInt16(cmd.ExecuteScalar())


                    'Consulta de los datos de la factura   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    AdaptadorSP = New MySqlDataAdapter("call" & SysName.Text & "facturadatosview(" + AdvBandedGridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString + ");", ConMixta)
                    AdaptadorSP.Fill(DsSP, "FacturaDatosView")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    'Llenado EmpresaView
                    AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", ConMixta)
                    AdaptadorSP.Fill(DsSP, "EmpresaView")

                    'Para facturas a credito
                    'Lleando pagaresView
                    AdaptadorSP = New MySqlDataAdapter("SELECT IDPagare,Pagares.IDFactura,NoPagare,Pagares.Cantidad,Pagares.FechaVencimiento as VencimientoPagares,Pagares.DiasVencidos as DiasVencidosPagares,Concepto,Pagares.Monto,Pagares.Balance as BalancePagares,Pagares.Nulo,GROUP_CONCAT(FacturaArticulos.Descripcion,'') AS DescripcionArticulos FROM" & SysName.Text & "Pagares INNER JOIN" & SysName.Text & "FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "FacturaArticulos on FacturaDatos.IDFacturaDatos=FacturaArticulos.IDFactura Where Pagares.IDFactura='" + AdvBandedGridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString + "' GROUP BY Pagares.IDPagare", ConMixta)
                    AdaptadorSP.Fill(DsSP, "ListadoPagaresView")

                    'Lleando balances_clientes_view
                    AdaptadorSP = New MySqlDataAdapter("call libregco.balances_clientes(" + txtIDCliente.Text + ");", ConMixta)
                    AdaptadorSP.Fill(DsSP, "balances_clientes")

                    'Lleando garantaias
                    AdaptadorSP = New MySqlDataAdapter("SELECT FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.idarticulo=articulos_garantia.idarticulo Where FacturaArticulos.IDFactura='" + AdvBandedGridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString + "' Group By FacturaArticulos.IDPrecio UNION ALL SELECT FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.IDSubcategoria=articulos_garantia.IDSubCategoria Where FacturaArticulos.IDFactura='" + AdvBandedGridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString + "' Group By FacturaArticulos.IDPrecio UNION ALL SELECT FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.IDCategoria=articulos_garantia.IDCategoria Where FacturaArticulos.IDFactura='" + AdvBandedGridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString + "' Group By FacturaArticulos.IDPrecio", ConMixta)
                    AdaptadorSP.Fill(DsSP, "GarantiaArticulosView")

                    'Lleando garantaias
                    AdaptadorSP = New MySqlDataAdapter("SELECT FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.idarticulo=articulos_garantia.idarticulo Where FacturaArticulos.IDFactura='" + AdvBandedGridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString + "' Group By FacturaArticulos.IDPrecio UNION ALL SELECT FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.IDSubcategoria=articulos_garantia.IDSubCategoria Where FacturaArticulos.IDFactura='" + AdvBandedGridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString + "' Group By FacturaArticulos.IDPrecio UNION ALL SELECT FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.IDCategoria=articulos_garantia.IDCategoria Where FacturaArticulos.IDFactura='" + AdvBandedGridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString + "' Group By FacturaArticulos.IDPrecio", ConMixta)
                    AdaptadorSP.Fill(DsSP, "GarantiaArticulosView")

                    For Each crReportObject In frm_reportView.ObjRpt.Subreports
                        If CType(crReportObject, ReportDocument).Name = "subreport_preguntas" Then
                            'Lleando garantaias
                            AdaptadorSP = New MySqlDataAdapter("SELECT idFactura_Preguntas,factura_preguntas.IDArticulo_Pregunta,factura_preguntas.IDFactura,factura_preguntas.IDArticulo,Titulo,Descripcion,Respuesta FROM" & SysName.Text & "factura_preguntas inner join Libregco.articulos_preguntas on factura_preguntas.IDArticulo_Pregunta=articulos_preguntas.idArticulos_preguntas Where IDFactura='" + AdvBandedGridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString + "'", ConMixta)
                            AdaptadorSP.Fill(DsSP, "FacturaPreguntas_DATA")

                            frm_reportView.ObjRpt.Subreports("subreport_preguntas").SetDataSource(DsSP.Tables("FacturaPreguntas_DATA"))
                        End If
                    Next

                    cmdSP.Dispose()
                    AdaptadorSP.Dispose()

                    ConMixta.Close()

                    frm_reportView.ObjRpt.Database.Tables("facturadatosview1").SetDataSource(DsSP.Tables("FacturaDatosView"))
                    frm_reportView.ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))
                    frm_reportView.ObjRpt.Subreports("subinforme_pagares_en_factura.rpt").SetDataSource(DsSP.Tables("ListadoPagaresView"))
                    frm_reportView.ObjRpt.Subreports("balances_clientes_formato.rpt").SetDataSource(DsSP.Tables("balances_clientes"))
                    frm_reportView.ObjRpt.Subreports("subreport_garantias.rpt").SetDataSource(DsSP.Tables("GarantiaArticulosView"))

                    If Duplicado = 1 Then
                        frm_reportView.ObjRpt.SetParameterValue("Duplicidad", DTConfiguracion.Rows(92 - 1).Item("Value1Var").ToString)
                    End If

                    Dim TmpForm = New frm_reportView
                    TmpForm.Text = "Visualizacion de reportes"
                    TmpForm.Show(Me)

                    TmpForm.CrystalViewer.ReportSource = Nothing
                    TmpForm.CrystalViewer.ReportSource = frm_reportView.ObjRpt
                    TmpForm.CrystalViewer.Refresh()
                    TmpForm.CrystalViewer.Cursor = Cursors.Default

                    lblStatusBar.Text = "Listo"

                End If

                'ElseIf e.Column.FieldName = "Arts" Then
                '    'MessageBox.Show(sender.ToString)
                '    frm_articulos_facturados.ShowDialog(Me)
            End If

        End If
    End Sub

    Private Sub cbxMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMoneda.SelectedIndexChanged
        RefrescarTablaFacturas()
        'RefrescarTablaPagares()

        Dim dstemp As New DataSet

        ConTemporal.Open()
        cmd = New MySqlCommand("SELECT Balance,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos LEFT JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda and FacturaDatos.IDCliente=Clientes_Balances.IDCliente) as CargosCliente,Moneda FROM Libregco.tipomoneda INNER JOIN Libregco.Clientes_Balances on TipoMoneda.IDTipoMoneda=Clientes_Balances.IDMoneda Where Clientes_Balances.IDCliente='" + txtIDCliente.Text + "' and Clientes_Balances.IDMoneda='" + cbxMoneda.EditValue.ToString + "' Order by Balance ASC", ConTemporal)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "tipomoneda")
        ConTemporal.Close()

        If dstemp.Tables("tipomoneda").Rows.Count > 0 Then
            txtBalanceGral.Text = CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("Balance")).ToString("C")
            txtBalanceGeneralCargos.Text = CDbl(CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("CargosCliente")) + CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("Balance"))).ToString("C")
            lblMoneda.Text = dstemp.Tables("tipomoneda").Rows(0).Item("Moneda")
        End If

        ILbcBalances.SelectedValue = CInt(cbxMoneda.EditValue)
        dstemp.Dispose()
    End Sub

    Private Sub PicImagen_Click(sender As Object, e As EventArgs) Handles PicImagen.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub


    Private Sub AdvBandedGridView1_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles AdvBandedGridView1.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1) & "   "
            ResetHeaderCheckBoxLocation(AdvBandedGridView1.Columns("Incluir").ColIndex, -1)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub


    Private Sub ILbcBalances_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ILbcBalances.SelectedIndexChanged
        'cbxMoneda.EditValue = ILbcBalances.SelectedValue
    End Sub

    Private Sub txtIDPago_TextChanged(sender As Object, e As EventArgs) Handles txtIDPago.TextChanged
        If txtIDPago.Text = "" Then
            cbxMoneda.Enabled = True
        Else
            cbxMoneda.Enabled = False
        End If
    End Sub

    Private Sub VerificarFechaSistema()
        Dim CurrentDate As New Date
        Con.Open()
        cmd = New MySqlCommand("SELECT CURDATE()", Con)
        CurrentDate = Convert.ToDateTime(cmd.ExecuteScalar())
        Con.Close()

        If Today <> CurrentDate Then
            MessageBox.Show("Existe un conflicto entre la fecha actual del equipo y la fecha del servidor." & vbNewLine & vbNewLine & "Por favor verifique la fecha del equipo o la del servidor para acceder al sistema.", "Diferencias en fechas", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Application.Exit()
        End If

    End Sub

    Private Sub AdvBandedGridView1_ColumnWidthChanged(sender As Object, e As XtraGrid.Views.Base.ColumnEventArgs) Handles AdvBandedGridView1.ColumnWidthChanged
        ResetHeaderCheckBoxLocation(AdvBandedGridView1.Columns("Incluir").ColIndex, -1)
    End Sub

    Private Sub VerificarSaldosconCargos()
        For Each row As DataRow In DTFacturas.Rows
            If CDbl(row.Item("Aplicar")) = CDbl(row.Item("Balance")) Then
                If CDbl(row.Item("Cargos")) < CDbl(row.Item("CargosFactura")) Then
                    MessageBox.Show("Se ha detectado que desea eliminar y/o ajustar los cargos acumulados por el vencimiento de la factura " & row.Item("SecondID") & " vencida en fecha " & row.Item("FechaVencimiento") & "." & vbNewLine & vbNewLine & "Por favor ingrese la superclave para continuar con el procedimiento.", "Control de modificación de cargos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    frm_superclave.IDAccion.Text = 109
                    frm_superclave.ShowDialog(Me)
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If
            End If
        Next

        ControlSuperClave = 0
    End Sub


    Private Sub VerificarSaldos()
        If LiberarControles.Text = 0 Then
            Dim IDFactura, Fecha As String

            For Each row As DataRow In DTFacturas.Rows
                If CDbl(row.Item("Final")) = 0 Then
                    IDFactura = row.Item("IDFacturaDatos")
                    Fecha = CDate(row.Item("Fecha"))

                    For Each Rw As DataRow In DTFacturas.Rows
                        If Rw.Item("IDFacturaDatos") <> IDFactura Then
                            If CDbl(Rw.Item("Final")) > 0 And CDate(Rw.Item("Fecha")) < Fecha Then
                                Dim Result1 As MsgBoxResult = MessageBox.Show("Se ha encontrado una o más facturas de mayor antigüedad que no son afectada en el actual recibo de ingreso." & vbNewLine & vbNewLine & "Recomendación" & vbNewLine & vbNewLine & "Factura: " & Rw.Item("SecondID") & " de fecha " & Rw.Item("Fecha") & vbNewLine & vbNewLine & "Recomendamos aplicar el pago a la factura en orden de antiguedad." & vbNewLine & vbNewLine & "¿Está seguro que desea proceder el recibo de ingreso?", "Hay factura antigua", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                If Result1 = MsgBoxResult.Yes Then
                                    frm_superclave.IDAccion.Text = 96
                                    frm_superclave.ShowDialog(Me)
                                    If ControlSuperClave = 1 Then
                                        Exit Sub
                                    End If
                                Else
                                    ControlSuperClave = 1
                                    Exit Sub
                                End If
                            End If
                        End If
                    Next
                End If
            Next

            ControlSuperClave = 0
        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione un cliente para poder acceder a su historial.", "No hay cliente activo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            frm_buscar_clientes.ShowDialog(Me)

            If txtIDCliente.Text <> "" Then
                frm_historialpagos.ShowDialog(Me)
            End If
        Else
            frm_historialpagos.ShowDialog(Me)
        End If

    End Sub

    Private Sub RepositoryItemButtonEdit2_ButtonPressed(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit2.ButtonPressed
        If e.Button.Caption = "Articulos" Then
            frm_articulos_facturados.ShowDialog(Me)
        ElseIf e.Button.Caption = "Conduces" Then

        End If
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione un cliente para poder acceder a su historial de pagos.", "No hay cliente activo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            frm_buscar_clientes.ShowDialog(Me)

            If txtIDCliente.Text <> "" Then
                frm_buscar_recibos_cliente.Text = txtNombre.Text
                frm_buscar_recibos_cliente.lblIDUsuario.Text = DTEmpleado.Rows(0).Item("IDEmpleado").ToString()
                frm_buscar_recibos_cliente.ShowDialog(Me)
            End If
        Else
            frm_buscar_recibos_cliente.ShowDialog(Me)
        End If

    End Sub

    Private Sub frm_recibo_pagos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If txtIDPago.Text = "" Then
            If AdvBandedGridView1.RowCount > 0 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea cerrar el formulario de recibos de ingreso?", "Cerrar formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If Result = MsgBoxResult.Yes Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If



        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El recibo de ingreso No. " & txtIDPago.Text & " del cliente " & txtNombre.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Recibo de Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then

                ControlSuperClave = 1
                frm_superclave.IDAccion.Text = 128
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ChkNulo.Checked = False
                SumarDescuentos()
                sqlQ = "UPDATE Abonos SET Concepto='" + txtConceptoPago.Text + "',Debito='" + CDbl(txtMontoAplicar.EditValue).ToString + "',Descuento='" + lblDescuento.Text + "',Total='" + lbltotalAbono.Text + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDAbono= (" + txtIDPago.Text + ")"
                GuardarDatos()
                CalcularBalances()
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))
            End If

        ElseIf txtIDPago.Text = "" Then
            MessageBox.Show("No hay un registro de recibo de ingreso abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el recibo de ingreso No. " & txtIDPago.Text & " del cliente " & txtNombre.Text & " del sistema?", "Anular Recibo de Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                ControlSuperClave = 1
                frm_superclave.IDAccion.Text = 127
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ChkNulo.Checked = True
                sqlQ = "UPDATE Abonos SET Concepto='" + txtConceptoPago.Text + "',Debito='" + CDbl(txtMontoAplicar.EditValue).ToString + "',Descuento='" + lblDescuento.Text + "',Total='" + lbltotalAbono.Text + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDAbono= (" + txtIDPago.Text + ")"
                GuardarDatos()
                CalcularBalances()
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))
            End If

        End If
    End Sub

    Private Sub AdvBandedGridView1_CellValueChanging(sender As Object, e As XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AdvBandedGridView1.CellValueChanging
        Try

            If e.RowHandle >= 0 Then
                AdvBandedGridView1.PostEditor()

                If e.Column.FieldName = "Cargos" Then

                    If CDbl(e.Value) > CDbl(AdvBandedGridView1.GetFocusedRowCellValue("CargosFactura")) Then
                        AdvBandedGridView1.SetFocusedRowCellValue("Cargos", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("CargosFactura")))
                    End If


                ElseIf e.Column.FieldName = "Aplicar" Then

                    If CDbl(e.Value) + CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Descuento")) > CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Balance")) Then
                        MessageBox.Show("El monto aplicado excede el balance de la factura. Verifique el ajuste en el descuento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AdvBandedGridView1.SetFocusedRowCellValue("Aplicar", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Balance")))
                    End If

                    AdvBandedGridView1.SetFocusedRowCellValue("Final", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Balance")) - CDbl(e.Value) - CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Descuento")))



                ElseIf e.Column.FieldName = "Descuento" Then

                    If CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Aplicar")) + CDbl(e.Value) > CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Balance")) Then
                        MessageBox.Show("El descuento aplicado excede el balance de la factura. Verifique el ajuste en el monto aplicado y el descuento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        AdvBandedGridView1.SetFocusedRowCellValue("Descuento", CDbl(0))
                    End If

                    AdvBandedGridView1.SetFocusedRowCellValue("Final", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Balance")) - CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Aplicar")) - CDbl(e.Value))

                ElseIf e.Column.FieldName = "Incluir" Then
                    AdvBandedGridView1.PostEditor()
                    Dim IsTicked As Boolean = (AdvBandedGridView1.GetFocusedRowCellValue("Incluir"))
                    If IsTicked Then
                        AdvBandedGridView1.SetFocusedRowCellValue("Cargos", 0)
                        AdvBandedGridView1.SetFocusedRowCellValue("CargosExcento", 0)
                        AdvBandedGridView1.SetFocusedRowCellValue("Aplicar", 0)
                        AdvBandedGridView1.SetFocusedRowCellValue("Final", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Balance")) - CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Aplicar")) - CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Descuento")))
                    Else

                        AdvBandedGridView1.SetFocusedRowCellValue("Cargos", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("CargosFactura")))
                        AdvBandedGridView1.SetFocusedRowCellValue("Aplicar", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Balance")) - CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Descuento")))
                        AdvBandedGridView1.SetFocusedRowCellValue("Final", CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Balance")) - CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Aplicar")) - CDbl(AdvBandedGridView1.GetFocusedRowCellValue("Descuento")))

                    End If
                End If



                ConceptoPago()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Sub ResetHeaderCheckBoxLocation(ByVal ColumnIndex As Integer, ByVal RowIndex As Integer)
        Dim Rect As Rectangle = GetColumnBounds(AdvBandedGridView1.Columns("Incluir"))
        Dim Pt As New Point()
        Pt.X = Rect.Location.X + (Rect.Width - HeaderIncluir.Width) \ 2 + 1
        Pt.Y = Rect.Location.Y + (Rect.Height - HeaderIncluir.Height) \ 2 + 1
        HeaderIncluir.Location = Pt
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub frm_recibo_pagos_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ResetHeaderCheckBoxLocation(AdvBandedGridView1.Columns("Incluir").ColIndex, -1)

        If Me.WindowState = FormWindowState.Maximized Then
            AdvBandedGridView1.OptionsView.ShowFooter = True
            If frm_accesos_rapidos_clientes.Visible = True Then
                frm_accesos_rapidos_clientes.Close()
            End If
        Else
            AdvBandedGridView1.OptionsView.ShowFooter = False
        End If
    End Sub

    Private Sub VerPagarésToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerPagarésToolStripMenuItem.Click
        frm_visualizacion_pagares.ShowDialog(Me)
    End Sub

    Private Sub frm_recibo_pagos_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ControlRapido()
    End Sub

    Private Sub AdvBandedGridView1_MasterRowExpanded(sender As Object, e As XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles AdvBandedGridView1.MasterRowExpanded
        Dim detailView As XtraGrid.Views.BandedGrid.AdvBandedGridView = CType(sender, XtraGrid.Views.BandedGrid.AdvBandedGridView).GetDetailView(e.RowHandle, e.RelationIndex)

        detailView.OptionsBehavior.ReadOnly = True
        detailView.Columns("IDPagare").Visible = False
        detailView.Columns("IDFacturaDatos").Visible = False
        detailView.Columns("Numero").Visible = False
        detailView.Columns("Descripcion").Visible = False

        detailView.Columns("FechaVencimiento").Caption = "Vencimiento"
        detailView.Columns("FechaVencimiento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        detailView.Columns("FechaVencimiento").DisplayFormat.FormatString = "dd/MM/yyyy"
        detailView.Columns("FechaVencimiento").UnboundType = DevExpress.Data.UnboundColumnType.DateTime

        detailView.Columns("DiasVencidos").Caption = "Días"
        detailView.Columns("Nombre").Caption = "Cobrador"
        detailView.Columns("DiasVencidos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        detailView.Columns("DiasVencidos").DisplayFormat.FormatString = "n0"
        detailView.Columns("Monto").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        detailView.Columns("Monto").DisplayFormat.FormatString = "c2"
        detailView.Columns("Balance").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        detailView.Columns("Balance").DisplayFormat.FormatString = "c2"
        'detailView.Columns("SecondID").Caption = "Titulación"
        'detailView.Columns("FechaCargado").Caption = "Fecha"
        'detailView.Columns("TipoCargado").Caption = "T/Tit."
        'detailView.Columns("DiasVencidos").Caption = "Días"
        'detailView.Columns("StatusPagare").Caption = "Status"

        detailView.Bands.RemoveAt(1)
        detailView.Bands.RemoveAt(1)
        detailView.Bands.RemoveAt(1)

        AdvBandedGridView1.OptionsDetail.ShowDetailTabs = False
        detailView.OptionsView.ShowFilterPanelMode = XtraGrid.Views.Base.ShowFilterPanelMode.Never
        detailView.Bands(0).Caption = "Información de cuotas"
        detailView.Bands(0).ImageOptions.Image = Nothing
        detailView.RowSeparatorHeight = 0
        If detailView IsNot Nothing Then
            AddHandler detailView.RowCellStyle, AddressOf DetailView_RowCellStyle

            For i = 0 To detailView.Columns.Count - 1
                detailView.Columns(i).OptionsColumn.AllowEdit = False
                detailView.Columns(i).OptionsColumn.AllowGroup = False
            Next

            detailView.BestFitColumns()
        End If
    End Sub

    Private Sub DetailView_RowCellStyle(ByVal sender As Object, e As XtraGrid.Views.Grid.RowCellStyleEventArgs)
        'Marcar facturas vencidas

        Dim currentView As GridView = TryCast(sender, GridView)

            If e.Column.FieldName = "FechaVencimiento" Then
                If Convert.ToDateTime(currentView.GetRowCellValue(e.RowHandle, "FechaVencimiento")) < Now Then
                    e.Appearance.ForeColor = Color.Red
                    e.Appearance.Font = New Font("Tahoma", 8, FontStyle.Regular Or FontStyle.Underline)
                Else
                    e.Appearance.ForeColor = Color.Black
                    e.Appearance.Font = New Font("Tahoma", 8, FontStyle.Regular)
                End If

        End If

    End Sub
End Class
