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
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class frm_envio_608
    Dim ID608 As String
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Dim sqlQ As String
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend TablaVentasAnuladas As DataTable
    Dim RepositoryTipoAnulacion As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit() With {.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard, .BestFitWidth = True}

    Private Sub frm_envio_608_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        SetTablaVentasAnuladasTable()
        LimpiarDatos()
        Actualizar()
        RefrescarTabla()
    End Sub

    Private Sub SetTablaVentasAnuladasTable()
        FillTipoAnulacion()

        TablaVentasAnuladas = New DataTable("VentasAnuladas")
        TablaVentasAnuladas.Columns.Add("ID608Detalle", System.Type.GetType("System.String"))
        TablaVentasAnuladas.Columns.Add("IDFacturaDatos", System.Type.GetType("System.String"))
        TablaVentasAnuladas.Columns.Add("SecondID", System.Type.GetType("System.String"))
        TablaVentasAnuladas.Columns.Add("IDTipoDocumento", System.Type.GetType("System.String"))
        TablaVentasAnuladas.Columns.Add("TipoDocumento", System.Type.GetType("System.String"))
        TablaVentasAnuladas.Columns.Add("IDTipoComprobanteFiscal", System.Type.GetType("System.String"))
        TablaVentasAnuladas.Columns.Add("TipoComprobanteFiscal", System.Type.GetType("System.String"))
        TablaVentasAnuladas.Columns.Add("NCF", System.Type.GetType("System.String"))
        TablaVentasAnuladas.Columns.Add("Fecha", System.Type.GetType("System.String"))
        TablaVentasAnuladas.Columns.Add("FechaFormato", System.Type.GetType("System.String"))
        TablaVentasAnuladas.Columns.Add("TipoAnulacion", System.Type.GetType("System.String"))
        TablaVentasAnuladas.Columns.Add("Estatus", System.Type.GetType("System.String"))
        'TablaVentas.Columns.Add("Actualizar", System.Type.GetType("System.String"))
        GridControl1.DataSource = TablaVentasAnuladas

        GridView1.Columns("TipoAnulacion").ColumnEdit = RepositoryTipoAnulacion
        'GridView1.Columns("Actualizar").ColumnEdit = RepositoryActualizar

        'Propiedades
        GridView1.Columns("ID608Detalle").Visible = False
        GridView1.Columns("ID608Detalle").OptionsColumn.AllowEdit = False
        GridView1.Columns("ID608Detalle").OptionsColumn.ReadOnly = True
        GridView1.Columns("IDFacturaDatos").Visible = False
        GridView1.Columns("IDFacturaDatos").OptionsColumn.AllowEdit = False
        GridView1.Columns("IDFacturaDatos").OptionsColumn.ReadOnly = True
        GridView1.Columns("IDFacturaDatos").Caption = "Código del documento"
        GridView1.Columns("IDFacturaDatos").Width = 120
        GridView1.Columns("SecondID").Visible = False
        GridView1.Columns("SecondID").OptionsColumn.AllowEdit = False
        GridView1.Columns("SecondID").OptionsColumn.ReadOnly = True
        GridView1.Columns("SecondID").Caption = "No. de factura"
        GridView1.Columns("SecondID").Width = 120
        GridView1.Columns("IDTipoDocumento").OptionsColumn.AllowEdit = False
        GridView1.Columns("IDTipoDocumento").OptionsColumn.ReadOnly = True
        GridView1.Columns("IDTipoDocumento").Caption = "ID del tipo de documento"
        GridView1.Columns("IDTipoDocumento").Visible = False
        GridView1.Columns("IDTipoDocumento").Width = 100
        GridView1.Columns("TipoDocumento").Caption = "Tipo del documento"
        GridView1.Columns("TipoDocumento").Visible = False
        GridView1.Columns("TipoDocumento").OptionsColumn.AllowEdit = False
        GridView1.Columns("TipoDocumento").OptionsColumn.ReadOnly = True
        GridView1.Columns("TipoDocumento").Width = 160
        GridView1.Columns("IDTipoComprobanteFiscal").Caption = "Código del comprobante fiscal"
        GridView1.Columns("IDTipoComprobanteFiscal").Visible = False
        GridView1.Columns("IDTipoComprobanteFiscal").OptionsColumn.AllowEdit = False
        GridView1.Columns("IDTipoComprobanteFiscal").OptionsColumn.ReadOnly = True
        GridView1.Columns("TipoComprobanteFiscal").Visible = False
        GridView1.Columns("TipoComprobanteFiscal").Caption = "Tipo de Comprobante"
        GridView1.Columns("TipoComprobanteFiscal").OptionsColumn.AllowEdit = False
        GridView1.Columns("TipoComprobanteFiscal").OptionsColumn.ReadOnly = True
        GridView1.Columns("NCF").Width = 150
        GridView1.Columns("NCF").OptionsColumn.AllowEdit = False
        GridView1.Columns("NCF").OptionsColumn.ReadOnly = True
        GridView1.Columns("Fecha").Visible = False
        GridView1.Columns("Fecha").OptionsColumn.AllowEdit = False
        GridView1.Columns("Fecha").OptionsColumn.ReadOnly = True
        GridView1.Columns("FechaFormato").Caption = "Fecha"
        GridView1.Columns("FechaFormato").Width = 100
        GridView1.Columns("FechaFormato").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GridView1.Columns("FechaFormato").OptionsColumn.AllowEdit = False
        GridView1.Columns("FechaFormato").OptionsColumn.ReadOnly = True
        GridView1.Columns("TipoAnulacion").Caption = "Tipo de anulación"
        GridView1.Columns("TipoAnulacion").Width = 330
        GridView1.Columns("Estatus").Caption = "Estado del registro"
        GridView1.Columns("Estatus").Width = 300
        GridView1.Columns("Estatus").OptionsColumn.ReadOnly = True
        GridView1.Columns("Estatus").OptionsColumn.AllowEdit = False
    End Sub


    Private Sub LimpiarDatos()
        ID608 = ""
        txtCantidadRegistros.Clear()
        cbxPeriodo.Items.Clear()
        TablaVentasAnuladas.Rows.Clear()
        txtSecondID.Text = ""
        txtSecondID.Tag = ""
        lblStatus.Text = "SIN PROCESAR"
        lblStatus.ForeColor = Color.Firebrick
        TileBarItem5.Visible = False
    End Sub

    Private Sub Actualizar()
        FillPeriodos()
        cbxPeriodo.Enabled = True
    End Sub

    Private Sub FillTipoAnulacion()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT idTipoAnulacion,TipoAnulacion FROM libregco.tipoanulacion", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "tipoanulacion")
        ConLibregco.Close()

        Dim TablaIngresos As DataTable = dstemp.Tables("tipoanulacion")
        RepositoryTipoAnulacion.DataSource = TablaIngresos
        RepositoryTipoAnulacion.ValueMember = "idTipoAnulacion"
        RepositoryTipoAnulacion.DisplayMember = "TipoAnulacion"


    End Sub

    Private Sub FillPeriodos()
        Try
            Dim dstemp As New DataSet

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT DATE_FORMAT(Fecha,'%Y%m') as Fecha FROM" & SysName.Text & "FacturaDatos Where FacturaDatos.Nulo=1 GROUP BY DATE_FORMAT(Fecha,'%Y%m') ORDER BY DATE_FORMAT(Fecha,'%Y%m') DESC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "FacturaDatos")
            cbxPeriodo.Items.Clear()
            ConMixta.Close()

            Dim Tabla As DataTable = dstemp.Tables("FacturaDatos")
            For Each Fila As DataRow In Tabla.Rows
                cbxPeriodo.Items.Add(Fila.Item("Fecha"))
            Next

            If Tabla.Rows.Count > 0 Then
            Else
                MessageBox.Show("No se encontraron períodos hábiles en la base de datos. Inserte registros de ventas para procesar el formato 608.", "No se encontraron registros de comprventasas 608", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub RefrescarTabla()
        Try
            If cbxPeriodo.Text <> "" Then
                Dim ds As New DataSet

                TablaVentasAnuladas.Rows.Clear()

                ConMixta.Open()
                cmd = New MySqlCommand("SELECT FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.IDTipoDocumento,TipoDocumento.Documento,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.NCF,FacturaDatos.Fecha,FacturaDatos.ClasificacionAnulacion,tipoanulacion.TipoAnulacion from " & SysName.Text & "FacturaDatos INNER JOIN" & SysName.Text & "TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.tipoanulacion on FacturaDatos.ClasificacionAnulacion=tipoanulacion.idTipoAnulacion Where DATE_FORMAT(FacturaDatos.Fecha,'%Y%m')='" + cbxPeriodo.Text.ToString + "' and FacturaDatos.Nulo=1", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds, "FacturaDatos")
                ConMixta.Close()

                Dim TB As DataTable = ds.Tables("FacturaDatos")
                For Each itm As DataRow In TB.Rows
                    TablaVentasAnuladas.Rows.Add("", itm.Item("IDFacturaDatos"), itm.Item("SecondID"), itm.Item("IDTipoDocumento"), itm.Item("Documento"), itm.Item("IDComprobanteFiscal"), itm.Item("TipoComprobante"), itm.Item("NCF"), CDate(itm.Item("Fecha")).ToString("dd/MM/yyyy"), CDate(itm.Item("Fecha")).ToString("yyyyMMdd"), itm.Item("ClasificacionAnulacion"), "")
                Next

                SumarRows()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SumarRows()
        txtCantidadRegistros.Text = TablaVentasAnuladas.Rows.Count
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

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Dim str As String = ""
        For i As Integer = 0 To GridView1.RowCount - 1
            str = str & vbNewLine & GridView1.GetRowCellValue(i, GridView1.FocusedColumn)
        Next

        Clipboard.SetText(str)
    End Sub

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

    Private Sub cbxPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPeriodo.SelectedIndexChanged
        TablaVentasAnuladas.Rows.Clear()

        If cbxPeriodo.Text <> "" Then
            Dim dstemp As New DataSet

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT idEnvio608,Envio608.IDTipoDocumento,TipoDocumento.Documento,envio608.SecondID,envio608.IDEquipo,AreaImpresion.ComputerName,AreaImpresion.IDAlmacen,Almacen.Almacen,Almacen.IDSucursal,Sucursal.Sucursal,envio608.IDUsuario,Usuarios.Nombre as NombreUsuario,envio608.Fecha,envio608.Modificacion,envio608.Periodo,envio608.CantRegistros FROM" & SysName.Text & "envio608 INNER JOIN" & SysName.Text & "TipoDocumento on envio608.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "AreaImpresion on envio608.IDEquipo=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Empleados as Usuarios on envio608.IDUsuario=Usuarios.IDEmpleado where envio608.Periodo='" + cbxPeriodo.Text.ToString + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "Envio608")
            ConMixta.Close()

            Dim TB As DataTable = dstemp.Tables("Envio608")

            If TB.Rows.Count = 0 Then
                RefrescarTabla()
                TileBarItem5.Visible = False
            Else
                cbxPeriodo.Enabled = False

                txtSecondID.Text = TB.Rows(0).Item("SecondID")
                txtSecondID.Tag = TB.Rows(0).Item("idEnvio608")
                lblStatus.Text = "PROCESADA"
                lblStatus.ForeColor = Color.Green
                txtCantidadRegistros.Text = TB.Rows(0).Item("CantRegistros")

                Dim ds As New DataSet

                ConMixta.Open()
                cmd = New MySqlCommand("SELECT idEnvio608_Detalles,FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.IDTipoDocumento,TipoDocumento.Documento,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.NCF,FacturaDatos.NCFModificado,FacturaDatos.ClasificacionAnulacion,tipoanulacion.TipoAnulacion,FacturaDatos.Fecha,Estatus from" & SysName.Text & "Envio608_detalle INNER JOIN" & SysName.Text & "FacturaDatos on Envio608_Detalle.IDFacturaDatos=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.tipoanulacion on FacturaDatos.ClasificacionAnulacion=tipoanulacion.idTipoAnulacion Where DATE_FORMAT(FacturaDatos.Fecha,'%Y%m')='" + cbxPeriodo.SelectedItem.ToString + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds, "envio608_detalle")
                ConMixta.Close()

                Dim TBa As DataTable = ds.Tables("envio608_detalle")

                For Each itm As DataRow In TBa.Rows
                    TablaVentasAnuladas.Rows.Add(itm.Item("idEnvio608_Detalles"), itm.Item("IDFacturaDatos"), itm.Item("SecondID"), itm.Item("IDTipoDocumento"), itm.Item("Documento"), itm.Item("IDComprobanteFiscal"), itm.Item("TipoComprobante"), itm.Item("NCF"), CDate(itm.Item("Fecha")).ToString("dd/MM/yyyy"), CDate(itm.Item("Fecha")).ToString("yyyyMMdd"), itm.Item("ClasificacionAnulacion"), itm.Item("Estatus"))
                Next

                SumarRows()

                TileBarItem5.Visible = True
            End If

        End If

    End Sub

    Private Sub TileBarItem3_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem3.ItemClick
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
    Private Sub ActualizarFacturas()
        ConMixta.Open()

        For Each rw As DataRow In TablaVentasAnuladas.Rows
            cmd = New MySqlCommand("UPDATE" & SysName.Text & "FacturaDatos SET ClasificacionAnulacion='" + rw.Item("TipoAnulacion").ToString + "' WHERE IDFacturaDatos= (" + rw.Item("IDFacturaDatos").ToString + ")", ConMixta)
            cmd.ExecuteNonQuery()
        Next
        ConMixta.Close()
    End Sub

    Private Sub TileBarItem2_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem2.ItemClick
        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar la línea " & CInt(GridView1.FocusedRowHandle.ToString) + 1 & " de la tabla?", "Eliminar la fila", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            If GridView1.GetFocusedRowCellValue("ID608Detalle").ToString = "" Then
                Dim iterateIndex1 As Integer = 0
                Dim newDataTable1 As DataTable = TablaVentasAnuladas.Copy
                For Each itm As DataRow In newDataTable1.Rows
                    If itm.Item("IDFacturaDatos") = GridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString Then
                        TablaVentasAnuladas.Rows.RemoveAt(iterateIndex1)
                        Exit For
                    Else
                        iterateIndex1 += 1
                    End If
                Next
                newDataTable1.Dispose()
            Else

                Con.Open()
                cmd = New MySqlCommand("Delete from envio608_detalle Where idEnvio608_Detalles='" + GridView1.GetFocusedRowCellValue("ID608Detalle").ToString + "'", Con)
                cmd.ExecuteNonQuery()
                Con.Close()

                Dim iterateIndex1 As Integer = 0
                Dim newDataTable1 As DataTable = TablaVentasAnuladas.Copy
                For Each itm As DataRow In newDataTable1.Rows
                    If itm.Item("IDFacturaDatos") = GridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString Then
                        TablaVentasAnuladas.Rows.RemoveAt(iterateIndex1)
                        Exit For
                    Else
                        iterateIndex1 += 1
                    End If
                Next
                newDataTable1.Dispose()
            End If



            SumarRows()
        End If

    End Sub

    Private Sub TileBarItem6_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem6.ItemClick
        If txtSecondID.Text = "" Then
            If TablaVentasAnuladas.Rows.Count > 0 Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatos()
                    Actualizar()
                End If
            Else
                LimpiarDatos()
                Actualizar()
            End If
        Else
            LimpiarDatos()
            Actualizar()
        End If

    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        If txtSecondID.Text <> "" Then
            Dim View As GridView = sender
            If (e.RowHandle >= 0) Then
                If CStr(View.GetRowCellDisplayText(e.RowHandle, View.Columns("ID608Detalle"))).ToString = "" Then
                    e.Appearance.BackColor = Color.LightGreen
                    e.Appearance.BackColor2 = Color.LightSkyBlue
                    e.HighPriority = True
                End If
            End If
        End If

    End Sub

    Private Sub GuardarDatos()
        Try
            ConMixta.Open()
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
            ConMixta.Close()

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
            ConMixta.Close()
        End Try
    End Sub

    Private Sub Ult608()
        Try

            If txtSecondID.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select idEnvio608 from" & SysName.Text & "Envio608 where idEnvio608= (Select Max(idEnvio608) from Envio608)", Con)
                txtSecondID.Tag = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select SecondID from" & SysName.Text & "Envio608 where idEnvio608= (Select Max(idEnvio608) from Envio608)", Con)
                txtSecondID.Text = Convert.ToString(cmd.ExecuteScalar())

                lblStatus.Text = "PROCESADO"
                lblStatus.ForeColor = Color.DarkSeaGreen
                Con.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

    Private Sub InsertDetalles()
        Con.Open()

        For Each Row As DataRow In TablaVentasAnuladas.Rows
            If Row.Item("ID608Detalle").ToString = "" Then

                cmd = New MySqlCommand("INSERT INTO" & SysName.Text & "envio608_detalle (ID608,IDFacturaDatos,Estatus) VALUES ('" + txtSecondID.Tag.ToString + "','" + Row.Item("IDFacturaDatos").ToString + "','" + Row.Item("Estatus").ToString + "')", Con)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("Select idEnvio608_Detalles from envio608_detalle where idEnvio608_Detalles=(Select Max(idEnvio608_Detalles) from envio608_detalle)", Con)
                Row.Item(0) = Convert.ToString(cmd.ExecuteScalar())

            Else

                cmd = New MySqlCommand("UPDATE" & SysName.Text & "envio608_detalle SET ID608='" + txtSecondID.Tag.ToString + "',IDFacturaDatos='" + Row.Item("IDFacturaDatos").ToString + "',Estatus='" + Row.Item("Estatus").ToString + "' Where idEnvio608_Detalles='" + Row.Item("ID608Detalle").ToString + "'", Con)
                cmd.ExecuteNonQuery()

            End If
        Next

        Con.Close()
    End Sub

    Private Sub TileBarItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem1.ItemClick
        If GridView1.RowCount > 0 Then
            If txtSecondID.Tag.ToString = "" Then

                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea procesar el formulario de envío de comprobantes anulados correspondiente al período " & cbxPeriodo.Text & "?", "Generar formulario 608", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ActualizarFacturas()
                    sqlQ = "INSERT INTO" & SysName.Text & "Envio608 (SecondID,IDTipoDocumento,IDEquipo,IDUsuario,Fecha,Modificacion,Periodo,CantRegistros) VALUES ('" + GetSecondID(61).ToString + "','62', '" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',NOW(),NOW(),'" + cbxPeriodo.Text + "','" + txtCantidadRegistros.Text + "')"
                    GuardarDatos()
                    Ult608()
                    InsertDetalles()
                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))


                End If

            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea actualizar el formulario de envío de ventas de productos y servicios 608 correspondiente al período " & cbxPeriodo.Text & "?", "Actualizar formulario 608", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ActualizarFacturas()
                    sqlQ = "UPDATE" & SysName.Text & "Envio608 SET IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',Modificacion=CURDATE(),CantRegistros='" + txtCantidadRegistros.Text + "' WHERE id608='" + txtSecondID.Tag.ToString + "')"
                    GuardarDatos()
                    InsertDetalles()
                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(2))
                End If
            End If
        End If

    End Sub

    Private Sub TileBarItem4_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem4.ItemClick
        If GridView1.FocusedRowHandle >= 0 Then
            If GridView1.GetFocusedRowCellValue("IDTipoDocumento") = 1 Or GridView1.GetFocusedRowCellValue("IDTipoDocumento") = 2 Then
                Dim PermisosConsultaVentas As New ArrayList
                PermisosConsultaVentas = PasarPermisos(46)

                If PermisosConsultaVentas(0) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para acceder al formulario de consulta de ventas.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    If frm_consulta_ventas.Visible = True Then
                        frm_consulta_ventas.Close()
                    End If

                    frm_consulta_ventas.Show(Me)

                    frm_consulta_ventas.txtFechaInicial.Value = CDate(GridView1.GetFocusedRowCellValue("Fecha"))
                    frm_consulta_ventas.txtFechaFinal.Value = CDate(GridView1.GetFocusedRowCellValue("Fecha"))
                    frm_consulta_ventas.chkNulos.Checked = True
                    frm_consulta_ventas.LookingForIDFactura = GridView1.GetFocusedRowCellValue("IDFacturaDatos")

                    frm_consulta_ventas.btnBuscarCons.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub TileBarItem5_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileBarItem5.ItemClick
        Dim RegistrosActualizados = 0
        Dim ds As New DataSet

        ConMixta.Open()
        cmd = New MySqlCommand("SELECT FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.IDTipoDocumento,TipoDocumento.Documento,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.NCF,FacturaDatos.Fecha,FacturaDatos.ClasificacionAnulacion,tipoanulacion.TipoAnulacion from " & SysName.Text & "FacturaDatos INNER JOIN" & SysName.Text & "TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.tipoanulacion on FacturaDatos.ClasificacionAnulacion=tipoanulacion.idTipoAnulacion Where DATE_FORMAT(FacturaDatos.Fecha,'%Y%m')='" + cbxPeriodo.Text.ToString + "' and FacturaDatos.Nulo=1", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "FacturaDatos")
        ConMixta.Close()

        Dim TB As DataTable = ds.Tables("FacturaDatos")

        For Each row As DataRow In TB.Rows
            Dim Founded As Boolean = False
            For Each itm As DataRow In TablaVentasAnuladas.Rows
                If row.Item("IDFacturaDatos") = itm.Item("IDFacturaDatos") Then
                    Founded = True
                    Exit For
                End If
            Next

            If Founded = False Then
                RegistrosActualizados += 1
                TablaVentasAnuladas.Rows.Add("", row.Item("IDFacturaDatos"), row.Item("SecondID"), row.Item("IDTipoDocumento"), row.Item("Documento"), row.Item("IDComprobanteFiscal"), row.Item("TipoComprobante"), row.Item("NCF"), CDate(row.Item("Fecha")).ToString("dd/MM/yyyy"), CDate(row.Item("Fecha")).ToString("yyyyMMdd"), row.Item("ClasificacionAnulacion"), "Nuevo regsitro")
            End If

        Next

        If RegistrosActualizados > 0 Then
            If RegistrosActualizados = 1 Then
                ToastNotificationsManager1.Notifications(3).Body2 = "Se encontró un nuevo registro"
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(3))
            ElseIf RegistrosActualizados > 1 Then
                ToastNotificationsManager1.Notifications(3).Body2 = "Se encontraron " & RegistrosActualizados & " nuevos registros"
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(3))
            End If
        End If

        SumarRows()
    End Sub

    Private Sub frm_envio_608_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If txtSecondID.Text = "" Then
            If TablaVentasAnuladas.Rows.Count > 0 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea cerrar el formulario?", "Cerrar formulario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

End Class