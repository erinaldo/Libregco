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

Public Class frm_eventos_boleteria
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList
    Dim RutaLogo As String
    Private Sub frm_eventos_boleteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        FillInstaledPrinters()
        FillReportes()
    End Sub

    Private Sub FillReportes()
        Try

            Dim DsTemp As New DataSet

            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Boleteria' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Reportes")
            CbxFormato.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("Reportes")

            For Each Fila As DataRow In Tabla.Rows
                CbxFormato.Items.Add(Fila.Item("Descripcion"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxFormato.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron reportes que involucren este vínculo del módulo.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillInstaledPrinters()
        For Each pkInstalledPrinters As String In PrinterSettings.InstalledPrinters
            CbxInstalledPrinters.Items.Add(pkInstalledPrinters)
        Next

        If CbxInstalledPrinters.Items.Count > 0 Then
            CbxInstalledPrinters.SelectedIndex = 0
        End If
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDEvento.Clear()
        txtEvento.Clear()
        txtBase.Clear()
        lblEjemploNumeracion.Text = "1"
        txtMontoAplicable.Text = CDbl(0).ToString("C")
        txtCantCaracteres.Text = 1
        dtpInicio.Value = Today
        dtpTermino.Value = Today
        txtUltimaSecuencia.Clear()
        txtLimiteSecuencia.Clear()
        chkAplicarFactura.Checked = False
        chkAplicarFactura.Tag = 0
        chkAplicarPagos.Tag = 0
        chkAplicarPagos.Checked = False
        PicLogo.Image = My.Resources.No_Image
        RutaLogo = ""
        txtPoliticas.Clear()
        PicLogo.Tag = ""
    End Sub

    Private Sub txtCantCaracteres_TextChanged(sender As Object, e As EventArgs) Handles txtCantCaracteres.TextChanged
        If txtCantCaracteres.Text = "" Then
        Else
            lblEjemploNumeracion.Text = CStr(1).PadLeft(txtCantCaracteres.Text, "0")
        End If
    End Sub

    Private Sub txtCantCaracteres_Leave(sender As Object, e As EventArgs) Handles txtCantCaracteres.Leave
        If txtCantCaracteres.Text = "" Then
            txtCantCaracteres.Text = 1
        ElseIf txtCantCaracteres.Text = 0 Then
            txtCantCaracteres.Text = 1
        End If
    End Sub

    Private Sub txtMontoAplicable_Leave(sender As Object, e As EventArgs) Handles txtMontoAplicable.Leave
        If txtMontoAplicable.Text = "" Then
            txtMontoAplicable.Text = CDbl(1).ToString("C")

        ElseIf txtMontoAplicable.Text = 0 Then
            txtMontoAplicable.Text = CDbl(1).ToString("C")
        Else

            txtMontoAplicable.Text = CDbl(txtMontoAplicable.Text).ToString("C")
        End If
    End Sub

    Private Sub dtpInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpInicio.ValueChanged
        lblPeriodo.Text = "Período del evento: " & CalcularFecha(dtpInicio.Value, dtpTermino.Value)
    End Sub

    Private Sub txtMontoAplicable_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoAplicable.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub txtUltimaSecuencia_Leave(sender As Object, e As EventArgs) Handles txtUltimaSecuencia.Leave
        If txtUltimaSecuencia.Text = "" Then
            txtUltimaSecuencia.Text = 0
        End If
    End Sub

    Private Sub txtUltimaSecuencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUltimaSecuencia.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtLimiteSecuencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimiteSecuencia.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtLimiteSecuencia_Leave(sender As Object, e As EventArgs) Handles txtLimiteSecuencia.Leave
        If txtLimiteSecuencia.Text = "" Then
            txtLimiteSecuencia.Text = 1
        End If
    End Sub

    Private Sub PicLogo_Click(sender As Object, e As EventArgs) Handles PicLogo.Click
        Dim OfdRutaFoto As New OpenFileDialog
        Dim wFile As System.IO.FileStream

        OfdRutaFoto.RestoreDirectory = True
        OfdRutaFoto.Title = ("Seleccionar foto de artículo")
        OfdRutaFoto.Filter = "Imágenes(*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png"
        OfdRutaFoto.FileName = ""

        If OfdRutaFoto.ShowDialog = Windows.Forms.DialogResult.OK Then
            PicLogo.Tag = OfdRutaFoto.FileName
            wFile = New FileStream(OfdRutaFoto.FileName, FileMode.Open, FileAccess.Read)
            PicLogo.Image = System.Drawing.Image.FromStream(wFile)
            RutaLogo = OfdRutaFoto.FileName
            wFile.Close()
        End If
    End Sub

    Private Sub dtpTermino_ValueChanged(sender As Object, e As EventArgs) Handles dtpTermino.ValueChanged
        lblPeriodo.Text = "Período del evento: " & CalcularFecha(dtpInicio.Value, dtpTermino.Value)
    End Sub

    Private Sub txtMontoAplicable_Enter(sender As Object, e As EventArgs) Handles txtMontoAplicable.Enter
        If txtMontoAplicable.Text = "" Then
            txtMontoAplicable.Text = 0
        Else
            txtMontoAplicable.Text = CDbl(txtMontoAplicable.Text)
        End If

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
    End Sub

    Private Sub GuardarDatos()
        Try
            ConMixta.Open()
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
            ConMixta.Close()

        Catch ex As Exception
            ConMixta.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UltEvento()
        If txtIDEvento.Text = "" Then
            ConMixta.Open()
            cmd = New MySqlCommand("Select IDEvento from" & SysName.Text & "EventosBoleteria where IDEvento= (Select Max(IDEvento) from" & SysName.Text & "EventosBoleteria)", ConMixta)
            txtIDEvento.Text = Convert.ToString(cmd.ExecuteScalar())
            ConMixta.Close()
        End If

    End Sub
    Private Sub ConvertDouble()
        txtMontoAplicable.Text = CDbl(txtMontoAplicable.Text)

    End Sub

    Private Sub ConvertCurrent()
        txtMontoAplicable.Text = CDbl(txtMontoAplicable.Text).ToString("C")
    End Sub

    Private Sub chkAplicarFactura_CheckedChanged(sender As Object, e As EventArgs) Handles chkAplicarFactura.CheckedChanged
        If chkAplicarFactura.Checked = True Then
            chkAplicarFactura.Tag = 1
        Else
            chkAplicarFactura.Tag = 0
        End If
    End Sub

    Private Sub chkAplicarPagos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAplicarPagos.CheckedChanged
        If chkAplicarPagos.Checked = True Then
            chkAplicarPagos.Tag = 1
        Else
            chkAplicarPagos.Tag = 0
        End If
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        Try
            If txtEvento.Text = "" Then
                MessageBox.Show("Especifique el nombre del evento que desea procesar.", "Nombre del evento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtEvento.Focus()
                Exit Sub

            ElseIf txtCantCaracteres.Text = "" Then
                MessageBox.Show("Especifique la cantidad de caracteres de la secuencia.", "Cant. de caracteres", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtCantCaracteres.Focus()
                Exit Sub

            ElseIf txtUltimaSecuencia.Text = "" Then
                MessageBox.Show("Especifique la secuencia que desea continuar.", "Actual secuencia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtUltimaSecuencia.Focus()
                Exit Sub

            ElseIf txtLimiteSecuencia.Text = "" Then
                MessageBox.Show("Especifique el límite máximo de la secuencia.", "Máxima secuencia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtLimiteSecuencia.Focus()
                Exit Sub
            End If

            If txtIDEvento.Text = "" Then 'Si no hay un cliente seleccionado
                If Permisos(1) = 0 Then
                    MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo registro de eventos de boletería a la base de datos?", "Guardar Nuevo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    sqlQ = "INSERT INTO" & SysName.Text & "EventosBoleteria (Evento,Base,FechaInicio,FechaTermino,MontoBoleto,CantidadLetras,UltimaSecuencia,HastaSecuencia,AplicaenFact,AplicaenCobro,Politicas,IDReporte,IDPrinter) VALUES ('" + txtEvento.Text + "','" + txtBase.Text + "','" + dtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + dtpTermino.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + txtMontoAplicable.Text + "','" + txtCantCaracteres.Text + "','" + txtUltimaSecuencia.Text + "','" + txtLimiteSecuencia.Text + "','" + chkAplicarFactura.Tag.ToString + "','" + chkAplicarPagos.Tag.ToString + "','" + txtPoliticas.Text + "','" + CbxFormato.Tag.ToString + "','" + Replace(CbxInstalledPrinters.Text, "\", "\\") + "')"
                    GuardarDatos()
                    ConvertCurrent()
                    UltEvento()
                    MoverFichero()
                    MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Else
                If Permisos(2) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConvertDouble()
                    sqlQ = "UPDATE" & SysName.Text & "EventosBoleteria Set Evento='" + txtEvento.Text + "',Base='" + txtBase.Text + "',FechaInicio='" + dtpInicio.Value.ToString("yyyy-MM-dd HH:mm:ss") + "',FechaTermino='" + dtpTermino.Value.ToString("yyyy-MM-dd HH:mm:ss") + "',MontoBoleto='" + txtMontoAplicable.Text + "',CantidadLetras='" + txtCantCaracteres.Text + "',UltimaSecuencia='" + txtUltimaSecuencia.Text + "',AplicaenFact='" + chkAplicarFactura.Tag.ToString + "',AplicaenCobro='" + chkAplicarPagos.Tag.ToString + "',Politicas='" + txtPoliticas.Text + "',IDReporte='" + CbxFormato.Tag.ToString + "',IDPrinter='" + Replace(CbxInstalledPrinters.Text, "\", "\\") + "' WHERE IDEvento= (" + txtIDEvento.Text + ")"
                    GuardarDatos()
                    ConvertCurrent()
                    MoverFichero()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If
        Catch ex As Exception
  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub MoverFichero()
        Try
            If TypeConnection.Text = 1 Then
                Dim ExistFile As Boolean

                'Modificando ruta de foto

                If RutaLogo <> "" Then
                    ExistFile = System.IO.File.Exists(RutaLogo)

                    If ExistFile = True Then
                        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Eventos\Evento-" & txtIDEvento.Text & ".png"

                        If RutaDestino <> RutaLogo Then
                            My.Computer.FileSystem.MoveFile(PicLogo.Tag.ToString, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                            sqlQ = "UPDATE" & SysName.Text & "EventosBoleteria SET Logo='" + Replace(RutaDestino, "\", "\\") + "' WHERE IDEvento= (" + txtIDEvento.Text + ")"
                            ConMixta.Open()
                            cmd = New MySqlCommand(sqlQ, ConMixta)
                            cmd.ExecuteNonQuery()
                            ConMixta.Close()

                        End If

                    Else
                        MessageBox.Show("El archivo " & PicLogo.Tag.ToString & " ha sido movido o eliminado antes de ser guardado en la base de datos.", "Archivo no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                Else
                    sqlQ = "UPDATE" & SysName.Text & "EventosBoleteria SET Logo='' WHERE IDEvento= (" + txtIDEvento.Text + ")"
                    ConMixta.Open()
                    cmd = New MySqlCommand(sqlQ, ConMixta)
                    cmd.ExecuteNonQuery()
                    ConMixta.Close()
                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_eventos.ShowDialog(Me)
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Reportes")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Reportes")

        CbxFormato.Tag = (Tabla.Rows(0).Item("IDReportes"))

    End Sub
End Class