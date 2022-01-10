Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frm_visual_solicitudes_cheques_compra
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet      'Usual sin interrupcion
    Dim IDCompra, IDSuplidor As New Label

    Private Sub frm_visual_solicitudes_cheques_compra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()

        If Me.Owner.Name = frm_pago_compras.Name Then
            IDSuplidor.Text = frm_pago_compras.txtIDSuplidor.Text
            lblNombreSuplidor.Text = frm_pago_compras.txtSuplidor.Text.ToUpper
            IDCompra.Text = frm_pago_compras.DgvCompras.CurrentRow.Cells(2).Value
            FillCompras()
            cbxFactura.Text = frm_pago_compras.DgvCompras.CurrentRow.Cells(15).Value
            ConsultarSolicitudes()
        End If
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()

    End Sub

    Private Sub ConsultarSolicitudes()
        Try
            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT SolicitudCheques.IDSolicitudCheque,SolicitudCheques.SecondID,Identidad,NoCuenta,FechaPago,SolicitudChequesDetalle.Monto,SolicitudCheques.Observacion FROM" & SysName.Text & "solicitudchequesdetalle inner join" & SysName.Text & "solicitudcheques on solicitudchequesdetalle.idsolicitudcheque=solicitudcheques.idsolicitudcheque inner join" & SysName.Text & "compras on solicitudchequesdetalle.idcompra=compras.idcompra inner join libregco.suplidor on compras.idsuplidor=suplidor.idsuplidor inner join" & SysName.Text & "cuentasbancarias on solicitudcheques.idcuenta=cuentasbancarias.idcuenta inner join libregco.bancos on cuentasbancarias.idbanco=bancos.idbanco WHERE Suplidor.IDSuplidor='" + IDSuplidor.Text + "' and Compras.IDCompra='" + IDCompra.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "SolicitudCheques")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("SolicitudCheques")
            DgvCheques.Rows.Clear()

            For Each row As DataRow In Tabla.Rows
                DgvCheques.Rows.Add(row.Item(0), row.Item(1), row.Item(2), row.Item(3), CDate(row.Item(4)).ToString("dd/MM/yyyy"), CDbl(row.Item(5)).ToString("C"), row.Item(6))
            Next

            For Each Row As DataGridViewRow In DgvCheques.Rows

                If CDate(Row.Cells(4).Value) = Today Then
                    Row.Cells(7).Value = "Aplicado hoy"
                    Row.DefaultCellStyle.ForeColor = Color.Blue
                    Row.DefaultCellStyle.BackColor = SystemColors.ControlLight
                ElseIf CDate(Row.Cells(4).Value) = Today.AddDays(-1) Then
                    Row.Cells(7).Value = "Pendiente para mañana"
                    Row.DefaultCellStyle.ForeColor = Color.GreenYellow
                ElseIf CDate(Row.Cells(4).Value) > Today Then
                    Row.Cells(7).Value = "Pendiente"
                    Row.DefaultCellStyle.ForeColor = Color.Red
                ElseIf Row.Cells(4).Value < Today Then
                    Row.Cells(7).Value = "Aplicado"
                    Row.DefaultCellStyle.ForeColor = Color.Green
                    Row.DefaultCellStyle.BackColor = SystemColors.ControlLight
                End If
            Next

            DgvCheques.ClearSelection()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillCompras()
        Try
            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT Compras.SecondID FROM" & SysName.Text & "Compras Where Compras.IDSuplidor='" + IDSuplidor.Text + "' and Compras.Nulo=0 ORDER BY IDCompra ASC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Compras")
            cbxFactura.Items.Clear()
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("Compras")

            For Each Fila As DataRow In Tabla.Rows
                cbxFactura.Items.Add(Fila.Item("SecondID"))
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub cbxFactura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxFactura.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDCompra FROM Compras WHERE SecondID= '" + cbxFactura.SelectedItem + "'", Con)
        IDCompra.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        ConsultarSolicitudes()
    End Sub
End Class