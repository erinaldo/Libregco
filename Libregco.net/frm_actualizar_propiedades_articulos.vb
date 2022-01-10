Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.DragDrop
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors

Public Class frm_actualizar_propiedades_articulos
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim SelectCommand As String = "SELECT Articulos.RutaFoto,Articulos.IDArticulo,Articulos.Descripcion,Articulos.Referencia,Articulos.IDTipoProducto,Articulos.IDSuplidor,Departamentos.IDDepartamento,Categoria.IDCategoria,Articulos.IDSubCategoria,Articulos.IDMarca,Articulos.IDParentesco,Articulos.IDGarantia,IDItbis,CodigoBarra,Serial,Promocion,Devolucion,VenderCosto,Descontinuar,BloqueoCredito,PreAlertar,NoPagoTarjeta,Revisado,Articulos.Desactivar,(SELECT coalesce(group_concat(IDPropiedad_propiedad separator ', '),'') FROM libregco.articulos_has_propiedad inner join libregco.articulos_propiedad on articulos_has_propiedad.IDPropiedad_propiedad=articulos_propiedad.idArticulos_propiedad  WHERE Articulos_has_propiedad.IDArticulo=Articulos.IDArticulo) as Grupo FROM libregco.PrecioArticulo INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Categoria on Articulos.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.departamentos on Articulos.IDDepartamento=Departamentos.IDDepartamento"
    Dim FullCommand As String
    Dim Permisos, PermisosArticulos As New ArrayList

    Friend TablaArticulos As DataTable
    Dim RepositorySecondID As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}

    Dim RepositoryTipo As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit() With {.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard, .BestFitWidth = True}
    Dim RepositoryDescrip As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit() With {.WordWrap = True, .AcceptsReturn = False, .AcceptsTab = False}
    Dim RepositorySuplidor As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
    Dim RepositoryDepartamento As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
    Dim RepositoryCategoria As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
    Dim RepositorySubCategoria As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
    Dim RepositoryMarca As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
    Dim RepositoryParentezco As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
    Dim RepositoryGarantia As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
    Dim RepositoryItbis As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
    Dim RepositoryChkSerial As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}
    Dim RepositoryChkPromocion As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}
    Dim RepositorychkNoDevolucion As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}
    Dim RepositorychkVentaCosto As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}
    Dim RepositoryChkDescontinuar As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}
    Dim RepositoryChkBloqueoCredito As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}
    Dim RepositoryChkPrealertar As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}
    Dim RepositoryChkNoPagoTarjeta As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}
    Dim RepositoryChkRevisado As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}
    Dim RepositoryChkNulo As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}
    Dim RepositoryPropiedades As New DevExpress.XtraEditors.Repository.RepositoryItemTokenEdit() With {.ShowDropDown = True, .CheckMode = DevExpress.XtraEditors.TokenEditCheckMode.Single, .PopupFilterMode = DevExpress.XtraEditors.TokenEditPopupFilterMode.Contains}
    Dim RepositoryImagen As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit() With {.PictureAlignment = ContentAlignment.MiddleCenter, .SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom, .ShowMenu = False}

    Dim stop_recursion As Boolean = True
    Dim ChangingfromTreeview As Boolean = True
    Private clone As DataView
    Private Sub frm_actualizar_propiedades_articulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        PermisosArticulos = PasarPermisos(3)
        For i As Integer = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemCheckState(i, CheckState.Checked)
        Next
        SpinEdit1.Value = CInt(DTConfiguracion.Rows(28 - 1).Item("Value2Int"))
        SetArticulosTable()
        LimpiarDatos()
        CargarCbxs()
        RefrescarTabla()

        AddHandler RepositorySubCategoria.EditValueChanged, AddressOf OnEditValueChangedSubCategoria
        AddHandler RepositoryCategoria.EditValueChanged, AddressOf OnEditValueChangedCategoria
        AddHandler RepositoryChkSerial.EditValueChanged, AddressOf OnEditValueChanged
        AddHandler RepositoryChkPromocion.EditValueChanged, AddressOf OnEditValueChanged
        AddHandler RepositorychkNoDevolucion.EditValueChanged, AddressOf OnEditValueChanged
        AddHandler RepositorychkVentaCosto.EditValueChanged, AddressOf OnEditValueChanged
        AddHandler RepositoryChkDescontinuar.EditValueChanged, AddressOf OnEditValueChanged
        AddHandler RepositoryChkBloqueoCredito.EditValueChanged, AddressOf OnEditValueChanged
        AddHandler RepositoryChkPrealertar.EditValueChanged, AddressOf OnEditValueChanged
        AddHandler RepositoryChkNoPagoTarjeta.EditValueChanged, AddressOf OnEditValueChanged
        AddHandler RepositoryChkRevisado.EditValueChanged, AddressOf OnEditValueChanged
        AddHandler RepositoryChkNulo.EditValueChanged, AddressOf OnEditValueChanged
        AddHandler RepositoryPropiedades.EditValueChanged, AddressOf onTokenValidate
        AddHandler RepositoryPropiedades.TokenRemoved, AddressOf onTokenRemoved
    End Sub

    Private Sub onTokenRemoved(ByVal sender As Object, ByVal e As EventArgs)
        If GridView1.FocusedRowHandle >= 0 Then
            Dim words As String() = CType(sender, TokenEdit).EditValue.Split(New Char() {" "c})
            Dim FilasenPropiedades As New ArrayList

            For Each word As String In words
                FilasenPropiedades.Add(word.Replace(",", "").Trim.ToString)
            Next

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT idArticulos_has_propiedad,IDPropiedad_propiedad,Propiedad FROM libregco.articulos_has_propiedad inner join libregco.articulos_propiedad on articulos_has_propiedad.IDPropiedad_propiedad=articulos_propiedad.idArticulos_propiedad where articulos_has_propiedad.IDArticulo='" + GridView1.GetFocusedRowCellValue("ID").ToString + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "articulos_has_propiedad")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("articulos_has_propiedad")

            For Each dt As DataRow In Tabla.Rows
                If FilasenPropiedades.Contains(dt.Item("IDPropiedad_propiedad").ToString) = False Then
                    ConLibregco.Open()
                    cmd = New MySqlCommand("Delete FROM articulos_has_propiedad WHERE idArticulos_has_propiedad='" + dt.Item("idArticulos_has_propiedad").ToString + "'", ConLibregco)
                    cmd.ExecuteNonQuery()
                    ConLibregco.Close()

                    ChangingfromTreeview = False

                    Dim nodes As TreeNode() = TreeView1.Nodes.Find(dt.Item("IDPropiedad_propiedad").ToString, True)
                    If nodes.Length > 0 Then
                        nodes(0).Checked = False
                    End If
                End If
            Next

            Tabla.Dispose()

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
        End If

    End Sub

    Private Sub onTokenValidate(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If GridView1.FocusedRowHandle >= 0 Then
                If GridView1.Columns.Count > 0 Then
                    Dim t As String = CType(sender, TokenEdit).EditValue.ToString.Replace("{", "").Replace("}", "")
                    Dim words As String() = t.Split(New Char() {","c})
                    Dim cmd1 As New MySqlCommand

                    Con.Open()
                    For Each word As String In words
                        If word.Trim.ToString <> "" Then
                            cmd1 = New MySqlCommand("SELECT count(idArticulos_has_propiedad) FROM libregco.articulos_has_propiedad where IDArticulo='" + GridView1.GetFocusedRowCellValue("ID").ToString + "' AND IDPropiedad_propiedad='" + word.Trim.ToString + "'", Con)
                            If Convert.ToInt16(cmd1.ExecuteScalar()) = 0 Then
                                cmd1 = New MySqlCommand("INSERT INTO articulos_has_propiedad (IDPropiedad_propiedad,IDArticulo) VALUES ('" + word.Trim.ToString + "','" + GridView1.GetFocusedRowCellValue(GridView1.Columns("ID")).ToString + "')", Con)
                                cmd1.ExecuteNonQuery()
                            End If
                        End If

                        Dim nodes As TreeNode() = TreeView1.Nodes.Find(word.Trim.ToString, True)

                        If nodes.Length > 0 Then
                            nodes(0).Checked = True
                        End If
                    Next

                    Con.Close()

                    cmd1.Dispose()

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
                End If
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub OnEditValueChangedCategoria(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim dstemp As New DataSet

            ConLibregco.Open()
            cmd = New MySqlCommand("Select Categoria.IDCategoria,Categoria.Categoria,Categoria.IDDepartamento FROM libregco.categoria INNER JOIN Libregco.Departamentos On Categoria.IDDepartamento=Departamentos.IDDepartamento Where Categoria.IDCategoria='" + CType(sender, DevExpress.XtraEditors.LookUpEdit).EditValue.ToString + "' ORDER BY Categoria ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "categoria")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("categoria")
            Dim myRow() As DataRow = TablaArticulos.Select("ID = '" + GridView1.GetFocusedRowCellValue(GridView1.Columns("ID")).ToString + "'")

            myRow(0)("Departamento") = Tabla.Rows(0).Item("IDDepartamento")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub OnEditValueChangedSubCategoria(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim dstemp As New DataSet

            ConLibregco.Open()
            cmd = New MySqlCommand("Select Subcategoria.IDSubcategoria,SubCategoria,Categoria.IDCategoria,Categoria,Departamentos.IDDepartamento,Departamento FROM libregco.subcategoria inner join libregco.categoria On subcategoria.idcategoria=categoria.idcategoria inner join libregco.departamentos On categoria.iddepartamento=departamentos.iddepartamento where SubCategoria.IDSubcategoria= '" + CType(sender, DevExpress.XtraEditors.LookUpEdit).EditValue.ToString + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "Subcategoria")
            ConLibregco.Close()

            Dim Tabla As DataTable = dstemp.Tables("Subcategoria")
            Dim myRow() As DataRow = TablaArticulos.Select("ID = '" + GridView1.GetFocusedRowCellValue(GridView1.Columns("ID")).ToString + "'")

            myRow(0)("Departamento") = Tabla.Rows(0).Item("IDDepartamento")
            myRow(0)("Categoria") = Tabla.Rows(0).Item("IDCategoria")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub OnEditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        GridView1.PostEditor()
    End Sub
    Private Sub SetArticulosTable()
        TablaArticulos = New DataTable("Articulos")
        TablaArticulos.Columns.Add("Imagen", System.Type.GetType("System.Object"))
        TablaArticulos.Columns.Add("ID", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Referencia", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Tipo", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Suplidor", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Departamento", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Categoria", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Subcategoria", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Marca", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Parentezco", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Garantia", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Itbis", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("CodigoBarra", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Serial", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Promocion", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("NoDevolucion", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("VentaCosto", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Descontinuar", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("BloqueoCredito", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Prealertar", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("NoPagoTarjeta", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Revisado", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Nulo", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Propiedades", System.Type.GetType("System.Object"))
        GridControl1.DataSource = TablaArticulos

        GridView1.Columns("Imagen").ColumnEdit = RepositoryImagen
        GridView1.Columns("ID").ColumnEdit = RepositorySecondID
        GridView1.Columns("Descripcion").ColumnEdit = RepositoryDescrip
        GridView1.Columns("Tipo").ColumnEdit = RepositoryTipo
        GridView1.Columns("Suplidor").ColumnEdit = RepositorySuplidor
        GridView1.Columns("Departamento").ColumnEdit = RepositoryDepartamento
        GridView1.Columns("Categoria").ColumnEdit = RepositoryCategoria
        GridView1.Columns("Subcategoria").ColumnEdit = RepositorySubCategoria
        GridView1.Columns("Marca").ColumnEdit = RepositoryMarca
        GridView1.Columns("Parentezco").ColumnEdit = RepositoryParentezco
        GridView1.Columns("Garantia").ColumnEdit = RepositoryGarantia
        GridView1.Columns("Itbis").ColumnEdit = RepositoryItbis
        GridView1.Columns("Serial").ColumnEdit = RepositoryChkSerial
        GridView1.Columns("Promocion").ColumnEdit = RepositoryChkPromocion
        GridView1.Columns("NoDevolucion").ColumnEdit = RepositorychkNoDevolucion
        GridView1.Columns("VentaCosto").ColumnEdit = RepositorychkVentaCosto
        GridView1.Columns("Descontinuar").ColumnEdit = RepositoryChkDescontinuar
        GridView1.Columns("BloqueoCredito").ColumnEdit = RepositoryChkBloqueoCredito
        GridView1.Columns("Prealertar").ColumnEdit = RepositoryChkPrealertar
        GridView1.Columns("NoPagoTarjeta").ColumnEdit = RepositoryChkNoPagoTarjeta
        GridView1.Columns("Revisado").ColumnEdit = RepositoryChkRevisado
        GridView1.Columns("Nulo").ColumnEdit = RepositoryChkNulo
        GridView1.Columns("Propiedades").ColumnEdit = RepositoryPropiedades

        'Estilos
        GridView1.Columns("Imagen").Width = 80
        GridView1.Columns("ID").Caption = "Código"
        GridView1.Columns("ID").Width = 80
        GridView1.Columns("Descripcion").Caption = "Descripción"
        GridView1.Columns("Descripcion").Width = 400
        GridView1.Columns("Referencia").Width = 180
        GridView1.Columns("Tipo").Width = 200
        GridView1.Columns("Suplidor").Width = 350
        GridView1.Columns("Departamento").Width = 200
        GridView1.Columns("Categoria").Width = 200
        GridView1.Columns("Subcategoria").Width = 200
        GridView1.Columns("Parentezco").Width = 200
        GridView1.Columns("Marca").Width = 200
        GridView1.Columns("Garantia").Width = 200
        GridView1.Columns("Itbis").Width = 200
        GridView1.Columns("CodigoBarra").Width = 180
        GridView1.Columns("Categoria").Caption = "Categoría"
        GridView1.Columns("Subcategoria").Caption = "Subcategoría"
        GridView1.Columns("Garantia").Caption = "Garantía"
        GridView1.Columns("Promocion").Caption = "Promoción"
        GridView1.Columns("CodigoBarra").Caption = "Código de barra"
        GridView1.Columns("NoDevolucion").Caption = "No devolución"
        GridView1.Columns("VentaCosto").Caption = "Vender al costo"
        GridView1.Columns("BloqueoCredito").Caption = "Bloqueo a crédito"
        GridView1.Columns("NoPagoTarjeta").Caption = "No pago tarjeta"
        GridView1.Columns("Serial").Width = 100
        GridView1.Columns("Promocion").Width = 100
        GridView1.Columns("NoDevolucion").Width = 100
        GridView1.Columns("VentaCosto").Width = 100
        GridView1.Columns("Descontinuar").Width = 100
        GridView1.Columns("BloqueoCredito").Width = 100
        GridView1.Columns("Prealertar").Width = 100
        GridView1.Columns("NoPagoTarjeta").Width = 100
        GridView1.Columns("Revisado").Width = 100
        GridView1.Columns("Nulo").Width = 100
        GridView1.Columns("Propiedades").Width = 450
    End Sub

    Private Sub CargarCbxs()
        FillRepositoryTipo()
        FillRepositorySuplidor()
        FillRepositoryDepartamento()
        FillRepositoryCategoria()
        FillRepositorySubCategoria()
        FillRepositoryMarca()
        FillRepositoryParentensco()
        FillRepositoryGarantia()
        FillRepositoryItbis()
        FillPropiedades()
    End Sub

    Private Sub FillPropiedades()
        Try

            RepositoryPropiedades.Tokens.Clear()
            TKPropiedades.Properties.Tokens.Clear()

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

                RepositoryPropiedades.Tokens.Add(Tk)
                TKPropiedades.Properties.Tokens.Add(Tk)

            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillRepositoryTipo()
        Dim dstemp As New DataSet


        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDTipoArticulo,tipoarticulo.TipoArticulo FROM Libregco.TipoArticulo Order by TipoArticulo ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "TipoArticulo")
        ConLibregco.Close()

        Dim TablaPropiedades As DataTable = dstemp.Tables("TipoArticulo")

        RepositoryTipo.DataSource = TablaPropiedades
        RepositoryTipo.ValueMember = "IDTipoArticulo"
        RepositoryTipo.DisplayMember = "TipoArticulo"
        RepositoryTipo.PopulateColumns()
        RepositoryTipo.Columns(RepositoryTipo.ValueMember).Visible = False
        RepositoryTipo.ShowHeader = False

        ILUETipo.Properties.DataSource = TablaPropiedades
        ILUETipo.Properties.ValueMember = "IDTipoArticulo"
        ILUETipo.Properties.DisplayMember = "TipoArticulo"
        ILUETipo.Properties.PopulateColumns()
        ILUETipo.Properties.Columns(ILUETipo.Properties.ValueMember).Visible = False
        ILUETipo.Properties.ShowHeader = False
    End Sub


    Private Sub FillRepositorySuplidor()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("Select Suplidor.IDSuplidor,Suplidor.Suplidor FROM Libregco.Suplidor ORDER BY Suplidor asc", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Suplidor")
        ConLibregco.Close()

        Dim TablaPropiedades As DataTable = dstemp.Tables("Suplidor")

        RepositorySuplidor.DataSource = TablaPropiedades
        RepositorySuplidor.ValueMember = "IDSuplidor"
        RepositorySuplidor.DisplayMember = "Suplidor"

        RepositorySuplidor.PopulateColumns()
        RepositorySuplidor.Columns(RepositorySuplidor.ValueMember).Visible = False
        RepositorySuplidor.ShowHeader = False
        ILUESuplidor.Properties.DataSource = TablaPropiedades
        ILUESuplidor.Properties.ValueMember = "IDSuplidor"
        ILUESuplidor.Properties.DisplayMember = "Suplidor"
        ILUESuplidor.Properties.PopulateColumns()
        ILUESuplidor.Properties.Columns(ILUESuplidor.Properties.ValueMember).Visible = False
        ILUESuplidor.Properties.ShowHeader = False
        ILUESuplidor.Visible = True
    End Sub

    Private Sub FillRepositoryDepartamento()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDDepartamento,Departamento FROM libregco.departamentos Order by Departamento ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "departamentos")
        ConLibregco.Close()

        Dim TablaPropiedades As DataTable = dstemp.Tables("departamentos")

        RepositoryDepartamento.DataSource = TablaPropiedades
        RepositoryDepartamento.ValueMember = "IDDepartamento"
        RepositoryDepartamento.DisplayMember = "Departamento"

        RepositoryDepartamento.PopulateColumns()
        RepositoryDepartamento.Columns(RepositoryDepartamento.ValueMember).Visible = False
        RepositoryDepartamento.ShowHeader = False


        ILUEDepartamento.Properties.DataSource = TablaPropiedades
        ILUEDepartamento.Properties.ValueMember = "IDDepartamento"
        ILUEDepartamento.Properties.DisplayMember = "Departamento"
        ILUEDepartamento.Properties.PopulateColumns()
        ILUEDepartamento.Properties.Columns(ILUEDepartamento.Properties.ValueMember).Visible = False
        ILUEDepartamento.Properties.ShowHeader = False
    End Sub

    Private Sub FillRepositoryCategoria()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCategoria,categoria,categoria.IDDepartamento FROM libregco.categoria inner join Libregco.Departamentos on categoria.IDDepartamento=Departamentos.IDDepartamento Order by Departamento ASC,Categoria ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "categoria")
        ConLibregco.Close()

        Dim TablaPropiedades As DataTable = dstemp.Tables("categoria")

        RepositoryCategoria.DataSource = TablaPropiedades
        RepositoryCategoria.ValueMember = "IDCategoria"
        RepositoryCategoria.DisplayMember = "categoria"

        RepositoryCategoria.PopulateColumns()
        RepositoryCategoria.Columns(RepositoryCategoria.ValueMember).Visible = False
        RepositoryCategoria.Columns(2).Visible = False
        RepositoryCategoria.ShowHeader = False

        ILUECategoria.Properties.DataSource = TablaPropiedades
        ILUECategoria.Properties.ValueMember = "IDCategoria"
        ILUECategoria.Properties.DisplayMember = "categoria"
        ILUECategoria.Properties.PopulateColumns()
        ILUECategoria.Properties.Columns(ILUECategoria.Properties.ValueMember).Visible = False
        ILUECategoria.Properties.ShowHeader = False
    End Sub

    Private Sub FillRepositorySubCategoria()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDSubCategoria,SubCategoria,SubCategoria.IDCategoria FROM Libregco.SubCategoria inner join libregco.categoria on subcategoria.idcategoria=categoria.idcategoria inner join Libregco.Departamentos on categoria.IDDepartamento=Departamentos.IDDepartamento Order by Departamento ASC,Categoria ASC,SubCategoria ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "SubCategoria")
        ConLibregco.Close()

        Dim TablaPropiedades As DataTable = dstemp.Tables("SubCategoria")

        RepositorySubCategoria.DataSource = TablaPropiedades
        RepositorySubCategoria.ValueMember = "IDSubCategoria"
        RepositorySubCategoria.DisplayMember = "SubCategoria"

        RepositorySubCategoria.PopulateColumns()
        RepositorySubCategoria.Columns(RepositorySubCategoria.ValueMember).Visible = False
        RepositorySubCategoria.Columns(2).Visible = False
        RepositorySubCategoria.ShowHeader = False

        ILUESubCategoria.Properties.DataSource = TablaPropiedades
        ILUESubCategoria.Properties.ValueMember = "IDSubCategoria"
        ILUESubCategoria.Properties.DisplayMember = "SubCategoria"
        ILUESubCategoria.Properties.PopulateColumns()
        ILUESubCategoria.Properties.Columns(ILUESubCategoria.Properties.ValueMember).Visible = False
        ILUESubCategoria.Properties.ShowHeader = False
    End Sub

    Private Sub FillRepositoryMarca()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDMarca,Marca.Marca FROM Libregco.Marca order by Marca ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Marca")
        ConLibregco.Close()

        Dim TablaPropiedades As DataTable = dstemp.Tables("Marca")

        RepositoryMarca.DataSource = TablaPropiedades
        RepositoryMarca.ValueMember = "IDMarca"
        RepositoryMarca.DisplayMember = "Marca"

        RepositoryMarca.PopulateColumns()
        RepositoryMarca.Columns(RepositoryMarca.ValueMember).Visible = False
        RepositoryMarca.ShowHeader = False


        ILUEMarca.Properties.DataSource = TablaPropiedades
        ILUEMarca.Properties.ValueMember = "IDMarca"
        ILUEMarca.Properties.DisplayMember = "Marca"
        ILUEMarca.Properties.PopulateColumns()
        ILUEMarca.Properties.Columns(ILUEMarca.Properties.ValueMember).Visible = False
        ILUEMarca.Properties.ShowHeader = False
    End Sub

    Private Sub FillRepositoryParentensco()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDParentesco,parentescoproducto.Descripcion FROM Libregco.parentescoproducto", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "parentescoproducto")
        ConLibregco.Close()

        Dim TablaPropiedades As DataTable = dstemp.Tables("parentescoproducto")

        RepositoryParentezco.DataSource = TablaPropiedades
        RepositoryParentezco.ValueMember = "IDParentesco"
        RepositoryParentezco.DisplayMember = "Descripcion"

        RepositoryParentezco.PopulateColumns()
        RepositoryParentezco.Columns(RepositoryParentezco.ValueMember).Visible = False
        RepositoryParentezco.ShowHeader = False

        ILUEParentesco.Properties.DataSource = TablaPropiedades
        ILUEParentesco.Properties.ValueMember = "IDParentesco"
        ILUEParentesco.Properties.DisplayMember = "Descripcion"
        ILUEParentesco.Properties.PopulateColumns()
        ILUEParentesco.Properties.Columns(ILUEParentesco.Properties.ValueMember).Visible = False
        ILUEParentesco.Properties.ShowHeader = False
    End Sub


    Private Sub FillRepositoryGarantia()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDGarantiaArticulos,GarantiaArticulos.TiempoGarantia FROM Libregco.GarantiaArticulos Order by Dias ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "GarantiaArticulos")
        ConLibregco.Close()

        Dim TablaPropiedades As DataTable = dstemp.Tables("GarantiaArticulos")

        RepositoryGarantia.DataSource = TablaPropiedades
        RepositoryGarantia.ValueMember = "IDGarantiaArticulos"
        RepositoryGarantia.DisplayMember = "TiempoGarantia"

        RepositoryGarantia.PopulateColumns()
        RepositoryGarantia.Columns(RepositoryGarantia.ValueMember).Visible = False
        RepositoryGarantia.ShowHeader = False

        ILUEGarantia.Properties.DataSource = TablaPropiedades
        ILUEGarantia.Properties.ValueMember = "IDGarantiaArticulos"
        ILUEGarantia.Properties.DisplayMember = "TiempoGarantia"
        ILUEGarantia.Properties.PopulateColumns()
        ILUEGarantia.Properties.Columns(ILUEGarantia.Properties.ValueMember).Visible = False
        ILUEGarantia.Properties.ShowHeader = False
    End Sub

    Private Sub FillRepositoryItbis()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoItbis,Tipo FROM libregco.tipoitbis ORDER BY Itbis asc", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "tipoitbis")
        ConLibregco.Close()

        Dim TablaPropiedades As DataTable = dstemp.Tables("tipoitbis")

        RepositoryItbis.DataSource = TablaPropiedades
        RepositoryItbis.ValueMember = "IDTipoItbis"
        RepositoryItbis.DisplayMember = "Tipo"

        RepositoryItbis.PopulateColumns()
        RepositoryItbis.Columns(RepositoryItbis.ValueMember).Visible = False
        RepositoryItbis.ShowHeader = False

        ILUEItbis.Properties.DataSource = TablaPropiedades
        ILUEItbis.Properties.ValueMember = "IDTipoItbis"
        ILUEItbis.Properties.DisplayMember = "Tipo"
        ILUEItbis.Properties.PopulateColumns()
        ILUEItbis.Properties.Columns(ILUEItbis.Properties.ValueMember).Visible = False
        ILUEItbis.Properties.ShowHeader = False
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
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
                        Str = Str & " AND Articulos.Desactivar=1"
                        Paremeter += 1
                    ElseIf cbxEstado.Text = "Nulos" Then
                        Str = Str & " AND Articulos.Desactivar=0"
                        Paremeter += 1
                    End If
                Else
                    If cbxEstado.Text = "Sólo Activos" Then
                        Str = Str & " Articulos.Desactivar=1"
                        Paremeter += 1
                    ElseIf cbxEstado.Text = "Nulos" Then
                        Str = Str & " Articulos.Desactivar=0"
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


            FullCommand = Str & " ORDER BY Articulos.Descripcion ASC LIMIT " & CInt(SpinEdit1.Value).ToString

        Else
            FullCommand = Str & " ORDER BY Articulos.Descripcion ASC LIMIT " & CInt(SpinEdit1.Value).ToString
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

    Private Sub RefrescarTabla()
        'Try
        Dim ds As New DataSet
        TablaArticulos.Rows.Clear()

        ConstructorSQL()

        Con.Open()
        cmd = New MySqlCommand(FullCommand, Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "Articulos")
        Con.Close()



        If frm_inicio.chkPreviewMode.CheckState = CheckState.Checked Then
            Dim img As Image
            For Each dt As DataRow In ds.Tables("Articulos").Rows

                If dt.Item("RutaFoto") <> "" Then
                    If System.IO.File.Exists(dt.Item("RutaFoto")) = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(dt.Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                        img = ResizeImage(System.Drawing.Image.FromStream(wFile), 45)
                        wFile.Close()
                    Else
                        img = ResizeImage(My.Resources.No_Image, 45)
                    End If
                Else
                    img = ResizeImage(My.Resources.No_Image, 45)
                End If

                TablaArticulos.Rows.Add(img, dt.Item(1), dt.Item(2), dt.Item(3), dt.Item(4), dt.Item(5), dt.Item(6), dt.Item(7), dt.Item(8), dt.Item(9), dt.Item(10), dt.Item(11), dt.Item(12), dt.Item(13), dt.Item(14), dt.Item(15), dt.Item(16), dt.Item(17), dt.Item(18), dt.Item(19), dt.Item(20), dt.Item(21), dt.Item(22), dt.Item(23), dt.Item(24))
            Next

        Else
            CheckedListBox1.SetItemCheckState(0, CheckState.Unchecked)

            For Each dt As DataRow In ds.Tables("Articulos").Rows
                TablaArticulos.Rows.Add(Nothing, dt.Item(1), dt.Item(2), dt.Item(3), dt.Item(4), dt.Item(5), dt.Item(6), dt.Item(7), dt.Item(8), dt.Item(9), dt.Item(10), dt.Item(11), dt.Item(12), dt.Item(13), dt.Item(14), dt.Item(15), dt.Item(16), dt.Item(17), dt.Item(18), dt.Item(19), dt.Item(20), dt.Item(21), dt.Item(22), dt.Item(23), dt.Item(24))
            Next
        End If

        ds.Dispose()

        'Catch ex As Exception
        '    Con.Close()
        'End Try
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        'Try


        If GridView1.DataRowCount > 0 Then
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ConLibregco.Open()

            For i As Integer = 0 To GridView1.DataRowCount - 1
                sqlQ = "UPDATE Libregco.Articulos SET Descripcion='" + GridView1.GetRowCellValue(i, "Descripcion").ToString + "',Referencia='" + GridView1.GetRowCellValue(i, "Referencia").ToString + "',IDTipoProducto='" + GridView1.GetRowCellValue(i, "Tipo").ToString + "',IDSuplidor='" + GridView1.GetRowCellValue(i, "Suplidor").ToString + "',IDDepartamento='" + GridView1.GetRowCellValue(i, "Departamento").ToString + "',IDCategoria='" + GridView1.GetRowCellValue(i, "Categoria").ToString + "',IDSubCategoria='" + GridView1.GetRowCellValue(i, "Subcategoria").ToString + "',IDMarca='" + GridView1.GetRowCellValue(i, "Marca").ToString + "',IDParentesco='" + GridView1.GetRowCellValue(i, "Parentezco").ToString + "',IDGarantia='" + GridView1.GetRowCellValue(i, "Garantia").ToString + "',IDItbis='" + GridView1.GetRowCellValue(i, "Itbis").ToString + "',CodigoBarra='" + GridView1.GetRowCellValue(i, "CodigoBarra").ToString + "',Serial='" + GridView1.GetRowCellValue(i, "Serial").ToString + "',Promocion='" + GridView1.GetRowCellValue(i, "Promocion").ToString + "',Devolucion='" + GridView1.GetRowCellValue(i, "NoDevolucion").ToString + "',VenderCosto='" + GridView1.GetRowCellValue(i, "VentaCosto").ToString + "',Descontinuar='" + GridView1.GetRowCellValue(i, "Descontinuar").ToString + "',BloqueoCredito='" + GridView1.GetRowCellValue(i, "BloqueoCredito").ToString + "',PreAlertar='" + GridView1.GetRowCellValue(i, "Prealertar").ToString + "',NoPagoTarjeta='" + GridView1.GetRowCellValue(i, "NoPagoTarjeta").ToString + "',Revisado='" + GridView1.GetRowCellValue(i, "Revisado").ToString + "',Desactivar='" + GridView1.GetRowCellValue(i, "Nulo").ToString + "' WHERE IDArticulo= (" + GridView1.GetRowCellValue(i, "ID").ToString + ")"
                cmd = New MySqlCommand(sqlQ, ConLibregco)
                cmd.ExecuteNonQuery()
            Next

            ConLibregco.Close()
            RefrescarTabla()
            MessageBox.Show("Se han guardado exitosamente los cambios realizados a los artículos seleccionados.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        End If

        'Catch ex As Exception
        '    Con.Close()
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        txtBuscarModulos.Text = ""
        txtBuscarModulos.Focus()
    End Sub


    Private Sub txtBuscarModulos_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarModulos.TextChanged
        If txtBuscarModulos.Text = "" Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
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
        TKPropiedades.EditValue = ""

        TreeView1.CollapseAll()
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

    Private Sub txtIDMedida_Leave(sender As Object, e As EventArgs) Handles txtIDMedida.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Medida from Medida Where IDMedida='" + txtIDMedida.Text + "'", ConLibregco)
        txtMedida.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtMedida.Text = "" Then txtIDMedida.Clear()
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

    Private Sub btnMedida_Click(sender As Object, e As EventArgs) Handles btnMedida.Click
        frm_buscar_medidas.ShowDialog(Me)
    End Sub

    Private Sub btnTipoItbis_Click(sender As Object, e As EventArgs) Handles btnTipoItbis.Click
        frm_buscar_itbis.ShowDialog(Me)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ConstructorSQL()
        RefrescarTabla()
        TreeView1.CollapseAll()
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


    Private Sub ILUETipo_EditValueChanged(sender As Object, e As EventArgs) Handles ILUETipo.EditValueChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Tipo") = ILUETipo.EditValue
        Next
    End Sub

    Private Sub ILUESuplidor_EditValueChanged(sender As Object, e As EventArgs) Handles ILUESuplidor.EditValueChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Suplidor") = ILUESuplidor.EditValue
        Next
    End Sub

    Private Sub ILUEDepartamento_EditValueChanged(sender As Object, e As EventArgs) Handles ILUEDepartamento.EditValueChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Departamento") = ILUEDepartamento.EditValue
        Next
    End Sub

    Private Sub ILUECategoria_EditValueChanged(sender As Object, e As EventArgs) Handles ILUECategoria.EditValueChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Categoria") = ILUECategoria.EditValue
        Next
    End Sub

    Private Sub ILUESubCategoria_EditValueChanged(sender As Object, e As EventArgs) Handles ILUESubCategoria.EditValueChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Subcategoria") = ILUESubCategoria.EditValue
        Next
    End Sub

    Private Sub ILUEMarca_EditValueChanged(sender As Object, e As EventArgs) Handles ILUEMarca.EditValueChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Marca") = ILUEMarca.EditValue
        Next
    End Sub

    Private Sub ILUEParentesco_EditValueChanged(sender As Object, e As EventArgs) Handles ILUEParentesco.EditValueChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Parentezco") = ILUEParentesco.EditValue
        Next
    End Sub

    Private Sub ILUEGarantia_EditValueChanged(sender As Object, e As EventArgs) Handles ILUEGarantia.EditValueChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Garantia") = ILUEGarantia.EditValue
        Next
    End Sub

    Private Sub ILUEItbis_EditValueChanged(sender As Object, e As EventArgs) Handles ILUEItbis.EditValueChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Itbis") = ILUEItbis.EditValue
        Next
    End Sub

    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit2.CheckedChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Serial") = Convert.ToInt16(CheckEdit2.CheckState)
        Next
    End Sub

    Private Sub CheckEdit3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit3.CheckedChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Promocion") = Convert.ToInt16(CheckEdit3.CheckState)
        Next
    End Sub

    Private Sub CheckEdit4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit4.CheckedChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("NoDevolucion") = Convert.ToInt16(CheckEdit4.CheckState)
        Next
    End Sub

    Private Sub CheckEdit5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit5.CheckedChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("VentaCosto") = Convert.ToInt16(CheckEdit5.CheckState)
        Next
    End Sub

    Private Sub CheckEdit6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit6.CheckedChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Descontinuar") = Convert.ToInt16(CheckEdit6.CheckState)
        Next
    End Sub

    Private Sub CheckEdit7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit7.CheckedChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("BloqueoCredito") = Convert.ToInt16(CheckEdit7.CheckState)
        Next
    End Sub

    Private Sub CheckEdit8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit8.CheckedChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Prealertar") = Convert.ToInt16(CheckEdit8.CheckState)
        Next
    End Sub

    Private Sub CheckEdit9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit9.CheckedChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("NoPagoTarjeta") = Convert.ToInt16(CheckEdit9.CheckState)
        Next
    End Sub

    Private Sub CheckEdit10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit10.CheckedChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Revisado") = Convert.ToInt16(CheckEdit10.CheckState)
        Next
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        For Each rw As DataRow In TablaArticulos.Rows
            rw.Item("Nulo") = Convert.ToInt16(CheckEdit1.CheckState)
        Next
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


    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If XtraTabControl1.SelectedTabPageIndex = 1 Then
            SplitContainer1.SplitterDistance = 240

            FillPropiedades()
            Populate()

            ChangingfromTreeview = False
            ChangeAllNodes(False, TreeView1)

            CheckedListBox2.SetItemChecked(0, CheckState.Checked)
            CheckedListBox2.SetItemChecked(1, CheckState.Checked)
            CheckedListBox2.SetItemChecked(2, CheckState.Checked)
            CheckedListBox2.SetItemChecked(24, CheckState.Checked)


            If GridView1.FocusedRowHandle >= 0 Then
                If GridView1.GetFocusedRowCellValue("Propiedades") <> "" Then
                    Dim words As String() = GridView1.GetFocusedRowCellValue("Propiedades").Split(New Char() {" "c})

                    Dim Filas As New ArrayList

                    For Each word As String In words
                        Filas.Add(word.Replace(",", "").Trim)
                    Next

                    For Each st As String In Filas
                        Dim nodes As TreeNode() = TreeView1.Nodes.Find(st, True)

                        'Check if at least one node was found
                        If nodes.Length > 0 Then
                            'Set Checked=True for the first found node (index 0)
                            nodes(0).Checked = True
                        End If
                    Next
                End If

            End If
        Else
            SplitContainer1.SplitterDistance = 438
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

    Public Sub CheckAllNodesForParent(ByRef CheckedTreeNode As TreeNode)
        If CheckedTreeNode.Checked Then
            If CheckedTreeNode.Parent Is Nothing = False Then
                Dim allChecked As Boolean = True
                For Each node As TreeNode In CheckedTreeNode.Parent.Nodes
                    If Not node.Checked Then
                        allChecked = False
                    End If
                Next
                If allChecked Then
                    CheckedTreeNode.Parent.Checked = True
                    CheckAllNodesForParent(CheckedTreeNode.Parent)
                End If
            End If
        Else
            If CheckedTreeNode.Parent Is Nothing = False Then
                CheckedTreeNode.Parent.Checked = False
                CheckAllNodesForParent(CheckedTreeNode.Parent)
            End If
        End If
    End Sub

    Public Sub UncheckParent(ByVal currNode As TreeNode)
        If Not currNode.Parent Is Nothing Then
            If currNode.Checked = False Then
                currNode.Parent.Checked = False
                currNode = currNode.Parent
                UncheckParent(currNode)
            End If
        End If
    End Sub

    Public Sub CheckParent(ByVal currNode As TreeNode)
        Dim check As Boolean = True
        While (Not currNode.Parent Is Nothing)
            For Each child As TreeNode In currNode.Parent.Nodes
                If child.Checked = False Then
                    check = False
                End If
            Next
            If check = True Then
                currNode.Parent.Checked = True
            End If
            currNode = currNode.Parent
            CheckParent(currNode)
        End While
    End Sub

    Public Sub CheckChildren(ByVal currNode As TreeNode)
        Dim checkStatus As Boolean = currNode.Checked
        For Each node As TreeNode In currNode.Nodes
            node.Checked = checkStatus
            CheckChildren(node)
        Next
    End Sub

    Private Sub TreeView1_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCheck
        Try

            'Dim check As Boolean = True
            'If stop_recursion = True Then
            '    stop_recursion = False
            '    CheckChildren(e.Node)
            '    If Not e.Node.Parent Is Nothing Then
            '        For Each child As TreeNode In e.Node.Parent.Nodes
            '            If child.Checked = False Then
            '                check = False
            '            End If
            '        Next
            '        If check = True Then
            '            CheckParent(e.Node)
            '        Else
            '            UncheckParent(e.Node)
            '        End If
            '    End If
            '    stop_recursion = True
            'End If


            If ChangingfromTreeview = True Then


                If GridView1.RowCount > 0 Then
                    If e.Node.Checked = True Then

                        'Si es padre no hago nada
                        ConLibregco.Open()
                        cmd = New MySqlCommand("SELECT coalesce(IDParent,0) FROM libregco.articulos_propiedad where idArticulos_propiedad='" + e.Node.Name + "'", ConLibregco)
                        Dim isParent As Int16 = Convert.ToInt16(cmd.ExecuteScalar())
                        ConLibregco.Close()

                        If isParent = 0 Then
                            Exit Sub
                        Else

                            If GridView1.SelectedRowsCount = 1 Then
                                ''Verificar si exist la propiedad ya vinculada
                                Dim words As String() = GridView1.GetFocusedRowCellValue("Propiedades").Split(New Char() {" "c})
                                Dim Filas As New ArrayList
                                For Each word As String In words
                                    Filas.Add(word.Replace(",", "").Trim)
                                Next
                                If Not Filas.Contains(e.Node.Name) Then
                                    'Adjuntar la propiedad del treeview
                                    Filas.Add(e.Node.Name)

                                    Dim ob As Object
                                    If GridView1.GetFocusedRowCellValue("Propiedades") = "" Then
                                        ob = e.Node.Name
                                    Else
                                        ob = GridView1.GetFocusedRowCellValue("Propiedades") & ", " & e.Node.Name
                                    End If
                                    GridView1.SetFocusedRowCellValue("Propiedades", ob)

                                    ConLibregco.Open()
                                    For Each itm As String In Filas
                                        If itm.Trim <> "" Then
                                            cmd = New MySqlCommand("SELECT count(idArticulos_has_propiedad) FROM libregco.articulos_has_propiedad where IDArticulo='" + GridView1.GetFocusedRowCellValue("ID").ToString + "' AND IDPropiedad_propiedad='" + itm + "'", ConLibregco)
                                            If Convert.ToInt16(cmd.ExecuteScalar()) = 0 Then
                                                cmd = New MySqlCommand("INSERT INTO articulos_has_propiedad (IDPropiedad_propiedad,IDArticulo) VALUES ('" + itm + "','" + GridView1.GetFocusedRowCellValue(GridView1.Columns("ID")).ToString + "')", ConLibregco)
                                                cmd.ExecuteNonQuery()
                                            End If
                                        End If
                                    Next
                                    ConLibregco.Close()
                                End If


                            Else
                                Dim rows() As Integer = GridView1.GetSelectedRows


                                For Each row As Integer In rows
                                    Dim words As String() = GridView1.GetRowCellValue(row, GridView1.Columns("Propiedades")).ToString.Split(New Char() {","c})
                                    Dim Filas As New ArrayList
                                    For Each word As String In words
                                        Filas.Add(word.Replace(",", "").Trim)
                                    Next

                                    If Not Filas.Contains(e.Node.Name) Then
                                        Filas.Add(e.Node.Name)

                                        Dim ob As Object
                                        If GridView1.GetRowCellValue(row, GridView1.Columns("Propiedades")) = "" Then
                                            ob = e.Node.Name
                                        Else
                                            ob = GridView1.GetRowCellValue(row, GridView1.Columns("Propiedades")) & ", " & e.Node.Name
                                        End If

                                        GridView1.SetRowCellValue(row, GridView1.Columns("Propiedades"), ob)

                                        ConLibregco.Open()
                                        For Each itm As String In Filas
                                            If itm.Trim <> "" Then
                                                cmd = New MySqlCommand("SELECT count(idArticulos_has_propiedad) FROM libregco.articulos_has_propiedad where IDArticulo='" + GridView1.GetRowCellValue(row, GridView1.Columns("ID")).ToString + "' AND IDPropiedad_propiedad='" + itm + "'", ConLibregco)
                                                If Convert.ToInt16(cmd.ExecuteScalar()) = 0 Then
                                                    cmd = New MySqlCommand("INSERT INTO articulos_has_propiedad (IDPropiedad_propiedad,IDArticulo) VALUES ('" + itm + "','" + GridView1.GetRowCellValue(row, GridView1.Columns("ID")).ToString + "')", ConLibregco)
                                                    cmd.ExecuteNonQuery()
                                                End If
                                            End If
                                        Next
                                        ConLibregco.Close()

                                    End If
                                Next

                            End If


                        End If

                        'Dim nodes As TreeNode() = TreeView1.Nodes.Find(e.Node.Name, True)
                        'Dim nodeparent As TreeNode
                        'If nodes.Length > 0 Then
                        '    nodeparent = nodes(0).Parent


                        '    For Each nd As TreeNode In nodeparent.Nodes
                        '        If nd.Name <> e.Node.Name Then
                        '            nd.Checked = False
                        '            nd.ForeColor = Color.Gray
                        '        Else
                        '            nd.ForeColor = Color.Black
                        '        End If

                        '    Next
                        'End If

                    Else
                        'Eliminando al checked = false

                        If GridView1.SelectedRowsCount = 1 Then
                            If GridView1.GetFocusedRowCellValue("Propiedades").ToString <> "" Then
                                Dim words As String() = GridView1.GetFocusedRowCellValue("Propiedades").Split(New Char() {" "c})
                                Dim Filas As New ArrayList
                                For Each word As String In words
                                    Filas.Add(word.Replace(",", "").Trim)
                                Next

                                If Filas.Contains(e.Node.Name) Then
                                    Filas.Remove(e.Node.Name)

                                    ConLibregco.Open()
                                    cmd = New MySqlCommand("SELECT COALESCE(idArticulos_has_propiedad,0) FROM libregco.articulos_has_propiedad where IDArticulo='" + GridView1.GetFocusedRowCellValue("ID").ToString + "' AND IDPropiedad_propiedad='" + e.Node.Name + "'", ConLibregco)
                                    Dim IDhasPropiedad As Integer = Convert.ToInt16(cmd.ExecuteScalar())
                                    If IDhasPropiedad <> 0 Then
                                        cmd = New MySqlCommand("Delete FROM articulos_has_propiedad WHERE idArticulos_has_propiedad='" + IDhasPropiedad.ToString + "'", ConLibregco)
                                        cmd.ExecuteNonQuery()
                                    End If
                                    ConLibregco.Close()

                                    Dim nuevostoken As Object = String.Join(", ", Filas.ToArray)
                                    GridView1.SetFocusedRowCellValue("Propiedades", nuevostoken)
                                End If
                            End If

                        Else
                            Dim rows() As Integer = GridView1.GetSelectedRows

                            ConLibregco.Open()
                            For Each row As Integer In rows

                                Dim words As String() = GridView1.GetRowCellValue(row, GridView1.Columns("Propiedades")).ToString.Split(New Char() {","c})
                                Dim Filas As New ArrayList
                                For Each word As String In words
                                    Filas.Add(word.Replace(",", "").Trim)
                                Next


                                If Filas.Contains(e.Node.Name) Then
                                    Filas.Remove(e.Node.Name)

                                    cmd = New MySqlCommand("SELECT COALESCE(idArticulos_has_propiedad,0) FROM libregco.articulos_has_propiedad where IDArticulo='" + GridView1.GetRowCellValue(row, GridView1.Columns("ID")).ToString + "' AND IDPropiedad_propiedad='" + e.Node.Name + "'", ConLibregco)
                                    Dim IDhasPropiedad As Integer = Convert.ToInt16(cmd.ExecuteScalar())
                                    If IDhasPropiedad <> 0 Then
                                        cmd = New MySqlCommand("Delete FROM articulos_has_propiedad WHERE idArticulos_has_propiedad='" + IDhasPropiedad.ToString + "'", ConLibregco)
                                        cmd.ExecuteNonQuery()
                                    End If

                                    Dim nuevostoken As Object = String.Join(", ", Filas.ToArray)
                                    GridView1.SetRowCellValue(row, GridView1.Columns("Propiedades"), nuevostoken)

                                End If
                            Next
                            ConLibregco.Close()

                        End If

                        'Dim nodes As TreeNode() = TreeView1.Nodes.Find(e.Node.Name, True)
                        'Dim nodeparent As TreeNode
                        'If nodes.Length > 0 Then
                        '    nodeparent = nodes(0).Parent


                        '    For Each nd As TreeNode In nodeparent.Nodes
                        '        If nd.Name <> e.Node.Name Then
                        '            nd.Checked = False
                        '            nd.ForeColor = Color.Gray
                        '        Else
                        '            nd.ForeColor = Color.Black
                        '        End If

                        '    Next
                        'End If
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If GridView1.FocusedRowHandle >= 0 Then
            ChangingfromTreeview = False
            ChangeAllNodes(False, TreeView1)

            If GridView1.SelectedRowsCount = 1 Then
                If GridView1.GetFocusedRowCellValue("Propiedades") <> "" Then
                    Dim words As String() = GridView1.GetFocusedRowCellValue("Propiedades").Split(New Char() {" "c})

                    Dim Filas As New ArrayList

                    For Each word As String In words
                        Filas.Add(word.Replace(",", "").Trim)
                    Next

                    For Each st As String In Filas
                        Dim nodes As TreeNode() = TreeView1.Nodes.Find(st, True)

                        'Check if at least one node was found
                        If nodes.Length > 0 Then
                            'Set Checked=True for the first found node (index 0)
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

            Else
                'MessageBox.Show("Controlar esto")

            End If


        End If

    End Sub

    Private Sub TreeView1_MouseHover(sender As Object, e As EventArgs) Handles TreeView1.MouseHover
        ChangingfromTreeview = True

    End Sub

    Private Sub TreeView1_MouseEnter(sender As Object, e As EventArgs) Handles TreeView1.MouseEnter
        ChangingfromTreeview = True

    End Sub

    Private Sub TreeView1_Enter(sender As Object, e As EventArgs) Handles TreeView1.Enter
        ChangingfromTreeview = True
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

    Private Sub TKPropiedades_EditValueChanged(sender As Object, e As EventArgs) Handles TKPropiedades.EditValueChanged
        If TKPropiedades.EditValue <> "" Then
            'Obtengo los indices de las filas seleccionadas
            Dim rows() As Integer = GridView1.GetSelectedRows

            Dim words As String() = TKPropiedades.EditValue.Split(New Char() {","c})

            ConLibregco.Open()

            For Each row As Integer In rows

                For Each word As String In words

                    If word.Trim.ToString <> "" Then
                        cmd = New MySqlCommand("SELECT count(idArticulos_has_propiedad) FROM libregco.articulos_has_propiedad where IDArticulo='" + GridView1.GetRowCellValue(row, GridView1.Columns("ID")).ToString + "' AND IDPropiedad_propiedad='" + word.Trim.ToString + "'", ConLibregco)
                        If Convert.ToInt16(cmd.ExecuteScalar()) = 0 Then
                            cmd = New MySqlCommand("INSERT INTO articulos_has_propiedad (IDPropiedad_propiedad,IDArticulo) VALUES ('" + word.Trim.ToString + "','" + GridView1.GetRowCellValue(row, GridView1.Columns("ID")) + "')", ConLibregco)
                            cmd.ExecuteNonQuery()
                        End If
                    End If

                Next

                cmd = New MySqlCommand("SELECT coalesce(group_concat(IDPropiedad_propiedad separator ', '),'') FROM libregco.articulos_has_propiedad WHERE Articulos_has_propiedad.IDArticulo='" + GridView1.GetRowCellValue(row, GridView1.Columns("ID")).ToString + "'", ConLibregco)
                GridView1.SetRowCellValue(row, GridView1.Columns("Propiedades"), Convert.ToString(cmd.ExecuteScalar()))
            Next

            ConLibregco.Close()

        End If

    End Sub

    Private Sub GridView1_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        If GridView1.FocusedRowHandle >= 0 Then
            If GridView1.SelectedRowsCount > 0 Then
                'Si son varias las filas seleccionadas

                'Obtengo las filas
                Dim rows() As Integer = GridView1.GetSelectedRows

                'Obtengo las propiedades y las meto en el arreglo
                Dim words As String() = GridView1.GetRowCellValue(rows(0), GridView1.Columns("Propiedades")).ToString().Split(New Char() {","c})
                'Las ingreso en un arreglo

                Dim FilasaVerificar As New ArrayList
                For Each word In words
                    FilasaVerificar.Add(word.Replace(",", "").Trim)
                Next


                For Each rw As Integer In rows
                    'MessageBox.Show("Buscando en fila del indice: " & rw)
                    Dim Propied As String() = GridView1.GetRowCellValue(rw, GridView1.Columns("Propiedades")).ToString().Split(New Char() {","c})

                    Dim arr As New ArrayList

                    For Each prop As String In Propied
                        arr.Add(prop.Replace(",", "").Trim)
                    Next

                    For Each st As String In FilasaVerificar
                        If arr.Contains(st) = True Then
                        Else
                            FilasaVerificar.Remove(st)
                            Exit For
                        End If
                    Next

                Next

                TKPropiedades.EditValue = String.Join(", ", FilasaVerificar.ToArray)

                ChangingfromTreeview = False
                ChangeAllNodes(False, TreeView1)

                For Each st As String In FilasaVerificar
                    Dim nodes As TreeNode() = TreeView1.Nodes.Find(st, True)
                    If nodes.Length > 0 Then
                        nodes(0).Checked = True
                    End If
                Next
            End If

        End If
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
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

            ElseIf GridView1.FocusedColumn.FieldName = "Imagen" Then
                If TypeConnection.Text = 1 Then
                    Dim OfdImagen As New OpenFileDialog
                    Dim Exists As Boolean
                    Dim RutaDestino As String
                    Dim UltNum As Double

                    With OfdImagen
                        .RestoreDirectory = True
                        .Title = "Buscar imagen de artículo"
                        .Filter = "Imágenes(*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png"
                        .FileName = ""
                        .Multiselect = True
                    End With

                    If OfdImagen.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor
                        OfdImagen.Multiselect = False

                        For Each itm In OfdImagen.FileNames
                            Exists = File.Exists(itm)

                            If Exists = True Then
                                ConLibregco.Open()
                                cmd = New MySqlCommand("SELECT AUTO_INCREMENT AS id FROM information_schema.Tables WHERE TABLE_SCHEMA='Libregco' AND table_name='Articulos_fotos'", ConLibregco)
                                UltNum = Convert.ToDouble(cmd.ExecuteScalar())
                                ConLibregco.Close()

                                RutaDestino = "\\" & PathServidor.Text & "\Libregco\Files\Artículos\" & "ART-" & GridView1.GetFocusedRowCellValue("ID").ToString & " R#" & UltNum & ".png"

                                If RutaDestino <> itm Then
                                    My.Computer.FileSystem.MoveFile(itm, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                                    itm = RutaDestino


                                    sqlQ = "INSERT INTO Libregco.Articulos_fotos (IDArticulo,Descripcion,Orden,RutaImagen) VALUES ('" + GridView1.GetFocusedRowCellValue("ID").ToString + "','','0','" + Replace(RutaDestino, "\", "\\") + "')"
                                    ConLibregco.Open()
                                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                                    cmd.ExecuteNonQuery()
                                    ConLibregco.Close()

                                    SetDefaultPhoto(GridView1.GetFocusedRowCellValue("ID"))

                                    Dim wFile As System.IO.FileStream
                                    wFile = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                                    GridView1.SetFocusedRowCellValue("Imagen", ResizeImage(System.Drawing.Image.FromStream(wFile), DTConfiguracion.Rows(180 - 1).Item("Value2Int")))
                                    wFile.Close()
                                End If
                            End If
                        Next


                    End If

                    Me.Cursor = Cursors.Default
                End If

            End If
        End If
    End Sub

    Private Sub GridView1_ShownEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView
        view = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If view.FocusedColumn.FieldName = "Categoria" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.LookUpEdit Then
            Dim edit As DevExpress.XtraEditors.LookUpEdit
            Dim table As DataTable
            Dim row As DataRow
            edit = CType(view.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
            table = CType(edit.Properties.DataSource, DataTable)
            clone = New DataView(table)
            row = view.GetDataRow(view.FocusedRowHandle)
            clone.RowFilter = "IDDepartamento = " + row("Departamento").ToString()
            edit.Properties.DataSource = clone

        ElseIf view.FocusedColumn.FieldName = "Subcategoria" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.LookUpEdit Then
            Dim edit As DevExpress.XtraEditors.LookUpEdit
            Dim table As DataTable
            Dim row As DataRow
            edit = CType(view.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
            table = CType(edit.Properties.DataSource, DataTable)
            clone = New DataView(table)
            row = view.GetDataRow(view.FocusedRowHandle)
            clone.RowFilter = "IDCategoria = " + row("Categoria").ToString()
            edit.Properties.DataSource = clone
        End If
    End Sub

    Private Sub GridView1_HiddenEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.HiddenEditor
        If Not clone Is Nothing Then
            clone.Dispose()
            clone = Nothing
        End If
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

    Private Sub GridView1_GotFocus(sender As Object, e As EventArgs) Handles GridView1.GotFocus
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
        Try
            Clipboard.SetText(GridView1.GetFocusedDisplayText())
        Catch ex As Exception

        End Try

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

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Dim str As String = ""
        For i As Integer = 0 To GridView1.RowCount - 1
            str = str & vbNewLine & GridView1.GetRowCellValue(i, GridView1.FocusedColumn)
        Next

        Clipboard.SetText(str)
    End Sub
End Class