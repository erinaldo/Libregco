Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_buscar_eventos
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_eventos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla
    End Sub

    Private Sub RefrescarTabla()
        'Cargar Errores
        Dim Img As Image
        Dim wFile As System.IO.FileStream
        Dim CmdEventos As New MySqlCommand

        ConMixta.Open()
        DgvEventos.Rows.Clear()
        CmdEventos.CommandText = "Select IDEvento,Logo,Evento,FechaTermino from" & SysName.Text & "EventosBoleteria where Evento like '%" + txtBuscar.Text + "%' ORDER BY Evento DESC"
        CmdEventos.Connection = ConMixta

        Dim LectorEventos As MySqlDataReader = CmdEventos.ExecuteReader

        While LectorEventos.Read
            Dim ExistFile As Boolean = System.IO.File.Exists(LectorEventos.GetValue(1))
            If ExistFile = True Then
                wFile = New FileStream(LectorEventos.GetValue(1), FileMode.Open, FileAccess.Read)
                Img = System.Drawing.Image.FromStream(wFile)
                wFile.Close()
            Else
                Img = My.Resources.No_Image
            End If

            DgvEventos.Rows.Add(LectorEventos.GetValue(0), Img, LectorEventos.GetValue(2), CDate(LectorEventos.GetValue(3)).ToString("dd/MM/yyyy"))
        End While
        LectorEventos.Close()


        ConMixta.Close()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub DgvEventos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEventos.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvEventos.Focus()
    End Sub

    Private Sub DgvEventos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvEventos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvEventos.Focus()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Try
            If DgvEventos.Rows.Count > 0 Then

                Dim IDEvento As New Label
                Dim DsTemp As New DataSet

                IDEvento.Text = DgvEventos.CurrentRow.Cells(0).Value

                DsTemp.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT * from" & SysName.Text & "EventosBoleteria Where IDEvento='" + IDEvento.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "Eventos")
                ConMixta.Close()

                Dim Tabla As DataTable = DsTemp.Tables("Eventos")

                If Me.Owner.Name = frm_eventos_boleteria.Name Then
                    frm_eventos_boleteria.txtIDEvento.Text = Tabla.Rows(0).Item("IDEvento")
                    frm_eventos_boleteria.txtEvento.Text = Tabla.Rows(0).Item("Evento")
                    frm_eventos_boleteria.txtBase.Text = Tabla.Rows(0).Item("Base")
                    frm_eventos_boleteria.dtpInicio.Value = CDate(Tabla.Rows(0).Item("FechaInicio"))
                    frm_eventos_boleteria.dtpTermino.Value = CDate(Tabla.Rows(0).Item("FechaTermino"))
                    frm_eventos_boleteria.txtMontoAplicable.Text = CDbl(Tabla.Rows(0).Item("MontoBoleto")).ToString("C")
                    frm_eventos_boleteria.txtCantCaracteres.Text = Tabla.Rows(0).Item("CantidadLetras")
                    frm_eventos_boleteria.txtUltimaSecuencia.Text = Tabla.Rows(0).Item("UltimaSecuencia")
                    frm_eventos_boleteria.txtLimiteSecuencia.Text = Tabla.Rows(0).Item("HastaSecuencia")
                    frm_eventos_boleteria.txtPoliticas.Text = Tabla.Rows(0).Item("Politicas")

                    If Tabla.Rows(0).Item("AplicaenFact") = 0 Then
                        frm_eventos_boleteria.chkAplicarFactura.Checked = False
                        frm_eventos_boleteria.chkAplicarFactura.Tag = 0
                    Else
                        frm_eventos_boleteria.chkAplicarFactura.Checked = True
                        frm_eventos_boleteria.chkAplicarFactura.Tag = 1
                    End If

                    If Tabla.Rows(0).Item("AplicaenCobro") = 0 Then
                        frm_eventos_boleteria.chkAplicarPagos.Checked = False
                        frm_eventos_boleteria.chkAplicarPagos.Tag = 0
                    Else
                        frm_eventos_boleteria.chkAplicarPagos.Checked = True
                        frm_eventos_boleteria.chkAplicarPagos.Tag = 1
                    End If

                    frm_eventos_boleteria.CbxInstalledPrinters.Text = Tabla.Rows(0).Item("IDPrinter")

                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Logo"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("Logo"), FileMode.Open, FileAccess.Read)
                        frm_eventos_boleteria.PicLogo.Image = Image.FromStream(wFile)
                        wFile.Close()
                        wFile.Dispose()
                    Else
                        MessageBox.Show("Se ha encontrado un archivo que ha sido específicado. El motivo se puede deber a que el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    Con.Open()
                    cmd = New MySqlCommand("Select Reporte from Reportes where IDReportes='" + Tabla.Rows(0).Item("IDReporte").ToString + "'", Con)
                    frm_eventos_boleteria.CbxFormato.Text = Convert.ToString(cmd.ExecuteScalar())
                    Con.Close()


                    Me.Close()
                End If
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
    Private Sub DgvEventos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvEventos.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvEventos.ColumnCount
                Dim NumRows As Integer = DgvEventos.RowCount
                Dim CurCell As DataGridViewCell = DgvEventos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvEventos.CurrentCell = DgvEventos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvEventos.CurrentCell = DgvEventos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

End Class