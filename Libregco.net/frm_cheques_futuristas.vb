Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_cheques_futuristas

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Incluir As New DataGridViewCheckBoxColumn
    Dim HeaderIncluir As New CheckBox
    Friend lblNulo, lblProcesado, lblIDUsuario, lblIDBanco As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_cheques_futuristas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        ColumnasDgvFactura()
        AddHeaderCheckBox()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ActualizarTodo()
        ControlSuperClave = 1
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        txtHora.Text = TimeOfDay
        lblNulo.Text = 0
        lblProcesado.text = 0
        ChkNulo.Checked = False
        chkProcesar.Checked = False
        HeaderIncluir.Checked = False
        btnBuscarCliente.Focus()
        DtpFechaDeposito.Value = Today
        lblStatusBar.Text = "Listo"
        FillCxbBanco()
    End Sub

    Private Sub FillCxbBanco()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Identidad FROM Bancos ORDER BY Identidad ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Bancos")
            cbxBanco.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Bancos")

            For Each Fila As DataRow In Tabla.Rows
                cbxBanco.Items.Add(Fila.Item("Identidad"))
            Next

            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se pudo cargar ningún BANCO ya que no se encontraron resultados en la base de datos. Defina los bancos emisores de cheques para procesar los cheques.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub
    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtSecondID.Clear()
        txtBalanceGral.Clear()
        txtUltimoPago.Clear()
        txtCalificacion.Clear()
        txtIDCheque.Clear()
        DgvFacturas.Rows.Clear()
        txtReferencia.Clear()
        cbxBanco.Items.Clear()
        txtNoCheque.Clear()
        txtMonto.Clear()
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

    Private Sub AddHeaderCheckBox()
        HeaderIncluir = New CheckBox()
        HeaderIncluir.Name = "HeaderIncluir"
        HeaderIncluir.Size = New Size(14, 14)
        HeaderIncluir.ThreeState = False
        HeaderIncluir.FlatStyle = FlatStyle.Standard
        DgvFacturas.Controls.Add(HeaderIncluir)

        AddHandler HeaderIncluir.CheckedChanged, AddressOf HeaderIncluir_CheckedChanged
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Sub RefrescarTablaFacturas()
        Try
            DgvFacturas.Rows.Clear()
            Con.Open()
            Dim CmdFacts As New MySqlCommand("SELECT IDFacturaDatos,SecondID,Fecha,FechaVencimiento,DiasVencidos,TotalNeto,Balance,Cargos,SecondID FROM FacturaDatos WHERE IDCliente='" + txtIDCliente.Text + "' and Balance>0 AND Nulo=0", Con)
            Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader

            While LectorFacturas.Read
                DgvFacturas.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), CDate(LectorFacturas.GetValue(2)).ToString("dd/MM/yyyy"), CDate(LectorFacturas.GetValue(3)).ToString("dd/MM/yyyy"), LectorFacturas.GetValue(4), LectorFacturas.GetValue(5), LectorFacturas.GetValue(6), LectorFacturas.GetValue(7), CDbl(0), False, "")
            End While
            LectorFacturas.Close()
            Con.Close()

            For Each Rows As DataGridViewRow In DgvFacturas.Rows
                Rows.Cells(10).Value = CDbl(Rows.Cells(6).Value).ToString("C")
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub ColumnasDgvFactura()
        Try
            DgvFacturas.Columns.Clear()

            With DgvFacturas
                .Columns.Add("IDFacturaDatos", "Factura")   '0
                .Columns.Add("SecondID", "Factura") '1
                .Columns.Add("Fecha", "Fecha") '2
                .Columns.Add("FechaVencimiento", "Vence") '3
                .Columns.Add("DiasVencidos", "Días") '4
                .Columns.Add("Monto", "Monto") '5
                .Columns.Add("Balance", "Balance") '6
                .Columns.Add("Cargos", "Cargos Acum.") '7
                .Columns.Add("Aplicar", "Aplicado") '8
                .Columns.Add(Incluir) '9
                .Columns.Add("Final", "Bal. Final") '10
                .Columns.Add("IDChequeDetalle", "IDChequeDetalle") '11
            End With
            PropiedadesDgvFactura()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PropiedadesDgvFactura()
        Try
            Dim DatagridWidth As Double = (DgvFacturas.Width - DgvFacturas.RowHeadersWidth) / 100

            With DgvFacturas
                .Columns(0).Visible = False
                .Columns(1).Width = DatagridWidth * 10
                .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(1).ReadOnly = True
                .Columns(2).Width = DatagridWidth * 8
                .Columns(2).ReadOnly = True
                .Columns(3).Width = DatagridWidth * 8
                .Columns(3).ReadOnly = True
                .Columns(4).Width = DatagridWidth * 6
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(4).ReadOnly = True
                .Columns(5).DefaultCellStyle.Format = ("C")
                .Columns(5).Width = DatagridWidth * 10
                .Columns(5).ReadOnly = True
                .Columns(6).DefaultCellStyle.Format = ("C")
                .Columns(6).Width = DatagridWidth * 12
                .Columns(6).ReadOnly = True
                .Columns(7).DefaultCellStyle.Format = ("C")
                .Columns(7).Width = DatagridWidth * 12
                .Columns(7).ReadOnly = True
                .Columns(8).DefaultCellStyle.Format = ("C")
                .Columns(8).Width = DatagridWidth * 12
                .Columns(8).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
                .Columns(10).Width = DatagridWidth * 14
                .Columns(10).DefaultCellStyle.ForeColor = Color.White
                .Columns(10).DefaultCellStyle.BackColor = Color.Gray
                .Columns(10).DefaultCellStyle.Format = ("C")
                .Columns(10).ReadOnly = True
                .Columns(11).Visible = False
            End With

            With Incluir
                .HeaderText = ""
                .Name = "Incluir"
                .Width = DatagridWidth * 8
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .FlatStyle = FlatStyle.Standard
                .DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
            End With
        Catch ex As Exception

        End Try
        For Each Column As DataGridViewColumn In DgvFacturas.Columns
            Column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub DgvFacturas_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFacturas.CellValueChanged
        Try

            If e.ColumnIndex = 8 Then
                If CDbl(DgvFacturas.CurrentRow.Cells(8).Value) > CDbl(DgvFacturas.CurrentRow.Cells(6).Value) Then
                    MessageBox.Show("El monto aplicado excede el balance de la factura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    DgvFacturas.CurrentRow.Cells(6).Value = CDbl(DgvFacturas.CurrentRow.Cells(5).Value).ToString("C")
                Else
                    DgvFacturas.CurrentRow.Cells(8).Value = CDbl(DgvFacturas.CurrentRow.Cells(8).Value).ToString("C")
                End If

                DgvFacturas.CurrentRow.Cells(10).Value = CDbl(DgvFacturas.CurrentRow.Cells(6).Value) - CDbl(DgvFacturas.CurrentRow.Cells(8).Value).ToString("C")

                CompararEntradas()
            End If
        Catch ex As Exception
            DgvFacturas.CurrentRow.Cells(8).Value = CDbl(0).ToString("C")
        End Try

        Try
            If e.ColumnIndex = 9 Then
                Dim IsTicked As Boolean = CBool(DgvFacturas.CurrentRow.Cells(9).Value)
                If IsTicked Then
                    DgvFacturas.CurrentRow.Cells(8).Value = CDbl(DgvFacturas.CurrentRow.Cells(6).Value).ToString("C")
                    DgvFacturas.CurrentRow.Cells(10).Value = (CDbl(DgvFacturas.CurrentRow.Cells(6).Value) - CDbl(DgvFacturas.CurrentRow.Cells(8).Value).ToString("C"))
                Else
                    DgvFacturas.CurrentRow.Cells(8).Value = CDbl(0).ToString("C")
                    DgvFacturas.CurrentRow.Cells(10).Value = (CDbl(DgvFacturas.CurrentRow.Cells(6).Value) - CDbl(DgvFacturas.CurrentRow.Cells(8).Value).ToString("C"))
                End If
            End If

        Catch ex As Exception
        End Try

        DgvFacturas.Invalidate()
    End Sub

    Private Sub ResetHeaderCheckBoxLocation(ByVal ColumnIndex As Integer, ByVal RowIndex As Integer)
        Dim Rect As Rectangle = DgvFacturas.GetCellDisplayRectangle(ColumnIndex, RowIndex, True)
        Dim Pt As New Point()
        Pt.X = Rect.Location.X + (Rect.Width - HeaderIncluir.Width) \ 2 + 1
        Pt.Y = Rect.Location.Y + (Rect.Height - HeaderIncluir.Height) \ 2 + 1
        HeaderIncluir.Location = Pt
    End Sub

    Private Sub DgvFacturas_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvFacturas.CellPainting
        If e.RowIndex = -1 AndAlso e.ColumnIndex = 9 Then
            ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex)
        End If
    End Sub

    Private Sub DgvFacturas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFacturas.CellEndEdit
        DgvFacturas.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvFacturas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFacturas.CellDoubleClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                frm_cambiar_precio_lite.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub CompararEntradas()
        Dim AplicadoValue As Double = 0
        For Each Rows As DataGridViewRow In DgvFacturas.Rows
            AplicadoValue = AplicadoValue + CDbl(Rows.Cells(8).Value)
        Next

        txtMonto.Text = AplicadoValue.ToString("C")

    End Sub

    Private Sub HeaderIncluir_CheckedChanged(sender As Object, e As EventArgs)
        Try
            Dim x As Integer = 0
            Dim CheckStatus As Boolean = DgvFacturas.Rows(x).Cells(9).Value = True

            Dim HeaderBox As CheckBox = DirectCast(DgvFacturas.Controls.Find("HeaderIncluir", True)(0), CheckBox)
            For Each Rows As DataGridViewRow In DgvFacturas.Rows
                Rows.Cells(9).Value = HeaderBox.Checked
            Next

            If HeaderIncluir.Checked = True Then
                For Each Rows As DataGridViewRow In DgvFacturas.Rows
                    Rows.Cells(8).Value = CDbl(Rows.Cells(5).Value).ToString("C")
                    Rows.Cells(10).Value = CDbl(0).ToString("C")
                Next
            Else
                For Each Rows As DataGridViewRow In DgvFacturas.Rows
                    Rows.Cells(8).Value = CDbl(0).ToString("C")
                    Rows.Cells(10).Value = CDbl(CDbl(Rows.Cells(5).Value) - CDbl(Rows.Cells(8).Value)).ToString("C")
                Next
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)

        If txtIDCliente.Text <> "" Then
            If DgvFacturas.Rows.Count = 0 Then
                MessageBox.Show("El cliente: [" & txtIDCliente.Text & "] " & txtNombre.Text & ", no tiene facturas pendientes.", "No se encontraron facturas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub cbxBanco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBanco.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDBanco FROM Bancos where Identidad= '" + cbxBanco.SelectedItem + "'", Con)
        lblIDBanco.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub DgvFacturas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFacturas.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 8 Then
                DgvFacturas.EditMode = DataGridViewEditMode.EditOnEnter
            End If
        End If
    End Sub

    Private Sub DgvFacturas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFacturas.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                If e.ColumnIndex = 7 Then
                    Dim Row As DataGridViewRow = DgvFacturas.CurrentRow

                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub DgvFacturas_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvFacturas.CurrentCellDirtyStateChanged
        If DgvFacturas.IsCurrentCellDirty Then
            DgvFacturas.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvFacturas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvFacturas.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)
        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = DgvFacturas.CurrentCell.ColumnIndex

        If Columna = 8 Then
            Dim Caracter As Char = e.KeyChar
            Dim Txt As TextBox = CType(sender, TextBox)

            If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") And (Txt.Text.Contains(",") = False) Then

                e.Handled = False
            Else
                e.Handled = True
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
        btnBuscarCliente.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub RecibosEmitidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecibosEmitidoToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Sub ConvertDouble()
        txtMonto.Text = CDbl(txtMonto.Text)
    End Sub

    Sub ConvertCurrent()
        txtMonto.Text = CDbl(txtMonto.Text).ToString("C")
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

    Private Sub UltCheque()
        Try

            If txtIDCheque.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDChequesFuturos from ChequesFuturos where IDChequesFuturos= (Select Max(IDChequesFuturos) from ChequesFuturos)", Con)
                txtIDCheque.Text = Convert.ToDouble(cmd.ExecuteScalar)

                cmd = New MySqlCommand("Select SecondID from ChequesFuturos where IDChequesFuturos= (Select Max(IDChequesFuturos) from ChequesFuturos)", Con)
                txtSecondID.Text = Convert.ToDouble(cmd.ExecuteScalar)

                Con.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDCheque.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el recibo de recepción del cheque futurista?", "Imprimir Recibo de Cheque Futurista", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub


    Private Sub InsertDetalleCheques()
        Try
            Dim y As Integer = 0
            Dim lblIDFactura, lblBceAnterior, lblDiasVencidos, lblDebito, lblIDChequeDetalle As New Label

            If txtIDCheque.Text = "" Then
            Else
Inicio:
                If y = DgvFacturas.Rows.Count Then
                    GoTo Fin
                End If

                lblIDFactura.Text = DgvFacturas.Rows(y).Cells(0).Value
                lblDiasVencidos.Text = CDbl(DgvFacturas.Rows(y).Cells(4).Value)
                lblBceAnterior.Text = CDbl(DgvFacturas.Rows(y).Cells(6).Value)
                lblDebito.Text = Math.Round(CDbl(DgvFacturas.Rows(y).Cells(8).Value), 2)
                lblIDChequeDetalle.Text = DgvFacturas.Rows(y).Cells(11).Value

                If lblIDChequeDetalle.Text = "" Then         'Si es un registro nuevo
                    If CDbl(lblDebito.Text) = 0 Then     'Si el total es 0 entonces no hago nada.
                    Else                                'Si es diference a 0 y es un registro nuevo, entonces lo inserto
                        sqlQ = "Insert into ChequesFuturosDetalle (IDChequesFuturo,IDFactura,BalanceAnterior,DiasVencidos,Debito) Values ('" + txtIDCheque.Text + "','" + lblIDFactura.Text + "','" + lblBceAnterior.Text + "','" + lblDiasVencidos.Text + "','" + lblDebito.Text + "')"
                        GuardarDatos()
                    End If
                Else                    'Si el registro ya existe.
                    If CDbl(lblDebito.Text) = 0 Then     'Si el total del existente es 0 entonces lo elimino.
                        sqlQ = "Delete from ChequesFuturosDetalle Where IDChequesFuturosDetalle = '" + lblIDChequeDetalle.Text + "'"
                        GuardarDatos()
                    Else            'Si el total es diferente a 0 entonces actualizo sus datos.
                        sqlQ = "UPDATE ChequesFuturosDetalle SET BalanceAnterior='" + lblBceAnterior.Text + "',DiasVencidos='" + lblDiasVencidos.Text + "',Debito='" + lblDebito.Text + "' WHERE IDChequesFuturosDetalle= '" + lblIDChequeDetalle.Text + "'"
                        GuardarDatos()
                    End If
                End If

            End If

            y = y + 1
            GoTo Inicio
Fin:

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If
    End Sub

    Private Sub chkProcesar_CheckedChanged(sender As Object, e As EventArgs) Handles chkProcesar.CheckedChanged
        If chkProcesar.Checked = True Then
            lblProcesado.Text = 1
        Else
            lblProcesado.Text = 0
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("No ha seleccionado el cliente para procesar el cheque futurista.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf cbxBanco.Text = "" Then
            MessageBox.Show("Seleccione el banco emisor del cheque.", "Seleccionar Banco", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxBanco.Focus()
            Exit Sub
        ElseIf txtNoCheque.Text = "" Then
            MessageBox.Show("Escriba el No. del cheque emitido.", "No. de cheque vacío", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNoCheque.Focus()
        ElseIf txtMonto.Text = "" Or txtMonto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Aún no ha procesado o definido la aplicación del cheques sobre las facturas del cliente.", "No ha aplicado el cheque", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDCheque.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el nuevo cheque futurista a nombre del cliente " & txtNombre.Text & " [ " & txtIDCliente.Text & " ] en la base de datos?", "Guardar Nuevo Cheque Futurista", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                CompararEntradas()
                ConvertDouble()
                sqlQ = "INSERT INTO ChequesFuturos (SecondID,IDTipoDocumento,IDSucursal,IDAlmacen,IDUsuario,Fecha,Hora,IDCliente,Referencia,IDBanco,FechaDeposito,NoCheque,MontoCheque,Procesado,Impreso,Nulo) VALUES ('" + GetSecondID(18).ToString + "',18,'" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDCliente.Text + "','" + txtReferencia.Text + "','" + lblIDBanco.Text + "','" + DtpFechaDeposito.Text + "','" + txtNoCheque.Text + "','" + txtMonto.Text + "','" + lblProcesado.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltCheque()
                InsertDetalleCheques()
                CalcularBalances()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE ChequesFuturos SET IDUsuario='" + lblIDUsuario.Text + "',IDCliente='" + txtIDCliente.Text + "',Referencia='" + txtReferencia.Text + "',IDBanco='" + lblIDBanco.Text + "',FechaDeposito='" + DtpFechaDeposito.Text + "',NoCheque='" + txtNoCheque.Text + "',MontoCheque='" + txtMonto.Text + "',Procesado='" + lblProcesado.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDChequesFuturos= (" + txtIDCheque.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertDetalleCheques()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("No ha seleccionado el cliente para procesar el cheque futurista.", "Seleccionar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.PerformClick()
            Exit Sub
        ElseIf cbxBanco.Text = "" Then
            MessageBox.Show("Seleccione el banco emisor del cheque.", "Seleccionar Banco", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxBanco.Focus()
            Exit Sub
        ElseIf txtNoCheque.Text = "" Then
            MessageBox.Show("Escriba el No. del cheque emitido.", "No. de cheque vacío", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNoCheque.Focus()
        ElseIf txtMonto.Text = "" Or txtMonto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Aún no ha procesado o definido la aplicación del cheques sobre las facturas del cliente.", "No ha aplicado el cheque", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDCheque.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el nuevo cheque futurista a nombre del cliente " & txtNombre.Text & " [ " & txtIDCliente.Text & " ] en la base de datos?", "Guardar Nuevo Cheque Futurista", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                CompararEntradas()
                ConvertDouble()
                sqlQ = "INSERT INTO ChequesFuturos (SecondID,IDTipoDocumento,IDSucursal,IDAlmacen,IDUsuario,Fecha,Hora,IDCliente,Referencia,IDBanco,FechaDeposito,NoCheque,MontoCheque,Procesado,Impreso,Nulo) VALUES ('" + GetSecondID(18).ToString + "',18,'" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDCliente.Text + "','" + txtReferencia.Text + "','" + lblIDBanco.Text + "','" + DtpFechaDeposito.Text + "','" + txtNoCheque.Text + "','" + txtMonto.Text + "','" + lblProcesado.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltCheque()
                InsertDetalleCheques()
                CalcularBalances()
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
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE ChequesFuturos SET IDUsuario='" + lblIDUsuario.Text + "',IDCliente='" + txtIDCliente.Text + "',Referencia='" + txtReferencia.Text + "',IDBanco='" + lblIDBanco.Text + "',FechaDeposito='" + DtpFechaDeposito.Text + "',NoCheque='" + txtNoCheque.Text + "',MontoCheque='" + txtMonto.Text + "',Procesado='" + lblProcesado.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDChequesFuturos= (" + txtIDCheque.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertDetalleCheques()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_cheque_futurista.ShowDialog(Me)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El cheque futurista No. " & txtIDCheque.Text & " del cliente " & txtNombre.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Registro de Cheque Futurista", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then

                ChkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE ChequesFuturos SET IDUsuario='" + lblIDUsuario.Text + "',Referencia='" + txtReferencia.Text + "',IDBanco='" + lblIDBanco.Text + "',FechaDeposito='" + DtpFechaDeposito.Text + "',NoCheque='" + txtNoCheque.Text + "',MontoCheque='" + txtMonto.Text + "',Procesado='" + lblProcesado.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDChequesFuturos= (" + txtIDCheque.Text + ")"
                GuardarDatos()
                CalcularBalances()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDCheque.Text = "" Then
            MessageBox.Show("No hay un registro de cheque futurista abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el cheque futurista No. " & txtIDCheque.Text & " del cliente " & txtNombre.Text & " del sistema?", "Anular Cheque Futurista", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ChkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE ChequesFuturos SET IDUsuario='" + lblIDUsuario.Text + "',Referencia='" + txtReferencia.Text + "',IDBanco='" + lblIDBanco.Text + "',FechaDeposito='" + DtpFechaDeposito.Text + "',NoCheque='" + txtNoCheque.Text + "',MontoCheque='" + txtMonto.Text + "',Procesado='" + lblProcesado.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDChequesFuturos= (" + txtIDCheque.Text + ")"
                GuardarDatos()
                CalcularBalances()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub txtNoCheque_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoCheque.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub ProcesarChequeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcesarChequeToolStripMenuItem.Click

        If txtIDCheque.Text = "" Then
            MessageBox.Show("No hay un registro de cheque guardado para procesar.", "No hay un registro de cheque futurista", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            If chkProcesar.Checked = False Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está opción indica que el cheque ha sido procesado exitosamente por el banco. Está seguro que desea procesar el cheque futurista?" & vbNewLine & txtNombre.Text & " [ " & txtIDCliente.Text & "]" & vbNewLine & "Referencia: [" & txtReferencia.Text & "]" & vbNewLine & "Banco Emisor: " & cbxBanco.Text & vbNewLine & "No. de Cheque: CK-" & txtNoCheque.Text & vbNewLine & "Monto del Cheque: " & txtMonto.Text, "Procesar Cheque Futurista", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    chkProcesar.Checked = True
                    ConvertDouble()
                    sqlQ = "UPDATE ChequesFuturos SET IDUsuario='" + lblIDUsuario.Text + "',Referencia='" + txtReferencia.Text + "',IDBanco='" + lblIDBanco.Text + "',FechaDeposito='" + DtpFechaDeposito.Value + "',NoCheque='" + txtNoCheque.Text + "',MontoCheque='" + txtMonto.Text + "',Procesado='" + lblProcesado.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDChequesFuturos= (" + txtIDCheque.Text + ")"
                    GuardarDatos()
                    ConvertCurrent()
                    MessageBox.Show("Se ha procesado el cheque exitosamente. Recuerde realizar el abono a la cuenta si no se ha procesado el ingreso.", "Información Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("El cheque futurista No. " & txtIDCheque.Text & " del cliente: " & txtNombre.Text & " [" & txtIDCliente.Text & "] ya ha sido procesado exitosamente." & vbNewLine & vbNewLine & "Está seguro que desea revertir el procesamiento del cheque?", "Revertir Proceso Cheque Futurista", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    chkProcesar.Checked = False
                    ConvertDouble()
                    sqlQ = "UPDATE ChequesFuturos SET IDUsuario='" + lblIDUsuario.Text + "',Referencia='" + txtReferencia.Text + "',IDBanco='" + lblIDBanco.Text + "',FechaDeposito='" + DtpFechaDeposito.Value + "',NoCheque='" + txtNoCheque.Text + "',MontoCheque='" + txtMonto.Text + "',Procesado='" + lblProcesado.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDChequesFuturos= (" + txtIDCheque.Text + ")"
                    GuardarDatos()
                    ConvertCurrent()
                    MessageBox.Show("Se ha revertido el procesado del cheque exitosamente.", "Información Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If
        End If
    End Sub

    Sub RefrescarTablaFacturasGuardadas()
        Try

            DgvFacturas.Rows.Clear()
            Con.Open()
            Dim CmdFacts As New MySqlCommand("SELECT IDFactura,SecondID,Fecha,FechaVencimiento,FacturaDatos.DiasVencidos,TotalNeto,BalanceAnterior,Cargos,Debito,IDChequesFuturosDetalle FROM chequesfuturosdetalle INNER JOIN FacturaDatos on ChequesFuturosDetalle.IDFactura=FacturaDatos.IDFacturaDatos WHERE IDChequesFuturo='" + txtIDCheque.Text + "'", Con)
            Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader

            While LectorFacturas.Read
                DgvFacturas.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), CDate(LectorFacturas.GetValue(2)).ToString("dd/MM/yyyy"), CDate(LectorFacturas.GetValue(3)).ToString("dd/MM/yyyy"), LectorFacturas.GetValue(4), LectorFacturas.GetValue(5), LectorFacturas.GetValue(6), LectorFacturas.GetValue(7), LectorFacturas.GetValue(8), False, LectorFacturas.GetValue(9))
            End While

            LectorFacturas.Close()
            Con.Close()

            For Each Rows As DataGridViewRow In DgvFacturas.Rows
                Rows.Cells(10).Value = (CDbl(Rows.Cells(6).Value) - CDbl(Rows.Cells(8).Value)).ToString("C")

                If CDbl(Rows.Cells(8).Value) = CDbl(Rows.Cells(6).Value) Then
                    Rows.Cells(9).Value = True
                End If
            Next


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CalcularBalances()
        Throw New NotImplementedException
    End Sub

End Class