Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_devoluciones_compras

    Dim sqlQ As String=""
    Dim cmd, cmd1 As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_devoluciones_compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
        RefrescarDevolucionDetalle()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDDevolucionCompra,DevolucionCompra.SecondID,IDFactura,Compras.SecondID AS SecondIDCompra,DevolucionCompra.Fecha,Descripcion,Devolver,DiasTransaccion FROM" & SysName.Text & "devolucioncompra INNER JOIN Libregco.motivodevolucion on devolucioncompra.IDMotivoDevolucion=motivodevolucion.IDMotivoDevolucion INNER JOIN" & SysName.Text & "Compras on DevolucionCompra.IDFactura=Compras.IDCompra Where IDDevolucionCompra like '%" + txtBuscar.Text + "%' and DevolucionCompra.Nulo=0 ORDER BY IDDevolucionCompra DESC", ConMixta)
            ElseIf rdbFactura.Checked = True Then
                cmd = New MySqlCommand("SELECT IDDevolucionCompra,DevolucionCompra.SecondID,IDFactura,Compras.SecondID AS SecondIDCompra,DevolucionCompra.Fecha,Descripcion,Devolver,DiasTransaccion FROM" & SysName.Text & "devolucioncompra INNER JOIN Libregco.motivodevolucion on devolucioncompra.IDMotivoDevolucion=motivodevolucion.IDMotivoDevolucion INNER JOIN" & SysName.Text & "Compras on DevolucionCompra.IDFactura=Compras.IDCompra Where IDFactura like '%" + txtBuscar.Text + "%' and DevolucionCompra.Nulo=0 ORDER BY IDFactura DESC", ConMixta)
            ElseIf rdbFecha.Checked = True Then
                cmd = New MySqlCommand("SELECT IDDevolucionCompra,DevolucionCompra.SecondID,IDFactura,Compras.SecondID AS SecondIDCompra,DevolucionCompra.Fecha,Descripcion,Devolver,DiasTransaccion FROM" & SysName.Text & " devolucioncompra INNER JOIN Libregco.motivodevolucion on devolucioncompra.IDMotivoDevolucion=motivodevolucion.IDMotivoDevolucion INNER JOIN" & SysName.Text & "Compras on DevolucionCompra.IDFactura=Compras.IDCompra Where Fecha like '%" + txtBuscar.Text + "%' and DevolucionCompra.Nulo=0 ORDER BY Fecha DESC", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "DevolucionCompra")

            Bs.DataMember = "DevolucionCompra"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvDevoluciones.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvDevoluciones
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "No. Devolución"
            .Columns(1).Width = 120
            .Columns(2).Visible = False
            .Columns(3).HeaderText = "No. Compra"
            .Columns(3).Width = 100
            .Columns(4).HeaderText = "Fecha"
            .Columns(4).Width = 80
            .Columns(5).HeaderText = "Mot. de Devolución"
            .Columns(5).Width = 200
            .Columns(6).Width = 125
            .Columns(6).DefaultCellStyle.Format = ("C")
            .Columns(7).HeaderText = "Días Trans."
            .Columns(7).Width = 100
        End With
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub DgvDevoluciones_SelectionChanged(sender As Object, e As EventArgs) Handles DgvDevoluciones.SelectionChanged
        RefrescarDevolucionDetalle()
    End Sub

    Private Sub RefrescarDevolucionDetalle()
        Try
            Dim IDDevolucion As New Label
            IDDevolucion.Text = DgvDevoluciones.CurrentRow.Cells(0).Value

            Ds1.Clear()
            cmd1 = New MySqlCommand("SELECT IDDevolucionCompraDetalle,IDArticulo,Descripcion,Medida,CantDevuelta,PrecioDevuelto FROM" & SysName.Text & "devolucioncompradetalle Where IDDevolucioncompra='" + IDDevolucion.Text + "' ORDER BY IDDevolucioncompraDetalle DESC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd1)
            Adaptador.Fill(Ds1, "devolucioncompradetalle")
            DgvDevDetalle.DataSource = Ds1
            DgvDevDetalle.DataMember = "devolucioncompradetalle"
            PropiedadDgvDetalles()

        Catch ex As Exception
            DgvDevDetalle.DataSource = Nothing
            DgvDevDetalle.Rows.Clear()
        End Try
    End Sub

    Private Sub PropiedadDgvDetalles()
        With DgvDevDetalle
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 90
            .Columns(1).HeaderText = "Cód. Art."
            .Columns(1).Width = 85
            .Columns(2).Width = 250
            .Columns(2).HeaderText = "Descripción"
            .Columns(3).Width = 80
            .Columns(4).HeaderText = "Cant. Dev."
            .Columns(4).Width = 100
            .Columns(5).HeaderText = "Precio Dev."
            .Columns(5).Width = 140
            .Columns(5).DefaultCellStyle.Format = ("C")
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        RefrescarDevolucionDetalle()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbFactura_CheckedChanged(sender As Object, e As EventArgs) Handles rdbFactura.CheckedChanged
        RefrescarTabla()
        RefrescarDevolucionDetalle()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles rdbFecha.CheckedChanged
        RefrescarTabla()
        RefrescarDevolucionDetalle()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
        RefrescarDevolucionDetalle()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvDevoluciones.Focus()
    End Sub

    Private Sub DgvDevolucion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvDevoluciones.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvDevoluciones.Focus()
        End If
    End Sub

    Private Sub DgvDevoluciones_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvDevoluciones.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvDevoluciones.ColumnCount
                Dim NumRows As Integer = DgvDevoluciones.RowCount
                Dim CurCell As DataGridViewCell = DgvDevoluciones.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvDevoluciones.CurrentCell = DgvDevoluciones.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvDevoluciones.CurrentCell = DgvDevoluciones.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvDevoluciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDevoluciones.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                LlenarFormularios()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Dim IDDevolucion As New Label
        IDDevolucion.Text = DgvDevoluciones.CurrentRow.Cells(0).Value

        Try
            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select IDDevolucionCompra,DevolucionCompra.SecondID,IDUsuario,Fecha,Hora,IDFactura,NCF,DevolverItbis,Devolver,DiasTransaccion,DevolucionCompra.IDMotivoDevolucion,MotivoDevolucion.Descripcion,DevolucionCompra.Nulo from" & SysName.Text & "DevolucionCompra INNER JOIN Libregco.motivodevolucion on DevolucionCompra.IDMotivoDevolucion=MotivoDevolucion.IDMotivoDevolucion Where IDDevolucionCompra='" + IDDevolucion.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "DevolucionCompra")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("DevolucionCompra")

            If Me.Owner.Name = frm_devolucion_compras.Name Then
                frm_devolucion_compras.txtFactura.Text = (Tabla.Rows(0).Item("IDFactura"))
                frm_devolucion_compras.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_devolucion_compras.txtIDDevolucion.Text = (Tabla.Rows(0).Item("IDDevolucionCompra"))
                frm_devolucion_compras.FillDgvArticulos()
                frm_devolucion_compras.txtIDMotivoDevolucion.Text = (Tabla.Rows(0).Item("IDMotivoDevolucion"))
                frm_devolucion_compras.txtMontoDevolver.Text = CDbl(Tabla.Rows(0).Item("Devolver")).ToString("C")
                frm_devolucion_compras.txtMotivoDevolucion.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_devolucion_compras.txtNCFDev.Text = (Tabla.Rows(0).Item("NCF"))
                frm_devolucion_compras.BuscarDevolucionProcesada()
                frm_devolucion_compras.FillChkDevolucion()
                frm_devolucion_compras.FactStatus()
            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class