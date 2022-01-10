Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_pago_compras

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Incluir As New DataGridViewCheckBoxColumn
    Dim HeaderIncluir As New CheckBox
    Friend lblIDUsuario, lblNulo, lblTransferenciaReferencia, lblTransferenciaCuenta, lblTransferenciaBanco, lblChequeNumero, lblChequeFecha, lblChequeBanco, lblChequeCuenta As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_pago_compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
        ColumnasDgvCompras()
        AddHeaderCheckBox()
        SelectUsuario()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub ActualizarTodo()
        lblNulo.Text = 0
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        HeaderIncluir.Checked = False
        lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        txtEfectivo.Text = CDbl(0).ToString("C")
        txtCheque.Text = CDbl(0).ToString("C")
        txtTransferencia.Text = CDbl(0).ToString("C")
        txtImporte.Text = CDbl(0).ToString("C")
        txtDescRet.Text = CDbl(0).ToString("C")
        txtNeto.Text = CDbl(0).ToString("C")
        txtMontoAplicar.Text = CDbl(0).ToString("C")
    End Sub

    Private Sub HabilitarControles()
        btnBuscarSup.Enabled = True
        DgvCompras.Enabled = True
        txtConcepto.Enabled = True
        txtComentario.Enabled = True
        txtCheque.Enabled = True
        txtEfectivo.Enabled = True
        txtTransferencia.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        btnBuscarSup.Enabled = False
        DgvCompras.Enabled = False
        txtConcepto.Enabled = False
        txtComentario.Enabled = False
        txtCheque.Enabled = False
        txtEfectivo.Enabled = False
        txtTransferencia.Enabled = False
    End Sub

    Private Sub AddHeaderCheckBox()
        HeaderIncluir = New CheckBox()
        HeaderIncluir.Name = "HeaderIncluir"
        HeaderIncluir.Size = New Size(14, 14)
        HeaderIncluir.ThreeState = False
        HeaderIncluir.FlatStyle = FlatStyle.Standard
        DgvCompras.Controls.Add(HeaderIncluir)

        AddHandler HeaderIncluir.CheckedChanged, AddressOf HeaderIncluir_CheckedChanged
    End Sub

    Private Sub HeaderIncluir_CheckedChanged(sender As Object, e As EventArgs)
        Try
            If DgvCompras.Rows.Count > 0 Then
                Dim x As Integer = 0
                Dim CheckStatus As Boolean = DgvCompras.Rows(x).Cells(12).Value = True

                Dim HeaderBox As CheckBox = DirectCast(DgvCompras.Controls.Find("HeaderIncluir", True)(0), CheckBox)
                For Each Rows As DataGridViewRow In DgvCompras.Rows
                    Rows.Cells(12).Value = HeaderBox.Checked
                Next

                If HeaderIncluir.Checked = True Then
                    For Each Rows As DataGridViewRow In DgvCompras.Rows
                        Rows.Cells(11).Value = CDbl(CDbl(Rows.Cells(7).Value) - CDbl(DgvCompras.CurrentRow.Cells(10).Value) - CDbl(DgvCompras.CurrentRow.Cells(9).Value) - CDbl(DgvCompras.CurrentRow.Cells(8).Value)).ToString("C")
                        Rows.Cells(13).Value = CDbl(0).ToString("C")
                    Next
                Else
                    For Each Rows As DataGridViewRow In DgvCompras.Rows
                        Rows.Cells(11).Value = CDbl(0).ToString("C")
                        Rows.Cells(13).Value = CDbl(CDbl(Rows.Cells(7).Value) - CDbl(DgvCompras.CurrentRow.Cells(10).Value) - CDbl(DgvCompras.CurrentRow.Cells(9).Value) - CDbl(DgvCompras.CurrentRow.Cells(8).Value)).ToString("C")
                    Next
                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LimpiarDatos()
        HabilitarControles()
        txtIDSuplidor.Clear()
        txtSecondID.Clear()
        txtSuplidor.Clear()
        txtIDPago.Clear()
        txtBalanceSup.Clear()
        txtUltimoMonto.Clear()
        txtUltimoPago.Clear()
        DgvCompras.Rows.Clear()
        txtConcepto.Clear()
        txtComentario.Clear()
        lblTransferenciaReferencia.Text = ""
        lblTransferenciaCuenta.Text = ""
        lblTransferenciaBanco.Text = ""
        lblChequeBanco.Text = ""
        lblChequeNumero.Text = ""
        lblChequeFecha.Text = ""
        lblChequeCuenta.Text = ""
        txtImporte.Text = CDbl(0).ToString("C")
        txtDescRet.Text = CDbl(0).ToString("C")
        txtNeto.Text = CDbl(0).ToString("C")
        txtMontoAplicar.Text = CDbl(0).ToString("C")
        txtCheque.Text = CDbl(0).ToString("C")
        txtEfectivo.Text = CDbl(0).ToString("C")
        txtTransferencia.Text = CDbl(0).ToString("C")
        btnBuscarSup.Focus()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ColumnasDgvCompras()
        DgvCompras.Columns.Clear()
        With DgvCompras
            .Columns.Add("IDPagoCompraDetalle", "IDPagoDetalle") '0
            .Columns.Add("IDPagoCompra", "IDPagoCompra") '1
            .Columns.Add("IDCompra", "IDCompra")  '2
            .Columns.Add("NoFactura", "No. Factura")    '3
            .Columns.Add("FechaFactura", "Fecha")    '4
            .Columns.Add("Vence", "Vence")  '5
            .Columns.Add("Monto", "Monto")    '6
            .Columns.Add("Balance", "Balance")  '7
            .Columns.Add("RetISR", "Ret. ISR")   '8
            .Columns.Add("RetITBIS", "Ret. Itbis") '9
            .Columns.Add("Descuento", "Descuento")   '10
            .Columns.Add("Aplicar", "Aplicar")  '11
            .Columns.Add(Incluir)    '12
            .Columns.Add("BceFinal", "Bce. Final") '13
            .Columns.Add("NCF", "NCF") '14
            .Columns.Add("SecondID", "Código") '15
            .Columns.Add("Dias", "Días") '16
            .Columns.Add("Estado", "Estado")
        End With
        PropiedadesDgvCompras()
    End Sub

    Private Sub PropiedadesDgvCompras()
        Try
            Dim DatagridWidth As Double = (DgvCompras.Width - DgvCompras.RowHeadersWidth) / 100

            With DgvCompras
                .Columns("IDPagoCompraDetalle").Visible = False
                .Columns("IDPagoCompra").Visible = False
                .Columns("IDCompra").Visible = False

                .Columns("NoFactura").Width = DatagridWidth * 12
                .Columns("NoFactura").ReadOnly = True

                .Columns("FechaFactura").Width = DatagridWidth * 8
                .Columns("FechaFactura").ReadOnly = True
                .Columns("FechaFactura").Visible = False

                .Columns("Vence").Width = DatagridWidth * 8
                .Columns("Vence").ReadOnly = True
                .Columns("Vence").Visible = True

                .Columns("Monto").Width = DatagridWidth * 12
                .Columns("Monto").DefaultCellStyle.Format = ("C")
                .Columns("Monto").ReadOnly = True

                .Columns("Balance").DefaultCellStyle.Format = ("C")
                .Columns("Balance").Width = DatagridWidth * 10
                .Columns("Balance").ReadOnly = True

                .Columns("RetISR").DefaultCellStyle.Format = ("C")

                If ChkVisualISR.Checked = True Then
                    .Columns("RetISR").Width = DatagridWidth * 10
                    .Columns("RetISR").Visible = True
                Else
                    .Columns("RetISR").Visible = False
                    .Columns("Monto").Width = DatagridWidth * 12.5
                    .Columns("Balance").Width = DatagridWidth * 12.5
                End If

                .Columns("RetITBIS").DefaultCellStyle.Format = ("C")

                If chkVisualItbis.Checked = True Then
                    .Columns("RetITBIS").Visible = True
                    .Columns("RetITBIS").Width = DatagridWidth * 10
                Else
                    .Columns("RetITBIS").Visible = False
                    .Columns("Descuento").Width = DatagridWidth * 15
                    .Columns("Aplicar").Width = DatagridWidth * 17
                End If

                .Columns("Descuento").DefaultCellStyle.Format = ("C")
                .Columns("Descuento").Width = DatagridWidth * 10

                .Columns("Aplicar").DefaultCellStyle.Format = ("C")
                .Columns("Aplicar").Width = DatagridWidth * 12
                .Columns("Aplicar").DefaultCellStyle.BackColor = Color.Beige

                .Columns("BceFinal").DefaultCellStyle.Format = ("C")
                .Columns("BceFinal").ReadOnly = True
                .Columns("BceFinal").Width = DatagridWidth * 12
                .Columns("BceFinal").DefaultCellStyle.BackColor = Color.Gray
                .Columns("BceFinal").DefaultCellStyle.ForeColor = Color.White

                .Columns("NCF").ReadOnly = True

                If chkNcf.Checked = True Then
                    .Columns("NCF").Width = DatagridWidth * 15
                    .Columns("NCF").Visible = True
                Else
                    .Columns("NCF").Visible = False
                End If

                .Columns("SecondID").Width = DatagridWidth * 12
                .Columns("SecondID").DisplayIndex = 0
                .Columns("SecondID").ReadOnly = True
                .Columns("SecondID").DefaultCellStyle.BackColor = SystemColors.Info
                .Columns("SecondID").DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)

                .Columns("Dias").Width = DatagridWidth * 6
                .Columns("Dias").HeaderText = "Días"
                .Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Dias").DisplayIndex = 7
                .Columns("Dias").ReadOnly = True

                .Columns("Estado").ReadOnly = True
                .Columns("Estado").Width = 300
                .Columns("Estado").DefaultCellStyle.WrapMode = DataGridViewTriState.True

            End With


            With Incluir
                .HeaderText = ""
                .Name = "Incluir"
                .Width = DatagridWidth * 4
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .FlatStyle = FlatStyle.Standard
                .DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
            End With

            'For Each Column As DataGridViewColumn In DgvCompras.Columns
            '    Column.SortMode = DataGridViewColumnSortMode.NotSortable
            'Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgvCompras_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvCompras.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvCompras.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvCompras.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvCompras.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnBuscarSup_Click(sender As Object, e As EventArgs) Handles btnBuscarSup.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Sub RefrescarComprasPendientes()
        'Try
        DgvCompras.Rows.Clear()
            ConMixta.Open()
        Dim Da As New MySqlCommand("SELECT IDCompra,NoFactura,FechaFactura,FechaVencimiento,TotalNeto,Balance,NCF,SecondID,if(Compras.FechaFactura<Now(),DATEDIFF(now(),Compras.FechaFactura),0) as DiasVencidos from" & SysName.Text & "Compras INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion where IDSuplidor='" + txtIDSuplidor.Text + "' and Balance>0  and Condicion.Dias>0 and Compras.Nulo=0", ConMixta)
        Dim LectorCompra As MySqlDataReader = Da.ExecuteReader

            While LectorCompra.Read
                DgvCompras.Rows.Add("", "", LectorCompra.GetValue(0), LectorCompra.GetValue(1), CDate(LectorCompra.GetValue(2)).ToString("dd/MM/yyyy"), CDate(LectorCompra.GetValue(3)).ToString("dd/MM/yyyy"), LectorCompra.GetValue(4), LectorCompra.GetValue(5), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), False, CDbl(0).ToString("C"), LectorCompra.GetValue(6), LectorCompra.GetValue(7), LectorCompra.GetValue(8))
                ''''''''''''''''''''''''''''''''IDCompra                 NoFactura                     FechaFactura                      FechaVencimiento                      TotalNeto                                Balance   
            End While
            LectorCompra.Close()
            ConMixta.Close()

            For Each Rows As DataGridViewRow In DgvCompras.Rows
                Rows.Cells(13).Value = CDbl(Rows.Cells(7).Value).ToString("C")
            Next

            BuscarAfecciones()

        'Catch ex As Exception
        'End Try

    End Sub

    Sub BuscarAfecciones()
        Try
            ConMixta.Open()

            For Each row As DataGridViewRow In DgvCompras.Rows

                'Determinar estado
                If CDate(row.Cells(5).Value) < Today Then
                    row.Cells(17).Value = "Factura vencida. "
                Else
                    row.Cells(17).Value = "Factura no vencida. "
                End If

                'Determinar si tiene cheques programados
                cmd = New MySqlCommand("SELECT Coalesce(Sum(SolicitudChequesDetalle.Monto+SolicitudChequesDetalle.Descuento),0) FROM" & SysName.Text & "solicitudchequesdetalle inner join" & SysName.Text & "solicitudcheques on solicitudchequesdetalle.IDSolicitudCheque=SolicitudCheques.IDSolicitudCHeque where IDCompra='" + row.Cells(2).Value.ToString + "' and SolicitudCheques.Estado=0 and SolicitudCheques.Nulo=0", ConMixta)
                If Convert.ToDouble(cmd.ExecuteScalar) > 0 Then
                    row.Cells(7).Style.ForeColor = Color.Green
                    row.Cells(17).Value = row.Cells(17).Value & "La factura tiene pagos programados por solicitud de cheques."
                End If
            Next

            DgvCompras.ClearSelection()
            ConMixta.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub ActualizarDeseleccion()
        txtConcepto.Clear()
    End Sub

    Private Sub ConceptoTransaccion()
        Try
            Dim Abono, Saldo As New ArrayList
            Dim TextosAbono, TextosSaldos, Espacio As String
            Dim TotalFila As Double = 0

            For Each row As DataGridViewRow In DgvCompras.Rows
                TotalFila = CDbl(row.Cells(8).Value) + CDbl(row.Cells(9).Value) + CDbl(row.Cells(10).Value) + CDbl(row.Cells(11).Value)

                If TotalFila > 0 Then
                    If TotalFila < CDbl(row.Cells(7).Value) Then
                        Abono.Add(CStr(row.Cells(15).Value))
                    Else
                        Saldo.Add(CStr(row.Cells(15).Value))
                    End If
                End If
            Next

            '----------------------------------------------------------------------------------------------

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

            txtConcepto.Text = TextosAbono & Espacio & TextosSaldos
            txtConcepto.Text = txtConcepto.Text.Substring(0, 255)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LimpiarDescRet()
        DgvCompras.CurrentRow.Cells(8).Value = CDbl(0).ToString("C")
        DgvCompras.CurrentRow.Cells(9).Value = CDbl(0).ToString("C")
        DgvCompras.CurrentRow.Cells(10).Value = CDbl(0).ToString("C")
    End Sub

    Private Sub DgvCompras_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvCompras.CurrentCellDirtyStateChanged
        If DgvCompras.IsCurrentCellDirty Then
            DgvCompras.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub ConjuntoSuma()
        SumarMontoAplicar()
        SumarDescuentosyRetenes()
        SumNeto()
    End Sub

    Private Sub SumarDescuentosyRetenes()
        Try
            Dim Counter = DgvCompras.Rows.Count
            Dim x As Integer = 0
            Dim Descuentos As Double = 0
            Dim RetISR As Double = 0
            Dim RetITBIS As Double = 0

Inicio:
            If x = Counter Then
                GoTo Fin
            End If

            RetISR = RetISR + CDbl(DgvCompras.Rows(x).Cells(8).Value)
            RetITBIS = RetITBIS + CDbl(DgvCompras.Rows(x).Cells(9).Value)
            Descuentos = Descuentos + CDbl(DgvCompras.Rows(x).Cells(10).Value)

            x = x + 1
            GoTo Inicio
Fin:
            txtDescRet.Text = CDbl(RetISR + RetITBIS + Descuentos).ToString("C")

        Catch ex As Exception
            '  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SumarMontoAplicar()
        Try
            Dim Counter = DgvCompras.Rows.Count
            Dim x As Integer = 0
            Dim MontoAplicar As Double = 0
            txtMontoAplicar.Clear()

Inicio:
            If x = Counter Then
                GoTo Fin
            End If

            MontoAplicar = MontoAplicar + CDbl(DgvCompras.Rows(x).Cells(11).Value)
            x = x + 1
            GoTo Inicio
Fin:

            txtMontoAplicar.Text = MontoAplicar.ToString("C")
            txtImporte.Text = MontoAplicar.ToString("C")
        Catch ex As Exception
            '  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SumNeto()
        txtNeto.Text = CDbl(CDbl(txtImporte.Text) + CDbl(txtDescRet.Text)).ToString("C")
    End Sub

    Private Sub CompararEntradas()
        Dim AplicadoValue As Double = 0
        For Each Rows As DataGridViewRow In DgvCompras.Rows
            AplicadoValue = AplicadoValue + CDbl(Rows.Cells(11).Value)
        Next

        If txtMontoAplicar.Text = "" Then
            txtMontoAplicar.Text = AplicadoValue.ToString("C")
        ElseIf AplicadoValue <> CDbl(txtMontoAplicar.Text) Then
            txtMontoAplicar.Text = AplicadoValue.ToString("C")
        End If
    End Sub

    Private Sub DgvCompras_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCompras.CellValueChanged
        Try

            If e.ColumnIndex = 11 Then
                If CDbl(DgvCompras.CurrentRow.Cells(11).Value) + CDbl(DgvCompras.CurrentRow.Cells(10).Value) + CDbl(DgvCompras.CurrentRow.Cells(9).Value) + CDbl(DgvCompras.CurrentRow.Cells(8).Value) > CDbl(DgvCompras.CurrentRow.Cells(7).Value) Then
                    MessageBox.Show("El monto aplicado excede el balance de la factura. Verifique los descuentos y retenciones.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    DgvCompras.CurrentRow.Cells(11).Value = CDbl(0).ToString("C")
                Else
                    DgvCompras.CurrentRow.Cells(11).Value = CDbl(DgvCompras.CurrentRow.Cells(11).Value).ToString("C")
                End If
                DgvCompras.CurrentRow.Cells(13).Value = CDbl(DgvCompras.CurrentRow.Cells(7).Value) - CDbl(DgvCompras.CurrentRow.Cells(11).Value) - CDbl(DgvCompras.CurrentRow.Cells(10).Value) - CDbl(DgvCompras.CurrentRow.Cells(9).Value) - CDbl(DgvCompras.CurrentRow.Cells(8).Value)
                CompararEntradas()
            End If
        Catch ex As Exception
            DgvCompras.CurrentRow.Cells(11).Value = CDbl(0).ToString("C")
        End Try

        Try
            If e.ColumnIndex = 8 Then
                If CDbl(DgvCompras.CurrentRow.Cells(11).Value) + CDbl(DgvCompras.CurrentRow.Cells(10).Value) + CDbl(DgvCompras.CurrentRow.Cells(9).Value) + CDbl(DgvCompras.CurrentRow.Cells(8).Value) > CDbl(DgvCompras.CurrentRow.Cells(7).Value) Then
                    MessageBox.Show("El monto aplicado excede el balance de la factura. Verifique los descuentos y retenciones.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    DgvCompras.CurrentRow.Cells(8).Value = CDbl(0).ToString("C")
                Else
                    DgvCompras.CurrentRow.Cells(8).Value = CDbl(DgvCompras.CurrentRow.Cells(8).Value).ToString("C")
                End If
                DgvCompras.CurrentRow.Cells(13).Value = CDbl(DgvCompras.CurrentRow.Cells(7).Value) - CDbl(DgvCompras.CurrentRow.Cells(11).Value) - CDbl(DgvCompras.CurrentRow.Cells(10).Value) - CDbl(DgvCompras.CurrentRow.Cells(9).Value) - CDbl(DgvCompras.CurrentRow.Cells(8).Value)
            End If
        Catch ex As Exception
            DgvCompras.CurrentRow.Cells(8).Value = CDbl(0).ToString("C")
        End Try

        Try
            If e.ColumnIndex = 9 Then
                If CDbl(DgvCompras.CurrentRow.Cells(11).Value) + CDbl(DgvCompras.CurrentRow.Cells(10).Value) + CDbl(DgvCompras.CurrentRow.Cells(9).Value) + CDbl(DgvCompras.CurrentRow.Cells(8).Value) > CDbl(DgvCompras.CurrentRow.Cells(7).Value) Then
                    MessageBox.Show("El monto aplicado excede el balance de la factura. Verifique los descuentos y retenciones.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    DgvCompras.CurrentRow.Cells(9).Value = CDbl(0).ToString("C")
                Else
                    DgvCompras.CurrentRow.Cells(9).Value = CDbl(DgvCompras.CurrentRow.Cells(9).Value).ToString("C")
                End If
                DgvCompras.CurrentRow.Cells(13).Value = CDbl(DgvCompras.CurrentRow.Cells(7).Value) - CDbl(DgvCompras.CurrentRow.Cells(11).Value) - CDbl(DgvCompras.CurrentRow.Cells(10).Value) - CDbl(DgvCompras.CurrentRow.Cells(9).Value) - CDbl(DgvCompras.CurrentRow.Cells(8).Value)
            End If
        Catch ex As Exception
            DgvCompras.CurrentRow.Cells(9).Value = CDbl(0).ToString("C")
        End Try

        Try
            If e.ColumnIndex = 10 Then
                If CDbl(DgvCompras.CurrentRow.Cells(11).Value) + CDbl(DgvCompras.CurrentRow.Cells(10).Value) + CDbl(DgvCompras.CurrentRow.Cells(9).Value) + CDbl(DgvCompras.CurrentRow.Cells(8).Value) > CDbl(DgvCompras.CurrentRow.Cells(7).Value) Then
                    MessageBox.Show("El monto aplicado excede el balance de la factura. Verifique los descuentos y retenciones.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    DgvCompras.CurrentRow.Cells(10).Value = CDbl(0).ToString("C")
                Else
                    DgvCompras.CurrentRow.Cells(10).Value = CDbl(DgvCompras.CurrentRow.Cells(10).Value).ToString("C")
                End If
                DgvCompras.CurrentRow.Cells(13).Value = CDbl(DgvCompras.CurrentRow.Cells(7).Value) - CDbl(DgvCompras.CurrentRow.Cells(11).Value) - CDbl(DgvCompras.CurrentRow.Cells(10).Value) - CDbl(DgvCompras.CurrentRow.Cells(9).Value) - CDbl(DgvCompras.CurrentRow.Cells(8).Value)
            End If
        Catch ex As Exception
            DgvCompras.CurrentRow.Cells(8).Value = CDbl(0).ToString("C")
        End Try

        Try
            If e.ColumnIndex = 12 Then
                Dim IsTicked As Boolean = CBool(DgvCompras.CurrentRow.Cells(12).Value)
                If IsTicked Then
                    DgvCompras.CurrentRow.Cells(11).Value = CDbl(CDbl(DgvCompras.CurrentRow.Cells(7).Value) - CDbl(DgvCompras.CurrentRow.Cells(8).Value) - CDbl(DgvCompras.CurrentRow.Cells(9).Value) - CDbl(DgvCompras.CurrentRow.Cells(10).Value).ToString("C"))
                    DgvCompras.CurrentRow.Cells(13).Value = CDbl(CDbl(DgvCompras.CurrentRow.Cells(7).Value) - CDbl(DgvCompras.CurrentRow.Cells(8).Value) - CDbl(DgvCompras.CurrentRow.Cells(9).Value) - CDbl(DgvCompras.CurrentRow.Cells(10).Value) - CDbl(DgvCompras.CurrentRow.Cells(11).Value).ToString("C"))
                Else
                    DgvCompras.CurrentRow.Cells(11).Value = CDbl(0).ToString("C")
                    DgvCompras.CurrentRow.Cells(13).Value = CDbl(CDbl(DgvCompras.CurrentRow.Cells(7).Value) - CDbl(DgvCompras.CurrentRow.Cells(8).Value) - CDbl(DgvCompras.CurrentRow.Cells(9).Value) - CDbl(DgvCompras.CurrentRow.Cells(10).Value).ToString("C"))
                End If
            End If

        Catch ex As Exception
        End Try
        ConjuntoSuma()
        ConceptoTransaccion()
    End Sub

    Private Sub AplicadoenCero()
        If CDbl(DgvCompras.CurrentRow.Cells(11).Value) = 0 Then
            DgvCompras.CurrentRow.Cells(12).Value = 0
        Else
            DgvCompras.CurrentRow.Cells(12).Value = 1
        End If
    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = DgvCompras.CurrentCell.ColumnIndex

        If Columna = 8 Or Columna = 9 Or Columna = 10 Or Columna = 11 Then
            Dim Caracter As Char = e.KeyChar
            Dim Txt As TextBox = CType(sender, TextBox)

            If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") And (Txt.Text.Contains(",") = False) Then

                e.Handled = False
            Else
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub DgvCompras_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvCompras.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)

        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub DgvCompras_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCompras.CellClick

        DgvCompras.EditMode = DataGridViewEditMode.EditOnEnter

    End Sub

    Private Sub lblCheque_Click(sender As Object, e As EventArgs) Handles lblCheque.Click
        txtCheque.Text = txtMontoAplicar.Text
        txtEfectivo.Text = CDbl(0).ToString("C")
        txtTransferencia.Text = CDbl(0).ToString("C")
        txtCheque.Focus()
    End Sub

    Private Sub lblEfectivo_Click(sender As Object, e As EventArgs) Handles lblEfectivo.Click
        txtEfectivo.Text = txtMontoAplicar.Text
        txtCheque.Text = CDbl(0).ToString("C")
        txtTransferencia.Text = CDbl(0).ToString("C")
        txtEfectivo.Focus()
    End Sub

    Private Sub lblTransferencia_Click(sender As Object, e As EventArgs) Handles lblTransferencia.Click
        txtTransferencia.Text = txtMontoAplicar.Text
        txtEfectivo.Text = CDbl(0).ToString("C")
        txtCheque.Text = CDbl(0).ToString("C")
        txtTransferencia.Focus()
    End Sub

    Private Sub txtCheque_Enter(sender As Object, e As EventArgs) Handles txtCheque.Enter
        If txtCheque.Text = "" Then
        Else
            txtCheque.Text = CDbl(txtCheque.Text)
        End If
    End Sub

    Private Sub txtEfectivo_Enter(sender As Object, e As EventArgs) Handles txtEfectivo.Enter
        If txtEfectivo.Text = "" Then
        Else
            txtEfectivo.Text = CDbl(txtEfectivo.Text)
        End If
    End Sub

    Private Sub txtTransferencia_Enter(sender As Object, e As EventArgs) Handles txtTransferencia.Enter
        If txtTransferencia.Text = "" Then
        Else
            txtTransferencia.Text = CDbl(txtTransferencia.Text)
        End If
    End Sub

    Private Sub txtCheque_Leave(sender As Object, e As EventArgs) Handles txtCheque.Leave
        Try

            If txtCheque.Text = "" Then
                txtCheque.Text = CDbl(0).ToString("C")
            Else
                txtCheque.Text = CDbl(txtCheque.Text).ToString("C")
            End If

            If CDbl(txtMontoAplicar.Text) >= 0 Then
                If CDbl(txtEfectivo.Text) + CDbl(txtCheque.Text) + CDbl(txtTransferencia.Text) > CDbl(txtMontoAplicar.Text) Then
                    txtCheque.Text = CDbl(CDbl(txtMontoAplicar.Text) - CDbl(txtEfectivo.Text) - CDbl(txtTransferencia.Text)).ToString("C")
                End If
            Else
                txtCheque.Text = CDbl(0).ToString("C")
            End If

        Catch ex As Exception
            txtCheque.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtEfectivo_Leave(sender As Object, e As EventArgs) Handles txtEfectivo.Leave
        Try

            If txtEfectivo.Text = "" Then
                txtEfectivo.Text = CDbl(0).ToString("C")
            Else
                txtEfectivo.Text = CDbl(txtEfectivo.Text).ToString("C")
            End If

            If CDbl(txtMontoAplicar.Text) >= 0 Then
                If CDbl(txtEfectivo.Text) + CDbl(txtCheque.Text) + CDbl(txtTransferencia.Text) > CDbl(txtMontoAplicar.Text) Then
                    txtEfectivo.Text = CDbl(CDbl(txtMontoAplicar.Text) - CDbl(txtCheque.Text) - CDbl(txtTransferencia.Text)).ToString("C")
                End If
            Else
                txtEfectivo.Text = CDbl(0).ToString("C")
            End If

        Catch ex As Exception
            txtEfectivo.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtTransferencia_Leave(sender As Object, e As EventArgs) Handles txtTransferencia.Leave
        Try

            If txtTransferencia.Text = "" Then
                txtTransferencia.Text = CDbl(0).ToString("C")
            Else
                txtTransferencia.Text = CDbl(txtTransferencia.Text).ToString("C")
            End If

            If CDbl(txtMontoAplicar.Text) >= 0 Then
                If CDbl(txtEfectivo.Text) + CDbl(txtCheque.Text) + CDbl(txtTransferencia.Text) > CDbl(txtMontoAplicar.Text) Then
                    txtTransferencia.Text = CDbl(CDbl(txtMontoAplicar.Text) - CDbl(txtEfectivo.Text) - CDbl(txtCheque.Text)).ToString("C")
                End If
            Else
                txtTransferencia.Text = CDbl(0).ToString("C")
            End If

        Catch ex As Exception
            txtTransferencia.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub ConvertDouble()
        txtBalanceSup.Text = CDbl(txtBalanceSup.Text)
        txtMontoAplicar.Text = CDbl(txtMontoAplicar.Text)
        txtCheque.Text = CDbl(txtCheque.Text)
        txtEfectivo.Text = CDbl(txtEfectivo.Text)
        txtTransferencia.Text = CDbl(txtTransferencia.Text)
        txtImporte.Text = CDbl(txtImporte.Text)
        txtDescRet.Text = CDbl(txtDescRet.Text)
        txtNeto.Text = CDbl(txtNeto.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtBalanceSup.Text = CDbl(txtBalanceSup.Text).ToString("C")
        txtMontoAplicar.Text = CDbl(txtMontoAplicar.Text).ToString("C")
        txtCheque.Text = CDbl(txtCheque.Text).ToString("C")
        txtEfectivo.Text = CDbl(txtEfectivo.Text).ToString("C")
        txtTransferencia.Text = CDbl(txtTransferencia.Text).ToString("C")
        txtImporte.Text = CDbl(txtImporte.Text).ToString("C")
        txtDescRet.Text = CDbl(txtDescRet.Text).ToString("C")
        txtNeto.Text = CDbl(txtNeto.Text).ToString("C")
    End Sub

    Private Sub GuardarDatos()
        Try
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
                cmd = New MySqlCommand("Select IDPagoCompra from PagoCompra where IDPagoCompra= (Select Max(IDPagoCompra) from PagoCompra)", Con)
                txtIDPago.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "UltPago")
        End Try
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDPago.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el recibo de pago de la factura?", "Imprimir Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub CalcBces()
        FunctCalcBcesFactSuplidor(txtIDSuplidor.Text)
        FunctCalcBceSuplidor(txtIDSuplidor.Text)
    End Sub

    Private Sub InsertDetallePago()
        Try
            Dim IDPagoCompraDetalle, IDPagoCompra As New Label
            Dim Sumatoria As Double

        Con.Open()

        For Each rw As DataGridViewRow In DgvCompras.Rows

            IDPagoCompraDetalle.Text = rw.Cells(0).Value
            IDPagoCompra.Text = rw.Cells(1).Value
            'IDCompra.Text = rw.Cells(2).Value
            'BceAnterior.Text = CDbl(rw.Cells(7).Value)
            'RetISR.Text = CDbl(rw.Cells(8).Value)
            'RetITBIS.Text = CDbl(rw.Cells(9).Value)
            'Descuento.Text = CDbl(rw.Cells(10).Value)
            'Aplicado.Text = CDbl(rw.Cells(11).Value)

            Sumatoria = CDbl(rw.Cells(8).Value) + CDbl(rw.Cells(9).Value) + CDbl(rw.Cells(10).Value) + CDbl(rw.Cells(11).Value)

            If IDPagoCompraDetalle.Text = "" Then
                If Sumatoria = 0 Then
                Else
                    sqlQ = "INSERT INTO PagoComprasDetalle (IDPagoCompra,IDCompra,BceAnterior,RetISR,RetITBIS,Descuento,Aplicado) VALUES ('" + txtIDPago.Text + "','" + rw.Cells(2).Value.ToString + "','" + CDbl(rw.Cells(7).Value).ToString + "','" + CDbl(rw.Cells(8).Value).ToString + "','" + CDbl(rw.Cells(9).Value).ToString + "','" + CDbl(rw.Cells(10).Value).ToString + "','" + CDbl(rw.Cells(11).Value).ToString + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()

                    cmd = New MySqlCommand("Select IDPagoComprasDetalle from pagocomprasdetalle where IDPagoComprasDetalle= (Select Max(IDPagoComprasDetalle) from pagocomprasdetalle)", Con)
                    rw.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                    rw.Cells(1).Value = txtIDPago.Text
                End If

            Else
                If Sumatoria = 0 Then
                    sqlQ = "Delete From PagoComprasDetalle Where IDPagoComprasDetalle='" + IDPagoCompraDetalle.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                Else
                    sqlQ = "UPDATE PagoComprasDetalle SET IDPagoCompra='" + IDPagoCompra.Text + "',IDCompra='" + rw.Cells(2).Value.ToString + "',BceAnterior='" + CDbl(rw.Cells(7).Value).ToString + "',RetISR='" + CDbl(rw.Cells(8).Value).ToString + "',RetItbis='" + CDbl(rw.Cells(9).Value).ToString + "',Descuento='" + CDbl(rw.Cells(10).Value).ToString + "',Aplicado='" + CDbl(rw.Cells(11).Value).ToString + "' Where IDPagoComprasDetalle='" + IDPagoCompraDetalle.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            End If

        Next

        Con.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub RefrescarPagoCompra()
        Try
            Con.Open()
            DgvCompras.Rows.Clear()
            Dim Da As New MySqlCommand("SELECT IDPagoComprasDetalle,IDPagoCompra,PagoComprasDetalle.IDCompra,Compras.NoFactura,Compras.FechaFactura,Compras.FechaVencimiento,Compras.TotalNeto,PagoComprasDetalle.BceAnterior,RetISR,RetItbis,PagoComprasDetalle.Descuento,Aplicado,NCF,Compras.SecondID FROM pagocomprasdetalle INNER JOIN Compras on PagoComprasDetalle.IDCompra=Compras.IDCompra where IDPagoCompra='" + txtIDPago.Text + "'", Con)
            Dim LectorPago As MySqlDataReader = Da.ExecuteReader

            While LectorPago.Read
                DgvCompras.Rows.Add(LectorPago.GetValue(0), LectorPago.GetValue(1), LectorPago.GetValue(2), LectorPago.GetValue(3), CDate(LectorPago.GetValue(4)).ToString("dd/MM/yyyy"), CDate(LectorPago.GetValue(5)).ToString("dd/MM/yyyy"), LectorPago.GetValue(6), LectorPago.GetValue(7), LectorPago.GetValue(8), LectorPago.GetValue(9), LectorPago.GetValue(10), LectorPago.GetValue(11), False, CDbl(CDbl(LectorPago.GetValue(7)) - CDbl(LectorPago.GetValue(11))).ToString("C"), LectorPago.GetValue(12), LectorPago.GetValue(13))
            End While

            LectorPago.Close()
            Con.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub txtCheque_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCheque.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtTransferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTransferencia.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = False Then
            lblNulo.Text = 0
        Else
            lblNulo.Text = 1
        End If
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarSup.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub BuscarCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarCompraToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub DgvCompras_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvCompras.CellPainting
        If e.RowIndex = -1 AndAlso e.ColumnIndex = 12 Then
            ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=20", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE PagoCompra SET SecondID='" + lblSecondID.Text + "' WHERE IDPagoCompra='" + txtIDPago.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=20"
            GuardarDatos()

        Catch ex As Exception

      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor para procesar el pago.", "Seleccionar Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSup.PerformClick()
            Exit Sub
        ElseIf DgvCompras.Rows.Count = 0 Then
            MessageBox.Show("No existen cuentas por pagar pendientes de este suplidor.", "No hay cuentas por pagar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtMontoAplicar.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("No se ha aplicado montos de pago en facturas. Por favor aplique el monto a pagar.", "Aplicar Monto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtEfectivo.Text = CDbl(0).ToString("C") And txtCheque.Text = CDbl(0).ToString("C") And txtTransferencia.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Seleccione el método de pago al suplidor.", "Seleccionar tipo de pago", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCheque.Focus()
            Exit Sub
        ElseIf CDbl(txtMontoAplicar.Text) <> (CDbl(txtCheque.Text) + CDbl(txtEfectivo.Text) + CDbl(txtTransferencia.Text)) Then
            MessageBox.Show("Los montos aplicados y la distribución de pagos no coincide.", "Verificar distribución de pagos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCheque.Focus()
            Exit Sub
        End If

        If txtIDPago.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo de pago al suplidor: " & txtSuplidor.Text & " [ " & txtIDSuplidor.Text & " ] en la base de datos?", "Guardar Nuevo Recibo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                For Each Row As DataGridViewRow In DgvCompras.Rows
                    If CDbl(Row.Cells(10).Value) + CDbl(Row.Cells(11).Value) > 0 Then
                        ConMixta.Open()
                        cmd = New MySqlCommand("SELECT Coalesce(Sum(SolicitudChequesDetalle.Monto+SolicitudChequesDetalle.Descuento),0) FROM" & SysName.Text & "solicitudchequesdetalle inner join" & SysName.Text & "solicitudcheques on solicitudchequesdetalle.IDSolicitudCheque=SolicitudCheques.IDSolicitudCHeque where IDCompra='" + Row.Cells(2).Value.ToString + "' and SolicitudCheques.Estado=0 and SolicitudCheques.Nulo=0", ConMixta)
                        If (CDbl(Row.Cells(10).Value) + CDbl(Row.Cells(11).Value) + CDbl(Convert.ToDouble(cmd.ExecuteScalar))) > CDbl(Row.Cells(7).Value) Then
                            MessageBox.Show("No se puede realizar el pago a la factura No. " & Row.Cells(15).Value & " ya que se encuentra una solicitud de cheques sin procesar que excede el balance pendiente." & vbNewLine & vbNewLine & "Por favor revise las transacciones correspondientes en el módulo de solicitud de cheques.", "Exceso en pago por solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            ConMixta.Close()
                            Exit Sub
                        End If
                        ConMixta.Close()
                    End If
                Next

                If CDbl(txtCheque.Text) > 0 And CDbl(txtEfectivo.Text) = 0 And CDbl(txtTransferencia.Text) = 0 Then
                    ControlSuperClave = 0
                    frm_cheques.ShowDialog(Me)
                    If ControlSuperClave = 0 Then
                        Exit Sub
                    End If
                End If

                If CDbl(txtTransferencia.Text) > 0 And CDbl(txtEfectivo.Text) = 0 And CDbl(txtCheque.Text) = 0 Then
                    ControlSuperClave = 0
                    frm_movimientos_bancarios.ShowDialog(Me)
                    If ControlSuperClave = 0 Then
                        Exit Sub
                    End If
                End If

                If CDbl(txtTransferencia.Text) > 0 And CDbl(txtCheque.Text) > 0 Then
                    ControlSuperClave = 0
                    frm_forma_pago_cxp.ShowDialog(Me)
                    If ControlSuperClave = 0 Then
                        Exit Sub
                    End If
                End If

                ConvertDouble()
                sqlQ = "INSERT INTO PagoCompra (IDTipoDocumento,Fecha,Hora,IDUsuario,IDSucursal,IDAlmacen,IDSuplidor,BceAnterior,MontoAplicado,Cheque,Efectivo,Transferencia,Importe,Retencion,Neto,Concepto,Comentario,TransferenciaReferencia,TransferenciaCuenta,TransferenciaBanco,ChequeNumero,ChequeFecha,ChequeBanco,ChequeCuenta,Nulo) VALUES (20,CURDATE(),CURTIME(), '" + lblIDUsuario.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + txtIDSuplidor.Text + "','" + txtBalanceSup.Text + "','" + txtMontoAplicar.Text + "','" + txtCheque.Text + "','" + txtEfectivo.Text + "','" + txtTransferencia.Text + "','" + txtImporte.Text + "','" + txtDescRet.Text + "','" + txtNeto.Text + "','" + txtConcepto.Text + "','" + txtComentario.Text + "','" + lblTransferenciaReferencia.Text + "','" + lblTransferenciaCuenta.Text + "','" + lblTransferenciaBanco.Text + "','" + lblChequeNumero.Text + "','" + lblChequeFecha.Text + "','" + lblChequeBanco.Text + "','" + lblChequeCuenta.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltPago()
                SetSecondID()
                InsertDetallePago()
                CalcBces()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then



                For Each Row As DataGridViewRow In DgvCompras.Rows
                    If CDbl(Row.Cells(10).Value) + CDbl(Row.Cells(11).Value) > 0 Then
                        ConMixta.Open()
                        cmd = New MySqlCommand("SELECT Coalesce(Sum(SolicitudChequesDetalle.Monto+SolicitudChequesDetalle.Descuento),0) FROM" & SysName.Text & "solicitudchequesdetalle inner join" & SysName.Text & "solicitudcheques on solicitudchequesdetalle.IDSolicitudCheque=SolicitudCheques.IDSolicitudCHeque where IDCompra='" + Row.Cells(2).Value.ToString + "' and SolicitudCheques.Estado=0 and SolicitudCheques.Nulo=0", ConMixta)
                        If (CDbl(Row.Cells(10).Value) + CDbl(Row.Cells(11).Value) + CDbl(Convert.ToDouble(cmd.ExecuteScalar))) > CDbl(Row.Cells(7).Value) Then
                            MessageBox.Show("No se puede realizar el pago a la factura No. " & Row.Cells(15).Value & " ya que se encuentra una solicitud de cheques sin procesar que excede el balance pendiente." & vbNewLine & vbNewLine & "Por favor revise las transacciones correspondientes en el módulo de solicitud de cheques.", "Exceso en pago por solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            ConMixta.Close()
                            Exit Sub
                        Else
                            ConMixta.Close()
                        End If
                    End If
                Next

                ConvertDouble()
                sqlQ = "UPDATE PagoCompra SET IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',MontoAplicado='" + txtMontoAplicar.Text + "',Cheque='" + txtCheque.Text + "',Efectivo='" + txtEfectivo.Text + "',Transferencia='" + txtTransferencia.Text + "',Importe='" + txtImporte.Text + "',Retencion='" + txtDescRet.Text + "',Neto='" + txtNeto.Text + "',Concepto='" + txtConcepto.Text + "',Comentario='" + txtComentario.Text + "',TransferenciaReferencia='" + lblTransferenciaReferencia.Text + "',TransferenciaCuenta='" + lblTransferenciaCuenta.Text + "',TransferenciaBanco='" + lblTransferenciaBanco.Text + "',ChequeNumero='" + lblChequeNumero.Text + "',ChequeFecha='" + lblChequeFecha.Text + "',ChequeBanco='" + lblChequeBanco.Text + "',ChequeCuenta='" + lblChequeCuenta.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDPagoCompra= (" + txtIDPago.Text + ")"
                GuardarDatos()
                InsertDetallePago()
                CalcBces()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor para procesar el pago.", "Seleccionar Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSup.PerformClick()
            Exit Sub
        ElseIf DgvCompras.Rows.Count = 0 Then
            MessageBox.Show("No existen cuentas por pagar pendientes de este suplidor.", "No hay cuentas por pagar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtMontoAplicar.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("No se ha aplicado montos de pago en facturas. Por favor aplique el monto a pagar.", "Aplicar Monto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtEfectivo.Text = CDbl(0).ToString("C") And txtCheque.Text = CDbl(0).ToString("C") And txtTransferencia.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Seleccione el método de pago al suplidor.", "Seleccionar tipo de pago", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCheque.Focus()
            Exit Sub
        ElseIf CDbl(txtMontoAplicar.Text) <> (CDbl(txtCheque.Text) + CDbl(txtEfectivo.Text) + CDbl(txtTransferencia.Text)) Then
            MessageBox.Show("Los montos aplicados y la distribución de pagos no coincide.", "Verificar distribución de pagos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCheque.Focus()
            Exit Sub
        End If

        If txtIDPago.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo de pago al suplidor: " & txtSuplidor.Text & " [ " & txtIDSuplidor.Text & " ] en la base de datos?", "Guardar Nuevo Recibo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                For Each Row As DataGridViewRow In DgvCompras.Rows
                    If CDbl(Row.Cells(10).Value) + CDbl(Row.Cells(11).Value) > 0 Then
                        ConMixta.Open()
                        cmd = New MySqlCommand("SELECT Coalesce(Sum(SolicitudChequesDetalle.Monto+SolicitudChequesDetalle.Descuento),0) FROM" & SysName.Text & "solicitudchequesdetalle inner join" & SysName.Text & "solicitudcheques on solicitudchequesdetalle.IDSolicitudCheque=SolicitudCheques.IDSolicitudCHeque where IDCompra='" + Row.Cells(2).Value.ToString + "' and SolicitudCheques.Estado=0 and SolicitudCheques.Nulo=0", ConMixta)
                        If (CDbl(Row.Cells(10).Value) + CDbl(Row.Cells(11).Value) + CDbl(Convert.ToDouble(cmd.ExecuteScalar))) > CDbl(Row.Cells(7).Value) Then
                            MessageBox.Show("No se puede realizar el pago a la factura No. " & Row.Cells(15).Value & " ya que se encuentra una solicitud de cheques sin procesar que excede el balance pendiente." & vbNewLine & vbNewLine & "Por favor revise las transacciones correspondientes en el módulo de solicitud de cheques.", "Exceso en pago por solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            ConMixta.Close()
                            Exit Sub
                        End If
                        ConMixta.Close()
                    End If
                Next

                If CDbl(txtCheque.Text) > 0 And CDbl(txtEfectivo.Text) = 0 And CDbl(txtTransferencia.Text) = 0 Then
                    ControlSuperClave = 0
                    frm_cheques.ShowDialog(Me)
                    If ControlSuperClave = 0 Then
                        Exit Sub
                    End If
                End If

                If CDbl(txtTransferencia.Text) > 0 And CDbl(txtEfectivo.Text) = 0 And CDbl(txtCheque.Text) = 0 Then
                    ControlSuperClave = 0
                    frm_movimientos_bancarios.ShowDialog(Me)
                    If ControlSuperClave = 0 Then
                        Exit Sub
                    End If
                End If

                If CDbl(txtTransferencia.Text) > 0 And CDbl(txtCheque.Text) > 0 Then
                    ControlSuperClave = 0
                    frm_forma_pago_cxp.ShowDialog(Me)
                    If ControlSuperClave = 0 Then
                        Exit Sub
                    End If
                End If

                ConvertDouble()
                sqlQ = "INSERT INTO PagoCompra (IDTipoDocumento,Fecha,Hora,IDUsuario,IDSucursal,IDAlmacen,IDSuplidor,BceAnterior,MontoAplicado,Cheque,Efectivo,Transferencia,Importe,Retencion,Neto,Concepto,Comentario,TransferenciaReferencia,TransferenciaCuenta,TransferenciaBanco,ChequeNumero,ChequeFecha,ChequeBanco,ChequeCuenta,Nulo) VALUES (20,'" + txtFecha.Text + "','" + txtHora.Text + "', '" + lblIDUsuario.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + txtIDSuplidor.Text + "','" + txtBalanceSup.Text + "','" + txtMontoAplicar.Text + "','" + txtCheque.Text + "','" + txtEfectivo.Text + "','" + txtTransferencia.Text + "','" + txtImporte.Text + "','" + txtDescRet.Text + "','" + txtNeto.Text + "','" + txtConcepto.Text + "','" + txtComentario.Text + "','" + lblTransferenciaReferencia.Text + "','" + lblTransferenciaCuenta.Text + "','" + lblTransferenciaBanco.Text + "','" + lblChequeNumero.Text + "','" + lblChequeFecha.Text + "','" + lblChequeBanco.Text + "','" + lblChequeCuenta.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltPago()
                SetSecondID()
                InsertDetallePago()
                CalcBces()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                For Each Row As DataGridViewRow In DgvCompras.Rows
                    If CDbl(Row.Cells(10).Value) + CDbl(Row.Cells(11).Value) > 0 Then
                        ConMixta.Open()
                        cmd = New MySqlCommand("SELECT Coalesce(Sum(SolicitudChequesDetalle.Monto+SolicitudChequesDetalle.Descuento),0) FROM" & SysName.Text & "solicitudchequesdetalle inner join" & SysName.Text & "solicitudcheques on solicitudchequesdetalle.IDSolicitudCheque=SolicitudCheques.IDSolicitudCHeque where IDCompra='" + Row.Cells(2).Value.ToString + "' and SolicitudCheques.Estado=0 and SolicitudCheques.Nulo=0", ConMixta)
                        If (CDbl(Row.Cells(10).Value) + CDbl(Row.Cells(11).Value) + CDbl(Convert.ToDouble(cmd.ExecuteScalar))) > CDbl(Row.Cells(7).Value) Then
                            MessageBox.Show("No se puede realizar el pago a la factura No. " & Row.Cells(15).Value & " ya que se encuentra una solicitud de cheques sin procesar que excede el balance pendiente." & vbNewLine & vbNewLine & "Por favor revise las transacciones correspondientes en el módulo de solicitud de cheques.", "Exceso en pago por solicitud", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            ConMixta.Close()
                            Exit Sub
                        Else
                            ConMixta.Close()
                        End If
                    End If
                Next

                ConvertDouble()
                sqlQ = "UPDATE PagoCompra SET IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',MontoAplicado='" + txtMontoAplicar.Text + "',Cheque='" + txtCheque.Text + "',Efectivo='" + txtEfectivo.Text + "',Transferencia='" + txtTransferencia.Text + "',Importe='" + txtImporte.Text + "',Retencion='" + txtDescRet.Text + "',Neto='" + txtNeto.Text + "',Concepto='" + txtConcepto.Text + "',Comentario='" + txtComentario.Text + "',TransferenciaReferencia='" + lblTransferenciaReferencia.Text + "',TransferenciaCuenta='" + lblTransferenciaCuenta.Text + "',TransferenciaBanco='" + lblTransferenciaBanco.Text + "',ChequeNumero='" + lblChequeNumero.Text + "',ChequeFecha='" + lblChequeFecha.Text + "',ChequeBanco='" + lblChequeBanco.Text + "',ChequeCuenta='" + lblChequeCuenta.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDPagoCompra= (" + txtIDPago.Text + ")"
                GuardarDatos()
                InsertDetallePago()
                CalcBces()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione un suplidor para visualizar el historial de las facturas.", "Seleccione un Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            frm_buscar_suplidor.ShowDialog(Me)

            If txtIDSuplidor.Text = "" Then
            Else
                frm_historial_suplidor.ShowDialog(Me)
            End If

        Else
            frm_historial_suplidor.ShowDialog(Me)
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click

        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El pago No. " & txtIDPago.Text & " del suplidor " & txtSuplidor.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 91
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE PagoCompra SET IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',MontoAplicado='" + txtMontoAplicar.Text + "',Cheque='" + txtCheque.Text + "',Efectivo='" + txtEfectivo.Text + "',Transferencia='" + txtTransferencia.Text + "',Importe='" + txtImporte.Text + "',Retencion='" + txtDescRet.Text + "',Neto='" + txtNeto.Text + "',Concepto='" + txtConcepto.Text + "',Comentario='" + txtComentario.Text + "',TransferenciaReferencia='" + lblTransferenciaReferencia.Text + "',TransferenciaCuenta='" + lblTransferenciaCuenta.Text + "',TransferenciaBanco='" + lblTransferenciaBanco.Text + "',ChequeNumero='" + lblChequeNumero.Text + "',ChequeFecha='" + lblChequeFecha.Text + "',ChequeBanco='" + lblChequeBanco.Text + "',ChequeCuenta='" + lblChequeCuenta.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDPagoCompra= (" + txtIDPago.Text + ")"
                GuardarDatos()
                CalcBces()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDPago.Text = "" Then
            MessageBox.Show("No hay un registro de pago de factura abierto para desactivar", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el pago no. " & txtIDPago.Text & " al suplidor " & txtSuplidor.Text & " del sistema?", "Anular pago a factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 92
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE PagoCompra SET IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',MontoAplicado='" + txtMontoAplicar.Text + "',Cheque='" + txtCheque.Text + "',Efectivo='" + txtEfectivo.Text + "',Transferencia='" + txtTransferencia.Text + "',Importe='" + txtImporte.Text + "',Retencion='" + txtDescRet.Text + "',Neto='" + txtNeto.Text + "',Concepto='" + txtConcepto.Text + "',Comentario='" + txtComentario.Text + "',TransferenciaReferencia='" + lblTransferenciaReferencia.Text + "',TransferenciaCuenta='" + lblTransferenciaCuenta.Text + "',TransferenciaBanco='" + lblTransferenciaBanco.Text + "',ChequeNumero='" + lblChequeNumero.Text + "',ChequeFecha='" + lblChequeFecha.Text + "',ChequeBanco='" + lblChequeBanco.Text + "',ChequeCuenta='" + lblChequeCuenta.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDPagoCompra= (" + txtIDPago.Text + ")"
                GuardarDatos()
                CalcBces()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub ResetHeaderCheckBoxLocation(ByVal ColumnIndex As Integer, ByVal RowIndex As Integer)
        Dim Rect As Rectangle = DgvCompras.GetCellDisplayRectangle(ColumnIndex, RowIndex, True)
        Dim Pt As New Point()
        Pt.X = Rect.Location.X + (Rect.Width - HeaderIncluir.Width) \ 2 + 1
        Pt.Y = Rect.Location.Y + (Rect.Height - HeaderIncluir.Height) \ 2 + 1
        HeaderIncluir.Location = Pt
    End Sub

    Private Sub DgvCompras_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCompras.CellEndEdit
        DgvCompras.CommitEdit(DataGridViewDataErrorContexts.Commit)

    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub frm_pago_compras_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadesDgvCompras()
    End Sub

    Private Sub chkNcf_CheckedChanged(sender As Object, e As EventArgs) Handles chkNcf.CheckedChanged
        PropiedadesDgvCompras()
    End Sub

    Private Sub chkVisualItbis_CheckedChanged(sender As Object, e As EventArgs) Handles chkVisualItbis.CheckedChanged
        PropiedadesDgvCompras()
    End Sub

    Private Sub ChkVisualISR_CheckedChanged(sender As Object, e As EventArgs) Handles ChkVisualISR.CheckedChanged
        PropiedadesDgvCompras()
    End Sub

    Private Sub DgvCompras_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCompras.CellDoubleClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 15 Then
                frm_previsualizacion_compra.Text = "Visualización de Compra No. " & CStr(DgvCompras.CurrentRow.Cells(3).Value)
                frm_previsualizacion_compra.Show(Me)

                ConMixta.Open()
                cmd = New MySqlCommand("SELECT Coalesce(Sum(SolicitudChequesDetalle.Monto+SolicitudChequesDetalle.Descuento),0) FROM" & SysName.Text & "solicitudchequesdetalle inner join" & SysName.Text & "solicitudcheques on solicitudchequesdetalle.IDSolicitudCheque=SolicitudCheques.IDSolicitudCHeque where IDCompra='" + DgvCompras.CurrentRow.Cells(2).Value.ToString + "' and SolicitudCheques.Estado=0 and SolicitudCheques.Nulo=0", ConMixta)
                Dim Solicit As Double = Convert.ToDouble(cmd.ExecuteScalar)
                ConMixta.Close()


                If Solicit > 0 Then
                    frm_visual_solicitudes_cheques_compra.Show(Me)
                End If
            End If
        End If
    End Sub
End Class