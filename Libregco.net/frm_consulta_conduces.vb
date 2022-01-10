Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_consulta_conduces

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblNulo, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT IDConduce,Conduce.SecondID,Conduce.Fecha,FacturaDatos.SecondID AS SecondIDFact,FacturaDAtos.IDCliente,FacturaDatos.NombreFactura,Conduce.Neto,Conduce.Nulo FROM" & SysName.Text & "conduce INNER JOIN" & SysName.Text & "FacturaDatos on Conduce.IDFacturaDatos=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente"
    Dim FullCommand, FechaValue, IDClienteValue, IDUsuarioValue, IDFacturaValue, IDConduceValue, NuloValue As String
    Dim A1, A2, A3, A4, A5 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_conduces_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDConduce,Conduce.SecondID,Conduce.Fecha,FacturaDatos.SecondID AS SecondIDFact,FacturaDAtos.IDCliente,FacturaDatos.NombreFactura,Conduce.Neto,Conduce.Nulo FROM" & SysName.Text & "conduce INNER JOIN" & SysName.Text & "FacturaDatos on Conduce.IDFacturaDatos=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente WHERE Conduce.Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Conduce.Nulo=0 ORDER BY IDConduce DESC", Con)
        RefrescarTabla()
        ConstructorSQL()
        FillReportes()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub CargarLibregco()
          PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Conduce' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Conduces' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            End If

            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Reportes")
            CbxFormato.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Reportes")

            For Each Fila As DataRow In Tabla.Rows
                CbxFormato.Items.Add(Fila.Item("Descripcion"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxFormato.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron reportes que involucren este vínculo del módulo.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtCliente.Clear()
        txtIDUsuario.Clear()
        txtUsuario.Clear()
        txtIDCliente.Focus()
        chkNulos.Checked = False
        lblNulo.Text = 0
        txtIDFactura.Clear()
        txtIDConduce.Clear()
        SummaCond()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
    End Sub


    Private Sub RefrescarTabla()
        Try
            Ds.Clear()
            ConMixta.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Conduce")
            DgvConduces.DataSource = Ds
            DgvConduces.DataMember = "Conduce"
            ConMixta.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvConduces.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvConduces
            .Columns(0).Visible = False

            .Columns(1).HeaderText = "No. Conduce"
            .Columns(1).Width = 110

            .Columns(2).HeaderText = "Fecha"
            .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
            .Columns(2).Width = 80

            .Columns(3).Width = 100
            .Columns(3).HeaderText = "No. Factura "

            .Columns(4).Width = 100
            .Columns(4).HeaderText = "Cód. Cliente"

            .Columns(5).Width = 230
            .Columns(5).HeaderText = "Cliente"

            .Columns(6).Width = 120
            .Columns(6).HeaderText = "Neto"
            .Columns(6).DefaultCellStyle.Format = ("C")

            .Columns(7).Visible = False
        End With
    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
Inicio:
        If x = DgvConduces.Rows.Count Then
            GoTo FIn
        End If

        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvConduces.Rows.Count
    End Sub

    Private Sub SelectCliente()
        Try
            Ds1.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Clientes Where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Clientes")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds1.Tables("Clientes")
            txtCliente.Text = (Tabla.Rows(0).Item("Nombre"))

        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " Desde SelectCliente")
            txtCliente.Text = ""
        End Try
    End Sub

    Private Sub SelectUsuario()
        Try
            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDUsuario.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Empleados")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Empleados")
            txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))

        Catch ex As Exception
            txtUsuario.Text = ""
            'MessageBox.Show(ex.Message.ToString & " Desde SelectVendedor")
        End Try
    End Sub

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave
        SelectCliente()
        VerificarCondicionCliente()
    End Sub

    Private Sub txtIDUsuario_Leave(sender As Object, e As EventArgs) Handles txtIDUsuario.Leave
        SelectUsuario()
        VerificarCondicionUsuario()
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If

        VerificarCondicionNulo()
    End Sub

    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub btnBuscarCons_Click(sender As Object, e As EventArgs) Handles btnBuscarCons.Click
        cmd = New MySqlCommand(FullCommand, Con)
        RefrescarTabla()
    End Sub

    Private Sub btnStructure_Click(sender As Object, e As EventArgs) Handles btnStructure.Click
        frm_query_structure.txtQuery.Text = "SQL Query: " & FullCommand
        frm_query_structure.ShowDialog()
    End Sub

    Private Sub txtFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub txtIDUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtIDUsuario.TextChanged
        VerificarCondicionUsuario()
    End Sub

    Private Sub VerificarCondicionUsuario()
        If txtIDUsuario.Text = "" Then
            IDUsuarioValue = ""
        Else
            IDUsuarioValue = " Conduce.IDUsuario=" & txtIDUsuario.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionCliente()
        If txtIDCliente.Text = "" Then
            IDClienteValue = ""
        Else
            IDClienteValue = " Conduce.IDCliente=" & txtIDCliente.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionIDConduce()
        If txtIDConduce.Text = "" Then
            IDConduceValue = ""
        Else
            IDConduceValue = " Conduce.IDConduce=" & txtIDConduce.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionIDFactura()
        If txtIDFactura.Text = "" Then
            IDFacturaValue = ""
        Else
            IDFacturaValue = " Conduce.IDFacturaDatos=" & txtIDFactura.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Value.ToString("yyyy-MM-dd")) And IsDate(txtFechaInicial.Value.ToString("yyyy-MM-dd")) Then
            FechaValue = " Conduce.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 = True Then
            NuloValue = ""
        Else
            NuloValue = " Conduce.Nulo=0 "
        End If

        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionUsuario()
        VerificarCondicionCliente()
        VerificarCondicionFecha()
        VerificarCondicionIDConduce()
        VerificarCondicionIDFactura()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDClienteValue <> "" Or IDUsuarioValue <> "" Or IDConduceValue <> "" Or IDFacturaValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDClienteValue & IDUsuarioValue & IDConduceValue & IDFacturaValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDClienteValue <> "" And IDUsuarioValue & IDConduceValue & IDFacturaValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDUsuarioValue <> "" And IDConduceValue & IDFacturaValue & NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If IDConduceValue <> "" And IDFacturaValue & NuloValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        If IDFacturaValue <> "" And NuloValue <> "" Then
            A5 = " AND"
        Else
            A5 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDClienteValue & A2 & IDUsuarioValue & A3 & IDConduceValue & A4 & IDFacturaValue & A5 & NuloValue
    End Sub


    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvConduces.Rows
                If CInt(Row.Cells(7).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtIDConduce_Leave(sender As Object, e As EventArgs) Handles txtIDConduce.Leave
        VerificarCondicionIDConduce()
    End Sub


    Private Sub txtIDFactura_Leave(sender As Object, e As EventArgs) Handles txtIDFactura.Leave
        VerificarCondicionIDFactura()
    End Sub

    Private Sub LoadAnimation()
        If PicLoading.Visible = False Then
            PicLoading.Visible = True
            ToolSeparator.Visible = True
            lblStatusBar.Text = "Cargando..."
        Else
            PicLoading.Visible = False
            ToolSeparator.Visible = False
            lblStatusBar.Text = "Listo"
        End If
    End Sub


    Private Sub btnPresentar_Click(sender As Object, e As EventArgs) Handles btnPresentar.Click
        Try
            Dim DsSP As New DataSet

            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then
                frm_reportView.ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text)
            Else
                frm_reportView.ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))
            End If

            If DgvConduces.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting

            If rdbGeneral.Checked = True Then
                '@IDUsuario
                If txtIDUsuario.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDUsuario.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Almacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Cliente
                If txtIDCliente.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDCliente.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cliente")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Condicion
                crParameterDiscreteValue.Value = 0
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Condicion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Estado
                If chkNulos.Checked = True Then
                    crParameterDiscreteValue.Value = 2
                Else
                    crParameterDiscreteValue.Value = 0
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Articulo
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Articulo")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Fecha
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Fecha")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterRangeValue = New ParameterRangeValue

                With crParameterRangeValue
                    .StartValue = txtFechaInicial.Value.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = txtFechaFinal.Value.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With

                crParameterValues.Add(crParameterRangeValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Medida
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Medida")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@NoConduce
                If txtIDConduce.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDConduce.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NoConduce")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@NoFactura
                If txtIDFactura.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDFactura.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NoFactura")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'Setting Info 
                'Resumir Reporte
                If chkResumir.Checked = True Then
                    ObjRpt.SetParameterValue("@Resumir", 1)
                Else
                    ObjRpt.SetParameterValue("@Resumir", 0)
                End If
                'Ordenamiento de Reporte
                ObjRpt.SetParameterValue("@SortedField", "")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Factura")
                'RangoFechas()
                ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ''Almacenes
                ObjRpt.SetParameterValue("Almacenes", "Todos los almacenes")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvConduces.SelectedRows.Count > 0 Then
                    Dim IDConduce As New Label
                    IDConduce.Text = DgvConduces.SelectedRows(0).Cells(0).Value

                    If DgvConduces.SelectedRows(0).Cells(7).Value = 1 Then
                        MessageBox.Show("El conduce " & DgvConduces.SelectedRows(0).Cells(1).Value & " de fecha " & DgvConduces.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar la factura.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    Dim cmdSP As New MySqlCommand
                    Dim AdaptadorSP As MySqlDataAdapter

                    'Consulta de los datos de la cotizacion   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    AdaptadorSP = New MySqlDataAdapter("Select Conduce.IDConduce,Conduce.IDTipoDocumento,TipoDocumento.Documento,Conduce.SecondID,Conduce.IDUsuario,Usuarios.Nombre as NombreUsuario,Conduce.IDFacturaDatos,FacturaDatos.SecondID AS SecondIDFact,FacturaDatos.Fecha as FechaFact,FacturaDatos.Hora as HoraFact,FacturaDatos.IDAlmacen,Almacen.Almacen,FacturaDatos.IDCondicion,Condicion.Condicion,FacturaDatos.IDVendedor,Vendedor.Nombre as NombreVendedor,Conduce.Fecha,Conduce.Hora,FacturaDatos.IDCliente,FacturaDatos.NombreFactura AS Nombre,FacturaDatos.IdentificacionFactura as Identificacion,FacturaDatos.DireccionFactura as Direccion,NombreFactura,DireccionFactura,TelefonosFactura,IdentificacionFactura,Conduce.Entregado,Conduce.Observacion,Conduce.SubTotal,Conduce.Itbis,Conduce.Neto,Conduce.Nulo,Conduce.Impreso,FacturaArticulos.IDArticulo,FacturaArticulos.Descripcion,Articulos.Referencia,FacturaArticulos.IDPrecio as IDPrecioVendida,PrecioArticuloVendido.Contenido as ContenidoVendido,FacturaArticulos.Cantidad as CantidadVendida,FacturaArticulos.IDMedida,MedidaComprada.Medida as MedidaVendida,ConduceDetalle.IDPrecio as IDPrecioEntregado,PrecioArticuloEntregada.IDMedida as IDMedidaEntregada,PrecioArticuloEntregada.Contenido as ContenidoEntregado,ConduceDetalle.Entregar as CantidadEntregada,MedidaEntregada.Medida as MedidaEntregada,ConduceDetalle.Precio as PrecioArticulo,ConduceDetalle.Itbis as ItbisArticulo,ConduceDetalle.Importe as ImporteArticulo,FacturaArticulos.Itbis as ItbisArt,FacturaArticulos.Importe,MostrarPrecios,round(((Cantidad*PrecioArticuloVendido.contenido)-(select coalesce(Sum(Entregar*PrecioArticuloConduce.Contenido),0) from" & SysName.Text & "ConduceDetalle inner join Libregco.PrecioArticulo as PrecioArticuloConduce on ConduceDetalle.IDPrecio=PrecioArticuloConduce.IDPrecios Where FacturaArticulos.IDFactArt=ConduceDetalle.IDFactArt))/PrecioArticulo.Contenido,4) as Disponible from" & SysName.Text & "FacturaArticulos INNER JOIN" & SysName.Text & "FacturaDatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.PrecioArticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN" & SysName.Text & "ConduceDetalle on FacturaArticulos.IDFactArt=ConduceDetalle.IDFactArt INNER JOIN" & SysName.Text & "Conduce on ConduceDetalle.IDConduce=Conduce.IDConduce INNER JOIN" & SysName.Text & "TipoDocumento on Conduce.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Empleados as Usuarios on Conduce.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Almacen on FacturaDatos.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Articulos on FacturaArticulos.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.PrecioArticulo as PrecioArticuloVendido on FacturaArticulos.IDPrecio=PrecioArticuloVendido.IDPrecios INNER JOIN Libregco.Medida as MedidaComprada on FacturaArticulos.IDMedida=MedidaComprada.IDMedida INNER JOIN Libregco.PrecioArticulo as PrecioArticuloEntregada on ConduceDetalle.IDPrecio=PrecioArticuloEntregada.IDPrecios INNER JOIN Libregco.Medida as MedidaEntregada on PrecioArticuloEntregada.IDMedida=MedidaEntregada.IDMedida WHERE Conduce.IDConduce='" + DgvConduces.SelectedRows(0).Cells(0).Value.ToString + "'", ConMixta)
                    AdaptadorSP.Fill(DsSP, "ConducesView")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    'Llenado EmpresaView
                    AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
                    AdaptadorSP.Fill(DsSP, "EmpresaView")

                    cmdSP.Dispose()
                    AdaptadorSP.Dispose()

                    frm_reportView.ObjRpt.Database.Tables("conducesview1").SetDataSource(DsSP.Tables("ConducesView"))
                    frm_reportView.ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))


                    'crParameterDiscreteValue.Value = IDConduce.Text
                    'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    'crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                    'crParameterValues.Add(crParameterDiscreteValue)
                    'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                Else
                    MessageBox.Show("No hay una fila seleccionada.")
                    Exit Sub
                End If
            End If

            LoadAnimation()

            If rdbPresentacion.Checked = True Then
                lblStatusBar.Text = "Visualizando el reporte..."

                Dim TmpForm = New frm_reportView
                TmpForm.Text = "Visualizacion de reportes /" & Me.Text & " / " & CbxFormato.Text
                TmpForm.Show(Me)

                TmpForm.CrystalViewer.ReportSource = Nothing
                TmpForm.CrystalViewer.ReportSource = frm_reportView.ObjRpt
                TmpForm.CrystalViewer.Refresh()
                TmpForm.CrystalViewer.Cursor = Cursors.Default

                lblStatusBar.Text = "Listo"

            ElseIf rdbImpresora.Checked = True Then
                lblStatusBar.Text = "Reporte en impresión..."
                Dim PrintDialog As New PrintDialog

                With PrintDialog
                    .AllowSelection = True
                    .AllowSomePages = True
                    .AllowPrintToFile = True
                End With

                If (PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    Me.Cursor = Cursors.WaitCursor

                    Dim PrinterSettings1 As New Printing.PrinterSettings
                    Dim PageSettings1 As New Printing.PageSettings

                    PrinterSettings1.PrinterName = PrintDialog.PrinterSettings.PrinterName
                    PrinterSettings1.Collate = PrintDialog.PrinterSettings.Collate
                    PrinterSettings1.Copies = PrintDialog.PrinterSettings.Copies
                    PrinterSettings1.FromPage = PrintDialog.PrinterSettings.FromPage
                    PrinterSettings1.ToPage = PrintDialog.PrinterSettings.ToPage
                    PageSettings1.PrinterResolution.Kind = PrintDialog.PrinterSettings.DefaultPageSettings.PrinterResolution.Kind

                    frm_reportView.ObjRpt.SummaryInfo.ReportTitle = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy")
                    frm_reportView.ObjRpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName

                    frm_reportView.ObjRpt.PrintToPrinter(PrinterSettings1, PageSettings1, False)

                    Me.Cursor = Cursors.Default
                End If

            ElseIf rdbPDF.Checked = True Then
                lblStatusBar.Text = "Convirtiendo en PDF..."
                Dim GetFileName As New SaveFileDialog
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOtions As New PdfRtfWordFormatOptions

                With GetFileName
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                    .Title = ("Especifique Ubicación")
                    .Filter = "Portable Documento Format (*.pdf)|*.pdf"
                    .FileName = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
                    .AddExtension = True
                End With

                If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
                    CrDiskFileDestinationOptions.DiskFileName = GetFileName.FileName
                    CrExportOptions = ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    ObjRpt.Export()
                    MessageBox.Show("La exportación ha finalizado.", "Exportación satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Process.Start(GetFileName.FileName)
                End If

            ElseIf rdbExcel.Checked = True Then
                lblStatusBar.Text = "Convirtiendo en archivo de Excel..."
                Dim GetFileName As New SaveFileDialog
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOtions As New ExcelFormatOptions

                With GetFileName
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                    .Title = ("Especifique Ubicación")
                    .Filter = "Excel (*.xls)|*.xls"
                    .FileName = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
                    .AddExtension = True
                End With

                If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
                    CrDiskFileDestinationOptions.DiskFileName = GetFileName.FileName
                    CrExportOptions = ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.Excel
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    ObjRpt.Export()
                    MessageBox.Show("La exportación ha finalizado.", "Exportación satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Process.Start(GetFileName.FileName)
                End If
            End If

            LoadAnimation()
            lblStatusBar.Text = "Listo"
            DsSP.Dispose()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Reportes")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("Reportes")
        IDReport.Text = (Tabla.Rows(0).Item("IDReportes"))
        NameReport.Text = (Tabla.Rows(0).Item("Reporte"))
        PathReport.Text = (Tabla.Rows(0).Item("Path"))

        If (Tabla.Rows(0).Item("HabilitadoResumen")) = 0 Then
            chkResumir.Visible = False
        Else
            chkResumir.Visible = True
        End If
    End Sub

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarTipoMemo_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoMemo.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DgvConduces.SelectedRows.Count > 0 Then
            Dim IDConduce As New Label
            IDConduce.Text = DgvConduces.SelectedRows(0).Cells(0).Value

            Ds1.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDConduce,Conduce.SecondID as SecondIDConduce,Conduce.IDFacturaDatos,FacturaDatos.SecondID AS SecondIDFactura,Conduce.Fecha,Conduce.Hora,FechaPrometida,Clientes.IDCliente,Nombre,Clientes.BalanceGeneral,Clientes.Direccion,Clientes.TelefonoPersonal,Conduce.IDAlmacen,Almacen.Almacen,Conduce.IDSucursal,Entregado,Conduce.Observacion,FacturaDatos.Fecha as FechaFactura,Conduce.Nulo,MostrarPrecios FROM" & SysName.Text & "conduce INNER JOIN" & SysName.Text & "FacturaDatos on Conduce.IDFacturaDatos=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "Almacen on Conduce.IDAlmacen=Almacen.IDAlmacen Where IDConduce= '" + IDConduce.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Conduce")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds1.Tables("Conduce")

            frm_conduce.Show(Me)

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

        Else
            MessageBox.Show("No hay una fila seleccionada.")
            End If
        Catch ex As Exception
  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub
End Class