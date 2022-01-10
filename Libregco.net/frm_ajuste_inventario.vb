Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid

Public Class frm_ajuste_inventario
    '
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim SelectCommand As String = "SELECT IDPrecios,Articulos.IDArticulo,Articulos.Descripcion,Articulos.Referencia,PrecioArticulo.IDMedida,Articulos.ExistenciaTotal,Fraccionamiento,Costo FROM libregco.articulos INNER JOIN Libregco.PrecioArticulo on Articulos.IDArticulo=PrecioArticulo.IDArticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrecioArticulo.Contenido>0"
    Dim FullCommand As String
    Dim Permisos, PermisosArticulos As New ArrayList

    Friend TablaArticulos As DataTable
    Dim RepositoryID As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}
    Dim RepositoryDescrip As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit() With {.WordWrap = True, .AcceptsReturn = False, .AcceptsTab = False}
    Dim RepositoryCantidad As New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit() With {.MinValue = "-100000", .MaxValue = "100000", .NullValuePrompt = 0, .NullValuePromptShowForEmptyValue = 0, .AllowNullInput = DevExpress.Utils.DefaultBoolean.False}
    Dim RepositoryMedida As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
    Dim RepositoryTipoAjuste As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
    Dim RepositoryCosto As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
    Dim RepositoryImporte As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()

    Private Sub frm_ajuste_inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        PermisosArticulos = PasarPermisos(3)

        For i As Integer = 0 To CheckedListBox1.Items.Count - 2
            CheckedListBox1.SetItemCheckState(i, CheckState.Checked)
        Next

        SetArticulosTable()
        SpinEdit1.Value = 2000
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        txtFecha.Text = Today.ToString("dd/MM/yyyy")
        ChkNulo.Checked = False
        FillAlmacen()
        TablaArticulos.Rows.Clear()
        RefrescarTabla()
    End Sub

    Function CheckIfHaveChangeds() As Boolean
        Dim HaveCh As Boolean = False
        For Each dt As DataRow In TablaArticulos.Rows
            If CDbl(dt.Item("Ajuste")) <> 0 Then
                HaveCh = True
            End If

            If HaveCh = True Then
                Exit For
            End If
        Next

        Return HaveCh
    End Function

    Private Sub SetArticulosTable()
        TablaArticulos = New DataTable("Articulos")
        TablaArticulos.Columns.Add("IDDetalle", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("IDPrecios", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("IDArticulo", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Referencia", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Medida", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Existencia", System.Type.GetType("System.Double"))

        TablaArticulos.Columns.Add("Ajuste", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("Resultado", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("Tipoajuste", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Fraccionamiento", System.Type.GetType("System.String"))
        TablaArticulos.Columns.Add("Costo", System.Type.GetType("System.Double"))
        TablaArticulos.Columns.Add("Importe", System.Type.GetType("System.Double"))

        GridControl1.DataSource = TablaArticulos

        'RepositoryMedida
        Dim ds As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDMedida,Medida FROM libregco.Medida", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "Medida")

        RepositoryMedida.DataSource = ds.Tables("Medida")
        RepositoryMedida.ValueMember = "IDMedida"
        RepositoryMedida.DisplayMember = "Medida"
        RepositoryMedida.PopulateColumns()
        RepositoryMedida.Columns(0).Visible = False
        RepositoryMedida.Columns(0).Caption = "ID"
        RepositoryMedida.Columns(1).Caption = "Medida"

        'RepositoryTipoAjuste
        Dim dsajustes As New DataSet

        cmd = New MySqlCommand("SELECT IDAjusteInventario,TipodeAjuste FROM libregco.tipodeajuste where IDAjusteInventario<3", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dsajustes, "tipodeajuste")
        ConLibregco.Close()

        dsajustes.Tables("tipodeajuste").Rows.Add()

        RepositoryTipoAjuste.DataSource = dsajustes.Tables("tipodeajuste")
        RepositoryTipoAjuste.ValueMember = "IDAjusteInventario"
        RepositoryTipoAjuste.DisplayMember = "TipodeAjuste"
        RepositoryTipoAjuste.PopulateColumns()
        RepositoryTipoAjuste.Columns(0).Caption = "ID"
        RepositoryTipoAjuste.Columns(0).Visible = False
        RepositoryTipoAjuste.Columns(1).Caption = "T/Ajuste"


        RepositoryCosto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryCosto.Mask.EditMask = "c"
        RepositoryCosto.Mask.UseMaskAsDisplayFormat = True
        RepositoryCosto.NullText = CDbl(0).ToString("C")
        RepositoryCosto.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryImporte.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryImporte.Mask.EditMask = "c"
        RepositoryImporte.Mask.UseMaskAsDisplayFormat = True
        RepositoryImporte.NullText = CDbl(0).ToString("C")
        RepositoryImporte.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        GridView1.Columns("IDArticulo").ColumnEdit = RepositoryID
        GridView1.Columns("Descripcion").ColumnEdit = RepositoryDescrip
        GridView1.Columns("Ajuste").ColumnEdit = RepositoryCantidad
        GridView1.Columns("Medida").ColumnEdit = RepositoryMedida
        GridView1.Columns("Tipoajuste").ColumnEdit = RepositoryTipoAjuste
        GridView1.Columns("Costo").ColumnEdit = RepositoryCosto
        GridView1.Columns("Importe").ColumnEdit = RepositoryImporte

        'Estilos
        GridView1.Columns("IDDetalle").Visible = False
        GridView1.Columns("IDPrecios").Visible = False
        GridView1.Columns("IDArticulo").Caption = "Código"
        GridView1.Columns("IDArticulo").Width = 80
        GridView1.Columns("Descripcion").Caption = "Descripción"
        GridView1.Columns("Descripcion").Width = 260
        GridView1.Columns("Descripcion").OptionsColumn.AllowEdit = False
        GridView1.Columns("Descripcion").OptionsColumn.ReadOnly = True
        GridView1.Columns("Referencia").Width = 180
        GridView1.Columns("Referencia").OptionsColumn.AllowEdit = False
        GridView1.Columns("Referencia").OptionsColumn.ReadOnly = True
        GridView1.Columns("Medida").Width = 140
        GridView1.Columns("Medida").OptionsColumn.AllowEdit = False
        GridView1.Columns("Medida").OptionsColumn.ReadOnly = True
        GridView1.Columns("Existencia").Width = 70
        GridView1.Columns("Existencia").OptionsColumn.AllowEdit = False
        GridView1.Columns("Existencia").OptionsColumn.ReadOnly = True
        GridView1.Columns("Ajuste").Width = 70
        GridView1.Columns("Ajuste").Caption = "Cant."
        GridView1.Columns("Resultado").Width = 70
        GridView1.Columns("Resultado").OptionsColumn.AllowEdit = False
        GridView1.Columns("Resultado").OptionsColumn.ReadOnly = True
        GridView1.Columns("Tipoajuste").Caption = "Tipo de ajuste"
        GridView1.Columns("Tipoajuste").Width = 160
        GridView1.Columns("Tipoajuste").OptionsColumn.AllowEdit = False
        GridView1.Columns("Tipoajuste").OptionsColumn.ReadOnly = True

        GridView1.Columns("Fraccionamiento").Visible = False
        GridView1.Columns("Importe").OptionsColumn.AllowEdit = False
        GridView1.Columns("Importe").OptionsColumn.ReadOnly = True
        GridView1.Columns("Importe").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:c2}")

    End Sub

    Private Sub FillAlmacen()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Almacen FROM Almacen INNER JOIN Empleados on Almacen.IDAlmacen=Empleados.IDAlmacen Where IDEmpleado='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "' ORDER BY Almacen.Almacen ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Almacen")
        CbxAlmacen.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Almacen")

        For Each Fila As DataRow In Tabla.Rows
            CbxAlmacen.Items.Add(Fila.Item("Almacen"))
        Next

        If Tabla.Rows.Count > 0 Then
            CbxAlmacen.SelectedIndex = 0
        Else
            MessageBox.Show("No se detectaron almacenes disponibles. Esto se puede deber a que no se encuentra un usuario definido en el formulario o porque no se encontraron almacenes en la base de datos." & vbNewLine & vbNewLine & "Por favor revise las condiciones o el sistema generará errores en la facturación.", "Sé detectó un fallo crítico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtFecha.Text = Today.ToString("dd/MM/yyyy")
        txtHora.Text = TimeOfDay.ToString("hh:mm:ss")
    End Sub

    Private Sub CbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxAlmacen.SelectedIndexChanged
        SetIDAlmacen()
    End Sub

    Private Sub SetIDAlmacen()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen='" + CbxAlmacen.SelectedItem + "'", Con)
        CbxAlmacen.Tag = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub


    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            DesHabilitarControles()
        Else
            HabilitarControles()
        End If
    End Sub

    Private Sub HabilitarControles()
        CbxAlmacen.Enabled = True
        txtReferencia.Enabled = True
        txtComentario.Enabled = True
        GridControl1.Enabled = True
    End Sub

    Private Sub DesHabilitarControles()
        CbxAlmacen.Enabled = False
        txtReferencia.Enabled = False
        txtComentario.Enabled = False
        GridControl1.Enabled = False
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
            Con.Close()
        End Try
    End Sub

    Private Sub CollapseMenu()
        If NavigationPane2.State = DevExpress.XtraBars.Navigation.NavigationPaneState.Default Then
            NavigationPane2.State = DevExpress.XtraBars.Navigation.NavigationPaneState.Collapsed
        End If
    End Sub


    Private Sub LimpiarDatos()
        CollapseMenu()
        txtFecha.Clear()
        txtSecondID.Clear()
        txtHora.Clear()
        txtIDAjuste.Clear()
        CbxAlmacen.Items.Clear()
        txtReferencia.Clear()
        txtComentario.Clear()
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
        txtBuscar.Text = ""
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
    End Sub

    Private Sub UltAjuste()
        Try
            If txtIDAjuste.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDAjusteInventario from MovimientoInventario where IDAjusteInventario= (Select Max(IDAjusteInventario) from MovimientoInventario)", Con)
                txtIDAjuste.Text = Convert.ToDouble(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDAjuste.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el ajuste de inventario?", "Imprimir Ajuste de Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub CalcExistencias()
        CalcExistencia()
        CalcExistenciaAlm()
    End Sub

    Private Sub CalcExistenciaAlm()
        For i As Integer = 0 To GridView1.DataRowCount - 1
            FunctCalcInvAlmacenes(GridView1.GetRowCellValue(i, "IDArticulo").ToString, GridView1.GetRowCellValue(i, "IDPrecios").ToString)
        Next

    End Sub

    Private Sub CalcExistencia()
        For i As Integer = 0 To GridView1.DataRowCount - 1
            FunctCalcInventarioGral(GridView1.GetRowCellValue(i, "IDArticulo").ToString)
        Next
    End Sub

    Private Sub InsertArticulos()
        Con.Open()

        For i As Integer = 0 To GridView1.DataRowCount - 1

            If CStr(GridView1.GetRowCellValue(i, "IDDetalle")) = "" Then

                If CDbl(GridView1.GetRowCellValue(i, "Ajuste")) <> 0 Then
                    sqlQ = "INSERT INTO Movimientoinvdetalle (IDMovimientoInventario,IDPrecio,IDArticulo,Descripcion,IDMedida,Cantidad,Precio,Importe,IDAlmacen,IDTipoAjusteDetalle,ExistenciaAnterior) VALUES ('" + txtIDAjuste.Text + "','" + GridView1.GetRowCellValue(i, "IDPrecios").ToString + "','" + GridView1.GetRowCellValue(i, "IDArticulo").ToString + "','" + GridView1.GetRowCellValue(i, "Descripcion").ToString + "','" + GridView1.GetRowCellValue(i, "Medida").ToString + "','" + CDbl(GridView1.GetRowCellValue(i, "Ajuste")).ToString + "','" + CDbl(GridView1.GetRowCellValue(i, "Costo")).ToString + "','" + CDbl(GridView1.GetRowCellValue(i, "Importe")).ToString + "','" + CbxAlmacen.Tag.ToString + "','" + GridView1.GetRowCellValue(i, "Tipoajuste").ToString + "','" + CDbl(GridView1.GetRowCellValue(i, "Existencia")).ToString + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()

                    cmd = New MySqlCommand("Select IDMovimientoDetalle from MovimientoInvdetalle where IDMovimientoDetalle= (Select Max(IDMovimientoDetalle) from MovimientoInvdetalle)", Con)
                    GridView1.SetRowCellValue(i, "IDDetalle", Convert.ToString(cmd.ExecuteScalar()))

                End If
            Else
                If CDbl(GridView1.GetRowCellValue(i, "Ajuste")) <> 0 Then
                    sqlQ = "UPDATE Movimientoinvdetalle SET IDPrecio='" + GridView1.GetRowCellValue(i, "IDPrecios").ToString + "',IDArticulo='" + GridView1.GetRowCellValue(i, "IDArticulo").ToString + "',Descripcion='" + GridView1.GetRowCellValue(i, "Descripcion").ToString + "',IDMedida='" + GridView1.GetRowCellValue(i, "Medida").ToString + "',Cantidad='" + CDbl(GridView1.GetRowCellValue(i, "Ajuste")).ToString + "',Precio='" + CDbl(GridView1.GetRowCellValue(i, "Costo")).ToString + "',Importe='" + CDbl(GridView1.GetRowCellValue(i, "Importe")).ToString + "',IDAlmacen='" + CbxAlmacen.Tag.ToString + "',IDTipoAjusteDetalle='" + GridView1.GetRowCellValue(i, "Tipoajuste").ToString + "',ExistenciaAnterior='" + CDbl(GridView1.GetRowCellValue(i, "Existencia")).ToString + "' Where IDMovimientoDetalle='" + GridView1.GetRowCellValue(i, "IDDetalle").ToString + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                Else
                    sqlQ = "Delete from Movimientoinvdetalle Where IDMovimientoDetalle= '" + GridView1.GetRowCellValue(i, "IDDetalle").ToString + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If

            End If

        Next

        Con.Close()

        'ShowSavedRows()
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

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub BuscarAjusteInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarAjusteInventarioToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDAjuste.Text = "" Then
            If CheckIfHaveChangeds() = True Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario de ajuste de inventario?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatos()
                    ActualizarTodo()
                End If
            Else
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            LimpiarDatos()
            ActualizarTodo()
        End If
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT * FROM" & SysName.Text & "TipoDocumento WHERE IDTipoDocumento='63'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            ConMixta.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE MovimientoInventario SET IDTipoDocumento='63',SecondID='" + lblSecondID.Text + "' WHERE IDAjusteInventario='" + txtIDAjuste.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento='63'"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
        CollapseMenu()
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        If e.Column.FieldName = "Existencia" Then
            e.Appearance.BackColor = SystemColors.Control
            If CDbl(currentView.GetRowCellValue(e.RowHandle, "Existencia")) = 0 Then
                e.Appearance.ForeColor = Color.Black

            ElseIf CDbl(currentView.GetRowCellValue(e.RowHandle, "Existencia")) > 0 Then
                e.Appearance.ForeColor = SystemColors.Highlight

            Else
                e.Appearance.ForeColor = Color.Salmon
            End If

        ElseIf e.Column.FieldName = "Ajuste" Then
            If CDbl(currentView.GetRowCellValue(e.RowHandle, "Ajuste")) = 0 Then
                e.Appearance.ForeColor = Color.Black

            ElseIf CDbl(currentView.GetRowCellValue(e.RowHandle, "Ajuste")) > 0 Then
                e.Appearance.ForeColor = SystemColors.Highlight

            Else
                e.Appearance.ForeColor = Color.Salmon
            End If

        ElseIf e.Column.FieldName = "Resultado" Then
            e.Appearance.BackColor = Color.WhiteSmoke
            e.Appearance.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)

            If CDbl(currentView.GetRowCellValue(e.RowHandle, "Resultado")) = 0 Then
                e.Appearance.ForeColor = Color.Black

            ElseIf CDbl(currentView.GetRowCellValue(e.RowHandle, "Resultado")) > 0 Then
                e.Appearance.ForeColor = SystemColors.Highlight

            Else
                e.Appearance.ForeColor = Color.Salmon
            End If

        ElseIf e.Column.FieldName = "Importe" Then
            If CDbl(currentView.GetRowCellValue(e.RowHandle, "Importe")) = 0 Then
                e.Appearance.ForeColor = Color.Black

            ElseIf CDbl(currentView.GetRowCellValue(e.RowHandle, "Importe")) > 0 Then
                e.Appearance.ForeColor = Color.Green

            Else
                e.Appearance.ForeColor = Color.Red
            End If

        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.FieldName = "Ajuste" Then
            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Resultado"), CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Existencia"))) + CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Ajuste"))))
            GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Importe"), CDbl(CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Costo"))) * CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Ajuste")))))

            If CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Ajuste"))) > 0 Then
                GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Tipoajuste"), 1)
            ElseIf CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Ajuste"))) < 0 Then
                GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Tipoajuste"), 2)
            Else
                GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Tipoajuste"), "")
            End If

            GridView1.Columns("Tipoajuste").SortOrder = DevExpress.Data.ColumnSortOrder.Descending

            GridView1.ExpandAllGroups()
        End If


    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro de ajuste de inventario No. " & txtIDAjuste.Text & " ya está anulada en el sistema. Desea activarla?", "Recuperar Registro de Ajuste de Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 2
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ChkNulo.Checked = False
                sqlQ = "UPDATE MovimientoInventario SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + CbxAlmacen.Tag.ToString + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',Total='" + CDbl(GridView1.Columns("Importe").SummaryItem.SummaryValue).ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.CheckState).ToString + "' WHERE IDAjusteInventario= (" + txtIDAjuste.Text + ")"
                GuardarDatos()
                CalcExistencias()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        ElseIf txtIDAjuste.Text = "" Then
            MessageBox.Show("No hay un registro de ajuste de inventario abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el registro de ajuste de inventario No. " & txtIDAjuste.Text & " del sistema?", "Anular Ajuste de Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_superclave.IDAccion.Text = 1
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                ChkNulo.Checked = True
                sqlQ = "UPDATE MovimientoInventario SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + CbxAlmacen.Tag.ToString + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',Total='" + CDbl(GridView1.Columns("Importe").SummaryItem.SummaryValue).ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.CheckState).ToString + "' WHERE IDAjusteInventario= (" + txtIDAjuste.Text + ")"
                GuardarDatos()
                CalcExistencias()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        End If
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub RemoveNotUsedRows()

        Dim iterateIndex1 As Integer = 0
        Dim newDataTable1 As DataTable = TablaArticulos.Copy
        For Each itm As DataRow In newDataTable1.Rows
            If CDbl(itm.Item("Ajuste")) = 0 And CStr(itm.Item("IDDetalle")) = "" Then
                TablaArticulos.Rows.RemoveAt(iterateIndex1)
            Else
                iterateIndex1 += 1
            End If
        Next
        newDataTable1.Dispose()

    End Sub

    Sub RefrescarTabla()
        Try
            Dim ds As New DataSet

            RemoveNotUsedRows
            ConstructorSQL()
            ConLibregco.Open()
            cmd = New MySqlCommand(FullCommand, ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "Articulos")
            ConLibregco.Close()

            For Each dt As DataRow In ds.Tables("Articulos").Rows
                Dim result() As DataRow = TablaArticulos.Select("IDPrecios = '" + dt.Item(0).ToString + "'")

                If result.Count = 0 Then
                    TablaArticulos.Rows.Add("", dt.Item(0), dt.Item(1), dt.Item(2), dt.Item(3), dt.Item(4), dt.Item(5), 0, dt.Item(5), "", dt.Item(6), dt.Item(7), 0)
                End If
            Next

            GridView1.ClearSelection()
            ds.Dispose()

            GridView1.Columns("Tipoajuste").GroupIndex = 0
            GridView1.ExpandAllGroups()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & ex.StackTrace)
        End Try
    End Sub

    Private Sub ConstructorSQL()
        Dim Paremeter As Integer = 1
        Dim Str As String = SelectCommand

        If txtBuscar.Text <> "" Or txtIDTipoProducto.Text <> "" Or txtIDDepartamento.Text <> "" Or txtIDCategoria.Text <> "" Or txtIDSubCategoria.Text <> "" Or txtIDSuplidor.Text <> "" Or txtIDMarca.Text <> "" Or txtIDMedida.Text <> "" Or txtIDTipoItbis.Text <> "" Or txtIDGarantia.Text <> "" Or txtIDParental.Text <> "" Or cbxPromocion.Text <> "Ambos" Or cbxDevolucion.Text <> "Ambos" Or cbxVenderCosto.Text <> "Ambos" Or cbxDescontinuado.Text <> "Ambos" Or cbxComision.Text <> "Ambos" Or cbxQrcode.Text <> "Ambos" Or cbxImagen.Text <> "Ambos" Or cbxHabSeries.Text <> "Ambos" Or chkPreAlertar.Text <> "Ambos" Or chkRevisado.Text <> "Ambos" Or chkBloqueoCredito.Text <> "Ambos" Or cbxCodigoBarra.Text <> "Todos" Or cbxNoPagoTarjeta.Text <> "Ambos" Or cbxEstado.Text <> "Todos" Or CbxExistencia.Text <> "Todas" Or cbxInventario.Text <> "Todos" Or chkPrecios.Checked = False Then

            If txtBuscar.Text <> "" Then
                Str = Str & " AND Articulos.Descripcion like '%" + txtBuscar.Text + "%' "
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

            If cbxEstado.Text <> "Estado" Then
                If Paremeter > 0 Then
                    If cbxEstado.Text = "Sí" Then
                        Str = Str & " AND Articulos.Desactivar=1"
                        Paremeter += 1
                    ElseIf cbxEstado.Text = "No" Then
                        Str = Str & " AND Articulos.Desactivar=0"
                        Paremeter += 1
                    End If
                Else
                    If cbxEstado.Text = "Sí" Then
                        Str = Str & " Articulos.Desactivar=1"
                        Paremeter += 1
                    ElseIf cbxEstado.Text = "No" Then
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


    Private Sub txtIDTipoItbis_Leave(sender As Object, e As EventArgs)
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

    Private Sub GridView1_EndSorting(sender As Object, e As EventArgs) Handles GridView1.EndSorting
        GridView1.ExpandAllGroups()
    End Sub

    Private Sub GridView1_EndGrouping(sender As Object, e As EventArgs) Handles GridView1.EndGrouping
        GridView1.ExpandAllGroups()
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If e.Column.FieldName = "Importe" Then
            If Convert.ToDouble(e.Value) = 0 Then
                e.DisplayText = ""
            End If
        End If
    End Sub

    Private Sub txtBuscar_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtBuscar.ButtonClick
        If e.Button.Tag = "Clear" Then
            txtBuscar.Text = ""
            txtBuscar.Focus()

        ElseIf e.Button.Tag = "Search" Then
            If txtIDAjuste.Text = "" Then
                If CheckIfHaveChangeds() = True Then
                    CollapseMenu()
                    RefrescarTabla()

                Else
                    TablaArticulos.Rows.Clear()
                    CollapseMenu()
                    RefrescarTabla()
                End If
            Else
                CollapseMenu()
                RefrescarTabla()
            End If

        End If

    End Sub

    Sub ShowSavedRows()
        Try
            Dim ds As New DataSet
            TablaArticulos.Rows.Clear()

            ConstructorSQL()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDMovimientoDetalle,IDPrecios,Articulos.IDArticulo,Articulos.Descripcion,Articulos.Referencia,PrecioArticulo.IDMedida,movimientoinvdetalle.ExistenciaAnterior,movimientoinvdetalle.Cantidad,Articulos.ExistenciaTotal,IDTipoAjusteDetalle,Fraccionamiento,Costo,Importe FROM" & SysName.Text & "movimientoinvdetalle INNER JOIN Libregco.PrecioArticulo on Movimientoinvdetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where IDMovimientoInventario='" + txtIDAjuste.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "Articulos")
            ConMixta.Close()

            For Each dt As DataRow In ds.Tables("Articulos").Rows
                TablaArticulos.Rows.Add(dt.Item(0), dt.Item(1), dt.Item(2), dt.Item(3), dt.Item(4), dt.Item(5), dt.Item(6), dt.Item(7), dt.Item(8), dt.Item(9), dt.Item(10), dt.Item(11), dt.Item(12))
            Next

            GridView1.ClearSelection()
            ds.Dispose()

            GridView1.Columns("Tipoajuste").GroupIndex = 0
            GridView1.ExpandAllGroups()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        If CbxAlmacen.Text = "" Then
            MessageBox.Show("Especifique el almacén que quedará afectado por el proceso.", "Seleccione el almacén", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CbxAlmacen.Focus()
            Exit Sub
        ElseIf txtReferencia.Text = "" Then
            MessageBox.Show("Escriba una breve referencia respecto al ajuste.", "Escriba una breve referencia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtReferencia.Focus()
            Exit Sub
        ElseIf CheckIfHaveChangeds() = False Then
            MessageBox.Show("Aún no se encontran artículos para procesar el ajuste.", "Agregue los artículos a procesar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDAjuste.Text = "" Then 'Si no hay ajuste
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la guardar el ajuste de inventario en la base de datos?", "Guardar ajuste de inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO MovimientoInventario (Fecha,Hora,IDUsuario,IDSucursal,IDAlmacen,Referencia,Comentario,Total,Impreso,Nulo) VALUES (CURDATE(),CURTIME(),'" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + CbxAlmacen.Tag.ToString + "','" + txtReferencia.Text + "','" + txtComentario.Text + "','" + CDbl(GridView1.Columns("Importe").SummaryItem.SummaryValue).ToString + "',0,0)"
                GuardarDatos()
                UltAjuste()
                SetSecondID()
                InsertArticulos()
                CalcExistencias()

                ToastNotificationsManager1.Notifications(0).Body = "El ajuste " & txtSecondID.Text & " ha sido guardada satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el ajuste de inventario?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE MovimientoInventario SET IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + CbxAlmacen.Tag.ToString + "',Referencia='" + txtReferencia.Text + "',Comentario='" + txtComentario.Text + "',Total='" + CDbl(GridView1.Columns("Importe").SummaryItem.SummaryValue).ToString + "',Nulo='" + Convert.ToInt16(ChkNulo.CheckState).ToString + "' WHERE IDAjusteInventario= (" + txtIDAjuste.Text + ")"
                GuardarDatos()
                InsertArticulos()
                CalcExistencias()

                ToastNotificationsManager1.Notifications(1).Body = "El ajuste " & txtSecondID.Text & " ha sido modificada satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))

                ImprimirDocumento()
            End If
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
        frm_buscar_ajustes_inventario.ShowDialog(Me)
    End Sub

    Private Sub GridView1_ShownEditor(sender As Object, e As EventArgs) Handles GridView1.ShownEditor
        GridView1.ExpandAllGroups()
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim IDDetalle As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("IDDetalle"))
            If IDDetalle <> "" Then
                e.Appearance.BackColor = Color.LightGreen
                e.Appearance.BackColor2 = Color.White
                e.HighPriority = True
            End If
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


End Class