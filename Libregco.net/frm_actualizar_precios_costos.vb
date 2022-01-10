Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.DragDrop
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors
Imports DevExpress.Utils

Public Class frm_actualizar_precios_costos
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim FullCommand As String
    Dim RedondearalEntero As Integer
    Dim Permisos, PermisosArticulos As New ArrayList
    Dim SelectCommand As String = "SELECT Articulos.RutaFoto,Articulos.IDArticulo,Articulos.Descripcion,Articulos.Referencia,Medida.Medida,Costo,CostoFinal,PrecioCredito,PrecioContado,Precio3,Precio4,IDPrecios,Articulos.ExistenciaTotal,PrecioArticulo.UltimaActualizacion,UltimoCambioPrecios,PrecioArticulo.UltimoCostoCompra,Marca.Marca FROM libregco.PrecioArticulo INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Marca on Articulos.IDMarca=Marca.IDMarca INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida"

    Friend TablaArticulos As DataTable
    Dim RepositoryImagen As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit() With {.PictureAlignment = ContentAlignment.MiddleCenter, .SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom}

    Dim RepositorySecondID As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}
    Dim RepositoryDescrip As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit() With {.WordWrap = True, .AcceptsReturn = False, .AcceptsTab = False}
    Dim RepositoryCosto As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryCostoFinal As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryPrecioA As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryPrecioB As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryPrecioC As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryPrecioD As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryChkIncluir As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}


    Private Sub frm_actualizar_precios_costos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarLibregco()
        Permisos = PasarPermisos(256)
        PermisosArticulos = PasarPermisos(3)
        SpinEdit1.Value = 500

        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemCheckState(i, CheckState.Checked)
        Next

        SetArticulosTable()
        CargarEmpresa()
        LimpiarDatos()
        'RefrescarTabla()
    End Sub

    Private Sub CollapseMenu()
        If NavigationPane2.State = DevExpress.XtraBars.Navigation.NavigationPaneState.Default Then
            NavigationPane2.State = DevExpress.XtraBars.Navigation.NavigationPaneState.Collapsed
        End If
    End Sub

    Private Sub SetArticulosTable()
        TablaArticulos = New DataTable("Articulos")
        TablaArticulos.Columns.Add("Imagen", System.Type.GetType("System.Object"))
        TablaArticulos.Columns.Add("ID", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Referencia", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Medida", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Costo", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("CostoFinal", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("PrecioA", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("PrecioB", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("PrecioC", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("PrecioD", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("NCosto", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("NCostoFinal", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("NPrecioA", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("NPrecioB", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("NPrecioC", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("NPrecioD", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("IDPrecio", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Existencia", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("UltimaActualizacion", System.Type.GetType("System.DateTime"))
        TablaArticulos.Columns.Add("UltimoCambio", System.Type.GetType("System.DateTime"))
        TablaArticulos.Columns.Add("UltCosto", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("Incluir", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Marca", System.Type.GetType("System.String"))
        GridControl1.DataSource = TablaArticulos

        GridView1.Columns("Imagen").ColumnEdit = RepositoryImagen
        GridView1.Columns("ID").ColumnEdit = RepositorySecondID
        GridView1.Columns("Descripcion").ColumnEdit = RepositoryDescrip
        GridView1.Columns("NCosto").ColumnEdit = RepositoryCosto
        GridView1.Columns("NCostoFinal").ColumnEdit = RepositoryCostoFinal
        GridView1.Columns("NPrecioA").ColumnEdit = RepositoryPrecioA
        GridView1.Columns("NPrecioB").ColumnEdit = RepositoryPrecioB
        GridView1.Columns("NPrecioC").ColumnEdit = RepositoryPrecioC
        GridView1.Columns("NPrecioD").ColumnEdit = RepositoryPrecioD
        GridView1.Columns("Incluir").ColumnEdit = RepositoryChkIncluir
        'Estilos
        GridView1.Columns("Imagen").Width = 80
        GridView1.Columns("ID").Caption = "Código"
        GridView1.Columns("ID").Width = 80
        GridView1.Columns("Descripcion").Caption = "Descripción"
        GridView1.Columns("Descripcion").Width = 400
        GridView1.Columns("Descripcion").OptionsColumn.AllowEdit = False
        GridView1.Columns("Descripcion").OptionsColumn.ReadOnly = True
        GridView1.Columns("Referencia").Width = 180
        GridView1.Columns("Referencia").OptionsColumn.AllowEdit = False
        GridView1.Columns("Referencia").OptionsColumn.ReadOnly = True
        GridView1.Columns("Medida").Width = 100
        GridView1.Columns("Medida").OptionsColumn.AllowEdit = False
        GridView1.Columns("Medida").OptionsColumn.ReadOnly = True

        GridView1.Columns("Costo").Caption = "Costo"
        GridView1.Columns("Costo").Width = 100
        GridView1.Columns("Costo").OptionsColumn.AllowEdit = False
        GridView1.Columns("Costo").OptionsColumn.ReadOnly = True
        GridView1.Columns("Costo").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Costo").DisplayFormat.FormatString = "C2"

        GridView1.Columns("CostoFinal").Caption = "Costo final"
        GridView1.Columns("CostoFinal").Width = 100
        GridView1.Columns("CostoFinal").OptionsColumn.AllowEdit = False
        GridView1.Columns("CostoFinal").OptionsColumn.ReadOnly = True
        GridView1.Columns("CostoFinal").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("CostoFinal").DisplayFormat.FormatString = "C2"

        GridView1.Columns("PrecioA").Caption = "Precio A"
        GridView1.Columns("PrecioA").Width = 100
        GridView1.Columns("PrecioA").OptionsColumn.AllowEdit = False
        GridView1.Columns("PrecioA").OptionsColumn.ReadOnly = True
        GridView1.Columns("PrecioA").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("PrecioA").DisplayFormat.FormatString = "C2"

        GridView1.Columns("PrecioB").Caption = "Precio B"
        GridView1.Columns("PrecioB").Width = 100
        GridView1.Columns("PrecioB").OptionsColumn.AllowEdit = False
        GridView1.Columns("PrecioB").OptionsColumn.ReadOnly = True
        GridView1.Columns("PrecioB").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("PrecioB").DisplayFormat.FormatString = "C2"

        GridView1.Columns("PrecioC").Caption = "Precio C"
        GridView1.Columns("PrecioC").Width = 100
        GridView1.Columns("PrecioC").OptionsColumn.AllowEdit = False
        GridView1.Columns("PrecioC").OptionsColumn.ReadOnly = True
        GridView1.Columns("PrecioC").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("PrecioC").DisplayFormat.FormatString = "C2"

        GridView1.Columns("PrecioD").Caption = "Precio D"
        GridView1.Columns("PrecioD").Width = 100
        GridView1.Columns("PrecioD").OptionsColumn.AllowEdit = False
        GridView1.Columns("PrecioD").OptionsColumn.ReadOnly = True
        GridView1.Columns("PrecioD").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("PrecioD").DisplayFormat.FormatString = "C2"

        GridView1.Columns("NCosto").Caption = "Nuevo Costo"
        GridView1.Columns("NCosto").Width = 110
        GridView1.Columns("NCosto").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("NCosto").DisplayFormat.FormatString = "C2"

        GridView1.Columns("NCostoFinal").Caption = "Nuevo Costo final"
        GridView1.Columns("NCostoFinal").Width = 110
        GridView1.Columns("NCostoFinal").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("NCostoFinal").DisplayFormat.FormatString = "C2"

        GridView1.Columns("NPrecioA").Caption = "Nuevo Precio A"
        GridView1.Columns("NPrecioA").Width = 110
        GridView1.Columns("NPrecioA").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("NPrecioA").DisplayFormat.FormatString = "C2"

        GridView1.Columns("NPrecioB").Caption = "Nuevo Precio B"
        GridView1.Columns("NPrecioB").Width = 110
        GridView1.Columns("NPrecioB").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("NPrecioB").DisplayFormat.FormatString = "C2"

        GridView1.Columns("NPrecioC").Caption = "Nuevo Precio C"
        GridView1.Columns("NPrecioC").Width = 110
        GridView1.Columns("NPrecioC").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("NPrecioC").DisplayFormat.FormatString = "C2"

        GridView1.Columns("NPrecioD").Caption = "Nuevo Precio D"
        GridView1.Columns("NPrecioD").Width = 110
        GridView1.Columns("NPrecioD").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("NPrecioD").DisplayFormat.FormatString = "C2"
        GridView1.Columns("IDPrecio").Visible = False

        GridView1.Columns("Existencia").Width = 80
        GridView1.Columns("Existencia").OptionsColumn.AllowEdit = False
        GridView1.Columns("Existencia").OptionsColumn.ReadOnly = True

        GridView1.Columns("UltimaActualizacion").Caption = "Ult. compra"
        GridView1.Columns("UltimaActualizacion").Width = 90
        GridView1.Columns("UltimaActualizacion").OptionsColumn.AllowEdit = False
        GridView1.Columns("UltimaActualizacion").OptionsColumn.ReadOnly = True
        GridView1.Columns("UltimaActualizacion").DisplayFormat.FormatType = FormatType.DateTime
        GridView1.Columns("UltimaActualizacion").DisplayFormat.FormatString = "dd/MM/yyyy"

        GridView1.Columns("UltimoCambio").Caption = "Ult. cambio."
        GridView1.Columns("UltimoCambio").Width = 90
        GridView1.Columns("UltimoCambio").OptionsColumn.AllowEdit = False
        GridView1.Columns("UltimoCambio").OptionsColumn.ReadOnly = True
        GridView1.Columns("UltimoCambio").DisplayFormat.FormatType = FormatType.DateTime
        GridView1.Columns("UltimoCambio").DisplayFormat.FormatString = "dd/MM/yyyy"

        GridView1.Columns("UltCosto").Caption = "Ult. Costo"
        GridView1.Columns("UltCosto").Width = 100
        GridView1.Columns("UltCosto").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("UltCosto").DisplayFormat.FormatString = "C2"
        GridView1.Columns("UltCosto").OptionsColumn.AllowEdit = False
        GridView1.Columns("UltCosto").OptionsColumn.ReadOnly = True

        GridView1.Columns("Incluir").Caption = "Incluir"
        GridView1.Columns("Incluir").Width = 100

        GridView1.Columns("Marca").Width = 100
        GridView1.Columns("Marca").OptionsColumn.AllowEdit = False
        GridView1.Columns("Marca").OptionsColumn.ReadOnly = True


        RepositoryCosto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryCosto.Mask.EditMask = "c"
        RepositoryCosto.Mask.UseMaskAsDisplayFormat = True
        RepositoryCosto.NullText = CDbl(0).ToString("C")
        RepositoryCosto.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryCostoFinal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryCostoFinal.Mask.EditMask = "c"
        RepositoryCostoFinal.Mask.UseMaskAsDisplayFormat = True
        RepositoryCostoFinal.NullText = CDbl(0).ToString("C")
        RepositoryCostoFinal.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryPrecioA.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryPrecioA.Mask.EditMask = "c"
        RepositoryPrecioA.Mask.UseMaskAsDisplayFormat = True
        RepositoryPrecioA.NullText = CDbl(0).ToString("C")
        RepositoryPrecioA.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryPrecioB.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryPrecioB.Mask.EditMask = "c"
        RepositoryPrecioB.Mask.UseMaskAsDisplayFormat = True
        RepositoryPrecioB.NullText = CDbl(0).ToString("C")
        RepositoryPrecioB.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryPrecioC.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryPrecioC.Mask.EditMask = "c"
        RepositoryPrecioC.Mask.UseMaskAsDisplayFormat = True
        RepositoryPrecioC.NullText = CDbl(0).ToString("C")
        RepositoryPrecioC.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryPrecioD.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryPrecioD.Mask.EditMask = "c"
        RepositoryPrecioD.Mask.UseMaskAsDisplayFormat = True
        RepositoryPrecioD.NullText = CDbl(0).ToString("C")
        RepositoryPrecioD.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
        CollapseMenu()

        If GridView1.FocusedRowHandle >= 0 Then
            If GridView1.FocusedColumn.FieldName = "ID" Then
                If PermisosArticulos(0) = 1 Then
                    If frm_mant_articulos.Visible = True Then
                        If frm_mant_articulos.WindowState = FormWindowState.Minimized Then
                            frm_mant_articulos.WindowState = FormWindowState.Normal
                        Else
                            frm_mant_articulos.Activate()
                        End If
                    Else
                        frm_mant_articulos.Show(Me)
                    End If

                    frm_mant_articulos.txtIDProducto.Text = GridView1.GetFocusedRowCellValue(GridView1.Columns("ID"))
                    frm_mant_articulos.FillAllDatafromID()
                End If
            End If
        End If
    End Sub


    Private Sub CargarEmpresa()
        'PicBoxLogo.Image = ConseguirLogoEmpresa()
        'Redondear al entero mas cercano
        ConMixta.Open()
        cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=186", ConMixta)
        RedondearalEntero = Convert.ToInt16(cmd.ExecuteScalar())
        ConMixta.Close()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CheckedListBox1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox1.ItemCheck
        If GridView1.Columns.Count > 0 Then
            For Each itm As String In CheckedListBox1.Items
                Dim index As Integer = CheckedListBox1.Items.IndexOf(itm)

                If CheckedListBox1.GetItemCheckState(e.Index) = CheckState.Checked Then
                    GridView1.Columns(e.Index).Visible = False
                Else
                    GridView1.Columns(e.Index).Visible = True
                End If

            Next
        End If
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim dstemp As New DataSet

            TablaArticulos.Rows.Clear()

            ConMixta.Open()
            ConstructorSQL()
            cmd = New MySqlCommand(FullCommand, ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "Articulos")
            ConMixta.Close()

            If frm_inicio.chkPreviewMode.CheckState = CheckState.Checked Then
                Dim img As Image

                For Each dt As DataRow In dstemp.Tables("Articulos").Rows
                    If dt.Item(0) <> "" Then
                        If System.IO.File.Exists(dt.Item(0)) = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(dt.Item(0), FileMode.Open, FileAccess.Read)
                            img = ResizeImage(System.Drawing.Image.FromStream(wFile), 45)
                            wFile.Close()
                        Else
                            img = ResizeImage(My.Resources.No_Image, 45)
                        End If
                    Else
                        img = ResizeImage(My.Resources.No_Image, 45)
                    End If

                    TablaArticulos.Rows.Add(img, dt.Item(1), dt.Item(2), dt.Item(3), dt.Item(4), dt.Item(5), dt.Item(6), dt.Item(7), dt.Item(8), dt.Item(9), dt.Item(10), 0, 0, 0, 0, 0, 0, dt.Item(11), dt.Item(12), dt.Item(13), dt.Item(14), dt.Item(15), 0, dt.Item(16))
                Next

            Else
                CheckedListBox1.SetItemCheckState(0, CheckState.Unchecked)

                For Each dt As DataRow In dstemp.Tables("Articulos").Rows
                    TablaArticulos.Rows.Add(Nothing, dt.Item(1), dt.Item(2), dt.Item(3), dt.Item(4), dt.Item(5), dt.Item(6), dt.Item(7), dt.Item(8), dt.Item(9), dt.Item(10), 0, 0, 0, 0, 0, 0, dt.Item(11), dt.Item(12), dt.Item(13), dt.Item(14), dt.Item(15), 0, dt.Item(16))
                Next

            End If

            GridView1.ClearSelection()
            dstemp.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & ex.StackTrace)
        End Try
    End Sub

    Private Function ReturnConstructorMysql(ByVal CantIFF As Integer)
        If CantIFF = 1 Then
            Return " "
        ElseIf CantIFF > 1 Then
            Return " AND "
        End If
    End Function

    Private Sub ConstructorSQL()
        Dim Paremeter As Integer = 0
        Dim Str As String = SelectCommand

        If txtBuscarModulos.Text <> "" Or txtIDTipoProducto.Text <> "" Or txtIDDepartamento.Text <> "" Or txtIDCategoria.Text <> "" Or txtIDSubCategoria.Text <> "" Or txtIDSuplidor.Text <> "" Or txtIDMarca.Text <> "" Or txtIDMedida.Text <> "" Or txtIDTipoItbis.Text <> "" Or txtIDGarantia.Text <> "" Or txtIDParental.Text <> "" Or cbxPromocion.Text <> "Ambos" Or cbxDevolucion.Text <> "Ambos" Or cbxVenderCosto.Text <> "Ambos" Or cbxDescontinuado.Text <> "Ambos" Or cbxComision.Text <> "Ambos" Or cbxQrcode.Text <> "Ambos" Or cbxImagen.Text <> "Ambos" Or cbxHabSeries.Text <> "Ambos" Or chkPreAlertar.Text <> "Ambos" Or chkRevisado.Text <> "Ambos" Or chkBloqueoCredito.Text <> "Ambos" Or cbxCodigoBarra.Text <> "Todos" Or cbxNoPagoTarjeta.Text <> "Ambos" Or cbxEstado.Text <> "Todos" Or CbxExistencia.Text <> "Todas" Or cbxInventario.Text <> "Todos" Or chkPrecios.Checked = False Then
            Str = Str & " WHERE "

            If txtBuscarModulos.Text <> "" Then
                Str = Str & " Articulos.Descripcion like '%" + txtBuscarModulos.Text + "%' "
                Paremeter += 1
            End If

            If txtIDTipoProducto.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Articulos.IDTipoProducto=" & txtIDTipoProducto.Text
                    Paremeter += 1
                Else
                    Str = Str & " Articulos.IDTipoProducto=" & txtIDTipoProducto.Text
                    Paremeter += 1
                End If
            End If

            If txtIDDepartamento.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Articulos.IDDepartamento=" & txtIDDepartamento.Text
                    Paremeter += 1
                Else
                    Str = Str & " Articulos.IDDepartamento=" & txtIDDepartamento.Text
                    Paremeter += 1
                End If
            End If

            If txtIDCategoria.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Articulos.IDCategoria=" & txtIDCategoria.Text
                    Paremeter += 1
                Else
                    Str = Str & " Articulos.IDCategoria=" & txtIDCategoria.Text
                    Paremeter += 1
                End If
            End If

            If txtIDSubCategoria.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Articulos.IDSubCategoria=" & txtIDSubCategoria.Text
                    Paremeter += 1
                Else
                    Str = Str & " Articulos.IDSubCategoria=" & txtIDSubCategoria.Text
                    Paremeter += 1
                End If
            End If

            If txtIDSuplidor.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Articulos.IDSuplidor=" & txtIDSuplidor.Text
                    Paremeter += 1
                Else
                    Str = Str & " Articulos.IDSuplidor=" & txtIDSuplidor.Text
                    Paremeter += 1
                End If
            End If

            If txtIDMarca.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Articulos.IDMarca=" & txtIDMarca.Text
                    Paremeter += 1
                Else
                    Str = Str & " Articulos.IDMarca=" & txtIDMarca.Text
                    Paremeter += 1
                End If
            End If

            If txtIDMedida.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND PrecioArticulo.IDMedida=" & txtIDMedida.Text
                    Paremeter += 1
                Else
                    Str = Str & " PrecioArticulo.IDMedida=" & txtIDMedida.Text
                    Paremeter += 1
                End If
            End If

            If txtIDTipoItbis.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Articulos.IDItbis=" & txtIDTipoItbis.Text
                    Paremeter += 1
                Else
                    Str = Str & " Articulos.IDItbis=" & txtIDTipoItbis.Text
                    Paremeter += 1
                End If
            End If

            If txtIDGarantia.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Articulos.IDGarantia=" & txtIDGarantia.Text
                    Paremeter += 1
                Else
                    Str = Str & " Articulos.IDGarantia=" & txtIDGarantia.Text
                    Paremeter += 1
                End If
            End If

            If txtIDParental.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Articulos.IDParentesco=" & txtIDParental.Text
                    Paremeter += 1
                Else
                    Str = Str & " Articulos.IDParentesco=" & txtIDParental.Text
                    Paremeter += 1
                End If
            End If

            If cbxPromocion.Text <> "Ambos" Then
                If Paremeter > 0 Then
                    If cbxPromocion.Text = "Sí" Then
                        Str = Str & " AND Articulos.Promocion=1"
                        Paremeter += 1
                    ElseIf cbxPromocion.Text = "No" Then
                        Str = Str & " AND Articulos.Promocion=0"
                        Paremeter += 1
                    End If
                Else
                    If cbxPromocion.Text = "Sí" Then
                        Str = Str & " Articulos.Promocion=1"
                        Paremeter += 1
                    ElseIf cbxPromocion.Text = "No" Then
                        Str = Str & " Articulos.Promocion=0"
                        Paremeter += 1
                    End If

                End If
            End If

            If cbxDevolucion.Text <> "Ambos" Then
                If Paremeter > 0 Then
                    If cbxDevolucion.Text = "Sí" Then
                        Str = Str & " AND Articulos.Devolucion=1"
                        Paremeter += 1
                    ElseIf cbxDevolucion.Text = "No" Then
                        Str = Str & " AND Articulos.Devolucion=0"
                        Paremeter += 1
                    End If
                Else
                    If cbxDevolucion.Text = "Sí" Then
                        Str = Str & " Articulos.Devolucion=1"
                        Paremeter += 1
                    ElseIf cbxDevolucion.Text = "No" Then
                        Str = Str & " Articulos.Devolucion=0"
                        Paremeter += 1
                    End If
                End If
            End If

            If cbxVenderCosto.Text <> "Ambos" Then
                If Paremeter > 0 Then
                    If cbxVenderCosto.Text = "Sí" Then
                        Str = Str & " AND Articulos.VenderCosto=1"
                        Paremeter += 1
                    ElseIf cbxVenderCosto.Text = "No" Then
                        Str = Str & " AND Articulos.VenderCosto=0"
                        Paremeter += 1
                    End If

                Else
                    If cbxVenderCosto.Text = "Sí" Then
                        Str = Str & " Articulos.VenderCosto=1"
                        Paremeter += 1
                    ElseIf cbxVenderCosto.Text = "No" Then
                        Str = Str & " Articulos.VenderCosto=0"
                        Paremeter += 1
                    End If
                End If
            End If

            If cbxDescontinuado.Text <> "Ambos" Then
                If Paremeter > 0 Then
                    If cbxDescontinuado.Text = "Sí" Then
                        Str = Str & " AND Articulos.Descontinuar=1"
                        Paremeter += 1
                    ElseIf cbxDescontinuado.Text = "No" Then
                        Str = Str & " AND Articulos.Descontinuar=0"
                        Paremeter += 1
                    End If
                Else
                    If cbxDescontinuado.Text = "Sí" Then
                        Str = Str & " Articulos.Descontinuar=1"
                        Paremeter += 1
                    ElseIf cbxDescontinuado.Text = "No" Then
                        Str = Str & " Articulos.Descontinuar=0"
                        Paremeter += 1
                    End If
                End If
            End If

            If cbxComision.Text <> "Ambos" Then
                If Paremeter > 0 Then
                    If cbxComision.Text = "Sí" Then
                        Str = Str & " AND Articulos.CobrarComision=1"
                        Paremeter += 1
                    ElseIf cbxComision.Text = "No" Then
                        Str = Str & " AND Articulos.CobrarComision=0"
                        Paremeter += 1
                    End If
                Else
                    If cbxComision.Text = "Sí" Then
                        Str = Str & " Articulos.CobrarComision=1"
                        Paremeter += 1
                    ElseIf cbxComision.Text = "No" Then
                        Str = Str & " Articulos.CobrarComision=0"
                        Paremeter += 1
                    End If
                End If
            End If

            If cbxQrcode.Text <> "Ambos" Then
                If Paremeter > 0 Then
                    If cbxQrcode.Text = "Sí" Then
                        Str = Str & " AND Articulos.QRCode<>''"
                        Paremeter += 1
                    ElseIf cbxQrcode.Text = "No" Then
                        Str = Str & " AND Articulos.QRCode=''"
                        Paremeter += 1
                    End If
                Else
                    If cbxQrcode.Text = "Sí" Then
                        Str = Str & " Articulos.QRCode<>''"
                        Paremeter += 1
                    ElseIf cbxQrcode.Text = "No" Then
                        Str = Str & " Articulos.QRCode=''"
                        Paremeter += 1
                    End If
                End If
            End If

            If cbxImagen.Text <> "Ambos" Then
                If Paremeter > 0 Then
                    If cbxImagen.Text = "Sí" Then
                        Str = Str & " AND Articulos.RutaFoto<>''"
                        Paremeter += 1
                    ElseIf cbxImagen.Text = "No" Then
                        Str = Str & " AND Articulos.RutaFoto=''"
                        Paremeter += 1
                    End If
                Else
                    If cbxImagen.Text = "Sí" Then
                        Str = Str & " Articulos.RutaFoto<>''"
                        Paremeter += 1
                    ElseIf cbxImagen.Text = "No" Then
                        Str = Str & " Articulos.RutaFoto=''"
                        Paremeter += 1
                    End If
                End If
            End If

            If cbxHabSeries.Text <> "Ambos" Then
                If Paremeter > 0 Then
                    If cbxHabSeries.Text = "Sí" Then
                        Str = Str & " AND Articulos.Serial=1"
                        Paremeter += 1
                    ElseIf cbxHabSeries.Text = "No" Then
                        Str = Str & " AND Articulos.Serial=0"
                        Paremeter += 1
                    End If
                Else
                    If cbxHabSeries.Text = "Sí" Then
                        Str = Str & " Articulos.Serial=1"
                        Paremeter += 1
                    ElseIf cbxHabSeries.Text = "No" Then
                        Str = Str & " Articulos.Serial=0"
                        Paremeter += 1
                    End If
                End If
            End If

            If chkPreAlertar.Text <> "Ambos" Then
                If Paremeter > 0 Then
                    If chkPreAlertar.Text = "Sí" Then
                        Str = Str & " AND Articulos.PreAlertar=1"
                        Paremeter += 1
                    ElseIf chkPreAlertar.Text = "No" Then
                        Str = Str & " AND Articulos.PreAlertar=0"
                        Paremeter += 1
                    End If
                Else
                    If chkPreAlertar.Text = "Sí" Then
                        Str = Str & " Articulos.PreAlertar=1"
                        Paremeter += 1
                    ElseIf chkPreAlertar.Text = "No" Then
                        Str = Str & " Articulos.PreAlertar=0"
                        Paremeter += 1
                    End If
                End If
            End If


            If chkRevisado.Text <> "Ambos" Then
                If Paremeter > 0 Then
                    If chkRevisado.Text = "Sí" Then
                        Str = Str & " AND Articulos.Revisado=1"
                        Paremeter += 1
                    ElseIf chkRevisado.Text = "No" Then
                        Str = Str & " AND Articulos.Revisado=0"
                        Paremeter += 1
                    End If
                Else
                    If chkRevisado.Text = "Sí" Then
                        Str = Str & " Articulos.Revisado=1"
                        Paremeter += 1
                    ElseIf chkRevisado.Text = "No" Then
                        Str = Str & " Articulos.Revisado=0"
                        Paremeter += 1
                    End If
                End If
            End If

            If chkBloqueoCredito.Text <> "Ambos" Then
                If Paremeter > 0 Then
                    If chkBloqueoCredito.Text = "Sí" Then
                        Str = Str & " AND Articulos.BloqueoCredito=1"
                        Paremeter += 1
                    ElseIf chkBloqueoCredito.Text = "No" Then
                        Str = Str & " AND Articulos.BloqueoCredito=0"
                        Paremeter += 1
                    End If
                Else
                    If chkBloqueoCredito.Text = "Sí" Then
                        Str = Str & " Articulos.BloqueoCredito=1"
                        Paremeter += 1
                    ElseIf chkBloqueoCredito.Text = "No" Then
                        Str = Str & " Articulos.BloqueoCredito=0"
                        Paremeter += 1
                    End If
                End If
            End If

            If cbxCodigoBarra.Text <> "Todos" Then
                If Paremeter > 0 Then
                    Str = Str & " AND Articulos.CodigoBarra<>''"
                    If cbxCodigoBarra.Text = "Con códigos" Then
                        Paremeter += 1
                    ElseIf cbxCodigoBarra.Text = "Sin códigos" Then
                        Str = Str & " AND Articulos.CodigoBarra=''"
                        Paremeter += 1
                    End If
                Else
                    If cbxCodigoBarra.Text = "Con códigos" Then
                        Str = Str & " Articulos.CodigoBarra<>''"
                        Paremeter += 1
                    ElseIf cbxCodigoBarra.Text = "Sin códigos" Then
                        Str = Str & " Articulos.CodigoBarra=''"
                        Paremeter += 1
                    End If
                End If
            End If

            If cbxNoPagoTarjeta.Text <> "Ambos" Then
                If Paremeter > 0 Then
                    If cbxNoPagoTarjeta.Text = "Sí" Then
                        Str = Str & " AND Articulos.NoPagoTarjeta=1"
                        Paremeter += 1
                    ElseIf cbxNoPagoTarjeta.Text = "No" Then
                        Str = Str & " AND Articulos.NoPagoTarjeta=0"
                        Paremeter += 1
                    End If
                Else
                    If cbxNoPagoTarjeta.Text = "Sí" Then
                        Str = Str & " Articulos.NoPagoTarjeta=1"
                        Paremeter += 1
                    ElseIf cbxNoPagoTarjeta.Text = "No" Then
                        Str = Str & " Articulos.NoPagoTarjeta=0"
                        Paremeter += 1
                    End If
                End If
            End If

            If cbxEstado.Text <> "Todos" Then
                If Paremeter > 0 Then
                    If cbxEstado.Text = "Sólo Activos" Then
                        Str = Str & " AND Articulos.Desactivar=1 AND PrecioArticulo.Nulo=0"
                        Paremeter += 1
                    ElseIf cbxEstado.Text = "Nulos" Then
                        Str = Str & " AND Articulos.Desactivar=0 AND PrecioArticulo.Nulo=0"
                        Paremeter += 1
                    End If
                Else
                    If cbxEstado.Text = "Sólo Activos" Then
                        Str = Str & " Articulos.Desactivar=1 AND PrecioArticulo.Nulo=0"
                        Paremeter += 1
                    ElseIf cbxEstado.Text = "Nulos" Then
                        Str = Str & " Articulos.Desactivar=0 AND PrecioArticulo.Nulo=0"
                        Paremeter += 1
                    End If
                End If
            End If

            If CbxExistencia.Text <> "Todas" Then
                If Paremeter > 0 Then
                    If CbxExistencia.Text = "Por debajo del mínimo" Then
                        Str = Str & " AND Articulos.ExistenciaTotal<ExistenciaMinima"
                        Paremeter += 1
                    ElseIf CbxExistencia.Text = "Por encima del máximo" Then
                        Str = Str & " AND Articulos.ExistenciaTotal>ExistenciaMaxima"
                        Paremeter += 1
                    End If

                Else
                    If CbxExistencia.Text = "Por debajo del mínimo" Then
                        Str = Str & " Articulos.ExistenciaTotal<ExistenciaMinima"
                        Paremeter += 1
                    ElseIf CbxExistencia.Text = "Por encima del máximo" Then
                        Str = Str & " Articulos.ExistenciaTotal>ExistenciaMaxima"
                        Paremeter += 1
                    End If

                End If
            End If

            If cbxInventario.Text <> "Todos" Then
                If Paremeter > 0 Then
                    If cbxInventario.Text = "Menor o Igual" Then
                        Str = Str & " AND Articulos.ExistenciaTotal<=" & txtInventarioCant.Text
                        Paremeter += 1
                    ElseIf cbxInventario.Text = "Menor" Then
                        Str = Str & " And Articulos.ExistenciaTotal<" & txtInventarioCant.Text
                        Paremeter += 1
                    ElseIf cbxInventario.Text = "Mayor" Then
                        Str = Str & " And Articulos.ExistenciaTotal>" & txtInventarioCant.Text
                        Paremeter += 1
                    ElseIf cbxInventario.Text = "Mayor o Igual" Then
                        Str = Str & " And Articulos.ExistenciaTotal>=" & txtInventarioCant.Text
                        Paremeter += 1
                    ElseIf cbxInventario.Text = "Diferente" Then
                        Str = Str & " And Articulos.ExistenciaTotal<>" & txtInventarioCant.Text
                        Paremeter += 1
                    ElseIf cbxInventario.Text = "Igual" Then
                        Str = Str & " And Articulos.ExistenciaTotal=" & txtInventarioCant.Text
                        Paremeter += 1
                    End If

                Else
                    If cbxInventario.Text = "Menor o Igual" Then
                        Str = Str & " Articulos.ExistenciaTotal<=" & txtInventarioCant.Text
                        Paremeter += 1
                    ElseIf cbxInventario.Text = "Menor" Then
                        Str = Str & " Articulos.ExistenciaTotal<" & txtInventarioCant.Text
                        Paremeter += 1
                    ElseIf cbxInventario.Text = "Mayor" Then
                        Str = Str & " Articulos.ExistenciaTotal>" & txtInventarioCant.Text
                        Paremeter += 1
                    ElseIf cbxInventario.Text = "Mayor o Igual" Then
                        Str = Str & " Articulos.ExistenciaTotal>=" & txtInventarioCant.Text
                        Paremeter += 1
                    ElseIf cbxInventario.Text = "Diferente" Then
                        Str = Str & " Articulos.ExistenciaTotal<>" & txtInventarioCant.Text
                        Paremeter += 1
                    ElseIf cbxInventario.Text = "Igual" Then
                        Str = Str & " Articulos.ExistenciaTotal=" & txtInventarioCant.Text
                        Paremeter += 1
                    End If

                End If
            End If

            If chkPrecios.Checked = False Then

                If cbxTipoFiltro.Text = "" Then
                    MessageBox.Show("Seleccione el tipo de filtro de precios.")
                    cbxTipoFiltro.Focus()
                    cbxTipoFiltro.DroppedDown = True
                    Exit Sub
                ElseIf cbxPrecio1.Text = "" Then
                    MessageBox.Show("Seleccione el primer nivel de precios/costos.")
                    cbxPrecio1.Focus()
                    cbxPrecio1.DroppedDown = True
                    Exit Sub
                ElseIf cbxPrecio2.Text = "" Then
                    MessageBox.Show("Seleccione el segundo nivel de precios/costos.")
                    cbxPrecio2.Focus()
                    cbxPrecio2.DroppedDown = True
                    Exit Sub
                End If

                If Paremeter > 0 Then
                    Str = Str & " AND " & cbxPrecio1.Tag.ToString & Label29.Text & cbxPrecio2.Tag.ToString
                    Paremeter += 1
                Else
                    Str = Str & " " & cbxPrecio1.Tag.ToString & Label29.Text & cbxPrecio2.Tag.ToString
                    Paremeter += 1
                End If
            End If

            FullCommand = Str & " ORDER BY Articulos.Descripcion ASC LIMIT " & CInt(SpinEdit1.Value.ToString)

        Else
            FullCommand = Str & " ORDER BY Articulos.Descripcion ASC LIMIT " & CInt(SpinEdit1.Value.ToString)
        End If

    End Sub

    Private Sub LimpiarDatos()
        txtIDTipoProducto.Clear()
        txtTipoProducto.Clear()
        txtIDDepartamento.Clear()
        txtDepartamento.Clear()
        txtIDCategoria.Clear()
        txtCategoria.Clear()
        txtIDSubCategoria.Clear()
        txtSubCategoria.Clear()
        txtIDSuplidor.Clear()
        txtSuplidor.Clear()
        txtIDMarca.Clear()
        txtMarca.Clear()

        cbxPromocion.SelectedIndex = 0
        cbxDevolucion.SelectedIndex = 0
        cbxVenderCosto.SelectedIndex = 0
        cbxDescontinuado.SelectedIndex = 0
        cbxHabSeries.SelectedIndex = 0
        chkPreAlertar.SelectedIndex = 0
        chkRevisado.SelectedIndex = 0
        chkBloqueoCredito.SelectedIndex = 0
        cbxEstado.SelectedIndex = 0
        CbxExistencia.SelectedIndex = 0
        cbxInventario.SelectedIndex = 0
        cbxComision.SelectedIndex = 0
        cbxCodigoBarra.SelectedIndex = 0
        cbxQrcode.SelectedIndex = 0
        cbxNoPagoTarjeta.SelectedIndex = 0
        cbxImagen.SelectedIndex = 0

        ConstructorSQL()
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

    Private Sub txtIDSuplidor_Leave(sender As Object, e As EventArgs) Handles txtIDSuplidor.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Suplidor from Suplidor Where IDSuplidor='" + txtIDSuplidor.Text + "'", ConLibregco)
        txtSuplidor.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtSuplidor.Text = "" Then txtIDSuplidor.Clear()
    End Sub

    Private Sub txtIDMarca_Leave(sender As Object, e As EventArgs) Handles txtIDMarca.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Marca from Marca Where IDMarca='" + txtIDMarca.Text + "'", ConLibregco)
        txtMarca.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtMarca.Text = "" Then txtIDMarca.Clear()
    End Sub

    Private Sub btnBuscarTipoProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoProducto.Click
        frm_buscar_tipo_articulo.ShowDialog(Me)
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

    Private Sub btnSuplidor_Click(sender As Object, e As EventArgs) Handles btnSuplidor.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        frm_buscar_marcas.ShowDialog(Me)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CollapseMenu()
        ConstructorSQL()
        RefrescarTabla()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        CollapseMenu()
        txtBuscarModulos.Clear()
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
        TablaArticulos.Rows.Clear()
    End Sub


    Private Sub PicLogo_Click(sender As Object, e As EventArgs) Handles PicLogo.Click
        CollapseMenu()
        frm_query_structure.txtQuery.Text = "SQL Query: " & FullCommand
        frm_query_structure.ShowDialog(Me)
    End Sub

    Private Sub txtCosto_Enter(sender As Object, e As EventArgs) Handles txtCosto.Enter
        Try
            CollapseMenu()

            If rdbPreciodirecto.Checked = True Then
                If txtCosto.Text = "" Then
                Else
                    txtCosto.Text = CDbl(txtCosto.Text)
                End If
            Else
                If txtCosto.Text = "" Then
                Else
                    txtCosto.Text = CDbl(Replace(txtCosto.Text, "%", ""))
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtCostoFinal_Enter(sender As Object, e As EventArgs) Handles txtCostoFinal.Enter
        CollapseMenu()

        If rdbPreciodirecto.Checked = True Then
            If txtCostoFinal.Text = "" Then
            Else
                txtCostoFinal.Text = CDbl(txtCostoFinal.Text)
            End If
        Else
            If txtCostoFinal.Text = "" Then
            Else
                txtCostoFinal.Text = CDbl(Replace(txtCostoFinal.Text, "%", ""))
            End If
        End If
    End Sub

    Private Sub txtPrecioA_Enter(sender As Object, e As EventArgs) Handles txtPrecioA.Enter
        CollapseMenu()

        If rdbPreciodirecto.Checked = True Then
            If txtPrecioA.Text = "" Then
            Else
                txtPrecioA.Text = CDbl(txtPrecioA.Text)
            End If
        Else
            If txtPrecioA.Text = "" Then
            Else
                txtPrecioA.Text = CDbl(Replace(txtPrecioA.Text, "%", ""))
            End If
        End If
    End Sub

    Private Sub txtPrecioB_Enter(sender As Object, e As EventArgs) Handles txtPrecioB.Enter
        CollapseMenu()

        If rdbPreciodirecto.Checked = True Then
            If txtPrecioB.Text = "" Then
            Else
                txtPrecioB.Text = CDbl(txtPrecioB.Text)
            End If
        Else
            If txtPrecioB.Text = "" Then
            Else
                txtPrecioB.Text = CDbl(Replace(txtPrecioB.Text, "%", ""))
            End If
        End If
    End Sub

    Private Sub TxtPrecioC_Enter(sender As Object, e As EventArgs) Handles txtPrecioC.Enter
        CollapseMenu()

        If rdbPreciodirecto.Checked = True Then
            If txtPrecioC.Text = "" Then
            Else
                txtPrecioC.Text = CDbl(txtPrecioC.Text)
            End If
        Else
            If txtPrecioC.Text = "" Then
            Else
                txtPrecioC.Text = CDbl(Replace(txtPrecioC.Text, "%", ""))
            End If
        End If
    End Sub

    Private Sub TxtPrecioD_Enter(sender As Object, e As EventArgs) Handles txtPrecioD.Enter
        CollapseMenu()

        If rdbPreciodirecto.Checked = True Then
            If txtPrecioD.Text = "" Then
            Else
                txtPrecioD.Text = CDbl(txtPrecioD.Text)
            End If
        Else
            If txtPrecioD.Text = "" Then
            Else
                txtPrecioD.Text = CDbl(Replace(txtPrecioD.Text, "%", ""))
            End If
        End If
    End Sub

    Private Sub CleanTextboxes()
        txtCosto.Clear()
        txtCostoFinal.Clear()
        txtPrecioA.Clear()
        txtPrecioB.Clear()
        txtPrecioC.Clear()
        txtPrecioD.Clear()

    End Sub
    Private Sub txtCosto_Leave(sender As Object, e As EventArgs) Handles txtCosto.Leave
        Try
            If rdbPreciodirecto.Checked = True Then

                If txtCosto.Text = "" Then
                    txtCosto.Text = CDbl(0).ToString("C")
                Else
                    txtCosto.Text = CDbl(txtCosto.Text).ToString("C")
                End If

            Else

                If txtCosto.Text = "" Then
                    txtCosto.Text = CDbl(0).ToString("P2")
                Else

                    txtCosto.Text = CDbl((txtCosto.Text) / 100).ToString("P2")
                End If

            End If
        Catch ex As Exception
            txtCosto.Text = CDbl(0)
        End Try
    End Sub

    Private Sub txtCostoFinal_Leave(sender As Object, e As EventArgs) Handles txtCostoFinal.Leave
        Try
            If rdbPreciodirecto.Checked = True Then

                If txtCostoFinal.Text = "" Then
                    txtCostoFinal.Text = CDbl(0).ToString("C")
                Else
                    txtCostoFinal.Text = CDbl(txtCostoFinal.Text).ToString("C")
                End If

            Else

                If txtCostoFinal.Text = "" Then
                    txtCostoFinal.Text = CDbl(0).ToString("P2")
                Else

                    txtCostoFinal.Text = CDbl((txtCostoFinal.Text) / 100).ToString("P2")
                End If

            End If
        Catch ex As Exception
            txtCostoFinal.Text = CDbl(0)
        End Try
    End Sub

    Private Sub txtPrecioA_Leave(sender As Object, e As EventArgs) Handles txtPrecioA.Leave
        Try
            If rdbPreciodirecto.Checked = True Then

                If txtPrecioA.Text = "" Then
                    txtPrecioA.Text = CDbl(0).ToString("C")
                Else
                    txtPrecioA.Text = CDbl(txtPrecioA.Text).ToString("C")
                End If

            Else

                If txtPrecioA.Text = "" Then
                    txtPrecioA.Text = CDbl(0).ToString("P2")
                Else

                    txtPrecioA.Text = CDbl((txtPrecioA.Text) / 100).ToString("P2")
                End If

            End If
        Catch ex As Exception
            txtPrecioA.Text = CDbl(0)
        End Try
    End Sub

    Private Sub txtPrecioB_Leave(sender As Object, e As EventArgs) Handles txtPrecioB.Leave
        Try
            If rdbPreciodirecto.Checked = True Then

                If txtPrecioB.Text = "" Then
                    txtPrecioB.Text = CDbl(0).ToString("C")
                Else
                    txtPrecioB.Text = CDbl(txtPrecioB.Text).ToString("C")
                End If

            Else

                If txtPrecioB.Text = "" Then
                    txtPrecioB.Text = CDbl(0).ToString("P2")
                Else

                    txtPrecioB.Text = CDbl((txtPrecioB.Text) / 100).ToString("P2")
                End If

            End If
        Catch ex As Exception
            txtPrecioB.Text = CDbl(0)
        End Try
    End Sub

    Private Sub btnCost_Click(sender As Object, e As EventArgs) Handles btnCost.Click
        If rdbPreciodirecto.Checked = True Then
            For i As Integer = 0 To GridView1.DataRowCount - 1
                GridView1.SetRowCellValue(i, "NCosto", RoundUp(CDbl(txtCosto.Text), RedondearalEntero))
            Next
        Else
            For i As Integer = 0 To GridView1.DataRowCount - 1
                GridView1.SetRowCellValue(i, "NCosto", RoundUp((CDbl(GridView1.GetRowCellValue(i, "Costo")) + (CDbl(GridView1.GetRowCellValue(i, "Costo")) * (CDbl(Replace(txtCosto.Text, "%", "")) / 100))), RedondearalEntero))
            Next
        End If
    End Sub

    Private Sub btnCostoFinal_Click(sender As Object, e As EventArgs) Handles btnCostoFinal.Click
        If rdbPreciodirecto.Checked = True Then
            For i As Integer = 0 To GridView1.DataRowCount - 1
                GridView1.SetRowCellValue(i, "NCostoFinal", RoundUp(CDbl(txtCostoFinal.Text), RedondearalEntero))
            Next
        Else
            For i As Integer = 0 To GridView1.DataRowCount - 1
                GridView1.SetRowCellValue(i, "NCostoFinal", RoundUp((CDbl(GridView1.GetRowCellValue(i, "CostoFinal")) + (CDbl(GridView1.GetRowCellValue(i, "CostoFinal")) * (CDbl(Replace(txtCostoFinal.Text, "%", "")) / 100))), RedondearalEntero))
            Next
        End If
    End Sub

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        CollapseMenu()

        If rdbPreciodirecto.Checked = True Then
            For i As Integer = 0 To GridView1.DataRowCount - 1
                GridView1.SetRowCellValue(i, "NPrecioA", RoundUp(CDbl(txtPrecioA.Text), RedondearalEntero))
            Next
        Else
            For i As Integer = 0 To GridView1.DataRowCount - 1
                GridView1.SetRowCellValue(i, "NPrecioA", RoundUp((CDbl(GridView1.GetRowCellValue(i, "PrecioA")) + (CDbl(GridView1.GetRowCellValue(i, "PrecioA")) * (CDbl(Replace(txtPrecioA.Text, "%", "")) / 100))), RedondearalEntero))
            Next
        End If

    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        CollapseMenu()

        If rdbPreciodirecto.Checked = True Then
            For i As Integer = 0 To GridView1.DataRowCount - 1
                GridView1.SetRowCellValue(i, "NPrecioB", RoundUp(CDbl(txtPrecioB.Text), RedondearalEntero))
            Next
        Else
            For i As Integer = 0 To GridView1.DataRowCount - 1
                GridView1.SetRowCellValue(i, "NPrecioB", RoundUp((CDbl(GridView1.GetRowCellValue(i, "PrecioB")) + (CDbl(GridView1.GetRowCellValue(i, "PrecioB")) * (CDbl(Replace(txtPrecioB.Text, "%", "")) / 100))), RedondearalEntero))
            Next
        End If
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        CollapseMenu()

        If rdbPreciodirecto.Checked = True Then
            For i As Integer = 0 To GridView1.DataRowCount - 1
                GridView1.SetRowCellValue(i, "NPrecioC", RoundUp(CDbl(txtPrecioC.Text), RedondearalEntero))
            Next
        Else
            For i As Integer = 0 To GridView1.DataRowCount - 1
                GridView1.SetRowCellValue(i, "NPrecioC", RoundUp((CDbl(GridView1.GetRowCellValue(i, "PrecioC")) + (CDbl(GridView1.GetRowCellValue(i, "PrecioC")) * (CDbl(Replace(txtPrecioC.Text, "%", "")) / 100))), RedondearalEntero))
            Next
        End If
    End Sub

    Private Sub btnD_Click(sender As Object, e As EventArgs) Handles btnD.Click
        CollapseMenu()

        If rdbPreciodirecto.Checked = True Then
            For i As Integer = 0 To GridView1.DataRowCount - 1
                GridView1.SetRowCellValue(i, "NPrecioD", RoundUp(CDbl(txtPrecioD.Text), RedondearalEntero))
            Next
        Else
            For i As Integer = 0 To GridView1.DataRowCount - 1
                GridView1.SetRowCellValue(i, "NPrecioD", RoundUp((CDbl(GridView1.GetRowCellValue(i, "PrecioD")) + (CDbl(GridView1.GetRowCellValue(i, "PrecioD")) * (CDbl(Replace(txtPrecioD.Text, "%", "")) / 100))), RedondearalEntero))
            Next
        End If
    End Sub

    'Private Sub DgvPrecios_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
    '    If DgvPrecios.Rows.Count > 0 Then

    '        Try
    '            If e.ColumnIndex = 10 Then
    '                If DgvPrecios.CurrentRow.Cells(10).Value = "" Then
    '                    DgvPrecios.CurrentRow.Cells(10).Value = DgvPrecios.CurrentRow.Cells(4).Value
    '                Else
    '                    DgvPrecios.CurrentRow.Cells(10).Value = CDbl(DgvPrecios.CurrentRow.Cells(10).Value).ToString("C")
    '                End If
    '            End If
    '        Catch ex As Exception
    '            DgvPrecios.CurrentRow.Cells(10).Value = CDbl(0).ToString("C")
    '        End Try

    '        Try
    '            If e.ColumnIndex = 11 Then
    '                If DgvPrecios.CurrentRow.Cells(11).Value = "" Then
    '                    DgvPrecios.CurrentRow.Cells(11).Value = DgvPrecios.CurrentRow.Cells(5).Value
    '                Else
    '                    DgvPrecios.CurrentRow.Cells(11).Value = CDbl(DgvPrecios.CurrentRow.Cells(11).Value).ToString("C")
    '                End If
    '            End If
    '        Catch ex As Exception
    '            DgvPrecios.CurrentRow.Cells(11).Value = CDbl(0).ToString("C")
    '        End Try

    '        Try
    '            If e.ColumnIndex = 12 Then
    '                If DgvPrecios.CurrentRow.Cells(12).Value = "" Then
    '                    DgvPrecios.CurrentRow.Cells(12).Value = DgvPrecios.CurrentRow.Cells(6).Value
    '                Else
    '                    DgvPrecios.CurrentRow.Cells(12).Value = CDbl(DgvPrecios.CurrentRow.Cells(12).Value).ToString("C")
    '                End If
    '            End If
    '        Catch ex As Exception
    '            DgvPrecios.CurrentRow.Cells(12).Value = CDbl(0).ToString("C")

    '        End Try

    '        Try
    '            If e.ColumnIndex = 13 Then
    '                If DgvPrecios.CurrentRow.Cells(13).Value = "" Then
    '                    DgvPrecios.CurrentRow.Cells(13).Value = DgvPrecios.CurrentRow.Cells(7).Value
    '                Else
    '                    DgvPrecios.CurrentRow.Cells(13).Value = CDbl(DgvPrecios.CurrentRow.Cells(13).Value).ToString("C")
    '                End If
    '            End If
    '        Catch ex As Exception
    '            DgvPrecios.CurrentRow.Cells(13).Value = CDbl(0).ToString("C")
    '        End Try

    '        Try
    '            If e.ColumnIndex = 14 Then
    '                If DgvPrecios.CurrentRow.Cells(14).Value = "" Then
    '                    DgvPrecios.CurrentRow.Cells(14).Value = DgvPrecios.CurrentRow.Cells(8).Value
    '                Else
    '                    DgvPrecios.CurrentRow.Cells(14).Value = CDbl(DgvPrecios.CurrentRow.Cells(14).Value).ToString("C")
    '                End If
    '            End If
    '        Catch ex As Exception
    '            DgvPrecios.CurrentRow.Cells(14).Value = CDbl(0).ToString("C")
    '        End Try

    '        Try
    '            If e.ColumnIndex = 15 Then
    '                If DgvPrecios.CurrentRow.Cells(15).Value = "" Then
    '                    DgvPrecios.CurrentRow.Cells(15).Value = DgvPrecios.CurrentRow.Cells(9).Value
    '                Else
    '                    DgvPrecios.CurrentRow.Cells(15).Value = CDbl(DgvPrecios.CurrentRow.Cells(15).Value).ToString("C")
    '                End If
    '            End If
    '        Catch ex As Exception
    '            DgvPrecios.CurrentRow.Cells(15).Value = CDbl(0).ToString("C")

    '        End Try

    '    End If

    'End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txtBuscarModulos.Text = ""
        txtBuscarModulos.Focus()
    End Sub

    Private Sub btnMedida_Click(sender As Object, e As EventArgs) Handles btnMedida.Click
        frm_buscar_medidas.ShowDialog(Me)
    End Sub

    Private Sub btnTipoItbis_Click(sender As Object, e As EventArgs) Handles btnTipoItbis.Click
        frm_buscar_itbis.ShowDialog(Me)
    End Sub

    Private Sub txtBuscarModulos_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarModulos.TextChanged
        If txtBuscarModulos.Text = "" Then
            Button6.Visible = False
        Else
            Button6.Visible = True
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        DeleteSelectedRows(GridView1)
    End Sub

    Private Sub DeleteSelectedRows(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim Row As DataRow
        Dim Rows() As DataRow
        Dim I As Integer
        ReDim Rows(View.SelectedRowsCount - 1)
        For I = 0 To View.SelectedRowsCount - 1
            Rows(I) = View.GetDataRow(View.GetSelectedRows(I))
        Next
        View.BeginSort()
        Try
            For Each Row In Rows
                Row.Delete()
            Next
        Finally
            View.EndSort()
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Private Sub cbxInventario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxInventario.SelectedIndexChanged
        If cbxInventario.Text = "Todos" Then
            txtInventarioCant.ReadOnly = True
        Else
            txtInventarioCant.ReadOnly = False
            txtInventarioCant.Focus()
            txtInventarioCant.SelectAll()
        End If
    End Sub

    Private Sub txtInventarioCant_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInventarioCant.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub txtIDTipoItbis_Leave(sender As Object, e As EventArgs) Handles txtIDTipoItbis.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Tipo from TipoItbis Where IDTipoItbis='" + txtIDTipoItbis.Text + "'", ConLibregco)
        txtTipoItbis.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtTipoItbis.Text = "" Then txtIDTipoItbis.Clear()

    End Sub

    Private Sub btnGarantia_Click(sender As Object, e As EventArgs) Handles btnGarantia.Click
        frm_buscar_tipo_garantia.ShowDialog(Me)
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

    Private Sub txtIDGarantia_Leave(sender As Object, e As EventArgs) Handles txtIDGarantia.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT TiempoGarantia FROM garantiaarticulos Where IDGarantiaArticulos='" + txtIDGarantia.Text + "'", ConLibregco)
        txtGarantia.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtGarantia.Text = "" Then txtIDGarantia.Clear()
    End Sub

    Private Sub txtPrecioC_Leave(sender As Object, e As EventArgs) Handles txtPrecioC.Leave
        Try
            If rdbPreciodirecto.Checked = True Then

                If txtPrecioC.Text = "" Then
                    txtPrecioC.Text = CDbl(0).ToString("C")
                Else
                    txtPrecioC.Text = CDbl(txtPrecioC.Text).ToString("C")
                End If

            Else

                If txtPrecioC.Text = "" Then
                    txtPrecioC.Text = CDbl(0).ToString("P2")
                Else

                    txtPrecioC.Text = CDbl((txtPrecioC.Text) / 100).ToString("P2")
                End If

            End If
        Catch ex As Exception
            txtPrecioC.Text = CDbl(0)
        End Try
    End Sub

    Private Sub txtPrecioD_Leave(sender As Object, e As EventArgs) Handles txtPrecioD.Leave
        Try
            If rdbPreciodirecto.Checked = True Then

                If txtPrecioD.Text = "" Then
                    txtPrecioD.Text = CDbl(0).ToString("C")
                Else
                    txtPrecioD.Text = CDbl(txtPrecioD.Text).ToString("C")
                End If

            Else

                If txtPrecioD.Text = "" Then
                    txtPrecioD.Text = CDbl(0).ToString("P2")
                Else

                    txtPrecioD.Text = CDbl((txtPrecioD.Text) / 100).ToString("P2")
                End If

            End If
        Catch ex As Exception
            txtPrecioD.Text = CDbl(0)
        End Try
    End Sub

    Private Sub txtCosto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCosto.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 45, 46
            Case 48 To 57
            Case 109
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCostoFinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCostoFinal.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 45, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtPrecioA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioA.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 45, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtPrecioB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioB.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 45, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtPrecioC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioC.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 45, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtPrecioD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecioD.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 45, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        CollapseMenu()

        If rdbPreciodirecto.Checked = False Then
            For i As Integer = 0 To GridView1.DataRowCount - 1
                If txtCosto.Text <> "" Then
                    If CDbl(Replace(txtCosto.Text, "%", "")) > 0 Then
                        GridView1.SetRowCellValue(i, "NCosto", RoundUp((CDbl(GridView1.GetRowCellValue(i, "Costo")) + (CDbl(GridView1.GetRowCellValue(i, "Costo")) * (CDbl(Replace(txtCosto.Text, "%", "")) / 100))), RedondearalEntero))
                    End If
                End If

                If txtCostoFinal.Text <> "" Then
                    If CDbl(Replace(txtCostoFinal.Text, "%", "")) > 0 Then
                        GridView1.SetRowCellValue(i, "NCostoFinal", RoundUp((CDbl(GridView1.GetRowCellValue(i, "CostoFinal")) + (CDbl(GridView1.GetRowCellValue(i, "CostoFinal")) * (CDbl(Replace(txtCostoFinal.Text, "%", "")) / 100))), RedondearalEntero))
                    End If
                End If

                If txtPrecioA.Text <> "" Then
                    If CDbl(Replace(txtPrecioA.Text, "%", "")) > 0 Then
                        GridView1.SetRowCellValue(i, "NPrecioA", RoundUp((CDbl(GridView1.GetRowCellValue(i, "PrecioA")) + (CDbl(GridView1.GetRowCellValue(i, "PrecioA")) * (CDbl(Replace(txtPrecioA.Text, "%", "")) / 100))), RedondearalEntero))
                    End If
                End If

                If txtPrecioB.Text <> "" Then
                    If CDbl(Replace(txtPrecioB.Text, "%", "")) > 0 Then
                        GridView1.SetRowCellValue(i, "NPrecioB", RoundUp((CDbl(GridView1.GetRowCellValue(i, "PrecioB")) + (CDbl(GridView1.GetRowCellValue(i, "PrecioB")) * (CDbl(Replace(txtPrecioB.Text, "%", "")) / 100))), RedondearalEntero))
                    End If
                End If

                If txtPrecioC.Text <> "" Then
                    If CDbl(Replace(txtPrecioC.Text, "%", "")) > 0 Then
                        GridView1.SetRowCellValue(i, "NPrecioC", RoundUp((CDbl(GridView1.GetRowCellValue(i, "PrecioC")) + (CDbl(GridView1.GetRowCellValue(i, "PrecioC")) * (CDbl(Replace(txtPrecioC.Text, "%", "")) / 100))), RedondearalEntero))
                    End If
                End If
                If txtPrecioD.Text <> "" Then
                    If CDbl(Replace(txtPrecioD.Text, "%", "")) > 0 Then
                        GridView1.SetRowCellValue(i, "NPrecioD", RoundUp((CDbl(GridView1.GetRowCellValue(i, "PrecioD")) + (CDbl(GridView1.GetRowCellValue(i, "PrecioD")) * (CDbl(Replace(txtPrecioD.Text, "%", "")) / 100))), RedondearalEntero))
                    End If
                End If

            Next

        Else
            For i As Integer = 0 To GridView1.DataRowCount - 1
                If txtCosto.Text <> "" Then
                    If CDbl(txtCosto.Text) > 0 Then
                        GridView1.SetRowCellValue(i, "NCosto", RoundUp(CDbl(txtCosto.Text), RedondearalEntero))
                    End If
                End If

                If txtCostoFinal.Text <> "" Then
                    If CDbl(txtCostoFinal.Text) > 0 Then
                        GridView1.SetRowCellValue(i, "NCostoFinal", RoundUp(CDbl(txtCostoFinal.Text), RedondearalEntero))
                    End If
                End If

                If txtPrecioA.Text <> "" Then
                    If CDbl(txtPrecioA.Text) > 0 Then
                        GridView1.SetRowCellValue(i, "NPrecioA", RoundUp(CDbl(txtPrecioA.Text), RedondearalEntero))
                    End If
                End If

                If txtPrecioB.Text <> "" Then
                    If CDbl(txtPrecioB.Text) > 0 Then
                        GridView1.SetRowCellValue(i, "NPrecioB", RoundUp(CDbl(txtPrecioB.Text), RedondearalEntero))
                    End If
                End If

                If txtPrecioC.Text <> "" Then
                    If CDbl(txtPrecioC.Text) > 0 Then
                        GridView1.SetRowCellValue(i, "NPrecioC", RoundUp(CDbl(txtPrecioC.Text), RedondearalEntero))
                    End If
                End If
                If txtPrecioD.Text <> "" Then
                    If CDbl(txtPrecioD.Text) > 0 Then
                        GridView1.SetRowCellValue(i, "NPrecioD", RoundUp(CDbl(txtPrecioD.Text), RedondearalEntero))
                    End If
                End If

            Next
        End If


    End Sub

    Private Sub txtIDMedida_Leave(sender As Object, e As EventArgs) Handles txtIDMedida.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Medida from Medida Where IDMedida='" + txtIDMedida.Text + "'", ConLibregco)
        txtMedida.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtMedida.Text = "" Then txtIDMedida.Clear()
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        CollapseMenu()

        If GridView1.DataRowCount > 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que guardar la modificación de precios y costos?", "Guardar precios y costos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                Con.Open()

               For i As Integer = 0 To GridView1.DataRowCount - 1

                    CheckedUptadesinPrinces(GridView1.GetRowCellValue(i, "IDPrecio"), GridView1.GetRowCellValue(i, "NCosto"), GridView1.GetRowCellValue(i, "NCostofinal"), GridView1.GetRowCellValue(i, "NPrecioA"), GridView1.GetRowCellValue(i, "NPrecioB"), GridView1.GetRowCellValue(i, "NPrecioC"), GridView1.GetRowCellValue(i, "NPrecioD"))

                    If CDbl(GridView1.GetRowCellValue(i, "NCosto")) > 0 Then
                        sqlQ = "UPDATE Libregco.PrecioArticulo SET Costo='" + CDbl(GridView1.GetRowCellValue(i, "NCosto")).ToString + "',CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(GridView1.GetRowCellValue(i, "NCosto"))).ToString + "' WHERE IDPrecios='" + CDbl(GridView1.GetRowCellValue(i, "IDPrecio")).ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                    End If

                    If CDbl(GridView1.GetRowCellValue(i, "NCostoFinal")) > 0 Then
                        sqlQ = "UPDATE Libregco.PrecioArticulo SET CostoFinal='" + CDbl(GridView1.GetRowCellValue(i, "NCostoFinal")).ToString + "' WHERE IDPrecios='" + CDbl(GridView1.GetRowCellValue(i, "IDPrecio")).ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                    End If

                    If CDbl(GridView1.GetRowCellValue(i, "NPrecioA")) > 0 Then
                        sqlQ = "UPDATE Libregco.PrecioArticulo SET PrecioCredito='" + CDbl(GridView1.GetRowCellValue(i, "NPrecioA")).ToString + "' WHERE IDPrecios='" + CDbl(GridView1.GetRowCellValue(i, "IDPrecio")).ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                    End If

                    If CDbl(GridView1.GetRowCellValue(i, "NPrecioB")) > 0 Then
                        sqlQ = "UPDATE Libregco.PrecioArticulo SET PrecioContado='" + CDbl(GridView1.GetRowCellValue(i, "NPrecioB")).ToString + "' WHERE IDPrecios='" + CDbl(GridView1.GetRowCellValue(i, "IDPrecio")).ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                    End If

                    If CDbl(GridView1.GetRowCellValue(i, "NPrecioC")) > 0 Then
                        sqlQ = "UPDATE Libregco.PrecioArticulo SET Precio3='" + CDbl(GridView1.GetRowCellValue(i, "NPrecioC")).ToString + "' WHERE IDPrecios='" + CDbl(GridView1.GetRowCellValue(i, "IDPrecio")).ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                    End If

                    If CDbl(GridView1.GetRowCellValue(i, "NPrecioD")) > 0 Then
                        sqlQ = "UPDATE Libregco.PrecioArticulo SET Precio4='" + CDbl(GridView1.GetRowCellValue(i, "NPrecioD")).ToString + "' WHERE IDPrecios='" + CDbl(GridView1.GetRowCellValue(i, "IDPrecio")).ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                    End If

                Next

                Con.Close()

                MessageBox.Show("Los precios han sido actualizados.", "Precios actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If

    End Sub

    Private Sub rdbPreciodirecto_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPreciodirecto.CheckedChanged
        CleanTextboxes()
    End Sub

    Private Sub chkPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrecios.CheckedChanged
        If chkPrecios.Checked Then
            GroupBox2.Enabled = False
        Else
            GroupBox2.Enabled = True
        End If
    End Sub

    Private Sub cbxTipoFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoFiltro.SelectedIndexChanged
        If cbxTipoFiltro.SelectedIndex = 0 Then
            Label29.Text = "<="
        ElseIf cbxTipoFiltro.SelectedIndex = 1 Then
            Label29.Text = "<"
        ElseIf cbxTipoFiltro.SelectedIndex = 2 Then
            Label29.Text = ">"
        ElseIf cbxTipoFiltro.SelectedIndex = 3 Then
            Label29.Text = ">="
        ElseIf cbxTipoFiltro.SelectedIndex = 4 Then
            Label29.Text = "<>"
        ElseIf cbxTipoFiltro.SelectedIndex = 5 Then
            Label29.Text = "="
        End If
    End Sub

    Private Sub cbxPrecio1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPrecio1.SelectedIndexChanged
        If cbxPrecio1.SelectedIndex = 0 Then
            cbxPrecio1.Tag = "Costo"
        ElseIf cbxPrecio1.SelectedIndex = 1 Then
            cbxPrecio1.Tag = "CostoFinal"
        ElseIf cbxPrecio1.SelectedIndex = 2 Then
            cbxPrecio1.Tag = "PrecioCredito"
        ElseIf cbxPrecio1.SelectedIndex = 3 Then
            cbxPrecio1.Tag = "PrecioContado"
        ElseIf cbxPrecio1.SelectedIndex = 4 Then
            cbxPrecio1.Tag = "Precio3"
        ElseIf cbxPrecio1.SelectedIndex = 5 Then
            cbxPrecio1.Tag = "Precio4"
        ElseIf cbxPrecio1.SelectedIndex = 6 Then
            cbxPrecio1.Tag = "PrecioBlackFriday"
        End If
    End Sub

    Private Sub CheckedListBox2_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles CheckedListBox2.ItemCheck
        For Each itm As String In CheckedListBox2.Items
            Dim index As Integer = CheckedListBox2.Items.IndexOf(itm)

            If CheckedListBox2.GetItemCheckState(e.Index) = CheckState.Checked Then
                GridView1.Columns(e.Index).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            Else
                GridView1.Columns(e.Index).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End If

        Next
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        If chkSeleccionarTodo.Checked = True Then
            For i As Integer = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemCheckState(i, CheckState.Checked)
            Next

        Else
            For i As Integer = 0 To CheckedListBox1.Items.Count - 1
                CheckedListBox1.SetItemCheckState(i, CheckState.Unchecked)
            Next
        End If
    End Sub

    Private Sub cbxPrecio2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPrecio2.SelectedIndexChanged
        If cbxPrecio2.SelectedIndex = 0 Then
            cbxPrecio2.Tag = "Costo"
        ElseIf cbxPrecio2.SelectedIndex = 1 Then
            cbxPrecio2.Tag = "CostoFinal"
        ElseIf cbxPrecio2.SelectedIndex = 2 Then
            cbxPrecio2.Tag = "PrecioCredito"
        ElseIf cbxPrecio2.SelectedIndex = 3 Then
            cbxPrecio2.Tag = "PrecioContado"
        ElseIf cbxPrecio2.SelectedIndex = 4 Then
            cbxPrecio2.Tag = "Precio3"
        ElseIf cbxPrecio2.SelectedIndex = 5 Then
            cbxPrecio2.Tag = "Precio4"
        ElseIf cbxPrecio2.SelectedIndex = 6 Then
            cbxPrecio2.Tag = "PrecioBlackFriday"
        End If
    End Sub

    Private Sub NavigationPane2_Leave(sender As Object, e As EventArgs) Handles NavigationPane2.Leave
        CollapseMenu()
    End Sub


    Private Sub PrevisualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrevisualizarToolStripMenuItem.Click
        ' Check whether the GridControl can be previewed. 
        If Not GridControl1.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error")
        Else
            GridView1.ShowPrintPreview()
        End If
    End Sub

    Private Sub ImpresiónDirectaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpresiónDirectaToolStripMenuItem.Click
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

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
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

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Clipboard.SetText(GridView1.GetFocusedDisplayText())
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Dim str As String = ""
        For i As Integer = 0 To GridView1.Columns.Count - 1
            If GridView1.Columns(i).Visible = True Then
                str = str & " ׀ " & GridView1.GetRowCellDisplayText(GridView1.FocusedRowHandle, GridView1.Columns(i))
            End If
        Next

        Clipboard.SetText(str)

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
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

    Private Sub HistóricoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistóricoToolStripMenuItem.Click
        frm_historial_modificaciones_precios.ShowDialog(Me)
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Dim str As String = ""
        For i As Integer = 0 To GridView1.RowCount - 1
            str = str & vbNewLine & GridView1.GetRowCellValue(i, GridView1.FocusedColumn)
        Next

        Clipboard.SetText(str)
    End Sub
End Class