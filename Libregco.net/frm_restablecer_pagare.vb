Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_restablecer_pagare

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblNulo, IDEmpleadoCheck As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_restablecer_pagare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        ColumnasDgvPagares()
        ColumnasDgvPagaresProcesar()
        ActualizarTodo()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ColumnasDgvPagaresProcesar()
        DgvPagaresProcesar.Columns.Clear()
        With DgvPagaresProcesar
            .Columns.Add("IDPagare", "Pagaré") '0
            .Columns.Add("NoPagare", "No.") '1
            .Columns.Add("Vencimiento", "Vencimiento") '2
            .Columns.Add("DiasVencidos", "Días") '3
            .Columns.Add("Monto", "Monto") '4
            .Columns.Add("Balance", "Balance") '5
        End With
        PropiedadDgvPagaresProcesar()

    End Sub

    Private Sub PropiedadDgvPagaresProcesar()
        With DgvPagaresProcesar
            .Columns(0).Width = 80
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            .Columns(1).Width = 45
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).Width = 90
            .Columns(2).DefaultCellStyle.Format = "yyyy-MM-dd"
            .Columns(3).Width = 50
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).Width = 100
            .Columns(4).DefaultCellStyle.Format = "C"
            .Columns(5).Visible = False
        End With

    End Sub

    Private Sub ColumnasDgvPagares()
        DgvPagares.Columns.Clear()
        With DgvPagares
            .Columns.Add("IDPagare", "ID") '0
            .Columns.Add("NoPagare", "No.") '1
            .Columns.Add("Vencimiento", "Vencimiento") '2
            .Columns.Add("DiasVencidos", "Días") '3
            .Columns.Add("Monto", "Monto") '4
            .Columns.Add("Balance", "Balance") '5
        End With
        PropiedadDgvPagares()
    End Sub

    Private Sub PropiedadDgvPagares()
        With DgvPagares
            .Columns(0).Width = 90
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            .Columns(1).Width = 120
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).Width = 100
            .Columns(2).DefaultCellStyle.Format = "yyyy-MM-dd"
            .Columns(3).Width = 50
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).Width = 110
            .Columns(4).DefaultCellStyle.Format = "C"
            .Columns(5).Width = 110
            .Columns(5).DefaultCellStyle.Format = "C"
        End With

    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        LimpiarTodo()
        txtFecha.Text = Today
        lblStatusBar.Text = "Listo"
        lblNulo.Text = 0
        HabilitarIntroduccion()
    End Sub

    Private Sub HabilitarControles()
        DgvPagares.Enabled = True
        DgvPagaresProcesar.Enabled = True
    End Sub

    Sub DeshabilitarControles()
        DgvPagares.Enabled = False
        DgvPagaresProcesar.Enabled = False
    End Sub

    Sub SelectUsuario()
        Try

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]"
            Con.Close()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub LimpiarTodo()
        txtIDListaPagare.Clear()
        txtSecondID.Clear()
        txtFecha.Clear()
        txtIDCobrador.Clear()
        txtCobrador.Clear()
        txtIDCliente.Clear()
        txtCliente.Clear()
        DgvPagares.Rows.Clear()
        DgvPagaresProcesar.Rows.Clear()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarTodo()
        ActualizarTodo()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
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

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=48", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE ListaPagares SET SecondID='" + lblSecondID.Text + "' WHERE IDControlPagares='" + txtIDListaPagare.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=48"
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
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub UltLista()
        If txtIDListaPagare.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDControlPagares from ListaPagares where IDControlPagares= (Select Max(IDControlPagares) from ListaPagares)", Con)
            txtIDListaPagare.Text = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()
        End If
    End Sub

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            lblNulo.Text = 1
            DeshabilitarControles()
        Else
            lblNulo.Text = 0
            HabilitarControles()
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDListaPagare.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el registro de restablecimiento de pagarés?", "Imprimir titulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_lista_cobros.ShowDialog(Me)
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay()
    End Sub

    Sub LeerPagares()
        DgvPagares.Rows.Clear()

        Con.Open()
        Dim CmdFacts As New MySqlCommand("SELECT IDPagare,Concat(NoPagare,'/',Cantidad),Pagares.FechaVencimiento,Pagares.DiasVencidos,Monto,Pagares.Balance FROM pagares INNER JOIN FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos Where IDCliente='" + txtIDCliente.Text + "' and IDEmpleado='" + txtIDCobrador.Text + "' and IDListaPagare>0 and FacturaDatos.Nulo=0 Order BY FechaVencimiento ASC", Con)

        Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader
        While LectorFacturas.Read
            DgvPagares.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), CDate(LectorFacturas.GetValue(2)).ToString("dd/MM/yyyy"), LectorFacturas.GetValue(3), LectorFacturas.GetValue(4), LectorFacturas.GetValue(5))
        End While
        LectorFacturas.Close()
        Con.Close()

        RemoveInProccesed()
        lblCantEncontrada.Text = DgvPagares.Rows.Count


    End Sub

    Private Sub RemoveInProccesed()
        Try
            For Each RowProcesado As DataGridViewRow In DgvPagaresProcesar.Rows
                For Each RowPagare As DataGridViewRow In DgvPagares.Rows
                    If RowProcesado.Cells(0).Value = RowPagare.Cells(0).Value Then
                        DgvPagares.Rows.Remove(RowPagare)
                    End If
                Next
            Next
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub btnTraspasar_Click(sender As Object, e As EventArgs) Handles btnTraspasar.Click
        If DgvPagares.Rows.Count > 0 Then
            DgvPagaresProcesar.Rows.Add(DgvPagares.CurrentRow.Cells(0).Value, DgvPagares.CurrentRow.Cells(1).Value, CDate(DgvPagares.CurrentRow.Cells(2).Value).ToShortDateString, DgvPagares.CurrentRow.Cells(3).Value, DgvPagares.CurrentRow.Cells(4).Value, DgvPagares.CurrentRow.Cells(5).Value)
            DgvPagares.Rows.Remove(DgvPagares.CurrentRow)

            LeerPagares()

            lblCantEncontrada.Text = DgvPagares.Rows.Count
            lblCantTransferir.Text = DgvPagaresProcesar.Rows.Count
        Else
            MessageBox.Show("No hay pagareses para traspasar.")
        End If

    End Sub

    Private Sub btnDevolver_Click(sender As Object, e As EventArgs) Handles btnDevolver.Click
        Dim IDPagare, lblBcePagare, lblLastMovimiento, LastCobrador As New Label

        If DgvPagaresProcesar.Rows.Count > 0 Then
            If txtIDListaPagare.Text = "" Then
                DgvPagares.Rows.Add(DgvPagaresProcesar.CurrentRow.Cells(0).Value, DgvPagaresProcesar.CurrentRow.Cells(1).Value, CDate(DgvPagaresProcesar.CurrentRow.Cells(2).Value).ToLongDateString, DgvPagaresProcesar.CurrentRow.Cells(3).Value, DgvPagaresProcesar.CurrentRow.Cells(4).Value, DgvPagaresProcesar.CurrentRow.Cells(5).Value)
                DgvPagaresProcesar.Rows.Remove(DgvPagaresProcesar.CurrentRow)

                LeerPagares()
            Else
                IDPagare.Text = DgvPagaresProcesar.CurrentRow.Cells(0).Value
                lblBcePagare.Text = CDbl(DgvPagaresProcesar.CurrentRow.Cells(5).Value)


                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("Select IDListado,ListaPagares.IDCobrador from movimientospagare INNER JOIN ListaPagares on MovimientosPagare.IDListado=ListaPagares.IDControlPagares where ListaPagares.Nulo=0 and IDPagare='" + IDPagare.Text + "' and IDControlPagares= (Select Max(IDControlPagares)-1 from ListaPagares)", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "movimientospagare")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("movimientospagare")
                lblLastMovimiento.Text = (Tabla.Rows(0).Item("IDListado"))
                LastCobrador.Text = (Tabla.Rows(0).Item("IDCobrador"))


                sqlQ = "UPDATE Pagares SET IDEmpleado='" + LastCobrador.Text + "',IDListaPagare='" + lblLastMovimiento.Text + "' WHERE IDPagare= '" + IDPagare.Text + "'"
                UpdateMovimientosPagares(IDPagare.Text, txtIDListaPagare.Text, 1)
                GuardarDatos()
                MessageBox.Show("Pagaré removido y restablecido correctamente.", "Operación Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Else
            MessageBox.Show("No hay pagareses transferidos para devolver.")
        End If

        DgvPagares.Sort(DgvPagares.Columns("NoPagare"), System.ComponentModel.ListSortDirection.Ascending)
        lblCantEncontrada.Text = DgvPagares.Rows.Count
        lblCantTransferir.Text = DgvPagaresProcesar.Rows.Count

    End Sub

    Private Sub btnTraspasarTodo_Click(sender As Object, e As EventArgs) Handles btnTraspasarTodo.Click
        If DgvPagares.Rows.Count > 0 Then
            For Each Row As DataGridViewRow In DgvPagares.Rows
                DgvPagaresProcesar.Rows.Add(Row.Cells(0).Value, Row.Cells(1).Value, CDate(Row.Cells(2).Value).ToShortDateString, Row.Cells(3).Value, Row.Cells(4).Value, Row.Cells(5).Value)
            Next
            DgvPagares.Rows.Clear()

            LeerPagares()

            lblCantEncontrada.Text = DgvPagares.Rows.Count
            lblCantTransferir.Text = DgvPagaresProcesar.Rows.Count
        Else
            MessageBox.Show("No hay pagareses para traspasar.")
        End If
    End Sub

    Private Sub btnDevolverTodo_Click(sender As Object, e As EventArgs) Handles btnDevolverTodo.Click
        If DgvPagaresProcesar.Rows.Count > 0 Then
            For Each Row As DataGridViewRow In DgvPagaresProcesar.Rows
                DgvPagares.Rows.Add(Row.Cells(0).Value, Row.Cells(1).Value, CDate(Row.Cells(2).Value).ToLongDateString, Row.Cells(3).Value, Row.Cells(4).Value, Row.Cells(5).Value)
            Next
            DgvPagaresProcesar.Rows.Clear()

            LeerPagares()

            lblCantEncontrada.Text = DgvPagares.Rows.Count
            lblCantTransferir.Text = DgvPagaresProcesar.Rows.Count
        Else
            MessageBox.Show("No hay pagareses transferidos para devolver.")
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If DgvPagaresProcesar.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado registros de pagares para restablecer.", "No hay pagares a procesar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDListaPagare.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar restablecer los pagarés a la base de datos?", "Generar Lista de Cobros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO ListaPagares (IDUsuario,IDTipoDocumento,IDAreaImpresion,Fecha,Hora,IDTipoCargado,Descripcion,IDCobrador,FechaVencimiento,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',48,'" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "','" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',4,'','" + txtIDCobrador.Text + "','" + Today.ToString("yyyy-MM-dd") + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltLista()
                SetSecondID()
                UpdatePagares()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la factura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE ListaPagares SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',Descripcion='',IDCobrador='" + txtIDCobrador.Text + "',FechaVencimiento='" + Today.ToString("yyyy-MM-dd") + "',Nulo='" + lblNulo.Text + "' WHERE IDControlPagares= '" + txtIDListaPagare.Text + "'"
                GuardarDatos()
                UpdatePagares()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
            End If
        End If

    End Sub

    Private Sub UpdatePagares()
        Try
            Dim IDPagare, lblBcePagare, lblLastMovimiento, LastCobrador As New Label

            If lblNulo.Text = 0 Then
                For Each Row As DataGridViewRow In DgvPagaresProcesar.Rows
                    IDPagare.Text = Row.Cells(0).Value
                    sqlQ = "UPDATE Pagares SET IDEmpleado=1,IDListaPagare='" + txtIDListaPagare.Text + "',Cargado=0 WHERE IDPagare= '" + IDPagare.Text + "'"
                    GuardarDatos()


                    UpdateMovimientosPagares(IDPagare.Text, txtIDListaPagare.Text, lblNulo.Text)

                Next
            Else
                For Each Row As DataGridViewRow In DgvPagaresProcesar.Rows
                    IDPagare.Text = Row.Cells(0).Value

                    Ds.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("Select IDListado,ListaPagares.IDCobrador from movimientospagare INNER JOIN ListaPagares on MovimientosPagare.IDListado=ListaPagares.IDControlPagares where ListaPagares.Nulo=0 and IDPagare='" + IDPagare.Text + "' and IDControlPagares= (Select Max(IDControlPagares)-1 from ListaPagares)", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "movimientospagare")
                    Con.Close()

                    Dim Tabla As DataTable = Ds.Tables("movimientospagare")
                    lblLastMovimiento.Text = (Tabla.Rows(0).Item("IDListado"))
                    LastCobrador.Text = (Tabla.Rows(0).Item("IDCobrador"))

                    sqlQ = "UPDATE Pagares SET IDEmpleado='" + LastCobrador.Text + "',IDListaPagare='" + lblLastMovimiento.Text + "',Cargado=1 WHERE IDPagare= '" + IDPagare.Text + "'"
                    GuardarDatos()

                    UpdateMovimientosPagares(IDPagare.Text, txtIDListaPagare.Text, lblNulo.Text)
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub RefrescarTablaPagares()
        Try
            If txtIDListaPagare.Text = "" Then
            Else
                DgvPagaresProcesar.Rows.Clear()
                Con.Open()
                Dim CmdFacts As New MySqlCommand("SELECT IDPagare,Concat(NoPagare,'/',Cantidad),FechaVencimiento,DiasVencidos,Monto,Pagares.Balance FROM pagares Where IDListaPagare='" + txtIDListaPagare.Text + "'", Con)
                Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader
                While LectorFacturas.Read
                    DgvPagaresProcesar.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), CDate(LectorFacturas.GetValue(2)).ToShortDateString, LectorFacturas.GetValue(3), LectorFacturas.GetValue(4), LectorFacturas.GetValue(5))
                End While
                LectorFacturas.Close()
                Con.Close()

            End If

            If DgvPagaresProcesar.Rows.Count = 0 Then
                lblStatusBar.Text = "Los pagarés que fueron restablecidos por este listado ya han sido asignados o eliminados del registro."
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub txtIDCobrador_Leave(sender As Object, e As EventArgs) Handles txtIDCobrador.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado='" + txtIDCobrador.Text + "'", Con)
        txtCobrador.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtCobrador.Text = "" Then
            txtIDCobrador.Clear()
        End If
        If IDEmpleadoCheck.Text <> txtIDCobrador.Text Then
            txtIDCliente.Clear()
            txtCliente.Clear()
            DgvPagares.Rows.Clear()
        End If

        HabilitarIntroduccion()
    End Sub

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave
        Dim IDEmpleado, Empleado As String

        ConLibregco.Open()

        cmd = New MySqlCommand("Select Nombre from Clientes Where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
        txtCliente.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        If txtCliente.Text = "" Then txtIDCliente.Clear()

        LeerPagares()
    End Sub

    Sub HabilitarIntroduccion()
        If txtIDCobrador.Text = "" Then
            txtIDCliente.Enabled = False
            btnBuscarCliente.Enabled = False
            txtIDCobrador.Enabled = True
            btnCobrador.Enabled = True
        Else
            txtIDCliente.Enabled = True
            btnBuscarCliente.Enabled = True
            txtIDCobrador.Enabled = False
            btnCobrador.Enabled = False
        End If
    End Sub

    Private Sub btnCobrador_Click(sender As Object, e As EventArgs) Handles btnCobrador.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub txtIDCobrador_Enter(sender As Object, e As EventArgs) Handles txtIDCobrador.Enter
        IDEmpleadoCheck.Text = txtIDCobrador.Text

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

End Class