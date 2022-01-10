Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_cargo_pagareses

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Incluir As New DataGridViewCheckBoxColumn
    Dim HeaderIncluir As New CheckBox
    Dim lblNulo, IDDefaultIDCobrador As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_cargo_pagareses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        CargarConfiguracion()
        ActualizarTodo()
        ColumnasDgvPagares()
        AddHeaderCheckBox()
    End Sub

    Private Sub CargarLibregco()
       PicLogo.Image = ConseguirLogoSistema()
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

    Private Sub ActualizarTodo()
        HabilitarControles()
        LimpiarTodo()
        DtpFechaVencimiento.Value = Today
        txtFecha.Text = Today
        lblStatusBar.Text = "Listo"
        HeaderIncluir.Checked = False
        lblNulo.Text = 0
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
        Dgvpagares.Rows.Clear()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ColumnasDgvPagares()
        Dgvpagares.Columns.Clear()
        With Dgvpagares
            .Columns.Add("IDPagare", "ID") '0
            .Columns.Add("NombreCliente", "Nombre") '1 
            .Columns.Add("IDFactura", "IDFactura") '2
            .Columns.Add("Vencimiento", "Vencimiento") '3
            .Columns.Add("Monto", "Monto") '4
            .Columns.Add("Balance", "Balance") '5
            .Columns.Add(Incluir) '6
            .Columns.Add("NoPagare", "No.") '7
            .Columns.Add("NoFactura", "Factura") '8
            .Columns.Add("IDTipo", "IDTipoPagare") '9
            .Columns.Add("TipoPagare", "Tipo") '10
        End With
        PropiedadDgvPagares()
    End Sub

    Private Sub PropiedadDgvPagares()
        With Dgvpagares
            .Columns(0).Width = 85
            .Columns(0).ReadOnly = True
            .Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            .Columns(0).DefaultCellStyle.Font = New Font("Courier New", 9, FontStyle.Regular)

            .Columns(1).Width = 280
            .Columns(1).ReadOnly = True

            .Columns(2).Visible = False

            .Columns(3).Width = 90
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).ReadOnly = True
            .Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy"

            .Columns(4).Width = 100
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(4).ReadOnly = True
            .Columns(4).DefaultCellStyle.Format = "C"

            .Columns(5).Width = 100
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(5).ReadOnly = True
            .Columns(5).DefaultCellStyle.Format = "C"

            .Columns(7).Width = 70
            .Columns(7).ReadOnly = True
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(7).DisplayIndex = 3

            .Columns(8).Width = 90
            .Columns(8).ReadOnly = True
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(8).DisplayIndex = 2

            .Columns(9).Visible = False

            .Columns(10).Width = 120
            .Columns(10).ReadOnly = True
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With

        With Incluir
            .HeaderText = ""
            .Name = "Incluir"
            .Width = 30
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
        Dgvpagares.Controls.Add(HeaderIncluir)

        AddHandler HeaderIncluir.CheckedChanged, AddressOf HeaderIncluir_CheckedChanged
    End Sub

    Private Sub HeaderIncluir_CheckedChanged(sender As Object, e As EventArgs)
        Try
            For Each row As DataGridViewRow In Dgvpagares.Rows
                row.Cells(6).Value = HeaderIncluir.CheckState
            Next
            'Dim HeaderBox As CheckBox = DirectCast(Dgvpagares.Controls.Find("HeaderIncluir", True)(0), CheckBox)
            'Dgvpagares.EditMode = DataGridViewEditMode.EditOnEnter

            'For Each Rows As DataGridViewRow In Dgvpagares.Rows
            '    Rows.Cells(6).Value = HeaderBox.Checked
            'Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ResetHeaderCheckBoxLocation(ByVal ColumnIndex As Integer, ByVal RowIndex As Integer)
        Dim Rect As Rectangle = Dgvpagares.GetCellDisplayRectangle(ColumnIndex, RowIndex, True)
        Dim Pt As New Point()
        Pt.X = Rect.Location.X + (Rect.Width - HeaderIncluir.Width) \ 2 + 1
        Pt.Y = Rect.Location.Y + (Rect.Height - HeaderIncluir.Height) \ 2 + 1
        HeaderIncluir.Location = Pt
    End Sub

    Private Sub Dgvpagares_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles Dgvpagares.CellPainting
        If e.RowIndex = -1 AndAlso e.ColumnIndex = 6 Then
            ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex)
        End If
    End Sub

    Private Sub btnBuscarPagares_Click(sender As Object, e As EventArgs) Handles btnBuscarPagares.Click
        Try
            If txtIDCobrador.Text = "" Then
                MessageBox.Show("Seleccione el cobrador para la búsqueda de las cuentas y pagares asignados." & vbNewLine & vbNewLine & "El sistema buscará los pagares vencidos de los clientes que tengan el cobrador que usted ha elegido.", "Elegir Cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnCobrador.PerformClick()
                Exit Sub
            End If

            Dgvpagares.Rows.Clear()
            Con.Open()
            Dim CmdFacts As New MySqlCommand("SELECT IDPagare,Nombre,IDFactura,Pagares.FechaVencimiento,Cantidad,Monto,Pagares.Balance,Concat(Pagares.NoPagare,'/',Pagares.Cantidad) as Numero,FacturaDatos.SecondID,Pagares.IDTipoPagare,TipoPagare.TipoPagare FROM pagares INNER JOIN FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN TipoPagare on Pagares.IDTipoPagare=TipoPagare.IDTipoPagare Where Pagares.FechaVencimiento<='" + DtpFechaVencimiento.Value.ToString("yyyy-MM-dd") + "' and Pagares.Balance>0 and Clientes.IDEmpleado='" + txtIDCobrador.Text + "' and Pagares.Cargado=0 and FacturaDatos.Balance>0 and FacturaDatos.Nulo=0", Con)
            Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader

            While LectorFacturas.Read
                Dgvpagares.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), LectorFacturas.GetValue(2), CDate(LectorFacturas.GetValue(3)).ToString("dd/MM/yyyy"), CDbl(LectorFacturas.GetValue(5)).ToString("C"), CDbl(LectorFacturas.GetValue(6)).ToString("C"), False, LectorFacturas.GetValue(7), LectorFacturas.GetValue(8), LectorFacturas.GetValue(9), LectorFacturas.GetValue(10))
            End While
            LectorFacturas.Close()
            Con.Close()

            GboxDatos.Enabled = False

            If Dgvpagares.Rows.Count = 0 Then
                lblStatusBar.Text = "No se encontraron pagares en la condición."
            ElseIf Dgvpagares.Rows.Count = 1 Then
                lblStatusBar.Text = "Solo se encontró un pagare en la condición."
            ElseIf Dgvpagares.Rows.Count > 1 Then
                lblStatusBar.Text = "Se encontraron: " & Dgvpagares.Rows.Count & " pagares en la condición."
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay()
    End Sub

    Private Sub Dgvpagares_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles Dgvpagares.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < Dgvpagares.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If Dgvpagares.RowHeadersWidth < CInt(size.Width + 20) Then
                Dgvpagares.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

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

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDListaPagare.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el registro de titulacion generalizada?", "Imprimir titulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If


    End Sub

    Private Sub UpdatePagares()
        Try
            Dim IDPagare, lblBcePagare, lblLastMovimiento, LastCobrador As New Label

            If lblNulo.Text = 0 Then
                For Each row As DataGridViewRow In Dgvpagares.Rows
                    If Convert.ToString(CBool(row.Cells(6).Value)) = True Then
                        IDPagare.Text = row.Cells(0).Value

                        sqlQ = "UPDATE Pagares SET IDEmpleado='" + txtIDCobrador.Text + "',IDListaPagare='" + txtIDListaPagare.Text + "',Cargado=1 WHERE IDPagare= '" + IDPagare.Text + "'"
                        GuardarDatos()

                        UpdateMovimientosPagares(IDPagare.Text, txtIDListaPagare.Text, lblNulo.Text)
                    End If
                Next

            Else

                For Each Row As DataGridViewRow In Dgvpagares.Rows
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

    Private Sub HabilitarControles()
        GboxDatos.Enabled = True
        Dgvpagares.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        GboxDatos.Enabled = False
        Dgvpagares.Enabled = False
    End Sub

    Sub RefrescarTablaPagares()
        Try
            If txtIDListaPagare.Text = "" Then
            Else
                Dgvpagares.Rows.Clear()
                Con.Open()

                Dim CmdFacts As New MySqlCommand("SELECT IDPagare,Nombre,IDFactura,Pagares.FechaVencimiento,Cantidad,Monto,Pagares.Balance,Concat(Pagares.NoPagare,'/',Pagares.Cantidad) as Numero,FacturaDatos.SecondID,Pagares.IDTipoPagare,TipoPagare.TipoPagare FROM pagares INNER JOIN FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN TipoPagare on Pagares.IDTipoPagare=TipoPagare.IDTipoPagare Where Pagares.IDListaPagare='" + txtIDListaPagare.Text + "'", Con)
                Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader

                While LectorFacturas.Read
                    Dgvpagares.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), LectorFacturas.GetValue(2), CDate(LectorFacturas.GetValue(3)).ToString("dd/MM/yyyy"), CDbl(LectorFacturas.GetValue(5)).ToString("C"), CDbl(LectorFacturas.GetValue(6)).ToString("C"), True, LectorFacturas.GetValue(7), LectorFacturas.GetValue(8), LectorFacturas.GetValue(9), LectorFacturas.GetValue(10))
                End While
                LectorFacturas.Close()
                Con.Close()

                PropiedadDgvPagares()

                If Dgvpagares.Rows.Count = 0 Then
                    lblStatusBar.Text = "Los pagarés que fueron registrados en este listado ya han sido re-asignados o eliminados del registro."
                End If

            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarTodo()
        ActualizarTodo()
    End Sub


    Private Sub Dgvpagares_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Dgvpagares.CellEndEdit
        Dgvpagares.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvSuperClaves_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgvpagares.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 6 Then
                Dgvpagares.EditMode = DataGridViewEditMode.EditOnEnter
            End If
        End If
    End Sub

    Private Sub DgvSuperClaves_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles Dgvpagares.CurrentCellDirtyStateChanged
        If Dgvpagares.IsCurrentCellDirty Then
            Dgvpagares.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=32", Con)
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

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=32"
            GuardarDatos()

        Catch ex As Exception

      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDCobrador.Text = "" Then
            MessageBox.Show("Seleccione el cobrador para la búsqueda de las cuentas y pagares asignados." & vbNewLine & vbNewLine & "El sistema buscará los pagares vencidos de los clientes que tengan el cobrador que usted ha elegido.", "Elegir Cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnCobrador.PerformClick()
            Exit Sub
        ElseIf Dgvpagares.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado registros de pagares que cumplan con la condición específicada.", "No hay pagares", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf DataGridViewExtensions.CheckBoxCount(Dgvpagares, 6, True) = 0 Then
            MessageBox.Show("No se han seleccionado ningún pagaré para su procesamiento.", "No hay pagares seleccionadas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDListaPagare.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea generar la lista de pagares del cobrador [" & txtIDCobrador.Text & "] " & txtCobrador.Text & " en la base de datos?", "Generar Lista de Cobros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO ListaPagares (IDUsuario,IDTipoDocumento,IDAreaImpresion,Fecha,Hora,IDTipoCargado,Descripcion,IDCobrador,FechaVencimiento,Nulo) VALUES ('" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',32,'" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "','" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',1,'" + txtDescripcion.Text + "','" + txtIDCobrador.Text + "','" + DtpFechaVencimiento.Value.ToString("yyyy-MM-dd") + "','" + lblNulo.Text + "')"
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
                sqlQ = "UPDATE ListaPagares SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',Descripcion='" + txtDescripcion.Text + "',IDCobrador='" + txtIDCobrador.Text + "',FechaVencimiento='" + DtpFechaVencimiento.Value.ToString("yyyy-MM-dd") + "',Nulo='" + lblNulo.Text + "' WHERE IDControlPagares= '" + txtIDListaPagare.Text + "'"
                GuardarDatos()
                UpdatePagares()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_lista_cobros.ShowDialog(Me)
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

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDListaPagare.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            frm_impresiones_directas.ShowDialog(Me)
        End If
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La lista de cobros del cobrador [" & txtIDCobrador.Text & "] " & txtCobrador.Text & " No. " & txtIDListaPagare.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Lista de Cobros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                ChkNulo.Checked = False
                sqlQ = "UPDATE ListaPagares SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',Descripcion='" + txtDescripcion.Text + "',IDCobrador='" + txtIDCobrador.Text + "',FechaVencimiento='" + CDate(DtpFechaVencimiento.Value).ToString("yyyy-MM-dd") + "',Nulo='" + lblNulo.Text + "' WHERE IDControlPagares= '" + txtIDListaPagare.Text + "'"
                GuardarDatos()
                UpdatePagares()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDListaPagare.Text = "" Then
            MessageBox.Show("No hay un registro de recibo de ingreso abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular la lista de cobros del cobrador [" & txtIDCobrador.Text & "] " & txtCobrador.Text & " No. " & txtIDListaPagare.Text & "  del sistema?", "Anular Lista de Cobros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ChkNulo.Checked = True
                sqlQ = "UPDATE ListaPagares SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',Descripcion='" + txtDescripcion.Text + "',IDCobrador='" + txtIDCobrador.Text + "',FechaVencimiento='" + CDate(DtpFechaVencimiento.Value).ToString("yyyy-MM-dd") + "',Nulo='" + lblNulo.Text + "' WHERE IDControlPagares= '" + txtIDListaPagare.Text + "'"
                GuardarDatos()
                UpdatePagares()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub btnCobrador_Click(sender As Object, e As EventArgs) Handles btnCobrador.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub txtIDCobrador_Leave(sender As Object, e As EventArgs) Handles txtIDCobrador.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Nombre from Empleados Where IDEmpleado='" + txtIDCobrador.Text + "'", Con)
        txtCobrador.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtCobrador.Text = "" Then txtIDCobrador.Clear()
    End Sub

 
End Class