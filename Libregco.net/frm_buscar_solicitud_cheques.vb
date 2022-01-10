Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_solicitud_cheques

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_solicitud_cheques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDSolicitudCheque,SolicitudCheques.SecondID,SolicitudCheques.Fecha,CuentasBancarias.NoCuenta,NoCheque,Beneficiario,Neto FROM solicitudcheques INNER JOIN CuentasBancarias on SolicitudCheques.IDCuenta=CuentasBancarias.IDCuenta where IDSolicitudCheque like '%" + txtBuscar.Text + "%' AND solicitudcheques.Nulo=0 ORDER By IDSolicitudCheque DESC LIMIT 50", Con)
            ElseIf rdbReferencia.Checked = True Then
                cmd = New MySqlCommand("SELECT IDSolicitudCheque,SolicitudCheques.SecondID,SolicitudCheques.Fecha,CuentasBancarias.NoCuenta,NoCheque,Beneficiario,Neto FROM solicitudcheques INNER JOIN CuentasBancarias on SolicitudCheques.IDCuenta=CuentasBancarias.IDCuenta where IDSolicitudCheque like '%" + txtBuscar.Text + "%' AND solicitudcheques.Nulo=0 ORDER By IDSolicitudCheque DESC LIMIT 50", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "SolicitudCheque")

            Bs.DataMember = "SolicitudCheque"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvSolicitud.DataSource = Bs

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
        With DgvSolicitud
            .Columns(0).Visible = False

            .Columns(1).Width = 100
            .Columns(1).HeaderText = "Código"

            .Columns(2).Width = 80
            .Columns(2).HeaderText = "Fecha"

            .Columns(3).Width = 120
            .Columns(3).HeaderText = "No. Cuenta"

            .Columns(4).Width = 70
            .Columns(4).HeaderText = "# Ck"

            .Columns(5).Width = 170

            .Columns(6).Width = 100
            .Columns(6).HeaderText = "Neto"
            .Columns(6).DefaultCellStyle.Format = "C"
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
        DgvSolicitud.Focus()
    End Sub

    Private Sub DgvSolicitud_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvSolicitud.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
            DgvSolicitud.Focus()
        End If
    End Sub

    Private Sub DgvSolicitud_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvSolicitud.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvSolicitud.ColumnCount
                Dim NumRows As Integer = DgvSolicitud.RowCount
                Dim CurCell As DataGridViewCell = DgvSolicitud.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvSolicitud.CurrentCell = DgvSolicitud.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvSolicitud.CurrentCell = DgvSolicitud.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvSolicitud_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSolicitud.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDSolicitud, Nulo As New Label
        IDSolicitud.Text = DgvSolicitud.CurrentRow.Cells(0).Value

        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDSolicitudCheque,SolicitudCheques.SecondID,SolicitudCheques.IDTipoDocumento,TipoDocumento.Documento,SolicitudCheques.IDEquipo,AreaImpresion.ComputerName,AreaImpresion.IDAlmacen,Almacen.Almacen,Almacen.IDSucursal,Sucursal.Sucursal,SolicitudCheques.Fecha,SolicitudCheques.Hora,SolicitudCheques.IDUsuario,Usuarios.Nombre as NombreUsuario,SolicitudCheques.IDCuenta,CuentasBancarias.NoCuenta,CuentasBancarias.Titular,CuentasBancarias.Balance as BceCuenta,CuentasBancarias.IDBanco,Bancos.Identidad,NoCheque,FechaPago,IDSuplidor,Beneficiario,Retencion,Monto,MontoLetras,Neto,SolicitudCheques.Observacion,Tipo,SolicitudCheques.Nulo,SolicitudCheques.Estado FROM" & SysName.Text & "solicitudcheques INNER JOIN" & SysName.Text & "TipoDocumento on SolicitudCheques.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "AreaImpresion on SolicitudCheques.IDEquipo=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Empleados as Usuarios on SolicitudCheques.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "CuentasBancarias on SolicitudCheques.IDCuenta=CuentasBancarias.IDCuenta INNER JOIN Libregco.Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco Where IDSolicitudCheque= '" + IDSolicitud.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "SolicitudCheque")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("SolicitudCheque")

        If Me.Owner.Name = frm_solicitud_cheques.Name Then

            If (Tabla.Rows(0).Item("Tipo")) = 0 Then
                frm_solicitud_cheques.rdbCuentasporPagar.Checked = True
                frm_solicitud_cheques.Tipo.Text = (Tabla.Rows(0).Item("Tipo"))
                frm_solicitud_cheques.TabControl1.SelectedIndex = 0
                frm_solicitud_cheques.txtIDSolicitud.Text = (Tabla.Rows(0).Item("IDSolicitudCheque"))
                frm_solicitud_cheques.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_solicitud_cheques.lblIDCuenta.Text = (Tabla.Rows(0).Item("IDCuenta"))
                frm_solicitud_cheques.txtBanco.Text = (Tabla.Rows(0).Item("Identidad"))
                frm_solicitud_cheques.cbxCuenta.Text = (Tabla.Rows(0).Item("NoCuenta"))
                frm_solicitud_cheques.SetIDCuenta()
                frm_solicitud_cheques.txtNoChequeC.Text = (Tabla.Rows(0).Item("NoCheque"))
                frm_solicitud_cheques.txtConcepto.Text = (Tabla.Rows(0).Item("Observacion"))
                frm_solicitud_cheques.txtMontoAplicar.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
                frm_solicitud_cheques.txtDescRet.Text = CDbl(Tabla.Rows(0).Item("Retencion")).ToString("C")
                frm_solicitud_cheques.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Neto")).ToString("C")
                frm_solicitud_cheques.dtpFechaPagoR.Text = (Tabla.Rows(0).Item("FechaPago"))
                frm_solicitud_cheques.dtpFechaPagoR.Value = (Tabla.Rows(0).Item("FechaPago"))
                frm_solicitud_cheques.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_solicitud_cheques.txtBalance.Text = CDbl(Tabla.Rows(0).Item("BceCuenta")).ToString("C")
                frm_solicitud_cheques.lblEstado.Text = Tabla.Rows(0).Item("Estado")
                frm_solicitud_cheques.Hora.Enabled = False

                Dim DsLlenarFormulario As New DataSet
                Dim IDSuplidor As New Label
                IDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))

                DsLlenarFormulario.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("Select IDSuplidor,Suplidor,TipoIdentificacion.Descripcion,TipoIdentificacion.IDTipoIdentificacion,RNC,Suplidor.IDProvincia,Provincias.Provincia,Suplidor.IDMunicipio,Municipios.Municipio,Direccion,Telefono,Fax,Email,Web,Representante,TelefonoRepresentante,Beneficiario,LimiteCredito,Suplidor.IDTipoSuplidor,TipoSuplidor.Descripcion as TipoSuplidor,Suplidor.IDCondicion,Condicion.Condicion,Suplidor.IDNCF,TipoComprobante,Suplidor.IDGasto,TipoGasto.TipoGasto,FechaIngreso,Balance,Desactivar,ifnull((Select Fecha from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Neto from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto,ifnull((Select SecondID from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPagoNumero from Libregco.Suplidor INNER JOIN Libregco.tipoidentificacion on Suplidor.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Libregco.Provincias on Suplidor.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Suplidor.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.TipoSuplidor on Suplidor.IDTipoSuplidor=TipoSuplidor.IDTipoSuplidor INNER JOIN Libregco.Condicion on Suplidor.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "ComprobanteFiscal on Suplidor.IDNCF=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.TipoGasto on Suplidor.IDGasto=TipoGasto.IDGasto Where IDSuplidor= '" + IDSuplidor.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsLlenarFormulario, "Suplidor")
                ConMixta.Close()

                Dim Tablas As DataTable = DsLlenarFormulario.Tables("Suplidor")

                frm_solicitud_cheques.txtIDSuplidor.Text = (Tablas.Rows(0).Item("IDSuplidor"))
                frm_solicitud_cheques.txtNombreSuplidor.Text = (Tablas.Rows(0).Item("Suplidor"))
                frm_solicitud_cheques.txtBalanceSup.Text = CDbl((Tablas.Rows(0).Item("Balance"))).ToString("C")
                frm_solicitud_cheques.txtUltimoPago.Text = (Tablas.Rows(0).Item("UltimoPago"))
                If IsNumeric(Tablas.Rows(0).Item("UltimoMonto")) Then
                    frm_solicitud_cheques.txtUltimoMonto.Text = CDbl(Tablas.Rows(0).Item("UltimoMonto")).ToString("C")
                Else
                    frm_solicitud_cheques.txtUltimoMonto.Text = (Tablas.Rows(0).Item("UltimoMonto"))
                End If

                frm_solicitud_cheques.WriteNumberToText()
                frm_solicitud_cheques.RefrescarSolicitudesDetalle()
            Else
                frm_solicitud_cheques.rdbEgresos.Checked = True
                frm_solicitud_cheques.Tipo.Text = (Tabla.Rows(0).Item("Tipo"))
                frm_solicitud_cheques.TabControl1.SelectedIndex = 1
                frm_solicitud_cheques.txtIDSolicitud.Text = (Tabla.Rows(0).Item("IDSolicitudCheque"))
                frm_solicitud_cheques.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_solicitud_cheques.lblIDCuenta.Text = (Tabla.Rows(0).Item("IDCuenta"))
                frm_solicitud_cheques.txtBancoE.Text = (Tabla.Rows(0).Item("Identidad")) & " --> " & (Tabla.Rows(0).Item("Titular"))
                frm_solicitud_cheques.cbxCuentaE.Text = (Tabla.Rows(0).Item("NoCuenta"))
                frm_solicitud_cheques.SetIDCuenta()
                frm_solicitud_cheques.txtNoChequeE.Text = (Tabla.Rows(0).Item("NoCheque"))
                frm_solicitud_cheques.txtConceptoE.Text = (Tabla.Rows(0).Item("Observacion"))
                frm_solicitud_cheques.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
                frm_solicitud_cheques.dtpFechaPagoE.Text = (Tabla.Rows(0).Item("FechaPago"))
                frm_solicitud_cheques.dtpFechaPagoE.Value = (Tabla.Rows(0).Item("FechaPago"))
                frm_solicitud_cheques.txtBeneficiario.Text = (Tabla.Rows(0).Item("Beneficiario"))
                frm_solicitud_cheques.WriteNumberToText()
                frm_solicitud_cheques.txtBalanceE.Text = CDbl(Tabla.Rows(0).Item("BceCuenta")).ToString("C")
                frm_solicitud_cheques.Hora.Enabled = False
            End If

            frm_solicitud_cheques.ConjuntoSuma()

        End If


        Close()
        Exit Sub
    End Sub

 
End Class