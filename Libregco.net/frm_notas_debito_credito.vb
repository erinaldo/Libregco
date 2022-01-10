Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_notas_debito_credito

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Incluir As New DataGridViewCheckBoxColumn
    Dim HeaderIncluir As New CheckBox
    Friend lblIDUsuario, lblIDTipoNota, lblIDComprobante, TipoNota, Itbis, lblNoNCF, DefaultCurrency As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_notas_debito_credito_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        SetItbis()
        Permisos = PasarPermisos(Me.Tag)
        ColumnasDgvDocs()
        AddHeaderCheckBox()
        SelectUsuario()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub SetItbis()
        Con.Open()
        cmd = New MySqlCommand("Select Value3Double from Configuracion where IDConfiguracion=11", Con)
        Itbis.Text = Convert.ToDouble(cmd.ExecuteScalar)

        'Moneda predeterminada
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=209", Con)
        DefaultCurrency.Text = CInt(Convert.ToString(cmd.ExecuteScalar()))

        Con.Close()
    End Sub

    Private Sub ColumnasDgvDocs()
        DgvFacturas.Columns.Clear()

        With DgvFacturas
            .Columns.Add("IDFacturaDatos", "No. Factura")   '0
            .Columns.Add("NCF", "NCF") '1
            .Columns.Add("Fecha", "Fecha") '2
            .Columns.Add("FechaVencimiento", "Venc") '3
            .Columns.Add("DiasVencidos", "Días") '4
            .Columns.Add("TotalNeto", "Monto") '5
            .Columns.Add("Balance", "Balance") '6
            .Columns.Add(Incluir) '7
            .Columns.Add("Aplicar", "Aplicar") '8
            .Columns.Add("Itbis", "Itbis") '9
            .Columns.Add("IDNotaDetalle", "IDNotaDetalle") '10
            .Columns.Add("SecondID", "No. Factura") '11
        End With

        PropiedadesDgvFactura()
    End Sub


    Private Sub PropiedadesDgvFactura()
        Try
            If DgvFacturas.Columns.Count > 0 Then
                Dim DatagridWidth As Double = (DgvFacturas.Width - DgvFacturas.RowHeadersWidth) / 100
                With DgvFacturas
                    .Columns(0).Visible = False
                    .Columns(1).Width = DatagridWidth * 14
                    .Columns(1).ReadOnly = True
                    .Columns(2).Width = DatagridWidth * 8
                    .Columns(2).ReadOnly = True
                    .Columns(3).Width = DatagridWidth * 8
                    .Columns(3).ReadOnly = True
                    .Columns(4).Width = DatagridWidth * 6
                    .Columns(4).ReadOnly = True
                    .Columns(5).Width = DatagridWidth * 11
                    .Columns(5).DefaultCellStyle.Format = ("C")
                    .Columns(6).Width = DatagridWidth * 11
                    .Columns(6).DefaultCellStyle.Format = ("C")
                    .Columns(8).DefaultCellStyle.Format = ("C")
                    .Columns(8).Width = DatagridWidth * 11
                    .Columns(9).DefaultCellStyle.Format = ("C")
                    .Columns(9).Width = DatagridWidth * 11
                    .Columns(10).Visible = False
                    .Columns(11).DisplayIndex = 0
                    .Columns(11).Width = DatagridWidth * 14
                    .Columns(11).ReadOnly = True

                    If Me.WindowState = FormWindowState.Normal Then
                        .Columns(3).HeaderText = "Venc."
                    Else
                        .Columns(3).HeaderText = "Vencimiento"
                    End If
                End With

                With Incluir
                    .HeaderText = ""
                    .Name = "Incluir"
                    .Width = DatagridWidth * 6
                    .ThreeState = False
                    .TrueValue = 1
                    .FalseValue = 0
                    .FlatStyle = FlatStyle.Standard
                End With
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
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

    Private Sub DgvFacturas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFacturas.CellEndEdit
        DgvFacturas.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvFacturas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvFacturas.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)
        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = DgvFacturas.CurrentCell.ColumnIndex

        If Columna = 8 Or Columna = 9 Then
            Dim Caracter As Char = e.KeyChar
            Dim Txt As TextBox = CType(sender, TextBox)

            If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") And (Txt.Text.Contains(",") = False) Then

                e.Handled = False
            Else
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub DgvFacturas_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvFacturas.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvFacturas.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvFacturas.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvFacturas.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub DgvFacturas_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvFacturas.CellPainting
        If e.RowIndex = -1 AndAlso e.ColumnIndex = 7 Then
            ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex)
        End If
    End Sub

    Private Sub DgvFacturas_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvFacturas.CurrentCellDirtyStateChanged
        If DgvFacturas.IsCurrentCellDirty Then
            DgvFacturas.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub ResetHeaderCheckBoxLocation(ByVal ColumnIndex As Integer, ByVal RowIndex As Integer)
        Dim Rect As Rectangle = DgvFacturas.GetCellDisplayRectangle(ColumnIndex, RowIndex, True)
        Dim Pt As New Point()
        Pt.X = Rect.Location.X + (Rect.Width - HeaderIncluir.Width) \ 2 + 1
        Pt.Y = Rect.Location.Y + (Rect.Height - HeaderIncluir.Height) \ 2 + 1
        HeaderIncluir.Location = Pt
    End Sub

    Private Sub HeaderIncluir_CheckedChanged(sender As Object, e As EventArgs)
        Try
            Dim x As Integer = 0
            Dim HeaderBox As CheckBox = DirectCast(DgvFacturas.Controls.Find("HeaderIncluir", True)(0), CheckBox)

            For Each Rows As DataGridViewRow In DgvFacturas.Rows
                Rows.Cells(7).Value = HeaderBox.Checked
            Next

            If HeaderIncluir.Checked = True Then
                For Each Rows As DataGridViewRow In DgvFacturas.Rows
                    Rows.Cells(8).Value = CDbl(Rows.Cells(6).Value).ToString("C")
                Next
            Else
                For Each Rows As DataGridViewRow In DgvFacturas.Rows
                    Rows.Cells(8).Value = CDbl(0).ToString("C")
                Next
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgvFacturas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFacturas.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 8 Or e.ColumnIndex = 9 Then
                DgvFacturas.EditMode = DataGridViewEditMode.EditOnEnter
            End If
        End If

    End Sub

    Private Sub DgvFacturas_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFacturas.CellValueChanged
        Try

            If e.ColumnIndex = 8 Then
                If rdbNotaCredito.Checked = True Then
                    If CDbl(DgvFacturas.CurrentRow.Cells(8).Value) > CDbl(DgvFacturas.CurrentRow.Cells(6).Value) Then
                        MessageBox.Show("El monto aplicado excede el balance de la factura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        DgvFacturas.CurrentRow.Cells(8).Value = CDbl(DgvFacturas.CurrentRow.Cells(6).Value).ToString("C")
                    Else
                        DgvFacturas.CurrentRow.Cells(8).Value = CDbl(DgvFacturas.CurrentRow.Cells(8).Value).ToString("C")
                    End If
                Else
                    DgvFacturas.CurrentRow.Cells(8).Value = CDbl(DgvFacturas.CurrentRow.Cells(8).Value).ToString("C")
                End If

                DgvFacturas.CurrentRow.Cells(9).Value = ((CDbl(DgvFacturas.CurrentRow.Cells(8).Value)) - ((CDbl(DgvFacturas.CurrentRow.Cells(8).Value) / (CDbl(1) + (CDbl(Itbis.Text)))))).ToString("C")

            End If
        Catch ex As Exception
            DgvFacturas.CurrentRow.Cells(8).Value = CDbl(0).ToString("C")
        End Try

        Try
            If e.ColumnIndex = 9 Then
                If CDbl(DgvFacturas.CurrentRow.Cells(9).Value) > (CDbl(DgvFacturas.CurrentRow.Cells(8).Value) * 0.18) Then
                    MessageBox.Show("El ITBIS no puede ser mayor que: " & (CDbl(DgvFacturas.CurrentRow.Cells(8).Value) * CDbl(0.18)).ToString("C") & ".", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    DgvFacturas.CurrentRow.Cells(9).Value = CDbl(0).ToString("C")
                Else
                    DgvFacturas.CurrentRow.Cells(9).Value = CDbl(DgvFacturas.CurrentRow.Cells(9).Value).ToString("C")
                End If
            End If

        Catch ex As Exception
            DgvFacturas.CurrentRow.Cells(9).Value = CDbl(0).ToString("C")
        End Try

        Try
            If e.ColumnIndex = 7 Then
                Dim IsTicked As Boolean = CBool(DgvFacturas.CurrentRow.Cells(7).Value)
                If IsTicked Then
                    DgvFacturas.CurrentRow.Cells(8).Value = CDbl(DgvFacturas.CurrentRow.Cells(6).Value).ToString("C")
                Else
                    DgvFacturas.CurrentRow.Cells(8).Value = CDbl(0).ToString("C")
                End If
            End If
        Catch ex As Exception
        End Try

        DgvFacturas.Invalidate()
        SumColumns()
    End Sub

    Private Sub SumColumns()
        Try
            Dim Neto As Double = 0
            Dim CalcItbis As Double = 0


            For Each Rows As DataGridViewRow In DgvFacturas.Rows
                CalcItbis = CalcItbis + (CDbl(Rows.Cells(9).Value))
                Neto = Neto + (CDbl(Rows.Cells(8).Value))
            Next
            txtNeto.Text = Neto.ToString("C")
            txtItbis.Text = CalcItbis.ToString("C")
            txtSubTotal.Text = (Neto - CalcItbis).ToString("C")


        Catch ex As Exception

        End Try
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        ControlSuperClave = 1
        ChkNulo.Checked = False
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        ChkNulo.Checked = False
        ChkGenerarNCF.Checked = False
        rdbNotaDebito.Checked = True
        txtSubTotal.Text = CDbl(0).ToString("C")
        txtItbis.Text = CDbl(0).ToString("C")
        txtNeto.Text = CDbl(0).ToString("C")
        cbxMoneda.EditValue = CInt(DefaultCurrency.Text)
        lblStatusBar.Text = "Listo"
        GPCliente.Text = " Información general"
        PicImagen.Image = My.Resources.no_photo
        lblNoNCF.Text = ""
        btnBuscarCliente.Focus()
        HeaderIncluir.Checked = False
        SetTipoNota()
        Hora.Enabled = True
    End Sub

    Private Sub SetTipoNota()
        If rdbNotaCredito.Checked = True Then
            lblIDTipoNota.Text = 2
            TipoNota.Text = "Nota de Crédito"
            lblIDComprobante.Text = 4
        ElseIf rdbNotaDebito.Checked = True Then
            lblIDTipoNota.Text = 1
            TipoNota.Text = "Nota de Débito"
            lblIDComprobante.Text = 3
        End If
    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtBalanceGral.Clear()
        txtBalanceGeneralCargos.Clear()
        txtUltimoPago.Clear()
        lblCalificacion.Text = ""
        txtSecondID.Clear()
        DgvFacturas.Rows.Clear()
        cbxMoneda.Properties.Items.Clear()
        ILbcBalances.Items.Clear()
    End Sub

    Sub RefrescarBalances()
        Try
            If txtIDCliente.Text <> "" Then
                Dim ds As New DataSet

                ConMixta.Open()

                cbxMoneda.Properties.Items.Clear()
                ILbcBalances.Items.Clear()

                cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto,Signo,Balance,MonedaImagen,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos LEFT JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda and FacturaDatos.IDCliente=Clientes_Balances.IDCliente) as CargosCliente FROM Libregco.tipomoneda INNER JOIN Libregco.Clientes_Balances on TipoMoneda.IDTipoMoneda=Clientes_Balances.IDMoneda Where Clientes_Balances.IDCliente='" + txtIDCliente.Text + "' Order by Balance ASC", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds, "tipomoneda")

                For Each Fila As DataRow In ds.Tables("tipomoneda").Rows
                    Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem
                    If CDbl(Fila.Item("CargosCliente")) = 0 Then
                        nvmoneda.Description = Fila.Item("Texto") & " " & CDbl(Fila.Item("Balance")).ToString("C") & "."
                    Else
                        nvmoneda.Description = Fila.Item("Texto") & " " & CDbl(Fila.Item("Balance")).ToString("C") & " (+) más cargos acumulados por " & CDbl(Fila.Item("CargosCliente")).ToString("C") & "."
                    End If

                    nvmoneda.Value = Fila.Item("IDTipoMoneda")

                    If Fila.Item("IDTipoMoneda") = 1 Then
                        nvmoneda.ImageIndex = 0
                    ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                        nvmoneda.ImageIndex = 1
                    ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                        nvmoneda.ImageIndex = 2
                    End If

                    cbxMoneda.Properties.Items.Add(nvmoneda)

                    Dim itm As New DevExpress.XtraEditors.Controls.ImageListBoxItem
                    Dim wFile As System.IO.FileStream

                    itm.Value = Fila.Item("IDTipoMoneda")

                    If CDbl(Fila.Item("CargosCliente")) = 0 Then
                        itm.Description = Fila.Item("Signo") & " " & CDbl(Fila.Item("Balance")).ToString("C")
                    Else
                        itm.Description = Fila.Item("Signo") & " " & CDbl(CDbl(Fila.Item("Balance")) + CDbl(Fila.Item("CargosCliente"))).ToString("C")
                    End If

                    If Fila.Item("MonedaImagen") <> "" Then
                        If System.IO.File.Exists(Fila.Item("MonedaImagen")) Then
                            wFile = New FileStream(Fila.Item("MonedaImagen"), FileMode.Open, FileAccess.Read)
                            itm.ImageOptions.Image = ResizeImage(System.Drawing.Image.FromStream(wFile), 18)
                        Else
                            itm.ImageOptions.Image = ResizeImage(My.Resources.no_photo, 18)
                        End If
                    Else
                        itm.ImageOptions.Image = ResizeImage(My.Resources.no_photo, 18)
                    End If

                    ILbcBalances.Items.Add(itm)
                Next

                ds.Dispose()
                ConMixta.Close()
            End If

            cbxMoneda.EditValue = CInt(DefaultCurrency.Text)


            Dim dstemp As New DataSet

            Con.Open()
            cmd = New MySqlCommand("SELECT Balance,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos LEFT JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda and FacturaDatos.IDCliente=Clientes_Balances.IDCliente) as CargosCliente FROM Libregco.tipomoneda INNER JOIN Libregco.Clientes_Balances on TipoMoneda.IDTipoMoneda=Clientes_Balances.IDMoneda Where Clientes_Balances.IDCliente='" + txtIDCliente.Text + "' and Clientes_Balances.IDMoneda='" + cbxMoneda.EditValue.ToString + "' Order by Balance ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "tipomoneda")
            Con.Close()

            If dstemp.Tables("tipomoneda").Rows.Count > 0 Then
                txtBalanceGral.Text = CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("Balance")).ToString("C")
                txtBalanceGeneralCargos.Text = CDbl(CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("CargosCliente")) + CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("Balance"))).ToString("C")
            End If

            dstemp.Dispose()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub cbxMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMoneda.SelectedIndexChanged
        RefrescarTablaFacturas()

        Dim dstemp As New DataSet

        ConTemporal.Open()
        cmd = New MySqlCommand("SELECT Balance,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos LEFT JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda and FacturaDatos.IDCliente=Clientes_Balances.IDCliente) as CargosCliente FROM Libregco.tipomoneda INNER JOIN Libregco.Clientes_Balances on TipoMoneda.IDTipoMoneda=Clientes_Balances.IDMoneda Where Clientes_Balances.IDCliente='" + txtIDCliente.Text + "' and Clientes_Balances.IDMoneda='" + cbxMoneda.EditValue.ToString + "' Order by Balance ASC", ConTemporal)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "tipomoneda")
        ConTemporal.Close()

        If dstemp.Tables("tipomoneda").Rows.Count > 0 Then
            txtBalanceGral.Text = CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("Balance")).ToString("C")
            txtBalanceGeneralCargos.Text = CDbl(CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("CargosCliente")) + CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("Balance"))).ToString("C")
        End If

        ILbcBalances.SelectedValue = CInt(cbxMoneda.EditValue)
        dstemp.Dispose()
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Sub RefrescarTablaFacturas()
        Try
            DgvFacturas.Rows.Clear()
            Con.Open()
            Dim CmdFacts As New MySqlCommand("SELECT FacturaDatos.IDFacturaDatos,FacturaDatos.NCF,FacturaDatos.Fecha,FechaVencimiento,DiasVencidos,TotalNeto,FacturaDatos.Balance,FacturaDatos.SecondID FROM FacturaDatos LEFT JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion WHERE FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and FacturaDatos.Balance>0 AND Transaccion.IDMoneda='" + cbxMoneda.EditValue.ToString + "' and FacturaDatos.Nulo=0", Con)
            Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader
            While LectorFacturas.Read
                DgvFacturas.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), CDate(LectorFacturas.GetValue(2)).ToString("dd/MM/yyyy"), CDate(LectorFacturas.GetValue(3)).ToString("dd/MM/yyyy"), LectorFacturas.GetValue(4), LectorFacturas.GetValue(5), LectorFacturas.GetValue(6), False, CDbl(0).ToString("C"), CDbl(0).ToString("C"), "", LectorFacturas.GetValue(7))
            End While

            LectorFacturas.Close()
            Con.Close()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub HabilitarControles()
        txtConcepto.Enabled = True
        GbTipoTrans.Enabled = True
        DgvFacturas.Enabled = True
    End Sub

    Sub DeshabilitarControles()
        txtConcepto.Enabled = False
        GbTipoTrans.Enabled = False
        DgvFacturas.Enabled = False
    End Sub

    Private Sub rdbNotaDebito_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNotaDebito.CheckedChanged
        SetTipoNota()
        SumColumns()
    End Sub

    Private Sub rdbNotaCredito_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNotaCredito.CheckedChanged
        SetTipoNota()
        SumColumns()
    End Sub

    Private Sub ConvertDouble()
        txtSubTotal.Text = CDbl(txtSubTotal.Text)
        txtItbis.Text = CDbl(txtItbis.Text)
        txtNeto.Text = CDbl(txtNeto.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtSubTotal.Text = CDbl(txtSubTotal.Text).ToString("C")
        txtItbis.Text = CDbl(txtItbis.Text).ToString("C")
        txtNeto.Text = CDbl(txtNeto.Text).ToString("C")
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

    Private Sub UltNota()
        Try

            If txtIDNota.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDNotaDebCred from NotaDebitoCredito where IDNotaDebCred= (Select Max(IDNotaDebCred) from NotaDebitoCredito)", Con)
                txtIDNota.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDNota.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir la " & TipoNota.Text & "?", "Imprimir " & TipoNota.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub CalcularBalances()
        FunctCalcBcesFact(txtIDCliente.Text)
        FunctCalcBceGral(txtIDCliente.Text)
    End Sub

    Private Sub InsertDetalle()
        Try
            Dim y As Integer = 0
            Dim lblIDDetalleNota, lblIDFactura, lblBceAnterior, lblAplicado, lblitbis, lblTotal As New Label

            If txtIDNota.Text = "" Then
            Else
Inicio:
                If y = DgvFacturas.Rows.Count Then
                    GoTo Fin
                End If

                lblIDFactura.Text = DgvFacturas.Rows(y).Cells(0).Value
                lblBceAnterior.Text = DgvFacturas.Rows(y).Cells(6).Value
                lblAplicado.Text = CDbl(DgvFacturas.Rows(y).Cells(8).Value)
                lblitbis.Text = CDbl(DgvFacturas.Rows(y).Cells(9).Value)
                lblTotal.Text = CDbl(DgvFacturas.Rows(y).Cells(8).Value) + CDbl(DgvFacturas.Rows(y).Cells(9).Value)
                lblIDDetalleNota.Text = DgvFacturas.Rows(y).Cells(10).Value

                If lblIDDetalleNota.Text = "" Then         'Si es un registro nuevo
                    If CDbl(lblTotal.Text) = 0 Then     'Si el total es 0 entonces no hago nada.
                    Else                                'Si es diference a 0 y es un registro nuevo, entonces lo inserto
                        sqlQ = "Insert into NotaDebitoCreditoDetalle (IDNotaDebitoCredito,IDFactura,BceAnterior,Aplicado,Itbis) Values ('" + txtIDNota.Text + "','" + lblIDFactura.Text + "','" + lblBceAnterior.Text + "','" + lblAplicado.Text + "','" + lblitbis.Text + "')"
                        GuardarDatos()
                    End If
                Else                    'Si el registro ya existe.
                    If CDbl(lblTotal.Text) = 0 Then     'Si el total del existente es 0 entonces lo elimino.
                        sqlQ = "Delete from NotaDebitoCreditoDetalle Where IDNotaDetalle = '" + lblIDDetalleNota.Text + "'"
                        GuardarDatos()
                    Else            'Si el total es diferente a 0 entonces actualizo sus datos.
                        sqlQ = "UPDATE NotaDebitoCreditoDetalle SET BceAnterior='" + lblBceAnterior.Text + "',Aplicado='" + lblAplicado.Text + "',Itbis='" + lblitbis.Text + "' WHERE IDNotaDetalle= '" + lblIDDetalleNota.Text + "'"
                        GuardarDatos()
                    End If
                End If

            End If

            y = y + 1
            GoTo Inicio
Fin:

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " Desde Insertar Detalle")
        End Try
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
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

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            DeshabilitarControles()
        Else
            HabilitarControles()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If rdbNotaDebito.Checked = True Then
        Else
            For Each Rows As DataGridViewRow In DgvFacturas.Rows
                If (CDbl(Rows.Cells(8).Value)) > (CDbl(Rows.Cells(6).Value)) Then
                    MessageBox.Show("El monto a aplicar [" & (CDbl(Rows.Cells(8).Value)).ToString("C") & "] es mayor al balance de la factura [" & (CDbl(Rows.Cells(6).Value)).ToString("C") & "]." & vbNewLine & vbNewLine & "Para procesar la nota de crédito debe disminuir o igualar el monto a aplicar al balance de la factura.", ",Monto a aplicar excede balance de factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Next
        End If

        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar la " & TipoNota.Text & ".", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.Focus()
            Exit Sub
        ElseIf DgvFacturas.Rows.Count = 0 Then
            MessageBox.Show("No es posible procesar una nota de crédito/débito ya que el cliente no tiene facturas pendientes.", "No se han encontrado facturas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtConcepto.Text = "" Then
            MessageBox.Show("Escriba el concepto de la " & TipoNota.Text & ".", "Concepto de la " & TipoNota.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        ElseIf txtNeto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Aún no se han especificado los datos para procesar la " & TipoNota.Text & ".", "No hay datos para proceso de " & TipoNota.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDNota.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la " & TipoNota.Text & " del cliente: " & txtNombre.Text & ", en la base de datos?", "Guardar Nueva " & TipoNota.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                GetNCFsNumbers(lblIDComprobante.Text)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ConvertDouble()
                sqlQ = "INSERT INTO NotaDebitoCredito (IDSucursal,IDAlmacen,IDUsuario,Fecha,Hora,IDCliente,IDTipoNota,Concepto,GenerarNCF,NCF,SubTotal,Itbis,Neto,Nulo,Impreso) VALUES ('" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDUsuario.Text + "',CURDATE(),CURTIME(),'" + txtIDCliente.Text + "','" + lblIDTipoNota.Text + "','" + txtConcepto.Text + "','" + Convert.ToInt16(ChkGenerarNCF.Checked).ToString + "','" + NewNCFValue.Text + "','" + txtSubTotal.Text + "','" + txtItbis.Text + "','" + txtNeto.Text + "','" + Convert.ToInt16(ChkNulo.Checked).ToString + "',0)"
                GuardarDatos()
                ConvertCurrent()
                UltNota()
                SetSecondID()
                InsertDetalle()
                CalcularBalances()
                DeshabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la factura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE NotaDebitoCredito SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha=CURDATE(),Hora=CURTIME(),IDCliente='" + txtIDCliente.Text + "',IDTipoNota='" + lblIDTipoNota.Text + "',Concepto='" + txtConcepto.Text + "',GenerarNCF='" + Convert.ToInt16(ChkGenerarNCF.Checked).ToString + "',NCF='" + lblNoNCF.Text + "',SubTotal='" + txtSubTotal.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtNeto.Text + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDNotaDebCred= (" + txtIDNota.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertDetalle()
                CalcularBalances()
                DeshabilitarControles()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet
            Dim IDTipoDocumento As New Label
            Con.Open()
            DsTemp.Clear()

            If rdbNotaCredito.Checked = True Then
                IDTipoDocumento.Text = 15
            ElseIf rdbNotaDebito.Checked = True Then
                IDTipoDocumento.Text = 14
            End If

            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento='" + IDTipoDocumento.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE notadebitocredito SET IDTipoDocumento='" + IDTipoDocumento.Text + "',SecondID='" + lblSecondID.Text + "' WHERE IDNotaDebCred='" + txtIDNota.Text + "'"
            GuardarDatos()

            If rdbNotaCredito.Checked = True Then
                sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=15"
                GuardarDatos()
            Else
                sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=14"
                GuardarDatos()
            End If


        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If rdbNotaDebito.Checked = True Then
        Else
            For Each Rows As DataGridViewRow In DgvFacturas.Rows
                If (CDbl(Rows.Cells(8).Value)) > (CDbl(Rows.Cells(6).Value)) Then
                    MessageBox.Show("El monto a aplicar [" & (CDbl(Rows.Cells(8).Value)).ToString("C") & "] es mayor al balance de la factura [" & (CDbl(Rows.Cells(6).Value)).ToString("C") & "]." & vbNewLine & vbNewLine & "Para procesar la nota de crédito debe disminuir o igualar el monto a aplicar al balance de la factura.", ",Monto a aplicar excede balance de factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Next
        End If

        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar la " & TipoNota.Text & ".", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.Focus()
            Exit Sub
        ElseIf DgvFacturas.Rows.Count = 0 Then
            MessageBox.Show("No es posible procesar una nota de crédito/débito ya que el cliente no tiene facturas pendientes.", "No se han encontrado facturas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtConcepto.Text = "" Then
            MessageBox.Show("Escriba el concepto de la " & TipoNota.Text & ".", "Concepto de la " & TipoNota.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        ElseIf txtNeto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Aún no se han especificado los datos para procesar la " & TipoNota.Text & ".", "No hay datos para proceso de " & TipoNota.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDNota.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la " & TipoNota.Text & " del cliente: " & txtNombre.Text & ", en la base de datos?", "Guardar Nueva " & TipoNota.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                GetNCFsNumbers(lblIDComprobante.Text)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ConvertDouble()
                sqlQ = "INSERT INTO NotaDebitoCredito (IDSucursal,IDAlmacen,IDUsuario,Fecha,Hora,IDCliente,IDTipoNota,Concepto,GenerarNCF,NCF,SubTotal,Itbis,Neto,Nulo,Impreso) VALUES ('" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDUsuario.Text + "',CURDATE(),CURTIME(),'" + txtIDCliente.Text + "','" + lblIDTipoNota.Text + "','" + txtConcepto.Text + "','" + Convert.ToInt16(ChkGenerarNCF.Checked).ToString + "','" + NewNCFValue.Text + "','" + txtSubTotal.Text + "','" + txtItbis.Text + "','" + txtNeto.Text + "','" + Convert.ToInt16(ChkNulo.Checked).ToString + "',0)"
                GuardarDatos()
                ConvertCurrent()
                UltNota()
                SetSecondID()
                InsertDetalle()
                CalcularBalances()
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
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la factura?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE NotaDebitoCredito SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha=CURDATE(),Hora=CURTIME(),IDCliente='" + txtIDCliente.Text + "',IDTipoNota='" + lblIDTipoNota.Text + "',Concepto='" + txtConcepto.Text + "',GenerarNCF='" + Convert.ToInt16(ChkGenerarNCF.Checked).ToString + "',NCF='" + lblNoNCF.Text + "',SubTotal='" + txtSubTotal.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtNeto.Text + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDNotaDebCred= (" + txtIDNota.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertDetalle()
                CalcularBalances()
                DeshabilitarControles()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_nota_debitocredito.ShowDialog(Me)
    End Sub

    Sub VerifyBalances()
        If DgvFacturas.Rows.Count = 0 Then
            For Each itm As DevExpress.XtraEditors.Controls.ImageComboBoxItem In cbxMoneda.Properties.Items
                If cbxMoneda.EditValue <> itm.Value Then
                    cbxMoneda.EditValue = CInt(itm.Value)
                End If

                If DgvFacturas.Rows.Count > 0 Then
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If rdbNotaDebito.Checked = True Then
        Else
            For Each Rows As DataGridViewRow In DgvFacturas.Rows
                If (CDbl(Rows.Cells(8).Value)) > (CDbl(Rows.Cells(6).Value)) Then
                    MessageBox.Show("El monto a aplicar [" & (CDbl(Rows.Cells(8).Value)).ToString("C") & "] es mayor al balance de la factura [" & (CDbl(Rows.Cells(6).Value)).ToString("C") & "]." & vbNewLine & vbNewLine & "Para procesar la nota de crédito debe disminuir o igualar el monto a aplicar al balance de la factura.", ",Monto a aplicar excede balance de factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            Next
        End If

        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione el cliente para procesar la " & TipoNota.Text & ".", "No se ha específicado el cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCliente.Focus()
            Exit Sub
        ElseIf DgvFacturas.Rows.Count = 0 Then
            MessageBox.Show("No es posible procesar una nota de crédito/débito ya que el cliente no tiene facturas pendientes.", "No se han encontrado facturas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtConcepto.Text = "" Then
            MessageBox.Show("Escriba el concepto de la " & TipoNota.Text & ".", "Concepto de la " & TipoNota.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        ElseIf txtNeto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Aún no se han especificado los datos para procesar la " & TipoNota.Text & ".", "No hay datos para proceso de " & TipoNota.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If


        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de " & TipoNota.Text & " del cliente " & txtNombre.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar " & TipoNota.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 85
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE NotaDebitoCredito SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha=CURDATE(),Hora=CURTIME(),IDCliente='" + txtIDCliente.Text + "',IDTipoNota='" + lblIDTipoNota.Text + "',Concepto='" + txtConcepto.Text + "',GenerarNCF='" + Convert.ToInt16(ChkGenerarNCF.Checked).ToString + "',NCF='" + lblNoNCF.Text + "',SubTotal='" + txtSubTotal.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtNeto.Text + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDNotaDebCred= (" + txtIDNota.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcularBalances()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDNota.Text = "" Then
            MessageBox.Show("No hay un registro de nota de débito/crédito abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular la " & TipoNota.Text & " del cliente: " & txtNombre.Text & " del sistema?", "Anular " & TipoNota.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 86
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE NotaDebitoCredito SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha=CURDATE(),Hora=CURTIME(),IDCliente='" + txtIDCliente.Text + "',IDTipoNota='" + lblIDTipoNota.Text + "',Concepto='" + txtConcepto.Text + "',GenerarNCF='" + Convert.ToInt16(ChkGenerarNCF.Checked).ToString + "',NCF='" + lblNoNCF.Text + "',SubTotal='" + txtSubTotal.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtNeto.Text + "',Nulo='" + Convert.ToInt16(ChkNulo.Checked).ToString + "' WHERE IDNotaDebCred= (" + txtIDNota.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcularBalances()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub frm_notas_debito_credito_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadesDgvFactura()
    End Sub

    Private Sub BuscarNotaDeDébitoCréditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarNotaDeDébitoCréditoToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub
End Class