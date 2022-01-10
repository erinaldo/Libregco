Imports MySql.Data.MySqlClient
Imports MySql.Data.dll
Imports System.Windows.Forms
Imports System.IO
Public Class frm_acuerdos_pago
    '
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDUsuario, lblNulo, lblStatus As New Label
    Dim lblIDGeneroDeudor, lblIDGeneroAcreedor, lblIDGeneroNotario, lblIDTipoIdentificacionDeudor, lblIDTipoIdentificacionAcreedor, lblIDTipoIndetificacionNotario, lblIDTipoIdentificacionTestigo1, lblIDTipoIdentificacionTestigo2 As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_acuerdos_pago_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
        SelectUsuario()
    End Sub

    Private Sub CargarEmpresa()
        Try
            PicBoxLogo.Image = ConseguirLogoEmpresa()
           
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtBalanceGral.Clear()
        txtUltimoPago.Clear()
        txtSecondID.Clear()
        txtCalificacion.Clear()
        txtIDAcuerdo.Clear()
        txtFecha.Clear()
        txtHora.Clear()

        cbxGeneroDeudor.Items.Clear()
        txtTratamientoDeudor.Clear()
        txtDeudor.Clear()
        txtDomicilioDeudor.Clear()
        cbxIdentificacionDeudor.Items.Clear()
        txtIdentificacionDeudor.Clear()
        txtNacionalidadDeudor.Clear()
        txtEstadoCivilDeudor.Clear()
        txtOcupacionDeudor.Clear()
        txtMunicipioDeudor.Clear()
        txtProvinciaDeudor.Clear()

        cbxGeneroAcreedor.Items.Clear()
        txtTratamientoAcreedor.Clear()
        txtAcreedor.Clear()
        txtDomicilioAcreedor.Clear()
        cbxIdentificacionAcreedor.Items.Clear()
        txtIdentificacionAcreedor.Clear()
        txtNacionalidadAcreedor.Clear()
        txtEstadoCivilAcreedor.Clear()
        txtOcupacionAcreedor.Clear()
        txtMunicipioAcreedor.Clear()
        txtProvinciaAcreedor.Clear()

        txtCiudadAcuerdo.Clear()
        txtNotario.Clear()
        txtNoRegistroNotario.Clear()
        txtDomicilioNotario.Clear()
        cbxTipoIdentNotario.Items.Clear()
        txtIdentificacionNotario.Clear()
        txtNacionalidadNotario.Clear()
        txtMunicipioAcuerdo.Clear()
        txtProvinciaAcuerdo.Clear()
        txtDeuda.Clear()
        txtCantidadCuotas.Clear()
        txtMontoCuotas.Clear()
        txtInteres.Clear()

        txtTestigo1.Clear()
        txtIdentificacionTestigo1.Clear()
        txtIdentificacionTestigo1.Mask = ""
        txtDomicilioTestigo1.Clear()
        txtNacionalidadTestigo1.Clear()
        txtTestigo2.Clear()
        txtIdentificacionTestigo2.Clear()
        txtIdentificacionTestigo2.Mask = ""
        txtDomicilioTestigo2.Clear()
        txtNacionalidadTestigo2.Clear()
        txtNotaAcuerdo.Clear()

        RichTextAcuerdo.Clear()
    End Sub

    Private Sub ActualizarTodo()
        DtpFecha.Value = Today
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        FillGenero()
        FillTipoIdentificacion()
        dtpVencimiento.Value = Today
        ChkNulo.Checked = False
        lblNulo.Text = 0
        lblStatus.Text = 0
        btnBuscarCliente.Focus()
        txtDeuda.Text = CDbl(0).ToString("C")
        txtCantidadCuotas.Text = 1
        txtDiasPago.Value = Today.ToString("dd")
        txtMontoCuotas.Text = CDbl(0).ToString("C")
        chkAcuerdoSimplificado.Checked = True
        txtIdentificacionDeudor.Mask = ""
        txtIdentificacionAcreedor.Mask = ""
        txtIdentificacionNotario.Mask = ""
        HabilitarControles()
    End Sub

    Private Sub FillGenero()
        Try

            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Genero FROM Genero ORDER BY Genero ", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Genero")
            cbxGeneroAcreedor.Items.Clear()
            cbxGeneroDeudor.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Genero")
            For Each Fila As DataRow In Tabla.Rows
                cbxGeneroDeudor.Items.Add(Fila.Item("Genero"))
                cbxGeneroAcreedor.Items.Add(Fila.Item("Genero"))
                cbxGeneroNotario.Items.Add(Fila.Item("Genero"))
            Next

            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron géneros hábiles en la base de datos. Inserte géneros hábiles para procesar los registros de los clientes.", "No se encontraron géneros", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillTipoIdentificacion()

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM TipoIdentificacion ORDER BY Descripcion", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoIdentificacion")
        cbxIdentificacionAcreedor.Items.Clear()
        cbxIdentificacionDeudor.Items.Clear()
        cbxIdentificacionTestigo1.Items.Clear()
        cbxIdentificacionTestigo2.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoIdentificacion")
        For Each Fila As DataRow In Tabla.Rows
            cbxIdentificacionAcreedor.Items.Add(Fila.Item("Descripcion"))
            cbxIdentificacionDeudor.Items.Add(Fila.Item("Descripcion"))
            cbxIdentificacionTestigo1.Items.Add(Fila.Item("Descripcion"))
            cbxIdentificacionTestigo2.Items.Add(Fila.Item("Descripcion"))
            cbxTipoIdentNotario.Items.Add(Fila.Item("Descripcion"))
        Next

        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron tipos de indentifiación hábiles en la base de datos. Inserte tipos de identificación hábiles para procesar los registros de los clientes.", "No se encontraron municipios", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If
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

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = False Then
            lblNulo.Text = 0
            HabilitarControles()
        Else
            lblNulo.Text = 1
            DeshabilitarControles()
        End If
    End Sub

    Private Sub UltAcuerdoPago()
        Try
            If txtIDAcuerdo.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDAcuerdoPago from AcuerdosPago where IDAcuerdoPago= (Select Max(IDAcuerdoPago) from AcuerdosPago)", Con)
                txtIDAcuerdo.Text = Convert.ToString(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select SecondID from AcuerdosPago where IDAcuerdoPago= (Select Max(IDAcuerdoPago) from AcuerdosPago)", Con)
                txtSecondID.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub ConvertDouble()
        txtDeuda.Text = CDbl(txtDeuda.Text)
        txtMontoCuotas.Text = CDbl(txtMontoCuotas.Text)
        txtInteres.Text = CDbl(Replace(txtInteres.Text, "%", "")) / 100
    End Sub

    Private Sub ConvertCurrent()
        txtDeuda.Text = CDbl(txtDeuda.Text).ToString("C")
        txtMontoCuotas.Text = CDbl(txtMontoCuotas.Text).ToString("C")
        txtInteres.Text = CDbl(txtInteres.Text).ToString("P2")
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

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDAcuerdo.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el acuerdo de pago?", "Imprimir Acuerdo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If

    End Sub

    Private Sub HabilitarControles()
        btnBuscarCliente.Enabled = True
        DtpFecha.Enabled = True
        txtDeuda.Enabled = True
        txtNotaAcuerdo.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        btnBuscarCliente.Enabled = False
        DtpFecha.Enabled = False
        txtDeuda.Enabled = False
        txtNotaAcuerdo.Enabled = False
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDeuda.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtMonto_Enter(sender As Object, e As EventArgs) Handles txtDeuda.Enter
        If txtDeuda.Text = "" Then
        Else
            txtDeuda.Text = CDbl(txtDeuda.Text)
        End If

    End Sub

    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtDeuda.Leave
        If txtDeuda.Text = "" Then
            txtDeuda.Text = CDbl(0).ToString("C")
        Else
            txtDeuda.Text = CDbl(txtDeuda.Text).ToString("C")
        End If

        If IsNumeric(CDbl(txtDeuda.Text)) Then
            txtMontoCuotas.Text = (CDbl(txtDeuda.Text) / CDbl(txtCantidadCuotas.Text)).ToString("C")
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Close()
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub rdbAbierto_CheckedChanged(sender As Object, e As EventArgs) Handles rdbAbierto.CheckedChanged
        VerificarStatus()
    End Sub

    Private Sub VerificarStatus()
        If rdbAbierto.Checked = True Then
            lblStatus.Text = 0
        Else
            lblStatus.Text = 1
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para realizar el acuerdo de pago.", "Seleccione el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.Focus()
            Exit Sub
        ElseIf CDbl(txtBalanceGral.Text) = 0 Then
            MessageBox.Show("El cliente específicado para el acuerdo de pago no tiene balance pendiente.", "No tiene balance", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtDeuda.Text = "" Or txtDeuda.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Especifique el monto del acuerdo de pago.", "Escriba el monto del acuerdo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDeuda.Focus()
            Exit Sub
        ElseIf txtNotaAcuerdo.Text = "" Then
            MessageBox.Show("Escriba una breve nota de las condiciones y descripción del acuerdo de pago.", "Especifique condiciones", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNotaAcuerdo.Focus()
            Exit Sub
        ElseIf cbxGeneroDeudor.Text = "" Then
            MessageBox.Show("Defina el género del deudor para continuar.", "Definir género", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxGeneroDeudor.Focus()
            cbxGeneroDeudor.DroppedDown = True
            Exit Sub
        ElseIf cbxGeneroAcreedor.Text = "" Then
            MessageBox.Show("Defina el género del acreedor para continuar.", "Definir género", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxGeneroAcreedor.Focus()
            cbxGeneroAcreedor.DroppedDown = True
            Exit Sub
        ElseIf cbxGeneroNotario.Text = "" Then
            MessageBox.Show("Defina el género del notario para continuar.", "Definir género", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxGeneroNotario.Focus()
            cbxGeneroNotario.DroppedDown = True
            Exit Sub
        ElseIf cbxIdentificacionDeudor.Text = "" Then
            MessageBox.Show("Defina el tipo de identificación del deudor para continuar.", "Definir identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxIdentificacionDeudor.Focus()
            cbxIdentificacionDeudor.DroppedDown = True
            Exit Sub
        ElseIf cbxIdentificacionAcreedor.Text = "" Then
            MessageBox.Show("Defina el tipo de identificación del acreedor para continuar.", "Definir identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxIdentificacionAcreedor.Focus()
            cbxIdentificacionAcreedor.DroppedDown = True
            Exit Sub
        ElseIf cbxTipoIdentNotario.Text = "" Then
            MessageBox.Show("Defina el tipo de identificación del notario para continuar.", "Definir identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxTipoIdentNotario.Focus()
            cbxTipoIdentNotario.DroppedDown = True
            Exit Sub
        ElseIf cbxIdentificacionTestigo1.Text = "" Then
            MessageBox.Show("Defina el tipo de identificación del testigo No.1 para continuar.", "Definir identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxIdentificacionTestigo1.Focus()
            cbxIdentificacionTestigo1.DroppedDown = True
            Exit Sub
        ElseIf cbxIdentificacionTestigo2.Text = "" Then
            MessageBox.Show("Defina el tipo de identificación del testigo No.2 para continuar.", "Definir identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxIdentificacionTestigo2.Focus()
            cbxIdentificacionTestigo2.DroppedDown = True
            Exit Sub
        End If

        If txtIDAcuerdo.Text = "" Then 'Si no hay acuerdo
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo acuerdo del cliente cód. [" & txtIDCliente.Text & "] " & " " & txtNombre.Text & " en la base de datos?", "Guardar Nuevo Acuerdo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                MessageBox.Show("INSERT INTO AcuerdosPago (IDTipoDocumento,IDUsuario,IDSucursal,IDAlmacen,Fecha,Hora,IDCliente,IDGeneroDeudor,TratamientoDeudor,Deudor,DomicilioDeudor,IDIdentificacionDeudor,IdentificacionDeudor,NacionalidadDeudor,EstadoCivilDeudor,ProfesionDeudor,MunicipioDeudor,ProvinciaDeudor,IDGeneroAcreedor,TratamientoAcreedor,Acreedor,DomicilioAcreedor,IDTipoIdentificacionAcreedor,IdentificacionAcreedor,NacionalidadAcreedor,EstadoCivilAcreedor,ProfesionAcreedor,MunicipioAcreedor,ProvinciaAcreedor,Fechapago,Vencimiento,CiudadAcuerdo,IDGeneroNotario,Notario,NoRegistroNotario,DomicilioNotario,IDTipoIdentificacionNotario,IdentificacionNotario,NacionalidadNotario,MunicipioNotario,ProvinciaNotario,Monto,SumaLetraMonto,CantidadCuotas,MontoCuotas,SumaLetraCuotas,DiasPago,Interes,Testigo1,IDTipoIdentificacionTestigo1,IdentificacionTestigo1,DomicilioTestigo1,NacionalidadTestigo1,Testigo2,IDTipoIdentificacionTestigo2,IdentificacionTestigo2,DomicilioTestigo2,NacionalidadTestigo2,Nota,Status,Impreso,Nulo) VALUES (28,'" + lblIDUsuario.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDCliente.Text + "','" + lblIDGeneroDeudor.Text + "','" + txtTratamientoDeudor.Text + "','" + txtDeudor.Text + "','" + txtDomicilioDeudor.Text + "','" + lblIDTipoIdentificacionDeudor.Text + "','" + txtIdentificacionDeudor.Text + "','" + txtNacionalidadDeudor.Text + "','" + txtEstadoCivilDeudor.Text + "','" + txtOcupacionDeudor.Text + "','" + txtMunicipioDeudor.Text + "','" + txtProvinciaDeudor.Text + "','" + lblIDGeneroAcreedor.Text + "','" + txtTratamientoAcreedor.Text + "','" + txtAcreedor.Text + "','" + txtDomicilioAcreedor.Text + "','" + lblIDTipoIdentificacionAcreedor.Text + "','" + txtIdentificacionAcreedor.Text + "','" + txtNacionalidadAcreedor.Text + "','" + txtEstadoCivilAcreedor.Text + "','" + txtOcupacionAcreedor.Text + "','" + txtMunicipioAcreedor.Text + "','" + txtProvinciaAcreedor.Text + "','" + DtpFecha.Text + "','" + dtpVencimiento.Text + "','" + txtCiudadAcuerdo.Text + "','" + lblIDGeneroNotario.Text + "','" + txtNotario.Text + "','" + txtNoRegistroNotario.Text + "','" + txtDomicilioNotario.Text + "','" + lblIDTipoIndetificacionNotario.Text + "','" + txtIdentificacionNotario.Text + "','" + txtNacionalidadNotario.Text + "','" + txtMunicipioAcuerdo.Text + "','" + txtProvinciaAcuerdo.Text + "','" + txtDeuda.Text + "','" + lblSumaLetraMonto.Text + "','" + txtCantidadCuotas.Text + "','" + txtMontoCuotas.Text + "','" + lblSumaLetraCuotas.Text + "','" + txtDiasPago.Value + "','" + txtInteres.Text + "','" + txtTestigo1.Text + "','" + lblIDTipoIdentificacionTestigo1.Text + "','" + txtIdentificacionTestigo1.Text + "','" + txtDomicilioTestigo1.Text + "','" + txtNacionalidadTestigo1.Text + "','" + txtTestigo2.Text + "','" + lblIDTipoIdentificacionTestigo2.Text + "','" + txtIdentificacionTestigo2.Text + "','" + txtDomicilioTestigo2.Text + "','" + txtNacionalidadTestigo2.Text + "','" + txtNotaAcuerdo.Text + "','" + lblStatus.Text + "',0,'" + lblNulo.Text + "')")
                sqlQ = "INSERT INTO AcuerdosPago (IDTipoDocumento,IDUsuario,IDSucursal,IDAlmacen,Fecha,Hora,IDCliente,IDGeneroDeudor,TratamientoDeudor,Deudor,DomicilioDeudor,IDIdentificacionDeudor,IdentificacionDeudor,NacionalidadDeudor,EstadoCivilDeudor,ProfesionDeudor,MunicipioDeudor,ProvinciaDeudor,IDGeneroAcreedor,TratamientoAcreedor,Acreedor,DomicilioAcreedor,IDTipoIdentificacionAcreedor,IdentificacionAcreedor,NacionalidadAcreedor,EstadoCivilAcreedor,ProfesionAcreedor,MunicipioAcreedor,ProvinciaAcreedor,Fechapago,Vencimiento,CiudadAcuerdo,IDGeneroNotario,Notario,NoRegistroNotario,DomicilioNotario,IDTipoIdentificacionNotario,IdentificacionNotario,NacionalidadNotario,MunicipioNotario,ProvinciaNotario,Monto,SumaLetraMonto,CantidadCuotas,MontoCuotas,SumaLetraCuotas,DiasPago,Interes,Testigo1,IDTipoIdentificacionTestigo1,IdentificacionTestigo1,DomicilioTestigo1,NacionalidadTestigo1,Testigo2,IDTipoIdentificacionTestigo2,IdentificacionTestigo2,DomicilioTestigo2,NacionalidadTestigo2,Nota,Status,Impreso,Nulo) 
                                                    VALUES (28,'" + lblIDUsuario.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDCliente.Text + "','" + lblIDGeneroDeudor.Text + "','" + txtTratamientoDeudor.Text + "','" + txtDeudor.Text + "','" + txtDomicilioDeudor.Text + "','" + lblIDTipoIdentificacionDeudor.Text + "','" + txtIdentificacionDeudor.Text + "','" + txtNacionalidadDeudor.Text + "','" + txtEstadoCivilDeudor.Text + "','" + txtOcupacionDeudor.Text + "','" + txtMunicipioDeudor.Text + "','" + txtProvinciaDeudor.Text + "','" + lblIDGeneroAcreedor.Text + "','" + txtTratamientoAcreedor.Text + "','" + txtAcreedor.Text + "','" + txtDomicilioAcreedor.Text + "','" + lblIDTipoIdentificacionAcreedor.Text + "','" + txtIdentificacionAcreedor.Text + "','" + txtNacionalidadAcreedor.Text + "','" + txtEstadoCivilAcreedor.Text + "','" + txtOcupacionAcreedor.Text + "','" + txtMunicipioAcreedor.Text + "','" + txtProvinciaAcreedor.Text + "','" + DtpFecha.Text + "','" + dtpVencimiento.Text + "','" + txtCiudadAcuerdo.Text + "','" + lblIDGeneroNotario.Text + "','" + txtNotario.Text + "','" + txtNoRegistroNotario.Text + "','" + txtDomicilioNotario.Text + "','" + lblIDTipoIndetificacionNotario.Text + "','" + txtIdentificacionNotario.Text + "','" + txtNacionalidadNotario.Text + "','" + txtMunicipioAcuerdo.Text + "','" + txtProvinciaAcuerdo.Text + "','" + txtDeuda.Text + "','" + lblSumaLetraMonto.Text + "','" + txtCantidadCuotas.Text + "','" + txtMontoCuotas.Text + "','" + lblSumaLetraCuotas.Text + "','" + txtDiasPago.Value + "','" + txtInteres.Text + "','" + txtTestigo1.Text + "','" + lblIDTipoIdentificacionTestigo1.Text + "','" + txtIdentificacionTestigo1.Text + "','" + txtDomicilioTestigo1.Text + "','" + txtNacionalidadTestigo1.Text + "','" + txtTestigo2.Text + "','" + lblIDTipoIdentificacionTestigo2.Text + "','" + txtIdentificacionTestigo2.Text + "','" + txtDomicilioTestigo2.Text + "','" + txtNacionalidadTestigo2.Text + "','" + txtNotaAcuerdo.Text + "','" + lblStatus.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                UltAcuerdoPago()
                SetSecondID()
                ConvertCurrent()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DeshabilitarControles()

            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el acuerdo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE AcuerdosPago SET IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCliente='" + txtIDCliente.Text + "',IDGeneroDeudor='" + lblIDGeneroDeudor.Text + "',TratamientoDeudor='" + txtTratamientoDeudor.Text + "',Deudor='" + txtDeudor.Text + "',DomicilioDeudor='" + txtDomicilioDeudor.Text + "',IDIdentificacionDeudor='" + lblIDTipoIdentificacionDeudor.Text + "',Identificaciondeudor='" + txtIdentificacionDeudor.Text + "',NacionalidadDeudor='" + txtNacionalidadDeudor.Text + "',EstadoCivilDeudor='" + txtEstadoCivilDeudor.Text + "',ProfesionDeudor='" + txtOcupacionDeudor.Text + "',MunicipioDeudor='" + txtMunicipioDeudor.Text + "',ProvinciaDeudor='" + txtProvinciaDeudor.Text + "',IDGeneroAcreedor='" + lblIDGeneroAcreedor.Text + "',TratamientoAcreedor='" + txtTratamientoAcreedor.Text + "',Acreedor='" + txtAcreedor.Text + "',DomicilioAcreedor='" + txtDomicilioAcreedor.Text + "',IDTipoIdentificacionAcreedor='" + lblIDTipoIdentificacionAcreedor.Text + "',NacionalidadAcreedor='" + txtNacionalidadAcreedor.Text + "',EstadoCivilAcreedor='" + txtEstadoCivilAcreedor.Text + "',ProfesionAcreedor='" + txtOcupacionAcreedor.Text + "',MunicipioAcreedor='" + txtMunicipioAcreedor.Text + "',ProvinciaAcreedor='" + txtProvinciaAcreedor.Text + "',FechaPago='" + CDate(DtpFecha.Value).ToString("yyyy-MM-dd") + "',Vencimiento='" + CDate(dtpVencimiento.Value).ToString("yyyy-MM-dd") + "',CiudadAcuerdo='" + txtCiudadAcuerdo.Text + "',IDGeneroNotario='" + lblIDGeneroNotario.Text + "',Notario='" + txtNotario.Text + "',NoRegistroNotario='" + txtNoRegistroNotario.Text + "',DomicilioNotario='" + txtDomicilioNotario.Text + "',IDTipoIdentificacionNotario='" + lblIDTipoIndetificacionNotario.Text + "',IdentificacionNotario='" + txtIdentificacionNotario.Text + "',NacionalidadNotario='" + txtNacionalidadNotario.Text + "',MunicipioNotario='" + txtMunicipioAcuerdo.Text + "',ProvinciaNotario='" + txtProvinciaAcuerdo.Text + "',Monto='" + txtDeuda.Text + "',CantidadCuotas='" + txtCantidadCuotas.Text + "',MontoCuotas='" + txtMontoCuotas.Text + "',DiasPago='" + txtDiasPago.Text + "',Interes='" + txtInteres.Text + "',Testigo1='" + txtTestigo1.Text + "',IdentificacionTestigo1='" + txtIdentificacionTestigo1.Text + "',DomicilioTestigo1='" + txtDomicilioTestigo1.Text + "',NacionalidadTestigo1='" + txtNacionalidadTestigo1.Text + "',Testigo2='" + txtTestigo2.Text + "',IDTipoIdentificacionTestigo1='" + lblIDTipoIdentificacionTestigo1.Text + "',IDTipoIdentificacionTestigo2='" + lblIDTipoIdentificacionTestigo2.Text + "',IdentificacionTestigo2='" + txtIdentificacionTestigo2.Text + "',DomicilioTestigo2='" + txtDomicilioTestigo2.Text + "',NacionalidadTestigo2='" + txtNacionalidadTestigo2.Text + "',Nota='" + txtNotaAcuerdo.Text + "',Status='" + lblStatus.Text + "',Nulo='" + lblNulo.Text + "',SumaLetraMonto='" + lblSumaLetraMonto.Text + "',SumaLetraCuotas='" + lblSumaLetraCuotas.Text + "' WHERE IDAcuerdoPago= (" + txtIDAcuerdo.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DeshabilitarControles()
            End If
        End If
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=28", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE AcuerdosPago SET SecondID='" + lblSecondID.Text + "' WHERE IDAcuerdoPago='" + txtIDAcuerdo.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=28"
            GuardarDatos()

        Catch ex As Exception

            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para realizar el acuerdo de pago.", "Seleccione el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.Focus()
            Exit Sub
        ElseIf CDbl(txtBalanceGral.Text) = 0 Then
            MessageBox.Show("El cliente específicado para el acuerdo de pago no tiene balance pendiente.", "No tiene balance", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtDeuda.Text = "" Or txtDeuda.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Especifique el monto del acuerdo de pago.", "Escriba el monto del acuerdo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDeuda.Focus()
            Exit Sub
        ElseIf txtNotaAcuerdo.Text = "" Then
            MessageBox.Show("Escriba una breve nota de las condiciones y descripción del acuerdo de pago.", "Especifique condiciones", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNotaAcuerdo.Focus()
            Exit Sub
        ElseIf cbxGeneroDeudor.Text = "" Then
            MessageBox.Show("Defina el género del deudor para continuar.", "Definir género", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxGeneroDeudor.Focus()
            cbxGeneroDeudor.DroppedDown = True
            Exit Sub
        ElseIf cbxGeneroAcreedor.Text = "" Then
            MessageBox.Show("Defina el género del acreedor para continuar.", "Definir género", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxGeneroAcreedor.Focus()
            cbxGeneroAcreedor.DroppedDown = True
            Exit Sub
        ElseIf cbxGeneroNotario.Text = "" Then
            MessageBox.Show("Defina el género del notario para continuar.", "Definir género", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxGeneroNotario.Focus()
            cbxGeneroNotario.DroppedDown = True
            Exit Sub
        ElseIf cbxIdentificacionDeudor.Text = "" Then
            MessageBox.Show("Defina el tipo de identificación del deudor para continuar.", "Definir identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxIdentificacionDeudor.Focus()
            cbxIdentificacionDeudor.DroppedDown = True
            Exit Sub
        ElseIf cbxIdentificacionAcreedor.Text = "" Then
            MessageBox.Show("Defina el tipo de identificación del acreedor para continuar.", "Definir identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxIdentificacionAcreedor.Focus()
            cbxIdentificacionAcreedor.DroppedDown = True
            Exit Sub
        ElseIf cbxTipoIdentNotario.Text = "" Then
            MessageBox.Show("Defina el tipo de identificación del notario para continuar.", "Definir identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxTipoIdentNotario.Focus()
            cbxTipoIdentNotario.DroppedDown = True
            Exit Sub
        ElseIf cbxIdentificacionTestigo1.Text = "" Then
            MessageBox.Show("Defina el tipo de identificación del testigo No.1 para continuar.", "Definir identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxIdentificacionTestigo1.Focus()
            cbxIdentificacionTestigo1.DroppedDown = True
            Exit Sub
        ElseIf cbxIdentificacionTestigo2.Text = "" Then
            MessageBox.Show("Defina el tipo de identificación del testigo No.2 para continuar.", "Definir identificación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxIdentificacionTestigo2.Focus()
            cbxIdentificacionTestigo2.DroppedDown = True
            Exit Sub
        End If

        If txtIDAcuerdo.Text = "" Then 'Si no hay acuerdo
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo acuerdo del cliente cód. [" & txtIDCliente.Text & "] " & " " & txtNombre.Text & " en la base de datos?", "Guardar Nuevo Acuerdo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO AcuerdosPago (IDTipoDocumento,IDUsuario,IDSucursal,IDAlmacen,Fecha,Hora,IDCliente,IDGeneroDeudor,TratamientoDeudor,Deudor,DomicilioDeudor,IDIdentificacionDeudor,IdentificacionDeudor,NacionalidadDeudor,EstadoCivilDeudor,ProfesionDeudor,MunicipioDeudor,ProvinciaDeudor,IDGeneroAcreedor,TratamientoAcreedor,Acreedor,DomicilioAcreedor,IDTipoIdentificacionAcreedor,IdentificacionAcreedor,NacionalidadAcreedor,EstadoCivilAcreedor,ProfesionAcreedor,MunicipioAcreedor,ProvinciaAcreedor,Fechapago,Vencimiento,CiudadAcuerdo,IDGeneroNotario,Notario,NoRegistroNotario,DomicilioNotario,IDTipoIdentificacionNotario,IdentificacionNotario,NacionalidadNotario,MunicipioNotario,ProvinciaNotario,Monto,SumaLetraMonto,CantidadCuotas,MontoCuotas,SumaLetraCuotas,DiasPago,Interes,Testigo1,IDTipoIdentificacionTestigo1,IdentificacionTestigo1,DomicilioTestigo1,NacionalidadTestigo1,Testigo2,IDTipoIdentificacionTestigo2,IdentificacionTestigo2,DomicilioTestigo2,NacionalidadTestigo2,Nota,Status,Impreso,Nulo) VALUES (28,'" + lblIDUsuario.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDCliente.Text + "','" + lblIDGeneroDeudor.Text + "','" + txtTratamientoDeudor.Text + "','" + txtDeudor.Text + "','" + txtDomicilioDeudor.Text + "','" + lblIDTipoIdentificacionDeudor.Text + "','" + txtIdentificacionDeudor.Text + "','" + txtNacionalidadDeudor.Text + "','" + txtEstadoCivilDeudor.Text + "','" + txtOcupacionDeudor.Text + "','" + txtMunicipioDeudor.Text + "','" + txtProvinciaDeudor.Text + "','" + lblIDGeneroAcreedor.Text + "','" + txtTratamientoAcreedor.Text + "','" + txtAcreedor.Text + "','" + txtDomicilioAcreedor.Text + "','" + lblIDTipoIdentificacionAcreedor.Text + "','" + txtIdentificacionAcreedor.Text + "','" + txtNacionalidadAcreedor.Text + "','" + txtEstadoCivilAcreedor.Text + "','" + txtOcupacionAcreedor.Text + "','" + txtMunicipioAcreedor.Text + "','" + txtProvinciaAcreedor.Text + "','" + DtpFecha.Text + "','" + dtpVencimiento.Text + "','" + txtCiudadAcuerdo.Text + "','" + lblIDGeneroNotario.Text + "','" + txtNotario.Text + "','" + txtNoRegistroNotario.Text + "','" + txtDomicilioNotario.Text + "','" + lblIDTipoIndetificacionNotario.Text + "','" + txtIdentificacionNotario.Text + "','" + txtNacionalidadNotario.Text + "','" + txtMunicipioAcuerdo.Text + "','" + txtProvinciaAcuerdo.Text + "','" + txtDeuda.Text + "','" + lblSumaLetraMonto.Text + "','" + txtCantidadCuotas.Text + "','" + txtMontoCuotas.Text + "','" + lblSumaLetraCuotas.Text + "','" + txtDiasPago.Value + "','" + txtInteres.Text + "','" + txtTestigo1.Text + "','" + lblIDTipoIdentificacionTestigo1.Text + "','" + txtIdentificacionTestigo1.Text + "','" + txtDomicilioTestigo1.Text + "','" + txtNacionalidadTestigo1.Text + "','" + txtTestigo2.Text + "','" + lblIDTipoIdentificacionTestigo2.Text + "','" + txtIdentificacionTestigo2.Text + "','" + txtDomicilioTestigo2.Text + "','" + txtNacionalidadTestigo2.Text + "','" + txtNotaAcuerdo.Text + "','" + lblStatus.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                UltAcuerdoPago()
                SetSecondID()
                ConvertCurrent()
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
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el acuerdo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE AcuerdosPago SET IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCliente='" + txtIDCliente.Text + "',IDGeneroDeudor='" + lblIDGeneroDeudor.Text + "',TratamientoDeudor='" + txtTratamientoDeudor.Text + "',Deudor='" + txtDeudor.Text + "',DomicilioDeudor='" + txtDomicilioDeudor.Text + "',IDIdentificacionDeudor='" + lblIDTipoIdentificacionDeudor.Text + "',Identificaciondeudor='" + txtIdentificacionDeudor.Text + "',NacionalidadDeudor='" + txtNacionalidadDeudor.Text + "',EstadoCivilDeudor='" + txtEstadoCivilDeudor.Text + "',ProfesionDeudor='" + txtOcupacionDeudor.Text + "',MunicipioDeudor='" + txtMunicipioDeudor.Text + "',ProvinciaDeudor='" + txtProvinciaDeudor.Text + "',IDGeneroAcreedor='" + lblIDGeneroAcreedor.Text + "',TratamientoAcreedor='" + txtTratamientoAcreedor.Text + "',Acreedor='" + txtAcreedor.Text + "',DomicilioAcreedor='" + txtDomicilioAcreedor.Text + "',IDTipoIdentificacionAcreedor='" + lblIDTipoIdentificacionAcreedor.Text + "',NacionalidadAcreedor='" + txtNacionalidadAcreedor.Text + "',EstadoCivilAcreedor='" + txtEstadoCivilAcreedor.Text + "',ProfesionAcreedor='" + txtOcupacionAcreedor.Text + "',MunicipioAcreedor='" + txtMunicipioAcreedor.Text + "',ProvinciaAcreedor='" + txtProvinciaAcreedor.Text + "',FechaPago='" + CDate(DtpFecha.Value).ToString("yyyy-MM-dd") + "',Vencimiento='" + CDate(dtpVencimiento.Value).ToString("yyyy-MM-dd") + "',CiudadAcuerdo='" + txtCiudadAcuerdo.Text + "',IDGeneroNotario='" + lblIDGeneroNotario.Text + "',Notario='" + txtNotario.Text + "',NoRegistroNotario='" + txtNoRegistroNotario.Text + "',DomicilioNotario='" + txtDomicilioNotario.Text + "',IDTipoIdentificacionNotario='" + lblIDTipoIndetificacionNotario.Text + "',IdentificacionNotario='" + txtIdentificacionNotario.Text + "',NacionalidadNotario='" + txtNacionalidadNotario.Text + "',MunicipioNotario='" + txtMunicipioAcuerdo.Text + "',ProvinciaNotario='" + txtProvinciaAcuerdo.Text + "',Monto='" + txtDeuda.Text + "',CantidadCuotas='" + txtCantidadCuotas.Text + "',MontoCuotas='" + txtMontoCuotas.Text + "',DiasPago='" + txtDiasPago.Text + "',Interes='" + txtInteres.Text + "',Testigo1='" + txtTestigo1.Text + "',IdentificacionTestigo1='" + txtIdentificacionTestigo1.Text + "',DomicilioTestigo1='" + txtDomicilioTestigo1.Text + "',NacionalidadTestigo1='" + txtNacionalidadTestigo1.Text + "',Testigo2='" + txtTestigo2.Text + "',IDTipoIdentificacionTestigo1='" + lblIDTipoIdentificacionTestigo1.Text + "',IDTipoIdentificacionTestigo2='" + lblIDTipoIdentificacionTestigo2.Text + "',IdentificacionTestigo2='" + txtIdentificacionTestigo2.Text + "',DomicilioTestigo2='" + txtDomicilioTestigo2.Text + "',NacionalidadTestigo2='" + txtNacionalidadTestigo2.Text + "',Nota='" + txtNotaAcuerdo.Text + "',Status='" + lblStatus.Text + "',Nulo='" + lblNulo.Text + "',SumaLetraMonto='" + lblSumaLetraMonto.Text + "',SumaLetraCuotas='" + lblSumaLetraCuotas.Text + "' WHERE IDAcuerdoPago= (" + txtIDAcuerdo.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_acuerdos_pagos.ShowDialog(Me)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El acuerdo de pago No. " & txtIDAcuerdo.Text & "  ya está desactivada del sistema. Desea volver a activarlo?", "Activar Acuerdo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then

                ChkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE AcuerdosPago SET IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCliente='" + txtIDCliente.Text + "',IDGeneroDeudor='" + lblIDGeneroDeudor.Text + "',TratamientoDeudor='" + txtTratamientoDeudor.Text + "',Deudor='" + txtDeudor.Text + "',DomicilioDeudor='" + txtDomicilioDeudor.Text + "',IDIdentificacionDeudor='" + lblIDTipoIdentificacionDeudor.Text + "',Identificaciondeudor='" + txtIdentificacionDeudor.Text + "',NacionalidadDeudor='" + txtNacionalidadDeudor.Text + "',EstadoCivilDeudor='" + txtEstadoCivilDeudor.Text + "',ProfesionDeudor='" + txtOcupacionDeudor.Text + "',MunicipioDeudor='" + txtMunicipioDeudor.Text + "',ProvinciaDeudor='" + txtProvinciaDeudor.Text + "',IDGeneroAcreedor='" + lblIDGeneroAcreedor.Text + "',TratamientoAcreedor='" + txtTratamientoAcreedor.Text + "',Acreedor='" + txtAcreedor.Text + "',DomicilioAcreedor='" + txtDomicilioAcreedor.Text + "',IDTipoIdentificacionAcreedor='" + lblIDTipoIdentificacionAcreedor.Text + "',NacionalidadAcreedor='" + txtNacionalidadAcreedor.Text + "',EstadoCivilAcreedor='" + txtEstadoCivilAcreedor.Text + "',ProfesionAcreedor='" + txtOcupacionAcreedor.Text + "',MunicipioAcreedor='" + txtMunicipioAcreedor.Text + "',ProvinciaAcreedor='" + txtProvinciaAcreedor.Text + "',FechaPago='" + DtpFecha.Text + "',Vencimiento='" + dtpVencimiento.Text + "',CiudadAcuerdo='" + txtCiudadAcuerdo.Text + "',Notario='" + txtNotario.Text + "',NoRegistroNotario='" + txtNoRegistroNotario.Text + "',DomicilioNotario='" + txtDomicilioNotario.Text + "',IDTipoIdentificacionNotario='" + lblIDTipoIndetificacionNotario.Text + "',IdentificacionNotario='" + txtIdentificacionNotario.Text + "',NacionalidadNotario='" + txtNacionalidadNotario.Text + "',MunicipioNotario='" + txtMunicipioAcuerdo.Text + "',ProvinciaNotario='" + txtProvinciaAcuerdo.Text + "',Monto='" + txtDeuda.Text + "',CantidadCuotas='" + txtCantidadCuotas.Text + "',MontoCuotas='" + txtMontoCuotas.Text + "',DiasPago='" + txtDiasPago.Value + "',Interes='" + txtInteres.Text + "',Testigo1='" + txtTestigo1.Text + "',IdentificacionTestigo1='" + txtIdentificacionTestigo1.Text + "',DomicilioTestigo1='" + txtDomicilioTestigo1.Text + "',NacionalidadTestigo1='" + txtNacionalidadTestigo1.Text + "',Testigo2='" + txtTestigo2.Text + "',IDTipoIdentificacionTestigo1='" + lblIDTipoIdentificacionTestigo1.Text + "',IDTipoIdentificacionTestigo2='" + lblIDTipoIdentificacionTestigo2.Text + "',IdentificacionTestigo2='" + txtIdentificacionTestigo2.Text + "',DomicilioTestigo2='" + txtDomicilioTestigo2.Text + "',NacionalidadTestigo2='" + txtNacionalidadTestigo2.Text + "',Nota='" + txtNotaAcuerdo.Text + "',Status='" + lblStatus.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAcuerdoPago= (" + txtIDAcuerdo.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDAcuerdo.Text = "" Then
            MessageBox.Show("No hay un registro de acuerdo de pago abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea desactivar el registro de acuerdo de pago No. " & txtIDAcuerdo.Text & " del sistema?", "Desactivar Acuerdo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ChkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE AcuerdosPago SET IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "',IDAlmacen='" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDCliente='" + txtIDCliente.Text + "',IDGeneroDeudor='" + lblIDGeneroDeudor.Text + "',TratamientoDeudor='" + txtTratamientoDeudor.Text + "',Deudor='" + txtDeudor.Text + "',DomicilioDeudor='" + txtDomicilioDeudor.Text + "',IDIdentificacionDeudor='" + lblIDTipoIdentificacionDeudor.Text + "',Identificaciondeudor='" + txtIdentificacionDeudor.Text + "',NacionalidadDeudor='" + txtNacionalidadDeudor.Text + "',EstadoCivilDeudor='" + txtEstadoCivilDeudor.Text + "',ProfesionDeudor='" + txtOcupacionDeudor.Text + "',MunicipioDeudor='" + txtMunicipioDeudor.Text + "',ProvinciaDeudor='" + txtProvinciaDeudor.Text + "',IDGeneroAcreedor='" + lblIDGeneroAcreedor.Text + "',TratamientoAcreedor='" + txtTratamientoAcreedor.Text + "',Acreedor='" + txtAcreedor.Text + "',DomicilioAcreedor='" + txtDomicilioAcreedor.Text + "',IDTipoIdentificacionAcreedor='" + lblIDTipoIdentificacionAcreedor.Text + "',NacionalidadAcreedor='" + txtNacionalidadAcreedor.Text + "',EstadoCivilAcreedor='" + txtEstadoCivilAcreedor.Text + "',ProfesionAcreedor='" + txtOcupacionAcreedor.Text + "',MunicipioAcreedor='" + txtMunicipioAcreedor.Text + "',ProvinciaAcreedor='" + txtProvinciaAcreedor.Text + "',FechaPago='" + DtpFecha.Text + "',Vencimiento='" + dtpVencimiento.Text + "',CiudadAcuerdo='" + txtCiudadAcuerdo.Text + "',Notario='" + txtNotario.Text + "',NoRegistroNotario='" + txtNoRegistroNotario.Text + "',DomicilioNotario='" + txtDomicilioNotario.Text + "',IDTipoIdentificacionNotario='" + lblIDTipoIndetificacionNotario.Text + "',IdentificacionNotario='" + txtIdentificacionNotario.Text + "',NacionalidadNotario='" + txtNacionalidadNotario.Text + "',MunicipioNotario='" + txtMunicipioAcuerdo.Text + "',ProvinciaNotario='" + txtProvinciaAcuerdo.Text + "',Monto='" + txtDeuda.Text + "',CantidadCuotas='" + txtCantidadCuotas.Text + "',MontoCuotas='" + txtMontoCuotas.Text + "',DiasPago='" + txtDiasPago.Value + "',Interes='" + txtInteres.Text + "',Testigo1='" + txtTestigo1.Text + "',IdentificacionTestigo1='" + txtIdentificacionTestigo1.Text + "',DomicilioTestigo1='" + txtDomicilioTestigo1.Text + "',NacionalidadTestigo1='" + txtNacionalidadTestigo1.Text + "',Testigo2='" + txtTestigo2.Text + "',IDTipoIdentificacionTestigo1='" + lblIDTipoIdentificacionTestigo1.Text + "',IDTipoIdentificacionTestigo2='" + lblIDTipoIdentificacionTestigo2.Text + "',IdentificacionTestigo2='" + txtIdentificacionTestigo2.Text + "',DomicilioTestigo2='" + txtDomicilioTestigo2.Text + "',NacionalidadTestigo2='" + txtNacionalidadTestigo2.Text + "',Nota='" + txtNotaAcuerdo.Text + "',Status='" + lblStatus.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDAcuerdoPago= (" + txtIDAcuerdo.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub cbxIdentificacionDeudor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxIdentificacionDeudor.SelectedIndexChanged
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDTipoIdentificacion,Mascara FROM TipoIdentificacion WHERE Descripcion= '" + cbxIdentificacionDeudor.SelectedItem + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoIdentificacion")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("TipoIdentificacion")

            lblIDTipoIdentificacionDeudor.Text = (Tabla.Rows(0).Item("IDTipoIdentificacion"))
            txtIdentificacionDeudor.Mask = (Tabla.Rows(0).Item("Mascara"))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub cbxIdentificacionAcreedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxIdentificacionAcreedor.SelectedIndexChanged
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDTipoIdentificacion,Mascara FROM TipoIdentificacion WHERE Descripcion= '" + cbxIdentificacionAcreedor.SelectedItem + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoIdentificacion")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("TipoIdentificacion")

            lblIDTipoIdentificacionAcreedor.Text = (Tabla.Rows(0).Item("IDTipoIdentificacion"))
            txtIdentificacionAcreedor.Mask = (Tabla.Rows(0).Item("Mascara"))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub cbxTipoIdentNotario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoIdentNotario.SelectedIndexChanged
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDTipoIdentificacion,Mascara FROM TipoIdentificacion WHERE Descripcion= '" + cbxTipoIdentNotario.SelectedItem + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoIdentificacion")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("TipoIdentificacion")

            lblIDTipoIndetificacionNotario.Text = (Tabla.Rows(0).Item("IDTipoIdentificacion"))
            txtIdentificacionNotario.Mask = (Tabla.Rows(0).Item("Mascara"))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub cbxGeneroDeudor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxGeneroDeudor.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDGenero FROM Genero WHERE Genero= '" + cbxGeneroDeudor.SelectedItem + "'", Con)
        lblIDGeneroDeudor.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub cbxGeneroAcreedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxGeneroAcreedor.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDGenero FROM Genero WHERE Genero= '" + cbxGeneroAcreedor.SelectedItem + "'", Con)
        lblIDGeneroAcreedor.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
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

    Private Sub txtInteres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInteres.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCantidadCuotas_Leave(sender As Object, e As EventArgs) Handles txtCantidadCuotas.Leave
        If txtCantidadCuotas.Text = 0 Then
            txtCantidadCuotas.Text = 1
        End If

        If IsNumeric(CDbl(txtDeuda.Text)) Then
            txtMontoCuotas.Text = (CDbl(txtDeuda.Text) / CDbl(txtCantidadCuotas.Text)).ToString("C")
        End If
    End Sub


    Private Sub txtInteres_Leave(sender As Object, e As EventArgs) Handles txtInteres.Leave
        Try
            If txtInteres.Text = "" Then
                txtInteres.Text = CDbl(0).ToString("P")
            Else
                If txtInteres.Text > 100 Then
                    txtInteres.Clear()
                End If
                txtInteres.Text = (CDbl(txtInteres.Text) / 100).ToString("P")
            End If

        Catch ex As Exception
            txtInteres.Text = CDbl(0).ToString("P")
        End Try
    End Sub

    Private Sub txtInteres_Enter(sender As Object, e As EventArgs) Handles txtInteres.Enter
        Try

            If txtInteres.Text = "" Then
            Else
                txtInteres.Text = CDbl(Replace(txtInteres.Text, "%", ""))
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cbxIdentificacionTestigo1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxIdentificacionTestigo1.SelectedIndexChanged
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDTipoIdentificacion,Mascara FROM TipoIdentificacion WHERE Descripcion= '" + cbxIdentificacionTestigo1.SelectedItem + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoIdentificacion")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("TipoIdentificacion")

            lblIDTipoIdentificacionTestigo1.Text = (Tabla.Rows(0).Item("IDTipoIdentificacion"))
            txtIdentificacionTestigo1.Mask = (Tabla.Rows(0).Item("Mascara"))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub cbxIdentificacionTestigo2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxIdentificacionTestigo2.SelectedIndexChanged
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDTipoIdentificacion,Mascara FROM TipoIdentificacion WHERE Descripcion= '" + cbxIdentificacionTestigo2.SelectedItem + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoIdentificacion")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("TipoIdentificacion")

            lblIDTipoIdentificacionTestigo2.Text = (Tabla.Rows(0).Item("IDTipoIdentificacion"))
            txtIdentificacionTestigo2.Mask = (Tabla.Rows(0).Item("Mascara"))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub cbxGeneroNotario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxGeneroNotario.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDGenero FROM Genero WHERE Genero= '" + cbxGeneroNotario.SelectedItem + "'", Con)
        lblIDGeneroNotario.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub txtDeuda_TextChanged(sender As Object, e As EventArgs) Handles txtDeuda.TextChanged
        lblSumaLetraMonto.Text = ConvertNumbertoString(txtDeuda.Text)
    End Sub

    Private Sub txtMontoCuotas_TextChanged(sender As Object, e As EventArgs) Handles txtMontoCuotas.TextChanged
        lblSumaLetraCuotas.Text = ConvertNumbertoString(txtMontoCuotas.Text)
    End Sub
End Class