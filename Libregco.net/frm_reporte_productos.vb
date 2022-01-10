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

Public Class frm_reporte_productos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim IDReport, NameReport, PathReport, OrdenCampo, OrdenFormula As New Label
    Dim Permisos As New ArrayList

    Private Sub LimpiarTodo()
        txtCodigoArtDesde.Clear()
        txtCodigoArtHasta.Clear()
        txtIDTipoProducto.Clear()
        txtTipoProducto.Clear()
        txtIDDepartamento.Clear()
        txtDepartamento.Clear()
        txtIDCategoria.Clear()
        txtCategoria.Clear()
        txtIDSubCategoria.Clear()
        txtSubCategoria.Clear()
        txtIDMedida.Clear()
        txtMedida.Clear()
        txtIDMarca.Clear()
        txtMarca.Clear()
        txtIDSuplidor.Clear()
        txtSuplidor.Clear()
        txtIDAlmacen.Clear()
        txtAlmacen.Clear()
        txtIDTipoItbis.Clear()
        txtTipoItbis.Clear()
        txtIDGarantia.Clear()
        txtGarantia.Clear()
        txtInventarioCant.Clear()
        txtIDMedida.Clear()
        txtMedida.Clear()
        txtIDGarantia.Clear()
        txtGarantia.Clear()
        txtIDParental.Clear()
        txtParentezco.Clear()

    End Sub

    Private Sub ActualizarTodo()
        FillReportes()
        chkResumir.Checked = False
        cbxPromocion.SelectedIndex = 0
        cbxDevolucion.SelectedIndex = 0
        cbxVenderCosto.SelectedIndex = 0
        cbxDescontinuado.SelectedIndex = 0
        cbxHabSeries.SelectedIndex = 0
        chkPreAlertar.SelectedIndex = 0
        chkRevisado.SelectedIndex = 0
        chkBloqueoCredito.SelectedIndex = 0
        cbxEstado.SelectedIndex = 0
        CbxOrden.SelectedIndex = 0
        CbxExistencia.SelectedIndex = 0
        cbxInventario.SelectedIndex = 0
        cbxTipoOrden.SelectedIndex = 0
    End Sub

    Private Sub rdbPresentacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPresentacion.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub FillReportes()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Productos' ORDER BY Descripcion ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Reportes")
            CbxFormato.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Reportes")

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

    Private Sub FillOrdenamiento()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM ReportesOrden where IDReporte='" + IDReport.text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "OrdenReportes")
            CbxOrden.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("OrdenReportes")

            For Each Fila As DataRow In Tabla.Rows
                CbxOrden.Items.Add(Fila.Item("Descripcion"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxOrden.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron orden de reportes que involucren este vínculo del módulo.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "FillOrdenamiento()")
        End Try

    End Sub

    Private Sub ChangePictureRdb()
        If rdbPresentacion.Checked = True Then
            PicSalida.Image = My.Resources.Preview_x72
        ElseIf rdbImpresora.Checked = True Then
            PicSalida.Image = My.Resources.Printer_x72
        ElseIf rdbPDF.Checked = True Then
            PicSalida.Image = My.Resources.AdobeReader_x72
        ElseIf rdbExcel.Checked = True Then
            PicSalida.Image = My.Resources.Ms_Excel_x72
        End If
    End Sub

    Private Sub rdbImpresora_CheckedChanged(sender As Object, e As EventArgs) Handles rdbImpresora.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub rdbPDF_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPDF.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub rdbExcel_CheckedChanged(sender As Object, e As EventArgs) Handles rdbExcel.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub btnBuscarArtDesde_Click(sender As Object, e As EventArgs) Handles btnBuscarArtDesde.Click
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarTipoProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoProducto.Click
        frm_buscar_tipo_articulo.ShowDialog(Me)
    End Sub

    Private Sub btnSuplidor_Click(sender As Object, e As EventArgs) Handles btnSuplidor.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub btnTipoItbis_Click(sender As Object, e As EventArgs) Handles btnTipoItbis.Click
        frm_buscar_itbis.ShowDialog(Me)
    End Sub

    Private Sub btnMedida_Click(sender As Object, e As EventArgs) Handles btnMedida.Click
        frm_buscar_medidas.ShowDialog(Me)
    End Sub

    Private Sub btnDepartamento_Click(sender As Object, e As EventArgs) Handles btnDepartamento.Click
        frm_buscar_departamentos.ShowDialog(Me)
    End Sub

    Private Sub btnCategoria_Click(sender As Object, e As EventArgs) Handles btnCategoria.Click
        frm_buscar_categorias.ShowDialog(Me)
    End Sub

    Private Sub btnSubCategoria_Click(sender As Object, e As EventArgs) Handles btnSubCategoria.Click
        frm_buscar_subcategorias.ShowDialog(Me)
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        frm_buscar_marcas.ShowDialog(Me)
    End Sub

    Private Sub btnAlmacen_Click(sender As Object, e As EventArgs) Handles btnAlmacen.Click
        frm_buscar_almacen_mant.ShowDialog(Me)
    End Sub

    Private Sub btnGarantia_Click(sender As Object, e As EventArgs) Handles btnGarantia.Click
        frm_buscar_tipo_garantia.ShowDialog(Me)
    End Sub

    Private Sub txtIDTipoProducto_Leave(sender As Object, e As EventArgs) Handles txtIDTipoProducto.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select TipoArticulo from TipoArticulo Where IDTipoArticulo='" + txtIDTipoProducto.Text + "'", ConLibregco)
        txtTipoProducto.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtTipoProducto.Text = "" Then txtIDTipoProducto.Clear()
    End Sub

    Private Sub txtIDDepartamento_Leave(sender As Object, e As EventArgs) Handles txtIDDepartamento.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Departamento from Departamentos Where IDDepartamento='" + txtIDDepartamento.Text + "'", ConLibregco)
        txtDepartamento.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtDepartamento.Text = "" Then txtIDDepartamento.Clear()
    End Sub

    Private Sub txtIDCategoria_Leave(sender As Object, e As EventArgs) Handles txtIDCategoria.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Categoria from Categoria Where IDCategoria='" + txtIDCategoria.Text + "'", ConLibregco)
        txtCategoria.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtCategoria.Text = "" Then txtIDCategoria.Clear()
    End Sub

    Private Sub txtIDSubCategoria_Leave(sender As Object, e As EventArgs) Handles txtIDSubCategoria.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select SubCategoria from SubCategoria Where IDSubCategoria='" + txtIDSubCategoria.Text + "'", ConLibregco)
        txtSubCategoria.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtSubCategoria.Text = "" Then txtIDSubCategoria.Clear()
    End Sub

    Private Sub txtIDMedida_Leave(sender As Object, e As EventArgs) Handles txtIDMedida.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Medida from Medida Where IDMedida='" + txtIDMedida.Text + "'", ConLibregco)
        txtMedida.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtMedida.Text = "" Then txtIDMedida.Clear()
    End Sub

    Private Sub txtIDMarca_Leave(sender As Object, e As EventArgs) Handles txtIDMarca.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Marca from Marca Where IDMarca='" + txtIDMarca.Text + "'", ConLibregco)
        txtMarca.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtMarca.Text = "" Then txtIDMarca.Clear()
    End Sub

    Private Sub txtIDSuplidor_Leave(sender As Object, e As EventArgs) Handles txtIDSuplidor.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Suplidor from Suplidor Where IDSuplidor='" + txtIDSuplidor.Text + "'", ConLibregco)
        txtSuplidor.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtSuplidor.Text = "" Then txtIDSuplidor.Clear()
    End Sub

    Private Sub txtIDAlmacen_Leave(sender As Object, e As EventArgs) Handles txtIDAlmacen.Leave
        Con.Open()
        cmd = New MySqlCommand("Select Almacen from Almacen Where IDAlmacen='" + txtIDAlmacen.Text + "'", Con)
        txtAlmacen.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        If txtAlmacen.Text = "" Then txtIDAlmacen.Clear()
    End Sub

    Private Sub txtIDTipoItbis_Leave(sender As Object, e As EventArgs) Handles txtIDTipoItbis.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Tipo from TipoItbis Where IDTipoItbis='" + txtIDTipoItbis.Text + "'", ConLibregco)
        txtTipoItbis.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtTipoItbis.Text = "" Then txtIDTipoItbis.Clear()
    End Sub

    Private Sub txtIDGarantia_Leave(sender As Object, e As EventArgs) Handles txtIDGarantia.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT TiempoGarantia FROM garantiaarticulos Where IDGarantiaArticulos='" + txtIDGarantia.Text + "'", ConLibregco)
        txtGarantia.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtGarantia.Text = "" Then txtIDGarantia.Clear()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Ds.Clear()
        chkResumir.Checked = False
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Reportes")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Reportes")
        IDReport.Text = (Tabla.Rows(0).Item("IDReportes"))
        NameReport.Text = (Tabla.Rows(0).Item("Reporte"))
        PathReport.Text = (Tabla.Rows(0).Item("Path"))


        If (Tabla.Rows(0).Item("HabilitadoResumen")) = 0 Then
            chkResumir.Enabled = False
        Else
            chkResumir.Enabled = True
        End If

        FillOrdenamiento()
    End Sub

    Private Sub cbxInventario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxInventario.SelectedIndexChanged
        If cbxInventario.Text <> "Todos" Then
            txtInventarioCant.Enabled = True
        Else
            txtInventarioCant.Enabled = False
            txtInventarioCant.Clear()
        End If
    End Sub

    Private Sub txtInventarioCant_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInventarioCant.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub CbxOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxOrden.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("Select Campo from ReportesOrden where IDReporte='" + IDReport.Text + "' and Descripcion='" + CbxOrden.Text + "'", Con)
        OrdenCampo.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub cbxTipoOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoOrden.SelectedIndexChanged
        If CbxOrden.Text = "Ascendente" Then
            OrdenFormula.Text = "crAscendingOrder"
        ElseIf CbxOrden.Text = "Descendiente" Then
            OrdenFormula.Text = "crDescendingOrder"
        End If
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


            If cbxInventario.Text <> "Todos" Then
                If txtInventarioCant.Text = "" Then
                    MessageBox.Show("Especifique la cantidad que desea especificar en el parámetro de inventario.", "Especificar parámetro inventario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtInventarioCant.Focus()
                    Exit Sub
                End If
            End If

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            '@IDArticulo
            Dim Minimo, Maximo As Integer
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDArticulo from Articulos where IDArticulo= (Select Max(IDArticulo) from Articulos)", ConLibregco)
            Maximo = Convert.ToInt16(cmd.ExecuteScalar())
            cmd = New MySqlCommand("Select IDArticulo from Articulos where IDArticulo= (Select Min(IDArticulo) from Articulos)", ConLibregco)
            Minimo = Convert.ToInt16(cmd.ExecuteScalar())
            ConLibregco.Close()

            If txtCodigoArtDesde.Text = "" Then
                txtCodigoArtDesde.Text = Minimo
            End If
            If txtCodigoArtHasta.Text = "" Then
                txtCodigoArtHasta.Text = Maximo
            End If

            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDArticulo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterRangeValue = New ParameterRangeValue

            With crParameterRangeValue
                .EndValue = txtCodigoArtHasta.Text
                .LowerBoundType = RangeBoundType.BoundInclusive
                .StartValue = txtCodigoArtDesde.Text
                .UpperBoundType = RangeBoundType.BoundInclusive
            End With

            crParameterValues.Add(crParameterRangeValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@TipoProducto
            If txtIDTipoProducto.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDTipoProducto.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoProducto")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Departamento
            If txtIDDepartamento.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDDepartamento.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Departamento")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Categoria
            If txtIDCategoria.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDCategoria.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Categoria")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Sub-Categoria
            If txtIDSubCategoria.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDSubCategoria.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@SubCategoria")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Medida
            If txtIDMedida.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDMedida.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Medida")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Marca
            If txtIDMarca.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDMarca.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Marca")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Suplidor
            If txtIDSuplidor.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDSuplidor.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Suplidor")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Almacen
            If txtIDAlmacen.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDAlmacen.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@TipoItbis
            If txtIDTipoItbis.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDTipoItbis.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoItbis")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Garantia
            If txtIDGarantia.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDGarantia.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Garantia")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Parental
            If txtIDParental.Text = "" Then
                crParameterDiscreteValue.Value = 0
            Else
                crParameterDiscreteValue.Value = txtIDParental.Text
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Parental")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Promocion
            If cbxPromocion.SelectedIndex = 0 Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxPromocion.SelectedIndex = 1 Then
                crParameterDiscreteValue.Value = 1
            ElseIf cbxPromocion.SelectedIndex = 2 Then
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Promocion")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Devolucion
            If cbxDevolucion.SelectedIndex = 0 Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxDevolucion.SelectedIndex = 1 Then
                crParameterDiscreteValue.Value = 1
            ElseIf cbxDevolucion.SelectedIndex = 2 Then
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Devolucion")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@VenderCosto
            If cbxVenderCosto.SelectedIndex = 0 Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxVenderCosto.SelectedIndex = 1 Then
                crParameterDiscreteValue.Value = 1
            ElseIf cbxVenderCosto.SelectedIndex = 2 Then
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@VenderCosto")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Descontinuado
            If cbxDescontinuado.SelectedIndex = 0 Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxDescontinuado.SelectedIndex = 1 Then
                crParameterDiscreteValue.Value = 1
            ElseIf cbxDescontinuado.SelectedIndex = 2 Then
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Descontinuado")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@NoSerial
            If cbxHabSeries.SelectedIndex = 0 Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxHabSeries.SelectedIndex = 1 Then
                crParameterDiscreteValue.Value = 1
            ElseIf cbxHabSeries.SelectedIndex = 2 Then
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NoSerial")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@PreAlertas
            If chkPreAlertar.SelectedIndex = 0 Then
                crParameterDiscreteValue.Value = 2
            ElseIf chkPreAlertar.SelectedIndex = 1 Then
                crParameterDiscreteValue.Value = 1
            ElseIf chkPreAlertar.SelectedIndex = 2 Then
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@PreAlertar")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Revisado
            If chkRevisado.SelectedIndex = 0 Then
                crParameterDiscreteValue.Value = 2
            ElseIf chkRevisado.SelectedIndex = 1 Then
                crParameterDiscreteValue.Value = 1
            ElseIf chkRevisado.SelectedIndex = 2 Then
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Revisado")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@BloqueoCredito
            If chkBloqueoCredito.SelectedIndex = 0 Then
                crParameterDiscreteValue.Value = 2
            ElseIf chkBloqueoCredito.SelectedIndex = 1 Then
                crParameterDiscreteValue.Value = 1
            ElseIf chkBloqueoCredito.SelectedIndex = 2 Then
                crParameterDiscreteValue.Value = 0
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@BloqueoCredito")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Estado
            If cbxEstado.Text = "Todos" Then
                crParameterDiscreteValue.Value = 2
            ElseIf cbxEstado.Text = "Sólo Activos" Then
                crParameterDiscreteValue.Value = 0
            ElseIf cbxEstado.Text = "Nulos" Then
                crParameterDiscreteValue.Value = 1
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Existencia
            If CbxExistencia.Text = "Todas" Then
                crParameterDiscreteValue.Value = 0
            ElseIf CbxExistencia.Text = "Por debajo del mínimo" Then
                crParameterDiscreteValue.Value = 1
            ElseIf CbxExistencia.Text = "Por encima del máximo" Then
                crParameterDiscreteValue.Value = 2
            End If
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Existencia")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Inventario
            If cbxInventario.Text = "Todos" Then
                crParameterDiscreteValue.Value = 0
                ObjRpt.SetParameterValue("@InventarioCant", 0)
            ElseIf cbxInventario.Text = "Menor o Igual" Then
                crParameterDiscreteValue.Value = 1
                ObjRpt.SetParameterValue("@InventarioCant", txtInventarioCant.Text)
            ElseIf cbxInventario.Text = "Menor" Then
                crParameterDiscreteValue.Value = 2
                ObjRpt.SetParameterValue("@InventarioCant", txtInventarioCant.Text)
            ElseIf cbxInventario.Text = "Mayor" Then
                crParameterDiscreteValue.Value = 3
                ObjRpt.SetParameterValue("@InventarioCant", txtInventarioCant.Text)
            ElseIf cbxInventario.Text = "Mayor o Igual" Then
                crParameterDiscreteValue.Value = 4
                ObjRpt.SetParameterValue("@InventarioCant", txtInventarioCant.Text)
            ElseIf cbxInventario.Text = "Diferente" Then
                crParameterDiscreteValue.Value = 5
                ObjRpt.SetParameterValue("@InventarioCant", txtInventarioCant.Text)
            ElseIf cbxInventario.Text = "Igual" Then
                crParameterDiscreteValue.Value = 6
                ObjRpt.SetParameterValue("@InventarioCant", txtInventarioCant.Text)
            End If

            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Inventario")
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
            ObjRpt.SetParameterValue("@SortedField", OrdenCampo.Text)
            ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & CbxOrden.Text)
            'Usuario Info
            ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
            ''Almacenes
            If txtIDAlmacen.Text = "" Then
                ObjRpt.SetParameterValue("Almacenes", "Todos los almacenes")
            Else
                ObjRpt.SetParameterValue("Almacenes", txtAlmacen.Text)
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadAnimation()

            If rdbPresentacion.Checked = True Then
                lblStatusBar.Text = "Visualizando el reporte..."
                Dim TmpForm = New frm_reportView
                TmpForm.Show(Me)
                TmpForm.CrystalViewer.ReportSource = ObjRpt
                TmpForm.CrystalViewer.Refresh()
                TmpForm.CrystalViewer.Cursor = Cursors.Default

            ElseIf rdbImpresora.Checked = True Then
                lblStatusBar.Text = "Reporte en impresión..."
                Dim PrintDialog As New PrintDialog
                With PrintDialog
                    .AllowSelection = True
                    .AllowSomePages = True
                    .AllowPrintToFile = True
                End With

                If (PrintDialog.ShowDialog = Windows.Forms.DialogResult.OK) Then
                    Me.Cursor = Cursors.WaitCursor
                    ObjRpt.SummaryInfo.ReportTitle = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy")
                    ObjRpt.SummaryInfo.ReportAuthor = frm_inicio.lblNombre.Text & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "] "
                    ObjRpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName
                    Dim Settings As New PrinterSettings
                    Dim PrinterDefault As String = Settings.PrinterName
                    Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", PrintDialog.PrinterSettings.PrinterName))
                    ObjRpt.PrintToPrinter(PrintDialog.PrinterSettings.Copies, PrintDialog.PrinterSettings.Collate, PrintDialog.PrinterSettings.FromPage, PrintDialog.PrinterSettings.ToPage)
                    Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", PrinterDefault))
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

                If GetFileName.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
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

                If GetFileName.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
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

            lblStatusBar.Text = "Listo"


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarTodo()
        cbxPromocion.SelectedIndex = 0
        cbxDevolucion.SelectedIndex = 0
        cbxVenderCosto.SelectedIndex = 0
        cbxDescontinuado.SelectedIndex = 0
        cbxHabSeries.SelectedIndex = 0
        chkPreAlertar.SelectedIndex = 0
        chkRevisado.SelectedIndex = 0
        chkBloqueoCredito.SelectedIndex = 0
        cbxEstado.SelectedIndex = 0
        CbxOrden.SelectedIndex = 0
        CbxExistencia.SelectedIndex = 0
        cbxInventario.SelectedIndex = 0
        cbxTipoOrden.SelectedIndex = 0
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub frm_reporte_productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarTodo()
        ActualizarTodo()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub btnparentezo_Click(sender As Object, e As EventArgs) Handles btnparentezo.Click
        frm_buscar_parentesco_productos.ShowDialog(Me)
    End Sub

    Private Sub txtIDParental_Leave(sender As Object, e As EventArgs) Handles txtIDParental.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Descripcion from ParentescoProducto Where IDParentesco='" + txtIDParental.Text + "'", ConLibregco)
        txtParentezco.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtParentezco.Text = "" Then txtIDParental.Clear()
    End Sub
End Class