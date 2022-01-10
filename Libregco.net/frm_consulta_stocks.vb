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
Public Class frm_consulta_stocks

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim DsArticulos, Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend IDReport, NameReport, PathReport, LimitValue As New Label
    Dim SelectCommand As String = "Select IDArticulo,Descripcion,Referencia,IDSuplidor,IDDepartamento,ExistenciaMin,ExistenciaTotal,ExistenciaMax from articulos WHERE Desactivar=0"
    Dim FullCommand, IDSuplidorValue, IDDepartamentoValue, StockValue, A1, A2 As String
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_stocks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        SetConfiguracion()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("Select IDArticulo,Descripcion,Referencia,IDSuplidor,IDDepartamento,ExistenciaTotal,ExistenciaMin,ExistenciaMax from articulos WHERE Desactivar=0", ConLibregco)
        RefrescarTabla()
        ConstructorSQL()
        FillReportes()
    End Sub

    Private Sub SetConfiguracion()
        Try
            'Limite de Consulta
            Con.Open()
            cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=28", Con)
            LimitValue.Text = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where IDReportes=85", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where IDReportes=6", Con)
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

    Private Sub Actualizar()
        rdbSinFiltrar.Checked = True
        chkLimitarBusqueda.Checked = True
    End Sub

    Private Sub PropiedadColumnsDgv()
        Try
            Dim DatagridWidth As Double = (DgvProductos.Width - DgvProductos.RowHeadersWidth) / 100

            With DgvProductos

                .Columns(0).HeaderText = "Código"
                .Columns(0).Width = DatagridWidth * 12

                .Columns(1).Width = DatagridWidth * 36
                .Columns(1).HeaderText = "Descripción"

                .Columns(2).Width = DatagridWidth * 13
                .Columns(2).HeaderText = "Ref."

                .Columns(3).Visible = False

                .Columns(4).Visible = False

                .Columns(5).Width = DatagridWidth * 13
                .Columns(5).HeaderText = "Exist. Actual"
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(6).Width = DatagridWidth * 13
                .Columns(6).HeaderText = "Exist. Mínima"
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(7).Width = DatagridWidth * 13
                .Columns(7).HeaderText = "Exist. Máxima"

            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ColorinStocks()
        If rdbSinFiltrar.Checked = True Then
            DgvProductos.Columns(5).DefaultCellStyle.BackColor = Color.LightGray
            DgvProductos.Columns(6).DefaultCellStyle.BackColor = Color.LightGray
            DgvProductos.Columns(7).DefaultCellStyle.BackColor = Color.LightGray
        ElseIf rdbMinimo.Checked = True Then
            DgvProductos.Columns(5).DefaultCellStyle.BackColor = Color.LightCoral
            DgvProductos.Columns(6).DefaultCellStyle.BackColor = Color.LightGray
            DgvProductos.Columns(7).DefaultCellStyle.BackColor = Color.LightGray
        ElseIf rdbMaximo.Checked = True Then
            DgvProductos.Columns(5).DefaultCellStyle.BackColor = Color.LightGray
            DgvProductos.Columns(6).DefaultCellStyle.BackColor = Color.LightGray
            DgvProductos.Columns(7).DefaultCellStyle.BackColor = Color.LightGreen
        End If
    End Sub

    Private Sub LimpiarDatos()
        txtIDSuplidor.Clear()
        txtIDDepartamento.Clear()
        txtDepartamento.Clear()
        txtSuplidor.Clear()
        TreeViewExistencia.Nodes.Clear()
        rdbSinFiltrar.Checked = True
        SummaCond()
        btnBuscarSuplidor.Focus()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub RefrescarTabla()
        DsArticulos.Clear()
        ConLibregco.Open()
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsArticulos, "Articulos")
        DgvProductos.DataSource = DsArticulos
        DgvProductos.DataMember = "Articulos"
        ConLibregco.Close()
        PropiedadColumnsDgv()
        SumarRows()
        ColorinStocks()
        DgvProductos.ClearSelection()
    End Sub

    Private Sub btnBuscarSuplidor_Click(sender As Object, e As EventArgs) Handles btnBuscarSuplidor.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarDepartamento_Click(sender As Object, e As EventArgs) Handles btnBuscarDepartamento.Click
        frm_buscar_departamentos.ShowDialog(Me)
    End Sub

    Private Sub SumarRows()
        lblCantidad.Text = "Registros Encontrados: " & DgvProductos.Rows.Count
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

    Private Sub SelectDepartamento()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Departamento FROM Departamentos Where IDDepartamento='" + txtIDDepartamento.Text + "'", ConLibregco)
            txtDepartamento.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

        Catch ex As Exception
            txtDepartamento.Text = ""
        End Try
    End Sub

    Private Sub txtIDSuplidor_Leave(sender As Object, e As EventArgs) Handles txtIDSuplidor.Leave
        SelectSuplidor()
    End Sub

    Private Sub txtIDDepartamento_Leave(sender As Object, e As EventArgs) Handles txtIDDepartamento.Leave
        SelectDepartamento()
    End Sub

    Private Sub SummaCond()
        VerificarCondicionSuplidor()
        VerificarCondicionDepartamento()
        VerificarCondicionStock()
    End Sub

    Private Sub VerificarCondicionStock()
        If rdbSinFiltrar.Checked = True Then
            StockValue = ""
        End If
        If rdbMinimo.Checked = True Then
            StockValue = " ExistenciaTotal<=ExistenciaMin "
        End If
        If rdbMaximo.Checked = True Then
            StockValue = " ExistenciaTotal>=ExistenciaMax "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionSuplidor()
        If txtIDSuplidor.Text = "" Then
            IDSuplidorValue = ""
        Else
            IDSuplidorValue = " Articulos.IDSuplidor=" & txtIDSuplidor.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionDepartamento()
        If txtIDDepartamento.Text = "" Then
            IDDepartamentoValue = ""
        Else
            IDDepartamentoValue = " Articulos.IDDepartamento=" & txtIDDepartamento.Text & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If IDSuplidorValue <> "" Or IDDepartamentoValue <> "" Or StockValue <> "" Then
            PutWhere = " AND "
        Else
            PutWhere = ""
        End If

        If IDSuplidorValue <> "" And IDDepartamentoValue & StockValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If IDDepartamentoValue <> "" And StockValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If chkLimitarBusqueda.Checked = True Then
            FullCommand = SelectCommand & PutWhere & IDSuplidorValue & A1 & IDDepartamentoValue & A2 & StockValue & " LIMIT " & LimitValue.Text
        Else
            FullCommand = SelectCommand & PutWhere & IDSuplidorValue & A1 & IDDepartamentoValue & A2 & StockValue
        End If

    End Sub

    Private Sub txtIDSuplidor_TextChanged(sender As Object, e As EventArgs) Handles txtIDSuplidor.TextChanged
        VerificarCondicionSuplidor()
    End Sub

    Private Sub txtIDDepartamento_TextChanged(sender As Object, e As EventArgs) Handles txtIDDepartamento.TextChanged
        VerificarCondicionDepartamento()
    End Sub

    Private Sub rdbMinimo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMinimo.CheckedChanged
        VerificarCondicionStock()
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

    Private Sub rdbMaximo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMaximo.CheckedChanged
        VerificarCondicionStock()
    End Sub

    Private Sub rdbSinFiltrar_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSinFiltrar.CheckedChanged
        VerificarCondicionStock()
    End Sub

    Sub CargarExistenciasTreeView()
        Try

            TreeViewExistencia.Nodes.Clear()

            Dim IDArticulo As New Label
            IDArticulo.Text = DgvProductos.CurrentRow.Cells(0).Value

            Dim Monto As Double = 0
            Dim MyNode() As TreeNode

            'Primero cargo todos los sucursales
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Sucursal.IDSucursal,Sucursal,SUM(Existencia) as Existencia FROM Existencia INNER JOIN Almacen ON Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios  INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo='" + IDArticulo.Text + "' AND Sucursal.Nulo=0 GROUP BY Sucursal.IDSucursal", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Sucursal")
            ConLibregco.Close()

            Dim TablaSucursales As DataTable = Ds.Tables("Sucursal")
            Dim IDSucursal, Medida As New Label

            For Each FilaSucursal As DataRow In TablaSucursales.Rows
                IDSucursal.Text = FilaSucursal.Item("IDSucursal")
                If CDbl(FilaSucursal.Item("Existencia")) = 0 Then
                    Medida.Text = ": [No hay unidades en stock]"
                ElseIf CDbl(FilaSucursal.Item("Existencia")) = 1 Then
                    Medida.Text = ": Sólo " & FilaSucursal.Item("Existencia") & " unidad encontrada."
                Else
                    Medida.Text = ": " & FilaSucursal.Item("Existencia") & " unidades encontradas."
                End If

                TreeViewExistencia.Nodes.Add(FilaSucursal.Item("IDSucursal"), "Sucursal: " & FilaSucursal.Item("Sucursal") & Medida.Text)

                MyNode = TreeViewExistencia.Nodes.Find(FilaSucursal.Item("IDSucursal"), True)

                Ds1.Clear()
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT Almacen.IDAlmacen,Almacen.Almacen,SUM(Existencia) as Existencia FROM Existencia INNER JOIN Almacen ON Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios  INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo='" + IDArticulo.Text + "' AND Sucursal.IDSucursal='" + IDSucursal.Text + "' AND Almacen.Desactivar=0 GROUP BY Almacen.IDAlmacen", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "Almacenes")
                ConLibregco.Close()

                Dim TablaAlmacenes As DataTable = Ds1.Tables("Almacenes")

                For Each FilaAlmacen As DataRow In TablaAlmacenes.Rows
                    If CDbl(FilaAlmacen.Item("Existencia")) = 0 Then
                        Medida.Text = ": [No hay unidades]"
                    ElseIf CDbl(FilaAlmacen.Item("Existencia")) = 1 Then
                        Medida.Text = ": " & FilaAlmacen.Item("Existencia") & " unidad"
                    Else
                        Medida.Text = ": " & FilaAlmacen.Item("Existencia") & " unidades"
                    End If

                    MyNode(0).Nodes.Add(FilaAlmacen.Item("IDAlmacen"), "[" & FilaAlmacen.Item("IDAlmacen") & "] " & FilaAlmacen.Item("Almacen") & Medida.Text)
                Next

            Next

            TreeViewExistencia.CollapseAll()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvProductos_SelectionChanged(sender As Object, e As EventArgs) Handles DgvProductos.SelectionChanged
        CargarExistenciasTreeView()
    End Sub

    Private Sub DgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvProductos.CellDoubleClick
        frm_consulta_stock_info.ShowDialog(Me)
    End Sub

    Private Sub chkLimitarBusqueda_CheckedChanged(sender As Object, e As EventArgs) Handles chkLimitarBusqueda.CheckedChanged
        ConstructorSQL()
    End Sub

    Private Sub frm_consulta_stocks_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadColumnsDgv()
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


    Private Sub btnPresentar_Click(sender As Object, e As EventArgs) Handles btnPresentar.Click
        Try

            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


            If DgvProductos.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting

            If rdbGeneral.Checked = True Then
                '@IDArticulo
                Dim Minimo, Maximo As Integer
                ConLibregco.Open()
                cmd = New MySqlCommand("Select IDArticulo from Articulos where IDArticulo= (Select Max(IDArticulo) from Articulos)", ConLibregco)
                Maximo = Convert.ToInt16(cmd.ExecuteScalar())
                cmd = New MySqlCommand("Select IDArticulo from Articulos where IDArticulo= (Select Min(IDArticulo) from Articulos)", ConLibregco)
                Minimo = Convert.ToInt16(cmd.ExecuteScalar())
                ConLibregco.Close()

                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDArticulo")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterRangeValue = New ParameterRangeValue

                With crParameterRangeValue
                    .EndValue = Maximo
                    .LowerBoundType = RangeBoundType.BoundInclusive
                    .StartValue = Minimo
                    .UpperBoundType = RangeBoundType.BoundInclusive
                End With

                crParameterValues.Add(crParameterRangeValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoProducto
                crParameterDiscreteValue.Value = 0
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
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Categoria")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Sub-Categoria
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@SubCategoria")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Medida
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Medida")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Marca
                crParameterDiscreteValue.Value = 0
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
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TipoItbis
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoItbis")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Garantia
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Garantia")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Promocion
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Promocion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Devolucion
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Devolucion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@VenderCosto
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@VenderCosto")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Descontinuado
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Descontinuado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@NoSerial
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NoSerial")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Estado
                crParameterDiscreteValue.Value = 2
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Existencia
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Existencia")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Inventario
                crParameterDiscreteValue.Value = 0
                ObjRpt.SetParameterValue("@InventarioCant", 0)
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
                ObjRpt.SetParameterValue("@SortedField", "Código Producto")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "Código Producto")
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ''Almacenes
                ObjRpt.SetParameterValue("Almacenes", "Todos los almacenes")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvProductos.SelectedRows.Count > 0 Then
                    Dim IDArticulo As New Label
                    IDArticulo.Text = DgvProductos.SelectedRows(0).Cells(0).Value

                    '@IDArticulo
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDArticulo")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterRangeValue = New ParameterRangeValue

                    With crParameterRangeValue
                        .EndValue = IDArticulo.Text
                        .LowerBoundType = RangeBoundType.BoundInclusive
                        .StartValue = IDArticulo.Text
                        .UpperBoundType = RangeBoundType.BoundInclusive
                    End With

                    crParameterValues.Add(crParameterRangeValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@TipoProducto
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoProducto")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Departamento
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Departamento")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Categoria
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Categoria")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Sub-Categoria
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@SubCategoria")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Medida
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Medida")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Marca
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Marca")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Suplidor
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Suplidor")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Almacen
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@TipoItbis
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TipoItbis")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Garantia
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Garantia")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Promocion
                    crParameterDiscreteValue.Value = 2
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Promocion")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Devolucion
                    crParameterDiscreteValue.Value = 2
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Devolucion")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@VenderCosto
                    crParameterDiscreteValue.Value = 2
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@VenderCosto")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Descontinuado
                    crParameterDiscreteValue.Value = 2
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Descontinuado")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@NoSerial
                    crParameterDiscreteValue.Value = 2
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NoSerial")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Estado
                    crParameterDiscreteValue.Value = 2
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Existencia
                    crParameterDiscreteValue.Value = 0
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Existencia")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    '@Inventario
                    crParameterDiscreteValue.Value = 0
                    ObjRpt.SetParameterValue("@InventarioCant", 0)
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Inventario")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    'Setting Info 
                    'Resumir Reporte
                    ObjRpt.SetParameterValue("@Resumir", 0)
                    'Ordenamiento de Reporte
                    ObjRpt.SetParameterValue("@SortedField", "Descripción")
                    ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "Descripción")
                    'Usuario Info
                    ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                    ''Almacenes
                    ObjRpt.SetParameterValue("Almacenes", "Todos los almacenes")

                Else
                    MessageBox.Show("No hay una fila seleccionada.")
                    Exit Sub
                End If
            End If

            LoadAnimation()

            If rdbPresentacion.Checked = True Then
                lblStatusBar.Text = "Visualizando el reporte..."
                Dim TmpForm = New frm_reportView
                TmpForm.Show(Me)
                TmpForm.CrystalViewer.ReportSource = ObjRpt
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