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
Public Class frm_consulta_devolucion_venta

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblNulo, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT IDDevolucionVenta,DevolucionVenta.SecondID,DevolucionVenta.Fecha,FacturaDatos.SecondID,FacturaDatos.NombreFactura as Nombre,DevolucionVenta.IDMotivoDevolucion,Motivodevolucion.Descripcion,Devolver,DevolucionVenta.Nulo,FacturaDatos.IDCliente FROM" & SysName.Text & "devolucionventa INNER JOIN Libregco.MotivoDevolucion on DevolucionVenta.IDMotivoDevolucion=MotivoDevolucion.IDMotivoDevolucion INNER JOIN" & SysName.Text & "FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente"
    Dim FullCommand, FechaValue, IDClienteValue, IDMotivoDevolucionValue, NuloValue, IDFacturaValue As String
    Dim A1, A2, A3, A4 As String
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList


    Private Sub frm_consulta_devolucion_venta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarDatos()
        Actualizar()
        Permisos = PasarPermisos(Me.Tag)
        cmd = New MySqlCommand("SELECT IDDevolucionVenta,DevolucionVenta.SecondID,DevolucionVenta.Fecha,FacturaDatos.SecondID,FacturaDatos.NombreFactura as Nombre,DevolucionVenta.IDMotivoDevolucion,Motivodevolucion.Descripcion,Devolver,DevolucionVenta.Nulo,FacturaDatos.IDCliente FROM" & SysName.Text & "devolucionventa INNER JOIN Libregco.MotivoDevolucion on DevolucionVenta.IDMotivoDevolucion=MotivoDevolucion.IDMotivoDevolucion INNER JOIN" & SysName.Text & "FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente WHERE DevolucionVenta.Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and DevolucionVenta.Nulo=0 ORDER BY IDDevolucionVenta DESC", Con)
        RefrescarTabla()
        ConstructorSQL()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtCliente.Clear()
        txtIDMotivoDevolucion.Clear()
        txtMotivoDevolucion.Clear()
        txtIDFactura.Clear()
        txtIDCliente.Focus()
        chkNulos.Checked = False
        lblNulo.Text = 0
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
            Adaptador.Fill(Ds, "Devolucion")
            DgvDevolucionVenta.DataSource = Ds
            DgvDevolucionVenta.DataMember = "Devolucion"
            ConMixta.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvDevolucionVenta.ClearSelection()
        Catch ex As Exception
            Con.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvDevolucionVenta

            .Columns(0).Visible = False

            .Columns(1).HeaderText = "No. Devolución"
            .Columns(1).Width = 120

            .Columns(2).HeaderText = "Fecha"
            .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
            .Columns(2).Width = 70

            .Columns(3).Width = 100
            .Columns(3).HeaderText = "No. Factura"

            .Columns(4).Width = 275
            .Columns(4).HeaderText = "Cliente"

            .Columns(5).Width = 45
            .Columns(5).HeaderText = "Vend"

            '.Columns(5).Width = 120
            '.Columns(5).HeaderText = "Descripción"
            .Columns(6).Visible = False

            .Columns(7).Width = 130
            .Columns(7).HeaderText = "Monto"
            .Columns(7).DefaultCellStyle.Format = ("C")

            .Columns(8).Visible = False
            .Columns(9).Visible = False
        End With
    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvDevolucionVenta.Rows.Count Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvDevolucionVenta.Rows(x).Cells(7).Value)
        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvDevolucionVenta.Rows.Count
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
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

    Private Sub SelectMotivoDevolucion()
        Try

            Ds1.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM motivodevolucion Where IDMotivoDevolucion='" + txtIDMotivoDevolucion.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "motivodevolucion")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds1.Tables("motivodevolucion")
            txtMotivoDevolucion.Text = (Tabla.Rows(0).Item("Descripcion"))

        Catch ex As Exception
            txtMotivoDevolucion.Text = ""
            'MessageBox.Show(ex.Message.ToString & " Desde SelectIDMotivoDevolucion()")
        End Try
    End Sub

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave
        SelectCliente()
        VerificarCondicionCliente()
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If
        VerificarCondicionNulo()
    End Sub

    Private Sub txtIDMotivoDevolucion_TextChanged(sender As Object, e As EventArgs) Handles txtIDMotivoDevolucion.TextChanged
        VerificarCondicionMotivoDevolucion()
    End Sub

    Private Sub VerificarCondicionMotivoDevolucion()
        If txtIDMotivoDevolucion.Text = "" Then
            IDMotivoDevolucionValue = ""
        Else
            IDMotivoDevolucionValue = " DevolucionVenta.IDMotivoDevolucion=" & txtIDMotivoDevolucion.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionCliente()
        If txtIDCliente.Text = "" Then
            IDClienteValue = ""
        Else
            IDClienteValue = " FacturaDatos.IDCliente=" & txtIDCliente.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Text) And IsDate(txtFechaInicial.Text) Then
            FechaValue = " DevolucionVenta.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
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

    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub VerificarCondicionFacturaValue()
        If txtIDFactura.Text = "" Then
            IDFacturaValue = ""
        Else
            IDFacturaValue = " FacturaDatos.SecondID='" & txtIDFactura.Text & "' "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 = True Then
            NuloValue = ""
        Else
            NuloValue = " DevolucionVenta.Nulo=0 "
        End If
        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionMotivoDevolucion()
        VerificarCondicionCliente()
        VerificarCondicionFecha()
        VerificarCondicionFacturaValue()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDClienteValue <> "" Or IDMotivoDevolucionValue <> "" Or IDFacturaValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDClienteValue & IDMotivoDevolucionValue & IDFacturaValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDClienteValue <> "" And IDMotivoDevolucionValue & IDFacturaValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDMotivoDevolucionValue <> "" And IDFacturaValue & NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If IDFacturaValue <> "" And NuloValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDClienteValue & A2 & IDMotivoDevolucionValue & A3 & IDFacturaValue & A4 & NuloValue

    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvDevolucionVenta.Rows
                If CInt(Row.Cells(8).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub txtIDMotivoDevolucion_Leave(sender As Object, e As EventArgs) Handles txtIDMotivoDevolucion.Leave
        SelectMotivoDevolucion()
    End Sub

    Private Sub btnBuscarMotivoDevolucion_Click(sender As Object, e As EventArgs) Handles btnBuscarMotivoDevolucion.Click
        frm_buscar_mot_devolucion.ShowDialog(Me)
    End Sub

    Private Sub txtIDCliente_TextChanged(sender As Object, e As EventArgs) Handles txtIDCliente.TextChanged
        VerificarCondicionCliente()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub txtIDFactura_TextChanged(sender As Object, e As EventArgs) Handles txtIDFactura.TextChanged
        VerificarCondicionFacturaValue()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DgvDevolucionVenta.SelectedRows.Count > 0 Then

                frm_superclave.IDAccion.Text = 112
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                Dim IDDevolucionVenta As New Label
                IDDevolucionVenta.Text = DgvDevolucionVenta.SelectedRows(0).Cells(0).Value

                Ds1.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("Select IDDevolucionVenta,DevolucionVenta.SecondID,DevolucionVenta.IDUsuario,DevolucionVenta.Fecha,DevolucionVenta.Hora,IDFactura,GenerarNCF,DevolucionVenta.NCF,DevolucionVenta.IDTipoDevolucion,TipoDevolucion.Tipo as Tipo,DevolverItbis,Devolver,DiasTransaccion,DevolucionVenta.IDMotivoDevolucion as IDMotivoDevolucion,MotivoDevolucion.Descripcion as Descripcion,DevolucionVenta.Itbis as ItbisDev,DevolucionVenta.Neto,DevolucionVenta.Nulo,FacturaDatos.SecondID AS SecondIDFact from" & SysName.Text & "DevolucionVenta INNER JOIN Libregco.motivodevolucion on DevolucionVenta.IDMotivoDevolucion=MotivoDevolucion.IDMotivoDevolucion INNER JOIN Libregco.TipoDevolucion on DevolucionVenta.IDTipoDevolucion=TipoDevolucion.IDTipoDevolucion INNER JOIN" & SysName.Text & "FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos Where IDDevolucionVenta='" + IDDevolucionVenta.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "Devolucion")
                ConMixta.Close()

                Dim Tabla As DataTable = Ds1.Tables("Devolucion")

                frm_devolucion_fact.Show()
                frm_devolucion_fact.txtIDDevolucion.Text = (Tabla.Rows(0).Item("IDDevolucionVenta"))
                frm_devolucion_fact.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_devolucion_fact.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_devolucion_fact.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_devolucion_fact.lblIDFactura.Text = Tabla.Rows(0).Item("IDFactura")
                frm_devolucion_fact.txtFactura.Text = (Tabla.Rows(0).Item("SecondIDFact"))
                frm_devolucion_fact.lblNoNCF.Text = (Tabla.Rows(0).Item("NCF"))
                frm_devolucion_fact.txtIDMotivoDevolucion.Text = (Tabla.Rows(0).Item("IDMotivoDevolucion"))
                frm_devolucion_fact.txtMotivoDevolucion.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_devolucion_fact.txtSubtotal.Text = CDbl(Tabla.Rows(0).Item("Devolver")).ToString("C")
                frm_devolucion_fact.txtItbis.Text = CDbl(Tabla.Rows(0).Item("ItbisDev")).ToString("C")
                frm_devolucion_fact.txtTotal.Text = CDbl(Tabla.Rows(0).Item("Neto")).ToString("C")
                frm_devolucion_fact.txtSubtotal.Text = CDbl(Tabla.Rows(0).Item("Devolver")).ToString("C")
                frm_devolucion_fact.FillDgvArticulos()
                frm_devolucion_fact.BuscarDatosdeFactura()
                frm_devolucion_fact.FactStatus()

                If (Tabla.Rows(0).Item("IDTipoDevolucion")) = 1 Then
                    frm_devolucion_fact.rdbVoucher.Checked = True
                ElseIf (Tabla.Rows(0).Item("IDTipoDevolucion")) = 2 Then
                    frm_devolucion_fact.rdbDevCredito.Visible = True
                    frm_devolucion_fact.rdbDevCredito.Checked = True
                ElseIf (Tabla.Rows(0).Item("IDTipoDevolucion")) = 3 Then
                    frm_devolucion_fact.rdbDevEfectivo.Checked = True
                End If

                If (Tabla.Rows(0).Item("DevolverItbis")) = 1 Then
                    frm_devolucion_fact.ChkDevolverItbis.Checked = True
                Else
                    frm_devolucion_fact.ChkDevolverItbis.Checked = False
                End If

                If (Tabla.Rows(0).Item("GenerarNCF")) = 1 Then
                    frm_devolucion_fact.ChkGenerarNCF.Checked = True
                Else
                    frm_devolucion_fact.ChkGenerarNCF.Checked = False
                End If

                If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                    frm_devolucion_fact.chkNulo.Checked = True
                Else
                    frm_devolucion_fact.chkNulo.Checked = False
                End If

                Close()
            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If
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

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Devolución Venta' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Devolución Ventas' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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

            If DgvDevolucionVenta.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting

            If rdbGeneral.Checked = True Then
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

                '@Producto
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Producto")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Marca
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Marca")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Almacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Suplidor
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Suplidor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Vendedor
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Vendedor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Provincia
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Provincia")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Municipio
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Municipio")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Calificacion
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Calificacion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Condicion
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Condicion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@NCF
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NCF")
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

                '@IDUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Motivo
                If txtIDMotivoDevolucion.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDMotivoDevolucion.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Motivo")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoDevolucion
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoDevolucion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@GenerarNCF
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@GenerarNCF")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@ItbisDevuelto
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@ItbisDevuelto")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@NoDocumento
                If txtIDFactura.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDFactura.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NoDocumento")
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
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Devolución")
                'RangoFechas()
                ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ''Almacenes
                ObjRpt.SetParameterValue("Almacenes", "Todos los almacenes")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvDevolucionVenta.SelectedRows.Count > 0 Then
                    Dim IDFactura As New Label
                    IDFactura.Text = DgvDevolucionVenta.SelectedRows(0).Cells(0).Value

                    If DgvDevolucionVenta.SelectedRows(0).Cells(8).Value = 1 Then
                        MessageBox.Show("El documento de devolución de ventas No. " & DgvDevolucionVenta.SelectedRows(0).Cells(1).Value & " de fecha " & DgvDevolucionVenta.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    Dim cmdSP As New MySqlCommand
                    Dim AdaptadorSP As MySqlDataAdapter

                    'Consulta de los datos de la devolucion venta   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    AdaptadorSP = New MySqlDataAdapter("SELECT DevolucionVenta.IDDevolucionVenta,DevolucionVenta.IDTipoDocumento,Documento,DevolucionVenta.SecondID as SecondIDDevolucion,DevolucionVenta.IDUsuario,Usuarios.Nombre as NombreUsuario,DevolucionVenta.Fecha,DevolucionVenta.Hora,DevolucionVenta.IDSucursal,DevolucionVenta.IDAlmacen,Almacen.Almacen,DevolucionVenta.NCF,DevolucionVenta.IDFactura,FacturaDatos.SecondID AS SecondIDFact,FacturaDatos.Fecha as FechaFactura,FacturaDatos.NCF AS NCFFactura,ComprobanteFiscal.TipoComprobante,FacturaDatos.IDCliente,Clientes.Nombre as NombreCliente,FacturaDatos.NombreFactura,Clientes.Identificacion,IdentificacionFactura,Clientes.Direccion,DireccionFactura,Provincias.Provincia,Municipios.Municipio,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,FacturaDatos.TelefonosFactura,Clientes.BalanceGeneral,FacturaDatos.IDVendedor,Vendedor.Nombre as NombreVendedor,DiasTransaccion,DevolucionVenta.IDTipoDevolucion,TipoDevolucion.Tipo,DevolucionVenta.IDMotivoDevolucion,MotivoDevolucion.Descripcion as MotivoDevolucion,DevolverItbis,DevolucionVenta.Subtotal,DevolucionVenta.Itbis,DevolucionVenta.Neto,Devolver,DevolucionVenta.Impreso,DevolucionVenta.Nulo,Devolucionventadetalle.IDArticulo,Articulos.Descripcion,Articulos.Referencia,Devolucionventadetalle.IDMedida,Medida.Medida,CantDevuelta,PrecioDevuelto,DevolucionVentaDetalle.Itbis as ItbisArt,DevolucionVentaDetalle.IDAlmacen as IDAlmacenArticulo,AlmacenArticulo.Almacen as AlmacenArticulo FROM" & SysName.Text & "devolucionventa INNER JOIN" & SysName.Text & "FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "DevolucionVentaDetalle on DevolucionVenta.IDDevolucionVenta=DevolucionVentaDetalle.IDDevolucionVenta INNER JOIN Libregco.Articulos on DevolucionVentaDetalle.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on DevolucionVentaDetalle.IDMedida=Medida.IDMedida INNER JOIN" & SysName.Text & "Empleados as Usuarios on DevolucionVenta.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "TipoDocumento on DevolucionVenta.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.MotivoDevolucion on DevolucionVenta.IDMotivoDevolucion=MotivoDevolucion.IDMotivoDevolucion INNER JOIN Libregco.TipoDevolucion on DevolucionVenta.IDTipoDevolucion=TipoDevolucion.IDTipoDevolucion INNER JOIN" & SysName.Text & "Almacen as AlmacenArticulo on DevolucionVentaDetalle.IDAlmacen=AlmacenArticulo.IDAlmacen INNER JOIN" & SysName.Text & "Almacen on DevolucionVenta.IDAlmacen=Almacen.IDAlmacen WHERE DevolucionVenta.IDDevolucionVenta='" + DgvDevolucionVenta.SelectedRows(0).Cells(0).Value.ToString + "'", ConMixta)
                    AdaptadorSP.Fill(DsSP, "DevolucionVentaView")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    'Llenado EmpresaView
                    AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
                    AdaptadorSP.Fill(DsSP, "EmpresaView")


                For Each crReportObject In frm_reportView.ObjRpt.Subreports
                    If CType(crReportObject, ReportDocument).Name = "balances_clientes_formato.rpt" Then
                        'Lleando balances_clientes_view
                        AdaptadorSP = New MySqlDataAdapter("call libregco.balances_clientes(" + DgvDevolucionVenta.CurrentRow.Cells("IDCliente").Value.ToString + ");", Con)
                        AdaptadorSP.Fill(DsSP, "balances_clientes")

                        frm_reportView.ObjRpt.Subreports("balances_clientes_formato.rpt").SetDataSource(DsSP.Tables("balances_clientes"))
                    End If

                Next

                cmdSP.Dispose()
                    AdaptadorSP.Dispose()

                    frm_reportView.ObjRpt.Database.Tables("devolucionventaview1").SetDataSource(DsSP.Tables("DevolucionVentaView"))
                    frm_reportView.ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))




                    ''@IDDocumento
                    'crParameterDiscreteValue.Value = IDFactura.Text
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

        Catch ex As Exception
        InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
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

End Class