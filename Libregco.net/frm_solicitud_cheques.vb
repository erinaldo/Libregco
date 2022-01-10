Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_solicitud_cheques

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Incluir As New DataGridViewCheckBoxColumn
    Dim HeaderIncluir As New CheckBox
    Friend lblIDUsuario, lblNulo, lblIDCuenta, Tipo, lblEstado As New Label
    Dim Permisos As New ArrayList


    Private Sub frm_solicitud_cheques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub FillCuenta()
        Try


            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT NoCuenta FROM CuentasBancarias WHERE Cheques=1 and Nulo=0 ORDER BY IDCuenta ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "CuentasBancarias")
            cbxCuenta.Items.Clear()
            cbxCuentaE.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("CuentasBancarias")

            For Each Fila As DataRow In Tabla.Rows
                cbxCuenta.Items.Add(Fila.Item("NoCuenta"))
                cbxCuentaE.Items.Add(Fila.Item("NoCuenta"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub SetIDCuenta()
        Try
            If txtIDSolicitud.Text = "" Then
                If Tipo.Text = 0 Then
                    Ds1.Clear()
                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT IDCuenta,Titular,Balance,Bancos.Identidad,ChequeActual FROM" & SysName.Text & "CuentasBancarias INNER JOIN Libregco.Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco WHERE CuentasBancarias.Cheques=1 and CuentasBancarias.Nulo=0 and NoCuenta='" + cbxCuenta.Text + "'", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds1, "CuentasBancarias")
                    ConMixta.Close()

                    Dim Tabla As DataTable = Ds1.Tables("CuentasBancarias")

                    lblIDCuenta.Text = (Tabla.Rows(0).Item("IDCuenta"))
                    txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))
                    txtNoChequeC.Text = CDbl(Tabla.Rows(0).Item("ChequeActual")) + 1

                    If IsNumeric(Tabla.Rows(0).Item("Balance")) Then
                        txtBalance.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
                    End If
                Else
                    Ds1.Clear()
                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT IDCuenta,Titular,Balance,Bancos.Identidad,ChequeActual FROM" & SysName.Text & "CuentasBancarias INNER JOIN Libregco.Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco WHERE CuentasBancarias.Cheques=1 and CuentasBancarias.Nulo=0 and NoCuenta='" + cbxCuentaE.Text + "'", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds1, "CuentasBancarias")
                    ConMixta.Close()

                    Dim Tablae As DataTable = Ds1.Tables("CuentasBancarias")

                    lblIDCuenta.Text = (Tablae.Rows(0).Item("IDCuenta"))
                    txtBancoE.Text = (Tablae.Rows(0).Item("Identidad")) & " --> " & (Tablae.Rows(0).Item("Titular"))
                    txtNoChequeE.Text = CDbl(Tablae.Rows(0).Item("ChequeActual")) + 1

                    If IsNumeric(Tablae.Rows(0).Item("Balance")) Then
                        txtBalanceE.Text = CDbl(Tablae.Rows(0).Item("Balance")).ToString("C")
                    End If
                End If
            End If

        Catch ex As Exception

        End Try


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
        WriteNumberToText()
    End Sub

    Private Sub ConceptoTransaccion()
        Dim x As Integer = 0
        Dim Total, Total1 As Double
        txtConcepto.Clear()

        If DgvCompras.Rows.Count > 0 Then
            txtConcepto.Text = ""
Inicio:
            If x = DgvCompras.Rows.Count Then
                GoTo Fin
            End If
            Total = CDbl(DgvCompras.Rows(x).Cells(8).Value) + CDbl(DgvCompras.Rows(x).Cells(9).Value) + CDbl(DgvCompras.Rows(x).Cells(10).Value) + CDbl(DgvCompras.Rows(x).Cells(11).Value)


            If Total > 0 Then
                If Total < CDbl(DgvCompras.Rows(x).Cells(7).Value) Then
                    txtConcepto.Text = txtConcepto.Text & "Abono a: " & CStr(DgvCompras.Rows(x).Cells(3).Value)
                ElseIf Total = CDbl(DgvCompras.Rows(x).Cells(7).Value) Then
                    txtConcepto.Text = txtConcepto.Text & "Saldo a: " & CStr(DgvCompras.Rows(x).Cells(3).Value)
                End If
            End If

            If x + 1 < DgvCompras.Rows.Count Then
                Total1 = CDbl(DgvCompras.Rows(x + 1).Cells(8).Value) + CDbl(DgvCompras.Rows(x + 1).Cells(9).Value) + CDbl(DgvCompras.Rows(x + 1).Cells(10).Value) + CDbl(DgvCompras.Rows(x + 1).Cells(11).Value)
                If Total1 > 0 And CDbl(DgvCompras.Rows(x).Cells(11).Value) > 0 Then
                    txtConcepto.Text = txtConcepto.Text & ", "
                End If
            End If

            x = x + 1
            GoTo Inicio

Fin:
            If txtConcepto.Text <> "" Then
                txtConcepto.Text = txtConcepto.Text & "."
            End If
        End If
    End Sub

    Sub WriteNumberToText()
        Dim CvtLetra As New Label
        Dim MontoDecimal As Decimal
        Dim DecimalResult As Decimal
        Dim DecimalResulttoString As String
        Dim Monto As Integer

        If Tipo.Text = 0 Then
            If CDbl(txtMontoAplicar.Text) > 0 Then
                MontoDecimal = CDbl(txtMontoAplicar.Text)
                DecimalResult = MontoDecimal - Int(MontoDecimal)
                Monto = MontoDecimal - DecimalResult

                If DecimalResult > 0 Then
                    DecimalResulttoString = " CON " & CInt(DecimalResult * 100) & "/100"
                Else
                    DecimalResulttoString = ""
                End If

                CvtLetra.Text = Num2Text(CInt(Monto))

                lblSumaLetra.Text = "LA SUMA DE " & CvtLetra.Text & " PESOS" & DecimalResulttoString

            Else
                lblSumaLetra.Text = ""
            End If
        Else
            If CDbl(txtMonto.Text) > 0 Then
                MontoDecimal = CDbl(txtMonto.Text)
                DecimalResult = MontoDecimal - Int(MontoDecimal)
                Monto = MontoDecimal - DecimalResult

                If DecimalResult > 0 Then
                    DecimalResulttoString = " CON " & CInt(DecimalResult * 100) & "/100"
                Else
                    DecimalResulttoString = ""
                End If

                CvtLetra.Text = Num2Text(CInt(Monto))

                txtMontoLetras.Text = "LA SUMA DE " & CvtLetra.Text & " PESOS" & DecimalResulttoString

            Else
                lblSumaLetra.Text = ""
            End If

        End If

    End Sub

    Sub ConjuntoSuma()
        Dim MontoAplicar As Double = 0
        Dim Descuentos As Double = 0
        Dim RetISR As Double = 0
        Dim RetITBIS As Double = 0


        For Each row As DataGridViewRow In DgvCompras.Rows
            MontoAplicar = MontoAplicar + CDbl(row.Cells(11).Value)
            RetISR = RetISR + CDbl(row.Cells(8).Value)
            RetITBIS = RetITBIS + CDbl(row.Cells(9).Value)
            Descuentos = Descuentos + CDbl(row.Cells(10).Value)

        Next

        txtMontoAplicar.Text = MontoAplicar.ToString("C")
        txtNeto.Text = (MontoAplicar + RetISR + RetITBIS + Descuentos).ToString("C")
        txtDescRet.Text = (RetISR + RetITBIS + Descuentos).ToString("C")
    End Sub

    Private Sub ActualizarTodo()
        FillCuenta()
        lblNulo.Text = 0
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        HeaderIncluir.Checked = False
        txtDescRet.Text = CDbl(0).ToString("C")
        txtNeto.Text = CDbl(0).ToString("C")
        txtMonto.Text = CDbl(0).ToString("C")
        txtMontoAplicar.Text = CDbl(0).ToString("C")
        Tipo.Text = 0
        rdbCuentasporPagar.Checked = True
        Hora.Enabled = True
        dtpFechaPagoE.Value = Today
        dtpFechaPagoR.Value = Today
        lblEstado.Text = 0
    End Sub

    Private Sub CompararEntradas()
        txtMontoAplicar.Text = (CDbl(txtNeto.Text) - CDbl(txtDescRet.Text)).ToString("C")
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
            Dim x As Integer = 0

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

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LimpiarDatos()
        txtIDSuplidor.Clear()
        txtNombreSuplidor.Clear()
        txtBalanceSup.Clear()
        txtUltimoPago.Clear()
        txtUltimoMonto.Clear()
        txtIDSolicitud.Clear()
        txtSecondID.Clear()
        DgvCompras.Rows.Clear()
        txtConcepto.Clear()
        txtConceptoE.Clear()
        txtBanco.Clear()
        txtBancoE.Clear()
        txtBalance.Clear()
        txtBalanceE.Clear()
        txtNoChequeE.Clear()
        txtNoChequeC.Clear()
        txtBeneficiario.Clear()
        txtMontoLetras.Clear()
        lblSumaLetra.Text = ""
        btnBuscarSup.Focus()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ColumnasDgvCompras()
        DgvCompras.Columns.Clear()
        With DgvCompras
            .Columns.Add("IDSolicitudDetalle", "IDSolicitudDetalle") '0
            .Columns.Add("IDCompra", "IDCompra")  '1
            .Columns.Add("SecondID", "Código") '2
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

        End With
        PropiedadesDgvCompras()
    End Sub

    Private Sub PropiedadesDgvCompras()
        Try
            Dim DatagridWidth As Double = (DgvCompras.Width - DgvCompras.RowHeadersWidth) / 100

            With DgvCompras
                .Columns("IDSolicitudDetalle").Visible = False
                .Columns("IDCompra").Visible = False

                .Columns("SecondID").Width = DatagridWidth * 11
                .Columns("SecondID").ReadOnly = True

                .Columns("NoFactura").Width = DatagridWidth * 11
                .Columns("NoFactura").ReadOnly = True

                .Columns("FechaFactura").Width = DatagridWidth * 8
                .Columns("FechaFactura").ReadOnly = True

                .Columns("Vence").Width = DatagridWidth * 8
                .Columns("Vence").ReadOnly = True

                .Columns("Monto").Width = DatagridWidth * 10
                .Columns("Monto").DefaultCellStyle.Format = ("C")
                .Columns("Monto").ReadOnly = True

                .Columns("Balance").DefaultCellStyle.Format = ("C")
                .Columns("Balance").Width = DatagridWidth * 12
                .Columns("Balance").ReadOnly = True

                .Columns("RetISR").DefaultCellStyle.Format = ("C")
                .Columns("RetISR").Width = DatagridWidth * 8

                .Columns("RetITBIS").DefaultCellStyle.Format = ("C")
                .Columns("RetITBIS").Width = DatagridWidth * 8

                .Columns("Descuento").DefaultCellStyle.Format = ("C")
                .Columns("Descuento").Width = DatagridWidth * 8

                .Columns("Aplicar").DefaultCellStyle.Format = ("C")
                .Columns("Aplicar").Width = DatagridWidth * 12
                .Columns("Aplicar").DefaultCellStyle.BackColor = Color.Beige

                .Columns("BceFinal").DefaultCellStyle.Format = ("C")
                .Columns("BceFinal").ReadOnly = True
                .Columns("BceFinal").Width = DatagridWidth * 12
                .Columns("BceFinal").DefaultCellStyle.BackColor = Color.Gray
                .Columns("BceFinal").DefaultCellStyle.ForeColor = Color.White

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

            For Each Column As DataGridViewColumn In DgvCompras.Columns
                Column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
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

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
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

    Private Sub ConvertDouble()
        txtMontoAplicar.Text = CDbl(txtMontoAplicar.Text)
        txtMonto.Text = CDbl(txtMonto.Text)
        txtDescRet.Text = CDbl(txtDescRet.Text)
        txtNeto.Text = CDbl(txtNeto.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtMontoAplicar.Text = CDbl(txtMontoAplicar.Text).ToString("C")
        txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
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

    Private Sub UltSolicitudCheque()
        Try
            If txtIDSolicitud.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDSolicitudCheque from solicitudcheques where IDSolicitudCheque= (Select Max(IDSolicitudCheque) from solicitudcheques)", Con)
                txtIDSolicitud.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "UltIDSolicitudCheque")
        End Try
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

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        If txtIDSolicitud.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir la solicitud de cheques?", "Imprimir solicitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub DgvCompras_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvCompras.CellPainting
        If e.RowIndex = -1 AndAlso e.ColumnIndex = 12 Then
            ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex)
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

    Private Sub btnBuscarSup_Click(sender As Object, e As EventArgs) Handles btnBuscarSup.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub cbxCuentaE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCuentaE.SelectedIndexChanged
        SetIDCuenta()
    End Sub

    Private Sub rdbCuentasporPagar_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCuentasporPagar.CheckedChanged
        If rdbCuentasporPagar.Checked = True Then
            Tipo.Text = 0
            TabControl1.SelectedIndex = 0
        Else
            Tipo.Text = 1
            TabControl1.SelectedIndex = 1
        End If

        DeshabilitarControlesporTipo()
    End Sub

    Private Sub cbxCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCuenta.SelectedIndexChanged
        SetIDCuenta()
    End Sub

    Sub RefrescarComprasPendientes()
        Try
            DgvCompras.Rows.Clear()
            Con.Open()
            Dim Da As New MySqlCommand("SELECT IDCompra,Compras.SecondID,NoFactura,FechaFactura,FechaVencimiento,TotalNeto,Balance-(SELECT Coalesce(Sum(solicitudchequesdetalle.Monto+SolicitudChequesDetalle.Descuento),0) FROM" & SysName.Text & "solicitudchequesdetalle inner join" & SysName.Text & "solicitudcheques on solicitudchequesdetalle.IDSolicitudCheque=SolicitudCheques.IDSolicitudCheque Where SolicitudCheques.Nulo=0 and SolicitudCheques.Estado=0 and Compras.IDCompra=SolicitudChequesDetalle.IDCompra) as Balance from" & SysName.Text & "Compras where IDSuplidor='" + txtIDSuplidor.Text + "' and Balance>0  and Nulo=0", Con)
            Dim LectorCompra As MySqlDataReader = Da.ExecuteReader

            While LectorCompra.Read
                DgvCompras.Rows.Add("", LectorCompra.GetValue(0), LectorCompra.GetValue(1), LectorCompra.GetValue(2), CDate(LectorCompra.GetValue(3)).ToString("dd/MM/yyyy"), CDate(LectorCompra.GetValue(4)).ToString("dd/MM/yyyy"), CDbl(LectorCompra.GetValue(5)).ToString("C"), CDbl(LectorCompra.GetValue(6)).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), False, CDbl(LectorCompra.GetValue(6)).ToString("C"))
                ''''''''''''''''''''''''''IDCompra                    SecondIDCompras                NoFactura                     FechaFactura                                        FechaVencimiento                                            TotalNeto                                                  Balance   
            End While
            LectorCompra.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub DgvCompras_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvCompras.CurrentCellDirtyStateChanged
        If DgvCompras.IsCurrentCellDirty Then
            DgvCompras.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtMonto.Leave
        Try
            If txtMonto.Text = "" Then
                txtMonto.Text = CDbl(0).ToString("C")
            Else
                txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
            End If

            WriteNumberToText()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtMonto_Enter(sender As Object, e As EventArgs) Handles txtMonto.Enter
        If txtMonto.Text = "" Then
        Else
            txtMonto.Text = CDbl(txtMonto.Text)
        End If
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Sub DeshabilitarControlesporTipo()

        If rdbCuentasporPagar.Checked = True Then
            btnBuscarSup.Enabled = True
            DgvCompras.Enabled = True
            cbxCuenta.Enabled = True
            txtConcepto.Enabled = True
            dtpFechaPagoR.Enabled = True
            cbxCuentaE.Enabled = False
            txtNoChequeE.Enabled = False
            txtBeneficiario.Enabled = False
            txtMonto.Enabled = False
            txtConceptoE.Enabled = False
            dtpFechaPagoE.Enabled = False

        Else
            btnBuscarSup.Enabled = False
            DgvCompras.Enabled = False
            cbxCuenta.Enabled = False
            txtConcepto.Enabled = False
            dtpFechaPagoR.Enabled = False
            cbxCuentaE.Enabled = True
            txtNoChequeE.Enabled = True
            txtBeneficiario.Enabled = True
            txtMonto.Enabled = True
            txtConceptoE.Enabled = True
            dtpFechaPagoE.Enabled = True
        End If

    End Sub

    Private Sub InsertDetalle()
        Try
            Dim y As Integer = 0
            Dim lblIDSolicitudDetalle, lblIDCompra, lblBalanceFact, lblRetIsr, lblRetItbis, lblDescuentoFact, lblAplicar, lblTotal, lblPendiente As New Label


            If txtIDSolicitud.Text = "" Then
            Else
Inicio:
                If y = DgvCompras.Rows.Count Then
                    GoTo Fin
                End If

                lblIDSolicitudDetalle.Text = DgvCompras.Rows(y).Cells(0).Value
                lblIDCompra.Text = DgvCompras.Rows(y).Cells(1).Value
                lblBalanceFact.Text = CDbl(DgvCompras.Rows(y).Cells(7).Value)
                lblRetIsr.Text = CDbl(DgvCompras.Rows(y).Cells(8).Value)
                lblRetItbis.Text = CDbl(DgvCompras.Rows(y).Cells(9).Value)
                lblDescuentoFact.Text = CDbl(DgvCompras.Rows(y).Cells(10).Value)
                lblAplicar.Text = CDbl(DgvCompras.Rows(y).Cells(11).Value)
                lblTotal.Text = lblRetIsr.Text + lblRetItbis.Text + lblDescuentoFact.Text + lblAplicar.Text
                lblPendiente.Text = CDbl(DgvCompras.Rows(y).Cells(13).Value)

                If lblIDSolicitudDetalle.Text = "" Then         'Si es un registro nuevo
                    If CDbl(lblTotal.Text) = 0 Then     'Si el total es 0 entonces no hago nada.
                    Else                                'Si es diference a 0 y es un registro nuevo, entonces lo inserto
                        sqlQ = "Insert into Solicitudchequesdetalle (IDSolicitudCheque,IDCompra,RetISR,RetItbis,Descuento,Monto,Balance) Values ('" + txtIDSolicitud.Text + "','" + lblIDCompra.Text + "','" + lblRetIsr.Text + "','" + lblRetItbis.Text + "','" + lblDescuentoFact.Text + "','" + lblAplicar.Text + "','" + lblPendiente.Text + "')"
                        GuardarDatos()
                    End If
                Else                    'Si el registro ya existe.
                    If CDbl(lblTotal.Text) = 0 Then     'Si el total del existente es 0 entonces lo elimino.
                        sqlQ = "Delete from Solicitudchequesdetalle Where IDChequesDetalle = '" + lblIDSolicitudDetalle.Text + "'"
                        GuardarDatos()
                    Else            'Si el total es diferente a 0 entonces actualizo sus datos.
                        sqlQ = "UPDATE Solicitudchequesdetalle SET RetISR='" + lblRetIsr.Text + "',RetItbis='" + lblRetItbis.Text + "',Descuento='" + lblDescuentoFact.Text + "',Monto='" + lblAplicar.Text + "',Balance='" + lblPendiente.Text + "' WHERE IDChequesDetalle= '" + lblIDSolicitudDetalle.Text + "'"
                        GuardarDatos()
                    End If
                End If

            End If

            y = y + 1
            GoTo Inicio
Fin:

            RefrescarSolicitudesDetalle()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " Desde Insertar Detalle Abono.")
        End Try
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If rdbCuentasporPagar.Checked = True Then
            If txtIDSuplidor.Text = "" Then
                MessageBox.Show("Seleccione el suplidor correspondiente para realizar la solicitud de cheques.", "Solicitud de cheques", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnBuscarSup.PerformClick()
                Exit Sub
            ElseIf cbxCuenta.Text = "" Then
                MessageBox.Show("Seleccione la cuenta bancaria para la solicitud de cheques.", "Seleccione la cuenta bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
                cbxCuenta.Focus()
                cbxCuenta.DroppedDown = True
            ElseIf CDbl(txtNeto.Text) = 0 Then
                MessageBox.Show("Escriba  o seleccione el monto aplicable a las facturas del suplidor.", "Neto no válido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDSolicitud.Text = "" Then 'Si no hay pago
                If Permisos(1) = 0 Then
                    MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar la solicitud de cheques al suplidor [" & txtIDSuplidor.Text & "] " & txtNombreSuplidor.Text & " de la cuenta " & cbxCuenta.Text & "?", "Procesar nuevo cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    sqlQ = "INSERT INTO SolicitudCheques (IDTipoDocumento,IDEquipo,Fecha,Hora,IDUsuario,IDCuenta,NoCheque,FechaPago,IDSuplidor,Beneficiario,Retencion,Monto,MontoLetras,Neto,Observacion,Tipo,Nulo,Estado) VALUES ('47','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + lblIDCuenta.Text + "','" + txtNoChequeC.Text + "','" + dtpFechaPagoR.Value.ToString("yyyy-MM-dd") + "','" + txtIDSuplidor.Text + "','" + txtNombreSuplidor.Text + "','" + txtDescRet.Text + "','" + txtMontoAplicar.Text + "','" + lblSumaLetra.Text + "','" + txtNeto.Text + "','" + txtConcepto.Text + "','" + Tipo.Text + "','" + lblNulo.Text + "',0)"
                    GuardarDatos()
                    UltSolicitudCheque()
                    SetSecondID()
                    InsertDetalle()

                    frm_cheques.Show(Me)
                    frm_cheques.cbxCuenta.Text = cbxCuenta.Text
                    frm_cheques.txtBeneficiario.Text = txtNombreSuplidor.Text
                    frm_cheques.txtMonto.Text = txtMontoAplicar.Text
                    frm_cheques.WriteNumberToText()
                    frm_cheques.txtConcepto.Text = txtConcepto.Text
                    frm_cheques.dtpFechaPago.Value = dtpFechaPagoR.Value
                    frm_cheques.ConvertDouble()

                    sqlQ = "INSERT INTO Movimientosbanco (IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Hora,IDCuentaBancaria,IDTipoMovimientoBanc,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,MontoLetras,NCF,Concepto,RutaDocumento,Nulo) VALUES ('45','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDCuenta.Text + "','1','" + frm_cheques.txtNoCheque.Text + "','" + frm_cheques.dtpFechaPago.Value.ToString("yyyy-MM-dd") + "','" + frm_cheques.txtBeneficiario.Text + "','" + frm_cheques.txtMonto.Text + "',0,0,'" + frm_cheques.txtMonto.Text + "','" + frm_cheques.txtMontoLetras.Text + "','','" + frm_cheques.txtConcepto.Text + "','" + Replace(frm_cheques.lblRutaDocumento.Text, "\", "\\") + "','" + frm_cheques.lblchknulo.Text + "')"
                    GuardarDatos()
                    frm_cheques.UpdateLastCheque()
                    frm_cheques.UltPagoCheque()
                    frm_cheques.SetSecondID()
                    ConvertCurrent()
                    CalcularBceCuentaBancaria(lblIDCuenta.Text)
                    frm_cheques.Close()

                    ConvertCurrent()
                    MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ImprimirDocumento()
                End If
            Else
                If Permisos(2) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    sqlQ = "UPDATE SolicitudCheques SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCuenta='" + lblIDCuenta.Text + "',NoCheque='" + txtNoChequeC.Text + "',FechaPago='" + dtpFechaPagoR.Value.ToString("yyyy-MM-dd") + "',IDSuplidor='" + txtIDSuplidor.Text + "',Beneficiario='" + txtNombreSuplidor.Text + "',Retencion='" + txtDescRet.Text + "',Monto='" + txtMonto.Text + "',MontoLetras='" + lblSumaLetra.Text + "',Neto='" + txtNeto.Text + "',Observacion='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "',Estado='" + lblEstado.Text + "' WHERE IDSolicitudCheque= (" + txtIDSolicitud.Text + ")"
                    GuardarDatos()
                    InsertDetalle()
                    ConvertCurrent()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ImprimirDocumento()
                End If
            End If

        ElseIf rdbEgresos.Checked = True Then
            If txtBeneficiario.Text = "" Then
                MessageBox.Show("El beneficiario a procesar se encuentra vacío. Indique el beneficiario para procesar el cheque.", "Especifique el beneficiario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtBeneficiario.Focus()
                Exit Sub
            ElseIf cbxCuentaE.Text = "" Then
                MessageBox.Show("Seleccione la cuenta bancaria para la solicitud de cheques.", "Seleccione la cuenta bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
                cbxCuentaE.Focus()
                cbxCuentaE.DroppedDown = True
            ElseIf txtMonto.Text = "" Then
                MessageBox.Show("El monto total del cheque no es válido.", "Especifique el monto del cheque", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtMonto.Focus()
                Exit Sub
            End If


            If txtIDSolicitud.Text = "" Then 'Si no hay pago
                If Permisos(1) = 0 Then
                    MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar la solicitud de cheques al suplidor [" & txtIDSuplidor.Text & "] " & txtNombreSuplidor.Text & " de la cuenta " & cbxCuenta.Text & "?", "Procesar nuevo cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    sqlQ = "INSERT INTO SolicitudCheques (IDTipoDocumento,IDEquipo,Fecha,Hora,IDUsuario,IDCuenta,NoCheque,FechaPago,IDSuplidor,Beneficiario,Retencion,Monto,MontoLetras,Neto,Observacion,Tipo,Nulo,Estado) VALUES ('47','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + lblIDCuenta.Text + "','" + txtNoChequeE.Text + "','" + dtpFechaPagoE.Value.ToString("yyyy-MM-dd") + "',1,'" + txtBeneficiario.Text + "',0,'" + txtMonto.Text + "','" + txtMontoLetras.Text + "','" + txtMonto.Text + "','" + txtConceptoE.Text + "','" + Tipo.Text + "','" + lblNulo.Text + "',0)"
                    GuardarDatos()
                    UltSolicitudCheque()
                    SetSecondID()

                    frm_cheques.Show(Me)
                    frm_cheques.cbxCuenta.Text = cbxCuenta.Text
                    frm_cheques.txtBeneficiario.Text = txtNombreSuplidor.Text
                    frm_cheques.txtMonto.Text = txtMontoAplicar.Text
                    frm_cheques.WriteNumberToText()
                    frm_cheques.txtConcepto.Text = txtConcepto.Text
                    frm_cheques.dtpFechaPago.Value = dtpFechaPagoR.Value
                    frm_cheques.ConvertDouble()

                    sqlQ = "INSERT INTO Movimientosbanco (IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Hora,IDCuentaBancaria,IDTipoMovimientoBanc,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,MontoLetras,NCF,Concepto,RutaDocumento,Nulo) VALUES ('45','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDCuenta.Text + "','1','" + frm_cheques.txtNoCheque.Text + "','" + frm_cheques.dtpFechaPago.Value.ToString("yyyy-MM-dd") + "','" + frm_cheques.txtBeneficiario.Text + "','" + frm_cheques.txtMonto.Text + "',0,0,'" + frm_cheques.txtMonto.Text + "','" + frm_cheques.txtMontoLetras.Text + "','','" + frm_cheques.txtConcepto.Text + "','" + Replace(frm_cheques.lblRutaDocumento.Text, "\", "\\") + "','" + frm_cheques.lblchknulo.Text + "')"
                    GuardarDatos()
                    frm_cheques.UpdateLastCheque()
                    frm_cheques.UltPagoCheque()
                    frm_cheques.SetSecondID()
                    ConvertCurrent()
                    CalcularBceCuentaBancaria(lblIDCuenta.Text)
                    frm_cheques.Close()

                    ConvertCurrent()
                    MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ImprimirDocumento()
                End If
            Else
                If Permisos(2) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    sqlQ = "UPDATE SolicitudCheques SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCuenta='" + lblIDCuenta.Text + "',NoCheque='" + txtNoChequeE.Text + "',FechaPago='" + dtpFechaPagoE.Value.ToString("yyyy-MM-dd") + "',Beneficiario='" + txtBeneficiario.Text + "',Retencion=0,Monto='" + txtMonto.Text + "',MontoLetras='" + txtMontoLetras.Text + "',Neto='" + txtMonto.Text + "',Observacion='" + txtConceptoE.Text + "',Nulo='" + lblNulo.Text + "',Estado='" + lblEstado.Text + "' WHERE IDSolicitudCheque= (" + txtIDSolicitud.Text + ")"
                    GuardarDatos()
                    ConvertCurrent()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ImprimirDocumento()
                End If
            End If

        End If
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=47", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE SolicitudCheques SET SecondID='" + lblSecondID.Text + "' WHERE IDSolicitudCheque= (" + txtIDSolicitud.Text + ")"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=47"
            GuardarDatos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If rdbCuentasporPagar.Checked = True Then
            If txtIDSuplidor.Text = "" Then
                MessageBox.Show("Seleccione el suplidor correspondiente para realizar la solicitud de cheques.", "Solicitud de cheques", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnBuscarSup.PerformClick()
                Exit Sub
            ElseIf CDbl(txtNeto.Text) = 0 Then
                MessageBox.Show("Escriba  o seleccione el =nto aplicable a las facturas del suplidor.", "Neto no válido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDSolicitud.Text = "" Then 'Si no hay pago
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar la solicitud de cheques al suplidor [" & txtIDSuplidor.Text & "] " & txtNombreSuplidor.Text & " de la cuenta " & cbxCuenta.Text & "?", "Procesar nuevo cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    sqlQ = "INSERT INTO SolicitudCheques (IDTipoDocumento,IDEquipo,Fecha,Hora,IDUsuario,IDCuenta,NoCheque,FechaPago,IDSuplidor,Beneficiario,Retencion,Monto,MontoLetras,Neto,Observacion,Tipo,Nulo,Estado) VALUES ('47','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + lblIDCuenta.Text + "','" + txtNoChequeC.Text + "','" + dtpFechaPagoR.Value.ToString("yyyy-MM-dd") + "','" + txtIDSuplidor.Text + "','" + txtBeneficiario.Text + "','" + txtDescRet.Text + "','" + txtMontoAplicar.Text + "','" + lblSumaLetra.Text + "','" + txtNeto.Text + "','" + txtConcepto.Text + "','" + Tipo.Text + "','" + lblNulo.Text + "',0)"
                    GuardarDatos()
                    UltSolicitudCheque()
                    SetSecondID()
                    InsertDetalle()

                    frm_cheques.Show(Me)
                    frm_cheques.cbxCuenta.Text = cbxCuenta.Text
                    frm_cheques.txtBeneficiario.Text = txtNombreSuplidor.Text
                    frm_cheques.txtMonto.Text = txtMontoAplicar.Text
                    frm_cheques.WriteNumberToText()
                    frm_cheques.txtConcepto.Text = txtConcepto.Text
                    frm_cheques.dtpFechaPago.Value = dtpFechaPagoR.Value
                    frm_cheques.ConvertDouble()

                    sqlQ = "INSERT INTO Movimientosbanco (IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Hora,IDCuentaBancaria,IDTipoMovimientoBanc,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,MontoLetras,NCF,Concepto,RutaDocumento,Nulo) VALUES ('45','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDCuenta.Text + "','1','" + frm_cheques.txtNoCheque.Text + "','" + frm_cheques.dtpFechaPago.Value.ToString("yyyy-MM-dd") + "','" + frm_cheques.txtBeneficiario.Text + "','" + frm_cheques.txtMonto.Text + "',0,0,'" + frm_cheques.txtMonto.Text + "','" + frm_cheques.txtMontoLetras.Text + "','','" + frm_cheques.txtConcepto.Text + "','" + Replace(frm_cheques.lblRutaDocumento.Text, "\", "\\") + "','" + frm_cheques.lblchknulo.Text + "')"
                    GuardarDatos()
                    frm_cheques.UpdateLastCheque()
                    frm_cheques.UltPagoCheque()
                    frm_cheques.SetSecondID()
                    ConvertCurrent()
                    CalcularBceCuentaBancaria(lblIDCuenta.Text)
                    frm_cheques.Close()

                    ConvertCurrent()
                    MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ImprimirDocumento()
                End If
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    sqlQ = "UPDATE SolicitudCheques SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCuenta='" + lblIDCuenta.Text + "',NoCheque='" + txtNoChequeC.Text + "',FechaPago='" + dtpFechaPagoR.Value.ToString("yyyy-MM-dd") + "',IDSuplidor='" + txtIDSuplidor.Text + "',Beneficiario='" + txtBeneficiario.Text + "',Retencion='" + txtDescRet.Text + "',Monto='" + txtMonto.Text + "',MontoLetras='" + lblSumaLetra.Text + "',Neto='" + txtNeto.Text + "',Observacion='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "',Estado='" + lblEstado.Text + "' WHERE IDSolicitudCheque= (" + txtIDSolicitud.Text + ")"
                    GuardarDatos()
                    InsertDetalle()
                    ConvertCurrent()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ImprimirDocumento()
                End If
            End If

        ElseIf rdbEgresos.Checked = True Then
            If txtBeneficiario.Text = "" Then
                MessageBox.Show("El beneficiario a procesar se encuentra vacío. Indique el beneficiario para procesar el cheque.", "Especifique el beneficiario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtBeneficiario.Focus()
                Exit Sub
            ElseIf txtMonto.Text = "" Then
                MessageBox.Show("El monto total del cheque no es válido.", "Especifique el monto del cheque", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtMonto.Focus()
                Exit Sub
            End If

            If txtIDSolicitud.Text = "" Then 'Si no hay pago
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar la solicitud de cheques al suplidor [" & txtIDSuplidor.Text & "] " & txtNombreSuplidor.Text & " de la cuenta " & cbxCuenta.Text & "?", "Procesar nuevo cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    sqlQ = "INSERT INTO SolicitudCheques (IDTipoDocumento,IDEquipo,Fecha,Hora,IDUsuario,IDCuenta,NoCheque,FechaPago,IDSuplidor,Beneficiario,Retencion,Monto,MontoLetras,Neto,Observacion,Tipo,Nulo,Estado) VALUES ('47','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + lblIDCuenta.Text + "','" + txtNoChequeE.Text + "','" + dtpFechaPagoE.Value.ToString("yyyy-MM-dd") + "',1,'" + txtBeneficiario.Text + "',0,'" + txtMonto.Text + "','" + txtMontoLetras.Text + "','" + txtMonto.Text + "','" + txtConceptoE.Text + "','" + Tipo.Text + "','" + lblNulo.Text + "',0)"
                    GuardarDatos()
                    UltSolicitudCheque()
                    SetSecondID()

                    frm_cheques.Show(Me)
                    frm_cheques.cbxCuenta.Text = cbxCuenta.Text
                    frm_cheques.txtBeneficiario.Text = txtNombreSuplidor.Text
                    frm_cheques.txtMonto.Text = txtMontoAplicar.Text
                    frm_cheques.WriteNumberToText()
                    frm_cheques.txtConcepto.Text = txtConcepto.Text
                    frm_cheques.dtpFechaPago.Value = dtpFechaPagoR.Value
                    frm_cheques.ConvertDouble()

                    sqlQ = "INSERT INTO Movimientosbanco (IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Hora,IDCuentaBancaria,IDTipoMovimientoBanc,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,MontoLetras,NCF,Concepto,RutaDocumento,Nulo) VALUES ('45','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDCuenta.Text + "','1','" + frm_cheques.txtNoCheque.Text + "','" + frm_cheques.dtpFechaPago.Value.ToString("yyyy-MM-dd") + "','" + frm_cheques.txtBeneficiario.Text + "','" + frm_cheques.txtMonto.Text + "',0,0,'" + frm_cheques.txtMonto.Text + "','" + frm_cheques.txtMontoLetras.Text + "','','" + frm_cheques.txtConcepto.Text + "','" + Replace(frm_cheques.lblRutaDocumento.Text, "\", "\\") + "','" + frm_cheques.lblchknulo.Text + "')"
                    GuardarDatos()
                    frm_cheques.UpdateLastCheque()
                    frm_cheques.UltPagoCheque()
                    frm_cheques.SetSecondID()
                    ConvertCurrent()
                    CalcularBceCuentaBancaria(lblIDCuenta.Text)
                    frm_cheques.Close()

                    ConvertCurrent()
                    MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ImprimirDocumento()
                    LimpiarDatos()
                    ActualizarTodo()
                End If
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    sqlQ = "UPDATE SolicitudCheques SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCuenta='" + lblIDCuenta.Text + "',NoCheque='" + txtNoChequeE.Text + "',FechaPago='" + dtpFechaPagoE.Value.ToString("yyyy-MM-dd") + "',Beneficiario='" + txtBeneficiario.Text + "',Retencion=0,Monto='" + txtMonto.Text + "',MontoLetras='" + txtMontoLetras.Text + "',Neto='" + txtMonto.Text + "',Observacion='" + txtConceptoE.Text + "',Nulo='" + lblNulo.Text + "',Estado='" + lblEstado.Text + "' WHERE IDSolicitudCheque= (" + txtIDSolicitud.Text + ")"
                    GuardarDatos()
                    ConvertCurrent()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ImprimirDocumento()
                    LimpiarDatos()
                    ActualizarTodo()
                End If
            End If

        End If
    End Sub

    Sub RefrescarSolicitudesDetalle()
        Try
            DgvCompras.Rows.Clear()
            Con.Open()
            Dim Da As New MySqlCommand("SELECT IDChequesdetalle,SolicitudChequesDetalle.IDCompra,Compras.SecondID,NoFactura,FechaFactura,FechaVencimiento,TotalNeto,Compras.Balance,SolicitudChequesDetalle.RetIsr,SolicitudChequesDetalle.RetItbis,SolicitudChequesDetalle.Descuento,SolicitudChequesDetalle.Monto,Solicitudchequesdetalle.Balance as BceDetalle from SolicitudChequesdetalle INNER JOIN Compras on SolicitudChequesDetalle.IDCompra=Compras.IDCompra where IDSolicitudCheque='" + txtIDSolicitud.Text + "'", Con)
            Dim LectorCompra As MySqlDataReader = Da.ExecuteReader

            While LectorCompra.Read
                DgvCompras.Rows.Add(LectorCompra.GetValue(0), LectorCompra.GetValue(1), LectorCompra.GetValue(2), LectorCompra.GetValue(3), CDate(LectorCompra.GetValue(4)).ToString("dd/MM/yyyy"), CDate(LectorCompra.GetValue(5)).ToString("dd/MM/yyyy"), CDbl(LectorCompra.GetValue(6)).ToString("C"), CDbl(LectorCompra.GetValue(7)).ToString("C"), CDbl(LectorCompra.GetValue(8)).ToString("C"), CDbl(LectorCompra.GetValue(9)).ToString("C"), CDbl(LectorCompra.GetValue(10)).ToString("C"), CDbl(LectorCompra.GetValue(11)).ToString("C"), False, CDbl(LectorCompra.GetValue(12)).ToString("C"))
            End While
            LectorCompra.Close()
            Con.Close()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If rdbCuentasporPagar.Checked = True Then
            If chkNulo.Checked = True Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("El registro solicitud de cheques " & txtSecondID.Text & " de la cuenta bancaria No. " & cbxCuenta.Text & " / " & txtBanco.Text & " con el número de cheque #" & txtNoChequeC.Text & " correspondiente al beneficiario " & txtBeneficiario.Text & ", ya está anulada en el sistema. Desea reactivarlo?", "Recuperar solicitud de cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then

                    chkNulo.Checked = False
                    ConvertDouble()
                    sqlQ = "UPDATE SolicitudCheques SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCuenta='" + lblIDCuenta.Text + "',NoCheque='" + txtNoChequeC.Text + "',FechaPago='" + dtpFechaPagoR.Value.ToString("yyyy-MM-dd") + "',IDSuplidor='" + txtIDSuplidor.Text + "',Beneficiario='" + txtBeneficiario.Text + "',Retencion='" + txtDescRet.Text + "',Monto='" + txtMonto.Text + "',MontoLetras='" + lblSumaLetra.Text + "',Neto='" + txtNeto.Text + "',Observacion='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "',Estado='" + lblEstado.Text + "' WHERE IDSolicitudCheque= (" + txtIDSolicitud.Text + ")"
                    GuardarDatos()
                    InsertDetalle()
                    ConvertCurrent()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            ElseIf txtIDSolicitud.Text = "" Then
                MessageBox.Show("No hay un registro cheque para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el registro de solicitud de cheques no. " & txtSecondID.Text & " correspondiente al cheque # " & txtNoChequeC.Text & " del beneficiario " & txtBeneficiario.Text & " del sistema?", "Anular registro de cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    chkNulo.Checked = True
                    ConvertDouble()
                    sqlQ = "UPDATE SolicitudCheques SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCuenta='" + lblIDCuenta.Text + "',NoCheque='" + txtNoChequeC.Text + "',FechaPago='" + dtpFechaPagoR.Value.ToString("yyyy-MM-dd") + "',IDSuplidor='" + txtIDSuplidor.Text + "',Beneficiario='" + txtBeneficiario.Text + "',Retencion='" + txtDescRet.Text + "',Monto='" + txtMonto.Text + "',MontoLetras='" + lblSumaLetra.Text + "',Neto='" + txtNeto.Text + "',Observacion='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "',Estado='" + lblEstado.Text + "' WHERE IDSolicitudCheque= (" + txtIDSolicitud.Text + ")"
                    GuardarDatos()
                    InsertDetalle()
                    ConvertCurrent()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Else

            If chkNulo.Checked = True Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("El registro solicitud de cheques " & txtSecondID.Text & " de la cuenta bancaria No. " & cbxCuenta.Text & " / " & txtBanco.Text & " con el número de cheque #" & txtNoChequeC.Text & " correspondiente al beneficiario " & txtBeneficiario.Text & ", ya está anulada en el sistema. Desea reactivarlo?", "Recuperar solicitud de cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then

                    chkNulo.Checked = False
                    ConvertDouble()
                    sqlQ = "UPDATE SolicitudCheques SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCuenta='" + lblIDCuenta.Text + "',NoCheque='" + txtNoChequeC.Text + "',FechaPago='" + dtpFechaPagoR.Value.ToString("yyyy-MM-dd") + "',IDSuplidor='" + txtIDSuplidor.Text + "',Beneficiario='" + txtBeneficiario.Text + "',Retencion='" + txtDescRet.Text + "',Monto='" + txtMonto.Text + "',MontoLetras='" + lblSumaLetra.Text + "',Neto='" + txtNeto.Text + "',Observacion='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "',Estado='" + lblEstado.Text + "' WHERE IDSolicitudCheque= (" + txtIDSolicitud.Text + ")"
                    GuardarDatos()
                    ConvertCurrent()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            ElseIf txtIDSolicitud.Text = "" Then
                MessageBox.Show("No hay un registro cheque para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el registro de solicitud de cheques no. " & txtSecondID.Text & " correspondiente al cheque # " & txtNoChequeE.Text & " del beneficiario " & txtBeneficiario.Text & " del sistema?", "Anular registro de cheque", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    chkNulo.Checked = True
                    ConvertDouble()
                    sqlQ = "UPDATE SolicitudCheques SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCuenta='" + lblIDCuenta.Text + "',NoCheque='" + txtNoChequeC.Text + "',FechaPago='" + dtpFechaPagoR.Value.ToString("yyyy-MM-dd") + "',IDSuplidor='" + txtIDSuplidor.Text + "',Beneficiario='" + txtBeneficiario.Text + "',Retencion='" + txtDescRet.Text + "',Monto='" + txtMonto.Text + "',MontoLetras='" + lblSumaLetra.Text + "',Neto='" + txtNeto.Text + "',Observacion='" + txtConcepto.Text + "',Nulo='" + lblNulo.Text + "',Estado='" + lblEstado.Text + "' WHERE IDSolicitudCheque= (" + txtIDSolicitud.Text + ")"
                    GuardarDatos()
                    ConvertCurrent()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        End If

    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_solicitud_cheques.ShowDialog(Me)
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnDesactivar.PerformClick()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub PicBoxLogo_Click(sender As Object, e As EventArgs) Handles PicBoxLogo.Click
        MessageBox.Show(Con.State.ToString & vbNewLine & ConLibregco.State.ToString & vbNewLine & ConLibregcoMain.State.ToString & vbNewLine & ConMixta.State.ToString)
    End Sub
End Class