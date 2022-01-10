Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Imports System.Drawing.Printing
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors
Imports System.Windows.Forms.DataVisualization.Charting
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid

Public Class frm_mant_articulos

    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Friend ControlParent As Integer
    Dim Adaptador As MySqlDataAdapter
    Friend RutaDocumento, lblIDPrecio, lblAnularPrecio, lblTipoMedida, Piezaje, lblCheckDuplicates, PathReport As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos, Precios As New ArrayList

    Private fromIndex1 As Integer
    Private dragIndex1 As Integer
    Private dragRect1 As Rectangle

    Private fromIndex2 As Integer
    Private dragIndex2 As Integer
    Private dragRect2 As Rectangle

    Private fromIndex3 As Integer
    Private dragIndex3 As Integer
    Private dragRect3 As Rectangle

    Private IDMarcaTMP As String
    Private MarcaTMP As String

    Dim ChangingfromTreeview As Boolean = True
    Dim TablaDatosHistorial As DataTable = New DataTable("Datos")

    Dim TablaQuestions As DataTable = New DataTable("Questions")
    Dim RepositoryQuestionTittle As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit() With {.WordWrap = True, .AcceptsReturn = False, .AcceptsTab = False}
    Dim RepositoryQuestionText As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit() With {.WordWrap = True, .AcceptsReturn = False, .AcceptsTab = False}
    Dim RepositoryQuestionDelete As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit() With {.Name = "Eliminar"}
    Dim RepositoryQuestionType As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}

    Dim TablaCambiosPrecios As DataTable = New DataTable("CambiosPrecios")

    Private Sub frm_mant_articulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        DgvColumnsPrecios()
        CargarConfiguracion()
        LimpiarDatosProducto()
        ActualizarDatos()
        RefrescarHistorial()
        FillTablaCambiosPrecios()
        RefrescarQuestions()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub CargarConfiguracion()
        Try
            ConLibregco.Open()

            'PermitirModContenido.Text = CInt(DTConfiguracion.Rows(115 - 1).Item("Value2Int"))

            'Activar evento de Black Friday
            If CInt(DTConfiguracion.Rows(131 - 1).Item("Value2Int")) = 0 Then
                If TabControl4.Contains(TabPage16) Then
                    TabControl4.TabPages.Remove(TabPage16)
                End If

            Else
                If TabControl4.Contains(TabPage16) Then
                Else
                    TabControl4.TabPages.Add(TabPage16)
                End If

                FillReportes()
            End If

            Ds.Dispose()
            cbxMoneda.Properties.Items.Clear()
            cbxMonedaComplementario.Properties.Items.Clear()
            cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM tipomoneda order by IDTipoMoneda ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "tipomoneda")

            For Each Fila As DataRow In Ds.Tables("tipomoneda").Rows
                Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem
                nvmoneda.Value = Fila.Item("IDTipoMoneda")

                If Fila.Item("IDTipoMoneda") = 1 Then
                    nvmoneda.ImageIndex = 0
                ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                    nvmoneda.ImageIndex = 1
                ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                    nvmoneda.ImageIndex = 2
                End If

                cbxMoneda.Properties.Items.Add(nvmoneda)
                cbxMonedaComplementario.Properties.Items.Add(nvmoneda)
            Next
            Ds.Dispose()


            'Moneda predeterminada
            'DefaultCurrency.Text = CInt(DTConfiguracion.Rows(209 - 1).Item("Value2Int"))

            ConLibregco.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillReportes()
        Try
            Ds.Clear()
            cmd = New MySqlCommand("SELECT * FROM libregco.reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize where IDReportes=233 and Reportes.Activo=1 and PaperSize.Activo=1 UNION ALL SELECT * FROM libregco.reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize where IDReportes=234 and Reportes.Activo=1 and PaperSize.Activo=1", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Reportes")
            CbxFormato.Items.Clear()

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

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Sub DgvColumnsPrecios()
        DgvPrecios.Columns.Clear()

        Dim ColImage As New DataGridViewImageColumn
        ColImage.Name = "ColImage"
        ColImage.HeaderText = "Moneda"
        ColImage.ImageLayout = DataGridViewImageCellLayout.Zoom

        With DgvPrecios
            .Columns.Add("IDPrecios", "IDPrecios")  '0
            .Columns.Add("IDMedida", "IDMedida") '1
            .Columns.Add("Abreviatura", "Medida") '2
            .Columns.Add("Contenido", "Contenido")  '3
            .Columns.Add("Costo", "Costo Compra") '4
            .Columns.Add("CostoFinal", "Costo Final") '5
            .Columns.Add("Descuento", "Desc. Máx.") '6
            .Columns.Add("Precio1", "Precio A") '7
            .Columns.Add("Precio2", "Precio B") '8
            .Columns.Add("Precio3", "Precio C") '9
            .Columns.Add("Precio4", "Precio D") '10
            .Columns.Add("Nulo", "Nulo") '11
            .Columns.Add("ClaveCosto", "Clave de costos") '12
            .Columns.Add("PrecioBlackFriday", "Black Friday") '13
            .Columns.Add("TipoMedida", "TipoMedida") '14
            .Columns.Add("Piezaje", "Piezaje") '15
            .Columns.Add("IDMoneda", "IDMoneda") '16
            .Columns.Add(ColImage)     '17
        End With

        PropiedadDgvPrecios()
    End Sub

    Private Sub PropiedadDgvPrecios()
        Try

            With DgvPrecios
                .Columns("IDPrecios").Visible = False
                .Columns("IDMedida").Visible = False
                .Columns("Abreviatura").Width = 91
                .Columns("Abreviatura").ReadOnly = True

                .Columns("Contenido").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Contenido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Contenido").Width = 63
                .Columns("Contenido").ReadOnly = True

                .Columns("Costo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Costo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Costo").Width = 93
                .Columns("Costo").DefaultCellStyle.Format = ("C")
                .Columns("Costo").ReadOnly = True

                .Columns("CostoFinal").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("CostoFinal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("CostoFinal").Width = 93
                .Columns("CostoFinal").DefaultCellStyle.Format = ("C")
                .Columns("CostoFinal").ReadOnly = True

                .Columns("Descuento").DefaultCellStyle.Format = ("P")
                .Columns("Descuento").Width = 46
                .Columns("Descuento").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Descuento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Descuento").ReadOnly = True

                .Columns("Precio1").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Precio1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Precio1").DefaultCellStyle.Format = ("C")
                .Columns("Precio1").Width = 95
                .Columns("Precio1").ReadOnly = True

                .Columns("Precio2").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Precio2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Precio2").DefaultCellStyle.Format = ("C")
                .Columns("Precio2").ReadOnly = True
                .Columns("Precio2").Width = 93

                .Columns("Precio3").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Precio3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Precio3").DefaultCellStyle.Format = ("C")
                .Columns("Precio3").ReadOnly = True
                .Columns("Precio3").Width = 93

                .Columns("Precio4").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Precio4").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Precio4").DefaultCellStyle.Format = ("C")
                .Columns("Precio4").ReadOnly = True
                .Columns("Precio4").Width = 93

                .Columns("Nulo").Visible = False

                .Columns("ClaveCosto").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("ClaveCosto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("ClaveCosto").ReadOnly = True
                .Columns("ClaveCosto").Width = 100

                .Columns("PrecioBlackFriday").Visible = False
                .Columns("TipoMedida").Visible = False

                .Columns("Piezaje").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Piezaje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Piezaje").ReadOnly = False
                .Columns("Piezaje").Width = 80
                .Columns("IDMoneda").Visible = False

                .Columns(17).DisplayIndex = 4
                .Columns(17).Width = 55
            End With
        Catch ex As Exception

        End Try

    End Sub

    Sub RefrescarQuestions()
        TablaQuestions.Columns.Clear()
        TablaQuestions.Clear()

        RepositoryQuestionDelete.Buttons(0).Caption = "Eliminar"
        RepositoryQuestionDelete.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
        RepositoryQuestionDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        RepositoryQuestionDelete.LookAndFeel.UseDefaultLookAndFeel = False
        RepositoryQuestionDelete.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)

        TablaQuestions.Columns.Add("colores", System.Type.GetType("System.String"))
        TablaQuestions.Columns.Add("idArticulos_preguntas", System.Type.GetType("System.String"))
        TablaQuestions.Columns.Add("Titulo", System.Type.GetType("System.String"))
        TablaQuestions.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaQuestions.Columns.Add("Abierta", System.Type.GetType("System.String"))
        TablaQuestions.Columns.Add("Opciones", System.Type.GetType("System.String"))
        TablaQuestions.Columns.Add("Eliminar", System.Type.GetType("System.String"))

        GridControl1.DataSource = TablaQuestions
        GridView1.Columns("colores").Width = 5
        GridView1.Columns("colores").Caption = " "
        GridView1.Columns("colores").OptionsColumn.AllowShowHide = False
        GridView1.Columns("colores").OptionsColumn.ShowInExpressionEditor = False
        GridView1.Columns("colores").OptionsColumn.ShowCaption = False
        GridView1.Columns("colores").OptionsColumn.AllowSize = False
        GridView1.Columns("colores").OptionsColumn.AllowEdit = False
        GridView1.Columns("colores").OptionsColumn.ReadOnly = True
        GridView1.Columns("colores").OptionsFilter.AllowFilter = False
        GridView1.Columns("idArticulos_preguntas").Width = 80
        GridView1.Columns("idArticulos_preguntas").OptionsColumn.AllowEdit = False
        GridView1.Columns("idArticulos_preguntas").OptionsColumn.ReadOnly = True
        GridView1.Columns("idArticulos_preguntas").Visible = False
        GridView1.Columns("Titulo").Caption = "Título"
        GridView1.Columns("Titulo").Width = 200
        GridView1.Columns("Titulo").ColumnEdit = RepositoryQuestionTittle
        GridView1.Columns("Descripcion").Caption = "Descripción"
        GridView1.Columns("Descripcion").Width = 400
        GridView1.Columns("Descripcion").ColumnEdit = RepositoryQuestionText
        GridView1.Columns("Abierta").Caption = "Abierta"
        GridView1.Columns("Abierta").Width = 75
        GridView1.Columns("Abierta").ColumnEdit = RepositoryQuestionType
        GridView1.Columns("Opciones").Width = 200
        GridView1.Columns("Opciones").Caption = "Parámetros"
        GridView1.Columns("Eliminar").ColumnEdit = RepositoryQuestionDelete
    End Sub
    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        If e.Column.FieldName = "colores" Then
            If currentView.GetRowCellValue(e.RowHandle, "idArticulos_preguntas") = "" Then
                e.Appearance.BackColor = Color.Red
            Else
                e.Appearance.BackColor = Color.LightGreen
            End If
        End If
    End Sub


    Private Sub GridView1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        Try
            If GridView1.FocusedRowHandle >= 0 Then
                If GridView1.FocusedColumn.FieldName = "Eliminar" Then
                    If GridView1.GetFocusedRowCellDisplayText("idArticulos_preguntas").ToString = "" Then
                        GridView1.DeleteRow(GridView1.FocusedRowHandle)
                    Else
                        Dim Result1 As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar la pregunta " & vbNewLine & vbNewLine & GridView1.GetFocusedRowCellValue("Titulo") & vbNewLine & vbNewLine & " para el artículo " & txtDescrip.Text & "?", "Eliminar pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If Result1 = MsgBoxResult.Yes Then
                            ConLibregco.Open()
                            cmd = New MySqlCommand("UPDATE articulos_preguntas SET Nulo=1 WHERE idArticulos_preguntas=(" + GridView1.GetFocusedRowCellValue("idArticulos_preguntas").ToString + ")", ConLibregco)
                            cmd.ExecuteNonQuery()
                            ConLibregco.Close()

                            GridView1.DeleteRow(GridView1.FocusedRowHandle)
                        End If
                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub GridView1_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("idArticulos_preguntas"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("Titulo"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("Descripcion"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("Abierta"), 1)
        view.SetRowCellValue(e.RowHandle, view.Columns("Opciones"), "")
    End Sub

    Sub RefrescarHistorial()
        TablaDatosHistorial.Columns.Add("Moneda", System.Type.GetType("System.String"))
        TablaDatosHistorial.Columns.Add("SecondID", System.Type.GetType("System.String"))
        TablaDatosHistorial.Columns.Add("Documento", System.Type.GetType("System.String"))
        TablaDatosHistorial.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
        TablaDatosHistorial.Columns.Add("NombreFactura", System.Type.GetType("System.String"))
        TablaDatosHistorial.Columns.Add("Medida", System.Type.GetType("System.String"))
        TablaDatosHistorial.Columns.Add("Cantidad", System.Type.GetType("System.String"))
        TablaDatosHistorial.Columns.Add("Acumulado", System.Type.GetType("System.String"))
        TablaDatosHistorial.Columns.Add("Signo", System.Type.GetType("System.String"))
        TablaDatosHistorial.Columns.Add("Precio", System.Type.GetType("System.Double"))

        TablaDatosHistorial.Columns("Moneda").Unique = False
        TablaDatosHistorial.Columns("SecondID").Unique = False
        GcHistorial.DataSource = TablaDatosHistorial

        GvHistorial.Columns("SecondID").Caption = "# Documento"
        GvHistorial.Columns("SecondID").Width = 120


        GvHistorial.Columns("Documento").Caption = "T/D"
        GvHistorial.Columns("Documento").Width = 200

        GvHistorial.Columns("Fecha").DisplayFormat.FormatType = FormatType.DateTime
        GvHistorial.Columns("Fecha").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"
        GvHistorial.Columns("Fecha").Width = 155

        GvHistorial.Columns("NombreFactura").Caption = " "
        GvHistorial.Columns("NombreFactura").Visible = False

        GvHistorial.Columns("Medida").Width = 75
        GvHistorial.Columns("Medida").Visible = False

        GvHistorial.Columns("Cantidad").Width = 70

        GvHistorial.Columns("Acumulado").Caption = "Acum."
        GvHistorial.Columns("Acumulado").Width = 70

        GvHistorial.Columns("Signo").Width = 40
        GvHistorial.Columns("Signo").Caption = " "

        GvHistorial.Columns("Precio").Width = 120

        GvHistorial.Columns("Precio").DisplayFormat.FormatType = FormatType.Numeric
        GvHistorial.Columns("Precio").DisplayFormat.FormatString = "C2"

        GvHistorial.Columns("Moneda").GroupIndex = 0
    End Sub

    Private Sub RemoverColores()
        PColor.Controls.Clear()

    End Sub

    Sub FillSubColors()
        PColor.Controls.Clear()

        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT ColorDetalleARGB FROM libregco.color_detalle Where IDColor='" + PColor.Tag.ToString + "'", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "color")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("color")

        Dim xLoc As Double = 0
        Dim WidhtS As Double = CInt(PColor.Width / Tabla.Rows.Count)

        For Each dt As DataRow In Tabla.Rows
            Dim CPanel As New Panel

            With CPanel
                .BackColor = Color.FromArgb(dt.Item(0))
                .Name = Now.ToString("yyyyMMddHHmmss")
                .Location = New Point(xLoc, 0)
                .Size = New Size(WidhtS, PColor.Height)
            End With

            PColor.Controls.Add(CPanel)
            xLoc += WidhtS
        Next

        Ds.Clear()
        Tabla.Clear()
    End Sub
    Sub CargarHistorial()
        Try
            TablaDatosHistorial.Rows.Clear()

            If Me.Owner.Name = frm_prefacturacion.Name Then
                    chkVentas.Checked = True
                    chkCompras.Checked = False
                    chkAjustesEntrada.Checked = False
                    chkAjustesSalida.Checked = False
                    chkDevoluciones.Checked = False
                    chkEntradas.Checked = False
                    chkReparaciones.Checked = False
                    chkDevolucionesCompra.Checked = False
                    chkInvInicial.Checked = False
                    chkCompras.Enabled = False
                    chkAjustesEntrada.Enabled = False
                    chkAjustesSalida.Enabled = False
                    chkDevoluciones.Enabled = False
                    chkEntradas.Enabled = False
                    chkReparaciones.Enabled = False
                    chkDevolucionesCompra.Enabled = False
                    chkInvInicial.Enabled = False

                    If chkVentas.Checked = True Then
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommandA As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,FacturaDatos.SecondID,TipoDocumento.Documento,timestamp(FacturaDatos.Fecha,FacturaDatos.Hora) as Fecha,FacturaDatos.NombreFactura,Medida.Medida,-(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,Importe/Cantidad as Precio from Libregco.facturaarticulos INNER JOIN Libregco.Medida on FacturaArticulos.IDMedida=Medida.IDMedida INNER JOIN Libregco.FacturaDatos on facturaarticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Clientes on facturadatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Precioarticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios WHERE FacturaArticulos.IDArticulo='" + txtIDProducto.Text + "' and FacturaDatos.Nulo=0 and FacturaDatos.IDCliente='" + frm_prefacturacion.txtIDCliente.Text + "'" & If(chkFiltrarExistencia.Checked, " and FacturaDatos.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReaderA As MySqlDataReader = myCommandA.ExecuteReader
                                TablaDatosHistorial.Load(myReaderA, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using

                        TablaDatosHistorial.EndLoadData()

                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommandB As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda, FacturaDatos.SecondID,TipoDocumento.Documento,timestamp(FacturaDatos.Fecha,FacturaDatos.Hora) as Fecha,FacturaDatos.NombreFactura,Medida.Medida,-(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,Importe/Cantidad as Precio from Libregco_Main.facturaarticulos INNER JOIN Libregco.Medida on FacturaArticulos.IDMedida=Medida.IDMedida INNER JOIN Libregco_Main.FacturaDatos on facturaarticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco_Main.TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco_Main.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Clientes on facturadatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Precioarticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios WHERE FacturaArticulos.IDArticulo='" + txtIDProducto.Text + "' and FacturaDatos.Nulo=0 and FacturaDatos.IDCliente='" + frm_prefacturacion.txtIDCliente.Text + "'" & If(chkFiltrarExistencia.Checked, " and FacturaDatos.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReaderB As MySqlDataReader = myCommandB.ExecuteReader
                                TablaDatosHistorial.Load(myReaderB, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using
                        TablaDatosHistorial.EndLoadData()
                    End If

                ElseIf Me.Owner.Name = frm_facturacion.Name Then
                    chkVentas.Checked = True
                    chkCompras.Enabled = False
                    chkAjustesEntrada.Enabled = False
                    chkAjustesSalida.Enabled = False
                    chkDevoluciones.Enabled = False
                    chkEntradas.Enabled = False
                    chkReparaciones.Enabled = False
                    chkDevolucionesCompra.Enabled = False
                    chkInvInicial.Enabled = False


                    chkCompras.Checked = False
                    chkAjustesEntrada.Checked = False
                    chkAjustesSalida.Checked = False
                    chkDevoluciones.Checked = False
                    chkEntradas.Checked = False
                    chkReparaciones.Checked = False
                    chkDevolucionesCompra.Checked = False
                    chkInvInicial.Checked = False

                    If chkVentas.Checked = True Then
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommandA As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,FacturaDatos.SecondID,TipoDocumento.Documento,timestamp(FacturaDatos.Fecha,FacturaDatos.Hora) as Fecha,FacturaDatos.NombreFactura,Medida.Medida,-(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,Importe/Cantidad as Precio from Libregco.facturaarticulos INNER JOIN Libregco.Medida on FacturaArticulos.IDMedida=Medida.IDMedida INNER JOIN Libregco.FacturaDatos on facturaarticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Clientes on facturadatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Precioarticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios WHERE FacturaArticulos.IDArticulo='" + txtIDProducto.Text + "' and FacturaDatos.Nulo=0 and FacturaDatos.IDCliente='" + frm_facturacion.txtIDCliente.Text + "'" & If(chkFiltrarExistencia.Checked, " and FacturaDatos.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReaderA As MySqlDataReader = myCommandA.ExecuteReader
                                TablaDatosHistorial.Load(myReaderA, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using

                        TablaDatosHistorial.EndLoadData()

                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommandB As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,FacturaDatos.SecondID,TipoDocumento.Documento,timestamp(FacturaDatos.Fecha,FacturaDatos.Hora) as Fecha,FacturaDatos.NombreFactura,Medida.Medida,-(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,Importe/Cantidad as Precio from Libregco_Main.facturaarticulos INNER JOIN Libregco.Medida on FacturaArticulos.IDMedida=Medida.IDMedida INNER JOIN Libregco_Main.FacturaDatos on facturaarticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco_Main.TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco_Main.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Clientes on facturadatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Precioarticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios WHERE FacturaArticulos.IDArticulo='" + txtIDProducto.Text + "' and FacturaDatos.Nulo=0 and FacturaDatos.IDCliente='" + frm_facturacion.txtIDCliente.Text + "'" & If(chkFiltrarExistencia.Checked, " and FacturaDatos.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReaderB As MySqlDataReader = myCommandB.ExecuteReader
                                TablaDatosHistorial.Load(myReaderB, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using
                        TablaDatosHistorial.EndLoadData()
                    End If

                Else

                    ''''''''Z
                    If chkCompras.Checked = True Then
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,Compras.SecondID,TipoDocumento.Documento,timestamp(Compras.Fecha,Compras.Hora) as Fecha,Suplidor as NombreFactura,Medida.Medida,(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,Round(Importe,3) as Precio from Libregco.detallecompra INNER JOIN Libregco.Medida on DetalleCompra.IDMedida=Medida.IDMedida INNER JOIN Libregco.compras on detallecompra.IDCompra=Compras.IDCompra INNER JOIN Libregco.TipoDocumento on Compras.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.TipoMoneda on Compras.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.precioarticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios WHERE DetalleCompra.IDArticulo='" + txtIDProducto.Text + "' and Compras.Nulo=0" & If(chkFiltrarExistencia.Checked, " and Compras.FechaFactura Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using

                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkVentas.Checked = True Then
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommandA As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,FacturaDatos.SecondID,TipoDocumento.Documento,timestamp(FacturaDatos.Fecha,FacturaDatos.Hora) as Fecha,FacturaDatos.NombreFactura,Medida.Medida,-(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,Importe/Cantidad as Precio from Libregco.facturaarticulos INNER JOIN Libregco.Medida on FacturaArticulos.IDMedida=Medida.IDMedida INNER JOIN Libregco.FacturaDatos on facturaarticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Clientes on facturadatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Precioarticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios WHERE FacturaArticulos.IDArticulo='" + txtIDProducto.Text + "' and FacturaDatos.Nulo=0" & If(chkFiltrarExistencia.Checked, " and FacturaDatos.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReaderA As MySqlDataReader = myCommandA.ExecuteReader
                                TablaDatosHistorial.Load(myReaderA, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using

                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkAjustesEntrada.Checked = True Then
                        '''''''Ajuste de Entrada
                        'Dim AnexoAjusteEntrada As New MySqlCommand("Select MovimientoInventario.SecondID,movimientoinventario.Fecha,MovimientoInventario.Hora,(Cantidad * Contenido) as Resultado,Importe from Libregco.movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco.Precioarticulo on movimientoinvdetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE Movimientoinvdetalle.IDArticulo='" + txtIDProducto.Text + "' and Movimientoinventario.IDTipodeAjuste=1 and Movimientoinventario.Nulo=0", ConMixta)
                        'Dim Lector2 As MySqlDataReader = AnexoAjusteEntrada.ExecuteReader

                        'While Lector2.Read
                        '    DgvHistorialArt.Rows.Add(Lector2.GetValue(0), CDate(Lector2.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector2.GetValue(2)), "Ajuste", "Ajuste de Entrada", Lector2.GetValue(3), "", "", Lector2.GetValue(4))
                        'End While
                        'Lector2.Close()
                        ''''''Ajuste de Entrada
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,MovimientoInventario.SecondID,Concat(TipoDocumento.Documento,' [ENTRADA]') as Documento,Timestamp(movimientoinventario.Fecha,MovimientoInventario.Hora) as Fecha,'' as NombreFactura,Medida.Medida,(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,(Importe/Cantidad) as Precio from Libregco.movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco.TipoDocumento on MovimientoInventario.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Precioarticulo on movimientoinvdetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida WHERE Movimientoinvdetalle.IDArticulo='" + txtIDProducto.Text + "' and movimientoinvdetalle.IDTipoAjusteDetalle=1 and Movimientoinventario.Nulo=0" & If(chkFiltrarExistencia.Checked, " and movimientoinventario.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using

                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkAjustesSalida.Checked = True Then
                        ''''''Ajuste de Salida
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,MovimientoInventario.SecondID,Concat(TipoDocumento.Documento,' [SALIDA]') as Documento,Timestamp(movimientoinventario.Fecha,MovimientoInventario.Hora) as Fecha,'' as NombreFactura,Medida.Medida,(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,(Importe/Cantidad) as Precio from Libregco.movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco.TipoDocumento on MovimientoInventario.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Precioarticulo on movimientoinvdetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida WHERE Movimientoinvdetalle.IDArticulo='" + txtIDProducto.Text + "' and movimientoinvdetalle.IDTipoAjusteDetalle=2 and Movimientoinventario.Nulo=0" & If(chkFiltrarExistencia.Checked, " and movimientoinventario.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using

                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkDevoluciones.Checked = True Then
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,DevolucionVenta.SecondID,TipoDocumento.Documento,Timestamp(DevolucionVenta.Fecha,DevolucionVenta.Hora) as Fecha,FacturaDatos.NombreFactura,Medida.Medida,(CantDevuelta * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,PrecioDevuelto as Precio from Libregco.Devolucionventadetalle INNER JOIN Libregco.PrecioArticulo on DevolucionVentaDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.devolucionventa on devolucionventadetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta INNER JOIN Libregco.TipoDocumento on DevolucionVenta.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where Devolucionventadetalle.IDArticulo='" + txtIDProducto.Text + "' and CantDevuelta>0 and DevolucionVenta.Nulo=0" & If(chkFiltrarExistencia.Checked, " and DevolucionVenta.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()

                            Using myReader As MySqlDataReader = myCommand.ExecuteReader

                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)

                                ConMixta.Close()

                            End Using
                        End Using
                    End Using

                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkInvInicial.Checked = True Then
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,MovimientoInventario.SecondID,TipoDocumento.Documento,Timestamp(movimientoinventario.Fecha,MovimientoInventario.Hora) as Fecha,'' as NombreFactura,Medida.Medida,(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,Importe as Precio from Libregco.movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco.TipoDocumento on MovimientoInventario.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Precioarticulo on movimientoinvdetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida WHERE Movimientoinvdetalle.IDArticulo='" + txtIDProducto.Text + "' and movimientoinvdetalle.IDTipoAjusteDetalle=3 and Movimientoinventario.Nulo=0" & If(chkFiltrarExistencia.Checked, " and MovimientoInventario.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()

                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using
                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkDevolucionesCompra.Checked = True Then
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,DevolucionCompra.SecondID,TipoDocumento.Documento,Timestamp(DevolucionCompra.Fecha,DevolucionCompra.Hora) As Fecha,Suplidor.Suplidor As NombreFactura,Medida.Medida,-(CantDevuelta * Contenido) As Cantidad,0 As Acumulado,TipoMoneda.Signo,PrecioDevuelto As Precio from Libregco.DevolucionCompraDetalle INNER JOIN Libregco.DevolucionCompra On DevolucionCompraDetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra INNER JOIN Libregco.TipoDocumento On DevolucionCompra.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Compras On DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN Libregco.Suplidor On Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Precioarticulo On DevolucionCompraDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida On DevolucionCompraDetalle.IDMedida=Medida.IDMedida INNER JOIN Libregco.TipoMoneda On Compras.IDMoneda=TipoMoneda.IDTipoMoneda WHERE DevolucionCompraDetalle.IDArticulo='" + txtIDProducto.Text + "' and DevolucionCompra.Nulo=0" & If(chkFiltrarExistencia.Checked, " and DevolucionCompra.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using
                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkReparaciones.Checked = True Then
                        ''''''Reparaciones no procesadas

                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,Reparacion.SecondID,TipoDocumento.Documento,Timestamp(Reparacion.Fecha,Reparacion.Hora) as Fecha,Suplidor.Suplidor as NombreFactura,Medida.Medida,-(Cantidad*Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,0 as Precio from Libregco.ReparacionDetalle INNER JOIN Libregco.Reparacion on ReparacionDetalle.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.TipoDocumento on Reparacion.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.PrecioArticulo on ReparacionDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where ReparacionDetalle.IDArticulo='" + txtIDProducto.Text + "' and Reparacion.IDTipoOrden=1 and Reparacion.Nulo=0" & If(chkFiltrarExistencia.Checked, " and Reparacion.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using
                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkEntradas.Checked = True Then
                        ''''''Entradas de reparaciones
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,EntradaReparacion.SecondID,TipoDocumento.Documento,timestamp(EntradaReparacion.Fecha,EntradaReparacion.Hora) as Fecha,Suplidor.Suplidor as NombreFactura,Medida.Medida,(CantidadRecibida * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,0 as Precio from Libregco.EntradaReparaciondetalle INNER JOIN Libregco.EntradaReparacion on EntradaReparaciondetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Libregco.TipoDocumento on EntradaReparacion.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.precioarticulo on EntradaReparaciondetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and EntradaReparacionDetalle.IDArticulo='" + txtIDProducto.Text + "' and EntradaReparacion.Nulo=0 and Reparacion.Nulo=0" & If(chkFiltrarExistencia.Checked, " and EntradaReparacion.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using
                        TablaDatosHistorial.EndLoadData()
                    End If

                    '''''''''''''''''''''''''''''''A
                    If chkCompras.Checked = True Then
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,Compras.SecondID,TipoDocumento.Documento,timestamp(Compras.Fecha,Compras.Hora) as Fecha,Suplidor as NombreFactura,Medida.Medida,(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,Round(Importe,3) as Precio from Libregco_Main.detallecompra INNER JOIN Libregco.Medida on DetalleCompra.IDMedida=Medida.IDMedida INNER JOIN Libregco_Main.compras on detallecompra.IDCompra=Compras.IDCompra INNER JOIN Libregco_Main.TipoDocumento on Compras.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.TipoMoneda on Compras.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.precioarticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios WHERE DetalleCompra.IDArticulo='" + txtIDProducto.Text + "' and Compras.Nulo=0" & If(chkFiltrarExistencia.Checked, " and Compras.FechaFactura Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using

                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkVentas.Checked = True Then
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,FacturaDatos.SecondID,TipoDocumento.Documento,timestamp(FacturaDatos.Fecha,FacturaDatos.Hora) as Fecha,FacturaDatos.NombreFactura,Medida.Medida,-(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,Importe/Cantidad as Precio from Libregco_Main.facturaarticulos INNER JOIN Libregco.Medida on FacturaArticulos.IDMedida=Medida.IDMedida INNER JOIN Libregco_Main.FacturaDatos on facturaarticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco_Main.TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco_Main.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Clientes on facturadatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Precioarticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios WHERE FacturaArticulos.IDArticulo='" + txtIDProducto.Text + "' and FacturaDatos.Nulo=0" & If(chkFiltrarExistencia.Checked, " and FacturaDatos.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using

                        TablaDatosHistorial.EndLoadData()
                    End If


                    If chkAjustesEntrada.Checked = True Then
                        '''''''Ajuste de Entrada
                        'Dim AnexoAjusteEntrada As New MySqlCommand("Select MovimientoInventario.SecondID,movimientoinventario.Fecha,MovimientoInventario.Hora,(Cantidad * Contenido) as Resultado,Importe from Libregco.movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco.Precioarticulo on movimientoinvdetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE Movimientoinvdetalle.IDArticulo='" + txtIDProducto.Text + "' and Movimientoinventario.IDTipodeAjuste=1 and Movimientoinventario.Nulo=0", ConMixta)
                        'Dim Lector2 As MySqlDataReader = AnexoAjusteEntrada.ExecuteReader

                        'While Lector2.Read
                        '    DgvHistorialArt.Rows.Add(Lector2.GetValue(0), CDate(Lector2.GetValue(1)).ToString("yyyy-MM-dd") & " " & Convert.ToString(Lector2.GetValue(2)), "Ajuste", "Ajuste de Entrada", Lector2.GetValue(3), "", "", Lector2.GetValue(4))
                        'End While
                        'Lector2.Close()
                        ''''''Ajuste de Entrada Nuevos
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,MovimientoInventario.SecondID,Concat(TipoDocumento.Documento,' [ENTRADA]') as Documento,Timestamp(movimientoinventario.Fecha,MovimientoInventario.Hora) as Fecha,'' as NombreFactura,Medida.Medida,(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,(Importe/Cantidad) as Precio from Libregco_Main.movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco_Main.TipoDocumento on MovimientoInventario.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Precioarticulo on movimientoinvdetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida WHERE Movimientoinvdetalle.IDArticulo='" + txtIDProducto.Text + "' and movimientoinvdetalle.IDTipoAjusteDetalle=1 and Movimientoinventario.Nulo=0" & If(chkFiltrarExistencia.Checked, " and MovimientoInventario.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using

                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkAjustesSalida.Checked = True Then
                        ''''''Ajuste de Salida
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,MovimientoInventario.SecondID,Concat(TipoDocumento.Documento,' [SALIDA]') as Documento,Timestamp(movimientoinventario.Fecha,MovimientoInventario.Hora) as Fecha,'' as NombreFactura,Medida.Medida,(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,ABS(Importe/Cantidad) as Precio from Libregco_Main.movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco_Main.TipoDocumento on MovimientoInventario.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Precioarticulo on movimientoinvdetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida WHERE Movimientoinvdetalle.IDArticulo='" + txtIDProducto.Text + "' and movimientoinvdetalle.IDTipoAjusteDetalle=2 and Movimientoinventario.Nulo=0" & If(chkFiltrarExistencia.Checked, " and MovimientoInventario.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using

                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkDevoluciones.Checked = True Then
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,DevolucionVenta.SecondID,TipoDocumento.Documento,Timestamp(DevolucionVenta.Fecha,DevolucionVenta.Hora) as Fecha,FacturaDatos.NombreFactura,Medida.Medida,(CantDevuelta * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,PrecioDevuelto as Precio from Libregco_Main.Devolucionventadetalle INNER JOIN Libregco.PrecioArticulo on DevolucionVentaDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco_Main.devolucionventa on devolucionventadetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta INNER JOIN Libregco_Main.TipoDocumento on DevolucionVenta.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco_Main.FacturaDatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where Devolucionventadetalle.IDArticulo='" + txtIDProducto.Text + "' and CantDevuelta>0 and DevolucionVenta.Nulo=0" & If(chkFiltrarExistencia.Checked, " and DevolucionVenta.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using

                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkInvInicial.Checked = True Then
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,MovimientoInventario.SecondID,TipoDocumento.Documento,Timestamp(movimientoinventario.Fecha,MovimientoInventario.Hora) as Fecha,'' as NombreFactura,Medida.Medida,(Cantidad * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,Importe as Precio from Libregco_Main.movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=MovimientoInventario.IDAjusteInventario INNER JOIN Libregco_Main.TipoDocumento on MovimientoInventario.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Precioarticulo on movimientoinvdetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida WHERE Movimientoinvdetalle.IDArticulo='" + txtIDProducto.Text + "' and movimientoinvdetalle.IDTipoAjusteDetalle=3 and Movimientoinventario.Nulo=0" & If(chkFiltrarExistencia.Checked, " and MovimientoInventario.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using
                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkDevolucionesCompra.Checked = True Then
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,DevolucionCompra.SecondID,TipoDocumento.Documento,Timestamp(DevolucionCompra.Fecha,DevolucionCompra.Hora) As Fecha,Suplidor.Suplidor As NombreFactura,Medida.Medida,-(CantDevuelta * Contenido) As Cantidad,0 As Acumulado,TipoMoneda.Signo,PrecioDevuelto As Precio from Libregco_Main.DevolucionCompraDetalle INNER JOIN Libregco_Main.DevolucionCompra On DevolucionCompraDetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra INNER JOIN Libregco_Main.TipoDocumento On DevolucionCompra.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco_Main.Compras On DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN Libregco.Suplidor On Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Precioarticulo On DevolucionCompraDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida On DevolucionCompraDetalle.IDMedida=Medida.IDMedida INNER JOIN Libregco.TipoMoneda On Compras.IDMoneda=TipoMoneda.IDTipoMoneda WHERE DevolucionCompraDetalle.IDArticulo='" + txtIDProducto.Text + "' and DevolucionCompra.Nulo=0" & If(chkFiltrarExistencia.Checked, " and DevolucionCompra.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using
                        TablaDatosHistorial.EndLoadData()
                    End If

                    If chkReparaciones.Checked = True Then
                        ''''''Reparaciones no procesadas

                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,Reparacion.SecondID,TipoDocumento.Documento,Timestamp(Reparacion.Fecha,Reparacion.Hora) as Fecha,Suplidor.Suplidor as NombreFactura,Medida.Medida,-(Cantidad*Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,0 as Precio from Libregco_Main.ReparacionDetalle INNER JOIN Libregco_Main.Reparacion on ReparacionDetalle.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco_Main.TipoDocumento on Reparacion.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.PrecioArticulo on ReparacionDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where ReparacionDetalle.IDArticulo='" + txtIDProducto.Text + "' and Reparacion.IDTipoOrden=1 and Reparacion.Nulo=0" & If(chkFiltrarExistencia.Checked, " and Reparacion.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using
                        TablaDatosHistorial.EndLoadData()
                    End If


                    If chkEntradas.Checked = True Then
                        ''''''Entradas de reparaciones
                        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                        Using myCommand As MySqlCommand = New MySqlCommand("Select TipoMoneda.Moneda,EntradaReparacion.SecondID,TipoDocumento.Documento,timestamp(EntradaReparacion.Fecha,EntradaReparacion.Hora) as Fecha,Suplidor.Suplidor as NombreFactura,Medida.Medida,(CantidadRecibida * Contenido) as Cantidad,0 as Acumulado,TipoMoneda.Signo,0 as Precio from Libregco_Main.EntradaReparaciondetalle INNER JOIN Libregco_Main.EntradaReparacion on EntradaReparaciondetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Libregco_Main.TipoDocumento on EntradaReparacion.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.precioarticulo on EntradaReparaciondetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda INNER JOIN Libregco_Main.Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and EntradaReparacionDetalle.IDArticulo='" + txtIDProducto.Text + "' and EntradaReparacion.Nulo=0 and Reparacion.Nulo=0" & If(chkFiltrarExistencia.Checked, " and EntradaReparacion.Fecha Between '" & dtpExistenciaDesde.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpExistenciaHasta.Value.ToString("yyyy-MM-dd") & "'", ""), ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaDatosHistorial.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using
                        TablaDatosHistorial.EndLoadData()
                    End If
                End If

                TablaDatosHistorial.DefaultView.Sort = "Fecha ASC"
                TablaDatosHistorial = TablaDatosHistorial.DefaultView.ToTable

                Dim acum As Double = 0
                For Each Rw As DataRow In TablaDatosHistorial.Rows
                    acum += CDbl(Rw.Item("Cantidad"))

                    Rw.Item("Acumulado") = acum
                Next

                GcHistorial.DataSource = TablaDatosHistorial

        Catch ex As Exception
            Dim rowErrors = TablaDatosHistorial.GetErrors()
            System.Diagnostics.Debug.WriteLine("YourDataTable Errors:" & rowErrors.Length)
            For i = 0 To rowErrors.Length - 1
                For Each col As DataColumn In rowErrors(i).GetColumnsInError()
                    System.Diagnostics.Debug.WriteLine(col.ColumnName & ":" & rowErrors(i).GetColumnError(col))
                Next
            Next
        End Try
    End Sub


    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub CargarHijos()
        Try
            DgvHijos.Rows.Clear()
            ConLibregco.Open()
            Dim SQLHijos As New MySqlCommand("SELECT IDProductosHijos,IDPrecioPadre,CantidadParaOferta,MedidaPadre.Medida,PrecioArticuloHijo.IDArticulo, ArticulosHijo.Descripcion, ArticulosHijo.Referencia, CantidadEnOferta, IDPrecioHijo, MedidaHijo.Medida, LimitarHastaFecha, HastaFecha, ValorIncluidoPrecio, Nivel, Precio, Articulos_hijos.Nulo FROM Libregco.articulos_hijos INNER JOIN Libregco.PrecioArticulo as PrecioArticuloPadre on articulos_hijos.IDPrecioPadre=PrecioarticuloPadre.IDPrecios INNER JOIN Libregco.Medida as MedidaPadre on PrecioArticuloPadre.IDMedida=MedidaPadre.IDMedida INNER JOIN Libregco.Articulos as ArticulosPadre on PrecioArticuloPadre.IDArticulo=ArticulosPadre.IDArticulo INNER JOIN Libregco.PrecioArticulo as PrecioArticuloHijo on articulos_hijos.IDPrecioHijo=PrecioarticuloHijo.IDPrecios INNER JOIN Libregco.Articulos as ArticulosHijo on PrecioArticuloHijo.IDArticulo=ArticulosHijo.IDArticulo INNER JOIN Libregco.Medida as MedidaHijo on PrecioArticuloHijo.IDMedida=MedidaHijo.IDMedida Where PrecioArticuloPadre.IDArticulo ='" + txtIDProducto.Text + "'", ConLibregco)
            Dim LectorHijos As MySqlDataReader = SQLHijos.ExecuteReader

            While LectorHijos.Read
                DgvHijos.Rows.Add(LectorHijos.GetValue(0), LectorHijos.GetValue(1), LectorHijos.GetValue(2), LectorHijos.GetValue(3), LectorHijos.GetValue(4), LectorHijos.GetValue(5), LectorHijos.GetValue(6), LectorHijos.GetValue(7), LectorHijos.GetValue(8), LectorHijos.GetValue(9), Convert.ToBoolean(LectorHijos.GetValue(10)), CDate(LectorHijos.GetValue(11)).ToString("dd/MM/yyyy"), Convert.ToBoolean(LectorHijos.GetValue(12)), LectorHijos.GetValue(13), CDbl(LectorHijos.GetValue(14)).ToString("C"), Convert.ToBoolean(LectorHijos.GetValue(15)))
            End While

            LectorHijos.Close()
            ConLibregco.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub RefrescarTablaPrecios()
        Try
            DgvPrecios.Rows.Clear()
            Con.Open()
            Dim SQLPrecios As New MySqlCommand("SELECT IDPrecios,PrecioArticulo.IDMedida,Abreviatura,Contenido,Costo,CostoFinal,DescuentoMaximo,PrecioCredito,PrecioContado,Precio3,Precio4,Nulo,CostoClave,PrecioBlackFriday,TipoMedida,Piezaje,PrecioArticulo.IDMoneda FROM Libregco.precioarticulo INNER JOIN Libregco.medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrecioArticulo.IDArticulo='" + txtIDProducto.Text + "' AND PrecioArticulo.Nulo=0", Con)
            Dim LectorPrecios As MySqlDataReader = SQLPrecios.ExecuteReader

            While LectorPrecios.Read
                DgvPrecios.Rows.Add(LectorPrecios.GetValue(0), LectorPrecios.GetValue(1), LectorPrecios.GetValue(2), LectorPrecios.GetValue(3), LectorPrecios.GetValue(4), LectorPrecios.GetValue(5), LectorPrecios.GetValue(6), LectorPrecios.GetValue(7), LectorPrecios.GetValue(8), LectorPrecios.GetValue(9), LectorPrecios.GetValue(10), LectorPrecios.GetValue(11), LectorPrecios.GetValue(12), LectorPrecios.GetValue(13), LectorPrecios.GetValue(14), LectorPrecios.GetValue(15), LectorPrecios.GetValue(16), If(CInt(LectorPrecios.GetValue(16)) = 1, imgFlags.Images(0), imgFlags.Images(1)))
            End While
            LectorPrecios.Close()
            Con.Close()

            VerificaciondePiezaje()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub VerificaciondePiezaje()
        For Each rw As DataGridViewRow In DgvPrecios.Rows
            If CDbl(rw.Cells("TipoMedida").Value) = 1 Then
                If CDbl(rw.Cells("Piezaje").Value) = 0 Then
                    Dim dstemp As New DataSet

                    Con.Open()
                    cmd = New MySqlCommand("SELECT IDPrecios,PrecioArticulo.IDMedida,Medida.Medida,Abreviatura,Contenido,Costo,CostoFinal,DescuentoMaximo,PrecioCredito,PrecioContado,Precio3,Precio4,Nulo,CostoClave,PrecioBlackFriday,TipoMedida,Piezaje,PrecioAMedida,PrecioBMedida,PrecioCMedida,PrecioDMedida,CostoMedida,MedidaDinamica FROM Libregco.precioarticulo INNER JOIN Libregco.medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrecioArticulo.IDPrecios='" + rw.Cells(0).Value.ToString + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(dstemp, "Precios")
                    Con.Close()

                    Dim TablaMedida As DataTable = dstemp.Tables("Precios")

                    If TablaMedida.Rows.Count > 0 Then
                        frm_piezaje_precios.lblIDPrecio = TablaMedida.Rows(0).Item("IDPrecios")
                        frm_piezaje_precios.lblMedidaPadre.Text = TablaMedida.Rows(0).Item("Medida").ToString.ToUpper
                        frm_piezaje_precios.lblMedidaPadre.Tag = TablaMedida.Rows(0).Item("MedidaDinamica")
                        frm_piezaje_precios.lblDescripcion.Text = txtDescrip.Text.ToUpper
                        frm_piezaje_precios.GroupControl1.Text = "Escriba la cantidad de " & "<u><color=30,144,255><B>" & TablaMedida.Rows(0).Item("MedidaDinamica").ToString.ToUpper & "</B></color></u> que contiene la medida"
                        frm_piezaje_precios.txtPiezaje.EditValue = TablaMedida.Rows(0).Item("Piezaje")
                        frm_piezaje_precios.lblCosto.Text = "Costo: " & CDbl(TablaMedida.Rows(0).Item("CostoMedida")).ToString("C") & " por cada " & "<u><color=30,144,255><B>" & TablaMedida.Rows(0).Item("MedidaDinamica").ToString.ToUpper & "</B></color></u>" & " (" & frm_piezaje_precios.txtPiezaje.Text & " x " & CDbl(TablaMedida.Rows(0).Item("CostoMedida")).ToString("C") & ")"
                        frm_piezaje_precios.lblCosto.Tag = CDbl(TablaMedida.Rows(0).Item("CostoMedida"))
                        frm_piezaje_precios.lblPrecio.Text = "Precio:" & CDbl(TablaMedida.Rows(0).Item("PrecioAMedida")).ToString("C") & " por cada " & "<u><color=30,144,255><B>" & TablaMedida.Rows(0).Item("MedidaDinamica").ToString.ToUpper & "</B></color></u>" & " (" & frm_piezaje_precios.txtPiezaje.Text & " x " & CDbl(TablaMedida.Rows(0).Item("PrecioAMedida")).ToString("C") & ")"
                        frm_piezaje_precios.lblPrecio.Tag = CDbl(TablaMedida.Rows(0).Item("PrecioAMedida"))
                        frm_piezaje_precios.PA.Text = CDbl(TablaMedida.Rows(0).Item("PrecioAMedida")).ToString("C")
                        frm_piezaje_precios.PB.Text = CDbl(TablaMedida.Rows(0).Item("PrecioBMedida")).ToString("C")
                        frm_piezaje_precios.PC.Text = CDbl(TablaMedida.Rows(0).Item("PrecioCMedida")).ToString("C")
                        frm_piezaje_precios.PD.Text = CDbl(TablaMedida.Rows(0).Item("PrecioDMedida")).ToString("C")

                        frm_piezaje_precios.txtCosto.EditValue = RoundUp(CDbl(CDbl(frm_piezaje_precios.lblCosto.Tag) * CDbl(frm_piezaje_precios.txtPiezaje.EditValue)), Convert.ToInt16(frm_piezaje_precios.chkRedondear.Checked))
                        frm_piezaje_precios.txtPrecio.EditValue = RoundUp(CDbl(CDbl(frm_piezaje_precios.lblPrecio.Tag) * CDbl(frm_piezaje_precios.txtPiezaje.EditValue)), Convert.ToInt16(frm_piezaje_precios.chkRedondear.Checked))
                        frm_piezaje_precios.txtPrecioA.EditValue = RoundUp(CDbl(CDbl(frm_piezaje_precios.PA.Text) * CDbl(frm_piezaje_precios.txtPiezaje.EditValue)), Convert.ToInt16(frm_piezaje_precios.chkRedondear.Checked))
                        frm_piezaje_precios.txtPrecioB.EditValue = RoundUp(CDbl(CDbl(frm_piezaje_precios.PB.Text) * CDbl(frm_piezaje_precios.txtPiezaje.EditValue)), Convert.ToInt16(frm_piezaje_precios.chkRedondear.Checked))
                        frm_piezaje_precios.txtPrecioC.EditValue = RoundUp(CDbl(CDbl(frm_piezaje_precios.PC.Text) * CDbl(frm_piezaje_precios.txtPiezaje.EditValue)), Convert.ToInt16(frm_piezaje_precios.chkRedondear.Checked))
                        frm_piezaje_precios.txtPrecioD.EditValue = RoundUp(CDbl(CDbl(frm_piezaje_precios.PD.Text) * CDbl(frm_piezaje_precios.txtPiezaje.EditValue)), Convert.ToInt16(frm_piezaje_precios.chkRedondear.Checked))



                        frm_piezaje_precios.ShowDialog(Me)
                    End If


                End If
            End If
        Next
    End Sub

    Sub FillTablaCambiosPrecios()
        Dim RepositoryDescripcion As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit() With {.WordWrap = True, .AcceptsReturn = False, .AcceptsTab = False}
        Dim ReposityImagen As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit() With {.PictureAlignment = ContentAlignment.MiddleCenter, .SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom}

        TablaCambiosPrecios.Columns.Clear()
        TablaCambiosPrecios.Clear()

        TablaCambiosPrecios.Columns.Add("IDCambioPrecio", System.Type.GetType("System.String"))
        TablaCambiosPrecios.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
        TablaCambiosPrecios.Columns.Add("Medida", System.Type.GetType("System.String"))
        TablaCambiosPrecios.Columns.Add("IDUsuario", System.Type.GetType("System.String"))
        TablaCambiosPrecios.Columns.Add("Foto", System.Type.GetType("System.Object"))
        TablaCambiosPrecios.Columns.Add("Usuario", System.Type.GetType("System.String"))
        TablaCambiosPrecios.Columns.Add("Descripcion", System.Type.GetType("System.String"))

        GCHistorialPrecios.DataSource = TablaCambiosPrecios

        GridView2.Columns("Descripcion").ColumnEdit = RepositoryDescripcion
        GridView2.Columns("Foto").ColumnEdit = ReposityImagen

        GridView2.Columns("IDCambioPrecio").Visible = False
        GridView2.Columns("Fecha").Width = 145
        GridView2.Columns("Fecha").OptionsColumn.AllowEdit = False
        GridView2.Columns("Fecha").OptionsColumn.ReadOnly = True
        GridView2.Columns("Fecha").Visible = True
        GridView2.Columns("Medida").Width = 120
        GridView2.Columns("IDUsuario").Visible = False
        GridView2.Columns("Usuario").Width = 260
        GridView2.Columns("Descripcion").Width = 400
        GridView2.Columns("Fecha").DisplayFormat.FormatType = FormatType.Custom
        GridView2.Columns("Fecha").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"

        GridView2.Columns("Fecha").GroupIndex = 0

    End Sub

    Sub RefrescarTablaHistorialPrecios()
        Try
            Dim wFilePath As System.IO.FileStream
            Dim RutaImage As Image

            TablaCambiosPrecios.Rows.Clear()

            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

            Con.Open()
            Dim SQLPrecios As New MySqlCommand("Select idprecioarticulo_historial,Fecha,Medida.Medida,IDUsuario,Empleados.RutaFoto,Empleados.Nombre,Modificacion FROM libregco.precioarticulo_historial INNER JOIN Libregco.PrecioArticulo On PrecioArticulo_historial.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida On PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN libregco.empleados On precioarticulo_historial.idusuario=empleados.idempleado where precioarticulo.IDArticulo='" + txtIDProducto.Text + "' ORDER BY precioarticulo_historial.Fecha DESC", Con)
            Dim LectorPrecios As MySqlDataReader = SQLPrecios.ExecuteReader

            While LectorPrecios.Read
                If System.IO.File.Exists(LectorPrecios.GetValue(4)) = True Then
                    wFilePath = New FileStream(LectorPrecios.GetValue(4), FileMode.Open, FileAccess.Read)
                    RutaImage = ResizeImage(System.Drawing.Image.FromStream(wFilePath), 60)
                    wFilePath.Close()
                Else
                    RutaImage = My.Resources.No_Image
                End If

                TablaCambiosPrecios.Rows.Add(LectorPrecios.GetValue(0), CDate(LectorPrecios.GetValue(1)), LectorPrecios.GetValue(2), LectorPrecios.GetValue(3), RutaImage, LectorPrecios.GetValue(5), LectorPrecios.GetValue(6))

            End While
            LectorPrecios.Close()
            Con.Close()

            GridView2.BeginDataUpdate()

            Try
                GridView2.ClearSorting()
                GridView2.Columns("Fecha").SortOrder = DevExpress.Data.ColumnSortOrder.Descending

            Finally
                GridView2.EndDataUpdate()
            End Try

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    'asfasfas vincular precio guardar
    Sub RefrescarTablaColectivos()
        If CStr(txtIDGrupo.Tag).ToString <> "" Then
            If CStr(txtIDGrupo.Tag) <> "1" Then

                Dim dstemp As New DataSet

                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT idArticulos_grupos,Colectivo,VincularPrecio FROM libregco.articulos_grupos where idArticulos_grupos='" + txtIDGrupo.Tag.ToString + "'", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(dstemp, "articulos_grupos")
                ConLibregco.Close()

                Dim TablaGrupo As DataTable = dstemp.Tables("articulos_grupos")

                If TablaGrupo.Rows.Count > 0 Then
                    txtGrupoNombre.Text = TablaGrupo.Rows(0).Item("Colectivo")
                    chkVincularPrecio.Checked = Convert.ToBoolean(TablaGrupo.Rows(0).Item("VincularPrecio"))
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim wFilePath, wFileColor As System.IO.FileStream
                Dim RutaImage, RutaColor As Image

                DgvGrupos.Rows.Clear()

                ConLibregco.Open()
                Dim SQLSimilares As New MySqlCommand("SELECT IDArticulo,Articulos.RutaFoto,Descripcion,Referencia,BigColorPath FROM libregco.articulos inner join libregco.color on articulos.idcolor=color.idcolor where Articulos.IDColectivo='" + txtIDGrupo.Tag.ToString + "'", ConLibregco)
                Dim LectorSimilares As MySqlDataReader = SQLSimilares.ExecuteReader

                While LectorSimilares.Read


                    If System.IO.File.Exists(LectorSimilares.GetValue(1)) = True Then
                        wFilePath = New FileStream(LectorSimilares.GetValue(1), FileMode.Open, FileAccess.Read)
                        RutaImage = ResizeImage(System.Drawing.Image.FromStream(wFilePath), 60)
                        wFilePath.Close()
                    Else
                        RutaImage = My.Resources.No_Image
                    End If

                    If System.IO.File.Exists(LectorSimilares.GetValue(4)) = True Then
                        wFileColor = New FileStream(LectorSimilares.GetValue(4), FileMode.Open, FileAccess.Read)
                        RutaColor = System.Drawing.Image.FromStream(wFileColor)
                        wFileColor.Close()
                    Else
                        RutaColor = Nothing
                    End If


                    DgvGrupos.Rows.Add(LectorSimilares.GetValue(0), RutaImage, LectorSimilares.GetValue(2), LectorSimilares.GetValue(3), RutaColor)


                End While

                LectorSimilares.Close()
                ConLibregco.Close()

                DgvGrupos.ClearSelection()

                If DgvGrupos.Rows.Count > 0 Then
                    Label52.Visible = True
                Else
                    Label52.Visible = False
                End If
            End If
        End If


    End Sub
    Sub RefrescarTablaSimilares()
        Try

            DgvSimilares.Rows.Clear()
            ConLibregco.Open()

            If TypeConnection.Text = 1 Then
                Dim SQLSimilares As New MySqlCommand("SELECT Articulos.RutaFoto,precioarticulo.IDArticulo,Descripcion,Medida.Medida,PrecioCredito,PrecioContado,Precio3,Precio4,Costo,CostoFinal,Articulos.Referencia FROM libregco.precioarticulo INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Articulos.IDSubCategoria='" + txtIDSubCategoria.Text + "' ORDER BY Articulos.Descripcion ASC LIMIT 50", ConLibregco)
                Dim LectorSimilares As MySqlDataReader = SQLSimilares.ExecuteReader

                While LectorSimilares.Read

                    Dim ExistFile As Boolean = System.IO.File.Exists(LectorSimilares.GetValue(0))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(LectorSimilares.GetValue(0), FileMode.Open, FileAccess.Read)
                        DgvSimilares.Rows.Add(ResizeImage(System.Drawing.Image.FromStream(wFile), 120), LectorSimilares.GetValue(1), LectorSimilares.GetValue(2), LectorSimilares.GetValue(10), LectorSimilares.GetValue(3), CDbl(LectorSimilares.GetValue(4)).ToString("C"), CDbl(LectorSimilares.GetValue(5)).ToString("C"), CDbl(LectorSimilares.GetValue(6)).ToString("C"), CDbl(LectorSimilares.GetValue(7)).ToString("C"), CDbl(LectorSimilares.GetValue(8)).ToString("C"), CDbl(LectorSimilares.GetValue(9)).ToString("C"))
                        wFile.Close()
                    Else
                        DgvSimilares.Rows.Add(ResizeImage(My.Resources.No_Image, 60), LectorSimilares.GetValue(1), LectorSimilares.GetValue(2), LectorSimilares.GetValue(10), LectorSimilares.GetValue(3), CDbl(LectorSimilares.GetValue(4)).ToString("C"), CDbl(LectorSimilares.GetValue(5)).ToString("C"), CDbl(LectorSimilares.GetValue(6)).ToString("C"), CDbl(LectorSimilares.GetValue(7)).ToString("C"), CDbl(LectorSimilares.GetValue(8)).ToString("C"), CDbl(LectorSimilares.GetValue(9)).ToString("C"))
                    End If

                End While

                LectorSimilares.Close()

            Else

                Dim SQLSimilares As New MySqlCommand("SELECT Articulos.RutaFoto,precioarticulo.IDArticulo,Descripcion,Medida.Medida,PrecioCredito,PrecioContado,Precio3,Precio4,Costo,CostoFinal,Articulos.Referencia FROM libregco.precioarticulo INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Articulos.IDSubCategoria='" + txtIDSubCategoria.Text + "' ORDER BY Articulos.Descripcion ASC LIMIT 50", ConLibregco)
                Dim LectorSimilares As MySqlDataReader = SQLSimilares.ExecuteReader

                While LectorSimilares.Read
                    DgvSimilares.Rows.Add(Nothing, LectorSimilares.GetValue(1), LectorSimilares.GetValue(2), LectorSimilares.GetValue(10), LectorSimilares.GetValue(3), CDbl(LectorSimilares.GetValue(4)).ToString("C"), CDbl(LectorSimilares.GetValue(5)).ToString("C"), CDbl(LectorSimilares.GetValue(6)).ToString("C"), CDbl(LectorSimilares.GetValue(7)).ToString("C"), CDbl(LectorSimilares.GetValue(8)).ToString("C"), CDbl(LectorSimilares.GetValue(9)).ToString("C"))
                End While

                LectorSimilares.Close()

            End If
            ConLibregco.Close()

            For Each row As DataGridViewRow In DgvSimilares.Rows
                If row.Cells(1).Value = txtIDProducto.Text Then
                    DgvSimilares.Rows(row.Index).DefaultCellStyle.BackColor = Color.Yellow
                    DgvSimilares.Rows(row.Index).DefaultCellStyle.ForeColor = Color.Blue
                End If
            Next

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
    Private Sub InsertStock()
        If txtStockMin.Text = "" And txtStockMax.Text = "" Then
            txtStockMin.Text = 0
            txtStockMax.Text = 1
            txtStockActual.Text = 0
        End If
    End Sub

    Private Sub SetPricesAutorization()
        If Not Precios.Contains("A") Then
            chkvisualprecioa.Enabled = False
            chkvisualprecioa.Checked = False
        End If

        If Not Precios.Contains("B") Then
            chkvisualpreciob.Enabled = False
            chkvisualpreciob.Checked = False
        End If

        If Not Precios.Contains("C") Then
            chkvisualprecioc.Enabled = False
            chkvisualprecioc.Checked = False
        End If

        If Not Precios.Contains("D") Then
            chkvisualpreciod.Enabled = False
            chkvisualpreciod.Checked = False
        End If

    End Sub

    Private Sub ActualizarDatos()
        FillMedidas()
        FillPropiedades()
        CargarChecks()
        ResetPicFoto()
        InsertStock()
        QrCode.Visible = False
        QrCode.Text = ""
        TabControl3.SelectedIndex = 0
        txtIDGrupo.Text = "[ Disponible ]"
        txtGrupoNombre.Enabled = False
        chkVincularPrecio.Enabled = False
        btnGuardarGrupo.Enabled = False
        Label52.Visible = False
        Populate()
        ChangingfromTreeview = False
        ChangeAllNodes(False, TreeView1)
        cbxMoneda.EditValue = CInt(DTConfiguracion.Rows(209 - 1).Item("Value2Int"))
        dtpEstadisticaInicial.Value = DateSerial(Now.AddYears(-1).Year, Now.Month, 1)
        dtpEstadisticaFinal.Value = Now
        cbxMonedaComplementario.EditValue = CInt(DTConfiguracion.Rows(209 - 1).Item("Value2Int"))
        SplitContainer1.Panel1Collapsed = True
        SplitContainer3.Panel1Collapsed = True
        btNoUsedIDs.Size = New Size(101, 18)
        btNoUsedIDs.Location = New Point(546, 145)
        btNoUsedIDs.Tag = ""
        btNoUsedIDs.Text = ""
        PicFotoArticulo.BackColor = SystemColors.Control
        txtDescrip.Multiline = False
        txtDescrip.Height = 23
        chkCompras.Enabled = True
        chkAjustesEntrada.Enabled = True
        chkAjustesSalida.Enabled = True
        chkDevoluciones.Enabled = True
        chkEntradas.Enabled = True
        chkReparaciones.Enabled = True
        chkDevolucionesCompra.Enabled = True
        chkBloquearModificacion.Checked = False
        chkInvInicial.Enabled = True
        txtIDGrupo.Tag = 1
        Precios = GetRangePrices()
        SetPricesAutorization()
        TbcProductos.Location = New Point(5, 172)
        Me.Size = New Size(887, 789)
        txtDescrip.Focus()
    End Sub

    Private Sub btn_Suplidor_Click(sender As Object, e As EventArgs) Handles btn_Suplidor.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub btn_Departamento_Click(sender As Object, e As EventArgs) Handles btn_Departamento.Click
        frm_buscar_departamentos.ShowDialog(Me)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Itbis.Click
        frm_buscar_itbis.ShowDialog(Me)
    End Sub

    Sub CargarExistenciasTreeView()
        Try
            Dim Monto As Double = 0
            Dim MyNode() As TreeNode

            TreeViewExistencia.Nodes.Clear()

            'Primero cargo todos los sucursales
            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT Sucursal.IDSucursal,Sucursal,SUM(Existencia) as Existencia FROM Libregco.Existencia INNER JOIN" & SysName.Text & "Almacen ON Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo='" + txtIDProducto.Text + "' AND Sucursal.Nulo=0 GROUP BY Sucursal.IDSucursal", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Sucursal")
            ConMixta.Close()

            Dim TablaSucursales As DataTable = Ds.Tables("Sucursal")
            Dim IDSucursal, IDAlmacen, Medida As New Label

            For Each FilaSucursal As DataRow In TablaSucursales.Rows
                IDSucursal.Text = FilaSucursal.Item("IDSucursal")
                If CDbl(FilaSucursal.Item("Existencia")) = 0 Then
                    Medida.Text = ": [No hay unidades en stock]"
                ElseIf CDbl(FilaSucursal.Item("Existencia")) = 1 Then
                    Medida.Text = ": Sólo " & FilaSucursal.Item("Existencia") & " unidad encontrada."
                Else
                    Medida.Text = ": " & FilaSucursal.Item("Existencia") & " unidades encontradas."
                End If

                TreeViewExistencia.Nodes.Add(FilaSucursal.Item("IDSucursal") & FilaSucursal.Item("Sucursal"), "Sucursal: " & FilaSucursal.Item("Sucursal") & Medida.Text)

                Ds1.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT Almacen.IDAlmacen,Almacen.Almacen,SUM(Existencia) as Existencia FROM Libregco.Existencia INNER JOIN" & SysName.Text & " Almacen ON Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & " Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo WHERE Articulos.IDArticulo='" + txtIDProducto.Text + "' AND Sucursal.IDSucursal='" + IDSucursal.Text + "' AND Almacen.Desactivar=0 GROUP BY Almacen.IDAlmacen", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "Almacenes")
                ConMixta.Close()

                Dim TablaAlmacenes As DataTable = Ds1.Tables("Almacenes")

                For Each FilaAlmacen As DataRow In TablaAlmacenes.Rows
                    IDAlmacen.Text = FilaAlmacen.Item("IDAlmacen")
                    If CDbl(FilaAlmacen.Item("Existencia")) = 0 Then
                        Medida.Text = ": [No hay unidades]"
                    ElseIf CDbl(FilaAlmacen.Item("Existencia")) = 1 Then
                        Medida.Text = ": " & FilaAlmacen.Item("Existencia") & " unidad"
                    Else
                        Medida.Text = ": " & FilaAlmacen.Item("Existencia") & " unidades"
                    End If

                    MyNode = TreeViewExistencia.Nodes.Find(FilaSucursal.Item("IDSucursal") & FilaSucursal.Item("Sucursal"), True)
                    MyNode(0).Nodes.Add(FilaAlmacen.Item("IDAlmacen") & FilaAlmacen.Item("Almacen"), "[" & FilaAlmacen.Item("IDAlmacen") & "] " & FilaAlmacen.Item("Almacen") & Medida.Text)

                    Ds2.Clear()
                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT Existencia.IDAlmacen,Medida.IDMedida,Medida.Medida,Existencia FROM Libregco.existencia INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where IDArticulo='" + txtIDProducto.Text + "' and IDAlmacen='" + IDAlmacen.Text + "' and PrecioArticulo.Nulo=0", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds2, "Medidas")
                    ConMixta.Close()

                    Dim TablaMedidas As DataTable = Ds2.Tables("Medidas")

                    For Each FilaMedida As DataRow In TablaMedidas.Rows
                        MyNode = TreeViewExistencia.Nodes.Find(FilaAlmacen.Item("IDAlmacen") & FilaAlmacen.Item("Almacen"), True)
                        MyNode(0).Nodes.Add(FilaMedida.Item("IDMedida") & FilaMedida.Item("Medida"), FilaMedida.Item("Existencia") & " " & (FilaMedida.Item("Medida").ToString.ToLower))
                    Next
                Next
            Next

            TreeViewExistencia.ExpandAll()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub chk_ConSerial_CheckedChanged(sender As Object, e As EventArgs) Handles chk_ConSerial.CheckedChanged
        If chk_ConSerial.Checked = True Then
            chk_ConSerial.Tag = 1
        Else
            chk_ConSerial.Tag = 0
        End If
    End Sub

    Private Sub chkPromocion_CheckedChanged(sender As Object, e As EventArgs) Handles chkPromocion.CheckedChanged
        If chkPromocion.Checked = True Then
            chkPromocion.Tag = 1
        Else
            chkPromocion.Tag = 0

        End If
    End Sub

    Private Sub chkDevolucion_CheckedChanged(sender As Object, e As EventArgs) Handles chkDevolucion.CheckedChanged
        If chkDevolucion.Checked = True Then
            chkDevolucion.Tag = 1
        Else
            chkDevolucion.Tag = 0
        End If
    End Sub

    Private Sub chkVenderCosto_CheckedChanged(sender As Object, e As EventArgs) Handles chkVenderCosto.CheckedChanged
        If chkVenderCosto.Checked = True Then
            chkVenderCosto.Tag = 1
        Else
            chkVenderCosto.Tag = 0
        End If
    End Sub

    Private Sub chkDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesactivar.CheckedChanged
        If chkDesactivar.Checked = True Then
            chkDesactivar.Tag = 1
            InhabilitarArticulo()
        Else
            chkDesactivar.Tag = 0
            HabilitarArticulo()
        End If
    End Sub

    Private Sub CreateFolder()
        Try
            Dim Exists As Boolean
            Exists = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Artículos")
            If Exists = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Artículos")
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub MoverFichero()
        'Try
        If DgvImagenes.Rows.Count > 0 Then
            If TypeConnection.Text = 1 Then
                Dim Exists As Boolean
                Dim RutaDestino As String

                CreateFolder()   'Verificamos si existe el folder del suplidor

                'Insertar imagenes 
                Dim UltNum As Double
                Dim IDImageDgv As New Label

                For Each row As DataGridViewRow In DgvImagenes.Rows
                    IDImageDgv.Text = row.Cells(0).Value

                    If IDImageDgv.Text = "" Then
                        Exists = File.Exists(row.Cells(4).Value)

                        If Exists = True Then
                            ConLibregco.Open()
                            cmd = New MySqlCommand("SELECT AUTO_INCREMENT AS id FROM information_schema.Tables WHERE TABLE_SCHEMA='Libregco' AND table_name='Articulos_fotos'", ConLibregco)
                            UltNum = Convert.ToDouble(cmd.ExecuteScalar())
                            ConLibregco.Close()

                            RutaDestino = "\\" & PathServidor.Text & "\Libregco\Files\Artículos\" & "ART-" & txtIDProducto.Text & " R#" & UltNum & ".png"

                            If RutaDestino <> row.Cells(4).Value Then
                                My.Computer.FileSystem.MoveFile(row.Cells(4).Value, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                                row.Cells(4).Value = RutaDestino

                                sqlQ = "INSERT INTO Libregco.Articulos_fotos (IDArticulo,Descripcion,Orden,RutaImagen) VALUES ('" + txtIDProducto.Text + "','" + row.Cells(1).Value.ToString + "','" + row.Cells(2).Value.ToString + "','" + Replace(RutaDestino, "\", "\\") + "')"
                                ConLibregco.Open()
                                cmd = New MySqlCommand(sqlQ, ConLibregco)
                                cmd.ExecuteNonQuery()
                                ConLibregco.Close()

                                row.Cells(0).Value = UltNum

                            End If
                        End If

                    Else

                        sqlQ = "UPDATE Articulos_fotos SET Descripcion='" + row.Cells(1).Value.ToString + "',Orden='" + row.Cells(2).Value.ToString + "' WHERE IDImagen= (" + IDImageDgv.Text + ")"
                        ConLibregco.Open()
                        cmd = New MySqlCommand(sqlQ, ConLibregco)
                        cmd.ExecuteNonQuery()
                        ConLibregco.Close()
                    End If
                Next

            End If
        End If

        If DgvEspecificaciones.Rows.Count > 0 Then
            'Insertar especificaciones
            Dim IDEspecificacion, Especificacion As New Label

            For Each row As DataGridViewRow In DgvEspecificaciones.Rows
                IDEspecificacion.Text = row.Cells(0).Value
                Especificacion.Text = row.Cells(1).Value

                If IDEspecificacion.Text = "" Then
                    sqlQ = "INSERT INTO Libregco.Articulos_especificaciones (IDArticulo,Especificacion) VALUES ('" + txtIDProducto.Text + "','" + Especificacion.Text + "')"
                    ConLibregco.Open()
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()
                    ConLibregco.Close()

                Else
                    sqlQ = "UPDATE Libregco.Articulos_especificaciones SET Especificacion='" + Especificacion.Text + "' WHERE IDEspecificacion= (" + IDEspecificacion.Text + ")"
                    ConLibregco.Open()
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()
                    ConLibregco.Close()
                End If

            Next

            RefrescarDgvEspecifaciones()
        End If

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Sub RefrescarDgvEspecifaciones()
        Try
            DgvEspecificaciones.Rows.Clear()
            ConLibregco.Open()
            Dim SQLEspecificacion As New MySqlCommand("SELECT IDEspecificacion,Especificacion FROM articulos_especificaciones where IDArticulo='" + txtIDProducto.Text + "'", ConLibregco)
            Dim LectorEspecificacion As MySqlDataReader = SQLEspecificacion.ExecuteReader

            While LectorEspecificacion.Read
                DgvEspecificaciones.Rows.Add(LectorEspecificacion.GetValue(0), LectorEspecificacion.GetValue(1))
            End While
            LectorEspecificacion.Close()
            ConLibregco.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub ProcesarExistencia()
        Dim IDAlmacen As New Label

        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen Where Desactivar=0", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Almacen")
        Con.Close()

        Dim TablaAlmacen As DataTable = Ds.Tables("Almacen")
        For Each FilaAlmacen As DataRow In TablaAlmacen.Rows

            IDAlmacen.Text = FilaAlmacen.Item("IDAlmacen")
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDExistencia FROM Libregco.Existencia INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios Where PrecioArticulo.IDArticulo='" + txtIDProducto.Text + "' and IDPrecioArticulo='" + lblIDPrecio.Text + "' and IDAlmacen='" + IDAlmacen.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Existencia")
            ConLibregco.Close()

            Dim TablaExistencia As DataTable = Ds.Tables("Existencia")
            If TablaExistencia.Rows.Count = 0 Then
                sqlQ = "INSERT INTO Libregco.Existencia (IDPrecioArticulo,IDAlmacen,Existencia) VALUES ('" + lblIDPrecio.Text + "','" + IDAlmacen.Text + "',0)"
                ConLibregco.Open()
                cmd = New MySqlCommand(sqlQ, ConLibregco)
                cmd.ExecuteNonQuery()
                ConLibregco.Close()
            End If
        Next

    End Sub

    Private Sub GuardarDatos()
        'Try
        ConMixta.Open()
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
            ConMixta.Close()

        'Catch ex As Exception
        '    Con.Close()
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub UltArticulo()
        If txtIDProducto.Text = "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDArticulo from Articulos where IDArticulo= (Select Max(IDArticulo) from Articulos)", ConLibregco)
            txtIDProducto.Text = Convert.ToDouble(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If
    End Sub

    Sub CargarChecks()
        chkDesactivar.Tag = 0
        chk_ConSerial.Tag = 0
        chkPromocion.Tag = 0
        chkDevolucion.Tag = 0
        chkVenderCosto.Tag = 0
        chkDescontinuar.Tag = 0
        chkBloqueoCredito.Tag = 0
        chkPreAlertar.Tag = 0
        ChkRevisado.Tag = 0
        chkNoPagoTarjeta.Tag = 0
        chkCobrarComision.Tag = 0
        chkPermitirModificarPrecio.Tag = 0
        txtPorcComision.Text = CDbl(0).ToString("P2")
        CbxOrden.SelectedIndex = 0
        CbxOrden.Tag = 0
    End Sub

    Private Sub LimpiarDatosProducto()
        txtDescrip.Clear()
        txtIDProducto.Clear()
        txtReferencia.Clear()
        txtIDSuplidor.Clear()
        txtSuplidor.Clear()
        txtIDDepartamento.Clear()
        txtDepartamento.Clear()
        txtIDTipoArticulo.Clear()
        txtTipoArticulo.Clear()
        txtIDItbis.Clear()
        txtItbis.Clear()
        txtIDCategoria.Clear()
        txtCategoria.Clear()
        txtSubCategoria.Clear()
        txtIDSubCategoria.Clear()
        txtIDMarca.Clear()
        txtMarca.Clear()
        txtTipoGarantia.Clear()
        txtIDGarantia.Clear()
        txtCodigoBarra.Clear()
        txtStockMin.Clear()
        txtStockMax.Clear()
        txtStockActual.Clear()
        txtEspecificacion.Clear()
        RutaDocumento.Text = ""
        txtIDParentesco.Clear()
        txtParentesco.Clear()
        txtGrupoNombre.Clear()
        chkVincularPrecio.Checked = False
        lblColorName.Text = "No específicado"
        PColor.BackColor = SystemColors.Control
        RemoverColores()
        chkServicioPersonalizable.Checked = False
        chkServicioPersonalizable.Visible = False
        chkDesactivar.Checked = False
        chk_ConSerial.Checked = False
        chkPromocion.Checked = False
        chkDevolucion.Checked = False
        chkVenderCosto.Checked = False
        chkDescontinuar.Checked = False
        chkBloqueoCredito.Checked = False
        chkPreAlertar.Checked = False
        ChkRevisado.Checked = False
        chkNoPagoTarjeta.Checked = False
        chkCobrarComision.Checked = False
        chkPermitirModificarPrecio.Checked = False
        chkvisualcosto.Checked = True
        chkvisualprecioa.Enabled = True
        chkvisualprecioa.Checked = True
        chkvisualpreciob.Enabled = True
        chkvisualpreciob.Checked = True
        chkvisualprecioc.Enabled = True
        chkvisualprecioc.Checked = True
        chkvisualpreciod.Enabled = True
        chkvisualpreciod.Checked = True
        ResetPicFoto()
        LimpiarLabels()
        LimpiarPrecios()
        RefrescarTablaPrecios()
        RefrescarTablaImagenes()
        RefrescarDgvEspecifaciones()
        TablaDatosHistorial.Rows.Clear()
        TablaQuestions.Rows.Clear()
        TablaCambiosPrecios.Rows.Clear()
        DgvSimilares.Rows.Clear()
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        DgvHijos.Rows.Clear()
        TreeViewExistencia.Nodes.Clear()
        DgvGarantiaProductos.Rows.Clear()
        DgvGrupos.Rows.Clear()
        DgvSubCategoria.Rows.Clear()
        DgvCategoria.Rows.Clear()
        txtGarantiaCategoria.Clear()
        txtGarantiaProducto.Clear()
        txtGarantiaSubCategoria.Clear()
        txtGarantiaCategoria.Tag = ""
        txtGarantiaProducto.Tag = ""
        txtGarantiaSubCategoria.Tag = ""
        lblSubCategoria.Text = ""
        lblCategoria.Text = ""
        lblIDArticuloComplementario.Text = ""
        lblArticuloComplementario.Text = ""
        lblReferenciaComplementario.Text = ""
        txtCantidadIncluirComplementario.Value = 1
        SplitContainer2.SplitterDistance = 42
        MinPrecioA.Text = CDbl(0).ToString("C")
        MinPrecioB.Text = CDbl(0).ToString("C")
        txtCantParaActivar.Value = 1
        cbxMedidaIncluir.DataSource = Nothing
        cbxMedidaIncluir.Items.Clear()
        chkIncluirPrecioComplementario.Checked = False
        cbxNivelPrecioComplementario.Text = "A"
        txtPrecioComplementario.Clear()
        chkLimitarVidaComplementario.Checked = False
        dtpFechaVidaComplementario.Value = Today
        chkNuloComplementario.Checked = False
        TbcProductos.SelectedIndex = 0
        TabControl3.SelectedIndex = 0
        TabControl4.SelectedIndex = 0
        XtraTabControl1.SelectedTabPageIndex = 0
        TabControl2.SelectedIndex = 0
        TabControl1.SelectedIndex = 0
        IDMarcaTMP = ""
        MarcaTMP = ""
        TKPropiedades.EditValue = ""
        TkPropiedadesMain.EditValue = ""
        txtDescrip.Focus()
    End Sub



    Sub ResetPicFoto()
        RutaDocumento.Text = ""
        PicFotoArticulo.Width = 312
        PicFotoArticulo.Height = 316
        PicFotoArticulo.Image = My.Resources.No_Image
    End Sub

    Private Sub LimpiarLabels()
        RutaDocumento.Text = ""
        LabelStatus.Text = "Listo"
    End Sub

    Private Sub HabilitarArticulo()
        TbcProductos.Enabled = True
    End Sub

    Private Sub InhabilitarArticulo()
        TbcProductos.Enabled = False
    End Sub

    Sub FillMedidas()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Abreviatura FROM Medida Where Desactivar=0 ORDER BY Medida ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Medida")
        cbxMedida.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Medida")
        For Each Fila As DataRow In Tabla.Rows
            cbxMedida.Items.Add(Fila.Item("Abreviatura"))
        Next

    End Sub

    Sub LimpiarPrecios()
        txtContenido.Enabled = True
        lblIDPrecio.Text = ""
        cbxMedida.Tag = ""
        cbxMedida.Items.Clear()
        txtContenido.EditValue = 1
        txtCosto.Value = 0
        txtCostoFinal.Value = 0
        txtDescMax.EditValue = 0
        txtPrecioB.Value = 0
        txtPrecioA.Value = 0
        txtPrecioC.Value = 0
        txtPrecioD.Value = 0
        txtPrecioBlackFriday.Clear()
        TextBox1.Clear()
        cbxMoneda.EditValue = CInt(DTConfiguracion.Rows(209 - 1).Item("Value2Int"))
        FillMedidas()
        SplitContainer3.Panel1Collapsed = True
        SplitContainer2.SplitterDistance = 42
    End Sub

    Private Sub cbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMedida.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDMedida FROM Medida WHERE Abreviatura= '" + cbxMedida.SelectedItem + "'", ConLibregco)
        cbxMedida.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        Dim PriceFounded As Boolean = False

        For Each rw As DataGridViewRow In DgvPrecios.Rows
            If rw.Cells(1).Value = cbxMedida.Tag.ToString Then

                If CInt(DTConfiguracion.Rows(115 - 1).Item("Value2Int")) = 1 Then
                    txtContenido.Enabled = True
                Else
                    txtContenido.Enabled = False
                End If

                lblIDPrecio.Text = DgvPrecios.CurrentRow.Cells(0).Value
                cbxMedida.Tag = DgvPrecios.CurrentRow.Cells(1).Value
                cbxMedida.Text = DgvPrecios.CurrentRow.Cells(2).Value
                txtContenido.EditValue = DgvPrecios.CurrentRow.Cells(3).Value
                txtCosto.Value = CDbl(DgvPrecios.CurrentRow.Cells(4).Value).ToString("C")
                txtCostoFinal.Value = CDbl(DgvPrecios.CurrentRow.Cells(5).Value).ToString("C")
                txtDescMax.EditValue = DgvPrecios.CurrentRow.Cells(6).Value
                txtPrecioA.Value = CDbl(DgvPrecios.CurrentRow.Cells(7).Value).ToString("C")
                txtPrecioB.Value = CDbl(DgvPrecios.CurrentRow.Cells(8).Value).ToString("C")
                txtPrecioC.Value = CDbl(DgvPrecios.CurrentRow.Cells(9).Value).ToString("C")
                txtPrecioD.Value = CDbl(DgvPrecios.CurrentRow.Cells(10).Value).ToString("C")
                txtPrecioBlackFriday.Text = CDbl(DgvPrecios.CurrentRow.Cells(13).Value).ToString("C")
                lblAnularPrecio.Text = DgvPrecios.CurrentRow.Cells(11).Value
                lblTipoMedida.Text = DgvPrecios.CurrentRow.Cells(14).Value
                Piezaje.Text = DgvPrecios.CurrentRow.Cells(15).Value
                PriceFounded = True
                Exit For
            End If
        Next

        If lblIDPrecio.Text = "" Then
            If PriceFounded = False Then
                txtContenido.Enabled = True
                lblIDPrecio.Text = ""
                txtContenido.EditValue = 1
                txtCosto.Value = 0
                txtCostoFinal.Value = 0
                txtDescMax.EditValue = 0
                txtPrecioB.Value = 0
                txtPrecioA.Value = 0
                txtPrecioC.Value = 0
                txtPrecioD.Value = 0
                txtPrecioBlackFriday.Clear()
                lblTipoMedida.Text = 1
                Piezaje.Text = 0
                txtContenido.Focus()
            End If

        End If

    End Sub

    Private Sub VerificarDuplicados()
        Dim x As Integer = 0
        Dim Counter As Integer = DgvPrecios.Rows.Count

Inicio:
        If x = DgvPrecios.Rows.Count Or DgvPrecios.Rows.Count = 0 Then
            lblCheckDuplicates.Text = 0
            Exit Sub
        End If

        If CInt(DgvPrecios.Rows(x).Cells(1).Value) = CInt(cbxMedida.Tag.ToString) Then
            MessageBox.Show("Este artículo ya se encuentra registrado y activo con la misma medida." & vbNewLine & "No es posible duplicar el precio para la misma medida del artículo.", "Producto ya introducido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            cbxMedida.Focus()
            lblCheckDuplicates.Text = 1
            Exit Sub
        Else
            x = x + 1
            GoTo Inicio
        End If

    End Sub

    Private Sub UltPrecio()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDPrecios from PrecioArticulo where IDPrecios= (Select Max(IDPrecios) from PrecioArticulo)", ConLibregco)
        lblIDPrecio.Text = Convert.ToDouble(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub txtStockMin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStockMin.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtStockMax_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStockMax.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub DgvPrecios_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvPrecios.CellMouseDoubleClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex <> 15 Then
                If CInt(DTConfiguracion.Rows(115 - 1).Item("Value2Int")) = 1 Then
                    txtContenido.Enabled = True
                Else
                    txtContenido.Enabled = False
                End If

                lblIDPrecio.Text = DgvPrecios.CurrentRow.Cells(0).Value
                cbxMedida.Tag = DgvPrecios.CurrentRow.Cells(1).Value
                cbxMedida.Text = DgvPrecios.CurrentRow.Cells(2).Value
                txtContenido.EditValue = DgvPrecios.CurrentRow.Cells(3).Value
                txtCosto.Value = CDbl(DgvPrecios.CurrentRow.Cells(4).Value).ToString("C")
                txtCostoFinal.Value = CDbl(DgvPrecios.CurrentRow.Cells(5).Value).ToString("C")
                txtDescMax.EditValue = DgvPrecios.CurrentRow.Cells(6).Value
                txtPrecioA.Value = CDbl(DgvPrecios.CurrentRow.Cells(7).Value).ToString("C")
                txtPrecioB.Value = CDbl(DgvPrecios.CurrentRow.Cells(8).Value).ToString("C")
                txtPrecioC.Value = CDbl(DgvPrecios.CurrentRow.Cells(9).Value).ToString("C")
                txtPrecioD.Value = CDbl(DgvPrecios.CurrentRow.Cells(10).Value).ToString("C")
                txtPrecioBlackFriday.Text = CDbl(DgvPrecios.CurrentRow.Cells(13).Value).ToString("C")
                lblAnularPrecio.Text = DgvPrecios.CurrentRow.Cells(11).Value
                lblTipoMedida.Text = DgvPrecios.CurrentRow.Cells(14).Value
                Piezaje.Text = DgvPrecios.CurrentRow.Cells(15).Value
                cbxMoneda.EditValue = CInt(DgvPrecios.CurrentRow.Cells(16).Value)
            Else
                If CDbl(DgvPrecios.CurrentRow.Cells("TipoMedida").Value) = 1 Then

                    Dim dstemp As New DataSet

                    Con.Open()
                    cmd = New MySqlCommand("SELECT IDPrecios,PrecioArticulo.IDMedida,Medida.Medida,Abreviatura,Contenido,Costo,CostoFinal,DescuentoMaximo,PrecioCredito,PrecioContado,Precio3,Precio4,Nulo,CostoClave,PrecioBlackFriday,TipoMedida,Piezaje,PrecioAMedida,PrecioBMedida,PrecioCMedida,PrecioDMedida,CostoMedida,MedidaDinamica FROM Libregco.precioarticulo INNER JOIN Libregco.medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrecioArticulo.IDPrecios='" + DgvPrecios.CurrentRow.Cells(0).Value.ToString + "'", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(dstemp, "Precios")
                    Con.Close()

                    Dim TablaMedida As DataTable = dstemp.Tables("Precios")

                    If TablaMedida.Rows.Count > 0 Then
                        frm_piezaje_precios.lblIDPrecio = TablaMedida.Rows(0).Item("IDPrecios")
                        frm_piezaje_precios.lblMedidaPadre.Text = TablaMedida.Rows(0).Item("Medida").ToString.ToUpper
                        frm_piezaje_precios.lblMedidaPadre.Tag = TablaMedida.Rows(0).Item("MedidaDinamica")
                        frm_piezaje_precios.lblDescripcion.Text = txtDescrip.Text.ToUpper
                        frm_piezaje_precios.GroupControl1.Text = "Escriba la cantidad de " & "<u><color=30,144,255><B>" & TablaMedida.Rows(0).Item("MedidaDinamica").ToString.ToUpper & "</B></color></u> que contiene la medida"
                        frm_piezaje_precios.txtPiezaje.EditValue = TablaMedida.Rows(0).Item("Piezaje")
                        frm_piezaje_precios.lblCosto.Text = "Costo: " & CDbl(TablaMedida.Rows(0).Item("CostoMedida")).ToString("C") & " por cada " & "<u><color=30,144,255><B>" & TablaMedida.Rows(0).Item("MedidaDinamica").ToString.ToUpper & "</B></color></u>" & " (" & frm_piezaje_precios.txtPiezaje.Text & " x " & CDbl(TablaMedida.Rows(0).Item("CostoMedida")).ToString("C") & ")"
                        frm_piezaje_precios.lblCosto.Tag = CDbl(TablaMedida.Rows(0).Item("CostoMedida"))
                        frm_piezaje_precios.lblPrecio.Text = "Precio:" & CDbl(TablaMedida.Rows(0).Item("PrecioAMedida")).ToString("C") & " por cada " & "<u><color=30,144,255><B>" & TablaMedida.Rows(0).Item("MedidaDinamica").ToString.ToUpper & "</B></color></u>" & " (" & frm_piezaje_precios.txtPiezaje.Text & " x " & CDbl(TablaMedida.Rows(0).Item("PrecioAMedida")).ToString("C") & ")"
                        frm_piezaje_precios.lblPrecio.Tag = CDbl(TablaMedida.Rows(0).Item("PrecioAMedida"))
                        frm_piezaje_precios.PA.Text = CDbl(TablaMedida.Rows(0).Item("PrecioAMedida")).ToString("C")
                        frm_piezaje_precios.PB.Text = CDbl(TablaMedida.Rows(0).Item("PrecioBMedida")).ToString("C")
                        frm_piezaje_precios.PC.Text = CDbl(TablaMedida.Rows(0).Item("PrecioCMedida")).ToString("C")
                        frm_piezaje_precios.PD.Text = CDbl(TablaMedida.Rows(0).Item("PrecioDMedida")).ToString("C")

                        frm_piezaje_precios.txtCosto.EditValue = RoundUp(CDbl(CDbl(frm_piezaje_precios.lblCosto.Tag) * CDbl(frm_piezaje_precios.txtPiezaje.EditValue)), Convert.ToInt16(frm_piezaje_precios.chkRedondear.Checked))
                        frm_piezaje_precios.txtPrecio.EditValue = RoundUp(CDbl(CDbl(frm_piezaje_precios.lblPrecio.Tag) * CDbl(frm_piezaje_precios.txtPiezaje.EditValue)), Convert.ToInt16(frm_piezaje_precios.chkRedondear.Checked))
                        frm_piezaje_precios.txtPrecioA.EditValue = RoundUp(CDbl(CDbl(frm_piezaje_precios.PA.Text) * CDbl(frm_piezaje_precios.txtPiezaje.EditValue)), Convert.ToInt16(frm_piezaje_precios.chkRedondear.Checked))
                        frm_piezaje_precios.txtPrecioB.EditValue = RoundUp(CDbl(CDbl(frm_piezaje_precios.PB.Text) * CDbl(frm_piezaje_precios.txtPiezaje.EditValue)), Convert.ToInt16(frm_piezaje_precios.chkRedondear.Checked))
                        frm_piezaje_precios.txtPrecioC.EditValue = RoundUp(CDbl(CDbl(frm_piezaje_precios.PC.Text) * CDbl(frm_piezaje_precios.txtPiezaje.EditValue)), Convert.ToInt16(frm_piezaje_precios.chkRedondear.Checked))
                        frm_piezaje_precios.txtPrecioD.EditValue = RoundUp(CDbl(CDbl(frm_piezaje_precios.PD.Text) * CDbl(frm_piezaje_precios.txtPiezaje.EditValue)), Convert.ToInt16(frm_piezaje_precios.chkRedondear.Checked))

                        frm_piezaje_precios.ShowDialog(Me)
                    End If

                End If
            End If

        End If
    End Sub

    Private Sub txtStockMax_Leave(sender As Object, e As EventArgs) Handles txtStockMax.Leave
        If CInt(txtStockMax.Text) < CInt(txtStockMin.Text) Then
            MessageBox.Show("El existencia máxima debe ser mayor a la existencia mínima", "Error en digitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtStockMax.Focus()
        End If
    End Sub

    Private Sub txtStockMin_Enter(sender As Object, e As EventArgs) Handles txtStockMin.Enter
        VerificarStatus()
    End Sub

    Private Sub txtStockMin_Leave(sender As Object, e As EventArgs) Handles txtStockMin.Leave
        VerificarStatus()
    End Sub

    Private Sub VerificarStatus()
        If txtStockMin.Focused = True Then
            If txtStockMin.Text <= 1 Then
                LabelStatus.Text = "Recomendamos que el stock mínimo de inventario sea mayor a 1 para un mejor control del inventario."
            Else
                LabelStatus.Text = "Listo"
            End If
        End If
    End Sub
    Private Sub txtContenido_Leave(sender As Object, e As EventArgs) Handles txtContenido.Leave
        If IsNumeric(txtContenido.EditValue) Then
            If txtContenido.EditValue = 0 Then
                txtContenido.EditValue = 1
            End If
        Else
            txtContenido.EditValue = 1
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDProducto.Text = "" Then
            If txtDescrip.Text <> "" Or txtReferencia.Text <> "" Or txtIDSuplidor.Text <> "" Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario de mantenimiento de artículos?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatosProducto()
                    ActualizarDatos()
                End If
            Else
                LimpiarDatosProducto()
                ActualizarDatos()
            End If
        Else
            LimpiarDatosProducto()
            ActualizarDatos()
        End If
    End Sub

    Sub RefrescarTablaImagenes()
        Try
            If TypeConnection.Text = 1 Then

                Dim Img As Image

                DgvImagenes.Rows.Clear()

                ConLibregco.Open()
                Dim SQLPrecios As New MySqlCommand("SELECT IDImagen,Descripcion,Orden,RutaImagen FROM articulos_fotos where IDArticulo='" + txtIDProducto.Text + "' Order by Orden asc", ConLibregco)
                Dim LectorImagen As MySqlDataReader = SQLPrecios.ExecuteReader

                While LectorImagen.Read
                    Dim ExistFile As Boolean = System.IO.File.Exists(LectorImagen.GetValue(3))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(LectorImagen.GetValue(3), FileMode.Open, FileAccess.Read)
                        DgvImagenes.Rows.Add(LectorImagen.GetValue(0), LectorImagen.GetValue(1), LectorImagen.GetValue(2), ResizeImage(System.Drawing.Image.FromStream(wFile), 120), LectorImagen.GetValue(3))
                        wFile.Close()
                    End If

                End While

                LectorImagen.Close()
                ConLibregco.Close()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
    Public Function SetQRImage(ByVal IDArticulo As String)
        Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Artículos\QRCodes")
        If Exists = False Then
            System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Artículos\QRCodes")
        End If

        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Artículos\QRCodes\" & "QR" & IDArticulo & ".png"

        If System.IO.Directory.Exists(RutaDestino) = False Then
            Dim img As Image = DirectCast(QrCode.Image.Clone, Image)
            img.Save(RutaDestino)

            sqlQ = "UPDATE Libregco.Articulos SET QRCode='" + Replace(RutaDestino, "\", "\\") + "' WHERE IDArticulo= (" + txtIDProducto.Text + ")"
            GuardarDatos()

            img.Dispose()
        End If

    End Function

    Private Sub GuardarHijos()
        Try
            ConLibregco.Open()

            For Each Rw As DataGridViewRow In DgvHijos.Rows
                If Rw.Cells(0).Value.ToString = "" Then
                    sqlQ = "INSERT INTO Libregco.Articulos_hijos (IDPrecioPadre,CantidadParaOferta,IDPrecioHijo,CantidadenOferta,ValorIncluidoPrecio,Nivel,Precio,LimitarHastaFecha,HastaFecha,Nulo) VALUES ('" + Rw.Cells(1).Value.ToString + "','" + Rw.Cells(2).Value.ToString + "','" + Rw.Cells(8).Value.ToString + "','" + Rw.Cells(7).Value.ToString + "','" + ConvertBooltoInt(CBool(Rw.Cells(12).Value)).ToString + "','" + Rw.Cells(13).Value.ToString + "','" + Rw.Cells(14).Value.ToString + "','" + ConvertBooltoInt(CBool(Rw.Cells(10).Value)).ToString + "','" + CDate(Rw.Cells(11).Value).ToString("yyyy-MM-dd") + "','" + ConvertBooltoInt(CBool(Rw.Cells(15).Value)).ToString + "')"
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()

                    cmd = New MySqlCommand("Select idProductosHijos from Articulos_hijos where idProductosHijos= (Select Max(idProductosHijos) from Articulos_hijos)", ConLibregco)
                    Rw.Cells(0).Value = Convert.ToDouble(cmd.ExecuteScalar())
                Else

                    sqlQ = "UPDATE Libregco.Articulos_hijos SET IDPrecioPadre='" + Rw.Cells(1).Value.ToString + "',CantidadParaOferta='" + Rw.Cells(2).Value.ToString + "',IDPrecioHijo='" + Rw.Cells(8).Value.ToString + "',CantidadenOferta='" + Rw.Cells(7).Value.ToString + "',ValorIncluidoPrecio='" + ConvertBooltoInt(CBool(Rw.Cells(12).Value)).ToString + "',Nivel='" + Rw.Cells(13).Value.ToString + "',Precio='" + CDbl(Rw.Cells(14).Value).ToString + "',LimitarHastaFecha='" + ConvertBooltoInt(CBool(Rw.Cells(10).Value)).ToString + "',HastaFecha='" + CDate(Rw.Cells(11).Value).ToString("yyyy-MM-dd") + "',Nulo='" + ConvertBooltoInt(CBool(Rw.Cells(15).Value)).ToString + "' WHERE IDProductosHijos= (" + Rw.Cells(0).Value.ToString + ")"
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()

                End If
            Next
            ConLibregco.Close()

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If Permisos(0) = 0 Then
            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para acceder a los registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ControlParent = 0
        frm_buscar_mant_articulos.lblStatus.Text = "Listo"
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtDescrip.Text = "" Then
            MessageBox.Show("Escriba la descripción o nombre del artículo a procesar.", "Descripción del artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescrip.Focus()
            Exit Sub
        ElseIf txtDescrip.Text.Trim.Length < ReturnMininCharacterLenght Then
            MessageBox.Show("La descripción del artículo no es lo suficientemente larga para cumplir con los requisitos de su procesamiento. Por favor sea más específico.", "Especificar Descripción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescrip.Focus()
            Exit Sub
        ElseIf txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor a quien le corresponderá por predeterminado el artículo: " & vbNewLine & vbNewLine & txtDescrip.Text, "Seleccione el Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_Suplidor.PerformClick()
            Exit Sub
        ElseIf txtIDTipoArticulo.Text = "" Then
            MessageBox.Show("Seleccione el tipo de artículo a procesar.", "Seleccionar Tipo de Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarTipoArticulo.PerformClick()
            Exit Sub
        ElseIf txtIDDepartamento.Text = "" Then
            MessageBox.Show("Seleccione el departamento correspodiente al artículo: " & vbNewLine & vbNewLine & txtDescrip.Text, "Seleccione el departamento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_Departamento.PerformClick()
            Exit Sub
        ElseIf txtIDCategoria.Text = "" Then
            MessageBox.Show("Seleccione la categoría correspodiente al artículo: " & txtDescrip.Text & ", perteneciente al departamento: " & txtDepartamento.Text & ".", "Seleccione el departamento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCategoria.PerformClick()
            Exit Sub
        ElseIf txtIDSubCategoria.Text = "" Then
            MessageBox.Show("Seleccione la subcategoría correspodiente al artículo: " & txtDescrip.Text & ", perteneciente al departamento: " & txtDepartamento.Text & ", y a la categoría: " & txtCategoria.Text & ".", "Seleccione el departamento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSubCategoria.PerformClick()
            Exit Sub
        ElseIf txtIDItbis.Text = "" Then
            MessageBox.Show("Seleccione el tipo de impuesto a la transferencia de bienes industrializados y de servicios (ITBIS) correspodiente al artículo: " & txtDescrip.Text & ".", "Seleccione Tipo de ITBIS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_Itbis.PerformClick()
            Exit Sub
        ElseIf txtIDMarca.Text = "" Then
            MessageBox.Show("Seleccione la marca correspondiente al artículo: " & vbNewLine & vbNewLine & txtDescrip.Text, "Seleccione la marca", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarMarca.PerformClick()
            Exit Sub
        ElseIf txtIDGarantia.Text = "" Then
            MessageBox.Show("Seleccione la garantía correspondiente al artículo: " & vbNewLine & vbNewLine & txtDescrip.Text, "Seleccione la garantía", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarGarantia.PerformClick()
            Exit Sub
        ElseIf txtIDParentesco.Text = "" Then
            MessageBox.Show("Seleccione el tipo de parentesco  correspondiente al artículo: " & vbNewLine & vbNewLine & txtDescrip.Text, "Seleccione el tipo de parentesco", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnParentesco.PerformClick()
            Exit Sub
        End If

        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If chkDesactivar.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El artículo " & txtDescrip.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar Articulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkDesactivar.Checked = False
                sqlQ = "UPDATE Libregco.Articulos SET Descripcion='" + txtDescrip.Text + "',Referencia='" + txtReferencia.Text + "',IDSuplidor='" + txtIDSuplidor.Text + "',IDTipoProducto='" + txtIDTipoArticulo.Text + "',IDDepartamento='" + txtIDDepartamento.Text + "',IDItbis='" + txtIDItbis.Text + "',IDCategoria='" + txtIDCategoria.Text + "',IDSubCategoria='" + txtIDSubCategoria.Text + "',IDMarca='" + txtIDMarca.Text + "',IDGarantia='" + txtIDGarantia.Text + "',IDParentesco='" + txtIDParentesco.Text + "',IDColor='" + PColor.Tag.ToString + "',CodigoBarra='" + txtCodigoBarra.Text + "',Serial='" + chk_ConSerial.Tag.ToString + "',Promocion='" + chkPromocion.Tag.ToString + "',Devolucion='" + chkDevolucion.Tag.ToString + "',VenderCosto='" + chkVenderCosto.Tag.ToString + "',Descontinuar='" + chkDescontinuar.Tag.ToString + "',BloqueoCredito='" + chkBloqueoCredito.Tag.ToString + "',PreAlertar='" + chkPreAlertar.Tag.ToString + "',Revisado='" + ChkRevisado.Tag.ToString + "',ExistenciaMin='" + txtStockMin.Text + "',ExistenciaMax='" + txtStockMax.Text + "',Desactivar='" + chkDesactivar.Tag.ToString + "',NoPagoTarjeta='" + chkNoPagoTarjeta.Tag.ToString + "',CobrarComision='" + chkCobrarComision.Tag.ToString + "',PorcentajeComision='" + CDbl(Replace(txtPorcComision.Text, "%", "")).ToString + "',NoPermitirCambiarPrecio='" + chkPermitirModificarPrecio.Tag.ToString + "',OrdenPrecios='" + CbxOrden.Tag.ToString + "',IDColectivo='" + If(txtIDGrupo.Text = "[ Disponible ]", 1, txtIDGrupo.Text).ToString + "' WHERE IDArticulo= (" + txtIDProducto.Text + ")"
                GuardarDatos()
                GuardarHijos()
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))
            End If
        ElseIf txtIDProducto.Text = "" Then
            MessageBox.Show("No hay un registro de artículos abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            frm_buscar_mant_articulos.ShowDialog(Me)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea desactivar el registro del artículo " & txtDescrip.Text & " del sistema?", "Desactivar Artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkDesactivar.Checked = True
                sqlQ = "UPDATE Libregco.Articulos SET Descripcion='" + txtDescrip.Text + "',Referencia='" + txtReferencia.Text + "',IDSuplidor='" + txtIDSuplidor.Text + "',IDTipoProducto='" + txtIDTipoArticulo.Text + "',IDDepartamento='" + txtIDDepartamento.Text + "',IDItbis='" + txtIDItbis.Text + "',IDCategoria='" + txtIDCategoria.Text + "',IDSubCategoria='" + txtIDSubCategoria.Text + "',IDMarca='" + txtIDMarca.Text + "',IDGarantia='" + txtIDGarantia.Text + "',IDParentesco='" + txtIDParentesco.Text + "',IDColor='" + PColor.Tag.ToString + "',CodigoBarra='" + txtCodigoBarra.Text + "',Serial='" + chk_ConSerial.Tag.ToString + "',Promocion='" + chkPromocion.Tag.ToString + "',Devolucion='" + chkDevolucion.Tag.ToString + "',VenderCosto='" + chkVenderCosto.Tag.ToString + "',Descontinuar='" + chkDescontinuar.Tag.ToString + "',BloqueoCredito='" + chkBloqueoCredito.Tag.ToString + "',PreAlertar='" + chkPreAlertar.Tag.ToString + "',Revisado='" + ChkRevisado.Tag.ToString + "',ExistenciaMin='" + txtStockMin.Text + "',ExistenciaMax='" + txtStockMax.Text + "',Desactivar='" + chkDesactivar.Tag.ToString + "',NoPagoTarjeta='" + chkNoPagoTarjeta.Tag.ToString + "',CobrarComision='" + chkCobrarComision.Tag.ToString + "',PorcentajeComision='" + CDbl(Replace(txtPorcComision.Text, "%", "")).ToString + "',NoPermitirCambiarPrecio='" + chkPermitirModificarPrecio.Tag.ToString + "',OrdenPrecios='" + CbxOrden.Tag.ToString + "',IDColectivo='" + If(txtIDGrupo.Text = "[ Disponible ]", 1, txtIDGrupo.Text).ToString + "' WHERE IDArticulo= (" + txtIDProducto.Text + ")"
                GuardarDatos()
                GuardarHijos()
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))
            End If
        End If
    End Sub

    Private Sub btnMedidas_Click(sender As Object, e As EventArgs) Handles btnMedidas.Click
        frm_mant_medidas.ShowDialog(Me)
    End Sub

    Private Sub btnAnularPrecio_Click(sender As Object, e As EventArgs) Handles btnAnularPrecio.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If lblIDPrecio.Text <> "" Then

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Sum(Existencia) FROM existencia Where IDPrecioArticulo='" + lblIDPrecio.Text + "'", ConLibregco)
            Dim Existencia As Double = Convert.ToDouble(cmd.ExecuteScalar())
            ConLibregco.Close()

            If Existencia <> 0 Then
                MessageBox.Show("Para anular los precios de los artículos es necesario igualar su inventario a 0 (cero)." & vbNewLine & vbNewLine & "Realice los ajustes de necesarios equivalentes previamente para finalizar esta operación", "Se han encontrado existencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el registro de precio del artículo?" & vbNewLine & txtDescrip.Text & " [ " & txtIDProducto.Text & "]" & vbNewLine & vbNewLine & "Medida: [" & cbxMedida.Text & "]" & vbNewLine & "Contenido: " & txtContenido.Text & vbNewLine & "Costo de Compras: " & txtCosto.Text & vbNewLine & "Descuento Máximo: " & txtDescMax.Text & vbNewLine & "Precio Contado: " & txtPrecioB.Text & vbNewLine & "Precio Crédito: " & txtPrecioA.Text, "Anular Registro de Precio", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                lblAnularPrecio.Text = 1
                sqlQ = "UPDATE Libregco.PrecioArticulo SET IDMedida='" + cbxMedida.Tag.ToString + "',Contenido='" + txtContenido.EditValue.ToString + "',Costo='" + txtCosto.EditValue.ToString + "',CostoFinal='" + txtCostoFinal.EditValue.ToString + "',PrecioContado='" + txtPrecioB.EditValue.ToString + "',PrecioCredito='" + txtPrecioA.EditValue.ToString + "',Precio3='" + txtPrecioC.EditValue.ToString + "',Precio4='" + txtPrecioD.EditValue.ToString + "',DescuentoMaximo='" + txtDescMax.EditValue.ToString + "',Nulo='" + lblAnularPrecio.Text + "',CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(txtCosto.Text)).ToString + "' WHERE IDPrecios=(" + lblIDPrecio.Text + ")"
                ConLibregco.Open()
                cmd = New MySqlCommand(sqlQ, ConLibregco)
                cmd.ExecuteNonQuery()
                ConLibregco.Close()
                MessageBox.Show("El precio de artículo ha sido anulado satisfactoriamenete.", "Anulación Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Else
            lblAnularPrecio.Text = 0
        End If
    End Sub

    Private Sub btnElegir_Click(sender As Object, e As EventArgs) Handles btnElegir.Click
        Try
            txtContenido.Enabled = False
            lblIDPrecio.Text = DgvPrecios.CurrentRow.Cells(0).Value
            cbxMedida.Tag = DgvPrecios.CurrentRow.Cells(1).Value
            cbxMedida.Text = DgvPrecios.CurrentRow.Cells(2).Value
            txtContenido.Text = DgvPrecios.CurrentRow.Cells(3).Value
            txtCosto.Text = CDbl(DgvPrecios.CurrentRow.Cells(4).Value).ToString("C")
            txtDescMax.Text = CDbl(DgvPrecios.CurrentRow.Cells(5).Value).ToString("P2")
            txtPrecioB.Text = CDbl(DgvPrecios.CurrentRow.Cells(6).Value).ToString("C")
            txtPrecioA.Text = CDbl(DgvPrecios.CurrentRow.Cells(7).Value).ToString("C")
            lblAnularPrecio.Text = DgvPrecios.CurrentRow.Cells(8).Value
            txtPrecioBlackFriday.Text = CDbl(DgvPrecios.CurrentRow.Cells(13).Value).ToString("C")
            cbxMoneda.EditValue = CInt(DgvPrecios.CurrentRow.Cells(16).Value)

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnLimpiarPrecio_Click(sender As Object, e As EventArgs) Handles btnLimpiarPrecio.Click
        If cbxMedida.Text <> "" Or txtContenido.Text <> "" Then
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea limpiar el registro de precio?", "Limpiar precio de medida", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                LimpiarPrecios()
            End If
        Else
            LimpiarPrecios()
        End If

    End Sub

    Private Sub btnInsertarPrecio_Click(sender As Object, e As EventArgs) Handles btnInsertarPrecio.Click
        'Los valores de ultima se refieren a lo siguiente

        ''Ultimo Costo de Compra= Se verifica a como fue la ultima vez que se compró
        ''Ultima Actualizacion de Compra= Fecha de la ultima compra
        ''UltimoCambioPrecios=  Ultima vez que se modificaron los precios

        If cbxMedida.Text = "" Then
            MessageBox.Show("Seleccione la medida del artículo a insertar.", "Medida o Unidad", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxMedida.Focus()
            cbxMedida.DroppedDown = True
            Exit Sub
        ElseIf txtContenido.EditValue = 0 Then
            MessageBox.Show("Escriba el contenido de la medida del artículo.", "Cantidad de Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtContenido.Focus()
            Exit Sub
        ElseIf txtCosto.EditValue = 0 Then
            MessageBox.Show("Defina el costo del artículo.", "Costo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCosto.Focus()
            Exit Sub
        ElseIf txtCostoFinal.EditValue = 0 Then
            MessageBox.Show("Defina el costo final del artículo.", "Costo Final", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtCostoFinal.Focus()
            Exit Sub
        ElseIf txtPrecioA.EditValue = 0 Or txtPrecioA.EditValue = CDbl(0).ToString("C") And txtPrecioA.Visible = True Then
            MessageBox.Show("Especifique el precio A del artículo.", "Precio de A", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPrecioA.Focus()
            Exit Sub
        ElseIf txtPrecioB.EditValue = 0 Or txtPrecioB.EditValue = CDbl(0).ToString("C") And txtPrecioB.Visible = True Then
            MessageBox.Show("Especifique el precio B del artículo.", "Precio de B", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPrecioB.Focus()
            Exit Sub
        ElseIf CDbl(txtPrecioA.EditValue) < CDbl(txtPrecioB.EditValue) Then
            MessageBox.Show("El precio A es menor que el precio B. Verifique los cálculos aplicados.", "Precio A menor que B", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPrecioB.Focus()
            Exit Sub
        ElseIf txtPrecioC.EditValue = 0 Or txtPrecioC.EditValue = CDbl(0).ToString("C") And txtPrecioC.Visible = True Then
            MessageBox.Show("Escriba y/o establezca el precio C del artículo..", "Precio de C", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPrecioC.Focus()
            Exit Sub
        ElseIf txtPrecioD.EditValue = 0 Or txtPrecioD.EditValue = CDbl(0).ToString("C") And txtPrecioD.Visible = True Then
            MessageBox.Show("Escriba y/o establezca el precio D del artículo.", "Precio de D", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPrecioD.Focus()
            Exit Sub
        ElseIf CInt(DTConfiguracion.Rows(16 - 1).Item("Value2Int")) = 0 Then
            If txtCosto.EditValue > txtPrecioA.EditValue Or txtCosto.EditValue > txtPrecioB.EditValue Or txtCosto.EditValue > txtPrecioC.EditValue Or txtCosto.EditValue > txtPrecioD.EditValue Then
                MessageBox.Show("Los precios específicados son menores al costo de venta del artículo.", "Exceden costo del producto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtPrecioD.Focus()
                Exit Sub
            End If
            If TabControl4.Contains(TabPage16) Then
                If TabPage16.Visible = True Then
                    If txtPrecioBlackFriday.Text <> "" Then
                        If IsNumeric(CDbl(txtPrecioBlackFriday.Text)) Then
                            If txtCosto.EditValue > CDbl(txtPrecioBlackFriday.Text) Then
                                MessageBox.Show("Los precios específicados son menores al costo de venta del artículo.", "Exceden costo del producto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                TabControl4.SelectedIndex = 1
                                txtPrecioBlackFriday.Focus()
                                txtPrecioBlackFriday.SelectAll()
                                Exit Sub
                            End If
                        End If
                    End If

                End If
            End If
        End If

        If txtPrecioBlackFriday.Text = "" Then
            txtPrecioBlackFriday.Text = 0
        End If

        For Each rw As DataGridViewRow In DgvPrecios.Rows
            If lblIDPrecio.Text <> rw.Cells("IDPrecios").Value.ToString Then
                If CDbl(rw.Cells("Contenido").Value) = CDbl(txtContenido.EditValue) Then
                    MessageBox.Show("El artículo " & txtDescrip.Text & " posee una medida (" & rw.Cells("Abreviatura").Value & ") que tiene el mismo contenido que desea ingresar." & vbNewLine & vbNewLine & "No es posible duplicar medidas que posean el mismo contenido.", "Contenido ya existente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If
        Next

        If txtIDProducto.Text = "" Then
            MessageBox.Show("No se ha guardado el producto a la base de datos.", "No se ha insertado el producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub

        Else

            If lblIDPrecio.Text = "" Then
                If Permisos(1) = 0 Then
                    MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                VerificarDuplicados()
                If lblCheckDuplicates.Text = 1 Then
                    Exit Sub
                End If

                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo registro a la base de datos?", "Guardar Nuevo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ConLibregco.Open()
                    cmd = New MySqlCommand("INSERT INTO Libregco.PrecioArticulo (IDArticulo,IDMedida,Contenido,Costo,CostoFinal,DescuentoMaximo,PrecioContado,PrecioCredito,Precio3,Precio4,Nulo,CostoClave,PrecioBlackFriday,Piezaje,UltimoCostoCompra,UltimaActualizacion,UltimoCambioPrecios,IDMoneda) VALUES ('" + txtIDProducto.Text + "','" + cbxMedida.Tag.ToString + "', '" + CDbl(txtContenido.EditValue).ToString + "','" + CDbl(txtCosto.EditValue).ToString + "', '" + CDbl(txtCostoFinal.EditValue).ToString + "','" + CDbl(txtDescMax.EditValue).ToString + "', '" + CDbl(txtPrecioB.EditValue).ToString + "','" + CDbl(txtPrecioA.EditValue).ToString + "','" + CDbl(txtPrecioC.EditValue).ToString + "','" + CDbl(txtPrecioD.EditValue).ToString + "',0,'" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(txtCosto.Text)).ToString + "','" + CDbl(txtPrecioBlackFriday.Text).ToString + "','" + Piezaje.Text + "','" + CDbl(txtCosto.EditValue).ToString + "',CURDATE(),CURDATE(),'" + cbxMoneda.EditValue.ToString + "')", ConLibregco)
                    cmd.ExecuteNonQuery()
                    ConLibregco.Close()

                    UltPrecio()
                    ProcesarExistencia()
                    MessageBox.Show("Precio guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    RefrescarTablaPrecios()
                    LimpiarPrecios()
                    cbxMedida.Focus()
                End If

            Else
                If Permisos(2) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                Dim ResultCambios As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro de precios?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If ResultCambios = MsgBoxResult.Yes Then
                    GuardarModificacionenPrecio()

                    ConLibregco.Open()
                    cmd = New MySqlCommand("UPDATE Libregco.PrecioArticulo SET IDMedida='" + cbxMedida.Tag.ToString + "',Contenido='" + txtContenido.EditValue.ToString + "',Costo='" + CDbl(txtCosto.EditValue).ToString + "',CostoFinal='" + CDbl(txtCostoFinal.EditValue).ToString + "',PrecioContado='" + CDbl(txtPrecioB.EditValue).ToString + "',PrecioCredito='" + CDbl(txtPrecioA.EditValue).ToString + "',Precio3='" + CDbl(txtPrecioC.EditValue).ToString + "',Precio4='" + CDbl(txtPrecioD.EditValue).ToString + "',DescuentoMaximo='" + CDbl(txtDescMax.EditValue).ToString + "',Nulo='" + lblAnularPrecio.Text + "',CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(txtCosto.Text)).ToString + "',PrecioBlackFriday='" + CDbl(txtPrecioBlackFriday.Text).ToString + "',Piezaje='" + Piezaje.Text + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "' WHERE IDPrecios=(" + lblIDPrecio.Text + ")", ConLibregco)
                    cmd.ExecuteNonQuery()
                    ConLibregco.Close()

                    ProcesarExistencia()

                    Con.Open()
                    UpdateLastUpdatePrices(lblIDPrecio.Text)
                    Con.Close()


                    MessageBox.Show("Los cambios se realizaron satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    RefrescarTablaPrecios()

                    ActualizarPreciosGrupales()
                    LimpiarPrecios()
                    cbxMedida.Focus()
                End If
            End If

        End If

    End Sub

    Private Sub ActualizarPreciosGrupales()
        Dim dstemp As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDPrecios,Costo,CostoFinal,PrecioCredito,PrecioContado,Precio3,Precio4 FROM libregco.articulos INNER JOIN Libregco.PrecioArticulo on Articulos.IDArticulo=PrecioArticulo.IDArticulo INNER JOIN Libregco.Articulos_Grupos on Articulos.IDColectivo=Articulos_Grupos.idArticulos_grupos where Articulos.IDColectivo='" + txtIDGrupo.Tag.ToString + "' and PrecioArticulo.IDMedida='" + cbxMedida.Tag.ToString + "' and Articulos_Grupos.VincularPrecio=1 and Articulos.IDArticulo<>'" + txtIDProducto.Text + "'", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "PrecioArticulo")
        ConLibregco.Close()

        Dim Tabla As DataTable = dstemp.Tables("PrecioArticulo")

        Con.Open()

        For Each rw As DataRow In Tabla.Rows

            CheckedUptadesinPrinces(rw.Item("IDPrecios").ToString, CDbl(txtCosto.Text), CDbl(txtCostoFinal.Text), CDbl(txtPrecioA.Text), CDbl(txtPrecioB.Text), CDbl(txtPrecioC.Text), CDbl(txtPrecioD.Text), CDbl(txtPrecioBlackFriday.Text), txtContenido.Text, cbxMedida.Text)

            sqlQ = "UPDATE Libregco.PrecioArticulo SET Costo='" + CDbl(txtCosto.EditValue).ToString + "',CostoFinal='" + CDbl(txtCostoFinal.EditValue).ToString + "',PrecioContado='" + CDbl(txtPrecioB.EditValue).ToString + "',PrecioCredito='" + CDbl(txtPrecioA.EditValue).ToString + "',Precio3='" + CDbl(txtPrecioC.EditValue).ToString + "',Precio4='" + CDbl(txtPrecioD.EditValue).ToString + "',DescuentoMaximo='" + CDbl(txtDescMax.EditValue).ToString + "',CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(txtCosto.Text)).ToString + "',PrecioBlackFriday='" + CDbl(txtPrecioBlackFriday.Text).ToString + "',IDMoneda='" + cbxMoneda.EditValue.ToString + "' WHERE IDPrecios=(" + rw.Item("IDPrecios").ToString + ")"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()

            UpdateLastUpdatePrices(rw.Item("IDPrecios").ToString)
        Next

        Con.Close()

        Tabla.Dispose()
        dstemp.Dispose()

    End Sub
    Private Sub GuardarModificacionenPrecio()
        'Try
        Con.Open()
            CheckedUptadesinPrinces(lblIDPrecio.Text, CDbl(txtCosto.Text), CDbl(txtCostoFinal.Text), CDbl(txtPrecioA.Text), CDbl(txtPrecioB.Text), CDbl(txtPrecioC.Text), CDbl(txtPrecioD.Text), CDbl(txtPrecioBlackFriday.Text), txtContenido.Text, cbxMedida.Text)
            Con.Close()

            RefrescarTablaHistorialPrecios()

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub
    Private Sub chkDescontinuar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDescontinuar.CheckedChanged
        If chkDescontinuar.Checked = True Then
            chkDescontinuar.Tag = 1
        Else
            chkDescontinuar.Tag = 0
        End If
    End Sub

    Private Sub btnBuscarTipoArticulo_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoArticulo.Click
        frm_buscar_tipo_articulo.ShowDialog(Me)
    End Sub

    Private Sub txtTamañoLetra_Leave(sender As Object, e As EventArgs) Handles txtTamañoLetra.Leave
        Try
            TreeViewExistencia.Font = New Font("Segoe UI", CInt(txtTamañoLetra.Text), FontStyle.Regular)
            TreeViewExistencia.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTamañoLetra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTamañoLetra.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub btnExpandirTreeView_Click(sender As Object, e As EventArgs) Handles btnExpandirTreeView.Click
        TreeViewExistencia.ExpandAll()
    End Sub

    Private Sub btnContraerTreeView_Click(sender As Object, e As EventArgs) Handles btnContraerTreeView.Click
        TreeViewExistencia.CollapseAll()
    End Sub

    Private Sub LoadAnimation()
        If PicLoading.Visible = False Then
            PicLoading.Visible = True
            ToolSeparator.Visible = True
            LabelStatus.Text = "Cargando..."
        Else
            PicLoading.Visible = False
            ToolSeparator.Visible = False
            LabelStatus.Text = "Listo"
        End If
    End Sub

    Private Sub btnImprimirArticulo_Click(sender As Object, e As EventArgs) Handles btnImprimirArticulo.Click
        Try
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If txtIDProducto.Text = "" Then
                MessageBox.Show("Seleccione un registro de artículos para acceder al reporte de descripción del artículo.", "Seleccionar artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnBuscar.PerformClick()
                Exit Sub
            End If

            Con.Open()
            cmd = New MySqlCommand("Select Path from Reportes where IDReportes=85", Con)
            Dim Path As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & Path) Else ObjRpt.Load("C:" & Path.Replace("\Libregco\Libregco.net", ""))

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            '@IDArticulo
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDArticulo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterRangeValue = New ParameterRangeValue

            With crParameterRangeValue
                .EndValue = txtIDProducto.Text
                .LowerBoundType = RangeBoundType.BoundInclusive
                .StartValue = txtIDProducto.Text
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

            '@PreAlertar
            crParameterDiscreteValue.Value = 0
            ObjRpt.SetParameterValue("@PreAlertar", 0)
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@PreAlertar")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@Revisado
            crParameterDiscreteValue.Value = 0
            ObjRpt.SetParameterValue("@Revisado", 0)
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Revisado")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@BloqueoCredito
            crParameterDiscreteValue.Value = 0
            ObjRpt.SetParameterValue("@BloqueoCredito", 0)
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@BloqueoCredito")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@IDParentezco
            crParameterDiscreteValue.Value = 0
            ObjRpt.SetParameterValue("@Parental", 0)
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Parental")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            'Setting Info 
            'Resumir Reporte
            ObjRpt.SetParameterValue("@Resumir", 0)
            'Ordenamiento de Reporte
            ObjRpt.SetParameterValue("@SortedField", "Descripción")
            ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "Descripción")
            'Usuario Info
            ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DTEmpleado.Rows(0).Item("Login").ToString() & " [" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString() & "]")
            ''Almacenes
            ObjRpt.SetParameterValue("Almacenes", "Todos los almacenes")


            LoadAnimation()
            LabelStatus.Text = "Visualizando el reporte..."
            Dim TmpForm = New frm_reportView
            TmpForm.Show(Me)
            TmpForm.CrystalViewer.ReportSource = ObjRpt
            TmpForm.CrystalViewer.Refresh()
            TmpForm.CrystalViewer.Cursor = Cursors.Default
            LabelStatus.Text = "Listo"


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnBuscarCategoria_Click(sender As Object, e As EventArgs) Handles btnBuscarCategoria.Click
        frm_buscar_categorias.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarSubCategoria_Click(sender As Object, e As EventArgs) Handles btnBuscarSubCategoria.Click
        frm_buscar_subcategorias.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarMarca_Click(sender As Object, e As EventArgs) Handles btnBuscarMarca.Click
        frm_buscar_marcas.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarGarantia_Click(sender As Object, e As EventArgs) Handles btnBuscarGarantia.Click
        frm_buscar_tipo_garantia.ShowDialog(Me)
    End Sub

    Private Sub txtReferencia_Leave(sender As Object, e As EventArgs) Handles txtReferencia.Leave

        If txtReferencia.Text <> "" Then
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,Referencia FROM Articulos where Referencia='" + txtReferencia.Text + "' and IDArticulo<>'" + txtIDProducto.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Articulos")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Articulos")

            If Tabla.Rows.Count > 0 Then
                MessageBox.Show("Ya se encuentra un registro de artículo que utiliza la referencia y/o modelo " & txtReferencia.Text & " en el sistema." & vbNewLine & vbNewLine & "El artículo corresponde a: [" & Tabla.Rows(0).Item("IDArticulo") & "] " & Tabla.Rows(0).Item("Descripcion") & ".", "Referencia y/o modelo en uso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtReferencia.Clear()
                txtReferencia.Focus()
            End If

        End If


    End Sub

    Private Sub txtDescrip_Leave(sender As Object, e As EventArgs) Handles txtDescrip.Leave
        If txtDescrip.Text <> "" Then
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,Referencia FROM Articulos where Descripcion='" + txtDescrip.Text + "' and IDArticulo<>'" + txtIDProducto.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Articulos")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Articulos")

            If Tabla.Rows.Count > 0 Then
                MessageBox.Show("Ya se encuentra un registro de artículo que utiliza la descripción " & txtDescrip.Text & " en el sistema." & vbNewLine & vbNewLine & "El artículo corresponde a: [" & Tabla.Rows(0).Item("IDArticulo") & "] " & Tabla.Rows(0).Item("Descripcion") & ", referencia: " & Tabla.Rows(0).Item("Referencia") & ".", "Descripción de artículo en uso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtDescrip.Clear()
                txtDescrip.Focus()
                Tabla.Dispose()
            End If

            If txtIDProducto.Text = "" Then
                If txtIDMarca.Text = "" Then
                    'Buscar la marca del articulo
                    Dim TablaP As New DataTable

                    ConLibregco.Open()

                    For Each word As String In txtDescrip.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
                        If Len(word) > 1 Then
                            Ds.Clear()
                            TablaP.Clear()

                            cmd = New MySqlCommand("SELECT count(Marca) FROM libregco.marca where Marca like '%" + word + "%'", ConLibregco)

                            If Convert.ToDouble(cmd.ExecuteScalar()) = 1 Then
                                cmd = New MySqlCommand("SELECT IDMarca,Marca FROM libregco.marca where Marca like '%" + word + "%'", ConLibregco)
                                Adaptador = New MySqlDataAdapter(cmd)
                                Adaptador.Fill(Ds, "Marca")
                                TablaP = Ds.Tables("Marca")

                                IDMarcaTMP = TablaP.Rows(0).Item(0)
                                MarcaTMP = TablaP.Rows(0).Item(1)

                                ToastNotificationsManager1.Notifications(2).Body = "Haz click aquí para indicar que la marca es " & MarcaTMP
                                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(2))

                                TablaP.Dispose()
                                ConLibregco.Close()
                                Exit Sub
                            End If
                        End If
                    Next

                    ConLibregco.Close()
                End If

            End If

        End If

        btNoUsedIDs.Tag = ""
        btNoUsedIDs.Text = ""

        btNoUsedIDs.Size = New Size(101, 18)
        btNoUsedIDs.Location = New Point(546, 145)


        If txtDescrip.Text.Contains("1/2") Then
            txtDescrip.Text.Replace("1/2", "½")

        ElseIf txtDescrip.Text.Contains("3/4") Then
            txtDescrip.Text.Replace("3/4", "¾")

        ElseIf txtDescrip.Text.Contains("1/4") Then
            txtDescrip.Text.Replace("1/4", "¼")

        ElseIf txtDescrip.Text.Contains("3/8") Then
            txtDescrip.Text.Replace("3/8", "⅜")

        ElseIf txtDescrip.Text.Contains("5/8") Then
            txtDescrip.Text.Replace("5/8", "⅝")

        ElseIf txtDescrip.Text.Contains("7/8") Then
            txtDescrip.Text.Replace("7/8", "⅞")

        ElseIf txtDescrip.Text.Contains("1/8") Then
            txtDescrip.Text.Replace("1/8", "⅛")
        End If
    End Sub

    Private Sub txtCodigoBarra_Leave(sender As Object, e As EventArgs) Handles txtCodigoBarra.Leave
        If txtCodigoBarra.Text <> "" Then
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,Referencia FROM Articulos where CodigoBarra='" + txtCodigoBarra.Text + "' and IDArticulo<>'" + txtIDProducto.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Articulos")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Articulos")

            If Tabla.Rows.Count > 0 Then
                MessageBox.Show("Ya se encuentra un registro de artículo que utiliza el código de barras " & txtCodigoBarra.Text & " en el sistema." & vbNewLine & vbNewLine & "El artículo corresponde a: [" & Tabla.Rows(0).Item("IDArticulo") & "] " & Tabla.Rows(0).Item("Descripcion") & ", referencia: " & Tabla.Rows(0).Item("Referencia") & ".", "Código de barra en uso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                txtCodigoBarra.Clear()
                txtCodigoBarra.Focus()
            End If

        End If
    End Sub

    Private Sub txtIDSuplidor_Leave(sender As Object, e As EventArgs) Handles txtIDSuplidor.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Suplidor from Suplidor Where IDSuplidor='" + txtIDSuplidor.Text + "'", ConLibregco)
        txtSuplidor.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtSuplidor.Text = "" Then txtIDSuplidor.Clear()
    End Sub

    Private Sub txtIDTipoArticulo_Leave(sender As Object, e As EventArgs) Handles txtIDTipoArticulo.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select TipoArticulo from TipoArticulo Where IDTipoArticulo='" + txtIDTipoArticulo.Text + "'", ConLibregco)
        txtTipoArticulo.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtTipoArticulo.Text = "" Then txtIDTipoArticulo.Clear()
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
        If txtIDCategoria.Text = "" Then
            MessageBox.Show("Seleccione la categoría del producto para proceder con el registro de artículos.", "Seleccionar categoría", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDCategoria.Focus()
        Else
            ConLibregco.Open()
            cmd = New MySqlCommand("Select SubCategoria from SubCategoria INNER JOIN Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria Where SubCategoria.IDSubCategoria='" + txtIDSubCategoria.Text + "' and SubCategoria.IDCategoria='" + txtIDCategoria.Text + "'", ConLibregco)
            txtSubCategoria.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
            If txtSubCategoria.Text = "" Then txtIDSubCategoria.Clear()
        End If

    End Sub

    Private Sub txtIDMarca_Leave(sender As Object, e As EventArgs) Handles txtIDMarca.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Marca from Marca Where IDMarca='" + txtIDMarca.Text + "'", ConLibregco)
        txtMarca.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtMarca.Text = "" Then txtIDMarca.Clear()
    End Sub

    Private Sub txtIDGarantia_Leave(sender As Object, e As EventArgs) Handles txtIDGarantia.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT TiempoGarantia FROM garantiaarticulos Where IDGarantiaArticulos='" + txtIDGarantia.Text + "'", ConLibregco)
        txtTipoGarantia.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtTipoGarantia.Text = "" Then txtIDGarantia.Clear()
    End Sub

    Private Sub txtIDItbis_Leave(sender As Object, e As EventArgs) Handles txtIDItbis.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Tipo from TipoItbis Where IDTipoItbis='" + txtIDItbis.Text + "'", ConLibregco)
        txtItbis.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtItbis.Text = "" Then txtIDItbis.Clear()
    End Sub

    Private Sub btnBuscarImagen_Click(sender As Object, e As EventArgs) Handles btnBuscarImagen.Click
        If TypeConnection.Text = 1 Then
            Dim OfdImagen As New OpenFileDialog


            With OfdImagen
                .RestoreDirectory = True
                .Title = "Buscar imagen de artículo"
                .Filter = "Imágenes(*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png"
                .FileName = ""
                .Multiselect = True
            End With

            If OfdImagen.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor

                With DgvImagenes
                    For Each file In OfdImagen.FileNames
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(file, FileMode.Open, FileAccess.Read)
                        .Rows.Add("", "", DgvImagenes.Rows.Count, ResizeImage(System.Drawing.Image.FromStream(wFile), 120), file)
                        wFile.Close()
                    Next
                End With


            End If

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DgvImagenes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvImagenes.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then
                DgvImagenes.EditMode = DataGridViewEditMode.EditOnEnter
            End If
        End If
    End Sub

    Private Sub DgvImagenes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvImagenes.CellEndEdit
        DgvImagenes.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvImagenes_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvImagenes.CurrentCellDirtyStateChanged
        If DgvImagenes.IsCurrentCellDirty Then
            DgvImagenes.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub btnVerImagen_Click(sender As Object, e As EventArgs) Handles btnVerImagen.Click
        If TypeConnection.Text = 1 Then
            If DgvImagenes.Rows.Count > 0 Then
                Dim Ruta As String = DgvImagenes.CurrentRow.Cells(4).Value

                If Ruta = "" Then
                    MessageBox.Show("No se ha encontrado una imagen anexa para poder abrirla.", "No imagen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    Dim Result As MsgBoxResult = MessageBox.Show("Desea abrir la foto vinculada al registro?", "Abrir Identificacion Anexa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        System.Diagnostics.Process.Start(Ruta)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnEliminarImagen_Click(sender As Object, e As EventArgs) Handles btnEliminarImagen.Click
        If TypeConnection.Text = 1 Then
            Dim IDImage, Ruta As String

            If DgvImagenes.Rows.Count > 0 Then
                IDImage = DgvImagenes.CurrentRow.Cells(0).Value
                Ruta = DgvImagenes.CurrentRow.Cells(4).Value

                If IDImage <> "" Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar la foto anexa al registro?", "Eliminar foto anexa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        sqlQ = "Delete from Articulos_fotos WHERE IDImagen='" + IDImage + "'"
                        ConLibregco.Open()
                        cmd = New MySqlCommand(sqlQ, ConLibregco)
                        cmd.ExecuteNonQuery()
                        ConLibregco.Close()

                        Dim ExistFile As Boolean = System.IO.File.Exists(Ruta)
                        If ExistFile = True Then
                            My.Computer.FileSystem.DeleteFile(Ruta, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                        End If

                        MessageBox.Show("La imagen ha sido eliminada satisfactoriamente.", "Imagen eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        SetDefaultPhoto(txtIDProducto.Text)
                        DgvImagenes.Rows.Remove(DgvImagenes.CurrentRow)

                    End If

                Else
                    DgvImagenes.Rows.Remove(DgvImagenes.CurrentRow)
                End If
            End If
        End If
    End Sub

    Private Sub btnAdjuntarEspecificacion_Click(sender As Object, e As EventArgs) Handles btnAdjuntarEspecificacion.Click
        DgvEspecificaciones.Rows.Add("", txtEspecificacion.Text)
        txtEspecificacion.Clear()
    End Sub

    Private Sub DgvEspecificacioneses_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEspecificaciones.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Then
                DgvEspecificaciones.EditMode = DataGridViewEditMode.EditOnEnter
            End If
        End If

    End Sub

    Private Sub DgvEspecificacioneses_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEspecificaciones.CellEndEdit
        DgvEspecificaciones.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvEspecificacioneses_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvEspecificaciones.CurrentCellDirtyStateChanged
        If DgvEspecificaciones.IsCurrentCellDirty Then
            DgvEspecificaciones.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub btnEliminarEspecificacion_Click(sender As Object, e As EventArgs) Handles btnEliminarEspecificacion.Click
        Dim IDEspecificacion As String

        If DgvEspecificaciones.Rows.Count > 0 Then
            IDEspecificacion = DgvEspecificaciones.CurrentRow.Cells(0).Value

            If IDEspecificacion <> "" Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar la especificación del producto?", "Eliminar especificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    sqlQ = "Delete from Articulos_especificaciones WHERE IDEspecificacion='" + IDEspecificacion + "'"
                    ConLibregco.Open()
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()
                    ConLibregco.Close()
                    MessageBox.Show("Especificación ha sido removida satisfactoriamente.", "Especificación eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    DgvEspecificaciones.Rows.Remove(DgvEspecificaciones.CurrentRow)
                End If

            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DgvHijos.Rows.Count > 0 Then
            If DgvHijos.CurrentRow.Cells(0).Value.ToString <> "" Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el producto hijo de " & txtDescrip.Text & "?", "Eliminar producto hijo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    sqlQ = "Delete from Articulos_Hijos WHERE IDProductosHijos='" + DgvHijos.CurrentRow.Cells(0).Value.ToString + "'"
                    ConLibregco.Open()
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()
                    ConLibregco.Close()
                    DgvHijos.Rows.Remove(DgvHijos.CurrentRow)
                    MessageBox.Show("El producto hijo ha sido removido satisfactoriamente.", "Relación eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Else
                DgvHijos.Rows.Remove(DgvHijos.CurrentRow)
            End If
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If txtIDProducto.Text = "" Then
            MessageBox.Show("Para agregar productos hijos debe utilizar un artículo que haya sido guardado en el sistema.", "No se encuentra un artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            ControlParent = 2
            frm_buscar_mant_articulos.lblStatus.Text = "Para agregar complementarios seleccione en la tabla de precios."
            frm_buscar_mant_articulos.ShowDialog(Me)
        End If
    End Sub

    Private Sub btnParentesco_Click(sender As Object, e As EventArgs) Handles btnParentesco.Click
        frm_buscar_parentesco_productos.ShowDialog(Me)
    End Sub

    Private Sub txtIDParentesco_Leave(sender As Object, e As EventArgs) Handles txtIDParentesco.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Descripcion from ParentescoProducto Where IDParentesco='" + txtIDParentesco.Text + "'", ConLibregco)
        txtParentesco.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtParentesco.Text = "" Then txtIDParentesco.Clear()
    End Sub

    Private Sub TbcProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TbcProductos.SelectedIndexChanged
        If TbcProductos.SelectedIndex = 1 Then
            cbxMedida.Focus()
        ElseIf TbcProductos.SelectedIndex = 3 Then
            ShowCheckedNodes()
        ElseIf TbcProductos.SelectedIndex = 4 Then
            DgvImagenes.ClearSelection()
        ElseIf TbcProductos.SelectedIndex = 7 Then
            GetInformation()
        ElseIf TbcProductos.SelectedIndex = 9 Then
            FillGarantias()
        End If
    End Sub

    Private Sub Populate()
        TreeView1.Nodes.Clear()

        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("Select articulos_propiedad.idArticulos_propiedad,articulos_propiedad.Propiedad,articulos_propiedad.IDParent FROM libregco.articulos_propiedad where articulos_propiedad.Nulo=0 ORDER BY IDParent ASC,articulos_propiedad.Orden ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Propiedades")
        ConLibregco.Close()

        Dim TablaPropiedades As DataTable = dstemp.Tables("Propiedades")

        Dim source = TablaPropiedades.AsEnumerable()
        Dim nodes = GetTreeNodes(source,
        Function(r) r.Field(Of Integer?)("IDParent") Is Nothing,
        Function(r, s) s.Where(Function(x) r("idArticulos_propiedad").Equals(x("IDParent"))),
        Function(r) New TreeNode With {.Text = r.Field(Of String)("Propiedad"), .Name = r.Field(Of Integer)("idArticulos_propiedad"), .Tag = r.Field(Of Integer)("idArticulos_propiedad")})

        TreeView1.Nodes.AddRange(nodes.ToArray())

        TreeView1.CollapseAll()
    End Sub

    Private Sub FillGarantias()
        Try
            DgvGarantiaProductos.Rows.Clear()
            DgvSubCategoria.Rows.Clear()
            DgvCategoria.Rows.Clear()

            Con.Open()

            If txtIDProducto.Text <> "" Then
                'Garantias especificas
                Dim GarantiaEspecifica As New MySqlCommand("Select idArticulos_garantia,Termino,isHypertext from Libregco.Articulos_Garantia where IDArticulo='" + txtIDProducto.Text + "' ORDER BY Orden ASC", Con)
                Dim Lector As MySqlDataReader = GarantiaEspecifica.ExecuteReader

                While Lector.Read
                    DgvGarantiaProductos.Rows.Add(Lector.GetValue(0), Lector.GetValue(1), Lector.GetValue(2))
                End While
                Lector.Close()
                DgvGarantiaProductos.ClearSelection()
            End If

            If txtIDSubCategoria.Text <> "" Then
                'Garantias de Subcategorias
                Dim GarantiaSubCategoria As New MySqlCommand("Select idArticulos_garantia,Termino,isHypertext from Libregco.Articulos_Garantia where IDSubCategoria='" + txtIDSubCategoria.Text + "' ORDER BY Orden ASC", Con)
                Dim Lector1 As MySqlDataReader = GarantiaSubCategoria.ExecuteReader

                While Lector1.Read
                    DgvSubCategoria.Rows.Add(Lector1.GetValue(0), Lector1.GetValue(1), Lector1.GetValue(2))
                End While
                Lector1.Close()
                DgvSubCategoria.ClearSelection()
                lblSubCategoria.Text = "Subcategoría: " & txtSubCategoria.Text

            End If

            If txtSubCategoria.Text <> "" Then
                'Garantias de categorias
                Dim GarantiaCategoria As New MySqlCommand("Select idArticulos_garantia,Termino,isHypertext from Libregco.Articulos_Garantia where IDCategoria='" + txtIDCategoria.Text + "' ORDER BY Orden ASC", Con)
                Dim Lector2 As MySqlDataReader = GarantiaCategoria.ExecuteReader

                While Lector2.Read
                    DgvCategoria.Rows.Add(Lector2.GetValue(0), Lector2.GetValue(1), Lector2.GetValue(2))
                End While
                Lector2.Close()
                DgvCategoria.ClearSelection()
                lblCategoria.Text = "Categoría: " & txtCategoria.Text
            End If


            Con.Close()

        Catch ex As Exception

            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub GetInformation()
        Try
            DgvGrafico1.Rows.Clear()
            Chart1.Series(0).Points.Clear()
            Chart1.Series(1).Points.Clear()
            Chart1.Series(2).Points.Clear()
            Chart1.Series(3).Points.Clear()

            If txtIDProducto.Text = "" Then
            Else
                Dim currentDate As DateTime = DateSerial(dtpEstadisticaInicial.Value.Year, dtpEstadisticaInicial.Value.Month, 1)
                Dim endDate As DateTime = DateSerial(dtpEstadisticaFinal.Value.Year, dtpEstadisticaFinal.Value.Month, 1)
                Dim monthCount As Integer = CInt(DateDiff(DateInterval.Month, currentDate, endDate))
                For i = 0 To monthCount
                    DgvGrafico1.Rows.Add(currentDate.AddMonths(i).ToString("dd/MM/yyyy"))
                Next

                Dim Accum As Double = 0

                ConMixta.Open()

                For Each rw As DataGridViewRow In DgvGrafico1.Rows
                    cmd = New MySqlCommand("SELECT Coalesce(sum(cantidad),0) as Cantidad FROM Libregco.facturaarticulos inner join Libregco.facturadatos on facturaarticulos.idfactura=facturadatos.idfacturadatos where idarticulo = '" + txtIDProducto.Text + "' and FacturaDatos.Fecha Between '" & CDate(rw.Cells(0).Value).ToString("yyyy-MM-dd") & "' AND '" & CDate(rw.Cells(0).Value).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") & "'", ConMixta)
                    rw.Cells(1).Value = Math.Round(CDbl(Convert.ToDouble(cmd.ExecuteScalar())), 3)

                    If chkRevalidacion.Checked Then
                        cmd = New MySqlCommand("SELECT Coalesce(sum(cantidad),0) as Cantidad FROM Libregco_Main.facturaarticulos inner join Libregco_Main.facturadatos on facturaarticulos.idfactura=facturadatos.idfacturadatos where idarticulo = '" + txtIDProducto.Text + "' and FacturaDatos.Fecha Between '" & CDate(rw.Cells(0).Value).ToString("yyyy-MM-dd") & "' AND '" & CDate(rw.Cells(0).Value).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") & "'", ConMixta)
                        rw.Cells(1).Value = CDbl(rw.Cells(1).Value) + Math.Round(CDbl(Convert.ToDouble(cmd.ExecuteScalar())), 3)
                    End If

                    cmd = New MySqlCommand("SELECT Coalesce(sum(cantidad),0) as Cantidad FROM Libregco.DetalleCompra inner join Libregco.compras on DetalleCompra.idcompra=compras.idcompra where idarticulo = '" + txtIDProducto.Text + "' and compras.Fecha Between '" & CDate(rw.Cells(0).Value).ToString("yyyy-MM-dd") & "' AND '" & CDate(rw.Cells(0).Value).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") & "'", ConMixta)
                    rw.Cells(2).Value = Math.Round(CDbl(Convert.ToDouble(cmd.ExecuteScalar())), 3)

                    If chkRevalidacion.Checked Then
                        cmd = New MySqlCommand("SELECT Coalesce(sum(cantidad),0) as Cantidad FROM Libregco_Main.DetalleCompra inner join Libregco_Main.compras on DetalleCompra.idcompra=compras.idcompra where idarticulo = '" + txtIDProducto.Text + "' and compras.Fecha Between '" & CDate(rw.Cells(0).Value).ToString("yyyy-MM-dd") & "' AND '" & CDate(rw.Cells(0).Value).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") & "'", ConMixta)
                        rw.Cells(2).Value = Math.Round(CDbl(rw.Cells(2).Value) + Math.Round(CDbl(Convert.ToDouble(cmd.ExecuteScalar())), 3), 3)
                    End If

                    rw.Cells(3).Value = Math.Round(CDbl(rw.Cells(2).Value) - CDbl(rw.Cells(1).Value), 3)
                    Accum += CDbl(rw.Cells(3).Value)

                    rw.Cells(4).Value = Accum
                Next

                ConMixta.Close()

                For Each rw As DataGridViewRow In DgvGrafico1.Rows
                    If chkChart1Venta.Checked Then
                        Chart1.Series("Ventas").Points.AddXY(CDate(rw.Cells(0).Value).ToString("MMMM-yyyy"), CDbl(rw.Cells(1).Value))
                    End If
                    If chkChart1Compra.Checked Then
                        Chart1.Series("Compras").Points.AddXY(CDate(rw.Cells(0).Value).ToString("MMMM-yyyy"), CDbl(rw.Cells(2).Value))
                    End If
                    If ChkChart1Resultado.Checked Then
                        Chart1.Series("Resultado").Points.AddXY(CDate(rw.Cells(0).Value).ToString("MMMM-yyyy"), CDbl(rw.Cells(3).Value))
                    End If
                    If chkChart1Acumulado.Checked Then
                        Chart1.Series("Acumulado").Points.AddXY(CDate(rw.Cells(0).Value).ToString("MMMM-yyyy"), CDbl(rw.Cells(4).Value))
                    End If
                Next
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkBloqueoCredito_CheckedChanged(sender As Object, e As EventArgs) Handles chkBloqueoCredito.CheckedChanged
        If chkBloqueoCredito.Checked = True Then
            chkBloqueoCredito.Tag = 1
        Else
            chkBloqueoCredito.Tag = 0
        End If
    End Sub


    Private Sub chkPreAlertar_CheckedChanged(sender As Object, e As EventArgs) Handles chkPreAlertar.CheckedChanged
        If chkPreAlertar.Checked = True Then
            chkPreAlertar.Tag = 1
        Else
            chkPreAlertar.Tag = 0
        End If
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        If chkSeleccionarTodo.Checked = True Then
            chkCompras.Checked = True
            chkDevolucionesCompra.Checked = True
            chkVentas.Checked = True
            chkInvInicial.Checked = True
            chkAjustesEntrada.Checked = True
            chkAjustesSalida.Checked = True
            chkReparaciones.Checked = True
            chkEntradas.Checked = True
            chkDevoluciones.Checked = True
        Else
            chkCompras.Checked = False
            chkDevolucionesCompra.Checked = False
            chkVentas.Checked = False
            chkInvInicial.Checked = False
            chkAjustesEntrada.Checked = False
            chkAjustesSalida.Checked = False
            chkReparaciones.Checked = False
            chkEntradas.Checked = False
            chkDevoluciones.Checked = False
        End If
    End Sub

    Private Sub ChkRevisado_CheckedChanged(sender As Object, e As EventArgs) Handles ChkRevisado.CheckedChanged
        If ChkRevisado.Checked = True Then
            ChkRevisado.Tag = 1
        Else
            ChkRevisado.Tag = 0
        End If
    End Sub

    Private Sub cbxMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMedida.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")


        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            txtContenido.Focus()
            txtContenido.SelectAll()
        End If
    End Sub

    Private Sub txtContenido_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContenido.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")


        ElseIf e.KeyCode = Keys.Right Then
            If txtContenido.Text <> "" Then
                If txtContenido.SelectionStart = CStr(txtContenido.EditValue).Length Then
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If
            End If

        ElseIf e.KeyCode = Keys.Left Then
            If txtContenido.SelectionStart = 0 Then
                e.Handled = True
                cbxMedida.Focus()
                cbxMedida.DroppedDown = True
            End If
        End If
    End Sub

    Private Sub txtCostoFinal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCostoFinal.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCostoFinal.IsPopupOpen = False Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If


        ElseIf e.KeyCode = Keys.Right Then
            If txtCostoFinal.Text <> "" Then
                If txtCostoFinal.SelectionStart = CStr(txtCostoFinal.Value).Length Then
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If
            End If

        ElseIf e.KeyCode = Keys.Left Then
            If txtCostoFinal.SelectionStart = 0 Then
                e.Handled = True
                txtCosto.Focus()
                txtCosto.SelectAll()

            End If
        End If
    End Sub

    Private Sub txtDescMax_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescMax.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            If txtDescMax.Text <> "" Then
                If txtDescMax.EditValue.SelectionStart = CStr(txtDescMax.EditValue).Length Then
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If
            End If

        ElseIf e.KeyCode = Keys.Left Then
            If txtDescMax.SelectionStart = 0 Then
                e.Handled = True
                txtCostoFinal.Focus()
                txtCostoFinal.SelectAll()

            End If
        End If
    End Sub

    Private Sub txtPrecioA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioA.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPrecioA.IsPopupOpen = False Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtPrecioA.Text <> "" Then
                If txtPrecioA.SelectionStart = CStr(txtPrecioA.Value).Length Then
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If
            End If

        ElseIf e.KeyCode = Keys.Left Then
            If txtPrecioA.SelectionStart = 0 Then
                e.Handled = True
                txtDescMax.Focus()
                txtDescMax.SelectAll()

            End If
        End If
    End Sub

    Private Sub txtPrecioB_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioB.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPrecioB.IsPopupOpen = False Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtPrecioB.Text <> "" Then
                If txtPrecioB.SelectionStart = CStr(txtPrecioB.Value).Length Then
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If
            End If

        ElseIf e.KeyCode = Keys.Left Then
            If txtPrecioB.SelectionStart = 0 Then
                e.Handled = True
                txtPrecioA.Focus()
                txtPrecioA.SelectAll()

            End If
        End If
    End Sub

    Private Sub txtPrecioC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioC.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPrecioC.IsPopupOpen = False Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtPrecioC.Text <> "" Then
                If txtPrecioC.SelectionStart = CStr(txtPrecioC.Value).Length Then
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If
            End If

        ElseIf e.KeyCode = Keys.Left Then
            If txtPrecioC.SelectionStart = 0 Then
                e.Handled = True
                txtPrecioB.Focus()
                txtPrecioB.SelectAll()
            End If
        End If
    End Sub

    Private Sub txtPrecioD_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioD.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPrecioD.IsPopupOpen = False Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtPrecioD.Text <> "" Then
                If txtPrecioD.SelectionStart = CStr(txtPrecioD.Value).Length Then
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If
            End If

        ElseIf e.KeyCode = Keys.Left Then
            If txtPrecioD.SelectionStart = 0 Then
                e.Handled = True
                txtPrecioC.Focus()
                txtPrecioC.SelectAll()

            End If
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If txtGarantiaProducto.Text <> "" Then
            DgvGarantiaProductos.Rows.Add(txtGarantiaProducto.Tag.ToString, txtGarantiaProducto.Text, Convert.ToInt16(chkHyperProducto.Checked))
            txtGarantiaProducto.Clear()
            txtGarantiaCategoria.Tag = ""
            chkHyperProducto.Checked = False
            txtGarantiaProducto.Focus()
        End If

    End Sub

    Private Sub DgvGarantiaProducto_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvGarantiaProductos.CellDoubleClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Then
                txtGarantiaProducto.Tag = DgvGarantiaProductos.CurrentRow.Cells(0).Value
                txtGarantiaProducto.Text = DgvGarantiaProductos.CurrentRow.Cells(1).Value
                chkHyperProducto.Checked = Convert.ToBoolean(DgvGarantiaProductos.CurrentRow.Cells(2).Value)
                DgvGarantiaProductos.Rows.Remove(DgvGarantiaProductos.CurrentRow)
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If txtGarantiaSubCategoria.Text <> "" Then
            DgvSubCategoria.Rows.Add(txtGarantiaSubCategoria.Tag.ToString, txtGarantiaSubCategoria.Text, Convert.ToInt16(chkHyperSubCat.Checked))
            txtGarantiaSubCategoria.Clear()
            txtGarantiaSubCategoria.Tag = ""
            chkHyperSubCat.Checked = False
            txtGarantiaSubCategoria.Focus()
        End If

    End Sub

    Private Sub DgvSubCategoria_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSubCategoria.CellDoubleClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Then
                txtGarantiaSubCategoria.Tag = DgvSubCategoria.CurrentRow.Cells(0).Value
                txtGarantiaSubCategoria.Text = DgvSubCategoria.CurrentRow.Cells(1).Value
                chkHyperSubCat.Checked = Convert.ToBoolean(DgvSubCategoria.CurrentRow.Cells(2).Value)
                DgvSubCategoria.Rows.Remove(DgvSubCategoria.CurrentRow)
            End If
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If txtGarantiaCategoria.Text <> "" Then
            DgvCategoria.Rows.Add(txtGarantiaCategoria.Tag.ToString, txtGarantiaCategoria.Text, Convert.ToInt16(chkHyperCat.Checked))
            txtGarantiaCategoria.Clear()
            txtGarantiaCategoria.Tag = ""
            chkHyperCat.Checked = False
            txtGarantiaCategoria.Focus()

        End If
    End Sub


    Private Sub DgvCategoria_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCategoria.CellDoubleClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Then
                txtGarantiaCategoria.Tag = DgvCategoria.CurrentRow.Cells(0).Value
                txtGarantiaCategoria.Text = DgvCategoria.CurrentRow.Cells(1).Value
                chkHyperCat.Checked = Convert.ToBoolean(DgvCategoria.CurrentRow.Cells(2).Value)
                DgvCategoria.Rows.Remove(DgvCategoria.CurrentRow)
            End If
        End If

    End Sub


    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If DgvGarantiaProductos.Rows.Count > 0 Then

            Con.Open()

            For Each Row As DataGridViewRow In DgvGarantiaProductos.Rows
                If Row.Cells(0).Value.ToString = "" Then
                    sqlQ = "INSERT INTO Articulos_garantia (IDArticulo,Termino,Orden,isHypertext) VALUES ('" + txtIDProducto.Text + "','" + Row.Cells(1).Value.ToString + "','" + Row.Index.ToString + "','" + Row.Cells(2).Value.ToString + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()

                    cmd = New MySqlCommand("Select idArticulos_garantia from Libregco.Articulos_garantia where idArticulos_garantia=(Select Max(idArticulos_garantia) from Libregco.Articulos_Garantia)", Con)
                    Row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                Else
                    sqlQ = "UPDATE Articulos_garantia SET IDArticulo='" + txtIDProducto.Text + "',Termino='" + Row.Cells(1).Value.ToString + "',isHypertext='" + Row.Cells(2).Value.ToString + "',Orden='" + Row.Index.ToString + "' Where idArticulos_garantia='" + Row.Cells(0).Value.ToString + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If



            Next

            Con.Close()

            MessageBox.Show("Las especificaciones de la garantía al nivel del producto han sido guardadas y actualizadas.", "Guardado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        End If
    End Sub


    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If txtIDSubCategoria.Text <> "" Then
            If DgvSubCategoria.Rows.Count > 0 Then

                Con.Open()

                For Each Row As DataGridViewRow In DgvSubCategoria.Rows
                    If Row.Cells(0).Value.ToString = "" Then
                        sqlQ = "INSERT INTO Articulos_garantia (IDSubCategoria,Termino,Orden,isHypertext) VALUES ('" + txtIDSubCategoria.Text + "','" + Row.Cells(1).Value.ToString + "','" + Row.Index.ToString + "','" + Row.Cells(2).Value.ToString + "')"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()

                        cmd = New MySqlCommand("Select idArticulos_garantia from Libregco.Articulos_garantia where idArticulos_garantia=(Select Max(idArticulos_garantia) from Libregco.Articulos_Garantia)", Con)
                        Row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                    Else
                        sqlQ = "UPDATE Articulos_garantia SET IDSubCategoria='" + txtIDSubCategoria.Text + "',Termino='" + Row.Cells(1).Value.ToString + "',isHypertext='" + Row.Cells(2).Value.ToString + "',Orden='" + Row.Index.ToString + "' Where idArticulos_garantia='" + Row.Cells(0).Value.ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                    End If



                Next

                Con.Close()

                MessageBox.Show("Las especificaciones de la garantía al nivel del subcategoría han sido guardadas y actualizadas.", "Guardado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            End If
        End If

    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        If txtIDCategoria.Text <> "" Then
            If DgvCategoria.Rows.Count > 0 Then

                Con.Open()

                For Each Row As DataGridViewRow In DgvCategoria.Rows
                    If Row.Cells(0).Value.ToString = "" Then
                        sqlQ = "INSERT INTO Articulos_garantia (IDCategoria,Termino,Orden,isHypertext) VALUES ('" + txtIDCategoria.Text + "','" + Row.Cells(1).Value.ToString + "','" + Row.Index.ToString + "','" + Row.Cells(2).Value.ToString + "')"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()

                        cmd = New MySqlCommand("Select idArticulos_garantia from Libregco.Articulos_garantia where idArticulos_garantia=(Select Max(idArticulos_garantia) from Libregco.Articulos_Garantia)", Con)
                        Row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                    Else
                        sqlQ = "UPDATE Articulos_garantia SET IDCategoria='" + txtIDCategoria.Text + "',Termino='" + Row.Cells(1).Value.ToString + "',isHypertext='" + Row.Cells(2).Value.ToString + "',Orden='" + Row.Index.ToString + "' Where idArticulos_garantia='" + Row.Cells(0).Value.ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                    End If



                Next

                Con.Close()

                MessageBox.Show("Las especificaciones de la garantía al nivel del categoría han sido guardadas y actualizadas.", "Guardado exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        If DgvGarantiaProductos.SelectedRows.Count > 0 Then
            If DgvGarantiaProductos.CurrentRow.Cells(0).Value.ToString = "" Then
                DgvGarantiaProductos.Rows.Remove(DgvGarantiaProductos.CurrentRow)
            Else
                Con.Open()
                sqlQ = "Delete from Articulos_Garantia Where idArticulos_garantia=(" + DgvGarantiaProductos.CurrentRow.Cells(0).Value.ToString + ")"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
                Con.Close()
                DgvGarantiaProductos.Rows.Remove(DgvGarantiaProductos.CurrentRow)
            End If

        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        If DgvSubCategoria.SelectedRows.Count > 0 Then
            If DgvSubCategoria.CurrentRow.Cells(0).Value.ToString = "" Then
                DgvSubCategoria.Rows.Remove(DgvSubCategoria.CurrentRow)
            Else
                Con.Open()
                sqlQ = "Delete from Articulos_Garantia Where idArticulos_garantia=(" + DgvSubCategoria.CurrentRow.Cells(0).Value.ToString + ")"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
                Con.Close()
                DgvSubCategoria.Rows.Remove(DgvSubCategoria.CurrentRow)
            End If

        End If
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        If DgvCategoria.SelectedRows.Count > 0 Then
            If DgvCategoria.CurrentRow.Cells(0).Value.ToString = "" Then
                DgvCategoria.Rows.Remove(DgvCategoria.CurrentRow)
            Else
                Con.Open()
                sqlQ = "Delete from Articulos_Garantia Where idArticulos_garantia=(" + DgvCategoria.CurrentRow.Cells(0).Value.ToString + ")"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
                Con.Close()
                DgvCategoria.Rows.Remove(DgvCategoria.CurrentRow)
            End If

        End If
    End Sub

    Private Sub DgvGarantiaProducto_DragDrop(sender As Object, e As DragEventArgs) Handles DgvGarantiaProductos.DragDrop
        Dim p As Point = DgvGarantiaProductos.PointToClient(New Point(e.X, e.Y))

        dragIndex1 = DgvGarantiaProductos.HitTest(p.X, p.Y).RowIndex

        If dragIndex1 > -1 Then
            If (e.Effect = DragDropEffects.Move) Then
                Dim dragRow As DataGridViewRow = e.Data.GetData(GetType(DataGridViewRow))
                DgvGarantiaProductos.Rows.RemoveAt(fromIndex1)
                DgvGarantiaProductos.Rows.Insert(dragIndex1, dragRow)
            End If
        End If

    End Sub

    Private Sub DgvGarantiaProducto_DragOver(sender As Object, e As DragEventArgs) Handles DgvGarantiaProductos.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub DgvGarantiaProducto_MouseDown(sender As Object, e As MouseEventArgs) Handles DgvGarantiaProductos.MouseDown
        fromIndex1 = DgvGarantiaProductos.HitTest(e.X, e.Y).RowIndex
        If fromIndex1 > -1 Then
            Dim dragSize As Size = SystemInformation.DragSize
            dragRect1 = New Rectangle(New Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)

        Else
            dragRect1 = Rectangle.Empty
        End If

        DgvGarantiaProductos.Cursor = Cursors.Default
    End Sub

    Private Sub DgvGarantiaProducto_MouseMove(sender As Object, e As MouseEventArgs) Handles DgvGarantiaProductos.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            If (dragRect1 <> Rectangle.Empty AndAlso Not dragRect1.Contains(e.X, e.Y)) Then
                DgvGarantiaProductos.DoDragDrop(DgvGarantiaProductos.Rows(fromIndex1), DragDropEffects.Move)
                DgvGarantiaProductos.Cursor = Cursors.Default
            End If
        End If
    End Sub


    Private Sub DgvGarantiaProducto_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles DgvGarantiaProductos.GiveFeedback
        e.UseDefaultCursors = False

        If e.Effect And DragDropEffects.Move = DragDropEffects.Move Then
            Dim DgvSz As Size = DgvGarantiaProductos.ClientSize
            Dim Rw As Integer = DgvGarantiaProductos.SelectedRows(0).Index
            Dim RowRect As Rectangle = DgvGarantiaProductos.GetRowDisplayRectangle(Rw, True)

            Using bmpDgv As Bitmap = New Bitmap(DgvSz.Width, DgvSz.Height)

                Using bmprow As Bitmap = New Bitmap(RowRect.Width, RowRect.Height)
                    DgvGarantiaProductos.DrawToBitmap(bmpDgv, New Rectangle(Point.Empty, DgvSz))

                    Using g As Graphics = Graphics.FromImage(bmprow)
                        g.DrawImage(bmpDgv, New Rectangle(Point.Empty, RowRect.Size), RowRect, GraphicsUnit.Pixel)
                    End Using

                    Dim Cur As Windows.Forms.Cursor = New Windows.Forms.Cursor(bmprow.GetHicon())
                    DgvGarantiaProductos.Cursor = Cur

                End Using
            End Using
        End If
    End Sub

    Private Sub DgvGarantiaProducto_MouseUp(sender As Object, e As MouseEventArgs) Handles DgvGarantiaProductos.MouseUp
        DgvGarantiaProductos.Cursor = Cursors.Default
    End Sub

    Private Sub DgvGarantiaProducto_Leave(sender As Object, e As EventArgs) Handles DgvGarantiaProductos.Leave
        DgvGarantiaProductos.Cursor = Cursors.Default
    End Sub

    Private Sub DgvSubCategoria_DragDrop(sender As Object, e As DragEventArgs) Handles DgvSubCategoria.DragDrop
        Dim p As Point = DgvSubCategoria.PointToClient(New Point(e.X, e.Y))

        dragIndex2 = DgvSubCategoria.HitTest(p.X, p.Y).RowIndex

        If dragIndex2 > -1 Then
            If (e.Effect = DragDropEffects.Move) Then
                Dim dragRow As DataGridViewRow = e.Data.GetData(GetType(DataGridViewRow))
                DgvSubCategoria.Rows.RemoveAt(fromIndex2)
                DgvSubCategoria.Rows.Insert(dragIndex2, dragRow)
            End If
        End If

    End Sub

    Private Sub DgvSubCategoria_DragOver(sender As Object, e As DragEventArgs) Handles DgvSubCategoria.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub DgvSubCategoria_MouseDown(sender As Object, e As MouseEventArgs) Handles DgvSubCategoria.MouseDown
        fromIndex2 = DgvSubCategoria.HitTest(e.X, e.Y).RowIndex
        If fromIndex2 > -1 Then
            Dim dragSize As Size = SystemInformation.DragSize
            dragRect2 = New Rectangle(New Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)

        Else
            dragRect2 = Rectangle.Empty
        End If

        DgvSubCategoria.Cursor = Cursors.Default
    End Sub

    Private Sub DgvSubCategoria_MouseMove(sender As Object, e As MouseEventArgs) Handles DgvSubCategoria.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            If (dragRect2 <> Rectangle.Empty AndAlso Not dragRect2.Contains(e.X, e.Y)) Then
                DgvSubCategoria.DoDragDrop(DgvSubCategoria.Rows(fromIndex2), DragDropEffects.Move)
                DgvSubCategoria.Cursor = Cursors.Default
            End If
        End If
    End Sub


    Private Sub DgvSubCategoria_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles DgvSubCategoria.GiveFeedback
        e.UseDefaultCursors = False

        If e.Effect And DragDropEffects.Move = DragDropEffects.Move Then
            Dim DgvSz As Size = DgvSubCategoria.ClientSize
            Dim Rw As Integer = DgvSubCategoria.SelectedRows(0).Index
            Dim RowRect As Rectangle = DgvSubCategoria.GetRowDisplayRectangle(Rw, True)

            Using bmpDgv As Bitmap = New Bitmap(DgvSz.Width, DgvSz.Height)

                Using bmprow As Bitmap = New Bitmap(RowRect.Width, RowRect.Height)
                    DgvSubCategoria.DrawToBitmap(bmpDgv, New Rectangle(Point.Empty, DgvSz))

                    Using g As Graphics = Graphics.FromImage(bmprow)
                        g.DrawImage(bmpDgv, New Rectangle(Point.Empty, RowRect.Size), RowRect, GraphicsUnit.Pixel)
                    End Using

                    Dim Cur As Windows.Forms.Cursor = New Windows.Forms.Cursor(bmprow.GetHicon())
                    DgvSubCategoria.Cursor = Cur

                End Using
            End Using
        End If
    End Sub

    Private Sub DgvSubCategoria_MouseUp(sender As Object, e As MouseEventArgs) Handles DgvSubCategoria.MouseUp
        DgvSubCategoria.Cursor = Cursors.Default
    End Sub

    Private Sub DgvSubCategoria_Leave(sender As Object, e As EventArgs) Handles DgvSubCategoria.Leave
        DgvSubCategoria.Cursor = Cursors.Default
    End Sub

    Private Sub DgvCategoria_DragDrop(sender As Object, e As DragEventArgs) Handles DgvCategoria.DragDrop
        Dim p As Point = DgvCategoria.PointToClient(New Point(e.X, e.Y))

        dragIndex3 = DgvCategoria.HitTest(p.X, p.Y).RowIndex

        If dragIndex3 > -1 Then
            If (e.Effect = DragDropEffects.Move) Then
                Dim dragRow As DataGridViewRow = e.Data.GetData(GetType(DataGridViewRow))
                DgvCategoria.Rows.RemoveAt(fromIndex3)
                DgvCategoria.Rows.Insert(dragIndex3, dragRow)
            End If
        End If

    End Sub

    Private Sub DgvCategoria_DragOver(sender As Object, e As DragEventArgs) Handles DgvCategoria.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub DgvCategoria_MouseDown(sender As Object, e As MouseEventArgs) Handles DgvCategoria.MouseDown
        fromIndex3 = DgvCategoria.HitTest(e.X, e.Y).RowIndex
        If fromIndex3 > -1 Then
            Dim dragSize As Size = SystemInformation.DragSize
            dragRect3 = New Rectangle(New Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)

        Else
            dragRect3 = Rectangle.Empty
        End If

        DgvCategoria.Cursor = Cursors.Default
    End Sub

    Private Sub DgvCategoria_MouseMove(sender As Object, e As MouseEventArgs) Handles DgvCategoria.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            If (dragRect3 <> Rectangle.Empty AndAlso Not dragRect3.Contains(e.X, e.Y)) Then
                DgvCategoria.DoDragDrop(DgvCategoria.Rows(fromIndex3), DragDropEffects.Move)
                DgvCategoria.Cursor = Cursors.Default
            End If
        End If
    End Sub


    Private Sub DgvCategoria_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles DgvCategoria.GiveFeedback
        e.UseDefaultCursors = False

        If e.Effect And DragDropEffects.Move = DragDropEffects.Move Then
            Dim DgvSz As Size = DgvCategoria.ClientSize
            Dim Rw As Integer = DgvCategoria.SelectedRows(0).Index
            Dim RowRect As Rectangle = DgvCategoria.GetRowDisplayRectangle(Rw, True)

            Using bmpDgv As Bitmap = New Bitmap(DgvSz.Width, DgvSz.Height)

                Using bmprow As Bitmap = New Bitmap(RowRect.Width, RowRect.Height)
                    DgvCategoria.DrawToBitmap(bmpDgv, New Rectangle(Point.Empty, DgvSz))

                    Using g As Graphics = Graphics.FromImage(bmprow)
                        g.DrawImage(bmpDgv, New Rectangle(Point.Empty, RowRect.Size), RowRect, GraphicsUnit.Pixel)
                    End Using

                    Dim Cur As Windows.Forms.Cursor = New Windows.Forms.Cursor(bmprow.GetHicon())
                    DgvCategoria.Cursor = Cur

                End Using
            End Using
        End If
    End Sub

    Private Sub DgvCategoria_MouseUp(sender As Object, e As MouseEventArgs) Handles DgvCategoria.MouseUp
        DgvCategoria.Cursor = Cursors.Default
    End Sub

    Private Sub EscanearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EscanearToolStripMenuItem.Click
        Try
            If TypeConnection.Text = 1 Then
                Dim CD As New WIA.CommonDialog
                Dim F As WIA.ImageFile = CD.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType)

                F.SaveFile("C\Temp\WIA." + F.FileExtension)

            End If
        Catch ex As Exception
            MessageBox.Show("Se ha producido un error debido a que la estructura de esta función solo está disponible para arquitecturas x32 bits.", "Error en aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvImagenes_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvImagenes.CellValueChanged
        'Try
        If DgvImagenes.Rows.Count > 0 Then
            If IsNumeric(DgvImagenes.CurrentRow.Cells(2).Value) Then
            Else
                DgvImagenes.CurrentRow.Cells(2).Value = DgvImagenes.Rows.Count
            End If
        End If
        'Catch ex As Exception

        'End Try


    End Sub

    Private Sub txtPrecioBlackFriday_Enter(sender As Object, e As EventArgs) Handles txtPrecioBlackFriday.Enter
        If txtPrecioBlackFriday.Text = "" Then
        Else
            txtPrecioBlackFriday.Text = CDbl(txtPrecioBlackFriday.Text)
        End If
    End Sub

    Private Sub txtPrecioBlackFriday_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioBlackFriday.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPrecioBlackFriday_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioBlackFriday.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtPrecioBlackFriday.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecioBlackFriday_Leave(sender As Object, e As EventArgs) Handles txtPrecioBlackFriday.Leave
        Try
            If txtPrecioBlackFriday.Text = "" Then
                txtPrecioBlackFriday.Text = (0).ToString("C")
            Else
                txtPrecioBlackFriday.Text = CDbl(txtPrecioBlackFriday.Text).ToString("C")

            End If
        Catch ex As Exception
            txtPrecioBlackFriday.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT * FROM" & SysName.Text & "Reportes Where Descripcion= '" + CbxFormato.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Reportes")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds.Tables("Reportes")

        CbxFormato.Tag = (Tabla.Rows(0).Item("IDReportes"))
        PathReport.Text = (Tabla.Rows(0).Item("Path"))
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            If DgvPrecios.Rows.Count > 0 Then

                Dim crParameterValues As New ParameterValues
                Dim crParameterDiscreteValue As New ParameterDiscreteValue
                Dim ObjRpt As New ReportDocument
                Dim DsSP As New DataSet

                If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


                Dim cmdSP As New MySqlCommand
                Dim AdaptadorSP As MySqlDataAdapter

                'Llenado EmpresaView
                AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
                AdaptadorSP.Fill(DsSP, "EmpresaView")

                'Para facturas a credito
                'Lleando EtiquetaData
                AdaptadorSP = New MySqlDataAdapter("Select Articulos.IDArticulo,Articulos.Descripcion,Referencia,IDTipoProducto,TipoArticulo,Articulos.IDSuplidor,Suplidor,Articulos.IDDepartamento,Departamento,Articulos.IDItbis,Tipo,Articulos.IDCategoria,Categoria,Articulos.IDSubCategoria,SubCategoria,Articulos.IDMarca,Marca,IDGarantia,TiempoGarantia,GarantiaArticulos.Dias,Articulos.IDParentesco,ParentescoProducto.Descripcion as Parentesco,CodigoBarra,Serial,Promocion,Devolucion,VenderCosto,Descontinuar,ExistenciaTotal,ExistenciaMin,ExistenciaMax,Existencia,Articulos.RutaFoto,Articulos.PreAlertar,Articulos.Revisado,Articulos.BloqueoCredito,Articulos.Desactivar,IDExistencia,Almacen.IDSucursal,Sucursal.Sucursal,Existencia.IDAlmacen,Almacen,Color.IDColor,Color.Color,BigColorPath,QRCode,Medida.IDMedida,Medida,Existencia.Existencia as ExistenciaAlmacen,IDPrecios,Contenido,Costo,CostoFinal,CostoClave,PrecioContado,PrecioCredito,Precio3,Precio4,PrecioBlackFriday,(Select count(IDEspecificacion) from Libregco.Articulos_Especificaciones Where Articulos.IDArticulo=Articulos_Especificaciones.IDArticulo) as CantEspecificaciones from Libregco.Articulos INNER JOIN Libregco.TipoArticulo on Articulos.IDTipoProducto=TipoArticulo.IDTipoArticulo INNER JOIN Libregco.Suplidor on Articulos.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Departamentos on Articulos.IDDepartamento=Departamentos.IDDepartamento INNER JOIN Libregco.TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis INNER JOIN Libregco.Categoria on Articulos.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.SubCategoria on Articulos.IDSubCategoria=SubCategoria.IDSubCategoria INNER JOIN Libregco.Marca on Articulos.IDMarca=Marca.IDMarca INNER JOIN Libregco.Garantiaarticulos ON Articulos.IDGarantia=GarantiaArticulos.IDGarantiaArticulos LEFT JOIN Libregco.PrecioArticulo on Articulos.IDArticulo=PrecioArticulo.IDArticulo LEFT JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida LEFT JOIN Libregco.Existencia on PrecioArticulo.IDPrecios=Existencia.IDPrecioArticulo LEFT JOIN Libregco.Almacen on Existencia.IDAlmacen=Almacen.IDAlmacen LEFT JOIN Libregco.Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.ParentescoProducto on Articulos.IDParentesco=ParentescoProducto.IDParentesco INNER JOIN Libregco.Color on Articulos.IDColor=Color.IDColor Where PrecioArticulo.IDPrecios='" + CStr(DgvPrecios.CurrentRow.Cells(0).Value).ToString + "'", ConMixta)
                AdaptadorSP.Fill(DsSP, "EtiquetasData")

                cmdSP.Dispose()
                AdaptadorSP.Dispose()

                ObjRpt.Database.Tables("listadoproductosview1").SetDataSource(DsSP.Tables("EtiquetasData"))
                ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))




                ''@Precios
                'crParameterDiscreteValue.Value = DgvPrecios.CurrentRow.Cells(0).Value
                'crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                'crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDPrecios")
                'crParameterValues.Add(crParameterDiscreteValue)
                'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@SelectPrecio
                crParameterDiscreteValue.Value = 8
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@SelectPrecio")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@TextoPresenta
                crParameterDiscreteValue.Value = TextBox1.Text
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@TextoPresenta")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                LabelStatus.Text = "Reporte en impresión..."

                Dim PrintDialog As New PrintDialog
                With PrintDialog
                    .AllowSelection = True
                    .AllowSomePages = True
                    .AllowPrintToFile = True
                    .PrinterSettings.Copies = Convert.ToInt16(txtCantidadImpresiones.Value)
                End With

                If (PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    Me.Cursor = Cursors.WaitCursor
                    ObjRpt.SummaryInfo.ReportTitle = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy")
                    ObjRpt.SummaryInfo.ReportAuthor = frm_inicio.lblNombre.Text & " [" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString() & "] "
                    ObjRpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName
                    Dim Settings As New PrinterSettings
                    Dim PrinterDefault As String = Settings.PrinterName
                    Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", PrintDialog.PrinterSettings.PrinterName))
                    ObjRpt.PrintToPrinter(PrintDialog.PrinterSettings.Copies, PrintDialog.PrinterSettings.Collate, PrintDialog.PrinterSettings.FromPage, PrintDialog.PrinterSettings.ToPage)
                    Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", PrinterDefault))
                    txtCantidadImpresiones.Value = 1
                    Me.Cursor = Cursors.Default
                End If
                LabelStatus.Text = "Listo"
                PrintDialog.Dispose()
            End If




        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvCategoria_Leave(sender As Object, e As EventArgs) Handles DgvCategoria.Leave
        DgvCategoria.Cursor = Cursors.Default
    End Sub

    Private Sub DgvHijos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvHijos.CellEndEdit
        DgvHijos.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvHijos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvHijos.CurrentCellDirtyStateChanged
        If DgvHijos.IsCurrentCellDirty Then
            DgvHijos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub

    Sub FillCbxMedidaPadres()
        Try
            Dim DsTemp As New DataSet

            cbxMedidaActivar.DataSource = Nothing
            cbxMedidaActivar.Items.Clear()

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDPrecios,Medida.Medida FROM libregco.precioarticulo inner join Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida where IDArticulo='" + txtIDProducto.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "precioarticulo")
            cbxMedidaActivar.ValueMember = "IDPrecios"
            cbxMedidaActivar.DisplayMember = "Medida"
            cbxMedidaActivar.DataSource = DsTemp.Tables("precioarticulo")
            ConLibregco.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillCbxMedidaHijos()
        Try
            Dim DsTemp As New DataSet

            cbxMedidaIncluir.DataSource = Nothing
            cbxMedidaIncluir.Items.Clear()

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDPrecios,Medida.Medida FROM libregco.precioarticulo inner join Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida where IDArticulo='" + lblIDArticuloComplementario.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "precioarticulo")
            cbxMedidaIncluir.ValueMember = "IDPrecios"
            cbxMedidaIncluir.DisplayMember = "Medida"
            cbxMedidaIncluir.DataSource = DsTemp.Tables("precioarticulo")
            ConLibregco.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub cbxMedidaActivar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMedidaActivar.SelectedIndexChanged
        cbxMedidaActivar.Tag = cbxMedidaActivar.ValueMember.ToString()
    End Sub

    Private Sub chkEnvioGratis_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnvioGratis.CheckedChanged
        If chkEnvioGratis.Checked = True Then
            chkEnvioGratis.Tag = 1
        Else
            chkEnvioGratis.Tag = 0
        End If
    End Sub

    Private Sub lblIDArticuloComplementario_TextChanged(sender As Object, e As EventArgs) Handles lblIDArticuloComplementario.TextChanged
        If lblIDArticuloComplementario.Text <> "" Then
            FillCbxMedidaHijos()
            GroupBox2.Enabled = True
        Else
            GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub chkNoPagoTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoPagoTarjeta.CheckedChanged
        If chkNoPagoTarjeta.Checked = True Then
            chkNoPagoTarjeta.Tag = 1
        Else
            chkNoPagoTarjeta.Tag = 0
        End If
    End Sub

    Private Sub txtCodigoBarra_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoBarra.TextChanged
        BarCodeControl1.Text = txtCodigoBarra.Text
    End Sub

    Private Sub cbxCobrarComision_CheckedChanged(sender As Object, e As EventArgs) Handles chkCobrarComision.CheckedChanged
        If chkCobrarComision.Checked = True Then
            txtPorcComision.Enabled = True
            chkCobrarComision.Tag = 1
        Else
            txtPorcComision.Enabled = False
            chkCobrarComision.Tag = 0
        End If
    End Sub

    Private Sub chkPermitirModificarPrecio_CheckedChanged(sender As Object, e As EventArgs) Handles chkPermitirModificarPrecio.CheckedChanged
        If chkPermitirModificarPrecio.Checked = True Then
            chkPermitirModificarPrecio.Tag = 1
        Else
            chkPermitirModificarPrecio.Tag = 0
        End If
    End Sub

    Private Sub txtPorcComision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcComision.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtPorcComision_Leave(sender As Object, e As EventArgs) Handles txtPorcComision.Leave
        Try
            If txtPorcComision.Text = "" Then
                txtPorcComision.Text = CDbl(0).ToString("P2")
            Else
                txtPorcComision.Text = (CDbl(txtPorcComision.Text) / 100).ToString("P2")
            End If

        Catch ex As Exception
            txtPorcComision.Text = CDbl(0).ToString("P2")
        End Try
    End Sub

    Private Sub txtPorcComision_Enter(sender As Object, e As EventArgs) Handles txtPorcComision.Enter
        Try
            If txtPorcComision.Text = "" Then
            Else
                txtPorcComision.Text = CDbl(Replace(txtPorcComision.Text, "%", ""))
            End If

        Catch ex As Exception
            txtPorcComision.Text = 0
            txtPorcComision.SelectAll()
        End Try
    End Sub

    Private Sub CbxOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxOrden.SelectedIndexChanged
        If CbxOrden.SelectedIndex = 0 Then
            CbxOrden.Tag = 0
        ElseIf CbxOrden.SelectedIndex = 1 Then
            CbxOrden.Tag = 1
        End If
    End Sub

    Private Sub PColor_Click(sender As Object, e As EventArgs) Handles PColor.Click
        frm_buscar_colores.ShowDialog(Me)
    End Sub

    Private Sub lblColorName_Click(sender As Object, e As EventArgs) Handles lblColorName.Click
        frm_buscar_colores.ShowDialog(Me)
    End Sub

    Private Sub AñadirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AñadirToolStripMenuItem.Click
        ControlParent = 1
        frm_buscar_mant_articulos.lblStatus.Text = "Añadir grupo de artículos / Multiselección activada"
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        If DgvGrupos.Rows.Count > 0 Then
            If CStr(DgvGrupos.CurrentRow.Cells(0).Value) <> "" Then
                If DgvGrupos.CurrentRow.Cells(0).Value <> txtIDProducto.Text Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo del grupo?", "Eliminar artículo de grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        sqlQ = "UPDATE Libregco.Articulos SET IDColectivo=1 WHERE IDArticulo='" + CStr(DgvGrupos.CurrentRow.Cells(0).Value).ToString + "'"

                        ConLibregco.Open()
                        cmd = New MySqlCommand(sqlQ, ConLibregco)
                        cmd.ExecuteNonQuery()
                        ConLibregco.Close()

                        MessageBox.Show("El artículo ha sido eliminado satisfactoriamente del grupo.", "Artículo eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        DgvGrupos.Rows.Remove(DgvGrupos.CurrentRow)

                        DgvGrupos.ClearSelection()
                    End If
                End If


            Else
                DgvGrupos.Rows.Remove(DgvGrupos.CurrentRow)
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        If txtIDGrupo.Tag = 1 Then
            ConLibregco.Open()
            cmd = New MySqlCommand("INSERT INTO Libregco.Articulos_grupos (Colectivo) VALUES ('')", ConLibregco)
            cmd.ExecuteNonQuery()
            cmd = New MySqlCommand("Select IDArticulos_grupos from Articulos_grupos where IDArticulos_grupos= (Select Max(IDArticulos_grupos) from Articulos_grupos)", ConLibregco)
            txtIDGrupo.Tag = Convert.ToDouble(cmd.ExecuteScalar())
            txtIDGrupo.Text = Convert.ToDouble(cmd.ExecuteScalar())

            ConLibregco.Close()
        End If

        ConLibregco.Open()

        cmd = New MySqlCommand("UPDATE Libregco.articulos_grupos SET Colectivo='" + txtGrupoNombre.Text + "',VincularPrecio='" + Convert.ToInt16(chkVincularPrecio.Checked).ToString + "' WHERE idArticulos_grupos= (" + txtIDGrupo.Text + ")", ConLibregco)
        cmd.ExecuteNonQuery()

        cmd = New MySqlCommand("UPDATE Libregco.Articulos SET IDColectivo='" + txtIDGrupo.Text + "' WHERE IDArticulo= (" + txtIDProducto.Text + ")", ConLibregco)
        cmd.ExecuteNonQuery()
        ConLibregco.Close()

        For Each row As DataGridViewRow In DgvGrupos.Rows
            ConLibregco.Open()
            cmd = New MySqlCommand("UPDATE Libregco.Articulos SET IDColectivo='" + txtIDGrupo.Text + "' WHERE IDArticulo= (" + row.Cells(0).Value.ToString + ")", ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()
        Next

        RefrescarTablaColectivos()
    End Sub

    Private Sub btnDuplicar_Click(sender As Object, e As EventArgs) Handles btnDuplicar.Click
        If txtIDProducto.Text = "" Then
            MessageBox.Show("No se ha guardado el producto a la base de datos.", "No se ha insertado el producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else

            ControlParent = 3
            frm_buscar_mant_articulos.ShowDialog(Me)

        End If
    End Sub

    Private Sub PicFotoArticulo_Click(sender As Object, e As EventArgs) Handles PicFotoArticulo.Click
        'If RutaDocumento.Text = "" Then
        TbcProductos.SelectedIndex = 4
        'End If
    End Sub

    Private Sub ToastNotificationsManager1_Activated(sender As Object, e As DevExpress.XtraBars.ToastNotifications.ToastNotificationEventArgs) Handles ToastNotificationsManager1.Activated
        If e.NotificationID.ToString = "ab2d2ce9-aad7-4127-b45c-480398674533" Then
            txtIDMarca.Text = IDMarcaTMP
            txtMarca.Text = MarcaTMP
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkvisualcosto.CheckedChanged
        txtCosto.Visible = chkvisualcosto.Checked
        txtCostoFinal.Visible = chkvisualcosto.Checked
        Label15.Visible = chkvisualcosto.Checked
        Label5.Visible = chkvisualcosto.Checked

        If DgvPrecios.Columns.Count > 0 Then
            DgvPrecios.Columns(4).Visible = chkvisualcosto.Checked
            DgvPrecios.Columns(5).Visible = chkvisualcosto.Checked
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles chkvisualprecioa.CheckedChanged
        txtPrecioA.Visible = chkvisualprecioa.Checked
        Label18.Visible = chkvisualprecioa.Checked
        Label28.Visible = chkvisualprecioa.Checked

        If DgvPrecios.Columns.Count > 0 Then
            DgvPrecios.Columns(7).Visible = chkvisualprecioa.Checked
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles chkvisualpreciob.CheckedChanged
        txtPrecioB.Visible = chkvisualpreciob.Checked
        Label17.Visible = chkvisualpreciob.Checked
        Label27.Visible = chkvisualpreciob.Checked
        Label25.Visible = chkvisualpreciob.Checked

        If DgvPrecios.Columns.Count > 0 Then
            DgvPrecios.Columns(8).Visible = chkvisualpreciob.Checked
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles chkvisualprecioc.CheckedChanged
        txtPrecioC.Visible = chkvisualprecioc.Checked
        Label7.Visible = chkvisualprecioc.Checked

        If DgvPrecios.Columns.Count > 0 Then
            DgvPrecios.Columns(9).Visible = chkvisualprecioc.Checked
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles chkvisualpreciod.CheckedChanged
        txtPrecioD.Visible = chkvisualpreciod.Checked
        Label11.Visible = chkvisualpreciod.Checked

        If DgvPrecios.Columns.Count > 0 Then
            DgvPrecios.Columns(10).Visible = chkvisualpreciod.Checked
        End If
    End Sub

    Private Sub txtDescrip_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescrip.KeyPress
        If Asc(e.KeyChar) = 39 Or Asc(e.KeyChar) = 44 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDescrip_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtDescrip.Validating
        txtDescrip.Text = txtDescrip.Text.Replace(",", "").Replace("'", "")
    End Sub

    Private Sub FillPropiedades()
        Try

            TKPropiedades.Properties.Tokens.Clear()
            TkPropiedadesMain.Properties.Tokens.Clear()

            Dim dstemp As New DataSet

            Con.Open()
            cmd = New MySqlCommand("SELECT idArticulos_propiedad,Propiedad FROM libregco.articulos_propiedad where Nulo=0 and IDParent is not null ORDER BY IDParent ASC,Orden ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "articulos_propiedad")
            Con.Close()

            Dim Tabla As DataTable = dstemp.Tables("articulos_propiedad")

            For Each Fila As DataRow In Tabla.Rows
                Dim Tk As New DevExpress.XtraEditors.TokenEditToken

                Tk.Value = Fila.Item("idArticulos_propiedad")
                Tk.Description = Fila.Item("Propiedad")

                TKPropiedades.Properties.Tokens.Add(Tk)
                TkPropiedadesMain.Properties.Tokens.Add(Tk)
            Next

        Catch ex As Exception

        End Try

    End Sub


    Private Sub TKPropiedades_EditValueChanged(sender As Object, e As EventArgs) Handles TKPropiedades.EditValueChanged
        If txtIDProducto.Text <> "" Then
            If TKPropiedades.EditValue <> "" Then
                'Obtengo los indices de las filas seleccionadas
                Dim words As String() = TKPropiedades.EditValue.Split(New Char() {","c})
                Dim Filas As New ArrayList

                ConMixta.Open()

                For Each word As String In words
                    If word.Trim.ToString <> "" Then
                        Filas.Add(word.Replace(",", "").Trim)
                        cmd = New MySqlCommand("SELECT count(idArticulos_has_propiedad) FROM libregco.articulos_has_propiedad where IDArticulo='" + txtIDProducto.Text + "' AND IDPropiedad_propiedad='" + word.Trim.ToString + "'", ConMixta)
                        If Convert.ToInt16(cmd.ExecuteScalar()) = 0 Then
                            cmd = New MySqlCommand("INSERT INTO Libregco.articulos_has_propiedad (IDPropiedad_propiedad,IDArticulo) VALUES ('" + word.Trim.ToString + "','" + txtIDProducto.Text + "')", ConMixta)
                            cmd.ExecuteNonQuery()
                        End If
                    End If
                Next

                cmd = New MySqlCommand("SELECT coalesce(group_concat(IDPropiedad_propiedad separator ', '),'') FROM libregco.articulos_has_propiedad WHERE Articulos_has_propiedad.IDArticulo='" + txtIDProducto.Text + "'", ConMixta)
                TkPropiedadesMain.EditValue = Convert.ToString(cmd.ExecuteScalar())

                ConMixta.Close()


                TreeView1.CollapseAll()
                ChangingfromTreeview = False
                ChangeAllNodes(False, TreeView1)

                For Each st As String In Filas
                    Dim nodes As TreeNode() = TreeView1.Nodes.Find(st, True)
                    If nodes.Length > 0 Then
                        nodes(0).Checked = True
                    End If
                Next


                For Each nd As TreeNode In TreeView1.Nodes
                    For Each nt As TreeNode In nd.Nodes     'As Hijos
                        For Each nc As TreeNode In nt.Nodes
                            If nc.Checked = True Then
                                nc.Expand()
                                nt.Expand()
                                nd.Expand()
                                Exit For
                            End If
                        Next
                        If nt.Checked = True Then
                            nt.Expand()
                            nd.Expand()
                            Exit For
                        End If
                    Next
                Next

            Else

                TreeView1.CollapseAll()
            End If

            RefrescarVGridPropiedades()
        End If


    End Sub

    Private Sub ChangeAllNodes(ByVal State As Boolean, ByVal TreeViewlist As TreeView)
        For Each mTN As TreeNode In TreeViewlist.Nodes
            CheckAll(mTN, State)
        Next
    End Sub

    Private Sub CheckAll(ByVal MyTreeNode As TreeNode, ByVal Optional CheckAll_YesNo As Boolean = True)
        For Each mTN As TreeNode In MyTreeNode.Nodes
            CheckAll(mTN, CheckAll_YesNo)
            mTN.Checked = CheckAll_YesNo
        Next
    End Sub

    Private Sub ShowCheckedNodes()
        If TKPropiedades.EditValue <> "" Then
            ChangingfromTreeview = False
            ChangeAllNodes(False, TreeView1)

            Dim words As String() = TKPropiedades.EditValue.Split(New Char() {" "c})
            Dim Filas As New ArrayList
            For Each word As String In words
                Filas.Add(word.Replace(",", "").Trim)
            Next

            For Each st As String In Filas
                Dim nodes As TreeNode() = TreeView1.Nodes.Find(st, True)
                If nodes.Length > 0 Then
                    nodes(0).Checked = True
                End If
            Next


            TreeView1.CollapseAll()
            For Each nd As TreeNode In TreeView1.Nodes
                For Each nt As TreeNode In nd.Nodes     'As Hijos
                    For Each nc As TreeNode In nt.Nodes
                        If nc.Checked = True Then
                            nc.Expand()
                            nt.Expand()
                            nd.Expand()
                            Exit For
                        End If
                    Next
                    If nt.Checked = True Then
                        nt.Expand()
                        nd.Expand()
                        Exit For
                    End If
                Next
            Next

        Else
            TreeView1.CollapseAll()
        End If
    End Sub

    Private Sub TkPropiedadesMain_Click(sender As Object, e As EventArgs) Handles TkPropiedadesMain.Click
        If txtIDProducto.Text <> "" Then
            TbcProductos.SelectedIndex = 3
        End If

    End Sub

    Private Sub chkIncluirPrecioComplementario_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluirPrecioComplementario.CheckedChanged
        If chkIncluirPrecioComplementario.Checked = True Then
            cbxNivelPrecioComplementario.Enabled = False
        Else
            cbxNivelPrecioComplementario.Enabled = True
        End If
    End Sub

    Private Sub chkLimitarVidaComplementario_CheckedChanged(sender As Object, e As EventArgs) Handles chkLimitarVidaComplementario.CheckedChanged
        If chkLimitarVidaComplementario.Checked = True Then
            dtpFechaVidaComplementario.Enabled = False
        Else
            dtpFechaVidaComplementario.Enabled = True
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If lblIDArticuloComplementario.Text <> "" Then
            DgvHijos.Rows.Add(lblArticuloHijo.Text, cbxMedidaActivar.SelectedValue.ToString, txtCantParaActivar.Value, cbxMedidaActivar.Text, lblIDArticuloComplementario.Text, lblArticuloComplementario.Text, lblReferenciaComplementario.Text, txtCantidadIncluirComplementario.Value, cbxMedidaIncluir.SelectedValue.ToString, cbxMedidaIncluir.Text, chkLimitarVidaComplementario.CheckState, dtpFechaVidaComplementario.Value.ToString("dd/MM/yyyy"), chkIncluirPrecioComplementario.CheckState, cbxNivelPrecioComplementario.Text, txtPrecioComplementario.Text, chkNuloComplementario.CheckState)

            lblIDArticuloComplementario.Text = ""
            lblArticuloComplementario.Text = ""
            lblReferenciaComplementario.Text = ""
            txtCantidadIncluirComplementario.Value = 1
            txtCantParaActivar.Value = 1
            cbxMedidaIncluir.DataSource = Nothing
            cbxMedidaIncluir.Items.Clear()
            chkIncluirPrecioComplementario.Checked = False
            cbxNivelPrecioComplementario.Text = "A"
            txtPrecioComplementario.Clear()
            chkLimitarVidaComplementario.Checked = False
            dtpFechaVidaComplementario.Value = Today
            chkNuloComplementario.Checked = False
        End If

    End Sub

    Private Sub cbxMedidaIncluir_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMedidaIncluir.SelectedIndexChanged
        If cbxNivelPrecioComplementario.Text <> "" Then
            If cbxMedidaIncluir.Text <> "" Then
                txtPrecioComplementario.Text = CDbl(GetPricesWithIDPrecio(cbxNivelPrecioComplementario.Text, cbxMedidaIncluir.SelectedValue.ToString, cbxMonedaComplementario.EditValue)).ToString("C")
            End If
        End If

    End Sub

    Private Sub cbxNivelPrecioComplementario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNivelPrecioComplementario.SelectedIndexChanged
        If cbxNivelPrecioComplementario.Text <> "" Then
            If cbxMedidaIncluir.Text <> "" Then

                txtPrecioComplementario.Text = CDbl(GetPricesWithIDPrecio(cbxNivelPrecioComplementario.Text, cbxMedidaIncluir.SelectedValue.ToString, cbxMonedaComplementario.EditValue)).ToString("C")
            End If
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If DgvHijos.Rows.Count > 0 Then
            If DgvHijos.SelectedRows.Count > 0 Then
                lblArticuloHijo.Text = DgvHijos.CurrentRow.Cells(0).Value
                txtCantParaActivar.Value = DgvHijos.CurrentRow.Cells(2).Value
                cbxMedidaActivar.Text = DgvHijos.CurrentRow.Cells(3).Value
                lblIDArticuloComplementario.Text = DgvHijos.CurrentRow.Cells(4).Value
                lblArticuloComplementario.Text = DgvHijos.CurrentRow.Cells(5).Value
                lblReferenciaComplementario.Text = DgvHijos.CurrentRow.Cells(6).Value
                txtCantidadIncluirComplementario.Value = DgvHijos.CurrentRow.Cells(7).Value

                cbxMedidaIncluir.Text = DgvHijos.CurrentRow.Cells(9).Value
                chkLimitarVidaComplementario.Checked = DgvHijos.CurrentRow.Cells(10).Value
                dtpFechaVidaComplementario.Value = DgvHijos.CurrentRow.Cells(11).Value

                chkIncluirPrecioComplementario.Checked = DgvHijos.CurrentRow.Cells(12).Value
                cbxNivelPrecioComplementario.Text = DgvHijos.CurrentRow.Cells(13).Value
                txtPrecioComplementario.Text = DgvHijos.CurrentRow.Cells(14).Value
                chkNuloComplementario.Checked = DgvHijos.CurrentRow.Cells(15).Value

                DgvHijos.Rows.Remove(DgvHijos.CurrentRow)

            End If
        End If
    End Sub

    Sub FillAllDatafromID()
        Dim DsTemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDArticulo,Articulos.Descripcion,Referencia,IDTipoProducto,TipoArticulo,Articulos.IDSuplidor,Suplidor,Articulos.IDDepartamento,Departamento,Articulos.IDItbis,Tipo,Articulos.IDCategoria,Categoria,Articulos.IDSubCategoria,SubCategoria,Articulos.IDMarca,Marca,IDGarantia,TiempoGarantia,CodigoBarra,Serial,Promocion,Devolucion,VenderCosto,Descontinuar,NoPagoTarjeta,BloqueoCredito,PreAlertar,Revisado,ExistenciaMin,ExistenciaMax,ExistenciaTotal,Articulos.RutaFoto,Articulos.Desactivar,Articulos.IDParentesco,ParentescoProducto.Descripcion as Parentesco,CobrarComision,PorcentajeComision,NoPermitirCambiarPrecio,OrdenPrecios,Articulos.IDColor,Color.Color,Color.BigColorPath,Articulos.IDColectivo,BloquearModificacionPrecio,ServicioPersonalizable,(SELECT coalesce(group_concat(IDPropiedad_propiedad separator ', '),'') FROM libregco.articulos_has_propiedad inner join libregco.articulos_propiedad on articulos_has_propiedad.IDPropiedad_propiedad=articulos_propiedad.idArticulos_propiedad  WHERE Articulos_has_propiedad.IDArticulo=Articulos.IDArticulo) as Propiedades FROM articulos INNER JOIN TipoArticulo on Articulos.IDTipoProducto=TipoArticulo.IDTipoArticulo INNER JOIN Suplidor on Articulos.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Departamentos on Articulos.IDDepartamento=Departamentos.IDDepartamento INNER JOIN TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis INNER JOIN Categoria on Articulos.IDCategoria=Categoria.IDCategoria INNER JOIN SubCategoria on Articulos.IDSubCategoria=SubCategoria.IDSubCategoria INNER JOIN Marca on Articulos.IDMarca=Marca.IDMarca INNER JOIN Garantiaarticulos ON Articulos.IDGarantia=GarantiaArticulos.IDGarantiaArticulos INNER JOIN Libregco.ParentescoProducto on Articulos.IDParentesco=ParentescoProducto.IDParentesco INNER JOIN Libregco.Color on Articulos.IDColor=Color.IDColor Where IDArticulo='" + txtIDProducto.Text + "'", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "Articulos")
        ConLibregco.Close()

        Dim Tabla As DataTable = DsTemp.Tables("Articulos")

        LimpiarPrecios()
        TbcProductos.SelectedIndex = 0
        TabControl3.SelectedIndex = 0
        TabControl4.SelectedIndex = 0
        XtraTabControl1.SelectedTabPageIndex = 0
        TabControl2.SelectedIndex = 0
        TabControl1.SelectedIndex = 0
        QrCode.Visible = True
        QrCode.Text = (Tabla.Rows(0).Item("IDArticulo"))
        txtIDProducto.Text = (Tabla.Rows(0).Item("IDArticulo"))
        txtDescrip.Text = (Tabla.Rows(0).Item("Descripcion"))
        txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
        txtIDTipoArticulo.Text = (Tabla.Rows(0).Item("IDTipoProducto"))
        txtTipoArticulo.Text = (Tabla.Rows(0).Item("TipoArticulo"))
        txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
        txtSuplidor.Text = (Tabla.Rows(0).Item("Suplidor"))
        txtIDDepartamento.Text = (Tabla.Rows(0).Item("IDDepartamento"))
        txtDepartamento.Text = (Tabla.Rows(0).Item("Departamento"))
        txtIDItbis.Text = (Tabla.Rows(0).Item("IDItbis"))
        txtItbis.Text = (Tabla.Rows(0).Item("Tipo"))
        txtIDCategoria.Text = (Tabla.Rows(0).Item("IDCategoria"))
        txtCategoria.Text = (Tabla.Rows(0).Item("Categoria"))
        txtIDSubCategoria.Text = (Tabla.Rows(0).Item("IDSubCategoria"))
        txtSubCategoria.Text = (Tabla.Rows(0).Item("SubCategoria"))
        txtIDMarca.Text = (Tabla.Rows(0).Item("IDMarca"))
        txtMarca.Text = (Tabla.Rows(0).Item("Marca"))
        txtIDGarantia.Text = (Tabla.Rows(0).Item("IDGarantia"))
        txtTipoGarantia.Text = (Tabla.Rows(0).Item("TiempoGarantia"))
        txtIDParentesco.Text = (Tabla.Rows(0).Item("IDParentesco"))
        txtParentesco.Text = (Tabla.Rows(0).Item("Parentesco"))
        txtCodigoBarra.Text = (Tabla.Rows(0).Item("CodigoBarra"))
        txtStockMin.Text = (Tabla.Rows(0).Item("ExistenciaMin"))
        txtStockMax.Text = (Tabla.Rows(0).Item("ExistenciaMax"))
        txtStockActual.Text = (Tabla.Rows(0).Item("ExistenciaTotal"))
        lblColorName.Text = (Tabla.Rows(0).Item("Color"))
        PColor.Tag = (Tabla.Rows(0).Item("IDColor"))
        txtIDGrupo.Tag = Tabla.Rows(0).Item("IDColectivo")
        TKPropiedades.EditValue = Tabla.Rows(0).Item("Propiedades")
        TkPropiedadesMain.EditValue = Tabla.Rows(0).Item("Propiedades")
        chkServicioPersonalizable.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("ServicioPersonalizable"))
        chk_ConSerial.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Serial"))
        chkPromocion.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Promocion"))
        chkDevolucion.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Devolucion"))
        chkVenderCosto.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("VenderCosto"))
        chkDescontinuar.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Descontinuar"))
        chkDesactivar.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Desactivar"))
        chkBloqueoCredito.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("BloqueoCredito"))
        chkPreAlertar.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("PreAlertar"))
        ChkRevisado.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Revisado"))
        chkNoPagoTarjeta.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("NoPagoTarjeta"))
        chkCobrarComision.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("CobrarComision"))
        chkBloquearModificacion.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("BloquearModificacionPrecio"))
        chkPermitirModificarPrecio.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("NoPermitirCambiarPrecio"))
        txtPorcComision.Text = (CDbl(Tabla.Rows(0).Item("PorcentajeComision")) / 100).ToString("P2")

        If txtIDGrupo.Tag = 1 Then
            txtIDGrupo.Text = "[ Disponible ]"
        Else
            txtIDGrupo.Text = txtIDGrupo.Tag.ToString
        End If

        FillSubColors()

        If (Tabla.Rows(0).Item("RutaFoto")) = "" Then
            PicFotoArticulo.Image = My.Resources.No_Image
        Else
            If TypeConnection.Text = 1 Then
                If (File.Exists(Tabla.Rows(0).Item("RutaFoto"))) Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream((Tabla.Rows(0).Item("RutaFoto")), FileMode.Open, FileAccess.Read)
                    PicFotoArticulo.Image = System.Drawing.Image.FromStream(wFile)
                    RutaDocumento.Text = (Tabla.Rows(0).Item("RutaFoto"))
                    wFile.Close()
                    PicFotoArticulo.BackColor = Color.White
                Else
                    MessageBox.Show("Se ha detectado una ruta de imagen en el archivo. Sin embargo, la foto no existe." & vbNewLine & vbNewLine & "Por favor revise la foto anexa o guarde una nueva para evitar futuros errores.", "No se encontró imagen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                RutaDocumento.Text = (Tabla.Rows(0).Item("RutaFoto"))
            End If
        End If

        If (Tabla.Rows(0).Item("OrdenPrecios")) = 0 Then
            CbxOrden.SelectedIndex = 0
        Else
            CbxOrden.SelectedIndex = 1
        End If

        RefrescarTablaPrecios()
        RefrescarTablaImagenes()
        RefrescarDgvEspecifaciones()
        CargarExistenciasTreeView()
        CargarHijos()
        RefrescarTablaSimilares()
        RefrescarTablaColectivos()
        RefrescarTablaHistorialPrecios()
        FillCbxMedidaPadres()
        RefrescarTablaPreguntas()
        RefrescarVGridPropiedades
    End Sub


    Sub RefrescarVGridPropiedades()

        VGridControl1.Rows.Clear()


        ConLibregco.Open()
        Ds.Clear()
        cmd = New MySqlCommand("SELECT idArticulos_has_propiedad,IDPropiedad_propiedad,Propiedad,IDParent,if((Select IDParent from Libregco.Articulos_Propiedad Where idArticulos_propiedad=PropiedadesUnitarias.IDParent) is null,(Select Propiedad from Libregco.Articulos_Propiedad Where idArticulos_propiedad=PropiedadesUnitarias.IDParent),(Select Propiedad from Libregco.articulos_propiedad WHERE idArticulos_propiedad=(Select IDParent from Libregco.Articulos_Propiedad Where idArticulos_propiedad=PropiedadesUnitarias.IDParent))) as IDParentParent,Nulo,Orden FROM libregco.articulos_has_propiedad INNER JOIN Libregco.articulos_propiedad as PropiedadesUnitarias on articulos_has_propiedad.IDPropiedad_propiedad=PropiedadesUnitarias.idArticulos_propiedad WHERE articulos_has_propiedad.IDArticulo='" + txtIDProducto.Text + "' ORDER BY Orden ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Propiedades")
        ConLibregco.Close()

        Dim TablaPropiedades As DataTable = Ds.Tables("Propiedades")

        Dim rHeader As New XtraVerticalGrid.Rows.EditorRow
        rHeader.Properties.UnboundType = DevExpress.Data.UnboundColumnType.String
        rHeader.Properties.Caption = " "
        rHeader.Properties.Value = " "


        For Each dt As DataRow In TablaPropiedades.Rows
            Dim rw As New XtraVerticalGrid.Rows.EditorRow

            rw.Properties.UnboundType = DevExpress.Data.UnboundColumnType.String
            rw.Properties.Caption = dt.Item("IDParentParent")
            rw.Properties.Value = dt.Item("Propiedad")

            VGridControl1.Rows.Add(rw)
        Next

    End Sub
    Sub RefrescarTablaPreguntas()
        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
            Using myCommand As MySqlCommand = New MySqlCommand("SELECT * FROM libregco.articulos_preguntas where IDArticulo='" + txtIDProducto.Text + "' and Articulos_preguntas.Nulo=0", ConMixta)
                ConMixta.Open()

                Using myReader As MySqlDataReader = myCommand.ExecuteReader

                    TablaQuestions.Load(myReader, LoadOption.Upsert)

                    ConMixta.Close()

                End Using
            End Using
        End Using
    End Sub
    Private Sub txtCosto_Enter(sender As Object, e As EventArgs) Handles txtCosto.Enter
        SplitContainer3.Panel1Collapsed = False
        lblMensajePrecio.Text = "{Para realizar cálculos directos presione la tecla F4 para abrir o cerrar la calculadora}"
    End Sub

    Private Sub CalcEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCosto.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCosto.IsPopupOpen = False Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtCosto.SelectionStart = CStr(txtCosto.Value).Length Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Left Then
            If txtCosto.SelectionStart = 0 Then
                e.Handled = True
                txtContenido.Focus()
                txtContenido.SelectAll()
            End If
        End If
    End Sub

    Private Sub txtContenido_Enter_1(sender As Object, e As EventArgs) Handles txtContenido.Enter
        SplitContainer3.Panel1Collapsed = False
        lblMensajePrecio.Text = "El contenido define la cantidad de un producto respecto a su medida. Ejemplo: La medida 'millar' posee 1000 (mil) unidades."
    End Sub

    Private Sub txtCostoFinal_Enter_1(sender As Object, e As EventArgs) Handles txtCostoFinal.Enter
        SplitContainer3.Panel1Collapsed = False
        lblMensajePrecio.Text = "{Para realizar cálculos directos presione la tecla F4 para abrir o cerrar la calculadora}"

        If CDbl(txtCostoFinal.Value) = 0 Then
            txtCostoFinal.Value = txtCosto.Value
        End If

    End Sub

    Private Sub txtDescMax_Enter(sender As Object, e As EventArgs) Handles txtDescMax.Enter
        If txtDescMax.EditValue = 0 Then
            SplitContainer3.Panel1Collapsed = False
            lblMensajePrecio.Text = "El descuento máximo es el total autorizado para rebajar al producto en facturación con los precios A y B." & vbNewLine & "Exprese el porcentaje de descuento que puede aplicarse al producto."
        Else
            SplitContainer3.Panel1Collapsed = True
            lblMensajePrecio.Text = ""
        End If
    End Sub

    Private Sub txtPrecioA_Enter(sender As Object, e As EventArgs) Handles txtPrecioA.Enter
        SplitContainer3.Panel1Collapsed = False
        lblMensajePrecio.Text = "{Para realizar cálculos directos presione la tecla F4 para abrir o cerrar la calculadora}"
    End Sub

    Private Sub txtPrecioB_Enter(sender As Object, e As EventArgs) Handles txtPrecioB.Enter
        SplitContainer3.Panel1Collapsed = False
        lblMensajePrecio.Text = "{Para realizar cálculos directos presione la tecla F4 para abrir o cerrar la calculadora}"
    End Sub

    Private Sub txtPrecioC_Enter(sender As Object, e As EventArgs) Handles txtPrecioC.Enter
        SplitContainer3.Panel1Collapsed = False
        lblMensajePrecio.Text = "{Para realizar cálculos directos presione la tecla F4 para abrir o cerrar la calculadora}"
    End Sub

    Private Sub txtPrecioD_Enter(sender As Object, e As EventArgs) Handles txtPrecioD.Enter
        SplitContainer3.Panel1Collapsed = False
        lblMensajePrecio.Text = "{Para realizar cálculos directos presione la tecla F4 para abrir o cerrar la calculadora}"
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ControlParent = 4
        frm_buscar_mant_articulos.lblStatus.Text = "Duplicado de propiedades."
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Private Sub txtDescMax_EditValueChanged(sender As Object, e As EventArgs) Handles txtDescMax.EditValueChanged
        Try
            If txtDescMax.EditValue > 0 Then
                MinPrecioA.Text = CDbl(CDbl(txtPrecioA.Value) - (CDbl(txtPrecioA.Value) * CDbl(txtDescMax.EditValue))).ToString("C")
                MinPrecioB.Text = CDbl(CDbl(txtPrecioB.Value) - (CDbl(txtPrecioB.Value) * CDbl(txtDescMax.EditValue))).ToString("C")
                SplitContainer2.SplitterDistance = 60
            Else
                MinPrecioA.Text = CDbl(0).ToString("C")
                MinPrecioB.Text = CDbl(0).ToString("C")
                SplitContainer2.SplitterDistance = 42
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtPrecioA_TextChanged(sender As Object, e As EventArgs) Handles txtPrecioA.TextChanged
        If IsNumeric(txtPrecioA.EditValue) Then
            If IsNumeric(txtDescMax.EditValue) Then
                MinPrecioA.Text = CDbl(CDbl(txtPrecioA.Value) - (CDbl(txtPrecioA.Value) * CDbl(txtDescMax.EditValue))).ToString("C")
                If txtDescMax.EditValue > 0 Then
                    SplitContainer2.SplitterDistance = 60
                End If
            Else
                MinPrecioA.Text = CDbl(0).ToString("C")
                SplitContainer2.SplitterDistance = 42
            End If
        End If
    End Sub

    Private Sub DgvPrecios_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPrecios.CellValueChanged
        If e.RowIndex >= 0 Then
            'Try
            If e.ColumnIndex = 15 Then
                If CDbl(DgvPrecios.CurrentRow.Cells(14).Value) = 1 Then
                    If IsNumeric(DgvPrecios.CurrentRow.Cells(15).Value) Then
                        If CDbl(DgvPrecios.CurrentRow.Cells(15).Value) <> 0 Then
                            Dim dstemp As New DataSet

                            Con.Open()
                            cmd = New MySqlCommand("SELECT IDPrecios,PrecioArticulo.IDMedida,Medida.Medida,Abreviatura,Contenido,Costo,CostoFinal,DescuentoMaximo,PrecioCredito,PrecioContado,Precio3,Precio4,Nulo,CostoClave,PrecioBlackFriday,TipoMedida,Piezaje,PrecioAMedida,PrecioBMedida,PrecioCMedida,PrecioDMedida,CostoMedida,MedidaDinamica FROM Libregco.precioarticulo INNER JOIN Libregco.medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrecioArticulo.IDPrecios='" + DgvPrecios.CurrentRow.Cells(0).Value.ToString + "'", Con)
                            Adaptador = New MySqlDataAdapter(cmd)
                            Adaptador.Fill(dstemp, "Precios")
                            Con.Close()

                            Dim TablaMedida As DataTable = dstemp.Tables("Precios")

                            If TablaMedida.Rows.Count > 0 Then

                                DgvPrecios.CurrentRow.Cells(4).Value = CDbl(CDbl(TablaMedida.Rows(0).Item("CostoMedida")) * CDbl(DgvPrecios.CurrentRow.Cells(15).Value)).ToString("C")
                                DgvPrecios.CurrentRow.Cells(5).Value = CDbl(CDbl(TablaMedida.Rows(0).Item("CostoMedida")) * CDbl(DgvPrecios.CurrentRow.Cells(15).Value)).ToString("C")
                                DgvPrecios.CurrentRow.Cells(7).Value = CDbl(CDbl(TablaMedida.Rows(0).Item("PrecioAMedida")) * CDbl(DgvPrecios.CurrentRow.Cells(15).Value)).ToString("C")
                                DgvPrecios.CurrentRow.Cells(8).Value = CDbl(CDbl(TablaMedida.Rows(0).Item("PrecioBMedida")) * CDbl(DgvPrecios.CurrentRow.Cells(15).Value)).ToString("C")
                                DgvPrecios.CurrentRow.Cells(9).Value = CDbl(CDbl(TablaMedida.Rows(0).Item("PrecioCMedida")) * CDbl(DgvPrecios.CurrentRow.Cells(15).Value)).ToString("C")
                                DgvPrecios.CurrentRow.Cells(10).Value = CDbl(CDbl(TablaMedida.Rows(0).Item("PrecioDMedida")) * CDbl(DgvPrecios.CurrentRow.Cells(15).Value)).ToString("C")
                                DgvPrecios.CurrentRow.Cells(12).Value = ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(CDbl(CDbl(TablaMedida.Rows(0).Item("CostoMedida")) * CDbl(DgvPrecios.CurrentRow.Cells(15).Value)))).ToString()

                                Con.Open()
                                CheckedUptadesinPrinces(DgvPrecios.CurrentRow.Cells(0).Value.ToString, CDbl(DgvPrecios.CurrentRow.Cells(4).Value).ToString, CDbl(DgvPrecios.CurrentRow.Cells(5).Value).ToString, CDbl(DgvPrecios.CurrentRow.Cells(7).Value).ToString, CDbl(DgvPrecios.CurrentRow.Cells(8).Value).ToString, CDbl(DgvPrecios.CurrentRow.Cells(9).Value).ToString, CDbl(DgvPrecios.CurrentRow.Cells(10).Value).ToString, CDbl(DgvPrecios.CurrentRow.Cells(13).Value).ToString, CDbl(DgvPrecios.CurrentRow.Cells(3).Value).ToString, DgvPrecios.CurrentRow.Cells(2).Value.ToString)

                                sqlQ = "UPDATE Libregco.PrecioArticulo SET Costo='" + CDbl(DgvPrecios.CurrentRow.Cells(4).Value).ToString + "',CostoFinal='" + CDbl(DgvPrecios.CurrentRow.Cells(5).Value).ToString + "',PrecioContado='" + CDbl(DgvPrecios.CurrentRow.Cells(8).Value).ToString + "',PrecioCredito='" + CDbl(DgvPrecios.CurrentRow.Cells(7).Value).ToString + "',Precio3='" + CDbl(DgvPrecios.CurrentRow.Cells(8).Value).ToString + "',Precio4='" + CDbl(DgvPrecios.CurrentRow.Cells(9).Value).ToString + "',DescuentoMaximo='" + CDbl(0).ToString + "',CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(DgvPrecios.CurrentRow.Cells(4).Value)).ToString + "',Piezaje='" + DgvPrecios.CurrentRow.Cells(15).Value.ToString + "' WHERE IDPrecios='" + DgvPrecios.CurrentRow.Cells(0).Value.ToString + "'"
                                cmd = New MySqlCommand(sqlQ, Con)
                                cmd.ExecuteNonQuery()

                                UpdateLastUpdatePrices(DgvPrecios.CurrentRow.Cells(0).Value.ToString)
                                Con.Close()

                                dstemp.Dispose()
                                TablaMedida.Dispose()

                                RefrescarTablaHistorialPrecios()
                            End If
                        End If


                    Else
                        DgvPrecios.CurrentRow.Cells(15).Value = 0
                    End If

                Else
                    DgvPrecios.CurrentRow.Cells(15).Value = 0
                End If

            End If

            'Catch ex As Exception
            '    DgvPrecios.CurrentRow.Cells(15).Value = 0
            'End Try

        End If
    End Sub

    Private Sub DgvPrecios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPrecios.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 15 Then
                DgvPrecios.EditMode = DataGridViewEditMode.EditOnEnter
            End If
        End If
    End Sub

    Private Sub txtPreciob_TextChanged(sender As Object, e As EventArgs) Handles txtPrecioB.TextChanged
        If IsNumeric(txtPrecioB.EditValue) Then
            If IsNumeric(txtDescMax.EditValue) Then
                MinPrecioB.Text = CDbl(CDbl(txtPrecioB.Value) - (CDbl(txtPrecioB.Value) * CDbl(txtDescMax.EditValue))).ToString("C")
                If txtDescMax.EditValue > 0 Then
                    SplitContainer2.SplitterDistance = 60
                End If
            Else
                MinPrecioB.Text = CDbl(0).ToString("C")
                SplitContainer2.SplitterDistance = 42
            End If
        End If
    End Sub

    Private Sub ImprimirToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem2.Click
        If txtIDProducto.Text <> "" Then
            If frm_reporte_etiquetas_productos.Visible = True Then
                frm_reporte_etiquetas_productos.Close()
            End If

            frm_reporte_etiquetas_productos.Show(Me)
            frm_reporte_etiquetas_productos.txtIDArticulo.Text = txtIDProducto.Text
            frm_reporte_etiquetas_productos.txtCantidad.Value = 1
            frm_reporte_etiquetas_productos.txtArticulo.Text = txtDescrip.Text
            frm_reporte_etiquetas_productos.FillMedida()
            frm_reporte_etiquetas_productos.btnBuscar.PerformClick()
        End If

    End Sub

    Private Sub TreeView1_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCheck
        Try
            If txtIDProducto.Text <> "" Then
                If ChangingfromTreeview = True Then

                    If e.Node.Checked = True Then

                        'Si es padre no hago nada
                        ConLibregco.Open()
                        cmd = New MySqlCommand("SELECT coalesce(IDParent,0) FROM libregco.articulos_propiedad where idArticulos_propiedad='" + e.Node.Name + "'", ConLibregco)
                        Dim isParent As Int16 = Convert.ToInt16(cmd.ExecuteScalar())
                        ConLibregco.Close()

                        If isParent = 0 Then
                            Exit Sub
                        Else

                            ''Verificar si exist la propiedad ya vinculada
                            Dim words As String() = TKPropiedades.EditValue.Split(New Char() {" "c})
                            Dim Filas As New ArrayList
                            For Each word As String In words
                                Filas.Add(word.Replace(",", "").Trim)
                            Next
                            If Not Filas.Contains(e.Node.Name) Then
                                'Adjuntar la propiedad del treeview
                                Filas.Add(e.Node.Name)

                                Dim ob As Object
                                If TKPropiedades.EditValue.ToString = "" Then
                                    ob = e.Node.Name
                                Else
                                    ob = TKPropiedades.EditValue & ", " & e.Node.Name
                                End If
                                TKPropiedades.EditValue = ob
                                TkPropiedadesMain.EditValue = ob

                                ConLibregco.Open()
                                For Each itm As String In Filas
                                    If itm.Trim <> "" Then
                                        cmd = New MySqlCommand("SELECT count(idArticulos_has_propiedad) FROM libregco.articulos_has_propiedad where IDArticulo='" + txtIDProducto.Text + "' AND IDPropiedad_propiedad='" + itm + "'", ConLibregco)
                                        If Convert.ToInt16(cmd.ExecuteScalar()) = 0 Then
                                            cmd = New MySqlCommand("INSERT INTO articulos_has_propiedad (IDPropiedad_propiedad,IDArticulo) VALUES ('" + itm + "','" + txtIDProducto.Text + "')", ConLibregco)
                                            cmd.ExecuteNonQuery()
                                        End If
                                    End If
                                Next
                                ConLibregco.Close()
                            End If



                        End If

                    Else
                        'Eliminando al checked = false

                        If txtIDProducto.Text <> "" Then
                            Dim words As String() = TKPropiedades.EditValue.Split(New Char() {" "c})
                            Dim Filas As New ArrayList
                            For Each word As String In words
                                Filas.Add(word.Replace(",", "").Trim)
                            Next

                            If Filas.Contains(e.Node.Name) Then
                                Filas.Remove(e.Node.Name)

                                ConLibregco.Open()
                                cmd = New MySqlCommand("SELECT COALESCE(idArticulos_has_propiedad,0) FROM libregco.articulos_has_propiedad where IDArticulo='" + txtIDProducto.Text + "' AND IDPropiedad_propiedad='" + e.Node.Name + "'", ConLibregco)
                                Dim IDhasPropiedad As Integer = Convert.ToInt16(cmd.ExecuteScalar())
                                If IDhasPropiedad <> 0 Then
                                    cmd = New MySqlCommand("Delete FROM articulos_has_propiedad WHERE idArticulos_has_propiedad='" + IDhasPropiedad.ToString + "'", ConLibregco)
                                    cmd.ExecuteNonQuery()
                                End If
                                ConLibregco.Close()

                                Dim nuevostoken As Object = String.Join(", ", Filas.ToArray)
                                TKPropiedades.EditValue = nuevostoken
                                TkPropiedadesMain.EditValue = nuevostoken
                            End If
                        End If

                    End If
                End If


                RefrescarVGridPropiedades()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TreeView1_MouseHover(sender As Object, e As EventArgs) Handles TreeView1.MouseHover
        ChangingfromTreeview = True

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        GetInformation()
    End Sub

    Private Sub Chart1_DoubleClick(sender As Object, e As EventArgs) Handles Chart1.DoubleClick
        'Dim TmpForm As New frm_preview_chart
        'Dim SampleChart As New Chart
        'SampleChart.Palette = Chart1.Palette

        'SampleChart.ChartAreas.Clear()
        'SampleChart.Legends.Clear()
        'SampleChart.Series.Clear()

        ''For i As Integer = 0 To Chart1.ChartAreas.Count - 1
        ''    SampleChart.ChartAreas.Add(Chart1.ChartAreas(i))
        ''Next
        ''For o As Integer = 0 To Chart1.Legends.Count - 1
        ''    SampleChart.Legends.Add(Chart1.Legends(o))
        ''Next
        'For a As Integer = 0 To Chart1.Series.Count - 1
        '    SampleChart.Series.Add(Chart1.Series(a))
        'Next


        'TmpForm.Controls.Add(SampleChart)
        '''''''''''''''''''''''''''''''''''''''''

        'SampleChart.Dock = DockStyle.Fill

        'TmpForm.Show()
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        Dim WebDoc As New frm_webbrowser_preview
        WebDoc.Show()

        Dim html As String = DgvGarantiaProductos.CurrentRow.Cells(1).Value
        WebDoc.WebBrowser1.DocumentText = html
    End Sub

    Private Sub DgvGarantiaProductos_SelectionChanged(sender As Object, e As EventArgs) Handles DgvGarantiaProductos.SelectionChanged
        If DgvGarantiaProductos.Rows.Count > 0 Then
            If DgvGarantiaProductos.CurrentRow.Cells(2).Value = 1 Then
                PreviewToolStripMenuItem.Visible = True
            Else
                PreviewToolStripMenuItem.Visible = False
            End If
        End If
    End Sub

    Private Sub DgvSubCategoria_SelectionChanged(sender As Object, e As EventArgs) Handles DgvSubCategoria.SelectionChanged
        If DgvSubCategoria.Rows.Count > 0 Then
            If DgvSubCategoria.CurrentRow.Cells(2).Value = 1 Then
                HTMLToolStripMenuItem.Visible = True
            Else
                HTMLToolStripMenuItem.Visible = False
            End If
        End If
    End Sub

    Private Sub DgvCategoria_SelectionChanged(sender As Object, e As EventArgs) Handles DgvCategoria.SelectionChanged
        If DgvCategoria.Rows.Count > 0 Then
            If DgvCategoria.CurrentRow.Cells(2).Value = 1 Then
                HTMLToolStripMenuItem1.Visible = True
            Else
                HTMLToolStripMenuItem1.Visible = False
            End If
        End If
    End Sub


    Private Sub HTMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTMLToolStripMenuItem.Click
        Dim WebDoc As New frm_webbrowser_preview
        WebDoc.Show()

        Dim html As String = DgvSubCategoria.CurrentRow.Cells(1).Value
        WebDoc.WebBrowser1.DocumentText = html
    End Sub

    Private Sub HTMLToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HTMLToolStripMenuItem1.Click
        Dim WebDoc As New frm_webbrowser_preview
        WebDoc.Show()

        Dim html As String = DgvCategoria.CurrentRow.Cells(1).Value
        WebDoc.WebBrowser1.DocumentText = html
    End Sub

    Private Sub btNoUsedIDs_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles btNoUsedIDs.ButtonClick
        If e.Button.Tag = "OK" Then
            If CStr(btNoUsedIDs.Tag) <> "" Then
                txtIDProducto.Text = btNoUsedIDs.Tag.ToString
                FillAllDatafromID()
                btNoUsedIDs.Tag = ""
                btNoUsedIDs.Text = ""

                btNoUsedIDs.Size = New Size(101, 18)
                btNoUsedIDs.Location = New Point(546, 145)
            End If

        ElseIf e.Button.Tag = "Search" Then

            Dim Dstemp As New DataSet

            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDArticulo,Descripcion,Referencia,VecesVendido,VecesComprado from Libregco.Articulos Where VecesVendido=0 And VecesComprado=0 ORDER BY RAND() LIMIT 1", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp, "Articulos")
            ConLibregco.Close()

            For Each Fila As DataRow In Dstemp.Tables(0).Rows
                btNoUsedIDs.Text = Fila.Item("Descripcion").ToString
                btNoUsedIDs.Tag = Fila.Item("IDArticulo").ToString
            Next

            btNoUsedIDs.Size = New Size(312, 18)
            btNoUsedIDs.Location = New Point(335, 145)
            Dstemp.Dispose()

        ElseIf e.Button.Tag = "List" Then
            frm_articulos_nousados.ShowDialog(Me)
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If txtIDProducto.Text = "" Then
            MessageBox.Show("No hay registro de artículo abierto para buscar historial de compra relacionado.", "No se encontró código", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            frm_consulta_stock_info.ShowDialog(Me)
        End If
    End Sub

    Private Sub btNoUsedIDs_Leave(sender As Object, e As EventArgs) Handles btNoUsedIDs.Leave
        btNoUsedIDs.Tag = ""
        btNoUsedIDs.Text = ""

        btNoUsedIDs.Size = New Size(101, 18)
        btNoUsedIDs.Location = New Point(546, 145)
    End Sub

    'Private Sub txtDescrip_TextChanged(sender As Object, e As EventArgs) Handles txtDescrip.TextChanged
    '    AdjustDescriptionHeight()
    'End Sub

    Private Function ReturnMininCharacterLenght() As Integer
        If DTConfiguracion.Rows(91 - 1).Item("Value2Int") = 1 Then
            Return 1
        ElseIf DTConfiguracion.Rows(91 - 1).Item("Value2Int") = 2 Then
            Return 10
        ElseIf DTConfiguracion.Rows(91 - 1).Item("Value2Int") = 3 Then
            Return 20
        End If
    End Function

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        If txtDescrip.Text = "" Then
            MessageBox.Show("Escriba la descripción o nombre del artículo a procesar.", "Descripción del artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescrip.Focus()
            Exit Sub
        ElseIf txtDescrip.Text.Trim.Length < ReturnMininCharacterLenght Then
            MessageBox.Show("La descripción del artículo no es lo suficientemente larga para cumplir con los requisitos de su procesamiento. Por favor sea más específico.", "Especificar Descripción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescrip.Focus()
            Exit Sub
        ElseIf txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor a quien le corresponderá por predeterminado el artículo: " & vbNewLine & vbNewLine & txtDescrip.Text, "Seleccione el Suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_Suplidor.PerformClick()
            Exit Sub
        ElseIf txtIDTipoArticulo.Text = "" Then
            MessageBox.Show("Seleccione el tipo de artículo a procesar.", "Seleccionar Tipo de Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarTipoArticulo.PerformClick()
            Exit Sub
        ElseIf txtIDDepartamento.Text = "" Then
            MessageBox.Show("Seleccione el departamento correspodiente al artículo: " & vbNewLine & vbNewLine & txtDescrip.Text, "Seleccione el departamento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_Departamento.PerformClick()
            Exit Sub
        ElseIf txtIDCategoria.Text = "" Then
            MessageBox.Show("Seleccione la categoría correspodiente al artículo: " & txtDescrip.Text & ", perteneciente al departamento: " & txtDepartamento.Text & ".", "Seleccione el departamento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarCategoria.PerformClick()
            Exit Sub
        ElseIf txtIDSubCategoria.Text = "" Then
            MessageBox.Show("Seleccione la subcategoría correspodiente al artículo: " & txtDescrip.Text & ", perteneciente al departamento: " & txtDepartamento.Text & ", y a la categoría: " & txtCategoria.Text & ".", "Seleccione el departamento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSubCategoria.PerformClick()
            Exit Sub
        ElseIf txtIDItbis.Text = "" Then
            MessageBox.Show("Seleccione el tipo de impuesto a la transferencia de bienes industrializados y de servicios (ITBIS) correspodiente al artículo: " & txtDescrip.Text & ".", "Seleccione Tipo de ITBIS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btn_Itbis.PerformClick()
            Exit Sub
        ElseIf txtIDMarca.Text = "" Then
            MessageBox.Show("Seleccione la marca correspondiente al artículo: " & vbNewLine & vbNewLine & txtDescrip.Text, "Seleccione la marca", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarMarca.PerformClick()
            Exit Sub
        ElseIf txtIDGarantia.Text = "" Then
            MessageBox.Show("Seleccione la garantía correspondiente al artículo: " & vbNewLine & vbNewLine & txtDescrip.Text, "Seleccione la garantía", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarGarantia.PerformClick()
            Exit Sub
        ElseIf txtIDParentesco.Text = "" Then
            MessageBox.Show("Seleccione el tipo de parentesco  correspondiente al artículo: " & vbNewLine & vbNewLine & txtDescrip.Text, "Seleccione el tipo de parentesco", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            TbcProductos.SelectedIndex = 0
            btnParentesco.PerformClick()
            Exit Sub
        End If

        If txtIDProducto.Text = "" Then 'Si no hay un producto seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo registro a la base de datos?", "Guardar Nuevo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Libregco.Articulos (Descripcion,Referencia,IDSuplidor,IDTipoProducto,IDDepartamento,IDItbis,IDCategoria,IDSubCategoria,IDMarca,IDGarantia,IDParentesco,IDColor,CodigoBarra,Serial,Promocion,Devolucion,VenderCosto,Descontinuar,BloqueoCredito,PreAlertar,Revisado,ExistenciaMin,ExistenciaMax,Desactivar,ExistenciaTotal,NoPagoTarjeta,CobrarComision,PorcentajeComision,NoPermitirCambiarPrecio,OrdenPrecios,IDColectivo,FechaCreacion,BloquearModificacionPrecio,ServicioPersonalizable) VALUES ('" + txtDescrip.Text + "','" + txtReferencia.Text + "', '" + txtIDSuplidor.Text + "','" + txtIDTipoArticulo.Text + "','" + txtIDDepartamento.Text + "', '" + txtIDItbis.Text + "', '" + txtIDCategoria.Text + "','" + txtIDSubCategoria.Text + "', '" + txtIDMarca.Text + "','" + txtIDGarantia.Text + "','" + txtIDParentesco.Text + "','" + PColor.Tag.ToString + "','" + txtCodigoBarra.Text + "','" + chk_ConSerial.Tag.ToString + "','" + chkPromocion.Tag.ToString + "','" + chkDevolucion.Tag.ToString + "', '" + chkVenderCosto.Tag.ToString + "', '" + chkDescontinuar.Tag.ToString + "','" + chkBloqueoCredito.Tag.ToString + "','" + chkPreAlertar.Tag.ToString + "','" + ChkRevisado.Tag.ToString + "','" + txtStockMin.Text + "', '" + txtStockMax.Text + "', '" + chkDesactivar.Tag.ToString + "',0,'" + chkNoPagoTarjeta.Tag.ToString + "','" + chkCobrarComision.Tag.ToString + "','" + CDbl(Replace(txtPorcComision.Text, "%", "")).ToString + "','" + chkPermitirModificarPrecio.Tag.ToString + "','" + CbxOrden.Tag.ToString + "','" + If(txtIDGrupo.Text = "[ Disponible ]", 1, txtIDGrupo.Text).ToString + "',CURDATE(),'" + Convert.ToInt16(chkBloquearModificacion.Checked).ToString + "','" + Convert.ToInt16(chkServicioPersonalizable.Checked).ToString + "')"
                GuardarDatos()
                UltArticulo()
                GuardarHijos()
                MoverFichero()
                SetDefaultPhoto(txtIDProducto.Text)
                SetQRImage(txtIDProducto.Text)
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))
                TbcProductos.Focus()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Libregco.Articulos SET Descripcion='" + txtDescrip.Text + "',Referencia='" + txtReferencia.Text + "',IDSuplidor='" + txtIDSuplidor.Text + "',IDTipoProducto='" + txtIDTipoArticulo.Text + "',IDDepartamento='" + txtIDDepartamento.Text + "',IDItbis='" + txtIDItbis.Text + "',IDCategoria='" + txtIDCategoria.Text + "',IDSubCategoria='" + txtIDSubCategoria.Text + "',IDMarca='" + txtIDMarca.Text + "',IDGarantia='" + txtIDGarantia.Text + "',IDParentesco='" + txtIDParentesco.Text + "',IDColor='" + PColor.Tag.ToString + "',CodigoBarra='" + txtCodigoBarra.Text + "',Serial='" + chk_ConSerial.Tag.ToString + "',Promocion='" + chkPromocion.Tag.ToString + "',Devolucion='" + chkDevolucion.Tag.ToString + "',VenderCosto='" + chkVenderCosto.Tag.ToString + "',Descontinuar='" + chkDescontinuar.Tag.ToString + "',BloqueoCredito='" + chkBloqueoCredito.Tag.ToString + "',PreAlertar='" + chkPreAlertar.Tag.ToString + "',Revisado='" + ChkRevisado.Tag.ToString + "',ExistenciaMin='" + txtStockMin.Text + "',ExistenciaMax='" + txtStockMax.Text + "',Desactivar='" + chkDesactivar.Tag.ToString + "',NoPagoTarjeta='" + chkNoPagoTarjeta.Tag.ToString + "',CobrarComision='" + chkCobrarComision.Tag.ToString + "',PorcentajeComision='" + CDbl(Replace(txtPorcComision.Text, "%", "")).ToString + "',NoPermitirCambiarPrecio='" + chkPermitirModificarPrecio.Tag.ToString + "',OrdenPrecios='" + CbxOrden.Tag.ToString + "',IDColectivo='" + If(txtIDGrupo.Text = "[ Disponible ]", 1, txtIDGrupo.Text).ToString + "',BloquearModificacionPrecio='" + Convert.ToInt16(chkBloquearModificacion.Checked).ToString + "',ServicioPersonalizable='" + Convert.ToInt16(chkServicioPersonalizable.Checked).ToString + "' WHERE IDArticulo= (" + txtIDProducto.Text + ")"
                GuardarDatos()
                GuardarHijos()
                MoverFichero()
                SetDefaultPhoto(txtIDProducto.Text)
                SetQRImage(txtIDProducto.Text)
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))
                TbcProductos.Focus()
            End If
        End If

    End Sub

    Private Sub TreeView1_MouseEnter(sender As Object, e As EventArgs) Handles TreeView1.MouseEnter
        ChangingfromTreeview = True

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If txtIDProducto.Text <> "" Then
            If TablaQuestions.Rows.Count > 0 Then
                ConLibregco.Open()

                For Each rw As DataRow In TablaQuestions.Rows
                    If CStr(rw.Item("idArticulos_preguntas")) = "" Then
                        If CStr(rw.Item("Titulo")) <> "" And CStr(rw.Item("Descripcion")) <> "" Then
                            cmd = New MySqlCommand("INSERT INTO Libregco.articulos_preguntas (IDArticulo,Titulo,Descripcion,Abierta,Opciones,Nulo) VALUES ('" + txtIDProducto.Text + "','" + rw.Item("Titulo").ToString + "','" + rw.Item("Descripcion").ToString + "','" + rw.Item("Abierta").ToString + "','" + rw.Item("Opciones").ToString + "',0)", ConLibregco)
                            cmd.ExecuteNonQuery()

                            cmd = New MySqlCommand("Select idArticulos_preguntas from articulos_preguntas where idArticulos_preguntas= (Select Max(idArticulos_preguntas) from articulos_preguntas)", ConLibregco)
                            rw.Item("idArticulos_preguntas") = Convert.ToDouble(cmd.ExecuteScalar())
                        End If
                    Else
                        cmd = New MySqlCommand("UPDATE articulos_preguntas SET Titulo='" + rw.Item("Titulo").ToString + "',Descripcion='" + rw.Item("Descripcion").ToString + "',Abierta='" + rw.Item("Abierta").ToString + "',Opciones='" + rw.Item("Opciones").ToString + "' WHERE idArticulos_preguntas=(" + CStr(rw.Item("idArticulos_preguntas")).ToString + ")", ConLibregco)
                        cmd.ExecuteNonQuery()
                    End If
                Next
                ConLibregco.Close()

                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(3))
            End If
        End If
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If XtraTabControl1.SelectedTabPageIndex = 1 Then
            btnActualizarHistorial.PerformClick()
        End If
    End Sub

    Private Sub chkFiltrarExistencia_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltrarExistencia.CheckedChanged
        dtpExistenciaDesde.Enabled = chkFiltrarExistencia.Checked
        dtpExistenciaHasta.Enabled = chkFiltrarExistencia.Checked


    End Sub

    Private Sub txtIDGrupo_TextChanged(sender As Object, e As EventArgs) Handles txtIDGrupo.TextChanged
        If txtIDGrupo.Text <> "" Then

            If IsNumeric(txtIDGrupo.Text) Then
                txtGrupoNombre.Enabled = True
                chkVincularPrecio.Enabled = True
                btnGuardarGrupo.Enabled = True
            End If

        End If
    End Sub

    Private Sub btnGuardarGrupo_Click(sender As Object, e As EventArgs) Handles btnGuardarGrupo.Click
        ConLibregco.Open()
        cmd = New MySqlCommand("UPDATE Libregco.articulos_grupos SET Colectivo='" + txtGrupoNombre.Text + "',VincularPrecio='" + Convert.ToInt16(chkVincularPrecio.Checked).ToString + "' WHERE idArticulos_grupos= (" + txtIDGrupo.Text + ")", ConLibregco)
        cmd.ExecuteNonQuery()
        ConLibregco.Close()

        MessageBox.Show("Se ha actualizado la información del grupo.")

    End Sub

    Private Sub chkBloquearModificacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkBloquearModificacion.CheckedChanged
        If chkBloquearModificacion.Checked Then
            DgvPrecios.Enabled = False
            DgvPrecios.ReadOnly = False
            SplitContainer2.Enabled = False
        Else
            DgvPrecios.Enabled = True
            DgvPrecios.ReadOnly = True
            SplitContainer2.Enabled = True
        End If
    End Sub

    Private Sub chkBloquearModificacion_Click(sender As Object, e As EventArgs) Handles chkBloquearModificacion.Click
        If txtIDProducto.Text = "" Then
        Else
            If chkBloquearModificacion.Checked = False Then
                chkBloquearModificacion.Checked = True
            Else
                frm_superclave.IDAccion.Text = 135
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    Exit Sub
                Else
                    chkBloquearModificacion.Checked = False
                End If
            End If
        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles btnActualizarHistorial.Click
        CargarHistorial()
    End Sub

    Private Sub TreeView1_Enter(sender As Object, e As EventArgs) Handles TreeView1.Enter
        ChangingfromTreeview = True
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        Dim GetFileName As New SaveFileDialog

        With GetFileName
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Title = ("Especifique ubicación")
            .Filter = "Archivos de Excel (*.xls)|*.xls"
            .FileName = ""
            .AddExtension = True
        End With

        If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
            GridView1.ExportToXls(GetFileName.FileName)
            Process.Start(GetFileName.FileName)
        End If

    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        Dim GetFileName As New SaveFileDialog

        With GetFileName
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Title = ("Especifique ubicación")
            .Filter = "Portable Documento Format (*.pdf)|*.pdf"
            .FileName = ""
            .AddExtension = True
        End With

        If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
            GridView1.ExportToPdf(GetFileName.FileName)
            Process.Start(GetFileName.FileName)
        End If

    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        Clipboard.SetText(GridView1.GetFocusedDisplayText())
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        Dim str As String = ""
        For i As Integer = 0 To GridView1.Columns.Count - 1
            If GridView1.Columns(i).Visible = True Then
                str = str & " ׀ " & GridView1.GetRowCellDisplayText(GridView1.FocusedRowHandle, GridView1.Columns(i))
            End If
        Next

        Clipboard.SetText(str)

    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        Dim str As String = ""
        For i As Integer = 0 To GridView1.RowCount - 1
            str = str & vbNewLine & GridView1.GetRowCellValue(i, GridView1.FocusedColumn)
        Next

        Clipboard.SetText(str)
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        ' Check whether the GridControl can be previewed. 
        If Not GcHistorial.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
        Else
            GvHistorial.ShowPrintPreview()
        End If
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        Try
            ' Check whether the GridControl can be printed. 
            If Not GcHistorial.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Else
                GvHistorial.Print()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        Dim GetFileName As New SaveFileDialog

        With GetFileName
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Title = ("Especifique ubicación")
            .Filter = "Archivos de Excel (*.xls)|*.xls"
            .FileName = ""
            .AddExtension = True
        End With

        If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
            GvHistorial.ExportToXls(GetFileName.FileName)
            Process.Start(GetFileName.FileName)
        End If

    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        Dim GetFileName As New SaveFileDialog

        With GetFileName
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Title = ("Especifique ubicación")
            .Filter = "Portable Documento Format (*.pdf)|*.pdf"
            .FileName = ""
            .AddExtension = True
        End With

        If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
            GvHistorial.ExportToPdf(GetFileName.FileName)
            Process.Start(GetFileName.FileName)
        End If

    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        Clipboard.SetText(GvHistorial.GetFocusedDisplayText())
    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        Dim str As String = ""
        For i As Integer = 0 To GvHistorial.Columns.Count - 1
            If GvHistorial.Columns(i).Visible = True Then
                str = str & " ׀ " & GvHistorial.GetRowCellDisplayText(GvHistorial.FocusedRowHandle, GvHistorial.Columns(i))
            End If
        Next

        Clipboard.SetText(str)

    End Sub

    Private Sub ToolStripMenuItem21_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem21.Click
        Dim str As String = ""
        For i As Integer = 0 To GvHistorial.RowCount - 1
            str = str & vbNewLine & GvHistorial.GetRowCellValue(i, GvHistorial.FocusedColumn)
        Next

        Clipboard.SetText(str)
    End Sub

    Private Sub txtDescrip_TextChanged(sender As Object, e As EventArgs) Handles txtDescrip.TextChanged
        If CInt(DTConfiguracion.Rows(90 - 1).Item("Value2Int")) = 1 Then
            If txtDescrip.Text.Contains("1/2") Then
                txtDescrip.Text = txtDescrip.Text.Replace("1/2", "½")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            ElseIf txtDescrip.Text.Contains("1 / 2") Then
                txtDescrip.Text = txtDescrip.Text.Replace("1 / 2", "½")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            ElseIf txtDescrip.Text.Contains("3/4") Then
                txtDescrip.Text = txtDescrip.Text.Replace("3/4", "¾")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            ElseIf txtDescrip.Text.Contains("3 / 4") Then
                txtDescrip.Text = txtDescrip.Text.Replace("3 / 4", "¾")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            ElseIf txtDescrip.Text.Contains("1/4") Then
                txtDescrip.Text = txtDescrip.Text.Replace("1/4", "¼")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            ElseIf txtDescrip.Text.Contains("1 / 4") Then
                txtDescrip.Text = txtDescrip.Text.Replace("1 / 4", "¼")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            ElseIf txtDescrip.Text.Contains("3/8") Then
                txtDescrip.Text = txtDescrip.Text.Replace("3/8", "⅜")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            ElseIf txtDescrip.Text.Contains("3 / 8") Then
                txtDescrip.Text = txtDescrip.Text.Replace("3 / 8", "⅜")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            ElseIf txtDescrip.Text.Contains("5/8") Then
                txtDescrip.Text = txtDescrip.Text.Replace("5/8", "⅝")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            ElseIf txtDescrip.Text.Contains("5 / 8") Then
                txtDescrip.Text = txtDescrip.Text.Replace("5 / 8", "⅝")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            ElseIf txtDescrip.Text.Contains("7/8") Then
                txtDescrip.Text = txtDescrip.Text.Replace("7/8", "⅞")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            ElseIf txtDescrip.Text.Contains("7 / 8") Then
                txtDescrip.Text = txtDescrip.Text.Replace("7 / 8", "⅞")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            ElseIf txtDescrip.Text.Contains("1/8") Then
                txtDescrip.Text = txtDescrip.Text.Replace("1/8", "⅛")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            ElseIf txtDescrip.Text.Contains("1 / 8") Then
                txtDescrip.Text = txtDescrip.Text.Replace("1 / 8", "⅛")
                txtDescrip.SelectionStart = txtDescrip.TextLength
            End If
        End If
    End Sub

    Private Sub txtIDTipoArticulo_TextChanged(sender As Object, e As EventArgs) Handles txtIDTipoArticulo.TextChanged
        If txtIDTipoArticulo.Text <> "" Then
            If txtIDTipoArticulo.Text = "2" Then
                chkServicioPersonalizable.Visible = True
            Else
                chkServicioPersonalizable.Visible = False
                chkServicioPersonalizable.Checked = False
            End If
        End If

    End Sub

    Private Sub TreeView1_Click(sender As Object, e As EventArgs) Handles TreeView1.Click
        ChangingfromTreeview = True
    End Sub

    Private Sub TreeView1_MouseClick(sender As Object, e As MouseEventArgs) Handles TreeView1.MouseClick
        ChangingfromTreeview = True
    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        ChangingfromTreeview = True
    End Sub

    Private Sub DgvPrecios_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPrecios.CellEndEdit
        DgvPrecios.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvPrecios_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvPrecios.CurrentCellDirtyStateChanged
        If DgvPrecios.IsCurrentCellDirty Then
            DgvPrecios.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvPrecios_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvPrecios.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)
        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = DgvPrecios.CurrentCell.ColumnIndex

        If Columna = 15 Then
            Dim Caracter As Char = e.KeyChar
            Dim Txt As TextBox = CType(sender, TextBox)

            If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") And (Txt.Text.Contains(",") = False) Then

                e.Handled = False
            Else
                e.Handled = True
            End If

        End If
    End Sub

    'Private Sub AdjustDescriptionHeight()
    '    Try
    '        If txtDescrip.Text.Length >= 55 Then
    '            txtDescrip.Multiline = True
    '            txtDescrip.Height = 46
    '            btNoUsedIDs.Location = New Point(546, 169)
    '            TbcProductos.Location = New Point(5, 195)
    '            Me.Size = New Size(887, 809)

    '        Else
    '            If txtDescrip.Height <> 23 Then
    '                txtDescrip.Multiline = False
    '                txtDescrip.Height = 23
    '                btNoUsedIDs.Location = New Point(546, 145)
    '                TbcProductos.Location = New Point(5, 172)
    '                Me.Size = New Size(887, 789)
    '            End If

    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message.ToString)
    '    End Try

    'End Sub

    Private Sub ImprimirGridToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirGridToolStripMenuItem.Click
        Try
            ' Check whether the GridControl can be printed. 
            If Not GridControl1.IsPrintingAvailable Then
                MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
            Else
                GridView1.Print()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub PrevisualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrevisualizarToolStripMenuItem.Click
        ' Check whether the GridControl can be previewed. 
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
        Else
            GridView1.ShowPrintPreview()
        End If
    End Sub
End Class

