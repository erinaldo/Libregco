Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_comp_fiscal

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblchkMostrarFact, lblchkNulo As New Label

    Private Sub frm_mant_comp_fiscal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        LimpiarDatos()
    End Sub

    Private Sub LimpiarDatos()
        txtIDNCF.Clear()
        txtNCF.Clear()
        txtInicial.Clear()
        txtHasta.Clear()
        txtUltimo.Clear()
        NoTCF.Clear()
        ActualizarTodo()

    End Sub

    Private Sub ActualizarTodo()
        chkMostrarenFact.Checked = False
        lblchkMostrarFact.Text = 2
        chkNulo.Checked = False
        lblchkNulo.Text = 0
    End Sub
    Private Sub chkMostrarenFact_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarenFact.CheckedChanged
        If chkMostrarenFact.Checked = True Then
            lblchkMostrarFact.Text = 1
        Else
            lblchkMostrarFact.Text = 2
        End If
    End Sub

    Private Sub txtHasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHasta.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub HabilitarControles()
        txtNCF.Enabled = True
        txtInicial.Enabled = True
        txtHasta.Enabled = True
        chkMostrarenFact.Enabled = True
        NoTCF.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        txtNCF.Enabled = False
        txtInicial.Enabled = False
        txtHasta.Enabled = False
        chkMostrarenFact.Enabled = False
        NoTCF.Enabled = False
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

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        HabilitarControles()
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        btnGuardar.PerformClick()
        btnNuevo.PerformClick()
    End Sub

    Private Sub UpdateNCFs()
        Try
            Dim DSPcs, DSNFs As New DataSet

            DSPcs.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT * FROM AreaImpresion", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DSPcs, "AreaImpresion")
            Con.Close()

            'Lleno otra tabla con cada uno de los terminales autorizados previamente
            Dim TablaPCs As DataTable = DSPcs.Tables("AreaImpresion")

            For Each FilaAreaImpresion As DataRow In TablaPCs.Rows
                Dim IDEquipo As New Label
                IDEquipo.Text = FilaAreaImpresion.Item("IDEquipo")

                DSNFs.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT * FROM comprobantefiscal", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DSNFs, "Comprobantefiscal")
                Con.Close()

                'Lleno una tabla con los tipos de comprobantes fiscales
                Dim TablaNCF As DataTable = DSNFs.Tables("Comprobantefiscal")

                For Each Fila As DataRow In TablaNCF.Rows
                    Dim IDComprobante, IDAreaImpresionNCF As New Label
                    IDComprobante.Text = Fila.Item("IDComprobanteFiscal")

                    Con.Open()
                    cmd = New MySqlCommand("SELECT IDAreaImpresionNCF FROM areaimpresionncf Where IDAreaImpresion='" + IDEquipo.Text + "' and IDNCF='" + IDComprobante.Text + "'", Con)
                    IDAreaImpresionNCF.Text = Convert.ToString(cmd.ExecuteScalar())
                    Con.Close()

                    If IDAreaImpresionNCF.Text = "" Then
                        sqlQ = "INSERT INTO AreaImpresionNCF (IDAreaImpresion,IDNCF,Inicial,Final,Actual) VALUES ('" + IDEquipo.Text + "','" + IDComprobante.Text + "','0','0','0')"
                        GuardarDatos()
                    End If
                Next
            Next


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtNCF.Text = "" Then
            MessageBox.Show("Escriba la descripción del comprobante fiscal a registrar.", "Escribir Tipo de NCF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNCF.Focus()
            Exit Sub
        ElseIf txtInicial.Text = "" Then
            MessageBox.Show("Especifique la forma o secuencia del comprobante.", "Escribir secuencia del comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtInicial.Focus()
            Exit Sub
        ElseIf txtHasta.Text = "" Then
            MessageBox.Show("Especifique el límite de generación del comprobante fiscal.", "Especificar límite de generación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtHasta.Focus()
            Exit Sub
        End If

        If txtIDNCF.Text = "" Then
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar el nuevo tipo de comprobante fiscal: " & txtNCF.Text & " en la base de datos?", "Guardar Nuevo NCF", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO ComprobanteFiscal (IDContexto,TipoComprobante,Inicial,Hasta,NoTCP,Nulo) VALUES ('" + lblchkMostrarFact.Text + "','" + txtNCF.Text + "','" + txtInicial.Text + "','" + txtHasta.Text + "','" + NoTCF.Text + "','" + lblchkNulo.Text + "')"
                GuardarDatos()
                UltNCF()
                UpdateNCFs()
                DeshabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE ComprobanteFiscal SET IDContexto='" + lblchkMostrarFact.Text + "',TipoComprobante='" + txtNCF.Text + "',Inicial='" + txtInicial.Text + "',Hasta='" + txtHasta.Text + "',NoTCP='" + NoTCF.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDComprobanteFiscal= (" + txtIDNCF.Text + ")"
                GuardarDatos()
                UpdateNCFs()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        End If
    End Sub

    Private Sub UltNCF()
        If txtIDNCF.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDComprobanteFiscal from ComprobanteFiscal where IDComprobanteFiscal= (Select Max(IDComprobanteFiscal) from ComprobanteFiscal)", Con)
            txtIDNCF.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        End If
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblchkNulo.Text = 1
            DeshabilitarControles()
        Else
            lblchkNulo.Text = 0
            HabilitarControles()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La comprobante fiscal " & txtNCF.Text & "  ya está desactivada del sistema. Desea volver a activarlo?", "Activar NCF", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE ComprobanteFiscal SET IDContexto='" + lblchkMostrarFact.Text + "',TipoComprobante='" + txtNCF.Text + "',Inicial='" + txtInicial.Text + "',Hasta='" + txtHasta.Text + "',NoTCP='" + NoTCF.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDComprobanteFiscal= (" + txtIDNCF.Text + ")"
                GuardarDatos()
                UpdateNCFs()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDNCF.Text = "" Then
            MessageBox.Show("No hay un registro de comprobante fiscal abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea desactivar el registro del comprobante fiscal " & txtNCF.Text & " del sistema?", "Desactivar Comprobante Fiscal", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE ComprobanteFiscal SET IDContexto='" + lblchkMostrarFact.Text + "',TipoComprobante='" + txtNCF.Text + "',Inicial='" + txtInicial.Text + "',Hasta='" + txtHasta.Text + "',NoTCP='" + NoTCF.Text + "',Nulo='" + lblchkNulo.Text + "' WHERE IDComprobanteFiscal= (" + txtIDNCF.Text + ")"
                GuardarDatos()
                UpdateNCFs()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_tipo_comprobantes.ShowDialog(Me)
    End Sub
End Class