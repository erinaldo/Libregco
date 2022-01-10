Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_entrega_cobro

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador, Adaptador1 As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblNulo, lblCierreEntrega, lblIDCobrador, AutoGenerarNumero As New Label
    Dim BtnRemover As New DataGridViewButtonColumn
    Dim Permisos As New ArrayList

    Private Sub frm_entrega_cobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        ColumnasDgvRecibos()
        LimpiarTodo()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
          PicLogo.Image = ConseguirLogoSistema()
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

    Private Sub ColumnasDgvRecibos()
        DgvRecibos.Rows.Clear()
        DgvRecibos.Columns.Clear()

        With DgvRecibos
            .Columns.Add("IDReciboCobro", "ID")    '0
            .Columns.Add("IDEntrega", "Cód. Entrega")   '1
            .Columns.Add("PreRecibo", "")   '2
            .Columns.Add("NoRecibo", "No. Recibo")  '3
            .Columns.Add("Monto", "Monto RD$")  '4
            .Columns.Add("Descripcion", "Comentario") '5
            .Columns.Add(BtnRemover)
        End With

        PropiedadColumnasDgvRecibos()
    End Sub

    Private Sub PropiedadColumnasDgvRecibos()
        With DgvRecibos
            .Columns(0).Width = 80
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(0).DefaultCellStyle.Font = New Font("Courier New", 9, FontStyle.Regular)
            .Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            .Columns(1).Visible = False
            .Columns(2).Width = 30
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).Width = 100
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(4).Width = 120
            .Columns(4).DefaultCellStyle.Format = ("C")
            .Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(5).Width = 240
            .Columns(5).DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Italic)
            .Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        With BtnRemover
            .Width = 60
            .UseColumnTextForButtonValue = True
            .HeaderText = ""
            .Text = "Eliminar"
            .DefaultCellStyle.Font = New Font("Arial", 8)
        End With
    End Sub

    Private Sub LimpiarTodo()
        CbxCobrador.Items.Clear()
        DtpFechaEntrega.Value = Today
        txtNoEntrega.Clear()
        txtSecondID.Clear()
        txtIDEntrega.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        txtCantRestante.Clear()
        txtFechaUltEntrega.Clear()
        txtCantidad.Clear()
        txtNoInicial.Clear()
        txtNoFinal.Clear()
        DgvRecibos.Rows.Clear()
        txtMontoEntrega.Clear()
        txtComision.Clear()
        txtNota.Clear()
        txtEfectivo.EditValue = 0
        txtCambios.EditValue = 0
        txtGranTotal.EditValue = 0
    End Sub

    Private Sub FillCobrador()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados where Nulo=0 and EsCobrador=1 ORDER By Nombre ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Empleados")
            CbxCobrador.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Empleados")

            For Each Fila As DataRow In Tabla.Rows
                CbxCobrador.Items.Add(Fila.Item("Nombre"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ActualizarTodo()
        CbxCobrador.Items.Clear()
        FillCobrador()
        txtFecha.Text = Today
        DtpFechaEntrega.Value = Today
        txtHora.Text = TimeOfDay
        txtMontoEntrega.Text = CDbl(0).ToString("C")
        txtComision.Text = CDbl(0).ToString("C")
        chkNulo.Checked = False
        chkCerrarEntrega.Checked = False
        lblCierreEntrega.Text = 0
        lblNulo.Text = 0
        HabilitarControles()
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblNulo.Text = 1
            DeshabilitarControles()
        Else
            lblNulo.Text = 0
            HabilitarControles()
        End If
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        If CbxCobrador.Text = "" Then
            MessageBox.Show("Especifique el cobrador para procesar sus respectivos recibos de cobro.", "Elegir cobrador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            CbxCobrador.Focus()
            CbxCobrador.DroppedDown = True
            Exit Sub
        ElseIf txtCantidad.Text = "" Then
            MessageBox.Show("Escriba la cantidad de recibos a procesar en la entrega.", "Cant. de Recibos a Procesar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtCantidad.Focus()
            Exit Sub
        ElseIf txtCantidad.Text = 0 Then
            MessageBox.Show("La cantidad de recibos a procesar debe ser mayor que 0.", "Cantidad no válida", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidad.Text = 1
            Exit Sub
        End If

        DgvRecibos.Rows.Clear()

        Con.Open()
        Ds.Clear()
        cmd = New MySqlCommand("SELECT IDReciboCobro,IDEntregaCobro,PreRecibo,NoRecibo,Monto,Comentario FROM reciboscobro INNER JOIN TalonarioRecibo on RecibosCobro.IDTalonario=TalonarioRecibo.IDTalonarioRecibo Where TalonarioRecibo.IDCobrador='" + lblIDCobrador.Text + "' and IDEntregaCobro IS NULL AND TalonarioRecibo.Nulo=0 UNION ALL SELECT IDReciboCobro,IDEntregaCobro,PreRecibo,NoRecibo,Monto,Comentario FROM reciboscobro INNER JOIN TalonarioRecibo on RecibosCobro.IDTalonario=TalonarioRecibo.IDTalonarioRecibo Where TalonarioRecibo.IDCobrador='" + lblIDCobrador.Text + "' and IDEntregaCobro='" + txtIDEntrega.Text + "' AND TalonarioRecibo.Nulo=0 ORDER BY NoRecibo ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Reciboscobro")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Reciboscobro")
        Dim x As Integer = 0

Inicio:

        If x = CInt(txtCantidad.Text) Then
            GoTo Fin
        End If

        If x >= CInt(Tabla.Rows.Count) Then
            MessageBox.Show("La cantidad de recibos a procesar en la entrega excede la cantidad de recibos disponibles (" & CInt(txtCantidad.Text) - CInt(Tabla.Rows.Count) & ") del cobrador." & vbNewLine & vbNewLine & "Verifique el control de talonarios y vuelva a intentarlo.", "Cant. de Recibos Excedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            DgvRecibos.Rows.Clear()
            Con.Close()
            Exit Sub
        End If

        DgvRecibos.Rows.Add((Tabla.Rows(x).Item("IDReciboCobro")), (Tabla.Rows(x).Item("IDEntregaCobro")), (Tabla.Rows(x).Item("PreRecibo")), (Tabla.Rows(x).Item("NoRecibo")), CDbl(Tabla.Rows(x).Item("Monto")).ToString("C"), (Tabla.Rows(x).Item("Comentario")))
        x = x + 1
        GoTo Inicio


Fin:
        Con.Close()
        txtNoFinal.Text = (Tabla.Rows(x - 1).Item("NoRecibo"))

    End Sub

    Private Sub BuscarReciboInicial()
        Try
            If txtIDEntrega.Text = "" Then
                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDReciboCobro,IDEntregaCobro,NoRecibo,Cierre FROM reciboscobro INNER JOIN TalonarioRecibo on RecibosCobro.IDTalonario=TalonarioRecibo.IDTalonarioRecibo Where TalonarioRecibo.IDCobrador='" + lblIDCobrador.Text + "' and IDEntregaCobro IS NULL AND Cierre=0 AND TalonarioRecibo.Nulo=0 ORDER BY NoRecibo ASC LIMIT 1", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Reciboscobro")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("Reciboscobro")

                If Tabla.Rows.Count = 0 Then
                    MessageBox.Show("El cobrador " & CbxCobrador.Text & " no tiene recibos disponibles para la realización de una entrega de cobros.", "No se encontraron recibos", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    CbxCobrador.Items.Clear()
                    FillCobrador()
                Else
                    txtNoInicial.Text = (Tabla.Rows(0).Item("NoRecibo"))
                End If
            End If
           
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CbxCobrador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxCobrador.SelectedIndexChanged
        SetIDCobrador()
        BuscarCantRest()
        BuscarUltEntrega()
        BuscarReciboInicial()
    End Sub

    Private Sub SetIDCobrador()
        Try
            Con.Open()
            cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + CbxCobrador.SelectedItem + "'", Con)
            lblIDCobrador.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub BuscarUltEntrega()
        Try
            Con.Open()
            cmd = New MySqlCommand("Select FechaEntrega FROM entregacobro Where IDCobrador='" + lblIDCobrador.Text + "' ORDER BY IDEntregaCobro DESC LIMIT 1", Con)
            txtFechaUltEntrega.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If IsDate(txtFechaUltEntrega.Text) Then
                txtFechaUltEntrega.Text = CDate(txtFechaUltEntrega.Text).ToString("dd/MM/yyyy")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub BuscarCantRest()
        Try
            Con.Open()
            cmd = New MySqlCommand("Select Coalesce(count(IDReciboCobro),0) as Cantidad from RecibosCobro INNER JOIN Talonariorecibo on RecibosCobro.IDTalonario=TalonarioRecibo.IDTalonarioRecibo Where TalonarioRecibo.IDCobrador='" + lblIDCobrador.Text + "' and RecibosCobro.Cierre=0 and TalonarioRecibo.Nulo=0 and RecibosCobro.IDEntregaCobro is null", Con)
            txtCantRestante.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvRecibos_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvRecibos.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvRecibos.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvRecibos.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvRecibos.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ConvertDouble()
        txtMontoEntrega.Text = CDbl(txtMontoEntrega.Text)
        txtComision.Text = CDbl(txtComision.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtMontoEntrega.Text = CDbl(txtMontoEntrega.Text).ToString("C")
        txtComision.Text = CDbl(txtComision.Text).ToString("C")
    End Sub

    Private Sub UltEntrega()
        Try
            If txtIDEntrega.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDEntregaCobro from entregacobro where IDEntregaCobro= (Select Max(IDEntregaCobro) from EntregaCobro)", Con)
                txtIDEntrega.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub HabilitarControles()
        GbDatosEntrega.Enabled = True
        GbNumeracion.Enabled = True
        GbDgv.Enabled = True
        GbComision.Enabled = True
        txtNoEntrega.Enabled = True
        chkCerrarEntrega.Enabled = True
        btnProcesar.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        GbDatosEntrega.Enabled = False
        GbNumeracion.Enabled = False
        GbDgv.Enabled = False
        GbComision.Enabled = False
        txtNota.Enabled = False
        chkCerrarEntrega.Enabled = False
        btnProcesar.Enabled = False
    End Sub

    Private Sub UpdateRecibos()
        Dim IDRecibo As New Label

        For Each row As DataGridViewRow In DgvRecibos.Rows
            IDRecibo.Text = row.Cells(0).Value
            If lblNulo.Text = 0 Then
                sqlQ = "UPDATE RecibosCobro SET IDEntregaCobro='" + txtIDEntrega.Text + "' WHERE IDReciboCobro= '" + IDRecibo.Text + "'"
                GuardarDatos()
            Else
                sqlQ = "UPDATE RecibosCobro SET IDEntregaCobro=NULL,Comentario='' WHERE IDReciboCobro= '" + IDRecibo.Text + "'"
                GuardarDatos()
            End If

        Next
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
            Con.Close()
        End Try
    End Sub

    Private Sub txtNoEntrega_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoEntrega.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Sub RefrescarTablaRecibos()

        Try
            If txtIDEntrega.Text = "" Then
            Else
                DgvRecibos.Rows.Clear()
                Con.Open()
                Dim Consulta As New MySqlCommand("Select IDReciboCobro,IDEntregaCobro,PreRecibo,NoRecibo,Monto,Comentario FROM RecibosCobro Where IDEntregaCobro='" + txtIDEntrega.Text + "'", Con)
                Dim LectorRecibos As MySqlDataReader = Consulta.ExecuteReader

                While LectorRecibos.Read
                    DgvRecibos.Rows.Add(LectorRecibos.GetValue(0), LectorRecibos.GetValue(1), LectorRecibos.GetValue(2), LectorRecibos.GetValue(3), LectorRecibos.GetValue(4), LectorRecibos.GetValue(5))
                End While
                PropiedadColumnasDgvRecibos()
                Con.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub ImprimirDocumento()
        If txtIDEntrega.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir la entrega de cobros?", "Imprimir Entrega de Cobros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub chkCerrarEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chkCerrarEntrega.CheckedChanged
        If chkCerrarEntrega.Checked = False Then
            lblCierreEntrega.Text = 0
        Else
            lblCierreEntrega.Text = 1
        End If
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarTodo()
        ActualizarTodo()
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=50", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE EntregaCobro SET SecondID='" + lblSecondID.Text + "',NoEntrega='" + lblSecondID.Text + "' WHERE IDEntregaCobro='" + txtIDEntrega.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=50"
            GuardarDatos()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_entrega_cobros.ShowDialog(Me)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La Entrega código No. " & txtIDEntrega.Text & ", del cobrador " & CbxCobrador.Text & "  ya está anulado en el sistema. Desea activarlo?", "Recuperar Entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                If chkCerrarEntrega.CheckState = CheckState.Checked Then
                    Con.Open()
                    'Buscar efectivbos
                    cmd = New MySqlCommand("SELECT COALESCE(Sum(Monto),0) FROM libregco.reciboscobro where IDEntregaCobro='" + txtIDEntrega.Text + "' and IDTipoRecibo=1", Con)
                    Dim SumEfectivos As Double = Convert.ToDouble(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("SELECT COALESCE(Sum(Monto),0) FROM libregco.reciboscobro where IDEntregaCobro='" + txtIDEntrega.Text + "' and IDTipoRecibo=2", Con)
                    Dim SumaCambios As Double = Convert.ToDouble(cmd.ExecuteScalar())
                    Con.Close()

                    If SumEfectivos <> CDbl(txtEfectivo.EditValue) Then
                        MessageBox.Show("La suma de los recibos de efectivo no coincide con el monto específicado en la entrega de cobros.", "Suma de efectivos no coincide", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    ElseIf SumaCambios <> CDbl(txtCambios.EditValue) Then
                        MessageBox.Show("La suma de los recibos de cambios no coincide con el monto específicado en la entrega de cobros.", "Suma de cambios no coincide", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                ConvertDouble()
                chkNulo.Checked = False
                sqlQ = "UPDATE EntregaCobro SET IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',NoEntrega='" + txtNoEntrega.Text + "',Descripcion='" + txtNota.Text + "',FechaEntrega='" + DtpFechaEntrega.Value.ToString("yyyy-MM-dd") + "',IDCobrador='" + lblIDCobrador.Text + "',Cantidad='" + txtCantidad.Text + "',NoInicial='" + txtNoInicial.Text + "',NoFinal='" + txtNoFinal.Text + "',Monto='" + txtMontoEntrega.Text + "',Comision='" + txtComision.Text + "',Cierre='" + lblCierreEntrega.Text + "',Nulo='" + lblNulo.Text + "',SumaEfectivos='" + txtEfectivo.EditValue.ToString + "',SumaCambios='" + txtCambios.EditValue.ToString + "' WHERE IDEntregaCobro= (" + txtIDEntrega.Text + ")"
                GuardarDatos()
                UpdateRecibos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDEntrega.Text = "" Then
            MessageBox.Show("No hay un registro de entrega abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Checked As Double
            Con.Open()
            cmd = New MySqlCommand("SELECT count(IDDetalleRecibo) FROM recibosdetalle INNER JOIN RecibosCobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro Where RecibosCobro.IDEntregaCobro='" + txtIDEntrega.Text + "'", Con)
            Checked = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()

            If Checked > 0 Then
                MessageBox.Show("La entrega de recibos no se puede anular ya que se han registrado detalle de recibos de cobros en el sistema.", "Existencia de detalles de recibos de cobro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el registro de entrega de cobro código No." & txtIDEntrega.Text & " del sistema?", "Anular Entrega de Cobros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                If chkCerrarEntrega.CheckState = CheckState.Checked Then
                    Con.Open()
                    'Buscar efectivbos
                    cmd = New MySqlCommand("SELECT COALESCE(Sum(Monto),0) FROM libregco.reciboscobro where IDEntregaCobro='" + txtIDEntrega.Text + "' and IDTipoRecibo=1", Con)
                    Dim SumEfectivos As Double = Convert.ToDouble(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("SELECT COALESCE(Sum(Monto),0) FROM libregco.reciboscobro where IDEntregaCobro='" + txtIDEntrega.Text + "' and IDTipoRecibo=2", Con)
                    Dim SumaCambios As Double = Convert.ToDouble(cmd.ExecuteScalar())
                    Con.Close()

                    If SumEfectivos <> CDbl(txtEfectivo.EditValue) Then
                        MessageBox.Show("La suma de los recibos de efectivo no coincide con el monto específicado en la entrega de cobros.", "Suma de efectivos no coincide", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    ElseIf SumaCambios <> CDbl(txtCambios.EditValue) Then
                        MessageBox.Show("La suma de los recibos de cambios no coincide con el monto específicado en la entrega de cobros.", "Suma de cambios no coincide", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                ConvertDouble()
                chkNulo.Checked = True
                sqlQ = "UPDATE EntregaCobro SET IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',NoEntrega='" + txtNoEntrega.Text + "',Descripcion='" + txtNota.Text + "',FechaEntrega='" + DtpFechaEntrega.Value.ToString("yyyy-MM-dd") + "',IDCobrador='" + lblIDCobrador.Text + "',Cantidad='" + txtCantidad.Text + "',NoInicial='" + txtNoInicial.Text + "',NoFinal='" + txtNoFinal.Text + "',Monto='" + txtMontoEntrega.Text + "',Comision='" + txtComision.Text + "',Cierre='" + lblCierreEntrega.Text + "',Nulo='" + lblNulo.Text + "',SumaEfectivos='" + txtEfectivo.EditValue.ToString + "',SumaCambios='" + txtCambios.EditValue.ToString + "' WHERE IDEntregaCobro= (" + txtIDEntrega.Text + ")"
                GuardarDatos()
                UpdateRecibos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
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

    Private Sub DgvRecibos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRecibos.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 6 Then
                Dim IDRecibo, IDEntrega As New Label
                IDRecibo.Text = DgvRecibos.CurrentRow.Cells(0).Value

                Con.Open()
                cmd = New MySqlCommand("SELECT IDEntregaCobro FROM reciboscobro where IDReciboCobro='" + IDRecibo.Text + "'", Con)
                IDEntrega.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If IDEntrega.Text = "" Then
                    DgvRecibos.Rows.Remove(DgvRecibos.CurrentRow)
                Else
                    Dim CheckedIfisUsed As Integer
                    Con.Open()
                    cmd = New MySqlCommand("SELECT count(IDDetalleRecibo) FROM recibosdetalle Where IDReciboCobro='" + IDRecibo.Text + "'", Con)
                    CheckedIfisUsed = Convert.ToDouble(cmd.ExecuteScalar())
                    Con.Close()

                    If CheckedIfisUsed > 0 Then
                        MessageBox.Show("El recibo de cobro No. " & DgvRecibos.CurrentRow.Cells(2).Value & " " & DgvRecibos.CurrentRow.Cells(3).Value & " ya ha sido utilizado en registros de cobros. No es posible eliminar el registro debido a que afectaría su relación integral." & vbNewLine & vbNewLine & "Para poder eliminarlo de la entrega es necesario eliminar el detalle de registro de cobros.", "El recibo de cobro está siendo utilizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el recibo código " & DgvRecibos.CurrentRow.Cells(0).Value & " correspondiente a la entrega No. " & txtNoEntrega.Text & "?", "Eliminar recibo procesado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        sqlQ = "UPDATE RecibosCobro SET IDSucursal=NULL,IDEntregaCobro=NULL,Fecha=Null,IDTipoRecibo=Null,IDCierre=Null,Comentario='' WHERE IDReciboCobro= '" + IDRecibo.Text + "'"
                        GuardarDatos()
                        DgvRecibos.Rows.Remove(DgvRecibos.CurrentRow)
                        txtCantidad.Text = DgvRecibos.Rows.Count
                        btnProcesar.PerformClick()
                        ConvertDouble()
                        sqlQ = "UPDATE EntregaCobro SET IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',NoEntrega='" + txtNoEntrega.Text + "',Descripcion='" + txtNota.Text + "',FechaEntrega='" + DtpFechaEntrega.Value.ToString("yyyy-MM-dd") + "',IDCobrador='" + lblIDCobrador.Text + "',Cantidad='" + txtCantidad.Text + "',NoInicial='" + txtNoInicial.Text + "',NoFinal='" + txtNoFinal.Text + "',Monto='" + txtMontoEntrega.Text + "',Comision='" + txtComision.Text + "',Cierre='" + lblCierreEntrega.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDEntregaCobro= (" + txtIDEntrega.Text + ")"
                        GuardarDatos()
                        ConvertCurrent()
                        MessageBox.Show("El recibo de cobro ha sido removido y restablecido correctamente.", "Operación Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If

            End If

        End If
    End Sub

    Private Sub txtEfectivo_EditValueChanged(sender As Object, e As EventArgs) Handles txtEfectivo.EditValueChanged
        txtGranTotal.EditValue = CDbl(txtEfectivo.EditValue) + CDbl(txtCambios.EditValue)
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        If DgvRecibos.Rows.Count = 0 Then
            MessageBox.Show("Aún no se ha procesado la cantidad de recibos de la entrega. Complete la entrega para procesarla.", "Complete la entrega de cobro", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf CInt(txtCantidad.Text) <> DgvRecibos.Rows.Count Then
            MessageBox.Show("La cantidad de recibos específicada no coincide con el número de recibos consultados. Por favor verifique el problema para continuar el proceso de la entrega de cobros.", "Cant. de recibos no coincide", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf CDbl(txtGranTotal.EditValue) = 0 Then
            MessageBox.Show("La entrega de cobros necesita tener sumatorias al menos de recibos de efectivos o de cambios. Por favor establezca el total de efectivo y total de cambios para continuar.", "Sumatorias incompletas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDEntrega.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar la entrega de cobros del cobrador " & CbxCobrador.Text & " en la base de datos?", "Guardar Entrega de Cobros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO EntregaCobro (IDAreaImpresion,IDTipoDocumento,IDUsuario,Fecha,Hora,NoEntrega,Descripcion,FechaEntrega,IDCobrador,Cantidad,NoInicial,NoFinal,Monto,Comision,Cierre,Pagada,Nulo,SumaEfectivos,SumaCambios) VALUES ('" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',50,'" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',CURDATE(),CURTIME(),'" + txtNoEntrega.Text + "','" + txtNota.Text + "','" + DtpFechaEntrega.Value.ToString("yyyy-MM-dd") + "','" + lblIDCobrador.Text + "','" + txtCantidad.Text + "','" + txtNoInicial.Text + "','" + txtNoFinal.Text + "','" + txtMontoEntrega.Text + "','" + txtComision.Text + "','" + lblCierreEntrega.Text + "',0,'" + lblNulo.Text + "','" + txtEfectivo.EditValue.ToString + "','" + txtCambios.EditValue.ToString + "')"
                GuardarDatos()
                ConvertCurrent()
                UltEntrega()
                SetSecondID()
                UpdateRecibos()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la entrega de cobros?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                If chkCerrarEntrega.CheckState = CheckState.Checked Then
                    Con.Open()
                    'Buscar efectivbos
                    cmd = New MySqlCommand("SELECT COALESCE(Sum(Monto),0) FROM libregco.reciboscobro where IDEntregaCobro='" + txtIDEntrega.Text + "' and IDTipoRecibo=1", Con)
                    Dim SumEfectivos As Double = Convert.ToDouble(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("SELECT COALESCE(Sum(Monto),0) FROM libregco.reciboscobro where IDEntregaCobro='" + txtIDEntrega.Text + "' and IDTipoRecibo=2", Con)
                    Dim SumaCambios As Double = Convert.ToDouble(cmd.ExecuteScalar())
                    Con.Close()

                    If SumEfectivos <> CDbl(txtEfectivo.EditValue) Then
                        MessageBox.Show("La suma de los recibos de efectivo no coincide con el monto específicado en la entrega de cobros.", "Suma de efectivos no coincide", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    ElseIf SumaCambios <> CDbl(txtCambios.EditValue) Then
                        MessageBox.Show("La suma de los recibos de cambios no coincide con el monto específicado en la entrega de cobros.", "Suma de cambios no coincide", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If

                ConvertDouble()
                    sqlQ = "UPDATE EntregaCobro SET IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Descripcion='" + txtNota.Text + "',FechaEntrega='" + DtpFechaEntrega.Value.ToString("yyyy-MM-dd") + "',IDCobrador='" + lblIDCobrador.Text + "',Cantidad='" + txtCantidad.Text + "',NoInicial='" + txtNoInicial.Text + "',NoFinal='" + txtNoFinal.Text + "',Monto='" + txtMontoEntrega.Text + "',Comision='" + txtComision.Text + "',Cierre='" + lblCierreEntrega.Text + "',Nulo='" + lblNulo.Text + "',SumaEfectivos='" + txtEfectivo.EditValue.ToString + "',SumaCambios='" + txtCambios.EditValue.ToString + "' WHERE IDEntregaCobro= (" + txtIDEntrega.Text + ")"
                    GuardarDatos()
                    ConvertCurrent()
                    UpdateRecibos()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    DeshabilitarControles()
                End If
            End If
    End Sub

    Private Sub txtCambios_EditValueChanged(sender As Object, e As EventArgs) Handles txtCambios.EditValueChanged
        txtGranTotal.EditValue = CDbl(txtEfectivo.EditValue) + CDbl(txtCambios.EditValue)
    End Sub

    Private Sub txtCantidad_Leave(sender As Object, e As EventArgs) Handles txtCantidad.Leave
        If IsNumeric(txtCantidad.Text) Then
            If CDbl(txtCantidad.Text) < DgvRecibos.Rows.Count Then
                txtCantidad.Undo()
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDEntrega.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            If CDbl(txtMontoEntrega.Text) > 0 Then
                frm_impresiones_directas.ShowDialog(Me)
            End If

        End If
       
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

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub
End Class