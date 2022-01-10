Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_conduces

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_conduces_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDConduce,Conduce.SecondID,Conduce.Fecha,FacturaDatos.NombreFactura,FacturaDatos.SecondID FROM" & SysName.Text & "conduce INNER JOIN" & SysName.Text & "FacturaDatos on Conduce.IDFacturaDatos=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente where IDConduce like '%" + txtBuscar.Text + "%' and Conduce.Nulo=0 ORDER BY IDConduce DESC", ConMixta)
            ElseIf rdbReferencia.Checked = True Then
                cmd = New MySqlCommand("SELECT IDConduce,Conduce.SecondID,Conduce.Fecha,FacturaDatos.NombreFactura,FacturaDatos.SecondID FROM" & SysName.Text & " conduce INNER JOIN" & SysName.Text & "FacturaDatos on Conduce.IDFacturaDatos=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente where Conduce.SecondID like '%" + txtBuscar.Text + "%' and Conduce.Nulo=0 ORDER BY IDConduce DESC", ConMixta)
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
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 90
            .Columns(1).Width = 105
            .Columns(1).HeaderText = "No. Conduce"
            .Columns(2).Width = 80
            .Columns(2).HeaderText = "Fecha"
            .Columns(3).Width = 250
            .Columns(3).HeaderText = "Nombre Cliente"
            .Columns(4).HeaderText = "No. Factura"
            .Columns(4).Width = 105
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
        Dim IDConduce, Nulo As New Label
        IDConduce.Text = DgvConduces.CurrentRow.Cells(0).Value

        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDConduce,Conduce.SecondID as SecondIDConduce,Conduce.IDFacturaDatos,FacturaDatos.SecondID AS SecondIDFactura,Conduce.Fecha,Conduce.Hora,FechaPrometida,Clientes.IDCliente,Nombre,Clientes.BalanceGeneral,Clientes.Direccion,Clientes.TelefonoPersonal,Conduce.IDAlmacen,Almacen.Almacen,Conduce.IDSucursal,Entregado,Conduce.Observacion,FacturaDatos.Fecha as FechaFactura,Conduce.Nulo,MostrarPrecios FROM" & SysName.Text & "conduce INNER JOIN" & SysName.Text & "FacturaDatos on Conduce.IDFacturaDatos=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "Almacen on Conduce.IDAlmacen=Almacen.IDAlmacen Where IDConduce= '" + IDConduce.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Conduce")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("Conduce")

        If Me.Owner.Name = frm_conduce.Name Then
            frm_conduce.lblIDFactura.Text = (Tabla.Rows(0).Item("IDFacturaDatos"))
            frm_conduce.txtIDFactura.Text = (Tabla.Rows(0).Item("SecondIDFactura"))
            frm_conduce.btnBuscarFactura.PerformClick()

            frm_conduce.txtIDConduce.Text = (Tabla.Rows(0).Item("IDConduce"))
            frm_conduce.txtSecondID.Text = (Tabla.Rows(0).Item("SecondIDConduce"))
            frm_conduce.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_conduce.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_conduce.dtpFechaPrometida.Text = (Tabla.Rows(0).Item("FechaPrometida"))
            frm_conduce.cbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))

            frm_conduce.txtObservacion.Text = (Tabla.Rows(0).Item("Observacion"))
            frm_conduce.txtEntregadoPor.Text = (Tabla.Rows(0).Item("Entregado"))
            frm_conduce.chkNulo.Tag = (Tabla.Rows(0).Item("Nulo"))
            frm_conduce.chkMostrarPrecios.Tag = Tabla.Rows(0).Item("MostrarPrecios")

            If Tabla.Rows(0).Item("MostrarPrecios") = 0 Then
                frm_conduce.chkMostrarPrecios.Checked = False
            Else
                frm_conduce.chkMostrarPrecios.Checked = True
            End If

            frm_conduce.RefrescarTablaArticulos()
            frm_conduce.BuscarDevoluciones()
            frm_conduce.SumTotal()
        End If

        Close()

    End Sub

End Class