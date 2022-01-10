Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO
Imports System.Drawing.Point

Public Class frm_registro_recibos_cobro

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet   'Normal Ds
    Dim Ds1 As New DataSet 'CbxFacturas
    Dim Adaptador As MySqlDataAdapter
    Dim lblIDTipoRecibo, lblIDCobradorEntrega, DefaultCobrador, lblIDTipoComision, lblExcedente, lblNulo As New Label
    Dim Permisos As New ArrayList
    Dim FechaConseguidaMinima, FechaConseguidaMaxima, PrimerDiaMes, UltimoDiaMes As Date
    Dim RangoInicial, RangoFinal As New Label
    Dim MontoDebido, MontoPagado As Double
    Dim DataGridViewTmp As New DataGridView
    Friend AvoidUpdateCbx As String = 0

    Private Sub frm_registro_recibos_cobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        SetConfiguracion()
        Permisos = PasarPermisos(Me.Tag)
        ColumnasDgvReciboDetalle()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Sub GetInformation()
        Try

            If txtIDCliente.Text <> "" Then
                DataGridViewTmp.Columns.Clear()
                DataGridViewTmp.AllowUserToAddRows = False
                DataGridViewTmp.Columns.Add("Fecha", "Fecha")
                DataGridViewTmp.Columns.Add("Compromiso", "Compromiso")
                DataGridViewTmp.Columns.Add("Pago", "Pagos")

                Con.Open()
                cmd = New MySqlCommand("SELECT FacturaDatos.FechaVencimiento FROM libregco.FacturaDatos where IDCliente='" + txtIDCliente.Text + "' ORDER BY FECHAVENCIMIENTO ASC LIMIT 1", Con)
                If IsDate(Convert.ToString(cmd.ExecuteScalar())) Then
                    FechaConseguidaMinima = Convert.ToString(cmd.ExecuteScalar())
                Else
                    Con.Close()
                    Exit Sub
                End If

                FechaConseguidaMaxima = DateSerial(Today.Year, Today.Month, Date.DaysInMonth(Today.Year, Today.Month))
                RangoInicial.Text = FechaConseguidaMinima
                RangoFinal.Text = FechaConseguidaMaxima

                DataGridViewTmp.Rows.Clear()
                Chart1.Series(0).Points.Clear()
                Chart1.Series(1).Points.Clear()

                Dim asd As String
                For i = Year(FechaConseguidaMinima) To Year(FechaConseguidaMaxima)
                    For m = 1 To 12
                        PrimerDiaMes = DateSerial(i, m, 1)
                        UltimoDiaMes = PrimerDiaMes.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")

                        asd = asd & vbNewLine & PrimerDiaMes & "-" & UltimoDiaMes
                        cmd = New MySqlCommand("SELECT Coalesce(sum(Monto),0) FROM libregco.pagares INNER JOIN Libregco.FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos where FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and Pagares.FechaVencimiento Between '" + PrimerDiaMes.ToString("yyyy-MM-dd") + "' and '" + UltimoDiaMes.ToString("yyyy-MM-dd") + "'", Con)
                        MontoDebido = Convert.ToString(cmd.ExecuteScalar())

                        cmd = New MySqlCommand("SELECT Coalesce(sum(Total),0) FROM libregco.Abonos Where IDCliente='" + txtIDCliente.Text + "' AND Fecha Between '" + PrimerDiaMes.ToString("yyyy-MM-dd") + "' and '" + UltimoDiaMes.ToString("yyyy-MM-dd") + "'", Con)
                        MontoPagado = Convert.ToString(cmd.ExecuteScalar())

                        If DateSerial(i, m, 1) < FechaConseguidaMaxima Then
                            If MontoDebido + MontoPagado > 0 Then
                                DataGridViewTmp.Rows.Add(PrimerDiaMes.ToString("yyyy-MM"), MontoDebido.ToString("C"), MontoPagado.ToString("C"))
                            End If
                        End If
                    Next
                Next

                Con.Close()
               
                For Each row As DataGridViewRow In DataGridViewTmp.Rows
                    Chart1.Series("Compromisos").Points.AddXY(row.Cells(0).Value, CDbl(row.Cells(1).Value).ToString("C"))
                    Chart1.Series("Pagos").Points.AddXY(row.Cells(0).Value, CDbl(row.Cells(2).Value).ToString("C"))
                Next
            End If



        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub SetConfiguracion()
        Try
            Con.Open()

            'Cobrador Predeterminado
            cmd = New MySqlCommand("SELECT Value2Int FROM configuracion where IDConfiguracion=25", Con)
            DefaultCobrador.Text = Convert.ToString(cmd.ExecuteScalar())
         
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ColumnasDgvReciboDetalle()
        DgvDetalleRecibos.Columns.Clear()
        With DgvDetalleRecibos
            .Columns.Add("IDDetalleRecibo", "IDDetalleRecibo")  '0
            .Columns.Add("IDReciboCobro", "Recibo") '1
            .Columns.Add("IDFactura", "No. Factura")   '2
            .Columns.Add("IDPagare", "IDPagare")    '3
            .Columns.Add("NoPagare", "No. Pagaré")    '4
            .Columns.Add("Monto", "Monto")  '5
            .Columns.Add("Descuento", "Descuento")  '6
            .Columns.Add("TipoComision", "Tipo Comisión") '7
            .Columns.Add("IDComision", "IDComisión")    '8
            .Columns.Add("Comision", "Comisión")    '9
            .Columns.Add("Cargos", "Cargos")    '10
        End With
        PropiedadDgvReciboDetalle()
    End Sub

    Private Sub PropiedadDgvReciboDetalle()
        With DgvDetalleRecibos
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Width = 140
            .Columns(3).Visible = False
            .Columns(4).Width = 120
            .Columns(5).Width = 115
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(6).Width = 105
            .Columns(6).DefaultCellStyle.Format = ("C")
            .Columns(7).Width = 300
            .Columns(8).Visible = False
            .Columns(9).Width = 160
            .Columns(9).DefaultCellStyle.Format = ("C")
            .Columns(10).DisplayIndex = 7
            .Columns(10).DefaultCellStyle.Format = ("C")
            .Columns(10).Width = 105
        End With
    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtNombre.Text = "No hay un cliente seleccionado"
        txtIDCobradorC.Clear()
        txtCobradorC.Clear()
        txtBalanceGral.Clear()
        txtUltimoPago.Clear()
        txtCalificacion.Clear()
        DtpFechaRecibo.Value = Now().AddDays(-1)
        cbxNoEntrega.Items.Clear()
        cbxNoRecibo.Items.Clear()
        CbxFactura.Items.Clear()
        CbxNoPagare.Items.Clear()
        CbxTipoComision.Items.Clear()
        cbxTipoRecibo.Items.Clear()
        txtMontoTotal.Clear()
        lblIDEntrega.Text = ""
        lblStatusBar.Text = "Listo"
        lblIDRecibo.Text = ""
        lblIDTipoRecibo.Text = ""
        lblIDPagare.Text = ""
        txtMonto.Clear()
        txtDescuento.Clear()
        txtComision.Clear()
        txtBalancePagare.Clear()
        txtMontoPagare.Clear()
        txtFechaVenc.Clear()
        txtDiasVenc.Clear()
        lblIDDetalle.Text = ""
        Label14.Text = ""
        lblCheckNotaDescuento.Text = ""
        txtNota.Clear()
        txtPagareStatus.Clear()
        txtCobrador.Clear()
        txtIDCobrador.Clear()
        DgvDetalleRecibos.Rows.Clear()
        DgvAuditoria.Rows.Clear()
        DgvRecibos.Rows.Clear()
        TextBox1.Text = "No hay un cliente seleccionado"
        Label46.Text = ""
        Label45.Text = ""
        Label47.Text = ""
        Label50.Text = ""
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        lblIDCobradorEntrega.Text = ""
        chkNulo.Checked = False
        DtpFechaRecibo.Value = Now().AddDays(-1)
        ResultadosEncontrados()
        lblExcedente.Text = 0
        lblIDFactura.Text = ""
        lblFechaEntrega.Text = ""
        lblCobradorEntrega.Text = ""
        lblUsuarioEntrega.Text = ""
        lblCantidadEntrega.Text = ""
        lblRangoEntrega.Text = ""
        lblComisionEntrega.Text = ""
        lblDescripcionEntrega.Text = ""
        lblNulo.Text = 0
        lblEstadoCobrador.Text = ""
        lblCheckNotaDescuento.Text = ""
        Label14.Text = ""
        lblMensajeAuditor.Text = ""
        AvoidUpdateCbx = 0
        lblAnular.Visible = False
        txtMontoRecibos.Text = CDbl(0).ToString("C")
        lblEstadoCobrador.ForeColor = Color.Black
        MakeRoundedImageToPanel(My.Resources.no_photo, PicCliente)
        Panel1.BackgroundImage = PicCliente.BackgroundImage
        FillCbxNoEntrega()
        FillDgvRecibos()
        TabControl1.SelectedIndex = 0
        Chart1.Series(0).Points.Clear()
    End Sub

    Sub FillDgvRecibos()
        Try
            DgvRecibos.Rows.Clear()

            If cbxNoEntrega.Text <> "1" Then
                Dim DateFormat As String

                ConMixta.Open()

                Dim Consulta As New MySqlCommand("SELECT IDReciboCobro,PreRecibo,NoRecibo,Fecha,RecibosCobro.IDTipoRecibo,TipoRecibos.Descripcion,Comentario,Monto FROM" & SysName.Text & "reciboscobro LEFT JOIN Libregco.TipoRecibos on RecibosCobro.IDTipoRecibo=TipoRecibos.IDTipoRecibo where RecibosCobro.IDEntregaCobro='" + lblIDEntrega.Text + "' ORDER BY NoRecibo ASC", ConMixta)
                Dim LectorRecibos As MySqlDataReader = Consulta.ExecuteReader

                While LectorRecibos.Read
                    If IsDate(LectorRecibos.GetValue(3)) Then
                        DateFormat = CDate(LectorRecibos.GetValue(3)).ToString("dd/MM/yyyy")
                    Else
                        DateFormat = "No procesada"
                    End If
                    DgvRecibos.Rows.Add(LectorRecibos.GetValue(0), LectorRecibos.GetValue(1), LectorRecibos.GetValue(2), DateFormat, LectorRecibos.GetValue(4), LectorRecibos.GetValue(5), LectorRecibos.GetValue(6), CDbl(LectorRecibos.GetValue(7)).ToString("C"))
                End While

                LectorRecibos.Close()
                ConMixta.Close()

                For Each row As DataGridViewRow In DgvRecibos.Rows
                    If IsDate(row.Cells(3).Value) Then
                    Else
                        DgvRecibos.ClearSelection()
                        DgvRecibos.Rows(row.Index).Selected = True
                        DgvRecibos.FirstDisplayedScrollingRowIndex = row.Index
                        Exit For
                    End If
                Next

                For Each rw As DataGridViewRow In DgvRecibos.Rows
                    If IsDate(rw.Cells(3).Value) Then
                        rw.DefaultCellStyle.BackColor = SystemColors.ControlLight
                    End If
                Next
            End If


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub FillDgvAuditoria()
        Try
            DgvAuditoria.Rows.Clear()
            ConMixta.Open()
            Dim Consulta As New MySqlCommand("SELECT IDRecibosCobroAuditoria,IDRecibosCobro,Abonos.SecondID,Abonos.Fecha,Abonos.Hora,RecibosCobroAuditoria.Monto,Abonos.Concepto,RecibosCobroAuditoria.IDAbono FROM" & SysName.Text & "reciboscobroauditoria INNER JOIN" & SysName.Text & "Abonos on RecibosCobroAuditoria.IDAbono=Abonos.IDAbono where RecibosCobroAuditoria.IDRecibosCobro='" + lblIDRecibo.Text + "'", ConMixta)
            Dim LectorRecibos As MySqlDataReader = Consulta.ExecuteReader

            While LectorRecibos.Read
                DgvAuditoria.Rows.Add(LectorRecibos.GetValue(0), LectorRecibos.GetValue(1), LectorRecibos.GetValue(2), CDate(LectorRecibos.GetValue(3)).ToString("dd/MM/yyyy") & " " & Convert.ToString(LectorRecibos.GetValue(4)), CDbl(LectorRecibos.GetValue(5)).ToString("C"), LectorRecibos.GetValue(6), LectorRecibos.GetValue(7))
            End While

            LectorRecibos.Close()
            ConMixta.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Sub FillCbxNoEntrega()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select NoEntrega from EntregaCobro Where Cierre=0 and Nulo=0", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "EntregaCobro")
        cbxNoEntrega.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("EntregaCobro")

        For Each Fila As DataRow In Tabla.Rows
            cbxNoEntrega.Items.Add(Fila.Item("NoEntrega"))
        Next

        If cbxNoEntrega.Items.Count = 1 Then
            cbxNoEntrega.SelectedIndex = 0
            cbxNoRecibo.DroppedDown = True
            cbxNoRecibo.Focus()
        End If

    End Sub

    Private Sub SetIDEntrega()
        Con.Open()
        Ds.Clear()
        cmd = New MySqlCommand("SELECT IDEntregaCobro,IDAreaImpresion,AreaImpresion.ComputerName,IDUsuario,Usuarios.Nombre as NombreUsuario,Fecha,Hora,NoEntrega,FechaEntrega,IDCobrador,Cobrador.Nombre as NombreCobrador,Cantidad,NoInicial,NoFinal,Monto,Comision,Descripcion,Cierre,Pagada,EntregaCobro.Nulo FROM entregacobro INNER JOIN Empleados as Usuarios on EntregaCobro.IDUsuario=Usuarios.IDEmpleado INNER JOIN Empleados as Cobrador on EntregaCobro.IDCobrador=Cobrador.IDEmpleado INNER JOIN AreaImpresion on EntregaCobro.IDAreaImpresion=AreaImpresion.IDEquipo Where NoEntrega='" + cbxNoEntrega.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "RecibosCobro")
        cbxNoRecibo.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("RecibosCobro")

        lblIDEntrega.Text = (Tabla.Rows(0).Item("IDEntregaCobro"))
        lblFechaEntrega.Text = CDate(Tabla.Rows(0).Item("FechaEntrega")).ToString("dd/MM/yyyy")
        lblCobradorEntrega.Text = "[" & (Tabla.Rows(0).Item("IDCobrador")) & "] " & (Tabla.Rows(0).Item("NombreCobrador"))
        lblIDCobradorEntrega.Text = (Tabla.Rows(0).Item("IDCobrador"))
        lblUsuarioEntrega.Text = "[" & (Tabla.Rows(0).Item("IDUsuario")) & "] " & (Tabla.Rows(0).Item("NombreUsuario"))
        lblCantidadEntrega.Text = (Tabla.Rows(0).Item("Cantidad"))
        lblRangoEntrega.Text = (Tabla.Rows(0).Item("NoInicial")) & " - " & (Tabla.Rows(0).Item("NoFinal"))
        lblComisionEntrega.Text = CDbl(Tabla.Rows(0).Item("Comision")).ToString("C")
        lblDescripcionEntrega.Text = (Tabla.Rows(0).Item("Descripcion"))

    End Sub

    Private Sub cbxNoEntrega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNoEntrega.SelectedIndexChanged
        SetIDEntrega()
        FillRecibos()
        FillDgvRecibos()
        VerificarCobrador()

        If cbxNoEntrega.Text = "1" Then
            LinkLabel1.Visible = True
        Else
            LinkLabel1.Visible = False
        End If

        Label46.Text = cbxNoEntrega.Text

        GetChartInformation()
    End Sub

    Sub FillRecibos()
        Con.Open()
        Ds.Clear()
        cmd = New MySqlCommand("Select Concat(PreRecibo,'-',NoRecibo) as Recibo from RecibosCobro Where IDEntregaCobro='" + lblIDEntrega.Text + "' ORDER BY IDReciboCobro ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "RecibosCobro")
        cbxNoRecibo.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("RecibosCobro")
        For Each Fila As DataRow In Tabla.Rows
            cbxNoRecibo.Items.Add(Fila.Item("Recibo"))
        Next

        If cbxNoRecibo.Items.Count = 1 Then
            cbxNoRecibo.SelectedIndex = 0
            cbxTipoRecibo.Focus()
        End If
    End Sub

    Private Sub cbxNoRecibo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNoRecibo.SelectedIndexChanged
        If AvoidUpdateCbx = 0 Then
            SetIDNoRecibo()
            FillTipoRecibo()
            BuscarRegistrosDetalle()
            CompleteTRecibo()
            AvoidDifCustomer()
            Label47.Text = cbxNoRecibo.Text

            For Each Rw As DataGridViewRow In DgvRecibos.Rows
                If Rw.Cells(1).Value & "-" & Rw.Cells(0).Value = cbxNoRecibo.Text Then
                    DgvRecibos.ClearSelection()
                    DgvRecibos.Rows(Rw.Index).Selected = True
                    DgvRecibos.FirstDisplayedScrollingRowIndex = Rw.Index
                End If
            Next
        Else
            SetIDNoRecibo()
            FillTipoRecibo()
            'BuscarRegistrosDetalle()
            CompleteTRecibo()
            Label47.Text = cbxNoRecibo.Text
        End If
        
    End Sub

    Private Sub AvoidDifCustomer()
        Dim MultCustRC, IDCliente, Nombre As String

        Con.Open()
        cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=14", Con)
        MultCustRC = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If MultCustRC = 0 Then
            Con.Open()
            cmd = New MySqlCommand("SELECT FacturaDatos.IDCliente FROM recibosdetalle INNER JOIN Pagares on RecibosDetalle.IDPagare=Pagares.IDPagare INNER JOIN FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Clientes on FacturaDatos.IDCliente=Clientes.IDCliente WHERE IDReciboCobro= '" + lblIDRecibo.Text + "' LIMIT 1", Con)
            IDCliente = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT FacturaDatos.IDCliente FROM recibosdetalle INNER JOIN Pagares on RecibosDetalle.IDPagare=Pagares.IDPagare INNER JOIN FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Clientes on FacturaDatos.IDCliente=Clientes.IDCliente WHERE IDReciboCobro= '" + lblIDRecibo.Text + "' LIMIT 1", Con)
            Nombre = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If IDCliente = "" Then
                Exit Sub
            End If

            If IDCliente <> txtIDCliente.Text Then
                MessageBox.Show("El Recibo No: " & cbxNoRecibo.Text & " ya esta siendo utilizado por el cliente: " & vbNewLine & Nombre & " [" & IDCliente & "]." & vbNewLine & vbNewLine & "Recuerde que esta configuración puede ser cambiada en los ajustes del sistema.")
                DgvDetalleRecibos.Rows.Clear()
                cbxNoRecibo.Items.Clear()
                cbxTipoRecibo.Items.Clear()
                txtMontoTotal.Clear()
                FillRecibos()
            End If
        End If

    End Sub

    Private Sub CompleteTRecibo()
        If DgvDetalleRecibos.Rows.Count > 0 Then
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM reciboscobro INNER JOIN TipoRecibos on RecibosCobro.IDTipoRecibo=TipoRecibos.IDTipoRecibo WHERE IDReciboCobro= '" + lblIDRecibo.Text + "'", Con)
            cbxTipoRecibo.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        End If
    End Sub

    Private Sub BuscarRegistrosDetalle()
        Try
            If frm_recibos_cobro_entrega_casa.Visible = False Then
                DgvDetalleRecibos.Rows.Clear()
                ConMixta.Open()
                Dim Consulta As New MySqlCommand("SELECT IDDetalleRecibo,RecibosDetalle.IDReciboCobro,FacturaDatos.IDFacturaDatos,RecibosDetalle.IDPagare,NoPagare,Debito,RecibosDetalle.Descuento,Descripcion,IDComision,RecibosDetalle.Comision,FacturaDatos.IDCliente,Clientes.Nombre,Calificacion.Calificacion,Clientes.BalanceGeneral,Clientes.IDEmpleado,Cobrador.Nombre as Cobrador,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(SELECT Ruta FROM" & SysName.Text & "documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,RecibosDetalle.Cargos FROM" & SysName.Text & "recibosdetalle INNER JOIN" & SysName.Text & "Reciboscobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro INNER JOIN" & SysName.Text & "Pagares on RecibosDetalle.IDPagare=Pagares.IDPagare INNER JOIN" & SysName.Text & "FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.comisioncobro on RecibosDetalle.IDComision=ComisionCobro.IDComisionCobro INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Cobrador on CLientes.IDEmpleado=Cobrador.IDEmpleado Where RecibosCobro.IDReciboCobro='" + lblIDRecibo.Text + "'", ConMixta)
                Dim LectorRecibosDetalle As MySqlDataReader = Consulta.ExecuteReader

                While LectorRecibosDetalle.Read
                    DgvDetalleRecibos.Rows.Add(LectorRecibosDetalle.GetValue(0), LectorRecibosDetalle.GetValue(1), LectorRecibosDetalle.GetValue(2), LectorRecibosDetalle.GetValue(3), LectorRecibosDetalle.GetValue(4), LectorRecibosDetalle.GetValue(5), LectorRecibosDetalle.GetValue(6), LectorRecibosDetalle.GetValue(7), LectorRecibosDetalle.GetValue(8), LectorRecibosDetalle.GetValue(9), LectorRecibosDetalle.GetValue(18))

                    txtIDCliente.Text = LectorRecibosDetalle.GetValue(10)
                    txtNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LectorRecibosDetalle.GetValue(11).ToString.ToLower)
                    TextBox1.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LectorRecibosDetalle.GetValue(11).ToString.ToLower)
                    txtCalificacion.Text = LectorRecibosDetalle.GetValue(12)
                    txtBalanceGral.Text = CDbl(LectorRecibosDetalle.GetValue(13)).ToString("C")

                    If CDbl(LectorRecibosDetalle.GetValue(13)) = 0 Then
                        txtBalanceGral.ForeColor = Color.Black
                    Else
                        txtBalanceGral.ForeColor = Color.Red
                    End If

                    txtIDCobradorC.Text = LectorRecibosDetalle.GetValue(14)
                    txtCobradorC.Text = LectorRecibosDetalle.GetValue(15)

                    If IsDate(LectorRecibosDetalle.GetValue(16)) Then
                        txtUltimoPago.Text = CDate(LectorRecibosDetalle.GetValue(16)).ToString("dd/MM/yyyy")
                    Else
                        txtUltimoPago.Text = ""
                    End If

                    If TypeConnection.Text = 1 Then
                        If IsDBNull(LectorRecibosDetalle.GetValue(17)) Then
                            MakeRoundedImageToPanel(My.Resources.no_photo, PicCliente)
                        Else
                            Dim ExistFile As Boolean = System.IO.File.Exists(LectorRecibosDetalle.GetValue(17))
                            If ExistFile = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(LectorRecibosDetalle.GetValue(17), FileMode.Open, FileAccess.Read)
                                MakeRoundedImageToPanel(System.Drawing.Image.FromStream(wFile), PicCliente)
                                wFile.Close()

                            Else
                                MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & LectorRecibosDetalle.GetValue(17) & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If
                        End If
                    End If
                End While

                If DgvDetalleRecibos.Rows.Count > 0 Then
                    Dim Monto As Double = 0

                    For Each rw As DataGridViewRow In DgvDetalleRecibos.Rows
                        Monto = CDbl(rw.Cells(5).Value) + CDbl(rw.Cells(6).Value) + CDbl(rw.Cells(10).Value) + Monto
                    Next
                    Label45.Text = Monto.ToString("C")

                    Panel1.BackgroundImage = PicCliente.BackgroundImage
                    GetInformation()
                    FillCbxFacturas()
                    VerificarCobrador()
                    SumRCenAuditoria()
                Else
                    TextBox1.Text = "No hay un cliente seleccionado"
                    MakeRoundedImageToPanel(My.Resources.no_photo, PicCliente)
                    Panel1.BackgroundImage = PicCliente.BackgroundImage
                    Label45.Text = ""
                    Label50.Text = ""
                    Chart1.Series(0).Points.Clear()
                    Chart1.Series(1).Points.Clear()
                    txtIDCliente.Clear()
                    txtNombre.Text = "No hay un cliente seleccionado"
                    txtIDCobradorC.Clear()
                    txtCobradorC.Clear()
                    txtBalanceGral.Clear()
                    txtUltimoPago.Clear()
                    txtCalificacion.Clear()
                End If

                LectorRecibosDetalle.Close()
                ConMixta.Close()
                ResultadosEncontrados()

            End If
           
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ResultadosEncontrados()
        If DgvDetalleRecibos.Rows.Count = 0 Then
            lblCountRows.Text = "No se encontraron resultados."
        ElseIf DgvDetalleRecibos.Rows.Count = 1 Then
            lblCountRows.Text = "Se ha encontrado: 1 Resultado"
        ElseIf DgvDetalleRecibos.Rows.Count > 1 Then
            lblCountRows.Text = "Se han encontrado: " & DgvDetalleRecibos.Rows.Count & " Resultados"
        End If
    End Sub

    Private Sub SetIDNoRecibo()
        Dim Nulo As String

        If cbxNoRecibo.Text <> "" Then
            Con.Open()
            cmd = New MySqlCommand("SELECT IDReciboCobro FROM RecibosCobro WHERE Concat(PreRecibo,'-',NoRecibo)= '" + cbxNoRecibo.Text + "'", Con)
            lblIDRecibo.Text = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT Monto FROM RecibosCobro WHERE Concat(PreRecibo,'-',NoRecibo)= '" + cbxNoRecibo.Text + "'", Con)
            txtMontoTotal.Text = Convert.ToDouble(cmd.ExecuteScalar()).ToString("C")

            cmd = New MySqlCommand("SELECT Nulo FROM RecibosCobro WHERE Concat(PreRecibo,'-',NoRecibo)= '" + cbxNoRecibo.Text + "'", Con)
            Nulo = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If Nulo = 1 Then
                chkNulo.Checked = True
            Else
                chkNulo.Checked = False
            End If

            lblAnular.Visible = True
        Else
            lblAnular.Visible = False
        End If

        FillDgvAuditoria()

    End Sub

    Private Sub GetChartInformation()
        Try

            If cbxNoEntrega.Text = "" Then
                Chart2.Visible = False
                GroupBox3.Visible = False
            Else
                If cbxNoEntrega.Text <> "1" Then
                    Chart2.Visible = True
                    GroupBox3.Visible = True

                    ConMixta.Open()
                    Ds.Clear()
                    cmd = New MySqlCommand("SELECT count(IDReciboCobro) as Cantidad,TipoRecibos.Descripcion,(count(IDReciboCobro)/(select Count(IDReciboCobro) from" & SysName.Text & "RecibosCobro Where RecibosCobro.IDEntregaCobro='" + lblIDEntrega.Text + "')) as Porcentaje,sum(RecibosCobro.Monto) as Montos FROM" & SysName.Text & "entregacobro inner join" & SysName.Text & "reciboscobro on entregacobro.identregacobro=reciboscobro.identregacobro inner join libregco.tiporecibos on reciboscobro.idtiporecibo=tiporecibos.idtiporecibo where EntregaCobro.IDEntregaCobro='" + lblIDEntrega.Text + "' group by TipoRecibos.Descripcion", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "facturaarticulos")
                    ConMixta.Close()

                    Dim Tabla As DataTable = Ds.Tables("facturaarticulos")

                    Chart2.DataSource = Tabla
                    Chart2.Series("Series1").XValueMember = "Descripcion"

                    If rdbCantidad.Checked = True Then
                        Chart2.Series("Series1").YValueMembers = "Cantidad"
                        Chart2.Series("Series1").LabelFormat = ""
                        Chart2.Titles("Title1").Text = "Clasificación de recibos por cantidad"
                    ElseIf rdbMonto.Checked = True Then
                        Chart2.Series("Series1").YValueMembers = "Montos"
                        Chart2.Series("Series1").LabelFormat = "C"
                        Chart2.Titles("Title1").Text = "Clasificación de recibos por montos"
                    End If

                    Chart2.DataBind()

                End If
             
            End If
            
            'If Tabla.Rows.Count > 0 Then
            '    For Each row As DataRow In Tabla.Rows
            '        Chart1.Series("Series1").Points.AddXY(row.Item(1), 2)
            '    Next


            'End If




        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillTipoRecibo()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Descripcion from TipoRecibos Where Nulo=0", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoRecibo")
        cbxTipoRecibo.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoRecibo")
        Dim Fila As DataRow

        For Each Fila In Tabla.Rows
            cbxTipoRecibo.Items.Add(Fila.Item("Descripcion"))
        Next

    End Sub

    Private Sub SetIDTipoRecibo()
        If Con.State = 1 Then
            Con.Close()
        End If

        Con.Open()
        cmd = New MySqlCommand("SELECT IDTipoRecibo FROM TipoRecibos WHERE Descripcion= '" + cbxTipoRecibo.Text + "'", Con)
        lblIDTipoRecibo.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub cbxTipoRecibo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoRecibo.SelectedIndexChanged
        SetIDTipoRecibo()
    End Sub

    Sub FillCbxFacturas()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT SecondID FROM FacturaDatos Where IDCliente='" + txtIDCliente.Text + "' and Nulo=0", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "FacturaDatos")
        CbxFactura.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("FacturaDatos")

        For Each Fila As DataRow In Tabla.Rows
            CbxFactura.Items.Add(Fila.Item("SecondID"))
        Next
    End Sub

    Private Sub CbxFactura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFactura.SelectedIndexChanged
        SetIDFactura()
        FillCbxPagares()
    End Sub

    Private Sub SetIDFactura()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDFacturaDatos FROM FacturaDatos WHERE SecondID= '" + CbxFactura.Text + "'", Con)
        lblIDFactura.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT NotaContado FROM FacturaDatos WHERE SecondID= '" + CbxFactura.Text + "'", Con)

        If Convert.ToInt16(cmd.ExecuteScalar()) = 1 Then
            cmd = New MySqlCommand("SELECT CondicionContado FROM FacturaDatos WHERE SecondID= '" + CbxFactura.Text + "'", Con)
            lblCheckNotaDescuento.Text = "La factura seleccionada tiene una nota de descuento.!!" & vbNewLine & Convert.ToString(cmd.ExecuteScalar())
        Else
            lblCheckNotaDescuento.Text = ""
        End If

        Con.Close()
    End Sub

    Private Sub FillCbxPagares()
        Try

            If IsNumeric(DefaultCobrador.Text) Then
                If lblIDCobradorEntrega.Text = DefaultCobrador.Text Then
                    Ds.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT NoPagare FROM Pagares Where IDFactura='" + lblIDFactura.Text + "' and Balance>0 and Nulo=0", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "Pagares")
                    CbxNoPagare.Items.Clear()
                    Con.Close()

                    Dim Tabla As DataTable = Ds.Tables("Pagares")
                    For Each Fila As DataRow In Tabla.Rows
                        CbxNoPagare.Items.Add(Fila.Item("NoPagare"))
                    Next

                    If Tabla.Rows.Count = 0 Then
                        MessageBox.Show("Todos los pagarés han sido cargados al cobrador por lo que no pueden ser visualizados en la entrega seleccionada.", "No hay pagarés disponibles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If

                Else
                    Ds.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT NoPagare FROM Pagares Where IDFactura='" + lblIDFactura.Text + "' and  (IDEmpleado='" + lblIDCobradorEntrega.Text + "' or IDEmpleado='" + txtIDCobradorC.Text + "') and Balance>0 and Nulo=0 ", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "Pagares")
                    CbxNoPagare.Items.Clear()
                    Con.Close()

                    Dim Tabla As DataTable = Ds.Tables("Pagares")
                    For Each Fila As DataRow In Tabla.Rows
                        CbxNoPagare.Items.Add(Fila.Item("NoPagare"))
                    Next

                    If Tabla.Rows.Count = 0 Then
                        MessageBox.Show("El cobrador " & lblCobradorEntrega.Text & " no tiene cargado pagaré(s) correspondiente a la factura No." & CbxFactura.Text & " y/o no tiene pagarés con balance pendiente.", "No se encontraron pagarés", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    End If

                End If
            End If
     

            txtMonto.Text = CDbl(0).ToString("C")
            txtDescuento.Text = CDbl(0).ToString("C")
            txtCargos.Text = CDbl(0).ToString("C")

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "Desde FillCbxPagares")
        End Try
    End Sub

    Private Sub FillCbxTipoComision()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM ComisionCobro Where Nulo=0", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "ComisionCobro")
        CbxTipoComision.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("ComisionCobro")

        For Each Fila As DataRow In Tabla.Rows
            CbxTipoComision.Items.Add(Fila.Item("Descripcion"))
        Next

        If cbxNoEntrega.Text = "1" Then
            CbxTipoComision.SelectedIndex = 2
        End If

    End Sub

    Private Sub CbxNoPagare_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxNoPagare.SelectedIndexChanged
        SetIDPagare()
        SetPagareInfo()
        FillCbxTipoComision()
    End Sub

    Private Sub SetPagareInfo()
        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT FechaVencimiento,DiasVencidos,Monto,Pagares.Balance,StatusPagare.Descripcion,Pagares.IDEmpleado,Empleados.Nombre FROM" & SysName.Text & "pagares INNER JOIN Libregco.StatusPagare on Pagares.IDStatusPagare=StatusPagare.IDStatusPagare INNER JOIN " & SysName.Text & "Empleados on Pagares.IDEmpleado=Empleados.IDEmpleado where IDPagare='" + lblIDPagare.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Pagares")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds.Tables("Pagares")
        txtFechaVenc.Text = (Tabla.Rows(0).Item("FechaVencimiento"))
        txtDiasVenc.Text = (Tabla.Rows(0).Item("DiasVencidos"))

        If CDbl(Tabla.Rows(0).Item("DiasVencidos")) > 0 Then
            txtDiasVenc.Visible = False
            Label14.Text = "El pagaré está vencido hace " & Tabla.Rows(0).Item("DiasVencidos") & " días."
        Else
            txtDiasVenc.Visible = False
        End If

        txtMontoPagare.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
        txtBalancePagare.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
        txtPagareStatus.Text = (Tabla.Rows(0).Item("Descripcion"))
        txtIDCobrador.Text = Tabla.Rows(0).Item("IDEmpleado")
        txtCobrador.Text = Tabla.Rows(0).Item("Nombre")

        If lblIDCobradorEntrega.Text <> txtIDCobrador.Text Then
            MessageBox.Show("El pagaré seleccionado esta asignado al cobrador " & "[" & txtIDCobrador.Text & "] " & txtCobrador.Text & " mientras que la entrega de cobros seleccionada pertenece a " & lblCobradorEntrega.Text & "." & vbNewLine & vbNewLine & "Este mensaje ha sido generado por el principio de titulación de pagarés y el control de listados de cobros.", "Cobradores diferentes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub SetIDPagare()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDPagare FROM Pagares WHERE IDFactura='" + lblIDFactura.Text + "' and NoPagare= '" + CbxNoPagare.Text + "'", Con)
        lblIDPagare.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtMonto.Leave
        Try
            If txtMonto.Text = "" Then
                txtMonto.Text = CDbl(0).ToString("C")
            Else
                txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
            End If

        Catch ex As Exception
            txtMonto.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtCargos_Leave(sender As Object, e As EventArgs) Handles txtCargos.Leave
        Try
            If txtCargos.Text = "" Then
                txtCargos.Text = CDbl(0).ToString("C")
            Else
                txtCargos.Text = CDbl(txtCargos.Text).ToString("C")
            End If

            CbxTipoComision.Focus()

        Catch ex As Exception
            txtCargos.Text = CDbl(0).ToString("C")
        End Try
    End Sub


    Private Sub txtDescuento_Leave(sender As Object, e As EventArgs) Handles txtDescuento.Leave
        Try
            If txtDescuento.Text = "" Then
                txtDescuento.Text = CDbl(0).ToString("C")
            Else
                txtDescuento.Text = CDbl(txtDescuento.Text).ToString("C")
            End If

            txtCargos.Focus()

        Catch ex As Exception
            txtDescuento.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub txtCargos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCargos.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub txtDescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuento.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub txtMonto_Enter(sender As Object, e As EventArgs) Handles txtMonto.Enter
        Try
            If txtMonto.Text = "" Then
            Else
                txtMonto.Text = CDbl(txtMonto.Text)
                txtMonto.SelectAll()
            End If

        Catch ex As Exception
            txtMonto.Text = CDbl(0)
        End Try
    End Sub

    Private Sub txtDescuento_Enter(sender As Object, e As EventArgs) Handles txtDescuento.Enter
        Try
            If txtDescuento.Text = "" Then
            Else
                txtDescuento.Text = CDbl(txtDescuento.Text)
                txtDescuento.SelectAll()
            End If

        Catch ex As Exception
            txtDescuento.Text = CDbl(0)
        End Try
    End Sub

    Private Sub txtCargos_Enter(sender As Object, e As EventArgs) Handles txtCargos.Enter
        Try
            If txtCargos.Text = "" Then
            Else
                txtCargos.Text = CDbl(txtCargos.Text)
                txtCargos.SelectAll()
            End If

        Catch ex As Exception
            txtCargos.Text = CDbl(0)
        End Try
    End Sub


    Private Sub CbxTipoComision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxTipoComision.SelectedIndexChanged
        SetIDTipoComision()
        CalcComision()
    End Sub

    Private Sub SetIDTipoComision()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDComisionCobro FROM ComisionCobro WHERE Descripcion='" + CbxTipoComision.Text + "'", Con)
        lblIDTipoComision.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub CalcComision()
        Dim PorcentajeCom As Double

        Con.Open()
        cmd = New MySqlCommand("SELECT Comision FROM ComisionCobro WHERE Descripcion='" + CbxTipoComision.Text + "'", Con)
        PorcentajeCom = Convert.ToDouble(cmd.ExecuteScalar())
        Con.Close()

        txtComision.Text = (PorcentajeCom * CDbl(CDbl(txtMonto.Text) + CDbl(txtCargos.Text))).ToString("C")
    End Sub

    Private Sub txtMonto_TextChanged(sender As Object, e As EventArgs) Handles txtMonto.TextChanged
        Try
            If txtMonto.Text = "" Or txtDescuento.Text = "" Then
            Else
                If CDbl(txtMonto.Text) + CDbl(txtDescuento.Text) > CDbl(txtBalancePagare.Text) Then
                    MessageBox.Show("El monto aplicado excede el balance del pagare. Por favor verifique los datos a introducir." & vbNewLine & vbNewLine & "De lo contrario, determine el ajuste a utilizar en los siguientes pagareses.", "Excede Balance Pagare", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtMonto.Text = CDbl(txtBalancePagare.Text) - CDbl(txtDescuento.Text).ToString("C")
                Else
                    CalcComision()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDescuento_TextChanged(sender As Object, e As EventArgs) Handles txtDescuento.TextChanged
        Try
            If txtDescuento.Text = "" Or txtMonto.Text = "" Then
            Else
                If CDbl(txtMonto.Text) + CDbl(txtDescuento.Text) > CDbl(txtBalancePagare.Text) Then
                    MessageBox.Show("El descuento aplicado excede el balance del pagare." & vbNewLine & vbNewLine & "Por favor verifique los datos a introducir. De lo contrario, determine el ajuste a utilizar en los siguientes pagareses.", "Excede Balance Pagare", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtDescuento.Text = CDbl(txtBalancePagare.Text) - CDbl(txtMonto.Text).ToString("C")
                Else
                    CalcComision()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnInsertDetalle_Click(sender As Object, e As EventArgs) Handles btnInsertDetalle.Click
        If cbxNoRecibo.Text = "" Then
            MessageBox.Show("Seleccione el No. del Recibo para continuar el procedimiento de detalle(s) de cobro.", "Seleccione la No. Recibo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxNoRecibo.Focus()
            Exit Sub
        ElseIf CbxFactura.Text = "" Then
            MessageBox.Show("Seleccione el No. factura para continuar el procedimiento de detalle de cobro.", "Seleccione la Factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxFactura.Focus()
            Exit Sub
        ElseIf CbxNoPagare.Text = "" Then
            MessageBox.Show("Seleccione el No. del pagaré para continuar el procedimiento de detalle(s) de cobro.", "Seleccione el pagaré correspondiente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxNoPagare.Focus()
            Exit Sub
        ElseIf CDbl(txtMonto.Text) + CDbl(txtDescuento.Text) = 0 And CDbl(txtCargos.Text) = 0 Then
            MessageBox.Show("Los montos aplicados y los descuentos deben ser mayor a 0 para formar parte del detalle del recibo de cobro.", "Complete la información", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        ElseIf CbxTipoComision.Text = "" Then
            MessageBox.Show("Seleccione el tipo de comisión a pagar al cobrador " & txtCobradorC.Text & " sobre el recibo No. " & cbxNoRecibo.Text & ".", "Seleccione Tipo de Comisión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxTipoComision.Focus()
            Exit Sub
        End If

        CheckBcePagare()

        If lblExcedente.Text = 1 Then
            Exit Sub
        End If

        With DgvDetalleRecibos
            .Rows.Add(lblIDDetalle.Text, lblIDRecibo.Text, lblIDFactura.Text, lblIDPagare.Text, CbxNoPagare.Text, txtMonto.Text, txtDescuento.Text, CbxTipoComision.Text, lblIDTipoComision.Text, txtComision.Text,txtCargos.text )
        End With

        LimpiarDetalle()
        SumMontoRecibo()
        ResultadosEncontrados()

        CbxFactura.Focus()

    End Sub

    Private Sub LimpiarDetalle()
        CbxFactura.Items.Clear()
        FillCbxFacturas()
        lblIDFactura.Text = ""
        CbxNoPagare.Items.Clear()
        lblIDPagare.Text = ""
        txtMonto.Clear()
        txtDescuento.Clear()
        CbxTipoComision.Items.Clear()
        lblIDTipoComision.Text = ""
        txtComision.Clear()
        txtCargos.Clear()
        lblExcedente.Text = 0
        lblIDDetalle.Text = ""
    End Sub

    Private Sub LimpiarDetalleEntrega()
        cbxNoEntrega.Items.Clear()
        cbxNoRecibo.Items.Clear()
        txtNota.Clear()
        lblIDPagare.Text = ""
        lblIDRecibo.Text = ""
        lblIDFactura.Text = ""
        lblIDEntrega.Text = ""
        DtpFechaRecibo.Value = Now().AddDays(-1)
        cbxTipoRecibo.Items.Clear()
        txtMonto.Clear()
        FillCbxNoEntrega()
        CbxNoPagare.Items.Clear()
        FillCbxFacturas()
    End Sub

    Private Sub chkEntCasa_CheckedChanged(sender As Object, e As EventArgs)
        LimpiarDetalleEntrega()
    End Sub

    Private Sub SumMontoRecibo()
        Dim Monto As Double = 0
        For Each Rows As DataGridViewRow In DgvDetalleRecibos.Rows
            Monto = CDbl(Rows.Cells(5).Value) + CDbl(Rows.Cells(10).Value) + Monto
        Next
        txtMontoTotal.Text = Monto.ToString("C")
        Label45.Text = Monto.ToString("C")
    End Sub

    Private Sub UpdateComisionEntrega()
        Dim Comision, Debitos As New Label
        Con.Open()
        cmd = New MySqlCommand("Select coalesce(Sum(Comision),0) from RecibosDetalle INNER JOIN RecibosCobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro Where IDEntregaCobro='" + lblIDEntrega.Text + "' AND reciboscobro.Nulo=0", Con)
        Comision.Text = Convert.ToDouble(cmd.ExecuteScalar())
        cmd = New MySqlCommand("Select coalesce(Sum(Debito+Cargos),0) from RecibosDetalle INNER JOIN RecibosCobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro Where IDEntregaCobro='" + lblIDEntrega.Text + "' AND reciboscobro.Nulo=0", Con)
        Debitos.Text = Convert.ToDouble(cmd.ExecuteScalar())
        Con.Close()

        sqlQ = "UPDATE EntregaCobro SET Comision='" + Comision.Text + "',Monto='" + Debitos.Text + "' WHERE IDEntregaCobro='" + lblIDEntrega.Text + "'"
        GuardarDatos()

    End Sub

    Private Sub DesHabilitarControles()
        cbxNoEntrega.Enabled = False
        cbxNoRecibo.Enabled = False
        DtpFechaRecibo.Enabled = False
        cbxTipoRecibo.Enabled = False
        txtNota.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        cbxNoEntrega.Enabled = True
        cbxNoRecibo.Enabled = True
        DtpFechaRecibo.Enabled = True
        cbxTipoRecibo.Enabled = True
        txtNota.Enabled = True
    End Sub

    Private Sub CheckBcePagare()
        Dim IDPagValue As String = lblIDPagare.Text
        Dim x As Integer = 0
        Dim BcePag As Double = txtBalancePagare.Text
        Dim SumPag As Double = 0


        For Each Row As DataGridViewRow In DgvDetalleRecibos.Rows
            If lblIDPagare.Text = Row.Cells(3).Value Then
                SumPag = SumPag + CDbl(Row.Cells(5).Value) + CDbl(Row.Cells(6).Value)
            End If
        Next

        If Math.Round(CDbl(SumPag), 3) + Math.Round(CDbl(txtMonto.Text), 3) + Math.Round(CDbl(txtDescuento.Text), 3) > Math.Round(CDbl(BcePag), 3) Then
            MessageBox.Show("El total aplicado al pagaré excede su balance. Por favor verifique los datos a insertar y/o el ajuste realizado sobre el pagare." & vbNewLine & vbNewLine & "Monto del Pagaré: " & txtMontoPagare.Text & vbNewLine & "Ingresos y Descuentos Aplicados: " & SumPag.ToString("C") & vbNewLine & "Total Aplicable: " & (CDbl(txtMontoPagare.Text) - SumPag).ToString("C") & vbNewLine & "Ingresos y Descuentos a Insertar: " & (CDbl(txtMonto.Text) + CDbl(txtDescuento.Text)).ToString("C") & vbNewLine & "Excedente: " & (BcePag - SumPag - CDbl(txtMonto.Text) - CDbl(txtDescuento.Text)).ToString("C"), "Excede el balance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            lblExcedente.Text = 1
        Else
            lblExcedente.Text = 0
        End If

    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub InsertDetalleAuditoria()
        'Try
        Dim IDAuditoria As New Label

        txtMontoRecibos.Text = CDbl(txtMontoRecibos.Text)

        For Each row As DataGridViewRow In DgvAuditoria.Rows
            IDAuditoria.Text = CStr(row.Cells(0).Value)

            If IDAuditoria.Text = "" Then
                sqlQ = "INSERT INTO reciboscobroauditoria (IDRecibosCobro,IDAbono,Monto) VALUES ('" + lblIDRecibo.Text + "','" + row.Cells(1).Value.ToString + "','" + CDbl(row.Cells(4).Value).ToString + "')"
                GuardarDatos()

                ConMixta.Open()
                cmd = New MySqlCommand("SELECT IDRecibosCobroAuditoria from" & SysName.Text & "RecibosCobroAuditoria where IDRecibosCobroAuditoria= (Select Max(IDRecibosCobroAuditoria) from" & SysName.Text & "reciboscobroauditoria)", ConMixta)
                row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

            Else
                sqlQ = "UPDATE" & SysName.Text & "reciboscobroauditoria SET IDRecibosCobro='" + lblIDRecibo.Text + "',IDAbono='" + row.Cells(6).Value.ToString + "',Monto='" + CDbl(row.Cells(4).Value).ToString + "' WHERE IDRecibosCobroAuditoria='" + IDAuditoria.Text + "'"
                GuardarDatos()
            End If


        Next

        txtMontoRecibos.Text = CDbl(txtMontoRecibos.Text).ToString("C")
        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub InsertDetalleRecibo()
        'Try
        Dim IDDetalleRecibo, IDReciboCobro, IDFactura, IDPagare, NoPagare, Debito, Descuento, TipoComision, IDComision, Comision, Cargos As New Label

        For Each row As DataGridViewRow In DgvDetalleRecibos.Rows
            IDDetalleRecibo.Text = row.Cells(0).Value
            IDReciboCobro.Text = row.Cells(1).Value
            IDFactura.Text = row.Cells(2).Value
            IDPagare.Text = row.Cells(3).Value
            NoPagare.Text = row.Cells(4).Value
            Debito.Text = CDbl(row.Cells(5).Value)
            Descuento.Text = CDbl(row.Cells(6).Value)
            TipoComision.Text = row.Cells(7).Value
            IDComision.Text = row.Cells(8).Value
            Comision.Text = CDbl(row.Cells(9).Value)
            Cargos.Text = CDbl(row.Cells(10).Value)

            If IDDetalleRecibo.Text = "" Then
                CalcBceCerrado(IDPagare.Text)

                sqlQ = "INSERT INTO RecibosDetalle (IDReciboCobro,IDPagare,Debito,Descuento,IDComision,Comision,Cargos) VALUES ('" + IDReciboCobro.Text + "','" + IDPagare.Text + "','" + Debito.Text + "','" + Descuento.Text + "','" + IDComision.Text + "','" + Comision.Text + "','" + Cargos.Text + "')"
                GuardarDatos()

                ConMixta.Open()
                cmd = New MySqlCommand("SELECT IDDetalleRecibo from" & SysName.Text & "recibosdetalle where IDDetalleRecibo= (Select Max(IDDetalleRecibo) from" & SysName.Text & "recibosdetalle)", ConMixta)
                row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

            Else
                sqlQ = "UPDATE RecibosDetalle SET IDReciboCobro='" + IDReciboCobro.Text + "',IDPagare='" + IDPagare.Text + "',Debito='" + Debito.Text + "',Descuento='" + Descuento.Text + "',IDComision='" + IDComision.Text + "',Comision='" + Comision.Text + "',Cargos='" + Cargos.Text + "' WHERE IDDetalleRecibo='" + IDDetalleRecibo.Text + "'"
                GuardarDatos()
            End If
        Next

        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub UpdateRecibo()
        Try
            txtMontoTotal.Text = CDbl(txtMontoTotal.Text)
            sqlQ = "UPDATE RecibosCobro SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',Fecha='" + DtpFechaRecibo.Value.ToString("yyyy-MM-dd") + "',IDTipoRecibo='" + lblIDTipoRecibo.Text + "',Monto='" + txtMontoTotal.Text + "',Comentario='" + txtNota.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDReciboCobro= '" + lblIDRecibo.Text + "'"
            GuardarDatos()

            txtMontoTotal.Text = CDbl(txtMontoTotal.Text).ToString("C")
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ActualizarBcePagare()
        Try

            For Each row As DataGridViewRow In DgvDetalleRecibos.Rows
                CalcBcePagares(row.Cells(2).Value)
            Next

            'Dim x As Integer = 0
            'Dim IDPagare, Monto, Debitos, BceAct As New Label

            'Inicio:
            '            If x = DgvDetalleRecibos.Rows.Count Then
            '                GoTo Fin
            '            End If

            '            IDPagare.Text = DgvDetalleRecibos.Rows(x).Cells(3).Value

            '            Con.Open()
            '            cmd = New MySqlCommand("Select Monto from Pagares where IDPagare='" + IDPagare.Text + "'", Con)
            '            Monto.Text = Convert.ToDouble(cmd.ExecuteScalar())
            '            cmd = New MySqlCommand("Select Coalesce(Sum(Debito+Descuento),0) from RecibosDetalle INNER JOIN RecibosCobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro where IDPagare='" + IDPagare.Text + "' and Nulo=0", Con)
            '            Debitos.Text = Convert.ToDouble(cmd.ExecuteScalar())
            '            Con.Close()

            '            BceAct.Text = CDbl(Monto.Text) - CDbl(Debitos.Text)

            '            sqlQ = "UPDATE Pagares SET Balance='" + BceAct.Text + "' WHERE IDPagare= '" + IDPagare.Text + "'"
            '            GuardarDatos()

            '            x = x + 1
            '            GoTo Inicio
            'Fin:
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnQuitarArticulo_Click(sender As Object, e As EventArgs) Handles btnQuitarArticulo.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar el eliminado de detalle de recibos de cobro.", "Seleccionar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf DgvDetalleRecibos.Rows.Count = 0 Then
            MessageBox.Show("No hay registros para eliminar.", "No se encuentran registros", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim IDDetalle As String = DgvDetalleRecibos.CurrentRow.Cells(0).Value

        If IDDetalle = "" Then
            DgvDetalleRecibos.Rows.Remove(DgvDetalleRecibos.CurrentRow)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el registro No. " & IDDetalle & " como registro de detalle del Recibo No. " & cbxNoRecibo.Text & " del Cliente: " & txtNombre.Text & "?", "Eliminar Detalle de Cobro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "Delete from RecibosDetalle Where IDDetalleRecibo = (" + IDDetalle + ")"
                GuardarDatos()
                MessageBox.Show("El detalle de recibo de cobro ha sido eliminado satisfactoriamente.", "Se ha eliminado el recibo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DgvDetalleRecibos.Rows.Remove(DgvDetalleRecibos.CurrentRow)
                SumMontoRecibo()
                UpdateRecibo()
                ActualizarBcePagEspecifico()
                UpdateComisionEntrega()
            End If
        End If

        ResultadosEncontrados()


    End Sub

    Private Sub ActualizarBcePagEspecifico()
        Try
            Dim x As Integer = 0
            Dim y As Integer = 0
            Dim IDFactura, IDPagare, Monto, Debitos, BceAct As New Label

            Con.Open()
            Ds.Clear()
            cmd = New MySqlCommand("SELECT IDFacturaDatos FROM facturadatos where IDCliente='" + txtIDCliente.Text + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Facturadatos")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Facturadatos")
Inicio:
            If x = Tabla.Rows.Count Then
                GoTo Fin
            End If

            IDFactura.Text = (Tabla.Rows(x).Item("IDFacturaDatos"))

            Ds1.Clear()
            cmd = New MySqlCommand("SELECT IDPagare,Monto FROM Pagares where IDFactura='" + IDFactura.Text + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Pagares")
            Con.Close()

            Dim Tabla1 As DataTable = Ds1.Tables("Pagares")

Pagares:
            If y = Tabla1.Rows.Count Then
                x = x + 1
                y = 0
                GoTo Inicio
            End If

            IDPagare.Text = (Tabla1.Rows(y).Item("IDPagare"))
            Monto.Text = (Tabla1.Rows(y).Item("Monto"))

            Con.Open()
            cmd = New MySqlCommand("Select Coalesce(Sum(Debito+Descuento),0) from RecibosDetalle INNER JOIN RecibosCobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro where IDPagare='" + IDPagare.Text + "' and Nulo=0", Con)
            Debitos.Text = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()

            BceAct.Text = CDbl(Monto.Text) - CDbl(Debitos.Text)
            sqlQ = "UPDATE Pagares SET Balance='" + BceAct.Text + "' WHERE IDPagare= '" + IDPagare.Text + "'"
            GuardarDatos()

            y = y + 1
            GoTo Pagares
Fin:

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarCliente.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub BuscarCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarCompraToolStripMenuItem.Click
        btnBuscarHistorial.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub ImprimirDocumento()
        If cbxNoRecibo.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el registro del recibo?", "Imprimir Registro de Cobro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblNulo.Text = 1
            DesHabilitarControles()
        Else
            lblNulo.Text = 0
            HabilitarControles()
        End If
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Permisos(1) = 0 Then
            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar el detalle del pago.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf cbxNoEntrega.Text = "" Then
            MessageBox.Show("Seleccione el No. de Entrega correspondiente al detalle de cobro de la cuenta.", "Seleccione No. Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxNoEntrega.Focus()
            cbxNoEntrega.DroppedDown = True
            Exit Sub
        ElseIf cbxNoRecibo.Text = "" Then
            MessageBox.Show("Seleccione el No. del Recibo para continuar el procedimiento de detalle(s) de cobro.", "Seleccione la No. Recibo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxNoRecibo.Focus()
            cbxNoRecibo.DroppedDown = True
            Exit Sub
        ElseIf cbxTipoRecibo.Text = "" Then
            MessageBox.Show("Seleccione el tipo de recibo de cobro para especificar la naturaleza del pago.", "Seleccione Tipo de Recibo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxTipoRecibo.Focus()
            cbxTipoRecibo.DroppedDown = True
            Exit Sub
        ElseIf DgvDetalleRecibos.Rows.Count = 0 Then
            MessageBox.Show("Aún no se ha procesado el detalle del cobro. Por favor detalle los pagos a los pagares para continuar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        SumRCenAuditoria()
        If ControlSuperClave = 1 Then
            TabControl1.SelectedIndex = 3
            MessageBox.Show("El monto de los recibos no está cuadrado para realizar el cierre del recibo de cobros." & vbNewLine & vbNewLine & "Por favor seleccione los recibos correctos o verifique el origen del error", "Error no cuadrado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el abono a cuenta al cliente " & vbNewLine & "[" & txtIDCliente.Text & "] " & txtNombre.Text & "?" & vbNewLine & "Entrega No. " & cbxNoEntrega.Text & vbNewLine & "Recibo No. " & cbxNoRecibo.Text, "Proceso Detalles de Recibos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            UpdateRecibo()
            InsertDetalleRecibo()
            InsertDetalleAuditoria()
            ActualizarBcePagare()
            UpdateComisionEntrega()
            MessageBox.Show("El proceso ha finalizado exitosamente.", "Finalizado Satisfactoriamente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            DesHabilitarControles()
        End If
    End Sub

    Private Sub btnBuscarHistorial_Click(sender As Object, e As EventArgs) Handles btnBuscarHistorial.Click
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione un cliente para proceder a su historial de recibos de cobro.", "No se encontró cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            If txtIDCliente.Text <> "" Then
                frm_historial_recibos_cliente.ShowDialog(Me)
            End If
        Else
            frm_historial_recibos_cliente.ShowDialog(Me)
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs)
        ImprimirDocumento()
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar el detalle del pago.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf cbxNoEntrega.Text = "" Then
            MessageBox.Show("Seleccione el No. de Entrega correspondiente al detalle de cobro de la cuenta.", "Seleccione No. Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxNoEntrega.Focus()
            Exit Sub
        ElseIf cbxNoRecibo.Text = "" Then
            MessageBox.Show("Seleccione el No. del Recibo para continuar el procedimiento de detalle(s) de cobro.", "Seleccione la No. Recibo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxNoRecibo.Focus()
            Exit Sub
        ElseIf cbxTipoRecibo.Text = "" Then
            MessageBox.Show("Seleccione el tipo de recibo de cobro para especificar la naturaleza del pago.", "Seleccione Tipo de Recibo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxTipoRecibo.Focus()
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El recibo de cobro No. " & cbxNoRecibo.Text & " del cliente " & txtNombre.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Recibo de Cobro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                UpdateRecibo()
                InsertDetalleRecibo()
                ActualizarBcePagare()
                UpdateComisionEntrega()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf cbxNoRecibo.Text = "" Then
            MessageBox.Show("No hay un registro de recibo de cobro abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el recibo de cobro No. " & cbxNoRecibo.Text & " del cliente " & txtNombre.Text & " del sistema?", "Anular Recibo de Cobro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                UpdateRecibo()
                InsertDetalleRecibo()
                ActualizarBcePagare()
                UpdateComisionEntrega()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Sub VerificarCobrador()
        If cbxNoEntrega.Text <> "" And txtIDCliente.Text <> "" Then
            If lblIDCobradorEntrega.Text <> txtIDCobradorC.Text Then
                lblEstadoCobrador.Text = "ATENCIÓN! El cobrador de la entrega no es el cobrador asignado al cliente."
                lblEstadoCobrador.ForeColor = Color.Red
            Else
                lblEstadoCobrador.Text = ""
                lblEstadoCobrador.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub btnConsultarEntrega_Click(sender As Object, e As EventArgs) Handles btnConsultarEntrega.Click
        If cbxNoEntrega.Text = "" Or cbxNoEntrega.Text = "1" Then
        Else
            frm_consulta_directa_entrega_cobros.ShowDialog(Me)
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frm_recibos_cobro_entrega_casa.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub PicCliente_Click(sender As Object, e As EventArgs) Handles PicCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub SimilarFindButton_Click(sender As Object, e As EventArgs) Handles SimilarFindButton.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub


    Private Sub DgvRecibos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRecibos.CellClick
        If e.RowIndex >= 0 Then
            If DgvRecibos.Rows.Count > 0 Then
                cbxNoRecibo.Text = DgvRecibos.CurrentRow.Cells(1).Value & "-" & DgvRecibos.CurrentRow.Cells(2).Value
                If IsDate(DgvRecibos.CurrentRow.Cells(3).Value) Then
                    DtpFechaRecibo.Value = CDate(DgvRecibos.CurrentRow.Cells(3).Value)
                Else
                    DtpFechaRecibo.Value = Today.AddDays(-1)
                End If
                txtMonto.Text = DgvRecibos.CurrentRow.Cells(7).Value

                If IsDBNull(DgvRecibos.CurrentRow.Cells(5).Value) Then
                    DtpFechaRecibo.Focus()
                    SendKeys.Send("{F4}")
                    Dim buttonCentre As Point = New Point(DtpFechaRecibo.Width / 2, DtpFechaRecibo.Height / 2)
                    Dim P As Point = DtpFechaRecibo.PointToScreen(buttonCentre)
                    Cursor.Position = P
                Else
                    cbxTipoRecibo.Text = DgvRecibos.CurrentRow.Cells(5).Value
                End If

            End If
        End If
       
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TabControl1.SelectedIndex = 1
        If txtIDCliente.Text = "" Then
            btnBuscarCliente.PerformClick()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TabControl1.SelectedIndex = 2

        If CbxFactura.Items.Count > 0 Then
            CbxFactura.Focus()
            CbxFactura.DroppedDown = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TabControl1.SelectedIndex = 3

        If DgvAuditoria.Rows.Count = 0 Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub PicCliente_Paint(sender As Object, e As PaintEventArgs) Handles PicCliente.Paint
        Panel1.BackgroundImage = PicCliente.BackgroundImage
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If frm_consulta_recibos_ingresos.Visible = True Then
            frm_consulta_recibos_ingresos.Close()
        End If

        frm_consulta_recibos_ingresos.Show(Me)
        frm_consulta_recibos_ingresos.txtIDCliente.Text = txtIDCliente.Text
        frm_consulta_recibos_ingresos.txtCliente.Text = txtNombre.Text
        frm_consulta_recibos_ingresos.txtFechaInicial.Text = Today.AddMonths(-1).ToString("dd/MM/yyyy")
        frm_consulta_recibos_ingresos.btnBuscarCons.PerformClick()
    End Sub

    Private Sub txtCargos_TextChanged(sender As Object, e As EventArgs) Handles txtCargos.TextChanged
        If txtCargos.Text = "" Then
        Else
            If IsNumeric(CDbl(txtCargos.Text)) Then
                CalcComision()
            End If

        End If

    End Sub

    Sub SumRCenAuditoria()
        Dim Monto As Double = 0
        Dim MontosporAplicar As Double = 0
        For Each rw As DataGridViewRow In DgvAuditoria.Rows
            Monto = CDbl(rw.Cells(4).Value) + Monto
        Next

        txtMontoRecibos.Text = Monto.ToString("C")

        For Each Rx As DataGridViewRow In DgvDetalleRecibos.Rows
            MontosporAplicar = CDbl(Rx.Cells(5).Value) + CDbl(Rx.Cells(10).Value) + MontosporAplicar
        Next

        If MontosporAplicar <> Monto Then
            lblMensajeAuditor.Text = "El monto de los recibos no está cuadrado para realizar el cierre del recibo de cobros. Por favor seleccione los recibos correctos o verifique el origen del error."
            lblMensajeAuditor.ForeColor = Color.Red
            ControlSuperClave = 1
        Else
            lblMensajeAuditor.Text = "El monto de la auditoría está cuadrado satisfactoriamente."
            lblMensajeAuditor.ForeColor = SystemColors.Highlight
            ControlSuperClave = 0
        End If
    End Sub


    Private Sub txtIDCliente_TextChanged(sender As Object, e As EventArgs) Handles txtIDCliente.TextChanged
        If txtIDCliente.Text = "" Then
            CbxFactura.Enabled = False
        Else
            CbxFactura.Enabled = True
        End If
    End Sub


    Private Sub DgvDetalleRecibos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DgvDetalleRecibos.RowsAdded
        If DgvDetalleRecibos.Rows.Count = 0 Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub DgvRecibos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvRecibos.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvRecibos.ColumnCount
                Dim NumRows As Integer = DgvRecibos.RowCount
                Dim CurCell As DataGridViewCell = DgvRecibos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvRecibos.CurrentCell = DgvRecibos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvRecibos.CurrentCell = DgvRecibos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvRecibos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvRecibos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If DgvRecibos.Rows.Count > 0 Then
                cbxNoRecibo.Text = DgvRecibos.CurrentRow.Cells(1).Value & "-" & DgvRecibos.CurrentRow.Cells(2).Value
                If IsDate(DgvRecibos.CurrentRow.Cells(3).Value) Then
                    DtpFechaRecibo.Value = CDate(DgvRecibos.CurrentRow.Cells(3).Value)
                Else
                    DtpFechaRecibo.Value = Today.AddDays(-1)
                End If
                txtMonto.Text = DgvRecibos.CurrentRow.Cells(7).Value
                If IsDBNull(DgvRecibos.CurrentRow.Cells(5).Value) Then
                    DtpFechaRecibo.Focus()
                    SendKeys.Send("{F4}")
                Else
                    cbxTipoRecibo.Text = DgvRecibos.CurrentRow.Cells(5).Value
                End If

            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If DgvAuditoria.Rows.Count = 0 Then
        Else

            If DgvAuditoria.SelectedRows.Count = 0 Then
                MessageBox.Show("Seleccione el recibo auditado que desea eliminar del registro.", "No hay un registro seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            Dim IDAuditoria As String
            IDAuditoria = DgvAuditoria.CurrentRow.Cells(0).Value

            If IDAuditoria = "" Then
                DgvAuditoria.Rows.Remove(DgvAuditoria.CurrentRow)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el registro de recibo de ingreso anexado al recibo de cobro?", "Eliminar Recibo Auditado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    sqlQ = "Delete from reciboscobroauditoria Where idRecibosCobroAuditoria= (" + IDAuditoria + ")"
                    GuardarDatos()
                    MessageBox.Show("El recibo de ingreso auditado ha sido eliminado satisfactoriamente.", "Se ha eliminado el recibo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    DgvAuditoria.Rows.Remove(DgvAuditoria.CurrentRow)
                    SumMontoRecibo()
                    UpdateRecibo()
                    ActualizarBcePagEspecifico()
                    UpdateComisionEntrega()
                End If
            End If
        End If
    End Sub

    Private Sub lblAnular_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblAnular.LinkClicked
        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el recibo de cobro no. " & cbxNoRecibo.Text & "?", "Anulación de recibo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            Dim IDPagarex, CantDetalle As String
            sqlQ = "UPDATE RecibosCobro SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',Fecha='" + DtpFechaRecibo.Value.ToString("yyyy-MM-dd") + "',IDTipoRecibo='3',Monto=0,Comentario='Recibo anulado',Nulo='1' WHERE IDReciboCobro= '" + lblIDRecibo.Text + "'"
            GuardarDatos()

            Con.Open()
            cmd = New MySqlCommand("SELECT IDPagare from Libregco.RecibosDetalle where iddetallerecibo= (Select Max(iddetallerecibo) from Libregco.RecibosDetalle)", Con)
            IDPagarex = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT count(iddetallerecibo) from Libregco.RecibosDetalle where IDReciboCobro='" + lblIDRecibo.Text + "'", Con)
            CantDetalle = Convert.ToString(cmd.ExecuteScalar())

            Con.Close()

            If CantDetalle = 0 Then
                sqlQ = "INSERT INTO RecibosDetalle (IDReciboCobro,IDPagare,Debito,Descuento,IDComision,Comision) VALUES ('" + lblIDRecibo.Text + "','" + IDPagarex + "','0','0','3','0')"
                GuardarDatos()
                FillRecibos()
                DesHabilitarControles()
            End If
        
            MessageBox.Show("El recibo ha sido anulado satisfactoriamente.", "Recibo " & cbxNoRecibo.Text & " eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub


    Private Sub rdbCantidad_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCantidad.CheckedChanged
        GetChartInformation()
    End Sub

    Private Sub rdbPorcentaje_CheckedChanged(sender As Object, e As EventArgs)
        GetChartInformation()
    End Sub

    Private Sub rdbMonto_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMonto.CheckedChanged
        GetChartInformation()
    End Sub
End Class