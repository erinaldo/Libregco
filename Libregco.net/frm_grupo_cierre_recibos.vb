Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_grupo_cierre_recibos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_grupo_cierre_recibos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        LimpiarDatos()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub CargarLibregco()
     PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub chkDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesactivar.CheckedChanged
        If chkDesactivar.Checked = True Then
            lblNulo.Text = 1
            InhabilitarControles()
        Else
            lblNulo.Text = 0
            HabilitarControles()
        End If
    End Sub

    Private Sub HabilitarControles()
        txtDescripcion.Enabled = True
        btnCobrador.Enabled = True
    End Sub

    Private Sub InhabilitarControles()
        txtDescripcion.Enabled = False
        btnCobrador.Enabled = False
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarDatos()
    End Sub

    Private Sub ActualizarDatos()
        chkDesactivar.Checked = False
        Hora.Enabled = True
    End Sub

    Private Sub LimpiarDatos()
        txtIDGrupo.Clear()
        txtSecondID.Clear()
        txtFecha.Clear()
        lblNulo.Text = 0
        txtDescripcion.Clear()
        txtIDCobrador.Clear()
        txtCobrador.Clear()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCobrador.Text = "" Then
            MessageBox.Show("Seleccione el cobrador de el grupo de cierre de recibos.", "Seleccione el cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnCobrador.PerformClick()
            Exit Sub
        ElseIf txtDescripcion.Text = "" Then
            MessageBox.Show("Escriba una breve descripción del grupo de cierre de recibos." & vbNewLine & vbNewLine & "Ejemplo:" & vbNewLine & "Entrega de recibos originales para el cierre del " & Today.AddMonths(-1).ToString("dd/MM/yyyy") & "-" & Today.ToString("dd/MM/yyyy") & ".", "Descripción de grupo de cierre", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        End If

        If txtIDGrupo.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar el nuevo grupo de cierre de recibos de cobros en la base de datos?", "Guardar Grupo de Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO CierreRecibos (IDUsuario,IDTipoDocumento,Fecha,IDCobrador,IDAreaImpresion,Descripcion,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',49,'" + CDate(txtFecha.Text).ToString("yyyy-MM-dd HH:mm:ss") + "','" + txtIDCobrador.Text + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + txtDescripcion.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltGrupo()
                SetSecondID()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE CierreRecibos SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDCobrador='" + txtIDCobrador.Text + "',IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',Descripcion='" + txtDescripcion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDRecibosCobroCierre= (" + txtIDGrupo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=49", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE CierreRecibos SET SecondID='" + lblSecondID.Text + "' WHERE IDRecibosCobroCierre='" + txtIDGrupo.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=49"
            GuardarDatos()

        Catch ex As Exception

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

    Private Sub UltGrupo()
        If txtIDGrupo.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDRecibosCobroCierre from CierreRecibos where IDRecibosCobroCierre= (Select Max(IDRecibosCobroCierre) from CierreRecibos)", Con)
            txtIDGrupo.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_cierre_recibos.ShowDialog(Me)
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub btnCobrador_Click(sender As Object, e As EventArgs) Handles btnCobrador.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtFecha.Text = Today.ToString("dd/MM/yyyy") & " " & TimeOfDay.ToString("HH:mm:ss tt")
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDGrupo.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            frm_impresiones_directas.ShowDialog(Me)
        End If
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

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkDesactivar.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El grupo de cierre No. " & txtSecondID.Text & " ya está anulado en el sistema. Desea activarlo?", "Recuperar Grupo de Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkDesactivar.Checked = False
                sqlQ = "UPDATE CierreRecibos SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDCobrador='" + txtIDCobrador.Text + "',IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',Descripcion='" + txtDescripcion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDRecibosCobroCierre= (" + txtIDGrupo.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDGrupo.Text = "" Then
            MessageBox.Show("No hay un registro de grupo abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el registro de grupo de cierres código No." & txtSecondID.Text & " del sistema?", "Anular Grupo de Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkDesactivar.Checked = True
                sqlQ = "UPDATE CierreRecibos SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDCobrador='" + txtIDCobrador.Text + "',IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',Descripcion='" + txtDescripcion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDRecibosCobroCierre= (" + txtIDGrupo.Text + ")"
                GuardarDatos()

                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub
End Class