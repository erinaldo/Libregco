Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_nota_debito_credito_cxp

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Incluir As New DataGridViewCheckBoxColumn
    Dim HeaderIncluir As New CheckBox
    Friend lblIDUsuario, Itbis, lblNulo As New Label
    Dim ImponerEscrituradeNCF, TypeOfMetod As String
    Dim Permisos As New ArrayList
    Private Sub frm_nota_debito_credito_cxp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SetItbis()
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

        'TipoComprobante
        cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=75", Con)
        TypeOfMetod = Convert.ToString(cmd.ExecuteScalar())

        Con.Close()
    End Sub

    Private Sub ColumnasDgvDocs()
        DgvFacturas.Columns.Clear()

        With DgvFacturas
            .Columns.Add("IDCompra", "Código")   '0
            .Columns.Add("NoFactura", "No. Fact") '1
            .Columns.Add("Fecha", "Fecha") '2
            .Columns.Add("Referencia", "Referencia") '3
            .Columns.Add("NCF", "NCF") '4
            .Columns.Add("TotalNeto", "Monto") '5
            .Columns.Add("Balance", "Balance") '6
            .Columns.Add(Incluir) '7
            .Columns.Add("Aplicar", "Aplicar") '8
            .Columns.Add("Itbis", "Itbis") '9
            .Columns.Add("IDNotaDetalle", "IDNotaDetalle") '10
            .Columns.Add("SecondID", "Compra")
        End With

        PropiedadesDgvFactura()
    End Sub


    Sub RefrescarTablaFacturas()
        Try
            DgvFacturas.Rows.Clear()
            Con.Open()
            Dim CmdFacts As New MySqlCommand("SELECT IDCompra,NoFactura,Fecha,Referencia,NCF,TotalNeto,Balance,SecondID FROM Compras WHERE Balance>0 AND IDSuplidor='" + txtIDSuplidor.Text + "' and Nulo=0", Con)

            Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader
            While LectorFacturas.Read
                DgvFacturas.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), CDate(LectorFacturas.GetValue(2)).ToString("dd/MM/yyyy"), LectorFacturas.GetValue(3), LectorFacturas.GetValue(4), LectorFacturas.GetValue(5), LectorFacturas.GetValue(6), False, CDbl(0).ToString("C"), CDbl(0).ToString("C"), "", LectorFacturas.GetValue(7))
            End While

            LectorFacturas.Close()
            Con.Close()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub PropiedadesDgvFactura()
        With DgvFacturas
            .Columns(0).Visible = False
            .Columns(1).Width = 110
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).Width = 95
            .Columns(3).Visible = False
            .Columns(3).ReadOnly = True
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).Width = 130
            .Columns(4).ReadOnly = True
            .Columns(5).Width = 120
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(5).ReadOnly = True
            .Columns(6).Width = 115
            .Columns(6).DefaultCellStyle.Format = ("C")
            .Columns(6).ReadOnly = True
            .Columns(8).DefaultCellStyle.Format = ("C")
            .Columns(8).Width = 130
            .Columns(8).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
            .Columns(9).DefaultCellStyle.Format = ("C")
            .Columns(9).Width = 130
            .Columns(9).DefaultCellStyle.BackColor = Color.LightGoldenrodYellow
            .Columns(10).Visible = False
            .Columns(11).Width = 110
            .Columns(11).DisplayIndex = 0
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(11).ReadOnly = True
        End With

        With Incluir
            .HeaderText = ""
            .Name = "Incluir"
            .Width = 20
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .FlatStyle = FlatStyle.Standard
        End With

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
                If CbxTipoComprobante.Tag = 24 Then
                    If CDbl(DgvFacturas.CurrentRow.Cells(8).Value) > CDbl(DgvFacturas.CurrentRow.Cells(6).Value) Then
                        MessageBox.Show("El monto aplicado excede el balance de la factura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        DgvFacturas.CurrentRow.Cells(8).Value = CDbl(DgvFacturas.CurrentRow.Cells(6).Value).ToString("C")
                    Else
                        DgvFacturas.CurrentRow.Cells(8).Value = CDbl(DgvFacturas.CurrentRow.Cells(8).Value).ToString("C")
                    End If
                Else
                    DgvFacturas.CurrentRow.Cells(8).Value = CDbl(DgvFacturas.CurrentRow.Cells(8).Value).ToString("C")
                End If

                If CDbl(DgvFacturas.CurrentRow.Cells(8).Value) < CDbl(DgvFacturas.CurrentRow.Cells(9).Value) Then
                    DgvFacturas.CurrentRow.Cells(9).Value = (CDbl(DgvFacturas.CurrentRow.Cells(8).Value) * CDbl(Itbis.Text)).ToString("C")
                End If

            End If
        Catch ex As Exception
            DgvFacturas.CurrentRow.Cells(8).Value = CDbl(0).ToString("C")
        End Try

        Try
            If e.ColumnIndex = 9 Then
                If CDbl(DgvFacturas.CurrentRow.Cells(9).Value) > (CDbl(DgvFacturas.CurrentRow.Cells(8).Value) * CDbl(Itbis.Text)) Then
                    MessageBox.Show("El ITBIS no puede ser mayor que: " & (CDbl(DgvFacturas.CurrentRow.Cells(8).Value) * CDbl(Itbis.Text)).ToString("C") & ".", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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
            Dim SubTotal As Double = 0
            Dim CalcItbis As Double = 0

            For Each Rows As DataGridViewRow In DgvFacturas.Rows
                CalcItbis = CalcItbis + (CDbl(Rows.Cells(9).Value))
                SubTotal = SubTotal + (CDbl(Rows.Cells(8).Value))
            Next
            txtItbis.Text = CalcItbis.ToString("C")
            txtSubTotal.Text = (SubTotal - CalcItbis).ToString("C")

            txtNeto.Text = (CDbl(txtSubTotal.Text) + CDbl(txtItbis.Text)).ToString("C")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        ControlSuperClave = 1
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        txtHora.Text = TimeOfDay
        ChkNulo.Checked = False
        txtSubTotal.Text = CDbl(0).ToString("C")
        txtItbis.Text = CDbl(0).ToString("C")
        txtNeto.Text = CDbl(0).ToString("C")
        lblNulo.Text = 0
        btnBuscarSup.Focus()
        HeaderIncluir.Checked = False
        FillComprobanteFiscal()
    End Sub

    Private Sub FillComprobanteFiscal()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT * FROM comprobantefiscal where TipoComprobante like '%Nota%' ORDER BY TipoComprobante ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "ComprobanteFiscal")
            CbxTipoComprobante.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")
            For Each Fila As DataRow In Tabla.Rows
                CbxTipoComprobante.Items.Add(Fila.Item("TipoComprobante"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LimpiarDatos()
        txtIDSuplidor.Clear()
        txtNombreSuplidor.Clear()
        txtBalanceSup.Clear()
        txtUltimoPago.Clear()
        txtUltimoMonto.Clear()
        txtIDNota.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        txtConcepto.Clear()
        txtNoNcf.Clear()
        txtSubTotal.Clear()
        txtItbis.Clear()
        txtNeto.Clear()
        txtSecondID.Clear()
        DgvFacturas.Rows.Clear()
    End Sub

    Private Sub HabilitarControles()
        txtConcepto.Enabled = True
        GbTipoTrans.Enabled = True
        DgvFacturas.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        txtConcepto.Enabled = False
        GbTipoTrans.Enabled = False
        DgvFacturas.Enabled = False
    End Sub

    Private Sub SetIDComprobante()
        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT * from" & SysName.Text & "ComprobanteFiscal Where TipoComprobante='" + CbxTipoComprobante.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Comprobantes")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds.Tables("Comprobantes")
        CbxTipoComprobante.Tag = Tabla.Rows(0).Item("IDComprobanteFiscal")
        ImponerEscrituradeNCF = Tabla.Rows(0).Item("ImposicionCompra")

        If txtIDNota.Text = "" Then
            If ImponerEscrituradeNCF = 1 Then
                If TypeOfMetod = 1 Then
                    txtNoNcf.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                    txtNoNcf.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                ElseIf TypeOfMetod = 2 Then
                    txtNoNcf.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                    txtNoNcf.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                ElseIf TypeOfMetod = 3 Then
                    txtNoNcf.Mask = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF") & "00000000"
                    txtNoNcf.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                End If
            Else
                If TypeOfMetod = 1 Then
                    txtNoNcf.Mask = ""
                    txtNoNcf.Text = ""
                ElseIf TypeOfMetod = 2 Then
                    txtNoNcf.Mask = ""
                    txtNoNcf.Text = ""
                ElseIf TypeOfMetod = 3 Then
                    txtNoNcf.Mask = ""
                    txtNoNcf.Text = ""
                End If
            End If

        Else
            txtNoNcf.Mask = ""
        End If

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
                cmd = New MySqlCommand("Select IDNotaDebitoCreditoCXP from NotaDebitoCreditocxp where IDNotaDebitoCreditoCXP= (Select Max(IDNotaDebitoCreditocxp) from NotaDebitoCreditocxp)", Con)
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
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir la " & CbxTipoComprobante.Text & "?", "Imprimir " & CbxTipoComprobante.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub CalcBces()
        FunctCalcBcesFactSuplidor(txtIDSuplidor.Text)
        FunctCalcBceSuplidor(txtIDSuplidor.Text)
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
                lblBceAnterior.Text = CDbl(DgvFacturas.Rows(y).Cells(6).Value)
                lblAplicado.Text = CDbl(DgvFacturas.Rows(y).Cells(8).Value)
                lblitbis.Text = CDbl(DgvFacturas.Rows(y).Cells(9).Value)
                lblTotal.Text = CDbl(DgvFacturas.Rows(y).Cells(8).Value) + CDbl(DgvFacturas.Rows(y).Cells(9).Value)
                lblIDDetalleNota.Text = DgvFacturas.Rows(y).Cells(10).Value

                If lblIDDetalleNota.Text = "" Then         'Si es un registro nuevo
                    If CDbl(lblTotal.Text) = 0 Then     'Si el total es 0 entonces no hago nada.
                    Else                                'Si es diference a 0 y es un registro nuevo, entonces lo inserto
                        sqlQ = "Insert into NotaDebitoCreditocxpdetalle (IDNotaDebitoCreditoCXP,IDCompra,BceAnterior,Aplicado,Itbis) Values ('" + txtIDNota.Text + "','" + lblIDFactura.Text + "','" + lblBceAnterior.Text + "','" + lblAplicado.Text + "','" + lblitbis.Text + "')"
                        GuardarDatos()
                    End If
                Else                    'Si el registro ya existe.
                    If CDbl(lblTotal.Text) = 0 Then     'Si el total del existente es 0 entonces lo elimino.
                        sqlQ = "Delete from NotaDebitoCreditocxpdetalle Where IDNotaDebitoCreditoCXPDetalle = '" + lblIDDetalleNota.Text + "'"
                        GuardarDatos()
                    Else            'Si el total es diferente a 0 entonces actualizo sus datos.
                        sqlQ = "UPDATE NotaDebitoCreditocxpdetalle SET BceAnterior='" + lblBceAnterior.Text + "',Aplicado='" + lblAplicado.Text + "',Itbis='" + lblitbis.Text + "' WHERE IDNotaDebitoCreditoCXPDetalle= '" + lblIDDetalleNota.Text + "'"
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
        btnGuardarC.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
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

    Sub FillChkBox()

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Nulo FROM NotaDebitoCredito Where IDNotaDebCred='" + txtIDNota.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Nota")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("Nota")
        lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))

        If lblNulo.Text = 0 Then
            ChkNulo.Checked = False
        Else
            ChkNulo.Checked = True
        End If
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor para procesar la " & CbxTipoComprobante.Text & ".", "No se ha específicado el suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSup.Focus()
            Exit Sub
        ElseIf CbxTipoComprobante.Text = "" Then
            MessageBox.Show("Seleccione el tipo de comprobante fiscal correspondiente.", "Seleccione tipo de NCF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxTipoComprobante.Focus()
            CbxTipoComprobante.DroppedDown = True
            Exit Sub
        ElseIf ImponerEscrituradeNCF = 1 And txtnoNCF.MaskFull = False Then
            MessageBox.Show("El tipo de comprobante fiscal seleccionado obliga a la escritura del NCF completamente. Por favor ingrese el número de comprobante fiscal.", "NCF incompleto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNoNcf.Focus()
            Exit Sub
        ElseIf txtConcepto.Text = "" Then
            MessageBox.Show("Escriba el concepto de la " & CbxTipoComprobante.Text & ".", "Concepto de la " & CbxTipoComprobante.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtConcepto.Focus()
            Exit Sub
        ElseIf txtNeto.Text = CDbl(0).ToString("C") Then
            MessageBox.Show("Aún no se han especificado los datos para procesar la " & CbxTipoComprobante.Text & ".", "No hay datos para proceso de " & CbxTipoComprobante.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDNota.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la " & CbxTipoComprobante.Text & " del suplidor: " & txtNombreSuplidor.Text & ", en la base de datos?", "Guardar " & CbxTipoComprobante.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO NotaDebitoCreditoCXP (IDSucursal,IDAlmacen,IDUsuario,Fecha,Hora,IDSuplidor,IDNCF,Concepto,NCF,SubTotal,Itbis,Neto,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + txtIDSuplidor.Text + "','" + CbxTipoComprobante.Tag.ToString + "','" + txtConcepto.Text + "','" + txtNoNcf.Text + "','" + txtSubTotal.Text + "','" + txtItbis.Text + "','" + txtNeto.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltNota()
                SetSecondID()
                InsertDetalle()
                CalcBces()
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
                sqlQ = "UPDATE NotaDebitoCreditoCXP SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSuplidor='" + txtIDSuplidor.Text + "',IDNCF='" + CbxTipoComprobante.Tag.ToString + "',Concepto='" + txtConcepto.Text + "',NCF='" + txtNoNcf.Text + "',SubTotal='" + txtSubTotal.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtNeto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDNotaDebitoCreditoCXP= (" + txtIDNota.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertDetalle()
                CalcBces()
                DeshabilitarControles()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub btnBuscarSup_Click(sender As Object, e As EventArgs) Handles btnBuscarSup.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub CbxTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxTipoComprobante.SelectedIndexChanged
        SetIDComprobante()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet
            Dim IDTipoDocumento As New Label

            If CbxTipoComprobante.Tag = 4 Then
                IDTipoDocumento.Text = 22
            ElseIf CbxTipoComprobante.Tag = 3 Then
                IDTipoDocumento.Text = 21
            End If

            Con.Open()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento='" + IDTipoDocumento.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE notadebitocreditocxp SET IDTipoDocumento='" + IDTipoDocumento.Text + "',SecondID='" + lblSecondID.Text + "' WHERE IDNotaDebitoCreditoCXP='" + txtIDNota.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento='" + IDTipoDocumento.Text + "'"
            GuardarDatos()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtNoNcf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoNcf.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "AB0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNoNcf_Leave(sender As Object, e As EventArgs) Handles txtNoNcf.Leave
        If CbxTipoComprobante.Text <> "" Then

            If txtNoNcf.MaskFull = False And ImponerEscrituradeNCF = 1 Then
                MessageBox.Show("No se ha completado la numeración del comprobante fiscal de la factura de compra. Por favor complete el registro.", "Numeración no completada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Else
                txtNoNcf.Text = txtNoNcf.Text.ToUpper
            End If
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_nota_debitocreditocxp.ShowDialog(Me)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de " & CbxTipoComprobante.Text & " del suplidor " & txtNombreSuplidor.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar " & CbxTipoComprobante.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 83
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE NotaDebitoCreditoCXP SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSuplidor='" + txtIDSuplidor.Text + "',IDNCF='" + CbxTipoComprobante.Tag.ToString + "',Concepto='" + txtConcepto.Text + "',NCF='" + txtNoNcf.Text + "',SubTotal='" + txtSubTotal.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtNeto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDNotaDebitoCreditoCXP= (" + txtIDNota.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcBces()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDNota.Text = "" Then
            MessageBox.Show("No hay un registro de nota de débito/crédito abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular la " & CbxTipoComprobante.Text & " del suplidor: " & txtNombreSuplidor.Text & " del sistema?", "Anular " & CbxTipoComprobante.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 81
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE NotaDebitoCreditoCXP SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSuplidor='" + txtIDSuplidor.Text + "',IDNCF='" + CbxTipoComprobante.Tag.ToString + "',Concepto='" + txtConcepto.Text + "',NCF='" + txtNoNcf.Text + "',SubTotal='" + txtSubTotal.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtNeto.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDNotaDebitoCreditoCXP= (" + txtIDNota.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcBces()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Sub RefrescarTablaNotaCXP()
        DgvFacturas.Rows.Clear()
        Con.Open()
        Dim CmdFacts As New MySqlCommand("SELECT NotaDebitoCreditoCXPDetalle.IDCompra,Compras.NoFactura,FechaFactura,Referencia,NCF,TotalNeto,NotaDebitoCreditoCXPDetalle.BceAnterior,Aplicado,NotaDebitoCreditoCXPDetalle.Itbis,IDNotaDebitoCreditoCXPDetalle,Compras.SecondID FROM notadebitocreditocxpdetalle INNER JOIN Compras on NotaDebitoCreditoCXPDetalle.IDCompra=Compras.IDCompra Where IDNotaDebitoCreditoCXP='" + txtIDNota.Text + "'", Con)
        Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader

        While LectorFacturas.Read
            DgvFacturas.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), CDate(LectorFacturas.GetValue(2)).ToString("dd/MM/yyyy"), LectorFacturas.GetValue(3), LectorFacturas.GetValue(4), CDbl(LectorFacturas.GetValue(5)).ToString("C"), CDbl(LectorFacturas.GetValue(6)).ToString("C"), False, CDbl(LectorFacturas.GetValue(7)).ToString("C"), CDbl(LectorFacturas.GetValue(8)).ToString("C"), LectorFacturas.GetValue(9), LectorFacturas.GetValue(10))
        End While
        LectorFacturas.Close()
        Con.Close()
    End Sub
End Class