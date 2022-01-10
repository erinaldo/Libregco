Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_proceso_pagares

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Dim lblIDFactura As New Label
    Dim EvitSabado, EvitDomingo, IDTipoPagareDefault, TipoPagareDefault, DefaultIDCobrador As String
    Dim CbxTipoPagare As New DataGridViewComboBoxColumn
    Dim btnDelete As New DataGridViewButtonColumn

    Private Sub frm_proceso_pagares_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        Permisos = PasarPermisos(Me.Tag)
        CargarConfiguracion()
        CargarLibregco()
        CargarEmpresa()
        ColumnsDgvPagares()
        CargarCbxTipoPagares()
    End Sub

    Private Sub CargarConfiguracion()
        Con.Open()
        ConLibregco.Open()

        'Evitar Sabados en pagares
        cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=50", Con)
        EvitSabado = Convert.ToString(cmd.ExecuteScalar())

        'Evitar Domingos en pagares
        cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=51", Con)
        EvitDomingo = Convert.ToString(cmd.ExecuteScalar())

        'IDTipoPagare Default
        cmd = New MySqlCommand("SELECT IDTipoPagare FROM tipopagare where IDTipoPagare= (Select Min(IDTipoPagare) from TipoPagare)", ConLibregco)
        IDTipoPagareDefault = Convert.ToString(cmd.ExecuteScalar())

        'TipoPagare Default
        cmd = New MySqlCommand("SELECT TipoPagare FROM tipopagare where IDTipoPagare= (Select Min(IDTipoPagare) from TipoPagare)", ConLibregco)
        TipoPagareDefault = Convert.ToString(cmd.ExecuteScalar())

        'Cobrador Predeterminado
        cmd = New MySqlCommand("SELECT Value2Int FROM configuracion where IDConfiguracion=25", Con)
        DefaultIDCobrador = Convert.ToString(cmd.ExecuteScalar())
      
        Con.Close()
        ConLibregco.Close()
    End Sub
    Private Sub ColumnsDgvPagares()
        Try
            DgvPagares.Columns.Add("IDPagare", "ID") '0
            DgvPagares.Columns.Add("IDTipoPagare", "IDTipoPagare") '1
            DgvPagares.Columns.Add(CbxTipoPagare) '2
            DgvPagares.Columns.Add("Numero", "No.") '3
            DgvPagares.Columns.Add("Cantidad", "Cantidad") '4
            DgvPagares.Columns.Add("Monto", "Monto RD$") '5
            DgvPagares.Columns.Add("Vencimiento", "Vencimiento") '6
            DgvPagares.Columns.Add("Concepto", "Concepto") '7
            DgvPagares.Columns.Add(btnDelete)
            PropiedadDgvPagares()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If txtFactura.Text = "" Then
                MessageBox.Show("Escriba el número de la factura en la que desea generar los pagarés.", "No. de factura vacío", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                frm_consulta_ventas.ShowDialog(Me)
            Else
                Con.Open()
                cmd = New MySqlCommand("Select IDFacturaDatos from FacturaDatos Where SecondID='" + txtFactura.Text + "'", Con)
                lblIDFactura.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If lblIDFactura.Text = "" Then
                    MessageBox.Show("No se encontró ningun resultado en la búsqueda.", "No existe factura con esa numeración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    Ds.Clear()
                    ConMixta.Open()
                    cmd = New MySqlCommand("Select FacturaDatos.SecondID,FacturaDatos.IDCondicion,Condicion.Condicion,Condicion.Dias,FacturaDatos.DiasCondicion,FacturaDatos.IDCliente,NombreFactura,DireccionFactura,TelefonosFactura,Clientes.Nombre,IDFacturaDatos,FacturaDatos.SecondID,IDTipoDocumento,IDTransaccion,Fecha,Hora,FacturaDatos.Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,NetoFactura,FacturaDatos.Balance,FechaVencimiento,CondicionContado,SubTotal,Descuento,Itbis,Flete,TotalNeto,Observacion,Clientes.IDCalificacion,Calificacion.Calificacion,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=FacturaDatos.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as Cobrador,Clientes.BalanceGeneral,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.IDVehiculo,Vehiculo.DatoVehiculo,FacturaDatos.IDVendedor,Vendedor.Nombre as Vendedor,FacturaDatos.IDChofer,Chofer.Nombre as Chofer,FacturaDatos.IDAlmacen,Almacen.Almacen,HabilitarFicha,NotaContado,FacturaDatos.EntregarPorConduce,FacturaDatos.Nulo from" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN" & SysName.Text & "Vehiculo on FacturaDatos.IDVehiculo=Vehiculo.IDVehiculo INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Chofer on FacturaDatos.IDChofer=Chofer.IDEmpleado INNER JOIN" & SysName.Text & "Almacen on FacturaDatos.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where IDFacturaDatos='" + lblIDFactura.Text + "' AND Condicion.Dias>0", ConMixta)
                     Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "FacturaDatos")
                    ConMixta.Close()

                    Dim Tabla As DataTable = Ds.Tables("FacturaDatos")

                    lblCliente.Text = "[" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("NombreFactura"))
                    lblFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy")
                    lblCondicion.Text = "[" & (Tabla.Rows(0).Item("IDCondicion")) & "] " & (Tabla.Rows(0).Item("Condicion"))
                    lblCantidadPagos.Text = (Tabla.Rows(0).Item("CantidadPagos"))
                    lblMontoPagos.Text = CDbl(Tabla.Rows(0).Item("MontoPagos")).ToString("C")
                    lblFrecuencia.Text = (Tabla.Rows(0).Item("DiasCondicion"))
                    lblPagoAdicional.Text = CDbl(Tabla.Rows(0).Item("PagoAdicional")).ToString("C")
                    If IsDate(Tabla.Rows(0).Item("FechaAdicional")) Then
                        lblFechaAdicional.Text = CDate(Tabla.Rows(0).Item("FechaAdicional")).ToString("dd/MM/yyyy")
                    Else
                        lblFechaAdicional.Text = ""
                    End If
                    lblMontoPagar.Text = CDbl(Tabla.Rows(0).Item("NetoFactura")).ToString("C")
                    lblVencimiento.Text = CDate(Tabla.Rows(0).Item("FechaVencimiento")).ToString("dd/MM/yyyy")
                    lblTotalNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")

                    'Buscar Pagares
                    ConMixta.Open()
                    DgvPagares.Rows.Clear()
                    Dim CmdPagares As New MySqlCommand("SELECT IDPagare,pagares.IDTipoPagare,TipoPagare,NoPagare,Cantidad,Monto,FechaVencimiento,Pagares.Concepto from" & SysName.Text & "pagares INNER JOIN Libregco.TipoPagare on Pagares.IDTipoPagare=TipoPagare.IDTipoPagare Where Pagares.IDFactura='" + lblIDFactura.Text + "'", ConMixta)
                    Dim Lectorpagare As MySqlDataReader = CmdPagares.ExecuteReader

                    While Lectorpagare.Read
                        DgvPagares.Rows.Add(Lectorpagare.GetValue(0), Lectorpagare.GetValue(1), Lectorpagare.GetValue(2), Lectorpagare.GetValue(3), Lectorpagare.GetValue(4), CDbl(Lectorpagare.GetValue(5)).ToString("C"), CDate(Lectorpagare.GetValue(6)).ToString("dd/MM/yyyy"), Lectorpagare.GetValue(7))
                    End While

                    Lectorpagare.Close()
                    ConMixta.Close()

                    If DgvPagares.Rows.Count = 0 Then
                        MessageBox.Show("No se encuentran pagarés generados en la factura No. " & txtFactura.Text & ".", "No pagarés", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    If CDbl(lblPagoAdicional.Text) > 0 Then
                        If CInt(DgvPagares.Rows.Count) = CInt(lblCantidadPagos.Text) + 1 Then
                            btnGenerar.Enabled = False
                        Else
                            btnGenerar.Enabled = True
                        End If
                    Else
                        If DgvPagares.Rows.Count = lblCantidadPagos.Text Then
                            btnGenerar.Enabled = False
                        Else
                            btnGenerar.Enabled = True
                        End If
                    End If
                End If
            End If

            txtFactura.Enabled = False

        Catch ex As Exception
            '  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub PropiedadDgvPagares()
        Try

            If DgvPagares.Columns.Count > 0 Then
                DgvPagares.Columns(0).ReadOnly = True
                DgvPagares.Columns(0).Width = 100
                DgvPagares.Columns(0).DefaultCellStyle.BackColor = Color.LightGray
                DgvPagares.Columns(1).Visible = False
                DgvPagares.Columns(2).Width = 130
                DgvPagares.Columns(2).HeaderText = "Tipo"
                DgvPagares.Columns(3).Width = 40
                DgvPagares.Columns(4).Width = 70
                DgvPagares.Columns(4).ReadOnly = True
                DgvPagares.Columns(5).Width = 100
                DgvPagares.Columns(6).Width = 90
                DgvPagares.Columns(6).DefaultCellStyle.Format = "dd/MM/yyyy"
                DgvPagares.Columns(7).Width = 450
                CbxTipoPagare.FlatStyle = FlatStyle.Flat

            End If

            With btnDelete
                .Width = 80
                .UseColumnTextForButtonValue = True
                .HeaderText = "Eliminar"
                .Text = ""
                .DefaultCellStyle.Font = New Font("Arial", 8)
            End With

        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub SetImageToDataGridViewButtonColumn_CallInCellPaintingEvent(ByRef img As Bitmap, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs)
        e.Paint(e.CellBounds, DataGridViewPaintParts.All & (DataGridViewPaintParts.ContentBackground) & (DataGridViewPaintParts.ContentForeground))
        Dim destRect As Rectangle = New Rectangle(e.CellBounds.X + (e.CellBounds.Width - img.Width) / 2, e.CellBounds.Y + (e.CellBounds.Height - img.Height) / 2, img.Width, img.Height)
        Dim srcRect As Rectangle = New Rectangle(0, 0, img.Width, img.Height)
        e.Graphics.DrawImage(img, destRect, srcRect, GraphicsUnit.Pixel)
        e.Handled = True
    End Sub

    Private Sub CargarCbxTipoPagares()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT TipoPagare FROM tipopagare Order by IDTipoPagare ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "tipopagare")
        CbxTipoPagare.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds1.Tables("tipopagare")

        CbxTipoPagare.DataSource = Tabla
        CbxTipoPagare.DisplayMember = "tipoPagare"

        PropiedadDgvPagares()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
   PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub DgvPagares_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPagares.CellEndEdit
        DgvPagares.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvPagares_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvPagares.CurrentCellDirtyStateChanged
        If DgvPagares.IsCurrentCellDirty Then
            DgvPagares.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub ComboBox_SelectionchangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim combo As ComboBox = CType(sender, ComboBox)

            Dim Descripcion As New Label
            Descripcion.Text = DgvPagares.CurrentRow.Cells(2).Value

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDTipoPagare from TipoPagare where TipoPagare='" + Descripcion.Text + "'", ConLibregco)
            DgvPagares.CurrentRow.Cells(1).Value = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub

    Private Sub DgvPagares_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvPagares.EditingControlShowing
        'REMEMBER TO CHANGE THE COLUMN INDEX NUMBER TO YOUR COMBOBOX INDEX!!
        If DgvPagares.CurrentCell.ColumnIndex = 2 Then
            Dim combo As ComboBox = CType(e.Control, ComboBox)
            If (combo IsNot Nothing) Then
                ' Remove an existing event-handler, if present, to avoid adding multiple handlers when the editing control is reused.
                RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)

                ' Add the event handler.
                AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)

            End If

        End If
    End Sub

    Private Sub DgvPagares_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPagares.CellValueChanged
        Try
            If DgvPagares.Rows.Count > 0 Then
                If e.ColumnIndex = 2 Then
                    Dim Descripcion As New Label
                    Descripcion.Text = DgvPagares.CurrentRow.Cells(2).Value

                    ConLibregco.Open()
                    cmd = New MySqlCommand("SELECT IDTipoPagare from TipoPagare where TipoPagare='" + Descripcion.Text + "'", ConLibregco)
                    DgvPagares.CurrentRow.Cells(1).Value = Convert.ToString(cmd.ExecuteScalar())
                    ConLibregco.Close()
                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        lblCliente.Text = ""
        lblFecha.Text = ""
        lblCondicion.Text = ""
        lblCantidadPagos.Text = ""
        lblMontoPagar.Text = ""
        lblMontoPagos.Text = ""
        lblFrecuencia.Text = ""
        lblPagoAdicional.Text = ""
        lblFechaAdicional.Text = ""
        lblVencimiento.Text = ""
        lblTotalNeto.Text = ""
        DgvPagares.Rows.Clear()
        Button1.Enabled = True
        txtFactura.Enabled = True
        txtFactura.Clear()
        btnGenerar.Enabled = False
    End Sub


    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim CantPag As Integer
        Dim Letras As String
        Dim DateTake As Date = lblFecha.Text

        CantPag = CDbl(lblCantidadPagos.Text)

        For i = 1 To CantPag
            Dim Founded As Boolean = False
            For Each row As DataGridViewRow In DgvPagares.Rows
                If IsNumeric(row.Cells(3).Value) Then
                    If row.Cells(3).Value = i Then
                        Founded = True
                        Exit For
                    End If
                End If
            Next
            If Founded = False Then
                Letras = "BUENO Y VÁLIDO POR " & ConvertNumbertoString(lblMontoPagos.Text)

                DateTake = CDate(lblFecha.Text)

                For u = 1 To i
                    DateTake = DateTake.AddDays(30)

                    If EvitSabado = 1 Then
                        If DateTake.DayOfWeek = DayOfWeek.Saturday Then
                            DateTake = DateTake.AddDays(1)
                        End If
                    End If
                    If EvitDomingo = 1 Then
                        If DateTake.DayOfWeek = DayOfWeek.Sunday Then
                            DateTake = DateTake.AddDays(1)
                        End If
                    End If
                Next

                DgvPagares.Rows.Add("", IDTipoPagareDefault, TipoPagareDefault, i, lblCantidadPagos.Text, lblMontoPagos.Text, DateTake.ToString("dd/MM/yyyy"), Letras)

            End If
        Next
        Dim Found As Boolean = False
        For Each row As DataGridViewRow In DgvPagares.Rows
            If CStr(row.Cells(3).Value).ToString = "ADC" Then
                Found = True
                Exit For
            End If
        Next
        If Found = False Then
          
            Letras = "BUENO Y VÁLIDO POR " & ConvertNumbertoString(lblPagoAdicional.Text)

            If IsNumeric(lblPagoAdicional.Text) Then
                If CDbl(lblPagoAdicional.Text) > 0 Then
                    DgvPagares.Rows.Add("", 2, "Adicional", "ADC", "ADC", lblPagoAdicional.Text, CDate(lblFechaAdicional.Text).ToString("dd/MM/yyyy"), Letras)
                End If
            End If


        End If
 
















        '        DgvPagares.Rows.Clear()

        '        Dim lblNoPagare, txtFechaVencimiento, CvtLetra, Concepto As New Label
        '        'Dim MontoDecimal As Decimal = CDbl(lblMontoPagos.Text)
        '        'Dim DecimalResult As Decimal = MontoDecimal - Int(MontoDecimal)
        '        'Dim DecimalResulttoString As String
        '        'Dim Monto As Integer = MontoDecimal - DecimalResult
        '        Dim Valor As Integer = lblCantidadPagos.Text
        '        Dim Dias As Integer = lblFrecuencia.Text
        '        Dim DateTake As Date = Today

        '        If DecimalResult > 0 Then
        '            DecimalResulttoString = "CON " & CInt(DecimalResult * 100) & "/100"
        '        Else
        '            DecimalResulttoString = ""
        '        End If

        '        If CDbl(lblMontoPagos.Text) > 0 Then
        '            lblNoPagare.Text = 1
        '            CvtLetra.Text = Num2Text(CInt(Monto))
        '            Concepto.Text = "BUENO Y VÁLIDO POR " & CvtLetra.Text & " PESOS" & DecimalResulttoString

        'Start:
        '            DateTake = DateTake.AddDays(lblFrecuencia.Text)

        '            If EvitSabado = 1 Then
        '                If DateTake.DayOfWeek = DayOfWeek.Saturday Then
        '                    DateTake = DateTake.AddDays(1)
        '                Else
        '                End If
        '            End If
        '            If EvitDomingo = 1 Then
        '                If DateTake.DayOfWeek = DayOfWeek.Sunday Then
        '                    DateTake = DateTake.AddDays(1)
        '                End If
        '            End If

        '            If Valor = DgvPagares.Rows.Count Then
        '                GoTo Final
        '            Else
        '                DgvPagares.Rows.Add("", IDTipoPagareDefault, TipoPagareDefault, lblNoPagare.Text, lblCantidadPagos.Text, lblMontoPagos.Text, DateTake.ToString("dd/MM/yyyy"), Concepto.Text)

        '                lblNoPagare.Text = CInt(lblNoPagare.Text) + 1

        '                GoTo Start
        '            End If
        '        End If
        'Final:

        '        Dim MontoAdicional As Integer = lblPagoAdicional.Text

        '        CvtLetra.Text = Num2Text(CInt(MontoAdicional))
        '        Concepto.Text = "BUENO Y VÁLIDO POR " & CvtLetra.Text & " PESOS"

        '        If MontoAdicional = 0 Then
        '        Else
        '            DgvPagares.Rows.Add("", 2, "Adicional", "ADC", lblCantidadPagos.Text, lblPagoAdicional.Text, CDate(lblFechaAdicional.Text).ToString("dd/MM/yyyy"), Concepto.Text)

        '        End If

    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim lblIDPagare, lblIDTipo, lblNoPagare, lblCantidad, lblFechaVencimiento, lblConcepto, lblMonto, lblIDStatus, lblIDEmpleado, lblNota, lblNulo As New Label
        If lblIDFactura.Text = "" Then
            MessageBox.Show("Escriba un número de factura valida para procesar nuevos pagarés.", "Seleccionar pagarés", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtFactura.Focus()
            Exit Sub
        ElseIf DgvPagares.Rows.Count = 0 Then
            MessageBox.Show("Genere los pagarés de la factura para continuar con el procedimiento.", "Genere los pagarés", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

     
        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los pagarés generados en la factura " & txtFactura.Text & " del cliente " & lblCliente.Text & " en la base de datos?", "Guardar Pagarés", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Con.Open()

            For Each Row As DataGridViewRow In DgvPagares.Rows
                lblIDPagare.Text = Row.Cells(0).Value
                lblIDTipo.Text = Row.Cells(1).Value
                lblNoPagare.Text = Row.Cells(3).Value
                lblCantidad.Text = Row.Cells(4).Value
                lblMonto.Text = CDbl(Row.Cells(5).Value)
                lblFechaVencimiento.Text = CDate(Row.Cells(6).Value).ToString("yyyy-MM-dd")
                lblConcepto.Text = Row.Cells(7).Value
                lblIDEmpleado.Text = DefaultIDCobrador
                lblIDStatus.Text = 1
                lblNota.Text = ""
                lblNulo.Text = 0

                If lblIDPagare.Text = "" Then
                    sqlQ = "INSERT INTO Pagares (IDTipoPagare,IDFactura,NoPagare,Cantidad,FechaVencimiento,DiasVencidos,Concepto,Monto,Balance,BalanceCerrado,IDEmpleado,IDStatusPagare,Nota,Cargado,Nulo) VALUES ('" + lblIDTipo.Text + "','" + lblIDFactura.Text + "','" + lblNoPagare.Text + "','" + lblCantidad.Text + "','" + lblFechaVencimiento.Text + "',0,'" + lblConcepto.Text + "','" + lblMonto.Text + "','" + lblMonto.Text + "','" + lblMonto.Text + "','" + lblIDEmpleado.Text + "','" + lblIDStatus.Text + "','" + lblNota.Text + "',0,'" + lblNulo.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()

                    cmd = New MySqlCommand("Select IDPagare from Pagares where IDPagare= (Select Max(IDPagare) from Pagares)", Con)
                    Row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())

                End If
            Next

            Con.Close()

            MessageBox.Show("Se han insertado satisfactoriamente los pagarés a la base de datos.", "Operación satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

    End Sub


    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        Dim IDPagare As New Label
        IDPagare.Text = DgvPagares.CurrentRow.Cells(0).Value

        If IDPagare.Text = "" Then
            DgvPagares.Rows.Remove(DgvPagares.CurrentRow)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el pagaré ID " & IDPagare.Text & " de la base de datos?", "Eliminar pagaré", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                Con.Open()
                sqlQ = "Delete from Pagares Where IDPagare = (" + IDPagare.Text + ")"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
                Con.Close()

                MessageBox.Show("El pagaré ID " & DgvPagares.CurrentRow.Cells(0).Value & " ha sido eliminado del sistema satisfactoriamente.", "Se ha eliminado el pagaré", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DgvPagares.Rows.Remove(DgvPagares.CurrentRow)
            End If
           
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If frm_pagares.Visible = True Then
            If frm_pagares.WindowState = FormWindowState.Minimized Then
                frm_pagares.WindowState = FormWindowState.Normal
            Else
                frm_pagares.Activate()
            End If
        Else
            frm_pagares.Show(Me)

            If lblIDFactura.Text <> "" Then
                frm_pagares.lblIDFactura.Text = lblIDFactura.Text
                frm_pagares.txtFactura.Text = txtFactura.Text
                frm_pagares.rdbPresentacion.Checked = True
                frm_pagares.btnBuscar.PerformClick()
            End If

        End If

    End Sub

    Private Sub DgvPagares_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DgvPagares.CellPainting
        If (e.ColumnIndex = 8 And e.RowIndex >= 0) Then
            SetImageToDataGridViewButtonColumn_CallInCellPaintingEvent(My.Resources.Delete_x16, e)
        End If
    End Sub

    Private Sub DgvPagares_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPagares.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 8 Then
                If IsNumeric(DgvPagares.CurrentRow.Cells(0).Value) Then

                    Dim Result As MsgBoxResult = MessageBox.Show("Estás seguro que deseas eliminar el pagaré  ID [" & DgvPagares.CurrentRow.Cells(0).Value & "] " & DgvPagares.CurrentRow.Cells(3).Value & "/" & DgvPagares.CurrentRow.Cells(4).Value & "?", "Eliminar pagaré", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                    If Result = MsgBoxResult.Yes Then
                        Con.Open()
                        cmd = New MySqlCommand("SELECT count(IDDetalleRecibo) FROM" & SysName.Text & "recibosdetalle where IDPagare='" + DgvPagares.CurrentRow.Cells(0).Value.ToString + "'", Con)
                        Dim CheckUsedID As Integer = Convert.ToString(cmd.ExecuteScalar())
                        Con.Close()

                        If CheckUsedID > 0 Then
                            MessageBox.Show("Se encontraron transacciones que afectan la integridad del pagaré seleccionado, por lo que no se puede eliminar.", "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        Else
                            Con.Open()
                            sqlQ = "Delete from Pagares Where IDPagare= '" + DgvPagares.CurrentRow.Cells(0).Value.ToString + "'"
                            cmd = New MySqlCommand(sqlQ, Con)
                            cmd.ExecuteNonQuery()
                            Con.Close()
                            DgvPagares.Rows.Remove(DgvPagares.CurrentRow)
                            MessageBox.Show("El pagaré ha sido eliminado satisfactoriamente.", "Pagaré eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            btnGenerar.Enabled = True
                        End If
                    End If
                Else
                    DgvPagares.Rows.Remove(DgvPagares.CurrentRow)
                End If
            End If
        End If
    End Sub
End Class