Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_registro_factura_sd

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend ShowInfoArticle, FactDebajoCosto, DefaultNcf, FacturarSinExist, DefaultVendedor, DefaultCondicion, DefaultAlmacen, DefaultDiasCondicion, EvitSabado, EvitDomingo, IdentObligCred, PerVentasSContrato, SolicitarAutCredito As String
    Friend lblIDUsuario, lblCondicion, lblIDAlmacen, lblIDTipoDocumento, lblDiasCondicion, lblIDTransaccion, lblIDComprobante, lblFichaDatos, lblNotaContado, lblchkEntregaConduce, lblNulo As New Label
    Friend ChangedCodeEmployee As Boolean
    Dim Permisos As New ArrayList

    Private Sub frm_registro_factura_sd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        SetConfiguracion()
        ColumnasDgvPagares()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub SetConfiguracion()
        'Mostrar el panel de informacion de los articulos
        Con.Open()
        ConMixta.Open()

        cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=15", Con)
        ShowInfoArticle = Convert.ToString(cmd.ExecuteScalar())

        'Permitir facturar debajo del costo
        cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=16", Con)
        FactDebajoCosto = Convert.ToString(cmd.ExecuteScalar())

        'Comprobante Fiscal Predeterminado
        cmd = New MySqlCommand("SELECT TipoComprobante FROM configuracion INNER JOIN comprobantefiscal on Configuracion.Value2Int=ComprobanteFiscal.IDComprobanteFiscal Where IDConfiguracion=13", Con)
        DefaultNcf = Convert.ToString(cmd.ExecuteScalar())

        'Condicion Predeterminada
        cmd = New MySqlCommand("Select Condicion from" & SysName.Text & "Configuracion INNER JOIN Libregco.Condicion on Configuracion.Value2Int=Condicion.IDCondicion Where IDConfiguracion=59", ConMixta)
        DefaultCondicion = Convert.ToString(cmd.ExecuteScalar())

        'Vendedor Predeterminado
        cmd = New MySqlCommand("Select Nombre from Configuracion INNER JOIN Empleados on Configuracion.Value2Int=Empleados.IDEmpleado Where IDConfiguracion=26", Con)
        DefaultVendedor = Convert.ToString(cmd.ExecuteScalar())

        'Almacen Predeterminado
        cmd = New MySqlCommand("Select Almacen from Configuracion INNER JOIN Almacen on Configuracion.Value2Int=Almacen.IDAlmacen Where IDConfiguracion=47", Con)
        DefaultAlmacen = Convert.ToString(cmd.ExecuteScalar())

        'Facturar sin Existencia
        cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=21", Con)
        FacturarSinExist = Convert.ToString(cmd.ExecuteScalar())

        'Evitar Sabados en pagares
        cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=50", Con)
        EvitSabado = Convert.ToString(cmd.ExecuteScalar())

        'Evitar Domingos en pagares
        cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=51", Con)
        EvitDomingo = Convert.ToString(cmd.ExecuteScalar())

        'Dias en condicion de pagares
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=52", Con)
        DefaultDiasCondicion = Convert.ToString(cmd.ExecuteScalar())

        'Obligación de cédulas en créditos
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=55", Con)
        IdentObligCred = Convert.ToString(cmd.ExecuteScalar())

        'Permitir créditos sin contrato
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=79", Con)
        PerVentasSContrato = Convert.ToString(cmd.ExecuteScalar())

        'Solicitar autorizacion para créditos
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=82", Con)
        SolicitarAutCredito = Convert.ToString(cmd.ExecuteScalar())


        Con.Close()
        ConMixta.Close()

    End Sub

    Private Sub LimpiarDatos()
        Try
            txtIDCliente.Clear()
            txtNombre.Clear()
            txtBalanceGeneral.Clear()
            txtUltimoPago.Clear()
            txtCalificacion.Clear()
            txtIDFactura.Clear()
            txtHoraFactura.Clear()
            txtFechaFactura.Clear()
            txtSecondID.Clear()
            txtNIF.Clear()
            txtIDVendedor.Clear()
            txtVendedor.Clear()
            txtObservacion.Clear()
            AjCondContado()
            txtFlete.Text = CDbl(0).ToString("C")
            CbxTipoComprobante.Items.Clear()
            cbxAlmacen.Items.Clear()
            cbxCondicion.Items.Clear()
            txtSubTotal.Text = CDbl(0).ToString("C")
            txtITBIS.Text = CDbl(0).ToString("C")
            TxtDescuentoSuma.Text = CDbl(0).ToString("C")
            txtFlete.Text = CDbl(0).ToString("C")
            txtNeto.Text = CDbl(0).ToString("C")
            ChkNulo.Checked = False
            txtCobrador.Clear()
            txtCreditoDisponible.Clear()
            btnBuscarCliente.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CalcVencientoFactura()
        Dim MayorDate As Date
        Try
            MayorDate = Today

            For Each Row As DataGridViewRow In DgvPagares.Rows
                If CDate(Row.Cells(4).Value) > MayorDate Then
                    MayorDate = CDate(Row.Cells(4).Value)
                End If
            Next
            txtFechaVencimiento.Text = MayorDate.ToString("yyyy-MM-dd")

        Catch ex As Exception
            'txtCantidadPagos.Text = 1
            'MessageBox.Show(ex.Message.ToString & " CalcVencimientoFactura")
        End Try
    End Sub

    Private Sub CargarEmpresa()
     PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ColumnasDgvPagares()
        DgvPagares.Columns.Clear()
        With DgvPagares
            .Columns.Add("IDPagare", "IDPagare") '0
            .Columns.Add("IDFactura", "ID Factura") '1
            .Columns.Add("NoPagare", "No Pagaré.") '2
            .Columns.Add("Cantidad", "Cant.") '3
            .Columns.Add("FechaVencimiento", "Vencimiento") '4
            .Columns.Add("Concepto", "Concepto") '5
            .Columns.Add("Monto", "Monto") '6
            .Columns.Add("Balance", "Balance") '7
        End With
        PropiedadesDgvPagares()
    End Sub

    Private Sub PropiedadesDgvPagares()
        Dim Condicion As String = False
        With DgvPagares
            .Columns("IDPagare").Visible = Condicion
            .Columns("IDFactura").Visible = Condicion
            .Columns("FechaVencimiento").Width = 100
            .Columns("NoPagare").Width = 70
            .Columns("Cantidad").Visible = Condicion
            .Columns("Concepto").Width = 375
            .Columns("Monto").Width = 140
            .Columns("Monto").DefaultCellStyle.Format = ("C")
            .Columns("Balance").DefaultCellStyle.Format = ("C")
            .Columns("Balance").Visible = Condicion
        End With
    End Sub

    Private Sub CambiarBalance()
        If lblDiasCondicion.Text = 0 Then
            txtCantidadPagos.Text = CDbl(0)
            txtMontoPagos.Text = CDbl(0)
            txtBalance.Text = CDbl(0)
        End If
    End Sub

    Private Sub SetIDTipoDocumento()
        If lblDiasCondicion.Text = 0 Then
            lblIDTipoDocumento.Text = 12
        Else
            lblIDTipoDocumento.Text = 54
        End If
    End Sub

    Private Sub ActualizarTodo()
        'Try
        TabPagCondicion.SelectedIndex = 0
        lblDiasCondicion.Text = 0
        lblIDTransaccion.Text = ""
        ControlSuperClave = 1
        lblNulo.Text = 0
        lblNotaContado.Text = 0
        lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        lblchkEntregaConduce.Text = 0
        lblFichaDatos.Text = 0
        txtDiasCondicion.Text = DefaultDiasCondicion
        CambiarBalance()
        txtSubTotal.Text = CDbl(0).ToString("C")
        TxtDescuentoSuma.Text = CDbl(0).ToString("C")
        txtITBIS.Text = CDbl(0).ToString("C")
        txtFlete.Text = CDbl(0).ToString("C")
        cbxCondicion.Text = DefaultCondicion
        txtCondicionContado.Enabled = False
        ChangedCodeEmployee = False
        txtFechaFactura.Text = Today.ToString("yyyy-MM-dd")
        txtFechaVencimiento.Text = Today.ToString("yyyy-MM-dd")
        NewNCFValue.Text = ""
        SetIDTipoDocumento()
        FillComprobante()
        FillAlmacen()
        FillCondicion()
        HabilitarControles()
        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try

    End Sub

    Private Sub FillCondicion()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Condicion FROM Condicion where Nulo=0 ORDER BY Orden ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Condicion")
            cbxCondicion.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Condicion")
            For Each Fila As DataRow In Tabla.Rows
                cbxCondicion.Items.Add(Fila.Item("Condicion"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxCondicion.Text = DefaultCondicion
            Else
                MessageBox.Show("No se pudo cargar ninguna condición para definirla en la factura ya que no se encontraron resultados en la base de datos. Cree condiciones de ventas." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub FillAlmacen()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Almacen FROM Almacen INNER JOIN Empleados on Almacen.IDAlmacen=Empleados.IDAlmacen Where IDEmpleado='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "' ORDER BY Almacen.Almacen ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Almacen")
            cbxAlmacen.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Almacen")

            For Each Fila As DataRow In Tabla.Rows
                cbxAlmacen.Items.Add(Fila.Item("Almacen"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxAlmacen.SelectedIndex = 0
            Else
                MessageBox.Show("No se detectaron almacenes disponibles. Esto se puede deber a que no se encuentra un usuario definido en el formulario o porque no se encontraron almacenes en la base de datos." & vbNewLine & vbNewLine & "Por favor revise las condiciones o el sistema generará errores en la facturación.", "Sé detectó un fallo crítico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetIDAlmacen()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + cbxAlmacen.SelectedItem + "'", Con)
        lblIDAlmacen.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub FillComprobante()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT TipoComprobante FROM ComprobanteFiscal where IDContexto=1 ORDER BY TipoComprobante ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "ComprobanteFiscal")
        CbxTipoComprobante.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")

        For Each Fila As DataRow In Tabla.Rows
            CbxTipoComprobante.Items.Add(Fila.Item("TipoComprobante"))
        Next

        If Tabla.Rows.Count > 0 Then
            CbxTipoComprobante.Text = DefaultNcf
        End If
    End Sub

    Private Sub SetIDComprobanteFiscal()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDComprobanteFiscal FROM ComprobanteFiscal WHERE TipoComprobante= '" + CbxTipoComprobante.SelectedItem + "'", Con)
        lblIDComprobante.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub LiberarDgvPagares()
        Try
            If DgvPagares.Columns.Count = 0 Then
                DgvPagares.DataSource = Nothing
                DgvPagares.Rows.Clear()
                ColumnasDgvPagares()
            Else
                DgvPagares.DataSource = Nothing
                DgvPagares.Rows.Clear()
                DgvPagares.Columns.Clear()
                ColumnasDgvPagares()
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub HabilitarControles()
        GbClientes.Enabled = True
        CbxTipoComprobante.Enabled = True
        TabPagCondicion.Enabled = True
        txtSubTotal.Enabled = True
        TxtDescuentoSuma.Enabled = True
        txtITBIS.Enabled = True
        txtFlete.Enabled = True
        txtNeto.Enabled = True
    End Sub

    Sub DeshabilitarControles()
        GbClientes.Enabled = False
        CbxTipoComprobante.Enabled = False
        TabPagCondicion.Enabled = False
        txtSubTotal.Enabled = False
        TxtDescuentoSuma.Enabled = False
        txtITBIS.Enabled = False
        txtFlete.Enabled = False
        txtNeto.Enabled = False
    End Sub

    Private Sub CbxTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxTipoComprobante.SelectedIndexChanged
        SetIDComprobanteFiscal()
    End Sub

    Private Sub chkFichaDatos_CheckedChanged(sender As Object, e As EventArgs) Handles chkFichaDatos.CheckedChanged
        If chkFichaDatos.Checked = True Then
            lblFichaDatos.Text = 0
        Else
            lblFichaDatos.Text = 1
        End If
    End Sub

    Private Sub AjCondContado()
        If txtNeto.Text = "" Then
            txtNeto.Text = CDbl(0).ToString("C")
        End If

        If lblDiasCondicion.Text = 0 Then
            TabPagCondicion.Visible = False
            txtSubTotal.Text = CDbl(0).ToString("C")
            TxtDescuentoSuma.Text = CDbl(0).ToString("C")
            txtITBIS.Text = CDbl(0).ToString("C")
            txtFlete.Text = CDbl(0).ToString("C")
            txtNeto.Text = CDbl(0).ToString("C")
            txtInicial.Text = CDbl(0)
            txtBalance.Text = CDbl(0)
            txtCantidadPagos.Text = 1
            txtMontoPagos.Text = CDbl(0)
            txtAdicional.Text = CDbl(0)
            txtFechaAdicional.Text = ""
            txtCondicionContado.Text = ""
            chkFichaDatos.Checked = False
            chkHabilitarNota.Checked = False
            txtFechaVencimiento.Text = Today.ToString("yyyy-MM-dd")
        End If
    End Sub

    Private Sub AjCondCredito()
        Try
            If txtNeto.Text = "" Then
                txtNeto.Text = CDbl(0.0).ToString("C")
            End If

            If txtIDFactura.Text = "" And lblDiasCondicion.Text > 0 And CDbl(txtNeto.Text) > 0 Then
                TabPagCondicion.Visible = True
                TabPagCondicion.SelectedIndex = 0
                txtInicial.Text = CDbl(0.0).ToString("C")
                txtBalance.Text = CDbl(0.0).ToString("C")
                txtCantidadPagos.Text = 1
                txtMontoPagos.Text = txtBalance.Text
                txtAdicional.Text = CDbl(0.0).ToString("C")
                txtCondicionContado.Text = ""
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub chkHabilitarNota_CheckedChanged(sender As Object, e As EventArgs) Handles chkHabilitarNota.CheckedChanged
        If chkHabilitarNota.Checked = True Then
            If txtIDFactura.Text = "" Then
                lblNotaContado.Text = 1
                frm_int_notacontado.ShowDialog(Me)
            End If
        Else
            lblNotaContado.Text = 0
            txtCondicionContado.Clear()
        End If
    End Sub

    Private Sub ValidacionEnInicial()
        Dim Neto, Inicial As Double
        Neto = txtNeto.Text
        Inicial = txtInicial.Text

        If Inicial > Neto Then
            MessageBox.Show("El inicial introducido en la factura es mayor al balance a pagar. Verifique los datos y/o la condición de la factura.", "Error en el inicial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtInicial.Text = CDbl(0).ToString("C")
            txtInicial.Focus()
        End If

        CalcularMontoPago()

    End Sub

    Private Sub txtInicial_Leave(sender As Object, e As EventArgs) Handles txtInicial.Leave
        If txtInicial.Text = "" Then
            txtInicial.Text = (0).ToString("C")
            txtBalance.Text = txtNeto.Text
        Else
            If CDbl(txtInicial.Text) > 0 And CDbl(txtInicial.Text) >= CDbl(txtNeto.Text) Then
                MessageBox.Show("El inicial es igual al monto neto de la factura." & vbNewLine & vbNewLine & "Por favor cambie la condición de la factura a {CONTADO}.", "Error en Inicial", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtInicial.Text = CDbl(0).ToString("C")
                Exit Sub
            Else
                txtInicial.Text = CDbl(txtInicial.Text).ToString("C")
            End If
        End If

        ValidacionEnInicial()
        CreatePagares()
    End Sub

    Sub CalcNeto()
        Try
            txtNeto.Text = CDbl(CDbl(txtSubTotal.Text) - CDbl(TxtDescuentoSuma.Text) + CDbl(txtITBIS.Text) + CDbl(txtFlete.Text)).ToString("C")

            If CDbl(txtNeto.Text) > 0 And lblDiasCondicion.Text > 0 Then
                TabPagCondicion.Visible = True
                CalcularMontoPago()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSubTotal_TextChanged(sender As Object, e As EventArgs) Handles txtSubTotal.TextChanged
        CalcNeto()
    End Sub

    Private Sub TxtDescuentoSuma_TextChanged(sender As Object, e As EventArgs) Handles TxtDescuentoSuma.TextChanged
        CalcNeto()
    End Sub

    Private Sub ValidacionEnAdicional()
        Dim Balance, Adicional As Double
        Balance = txtBalance.Text
        Adicional = txtAdicional.Text

        If Adicional >= Balance Then
            MessageBox.Show("El adicional introducido en la factura es mayor o igual al balance a pagar. Verifique los datos y/o la condición de la factura.", "Error en el adicional", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtAdicional.Text = CDbl(0).ToString("C")
            txtAdicional.Focus()
            Exit Sub
        End If

        If CDbl(txtAdicional.Text) > 0 Then
            txtFechaAdicional.Enabled = True
            txtFechaAdicional.Focus()
        Else
            txtFechaAdicional.Enabled = False
        End If
    End Sub

    Private Sub txtInicial_TextChanged(sender As Object, e As EventArgs) Handles txtInicial.TextChanged
        CalcularMontoPago()
    End Sub

    Private Sub ValidarFechaAdicional()
        Try
            If CDbl(txtAdicional.Text) > 0 Then
                If IsDate(txtFechaAdicional.Text) Then
                    If CDate(txtFechaAdicional.Text) < CDate(txtFechaFactura.Text) Then
                        MessageBox.Show("La fecha del adicional introducida en la factura es menor a la fecha de la factura." & vbNewLine & vbNewLine & "Verifique los datos y/o la condición de la factura.", "Error en el adicional", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtFechaAdicional.Clear()
                        txtFechaAdicional.Focus()
                    End If
                Else
                    MessageBox.Show("El dato introducido no es una fecha válida.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtFechaAdicional.Clear()
                    txtFechaAdicional.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " ValidarFechaAdicional")
        End Try
    End Sub

    Private Sub txtFechaAdicional_Leave(sender As Object, e As EventArgs) Handles txtFechaAdicional.Leave
        ValidarFechaAdicional()
        CalcVencientoFactura()
        CreatePagares()
    End Sub

    Private Sub txtITBIS_TextChanged(sender As Object, e As EventArgs) Handles txtITBIS.TextChanged
        CalcNeto()
    End Sub

    Private Sub txtFlete_TextChanged(sender As Object, e As EventArgs) Handles txtFlete.TextChanged
        CalcNeto()
    End Sub

    Friend Sub CreatePagares()
        Try

            If txtIDFactura.Text = "" And lblDiasCondicion.Text > 0 Then
                DgvPagares.Rows.Clear()

                Dim lblNoPagare, txtFechaVencimiento, CvtLetra, Concepto As New Label
                Dim MontoDecimal As Decimal = CDbl(txtMontoPagos.Text)
                Dim DecimalResult As Decimal = MontoDecimal - Int(MontoDecimal)
                Dim Monto As Integer = MontoDecimal - DecimalResult
                Dim Valor As Integer = txtCantidadPagos.Text
                Dim Dias As Integer = txtDiasCondicion.Text
                Dim DateTake As Date = Today

                If CDbl(txtMontoPagos.Text) > 0 Then
                    lblNoPagare.Text = 1
                    CvtLetra.Text = Num2Text(CInt(Monto))
                    Concepto.Text = "BUENO Y VÁLIDO POR " & CvtLetra.Text & " PESOS CON " & CInt(DecimalResult * 100) & "/100"

Start:
                    DateTake = DateTake.AddDays(txtDiasCondicion.Text)

                    If EvitSabado = 1 Then
                        If DateTake.DayOfWeek = DayOfWeek.Saturday Then
                            DateTake = DateTake.AddDays(1)
                        Else
                        End If
                    End If
                    If EvitDomingo = 1 Then
                        If DateTake.DayOfWeek = DayOfWeek.Sunday Then
                            DateTake = DateTake.AddDays(1)
                        End If
                    End If

                    If Valor = DgvPagares.Rows.Count Then
                        GoTo Final
                    Else
                        DgvPagares.Rows.Add("", "", lblNoPagare.Text, txtCantidadPagos.Text, DateTake.ToString("yyyy-MM-dd"), Concepto.Text, txtMontoPagos.Text, txtMontoPagos.Text)

                        lblNoPagare.Text = CInt(lblNoPagare.Text) + 1

                        GoTo Start
                    End If
                End If
Final:
                CreateAdicional()
            End If

            CalcVencientoFactura()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CreateAdicional()
        Dim MontoAdicional As Integer = txtAdicional.Text
        Dim Concepto, CvtLetra As New Label

        CvtLetra.Text = Num2Text(CInt(MontoAdicional))
        Concepto.Text = "BUENO Y VÁLIDO POR " & CvtLetra.Text & " PESOS CON 00/100"

        If MontoAdicional = 0 Then
        Else
            DgvPagares.Rows.Add("", "", "ADC", "ADC", txtFechaAdicional.Text, Concepto.Text, txtAdicional.Text, txtAdicional.Text)

        End If

    End Sub

    Private Sub CalcularMontoPago()
        Try
            If lblDiasCondicion.Text > 0 Then
                Dim TotalAPagar As Double = txtBalance.Text
                Dim AdicionalaPagar As Double = txtAdicional.Text

                txtBalance.Text = (CDbl(txtNeto.Text) - CDbl(txtInicial.Text)).ToString("C")
                txtMontoPagos.Text = ((TotalAPagar - AdicionalaPagar) / CInt(txtCantidadPagos.Text))
                txtMontoPagos.Text = CDbl(txtMontoPagos.Text).ToString("C")
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " CalcularMontoPago")
        End Try
    End Sub

    Private Sub txtSubTotal_Leave(sender As Object, e As EventArgs) Handles txtSubTotal.Leave
        If txtSubTotal.Text = "" Then
            txtSubTotal.Text = CDbl(0).ToString("C")
        Else
            txtSubTotal.Text = CDbl(txtSubTotal.Text).ToString("C")
        End If

        CreatePagares()
    End Sub

    Private Sub TxtDescuentoSuma_Leave(sender As Object, e As EventArgs) Handles TxtDescuentoSuma.Leave
        If TxtDescuentoSuma.Text = "" Then
            TxtDescuentoSuma.Text = CDbl(0).ToString("C")
        Else
            TxtDescuentoSuma.Text = CDbl(TxtDescuentoSuma.Text).ToString("C")
        End If
        CreatePagares()
    End Sub

    Private Sub txtITBIS_Leave(sender As Object, e As EventArgs) Handles txtITBIS.Leave
        If txtITBIS.Text = "" Then
            txtITBIS.Text = CDbl(0).ToString("C")
        Else
            txtITBIS.Text = CDbl(txtITBIS.Text).ToString("C")
        End If
        CreatePagares()
    End Sub

    Private Sub txtFlete_Leave(sender As Object, e As EventArgs) Handles txtFlete.Leave
        If txtFlete.Text = "" Then
            txtFlete.Text = CDbl(0).ToString("C")
        Else
            txtFlete.Text = CDbl(txtFlete.Text).ToString("C")
        End If
        CreatePagares()
    End Sub

    Private Sub txtCantidadPagos_Leave(sender As Object, e As EventArgs)
        CreatePagares()
    End Sub

    Sub ConvertDouble()
        txtSubTotal.Text = CDbl(txtSubTotal.Text)
        txtITBIS.Text = CDbl(txtITBIS.Text)
        TxtDescuentoSuma.Text = CDbl(TxtDescuentoSuma.Text)
        txtFlete.Text = CDbl(txtFlete.Text)
        txtNeto.Text = CDbl(txtNeto.Text)
        txtInicial.Text = CDbl(txtInicial.Text)
        txtAdicional.Text = CDbl(txtAdicional.Text)
        txtBalance.Text = CDbl(txtBalance.Text)
        txtMontoPagos.Text = CDbl(txtMontoPagos.Text)

    End Sub

    Sub ConvertCurrent()
        txtInicial.Text = CDbl(txtInicial.Text).ToString("C")
        txtAdicional.Text = CDbl(txtAdicional.Text).ToString("C")
        txtSubTotal.Text = CDbl(txtSubTotal.Text).ToString("C")
        txtITBIS.Text = CDbl(txtITBIS.Text).ToString("C")
        TxtDescuentoSuma.Text = CDbl(TxtDescuentoSuma.Text).ToString("C")
        txtFlete.Text = CDbl(txtFlete.Text).ToString("C")
        txtNeto.Text = CDbl(txtNeto.Text).ToString("C")
        txtBalance.Text = CDbl(txtBalance.Text).ToString("C")
        txtMontoPagos.Text = CDbl(txtMontoPagos.Text).ToString("C")
    End Sub

    Private Sub BuscarFactVencidas()
        If lblDiasCondicion.Text > 0 Then
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select FechaVencimiento from FacturaDatos where IDCliente= '" + txtIDCliente.Text + "' and Balance>0 and FechaVencimiento<'" + Today.ToString("yyyy-MM-dd") + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "FacturaDatos")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("FacturaDatos")

            If Tabla.Rows.Count > 0 Then
                Dim Result As MsgBoxResult = MessageBox.Show("El cliente: " & txtNombre.Text & " [" & txtIDCliente.Text & "] tiene factura vencidas." & vbNewLine & vbNewLine & "Está seguro que desea continuar?", "Exiten Facturas Vencidas", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    frm_superclave.IDAccion.Text = 49
                    frm_superclave.ShowDialog(Me)
                Else
                    ControlSuperClave = 1
                End If
            End If
            BuscarLimiteCredito()
        End If
    End Sub

    Private Sub BuscarLimiteCredito()
        Try
            Dim LimiteCredito, SumBceFacts As New Label

            If lblDiasCondicion.Text > 0 Then

                ConLibregco.Open()
                cmd = New MySqlCommand("Select LimiteCredito from Clientes where IDCliente= '" + txtIDCliente.Text + "'", ConLibregco)
                LimiteCredito.Text = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From FacturaDatos where IDCliente= '" + txtIDCliente.Text + "' and Nulo=0", ConLibregco)
                SumBceFacts.Text = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()

                If CDbl(SumBceFacts.Text) + CDbl(txtBalance.Text) > CDbl(LimiteCredito.Text) Then
                    MessageBox.Show("La factura excede el límite de crédito [" & CDbl(LimiteCredito.Text).ToString("C") & "] aprobado al cliente. La factura no se generará.", "Excede crédito otorgado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ControlSuperClave = 1
                Else
                    ControlSuperClave = 0
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "Desde Buscar Limite Credito")
        End Try
    End Sub

    Private Sub StatusCliente()
        Try
            Dim NoRecibirCheques, CuentaIncobrable, CreditoCerrado As New Label

            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("Select CuentaIncobrable,CerrarCredito from Clientes where IDCliente= '" + txtIDCliente.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Clientes")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Clientes")

            CuentaIncobrable.Text = (Tabla.Rows(0).Item("CuentaIncobrable"))
            CreditoCerrado.Text = (Tabla.Rows(0).Item("CerrarCredito"))

            If CreditoCerrado.Text = 1 And lblDiasCondicion.Text > 0 Then
                MessageBox.Show("El cliente tiene el crédito cerrado." & vbNewLine & "Por favor verifique su historial para verificar su status crediticio.", "CREDITO CERRADO", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ControlSuperClave = 1
                Exit Sub
            Else
                ControlSuperClave = 0
            End If

            If CuentaIncobrable.Text = 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("El cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] " & "posee cuentas incobrables." & vbNewLine & "Es recomendable consultar el status con " & txtCobrador.Text & ", cobrador asignado actualmente." & vbNewLine & vbNewLine & "Está seguro que desea continuar con la factura?", "Posee cuentas incobrables", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    Exit Sub
                Else
                    ControlSuperClave = 1
                    Exit Sub
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "Desde Status Cliente")
        End Try
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDFactura.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea imprimir la factura?", "Imprimir Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If

        If DgvPagares.Rows.Count > 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir los pagarés de la factura?", "Impresión de pagarés", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                If frm_pagares.Visible = True Then
                    If frm_pagares.WindowState = FormWindowState.Minimized Then
                        frm_pagares.WindowState = FormWindowState.Normal
                    Else
                        frm_pagares.Activate()
                    End If
                    frm_pagares.lblIDFactura.Text = txtIDFactura.Text
                    frm_pagares.txtFactura.Text = txtSecondID.Text
                    frm_pagares.rdbPresentacion.Checked = True
                    frm_pagares.btnBuscar.PerformClick()
                Else
                    frm_pagares.Show(Me)
                    frm_pagares.lblIDFactura.Text = txtIDFactura.Text
                    frm_pagares.txtFactura.Text = txtSecondID.Text
                    frm_pagares.rdbPresentacion.Checked = True
                    frm_pagares.btnBuscar.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub VerificarCreacionPagare()
        If lblDiasCondicion.Text = 0 Then
        Else
            CreatePagares()
        End If

    End Sub

    Private Sub VerificarNCFs()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select Hasta,Ultimo from comprobantefiscal where IDComprobanteFiscal= '" + lblIDComprobante.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Comprobantefiscal")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Comprobantefiscal")

            If (Tabla.Rows(0).Item("Hasta")) = "" Then
            Else
                Dim Restantes As Integer = CInt(Tabla.Rows(0).Item("Hasta")) - CInt(Tabla.Rows(0).Item("Ultimo"))
                Dim DiasAlertas As Integer

                Con.Open()
                cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=12", Con)
                DiasAlertas = Convert.ToDouble(cmd.ExecuteScalar())
                Con.Close()

                If Restantes <= DiasAlertas Then

                    If Restantes <= 0 Then
                        Con.Open()
                        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=24", Con)
                        Dim FactNCFAgotado As String = Convert.ToString(cmd.ExecuteScalar())
                        Con.Close()

                        If FactNCFAgotado = 0 Then
                            MessageBox.Show("El sistema tiene bloqueado el procesamiento de facturas con comprobantes fiscales agotados.", "Configuración de NCF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            ControlSuperClave = 1
                            Exit Sub
                        End If

                        Dim Result As MsgBoxResult = MessageBox.Show("Los NCF del tipo " & CbxTipoComprobante.Text & " se han agotado. " & vbNewLine & "Está seguro que desea generar la factura?", "Generar Factura con NCF Agotado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        If Result = MsgBoxResult.Yes Then
                            MessageBox.Show("El sistema seguirá generando los comprobantes fiscales siguientes. Solicite inmediatamente a la DGII los correspondientes comprobantes fiscales.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                            ControlSuperClave = 0
                        Else
                            ControlSuperClave = 1
                        End If
                    Else
                        MessageBox.Show("ADVERTENCIA: Solo quedan " & Restantes & " comprobantes disponibles del tipo " & CbxTipoComprobante.Text & "." & vbNewLine & "Solicite a la DGII los correspondientes comprobantes fiscales.", "Advertencia de NCF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        ControlSuperClave = 0
                    End If

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento='" + lblIDTipoDocumento.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE FacturaDatos SET SecondID='" + lblSecondID.Text + "' WHERE IDFacturaDatos='" + txtIDFactura.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento='" + lblIDTipoDocumento.Text + "'"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertPagares()
        Dim lblIDPagare, lblIDFactura, lblNoPagare, lblCantidad, lblFechaVencimiento, lblDiasVencidos, lblConcepto, lblMonto, lblCargos, lblBalance, lblIDEmpleado, lblIDStatus, lblNota, lblNulo As New Label
        Dim x As Integer = 0
        Dim Counter As Integer = DgvPagares.RowCount

Inicio:
        If x = Counter Then
            GoTo Fin
        End If

        lblIDPagare.Text = DgvPagares.Rows(x).Cells(0).Value
        lblIDFactura.Text = DgvPagares.Rows(x).Cells(1).Value
        lblNoPagare.Text = DgvPagares.Rows(x).Cells(2).Value
        lblCantidad.Text = DgvPagares.Rows(x).Cells(3).Value
        lblFechaVencimiento.Text = DgvPagares.Rows(x).Cells(4).Value()
        lblDiasVencidos.Text = 0
        lblConcepto.Text = DgvPagares.Rows(x).Cells(5).Value
        lblMonto.Text = CDbl(DgvPagares.Rows(x).Cells(6).Value)
        lblBalance.Text = CDbl(DgvPagares.Rows(x).Cells(7).Value)
        lblIDEmpleado.Text = 1
        lblIDStatus.Text = 1
        lblNota.Text = ""
        lblNulo.Text = 0

        If lblIDPagare.Text = "" Then
            sqlQ = "INSERT INTO Pagares (IDFactura,NoPagare,Cantidad,FechaVencimiento,DiasVencidos,Concepto,Monto,Balance,IDEmpleado,IDStatusPagare,Nota,Nulo) VALUES ('" + txtIDFactura.Text + "','" + lblNoPagare.Text + "','" + lblCantidad.Text + "','" + lblFechaVencimiento.Text + "','" + lblDiasVencidos.Text + "','" + lblConcepto.Text + "','" + lblMonto.Text + "','" + lblBalance.Text + "','" + lblIDEmpleado.Text + "','" + lblIDStatus.Text + "','" + lblNota.Text + "','" + lblNulo.Text + "')"
            GuardarDatos()
        Else
            sqlQ = "UPDATE Pagares SET FechaVencimiento='" + lblFechaVencimiento.Text + "',Concepto='" + lblConcepto.Text + "',Monto='" + lblMonto.Text + "' WHERE IDPagare=(" + lblIDPagare.Text + ")"
            GuardarDatos()
        End If

        x = x + 1
        GoTo Inicio

Fin:

    End Sub

    Private Sub UltFactura()
        If txtIDFactura.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDFacturaDatos from FacturaDatos where IDFacturaDatos= (Select Max(IDFacturaDatos) from FacturaDatos)", Con)
            txtIDFactura.Text = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()
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
            MessageBox.Show(ex.Message & "Desde GuardarDatos1")
        End Try
    End Sub

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            lblNulo.Text = 1
            DeshabilitarControles()
        Else
            lblNulo.Text = 0
            HabilitarControles()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar la factura.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf CbxTipoComprobante.Text = "" Then
            MessageBox.Show("Seleccione el tipo de comprobante fiscal que genererá la factura.", "Seleccionar Tipo de NCF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxTipoComprobante.Focus()
            CbxTipoComprobante.DroppedDown = True
            Exit Sub
        ElseIf txtVendedor.Text = "" Then
            MessageBox.Show("Escriba el código del vendedor.", "Código del Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDVendedor.Focus()
            Exit Sub
        ElseIf lblDiasCondicion.Text > 0 And (CDbl(txtDiasCondicion.Text) * CDbl(txtCantidadPagos.Text)) > CDbl(lblDiasCondicion.Text) Then
            MessageBox.Show("La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente." & vbNewLine & vbNewLine & txtCantidadPagos.Text & " pagos cada " & txtDiasCondicion.Text & " días dan un total de " & (CDbl(txtCantidadPagos.Text) * CDbl(txtDiasCondicion.Text)) & " días", "Exceso de días en condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidadPagos.Text = 1
            Exit Sub
        ElseIf txtObservacion.Text = "" Then
            MessageBox.Show("Escriba un concepto para la factura.", "Escribir concepto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtNeto.Text = CDbl(0).ToString("C") Or txtNeto.Text = 0 Then
            MessageBox.Show("Escriba el monto de la factura a procesar.", "Monto de la factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf PerVentasSContrato = 0 And lblDiasCondicion.Text > 0 Then
            Con.Open()
            'BuscarCantidad de contratos a nombre del cliente
            cmd = New MySqlCommand("SELECT count(IDContrato) FROM contratos where IDCliente='" + txtIDCliente.Text + "' and FechaVencimiento>'" + Today + "'", Con)
            Dim CantContratos As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If CantContratos = 0 Then
                MessageBox.Show("No se han encontrado contratos de solicitud de crédito váalidos para procesar el crédito a procesar." & vbNewLine & vbNewLine & "Por favor realice un nuevo contrato para realizar créditos a nombre del cliente [" & txtIDCliente.Text & "] " & txtNombre.Text & ".", "No se encontraron contratos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If

        VerificarCreacionPagare()

        If txtIDFactura.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva factura a nombre del cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] en la base de datos?", "Guardar Nueva Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                StatusCliente()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                BuscarCedulaenCredito()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                BuscarFactVencidas()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                If SolicitarAutCredito = 1 Then
                    If lblDiasCondicion.Text > 0 Then
                        frm_usuarios_recepcion_solicitud.ShowDialog(Me)

                        If frm_autorizacion_acciones.IDEmpleadoAvisa.Text = "" Then
                            frm_autorizacion_acciones.IDEmpleadoAvisa.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
                        End If

                        frm_autorizacion_acciones.IDAccion.Text = 17
                        frm_autorizacion_acciones.lblAccion.Text = "Control de ventas a crédito (Autorización de ventas)"
                        frm_autorizacion_acciones.ShowDialog(Me)

                        If ControlSuperClave = 1 Then
                            Exit Sub
                        End If
                    End If
                End If


                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                GetNCFsNumbers(lblIDComprobante.Text)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If


                CambiarBalance()
                ConvertDouble()
                sqlQ = "INSERT INTO Facturadatos (IDEquipo,IDEstadoFactura,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDTipoDocumento,IDTransaccion,NCF,NIF,IDCondicion,DiasCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDChofer,IDVehiculo,IDVendedor,IDUsuario,Fecha,Hora,Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FechaVencimiento,NotaContado,CondicionContado,SubTotal,Descuento,Itbis,ItbisRetenido,ItbisPercibido,RetencionRenta,ISRPercibido,ISC,OtrosImpuestos,PropinaLegal,Flete,TotalNeto,Cargos,Balance,HabilitarFicha,DiasVencidos,Status,Observacion,Cierre,Impreso,EntregarPorConduce,IDTipoIngreso,Nulo,NetoLetra) VALUES ('" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',1,'" + txtIDCliente.Text + "','" + txtNombre.Text + "','" + txtRNC.Text + "','" + txtDireccion.Text + "','" + txtTelefonos.Text + "','" + lblIDTipoDocumento.Text + "', '" + lblIDTransaccion.Text + "','" + NewNCFValue.Text + "','" + txtNIF.Text + "','" + lblCondicion.Text + "','" + txtDiasCondicion.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + lblIDAlmacen.Text + "','" + lblIDComprobante.Text + "','1','1','" + txtIDVendedor.Text + "','" + lblIDUsuario.Text + "','" + txtFechaFactura.Text + "','" + txtHoraFactura.Text + "','" + txtInicial.Text + "','" + txtCantidadPagos.Text + "','" + txtMontoPagos.Text + "','" + txtAdicional.Text + "','" + txtFechaAdicional.Text + "','" + txtBalance.Text + "','" + txtFechaVencimiento.Text + "','" + lblNotaContado.Text + "','" + txtCondicionContado.Text + "','" + txtSubTotal.Text + "','" + TxtDescuentoSuma.Text + "','" + txtITBIS.Text + "',0,0,0,0,0,0,0,'" + txtFlete.Text + "','" + txtNeto.Text + "',0,'" + txtBalance.Text + "','" + lblFichaDatos.Text + "',0,'ACTIVA','" + txtObservacion.Text + "',0,0,'" + lblchkEntregaConduce.Text + "',1,'" + lblNulo.Text + "','" + ConvertNumbertoString(CDbl(txtNeto.Text)).ToString + "')"
                GuardarDatos()
                ConvertCurrent()
                UltFactura()
                SetSecondID()
                InsertPagares()
                CalcularBalance()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la factura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ConvertDouble()
                sqlQ = "UPDATE FacturaDatos SET IDCliente='" + txtIDCliente.Text + "',NombreFactura='" + txtNombre.Text + "',IdentificacionFactura='" + txtRNC.Text + "',DireccionFactura='" + txtDireccion.Text + "',TelefonosFactura='" + txtTelefonos.Text + "',IDTipoDocumento='" + lblIDTipoDocumento.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',NIF='" + txtNIF.Text + "',IDCondicion='" + lblCondicion.Text + "',DiasCondicion='" + txtDiasCondicion.Text + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDComprobanteFiscal='" + lblIDComprobante.Text + "',IDVendedor='" + txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFechaFactura.Text + "',Hora='" + txtHoraFactura.Text + "',Inicial='" + txtInicial.Text + "',CantidadPagos='" + txtCantidadPagos.Text + "',MontoPagos='" + txtMontoPagos.Text + "',PagoAdicional='" + txtAdicional.Text + "',FechaAdicional='" + txtFechaAdicional.Text + "',NetoFactura='" + txtBalance.Text + "',FechaVencimiento='" + txtFechaVencimiento.Text + "',NotaContado='" + lblNotaContado.Text + "',CondicionContado='" + txtCondicionContado.Text + "',SubTotal='" + txtSubTotal.Text + "',Descuento='" + TxtDescuentoSuma.Text + "',Itbis='" + txtITBIS.Text + "',Flete='" + txtFlete.Text + "',TotalNeto='" + txtNeto.Text + "',HabilitarFicha='" + lblFichaDatos.Text + "',Observacion='" + txtObservacion.Text + "',EntregarPorConduce='" + lblchkEntregaConduce.Text + "',Nulo='" + lblNulo.Text + "',NetoLetra='" + ConvertNumbertoString(CDbl(txtNeto.Text)).ToString + "' WHERE IDFacturaDatos= (" + txtIDFactura.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcularBalance()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub CalcularBalance()
        FunctCalcBcesFact(txtIDCliente.Text)
        FunctCalcBceGral(txtIDCliente.Text)
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar la factura.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf CbxTipoComprobante.Text = "" Then
            MessageBox.Show("Seleccione el tipo de comprobante fiscal que genererá la factura.", "Seleccionar Tipo de NCF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxTipoComprobante.Focus()
            CbxTipoComprobante.DroppedDown = True
            Exit Sub
        ElseIf txtVendedor.Text = "" Then
            MessageBox.Show("Escriba el código del vendedor.", "Código del Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDVendedor.Focus()
            Exit Sub
        ElseIf lblDiasCondicion.Text > 0 And (CDbl(txtDiasCondicion.Text) * CDbl(txtCantidadPagos.Text)) > CDbl(lblDiasCondicion.Text) Then
            MessageBox.Show("La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente." & vbNewLine & vbNewLine & txtCantidadPagos.Text & " pagos cada " & txtDiasCondicion.Text & " días dan un total de " & (CDbl(txtCantidadPagos.Text) * CDbl(txtDiasCondicion.Text)) & " días", "Exceso de días en condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidadPagos.Text = 1
            Exit Sub
        ElseIf txtObservacion.Text = "" Then
            MessageBox.Show("Escriba un concepto para la factura.", "Escribir concepto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtNeto.Text = CDbl(0).ToString("C") Or txtNeto.Text = 0 Then
            MessageBox.Show("Escriba el monto de la factura a procesar.", "Monto de la factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf PerVentasSContrato = 0 And lblDiasCondicion.Text > 0 Then
            'BuscarCantidad de contratos a nombre del cliente
            cmd = New MySqlCommand("SELECT count(IDContrato) FROM contratos where IDCliente='" + txtIDCliente.Text + "' and FechaVencimiento>'" + Today + "'", Con)
            Dim CantContratos As String = Convert.ToString(cmd.ExecuteScalar())

            If CantContratos = 0 Then
                MessageBox.Show("No se han encontrado contratos de solicitud de crédito váalidos para procesar el crédito a procesar." & vbNewLine & vbNewLine & "Por favor realice un nuevo contrato para realizar créditos a nombre del cliente [" & txtIDCliente.Text & "] " & txtNombre.Text & ".", "No se encontraron contratos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If

        VerificarCreacionPagare()

        If txtIDFactura.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva factura a nombre del cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] en la base de datos?", "Guardar Nueva Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                StatusCliente()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                BuscarCedulaenCredito()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                BuscarFactVencidas()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                If SolicitarAutCredito = 1 And lblDiasCondicion.Text > 0 Then
                    frm_autorizacion_acciones.ShowDialog(Me)
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If


                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                GetNCFsNumbers(lblIDComprobante.Text)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If


                CambiarBalance()
                ConvertDouble()
                sqlQ = "INSERT INTO Facturadatos (IDEquipo,IDEstadoFactura,IDCliente,NombreFactura,IdentificacionFactura,DireccionFactura,TelefonosFactura,IDTipoDocumento,IDTransaccion,NCF,NIF,IDCondicion,DiasCondicion,IDSucursal,IDAlmacen,IDComprobanteFiscal,IDChofer,IDVehiculo,IDVendedor,IDUsuario,Fecha,Hora,Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FechaVencimiento,NotaContado,CondicionContado,SubTotal,Descuento,Itbis,ItbisRetenido,ItbisPercibido,RetencionRenta,ISRPercibido,ISC,OtrosImpuestos,PropinaLegal,Flete,TotalNeto,Cargos,Balance,HabilitarFicha,DiasVencidos,Status,Observacion,Cierre,Impreso,EntregarPorConduce,IDTipoIngreso,Nulo,NetoLetra) VALUES ('" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',1,'" + txtIDCliente.Text + "','" + txtNombre.Text + "','" + txtRNC.Text + "','" + txtDireccion.Text + "','" + txtTelefonos.Text + "','" + lblIDTipoDocumento.Text + "', '" + lblIDTransaccion.Text + "','" + NewNCFValue.Text + "','" + txtNIF.Text + "','" + lblCondicion.Text + "','" + txtDiasCondicion.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + lblIDAlmacen.Text + "','" + lblIDComprobante.Text + "','1','1','" + txtIDVendedor.Text + "','" + lblIDUsuario.Text + "','" + txtFechaFactura.Text + "','" + txtHoraFactura.Text + "','" + txtInicial.Text + "','" + txtCantidadPagos.Text + "','" + txtMontoPagos.Text + "','" + txtAdicional.Text + "','" + txtFechaAdicional.Text + "','" + txtBalance.Text + "','" + txtFechaVencimiento.Text + "','" + lblNotaContado.Text + "','" + txtCondicionContado.Text + "','" + txtSubTotal.Text + "','" + TxtDescuentoSuma.Text + "','" + txtITBIS.Text + "',0,0,0,0,0,0,0,'" + txtFlete.Text + "','" + txtNeto.Text + "',0,'" + txtBalance.Text + "','" + lblFichaDatos.Text + "',0,'ACTIVA','" + txtObservacion.Text + "',0,0,'" + lblchkEntregaConduce.Text + "',1,'" + lblNulo.Text + "','" + ConvertNumbertoString(CDbl(txtNeto.Text)).ToString + "')"
                GuardarDatos()
                ConvertCurrent()
                UltFactura()
                SetSecondID()
                InsertPagares()
                CalcularBalance()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la factura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ConvertDouble()
                sqlQ = "UPDATE FacturaDatos SET IDCliente='" + txtIDCliente.Text + "',NombreFactura='" + txtNombre.Text + "',IdentificacionFactura='" + txtRNC.Text + "',DireccionFactura='" + txtDireccion.Text + "',TelefonosFactura='" + txtTelefonos.Text + "',IDTipoDocumento='" + lblIDTipoDocumento.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',NIF='" + txtNIF.Text + "',IDCondicion='" + lblCondicion.Text + "',DiasCondicion='" + txtDiasCondicion.Text + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDComprobanteFiscal='" + lblIDComprobante.Text + "',IDVendedor='" + txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFechaFactura.Text + "',Hora='" + txtHoraFactura.Text + "',Inicial='" + txtInicial.Text + "',CantidadPagos='" + txtCantidadPagos.Text + "',MontoPagos='" + txtMontoPagos.Text + "',PagoAdicional='" + txtAdicional.Text + "',FechaAdicional='" + txtFechaAdicional.Text + "',NetoFactura='" + txtBalance.Text + "',FechaVencimiento='" + txtFechaVencimiento.Text + "',NotaContado='" + lblNotaContado.Text + "',CondicionContado='" + txtCondicionContado.Text + "',SubTotal='" + txtSubTotal.Text + "',Descuento='" + TxtDescuentoSuma.Text + "',Itbis='" + txtITBIS.Text + "',Flete='" + txtFlete.Text + "',TotalNeto='" + txtNeto.Text + "',HabilitarFicha='" + lblFichaDatos.Text + "',Observacion='" + txtObservacion.Text + "',EntregarPorConduce='" + lblchkEntregaConduce.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDFacturaDatos= (" + txtIDFactura.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcularBalance()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_factura_sd.ShowDialog(Me)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La factura No. " & txtIDFactura.Text & " del cliente " & txtNombre.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 104
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE FacturaDatos SET IDCliente='" + txtIDCliente.Text + "',NombreFactura='" + txtNombre.Text + "',IdentificacionFactura='" + txtRNC.Text + "',DireccionFactura='" + txtDireccion.Text + "',TelefonosFactura='" + txtTelefonos.Text + "',IDTipoDocumento='" + lblIDTipoDocumento.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',NIF='" + txtNIF.Text + "',IDCondicion='" + lblCondicion.Text + "',DiasCondicion='" + txtDiasCondicion.Text + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDComprobanteFiscal='" + lblIDComprobante.Text + "',IDVendedor='" + txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFechaFactura.Text + "',Hora='" + txtHoraFactura.Text + "',Inicial='" + txtInicial.Text + "',CantidadPagos='" + txtCantidadPagos.Text + "',MontoPagos='" + txtMontoPagos.Text + "',PagoAdicional='" + txtAdicional.Text + "',FechaAdicional='" + txtFechaAdicional.Text + "',NetoFactura='" + txtBalance.Text + "',FechaVencimiento='" + txtFechaVencimiento.Text + "',NotaContado='" + lblNotaContado.Text + "',CondicionContado='" + txtCondicionContado.Text + "',SubTotal='" + txtSubTotal.Text + "',Descuento='" + TxtDescuentoSuma.Text + "',Itbis='" + txtITBIS.Text + "',Flete='" + txtFlete.Text + "',TotalNeto='" + txtNeto.Text + "',HabilitarFicha='" + lblFichaDatos.Text + "',Observacion='" + txtObservacion.Text + "',EntregarPorConduce='" + lblchkEntregaConduce.Text + "',Nulo='" + lblNulo.Text + "',NetoLetra='" + ConvertNumbertoString(CDbl(txtNeto.Text)).ToString + "' WHERE IDFacturaDatos= (" + txtIDFactura.Text + ")"
                GuardarDatos()
                CalcularBalance()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDFactura.Text = "" Then
            MessageBox.Show("No hay un registro de factura abierto para anular.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular la factura No. " & txtIDFactura.Text & " del cliente " & txtNombre.Text & " del sistema?", "Anular Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 105
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE FacturaDatos SET IDCliente='" + txtIDCliente.Text + "',NombreFactura='" + txtNombre.Text + "',IdentificacionFactura='" + txtRNC.Text + "',DireccionFactura='" + txtDireccion.Text + "',TelefonosFactura='" + txtTelefonos.Text + "',IDTipoDocumento='" + lblIDTipoDocumento.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',NIF='" + txtNIF.Text + "',IDCondicion='" + lblCondicion.Text + "',DiasCondicion='" + txtDiasCondicion.Text + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDComprobanteFiscal='" + lblIDComprobante.Text + "',IDVendedor='" + txtIDVendedor.Text + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFechaFactura.Text + "',Hora='" + txtHoraFactura.Text + "',Inicial='" + txtInicial.Text + "',CantidadPagos='" + txtCantidadPagos.Text + "',MontoPagos='" + txtMontoPagos.Text + "',PagoAdicional='" + txtAdicional.Text + "',FechaAdicional='" + txtFechaAdicional.Text + "',NetoFactura='" + txtBalance.Text + "',FechaVencimiento='" + txtFechaVencimiento.Text + "',NotaContado='" + lblNotaContado.Text + "',CondicionContado='" + txtCondicionContado.Text + "',SubTotal='" + txtSubTotal.Text + "',Descuento='" + TxtDescuentoSuma.Text + "',Itbis='" + txtITBIS.Text + "',Flete='" + txtFlete.Text + "',TotalNeto='" + txtNeto.Text + "',HabilitarFicha='" + lblFichaDatos.Text + "',Observacion='" + txtObservacion.Text + "',EntregarPorConduce='" + lblchkEntregaConduce.Text + "',Nulo='" + lblNulo.Text + "',NetoLetra='" + ConvertNumbertoString(CDbl(txtNeto.Text)).ToString + "' WHERE IDFacturaDatos= (" + txtIDFactura.Text + ")"
                GuardarDatos()
                CalcularBalance()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub txtSubTotal_Enter(sender As Object, e As EventArgs) Handles txtSubTotal.Enter
        If txtSubTotal.Text = "" Then
        Else
            txtSubTotal.Text = CDbl(txtSubTotal.Text)
        End If
    End Sub

    Private Sub TxtDescuentoSuma_Enter(sender As Object, e As EventArgs) Handles TxtDescuentoSuma.Enter
        If TxtDescuentoSuma.Text = "" Then
        Else
            TxtDescuentoSuma.Text = CDbl(TxtDescuentoSuma.Text)
        End If
    End Sub

    Private Sub txtITBIS_Enter(sender As Object, e As EventArgs) Handles txtITBIS.Enter
        If txtITBIS.Text = "" Then
        Else
            txtITBIS.Text = CDbl(txtITBIS.Text)
        End If
    End Sub

    Private Sub txtFlete_Enter(sender As Object, e As EventArgs) Handles txtFlete.Enter
        If txtFlete.Text = "" Then
        Else
            txtFlete.Text = CDbl(txtFlete.Text)
        End If
    End Sub

    Private Sub BuscarCedulaenCredito()
        If IdentObligCred = 1 Then
            If lblDiasCondicion.Text > 0 Then
                ConLibregco.Open()
                cmd = New MySqlCommand("Select Clientes.Identificacion from Clientes where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
                Dim IdentInserted As String = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()

                If IdentInserted.Length > 0 Then
                    IdentInserted = Replace(IdentInserted, "_", "")
                    IdentInserted = Replace(IdentInserted, "-", "")
                End If

                If IdentInserted.Trim = "" Then
                    MessageBox.Show("El cliente: [" & txtIDCliente.Text & "] " & txtNombre.Text & " no tiene un número de identificación/cédula válido para procesar facturas a crédito." & vbNewLine & vbNewLine & "Por favor inserte el número de identificación del cliente para procesar la factura.", "No tiene No. de Identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ControlSuperClave = 1
                Else
                    ControlSuperClave = 0
                End If
            End If
        Else
            ControlSuperClave = 0
        End If
    End Sub


    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtFechaFactura.Text = Today.ToString("yyyy-MM-dd")
        txtHoraFactura.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Sub RefrescarTablaPagares()
        Try
            DgvPagares.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("Select IDPagare,IDFactura,NoPagare,Cantidad,FechaVencimiento,Concepto,Monto,Balance from Pagares where IDFactura='" + txtIDFactura.Text + "'", Con)
            Dim LectorPagares As MySqlDataReader = Consulta.ExecuteReader

            While LectorPagares.Read
                DgvPagares.Rows.Add(LectorPagares.GetValue(0), LectorPagares.GetValue(1), LectorPagares.GetValue(2), LectorPagares.GetValue(3), LectorPagares.GetValue(4), LectorPagares.GetValue(5), LectorPagares.GetValue(6), LectorPagares.GetValue(7))
            End While
            LectorPagares.Close()
            Con.Close()
            PropiedadesDgvPagares()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
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

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub BuscarFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarFacturaToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub txtSubTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSubTotal.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub txtDiasCondicion_Leave(sender As Object, e As EventArgs) Handles txtDiasCondicion.Leave
        If txtDiasCondicion.Text = "" Then
            txtDiasCondicion.Text = DefaultDiasCondicion
        End If

        If (CDbl(txtDiasCondicion.Text) * CDbl(txtCantidadPagos.Text)) > CDbl(lblDiasCondicion.Text) Then
            MessageBox.Show("La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente." & vbNewLine & vbNewLine & txtCantidadPagos.Text & " pagos cada " & txtDiasCondicion.Text & " días dan un total de " & (CDbl(txtCantidadPagos.Text) * CDbl(txtDiasCondicion.Text)) & " días", "Exceso de días en condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidadPagos.Text = 1
        End If

        CreatePagares()
    End Sub

    Private Sub TxtDescuentoSuma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDescuentoSuma.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub txtITBIS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtITBIS.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub txtFlete_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFlete.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub txtDiasCondicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasCondicion.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtInicial_Enter(sender As Object, e As EventArgs) Handles txtInicial.Enter
        If txtInicial.Text = "" Then
        Else
            txtInicial.Text = CDbl(txtInicial.Text)
        End If
    End Sub

    Private Sub txtCantidadPagos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadPagos.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCantidadPagos_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadPagos.TextChanged
        CalcularMontoPago()
    End Sub

    Private Sub txtCantidadPagos_Leave_1(sender As Object, e As EventArgs) Handles txtCantidadPagos.Leave
        If txtCantidadPagos.Text = "" Or txtCantidadPagos.Text = 0 Then
            txtCantidadPagos.Text = 1
        End If

        If (CDbl(txtDiasCondicion.Text) * CDbl(txtCantidadPagos.Text)) > CDbl(lblDiasCondicion.Text) Then
            MessageBox.Show("La cantidad de pagos bajo la condición de " & txtDiasCondicion.Text & " días excede la cantidad de días otorgada al cliente." & vbNewLine & vbNewLine & txtCantidadPagos.Text & " pagos cada " & txtDiasCondicion.Text & " días dan un total de " & (CDbl(txtCantidadPagos.Text) * CDbl(txtDiasCondicion.Text)) & " días", "Exceso de días en condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidadPagos.Text = 1
        End If

        CreatePagares()
    End Sub

    Private Sub txtAdicional_TextChanged(sender As Object, e As EventArgs) Handles txtAdicional.TextChanged
        CalcularMontoPago()
    End Sub

    Private Sub txtAdicional_Leave(sender As Object, e As EventArgs) Handles txtAdicional.Leave
        If txtAdicional.Text = "" Then
            txtAdicional.Text = CDbl(0).ToString("C")
            txtFechaAdicional.Clear()

        Else
            txtAdicional.Text = CDbl(txtAdicional.Text).ToString("C")
        End If
        ValidacionEnAdicional()
    End Sub

    Private Sub txtAdicional_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAdicional.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtAdicional_Enter(sender As Object, e As EventArgs) Handles txtAdicional.Enter
        If txtAdicional.Text = "" Then
        Else
            txtAdicional.Text = CDbl(txtAdicional.Text)
        End If
    End Sub

    Private Sub txtFechaAdicional_TextChanged(sender As Object, e As EventArgs) Handles txtFechaAdicional.TextChanged
        If txtFechaAdicional.Text = "" Then
        Else
            txtFechaAdicional.Mask = "0000-00-00"
            txtFechaAdicional.SelectionStart = 1
        End If
    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        lblCondicion.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT Dias FROM Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        lblDiasCondicion.Text = Convert.ToString(cmd.ExecuteScalar())

        ConLibregco.Close()

        If lblDiasCondicion.Text = 0 Then
            AjCondContado()
            SetIDTipoDocumento()
        Else
            AjCondCredito()
            CalcVencientoFactura()
            SetIDTipoDocumento()
        End If


    End Sub

    Private Sub cbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAlmacen.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + cbxAlmacen.SelectedItem + "'", Con)
        lblIDAlmacen.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub GbClientes_Leave(sender As Object, e As EventArgs) Handles GbClientes.Leave
        If txtDireccion.Visible = True Then
            GbClientes.Size = New Size(GbClientes.Size.Width, 78)
            lblDireccion.Visible = False
            lblTelefonos.Visible = False
            txtDireccion.Visible = False
            txtTelefonos.Visible = False
            lblRNC.Visible = False
            txtRNC.Visible = False
        End If
    End Sub

    Private Sub lblModificar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblModificar.LinkClicked
        If txtDireccion.Visible = False Then
            GbClientes.Size = New Size(GbClientes.Size.Width, GbClientes.Size.Height + 78)
            txtNombre.Enabled = True
            txtNombre.ReadOnly = False
            lblDireccion.Visible = True
            lblTelefonos.Visible = True
            txtDireccion.Visible = True
            txtTelefonos.Visible = True
            lblRNC.Visible = True
            txtRNC.Visible = True
            txtNombre.Focus()
        Else
            GbClientes.Size = New Size(GbClientes.Size.Width, GbClientes.Size.Height - 78)
            txtNombre.Enabled = False
            txtNombre.ReadOnly = True
            lblDireccion.Visible = False
            lblTelefonos.Visible = False
            txtDireccion.Visible = False
            txtTelefonos.Visible = False
            lblRNC.Visible = False
            txtRNC.Visible = False
        End If
    End Sub

    Private Sub Label34_Click(sender As Object, e As EventArgs) Handles Label34.Click
        If txtDireccion.Visible = True Then
            GbClientes.Size = New Size(GbClientes.Size.Width, GbClientes.Size.Height - 78)
            lblDireccion.Visible = False
            lblTelefonos.Visible = False
            txtDireccion.Visible = False
            txtTelefonos.Visible = False
            lblRNC.Visible = False
            txtRNC.Visible = False
        Else
            lblDireccion.Visible = True
            lblTelefonos.Visible = True
            txtDireccion.Visible = True
            txtTelefonos.Visible = True
            lblRNC.Visible = True
            txtRNC.Visible = True
        End If
    End Sub

    Private Sub chkEntregarporConduce_CheckedChanged(sender As Object, e As EventArgs) Handles chkEntregarporConduce.CheckedChanged
        If chkEntregarporConduce.Checked = True Then
            lblchkEntregaConduce.Text = 1
        Else
            lblchkEntregaConduce.Text = 0
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub txtIDVendedor_Leave(sender As Object, e As EventArgs) Handles txtIDVendedor.Leave
        If ChangedCodeEmployee = True And txtIDVendedor.Text <> "" Then
            frm_contraseña_empleado.txtUsuario.Tag = txtIDVendedor.Text
            frm_contraseña_empleado.ShowDialog(Me)
        Else
            If txtIDVendedor.Text <> "" Then
                If txtVendedor.Text = "" Then
                    frm_contraseña_empleado.txtUsuario.Tag = txtIDVendedor.Text
                    frm_contraseña_empleado.ShowDialog(Me)
                End If
            Else
                txtIDVendedor.Clear()
                txtVendedor.Clear()
            End If
        End If
    End Sub

    Private Sub txtIDVendedor_TextChanged(sender As Object, e As EventArgs) Handles txtIDVendedor.TextChanged
        ChangedCodeEmployee = True
    End Sub


End Class