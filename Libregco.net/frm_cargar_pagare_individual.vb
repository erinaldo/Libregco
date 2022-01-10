Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_cargar_pagare_individual

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim BtnIncluirAgregar, BtnIncluirRemover As New DataGridViewButtonColumn
    Dim lblNulo, IDDefaultIDCobrador As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList

    Private Sub frm_cargar_pagare_individual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        CargarConfiguracion()
        SelectUsuario()
        ActualizarTodo()
        ColumnasDgvFacturas()
        ColumnasDgvPagares()
        ColumnasDgvPagaresProcesar()
        ColumnasDgvArticulos()
    End Sub

    Private Sub CargarConfiguracion()
        Try

            Con.Open()

            'Cobrador Predeterminado
            cmd = New MySqlCommand("Select Empleados.IDEmpleado from Configuracion INNER JOIN Empleados on Configuracion.Value2Int=Empleados.IDEmpleado Where IDConfiguracion=25", Con)
            IDDefaultIDCobrador.Text = Convert.ToString(cmd.ExecuteScalar())

            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ColumnasDgvArticulos()
        With DgvArticulos
            .Columns.Add("IDArticulo", "Código") '0
            .Columns.Add("Descripcion", "Descripción") '1
            .Columns.Add("Cantidad", "Cant.") '2
        End With
        PropiedadDgvArticulos()
    End Sub

    Private Sub PropiedadDgvArticulos()
        With DgvArticulos
            .Columns(0).Width = 60
            .Columns(1).Width = 205
            .Columns(2).Width = 60
        End With
    End Sub

    Private Sub ColumnasDgvPagaresProcesar()
        DgvPagaresProcesar.Columns.Clear()
        With DgvPagaresProcesar
            .Columns.Add("IDPagare", "ID") '0
            .Columns.Add("NoPagare", "No.") '1
            .Columns.Add("Vencimiento", "Vencimiento") '2
            .Columns.Add("DiasVencidos", "Días") '3
            .Columns.Add("Monto", "Monto") '4
            .Columns.Add("Balance", "Balance") '5
            .Columns.Add(BtnIncluirRemover)
        End With
        PropiedadDgvPagaresProcesar()

    End Sub

    Private Sub ColumnasDgvFacturas()
        DgvFacturas.Columns.Clear()
        With DgvFacturas
            .Columns.Add("IDFacturaDatos", "ID") '0
            .Columns.Add("SecondID", "No. Factura") '1
            .Columns.Add("Fecha", "Fecha") '2
            .Columns.Add("Condicion", "Condición") '3

        End With
        PropiedadDgvFacturas()
    End Sub

    Private Sub PropiedadDgvFacturas()
        With DgvFacturas
            .Columns(0).Visible = False
            .Columns(1).Width = 100
            .Columns(2).Width = 85
            .Columns(3).Width = 140
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
            .Columns.Add(BtnIncluirAgregar)
        End With
        PropiedadDgvPagares()
    End Sub

    Private Sub PropiedadDgvPagaresProcesar()
        With DgvPagaresProcesar
            .Columns(0).Width = 80
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            .Columns(1).Width = 70
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).Width = 200
            .Columns(3).Width = 50
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).Width = 100
            .Columns(4).DefaultCellStyle.Format = "C"
            .Columns(5).Width = 100
            .Columns(5).DefaultCellStyle.Format = "C"
        End With

        With BtnIncluirRemover
            .Width = 60
            .UseColumnTextForButtonValue = True
            .HeaderText = "Remover"
            .Text = "Remover"
            .DefaultCellStyle.Font = New Font("Arial", 8)
            .ToolTipText = "Remover pagaré del listado."

        End With
    End Sub


    Private Sub PropiedadDgvPagares()
        With DgvPagares
            .Columns(0).Width = 80
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(0).DefaultCellStyle.BackColor = Color.LightGray

            .Columns(1).Width = 70
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).Width = 200
            .Columns(3).Width = 50
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).Width = 100
            .Columns(4).DefaultCellStyle.Format = "C"
            .Columns(5).Width = 100
            .Columns(5).DefaultCellStyle.Format = "C"
        End With

        With BtnIncluirAgregar
            .Width = 60
            .UseColumnTextForButtonValue = True
            .HeaderText = "Incluir"
            .Text = "Incluir"
            .DefaultCellStyle.Font = New Font("Arial", 8)
            .ToolTipText = "Agregar pagaré al listado."
        End With
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        LimpiarTodo()
        txtFecha.Text = Today
        lblStatusBar.Text = "Listo"
        lblCantFact.Text = ""
        lblNulo.Text = 0
        MensajeRapido()
        HabilitarIntroduccion()
    End Sub

    Private Sub HabilitarControles()
        txtIDCobrador.Enabled = True
        DgvFacturas.Enabled = True
        DgvPagares.Enabled = True
        DgvPagaresProcesar.Enabled = True
    End Sub

    Sub DeshabilitarControles()
        txtIDCobrador.Enabled = False
        DgvFacturas.Enabled = False
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
        txtDescripcion.Clear()
        txtIDCliente.Clear()
        txtCliente.Clear()
        DgvFacturas.Rows.Clear()
        DgvPagares.Rows.Clear()
        DgvArticulos.Rows.Clear()
        DgvPagaresProcesar.Rows.Clear()
    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub RefrescarFacturas()
        Try
            If txtIDCliente.Text <> "" Then
                DgvArticulos.Rows.Clear()
                DgvPagares.Rows.Clear()
                DgvFacturas.Rows.Clear()

                ConMixta.Open()
                Dim CmdFacts As New MySqlCommand("SELECT IDFacturaDatos,SecondID,Fecha,Condicion.Condicion FROM" & SysName.Text & "facturadatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where IDCliente='" + txtIDCliente.Text + "' and Condicion.Dias>0 and FacturaDatos.Nulo=0", ConMixta)
                Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader

                While LectorFacturas.Read
                    DgvFacturas.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), CDate(LectorFacturas.GetValue(2)).ToString("dd/MM/yyyy"), LectorFacturas.GetValue(3))
                End While
                LectorFacturas.Close()
                ConMixta.Close()

                lblCantFact.Text = "Facturas Encontradas: " & DgvFacturas.Rows.Count
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try

    End Sub

    Private Sub DgvFacturas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFacturas.CellClick
        Try
            If e.RowIndex >= 0 Then
                If e.ColumnIndex = 6 Then
                    DgvFacturas.EditMode = DataGridViewEditMode.EditOnEnter
                    LeerPagares()
                End If
            End If

        Catch ex As Exception

        End Try
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

    Private Sub DgvPagares_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPagares.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 6 Then

                For Each rw As DataGridViewRow In DgvPagares.Rows
                    If DgvPagares.CurrentRow.Cells(0).Value <> rw.Cells(0).Value Then
                        If CDate(rw.Cells(2).Value) < CDate(DgvPagares.CurrentRow.Cells(2).Value) Then
                            Dim Result As MsgBoxResult = MessageBox.Show("Usted ha seleccionado un pagaré que no corresponde al orden obligatorio de los mismos." & vbNewLine & vbNewLine & "Está seguro que desea seleccionarlo?" & vbNewLine & vbNewLine & "Pagaré seleccionado: " & DgvPagares.CurrentRow.Cells(1).Value.ToString & " de fecha " & CDate(DgvPagares.CurrentRow.Cells(2).Value.ToString) & vbNewLine & "Pagaré en ordén: " & rw.Cells(1).Value & " de fecha " & CDate(rw.Cells(2).Value.ToString), "Selección de pagaré fuera de orden", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If Result = MsgBoxResult.Yes Then
                                frm_superclave.IDAccion.Text = 113
                                frm_superclave.ShowDialog(Me)

                                If ControlSuperClave = 1 Then
                                    Exit Sub

                                End If

                            Else
                                Exit Sub
                            End If
                        End If
                    End If

                Next

                DgvPagaresProcesar.Rows.Add(DgvPagares.CurrentRow.Cells(0).Value, DgvPagares.CurrentRow.Cells(1).Value, DgvPagares.CurrentRow.Cells(2).Value, DgvPagares.CurrentRow.Cells(3).Value, DgvPagares.CurrentRow.Cells(4).Value, DgvPagares.CurrentRow.Cells(5).Value)
                DgvPagares.Rows.Remove(DgvPagares.CurrentRow)
            End If
        End If
    End Sub

    Private Sub DgvPagaresProcesar_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPagaresProcesar.CellClick
        Dim IDPagare, lblBcePagare, lblLastMovimiento, LastCobrador As New Label

        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 6 Then
                If txtIDListaPagare.Text = "" Then
                    DgvPagaresProcesar.Rows.Remove(DgvPagaresProcesar.CurrentRow)
                Else
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el pagaré código " & DgvPagaresProcesar.CurrentRow.Cells(0).Value & " del cobrador [" & txtIDCobrador.Text & "] " & txtCobrador.Text & " de la base de datos?", "Eliminar Pagaré Procesado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then

                        IDPagare.Text = DgvPagaresProcesar.CurrentRow.Cells(0).Value
                        lblBcePagare.Text = CDbl(DgvPagaresProcesar.CurrentRow.Cells(5).Value)

                        If CDbl(lblBcePagare.Text) = 0 Then
                            MessageBox.Show("No ha sido posible reestablecer el pagaré ya que se han emitido débitos y/o su balance es 0.", "Pagaré ya ha sido pagado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                        Ds.Clear()
                        Con.Open()
                        cmd = New MySqlCommand("Select IDListado, ListaPagares.IDCobrador from movimientospagare INNER JOIN ListaPagares on MovimientosPagare.IDListado=ListaPagares.IDControlPagares where ListaPagares.Nulo=0 And IDPagare='" + IDPagare.Text + "' and IDControlPagares= (Select Max(IDControlPagares)-1 from ListaPagares)", Con)
                            Adaptador = New MySqlDataAdapter(cmd)
                        Adaptador.Fill(Ds, "movimientospagare")
                        Con.Close()

                        Dim Tabla As DataTable = Ds.Tables("movimientospagare")
                        If Tabla.Rows.Count = 0 Then
                            sqlQ = "UPDATE Pagares SET IDEmpleado='" + IDDefaultIDCobrador.Text + "',IDListaPagare=NULL,Cargado=0 WHERE IDPagare= '" + IDPagare.Text + "'"
                            GuardarDatos()
                        Else
                            lblLastMovimiento.Text = (Tabla.Rows(0).Item("IDListado"))
                            LastCobrador.Text = (Tabla.Rows(0).Item("IDCobrador"))

                            sqlQ = "UPDATE Pagares SET IDEmpleado='" + LastCobrador.Text + "',IDListaPagare='" + lblLastMovimiento.Text + "',Cargado=1 WHERE IDPagare= '" + IDPagare.Text + "'"
                            GuardarDatos()

                        End If

                        UpdateMovimientosPagares(IDPagare.Text, txtIDListaPagare.Text, 1)
                        DgvPagaresProcesar.Rows.Remove(DgvPagaresProcesar.CurrentRow)
                        MessageBox.Show("Pagaré removido y restablecido correctamente.", "Operación Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    End If
                End If
                LeerPagares()
            End If

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

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub UpdatePagares()
        Try
            Dim IDPagare, lblBcePagare, lblLastMovimiento, LastCobrador As New Label


            If lblNulo.Text = 0 Then
                For Each Row As DataGridViewRow In DgvPagaresProcesar.Rows
                    IDPagare.Text = Row.Cells(0).Value
                    sqlQ = "UPDATE Pagares SET IDEmpleado='" + txtIDCobrador.Text + "',IDListaPagare='" + txtIDListaPagare.Text + "',Cargado=1 WHERE IDPagare= '" + IDPagare.Text + "'"
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
                    If Tabla.Rows.Count = 0 Then
                        sqlQ = "UPDATE Pagares SET IDEmpleado='" + IDDefaultIDCobrador.Text + "',IDListaPagare=NULL,Cargado=0 WHERE IDPagare= '" + IDPagare.Text + "'"
                        GuardarDatos()
                    Else
                        lblLastMovimiento.Text = (Tabla.Rows(0).Item("IDListado"))
                        LastCobrador.Text = (Tabla.Rows(0).Item("IDCobrador"))


                        sqlQ = "UPDATE Pagares SET IDEmpleado='" + LastCobrador.Text + "',IDListaPagare='" + lblLastMovimiento.Text + "',Cargado=1 WHERE IDPagare= '" + IDPagare.Text + "'"
                        GuardarDatos()
                    End If

                    UpdateMovimientosPagares(IDPagare.Text, txtIDListaPagare.Text, lblNulo.Text)

                Next
            End If

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

            cmd = New MySqlCommand("Select SecondID from ListaPagares where IDControlPagares= (Select Max(IDControlPagares) from ListaPagares)", Con)
            txtSecondID.Text = Convert.ToString(cmd.ExecuteScalar())

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

    Sub RefrescarTablaPagares()
        Try
            If txtIDListaPagare.Text = "" Then
            Else
                DgvPagaresProcesar.Rows.Clear()
                Con.Open()
                Dim CmdFacts As New MySqlCommand("SELECT IDPagare,Concat(NoPagare,'/',Cantidad),FechaVencimiento,DiasVencidos,Monto,Pagares.Balance FROM pagares Where IDListaPagare='" + txtIDListaPagare.Text + "'", Con)
                Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader
                While LectorFacturas.Read
                    DgvPagaresProcesar.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), CDate(LectorFacturas.GetValue(2)).ToLongDateString, LectorFacturas.GetValue(3), LectorFacturas.GetValue(4), LectorFacturas.GetValue(5))
                End While
                LectorFacturas.Close()
                Con.Close()

                PropiedadDgvPagaresProcesar()

                If DgvPagaresProcesar.Rows.Count = 0 Then
                    lblStatusBar.Text = "Algunos pagarés registrados en este listado ya han sido re-asignados o eliminados del registro."
                End If

            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay()
    End Sub

    Private Sub DgvFacturas_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvFacturas.RowPostPaint
        Try
            LeerPagares()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LeerPagares()
        If DgvFacturas.Rows.Count > 0 Then
            Dim lblIDFactura As New Label
            lblIDFactura.Text = DgvFacturas.CurrentRow.Cells(0).Value

            DgvPagares.Rows.Clear()
            Con.Open()
            Dim CmdFacts As New MySqlCommand("SELECT IDPagare,Concat(NoPagare,'/',Cantidad),FechaVencimiento,DiasVencidos,Monto,Pagares.Balance FROM pagares Where Pagares.Balance>0 and Pagares.Cargado=0 and Pagares.IDFactura='" + lblIDFactura.Text + "' ORDER BY FechaVencimiento ASC", Con)
            Dim LectorPagare As MySqlDataReader = CmdFacts.ExecuteReader

            While LectorPagare.Read
                DgvPagares.Rows.Add(LectorPagare.GetValue(0), LectorPagare.GetValue(1), CDate(LectorPagare.GetValue(2)).ToLongDateString, LectorPagare.GetValue(3), LectorPagare.GetValue(4), LectorPagare.GetValue(5))
            End While
            LectorPagare.Close()
            Con.Close()
        
            RemoveInProccesed()
            LeerArticulos()
            MarcarVencidas()
        End If
    End Sub

    Private Sub LeerArticulos()
        Try
            If DgvFacturas.Rows.Count > 0 Then
                Dim lblIDFactura As New Label
                lblIDFactura.Text = DgvFacturas.CurrentRow.Cells(0).Value

                DgvArticulos.Rows.Clear()
                Con.Open()
                Dim CMDArts As New MySqlCommand("SELECT IDArticulo,Descripcion,Concat(Cantidad,' ',Medida) FROM facturaarticulos Where IDFactura='" + lblIDFactura.Text + "'", Con)
                Dim LectorArticulos As MySqlDataReader = CMDArts.ExecuteReader

                While LectorArticulos.Read
                    DgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2))
                End While
                LectorArticulos.Close()
                Con.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub MarcarVencidas()
        For Each Row As DataGridViewRow In DgvPagares.Rows
            If CDate(Row.Cells(2).Value) < Today Then
                Row.Cells(2).Style.ForeColor = Color.Red
                Row.Cells(2).Style.Font = New Font("Arial", 9, FontStyle.Bold Or FontStyle.Underline)
            End If
        Next
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If DgvPagaresProcesar.Rows.Count > 0 Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario de titulación individual?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                LimpiarTodo()
                ActualizarTodo()
            End If
        Else
            LimpiarTodo()
            ActualizarTodo()
        End If
     
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=33", Con)
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

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=33"
            GuardarDatos()

        Catch ex As Exception

      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCobrador.Text = "" Then
            MessageBox.Show("Seleccione el cobrador.", "Elegir Cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDCobrador.Focus()
            btnCobrador.PerformClick()
            Exit Sub
        ElseIf DgvPagaresProcesar.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado registros de pagares para cargarlos al cobrador [" & txtIDCobrador.Text & "] " & txtCobrador.Text & ".", "No hay pagares a procesar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtDescripcion.Text = "" Then
            MessageBox.Show("Escriba una breve descripción de la titulación o seleccione el tipo de titulación en la opción Descripción Rápida.", "Descripción vacía", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        End If

        If txtIDListaPagare.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar la lista de pagares del cobrador [" & txtIDCobrador.Text & "] " & txtCobrador.Text & " de la base de datos?", "Generar Lista de Cobros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO ListaPagares (IDUsuario,IDTipoDocumento,IDAreaImpresion,Fecha,Hora,IDTipoCargado,Descripcion,IDCobrador,FechaVencimiento,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',33,'" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "','" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',2,'" + txtDescripcion.Text + "','" + txtIDCobrador.Text + "','" + Today.ToString("yyyy-MM-dd") + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltLista()
                SetSecondID()
                UpdatePagares()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                'DeshabilitarControles()
                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la factura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE ListaPagares SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',Descripcion='" + txtDescripcion.Text + "',IDCobrador='" + txtIDCobrador.Text + "',FechaVencimiento='" + Today.ToString("yyyy-MM-dd") + "',Nulo='" + lblNulo.Text + "' WHERE IDControlPagares= '" + txtIDListaPagare.Text + "'"
                GuardarDatos()
                UpdatePagares()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                'DeshabilitarControles()
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDListaPagare.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el registro de titulacion individualizada?", "Imprimir titulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_lista_cobros.ShowDialog(Me)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La lista de cobros del cobrador [" & txtIDCobrador.Text & "] " & txtCobrador.Text & " No. " & txtIDListaPagare.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Lista de Cobros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                ChkNulo.Checked = False
                sqlQ = "UPDATE ListaPagares SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',Descripcion='" + txtDescripcion.Text + "',IDCobrador='" + txtIDCobrador.Text + "',FechaVencimiento='" + Today.ToString("yyyy-MM-dd") + "',Nulo='" + lblNulo.Text + "' WHERE IDControlPagares= '" + txtIDListaPagare.Text + "'"
                GuardarDatos()
                UpdatePagares()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDListaPagare.Text = "" Then
            MessageBox.Show("No hay un registro de cargado de pagaré abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular la lista de cobros del cobrador [" & txtIDCobrador.Text & "] " & txtCobrador.Text & " No. " & txtIDListaPagare.Text & "  del sistema?", "Anular Lista de Cobros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ChkNulo.Checked = True
                sqlQ = "UPDATE ListaPagares SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',Descripcion='" + txtDescripcion.Text + "',IDCobrador='" + txtIDCobrador.Text + "',FechaVencimiento='" + Today.ToString("yyyy-MM-dd") + "',Nulo='" + lblNulo.Text + "' WHERE IDControlPagares= '" + txtIDListaPagare.Text + "'"
                GuardarDatos()
                UpdatePagares()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub DgvPagares_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPagares.CellEndEdit
        DgvPagares.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvPagares_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvPagares.CurrentCellDirtyStateChanged
        If DgvPagares.IsCurrentCellDirty Then
            DgvPagares.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvPagaresProcesar_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPagaresProcesar.CellEndEdit
        DgvPagaresProcesar.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvPagaresProcesar_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvPagaresProcesar.CurrentCellDirtyStateChanged
        If DgvPagaresProcesar.IsCurrentCellDirty Then
            DgvPagaresProcesar.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub txtIDCobrador_Leave(sender As Object, e As EventArgs) Handles txtIDCobrador.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado='" + txtIDCobrador.Text + "'", Con)
        txtCobrador.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtCobrador.Text = "" Then txtIDCobrador.Clear()

        HabilitarIntroduccion()

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

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave
        Dim IDEmpleado, Empleado As String

        Con.Open()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Nombre from Clientes Where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
        txtCliente.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("Select IDEmpleado from Clientes Where IDCliente='" + txtIDCliente.Text + "'", Con)
        IDEmpleado = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado='" + IDEmpleado + "'", Con)
        Empleado = Convert.ToString(cmd.ExecuteScalar())

        Con.Close()
        ConLibregco.Close()

        If txtCliente.Text <> "" Then
            If IDEmpleado <> txtIDCobrador.Text Then
                MessageBox.Show("[" & txtIDCliente.Text & "] " & txtCliente.Text & " esta asignado para el cobrador [" & IDEmpleado & "] " & Empleado & "." & vbNewLine & vbNewLine & "Por tal motivo no es elegible para una titulación para el cobrador [" & txtIDCobrador.Text & "] " & txtCobrador.Text & ".", "Cobrador no coincide", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtIDCliente.Clear()
                txtCliente.Clear()
            End If
        Else
            DgvFacturas.Rows.Clear()
            DgvArticulos.Rows.Clear()
        End If

        If txtCliente.Text = "" Then txtIDCliente.Clear()

        RefrescarFacturas()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
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
        ImprimirDocumento()
    End Sub

    Private Sub MensajeRapido()
        If txtIDListaPagare.Text = "" Then
            If RadioButton1.Checked = True Then
                txtDescripcion.Text = "Cuentas cargadas al " & Today.ToString("dd 'de' MMMM 'de' yyyy") & " por petición del cobrador."
            ElseIf RadioButton2.Checked = True Then
                txtDescripcion.Text = "Cuentas cargadas al " & Today.ToString("dd 'de' MMMM 'de' yyyy") & " por afección de cobros."
            ElseIf RadioButton3.Checked = True Then
                txtDescripcion.Text = "Cargo de pagarés a cuentas del cobrador post-cierre del mes de " & Today.ToString("MMMM 'de' yyyy") & "."
            End If
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        MensajeRapido()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        MensajeRapido()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        MensajeRapido()
    End Sub
End Class