Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_descontar_prestamos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim ChkIncluirFact As New DataGridViewCheckBoxColumn
    Friend lblIDUsuario, lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_descontar_prestamos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
        ColumnasDgvPrestamos()
        SelectUsuario()
    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
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

    Private Sub ColumnasDgvPrestamos()
        DgvPrestamos.Columns.Clear()

        With DgvPrestamos
            .Columns.Add("IDAbonoDetalle", "IDAbonoDetalle") '0
            .Columns.Add("IDPrestamo", "Código")  '1
            .Columns.Add("SecondID", "No.") '2 'SecondID de préstamo
            .Columns.Add("Fecha", "Fecha")    '3
            .Columns.Add("Concepto", "Concepto")    '4
            .Columns.Add("Monto", "Monto")   '5
            .Columns.Add("Balance", "Balance")        '6
            .Columns.Add(ChkIncluirFact)    '7
            .Columns.Add("Aplicar", "Aplicar")  '8

        End With

        PropiedadesDgvPrestamos()
    End Sub

    Private Sub InsertDetallePago()
        Dim IDAbonoDetalle, IDPrestamoEmp, BceAnterior, Aplicado As New Label

        For Each Row As DataGridViewRow In DgvPrestamos.Rows
            IDAbonoDetalle.Text = Row.Cells(0).Value
            IDPrestamoEmp.Text = Row.Cells(1).Value
            BceAnterior.Text = CDbl(Row.Cells(6).Value)
            Aplicado.Text = CDbl(Row.Cells(8).Value)

            If IDAbonoDetalle.Text = "" Then
                If CDbl(Aplicado.Text) > 0 Then
                    sqlQ = "INSERT INTO abprestempdetalle (IDAbPrestEmp,IDPrestamoEmp,BalanceAnterior,Aplicado) VALUES ('" + txtIDAbonoPrestamo.Text + "','" + IDPrestamoEmp.Text + "','" + BceAnterior.Text + "','" + Aplicado.Text + "')"
                    GuardarDatos()
                End If
            Else
                If CDbl(Aplicado.Text) = 0 Then     'Si el total del existente es 0 entonces lo elimino.
                    sqlQ = "Delete from abprestempdetalle Where IDAbPrestEmpDetalle= '" + IDAbonoDetalle.Text + "'"
                    GuardarDatos()
                Else
                    sqlQ = "UPDATE abprestempdetalle SET IDAbPrestEmp='" + txtIDAbonoPrestamo.Text + "',IDPrestamoEmp='" + IDPrestamoEmp.Text + "',BalanceAnterior='" + BceAnterior.Text + "',Aplicado='" + Aplicado.Text + "' WHERE IDAbPrestEmpDetalle= (" + IDAbonoDetalle.Text + ")"
                    GuardarDatos()
                End If
            End If
        Next

    End Sub

    Private Sub PropiedadesDgvPrestamos()
        With DgvPrestamos

            .Columns(0).Visible = False

            .Columns(1).Width = 100
            .Columns(1).ReadOnly = True
            .Columns(1).Visible = False

            .Columns(2).Width = 100
            .Columns(2).ReadOnly = True

            .Columns(3).Width = 100
            .Columns(3).ReadOnly = True

            .Columns(4).Width = 270
            .Columns(4).ReadOnly = True

            .Columns(5).Width = 130
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(5).ReadOnly = True

            .Columns(6).DefaultCellStyle.Format = ("C")
            .Columns(6).Width = 130
            .Columns(6).ReadOnly = True

            .Columns(8).Width = 130
            .Columns(8).DefaultCellStyle.Format = ("C")
            .Columns(8).DefaultCellStyle.BackColor = Color.Beige

        End With

        With ChkIncluirFact
            .HeaderText = "Incl."
            .Name = "ChkIncluirFact"
            .Width = 30
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .DefaultCellStyle.BackColor = Color.LightGray
            .FlatStyle = FlatStyle.Standard

        End With
    End Sub

    Private Sub ActualizarTodo()
        ControlSuperClave = 1
        lblNulo.Text = 0
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        txtMontoAplicar.Text = CDbl(0).ToString("C")
    End Sub

    Private Sub LimpiarDatos()
        HabilitarControles()
        txtIDEmpleado.Clear()
        txtEmpleado.Clear()
        txtIDAbonoPrestamo.Clear()
        txtSecondID.Clear()
        txtBalanceEmp.Clear()
        txtUltimoMonto.Clear()
        txtUltimoPago.Clear()
        DgvPrestamos.Rows.Clear()
        txtConcepto.Clear()
        txtComentario.Clear()
        btnBuscarEmpleado.Focus()
    End Sub

    Private Sub HabilitarControles()
        btnBuscarEmpleado.Enabled = True
        DgvPrestamos.Enabled = True
        txtConcepto.Enabled = True
        txtComentario.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        btnBuscarEmpleado.Enabled = False
        DgvPrestamos.Enabled = False
        txtConcepto.Enabled = False
        txtComentario.Enabled = False
    End Sub

    Private Sub DgvPrestamos_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvPrestamos.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvPrestamos.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvPrestamos.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvPrestamos.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnBuscarEmpleado_Click(sender As Object, e As EventArgs) Handles btnBuscarEmpleado.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Sub FillPagosDetalle()
        Try

            DgvPrestamos.Rows.Clear()
            Con.Open()
            Dim AnexarPrestamos As New MySqlCommand("SELECT IDAbPrestEmpDetalle,IDPrestamoEmp,PrestamosEmp.SecondID,PrestamosEmp.Fecha,PrestamosEmp.Concepto,Monto,BalanceAnterior,Aplicado FROM abprestempdetalle INNER JOIN PrestamosEmp on AbPrestEmpDetalle.IDPrestamoEmp=PrestamosEmp.IDPrestamosEmp where IDAbPrestEmp='" + txtIDAbonoPrestamo.Text + "'", Con)

            Dim LectorPrestamos As MySqlDataReader = AnexarPrestamos.ExecuteReader

            While LectorPrestamos.Read
                DgvPrestamos.Rows.Add(LectorPrestamos.GetValue(0), LectorPrestamos.GetValue(1), LectorPrestamos.GetValue(2), CDate(LectorPrestamos.GetValue(3)).ToString("dd/MM/yyyy"), LectorPrestamos.GetValue(4), CDbl(LectorPrestamos.GetValue(5)).ToString("C"), CDbl(LectorPrestamos.GetValue(6)).ToString("C"), True, CDbl(LectorPrestamos.GetValue(7)).ToString("C"))
            End While
            LectorPrestamos.Close()
            Con.Close()

            PropiedadesDgvPrestamos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub RefrescarPrestamosActivos()
        Try

            DgvPrestamos.Rows.Clear()
            Con.Open()
            Dim AnexarPrestamos As New MySqlCommand("SELECT IDPrestamosEmp,SecondID,Fecha,Concepto,Monto,Balance from PrestamosEmp where IDEmpleado='" + txtIDEmpleado.Text + "' and Balance>0  and Nulo=0", Con)

            Dim LectorPrestamos As MySqlDataReader = AnexarPrestamos.ExecuteReader

            While LectorPrestamos.Read
                DgvPrestamos.Rows.Add("", LectorPrestamos.GetValue(0), LectorPrestamos.GetValue(1), CDate(LectorPrestamos.GetValue(2)).ToString("dd/MM/yyyy"), LectorPrestamos.GetValue(3), LectorPrestamos.GetValue(4), LectorPrestamos.GetValue(5), 0, CDbl(0).ToString("C"))
            End While
            LectorPrestamos.Close()
            Con.Close()

            PropiedadesDgvPrestamos()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub DgvPrestamos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPrestamos.CellContentClick
        Try
            If e.RowIndex < 0 Then
                Exit Sub
            End If

            If e.ColumnIndex = 6 Then
                DgvPrestamos.EndEdit()

                If Convert.ToBoolean(DgvPrestamos.CurrentCell.Value) = True Then
                    DgvPrestamos.Rows(e.RowIndex).Cells(8).Value = DgvPrestamos.Rows(e.RowIndex).Cells(5).Value
                Else
                    DgvPrestamos.Rows(e.RowIndex).Cells(8).Value = CDbl(0).ToString("C")
                    LimpiarDescRet()
                    ActualizarDeseleccion()
                End If
            End If

            ConjuntoSuma()
            ConceptoTransaccion()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LimpiarDescRet()
        DgvPrestamos.CurrentRow.Cells(8).Value = CDbl(0).ToString("C")
    End Sub

    Private Sub ActualizarDeseleccion()
        txtConcepto.Clear()
    End Sub

    Private Sub ConjuntoSuma()
        SumarMontoAplicar()
    End Sub

    Private Sub SumarMontoAplicar()
        Try
            Dim Counter = DgvPrestamos.Rows.Count
            Dim x As Integer = 0
            Dim MontoAplicar As Double = 0
            txtMontoAplicar.Clear()

Inicio:
            If x = Counter Then
                GoTo Fin
            End If

            MontoAplicar = MontoAplicar + CDbl(DgvPrestamos.Rows(x).Cells(8).Value)
            x = x + 1
            GoTo Inicio
Fin:

            txtMontoAplicar.Text = MontoAplicar.ToString("C")

        Catch ex As Exception
            '  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvPrestamos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPrestamos.CellValueChanged
        Try
            If e.ColumnIndex = 8 Then
                If CDbl(DgvPrestamos.CurrentRow.Cells(8).Value) > CDbl(DgvPrestamos.CurrentRow.Cells(6).Value) Then
                    DgvPrestamos.CurrentRow.Cells(8).Value = CDbl(DgvPrestamos.CurrentRow.Cells(6).Value).ToString("C")
                Else
                    DgvPrestamos.CurrentRow.Cells(8).Value = CDbl(DgvPrestamos.CurrentRow.Cells(8).Value).ToString("C")
                End If
                AplicadoenCero()
            End If
        Catch ex As Exception
        End Try

        Try
            If e.ColumnIndex = 7 Then
                Dim IsTicked As Boolean = CBool(DgvPrestamos.CurrentRow.Cells(7).Value)
                If IsTicked Then
                    DgvPrestamos.CurrentRow.Cells(8).Value = CDbl(DgvPrestamos.CurrentRow.Cells(6).Value).ToString("C")
                Else
                    DgvPrestamos.CurrentRow.Cells(8).Value = CDbl(0).ToString("C")
                End If
            End If

        Catch ex As Exception
        End Try

        ConjuntoSuma()
        ConceptoTransaccion()

    End Sub

    Private Sub ConceptoTransaccion()
        Dim Abonos, Saldos As Boolean
        Dim TextoAbono As String
        Abonos = False
        Saldos = False

        For Each Row As DataGridViewRow In DgvPrestamos.Rows
            If CDbl(Row.Cells(8).Value) > 0 Then
                If CDbl(Row.Cells(8).Value) < CDbl(Row.Cells(6).Value) Then
                    Abonos = True
                    TextoAbono = "Abono a: "
                    Exit For
                End If
            End If
        Next

        If Abonos = True Then
            For Each RowAb As DataGridViewRow In DgvPrestamos.Rows
                If CDbl(RowAb.Cells(8).Value) > 0 Then
                    If CDbl(RowAb.Cells(8).Value) < CDbl(RowAb.Cells(6).Value) Then
                        TextoAbono = TextoAbono & RowAb.Cells(2).Value & " "
                    End If
                End If
            Next
        End If

        For Each Rowsa As DataGridViewRow In DgvPrestamos.Rows
            'Determinar si hay abonos
            If CDbl(Rowsa.Cells(8).Value) > 0 Then
                If CDbl(Rowsa.Cells(8).Value) >= CDbl(Rowsa.Cells(6).Value) Then
                    Saldos = True
                    TextoAbono = TextoAbono & "Saldo a: "
                    Exit For
                End If
            End If
        Next

        If Saldos = True Then
            For Each RowSa As DataGridViewRow In DgvPrestamos.Rows
                If CDbl(RowSa.Cells(8).Value) > 0 Then
                    If CDbl(RowSa.Cells(8).Value) >= CDbl(RowSa.Cells(6).Value) Then
                        TextoAbono = TextoAbono & RowSa.Cells(2).Value & " "
                    End If
                End If
            Next
        End If

        txtConcepto.Text = TextoAbono
        '        Dim Counter As Integer = DgvPrestamos.Rows.Count
        '        Dim x As Integer = 0
        '        Dim Balance, Aplicado As Double
        '        txtConcepto.Clear()

        'Inicio:
        '        If x = Counter Then
        '            GoTo Fin
        '        End If

        '        Balance = CDbl(DgvPrestamos.Rows(x).Cells(6).Value)
        '        Aplicado = CDbl(DgvPrestamos.Rows(x).Cells(8).Value)

        '        If Aplicado = 0 Then
        '            x = x + 1
        '            GoTo Inicio
        '        End If

        '        If Aplicado >= Balance Then
        '            txtConcepto.Text = txtConcepto.Text & "Saldo a Préstamo No: " & DgvPrestamos.Rows(x).Cells(2).Value & ". "
        '        Else
        '            txtConcepto.Text = txtConcepto.Text & "Abono a Préstamo No: " & DgvPrestamos.Rows(x).Cells(2).Value & ". "
        '        End If

        '        x = x + 1
        '        GoTo Inicio
        'Fin:

    End Sub

    Private Sub AplicadoenCero()
        If CDbl(DgvPrestamos.CurrentRow.Cells(8).Value) = 0 Then
            DgvPrestamos.CurrentRow.Cells(7).Value = 0
        Else
            DgvPrestamos.CurrentRow.Cells(7).Value = 1
        End If
    End Sub

    Private Sub ConvertDouble()
        txtBalanceEmp.Text = CDbl(txtBalanceEmp.Text)
        txtMontoAplicar.Text = CDbl(txtMontoAplicar.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtBalanceEmp.Text = CDbl(txtBalanceEmp.Text).ToString("C")
        txtMontoAplicar.Text = CDbl(txtMontoAplicar.Text).ToString("C")
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message & " Desde Guardar Datos")
        End Try
    End Sub

    Private Sub UltAbonoPrestamo()
        Try
            If txtIDAbonoPrestamo.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDAbonoPrestamosEmp from abprestemp where IDAbonoPrestamosEmp= (Select Max(IDAbonoPrestamosEmp) from abprestemp)", Con)
                txtIDAbonoPrestamo.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvPrestamos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        If DgvPrestamos.IsCurrentCellDirty Then
            DgvPrestamos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = DgvPrestamos.CurrentCell.ColumnIndex

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

    Private Sub DgvPrestamos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        Dim Validar As TextBox = CType(e.Control, TextBox)

        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub DgvPrestamos_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        DgvPrestamos.EditMode = DataGridViewEditMode.EditOnEnter
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDAbonoPrestamo.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el recibo de pago de la factura?", "Imprimir Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CalcMontoCuota()
        Try
            Con.Open()
            cmd = New MySqlCommand("SELECT Coalesce(sum(if(prestamosemp.Cuota<=PrestamosEmp.Balance,prestamosemp.Cuota,PrestamosEmp.Balance)),0) as Cuota FROM prestamosemp where Balance>0 and IDEmpleado='" + txtIDEmpleado.Text + "'", Con)
            Dim Cuota As New Label
            Cuota.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            sqlQ = "UPDATE Empleados SET CuotaPrestamo='" + Cuota.Text + "' WHERE IDEmpleado= '" + txtIDEmpleado.Text + "'"
            GuardarDatos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDAbonoPrestamo.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo de pago del empleado: " & txtEmpleado.Text & " [ " & txtIDEmpleado.Text & " ] en la base de datos?", "Guardar Nuevo Recibo de Pago a Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO AbPrestemp (IDTipoDocumento,IDUsuario,Fecha,Hora,IDSucursal,IDAlmacen,IDEquipo,IDEmpleado,Total,BalanceAnterior,Concepto,Referencia,Impreso,Nulo) VALUES (42,'" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "', '" + txtIDEmpleado.Text + "','" + txtMontoAplicar.Text + "','" + txtBalanceEmp.Text + "','" + txtConcepto.Text + "','" + txtComentario.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltAbonoPrestamo()
                SetSecondID()
                InsertDetallePago()
                FunctCalcBcesEmpleados(txtIDEmpleado.Text)
                CalcMontoCuota()
                FillPagosDetalle()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el recibo de pago?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                ConvertDouble()
                sqlQ = "UPDATE AbPrestemp SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',IDEmpleado='" + txtIDEmpleado.Text + "',Total='" + txtMontoAplicar.Text + "',BalanceAnterior='" + txtBalanceEmp.Text + "',Concepto='" + txtConcepto.Text + "',Referencia='" + txtComentario.Text + "', Nulo='" + lblNulo.Text + "' WHERE IDAbonoPrestamosEmp= (" + txtIDAbonoPrestamo.Text + ")"
                GuardarDatos()
                InsertDetallePago()
                FunctCalcBcesEmpleados(txtIDEmpleado.Text)
                ConvertCurrent()
                CalcMontoCuota()
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
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=42", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE AbPrestEmp SET SecondID='" + lblSecondID.Text + "' WHERE IDAbonoPrestamosEmp='" + txtIDAbonoPrestamo.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=42"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
         If txtIDAbonoPrestamo.Text = "" Then 'Si no hay pago
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo de pago del empleado: " & txtEmpleado.Text & " [ " & txtIDEmpleado.Text & " ] en la base de datos?", "Guardar Nuevo Recibo de Pago a Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                ConvertDouble()
                sqlQ = "INSERT INTO AbPrestemp (IDTipoDocumento,IDUsuario,Fecha,Hora,IDSucursal,IDAlmacen,IDEquipo,IDEmpleado,Total,BalanceAnterior,Concepto,Referencia,Impreso,Nulo) VALUES (42,'" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "', '" + txtIDEmpleado.Text + "','" + txtMontoAplicar.Text + "','" + txtBalanceEmp.Text + "','" + txtConcepto.Text + "','" + txtComentario.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                UltAbonoPrestamo()
                SetSecondID()
                InsertDetallePago()
                FunctCalcBcesEmpleados(txtIDEmpleado.Text)
                CalcMontoCuota()
                ConvertCurrent()
                FillPagosDetalle()
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
                sqlQ = "UPDATE AbPrestemp SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + lblIDUsuario.Text + "',IDEmpleado='" + txtIDEmpleado.Text + "',Total='" + txtMontoAplicar.Text + "',BalanceAnterior='" + txtBalanceEmp.Text + "',Concepto='" + txtConcepto.Text + "',Referencia='" + txtComentario.Text + "', Nulo='" + lblNulo.Text + "' WHERE IDAbonoPrestamosEmp= (" + txtIDAbonoPrestamo.Text + ")"
                GuardarDatos()
                InsertDetallePago()
                FunctCalcBcesEmpleados(txtIDEmpleado.Text)
                CalcMontoCuota()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro del abono al préstamo código No. " & txtIDAbonoPrestamo.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Abono a Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 36
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE AbPrestemp SET IDUsuario='" + lblIDUsuario.Text + "',IDEmpleado='" + txtIDEmpleado.Text + "',Total='" + txtMontoAplicar.Text + "',BalanceAnterior='" + txtBalanceEmp.Text + "',Concepto='" + txtConcepto.Text + "',Referencia='" + txtComentario.Text + "', Nulo='" + lblNulo.Text + "' WHERE IDAbonoPrestamosEmp= (" + txtIDAbonoPrestamo.Text + ")"
                GuardarDatos()
                ConvertCurrent()

                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDAbonoPrestamo.Text = "" Then
            MessageBox.Show("No hay un registro de abono a préstamo abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el abono a préstamo código no. " & txtIDAbonoPrestamo.Text & " del sistema?", "Anular Abono a Préstamo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 35
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE AbPrestemp SET IDUsuario='" + lblIDUsuario.Text + "',IDEmpleado='" + txtIDEmpleado.Text + "',Total='" + txtMontoAplicar.Text + "',BalanceAnterior='" + txtBalanceEmp.Text + "',Concepto='" + txtConcepto.Text + "',Referencia='" + txtComentario.Text + "', Nulo='" + lblNulo.Text + "' WHERE IDAbonoPrestamosEmp= (" + txtIDAbonoPrestamo.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                FunctCalcBcesEmpleados(txtIDEmpleado.Text)
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub GuardarYLimpiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarYLimpiarToolStripMenuItem.Click
        btnGuardaryLimpiar.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

 
    Private Sub DgvPrestamos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPrestamos.CellEndEdit
        DgvPrestamos.CommitEdit(DataGridViewDataErrorContexts.Commit)

    End Sub

    Private Sub DgvPrestamos_CurrentCellDirtyStateChanged_1(sender As Object, e As EventArgs) Handles DgvPrestamos.CurrentCellDirtyStateChanged
        If DgvPrestamos.IsCurrentCellDirty Then
            DgvPrestamos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvPrestamos_EditingControlShowing_1(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvPrestamos.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)
        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_abono_prestamo.ShowDialog(Me)
    End Sub
End Class