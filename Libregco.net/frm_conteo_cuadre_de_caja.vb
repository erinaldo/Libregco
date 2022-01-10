Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_conteo_cuadre_de_caja

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList

    Private Sub frm_conteo_cuadre_de_caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        ActualizarTodo()
    End Sub

    Private Sub btn_Suplidor_Click(sender As Object, e As EventArgs) Handles btn_Suplidor.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()

        If Me.Owner.Name = frm_corte_caja.Name Then
            GroupBox1.Visible = False
            Panel1.Visible = False
            btnPresentar.Visible = False
            btnElegir.Visible = True
        Else
            GroupBox1.Visible = True
            Panel1.Visible = True
            btnPresentar.Visible = True
            btnElegir.Visible = False
        End If
    End Sub

    Private Sub x2000_TextChanged(sender As Object, e As EventArgs) Handles x2000.TextChanged
        Try
            If x2000.Text = "" Then
            Else
                Tx2000.Text = (CDbl(x2000.Text) * 2000).ToString("C")
                OperacionesdeSuma()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub x1000_TextChanged(sender As Object, e As EventArgs) Handles x1000.TextChanged
        Try
            If x1000.Text = "" Then
            Else
                Tx1000.Text = (CDbl(x1000.Text) * 1000).ToString("C")
                OperacionesdeSuma()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub x500_TextChanged(sender As Object, e As EventArgs) Handles x500.TextChanged
        Try
            If x500.Text = "" Then
            Else
                Tx500.Text = (CDbl(x500.Text) * 500).ToString("C")
                OperacionesdeSuma()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub x200_TextChanged(sender As Object, e As EventArgs) Handles x200.TextChanged
        Try
            If x200.Text = "" Then
            Else
                Tx200.Text = (CDbl(x200.Text) * 200).ToString("C")
                OperacionesdeSuma()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub x100_TextChanged(sender As Object, e As EventArgs) Handles x100.TextChanged
        Try
            If x100.Text = "" Then
            Else
                Tx100.Text = (CDbl(x100.Text) * 100).ToString("C")
                OperacionesdeSuma()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub x50_TextChanged(sender As Object, e As EventArgs) Handles x50.TextChanged
        Try
            If x50.Text = "" Then
            Else
                Tx50.Text = (CDbl(x50.Text) * 50).ToString("C")
                OperacionesdeSuma()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub x25_TextChanged(sender As Object, e As EventArgs) Handles x25.TextChanged
        Try
            If x25.Text = "" Then
            Else
                Tx25.Text = (CDbl(x25.Text) * 25).ToString("C")
                OperacionesdeSuma()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub x20_TextChanged(sender As Object, e As EventArgs) Handles x20.TextChanged
        Try
            If x20.Text = "" Then
            Else
                Tx20.Text = (CDbl(x20.Text) * 20).ToString("C")
                OperacionesdeSuma()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub x10_TextChanged(sender As Object, e As EventArgs) Handles x10.TextChanged
        Try
            If x10.Text = "" Then
            Else
                Tx10.Text = (CDbl(x10.Text) * 10).ToString("C")
                OperacionesdeSuma()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub x5_TextChanged(sender As Object, e As EventArgs) Handles x5.TextChanged
        Try
            If x5.Text = "" Then
            Else
                Tx5.Text = (CDbl(x5.Text) * 5).ToString("C")
                OperacionesdeSuma()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub x1_TextChanged(sender As Object, e As EventArgs) Handles x1.TextChanged
        Try
            If x1.Text = "" Then
            Else
                Tx1.Text = (CDbl(x1.Text) * 1).ToString("C")
                OperacionesdeSuma()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SumEfectivo()
        Try
            txtEfectivo.Text = (CDbl(Tx2000.Text) + CDbl(Tx1000.Text) + CDbl(Tx500.Text) + CDbl(Tx200.Text) + CDbl(Tx100.Text) + CDbl(Tx50.Text) + CDbl(Tx25.Text) + CDbl(Tx20.Text) + CDbl(Tx10.Text) + CDbl(Tx5.Text) + CDbl(Tx1.Text)).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub x1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles x500.KeyPress, x50.KeyPress, x5.KeyPress, x25.KeyPress, x2000.KeyPress, x200.KeyPress, x20.KeyPress, x1000.KeyPress, x100.KeyPress, x10.KeyPress, x1.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub ActualizarTodo()
        'Tasa Dolar
        ConLibregco.Open()
        cmd = New MySqlCommand("Select TasaCompra from TipoMoneda Where IDTipoMoneda=2", ConLibregco)
        txtTasaDolar.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
        ConLibregco.Close()

        If Me.Owner.Name <> frm_corte_caja.Name Then
            x2000.Text = 0
            x1000.Text = 0
            x500.Text = 0
            x200.Text = 0
            x100.Text = 0
            x50.Text = 0
            x25.Text = 0
            x20.Text = 0
            x10.Text = 0
            x5.Text = 0
            x1.Text = 0
            txtInicialCaja.Text = CDbl(0).ToString("C")
            txtEfectivo.Text = CDbl(0).ToString("C")
            txtCheque.Text = CDbl(0).ToString("C")
            txtTarjeta.Text = CDbl(0).ToString("C")
            txtDolares.Text = CDbl(0).ToString("C")
            txtDepositos.Text = CDbl(0).ToString("C")
            txtOtrosIngresos.Text = CDbl(0).ToString("C")
            txtTotalIngresos.Text = CDbl(0).ToString("C")
            txtDevolucion.Text = CDbl(0).ToString("C")
            txtEgreso.Text = CDbl(0).ToString("C")
            txtOtrosEgresos.Text = CDbl(0).ToString("C")
            txtTotalEgresos.Text = CDbl(0).ToString("C")
            txtCantidadDolar.Text = 0
            txtTotal.Text = CDbl(0).ToString("C")
            txtIDUsuario.Clear()
            txtUsuario.Clear()
            dtpFecha.Value = Today
            dtpFecha.Focus()
        End If

    End Sub

    Private Sub x2000_Leave(sender As Object, e As EventArgs) Handles x2000.Leave
        If x2000.Text = "" Then
            x2000.Text = 0
        End If
    End Sub

    Private Sub x1000_Leave(sender As Object, e As EventArgs) Handles x1000.Leave
        If x1000.Text = "" Then
            x1000.Text = 0
        End If
    End Sub

    Private Sub x500_Leave(sender As Object, e As EventArgs) Handles x500.Leave
        If x500.Text = "" Then
            x500.Text = 0
        End If

    End Sub

    Private Sub x200_Leave(sender As Object, e As EventArgs) Handles x200.Leave
        If x200.Text = "" Then
            x200.Text = 0
        End If
    End Sub

    Private Sub x100_Leave(sender As Object, e As EventArgs) Handles x100.Leave
        If x100.Text = "" Then
            x100.Text = 0
        End If
    End Sub

    Private Sub x50_Leave(sender As Object, e As EventArgs) Handles x50.Leave
        If x50.Text = "" Then
            x50.Text = 0
        End If
    End Sub

    Private Sub x25_Leave(sender As Object, e As EventArgs) Handles x25.Leave
        If x25.Text = "" Then
            x25.Text = 0
        End If
    End Sub

    Private Sub x20_Leave(sender As Object, e As EventArgs) Handles x20.Leave
        If x20.Text = "" Then
            x20.Text = 0
        End If
    End Sub

    Private Sub x10_Leave(sender As Object, e As EventArgs) Handles x10.Leave
        If x10.Text = "" Then
            x10.Text = 0
        End If
    End Sub

    Private Sub x5_Leave(sender As Object, e As EventArgs) Handles x5.Leave
        If x5.Text = "" Then
            x5.Text = 0
        End If
    End Sub

    Private Sub x1_Leave(sender As Object, e As EventArgs) Handles x1.Leave
        If x1.Text = "" Then
            x1.Text = 0
        End If
    End Sub

    Private Sub txtInicialCaja_Leave(sender As Object, e As EventArgs) Handles txtInicialCaja.Leave
        If txtInicialCaja.Text = "" Then
            txtInicialCaja.Text = CDbl(0).ToString("C")
        Else
            txtInicialCaja.Text = CDbl(txtInicialCaja.Text).ToString("C")
        End If
    End Sub

    Private Sub txtCheque_Leave(sender As Object, e As EventArgs) Handles txtCheque.Leave
        If txtCheque.Text = "" Then
            txtCheque.Text = CDbl(0).ToString("C")
        Else
            txtCheque.Text = CDbl(txtCheque.Text).ToString("C")
        End If
    End Sub

    Private Sub txtTarjeta_Leave(sender As Object, e As EventArgs) Handles txtTarjeta.Leave
        If txtTarjeta.Text = "" Then
            txtTarjeta.Text = CDbl(0).ToString("C")
        Else
            txtTarjeta.Text = CDbl(txtTarjeta.Text).ToString("C")
        End If
    End Sub

    Private Sub txtDepositos_Leave(sender As Object, e As EventArgs) Handles txtDepositos.Leave
        If txtDepositos.Text = "" Then
            txtDepositos.Text = CDbl(0).ToString("C")
        Else
            txtDepositos.Text = CDbl(txtDepositos.Text).ToString("C")
        End If
    End Sub

    Private Sub txtOtrosIngresos_Leave(sender As Object, e As EventArgs) Handles txtOtrosIngresos.Leave
        If txtOtrosIngresos.Text = "" Then
            txtOtrosIngresos.Text = CDbl(0).ToString("C")
        Else
            txtOtrosIngresos.Text = CDbl(txtOtrosIngresos.Text).ToString("C")
        End If
    End Sub

    Private Sub txtDevolucion_Leave(sender As Object, e As EventArgs) Handles txtDevolucion.Leave
        If txtDevolucion.Text = "" Then
            txtDevolucion.Text = CDbl(0).ToString("C")
        Else
            txtDevolucion.Text = CDbl(txtDevolucion.Text).ToString("C")
        End If
    End Sub

    Private Sub txtEgreso_Leave(sender As Object, e As EventArgs) Handles txtEgreso.Leave
        If txtEgreso.Text = "" Then
            txtEgreso.Text = CDbl(0).ToString("C")
        Else
            txtEgreso.Text = CDbl(txtEgreso.Text).ToString("C")
        End If
    End Sub

    Private Sub txtOtrosEgresos_Leave(sender As Object, e As EventArgs) Handles txtOtrosEgresos.Leave
        If txtOtrosEgresos.Text = "" Then
            txtOtrosEgresos.Text = CDbl(0).ToString("C")
        Else
            txtOtrosEgresos.Text = CDbl(txtOtrosEgresos.Text).ToString("C")
        End If
    End Sub

    Private Sub txtInicialCaja_Enter(sender As Object, e As EventArgs) Handles txtInicialCaja.Enter
        If txtInicialCaja.Text = "" Then
        Else
            txtInicialCaja.Text = CDbl(txtInicialCaja.Text)
        End If
    End Sub

    Private Sub txtCheque_Enter(sender As Object, e As EventArgs) Handles txtCheque.Enter
        If txtCheque.Text = "" Then
        Else
            txtCheque.Text = CDbl(txtCheque.Text)
        End If
    End Sub

    Private Sub txtTarjeta_Enter(sender As Object, e As EventArgs) Handles txtTarjeta.Enter
        If txtTarjeta.Text = "" Then
        Else
            txtTarjeta.Text = CDbl(txtTarjeta.Text)
        End If
    End Sub

    Private Sub txtDepositos_Enter(sender As Object, e As EventArgs) Handles txtDepositos.Enter
        If txtDepositos.Text = "" Then
        Else
            txtDepositos.Text = CDbl(txtDepositos.Text)
        End If
    End Sub

    Private Sub txtOtrosIngresos_Enter(sender As Object, e As EventArgs) Handles txtOtrosIngresos.Enter
        If txtOtrosIngresos.Text = "" Then
        Else
            txtOtrosIngresos.Text = CDbl(txtOtrosIngresos.Text)
        End If
    End Sub

    Private Sub txtDevolucion_Enter(sender As Object, e As EventArgs) Handles txtDevolucion.Enter
        If txtDevolucion.Text = "" Then
        Else
            txtDevolucion.Text = CDbl(txtDevolucion.Text)
        End If
    End Sub

    Private Sub txtEgreso_Enter(sender As Object, e As EventArgs) Handles txtEgreso.Enter
        If txtEgreso.Text = "" Then
        Else
            txtEgreso.Text = CDbl(txtEgreso.Text)
        End If
    End Sub

    Private Sub txtOtrosEgresos_Enter(sender As Object, e As EventArgs) Handles txtOtrosEgresos.Enter
        If txtOtrosEgresos.Text = "" Then
        Else
            txtOtrosEgresos.Text = CDbl(txtOtrosEgresos.Text)
        End If
    End Sub

    Private Sub SumIngresos()
        Try
            txtTotalIngresos.Text = (Val(txtInicialCaja.Text) + Val(txtEfectivo.Text) + Val(txtCheque.Text) + Val(txtTarjeta.Text) + Val(txtDolares.Text) + Val(txtDepositos.Text) + Val(txtOtrosIngresos.Text)).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SumEgresos()
        Try

            txtTotalEgresos.Text = (Val(txtDevolucion.Text) + Val(txtEgreso.Text) + Val(txtOtrosEgresos.Text)).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SumTotal()
        Try

            txtTotal.Text = (Val(txtTotalIngresos.Text) - Val(txtTotalEgresos.Text)).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub OperacionesdeSuma()
        SumEfectivo()
        SumIngresos()
        SumEgresos()
        SumTotal()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        x2000.Text = 0
        x1000.Text = 0
        x500.Text = 0
        x200.Text = 0
        x100.Text = 0
        x50.Text = 0
        x25.Text = 0
        x20.Text = 0
        x10.Text = 0
        x5.Text = 0
        x1.Text = 0
        txtInicialCaja.Text = CDbl(0).ToString("C")
        txtEfectivo.Text = CDbl(0).ToString("C")
        txtCheque.Text = CDbl(0).ToString("C")
        txtTarjeta.Text = CDbl(0).ToString("C")
        txtDolares.Text = CDbl(0).ToString("C")
        txtDepositos.Text = CDbl(0).ToString("C")
        txtOtrosIngresos.Text = CDbl(0).ToString("C")
        txtTotalIngresos.Text = CDbl(0).ToString("C")
        txtDevolucion.Text = CDbl(0).ToString("C")
        txtEgreso.Text = CDbl(0).ToString("C")
        txtOtrosEgresos.Text = CDbl(0).ToString("C")
        txtTotalEgresos.Text = CDbl(0).ToString("C")
        txtCantidadDolar.Text = 0
        txtTotal.Text = CDbl(0).ToString("C")

    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub txtTasaDolar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTasaDolar.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub txtTasaDolar_Leave(sender As Object, e As EventArgs) Handles txtTasaDolar.Leave
        If IsNumeric(txtTasaDolar.Text) Then
            txtTasaDolar.Text = CDbl(txtTasaDolar.Text).ToString("C")
        Else
            'Tasa Dolar
            ConLibregco.Open()
            cmd = New MySqlCommand("Select TasaCompra from TipoMoneda Where IDTipoMoneda=2", ConLibregco)
            txtTasaDolar.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            ConLibregco.Close()
        End If

        txtDolares.Text = (Val(txtCantidadDolar.Text) * Val(txtTasaDolar.Text)).ToString("C")

    End Sub

    Private Sub txtTasaDolar_Enter(sender As Object, e As EventArgs) Handles txtTasaDolar.Enter
        If txtTasaDolar.Text = "" Then
        Else
            txtTasaDolar.Text = CDbl(txtTasaDolar.Text)
        End If
    End Sub

    Private Sub txtCantidadDolar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadDolar.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub txtCantidadDolar_Leave(sender As Object, e As EventArgs) Handles txtCantidadDolar.Leave
        If txtCantidadDolar.Text = "" Then
            txtCantidadDolar.Text = 0
        Else
        End If

        txtDolares.Text = (Val(txtCantidadDolar.Text) * Val(txtTasaDolar.Text)).ToString("C")
    End Sub

    Private Sub txtInicialCaja_TextChanged(sender As Object, e As EventArgs) Handles txtInicialCaja.TextChanged
        OperacionesdeSuma()
    End Sub

    Private Sub txtCheque_TextChanged(sender As Object, e As EventArgs) Handles txtCheque.TextChanged
        OperacionesdeSuma()
    End Sub

    Private Sub txtEgreso_TextChanged(sender As Object, e As EventArgs) Handles txtEgreso.TextChanged
        OperacionesdeSuma()
    End Sub

    Private Sub txtDevolucion_TextChanged(sender As Object, e As EventArgs) Handles txtDevolucion.TextChanged
        OperacionesdeSuma()
    End Sub

    Private Sub txtOtrosIngresos_TextChanged(sender As Object, e As EventArgs) Handles txtOtrosIngresos.TextChanged
        OperacionesdeSuma()
    End Sub

    Private Sub txtDepositos_TextChanged(sender As Object, e As EventArgs) Handles txtDepositos.TextChanged
        OperacionesdeSuma()
    End Sub

    Private Sub txtTasaDolar_TextChanged(sender As Object, e As EventArgs) Handles txtTasaDolar.TextChanged
        OperacionesdeSuma()
    End Sub

    Private Sub txtCantidadDolar_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadDolar.TextChanged
        OperacionesdeSuma()
    End Sub

    Private Sub txtTarjeta_TextChanged(sender As Object, e As EventArgs) Handles txtTarjeta.TextChanged
        OperacionesdeSuma()
    End Sub

    Private Sub txtOtrosEgresos_TextChanged(sender As Object, e As EventArgs) Handles txtOtrosEgresos.TextChanged
        OperacionesdeSuma()
    End Sub

    Private Sub txtDolares_TextChanged(sender As Object, e As EventArgs) Handles txtDolares.TextChanged
        OperacionesdeSuma()
    End Sub

    Private Sub LoadAnimation()
        If PicLoading.Visible = False Then
            PicLoading.Visible = True
            ToolSeparator.Visible = True
            lblStatusBar.Text = "Cargando..."
        Else
            PicLoading.Visible = False
            ToolSeparator.Visible = False
            lblStatusBar.Text = "Listo"
        End If
    End Sub

    Private Sub ElegirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnElegir.Click
        frm_corte_caja.txtEfectivoContado.Text = (CDbl(Tx2000.Text) + CDbl(Tx1000.Text) + CDbl(Tx500.Text) + CDbl(Tx200.Text) + CDbl(Tx100.Text) + CDbl(Tx50.Text) + CDbl(Tx25.Text) + CDbl(Tx20.Text) + CDbl(Tx10.Text) + CDbl(Tx5.Text) + CDbl(Tx1.Text)).ToString("C")
        Me.Close()
    End Sub

    Private Sub btnPresentar_Click(sender As Object, e As EventArgs) Handles btnPresentar.Click
        Try
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            End If
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            Con.Open()
            cmd = New MySqlCommand("Select Path from Reportes where IDReportes=88", Con)
            Dim Path As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & Path) Else ObjRpt.Load("C:" & Path.Replace("\Libregco\Libregco.net", ""))

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            'Setting Info
            ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
            If txtIDUsuario.Text = "" Then
                ObjRpt.SetParameterValue("@UsuarioEntrega", "")
            Else
                ObjRpt.SetParameterValue("@UsuarioEntrega", "[" & txtIDUsuario.Text & "] " & txtUsuario.Text)
            End If
            ObjRpt.SetParameterValue("@FechaCuadre", dtpFecha.Text)
            ObjRpt.SetParameterValue("2000Cant", x2000.Text)
            ObjRpt.SetParameterValue("1000Cant", x1000.Text)
            ObjRpt.SetParameterValue("500Cant", x500.Text)
            ObjRpt.SetParameterValue("200Cant", x200.Text)
            ObjRpt.SetParameterValue("100Cant", x100.Text)
            ObjRpt.SetParameterValue("50Cant", x50.Text)
            ObjRpt.SetParameterValue("25Cant", x25.Text)
            ObjRpt.SetParameterValue("20Cant", x20.Text)
            ObjRpt.SetParameterValue("10Cant", x10.Text)
            ObjRpt.SetParameterValue("5Cant", x5.Text)
            ObjRpt.SetParameterValue("1Cant", x1.Text)
            ObjRpt.SetParameterValue("@InicialdeCaja", txtInicialCaja.Text)
            ObjRpt.SetParameterValue("@Efectivo", txtEfectivo.Text)
            ObjRpt.SetParameterValue("@Cheque", txtCheque.Text)
            ObjRpt.SetParameterValue("@Tarjetas", txtTarjeta.Text)
            ObjRpt.SetParameterValue("@Dolares", txtDolares.Text)
            ObjRpt.SetParameterValue("@CantidadDolares", txtCantidadDolar.Text & " x " & txtTasaDolar.Text)
            ObjRpt.SetParameterValue("@Depositos", txtDepositos.Text)
            ObjRpt.SetParameterValue("@Otros", txtOtrosIngresos.Text)
            ObjRpt.SetParameterValue("@TotalIngresos", txtTotalIngresos.Text)
            ObjRpt.SetParameterValue("@Devoluciones", txtDevolucion.Text)
            ObjRpt.SetParameterValue("@Egresos", txtEgreso.Text)
            ObjRpt.SetParameterValue("@OtrosEgresos", txtOtrosEgresos.Text)
            ObjRpt.SetParameterValue("@TotalEgresos", txtTotalEgresos.Text)
            ObjRpt.SetParameterValue("@GranTotal", txtTotal.Text)

            LoadAnimation()
            lblStatusBar.Text = "Visualizando el reporte..."
            Dim TmpForm = New frm_reportView
            TmpForm.Show(Me)
            TmpForm.CrystalViewer.ReportSource = ObjRpt
            TmpForm.CrystalViewer.Refresh()
            TmpForm.CrystalViewer.Cursor = Cursors.Default
            lblStatusBar.Text = "Listo"


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

End Class