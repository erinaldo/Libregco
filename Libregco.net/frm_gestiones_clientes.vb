Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_gestiones_clientes
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue

    Private Sub frm_gestiones_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        AddClickEvents()
        LimpiarDatos()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub PicCliente_Click(sender As Object, e As EventArgs) Handles PicCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub SimilarFindButton_Click(sender As Object, e As EventArgs) Handles SimilarFindButton.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Text = ""
        txtNombre.Text = "No hay un cliente seleccionado"
        txtBalanceGral.Text = ""
        txtUltimoPago.Text = ""
        txtCobradorC.Text = ""
        txtCalificacion.Text = ""
        txtIDCobradorC.Text = ""
        PicCliente.BackgroundImage = My.Resources.no_photo
        txtInfoAdicional.Clear()
        Label3.Text = ""
        MakeRoundedImageToPanel(My.Resources.no_photo, PicCliente)
        txtIDGestion.Clear()
        chkNulo.Checked = False
        chkNulo.Tag = 0
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos
    End Sub

    Private Sub AddClickEvents()
        AddHandler Button1.Click, AddressOf ClickONButton
        AddHandler Button2.Click, AddressOf ClickONButton
        AddHandler Button3.Click, AddressOf ClickONButton
        AddHandler Button4.Click, AddressOf ClickONButton
        AddHandler Button5.Click, AddressOf ClickONButton
        AddHandler Button6.Click, AddressOf ClickONButton
        AddHandler Button7.Click, AddressOf ClickONButton
        AddHandler Button8.Click, AddressOf ClickONButton
        AddHandler Button9.Click, AddressOf ClickONButton
        AddHandler Button10.Click, AddressOf ClickONButton
        AddHandler Button11.Click, AddressOf ClickONButton

    End Sub

    Private Sub ClickONButton(sender As Object, e As EventArgs)
        Label3.Text = DirectCast(sender, Button).Text
        txtInfoAdicional.Focus()
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione un cliente para realizar la gestión.", "Seleccione el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Label3.Text = "" Then
            MessageBox.Show("Seleccione un estado de gestión sobre el cliente.", "Descripción de garantía", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtInfoAdicional.Text = "" Then
            MessageBox.Show("Haga una breve descripción de la gestión que desea procesar.", "Escriba un breve resumen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtInfoAdicional.Focus()
            Exit Sub
        End If

        If txtIDGestion.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar la gestión de cobros a la base de datos?", "Guardar Nueva Gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Gestion_clientes (IDCliente,Fecha,Gestion,InfoAdicional,Nulo) VALUES ('" + txtIDCliente.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + Label3.Text + "','" + txtInfoAdicional.Text + "',0)"
                GuardarDatos()
                UltGestion
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                chkNulo.Checked = False
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Gestion_clientes SET IDCliente='" + txtIDCliente.Text + "',Fecha='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',Gestion='" + Label3.Text + "',InfoAdicional='" + txtInfoAdicional.Text + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDGestion_Clientes= (" + txtIDGestion.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                chkNulo.Checked = True
            End If
        End If
    End Sub

    Private Sub UltGestion()
        If txtIDGestion.Text = "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDGestion_Clientes from Gestion_Clientes where IDGestion_Clientes= (Select Max(IDGestion_Clientes) from Gestion_Clientes)", ConLibregco)
            txtIDGestion.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If

    End Sub
    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()
        Catch ex As Exception
            Con.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            chkNulo.Tag = 1
        Else
            chkNulo.Tag = 0
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La gestión " & txtIDGestion.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar Gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE Gestion_clientes SET IDCliente='" + txtIDCliente.Text + "',Fecha='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',Gestion='" + Label3.Text + "',InfoAdicional='" + txtInfoAdicional.Text + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDGestion_Clientes= (" + txtIDGestion.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDGestion.Text = "" Then
            MessageBox.Show("No hay un registro de gestión abierto para desactivar", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            frm_buscar_gestiones_clientes.ShowDialog(Me)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea desactivar el registro de gestión " & txtIDGestion.Text & " del sistema?", "Desactivar gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE Gestion_clientes SET IDCliente='" + txtIDCliente.Text + "',Fecha='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',Gestion='" + Label3.Text + "',InfoAdicional='" + txtInfoAdicional.Text + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDGestion_Clientes= (" + txtIDGestion.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_gestiones_clientes.ShowDialog(Me)
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


    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If txtIDCliente.Text = "" Then
                MessageBox.Show("Seleccione un registro de clientes para acceder al reporte de descripción.", "Seleccionar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnBuscar.PerformClick()
                Exit Sub
            End If

            Con.Open()
            cmd = New MySqlCommand("Select Path from Reportes where IDReportes=247", Con)
            Dim Path As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            ObjRpt.Load("\\" & PathServidor.Text & Path)

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            '@IDCliente
            crParameterDiscreteValue.Value = txtIDCliente.Text
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDCliente")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'Usuario Info
            ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")

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