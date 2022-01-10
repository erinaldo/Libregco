Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid

Public Class frm_mant_clientes

    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    'Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador, Adaptador1 As MySqlDataAdapter
    Dim DefaultCobrador, DefaultDiasCondicion, DefaultNcf, DefaultCondicion, DefaultEstadoCivil, DefaultOcupacion, DefaultNacionalidad, DefaultTratamiento, IdentObligCred, lblCheckIncompletes, NumberToCheckNames, CopiaCedulaObligatoria, DireccionObligatoria, TelefonoPersonal1Obligatoria, TelefonoPersonalObligatoria2, GaranteObligatoria, InformacionAdicionalObligatoria, CantCustomers As String
    Dim CbxClase As New DataGridViewComboBoxColumn
    Dim PictureColumn As New DataGridViewImageColumn
    Friend lblChkVivienda, lblTipoVivienda, lblchkVehiculo, lblchkTrabajo, lblchkSeguro, lblchkTarjetas, lblControlarEdad, lblCreditosAnteriores, lblGarante, LastIDCliente As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList
    Dim Precios As New ArrayList
    Friend AccionesModulosAutorizadas As New ArrayList
    Dim TablaBalances As DataTable
    Dim TablaCarnetTributacion As DataTable

    Private Sub frm_mant_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        SetConfiguracion()
        Permisos = PasarPermisos(Me.Tag)
        CargarEmpresa()
        SetTablaBalances()
        SetTablaCarnetsTributacion()
        LimpiarDatosCliente()
        ColumnsDgvRerencias()
        ColumnsDgvContratos()
        ColumnsDgvRutas()
        CargarCbxClase()
        ActualizarTodo()
    End Sub

    Sub RefrescarBalances()
        Try
            TablaBalances.Rows.Clear()

            If txtIDCliente.Text = "" Then
                Dim ds As New DataSet
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT * FROM libregco.tipomoneda ORDER BY IDTipoMoneda ASC", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds, "tipomoneda")
                ConLibregco.Close()

                Dim img As Image
                Dim wFile As System.IO.FileStream

                For Each Row As DataRow In ds.Tables(0).Rows
                    If Row.Item("MonedaImagen") <> "" Then
                        If System.IO.File.Exists(Row.Item("MonedaImagen")) Then
                            wFile = New FileStream(Row.Item("MonedaImagen"), FileMode.Open, FileAccess.Read)
                            img = ResizeImage(System.Drawing.Image.FromStream(wFile), 18)
                        Else
                            img = ResizeImage(My.Resources.No_Image, 18)
                        End If
                    Else
                        img = ResizeImage(My.Resources.No_Image, 18)
                    End If


                    TablaBalances.Rows.Add("", img, Row.Item("Texto"), Row.Item("Signo"), 0, 0, 0, 0, Row.Item("IDTipoMoneda"))

                Next

                ds.Dispose()
            Else

                Dim ds As New DataSet

                ConMixta.Open()
                cmd = New MySqlCommand("SELECT idClientes_Balances,IDMoneda,MonedaImagen,Texto,Signo,Balance,LimiteCredito,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos LEFT JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda and FacturaDatos.IDCliente=Clientes_Balances.IDCliente) as CargosCliente FROM Libregco.tipomoneda INNER JOIN Libregco.Clientes_Balances on TipoMoneda.IDTipoMoneda=Clientes_Balances.IDMoneda Where Clientes_Balances.IDCliente='" + txtIDCliente.Text + "' Order by Balance ASC", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds, "tipomoneda")
                ConMixta.Close()

                Dim img As Image
                Dim wFile As System.IO.FileStream

                For Each Fila As DataRow In ds.Tables("tipomoneda").Rows
                    If Fila.Item("MonedaImagen") <> "" Then
                        If System.IO.File.Exists(Fila.Item("MonedaImagen")) Then
                            wFile = New FileStream(Fila.Item("MonedaImagen"), FileMode.Open, FileAccess.Read)
                            img = ResizeImage(System.Drawing.Image.FromStream(wFile), 18)
                        Else
                            img = ResizeImage(My.Resources.No_Image, 18)
                        End If
                    Else
                        img = ResizeImage(My.Resources.No_Image, 18)
                    End If


                    TablaBalances.Rows.Add(Fila.Item("idClientes_Balances"), img, Fila.Item("Texto"), Fila.Item("Signo"), Fila.Item("LimiteCredito"), Fila.Item("Balance"), Fila.Item("CargosCliente"), CDbl(Fila.Item("LimiteCredito")) - CDbl(Fila.Item("Balance")), Fila.Item("IDMoneda"))
                Next

                ds.Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.FieldName = "Limite" Then
            If IsNumeric(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Limite"))) Then
                GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Disponible"), CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Limite"))) - CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Balance"))))
            Else
                GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Limite"), 0)
                GridView1.PostEditor()
                GridView1.SetRowCellValue(e.RowHandle, GridView1.Columns("Disponible"), CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Limite"))) - CDbl(GridView1.GetRowCellValue(e.RowHandle, GridView1.Columns("Balance"))))
            End If
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)

        If e.Column.FieldName = "Cargos" Then
            If CDbl(currentView.GetRowCellValue(e.RowHandle, "Cargos")) = 0 Then
                e.Appearance.ForeColor = Color.Black
            Else
                e.Appearance.ForeColor = Color.Red
            End If

        ElseIf e.Column.FieldName = "Disponible" Then
            If CDbl(currentView.GetRowCellValue(e.RowHandle, "Disponible")) = 0 Then
                e.Appearance.ForeColor = Color.Black

            ElseIf CDbl(currentView.GetRowCellValue(e.RowHandle, "Disponible")) > 0 Then
                e.Appearance.ForeColor = Color.Green

            Else
                e.Appearance.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Function BalancesClientesExist(ByVal IDCliente As String, ByVal IDMoneda As String) As Boolean
        cmd = New MySqlCommand("Select count(*) FROM libregco.clientes_balances where IDCliente='" + IDCliente + "' And IDMoneda='" + IDMoneda + "'", ConLibregco)
        If Convert.ToString(cmd.ExecuteScalar()) = 0 Then
            Return False
        Else
            Return True
        End If

    End Function
    Private Sub ActualizarLimites()
        Try

            If ConLibregco.State = ConnectionState.Open Then
                ConLibregco.Close()
            End If


            ConLibregco.Open()

            For Each dt As DataRow In TablaBalances.Rows
                If CStr(dt.Item("IDClientes_Balance")) = "" Then
                    If BalancesClientesExist(txtIDCliente.Text, dt.Item("IDTipoMoneda").ToString) = False Then
                        cmd = New MySqlCommand("INSERT INTO Libregco.clientes_balances (IDCliente,IDMoneda,Balance,CargosGeneral,BalanceLetras,LimiteCredito) VALUES ('" + txtIDCliente.Text + "','" + dt.Item("IDTipoMoneda").ToString + "','" + dt.Item("Balance").ToString + "',0,'" + ConvertNumbertoString(dt.Item("Balance").ToString, dt.Item("Moneda").ToString).ToString + "','" + dt.Item("Limite").ToString + "')", ConLibregco)
                        cmd.ExecuteNonQuery()

                        cmd = New MySqlCommand("Select idClientes_Balances from clientes_balances where idClientes_Balances= (Select Max(idClientes_Balances) from clientes_balances)", ConLibregco)
                        dt.Item("IDClientes_Balance") = Convert.ToString(cmd.ExecuteScalar())
                    End If


                Else
                    cmd = New MySqlCommand("UPDATE clientes_balances SET LimiteCredito='" + CDbl(dt.Item("Limite")).ToString + "' WHERE idClientes_Balances='" + dt.Item("IDClientes_Balance").ToString + "'", ConLibregco)
                    cmd.ExecuteNonQuery()
                End If

            Next

            ConLibregco.Close()


            If frm_facturacion.Visible = True Then
                If frm_facturacion.txtIDCliente.Text = txtIDCliente.Text Then
                    Dim dstemp As New DataSet
                    ConTemporal.Open()
                    cmd = New MySqlCommand("SELECT Clientes_Balances.IDMoneda,idClientes_Balances,TasaCompra,Balance,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos LEFT JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda and FacturaDatos.IDCliente=Clientes_Balances.IDCliente) as CargosCliente,Moneda,(Clientes_Balances.LimiteCredito-Clientes_Balances.Balance) as CreditoDisponible FROM Libregco.tipomoneda INNER JOIN Libregco.Clientes_Balances on TipoMoneda.IDTipoMoneda=Clientes_Balances.IDMoneda Where Clientes_Balances.IDCliente='" + frm_facturacion.txtIDCliente.Text + "' and Clientes_Balances.IDMoneda='" + frm_facturacion.cbxMoneda.EditValue.ToString + "' Order by Balance ASC", ConTemporal)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(dstemp, "tipomoneda")
                    ConTemporal.Close()

                    If dstemp.Tables("tipomoneda").Rows.Count > 0 Then
                        frm_facturacion.txtBalanceGeneral.Text = CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("Balance")).ToString("C")
                        frm_facturacion.NombreMoneda = dstemp.Tables("tipomoneda").Rows(0).Item("Moneda")
                        frm_facturacion.txtCreditoDisponible.Text = GetAmountinCurrencyConvert(CDbl(dstemp.Tables("tipomoneda").Rows(0).Item("CreditoDisponible")), frm_facturacion.cbxMoneda.EditValue.ToString).ToString("C")
                        frm_facturacion.lblTasa.Text = dstemp.Tables("tipomoneda").Rows(0).Item("TasaCompra")

                        If dstemp.Tables("tipomoneda").Rows(0).Item("IDMoneda") = 1 Then
                            frm_facturacion.lblTasa.Visible = False
                            frm_facturacion.Label3.Visible = False
                        Else
                            frm_facturacion.lblTasa.Visible = True
                            frm_facturacion.Label3.Visible = True
                        End If

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        'If e.RowHandle >= 0 Then
        If e.Column.FieldName = "Vencimiento" Then
                GridView2.SetFocusedRowCellValue("Dias", CalcularFecha(Today, CDate(GridView2.GetFocusedRowCellValue("Vencimiento"))))
            End If
        'End If
    End Sub

    Sub RefrescarCarnets()
        'View.SetRowCellValue(e.RowHandle, View.Columns("idClientes_Carnet_Tributacion"), "")
        'View.SetRowCellValue(e.RowHandle, View.Columns("Fecha"), Now.ToString("dd/MM/yyyy hh:mm:ss"))
        'View.SetRowCellValue(e.RowHandle, View.Columns("Vencimiento"), Today)
        'View.SetRowCellValue(e.RowHandle, View.Columns("Dias"), CalcularFecha(Today, Today))
        'View.SetRowCellValue(e.RowHandle, View.Columns("RutaCarnet"), "")
        'View.SetRowCellValue(e.RowHandle, View.Columns("Imagen"), Nothing)
        If txtIDCliente.Text <> "" Then
            Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                Using myCommand As MySqlCommand = New MySqlCommand("SELECT idClientes_Carnet_Tributacion,Fecha,Vencimiento,RutaCarnet,if(RutaCarnet='',NULL,RutaCarnet) as Imagen FROM libregco.clientes_carnet_tributacion where IDCliente='" + txtIDCliente.Text + "'", ConMixta)
                    ConMixta.Open()

                    Using myReader As MySqlDataReader = myCommand.ExecuteReader

                        TablaCarnetTributacion.Load(myReader, LoadOption.Upsert)

                        ConMixta.Close()

                    End Using
                End Using
            End Using


            For Each rw As DataRow In TablaCarnetTributacion.Rows
                rw.Item("Dias") = CalcularFecha(Today, CDate(rw.Item("Vencimiento")))
            Next

            TablaCarnetTributacion.Columns("idClientes_Carnet_Tributacion").Unique = False
        End If
    End Sub

    Private Sub GridView2_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView2.InitNewRow
        'TablaCarnetTributacion.Columns.Add("idClientes_Carnet_Tributacion", System.Type.GetType("System.String"))
        'TablaCarnetTributacion.Columns.Add("Fecha", System.Type.GetType("System.String"))
        'TablaCarnetTributacion.Columns.Add("Vencimiento", System.Type.GetType("System.String"))
        'TablaCarnetTributacion.Columns.Add("Dias", System.Type.GetType("System.String"))
        'TablaCarnetTributacion.Columns.Add("RutaFoto", System.Type.GetType("System.String"))
        'TablaCarnetTributacion.Columns.Add("Imagen", System.Type.GetType("System.String"))
        'TablaCarnetTributacion.Columns.Add("Eliminar", System.Type.GetType("System.String"))

        Dim view As GridView = CType(sender, GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("idClientes_Carnet_Tributacion"), "")
        view.SetRowCellValue(e.RowHandle, view.Columns("Fecha"), Now.ToString("dd/MM/yyyy hh:mm:ss"))
        'view.SetRowCellValue(e.RowHandle, view.Columns("Vencimiento"), Today)
        view.SetRowCellValue(e.RowHandle, view.Columns("Dias"), "No determinada")
        view.SetRowCellValue(e.RowHandle, view.Columns("RutaCarnet"), "")
        'view.SetRowCellValue(e.RowHandle, view.Columns("Imagen"), Nothing)

    End Sub

    Private Sub GridView2_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        If e.Column.FieldName = "colores" Then
            If currentView.GetRowCellValue(e.RowHandle, "idClientes_Carnet_Tributacion") = "" Then
                e.Appearance.BackColor = Color.Red
            Else
                e.Appearance.BackColor = Color.LightGreen
            End If
        ElseIf e.Column.FieldName = "Dias" Then
            e.Appearance.BackColor = SystemColors.ControlLight

        ElseIf e.Column.FieldName = "Fecha" Then
            e.Appearance.BackColor = SystemColors.ControlLight
        End If
    End Sub

    Private Sub SetTablaCarnetsTributacion()
        TablaCarnetTributacion = New DataTable("Carnet")
        TablaCarnetTributacion.Columns.Clear()
        TablaCarnetTributacion.Clear()

        Dim RepositoryPicture As New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit With {.ShowIcon = True, .NullText = "", .ShowMenu = False}
        Dim RepositoryVencimiento As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit() With {.NullText = Today, .AllowNullInput = DefaultBoolean.False, .NullValuePromptShowForEmptyValue = True}
        Dim RepositoryDelete As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit() With {.Name = "Eliminar"}

        RepositoryVencimiento.Mask.MaskType = XtraEditors.Mask.MaskType.DateTime
        RepositoryVencimiento.Mask.UseMaskAsDisplayFormat = True
        RepositoryVencimiento.Mask.EditMask = "d"

        RepositoryPicture.ShowDropDown = XtraEditors.Controls.ShowDropDown.Never
        RepositoryPicture.ShowMenu = False
        RepositoryPicture.ReadOnly = True
        'RepositoryPicture.

        RepositoryDelete.Buttons(0).Caption = "Eliminar"
        RepositoryDelete.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete
        RepositoryDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        RepositoryDelete.LookAndFeel.UseDefaultLookAndFeel = False
        RepositoryDelete.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)

        TablaCarnetTributacion.Columns.Add("colores", System.Type.GetType("System.String"))
        TablaCarnetTributacion.Columns.Add("idClientes_Carnet_Tributacion", System.Type.GetType("System.String"))
        TablaCarnetTributacion.Columns.Add("Fecha", System.Type.GetType("System.String"))
        TablaCarnetTributacion.Columns.Add("Vencimiento", System.Type.GetType("System.Object"))
        TablaCarnetTributacion.Columns.Add("Dias", System.Type.GetType("System.String"))
        TablaCarnetTributacion.Columns.Add("RutaCarnet", System.Type.GetType("System.String"))
        TablaCarnetTributacion.Columns.Add("Imagen", System.Type.GetType("System.Object"))
        TablaCarnetTributacion.Columns.Add("Eliminar", System.Type.GetType("System.String"))

        GridControl2.DataSource = TablaCarnetTributacion

        GridView2.Columns("Imagen").ColumnEdit = RepositoryPicture
        GridView2.Columns("Vencimiento").ColumnEdit = RepositoryVencimiento
        GridView2.Columns("Eliminar").ColumnEdit = RepositoryDelete

        GridView2.Columns("colores").Width = 5
        GridView2.Columns("colores").Caption = " "
        GridView2.Columns("colores").OptionsColumn.AllowShowHide = False
        GridView2.Columns("colores").OptionsColumn.ShowInExpressionEditor = False
        GridView2.Columns("colores").OptionsColumn.ShowCaption = False
        GridView2.Columns("colores").OptionsColumn.AllowSize = False
        GridView2.Columns("colores").OptionsColumn.AllowEdit = False
        GridView2.Columns("colores").OptionsColumn.ReadOnly = True
        GridView2.Columns("colores").OptionsFilter.AllowFilter = False

        GridView2.Columns("idClientes_Carnet_Tributacion").Visible = False
        GridView2.Columns("Fecha").Width = 140
        GridView2.Columns("Fecha").OptionsColumn.ReadOnly = True
        GridView2.Columns("Fecha").OptionsColumn.AllowEdit = False

        GridView2.Columns("Vencimiento").Width = 120

        GridView2.Columns("Dias").Width = 120
        GridView2.Columns("Dias").OptionsColumn.ReadOnly = True
        GridView2.Columns("Dias").OptionsColumn.AllowEdit = False

        GridView2.Columns("RutaCarnet").Visible = False

        GridView2.Columns("Eliminar").Width = 65

    End Sub

    Private Sub GridView2_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView2.RowCellClick
        'If GridView2.FocusedRowHandle >= -1 Then

        If GridView2.FocusedColumn.FieldName = "Imagen" Then
            If TypeConnection.Text = 1 Then

                If frm_subir_documento.Visible = True Then
                    frm_subir_documento.Close()
                End If

                frm_subir_documento.Show(Me)
                frm_subir_documento.PicDocumento.Width = 539
                frm_subir_documento.PicDocumento.Height = 607
                frm_subir_documento.PicDocumento.Location = New Point(0, 0)

                frm_subir_documento.RutaDocumento.Text = GridView2.GetFocusedRowCellValue(GridView2.Columns("RutaCarnet"))

                If GridView2.GetFocusedRowCellValue(GridView2.Columns("RutaCarnet")) <> "" Then
                    If System.IO.File.Exists(GridView2.GetFocusedRowCellValue(GridView2.Columns("RutaCarnet"))) = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(GridView2.GetFocusedRowCellValue(GridView2.Columns("RutaCarnet")), FileMode.Open, FileAccess.Read)
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

                GridView2.Focus()
                GridView2.FocusedRowHandle = GridControl2.NewItemRowHandle
                GridView2.FocusedColumn = GridView2.VisibleColumns(6)
                GridView2.ShowEditor()
            End If

        ElseIf GridView2.FocusedColumn.FieldName = "Eliminar" Then
                If GridView2.GetFocusedRowCellDisplayText("idClientes_Carnet_Tributacion").ToString = "" Then
                    GridView2.DeleteRow(GridView2.FocusedRowHandle)
                Else
                    Dim Result1 As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el carnet de vencimiento" & vbNewLine & vbNewLine & GridView2.GetFocusedRowCellValue("Vencimiento") & vbNewLine & vbNewLine & " de " & txtNombre.Text & "?", "Eliminar carnet de tributación especial", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result1 = MsgBoxResult.Yes Then
                        ConLibregco.Open()
                        cmd = New MySqlCommand("DELETE FROM clientes_carnet_tributacion WHERE idClientes_Carnet_Tributacion=(" + GridView2.GetFocusedRowCellValue("idClientes_Carnet_Tributacion").ToString + ")", ConLibregco)
                        cmd.ExecuteNonQuery()
                        ConLibregco.Close()

                        GridView2.DeleteRow(GridView2.FocusedRowHandle)
                    End If
                End If

            End If
        'End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If txtIDCliente.Text <> "" Then
            If TablaCarnetTributacion.Rows.Count > 0 Then
                ConLibregco.Open()
                For Each rw As DataRow In TablaCarnetTributacion.Rows
                    If CStr(rw.Item("idClientes_Carnet_Tributacion")) = "" Then
                        If IsDate(rw.Item("Vencimiento")) = True And CStr(rw.Item("RutaCarnet")) <> "" Then
                            'Busco el último ID de los documentos para diferenciarlos y no sustituir archivos diferentes con la opcion mover archivos
                            cmd = New MySqlCommand("SELECT AUTO_INCREMENT AS id FROM information_schema.Tables WHERE TABLE_SCHEMA='Libregco' AND table_name='clientes_carnet_tributacion'", ConLibregco)
                            Dim UltNum As Double = Convert.ToDouble(cmd.ExecuteScalar())

                            'Verifico si existen los archivos en ruta
                            Dim ExistFile As Boolean = System.IO.File.Exists(rw.Item("RutaCarnet"))
                            If ExistFile = True Then
                                Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Clientes\CarnetTributacion\" & txtIDCliente.Text & "-" & UltNum & ".png"

                                If RutaDestino <> rw.Item("RutaCarnet") Then
                                    My.Computer.FileSystem.CopyFile(rw.Item("RutaCarnet"), RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                                End If

                                cmd = New MySqlCommand("INSERT INTO Libregco.clientes_carnet_tributacion (Fecha,IDCliente,Vencimiento,RutaCarnet) VALUES ('" + CDate(rw.Item("Fecha")).ToString("yyyy-MM-dd HH:mm:ss") + "','" + txtIDCliente.Text + "','" + CDate(rw.Item("Vencimiento")).ToString("yyyy-MM-dd") + "','" + Replace(RutaDestino, "\", "\\").ToString + "')", ConLibregco)
                                cmd.ExecuteNonQuery()

                                cmd = New MySqlCommand("Select idClientes_Carnet_Tributacion from clientes_carnet_tributacion where idClientes_Carnet_Tributacion= (Select Max(idClientes_Carnet_Tributacion) from clientes_carnet_tributacion)", ConLibregco)
                                rw.Item("idClientes_Carnet_Tributacion") = Convert.ToDouble(cmd.ExecuteScalar())
                            End If
                        End If
                    Else
                        cmd = New MySqlCommand("UPDATE clientes_carnet_tributacion SET Vencimiento='" + CDate(rw.Item("Vencimiento")).ToString("yyyy-MM-dd") + "',RutaCarnet='" + Replace(rw.Item("RutaCarnet"), "\", "\\").ToString + "' WHERE idClientes_Carnet_Tributacion=(" + CStr(rw.Item("idClientes_Carnet_Tributacion")).ToString + ")", ConLibregco)
                        cmd.ExecuteNonQuery()
                    End If
                Next

                ConLibregco.Close()

                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(3))

            End If

        End If
    End Sub

    Private Sub SetTablaBalances()
        Dim ReposityImagen As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit With {.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray, .PictureAlignment = ContentAlignment.MiddleCenter, .SizeMode = XtraEditors.Controls.PictureSizeMode.Zoom, .NullText = "", .ShowMenu = True}
        Dim RepositoryLimite As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit() With {.NullText = 0, .AllowNullInput = DefaultBoolean.False, .NullValuePromptShowForEmptyValue = 0}
        Dim RepositoryBalance As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit() With {.NullText = 0, .AllowNullInput = DefaultBoolean.False, .NullValuePromptShowForEmptyValue = 0}
        Dim RepositoryCargos As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit() With {.NullText = 0, .AllowNullInput = DefaultBoolean.False, .NullValuePromptShowForEmptyValue = 0}
        Dim RepositoryDisponible As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit() With {.NullText = 0, .AllowNullInput = DefaultBoolean.False, .NullValuePromptShowForEmptyValue = 0}

        TablaBalances = New DataTable("Balances")

        TablaBalances.Columns.Add("IDClientes_Balance", System.Type.GetType("System.String"))
        TablaBalances.Columns.Add("MonedaImagen", System.Type.GetType("System.Object"))
        TablaBalances.Columns.Add("Moneda", System.Type.GetType("System.String"))
        TablaBalances.Columns.Add("Signo", System.Type.GetType("System.String"))
        TablaBalances.Columns.Add("Limite", System.Type.GetType("System.Double"))
        TablaBalances.Columns.Add("Balance", System.Type.GetType("System.Double"))
        TablaBalances.Columns.Add("Cargos", System.Type.GetType("System.Double"))
        TablaBalances.Columns.Add("Disponible", System.Type.GetType("System.Double"))
        TablaBalances.Columns.Add("IDTipoMoneda", System.Type.GetType("System.String"))

        GridControl1.DataSource = TablaBalances

        GridView1.Columns("MonedaImagen").ColumnEdit = ReposityImagen
        GridView1.Columns("Limite").ColumnEdit = RepositoryLimite
        GridView1.Columns("Balance").ColumnEdit = RepositoryBalance
        GridView1.Columns("Cargos").ColumnEdit = RepositoryCargos
        GridView1.Columns("Disponible").ColumnEdit = RepositoryDisponible

        GridView1.Columns("IDClientes_Balance").Visible = False
        GridView1.Columns("MonedaImagen").Caption = " "
        GridView1.Columns("MonedaImagen").Width = 50
        GridView1.Columns("Moneda").OptionsColumn.ReadOnly = True
        GridView1.Columns("Moneda").OptionsColumn.AllowEdit = False
        GridView1.Columns("Moneda").Width = 200
        GridView1.Columns("Signo").OptionsColumn.ReadOnly = True
        GridView1.Columns("Signo").OptionsColumn.AllowEdit = False
        GridView1.Columns("Signo").Width = 50
        GridView1.Columns("Balance").OptionsColumn.ReadOnly = True
        GridView1.Columns("Balance").OptionsColumn.AllowEdit = False
        GridView1.Columns("Balance").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Balance").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Balance").Width = 85
        GridView1.Columns("Cargos").OptionsColumn.ReadOnly = True
        GridView1.Columns("Cargos").OptionsColumn.AllowEdit = False
        GridView1.Columns("Cargos").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Cargos").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Cargos").Width = 85
        GridView1.Columns("Limite").Caption = "Límite crédito"
        GridView1.Columns("Limite").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Limite").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Limite").Width = 85
        GridView1.Columns("Disponible").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Disponible").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Disponible").Width = 85
        GridView1.Columns("Disponible").OptionsColumn.ReadOnly = True
        GridView1.Columns("Disponible").OptionsColumn.AllowEdit = False
        GridView1.Columns("IDTipoMoneda").Visible = False
    End Sub
    Private Sub ControlRapido()
        Try
            If DTConfiguracion.Rows(102 - 1).Item("Value2Int").ToString = "1" Then
                If SearchingFast = False Then
                    If Me.WindowState = FormWindowState.Normal Then
                        If frm_accesos_rapidos_clientes.Visible = True Then
                            If frm_accesos_rapidos_clientes.Owner.Name <> Me.Name Then
                                frm_accesos_rapidos_clientes.Close()
                                frm_accesos_rapidos_clientes.Show(Me)
                            End If
                        Else
                            frm_accesos_rapidos_clientes.Show(Me)
                        End If

                        frm_accesos_rapidos_clientes.Location = New Point(Me.Location.X + Me.Size.Width - 12, Me.Location.Y)
                    Else
                        If frm_accesos_rapidos_clientes.Visible = True Then
                            frm_accesos_rapidos_clientes.Close()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub SetConfiguracion()
        Try
            Con.Open()
            ConMixta.Open()

            'Cobrador Predeterminado
            cmd = New MySqlCommand("Select Nombre from Configuracion INNER JOIN Empleados on Configuracion.Value2Int=Empleados.IDEmpleado Where IDConfiguracion=25", Con)
            DefaultCobrador = Convert.ToString(cmd.ExecuteScalar())

            'Dias condicion para pagares
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=52", Con)
            DefaultDiasCondicion = Convert.ToString(cmd.ExecuteScalar())

            'Comprobante Fiscal Predeterminado
            cmd = New MySqlCommand("SELECT TipoComprobante FROM configuracion INNER JOIN comprobantefiscal on Configuracion.Value2Int=ComprobanteFiscal.IDComprobanteFiscal Where IDConfiguracion=13", Con)
            DefaultNcf = Convert.ToString(cmd.ExecuteScalar())

            'Estado Civil Predeterminado
            cmd = New MySqlCommand("SELECT EstadoCivil FROM" & SysName.Text & "configuracion INNER JOIN Libregco.EstadoCivil on Configuracion.Value2Int=EstadoCivil.IDCivil Where IDConfiguracion=60", ConMixta)
            DefaultEstadoCivil = Convert.ToString(cmd.ExecuteScalar())

            'Ocupacion Predeterminada
            cmd = New MySqlCommand("SELECT Ocupacion FROM" & SysName.Text & "configuracion INNER JOIN Libregco.Ocupacion on Configuracion.Value2Int=Ocupacion.IDOcupacion Where IDConfiguracion=61", ConMixta)
            DefaultOcupacion = Convert.ToString(cmd.ExecuteScalar())

            'Nacionalidad Predeterminada
            cmd = New MySqlCommand("SELECT Nacionalidad FROM" & SysName.Text & "configuracion INNER JOIN Libregco.Nacionalidad on Configuracion.Value2Int=Nacionalidad.IDNacionalidad Where IDConfiguracion=62", ConMixta)
            DefaultNacionalidad = Convert.ToString(cmd.ExecuteScalar())

            'Obligación de cédulas en créditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=55", Con)
            IdentObligCred = Convert.ToString(cmd.ExecuteScalar())

            If IdentObligCred = 1 Then
                Label84.Visible = True
            Else
                Label84.Visible = False
            End If

            'Controlar edad
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=58", Con)
            lblControlarEdad.Text = Convert.ToString(cmd.ExecuteScalar())

            'Verificar incompletos
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=122", Con)
            lblCheckIncompletes = Convert.ToString(cmd.ExecuteScalar())

            'Cant de registros para revisar nombres
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=123", Con)
            NumberToCheckNames = Convert.ToInt16(cmd.ExecuteScalar())

            'Copia de cedula obligatoria
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=138", Con)
            CopiaCedulaObligatoria = Convert.ToString(cmd.ExecuteScalar())

            'Solicitar direccion completa en creditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=155", Con)
            DireccionObligatoria = Convert.ToInt16(cmd.ExecuteScalar())

            If DireccionObligatoria = 1 Then
                Label81.Visible = True
            Else
                Label81.Visible = False
            End If

            'Solicitar telefono personal 1 en creditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=156", Con)
            TelefonoPersonal1Obligatoria = Convert.ToInt16(cmd.ExecuteScalar())

            If TelefonoPersonal1Obligatoria = 1 Then
                Label82.Visible = True
            Else
                Label82.Visible = False
            End If

            'Solicitar telefono personal 2 en creditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=157", Con)
            TelefonoPersonalObligatoria2 = Convert.ToInt16(cmd.ExecuteScalar())

            If TelefonoPersonalObligatoria2 = 1 Then
                Label83.Visible = True
            Else
                Label83.Visible = False
            End If

            'Solicitar garante en creditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=158", Con)
            GaranteObligatoria = Convert.ToInt16(cmd.ExecuteScalar())

            If GaranteObligatoria = 1 Then
                Label80.Visible = True
            Else
                Label80.Visible = False
            End If

            'Solicitar garante en creditos
            cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=159", Con)
            InformacionAdicionalObligatoria = Convert.ToInt16(cmd.ExecuteScalar())

            If InformacionAdicionalObligatoria = 1 Then
                Label79.Visible = True
            Else
                Label79.Visible = False
            End If

            'Verificar si hay internet para google maps
            If My.Computer.Network.IsAvailable = True Then
                GoogleMapsIco.Visible = True
                LinkGoogleMaps.Visible = True
            Else
                GoogleMapsIco.Visible = False
                LinkGoogleMaps.Visible = False
            End If

            'Condicion Predeterminada
            cmd = New MySqlCommand("SELECT Value2Int FROM configuracion where IDConfiguracion=59", Con)
            DefaultCondicion = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select Condicion from Libregco.Condicion Where IDCondicion='" + DefaultCondicion + "'", ConMixta)
            DefaultCondicion = Convert.ToString(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select count(IDCliente) from Libregco.Clientes", ConMixta)
            CantCustomers = Convert.ToString(cmd.ExecuteScalar())


            Con.Close()
            ConMixta.Close()

            If GaranteObligatoria = 1 Then
                rdbGaranteSi.Checked = True
                rdbGaranteNo.Enabled = False
            End If


            'Lugares de nacimientos
            txtLugarNacimiento.AutoCompleteCustomSource.Clear()
            Dim Ds As New DataSet

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT LugarNacimiento,COUNT(LugarNacimiento) as Contar FROM Clientes WHERE LugarNacimiento<>'' GROUP BY LugarNacimiento HAVING COUNT(LugarNacimiento)>10 ORDER BY LugarNacimiento ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Clientes")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Clientes")

            For Each Dt As DataRow In Tabla.Rows
                txtLugarNacimiento.AutoCompleteCustomSource.Add(Dt.Item(0).ToString())
            Next



        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub ColumnsDgvRerencias()
        With DgvReferencias
            .Columns.Add("Nombre", "Nombre")
            .Columns.Add("Relacion", "Relación")
            .Columns.Add("Direccion", "Dirección")
            .Columns.Add("Telefono", "Teléfono")
        End With

        PropiedadDgvReferencias()
    End Sub

    Private Sub ColumnsDgvContratos()
        With DgvContratos
            .Columns.Add("IDContrato", "IDContrato")
            .Columns.Add("SecondID", "Código")
            .Columns.Add("NoContrato", "No. Contrato")
            .Columns.Add("Folio", "Folio")
            .Columns.Add("Fecha", "Fecha")
            .Columns.Add("Vencimiento", "Vencimiento")
        End With

        PropiedadDgvContratos()
    End Sub

    Sub PropiedadDgvContratos()
        Try
            If DgvContratos.Columns.Count > 0 Then
                Dim DatagridWidth As Double = (DgvContratos.Width - DgvContratos.RowHeadersWidth) / 100
                With DgvContratos
                    .Columns(0).Visible = False
                    .Columns(1).Width = DatagridWidth * 20
                    .Columns(2).Width = DatagridWidth * 15
                    .Columns(3).Width = DatagridWidth * 15
                    .Columns(4).Width = DatagridWidth * 25
                    .Columns(5).Width = DatagridWidth * 25
                End With

            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub RefrescarTablaGestion()
        Try

            DgvGestion.Rows.Clear()
            ConLibregco.Open()
            Dim SqlConsulta As New MySqlCommand("SELECT idgestion_clientes,fecha,gestion,infoadicional FROM libregco.gestion_clientes where IDCliente= '" + txtIDCliente.Text + "' and Nulo=0", ConLibregco)
            Dim LectorGestion As MySqlDataReader = SqlConsulta.ExecuteReader

            While LectorGestion.Read
                DgvGestion.Rows.Add(LectorGestion.GetValue(0), LectorGestion.GetValue(1), LectorGestion.GetValue(2), LectorGestion.GetValue(3))
            End While
            LectorGestion.Close()
            ConLibregco.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Sub RefrescarTablaContratos()
        Try
            DgvContratos.Rows.Clear()
            ConLibregco.Open()
            Dim SqlConsulta As New MySqlCommand("SELECT IDContrato,SecondID,NoContrato,Folio,Fecha,FechaVencimiento,Observaciones FROM contratos where IDCliente= '" + txtIDCliente.Text + "' and Nulo=0", ConLibregco)
            Dim LectorContratos As MySqlDataReader = SqlConsulta.ExecuteReader

            While LectorContratos.Read
                DgvContratos.Rows.Add(LectorContratos.GetValue(0), LectorContratos.GetValue(1), LectorContratos.GetValue(2), LectorContratos.GetValue(3), LectorContratos.GetValue(4), LectorContratos.GetValue(5))
            End While
            LectorContratos.Close()
            ConLibregco.Close()

            PropiedadDgvContratos()
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub RefrescarTablaReferencias()
        Try
            DgvReferencias.Rows.Clear()
            ConLibregco.Open()
            Dim SqlConsulta As New MySqlCommand("SELECT Nombre,Relacion,Direccion,Telefono FROM Referencias INNER JOIN relacionfamiliar ON Referencias.IDRelacion= relacionfamiliar.IDRelacionFamiliar where IDCliente = '" + txtIDCliente.Text + "'", ConLibregco)
            Dim LectorReferencias As MySqlDataReader = SqlConsulta.ExecuteReader

            While LectorReferencias.Read
                DgvReferencias.Rows.Add(LectorReferencias.GetValue(0), LectorReferencias.GetValue(1), LectorReferencias.GetValue(2), LectorReferencias.GetValue(3))
            End While
            LectorReferencias.Close()
            ConLibregco.Close()

            PropiedadDgvReferencias()


            DgvReferencias.ClearSelection()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ColumnsDgvRutas()
        DgvRutasAnexas.Columns.Clear()

        With DgvRutasAnexas
            .Columns.Add("IDDocClientes", "Código")    '0
            .Columns.Add("IDCliente", "Cód. Cliente") '1
            .Columns.Add("IDClase", "Cód. Clase") '2
            .Columns.Add("Ruta", "Ruta Destino") '3
            .Columns.Add(CbxClase) '4
            .Columns.Add("Tamaño", "Tamaño en KB") '5
            .Columns.Add(PictureColumn) '6
        End With

        PropiedadDgvRutasAnexas()
    End Sub

    Private Sub PropiedadDgvRutasAnexas()
        Try
            If DgvRutasAnexas.Columns.Count > 0 Then
                Dim DatagridWidth As Double = (DgvRutasAnexas.Width - DgvRutasAnexas.RowHeadersWidth) / 100
                With DgvRutasAnexas
                    .Columns(0).Visible = False
                    .Columns(1).Visible = False
                    .Columns(2).Visible = False
                    .Columns(3).Width = DatagridWidth * 58
                    .Columns(3).ReadOnly = True
                    .Columns(4).Width = DatagridWidth * 20
                    .Columns(4).HeaderText = "Clase Documento"
                    .Columns(4).DisplayIndex = 0
                    .Columns(5).Width = DatagridWidth * 10
                    .Columns(5).ReadOnly = True
                    .Columns(6).Width = DatagridWidth * 12
                End With

                CbxClase.FlatStyle = FlatStyle.Flat
                PictureColumn.ImageLayout = DataGridViewImageCellLayout.Zoom

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub PropiedadDgvReferencias()
        Try
            If DgvReferencias.Columns.Count > 0 Then
                Dim DatagridWidth As Double = (DgvReferencias.Width - DgvReferencias.RowHeadersWidth) / 100

                With DgvReferencias
                    .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
                    .Columns(0).Width = DatagridWidth * 30
                    .Columns(1).Width = DatagridWidth * 15
                    .Columns(1).HeaderText = "Relación"
                    .Columns(2).Width = DatagridWidth * 40
                    .Columns(2).HeaderText = "Dirección"
                    .Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    .Columns(3).Width = DatagridWidth * 15
                    .Columns(3).HeaderText = "Teléfono"
                End With
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Con.Close()
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ActualizarTodo()
        HabilitarCliente()
        FillTipoIdentificacion()
        FillNacionalidad()
        FillGenero()
        FillProvincia()
        FillOcupacion()
        FillEstadoCivil()
        FillOcupacionConyuge()
        FillCalificacion()
        FillComprobanteFiscal()
        FillCondicion()
        FillCobrador()
        FillVendedor()
        FillTratamiento()
        TypeTrabajo()
        CargarChecks()
        txtFechaIngreso.Text = Today.ToString("yyyy-MM-dd")
        TxtFechaNacimiento.Mask = ""
        txtIdentificacion.Mask = ""
        txtTelefonoPer.Mask = ""
        txtTelefonoHog.Mask = ""
        txtTelefonoTrab.Mask = ""
        txtTelefonoConyuge.Mask = ""
        txtTelefonoPat.Mask = ""
        txtTelefonoPatCony.Mask = ""
        txtCondicionDias.Text = DefaultDiasCondicion
        ColorCalificacion.BackColor = SystemColors.Control
        cbxCondicion.Text = DefaultCondicion
        lblStatusBar.Text = "Listo"
        txtSueldo.Text = CDbl(0).ToString("C")
        cbxTipoIdentificacionGarante.DataSource = Nothing
        XtraTabPage5.PageVisible = False
        cbxTipoIdentificacionGarante.Items.Clear()
        ControlRapido()
        Precios = GetRangePrices()
        RefrescarBalances()

        For Each item As String In Precios
            txtPrecio.Items.Add(item)
        Next

        If tbcClientes.Contains(tabPage2) Then
        Else
            tbcClientes.TabPages.Insert(2, tabPage2)
        End If
        If tbcClientes.Contains(Tab_Civil) Then
        Else
            tbcClientes.TabPages.Insert(3, Tab_Civil)
        End If

        XtraTabControl1.TabPages(0).PageEnabled = True
        XtraTabControl1.TabPages(1).PageEnabled = True
        XtraTabControl1.Refresh()
    End Sub

    Sub CargarChecks()
        chkNoRecibirCheques.Tag = 0
        chkCerrarCredito.Tag = 0
        chkCuentaIncobrable.Tag = 0
        chkDesactivarCliente.Tag = 0
        chkGenerarCargos.Tag = 1
        chkEntregarporConduce.Tag = 0
        chkBloqueoCobrador.Tag = 0
        lblChkVivienda.Text = 2
        lblchkVehiculo.Text = 2
        lblchkTrabajo.Text = 3
        lblchkSeguro.Text = 0
        ckhCuentasBancarias.Tag = 0
        lblchkTarjetas.Text = 0
        lblCreditosAnteriores.Text = 0
        lblTipoVivienda.Text = 3
        lblGarante.Text = 0
    End Sub

    Sub LimpiarDatosCliente()
        tbcClientes.SelectedIndex = 0
        txtIDCliente.Clear()
        txtNombre.Clear()
        txtApodo.Clear()
        txtEdad.Clear()
        cbxTipoIdentificacion.Items.Clear()
        cbxNacionalidad.Items.Clear()
        txtIdentificacion.Clear()
        cbxGenero.Items.Clear()
        TxtFechaNacimiento.Clear()
        txtLugarNacimiento.Clear()
        cbxProvincia.Items.Clear()
        cbxMunicipio.Items.Clear()
        CbxTratamiento.Items.Clear()
        CbxTratamiento.Tag = ""
        LastIDCliente.Text = ""
        txtDireccion.Clear()
        txtReferencia.Clear()
        txtTelefonoPer.Clear()
        txtTelefonoHog.Clear()
        txtCorreoElec.Clear()
        cbxOcupacion.Items.Clear()
        txtLugarTrabajo.Clear()
        txtUbicacionTrabajo.Clear()
        txtTelefonoTrab.Clear()
        txtPadre.Clear()
        txtMadre.Clear()
        txtDomicilioPat.Clear()
        txtTelefonoPat.Clear()
        cbxEstadoCivil.Items.Clear()
        txtNombreConyuge.Clear()
        txtTelefonoConyuge.Clear()
        txtCantNumLaborando.Clear()
        cbxOcupacionConyuge.Items.Clear()
        txtLugarTrabajoCony.Clear()
        txtPadreConyuge.Clear()
        txtMadreConyuge.Clear()
        txtDomicilioPatCony.Clear()
        txtTelefonoPatCony.Clear()
        txtIDTipoCredito.Clear()
        txtPrecio.Items.Clear()
        txtTipoCredito.Clear()
        txtIDGrupoCxc.Clear()
        txtGrupoCxc.Clear()
        txtTiempoAlquiler.Clear()
        cbxTiempoAlquier.SelectedIndex = 0
        cbxTiempoLaborando.SelectedIndex = 0
        txtEntidadCuentaBancaria.Clear()
        txtEntidadTarjeta.Clear()
        cbxCalificacion.Items.Clear()
        cbxTipoComprobante.Items.Clear()
        cbxCondicion.Items.Clear()
        TablaBalances.Rows.Clear()
        TablaCarnetTributacion.Rows.Clear()
        lblNacimientoFormatoLargo.Text = ""
        cbxCobrador.Items.Clear()
        cbxSubCobrador.Items.Clear()
        cbxVendedor.Items.Clear()
        txtInfoAdicional.Clear()
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        txtReferenciaComercial1.Clear()
        txtReferenciaComercial2.Clear()
        txtOcupacionAutoEmpleado.Clear()
        txtNombreGarante.Clear()
        txtIdentificacionGarante.Clear()
        DgvContratos.Rows.Clear()
        DgvReferencias.Rows.Clear()
        DgvRutasAnexas.Rows.Clear()
        DgvGestion.Rows.Clear()
        txtDireccionGarante.Clear()
        txtEncargadoCompras.Clear()
        txtContactoTelCompras.Text = ""
        txtContactoTelComprasExt.Clear()
        txtEncargadoCXC.Clear()
        txtContactoTelCXC.Text = ""
        txtExtEncargadoCXC.Clear()
        txtTelefonoGarante.Clear()
        chkNoRecibirCheques.Checked = False
        chkCuentaIncobrable.Checked = False
        chkCerrarCredito.Checked = False
        chkDesactivarCliente.Checked = False
        chkGenerarCargos.Checked = True
        chkEntregarporConduce.Checked = False
        chkSolicitarNoOrden.Checked = False
        chkBloqueoCobrador.Checked = False
        rdbVehiculosNo.Checked = False
        rdbVehiculosSi.Checked = False
        rdbVehiculoNoINFO.Checked = True
        rdbCasaAlquilada.Checked = False
        rdbCasaPropia.Checked = False
        rdbCasaNoInfo.Checked = True
        rdbCasa.Checked = False
        rdbPension.Checked = False
        rdbViviendaNoEspecificada.Checked = True
        rdbApartamento.Checked = False
        txtTiempoAlquiler.Enabled = False
        cbxTiempoAlquier.Enabled = False
        rdbCreditoComercialesSi.Checked = False
        rdbCreditoComercialNo.Checked = False
        txtReferenciaComercial1.Enabled = False
        txtReferenciaComercial2.Enabled = False
        rdbGaranteSi.Checked = False
        rdbGaranteNo.Checked = False
        GroupBox12.Enabled = False
        txtEntidadCuentaBancaria.Enabled = False
        txtEntidadTarjeta.Enabled = False
        rdbSiTrabajoEstablecimiento.Checked = False
        rdbSiTrabajoAuto.Checked = False
        rdbNoTrabajo.Checked = False
        rdbTrabajoNoSuministrado.Checked = True
        ckhCuentasBancarias.Checked = False
        chkTarjetasCredito.Checked = False
        lblCantCqDevueltos.Text = "Cantidad de cheques devueltos: "
        lblMontoUltCqDevuelto.Text = "Monto últ. cheque devuelto: "
        lblFechaUltCkDevuelto.Text = "Fecha últ. cheque devuelto: "
        lblMontoChequeDevPendiente.Text = "Monto cheques dev. pendientes: "
        lblFechaCqDevPendiente.Text = "Fecha últ. cheque dev. pendiente:"
        lblMontoUltimoPago.Text = "Monto de último pago: "
        lblFechaUltimoPago.Text = "Fecha de último pago: "
        lblBalanceActual.Text = "Balance actual: "
        lblLimiteCredito.Text = "Límite de crédito: "
        lblDisponibilidad.Text = "Disponibilidad: "
        lblCantCkfuturosPend.Text = "Cant. de cheques futuros pendientes: "
        lblMontoCqFutPend.Text = "Monto de cheques fut. pendientes: "
        lblPromedioPago.Text = "Promedio de pago (mes): "
        lblFrecuenciaPagoDias.Text = "Frecuencia de pago (Días): "
        lblTotalComprado.Text = "Total comprado: "
        AccionesModulosAutorizadas.Clear()
        MakeRoundedImage(My.Resources.no_photo, PicInmediata)
        RefrescarTablaReferencias()
        RefrescarTablaRutas()
        CbxTratamiento.Focus()
    End Sub

    Private Sub SetIDProvincia()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDProvincia FROM Provincias WHERE Provincia= '" + cbxProvincia.SelectedItem + "'", ConLibregco)
        cbxProvincia.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub SetIDMunicipio()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDMunicipio FROM Municipios WHERE Municipio= '" + cbxMunicipio.SelectedItem + "'", ConLibregco)
        cbxMunicipio.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub SetIDNacionalidad()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDNacionalidad FROM nacionalidad WHERE nacionalidad = '" + cbxNacionalidad.SelectedItem + "'", ConLibregco)
        cbxNacionalidad.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub SetIDGenero()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDGenero FROM Genero WHERE Genero= '" + cbxGenero.SelectedItem + "'", ConLibregco)
        cbxGenero.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        If CbxTratamiento.Tag = 1 Then
            If cbxGenero.Tag = 1 Then
                CbxTratamiento.Text = "Sra."
            ElseIf cbxGenero.Tag = 2 Then
                CbxTratamiento.Text = "Sr."
            ElseIf cbxGenero.Tag = 3 Then
                CbxTratamiento.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub SetIDOcupacion()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDOcupacion FROM Ocupacion WHERE Ocupacion= '" + cbxOcupacion.SelectedItem + "'", ConLibregco)
        cbxOcupacion.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub SetIDOcupacionConyuge()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDOcupacion FROM Ocupacion WHERE Ocupacion= '" + cbxOcupacionConyuge.SelectedItem + "'", ConLibregco)
        cbxOcupacionConyuge.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub SetIDEstadoCivil()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCivil FROM EstadoCivil WHERE EstadoCivil= '" + cbxEstadoCivil.SelectedItem + "'", ConLibregco)
        cbxEstadoCivil.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub


    Private Sub FillProvincia()
        Try
            Dim ds As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Provincia FROM Provincias ORDER BY Provincia ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Provincias")
            cbxProvincia.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Provincias")

            For Each Fila As DataRow In Tabla.Rows
                cbxProvincia.Items.Add(Fila.Item("Provincia"))
            Next

            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron provincias hábiles en la base de datos. Inserte provincias para procesar los registros de los clientes.", "No se encontraron provincias", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillMunicipio()
        Try
            SetIDProvincia()

            Dim ds As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Municipio FROM Municipios WHERE IDProvincia= ('" + cbxProvincia.Tag.ToString + "') ORDER BY Municipio ASC", ConLibregco)
            Adaptador1 = New MySqlDataAdapter(cmd)
            Adaptador1.Fill(ds, "Municipios")
            cbxMunicipio.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = ds.Tables("Municipios")
            For Each Fila As DataRow In Tabla.Rows
                cbxMunicipio.Items.Add(Fila.Item("Municipio"))
            Next

            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron municipios hábiles en la base de datos. Inserte municipios para procesar los registros de los clientes.", "No se encontraron municipios", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            ElseIf Tabla.Rows.Count = 1 Then
                cbxMunicipio.SelectedIndex = 0
                txtDireccion.Focus()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillTipoIdentificacion()

        Dim ds As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM TipoIdentificacion ORDER BY Descripcion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoIdentificacion")
        cbxTipoIdentificacion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoIdentificacion")
        For Each Fila As DataRow In Tabla.Rows
            cbxTipoIdentificacion.Items.Add(Fila.Item("Descripcion"))
        Next

        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron tipos de indentifiación hábiles en la base de datos. Inserte tipos de identificación hábiles para procesar los registros de los clientes.", "No se encontraron municipios", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If
    End Sub


    Private Sub FillTipoIdentificacionGarante()
        Try
            Dim DsTemp As New DataSet

            cbxTipoIdentificacionGarante.DataSource = Nothing
            cbxTipoIdentificacionGarante.Items.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDTipoIdentificacion,Descripcion FROM TipoIdentificacion ORDER BY Descripcion ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoIdentificacion")
            cbxTipoIdentificacionGarante.DisplayMember = "Descripcion"
            cbxTipoIdentificacionGarante.ValueMember = "IDTipoIdentificacion"
            cbxTipoIdentificacionGarante.DataSource = DsTemp.Tables("TipoIdentificacion")
            ConLibregco.Close()

            If cbxTipoIdentificacionGarante.Items.Count = 0 Then
                MessageBox.Show("No se encontraron tipos de indentifiación hábiles en la base de datos. Inserte tipos de identificación hábiles para procesar los registros de los clientes.", "No se encontraron tipos de identificación", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub

    Private Sub FillNacionalidad()
        Try
            Dim ds As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Nacionalidad FROM Nacionalidad ORDER BY Nacionalidad ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Nacionalidad")
            cbxNacionalidad.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Nacionalidad")
            For Each Fila As DataRow In Tabla.Rows
                cbxNacionalidad.Items.Add(Fila.Item("Nacionalidad"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxNacionalidad.Text = DefaultNacionalidad
            Else
                MessageBox.Show("No se encontraron nacionalidades hábiles en la base de datos. Inserte nacionalidades para procesar los registros de los clientes.", "No se encontraron nacionalidades", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillGenero()
        Try

            Dim ds As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Genero FROM Genero ORDER BY Genero ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Genero")
            cbxGenero.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Genero")
            For Each Fila As DataRow In Tabla.Rows
                cbxGenero.Items.Add(Fila.Item("Genero"))
            Next

            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron géneros hábiles en la base de datos. Inserte géneros hábiles para procesar los registros de los clientes.", "No se encontraron géneros", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillOcupacion()
        Try
            Dim ds As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Ocupacion FROM Ocupacion ORDER BY Ocupacion ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Ocupacion")
            cbxOcupacion.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Ocupacion")

            For Each Fila As DataRow In Tabla.Rows
                cbxOcupacion.Items.Add(Fila.Item("Ocupacion"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxOcupacion.Text = DefaultOcupacion
            Else
                MessageBox.Show("No se encontraron ocupaciones hábiles en la base de datos. Inserte ocupaciones hábiles para procesar los registros de los clientes.", "No se encontraron ocupaciones", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillOcupacionConyuge()
        Try
            Dim ds As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Ocupacion FROM Ocupacion ORDER BY Ocupacion ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Ocupacion")
            cbxOcupacionConyuge.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Ocupacion")

            For Each Fila As DataRow In Tabla.Rows
                cbxOcupacionConyuge.Items.Add(Fila.Item("Ocupacion"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxOcupacionConyuge.Text = DefaultOcupacion
            Else
                MessageBox.Show("No se encontraron ocupaciones hábiles en la base de datos. Inserte ocupaciones hábiles para procesar los registros de los clientes.", "No se encontraron ocupaciones", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillEstadoCivil()
        Try

            Dim ds As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT EstadoCivil FROM EstadoCivil ORDER BY EstadoCivil ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "EstadoCivil")
            cbxEstadoCivil.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("EstadoCivil")

            For Each Fila As DataRow In Tabla.Rows
                cbxEstadoCivil.Items.Add(Fila.Item("EstadoCivil"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxEstadoCivil.Text = DefaultEstadoCivil
            Else
                MessageBox.Show("No se encontraron estados civiles hábiles en la base de datos. Inserte estados civiles hábiles para procesar los registros de los clientes.", "No se encontraron estados civiles", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetIDTipoIdentificacion()
        Try
            'Dim valueinMask As String
            'valueinMask = Replace(txtIdentificacion.Text, "-", "")
            'MessageBox.Show(valueinMask)

            Dim ds As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDTipoIdentificacion,Mascara FROM TipoIdentificacion WHERE Descripcion= '" + cbxTipoIdentificacion.SelectedItem + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoIdentificacion")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("TipoIdentificacion")

            cbxTipoIdentificacion.Tag = (Tabla.Rows(0).Item("IDTipoIdentificacion"))
            txtIdentificacion.Mask = (Tabla.Rows(0).Item("Mascara"))

            ''txtIdentificacion.Text = valueinMask

            If cbxTipoIdentificacion.Tag = "2" Then
                CbxTratamiento.Enabled = False
                cbxGenero.Enabled = False
                CbxTratamiento.Text = "N/A"
                cbxGenero.Text = "Sin especificar"
                txtApodo.Enabled = False
                TxtFechaNacimiento.Enabled = False
                cbxNacionalidad.Enabled = False
                txtLugarNacimiento.Enabled = False
                Panel8.Enabled = False
                GroupBox3.Enabled = False
                GroupBox5.Enabled = False
                GroupBox6.Enabled = False
                GroupBox7.Enabled = False
                GroupBox8.Enabled = False
                Panel6.Enabled = False
                txtReferenciaComercial1.Enabled = False
                txtReferenciaComercial2.Enabled = False
                Panel7.Enabled = False
                GroupBox12.Enabled = False
                GroupBox13.Enabled = False
                OpenMantRef_btn.Enabled = False

                If tbcClientes.Contains(tabPage2) Then
                    tbcClientes.TabPages.Remove(tabPage2)
                End If
                If tbcClientes.Contains(Tab_Civil) Then
                    tbcClientes.TabPages.Remove(Tab_Civil)
                End If

                XtraTabControl1.TabPages(0).PageEnabled = False
                XtraTabControl1.TabPages(1).PageEnabled = True

            Else
                CbxTratamiento.Enabled = True
                cbxGenero.Enabled = True
                txtApodo.Enabled = True
                cbxNacionalidad.Enabled = True
                TxtFechaNacimiento.Enabled = True
                txtLugarNacimiento.Enabled = True
                Panel8.Enabled = True
                GroupBox3.Enabled = True
                GroupBox5.Enabled = True
                GroupBox6.Enabled = True
                GroupBox7.Enabled = True
                GroupBox8.Enabled = True
                Panel6.Enabled = True
                txtReferenciaComercial1.Enabled = True
                txtReferenciaComercial2.Enabled = True
                Panel7.Enabled = True
                GroupBox12.Enabled = True
                GroupBox13.Enabled = True
                OpenMantRef_btn.Enabled = True

                If tbcClientes.Contains(tabPage2) Then
                Else
                    tbcClientes.TabPages.Insert(2, tabPage2)
                End If
                If tbcClientes.Contains(Tab_Civil) Then
                Else
                    tbcClientes.TabPages.Insert(3, Tab_Civil)
                End If

                XtraTabControl1.TabPages(0).PageEnabled = True
                XtraTabControl1.TabPages(1).PageEnabled = False

            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetIDCalificacion()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCalificacion FROM Calificacion WHERE Calificacion= '" + cbxCalificacion.SelectedItem + "'", ConLibregco)
        cbxCalificacion.Tag = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT ColorCalificacion FROM Calificacion WHERE Calificacion= '" + cbxCalificacion.SelectedItem + "'", ConLibregco)
        ColorCalificacion.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        ConLibregco.Close()
    End Sub

    Private Sub FillCalificacion()
        Try
            Dim ds As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Calificacion FROM Calificacion ORDER BY IDCalificacion ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Calificacion")
            cbxCalificacion.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Calificacion")
            For Each Fila As DataRow In Tabla.Rows
                cbxCalificacion.Items.Add(Fila.Item("Calificacion"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxCalificacion.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron estados civiles hábiles en la base de datos. Inserte estados civiles hábiles para procesar los registros de los clientes.", "No se encontraron estados civiles", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SetIDCobrador()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + cbxCobrador.SelectedItem + "'", Con)
        cbxCobrador.Tag = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub FillCondicion()
        Try
            Dim ds As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Condicion FROM Condicion where Nulo=0 ORDER BY Orden ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Condicion")
            cbxCondicion.Items.Clear()
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Condicion")
            For Each Fila As DataRow In Tabla.Rows
                cbxCondicion.Items.Add(Fila.Item("Condicion"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxCondicion.Text = DefaultCondicion
            Else
                MessageBox.Show("No se pudo cargar ningún tipo de condiciones de ventas para definirla ya que no se encontraron resultados en la base de datos. Cree las condiciones de ventas." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillComprobanteFiscal()
        Try
            Dim ds As New DataSet
            Con.Open()
            cmd = New MySqlCommand("SELECT TipoComprobante FROM ComprobanteFiscal where IDContexto=1 ORDER BY TipoComprobante ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "ComprobanteFiscal")
            cbxTipoComprobante.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")
            For Each Fila As DataRow In Tabla.Rows
                cbxTipoComprobante.Items.Add(Fila.Item("TipoComprobante"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxTipoComprobante.Text = DefaultNcf
            Else
                MessageBox.Show("No se pudo cargar ningún tipo de comprobante fiscal para definirla en la factura ya que no se encontraron resultados en la base de datos. Cree los tipos de comprobantes fiscales." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillTratamiento()
        Try
            Dim ds As New DataSet
            Con.Open()
            cmd = New MySqlCommand("SELECT TratamientoAbreviado FROM libregco.tratamiento Order by TratamientoAbreviado ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "tratamiento")
            CbxTratamiento.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("tratamiento")

            For Each Fila As DataRow In Tabla.Rows
                CbxTratamiento.Items.Add(Fila.Item("TratamientoAbreviado"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxTratamiento.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron registros de tratamientos activos en el sistema. Registre un tratamiento para poder procesar los registros de clientes.", "No se encontraron tratamientos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Close()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillVendedor()
        Try
            Dim ds As New DataSet
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where EsVendedor=1 ORDER BY Nombre ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Empleados")
            cbxVendedor.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Empleados")

            For Each Fila As DataRow In Tabla.Rows
                cbxVendedor.Items.Add(Fila.Item("Nombre"))
            Next

            If Tabla.Rows.Count > 0 Then
            Else
                MessageBox.Show("No se encontraron registros de vendedor activos en el sistema. Registre un cobrador para poder procesar los registros de clientes.", "No se encontraron vendedores", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Close()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FillCobrador()
        Try
            Dim ds As New DataSet
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados Where EsCobrador=1 ORDER BY Nombre ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Empleados")
            cbxCobrador.Items.Clear()
            cbxSubCobrador.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Empleados")

            For Each Fila As DataRow In Tabla.Rows
                cbxCobrador.Items.Add(Fila.Item("Nombre"))
                cbxSubCobrador.Items.Add(Fila.Item("Nombre"))

            Next

            If Tabla.Rows.Count > 0 Then
                cbxCobrador.Text = DefaultCobrador
                cbxSubCobrador.Text = DefaultCobrador
            Else
                MessageBox.Show("No se encontraron registros de cobrador activos en el sistema. Registre un cobrador para poder procesar los registros de clientes.", "No se encontraron cobradores", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Close()
            End If
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub cbxProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProvincia.SelectedIndexChanged
        FillMunicipio()
    End Sub

    Private Sub VerificarClasesAnexasVacias()
        Try
            Dim x As Integer = 0
            Dim Clase As String

Inicio:
            If x = DgvRutasAnexas.Rows.Count Then
                GoTo Fin
            End If

            Clase = DgvRutasAnexas.Rows(x).Cells(4).Value

            If Clase = "" Then
                MessageBox.Show("Seleccione el tipo de documento para anexar al registro de la ruta " & DgvRutasAnexas.Rows(x).Cells(3).Value & ".", "Seleccione el tipo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                If tbcClientes.SelectedIndex = 1 Then
                Else
                    tbcClientes.SelectedIndex = 1
                End If

                DgvRutasAnexas.Rows(x).Cells(4).Selected = True
                ControlSuperClave = 1
                Exit Sub
            Else
                x = x + 1
                GoTo Inicio
            End If

Fin:
            ControlSuperClave = 0

            'Con.Open()
            'cmd = New MySqlCommand("Select Value3Double from Configuracion where IDConfiguracion=70", Con)
            Dim MaxSizeofFile As Double = DTConfiguracion.Rows(70 - 1).Item("Value3Double")
            'Con.Close()

            For Each Row As DataGridViewRow In DgvRutasAnexas.Rows
                If Row.Cells(5).Value > MaxSizeofFile Then
                    MessageBox.Show("El archivo anexo del tipo: " & Row.Cells(4).Value & vbNewLine & vbNewLine & "Ubicado en " & Row.Cells(3).Value & vbNewLine & vbNewLine & " excede el tamaño máximo de [" & MaxSizeofFile & " kilobytes] establecido en el sistema.", "Excede tamaño autorizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Row.Cells(5).Selected = True
                    ControlSuperClave = 1
                    Exit Sub
                End If
            Next

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub InsertDocumentos()
        Try

            Dim IDDocumento, IDCliente, IDClase, Clase, Ruta As New Label
            Dim UltNum As Double

            For Each row As DataGridViewRow In DgvRutasAnexas.Rows
                IDDocumento.Text = row.Cells(0).Value
                IDCliente.Text = row.Cells(1).Value
                IDClase.Text = row.Cells(2).Value
                Ruta.Text = row.Cells(3).Value
                Clase.Text = row.Cells(4).Value

                If IDDocumento.Text = "" Then

                    'Busco el último ID de los documentos para diferenciarlos y no sustituir archivos diferentes con la opcion mover archivos
                    ConLibregco.Open()
                    cmd = New MySqlCommand("SELECT AUTO_INCREMENT AS id FROM information_schema.Tables WHERE TABLE_SCHEMA='Libregco' AND table_name='DocumentosClientes'", ConLibregco)
                    UltNum = Convert.ToDouble(cmd.ExecuteScalar())
                    ConLibregco.Close()

                    'Verifico si existen los archivos en ruta
                    Dim ExistFile As Boolean = System.IO.File.Exists(Ruta.Text)
                    If ExistFile = True Then
                        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Clientes\" & txtIDCliente.Text & "-" & Replace(txtNombre.Text, "/", "-") & " IDDOC" & UltNum & ".png"

                        If RutaDestino <> Ruta.Text Then
                            My.Computer.FileSystem.CopyFile(Ruta.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        End If

                        sqlQ = "INSERT INTO Documentosclientes (IDCliente,IDClase,Ruta) VALUES ('" + txtIDCliente.Text + "', '" + IDClase.Text + "','" + Replace(RutaDestino, "\", "\\") + "')"
                        ConLibregco.Open()
                        cmd = New MySqlCommand(sqlQ, ConLibregco)
                        cmd.ExecuteNonQuery()
                        ConLibregco.Close()
                    Else
                        MessageBox.Show("El archivo " & Ruta.Text & " ha sido eliminado o movido de la ruta anexada. Su anexo no será registrado.", "No se encontró archivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        DgvRutasAnexas.Rows.Remove(DgvRutasAnexas.Rows(row.Index))
                    End If

                Else

                    sqlQ = "UPDATE Documentosclientes SET IDCliente='" + txtIDCliente.Text + "',IDClase='" + IDClase.Text + "',Ruta='" + Replace(Ruta.Text, "\", "\\") + "'  WHERE IDDocumentosClientes= (" + IDDocumento.Text + ")"
                    ConLibregco.Open()
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()
                    ConLibregco.Close()
                End If

            Next

            RefrescarTablaRutas()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub RefrescarTablaRutas()
        Try
            Dim Img As Image
            Dim wFile As System.IO.FileStream

            DgvRutasAnexas.Rows.Clear()
            ConLibregco.Open()
            Dim Consulta As New MySqlCommand("SELECT IDDocumentosClientes,IDCliente,IDClase,Ruta,Descripcion FROM documentosclientes INNER JOIN claseanexa on DocumentosClientes.IDClase=ClaseAnexa.IDClaseAnexa Where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                Dim ExistFile As Boolean = System.IO.File.Exists(LectorDocumentos.GetValue(3))

                If ExistFile = True Then
                    wFile = New FileStream(LectorDocumentos.GetValue(3), FileMode.Open, FileAccess.Read)
                    Img = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                Else
                    Img = My.Resources.no_photo
                End If

                DgvRutasAnexas.Rows.Add(LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(2), LectorDocumentos.GetValue(3), LectorDocumentos.GetValue(4), GetFileSizes(LectorDocumentos.GetValue(3)), Img)
            End While

            LectorDocumentos.Close()
            ConLibregco.Close()

            If DgvRutasAnexas.Rows.Count = 0 Then
                lblStatusBar.Text = "Listo"
            Else
                lblStatusBar.Text = "Se han anexado : " & DgvRutasAnexas.Rows.Count & " Registro(s)"
            End If

        Catch ex As Exception
            ConLibregco.Close()
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub chkNoRecibirCheques_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoRecibirCheques.CheckedChanged
        If chkNoRecibirCheques.Checked = True Then
            chkNoRecibirCheques.Tag = 1
        Else
            chkNoRecibirCheques.Tag = 0
        End If
    End Sub

    Private Sub chkCuentaIncobrable_CheckedChanged(sender As Object, e As EventArgs) Handles chkCuentaIncobrable.CheckedChanged
        If chkCuentaIncobrable.Checked = True Then
            chkCuentaIncobrable.Tag = 1
        Else
            chkCuentaIncobrable.Tag = 0
        End If
    End Sub

    Private Sub cbxNacionalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNacionalidad.SelectedIndexChanged
        cbxNacionalidad.Tag = cbxNacionalidad.SelectedItem
        SetIDNacionalidad()
    End Sub

    Private Sub cbxGenero_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxGenero.SelectedIndexChanged
        SetIDGenero()
    End Sub

    Private Sub cbxOcupacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxOcupacion.SelectedIndexChanged
        SetIDOcupacion()
    End Sub

    Private Sub cbxEstadoCivil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEstadoCivil.SelectedIndexChanged
        SetIDEstadoCivil()
    End Sub

    Private Sub cbxOcupacionConyuge_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxOcupacionConyuge.SelectedIndexChanged
        SetIDOcupacionConyuge()
    End Sub

    Private Sub cbxMunicipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMunicipio.SelectedIndexChanged
        SetIDMunicipio()
    End Sub

    Private Sub cbxCalificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCalificacion.SelectedIndexChanged
        SetIDCalificacion()
    End Sub

    Private Sub cbxCobrador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCobrador.SelectedIndexChanged
        SetIDCobrador()
    End Sub

    Private Sub txtTelefonoPer_TextChanged(sender As Object, e As EventArgs) Handles txtTelefonoPer.TextChanged
        If txtTelefonoPer.Text = "" Then
        Else
            txtTelefonoPer.Mask = "000-000-0000"
            txtTelefonoPer.SelectionStart = 1
        End If
    End Sub

    Sub CalcEdad()
        Try
            If (IsDate(TxtFechaNacimiento.Text)) = True Then
                Dim DateNacimiento As Date = TxtFechaNacimiento.Text
                txtEdad.Text = CalcularFecha(DateNacimiento, Today)

                lblNacimientoFormatoLargo.Text = DateNacimiento.ToLongDateString

            End If
        Catch ex As Exception
            txtEdad.Text = ""
            lblNacimientoFormatoLargo.Text = ""
        End Try
    End Sub

    Function CalcularFecha(ByVal dDesde As Date, ByVal dHasta As Date)
        Dim iAnoDesde As Integer = dDesde.Year
        Dim iAnoHasta As Integer = dHasta.Year
        Dim iMesDesde As Integer = dDesde.Month
        Dim iMesHasta As Integer = dHasta.Month
        Dim iDiaDesde As Integer = dDesde.Day
        Dim iDiaHasta As Integer = dHasta.Day
        Dim Años, Meses, Dias As Integer

        If (iDiaHasta < iDiaDesde) Then
            iDiaHasta = iDiaHasta + 30
            iMesHasta = iMesHasta - 1
        End If

        Dias = iDiaHasta - iDiaDesde

        If (iMesHasta < iMesDesde) Then
            iMesHasta = iMesHasta + 12
            iAnoHasta = iAnoHasta - 1
        End If

        Meses = iMesHasta - iMesDesde
        Años = iAnoHasta - iAnoDesde

        'Retornamos los valores en una cadena string
        Dim AñoString, MesString, DiaString, A1, A2 As String
        If Años = 0 Then
            AñoString = ""
        ElseIf Años = 1 Then
            AñoString = Años & " año"
        Else
            AñoString = Años & " años"
        End If

        If Meses = 0 Then
            MesString = ""
        ElseIf Meses = 0 And Dias = 0 Then
        ElseIf Meses = 1 Then
            MesString = Meses & " mes"
        Else
            MesString = Meses & " meses"
        End If

        If Dias = 0 Then
            DiaString = ""
        ElseIf Dias = 1 Then
            DiaString = Dias & " día"
        Else
            DiaString = Dias & " días"
        End If

        If AñoString <> "" And MesString <> "" And DiaString <> "" Then
            A1 = ", "
        ElseIf AñoString = "" Then
            A1 = ""
        ElseIf MesString = "" And DiaString = "" Then
            A1 = ""
        Else
            A1 = " y "
        End If

        If AñoString <> "" And MesString <> "" And DiaString <> "" Then
            A2 = " y "
        ElseIf AñoString = "" And MesString <> "" And DiaString <> "" Then
            A2 = " y "
        ElseIf MesString = "" And DiaString = "" Then
            A2 = ""
        End If

        Return (AñoString & A1 & MesString & A2 & DiaString)

    End Function

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub txtCedula_Leave(sender As Object, e As EventArgs) Handles txtIdentificacion.Leave
        If IdentObligCred = 1 Then
            If cbxTipoIdentificacion.Text.Contains("Cédula") Then
                If txtIdentificacion.MaskFull = False Then
                    MessageBox.Show("Se ha establecido que es obligatoria la introducción de la cédula de identidad y electoral para la solicitud de créditos." & vbNewLine & vbNewLine & "Por favor ingrese el número de cédula del cliente solicitante para procesar el registro. El registro del cliente y las facturas a crédito no podrán ser procesadas bajo esta condición", "Escriba el No. de cédula", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    VerificarCedula()
                End If
            End If
        Else
            VerificarCedula()
        End If
    End Sub

    Private Sub VerificarSiExisteCedula()
        Try
            Dim TexttoFind As String

            TexttoFind = Replace(txtIdentificacion.Text, "-", "").Trim

            If TexttoFind <> "" Then
                Dim ds As New DataSet
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT IDCliente,Nombre,Identificacion FROM Clientes WHERE Identificacion= '" + txtIdentificacion.Text + "'", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Clientes")
                ConLibregco.Close()

                Dim Tabla As DataTable = Ds.Tables("Clientes")

                If Tabla.Rows.Count = 0 Then
                    ControlSuperClave = 0
                Else
                    MessageBox.Show("La cédula introducida ya existe en la base de datos." & vbNewLine & vbNewLine & "Pertenece al cliente código No. [" & (Tabla.Rows(0).Item("IDCliente")) & "] " & (Tabla.Rows(0).Item("Nombre")) & ".", "Existe en la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    ControlSuperClave = 1
                    txtIdentificacion.Clear()
                End If
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub VerificarCedula()
        Try

            If txtIDCliente.Text = "" Then
                Dim ds As New DataSet
                Dim Cedula As New Label
                Cedula.Text = Replace(txtIdentificacion.Text, "-", "").Trim

                If Cedula.Text = "" Then
                    Exit Sub
                End If

                VerificarSiExisteCedula()
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                Ds.Clear()
                ConUtilitarios.Open()
                cmd = New MySqlCommand("SELECT * FROM Libregco_Utilitarios.RncDgii WHERE RNC= '" + Cedula.Text + "'", ConUtilitarios)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "RncDgii")
                ConUtilitarios.Close()

                Dim Tabla As DataTable = Ds.Tables("RncDgii")

                If Tabla.Rows.Count = 0 Then
                    Dim ValueReplace As String
                    ValueReplace = Replace(txtIdentificacion.Text, "_", "")
                    ValueReplace = Replace(ValueReplace, "-", "")

                    If ValueReplace.Trim <> "" Then
                        MessageBox.Show("El registro de cédula no se encuentra en la base de datos de la DGII.", "No se encontraron resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Else
                    If cbxTipoIdentificacion.Tag = 1 Then
                        txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                        If (Tabla.Rows(0).Item("Establecimiento")) <> "" Then
                            txtNombre.Text = (Tabla.Rows(0).Item("Nombre")) & " Y/O " & (Tabla.Rows(0).Item("Establecimiento"))
                        End If
                    ElseIf cbxTipoIdentificacion.Tag = 2 Then
                        txtNombre.Text = (Tabla.Rows(0).Item("Nombre"))
                        If (Tabla.Rows(0).Item("Establecimiento")) <> "" Then
                            txtNombre.Text = (Tabla.Rows(0).Item("Nombre")) & " Y/O " & (Tabla.Rows(0).Item("Establecimiento"))
                        End If
                    End If

                    txtTelefonoPer.Text = "809" & (Tabla.Rows(0).Item("Telefono"))
                    txtDireccion.Text = (Tabla.Rows(0).Item("Direccion"))
                End If
            End If

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtTelefonoPer_Leave(sender As Object, e As EventArgs) Handles txtTelefonoPer.Leave
        If Len(txtTelefonoPer.Text) = 8 Then
            txtTelefonoPer.Mask = ""
        End If
        If Len(txtTelefonoPer.Text) = 12 Then
            txtTelefonoPer.Mask = "000-000-0000"
        End If

        If HaveDuplicatesNumbers(txtTelefonoPer.Text, txtTelefonoHog.Text, txtTelefonoTrab.Text, txtTelefonoPat.Text, txtTelefonoConyuge.Text, txtTelefonoPatCony.Text, txtTelefonoGarante.Text, cbxTipoIdentificacion.Tag.ToString) = True Then
            txtTelefonoPer.Focus()
            txtTelefonoPer.SelectAll()
        End If

    End Sub

    Private Sub txtTelefonoHog_TextChanged(sender As Object, e As EventArgs) Handles txtTelefonoHog.TextChanged
        If txtTelefonoHog.Text = "" Then
        Else
            txtTelefonoHog.Mask = "000-000-0000"
            txtTelefonoHog.SelectionStart = 1
        End If
    End Sub

    Private Sub txtTelefonoHog_Leave(sender As Object, e As EventArgs) Handles txtTelefonoHog.Leave
        If Len(txtTelefonoHog.Text) = 8 Then
            txtTelefonoHog.Mask = ""
        End If
        If Len(txtTelefonoHog.Text) = 12 Then
            txtTelefonoHog.Mask = "000-000-0000"
        End If

        If HaveDuplicatesNumbers(txtTelefonoPer.Text, txtTelefonoHog.Text, txtTelefonoTrab.Text, txtTelefonoPat.Text, txtTelefonoConyuge.Text, txtTelefonoPatCony.Text, txtTelefonoGarante.Text, cbxTipoIdentificacion.Tag.ToString) = True Then
            txtTelefonoHog.Focus()
            txtTelefonoHog.SelectAll()
        End If
    End Sub

    Private Sub txtTelefonoPat_TextChanged(sender As Object, e As EventArgs) Handles txtTelefonoPat.TextChanged
        If txtTelefonoPat.Text = "" Then
        Else
            txtTelefonoPat.Mask = "000-000-0000"
            txtTelefonoPat.SelectionStart = 1
        End If
    End Sub

    Private Sub txtTelefonoPat_Leave(sender As Object, e As EventArgs) Handles txtTelefonoPat.Leave
        If Len(txtTelefonoPat.Text) = 8 Then
            txtTelefonoPat.Mask = ""
        End If
        If Len(txtTelefonoPat.Text) = 12 Then
            txtTelefonoPat.Mask = "000-000-0000"
        End If
        If HaveDuplicatesNumbers(txtTelefonoPer.Text, txtTelefonoHog.Text, txtTelefonoTrab.Text, txtTelefonoPat.Text, txtTelefonoConyuge.Text, txtTelefonoPatCony.Text, txtTelefonoGarante.Text, cbxTipoIdentificacion.Tag.ToString) = True Then
            txtTelefonoPat.Focus()
            txtTelefonoPat.SelectAll()
        End If
    End Sub

    Private Sub txtTelefonoTrab_Leave(sender As Object, e As EventArgs) Handles txtTelefonoTrab.Leave
        If Len(txtTelefonoTrab.Text) = 8 Then
            txtTelefonoTrab.Mask = ""
        End If
        If Len(txtTelefonoTrab.Text) = 12 Then
            txtTelefonoTrab.Mask = "000-000-0000"
        End If

        If HaveDuplicatesNumbers(txtTelefonoPer.Text, txtTelefonoHog.Text, txtTelefonoTrab.Text, txtTelefonoPat.Text, txtTelefonoConyuge.Text, txtTelefonoPatCony.Text, txtTelefonoGarante.Text, cbxTipoIdentificacion.Tag.ToString) = True Then
            txtTelefonoTrab.Focus()
            txtTelefonoTrab.SelectAll()
        End If
    End Sub

    Private Sub txtTelefonoTrab_TextChanged(sender As Object, e As EventArgs) Handles txtTelefonoTrab.TextChanged
        If txtTelefonoTrab.Text = "" Then
        Else
            txtTelefonoTrab.Mask = "000-000-0000"
            txtTelefonoTrab.SelectionStart = 1
        End If
    End Sub

    Private Sub txtTelefonoConyuge_TextChanged(sender As Object, e As EventArgs) Handles txtTelefonoConyuge.TextChanged
        If txtTelefonoConyuge.Text = "" Then
        Else
            txtTelefonoConyuge.Mask = "000-000-0000"
            txtTelefonoConyuge.SelectionStart = 1
        End If
    End Sub

    Private Sub txtTelefonoConyuge_Leave(sender As Object, e As EventArgs) Handles txtTelefonoConyuge.Leave
        If Len(txtTelefonoConyuge.Text) = 8 Then
            txtTelefonoConyuge.Mask = ""
        End If
        If Len(txtTelefonoConyuge.Text) = 12 Then
            txtTelefonoConyuge.Mask = "000-000-0000"
        End If

        If HaveDuplicatesNumbers(txtTelefonoPer.Text, txtTelefonoHog.Text, txtTelefonoTrab.Text, txtTelefonoPat.Text, txtTelefonoConyuge.Text, txtTelefonoPatCony.Text, txtTelefonoGarante.Text, cbxTipoIdentificacion.Tag.ToString) = True Then
            txtTelefonoConyuge.Focus()
            txtTelefonoConyuge.SelectAll()
        End If

    End Sub

    Private Sub txtTelefonoPatCony_TextChanged(sender As Object, e As EventArgs) Handles txtTelefonoPatCony.TextChanged
        If txtTelefonoPatCony.Text = "" Then
        Else
            txtTelefonoPatCony.Mask = "000-000-0000"
            txtTelefonoPatCony.SelectionStart = 1
        End If
    End Sub

    Private Sub txtTelefonoPatCony_Leave(sender As Object, e As EventArgs) Handles txtTelefonoPatCony.Leave
        If Len(txtTelefonoPatCony.Text) = 8 Then
            txtTelefonoPatCony.Mask = ""
        End If
        If Len(txtTelefonoPatCony.Text) = 12 Then
            txtTelefonoPatCony.Mask = "000-000-0000"
        End If

        If HaveDuplicatesNumbers(txtTelefonoPer.Text, txtTelefonoHog.Text, txtTelefonoTrab.Text, txtTelefonoPat.Text, txtTelefonoConyuge.Text, txtTelefonoPatCony.Text, txtTelefonoGarante.Text, cbxTipoIdentificacion.Tag.ToString) = True Then
            txtTelefonoPatCony.Focus()
            txtTelefonoPatCony.SelectAll()
        End If

    End Sub

    Private Sub OpenMantRef_btn_Click(sender As Object, e As EventArgs) Handles OpenMantRef_btn.Click

        If txtIDCliente.Text = "" Then
            MessageBox.Show("No se han guardado los datos del cliente a la base de datos. Por favor guarde el registro.", "No se encontró cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            If btnGuardar.Enabled = True Then
                btnGuardar.PerformClick()
                frm_mant_referencias.txtIDCliente.Text = txtIDCliente.Text
                frm_mant_referencias.txtNombre.Text = txtNombre.Text
                frm_mant_referencias.txtCedula.Text = txtIdentificacion.Text
                frm_mant_referencias.ShowDialog(Me)
            End If

        Else
            frm_mant_referencias.txtIDCliente.Text = txtIDCliente.Text
            frm_mant_referencias.txtNombre.Text = txtNombre.Text
            frm_mant_referencias.txtCedula.Text = txtIdentificacion.Text
            frm_mant_referencias.ShowDialog(Me)
        End If

    End Sub

    Private Sub UltCliente()
        If txtIDCliente.Text = "" Then
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDCliente from Clientes where IDCliente= (Select Max(IDCliente) from Clientes)", ConLibregco)
            txtIDCliente.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If LastIDCliente.Text = txtIDCliente.Text Then
                If Con.State = ConnectionState.Open Then
                    Con.Close()
                End If
                If ConMixta.State = ConnectionState.Open Then
                    ConMixta.Close()
                End If
                If ConLibregco.State = ConnectionState.Open Then
                    ConLibregco.Close()
                End If

                lblStatusBar.ForeColor = Color.Red
                lblStatusBar.Text = "Reintentando guardar el cliente..."

                ConLibregco.Open()
                cmd = New MySqlCommand("INSERT INTO Libregco.Clientes (IDTratamiento,Nombre,Apodo,IDTipoIdentificacion,IDNacionalidad,Identificacion,IDGenero,FechaNacimiento,LugarNacimiento,IDProvincia,IDMunicipio,Direccion,Referencia,TelefonoPersonal,TelefonoHogar,CorreoElectronico,Sueldo,Vivienda,NumeroTiempoAlquilado,TiempoAlquilado,TipoVivienda,Vehiculo,TrabajoActivo,TrabajoCantTiempoLaborando,TrabajoTiempoLaborando,SeguroMedico,CuentasBancaria,EntidadBancariaCuenta,Tarjeta,EntidadBancariaTarjeta,IDOcupacion,LugarTrabajo,UbicacionTrabajo,TelefonoTrabajo,DedicacionAutoEmpleado,OrigenPagos,PadreCliente,MadreCliente,DomicilioPaternos,TelefonoPaternos,IDCivil,Conyuge,TelefonoConyuge,IDOcupacionConyuge,LugarTrabajoConyuge,PadreConyuge,MadreConyuge,DomicilioPatConyuge,TelefonoPatConyuge,IDGrupoCxc,IDTipoCredito,IDCalificacion,CalificacionAutonoma,xCore,DiasCondicion,IDComprobanteFiscal,IDCondicionCliente,Precio,IDEmpleado,IDEmpleadoSub,InformacionAdc,Alertas,FechaIngreso,NoRecibirCheques,CuentaIncobrable,GenerarCargo,CerrarCredito,EntregarporConduce,BloqueoCobrador,BalanceGeneral,Desactivar,BalanceGeneralLetras,Locacion,CreditoAnterior,ReferenciaComercial1,ReferenciaComercial2,Garante,GaranteNombre,TipoIdentificacionGarante,IdentificacionGarante,DireccionGarante,TelefonoGarante,IDRegistrador,IDUsuarioModificador,ContactoCompras,TelContactoCompras,ExtCompras,ContactoCXC,TelContactoCXC,ExtCXC,IDVendedorCliente,LimiteCredito,LiberarControles) VALUES ('" + CbxTratamiento.Tag.ToString + "','" + txtNombre.Text + "','" + txtApodo.Text + "', '" + cbxTipoIdentificacion.Tag.ToString + "','" + cbxNacionalidad.Tag.ToString + "','" + txtIdentificacion.Text + "', '" + cbxGenero.Tag.ToString + "', '" + TxtFechaNacimiento.Text + "','" + txtLugarNacimiento.Text + "','" + cbxProvincia.Tag.ToString + "', '" + cbxMunicipio.Tag.ToString + "','" + txtDireccion.Text + "','" + txtReferencia.Text + "','" + txtTelefonoPer.Text + "','" + txtTelefonoHog.Text + "', '" + txtCorreoElec.Text + "', '" + CDbl(txtSueldo.Text).ToString + "','" + lblChkVivienda.Text + "','" + txtTiempoAlquiler.Text + "','" + cbxTiempoAlquier.Text + "','" + lblTipoVivienda.Text + "','" + lblchkVehiculo.Text + "','" + lblchkTrabajo.Text + "','" + txtCantNumLaborando.Text + "','" + cbxTiempoLaborando.Text + "','" + lblchkSeguro.Text + "','" + ckhCuentasBancarias.Tag.ToString + "','" + txtEntidadCuentaBancaria.Text + "','" + lblchkTarjetas.Text + "','" + txtEntidadTarjeta.Text + "','" + cbxOcupacion.Tag.ToString + "', '" + txtLugarTrabajo.Text + "', '" + txtUbicacionTrabajo.Text + "', '" + txtTelefonoTrab.Text + "','" + txtOcupacionAutoEmpleado.Text + "' ,'" + txtOrigenPagos.Text + "','" + txtPadre.Text + "', '" + txtMadre.Text + "','" + txtDomicilioPat.Text + "', '" + txtTelefonoPat.Text + "', '" + cbxEstadoCivil.Tag.ToString + "', '" + txtNombreConyuge.Text + "', '" + txtTelefonoConyuge.Text + "', '" + cbxOcupacionConyuge.Tag.ToString + "', '" + txtLugarTrabajoCony.Text + "', '" + txtPadreConyuge.Text + "', '" + txtMadreConyuge.Text + "','" + txtDomicilioPatCony.Text + "', '" + txtTelefonoPatCony.Text + "','" + txtIDGrupoCxc.Text + "','" + txtIDTipoCredito.Text + "','" + cbxCalificacion.Tag.ToString + "','" + txtCalificacionAutonoma.Text + "','" + txtXCore.Text + "','" + txtCondicionDias.Text + "', '" + cbxTipoComprobante.Tag.ToString + "','" + cbxCondicion.Tag.ToString + "','" + txtPrecio.Text + "','" + cbxCobrador.Tag.ToString + "','" + cbxSubCobrador.Tag.ToString + "','" + txtInfoAdicional.Text + "','" + txtAlerta.Text + "','" + txtFechaIngreso.Text + "','" + chkNoRecibirCheques.Tag.ToString + "','" + chkCuentaIncobrable.Tag.ToString + "','" + chkGenerarCargos.Tag.ToString + "','" + chkCerrarCredito.Tag.ToString + "','" + chkEntregarporConduce.Tag.ToString + "','" + chkBloqueoCobrador.Tag.ToString + "','0','" + chkDesactivarCliente.Tag.ToString + "','','','" + lblCreditosAnteriores.Text + "','" + txtReferenciaComercial1.Text + "','" + txtReferenciaComercial2.Text + "','" + lblGarante.Text + "','" + txtNombreGarante.Text + "','" + cbxTipoIdentificacionGarante.Text + "','" + txtIdentificacionGarante.Text + "','" + txtDireccionGarante.Text + "','" + txtTelefonoGarante.Text + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "','" + txtEncargadoCompras.Text + "','" + txtContactoTelCompras.Text + "','" + txtContactoTelComprasExt.Text + "','" + txtEncargadoCXC.Text + "','" + txtContactoTelCXC.Text + "','" + txtExtEncargadoCXC.Text + "','" + cbxVendedor.Tag.ToString + "',0,'" + Convert.ToInt16(chkLiberarControles.Checked).ToString + "')", ConLibregco)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("Select IDCliente from Clientes where IDCliente= (Select Max(IDCliente) from Clientes)", ConLibregco)
                txtIDCliente.Text = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()

                If txtIDCliente.Text = LastIDCliente.Text Then
                    MessageBox.Show("No se ha podido guardar el cliente. Verifique la comunicación con el servidor para poder guardar la factura.")
                    Application.Exit()
                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End If
    End Sub

    Private Sub TxtFechaNacimiento_TextChanged(sender As Object, e As EventArgs) Handles TxtFechaNacimiento.TextChanged
        If TxtFechaNacimiento.Text = "" Then
        Else
            TxtFechaNacimiento.Mask = "00/00/0000"
            TxtFechaNacimiento.SelectionStart = 1
        End If
    End Sub

    Private Sub TxtFechaNacimiento_Leave(sender As Object, e As EventArgs) Handles TxtFechaNacimiento.Leave
        If Len(TxtFechaNacimiento.Text) < 10 Then
            TxtFechaNacimiento.Mask = ""
            txtEdad.Text = ""
        Else
            If IsDate(TxtFechaNacimiento.Text) Then
                TxtFechaNacimiento.Mask = "00/00/0000"
            Else
                TxtFechaNacimiento.Mask = ""
                txtEdad.Text = ""
            End If
        End If

        If IsDate(TxtFechaNacimiento.Text) Then
            If CDate(TxtFechaNacimiento.Text) > Today Then
                MessageBox.Show("La fecha de nacimiento no es válida.", "Fecha ha excedido el rango", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                TxtFechaNacimiento.Text = ""
                TxtFechaNacimiento.Mask = ""
            End If
        End If

        CalcEdad()
    End Sub

    Private Sub chkDesactivarCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesactivarCliente.CheckedChanged
        If chkDesactivarCliente.Checked = True Then
            chkDesactivarCliente.Tag = 1
            DeshabilitarCliente()
        Else
            chkDesactivarCliente.Tag = 0
            HabilitarCliente()
        End If
    End Sub

    Sub DeshabilitarCliente()
        CbxTratamiento.Enabled = False
        txtIDCliente.Enabled = False
        txtNombre.Enabled = False
        txtApodo.Enabled = False
        cbxNacionalidad.Enabled = False
        txtIdentificacion.Enabled = False
        cbxGenero.Enabled = False
        TxtFechaNacimiento.Enabled = False
        txtEdad.Enabled = False
        txtLugarNacimiento.Enabled = False
        cbxProvincia.Enabled = False
        cbxMunicipio.Enabled = False
        txtDireccion.Enabled = False
        txtReferencia.Enabled = False
        txtTelefonoPer.Enabled = False
        txtTelefonoHog.Enabled = False
        txtCorreoElec.Enabled = False
        cbxOcupacion.Enabled = False
        txtLugarTrabajo.Enabled = False
        txtUbicacionTrabajo.Enabled = False
        txtTelefonoTrab.Enabled = False
        txtPadre.Enabled = False
        txtMadre.Enabled = False
        txtDomicilioPat.Enabled = False
        txtTelefonoPat.Enabled = False
        cbxEstadoCivil.Enabled = False
        txtNombreConyuge.Enabled = False
        txtTelefonoConyuge.Enabled = False
        cbxOcupacionConyuge.Enabled = False
        txtLugarTrabajoCony.Enabled = False
        txtPadreConyuge.Enabled = False
        txtMadreConyuge.Enabled = False
        txtDomicilioPatCony.Enabled = False
        txtTelefonoPatCony.Enabled = False
        cbxCalificacion.Enabled = False
        cbxTipoComprobante.Enabled = False
        cbxCobrador.Enabled = False
        txtInfoAdicional.Enabled = False
        chkNoRecibirCheques.Enabled = False
        chkCuentaIncobrable.Enabled = False
        chkCerrarCredito.Enabled = False
        chkGenerarCargos.Enabled = False
        DgvReferencias.Enabled = False
        OpenMantRef_btn.Enabled = False
        cbxTipoIdentificacion.Enabled = False
        DgvRutasAnexas.Enabled = False
        Acciones.Enabled = False
        chkEntregarporConduce.Enabled = False
        txtAlerta.Enabled = False
        txtCondicionDias.Enabled = False
        chkBloqueoCobrador.Enabled = False
        'chkVivienda.Enabled = False
        'chkVehiculos.Enabled = False
        'chkTrabajoActivo.Enabled = False
        'chkSeguroMedico.Enabled = False
        ckhCuentasBancarias.Enabled = False
        chkTarjetasCredito.Enabled = False
        txtSueldo.Enabled = False
        txtPrecio.Enabled = False
    End Sub

    Private Sub HabilitarCliente()
        CbxTratamiento.Enabled = True
        cbxTipoIdentificacion.Enabled = True
        txtIDCliente.Enabled = True
        txtNombre.Enabled = True
        txtApodo.Enabled = True
        cbxNacionalidad.Enabled = True
        txtIdentificacion.Enabled = True
        cbxGenero.Enabled = True
        TxtFechaNacimiento.Enabled = True
        txtLugarNacimiento.Enabled = True
        cbxProvincia.Enabled = True
        cbxMunicipio.Enabled = True
        txtDireccion.Enabled = True
        txtReferencia.Enabled = True
        txtTelefonoPer.Enabled = True
        txtTelefonoHog.Enabled = True
        txtCorreoElec.Enabled = True
        cbxOcupacion.Enabled = True
        txtLugarTrabajo.Enabled = True
        txtUbicacionTrabajo.Enabled = True
        txtTelefonoTrab.Enabled = True
        txtPadre.Enabled = True
        txtMadre.Enabled = True
        txtDomicilioPat.Enabled = True
        txtTelefonoPat.Enabled = True
        cbxEstadoCivil.Enabled = True
        txtNombreConyuge.Enabled = True
        txtTelefonoConyuge.Enabled = True
        cbxOcupacionConyuge.Enabled = True
        txtLugarTrabajoCony.Enabled = True
        txtPadreConyuge.Enabled = True
        txtMadreConyuge.Enabled = True
        txtDomicilioPatCony.Enabled = True
        txtTelefonoPatCony.Enabled = True
        cbxCalificacion.Enabled = True
        cbxCobrador.Enabled = True
        txtInfoAdicional.Enabled = True
        chkNoRecibirCheques.Enabled = True
        chkCuentaIncobrable.Enabled = True
        chkCerrarCredito.Enabled = True
        cbxTipoComprobante.Enabled = True
        chkGenerarCargos.Enabled = True
        DgvReferencias.Enabled = True
        OpenMantRef_btn.Enabled = True
        DgvRutasAnexas.Enabled = True
        Acciones.Enabled = True
        chkEntregarporConduce.Enabled = True
        chkBloqueoCobrador.Enabled = True
        txtAlerta.Enabled = True
        txtCondicionDias.Enabled = True
        'chkVivienda.Enabled = True
        'chkVehiculos.Enabled = True
        'chkTrabajoActivo.Enabled = True
        'chkSeguroMedico.Enabled = True
        ckhCuentasBancarias.Enabled = True
        chkTarjetasCredito.Enabled = True
        txtSueldo.Enabled = True
        txtPrecio.Enabled = True
    End Sub

    Private Sub btnConsultarRNC_Click(sender As Object, e As EventArgs) Handles btnConsultarRNC.Click
        frm_consulta_rnc.ShowDialog(Me)
    End Sub

    Private Sub BuscarRNCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarRNCToolStripMenuItem.Click
        frm_consulta_rnc.ShowDialog(Me)
    End Sub

    Private Sub cbxTipoIdentificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoIdentificacion.SelectedIndexChanged
        SetIDTipoIdentificacion()
    End Sub

    Private Sub SigTo1_Click(sender As Object, e As EventArgs) Handles SigTo1.Click
        tbcClientes.SelectedIndex = 1
    End Sub

    Private Sub SigTo2_Click(sender As Object, e As EventArgs) Handles SigTo2.Click
        tbcClientes.SelectedIndex = 2
    End Sub

    Private Sub SigTo3_Click(sender As Object, e As EventArgs) Handles SigTo3.Click
        tbcClientes.SelectedIndex = 3
    End Sub

    Private Sub SigTo4_Click(sender As Object, e As EventArgs) Handles SigTo4.Click
        tbcClientes.SelectedIndex = 4
    End Sub

    Private Sub SigTo5_Click(sender As Object, e As EventArgs) Handles SigTo5.Click
        tbcClientes.SelectedIndex = 5
    End Sub

    Private Sub SigTo6_Click(sender As Object, e As EventArgs) Handles SigTo6.Click
        tbcClientes.SelectedIndex = 6
    End Sub

    Private Sub AntTo5_Click(sender As Object, e As EventArgs) Handles AntTo5.Click
        tbcClientes.SelectedIndex = 5
    End Sub

    Private Sub AntTo4_Click(sender As Object, e As EventArgs) Handles AntTo4.Click
        tbcClientes.SelectedIndex = 4
    End Sub

    Private Sub AntTo3_Click(sender As Object, e As EventArgs) Handles AntTo3.Click
        tbcClientes.SelectedIndex = 3
    End Sub

    Private Sub AntTo2_Click(sender As Object, e As EventArgs) Handles AntTo2.Click
        tbcClientes.SelectedIndex = 2
    End Sub

    Private Sub AntTo1_Click(sender As Object, e As EventArgs) Handles AntTo1.Click
        tbcClientes.SelectedIndex = 1
    End Sub

    Private Sub AntTo0_Click(sender As Object, e As EventArgs) Handles AntTo0.Click
        tbcClientes.SelectedIndex = 0
    End Sub

    Private Sub chkGenerarCargos_CheckedChanged(sender As Object, e As EventArgs) Handles chkGenerarCargos.CheckedChanged
        If chkGenerarCargos.Checked = True Then
            chkGenerarCargos.Tag = 1
        Else
            chkGenerarCargos.Tag = 0
        End If
    End Sub

    Private Sub DgvRutasAnexas_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvRutasAnexas.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvRutasAnexas.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvRutasAnexas.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvRutasAnexas.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub btnEscanear_Click(sender As Object, e As EventArgs) Handles btnEscanear.Click
        Try
            If TypeConnection.Text = 1 Then
                Dim FileLocation, RandomValue As String
                Dim CD As New WIA.CommonDialog
                Dim F As WIA.ImageFile = CD.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType)
                Dim FileName As String = Today.ToString("ddMMyyyy") & TimeOfDay.ToString("hhmmss")

                If IsNothing(F) Then
                Else
                    FileLocation = Path.GetTempPath & FileName & "." & F.FileExtension
                    F.SaveFile(FileLocation)

                    DgvRutasAnexas.Rows.Add("", "", "", FileLocation, "", GetFileSizes(FileLocation))
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Se ha producido un error debido a que la estructura de esta función solo está disponible para arquitecturas x32 bits.", "Error en aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnBuscarDoc_Click(sender As Object, e As EventArgs) Handles btnBuscarDoc.Click
        Dim OfdRutaFoto As New OpenFileDialog
        Dim wFile As System.IO.FileStream

        OfdRutaFoto.Title = ("Seleccionar Documentos")
        OfdRutaFoto.Multiselect = True
        OfdRutaFoto.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
        OfdRutaFoto.FileName = ""
        OfdRutaFoto.RestoreDirectory = True

        If OfdRutaFoto.ShowDialog = Windows.Forms.DialogResult.OK Then

            For Each itm In OfdRutaFoto.FileNames
                wFile = New FileStream(itm, FileMode.Open, FileAccess.Read)
                DgvRutasAnexas.Rows.Add("", "", "", itm, "", GetFileSizes(itm), System.Drawing.Image.FromStream(wFile))
            Next

            wFile.Close()
            lblStatusBar.Text = "Se han anexado : " & DgvRutasAnexas.Rows.Count & " Registro(s)"
        End If


    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        Dim RutaDestino As String
        Dim Exists As Boolean

        Cursor.Current = Cursors.WaitCursor

        If DgvRutasAnexas.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran rutas para abrir documentos.", "No se encontraron rutas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            RutaDestino = DgvRutasAnexas.CurrentRow.Cells(3).Value

            Exists = System.IO.File.Exists(RutaDestino)

            If Exists = False Then
                MessageBox.Show("El archivo específicado en la ruta " & RutaDestino & " se ha modificado o eliminado.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                DgvRutasAnexas.Rows.Remove(DgvRutasAnexas.CurrentRow)
            Else
                System.Diagnostics.Process.Start(RutaDestino)
            End If
        End If

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnImprimirDoc_Click(ByVal ender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirDoc.Click
        Dim RutaDestino As String
        Dim Exists As Boolean

        Try

            If DgvRutasAnexas.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran rutas para imprimir.", "No se encontraron rutas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                RutaDestino = DgvRutasAnexas.CurrentRow.Cells(3).Value

                Exists = System.IO.File.Exists(RutaDestino)

                If Exists = False Then
                    MessageBox.Show("El archivo específicado en la ruta " & RutaDestino & " se ha modificado o eliminado.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    DgvRutasAnexas.Rows.Remove(DgvRutasAnexas.CurrentRow)
                Else

                    If Me.PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Try
                            AddHandler Me.PrintDocument1.PrintPage,
                                AddressOf Me.GraphicsPrint
                            Me.PrintDocument1.Print()


                        Catch ex As Exception
                            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
                        End Try
                    End If

                End If
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub GraphicsPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        If TypeConnection.Text = 1 Then
            Dim RutaDestino As String = DgvRutasAnexas.CurrentRow.Cells(3).Value
            Dim ImagePrint As Image = Image.FromFile(RutaDestino, True)
            e.Graphics.DrawImage(ImagePrint, 50, 50, ImagePrint.Width, ImagePrint.Height)
            e.HasMorePages = False

        End If

    End Sub

    Private Sub EscanearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EscanearToolStripMenuItem.Click
        btnEscanear.PerformClick()
    End Sub

    Private Sub BuscarDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarDocumentoToolStripMenuItem.Click
        btnBuscarDoc.PerformClick()
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        btnAbrir.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If txtIDCliente.Text = "" Then
            If txtNombre.Text <> "" Or txtDireccion.Text <> "" Or Replace(txtIdentificacion.Text, "-", "") <> "" Or DgvRutasAnexas.Rows.Count > 0 Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado campos llenos." & vbNewLine & vbNewLine & "Está seguro que desea limpiar el formulario de mantenimiento de clientes?", "Nuevo registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    LimpiarDatosCliente()
                    ActualizarTodo()
                End If
            Else
                LimpiarDatosCliente()
                ActualizarTodo()
            End If
        Else
            LimpiarDatosCliente()
            ActualizarTodo()
        End If
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            ConLibregco.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=30", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            ConLibregco.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)

            ConLibregco.Open()

            sqlQ = "UPDATE Clientes SET SecondID='" + lblSecondID.Text + "' WHERE IDCliente='" + txtIDCliente.Text + "'"
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()


            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=30"
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()

            ConLibregco.Close()

        Catch ex As Exception

        End Try
    End Sub

    Function VerificarEdad(ByVal dDesde As Date, ByVal dHasta As Date)
        Dim iAnoDesde As Integer = dDesde.Year
        Dim iAnoHasta As Integer = dHasta.Year
        Dim iMesDesde As Integer = dDesde.Month
        Dim iMesHasta As Integer = dHasta.Month
        Dim iDiaDesde As Integer = dDesde.Day
        Dim iDiaHasta As Integer = dHasta.Day
        Dim Años, Meses, Dias As Integer

        If (iDiaHasta < iDiaDesde) Then
            iDiaHasta = iDiaHasta + 30
            iMesHasta = iMesHasta - 1
        End If

        Dias = iDiaHasta - iDiaDesde

        If (iMesHasta < iMesDesde) Then
            iMesHasta = iMesHasta + 12
            iAnoHasta = iAnoHasta - 1
        End If

        Meses = iMesHasta - iMesDesde
        Años = iAnoHasta - iAnoDesde

        Return Años
    End Function

    Private Sub CheckLimitedeCredito()
        Con.Open()
        'Get Date of TODAY
        cmd = New MySqlCommand("select curdate()", Con)
        Dim TodayIS As Date = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If CDate(txtFechaIngreso.Text) <> TodayIS Then

            For Each rw As DataRow In TablaBalances.Rows
                'Establezco el limite anterior en la base de datos

                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT LimiteCredito FROM libregco.clientes_balances where idClientes_Balances='" + rw.Item("IDClientes_Balance").ToString + "'", ConLibregco)
                Dim LimiteAnterior As Double = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()

                'Hago la comparacion
                If CDbl(rw.Item("Limite")) > LimiteAnterior Then

                    'If Not AccionesModulosAutorizadas.Contains("106") Then
                    MessageBox.Show("Se ha(n) detectado cambios en el límite de crédito en la moneda " & vbNewLine & "(" & rw.Item("Moneda") & ").")

                    ControlSuperClave = 1
                    frm_superclave.IDAccion.Text = 106
                    frm_superclave.ShowDialog(Me)
                    'Else
                    '    ControlSuperClave = 0
                    'End If

                    If ControlSuperClave = 0 Then
                    Else
                        rw.Item("Limite") = CDbl(LimiteAnterior)
                    End If

                End If
            Next

        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_clientes.ShowDialog(Me)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("El formulario está vacío por lo que no se pueden modificar el registro de la base de datos.", "No hay información para anular", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If chkDesactivarCliente.Checked = True Then
                Dim Result1 As MsgBoxResult = MessageBox.Show("El cliente " & txtNombre.Text & "  ya está desactivado del sistema. Desea volver a activarlo?", "Activar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then

                    If txtNombre.Text = "" Then
                        MessageBox.Show("El nombre del cliente se encuentra vacío." & vbNewLine & vbNewLine & "Escriba el nombre del cliente para procesar el registro.", "Escriba el nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 0
                        txtNombre.Focus()
                        Exit Sub
                    ElseIf cbxTipoIdentificacion.Text = "" Then
                        MessageBox.Show("Seleccione un tipo de documento/identificación para el cliente: " & vbNewLine & vbNewLine & txtNombre.Text, "Seleccione el tipo de documento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 0
                        cbxTipoIdentificacion.Focus()
                        cbxTipoIdentificacion.DroppedDown = True
                        Exit Sub
                    ElseIf cbxGenero.Text = "" Then
                        MessageBox.Show("Seleccione el género correspondiente al cliente.", "Seleccione el género", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 0
                        cbxGenero.Focus()
                        cbxGenero.DroppedDown = True
                        Exit Sub
                    ElseIf cbxNacionalidad.Text = "" Then
                        MessageBox.Show("Seleccione la nacionalidad correspondiente al cliente.", "Seleccione la nacionalidad", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 0
                        cbxNacionalidad.Focus()
                        cbxNacionalidad.DroppedDown = True
                        Exit Sub
                    ElseIf cbxProvincia.Text = "" Then
                        MessageBox.Show("Seleccione la provincia correspondiente del cliente.", "Seleccione la provincia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 0
                        cbxProvincia.Focus()
                        cbxProvincia.DroppedDown = True
                        Exit Sub
                    ElseIf cbxMunicipio.Text = "" Then
                        MessageBox.Show("Seleccione el municipio correspondiente al cliente.", "Seleccione el municipio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 0
                        cbxMunicipio.Focus()
                        cbxMunicipio.DroppedDown = True
                        Exit Sub
                    ElseIf txtIDGrupoCxc.Text = "" Then
                        MessageBox.Show("Seleccione el grupo de cuentas por cobrar correspondiente al cliente.", "Seleccione el grupo de cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 4
                        btnBuscarGrupoCxc.Focus()
                        Exit Sub
                    ElseIf txtIDTipoCredito.Text = "" Then
                        MessageBox.Show("Seleccione el tipo de crédito correspondiente al cliente.", "Seleccione el tipo de crédito a otorgar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 4
                        btnBuscarTipoCredito.Focus()
                        Exit Sub
                    ElseIf cbxCobrador.Text = "" Then
                        MessageBox.Show("Seleccione el cobrador correspondiente al cliente.", "Seleccione el cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 4
                        cbxCobrador.Focus()
                        cbxCobrador.DroppedDown = True
                        Exit Sub
                    ElseIf cbxTipoComprobante.Text = "" Then
                        MessageBox.Show("Seleccione el tipo de comprobante fiscal correspondiente al cliente.", "Seleccione el tipo de NCF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 4
                        cbxTipoComprobante.Focus()
                        cbxTipoComprobante.DroppedDown = True
                        Exit Sub
                    ElseIf cbxCondicion.Text = "" Then
                        MessageBox.Show("Seleccione el tipo de condición de venta correspondiente al cliente.", "Seleccione la condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 5
                        cbxCondicion.Focus()
                        cbxCondicion.DroppedDown = True
                        Exit Sub
                    ElseIf txtPrecio.Text = "" Then
                        MessageBox.Show("Seleccione el nivel de precio a asignar al cliente.", "Seleccionar nivel de precios", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        txtPrecio.Focus()
                        txtPrecio.DroppedDown = True
                        Exit Sub
                    End If

                    chkDesactivarCliente.Checked = False

                    sqlQ = "UPDATE Libregco.Clientes SET IDTratamiento='" + CbxTratamiento.Tag.ToString + "',Nombre='" + txtNombre.Text + "',Apodo='" + txtApodo.Text + "',IDNacionalidad='" + cbxNacionalidad.Tag.ToString + "',IDTipoIdentificacion='" + cbxTipoIdentificacion.Tag.ToString + "',Identificacion='" + txtIdentificacion.Text + "',IDGenero='" + cbxGenero.Tag.ToString + "',FechaNacimiento='" + TxtFechaNacimiento.Text + "',LugarNacimiento='" + txtLugarNacimiento.Text + "',IDProvincia='" + cbxProvincia.Tag.ToString + "',IDMunicipio='" + cbxMunicipio.Tag.ToString + "',Direccion='" + txtDireccion.Text + "',Referencia='" + txtReferencia.Text + "',TelefonoPersonal='" + txtTelefonoPer.Text + "',TelefonoHogar='" + txtTelefonoHog.Text + "',CorreoElectronico='" + txtCorreoElec.Text + "',Vehiculo='" + lblchkVehiculo.Text + "',Vivienda='" + lblChkVivienda.Text + "',NumeroTiempoAlquilado='" + txtTiempoAlquiler.Text + "',TiempoAlquilado='" + cbxTiempoAlquier.Text + "',TipoVivienda='" + lblTipoVivienda.Text + "',TrabajoActivo='" + lblchkTrabajo.Text + "',TrabajoCantTiempoLaborando='" + txtCantNumLaborando.Text + "',TrabajoTiempoLaborando='" + cbxTiempoLaborando.Text + "',SeguroMedico='" + lblchkSeguro.Text + "',CuentasBancaria='" + ckhCuentasBancarias.Tag.ToString + "',EntidadBancariaCuenta='" + txtEntidadCuentaBancaria.Text + "',Tarjeta='" + lblchkTarjetas.Text + "',EntidadBancariaTarjeta='" + txtEntidadTarjeta.Text + "',Sueldo='" + CDbl(txtSueldo.Text).ToString + "',IDOcupacion='" + cbxOcupacion.Tag.ToString + "',LugarTrabajo='" + txtLugarTrabajo.Text + "',UbicacionTrabajo='" + txtUbicacionTrabajo.Text + "',TelefonoTrabajo='" + txtTelefonoTrab.Text + "',DedicacionAutoEmpleado='" + txtOcupacionAutoEmpleado.Text + "',OrigenPagos='" + txtOrigenPagos.Text + "',PadreCliente='" + txtPadre.Text + "',MadreCliente='" + txtMadre.Text + "',DomicilioPaternos='" + txtDomicilioPat.Text + "',TelefonoPaternos='" + txtTelefonoPat.Text + "',IDCivil='" + cbxEstadoCivil.Tag.ToString + "',Conyuge='" + txtNombreConyuge.Text + "',TelefonoConyuge='" + txtTelefonoConyuge.Text + "',IDOcupacionConyuge='" + cbxOcupacionConyuge.Tag.ToString + "',LugarTrabajoConyuge='" + txtLugarTrabajoCony.Text + "',PadreConyuge='" + txtPadreConyuge.Text + "',MadreConyuge='" + txtMadreConyuge.Text + "',DomicilioPatConyuge='" + txtDomicilioPatCony.Text + "',TelefonoPatConyuge='" + txtTelefonoPatCony.Text + "',IDCalificacion='" + cbxCalificacion.Tag.ToString + "',CalificacionAutonoma='" + txtCalificacionAutonoma.Text + "',xCore='" + txtXCore.Text + "',DiasCondicion='" + txtCondicionDias.Text + "',IDGrupoCXC='" + txtIDGrupoCxc.Text + "',InformacionAdc='" + txtInfoAdicional.Text + "',IDTipoCredito='" + txtIDTipoCredito.Text + "',IDEmpleado='" + cbxCobrador.Tag.ToString + "',IDEmpleadoSub='" + cbxSubCobrador.Tag.ToString + "',IDComprobanteFiscal='" + cbxTipoComprobante.Tag.ToString + "',IDCondicionCliente='" + cbxCondicion.Tag.ToString + "',Precio='" + txtPrecio.Text + "',Alertas='" + txtAlerta.Text + "',NoRecibirCheques='" + chkNoRecibirCheques.Tag.ToString + "',CuentaIncobrable='" + chkCuentaIncobrable.Tag.ToString + "',GenerarCargo='" + chkGenerarCargos.Tag.ToString + "',CerrarCredito='" + chkCerrarCredito.Tag.ToString + "',EntregarPorConduce='" + chkEntregarporConduce.Tag.ToString + "',BloqueoCobrador='" + chkBloqueoCobrador.Tag.ToString + "',Desactivar='" + chkDesactivarCliente.Tag.ToString + "',Locacion='',CreditoAnterior='" + lblCreditosAnteriores.Text + "',ReferenciaComercial1='" + txtReferenciaComercial1.Text + "',ReferenciaComercial2='" + txtReferenciaComercial2.Text + "',Garante='" + lblGarante.Text + "',GaranteNombre='" + txtNombreGarante.Text + "',TipoIdentificacionGarante='" + cbxTipoIdentificacionGarante.Text + "',IdentificacionGarante='" + txtIdentificacionGarante.Text + "',DireccionGarante='" + txtDireccionGarante.Text + "',TelefonoGarante='" + txtTelefonoGarante.Text + "',IDUsuarioModificador='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDVendedorCliente='" + cbxVendedor.Tag.ToString + "' WHERE IDCliente= (" + txtIDCliente.Text + ")"
                    GuardarDatos()
                    InsertDocumentos()
                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))
                End If

            Else


                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT sum(Balance) FROM libregco.clientes_balances where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
                Dim MontosDisponibles As Double = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()

                If MontosDisponibles > 0 Then
                    MessageBox.Show("No es posible anular el registro del cliente " & txtNombre.Text & " ya que posee balances pendientes.", "El cliente posee balances pendientes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea desactivar el registro del cliente " & txtNombre.Text & " del sistema?", "Desactivar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    chkDesactivarCliente.Checked = True
                    sqlQ = "UPDATE Libregco.Clientes SET IDTratamiento='" + CbxTratamiento.Tag.ToString + "',Nombre='" + txtNombre.Text + "',Apodo='" + txtApodo.Text + "',IDNacionalidad='" + cbxNacionalidad.Tag.ToString + "',IDTipoIdentificacion='" + cbxTipoIdentificacion.Tag.ToString + "',Identificacion='" + txtIdentificacion.Text + "',IDGenero='" + cbxGenero.Tag.ToString + "',FechaNacimiento='" + TxtFechaNacimiento.Text + "',LugarNacimiento='" + txtLugarNacimiento.Text + "',IDProvincia='" + cbxProvincia.Tag.ToString + "',IDMunicipio='" + cbxMunicipio.Tag.ToString + "',Direccion='" + txtDireccion.Text + "',Referencia='" + txtReferencia.Text + "',TelefonoPersonal='" + txtTelefonoPer.Text + "',TelefonoHogar='" + txtTelefonoHog.Text + "',CorreoElectronico='" + txtCorreoElec.Text + "',Vehiculo='" + lblchkVehiculo.Text + "',Vivienda='" + lblChkVivienda.Text + "',NumeroTiempoAlquilado='" + txtTiempoAlquiler.Text + "',TiempoAlquilado='" + cbxTiempoAlquier.Text + "',TipoVivienda='" + lblTipoVivienda.Text + "',TrabajoActivo='" + lblchkTrabajo.Text + "',TrabajoCantTiempoLaborando='" + txtCantNumLaborando.Text + "',TrabajoTiempoLaborando='" + cbxTiempoLaborando.Text + "',SeguroMedico='" + lblchkSeguro.Text + "',CuentasBancaria='" + ckhCuentasBancarias.Tag.ToString + "',EntidadBancariaCuenta='" + txtEntidadCuentaBancaria.Text + "',Tarjeta='" + lblchkTarjetas.Text + "',EntidadBancariaTarjeta='" + txtEntidadTarjeta.Text + "',Sueldo='" + CDbl(txtSueldo.Text).ToString + "',IDOcupacion='" + cbxOcupacion.Tag.ToString + "',LugarTrabajo='" + txtLugarTrabajo.Text + "',UbicacionTrabajo='" + txtUbicacionTrabajo.Text + "',TelefonoTrabajo='" + txtTelefonoTrab.Text + "',DedicacionAutoEmpleado='" + txtOcupacionAutoEmpleado.Text + "',OrigenPagos='" + txtOrigenPagos.Text + "',PadreCliente='" + txtPadre.Text + "',MadreCliente='" + txtMadre.Text + "',DomicilioPaternos='" + txtDomicilioPat.Text + "',TelefonoPaternos='" + txtTelefonoPat.Text + "',IDCivil='" + cbxEstadoCivil.Tag.ToString + "',Conyuge='" + txtNombreConyuge.Text + "',TelefonoConyuge='" + txtTelefonoConyuge.Text + "',IDOcupacionConyuge='" + cbxOcupacionConyuge.Tag.ToString + "',LugarTrabajoConyuge='" + txtLugarTrabajoCony.Text + "',PadreConyuge='" + txtPadreConyuge.Text + "',MadreConyuge='" + txtMadreConyuge.Text + "',DomicilioPatConyuge='" + txtDomicilioPatCony.Text + "',TelefonoPatConyuge='" + txtTelefonoPatCony.Text + "',IDCalificacion='" + cbxCalificacion.Tag.ToString + "',CalificacionAutonoma='" + txtCalificacionAutonoma.Text + "',xCore='" + txtXCore.Text + "',DiasCondicion='" + txtCondicionDias.Text + "',IDGrupoCXC='" + txtIDGrupoCxc.Text + "',InformacionAdc='" + txtInfoAdicional.Text + "',IDTipoCredito='" + txtIDTipoCredito.Text + "',IDEmpleado='" + cbxCobrador.Tag.ToString + "',IDEmpleadoSub='" + cbxSubCobrador.Tag.ToString + "',IDComprobanteFiscal='" + cbxTipoComprobante.Tag.ToString + "',IDCondicionCliente='" + cbxCondicion.Tag.ToString + "',Precio='" + txtPrecio.Text + "',Alertas='" + txtAlerta.Text + "',NoRecibirCheques='" + chkNoRecibirCheques.Tag.ToString + "',CuentaIncobrable='" + chkCuentaIncobrable.Tag.ToString + "',GenerarCargo='" + chkGenerarCargos.Tag.ToString + "',CerrarCredito='" + chkCerrarCredito.Tag.ToString + "',EntregarPorConduce='" + chkEntregarporConduce.Tag.ToString + "',BloqueoCobrador='" + chkBloqueoCobrador.Tag.ToString + "',Desactivar='" + chkDesactivarCliente.Tag.ToString + "',Locacion='',CreditoAnterior='" + lblCreditosAnteriores.Text + "',ReferenciaComercial1='" + txtReferenciaComercial1.Text + "',ReferenciaComercial2='" + txtReferenciaComercial2.Text + "',Garante='" + lblGarante.Text + "',GaranteNombre='" + txtNombreGarante.Text + "',TipoIdentificacionGarante='" + cbxTipoIdentificacionGarante.Text + "',IdentificacionGarante='" + txtIdentificacionGarante.Text + "',DireccionGarante='" + txtDireccionGarante.Text + "',TelefonoGarante='" + txtTelefonoGarante.Text + "',IDUsuarioModificador='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',IDVendedorCliente='" + cbxVendedor.Tag.ToString + "' WHERE IDCliente= (" + txtIDCliente.Text + ")"
                    GuardarDatos()
                    InsertDocumentos()
                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(2))
                End If
            End If

        End If

    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimirDoc.PerformClick()
    End Sub

    Private Sub CargarCbxClase()
        Dim ds As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM Claseanexa where Nulo=0", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "Claseanexa")
        CbxClase.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = ds.Tables("Claseanexa")

        CbxClase.DataSource = Tabla
        CbxClase.DisplayMember = "Descripcion"

        PropiedadDgvRutasAnexas()
    End Sub

    Private Sub DgvRutasAnexas_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRutasAnexas.CellValueChanged
        Try
            If DgvRutasAnexas.Rows.Count > 0 Then
                If e.ColumnIndex = 4 Then
                    Dim Descripcion As New Label
                    Descripcion.Text = DgvRutasAnexas.CurrentRow.Cells(4).Value

                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT IDClaseAnexa from Libregco.ClaseAnexa where Descripcion='" + Descripcion.Text + "'", ConMixta)
                    DgvRutasAnexas.CurrentRow.Cells(2).Value = Convert.ToString(cmd.ExecuteScalar())
                    ConMixta.Close()
                End If
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnLimpiarSeleccion_Click(sender As Object, e As EventArgs) Handles btnLimpiarSeleccion.Click

        If TypeConnection.Text = 1 Then
            If DgvRutasAnexas.Rows.Count = 0 Then
                MessageBox.Show("No hay rutas anexas para eliminar selección.", "No se encontró ruta", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                Dim IDDocumento As String = DgvRutasAnexas.CurrentRow.Cells(0).Value

                If IDDocumento = "" Then
                    DgvRutasAnexas.Rows.Remove(DgvRutasAnexas.CurrentRow)
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(DgvRutasAnexas.CurrentRow.Cells(3).Value)
                    If ExistFile = True Then
                        frm_show_ruta_imagen.Show(Me)
                    End If

                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar la ruta " & DgvRutasAnexas.CurrentRow.Cells(3).Value & " como documento anexo al registro?", "Eliminar Documentación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        sqlQ = "Delete from Libregco.documentosclientes Where IDDocumentosClientes = (" + IDDocumento + ")"
                        Con.Open()
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                        Con.Close()
                        DgvRutasAnexas.Rows.Remove(DgvRutasAnexas.CurrentRow)
                    End If

                    If frm_show_ruta_imagen.Visible = True Then
                        frm_show_ruta_imagen.Close()
                    End If

                End If


                If DgvRutasAnexas.Rows.Count = 0 Then
                    lblStatusBar.Text = "Listo"
                Else
                    lblStatusBar.Text = "Se han anexado : " & DgvRutasAnexas.Rows.Count & " Registro(s)"
                End If

            End If
        End If

    End Sub

    Private Sub DgvRutasAnexas_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvRutasAnexas.CellMouseMove
        'If e.ColumnIndex = 3 Then
        '    If DgvRutasAnexas.Rows.Count = 0 Then
        '    Else
        '        Cursor.Current = Cursors.Hand
        '    End If
        'End If
    End Sub

    Private Sub DgvRutasAnexas_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvRutasAnexas.CellMouseDoubleClick
        If e.ColumnIndex = 3 Then
            Dim RutaDestino As String
            Dim Exists As Boolean
            Dim Counter As Integer = DgvRutasAnexas.Rows.Count

            Cursor.Current = Cursors.WaitCursor

            If Counter = 0 Then
            Else
                RutaDestino = DgvRutasAnexas.CurrentRow.Cells(3).Value
                Exists = System.IO.File.Exists(RutaDestino)

                If Exists = False Then
                    MessageBox.Show("El archivo específicado en la ruta " & RutaDestino & " se ha modificado o eliminado.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Else
                    System.Diagnostics.Process.Start(RutaDestino)
                End If
            End If

            Cursor.Current = Cursors.Default

        End If
    End Sub


    Private Sub DgvRutasAnexas_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvRutasAnexas.CellFormatting
        If e.ColumnIndex = Me.DgvRutasAnexas.Columns(3).Index AndAlso (e.Value IsNot Nothing) Then

            With Me.DgvRutasAnexas.Rows(e.RowIndex).Cells(e.ColumnIndex)
                .ToolTipText = "Doble Click para visualizar el documento."
            End With
        End If


    End Sub

    Private Sub LimpiarSeleccionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarSeleccionToolStripMenuItem.Click
        btnLimpiarSeleccion.PerformClick()
    End Sub

    Private Sub HistorialDelClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialDelClienteToolStripMenuItem.Click
        If txtIDCliente.Text = "" Then
            MessageBox.Show("Seleccione un cliente para poder acceder a su historial.", "No hay cliente activo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            frm_buscar_clientes.ShowDialog(Me)

            If txtIDCliente.Text <> "" Then
                frm_historialpagos.ShowDialog(Me)
            End If
        Else
            frm_historialpagos.ShowDialog(Me)
        End If

    End Sub

    Private Sub btnBuscarGrupoCxc_Click(sender As Object, e As EventArgs) Handles btnBuscarGrupoCxc.Click
        frm_buscar_grupo_cxc.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarTipoCredito_Click(sender As Object, e As EventArgs) Handles btnBuscarTipoCredito.Click
        frm_buscar_tipo_credito.ShowDialog(Me)
    End Sub

    Private Sub txtCorreoElec_Leave(sender As Object, e As EventArgs) Handles txtCorreoElec.Leave
        If txtCorreoElec.Text <> "" Then
            If Validar_Mail(LCase(txtCorreoElec.Text)) = False Then
                MessageBox.Show("La dirección de correo electrónico no es no válida. El correo debe tener el formato: nombre@dominio.com, por favor escriba un correo válido.", "Validación de correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCorreoElec.Focus()
                txtCorreoElec.SelectAll()
            End If
        End If
    End Sub

    Private Sub txtCondicionDias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCondicionDias.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCondicionDias_Leave(sender As Object, e As EventArgs) Handles txtCondicionDias.Leave
        If txtCondicionDias.Text = "" Then
            txtCondicionDias.Text = DefaultDiasCondicion
        End If
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub cbxTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoComprobante.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDComprobanteFiscal FROM ComprobanteFiscal WHERE TipoComprobante= '" + cbxTipoComprobante.SelectedItem + "'", Con)
        cbxTipoComprobante.Tag = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If cbxTipoComprobante.Tag = 8 Then
            XtraTabPage5.PageVisible = True
        Else
            XtraTabPage5.PageVisible = False
        End If
    End Sub

    Private Sub DgvRutasAnexas_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvRutasAnexas.EditingControlShowing
        'REMEMBER TO CHANGE THE COLUMN INDEX NUMBER TO YOUR COMBOBOX INDEX!!
        If DgvRutasAnexas.CurrentCell.ColumnIndex = 4 Then
            Dim combo As ComboBox = CType(e.Control, ComboBox)
            If (combo IsNot Nothing) Then
                ' Remove an existing event-handler, if present, to avoid adding multiple handlers when the editing control is reused.
                RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)

                ' Add the event handler.
                AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)

            End If

        End If
    End Sub

    Private Sub DgvRutasAnexas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRutasAnexas.CellEndEdit
        DgvRutasAnexas.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvRutasAnexas_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvRutasAnexas.CurrentCellDirtyStateChanged
        If DgvRutasAnexas.IsCurrentCellDirty Then
            DgvRutasAnexas.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub ComboBox_SelectionchangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim combo As ComboBox = CType(sender, ComboBox)

            Dim Descripcion As New Label
            Descripcion.Text = DgvRutasAnexas.CurrentRow.Cells(4).Value

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDClaseAnexa from ClaseAnexa where Descripcion='" + Descripcion.Text + "'", ConLibregco)
            DgvRutasAnexas.CurrentRow.Cells(2).Value = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub

    Private Sub chkEntregarporConduce_CheckedChanged(sender As Object, e As EventArgs) Handles chkEntregarporConduce.CheckedChanged
        If chkEntregarporConduce.Checked = True Then
            chkEntregarporConduce.Tag = 1
        Else
            chkEntregarporConduce.Tag = 0
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

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If txtIDCliente.Text = "" Then
                MessageBox.Show("Seleccione un registro de clientes para acceder al reporte de descripción.", "Seleccionar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnBuscar.PerformClick()
                Exit Sub
            End If

            Con.Open()
            cmd = New MySqlCommand("Select Path from Reportes where IDReportes=87", Con)
            Dim Path As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            ObjRpt.Load("\\" & PathServidor.Text & Path)

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            '@IDCliente
            crParameterDiscreteValue.Value = txtIDCliente.Text
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDCliente")
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
            ''@Edad
            ObjRpt.SetParameterValue("@Edad", txtEdad.Text)

            LoadAnimation()
            lblStatusBar.Text = "Visualizando el reporte..."
            Dim TmpForm = New frm_reportView
            TmpForm.Show(Me)
            TmpForm.CrystalViewer.ReportSource = ObjRpt
            TmpForm.CrystalViewer.Refresh()
            TmpForm.CrystalViewer.Cursor = Cursors.Default
            lblStatusBar.Text = "Listo"


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub frm_mant_clientes_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadDgvRutasAnexas()
        PropiedadDgvReferencias()
    End Sub


    Private Sub GoogleMapsIco_Click(sender As Object, e As EventArgs) Handles GoogleMapsIco.Click
        LinkGoogleMaps_LinkClicked(LinkGoogleMaps, Nothing)
    End Sub

    Private Sub OpenGoogleMaps()
        If My.Computer.Network.IsAvailable = True Then
            frm_visualizar_mapas.ShowDialog(Me)
        Else
            MessageBox.Show("No se ha encontrado acceso al internet.", "Problema con el acceso al internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub LinkGoogleMaps_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkGoogleMaps.LinkClicked
        OpenGoogleMaps()
    End Sub

    Private Sub chkBloqueoCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chkBloqueoCobrador.CheckedChanged
        If chkBloqueoCobrador.Checked = True Then
            chkBloqueoCobrador.Tag = 1
        Else
            chkBloqueoCobrador.Tag = 0
        End If
    End Sub

    Private Sub txtSueldo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSueldo.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtSueldo_Leave(sender As Object, e As EventArgs) Handles txtSueldo.Leave
        If txtSueldo.Text = "" Then
            txtSueldo.Text = (0).ToString("C")
        Else
            txtSueldo.Text = CDbl(txtSueldo.Text).ToString("C")
        End If
    End Sub

    Private Sub txtSueldo_Enter(sender As Object, e As EventArgs) Handles txtSueldo.Enter
        txtSueldo.Text = CDbl(txtSueldo.Text)
    End Sub

    Private Sub ckhCuentasBancarias_CheckedChanged(sender As Object, e As EventArgs) Handles ckhCuentasBancarias.CheckedChanged
        If ckhCuentasBancarias.Checked = True Then
            ckhCuentasBancarias.Tag = 1
            txtEntidadCuentaBancaria.Enabled = True
        Else
            ckhCuentasBancarias.Tag = 0
            txtEntidadCuentaBancaria.Enabled = False
        End If
    End Sub

    Private Sub chkTarjetasCredito_CheckedChanged(sender As Object, e As EventArgs) Handles chkTarjetasCredito.CheckedChanged
        If chkTarjetasCredito.Checked = True Then
            lblchkTarjetas.Text = 1
            txtEntidadTarjeta.Enabled = True
        Else
            lblchkTarjetas.Text = 0
            txtEntidadTarjeta.Enabled = False
        End If
    End Sub

    Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs)
        If txtPrecio.Text <> "A" Or txtPrecio.Text <> "B" Or txtPrecio.Text <> "C" Or txtPrecio.Text <> "D" Then
            MessageBox.Show("Ha elegido un código de precios no válido para el sistema.", "Rango de precio no válido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtPrecio.Text = "A"
        End If

    End Sub


    Private Sub btnMakePhoto_Click(sender As Object, e As EventArgs) Handles btnMakePhoto.Click
        Try
            If TypeConnection.Text = 1 Then
                If DgvRutasAnexas.Rows.Count = 0 Then
                    MessageBox.Show("No se encuentran documentos anexos registrados en el cliente." & vbNewLine & vbNewLine & "Por favor registre una documento hábil con fotografía para proceder a hacer una selección de imagen del cliente.", "No se encuentran anexos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                ElseIf DgvRutasAnexas.SelectedRows.Count = 0 Then
                    MessageBox.Show("Seleccione el documento anexo de la cual desea extraer la fotografía.", "Seleccionar documento para fotografía", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    frm_hacer_foto_cliente.lblPath.Text = DgvRutasAnexas.SelectedRows(0).Cells(3).Value
                    frm_hacer_foto_cliente.Show(Me)

                End If

            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub TxtFechaNacimiento_Enter(sender As Object, e As EventArgs) Handles TxtFechaNacimiento.Enter
        If TxtFechaNacimiento.Text = "" Then
            TxtFechaNacimiento.Mask = "00/00/0000"
        End If
    End Sub

    Private Sub txtTelefonoTrab_Enter(sender As Object, e As EventArgs) Handles txtTelefonoTrab.Enter
        If txtTelefonoTrab.Mask = "" Then
            txtTelefonoTrab.Mask = ""
        Else
            txtTelefonoTrab.Mask = "000-000-0000"
        End If
    End Sub

    Private Sub txtTelefonoPat_Enter(sender As Object, e As EventArgs) Handles txtTelefonoPat.Enter
        If txtTelefonoPat.Mask = "" Then
            txtTelefonoPat.Mask = ""
        Else
            txtTelefonoPat.Mask = "000-000-0000"
        End If
    End Sub

    Private Sub txtTelefonoConyuge_Enter(sender As Object, e As EventArgs) Handles txtTelefonoConyuge.Enter
        If txtTelefonoConyuge.Mask = "" Then
            txtTelefonoConyuge.Mask = ""
        Else
            txtTelefonoConyuge.Mask = "000-000-0000"
        End If
    End Sub

    Private Sub txtTelefonoPatCony_Enter(sender As Object, e As EventArgs) Handles txtTelefonoPatCony.Enter
        If txtTelefonoPatCony.Mask = "" Then
            txtTelefonoPatCony.Mask = ""
        Else
            txtTelefonoPatCony.Mask = "000-000-0000"
        End If
    End Sub

    Private Sub tbcClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcClientes.SelectedIndexChanged
        If tbcClientes.SelectedIndex = 7 Then
            GetInformation()
            GetInfoBase()
        End If
    End Sub

    Private Sub GetInfoBase()
        Try
            If txtIDCliente.Text <> "" Then
                Con.Open()
                ConMixta.Open()

                cmd = New MySqlCommand("SELECT count(FacturaDatos.IDFacturaDatos) FROM " & SysName.Text & "FacturaDatos where IDCliente='" + txtIDCliente.Text + "' and FacturaDatos.IDTipoDocumento=17 and FacturaDatos.Nulo=0", Con)
                lblCantCqDevueltos.Text = "Cantidad de cheques devueltos: " & Convert.ToString(cmd.ExecuteScalar())

                cmd = New MySqlCommand("SELECT Coalesce(sum(FacturaDatos.TotalNeto),0) FROM " & SysName.Text & "FacturaDatos where IDCliente='" + txtIDCliente.Text + "' and FacturaDatos.IDTipoDocumento=17 and FacturaDatos.Nulo=0 ORDER BY IDFacturaDatos ASC LIMIT 1", Con)
                lblMontoUltCqDevuelto.Text = "Monto últ. cheque devuelto: " & CDbl(Convert.ToString(cmd.ExecuteScalar())).ToString("C")

                cmd = New MySqlCommand("SELECT Fecha FROM " & SysName.Text & "FacturaDatos where IDCliente='" + txtIDCliente.Text + "' and FacturaDatos.IDTipoDocumento=17 and FacturaDatos.Nulo=0 ORDER BY IDFacturaDatos ASC LIMIT 1", Con)
                If IsDate(Convert.ToString(cmd.ExecuteScalar())) Then
                    lblFechaUltCkDevuelto.Text = "Fecha últ. cheque devuelto: " & CDate(Convert.ToString(cmd.ExecuteScalar())).ToString("dd/MM/yyyy")
                Else
                    lblFechaUltCkDevuelto.Text = "Fecha últ. cheque devuelto: " & "No existe."
                End If

                cmd = New MySqlCommand("SELECT Coalesce(sum(FacturaDatos.TotalNeto),0) FROM " & SysName.Text & "FacturaDatos where IDCliente='" + txtIDCliente.Text + "' and FacturaDatos.IDTipoDocumento=17 and FacturaDatos.Nulo=0 and Balance>0 ORDER BY IDFacturaDatos ASC", Con)
                lblMontoChequeDevPendiente.Text = "Monto cheques dev. pendientes: " & CDbl(Convert.ToString(cmd.ExecuteScalar())).ToString("C")

                cmd = New MySqlCommand("SELECT Fecha FROM " & SysName.Text & "FacturaDatos where IDCliente='" + txtIDCliente.Text + "' and FacturaDatos.IDTipoDocumento=17 and FacturaDatos.Nulo=0 and Balance>0 ORDER BY IDFacturaDatos ASC LIMIT 1", Con)
                If IsDate(Convert.ToString(cmd.ExecuteScalar())) Then
                    lblFechaCqDevPendiente.Text = "Fecha últ. cheque dev. pendiente:" & CDate(Convert.ToString(cmd.ExecuteScalar())).ToString("dd/MM/yyyy")
                Else
                    lblFechaCqDevPendiente.Text = "Fecha últ. cheque dev. pendiente:" & "No existe."
                End If

                cmd = New MySqlCommand("Select Total from " & SysName.Text & "Abonos where IDCliente='" + txtIDCliente.Text + "' order by Abonos.IDAbono desc LIMIT 1", Con)
                If IsNumeric(Convert.ToString(cmd.ExecuteScalar())) Then
                    lblMontoUltimoPago.Text = "Monto de último pago: " & CDbl(Convert.ToString(cmd.ExecuteScalar())).ToString("C")
                Else
                    lblMontoUltimoPago.Text = "Monto de último pago: " & "No hay pagos."
                End If

                cmd = New MySqlCommand("Select Fecha from" & SysName.Text & "Abonos where IDCliente='" + txtIDCliente.Text + "'and Nulo=0 ORDER BY IDAbono DESC LIMIT 1", Con)
                If IsDate(Convert.ToString(cmd.ExecuteScalar())) Then
                    lblFechaUltimoPago.Text = "Fecha de último pago: " & CDate(Convert.ToString(cmd.ExecuteScalar())).ToString("dd/MM/yyyy")
                Else
                    lblFechaUltimoPago.Text = "Fecha de último pago: " & "No hay pagos."
                End If

                cmd = New MySqlCommand("SELECT BalanceGeneral FROM libregco.Clientes where IDCliente='" + txtIDCliente.Text + "'", Con)
                lblBalanceActual.Text = "Balance actual: " & CDbl(Convert.ToString(cmd.ExecuteScalar())).ToString("C")

                cmd = New MySqlCommand("SELECT LimiteCredito FROM libregco.Clientes where IDCliente='" + txtIDCliente.Text + "'", Con)
                lblLimiteCredito.Text = "Límite de crédito: " & CDbl(Convert.ToString(cmd.ExecuteScalar())).ToString("C")

                cmd = New MySqlCommand(" SELECT LimiteCredito-BalanceGeneral FROM libregco.Clientes where IDCliente='" + txtIDCliente.Text + "'", Con)
                lblDisponibilidad.Text = "Disponibilidad: " & CDbl(Convert.ToString(cmd.ExecuteScalar())).ToString("C")

                cmd = New MySqlCommand("SELECT count(FacturaDatos.IDFacturaDatos) FROM " & SysName.Text & "FacturaDatos where IDCliente='" + txtIDCliente.Text + "' and FacturaDatos.IDTipoDocumento=18 and FacturaDatos.Nulo=0 and FacturaDatos.Balance>0", Con)
                lblCantCkfuturosPend.Text = "Cant. de cheques futuros pendientes: " & Convert.ToString(cmd.ExecuteScalar())

                cmd = New MySqlCommand("SELECT Coalesce(sum(FacturaDatos.TotalNeto),0) FROM " & SysName.Text & "FacturaDatos where IDCliente='" + txtIDCliente.Text + "' and FacturaDatos.IDTipoDocumento=18 and FacturaDatos.Nulo=0 and Balance>0 ORDER BY IDFacturaDatos ASC", Con)
                lblMontoCqFutPend.Text = "Monto de cheques fut. pendientes: " & CDbl(Convert.ToString(cmd.ExecuteScalar())).ToString("C")

                cmd = New MySqlCommand("SELECT Fecha FROM" & SysName.Text & "abonos where IDCliente='" + txtIDCliente.Text + "' AND Abonos.Nulo=0 ORDER BY IDAbono DESC LIMIT 1", Con)

                Dim LastIng As String
                LastIng = Convert.ToString(cmd.ExecuteScalar())

                If IsDate(LastIng) Then
                    cmd = New MySqlCommand("SELECT Coalesce(sum(Abonos.Total),0) FROM " & SysName.Text & "Abonos where IDCliente='" + txtIDCliente.Text + "' and Abonos.Nulo=0 and Abonos.Fecha Between '" + DateSerial(Now.Year, 1, 1).ToString("yyyy-MM-dd") + "' and '" + DateSerial(Now.Year, 12, 31).ToString("yyyy-MM-dd") + "'", Con)
                    lblPromedioPago.Text = "Promedio de pago (mes): " & CDbl((Convert.ToString(cmd.ExecuteScalar())) / CDbl(DateDiff(DateInterval.Month, CDate(txtFechaIngreso.Text), CDate(LastIng)))).ToString("C")
                Else
                    lblPromedioPago.Text = "Promedio de pago (mes): " & "No ha podido ser establecido."
                End If

                cmd = New MySqlCommand("SELECT coalesce(SUM(datediff((SELECT Abonos.Fecha FROM " & SysName.Text & "detalleabonos INNER JOIN " & SysName.Text & "Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono where DetalleAbonos.IDFactura=FacturaDatos.IDFacturaDatos and DetalleAbonos.BalanceAnterior-DetalleAbonos.Total=0),FacturaDatos.Fecha))/(select count(FacturaDatos.IDFacturaDatos) from " & SysName.Text & "FacturaDatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion where IDCliente='" + txtIDCliente.Text + "' and Condicion.Dias>0 and Balance=0 and FacturaDatos.Nulo=0),0) as CantidadFactSalda FROM " & SysName.Text & "FacturaDatos where IDCliente='" + txtIDCliente.Text + "' and Balance=0", ConMixta)
                lblFrecuenciaPagoDias.Text = "Frecuencia de pago (Días): " & CInt(Convert.ToString(cmd.ExecuteScalar())) & " días"

                cmd = New MySqlCommand("Select coalesce(sum(FacturaDatos.TotalNeto),0) from " & SysName.Text & "FacturaDatos where IDCliente='" + txtIDCliente.Text + "' and FacturaDatos.Nulo=0", Con)
                lblTotalComprado.Text = "Total comprado: " & CDbl(Convert.ToString(cmd.ExecuteScalar())).ToString("C")

                Con.Close()
                ConMixta.Close()

            End If
        Catch ex As Exception
            Con.Close()
            ConMixta.Close()
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub GetInformation()
        Try
            Dim FechaConseguidaMinima, FechaConseguidaMaxima, PrimerDiaMes, UltimoDiaMes As Date
            Dim MontoDebido, MontoPagado As Double
            Dim DataGridView1 As New DataGridView

            If txtIDCliente.Text <> "" Then
                DataGridView1.Columns.Clear()
                DataGridView1.AllowUserToAddRows = False
                DataGridView1.Columns.Add("Fecha", "Fecha")
                DataGridView1.Columns.Add("Compromiso", "Compromiso")
                DataGridView1.Columns.Add("Pago", "Pagos")

                Con.Open()

                If CheckBox1.Checked = False Then
                    cmd = New MySqlCommand("SELECT FacturaDatos.FechaVencimiento FROM libregco.FacturaDatos where IDCliente='" + txtIDCliente.Text + "' ORDER BY FECHAVENCIMIENTO ASC LIMIT 1", Con)
                    If IsDate(Convert.ToString(cmd.ExecuteScalar())) Then
                        FechaConseguidaMinima = Convert.ToString(cmd.ExecuteScalar())
                    Else
                        Con.Close()
                        MessageBox.Show("El cliente no tiene facturas registradas para generar estadísticas.", "No se encontraron facturas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Else
                    FechaConseguidaMinima = DateTimePicker1.Value.ToString("dd/MM/yyyy")
                End If

                'Estoy utilizando la fecha actual
                'cmd = New MySqlCommand("SELECT FacturaDatos.FechaVencimiento FROM libregco.FacturaDatos where IDCliente='" + txtIDCliente.Text + "' union all SELECT Abonos.Fecha FROM libregco.Abonos Where IDCliente='" + txtIDCliente.Text + "' ORDER BY FECHAVENCIMIENTO DESC LIMIT 1", Con)
                FechaConseguidaMaxima = DateSerial(Today.Year, Today.Month, Date.DaysInMonth(Today.Year, Today.Month))

                RangoInicial.Text = FechaConseguidaMinima
                RangoFinal.Text = FechaConseguidaMaxima

                DataGridView1.Rows.Clear()
                Chart1.Series(0).Points.Clear()
                Chart1.Series(1).Points.Clear()

                For i = Year(FechaConseguidaMinima) To Year(FechaConseguidaMaxima)
                    If CheckBox1.Checked = False Then
                        For m = 1 To 12
                            PrimerDiaMes = DateSerial(i, m, 1)
                            UltimoDiaMes = PrimerDiaMes.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")

                            cmd = New MySqlCommand("SELECT Coalesce(sum(Monto),0) FROM libregco.pagares INNER JOIN Libregco.FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos where FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and Pagares.FechaVencimiento Between '" + PrimerDiaMes.ToString("yyyy-MM-dd") + "' and '" + UltimoDiaMes.ToString("yyyy-MM-dd") + "'", Con)
                            MontoDebido = Convert.ToString(cmd.ExecuteScalar())

                            cmd = New MySqlCommand("SELECT Coalesce(sum(Total),0) FROM libregco.Abonos Where IDCliente='" + txtIDCliente.Text + "' AND Fecha Between '" + PrimerDiaMes.ToString("yyyy-MM-dd") + "' and '" + UltimoDiaMes.ToString("yyyy-MM-dd") + "'", Con)
                            MontoPagado = Convert.ToString(cmd.ExecuteScalar())

                            If DateSerial(i, m, 1) < FechaConseguidaMaxima Then
                                If MontoDebido + MontoPagado > 0 Then
                                    DataGridView1.Rows.Add(PrimerDiaMes.ToString("yyyy-MM"), MontoDebido.ToString("C"), MontoPagado.ToString("C"))
                                End If
                            End If
                        Next
                    Else
                        For m = Month(DateTimePicker1.Value) To 12
                            PrimerDiaMes = DateSerial(i, m, 1)
                            UltimoDiaMes = PrimerDiaMes.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")

                            cmd = New MySqlCommand("SELECT Coalesce(sum(Monto),0) FROM libregco.pagares INNER JOIN Libregco.FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos where FacturaDatos.IDCliente='" + txtIDCliente.Text + "' and Pagares.FechaVencimiento Between '" + PrimerDiaMes.ToString("yyyy-MM-dd") + "' and '" + UltimoDiaMes.ToString("yyyy-MM-dd") + "'", Con)
                            MontoDebido = Convert.ToString(cmd.ExecuteScalar())

                            cmd = New MySqlCommand("SELECT Coalesce(sum(Total),0) FROM libregco.Abonos Where IDCliente='" + txtIDCliente.Text + "' AND Fecha Between '" + PrimerDiaMes.ToString("yyyy-MM-dd") + "' and '" + UltimoDiaMes.ToString("yyyy-MM-dd") + "'", Con)
                            MontoPagado = Convert.ToString(cmd.ExecuteScalar())

                            If DateSerial(i, m, 1) < FechaConseguidaMaxima Then
                                If MontoDebido + MontoPagado > 0 Then
                                    DataGridView1.Rows.Add(PrimerDiaMes.ToString("yyyy-MM"), MontoDebido.ToString("C"), MontoPagado.ToString("C"))
                                End If
                            End If
                        Next
                    End If
                Next

                Con.Close()

                For Each row As DataGridViewRow In DataGridView1.Rows
                    Chart1.Series("Compromisos").Points.AddXY(row.Cells(0).Value, CDbl(row.Cells(1).Value).ToString("C"))
                    Chart1.Series("Pagos").Points.AddXY(row.Cells(0).Value, CDbl(row.Cells(2).Value).ToString("C"))

                Next
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            DateTimePicker1.Enabled = True
        Else
            DateTimePicker1.Enabled = False
        End If

        GetInformation()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        GetInformation()
    End Sub

    Private Sub frm_mant_clientes_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ControlRapido()
    End Sub

    Private Sub CbxTratamiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxTratamiento.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTratamiento FROM Tratamiento WHERE TratamientoAbreviado= '" + CbxTratamiento.Text + "'", ConLibregco)
        CbxTratamiento.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub chkCerrarCredito_Click(sender As Object, e As EventArgs) Handles chkCerrarCredito.Click
        If txtIDCliente.Text = "" Then

            If chkCerrarCredito.Checked = False Then
                chkCerrarCredito.Checked = True
                chkCerrarCredito.Tag = 1
            Else
                chkCerrarCredito.Checked = False
                chkCerrarCredito.Tag = 0
            End If

        Else
            If chkCerrarCredito.Checked = True Then
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT CerrarCredito FROM Clientes WHERE IDCliente= '" + txtIDCliente.Text + "'", ConLibregco)
                Dim StatusCred As Integer = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()

                If StatusCred = 1 Then
                    frm_superclave.IDAccion.Text = 111
                    frm_superclave.ShowDialog(Me)

                    If ControlSuperClave = 1 Then
                        Exit Sub
                    Else
                        chkCerrarCredito.Checked = False
                        chkCerrarCredito.Tag = 0
                    End If

                Else
                    chkCerrarCredito.Checked = False
                    chkCerrarCredito.Tag = 0
                End If
            Else
                chkCerrarCredito.Checked = True
                chkCerrarCredito.Tag = 1
            End If

        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Chart1.Dock = DockStyle.None Then
            GroupBox9.Visible = False
            Chart1.Dock = DockStyle.Fill
            Button1.Text = "Contraer gráfica"
        Else
            GroupBox9.Visible = True
            Chart1.Dock = DockStyle.None
            Button1.Text = "Expandir gráfica"
        End If
    End Sub

    Private Sub cbxSubCobrador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSubCobrador.SelectedIndexChanged
        SetIDSubCobrador()
    End Sub


    Private Sub SetIDSubCobrador()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + cbxSubCobrador.SelectedItem + "'", Con)
        cbxSubCobrador.Tag = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub TypeTrabajo()
        '0 No Trabajo
        '1 Si trabajo
        '2 Trabajo como autoempleado
        '3 No tengo bases para opinar

        If rdbSiTrabajoEstablecimiento.Checked = True Then
            GroupBox14.Enabled = True
            GroupBox15.Enabled = False
            lblchkTrabajo.Text = 1
            txtSueldo.Enabled = True
            txtOrigenPagos.Enabled = False
        ElseIf rdbSiTrabajoAuto.Checked = True Then
            GroupBox14.Enabled = False
            GroupBox15.Enabled = True
            lblchkTrabajo.Text = 2
            txtSueldo.Enabled = True
            txtOrigenPagos.Enabled = False
        ElseIf rdbNoTrabajo.Checked = True Then
            GroupBox14.Enabled = False
            GroupBox15.Enabled = False
            lblchkTrabajo.Text = 0
            txtSueldo.Enabled = False
            txtOrigenPagos.Enabled = True
        ElseIf rdbTrabajoNoSuministrado.Checked = True Then
            GroupBox14.Enabled = False
            GroupBox15.Enabled = False
            lblchkTrabajo.Text = 3
            txtSueldo.Enabled = False
            txtOrigenPagos.Enabled = False

        Else
            GroupBox14.Enabled = False
            GroupBox15.Enabled = False
            txtSueldo.Enabled = False
            txtOrigenPagos.Enabled = False
        End If
        Panel1.BackColor = SystemColors.Control
    End Sub

    Private Sub txtCondicionDias_TextChanged(sender As Object, e As EventArgs) Handles txtCondicionDias.TextChanged
        If Len(txtCondicionDias.Text) = 0 Then
            txtCondicionDias.Text = 0
            txtCondicionDias.SelectAll()
        End If
    End Sub

    Private Sub txtCalificacionAutonoma_TextChanged(sender As Object, e As EventArgs) Handles txtCalificacionAutonoma.TextChanged
        If Len(txtCalificacionAutonoma.Text) = 0 Then
            txtCalificacionAutonoma.Text = 0
            txtCalificacionAutonoma.SelectAll()
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789.,/ "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNombre_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNombre.Validating
        txtNombre.Text = txtNombre.Text.Replace("'", "")
    End Sub

    Private Sub cbxVendedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxVendedor.SelectedIndexChanged
        SetIDVendedor()
    End Sub

    Private Sub SetIDVendedor()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + cbxVendedor.SelectedItem + "'", Con)
        cbxVendedor.Tag = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Try
        GridView1.PostEditor()

        If txtNombre.Text = "" Then
            MessageBox.Show("El nombre del cliente se encuentra vacío." & vbNewLine & vbNewLine & "Escriba el nombre del cliente para procesar el registro.", "Escriba el nombre del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            tbcClientes.SelectedIndex = 0
            txtNombre.Focus()
            Exit Sub
        ElseIf cbxTipoIdentificacion.Text = "" Then
            MessageBox.Show("Seleccione un tipo de documento/identificación para el cliente: " & vbNewLine & vbNewLine & txtNombre.Text, "Seleccione el tipo de documento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            tbcClientes.SelectedIndex = 0
            cbxTipoIdentificacion.Focus()
            cbxTipoIdentificacion.DroppedDown = True
            Exit Sub
        ElseIf cbxGenero.Text = "" Then
            MessageBox.Show("Seleccione el género correspondiente al cliente.", "Seleccione el género", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            tbcClientes.SelectedIndex = 0
            cbxGenero.Focus()
            cbxGenero.DroppedDown = True
            Exit Sub
        ElseIf cbxNacionalidad.Text = "" Then
            MessageBox.Show("Seleccione la nacionalidad correspondiente al cliente.", "Seleccione la nacionalidad", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            tbcClientes.SelectedIndex = 0
            cbxNacionalidad.Focus()
            cbxNacionalidad.DroppedDown = True
            Exit Sub
        ElseIf cbxProvincia.Text = "" Then
            MessageBox.Show("Seleccione la provincia correspondiente del cliente.", "Seleccione la provincia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            tbcClientes.SelectedIndex = 0
            cbxProvincia.Focus()
            cbxProvincia.DroppedDown = True
            Exit Sub
        ElseIf cbxMunicipio.Text = "" Then
            MessageBox.Show("Seleccione el municipio correspondiente al cliente.", "Seleccione el municipio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            tbcClientes.SelectedIndex = 0
            cbxMunicipio.Focus()
            cbxMunicipio.DroppedDown = True
            Exit Sub
        ElseIf CantCustomers > 0 And txtDireccion.Text = "" Then
            MessageBox.Show("La dirección del cliente se encuentra vacía.", "Escriba la dirección del cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            tbcClientes.SelectedIndex = 0
            txtDireccion.Focus()
            Exit Sub
        ElseIf CantCustomers > 0 And DireccionObligatoria = 1 And Len(txtDireccion.Text) < 16 Then
            MessageBox.Show("Es necesario escribir una dirección más detallada del cliente.", "Dirección no detallada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            tbcClientes.SelectedIndex = 0
            txtDireccion.Focus()
            txtDireccion.SelectAll()
            Exit Sub
        ElseIf CantCustomers > 0 And TelefonoPersonal1Obligatoria = 1 And txtTelefonoPer.MaskFull = False Then
            MessageBox.Show("Es necesario escribir el teléfono personal 1 del cliente.", "Teléfono Personal no específicado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            tbcClientes.SelectedIndex = 0
            txtTelefonoPer.Focus()
            txtTelefonoPer.SelectAll()
            Exit Sub
        ElseIf CantCustomers > 0 And TelefonoPersonalObligatoria2 = 1 And txtTelefonoHog.MaskFull = False Then
            MessageBox.Show("Es necesario escribir el teléfono personal 2 del cliente.", "Teléfono hogar no específicado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            tbcClientes.SelectedIndex = 0
            txtTelefonoHog.Focus()
            txtTelefonoHog.SelectAll()
            Exit Sub
        ElseIf txtIDGrupoCxc.Text = "" Then
            MessageBox.Show("Seleccione el grupo de cuentas por cobrar correspondiente al cliente.", "Seleccione el grupo de cuentas por cobrar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If cbxTipoIdentificacion.Tag = "2" Then tbcClientes.SelectedIndex = 3 Else tbcClientes.SelectedIndex = 5
            XtraTabControl2.SelectedTabPageIndex = 0
            btnBuscarGrupoCxc.Focus()
            Exit Sub
        ElseIf txtIDTipoCredito.Text = "" Then
            MessageBox.Show("Seleccione el tipo de crédito correspondiente al cliente.", "Seleccione el tipo de crédito a otorgar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If cbxTipoIdentificacion.Tag = "2" Then tbcClientes.SelectedIndex = 5 Else tbcClientes.SelectedIndex = 3
            XtraTabControl2.SelectedTabPageIndex = 0
            btnBuscarTipoCredito.Focus()
            Exit Sub
        ElseIf cbxCobrador.Text = "" Then
            MessageBox.Show("Seleccione el cobrador correspondiente al cliente.", "Seleccione el cobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If cbxTipoIdentificacion.Tag = "2" Then tbcClientes.SelectedIndex = 5 Else tbcClientes.SelectedIndex = 3
            XtraTabControl2.SelectedTabPageIndex = 0
            cbxCobrador.Focus()
            cbxCobrador.DroppedDown = True
            Exit Sub
        ElseIf cbxSubCobrador.Text = "" Then
            MessageBox.Show("Seleccione el subcobrador correspondiente al cliente.", "Seleccione el subcobrador", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If cbxTipoIdentificacion.Tag = "2" Then tbcClientes.SelectedIndex = 5 Else tbcClientes.SelectedIndex = 3
            XtraTabControl2.SelectedTabPageIndex = 0
            cbxSubCobrador.Focus()
            cbxSubCobrador.DroppedDown = True
            Exit Sub
        ElseIf cbxVendedor.Text = "" Then
            MessageBox.Show("Seleccione el vendedor correspondiente al cliente.", "Seleccione el Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If cbxTipoIdentificacion.Tag = "2" Then tbcClientes.SelectedIndex = 5 Else tbcClientes.SelectedIndex = 3
            XtraTabControl2.SelectedTabPageIndex = 0
            cbxVendedor.Focus()
                cbxVendedor.DroppedDown = True
                Exit Sub
            ElseIf cbxTipoComprobante.Text = "" Then
                MessageBox.Show("Seleccione el tipo de comprobante fiscal correspondiente al cliente.", "Seleccione el tipo de NCF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If cbxTipoIdentificacion.Tag = "2" Then tbcClientes.SelectedIndex = 5 Else tbcClientes.SelectedIndex = 3
            XtraTabControl2.SelectedTabPageIndex = 0
            cbxTipoComprobante.Focus()
                cbxTipoComprobante.DroppedDown = True
                Exit Sub
            ElseIf cbxCondicion.Text = "" Then
                MessageBox.Show("Seleccione el tipo de condición de venta correspondiente al cliente.", "Seleccione la condición", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If cbxTipoIdentificacion.Tag = "2" Then tbcClientes.SelectedIndex = 5 Else tbcClientes.SelectedIndex = 3
            XtraTabControl2.SelectedTabPageIndex = 0
            cbxCondicion.Focus()
                cbxCondicion.DroppedDown = True
                Exit Sub
            ElseIf txtPrecio.Text = "" Then
                MessageBox.Show("Seleccione el nivel de precio a asignar al cliente.", "Seleccionar nivel de precios", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If cbxTipoIdentificacion.Tag = "2" Then tbcClientes.SelectedIndex = 5 Else tbcClientes.SelectedIndex = 3
            XtraTabControl2.SelectedTabPageIndex = 0
            txtPrecio.Focus()
                txtPrecio.DroppedDown = True
                Exit Sub
            End If

            If CantCustomers > 0 Then
                If txtIDTipoCredito.Text = 1 Then
                    If GaranteObligatoria = 1 And txtNombreGarante.Text = "" Or GaranteObligatoria = 1 And Len(txtNombreGarante.Text) < 10 Then
                        rdbGaranteSi.Checked = True
                        MessageBox.Show("Es necesario escribir el nombre del garante para la otorgación del crédito al cliente.", "Nombre de garante no específicado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 4
                        txtNombreGarante.Focus()
                        txtNombreGarante.SelectAll()
                        Exit Sub
                    ElseIf GaranteObligatoria = 1 And cbxTipoIdentificacionGarante.Text = "" Then
                        rdbGaranteSi.Checked = True
                        MessageBox.Show("Seleccione el tipo de identificación del garante para la otorgación de crédito al cliente.", "Tipo de documento del garante no específicado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 4
                        cbxTipoIdentificacionGarante.Focus()
                        cbxTipoIdentificacionGarante.DroppedDown = True
                        Exit Sub
                    ElseIf GaranteObligatoria = 1 And txtIdentificacionGarante.MaskFull = False Then
                        rdbGaranteSi.Checked = True
                        MessageBox.Show("Escriba el No. de identificación del garante para la otorgación de crédito al cliente.", "No. de documento del garante no específicado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 4
                        txtIdentificacionGarante.Focus()
                        txtIdentificacionGarante.SelectAll()
                        Exit Sub
                    ElseIf GaranteObligatoria = 1 And txtDireccionGarante.Text = "" Or GaranteObligatoria = 1 And Len(txtDireccionGarante.Text) < 16 Then
                        rdbGaranteSi.Checked = True
                        MessageBox.Show("Es necesario escribir la dirección del garante y/o especificar con más detalle la misma para la otorgación de crédito al cliente.", "Dirección del garante no específicado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 4
                        txtDireccionGarante.Focus()
                        txtDireccionGarante.SelectAll()
                        Exit Sub
                    ElseIf GaranteObligatoria = 1 And txtTelefonoGarante.MaskFull = False Or GaranteObligatoria = 1 And txtTelefonoGarante.Text = "" Then
                        rdbGaranteSi.Checked = True
                        MessageBox.Show("Es necesario escribir el número teléfonico del garante para la otorgación de crédito al cliente.", "No. Teléfonico del garante no específicado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 4
                        txtTelefonoGarante.Focus()
                        txtTelefonoGarante.SelectAll()
                        Exit Sub
                    ElseIf InformacionAdicionalObligatoria = 1 And txtInfoAdicional.Text = "" Or InformacionAdicionalObligatoria = 1 And Len(txtInfoAdicional.Text) < 10 Then
                        MessageBox.Show("Es necesario escribir información y/o descripciones de la relación del cliente para la otorgación de crédito al cliente.", "Información adicional no específicada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        tbcClientes.SelectedIndex = 5
                        txtInfoAdicional.Focus()
                        txtInfoAdicional.SelectAll()
                        Exit Sub
                    End If
                End If
            End If

            If txtCondicionDias.Text = "" Then
                txtCondicionDias.Text = DefaultDiasCondicion
            End If

            If CantCustomers = 0 Then
                If HaveDuplicatesNumbers(txtTelefonoPer.Text, txtTelefonoHog.Text, txtTelefonoTrab.Text, txtTelefonoPat.Text, txtTelefonoConyuge.Text, txtTelefonoPatCony.Text, txtTelefonoGarante.Text, cbxTipoIdentificacion.Tag.ToString) = True Then
                    Exit Sub
                End If
            End If

            If CantCustomers > 0 Then
                'Verificacion de identificaciones
                If txtIDGrupoCxc.Text <> 3 Then
                    If IdentObligCred = 1 Then
                        If cbxTipoIdentificacion.Text.Contains("Cédula") Then
                            lblStatusBar.Text = "Verificando introducción de documentos de identidad."
                            If txtIdentificacion.MaskFull = False Then
                                If Not AccionesModulosAutorizadas.Contains("55") Then
                                    ControlSuperClave = 1
                                    MessageBox.Show("Se ha establecido que es obligatoria la introducción de la cédula de identidad y electoral para la solicitud de créditos." & vbNewLine & vbNewLine & "Por favor ingrese el número de cédula del cliente solicitante para procesar el registro. El registro del cliente y las facturas a crédito no podrán ser procesadas bajo esta condición", "Escriba el No. de cédula", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    tbcClientes.SelectedIndex = 0
                                    frm_superclave.IDAccion.Text = 55
                                    frm_superclave.ShowDialog(Me)
                                Else
                                    ControlSuperClave = 0
                                End If

                                If ControlSuperClave = 1 Then
                                    Exit Sub
                                End If
                            End If
                        End If

                        If CopiaCedulaObligatoria = 1 Then
                            Dim Founded As Boolean = False
                            lblStatusBar.Text = "Verificando introducción de archivos de documentos de identidad."

                            For Each rw As DataGridViewRow In DgvRutasAnexas.Rows
                                If (rw.Cells(4).Value).ToString.Contains("Cédula") Then
                                    Founded = True
                                    Exit For
                                Else
                                    Founded = False
                                End If
                            Next

                            If Founded = False Then
                                If Not AccionesModulosAutorizadas.Contains("114") Then
                                    ControlSuperClave = 1
                                    MessageBox.Show("Se ha específicado que es obligatoria la introducción de los archivos digitales de lo(s) documento(s) de identidad." & vbNewLine & vbNewLine & "Por favor ingrese el archivo del documento de identidad para procesar el registro.", "Anexo de archivo digital de identidad", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                                    frm_superclave.IDAccion.Text = 114
                                    frm_superclave.ShowDialog(Me)
                                Else
                                    ControlSuperClave = 0
                                End If


                                If ControlSuperClave = 1 Then
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            'Verificar filenamepath
            lblStatusBar.Text = "Verificando integridad de nombres."
            Dim array1() As String = {"\", ": ", "*", "*", "?", """", "'", "''", "<", ">", "|"}
            For Each St As Char In txtNombre.Text
                If array1.Contains(St) Then
                    MessageBox.Show("Se ha(n) encontrado carácteres no permitidos en el nombre del cliente." & vbNewLine & vbNewLine & "Por favor revise el nombre " & vbNewLine & vbNewLine & txtNombre.Text & vbNewLine & vbNewLine & " e intenté nuevamente guardar el registro.", "Carácter no válido " & St, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Next

            'Verificar Nombre
            If txtIDTipoCredito.Text = 1 Then
                lblStatusBar.Text = "Verificando nombres y apellidos no coincidentes"
                Con.Open()
                cmd = New MySqlCommand("SELECT count(IDCliente) from Libregco.Clientes", Con)
                If Convert.ToInt16(cmd.ExecuteScalar()) >= NumberToCheckNames Then
                    For Each word As String In txtNombre.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
                        If Len(word) > 3 Then
                            lblStatusBar.Text = word
                            cmd = New MySqlCommand("SELECT count(IDCliente) from Libregco.Clientes where Nombre like '%" + word + "%'", Con)
                            If Convert.ToDouble(cmd.ExecuteScalar()) = 0 Then
                                Dim Result As MsgBoxResult = MessageBox.Show("Se ha encontrado un resultado nuevo en la enciclopedia de nombres y apellidos del sistema." & vbNewLine & vbNewLine & "Está seguro que la palabra " & vbNewLine & vbNewLine & word & vbNewLine & vbNewLine & "está escrita correctamente?", "Se ha encontrado un resultado único", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                                If Result = MsgBoxResult.Yes Then
                                Else
                                    Con.Close()
                                    Exit Sub
                                End If
                            End If
                        End If
                    Next
                End If
                Con.Close()
            End If

            If txtIDGrupoCxc.Text <> 3 Then
                'Mensajes incompletos
                If txtIDGrupoCxc.Text = 1 Then
                    lblStatusBar.Text = "Verificando campos incompletos."
                    CheckIncompletes()
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                End If
            End If



            If txtIDCliente.Text = "" Then 'Si no hay un cliente seleccionado
                If Permisos(1) = 0 Then
                    MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo registro a la base de datos?", "Guardar Nuevo Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then

                    ConLibregco.Open()
                    cmd = New MySqlCommand("Select IDCliente from Clientes where IDCliente= (Select Max(IDCliente) from Clientes)", ConLibregco)
                    LastIDCliente.Text = Convert.ToString(cmd.ExecuteScalar())
                    ConLibregco.Close()

                    If cbxTipoIdentificacion.Tag = 1 Then
                        If txtIDTipoCredito.Text = 1 Then
                            If lblControlarEdad.Text = 1 Then
                                'Fecha de nacimiento no introducida
                                If IsDate(TxtFechaNacimiento.Text) Then
                                    ControlSuperClave = 0
                                Else
                                    lblStatusBar.Text = "Verificando fecha de nacimiento del cliente."
                                    If Not AccionesModulosAutorizadas.Contains("57") Then
                                        ControlSuperClave = 1

                                        Dim Result1 As MsgBoxResult = MessageBox.Show("La fecha de nacimiento es un valor obligatorio para determinar la otorgación de créditos a menores de edad." & vbNewLine & vbNewLine & "Está seguro que desea continuar el procesamiento sin ingresar la fecha de nacimiento?", "No se encontró fecha de nacimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        If Result1 = MsgBoxResult.Yes Then
                                            frm_superclave.IDAccion.Text = 57
                                            frm_superclave.ShowDialog(Me)
                                        Else
                                            TxtFechaNacimiento.Focus()
                                            Exit Sub
                                        End If
                                    Else
                                        ControlSuperClave = 0
                                    End If
                                End If
                                If ControlSuperClave = 1 Then
                                    Exit Sub
                                End If

                                'Verificar mayoria de edad
                                If IsDate(TxtFechaNacimiento.Text) Then
                                    lblStatusBar.Text = "Verificando edad legal del cliente."
                                    If Not AccionesModulosAutorizadas.Contains("56") Then
                                        ControlSuperClave = 1

                                        If VerificarEdad(CDate(TxtFechaNacimiento.Text), Today) < 18 Then
                                            Dim Result1 As MsgBoxResult = MessageBox.Show("El cliente " & txtNombre.Text & " sólo tiene " & CalcularFecha(CDate(TxtFechaNacimiento.Text), Today) & " de edad." & vbNewLine & vbNewLine & "Tome en cuenta que la realización de crédito a menores de edad debe ser autorizada y firmada por los padres o tutores del menor ya que existen leyes que protegen al menor de la generación de cargos por los créditos que le podrían ser otorgados." & vbNewLine & vbNewLine & "¿Está seguro que desea continuar?", "Menor de edad", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                            If Result1 = MsgBoxResult.Yes Then
                                                frm_superclave.IDAccion.Text = 56
                                                frm_superclave.ShowDialog(Me)
                                            Else
                                                Exit Sub
                                            End If
                                        Else
                                            ControlSuperClave = 0
                                        End If
                                    Else
                                        ControlSuperClave = 0
                                    End If

                                    If ControlSuperClave = 1 Then
                                        Exit Sub
                                    End If
                                End If

                            End If
                        End If
                    End If


                    lblStatusBar.Text = "Verificando clases anexas no completadas."
                    VerificarClasesAnexasVacias()
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If

                    lblStatusBar.Text = "Insertando registro a la base de datos"
                    sqlQ = "INSERT INTO Libregco.Clientes (IDTratamiento,Nombre,Apodo,IDTipoIdentificacion,IDNacionalidad,Identificacion,IDGenero,FechaNacimiento,LugarNacimiento,IDProvincia,IDMunicipio,Direccion,Referencia,TelefonoPersonal,TelefonoHogar,CorreoElectronico,Sueldo,Vivienda,NumeroTiempoAlquilado,TiempoAlquilado,TipoVivienda,Vehiculo,TrabajoActivo,TrabajoCantTiempoLaborando,TrabajoTiempoLaborando,SeguroMedico,CuentasBancaria,EntidadBancariaCuenta,Tarjeta,EntidadBancariaTarjeta,IDOcupacion,LugarTrabajo,UbicacionTrabajo,TelefonoTrabajo,DedicacionAutoEmpleado,OrigenPagos,PadreCliente,MadreCliente,DomicilioPaternos,TelefonoPaternos,IDCivil,Conyuge,TelefonoConyuge,IDOcupacionConyuge,LugarTrabajoConyuge,PadreConyuge,MadreConyuge,DomicilioPatConyuge,TelefonoPatConyuge,IDGrupoCxc,IDTipoCredito,IDCalificacion,CalificacionAutonoma,xCore,DiasCondicion,IDComprobanteFiscal,IDCondicionCliente,Precio,IDEmpleado,IDEmpleadoSub,InformacionAdc,Alertas,FechaIngreso,NoRecibirCheques,CuentaIncobrable,GenerarCargo,CerrarCredito,EntregarporConduce,BloqueoCobrador,BalanceGeneral,Desactivar,BalanceGeneralLetras,Locacion,CreditoAnterior,ReferenciaComercial1,ReferenciaComercial2,Garante,GaranteNombre,TipoIdentificacionGarante,IdentificacionGarante,DireccionGarante,TelefonoGarante,IDRegistrador,IDUsuarioModificador,ContactoCompras,TelContactoCompras,ExtCompras,ContactoCXC,TelContactoCXC,ExtCXC,IDVendedorCliente,LimiteCredito,LiberarControles) VALUES ('" + CbxTratamiento.Tag.ToString + "','" + txtNombre.Text + "','" + txtApodo.Text + "', '" + cbxTipoIdentificacion.Tag.ToString + "','" + cbxNacionalidad.Tag.ToString + "','" + txtIdentificacion.Text + "', '" + cbxGenero.Tag.ToString + "', '" + TxtFechaNacimiento.Text + "','" + txtLugarNacimiento.Text + "','" + cbxProvincia.Tag.ToString + "', '" + cbxMunicipio.Tag.ToString + "','" + txtDireccion.Text + "','" + txtReferencia.Text + "','" + txtTelefonoPer.Text + "','" + txtTelefonoHog.Text + "', '" + txtCorreoElec.Text + "', '" + CDbl(txtSueldo.Text).ToString + "','" + lblChkVivienda.Text + "','" + txtTiempoAlquiler.Text + "','" + cbxTiempoAlquier.Text + "','" + lblTipoVivienda.Text + "','" + lblchkVehiculo.Text + "','" + lblchkTrabajo.Text + "','" + txtCantNumLaborando.Text + "','" + cbxTiempoLaborando.Text + "','" + lblchkSeguro.Text + "','" + ckhCuentasBancarias.Tag.ToString + "','" + txtEntidadCuentaBancaria.Text + "','" + lblchkTarjetas.Text + "','" + txtEntidadTarjeta.Text + "','" + cbxOcupacion.Tag.ToString + "', '" + txtLugarTrabajo.Text + "', '" + txtUbicacionTrabajo.Text + "', '" + txtTelefonoTrab.Text + "','" + txtOcupacionAutoEmpleado.Text + "' ,'" + txtOrigenPagos.Text + "','" + txtPadre.Text + "', '" + txtMadre.Text + "','" + txtDomicilioPat.Text + "', '" + txtTelefonoPat.Text + "', '" + cbxEstadoCivil.Tag.ToString + "', '" + txtNombreConyuge.Text + "', '" + txtTelefonoConyuge.Text + "', '" + cbxOcupacionConyuge.Tag.ToString + "', '" + txtLugarTrabajoCony.Text + "', '" + txtPadreConyuge.Text + "', '" + txtMadreConyuge.Text + "','" + txtDomicilioPatCony.Text + "', '" + txtTelefonoPatCony.Text + "','" + txtIDGrupoCxc.Text + "','" + txtIDTipoCredito.Text + "','" + cbxCalificacion.Tag.ToString + "','" + txtCalificacionAutonoma.Text + "','" + txtXCore.Text + "','" + txtCondicionDias.Text + "', '" + cbxTipoComprobante.Tag.ToString + "','" + cbxCondicion.Tag.ToString + "','" + txtPrecio.Text + "','" + cbxCobrador.Tag.ToString + "','" + cbxSubCobrador.Tag.ToString + "','" + txtInfoAdicional.Text + "','" + txtAlerta.Text + "','" + txtFechaIngreso.Text + "','" + chkNoRecibirCheques.Tag.ToString + "','" + chkCuentaIncobrable.Tag.ToString + "','" + chkGenerarCargos.Tag.ToString + "','" + chkCerrarCredito.Tag.ToString + "','" + chkEntregarporConduce.Tag.ToString + "','" + chkBloqueoCobrador.Tag.ToString + "','0','" + chkDesactivarCliente.Tag.ToString + "','','','" + lblCreditosAnteriores.Text + "','" + txtReferenciaComercial1.Text + "','" + txtReferenciaComercial2.Text + "','" + lblGarante.Text + "','" + txtNombreGarante.Text + "','" + cbxTipoIdentificacionGarante.Text + "','" + txtIdentificacionGarante.Text + "','" + txtDireccionGarante.Text + "','" + txtTelefonoGarante.Text + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "','" + txtEncargadoCompras.Text + "','" + txtContactoTelCompras.Text + "','" + txtContactoTelComprasExt.Text + "','" + txtEncargadoCXC.Text + "','" + txtContactoTelCXC.Text + "','" + txtExtEncargadoCXC.Text + "','" + cbxVendedor.Tag.ToString + "',0,'" + Convert.ToInt16(chkLiberarControles.Checked).ToString + "')"
                    GuardarDatos()
                    UltCliente()
                    SetSecondID()
                    ActualizarLimites()
                    lblStatusBar.Text = "Actualizando documentos del cliente."
                    InsertDocumentos()
                    RefrescarBalances()
                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))
                End If
            Else
                If Permisos(2) = 0 Then
                    MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then

                    lblStatusBar.Text = "Verificando clases anexas no completadas."
                    VerificarClasesAnexasVacias()
                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If
                    lblStatusBar.Text = "Verificando límite del crédito del cliente."
                    CheckLimitedeCredito()
                    lblStatusBar.Text = "Actualizando registro en la base de datos."
                    sqlQ = "UPDATE Libregco.Clientes SET IDTratamiento='" + CbxTratamiento.Tag.ToString + "',Nombre='" + txtNombre.Text + "',Apodo='" + txtApodo.Text + "',IDNacionalidad='" + cbxNacionalidad.Tag.ToString + "',IDTipoIdentificacion='" + cbxTipoIdentificacion.Tag.ToString + "',Identificacion='" + txtIdentificacion.Text + "',IDGenero='" + cbxGenero.Tag.ToString + "',FechaNacimiento='" + TxtFechaNacimiento.Text + "',LugarNacimiento='" + txtLugarNacimiento.Text + "',IDProvincia='" + cbxProvincia.Tag.ToString + "',IDMunicipio='" + cbxMunicipio.Tag.ToString + "',Direccion='" + txtDireccion.Text + "',Referencia='" + txtReferencia.Text + "',TelefonoPersonal='" + txtTelefonoPer.Text + "',TelefonoHogar='" + txtTelefonoHog.Text + "',CorreoElectronico='" + txtCorreoElec.Text + "',Vehiculo='" + lblchkVehiculo.Text + "',Vivienda='" + lblChkVivienda.Text + "',NumeroTiempoAlquilado='" + txtTiempoAlquiler.Text + "',TiempoAlquilado='" + cbxTiempoAlquier.Text + "',TipoVivienda='" + lblTipoVivienda.Text + "',TrabajoActivo='" + lblchkTrabajo.Text + "',TrabajoCantTiempoLaborando='" + txtCantNumLaborando.Text + "',TrabajoTiempoLaborando='" + cbxTiempoLaborando.Text + "',SeguroMedico='" + lblchkSeguro.Text + "',CuentasBancaria='" + ckhCuentasBancarias.Tag.ToString + "',EntidadBancariaCuenta='" + txtEntidadCuentaBancaria.Text + "',Tarjeta='" + lblchkTarjetas.Text + "',EntidadBancariaTarjeta='" + txtEntidadTarjeta.Text + "',Sueldo='" + CDbl(txtSueldo.Text).ToString + "',IDOcupacion='" + cbxOcupacion.Tag.ToString + "',LugarTrabajo='" + txtLugarTrabajo.Text + "',UbicacionTrabajo='" + txtUbicacionTrabajo.Text + "',TelefonoTrabajo='" + txtTelefonoTrab.Text + "',DedicacionAutoEmpleado='" + txtOcupacionAutoEmpleado.Text + "',OrigenPagos='" + txtOrigenPagos.Text + "',PadreCliente='" + txtPadre.Text + "',MadreCliente='" + txtMadre.Text + "',DomicilioPaternos='" + txtDomicilioPat.Text + "',TelefonoPaternos='" + txtTelefonoPat.Text + "',IDCivil='" + cbxEstadoCivil.Tag.ToString + "',Conyuge='" + txtNombreConyuge.Text + "',TelefonoConyuge='" + txtTelefonoConyuge.Text + "',IDOcupacionConyuge='" + cbxOcupacionConyuge.Tag.ToString + "',LugarTrabajoConyuge='" + txtLugarTrabajoCony.Text + "',PadreConyuge='" + txtPadreConyuge.Text + "',MadreConyuge='" + txtMadreConyuge.Text + "',DomicilioPatConyuge='" + txtDomicilioPatCony.Text + "',TelefonoPatConyuge='" + txtTelefonoPatCony.Text + "',IDCalificacion='" + cbxCalificacion.Tag.ToString + "',CalificacionAutonoma='" + txtCalificacionAutonoma.Text + "',xCore='" + txtXCore.Text + "',DiasCondicion='" + txtCondicionDias.Text + "',IDGrupoCXC='" + txtIDGrupoCxc.Text + "',InformacionAdc='" + txtInfoAdicional.Text + "',IDTipoCredito='" + txtIDTipoCredito.Text + "',IDEmpleado='" + cbxCobrador.Tag.ToString + "',IDEmpleadoSub='" + cbxSubCobrador.Tag.ToString + "',IDComprobanteFiscal='" + cbxTipoComprobante.Tag.ToString + "',IDCondicionCliente='" + cbxCondicion.Tag.ToString + "',Precio='" + txtPrecio.Text + "',Alertas='" + txtAlerta.Text + "',NoRecibirCheques='" + chkNoRecibirCheques.Tag.ToString + "',CuentaIncobrable='" + chkCuentaIncobrable.Tag.ToString + "',GenerarCargo='" + chkGenerarCargos.Tag.ToString + "',CerrarCredito='" + chkCerrarCredito.Tag.ToString + "',EntregarPorConduce='" + chkEntregarporConduce.Tag.ToString + "',BloqueoCobrador='" + chkBloqueoCobrador.Tag.ToString + "',Desactivar='" + chkDesactivarCliente.Tag.ToString + "',Locacion='',CreditoAnterior='" + lblCreditosAnteriores.Text + "',ReferenciaComercial1='" + txtReferenciaComercial1.Text + "',ReferenciaComercial2='" + txtReferenciaComercial2.Text + "',Garante='" + lblGarante.Text + "',GaranteNombre='" + txtNombreGarante.Text + "',TipoIdentificacionGarante='" + cbxTipoIdentificacionGarante.Text + "',IdentificacionGarante='" + txtIdentificacionGarante.Text + "',DireccionGarante='" + txtDireccionGarante.Text + "',TelefonoGarante='" + txtTelefonoGarante.Text + "',IDUsuarioModificador='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "',ContactoCompras='" + txtEncargadoCompras.Text + "',TelContactoCompras='" + txtContactoTelCompras.Text + "',ExtCompras='" + txtContactoTelComprasExt.Text + "',ContactoCXC='" + txtEncargadoCXC.Text + "',TelContactoCXC='" + txtContactoTelCXC.Text + "',ExtCXC='" + txtExtEncargadoCXC.Text + "',IDVendedorCliente='" + cbxVendedor.Tag.ToString + "',LiberarControles='" + Convert.ToInt16(chkLiberarControles.Checked).ToString + "' WHERE IDCliente= (" + txtIDCliente.Text + ")"
                    GuardarDatos()
                    ActualizarLimites()
                    lblStatusBar.Text = "Actualizando documentos del cliente."
                    InsertDocumentos()
                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))
                End If
            End If

        'Catch ex As Exception

        '    'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub GridView2_ValidateRow(sender As Object, e As XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView2.ValidateRow
        For Each rw As DataRow In TablaCarnetTributacion.Rows
            rw.Item("Dias") = CalcularFecha(Today, CDate(rw.Item("Vencimiento")))
        Next
    End Sub

    Private Sub GridView2_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles GridView2.CustomRowCellEdit
        If e.Column.FieldName = "Imagen" Then
            e.Column.OptionsColumn.AllowEdit = False
            e.Column.OptionsColumn.ReadOnly = True
        End If
    End Sub

    Private Sub chkLiberarControles_Click(sender As Object, e As EventArgs) Handles chkLiberarControles.Click
        If chkLiberarControles.Checked = False Then

            frm_superclave.IDAccion.Text = 136
            frm_superclave.ShowDialog(Me)

            If ControlSuperClave = 1 Then
                Exit Sub
            Else
                chkLiberarControles.Checked = True
            End If

        Else
            chkLiberarControles.Checked = False
        End If

    End Sub

    Private Sub txtXCore_TextChanged(sender As Object, e As EventArgs) Handles txtXCore.TextChanged
        If Len(txtXCore.Text) = 0 Then
            txtXCore.Text = 0
            txtXCore.SelectAll()
        End If
    End Sub

    Private Sub rdbSiTrabajoEstablecimiento_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSiTrabajoEstablecimiento.CheckedChanged
        TypeTrabajo()
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789#.,/ "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtReferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReferencia.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789#.,/ "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCorreoElec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreoElec.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789#.,/@ "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtLugarNacimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLugarNacimiento.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789#.,/ "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtAlerta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAlerta.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789#.,/ "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtInfoAdicional_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInfoAdicional.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnñopqrstuvwxyz0123456789#.,/ "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        If Len(txtNombre.Text) > 0 Then
            If txtNombre.Text.Substring(0, 1) = " " Then
                txtNombre.Text = txtNombre.Text.Remove(0, 1)
            End If

            If txtNombre.Text.Contains("  ") Then
                txtNombre.Text = txtNombre.Text.Replace("  ", " ")
                txtNombre.SelectionStart = txtNombre.TextLength
            End If
        End If
    End Sub

    Private Sub rdbSiTrabajoAuto_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSiTrabajoAuto.CheckedChanged
        TypeTrabajo()
    End Sub

    Private Sub rdbNoTrabajo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoTrabajo.CheckedChanged
        TypeTrabajo()
    End Sub

    Private Sub rdbTrabajoNoSuministrado_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTrabajoNoSuministrado.CheckedChanged
        TypeTrabajo()
    End Sub

    Private Sub rdbVehiculosSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdbVehiculosSi.CheckedChanged
        If rdbVehiculosNo.Checked = True Then
            lblchkVehiculo.Text = 0
        ElseIf rdbVehiculosSi.Checked = True Then
            lblchkVehiculo.Text = 1
        ElseIf rdbVehiculoNoINFO.Checked = True Then
            lblchkVehiculo.Text = 2
        End If
    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion WHERE Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        cbxCondicion.Tag = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub rdbVehiculosNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbVehiculosNo.CheckedChanged
        If rdbVehiculosNo.Checked = True Then
            lblchkVehiculo.Text = 0
        ElseIf rdbVehiculosSi.Checked = True Then
            lblchkVehiculo.Text = 1
        ElseIf rdbVehiculoNoINFO.Checked = True Then
            lblchkVehiculo.Text = 2
        End If
    End Sub

    Private Sub rdbCasaPropia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCasaPropia.CheckedChanged
        TypeVivienda()
    End Sub

    Private Sub TypeVivienda()
        If rdbCasaPropia.Checked Then
            lblChkVivienda.Text = 1
            txtTiempoAlquiler.Enabled = False
            cbxTiempoAlquier.Enabled = False
        ElseIf rdbCasaAlquilada.Checked Then
            lblChkVivienda.Text = 0
            txtTiempoAlquiler.Enabled = True
            cbxTiempoAlquier.Enabled = True
        ElseIf rdbCasaNoInfo.Checked = True Then
            lblChkVivienda.Text = 2
            txtTiempoAlquiler.Enabled = False
            cbxTiempoAlquier.Enabled = False
        End If
        Panel2.BackColor = SystemColors.Control
    End Sub

    Private Sub rdbCasaAlquilada_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCasaAlquilada.CheckedChanged
        TypeVivienda()
    End Sub

    Private Sub rdbCasaNoInfo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCasaNoInfo.CheckedChanged
        TypeVivienda()
    End Sub

    Private Sub rdbSeguroSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSeguroSi.CheckedChanged
        If rdbSeguroSi.Checked = True Then
            lblchkSeguro.Text = 1
        Else
            lblchkSeguro.Text = 0
        End If
    End Sub

    Private Sub rdbSeguroNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSeguroNo.CheckedChanged
        If rdbSeguroNo.Checked = True Then
            lblchkSeguro.Text = 0
        Else
            lblchkSeguro.Text = 1
        End If
    End Sub

    Private Sub rdbCreditoComercialesSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCreditoComercialesSi.CheckedChanged
        If rdbCreditoComercialesSi.Checked = True Then
            txtReferenciaComercial1.Enabled = True
            txtReferenciaComercial2.Enabled = True
            lblCreditosAnteriores.Text = 1
        Else
            txtReferenciaComercial1.Enabled = False
            txtReferenciaComercial2.Enabled = False
            lblCreditosAnteriores.Text = 0
        End If
    End Sub

    Private Sub rdbCreditoComercialNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCreditoComercialNo.CheckedChanged
        If rdbCreditoComercialNo.Checked = True Then
            txtReferenciaComercial1.Enabled = False
            txtReferenciaComercial2.Enabled = False
            lblCreditosAnteriores.Text = 0
        Else
            txtReferenciaComercial1.Enabled = True
            txtReferenciaComercial2.Enabled = True
            lblCreditosAnteriores.Text = 1
        End If
    End Sub

    Private Sub rdbGaranteSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdbGaranteSi.CheckedChanged
        If rdbGaranteSi.Checked = True Then
            GroupBox12.Enabled = True
            FillTipoIdentificacionGarante()
            lblGarante.Text = 1
        Else
            GroupBox12.Enabled = False
            cbxTipoIdentificacionGarante.DataSource = Nothing
            cbxTipoIdentificacionGarante.Items.Clear()
            lblGarante.Text = 0
        End If
    End Sub

    Private Sub rdbGaranteNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbGaranteNo.CheckedChanged
        If rdbGaranteNo.Checked = True Then
            GroupBox12.Enabled = False
            lblGarante.Text = 0
        Else
            GroupBox12.Enabled = True
            lblGarante.Text = 1
        End If
    End Sub

    Private Sub TipodeVivienda()
        If rdbCasa.Checked = True Then
            lblTipoVivienda.Text = 0
        ElseIf rdbApartamento.Checked = True Then
            lblTipoVivienda.Text = 1
        ElseIf rdbPension.Checked = True Then
            lblTipoVivienda.Text = 2
        ElseIf rdbViviendaNoEspecificada.Checked = True Then
            lblTipoVivienda.Text = 3
        End If
        Panel8.BackColor = SystemColors.Control
    End Sub

    Private Sub cbxTipoIdentificacionGarante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoIdentificacionGarante.SelectedIndexChanged
        Try
            Dim ds As New DataSet
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDTipoIdentificacion,Mascara FROM Libregco.TipoIdentificacion WHERE Descripcion= '" + cbxTipoIdentificacionGarante.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoIdentificacion")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("TipoIdentificacion")

            If Tabla.Rows.Count > 0 Then
                cbxTipoIdentificacionGarante.Tag = (Tabla.Rows(0).Item("IDTipoIdentificacion"))
                txtIdentificacionGarante.Mask = (Tabla.Rows(0).Item("Mascara"))
            Else
                cbxTipoIdentificacionGarante.Tag = 0
                txtIdentificacionGarante.Mask = ""
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtTelefonoGarante_Leave(sender As Object, e As EventArgs) Handles txtTelefonoGarante.Leave
        If Len(txtTelefonoGarante.Text) = 8 Then
            txtTelefonoGarante.Mask = ""
        End If
        If Len(txtTelefonoGarante.Text) = 12 Then
            txtTelefonoGarante.Mask = "000-000-0000"
        End If

        If HaveDuplicatesNumbers(txtTelefonoPer.Text, txtTelefonoHog.Text, txtTelefonoTrab.Text, txtTelefonoPat.Text, txtTelefonoConyuge.Text, txtTelefonoPatCony.Text, txtTelefonoGarante.Text, cbxTipoIdentificacion.Tag.ToString) = True Then
            txtTelefonoGarante.Focus()
            txtTelefonoGarante.SelectAll()
        End If
    End Sub


    Private Sub txtTelefonoGarante_TextChanged(sender As Object, e As EventArgs) Handles txtTelefonoGarante.TextChanged
        If txtTelefonoGarante.Text = "" Then
        Else
            txtTelefonoGarante.Mask = "000-000-0000"
            txtTelefonoGarante.SelectionStart = 1
        End If
    End Sub


    Private Sub rdbCasa_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCasa.CheckedChanged
        TipodeVivienda()
    End Sub

    Private Sub rdbApartamento_CheckedChanged(sender As Object, e As EventArgs) Handles rdbApartamento.CheckedChanged
        TipodeVivienda()
    End Sub

    Private Sub rdbPension_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPension.CheckedChanged
        TipodeVivienda()
    End Sub

    Private Sub rdbViviendaNoEspecificada_CheckedChanged(sender As Object, e As EventArgs) Handles rdbViviendaNoEspecificada.CheckedChanged
        TipodeVivienda()
    End Sub


    Private Sub rdbVehiculoNoINFO_CheckedChanged(sender As Object, e As EventArgs) Handles rdbVehiculoNoINFO.CheckedChanged
        If rdbVehiculosNo.Checked = True Then
            lblchkVehiculo.Text = 0
        ElseIf rdbVehiculosSi.Checked = True Then
            lblchkVehiculo.Text = 1
        ElseIf rdbVehiculoNoINFO.Checked = True Then
            lblchkVehiculo.Text = 2
        End If
    End Sub

    Private Sub CheckIncompletes()
        If lblCheckIncompletes = 1 Then
            If txtIDGrupoCxc.Text = 1 Then
                lblStatusBar.Text = "Verificando campos incompletos."

                frm_incompletos_clientes.DgvIncompletos.Rows.Clear()

                If rdbCasa.Checked = False And rdbApartamento.Checked = False And rdbPension.Checked = False And rdbViviendaNoEspecificada.Checked = False Or rdbViviendaNoEspecificada.Checked = True Then
                    frm_incompletos_clientes.DgvIncompletos.Rows.Add(1, "• Tipo de vivienda", "No se ha específicado ninguno de los valores disponibles (Casa, Apartamento, Pensión) o se ha indicado que la información no está disponible.")
                End If
                If rdbCasaPropia.Checked = False And rdbCasaAlquilada.Checked = False And rdbCasaNoInfo.Checked = False Or rdbCasaNoInfo.Checked = True Then
                    frm_incompletos_clientes.DgvIncompletos.Rows.Add(2, "• Propiedad de vivienda", "No se ha específicado ninguno de los valores disponibles (Propia, Alquilada) o se ha indicado que la información no está disponible.")
                End If
                If rdbSiTrabajoEstablecimiento.Checked = False And rdbSiTrabajoAuto.Checked = False And rdbNoTrabajo.Checked = False And rdbTrabajoNoSuministrado.Checked = False Or rdbTrabajoNoSuministrado.Checked = True Then
                    frm_incompletos_clientes.DgvIncompletos.Rows.Add(3, "• Trabajo", "No se ha específicado ninguno de los valores disponibles (Trabajo en establecimiento, Autotrabajo, No Trabajo) se ha indicado que la información no está disponible.")
                End If

                If rdbSiTrabajoEstablecimiento.Checked = True And txtLugarTrabajo.Text = "" Then
                    frm_incompletos_clientes.DgvIncompletos.Rows.Add(4, "• Lugar de Trabajo", "Se ha determinado que el cliente trabajo pero no se ha específicado el lugar.")
                End If

                If rdbSiTrabajoAuto.Checked = True And txtOcupacionAutoEmpleado.Text = "" Then
                    frm_incompletos_clientes.DgvIncompletos.Rows.Add(5, "• Dedicación de autoempleado", "Se ha determinado que el trabajo por su cuenta pero no se ha específicado a que se dedica.")
                End If

                If rdbNoTrabajo.Checked = True And txtOrigenPagos.Text = "" Then
                    frm_incompletos_clientes.DgvIncompletos.Rows.Add(6, "• Origen de ingresos", "Se ha determinado que el cliente no trabajo pero no se ha específicado el origen de los ingresos.")
                End If

                If rdbCreditoComercialesSi.Checked = True And txtReferenciaComercial1.Text = "" Then
                    frm_incompletos_clientes.DgvIncompletos.Rows.Add(7, "• Referencia Comercial", "Se determinó que el cliente ha comprado anteriormente a crédito pero no se ha específicado la referencia.")
                End If

                If rdbGaranteSi.Checked = True And txtNombreGarante.Text = "" Then
                    frm_incompletos_clientes.DgvIncompletos.Rows.Add(8, "• Fiador Solidario", "Se determinó que el cliente tiene un garante pero no se ha específicado información del mismo.")
                End If

                If DgvReferencias.Rows.Count < 3 Then
                    frm_incompletos_clientes.DgvIncompletos.Rows.Add(9, "• Referencias personales", "No se han completado el número de referencias personales del cliente.")
                End If

                If frm_incompletos_clientes.DgvIncompletos.Rows.Count > 0 Then
                    ControlSuperClave = 1
                    frm_incompletos_clientes.ShowDialog(Me)
                Else
                    ControlSuperClave = 0
                End If
            Else
                ControlSuperClave = 0
            End If

        Else
            ControlSuperClave = 0
        End If

    End Sub

End Class



