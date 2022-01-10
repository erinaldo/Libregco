Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_devolucion_compras

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDUsuario, lblIDCompra, lblTipoDevolucion, lblIDAlmacen, lblNulo, lblDevItbis As New Label
    Dim Permisos As New ArrayList
    Dim TypeOfMetod, ImponerEscrituradeNCF As String

    Private Sub frm_devolucion_compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarConfiguracion()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        LimpiarDatos()
        ActualizarTodo()
        ColumnsDgvArticulos()
    End Sub

    Private Sub CargarConfiguracion()
        Try
            ConMixta.Open()

            'TipoComprobante
            cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=75", ConMixta)
            TypeOfMetod = Convert.ToString(cmd.ExecuteScalar())

            ConMixta.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarLibregco()
      PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub ColumnsDgvArticulos()
        DgvArticulos.Columns.Clear()

        With DgvArticulos
            .Columns.Add("IDDevolucionCompraDetalle", "IDDevolucionDetalle") '0
            .Columns.Add("IDDevolucion", "IDDevolucion")    '1
            .Columns.Add("IDPrecio", "IDPrecio")    '2
            .Columns.Add("IDFacturaArt", "IDFacturaArt") '3
            .Columns.Add("IDFactura", "IDFactura")  '4
            .Columns.Add("IDArticulo", "Código")    '5
            .Columns.Add("Descripcion", "Descripción")    '6
            .Columns.Add("IDMedida", "IDMedida")    '7
            .Columns.Add("Medida", "Medida")    '8
            .Columns.Add("Cantidad", "Cant. Comp.")    '9
            .Columns.Add("PrecioUnitario", "Costo")    '10
            .Columns.Add("Itbis", "Itbis")  '11
            .Columns.Add("CantidadDev", "Cant. Dev.")   '12
            .Columns.Add("PrecioDev", "Precio Devolución")    '13
            .Columns.Add("IDAlmacen", "Almacén") '14
            PropiedadDgvArticulos()
        End With
    End Sub

    Private Sub PropiedadDgvArticulos()
        Try
            Dim DatagridWith As Double = (DgvArticulos.Width - DgvArticulos.RowHeadersWidth) / 100
            With DgvArticulos
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = False
                .Columns(3).Visible = False
                .Columns(4).Visible = False
                .Columns(5).Width = DatagridWith * 10
                .Columns(5).ReadOnly = True
                .Columns(6).Width = DatagridWith * 26
                .Columns(6).ReadOnly = True
                .Columns(7).Visible = False
                .Columns(8).Width = DatagridWith * 8
                .Columns(8).ReadOnly = True
                .Columns(9).Width = DatagridWith * 10
                .Columns(9).ReadOnly = True
                .Columns(10).DefaultCellStyle.Format = ("C4")
                .Columns(10).Width = DatagridWith * 14
                .Columns(10).ReadOnly = True
                .Columns(11).Visible = False
                .Columns(12).Width = DatagridWith * 10
                .Columns(13).Width = DatagridWith * 14
                .Columns(13).DefaultCellStyle.Format = ("C4")
                .Columns(14).Width = DatagridWith * 8
                .Columns(14).ReadOnly = True

                If Me.WindowState = FormWindowState.Maximized Then
                    .Columns(9).HeaderText = "Cantidad Comprada"
                    .Columns(12).HeaderText = "Cantidad Devuelta"
                Else
                    .Columns(9).HeaderText = "Cant. Comp."
                    .Columns(12).HeaderText = "Cant. Dev."
                End If

            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LimpiarDatos()
        txtIDSuplidor.Clear()
        txtSecondID.Clear()
        txtNombre.Clear()
        txtBalanceGral.Clear()
        txtUltimoPago.Clear()
        txtNCF.Clear()
        txtNCFDev.Clear()
        txtRNC.Clear()
        txtIDDevolucion.Clear()
        txtBalanceFactura.Clear()
        txtFactura.Clear()
        txtFechaFactura.Clear()
        txtDias.Clear()
        txtMotivoDevolucion.Clear()
        txtCondicion.Clear()
        txtComprobante.Clear()
        txtItbis.Clear()
        txtTotal.Clear()
        txtMontoDevolver.Clear()
        txtIDMotivoDevolucion.Clear()
        DgvArticulos.Rows.Clear()
    End Sub

    Private Sub ActualizarTodo()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        ChkDevolverItbis.Checked = False
        lblDevItbis.Text = 0
        chkNulo.Checked = False
        ControlSuperClave = 1
        lblNulo.Text = 0
        lblStatusCompra.Text = ""
        FillAlmacen()
        SetIDComprobante()
        txtFactura.Focus()
        HabilitarControles()
        FactStatus()
    End Sub

    Private Sub SetIDComprobante()
        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT * from" & SysName.Text & "ComprobanteFiscal Where IDComprobanteFiscal=4", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Comprobantes")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds.Tables("Comprobantes")

        ImponerEscrituradeNCF = Tabla.Rows(0).Item("ImposicionCompra")

        If txtIDDevolucion.Text = "" Then
            If ImponerEscrituradeNCF = 1 Then
                If TypeOfMetod = 1 Then
                    txtNCFDev.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                    txtNCFDev.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                ElseIf TypeOfMetod = 2 Then
                    txtNCFDev.Mask = Tabla.Rows(0).Item("Serie") & "000000000000000000"
                    txtNCFDev.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                ElseIf TypeOfMetod = 3 Then
                    txtNCFDev.Mask = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF") & "00000000"
                    txtNCFDev.Text = Tabla.Rows(0).Item("Serie") & Tabla.Rows(0).Item("NoTCF")
                End If
            Else
                If TypeOfMetod = 1 Then
                    txtNCFDev.Mask = ""

                ElseIf TypeOfMetod = 2 Then
                    txtNCFDev.Mask = ""

                ElseIf TypeOfMetod = 3 Then
                    txtNCFDev.Mask = ""

                End If
            End If

        Else
            txtNCFDev.Mask = ""
        End If

        Tabla.Dispose()

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
        End Try
    End Sub

    Sub RefrescarDgvArticulos()
        Try

            DgvArticulos.Rows.Clear()
            Con.Open()
            Dim Cmd As New MySqlCommand("Select IDPrecio,IDDetalleCompra,DetalleCompra.IDCompra,IDArticulo,Descripcion,IDMedida,Medida,(DetalleCompra.Cantidad)-(Select Coalesce(Sum(CantDevuelta),0) from DevolucionCompraDetalle INNER JOIN DevolucionCompra on DevolucionCompraDetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra Where DevolucionCompraDetalle.IDDetalleCompra=DetalleCompra.IDDetalleCompra and DevolucionCompra.Nulo=0) as Cantidad,Importe,DetalleCompra.Itbis,DetalleCompra.IDAlmacen from DetalleCompra INNER JOIN Compras on DetalleCompra.IDCompra=Compras.IDCompra Where DetalleCompra.IDCompra='" + txtFactura.Text + "' or Compras.SecondID='" + txtFactura.Text + "'", Con)
            Dim LectorArticulos As MySqlDataReader = Cmd.ExecuteReader
            While LectorArticulos.Read
                DgvArticulos.Rows.Add("", "", LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), CDbl(LectorArticulos.GetValue(8)).ToString("C4"), CDbl(LectorArticulos.GetValue(9)).ToString("C4"), "0", CDbl(LectorArticulos.GetValue(8)).ToString("C4"), LectorArticulos.GetValue(10))
            End While

            LectorArticulos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnBuscarFactura_Click(sender As Object, e As EventArgs) Handles btnBuscarFactura.Click
        Try
            BuscarDatosdeFactura()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarDevoluciones()

        '        Try
        '            Dim x As Integer = 0
        '            Dim IDArticulo, IDDevolucionCompra, CantDevuelta As New Label

        'Inicio:
        '            If x = DgvArticulos.Rows.Count Then
        '                GoTo Fin
        '            End If

        '            IDDevolucionCompra.Text = DgvArticulos.Rows(x).Cells(1).Value
        '            IDArticulo.Text = DgvArticulos.Rows(x).Cells(5).Value
        '            CantDevuelta.Text = DgvArticulos.Rows(x).Cells(9).Value

        '            Ds.Clear()
        '            Con.Open()
        '            cmd = New MySqlCommand("SELECT IDFactura,IDArticulo,CantDevuelta FROM devolucioncompradetalle INNER JOIN DevolucionCompra on devolucioncompradetalle.IDDevolucioncompra=Devolucioncompra.IDDevolucioncompra INNER JOIN Compras on DevolucionCompra.IDFactura=Compras.IDCompra Where IDFactura='" + txtFactura.Text + "' or Compras.SecondID='" + txtFactura.Text + "' and IDArticulo='" + IDArticulo.Text + "' and DevolucionCompra.Nulo=0", Con)
        '            Adaptador = New MySqlDataAdapter(cmd)
        '            Adaptador.Fill(Ds, "DevolucionCompradetalle")
        '            Con.Close()

        '            Dim Tabla As DataTable = Ds.Tables("DevolucionCompradetalle")
        '            If Tabla.Rows.Count = 0 Then
        '                x = x + 1
        '                GoTo Inicio
        '            Else
        '                CantDevuelta.Text = Tabla.Compute("Sum(CantDevuelta)", "")
        '                DgvArticulos.Rows(x).Cells(9).Value = CDbl(DgvArticulos.Rows(x).Cells(9).Value) - CDbl(CantDevuelta.Text)
        '            End If

        '            x = x + 1
        '            GoTo Inicio
        'Fin:
        '        Catch ex As Exception
        '      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        '        End Try

    End Sub

    Sub BuscarDatosdeFactura()
        Try
            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select IDCompra,Compras.SecondID,Compras.IDSuplidor,Rnc,Suplidor,Suplidor.Balance as BalanceSuplidor,FechaFactura,NCF,TipoComprobante,Condicion,TotalNeto,Compras.Balance as BalanceFactura,Compras.Nulo From" & SysName.Text & "Compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "ComprobanteFiscal on Compras.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal Where IDCompra='" + txtFactura.Text + "' or Compras.SecondID='" + txtFactura.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Compras")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("Compras")

            If frm_consulta_compras.Visible = True Then
                frm_consulta_compras.Close()
            End If

            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron resultados.", "No se encontró", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                frm_consulta_compras.ShowDialog(Me)
                Exit Sub
            Else
                lblIDCompra.Text = (Tabla.Rows(0).Item("IDCompra"))
                txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                txtNombre.Text = (Tabla.Rows(0).Item("Suplidor"))
                txtRNC.Text = (Tabla.Rows(0).Item("Rnc"))
                txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceSuplidor")).ToString("C")
                txtCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                txtComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                txtFechaFactura.Text = (Tabla.Rows(0).Item("FechaFactura"))
                txtBalanceFactura.Text = CDbl(Tabla.Rows(0).Item("BalanceFactura")).ToString("C")
                txtNCF.Text = (Tabla.Rows(0).Item("NCF"))
                txtDias.Text = DateDiff(DateInterval.Day, CDate(txtFechaFactura.Text), Today)

                If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                    lblStatusCompra.Text = "Este registro de compra ha sido anulado."
                    lblStatusCompra.ForeColor = Color.Red
                    DgvArticulos.Enabled = False
                    GbMotivos.Enabled = False
                Else
                    lblStatusCompra.Text = ""
                    DgvArticulos.Enabled = True
                    GbMotivos.Enabled = True
                End If

                RefrescarDgvArticulos()
                BuscarDevoluciones()
                FactStatus()
                UltimoPago()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub RefrescarDgvArticulosProcesada()
        Try

            DgvArticulos.Rows.Clear()
            ConMixta.Open()
            Dim Cmd As New MySqlCommand("SELECT IDDevolucionCompraDetalle,DevolucionCompraDetalle.IDDevolucionCompra,DevolucionCompraDetalle.IDPrecio,DevolucionCompraDetalle.IDDetalleCompra,DevolucionCompra.IDFactura as IDCompra,DevolucionCompraDetalle.IDArticulo,DevolucionCompraDetalle.Descripcion,DevolucionCompraDetalle.IDMedida,Medida.Medida,DevolucionCompraDetalle.CantVendida,DetalleCompra.PrecioUnitario,DetalleCompra.Itbis,DevolucionCompraDetalle.CantDevuelta,DevolucionCompraDetalle.PrecioDevuelto,DevolucionCompraDetalle.IDAlmacen from" & SysName.Text & "devolucioncompradetalle  inner join" & SysName.Text & "DevolucionCompra on DevolucionCompraDetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra Inner join" & SysName.Text & "Compras on DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN" & SysName.Text & "DetalleCompra on DevolucionCompradetalle.IDDetalleCompra=DetalleCompra.IDDetalleCompra INNER join Libregco.PrecioArticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where DevolucionCompra.IDDevolucionCompra='" + txtIDDevolucion.Text + "'", ConMixta)

            Dim LectorArticulos As MySqlDataReader = Cmd.ExecuteReader

            While LectorArticulos.Read
                DgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), CDbl(LectorArticulos.GetValue(10)).ToString("C4"), CDbl(LectorArticulos.GetValue(11)).ToString("C4"), LectorArticulos.GetValue(12), CDbl(LectorArticulos.GetValue(13)).ToString("C4"), LectorArticulos.GetValue(14))
            End While

            LectorArticulos.Close()
            ConMixta.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Sub BuscarDevolucionProcesada()
        Try
            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("Select IDCompra, Compras.SecondID, Compras.IDSuplidor, Rnc, Suplidor, Suplidor.Balance As BalanceSuplidor, FechaFactura, NCF, TipoComprobante, Condicion, TotalNeto, Compras.Balance As BalanceFactura, Compras.Nulo From" & SysName.Text & "Compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion INNER JOIN" & SysName.Text & "ComprobanteFiscal on Compras.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal Where IDCompra='" + txtFactura.Text + "' or Compras.SecondID='" + txtFactura.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Compras")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("Compras")
            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron resultados.", "No se encontró", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                frm_consulta_compras.ShowDialog(Me)
                Exit Sub
            Else
                lblIDCompra.Text = (Tabla.Rows(0).Item("IDCompra"))
                txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                txtNombre.Text = (Tabla.Rows(0).Item("Suplidor"))
                txtRNC.Text = (Tabla.Rows(0).Item("Rnc"))
                txtBalanceGral.Text = CDbl(Tabla.Rows(0).Item("BalanceSuplidor")).ToString("C")
                txtCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                txtComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                txtFechaFactura.Text = (Tabla.Rows(0).Item("FechaFactura"))
                txtBalanceFactura.Text = CDbl(Tabla.Rows(0).Item("BalanceFactura")).ToString("C")
                txtNCF.Text = (Tabla.Rows(0).Item("NCF"))
                txtDias.Text = DateDiff(DateInterval.Day, CDate(txtFechaFactura.Text), Today)

                If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                    lblStatusCompra.Text = "Este registro de compra ha sido anulado."
                    lblStatusCompra.ForeColor = Color.Red
                    DgvArticulos.Enabled = False
                    GbMotivos.Enabled = False
                Else
                    lblStatusCompra.Text = ""
                    DgvArticulos.Enabled = True
                    GbMotivos.Enabled = True
                End If

                RefrescarDgvArticulosProcesada()
                CalcDevolucion()
                FactStatus()
                UltimoPago()
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

    Private Sub UltimoPago()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select IDSuplidor,Fecha from PagoCompra where IDPagoCompra=(Select Max(IDPagoCompra) from PagoCompra) and IDSuplidor='" + txtIDSuplidor.Text + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "PagosCompra")
            Con.Close()

            Dim Tabla1 As DataTable = Ds.Tables("PagosCompra")
            If Tabla1.Rows.Count = CInt(0) Then
                txtUltimoPago.Text = "NINGUNO"
            Else
                txtUltimoPago.Text = (Tabla1.Rows(0).Item("Fecha"))
            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
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

    Private Sub DgvArticulos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellValueChanged
        Try
            Try


                If e.ColumnIndex = 12 Then
                    If DgvArticulos.CurrentRow.Cells(12).Value = "" Then
                        DgvArticulos.CurrentRow.Cells(12).Value = CDbl(0)
                    Else
                    End If

                    If CDbl(DgvArticulos.CurrentRow.Cells(12).Value) > CDbl(DgvArticulos.CurrentRow.Cells(9).Value) Then
                        MessageBox.Show("La cantidad para devolución excede la cantidad comprada.", "Excede la cant. comprada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        DgvArticulos.CurrentRow.Cells(12).Value = CDbl(DgvArticulos.CurrentRow.Cells(9).Value)
                    End If

                End If
            Catch ex As Exception
                DgvArticulos.CurrentRow.Cells(12).Value = CDbl(0)
            End Try

            Try

                If e.ColumnIndex = 13 Then
                    If DgvArticulos.CurrentRow.Cells(13).Value = "" Then
                        DgvArticulos.CurrentRow.Cells(13).Value = CDbl(DgvArticulos.CurrentRow.Cells(10).Value)
                    Else
                        DgvArticulos.CurrentRow.Cells(13).Value = CDbl(DgvArticulos.CurrentRow.Cells(13).Value).ToString("C4")
                    End If

                End If

            Catch ex As Exception
                DgvArticulos.CurrentRow.Cells(13).Value = CDbl(DgvArticulos.CurrentRow.Cells(10).Value)
            End Try

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
        Dim IDArticulo, ItbisArt As New Label
        Dim SubTotal As Double = 0
        Dim Itbis As Double = 0
        Dim Neto As Double = 0

        For Each Rows As DataGridViewRow In DgvArticulos.Rows
            If CDbl(Rows.Cells(12).Value) > 0 Then
                IDArticulo.Text = Rows.Cells(5).Value

                SubTotal = SubTotal + (CDbl(Rows.Cells(13).Value) * CDbl(Rows.Cells(12).Value))

                If ChkDevolverItbis.Checked = True Then
                    Itbis = 0
                Else
                    'ConLibregco.Open()
                    'cmd = New MySqlCommand("SELECT Itbis FROM articulos INNER JOIN TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis where IDArticulo='" + IDArticulo.Text + "'", ConLibregco)
                    'ItbisArt.Text = Convert.ToDouble(cmd.ExecuteScalar())
                    'ConLibregco.Close()
                    Itbis = Itbis + CDbl(Rows.Cells(12).Value * CDbl(Rows.Cells(11).Value))
                End If
            End If

        Next

        txtMontoDevolver.Text = SubTotal.ToString("C")
        txtItbis.Text = Itbis.ToString("C")
        txtTotal.Text = (SubTotal - Itbis).ToString("C")

    End Sub

    Private Sub ChkDevolverItbis_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDevolverItbis.CheckedChanged
        If ChkDevolverItbis.Checked = True Then
            lblDevItbis.Text = 1
        Else
            lblDevItbis.Text = 0
        End If
        CalcDevolucion()
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblNulo.Text = 1
            DeshabilitarControles()
        Else
            lblNulo.Text = 0
            HabilitarControles()
        End If
    End Sub

    Private Sub ConvertDouble()
        txtMontoDevolver.Text = CDbl(txtMontoDevolver.Text)
        txtItbis.Text = CDbl(txtItbis.Text)
        txtTotal.Text = CDbl(txtTotal.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtMontoDevolver.Text = CDbl(txtMontoDevolver.Text).ToString("C")
        txtItbis.Text = CDbl(txtItbis.Text).ToString("C")
        txtTotal.Text = CDbl(txtTotal.Text).ToString("C")
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
                cmd = New MySqlCommand("Select IDDevolucionCompra from DevolucionCompra where IDDevolucionCompra= (Select Max(IDDevolucionCompra) from DevolucionCompra)", Con)
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
        txtNCFDev.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        txtFactura.Enabled = True
        btnBuscarFactura.Enabled = True
        DgvArticulos.Enabled = True
        ChkDevolverItbis.Enabled = True
        txtNCFDev.Enabled = True
    End Sub

    Private Sub InsertDevolucionDetalle()
        Con.Open()

        For Each rw As DataGridViewRow In DgvArticulos.Rows

            If rw.Cells(0).Value.ToString = "" Then
                If CDbl(rw.Cells(12).Value.ToString) > CDbl(0) Then
                    sqlQ = "INSERT INTO Devolucioncompradetalle (IDDevolucionCompra,IDPrecio,IDDetalleCompra,IDArticulo,Descripcion,IDMedida,Medida,CantVendida,PrecioVenta,Itbis,CantDevuelta,PrecioDevuelto,IDAlmacen) VALUES ('" + txtIDDevolucion.Text + "','" + rw.Cells(2).Value.ToString + "','" + rw.Cells(3).Value.ToString + "','" + rw.Cells(5).Value.ToString + "','" + rw.Cells(6).Value.ToString + "','" + rw.Cells(7).Value.ToString + "','" + rw.Cells(8).Value.ToString + "','" + rw.Cells(9).Value.ToString + "','" + CDbl(rw.Cells(10).Value).ToString + "','" + CDbl(rw.Cells(11).Value).ToString + "','" + CDbl(rw.Cells(12).Value).ToString + "','" + CDbl(rw.Cells(13).Value).ToString + "','" + rw.Cells(14).Value.ToString + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()

                    cmd = New MySqlCommand("Select IDDevolucionCompraDetalle from DevolucionCompraDetalle where IDDevolucionCompraDetalle= (Select Max(IDDevolucionCompraDetalle) from DevolucionCompraDetalle)", Con)
                    rw.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                End If
            Else
                If CDbl(rw.Cells(12).Value) = 0 Then
                    sqlQ = "Delete from Devolucioncompradetalle Where IDDevolucionCompraDetalle= '" + rw.Cells(0).Value.ToString + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                Else
                    sqlQ = "UPDATE Devolucioncompradetalle SET CantDevuelta='" + rw.Cells(12).Value.ToString + "',PrecioDevuelto='" + CDbl(rw.Cells(13).Value).ToString + "',IDAlmacen='" + rw.Cells(14).Value.ToString + "' WHERE IDDevolucionCompraDetalle='" + rw.Cells(0).Value.ToString + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If

            End If
        Next

        Con.Close()
    End Sub

    Private Sub CalcExistencias()
        CalcExistencia()
        CalcExistenciaAlm()
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
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
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

    Private Sub txtFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFactura.KeyPress
        'Dim Car% = Asc(e.KeyChar)
        'Select Case Car
        '    Case 8
        '    Case 48 To 57
        '    Case Else
        '        e.KeyChar = Nothing
        'End Select
    End Sub

    Sub FillChkDevolucion()
        Try

            Dim IDTipoDevolucion, DevolverItbis, Nulo As New Label

            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select DevolverItbis,Nulo from DevolucionCompra Where IDDevolucionCompra='" + txtIDDevolucion.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "DevolucionCompra")
            Con.Close()
            Dim TablaChk As DataTable = Ds.Tables("DevolucionCompra")

            DevolverItbis.Text = (TablaChk.Rows(0).Item("DevolverItbis"))
            Nulo.Text = (TablaChk.Rows(0).Item("Nulo"))

            If DevolverItbis.Text = 1 Then
                ChkDevolverItbis.Checked = True
            Else
                ChkDevolverItbis.Checked = False
            End If

            If Nulo.Text = 1 Then
                chkNulo.Checked = True
            Else
                chkNulo.Checked = False
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub FillDgvArticulos()
        Try

            DgvArticulos.Rows.Clear()
            Con.Open()
            Dim Cmd As New MySqlCommand("Select IDDevolucionCompraDetalle,DevolucionCompraDetalle.IDDevolucionCompra,IDPrecio,IDDetalleCompra,IDFactura,IDArticulo,Descripcion,IDMedida,Medida,CantVendida,PrecioVenta,DevolucionCompraDetalle.Itbis,CantDevuelta,PrecioDevuelto,DevolucionCompraDetalle.IDAlmacen from DevolucionCompraDetalle INNER JOIN DevolucionCompra on devolucionCompradetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra Where DevolucionCompraDetalle.IDDevolucionCompra='" + txtIDDevolucion.Text + "'", Con)
            Dim LectorArticulos As MySqlDataReader = Cmd.ExecuteReader

            While LectorArticulos.Read
                DgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), LectorArticulos.GetValue(10), LectorArticulos.GetValue(11), LectorArticulos.GetValue(12), LectorArticulos.GetValue(13), LectorArticulos.GetValue(14))
            End While

            LectorArticulos.Close()
            Con.Close()
            CalcDevolucion()
            PropiedadDgvArticulos()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnBuscarMotivo_Click(sender As Object, e As EventArgs) Handles btnBuscarMotivo.Click
        frm_buscar_mot_devolucion.ShowDialog(Me)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CalcBces()
        FunctCalcBcesFactSuplidor(txtIDSuplidor.Text)
        FunctCalcBceSuplidor(txtIDSuplidor.Text)
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=7", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE DevolucionCompra SET SecondID='" + lblSecondID.Text + "' WHERE IDDevolucionCompra='" + txtIDDevolucion.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=7"
            GuardarDatos()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub UpdateNCFModificado()
        sqlQ = "UPDATE Compras SET NCFModificado='" + txtNCFDev.Text + "' WHERE IDCompra= (" + lblIDCompra.Text + ")"
        GuardarDatos()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim SumaDev As Double = 0

        For Each Rows As DataGridViewRow In DgvArticulos.Rows
            SumaDev = CDbl(Rows.Cells(12).Value) + SumaDev
        Next

        If txtFactura.Text = "" Then
            MessageBox.Show("Escriba el código o número de registro de la factura de compra para procesar la devolución de artículos.", "Escribir No. Factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtFactura.Focus()
            Exit Sub
        ElseIf txtIDMotivoDevolucion.Text = "" Then
            MessageBox.Show("Seleccione el motivo de la devolución de compras.", "Seleccionar motivo de devolución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarMotivo.PerformClick()
            Exit Sub
        ElseIf SumaDev = 0 Then
            MessageBox.Show("No se han incluido el/los artículos para la devolución de compras." & vbNewLine & "Por favor indique los artículos a devolver.", "Indicar artículos a devolución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf CDbl(txtMontoDevolver.Text) > CDbl(txtBalanceFactura.Text) Then
            MessageBox.Show("No se puede procesar la devolución de artículos ya que el monto a devolver excede el balance de la factura.", "Excede el balance", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf ImponerEscrituradeNCF = 1 And txtNCFDev.MaskFull = False Then
            MessageBox.Show("El tipo de comprobante fiscal seleccionado obliga a la escritura del NCF completamente. Por favor ingrese el número de comprobante fiscal.", "NCF incompleto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtNCF.Focus()
            Exit Sub
        End If

        If txtIDDevolucion.Text = "" Then 'Si no hay pago
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la devolución de la compra No. " & txtFactura.Text & " en la base de datos?", "Guardar Nueva Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO Devolucioncompra (IDTipoDocumento,IDUsuario,Fecha,Hora,IDSucursal,IDAlmacen,IDFactura,NCF,IDMotivoDevolucion,DevolverItbis,Devolver,Itbis,Neto,DiasTransaccion,Impreso,Nulo) VALUES (7,'" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + lblIDAlmacen.Text + "','" + lblIDCompra.Text + "','" + txtNCFDev.Text + "','" + txtIDMotivoDevolucion.Text + "','" + lblDevItbis.Text + "','" + txtMontoDevolver.Text + "','" + txtItbis.Text + "','" + txtTotal.Text + "','" + txtDias.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltDevolucion()
                SetSecondID()
                InsertDevolucionDetalle()
                CalcBces()
                CalcExistencias()
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
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la devolución de la compra?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE Devolucioncompra SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDFactura='" + lblIDCompra.Text + "',NCF='" + txtNCFDev.Text + "',DevolverItbis='" + lblDevItbis.Text + "',Devolver='" + txtMontoDevolver.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtTotal.Text + "',DiasTransaccion='" + txtDias.Text + "',IDMotivoDevolucion='" + txtIDMotivoDevolucion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDDevolucionCompra= (" + txtIDDevolucion.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertDevolucionDetalle()
                CalcBces()
                CalcExistencias()
                UpdateNCFModificado()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_devoluciones_compras.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim SumaDev As Double = 0

        For Each Rows As DataGridViewRow In DgvArticulos.Rows
            SumaDev = CDbl(Rows.Cells(12).Value) + SumaDev
        Next

        If txtFactura.Text = "" Then
            MessageBox.Show("Escriba el código o número de registro de la factura de compra para procesar la devolución de artículos.", "Escribir No. Factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtFactura.Focus()
            Exit Sub
        ElseIf txtIDMotivoDevolucion.Text = "" Then
            MessageBox.Show("Seleccione el motivo de la devolución de compras.", "Seleccionar motivo de devolución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarMotivo.PerformClick()
            Exit Sub
        ElseIf SumaDev = 0 Then
            MessageBox.Show("No se han incluido el/los artículos para la devolución de compras." & vbNewLine & "Por favor indique los artículos a devolver.", "Indicar artículos a devolución", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf txtIDDevolucion.text = "" And CDbl(txtMontoDevolver.Text) > CDbl(txtBalanceFactura.Text) Then
            MessageBox.Show("No se puede procesar la devolución de artículos ya que el monto a devolver excede el balance de la factura.", "Excede el balance", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If Permisos(1) = 0 Then
            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La devolución No. " & txtIDDevolucion.Text & " de la compra " & txtFactura.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 38
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                chkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE Devolucioncompra SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDFactura='" + lblIDCompra.Text + "',NCF='" + txtNCFDev.Text + "',DevolverItbis='" + lblDevItbis.Text + "',Devolver='" + txtMontoDevolver.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtTotal.Text + "',DiasTransaccion='" + txtDias.Text + "',IDMotivoDevolucion='" + txtIDMotivoDevolucion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDDevolucionCompra= (" + txtIDDevolucion.Text + ")"
                GuardarDatos()
                CalcBces()
                ConvertCurrent()
                CalcExistencias()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDDevolucion.Text = "" Then
            MessageBox.Show("No hay un registro de devolución de compras abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular la devolución No. " & txtIDDevolucion.Text & " de la factura No. " & txtFactura.Text & " del sistema?", "Anular Devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 37
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                chkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE Devolucioncompra SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + lblIDAlmacen.Text + "',IDFactura='" + lblIDCompra.Text + "',NCF='" + txtNCFDev.Text + "',DevolverItbis='" + lblDevItbis.Text + "',Devolver='" + txtMontoDevolver.Text + "',Itbis='" + txtItbis.Text + "',Neto='" + txtTotal.Text + "',DiasTransaccion='" + txtDias.Text + "',IDMotivoDevolucion='" + txtIDMotivoDevolucion.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDDevolucionCompra= (" + txtIDDevolucion.Text + ")"
                GuardarDatos()
                CalcBces()
                ConvertCurrent()
                CalcExistencias()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub txtNCFDev_Leave(sender As Object, e As EventArgs) Handles txtNCFDev.Leave
        txtNCFDev.Text = txtNCFDev.Text.ToUpper
    End Sub

    Private Sub frm_devolucion_compras_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadDgvArticulos()
    End Sub

    Private Sub FillAlmacen()

        Ds.clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Almacen FROM Almacen INNER JOIN Empleados on Almacen.IDAlmacen=Empleados.IDAlmacen Where IDEmpleado='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "' ORDER BY Almacen.Almacen ASC", Con)
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

    Private Sub CbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxAlmacen.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + CbxAlmacen.SelectedItem + "'", Con)
        lblIDAlmacen.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub dgvArticulosFactura_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvArticulos.CellFormatting
        If e.ColumnIndex = Me.DgvArticulos.Columns(14).Index AndAlso (e.Value IsNot Nothing) Then

            With Me.DgvArticulos.Rows(e.RowIndex).Cells(e.ColumnIndex)
                Dim IDAlmacen As String = DgvArticulos.CurrentRow.Cells(14).Value
                Con.Open()
                cmd = New MySqlCommand("Select Almacen from Almacen where IDAlmacen='" + IDAlmacen + "'", Con)
                Dim Almacen As String = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                .ToolTipText = Almacen
            End With
        End If
    End Sub

    Private Sub dgvarticulos_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvArticulos.CellMouseMove
        If e.ColumnIndex = 14 Then
            If DgvArticulos.Rows.Count = 0 Then
            Else
                Cursor.Current = Cursors.Hand
            End If
        End If
    End Sub

    Private Sub dgvarticulos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 12 Then
                DgvArticulos.EditMode = DataGridViewEditMode.EditOnEnter
            ElseIf e.ColumnIndex = 14 Then
                frm_cambiar_almacenes_fact.IDPrecios.Text = DgvArticulos.CurrentRow.Cells(2).Value
                frm_cambiar_almacenes_fact.Show(Me)
            End If
        End If
    End Sub

    Private Sub BuscarDevoluciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarDevoluciónToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub
End Class