Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_pedidos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_pedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDPedido,Fecha,Nombre,Pedidos.Referencia,Total FROM" & SysName.Text & "Pedidos INNER JOIN Libregco.Clientes on Pedidos.IDCliente=Clientes.IDCliente where IDPedido like '%" + txtBuscar.Text + "%' AND Pedidos.Nulo=0 ORDER BY IDPedido DESC", ConMixta)
            ElseIf rdbReferencia.Checked = True Then
                cmd = New MySqlCommand("SELECT IDPedido,Fecha,Nombre,Pedidos.Referencia,Total FROM" & SysName.Text & "Pedidos INNER JOIN Libregco.Clientes on Pedidos.IDCliente=Clientes.IDCliente where Referencia like '%" + txtBuscar.Text + "%' AND Pedidos.Nulo=0 ORDER BY Referencia ASC", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Pedidos")

            Bs.DataMember = "Pedidos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvPedidos.DataSource = Bs

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
        With DgvPedidos
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 80
            .Columns(1).Width = 80
            .Columns(2).Width = 190
            .Columns(3).Width = 170
            .Columns(4).Width = 110
            .Columns(4).DefaultCellStyle.Format = ("C")
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbReferencia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbReferencia.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvPedidos.Focus()
    End Sub

    Private Sub DgvPedidos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvPedidos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvPedidos.Focus()
        End If
    End Sub

    Private Sub DgvPedidos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvPedidos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvPedidos.ColumnCount
                Dim NumRows As Integer = DgvPedidos.RowCount
                Dim CurCell As DataGridViewCell = DgvPedidos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvPedidos.CurrentCell = DgvPedidos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvPedidos.CurrentCell = DgvPedidos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvPedidos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPedidos.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDPedido, Nulo As New Label
        IDPedido.Text = DgvPedidos.CurrentRow.Cells(0).Value

        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("Select IDPedido,Fecha,Hora,IDUsuario,Pedidos.SecondID,Pedidos.IDCliente,Clientes.Nombre as NombreCliente,BalanceGeneral,Pedidos.Referencia,Comentario,SubTotal,Descuento,Itbis,Total,Pedidos.IDCondicion,Condicion.Condicion,Pedidos.IDVendedor,Empleados.Nombre as NombreVendedor,Pedidos.Nulo,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Pedidos.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible from" & SysName.Text & "Pedidos INNER JOIN Libregco.Clientes on Pedidos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCAlificacion INNER JOIN Libregco.Condicion on Pedidos.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "Empleados on Pedidos.IDVendedor=Empleados.IDEmpleado Where IDPedido = '" + IDPedido.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Pedido")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("Pedido")

        If Me.Owner.Name = frm_pedidos.Name Then
            frm_pedidos.txtIDPedido.Text = (Tabla.Rows(0).Item("IDPedido"))
            frm_pedidos.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_pedidos.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_pedidos.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_pedidos.lblIDUsuario.Text = (Tabla.Rows(0).Item("IDUsuario"))
            frm_pedidos.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
            frm_pedidos.txtNombre.Text = (Tabla.Rows(0).Item("NombreCliente"))
            frm_pedidos.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
            frm_pedidos.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
            frm_pedidos.lblIDCondicion.Text = (Tabla.Rows(0).Item("IDCondicion"))
            frm_pedidos.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
            frm_pedidos.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubTotal")).ToString("C")
            frm_pedidos.txtDescuento.Text = CDbl(Tabla.Rows(0).Item("Descuento")).ToString("C")
            frm_pedidos.txtItbis.Text = CDbl(Tabla.Rows(0).Item("Itbis")).ToString("C")
            frm_pedidos.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Total")).ToString("C")
            frm_pedidos.txtIDVendedor.Text = (Tabla.Rows(0).Item("IDVendedor"))
            frm_pedidos.txtVendedor.Text = (Tabla.Rows(0).Item("NombreVendedor"))
            frm_pedidos.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))
            frm_pedidos.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
            frm_pedidos.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))

            frm_pedidos.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))


            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_pedidos.ChkNulo.Checked = False
            Else
                frm_pedidos.ChkNulo.Checked = True
            End If

            frm_pedidos.RefrescarTablaArticulos()

        End If

        Close()
        Exit Sub
    End Sub
End Class