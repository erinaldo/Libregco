Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_generacion_nuevos_recibos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblIDNaturaleza, lblPreRecibo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_generacion_nuevos_recibos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        CargarEmpresa()
        ColumnasDgvRecibos()
        LimpiarTodo()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarTodo()
        cbxNaturaleza.Items.Clear()
        DgvRecibos.Rows.Clear()
        lblIDNaturaleza.Text = ""
        txtCantidad.Clear()
        txtInicial.Clear()
        txtFinal.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        lblPreRecibo.Text = ""
        txtFabricante.Clear()
        dtpFechaEmision.Value = Today
        txtObservaciones.Clear()
        txtIDGRecibo.Clear()
        txtSecondID.Clear()
        txtFecha.Clear()
        txtHora.Clear()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        HabilitarSet()
        FillNaturaleza()
        txtFecha.Text = Today
        txtHora.Text = TimeOfDay
        lblNulo.Text = 0
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ColumnasDgvRecibos()
        DgvRecibos.Columns.Clear()
        With DgvRecibos
            .Columns.Add("IDReciboCobro", "IDRecibo") '0
            .Columns.Add("IDGrupoRecibo", "Grupo") '1
            .Columns.Add("PreRecibo", "Tipo") '2
            .Columns.Add("NoRecibo", "No. Recibo") '3
            .Columns.Add("Descripcion", "Descripción") '4
        End With

        PropiedadColumnasDgvRecibos()
    End Sub

    Private Sub PropiedadColumnasDgvRecibos()
        With DgvRecibos
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Width = 80
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            .Columns(3).Width = 120
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).Width = 490
        End With
    End Sub

    Private Sub FillNaturaleza()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Naturalezarecibo Where Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Naturalezarecibo")
            cbxNaturaleza.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Naturalezarecibo")
            For Each Fila As DataRow In Tabla.Rows
                cbxNaturaleza.Items.Add(Fila.Item("Descripcion"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub

    Private Sub SetIDNaturaleza()
        Con.Open()

        cmd = New MySqlCommand("SELECT IDNaturaleza FROM Naturalezarecibo WHERE Descripcion= '" + cbxNaturaleza.Text + "'", Con)
        lblIDNaturaleza.Text = Convert.ToDouble(cmd.ExecuteScalar())
        cmd = New MySqlCommand("SELECT Abreviacion FROM Naturalezarecibo WHERE Descripcion= '" + cbxNaturaleza.Text + "'", Con)
        lblPreRecibo.Text = Convert.ToString(cmd.ExecuteScalar())

        Con.Close()
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        If txtCantidad.Text = "" Then
            MessageBox.Show("Especifique la cantidad de recibos que tiene el talonario para continuar.", "Complete la cant. de recibos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidad.Focus()
            Exit Sub
        End If
        If txtInicial.Text = "" Then
            MessageBox.Show("Debe especificar la numeración inicial del talonario a entregar.", "No. inicial de talonario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
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
        Try
            Dim Cant As Double = txtCantidad.Text
            Dim InCrec As New Label
            Dim x As Integer = 0
            DgvRecibos.Rows.Clear()

            Con.Open()
Inicio:
            If x = Cant Then
                GoTo Final
            End If

            InCrec.Text = lblPreRecibo.Text & CInt(txtInicial.Text) + CInt(x)

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Concat(PreRecibo,NoRecibo) FROM Reciboscobro INNER JOIN GrupoRecibos on RecibosCobro.IDGrupoRecibo=GrupoRecibos.IDGrupoRecibos Where Concat(PreRecibo,NoRecibo)= '" + InCrec.Text + "' And GrupoRecibos.Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Reciboscobro")

            Dim Tabla As DataTable = Ds.Tables("Reciboscobro")
            If Tabla.Rows.Count = 0 Then
                DgvRecibos.Rows.Add("", "", lblPreRecibo.Text, CDbl(txtInicial.Text) + CInt(x), "Recibo sin procesar.")
            Else
                MessageBox.Show("El número [" & lblPreRecibo.Text & CDbl(txtInicial.Text) + CInt(x) & "] ya se encuentra procesado como " & cbxNaturaleza.Text & "." & vbNewLine & "Verifique la naturaleza del error y vuelva a intentar crear el talonario.", "Verificar " & lblPreRecibo.Text & "-" & CDbl(txtInicial.Text) + CInt(x), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                DgvRecibos.Rows.Clear()
                Con.Close()
                Exit Sub
            End If

            x = x + 1
            GoTo inicio
Final:
            Con.Close()
            txtCantidad.Enabled = False
            txtInicial.Enabled = False
            txtFinal.Enabled = False
            btnProcesar.Enabled = False
            cbxNaturaleza.Enabled = False
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub cbxNaturaleza_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNaturaleza.SelectedIndexChanged
        SetIDNaturaleza()
        HabilitarSet()
    End Sub

    Private Sub HabilitarSet()
        If cbxNaturaleza.Text = "" Then
            txtCantidad.Enabled = False
            txtInicial.Enabled = False
            txtFinal.Enabled = False
            btnProcesar.Enabled = False
        Else
            txtCantidad.Enabled = True
            txtInicial.Enabled = True
            txtFinal.Enabled = True
            btnProcesar.Enabled = True
        End If
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

    Private Sub txtFinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFinal.KeyPress
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

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub InsertarRecibos()
        Dim IDRecibo, PreRecibo, IDTalonario, NoRecibo, Descripcion As New Label
        Dim x As Integer = 0

Inicio:
        If x = DgvRecibos.RowCount Then
            GoTo Fin
        End If
        IDRecibo.Text = DgvRecibos.Rows(x).Cells(0).Value
        PreRecibo.Text = DgvRecibos.Rows(x).Cells(2).Value
        NoRecibo.Text = CDbl(DgvRecibos.Rows(x).Cells(3).Value)
        Descripcion.Text = DgvRecibos.Rows(x).Cells(4).Value


        If IDRecibo.Text = "" Then
            sqlQ = "INSERT INTO Reciboscobro (IDGrupoRecibo,PreRecibo,NoRecibo,Comentario,Cierre,Nulo) VALUES ('" + txtIDGRecibo.Text + "','" + PreRecibo.Text + "','" + NoRecibo.Text + "','" + Descripcion.Text + "',0,0)"
            GuardarDatos()
            x = x + 1
            GoTo Inicio
        Else
            x = x + 1
            GoTo Inicio
        End If

Fin:
        RefrescarRecibos()

        '.Columns.Add("IDReciboCobro", "IDRecibo") '0
        '.Columns.Add("IDGrupoRecibo", "Grupo") '1
        '.Columns.Add("PreRecibo", "Tipo") '2
        '.Columns.Add("NoRecibo", "No. Recibo") '3
        '.Columns.Add("Descripcion", "Descripción") '4
    End Sub

    Sub RefrescarRecibos()
        Try
            DgvRecibos.Rows.Clear()
            Con.Open()
            Dim CmdFacts As New MySqlCommand("SELECT IDReciboCobro,IDGrupoRecibo,PreRecibo,NoRecibo,Comentario from RecibosCobro WHERE IDGrupoRecibo='" + txtIDGRecibo.Text + "'", Con)
            Dim LectorRecibos As MySqlDataReader = CmdFacts.ExecuteReader

            While LectorRecibos.Read
                DgvRecibos.Rows.Add(LectorRecibos.GetValue(0), LectorRecibos.GetValue(1), LectorRecibos.GetValue(2), LectorRecibos.GetValue(3), LectorRecibos.GetValue(4))
            End While
            LectorRecibos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub UltGRecibo()
        Try
            If txtIDGRecibo.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDGrupoRecibos from gruporecibos where IDGrupoRecibos= (Select Max(IDGrupoRecibos) from gruporecibos)", Con)
                txtIDGRecibo.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub HabilitarControles()
        GbDatosTal.Enabled = True
        DgvRecibos.Enabled = True
        cbxNaturaleza.Enabled = True
        txtFabricante.Enabled = True
        txtObservaciones.Enabled = True
        dtpFechaEmision.Enabled = True
        btnProcesar.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        GbDatosTal.Enabled = False
        DgvRecibos.Enabled = False
        cbxNaturaleza.Enabled = False
        txtFabricante.Enabled = False
        txtObservaciones.Enabled = False
        dtpFechaEmision.Enabled = False
        btnProcesar.Enabled = False
    End Sub

    Private Sub txtInicial_Leave(sender As Object, e As EventArgs) Handles txtInicial.Leave
        Try

            If txtInicial.Text = "" Then
            Else
                If txtIDGRecibo.Text = "" Then
                    Ds.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("Select IDGrupoRecibos,Fecha,NoInicial from GrupoRecibos where NoInicial='" + txtInicial.Text + "' And IDNaturaleza='" + lblIDNaturaleza.Text + "' and Nulo=0", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "Talonariorecibo")
                    Con.Close()

                    Dim Tabla As DataTable = Ds.Tables("Talonariorecibo")

                    If Tabla.Rows.Count = 0 Then
                    Else
                        MessageBox.Show("El número de recibo inicial ya se encuentra ingresado en el grupo de recibos No. " & Tabla.Rows(0).Item("IDGrupoRecibos") & ", de fecha " & Tabla.Rows(0).Item("Fecha") & ".", "Verificar No. inicial de grupo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        txtInicial.Focus()
                        txtInicial.SelectAll()
                        Exit Sub
                    End If

                    Ds.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT NoRecibo FROM Reciboscobro INNER JOIN GrupoRecibos on RecibosCobro.IDGrupoRecibo=GrupoRecibos.IDGrupoRecibos Where NoRecibo='" + txtInicial.Text + "' And GrupoRecibos.Nulo=0 and IDNaturaleza='" + lblIDNaturaleza.Text + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "Reciboscobro")
                    Con.Close()

                    Dim TablaRec As DataTable = Ds.Tables("Talonariorecibo")

                    If TablaRec.Rows.Count > 0 Then
                        MessageBox.Show("El número de recibo inicial [" & txtInicial.Text & "] ya está procesado como un recibo de cobros. Verifique la naturaleza del error.", "Verificar No. Inicial", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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

    Private Sub btnAnular_Click(sender As Object, e As EventArgs)
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El grupo de recibos código No. " & txtIDGRecibo.Text & " ya está anulado en el sistema. Desea activarlo?", "Recuperar Grupo de Recibos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then

                ChkNulo.Checked = False
                sqlQ = "UPDATE GrupoRecibos SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',Cantidad='" + txtCantidad.Text + "',NoInicial='" + txtInicial.Text + "',NoFinal='" + txtFinal.Text + "',IDNaturaleza='" + lblIDNaturaleza.Text + "',Fabricante='" + txtFabricante.Text + "',FechaEmision='" + dtpFechaEmision.Value + "',Observaciones='" + txtObservaciones.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDGrupoRecibos= '" + txtIDGRecibo.Text + "'"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDGRecibo.Text = "" Then
            MessageBox.Show("No hay un registro de grupo de recibos abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el registro del grupo de recibos código No." & txtIDGRecibo.Text & " del sistema?", "Anular Grupo de Recibos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                ChkNulo.Checked = True
                sqlQ = "UPDATE GrupoRecibos SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',Cantidad='" + txtCantidad.Text + "',NoInicial='" + txtInicial.Text + "',NoFinal='" + txtFinal.Text + "',IDNaturaleza='" + lblIDNaturaleza.Text + "',Fabricante='" + txtFabricante.Text + "',FechaEmision='" + dtpFechaEmision.Value + "',Observaciones='" + txtObservaciones.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDGrupoRecibos= '" + txtIDGRecibo.Text + "'"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Sub RefrescarTablaRecibos()

        Try
            If txtIDGRecibo.Text = "" Then
            Else
                DgvRecibos.Rows.Clear()
                Con.Open()
                Dim Consulta As New MySqlCommand("Select IDReciboCobro,IDGrupoRecibo,PreRecibo,NoRecibo,Comentario FROM RecibosCobro Where IDGrupoRecibo='" + txtIDGRecibo.Text + "'", Con)
                Dim LectorRecibos As MySqlDataReader = Consulta.ExecuteReader

                While LectorRecibos.Read
                    DgvRecibos.Rows.Add(LectorRecibos.GetValue(0), LectorRecibos.GetValue(1), LectorRecibos.GetValue(2), LectorRecibos.GetValue(3), LectorRecibos.GetValue(4))
                End While
                LectorRecibos.Close()
                Con.Close()
                PropiedadColumnasDgvRecibos()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

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
        btnDesactivar.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDGRecibo.Text = "" Then
            If cbxNaturaleza.Text <> "" Or txtCantidad.Text <> "" Or txtInicial.Text <> "" Or txtFinal.Text <> "" Then
                Dim Result As MsgBoxResult = MessageBox.Show("Se encuentran datos sin procesar. " & vbNewLine & vbNewLine & "Está seguro que desea limpiar el registro de recibos?", "Limpiar Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
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
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=51", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE GrupoRecibos SET SecondID='" + lblSecondID.Text + "' WHERE IDGrupoRecibos='" + txtIDGRecibo.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=51"
            GuardarDatos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtCantidad.Text = "" Then
            MessageBox.Show("Escriba la cantidad de recibos que contiene el talonario.", "Cantidad de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidad.Focus()
            Exit Sub
        ElseIf txtInicial.Text = "" Then
            MessageBox.Show("Seleccione el recibo inicial del talonario.", "Recibo Inicial del talonario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtInicial.Focus()
            Exit Sub
        ElseIf cbxNaturaleza.Text = "" Then
            MessageBox.Show("Elija la naturaleza de los talonarios de cobros.", "Elegir Tipo de Recibos en Talonario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxNaturaleza.Focus()
            cbxNaturaleza.DroppedDown = True
            Exit Sub
        ElseIf DgvRecibos.Rows.Count = 0 Then
            MessageBox.Show("Aún no se han generado los recibos del talonario. Procese el talonario para continuar.", "Procesar Talonario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnProcesar.Focus()
            Exit Sub
        End If

        If txtIDGRecibo.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea generar los nuevos recibos de cobros en la base de datos?", "Generar recibos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO GrupoRecibos (IDTipoDocumento,IDSucursal,IDUsuario,Fecha,Hora,Cantidad,NoInicial,NoFinal,IDNaturaleza,Fabricante,FechaEmision,Observaciones,Nulo) VALUES (51,'" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "','" + CDate(txtHora.Text).ToString("HH:mm:ss") + "','" + txtCantidad.Text + "','" + txtInicial.Text + "','" + txtFinal.Text + "','" + lblIDNaturaleza.Text + "','" + txtFabricante.Text + "','" + dtpFechaEmision.Value.ToString("yyyy-MM-dd") + "','" + txtObservaciones.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltGRecibo()
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
                sqlQ = "UPDATE GrupoRecibos SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + txtFecha.Text.ToString("yyyy-MM-dd") + "',Hora='" + txtHora.Text.ToString("HH:mm:ss") + "',Cantidad='" + txtCantidad.Text + "',NoInicial='" + txtInicial.Text + "',NoFinal='" + txtFinal.Text + "',IDNaturaleza='" + lblIDNaturaleza.Text + "',Fabricante='" + txtFabricante.Text + "',FechaEmision='" + dtpFechaEmision.Value.ToString("yyyy-MM-dd") + "',Observaciones='" + txtObservaciones.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDGrupoRecibos= '" + txtIDGRecibo.Text + "'"
                GuardarDatos()
                InsertarRecibos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
            End If
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtCantidad.Text = "" Then
            MessageBox.Show("Escriba la cantidad de recibos que contiene el talonario.", "Cantidad de Recibos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCantidad.Focus()
            Exit Sub
        ElseIf txtInicial.Text = "" Then
            MessageBox.Show("Seleccione el recibo inicial del talonario.", "Recibo Inicial del talonario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtInicial.Focus()
            Exit Sub
        ElseIf cbxNaturaleza.Text = "" Then
            MessageBox.Show("Elija la naturaleza de los talonarios de cobros.", "Elegir Tipo de Recibos en Talonario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxNaturaleza.Focus()
            cbxNaturaleza.DroppedDown = True
            Exit Sub
        ElseIf DgvRecibos.Rows.Count = 0 Then
            MessageBox.Show("Aún no se han generado los recibos del talonario. Procese el talonario para continuar.", "Procesar Talonario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnProcesar.Focus()
            Exit Sub
        End If

        If txtIDGRecibo.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea generar los nuevos recibos de cobros en la base de datos?", "Generar recibos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO GrupoRecibos (IDTipoDocumento,IDUsuario,Fecha,Hora,Cantidad,NoInicial,NoFinal,IDNaturaleza,Fabricante,FechaEmision,Observaciones,Nulo) VALUES (51,'" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "','" + CDate(txtHora.Text).ToString("HH:mm:ss") + "','" + txtCantidad.Text + "','" + txtInicial.Text + "','" + txtFinal.Text + "','" + lblIDNaturaleza.Text + "','" + txtFabricante.Text + "','" + dtpFechaEmision.Value.ToString("yyyy-MM-dd") + "','" + txtObservaciones.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                UltGRecibo()
                SetSecondID()
                InsertarRecibos()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarTodo()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el talonario?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE GrupoRecibos SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',Cantidad='" + txtCantidad.Text + "',NoInicial='" + txtInicial.Text + "',NoFinal='" + txtFinal.Text + "',IDNaturaleza='" + lblIDNaturaleza.Text + "',Fabricante='" + txtFabricante.Text + "',FechaEmision='" + dtpFechaEmision.Value.ToString("yyyy-MM-dd") + "',Observaciones='" + txtObservaciones.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDGrupoRecibos= '" + txtIDGRecibo.Text + "'"
                GuardarDatos()
                InsertarRecibos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                LimpiarTodo()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_grupo_recibos.ShowDialog(Me)
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La generación de recibos No. " & txtSecondID.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar generación de recibos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 47
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = False
                sqlQ = "UPDATE GrupoRecibos SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',Cantidad='" + txtCantidad.Text + "',NoInicial='" + txtInicial.Text + "',NoFinal='" + txtFinal.Text + "',IDNaturaleza='" + lblIDNaturaleza.Text + "',Fabricante='" + txtFabricante.Text + "',FechaEmision='" + dtpFechaEmision.Value.ToString("yyyy-MM-dd") + "',Observaciones='" + txtObservaciones.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDGrupoRecibos= '" + txtIDGRecibo.Text + "'"
                GuardarDatos()
                InsertarRecibos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDGRecibo.Text = "" Then
            MessageBox.Show("No hay un registro de movimiento bancario abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular la generación de recibos No. " & txtSecondID.Text & " del sistema?", "Anular Mov. Bancario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 46
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ChkNulo.Checked = True
                sqlQ = "UPDATE GrupoRecibos SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Fecha='" + CDate(txtFecha.Text).ToString("yyyy-MM-dd") + "',Hora='" + CDate(txtHora.Text).ToString("HH:mm:ss") + "',Cantidad='" + txtCantidad.Text + "',NoInicial='" + txtInicial.Text + "',NoFinal='" + txtFinal.Text + "',IDNaturaleza='" + lblIDNaturaleza.Text + "',Fabricante='" + txtFabricante.Text + "',FechaEmision='" + dtpFechaEmision.Value.ToString("yyyy-MM-dd") + "',Observaciones='" + txtObservaciones.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDGrupoRecibos= '" + txtIDGRecibo.Text + "'"
                GuardarDatos()
                InsertarRecibos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDGRecibo.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            frm_impresiones_directas.ShowDialog(Me)
        End If

    End Sub
End Class