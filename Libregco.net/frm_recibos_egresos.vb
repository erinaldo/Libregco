Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_recibos_egresos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim BtnArts As New DataGridViewButtonColumn
    Friend lblNulo, lblIDUsuario, DefaultCurrency As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_recibos_egresos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        CargarConfiguracion
        AutoCompleteSourceBeneficiario()
        AutoCompleteSourceConceptos()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarConfiguracion()
        Con.Open()
        'Moneda predeterminada
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=209", Con)
        DefaultCurrency.Text = CInt(Convert.ToString(cmd.ExecuteScalar()))
        Con.Close()
    End Sub

    Private Sub AutoCompleteSourceBeneficiario()
        Try
            Ds.Clear()

            Con.Open()
            cmd = New MySqlCommand("SELECT Beneficiario FROM egresos group by Beneficiario ORDER BY Beneficiario ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "egresos")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("egresos")

            For Each Dt As DataRow In Tabla.Rows
                txtBeneficiario.AutoCompleteCustomSource.Add(Dt.Item(0).ToString())
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
       
    End Sub


    Private Sub AutoCompleteSourceConceptos()
        Try
            Dim Dstmp As New DataSet

            Con.Open()
            cmd = New MySqlCommand("SELECT Concepto FROM egresos group by Concepto ORDER BY Concepto ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstmp, "egresos")
            Con.Close()

            Dim TablaASD As DataTable = Dstmp.Tables("egresos")

            For Each DtA As DataRow In TablaASD.Rows
                txtConcepto.AutoCompleteCustomSource.Add(DtA.Item(0).ToString())
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub
    Private Sub LimpiarDatos()
        txtIDEgreso.Clear()
        txtSecondID.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        txtBeneficiario.Clear()
        txtMonto.Clear()
        txtReferencia.Clear()
        txtConcepto.Clear()
        txtComentario.Clear()
    End Sub

    Private Sub ActualizarTodo()
        Try
            HabilitarControles()
            FillMonedas
            ControlSuperClave = 1
            txtFecha.Text = Today.ToString("yyyy-MM-dd")
            lblNulo.Text = 0
            ChkNulo.Checked = False
            cbxMoneda.EditValue = CInt(DefaultCurrency.Text)
            btnBuscarSuplidor.Focus()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    
    End Sub

    Private Sub FillMonedas()
        Dim ds As New DataSet

        cbxMoneda.Properties.Items.Clear()

        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto,Signo FROM Libregco.tipomoneda ", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "tipomoneda")
        ConMixta.Close()

        For Each Fila As DataRow In ds.Tables("tipomoneda").Rows
            Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem

            nvmoneda.Description = Fila.Item("Texto")
            nvmoneda.Value = Fila.Item("IDTipoMoneda")

            If Fila.Item("IDTipoMoneda") = 1 Then
                nvmoneda.ImageIndex = 0
            ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                nvmoneda.ImageIndex = 1
            ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                nvmoneda.ImageIndex = 2
            End If

            cbxMoneda.Properties.Items.Add(nvmoneda)
        Next

        cbxMoneda.EditValue = CInt(DefaultCurrency.Text)

    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub HabilitarControles()
        txtBeneficiario.Enabled = True
        txtMonto.Enabled = True
        txtReferencia.Enabled = True
        txtConcepto.Enabled = True
        btnBuscarSuplidor.Enabled = True
        txtComentario.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        txtBeneficiario.Enabled = False
        txtMonto.Enabled = False
        txtReferencia.Enabled = False
        txtConcepto.Enabled = False
        btnBuscarSuplidor.Enabled = False
        txtComentario.Enabled = False
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDEgreso.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el comprobante del recibo de egreso?", "Imprimir Comprobante de Egreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
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
        Catch ex As Exception
            txtMonto.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub txtMonto_Enter(sender As Object, e As EventArgs) Handles txtMonto.Enter
        If txtMonto.Text = "" Then
        Else
            txtMonto.Text = CDbl(txtMonto.Text)
        End If
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

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub ConvertDouble()
        txtMonto.Text = CDbl(txtMonto.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & "Desde GuardarDatos1")
            Con.Close()
        End Try
    End Sub

    Private Sub UltEgreso()
        Try
            If txtIDEgreso.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDEgresos from Egresos where IDEgresos= (Select Max(IDEgresos) from Egresos)", Con)
                txtIDEgreso.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            DeshabilitarControles()
            lblNulo.Text = 1
        Else
            HabilitarControles()
            lblNulo.Text = 0
        End If
    End Sub

    Private Sub btnBuscarSuplidor_Click(sender As Object, e As EventArgs) Handles btnBuscarSuplidor.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtBeneficiario.Text = "" Then
            MessageBox.Show("Seleccione o escriba el nombre del beneficiario.", "No se ha específicado el beneficiario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSuplidor.Focus()
            Exit Sub
        ElseIf txtMonto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba el monto del Egreso a procesar.", "Defina el Monto del Egreso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        ElseIf txtConcepto.Text = "" Then
            MessageBox.Show("Escriba el concepto del ingreso a procesar.", "Concepto de Ingreso Variado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        ElseIf txtConcepto.Text.Trim.Length < 10 Then
            MessageBox.Show("El concepto escrito no cumple con los requisitos para ser procesado. Por favor defina detalladamente el concepto de la transacción.", "Detallar Ingreso Variado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        End If

        If txtIDEgreso.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el generar el recibo de egreso al beneficario: " & txtBeneficiario.Text & ", en la base de datos?", "Guardar Nuevo Egreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Egresos (IDTipoDocumento,IDSucursal,IDAlmacen,IDEquipo,IDUsuario,Fecha,Hora,Beneficiario,Monto,Referencia,Concepto,Comentario,Impreso,IDMoneda,Nulo) VALUES (23,'" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtBeneficiario.Text + "','" + txtMonto.Text + "','" + txtReferencia.Text + "','" + txtConcepto.Text + "','" + txtComentario.Text + "',0,'" + cbxMoneda.EditValue.ToString + "','" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltEgreso()
                SetSecondID()
                DeshabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el egreso?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Egresos SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',Beneficiario='" + txtBeneficiario.Text + "',Monto='" + txtMonto.Text + "',Referencia='" + txtReferencia.Text + "',Concepto='" + txtConcepto.Text + "',Comentario='" + txtComentario.Text + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "',Nulo='" + lblNulo.Text + "' WHERE IDEgresos= (" + txtIDEgreso.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                DeshabilitarControles()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=23", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE Egresos SET SecondID='" + lblSecondID.Text + "' WHERE IDEgresos='" + txtIDEgreso.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=23"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_recibos_egresos.ShowDialog(Me)
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de recibo de egreso No." & txtIDEgreso.Text & " del beneficiario: " & txtBeneficiario.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Egreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 97
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE Egresos SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',Beneficiario='" + txtBeneficiario.Text + "',Monto='" + txtMonto.Text + "',Referencia='" + txtReferencia.Text + "',Concepto='" + txtConcepto.Text + "',Comentario='" + txtComentario.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDEgresos= (" + txtIDEgreso.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDEgreso.Text = "" Then
            MessageBox.Show("No hay un registro de egreso abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el registro de egreso No." & txtIDEgreso.Text & ", del beneficiario: " & txtBeneficiario.Text & " del sistema?", "Anular Egreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 98
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE Egresos SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',Beneficiario='" + txtBeneficiario.Text + "',Monto='" + txtMonto.Text + "',Referencia='" + txtReferencia.Text + "',Concepto='" + txtConcepto.Text + "',Comentario='" + txtComentario.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDEgresos= (" + txtIDEgreso.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtBeneficiario.Text = "" Then
            MessageBox.Show("Seleccione o escriba el nombre del beneficiario.", "No se ha específicado el beneficiario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSuplidor.Focus()
            Exit Sub
        ElseIf txtMonto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Escriba el monto del Egreso a procesar.", "Defina el Monto del Egreso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMonto.Focus()
            Exit Sub
        ElseIf txtConcepto.Text = "" Then
            MessageBox.Show("Escriba el concepto del ingreso a procesar.", "Concepto de Ingreso Variado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        ElseIf txtConcepto.Text.Trim.Length < 10 Then
            MessageBox.Show("El concepto escrito no cumple con los requisitos para ser procesado. Por favor defina detalladamente el concepto de la transacción.", "Detallar Ingreso Variado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        End If

        If txtIDEgreso.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el generar el recibo de egreso al beneficario: " & txtBeneficiario.Text & ", en la base de datos?", "Guardar Nuevo Egreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Egresos (IDTipoDocumento,IDSucursal,IDAlmacen,IDEquipo,IDUsuario,Fecha,Hora,Beneficiario,Monto,Referencia,Concepto,Comentario,Impreso,IDMoneda,Nulo) VALUES (23,'" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtBeneficiario.Text + "','" + txtMonto.Text + "','" + txtReferencia.Text + "','" + txtConcepto.Text + "','" + txtComentario.Text + "',0,'" + cbxMoneda.EditValue.ToString + "','" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltEgreso()
                SetSecondID()
                DeshabilitarControles()
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
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el egreso?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Egresos SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',Beneficiario='" + txtBeneficiario.Text + "',Monto='" + txtMonto.Text + "',Referencia='" + txtReferencia.Text + "',Concepto='" + txtConcepto.Text + "',Comentario='" + txtComentario.Text + "',IDMoneda=,'" + cbxMoneda.EditValue.ToString + "',Nulo='" + lblNulo.Text + "' WHERE IDEgresos= (" + txtIDEgreso.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                DeshabilitarControles()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub
End Class