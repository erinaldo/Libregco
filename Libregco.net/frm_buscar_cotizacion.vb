Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_cotizacion

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_cotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarEmpresa()
        'Me.WindowState = CheckWindowState()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCotizacion,Cotizacion.SecondID,NombreCotizacion,Fecha,Comentario,TotalNeto FROM" & SysName.Text & "cotizacion INNER JOIN Libregco.Clientes on Cotizacion.IDCliente=Clientes.IDCliente Where IDCotizacion like '%" + txtBuscar.Text + "%' and Cotizacion.Nulo=0 ORDER BY IDCotizacion DESC", ConMixta)
            ElseIf rdbComentario.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCotizacion,Cotizacion.SecondID,NombreCotizacion,Fecha,Comentario,TotalNeto FROM" & SysName.Text & " cotizacion INNER JOIN Libregco.Clientes on Cotizacion.IDCliente=Clientes.IDCliente Where Comentario like '%" + txtBuscar.Text + "%' and Cotizacion.Nulo=0 ORDER BY IDCotizacion ASC", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Cotizacion")

            Bs.DataMember = "Cotizacion"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvCotizacion.DataSource = Bs

            PropiedadColumnsDgv()

        Catch ex As Exception
        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvCotizacion
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "No. Cotización"
            .Columns(1).Width = 110
            .Columns(2).Width = 200
            .Columns(3).Width = 80
            .Columns(4).Width = 160
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(5).Width = 160
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbComentario_CheckedChanged(sender As Object, e As EventArgs) Handles rdbComentario.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvCotizacion.Focus()
    End Sub

    Private Sub DgvCotizacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvCotizacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvCotizacion.Focus()
        End If
    End Sub

    Private Sub DgvCotizacion_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCotizacion.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvCotizacion.ColumnCount
                Dim NumRows As Integer = DgvCotizacion.RowCount
                Dim CurCell As DataGridViewCell = DgvCotizacion.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvCotizacion.CurrentCell = DgvCotizacion.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvCotizacion.CurrentCell = DgvCotizacion.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvCotizacion_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCotizacion.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDCotizacion, Nulo As New Label
        IDCotizacion.Text = DgvCotizacion.CurrentRow.Cells(0).Value

        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT Cotizacion.IDCotizacion,Cotizacion.SecondID,Cotizacion.IDCliente,NombreCotizacion,DireccionCotizacion,TelefonoCotizacion,Clientes.BalanceGeneral,Clientes.IDCalificacion,Calificacion,Fecha,Hora,Cotizacion.IDCondicion,Condicion.Condicion,IDVendedor,Empleados.Nombre as NombreVendedor,Comentario,SubTotal,Descuento,Itbis,Flete,TotalNeto,Cotizacion.IDMoneda,Cotizacion.Nulo,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Cotizacion.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible FROM" & SysName.Text & "cotizacion INNER JOIN Libregco.Clientes on Cotizacion.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados on Cotizacion.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on Cotizacion.IDCondicion=Condicion.IDCondicion Where IDCotizacion='" + IDCotizacion.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Cotizacion")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("Cotizacion")

        If Me.Owner.Name = frm_cotizacion.Name Then
            frm_cotizacion.txtIDCotizacion.Text = (Tabla.Rows(0).Item("IDCotizacion"))
            frm_cotizacion.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_cotizacion.txtFechaCotizacion.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_cotizacion.txtHoraCotizacion.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_cotizacion.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            frm_cotizacion.txtNombre.Text = Tabla.Rows(0).Item("NombreCotizacion")
            frm_cotizacion.txtDireccion.Text = Tabla.Rows(0).Item("DireccionCotizacion")
            frm_cotizacion.txtTelefonos.Text = Tabla.Rows(0).Item("TelefonoCotizacion")
            frm_cotizacion.txtVendedor.Tag = (Tabla.Rows(0).Item("IDVendedor"))
            frm_cotizacion.txtVendedor.Text = (Tabla.Rows(0).Item("NombreVendedor"))
            frm_cotizacion.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
            frm_cotizacion.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubTotal")).ToString("C")
            frm_cotizacion.TxtDescuento.Text = CDbl(Tabla.Rows(0).Item("Descuento")).ToString("C")
            frm_cotizacion.txtITBIS.Text = CDbl(Tabla.Rows(0).Item("Itbis")).ToString("C")
            frm_cotizacion.txtFlete.Text = CDbl(Tabla.Rows(0).Item("Flete")).ToString("C")
            frm_cotizacion.txtNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
            frm_cotizacion.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
            frm_cotizacion.cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))

            If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                frm_cotizacion.chkNulo.Checked = True
            Else
                frm_cotizacion.chkNulo.Checked = False
            End If

            frm_cotizacion.RefrescarTablaArticulos()
            frm_cotizacion.SumTotales()
        End If

        Close()
        Exit Sub
    End Sub

    
End Class
