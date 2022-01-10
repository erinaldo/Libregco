Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_historialpagos
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Dim DefaultCurrency As New Label

    Private Sub frm_historialpagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        SetDefaultColors()
        LimpiarTodo()
        ColumnsHistorial()
        CheckForms()
        ActualizarTodo()
        CargarMonedas()
    End Sub

    Private Sub CargarMonedas()
        'Cargar monedas
        Dim dstemp As New DataSet

        LueMoneda.Properties.Items.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM tipomoneda order by IDTipoMoneda ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "tipomoneda")
        ConLibregco.Close()

        For Each Fila As DataRow In dstemp.Tables("tipomoneda").Rows
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

            LueMoneda.Properties.Items.Add(nvmoneda)
        Next
        dstemp.Dispose()


        Con.Open()

        'Moneda predeterminada
        cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion Where IDConfiguracion=209", Con)
        DefaultCurrency.Text = CInt(Convert.ToString(cmd.ExecuteScalar()))
        Con.Close()

        LueMoneda.EditValue = CInt(DefaultCurrency.Text)

    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub SetDefaultColors()
        Con.Open()

        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=39", Con)
        ColorFactCredito.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=40", Con)
        ColorFactContado.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=41", Con)
        ColorAbonos.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=42", Con)
        ColorChequesDev.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=43", Con)
        ColorDevoluciones.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=44", Con)
        ColorNotaCredito.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=45", Con)
        ColorNotaDebito.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=46", Con)
        ColorCargos.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        Con.Close()
    End Sub

    Private Sub ActualizarTodo()
        'chkFacturaCredito.Checked = True
        'chkFacturaContado.Checked = True
        'chkAbono.Checked = True
        'chkCargos.Checked = True
        'chkNotaDebito.Checked = True
        'chkNotaCredito.Checked = True
        'chkChequesDev.Checked = True
        'chkDevoluciones.Checked = True
    End Sub

    Private Sub LimpiarTodo()
        txtIDCliente.Clear()
        txtNombreCliente.Clear()
    End Sub

    Private Sub CheckForms()
        If Me.Owner.Name = frm_recibo_pagos.Name Then
            If frm_recibo_pagos.txtIDCliente.Text <> "" Then
                txtIDCliente.Text = frm_recibo_pagos.txtIDCliente.Text
                txtNombreCliente.Text = frm_recibo_pagos.txtNombre.Text
            End If
        ElseIf Me.Owner.Name = frm_facturacion.Name Then
            If frm_facturacion.txtIDCliente.Text <> "" Then
                txtIDCliente.Text = frm_facturacion.txtIDCliente.Text
                txtNombreCliente.Text = frm_facturacion.txtNombre.Text
            End If
        ElseIf Me.Owner.Name = frm_mant_clientes.Name Then
            If frm_mant_clientes.txtIDCliente.Text <> "" Then
                txtIDCliente.Text = frm_mant_clientes.txtIDCliente.Text
                txtNombreCliente.Text = frm_mant_clientes.txtNombre.Text
            End If
        Else
            frm_buscar_clientes.ShowDialog(Me)
        End If
    End Sub
    Private Sub ColumnsHistorial()
        DgvHistorial.Columns.Clear()
        With DgvHistorial
            .Columns.Add("Tipo", "Tipo") '0
            .Columns.Add("NoDocumento", "No. Doc") '1
            .Columns.Add("Fecha", "Fecha") '2
            .Columns.Add("Concepto", "Concepto") '3
            .Columns.Add("Debito", "Débito")   '4
            .Columns.Add("Credito", "Crédito") '5
            .Columns.Add("Total", "Balance")  '6
        End With
        PropiedadColumnsDgv()
    End Sub

    Sub RefrescarTabla()
        'Try
        DgvHistorial.Rows.Clear()

        ConMixta.Open()

        If chkFacturaCredito.Checked = True Then
            '''''Facturas Credito
            Dim AnexoFacturasCredito As New MySqlCommand("SELECT SecondID,FacturaDatos.Fecha,FacturaDatos.Hora,Inicial,TotalNeto from" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion where FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and Condicion.Dias>0 and FacturaDatos.IDTipoDocumento=12 AND Transaccion.IDMoneda='" + LueMoneda.EditValue.ToString + "' and FacturaDatos.Nulo=0 UNION ALL SELECT FacturaDatos.SecondID,FacturaDatos.Fecha,FacturaDatos.Hora,Inicial,TotalNeto from" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion where IDCliente='" + txtIDCliente.Text + "' and Condicion.Dias>0 and FacturaDatos.IDTipoDocumento=2 AND Transaccion.IDMoneda='" + LueMoneda.EditValue.ToString + "'AND FacturaDatos.Nulo=0", ConMixta)
            Dim Lector1 As MySqlDataReader = AnexoFacturasCredito.ExecuteReader

            While Lector1.Read
                DgvHistorial.Rows.Add("+ Fact. Crédito", Lector1.GetValue(0), CDate(Lector1.GetValue(1)).ToString("yyyy-MM-dd") & " " & CDate(Convert.ToString(Lector1.GetValue(2))).ToString("hh:mm:ss tt"), " Facturación correspondiente al Doc. No: " & Lector1.GetValue(0), Lector1.GetValue(3), Lector1.GetValue(4), "")
            End While
            Lector1.Close()
        End If

        If chkFacturaContado.Checked = True Then
            '''''Facturas Contado
            Dim AnexoFacturasContado As New MySqlCommand("SELECT SecondID,FacturaDatos.Fecha,FacturaDatos.Hora,Inicial,TotalNeto from" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion where FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and Condicion.Dias=0 and FacturaDatos.IDTipoDocumento=12 AND Transaccion.IDMoneda='" + LueMoneda.EditValue.ToString + "' AND FacturaDatos.Nulo=0 UNION ALL SELECT FacturaDatos.SecondID,FacturaDatos.Fecha,FacturaDatos.Hora,Inicial,TotalNeto from" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion where IDCliente='" + txtIDCliente.Text + "' and Condicion.Dias=0 and FacturaDatos.IDTipoDocumento=1 AND Transaccion.IDMoneda='" + LueMoneda.EditValue.ToString + "' AND FacturaDatos.Nulo=0", ConMixta)
            Dim Lector6 As MySqlDataReader = AnexoFacturasContado.ExecuteReader

            While Lector6.Read
                DgvHistorial.Rows.Add("Fact. Contado", Lector6.GetValue(0), CDate(Lector6.GetValue(1)).ToString("yyyy-MM-dd") & " " & CDate(Convert.ToString(Lector6.GetValue(2))).ToString("hh:mm:ss tt"), " Facturación correspondiente al Doc. No: " & Lector6.GetValue(0), Lector6.GetValue(4), Lector6.GetValue(4), CDbl(0).ToString("C"))
            End While
            Lector6.Close()
        End If

        If chkAbono.Checked = True Then
            ''''''Abonos a facturas
            Dim AnexoAbonos As New MySqlCommand("SELECT SecondID,Abonos.Fecha,Abonos.Hora,Concepto,Total FROM" & SysName.Text & "Abonos INNER JOIN" & SysName.Text & "Transaccion on Abonos.IDTransaccion=Transaccion.IDTransaccion Where Abonos.IDCliente='" + txtIDCliente.Text + "' AND Transaccion.IDMoneda='" + LueMoneda.EditValue.ToString + "' and Nulo=0 ORDER BY IDAbono ASC", ConMixta)
            Dim Lector As MySqlDataReader = AnexoAbonos.ExecuteReader

            While Lector.Read
                DgvHistorial.Rows.Add("- Abono", Lector.GetValue(0), CDate(Lector.GetValue(1)).ToString("yyyy-MM-dd") & " " & CDate(Convert.ToString(Lector.GetValue(2))).ToString("hh:mm:ss tt"), Lector.GetValue(3), Lector.GetValue(4), CDbl(0).ToString("C"), "")
            End While
            Lector.Close()
        End If

        If chkChequesDev.Checked = True Then
            ''''Cheques Devueltos
            Dim AnexoChequesDevueltos As New MySqlCommand("SELECT FacturaDatos.SecondID,FacturaDatos.Fecha,FacturaDatos.Hora,Inicial,TotalNeto from" & SysName.Text & "FacturaDatos INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion where FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and FacturaDatos.IDTipoDocumento=17 AND Transaccion.IDMoneda='" + LueMoneda.EditValue.ToString + "' and FacturaDatos.Nulo=0 ORDER BY IDFacturaDatos ASC", ConMixta)
            Dim Lector2 As MySqlDataReader = AnexoChequesDevueltos.ExecuteReader

            While Lector2.Read
                DgvHistorial.Rows.Add("+ Cheque Dev.", Lector2.GetValue(0), CDate(Lector2.GetValue(1)).ToString("yyyy-MM-dd") & " " & CDate(Convert.ToString(Lector2.GetValue(2))).ToString("hh:mm:ss tt"), " Devolución de Cheque No. " & Lector2.GetValue(0), Lector2.GetValue(3), Lector2.GetValue(4), "")
            End While
            Lector2.Close()
        End If

        If chkDevoluciones.Checked = True Then
            '''''Devoluciones de Ventas
            Dim AnexoDevoluciones As New MySqlCommand("SELECT DevolucionVenta.SecondID,DevolucionVenta.Fecha,DevolucionVenta.Hora,DevolucionVenta.Devolver from" & SysName.Text & "DevolucionVenta INNER JOIN" & SysName.Text & "FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion where FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and DevolucionVenta.Nulo=0 and Condicion.Dias>0 and IDTipoDevolucion<>1 AND Transaccion.IDMoneda='" + LueMoneda.EditValue.ToString + "'", ConMixta)
            Dim Lector3 As MySqlDataReader = AnexoDevoluciones.ExecuteReader

            While Lector3.Read
                DgvHistorial.Rows.Add("- Devolución", Lector3.GetValue(0), CDate(Lector3.GetValue(1)).ToString("yyyy-MM-dd") & " " & CDate(Convert.ToString(Lector3.GetValue(2))).ToString("hh:mm:ss tt"), " Devolución de venta No. " & Lector3.GetValue(0), Lector3.GetValue(3), CDbl(0).ToString("C"), "")
            End While
            Lector3.Close()
        End If

        If chkNotaCredito.Checked = True Then
            '''''Notas de Crédito
            Dim AnexoNotaCred As New MySqlCommand("SELECT notadebitocredito.SecondID,notadebitocredito.Fecha,notadebitocredito.Hora,notadebitocredito.Concepto,Aplicado FROM" & SysName.Text & "notadebitocredito INNER JOIN Libregco.TipoNotaFactura on TipoNotaFactura.IDTipoNotaFactura=NotaDebitoCredito.IDTipoNota INNER JOIN" & SysName.Text & "notadebitocreditodetalle on NotaDebitoCredito.IDNotaDebCred=NotaDebitoCreditoDetalle.IDNotaDebitoCredito INNER JOIN" & SysName.Text & "FacturaDatos on NotaDebitoCreditoDetalle.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and IDTipoNota=2 and NotaDebitoCredito.Nulo=0 AND Transaccion.IDMoneda='" + LueMoneda.EditValue.ToString + "'", ConMixta)
            Dim Lector4 As MySqlDataReader = AnexoNotaCred.ExecuteReader

            While Lector4.Read
                DgvHistorial.Rows.Add(" - N.Crédito", Lector4.GetValue(0), CDate(Lector4.GetValue(1)).ToString("yyyy-MM-dd") & " " & CDate(Convert.ToString(Lector4.GetValue(2))).ToString("hh: mm:ss tt"), Lector4.GetValue(3), Lector4.GetValue(4), CDbl(0).ToString("C"), "")
            End While
            Lector4.Close()
        End If

        If chkNotaDebito.Checked = True Then
            '''''Notas de Débito
            Dim AnexoNotaDeb As New MySqlCommand("SELECT notadebitocredito.SecondID,notadebitocredito.Fecha,notadebitocredito.Hora,notadebitocredito.Concepto,Aplicado FROM" & SysName.Text & "notadebitocredito INNER JOIN Libregco.TipoNotaFactura on TipoNotaFactura.IDTipoNotaFactura=NotaDebitoCredito.IDTipoNota INNER JOIN" & SysName.Text & "notadebitocreditodetalle on NotaDebitoCredito.IDNotaDebCred=NotaDebitoCreditoDetalle.IDNotaDebitoCredito INNER JOIN" & SysName.Text & "FacturaDatos on NotaDebitoCreditoDetalle.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and IDTipoNota=1 and NotaDebitoCredito.Nulo=0 AND Transaccion.IDMoneda='" + LueMoneda.EditValue.ToString + "'", ConMixta)
            Dim Lector5 As MySqlDataReader = AnexoNotaDeb.ExecuteReader

            While Lector5.Read
                DgvHistorial.Rows.Add("+ N. Débito", Lector5.GetValue(0), CDate(Lector5.GetValue(1)).ToString("yyyy-MM-dd") & " " & CDate(Convert.ToString(Lector5.GetValue(2))).ToString("hh:mm:ss tt"), Lector5.GetValue(3), CDbl(0).ToString("C"), Lector5.GetValue(4), "")
            End While
            Lector5.Close()
        End If

        If chkCargos.Checked = True Then
            '''''Cargos a facturas
            Dim AnexoCargos As New MySqlCommand("SELECT IDCargosFactura,CargosFactura.Fecha,CargosFactura.Hora,IDFactura,FacturaDatos.SecondID,Monto,Cargosfactura.Descripcion FROM" & SysName.Text & "Cargosfactura INNER JOIN" & SysName.Text & "FacturaDatos on CargosFactura.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion where FacturaDatos.IDCliente='" + txtIDCliente.Text + "' AND Transaccion.IDMoneda='" + LueMoneda.EditValue.ToString + "' and CargosFactura.Nulo=0", ConMixta)
            Dim Lector7 As MySqlDataReader = AnexoCargos.ExecuteReader

            While Lector7.Read
                DgvHistorial.Rows.Add("+ Cargos", Lector7.GetValue(0), CDate(Lector7.GetValue(1)).ToString("yyyy-MM-dd") & " " & CDate(Convert.ToString(Lector7.GetValue(2))).ToString("hh:mm:ss tt"), Lector7.GetValue(6) & " en " & Lector7.GetValue(4), CDbl(0).ToString("C"), CDbl(Lector7.GetValue(5)).ToString("C"), "")
            End While
            Lector7.Close()

            '''''Descuento sobre cargos
            Dim AnexoExcentos As New MySqlCommand("SELECT Coalesce(Sum(CargosExcento),0) as CargosExonerados from" & SysName.Text & "DetalleAbonos INNER JOIN" & SysName.Text & "Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono INNER JOIN" & SysName.Text & "FacturaDatos on DetalleAbonos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where Abonos.Nulo=0 and FacturaDatos.IDCliente='" + txtIDCliente.Text + "' AND Transaccion.IDMoneda='" + LueMoneda.EditValue.ToString + "'", ConMixta)
            Dim SumCargos As Double = Convert.ToDouble(AnexoExcentos.ExecuteScalar())
            Dim Lector8 As MySqlDataReader = AnexoExcentos.ExecuteReader

            If SumCargos > 0 Then
                While Lector8.Read
                    DgvHistorial.Rows.Add("- Desc. Cargos", "", Today.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss"), "Descuento aplicados a cargos generados a la fecha.", CDbl(Lector8.GetValue(0)).ToString("C"), CDbl(0).ToString("C"), "")
                End While
                Lector8.Close()
            End If
        End If

        ConMixta.Close()

            DgvHistorial.Sort(DgvHistorial.Columns("Fecha"), System.ComponentModel.ListSortDirection.Ascending)
            CalcTotal()
            CambiarColorGrid()
            DgvHistorial.ClearSelection()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString)
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Sub CambiarColorGrid()

        For Each Row As DataGridViewRow In DgvHistorial.Rows
            If Row.Cells(0).Value = "+ Fact. Crédito" Then
                Row.DefaultCellStyle.BackColor = ColorFactCredito.BackColor
            ElseIf Row.Cells(0).Value = "Fact. Contado" Then
                Row.DefaultCellStyle.BackColor = ColorFactContado.BackColor
            ElseIf Row.Cells(0).Value = "+ Cargos" Then
                Row.DefaultCellStyle.BackColor = ColorCargos.BackColor
            ElseIf Row.Cells(0).Value = "- Abono" Then
                Row.DefaultCellStyle.BackColor = ColorAbonos.BackColor
            ElseIf Row.Cells(0).Value = "+ Cheque Dev." Then
                Row.DefaultCellStyle.BackColor = ColorChequesDev.BackColor
            ElseIf Row.Cells(0).Value = "- Devolución" Then
                Row.DefaultCellStyle.BackColor = ColorDevoluciones.BackColor
            ElseIf Row.Cells(0).Value = "- N. Crédito" Then
                Row.DefaultCellStyle.BackColor = ColorNotaCredito.BackColor
            ElseIf Row.Cells(0).Value = "+ N. Débito" Then
                Row.DefaultCellStyle.BackColor = ColorNotaDebito.BackColor
            End If
        Next
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvHistorial

            .Columns("Tipo").Width = 90
            .Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Tipo").SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns("NoDocumento").Width = 80
            .Columns("NoDocumento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("NoDocumento").SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns("Fecha").Width = 150
            .Columns("Fecha").DefaultCellStyle.Format = ("yyyy-MM-dd HH:mm:ss")
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns("Concepto").Width = 280
            .Columns("Concepto").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Concepto").DefaultCellStyle.WrapMode = DataGridViewTriState.True

            .Columns("Debito").Width = 100
            .Columns("Debito").DefaultCellStyle.Format = ("C")
            .Columns("Debito").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Debito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            .Columns("Credito").Width = 100
            .Columns("Credito").DefaultCellStyle.Format = ("C")
            .Columns("Credito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Credito").SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns("Total").Width = 110
            .Columns("Total").DefaultCellStyle.Format = ("C")
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Total").SortMode = DataGridViewColumnSortMode.NotSortable

        End With
    End Sub

    Private Sub DgvHistorial_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvHistorial.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvHistorial.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvHistorial.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvHistorial.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub CalcTotal()
        Dim Debito, Credito, Total As Double
        Dim x As Integer

        Total = 0

Inicio:
        If x = DgvHistorial.Rows.Count Then
            GoTo Fin
        End If
        
        Debito = CDbl(DgvHistorial.Rows(x).Cells(4).Value)
        Credito = CDbl(DgvHistorial.Rows(x).Cells(5).Value)


        Total = Total + Credito - Debito
        DgvHistorial.Rows(x).Cells(6).Value = Total

        x = x + 1
        GoTo Inicio
Fin:
    End Sub

    Private Sub frm_historialpagos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LimpiarTodo()
        DgvHistorial.Rows.Clear()
    End Sub

    Private Sub ColorFactCredito_Click(sender As Object, e As EventArgs) Handles ColorFactCredito.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorFactCredito.BackColor = CDialog.Color
            CambiarColorGrid()
        End If
    End Sub

    Private Sub ColorFactContado_Click(sender As Object, e As EventArgs) Handles ColorFactContado.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorFactContado.BackColor = CDialog.Color
            CambiarColorGrid()
        End If
    End Sub

    Private Sub ColorAbonos_Click(sender As Object, e As EventArgs) Handles ColorAbonos.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorAbonos.BackColor = CDialog.Color
            CambiarColorGrid()
        End If
    End Sub

    Private Sub ColorCargos_Click(sender As Object, e As EventArgs) Handles ColorCargos.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorCargos.BackColor = CDialog.Color
            CambiarColorGrid()
        End If
    End Sub

    Private Sub ColorNotaDebito_Click(sender As Object, e As EventArgs) Handles ColorNotaDebito.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorNotaDebito.BackColor = CDialog.Color
            CambiarColorGrid()
        End If
    End Sub

    Private Sub ColorNotaCredito_Click(sender As Object, e As EventArgs) Handles ColorNotaCredito.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorNotaCredito.BackColor = CDialog.Color
            CambiarColorGrid()
        End If
    End Sub

    Private Sub ColorChequesDev_Click(sender As Object, e As EventArgs) Handles ColorChequesDev.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorChequesDev.BackColor = CDialog.Color
            CambiarColorGrid()
        End If
    End Sub

    Private Sub ColorDevoluciones_Click(sender As Object, e As EventArgs) Handles ColorDevoluciones.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True


        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorDevoluciones.BackColor = CDialog.Color
            CambiarColorGrid()
        End If
    End Sub


    Private Sub LueMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LueMoneda.SelectedIndexChanged
        RefrescarTabla()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If frm_reporte_movimientos_clientes.Visible = True Then
            If frm_reporte_movimientos_clientes.WindowState = FormWindowState.Minimized Then
                frm_reporte_movimientos_clientes.WindowState = FormWindowState.Normal
            Else
                frm_reporte_movimientos_clientes.Activate()
            End If
        Else
            frm_reporte_movimientos_clientes.Show(Me)
        End If

        frm_reporte_movimientos_clientes.txtIDCliente.Text = txtIDCliente.Text
        frm_reporte_movimientos_clientes.txtCliente.Text = txtNombreCliente.Text
        frm_reporte_movimientos_clientes.FillEstadoCuenta()

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefrescarTabla()
    End Sub
End Class
