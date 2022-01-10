Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_conduce_reparacion

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_conduce_reparacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDReparacion,SecondID,Fecha,Suplidor.Suplidor,Motivo,Nulo FROM" & SysName.Text & "reparacion INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor where SecondID like '%" + txtBuscar.Text + "%' and Reparacion.Nulo=0 ORDER BY IDReparacion DESC", ConMixta)
            ElseIf rdbMotivo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDReparacion,SecondID,Fecha,Suplidor.Suplidor,Motivo,Nulo FROM" & SysName.Text & "reparacion INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor Where Motivo like '%" + txtBuscar.Text + "%' and Reparacion.Nulo=0 ORDER BY IDReparacion DESC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Conduces")

            Bs.DataMember = "Conduces"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvConduces.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception
            '  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvConduces
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "No. Conduce"
            .Columns(1).Width = 100
            .Columns(2).HeaderText = "Fecha"
            .Columns(2).Width = 80
            .Columns(3).HeaderText = "Suplidor"
            .Columns(3).Width = 230
            .Columns(4).Width = 200
            .Columns(4).HeaderText = "Motivo"
            .Columns(4).Width = 240
            .Columns(5).Visible = False
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbReferencia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMotivo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvConduces.Focus()
    End Sub

    Private Sub DgvConduces_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvConduces.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvConduces.Focus()
        End If
    End Sub

    Private Sub DgvConduces_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvConduces.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvConduces.ColumnCount
                Dim NumRows As Integer = DgvConduces.RowCount
                Dim CurCell As DataGridViewCell = DgvConduces.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvConduces.CurrentCell = DgvConduces.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvConduces.CurrentCell = DgvConduces.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvConduces_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvConduces.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDReparacion, Nulo As New Label
        IDReparacion.Text = DgvConduces.CurrentRow.Cells(0).Value

        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDReparacion,IDTipoDocumento,Reparacion.SecondID as SecondIDReparacion,Fecha,Hora,IDUsuario,Reparacion.IDSuplidor,Suplidor.Suplidor,Suplidor.Balance,Reparacion.IDAlmacen,Almacen.Almacen,Reparacion.IDTipoOrden,TipoOrdenReparacion.Descripcion as DescripcionOrden,Reparacion.IDStatusReparacion,StatusReparacion.Descripcion as StatusReparacion,FechaPrometida,Comentario,Motivo,Impreso,Reparacion.Nulo,ifnull((Select Fecha from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Neto from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto FROM" & SysName.Text & "reparacion INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & "Almacen on Reparacion.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.TipoOrdenReparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion INNER JOIN Libregco.StatusReparacion on Reparacion.IDStatusReparacion=StatusReparacion.IDStatusReparacion Where IDReparacion= '" + IDReparacion.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Reparacion")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("Reparacion")

        If Me.Owner.Name = frm_conduce_reparaciones.Name Then
            frm_conduce_reparaciones.txtIDReparacion.Text = (Tabla.Rows(0).Item("IDReparacion"))
            frm_conduce_reparaciones.txtSecondID.Text = (Tabla.Rows(0).Item("SecondIDReparacion"))
            frm_conduce_reparaciones.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_conduce_reparaciones.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_conduce_reparaciones.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
            frm_conduce_reparaciones.cbxTipoOrden.Text = (Tabla.Rows(0).Item("DescripcionOrden"))
            frm_conduce_reparaciones.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
            frm_conduce_reparaciones.cbxStatus.Text = (Tabla.Rows(0).Item("StatusReparacion"))
            frm_conduce_reparaciones.txtBalanceSup.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
            frm_conduce_reparaciones.txtMotivo.Text = (Tabla.Rows(0).Item("Motivo"))
            frm_conduce_reparaciones.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
            frm_conduce_reparaciones.DtpFechaPrometida.Value = (Tabla.Rows(0).Item("FechaPrometida"))
            frm_conduce_reparaciones.lblDesactivar.Text = (Tabla.Rows(0).Item("Nulo"))

            If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                frm_conduce_reparaciones.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
            Else
                frm_conduce_reparaciones.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
            End If

            If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                frm_conduce_reparaciones.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
            Else
                frm_conduce_reparaciones.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
            End If

            frm_conduce_reparaciones.RefrescarTablaConsulta()
            frm_conduce_reparaciones.cbxStatus.Enabled = True
        End If

        Close()
        Exit Sub

    End Sub
End Class