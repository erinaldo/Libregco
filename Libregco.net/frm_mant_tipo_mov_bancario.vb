Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_tipo_mov_bancario


    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblChkPedirNcf, lblChkPedirCApInt, lblIDTipoFuncion As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_tipo_mov_bancario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub LimpiarDatos()
        txtIDTipoMov.Clear()
        txtDescripcion.Clear()
        txtAbreviatura.Clear()
        txtIDCtaContable.Clear()
        txtCtaContable.Clear()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        chkNulo.Checked = False
        ChkPedirCapInt.Checked = False
        chkPedirNCF.Checked = False
        lblNulo.Text = 0
        lblIDTipoFuncion.Text = ""
        lblChkPedirCApInt.Text = ""
        lblChkPedirNcf.Text = ""
        txtDescripcion.Focus()
        FillTipoFuncion()
    End Sub

    Private Sub FillTipoFuncion()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM TipoFuncion ORDER BY IDTipoFuncion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoFuncion")
        cbxFuncion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoFuncion")

        For Each Fila As DataRow In Tabla.Rows
            cbxFuncion.Items.Add(Fila.Item("Descripcion"))
        Next

        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron funciones disponibles. Inserte las funciones para poder procesar los movimientos bancarios.", "No se encontraron funciones aritmeticas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = False Then
            lblNulo.Text = 0
            HabilitarControles()
        Else
            lblNulo.Text = 1
            DeshabilitarControles()
        End If
    End Sub

    Private Sub CargarEmpresa()
    PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()
        Catch ex As Exception
            ConLibregco.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub UltTipoMovBancario()
        Try
            If txtIDTipoMov.Text = "" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("Select IDTipoMovBancario from TipoMovBancario where IDTipoMovBancario= (Select Max(IDTipoMovBancario) from TipoMovBancario)", ConLibregco)
                txtIDTipoMov.Text = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " UltTipoMovBancario()")
        End Try
    End Sub

    Private Sub DeshabilitarControles()
        txtDescripcion.Enabled = False
        txtAbreviatura.Enabled = False
        btnBuscarCtaContable.Enabled = False
        txtCtaContable.Enabled = False
        cbxFuncion.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        txtDescripcion.Enabled = True
        txtAbreviatura.Enabled = True
        btnBuscarCtaContable.Enabled = True
        txtCtaContable.Enabled = True
        cbxFuncion.Enabled = True
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

    Private Sub btnBuscarCtaContable_Click(sender As Object, e As EventArgs) Handles btnBuscarCtaContable.Click
        frm_buscar_cuenta_contable.ShowDialog(Me)
    End Sub

    Private Sub chkPedirNCF_CheckedChanged(sender As Object, e As EventArgs) Handles chkPedirNCF.CheckedChanged
        If chkPedirNCF.Checked = False Then
            lblChkPedirNcf.Text = 0
        Else
            lblChkPedirNcf.Text = 1
        End If
    End Sub

    Private Sub ChkPedirCapInt_CheckedChanged(sender As Object, e As EventArgs) Handles ChkPedirCapInt.CheckedChanged
        If ChkPedirCapInt.Checked = False Then
            lblChkPedirCApInt.Text = 0
        Else
            lblChkPedirCApInt.Text = 1
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Escriba el nombre del tipo de transacción bancaria para procesar el registro.", "Escriba descripción de la transacción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf txtIDCtaContable.Text = "" Then
            MessageBox.Show("Seleccione la cuenta bancaria afectada por la transacción bancaria.", "Seleccionar Cta. Contable", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCtaContable.PerformClick()
        End If

        If txtIDTipoMov.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo tipo de movimiento bancario " & txtDescripcion.Text & " en la base de datos?", "Guardar nuevo tipo de movimiento bancario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO TipoMovBancario (TipoMovimiento,Abreviatura,IDTipoFuncion,IDCtaContable,PedirNCF,PedirCapInt,Nulo) VALUES ('" + txtDescripcion.Text + "','" + txtAbreviatura.Text + "','" + lblIDTipoFuncion.Text + "','" + txtIDCtaContable.Text + "','" + lblChkPedirNcf.Text + "','" + lblChkPedirCApInt.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltTipoMovBancario()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la tipo de movimiento bancario?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE TipoMovBancario SET TipoMovimiento='" + txtDescripcion.Text + "',Abreviatura='" + txtAbreviatura.Text + "',IDTipoFuncion='" + lblIDTipoFuncion.Text + "',IDCtaContable='" + txtIDCtaContable.Text + "',PedirNCF='" + lblChkPedirNcf.Text + "',PedirCapInt='" + lblChkPedirCApInt.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoMovBancario= '" + txtIDTipoMov.Text + "'"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Escriba el nombre del tipo de transacción bancaria para procesar el registro.", "Escriba descripción de la transacción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf txtIDCtaContable.Text = "" Then
            MessageBox.Show("Seleccione la cuenta bancaria afectada por la transacción bancaria.", "Seleccionar Cta. Contable", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCtaContable.PerformClick()
        End If

        If txtIDTipoMov.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo tipo de movimiento bancario " & txtDescripcion.Text & " en la base de datos?", "Guardar nuevo tipo de movimiento bancario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO TipoMovBancario (TipoMovimiento,Abreviatura,IDTipoFuncion,IDCtaContable,PedirNCF,PedirCapInt,Nulo) VALUES ('" + txtDescripcion.Text + "','" + txtAbreviatura.Text + "','" + lblIDTipoFuncion.Text + "','" + txtIDCtaContable.Text + "','" + lblChkPedirNcf.Text + "','" + lblChkPedirCApInt.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltTipoMovBancario()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la tipo de movimiento bancario?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE TipoMovBancario SET TipoMovimiento='" + txtDescripcion.Text + "',Abreviatura='" + txtAbreviatura.Text + "',IDTipoFuncion='" + lblIDTipoFuncion.Text + "',IDCtaContable='" + txtIDCtaContable.Text + "',PedirNCF='" + lblChkPedirNcf.Text + "',PedirCapInt='" + lblChkPedirCApInt.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoMovBancario= '" + txtIDTipoMov.Text + "'"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_tipo_movimiento_bancario.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El movimiento bancario código. " & txtIDTipoMov.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Tipo Movimiento Bancario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE TipoMovBancario SET TipoMovimiento='" + txtDescripcion.Text + "',Abreviatura='" + txtAbreviatura.Text + "',IDTipoFuncion='" + lblIDTipoFuncion.Text + "',IDCtaContable='" + txtIDCtaContable.Text + "',PedirNCF='" + lblChkPedirNcf.Text + "',PedirCapInt='" + lblChkPedirCApInt.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoMovBancario= '" + txtIDTipoMov.Text + "'"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDTipoMov.Text = "" Then
            MessageBox.Show("No hay un registro de movimiento bancario abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el tipo de movimiento bancario código. " & txtIDTipoMov.Text & " / " & txtDescripcion.Text & " del sistema?", "Anular Tipo Movimiento Bancario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE TipoMovBancario SET TipoMovimiento='" + txtDescripcion.Text + "',Abreviatura='" + txtAbreviatura.Text + "',IDTipoFuncion='" + lblIDTipoFuncion.Text + "',IDCtaContable='" + txtIDCtaContable.Text + "',PedirNCF='" + lblChkPedirNcf.Text + "',PedirCapInt='" + lblChkPedirCApInt.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTipoMovBancario= '" + txtIDTipoMov.Text + "'"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub cbxFuncion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxFuncion.SelectedIndexChanged
        SetIDFuncion()
    End Sub

    Private Sub SetIDFuncion()
        If Con.State = ConnectionState.Open Then
            Con.Close()
        End If

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoFuncion FROM tipofuncion Where Descripcion='" + cbxFuncion.SelectedItem + "'", ConLibregco)
        lblIDTipoFuncion.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub
End Class