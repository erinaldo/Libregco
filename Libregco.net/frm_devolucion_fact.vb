Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_devolucion_fact

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDUsuario, lblIDFactura, lblTipoDevolucion, lblNoNCF, lblNetoFactura, txtBalanceFact As New Label
    Dim PermitirDevolucionMas30 As String
    Dim Permisos As New ArrayList

    Private Sub frm_devolucion_fact_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SetConfiguracion
        SelectUsuario()
        LimpiarDatos()
        ActualizarTodo()
        ColumnsDgvArticulos()
    End Sub

    Private Sub SetConfiguracion()
        Try
            Con.Open()

            'Permitir devolucion facturas con mas de 30 dias
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=177", Con)
            PermitirDevolucionMas30 = Convert.ToString(Convert.ToInt16(cmd.ExecuteScalar()))

            Con.Close()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CargarLibregco()
       PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub ColumnsDgvArticulos()
        DgvArticulos.Columns.Clear()
        With DgvArticulos
            .Columns.Add("IDDevolucionVentaDetalle", "IDDevolucionDetalle") '0
            .Columns.Add("IDDevolucion", "IDDevolucion")    '1
            .Columns.Add("IDPrecio", "IDPrecio")    '2
            .Columns.Add("IDFacturaArt", "IDFacturaArt") '3
            .Columns.Add("IDFactura", "IDFactura")  '4
            .Columns.Add("IDArticulo", "Código")    '5
            .Columns.Add("Descripcion", "Descripción")    '6
            .Columns.Add("IDMedida", "IDMedida")    '7
            .Columns.Add("Medida", "Medida")    '8
            .Columns.Add("Cantidad", "Cant. Vend.")    '9
            .Columns.Add("PrecioUnitario", "Precio Venta")    '10
            .Columns.Add("Itbis", "Itbis")  '11
            .Columns.Add("CantidadDev", "Cant. Dev.")   '12
            .Columns.Add("PrecioDev", "Precio Devolución")    '13
            .Columns.Add("IDAlmacen", "Almacén") '14

            PropiedadDgvArticulos()
        End With
    End Sub

    Private Sub PropiedadDgvArticulos()
        Dim DatagridWith As Double = (DgvArticulos.Width - DgvArticulos.RowHeadersWidth) / 100

        With DgvArticulos
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Width = DatagridWith * 10
            .Columns(5).ReadOnly = True
            .Columns(6).Width = DatagridWith * 30
            .Columns(6).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .Columns(6).ReadOnly = True
            .Columns(7).Visible = False
            .Columns(8).Width = DatagridWith * 10
            .Columns(8).ReadOnly = True
            .Columns(9).Width = DatagridWith * 10
            .Columns(9).ReadOnly = True
            .Columns(10).DefaultCellStyle.Format = ("C")
            .Columns(10).Width = DatagridWith * 10
            .Columns(10).ReadOnly = True
            .Columns(11).Visible = False
            .Columns(12).Width = DatagridWith * 10
            .Columns(13).Width = DatagridWith * 10
            .Columns(13).DefaultCellStyle.Format = ("C")
            .Columns(14).HeaderText = "Almacén"
            .Columns(14).Width = DatagridWith * 10
            .Columns(14).ReadOnly = True
        End With
    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtSecondID.Clear()
        txtNombre.Clear()
        txtIDDevolucion.Clear()
        txtFactura.Clear()
        txtFechaFactura.Clear()
        txtDias.Clear()
        txtMotivoDevolucion.Clear()
        txtCondicion.Clear()
        txtComprobante.Clear()
        txtVendedor.Clear()
        txtItbis.Clear()
        txtMontoDevolucion.Clear()
        txtBalanceFact.Text = ""
        txtTotal.Clear()
        txtSubtotal.Clear()
        txtIDMotivoDevolucion.Clear()
        DgvArticulos.Rows.Clear()
    End Sub

    Private Sub ActualizarTodo()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        ChkDevolverItbis.Checked = False
        ChkDevolverItbis.Enabled = True
        chkNulo.Checked = False
        ChkGenerarNCF.Checked = False
        ControlSuperClave = 0
        lblTipoDevolucion.Text = 3
        rdbVoucher.Checked = False
        lblNetoFactura.Text = 0
        ChkDevolverItbis.Tag = 0
        chkNulo.Tag = 0
        ChkGenerarNCF.Tag = 0
        lblNoNCF.Text = ""
        lblStatusBar.Text = "Listo"
        txtBalanceFact.Text = 0
        lblStatusBar.ForeColor = Color.Black
        rdbDevCredito.Visible = False
        rdbDevEfectivo.Visible = True
        rdbVoucher.Visible = True
        FillAlmacen()
        FactStatus()
        HabilitarControles()
        txtFactura.Focus()
    End Sub

    Private Sub FillAlmacen()

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Almacen FROM Almacen INNER JOIN Empleados on Almacen.IDAlmacen=Empleados.IDAlmacen Where IDEmpleado='" + lblIDUsuario.Text + "' ORDER BY Almacen.Almacen ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Almacen")
        cbxAlmacen.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Almacen")

        For Each Fila As DataRow In Tabla.Rows
            cbxAlmacen.Items.Add(Fila.Item("Almacen"))
        Next

        If Tabla.Rows.Count > 0 Then
            cbxAlmacen.SelectedIndex = 0
        Else
            MessageBox.Show("No se detectaron almacenes disponibles. Esto se puede deber a que no se encuentra un usuario definido en el formulario o porque no se encontraron almacenes en la base de datos." & vbNewLine & vbNewLine & "Por favor revise las condiciones o el sistema generará errores en la facturación.", "Sé detectó un fallo crítico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub SetIDAlmacen()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + cbxAlmacen.SelectedItem + "'", Con)
        cbxAlmacen.Tag = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub
    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub RefrescarDgvArticulos()
        Try
            DgvArticulos.Rows.Clear()
            Con.Open()
            Dim Cmd As New MySqlCommand("Select IDPrecio,IDFactArt,FacturaArticulos.IDFactura,FacturaArticulos.IDArticulo,FacturaArticulos.Descripcion,FacturaArticulos.IDMedida,FacturaArticulos.Medida,FacturaArticulos.Cantidad,FacturaArticulos.PrecioUnitario,FacturaArticulos.Itbis,FacturaArticulos.IDAlmacen,FacturaArticulos.Importe from FacturaArticulos INNER JOIN FacturaDatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos Where FacturaDatos.SecondID='" + txtFactura.Text + "'", Con)
            Dim LectorArticulos As MySqlDataReader = Cmd.ExecuteReader

            While LectorArticulos.Read
                DgvArticulos.Rows.Add("", "", LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), (CDbl(LectorArticulos.GetValue(11)) / CDbl(LectorArticulos.GetValue(7))).ToString("C"), (CDbl(LectorArticulos.GetValue(9)).ToString("C")), "0", (CDbl(LectorArticulos.GetValue(11)) / CDbl(LectorArticulos.GetValue(7))).ToString("C"), LectorArticulos.GetValue(10))
            End While

            Con.Close()
            LectorArticulos.Close()
            PropiedadDgvArticulos()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnBuscarFactura_Click(sender As Object, e As EventArgs) Handles btnBuscarFactura.Click
        Try
            If txtFactura.Text = "" Then
                Dim Intentos As Integer = 0
                MessageBox.Show("Escriba el número de la factura en la que desea generar la devolución.", "No. de factura vacío", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                If frm_consulta_ventas.Visible = True Then
                    frm_consulta_ventas.Close()
                End If

                frm_consulta_ventas.ShowDialog(Me)

                    If Intentos < 2 Then
                        If txtFactura.Text <> "" Then
                            Intentos += 1
                            btnBuscarFactura.PerformClick()
                        End If
                    End If

                Else
                    Con.Open()

                cmd = New MySqlCommand("Select IDFacturaDatos from FacturaDatos Where SecondID='" + txtFactura.Text + "'", Con)
                lblIDFactura.Text = Convert.ToString(cmd.ExecuteScalar())

                If lblIDFactura.Text = "" Then
                    MessageBox.Show("No se encontró ningun resultado en la búsqueda.", "No existe factura con esa numeración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Con.Close()
                    Exit Sub
                Else
                    cmd = New MySqlCommand("Select IDSucursal from FacturaDatos Where FacturaDatos.SecondID='" + txtFactura.Text + "'", Con)
                    Dim IDSucursal As String = Convert.ToString(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=47", Con)
                    Dim PermitirDevCSucursal As String = Convert.ToString(cmd.ExecuteScalar())

                    If PermitirDevCSucursal = 0 Then
                        If IDSucursal <> DtEmpleado.Rows(0).item("IDSucursal").ToString() Then
                            MessageBox.Show("El número de factura ingresada corresponde a otra sucursal." & vbNewLine & vbNewLine & "El sistema tiene bloqueada la recepción de devoluciones de ventas en sucursales distintas.", "Sucursales distintas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Con.Close()
                            Exit Sub
                        End If
                    Else
                        If IDSucursal <> DtEmpleado.Rows(0).item("IDSucursal").ToString() Then
                            MessageBox.Show("Está procesando una devolución de venta sobre una factura emitida en otra sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    End If
                End If

                Con.Close()

                BuscarDatosdeFactura()
                RefrescarDgvArticulos()
                BuscarDevoluciones()
                FactStatus()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarDevoluciones()

        Try
            Dim x As Integer = 0
            Dim IDArticulo, IDDevolucionVenta, CantDevuelta As New Label

Inicio:
            If x = DgvArticulos.Rows.Count Then
                GoTo Fin
            End If

            IDDevolucionVenta.Text = DgvArticulos.Rows(x).Cells(1).Value
            IDArticulo.Text = DgvArticulos.Rows(x).Cells(5).Value
            CantDevuelta.Text = DgvArticulos.Rows(x).Cells(9).Value

            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDFactura,IDArticulo,CantDevuelta FROM devolucionventadetalle INNER JOIN DevolucionVenta on devolucionventadetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta INNER JOIN FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos Where FacturaDatos.SecondID='" + txtFactura.Text + "' and IDArticulo='" + IDArticulo.Text + "' and DevolucionVenta.Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Devolucionventadetalle")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Devolucionventadetalle")
            Dim ContarFilas As Integer = Tabla.Rows.Count

            If ContarFilas = 0 Then
                x = x + 1
                GoTo Inicio
            Else
                CantDevuelta.Text = Tabla.Compute("Sum(CantDevuelta)", "")
                DgvArticulos.Rows(x).Cells(9).Value = CDbl(DgvArticulos.Rows(x).Cells(9).Value) - CDbl(CantDevuelta.Text)
                lblStatusBar.Text = "La Factura No." & txtFactura.Text.ToUpper & " tiene devoluciones."
                lblStatusBar.ForeColor = Color.Red
            End If

            x = x + 1
            GoTo Inicio
Fin:

            If txtIDDevolucion.Text = "" Then
                If txtMontoDevolucion.Text <> "" Then
                    If CDbl(txtMontoDevolucion.Text) > 0 Then
                        If CDbl(txtBalanceFact.Text) >= CDbl(txtMontoDevolucion.Text) Then
                            rdbDevCredito.Visible = True
                            rdbDevCredito.Checked = True
                        Else
                            rdbDevCredito.Visible = False
                            rdbVoucher.Checked = True
                        End If

                        'Else

                        '    rdbDevCredito.Visible = False
                        '    rdbDevCredito.Checked = False

                    End If
                End If
            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub UpdateNCFModificado()
        sqlQ = "UPDATE FacturaDatos SET NCFModificado='" + NewNCFValue.Text + "' WHERE IDFacturaDatos= (" + lblIDFactura.Text + ")"
        GuardarDatos()
    End Sub


    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=13", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE DevolucionVenta SET SecondID='" + lblSecondID.Text + "' WHERE IDDevolucionVenta='" + txtIDDevolucion.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=13"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Sub BuscarDatosdeFactura()
        Try
            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select FacturaDatos.IDCliente,FacturaDatos.NombreFactura,BalanceGeneral,Calificacion,Vendedor.Nombre as Vendedor,Usuarios.Nombre as Usuario,FacturaDatos.IDCondicion,Condicion.Condicion,Condicion.Dias,FacturaDatos.IDComprobanteFiscal,TipoComprobante,NCF,Fecha,FacturaDatos.Balance,NetoFactura,FacturaDatos.Nulo from" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Usuarios on FacturaDatos.IDUsuario=Usuarios.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "comprobantefiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal Where FacturaDatos.IDFacturaDatos='" + lblIDFactura.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "FacturaDatos")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("FacturaDatos")

            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron resultados.", "No se encontró", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                txtNombre.Text = (Tabla.Rows(0).Item("NombreFactura"))
                txtVendedor.Text = "Vendedor: " & (Tabla.Rows(0).Item("Vendedor"))
                txtCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                txtComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                txtFechaFactura.Text = (Tabla.Rows(0).Item("Fecha"))
                txtDias.Text = DateDiff(DateInterval.Day, CDate(txtFechaFactura.Text), Today)
                lblNetoFactura.Text = Tabla.Rows(0).Item("NetoFactura")
                txtBalanceFact.Text = Tabla.Rows(0).Item("Balance")

                If CDbl(txtDias.Text) >= 30 Then
                    If PermitirDevolucionMas30 = 0 Then
                        ChkDevolverItbis.Checked = False
                        ChkDevolverItbis.Enabled = False
                    Else
                        ChkDevolverItbis.Checked = False
                        ChkDevolverItbis.Enabled = True
                    End If

                Else
                    ChkDevolverItbis.Checked = True
                    ChkDevolverItbis.Enabled = True
                End If

                If CDbl(Tabla.Rows(0).Item("Dias")) = 0 Then
                    rdbDevEfectivo.Visible = False
                    rdbVoucher.Visible = False
                Else
                    rdbDevEfectivo.Visible = False
                    rdbVoucher.Visible = False
                End If

                If CDbl(Tabla.Rows(0).Item("Balance")) > 0 Then
                    rdbDevEfectivo.Checked = False
                    rdbVoucher.Checked = False
                    rdbDevEfectivo.Visible = False
                    rdbVoucher.Visible = False
                    rdbDevCredito.Visible = True
                Else
                    If CDbl(Tabla.Rows(0).Item("Dias")) > 0 Then
                        rdbDevEfectivo.Visible = False
                    Else
                        rdbDevEfectivo.Visible = True
                        rdbVoucher.Visible = True
                    End If

                End If

                If Tabla.Rows(0).Item("IDComprobanteFiscal") = 1 Then
                    If Tabla.Rows(0).Item("NCF") <> "" Then
                        ChkGenerarNCF.Checked = True
                    Else
                        ChkGenerarNCF.Checked = False
                    End If
                    ChkGenerarNCF.Enabled = True
                Else
                    If CInt(DTConfiguracion.Rows(218 - 1).Item("Value2Int")) = 1 Then
                        ChkGenerarNCF.Checked = False
                        ChkGenerarNCF.Enabled = False
                    Else
                        If Tabla.Rows(0).Item("NCF") <> "" Then
                            ChkGenerarNCF.Checked = True
                        Else
                            ChkGenerarNCF.Checked = False
                        End If
                    End If
                End If


                If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                    DgvArticulos.Enabled = False
                Else
                    DgvArticulos.Enabled = True
                End If

                If rdbDevCredito.Visible = False And rdbDevEfectivo.Visible = False And rdbVoucher.Visible = False Then
                    MessageBox.Show("No es posible realizarse la devolución de crédito ya que la factura seleccionada ya está salda. Por favor realice una nota de crédito y posteriormente el ajuste de inventario.", "Imposibilidad de devolución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub FactStatus()
        Dim Counter As Integer = DgvArticulos.Rows.Count

        If txtFactura.Text <> "" And Counter > 0 Then
            txtFactura.ReadOnly = True
            btnBuscarFactura.Enabled = False
        Else
            txtFactura.ReadOnly = False
            btnBuscarFactura.Enabled = True
        End If
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub DgvArticulos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellContentClick
        Try
            If e.RowIndex < 0 Then
                Exit Sub
            End If

            If e.ColumnIndex = 12 Or e.ColumnIndex = 13 Then
                DgvArticulos.EndEdit()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvArticulos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvArticulos.CurrentCellDirtyStateChanged
        If DgvArticulos.IsCurrentCellDirty Then
            DgvArticulos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvArticulos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellClick
        DgvArticulos.EditMode = DataGridViewEditMode.EditOnEnter
    End Sub

    Private Sub DgvArticulos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellValueChanged
        Try

            If e.ColumnIndex = 12 Then
                If DgvArticulos.CurrentRow.Cells(12).Value = "" Then
                    DgvArticulos.CurrentRow.Cells(12).Value = CDbl(0)
                Else
                    If IsNumeric(DgvArticulos.CurrentRow.Cells(12).Value) Then
                        If CDbl(DgvArticulos.CurrentRow.Cells(12).Value) > 0 Then
                            Dim CheckPermDev, IDArtc As String
                            IDArtc = DgvArticulos.CurrentRow.Cells(5).Value

                            ConLibregco.Open()
                            cmd = New MySqlCommand("SELECT Devolucion FROM articulos Where IDArticulo='" + IDArtc + "'", ConLibregco)
                            CheckPermDev = Convert.ToString(cmd.ExecuteScalar())
                            ConLibregco.Close()

                            If CheckPermDev = 1 Then
                                MessageBox.Show("No está permitida la devolución del artículo [" & DgvArticulos.CurrentRow.Cells(5).Value & "] " & DgvArticulos.CurrentRow.Cells(6).Value & ".", "Devolución no permitida", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                DgvArticulos.CurrentRow.Cells(12).Value = CDbl(0)
                            End If
                        End If

                    Else
                        DgvArticulos.CurrentRow.Cells(12).Value = CDbl(0)

                    End If


                End If

                    If CDbl(DgvArticulos.CurrentRow.Cells(12).Value) > CDbl(DgvArticulos.CurrentRow.Cells(9).Value) Then
                    MessageBox.Show("La cantidad para devolución excede la cantidad comprada.", "Excede la cant. comprada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    DgvArticulos.CurrentRow.Cells(12).Value = CDbl(DgvArticulos.CurrentRow.Cells(9).Value)
                End If

            End If

            If e.ColumnIndex = 13 Then
                If DgvArticulos.CurrentRow.Cells(13).Value = "" Then
                    DgvArticulos.CurrentRow.Cells(13).Value = CDbl(DgvArticulos.CurrentRow.Cells(10).Value)

                Else

                    If IsNumeric(DgvArticulos.CurrentRow.Cells(13).Value) Then

                        If CDbl(DgvArticulos.CurrentRow.Cells(13).Value) > CDbl(DgvArticulos.CurrentRow.Cells(10).Value) Then
                            MessageBox.Show("El valor de devolución no puede exceder el precio de venta del artículo.", "Valor excede precio de venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            DgvArticulos.CurrentRow.Cells(13).Value = DgvArticulos.CurrentRow.Cells(10).Value
                        Else
                            DgvArticulos.CurrentRow.Cells(13).Value = CDbl(DgvArticulos.CurrentRow.Cells(13).Value).ToString("C")
                        End If

                    Else
                        DgvArticulos.CurrentRow.Cells(13).Value = DgvArticulos.CurrentRow.Cells(10).Value
                    End If

                End If

            End If

            CalcDevolucion()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = DgvArticulos.CurrentCell.ColumnIndex

        If Columna = 12 Or Columna = 13 Then
            Dim Caracter As Char = e.KeyChar
            Dim Txt As TextBox = CType(sender, TextBox)

            If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") And (Txt.Text.Contains(",") = False) Then

                e.Handled = False
            Else
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub DgvArticulos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvArticulos.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)

        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub CalcDevolucion()
        Dim SubTotal As Double = 0
        Dim Itbis As Double = 0
        Dim Neto As Double = 0

        For Each Rows As DataGridViewRow In DgvArticulos.Rows
            SubTotal = SubTotal + ((CDbl(Rows.Cells(13).Value) - CDbl(Rows.Cells(11).Value)) * CDbl(Rows.Cells(12).Value))
            Itbis = Itbis + (CDbl(Rows.Cells(11).Value) * CDbl(Rows.Cells(12).Value))
        Next

        txtSubtotal.Text = SubTotal.ToString("C")
        txtItbis.Text = Itbis.ToString("C")
        txtTotal.Text = (SubTotal + Itbis).ToString("C")

        If ChkDevolverItbis.Checked = True Then
            txtMontoDevolucion.Text = txtTotal.Text
        Else
            txtMontoDevolucion.Text = txtSubtotal.Text
        End If


    End Sub

    Private Sub ChkDevolverItbis_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDevolverItbis.CheckedChanged
        If ChkDevolverItbis.Checked = True Then
            ChkDevolverItbis.Tag = 1
        Else
            ChkDevolverItbis.Tag = 0
        End If
        CalcDevolucion()
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            chkNulo.Tag = 1
            DeshabilitarControles()
        Else
            chkNulo.Tag = 0
            HabilitarControles()
        End If
    End Sub

    Private Sub ConvertDouble()
        txtSubtotal.Text = CDbl(txtSubtotal.Text)
        txtItbis.Text = CDbl(txtItbis.Text)
        txtTotal.Text = CDbl(txtTotal.Text)
        txtMontoDevolucion.Text = CDbl(txtMontoDevolucion.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtSubtotal.Text = CDbl(txtSubtotal.Text).ToString("C")
        txtItbis.Text = CDbl(txtItbis.Text).ToString("C")
        txtTotal.Text = CDbl(txtTotal.Text).ToString("C")
        txtMontoDevolucion.Text = CDbl(txtMontoDevolucion.Text).ToString("C")
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

    Private Sub UltDevolucion()
        Try

            If txtIDDevolucion.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDDevolucionVenta from DevolucionVenta where IDDevolucionVenta= (Select Max(IDDevolucionVenta) from DevolucionVenta)", Con)
                txtIDDevolucion.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DeshabilitarControles()
        txtFactura.Enabled = False
        btnBuscarFactura.Enabled = False
        DgvArticulos.Enabled = False
        ChkDevolverItbis.Enabled = False
        ChkGenerarNCF.Enabled = False
        rdbVoucher.Enabled = False
        rdbDevEfectivo.Enabled = False
        rdbDevCredito.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        txtFactura.Enabled = True
        btnBuscarFactura.Enabled = True
        DgvArticulos.Enabled = True
        ChkDevolverItbis.Enabled = True
        ChkGenerarNCF.Enabled = True
        rdbVoucher.Enabled = True
        rdbDevEfectivo.Enabled = True
        rdbDevCredito.Enabled = True
    End Sub

    Private Sub InsertDevolucionDetalle()
        Dim x As Integer = 0
        Dim Counter As Integer = DgvArticulos.Rows.Count
        Dim IDDevolucionDetalle, IDDevolucion, IDPrecio, IDFacturaArt, IDFactura, IDArticulo, Descripcion, IDMedida, Medida, CantVendida, PrecioVenta, Itbis, CantDevuelta, PrecioDev, IDAlmacen As New Label

Inicio:
        If x = Counter Then
            GoTo Fin
        End If

        IDDevolucionDetalle.Text = DgvArticulos.Rows(x).Cells(0).Value
        'IDDevolucion.Text = CDbl(DgvArticulos.Rows(x).Cells(1).Value)
        IDPrecio.Text = DgvArticulos.Rows(x).Cells(2).Value
        IDFacturaArt.Text = DgvArticulos.Rows(x).Cells(3).Value
        IDFactura.Text = CDbl(DgvArticulos.Rows(x).Cells(4).Value)
        IDArticulo.Text = CDbl(DgvArticulos.Rows(x).Cells(5).Value)
        Descripcion.Text = DgvArticulos.Rows(x).Cells(6).Value
        IDMedida.Text = CDbl(DgvArticulos.Rows(x).Cells(7).Value)
        Medida.Text = DgvArticulos.Rows(x).Cells(8).Value
        CantVendida.Text = CDbl(DgvArticulos.Rows(x).Cells(9).Value)
        PrecioVenta.Text = CDbl(DgvArticulos.Rows(x).Cells(10).Value)
        Itbis.Text = CDbl(DgvArticulos.Rows(x).Cells(11).Value)
        CantDevuelta.Text = CDbl(DgvArticulos.Rows(x).Cells(12).Value)
        PrecioDev.Text = CDbl(DgvArticulos.Rows(x).Cells(13).Value)
        IDAlmacen.Text = DgvArticulos.Rows(x).Cells(14).Value

        If IDDevolucionDetalle.Text = "" Then
            If CDbl(CantDevuelta.Text) > CDbl(0) Then
                sqlQ = "INSERT INTO Devolucionventadetalle (IDDevolucionVenta,IDPrecio,IDFactArt,IDArticulo,Descripcion,IDMedida,Medida,CantVendida,PrecioVenta,Itbis,CantDevuelta,PrecioDevuelto,IDAlmacen) VALUES ('" + txtIDDevolucion.Text + "','" + IDPrecio.Text + "','" + IDFacturaArt.Text + "','" + IDArticulo.Text + "','" + Descripcion.Text + "','" + IDMedida.Text + "','" + Medida.Text + "','" + CantVendida.Text + "','" + PrecioVenta.Text + "','" + Itbis.Text + "','" + CantDevuelta.Text + "','" + PrecioDev.Text + "','" + IDAlmacen.Text + "')"
                GuardarDatos()
                x = x + 1
                GoTo Inicio
            End If
        Else
            sqlQ = "UPDATE Devolucionventadetalle SET CantDevuelta='" + CantDevuelta.Text + "',PrecioDevuelto='" + PrecioDev.Text + "',IDAlmacen='" + IDAlmacen.Text + "' WHERE IDDevolucionVentaDetalle='" + IDDevolucionDetalle.Text + "'"
            GuardarDatos()
            x = x + 1
            GoTo Inicio
        End If

        x = x + 1
        GoTo Inicio
Fin:
    End Sub

    Private Sub CalcularBalances()
        FunctCalcBcesFact(txtIDCliente.Text)
        FunctCalcBceGral(txtIDCliente.Text)
    End Sub

    Private Sub CalcExistenciaAlm()
        Dim IDArticulo, IDPrecio As String

        For Each Row As DataGridViewRow In DgvArticulos.Rows
            IDArticulo = Row.Cells(5).Value
            IDPrecio = Row.Cells(2).Value
            FunctCalcInvAlmacenes(IDArticulo, IDPrecio)
        Next
    End Sub

    Private Sub CalcExistencia()
        Dim IDArticulo As String

        For Each Row As DataGridViewRow In DgvArticulos.Rows
            IDArticulo = Row.Cells(5).Value
            FunctCalcInventarioGral(IDArticulo)
        Next

    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDDevolucion.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el recibo de la devolución?", "Imprimir Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarFactura.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Sub FillDgvArticulos()
        Try
            DgvArticulos.Rows.Clear()
            Con.Open()
            Dim Cmd As New MySqlCommand("Select IDDevolucionVentaDetalle,DevolucionVentaDetalle.IDDevolucionVenta,IDPrecio,IDFactura,IDFactArt,IDArticulo,Descripcion,IDMedida,Medida,CantVendida,PrecioVenta,DevolucionVentaDetalle.Itbis,CantDevuelta,PrecioDevuelto,DevolucionVentaDetalle.IDAlmacen from DevolucionVentaDetalle INNER JOIN DevolucionVenta on DevolucionVentaDetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta Where DevolucionVentaDetalle.IDDevolucionVenta='" + txtIDDevolucion.Text + "'", Con)
            Dim LectorArticulos As MySqlDataReader = Cmd.ExecuteReader
            While LectorArticulos.Read
                DgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), LectorArticulos.GetValue(10), LectorArticulos.GetValue(11), LectorArticulos.GetValue(12), LectorArticulos.GetValue(13), LectorArticulos.GetValue(14))
            End While
            LectorArticulos.Close()
            Con.Close()
            PropiedadDgvArticulos()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnBuscarMotivo_Click(sender As Object, e As EventArgs) Handles btnBuscarMotivo.Click
        frm_buscar_mot_devolucion.ShowDialog(Me)
    End Sub

    Private Sub rdbVoucher_CheckedChanged(sender As Object, e As EventArgs) Handles rdbVoucher.CheckedChanged
        If rdbVoucher.Checked = True Then
            lblTipoDevolucion.Text = 1
        End If
    End Sub

    Private Sub rdbDevEfectivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDevEfectivo.CheckedChanged
        If rdbDevEfectivo.Checked = True Then
            lblTipoDevolucion.Text = 3
        End If
    End Sub

    Private Sub rdbDevCredito_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDevCredito.CheckedChanged
        If rdbDevCredito.Checked = True Then
            lblTipoDevolucion.Text = 2
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub ChkGenerarNCF_CheckedChanged(sender As Object, e As EventArgs) Handles ChkGenerarNCF.CheckedChanged
        If ChkGenerarNCF.Checked = True Then
            ChkGenerarNCF.Tag = 1
        Else
            ChkGenerarNCF.Tag = 0
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If rdbDevCredito.Visible = False And rdbDevEfectivo.Visible = False And rdbVoucher.Visible = False Then
            MessageBox.Show("No es posible realizarse la devolución de crédito ya que la factura seleccionada ya está salda. Por favor realice una nota de crédito y posteriormente el ajuste de inventario.", "Imposibilidad de devolución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim ItemsDevueltos As Double = 0
        For Each Rows As DataGridViewRow In DgvArticulos.Rows
            ItemsDevueltos = ItemsDevueltos + (CDbl(Rows.Cells(12).Value))
        Next

        If txtFactura.Text = "" Then
            MessageBox.Show("Escriba el No. de Factura a buscar para procesar la devolución de venta.", "Escriba el Número de la Factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtFactura.Focus()
            Exit Sub
        ElseIf ItemsDevueltos = 0 Then
            MessageBox.Show("No se han específicado artículos para devolución.", "Especificar Cant. a devolver", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf txtIDMotivoDevolucion.Text = "" Then
            MessageBox.Show("Seleccione el motivo de la devolución de la Factura No: " & txtFactura.Text & " para procesar la devolución.", "Seleccione Motivo de Devolución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarMotivo.Focus()
            Exit Sub
        ElseIf rdbDevCredito.Checked = False And rdbDevEfectivo.Checked = False And rdbVoucher.Checked = False Then
            MessageBox.Show("Seleccione la forma de la devolución.", "Forma de devolución", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf rdbDevCredito.Checked = True Then
            Dim MontoPago As Double
            Con.Open()
            cmd = New MySqlCommand("Select Coalesce(Sum(DetalleAbonos.Total),0) From DetalleAbonos INNER JOIN Abonos On DetalleAbonos.IDAbono= Abonos.IDAbono where IDFactura='" + txtFactura.Text + "' and Nulo=0", Con)
            MontoPago = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()

            If MontoPago > 0 And CDbl(txtTotal.Text) > CDbl(txtBalanceFact.Text) Then
                MessageBox.Show("Esta factura tiene pagos aplicados por un monto de " & MontoPago.ToString("C") & "." & vbNewLine & vbNewLine & "No se pueden aplicar créditos por devolución por un monto mayor a " & txtBalanceFact.Text & " bajo este tipo de devolución.", "Valor Excede Balance", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf MontoPago = 0 And CDbl(txtTotal.Text) > CDbl(txtBalanceFact.Text) Then
                MessageBox.Show("No se pueden aplicar créditos por devolución por un monto mayor a " & txtBalanceFact.Text & " bajo este tipo de devolución.", "Valor Excede Balance", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If

        If txtIDDevolucion.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la devolución de la factura No. " & txtFactura.Text & " en la base de datos?", "Guardar Nueva Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                If ChkGenerarNCF.Checked = True Then
                    GetNCFsNumbers(4)
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                Else
                    NewNCFValue.Text = ""
                End If

                ConvertDouble()
                sqlQ = "INSERT INTO DevolucionVenta (IDTipoDocumento,IDUsuario,Fecha,Hora,IDSucursal,IDAlmacen,IDEquipo,IDFactura,GenerarNCF,NCF,IDTipoDevolucion,DevolverItbis,DiasTransaccion,IDMotivoDevolucion,Subtotal,Itbis,Neto,Devolver,Impreso,Nulo) VALUES (13,'" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString() + "','" + cbxAlmacen.Tag.ToString + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + lblIDFactura.Text + "','" + ChkGenerarNCF.Tag.ToString + "','" + NewNCFValue.Text + "','" + lblTipoDevolucion.Text + "','" + ChkDevolverItbis.Tag.ToString + "','" + txtDias.Text + "','" + txtIDMotivoDevolucion.Text + "','" + txtSubtotal.Text + "','" + txtItbis.Text + "','" + txtTotal.Text + "','" + txtMontoDevolucion.Text + "',0,'" + chkNulo.Tag.ToString + "')"
                GuardarDatos()
                ConvertCurrent()
                UltDevolucion()
                SetSecondID()
                InsertDevolucionDetalle()
                CalcularExistencias()
                CalcularBalances()
                UpdateNCFModificado()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                DeshabilitarControles()
            End If

        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la devolución?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                ConMixta.Open()
                cmd = New MySqlCommand("SELECT coalesce(sum(credito),0) as MontosUsados FROM" & SysName.Text & "transaccion WHERE IDCredito='" + txtIDDevolucion.Text + "'", ConMixta)
                Dim MontoUsado As Double = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If MontoUsado > 0 Then
                    MessageBox.Show("No se pueden realizar cambios en la actual devolución ya que se ha(n) realizado transacciones con el crédito de la misma.", "Crédito con referencias integrales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                frm_superclave.IDAccion.Text = 122
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ConvertDouble()
                sqlQ = "UPDATE DevolucionVenta SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + cbxAlmacen.Tag.ToString + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDFactura='" + lblIDFactura.Text + "',GenerarNCF='" + ChkGenerarNCF.Tag.ToString + "',NCF='" + lblNoNCF.Text + "',IDTipoDevolucion='" + lblTipoDevolucion.Text + "',DevolverItbis='" + ChkDevolverItbis.Tag.ToString + "',Devolver='" + txtMontoDevolucion.Text + "',DiasTransaccion='" + txtDias.Text + "',IDMotivoDevolucion='" + txtIDMotivoDevolucion.Text + "',Subtotal='" + txtSubtotal.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtTotal.Text + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDDevolucionVenta= (" + txtIDDevolucion.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertDevolucionDetalle()
                CalcularExistencias()
                CalcularBalances()
                UpdateNCFModificado()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub CalcularExistencias()
        CalcExistencia()
        CalcExistenciaAlm()
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If rdbDevCredito.Visible = False And rdbDevEfectivo.Visible = False And rdbVoucher.Visible = False Then
            MessageBox.Show("No es posible realizarse la devolución de crédito ya que la factura seleccionada ya está salda. Por favor realice una nota de crédito y posteriormente el ajuste de inventario.", "Imposibilidad de devolución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim ItemsDevueltos As Double = 0
        For Each Rows As DataGridViewRow In DgvArticulos.Rows
            ItemsDevueltos = ItemsDevueltos + (CDbl(Rows.Cells(12).Value))
        Next

        If txtFactura.Text = "" Then
            MessageBox.Show("Escriba el No. de Factura a buscar para procesar la devolución de venta.", "Escriba el Número de la Factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtFactura.Focus()
            Exit Sub
        ElseIf ItemsDevueltos = 0 Then
            MessageBox.Show("No se han específicado artículos para devolución.", "Especificar Cant. a devolver", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf txtIDMotivoDevolucion.Text = "" Then
            MessageBox.Show("Seleccione el motivo de la devolución de la Factura No: " & txtFactura.Text & " para procesar la devolución.", "Seleccione Motivo de Devolución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarMotivo.Focus()
            Exit Sub
        ElseIf rdbDevCredito.Checked = False And rdbDevEfectivo.Checked = False And rdbVoucher.Checked = False Then
            MessageBox.Show("Seleccione la forma de la devolución.", "Forma de devolución", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf rdbDevCredito.Checked = True Then
            Dim MontoPago As Double
            Con.Open()
            cmd = New MySqlCommand("Select Coalesce(Sum(DetalleAbonos.Total),0) From DetalleAbonos INNER JOIN Abonos On DetalleAbonos.IDAbono= Abonos.IDAbono where IDFactura='" + txtFactura.Text + "' and Nulo=0", Con)
            MontoPago = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()

            If MontoPago > 0 And CDbl(txtTotal.Text) > CDbl(txtBalanceFact.Text) Then
                MessageBox.Show("Esta factura tiene pagos aplicados por un monto de " & MontoPago.ToString("C") & "." & vbNewLine & vbNewLine & "No se pueden aplicar créditos por devolución por un monto mayor a " & txtBalanceFact.Text & " bajo este tipo de devolución.", "Valor Excede Balance", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf MontoPago = 0 And CDbl(txtTotal.Text) > CDbl(txtBalanceFact.Text) Then
                MessageBox.Show("No se pueden aplicar créditos por devolución por un monto mayor a " & txtBalanceFact.Text & " bajo este tipo de devolución.", "Valor Excede Balance", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If

        If txtIDDevolucion.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la devolución de la factura No. " & txtFactura.Text & " en la base de datos?", "Guardar Nueva Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                If ChkGenerarNCF.Checked = True Then
                    GetNCFsNumbers(4)
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                Else
                    NewNCFValue.Text = ""
                End If

                ConvertDouble()
                sqlQ = "INSERT INTO DevolucionVenta (IDTipoDocumento,IDUsuario,Fecha,Hora,IDSucursal,IDAlmacen,IDEquipo,IDFactura,GenerarNCF,NCF,IDTipoDevolucion,DevolverItbis,DiasTransaccion,IDMotivoDevolucion,Subtotal,Itbis,Neto,Devolver,Impreso,Nulo) VALUES (13,'" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + cbxAlmacen.Tag.ToString + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + lblIDFactura.Text + "','" + ChkGenerarNCF.Tag.ToString + "','" + NewNCFValue.Text + "','" + lblTipoDevolucion.Text + "','" + ChkDevolverItbis.Tag.ToString + "','" + txtDias.Text + "','" + txtIDMotivoDevolucion.Text + "','" + txtSubtotal.Text + "','" + txtItbis.Text + "','" + txtTotal.Text + "','" + txtMontoDevolucion.Text + "',0,'" + chkNulo.Tag.ToString + "')"
                GuardarDatos()
                ConvertCurrent()
                UltDevolucion()
                SetSecondID()
                InsertDevolucionDetalle()
                CalcularExistencias()
                CalcularBalances()
                UpdateNCFModificado()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la devolución?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then


                ConMixta.Open()
                cmd = New MySqlCommand("SELECT coalesce(sum(credito),0) as MontosUsados FROM" & SysName.Text & "transaccion WHERE IDCredito='" + txtIDDevolucion.Text + "'", ConMixta)
                Dim MontoUsado As Double = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If MontoUsado > 0 Then
                    MessageBox.Show("No se pueden realizar cambios en la actual devolución ya que se ha(n) realizado transacciones con el crédito de la misma.", "Crédito con referencias integrales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If


                frm_superclave.IDAccion.Text = 122
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                ConvertDouble()
                sqlQ = "UPDATE DevolucionVenta SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + cbxAlmacen.Tag.ToString + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDFactura='" + lblIDFactura.Text + "',GenerarNCF='" + ChkGenerarNCF.Tag.ToString + "',NCF='" + lblNoNCF.Text + "',IDTipoDevolucion='" + lblTipoDevolucion.Text + "',DevolverItbis='" + ChkDevolverItbis.Tag.ToString + "',Devolver='" + txtMontoDevolucion.Text + "',DiasTransaccion='" + txtDias.Text + "',IDMotivoDevolucion='" + txtIDMotivoDevolucion.Text + "',Subtotal='" + txtSubtotal.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtTotal.Text + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDDevolucionVenta= (" + txtIDDevolucion.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertDevolucionDetalle()
                CalcularExistencias()
                CalcularBalances()
                UpdateNCFModificado()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub ChkDevolverItbis_Click(sender As Object, e As EventArgs) Handles ChkDevolverItbis.Click
        If lblIDFactura.Text <> "" Then
            If CDbl(txtDias.Text) <= 30 Then
                If ChkDevolverItbis.CheckState = CheckState.Checked Then
                    ChkDevolverItbis.CheckState = CheckState.Unchecked
                Else
                    ChkDevolverItbis.CheckState = CheckState.Checked
                End If
            Else
                If ChkDevolverItbis.CheckState = CheckState.Unchecked Then
                    ControlSuperClave = 1

                    frm_superclave.IDAccion.Text = 131
                    frm_superclave.ShowDialog(Me)

                    If ControlSuperClave = 1 Then
                        Exit Sub
                    Else
                        ControlSuperClave = 0

                        ChkDevolverItbis.CheckState = CheckState.Checked

                    End If
                Else
                    ChkDevolverItbis.CheckState = CheckState.Unchecked
                End If

            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_devoluciones.ShowDialog(Me)
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim ItemsDevueltos As Double = 0
        For Each Rows As DataGridViewRow In DgvArticulos.Rows
            ItemsDevueltos = ItemsDevueltos + (CDbl(Rows.Cells(12).Value))
        Next

        If txtFactura.Text = "" Then
            MessageBox.Show("Escriba el No. de Factura a buscar para procesar la devolución de venta.", "Escriba el Número de la Factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtFactura.Focus()
            Exit Sub
        ElseIf ItemsDevueltos = 0 Then
            MessageBox.Show("No se han específicado artículos para devolución.", "Especificar Cant. a devolver", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf txtIDMotivoDevolucion.Text = "" Then
            MessageBox.Show("Seleccione el motivo de la devolución de la Factura No: " & txtFactura.Text & " para procesar la devolución.", "Seleccione Motivo de Devolución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarMotivo.Focus()
            Exit Sub
        End If

        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ConMixta.Open()
        cmd = New MySqlCommand("SELECT coalesce(sum(credito),0) as MontosUsados FROM" & SysName.Text & "transaccion WHERE IDCredito='" + txtIDDevolucion.Text + "'", ConMixta)
        Dim MontoUsado As Double = Convert.ToString(cmd.ExecuteScalar())
        ConMixta.Close()

        If MontoUsado > 0 Then
            MessageBox.Show("No se pueden realizar cambios en la actual devolución ya que se ha(n) realizado transacciones con el crédito de la misma.", "Crédito con referencias integrales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La devolución No. " & txtIDDevolucion.Text & " de la factura " & txtFactura.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 40
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE DevolucionVenta SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + cbxAlmacen.Tag.ToString + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDFactura='" + lblIDFactura.Text + "',GenerarNCF='" + ChkGenerarNCF.Tag.ToString + "',NCF='" + lblNoNCF.Text + "',IDTipoDevolucion='" + lblTipoDevolucion.Text + "',DevolverItbis='" + ChkDevolverItbis.Tag.ToString + "',Devolver='" + txtMontoDevolucion.Text + "',DiasTransaccion='" + txtDias.Text + "',IDMotivoDevolucion='" + txtIDMotivoDevolucion.Text + "',Subtotal='" + txtSubtotal.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtTotal.Text + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDDevolucionVenta= (" + txtIDDevolucion.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcExistencia()
                CalcExistenciaAlm()
                CalcularBalances()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDDevolucion.Text = "" Then
            MessageBox.Show("No hay un registro de factura abierto para desactivar", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular la devolución No. " & txtIDDevolucion.Text & " de la factura No. " & txtFactura.Text & " del sistema?", "Anular Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 39
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE DevolucionVenta SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + cbxAlmacen.Tag.ToString + "',IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDFactura='" + lblIDFactura.Text + "',GenerarNCF='" + ChkGenerarNCF.Tag.ToString + "',NCF='" + lblNoNCF.Text + "',IDTipoDevolucion='" + lblTipoDevolucion.Text + "',DevolverItbis='" + ChkDevolverItbis.Tag.ToString + "',Devolver='" + txtMontoDevolucion.Text + "',DiasTransaccion='" + txtDias.Text + "',IDMotivoDevolucion='" + txtIDMotivoDevolucion.Text + "',Subtotal='" + txtSubtotal.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtTotal.Text + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDDevolucionVenta= (" + txtIDDevolucion.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                CalcExistencia()
                CalcExistenciaAlm()
                CalcularBalances()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub cbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAlmacen.SelectedIndexChanged
        SetIDAlmacen()
    End Sub

    Private Sub DgvArticulos_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvArticulos.CellFormatting
        'If DgvArticulos.Columns.Count > 0 Then
        '    If DgvArticulos.Rows.Count > 0 Then
        '        If e.ColumnIndex = Me.DgvArticulos.Columns(14).Index AndAlso (e.Value IsNot Nothing) Then

        '            With Me.DgvArticulos.Rows(e.RowIndex).Cells(e.ColumnIndex)
        '                Dim IDAlmacen As String = DgvArticulos.CurrentRow.Cells(14).Value
        '                Con.Open()
        '                cmd = New MySqlCommand("Select Almacen from Almacen where IDAlmacen='" + IDAlmacen + "'", Con)
        '                Dim Almacen As String = Convert.ToString(cmd.ExecuteScalar())
        '                Con.Close()

        '                .ToolTipText = Almacen
        '            End With
        '        End If
        '    End If
        'End If


    End Sub

    Private Sub frm_devolucion_fact_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If DgvArticulos.Columns.Count > 0 Then
            PropiedadDgvArticulos()
        End If

    End Sub

    Private Sub BuscarDevoluciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarDevoluciónToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub
End Class
