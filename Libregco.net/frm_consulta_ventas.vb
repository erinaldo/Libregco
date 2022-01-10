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
Imports DevExpress.Utils
Imports DevExpress.Utils.Win
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraGrid.Views.Grid

Public Class frm_consulta_ventas
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList
    Friend IDReport, NameReport, PathReport As New Label
    Dim Duplicidad As New Label

    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue

    Friend TablaVentas As DataTable
    Dim RepositoryCondicionContado As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .ValueGrayed = "", .Caption = "Subtotales", .ReadOnly = False}
    Dim RepositorySecondID As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}
    Dim RepositoryCurrency As New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()
    Dim RepositoryPicture As New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit With {.PictureStoreMode = PictureStoreMode.ByteArray, .PopupBorderStyle = PopupBorderStyles.NoBorder, .PictureAlignment = ContentAlignment.MiddleCenter, .ShowIcon = True, .SizeMode = PictureSizeMode.Zoom, .NullText = "", .ShowMenu = True}
    Dim SelectCommand As String = "SELECT IDFacturaDatos as ID,FacturaDatos.SecondID,FacturaDatos.Fecha,FacturaDatos.Hora,TIMESTAMP(FacturaDatos.Fecha,FacturaDatos.Hora) As FechaHora,FechaVencimiento As Vencimiento,FacturaDatos.IDCondicion,Condicion,FacturaDatos.IDUsuario,Usuarios.Nombre As Usuario,IDVendedor,Vendedores.Nombre As Vendedor,facturadatos.IDCliente,NombreFactura As Nombre,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.NCF,Subtotal,Descuento,Itbis,Flete,TotalNeto,Cargos,FacturaDatos.Balance,NotaContado,CondicionContado,FacturaDatos.Nulo,TipoAnulacion.TipoAnulacion as ClasAnulacion,MotivoAnulacion,FechaAnulacion,Anulador.Nombre As Anulador,Transaccion.IDMoneda,Signo,Moneda,Transaccion.IDMoneda as IDMonedaI,FacturaDatos.FacturaFilePath,if(FacturaDatos.FacturaFilePath='',NULL,FacturaDatos.FacturaFilePath) AS Imagen FROM" & SysName.Text & "facturadatos INNER JOIN Libregco.condicion On FacturaDatos.IDCondicion=Condicion.IDCondicion INNER JOIN Libregco.Clientes On FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "Empleados As Vendedores On FacturaDatos.IDVendedor=Vendedores.IDEmpleado INNER JOIN" & SysName.Text & "Empleados As Usuarios On FacturaDatos.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal On FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal LEFT JOIN" & SysName.Text & "Empleados As Anulador On FacturaDatos.IDUsuarioAnulador=Anulador.IDEmpleado LEFT JOIN Libregco.TipoAnulacion ON FacturaDatos.ClasificacionAnulacion=TipoAnulacion.idTipoAnulacion LEFT JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda"
    Dim newstr As New AutoCompleteStringCollection
    Dim TablaNombres As DataTable
    Friend LookingForIDFactura As String = ""

    Private Sub frm_consulta_ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.CenterToParent()
            'Me.WindowState = CheckWindowState()
            CargarLibregco()
            Permisos = PasarPermisos(Me.Tag)
            SetVentasTable()
            LimpiarDatos()
            Actualizar()
            RefrescarTabla()
            FillReportes()
            FillNames()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SetVentasTable()
        RepositoryCurrency.SmallImages = imgFlags
        RepositoryCurrency.GlyphAlignment = HorzAlignment.Near
        RepositoryCurrency.Name = "RepCurrency"

        Dim dstemp As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM Libregco.tipomoneda order by IDTipoMoneda ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "tipomoneda")
        ConLibregco.Close()

        Dim Tabla As DataTable = dstemp.Tables("tipomoneda")

        For Each Fila As DataRow In Tabla.Rows
            Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem
            'nvmoneda.Description = Fila.Item("Texto")
            nvmoneda.Value = Fila.Item("IDTipoMoneda")

            If Fila.Item("IDTipoMoneda") = 1 Then
                nvmoneda.ImageIndex = 0
            ElseIf Fila.Item("IDTipoMoneda") = 2 Then
                nvmoneda.ImageIndex = 1
            ElseIf Fila.Item("IDTipoMoneda") = 3 Then
                nvmoneda.ImageIndex = 2
            End If

            nvmoneda.Description = Fila.Item("Texto")

            RepositoryCurrency.Properties.Items.Add(nvmoneda)
        Next
        Tabla.Dispose()
        dstemp.Dispose()

        TablaVentas = New DataTable("Ventas")

        TablaVentas.Columns.Add("ID", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("SecondID", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Fecha", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Hora", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("FechaHora", System.Type.GetType("System.DateTime"))
        TablaVentas.Columns.Add("Vencimiento", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("IDCondicion", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Condicion", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("IDUsuario", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Usuario", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("IDVendedor", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Vendedor", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("IDCliente", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Nombre", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("IDComprobanteFiscal", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("TipoComprobante", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("NCF", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Subtotal", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("Descuento", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("Itbis", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("Flete", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("TotalNeto", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("Cargos", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("Balance", System.Type.GetType("System.Double"))
        TablaVentas.Columns.Add("NotaContado", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("CondicionContado", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Nulo", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("ClasAnulacion", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("MotivoAnulacion", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("FechaAnulacion", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Anulador", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("IDMoneda", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Signo", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Moneda", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("IDMonedaI", System.Type.GetType("System.Object"))
        TablaVentas.Columns.Add("FacturaFilePath", System.Type.GetType("System.String"))
        TablaVentas.Columns.Add("Imagen", System.Type.GetType("System.String"))

        GridControl1.DataSource = TablaVentas
        GridView1.Columns("SecondID").ColumnEdit = RepositorySecondID
        GridView1.Columns("CondicionContado").ColumnEdit = RepositoryCondicionContado
        GridView1.Columns("IDMonedaI").ColumnEdit = RepositoryCurrency
        GridView1.Columns("Imagen").ColumnEdit = RepositoryPicture

        'Propiedades
        GridView1.Columns("ID").Visible = False
        GridView1.Columns("ID").Caption = "Código de la factura"
        GridView1.Columns("SecondID").Caption = "Documento"
        GridView1.Columns("Fecha").Visible = False
        GridView1.Columns("Hora").Visible = False
        GridView1.Columns("FechaHora").Caption = "Fecha de registro"
        GridView1.Columns("FechaHora").DisplayFormat.FormatType = FormatType.DateTime
        GridView1.Columns("FechaHora").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"
        GridView1.Columns("Vencimiento").Visible = False
        GridView1.Columns("IDCondicion").Caption = "Código de la condición"
        GridView1.Columns("IDCondicion").Visible = False
        GridView1.Columns("Condicion").Caption = "Condición"
        GridView1.Columns("IDUsuario").Caption = "ID del usuario"
        GridView1.Columns("IDUsuario").Visible = False
        GridView1.Columns("Usuario").Visible = False
        GridView1.Columns("IDVendedor").Caption = "ID del vendedor"
        GridView1.Columns("IDVendedor").Visible = False
        GridView1.Columns("Vendedor").Visible = False
        GridView1.Columns("IDCliente").Caption = "ID"

        GridView1.Columns("IDComprobanteFiscal").Visible = False
        GridView1.Columns("IDComprobanteFiscal").Caption = "Código del comprobante"
        GridView1.Columns("TipoComprobante").Caption = "Tipo de comprobante"
        GridView1.Columns("TipoComprobante").Visible = False
        GridView1.Columns("Subtotal").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Subtotal").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Subtotal").Visible = False
        GridView1.Columns("Descuento").Visible = False
        GridView1.Columns("Descuento").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Descuento").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Itbis").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Itbis").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Itbis").Visible = False
        GridView1.Columns("Flete").Visible = False
        GridView1.Columns("Flete").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Flete").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Cargos").Visible = False
        GridView1.Columns("Cargos").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Cargos").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Balance").Visible = False
        GridView1.Columns("Balance").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Balance").DisplayFormat.FormatString = "C2"
        GridView1.Columns("TotalNeto").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("TotalNeto").DisplayFormat.FormatString = "C2"
        GridView1.Columns("NotaContado").Visible = False
        GridView1.Columns("NotaContado").Caption = "Nota de contado"
        GridView1.Columns("CondicionContado").Visible = False
        GridView1.Columns("CondicionContado").Caption = "Condición de nota de contado"
        GridView1.Columns("FacturaFilePath").Visible = False

        If CInt(DTConfiguracion.Rows(88 - 1).Item("Value2Int")) = 0 Then
            GridView1.Columns("Imagen").Visible = False
        Else
            GridView1.Columns("Imagen").Visible = True
        End If

        GridView1.Columns("Nulo").Visible = False
        GridView1.Columns("ClasAnulacion").Visible = False
        GridView1.Columns("ClasAnulacion").Caption = "Clasificación de anulación"
        GridView1.Columns("MotivoAnulacion").Visible = False
        GridView1.Columns("MotivoAnulacion").Caption = "Motivo de anulación"
        GridView1.Columns("FechaAnulacion").Visible = False
        GridView1.Columns("FechaAnulacion").Caption = "Fecha de anulación"
        GridView1.Columns("Anulador").Visible = False
        GridView1.Columns("Anulador").Caption = "Usuario anulador"
        GridView1.Columns("IDMoneda").Visible = False
        GridView1.Columns("Signo").Caption = " "
        GridView1.Columns("Signo").Visible = False
        GridView1.Columns("IDMonedaI").Caption = "Moneda Imagen"

        For i = 0 To GridView1.Columns.Count - 1
            GridView1.Columns(i).OptionsColumn.ReadOnly = True
            GridView1.Columns(i).OptionsColumn.AllowEdit = False
        Next

        GridView1.Columns("Moneda").GroupIndex = 0

        Dim item As New DevExpress.XtraGrid.GridGroupSummaryItem
        item.FieldName = "TotalNeto"
        item.ShowInGroupColumnFooter = GridView1.Columns("TotalNeto")
        item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item.DisplayFormat = "{0:c2}"
        item.ShowInGroupColumnFooter = Nothing
        GridView1.GroupSummary.Add(item)

        GridView1.ExpandAllGroups()

    End Sub

    Private Sub btnImagen_Click(sender As Object, e As EventArgs) Handles btnImagen.Click
        If TypeConnection.Text = 1 Then
            Dim ExistFile As Boolean = System.IO.File.Exists(GridView1.GetFocusedRowCellValue("FacturaFilePath").ToString)
            If ExistFile = True Then

                System.Diagnostics.Process.Start(GridView1.GetFocusedRowCellValue("FacturaFilePath").ToString)
            Else
                MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una copia de la factura. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & GridView1.GetFocusedRowCellValue("FacturaFilePath").ToString & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If

    End Sub

    Private Sub btnSubir_Click(sender As Object, e As EventArgs) Handles btnSubir.Click
        If TypeConnection.Text = 1 Then
            If frm_subir_documento.Visible = True Then
                frm_subir_documento.Close()
            End If

            frm_subir_documento.Show(Me)
            frm_subir_documento.PicDocumento.Width = 459
            frm_subir_documento.PicDocumento.Height = 530
            frm_subir_documento.PicDocumento.Location = New Point(0, 0)

            frm_subir_documento.RutaDocumento.Text = GridView1.GetFocusedRowCellValue(GridView1.Columns("FacturaFilePath"))

            If GridView1.GetFocusedRowCellValue(GridView1.Columns("FacturaFilePath")) <> "" Then
                If System.IO.File.Exists(GridView1.GetFocusedRowCellValue(GridView1.Columns("FacturaFilePath"))) = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(GridView1.GetFocusedRowCellValue(GridView1.Columns("FacturaFilePath")), FileMode.Open, FileAccess.Read)
                    frm_subir_documento.PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                    frm_subir_documento.btnDownload.Visible = True
                Else
                    frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                    frm_subir_documento.btnBuscar.PerformClick()
                    frm_subir_documento.btnDownload.Visible = False
                End If
            Else
                frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                frm_subir_documento.btnBuscar.PerformClick()
                frm_subir_documento.btnDownload.Visible = False
            End If



        End If
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Dim Dstemp As New DataSet

            ConMixta.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM" & SysName.Text & "Reportes INNER JOIN Libregco.PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Facturación' and PaperSize.Activo=1 and Reportes.Activo=1 ORDER BY NoOrden ASC", ConMixta)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM" & SysName.Text & "Reportes INNER JOIN Libregco.PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Ventas' and PaperSize.Activo=1 and Reportes.Activo=1 ORDER BY NoOrden ASC", ConMixta)
            End If

            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp, "Reportes")
            CbxFormato.Items.Clear()
            ConMixta.Close()

            Dim Tabla As DataTable = Dstemp.Tables("Reportes")

            For Each Fila As DataRow In Tabla.Rows
                CbxFormato.Items.Add(Fila.Item("Descripcion"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxFormato.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron reportes que involucren este vínculo del módulo.")
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LimpiarDatos()
        txtIDCliente.Clear()
        txtCliente.Clear()
        txtIDVendedor.Clear()
        txtVendedor.Clear()
        txtFechaInicial.Value = Today
        txtFechaFinal.Value = Today
        txtIDCliente.Focus()
        chkNulos.Checked = False
        FillCondicion()
        cbxCondicion.Tag = 0
        cbxCondicion.Text = "Todas"
    End Sub

    Private Sub Actualizar()
        cbxOrden.SelectedIndex = 0
        CbxTipoOrden.SelectedIndex = 0

        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
        cbxCondicion.Text = "Todas"
    End Sub

    Private Sub FillCondicion()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Condicion FROM Condicion ORDER BY Condicion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Condicion")
        cbxCondicion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = dstemp.Tables("Condicion")
        For Each Fila As DataRow In Tabla.Rows
            cbxCondicion.Items.Add(Fila.Item("Condicion"))
        Next

        cbxCondicion.Items.Add("Todas")

    End Sub

    Private Function ConstructorQuery() As String
        Dim Paremeter As Integer = 0
        Dim Str As String = ""
        Dim Orderby As String

        If IsDate(txtFechaInicial.Value) Or txtIDCliente.Text <> "" Or txtCliente.Text <> "" Or txtIDVendedor.Text <> "" Or cbxCondicion.Text <> "Todas" Or chkNulos.CheckState = CheckState.Unchecked Then
            Str = Str & " WHERE "

            If IsDate(txtFechaInicial.Value) Then
                If Paremeter > 0 Then
                    Str = Str & " AND FacturaDatos.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "' "
                    Paremeter += 1
                Else
                    Str = Str & " FacturaDatos.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "' "
                    Paremeter += 1
                End If
            End If

            If txtIDCliente.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND FacturaDatos.IDCliente=" & txtIDCliente.Text & " "
                    Paremeter += 1
                Else
                    Str = Str & " FacturaDatos.IDCliente=" & txtIDCliente.Text & " "
                    Paremeter += 1
                End If
            End If

            If txtCliente.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND FacturaDatos.NombreFactura Like '%" & txtCliente.Text & "%' "
                    Paremeter += 1
                Else
                    Str = Str & " FacturaDatos.NombreFactura Like '%" & txtCliente.Text & "%' "
                    Paremeter += 1
                End If
            End If
            If txtIDVendedor.Text <> "" Then
                If Paremeter > 0 Then
                    Str = Str & " AND FacturaDatos.IDVendedor=" & txtIDVendedor.Text & " "
                    Paremeter += 1
                Else
                    Str = Str & " FacturaDatos.IDVendedor=" & txtIDVendedor.Text & " "
                    Paremeter += 1
                End If
            End If

            If cbxCondicion.Text <> "Todas" Then
                If Paremeter > 0 Then
                    Str = Str & " AND FacturaDatos.IDCondicion=" & cbxCondicion.Tag.ToString & " "
                    Paremeter += 1
                Else
                    Str = Str & " FacturaDatos.IDCondicion=" & cbxCondicion.Tag.ToString & " "
                    Paremeter += 1
                End If
            End If

            If chkNulos.CheckState = CheckState.Unchecked Then
                If Paremeter > 0 Then
                    Str = Str & " AND FacturaDatos.Nulo=0 "
                    Paremeter += 1
                Else
                    Str = Str & " FacturaDatos.Nulo=0 "
                    Paremeter += 1
                End If
            End If
        End If

        If cbxOrden.Text = "Documento" Then
            Orderby = " ORDER BY IDFacturaDatos " & CbxTipoOrden.Text
        ElseIf cbxOrden.Text = "Fecha" Then
            Orderby = " ORDER BY TIMESTAMP(Fecha,Hora) " & CbxTipoOrden.Text
        ElseIf cbxOrden.Text = "Cliente" Then
            Orderby = " ORDER BY NombreFactura " & CbxTipoOrden.Text
        ElseIf cbxOrden.Text = "Total" Then
            Orderby = " ORDER BY TotalNeto " & CbxTipoOrden.Text
        End If

        Return Str & Orderby

    End Function


    Private Sub RefrescarTabla()
        Try
            TablaVentas.Clear()

            Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                Using myCommand As MySqlCommand = New MySqlCommand(SelectCommand & ConstructorQuery(), ConMixta)
                    ConMixta.Open()

                    Using myReader As MySqlDataReader = myCommand.ExecuteReader

                        TablaVentas.Load(myReader, LoadOption.Upsert)

                        ConMixta.Close()

                    End Using
                End Using
            End Using

            TablaVentas.EndLoadData()
            GridView1.BestFitColumns()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub


    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        If cbxCondicion.Text <> "Todas" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion WHERE Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
            cbxCondicion.Tag = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
        End If
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView1.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Nulo"))
            If category = "1" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.SeaShell
                e.HighPriority = True
            End If
        End If

        If Me.Owner.Name = frm_envio_607.Name Then
            Dim View1 As GridView = sender
            If (e.RowHandle >= 0) Then
                Dim category As String = View1.GetRowCellDisplayText(e.RowHandle, View1.Columns("ID"))
                If category = LookingForIDFactura Then
                    e.Appearance.BackColor = Color.LightBlue
                    e.Appearance.BackColor2 = SystemColors.HighlightText
                    e.HighPriority = True
                End If
            End If
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarTipoMemo_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoMemo.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub FillNames()
        Dim DsNames As New DataSet

        ConMixta.Open()
        cmd = New MySqlCommand("SELECT FacturaDatos.NombreFactura FROM" & SysName.Text & "FacturaDatos GROUP BY NombreFactura Order by NombreFactura ASC Limit 100", ConMixta)
        'Where NombreFactura Like '%" + txtCliente.Text + "%' 
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsNames, "Nombre")
        ConMixta.Close()

        TablaNombres = DsNames.Tables("Nombre")

        For Each Fila As DataRow In TablaNombres.Rows
            newstr.Add(Fila.Item(0))
        Next

        txtCliente.AutoCompleteMode = AutoCompleteMode.Suggest
        txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtCliente.AutoCompleteCustomSource = newstr
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView1.RowClick
        If GridView1.FocusedRowHandle >= 0 Then
            If Me.Owner.Name = frm_inicio.Name Then

                If GridView1.GetFocusedRowCellValue("Nulo").ToString = "1" Then
                    MessageBox.Show("Clasificacion: " & GridView1.GetFocusedRowCellValue("ClasAnulacion").ToString & vbNewLine & "Motivo: " & GridView1.GetFocusedRowCellValue("MotivoAnulacion").ToString & vbNewLine & "Fecha: " & GridView1.GetFocusedRowCellValue("FechaAnulacion").ToString & vbNewLine & vbNewLine & "Anulador: " & GridView1.GetFocusedRowCellValue("Anulador").ToString)
                End If
            End If

        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub btnBuscarCons_Click(sender As Object, e As EventArgs) Handles btnBuscarCons.Click
        RefrescarTabla()
    End Sub

    Private Sub btnStructure_Click(sender As Object, e As EventArgs) Handles btnStructure.Click
        frm_query_structure.txtQuery.Text = "SQL Query: " & SelectCommand & ConstructorQuery()
        frm_query_structure.ShowDialog()

        frm_niveles_desarrollo_facturacion.IDFactura = GridView1.GetFocusedRowCellValue("ID")
        frm_niveles_desarrollo_facturacion.ShowDialog(Me)
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

    Private Sub GridView1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        Try
            If GridView1.FocusedRowHandle >= 0 Then

                If GridView1.FocusedColumn.FieldName = "SecondID" Then
                    btnModificar.PerformClick()
                    Exit Sub
                ElseIf GridView1.FocusedColumn.FieldName = "Imagen" Then
                    If TypeConnection.Text = 1 Then

                        If frm_subir_documento.Visible = True Then
                            frm_subir_documento.Close()
                        End If

                        frm_subir_documento.Show(Me)
                        frm_subir_documento.PicDocumento.Width = 539
                        frm_subir_documento.PicDocumento.Height = 607
                        frm_subir_documento.PicDocumento.Location = New Point(0, 0)

                        frm_subir_documento.RutaDocumento.Text = GridView1.GetFocusedRowCellValue(GridView1.Columns("FacturaFilePath"))

                        If GridView1.GetFocusedRowCellValue(GridView1.Columns("FacturaFilePath")) <> "" Then
                            If System.IO.File.Exists(GridView1.GetFocusedRowCellValue(GridView1.Columns("FacturaFilePath"))) = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(GridView1.GetFocusedRowCellValue(GridView1.Columns("FacturaFilePath")), FileMode.Open, FileAccess.Read)
                                frm_subir_documento.PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
                                wFile.Close()
                                frm_subir_documento.btnDownload.Visible = True
                            Else
                                frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                                frm_subir_documento.btnBuscar.PerformClick()
                                frm_subir_documento.btnDownload.Visible = False
                            End If
                        Else
                            frm_subir_documento.PicDocumento.Image = My.Resources.No_Image
                            frm_subir_documento.btnBuscar.PerformClick()
                            frm_subir_documento.btnDownload.Visible = False
                        End If
                    End If
                End If


                If Me.Owner.Name = frm_inicio.Name Then
                    Exit Sub

                ElseIf Me.Owner.Name = frm_devolucion_fact.Name Then
                    frm_devolucion_fact.txtFactura.Text = GridView1.GetFocusedRowCellValue("SecondID").ToString

                    Close()

                ElseIf Me.Owner.Name = frm_pagares.Name Then
                    Dim IDCondicion As New Label
                    IDCondicion.Text = GridView1.GetFocusedRowCellValue("IDCondicion").ToString

                    ConLibregco.Open()
                    cmd = New MySqlCommand("SELECT Dias FROM Condicion Where IDCondicion='" + IDCondicion.Text + "'", ConLibregco)
                    Dim Dias As String = Convert.ToString(cmd.ExecuteScalar())
                    ConLibregco.Close()

                    If Dias > 0 Then
                        frm_pagares.lblIDFactura.Text = GridView1.GetFocusedRowCellValue("ID").ToString
                        frm_pagares.txtFactura.Text = GridView1.GetFocusedRowCellValue("SecondID").ToString

                        Close()
                    Else
                        MessageBox.Show("La factura seleccionada no tiene pagarés procesados.", "No se encontraron pagarés", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                ElseIf Me.Owner.Name = frm_introducir_seriales.Name Then
                    frm_introducir_seriales.txtFactura.Text = GridView1.GetFocusedRowCellValue("SecondID").ToString

                    Close()

                ElseIf Me.Owner.Name = frm_consulta_serie_garantia.Name Then
                    frm_consulta_serie_garantia.txtIDFactura.Text = GridView1.GetFocusedRowCellValue("SecondID").ToString

                    Close()

                ElseIf Me.Owner.Name = frm_proceso_pagares.Name Then
                    frm_proceso_pagares.txtFactura.Text = GridView1.GetFocusedRowCellValue("SecondID").ToString

                    Close()

                ElseIf Me.Owner.Name = frm_reporte_recibos_cobros.Name Then
                    frm_reporte_recibos_cobros.txtIDFactura.Text = GridView1.GetFocusedRowCellValue("ID").ToString
                    frm_reporte_recibos_cobros.txtFactura.Text = GridView1.GetFocusedRowCellValue("SecondID").ToString

                    Close()
                ElseIf Me.Owner.Name = frm_reporte_entrega_cobros.Name Then
                    frm_reporte_entrega_cobros.txtIDFactura.Text = GridView1.GetFocusedRowCellValue("ID").ToString
                    frm_reporte_entrega_cobros.txtFactura.Text = GridView1.GetFocusedRowCellValue("SecondID").ToString

                    Close()

                ElseIf Me.Owner.Name = frm_reporte_titulaciones.Name Then
                    frm_reporte_titulaciones.txtIDFactura.Text = GridView1.GetFocusedRowCellValue("ID").ToString
                    frm_reporte_titulaciones.txtFactura.Text = GridView1.GetFocusedRowCellValue("SecondID").ToString

                    Close()

                ElseIf Me.Owner.Name = frm_conduce.Name Then
                    frm_conduce.lblIDFactura.Text = GridView1.GetFocusedRowCellValue("ID").ToString
                    frm_conduce.txtIDFactura.Text = GridView1.GetFocusedRowCellValue("SecondID").ToString
                    frm_conduce.btnBuscarFactura.PerformClick()

                    Close()

                ElseIf Me.Owner.Name = frm_cartas_modelos_facturas.Name Then
                    frm_cartas_modelos_facturas.txtIDFactura.Text = GridView1.GetFocusedRowCellValue("ID").ToString
                    frm_cartas_modelos_facturas.txtFactura.Text = GridView1.GetFocusedRowCellValue("SecondID").ToString

                    Close()

                ElseIf Me.Owner.Name = frm_reporte_conduces.Name Then
                    frm_reporte_conduces.txtIDFactura.Text = GridView1.GetFocusedRowCellValue("ID").ToString
                    frm_reporte_conduces.txtFactura.Text = GridView1.GetFocusedRowCellValue("SecondID").ToString
                    Close()
                End If



            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If GridView1.FocusedRowHandle >= 0 Then
            If TypeConnection.Text = 1 Then
                If TablaVentas.Rows.Count = 0 Then
                    btnImagen.Visible = False
                    btnSubir.Visible = False
                Else
                    If CInt(DTConfiguracion.Rows(88 - 1).Item("Value2Int")) = 0 Then
                        btnImagen.Visible = False
                        btnSubir.Visible = False
                        GridView1.Columns("Imagen").Visible = False
                    Else
                        GridView1.Columns("Imagen").Visible = True
                        If GridView1.SelectedRowsCount > 0 Then
                            If GridView1.GetFocusedRowCellValue("FacturaFilePath").ToString <> "" Then
                                btnImagen.Visible = True
                                btnSubir.Visible = False
                            Else
                                btnImagen.Visible = False
                                btnSubir.Visible = True
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnPresentar_Click(sender As Object, e As EventArgs) Handles btnPresentar.Click
        'Try
        Dim DsSP As New DataSet

        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If GridView1.FocusedRowHandle >= 0 Then
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

            If TypeConnection.Text = 1 Then
                frm_reportView.ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text)
            Else
                frm_reportView.ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))
            End If

            If GridView1.RowCount = 0 Then
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

                '@Cliente
                If txtIDCliente.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDCliente.Text
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cliente")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Vendedor
                If txtIDVendedor.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDVendedor.Text
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Vendedor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Condicion
                If cbxCondicion.Text = "Todas" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = cbxCondicion.Tag.ToString
                End If
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Condicion")
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

                '@IDUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Chofer
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Chofer")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Cobrador
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cobrador")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Suplidor
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Suplidor")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Marca
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Marca")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Provincia
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Provincia")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Municipio
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Municipio")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Almacen
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Almacen")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@NotaDescuento
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NotaDescuento")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Calificacion
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Calificacion")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@NCF
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@NCF")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Cierre
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Cierre")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@HabilitarFicha
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = frm_reportView.ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@HabilitarFicha")
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
                ''Almacenes
                frm_reportView.ObjRpt.SetParameterValue("Almacenes", "Todos los almacenes")
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If GridView1.SelectedRowsCount > 0 Then
                    If GridView1.GetFocusedRowCellValue("Nulo").ToString = 1 Then
                        MessageBox.Show("El documento de ventas " & GridView1.GetFocusedRowCellValue("SecondID").ToString & " de fecha " & GridView1.GetFocusedRowCellValue("Fecha").ToString & " está nulo, por lo que no se puede visualizar la factura.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    Dim cmdSP As New MySqlCommand
                    Dim AdaptadorSP As MySqlDataAdapter

                    'Consulta de los datos de la factura   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    AdaptadorSP = New MySqlDataAdapter("call" & SysName.Text & "facturadatosview(" + GridView1.GetFocusedRowCellValue("ID").ToString + ");", Con)
                        AdaptadorSP.Fill(DsSP, "FacturaDatosView")

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        'Llenado EmpresaView
                        AdaptadorSP = New MySqlDataAdapter("Select * from" & SysName.Text & "RazonSocial LIMIT 1", Con)
                        AdaptadorSP.Fill(DsSP, "EmpresaView")

                        'Para facturas a credito
                        'Lleando pagaresView
                        AdaptadorSP = New MySqlDataAdapter("SELECT IDPagare,Pagares.IDFactura,NoPagare,Pagares.Cantidad,Pagares.FechaVencimiento as VencimientoPagares,Pagares.DiasVencidos as DiasVencidosPagares,Concepto,Pagares.Monto,Pagares.Balance as BalancePagares,Pagares.Nulo,GROUP_CONCAT(FacturaArticulos.Descripcion,'') AS DescripcionArticulos FROM" & SysName.Text & "Pagares INNER JOIN" & SysName.Text & "FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "FacturaArticulos on FacturaDatos.IDFacturaDatos=FacturaArticulos.IDFactura Where Pagares.IDFactura='" + GridView1.GetFocusedRowCellValue("ID").ToString + "' GROUP BY Pagares.IDPagare", ConMixta)
                        AdaptadorSP.Fill(DsSP, "ListadoPagaresView")

                        'Lleando balances_clientes_view
                        AdaptadorSP = New MySqlDataAdapter("call libregco.balances_clientes(" + GridView1.GetFocusedRowCellValue("IDCliente").ToString + ");", Con)
                        AdaptadorSP.Fill(DsSP, "balances_clientes")

                    'Lleando garantaias
                    AdaptadorSP = New MySqlDataAdapter("Select * from (SELECT idArticulos_garantia,FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.idarticulo=articulos_garantia.idarticulo Where FacturaArticulos.IDFactura='" + GridView1.GetFocusedRowCellValue("ID").ToString + "' UNION ALL SELECT idArticulos_garantia,FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.IDSubcategoria=articulos_garantia.IDSubCategoria Where FacturaArticulos.IDFactura='" + GridView1.GetFocusedRowCellValue("ID").ToString + "' UNION ALL SELECT idArticulos_garantia,FacturaArticulos.IDFactArt,FacturaArticulos.IDFactura,Articulos.IDArticulo,Articulos.IDSubCategoria,Articulos.IDCategoria,Termino,Articulos_Garantia.Orden,isHypertext FROM" & SysName.Text & "FacturaArticulos inner join libregco.precioarticulo on facturaarticulos.idarticulo=precioarticulo.idarticulo inner join libregco.articulos on precioarticulo.idarticulo=articulos.idarticulo INNER join libregco.articulos_garantia on articulos.IDCategoria=articulos_garantia.IDCategoria Where FacturaArticulos.IDFactura='" + GridView1.GetFocusedRowCellValue("ID").ToString + "') AS Resultados  Group by Resultados.idArticulos_garantia ORDER BY Resultados.Orden", ConMixta)
                    AdaptadorSP.Fill(DsSP, "GarantiaArticulosView")


                    For Each crReportObject In frm_reportView.ObjRpt.Subreports
                        If CType(crReportObject, ReportDocument).Name = "subreport_preguntas" Then
                            'Lleando garantaias
                            AdaptadorSP = New MySqlDataAdapter("SELECT idFactura_Preguntas,factura_preguntas.IDArticulo_Pregunta,factura_preguntas.IDFactura,factura_preguntas.IDArticulo,Titulo,Descripcion,Respuesta FROM" & SysName.Text & "factura_preguntas inner join Libregco.articulos_preguntas on factura_preguntas.IDArticulo_Pregunta=articulos_preguntas.idArticulos_preguntas Where IDFactura='" + GridView1.GetFocusedRowCellValue("ID").ToString + "'", ConMixta)
                            AdaptadorSP.Fill(DsSP, "FacturaPreguntas_DATA")

                            frm_reportView.ObjRpt.Subreports("subreport_preguntas").SetDataSource(DsSP.Tables("FacturaPreguntas_DATA"))
                        End If
                    Next

                    cmdSP.Dispose()
                    AdaptadorSP.Dispose()

                        frm_reportView.ObjRpt.Database.Tables("facturadatosview1").SetDataSource(DsSP.Tables("FacturaDatosView"))
                        frm_reportView.ObjRpt.Database.Tables("empresaview1").SetDataSource(DsSP.Tables("EmpresaView"))
                        frm_reportView.ObjRpt.Subreports("subinforme_pagares_en_factura.rpt").SetDataSource(DsSP.Tables("ListadoPagaresView"))
                        frm_reportView.ObjRpt.Subreports("balances_clientes_formato.rpt").SetDataSource(DsSP.Tables("balances_clientes"))
                        frm_reportView.ObjRpt.Subreports("subreport_garantias.rpt").SetDataSource(DsSP.Tables("GarantiaArticulosView"))



                    If Duplicidad.Text = 1 Then
                        frm_reportView.ObjRpt.SetParameterValue("Duplicidad", DTConfiguracion.Rows(93 - 1).Item("Value1Var").ToString)
                    End If

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

        Else
            MessageBox.Show("No hay una fila seleccionada.")
        End If


        DsSP.Dispose()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString)
        '    GC.Collect()
        '    ObjRpt.Close()
        '    ObjRpt.Dispose()
        '    'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Dim dstemp As New DataSet
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM" & SysName.Text & "Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Reportes")
        Con.Close()

        Dim Tabla As DataTable = dstemp.Tables("Reportes")
        IDReport.Text = (Tabla.Rows(0).Item("IDReportes"))
        NameReport.Text = (Tabla.Rows(0).Item("Reporte"))
        PathReport.Text = (Tabla.Rows(0).Item("Path"))
        Duplicidad.Text = (Tabla.Rows(0).Item("ModoDuplicado"))

        If (Tabla.Rows(0).Item("HabilitadoResumen")) = 0 Then
            chkResumir.Visible = False
        Else
            chkResumir.Visible = True
        End If
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub SelectCliente()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Clientes Where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
            txtCliente.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
            If txtCliente.Text = "" Then txtIDCliente.Clear()
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " Desde SelectCliente")
            txtCliente.Text = ""
        End Try
    End Sub

    Private Sub SelectVendedor()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where IDEmpleado='" + txtIDVendedor.Text + "'", ConLibregco)
            txtVendedor.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()
            If txtVendedor.Text = "" Then txtIDVendedor.Clear()
        Catch ex As Exception
            txtVendedor.Text = ""
            'MessageBox.Show(ex.Message.ToString & " Desde SelectVendedor")
        End Try
    End Sub


    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If GridView1.FocusedRowHandle >= 0 Then
                If GridView1.SelectedRowsCount > 0 Then
                    frm_superclave.IDAccion.Text = 32
                    frm_superclave.ShowDialog(Me)
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If

                    Dim IDFactura As New Label
                    IDFactura.Text = GridView1.GetFocusedRowCellValue("ID").ToString

                    Dim dstemp As New DataSet
                    ConMixta.Open()
                    cmd = New MySqlCommand("Select FacturaDatos.SecondID,FacturaDatos.IDCondicion,Condicion.Condicion,FacturaDatos.IDCliente,NombreFactura,DireccionFactura,TelefonosFactura,IdentificacionFactura,Clientes.Nombre,FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.IDTipoDocumento,FacturaDatos.IDTransaccion,FacturaDatos.Fecha,FacturaDatos.Hora,FacturaDatos.Inicial,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,FacturaDatos.Balance,FechaVencimiento,CondicionContado,SubTotal,Descuento,Itbis,Flete,TotalNeto,Transaccion.IDMoneda,Observacion,Clientes.IDCalificacion,Calificacion.Calificacion,Calificacion.ColorCalificacion,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=FacturaDatos.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,ifnull((Select Total from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoMontoPago,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Clientes.IDEmpleado as IDCobrador,Cobrador.Nombre as Cobrador,Clientes.BalanceGeneral,FacturaDatos.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,FacturaDatos.IDVehiculo,Vehiculo.DatoVehiculo,FacturaDatos.IDVendedor,Vendedor.Nombre as Vendedor,FacturaDatos.IDChofer,Chofer.Nombre as Chofer,FacturaDatos.IDAlmacen,Almacen.Almacen,HabilitarFicha,NotaContado,FacturaDatos.Nulo,FacturaDatos.Impreso,Clientes.Precio,Clientes.EntregarPorConduce,Clientes.Alertas,Clientes.BloqueoCobrador,Clientes.LiberarControles,Transaccion.IDMoneda from" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados as Cobrador on Clientes.IDEmpleado=Cobrador.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on FacturaDatos.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Vehiculo on FacturaDatos.IDVehiculo=Vehiculo.IDVehiculo INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Chofer on FacturaDatos.IDChofer=Chofer.IDEmpleado INNER JOIN" & SysName.Text & "Almacen on FacturaDatos.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where IDFacturaDatos='" + IDFactura.Text + "'", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(dstemp, "FacturaDatos")
                    ConMixta.Close()

                    Dim Tabla As DataTable = dstemp.Tables("FacturaDatos")
                    If frm_facturacion.Visible = True Then
                        frm_facturacion.Close()
                    End If

                    frm_facturacion.Show(Me)
                    frm_facturacion.Hora.Enabled = False
                    frm_facturacion.GbClientes.Text = "Información general <b>" & (Tabla.Rows(0).Item("Nombre")).ToString.ToUpper & "</b> <color=red> (" & (Tabla.Rows(0).Item("IDCliente")) & ") </color>"
                    frm_facturacion.txtIDCliente.Text = (Tabla.Rows(0).Item("IDCliente"))
                    frm_facturacion.txtIDFactura.Text = (Tabla.Rows(0).Item("IDFacturaDatos"))
                    frm_facturacion.txtNombre.Text = (Tabla.Rows(0).Item("NombreFactura"))
                    frm_facturacion.txtDireccion.Text = (Tabla.Rows(0).Item("DireccionFactura"))
                    frm_facturacion.txtTelefonos.Text = (Tabla.Rows(0).Item("TelefonosFactura"))
                    frm_facturacion.txtRNC.Text = (Tabla.Rows(0).Item("IdentificacionFactura"))
                    frm_facturacion.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                    frm_facturacion.lblIDTipoDocumento.Text = (Tabla.Rows(0).Item("IDTipoDocumento"))
                    frm_facturacion.lblIDTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
                    frm_facturacion.cbxCondicion.Text = (Tabla.Rows(0).Item("Condicion"))
                    frm_facturacion.cbxCondicion.Tag = (Tabla.Rows(0).Item("IDCondicion"))
                    frm_facturacion.RefrescarBalances()
                    frm_facturacion.cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))
                    frm_facturacion.txtFecha.Value = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy")
                    frm_facturacion.txtInicial.Text = (Tabla.Rows(0).Item("Inicial"))
                    frm_facturacion.txtCantidadPagos.Text = (Tabla.Rows(0).Item("CantidadPagos"))
                    frm_facturacion.txtMontoPagos.Text = (Tabla.Rows(0).Item("MontoPagos"))

                    frm_facturacion.txtAdicional.Text = CDbl(Tabla.Rows(0).Item("PagoAdicional")).ToString("C")

                    If IsDate(Tabla.Rows(0).Item("FechaAdicional")) Then
                        frm_facturacion.txtFechaAdicional.Text = CDate(Tabla.Rows(0).Item("FechaAdicional")).ToString("dd/MM/yyyy")
                    Else
                        frm_facturacion.txtFechaAdicional.Text = ""
                    End If
                    frm_facturacion.txtBalance.Text = (Tabla.Rows(0).Item("Balance"))
                    frm_facturacion.txtFechaVencimiento.Text = (Tabla.Rows(0).Item("FechaVencimiento"))
                    frm_facturacion.txtCondicionContado.Text = (Tabla.Rows(0).Item("CondicionContado"))
                    frm_facturacion.txtSubTotal.Text = (Tabla.Rows(0).Item("SubTotal"))
                    frm_facturacion.TxtDescuentoSuma.Text = (Tabla.Rows(0).Item("Descuento"))
                    frm_facturacion.txtITBIS.Text = (Tabla.Rows(0).Item("Itbis"))
                    frm_facturacion.txtFlete.Text = (Tabla.Rows(0).Item("Flete"))
                    frm_facturacion.txtNeto.Text = (Tabla.Rows(0).Item("TotalNeto"))
                    frm_facturacion.txtObservacion.Text = (Tabla.Rows(0).Item("Observacion"))
                    frm_facturacion.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    frm_facturacion.txtCreditoDisponible.Text = CDbl(Tabla.Rows(0).Item("CreditoDisponible")).ToString("C")
                    frm_facturacion.txtCalificacion.Text = (Tabla.Rows(0).Item("Calificacion"))
                    frm_facturacion.lblCalificacionColor.BackColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))
                    frm_facturacion.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                    frm_facturacion.txtCobrador.Text = (Tabla.Rows(0).Item("Cobrador"))
                    frm_facturacion.txtCobrador.Tag = Tabla.Rows(0).Item("IDCobrador")
                    frm_facturacion.CbxTipoComprobante.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                    frm_facturacion.cbxVehiculo.Text = (Tabla.Rows(0).Item("Datovehiculo"))
                    frm_facturacion.txtVendedor.Tag = (Tabla.Rows(0).Item("IDVendedor"))
                    frm_facturacion.txtVendedor.Text = (Tabla.Rows(0).Item("Vendedor"))
                    frm_facturacion.CbxChofer.Text = (Tabla.Rows(0).Item("Chofer"))
                    frm_facturacion.cbxAlmacen.Text = (Tabla.Rows(0).Item("Almacen"))
                    frm_facturacion.EstadoImpresion = Tabla.Rows(0).Item("Impreso")
                    frm_facturacion.LiberarControles.Text = Tabla.Rows(0).Item("LiberarControles")
                    frm_facturacion.cbxMoneda.EditValue = CInt(Tabla.Rows(0).Item("IDMoneda"))

                    If (Tabla.Rows(0).Item("HabilitarFicha")) = 0 Then
                        frm_facturacion.chkFichaDatos.Checked = False
                    Else
                        frm_facturacion.chkFichaDatos.Checked = True
                    End If
                    If (Tabla.Rows(0).Item("NotaContado")) = 0 Then
                        frm_facturacion.chkHabilitarNota.Checked = False
                    Else
                        frm_facturacion.chkHabilitarNota.Checked = True
                        frm_int_notacontado.DtpFecha.Value = CDate(Between(Tabla.Rows(0).Item("CondicionContado"), "del ", " sólo")).ToString("dd/MM/yyyy")
                        frm_int_notacontado.txtMonto.Text = CDbl(After(Tabla.Rows(0).Item("CondicionContado"), "$")).ToString("C")
                    End If

                    If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                        frm_facturacion.chkDesactivar.Checked = False
                    Else
                        frm_facturacion.chkDesactivar.Checked = True
                    End If

                    If CInt(Tabla.Rows(0).Item("IDCalificacion")) > 6 Then
                        frm_facturacion.lblMensajeCalificacion.ForeColor = Color.FromArgb(Tabla.Rows(0).Item("ColorCalificacion"))
                        frm_facturacion.lblMensajeCalificacion.Visible = True
                    Else
                        frm_facturacion.lblMensajeCalificacion.Visible = False
                    End If


                    If IsNumeric(Tabla.Rows(0).Item("UltimoMontoPago")) Then
                        frm_facturacion.txtUltimoMonto.Text = CDbl(Tabla.Rows(0).Item("UltimoMontoPago")).ToString("C")
                    Else
                        frm_facturacion.txtUltimoMonto.Text = Tabla.Rows(0).Item("UltimoMontoPago")
                    End If

                    Dim Founded As Boolean = False
                    For Each itm As String In frm_facturacion.cbxPrecio.Items
                        If itm = (Tabla.Rows(0).Item("Precio")) Then
                            frm_facturacion.cbxPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                            Founded = True
                            Exit For
                        End If
                    Next
                    If Founded = False Then
                        frm_facturacion.cbxPrecio.Items.Add(Tabla.Rows(0).Item("Precio"))
                        frm_facturacion.cbxPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                        frm_facturacion.txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                    Else
                        frm_facturacion.txtNivelPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                        frm_facturacion.cbxPrecio.Text = (Tabla.Rows(0).Item("Precio"))
                    End If

                    If IsDate(Tabla.Rows(0).Item("UltimoPago")) Then
                        frm_facturacion.txtUltimoPago.Text = CDate(Tabla.Rows(0).Item("UltimoPago")).ToString("dd/MM/yyyy")
                    Else
                        frm_facturacion.txtUltimoPago.Text = (Tabla.Rows(0).Item("UltimoPago"))
                    End If

                    If (Tabla.Rows(0).Item("EntregarPorConduce")) = 1 Then
                        frm_facturacion.chkEntregarporConduce.Checked = True
                    Else
                        frm_facturacion.chkEntregarporConduce.Checked = False
                    End If

                    'Liberando controles
                    If DTConfiguracion.Rows(83 - 1).Item("Value2Int") = 1 Then
                        If Tabla.Rows(0).Item("IDCliente") = DTConfiguracion.Rows(84 - 1).Item("Value2Int") Then
                            frm_facturacion.LiberarControles.Text = 1
                        End If
                    End If

                    If (Tabla.Rows(0).Item("Alertas")) <> "" Then
                        MessageBox.Show("El cliente [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & " tiene una alerta." & vbNewLine & vbNewLine & Tabla.Rows(0).Item("Alertas"), "Alerta de cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    If (Tabla.Rows(0).Item("BloqueoCobrador")) = 1 Then
                        MessageBox.Show("Se han deshabilitado los controles para el cliente [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & " ya que se habilitó el bloqueo del cobrador." & vbNewLine & vbNewLine & "Verifique los motivos del bloqueo con el cobrador para deshabilitar la opción en el mantenimiento de clientes.", "Bloqueo del cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        frm_facturacion.DeshabilitarControles()
                    End If

                    If TypeConnection.Text = 1 Then
                        If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                            frm_facturacion.PicImagen.Image = My.Resources.no_photo
                        Else
                            Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("Foto"))
                            If ExistFile = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                                frm_facturacion.PicImagen.Image = Image.FromStream(wFile)
                                wFile.Close()
                            Else
                                MessageBox.Show("Se ha encontrado un archivo que ha sido específicado como una foto de cliente. Sin embargo, el archivo ha sido movido o eliminado de la ruta de acceso suministrada a la base de datos." & vbNewLine & vbNewLine & "Por favor verifique la integridad de la ruta de acceso válida en '" & Tabla.Rows(0).Item("Foto") & "' en el directorio.", "Archivo no encontrado en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If
                        End If
                    End If

                    frm_facturacion.btnAnular.Enabled = True
                    If frm_facturacion.dgvArticulosFactura.Rows.Count > 0 Then
                        frm_facturacion.cbxMoneda.Enabled = False
                    End If

                    frm_facturacion.RefrescarTablaConsulta()
                    frm_facturacion.RefrescarTablaPagares()
                    frm_facturacion.SumTotales()


                    'Cargando prefacturas incluidas
                    Dim dstem As New DataSet

                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT IDPrefactura FROM" & SysName.Text & "prefactura where IDFacturaDatos='" + Tabla.Rows(0).Item("IDFacturaDatos").ToString + "'", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(dstem, "prefactura")
                    ConMixta.Close()

                    For Each dt As DataRow In dstem.Tables(0).Rows
                        frm_facturacion.IDPrefactura.Add(dt.Item("IDPrefactura"))
                    Next

                    Tabla.Dispose()
                    dstemp.Dispose()
                    dstem.Dispose()

                Else

                    MessageBox.Show("No hay una fila seleccionada.")

                End If

            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub frm_consulta_ventas_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        GridView1.BestFitColumns()
    End Sub



    Private Sub GridView1_EndGrouping(sender As Object, e As EventArgs) Handles GridView1.EndGrouping
        GridView1.BestFitColumns()
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

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave
        SelectCliente()
    End Sub

    Private Sub txtIDVendedor_Leave(sender As Object, e As EventArgs) Handles txtIDVendedor.Leave
        SelectVendedor()
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

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Dim str As String = ""
        For i As Integer = 0 To GridView1.RowCount - 1
            str = str & vbNewLine & GridView1.GetRowCellValue(i, GridView1.FocusedColumn)
        Next

        Clipboard.SetText(str)
    End Sub
End Class