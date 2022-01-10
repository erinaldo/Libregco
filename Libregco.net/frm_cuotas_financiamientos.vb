Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Imports System.Drawing.Printing
Public Class frm_cuotas_financiamientos
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Friend CambiarFecha, LimitarDescuentos, LimiteMaximoDescuento, PermitirPagosTarjeta As String
    Dim HeaderIncluir As New CheckBox
    Friend lblTotalAbono, lblDescuento, lblIDTransaccion, DiasPeriodoPago As New Label
    Friend AplicarExoneracionProntoPago As Boolean = False


    Private Sub frm_cuotas_financiamientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        CargarConfiguracion()
        AddHeaderCheckBox()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Function VScrollBarVisible() As Boolean
        Dim ctrl As New Control
        For Each ctrl In DgvCuotas.Controls
            If ctrl.GetType() Is GetType(VScrollBar) Then
                If ctrl.Visible = True Then
                    Return True
                Else
                    Return False
                End If
            End If
        Next
        Return Nothing

    End Function

    Private Sub AddHeaderCheckBox()
        HeaderIncluir = New CheckBox()
        HeaderIncluir.Name = "HeaderIncluir"
        HeaderIncluir.Size = New Size(14, 14)
        HeaderIncluir.ThreeState = False
        HeaderIncluir.FlatStyle = FlatStyle.Standard
        DgvCuotas.Controls.Add(HeaderIncluir)

        AddHandler HeaderIncluir.CheckedChanged, AddressOf HeaderIncluir_CheckedChanged
    End Sub

    Sub MarcarFactsVencidas()

        For Each Row As DataGridViewRow In DgvCuotas.Rows
            If CDate(Row.Cells(3).Value) < Today Then
                Row.Cells(3).Style.ForeColor = Color.Red
                Row.Cells(3).Style.Font = New Font("Segoe UI", 9, FontStyle.Regular Or FontStyle.Underline)
            End If
        Next

    End Sub

    Private Sub DgvCuotas_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvCuotas.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvCuotas.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvCuotas.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvCuotas.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CheckCargos()
        Dim CargosAcumulados As Double = 0
        Dim DatagridWidth As Double = (DgvCuotas.Width - DgvCuotas.RowHeadersWidth) / 100

        For Each row As DataGridViewRow In DgvCuotas.Rows
            CargosAcumulados = CDbl(row.Cells(7).Value) + CargosAcumulados

            If CDbl(row.Cells(7).Value) > 0 Then
                row.Cells(11).ReadOnly = False
            Else
                row.Cells(11).ReadOnly = True
            End If
        Next

        If CargosAcumulados = 0 Then
            DgvCuotas.Columns(7).Visible = False
            DgvCuotas.Columns(11).Visible = False
            DgvCuotas.Columns(14).Visible = False
            DgvCuotas.Columns(2).Width = 80
            DgvCuotas.Columns(3).Width = 80
            DgvCuotas.Columns(4).Width = 110
            DgvCuotas.Columns(5).Width = 110
            DgvCuotas.Columns(6).Width = 110
            DgvCuotas.Columns(7).Width = 110
            DgvCuotas.Columns(8).Width = 110
            DgvCuotas.Columns(9).Width = 110
            DgvCuotas.Columns(10).Width = 110
            DgvCuotas.Columns(11).Width = 110
            DgvCuotas.Columns(12).Width = 110
            DgvCuotas.Columns(13).Width = 110
        Else
            DgvCuotas.Columns(7).Visible = True
            DgvCuotas.Columns(11).Visible = True
            DgvCuotas.Columns(14).Visible = True

            DgvCuotas.Columns(2).Width = 70
            DgvCuotas.Columns(3).Width = 70
            DgvCuotas.Columns(4).Width = 90
            DgvCuotas.Columns(5).Width = 90
            DgvCuotas.Columns(6).Width = 90
            DgvCuotas.Columns(7).Width = 90
            DgvCuotas.Columns(8).Width = 90
            DgvCuotas.Columns(9).Width = 90
            DgvCuotas.Columns(10).Width = 90
            DgvCuotas.Columns(11).Width = 90
            DgvCuotas.Columns(12).Width = 90
            DgvCuotas.Columns(13).Width = 90


        End If
    End Sub

    Private Sub HeaderIncluir_CheckedChanged(sender As Object, e As EventArgs)
        Try
            Dim HeaderBox As CheckBox = DirectCast(DgvCuotas.Controls.Find("HeaderIncluir", True)(0), CheckBox)
            For Each Rows As DataGridViewRow In DgvCuotas.Rows
                Rows.Cells(15).Value = HeaderBox.Checked
            Next

            If HeaderIncluir.Checked = True Then
                For Each Rows As DataGridViewRow In DgvCuotas.Rows
                    Rows.Cells(9).Value = CDbl(Rows.Cells(5).Value).ToString("C4")
                    Rows.Cells(10).Value = CDbl(Rows.Cells(6).Value).ToString("C4")
                    Rows.Cells(11).Value = CDbl(Rows.Cells(7).Value).ToString("C4")
                    Rows.Cells(16).Value = CDbl(0).ToString("C4")

                Next
            Else
                For Each Rows As DataGridViewRow In DgvCuotas.Rows
                    Rows.Cells(9).Value = CDbl(0).ToString("C4")
                    Rows.Cells(10).Value = CDbl(0).ToString("C4")
                    Rows.Cells(11).Value = CDbl(0).ToString("C4")

                    Rows.Cells(16).Value = (CDbl(Rows.Cells(8).Value) + CDbl(Rows.Cells(7).Value) - CDbl(Rows.Cells(9).Value) - CDbl(Rows.Cells(10).Value) - CDbl(Rows.Cells(11).Value) - CDbl(Rows.Cells(12).Value) - CDbl(Rows.Cells(13).Value) - CDbl(Rows.Cells(14).Value)).ToString("C4")

                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtBalanceGeneral.Clear()
        txtBalanceGeneralCargos.Clear()
        txtUltimoPago.Clear()
        txtCalificacion.Clear()
        txtConceptoPago.Clear()
        DgvCuotas.Rows.Clear()
        txtIDPagoFinanciamiento.Clear()
        txtSecondID.Clear()
        txtMontoAplicar.Clear()
        cbxFinanciamientos.DataSource = Nothing
        cbxFinanciamientos.Items.Clear()
        lblIDTransaccion.Text = ""
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        lblStatusBar.ForeColor = Color.Black
        lblStatusBar.Text = "Listo"
        ControlSuperClave = 1
        txtFecha.Value = Today.ToString("dd/MM/yyyy")
        chkNulo.Checked = False
        lblTotalAbono.Text = 0
        lblDescuento.Text = 0
        HeaderIncluir.Checked = False
        AplicarExoneracionProntoPago = False
        CheckCargos()
        btnBuscarCliente.Focus()
        Hora.Enabled = True
    End Sub
    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub CargarConfiguracion()
        Try
            Con.Open()

            'Permiso general de cambio de fechas
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=63", Con)
            CambiarFecha = Convert.ToString(cmd.ExecuteScalar())

            If CambiarFecha = 1 Then
                txtFecha.Enabled = True
                txtHora.Enabled = True
            Else
                txtFecha.Enabled = False
                txtHora.Enabled = False
            End If

            'Limitar descuentos de recibos de ingresos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=8", Con)
            LimitarDescuentos = Convert.ToString(cmd.ExecuteScalar())

            'Limite maximo descuentos de recibos de ingresos
            cmd = New MySqlCommand("Select Value3Double from Configuracion where IDConfiguracion=56", Con)
            LimiteMaximoDescuento = Convert.ToDouble(cmd.ExecuteScalar())

            'Permitir pagos con tarjeta
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=154", Con)
            PermitirPagosTarjeta = Convert.ToInt16(cmd.ExecuteScalar())

            Con.Close()

            Dim headers As New List(Of DGVMultiHeader)
            headers.Add(New DGVMultiHeader("Cuotas", NoCuota.Index, MontoCuota.Index))
            headers.Add(New DGVMultiHeader("Balances", Capital.Index, Balance.Index))
            headers.Add(New DGVMultiHeader("Aplicación de pagos", CapitalAPagar.Index, Restante.Index))
            Dim headerManager = New DGVMultiHeaderManager(DgvCuotas, headers)

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Value = DateTime.Now
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Sub FillFinanciamientos()
        Dim DsTemp As New DataSet

        cbxFinanciamientos.DataSource = Nothing
        cbxFinanciamientos.Items.Clear()

        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDFinanciamientos,SecondID FROM" & SysName.Text & "financiamientos where IDCliente='" + txtIDCliente.Text + "' ORDER BY Fecha ASC", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "financiamiento")
        cbxFinanciamientos.ValueMember = "IDFinanciamientos"
        cbxFinanciamientos.DisplayMember = "SecondID"
        cbxFinanciamientos.DataSource = DsTemp.Tables("financiamiento")
        ConMixta.Close()

        cbxFinanciamientos.Text = "Financiamientos"
    End Sub

    Private Sub cbxFinanciamientos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxFinanciamientos.SelectedIndexChanged
        If txtIDCliente.Text <> "" Then
            DgvCuotas.Rows.Clear()

            If ConMixta.State = ConnectionState.Closed Then
                ConMixta.Open()
            End If

            Dim St As String = "Select IDFinanciamientos_cuotas,NoCuota,FechaVencimiento,Monto,(Capital-(Select coalesce(sum(CapitalAplicado+DescuentosAplicado),0) from" & SysName.Text & "pagosfinanciamientos_detalles INNER JOIN" & SysName.Text & "PagosFinanciamientos on PagosFinanciamientos.IDPagosFinanciamientos=PagosFinanciamientos_detalles.IDPagosFinanciamientos Where Financiamientos_cuotas.idFinanciamientos_cuotas=pagosfinanciamientos_detalles.IDFinanciamientoCuota AND PagosFinanciamientos.Nulo=0)) as Capital,(Interes-(Select coalesce(sum(InteresAplicado+InteresExonerado),0) from" & SysName.Text & "pagosfinanciamientos_detalles INNER JOIN" & SysName.Text & "PagosFinanciamientos on PagosFinanciamientos.IDPagosFinanciamientos=PagosFinanciamientos_detalles.IDPagosFinanciamientos Where Financiamientos_cuotas.idFinanciamientos_cuotas=pagosfinanciamientos_detalles.IDFinanciamientoCuota AND PagosFinanciamientos.Nulo=0)) as Interes,(Cargo-(Select coalesce(sum(CargosAplicados+CargosExonerado),0) from" & SysName.Text & "pagosfinanciamientos_detalles INNER JOIN" & SysName.Text & "PagosFinanciamientos on PagosFinanciamientos.IDPagosFinanciamientos=PagosFinanciamientos_detalles.IDPagosFinanciamientos Where Financiamientos_cuotas.idFinanciamientos_cuotas=pagosfinanciamientos_detalles.IDFinanciamientoCuota AND PagosFinanciamientos.Nulo=0)) as Cargo,Balance FROM" & SysName.Text & "Financiamientos_cuotas WHERE IDFinanciamiento='" + cbxFinanciamientos.SelectedValue.ToString + "' and Balance>0 Order by NoCuota ASC"
            Dim Consulta As New MySqlCommand(St, ConMixta)
            Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

            While LectorArticulos.Read
                DgvCuotas.Rows.Add("", LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), CDate(LectorArticulos.GetValue(2)).ToString("dd/MM/yyyy"), CDbl(LectorArticulos.GetValue(3)).ToString("C4"), CDbl(LectorArticulos.GetValue(4)).ToString("C4"), CDbl(LectorArticulos.GetValue(5)).ToString("C4"), CDbl(LectorArticulos.GetValue(6)).ToString("C4"), CDbl(LectorArticulos.GetValue(7)).ToString("C4"), CDbl(0).ToString("C4"), CDbl(0).ToString("C4"), CDbl(0).ToString("C4"), CDbl(0).ToString("C4"), CDbl(0).ToString("C4"), CDbl(0).ToString("C4"), False, CDbl(LectorArticulos.GetValue(7)).ToString("C4"))
            End While

            LectorArticulos.Close()

            If ConMixta.State = ConnectionState.Open Then
                ConMixta.Close()
            End If

            MarcarFactsVencidas()
            CheckCargos()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub VerificarFechaSistema()
        Dim CurrentDate As New Date
        Con.Open()
        cmd = New MySqlCommand("SELECT CURDATE()", Con)
        CurrentDate = Convert.ToDateTime(cmd.ExecuteScalar())
        Con.Close()

        If Today <> CurrentDate Then
            MessageBox.Show("Existe un conflicto entre la fecha actual del equipo y la fecha del servidor." & vbNewLine & vbNewLine & "Por favor verifique la fecha del equipo o la del servidor para acceder al sistema.", "Diferencias en fechas", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Application.Exit()
        End If

    End Sub

    Private Sub CompararEntradas()
        Dim AplicadoValue As Double = 0
        For Each Rows As DataGridViewRow In DgvCuotas.Rows
            AplicadoValue = AplicadoValue + CDbl(Rows.Cells(9).Value) + CDbl(Rows.Cells(10).Value) + CDbl(Rows.Cells(11).Value)
        Next

        If txtMontoAplicar.Text = "" Then
            txtMontoAplicar.Text = AplicadoValue.ToString("C4")
        ElseIf AplicadoValue <> CDbl(txtMontoAplicar.Text) Then
            txtMontoAplicar.Text = AplicadoValue.ToString("C4")
        End If
    End Sub


    Private Sub VerificarSaldosconCargos()
        For Each row As DataGridViewRow In DgvCuotas.Rows
            If CDbl(row.Cells(7).Value) > 0 Then
                If CDbl(row.Cells(14).Value) > 0 Then
                    MessageBox.Show("Se ha detectado que desea eliminar y/o ajustar los cargos acumulados por el vencimiento de la cuota " & row.Cells(2).Value & " vencida en fecha " & row.Cells(3).Value & "." & vbNewLine & vbNewLine & "Por favor ingrese la superclave para continuar con el procedimiento.", "Control de modificación de cargos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    frm_superclave.IDAccion.Text = 109
                    frm_superclave.ShowDialog(Me)
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If
            End If
        Next

        ControlSuperClave = 0
    End Sub


    Private Sub VerificarSaldos()
        Dim IDCuota, Fecha As String

        For Each row As DataGridViewRow In DgvCuotas.Rows
            If CDbl(row.Cells(16).Value) = 0 Then
                IDCuota = row.Cells(1).Value
                Fecha = CDate(row.Cells(3).Value)

                For Each Rw As DataGridViewRow In DgvCuotas.Rows
                    If Rw.Cells(1).Value <> IDCuota Then
                        If CDbl(Rw.Cells(16).Value) > 0 And CDate(Rw.Cells(3).Value) < Fecha Then
                            Dim Result1 As MsgBoxResult = MessageBox.Show("Se ha encontrado una o más cuotas de mayor antigüedad que no son afectada en el actual recibo de ingreso." & vbNewLine & vbNewLine & "Recomendación" & vbNewLine & vbNewLine & "Factura: " & Rw.Cells(2).Value & " de fecha " & Rw.Cells(4).Value & vbNewLine & vbNewLine & "Recomendamos aplicar el pago a la factura en orden de antiguedad." & vbNewLine & vbNewLine & "¿Está seguro que desea proceder el recibo de ingreso?", "Hay factura antigua", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            If Result1 = MsgBoxResult.Yes Then
                                frm_superclave.IDAccion.Text = 96
                                frm_superclave.ShowDialog(Me)
                                If ControlSuperClave = 1 Then
                                    Exit Sub
                                End If
                            Else
                                ControlSuperClave = 1
                                Exit Sub
                            End If
                        End If
                    End If
                Next
            End If
        Next

        ControlSuperClave = 0
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDPagoFinanciamiento.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el recibo de pagos de las cuotas de financiamiento?", "Imprimir recibo de financiamiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub DgvCuotass_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvCuotas.CellPainting
        If e.RowIndex = -1 AndAlso e.ColumnIndex = 15 Then
            ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex)
        End If
    End Sub

    Private Sub ResetHeaderCheckBoxLocation(ByVal ColumnIndex As Integer, ByVal RowIndex As Integer)
        Dim Rect As Rectangle = DgvCuotas.GetCellDisplayRectangle(ColumnIndex, RowIndex, True)
        Dim Pt As New Point()
        Pt.X = Rect.Location.X + (Rect.Width - HeaderIncluir.Width) \ 2 + 1
        Pt.Y = Rect.Location.Y + (Rect.Height - HeaderIncluir.Height) \ 2 + 1
        HeaderIncluir.Location = Pt
    End Sub

    Private Sub DgvCuotas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCuotas.CellEndEdit
        DgvCuotas.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = DgvCuotas.CurrentCell.ColumnIndex

        If Columna = 9 Or Columna = 10 Or Columna = 11 Or Columna = 12 Then
            Dim Caracter As Char = e.KeyChar
            Dim Txt As TextBox = CType(sender, TextBox)

            If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") And (Txt.Text.Contains(",") = False) Then

                e.Handled = False
            Else
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub DgvCuotas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvCuotas.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)
        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub DgvCuotas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCuotas.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 9 Or e.ColumnIndex = 10 Or e.ColumnIndex = 11 Or e.ColumnIndex = 12 Then
                DgvCuotas.EditMode = DataGridViewEditMode.EditOnEnter
            End If
        End If

    End Sub

    Private Sub DgvCuotas_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvCuotas.CurrentCellDirtyStateChanged
        If DgvCuotas.IsCurrentCellDirty Then
            DgvCuotas.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            DeshabilitarControles()
        Else
            HabilitarControles()
        End If
    End Sub

    Sub DeshabilitarControles()
        GbAplicado.Enabled = False
        DgvCuotas.Enabled = False
        cbxFinanciamientos.Enabled = False
        txtConceptoPago.Enabled = False
        btnGuardarC.Enabled = False
        btnBuscarCliente.Enabled = False
    End Sub

    Sub HabilitarControles()
        GbAplicado.Enabled = True
        DgvCuotas.Enabled = True
        txtConceptoPago.Enabled = True
        cbxFinanciamientos.Enabled = True
        btnGuardarC.Enabled = True
        btnBuscarCliente.Enabled = True
    End Sub

    Private Sub SumarDescuentos()
        Dim y As Integer = 0
        Dim Descuento As Double

Inicio:
        If y = DgvCuotas.Rows.Count Then
            GoTo Fin

        End If

        Descuento = Descuento + CDbl(DgvCuotas.Rows(y).Cells(12).Value) + CDbl(DgvCuotas.Rows(y).Cells(13).Value) + CDbl(DgvCuotas.Rows(y).Cells(14).Value)
        y = y + 1
        GoTo Inicio
Fin:
        lblDescuento.Text = Descuento
        lblTotalAbono.Text = CDbl(txtMontoAplicar.Text) + CDbl(lblDescuento.Text)

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
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

    Private Sub BuscarFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarFacturaToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub DgvCuotas_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCuotas.CellValueChanged
        If DgvCuotas.Rows.Count > 0 Then
            Try
                If e.ColumnIndex = 9 Then
                    If CDbl(DgvCuotas.CurrentRow.Cells(9).Value) + CDbl(DgvCuotas.CurrentRow.Cells(12).Value) > CDbl(DgvCuotas.CurrentRow.Cells(5).Value) Then
                        DgvCuotas.CurrentRow.Cells(9).Value = CDbl(CDbl(DgvCuotas.CurrentRow.Cells(5).Value) - CDbl(DgvCuotas.CurrentRow.Cells(12).Value)).ToString("C4")
                    Else
                        DgvCuotas.CurrentRow.Cells(9).Value = CDbl(DgvCuotas.CurrentRow.Cells(9).Value).ToString("C4")
                    End If

                    DgvCuotas.CurrentRow.Cells(16).Value = CDbl(CDbl(DgvCuotas.CurrentRow.Cells(8).Value) - CDbl(DgvCuotas.CurrentRow.Cells(9).Value) - CDbl(DgvCuotas.CurrentRow.Cells(10).Value) - CDbl(DgvCuotas.CurrentRow.Cells(11).Value) - CDbl(DgvCuotas.CurrentRow.Cells(12).Value) - CDbl(DgvCuotas.CurrentRow.Cells(13).Value) - CDbl(DgvCuotas.CurrentRow.Cells(14).Value)).ToString("C4")
                    CompararEntradas()
                End If
            Catch ex As Exception
                DgvCuotas.CurrentRow.Cells(9).Value = CDbl(0).ToString("C4")
            End Try

            Try
                If e.ColumnIndex = 10 Then
                    If CDbl(DgvCuotas.CurrentRow.Cells(10).Value) + CDbl(DgvCuotas.CurrentRow.Cells(13).Value) > CDbl(DgvCuotas.CurrentRow.Cells(6).Value) Then
                        DgvCuotas.CurrentRow.Cells(10).Value = CDbl(CDbl(DgvCuotas.CurrentRow.Cells(6).Value) - CDbl(DgvCuotas.CurrentRow.Cells(13).Value)).ToString("C4")
                    Else
                        DgvCuotas.CurrentRow.Cells(10).Value = CDbl(DgvCuotas.CurrentRow.Cells(10).Value).ToString("C4")
                    End If

                    DgvCuotas.CurrentRow.Cells(16).Value = CDbl(CDbl(DgvCuotas.CurrentRow.Cells(8).Value) - CDbl(DgvCuotas.CurrentRow.Cells(9).Value) - CDbl(DgvCuotas.CurrentRow.Cells(10).Value) - CDbl(DgvCuotas.CurrentRow.Cells(11).Value) - CDbl(DgvCuotas.CurrentRow.Cells(12).Value) - CDbl(DgvCuotas.CurrentRow.Cells(13).Value) - CDbl(DgvCuotas.CurrentRow.Cells(14).Value)).ToString("C4")
                    CompararEntradas()
                End If
            Catch ex As Exception
                DgvCuotas.CurrentRow.Cells(10).Value = CDbl(0).ToString("C4")
            End Try



            Try
                If e.ColumnIndex = 11 Then
                    If IsNumeric(CDbl(DgvCuotas.CurrentRow.Cells(11).Value)) And CDbl(DgvCuotas.CurrentRow.Cells(7).Value) > 0 Then
                        If CDbl(CDbl(DgvCuotas.CurrentRow.Cells(11).Value) + CDbl(DgvCuotas.CurrentRow.Cells(14).Value)) > CDbl(DgvCuotas.CurrentRow.Cells(7).Value) Then
                            DgvCuotas.CurrentRow.Cells(11).Value = CDbl(CDbl(DgvCuotas.CurrentRow.Cells(7).Value) - CDbl(DgvCuotas.CurrentRow.Cells(14).Value)).ToString("C4")
                        Else
                            DgvCuotas.CurrentRow.Cells(11).Value = CDbl(DgvCuotas.CurrentRow.Cells(11).Value).ToString("C4")
                        End If
                    Else
                        DgvCuotas.CurrentRow.Cells(11).Value = CDbl(0).ToString("C4")
                    End If

                    DgvCuotas.CurrentRow.Cells(16).Value = CDbl(CDbl(DgvCuotas.CurrentRow.Cells(8).Value) - CDbl(DgvCuotas.CurrentRow.Cells(9).Value) - CDbl(DgvCuotas.CurrentRow.Cells(10).Value) - CDbl(DgvCuotas.CurrentRow.Cells(11).Value) - CDbl(DgvCuotas.CurrentRow.Cells(12).Value) - CDbl(DgvCuotas.CurrentRow.Cells(13).Value) - CDbl(DgvCuotas.CurrentRow.Cells(14).Value)).ToString("C4")
                    CompararEntradas()
                End If
            Catch ex As Exception
                DgvCuotas.CurrentRow.Cells(11).Value = CDbl(0).ToString("C4")
            End Try

            Try
                If e.ColumnIndex = 12 Then
                    If IsNumeric(CDbl(DgvCuotas.CurrentRow.Cells(12).Value)) And CDbl(DgvCuotas.CurrentRow.Cells(5).Value) > 0 Then
                        If CDbl(DgvCuotas.CurrentRow.Cells(12).Value) + CDbl(DgvCuotas.CurrentRow.Cells(9).Value) > CDbl(DgvCuotas.CurrentRow.Cells(5).Value) Then
                            DgvCuotas.CurrentRow.Cells(12).Value = CDbl(CDbl(DgvCuotas.CurrentRow.Cells(5).Value) - CDbl(DgvCuotas.CurrentRow.Cells(9).Value)).ToString("C4")
                        Else
                            DgvCuotas.CurrentRow.Cells(12).Value = CDbl(DgvCuotas.CurrentRow.Cells(12).Value).ToString("C4")
                        End If
                    Else
                        DgvCuotas.CurrentRow.Cells(12).Value = CDbl(0).ToString("C4")
                    End If

                    DgvCuotas.CurrentRow.Cells(16).Value = CDbl(CDbl(DgvCuotas.CurrentRow.Cells(8).Value) - CDbl(DgvCuotas.CurrentRow.Cells(9).Value) - CDbl(DgvCuotas.CurrentRow.Cells(10).Value) - CDbl(DgvCuotas.CurrentRow.Cells(11).Value) - CDbl(DgvCuotas.CurrentRow.Cells(12).Value) - CDbl(DgvCuotas.CurrentRow.Cells(13).Value) - CDbl(DgvCuotas.CurrentRow.Cells(14).Value)).ToString("C4")
                    CompararEntradas()
                End If
            Catch ex As Exception
                DgvCuotas.CurrentRow.Cells(11).Value = CDbl(0).ToString("C4")
            End Try

            Try
                If e.ColumnIndex = 13 Then
                    If CDbl(DgvCuotas.CurrentRow.Cells(10).Value) + CDbl(DgvCuotas.CurrentRow.Cells(13).Value) > CDbl(DgvCuotas.CurrentRow.Cells(6).Value) Then
                        DgvCuotas.CurrentRow.Cells(13).Value = (CDbl(DgvCuotas.CurrentRow.Cells(6).Value) - CDbl(DgvCuotas.CurrentRow.Cells(10).Value)).ToString("C4")
                    Else
                        DgvCuotas.CurrentRow.Cells(13).Value = (CDbl(DgvCuotas.CurrentRow.Cells(13).Value)).ToString("C4")
                    End If

                    DgvCuotas.CurrentRow.Cells(16).Value = CDbl(CDbl(DgvCuotas.CurrentRow.Cells(8).Value) - CDbl(DgvCuotas.CurrentRow.Cells(9).Value) - CDbl(DgvCuotas.CurrentRow.Cells(10).Value) - CDbl(DgvCuotas.CurrentRow.Cells(11).Value) - CDbl(DgvCuotas.CurrentRow.Cells(12).Value) - CDbl(DgvCuotas.CurrentRow.Cells(13).Value) - CDbl(DgvCuotas.CurrentRow.Cells(14).Value)).ToString("C4")
                    CompararEntradas()
                End If
            Catch ex As Exception
                DgvCuotas.CurrentRow.Cells(10).Value = CDbl(0).ToString("C4")
            End Try

            Try
                If e.ColumnIndex = 14 Then
                    If CDbl(DgvCuotas.CurrentRow.Cells(11).Value) + CDbl(DgvCuotas.CurrentRow.Cells(14).Value) > CDbl(DgvCuotas.CurrentRow.Cells(7).Value) Then
                        DgvCuotas.CurrentRow.Cells(14).Value = CDbl(CDbl(DgvCuotas.CurrentRow.Cells(7).Value) - CDbl(DgvCuotas.CurrentRow.Cells(11).Value)).ToString("C4")
                    Else
                        DgvCuotas.CurrentRow.Cells(14).Value = CDbl(DgvCuotas.CurrentRow.Cells(14).Value).ToString("C4")
                    End If

                    DgvCuotas.CurrentRow.Cells(16).Value = CDbl(CDbl(DgvCuotas.CurrentRow.Cells(8).Value) - CDbl(DgvCuotas.CurrentRow.Cells(9).Value) - CDbl(DgvCuotas.CurrentRow.Cells(10).Value) - CDbl(DgvCuotas.CurrentRow.Cells(11).Value) - CDbl(DgvCuotas.CurrentRow.Cells(12).Value) - CDbl(DgvCuotas.CurrentRow.Cells(13).Value) - CDbl(DgvCuotas.CurrentRow.Cells(14).Value)).ToString("C4")
                    CompararEntradas()
                End If
            Catch ex As Exception
                DgvCuotas.CurrentRow.Cells(10).Value = CDbl(0).ToString("C4")
            End Try



            Try
                If e.ColumnIndex = 15 Then
                    Dim IsTicked As Boolean = CBool(DgvCuotas.CurrentRow.Cells(15).Value)
                    If IsTicked Then
                        DgvCuotas.CurrentRow.Cells(9).Value = (CDbl(DgvCuotas.CurrentRow.Cells(5).Value) - CDbl(DgvCuotas.CurrentRow.Cells(12).Value)).ToString("C4")
                        DgvCuotas.CurrentRow.Cells(10).Value = (CDbl(DgvCuotas.CurrentRow.Cells(6).Value) - CDbl(DgvCuotas.CurrentRow.Cells(13).Value)).ToString("C4")
                        DgvCuotas.CurrentRow.Cells(11).Value = (CDbl(DgvCuotas.CurrentRow.Cells(7).Value) - CDbl(DgvCuotas.CurrentRow.Cells(14).Value)).ToString("C4")
                    Else
                        DgvCuotas.CurrentRow.Cells(9).Value = CDbl(0).ToString("C4")
                        DgvCuotas.CurrentRow.Cells(10).Value = CDbl(0).ToString("C4")
                        DgvCuotas.CurrentRow.Cells(11).Value = CDbl(0).ToString("C4")
                        DgvCuotas.CurrentRow.Cells(12).Value = CDbl(0).ToString("C4")
                        DgvCuotas.CurrentRow.Cells(13).Value = CDbl(0).ToString("C4")
                        DgvCuotas.CurrentRow.Cells(14).Value = CDbl(0).ToString("C4")
                    End If

                    DgvCuotas.CurrentRow.Cells(16).Value = (CDbl(DgvCuotas.CurrentRow.Cells(8).Value) - CDbl(DgvCuotas.CurrentRow.Cells(9).Value) - CDbl(DgvCuotas.CurrentRow.Cells(10).Value) - CDbl(DgvCuotas.CurrentRow.Cells(11).Value) - CDbl(DgvCuotas.CurrentRow.Cells(12).Value) - CDbl(DgvCuotas.CurrentRow.Cells(13).Value) - CDbl(DgvCuotas.CurrentRow.Cells(14).Value)).ToString("C4")
                    CompararEntradas()
                End If

            Catch ex As Exception
            End Try

            ConceptoPago()
            DgvCuotas.Invalidate()
        End If
    End Sub

    Private Sub btnAplicarMonto_Click(sender As Object, e As EventArgs) Handles btnAplicarMonto.Click
        Try
            If txtMontoAplicar.Text <> "" Then
                If cbxFinanciamientos.Text <> "" Then
                    If IsNumeric(CDbl(txtMontoAplicar.Text)) Then
                        If CDbl(txtMontoAplicar.Text) > 0 Then
                            Dim MontoVencido As Double
                            Con.Open()
                            cmd = New MySqlCommand("SELECT coalesce(sum(Balance),0) FROM financiamientos_cuotas where fechavencimiento<now() and Balance>0 and IDFinanciamiento='" + cbxFinanciamientos.SelectedValue.ToString + "'", Con)
                            MontoVencido = Convert.ToDouble(cmd.ExecuteScalar)
                            Con.Close()

                            If CDbl(txtMontoAplicar.Text) > MontoVencido Then
                                Dim Result As MsgBoxResult = MessageBox.Show("El monto a aplicar es mayor a la cantidad de cuotas vencidas. Desea aplicar los descuentos correspondientes sobre los intereses?", "Descuentos en interés sin vencer", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                If Result = MsgBoxResult.Yes Then
                                    AplicarExoneracionProntoPago = True

                                    ConMixta.Open()
                                    cmd = New MySqlCommand("SELECT Dias FROM" & SysName.Text & "financiamientos inner join libregco.periodopago on financiamientos.IDFormaPago=PeriodoPago.IDPeriodoPago where idFinanciamientos='" + cbxFinanciamientos.SelectedValue.ToString + "'", ConMixta)
                                    DiasPeriodoPago.Text = Convert.ToInt16(cmd.ExecuteScalar)
                                    ConMixta.Close()

                                Else
                                    AplicarExoneracionProntoPago = False
                                End If

                            End If

                        End If

                    End If
                End If


                If CDbl(txtMontoAplicar.Text) > 0 Then
                    Dim x As Integer = 0
                    Dim AplicadoValue As Double = CDbl(txtMontoAplicar.Text)

Inicio:
                    If x = DgvCuotas.Rows.Count Then
                        GoTo Fin
                    End If

                    If AplicadoValue > 0 Then

                        If AplicarExoneracionProntoPago = True Then
                            If CDate(DgvCuotas.Rows(x).Cells(3).Value) > Today Then
                                If CDbl(AplicadoValue) > CDbl(DgvCuotas.Rows(x).Cells(5).Value) Then
                                    Dim DiasSinVencer As Integer = DateDiff(DateInterval.Day, Today, CDate(DgvCuotas.Rows(x).Cells(3).Value))
                                    If DiasSinVencer > CInt(DiasPeriodoPago.Text) Then
                                        DgvCuotas.Rows(x).Cells(13).Value = DgvCuotas.Rows(x).Cells(6).Value
                                    Else
                                        DgvCuotas.Rows(x).Cells(13).Value = CDbl((CDbl(DgvCuotas.Rows(x).Cells(6).Value) / CInt(DiasPeriodoPago.Text)) * DiasSinVencer).ToString("C4")
                                    End If
                                Else
                                    DgvCuotas.Rows(x).Cells(9).Value = AplicadoValue.ToString("C4")
                                    Dim PorcT As Double = AplicadoValue / CDbl(DgvCuotas.Rows(x).Cells(5).Value)
                                    AplicadoValue = AplicadoValue - CDbl(DgvCuotas.Rows(x).Cells(9).Value)
                                    DgvCuotas.Rows(x).Cells(13).Value = CDbl(CDbl(DgvCuotas.Rows(x).Cells(6).Value) * PorcT).ToString("C")
                                End If
                            End If
                        End If

                        If AplicadoValue > CDbl(CDbl(DgvCuotas.Rows(x).Cells(6).Value) - CDbl(DgvCuotas.Rows(x).Cells(13).Value)) Then
                            DgvCuotas.Rows(x).Cells(10).Value = CDbl(CDbl(DgvCuotas.Rows(x).Cells(6).Value) - CDbl(DgvCuotas.Rows(x).Cells(13).Value)).ToString("C4")
                            AplicadoValue = AplicadoValue - (CDbl(DgvCuotas.Rows(x).Cells(6).Value) - CDbl(DgvCuotas.Rows(x).Cells(13).Value))
                        ElseIf AplicadoValue <= CDbl(CDbl(DgvCuotas.Rows(x).Cells(6).Value) - CDbl(DgvCuotas.Rows(x).Cells(13).Value)) Then
                            DgvCuotas.Rows(x).Cells(10).Value = CDbl(AplicadoValue).ToString("C4")
                            AplicadoValue = 0
                        End If
                    End If

                    If AplicadoValue > 0 Then
                        If AplicadoValue > CDbl(CDbl(DgvCuotas.Rows(x).Cells(7).Value) - CDbl(DgvCuotas.Rows(x).Cells(14).Value)) Then
                            DgvCuotas.Rows(x).Cells(11).Value = CDbl(CDbl(DgvCuotas.Rows(x).Cells(7).Value) - CDbl(DgvCuotas.Rows(x).Cells(14).Value)).ToString("C4")
                            AplicadoValue = AplicadoValue - (CDbl(DgvCuotas.Rows(x).Cells(7).Value) - CDbl(DgvCuotas.Rows(x).Cells(14).Value))
                        ElseIf AplicadoValue <= CDbl(CDbl(DgvCuotas.Rows(x).Cells(7).Value) - CDbl(DgvCuotas.Rows(x).Cells(14).Value)) Then
                            DgvCuotas.Rows(x).Cells(11).Value = AplicadoValue.ToString("C4")
                            AplicadoValue = 0
                        End If
                    End If

                    If AplicadoValue > 0 Then
                        If AplicadoValue > CDbl(CDbl(DgvCuotas.Rows(x).Cells(5).Value) - CDbl(DgvCuotas.Rows(x).Cells(12).Value)) Then
                            DgvCuotas.Rows(x).Cells(9).Value = CDbl(CDbl(DgvCuotas.Rows(x).Cells(5).Value) - CDbl(DgvCuotas.Rows(x).Cells(12).Value)).ToString("C4")
                            AplicadoValue = AplicadoValue - (CDbl(DgvCuotas.Rows(x).Cells(5).Value) - CDbl(DgvCuotas.Rows(x).Cells(12).Value))
                        ElseIf AplicadoValue <= CDbl(CDbl(DgvCuotas.Rows(x).Cells(5).Value) - CDbl(DgvCuotas.Rows(x).Cells(12).Value)) Then
                            DgvCuotas.Rows(x).Cells(9).Value = CDbl(AplicadoValue).ToString("C4")
                            AplicadoValue = 0
                        End If
                    End If

                    DgvCuotas.Rows(x).Cells(16).Value = CDbl(CDbl(DgvCuotas.Rows(x).Cells(8).Value) - CDbl(DgvCuotas.Rows(x).Cells(9).Value) - CDbl(DgvCuotas.Rows(x).Cells(10).Value) - CDbl(DgvCuotas.Rows(x).Cells(11).Value) - CDbl(DgvCuotas.Rows(x).Cells(12).Value) - CDbl(DgvCuotas.Rows(x).Cells(13).Value) - CDbl(DgvCuotas.Rows(x).Cells(14).Value)).ToString("C4")

                    If AplicadoValue = 0 Then
                        GoTo Fin
                    End If

                    x = x + 1
                    GoTo Inicio
Fin:


                End If

                ConceptoPago()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub ConceptoPago()
        Try

            Dim Abono, Saldo As New ArrayList
            Dim TextosAbono, TextosSaldos, Espacio As String

            '--------------------------------------------------------------

            'For Each row As DataGridViewRow In DgvCuotas.Rows
            '    If CDbl(row.Cells(9).Value) + CDbl(row.Cells(10).Value) + CDbl(row.Cells(11).Value) > 0 Then
            '        If (CDbl(row.Cells(9).Value) + CDbl(row.Cells(10).Value) + CDbl(row.Cells(11).Value) + CDbl(row.Cells(12).Value) + CDbl(row.Cells(13).Value) + CDbl(row.Cells(14).Value)) < CDbl(row.Cells(8).Value) Then
            '            Abono.Add(CStr(row.Cells(2).Value))
            '        ElseIf (CDbl(row.Cells(9).Value) + CDbl(row.Cells(10).Value) + CDbl(row.Cells(11).Value) + CDbl(row.Cells(12).Value) + CDbl(row.Cells(13).Value) + CDbl(row.Cells(14).Value)) = CDbl(row.Cells(8).Value) Then
            '            Saldo.Add(CStr(row.Cells(2).Value))
            '        End If
            '    End If
            'Next

            For Each row As DataGridViewRow In DgvCuotas.Rows
                If CDbl(row.Cells(16).Value) = 0 Then
                    Saldo.Add(CStr(row.Cells(2).Value))
                Else
                    If CDbl(row.Cells(8).Value) <> CDbl(row.Cells(16).Value) Then
                        Abono.Add(CStr(row.Cells(2).Value))
                    End If
                End If
            Next

            '------------------------------------------------------------

            If Abono.Count > 0 Then
                Dim i As Integer = 0
                For Each itm As String In Abono
                    i += 1
                    TextosAbono = TextosAbono & itm

                    If i < Abono.Count Then
                        TextosAbono = TextosAbono & ";"
                    End If
                Next

                TextosAbono = "Abono a cuota(s) No.: " & TextosAbono
            Else
                TextosAbono = ""
            End If

            '------------------------------------------------------------

            If Saldo.Count > 0 Then
                Dim a As Integer = 0
                For Each itx As String In Saldo
                    a += 1
                    TextosSaldos = TextosSaldos & itx

                    If a < Saldo.Count Then
                        TextosSaldos = TextosSaldos & ";"
                    End If
                Next

                TextosSaldos = "Saldo a cuota(s) No.: " & TextosSaldos
            Else
                TextosSaldos = ""
            End If

            If TextosAbono <> "" And TextosSaldos <> "" Then
                Espacio = ", "
            Else
                Espacio = ""
            End If

            txtConceptoPago.Text = TextosAbono & Espacio & TextosSaldos
            txtConceptoPago.Text = txtConceptoPago.Text.Substring(0, 255)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        Dim SumAplicar As Double = 0
        For Each Rows As DataGridViewRow In DgvCuotas.Rows
            SumAplicar = SumAplicar + CDbl(Rows.Cells(9).Value) + CDbl(Rows.Cells(10).Value) + CDbl(Rows.Cells(11).Value)
        Next

        VerificarFechaSistema()

        If txtIDCliente.Text = "" Then
            MessageBox.Show("No se ha seleccionado el cliente para iniciar el proceso de pago.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf txtMontoAplicar.Text = CDbl(0).ToString("C4") Then
            MessageBox.Show("El monto a aplicar en el abono debe ser nayor a cero.", "Monto a Aplicar es 0", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMontoAplicar.Focus()
            Exit Sub
        ElseIf txtMontoAplicar.Text = "" Then
            MessageBox.Show("Escriba el monto a aplicar en el recibo.", "No se especificó monto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMontoAplicar.Focus()
            Exit Sub
        ElseIf SumAplicar = 0 Then
            MessageBox.Show("No se ha específicado el detalle del abono en las facturas.", "Escriba los montos a aplicar en las facturas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtConceptoPago.Text = "" Then
            Dim Concept As MsgBoxResult = MessageBox.Show("El concepto del pago está vacío. Desearía generarlo automáticamente?", "Concepto en blanco", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Concept = MsgBoxResult.Yes Then
                ConceptoPago()
            End If
        End If

        If txtIDPagoFinanciamiento.Text = "" Then 'Si no hay pago
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo recibo de pago a nombre del cliente " & txtNombre.Text & " [ " & txtIDCliente.Text & " ] en la base de datos?", "Guardar Nuevo Recibo de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                'Buscar limite de descuentos
                If LimitarDescuentos = 1 Then
                    Dim DescuentosAplicados As Double = 0

                    For Each row As DataGridViewRow In DgvCuotas.Rows
                        DescuentosAplicados = DescuentosAplicados + CDbl(row.Cells(12).Value)
                    Next

                    If DescuentosAplicados > CDbl(LimiteMaximoDescuento) Then
                        MessageBox.Show("Ha superado el límite máximo del monto de descuentos autorizado." & vbNewLine & vbNewLine & "Por favor verifique la información suministrada en el recibo y proceda a introducir la superclave para continuar.", "Se ha excedido el monto de descuento máximo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        ControlSuperClave = 1
                        frm_superclave.IDAccion.Text = 95
                        frm_superclave.ShowDialog(Me)

                        If ControlSuperClave = 1 Then
                            Exit Sub
                        End If
                    End If
                End If

                'Buscar similitudes
                FindSimilarities(58, txtIDCliente.Text, txtMontoAplicar.Text, CDate(txtFecha.Value))
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                VerificarSaldosconCargos()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                VerificarSaldos()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                CompararEntradas()
                SumarDescuentos()

                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                sqlQ = "INSERT INTO pagosfinanciamientos (IDTipoDocumento,Fecha,IDAreaImpresion,IDUsuario,IDTransaccion,IDFinanciamiento,BalanceAnterior,Concepto,Debitos,Descuentos,TotalAplicado,SumaLetra,Impreso,Nulo) VALUES ('58','" + txtFecha.Value.ToString("yyyy-MM-dd") & " " & Now.ToString("HH:mm:sss") + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + lblIDTransaccion.Text + "','" + cbxFinanciamientos.SelectedValue.ToString + "','" + CDbl(txtBalanceGeneralCargos.Text).ToString + "','" + txtConceptoPago.Text + "','" + CDbl(txtMontoAplicar.Text).ToString + "','" + CDbl(lblDescuento.Text).ToString + "','" + CDbl(lblTotalAbono.Text).ToString + "','" + ConvertNumbertoString(txtMontoAplicar.Text).ToString + "',0,'" + Convert.ToInt16(chkNulo.CheckState).ToString + "')"
                GuardarDatos()
                UltPago()
                InsertDetalleAbono()
                SetSecondID()
                CalcularBalances()

                ToastNotificationsManager1.Notifications(0).Body = "El pago " & txtSecondID.Text & " ha sido guardado satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

                ImprimirDocumento()

                DeshabilitarControles()
                Hora.Enabled = False
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_formadepago.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                SumarDescuentos()
                sqlQ = "UPDATE pagosfinanciamientos SET Fecha='" + txtFecha.Value.ToString("yyyy-MM-dd") & " " & Now.ToString("HH:mm:sss") + "',IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',BalanceAnterior='" + CDbl(txtBalanceGeneralCargos.Text).ToString + "',Concepto='" + txtConceptoPago.Text + "',Debitos='" + CDbl(txtMontoAplicar.Text).ToString + "',Descuentos='" + CDbl(lblDescuento.Text).ToString + "',TotalAplicado='" + CDbl(lblTotalAbono.Text).ToString + "',SumaLetra='" + ConvertNumbertoString(txtMontoAplicar.Text).ToString + "',Nulo='" + Convert.ToInt16(chkNulo.CheckState).ToString + "' WHERE idPagosFinanciamientos= (" + txtIDPagoFinanciamiento.Text + ")"
                GuardarDatos()
                InsertDetalleAbono()
                CalcularBalances()

                ToastNotificationsManager1.Notifications(1).Body = "El pago " & txtSecondID.Text & " ha sido modificado satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))

                ImprimirDocumento()
                DeshabilitarControles()
                Hora.Enabled = False
            End If
        End If
    End Sub

    Private Sub CalcularBalances()
        FunctCalcBcesFact(txtIDCliente.Text)
        FunctCalcBceGral(txtIDCliente.Text)
    End Sub

    Private Sub InsertDetalleAbono()
        Try
            For Each rw As DataGridViewRow In DgvCuotas.Rows
                If CStr(rw.Cells(0).Value) = "" Then
                    If CDbl(CDbl(rw.Cells(9).Value) + CDbl(rw.Cells(10).Value) + CDbl(rw.Cells(11).Value) + CDbl(rw.Cells(12).Value) + CDbl(rw.Cells(13).Value) + CDbl(rw.Cells(14).Value)) = 0 Then
                    Else
                        sqlQ = "Insert into pagosfinanciamientos_detalles (IDPagosFinanciamientos,IDFinanciamientoCuota,BceCapitalAnterior,BceInteresAnterior,BceCargosAnterior,CapitalAplicado,InteresAplicado,CargosAplicados,DescuentosAplicado,InteresExonerado,CargosExonerado) Values ('" + txtIDPagoFinanciamiento.Text + "','" + rw.Cells(1).Value.ToString + "','" + CDbl(rw.Cells(5).Value).ToString + "','" + CDbl(rw.Cells(6).Value).ToString + "','" + CDbl(rw.Cells(7).Value).ToString + "','" + CDbl(rw.Cells(9).Value).ToString + "','" + CDbl(rw.Cells(10).Value).ToString + "','" + CDbl(rw.Cells(11).Value).ToString + "','" + CDbl(rw.Cells(12).Value).ToString + "','" + CDbl(rw.Cells(13).Value).ToString + "','" + CDbl(rw.Cells(14).Value).ToString + "')"
                        GuardarDatos()

                        Con.Open()
                        cmd = New MySqlCommand("Select idPagosFinanciamientos_Detalles from pagosfinanciamientos_detalles where idPagosFinanciamientos_Detalles= (Select Max(idPagosFinanciamientos_Detalles) from pagosfinanciamientos_detalles)", Con)
                        rw.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                        Con.Close()
                    End If

                Else
                    If CDbl(CDbl(rw.Cells(9).Value) + CDbl(rw.Cells(10).Value) + CDbl(rw.Cells(11).Value) + CDbl(rw.Cells(12).Value) + CDbl(rw.Cells(13).Value) + CDbl(rw.Cells(14).Value)) = 0 Then
                        sqlQ = "Delete from pagosfinanciamientos_detalles Where idPagosFinanciamientos_Detalles = '" + CStr(rw.Cells(0).Value).ToString + "'"
                        GuardarDatos()

                    Else
                        sqlQ = "UPDATE pagosfinanciamientos_detalles SET BceCapitalAnterior='" + CDbl(rw.Cells(5).Value).ToString + "',BceInteresAnterior='" + CDbl(rw.Cells(6).Value).ToString + "',BceCargosAnterior='" + CDbl(rw.Cells(7).Value).ToString + "',CapitalAplicado='" + CDbl(rw.Cells(9).Value).ToString + "',InteresAplicado='" + CDbl(rw.Cells(10).Value).ToString + "',CargosAplicados='" + CDbl(rw.Cells(11).Value).ToString + "',DescuentosAplicado='" + CDbl(rw.Cells(12).Value).ToString + "',InteresExonerado='" + CDbl(rw.Cells(13).Value).ToString + "',CargosExonerado='" + CDbl(rw.Cells(14).Value).ToString + "' WHERE idPagosFinanciamientos_Detalles= '" + CStr(rw.Cells(0).Value).ToString + "'"
                        GuardarDatos()
                    End If


                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " Desde Insertar Detalle Abono.")
        End Try
    End Sub

    Private Sub SetSecondID()
        Dim DsTemp As New DataSet

        Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=58", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE pagosfinanciamientos SET SecondID='" + lblSecondID.Text + "' WHERE idPagosFinanciamientos='" + txtIDPagoFinanciamiento.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=58"
            GuardarDatos()

       End Sub
    Private Sub txtMontoAplicar_Enter(sender As Object, e As EventArgs) Handles txtMontoAplicar.Enter
        Try
            txtMontoAplicar.Text = CDbl(txtMontoAplicar.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione un cliente para poder acceder a su historial de pagos.", "No hay cliente activo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            frm_buscar_clientes.ShowDialog(Me)

            If txtIDCliente.Text <> "" Then
                frm_buscar_pago_cuotas_financiamientos.ShowDialog(Me)
            End If
        Else
            frm_buscar_pago_cuotas_financiamientos.ShowDialog(Me)
        End If

    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El recibo de pago de cuotas de financiamientos No. " & txtSecondID.Text & " del cliente " & txtNombre.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Recibo de Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then

                chkNulo.Checked = False
                SumarDescuentos()
                sqlQ = "UPDATE pagosfinanciamientos SET Fecha='" + txtFecha.Value.ToString("yyyy-MM-dd") & " " & Now.ToString("HH:mm:sss") + "',IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Concepto='" + txtConceptoPago.Text + "',Debitos='" + CDbl(txtMontoAplicar.Text).ToString + "',Descuentos='" + CDbl(lblDescuento.Text).ToString + "',TotalAplicado='" + CDbl(lblTotalAbono.Text).ToString + "',SumaLetra='" + ConvertNumbertoString(txtMontoAplicar.Text).ToString + "',Nulo='" + Convert.ToInt16(chkNulo.CheckState).ToString + "' WHERE idPagosFinanciamientos= (" + txtIDPagoFinanciamiento.Text + ")"
                GuardarDatos()
                CalcularBalances()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDPagoFinanciamiento.Text = "" Then
            MessageBox.Show("No hay un registro de recibo de ingreso abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el recibo de pago de cuotas de financiamientos No." & txtSecondID.Text & " del cliente " & txtNombre.Text & " del sistema?", "Anular Recibo de Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                chkNulo.Checked = True
                sqlQ = "UPDATE pagosfinanciamientos SET Fecha='" + txtFecha.Value.ToString("yyyy-MM-dd") & " " & Now.ToString("HH:mm:sss") + "',IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Concepto='" + txtConceptoPago.Text + "',Debitos='" + CDbl(txtMontoAplicar.Text).ToString + "',Descuentos='" + CDbl(lblDescuento.Text).ToString + "',TotalAplicado='" + CDbl(lblTotalAbono.Text).ToString + "',SumaLetra='" + ConvertNumbertoString(txtMontoAplicar.Text).ToString + "',Nulo='" + Convert.ToInt16(chkNulo.CheckState).ToString + "' WHERE idPagosFinanciamientos= (" + txtIDPagoFinanciamiento.Text + ")"
                GuardarDatos()
                CalcularBalances()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
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

    Private Sub UltPago()
        Try

            If txtIDPagoFinanciamiento.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select idPagosFinanciamientos from pagosfinanciamientos where idPagosFinanciamientos= (Select Max(idPagosFinanciamientos) from pagosfinanciamientos)", Con)
                txtIDPagoFinanciamiento.Text = Convert.ToDouble(cmd.ExecuteScalar)
                Con.Close()
            Else
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "UltPago")
        End Try
    End Sub

    Private Sub txtMontoAplicar_Leave(sender As Object, e As EventArgs) Handles txtMontoAplicar.Leave
        Try
            If txtMontoAplicar.Text = "" Then
                LimpiarAplicados()
                txtMontoAplicar.Text = CDbl(0).ToString("C4")
                txtConceptoPago.Text = ""
            Else
                txtMontoAplicar.Text = CDbl(txtMontoAplicar.Text).ToString("C4")

            End If

        Catch ex As Exception
            txtMontoAplicar.Text = CDbl(0).ToString
            txtConceptoPago.Text = ""
            LimpiarAplicados()
        End Try
    End Sub

    Sub LimpiarAplicados()

        For Each Rows As DataGridViewRow In DgvCuotas.Rows
            Rows.Cells(9).Value = CDbl(0).ToString("C4")
            Rows.Cells(10).Value = CDbl(0).ToString("C4")
            Rows.Cells(11).Value = CDbl(0).ToString("C4")
        Next

    End Sub

    Private Sub frm_recibo_pagos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Control.ModifierKeys = Keys.Control Then
            If e.KeyCode = Keys.A Then
                e.Handled = True
                txtMontoAplicar.Focus()
            End If
        End If
    End Sub
End Class