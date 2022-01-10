Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_talonarios_cobro

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador, Adaptador1 As MySqlDataAdapter
    Friend lblNulo, lblIDUsuario, lblIDCobrador, lblIDNaturaleza, lblPreRecibo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_talonarios_cobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            GroupBox2.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub ColumnasDgvRecibos()
        DgvRecibos.Columns.Clear()
        With DgvRecibos
            .Columns.Add("IDTalonario", "IDTalonario")
            .Columns.Add("IDReciboCobro", "ID")
            .Columns.Add("NoRecibo", "No. Recibo")
            .Columns.Add("Monto", "Monto RD$")
            .Columns.Add("Descripcion", "Descripción")
        End With

        PropiedadColumnasDgvRecibos()
    End Sub

    Private Sub PropiedadColumnasDgvRecibos()
        With DgvRecibos
            .Columns(0).Visible = False
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(1).Width = 110
            .Columns(1).DefaultCellStyle.BackColor = Color.LightGray
            .Columns(1).DefaultCellStyle.Font = New Font("Courier New", 9, FontStyle.Regular)
            .Columns(2).Width = 110
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).Width = 120
            .Columns(3).DefaultCellStyle.Format = ("C")
            .Columns(4).DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Italic)
            .Columns(4).Width = 400
        End With
    End Sub

    Private Sub LimpiarTodo()
        CbxCobrador.Items.Clear()
        txtNoTalonario.Clear()
        txtCantidad.Clear()
        txtInicial.Clear()
        txtFinal.Clear()
        txtCantRestante.Clear()
        txtFechaUltEntrega.Clear()
        txtIDTalonario.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        cbxNaturaleza.Items.Clear()
        lblIDNaturaleza.Text = ""
        lblPreRecibo.Text = ""
        txtSecondID.Clear()
    End Sub

    Private Sub FillNaturaleza()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Naturalezarecibo Where Nulo=0", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Naturalezarecibo")
            cbxNaturaleza.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Naturalezarecibo")
            For Each Fila As DataRow In Tabla.Rows
                cbxNaturaleza.Items.Add(Fila.Item("Descripcion"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillCobrador()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados where Nulo=0 ORDER BY Nombre ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Empleados")
            CbxCobrador.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Empleados")
            For Each Fila As DataRow In Tabla.Rows
                CbxCobrador.Items.Add(Fila.Item("Nombre"))
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "FillCobrador")
        End Try
    End Sub


    Private Sub ActualizarTodo()
        HabilitarControles()
        txtFecha.Text = Today
        txtHora.Text = TimeOfDay
        lblNulo.Text = 0
        CbxCobrador.Items.Clear()
        DgvRecibos.Rows.Clear()
        FillCobrador()
        FillNaturaleza()
        CbxCobrador.Focus()
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
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

    Private Sub SetIDCobrador()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + CbxCobrador.SelectedItem + "'", Con)
        lblIDCobrador.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub UltTalonario()
        Try
            If txtIDTalonario.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDTalonarioRecibo from TalonarioRecibo where IDTalonarioRecibo= (Select Max(IDTalonarioRecibo) from TalonarioRecibo)", Con)
                txtIDTalonario.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertarRecibos()
        Try
            Dim IDTalonario, IDRecibo, NoRecibo, Monto, Descripcion As New Label
            Dim x As Integer = 0

Inicio:
            If x = DgvRecibos.RowCount Then
                GoTo Fin
            End If

            IDTalonario.Text = DgvRecibos.Rows(x).Cells(0).Value
            IDRecibo.Text = DgvRecibos.Rows(x).Cells(1).Value
            NoRecibo.Text = DgvRecibos.Rows(x).Cells(2).Value
            Monto.Text = CDbl(DgvRecibos.Rows(x).Cells(3).Value)
            Descripcion.Text = DgvRecibos.Rows(x).Cells(4).Value

            If IDTalonario.Text = "" Then
                sqlQ = "UPDATE RecibosCobro SET IDTalonario='" + txtIDTalonario.Text + "',Monto='" + Monto.Text + "',Comentario='" + Descripcion.Text + "' WHERE IDReciboCobro= '" + IDRecibo.Text + "'"
                GuardarDatos()
                x = x + 1
                GoTo Inicio
            Else
                x = x + 1
                GoTo Inicio
            End If
Fin:

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CbxCobrador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxCobrador.SelectedIndexChanged
        SetIDCobrador()
        BuscarNaturaleza()
        BuscarCantRest()
        BuscarUltEntrega()
    End Sub

    Private Sub BuscarNaturaleza()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Naturalezarecibo Where Nulo=0", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Naturalezarecibo")
            cbxNaturaleza.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Naturalezarecibo")

            For Each Fila As DataRow In Tabla.Rows
                cbxNaturaleza.Items.Add(Fila.Item("Descripcion"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub SetIDNaturaleza()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDNaturaleza FROM Naturalezarecibo WHERE Descripcion= '" + cbxNaturaleza.SelectedItem + "'", ConLibregco)
        lblIDNaturaleza.Text = Convert.ToString(cmd.ExecuteScalar())
        cmd = New MySqlCommand("SELECT Abreviacion FROM Naturalezarecibo WHERE Descripcion= '" + cbxNaturaleza.SelectedItem + "'", ConLibregco)
        lblPreRecibo.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Sub BuscarCantRest()
        Try
            Con.Open()
            cmd = New MySqlCommand("Select Coalesce(count(IDReciboCobro),0) as Cantidad from RecibosCobro INNER JOIN Talonariorecibo on RecibosCobro.IDTalonario=TalonarioRecibo.IDTalonarioRecibo Where TalonarioRecibo.IDCobrador='" + lblIDCobrador.Text + "' and TalonarioRecibo.Nulo=0 and RecibosCobro.IDEntregaCobro is null", Con)
            txtCantRestante.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub RefrescarTablaRecibos()

        Try
            If txtIDTalonario.Text <> "" Then
                DgvRecibos.Rows.Clear()
                Con.Open()
                Dim Consulta As New MySqlCommand("Select IDTalonario,IDReciboCobro,NoRecibo,Monto,Comentario FROM RecibosCobro Where IDTalonario='" + txtIDTalonario.Text + "'", Con)
                Dim LectorRecibos As MySqlDataReader = Consulta.ExecuteReader

                While LectorRecibos.Read
                    DgvRecibos.Rows.Add(LectorRecibos.GetValue(0), LectorRecibos.GetValue(1), LectorRecibos.GetValue(2), LectorRecibos.GetValue(3), LectorRecibos.GetValue(4))
                End While
                LectorRecibos.Close()
                Con.Close()
            End If

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

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub HabilitarControles()
        GbDatosTal.Enabled = True
        CbxCobrador.Enabled = True
        DgvRecibos.Enabled = True
        cbxNaturaleza.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        GbDatosTal.Enabled = False
        CbxCobrador.Enabled = False
        DgvRecibos.Enabled = False
        cbxNaturaleza.Enabled = False
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

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        If txtCantidad.Text = "" Then
            MessageBox.Show("Especifique la cantidad de recibos que tiene el talonario para continuar.", "Complete la Cant. de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidad.Focus()
            Exit Sub
        End If
        If txtInicial.Text = "" Then
            MessageBox.Show("Debe especificar la numeración inicial del talonario a entregar.", "No. Inicial de Talonario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtInicial.Focus()
            Exit Sub
        End If

        If txtFinal.Text = "" Then
            txtFinal.Text = CInt(txtInicial.Text) + CInt(txtCantidad.Text) - 1
        Else
            If txtFinal.Text <> CInt(txtInicial.Text) + CInt(txtCantidad.Text) - 1 Then
                MessageBox.Show("El recibo final específicado no concuerda con el cálculo en base al recibo inicial y la cantidad." & vbNewLine & vbNewLine & "Si desea el cálculo automático del recibo final, deje en blanco la casilla de No. Final.", "Error en cálculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtFinal.Focus()
                txtFinal.SelectAll()
                Exit Sub
            End If
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            Dim Cant As Double = txtCantidad.Text
            Dim x As Integer = 0
            DgvRecibos.Rows.Clear()

            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDReciboCobro,NoRecibo,Comentario FROM reciboscobro INNER JOIN GrupoRecibos on RecibosCobro.IDGrupoRecibo=GrupoRecibos.IDGrupoRecibos Where IDNaturaleza='" + lblIDNaturaleza.Text + "' and NoRecibo>=" & txtInicial.Text & " and NoRecibo<=" & txtFinal.Text & " and IDTalonario is Null", Con)
            Dim LectorRecibos As MySqlDataReader = Consulta.ExecuteReader

            While LectorRecibos.Read
                DgvRecibos.Rows.Add("", LectorRecibos.GetValue(0), LectorRecibos.GetValue(1), CDbl(0).ToString("C"), LectorRecibos.GetValue(2))
            End While
            LectorRecibos.Close()
            Con.Close()

            GbDatosTal.Enabled = False

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub txtInicial_Leave(sender As Object, e As EventArgs) Handles txtInicial.Leave
        Try

            If txtInicial.Text = "" Then
            Else
                If txtIDTalonario.Text = "" Then
                    Ds.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("Select NoTalonario,Fecha,Inicial from Talonariorecibo where Inicial='" + txtInicial.Text + "' And IDNaturaleza='" + lblIDNaturaleza.Text + "' and Nulo=0", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "Talonariorecibo")
                    Con.Close()

                    Dim Tabla As DataTable = Ds.Tables("Talonariorecibo")
                    If Tabla.Rows.Count > 0 Then
                        MessageBox.Show("El número de recibo inicial del presente talonario ya se encuentra ingresado en el talonario No." & Tabla.Rows(0).Item("NoTalonario") & ", de fecha " & Tabla.Rows(0).Item("Fecha") & ". Verifique la naturaleza del error.", "Verificar No. Inicial Talonario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtInicial.Focus()
                        txtInicial.SelectAll()
                        Exit Sub
                    End If

                    Ds.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT NoRecibo FROM Reciboscobro INNER JOIN TalonarioRecibo on RecibosCobro.IDTalonario=TalonarioRecibo.IDTalonarioRecibo Where NoRecibo = '" + txtInicial.Text + "' And TalonarioRecibo.Nulo=0 and IDNaturaleza='" + lblIDNaturaleza.Text + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "Reciboscobro")
                    Con.Close()

                    Dim TablaRec As DataTable = Ds.Tables("Reciboscobro")

                    If TablaRec.Rows.Count = 0 Then
                    Else
                        MessageBox.Show("El número de recibo inicial [" & txtInicial.Text & "] de presente talonario ya está procesado como un recibo de cobros. Verifique la naturaleza del error.", "Verificar No. Inicial Talonario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtInicial.Focus()
                        txtInicial.SelectAll()
                        Exit Sub
                    End If

                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

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

    Private Sub txtInicial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInicial.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtFinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFinal.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub cbxNaturaleza_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNaturaleza.SelectedIndexChanged
        SetIDNaturaleza()
    End Sub

    Private Sub txtNoTalonario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoTalonario.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDTalonario.Text = "" Then
            If CbxCobrador.Text <> "" Or txtCantidad.Text <> "" Or txtInicial.Text <> "" Or txtFinal.Text <> "" Then
                Dim Result As MsgBoxResult = MessageBox.Show("Se encuentran datos sin procesar. " & vbNewLine & vbNewLine & "Está seguro que desea limpiar el registro?", "Limpiar Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    LimpiarTodo()
                    ActualizarTodo()
                Else
                End If
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
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=52", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE TalonarioRecibo SET SecondID='" + lblSecondID.Text + "' WHERE IDTalonarioRecibo='" + txtIDTalonario.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=52"
            GuardarDatos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If CbxCobrador.Text = "" Then
            MessageBox.Show("Seleccione el cobrador que recibe el talonario de cobros.", "Elegir cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxCobrador.Focus()
            CbxCobrador.DroppedDown = True
            Exit Sub
        ElseIf cbxNaturaleza.Text = "" Then
            MessageBox.Show("Elija la naturaleza de los talonarios de cobros.", "Elegir Tipo de Recibos en Talonario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxNaturaleza.Focus()
            cbxNaturaleza.DroppedDown = True
            Exit Sub
        ElseIf txtCantidad.Text = "" Then
            MessageBox.Show("Escriba la cantidad de recibos que contiene el talonario.", "Cantidad de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidad.Focus()
            Exit Sub
        ElseIf txtInicial.Text = "" Then
            MessageBox.Show("Seleccione el recibo inicial del talonario.", "Recibo Inicial del talonario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtInicial.Focus()
            Exit Sub
        ElseIf DgvRecibos.Rows.Count = 0 Then
            MessageBox.Show("Aún no se han generado los recibos del talonario. Procese el talonario para continuar.", "Procesar Talonario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnProcesar.Focus()
            Exit Sub
        End If

        If txtIDTalonario.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo talonario de cobros para el cobrador " & CbxCobrador.Text & " en la base de datos?", "Guardar Talonario de Cobros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO TalonarioRecibo (IDTipoDocumento,IDUsuario,IDNaturaleza,Fecha,Hora,IDCobrador,NoTalonario,Cantidad,Inicial,Final,CantRestante,Nulo) VALUES (52,'" + lblIDUsuario.Text + "','" + lblIDNaturaleza.Text + "','" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "','" + CDate(txtHora.Text).ToString("HH:mm:ss") + "','" + lblIDCobrador.Text + "','" + txtNoTalonario.Text + "','" + txtCantidad.Text + "','" + txtInicial.Text + "','" + txtFinal.Text + "','" + txtCantidad.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltTalonario()
                SetSecondID()
                InsertarRecibos()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el talonario?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE TalonarioRecibo SET IDUsuario='" + lblIDUsuario.Text + "',IDNaturaleza='" + lblIDNaturaleza.Text + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',IDCobrador='" + lblIDCobrador.Text + "',NoTalonario='" + txtNoTalonario.Text + "',Cantidad='" + txtCantidad.Text + "',Inicial='" + txtInicial.Text + "',Final='" + txtFinal.Text + "',CantRestante='" + txtCantRestante.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTalonarioRecibo= (" + txtIDTalonario.Text + ")"
                GuardarDatos()
                InsertarRecibos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_talonario_cobro.ShowDialog(Me)
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El talonario código No. " & txtIDTalonario.Text & ", del cobrador " & CbxCobrador.Text & "  ya está anulado en el sistema. Desea activarlo?", "Recuperar Talonario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                ChkNulo.Checked = False
                sqlQ = "UPDATE TalonarioRecibo SET IDUsuario='" + lblIDUsuario.Text + "',IDNaturaleza='" + lblIDNaturaleza.Text + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',IDCobrador='" + lblIDCobrador.Text + "',NoTalonario='" + txtNoTalonario.Text + "',Cantidad='" + txtCantidad.Text + "',Inicial='" + txtInicial.Text + "',Final='" + txtFinal.Text + "',CantRestante='" + txtCantRestante.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTalonarioRecibo= (" + txtIDTalonario.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDTalonario.Text = "" Then
            MessageBox.Show("No hay un registro de talonario abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el registro del talonario código No." & txtIDTalonario.Text & " del sistema?", "Anular Talonario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ChkNulo.Checked = True
                sqlQ = "UPDATE TalonarioRecibo SET IDUsuario='" + lblIDUsuario.Text + "',IDNaturaleza='" + lblIDNaturaleza.Text + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',IDCobrador='" + lblIDCobrador.Text + "',NoTalonario='" + txtNoTalonario.Text + "',Cantidad='" + txtCantidad.Text + "',Inicial='" + txtInicial.Text + "',Final='" + txtFinal.Text + "',CantRestante='" + txtCantRestante.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDTalonarioRecibo= (" + txtIDTalonario.Text + ")"
                GuardarDatos()

                For Each Row As DataGridViewRow In DgvRecibos.Rows
                    Dim IDRecibo As New Label
                    IDRecibo.Text = Row.Cells(1).Value
                    sqlQ = "UPDATE RecibosCobro SET IDTalonario=NULL,Comentario='Recibo sin procesar.' WHERE IDReciboCobro= '" + IDRecibo.Text + "'"
                    GuardarDatos()

                Next
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDTalonario.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            frm_impresiones_directas.ShowDialog(Me)
        End If
    End Sub
End Class