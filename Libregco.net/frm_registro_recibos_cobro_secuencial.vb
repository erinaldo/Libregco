Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_registro_recibos_cobro_secuencial
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet   'Normal Ds
    Dim Ds1 As New DataSet 'CbxFacturas
    Dim Adaptador As MySqlDataAdapter
    Dim lblIDTipoRecibo, lblIDCobradorEntrega, DefaultCobrador, lblIDTipoComision, lblExcedente, lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_registro_recibos_cobro_secuencial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        SetConfiguracion()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        ActualizarTodo()
    End Sub
    Private Sub SetConfiguracion()
        Try
            Con.Open()

            'Cobrador Predeterminado
            cmd = New MySqlCommand("SELECT Value2Int FROM configuracion where IDConfiguracion=25", Con)
            DefaultCobrador.Text = Convert.ToString(cmd.ExecuteScalar())

            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub LimpiarDatos()
        lblFechaEntrega.Text = ""
        lblCobradorEntrega.Text = ""
        lblEfectivo.Text = ""
        lblCambio.Text = ""
        lblCantidadEntrega.Text = ""
        lblRangoEntrega.Text = ""
        lblMonto.Text = ""
        lblComisionEntrega.Text = ""
        cbxNoEntrega.Items.Clear()
        cbxNoRecibo.Items.Clear()
        cbxTipoRecibo.Items.Clear()
        DtpFechaRecibo.Value = Today
        txtFactura.Clear()
        lblCliente.Text = ""
        lblFechaFactura.Text = ""
        lblArticulo.Text = ""
        txtMontoTotal.Clear()
        DgvDetalleRecibos.Rows.Clear()
        lblCantidadPagares.Text = ""
        lblIDEntrega.Text = ""
        lblIDRecibo.Text = ""
        lblIDTipoRecibo.Text = ""
        lblIDCobradorEntrega.Text = ""
        lbldireccion.Text = ""
        lblTelefono.Text = ""
        lblCantidadPagares.Text = ""
        lblFacturaConsultada.Text = ""
        txtComentario.Clear()
        PictureBox1.Image = My.Resources.no_photo
    End Sub

    Private Sub ActualizarTodo()
        DtpFechaRecibo.Value = Today
        txtMontoProcesado.Text = CDbl(0).ToString("C")
        lblExcedente.Text = 0
        lblNulo.Text = 0
        chkNulo.Checked = False
        lblBarCambio.Visible = False
        lblBarEfect.Visible = False
        FillCbxNoEntrega()
        FillTipoRecibo()
    End Sub

    Sub FillCbxNoEntrega()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select NoEntrega from EntregaCobro Where Cierre=0 and Nulo=0 ORDER BY IDEntregaCobro ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "EntregaCobro")
        cbxNoEntrega.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("EntregaCobro")

        For Each Fila As DataRow In Tabla.Rows
            cbxNoEntrega.Items.Add(Fila.Item("NoEntrega"))
        Next

        If cbxNoEntrega.Items.Count = 1 Then
            cbxNoEntrega.SelectedIndex = 0
            cbxNoRecibo.DroppedDown = True
            cbxNoRecibo.Focus()
        End If

    End Sub

    Private Sub cbxNoEntrega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNoEntrega.SelectedIndexChanged
        SetIDEntrega()
        FillRecibos()
    End Sub

    Private Sub SetIDEntrega()
        Con.Open()
        Ds.Clear()
        cmd = New MySqlCommand("SELECT IDEntregaCobro,IDAreaImpresion,AreaImpresion.ComputerName,IDUsuario,Usuarios.Nombre as NombreUsuario,Fecha,Hora,NoEntrega,FechaEntrega,IDCobrador,Cobrador.Nombre as NombreCobrador,Cantidad,NoInicial,NoFinal,Monto,Comision,Descripcion,Cierre,Pagada,EntregaCobro.Nulo,Coalesce((SELECT sum(monto) FROM libregco.reciboscobro where IDTipoRecibo=1 and RecibosCobro.IDEntregaCobro=EntregaCobro.IDEntregaCobro),0) as Efectivo,Coalesce((SELECT sum(monto) FROM libregco.reciboscobro where IDTipoRecibo=2 and RecibosCobro.IDEntregaCobro=EntregaCobro.IDEntregaCobro),0) as Cambio FROM entregacobro INNER JOIN Empleados as Usuarios on EntregaCobro.IDUsuario=Usuarios.IDEmpleado INNER JOIN Empleados as Cobrador on EntregaCobro.IDCobrador=Cobrador.IDEmpleado INNER JOIN AreaImpresion on EntregaCobro.IDAreaImpresion=AreaImpresion.IDEquipo Where NoEntrega='" + cbxNoEntrega.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "RecibosCobro")
        cbxNoRecibo.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("RecibosCobro")

        lblIDEntrega.Text = (Tabla.Rows(0).Item("IDEntregaCobro"))
        lblFechaEntrega.Text = CDate(Tabla.Rows(0).Item("FechaEntrega")).ToString("dd/MM/yyyy")
        lblCobradorEntrega.Text = "[" & (Tabla.Rows(0).Item("IDCobrador")) & "] " & (Tabla.Rows(0).Item("NombreCobrador"))
        lblIDCobradorEntrega.Text = (Tabla.Rows(0).Item("IDCobrador"))
        lblCantidadEntrega.Text = (Tabla.Rows(0).Item("Cantidad"))
        lblRangoEntrega.Text = (Tabla.Rows(0).Item("NoInicial")) & " - " & (Tabla.Rows(0).Item("NoFinal"))
        lblComisionEntrega.Text = CDbl(Tabla.Rows(0).Item("Comision")).ToString("C")
        lblMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")

        If CDbl(Tabla.Rows(0).Item("Monto")) > 0 Then
            lblBarCambio.Visible = True
            lblBarEfect.Visible = True
            lblBarEfect.Location = New Point(942, 3)
            lblBarCambio.Location = New Point(996, 3)
            lblEfectivo.Text = CDbl(Tabla.Rows(0).Item("Efectivo")).ToString("C")
            lblCambio.Text = CDbl(Tabla.Rows(0).Item("Cambio")).ToString("C")
            lblEfectivoPorc.Text = (CDbl(Tabla.Rows(0).Item("Efectivo")) / CDbl(Tabla.Rows(0).Item("Monto"))).ToString("P2")
            lblCambioPorc.Text = (CDbl(Tabla.Rows(0).Item("Cambio")) / CDbl(Tabla.Rows(0).Item("Monto"))).ToString("P2")
            lblBarEfect.Size = New Size(10, 45 * (CDbl(Tabla.Rows(0).Item("Efectivo")) / CDbl(Tabla.Rows(0).Item("Monto"))))
            lblBarCambio.Size = New Size(10, 45 * (CDbl(Tabla.Rows(0).Item("Cambio")) / CDbl(Tabla.Rows(0).Item("Monto"))))
        Else
            lblBarCambio.Visible = False
            lblBarEfect.Visible = False
            lblEfectivo.Text = ""
            lblCambio.Text = ""
            lblEfectivoPorc.Text = ""
            lblCambioPorc.Text = ""
            lblBarEfect.Size = New Size(10, 0)
            lblBarCambio.Size = New Size(10, 0)
        End If

        If cbxNoEntrega.Text <> "" Then
            If cbxNoEntrega.Text <> "1" Then
                For Each rw As DataGridViewRow In DgvDetalleRecibos.Rows
                    If rw.Cells(6).Value = lblIDCobradorEntrega.Text Then
                        rw.DefaultCellStyle.BackColor = SystemColors.Info
                    Else
                        rw.DefaultCellStyle.BackColor = Color.White
                    End If
                    If CDate(rw.Cells(3).Value) < Today Then
                        rw.Cells(3).Style.ForeColor = Color.Red
                    Else
                        rw.Cells(3).Style.ForeColor = Color.Black
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub FillRecibos()
        Con.Open()
        Ds.Clear()
        cmd = New MySqlCommand("Select Concat(PreRecibo,'-',NoRecibo) as Recibo from RecibosCobro Where IDEntregaCobro='" + lblIDEntrega.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "RecibosCobro")
        cbxNoRecibo.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("RecibosCobro")
        For Each Fila As DataRow In Tabla.Rows
            cbxNoRecibo.Items.Add(Fila.Item("Recibo"))
        Next

        If cbxNoRecibo.Items.Count = 1 Then
            cbxNoRecibo.SelectedIndex = 0
            cbxTipoRecibo.Focus()
        End If
    End Sub

    Private Sub cbxNoRecibo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNoRecibo.SelectedIndexChanged
        SetIDNoRecibo()
        BuscarRegistrosDetalle()
    End Sub

    Private Sub SetIDNoRecibo()
        Dim Nulo As String

        If cbxNoRecibo.Text <> "" Then
            Con.Open()
            cmd = New MySqlCommand("SELECT IDReciboCobro FROM RecibosCobro WHERE Concat(PreRecibo,'-',NoRecibo)= '" + cbxNoRecibo.Text + "'", Con)
            lblIDRecibo.Text = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT Monto FROM RecibosCobro WHERE Concat(PreRecibo,'-',NoRecibo)= '" + cbxNoRecibo.Text + "'", Con)
            txtMontoTotal.Text = Convert.ToDouble(cmd.ExecuteScalar()).ToString("C")

            cmd = New MySqlCommand("SELECT Nulo FROM RecibosCobro WHERE Concat(PreRecibo,'-',NoRecibo)= '" + cbxNoRecibo.Text + "'", Con)
            Nulo = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()
        End If


    End Sub

    Private Sub FillTipoRecibo()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select Descripcion from TipoRecibos Where Nulo=0 ORDER BY IDTipoRecibo ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoRecibo")
        cbxTipoRecibo.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoRecibo")

        cbxTipoRecibo.Items.Clear()

        For Each Fila As DataRow In Tabla.Rows
            cbxTipoRecibo.Items.Add(Fila.Item("Descripcion"))
        Next

    End Sub

    Private Sub SetIDTipoRecibo()
        If Con.State = 1 Then
            Con.Close()
        End If

        Con.Open()
        cmd = New MySqlCommand("SELECT IDTipoRecibo FROM TipoRecibos WHERE Descripcion= '" + cbxTipoRecibo.Text + "'", Con)
        lblIDTipoRecibo.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub BuscarRegistrosDetalle()
        Try

            Dim Dstemp As New DataSet

            Con.Open()
            Dstemp.Clear()
            cmd = New MySqlCommand("SELECT RecibosDetalle.IDDetalleRecibo,RecibosDetalle.IDPagare,concat(nopagare,'/',cantidad) as Cantidad,pagares.fechavencimiento,Pagares.DiasVencidos,StatusPagare.Descripcion as StatusPagare,Pagares.IDEmpleado,Cobrador.Nombre as NombreCobrador,Pagares.Monto,Pagares.Balance,RecibosDetalle.Debito,RecibosDetalle.Descuento,RecibosDetalle.IDComision,ComisionCobro.Descripcion as ComisionCobro,RecibosDetalle.Comision,IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.IDCliente,NombreFactura,DireccionFactura,TelefonosFactura,FacturaDatos.Fecha,(SELECT (Select Group_Concat(Descripcion) from Libregco.FacturaArticulos Where FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos)) as Articulos,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,RecibosCobro.Fecha as FechaRecibo,RecibosCobro.IDTipoRecibo,TipoRecibos.Descripcion as TipoRecibo,RecibosCobro.Comentario,RecibosCobro.Monto AS MontoProcesado FROM libregco.RecibosDetalle INNER JOIN Libregco.RecibosCobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro INNER JOIN Libregco.TipoRecibos on RecibosCobro.IDTipoRecibo=TipoRecibos.IDTipoRecibo INNER JOIN Libregco.Pagares on RecibosDetalle.IDPagare=Pagares.IDPagare INNER JOIN Libregco.StatusPagare on Pagares.IDStatusPagare=StatusPagare.IDStatusPagare INNER JOIN Libregco.Empleados as Cobrador on Pagares.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.ComisionCobro on RecibosDetalle.IDComision=ComisionCobro.IDComisionCobro INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where RecibosDetalle.IDReciboCobro='" + lblIDRecibo.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp, "RecibosCobro")
            Con.Close()

            DgvDetalleRecibos.Rows.Clear()

            Dim Tabla As DataTable = Dstemp.Tables("RecibosCobro")

            If Tabla.Rows.Count > 0 Then

                txtFactura.Text = Tabla.Rows(0).Item("SecondID")
                DtpFechaRecibo.Value = CDate(Tabla.Rows(0).Item("FechaRecibo"))
                cbxTipoRecibo.Text = Tabla.Rows(0).Item("TipoRecibo")
                lblIDTipoRecibo.Text = Tabla.Rows(0).Item("IDTipoRecibo")
                txtMontoProcesado.Text = CDbl(Tabla.Rows(0).Item("MontoProcesado")).ToString("C")
                lblCliente.Text = "[" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("NombreFactura")
                lblFechaFactura.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy")
                lblArticulo.Text = Tabla.Rows(0).Item("Articulos")
                lbldireccion.Text = CStr(Tabla.Rows(0).Item("DireccionFactura")).ToUpper
                lblTelefono.Text = Tabla.Rows(0).Item("TelefonosFactura")
                Label16.Visible = False
                lblFacturaConsultada.Text = ""

                If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                    PictureBox1.Image = My.Resources.no_photo
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                        PictureBox1.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If


                Con.Open()
                Dim Consulta As New MySqlCommand("SELECT IDPagare,concat(nopagare,'/',cantidad),pagares.fechavencimiento,Pagares.DiasVencidos,StatusPagare.Descripcion AS Status,Pagares.IDEmpleado,Cobrador.Nombre as NombreCobrador,Pagares.Monto,Pagares.Balance,0,0,1,'Comisión regular del 10%',0 FROM libregco.pagares INNER JOIN Libregco.StatusPagare on Pagares.IDStatusPagare=StatusPagare.IDStatusPagare  INNER JOIN Libregco.Empleados as Cobrador on Pagares.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos Where FacturaDatos.SecondID='" + txtFactura.Text + "' or FacturaDatos.IDFacturaDatos='" + txtFactura.Text + "' ORDER BY FechaVencimiento ASC", Con)
                Dim LectorRecibosDetalle As MySqlDataReader = Consulta.ExecuteReader

                While LectorRecibosDetalle.Read
                    DgvDetalleRecibos.Rows.Add("", LectorRecibosDetalle.GetValue(0), LectorRecibosDetalle.GetValue(1), CDate(LectorRecibosDetalle.GetValue(2)).ToString("dd/MM/yyyy"), LectorRecibosDetalle.GetValue(3), LectorRecibosDetalle.GetValue(4), LectorRecibosDetalle.GetValue(5), LectorRecibosDetalle.GetValue(6), CDbl(LectorRecibosDetalle.GetValue(7)).ToString("C"), CDbl(LectorRecibosDetalle.GetValue(8)).ToString("C"), CDbl(LectorRecibosDetalle.GetValue(9)).ToString("C"), CDbl(LectorRecibosDetalle.GetValue(10)).ToString("C"), LectorRecibosDetalle.GetValue(11), LectorRecibosDetalle.GetValue(12), CDbl(LectorRecibosDetalle.GetValue(13)).ToString("C"))
                End While
                LectorRecibosDetalle.Close()
                Con.Close()

                For Each rw As DataGridViewRow In DgvDetalleRecibos.Rows
                    For Each row As DataRow In Tabla.Rows
                        If row.Item("IDPagare") = rw.Cells(1).Value Then
                            DgvDetalleRecibos.Rows(rw.Index).SetValues(row.Item("IDDetalleRecibo"), row.Item("IDPagare"), row.Item("Cantidad"), CDate(row.Item("FechaVencimiento")).ToString("dd/MM/yyyy"), row.Item("DiasVencidos"), row.Item("StatusPagare"), row.Item("IDEmpleado"), row.Item("NombreCobrador"), CDbl(row.Item("Monto")).ToString("C"), (CDbl(row.Item("Balance")) + CDbl(row.Item("Debito")) + CDbl(row.Item("Descuento"))).ToString("C"), CDbl(row.Item("Debito")).ToString("C"), CDbl(row.Item("Descuento")).ToString("C"), row.Item("IDComision"), row.Item("ComisionCobro"), CDbl(row.Item("Comision")).ToString("C"))
                        End If
                    Next
                Next

                If cbxNoEntrega.Text <> "" Then
                    If cbxNoEntrega.Text <> "1" Then
                        For Each rw As DataGridViewRow In DgvDetalleRecibos.Rows
                            If rw.Cells(6).Value = lblIDCobradorEntrega.Text Then
                                rw.DefaultCellStyle.BackColor = SystemColors.Info
                            Else
                                rw.DefaultCellStyle.BackColor = Color.White
                            End If
                            If CDate(rw.Cells(3).Value) < Today Then
                                rw.Cells(3).Style.ForeColor = Color.Red
                            Else
                                rw.Cells(3).Style.ForeColor = Color.Black
                            End If
                        Next
                    End If
                End If
                DgvDetalleRecibos.Columns(10).DefaultCellStyle.BackColor = SystemColors.Info
                DgvDetalleRecibos.ClearSelection()

            End If

        Catch ex As Exception
            DtpFechaRecibo.Value = Today
            cbxTipoRecibo.Items.Clear()
            FillTipoRecibo()
            lblIDTipoRecibo.Text = ""
            txtFactura.Text = ""
            txtMontoProcesado.Text = CDbl(0).ToString("C")
            lblCliente.Text = ""
            lbldireccion.Text = ""
            lblTelefono.Text = ""
            lblFechaFactura.Text = ""
            lblArticulo.Text = ""
            lblFacturaConsultada.Text = ""
            Label16.Visible = False
            lblFacturaConsultada.Text = ""
            DgvDetalleRecibos.Rows.Clear()
            PictureBox1.Image = My.Resources.no_photo
        End Try
    End Sub

    Private Sub txtFactura_Leave(sender As Object, e As EventArgs) Handles txtFactura.Leave
        If txtFactura.Text = "" Then
            lblCliente.Text = ""
            lbldireccion.Text = ""
            lblTelefono.Text = ""
            lblFechaFactura.Text = ""
            lblArticulo.Text = ""
            lblFacturaConsultada.Text = ""
            DgvDetalleRecibos.Rows.Clear()
            PictureBox1.Image = My.Resources.no_photo

        Else
            Dim DsTemp As New DataSet

            DsTemp.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.IDCliente,NombreFactura,DireccionFactura,TelefonosFactura,Fecha,(SELECT (Select Group_Concat(Descripcion) from Libregco.FacturaArticulos Where FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos)) as Articulos,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto FROM libregco.facturadatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente where IDFacturaDatos like '%" + txtFactura.Text + "%' or FacturaDatos.SecondID like '%" + txtFactura.Text + "%'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Factura")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("Factura")
            If Tabla.Rows.Count = 0 Then
                lblCliente.Text = ""
                lbldireccion.Text = ""
                lblTelefono.Text = ""
                lblFechaFactura.Text = ""
                lblArticulo.Text = ""
                lblFacturaConsultada.Text = ""
                DgvDetalleRecibos.Rows.Clear()
                PictureBox1.Image = My.Resources.no_photo
                MessageBox.Show("No se encontraron resultados de facturas con el número '" & txtFactura.Text & "' en la base de datos.", "Por favor revise y vuelva escribir el No. de factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                lblCliente.Text = "[" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("NombreFactura")
                lblFechaFactura.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy")
                lblArticulo.Text = Tabla.Rows(0).Item("Articulos")
                lbldireccion.Text = CStr(Tabla.Rows(0).Item("DireccionFactura")).ToUpper
                lblTelefono.Text = Tabla.Rows(0).Item("TelefonosFactura")

                If Tabla.Rows(0).Item("SecondID") <> txtFactura.Text Then
                    Label16.Visible = True
                    lblFacturaConsultada.Text = Tabla.Rows(0).Item("SecondID")
                Else
                    Label16.Visible = False
                    lblFacturaConsultada.Text = ""
                End If


                If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                    PictureBox1.Image = My.Resources.no_photo
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                        PictureBox1.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    Else
                        MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If

                DgvDetalleRecibos.Rows.Clear()
                Con.Open()
                Dim Consulta As New MySqlCommand("SELECT IDPagare,concat(nopagare,'/',cantidad),pagares.fechavencimiento,Pagares.DiasVencidos,StatusPagare.Descripcion AS Status,Pagares.IDEmpleado,Cobrador.Nombre as NombreCobrador,Pagares.Monto,Pagares.Balance,0,0,1,'Comisión regular del 10%',0 FROM libregco.pagares INNER JOIN Libregco.StatusPagare on Pagares.IDStatusPagare=StatusPagare.IDStatusPagare  INNER JOIN Libregco.Empleados as Cobrador on Pagares.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos Where FacturaDatos.SecondID='" + txtFactura.Text + "' or FacturaDatos.IDFacturaDatos='" + txtFactura.Text + "' and Pagares.Balance>0 ORDER BY FechaVencimiento ASC", Con)
                Dim LectorRecibosDetalle As MySqlDataReader = Consulta.ExecuteReader

                While LectorRecibosDetalle.Read
                    DgvDetalleRecibos.Rows.Add("", LectorRecibosDetalle.GetValue(0), LectorRecibosDetalle.GetValue(1), CDate(LectorRecibosDetalle.GetValue(2)).ToString("dd/MM/yyyy"), LectorRecibosDetalle.GetValue(3), LectorRecibosDetalle.GetValue(4), LectorRecibosDetalle.GetValue(5), LectorRecibosDetalle.GetValue(6), CDbl(LectorRecibosDetalle.GetValue(7)).ToString("C"), CDbl(LectorRecibosDetalle.GetValue(8)).ToString("C"), CDbl(LectorRecibosDetalle.GetValue(9)).ToString("C"), CDbl(LectorRecibosDetalle.GetValue(10)).ToString("C"), LectorRecibosDetalle.GetValue(11), LectorRecibosDetalle.GetValue(12), CDbl(LectorRecibosDetalle.GetValue(13)).ToString("C"))
                End While
                LectorRecibosDetalle.Close()
                Con.Close()

                If cbxNoEntrega.Text <> "" Then
                    If cbxNoEntrega.Text <> "1" Then
                        For Each rw As DataGridViewRow In DgvDetalleRecibos.Rows
                            If rw.Cells(6).Value = lblIDCobradorEntrega.Text Then
                                rw.DefaultCellStyle.BackColor = SystemColors.Info
                            Else
                                rw.DefaultCellStyle.BackColor = Color.White
                            End If
                            If CDate(rw.Cells(3).Value) < Today Then
                                rw.Cells(3).Style.ForeColor = Color.Red
                            Else
                                rw.Cells(3).Style.ForeColor = Color.Black
                            End If
                        Next
                    End If
                End If
            End If

            DgvDetalleRecibos.ClearSelection()
            lblCantidadPagares.Text = DgvDetalleRecibos.Rows.Count & " pagaré(s)."
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Try
        If cbxNoEntrega.Text = "" Then
            MessageBox.Show("Seleccione la entrega de recibos de cobros a la que desea anexar el registro.", "Seleccionar No. de entrega", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxNoEntrega.Focus()
            cbxNoEntrega.DroppedDown = True
            Exit Sub
        End If

        Dim DsTemp As New DataSet
        Dim Aplicado As Double = txtMontoTotal.Text
        Dim Comision As Double
        Con.Open()

        For Each row As DataGridViewRow In DgvDetalleRecibos.Rows

            If row.Cells(6).Value = lblIDCobradorEntrega.Text Then
                If Aplicado > CDbl(row.Cells(9).Value) Then
                    row.Cells(10).Value = (CDbl(row.Cells(9).Value) - CDbl(row.Cells(11).Value)).ToString("C")
                ElseIf Aplicado < CDbl(row.Cells(9).Value) Then
                    row.Cells(10).Value = Aplicado.ToString("C")
                ElseIf Aplicado = CDbl(row.Cells(9).Value) Then
                    row.Cells(10).Value = (CDbl(row.Cells(9).Value) - CDbl(row.Cells(11).Value)).ToString("C")
                End If

                Aplicado = Aplicado - CDbl(row.Cells(10).Value)

            Else
                If Aplicado > 0 Then
                    MessageBox.Show("El pagaré " & row.Cells(2).Value & " no está titularizado al cobrador " & lblCobradorEntrega.Text & ".", "No se puede aplicar ingresos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If

            cmd = New MySqlCommand("SELECT Comision FROM libregco.comisioncobro where IDComisionCobro='" + CStr(row.Cells(12).Value).ToString + "'", Con)
            Comision = Convert.ToDouble(cmd.ExecuteScalar())
            row.Cells(14).Value = (CDbl(row.Cells(10).Value) * Comision).ToString("C")
        Next
        Con.Close()


        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub txtMontoTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMontoTotal.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtMontoTotal_Leave(sender As Object, e As EventArgs) Handles txtMontoTotal.Leave
        Try
            If txtMontoTotal.Text = "" Then
                txtMontoTotal.Text = CDbl(0).ToString("C")
            Else
                txtMontoTotal.Text = CDbl(txtMontoTotal.Text).ToString("C")
            End If

        Catch ex As Exception
            txtMontoTotal.Text = CDbl(0).ToString("C")
        End Try
    End Sub

    Private Sub DgvDetalleRecibos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDetalleRecibos.CellValueChanged
        Try
            Dim DsTemp As New DataSet

            Try
                If e.ColumnIndex = 10 Then
                    If CDbl(DgvDetalleRecibos.CurrentRow.Cells(10).Value) + CDbl(DgvDetalleRecibos.CurrentRow.Cells(11).Value) > CDbl(DgvDetalleRecibos.CurrentRow.Cells(9).Value) Then
                        MessageBox.Show("El monto aplicado excede el balance. Verifique el ajuste en el descuento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        DgvDetalleRecibos.CurrentRow.Cells(10).Value = CDbl(0).ToString("C")
                    Else
                        DgvDetalleRecibos.CurrentRow.Cells(10).Value = CDbl(DgvDetalleRecibos.CurrentRow.Cells(10).Value).ToString("C")
                    End If

                End If
            Catch ex As Exception
                DgvDetalleRecibos.CurrentRow.Cells(10).Value = CDbl(0).ToString("C")
            End Try

            Try
                If e.ColumnIndex = 11 Then
                    If CDbl(DgvDetalleRecibos.CurrentRow.Cells(10).Value) + CDbl(DgvDetalleRecibos.CurrentRow.Cells(11).Value) > CDbl(DgvDetalleRecibos.CurrentRow.Cells(9).Value) Then
                        MessageBox.Show("El descuento aplicado excede el balance del pagaré. Verifique el ajuste en el monto aplicado y el descuento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        DgvDetalleRecibos.CurrentRow.Cells(11).Value = CDbl(0).ToString("C")
                    Else
                        DgvDetalleRecibos.CurrentRow.Cells(11).Value = CDbl(DgvDetalleRecibos.CurrentRow.Cells(11).Value).ToString("C")
                    End If

                End If

            Catch ex As Exception
                DgvDetalleRecibos.CurrentRow.Cells(11).Value = CDbl(0).ToString("C")
            End Try

            Try
                If e.ColumnIndex = 12 Then
                    DsTemp.Clear()
                    cmd = New MySqlCommand("SELECT IDComisionCobro,Descripcion,Comision FROM libregco.comisioncobro where IDComisionCobro='" + DgvDetalleRecibos.CurrentRow.Cells(12).Value + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "Comision")
                    Dim Tabla As DataTable = DsTemp.Tables("Comision")

                    If Tabla.Rows.Count = 0 Then
                        DgvDetalleRecibos.CurrentRow.Cells(12).Value = 1
                        DgvDetalleRecibos.CurrentRow.Cells(13).Value = "Comisión regular del 10%"
                    Else
                        DgvDetalleRecibos.CurrentRow.Cells(13).Value = Tabla.Rows(0).Item("Descripcion")
                        DgvDetalleRecibos.CurrentRow.Cells(14).Value = (CDbl(DgvDetalleRecibos.CurrentRow.Cells(10).Value) * CDbl(Tabla.Rows(0).Item("Comision"))).ToString("C")
                    End If


                End If

            Catch ex As Exception
                DgvDetalleRecibos.CurrentRow.Cells(12).Value = 1
                DgvDetalleRecibos.CurrentRow.Cells(13).Value = "Comisión regular del 10%"
                DgvDetalleRecibos.CurrentRow.Cells(14).Value = (CDbl(DgvDetalleRecibos.CurrentRow.Cells(10).Value) * 0.1).ToString("C")

            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvDetalleRecibos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDetalleRecibos.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 10 Or e.ColumnIndex = 11 Or e.ColumnIndex = 12 Then
                DgvDetalleRecibos.EditMode = DataGridViewEditMode.EditOnEnter
            End If
        End If
    End Sub

    Private Sub DgvDetalleRecibos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDetalleRecibos.CellEndEdit
        DgvDetalleRecibos.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvDetalleRecibos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvDetalleRecibos.CurrentCellDirtyStateChanged
        If DgvDetalleRecibos.IsCurrentCellDirty Then
            DgvDetalleRecibos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = DgvDetalleRecibos.CurrentCell.ColumnIndex

        If Columna = 10 Or Columna = 11 Or Columna = 12 Then
            Dim Caracter As Char = e.KeyChar
            Dim Txt As TextBox = CType(sender, TextBox)

            If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") And (Txt.Text.Contains(",") = False) Then

                e.Handled = False
            Else
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub DgvDetalleRecibos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvDetalleRecibos.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)
        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frm_consulta_registro_factura.ShowDialog(Me)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Permisos(1) = 0 Then
            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

       If cbxNoEntrega.Text = "" Then
            MessageBox.Show("Seleccione el No. de Entrega correspondiente al detalle de cobro de la cuenta.", "Seleccione No. Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxNoEntrega.Focus()
            cbxNoEntrega.DroppedDown = True
            Exit Sub
        ElseIf cbxNoRecibo.Text = "" Then
            MessageBox.Show("Seleccione el No. del Recibo para continuar el procedimiento de detalle(s) de cobro.", "Seleccione la No. Recibo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxNoRecibo.Focus()
            cbxNoRecibo.DroppedDown = True
            Exit Sub
        ElseIf cbxTipoRecibo.Text = "" Then
            MessageBox.Show("Seleccione el tipo de recibo de cobro para especificar la naturaleza del pago.", "Seleccione Tipo de Recibo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxTipoRecibo.Focus()
            cbxTipoRecibo.DroppedDown = True
            Exit Sub
        ElseIf CDbl(txtMontoTotal.Text) = 0 Then
            MessageBox.Show("Especifique el monto del recibo de cobro que desea ingresar..", "Ingresar monto del recibo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMontoTotal.Focus()
            Exit Sub
        ElseIf DgvDetalleRecibos.Rows.Count = 0 Then
            MessageBox.Show("Aún no se ha procesado el detalle del cobro. Por favor detalle los pagos a los pagares para continuar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el abono a cuenta al cliente " & vbNewLine & lblCliente.Text & "?" & vbNewLine & "Entrega No. " & cbxNoEntrega.Text & vbNewLine & "Recibo No. " & cbxNoRecibo.Text, "Proceso Detalles de Recibos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            InsertDetalleRecibo()
            UpdateRecibo()
            ActualizarBcePagare()
            UpdateComisionEntrega()
            MessageBox.Show("El proceso ha finalizado exitosamente.", "Finalizado Satisfactoriamente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub


    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Con.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub UpdateComisionEntrega()
        Dim Comision, Debitos As New Label
        Con.Open()
        cmd = New MySqlCommand("Select coalesce(Sum(Comision),0) from RecibosDetalle INNER JOIN RecibosCobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro Where IDEntregaCobro='" + lblIDEntrega.Text + "' AND reciboscobro.Nulo=0", Con)
        Comision.Text = Convert.ToDouble(cmd.ExecuteScalar())
        cmd = New MySqlCommand("Select coalesce(Sum(Debito),0) from RecibosDetalle INNER JOIN RecibosCobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro Where IDEntregaCobro='" + lblIDEntrega.Text + "' AND reciboscobro.Nulo=0", Con)
        Debitos.Text = Convert.ToDouble(cmd.ExecuteScalar())
        Con.Close()

        sqlQ = "UPDATE EntregaCobro SET Comision='" + Comision.Text + "',Monto='" + Debitos.Text + "' WHERE IDEntregaCobro='" + lblIDEntrega.Text + "'"
        GuardarDatos()

    End Sub

    Private Sub InsertDetalleRecibo()
        Try

            For Each row As DataGridViewRow In DgvDetalleRecibos.Rows
                If CStr(row.Cells(0).Value) = "" Then
                    If CDbl(row.Cells(10).Value) + CDbl(row.Cells(11).Value) > 0 Then
                        sqlQ = "INSERT INTO RecibosDetalle (IDReciboCobro,IDPagare,Debito,Descuento,IDComision,Comision) VALUES ('" + lblIDRecibo.Text + "','" + row.Cells(1).Value.ToString + "','" + CDbl(row.Cells(10).Value).ToString + "','" + CDbl(row.Cells(11).Value).ToString + "','" + row.Cells(12).Value.ToString + "','" + CDbl(row.Cells(14).Value).ToString + "') "
                        GuardarDatos()

                        ConMixta.Open()
                        cmd = New MySqlCommand("SELECT IDDetalleRecibo from" & SysName.Text & "recibosdetalle where IDDetalleRecibo= (Select Max(IDDetalleRecibo) from" & SysName.Text & "recibosdetalle)", ConMixta)
                        row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                        ConMixta.Close()
                    End If

                Else
                    If CDbl(row.Cells(10).Value) + CDbl(row.Cells(11).Value) = 0 Then
                        sqlQ = "Delete from RecibosDetalle Where IDDetalleRecibo = '" + row.Cells(0).Value.ToString + "'"
                        GuardarDatos()
                    Else
                        sqlQ = "UPDATE RecibosDetalle SET IDReciboCobro='" + lblIDRecibo.Text + "',IDPagare='" + row.Cells(1).Value.ToString + "',Debito='" + CDbl(row.Cells(10).Value).ToString + "',Descuento='" + CDbl(row.Cells(11).Value).ToString + "',IDComision='" + row.Cells(12).Value.ToString + "',Comision='" + CDbl(row.Cells(14).Value).ToString + "' WHERE IDDetalleRecibo= '" + row.Cells(0).Value.ToString + "'"
                        GuardarDatos()
                    End If
                End If
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UpdateRecibo()
        Try
            Con.Open()
            cmd = New MySqlCommand("SELECT SUM(Debito) FROM libregco.recibosdetalle where IDReciboCobro='" + lblIDRecibo.Text + "'", Con)
            txtMontoProcesado.Text = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()

            sqlQ = "UPDATE RecibosCobro SET IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',Fecha='" + DtpFechaRecibo.Value.ToString("yyyy-MM-dd") + "',IDTipoRecibo='" + lblIDTipoRecibo.Text + "',Monto='" + CDbl(txtMontoProcesado.Text).ToString + "',Comentario='" + txtComentario.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDReciboCobro= '" + lblIDRecibo.Text + "'"
            GuardarDatos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ActualizarBcePagare()
        Try
            Dim x As Integer = 0
            Dim IDPagare, Monto, Debitos, BceAct As New Label

Inicio:
            If x = DgvDetalleRecibos.Rows.Count Then
                GoTo Fin
            End If

            IDPagare.Text = DgvDetalleRecibos.Rows(x).Cells(1).Value

            Con.Open()
            cmd = New MySqlCommand("Select Monto from Pagares where IDPagare='" + IDPagare.Text + "'", Con)
            Monto.Text = Convert.ToDouble(cmd.ExecuteScalar())
            cmd = New MySqlCommand("Select Coalesce(Sum(Debito+Descuento),0) from RecibosDetalle INNER JOIN RecibosCobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro where IDPagare='" + IDPagare.Text + "' and Nulo=0", Con)
            Debitos.Text = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()

            BceAct.Text = CDbl(Monto.Text) - CDbl(Debitos.Text)

            sqlQ = "UPDATE Pagares SET Balance='" + BceAct.Text + "' WHERE IDPagare= '" + IDPagare.Text + "'"
            GuardarDatos()

            x = x + 1
            GoTo Inicio
Fin:
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If cbxNoEntrega.Text = "" Then
            MessageBox.Show("Seleccione el No. de Entrega correspondiente al detalle de cobro de la cuenta.", "Seleccione No. Entrega", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxNoEntrega.Focus()
            cbxNoEntrega.DroppedDown = True
            Exit Sub
        ElseIf cbxNoRecibo.Text = "" Then
            MessageBox.Show("Seleccione el No. del Recibo para continuar el procedimiento de detalle(s) de cobro.", "Seleccione la No. Recibo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxNoRecibo.Focus()
            cbxNoRecibo.DroppedDown = True
            Exit Sub
        ElseIf cbxTipoRecibo.Text = "" Then
            MessageBox.Show("Seleccione el tipo de recibo de cobro para especificar la naturaleza del pago.", "Seleccione Tipo de Recibo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxTipoRecibo.Focus()
            cbxTipoRecibo.DroppedDown = True
            Exit Sub
        ElseIf CDbl(txtMontoTotal.Text) = 0 Then
            MessageBox.Show("Especifique el monto del recibo de cobro que desea ingresar..", "Ingresar monto del recibo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtMontoTotal.Focus()
            Exit Sub
        ElseIf DgvDetalleRecibos.Rows.Count = 0 Then
            MessageBox.Show("Aún no se ha procesado el detalle del cobro. Por favor detalle los pagos a los pagares para continuar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El recibo de cobro No. " & cbxNoRecibo.Text & " del cliente " & lblCliente.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Recibo de Cobro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                UpdateRecibo()
                InsertDetalleRecibo()
                ActualizarBcePagare()
                UpdateComisionEntrega()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf cbxNoRecibo.Text = "" Then
            MessageBox.Show("No hay un registro de recibo de cobro abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el recibo de cobro No. " & cbxNoRecibo.Text & " del cliente " & lblCliente.Text & " del sistema?", "Anular Recibo de Cobro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                UpdateRecibo()
                InsertDetalleRecibo()
                ActualizarBcePagare()
                UpdateComisionEntrega()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        'If Permisos(3) = 0 Then
        '    MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If

        'If txtIDCliente.Text = "" Then
        '    MessageBox.Show("Seleccione un cliente para proceder a su historial de recibos de cobro.", "No se encontró cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '    btnBuscarCliente.PerformClick()
        '    If txtIDCliente.Text <> "" Then
        '        frm_historial_recibos_cliente.ShowDialog(Me)
        '    End If
        'Else
        '    frm_historial_recibos_cliente.ShowDialog(Me)
        'End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        If IsNumeric(lblIDEntrega.Text) Then
            frm_consulta_directa_entrega_cobros.ShowDialog(Me)
        End If

    End Sub

    Private Sub cbxTipoRecibo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoRecibo.SelectedIndexChanged
        If Con.State = 1 Then
            Con.Close()
        End If

        Con.Open()
        cmd = New MySqlCommand("SELECT IDTipoRecibo FROM TipoRecibos WHERE Descripcion= '" + cbxTipoRecibo.Text + "'", Con)
        lblIDTipoRecibo.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub
End Class