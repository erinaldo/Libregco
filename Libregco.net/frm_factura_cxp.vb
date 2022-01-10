Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Net.Mail
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Net

Public Class frm_factura_cxp

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend DefaultCondicion, ImponerEscrituradeNCF, TypeOfMetod, VerificarSubtotales, PermitirDuplicados, CantDecimales As String
    Friend RutaDocumento, lblDiasCondicion As New Label
    Dim Permisos As New ArrayList
    Private MailRegex As New Regex("^[-a-z0-9!#$%&'*+/=?^_`{|}~]+(?:\.[-a-z0-9!#$%&'*+/=?^_`{|}~]+)*@(?:[a-z0-9]([-a-z0-9]{0,61}[a-z0-9])?\.)*(?:aero|arpa|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|[a-z][a-z])$",
         RegexOptions.Compiled)

    Private Sub frm_factura_cxp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        SetConfiguracion()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
        SelectUsuario()
    End Sub

    Private Sub SetConfiguracion()
        Try
            ConMixta.Open()

            'Condicion Predeterminada
            cmd = New MySqlCommand("Select Condicion from" & SysName.Text & "Configuracion INNER JOIN Libregco.Condicion on Configuracion.Value2Int=Condicion.IDCondicion Where IDConfiguracion=59", ConMixta)
            DefaultCondicion = Convert.ToString(cmd.ExecuteScalar())

            'TipoComprobante
            cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=75", ConMixta)
            TypeOfMetod = Convert.ToString(cmd.ExecuteScalar())

            'Hacer revisión de subtotales durante el registro de compras
            cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=164", ConMixta)
            VerificarSubtotales = Convert.ToString(cmd.ExecuteScalar())

            'Permitir duplicados
            cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=169", ConMixta)
            PermitirDuplicados = Convert.ToString(cmd.ExecuteScalar())

            'Cantidad de decimales
            cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=168", ConMixta)
            CantDecimales = Convert.ToString(cmd.ExecuteScalar())
            txtCantDecimales.Value = CantDecimales

            ConMixta.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub ActualizarTodo()
        XtraTabPage3.PageVisible = False
        XtraTabControl1.SelectedTabPageIndex = 0
        CbxAlmacen.Tag = ""
        ControlSuperClave = 0
        chkNulo.Checked = False
        txtTasa.Text = 1
        txtSubTotal.Text = CDbl(0.0).ToString("C" & CantDecimales)
        txtFlete.Text = CDbl(0.0).ToString("C" & CantDecimales)
        txtNeto.Text = CDbl(0.0).ToString("C" & CantDecimales)
        txtDescuento.Text = CDbl(0.0).ToString("C" & CantDecimales)
        txtItbis.Text = CDbl(0.0).ToString("C" & CantDecimales)
        txtFecha.Text = Today.ToString("dd/MM/yyyy")
        chkEnviarReporte.Checked = False
        chkEnviarCopiaDigital.Checked = False
        lblStatusBar.Text = "Listo"
        lblStatusBar.ForeColor = Color.Black
        Label30.Text = "Cant. de caracteres: "
        MostrarControlSubTotales()
        DtpFechaFact.Value = Today
        DtpVencimiento.Value = Today
        DtpDiaRecibido.Value = Today
        DtpDiaRecibido.Value = Today
        FillComprobanteFiscal()
        FillRecepcion()
        FillAlmacen()
        FillCondicion()
        FillMonedas()
        FillGastos()
        HabilitarEnvioDatos()
        FillCorreos()
    End Sub

    Private Sub FillGastos()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT TipoGasto FROM libregco.tipogasto where Nulo=0 ORDER BY IDGASTO ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoGasto")
            cbxGasto.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("TipoGasto")
            For Each Fila As DataRow In Tabla.Rows
                cbxGasto.Items.Add(Fila.Item("TipoGasto"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxGasto.SelectedIndex = 0
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Sub HabilitarEnvioDatos()
        If txtIDCompra.Text <> "" Then
            XtraTabPage3.PageVisible = True

            If RutaDocumento.Text = "" Then
                chkEnviarCopiaDigital.Checked = False
                chkEnviarCopiaDigital.Enabled = False
                chkEnviarReporte.Enabled = True

            Else
                chkEnviarCopiaDigital.Checked = False
                chkEnviarReporte.Checked = False
                chkEnviarCopiaDigital.Enabled = True
                chkEnviarReporte.Enabled = True
            End If
        Else
            XtraTabPage3.PageVisible = False
        End If

    End Sub

    Private Sub FillMonedas()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Texto FROM libregco.tipomoneda order by IDTipoMoneda ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Moneda")
            cbxMoneda.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Moneda")

            For Each Fila As DataRow In Tabla.Rows
                cbxMoneda.Items.Add(Fila.Item("Texto"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxMoneda.SelectedIndex = 0
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub MostrarControlSubTotales()
        If txtSecondID.Text = "" Then
            VerificarSubtotalesToolStripMenuItem.Visible = False
        Else
            VerificarSubtotalesToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub FillRecepcion()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Nombre FROM Empleados ORDER BY Nombre ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Empleados")
        CbxEmpleadoRec.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Empleados")

        For Each Fila As DataRow In Tabla.Rows
            CbxEmpleadoRec.Items.Add(Fila.Item("Nombre"))
        Next

    End Sub

    Private Sub FillAlmacen()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Almacen FROM Almacen ORDER BY Almacen ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Almacen")
        CbxAlmacen.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Almacen")

        For Each Fila As DataRow In Tabla.Rows
            CbxAlmacen.Items.Add(Fila.Item("Almacen"))
        Next

    End Sub

    Private Sub FillComprobanteFiscal()
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

    End Sub

    Private Sub FillCondicion()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Condicion FROM Condicion ORDER BY Dias ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Condicion")
        cbxCondicion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Condicion")

        For Each Fila As DataRow In Tabla.Rows
            cbxCondicion.Items.Add(Fila.Item("Condicion"))
        Next

    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        SetIDCondicion()

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Dias FROM Libregco.Condicion Where Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        lblDiasCondicion.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        If lblDiasCondicion.Text = 0 Then
            DtpVencimiento.Value = DtpFechaFact.Value
            DtpVencimiento.Enabled = False
        Else

            DtpVencimiento.Enabled = True

            If CDbl(lblDiasCondicion.Text) > 998 Then
                DtpVencimiento.Value = DtpFechaFact.Value.AddDays(30)
            Else
                DtpVencimiento.Value = DtpFechaFact.Value.AddDays(lblDiasCondicion.Text)
            End If

        End If
    End Sub

    Private Sub SetIDCondicion()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion WHERE Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        cbxCondicion.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub CbxTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxTipoComprobante.SelectedIndexChanged
        SetIDComprobante()
    End Sub

    Private Sub SetIDComprobante()
        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT * from" & SysName.Text & "ComprobanteFiscal Where TipoComprobante='" + CbxTipoComprobante.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Comprobantes")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds.Tables("Comprobantes")

        CbxTipoComprobante.Tag = Tabla.Rows(0).Item("IDComprobanteFiscal")
        ImponerEscrituradeNCF = Tabla.Rows(0).Item("ImposicionCompra")

        'If txtIDCompra.Text = "" Then
        If ImponerEscrituradeNCF = 1 Then
                If TypeOfMetod = 1 Then
                    txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                    txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                ElseIf TypeOfMetod = 2 Then
                    txtNCF.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                    txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                ElseIf TypeOfMetod = 3 Then
                    txtNCF.Mask = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF") & CDbl(0).ToString.PadLeft(Tabla.Rows(0).Item("Longitud"), "0")
                    txtNCF.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                End If
            Else
                If TypeOfMetod = 1 Then
                    txtNCF.Mask = ""

                ElseIf TypeOfMetod = 2 Then
                    txtNCF.Mask = ""

                ElseIf TypeOfMetod = 3 Then
                    txtNCF.Mask = ""

                End If
            End If

        'Else
        '    txtNCF.Mask = ""
        'End If



    End Sub

    Private Sub CbxEmpleadoRec_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxEmpleadoRec.SelectedIndexChanged
        SetIDEmpleadoRec()
    End Sub

    Private Sub SetIDEmpleadoRec()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + CbxEmpleadoRec.SelectedItem + "'", Con)
        CbxEmpleadoRec.Tag = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub CbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxAlmacen.SelectedIndexChanged
        SetIDAlmacen()
    End Sub

    Private Sub SetIDAlmacen()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + CbxAlmacen.SelectedItem + "'", Con)
        CbxAlmacen.Tag = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtHora.Text = TimeOfDay.ToString("hh:mm:ss tt")
    End Sub

    Private Sub SelectUsuario()
        Try

            GbxUserInfo.Text = "User Info --> " & frm_inicio.Button3.Text & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]"
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        HabilitarControles()
        RutaDocumento.Text = ""
        txtIDCompra.Clear()
        txtIDSuplidor.Clear()
        txtNombreSuplidor.Clear()
        txtBalanceSup.Clear()
        txtUltimoMonto.Clear()
        txtSecondID.Clear()
        txtUltimoPago.Clear()
        txtNoFact.Clear()
        txtReferencia.Clear()
        txtNCF.Clear()
        txtNotaCompra.Clear()
        cbxCondicion.Items.Clear()
        CbxTipoComprobante.Items.Clear()
        CbxEmpleadoRec.Items.Clear()
        CbxAlmacen.Items.Clear()
        chkNulo.Checked = False
        btnBuscarSup.Focus()
    End Sub

    Private Sub txtFlete_Leave(sender As Object, e As EventArgs) Handles txtFlete.Leave
        If txtFlete.Text = "" Then
            txtFlete.Text = CDbl(0).ToString("C")
        Else
            txtFlete.Text = CDbl(txtFlete.Text).ToString("C")
            SumarNeto()
        End If
    End Sub

    Private Sub txtFlete_Enter(sender As Object, e As EventArgs) Handles txtFlete.Enter
        If txtFlete.Text = "" Then
        Else
            txtFlete.Text = CDbl(txtFlete.Text)
        End If
    End Sub

    Private Sub ConvertCurrent()
        txtSubTotal.Text = CDbl(txtSubTotal.Text).ToString("C")
        txtItbis.Text = CDbl(txtItbis.Text).ToString("C")
        txtDescuento.Text = CDbl(txtDescuento.Text).ToString("C")
        txtFlete.Text = CDbl(txtFlete.Text).ToString("C")
        txtNeto.Text = CDbl(txtNeto.Text).ToString("C")
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
            Con.Close()
        End Try
    End Sub

    Private Sub UltCompra()
        Try

            If txtIDCompra.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDCompra from Compras where IDCompra= (Select Max(IDCompra) from Compras)", Con)
                txtIDCompra.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CalcBces()
        FunctCalcBcesFactSuplidor(txtIDSuplidor.Text)
        FunctCalcBceSuplidor(txtIDSuplidor.Text)
    End Sub

    Private Sub chkAnular_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            DeshabilitarControles()
        Else
            HabilitarControles()
        End If
    End Sub

    Private Sub DeshabilitarControles()
        GroupControl1.Enabled = False
        GroupControl2.Enabled = False
        XtraTabPage1.PageEnabled = False
        txtFlete.Enabled = False
        txtSubTotal.Enabled = False
        txtDescuento.Enabled = False
        txtItbis.Enabled = False
        txtNeto.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        GroupControl1.Enabled = True
        GroupControl2.Enabled = True
        XtraTabPage1.PageEnabled = True
        txtFlete.Enabled = True
        txtSubTotal.Enabled = True
        txtDescuento.Enabled = True
        txtItbis.Enabled = True
        txtNeto.Enabled = True
    End Sub


    Private Sub DtpDiaRecibido_ValueChanged(sender As Object, e As EventArgs) Handles DtpDiaRecibido.ValueChanged
        If DtpDiaRecibido.Value < DtpFechaFact.Value Then
            MessageBox.Show("La fecha de recepción de compras no puede ser menor a la fecha de facturacíon. Verifique los datos para continuar.", "Error en fecha de recepción", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            DtpDiaRecibido.Value = DtpFechaFact.Value
        Else
        End If
    End Sub

    Private Sub DtpVencimiento_ValueChanged(sender As Object, e As EventArgs) Handles DtpVencimiento.ValueChanged
        If DtpVencimiento.Value < DtpFechaFact.Value Then
            MessageBox.Show("La fecha de vencimiento de compras no puede ser menor a la fecha de facturacíon. Verifique los datos para continuar.", "Error en fecha de vencimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            DtpVencimiento.Value = DtpFechaFact.Value
        Else
        End If
    End Sub

    Private Sub ConvertDouble()
        txtSubTotal.Text = CDbl(txtSubTotal.Text)
        txtItbis.Text = CDbl(txtItbis.Text)
        txtDescuento.Text = CDbl(txtDescuento.Text)
        txtFlete.Text = CDbl(txtFlete.Text)
        txtNeto.Text = CDbl(txtNeto.Text)
    End Sub

    Private Sub SumarNeto()
        Dim SubTotal, Descuento, Itbis, Flete As Double
        SubTotal = txtSubTotal.Text
        Descuento = txtDescuento.Text
        Itbis = txtItbis.Text
        Flete = txtFlete.Text

        txtNeto.Text = CDbl(SubTotal - Descuento + Itbis + Flete).ToString("C")
    End Sub

    Private Sub txtSubTotal_Leave(sender As Object, e As EventArgs) Handles txtSubTotal.Leave
        If txtSubTotal.Text = "" Then
            txtSubTotal.Text = CDbl(0).ToString("C")
        Else
            txtSubTotal.Text = CDbl(txtSubTotal.Text).ToString("C")
            SumarNeto()
        End If

    End Sub

    Private Sub txtDescuento_Leave(sender As Object, e As EventArgs) Handles txtDescuento.Leave
        If txtDescuento.Text = "" Then
            txtDescuento.Text = CDbl(0).ToString("C")
        Else
            txtDescuento.Text = CDbl(txtDescuento.Text).ToString("C")
            SumarNeto()
        End If
    End Sub

    Private Sub txtItbis_Leave(sender As Object, e As EventArgs) Handles txtItbis.Leave
        If txtItbis.Text = "" Then
            txtItbis.Text = CDbl(0).ToString("C")
        Else
            txtItbis.Text = CDbl(txtItbis.Text).ToString("C")
            SumarNeto()
        End If
    End Sub

    Private Sub txtSubTotal_Enter(sender As Object, e As EventArgs) Handles txtSubTotal.Enter
        If txtSubTotal.Text = "" Then
        Else
            txtSubTotal.Text = CDbl(txtSubTotal.Text)
        End If
    End Sub

    Private Sub txtDescuento_Enter(sender As Object, e As EventArgs) Handles txtDescuento.Enter
        If txtDescuento.Text = "" Then
        Else
            txtDescuento.Text = CDbl(txtDescuento.Text)
        End If
    End Sub

    Private Sub txtItbis_Enter(sender As Object, e As EventArgs) Handles txtItbis.Enter
        If txtItbis.Text = "" Then
        Else
            txtItbis.Text = CDbl(txtItbis.Text)
        End If
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDCompra.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el registro de compras?", "Imprimir Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarSuplidorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarSuplidorToolStripMenuItem.Click
        btnBuscarSup.PerformClick()
    End Sub

    Private Sub BuscarCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarCompraToolStripMenuItem.Click
        btnBuscarCompra.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
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
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=19", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE Compras SET SecondID='" + lblSecondID.Text + "' WHERE IDCompra='" + txtIDCompra.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=19"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try

            If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor para procesar la factura.", "Elegir Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSup.PerformClick()
            Exit Sub
        ElseIf txtNoFact.Text = "" Then
            MessageBox.Show("Escriba el No. de factura del documento.", "No. de Factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNoFact.Focus()
            Exit Sub
        ElseIf txtNeto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba los sub-totales de la factura a procesar.", "Monto de factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtSubTotal.Focus()
            Exit Sub
        ElseIf cbxCondicion.Text = "" Then
            MessageBox.Show("Seleccione la condición de la factura.", "Seleccionar condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxCondicion.Focus()
            cbxCondicion.DroppedDown = True
            Exit Sub
        ElseIf CbxAlmacen.Text = "" Then
            MessageBox.Show("Seleccione el almacén de la factura.", "Seleccionar almacén", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxAlmacen.Focus()
            CbxAlmacen.DroppedDown = True
            Exit Sub
        ElseIf CbxEmpleadoRec.Text = "" Then
            MessageBox.Show("Seleccione el empleado que recibió la factura.", "Seleccionar empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxEmpleadoRec.Focus()
            CbxEmpleadoRec.DroppedDown = True
            Exit Sub
        ElseIf CbxTipoComprobante.Text = "" Then
            MessageBox.Show("Seleccione el tipo de comprobante fiscal de la factura.", "Seleccionar Tipo de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxTipoComprobante.Focus()
            CbxTipoComprobante.DroppedDown = True
            Exit Sub
        End If

            If txtIDCompra.Text = "" Then
                If Permisos(1) = 0 Then
                    MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva factura de compras del suplidor " & txtNombreSuplidor.Text & " [" & txtIDSuplidor.Text & "] en la base de datos?", "Guardar Nueva Factura de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then

                    FindSimilaritiesCompras(txtIDSuplidor.Text, txtFecha.Text, txtNCF.Text, txtNoFact.Text)
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                    Con.Open()
                    cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=9", Con)
                    Dim AvisoInconsistencia = Convert.ToString(cmd.ExecuteScalar())
                    Con.Close()

                    If AvisoInconsistencia = 1 Then
                        If ImponerEscrituradeNCF = 1 Then
                            Dim thisMonth As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
                            Dim FirstDayofMonth As DateTime = thisMonth.ToString("yyyy-MM-01")
                            Dim LastDayOfMonth As DateTime = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
                            If CDate(DtpFechaFact.Value) > CDate(LastDayOfMonth) Or CDate(DtpFechaFact.Value) < FirstDayofMonth Then
                                MessageBox.Show("La factura de compra que está generando no pertenece al mes actual." & vbNewLine & vbNewLine & "Esta diferencia implica que la factura podría no ser presentada satisfactoriamente al fisco.", "Aviso de fecha de factura retrasada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                frm_superclave.IDAccion.Text = 99
                                frm_superclave.ShowDialog(Me)
                                If ControlSuperClave = 1 Then
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If

                    ConvertDouble()
                    sqlQ = "INSERT INTO Compras (IDTipoDocumento,IDSuplidor,IDUsuario,Fecha,Hora,IDCondicion,FechaFactura,FechaVencimiento,NoFactura,Referencia,IDComprobanteFiscal,NCF,TipoItbis,IDSucursal,IDAlmacen,SubTotal,Descuento,Descuento2,ITBIS,Flete,TotalNeto,IDEmpleadoRec,DiaRecepcion,Nota,PrecioDiferido,CreditoPendiente,ArticuloFuera,NegociarFlete,Averiados,DescuentoAlPago,IDTipoGasto,IDMoneda,Tasa,Balance,RutaDocumento,Nulo,Impreso,SubtotalLlenado,SubtotalBienes,SubtotalServicios,ItbisFacturado,ItbisRetenido,ItbisProporcionalidad,ItbisalCosto,ItbisAdelantar,ItbisPercibidoenCompras,IDISRTipoRetencion,ISRPercibido,ISRMontoRetencion,ISCTotal,PropinaLegal,OtrosImpuestos,IDTipoPago,CantDecimales,NCFModificado) VALUES (19,'" + txtIDSuplidor.Text + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',curdate(),curtime(),'" + cbxCondicion.Tag.ToString + "','" + DtpFechaFact.Value.ToString("yyyy-MM-dd") + "','" + DtpVencimiento.Value.ToString("yyyy-MM-dd") + "','" + txtNoFact.Text + "','" + txtReferencia.Text + "','" + CbxTipoComprobante.Tag.ToString + "','" + txtNCF.Text + "','1','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + CbxAlmacen.Tag.ToString + "','" + txtSubTotal.Text + "','" + txtDescuento.Text + "','0','" + txtItbis.Text + "','" + txtFlete.Text + "','" + txtNeto.Text + "','" + CbxEmpleadoRec.Tag.ToString + "','" + DtpDiaRecibido.Value.ToString("yyyy-MM-dd") + "','" + txtNotaCompra.Text + "','0','0','0','0','0','0','" + cbxGasto.Tag.ToString + "','" + cbxMoneda.Tag.ToString + "','" + txtTasa.Text + "','" + txtNeto.Text + "','" + (Replace(RutaDocumento.Text, "\", "\\")) + "','" + Convert.ToInt16(chkNulo.Checked).ToString + "',0,0,'" + CDbl(txtSubTotal.Text).ToString + "',0,'" + CDbl(txtItbis.Text).ToString + "',0,0,0,0,0,1,0,0,0,0,0,1,'" + txtCantDecimales.Value.ToString + "','')"
                    GuardarDatos()
                    ConvertCurrent()
                    UltCompra()
                    SetSecondID()
                    CalcBces()
                    MoverFichero()
                    HabilitarEnvioDatos()

                    ToastNotificationsManager1.Notifications(0).Body = "La compra " & txtSecondID.Text & " ha sido guardada satisfactoriamente."
                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

                    If VerificarSubtotales = 1 Then
                        frm_subtotales_compras.ShowDialog(Me)
                    End If

                    ImprimirDocumento()

                    DeshabilitarControles()

                End If
            Else
                If Permisos(2) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la factura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    sqlQ = "UPDATE Compras SET IDSuplidor='" + txtIDSuplidor.Text + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDCondicion='" + cbxCondicion.Tag.ToString + "',FechaFactura='" + DtpFechaFact.Value.ToString("yyyy-MM-dd") + "',FechaVencimiento='" + DtpVencimiento.Value.ToString("yyyy-MM-dd") + "',NoFactura='" + txtNoFact.Text + "',Referencia='" + txtReferencia.Text + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',NCF='" + txtNCF.Text + "',TipoItbis='1',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + CbxAlmacen.Tag.ToString + "',SubTotal='" + txtSubTotal.Text + "',Descuento='" + txtDescuento.Text + "',ITBIS='" + txtItbis.Text + "',Descuento2='0',Flete='" + txtFlete.Text + "',TotalNeto='" + txtNeto.Text + "',IDEmpleadoRec='" + CbxEmpleadoRec.Tag.ToString + "',DiaRecepcion='" + DtpDiaRecibido.Value.ToString("yyyy-MM-dd") + "',Nota='" + txtNotaCompra.Text + "',PrecioDiferido='0',CreditoPendiente='0',ArticuloFuera='0',NegociarFlete='0',Averiados='0',DescuentoAlPago='0',IDTipoGasto='" + cbxGasto.Tag.ToString + "',IDMoneda='" + cbxMoneda.Tag.ToString + "',Tasa='" + txtTasa.Text + "',RutaDocumento='" + (Replace(RutaDocumento.Text, "\", "\\")) + "',CantDecimales='" + txtCantDecimales.Value.ToString + "',Nulo='" + Convert.ToInt16(chkNulo.Checked).ToString + "' WHERE IDCompra= (" + txtIDCompra.Text + ")"
                    GuardarDatos()
                    ConvertCurrent()
                    CalcBces()
                    MoverFichero()
                    HabilitarEnvioDatos()

                    ToastNotificationsManager1.Notifications(1).Body = "La compra " & txtSecondID.Text & " ha sido modificada satisfactoriamente."
                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))

                    If VerificarSubtotales = 1 Then
                        frm_subtotales_compras.ShowDialog(Me)
                    End If

                    ImprimirDocumento()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor para procesar la factura.", "Elegir Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSup.PerformClick()
            Exit Sub
        ElseIf txtNoFact.Text = "" Then
            MessageBox.Show("Escriba el No. de factura del documento.", "No. de Factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNoFact.Focus()
            Exit Sub
        ElseIf txtNeto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba los sub-totales de la factura a procesar.", "Monto de factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtSubTotal.Focus()
            Exit Sub
        ElseIf cbxCondicion.Text = "" Then
            MessageBox.Show("Seleccione la condición de la factura.", "Seleccionar condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxCondicion.Focus()
            cbxCondicion.DroppedDown = True
            Exit Sub

        ElseIf CbxEmpleadoRec.Text = "" Then
            MessageBox.Show("Seleccione el empleado que recibió la factura.", "Seleccionar empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxEmpleadoRec.Focus()
            CbxEmpleadoRec.DroppedDown = True
            Exit Sub
        ElseIf CbxTipoComprobante.Text = "" Then
            MessageBox.Show("Seleccione el tipo de comprobante fiscal de la factura.", "Seleccionar Tipo de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxTipoComprobante.Focus()
            CbxTipoComprobante.DroppedDown = True
            Exit Sub
        End If

        If txtIDCompra.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva factura de compras del suplidor " & txtNombreSuplidor.Text & " [" & txtIDSuplidor.Text & "] en la base de datos?", "Guardar Nueva Factura de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                FindSimilaritiesCompras(txtIDSuplidor.Text, txtFecha.Text, txtNCF.Text, txtNoFact.Text)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                Con.Open()
                cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=9", Con)
                Dim AvisoInconsistencia = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If AvisoInconsistencia = 1 Then
                    If ImponerEscrituradeNCF = 1 Then
                        Dim thisMonth As New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
                        Dim FirstDayofMonth As DateTime = thisMonth.ToString("yyyy-MM-01")
                        Dim LastDayOfMonth As DateTime = thisMonth.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
                        If CDate(DtpFechaFact.Value) > CDate(LastDayOfMonth) Or CDate(DtpFechaFact.Value) < FirstDayofMonth Then
                            MessageBox.Show("La factura de compra que está generando no pertenece al mes actual." & vbNewLine & vbNewLine & "Esta diferencia implica que la factura podría no ser presentada satisfactoriamente al fisco.", "Aviso de fecha de factura retrasada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            frm_superclave.IDAccion.Text = 99
                            frm_superclave.ShowDialog(Me)
                            If ControlSuperClave = 1 Then
                                Exit Sub
                            End If
                        End If
                    End If
                End If

                ConvertDouble()
                sqlQ = "INSERT INTO Compras (IDTipoDocumento,IDSuplidor,IDUsuario,Fecha,Hora,IDCondicion,FechaFactura,FechaVencimiento,NoFactura,Referencia,IDComprobanteFiscal,NCF,TipoItbis,IDSucursal,IDAlmacen,SubTotal,Descuento,Descuento2,ITBIS,Flete,TotalNeto,IDEmpleadoRec,DiaRecepcion,Nota,PrecioDiferido,CreditoPendiente,ArticuloFuera,NegociarFlete,Averiados,DescuentoAlPago,IDTipoGasto,IDMoneda,Tasa,Balance,RutaDocumento,Nulo,Impreso,SubtotalLlenado,SubtotalBienes,SubtotalServicios,ItbisFacturado,ItbisRetenido,ItbisProporcionalidad,ItbisalCosto,ItbisAdelantar,ItbisPercibidoenCompras,IDISRTipoRetencion,ISRPercibido,ISRMontoRetencion,ISCTotal,PropinaLegal,OtrosImpuestos,IDTipoPago,CantDecimales,NCFModificado) VALUES (19,'" + txtIDSuplidor.Text + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',curdate(),curtime(),'" + cbxCondicion.Tag.ToString + "','" + DtpFechaFact.Value.ToString("yyyy-MM-dd") + "','" + DtpVencimiento.Value.ToString("yyyy-MM-dd") + "','" + txtNoFact.Text + "','" + txtReferencia.Text + "','" + CbxTipoComprobante.Tag.ToString + "','" + txtNCF.Text + "','1','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + CbxAlmacen.Tag.ToString + "','" + txtSubTotal.Text + "','" + txtDescuento.Text + "','0','" + txtItbis.Text + "','" + txtFlete.Text + "','" + txtNeto.Text + "','" + CbxEmpleadoRec.Tag.ToString + "','" + DtpDiaRecibido.Value.ToString("yyyy-MM-dd") + "','" + txtNotaCompra.Text + "','0','0','0','0','0','0','" + cbxGasto.Tag.ToString + "','" + cbxMoneda.Tag.ToString + "','" + txtTasa.Text + "','" + txtNeto.Text + "','" + (Replace(RutaDocumento.Text, "\", "\\")) + "','" + Convert.ToInt16(chkNulo.Checked).ToString + "',0,0,'" + CDbl(txtSubTotal.Text).ToString + "',0,'" + CDbl(txtItbis.Text).ToString + "',0,0,0,0,0,1,0,0,0,0,0,1,'" + txtCantDecimales.Value.ToString + "','')"
                GuardarDatos()
                ConvertCurrent()
                UltCompra()
                SetSecondID()
                CalcBces()
                MoverFichero()
                HabilitarEnvioDatos()

                ToastNotificationsManager1.Notifications(0).Body = "La compra " & txtSecondID.Text & " ha sido guardada satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

                If VerificarSubtotales = 1 Then
                    frm_subtotales_compras.ShowDialog(Me)
                End If

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
                ConvertDouble()
                sqlQ = "UPDATE Compras SET IDSuplidor='" + txtIDSuplidor.Text + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDCondicion='" + cbxCondicion.Tag.ToString + "',FechaFactura='" + DtpFechaFact.Value.ToString("yyyy-MM-dd") + "',FechaVencimiento='" + DtpVencimiento.Value.ToString("yyyy-MM-dd") + "',NoFactura='" + txtNoFact.Text + "',Referencia='" + txtReferencia.Text + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',NCF='" + txtNCF.Text + "',TipoItbis='1',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + CbxAlmacen.Tag.ToString + "',SubTotal='" + txtSubTotal.Text + "',Descuento='" + txtDescuento.Text + "',ITBIS='" + txtItbis.Text + "',Descuento2='0',Flete='" + txtFlete.Text + "',TotalNeto='" + txtNeto.Text + "',IDEmpleadoRec='" + CbxEmpleadoRec.Tag.ToString + "',DiaRecepcion='" + DtpDiaRecibido.Value.ToString("yyyy-MM-dd") + "',Nota='" + txtNotaCompra.Text + "',PrecioDiferido='0',CreditoPendiente='0',ArticuloFuera='0',NegociarFlete='0',Averiados='0',DescuentoAlPago='0',IDTipoGasto='" + cbxGasto.Tag.ToString + "',IDMoneda='" + cbxMoneda.Tag.ToString + "',Tasa='" + txtTasa.Text + "',RutaDocumento='" + (Replace(RutaDocumento.Text, "\", "\\")) + "',CantDecimales='" + txtCantDecimales.Value.ToString + "',Nulo='" + Convert.ToInt16(chkNulo.Checked).ToString + "' WHERE IDCompra= (" + txtIDCompra.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcBces()
                MoverFichero()
                HabilitarEnvioDatos()

                ToastNotificationsManager1.Notifications(1).Body = "La compra " & txtSecondID.Text & " ha sido modificada satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))

                If VerificarSubtotales = 1 Then
                    frm_subtotales_compras.ShowDialog(Me)
                End If

                ImprimirDocumento()

                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscarCompra_Click(sender As Object, e As EventArgs) Handles btnBuscarCompra.Click
        frm_buscar_facturas_cxp.ShowDialog(Me)
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de compra No. " & txtIDCompra.Text & " del suplidor " & txtNombreSuplidor.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Factura de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 133
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE Compras SET IDSuplidor='" + txtIDSuplidor.Text + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha=CURDATE(),Hora=CURTIME(),IDCondicion='" + cbxCondicion.Tag.ToString + "',FechaFactura='" + DtpFechaFact.Value.ToString("yyyy-MM-dd") + "',FechaVencimiento='" + DtpVencimiento.Value.ToString("yyyy-MM-dd") + "',NoFactura='" + txtNoFact.Text + "',Referencia='" + txtReferencia.Text + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',NCF='" + txtNCF.Text + "',TipoItbis='1',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + CbxAlmacen.Tag.ToString + "',SubTotal='" + txtSubTotal.Text + "',Descuento='" + txtDescuento.Text + "',ITBIS='" + txtItbis.Text + "',Descuento2='0',Flete='" + txtFlete.Text + "',TotalNeto='" + txtNeto.Text + "',IDEmpleadoRec='" + CbxEmpleadoRec.Tag.ToString + "',DiaRecepcion='" + DtpDiaRecibido.Value.ToString("yyyy-MM-dd") + "',Nota='" + txtNotaCompra.Text + "',PrecioDiferido='0',CreditoPendiente='0',ArticuloFuera='0',NegociarFlete='0',Averiados='0',DescuentoAlPago='0',IDTipoGasto='" + cbxGasto.Tag.ToString + "',IDMoneda='" + cbxMoneda.Tag.ToString + "',Tasa='" + txtTasa.Text + "',RutaDocumento='" + (Replace(RutaDocumento.Text, "\", "\\")) + "',CantDecimales='" + txtCantDecimales.Value.ToString + "',Nulo='" + Convert.ToInt16(chkNulo.Checked).ToString + "' WHERE IDCompra= (" + txtIDCompra.Text + ")"
                GuardarDatos()
                CalcBces()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDCompra.Text = "" Then
            MessageBox.Show("No hay un registro de factura de compra abierto para desactivar", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular la factura de compra No. " & txtIDCompra.Text & " del suplidor " & txtNombreSuplidor.Text & " del sistema?", "Anular Factura de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 132
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE Compras SET IDSuplidor='" + txtIDSuplidor.Text + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha=CURDATE(),Hora=CURTIME(),IDCondicion='" + cbxCondicion.Tag.ToString + "',FechaFactura='" + DtpFechaFact.Value.ToString("yyyy-MM-dd") + "',FechaVencimiento='" + DtpVencimiento.Value.ToString("yyyy-MM-dd") + "',NoFactura='" + txtNoFact.Text + "',Referencia='" + txtReferencia.Text + "',IDComprobanteFiscal='" + CbxTipoComprobante.Tag.ToString + "',NCF='" + txtNCF.Text + "',TipoItbis='1',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + CbxAlmacen.Tag.ToString + "',SubTotal='" + txtSubTotal.Text + "',Descuento='" + txtDescuento.Text + "',ITBIS='" + txtItbis.Text + "',Descuento2='0',Flete='" + txtFlete.Text + "',TotalNeto='" + txtNeto.Text + "',IDEmpleadoRec='" + CbxEmpleadoRec.Tag.ToString + "',DiaRecepcion='" + DtpDiaRecibido.Value.ToString("yyyy-MM-dd") + "',Nota='" + txtNotaCompra.Text + "',PrecioDiferido='0',CreditoPendiente='0',ArticuloFuera='0',NegociarFlete='0',Averiados='0',DescuentoAlPago='0',IDTipoGasto='" + cbxGasto.Tag.ToString + "',IDMoneda='" + cbxMoneda.Tag.ToString + "',Tasa='" + txtTasa.Text + "',RutaDocumento='" + (Replace(RutaDocumento.Text, "\", "\\")) + "',CantDecimales='" + txtCantDecimales.Value.ToString + "',Nulo='" + Convert.ToInt16(chkNulo.Checked).ToString + "' WHERE IDCompra= (" + txtIDCompra.Text + ")"
                GuardarDatos()
                CalcBces()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub btnBuscarSup_Click(sender As Object, e As EventArgs) Handles btnBuscarSup.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub btnSubirFactura_Click(sender As Object, e As EventArgs) Handles btnSubirFactura.Click
        If TypeConnection.Text = 1 Then
            If frm_subir_documento.Visible = True Then
                frm_subir_documento.Close()
            End If

            frm_subir_documento.Show(Me)
            frm_subir_documento.PicDocumento.Width = 539
            frm_subir_documento.PicDocumento.Height = 607
            frm_subir_documento.PicDocumento.Location = New Point(0, 0)

            frm_subir_documento.RutaDocumento.Text = RutaDocumento.Text

            If RutaDocumento.Text <> "" Then
                If System.IO.File.Exists(RutaDocumento.Text) = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(RutaDocumento.Text, FileMode.Open, FileAccess.Read)
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

    Private Sub CreateFolder()
        Try
            Dim Exists As Boolean
            Exists = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & txtIDSuplidor.Text)

            If Exists = True Then
            Else
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & txtIDSuplidor.Text)
            End If


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub cbxGasto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxGasto.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDGasto FROM TipoGasto WHERE TipoGasto= '" + cbxGasto.SelectedItem + "'", ConLibregco)
        cbxGasto.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub cbxMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMoneda.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoMoneda FROM TipoMoneda WHERE Texto= '" + cbxMoneda.SelectedItem + "'", ConLibregco)
        cbxMoneda.Tag = Convert.ToString(cmd.ExecuteScalar())

        If txtIDCompra.Text = "" Then
            cmd = New MySqlCommand("SELECT TasaCompra FROM TipoMoneda WHERE Texto= '" + cbxMoneda.SelectedItem + "'", ConLibregco)
            txtTasa.Text = Convert.ToString(cmd.ExecuteScalar())
        End If

        ConLibregco.Close()
    End Sub

    Private Sub VerificarSubtotalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerificarSubtotalesToolStripMenuItem.Click
        frm_subtotales_compras.ShowDialog(Me)
    End Sub

    Private Sub txtNotaCompra_TextChanged(sender As Object, e As EventArgs) Handles txtNotaCompra.TextChanged
        Label30.Text = "Cant. de caracteres: " & txtNotaCompra.Text.Length.ToString
    End Sub

    Private Sub txtSubTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSubTotal.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtSubTotal.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuento.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtDescuento.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtItbis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItbis.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtItbis.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtFlete_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFlete.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtFlete.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub MoverFichero()
        Try
            CreateFolder()   'Verificamos si existe el folder del suplidor

            If RutaDocumento.Text = "" Then
            Else
                'Verifico si existe la carpeta del suplidor
                Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & txtIDSuplidor.Text)
                If Exists = False Then
                    System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & txtIDSuplidor.Text)
                End If


                'Verifico si existe el archivo de por anexar
                Dim ExistsFile As Boolean = System.IO.File.Exists(RutaDocumento.Text)

                If ExistsFile = True Then
                    Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & txtIDSuplidor.Text & "\" & txtSecondID.Text & "-" & txtNoFact.Text & ".png"

                    If RutaDestino <> RutaDocumento.Text Then
                        My.Computer.FileSystem.MoveFile(RutaDocumento.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                    End If

                    sqlQ = "UPDATE Compras SET RutaDocumento='" + (Replace(RutaDestino, "\", "\\")) + "' WHERE IDCompra= '" + txtIDCompra.Text + "'"
                    GuardarDatos()

                    'Devolver Nueva Ruta al los controles
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                    frm_subir_documento.PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                    RutaDocumento.Text = RutaDestino
                    wFile.Close()
                End If

            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub txtNCF_Leave(sender As Object, e As EventArgs) Handles txtNCF.Leave
        txtNCF.Text = txtNCF.Text.ToUpper
    End Sub

    Private Sub edtTo_ValidateToken(sender As Object, e As DevExpress.XtraEditors.TokenEditValidateTokenEventArgs) Handles edtTo.ValidateToken
        e.IsValid = MailRegex.IsMatch(e.Description)
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click

        If My.Computer.Network.IsAvailable = True Then

            If edtTo.GetTokenList.Count = 0 Then
                MessageBox.Show("Escriba al menos una dirección de correo electrónico de destinatario(s) para enviar los datos de este registro.", "No hay destinatarios", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            Dim Envios As New SmtpClient
            Dim Correos As New MailMessage
            Dim ReportPath As String

            Correos.To.Clear()
            Correos.Subject = "Registro de compras"
            Correos.IsBodyHtml = True
            Correos.Body = "<ul> <li>Raz&oacute;n Social: " & frm_inicio.lblRazon.Text & "</li> <li>Teminal: " & frm_inicio.Button4.Text & "</li> </ul><p>Notificamos el registro de la factura de compra No. <strong>" + txtNoFact.Text + "&nbsp;</strong>de fecha " + DtpFechaFact.Value.ToString("dd/MM/yyyy") + " del suplidor " + txtNombreSuplidor.Text + ", por un valor de " + txtNeto.Text + ".</p> <p>Este registro se encuentra guardado con el ID # <strong>" + txtSecondID.Text + "</strong>.</p><p>&nbsp;Este correo ha remitido por <strong>" + frm_inicio.lblNombre.Text + "</strong>.</p> <hr /> <p>Este mensaje ha sido enviado desde @<em><strong>Libregco</strong></em>.</p>"
            Correos.From = New System.Net.Mail.MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, System.Text.Encoding.UTF8)
            Correos.Priority = System.Net.Mail.MailPriority.Normal

            For Each st As String In edtTo.EditValue
                Correos.To.Add(Trim(String.Format(st)))
            Next

            If chkEnviarCopiaDigital.Checked = True Then
                Dim Attach As New System.Net.Mail.Attachment(RutaDocumento.Text)
                Correos.Attachments.Add(Attach)
            End If

            If chkEnviarReporte.Checked = True Then
                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue
                Dim crParameterFiledDefinitions As ParameterFieldDefinitions
                Dim crParameterFieldDefinition As ParameterFieldDefinition
                Dim crParameterRangeValue As ParameterRangeValue
                Dim ObjRpt As New ReportDocument

                'Buscar ubicacion del reporte
                Dim CompraReportPath As String
                Con.Open()
                cmd = New MySqlCommand("Select Path FROM" & SysName.Text & "reportes where IDReportes=72", Con)
                CompraReportPath = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                'Selecciono el tipo de conexion
                If TypeConnection.Text = 1 Then
                    ObjRpt.Load("\\" & PathServidor.Text & CompraReportPath)
                Else
                    ObjRpt.Load("C:" & CompraReportPath.Replace("\Libregco\Libregco.net", ""))
                End If

                'Limpio los antiguos parametros
                crParameterValues.Clear()

                crParameterDiscreteValue.Value = txtIDCompra.Text
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'Despues de cargados los datos, las opciones del PDF por DEfault
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOtions As New PdfRtfWordFormatOptions

                CrDiskFileDestinationOptions.DiskFileName = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), txtSecondID.Text) & ".pdf"
                ReportPath = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), txtSecondID.Text) & ".pdf"
                CrExportOptions = ObjRpt.ExportOptions

                With CrExportOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportFormatType = ExportFormatType.PortableDocFormat
                    .ExportDestinationOptions = CrDiskFileDestinationOptions
                    .ExportFormatOptions = CrFormatTypeOtions
                End With

                ObjRpt.Export()

                Dim Attach As New System.Net.Mail.Attachment(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), txtSecondID.Text) & ".pdf")
                Correos.Attachments.Add(Attach)
            End If

            'Envio del correo
            Correos.From = New MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString)
            Envios.Credentials = New NetworkCredential(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(37 - 1).Item("Value1Var").ToString)

            Envios.Host = "smtp.gmail.com"
            Envios.Port = 587
            Envios.EnableSsl = True
            Envios.Send(Correos)


            Envios.Dispose()
            Correos.Dispose()

            If System.IO.File.Exists(ReportPath) = True Then
                System.IO.File.Delete(ReportPath)
            End If

            Dim NotificacionMessage As New NotifyIcon
            NotificacionMessage.Icon = SystemIcons.Application
            NotificacionMessage.BalloonTipIcon = ToolTipIcon.Info
            NotificacionMessage.Visible = True


            With NotificacionMessage
                .Text = "El correo ha sido enviado exitosamente."
                .BalloonTipTitle = "Correo enviado"
                .BalloonTipText = "El correo ha sido enviado exitosamente."
                .ShowBalloonTip(2000)
            End With

            NotificacionMessage.Dispose()


            'MessageBox.Show("El correo ha sido enviado exitosamente.", "Envío Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        Else
            MessageBox.Show("No se ha encontrado acceso a Internet para procesar la acción.", "No se detectó acceso a Internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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

    Private Sub FillCorreos()
        Try

            edtTo.Properties.Tokens.Clear()
            edtTo.EditValue = Nothing

            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select CorreoElectronico FROM empleados where correoelectronico<>'' and Nulo=0 group by correoelectronico", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Correo")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Correo")
            For Each Fila As DataRow In Tabla.Rows
                edtTo.Properties.Tokens.Add(New DevExpress.XtraEditors.TokenEditToken(Fila.Item(0)))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

End Class