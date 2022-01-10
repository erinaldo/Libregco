Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_mant_suplidor

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDProvincia, lblIDMunicipio, lblTipoIdentificacion, lblDesactivar As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList

    Private Sub frm_mant_sup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        CargarEmpresa()
        ActualizarDatos()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
    PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub GetFilesfromFolder()
        Try
            DgvArchivos.Rows.Clear()

            Dim DirInfo As New DirectoryInfo("\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & txtIDSuplidor.Text)
            'Get a reference to each file in that directory.
            Dim fiArr As FileInfo() = DirInfo.GetFiles()
            'Display the names of the files.
            Dim FInfo As FileInfo


            For Each FInfo In fiArr
                DgvArchivos.Rows.Add(FInfo.FullName, FInfo.LastWriteTime, Math.Round((FInfo.Length / 1024), 0), Image.FromFile(FInfo.FullName))
            Next FInfo

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub ActualizarDatos()
        FillTipoIdentificacion()
        FillProvincia()
        txtSuplidor.Focus()
        CargarChecks()
        txtFechaRegistro.Text = Today.ToString("yyyy-MM-dd")
        txtLimite.Text = CDbl(0.0).ToString("C")
        txtBalance.Text = CDbl(0).ToString("C")
    End Sub


    Private Sub SetIDTipoIdentificacion()

        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoIdentificacion,Mascara FROM TipoIdentificacion WHERE Descripcion= '" + cbxTipoIdentificacion.SelectedItem + "'", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoIdentificacion")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoIdentificacion")

        lblTipoIdentificacion.Text = (Tabla.Rows(0).Item("IDTipoIdentificacion"))
        txtRnc.Mask = (Tabla.Rows(0).Item("Mascara"))
        txtRnc.Focus()


    End Sub

    Private Sub FillTipoIdentificacion()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM TipoIdentificacion ORDER BY Descripcion asc", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoIdentificacion")
        cbxTipoIdentificacion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoIdentificacion")

        For Each Fila As DataRow In Tabla.Rows
            cbxTipoIdentificacion.Items.Add(Fila.Item("Descripcion"))
        Next

    End Sub

    Private Sub FillProvincia()

        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Provincia FROM Provincias ORDER BY Provincia ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Provincias")
        cbxProvincia.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Provincias")

        For Each Fila As DataRow In Tabla.Rows
            cbxProvincia.Items.Add(Fila.Item("Provincia"))
        Next
        cbxProvincia.DropDownStyle = ComboBoxStyle.DropDownList

    End Sub

    Private Sub FillMunicipio()

        SetIDProvincia()

        Ds1.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Municipio FROM Municipios WHERE IDProvincia= '" + lblIDProvincia.Text + "' ORDER BY Municipio ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Municipios")
        cbxMunicipio.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds1.Tables("Municipios")
        For Each Fila As DataRow In Tabla.Rows
            cbxMunicipio.Items.Add(Fila.Item("Municipio"))
        Next
        cbxMunicipio.DropDownStyle = ComboBoxStyle.DropDownList


    End Sub

    Private Sub SetIDMunicipio()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDMunicipio FROM Municipios WHERE Municipio= '" + cbxMunicipio.SelectedItem + "' Order By Municipio ASC", ConLibregco)
        lblIDMunicipio.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub SetIDProvincia()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDProvincia FROM Provincias WHERE Provincia= '" + cbxProvincia.SelectedItem + "' Order By Provincia ASC", ConLibregco)
        lblIDProvincia.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub cbxProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProvincia.SelectedIndexChanged
        FillMunicipio()
    End Sub

    Private Sub cbxMunicipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMunicipio.SelectedIndexChanged
        SetIDMunicipio()
    End Sub

    Private Sub ChkDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDesactivar.CheckedChanged
        If ChkDesactivar.Checked = True Then
            lblDesactivar.Text = 1
            InhabilitarSuplidor()
        Else
            lblDesactivar.Text = 0
            HabilitarSuplidor()
        End If
    End Sub

    Private Sub HabilitarSuplidor()
        TbSuplidor.Enabled = True
        txtSuplidor.Enabled = True
        txtRnc.Enabled = True
        cbxTipoIdentificacion.Enabled = True
    End Sub

    Private Sub InhabilitarSuplidor()
        TbSuplidor.Enabled = False
        txtSuplidor.Enabled = False
        txtRnc.Enabled = False
        cbxTipoIdentificacion.Enabled = False
    End Sub

    Private Sub LimpiarDatosSuplidor()
        txtIDSuplidor.Clear()
        txtSuplidor.Clear()
        txtRnc.Mask = ""
        cbxTipoIdentificacion.Items.Clear()
        txtBeneficiario.Clear()
        txtRnc.Clear()
        cbxProvincia.Items.Clear()
        cbxMunicipio.Items.Clear()
        txtDireccion.Clear()
        txtTelefono.Clear()
        txtFax.Clear()
        txtRepresentante.Clear()
        txtTelRep.Clear()
        txtCorreo.Clear()
        txtWeb.Clear()
        txtIDTipoSuplidor.Clear()
        txtTipoSuplidor.Clear()
        txtIDNcf.Clear()
        txtNCF.Clear()
        txtIDTipoGasto.Clear()
        txtTipoGasto.Clear()
        txtIDCondicion.Clear()
        txtCondicion.Clear()
        txtLimite.Text = 0
        txtBalance.Clear()
        txtFechaRegistro.Clear()
        ChkDesactivar.Checked = False
        LimpiarLabels()
        DgvArchivos.Rows.Clear()
        txtSuplidor.Focus()
    End Sub

    Private Sub LimpiarLabels()
        lblDesactivar.Text = 0
        lblIDProvincia.Text = 0
        lblIDMunicipio.Text = 0
    End Sub

    Private Sub CargarChecks()
        lblDesactivar.Text = 0
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
        End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UltSuplidor()
        If txtIDSuplidor.Text = "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDSuplidor from Suplidor where IDSuplidor= (Select Max(IDSuplidor) from Suplidor)", ConLibregco)
            txtIDSuplidor.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If
    End Sub

    Private Sub frm_mant_suplidor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LimpiarDatosSuplidor()
    End Sub

    Private Sub txtBeneficiario_Enter(sender As Object, e As EventArgs) Handles txtBeneficiario.Enter
        If txtBeneficiario.Text = "" Then
            txtBeneficiario.Text = txtSuplidor.Text
        End If
    End Sub

    Private Sub txtLimite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimite.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtLimite_Leave(sender As Object, e As EventArgs) Handles txtLimite.Leave
        If txtLimite.Text = "" Then
            txtLimite.Text = (0).ToString("C")
        Else
            txtLimite.Text = CDbl(txtLimite.Text).ToString("C")
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatosSuplidor()
        ActualizarDatos()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtSuplidor.Text = "" Then
            MessageBox.Show("Escriba el nombre del nuevo suplidor a procesar.", "Nombre del Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtSuplidor.Focus()
            Exit Sub
        ElseIf cbxTipoIdentificacion.Text = "" Then
            MessageBox.Show("Seleccione el tipo de identificación del suplidor.", "Tipo de Registro de Contribución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxTipoIdentificacion.Focus()
            cbxTipoIdentificacion.DroppedDown = True
            Exit Sub
        ElseIf cbxProvincia.Text = "" Then
            MessageBox.Show("Seleccione la provincia de la ubicación del suplidor.", "Seleccionar Provincia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxProvincia.Focus()
            cbxProvincia.DroppedDown = True
            Exit Sub
        ElseIf cbxMunicipio.Text = "" Then
            MessageBox.Show("Seleccione el municipio de la ubicación del suplidor.", "Seleccionar Municipio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxMunicipio.Focus()
            cbxMunicipio.DroppedDown = True
            Exit Sub
        ElseIf txtIDTipoSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el tipo de suplidor.", "Seleccionar Tipo del Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnBuscarTipoSuplidor.PerformClick()
            Exit Sub
        ElseIf txtIDCondicion.Text = "" Then
            MessageBox.Show("Seleccione la condición de compras del suplidor.", "Seleccionar Condición", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnBuscarCondicion.PerformClick()
            Exit Sub
        ElseIf txtIDNcf.Text = "" Then
            MessageBox.Show("Seleccione el tipo de comprobante fiscal que emite el suplidor.", "Seleccionar Tipo de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnBuscarNCF.PerformClick()
            Exit Sub
        ElseIf txtIDTipoGasto.Text = "" Then
            MessageBox.Show("Seleccione el tipo de gasto que representan las compras del suplidor.", "Seleccionar Tipo de Gasto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnBuscarTipoGasto.PerformClick()
            Exit Sub
        ElseIf txtLimite.Text = "" Then
            MessageBox.Show("Específique el límite de crédito otorgado por el suplidor.", "Especificar Límite de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtLimite.Focus()
            Exit Sub
        End If

        If txtIDSuplidor.Text = "" Then 'Si no hay un suplidor seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo registro a la base de datos?", "Guardar Nuevo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Suplidor (Suplidor,IDTipoIdentificacion,RNC,IDProvincia,IDMunicipio,Direccion,Telefono,Fax,Email,Web,Representante,TelefonoRepresentante,Beneficiario,LimiteCredito,IDTipoSuplidor,IDCondicion,IDNCF,IDGasto,FechaIngreso,Balance,Desactivar) VALUES ('" + txtSuplidor.Text + "','" + lblTipoIdentificacion.Text + "','" + txtRnc.Text + "', '" + lblIDProvincia.Text + "','" + lblIDMunicipio.Text + "', '" + txtDireccion.Text + "', '" + txtTelefono.Text + "','" + txtFax.Text + "','" + txtCorreo.Text + "', '" + txtWeb.Text + "','" + txtRepresentante.Text + "','" + txtTelRep.Text + "','" + txtBeneficiario.Text + "','" + txtLimite.Text + "', '" + txtIDTipoSuplidor.Text + "', '" + txtIDCondicion.Text + "','" + txtIDNcf.Text + "', '" + txtIDTipoGasto.Text + "', '" + txtFechaRegistro.Text + "','" + txtBalance.Text + "','" + lblDesactivar.Text + "')"
                GuardarDatos()
                ConvertCurrents()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                UltSuplidor()
                CreateFolder()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Suplidor SET Suplidor='" + txtSuplidor.Text + "',IDTipoIdentificacion='" + lblTipoIdentificacion.Text + "',Rnc='" + txtRnc.Text + "',IDProvincia='" + lblIDProvincia.Text + "',IDMunicipio='" + lblIDMunicipio.Text + "',Direccion='" + txtDireccion.Text + "',Telefono='" + txtTelefono.Text + "',Fax='" + txtFax.Text + "',Email='" + txtCorreo.Text + "',Web='" + txtWeb.Text + "',Representante='" + txtRepresentante.Text + "',TelefonoRepresentante='" + txtTelRep.Text + "',Beneficiario='" + txtBeneficiario.Text + "',LimiteCredito='" + txtLimite.Text + "',IDTipoSuplidor='" + txtIDTipoSuplidor.Text + "',IDCondicion='" + txtIDCondicion.Text + "',IDNCF='" + txtIDNcf.Text + "',IDGasto='" + txtIDTipoGasto.Text + "',FechaIngreso='" + txtFechaRegistro.Text + "',Desactivar='" + lblDesactivar.Text + "' WHERE IDSuplidor= (" + txtIDSuplidor.Text + ")"
                GuardarDatos()
                ConvertCurrents()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                CreateFolder()
            End If
        End If

    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtSuplidor.Text = "" Then
            MessageBox.Show("Escriba el nombre del nuevo suplidor a procesar.", "Nombre del Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtSuplidor.Focus()
            Exit Sub
        ElseIf cbxTipoIdentificacion.Text = "" Then
            MessageBox.Show("Seleccione el tipo de identificación del suplidor.", "Tipo de Registro de Contribución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxTipoIdentificacion.Focus()
            cbxTipoIdentificacion.DroppedDown = True
            Exit Sub
        ElseIf cbxProvincia.Text = "" Then
            MessageBox.Show("Seleccione la provincia de la ubicación del suplidor.", "Seleccionar Provincia", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxProvincia.Focus()
            cbxProvincia.DroppedDown = True
            Exit Sub
        ElseIf cbxMunicipio.Text = "" Then
            MessageBox.Show("Seleccione el municipio de la ubicación del suplidor.", "Seleccionar Municipio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxMunicipio.Focus()
            cbxMunicipio.DroppedDown = True
            Exit Sub
        ElseIf txtIDTipoSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el tipo de suplidor.", "Seleccionar Tipo del Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnBuscarTipoSuplidor.PerformClick()
            Exit Sub
        ElseIf txtIDCondicion.Text = "" Then
            MessageBox.Show("Seleccione la condición de compras del suplidor.", "Seleccionar Condición", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnBuscarCondicion.PerformClick()
            Exit Sub
        ElseIf txtIDNcf.Text = "" Then
            MessageBox.Show("Seleccione el tipo de comprobante fiscal que emite el suplidor.", "Seleccionar Tipo de Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnBuscarNCF.PerformClick()
            Exit Sub
        ElseIf txtIDTipoGasto.Text = "" Then
            MessageBox.Show("Seleccione el tipo de gasto que representan las compras del suplidor.", "Seleccionar Tipo de Gasto", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnBuscarTipoGasto.PerformClick()
            Exit Sub
        ElseIf txtLimite.Text = "" Or txtLimite.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Específique el límite de crédito otorgado por el suplidor.", "Especificar Límite de Crédito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtLimite.Focus()
            Exit Sub
        End If

        If txtIDSuplidor.Text = "" Then 'Si no hay un suplidor seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo registro a la base de datos?", "Guardar Nuevo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Suplidor (Suplidor,IDTipoIdentificacion,RNC,IDProvincia,IDMunicipio,Direccion,Telefono,Fax,Email,Web,Representante,TelefonoRepresentante,Beneficiario,LimiteCredito,IDTipoSuplidor,IDCondicion,IDNCF,IDGasto,FechaIngreso,Balance,Desactivar) VALUES ('" + txtSuplidor.Text + "','" + lblTipoIdentificacion.Text + "','" + txtRnc.Text + "', '" + lblIDProvincia.Text + "','" + lblIDMunicipio.Text + "', '" + txtDireccion.Text + "', '" + txtTelefono.Text + "','" + txtFax.Text + "','" + txtCorreo.Text + "', '" + txtWeb.Text + "','" + txtRepresentante.Text + "','" + txtTelRep.Text + "','" + txtBeneficiario.Text + "','" + txtLimite.Text + "', '" + txtIDTipoSuplidor.Text + "', '" + txtIDCondicion.Text + "','" + txtIDNcf.Text + "', '" + txtIDTipoGasto.Text + "', '" + txtFechaRegistro.Text + "','" + txtBalance.Text + "','" + lblDesactivar.Text + "')"
                GuardarDatos()
                ConvertCurrents()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                UltSuplidor()
                CreateFolder()
                LimpiarDatosSuplidor()
                ActualizarDatos()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Suplidor SET Suplidor='" + txtSuplidor.Text + "',IDTipoIdentificacion='" + lblTipoIdentificacion.Text + "',Rnc='" + txtRnc.Text + "',IDProvincia='" + lblIDProvincia.Text + "',IDMunicipio='" + lblIDMunicipio.Text + "',Direccion='" + txtDireccion.Text + "',Telefono='" + txtTelefono.Text + "',Fax='" + txtFax.Text + "',Email='" + txtCorreo.Text + "',Web='" + txtWeb.Text + "',Representante='" + txtRepresentante.Text + "',TelefonoRepresentante='" + txtTelRep.Text + "',Beneficiario='" + txtBeneficiario.Text + "',LimiteCredito='" + txtLimite.Text + "',IDTipoSuplidor='" + txtIDTipoSuplidor.Text + "',IDCondicion='" + txtIDCondicion.Text + "',IDNCF='" + txtIDNcf.Text + "',IDGasto='" + txtIDTipoGasto.Text + "',FechaIngreso='" + txtFechaRegistro.Text + "',Desactivar='" + lblDesactivar.Text + "' WHERE IDSuplidor= (" + txtIDSuplidor.Text + ")"
                GuardarDatos()
                ConvertCurrents()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                CreateFolder()
                LimpiarDatosSuplidor()
                ActualizarDatos()
            End If
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkDesactivar.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El suplidor " & txtSuplidor.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar Suplidor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                ChkDesactivar.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE Suplidor SET Suplidor='" + txtSuplidor.Text + "',IDTipoIdentificacion='" + lblTipoIdentificacion.Text + "',Rnc='" + txtRnc.Text + "',IDProvincia='" + lblIDProvincia.Text + "',IDMunicipio='" + lblIDMunicipio.Text + "',Direccion='" + txtDireccion.Text + "',Telefono='" + txtTelefono.Text + "',Fax='" + txtFax.Text + "',Email='" + txtCorreo.Text + "',Web='" + txtWeb.Text + "',Representante='" + txtRepresentante.Text + "',TelefonoRepresentante='" + txtTelRep.Text + "',Beneficiario='" + txtBeneficiario.Text + "',LimiteCredito='" + txtLimite.Text + "',IDTipoSuplidor='" + txtIDTipoSuplidor.Text + "',IDCondicion='" + txtIDCondicion.Text + "',IDNCF='" + txtIDNcf.Text + "',IDGasto='" + txtIDTipoGasto.Text + "',FechaIngreso='" + txtFechaRegistro.Text + "',Desactivar='" + lblDesactivar.Text + "' WHERE IDSuplidor= (" + txtIDSuplidor.Text + ")"
                GuardarDatos()
                ConvertCurrents()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDSuplidor.Text = "" Then
            MessageBox.Show("No hay un registro de suplidor abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea desactivar el registro del suplidor " & txtSuplidor.Text & " del sistema?", "Desactivar Suplidor", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ChkDesactivar.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE Suplidor SET Suplidor='" + txtSuplidor.Text + "',IDTipoIdentificacion='" + lblTipoIdentificacion.Text + "',Rnc='" + txtRnc.Text + "',IDProvincia='" + lblIDProvincia.Text + "',IDMunicipio='" + lblIDMunicipio.Text + "',Direccion='" + txtDireccion.Text + "',Telefono='" + txtTelefono.Text + "',Fax='" + txtFax.Text + "',Email='" + txtCorreo.Text + "',Web='" + txtWeb.Text + "',Representante='" + txtRepresentante.Text + "',TelefonoRepresentante='" + txtTelRep.Text + "',Beneficiario='" + txtBeneficiario.Text + "',LimiteCredito='" + txtLimite.Text + "',IDTipoSuplidor='" + txtIDTipoSuplidor.Text + "',IDCondicion='" + txtIDCondicion.Text + "',IDNCF='" + txtIDNcf.Text + "',IDGasto='" + txtIDTipoGasto.Text + "',FechaIngreso='" + txtFechaRegistro.Text + "',Desactivar='" + lblDesactivar.Text + "' WHERE IDSuplidor= (" + txtIDSuplidor.Text + ")"
                GuardarDatos()
                ConvertCurrents()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If

    End Sub

    Private Sub ConvertCurrents()
        txtLimite.Text = CDbl(txtLimite.Text).ToString("C")
        txtBalance.Text = CDbl(txtBalance.Text).ToString("C")
    End Sub

    Private Sub ConvertDouble()
        txtLimite.Text = CDbl(txtLimite.Text)
        txtBalance.Text = CDbl(txtBalance.Text)
    End Sub

    Private Sub cbxTipoIdentificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoIdentificacion.SelectedIndexChanged
        SetIDTipoIdentificacion()
    End Sub

    Private Sub BuscarRNCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarRNCToolStripMenuItem.Click
        frm_consulta_rnc.Show(Me)
    End Sub

    Private Sub txtLimite_Enter(sender As Object, e As EventArgs) Handles txtLimite.Enter
        If txtLimite.Text = "" Then
        Else
            txtLimite.Text = CDbl(txtLimite.Text)
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub btnBuscarNCF_Click(sender As Object, e As EventArgs) Handles btnBuscarNCF.Click
        frm_buscar_tipo_comprobantes.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarTipoSuplidor_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoSuplidor.Click
        frm_buscar_tipo_suplidor.ShowDialog(Me)
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub LoadAnimation()
        If PicLoading.Visible = False Then
            PicLoading.Visible = True
            ToolSeparator.Visible = True
            LabelStatus.Text = "Cargando..."
        Else
            PicLoading.Visible = False
            ToolSeparator.Visible = False
            LabelStatus.Text = "Listo"
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If txtIDSuplidor.Text = "" Then
                MessageBox.Show("Seleccione un registro de suplidor para acceder al reporte de descripción del suplidor", "Seleccionar suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnBuscar.PerformClick()
                Exit Sub
            End If

            Con.Open()
            cmd = New MySqlCommand("Select Path from Reportes where IDReportes=143", Con)
            Dim Path As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & Path) Else ObjRpt.Load("C:" & Path.Replace("\Libregco\Libregco.net", ""))

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            '@IDArticulo
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDSuplidor")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterRangeValue = New ParameterRangeValue

            With crParameterRangeValue
                .EndValue = txtIDSuplidor.Text
                .LowerBoundType = RangeBoundType.BoundInclusive
                .StartValue = txtIDSuplidor.Text
                .UpperBoundType = RangeBoundType.BoundInclusive
            End With

            crParameterValues.Add(crParameterRangeValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@IDTipoIdentificacion
            crParameterDiscreteValue.Value = 0
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDTipoIdentificacion")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@IDProvincia
            crParameterDiscreteValue.Value = 0
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDProvincia")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@IDMunicipio
            crParameterDiscreteValue.Value = 0
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDMunicipio")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@IDTipoSuplidor
            crParameterDiscreteValue.Value = 0
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDTipoSuplidor")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@IDCondicion
            crParameterDiscreteValue.Value = 0
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDCondicion")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@IDNCF
            crParameterDiscreteValue.Value = 0
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDNcf")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@IDGasto
            crParameterDiscreteValue.Value = 0
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDGasto")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Estado
            crParameterDiscreteValue.Value = 2
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@FechaIngreso
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@FechaIngreso")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterRangeValue = New ParameterRangeValue

            With crParameterRangeValue
                .StartValue = DateTime.MinValue
                .UpperBoundType = RangeBoundType.BoundInclusive
                .EndValue = DateTime.MaxValue
                .LowerBoundType = RangeBoundType.BoundInclusive
            End With
            crParameterValues.Add(crParameterRangeValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'Setting Info 
            'Resumir Reporte
            ObjRpt.SetParameterValue("@Resumir", 0)
            'Ordenamiento de Reporte
            ObjRpt.SetParameterValue("@SortedField", "Descripción")
            ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "Descripción")
            'Usuario Info
            ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")


            LoadAnimation()
            LabelStatus.Text = "Visualizando el reporte..."

            Dim TmpForm = New frm_reportView
            TmpForm.Show(Me)
            TmpForm.CrystalViewer.ReportSource = ObjRpt
            TmpForm.CrystalViewer.Refresh()
            TmpForm.CrystalViewer.Cursor = Cursors.Default


            LabelStatus.Text = "Listo"


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub btnBuscarTipoGasto_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoGasto.Click
        frm_buscar_tipo_gasto.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarCondicion_Click(sender As Object, e As EventArgs) Handles btnBuscarCondicion.Click
        frm_buscar_condicion.ShowDialog(Me)
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

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub txtTelefono_Leave(sender As Object, e As EventArgs) Handles txtTelefono.Leave
        If Len(txtTelefono.Text) = 8 Then
            txtTelefono.Mask = ""
        End If
        If Len(txtTelefono.Text) = 12 Then
            txtTelefono.Mask = "000-000-0000"
        End If
    End Sub

    Private Sub txtFax_Leave(sender As Object, e As EventArgs) Handles txtFax.Leave
        If Len(txtFax.Text) = 8 Then
            txtFax.Mask = ""
        End If
        If Len(txtFax.Text) = 12 Then
            txtFax.Mask = "000-000-0000"
        End If
    End Sub

    Private Sub txtTelRep_Leave(sender As Object, e As EventArgs) Handles txtTelRep.Leave
        If Len(txtTelRep.Text) = 8 Then
            txtTelRep.Mask = ""
        End If
        If Len(txtTelRep.Text) = 12 Then
            txtTelRep.Mask = "000-000-0000"
        End If
    End Sub

    Private Sub txtSuplidor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSuplidor.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TbSuplidor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TbSuplidor.SelectedIndexChanged
        If TbSuplidor.SelectedIndex = 2 Then
            GetFilesfromFolder()
        End If
    End Sub

    Private Sub txtTelefono_TextChanged(sender As Object, e As EventArgs) Handles txtTelefono.TextChanged
        If txtTelefono.Text = "" Then
        Else
            txtTelefono.Mask = "000-000-0000"
            txtTelefono.SelectionStart = 1
        End If
    End Sub

    Private Sub txtFax_TextChanged(sender As Object, e As EventArgs) Handles txtFax.TextChanged
        If txtFax.Text = "" Then
        Else
            txtFax.Mask = "000-000-0000"
            txtFax.SelectionStart = 1
        End If
    End Sub

    Private Sub txtTelRep_TextChanged(sender As Object, e As EventArgs) Handles txtTelRep.TextChanged
        If txtTelRep.Text = "" Then
        Else
            txtTelRep.Mask = "000-000-0000"
            txtTelRep.SelectionStart = 1
        End If
    End Sub

  
    Private Sub DgvArchivos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArchivos.CellClick
        If e.RowIndex >= 0 Then
            If System.IO.File.Exists(DgvArchivos.CurrentRow.Cells(0).Value) = True Then
                System.Diagnostics.Process.Start(DgvArchivos.CurrentRow.Cells(0).Value)
            End If
        End If
          
    End Sub
End Class

