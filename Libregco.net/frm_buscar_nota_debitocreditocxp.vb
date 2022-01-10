Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_nota_debitocreditocxp

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_nota_debitocreditocxp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDNotaDebitoCreditoCXP,SecondID,TipoDocumento.Documento,Fecha,NotaDebitoCreditoCxp.IDSuplidor,Suplidor.Suplidor,Concepto,Neto FROM" & SysName.Text & "notadebitocreditocxp INNER JOIN" & SysName.Text & "TipoDocumento on NotaDebitoCreditoCxp.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Suplidor on NotaDebitoCreditoCxP.IDSuplidor=Suplidor.IDSuplidor where SecondID like '%" + txtBuscar.Text + "%' AND NotaDebitoCreditoCXP.Nulo=0 ORDER By IDNotaDebitoCreditoCXP DESC LIMIT 50", ConMixta)
            ElseIf rdbReferencia.Checked = True Then
                cmd = New MySqlCommand("SELECT IDNotaDebitoCreditoCXP,SecondID,TipoDocumento.Documento,Fecha,NotaDebitoCreditoCxp.IDSuplidor,Suplidor.Suplidor,Concepto,Neto FROM" & SysName.Text & " notadebitocreditocxp INNER JOIN" & SysName.Text & "TipoDocumento on NotaDebitoCreditoCxp.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Suplidor on NotaDebitoCreditoCxP.IDSuplidor=Suplidor.IDSuplidor where Concepto like '%" + txtBuscar.Text + "%' AND NotaDebitoCreditoCXP.Nulo=0 ORDER By IDNotaDebCred DESC LIMIT 50", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Nota")

            Bs.DataMember = "Nota"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvNotas.DataSource = Bs

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
        With DgvNotas
            .Columns(0).Visible = False
            .Columns(1).Width = 90
            .Columns(1).HeaderText = "Código"
            .Columns(2).Width = 150
            .Columns(2).HeaderText = "Tipo de Nota"

            .Columns(3).Width = 70
            .Columns(4).Width = 70
            .Columns(4).HeaderText = "ID Sup."
            .Columns(5).Width = 240
            .Columns(6).Visible = False
            .Columns(7).DefaultCellStyle.Format = ("C")
            .Columns(7).Width = 110
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
        DgvNotas.Focus()
    End Sub

    Private Sub DgvNotas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvNotas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvNotas.Focus()
        End If
    End Sub

    Private Sub DgvNotas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvNotas.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvNotas.ColumnCount
                Dim NumRows As Integer = DgvNotas.RowCount
                Dim CurCell As DataGridViewCell = DgvNotas.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvNotas.CurrentCell = DgvNotas.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvNotas.CurrentCell = DgvNotas.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvNotas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNotas.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDNota, Nulo As New Label
        IDNota.Text = DgvNotas.CurrentRow.Cells(0).Value

        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDNotaDebitoCreditoCXP,SecondID,NotaDebitoCreditoCXP.IDTipoDocumento,TipoDocumento.Documento,IDUsuario,Usuarios.Nombre as NombreUsuario,NotaDebitoCreditoCXP.IDSucursal,Sucursal.Sucursal,NotaDebitoCreditoCXP.IDAlmacen,Almacen.Almacen,NotaDebitoCreditoCXP.IDSuplidor,Suplidor.Suplidor,Suplidor.Balance,NotaDebitoCreditoCXP.IDNCF,ComprobanteFiscal.TipoComprobante,NotaDebitoCreditoCXP.Fecha,NotaDebitoCreditoCXP.Hora,NCF,Concepto,NotaDebitoCreditoCXP.SubTotal,NotaDebitoCreditoCXP.Itbis,NotaDebitoCreditoCXP.Neto,NotaDebitoCreditoCXP.Nulo,ifnull((Select Fecha from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Neto from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto,ifnull((Select SecondID from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPagoNumero FROM" & SysName.Text & "notadebitocreditocxp INNER JOIN" & SysName.Text & "TipoDocumento on NotaDebitoCreditoCXP.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Empleados as Usuarios on NotaDebitoCreditoCXP.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Sucursal on NotaDebitoCreditoCXP.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on NotaDebitoCreditoCXP.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Suplidor on NotaDebitoCreditoCXP.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & "ComprobanteFiscal on NotaDebitoCreditoCXP.IDNCF=ComprobanteFiscal.IDComprobanteFiscal Where IDNotaDebitoCreditoCXP= '" + IDNota.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Nota")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("Nota")

        If Me.Owner.Name = frm_nota_debito_credito_cxp.Name Then
            frm_nota_debito_credito_cxp.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
            frm_nota_debito_credito_cxp.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
            frm_nota_debito_credito_cxp.txtBalanceSup.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
            frm_nota_debito_credito_cxp.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
            frm_nota_debito_credito_cxp.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
            frm_nota_debito_credito_cxp.txtConcepto.Text = (Tabla.Rows(0).Item("Concepto"))
            frm_nota_debito_credito_cxp.txtNoNcf.Text = (Tabla.Rows(0).Item("NCF"))
            frm_nota_debito_credito_cxp.txtIDNota.Text = (Tabla.Rows(0).Item("IDNotaDebitoCreditoCXP"))
            frm_nota_debito_credito_cxp.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            frm_nota_debito_credito_cxp.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            frm_nota_debito_credito_cxp.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            frm_nota_debito_credito_cxp.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubTotal")).ToString("C")
            frm_nota_debito_credito_cxp.txtItbis.Text = CDbl(Tabla.Rows(0).Item("Itbis")).ToString("C")
            frm_nota_debito_credito_cxp.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Neto")).ToString("C")
            frm_nota_debito_credito_cxp.lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))
            frm_nota_debito_credito_cxp.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                frm_nota_debito_credito_cxp.ChkNulo.Checked = False
            Else
                frm_nota_debito_credito_cxp.ChkNulo.Checked = True
            End If

            frm_nota_debito_credito_cxp.RefrescarTablaNotaCXP()
        End If


        Close()
        Exit Sub
    End Sub


End Class