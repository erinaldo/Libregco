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
Public Class frm_consulta_orden_compra

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblNulo, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT IDOrdenCompra,OrdenCompra.SecondID,Fecha,Suplidor,Nombre,Total,OrdenCompra.Nulo FROM" & SysName.Text & "ordencompra INNER JOIN Libregco.Suplidor on OrdenCompra.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & " Empleados on OrdenCompra.IDUsuario=Empleados.IDEmpleado"
    Dim FullCommand, FechaValue, MontoValue, IDUsuarioValue, IDSuplidorValue, NuloValue As String
    Dim A1, A2, A3, A4 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_orden_compra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDOrdenCompra,OrdenCompra.SecondID,Fecha,Suplidor,Nombre,Total,OrdenCompra.Nulo FROM" & SysName.Text & "ordencompra INNER JOIN Libregco.Suplidor on OrdenCompra.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & "Empleados on OrdenCompra.IDUsuario=Empleados.IDEmpleado Where Fecha BETWEEN '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' AND '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and OrdenCompra.Nulo=0", Con)
        RefrescarTabla()
        ConstructorSQL()
        FillReportes()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Orden Compra' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Orden de Compras' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
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
        txtIDUsuario.Clear()
        txtUsuario.Clear()
        txtIDSuplidor.Clear()
        txtSuplidor.Clear()
        txtMontoInicial.Clear()
        txtMontoFinal.Clear()
        chkNulos.Checked = False
        lblNulo.Text = 0
        SummaCond()
        txtIDUsuario.Focus()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
        VerificarCondicionFecha()
    End Sub

    Private Sub txtMontoFinal_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub RefrescarTabla()
        Ds.Clear()
        ConMixta.Open()
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "OrdenCompra")
        DgvOrdenesCompra.DataSource = Ds
        DgvOrdenesCompra.DataMember = "OrdenCompra"
        ConMixta.Close()
        PropiedadColumnsDgv()
        SumarRows()
        MarcarCanceladas()
        DgvOrdenesCompra.ClearSelection()
    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvOrdenesCompra.Rows
                If CInt(Row.Cells(5).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvOrdenesCompra
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 100
            .Columns(2).Width = 80
            .Columns(2).HeaderText = "Fecha"
            .Columns(3).HeaderText = "Suplidor"
            .Columns(3).Width = 260
            .Columns(4).HeaderText = "Usuario"
            .Columns(4).Width = 200
            .Columns(5).Width = 110
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(5).HeaderText = "Importe"
            .Columns(6).Visible = False
        End With
    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvOrdenesCompra.Rows.Count Then
            GoTo Fin
        End If

        Monto = Monto + CDbl(DgvOrdenesCompra.Rows(x).Cells(5).Value)

        x = x + 1
        GoTo Inicio
Fin:
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
        lblCantidad.Text = "Registros Encontrados: " & DgvOrdenesCompra.Rows.Count
    End Sub

    Private Sub SelectUsuario()
        Try
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDUsuario.Text + "'", Con)
            txtUsuario.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

        Catch ex As Exception
            txtUsuario.Text = ""
        End Try
    End Sub

    Private Sub SelectSuplidor()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Suplidor FROM Suplidor Where IDSuplidor='" + txtIDSuplidor.Text + "'", ConLibregco)
            txtSuplidor.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

        Catch ex As Exception
            txtSuplidor.Text = ""
        End Try
    End Sub

    Private Sub txtIDSuplidor_Leave(sender As Object, e As EventArgs) Handles txtIDSuplidor.Leave
        SelectSuplidor()
        VerificarCondicionSuplidor()
    End Sub

    Private Sub txtIDUsuario_Leave(sender As Object, e As EventArgs) Handles txtIDUsuario.Leave
        SelectUsuario()
        VerificarCondicionUsuario()
    End Sub

    Private Sub txtMontoInicial_Leave(sender As Object, e As EventArgs) Handles txtMontoInicial.Leave
        If txtMontoInicial.Text = "" Then
        Else
            txtMontoInicial.Text = CDbl(txtMontoInicial.Text).ToString("C")
        End If
        VerificarCondicionMontos()
    End Sub

    Private Sub txtMontoFinal_Leave(sender As Object, e As EventArgs) Handles txtMontoFinal.Leave
        If txtMontoFinal.Text = "" Then
        Else
            txtMontoFinal.Text = CDbl(txtMontoFinal.Text).ToString("C")
        End If
        VerificarCondicionMontos()
    End Sub

    Private Sub txtMontoInicial_Enter(sender As Object, e As EventArgs) Handles txtMontoInicial.Enter
        If txtMontoInicial.Text = "" Then
        Else
            txtMontoInicial.Text = CDbl(txtMontoInicial.Text)
        End If
    End Sub

    Private Sub txtMontoFinal_Enter(sender As Object, e As EventArgs) Handles txtMontoFinal.Enter
        If txtMontoFinal.Text = "" Then
        Else
            txtMontoFinal.Text = CDbl(txtMontoFinal.Text)
        End If
    End Sub
    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If
        VerificarCondicionNulo()
    End Sub

    Private Sub txtFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub btnBuscarCOns_Click(sender As Object, e As EventArgs) Handles btnBuscarCOns.Click
        cmd = New MySqlCommand(FullCommand, Con)
        RefrescarTabla()
    End Sub

    Private Sub btnStructure_Click(sender As Object, e As EventArgs) Handles btnStructure.Click
        frm_query_structure.txtQuery.Text = "SQL Query: " & FullCommand
        frm_query_structure.ShowDialog()
    End Sub

    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Sub VerificarCondicionUsuario()
        If txtIDUsuario.Text = "" Then
            IDUsuarioValue = ""
        Else
            IDUsuarioValue = " OrdenCompra.IDUsuario=" & txtIDUsuario.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Sub VerificarCondicionSuplidor()
        If txtIDSuplidor.Text = "" Then
            IDSuplidorValue = ""
        Else
            IDSuplidorValue = " OrdenCompra.IDSuplidor=" & txtIDSuplidor.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Value) And IsDate(txtFechaInicial.Value) Then
            FechaValue = " OrdenCompra.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionMontos()
        Try
            If CDbl(txtMontoInicial.Text) <= CDbl(txtMontoFinal.Text) Then
                MontoValue = " OrdenCompra.Total BETWEEN '" & CDbl(txtMontoInicial.Text) & "' AND '" & CDbl(txtMontoFinal.Text) & "'"
            Else
                MontoValue = ""
            End If

            If txtMontoInicial.Text = "" Or txtMontoFinal.Text = "" Then
                MontoValue = ""
            End If

            ConstructorSQL()

        Catch ex As Exception
            MontoValue = ""
        End Try
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 = True Then
            NuloValue = ""
        Else
            NuloValue = " OrdenCompra.Nulo=0 "
        End If
        ConstructorSQL()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionUsuario()
        VerificarCondicionSuplidor()
        VerificarCondicionFecha()
        VerificarCondicionMontos()
        VerificarCondicionNulo()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or IDUsuarioValue <> "" Or IDSuplidorValue <> "" Or MontoValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And IDUsuarioValue & IDSuplidorValue & MontoValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDUsuarioValue <> "" And IDSuplidorValue & MontoValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If IDSuplidorValue <> "" And MontoValue & NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If MontoValue <> "" And NuloValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & IDUsuarioValue & A2 & IDSuplidorValue & A3 & MontoValue & A4 & NuloValue

    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarSuplidor_Click(sender As Object, e As EventArgs) Handles btnBuscarSuplidor.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub DgvOrdenesCompra_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvOrdenesCompra.CellDoubleClick
        Try
            If e.RowIndex >= 0 Then
                LlenarFormularios()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " DgvOrdenesCompra_CellDoubleClick")
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Dim IDOrdenCompra As New Label
        IDOrdenCompra.Text = DgvOrdenesCompra.CurrentRow.Cells(0).Value
        Try

            Ds1.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDOrdenCompra,OrdenCompra.SecondID,OrdenCompra.IDSuplidor,Suplidor,OrdenCompra.Referencia,Comentario,IDTipoOrden,Descripcion,Balance,Suplidor.IDCondicion,Condicion.Condicion,Suplidor.IDNCF,TipoComprobante,Suplidor.IDGasto,TipoGasto.TipoGasto,FechaIngreso,Balance,Desactivar,ifnull((Select Fecha from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Neto from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto FROM" & SysName.Text & "OrdenCompra INNER JOIN Libregco.Suplidor on OrdenCompra.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.TipoOrdenCompra on OrdenCompra.IDTipoOrden=TipoOrdenCompra.IDTipoOrdenCompra INNER JOIN Libregco.Condicion on Suplidor.IDCondicion=Condicion.IDCondicion  INNER JOIN" & SysName.Text & "ComprobanteFiscal on Suplidor.IDNCF=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.TipoGasto on Suplidor.IDGasto=TipoGasto.IDGasto  Where IDOrdenCompra='" + IDOrdenCompra.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "OrdenCompra")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds1.Tables("OrdenCompra")

            If (Tabla.Rows(0).Item("IDTipoOrden")) = 2 Then
                MessageBox.Show("La orden de compras seleccionada ya ha sido procesada y ha generado una factura de compras.", "Orden Procesada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                frm_registro_compras.DeshabilitarControles()
                frm_registro_compras.btnGuardarC.Enabled = False
            End If

            If Me.Owner.Name = frm_registro_compras.Name Then
                frm_registro_compras.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_registro_compras.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_registro_compras.txtBalanceSup.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
                frm_registro_compras.txtReferencia.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_registro_compras.txtNotaCompra.Text = (Tabla.Rows(0).Item("Comentario"))
                frm_registro_compras.IDOrdenCompra.Text = (Tabla.Rows(0).Item("IDOrdenCompra"))
                frm_registro_compras.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                frm_registro_compras.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                frm_registro_compras.LUEGasto.EditValue = (Tabla.Rows(0).Item("IDGasto"))
                frm_registro_compras.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                frm_registro_compras.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))

                If IsNumeric(Tabla.Rows(0).Item("UltimoMonto")) Then
                    frm_registro_compras.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMonto")).ToString("C")
                Else
                    frm_registro_compras.txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
                End If


                PasarArticulos()
            End If
           
            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub PasarArticulos()
        Try
            Dim IDOrdenCompra, IDArticulo As New Label
            IDOrdenCompra.Text = DgvOrdenesCompra.CurrentRow.Cells(0).Value

            If frm_registro_compras.Visible = True Then
                frm_registro_compras.TablaCompras.Rows.Clear()

                Con.Open()
                cmd = New MySqlCommand("Select * from OrdenCompraDetalle Where IDOrdenCompra='" + IDOrdenCompra.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "OrdenCompraDetalle")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("OrdenCompraDetalle")
                For Each Row As DataRow In Tabla.Rows
                    frm_registro_compras.lblIDAlmacenArticulo.Text = DtEmpleado.Rows(0).item("IDAlmacen").ToString()
                    frm_registro_compras.txtIDArticulo.Text = Row.Item("IDArticulo")
                    frm_registro_compras.SetInformacionArticulo()
                    frm_registro_compras.CbxMedida.Text = Row.Item("Medida")
                    frm_registro_compras.txtCantidadArticulo.Text = Row.Item("Cantidad")
                    frm_registro_compras.txtDescripcionArticulo.Text = Row.Item("Descripcion")
                    frm_registro_compras.txtPrecio.Text = CDbl(Row.Item("Precio"))
                    frm_registro_compras.btnAplicarMonto.PerformClick()






                    'ConLibregco.Open()
                    'cmd = New MySqlCommand("SELECT Itbis FROM Articulos INNER JOIN TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis WHERE IDArticulo= '" + IDArticulo.Text + "'", ConLibregco)
                    'Dim ItbisC As Double = Convert.ToDouble(cmd.ExecuteScalar())
                    'ConLibregco.Close()

                    'If frm_registro_compras.rdbIncluido.Checked = True Then
                    '    frm_registro_compras.DgvArticulos.Rows.Add("", "", Row.Item("IDPrecio"), Row.Item("IDArticulo"), Row.Item("Descripcion"), Row.Item("IDMedida"), Row.Item("Medida"), Row.Item("Cantidad"), (CDbl(Row.Item("Precio")) / (CDbl(1) + ItbisC)).ToString("C"), ((CDbl(Row.Item("Precio")) / (CDbl(1) + ItbisC)) * CDbl(Replace(frm_registro_compras.txtDescuentoAplicado.Text, "%", "") / 100)).ToString("C"), CDbl(0).ToString("C"), (((CDbl(Row.Item("Precio")) / (CDbl(1) + ItbisC)) - ((CDbl(Row.Item("Precio")) / (CDbl(1) + ItbisC)) * CDbl(Replace(frm_registro_compras.txtDescuentoAplicado.Text, "%", "") / 100))) * ItbisC).ToString("C"), CDbl(Row.Item("Precio")).ToString("C"))
                    'ElseIf frm_registro_compras.rdbNoIncluido.Checked = True Then
                    '    frm_registro_compras.DgvArticulos.Rows.Add("", "", Row.Item("IDPrecio"), Row.Item("IDArticulo"), Row.Item("Descripcion"), Row.Item("IDMedida"), Row.Item("IDMedida"), Row.Item("Cantidad"), CDbl(Row.Item("Precio")).ToString("C"), CDbl(0))
                    'ElseIf frm_registro_compras.rdbNoItbis.Checked = True Then
                    '    frm_registro_compras.DgvArticulos.Rows.Add("", "", Row.Item("IDPrecio"), Row.Item("IDArticulo"), Row.Item("Descripcion"), Row.Item("IDMedida"), Row.Item("IDMedida"), Row.Item("Cantidad"), CDbl(Row.Item("Precio")).ToString("C"), (CDbl(CDbl(Row.Item("Precio")) * CDbl(Replace(frm_registro_compras.txtDescuentoAplicado.Text, "%", ""))) / 100).ToString("C"), CDbl(0).ToString("C"), CDbl(0).ToString("C"), (CDbl(Row.Item("Precio")) - (CDbl(CDbl(Row.Item("Precio")) * CDbl(Replace(frm_registro_compras.txtDescuentoAplicado.Text, "%", ""))) / 100)).ToString("C"))
                    'End If

                Next

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
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

            If TypeConnection.Text = 1 Then
                frm_reportView.ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text)
            Else
                frm_reportView.ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))
            End If

            If DgvOrdenesCompra.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If


            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting

            If rdbGeneral.Checked = True Then
                '@Fecha
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
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

                '@Suplidor
                If txtIDSuplidor.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDSuplidor.Text
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Suplidor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoSuplidor
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoSuplidor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@IDUsuario
                If txtIDUsuario.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDUsuario.Text
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Producto
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Producto")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoProducto
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoProducto")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Medida
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Medida")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Departamento
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Departamento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Categoria
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Categoria")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@SubCategoria
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@SubCategoria")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@StatusOrden
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@StatusOrden")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Estado
                If chkNulos.Checked = True Then
                    crParameterDiscreteValue.Value = 2
                Else
                    crParameterDiscreteValue.Value = 0
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'Setting Info 
                'Resumir Reporte
                If chkResumir.Checked = True Then
                    frm_reportView.ObjRpt.SetParameterValue("@Resumir", 1)
                Else
                    frm_reportView.ObjRpt.SetParameterValue("@Resumir", 0)
                End If
                'Ordenamiento de Reporte
                frm_reportView.ObjRpt.SetParameterValue("@SortedField", "")
                frm_reportView.ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Factura")
                'RangoFechas()
                frm_reportView.ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                'Usuario Info
                frm_reportView.ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvOrdenesCompra.SelectedRows.Count > 0 Then
                    Dim IDOrdenCompra As New Label
                    IDOrdenCompra.Text = DgvOrdenesCompra.SelectedRows(0).Cells(0).Value

                    If DgvOrdenesCompra.SelectedRows(0).Cells(6).Value = 1 Then
                        MessageBox.Show("La orden de compras No." & DgvOrdenesCompra.SelectedRows(0).Cells(1).Value & " de fecha " & DgvOrdenesCompra.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    Dim cmdSP As New MySqlCommand
                    Dim AdaptadorSP As MySqlDataAdapter

                    'Consulta de los datos de la orden de compra   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    AdaptadorSP = New MySqlDataAdapter("SELECT OrdenCompra.IDOrdenCompra,OrdenCompra.IDTipoDocumento,TipoDocumento.Documento,SecondID,Fecha,Hora,IDUsuario,Usuarios.Nombre as NombreUsuario,OrdenCompra.IDSuplidor,Suplidor.Suplidor,Suplidor.Rnc,Suplidor.Direccion,Suplidor.Telefono,Suplidor.TelefonoRepresentante,Suplidor.Representante,IDTipoOrden,OrdenCompra.Referencia as ReferenciaOrden,OrdenCompra.Comentario,(if(TipoItbis=1,'Itbis incluído','No incluído')) as TipoItbis,OrdenCompra.SubtotalOrden,OrdenCompra.ItbisOrden,OrdenCompra.Total,OrdenCompra.Impreso,OrdenCompra.Nulo,OrdenCompraDetalle.IDArticulo,OrdenCompraDetalle.IDMedida,Medida.Medida,Cantidad,Articulos.Descripcion,Articulos.Referencia as ReferenciaArt,OrdenCompraDetalle.SubtotalDetalle,OrdenCompraDetalle.ItbisDetalle,OrdenCompraDetalle.Precio,OrdenCompraDetalle.Importe FROM" & SysName.Text & "ordencompra INNER JOIN Libregco.Suplidor on OrdenCompra.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & "OrdenCompraDetalle on OrdenCompra.IDOrdenCompra=OrdenCompraDetalle.IDOrdenCompra INNER JOIN Libregco.Articulos on OrdenCompraDetalle.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on OrdenCompraDetalle.IDMedida=Medida.IDMedida INNER JOIN" & SysName.Text & "Empleados as Usuarios on OrdenCompra.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "TipoDocumento on OrdenCompra.IDTipoDocumento=TipoDocumento.IDTipoDocumento Where OrdenCompra.IDOrdenCompra='" + DgvOrdenesCompra.CurrentRow.Cells(0).Value.ToString + "'", ConMixta)
                    AdaptadorSP.Fill(DsSP, "OrdenCompraView")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    'Llenado EmpresaView
                    AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
                    AdaptadorSP.Fill(DsSP, "EmpresaView")

                    cmdSP.Dispose()
                    AdaptadorSP.Dispose()

                    frm_reportView.ObjRpt.Database.Tables("ordencompraview1").SetDataSource(DsSP.Tables("OrdenCompraView"))
                    frm_reportView.ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))

                    'crParameterDiscreteValue.Value = IDOrdenCompra.Text
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
                    CrExportOptions = frm_reportView.ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    frm_reportView.ObjRpt.Export()
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
                    CrExportOptions = frm_reportView.ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.Excel
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    frm_reportView.ObjRpt.Export()
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

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            Dim DsTemp As New DataSet
            If DgvOrdenesCompra.SelectedRows.Count > 0 Then
                Dim IDOrdenCompra As New Label
                IDOrdenCompra.Text = DgvOrdenesCompra.SelectedRows(0).Cells(0).Value

                DsTemp.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("Select IDOrdenCompra,OrdenCompra.SecondID,Fecha,Hora,IDUsuario,OrdenCompra.IDSuplidor,Suplidor,OrdenCompra.Referencia,Comentario,Total,OrdenCompra.Nulo,Suplidor.Balance,OrdenCompra.IDTipoOrden,Descripcion,OrdenCompra.IDAlmacen,Almacen.Almacen,TipoItbis,SubtotalOrden,ItbisOrden from" & SysName.Text & "OrdenCompra INNER JOIN Libregco.Suplidor on OrdenCompra.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.TipoOrdenCompra on OrdenCompra.IDTipoOrden=TipoOrdenCompra.IDTipoOrdenCompra INNER JOIN" & SysName.Text & "Almacen on OrdenCompra.IDAlmacen=Almacen.IDAlmacen Where IDOrdenCompra='" + IDOrdenCompra.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "OrdenCompra")
                ConMixta.Close()

                Dim Tabla As DataTable = DsTemp.Tables("OrdenCompra")

                If frm_orden_compras.Visible = True Then
                    frm_orden_compras.Close()
                End If

                frm_orden_compras.Show(Me)

                frm_orden_compras.txtIDOrdenCompra.Text = (Tabla.Rows(0).Item("IDOrdenCompra"))
                frm_orden_compras.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_orden_compras.txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                frm_orden_compras.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                frm_orden_compras.txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                frm_orden_compras.txtNombreSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
                frm_orden_compras.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
                frm_orden_compras.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
                frm_orden_compras.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("SubtotalOrden")).ToString("C")
                frm_orden_compras.txtItbis.Text = CDbl(Tabla.Rows(0).Item("ItbisOrden")).ToString("C")
                frm_orden_compras.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Total")).ToString("C")
                frm_orden_compras.ChkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))
                frm_orden_compras.txtBalanceSup.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
                frm_orden_compras.cbxStatusOrder.Tag = (Tabla.Rows(0).Item("IDTipoOrden"))
                frm_orden_compras.cbxStatusOrder.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_orden_compras.CbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))

                If (Tabla.Rows(0).Item("TipoItbis")) = 1 Then
                    frm_orden_compras.rdbIncluido.Checked = True
                ElseIf (Tabla.Rows(0).Item("TipoItbis")) = 2 Then
                    frm_orden_compras.rdbNoIncluido.Checked = True
                ElseIf (Tabla.Rows(0).Item("TipoItbis")) = 3 Then
                    frm_orden_compras.rdbNoItbis.Checked = True
                End If

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_orden_compras.ChkNulo.Checked = False
                Else
                    frm_orden_compras.ChkNulo.Checked = True
                End If

                frm_orden_compras.RefrescarTablaArticulos()

            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class