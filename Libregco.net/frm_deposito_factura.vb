Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_deposito_factura
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos, PagaresCreados, Precios As New ArrayList

    Private Sub frm_deposito_factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub SelectUsuario()
        Try

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]"
            Con.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtBalanceGral.Clear()
        txtBalanceGeneralCargos.Clear()
        txtUltimoPago.Clear()
        txtCalificacion.Clear()
        txtFecha.Clear()
        txtIDDeposito.Clear()
        txtSecondID.Clear()
        DgvFacturaDepositadas.Rows.Clear()
        DgvFacturasPendientes.Rows.Clear()
        txtDescripcion.Clear()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        ChkNulo.Checked = False
        Hora.Enabled = True
        btnBuscarCliente.Enabled = True
        ChkNulo.Tag = 0
        ControlSuperClave = 1
        txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")
        btnSustractAll.Enabled = True
        ContarFilas()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Sub HabilitarControles()
        GbCliente.Enabled = True
        DgvFacturaDepositadas.Enabled = True
        DgvFacturasPendientes.Enabled = True
        btnAddAll.Enabled = True
        btnAddOne.Enabled = True
        btnSustractAll.Enabled = True
        btnSustractOne.Enabled = True
        txtDescripcion.Enabled = True
    End Sub

    Private Sub btnAddOne_Click(sender As Object, e As EventArgs) Handles btnAddOne.Click
        Try
            If DgvFacturasPendientes.SelectedRows.Count > 0 Then
                DgvFacturaDepositadas.Rows.Add("", DgvFacturasPendientes.CurrentRow.Cells(0).Value, DgvFacturasPendientes.CurrentRow.Cells(1).Value, DgvFacturasPendientes.CurrentRow.Cells(2).Value, DgvFacturasPendientes.CurrentRow.Cells(3).Value)
                DgvFacturasPendientes.Rows.Remove(DgvFacturasPendientes.CurrentRow)
            End If

            ContarFilas()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnAddAll_Click(sender As Object, e As EventArgs) Handles btnAddAll.Click
        For Each Row As DataGridViewRow In DgvFacturasPendientes.Rows
            DgvFacturaDepositadas.Rows.Add("", Row.Cells(0).Value, Row.Cells(1).Value, Row.Cells(2).Value, Row.Cells(3).Value)
        Next
        DgvFacturasPendientes.Rows.Clear()
        ContarFilas()
    End Sub

    Private Sub btnSustractOne_Click(sender As Object, e As EventArgs) Handles btnSustractOne.Click
        If DgvFacturaDepositadas.SelectedRows.Count > 0 Then
            If CStr(DgvFacturaDepositadas.CurrentRow.Cells(0).Value.ToString) = "" Then
                DgvFacturasPendientes.Rows.Add(DgvFacturaDepositadas.CurrentRow.Cells(1).Value, DgvFacturaDepositadas.CurrentRow.Cells(2).Value, DgvFacturaDepositadas.CurrentRow.Cells(3).Value, DgvFacturaDepositadas.CurrentRow.Cells(4).Value)
                DgvFacturaDepositadas.Rows.Remove(DgvFacturaDepositadas.CurrentRow)

            Else

                DgvFacturasPendientes.Rows.Add(DgvFacturaDepositadas.CurrentRow.Cells(1).Value, DgvFacturaDepositadas.CurrentRow.Cells(2).Value, DgvFacturaDepositadas.CurrentRow.Cells(3).Value, DgvFacturaDepositadas.CurrentRow.Cells(4).Value)

                sqlQ = "Delete from depositofacturadetalle Where IDdepositofacturadetalle = (" + DgvFacturaDepositadas.CurrentRow.Cells(0).Value.ToString + ")"
                GuardarDatos()

                DgvFacturaDepositadas.Rows.Remove(DgvFacturaDepositadas.CurrentRow)

            End If
        End If
        ContarFilas()
    End Sub

    Private Sub btnSustractAll_Click(sender As Object, e As EventArgs) Handles btnSustractAll.Click
        For Each Row As DataGridViewRow In DgvFacturaDepositadas.Rows
            DgvFacturasPendientes.Rows.Add(Row.Cells(1).Value, Row.Cells(2).Value, Row.Cells(3).Value, Row.Cells(4).Value)
        Next
        DgvFacturaDepositadas.Rows.Clear()
        ContarFilas()
    End Sub

    Sub ContarFilas()
        Label7.Text = "Cant. de facturas sin depositar: " & DgvFacturasPendientes.Rows.Count
        Label8.Text = "Cant. de facturas seleccionadas: " & DgvFacturaDepositadas.Rows.Count
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDDeposito.Text = "" Then
            If DgvFacturaDepositadas.Rows.Count > 0 Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario de mantenimiento de depósito de facturas?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatos()
                    ActualizarTodo()
                End If
            Else
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            LimpiarDatos()
            ActualizarTodo()
        End If
    End Sub

    Private Sub DgvFacturasPendientes_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvFacturasPendientes.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvFacturasPendientes.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvFacturasPendientes.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvFacturasPendientes.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub DgvFacturaDepositadas_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs)
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvFacturaDepositadas.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvFacturaDepositadas.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvFacturaDepositadas.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            ChkNulo.Tag = 1
            DeshabilitarControles()
        Else
            ChkNulo.Tag = 0
            HabilitarControles()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("No se ha seleccionado el cliente para iniciar el proceso de depósito de factura.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf DgvFacturaDepositadas.Rows.Count = 0 Then
            MessageBox.Show("Aún no hay facturas seleccionadas para realizar el depósito.", "No hay facturas seleccionadas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDDeposito.Text = "" Then 'Si no hay pago
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el registro de depósito de facturas al cliente " & txtNombre.Text & " [ " & txtIDCliente.Text & " ] en la base de datos?", "Guardar Depósito de factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO DepositoFacturas (IDTipoDocumento,Fecha,IDUsuario,IDCliente,Descripcion,Impreso,Nulo) VALUES (55,Now(),'" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + txtIDCliente.Text + "', '" + txtDescripcion.Text + "',0,0)"
                GuardarDatos()
                UltDeposito()
                SetSecondID()
                InsertDetalles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DeshabilitarControles()
                Hora.Enabled = False
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE DepositoFacturas SET Fecha=Now(),IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDCliente='" + txtIDCliente.Text + "',Descripcion='" + txtDescripcion.Text + "' WHERE IDDepositoFacturas= (" + txtIDDeposito.Text + ")"
                GuardarDatos()
                InsertDetalles()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DeshabilitarControles()
                Hora.Enabled = False
            End If
        End If
    End Sub


    Private Sub InsertDetalles()
        Try
            For Each Row As DataGridViewRow In DgvFacturaDepositadas.Rows
                If Row.Cells(0).Value.ToString = "" Then
                    sqlQ = "Insert into DepositoFacturaDetalle (IDDepositoFactura,IDFactura) Values ('" + txtIDDeposito.Text + "','" + Row.Cells(1).Value.ToString + "')"
                    GuardarDatos()

                    Con.Open()
                    cmd = New MySqlCommand("Select idDepositoFacturaDetalle from depositofacturadetalle where idDepositoFacturaDetalle= (Select Max(idDepositoFacturaDetalle) from depositofacturadetalle)", Con)
                    Row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                    Con.Close()
                Else

                    sqlQ = "UPDATE DepositoFacturaDetalle SET IDDepositoFactura='" + txtIDDeposito.Text + "',IDFactura='" + Row.Cells(1).Value.ToString + "' WHERE IDDepositoFacturaDetalle= (" + Row.Cells(0).Value.ToString + ")"
                    GuardarDatos()
                End If
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=55", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE depositofacturas SET SecondID='" + lblSecondID.Text + "' WHERE IDdepositofacturas='" + txtIDDeposito.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=55"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub UltDeposito()
        Try

            If txtIDDeposito.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select idDepositoFacturas from depositofacturas where idDepositoFacturas= (Select Max(idDepositoFacturas) from depositofacturas)", Con)
                txtIDDeposito.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "UltPago")
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
            MessageBox.Show(ex.Message & " Desde Guardar Datos")
        End Try
    End Sub

    Sub DeshabilitarControles()
        GbCliente.Enabled = False
        DgvFacturaDepositadas.Enabled = False
        DgvFacturasPendientes.Enabled = False
        btnAddAll.Enabled = False
        btnAddOne.Enabled = False
        btnSustractAll.Enabled = False
        btnSustractOne.Enabled = False
        txtDescripcion.Enabled = False
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_deposito_factura.ShowDialog(Me)
    End Sub

    Sub RefrescarTablaFacturas()
        Try
            DgvFacturasPendientes.Rows.Clear()
            ConMixta.Open()

            Dim CmdFacts As New MySqlCommand("SELECT IDFacturaDatos,SecondID,Fecha,FechaVencimiento,Balance,Cargos,(Select count(idDepositoFacturaDetalle) from" & SysName.Text & "DepositoFacturaDetalle Inner join" & SysName.Text & "DepositoFacturas on DepositoFacturaDetalle.IDDepositoFactura=DepositoFacturas.IDDepositoFacturas Where depositofacturadetalle.IDFactura=FacturaDatos.IDFacturaDatos) as Procesada FROM" & SysName.Text & "FacturaDatos WHERE IDCliente='" + txtIDCliente.Text + "' and FacturaDatos.Balance>0 AND FacturaDatos.Nulo=0", ConMixta)
            Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader

            While LectorFacturas.Read
                If LectorFacturas.GetValue(6) = 0 Then
                    DgvFacturasPendientes.Rows.Add(LectorFacturas.GetValue(0), "Documento: " & vbNewLine & LectorFacturas.GetValue(1), "Fecha: " & LectorFacturas.GetValue(2) & vbNewLine & "Vencimiento: " & LectorFacturas.GetValue(3), "Balance: " & CDbl(LectorFacturas.GetValue(4)).ToString("C") & vbNewLine & "Cargos: " & CDbl(LectorFacturas.GetValue(5)).ToString())
                End If
            End While

            LectorFacturas.Close()
            ConMixta.Close()

            ContarFilas()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de depósito de factura ya está desactivada del sistema. Desea volver a activarlo?", "Activar Depósto de factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                ChkNulo.Checked = False
                sqlQ = "UPDATE DepositoFacturas SET Nulo='" + ChkNulo.Tag.ToString + "' WHERE IDDepositoFacturas= (" + txtIDDeposito.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDDeposito.Text = "" Then
            MessageBox.Show("No hay un registro de depósito de factura abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea desactivar el registro de depósito de factura?", "Desactivar Depósito de factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ChkNulo.Checked = True
                sqlQ = "UPDATE DepositoFacturas SET Nulo='" + ChkNulo.Tag.ToString + "' WHERE IDDepositoFacturas= (" + txtIDDeposito.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub ImprimirDocumento()

        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDDeposito.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el registro de depósito de facturas?", "Imprimir Depósito de factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If

    End Sub
    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarCliente.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Sub RefrescarTablaFacturasDepositadas()
        Try
            DgvFacturaDepositadas.Rows.Clear()
            ConMixta.Open()

            Dim CmdFacts As New MySqlCommand("SELECT IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.Fecha,FacturaDatos.FechaVencimiento,Balance,Cargos,idDepositoFacturaDetalle FROM" & SysName.Text & "DepositoFacturaDetalle INNER JOIN" & SysName.Text & "FacturaDatos ON DepositoFacturaDetalle.IDFactura=FacturaDatos.IDFacturaDatos WHERE IDDepositoFactura='" + txtIDDeposito.Text + "'", ConMixta)
            Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader

            While LectorFacturas.Read
                DgvFacturaDepositadas.Rows.Add(LectorFacturas.GetValue(6), LectorFacturas.GetValue(0), "Documento: " & vbNewLine & LectorFacturas.GetValue(1), "Fecha: " & LectorFacturas.GetValue(2) & vbNewLine & "Vencimiento: " & LectorFacturas.GetValue(3), "Balance: " & CDbl(LectorFacturas.GetValue(4)).ToString("C") & vbNewLine & "Cargos: " & CDbl(LectorFacturas.GetValue(5)).ToString())
            End While

            LectorFacturas.Close()
            ConMixta.Close()

            EliminarFilas()
            ContarFilas()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub EliminarFilas()
        For Each Row As DataGridViewRow In DgvFacturasPendientes.Rows
            For Each rw As DataGridViewRow In DgvFacturaDepositadas.Rows
                If Row.Cells(0).Value = rw.Cells(1).Value Then
                    DgvFacturasPendientes.Rows.Remove(Row)
                End If
            Next
        Next
    End Sub
End Class