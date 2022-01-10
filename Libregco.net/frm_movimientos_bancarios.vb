Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_movimientos_bancarios

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblchkNulo, lblIDTipoMovimiento, lblIDCuentaBancaria, lblRutaDocumento As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_movimientos_bancarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
        CheckForm()
    End Sub

    Private Sub CheckForm()
        Try
            If Me.Owner.Name = frm_pago_compras.Name Then
                ControlSuperClave = 0
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT TipoMovimiento FROM libregco.tipomovbancario where IDTipoMovBancario=8", ConMixta)
                cbxTipoMovimiento.Text = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()
                cbxTipoMovimiento.Enabled = False
                btnNuevo.Enabled = False
                txtConcepto.Text = frm_pago_compras.txtConcepto.Text
                txtMonto.Text = frm_pago_compras.txtTransferencia.Text
                txtMonto.Enabled = False
            Else
                ControlSuperClave = 1
                txtMonto.Enabled = True
                cbxTipoMovimiento.Enabled = True
                btnNuevo.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtFuncion.Clear()
        txtGerente.Clear()
        txtSucursalDirecta.Clear()
        txtTitular.Clear()
        txtMoneda.Clear()
        txtBalanceconReserva.Clear()
        cbxTipoMovimiento.Items.Clear()
        cbxCuentaBancaria.Items.Clear()
        txtBalance.Clear()
        txtBanco.Clear()
        dtpFecha.Value = Today
        txtMonto.Clear()
        txtConcepto.Clear()
        txtIDMovimientoBanc.Clear()
        txtSecondID.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        lblRutaDocumento.Text = ""
        txtReferencia.Clear()
    End Sub

    Private Sub ActualizarTodo()
        Try
            txtNCF.Visible = False
            lblNCF.Visible = False
            txtCapital.Visible = False
            txtInteres.Visible = False
            Label13.Visible = False
            Label14.Visible = False
            txtCapital.Text = CDbl(0).ToString("C")
            txtInteres.Text = CDbl(0).ToString("C")
            txtMonto.Text = CDbl(0).ToString("C")
            ControlSuperClave = 1
            lblchkNulo.Text = 0
            txtFecha.Text = Today.ToString("yyyy-MM-dd")
            txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
            lblSumaLetra.Text = ""
            chkNulo.Checked = False
            HabilitarControles()
            FillTipoMovimiento()
            FillCuentaBanc()
            cbxTipoMovimiento.Focus()
            Hora.Enabled = True
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Sub SetIDCuentaBanc()
        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT CuentasBancarias.IDCuenta,CuentasBancarias.IDBanco,Bancos.Identidad,SucursalDirecta,Oficial,Titular,TipoMoneda.Texto,CuentasBancarias.Balance,CuentasBancarias.LimiteReserva FROM" & SysName.Text & "cuentasbancarias INNER JOIN Libregco.TipoMoneda on CuentasBancarias.IDTipoMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco Where NoCuenta= '" + cbxCuentaBancaria.SelectedItem + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "cuentasbancarias")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds.Tables("cuentasbancarias")

        lblIDCuentaBancaria.Text = (Tabla.Rows(0).Item("IDCuenta"))
        txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))
        txtSucursalDirecta.Text = (Tabla.Rows(0).Item("SucursalDirecta"))
        txtGerente.Text = (Tabla.Rows(0).Item("Oficial"))
        txtTitular.Text = (Tabla.Rows(0).Item("Titular"))
        txtMoneda.Text = (Tabla.Rows(0).Item("Texto"))
        txtBalance.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
        txtBalanceconReserva.Text = (CDbl(Tabla.Rows(0).Item("Balance")) + CDbl(Tabla.Rows(0).Item("LimiteReserva"))).ToString("C")
    End Sub

    Sub SetIDTipoMovimiento()

        If ConMixta.State = ConnectionState.Open Then
            ConMixta.Close()
        End If

        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDTipoMovBancario,TipoMovimiento,TipoMovBancario.IDTipoFuncion,TipoFuncion.Descripcion,PedirNCF,PedirCapInt FROM Libregco.tipomovbancario INNER JOIN Libregco.TipoFuncion on TipoMovBancario.IDTipoFuncion=TipoFuncion.IDTipoFuncion Where TipoMovimiento= '" + cbxTipoMovimiento.SelectedItem + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoMovimiento")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoMovimiento")
        lblIDTipoMovimiento.Text = (Tabla.Rows(0).Item("IDTipoMovBancario"))
        txtFuncion.Text = (Tabla.Rows(0).Item("Descripcion"))

        If (Tabla.Rows(0).Item("PedirNCF")) = 0 Then
            txtNCF.Visible = False
            lblNCF.Visible = False
        Else
            txtNCF.Visible = True
            lblNCF.Visible = True
        End If

        If (Tabla.Rows(0).Item("PedirCapInt")) = 0 Then
            txtCapital.Visible = False
            txtInteres.Visible = False
            Label13.Visible = False
            Label14.Visible = False
        Else
            txtCapital.Visible = True
            txtInteres.Visible = True
            Label13.Visible = True
            Label14.Visible = True
        End If
    End Sub

    Private Sub FillCuentaBanc()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT NoCuenta FROM cuentasbancarias Where Nulo=0", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Cuentasbancarias")
        cbxCuentaBancaria.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Cuentasbancarias")

        For Each Fila As DataRow In Tabla.Rows
            cbxCuentaBancaria.Items.Add(Fila.Item("NoCuenta"))
        Next

    End Sub

    Private Sub FillTipoMovimiento()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT TipoMovimiento FROM TipoMovBancario where IDTipoMovBancario>1 and Nulo=0 ORDER BY TipoMovimiento ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoMovBancario")
        cbxTipoMovimiento.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoMovBancario")
        For Each Fila As DataRow In Tabla.Rows
            cbxTipoMovimiento.Items.Add(Fila.Item("TipoMovimiento"))
        Next

    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub cbxCuentaBancaria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCuentaBancaria.SelectedIndexChanged
        SetIDCuentaBanc()
    End Sub

    Private Sub cbxTipoMovimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoMovimiento.SelectedIndexChanged
        SetIDTipoMovimiento()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
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

    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtMonto.Leave
        Try

            If txtMonto.Text = "" Then
                txtMonto.Text = CDbl(0).ToString("C")
            Else
                txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
            End If

           
            lblSumaLetra.Text = "LA SUMA DE " & ConvertNumbertoString(txtMonto.Text)

        Catch ex As Exception
            txtMonto.Text = CDbl(0).ToString("C")
            lblSumaLetra.Text = ""
        End Try
    End Sub

    Private Sub txtMonto_Enter(sender As Object, e As EventArgs) Handles txtMonto.Enter
        If txtMonto.Text = "" Then
        Else
            txtMonto.Text = CDbl(txtMonto.Text)
        End If
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = False Then
            lblchkNulo.Text = 0
            HabilitarControles()
        Else
            lblchkNulo.Text = 1
            DeshabilitarControles()
        End If
    End Sub

    Private Sub DeshabilitarControles()
        GbMovimiento.Enabled = False
        txtCapital.Enabled = False
        txtInteres.Enabled = False
        txtNCF.Enabled = False
        dtpFecha.Enabled = False
        txtMonto.Enabled = False
        txtConcepto.Enabled = False
        chkNulo.Enabled = False
        txtReferencia.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        GbMovimiento.Enabled = True
        txtCapital.Enabled = True
        txtInteres.Enabled = True
        txtNCF.Enabled = True
        dtpFecha.Enabled = True
        txtMonto.Enabled = True
        txtConcepto.Enabled = True
        chkNulo.Enabled = True
        txtReferencia.Enabled = True
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDMovimientoBanc.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea imprimir el boucher del movimiento bancario?", "Imprimir Movimiento Bancario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
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

    Private Sub UltMovimientoBanc()
        Try

            If txtIDMovimientoBanc.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDMovimiento from MovimientosBanco where IDMovimiento= (Select Max(IDMovimiento) from MovimientosBanco)", Con)
                txtIDMovimientoBanc.Text = Convert.ToDouble(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " UltMovimientoBanc()")
        End Try
    End Sub

    Private Sub ConvertDouble()
        txtMonto.Text = CDbl(txtMonto.Text)
        txtCapital.Text = CDbl(txtCapital.Text)
        txtInteres.Text = CDbl(txtInteres.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
        txtCapital.Text = CDbl(txtCapital.Text).ToString("C")
        txtInteres.Text = CDbl(txtInteres.Text).ToString("C")
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs)
        ImprimirDocumento()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub BuscarCompraToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnDesactivar.PerformClick()
    End Sub

    Private Sub btnSubirDocumento_Click(sender As Object, e As EventArgs)
        frm_subir_documento.ShowDialog(Me)
    End Sub

    Private Sub SubirTransacciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubirTransacciónToolStripMenuItem.Click
        btnSubirArchivo.PerformClick()
    End Sub

    Private Sub txtCapital_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCapital.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtInteres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInteres.KeyPress
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


    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=45", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE movimientosbanco SET SecondID='" + lblSecondID.Text + "' WHERE IDMovimiento= (" + txtIDMovimientoBanc.Text + ")"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=45"
            GuardarDatos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If cbxTipoMovimiento.Text = "" Then
            MessageBox.Show("Seleccione el tipo de movimiento bancario.", "Seleccionar Movimiento Bancario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxTipoMovimiento.Focus()
            cbxTipoMovimiento.DroppedDown = True
            Exit Sub
        ElseIf cbxCuentaBancaria.Text = "" Then
            MessageBox.Show("Seleccione el No. de Cuenta de la transacción bancaria.", "Seleccionar Cuenta Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxCuentaBancaria.Focus()
            cbxCuentaBancaria.DroppedDown = True
            Exit Sub
        ElseIf txtMonto.Text = "" Or txtMonto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba el monto de la transacción bancaria.", "Escribir Monto de Transacción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        End If

        If txtIDMovimientoBanc.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el movimiento de " & cbxTipoMovimiento.Text & " en la cuenta No. " & cbxCuentaBancaria.Text & " en la base de datos?", "Guardar Nuevo Movimiento en Cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                GuardarArchivo()
                sqlQ = "INSERT INTO Movimientosbanco (IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Hora,IDCuentaBancaria,IDTipoMovimientoBanc,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,MontoLetras,NCF,Concepto,RutaDocumento,Nulo) VALUES ('45','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDCuentaBancaria.Text + "','" + lblIDTipoMovimiento.Text + "','" + txtReferencia.Text + "','" + dtpFecha.Value.ToString("yyyy-MM-dd") + "','','" + txtMonto.Text + "','" + txtCapital.Text + "','" + txtInteres.Text + "','" + txtMonto.Text + "','" + lblSumaLetra.Text + "','','" + txtConcepto.Text + "','" + Replace(lblRutaDocumento.Text, "\", "\\") + "','" + lblchkNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltMovimientoBanc()
                SetSecondID()
                CalcularBceCuentaBancaria(lblIDCuentaBancaria.Text)
                MessageBox.Show("Registro guardado satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DeshabilitarControles()
                ControlSuperClave = 1
                If Me.Owner.Name = frm_pago_compras.Name Then
                    frm_pago_compras.lblTransferenciaBanco.Text = txtBanco.Text
                    frm_pago_compras.lblTransferenciaCuenta.Text = cbxCuentaBancaria.Text
                    frm_pago_compras.lblTransferenciaReferencia.Text = txtReferencia.Text
                    Me.Close()
                End If
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Si el ID no esta vacío, actualizo los datos.
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el movimiento bancario?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                GuardarArchivo()
                ConvertDouble()
                sqlQ = "UPDATE MovimientosBanco SET IDCuentaBancaria='" + lblIDCuentaBancaria.Text + "',IDTipoMovimientoBanc='" + lblIDTipoMovimiento.Text + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',NoTransaccion='" + txtReferencia.Text + "',FechaMovimiento='" + dtpFecha.Value.ToString("yyyy-MM-dd") + "',Monto='" + txtMonto.Text + "',Capital='" + txtCapital.Text + "',Interes='" + txtInteres.Text + "',Total='" + txtMonto.Text + "',NCF='" + txtNCF.Text + "',Concepto='" + txtConcepto.Text + "',RutaDocumento='" + lblRutaDocumento.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDMovimiento= (" + txtIDMovimientoBanc.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcularBceCuentaBancaria(lblIDCuentaBancaria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                ControlSuperClave = 1
                If Me.Owner.Name = frm_pago_compras.Name Then
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub GuardarArchivo()
        Try
            'Verifico si existe la carpeta del cliente
            Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Bancos\Movimientos")
            If Exists = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Bancos\Movimientos")
            End If

            'Verifico si existen los archivos en ruta
            If lblRutaDocumento.Text <> "" Then
                Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Bancos\Movimientos\" & txtIDMovimientoBanc.Text & ".png"
                If RutaDestino <> lblRutaDocumento.Text Then
                    If System.IO.File.Exists(RutaDestino) Then
                        My.Computer.FileSystem.RenameFile(RutaDestino, txtIDMovimientoBanc.Text & "-OLD" & Today.ToString("yyyyMMdd") & TimeOfDay.ToString("HHmmss"))
                        My.Computer.FileSystem.MoveFile(lblRutaDocumento.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                    Else
                        My.Computer.FileSystem.MoveFile(lblRutaDocumento.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                    End If

                    lblRutaDocumento.Text = RutaDestino
                End If
            End If


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If cbxTipoMovimiento.Text = "" Then
            MessageBox.Show("Seleccione el tipo de movimiento bancario.", "Seleccionar Movimiento Bancario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxTipoMovimiento.Focus()
            cbxTipoMovimiento.DroppedDown = True
            Exit Sub
        ElseIf cbxCuentaBancaria.Text = "" Then
            MessageBox.Show("Seleccione el No. de Cuenta de la transacción bancaria.", "Seleccionar Cuenta Bancaria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxCuentaBancaria.Focus()
            cbxCuentaBancaria.DroppedDown = True
            Exit Sub
        ElseIf txtMonto.Text = "" Or txtMonto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba el monto de la transacción bancaria.", "Escribir Monto de Transacción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        End If

        If txtIDMovimientoBanc.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el movimiento de " & cbxTipoMovimiento.Text & " en la cuenta No. " & cbxCuentaBancaria.Text & " en la base de datos?", "Guardar Nuevo Movimiento en Cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                GuardarArchivo()
                sqlQ = "INSERT INTO Movimientosbanco (IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Hora,IDCuentaBancaria,IDTipoMovimientoBanc,NoTransaccion,FechaMovimiento,Beneficiario,Monto,Capital,Interes,Total,MontoLetras,NCF,Concepto,RutaDocumento,Nulo) VALUES ('45','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDCuentaBancaria.Text + "','" + lblIDTipoMovimiento.Text + "','" + txtReferencia.Text + "','" + dtpFecha.Value.ToString("yyyy-MM-dd") + "','','" + txtMonto.Text + "','" + txtCapital.Text + "','" + txtInteres.Text + "','" + txtMonto.Text + "','" + lblSumaLetra.Text + "','','" + txtConcepto.Text + "','" + Replace(lblRutaDocumento.Text, "\", "\\") + "','" + lblchkNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltMovimientoBanc()
                SetSecondID()
                CalcularBceCuentaBancaria(lblIDCuentaBancaria.Text)
                MessageBox.Show("Registro guardado satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
                 ControlSuperClave = 1
                If Me.Owner.Name = frm_pago_compras.Name Then
                    frm_pago_compras.lblTransferenciaBanco.Text = txtBanco.Text
                    frm_pago_compras.lblTransferenciaCuenta.Text = cbxCuentaBancaria.Text
                    frm_pago_compras.lblTransferenciaReferencia.Text = txtReferencia.Text
                    Me.Close()
                End If
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            'Si el ID no esta vacío, actualizo los datos.
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el movimiento bancario?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                GuardarArchivo()
                ConvertDouble()
                sqlQ = "UPDATE MovimientosBanco SET IDCuentaBancaria='" + lblIDCuentaBancaria.Text + "',IDTipoMovimientoBanc='" + lblIDTipoMovimiento.Text + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',NoTransaccion='" + txtReferencia.Text + "',FechaMovimiento='" + dtpFecha.Value.ToString("yyyy-MM-dd") + "',Monto='" + txtMonto.Text + "',Capital='" + txtCapital.Text + "',Interes='" + txtInteres.Text + "',Total='" + txtMonto.Text + "',NCF='" + txtNCF.Text + "',Concepto='" + txtConcepto.Text + "',RutaDocumento='" + lblRutaDocumento.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDMovimiento= (" + txtIDMovimientoBanc.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcularBceCuentaBancaria(lblIDCuentaBancaria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El movimiento No. " & txtIDMovimientoBanc.Text & " del tipo " & cbxTipoMovimiento.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Mov. Bancario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 79
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE MovimientosBanco SET IDCuentaBancaria='" + lblIDCuentaBancaria.Text + "',IDTipoMovimientoBanc='" + lblIDTipoMovimiento.Text + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',NoTransaccion='" + txtReferencia.Text + "',FechaMovimiento='" + dtpFecha.Value.ToString("yyyy-MM-dd") + "',Monto='" + txtMonto.Text + "',Capital='" + txtCapital.Text + "',Interes='" + txtInteres.Text + "',Total='" + txtMonto.Text + "',NCF='" + txtNCF.Text + "',Concepto='" + txtConcepto.Text + "',RutaDocumento='" + lblRutaDocumento.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDMovimiento= (" + txtIDMovimientoBanc.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcularBceCuentaBancaria(lblIDCuentaBancaria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDMovimientoBanc.Text = "" Then
            MessageBox.Show("No hay un registro de movimiento bancario abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el movimiento bancario No. " & txtIDMovimientoBanc.Text & " del tipo " & cbxTipoMovimiento.Text & " del sistema?", "Anular Mov. Bancario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 80
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE MovimientosBanco SET IDCuentaBancaria='" + lblIDCuentaBancaria.Text + "',IDTipoMovimientoBanc='" + lblIDTipoMovimiento.Text + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',NoTransaccion='" + txtReferencia.Text + "',FechaMovimiento='" + dtpFecha.Value.ToString("yyyy-MM-dd") + "',Monto='" + txtMonto.Text + "',Capital='" + txtCapital.Text + "',Interes='" + txtInteres.Text + "',Total='" + txtMonto.Text + "',NCF='" + txtNCF.Text + "',Concepto='" + txtConcepto.Text + "',RutaDocumento='" + lblRutaDocumento.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDMovimiento= (" + txtIDMovimientoBanc.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcularBceCuentaBancaria(lblIDCuentaBancaria.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub txtCapital_Leave(sender As Object, e As EventArgs) Handles txtCapital.Leave
        If txtCapital.Text = "" Then
            txtCapital.Text = CDbl(0).ToString("C")
        Else
            txtCapital.Text = CDbl(txtCapital.Text).ToString("C")
        End If
    End Sub

    Private Sub txtInteres_Leave(sender As Object, e As EventArgs) Handles txtInteres.Leave
        If txtInteres.Text = "" Then
            txtInteres.Text = CDbl(0).ToString("C")
        Else
            txtInteres.Text = CDbl(txtInteres.Text).ToString("C")
        End If
    End Sub

    Private Sub txtCapital_Enter(sender As Object, e As EventArgs) Handles txtCapital.Enter
        If txtCapital.Text = "" Then
        Else
            txtCapital.Text = CDbl(txtCapital.Text)
        End If
    End Sub

    Private Sub txtInteres_Enter(sender As Object, e As EventArgs) Handles txtInteres.Enter
        If txtInteres.Text = "" Then
        Else
            txtInteres.Text = CDbl(txtInteres.Text)
        End If
    End Sub

    Private Sub btnSubirArchivo_Click(sender As Object, e As EventArgs) Handles btnSubirArchivo.Click
        If TypeConnection.Text = 1 Then
            If frm_subir_documento.Visible = True Then
                frm_subir_documento.Close()
            End If

            frm_subir_documento.Show(Me)
            frm_subir_documento.PicDocumento.Width = 539
            frm_subir_documento.PicDocumento.Height = 607
            frm_subir_documento.PicDocumento.Location = New Point(0, 0)

            frm_subir_documento.RutaDocumento.Text = lblRutaDocumento.Text

            If lblRutaDocumento.Text <> "" Then
                If System.IO.File.Exists(lblRutaDocumento.Text) = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(lblRutaDocumento.Text, FileMode.Open, FileAccess.Read)
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

    Private Sub BuscarToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_mov_bancarios.ShowDialog(Me)
    End Sub

    Private Sub btnImprimir_Click_1(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

End Class