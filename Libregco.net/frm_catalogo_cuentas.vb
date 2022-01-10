Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils.DragDrop
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frm_catalogo_cuentas
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Dim sqlQ As String

    Friend IsLimitedByFilter As Boolean = False
    Friend isParenttoFilter As String = ""

    Friend TablaCuentas As DataTable
    Private cloneCuentas As DataView

    Private Sub frm_catalogo_cuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        'Permisos = PasarPermisos(Me.Tag)
        CargarLibregco()
        CargarEmpresa()
        SetCuentasTable()
        LimpiarDatos()
        ActualizarTodo()
    End Sub


    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarEmpresa()
        'PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub LimpiarDatos()
        TablaCuentas.Rows.Clear()
        TreeView1.Nodes.Clear()
    End Sub

    Private Sub FillRepositoryCuentas()
        Dim dstemp As New DataSet


        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT CtaContable.IDCtaCont,IF(CtaContable.IDParent is NULL,NombreCuenta,Concat((Select NombreCuenta from CtaContable as PET where PET.IDCtaCont=CtaContable.IDParent),'.',CtaContable.NombreCuenta)) as NombreCuenta FROM libregco.CtaContable ORDER BY IDParent ASC,NoCuenta ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Cuentas")
        ConLibregco.Close()

        dstemp.Tables("Cuentas").Rows.Add()

        Dim TablaCuentas As DataTable = dstemp.Tables("Cuentas")

        RepositoryCuentas.DataSource = TablaCuentas
        RepositoryCuentas.ValueMember = "IDCtaCont"
        RepositoryCuentas.DisplayMember = "NombreCuenta"

        RepositoryCuentas.PopulateColumns()
        RepositoryCuentas.Columns(RepositoryCuentas.ValueMember).Visible = False
        RepositoryCuentas.ShowHeader = False
    End Sub

    Private Sub SetCuentasTable()
        TablaCuentas = New DataTable("Cuentas")

        TablaCuentas.Columns.Add("IDCtaCont", System.Type.GetType("System.String"))
        TablaCuentas.Columns.Add("NombreCuenta", System.Type.GetType("System.String"))
        TablaCuentas.Columns.Add("NoCuenta", System.Type.GetType("System.String"))
        TablaCuentas.Columns.Add("IDParent", System.Type.GetType("System.String"))
        TablaCuentas.Columns.Add("NoParent", System.Type.GetType("System.String"))
        TablaCuentas.Columns.Add("Comentario", System.Type.GetType("System.String"))
        TablaCuentas.Columns.Add("Nulo", System.Type.GetType("System.String"))
        TablaCuentas.Columns.Add("Numero", System.Type.GetType("System.String"))
        TablaCuentas.Columns.Add("Orden", System.Type.GetType("System.String"))

        GridControl1.DataSource = TablaCuentas
        SetUpGrid(GridControl1, TablaCuentas)
        'AdvBandedGridView1.Columns("IDParent").ColumnEdit = RepositoryCuentas
        'AdvBandedGridView1.Columns("Nulo").ColumnEdit = RepositoryChkNulo

        ''Estilos
        'AdvBandedGridView1.Columns("IDCtaCont").Visible = False
        'AdvBandedGridView1.Columns("NombreCuenta").Width = 240
        'AdvBandedGridView1.Columns("NombreCuenta").Caption = "Nombre"
        'AdvBandedGridView1.Columns("NoCuenta").Width = 200
        'AdvBandedGridView1.Columns("NoCuenta").Caption = "# Cuenta"
        'AdvBandedGridView1.Columns("IDParent").Width = 260
        'AdvBandedGridView1.Columns("IDParent").Caption = "Padre"
        'AdvBandedGridView1.Columns("Comentario").Width = 180
        'AdvBandedGridView1.Columns("Comentario").Caption = "Observación"
        'AdvBandedGridView1.Columns("Nulo").Width = 50

    End Sub


    Private Sub ActualizarTodo()
        IsLimitedByFilter = False
        isParenttoFilter = ""

        HabilitarControles()

        FillCuentas()
        Populate()

        GridControl1.Focus()
    End Sub

    Private Sub FillCuentas()
        FillRepositoryCuentas()
        TablaCuentas.Clear()

        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
            Using myCommand As MySqlCommand = New MySqlCommand("SELECT IDCtaCont,NombreCuenta,NoCuenta,IDParent,(Select NoCuenta from" & SysName.Text & "CtaContable as CtaParent Where CtaContable.IDParent=CtaParent.IDCtaCont) as NoParent,Comentario,Convert(Nulo,CHAR) as Nulo FROM" & SysName.Text & "CtaContable ORDER BY IDParent ASC,CtaContable.NoCuenta ASC", ConMixta)
                ConMixta.Open()

                Using myReader As MySqlDataReader = myCommand.ExecuteReader

                    TablaCuentas.Load(myReader, LoadOption.Upsert)

                    ConMixta.Close()

                End Using
            End Using
        End Using

        TablaCuentas.EndLoadData()

        AdvBandedGridView1.Columns("IDParent").GroupIndex = 0
        AdvBandedGridView1.ExpandAllGroups()
    End Sub

    Private Sub AdvBandedGridView1_ShownEditor(sender As Object, e As EventArgs) Handles AdvBandedGridView1.ShownEditor
        If AdvBandedGridView1.FocusedColumn.FieldName = "IDParent" Then
            If TypeOf AdvBandedGridView1.ActiveEditor Is DevExpress.XtraEditors.LookUpEdit Then
                Dim view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView = TryCast(sender, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
                If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                Else
                    Dim edit As DevExpress.XtraEditors.LookUpEdit
                    Dim table As DataTable
                    Dim row As DataRow
                    edit = CType(view.ActiveEditor, DevExpress.XtraEditors.LookUpEdit)
                    table = CType(edit.Properties.DataSource, DataTable)
                    cloneCuentas = New DataView(table)
                    row = view.GetDataRow(view.FocusedRowHandle)
                    cloneCuentas.RowFilter = "IDCtaCont<>'" + AdvBandedGridView1.GetFocusedRowCellValue("IDCtaCont").ToString + "'"
                    edit.Properties.DataSource = cloneCuentas
                    AdvBandedGridView1.ShowEditor()
                End If
            End If
        End If
    End Sub

    'Sub FillPropiedadesLimitada()
    '    Dim newImage As Image
    '    Dim ds As New DataSet

    '    FillRepositoryPropiedades()

    '    TablaCuentas.Rows.Clear()

    '    Con.Open()
    '    cmd = New MySqlCommand("SELECT idArticulos_propiedad,Propiedad,NotaPropiedad,IDParent,PropiedadImagen,Nulo,Orden FROM libregco.articulos_propiedad Where IDParent='" + isParenttoFilter + "' ORDER BY IDParent ASC,articulos_propiedad.Orden ASC", Con)
    '    Adaptador = New MySqlDataAdapter(cmd)
    '    Adaptador.Fill(ds, "Propiedadess")
    '    Con.Close()

    '    Dim Tabla As DataTable = ds.Tables("Propiedadess")

    '    For Each dt As DataRow In Tabla.Rows
    '        If dt.Item("PropiedadImagen").ToString <> "" Then
    '            If System.IO.File.Exists(dt.Item("PropiedadImagen")) Then
    '                Dim wFile As System.IO.FileStream

    '                wFile = New FileStream(dt.Item("PropiedadImagen"), FileMode.Open, FileAccess.Read)
    '                newImage = System.Drawing.Image.FromStream(wFile)
    '                wFile.Close()
    '            Else
    '                newImage = Nothing
    '            End If
    '        Else
    '            newImage = Nothing
    '        End If

    '        TablaCuentas.Rows.Add(dt.Item("idArticulos_propiedad"), dt.Item("Propiedad"), dt.Item("NotaPropiedad"), dt.Item("IDParent"), newImage, dt.Item("PropiedadImagen"), dt.Item("Nulo"), dt.Item("Orden"))
    '    Next

    '    AdvBandedGridView1.Columns(3).GroupIndex = 0
    '    AdvBandedGridView1.ExpandAllGroups()
    'End Sub

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

    'Private Sub AdvBandedGridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AdvBandedGridView1.CellValueChanged
    '    'If e.RowHandle >= 0 Then

    '    If AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta") Is Nothing Then
    '        Exit Sub
    '    ElseIf AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString = "" Then
    '        Exit Sub
    '    End If

    '    ConLibregco.Open()

    '    If AdvBandedGridView1.GetDataRow(e.RowHandle)("IDCtaCont").ToString = "" Then
    '        If AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString <> "" Then
    '            If AdvBandedGridView1.GetDataRow(e.RowHandle)("IDParent").ToString = "" Then
    '                sqlQ = "INSERT INTO CtaContable (NoCuenta,NombreCuenta,Comentario,Nulo) VALUES ('" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NoCuenta").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("Comentario").ToString + "','" + Convert.ToInt16(AdvBandedGridView1.GetDataRow(e.RowHandle)("Nulo").ToString).ToString + "')"
    '                cmd = New MySqlCommand(sqlQ, ConLibregco)
    '                cmd.ExecuteNonQuery()
    '            Else
    '                sqlQ = "INSERT INTO CtaContable (NoCuenta,NombreCuenta,Comentario,IDParent,Nulo) VALUES ('" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NoCuenta").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("Comentario").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("IDParent").ToString + "','" + Convert.ToInt16(AdvBandedGridView1.GetDataRow(e.RowHandle)("Nulo").ToString).ToString + "')"
    '                cmd = New MySqlCommand(sqlQ, ConLibregco)
    '                cmd.ExecuteNonQuery()
    '            End If
    '            cmd = New MySqlCommand("Select IDCtaCont from CtaContable where IDCtaCont= (Select Max(IDCtaCont) from CtaContable)", ConLibregco)
    '            AdvBandedGridView1.GetDataRow(e.RowHandle)("IDCtaCont") = Convert.ToDouble(cmd.ExecuteScalar)
    '        End If

    '    Else
    '        If AdvBandedGridView1.GetDataRow(e.RowHandle)("IDParent").ToString = "" Then
    '            sqlQ = "UPDATE CtaContable SET NoCuenta='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NoCuenta").ToString + "',NombreCuenta='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString + "',Comentario='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("Comentario").ToString + "',IDParent=NULL,Nulo='" + Convert.ToInt16(AdvBandedGridView1.GetDataRow(e.RowHandle)("Nulo").ToString).ToString + "' WHERE IDCtaCont='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("IDCtaCont").ToString + "'"
    '            cmd = New MySqlCommand(sqlQ, ConLibregco)
    '            cmd.ExecuteNonQuery()
    '        Else
    '            sqlQ = "UPDATE CtaContable SET NoCuenta='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NoCuenta").ToString + "',NombreCuenta='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString + "',Comentario='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("Comentario").ToString + "',IDParent='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("IDParent").ToString + "',Nulo='" + Convert.ToInt16(AdvBandedGridView1.GetDataRow(e.RowHandle)("Nulo").ToString).ToString + "' WHERE IDCtaCont='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("IDCtaCont").ToString + "'"
    '            cmd = New MySqlCommand(sqlQ, ConLibregco)
    '            cmd.ExecuteNonQuery()
    '        End If
    '    End If

    '    ConLibregco.Close()

    '    If IsLimitedByFilter = False Then
    '        Populate()
    '        FillRepositoryCuentas()
    '    Else
    '        PopulateLimitada()
    '        FillRepositoryCuentas()
    '    End If

    '    AdvBandedGridView1.ExpandAllGroups()

    '    'End If
    'End Sub

    Private Sub Populate()
        TreeView1.Nodes.Clear()

        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("Select CtaContable.IDCtaCont,CtaContable.NoCuenta,CtaContable.NombreCuenta,CtaContable.IDParent FROM libregco.CtaContable where CtaContable.Nulo=0 ORDER BY IDParent ASC,CtaContable.NoCuenta ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Cuentas")
        ConLibregco.Close()

        Dim TablaCuentass As DataTable = dstemp.Tables("Cuentas")

        Dim source = TablaCuentass.AsEnumerable()
        Dim nodes = GetTreeNodes(source, Function(r) r.Field(Of Integer?)("IDParent") Is Nothing, Function(r, s) s.Where(Function(x) r("IDCtaCont").Equals(x("IDParent"))), Function(r) New TreeNode With {.Text = r.Field(Of String)("NoCuenta") & " - " & r.Field(Of String)("NombreCuenta")})

        TreeView1.Nodes.AddRange(nodes.ToArray())

        TreeView1.ExpandAll()
    End Sub

    Sub PopulateLimitada()
        TreeView1.Nodes.Clear()

        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("Select CtaContable.IDCtaCont,CtaContable.NombreCuenta,CtaContable.IDParent FROM libregco.CtaContable where CtaContable.IDCtaCont='" + isParenttoFilter + "' and CtaContable.Nulo=0 UNION ALL Select CtaContable.IDCtaCont,CtaContable.NombreCuenta,CtaContable.IDParent FROM libregco.CtaContable where CtaContable.IDParent='" + isParenttoFilter + "' and CtaContable.Nulo=0", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Cuentas")
        ConLibregco.Close()

        Dim TablaCuentas As DataTable = dstemp.Tables("Cuentas")

        Dim source = TablaCuentas.AsEnumerable()
        Dim nodes = GetTreeNodes(
        source,
        Function(r) r.Field(Of Integer?)("IDParent") Is Nothing,
        Function(r, s) s.Where(Function(x) r("IDCtaCont").Equals(x("IDParent"))),
        Function(r) New TreeNode With {.Text = r.Field(Of String)("NombreCuenta")})

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

    'Private Sub AdvBandedGridView1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles AdvBandedGridView1.RowCellClick
    '    If AdvBandedGridView1.FocusedRowHandle >= 0 Then
    '        If AdvBandedGridView1.FocusedColumn.FieldName = "Imagen" Then

    '            If TypeConnection.Text = 1 Then
    '                If AdvBandedGridView1.GetFocusedRowCellValue("RutaImagen").ToString = "" Then
    '                    Dim wFile As System.IO.FileStream
    '                    Dim OfdRutaFoto As New OpenFileDialog

    '                    OfdRutaFoto.RestoreDirectory = True
    '                    OfdRutaFoto.Title = ("Selección de imagen para dependencia")
    '                    OfdRutaFoto.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
    '                    OfdRutaFoto.FileName = ""
    '                    OfdRutaFoto.Multiselect = False

    '                    If OfdRutaFoto.ShowDialog = Windows.Forms.DialogResult.OK Then
    '                        Dim myRow() As DataRow
    '                        myRow = TablaPropiedades.Select("ID = '" + AdvBandedGridView1.GetFocusedRowCellValue("ID").ToString + "'")
    '                        myRow(0)("RutaImagen") = OfdRutaFoto.FileName


    '                        wFile = New FileStream(OfdRutaFoto.FileName, FileMode.Open, FileAccess.Read)
    '                        myRow(0)("Imagen") = System.Drawing.Image.FromStream(wFile)
    '                        wFile.Close()

    '                        'Guardando en la carpeta y generando nuevo destino
    '                        Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Propiedades")
    '                        If Exists = False Then
    '                            System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Propiedades")
    '                        End If

    '                        Dim Exists1 As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Propiedades\Dependencias")
    '                        If Exists1 = False Then
    '                            System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Artículos\Propiedades\Dependencias")
    '                        End If


    '                        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Artículos\Propiedades\Dependencias\" & AdvBandedGridView1.GetFocusedRowCellValue("ID").ToString & ".png"

    '                        If myRow(0)("RutaImagen") <> RutaDestino Then
    '                            Dim ExistFile As Boolean = System.IO.File.Exists(myRow(0)("RutaImagen"))
    '                            If ExistFile = True Then
    '                                My.Computer.FileSystem.MoveFile(myRow(0)("RutaImagen"), RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

    '                                sqlQ = "UPDATE Libregco.articulos_propiedad SET PropiedadImagen='" + Replace(RutaDestino, "\", "\\") + "' WHERE idArticulos_propiedad= (" + AdvBandedGridView1.GetFocusedRowCellValue("ID").ToString + ")"
    '                                GuardarDatos()

    '                                myRow(0)("RutaImagen") = RutaDestino
    '                            End If

    '                        End If
    '                    End If
    '                End If

    '            End If

    '        End If

    '    End If
    'End Sub

    Private Sub AdvBandedGridView1_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles AdvBandedGridView1.InitNewRow
        'TablaCuentas.Columns.Add("IDCtaCont", System.Type.GetType("System.String"))
        'TablaCuentas.Columns.Add("NombreCuenta", System.Type.GetType("System.String"))
        'TablaCuentas.Columns.Add("NoCuenta", System.Type.GetType("System.String"))
        'TablaCuentas.Columns.Add("IDParent", System.Type.GetType("System.String"))
        'TablaCuentas.Columns.Add("Comentario", System.Type.GetType("System.String"))
        'TablaCuentas.Columns.Add("Nulo", System.Type.GetType("System.String"))
        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("IDCtaCont"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("IDParent"), Nothing)
        view.SetRowCellValue(e.RowHandle, view.Columns("Nulo"), "0")
    End Sub

    Private Sub AdvBandedGridView1_ValidateRow(sender As Object, e As XtraGrid.Views.Base.ValidateRowEventArgs) Handles AdvBandedGridView1.ValidateRow
        Try
            If AdvBandedGridView1.IsFocusedView = True Then
                Dim obj As DataRowView = AdvBandedGridView1.GetRow(e.RowHandle)

                If obj.Item("NombreCuenta") = "" Or obj.Item("NombreCuenta") Is Nothing Then
                    e.Valid = False
                Else
                    e.Valid = True

                    If ConLibregco.State = ConnectionState.Open Then
                        ConLibregco.Close()
                    End If

                    ConLibregco.Open()

                    If AdvBandedGridView1.GetDataRow(e.RowHandle)("IDCtaCont").ToString = "" Then
                        If AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString <> "" Then
                            If AdvBandedGridView1.GetDataRow(e.RowHandle)("IDParent").ToString = "" Then
                                sqlQ = "INSERT INTO CtaContable (NoCuenta,NombreCuenta,Comentario,Nulo) VALUES ('" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NoCuenta").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("Comentario").ToString + "','" + Convert.ToInt16(AdvBandedGridView1.GetDataRow(e.RowHandle)("Nulo").ToString).ToString + "')"
                                cmd = New MySqlCommand(sqlQ, ConLibregco)
                                cmd.ExecuteNonQuery()
                            Else
                                sqlQ = "INSERT INTO CtaContable (NoCuenta,NombreCuenta,Comentario,IDParent,Nulo) VALUES ('" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NoCuenta").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("Comentario").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("IDParent").ToString + "','" + Convert.ToInt16(AdvBandedGridView1.GetDataRow(e.RowHandle)("Nulo").ToString).ToString + "')"
                                cmd = New MySqlCommand(sqlQ, ConLibregco)
                                cmd.ExecuteNonQuery()
                            End If
                            cmd = New MySqlCommand("Select IDCtaCont from CtaContable where IDCtaCont= (Select Max(IDCtaCont) from CtaContable)", ConLibregco)
                            AdvBandedGridView1.GetDataRow(e.RowHandle)("IDCtaCont") = Convert.ToDouble(cmd.ExecuteScalar)
                        End If

                    Else
                        If AdvBandedGridView1.GetDataRow(e.RowHandle)("IDParent").ToString = "" Then
                            sqlQ = "UPDATE CtaContable SET NoCuenta='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NoCuenta").ToString + "',NombreCuenta='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString + "',Comentario='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("Comentario").ToString + "',IDParent=NULL,Nulo='" + Convert.ToInt16(AdvBandedGridView1.GetDataRow(e.RowHandle)("Nulo").ToString).ToString + "' WHERE IDCtaCont='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("IDCtaCont").ToString + "'"
                            cmd = New MySqlCommand(sqlQ, ConLibregco)
                            cmd.ExecuteNonQuery()
                        Else
                            sqlQ = "UPDATE CtaContable SET NoCuenta='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NoCuenta").ToString + "',NombreCuenta='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString + "',Comentario='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("Comentario").ToString + "',IDParent='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("IDParent").ToString + "',Nulo='" + Convert.ToInt16(AdvBandedGridView1.GetDataRow(e.RowHandle)("Nulo").ToString).ToString + "' WHERE IDCtaCont='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("IDCtaCont").ToString + "'"
                            cmd = New MySqlCommand(sqlQ, ConLibregco)
                            cmd.ExecuteNonQuery()
                        End If
                    End If

                    ConLibregco.Close()

                    If IsLimitedByFilter = False Then
                        Populate()
                        FillRepositoryCuentas()
                    Else
                        PopulateLimitada()
                        FillRepositoryCuentas()
                    End If

                    AdvBandedGridView1.ExpandAllGroups()
                End If
            End If
        Catch ex As Exception
            e.Valid = False
        End Try


    End Sub

    Private Sub AdvBandedGridView1_CellValueChanged(sender As Object, e As XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AdvBandedGridView1.CellValueChanged
        If AdvBandedGridView1.IsNewItemRow(e.RowHandle) Then
        Else
            Dim obj As DataRowView = AdvBandedGridView1.GetRow(e.RowHandle)

            If obj.Item("NombreCuenta") = "" Or obj.Item("NombreCuenta") Is Nothing Then
            Else
                If ConLibregco.State = ConnectionState.Open Then
                    ConLibregco.Close()
                End If

                ConLibregco.Open()

                If AdvBandedGridView1.GetDataRow(e.RowHandle)("IDCtaCont").ToString = "" Then
                    If AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString <> "" Then
                        If AdvBandedGridView1.GetDataRow(e.RowHandle)("IDParent").ToString = "" Then
                            sqlQ = "INSERT INTO CtaContable (NoCuenta,NombreCuenta,Comentario,Nulo) VALUES ('" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NoCuenta").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("Comentario").ToString + "','" + Convert.ToInt16(AdvBandedGridView1.GetDataRow(e.RowHandle)("Nulo").ToString).ToString + "')"
                            cmd = New MySqlCommand(sqlQ, ConLibregco)
                            cmd.ExecuteNonQuery()
                        Else
                            sqlQ = "INSERT INTO CtaContable (NoCuenta,NombreCuenta,Comentario,IDParent,Nulo) VALUES ('" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NoCuenta").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("Comentario").ToString + "','" + AdvBandedGridView1.GetDataRow(e.RowHandle)("IDParent").ToString + "','" + Convert.ToInt16(AdvBandedGridView1.GetDataRow(e.RowHandle)("Nulo").ToString).ToString + "')"
                            cmd = New MySqlCommand(sqlQ, ConLibregco)
                            cmd.ExecuteNonQuery()
                        End If
                        cmd = New MySqlCommand("Select IDCtaCont from CtaContable where IDCtaCont= (Select Max(IDCtaCont) from CtaContable)", ConLibregco)
                        AdvBandedGridView1.GetDataRow(e.RowHandle)("IDCtaCont") = Convert.ToDouble(cmd.ExecuteScalar)
                    End If

                Else
                    If AdvBandedGridView1.GetDataRow(e.RowHandle)("IDParent").ToString = "" Then
                        sqlQ = "UPDATE CtaContable SET NoCuenta='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NoCuenta").ToString + "',NombreCuenta='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString + "',Comentario='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("Comentario").ToString + "',IDParent=NULL,Nulo='" + Convert.ToInt16(AdvBandedGridView1.GetDataRow(e.RowHandle)("Nulo").ToString).ToString + "' WHERE IDCtaCont='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("IDCtaCont").ToString + "'"
                        cmd = New MySqlCommand(sqlQ, ConLibregco)
                        cmd.ExecuteNonQuery()
                    Else
                        sqlQ = "UPDATE CtaContable SET NoCuenta='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NoCuenta").ToString + "',NombreCuenta='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("NombreCuenta").ToString + "',Comentario='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("Comentario").ToString + "',IDParent='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("IDParent").ToString + "',Nulo='" + Convert.ToInt16(AdvBandedGridView1.GetDataRow(e.RowHandle)("Nulo").ToString).ToString + "' WHERE IDCtaCont='" + AdvBandedGridView1.GetDataRow(e.RowHandle)("IDCtaCont").ToString + "'"
                        cmd = New MySqlCommand(sqlQ, ConLibregco)
                        cmd.ExecuteNonQuery()
                    End If
                End If

                ConLibregco.Close()

                If IsLimitedByFilter = False Then
                    Populate()
                    FillRepositoryCuentas()
                Else
                    PopulateLimitada()
                    FillRepositoryCuentas()
                End If

                AdvBandedGridView1.ExpandAllGroups()
            End If
        End If

    End Sub

    Private Sub AdvBandedGridView1_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles AdvBandedGridView1.ShowingEditor
        If AdvBandedGridView1.FocusedColumn.FieldName = "Nulo" Then
            If AdvBandedGridView1.IsNewItemRow(AdvBandedGridView1.FocusedRowHandle) Then
                AdvBandedGridView1.HideEditor()
            End If
        End If
    End Sub

    Public Sub SetUpGrid(ByVal grid As DevExpress.XtraGrid.GridControl, ByVal table As DataTable)
        Dim view As GridView = TryCast(grid.MainView, GridView)
        grid.DataSource = table
        'view.OptionsBehavior.Editable = False

        HandleBehaviorDragDropEvents()
    End Sub

    Public Sub HandleBehaviorDragDropEvents()
        Dim gridControlBehavior As DragDropBehavior = BehaviorManager1.GetBehavior(Of DragDropBehavior)(Me.AdvBandedGridView1)
        AddHandler gridControlBehavior.DragDrop, AddressOf Behavior_DragDrop
        AddHandler gridControlBehavior.DragOver, AddressOf Behavior_DragOver
    End Sub
    Private Sub Behavior_DragOver(ByVal sender As Object, ByVal e As DragOverEventArgs)
        Dim args As DragOverGridEventArgs = DragOverGridEventArgs.GetDragOverGridEventArgs(e)
        e.InsertType = args.InsertType
        e.InsertIndicatorLocation = args.InsertIndicatorLocation
        e.Action = args.Action
        Cursor.Current = args.Cursor
        args.Handled = True
    End Sub
    Private Sub Behavior_DragDrop(ByVal sender As Object, ByVal e As DevExpress.Utils.DragDrop.DragDropEventArgs)
        Dim targetGrid As GridView = TryCast(e.Target, GridView)
        Dim sourceGrid As GridView = TryCast(e.Source, GridView)
        If e.Action = DragDropActions.None OrElse targetGrid IsNot sourceGrid Then
            Return
        End If
        Dim sourceTable As DataTable = TryCast(sourceGrid.GridControl.DataSource, DataTable)

        Dim hitPoint As Point = targetGrid.GridControl.PointToClient(Cursor.Position)
        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = targetGrid.CalcHitInfo(hitPoint)

        Dim sourceHandles() As Integer = e.GetData(Of Integer())()

        Dim targetRowHandle As Integer = hitInfo.RowHandle
        Dim targetRowIndex As Integer = targetGrid.GetDataSourceRowIndex(targetRowHandle)

        Dim draggedRows As New List(Of DataRow)()
        For Each sourceHandle As Integer In sourceHandles
            Dim oldRowIndex As Integer = sourceGrid.GetDataSourceRowIndex(sourceHandle)
            Dim oldRow As DataRow = sourceTable.Rows(oldRowIndex)
            draggedRows.Add(oldRow)
        Next sourceHandle

        Dim newRowIndex As Integer

        Select Case e.InsertType
            Case InsertType.Before
                newRowIndex = If(targetRowIndex > sourceHandles(sourceHandles.Length - 1), targetRowIndex - 1, targetRowIndex)
                For i As Integer = draggedRows.Count - 1 To 0 Step -1
                    Dim oldRow As DataRow = draggedRows(i)
                    Dim newRow As DataRow = sourceTable.NewRow()
                    newRow.ItemArray = oldRow.ItemArray
                    sourceTable.Rows.Remove(oldRow)
                    sourceTable.Rows.InsertAt(newRow, newRowIndex)
                Next i
            Case InsertType.After
                newRowIndex = If(targetRowIndex < sourceHandles(0), targetRowIndex + 1, targetRowIndex)
                For i As Integer = 0 To draggedRows.Count - 1
                    Dim oldRow As DataRow = draggedRows(i)
                    Dim newRow As DataRow = sourceTable.NewRow()
                    newRow.ItemArray = oldRow.ItemArray
                    sourceTable.Rows.Remove(oldRow)
                    sourceTable.Rows.InsertAt(newRow, newRowIndex)
                Next i
            Case Else
                newRowIndex = -1
        End Select
        Dim insertedIndex As Integer = targetGrid.GetRowHandle(newRowIndex)
        targetGrid.FocusedRowHandle = insertedIndex
        targetGrid.SelectRow(targetGrid.FocusedRowHandle)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

    End Sub

    Private Sub RepositoryCuentas_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryCuentas.EditValueChanged
        If AdvBandedGridView1.GetFocusedRowCellValue("IDParent") Is Nothing Or IsDBNull(AdvBandedGridView1.GetFocusedRowCellValue("IDParent")) Then
            'MessageBox.Show("Vacío")
        Else

            If ConMixta.State = ConnectionState.Open Then
                ConMixta.Close()
            End If

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT Count(*) as Cantidad FROM libregco.ctacontable where IDParent='" + AdvBandedGridView1.GetFocusedRowCellValue("IDParent").ToString + "'", ConMixta)
            Dim value As String = Convert.ToString(cmd.ExecuteScalar)
            AdvBandedGridView1.SetFocusedRowCellValue("Numero", value)
            AdvBandedGridView1.SetFocusedRowCellValue("NoCuenta", AdvBandedGridView1.GetFocusedRowCellValue("NoParent") & "." & value)
            AdvBandedGridView1.SetFocusedRowCellValue("Orden", value)
            ConMixta.Close()
        End If

    End Sub
End Class