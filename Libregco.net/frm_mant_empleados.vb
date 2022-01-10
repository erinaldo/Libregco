Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_mant_empleados

    Dim sqlQ As String=""
    Dim cmd, cmd1 As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador, Adaptador1 As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim ChkDeducciones As New DataGridViewCheckBoxColumn
    Dim DefaultNacionalidad As String
    Friend lblIDProvincia, lblIDMunicipio, lblNacionalidad, lblGenero, lblPrivilegio, lblIDAlmacen, lblPeriodoPago, lblAlertas, lblRutaFoto, lblChatFoto, lblIDStatusChat, lblRutaCedula, lblHabilitarNomina, lblChkCobrarTss, lblChkCobrarISR, lblNulo, lblGrayChatFoto As New Label
    Dim Permisos As New ArrayList
    Dim PermisosVacaciones As New ArrayList
    Dim arrTiempoCalculo(2) As Integer
    Private Sub frm_mant_empleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        PermisosVacaciones = PasarPermisos(140)
        SetConfiguracion()
        CargarEmpresa()
        ActualizarDatos()
    End Sub

    Private Sub SetConfiguracion()
        Try
            ConMixta.Open()

            'Nacionalidad Predeterminada
            cmd = New MySqlCommand("SELECT Nacionalidad FROM" & SysName.Text & "Configuracion INNER JOIN Libregco.Nacionalidad on Configuracion.Value2Int=Nacionalidad.IDNacionalidad Where IDConfiguracion=62", ConMixta)
            DefaultNacionalidad = Convert.ToString(cmd.ExecuteScalar())


            ConMixta.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
        PicLogo2.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub ActualizarDatos()
        ColumnsDgvDeduccion()
        LimpiarDatosClientes()
        FillGenero()
        FillNacionalidad()
        FillProvincia()
        FillPrivilegios()
        FillPeriodoPago()
        FillDgvDeducciones()
        FillChatStatus()
        txtCedula.Mask = ""
        txtTelefonoPersonal.Mask = ""
        txtTelefonoHogar.Mask = ""
        ChkAlertas.Checked = False
        txtSalario.Text = CDbl(0).ToString("C")
        txtCuotaPrestamo.Text = CDbl(0).ToString("C")
        txtConsFlota.Text = CDbl(0).ToString("C")
        txtCuotaCuenta.Text = CDbl(0).ToString("C")
        txtCotizable.Text = CDbl(0).ToString("C")
        txtSeguroComplementario.Text = CDbl(0).ToString("C")
        CargarChecks()
        ResetPicFoto()
        ResetPicCedula()
        ResetPicChat()
        PicChat.Image = Nothing
        chkCobrador.Checked = False
        chkVendedor.Checked = False
        TabCEmpleados.SelectedIndex = 0
        lblChkCobrarISR.Text = 0
        lblGrayChatFoto.Text = ""
        lblChkCobrarTss.Text = 0
        btnAnterior.Enabled = False
        txtFechaNacimiento.Value = Today
        txtNombre.Focus()
    End Sub

    Private Sub FillChatStatus()
        Try

            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Status FROM estatusconversacion ORDER BY Status", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "estatusconversacion")
            cbxEstadoChat.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("estatusconversacion")

            For Each Fila As DataRow In Tabla.Rows
                cbxEstadoChat.Items.Add(Fila.Item("Status"))
            Next


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub LimpiarDatosClientes()
        txtIDEmpleado.Text = ""
        txtNombre.Text = ""
        txtApodo.Text = ""
        cbxNacionalidad.Items.Clear()
        txtCedula.Text = ""
        CbxGenero.Items.Clear()
        txtEdad.Text = ""
        CbxProvincia.Items.Clear()
        cbxMunicipio.Items.Clear()
        CbxPeriodoPago.Items.Clear()
        txtDireccion.Text = ""
        txtTelefonoPersonal.Text = ""
        txtTelefonoHogar.Text = ""
        txtCorreo.Clear()
        CbxPeriodoPago.Items.Clear()
        txtIDSucursal.Clear()
        txtSucursal.Clear()
        txtIDNomina.Clear()
        txtTipoNomina.Clear()
        txtIDDepartamento.Clear()
        txtDepartamento.Clear()
        txtIDTanda.Clear()
        txtTanda.Clear()
        txtPuesto.Clear()
        dtpFechaIngreso.Value = Today
        dtpFechaIngreso.Text = Today
        dtpFechaSalida.Value = Today
        dtpVacacionTermina.Value = Today
        dtpVacacionInicia.Value = Today
        txtTiempoLaboral.Text = ""
        txtTotalRecibir.Clear()
        txtSalarioDiario.Clear()
        txtSalario.Text = ""
        txtCuentaBancaria.Clear()
        txtCuotaPrestamo.Clear()
        chkNulo.Checked = False
        chkHabNomina.Checked = False
        txtLogin.Text = ""
        txtPassword.Text = ""
        lblPassInfo.Text = ""
        txtBalance.Clear()
        CbxPrivilegios.Items.Clear()
        txtConfirmacionPassword.Text = ""
        txtIDArs.Clear()
        txtArs.Clear()
        txtIDAfp.Clear()
        txtCarnet.Clear()
        txtAfp.Clear()
        txtDiasVacaciones.Clear()
        txtTotalVacaciones.Clear()
        txtIDVacaciones.Clear()
        DgvVacaciones.Rows.Clear()
        Label45.Text = ""
        DgvMensualidades.Rows.Clear()
        txtSumaSalarios.Clear()
        txtSalarioPromedioMensual.Clear()
        txtSalarioPromedioDiario.Clear()
        TsPreaviso.IsOn = False
        txtPreaviso.Clear()
        TSCesantia.IsOn = True
        txtCesantiaNuevo.Clear()
        txtCensantiaAntes.Clear()
        TSVacaciones.IsOn = True
        txtVacaciones.Clear()
        TSNavidad.IsOn = True
        txtNavidad.Clear()
        txtTiempoLaborado.Clear()
        txtPasswordFactor.Text = ""
        txtPasswordFactorRep.Text = ""
        lblMensajeFactores.Text = ""
        ResetPicFoto()
        ResetPicCedula()
        LimpiarLabels()
        txtNombre.Focus()
    End Sub

    Sub CargarChecks()
        lblNulo.Text = 0
        lblAlertas.Text = 0
        lblHabilitarNomina.Text = 0
    End Sub

    Private Sub FillGenero()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Genero FROM Genero ORDER BY Genero asc", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Genero")
            CbxGenero.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Genero")

            For Each Fila As DataRow In Tabla.Rows
                CbxGenero.Items.Add(Fila.Item("Genero"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillPrivilegios()
        Try

            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Privilegios FROM Privilegios ORDER BY Privilegios asc", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Privilegios")
            CbxPrivilegios.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Privilegios")

            For Each Fila As DataRow In Tabla.Rows
                CbxPrivilegios.Items.Add(Fila.Item("Privilegios"))
            Next


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillProvincia()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Provincia FROM Provincias ORDER BY Provincia ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Provincias")
            CbxProvincia.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Provincias")
            For Each Fila As DataRow In Tabla.Rows
                CbxProvincia.Items.Add(Fila.Item("Provincia"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillMunicipio()
        Try

            SetIDProvincia()

            Ds.Clear()
            ConLibregco.Open()
            cmd1 = New MySqlCommand("SELECT Municipio FROM Municipios WHERE IDProvincia= ('" + lblIDProvincia.Text + "') ORDER BY Municipio ASC", ConLibregco)
            Adaptador1 = New MySqlDataAdapter(cmd1)
            Adaptador1.Fill(Ds, "Municipios")
            cbxMunicipio.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Municipios")

            For Each Fila As DataRow In Tabla.Rows
                cbxMunicipio.Items.Add(Fila.Item("Municipio"))
            Next


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillPeriodoPago()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM PeriodoPago ORDER BY IDPeriodoPago ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "PeriodoPago")
            CbxPeriodoPago.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("PeriodoPago")

            For Each Fila As DataRow In Tabla.Rows
                CbxPeriodoPago.Items.Add(Fila.Item("Descripcion"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
    Private Sub FillNacionalidad()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Nacionalidad FROM Nacionalidad ORDER BY Nacionalidad asc", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Nacionalidad")
            cbxNacionalidad.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Nacionalidad")

            For Each Fila As DataRow In Tabla.Rows
                cbxNacionalidad.Items.Add(Fila.Item("Nacionalidad"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxNacionalidad.Text = DefaultNacionalidad
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub SetIDPrivilegios()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDPrivilegio FROM Privilegios WHERE Privilegios= '" + CbxPrivilegios.SelectedItem + "' Order By Privilegios ASC", ConLibregco)
            lblPrivilegio.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetIDPeriodoPago()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDPeriodoPago FROM PeriodoPago WHERE Descripcion= '" + CbxPeriodoPago.SelectedItem + "'", ConLibregco)
            lblPeriodoPago.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CbxProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxProvincia.SelectedIndexChanged
        FillMunicipio()
    End Sub

    Private Sub SetIDProvincia()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDProvincia FROM Provincias WHERE Provincia= '" + CbxProvincia.SelectedItem + "' Order By Provincia ASC", ConLibregco)
            lblIDProvincia.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try

    End Sub

    Private Sub SetIDMunicipio()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDMunicipio FROM Municipios WHERE Municipio= '" + cbxMunicipio.SelectedItem + "' Order By Municipio ASC", ConLibregco)
            lblIDMunicipio.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub cbxMunicipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMunicipio.SelectedIndexChanged
        SetIDMunicipio()
    End Sub

    Private Sub cbxNacionalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNacionalidad.SelectedIndexChanged
        SetIDNacionalidad()
    End Sub

    Private Sub SetIDNacionalidad()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDNacionalidad FROM Nacionalidad WHERE Nacionalidad= '" + cbxNacionalidad.SelectedItem + "' Order By Nacionalidad ASC", ConLibregco)
            lblNacionalidad.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub SetIDGenero()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDGenero FROM Genero WHERE Genero= '" + CbxGenero.SelectedItem + "' Order By Genero ASC", ConLibregco)
            lblGenero.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub CbxGenero_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxGenero.SelectedIndexChanged
        SetIDGenero()
    End Sub

    Private Sub chkDesactivarEmpleado_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblNulo.Text = 1
            InhabilitarEmpleados()
        Else
            lblNulo.Text = 0
            HabilitarEmpleados()
        End If
    End Sub

    Private Sub CbxPrivilegios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxPrivilegios.SelectedIndexChanged
        SetIDPrivilegios()
    End Sub

    Private Sub txtCedula_TextChanged(sender As Object, e As EventArgs) Handles txtCedula.TextChanged
        If txtCedula.Text = "" Then
            txtCedula.Mask = ""
        Else
            txtCedula.Mask = "000-0000000-0"
        End If
        txtCedula.SelectionStart = 1
    End Sub

    Private Sub DtpFechaNacimiento_Leave(sender As Object, e As EventArgs)
        CalcEdad()
    End Sub

    Sub CalcEdad()
        If Len(txtFechaNacimiento.Text) < 8 Or txtFechaNacimiento.Text = "" Then
            Exit Sub
        Else
            If Not IsDate(txtFechaNacimiento.Text) Then
                MessageBox.Show("El dato introducido no es una fecha válida", "Dato no válido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                Dim DateNacimiento As Date = txtFechaNacimiento.Text
                txtEdad.Text = CalcularFecha(DateNacimiento, Today)
            End If
        End If
    End Sub

    Private Sub txtCedula_Leave(sender As Object, e As EventArgs) Handles txtCedula.Leave
        If Len(txtCedula.Text) < 13 Then
            txtCedula.Mask = ""
            txtCedula.Text = ""
        End If
    End Sub

    Private Sub txtTelefonoPersonal_Leave(sender As Object, e As EventArgs) Handles txtTelefonoPersonal.Leave
        If Len(txtTelefonoPersonal.Text) = 8 Then
            txtTelefonoPersonal.Mask = ""
        End If
        If Len(txtTelefonoPersonal.Text) = 12 Then
            txtTelefonoPersonal.Mask = "000-000-0000"
        End If
    End Sub

    Private Sub txtTelefonoPersonal_TextChanged(sender As Object, e As EventArgs) Handles txtTelefonoPersonal.TextChanged
        If txtTelefonoPersonal.Text = "" Then
            txtTelefonoPersonal.Mask = ""
        Else
            txtTelefonoPersonal.Mask = "000-000-0000"
            txtTelefonoPersonal.SelectionStart = 1
        End If
    End Sub

    Private Sub LimpiarLabels()
        lblNacionalidad.Text = ""
        lblGenero.Text = ""
        lblIDProvincia.Text = ""
        lblIDMunicipio.Text = ""
        lblPrivilegio.Text = ""
        lblPeriodoPago.Text = ""
        lblRutaFoto.Text = ""
        lblRutaCedula.Text = ""
        lblFechaPassword.Text = ""
        lblIDStatusChat.Text = ""
    End Sub

    Sub ResetPicFoto()
        Try
            PicFoto.Width = 276
            PicFoto.Height = 330
            PicFoto.Image = My.Resources.no_photo

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Sub ResetPicChat()
        Try
            PicChat.Width = 300
            PicChat.Height = 300
            PicChat.Image = My.Resources.no_photo

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub
    Sub ResetPicCedula()
        Try

            PicBCedula.Width = 250
            PicBCedula.Height = 337
            PicBCedula.Image = My.Resources.no_photo

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub btnCargarFoto_Click_(sender As Object, e As EventArgs) Handles btnCargarFoto.Click
        Try
            If TypeConnection.Text = 1 Then
                Dim wFile As System.IO.FileStream
                Dim OfdRutaFoto As New OpenFileDialog

                OfdRutaFoto.RestoreDirectory = True
                OfdRutaFoto.Title = ("Selección de foto de empleado")
                OfdRutaFoto.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
                OfdRutaFoto.FileName = txtNombre.Text

                If OfdRutaFoto.ShowDialog = Windows.Forms.DialogResult.OK Then
                    lblRutaFoto.Text = OfdRutaFoto.FileName
                    wFile = New FileStream(OfdRutaFoto.FileName, FileMode.Open, FileAccess.Read)
                    PicFoto.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                End If
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub btnEliminarFoto_Click(sender As Object, e As EventArgs) Handles btnEliminarFoto.Click
        If TypeConnection.Text = 1 Then
            If lblRutaFoto.Text = "" Then
                MessageBox.Show("No existe foto anexa al registro.", "No existe foto", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Desea eliminar la foto anexa al registro?", "Eliminar Identificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    lblRutaFoto.Text = ""
                    ResetPicFoto()
                End If
            End If
        End If
    End Sub

    Private Sub btnAbrirFoto_Click(sender As Object, e As EventArgs) Handles btnAbrirFoto.Click
        If TypeConnection.Text = 1 Then
            If lblRutaFoto.Text = "" Then
                MessageBox.Show("No se ha encontrado la foto anexa para poder abrirla.", "Falta Anexar Foto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Desea abrir la foto vinculada al registro?", "Abrir Identificacion Anexa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(lblRutaFoto.Text)
                End If
            End If
        End If
    End Sub

    Sub CalcTiempoLaboral()
        Try
            txtTiempoLaboral.Text = CalcularFecha(dtpFechaIngreso.Value, Today)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtConfirmacionPassword_Leave(sender As Object, e As EventArgs) Handles txtConfirmacionPassword.Leave
        If txtConfirmacionPassword.Text = txtPassword.Text Then
            lblPassInfo.Text = ""
        Else
            lblPassInfo.Text = "Las contraseñas no coinciden. Intente de nuevo."
            lblPassInfo.ForeColor = Color.Red
        End If
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd1 = New MySqlCommand(sqlQ, ConLibregco)
            cmd1.ExecuteNonQuery()
            ConLibregco.Close()

            ConLibregcoMain.Open()
            cmd1 = New MySqlCommand(sqlQ, ConLibregcoMain)
            cmd1.ExecuteNonQuery()
            ConLibregcoMain.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub GuardarDeducciones()
        Try
            Dim IDDeduccion, IDDeduccionEmp, Activado As New Label
            Dim IsTicked As Boolean

            ConMixta.Open()

            For i As Integer = 0 To DgvDeducciones.Rows.Count - 1
                IDDeduccion.Text = DgvDeducciones.Rows(i).Cells(0).Value
                IsTicked = CBool(DgvDeducciones.Rows(i).Cells(2).Value)

                If IsTicked Then
                    Activado.Text = 1
                Else
                    Activado.Text = 0
                End If

                cmd = New MySqlCommand("SELECT IDDeduccionEmp FROM" & SysName.Text & "DeduccionesEmpleados WHERE IDEmpleado='" + txtIDEmpleado.Text + "' and IDDeduccion='" + IDDeduccion.Text + "'", ConMixta)
                IDDeduccionEmp.Text = Convert.ToString(cmd.ExecuteScalar())

                If IDDeduccionEmp.Text = "" Then
                    sqlQ = "INSERT INTO" & SysName.Text & "DeduccionesEmpleados (IDDeduccion,IDEmpleado,Activado) VALUES ('" + IDDeduccion.Text + "','" + txtIDEmpleado.Text + "','" + Activado.Text + "')"
                    cmd1 = New MySqlCommand(sqlQ, ConMixta)
                    cmd1.ExecuteNonQuery()
                Else
                    sqlQ = "UPDATE" & SysName.Text & "DeduccionesEmpleados SET Activado='" + Activado.Text + "' WHERE IDDeduccionEmp='" + IDDeduccionEmp.Text + "'"
                    cmd1 = New MySqlCommand(sqlQ, ConMixta)
                    cmd1.ExecuteNonQuery()
                End If

                cmd = New MySqlCommand("SELECT IDDeduccionEmp FROM" & SysName.Text & "DeduccionesEmpleados WHERE IDEmpleado='" + txtIDEmpleado.Text + "' and IDDeduccion='" + IDDeduccion.Text + "'", ConMixta)
                IDDeduccionEmp.Text = Convert.ToString(cmd.ExecuteScalar())

                If IDDeduccionEmp.Text = "" Then
                    sqlQ = "INSERT INTO" & SysName.Text & "DeduccionesEmpleados (IDDeduccion,IDEmpleado,Activado) VALUES ('" + IDDeduccion.Text + "','" + txtIDEmpleado.Text + "','" + Activado.Text + "')"
                    cmd1 = New MySqlCommand(sqlQ, ConMixta)
                    cmd1.ExecuteNonQuery()
                Else
                    sqlQ = "UPDATE" & SysName.Text & "DeduccionesEmpleados SET Activado='" + Activado.Text + "' WHERE IDDeduccionEmp='" + IDDeduccionEmp.Text + "'"
                    cmd1 = New MySqlCommand(sqlQ, ConMixta)
                    cmd1.ExecuteNonQuery()
                End If

            Next

            ConMixta.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub UltEmpleado()
        Try
            If txtIDEmpleado.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDEmpleado from Empleados where IDEmpleado= (Select Max(IDEmpleado) from Empleados)", Con)
                txtIDEmpleado.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub txtTelefonoHogar_TextChanged(sender As Object, e As EventArgs) Handles txtTelefonoHogar.TextChanged
        If txtTelefonoHogar.Text = "" Then
            txtTelefonoHogar.Mask = ""
        Else
            txtTelefonoHogar.Mask = "000-000-0000"
            txtTelefonoHogar.SelectionStart = 1
        End If
    End Sub

    Private Sub txtTelefonoHogar_Leave(sender As Object, e As EventArgs) Handles txtTelefonoHogar.Leave
        If Len(txtTelefonoHogar.Text) = 8 Then
            txtTelefonoHogar.Mask = ""
        End If
        If Len(txtTelefonoHogar.Text) = 12 Then
            txtTelefonoHogar.Mask = "000-000-0000"
        End If
    End Sub

    Private Sub InhabilitarEmpleados()
        txtIDEmpleado.Enabled = False
        txtNombre.Enabled = False
        txtApodo.Enabled = False
        cbxNacionalidad.Enabled = False
        txtCedula.Enabled = False
        CbxGenero.Enabled = False
        txtFechaNacimiento.Enabled = False
        txtEdad.Enabled = False
        CbxProvincia.Enabled = False
        cbxMunicipio.Enabled = False
        txtDireccion.Enabled = False
        txtTelefonoPersonal.Enabled = False
        txtTelefonoHogar.Enabled = False
        txtCorreo.Enabled = False
        btnCargarFoto.Enabled = False
        btnEliminarFoto.Enabled = False
        CbxPeriodoPago.Enabled = False
        dtpFechaIngreso.Enabled = False
        txtTiempoLaboral.Enabled = False
        txtSalario.Enabled = False
        CbxPeriodoPago.Enabled = False
        chkNulo.Enabled = False
        btnCargarCedula.Enabled = False
        btnEliminarCedula.Enabled = False
        txtLogin.Enabled = False
        txtPassword.Enabled = False
        CbxPrivilegios.Enabled = False
        txtConfirmacionPassword.Enabled = False
        btnBuscarNomina.Enabled = False
        btnBuscarCargo.Enabled = False
        btnBuscarTanda.Enabled = False
        txtCuentaBancaria.Enabled = False
        txtCuotaPrestamo.Enabled = False
        txtConsFlota.Enabled = False
        txtCarnet.Enabled = False
        DgvDeducciones.Enabled = False
        btn_buscarArs.Enabled = False
        btnBuscarAfp.Enabled = False
        btnSucursal.Enabled = False
        cbxAlmacen.Enabled = False
    End Sub

    Private Sub HabilitarEmpleados()
        txtIDEmpleado.Enabled = True
        txtNombre.Enabled = True
        txtApodo.Enabled = True
        cbxNacionalidad.Enabled = True
        txtCedula.Enabled = True
        CbxGenero.Enabled = True
        txtFechaNacimiento.Enabled = True
        txtEdad.Enabled = True
        CbxProvincia.Enabled = True
        cbxMunicipio.Enabled = True
        txtDireccion.Enabled = True
        txtTelefonoPersonal.Enabled = True
        txtTelefonoHogar.Enabled = True
        txtCorreo.Enabled = True
        btnCargarFoto.Enabled = True
        btnEliminarFoto.Enabled = True
        CbxPeriodoPago.Enabled = True
        dtpFechaIngreso.Enabled = True
        txtTiempoLaboral.Enabled = True
        txtSalario.Enabled = True
        CbxPeriodoPago.Enabled = True
        chkNulo.Enabled = True
        btnCargarCedula.Enabled = True
        btnEliminarCedula.Enabled = True
        txtLogin.Enabled = True
        txtPassword.Enabled = True
        CbxPrivilegios.Enabled = True
        txtConfirmacionPassword.Enabled = True
        btnBuscarNomina.Enabled = True
        btnBuscarCargo.Enabled = True
        btnBuscarTanda.Enabled = True
        txtCuentaBancaria.Enabled = True
        txtCuotaPrestamo.Enabled = True
        txtConsFlota.Enabled = True
        txtCarnet.Enabled = True
        DgvDeducciones.Enabled = True
        btn_buscarArs.Enabled = True
        btnBuscarAfp.Enabled = True
        btnSucursal.Enabled = True
        cbxAlmacen.Enabled = True
    End Sub

    Private Sub ConvertCurrents()
        txtSalario.Text = CDbl(txtSalario.Text).ToString("C")
        txtCuotaPrestamo.Text = CDbl(txtCuotaPrestamo.Text).ToString("C")
        txtConsFlota.Text = CDbl(txtConsFlota.Text).ToString("C")
        txtCuotaCuenta.Text = CDbl(txtCuotaCuenta.Text).ToString("C")
        txtCotizable.Text = CDbl(txtCotizable.Text).ToString("C")
        txtSeguroComplementario.Text = CDbl(txtSeguroComplementario.Text).ToString("C")
    End Sub

    Private Sub ConvertDouble()
        txtSalario.Text = CDbl(txtSalario.Text)
        txtCuotaPrestamo.Text = CDbl(txtCuotaPrestamo.Text)
        txtConsFlota.Text = CDbl(txtConsFlota.Text)
        txtCuotaCuenta.Text = CDbl(txtCuotaCuenta.Text)
        txtCotizable.Text = CDbl(txtCotizable.Text)
        txtSeguroComplementario.Text = CDbl(txtSeguroComplementario.Text)
    End Sub

    Private Sub txtSalario_Leave(sender As Object, e As EventArgs) Handles txtSalario.Leave
        If txtSalario.Text = "" Then
            txtSalario.Text = (0).ToString("C")
        Else
            txtSalario.Text = CDbl(txtSalario.Text).ToString("C")
        End If
    End Sub

    Private Sub CbxPeriodoPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxPeriodoPago.SelectedIndexChanged
        SetIDPeriodoPago()
    End Sub

    Private Sub txtCuotaPrestamo_Leave(sender As Object, e As EventArgs) Handles txtCuotaPrestamo.Leave
        If txtCuotaPrestamo.Text = "" Then
            txtCuotaPrestamo.Text = CDbl(0).ToString("C")
        Else
            txtCuotaPrestamo.Text = CDbl(txtCuotaPrestamo.Text).ToString("C")
        End If
    End Sub

    Private Sub txtCuotaPrestamo_Enter(sender As Object, e As EventArgs) Handles txtCuotaPrestamo.Enter
        If txtCuotaPrestamo.Text = "" Then
        Else
            txtCuotaPrestamo.Text = CDbl(txtCuotaPrestamo.Text)
        End If
    End Sub

    Private Sub btnBuscarCargo_Click(sender As Object, e As EventArgs) Handles btnBuscarCargo.Click
        frm_buscar_cargos_emp.ShowDialog(Me)
    End Sub

    Private Sub txtSalario_Enter(sender As Object, e As EventArgs) Handles txtSalario.Enter
        If txtSalario.Text = "" Then
        Else
            txtSalario.Text = CDbl(txtSalario.Text)
        End If
    End Sub

    Private Sub txtSalario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSalario.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCuotaPrestamo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCuotaPrestamo.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub btnBuscarTanda_Click(sender As Object, e As EventArgs) Handles btnBuscarTanda.Click
        frm_buscar_tandas.ShowDialog(Me)
    End Sub

    Private Sub ColumnsDgvDeduccion()
        DgvDeducciones.Rows.Clear()
        DgvDeducciones.Columns.Clear()

        With DgvDeducciones
            .Columns.Add("IDDeduccion", "Código")  '0
            .Columns.Add("Descripcion", "Deducciones")    '1
            .Columns.Add(ChkDeducciones)    '2
            PropiedadesDgvDeduccion()
        End With

    End Sub

    Private Sub PropiedadesDgvDeduccion()
        With DgvDeducciones
            .Columns(0).Width = 70
            .Columns(0).ReadOnly = True
            .Columns(1).Width = 250
            .Columns(0).ReadOnly = True
            .Columns(2).Width = 80
        End With

        With ChkDeducciones
            .HeaderText = "Incluir"
            .Name = "ChkDeducciones"
            .Width = 60
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .DefaultCellStyle.BackColor = Color.LightGray
            .FlatStyle = FlatStyle.Standard

        End With
    End Sub

    Private Sub FillDgvDeducciones()
        Try
            DgvDeducciones.Rows.Clear()
            Con.Open()
            Dim AnexoSql As New MySqlCommand("SELECT IDDeduccion,Descripcion from Deducciones where Nulo=0 ORDER BY IDDeduccion ASC", Con)

            Dim LectorDeducciones As MySqlDataReader = AnexoSql.ExecuteReader
            While LectorDeducciones.Read
                DgvDeducciones.Rows.Add(LectorDeducciones.GetValue(0), LectorDeducciones.GetValue(1))
            End While

            LectorDeducciones.Close()
            Con.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub FillVacaciones()
        Try
            DgvVacaciones.Rows.Clear()
            ConMixta.Open()
            Dim AnexoSql As New MySqlCommand("SELECT idvacaciones,FechaSalida,FechaEntrada,DiasPagados,ConceptoVacaciones,MontoVacaciones,SecondID FROM" & SysName.Text & "Empleados_vacaciones where IDEmpleado='" + txtIDEmpleado.Text + "'", ConMixta)

            Dim LectorVacaciones As MySqlDataReader = AnexoSql.ExecuteReader
            While LectorVacaciones.Read
                DgvVacaciones.Rows.Add(LectorVacaciones.GetValue(0), LectorVacaciones.GetValue(6), CDate(Convert.ToString(LectorVacaciones.GetValue(1))).ToString("dd/MM/yyyy"), CDate(Convert.ToString(LectorVacaciones.GetValue(2))).ToString("dd/MM/yyyy"), LectorVacaciones.GetValue(3), LectorVacaciones.GetValue(4), CDbl(LectorVacaciones.GetValue(5)).ToString("C"))
            End While

            LectorVacaciones.Close()
            ConMixta.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub dtpFechaIngreso_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaIngreso.ValueChanged
        If dtpFechaIngreso.Value > Today Then
            MessageBox.Show("La fecha de ingreso no puede ser futura, verifique los datos introducidos.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            dtpFechaIngreso.Value = Today
        End If
        CalcTiempoLaboral()

        CalcPrest()
    End Sub

    Sub CalcSalarioDiario()
        If txtSalario.Text = "" Then
        Else
            txtSalarioDiario.Text = (CDbl(txtSalario.Text) / 23.83).ToString("C")
        End If
    End Sub

    Private Sub txtSalario_TextChanged(sender As Object, e As EventArgs) Handles txtSalario.TextChanged
        If txtSalario.Text = "" Then
            txtSalario.Text = 0
        End If
        CalcSalarioDiario()
    End Sub

    Sub SelectDeducciones()
        Try
            Dim IDDeduccion, Activado As New Label

            Con.Open()

            For Each Row As DataGridViewRow In DgvDeducciones.Rows
                IDDeduccion.Text = Row.Cells(0).Value
                cmd = New MySqlCommand("SELECT Activado FROM DeduccionesEmpleados WHERE IDEmpleado='" + txtIDEmpleado.Text + "' and IDDeduccion='" + IDDeduccion.Text + "'", Con)
                Activado.Text = Convert.ToString(cmd.ExecuteScalar())

                If Activado.Text = "" Then
                    Row.Cells(2).Value = 0
                ElseIf Activado.Text = 0 Then
                    Row.Cells(2).Value = 0
                Else
                    Row.Cells(2).Value = 1
                End If
            Next

            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtConsFlota_Enter(sender As Object, e As EventArgs) Handles txtConsFlota.Enter
        If txtConsFlota.Text = "" Then
        Else
            txtConsFlota.Text = CDbl(txtConsFlota.Text)
        End If
    End Sub

    Private Sub txtConsFlota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConsFlota.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtConsFlota_Leave(sender As Object, e As EventArgs) Handles txtConsFlota.Leave
        If txtConsFlota.Text = "" Then
            txtConsFlota.Text = CDbl(0).ToString("C")
        Else
            txtConsFlota.Text = CDbl(txtConsFlota.Text).ToString("C")
        End If
    End Sub

    Private Sub ChkAlertas_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAlertas.CheckedChanged
        If ChkAlertas.Checked = True Then
            lblAlertas.Text = 1
        Else
            lblAlertas.Text = 0
        End If
    End Sub

    Private Sub txtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        If txtLogin.Text <> "" And Validar_Password(txtPassword.Text) = False Then
            MessageBox.Show("La contraseña no cumple con los estándares establecidos." & vbNewLine & vbNewLine & "La contraseña debe tener de 6 a 15 caracteres." & vbNewLine & "Deben tener al menos una letra minúscula" & vbNewLine & "Deben tener al menos una letra mayúscula.", "Requisitos para contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            lblPassInfo.Text = "La contraseña no cumple los requisitos"
            lblPassInfo.ForeColor = Color.Red
        Else
            lblPassInfo.Text = ""
        End If

        If txtPassword.Text <> txtConfirmacionPassword.Text Then
            lblFechaPassword.Text = Today.ToString("yyyy-MM-dd")
        End If
    End Sub

    Private Sub txtLogin_Leave(sender As Object, e As EventArgs) Handles txtLogin.Leave
        Try
            If txtLogin.Text <> "" Then
                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("Select IDEmpleado,Nombre,Login from Empleados where Login='" + txtLogin.Text + "' ", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Empleados")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("Empleados")
                If Tabla.Rows.Count > 0 Then
                    If txtIDEmpleado.Text = "" Then
                        lblPassInfo.Text = "El nombre de usuario introducido ya esta siendo utilizado por otro empleado."
                        lblPassInfo.ForeColor = Color.Red
                        txtLogin.Focus()
                        txtLogin.SelectAll()
                    Else
                        If (Tabla.Rows(0).Item("IDEmpleado")) = txtIDEmpleado.Text Then
                        Else
                            lblPassInfo.Text = "El nombre de usuario introducido ya esta siendo utilizado por otro empleado."
                            lblPassInfo.ForeColor = Color.Red
                            txtLogin.Focus()
                            txtLogin.SelectAll()
                            Exit Sub
                        End If
                    End If
                End If
            End If

            If Len(txtLogin.Text) > 0 And Len(txtLogin.Text) < 5 Then
                lblPassInfo.Text = "El nombre de usuario debe tener 4 o más caracteres."
                lblPassInfo.ForeColor = Color.Red
            Else
                lblPassInfo.Text = ""
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtCorreo_Leave(sender As Object, e As EventArgs) Handles txtCorreo.Leave
        If txtCorreo.Text <> "" Then
            If Validar_Mail(LCase(txtCorreo.Text)) = False Then
                MessageBox.Show("La dirección de correo electrónico no es no válida. El correo debe tener el formato: nombre@dominio.com, por favor escriba un correo válido.", "Validación de correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCorreo.Focus()
                txtCorreo.SelectAll()
            End If
        End If
    End Sub

    Private Sub btn_buscarArs_Click(sender As Object, e As EventArgs) Handles btn_buscarArs.Click
        frm_buscar_ars.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarAfp_Click(sender As Object, e As EventArgs) Handles btnBuscarAfp.Click
        frm_buscar_afp.ShowDialog(Me)
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If TabCEmpleados.SelectedIndex = 0 Then
        ElseIf TabCEmpleados.SelectedIndex = 1 Then
            TabCEmpleados.SelectedIndex = 0
            btnAnterior.Enabled = False
            cbxNacionalidad.Focus()
        ElseIf TabCEmpleados.SelectedIndex = 2 Then
            btnAnterior.Enabled = True
            btnSiguiente.Enabled = True
            TabCEmpleados.SelectedIndex = 1
            btnBuscarNomina.Focus()
        ElseIf TabCEmpleados.SelectedIndex = 3 Then
            btnAnterior.Enabled = True
            btnSiguiente.Enabled = True
            TabCEmpleados.SelectedIndex = 2
            btnCargarCedula.Focus()
        ElseIf TabCEmpleados.SelectedIndex = 4 Then
            btnAnterior.Enabled = True
            btnSiguiente.Enabled = True
            TabCEmpleados.SelectedIndex = 3
            btnCargarCedula.Focus()
        ElseIf TabCEmpleados.SelectedIndex = 5 Then
            btnAnterior.Enabled = True
            btnSiguiente.Enabled = True
            TabCEmpleados.SelectedIndex = 4
            btnCargarCedula.Focus()
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If TabCEmpleados.SelectedIndex = 0 Then
            btnAnterior.Enabled = True
            btnSiguiente.Enabled = True
            TabCEmpleados.SelectedIndex = 1
            btnBuscarNomina.Focus()
        ElseIf TabCEmpleados.SelectedIndex = 1 Then
            TabCEmpleados.SelectedIndex = 2
            btnAnterior.Enabled = True
            btnSiguiente.Enabled = True
            txtCuentaBancaria.Focus()
        ElseIf TabCEmpleados.SelectedIndex = 2 Then
            btnAnterior.Enabled = True
            btnSiguiente.Enabled = False
            TabCEmpleados.SelectedIndex = 3
            btnCargarCedula.Focus()
        ElseIf TabCEmpleados.SelectedIndex = 3 Then
            btnAnterior.Enabled = True
            btnSiguiente.Enabled = False
            TabCEmpleados.SelectedIndex = 4
            btnCargarCedula.Focus()
        ElseIf TabCEmpleados.SelectedIndex = 4 Then
            btnAnterior.Enabled = True
            btnSiguiente.Enabled = False
            TabCEmpleados.SelectedIndex = 5
            btnCargarCedula.Focus()
        End If
    End Sub

    Private Sub TabCEmpleados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabCEmpleados.SelectedIndexChanged
        If TabCEmpleados.SelectedIndex = 0 Then
            btnSiguiente.Enabled = True
            btnAnterior.Enabled = False
        ElseIf TabCEmpleados.SelectedIndex = 1 Then
            btnSiguiente.Enabled = True
            btnAnterior.Enabled = True
        ElseIf TabCEmpleados.SelectedIndex = 2 Then
            btnSiguiente.Enabled = True
            btnAnterior.Enabled = True
        ElseIf TabCEmpleados.SelectedIndex = 3 Then
            If PermisosVacaciones(1) = 0 Then
                TabPage7.Enabled = False
            End If

            CalcPrest()

        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDEmpleado.Text = "" Then
            If txtNombre.Text <> "" Or txtDireccion.Text <> "" Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario de mantenimiento de empleados?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatosClientes()
                    ActualizarDatos()
                End If
            Else
                LimpiarDatosClientes()
                ActualizarDatos()
            End If
        Else
            LimpiarDatosClientes()
            ActualizarDatos()
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If txtNombre.Text = "" Then
                MessageBox.Show("El nombre del empleado se encuentra vacío. Escriba el nombre del empleado para procesar el registro.", "Escriba el nombre del empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 0
                txtNombre.Focus()
                Exit Sub
            ElseIf CbxGenero.Text = "" Then
                MessageBox.Show("Seleccione el género correspondiente al empleado.", "Seleccione el género", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 0
                CbxGenero.Focus()
                CbxGenero.DroppedDown = True
                Exit Sub
            ElseIf CbxProvincia.Text = "" Then
                MessageBox.Show("Seleccione la provincia correspondiente del cliente.", "Seleccione la provincia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 0
                CbxProvincia.Focus()
                CbxProvincia.DroppedDown = True
                Exit Sub
            ElseIf cbxMunicipio.Text = "" Then
                MessageBox.Show("Seleccione el municipio correspondiente al cliente.", "Seleccione el municipio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 0
                cbxMunicipio.Focus()
                cbxMunicipio.DroppedDown = True
                Exit Sub
            ElseIf txtIDSucursal.Text = "" Then
                MessageBox.Show("Seleccione la sucursal a la cual pertenece el empleado.", "Seleccionar Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                btnSucursal.PerformClick()
                Exit Sub
            ElseIf cbxAlmacen.Text = "" Then
                MessageBox.Show("Seleccione el almacén correspondiente del empleado.", "Seleccionar Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                cbxAlmacen.Focus()
                cbxAlmacen.DroppedDown = True
                Exit Sub
            ElseIf txtIDNomina.Text = "" Then
                MessageBox.Show("Seleccione la nómina del empleado", "Seleccionar nómina", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                btnBuscarNomina.PerformClick()
                Exit Sub
            ElseIf txtIDDepartamento.Text = "" Then
                MessageBox.Show("Seleccione el cargo del empleado", "Seleccionar Cargo Departamental", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                btnBuscarCargo.PerformClick()
                Exit Sub
            ElseIf txtIDTanda.Text = "" Then
                MessageBox.Show("Seleccione la tanda del empleado", "Seleccionar Tanda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                btnBuscarTanda.PerformClick()
                Exit Sub
            ElseIf txtIDArs.Text = "" Then
                MessageBox.Show("Seleccione la aseguradora de riesgos laborales del empleado.", "Seleccionar Ars", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                btn_buscarArs.PerformClick()
                Exit Sub
            ElseIf txtIDAfp.Text = "" Then
                MessageBox.Show("Seleccione la administradora de fondos de pensión del empleado.", "Seleccionar Afp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                btnBuscarAfp.PerformClick()
                Exit Sub
            ElseIf CbxPeriodoPago.Text = "" Then
                MessageBox.Show("Seleccione el período de pago del empleado.", "Seleccione la forma de pago del empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                CbxPeriodoPago.Focus()
                CbxPeriodoPago.DroppedDown = True
                Exit Sub
            ElseIf CbxPrivilegios.Text = "" Then
                MessageBox.Show("Seleccione el tipo de privilegios del empleado.", "Seleccione los privilegios", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 4
                CbxPrivilegios.Focus()
                CbxPrivilegios.DroppedDown = True
                Exit Sub
            ElseIf cbxEstadoChat.Text = "" Then
                MessageBox.Show("Seleccione un estado para mostrar en el chat del sistema.", "Seleccione estado en el chat", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 3
                cbxEstadoChat.Focus()
                cbxEstadoChat.DroppedDown = True
            ElseIf NuevaEstructuracion = True Then
                If txtLogin.Text = "" Then
                    MessageBox.Show("Es necesario que establezca su cuenta de inicio para acceder al sistema. Por favor escriba el nombre de usuario que desea utilizar.", "Escriba su nombre de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    TabCEmpleados.SelectedIndex = 4
                    txtLogin.Focus()
                    Exit Sub
                ElseIf txtPassword.Text = "" Then
                    MessageBox.Show("La contraseña está en blanco. Por facor escriba la contraseña de su cuenta de inicio para continuar con el registro de la cuenta.", "Escriba la contraseña de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    TabCEmpleados.SelectedIndex = 4
                    txtPassword.Focus()
                    Exit Sub
                End If
            ElseIf txtPasswordFactor.Text > "" Then
                If txtPasswordFactor.Text <> txtPasswordFactorRep.Text Then
                    MessageBox.Show("La contraseña de 4 factores no coincide. Por favor vuelva a escribir la contraseña e intente volver a guardar el registro.", "Contraseña no coincide", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    TabCEmpleados.SelectedIndex = 0
                    txtPasswordFactor.Focus()
                    Exit Sub
                End If
            End If

            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If chkNulo.Checked = True Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("El empleado " & txtNombre.Text & "  ya está desactivado del sistema. Desea volver a activarlo.", "Activar Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    ConvertDouble()
                    chkNulo.Checked = False
                    sqlQ = "UPDATE Empleados SET Nombre='" + txtNombre.Text + "',Apodo='" + txtApodo.Text + "',IDNacionalidad='" + lblNacionalidad.Text + "',Cedula='" + txtCedula.Text + "',IDGenero='" + lblGenero.Text + "',FechaNacimiento='" + txtFechaNacimiento.Value.ToString("yyyy-MM-dd") + "',IDProvincia='" + lblIDProvincia.Text + "',IDMunicipio='" + lblIDMunicipio.Text + "',Direccion='" + txtDireccion.Text + "',TelefonoPersonal='" + txtTelefonoPersonal.Text + "',TelefonoHogar='" + txtTelefonoHogar.Text + "',CorreoElectronico='" + txtCorreo.Text + "',RutaFoto='" + Replace(lblRutaFoto.Text, "\", "\\") + "',IDSucursal='" + txtIDSucursal.Text + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDTipoNomina='" + txtIDNomina.Text + "',Salario='" + txtSalario.Text + "',Cotizable='" + txtCotizable.Text + "',IDCargo='" + txtIDDepartamento.Text + "',Puesto='" + txtPuesto.Text + "',IDPeriodoPago='" + lblPeriodoPago.Text + "',IDTanda='" + txtIDTanda.Text + "',IDArs='" + txtIDArs.Text + "',IDAfp='" + txtIDAfp.Text + "',Carnet='" + txtCarnet.Text + "',FechaIngreso='" + dtpFechaIngreso.Value.ToString("yyyy-MM-dd") + "',CuentaBancaria='" + txtCuentaBancaria.Text + "',CuotaPrestamo='" + txtCuotaPrestamo.Text + "',CuotaCuenta='" + txtCuotaCuenta.Text + "',ConsumoFlota='" + txtConsFlota.Text + "',IDPrivilegios='" + lblPrivilegio.Text + "',RutaCedula='" + Replace(lblRutaCedula.Text, "\", "\\") + "',Login='" + txtLogin.Text + "',Password='" + txtPassword.Text + "',FechaPassword='" + lblFechaPassword.Text + "',Alertas='" + lblAlertas.Text + "',HabilitarNomina='" + lblHabilitarNomina.Text + "',CobrarTss='" + lblChkCobrarTss.Text + "',CobrarIsr='" + lblChkCobrarISR.Text + "',IDChatStatus='" + lblIDStatusChat.Text + "',ImagenChat='" + Replace(lblChatFoto.Text, "\", "\\") + "',VacacionInicia='" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "',VacacionTermina='" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "',Nulo='" + lblNulo.Text + "',FactorNumerico='" + txtPasswordFactor.Text + "',SeguroComplementario='" + txtSeguroComplementario.Text + "',EsVendedor='" + Convert.ToInt16(chkVendedor.CheckState).ToString + "',EsCobrador='" + Convert.ToInt16(chkCobrador.CheckState).ToString + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"
                    GuardarDatos()
                    MoverFichero()
                    GuardarDeducciones()
                    ConvertCurrents()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            ElseIf txtIDEmpleado.Text = "" Then
                MessageBox.Show("No hay un registro de empleado abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea desactivar el registro del empleado " & txtNombre.Text & " del sistema?", "Desactivar Empleado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    chkNulo.Checked = True
                    sqlQ = "UPDATE Empleados SET Nombre='" + txtNombre.Text + "',Apodo='" + txtApodo.Text + "',IDNacionalidad='" + lblNacionalidad.Text + "',Cedula='" + txtCedula.Text + "',IDGenero='" + lblGenero.Text + "',FechaNacimiento='" + txtFechaNacimiento.Value.ToString("yyyy-MM-dd") + "',IDProvincia='" + lblIDProvincia.Text + "',IDMunicipio='" + lblIDMunicipio.Text + "',Direccion='" + txtDireccion.Text + "',TelefonoPersonal='" + txtTelefonoPersonal.Text + "',TelefonoHogar='" + txtTelefonoHogar.Text + "',CorreoElectronico='" + txtCorreo.Text + "',RutaFoto='" + Replace(lblRutaFoto.Text, "\", "\\") + "',IDSucursal='" + txtIDSucursal.Text + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDTipoNomina='" + txtIDNomina.Text + "',Salario='" + txtSalario.Text + "',Cotizable='" + txtCotizable.Text + "',IDCargo='" + txtIDDepartamento.Text + "',Puesto='" + txtPuesto.Text + "',IDPeriodoPago='" + lblPeriodoPago.Text + "',IDTanda='" + txtIDTanda.Text + "',IDArs='" + txtIDArs.Text + "',IDAfp='" + txtIDAfp.Text + "',Carnet='" + txtCarnet.Text + "',FechaIngreso='" + dtpFechaIngreso.Value.ToString("yyyy-MM-dd") + "',CuentaBancaria='" + txtCuentaBancaria.Text + "',CuotaPrestamo='" + txtCuotaPrestamo.Text + "',CuotaCuenta='" + txtCuotaCuenta.Text + "',ConsumoFlota='" + txtConsFlota.Text + "',IDPrivilegios='" + lblPrivilegio.Text + "',RutaCedula='" + Replace(lblRutaCedula.Text, "\", "\\") + "',Login='" + txtLogin.Text + "',Password='" + txtPassword.Text + "',FechaPassword='" + lblFechaPassword.Text + "',Alertas='" + lblAlertas.Text + "',HabilitarNomina='" + lblHabilitarNomina.Text + "',CobrarTss='" + lblChkCobrarTss.Text + "',CobrarIsr='" + lblChkCobrarISR.Text + "',IDChatStatus='" + lblIDStatusChat.Text + "',ImagenChat='" + Replace(lblChatFoto.Text, "\", "\\") + "',VacacionInicia='" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "',VacacionTermina='" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "',Nulo='" + lblNulo.Text + "',FactorNumerico='" + txtPasswordFactor.Text + "',SeguroComplementario='" + txtSeguroComplementario.Text + "',EsVendedor='" + Convert.ToInt16(chkVendedor.CheckState).ToString + "',EsCobrador='" + Convert.ToInt16(chkCobrador.CheckState).ToString + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"
                    GuardarDatos()
                    MoverFichero()
                    GuardarDeducciones()
                    ConvertCurrents()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnBuscarNomina_Click(sender As Object, e As EventArgs) Handles btnBuscarNomina.Click
        frm_buscar_tipo_nomina.ShowDialog(Me)
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        GuardarToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub ImprimirToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem1.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        Close()
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub chkHabNomina_CheckedChanged(sender As Object, e As EventArgs) Handles chkHabNomina.CheckedChanged
        If chkHabNomina.Checked = True Then
            lblHabilitarNomina.Text = 1
        Else
            lblHabilitarNomina.Text = 0
        End If
    End Sub

    Private Sub btnSucursal_Click(sender As Object, e As EventArgs) Handles btnSucursal.Click
        frm_buscar_sucursal.ShowDialog(Me)
    End Sub

    Private Sub txtIDSucursal_TextChanged(sender As Object, e As EventArgs) Handles txtIDSucursal.TextChanged
        FillAlmacen()
    End Sub

    Private Sub FillAlmacen()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Almacen FROM Almacen WHERE IDSucursal='" + txtIDSucursal.Text + "' ORDER BY Almacen ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Almacen")
        cbxAlmacen.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Almacen")

        For Each Fila As DataRow In Tabla.Rows
            cbxAlmacen.Items.Add(Fila.Item("Almacen"))
        Next

        If txtIDSucursal.Text <> "" And Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron almacenes dependientes de la sucursal: " & txtSucursal.Text & ". Inserte almacenes válidos para poder procesar al empleado.", "No se encontraron almacenes de la sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub cbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAlmacen.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + cbxAlmacen.SelectedItem + "'", Con)
        lblIDAlmacen.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub CargarFotoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarFotoToolStripMenuItem.Click
        btnCargarFoto.PerformClick()
    End Sub

    Private Sub AbrirFotoDelEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirFotoDelEmpleadoToolStripMenuItem.Click
        btnAbrirFoto.PerformClick()
    End Sub

    Private Sub EliminarFotoDelEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarFotoDelEmpleadoToolStripMenuItem.Click
        btnEliminarFoto.PerformClick()
    End Sub

    Private Sub CargarImagenDeIndetificaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarImagenDeIndetificaciónToolStripMenuItem.Click
        btnCargarCedula.PerformClick()
    End Sub

    Private Sub AbrirImagenDeIdentificaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirImagenDeIdentificaciónToolStripMenuItem.Click
        btnAbrirCedula.PerformClick()
    End Sub

    Private Sub EliminarImagenDeIdentificaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarImagenDeIdentificaciónToolStripMenuItem.Click
        btnEliminarCedula.PerformClick()
    End Sub

    Private Sub txtFechaNacimiento_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaNacimiento.ValueChanged
        CalcEdad()
    End Sub

    Private Sub DgvDeducciones_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvDeducciones.CurrentCellDirtyStateChanged
        If TypeOf DgvDeducciones.CurrentCell Is DataGridViewCheckBoxCell Then
            DgvDeducciones.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub chkTesoreria_CheckedChanged(sender As Object, e As EventArgs) Handles chkTesoreria.CheckedChanged
        If chkTesoreria.Checked = True Then
            lblChkCobrarTss.Text = 1
        Else
            lblChkCobrarTss.Text = 0
        End If
    End Sub

    Private Sub chkISR_CheckedChanged(sender As Object, e As EventArgs) Handles chkISR.CheckedChanged
        If chkISR.Checked = True Then
            lblChkCobrarISR.Text = 1
        Else
            lblChkCobrarISR.Text = 0
        End If
    End Sub

    Private Sub txtCuotaCuenta_Enter(sender As Object, e As EventArgs) Handles txtCuotaCuenta.Enter
        If txtCuotaCuenta.Text = "" Then
        Else
            txtCuotaCuenta.Text = CDbl(txtCuotaCuenta.Text)
        End If
    End Sub

    Private Sub txtCuotaCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCuotaCuenta.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCuotaCuenta_Leave(sender As Object, e As EventArgs) Handles txtCuotaCuenta.Leave
        If txtCuotaCuenta.Text = "" Then
            txtCuotaCuenta.Text = CDbl(0).ToString("C")
        Else
            txtCuotaCuenta.Text = CDbl(txtCuotaCuenta.Text).ToString("C")
        End If
    End Sub

    Private Sub cbxEstadoChat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEstadoChat.SelectedIndexChanged
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDEstatusConversacion FROM estatusconversacion where Status= '" + cbxEstadoChat.SelectedItem + "'", ConLibregco)
            lblIDStatusChat.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try

            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If txtIDEmpleado.Text <> "" Then
                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue
                Dim ObjRpt As New ReportDocument

                Con.Open()
                cmd = New MySqlCommand("Select Path from Reportes where IDReportes=192", Con)
                Dim Path As String = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()


                ObjRpt.Load("\\" & PathServidor.Text & Path)

                crParameterValues.Clear()
                frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@CodigoEmpleado")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterRangeValue = New ParameterRangeValue

                With crParameterRangeValue
                    .EndValue = txtIDEmpleado.Text
                    .LowerBoundType = RangeBoundType.BoundInclusive
                    .StartValue = txtIDEmpleado.Text
                    .UpperBoundType = RangeBoundType.BoundInclusive
                End With

                crParameterValues.Add(crParameterRangeValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@FechaIngreso
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@FechaIngreso")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterRangeValue = New ParameterRangeValue
                With crParameterRangeValue
                    .StartValue = dtpFechaIngreso.Value.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = dtpFechaIngreso.Value.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With
                crParameterValues.Add(crParameterRangeValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@FechaNacimiento
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@FechaNacimiento")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterRangeValue = New ParameterRangeValue
                With crParameterRangeValue
                    .StartValue = Today.AddYears(-80)
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = Today
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With
                crParameterValues.Add(crParameterRangeValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Nacionalidad
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Nacionalidad")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Genero
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Genero")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Provincia
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Provincia")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Municipio
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Municipio")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Sucursal
                If txtIDSucursal.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDSucursal.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Sucursal")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Almacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Nomina
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Nomina")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Cargo
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cargo")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Departamento
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Departamento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Tanda
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Tanda")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@ARS
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@ARS")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@AFP
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@AFP")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Periodo
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Periodo")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Alertas
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Alertas")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@enNomina
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@enNomina")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Estado
                crParameterDiscreteValue.Value = 2

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'Setting Info
                'Resumir Reporte
                ObjRpt.SetParameterValue("@Resumir", 1)

                'Ordenamiento de Reporte
                ObjRpt.SetParameterValue("@SortedField", "Cód. Empleado")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "Cód. Empleado")
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lblStatusBar.Text = "Visualizando el reporte..."
                Dim TmpForm = New frm_reportView
                TmpForm.Show(Me)
                TmpForm.CrystalViewer.ReportSource = ObjRpt
                TmpForm.CrystalViewer.Refresh()
                TmpForm.CrystalViewer.Cursor = Cursors.Default
                lblStatusBar.Text = "Listo"


            Else
                MessageBox.Show("No se encuentra un registro disponible en el formulario para imprimir. Por favor seleccione o guarde un registro para imprimir.", "No hay registro abierto", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CreateFolder()
        Try

            Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Empleados\Fotos")
            If Exists = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Empleados\Fotos")
            End If

            Dim Exists1 As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Empleados\Cedulas")
            If Exists1 = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Empleados\Cedulas")
            End If

            Dim Exists2 As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Empleados\Chat")
            If Exists2 = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Empleados\Chat")
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


    Private Sub MoverFichero()
        Try
            If TypeConnection.Text = 1 Then

                Dim Exists As Boolean
                Dim RutaDestino As String

                CreateFolder()

                'Modificando ruta de foto

                If lblRutaFoto.Text <> "" Then
                    Exists = System.IO.File.Exists(lblRutaFoto.Text)

                    If Exists = True Then
                        RutaDestino = "\\" & PathServidor.Text & "\Libregco\Files\Empleados\Fotos\[" & txtIDEmpleado.Text & "] " & txtNombre.Text & ".png"

                        If RutaDestino <> lblRutaFoto.Text Then
                            My.Computer.FileSystem.MoveFile(lblRutaFoto.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                            lblRutaFoto.Text = RutaDestino

                            sqlQ = "UPDATE Empleados SET RutaFoto='" + Replace(lblRutaFoto.Text, "\", "\\") + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"

                            ConLibregco.Open()
                            cmd1 = New MySqlCommand(sqlQ, ConLibregco)
                            cmd1.ExecuteNonQuery()
                            ConLibregco.Close()

                            ConLibregcoMain.Open()
                            cmd1 = New MySqlCommand(sqlQ, ConLibregcoMain)
                            cmd1.ExecuteNonQuery()
                            ConLibregcoMain.Close()


                        End If

                    Else
                        MessageBox.Show("El archivo " & lblRutaFoto.Text & " ha sido movido o eliminado antes de ser guardado en la base de datos.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If


                'Modificando ruta de cedula
                If lblRutaCedula.Text <> "" Then
                    Exists = System.IO.File.Exists(lblRutaCedula.Text)

                    If Exists = True Then
                        RutaDestino = "\\" & PathServidor.Text & "\Libregco\Files\Empleados\Cedulas\[" & txtIDEmpleado.Text & "] " & txtNombre.Text & ".png"

                        If RutaDestino <> lblRutaCedula.Text Then
                            My.Computer.FileSystem.MoveFile(lblRutaCedula.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                            lblRutaCedula.Text = RutaDestino

                            sqlQ = "UPDATE Empleados SET RutaCedula='" + Replace(lblRutaCedula.Text, "\", "\\") + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"

                            ConLibregco.Open()
                            cmd1 = New MySqlCommand(sqlQ, ConLibregco)
                            cmd1.ExecuteNonQuery()
                            ConLibregco.Close()

                            ConLibregcoMain.Open()
                            cmd1 = New MySqlCommand(sqlQ, ConLibregcoMain)
                            cmd1.ExecuteNonQuery()
                            ConLibregcoMain.Close()


                        End If

                    Else
                        MessageBox.Show("El archivo " & lblRutaCedula.Text & " ha sido movido o eliminado antes de ser guardado en la base de datos.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If




                'If lblRutaCedula.Text <> "" Then
                '    ExistFile = System.IO.File.Exists(lblRutaCedula.Text)
                '    If ExistFile = True Then
                '        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Empleados\Cedulas\[" & txtIDEmpleado.Text & "] " & txtNombre.Text & ".png"

                '        If Path.GetFileName(RutaDestino) <> Path.GetFileName(lblRutaCedula.Text) Then
                '            My.Computer.FileSystem.MoveFile(lblRutaCedula.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                '            lblRutaCedula.Text = RutaDestino
                '        End If

                '    Else
                '        MessageBox.Show("El archivo " & lblRutaCedula.Text & " ha sido movido o eliminado antes de ser guardado en la base de datos.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                '    End If
                'End If

                'Modificando ruta de chat
                If lblChatFoto.Text <> "" Then
                    Exists = System.IO.File.Exists(lblChatFoto.Text)

                    If Exists = True Then
                        RutaDestino = "\\" & PathServidor.Text & "\Libregco\Files\Empleados\Chat\[" & txtIDEmpleado.Text & "] " & txtNombre.Text & ".png"

                        If RutaDestino <> lblChatFoto.Text Then
                            My.Computer.FileSystem.MoveFile(lblChatFoto.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                            lblChatFoto.Text = RutaDestino

                            sqlQ = "UPDATE Empleados SET ImagenChat='" + Replace(lblChatFoto.Text, "\", "\\") + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"


                            ConLibregco.Open()
                            cmd1 = New MySqlCommand(sqlQ, ConLibregco)
                            cmd1.ExecuteNonQuery()
                            ConLibregco.Close()

                            ConLibregcoMain.Open()
                            cmd1 = New MySqlCommand(sqlQ, ConLibregcoMain)
                            cmd1.ExecuteNonQuery()
                            ConLibregcoMain.Close()

                            'Gray Picture
                            RutaDestino = "\\" & PathServidor.Text & "\Libregco\Files\Empleados\Chat\[" & txtIDEmpleado.Text & "] " & "Gray-" & txtNombre.Text & ".png"

                            Dim GrayBitmap As Bitmap

                            If RutaDestino <> lblGrayChatFoto.Text Then
                                If lblChatFoto.Text <> "" Then
                                    GrayBitmap = ConvertToGrayScale(PicChat.Image)
                                    'ElseIf lblRutaFoto.Text <> "" Then
                                    'GrayBitmap = ConvertToGrayScale(PicFoto.Image)
                                End If

                                GrayBitmap.Save(RutaDestino, System.Drawing.Imaging.ImageFormat.Jpeg)

                                sqlQ = "UPDATE Empleados SET GrayPictureFile='" + Replace(RutaDestino, "\", "\\") + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"

                                ConLibregco.Open()
                                cmd1 = New MySqlCommand(sqlQ, ConLibregco)
                                cmd1.ExecuteNonQuery()
                                ConLibregco.Close()

                                ConLibregcoMain.Open()
                                cmd1 = New MySqlCommand(sqlQ, ConLibregcoMain)
                                cmd1.ExecuteNonQuery()
                                ConLibregcoMain.Close()
                            End If

                        Else
                            MessageBox.Show("El archivo " & lblChatFoto.Text & " ha sido movido o eliminado antes de ser guardado en la base de datos.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                End If
                'If lblGrayChatFoto.Text = "" Then
                '    Exists = System.IO.File.Exists(lblGrayChatFoto.Text)

                '    If Exists = False Then
                '        RutaDestino = "\\" & PathServidor.Text & "\Libregco\Files\Empleados\Chat\[" & txtIDEmpleado.Text & "] " & "Gray-" & txtNombre.Text

                '        Dim GrayBitmap As Bitmap

                '        If RutaDestino <> lblGrayChatFoto.Text Then
                '            If lblChatFoto.Text <> "" Then
                '                GrayBitmap = ConvertToGrayScale(PicChat.Image)
                '            ElseIf lblRutaFoto.Text <> "" Then
                '                GrayBitmap = ConvertToGrayScale(PicFoto.Image)
                '            End If

                '            GrayBitmap.Save(RutaDestino, System.Drawing.Imaging.ImageFormat.Jpeg)

                '            sqlQ = "UPDATE Empleados SET GrayPictureFile='" + Replace(RutaDestino, "\", "\\") + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"

                '            ConLibregco.Open()
                '            cmd1 = New MySqlCommand(sqlQ, ConLibregco)
                '            cmd1.ExecuteNonQuery()
                '            ConLibregco.Close()

                '            ConLibregcoMain.Open()
                '            cmd1 = New MySqlCommand(sqlQ, ConLibregcoMain)
                '            cmd1.ExecuteNonQuery()
                '            ConLibregcoMain.Close()
                '        End If
                '    End If
                'End If



                'If lblChatFoto.Text <> "" Then
                '    ExistFile = System.IO.File.Exists(lblChatFoto.Text)
                '    If ExistFile = True Then
                '        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Empleados\Chat\[" & txtIDEmpleado.Text & "] " & txtNombre.Text & ".png"

                '        If Path.GetFileName(RutaDestino) <> Path.GetFileName(lblChatFoto.Text) Then
                '            My.Computer.FileSystem.MoveFile(lblChatFoto.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                '            lblChatFoto.Text = RutaDestino
                '        End If


                '    Else
                '        MessageBox.Show("El archivo " & lblChatFoto.Text & " ha sido movido o eliminado antes de ser guardado en la base de datos.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                '    End If
                'End If


            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub btnCargarCedula_Click(sender As Object, e As EventArgs) Handles btnCargarCedula.Click
        Try
            If TypeConnection.Text = 1 Then
                Dim wFile As System.IO.FileStream
                Dim OfdRutaCedula As New OpenFileDialog

                OfdRutaCedula.RestoreDirectory = True
                OfdRutaCedula.Title = ("Seleccionar de identificación")
                OfdRutaCedula.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
                OfdRutaCedula.FileName = ""

                If OfdRutaCedula.ShowDialog = Windows.Forms.DialogResult.OK Then
                    lblRutaCedula.Text = OfdRutaCedula.FileName
                    wFile = New FileStream(OfdRutaCedula.FileName, FileMode.Open, FileAccess.Read)
                    PicBCedula.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                End If
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnAbrirCedula_Click(sender As Object, e As EventArgs) Handles btnAbrirCedula.Click
        If TypeConnection.Text = 1 Then
            If lblRutaCedula.Text = "" Then
                MessageBox.Show("No se ha encontrado la cédula anexa para poder abrirla.", "Falta Anexar Cédula", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Desea abrir la cédula vinculada al registro?", "Abrir Identificacion Anexa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(lblRutaCedula.Text)
                End If
            End If
        End If
    End Sub

    Private Sub btnEliminarCedula_Click(sender As Object, e As EventArgs) Handles btnEliminarCedula.Click
        If TypeConnection.Text = 1 Then
            If lblRutaCedula.Text = "" Then
                MessageBox.Show("No existe cédula anexa al registro.", "No existe cédula", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Desea eliminar la cédula anexa al registro?", "Eliminar identificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    lblRutaCedula.Text = ""
                    ResetPicCedula()
                End If
            End If
        End If

    End Sub

    Private Sub btnCargarChat_Click(sender As Object, e As EventArgs) Handles btnCargarChat.Click
        Try
            If TypeConnection.Text = 1 Then
                Dim wFile As System.IO.FileStream
                Dim OfdRutaCedula As New OpenFileDialog

                OfdRutaCedula.RestoreDirectory = True
                OfdRutaCedula.Title = ("Seleccionar de imagen para el chat")
                OfdRutaCedula.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
                OfdRutaCedula.FileName = ""

                If OfdRutaCedula.ShowDialog = Windows.Forms.DialogResult.OK Then
                    lblChatFoto.Text = OfdRutaCedula.FileName
                    wFile = New FileStream(OfdRutaCedula.FileName, FileMode.Open, FileAccess.Read)
                    PicChat.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                End If
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnAbrirChat_Click(sender As Object, e As EventArgs) Handles btnAbrirChat.Click
        If TypeConnection.Text = 1 Then
            If lblChatFoto.Text = "" Then
                MessageBox.Show("No se ha encontrado la imagen para poder abrirla.", "No se encontró la imagen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Desea abrir la imagen registrada para el chat?", "Abrir Imagen Anexa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start(lblChatFoto.Text)
                End If
            End If
        End If
    End Sub

    Private Sub txtSeguroComplementario_Leave(sender As Object, e As EventArgs) Handles txtSeguroComplementario.Leave
        If txtSeguroComplementario.Text = "" Then
            txtSeguroComplementario.Text = CDbl(0).ToString("C")
        Else
            txtSeguroComplementario.Text = CDbl(txtSeguroComplementario.Text).ToString("C")
        End If
    End Sub

    Private Sub txtSeguroComplementario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSeguroComplementario.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtSeguroComplementario_Enter(sender As Object, e As EventArgs) Handles txtSeguroComplementario.Enter
        If txtSeguroComplementario.Text = "" Then
        Else
            txtSeguroComplementario.Text = CDbl(txtSeguroComplementario.Text)
        End If
    End Sub

    Private Sub btnEliminarChat_Click(sender As Object, e As EventArgs) Handles btnEliminarChat.Click
        If TypeConnection.Text = 1 Then
            If lblChatFoto.Text = "" Then
                MessageBox.Show("No existe imagen para el chat.", "No existe imagen", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Desea eliminar la imagen del chat anexa al registro?", "Eliminar Imagen del chat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    lblChatFoto.Text = ""
                    ResetPicChat()
                End If
            End If
        End If
    End Sub

    Private Sub btnProgramarVacaciones_Click(sender As Object, e As EventArgs) Handles btnProgramarVacaciones.Click
        If txtDiasVacaciones.Text = "" Then
            MessageBox.Show("No se ha cálculado la cantidad de días hábiles en la programación de las vacaciones.")
            Exit Sub

        ElseIf txtDiasVacaciones.Text = "0" Then
            MessageBox.Show("No se ha cálculado la cantidad de días hábiles en la programación de las vacaciones.")
            Exit Sub

        ElseIf txtTotalVacaciones.Text = "" Then
            MessageBox.Show("No se ha cálculado el monto total de las vacaciones en la programación de las vacaciones.")
            Exit Sub

        ElseIf txtTotalVacaciones.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("No se ha cálculado el monto total de las vacaciones en la programación de las vacaciones.")
            Exit Sub

        ElseIf dtpVacacionInicia.Value = dtpVacacionTermina.Value Then
            MessageBox.Show("La fecha de inicio de las vacaciones debe ser menor a la fecha de entrada.")
            Exit Sub

        End If

        If txtIDVacaciones.Text = "" Then
            If PermisosVacaciones(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea programar las vacaciones anuales de " & txtNombre.Text & " del " & dtpVacacionInicia.Value & " al " & dtpVacacionTermina.Value & "?", "Establecer período de vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Empleados_Vacaciones (IDEmpleado,Fecha,FechaSalida,FechaEntrada,DiasPagados,ConceptoVacaciones,MontoVacaciones,Adjunto,Nulo) VALUES ('" + txtIDEmpleado.Text + "','" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "', '" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "','" + txtDiasVacaciones.Text + "', '' , '" + CDbl(txtTotalVacaciones.Text).ToString + "','','0')"
                GuardarDatos()

                sqlQ = "UPDATE Empleados SET VacacionInicia='" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "',VacacionTermina='" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"
                GuardarDatos()

                Con.Open()
                cmd = New MySqlCommand("Select IDVacaciones from Empleados_Vacaciones where IDVacaciones= (Select Max(IDVacaciones) from Empleados_Vacaciones)", Con)
                txtIDVacaciones.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()

                txtIDVacaciones.Clear()
                txtDiasVacaciones.Clear()
                txtTotalVacaciones.Clear()
                Button1.Visible = True
                ConvertCurrents()

                FillVacaciones()
                MessageBox.Show("Las vacaciones han sido programadas satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)



            End If

        Else
            If PermisosVacaciones(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en la programación de las vacaciones seleccionada?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()

                sqlQ = "UPDATE Empleados_Vacaciones SET IDEmpleado='" + txtIDEmpleado.Text + "',FechaSalida='" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "',FechaEntrada='" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "',DiasPagados='" + txtDiasVacaciones.Text + "',ConceptoVacaciones='',MontoVacaciones='" + CDbl(txtTotalVacaciones.Text).ToString + "' WHERE IDVacaciones= '" + txtIDVacaciones.Text + "'"
                GuardarDatos()

                sqlQ = "UPDATE Empleados SET VacacionInicia='" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "',VacacionTermina='" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"
                GuardarDatos()

                ConvertCurrents()
                txtIDVacaciones.Clear()
                txtDiasVacaciones.Clear()
                txtTotalVacaciones.Clear()
                Button1.Visible = True
                FillVacaciones()

                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If


        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        btnCargarChat.PerformClick()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        btnAbrirChat.PerformClick()
    End Sub

    Private Sub TsPreaviso_Toggled(sender As Object, e As EventArgs) Handles TsPreaviso.Toggled
        CalcPrest()
    End Sub

    Private Sub TSCesantia_Toggled(sender As Object, e As EventArgs) Handles TSCesantia.Toggled
        CalcPrest()
    End Sub

    Private Sub TSVacaciones_Toggled(sender As Object, e As EventArgs) Handles TSVacaciones.Toggled
        CalcPrest()
    End Sub

    Private Sub dtpFechaSalida_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaSalida.ValueChanged
        CalcPrest()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtIDEmpleado.Text <> "" Then
            If txtIDVacaciones.Text = "" Then

                For Each rw As DataGridViewRow In DgvVacaciones.Rows
                    If CDate(rw.Cells(1).Value).Year = Today.Year Then
                        Dim Result As MsgBoxResult = MessageBox.Show("Ya se han generado vacaciones durante el período actual." & vbNewLine & vbNewLine & "Está seguro que desea programar otras vacaciones para el mismo empleado?", "Establecer período de vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                        If Result = MsgBoxResult.Yes Then
                            Exit For
                        Else
                            Exit Sub
                        End If
                    End If
                Next

                dtpVacacionTermina.Value = CalcDiasVacaciones(dtpVacacionInicia.Value)

                calcDifFechas(dtpFechaIngreso.Value, Today, arrTiempoCalculo)

                'Vacaciones
                Dim diasvacaciones As Integer = 0

                ' Calcular Preaviso
                Dim mesesPreaviso As Integer = ((arrTiempoCalculo(0) * 12) + arrTiempoCalculo(1))
                Dim diaspreaviso As Integer = 0
                Select Case (True)
                    Case (mesesPreaviso >= 12)
                        diaspreaviso = 28
                    Case (mesesPreaviso >= 6)
                        diaspreaviso = 14
                    Case (mesesPreaviso >= 3)
                        diaspreaviso = 7
                End Select



                If txtIDVacaciones.Text = "" Then
                    Select Case (True)
                        Case (mesesPreaviso >= 60)
                            diasvacaciones = 18
                            Exit Select
                        Case (mesesPreaviso >= 12)
                            diasvacaciones = 14
                            Exit Select
                        Case (mesesPreaviso >= 5)
                            diasvacaciones = mesesPreaviso + 1
                            Exit Select
                    End Select

                Else

                    Select Case (True)
                        Case (arrTiempoCalculo(1) > 11)
                            diasvacaciones = 12
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 10)
                            diasvacaciones = 11
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 9)
                            diasvacaciones = 10
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 8)
                            diasvacaciones = 9
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 7)
                            diasvacaciones = 8
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 6)
                            diasvacaciones = 7
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 5)
                            diasvacaciones = 6
                            Exit Select
                    End Select

                End If

                Dim salarioVacaciones As Double = 0
                Dim valorDiaVacaciones As Double = 0

                If (arrTiempoCalculo(0) > 0) Then
                    'Tomamos el valor para el dia de vacaciones cuando tenga el ano acumulado
                    valorDiaVacaciones = CDbl(txtSalario.Text) / 23.83
                    salarioVacaciones = diasvacaciones * valorDiaVacaciones

                ElseIf (arrTiempoCalculo(1) > 0) Then
                    'Tomamos el valor para el dia de vacaciones con el ultimo salario
                    valorDiaVacaciones = CDbl(txtSalario.Text) / 23.83
                    salarioVacaciones = diasvacaciones * valorDiaVacaciones
                Else
                    valorDiaVacaciones = CDbl(txtSalario.Text) / 23.83
                    salarioVacaciones = diasvacaciones * valorDiaVacaciones
                End If

                If (diasvacaciones > 0) Then
                    txtDiasVacaciones.Text = diasvacaciones
                    txtTotalVacaciones.Text = CDbl(salarioVacaciones).ToString("C")
                Else
                    txtDiasVacaciones.Text = ""
                    txtTotalVacaciones.Text = ""
                End If

            End If
        End If

    End Sub

    Private Sub txtTotalVacaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalVacaciones.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

        If (txtTotalVacaciones.Text.IndexOf(".") >= 0 And e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalVacaciones_Leave(sender As Object, e As EventArgs) Handles txtTotalVacaciones.Leave
        If txtTotalVacaciones.Text = "" Then
            txtTotalVacaciones.Text = 0
        Else
            txtTotalVacaciones.Text = CDbl(txtTotalVacaciones.Text).ToString("C")
        End If
    End Sub

    Private Sub txtTotalVacaciones_Enter(sender As Object, e As EventArgs) Handles txtTotalVacaciones.Enter
        If txtTotalVacaciones.Text = "" Then
        Else
            txtTotalVacaciones.Text = CDbl(txtTotalVacaciones.Text)
        End If
    End Sub

    Private Sub DgvVacaciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvVacaciones.CellDoubleClick
        If e.RowIndex >= 0 Then
            txtIDVacaciones.Text = DgvVacaciones.CurrentRow.Cells(0).Value
            dtpVacacionInicia.Value = CDate(DgvVacaciones.CurrentRow.Cells(1).Value)
            dtpVacacionTermina.Value = CDate(DgvVacaciones.CurrentRow.Cells(2).Value)
            txtDiasVacaciones.Text = DgvVacaciones.CurrentRow.Cells(3).Value
            txtTotalVacaciones.Text = DgvVacaciones.CurrentRow.Cells(5).Value
            Button1.Visible = False
        End If
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Try
            If txtNombre.Text = "" Then
                MessageBox.Show("El nombre del empleado se encuentra vacío. Escriba el nombre del empleado para procesar el registro.", "Escriba el nombre del empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 0
                txtNombre.Focus()
                Exit Sub
            ElseIf CbxGenero.Text = "" Then
                MessageBox.Show("Seleccione el género correspondiente al empleado.", "Seleccione el género", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 0
                CbxGenero.Focus()
                CbxGenero.DroppedDown = True
                Exit Sub
            ElseIf CbxProvincia.Text = "" Then
                MessageBox.Show("Seleccione la provincia correspondiente del cliente.", "Seleccione la provincia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 0
                CbxProvincia.Focus()
                CbxProvincia.DroppedDown = True
                Exit Sub
            ElseIf cbxMunicipio.Text = "" Then
                MessageBox.Show("Seleccione el municipio correspondiente al cliente.", "Seleccione el municipio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 0
                cbxMunicipio.Focus()
                cbxMunicipio.DroppedDown = True
                Exit Sub
            ElseIf txtIDSucursal.Text = "" Then
                MessageBox.Show("Seleccione la sucursal a la cual pertenece el empleado.", "Seleccionar Sucursal", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                btnSucursal.PerformClick()
                Exit Sub
            ElseIf cbxAlmacen.Text = "" Then
                MessageBox.Show("Seleccione el almacén correspondiente del empleado.", "Seleccionar Almacén", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                cbxAlmacen.Focus()
                cbxAlmacen.DroppedDown = True
                Exit Sub
            ElseIf txtIDNomina.Text = "" Then
                MessageBox.Show("Seleccione la nómina del empleado", "Seleccionar nómina", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                btnBuscarNomina.PerformClick()
                Exit Sub
            ElseIf txtIDDepartamento.Text = "" Then
                MessageBox.Show("Seleccione el cargo del empleado", "Seleccionar Cargo Departamental", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                btnBuscarCargo.PerformClick()
                Exit Sub
            ElseIf txtIDTanda.Text = "" Then
                MessageBox.Show("Seleccione la tanda del empleado", "Seleccionar Tanda", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                btnBuscarTanda.PerformClick()
                Exit Sub
            ElseIf txtIDArs.Text = "" Then
                MessageBox.Show("Seleccione la aseguradora de riesgos laborales del empleado.", "Seleccionar Ars", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                btn_buscarArs.PerformClick()
                Exit Sub
            ElseIf txtIDAfp.Text = "" Then
                MessageBox.Show("Seleccione la administradora de fondos de pensión del empleado.", "Seleccionar Afp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                btnBuscarAfp.PerformClick()
                Exit Sub
            ElseIf CbxPeriodoPago.Text = "" Then
                MessageBox.Show("Seleccione el período de pago del empleado.", "Seleccione la forma de pago del empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 1
                CbxPeriodoPago.Focus()
                CbxPeriodoPago.DroppedDown = True
                Exit Sub
            ElseIf CbxPrivilegios.Text = "" Or lblPrivilegio.Text = "" Then
                MessageBox.Show("Seleccione el tipo de privilegios del empleado.", "Seleccione los privilegios", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 4
                CbxPrivilegios.Focus()
                CbxPrivilegios.DroppedDown = True
                Exit Sub
            ElseIf dtpVacacionTermina.Value < dtpVacacionInicia.Value Then
                MessageBox.Show("La fecha final de las vacaciones debe ser mayor a la fecha de inicio.", "La fecha final debe ser mayor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                dtpVacacionTermina.Value = dtpVacacionInicia.Value
                Exit Sub
            ElseIf dtpVacacionInicia.Value > dtpVacacionTermina.Value Then
                MessageBox.Show("La fecha inicial de las vacaciones debe ser menor a la fecha de termino.", "La fecha inicial debe ser menor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                dtpVacacionInicia.Value = dtpVacacionTermina.Value
                Exit Sub
            ElseIf cbxEstadoChat.Text = "" Then
                MessageBox.Show("Seleccione un estado para mostrar en el chat del sistema.", "Seleccione estado en el chat", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TabCEmpleados.SelectedIndex = 4
                cbxEstadoChat.Focus()
                cbxEstadoChat.DroppedDown = True
                Exit Sub
            ElseIf NuevaEstructuracion = True Then
                If txtLogin.Text = "" Then
                    MessageBox.Show("Es necesario que establezca su cuenta de inicio para acceder al sistema. Por favor escriba el nombre de usuario que desea utilizar.", "Escriba su nombre de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    TabCEmpleados.SelectedIndex = 5
                    txtLogin.Focus()
                    Exit Sub
                ElseIf txtPassword.Text = "" Then
                    MessageBox.Show("La contraseña está en blanco. Por facor escriba la contraseña de su cuenta de inicio para continuar con el registro de la cuenta.", "Escriba la contraseña de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    TabCEmpleados.SelectedIndex = 5
                    txtPassword.Focus()
                    Exit Sub
                End If
            ElseIf txtLogin.Text <> "" Then
                If txtPassword.Text = "" Then
                    MessageBox.Show("Escriba la contraseña de su usuario para el acceso al sistema.", "Contraseña de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    TabCEmpleados.SelectedIndex = 5
                    txtPassword.Focus()
                    Exit Sub
                ElseIf Len(txtLogin.Text) < 5 And txtPassword.Text <> "" Then
                    MessageBox.Show("El nombre de usuario debe tener 4 o más caracteres.", "Nombre de Usuario Corto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    lblPassInfo.Text = "El nombre de usuario debe tener 4 o más caracteres."
                    lblPassInfo.ForeColor = Color.Red
                    TabCEmpleados.SelectedIndex = 5
                    txtLogin.Focus()
                    Exit Sub
                ElseIf Len(txtPassword.Text) < 6 And txtLogin.Text <> "" Then
                    MessageBox.Show("La contraseña debe tener 6 o más caracteres.", "Contraseña muy corta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    lblPassInfo.Text = "La contraseña debe tener 6 o más caracteres."
                    lblPassInfo.ForeColor = Color.Red
                    TabCEmpleados.SelectedIndex = 5
                    txtPassword.Focus()
                    Exit Sub
                    'ElseIf txtPassword.Text = txtConfirmacionPassword.Text And txtLogin.Text <> "" And txtCorreo.Text = "" Then
                    '    MessageBox.Show("Para crear una cuenta de acceso a Libregco es necesario asociar una cuenta de correo electrónica." & vbNewLine & vbNewLine & "Por favor ingrese una cuenta de correo para poder continuar.", "Ingrese Correo Electrónico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    '    TabCEmpleados.SelectedIndex = 0
                    '    txtCorreo.Focus()
                    '    Exit Sub
                End If
            ElseIf txtPassword.Text <> "" Then
                If txtLogin.Text = "" Then
                    MessageBox.Show("Escriba el nombre de usuario para el acceso al sistema.", "Nombre de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    TabCEmpleados.SelectedIndex = 5
                    txtLogin.Focus()
                    Exit Sub
                ElseIf txtPassword.Text <> "" And txtConfirmacionPassword.Text = "" Or txtPassword.Text <> txtConfirmacionPassword.Text Then
                    MessageBox.Show("Confirme la contraseña a ingresar para el acceso al sistema.", "Verificar Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    TabCEmpleados.SelectedIndex = 5
                    txtConfirmacionPassword.Focus()
                    Exit Sub
                    'ElseIf txtPassword.Text = txtConfirmacionPassword.Text And txtLogin.Text <> "" And txtCorreo.Text = "" Then
                    '    MessageBox.Show("Para crear una cuenta de acceso a Libregco es necesario asociar una cuenta de correo electrónica." & vbNewLine & vbNewLine & "Por favor ingrese una cuenta de correo para poder continuar.", "Ingrese Correo Electrónico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    '    TabCEmpleados.SelectedIndex = 0
                    '    txtCorreo.Focus()
                    '    Exit Sub
                End If
            ElseIf txtPasswordFactor.Text <> "" Then
                If txtPasswordFactor.Text <> txtPasswordFactorRep.Text Then
                    MessageBox.Show("La contraseña de 4 factores no coincide. Por favor vuelva a escribir la contraseña e intente volver a guardar el registro.", "Contraseña no coincide", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    TabCEmpleados.SelectedIndex = 5
                    txtPasswordFactor.Focus()
                    Exit Sub
                End If
            End If



            If txtLogin.Text <> "" Then
                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("Select IDEmpleado,Nombre,Login from Empleados where Login='" + txtLogin.Text + "' and IDEmpleado<>'" + txtIDEmpleado.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Empleados")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("Empleados")
                If Tabla.Rows.Count > 0 Then

                    If txtIDEmpleado.Text = "" Then
                        MessageBox.Show("El nombre de usuario introducido ya esta siendo utilizado por otro empleado.", "El usuario esta siendo utilizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        lblPassInfo.ForeColor = Color.Red
                        txtLogin.SelectAll()
                        Exit Sub
                    Else
                        If (Tabla.Rows(0).Item("IDEmpleado")) = txtIDEmpleado.Text Then
                        Else
                            MessageBox.Show("El nombre de usuario introducido ya esta siendo utilizado por otro empleado.", "El usuario esta siendo utilizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            lblPassInfo.ForeColor = Color.Red
                            txtLogin.SelectAll()
                            Exit Sub
                        End If
                    End If
                End If
            End If

            If txtIDEmpleado.Text = "" Then 'Si no hay un cliente seleccionado
                If Permisos(1) = 0 Then
                    MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo registro a la base de datos?", "Guardar Nuevo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    sqlQ = "INSERT INTO Empleados (Nombre,Apodo,IDNacionalidad,Cedula,IDGenero,FechaNacimiento,IDProvincia,IDMunicipio,Direccion,TelefonoPersonal,TelefonoHogar,CorreoElectronico,CorreoVerificado,RutaFoto,IDSucursal,IDAlmacen,IDTipoNomina,Salario,Cotizable,IDCargo,Puesto,IDPeriodoPago,IDTanda,IDArs,IDAfp,Carnet,FechaIngreso,CuentaBancaria,CuotaPrestamo,CuotaCuenta,ConsumoFlota,IDPrivilegios,RutaCedula,Login,Password,FechaPassword,Status,Balance,Alertas,Conectado,HabilitarNomina,CobrarTss,CobrarISR,IDChatStatus,ImagenChat,VacacionInicia,VacacionTermina,Nulo,FactorNumerico,ColorMode,MostrarenTope,HabilitarNotificaciones,MostrarContenido,MostrarConsejos,BloqueoInactividad,SeguroComplementario,Memos,NotificacionStart,AgendaFilePath,ClaveVerificacion,Disponible,GrayPictureFile,EsVendedor,EsCobrador) VALUES ('" + txtNombre.Text + "','" + txtApodo.Text + "', '" + lblNacionalidad.Text + "','" + txtCedula.Text + "', '" + lblGenero.Text + "', '" + txtFechaNacimiento.Value.ToString("yyyy-MM-dd") + "','" + lblIDProvincia.Text + "', '" + lblIDMunicipio.Text + "','" + txtDireccion.Text + "','" + txtTelefonoPersonal.Text + "','" + txtTelefonoHogar.Text + "','" + txtCorreo.Text + "',0, '" + Replace(lblRutaFoto.Text, "\", "\\") + "','" + txtIDSucursal.Text + "','" + lblIDAlmacen.Text + "','" + txtIDNomina.Text + "','" + txtSalario.Text + "','" + txtCotizable.Text + "', '" + txtIDDepartamento.Text + "','" + txtPuesto.Text + "','" + lblPeriodoPago.Text + "', '" + txtIDTanda.Text + "','" + txtIDArs.Text + "','" + txtIDAfp.Text + "','" + txtCarnet.Text + "','" + dtpFechaIngreso.Value.ToString("yyyy-MM-dd") + "', '" + txtCuentaBancaria.Text + "', '" + txtCuotaPrestamo.Text + "','" + txtCuotaCuenta.Text + "', '" + txtConsFlota.Text + "','" + lblPrivilegio.Text + "', '" + Replace(lblRutaCedula.Text, "\", "\\") + "', '" + txtLogin.Text + "', '" + txtPassword.Text + "','" + lblFechaPassword.Text + "',0,0,'" + lblAlertas.Text + "',0,'" + lblHabilitarNomina.Text + "','" + lblChkCobrarTss.Text + "','" + lblChkCobrarISR.Text + "','" + lblIDStatusChat.Text + "','" + Replace(lblChatFoto.Text, "/", "//") + "','" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "','" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "','" + lblNulo.Text + "','" + txtPasswordFactor.Text + "',1,1,1,1,1,1,'" + txtSeguroComplementario.Text + "','','1,1,1,1,1,1','','',0,'','" + Convert.ToInt16(chkVendedor.CheckState).ToString + "','" + Convert.ToInt16(chkCobrador.CheckState).ToString + "')"
                    GuardarDatos()
                    UltEmpleado()
                    MoverFichero()
                    GuardarDeducciones()
                    ConvertCurrents()
                    MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Else
                If Permisos(2) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    sqlQ = "UPDATE Empleados SET Nombre='" + txtNombre.Text + "',Apodo='" + txtApodo.Text + "',IDNacionalidad='" + lblNacionalidad.Text + "',Cedula='" + txtCedula.Text + "',IDGenero='" + lblGenero.Text + "',FechaNacimiento='" + txtFechaNacimiento.Value.ToString("yyyy-MM-dd") + "',IDProvincia='" + lblIDProvincia.Text + "',IDMunicipio='" + lblIDMunicipio.Text + "',Direccion='" + txtDireccion.Text + "',TelefonoPersonal='" + txtTelefonoPersonal.Text + "',TelefonoHogar='" + txtTelefonoHogar.Text + "',CorreoElectronico='" + txtCorreo.Text + "',RutaFoto='" + Replace(lblRutaFoto.Text, "\", "\\") + "',IDSucursal='" + txtIDSucursal.Text + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDTipoNomina='" + txtIDNomina.Text + "',Salario='" + txtSalario.Text + "',Cotizable='" + txtCotizable.Text + "',IDCargo='" + txtIDDepartamento.Text + "',Puesto='" + txtPuesto.Text + "',IDPeriodoPago='" + lblPeriodoPago.Text + "',IDTanda='" + txtIDTanda.Text + "',IDArs='" + txtIDArs.Text + "',IDAfp='" + txtIDAfp.Text + "',Carnet='" + txtCarnet.Text + "',FechaIngreso='" + dtpFechaIngreso.Value.ToString("yyyy-MM-dd") + "',CuentaBancaria='" + txtCuentaBancaria.Text + "',CuotaPrestamo='" + txtCuotaPrestamo.Text + "',CuotaCuenta='" + txtCuotaCuenta.Text + "',ConsumoFlota='" + txtConsFlota.Text + "',IDPrivilegios='" + lblPrivilegio.Text + "',RutaCedula='" + Replace(lblRutaCedula.Text, "\", "\\") + "',Login='" + txtLogin.Text + "',Password='" + txtPassword.Text + "',FechaPassword='" + lblFechaPassword.Text + "',Alertas='" + lblAlertas.Text + "',HabilitarNomina='" + lblHabilitarNomina.Text + "',CobrarTss='" + lblChkCobrarTss.Text + "',CobrarIsr='" + lblChkCobrarISR.Text + "',IDChatStatus='" + lblIDStatusChat.Text + "',ImagenChat='" + Replace(lblChatFoto.Text, "\", "\\") + "',VacacionInicia='" + dtpVacacionInicia.Value.ToString("yyyy-MM-dd") + "',VacacionTermina='" + dtpVacacionTermina.Value.ToString("yyyy-MM-dd") + "',Nulo='" + lblNulo.Text + "',FactorNumerico='" + txtPasswordFactor.Text + "',SeguroComplementario='" + txtSeguroComplementario.Text + "',EsVendedor='" + Convert.ToInt16(chkVendedor.CheckState).ToString + "',EsCobrador='" + Convert.ToInt16(chkCobrador.CheckState).ToString + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"
                    GuardarDatos()
                    MoverFichero()
                    GuardarDeducciones()
                    ConvertCurrents()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtNombre_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNombre.Validating
        txtNombre.Text = txtNombre.Text.Replace(",", "").Replace("'", "")
    End Sub

    Private Sub txtCotizable_TextChanged(sender As Object, e As EventArgs) Handles txtCotizable.TextChanged
        If txtCotizable.Text = "" Then
            txtCotizable.Text = 0
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789áéíóú "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TSNavidad_Toggled(sender As Object, e As EventArgs) Handles TSNavidad.Toggled
        CalcPrest()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        btnEliminarChat.PerformClick()
    End Sub

    Private Sub txtIDSucursal_Leave(sender As Object, e As EventArgs) Handles txtIDSucursal.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Sucursal from Sucursal Where IDSucursal='" + txtIDSucursal.Text + "'", Con)
        txtSucursal.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtSucursal.Text = "" Then txtIDSucursal.Clear()
    End Sub

    Private Sub txtIDNomina_Leave(sender As Object, e As EventArgs) Handles txtIDNomina.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM tiponomina Where IDTipoNomina='" + txtIDNomina.Text + "'", ConLibregco)
        txtTipoNomina.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtTipoNomina.Text = "" Then txtIDNomina.Clear()
    End Sub

    Private Sub txtIDDepartamento_Leave(sender As Object, e As EventArgs) Handles txtIDDepartamento.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Cargo FROM cargosemp where IDCargo='" + txtIDDepartamento.Text + "'", ConLibregco)
        txtDepartamento.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtDepartamento.Text = "" Then txtIDDepartamento.Clear()
    End Sub

    Private Sub txtIDTanda_Leave(sender As Object, e As EventArgs) Handles txtIDTanda.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM tandas where IDTanda='" + txtIDTanda.Text + "'", ConLibregco)
        txtTanda.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtTanda.Text = "" Then txtIDTanda.Clear()
    End Sub

    Private Sub txtIDArs_Leave(sender As Object, e As EventArgs) Handles txtIDArs.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM ars where IDArs='" + txtIDArs.Text + "'", ConLibregco)
        txtArs.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtArs.Text = "" Then txtIDArs.Clear()
    End Sub

    Private Sub txtIDAfp_Leave(sender As Object, e As EventArgs) Handles txtIDAfp.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM afp where IDAfp='" + txtIDAfp.Text + "'", ConLibregco)
        txtAfp.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtAfp.Text = "" Then txtIDAfp.Clear()
    End Sub

    Private Sub txtCotizable_Leave(sender As Object, e As EventArgs) Handles txtCotizable.Leave
        If txtCotizable.Text = "" Then
            txtCotizable.Text = (0).ToString("C")
        Else
            txtCotizable.Text = CDbl(txtCotizable.Text).ToString("C")
        End If
    End Sub

    Private Sub txtCotizable_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCotizable.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCotizable_Enter(sender As Object, e As EventArgs) Handles txtCotizable.Enter
        If txtCotizable.Text = "" Then
        Else
            txtCotizable.Text = CDbl(txtCotizable.Text)
        End If
    End Sub

    Private Sub txtPasswordFactor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPasswordFactor.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtPasswordFactorRep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPasswordFactorRep.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtPasswordFactorRep_Leave(sender As Object, e As EventArgs) Handles txtPasswordFactorRep.Leave
        If txtPasswordFactor.Text <> "" Then
            If txtPasswordFactor.Text <> txtPasswordFactorRep.Text Then
                lblMensajeFactores.ForeColor = Color.Red
                lblMensajeFactores.Text = "La contraseña de factor no coincide."
                txtPasswordFactor.Text = ""
                txtPasswordFactorRep.Text = ""
                txtPasswordFactor.Focus()
            Else
                lblMensajeFactores.Text = ""
                lblMensajeFactores.ForeColor = Color.Black
            End If
        End If
        
    End Sub

    Private Sub txtPasswordFactor_Leave(sender As Object, e As EventArgs) Handles txtPasswordFactor.Leave
        If txtPasswordFactor.Text <> "" Then
            If txtPasswordFactor.Text.Length < 4 Then
                MessageBox.Show("Por favor escriba una contraseña de 4 dígitos.", "Faltan " & 4 - CInt(txtPasswordFactor.Text.Length) & " dígito(s)", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtPasswordFactor.Focus()
                txtPasswordFactor.SelectAll()
                Exit Sub
            Else
                lblMensajeFactores.Text = "Vuelva a repetir la misma contraseña"
                lblMensajeFactores.ForeColor = SystemColors.Highlight
            End If
        End If

    End Sub

    Sub CalcPrest()
        If TabCEmpleados.SelectedIndex = 3 Then
            Dim TiempoLaborado(2) As Integer

            DgvMensualidades.Rows.Clear()


            calcDifFechas(dtpFechaIngreso.Value, Today, arrTiempoCalculo)
            calcDifFechas(dtpFechaIngreso.Value, Today, TiempoLaborado)

            Dim MesesdeNomina As Integer = 1

            If arrTiempoCalculo(0) = 0 Then
                MesesdeNomina = arrTiempoCalculo(1)
            Else
                MesesdeNomina = 12
            End If

            Dim StartDate, FinalDate As Date
            Dim DsTemp As New DataSet

            ConLibregco.Open()

            For i As Integer = MesesdeNomina To 1 Step -1
                DsTemp.Clear()

                StartDate = DateSerial(Today.Year, Today.Month, 1).AddMonths(-i)
                FinalDate = StartDate.AddMonths(1).AddDays(-1)


                cmd = New MySqlCommand("SELECT Fecha,coalesce(sum(NominaDetalle.Bruto),0) as Bruto,coalesce(sum(if(NominaDetalle.Deducciones>0,NominaDetalle.Deducciones,0)),0) as Comisiones,coalesce(sum((nominaDetalle.Bruto+if(NominaDetalle.Deducciones>0,NominaDetalle.Deducciones,0))),0) as Total  FROM" & SysName.Text & "nominadetalle inner join" & SysName.Text & "nomina on nominadetalle.idnomina=nomina.idnomina where IDempleado='" + txtIDEmpleado.Text + "' and Fecha Between '" + StartDate.ToString("yyyy-MM-dd") + "' and '" + FinalDate.ToString("yyyy-MM-dd") + "' and Nomina.Nulo=0", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "Nomina")
                Dim Tabla As DataTable = DsTemp.Tables("Nomina")

                If Tabla.Rows.Count > 0 Then
                    If CDbl(Tabla.Rows(0).Item("Total")) > 0 Then
                        DgvMensualidades.Rows.Add(DgvMensualidades.Rows.Count + 1, MonthName(CDate(Convert.ToString(Tabla.Rows(0).Item("Fecha"))).Month, True) & " - " & CDate(Convert.ToString(Tabla.Rows(0).Item("Fecha"))).Year, CDbl(Tabla.Rows(0).Item("Bruto")).ToString("C"), CDbl(Tabla.Rows(0).Item("Comisiones")).ToString("C"), CDbl(Tabla.Rows(0).Item("Total")).ToString("C"))
                    End If
                End If

            Next

            ConLibregco.Close()

            If arrTiempoCalculo(0) = 0 Then
                If arrTiempoCalculo(1) <> DgvMensualidades.Rows.Count Then
                    MessageBox.Show("No es posible establecer los derechos adquiridos a través de este método ya que la antiguedad del empleado excede la antiguedad de los registros de nómina." & vbNewLine & vbNewLine & "Utilice la herramienta en el módulo Nómina->Procesos->Préstaciones Laborales", "No es posible verificación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If



            Dim Mensaje As String = ""

                If TiempoLaborado(0) > 0 Then
                    Mensaje += TiempoLaborado(0) & If(TiempoLaborado(0) > 1, " años", " año")

                    If TiempoLaborado(1) > 0 Then

                        If TiempoLaborado(2) > 0 Then
                            Mensaje += ", " & TiempoLaborado(1) & If(TiempoLaborado(1) > 1, " meses", " mes")
                            Mensaje += " y " & TiempoLaborado(2) & If(TiempoLaborado(2) > 1, " días", " día")
                        Else

                            Mensaje += " y " & TiempoLaborado(1) & If(TiempoLaborado(1) > 1, " meses", " mes")

                        End If


                    ElseIf TiempoLaborado(2) > 0 Then
                        Mensaje += " y " & TiempoLaborado(2) & If(TiempoLaborado(2) > 1, " días", " día")
                    End If

                ElseIf TiempoLaborado(1) > 0 Then
                    If TiempoLaborado(2) > 0 Then
                        Mensaje += TiempoLaborado(1) & If(TiempoLaborado(1) > 1, " meses", " mes")
                        Mensaje += " y " & TiempoLaborado(2) & If(TiempoLaborado(2) > 1, " días", " día")

                    Else

                        Mensaje += TiempoLaborado(1) & If(TiempoLaborado(1) > 1, " meses", " mes")
                    End If

                ElseIf TiempoLaborado(2) > 0 Then
                    Mensaje += TiempoLaborado(2) & If(TiempoLaborado(2) > 1, " días", " día")
                End If

                txtTiempoLaborado.Text = Mensaje

                '''''''''''''''''''''''''''''''''''''''



                If DgvMensualidades.Rows.Count > 0 Then
                    Dim SueldoAcumulado As Double = 0
                    Dim promediodiario As Double = 0


                    For Each row As DataGridViewRow In DgvMensualidades.Rows
                        SueldoAcumulado += CDbl(row.Cells(4).Value)
                    Next

                    txtSumaSalarios.Text = SueldoAcumulado.ToString("C")

                    Dim Coeficiente As Double = 1

                    Dim promedioMensual As Double = 0
                    If arrTiempoCalculo(0) > 0 Then
                        promedioMensual = (SueldoAcumulado / 12) * Coeficiente

                    ElseIf arrTiempoCalculo(1) > 0 Then
                        promedioMensual = (SueldoAcumulado / arrTiempoCalculo(1)) * Coeficiente

                    Else
                        promedioMensual = SueldoAcumulado * Coeficiente
                    End If

                    txtSalarioPromedioMensual.Text = promedioMensual.ToString("C")
                    promediodiario = (promedioMensual / 23.83)
                    txtSalarioPromedioDiario.Text = (promediodiario).ToString("C")

                    ' Calcular Preaviso
                    Dim mesesPreaviso As Integer = ((arrTiempoCalculo(0) * 12) + arrTiempoCalculo(1))
                    Dim diaspreaviso As Integer = 0
                    Dim totalpreaviso As Double = 0

                    Select Case (True)
                        Case (mesesPreaviso >= 12)
                            diaspreaviso = 28
                        Case (mesesPreaviso >= 6)
                            diaspreaviso = 14
                        Case (mesesPreaviso >= 3)
                            diaspreaviso = 7
                    End Select

                    totalpreaviso = (CDbl(promedioMensual / 23.83)) * diaspreaviso

                    If TsPreaviso.IsOn = True Then
                        txtPreaviso.Text = CDbl(0).ToString("C")
                        txtPreaviso.Tag = CDbl(0)
                    Else

                        txtPreaviso.Text = CDbl(totalpreaviso).ToString("C") & " (" & diaspreaviso & ") " & If(diaspreaviso > 1, "días", "día")
                        txtPreaviso.Tag = CDbl(totalpreaviso)
                    End If


                    ' Cesantia
                    Dim fechaingreso(2) As Integer

                    fechaingreso(0) = dtpFechaIngreso.Value.Day
                    fechaingreso(1) = dtpFechaIngreso.Value.Month
                    fechaingreso(2) = dtpFechaIngreso.Value.Year

                    Dim fechasalida(2) As Integer
                    fechasalida(0) = dtpFechaSalida.Value.Day
                    fechasalida(1) = dtpFechaSalida.Value.Month
                    fechasalida(2) = dtpFechaSalida.Value.Year

                    Dim fecha1 As Date = New Date(fechaingreso(2), fechaingreso(1), fechaingreso(0))
                    Dim fecha2 As Date = New Date(fechasalida(2), fechasalida(1), fechasalida(0))

                    Dim d1 As Date = New Date(1992, 5, 17)
                    Dim d2 As Date = New Date(fechaingreso(2), fechaingreso(1), fechaingreso(0))

                    Dim TiempoAntesCodigo(3) As Integer
                    Dim TiempoDespuesCodigo(3) As Integer
                    Dim iDiasCensantiaAnterior = 0

                    If d1 > d2 Then
                        calcDifFechas(d2, d1, TiempoAntesCodigo)
                        d2 = New Date(fechasalida(2), fechasalida(1), fechasalida(0))

                        calcDifFechas(d1, d2, TiempoDespuesCodigo)

                        If (TiempoAntesCodigo(0) > 0) Then
                            iDiasCensantiaAnterior = TiempoAntesCodigo(0) * 15
                        End If

                        ''Ajuste en los meses despues del codigo con la suma de los dias antes y despues
                        If ((TiempoAntesCodigo(2) + TiempoDespuesCodigo(2)) >= 30) Then
                            TiempoDespuesCodigo(1) = TiempoDespuesCodigo(1) + 1
                        End If

                        'Ajuste en los anos despues del codigo con la suma de los anos antes y despues

                        If ((TiempoDespuesCodigo(1) + TiempoAntesCodigo(1)) >= 12) Then
                            TiempoDespuesCodigo(1) = TiempoDespuesCodigo(1) + TiempoAntesCodigo(1) - 12
                            TiempoDespuesCodigo(0) = TiempoDespuesCodigo(0) + 1
                        End If

                    Else

                        TiempoDespuesCodigo(0) = arrTiempoCalculo(0)
                        TiempoDespuesCodigo(1) = arrTiempoCalculo(1)
                        TiempoDespuesCodigo(2) = arrTiempoCalculo(2)
                    End If

                    Dim iDiasCesantiaNueva As Integer = 0

                    If (TiempoDespuesCodigo(0) >= 5) Then
                        iDiasCesantiaNueva = iDiasCesantiaNueva + (23 * TiempoDespuesCodigo(0))
                    ElseIf (TiempoDespuesCodigo(0) >= 1) Then
                        iDiasCesantiaNueva = iDiasCesantiaNueva + (21 * TiempoDespuesCodigo(0))
                    End If

                    If (TiempoDespuesCodigo(1) >= 6) Then
                        iDiasCesantiaNueva = (iDiasCesantiaNueva + 13)
                    ElseIf (TiempoDespuesCodigo(1) >= 3) Then
                        iDiasCesantiaNueva = (iDiasCesantiaNueva + 6)
                    End If

                    Dim cCesantiaAnterior As Double = (iDiasCensantiaAnterior * promediodiario * 100) / 100
                    Dim cCesantiaNueva As Double = (iDiasCesantiaNueva * promediodiario * 100) / 100

                    If TSCesantia.IsOn = False Then
                        txtCensantiaAntes.Text = CDbl(0).ToString("C")
                        txtCensantiaAntes.Tag = 0
                        txtCesantiaNuevo.Text = CDbl(0).ToString("C")
                        txtCesantiaNuevo.Tag = 0
                        cCesantiaAnterior = 0
                        cCesantiaAnterior = 0

                    Else
                        If (iDiasCensantiaAnterior > 0) Then
                            txtCensantiaAntes.Text = CDbl(cCesantiaAnterior).ToString("C") & " (" & iDiasCensantiaAnterior & " días)"
                            txtCensantiaAntes.Tag = cCesantiaAnterior
                        Else
                            txtCensantiaAntes.Text = CDbl(0).ToString("C") & " (" & iDiasCensantiaAnterior & " días)"
                            txtCensantiaAntes.Tag = 0
                        End If


                        If (iDiasCesantiaNueva > 0) Then
                            txtCesantiaNuevo.Text = CDbl(cCesantiaNueva).ToString("C") & " (" & iDiasCesantiaNueva & " días)"
                            txtCesantiaNuevo.Tag = cCesantiaNueva
                        Else
                            txtCesantiaNuevo.Text = CDbl(0).ToString("C")
                            txtCesantiaNuevo.Tag = 0
                        End If
                    End If


                    'Vacaciones
                    Dim diasvacaciones As Integer = 0

                    If TSVacaciones.IsOn = False Then
                        Select Case (True)
                            Case (mesesPreaviso >= 60)
                                diasvacaciones = 18
                                Exit Select
                            Case (mesesPreaviso >= 12)
                                diasvacaciones = 14
                                Exit Select
                            Case (mesesPreaviso >= 5)
                                diasvacaciones = mesesPreaviso + 1
                                Exit Select
                        End Select

                    Else

                        Select Case (True)
                            Case (arrTiempoCalculo(1) > 11)
                                diasvacaciones = 12
                                Exit Select
                            Case (arrTiempoCalculo(1) >= 10)
                                diasvacaciones = 11
                                Exit Select
                            Case (arrTiempoCalculo(1) >= 9)
                                diasvacaciones = 10
                                Exit Select
                            Case (arrTiempoCalculo(1) >= 8)
                                diasvacaciones = 9
                                Exit Select
                            Case (arrTiempoCalculo(1) >= 7)
                                diasvacaciones = 8
                                Exit Select
                            Case (arrTiempoCalculo(1) >= 6)
                                diasvacaciones = 7
                                Exit Select
                            Case (arrTiempoCalculo(1) >= 5)
                                diasvacaciones = 6
                                Exit Select
                        End Select

                    End If

                Dim salarioVacaciones As Double = 0
                Dim valorDiaVacaciones As Double = 0

                    If (arrTiempoCalculo(0) > 0) Then
                        'Tomamos el valor para el dia de vacaciones cuando tenga el ano acumulado
                        valorDiaVacaciones = CDbl(DgvMensualidades.Rows(11).Cells(4).Value) / 23.83
                        salarioVacaciones = diasvacaciones * valorDiaVacaciones

                    ElseIf (arrTiempoCalculo(1) > 0) Then
                        'Tomamos el valor para el dia de vacaciones con el ultimo salario
                        valorDiaVacaciones = CDbl(DgvMensualidades.Rows(arrTiempoCalculo(1) - 1).Cells(4).Value) / 23.83
                        salarioVacaciones = diasvacaciones * valorDiaVacaciones

                    Else

                        valorDiaVacaciones = CDbl(DgvMensualidades.Rows(0).Cells(4).Value) / 23.83
                        salarioVacaciones = diasvacaciones * valorDiaVacaciones

                    End If

                    If (diasvacaciones > 0) Then
                        txtVacaciones.Text = CDbl(salarioVacaciones).ToString("C") & " (" & diasvacaciones & If(diasvacaciones > 1, " días", " día") & ")"
                        txtVacaciones.Tag = salarioVacaciones

                    Else
                        txtVacaciones.Text = CDbl(0).ToString("C")
                        txtVacaciones.Tag = 0
                    End If

                If txtVacaciones.Text = "" Then
                    txtVacaciones.Text = CDbl(0).ToString("C")
                    txtVacaciones.Tag = 0
                End If

                'Salario de navidad
                Dim SalarioNavidad As Double = 0

                    If TSNavidad.IsOn = False Then
                        txtNavidad.Text = CDbl(0).ToString("C")
                        txtNavidad.Tag = 0

                    Else

                        Dim arrTiempoNavidad(2) As Integer
                        Dim dd1 As New Date
                        If dtpFechaIngreso.Value > DateSerial(Today.Year, 1, 1) Then
                            dd1 = dtpFechaIngreso.Value
                        Else
                            dd1 = DateSerial(Today.Year, 1, 1)
                        End If

                        Dim dd2 As New Date
                        dd2 = dtpFechaSalida.Value

                        calcDifFechas(dd1, dd2, arrTiempoNavidad)

                        Dim totaldiasmes As Integer = diasMes(fechasalida(1), fechasalida(2))

                        If (arrTiempoNavidad(0) > 0) Then
                            SalarioNavidad = promedioMensual

                        Else
                            SalarioNavidad = ((arrTiempoNavidad(1) * promedioMensual) + (((arrTiempoNavidad(2) * 23.83) / totaldiasmes) * promediodiario)) / 12
                        End If

                        'Mostrar el tiempo de navidad
                        Dim tiempoNavidad As String = ""

                        If (arrTiempoNavidad(0) > 0) Then
                            tiempoNavidad = " (1 Año)"

                        ElseIf (arrTiempoNavidad(1) > 0) Then
                            tiempoNavidad = " ("
                            tiempoNavidad += arrTiempoNavidad(1) & If(arrTiempoNavidad(1) > 1, " meses", " mes")

                            If (arrTiempoNavidad(2) > 0) Then
                                tiempoNavidad += " y " & arrTiempoNavidad(2) & If(arrTiempoNavidad(2) > 1, " días", " día")
                            End If

                            tiempoNavidad += ")"

                        Else

                            tiempoNavidad = " " & arrTiempoNavidad(2) & If(arrTiempoNavidad(2) > 1, " días", " día")
                        End If

                        txtNavidad.Text = CDbl(SalarioNavidad).ToString("C") & tiempoNavidad
                        txtNavidad.Tag = SalarioNavidad

                    End If

                    txtTotalRecibir.Text = (CDbl(txtPreaviso.Tag) + CDbl(txtCensantiaAntes.Tag) + CDbl(txtCesantiaNuevo.Tag) + CDbl(txtVacaciones.Tag) + CDbl(txtNavidad.Tag)).ToString("C")

                End If

            End If

    End Sub

    Private Function diasMes(ByVal mes As Integer, ByVal anno As Integer) As Integer
        Select Case (mes)
            Case 1, 3, 5, 7, 8, 10, 12
                Return 31

            Case 2
                If Date.IsLeapYear(anno) Then
                    Return 29
                Else
                    Return 28
                End If

            Case Else
                Return 30
        End Select

    End Function
End Class
