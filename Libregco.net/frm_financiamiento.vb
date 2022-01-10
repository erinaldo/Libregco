Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Imports System.Drawing.Printing

Public Class frm_financiamiento
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Dim lblIDUsuario As New Label
    Friend Relacion, Dias, Interes, DenomInteres, Nombre, lblImponerVentaNCF, lblControlarMontos, lblIDCondicion, lblIDTransaccion, DefaultIDCobrador As New Label
    Friend DefaultNcf, ImponerInfoenNCF, IDGrupoCXC, IdentObligCred, MaxFacturasCreditoPermitidas, MaxPagosVencidos, MontoMinimoPagare As String
    Friend IsSaved As Boolean = False
    Friend TipodeImpresion As Integer
    Friend AccionesModulosAutorizadas As New ArrayList
    Private Sub frm_financiamiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        SetConfiguracion()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub SetConfiguracion()
        Try


            'Mostrar el panel de informacion de los articulos
            Con.Open()
            ConLibregco.Open()

            'Comprobante Fiscal Predeterminado
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=13", Con)
            DefaultNcf = Convert.ToString(cmd.ExecuteScalar())
            cmd = New MySqlCommand("SELECT TipoComprobante FROM Comprobantefiscal Where IDComprobanteFiscal='" + DefaultNcf + "'", Con)
            DefaultNcf = Convert.ToString(cmd.ExecuteScalar())

            'Imponer RNC y telefonos en ventas con valor fiscal
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=114", Con)
            ImponerInfoenNCF = Convert.ToDouble(cmd.ExecuteScalar())

            'Obligación de cédulas en créditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=55", Con)
            IdentObligCred = Convert.ToString(cmd.ExecuteScalar())

            'Controlar montos de pagos con relación al sueldo
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=103", Con)
            lblControlarMontos.Text = Convert.ToString(cmd.ExecuteScalar())

            'Cantidad maxima de pagos vencidos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=140", Con)
            If Convert.ToDouble(cmd.ExecuteScalar()) = 0 Then
                MaxPagosVencidos = 999
            Else
                cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=141", Con)
                MaxPagosVencidos = Convert.ToDouble(cmd.ExecuteScalar())
            End If

            'Cantidad maxima de facturas pendientes
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=142", Con)
            If Convert.ToDouble(cmd.ExecuteScalar()) = 0 Then
                MaxFacturasCreditoPermitidas = 999
            Else
                cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=143", Con)
                MaxFacturasCreditoPermitidas = Convert.ToDouble(cmd.ExecuteScalar())
            End If

            'Monto minimo de pagare
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=144", Con)
            If Convert.ToDouble(cmd.ExecuteScalar()) = 0 Then
                MontoMinimoPagare = 0
            Else
                cmd = New MySqlCommand("Select Value3Double from Configuracion where IDConfiguracion=145", Con)
                MontoMinimoPagare = Convert.ToDouble(cmd.ExecuteScalar())
            End If

            'Verificar condicion de financiamiento
            cmd = New MySqlCommand("Select Dias FROM libregco.condicion Where Dias=9999", Con)
            Dim DiasCondicion As String = Convert.ToString(cmd.ExecuteScalar())

            If DiasCondicion = "" Then
                sqlQ = "INSERT INTO Condicion (Condicion,Dias,Orden,Nulo) VALUES ('Créditos a largo plazo / Financiamientos','9999','0','0')"
                cmd = New MySqlCommand(sqlQ, ConLibregco)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("Select IDCondicion from Condicion where IDCondicion= (Select Max(IDCondicion) from Condicion)", ConLibregco)
                lblIDCondicion.Text = Convert.ToString(cmd.ExecuteScalar())

            Else
                cmd = New MySqlCommand("Select IDCondicion FROM libregco.condicion Where Dias=9999", Con)
                lblIDCondicion.Text = Convert.ToString(cmd.ExecuteScalar())
            End If

            'Cobrador Predeterminado
            cmd = New MySqlCommand("SELECT Value2Int FROM configuracion where IDConfiguracion=25", Con)
            DefaultIDCobrador.Text = Convert.ToString(cmd.ExecuteScalar())


            Con.Close()
            ConLibregco.Close()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
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

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtBalanceGeneral.Clear()
        txtUltimoPago.Clear()
        txtCalificacion.Clear()
        txtDescripcion.Clear()
        cbxMetodo.Items.Clear()
        cbxFormaPago.Items.Clear()
        dtpFechaInicio.Value = Today
        txtCantidadCuotas.Text = ""
        txtPorcInteres.Text = ""
        lblIDTransaccion.Text = ""
        txtMonto.Clear()
        txtCostoTramite.Clear()
        txtGranTotal.Clear()
        txtInicial.Clear()
        txtMontoPrestamo.Clear()
        txtMeses.Clear()
        txtMontoPagos.Clear()
        txtTotalAPagar.Clear()
        DgvCuotas.Rows.Clear()
        txtIDFinanciamiento.Clear()
        txtSecondID.Clear()
        txtTiempoPeriodos.Clear()
        AccionesModulosAutorizadas.Clear()
    End Sub
    Private Sub ActualizarTodo()
        Try
            HabilitarControles()
            IsSaved = False
            txtMonto.Text = CDbl(0).ToString("C")
            txtCostoTramite.Text = CDbl(0).ToString("C")
            txtGranTotal.Text = CDbl(0).ToString("C")
            txtInicial.Text = CDbl(0).ToString("C")
            txtSubTotal.Text = CDbl(0).ToString("C")
            txtITBIS.Text = CDbl(0).ToString("C")
            txtNeto.Text = CDbl(0).ToString("C")
            txtMontoPrestamo.Text = CDbl(0).ToString("C")
            FillCbxFormaPago()
            FillCbxMetodo()
            FillComprobante()
            FillVendedores()
            ChkEvitSaturday.Checked = False
            chkRedondearCuotas.Checked = False
            ChkEvitSunday.Checked = False
            chkPoseeGarantia.Checked = False
            chkNulo.Checked = False
            ProgressBar1.Visible = False
            txtFecha.Value = Today
            txtHora.Value = DateTime.Now
            Hora.Enabled = True

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillCbxFormaPago()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM PeriodoPago ORDER BY Dias ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "FormasPago")
            cbxFormaPago.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("FormasPago")

            For Each Fila As DataRow In Tabla.Rows
                cbxFormaPago.Items.Add(Fila.Item("Descripcion"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillCbxMetodo()
        Try

            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM tipofinanciamiento ORDER BY Descripcion ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoPrestamo")
            cbxMetodo.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("TipoPrestamo")

            For Each Fila As DataRow In Tabla.Rows
                cbxMetodo.Items.Add(Fila.Item("Descripcion"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
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

    Private Sub txtCantidadCuotas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadCuotas.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtPorcInteres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcInteres.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCostoTramite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCostoTramite.KeyPress
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
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtCantidadCuotas_Enter(sender As Object, e As EventArgs) Handles txtCantidadCuotas.Enter
        Try
            If txtCantidadCuotas.Text = "" Then
            Else
                txtCantidadCuotas.Text = CInt(txtCantidadCuotas.Text)
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtPorcInteres_Enter(sender As Object, e As EventArgs) Handles txtPorcInteres.Enter
        Try
            If txtPorcInteres.Text = "" Then
            Else
                txtPorcInteres.Text = Replace(txtPorcInteres.Text, "%", "")
                txtPorcInteres.SelectAll()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " TxtPorInteres-Enter")
        End Try
    End Sub

    Private Sub txtCostoTramite_Enter(sender As Object, e As EventArgs) Handles txtCostoTramite.Enter
        If txtCostoTramite.Text = "" Then
        Else
            txtCostoTramite.Text = CDbl(txtCostoTramite.Text)
        End If
    End Sub

    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtMonto.Leave
        Try

            If txtMonto.Text = "" Then
                txtMonto.Text = CDbl(0).ToString("C")
            Else
                txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " TxtMonto-Leave")
        End Try
    End Sub

    Private Sub txtPorcInteres_Leave(sender As Object, e As EventArgs) Handles txtPorcInteres.Leave
        Try
            If txtPorcInteres.Text = "" Then
                txtPorcInteres.Text = CDbl(0).ToString("P")
            Else
                txtPorcInteres.Text = (CDbl(txtPorcInteres.Text) / 100).ToString("P")
            End If

            If txtGranTotal.Text <> CDbl(0).ToString("C") And txtMonto.Text <> "" And txtCantidadCuotas.Text <> "" And txtCostoTramite.Text <> "" And cbxMetodo.Text <> "" Then
                CalcularFinanciamiento()
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " TxtPorInteres-Leave")
        End Try
    End Sub

    Private Sub txtCostoTramite_Leave(sender As Object, e As EventArgs) Handles txtCostoTramite.Leave
        Try

            If txtCostoTramite.Text = "" Then
                txtCostoTramite.Text = CDbl(0).ToString("C")
            Else
                txtCostoTramite.Text = CDbl(txtCostoTramite.Text).ToString("C")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " TxtCostoTramite-Leave")
        End Try
    End Sub

    Private Sub txtInicial_Leave(sender As Object, e As EventArgs) Handles txtInicial.Leave
        Try

            If txtInicial.Text = "" Then
                txtInicial.Text = CDbl(0).ToString("C")
            Else
                txtInicial.Text = CDbl(txtInicial.Text).ToString("C")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " txtInicial-Leave")
        End Try
    End Sub

    Private Sub txtMonto_TextChanged(sender As Object, e As EventArgs) Handles txtMonto.TextChanged
        Try
            txtGranTotal.Text = CDbl(CDbl(txtMonto.Text) - CDbl(txtInicial.Text)).ToString("C")

            If txtGranTotal.Text <> CDbl(0).ToString("C") And txtMonto.Text <> "" And txtCantidadCuotas.Text <> "" And txtCostoTramite.Text <> "" And cbxMetodo.Text <> "" Then
                CalcularFinanciamiento()
            End If

        Catch ex As Exception
            txtGranTotal.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtCostoTramite_TextChanged(sender As Object, e As EventArgs) Handles txtCostoTramite.TextChanged
        Try
            txtGranTotal.Text = CDbl(CDbl(txtMonto.Text) - CDbl(txtInicial.Text)).ToString("C")

            If txtGranTotal.Text <> CDbl(0).ToString("C") And txtMonto.Text <> "" And txtCantidadCuotas.Text <> "" And txtCostoTramite.Text <> "" And cbxMetodo.Text <> "" Then
                CalcularFinanciamiento()
            End If
        Catch ex As Exception
            txtGranTotal.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtInicial_Enter(sender As Object, e As EventArgs) Handles txtInicial.Enter
        Try
            If txtInicial.Text = "" Then
            Else
                txtInicial.Text = CDbl(txtInicial.Text)
            End If
        Catch ex As Exception
            txtInicial.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtInicial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInicial.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaInicio.Value <> dtpFechaFinal.Value Then
            txtTiempoPeriodos.Text = CalcularFecha(dtpFechaInicio.Value, dtpFechaFinal.Value)
            txtTiempoPeriodos.Tag = DateDiff(DateInterval.Month, dtpFechaInicio.Value, dtpFechaFinal.Value)

            If cbxFormaPago.Text <> "" Then
                txtTiempoPeriodos.Text = CalcularFecha(dtpFechaInicio.Value, dtpFechaFinal.Value)
            End If
        End If

        dtpFechaFinal.MinDate = dtpFechaInicio.Value

        If txtGranTotal.Text <> CDbl(0).ToString("C") And txtMonto.Text <> "" And txtCantidadCuotas.Text <> "" And txtCostoTramite.Text <> "" And cbxMetodo.Text <> "" Then
            CalcularFinanciamiento()
        End If
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        If dtpFechaInicio.Value <> dtpFechaFinal.Value Then
            txtTiempoPeriodos.Text = CalcularFecha(dtpFechaInicio.Value, dtpFechaFinal.Value)
            txtTiempoPeriodos.Tag = DateDiff(DateInterval.Month, dtpFechaInicio.Value, dtpFechaFinal.Value)

            If cbxFormaPago.Text <> "" Then
                txtTiempoPeriodos.Text = CalcularFecha(dtpFechaInicio.Value, dtpFechaFinal.Value)
            End If
        End If

    End Sub

    Private Sub txtCantidadCuotas_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadCuotas.TextChanged
        If txtGranTotal.Text <> CDbl(0).ToString("C") And txtMonto.Text <> "" And txtCantidadCuotas.Text <> "" And txtCostoTramite.Text <> "" And cbxMetodo.Text <> "" Then
            CalcularFinanciamiento()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDFinanciamiento.Text = "" Then
            If txtIDCliente.Text <> "" Or DgvCuotas.Rows.Count > 0 Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario de financiamientos?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatos()
                    ActualizarTodo()
                End If
            Else
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            LimpiarDatos()
            ActualizarTodo()
        End If
    End Sub

    Private Sub txtInicial_TextChanged(sender As Object, e As EventArgs) Handles txtInicial.TextChanged
        Try
            txtGranTotal.Text = CDbl(CDbl(txtMonto.Text) - CDbl(txtInicial.Text)).ToString("C")

            If txtGranTotal.Text <> CDbl(0).ToString("C") And txtMonto.Text <> "" And txtCantidadCuotas.Text <> "" And txtCostoTramite.Text <> "" And cbxMetodo.Text <> "" Then
                CalcularFinanciamiento()
            End If

        Catch ex As Exception
            txtInicial.Text = 0
        End Try
    End Sub

    Private Sub ChkEvitSaturday_CheckedChanged(sender As Object, e As EventArgs) Handles ChkEvitSaturday.CheckedChanged
        If txtGranTotal.Text <> CDbl(0).ToString("C") And txtMonto.Text <> "" And txtCantidadCuotas.Text <> "" And txtCostoTramite.Text <> "" And cbxMetodo.Text <> "" Then
            CalcularFinanciamiento()
        End If
    End Sub

    Private Sub ChkEvitSunday_CheckedChanged(sender As Object, e As EventArgs) Handles ChkEvitSunday.CheckedChanged
        If txtGranTotal.Text <> CDbl(0).ToString("C") And txtMonto.Text <> "" And txtCantidadCuotas.Text <> "" And txtCostoTramite.Text <> "" And cbxMetodo.Text <> "" Then
            CalcularFinanciamiento()
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Value = DateTime.Now
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub cbxMetodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMetodo.SelectedIndexChanged
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT idTipoFinanciamiento FROM tipofinanciamiento where Descripcion= '" + cbxMetodo.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoPrestamo")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("TipoPrestamo")

            cbxMetodo.Tag = (Tabla.Rows(0).Item("idTipoFinanciamiento"))

            If txtGranTotal.Text <> CDbl(0).ToString("C") And txtMonto.Text <> "" And txtCantidadCuotas.Text <> "" And txtCostoTramite.Text <> "" And cbxMetodo.Text <> "" Then
                CalcularFinanciamiento()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub cbxFormaPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxFormaPago.SelectedIndexChanged
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDPeriodoPago,Relacion,Dias,DenomInteres FROM PeriodoPago WHERE Descripcion= '" + cbxFormaPago.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "FormasPago")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("FormasPago")

            cbxFormaPago.Tag = (Tabla.Rows(0).Item("IDPeriodoPago"))
            Relacion.Text = (Tabla.Rows(0).Item("Relacion"))
            Dias.Text = (Tabla.Rows(0).Item("Dias"))
            DenomInteres.Text = (Tabla.Rows(0).Item("DenomInteres"))

            If txtGranTotal.Text <> CDbl(0).ToString("C") And txtMonto.Text <> "" And txtCantidadCuotas.Text <> "" And txtCostoTramite.Text <> "" And cbxMetodo.Text <> "" Then
                CalcularFinanciamiento()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CbxTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxTipoComprobante.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDComprobanteFiscal FROM ComprobanteFiscal WHERE TipoComprobante= '" + CbxTipoComprobante.SelectedItem + "'", Con)
        CbxTipoComprobante.Tag = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT ImposicionVenta FROM ComprobanteFiscal WHERE TipoComprobante= '" + CbxTipoComprobante.SelectedItem + "'", Con)
        lblImponerVentaNCF.Text = Convert.ToString(cmd.ExecuteScalar())

        Con.Close()
    End Sub

    Private Sub cbxVendedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxVendedor.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + cbxVendedor.SelectedItem + "'", Con)
        cbxVendedor.Tag = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub chkGenerarItbis_CheckedChanged(sender As Object, e As EventArgs) Handles chkGenerarItbis.CheckedChanged

        If chkGenerarItbis.Checked = False Then
            Label30.Visible = False
            txtTasaItbis.Visible = False
            txtTasaItbis.Text = 0

            txtSubTotal.Text = CDbl(txtMontoPrestamo.Text).ToString("C")
            txtITBIS.Text = CDbl(0).ToString("C")
            txtNeto.Text = CDbl(txtMontoPrestamo.Text).ToString("C")

        Else

            Label30.Visible = True
            txtTasaItbis.Visible = True

            Dim Porcentaje As Double
            Porcentaje = ((Replace(txtTasaItbis.Text, "%", ""))) / 100

            If Porcentaje = 0 Then
                txtTasaItbis.Text = (CDbl(18) / 100).ToString("P")
                Porcentaje = ((Replace(txtTasaItbis.Text, "%", ""))) / 100
            End If

            If Porcentaje > 0 Then
                txtSubTotal.Text = (CDbl(txtMontoPrestamo.Text) / (1 + Porcentaje)).ToString("C")
                txtITBIS.Text = (CDbl(txtMontoPrestamo.Text) - CDbl(txtSubTotal.Text)).ToString("C")
                txtNeto.Text = CDbl(txtMontoPrestamo.Text).ToString("C")
            Else
                txtSubTotal.Text = CDbl(txtMontoPrestamo.Text).ToString("C")
                txtITBIS.Text = CDbl(0).ToString("C")
                txtNeto.Text = CDbl(txtMontoPrestamo.Text).ToString("C")
            End If
        End If
    End Sub

    Private Sub txtTasaItbis_Leave(sender As Object, e As EventArgs) Handles txtTasaItbis.Leave
        Try
            If txtTasaItbis.Text = "" Then
                txtTasaItbis.Text = CDbl(0).ToString("P")
            Else
                txtTasaItbis.Text = (CDbl(txtTasaItbis.Text) / 100).ToString("P")
            End If

            If txtGranTotal.Text <> CDbl(0).ToString("C") And txtMonto.Text <> "" And txtCantidadCuotas.Text <> "" And txtCostoTramite.Text <> "" And cbxMetodo.Text <> "" Then
                CalcularFinanciamiento()
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " TxtPorInteres-Leave")
        End Try
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            DeshabilitarControles()
        Else
            HabilitarControles()
        End If
    End Sub

    Private Sub txtTasaItbis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTasaItbis.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
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

    Private Sub StatusCliente()
        Try
            Dim IDCalificacion, CuentaIncobrable, CreditoCerrado As New Label

            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDCalificacion,CuentaIncobrable,CerrarCredito from Libregco.Clientes where IDCliente= '" + txtIDCliente.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Clientes")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Clientes")
            CuentaIncobrable.Text = Tabla.Rows(0).Item("CuentaIncobrable")
            CreditoCerrado.Text = Tabla.Rows(0).Item("CerrarCredito")
            IDCalificacion.Text = Tabla.Rows(0).Item("IDCalificacion")

            If IDCalificacion.Text > 6 Then
                frm_degraded_client.IDCliente.Text = txtIDCliente.Text
                frm_degraded_client.ShowDialog(Me)

                frm_superclave.IDAccion.Text = 117
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    Exit Sub
                Else
                    ControlSuperClave = 0
                End If
            End If

            If CreditoCerrado.Text = 1 Then
                MessageBox.Show("El cliente tiene el crédito cerrado." & vbNewLine & "Por favor verifique su historial para verificar su status crediticio.", "CREDITO CERRADO", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ControlSuperClave = 1
                Exit Sub
            Else
                ControlSuperClave = 0
            End If

            If CuentaIncobrable.Text = 1 Then
                'Dim Result As MsgBoxResult = MessageBox.Show("El cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] " & "posee cuentas incobrables." & vbNewLine & "Es recomendable consultar el status con " & txtCobrador.Text & ", cobrador asignado actualmente." & vbNewLine & vbNewLine & "Está seguro que desea continuar con la factura?", "Posee cuentas incobrables", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                'If Result = MsgBoxResult.Yes Then
                '    Exit Sub
                'Else
                '    ControlSuperClave = 1
                '    Exit Sub
                'End If
            End If


            Tabla.Dispose()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarCedulaenCredito()
        If IdentObligCred = 1 Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select Clientes.Identificacion from Clientes where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
            Dim IdentInserted As String = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

            If IdentInserted.Length > 0 Then
                IdentInserted = Replace(IdentInserted, "_", "")
                IdentInserted = Replace(IdentInserted, "-", "")
            End If

            If IdentInserted.Trim = "" Then
                MessageBox.Show("El cliente: [" & txtIDCliente.Text & "] " & txtNombre.Text & " no tiene un número de identificación/cédula válido para procesar el financiamiento." & vbNewLine & vbNewLine & "Por favor inserte el número de identificación del cliente para procesar el financiamiento.", "No tiene No. de Identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ControlSuperClave = 1
            Else
                ControlSuperClave = 0
            End If
        Else
            ControlSuperClave = 0
        End If
    End Sub

    Private Sub BuscarLimiteCredito()
        Try
            Dim LimiteCredito, SumBceFacts As New Label

            ConLibregco.Open()
            ConMixta.Open()

            cmd = New MySqlCommand("Select LimiteCredito from Libregco.Clientes where IDCliente= '" + txtIDCliente.Text + "'", ConLibregco)
            LimiteCredito.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From" & SysName.Text & "FacturaDatos where IDCliente= '" + txtIDCliente.Text + "' and Nulo=0", ConMixta)
            SumBceFacts.Text = Convert.ToDouble(cmd.ExecuteScalar())

            ConLibregco.Close()
            ConMixta.Close()

            If CDbl(SumBceFacts.Text) + CDbl(txtTotalAPagar.Text) > CDbl(LimiteCredito.Text) Then
                MessageBox.Show("El financiamiento excede el límite de crédito [" & CDbl(LimiteCredito.Text).ToString("C") & "] aprobado al cliente. El financiamiento no se generará.", "Excede crédito otorgado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ControlSuperClave = 1
            Else
                ControlSuperClave = 0
            End If


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarFactVencidas()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select FechaVencimiento from FacturaDatos where IDCliente= '" + txtIDCliente.Text + "' and Balance>0 and FechaVencimiento<'" + Today.ToString("yyyy-MM-dd") + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "FacturaDatos")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("FacturaDatos")

        If Tabla.Rows.Count > 0 Then

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
            frm_reporte_movimientos_clientes.txtCliente.Text = txtNombre.Text
            frm_reporte_movimientos_clientes.FillEstadoCuenta()


            Dim Result As MsgBoxResult = MessageBox.Show("El cliente [" & txtIDCliente.Text & "] " & txtNombre.Text & " tiene factura(s) vencida(s)." & vbNewLine & vbNewLine & "Está seguro que desea continuar?", "Existen facturas vencidas", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            If Result = MsgBoxResult.Yes Then
                If Not AccionesModulosAutorizadas.Contains("49") Then
                    ControlSuperClave = 1
                    frm_superclave.IDAccion.Text = 49
                    frm_superclave.ShowDialog(Me)
                Else
                    ControlSuperClave = 0
                End If
            Else
                ControlSuperClave = 1
            End If
        End If

        Tabla.Dispose()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarCliente.PerformClick()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BuscarFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarFacturaToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_financiamientos.ShowDialog(Me)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El financiamiento No. " & txtSecondID.Text & " del cliente " & txtNombre.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Financiamiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 124
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = False
                'Modificando financiamiento
                '***************************************************
                sqlQ = "UPDATE Financiamientos SET IDTipoDocumento='57',SecondID='" + txtSecondID.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',Fecha='" + txtFecha.Value.ToString("yyyy-MM-dd") & " " & Now.ToString("HH:mm:sss") + "',IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',IDVendedor='" + cbxVendedor.Tag.ToString + "',IDCliente='" + txtIDCliente.Text + "',Descripcion='" + txtDescripcion.Text + "',IDTipoFinanciamiento='" + cbxMetodo.Tag.ToString + "',IDFormaPago='" + cbxFormaPago.Tag.ToString + "',FechaInicio='" + dtpFechaInicio.Value.ToString("yyyy-MM-dd") + "',FechaFinal='" + dtpFechaFinal.Value.ToString("yyyy-MM-dd") + "',CantidadCuotas='" + txtCantidadCuotas.Text + "',InteresMensual='" + ((Replace(txtPorcInteres.Text, "%", "")) / 100).ToString + "',EvitSabado='" + Convert.ToInt16(ChkEvitSaturday.Checked).ToString + "',EvitDomingo='" + Convert.ToInt16(ChkEvitSunday.Checked).ToString + "',PoseeGarantias='" + Convert.ToInt16(chkPoseeGarantia.Checked).ToString + "',RedondearCuotas='" + Convert.ToInt16(chkRedondearCuotas.Checked).ToString + "',Valor='" + CDbl(txtMonto.Text).ToString + "',Inicial='" + CDbl(txtInicial.Text).ToString + "',Financiamiento='" + CDbl(txtGranTotal.Text).ToString + "',Tramites='" + CDbl(txtCostoTramite.Text).ToString + "',MontoPrestamo='" + CDbl(txtMontoPrestamo.Text).ToString + "',TotalAPagar='" + CDbl(txtTotalAPagar.Text).ToString + "',MesesAplicables='" + txtMeses.Text + "',MontoPagos='" + CDbl(txtMontoPagos.Text).ToString + "',Subtotal='" + CDbl(txtSubTotal.Text).ToString + "',Itbis='" + CDbl(txtITBIS.Text).ToString + "',ItbisPorcentaje='" + ((Replace(txtTasaItbis.Text, "%", "")) / 100).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',Nulo='" + Convert.ToInt16(chkNulo.Checked).ToString + "' WHERE IDFinanciamientos= (" + txtIDFinanciamiento.Text + ")"
                GuardarDatos()

                CalcularBalances()

                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDFinanciamiento.Text = "" Then
            MessageBox.Show("No hay un registro de financiamiento abierto para anular.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el financiamiento No. " & txtSecondID.Text & " del cliente " & txtNombre.Text & " del sistema?", "Anular Financiamiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 123
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = True
                'Modificando financiamiento
                '***************************************************
                sqlQ = "UPDATE Financiamientos SET IDTipoDocumento='57',SecondID='" + txtSecondID.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',Fecha='" + txtFecha.Value.ToString("yyyy-MM-dd") & " " & Now.ToString("HH:mm:sss") + "',IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',IDVendedor='" + cbxVendedor.Tag.ToString + "',IDCliente='" + txtIDCliente.Text + "',Descripcion='" + txtDescripcion.Text + "',IDTipoFinanciamiento='" + cbxMetodo.Tag.ToString + "',IDFormaPago='" + cbxFormaPago.Tag.ToString + "',FechaInicio='" + dtpFechaInicio.Value.ToString("yyyy-MM-dd") + "',FechaFinal='" + dtpFechaFinal.Value.ToString("yyyy-MM-dd") + "',CantidadCuotas='" + txtCantidadCuotas.Text + "',InteresMensual='" + ((Replace(txtPorcInteres.Text, "%", "")) / 100).ToString + "',EvitSabado='" + Convert.ToInt16(ChkEvitSaturday.Checked).ToString + "',EvitDomingo='" + Convert.ToInt16(ChkEvitSunday.Checked).ToString + "',PoseeGarantias='" + Convert.ToInt16(chkPoseeGarantia.Checked).ToString + "',RedondearCuotas='" + Convert.ToInt16(chkRedondearCuotas.Checked).ToString + "',Valor='" + CDbl(txtMonto.Text).ToString + "',Inicial='" + CDbl(txtInicial.Text).ToString + "',Financiamiento='" + CDbl(txtGranTotal.Text).ToString + "',Tramites='" + CDbl(txtCostoTramite.Text).ToString + "',MontoPrestamo='" + CDbl(txtMontoPrestamo.Text).ToString + "',TotalAPagar='" + CDbl(txtTotalAPagar.Text).ToString + "',MesesAplicables='" + txtMeses.Text + "',MontoPagos='" + CDbl(txtMontoPagos.Text).ToString + "',Subtotal='" + CDbl(txtSubTotal.Text).ToString + "',Itbis='" + CDbl(txtITBIS.Text).ToString + "',ItbisPorcentaje='" + ((Replace(txtTasaItbis.Text, "%", "")) / 100).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',Nulo='" + Convert.ToInt16(chkNulo.Checked).ToString + "' WHERE IDFinanciamientos= (" + txtIDFinanciamiento.Text + ")"
                GuardarDatos()

                CalcularBalances()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub chkRedondearCuotas_CheckedChanged(sender As Object, e As EventArgs) Handles chkRedondearCuotas.CheckedChanged
        If txtGranTotal.Text <> CDbl(0).ToString("C") And txtMonto.Text <> "" And txtCantidadCuotas.Text <> "" And txtCostoTramite.Text <> "" And cbxMetodo.Text <> "" Then
            CalcularFinanciamiento()
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub ControlRelacionSueldo()
        Try
            If lblControlarMontos.Text = 1 Then
                Dim Sueldo, Relacion, Mensualidad As Double

                ConMixta.Open()
                cmd = New MySqlCommand("SELECT Sueldo FROM libregco.clientes where IDCliente='" + txtIDCliente.Text + "'", ConMixta)
                Sueldo = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select Value3Double from" & SysName.Text & "Configuracion where IDConfiguracion=104", ConMixta)
                Relacion = CDbl(Convert.ToDouble(cmd.ExecuteScalar()))

                cmd = New MySqlCommand("SELECT Coalesce(sum(IF(MontoPagos<Balance, MontoPagos,Balance)),0) AS MontoValido FROM" & SysName.Text & "facturadatos inner join libregco.Condicion on facturadatos.IDCondicion=Condicion.IDCondicion where Condicion.Dias>0 and FacturaDatos.Balance>0 and IDCliente='" + txtIDCliente.Text + "'", ConMixta)
                Mensualidad = CDbl(Convert.ToString(cmd.ExecuteScalar())) + CDbl(txtMontoPagos.Text)
                ConMixta.Close()

                If Mensualidad > (Sueldo * Relacion) Then
                    If Not AccionesModulosAutorizadas.Contains("107") Then
                        MessageBox.Show("Los montos de pagos que tiene el cliente (" & Mensualidad.ToString("C") & ")" & vbNewLine & vbNewLine & "Exceden su capacidad en base al salario específicado según fue establecido en la relación de la capacidad de pagos (" & Relacion.ToString("P2") & ") establecida en el sistema.", "Exceso de capacidad de pago", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        ControlSuperClave = 1
                        frm_superclave.IDAccion.Text = 107
                        frm_superclave.ShowDialog(Me)
                    Else
                        ControlSuperClave = 0

                    End If
                End If
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            Con.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UltFinanciamiento()
        If txtIDFinanciamiento.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDFinanciamientos from Financiamientos where IDFinanciamientos= (Select Max(IDFinanciamientos) from Financiamientos)", Con)
            txtIDFinanciamiento.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select SecondID from Financiamientos where IDFinanciamientos= (Select Max(IDFinanciamientos) from Financiamientos)", Con)
            txtSecondID.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        End If
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDFinanciamiento.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el financiamiento?", "Imprimir Financiamiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                TipodeImpresion = 1
                frm_impresiones_directas.ShowDialog(Me)
            End If

            If DgvCuotas.Rows.Count > 0 Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Desea imprimir las cuotas correspondientes del financiamiento?", "Imprimir Cuotas", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    TipodeImpresion = 2
                    frm_impresiones_directas.ShowDialog(Me)
                End If
            End If
        End If
    End Sub
    Private Sub DeshabilitarControles()
        GbClientes.Enabled = False
        GroupBox1.Enabled = False
        btnGuardarC.Enabled = False
        btnBuscar.Enabled = False
        GbxUserInfo.Enabled = False
        cbxVendedor.Enabled = False
        CbxTipoComprobante.Enabled = False
        chkGenerarItbis.Enabled = False
        txtTasaItbis.Enabled = False
        DgvCuotas.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        GbClientes.Enabled = True
        GroupBox1.Enabled = True
        XtraTabControl1.Enabled = True
        btnGuardarC.Enabled = True
        btnBuscar.Enabled = True
        btnAnular.Enabled = True
        GbxUserInfo.Enabled = True
        cbxVendedor.Enabled = True
        CbxTipoComprobante.Enabled = True
        chkGenerarItbis.Enabled = True
        txtTasaItbis.Enabled = True
        DgvCuotas.Enabled = True
    End Sub

    Private Sub CalcularBalances()
        FunctCalcBcesFact(txtIDCliente.Text)
        FunctCalcBceGral(txtIDCliente.Text)
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        'Try
        Dim CheckADC As New Label
        VerificarFechaSistema()

        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar el financiamiento.", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            lblStatusBar.Text = "Seleccione el cliente para procesar el financiamiento. No se ha específicado el cliente"
            btnBuscarCliente.PerformClick()
            Exit Sub

        ElseIf txtNombre.Text = "" Then
            MessageBox.Show("Escriba el nombre del cliente del financiamiento a procesar.", "Nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            lblStatusBar.Text = "Escriba el nombre del cliente de la financiamiento a procesar"
            txtNombre.Enabled = True
            txtNombre.Focus()
            Exit Sub

        ElseIf txtDescripcion.Text = "" Then
            MessageBox.Show("Haga una breve descripción del objeto de financiamiento.", "Descripción del financiamiento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub

        ElseIf DgvCuotas.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran cuotas en el financiamiento", "No hay cuotas a financiar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            lblStatusBar.Text = "No se encuentran cuotas en el financiamiento"
            txtCantidadCuotas.Focus()
            Exit Sub

        ElseIf cbxVendedor.Text = "" Then
            MessageBox.Show("Seleccione el vendedor para procesar el financiamiento.", "Código del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            XtraTabControl1.SelectedTabPageIndex = 1
            cbxVendedor.Focus()
            cbxVendedor.DroppedDown = True
            Exit Sub

        ElseIf CbxTipoComprobante.Text = "" Then
            MessageBox.Show("Elija el tipo de comprobante fiscal que desea generar para el financiamiento", "Tipo de NCF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            XtraTabControl1.SelectedTabPageIndex = 1
            CbxTipoComprobante.Focus()
            CbxTipoComprobante.DroppedDown = True
            Exit Sub

        ElseIf DtEmpleado.Rows(0).item("IDSucursal").ToString() = "" Then
            MessageBox.Show("No se detectó el código de la sucursal para procesar el financiamiento.", "Código de Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            lblStatusBar.Text = "No se detectó el código de la sucursal para procesar el financiamiento."
            Exit Sub

        ElseIf ImponerInfoenNCF = 1 And lblImponerVentaNCF.Text = 1 Then

            If txtNombre.Text.Contains("CONTADO") Then
                MessageBox.Show("Por favor escriba el nombre de la persona o negocio a la que desea facturar.", "Escriba la denominación social", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                lblStatusBar.Text = "Por favor escriba el nombre de la persona o negocio a la que desea facturar."
                txtNombre.Enabled = True
                txtNombre.ReadOnly = False
                txtNombre.Focus()
                Exit Sub

            ElseIf txtRNC.Text.Trim = "" Then
                MessageBox.Show("Por favor escriba el número de registro nacional del contribuyente del cliente que desea facturar.", "Escriba el RNC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                lblStatusBar.Text = "Por favor escriba el número de registro nacional del contribuyente del cliente que desea facturar."

                If GbClientes.Height = 72 Then
                    GbClientes.Size = New Size(GbClientes.Size.Width, GbClientes.Size.Height + 78)
                End If

                txtNombre.Enabled = True
                txtNombre.ReadOnly = False
                lblDireccion.Visible = True
                lblTelefonos.Visible = True
                txtDireccion.Visible = True
                txtTelefonos.Visible = True
                lblRNC.Visible = True
                txtRNC.Visible = True
                txtRNC.Focus()
                Exit Sub

            ElseIf txtTelefonos.Text.Replace("-", "").Trim = "" Then
                MessageBox.Show("Por favor escriba al menos un número teléfonico del cliente.", "Escriba un número teléfonico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                lblStatusBar.Text = "Por favor escriba al menos un número teléfonico del cliente."

                If GbClientes.Height = 72 Then
                    GbClientes.Size = New Size(GbClientes.Size.Width, GbClientes.Size.Height + 78)
                End If

                txtNombre.Enabled = True
                txtNombre.ReadOnly = False
                lblDireccion.Visible = True
                lblTelefonos.Visible = True
                txtDireccion.Visible = True
                txtTelefonos.Visible = True
                lblRNC.Visible = True
                txtRNC.Visible = True
                txtTelefonos.Focus()
                Exit Sub
            End If
        End If


        If txtIDFinanciamiento.Text = "" Then 'Si no hay factura
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo financiamiento a nombre del cliente " & txtNombre.Text & " [" & txtIDCliente.Text & "] en la base de datos?", "Guardar Nuevo financiamiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                ControlSuperClave = 0
                lblStatusBar.Text = "Verificando disponibilidad de NCF."
                GetIfBlockedNCFS(CbxTipoComprobante.Tag)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                'Buscar similitudes
                lblStatusBar.Text = "Verificando si existen duplicados de la misma."
                If txtIDCliente.Text <> 1 Then

                    FindSimilarities(1, txtIDCliente.Text, txtNeto.Text, CDate(txtFecha.Value))
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If

                    FindSimilarities(2, txtIDCliente.Text, txtNeto.Text, CDate(txtFecha.Value))
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If


                If CheckDoubleBilling(txtIDCliente.Text) = True Then
                    frm_bloqueo_facturacion_simultanea.ShowDialog(Me)
                    Exit Sub
                End If

                If CInt(IDGrupoCXC) <> 3 Then
                    lblStatusBar.Text = "Verificando estatus crediticio del cliente."
                    StatusCliente()
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If

                lblStatusBar.Text = "Verificando registro de documento de identidad."
                BuscarCedulaenCredito()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                lblStatusBar.Text = "Verificando límites de crédito."
                BuscarLimiteCredito()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If


                If CInt(IDGrupoCXC) <> 3 Then
                    lblStatusBar.Text = "Verificando existencia de facturas vencidas."
                    BuscarFactVencidas()
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    Else
                        If frm_reporte_movimientos_clientes.Visible = True Then
                            frm_reporte_movimientos_clientes.Close()
                        End If
                    End If
                End If

                If CInt(IDGrupoCXC) <> 3 Then
                    lblStatusBar.Text = "Verificando cantidad de cuentas pendientes"
                    ConMixta.Open()
                    cmd = New MySqlCommand("Select count(IDFacturaDatos) FROM" & SysName.Text & "facturadatos INNER JOIN Libregco.Condicion On FacturaDatos.IDCondicion=Condicion.IDCondicion where IDCliente='" + txtIDCliente.Text + "' And FacturaDatos.FechaVencimiento<'" + Today.ToString("yyyy-MM-dd") + "' and Condicion.Dias>0 And FacturaDatos.Balance>0 and FacturaDatos.Nulo=0", ConMixta)
                    Dim CantFacturasPendientes As String = Convert.ToString(cmd.ExecuteScalar())
                    ConMixta.Close()
                    If CInt(CantFacturasPendientes) >= CInt(MaxFacturasCreditoPermitidas) Then
                        If Not AccionesModulosAutorizadas.Contains("118") Then
                            ControlSuperClave = 1
                            frm_superclave.IDAccion.Text = 118
                            frm_superclave.ShowDialog(Me)
                        Else
                            ControlSuperClave = 0
                        End If
                    End If
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If

                If CInt(IDGrupoCXC) <> 3 Then
                    lblStatusBar.Text = "Verificando cantidad de pagos pendientes"
                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT count(IDPagare) FROM" & SysName.Text & "Pagares INNER JOIN" & SysName.Text & "FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos where FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and Pagares.Balance>0 and Pagares.FechaVencimiento<Now() and FacturaDatos.Balance>0 and FacturaDatos.Nulo=0", ConMixta)
                    Dim CantPagaresVencidos As String = Convert.ToString(cmd.ExecuteScalar())
                    ConMixta.Close()
                    If CInt(CantPagaresVencidos) >= CInt(MaxPagosVencidos) Then
                        If Not AccionesModulosAutorizadas.Contains("119") Then
                            ControlSuperClave = 1
                            frm_superclave.IDAccion.Text = 119
                            frm_superclave.ShowDialog(Me)
                        Else
                            ControlSuperClave = 0
                        End If

                    End If
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If


                If CInt(IDGrupoCXC) <> 3 Then
                    lblStatusBar.Text = "Verificando montos de los pagarés"
                    If CDbl(txtMontoPagos.Text) < CDbl(MontoMinimoPagare) Then
                        If Not AccionesModulosAutorizadas.Contains("120") Then
                            ControlSuperClave = 1
                            frm_superclave.IDAccion.Text = 120
                            frm_superclave.ShowDialog(Me)
                        Else
                            ControlSuperClave = 0
                        End If
                    End If
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If


                If CInt(IDGrupoCXC) <> 3 Then
                    'Si el cliente es personal verifico si puede pagarlo con respecto a la formula de salario
                    ConLibregco.Open()
                    cmd = New MySqlCommand("SELECT IDTipoCredito FROM clientes where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
                    If Convert.ToString(cmd.ExecuteScalar()) = 1 Then
                        lblStatusBar.Text = "Calculado relación de pagos con respecto al sueldo."
                        ControlRelacionSueldo()
                        If ControlSuperClave = 1 Then
                            ConLibregco.Close()
                            Exit Sub
                        End If
                    End If
                    ConLibregco.Close()
                End If


                'Hacer aqui parte de introducir forma de pago
                '*****************************************
                lblStatusBar.Text = "Registrando método de pago."
                frm_formadepago.txtEfectivo.Focus()
                frm_formadepago.txtEfectivo.SelectAll()
                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                lblStatusBar.Text = "Adquiriendo secuencia de NCF."
                GetNCFsNumbers(CbxTipoComprobante.Tag.ToString)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                'Guardando registro en la tabla de financiamientos
                '***********************************************
                lblStatusBar.Text = "Guardando registro a la base de datos."
                sqlQ = "INSERT INTO Financiamientos (IDTipoDocumento,SecondID,IDTransaccion,Fecha,IDAreaImpresion,IDUsuario,IDVendedor,IDCliente,Descripcion,IDTipoFinanciamiento,IDFormaPago,FechaInicio,FechaFinal,CantidadCuotas,InteresMensual,EvitSabado,EvitDomingo,PoseeGarantias,RedondearCuotas,Valor,Inicial,Financiamiento,Tramites,MontoPrestamo,TotalAPagar,MesesAplicables,MontoPagos,IDTipoNCF,NCF,Subtotal,Itbis,ItbisPorcentaje,TotalNeto,Balance,BalanceLetra,Nulo,Impreso) VALUES ('57','" + GetSecondID(57).ToString + "','" + lblIDTransaccion.Text + "','" + txtFecha.Value.ToString("yyyy-MM-dd") & " " & Now.ToString("HH:mm:sss") + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + lblIDUsuario.Text + "','" + cbxVendedor.Tag.ToString + "','" + txtIDCliente.Text + "','" + txtDescripcion.Text + "','" + cbxMetodo.Tag.ToString + "','" + cbxFormaPago.Tag.ToString + "','" + dtpFechaInicio.Value.ToString("yyyy-MM-dd") + "', '" + dtpFechaFinal.Value.ToString("yyyy-MM-dd") + "','" + txtCantidadCuotas.Text + "','" + ((Replace(txtPorcInteres.Text, "%", "")) / 100).ToString + "','" + Convert.ToInt16(ChkEvitSaturday.Checked).ToString + "','" + Convert.ToInt16(ChkEvitSunday.Checked).ToString + "','" + Convert.ToInt16(chkPoseeGarantia.Checked).ToString + "','" + Convert.ToInt16(chkRedondearCuotas.Checked).ToString + "','" + CDbl(txtMonto.Text).ToString + "','" + CDbl(txtInicial.Text).ToString + "','" + CDbl(txtGranTotal.Text).ToString + "','" + CDbl(txtCostoTramite.Text).ToString + "','" + CDbl(txtMontoPrestamo.Text).ToString + "','" + CDbl(txtTotalAPagar.Text).ToString + "','" + txtMeses.Text + "','" + CDbl(txtMontoPagos.Text).ToString + "','" + CbxTipoComprobante.Tag.ToString + "','" + NewNCFValue.Text + "','" + CDbl(txtSubTotal.Text).ToString + "','" + CDbl(txtITBIS.Text).ToString + "','" + ((Replace(txtTasaItbis.Text, "%", "")) / 100).ToString + "','" + CDbl(txtNeto.Text).ToString + "','" + CDbl(txtNeto.Text).ToString + "','" + ConvertNumbertoString(txtNeto.Text).ToString + "','" + Convert.ToInt16(chkNulo.Checked).ToString + "',0)"

                lblStatusBar.Text = "Guardando registro a la base de datos (Insertando registro)."
                GuardarDatos()

                lblStatusBar.Text = "Guardando registro a la base de datos (Obteniendo número de financiamiento)."
                UltFinanciamiento()

                lblStatusBar.Text = "Guardando registro a la base de datos (Insertando cuotas)."
                InsertPagares()

                lblStatusBar.Text = "Calculando balances."
                CalcularBalances()

                lblStatusBar.ForeColor = Color.Green
                lblStatusBar.Text = "El registro fue guardado satisfactoriamente."

                ToastNotificationsManager1.Notifications(0).Body = "El financiamiento " & txtSecondID.Text & " ha sido guardada satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

                DeshabilitarControles()
                Hora.Enabled = False
                btnAnular.Enabled = False
                lblStatusBar.ForeColor = Color.Black
                lblStatusBar.Text = "Listo."
                ImprimirDocumento()

            End If
        Else

            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If IsFinanciamientoModifiable(txtIDFinanciamiento.Text) = False Then
                MessageBox.Show("El financiamiento no es modificable ya que se han hecho transacciones que afectan su integridad.", "El financiamiento no se puede modificar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el financiamiento?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                lblStatusBar.Text = "Modificando registro de método de pago."
                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                lblStatusBar.Text = "Modificando registro de la base de datos."

                'Modificando financiamiento
                '***************************************************
                sqlQ = "UPDATE Financiamientos SET IDTipoDocumento='57',SecondID='" + txtSecondID.Text + "',IDTransaccion='" + lblIDTransaccion.Text + "',Fecha='" + txtFecha.Value.ToString("yyyy-MM-dd") & " " & Now.ToString("HH:mm:sss") + "',IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',IDVendedor='" + cbxVendedor.Tag.ToString + "',IDCliente='" + txtIDCliente.Text + "',Descripcion='" + txtDescripcion.Text + "',IDTipoFinanciamiento='" + cbxMetodo.Tag.ToString + "',IDFormaPago='" + cbxFormaPago.Tag.ToString + "',FechaInicio='" + dtpFechaInicio.Value.ToString("yyyy-MM-dd") + "',FechaFinal='" + dtpFechaFinal.Value.ToString("yyyy-MM-dd") + "',CantidadCuotas='" + txtCantidadCuotas.Text + "',InteresMensual='" + ((Replace(txtPorcInteres.Text, "%", "")) / 100).ToString + "',EvitSabado='" + Convert.ToInt16(ChkEvitSaturday.Checked).ToString + "',EvitDomingo='" + Convert.ToInt16(ChkEvitSunday.Checked).ToString + "',PoseeGarantias='" + Convert.ToInt16(chkPoseeGarantia.Checked).ToString + "',RedondearCuotas='" + Convert.ToInt16(chkRedondearCuotas.Checked).ToString + "',Valor='" + CDbl(txtMonto.Text).ToString + "',Inicial='" + CDbl(txtInicial.Text).ToString + "',Financiamiento='" + CDbl(txtGranTotal.Text).ToString + "',Tramites='" + CDbl(txtCostoTramite.Text).ToString + "',MontoPrestamo='" + CDbl(txtMontoPrestamo.Text).ToString + "',TotalAPagar='" + CDbl(txtTotalAPagar.Text).ToString + "',MesesAplicables='" + txtMeses.Text + "',MontoPagos='" + CDbl(txtMontoPagos.Text).ToString + "',Subtotal='" + CDbl(txtSubTotal.Text).ToString + "',Itbis='" + CDbl(txtITBIS.Text).ToString + "',ItbisPorcentaje='" + ((Replace(txtTasaItbis.Text, "%", "")) / 100).ToString + "',TotalNeto='" + CDbl(txtNeto.Text).ToString + "',Balance='" + CDbl(txtNeto.Text).ToString + "',BalanceLetra='" + ConvertNumbertoString(txtNeto.Text).ToString + "',Nulo='" + Convert.ToInt16(chkNulo.Checked).ToString + "' WHERE IDFinanciamientos= (" + txtIDFinanciamiento.Text + ")"
                GuardarDatos()

                InsertPagares()

                CalcularBalances()

                ToastNotificationsManager1.Notifications(1).Body = "El financiamiento " & txtSecondID.Text & " ha sido modificada satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))

                lblStatusBar.ForeColor = Color.Green
                lblStatusBar.Text = "El registro fue modificado satisfactoriamente."
                DeshabilitarControles()
                Hora.Enabled = False
                btnAnular.Enabled = False
                lblStatusBar.ForeColor = Color.Black
                lblStatusBar.Text = "Listo."
                ImprimirDocumento()
            End If
        End If
        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub InsertPagares()
        If IsFinanciamientoModifiable(txtIDFinanciamiento.Text) Then
            Con.Open()

            sqlQ = "Delete from" & SysName.Text & "Financiamientos_cuotas Where IDFinanciamiento=(" + txtIDFinanciamiento.Text + ")"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()

            ProgressBar1.Value = 0
            ProgressBar1.Visible = True
            ProgressBar1.Maximum = DgvCuotas.Rows.Count

            For Each rw As DataGridViewRow In DgvCuotas.Rows
                ProgressBar1.Value = rw.Index + 1
                sqlQ = "INSERT INTO" & SysName.Text & "Financiamientos_cuotas (IDFinanciamiento,NoCuota,FechaVencimiento,DiasVencidos,Concepto,Monto,Capital,Interes,Cargo,Balance,Nota,TotalSumaLetra,Nulo) VALUES ('" + txtIDFinanciamiento.Text + "','" + rw.Cells(1).Value.ToString + "','" + CDate(rw.Cells(3).Value).ToString("yyyy-MM-dd") + "',0,'','" + CDbl(rw.Cells(2).Value).ToString + "','" + CDbl(rw.Cells(4).Value).ToString + "','" + CDbl(rw.Cells(5).Value).ToString + "',0,'" + CDbl(rw.Cells(2).Value).ToString + "','','" + rw.Cells(7).Value.ToString + "',0)"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("Select idFinanciamientos_cuotas from" & SysName.Text & "Financiamientos_cuotas where idFinanciamientos_cuotas=(Select Max(idFinanciamientos_cuotas) from Financiamientos_cuotas)", Con)
                rw.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
            Next

            Con.Close()
        End If
    End Sub

    Private Sub CalcularFinanciamiento()
        Try
            If txtMonto.Text = "" Or txtMonto.Text = CDbl(0).ToString("C") Then
                MessageBox.Show("Especifique el monto del préstamo.", "Escriba el valor del préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtMonto.Focus()
                Exit Sub
            ElseIf txtCantidadCuotas.Text = "" Or txtCantidadCuotas.Text = CDbl(0).ToString("C") Then
                MessageBox.Show("Especifique la cantidad de cuotas del préstamo.", "Defina la cantidad de pagos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtCantidadCuotas.Focus()
                Exit Sub
            ElseIf txtPorcInteres.Text = "" Then
                MessageBox.Show("Establezca el interés mensual del préstamo.", "Defina el Interés del Préstamo ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtPorcInteres.Focus()
                Exit Sub
            ElseIf cbxMetodo.Text = "" Then
                MessageBox.Show("Seleccione el tipo de método a utilizar para el préstamo.", "Seleccione Método", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                cbxMetodo.Focus()
                Exit Sub
            ElseIf cbxFormaPago.Text = "" Then
                MessageBox.Show("Seleccione la forma de pago del préstamo.", "Seleccione Forma de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                cbxFormaPago.Focus()
                Exit Sub
            ElseIf txtCostoTramite.Text = "" Then
                txtCostoTramite.Text = CDbl(0).ToString("C")
            End If

        If chkRedondearCuotas.Checked = True Then
            txtMeses.Text = Math.Round(CDbl(CDbl(txtCantidadCuotas.Text) * CDbl(Relacion.Text)), 4)
            txtPorcInteres.Text = (Replace(txtPorcInteres.Text, "%", "")) / 100

            If cbxMetodo.Text = "Lineal" Then
                txtMontoPrestamo.Text = (Math.Round((CDbl(txtGranTotal.Text) * (CDbl(txtPorcInteres.Text)) * CDbl(txtMeses.Text) + CDbl(txtGranTotal.Text))).ToString("C4"))
                txtMontoPagos.Text = Math.Round(((CDbl(txtMontoPrestamo.Text) + CDbl(txtCostoTramite.Text)) / CDbl(txtCantidadCuotas.Text))).ToString("C4")
                txtTotalAPagar.Text = Math.Round((CDbl(txtMontoPagos.Text) * CDbl(txtCantidadCuotas.Text))).ToString("C4")
            End If

            If cbxMetodo.Text = "Amortizado" Then
                Dim Interes As Double = CDbl(txtPorcInteres.Text) / CDbl(DenomInteres.Text)
                Dim Numerador As Double = (Interes * (1 + CDbl(Interes)) ^ CDbl(txtCantidadCuotas.Text))
                Dim Denominador As Double = ((1 + Interes) ^ CDbl(txtCantidadCuotas.Text) - 1)
                Dim Resultado As Double

                If Denominador = 0 Then
                    Resultado = Math.Round((CDbl(txtGranTotal.Text) + CDbl(txtCostoTramite.Text)) / CDbl(txtCantidadCuotas.Text))
                Else
                    Resultado = Math.Round((CDbl(txtGranTotal.Text) + CDbl(txtCostoTramite.Text)) * (Numerador / Denominador))
                End If

                txtMontoPrestamo.Text = Math.Round(CDbl(txtGranTotal.Text)).ToString("C4")
                txtMontoPagos.Text = Math.Round(Resultado).ToString("C4")
                txtTotalAPagar.Text = Math.Round((CDbl(txtMontoPagos.Text) * CDbl(txtCantidadCuotas.Text))).ToString("C4")
            End If

            If cbxMetodo.Text = "Amortizado Compuesto" Then
                Dim Interes As Double = CDbl(txtPorcInteres.Text) / CDbl(DenomInteres.Text)
                Dim Numerador As Double = (Interes * (1 + CDbl(Interes)) ^ CDbl(txtCantidadCuotas.Text))
                Dim Denominador As Double = ((1 + Interes) ^ CDbl(txtCantidadCuotas.Text) - 1)
                Dim Resultado As Double

                If Denominador = 0 Then
                    Resultado = Math.Round((CDbl(txtGranTotal.Text) + CDbl(txtCostoTramite.Text)) / CDbl(txtCantidadCuotas.Text))
                Else
                    Resultado = Math.Round((CDbl(txtGranTotal.Text) + CDbl(txtCostoTramite.Text)) * (Numerador / Denominador))
                End If

                txtMontoPrestamo.Text = Math.Round(CDbl(txtGranTotal.Text)).ToString("C4")
                txtMontoPagos.Text = Math.Round(Resultado).ToString("C4")
                txtTotalAPagar.Text = Math.Round((CDbl(txtMontoPagos.Text) * CDbl(txtCantidadCuotas.Text))).ToString("C4")
            End If

            If cbxMetodo.Text = "Sólo A Interés" Then
                txtMontoPrestamo.Text = Math.Round(CDbl(txtGranTotal.Text)).ToString("C4")
                txtMontoPagos.Text = Math.Round(CDbl((CDbl(txtMontoPrestamo.Text) + CDbl(txtCostoTramite.Text)) * (CDbl(txtPorcInteres.Text) / CDbl(DenomInteres.Text)))).ToString("C4")
                txtTotalAPagar.Text = (Math.Round(((CDbl(txtGranTotal.Text) + CDbl(txtCostoTramite.Text)) * (CDbl(txtPorcInteres.Text)) * CDbl(txtMeses.Text) + CDbl(txtGranTotal.Text))).ToString("C4"))
            End If
        Else
            txtMeses.Text = Math.Round(CDbl(CDbl(txtCantidadCuotas.Text) * CDbl(Relacion.Text)), 4)
            txtPorcInteres.Text = (Replace(txtPorcInteres.Text, "%", "")) / 100

            If cbxMetodo.Text = "Lineal" Then
                txtMontoPrestamo.Text = (Math.Round((CDbl(txtGranTotal.Text) * (CDbl(txtPorcInteres.Text)) * CDbl(txtMeses.Text) + CDbl(txtGranTotal.Text)), 4)).ToString("C4")
                txtMontoPagos.Text = Math.Round(((CDbl(txtMontoPrestamo.Text) + CDbl(txtCostoTramite.Text)) / CDbl(txtCantidadCuotas.Text)), 4).ToString("C4")
                txtTotalAPagar.Text = Math.Round((CDbl(txtMontoPagos.Text) * CDbl(txtCantidadCuotas.Text)), 4).ToString("C4")
            End If

            If cbxMetodo.Text = "Amortizado" Then
                Dim Interes As Double = CDbl(txtPorcInteres.Text) / CDbl(DenomInteres.Text)
                Dim Numerador As Double = (Interes * (1 + CDbl(Interes)) ^ CDbl(txtCantidadCuotas.Text))
                Dim Denominador As Double = ((1 + Interes) ^ CDbl(txtCantidadCuotas.Text) - 1)
                Dim Resultado As Double

                If Denominador = 0 Then
                    Resultado = (CDbl(txtGranTotal.Text) + CDbl(txtCostoTramite.Text)) / CDbl(txtCantidadCuotas.Text)
                Else
                    Resultado = (CDbl(txtGranTotal.Text) + CDbl(txtCostoTramite.Text)) * (Numerador / Denominador)
                End If

                txtMontoPrestamo.Text = Math.Round(CDbl(txtGranTotal.Text), 4).ToString("C4")
                txtMontoPagos.Text = Math.Round(Resultado, 4).ToString("C4")
                txtTotalAPagar.Text = Math.Round((CDbl(txtMontoPagos.Text) * CDbl(txtCantidadCuotas.Text)), 4).ToString("C4")
            End If

            If cbxMetodo.Text = "Amortizado Compuesto" Then
                Dim Interes As Double = CDbl(txtPorcInteres.Text) / CDbl(DenomInteres.Text)
                Dim Numerador As Double = (Interes * (1 + CDbl(Interes)) ^ CDbl(txtCantidadCuotas.Text))
                Dim Denominador As Double = ((1 + Interes) ^ CDbl(txtCantidadCuotas.Text) - 1)
                Dim Resultado As Double

                If Denominador = 0 Then
                    Resultado = (CDbl(txtGranTotal.Text) + CDbl(txtCostoTramite.Text)) / CDbl(txtCantidadCuotas.Text)
                Else
                    Resultado = (CDbl(txtGranTotal.Text) + CDbl(txtCostoTramite.Text)) * (Numerador / Denominador)
                End If

                txtMontoPrestamo.Text = Math.Round(CDbl(txtGranTotal.Text), 4).ToString("C4")
                txtMontoPagos.Text = Math.Round(Resultado, 4).ToString("C4")
                txtTotalAPagar.Text = Math.Round((CDbl(txtMontoPagos.Text) * CDbl(txtCantidadCuotas.Text)), 4).ToString("C4")
            End If

            If cbxMetodo.Text = "Sólo A Interés" Then
                txtMontoPrestamo.Text = Math.Round(CDbl(txtGranTotal.Text), 4).ToString("C4")
                txtMontoPagos.Text = Math.Round(CDbl((CDbl(txtMontoPrestamo.Text) + CDbl(txtCostoTramite.Text)) * (CDbl(txtPorcInteres.Text) / CDbl(DenomInteres.Text))), 4).ToString("C4")
                txtTotalAPagar.Text = (Math.Round(((CDbl(txtGranTotal.Text) + CDbl(txtCostoTramite.Text)) * (CDbl(txtPorcInteres.Text)) * CDbl(txtMeses.Text) + CDbl(txtGranTotal.Text)), 4).ToString("C4"))
            End If
        End If


        txtPorcInteres.Text = CDbl(txtPorcInteres.Text).ToString("P")

        InsertRows()


        If chkGenerarItbis.Checked = False Then
            Label30.Visible = False
            txtTasaItbis.Visible = False
            txtTasaItbis.Text = 0

            txtSubTotal.Text = CDbl(txtMontoPrestamo.Text).ToString("C")
            txtITBIS.Text = CDbl(0).ToString("C")
            txtNeto.Text = CDbl(txtMontoPrestamo.Text).ToString("C")

        Else

            Label30.Visible = True
            txtTasaItbis.Visible = True

            Dim Porcentaje As Double
            Porcentaje = ((Replace(txtTasaItbis.Text, "%", ""))) / 100

            If Porcentaje = 0 Then
                txtTasaItbis.Text = (CDbl(18) / 100).ToString("P")
                Porcentaje = ((Replace(txtTasaItbis.Text, "%", ""))) / 100
            End If

            If Porcentaje > 0 Then
                txtSubTotal.Text = (CDbl(txtMontoPrestamo.Text) / (1 + Porcentaje)).ToString("C")
                txtITBIS.Text = (CDbl(txtMontoPrestamo.Text) - CDbl(txtSubTotal.Text)).ToString("C")
                txtNeto.Text = CDbl(txtMontoPrestamo.Text).ToString("C")
            Else
                txtSubTotal.Text = CDbl(txtMontoPrestamo.Text).ToString("C")
                txtITBIS.Text = CDbl(0).ToString("C")
                txtNeto.Text = CDbl(txtMontoPrestamo.Text).ToString("C")
            End If
        End If

        Catch ex As Exception
  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub InsertRows()
        Try
            If IsSaved = False Then
                Dim x As Integer = 0
                Dim DateValue As Date = dtpFechaInicio.Value
                Dim BceMonto As Double = CDbl(txtMontoPrestamo.Text) + CDbl(txtCostoTramite.Text)
                Dim BcePagar As Double = txtTotalAPagar.Text
                Dim Capital, Intereses As Double
                Dim Porcentaje As Double = ((Replace(txtPorcInteres.Text, "%", ""))) / 100 / CDbl(DenomInteres.Text)
                DgvCuotas.Rows.Clear()


Inicio:
                If x = CInt(txtCantidadCuotas.Text) Then
                    GoTo Fin
                End If

                If cbxFormaPago.Text = "Mensual" Then
                    DateValue = DateValue.AddMonths(1)

                ElseIf cbxFormaPago.Text = "Anual" Then
                    DateValue = DateValue.AddYears(1)
                Else
                    DateValue = DateValue.AddDays(Dias.Text)
                End If

                If ChkEvitSaturday.Checked = True Then
                    If DateValue.DayOfWeek = 6 Then
                        DateValue = DateValue.AddDays(1)
                    End If
                End If
                If ChkEvitSunday.Checked = True Then
                    If DateValue.DayOfWeek = DayOfWeek.Sunday Then
                        DateValue = DateValue.AddDays(1)
                    End If
                End If

                With DgvCuotas
                    If chkRedondearCuotas.Checked = True Then
                        If cbxMetodo.Text = "Lineal" Then
                            BcePagar = BcePagar - CDbl(txtMontoPagos.Text)
                            .Rows.Add("", x + 1, CDbl(txtMontoPagos.Text).ToString("C4"), DateValue.ToString("dd/MM/yyyy"), (CDbl(txtGranTotal.Text) / CDbl(txtCantidadCuotas.Text)).ToString("C4"), Math.Round(((CDbl(txtMontoPrestamo.Text) - CDbl(txtGranTotal.Text)) / CDbl(txtCantidadCuotas.Text))).ToString("C4"), BcePagar.ToString("C4"), ConvertNumbertoString(txtMontoPagos.Text))
                        End If

                        If cbxMetodo.Text = "Amortizado" Then
                            Intereses = Math.Round(BceMonto * Porcentaje)
                            Capital = Math.Round(CDbl(txtMontoPagos.Text) - Intereses)
                            BcePagar = Math.Round(BcePagar - CDbl(txtMontoPagos.Text))

                            .Rows.Add("", x + 1, CDbl(txtMontoPagos.Text).ToString("C4"), DateValue.ToString("dd/MM/yyyy"), Capital.ToString("C4"), Math.Round(Intereses).ToString("C4"), BcePagar.ToString("C4"), ConvertNumbertoString(txtMontoPagos.Text))

                            BceMonto = Math.Round(BceMonto - CDbl(Capital))
                        End If

                        If cbxMetodo.Text = "Amortizado Compuesto" Then
                            BcePagar = Math.Round(BcePagar - CDbl(txtMontoPagos.Text))
                            .Rows.Add("", x + 1, CDbl(txtMontoPagos.Text).ToString("C4"), DateValue.ToString("dd/MM/yyyy"), CDbl(0).ToString("C4"), CDbl(0).ToString("C4"), BcePagar.ToString("C4"), ConvertNumbertoString(txtMontoPagos.Text))
                        End If

                        If cbxMetodo.Text = "Sólo A Interés" Then
                            If x + 1 = CInt(txtCantidadCuotas.Text) Then
                                BcePagar = Math.Round(0)
                                .Rows.Add("", x + 1, (CDbl(txtMontoPagos.Text) + CDbl(txtMontoPrestamo.Text)).ToString("C4"), DateValue.ToString("dd/MM/yyyy"), CDbl(txtMontoPrestamo.Text).ToString("C4"), Math.Round(CDbl(txtMontoPagos.Text)).ToString("C4"), BcePagar.ToString("C4"), ConvertNumbertoString(txtMontoPagos.Text))
                            Else
                                BcePagar = CDbl(txtMontoPrestamo.Text).ToString("C4")
                                .Rows.Add("", x + 1, CDbl(txtMontoPagos.Text).ToString("C4"), DateValue.ToString("dd/MM/yyyy"), CDbl(0).ToString("C4"), CDbl(txtMontoPagos.Text).ToString("C4"), BcePagar.ToString("C4"), ConvertNumbertoString(txtMontoPagos.Text))
                            End If
                        End If
                    Else

                        If cbxMetodo.Text = "Lineal" Then
                            BcePagar = BcePagar - CDbl(txtMontoPagos.Text)
                            .Rows.Add("", x + 1, CDbl(txtMontoPagos.Text).ToString("C4"), DateValue.ToString("dd/MM/yyyy"), (CDbl(txtGranTotal.Text) / CDbl(txtCantidadCuotas.Text)).ToString("C4"), Math.Round(((CDbl(txtMontoPrestamo.Text) - CDbl(txtGranTotal.Text)) / CDbl(txtCantidadCuotas.Text)), 4).ToString("C4"), BcePagar.ToString("C4"), ConvertNumbertoString(txtMontoPagos.Text))
                        End If

                        If cbxMetodo.Text = "Amortizado" Then
                            Intereses = Math.Round(BceMonto * Porcentaje, 4)
                            Capital = Math.Round(CDbl(txtMontoPagos.Text) - Intereses, 4)
                            BcePagar = Math.Round(BcePagar - CDbl(txtMontoPagos.Text), 4)

                            .Rows.Add("", x + 1, CDbl(txtMontoPagos.Text).ToString("C4"), DateValue.ToString("dd/MM/yyyy"), Capital.ToString("C4"), Math.Round(Intereses, 4).ToString("C4"), BcePagar.ToString("C4"), ConvertNumbertoString(txtMontoPagos.Text))

                            BceMonto = Math.Round(BceMonto - CDbl(Capital), 4)
                        End If

                        If cbxMetodo.Text = "Amortizado Compuesto" Then
                            BcePagar = Math.Round(BcePagar - CDbl(txtMontoPagos.Text), 4)
                            .Rows.Add("", x + 1, CDbl(txtMontoPagos.Text).ToString("C4"), DateValue.ToString("dd/MM/yyyy"), CDbl(0).ToString("C4"), CDbl(0).ToString("C4"), BcePagar.ToString("C4"), ConvertNumbertoString(txtMontoPagos.Text))
                        End If

                        If cbxMetodo.Text = "Sólo A Interés" Then
                            If x + 1 = CInt(txtCantidadCuotas.Text) Then
                                BcePagar = Math.Round(0)
                                .Rows.Add("", x + 1, (CDbl(txtMontoPagos.Text) + CDbl(txtMontoPrestamo.Text)).ToString("C4"), DateValue.ToString("dd/MM/yyyy"), CDbl(txtMontoPrestamo.Text).ToString("C4"), Math.Round(CDbl(txtMontoPagos.Text), 4).ToString("C4"), BcePagar.ToString("C4"), ConvertNumbertoString(txtMontoPagos.Text))
                            Else
                                BcePagar = CDbl(txtMontoPrestamo.Text).ToString("C4")
                                .Rows.Add("", x + 1, CDbl(txtMontoPagos.Text).ToString("C4"), DateValue.ToString("dd/MM/yyyy"), CDbl(0).ToString("C4"), CDbl(txtMontoPagos.Text).ToString("C4"), BcePagar.ToString("C4"), ConvertNumbertoString(txtMontoPagos.Text))
                            End If
                        End If
                    End If
                End With

                x = x + 1
                GoTo Inicio

Fin:

                dtpFechaFinal.Value = DateValue

            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillComprobante()
        Try
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
            Else
                MessageBox.Show("No se pudo cargar ningún tipo de comprobante fiscal para definirla en el financiamiento ya que no se encontraron resultados en la base de datos. Cree los tipos de comprobantes fiscales." & vbNewLine & vbNewLine & "El financiamiento no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

            Tabla.Dispose()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillVendedores()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados ORDER BY Nombre ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Empleados")
            cbxVendedor.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Empleados")
            For Each Fila As DataRow In Tabla.Rows
                cbxVendedor.Items.Add(Fila.Item("Nombre"))
            Next

            If Tabla.Rows.Count > 0 Then

            Else
                MessageBox.Show("No se pudo cargar ningún vendedor para definirla en el financiamiento ya que no se encontraron resultados en la base de datos." & vbNewLine & vbNewLine & "El financiamiento no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

            Tabla.Dispose()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class