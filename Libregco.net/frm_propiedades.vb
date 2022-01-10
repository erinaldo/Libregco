Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.DragDrop
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frm_propiedades
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Dim sqlQ As String

    Friend IsLimitedByFilter As Boolean = False
    Friend isParenttoFilter As String = ""

    Friend TablaPropiedades As DataTable
    Dim RepositoryPropiedades As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit() With {.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard, .BestFitWidth = True}
    Dim RepositoryPicture As New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit With {.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray, .PopupBorderStyle = PopupBorderStyles.NoBorder, .PictureAlignment = ContentAlignment.MiddleCenter, .ShowIcon = True, .SizeMode = PictureSizeMode.Zoom, .NullText = "", .ShowMenu = True}
    Dim RepositoryChkNulo As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .AllowGrayed = False, .ValueGrayed = "0"}
    Dim SpinColumnOrder As New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit() With {.MinValue = "0", .MaxValue = "10000", .AllowNullInput = DevExpress.Utils.DefaultBoolean.False, .NullValuePromptShowForEmptyValue = 0, .NullText = 0}

    Private Sub ctypefrm_propiedades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        Permisos = PasarPermisos(Me.Tag)
        CargarLibregco()
        CargarEmpresa()
        SetPropiedadesTable()
        LimpiarDatos()
        ActualizarTodo()
        AddHandler RepositoryChkNulo.EditValueChanged, AddressOf OnEditValueChanged
    End Sub

    Private Sub OnEditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        GridView1.PostEditor()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub LimpiarDatos()
        TablaPropiedades.Rows.Clear()
        TreeView1.Nodes.Clear()
    End Sub

    Private Sub FillRepositoryPropiedades()
        Dim dstemp As New DataSet


        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT idArticulos_propiedad,IF(articulos_propiedad.IDParent is NULL,Propiedad,Concat((Select Propiedad from articulos_propiedad as PET where PET.idArticulos_propiedad=articulos_propiedad.IDParent),'.',articulos_propiedad.Propiedad)) as Propiedad FROM libregco.articulos_propiedad ORDER BY IDParent ASC,Propiedad ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "articulos_propiedad")
        ConLibregco.Close()

        dstemp.Tables("articulos_propiedad").Rows.Add()

        Dim TablaPropiedades As DataTable = dstemp.Tables("articulos_propiedad")

        RepositoryPropiedades.DataSource = TablaPropiedades
        RepositoryPropiedades.ValueMember = "idArticulos_propiedad"
        RepositoryPropiedades.DisplayMember = "Propiedad"

        RepositoryPropiedades.PopulateColumns()
        RepositoryPropiedades.Columns(RepositoryPropiedades.ValueMember).Visible = False
        RepositoryPropiedades.ShowHeader = False
    End Sub

    Private Sub SetPropiedadesTable()
        TablaPropiedades = New DataTable("Propiedades")

        TablaPropiedades.Columns.Add("ID", System.Type.GetType("System.String"))
        TablaPropiedades.Columns.Add("Propiedad", System.Type.GetType("System.String"))
        TablaPropiedades.Columns.Add("Nota", System.Type.GetType("System.String"))
        TablaPropiedades.Columns.Add("Padre", System.Type.GetType("System.String"))
        TablaPropiedades.Columns.Add("Imagen", System.Type.GetType("System.Object"))
        TablaPropiedades.Columns.Add("RutaImagen", System.Type.GetType("System.String"))
        TablaPropiedades.Columns.Add("Nulo", System.Type.GetType("System.String"))
        TablaPropiedades.Columns.Add("Orden", System.Type.GetType("System.Decimal"))

        GridControl1.DataSource = TablaPropiedades
        GridControl1.DataSource = TablaPropiedades
        GridView1.Columns("Padre").ColumnEdit = RepositoryPropiedades
        GridView1.Columns("Imagen").ColumnEdit = RepositoryPicture
        GridView1.Columns("Nulo").ColumnEdit = RepositoryChkNulo
        GridView1.Columns("Orden").ColumnEdit = SpinColumnOrder

        'Estilos
        GridView1.Columns("ID").Visible = False
        GridView1.Columns("Propiedad").Width = 200
        GridView1.Columns("Nota").Width = 240
        GridView1.Columns("Padre").Width = 260
        GridView1.Columns("Imagen").Width = 60
        GridView1.Columns("RutaImagen").Visible = False
        GridView1.Columns("Nulo").Width = 50
        GridView1.Columns("Orden").Width = 60

        SpinColumnOrder.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        SpinColumnOrder.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        SpinColumnOrder.Properties.Mask.EditMask = "#####"
    End Sub


    Private Sub ActualizarTodo()
        IsLimitedByFilter = False
        isParenttoFilter = ""

        HabilitarControles()

        FillPropiedades()
        Populate()

        GridControl1.Focus()
    End Sub

    Private Sub FillPropiedades()
        Dim newImage As Image
        Dim ds As New DataSet

        FillRepositoryPropiedades()

        TablaPropiedades.Rows.Clear()

        Con.Open()
        cmd = New MySqlCommand("SELECT idArticulos_propiedad,Propiedad,NotaPropiedad,IDParent,PropiedadImagen,Nulo,Orden FROM libregco.articulos_propiedad ORDER BY IDParent ASC,articulos_propiedad.Orden ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "Propiedadess")
        Con.Close()

        Dim Tabla As DataTable = ds.Tables("Propiedadess")

        For Each dt As DataRow In Tabla.Rows
            If dt.Item("PropiedadImagen").ToString <> "" Then
                If System.IO.File.Exists(dt.Item("PropiedadImagen")) Then
                    Dim wFile As System.IO.FileStream

                    wFile = New FileStream(dt.Item("PropiedadImagen"), FileMode.Open, FileAccess.Read)
                    newImage = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                Else
                    newImage = Nothing
                End If
            Else
                newImage = Nothing
            End If

            TablaPropiedades.Rows.Add(dt.Item("idArticulos_propiedad"), dt.Item("Propiedad"), dt.Item("NotaPropiedad"), dt.Item("IDParent"), newImage, dt.Item("PropiedadImagen"), dt.Item("Nulo"), dt.Item("Orden"))
        Next

        GridView1.Columns(3).GroupIndex = 0
        GridView1.ExpandAllGroups()
    End Sub

    Sub FillPropiedadesLimitada()
        Dim newImage As Image
        Dim ds As New DataSet

        FillRepositoryPropiedades()

        TablaPropiedades.Rows.Clear()

        Con.Open()
        cmd = New MySqlCommand("SELECT idArticulos_propiedad,Propiedad,NotaPropiedad,IDParent,PropiedadImagen,Nulo,Orden FROM libregco.articulos_propiedad Where IDParent='" + isParenttoFilter + "' ORDER BY IDParent ASC,articulos_propiedad.Orden ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "Propiedadess")
        Con.Close()

        Dim Tabla As DataTable = ds.Tables("Propiedadess")

        For Each dt As DataRow In Tabla.Rows
            If dt.Item("PropiedadImagen").ToString <> "" Then
                If System.IO.File.Exists(dt.Item("PropiedadImagen")) Then
                    Dim wFile As System.IO.FileStream

                    wFile = New FileStream(dt.Item("PropiedadImagen"), FileMode.Open, FileAccess.Read)
                    newImage = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                Else
                    newImage = Nothing
                End If
            Else
                newImage = Nothing
            End If

            TablaPropiedades.Rows.Add(dt.Item("idArticulos_propiedad"), dt.Item("Propiedad"), dt.Item("NotaPropiedad"), dt.Item("IDParent"), newImage, dt.Item("PropiedadImagen"), dt.Item("Nulo"), dt.Item("Orden"))
        Next

        GridView1.Columns(3).GroupIndex = 0
        GridView1.ExpandAllGroups()
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

        Catch ex As Exception
            ConLibregco.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub


    Private Sub DeshabilitarControles()
        GridControl1.Enabled = False
        TreeView1.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        GridControl1.Enabled = True
        TreeView1.Enabled = True
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub HistorialToolStripMenuItem_Click(sender As Object, e As EventArgs)
        btnBuscar.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.RowHandle >= 0 Then

            If GridView1.GetDataRow(e.RowHandle)(1) Is Nothing Then
                Exit Sub
            ElseIf GridView1.GetDataRow(e.RowHandle)(1).ToString = "" Then
                Exit Sub
            End If

            ConLibregco.Open()

            If GridView1.GetDataRow(e.RowHandle)(0).ToString = "" Then
                If GridView1.GetDataRow(e.RowHandle)(1).ToString <> "" Then
                    If GridView1.GetDataRow(e.RowHandle)(3).ToString = "" Then
                        sqlQ = "INSERT INTO articulos_propiedad (Propiedad,NotaPropiedad,PropiedadImagen,Nulo,Orden) VALUES ('" + GridView1.GetDataRow(e.RowHandle)(1).ToString + "','" + GridView1.GetDataRow(e.RowHandle)(2).ToString + "','" + GridView1.GetDataRow(e.RowHandle)(5).ToString + "','" + Convert.ToInt16(GridView1.GetDataRow(e.RowHandle)(6).ToString).ToString + "','" + GridView1.GetDataRow(e.RowHandle)(7).ToString + "')"
                        cmd = New MySqlCommand(sqlQ, ConLibregco)
                        cmd.ExecuteNonQuery()
                    Else
                        sqlQ = "INSERT INTO articulos_propiedad (Propiedad,NotaPropiedad,IDParent,PropiedadImagen,Nulo,Orden) VALUES ('" + GridView1.GetDataRow(e.RowHandle)(1).ToString + "','" + GridView1.GetDataRow(e.RowHandle)(2).ToString + "','" + GridView1.GetDataRow(e.RowHandle)(3).ToString + "','" + GridView1.GetDataRow(e.RowHandle)(5).ToString + "','" + Convert.ToInt16(GridView1.GetDataRow(e.RowHandle)(6).ToString).ToString + "','" + GridView1.GetDataRow(e.RowHandle)(7).ToString + "')"
                        cmd = New MySqlCommand(sqlQ, ConLibregco)
                        cmd.ExecuteNonQuery()
                    End If
                    cmd = New MySqlCommand("Select idArticulos_propiedad from articulos_propiedad where idArticulos_propiedad= (Select Max(idArticulos_propiedad) from articulos_propiedad)", ConLibregco)
                    GridView1.GetDataRow(e.RowHandle)(0) = Convert.ToDouble(cmd.ExecuteScalar)
                End If

            Else
                'If GridView1.GetDataRow(e.RowHandle)(1).ToString = "" Then
                '    sqlQ = "DELETE FROM articulos_propiedad WHERE idArticulos_propiedad='" + GridView1.GetDataRow(e.RowHandle)(0).ToString + "'"
                '    cmd = New MySqlCommand(sqlQ, ConLibregco)
                '    cmd.ExecuteNonQuery()
                'Else
                If GridView1.GetDataRow(e.RowHandle)(3).ToString = "" Then
                    sqlQ = "UPDATE articulos_propiedad SET Propiedad='" + GridView1.GetDataRow(e.RowHandle)(1).ToString + "',NotaPropiedad='" + GridView1.GetDataRow(e.RowHandle)(2).ToString + "',IDParent=NULL,Nulo='" + Convert.ToInt16(GridView1.GetDataRow(e.RowHandle)(6).ToString).ToString + "',Orden='" + GridView1.GetDataRow(e.RowHandle)(7).ToString + "' WHERE idArticulos_propiedad='" + GridView1.GetDataRow(e.RowHandle)(0).ToString + "'"
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()
                Else
                    sqlQ = "UPDATE articulos_propiedad SET Propiedad='" + GridView1.GetDataRow(e.RowHandle)(1).ToString + "',NotaPropiedad='" + GridView1.GetDataRow(e.RowHandle)(2).ToString + "',IDParent='" + GridView1.GetDataRow(e.RowHandle)(3).ToString + "',Nulo='" + Convert.ToInt16(GridView1.GetDataRow(e.RowHandle)(6).ToString).ToString + "',Orden='" + GridView1.GetDataRow(e.RowHandle)(7).ToString + "' WHERE idArticulos_propiedad='" + GridView1.GetDataRow(e.RowHandle)(0).ToString + "'"
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()
                End If
                'End If
            End If

            ConLibregco.Close()

            If IsLimitedByFilter = False Then
                Populate()
                FillRepositoryPropiedades()
            Else
                PopulateLimitada()
                FillRepositoryPropiedades()
            End If

            GridView1.ExpandAllGroups()

        End If
    End Sub

    'Private Sub GuardarDgvs()

    '    ConLibregco.Open()

    '    For Each itm As DataRow In TablaPropiedades.Rows
    '        If itm(0).ToString = "" Then
    '            If itm(1).ToString <> "" Then
    '                If itm(3).ToString = "" Then
    '                    sqlQ = "INSERT INTO articulos_propiedad (Propiedad,NotaPropiedad,PropiedadImagen,Nulo) VALUES ('" + itm(1).ToString + "','" + itm(2).ToString + "','" + itm(5).ToString + "','" + Convert.ToInt16(itm(6)).ToString + "')"
    '                    cmd = New MySqlCommand(sqlQ, ConLibregco)
    '                    cmd.ExecuteNonQuery()
    '                Else
    '                    sqlQ = "INSERT INTO articulos_propiedad (Propiedad,NotaPropiedad,IDParent,PropiedadImagen,Nulo) VALUES ('" + itm(1).ToString + "','" + itm(2).ToString + "','" + itm(3).ToString + "','" + itm(5).ToString + "','" + Convert.ToInt16(itm(6)).ToString + "')"
    '                    cmd = New MySqlCommand(sqlQ, ConLibregco)
    '                    cmd.ExecuteNonQuery()
    '                End If

    '                cmd = New MySqlCommand("Select idArticulos_propiedad from articulos_propiedad where idArticulos_propiedad= (Select Max(idArticulos_propiedad) from articulos_propiedad)", ConLibregco)
    '                itm(0) = Convert.ToDouble(cmd.ExecuteScalar)
    '            End If
    '        Else
    '            If itm(1).ToString = "" Then
    '                sqlQ = "DELETE FROM articulos_propiedad WHERE idArticulos_propiedad='" + itm(0).ToString + "'"
    '                cmd = New MySqlCommand(sqlQ, ConLibregco)
    '                cmd.ExecuteNonQuery()
    '            Else
    '                If itm(3).ToString = "" Then
    '                    sqlQ = "UPDATE articulos_propiedad SET Propiedad='" + itm(1).ToString + "',NotaPropiedad='" + itm(2).ToString + "',IDParent=NULL,Nulo='" + Convert.ToInt16(itm(6)).ToString + "' WHERE idArticulos_propiedad='" + itm(0).ToString + "'"
    '                    cmd = New MySqlCommand(sqlQ, ConLibregco)
    '                    cmd.ExecuteNonQuery()

    '                Else
    '                    sqlQ = "UPDATE articulos_propiedad SET Propiedad='" + itm(1).ToString + "',NotaPropiedad='" + itm(2).ToString + "',IDParent='" + itm(3).ToString + "',Nulo='" + Convert.ToInt16(itm(6)).ToString + "' WHERE idArticulos_propiedad='" + itm(0).ToString + "'"
    '                    cmd = New MySqlCommand(sqlQ, ConLibregco)
    '                    cmd.ExecuteNonQuery()
    '                End If
    '            End If
    '        End If
    '    Next

    '    ConLibregco.Close()

    '    Populate()

    'End Sub

    'Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
    '    If Permisos(1) = 0 Then
    '        MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Exit Sub
    '    End If


    '    Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar y actualizar las propiedades en la base de datos?", "Guardar propiedades", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '    If Result = MsgBoxResult.Yes Then
    '        GuardarDgvs()
    '        MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '    End If

    'End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_propiedades.ShowDialog(Me)
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
        Dim nodes = GetTreeNodes(source, Function(r) r.Field(Of Integer?)("IDParent") Is Nothing, Function(r, s) s.Where(Function(x) r("idArticulos_propiedad").Equals(x("IDParent"))), Function(r) New TreeNode With {.Text = r.Field(Of String)("Propiedad")})

        TreeView1.Nodes.AddRange(nodes.ToArray())

        TreeView1.ExpandAll()
    End Sub

    Sub PopulateLimitada()
        TreeView1.Nodes.Clear()

        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("Select articulos_propiedad.idArticulos_propiedad,articulos_propiedad.Propiedad,articulos_propiedad.IDParent FROM libregco.articulos_propiedad where Articulos_Propiedad.idArticulos_propiedad='" + isParenttoFilter + "' and articulos_propiedad.Nulo=0 UNION ALL Select articulos_propiedad.idArticulos_propiedad,articulos_propiedad.Propiedad,articulos_propiedad.IDParent FROM libregco.articulos_propiedad where Articulos_Propiedad.IDParent='" + isParenttoFilter + "' and articulos_propiedad.Nulo=0", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Propiedades")
        ConLibregco.Close()

        Dim TablaPropiedades As DataTable = dstemp.Tables("Propiedades")

        Dim source = TablaPropiedades.AsEnumerable()
        Dim nodes = GetTreeNodes(
        source,
        Function(r) r.Field(Of Integer?)("IDParent") Is Nothing,
        Function(r, s) s.Where(Function(x) r("idArticulos_propiedad").Equals(x("IDParent"))),
        Function(r) New TreeNode With {.Text = r.Field(Of String)("Propiedad")})

        TreeView1.Nodes.AddRange(nodes.ToArray())

        TreeView1.ExpandAll()
    End Sub


    Private Sub TreeView1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        ' The code only executes if the user caused the checked state to change.
        If e.Action <> TreeViewAction.Unknown Then
            If e.Node.Nodes.Count > 0 Then
                ' Calls the CheckAllChildNodes method, passing in the current 
                ' Checked value of the TreeNode whose checked state changed. 
                Me.CheckAllChildNodes(e.Node, e.Node.Checked)
            End If
        End If
    End Sub

    Private Sub CheckAllChildNodes(treeNode As TreeNode, nodeChecked As Boolean)
        Dim node As TreeNode
        For Each node In treeNode.Nodes
            node.Checked = nodeChecked
            If node.Nodes.Count > 0 Then
                ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                Me.CheckAllChildNodes(node, nodeChecked)
            End If
        Next node
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        If GridView1.FocusedRowHandle >= 0 Then
            If GridView1.FocusedColumn.FieldName = "Imagen" Then

                If TypeConnection.Text = 1 Then
                    If GridView1.GetFocusedRowCellValue("RutaImagen").ToString = "" Then
                        Dim wFile As System.IO.FileStream
                        Dim OfdRutaFoto As New OpenFileDialog

                        OfdRutaFoto.RestoreDirectory = True
                        OfdRutaFoto.Title = ("Selección de imagen para dependencia")
                        OfdRutaFoto.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
                        OfdRutaFoto.FileName = ""
                        OfdRutaFoto.Multiselect = False

                        If OfdRutaFoto.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Dim myRow() As DataRow
                            myRow = TablaPropiedades.Select("ID = '" + GridView1.GetFocusedRowCellValue("ID").ToString + "'")
                            myRow(0)("RutaImagen") = OfdRutaFoto.FileName


                            wFile = New FileStream(OfdRutaFoto.FileName, FileMode.Open, FileAccess.Read)
                            myRow(0)("Imagen") = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()

                            'Guardando en la carpeta y generando nuevo destino
                            Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Propiedades")
                            If Exists = False Then
                                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Propiedades")
                            End If

                            Dim Exists1 As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Propiedades\Dependencias")
                            If Exists1 = False Then
                                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Propiedades\Dependencias")
                            End If


                            Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Artículos\Propiedades\Dependencias\" & GridView1.GetFocusedRowCellValue("ID").ToString & ".png"

                            If myRow(0)("RutaImagen") <> RutaDestino Then
                                Dim ExistFile As Boolean = System.IO.File.Exists(myRow(0)("RutaImagen"))
                                If ExistFile = True Then
                                    My.Computer.FileSystem.MoveFile(myRow(0)("RutaImagen"), RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                                    sqlQ = "UPDATE Libregco.articulos_propiedad SET PropiedadImagen='" + Replace(RutaDestino, "\", "\\") + "' WHERE idArticulos_propiedad= (" + GridView1.GetFocusedRowCellValue("ID").ToString + ")"
                                    GuardarDatos()

                                    myRow(0)("RutaImagen") = RutaDestino
                                End If

                            End If
                        End If
                    End If

                End If

            End If

        End If
    End Sub

    Private Sub GridView1_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("ID"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("Nota"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("Padre"), Nothing)
        view.SetRowCellValue(e.RowHandle, view.Columns("Imagen"), Nothing)
        view.SetRowCellValue(e.RowHandle, view.Columns("RutaImagen"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("Nulo"), 0)
        view.SetRowCellValue(e.RowHandle, view.Columns("Orden"), TablaPropiedades.Rows.Count)
    End Sub


End Class