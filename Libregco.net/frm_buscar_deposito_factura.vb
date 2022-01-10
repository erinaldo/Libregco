Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_deposito_factura
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_deposito_factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT idDepositoFacturas,DepositoFacturas.SecondID,Fecha,DepositoFacturas.IDCliente,Clientes.Nombre FROM" & SysName.Text & "depositofacturas INNER JOIN Libregco.Clientes on DepositoFacturas.IDCliente=Clientes.IDCliente where DepositoFacturas.SecondID like '%" + txtBuscar.Text + "%' ORDER BY IDDepositoFacturas DESC LIMIT 50", ConMixta)
            ElseIf rdbNombre.Checked = True Then
                cmd = New MySqlCommand("SELECT idDepositoFacturas,DepositoFacturas.SecondID,Fecha,DepositoFacturas.IDCliente,Clientes.Nombre FROM" & SysName.Text & "depositofacturas INNER JOIN Libregco.Clientes on DepositoFacturas.IDCliente=Clientes.IDCliente where Clientes.Nombre like '%" + txtBuscar.Text + "%' ORDER BY Clientes.Nombre ASC LIMIT 50", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "DepositoFacturas")

            Bs.DataMember = "DepositoFacturas"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvDepositos.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbNombre.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvDepositos
            DgvDepositos.Columns(0).Visible = False
            DgvDepositos.Columns(1).HeaderText = "Depósito"
            DgvDepositos.Columns(1).Width = 120
            DgvDepositos.Columns(2).Width = 130

            DgvDepositos.Columns(3).HeaderText = "ID"
            DgvDepositos.Columns(3).Width = 80

            DgvDepositos.Columns(4).HeaderText = "Nombre"
            DgvDepositos.Columns(4).Width = 500
        End With
    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNombre.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim IDDeposito As New Label
            IDDeposito.Text = DgvDepositos.CurrentRow.Cells(0).Value

            Dim DsTemp As New DataSet

            DsTemp.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT idDepositoFacturas,DepositoFacturas.SecondID,Fecha,DepositoFacturas.IDCliente,Clientes.Nombre,DepositoFacturas.Descripcion,Clientes.BalanceGeneral,DepositoFacturas.Nulo,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago FROM" & SysName.Text & "depositofacturas  INNER JOIN Libregco.Clientes on DepositoFacturas.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion Where IDDepositoFacturas= '" + IDDeposito.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "DepositoFacturas")
            ConMixta.Close()

            Dim Tabla As DataTable = DsTemp.Tables("DepositoFacturas")

            If Me.Owner.Name = frm_deposito_factura.Name Then
                frm_deposito_factura.btnSustractAll.Enabled = False
                frm_deposito_factura.txtIDDeposito.Text = Tabla.Rows(0).Item("IDDepositoFacturas")
                frm_deposito_factura.txtSecondID.Text = Tabla.Rows(0).Item("SecondID")
                frm_deposito_factura.txtIDCliente.Text = Tabla.Rows(0).Item("IDCliente")
                frm_deposito_factura.txtNombre.Text = Tabla.Rows(0).Item("Nombre")
                frm_deposito_factura.txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                frm_deposito_factura.txtBalanceGeneralCargos.Text = (CDbl(Tabla.Rows(0).Item("BalanceGeneral")) + CDbl(Tabla.Rows(0).Item("CargosCliente"))).ToString("C")
                frm_deposito_factura.txtUltimoPago.Text = Tabla.Rows(0).Item("UltimoPago")
                frm_deposito_factura.txtCalificacion.Text = Tabla.Rows(0).Item("Calificacion")
                frm_deposito_factura.txtDescripcion.Text = Tabla.Rows(0).Item("Descripcion")

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_deposito_factura.ChkNulo.Checked = False
                    frm_deposito_factura.ChkNulo.Tag = 0
                Else
                    frm_deposito_factura.ChkNulo.Checked = True
                    frm_deposito_factura.ChkNulo.Tag = 1
                End If

                frm_deposito_factura.RefrescarTablaFacturas()
                frm_deposito_factura.RefrescarTablaFacturasDepositadas()
                frm_deposito_factura.EliminarFilas()

                Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub DgvDepositos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvDepositos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvDepositos.Focus()
        End If
    End Sub

    Private Sub DgvDepositos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvDepositos.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvDepositos.ColumnCount
                Dim NumRows As Integer = DgvDepositos.RowCount
                Dim CurCell As DataGridViewCell = DgvDepositos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvDepositos.CurrentCell = DgvDepositos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvDepositos.CurrentCell = DgvDepositos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvDepositos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDepositos.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvDepositos.Focus()
    End Sub
End Class