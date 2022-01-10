Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Microsoft.Win32
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.iCalendar

Public Class frm_inicio
    Dim Connon As New MySqlConnection(CnString)
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim LastLastIdletime, CounterIdleTime, idletime As Integer
    Dim IDBitacora As New Label
    Dim lastInputInf As New LASTINPUTINFO()
    Private QtAlertas, QtCumpleanos, QtSolicitudes, QtRecordatorios, QtChat, QtAgenda, QtBoucher As Integer
    Private ArNotificaciones() As String
    Private FormIsLoaded As Boolean = False
    Dim NormalPicture As Bitmap
    Dim NormalPicturePath As String
    Dim GrayPicture As Bitmap
    Dim GrayPicturePath As String

    <StructLayout(LayoutKind.Sequential)>
    Structure LASTINPUTINFO
        <MarshalAs(UnmanagedType.U4)>
        Public cbSize As Integer
        <MarshalAs(UnmanagedType.U4)>
        Public dwTime As Integer
    End Structure

    <DllImport("user32.dll")>
    Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function

    Private Sub frm_inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        CargarConfiguracion()
        SelectUsuario()
        CargarAccesosRapidos()
        LeerPermisosdeUsuarios()
        InsertarBitacora(1)
        LeerBitacoraID()
        CargarInformaciones()
        FormIsLoaded = True
        Me.Activate()

        lblStatusBar.ForeColor = Color.Black
        lblStatusBar.Text = "Listo."

    End Sub

    Private Sub frm_inicio_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If CInt(DTAreaImpresion.Rows(0).Item("LiteMode")) = 0 Then
            'CargarClima()
            CargarAlertas()

            DateEdit1.EditValue = Now.AddDays(-30)
            DateEdit2.EditValue = Now

            CargarBouchers()
            CargarCumpleanos()
            CargarTareas()
            CargarSolicitudes()
            CargarRecordatorios()
            CargarChat()
            LoadSchedule()
            OverLoadNotification()

            If chkNotificacionAgenda.IsOn = True Then
                If QtAgenda > 0 Then
                    InfoToolStripMenuItem.PerformClick()
                    NavigationPane2.SelectedPage = NavigationPage7
                    SchedulerControl1.ActiveViewType = SchedulerViewType.Agenda
                    NavigationPane2.Width = TabPage2.Width - 15
                    lblStatusBar.ForeColor = SystemColors.Highlight
                    lblStatusBar.Text = "Se ha encontrado evento(s) para el día de hoy."
                End If
            End If
        End If

    End Sub

    Private Sub CargarInformaciones()
        lblStatusBar.Text = "Cargando informaciones de Libregco."
        If CInt(DTAreaImpresion.Rows(0).Item("LiteMode")) = 0 Then
            CargarNovedades()
            CargarQuotes()
            AdjustarMenuPrincipal()
            CargarEquipos()
            CargarComunidad()
            chkModoBajoRendimiento.Checked = False
        Else
            Label41.PerformClick()
            InfoToolStripMenuItem.Visible = False
            ToolStripMenuItem2.Visible = False
            SplitContainer1.Panel1Collapsed = True
            chkModoBajoRendimiento.Checked = True
        End If
    End Sub

    Private Sub OverLoadNotification()
        If QtChat + QtCumpleanos > 0 Then
            NavigationPane2.Pages(0).ImageOptions.Image = OverlayImages(NavigationPane2.Pages(0).ImageOptions.Image, ReturnNotificationImage(New Font("Segoe UI", 8, FontStyle.Bold), New Size(25, 25), Brushes.Red, QtChat + QtCumpleanos, Brushes.White), New Point(32, 0))
        Else
            If rdbClaro.Checked = True Then
                NavigationPane2.Pages(0).ImageOptions.Image = My.Resources.Social1Black
            Else
                NavigationPane2.Pages(0).ImageOptions.Image = My.Resources.Social1White
            End If
        End If

        If QtRecordatorios + QtSolicitudes > 0 Then
            NavigationPane2.Pages(2).ImageOptions.Image = OverlayImages(NavigationPane2.Pages(2).ImageOptions.Image, ReturnNotificationImage(New Font("Segoe UI", 8, FontStyle.Bold), New Size(25, 25), Brushes.Red, QtRecordatorios + QtSolicitudes, Brushes.White), New Point(32, 0))
        Else
            If rdbClaro.Checked = True Then
                NavigationPane2.Pages(2).ImageOptions.Image = My.Resources.ClockBlack
            Else
                NavigationPane2.Pages(2).ImageOptions.Image = My.Resources.ClockWhite
            End If
        End If

        If QtAlertas + QtBoucher > 0 Then
            NavigationPane2.Pages(3).ImageOptions.Image = OverlayImages(NavigationPane2.Pages(3).ImageOptions.Image, ReturnNotificationImage(New Font("Segoe UI", 8, FontStyle.Bold), New Size(25, 25), Brushes.Red, QtAlertas + QtBoucher, Brushes.White), New Point(32, 0))
        Else
            If rdbClaro.Checked = True Then
                NavigationPane2.Pages(3).ImageOptions.Image = My.Resources.WarningBlack
            Else
                NavigationPane2.Pages(3).ImageOptions.Image = My.Resources.WarningWhite
            End If
        End If

        Dim appointments As List(Of Appointment) = SchedulerControl1.Storage.GetAppointments(DateTime.Today, DateTime.Today.AddDays(1), True).ToList()

        If chkNotificacionAgenda.IsOn = True Then
            QtAgenda = appointments.Count
        Else
            QtAgenda = 0
        End If

        If QtAgenda > 0 Then
            NavigationPane2.Pages(4).ImageOptions.Image = OverlayImages(NavigationPane2.Pages(4).ImageOptions.Image, ReturnNotificationImage(New Font("Segoe UI", 8, FontStyle.Bold), New Size(25, 25), Brushes.Red, QtAgenda, Brushes.White), New Point(32, 0))
        Else
            If rdbClaro.Checked = True Then
                NavigationPane2.Pages(4).ImageOptions.Image = My.Resources.ScheduleBlack
            Else
                NavigationPane2.Pages(4).ImageOptions.Image = My.Resources.ScheduleWhite
            End If
        End If

        If rdbClaro.Checked = True Then
            If QtAlertas + QtBoucher + QtChat + QtCumpleanos + QtRecordatorios + QtSolicitudes + QtAgenda > 0 Then
                InfoToolStripMenuItem.Image = OverlayImages(My.Resources.InfoBlackx26, ReturnNotificationImage(New Font("Segoe UI", 8, FontStyle.Bold), New Size(17, 17), Brushes.Red, QtAlertas + QtBoucher + QtChat + QtCumpleanos + QtRecordatorios + QtSolicitudes + QtAgenda, Brushes.White), New Point(13, 0))
            Else
                InfoToolStripMenuItem.Image = My.Resources.InfoBlackx26
            End If
        Else
            If QtAlertas + QtBoucher + QtChat + QtCumpleanos + QtRecordatorios + QtSolicitudes + QtAgenda > 0 Then
                InfoToolStripMenuItem.Image = OverlayImages(My.Resources.InfoWhitex26, ReturnNotificationImage(New Font("Segoe UI", 8, FontStyle.Bold), New Size(17, 17), Brushes.Red, QtAlertas + QtBoucher + QtChat + QtCumpleanos + QtRecordatorios + QtSolicitudes + QtAgenda, Brushes.White), New Point(13, 0))
            Else
                InfoToolStripMenuItem.Image = My.Resources.InfoWhitex26
            End If
        End If
    End Sub


    Private Sub CargarBouchers()
        QtBoucher = 0

        Con.Open()
        cmd = New MySqlCommand("SELECT count(*) as Registros FROM (SELECT Transaccion.IDTransaccion,Transaccion.IDMoneda,TipoMoneda.Moneda,TipoDocumento.Documento as Documento,FacturaDatos.SecondID,FacturaDatos.Fecha,FacturaDatos.NombreFactura,Transaccion.NoAprobacion,Transaccion.Tarjeta,Transaccion.RutaBoucher FROM" & SysName.Text & "transaccion INNER JOIN" & SysName.Text & "FacturaDatos on Transaccion.IDTransaccion=FacturaDatos.IDTransaccion INNER JOIN" & SysName.Text & "TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda Where Transaccion.Tarjeta>0 and FacturaDatos.Fecha Between '" + CDate(DateEdit1.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DateEdit2.EditValue).ToString("yyyy-MM-dd") + "' UNION ALL SELECT Transaccion.IDTransaccion,Transaccion.IDMoneda,TipoMoneda.Moneda,TipoDocumento.Documento,Abonos.SecondID,Abonos.Fecha,Clientes.Nombre,Transaccion.NoAprobacion,Transaccion.Tarjeta,Transaccion.RutaBoucher FROM" & SysName.Text & "transaccion INNER JOIN" & SysName.Text & "Abonos on Transaccion.IDTransaccion=Abonos.IDTransaccion INNER JOIN Libregco.Clientes on Abonos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "TipoDocumento on Abonos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda Where Transaccion.Tarjeta>0 and Abonos.Fecha Between '" + CDate(DateEdit1.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DateEdit2.EditValue).ToString("yyyy-MM-dd") + "') as Resultados Where Resultados.RutaBoucher='' ORDER BY Resultados.Fecha ASC", Con)
        Dim Registros As Integer = Convert.ToDouble(cmd.ExecuteScalar())
        Con.Close()

        If Registros > 0 Then
            TablaTransacciones.Columns.Clear()
            TablaTransacciones.Clear()

            Dim RepositoryPicture As New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit With {.PictureStoreMode = XtraEditors.Controls.PictureStoreMode.ByteArray, .PopupBorderStyle = XtraEditors.Controls.PopupBorderStyles.NoBorder, .PictureAlignment = ContentAlignment.MiddleCenter, .ShowIcon = True, .SizeMode = XtraEditors.Controls.PictureSizeMode.Zoom, .NullText = "", .ShowMenu = True}
            Dim RepositoryVerificado As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit() With {.ValueChecked = "1", .ValueUnchecked = "0", .ValueGrayed = "", .Caption = "Verificado", .ReadOnly = False}
            Dim RepositoryCurrency As New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox()


            'Setting currencys------------------------------------------------------------------------------------
            RepositoryCurrency.SmallImages = imgFlags
            RepositoryCurrency.GlyphAlignment = DevExpress.Utils.HorzAlignment.Near
            RepositoryCurrency.Name = "RepCurrency"

            Ds.Dispose()

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDTipoMoneda,Texto FROM Libregco.tipomoneda order by IDTipoMoneda ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "tipomoneda")
            ConLibregco.Close()

            For Each Fila As DataRow In Ds.Tables("tipomoneda").Rows
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

                'nvmoneda.Description = Fila.Item("Texto")

                RepositoryCurrency.Properties.Items.Add(nvmoneda)
            Next
            Ds.Dispose()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Create DataColumn objects of data types.
            TablaTransacciones.Columns.Add("IDTransaccion", System.Type.GetType("System.String"))
            TablaTransacciones.Columns.Add("MonedaImagen", System.Type.GetType("System.Object"))
            TablaTransacciones.Columns.Add("Moneda", System.Type.GetType("System.String"))
            TablaTransacciones.Columns.Add("Documento", System.Type.GetType("System.String"))
            TablaTransacciones.Columns.Add("SecondID", System.Type.GetType("System.String"))
            TablaTransacciones.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
            TablaTransacciones.Columns.Add("NombreFactura", System.Type.GetType("System.String"))
            TablaTransacciones.Columns.Add("NoAprobacion", System.Type.GetType("System.String"))
            TablaTransacciones.Columns.Add("Tarjeta", System.Type.GetType("System.Double"))
            TablaTransacciones.Columns.Add("RutaBoucher", System.Type.GetType("System.String"))
            TablaTransacciones.Columns.Add("Imagen", System.Type.GetType("System.String"))
            TablaTransacciones.Columns.Add("Verificado", System.Type.GetType("System.String"))

            GridControl1.DataSource = TablaTransacciones
            GridView1.Columns("Imagen").ColumnEdit = RepositoryPicture
            GridView1.Columns("MonedaImagen").ColumnEdit = RepositoryCurrency
            GridView1.Columns("Verificado").ColumnEdit = RepositoryVerificado

            'Propiedades
            GridView1.Columns("IDTransaccion").Visible = False
            GridView1.Columns("MonedaImagen").OptionsColumn.ReadOnly = True
            GridView1.Columns("MonedaImagen").OptionsColumn.AllowEdit = False
            GridView1.Columns("MonedaImagen").MaxWidth = 25
            GridView1.Columns("MonedaImagen").Caption = " "

            GridView1.Columns("Moneda").OptionsColumn.ReadOnly = True
            GridView1.Columns("Moneda").OptionsColumn.AllowEdit = False
            GridView1.Columns("Documento").Caption = "Tipo de documento"
            GridView1.Columns("Documento").OptionsColumn.ReadOnly = True
            GridView1.Columns("Documento").OptionsColumn.AllowEdit = False
            GridView1.Columns("SecondID").Caption = "# Documento"
            GridView1.Columns("SecondID").OptionsColumn.ReadOnly = True
            GridView1.Columns("SecondID").OptionsColumn.AllowEdit = False
            GridView1.Columns("Fecha").Caption = "Fecha"
            GridView1.Columns("Fecha").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridView1.Columns("Fecha").DisplayFormat.FormatString = "dd/MM/yyyy"
            GridView1.Columns("Fecha").OptionsColumn.ReadOnly = True
            GridView1.Columns("Fecha").OptionsColumn.AllowEdit = False
            GridView1.Columns("NombreFactura").Caption = "Intermediario"
            GridView1.Columns("NombreFactura").OptionsColumn.ReadOnly = True
            GridView1.Columns("NombreFactura").OptionsColumn.AllowEdit = False
            GridView1.Columns("NoAprobacion").Caption = "# Aprobación"
            GridView1.Columns("NoAprobacion").OptionsColumn.ReadOnly = True
            GridView1.Columns("NoAprobacion").OptionsColumn.AllowEdit = False
            GridView1.Columns("Tarjeta").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GridView1.Columns("Tarjeta").DisplayFormat.FormatString = "C2"
            GridView1.Columns("Tarjeta").Caption = "Monto ($)"
            GridView1.Columns("Tarjeta").OptionsColumn.ReadOnly = True
            GridView1.Columns("Tarjeta").OptionsColumn.AllowEdit = False
            GridView1.Columns("RutaBoucher").Visible = False
            GridView1.Columns("RutaBoucher").OptionsColumn.ReadOnly = True
            GridView1.Columns("RutaBoucher").OptionsColumn.AllowEdit = False
            GridView1.Columns("Imagen").OptionsColumn.ReadOnly = True
            GridView1.Columns("Imagen").OptionsColumn.AllowEdit = False
            GridView1.Columns("Verificado").Visible = False

            GridView1.Columns("Moneda").GroupIndex = 0
            GridView1.Columns("Documento").GroupIndex = 1
            GridView1.Columns("Fecha").GroupIndex = 2

            GridView1.ExpandAllGroups()

            TablaTransacciones.Rows.Clear()

            Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
                Using myCommand As MySqlCommand = New MySqlCommand("SELECT Resultados.IDTransaccion,Resultados.IDMoneda as MonedaImagen,Resultados.Moneda,Resultados.Documento as Documento,Resultados.SecondID,Resultados.Fecha,Resultados.NombreFactura,Resultados.NoAprobacion,Resultados.Tarjeta,Resultados.RutaBoucher,if(Resultados.Imagen='',NULL,Resultados.Imagen) as Imagen,0 as Verificado FROM (SELECT Transaccion.IDTransaccion,Transaccion.IDMoneda,TipoMoneda.Moneda,TipoDocumento.Documento as Documento,FacturaDatos.SecondID,FacturaDatos.Fecha,FacturaDatos.NombreFactura,Transaccion.NoAprobacion,Transaccion.Tarjeta,Transaccion.RutaBoucher,Transaccion.RutaBoucher as Imagen FROM" & SysName.Text & "transaccion INNER JOIN" & SysName.Text & "FacturaDatos on Transaccion.IDTransaccion=FacturaDatos.IDTransaccion INNER JOIN" & SysName.Text & "TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda Where FacturaDatos.Fecha Between '" + CDate(DateEdit1.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DateEdit2.EditValue).ToString("yyyy-MM-dd") + "' and Transaccion.Tarjeta>0 UNION ALL SELECT Transaccion.IDTransaccion,Transaccion.IDMoneda,TipoMoneda.Moneda,TipoDocumento.Documento,Abonos.SecondID,Abonos.Fecha,Clientes.Nombre,Transaccion.NoAprobacion,Transaccion.Tarjeta,Transaccion.RutaBoucher,Transaccion.RutaBoucher as Imagen FROM" & SysName.Text & "transaccion INNER JOIN" & SysName.Text & "Abonos on Transaccion.IDTransaccion=Abonos.IDTransaccion INNER JOIN Libregco.Clientes on Abonos.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "TipoDocumento on Abonos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.TipoMoneda on Transaccion.IDMoneda=TipoMoneda.IDTipoMoneda Where Abonos.Fecha Between '" + CDate(DateEdit1.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DateEdit2.EditValue).ToString("yyyy-MM-dd") + "' and Transaccion.Tarjeta>0) as Resultados ORDER BY Resultados.Fecha ASC", ConMixta)
                    ConMixta.Open()
                    Using myReader As MySqlDataReader = myCommand.ExecuteReader
                        TablaTransacciones.Load(myReader, LoadOption.Upsert)
                        ConMixta.Close()
                    End Using
                End Using
            End Using

            TablaTransacciones.EndLoadData()
            GridView1.BestFitColumns()
        Else
            LabelControl7.Visible = False
        End If

        If Registros > 0 Then
            If chkBoucher.IsOn = True Then
                If UsuariosToolStripMenuItem.Tag = 1 Then
                    InfoToolStripMenuItem.PerformClick()
                    NavigationPane2.SelectedPage = NavigationPage6
                    NavBarControl4.ActiveGroup = NavBouchers
                End If
                QtBoucher = Registros
            Else
                QtBoucher = 0
            End If
        End If

    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        'Try
        If GridView1.FocusedRowHandle >= 0 Then
            If GridView1.FocusedColumn.FieldName = "Imagen" Then
                If TypeConnection.Text = 1 Then

                    If frm_subir_documento.Visible = True Then
                        frm_subir_documento.Close()
                    End If

                    frm_subir_documento.Show(Me)
                    frm_subir_documento.PicDocumento.Width = 539
                    frm_subir_documento.PicDocumento.Height = 607
                    frm_subir_documento.PicDocumento.Location = New Point(0, 0)

                    frm_subir_documento.RutaDocumento.Text = GridView1.GetFocusedRowCellValue(GridView1.Columns("RutaBoucher"))

                    If GridView1.GetFocusedRowCellValue(GridView1.Columns("RutaBoucher")) <> "" Then
                        If System.IO.File.Exists(GridView1.GetFocusedRowCellValue(GridView1.Columns("RutaBoucher"))) = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(GridView1.GetFocusedRowCellValue(GridView1.Columns("RutaBoucher")), FileMode.Open, FileAccess.Read)
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


        End If


        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub CargarEquipos()
        Try

            ConMixta.Open()
            DgvEquipos.Rows.Clear()
            Ds.Clear()
            cmd = New MySqlCommand("SELECT AreaImpresion.IDEquipo,ComputerName,IPPrivada,IPPublica,AreaImpresion.Nulo,SizeIndex,AutomaticStartUp,MuteApp,Suspender,Empleados.Nombre,max(Bitacora.Fecha),WindowsUser,WindowsPassword FROM" & SysName.Text & "areaimpresion INNER JOIN" & SysName.Text & "Bitacora on AreaImpresion.IDEquipo=Bitacora.IDEquipo INNER JOIN" & SysName.Text & "Empleados on Bitacora.IDEmpleado=Empleados.IDEmpleado where Abierta=1 and Conectado=1 group by IDEquipo", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Equipos")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("Equipos")

            For Each row As DataRow In Tabla.Rows
                DgvEquipos.Rows.Add(My.Resources.Monitorx24, row.Item(0), row.Item(1) & vbNewLine & "-> " & row.Item(9), CDate(row.Item(10)), row.Item(2), row.Item(3), CBool(row.Item(4)), row.Item(5), CBool(row.Item(6)), CBool(row.Item(7)), CBool(row.Item(8)), row.Item("ComputerName"), row.Item(11), row.Item(12))
            Next

            DgvEquipos.ClearSelection()

            Tabla.Dispose()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarComunidad()
        Try

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarTareas()
        Try
            Dim ClienteSinCed, ClientesSinCopia, MemosNoFinalizados, ComprasSinCopia, ComprasCreditosPend, ComprasAveriado As Double

            'Clientes sin cedulas
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT count(Clientes.IDCliente) FROM libregco.clientes INNER JOIN" & SysName.Text & "Contratos on Clientes.IDCliente=Contratos.IDCliente where IDTipoIdentificacion=1 and identificacion='' and IDGrupocxc=1 and Clientes.IDCliente>1 AND BalanceGeneral>0 and Contratos.IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'", ConMixta)
            ClienteSinCed = Convert.ToString(cmd.ExecuteScalar())

            'Clientes con contratos pero sin copias de cedulas
            cmd = New MySqlCommand("SELECT count(Clientes.IDCliente) FROM libregco.clientes INNER JOIN" & SysName.Text & "Contratos on Clientes.IDCliente=Contratos.IDCliente where IDGrupocxc = 1 And Clientes.IDCliente> 1 And BalanceGeneral>0 And Contratos.IDUsuario ='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' AND NOT EXISTS (SELECT * FROM Libregco.DocumentosClientes WHERE Clientes.IDCliente=DocumentosClientes.IDCliente AND IDClase=2)", ConMixta)
            ClientesSinCopia = Convert.ToString(cmd.ExecuteScalar())

            'Solicitudes y memos no finalizados 
            cmd = New MySqlCommand("SELECT count(IDMemoC) FROM" & SysName.Text & "MemosClientes where Finalizado=0 and Nulo=0 and IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'", ConMixta)
            MemosNoFinalizados = Convert.ToString(cmd.ExecuteScalar())

            'Compras sin copias
            cmd = New MySqlCommand("SELECT COUNT(Compras.IDCompra) FROM" & SysName.Text & "compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor where NCF<>'' and Compras.RutaDocumento='' AND Compras.IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' AND Compras.Nulo=0", ConMixta)
            ComprasSinCopia = Convert.ToString(cmd.ExecuteScalar())

            'Compras con notas pendientes
            cmd = New MySqlCommand("SELECT COUNT(Compras.IDCompra) FROM" & SysName.Text & "compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor where NCF<>'' and Compras.CreditoPendiente=1 AND Compras.IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' AND Compras.Nulo=0", ConMixta)
            ComprasCreditosPend = Convert.ToString(cmd.ExecuteScalar())

            'Compras con Averiados
            cmd = New MySqlCommand("SELECT COUNT(Compras.IDCompra) FROM" & SysName.Text & "compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor where NCF<>'' and Compras.Averiados=1 AND Compras.IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' AND Compras.Nulo=0", ConMixta)
            ComprasAveriado = Convert.ToString(cmd.ExecuteScalar())

            ConMixta.Close()

            If ClientesSinCopia + ClienteSinCed + MemosNoFinalizados + ComprasSinCopia + ComprasCreditosPend + ComprasAveriado > 0 Then
                PanelTareas.Visible = True
                Label48.Text = ClientesSinCopia + ClienteSinCed + MemosNoFinalizados + ComprasSinCopia + ComprasCreditosPend + ComprasAveriado
            Else
                PanelTareas.Visible = False
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Public Function GetLastInputTime() As Integer
        idletime = 0
        lastInputInf.cbSize = Marshal.SizeOf(lastInputInf)
        lastInputInf.dwTime = 0

        If GetLastInputInfo(lastInputInf) Then
            idletime = Environment.TickCount - lastInputInf.dwTime
        End If

        If idletime > 0 Then
            Return idletime / 1000
        Else : Return 0
        End If
    End Function

    Private Sub CargarRecordatorios()
        'Propiedades del datagrid
        PropiedadDgvRecordatorios()

        QtRecordatorios = 0
        DgvRecordatorios.Rows.Clear()

        ConMixta.Open()

        'Cargar tareas

        'Clientes sin cedulas
        DgvRecordatorios.Rows.Add(3, "Clientes sin identificación")

        Ds.Clear()
        cmd = New MySqlCommand("SELECT Clientes.IDCliente,Clientes.Nombre,Clientes.TelefonoPersonal,Clientes.TelefonoHogar FROM libregco.clientes INNER JOIN" & SysName.Text & "Contratos on Clientes.IDCliente=Contratos.IDCliente where IDTipoIdentificacion=1 and identificacion='' and IDGrupocxc=1 and Clientes.IDCliente>1 AND BalanceGeneral>0 and Contratos.IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "SinCedulas")

        Dim Tabla0 As DataTable = Ds.Tables("SinCedulas")

        If Tabla0.Rows.Count = 0 Then
            DgvRecordatorios.Rows.Add(2, "✓ No tienes clientes pendientes sin cédulas")
        Else
            For Each row As DataRow In Tabla0.Rows
                DgvRecordatorios.Rows.Add(1, "(" & row.Item(0) & ") " & row.Item(1) & " " & row.Item(2) & " " & row.Item(3))
            Next
        End If
        DgvRecordatorios.Rows.Add(1, "")
        Tabla0.Dispose()

        'Clientes con contratos sin copias de cedulas
        DgvRecordatorios.Rows.Add(3, "Clientes con contratos sin copias de identificación")

        Ds.Clear()
        cmd = New MySqlCommand("SELECT Clientes.IDCliente,Clientes.Nombre,Clientes.TelefonoPersonal,Clientes.TelefonoHogar FROM libregco.clientes INNER JOIN" & SysName.Text & "Contratos on Clientes.IDCliente=Contratos.IDCliente where IDGrupocxc = 1 And Clientes.IDCliente>1 And BalanceGeneral>0 And Contratos.IDUsuario ='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'  AND NOT EXISTS (SELECT * FROM Libregco.DocumentosClientes WHERE Clientes.IDCliente=DocumentosClientes.IDCliente AND IDClase='2')", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "NoCopias")

        Dim Tabla1 As DataTable = Ds.Tables("NoCopias")

        If Tabla1.Rows.Count = 0 Then
            DgvRecordatorios.Rows.Add(2, "✓ No tienes clientes con copias pendientes")
        Else
            For Each row As DataRow In Tabla1.Rows
                DgvRecordatorios.Rows.Add(1, "(" & row.Item(0) & ") " & row.Item(1) & " " & row.Item(2) & " " & row.Item(3))

                If chkNotificacionRecordatorio.IsOn = True Then
                    QtRecordatorios += 1
                Else
                    QtRecordatorios = 0
                End If
            Next
        End If

        DgvRecordatorios.Rows.Add(1, "")
        Tabla1.Dispose()


        'Memos no finalizados
        DgvRecordatorios.Rows.Add(3, "Solicitudes no finalizadas")

        Ds.Clear()
        cmd = New MySqlCommand("SELECT MemosClientes.SecondID,Clase,MemosClientes.Fecha,MemosClientes.IDCliente,Clientes.Nombre,FechaLimite FROM" & SysName.Text & "MemosClientes INNER JOIN Libregco.TiposMemos on MemosClientes.IDTipoMemo=TiposMemos.IDTiposMemos INNER JOIN Libregco.Clientes on MemosClientes.IDCliente=Clientes.IDCliente where Finalizado=0 and Nulo=0 and IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Memos")

        Dim Tabla2 As DataTable = Ds.Tables("Memos")

        If Tabla2.Rows.Count = 0 Then
            DgvRecordatorios.Rows.Add(2, "✓ No hay solicitudes pendientes")
        Else
            For Each row As DataRow In Tabla2.Rows
                DgvRecordatorios.Rows.Add(1, row.Item(0) & " de la clase: " & row.Item(1) & " de fecha " & row.Item(2) & " del (" & row.Item(3) & ") " & row.Item(4))
                DgvRecordatorios.Rows.Add(1, "Fecha Límite: " & row.Item(5))
                If chkNotificacionRecordatorio.IsOn = True Then
                    QtRecordatorios += 1
                Else
                    QtRecordatorios = 0
                End If
            Next
        End If
        DgvRecordatorios.Rows.Add(1, "")
        Tabla2.Dispose()

        'Compras sin copias registradas
        DgvRecordatorios.Rows.Add(3, "Compras sin copias guardadas")

        Ds.Clear()
        cmd = New MySqlCommand("SELECT Compras.SecondID,Compras.FechaFactura,Suplidor.Suplidor FROM" & SysName.Text & "compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor where NCF<>'' and Compras.RutaDocumento='' AND Compras.IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' AND Compras.Nulo=0", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "NoCopiasCom")

        Dim Tabla3 As DataTable = Ds.Tables("NoCopiasCom")

        If Tabla3.Rows.Count = 0 Then
            DgvRecordatorios.Rows.Add(2, "✓ No tienes compras con facturas pendientes")
        Else
            For Each row As DataRow In Tabla3.Rows
                DgvRecordatorios.Rows.Add(1, row.Item(0) & " " & row.Item(1) & " de " & row.Item(2))
                If chkNotificacionRecordatorio.IsOn = True Then
                    QtRecordatorios += 1
                Else
                    QtRecordatorios = 0
                End If
            Next
        End If
        DgvRecordatorios.Rows.Add(1, "")
        Tabla3.Dispose()

        'Compras con notas pendientes
        DgvRecordatorios.Rows.Add(3, "Compras con notas pendientes")

        Ds.Clear()
        cmd = New MySqlCommand("SELECT Compras.SecondID,Compras.FechaFactura,Suplidor.Suplidor FROM" & SysName.Text & "compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor where NCF<>'' and Compras.CreditoPendiente=1 AND Compras.IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' AND Compras.Nulo=0", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "NotasPend")

        Dim Tabla4 As DataTable = Ds.Tables("NotasPend")

        If Tabla4.Rows.Count = 0 Then
            DgvRecordatorios.Rows.Add(2, "✓ No tienes compras con notas pendientes")
        Else
            For Each row As DataRow In Tabla4.Rows
                DgvRecordatorios.Rows.Add(1, row.Item(0) & " " & row.Item(1) & " de " & row.Item(2))
                If chkNotificacionRecordatorio.IsOn = True Then
                    QtRecordatorios += 1
                Else
                    QtRecordatorios = 0
                End If
            Next
        End If
        DgvRecordatorios.Rows.Add(1, "")
        Tabla4.Dispose()

        'Compras con averiados
        DgvRecordatorios.Rows.Add(3, "Compras con artículos averiados")

        Ds.Clear()
        cmd = New MySqlCommand("SELECT Compras.SecondID,Compras.FechaFactura,Suplidor.Suplidor FROM" & SysName.Text & "compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor where Compras.Averiados=1 AND Compras.IDUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' AND Compras.Nulo=0", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Averiados")

        Dim Tabla5 As DataTable = Ds.Tables("Averiados")

        If Tabla5.Rows.Count = 0 Then
            DgvRecordatorios.Rows.Add(2, "✓ No tienes compras con averiados pendientes")
        Else
            For Each row As DataRow In Tabla5.Rows
                DgvRecordatorios.Rows.Add(1, row.Item(0) & " " & row.Item(1) & " de " & row.Item(2))
                If chkNotificacionRecordatorio.IsOn = True Then
                    QtRecordatorios += 1
                Else
                    QtRecordatorios = 0
                End If
            Next
        End If
        DgvRecordatorios.Rows.Add(1, "")

        Tabla5.Dispose()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Cargar vacaciones
        DgvRecordatorios.Rows.Add(3, "Vacaciones")

        For i = 1 To 12
            Ds.Clear()
            cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,VacacionInicia,VacacionTermina FROM" & SysName.Text & "empleados Where Month(VacacionInicia)= '" + i.ToString + "' and Empleados.Nulo=0 order by vacacioninicia asc", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Vacaciones")

            Dim Tabla As DataTable = Ds.Tables("Vacaciones")

            If Tabla.Rows.Count > 0 Then
                DgvRecordatorios.Rows.Add(0, MonthName(i, False))
            End If

            For Each row As DataRow In Tabla.Rows

                If CDate(row.Item("VacacionInicia")) < Today Then
                    DgvRecordatorios.Rows.Add(2, "✓ (" & row.Item("IDEmpleado") & ") " & row.Item("Nombre") & " tuvo sus vacaciones del " & CDate(row.Item("vacacioninicia")) & " al " & CDate(row.Item("VacacionTermina")))
                Else
                    DgvRecordatorios.Rows.Add(1, "(" & row.Item("IDEmpleado") & ") " & row.Item("Nombre") & " tiene sus vacaciones el " & CDate(row.Item("vacacioninicia")) & " y terminan el " & CDate(row.Item("VacacionTermina")) & ". Faltan " & DateDiff(DateInterval.Day, Today, CDate(row.Item("vacacioninicia"))) & " día(s)")
                End If

            Next
            Tabla.Dispose()
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ConMixta.Close()

        For Each row As DataGridViewRow In DgvRecordatorios.Rows
            If CDbl(row.Cells(0).Value) = 0 Then
                row.Cells(1).Style.ForeColor = SystemColors.ControlDark
                row.Cells(1).Style.Font = New Font("Segoe UI", 9, FontStyle.Regular Or FontStyle.Italic)
            ElseIf CDbl(row.Cells(0).Value) = 2 Then
                row.Cells(1).Style.ForeColor = Color.MediumSeaGreen
            ElseIf CDbl(row.Cells(0).Value) = 3 Then
                row.Cells(1).Style.Font = New Font("Segoe UI", 9, FontStyle.Bold Or FontStyle.Underline)
                row.Cells(1).Style.ForeColor = SystemColors.Highlight
            End If
        Next

        DgvRecordatorios.ClearSelection()
    End Sub

    Private Sub CargarQuotes()
        Try
            Dim RandomValue As Integer
            Ds.Clear()
            ConUtilitarios.Open()
            cmd = New MySqlCommand("Select * from Quotes", ConUtilitarios)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Quotes")
            ConUtilitarios.Close()

            Dim Tabla As DataTable = Ds.Tables("Quotes")

            Randomize()
            RandomValue = CInt(Math.Floor(Tabla.Rows.Count - 1) * Rnd())

            lblQuote.Text = Tabla.Rows(RandomValue).Item("Quote") & vbNewLine & "- " & Tabla.Rows(RandomValue).Item("Autor")

            Tabla.Dispose()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Sub CargarChat()
        'Try
        Dim newImage As Image
        'Propiedades del datagrid
        PropiedadDgvChat()

        Dim DsConversaciones As New DataSet
        DgvConversations.Rows.Clear()

        QtChat = 0

        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT Conversaciones.IDConversacion,UsuariosConversacion.IDUsuariosConversacion,UsuariosConversacion.IDEmpleado FROM" & SysName.Text & "conversaciones INNER JOIN" & SysName.Text & "UsuariosConversacion on Conversaciones.IDConversacion=UsuariosConversacion.IDConversacion where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' and Individual=1", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Conversaciones")

        Dim Tabla As DataTable = Ds.Tables("Conversaciones")
        Dim TablaUsuarios As DataTable

        For Each row As DataRow In Tabla.Rows
            DsConversaciones.Clear()
            cmd = New MySqlCommand("SELECT usuariosconversacion.IDUsuariosConversacion,usuariosconversacion.IDConversacion,usuariosconversacion.IDEmpleado,Empleados.Nombre,Empleados.ImagenChat,usuariosconversacion.IDRol,RolConversacion.Rol,UsuariosConversacion.IDEstadoChat,EstatusConversacion.Status,EstatusConversacion.ARGB,UsuariosConversacion.Fecha as DateRegistryUser,Descripcion,Conversaciones.Fecha as CreateDate,ImagenConversacion,Individual,IDEmpleadoCreador,CreatedBy.Nombre as NameCreatedBy,CreatedBy.ImagenChat as ImageCreatedBy,(SELECT count(Leido) FROM" & SysName.Text & "Mensajes Inner join" & SysName.Text & "UsuariosConversacion on Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosConversacion INNER JOIN" & SysName.Text & "Conversaciones on UsuariosConversacion.IDConversacion=Conversaciones.IDConversacion Where Leido=0 and UsuariosConversacion.IDEmpleado<>'" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' and UsuariosConversacion.IDConversacion='" + row.Item(0).ToString + "') as CantNoRead FROM" & SysName.Text & "usuariosconversacion INNER JOIN" & SysName.Text & "Conversaciones on UsuariosConversacion.IDConversacion=Conversaciones.IDConversacion INNER JOIN Libregco.RolConversacion on UsuariosConversacion.IDRol=RolConversacion.IDRolConversacion INNER JOIN Libregco.EstatusConversacion on UsuariosConversacion.IDEstadoChat=EstatusConversacion.IDEstatusConversacion INNER JOIN" & SysName.Text & "Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as CreatedBy on Conversaciones.IDEmpleadoCreador=CreatedBy.IDEmpleado where UsuariosConversacion.IDConversacion='" + row.Item(0).ToString + "' and UsuariosConversacion.IDEmpleado<>'" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' and Empleados.Nulo=0", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsConversaciones, "Usuarios")

            TablaUsuarios = DsConversaciones.Tables("Usuarios")

            For Each rw As DataRow In TablaUsuarios.Rows
                'Foto de personas del chat
                Dim ExistFile As Boolean = System.IO.File.Exists(rw.Item(4))
                If ExistFile = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(rw.Item(4), FileMode.Open, FileAccess.Read)
                    newImage = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()

                Else
                    newImage = My.Resources.no_photo
                End If

                DgvConversations.Rows.Add(rw.Item(0), ResizeImage(newImage, 70), rw.Item(3), CDate(rw.Item(12)).ToString("dd/MM/yyyy hh:mm:ss tt"), rw.Item(4), rw.Item(18), rw.Item(14), rw.Item(1))
            Next
        Next

        ConMixta.Close()

        For Each row As DataGridViewRow In DgvConversations.Rows
            If CDbl(row.Cells(5).Value) > 0 Then
                row.Cells(5).Style.ForeColor = Color.MediumSeaGreen
            End If
        Next

        If DgvConversations.Rows.Count = 0 Then
            DgvConversations.Rows.Add("", Nothing, "No hay conversaciones encontradas en el historial del chat.", Today.ToString("dd/MM/yyyy") & " " & TimeOfDay.ToString("hh:mm:ss tt"))
        End If


        If rdbOscuro.Checked = True Then
            DgvConversations.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 88, 88, 88)
            DgvConversations.DefaultCellStyle.SelectionForeColor = SystemColors.ControlLight
        Else
            DgvConversations.DefaultCellStyle.SelectionBackColor = SystemColors.ControlLight
            DgvConversations.DefaultCellStyle.SelectionForeColor = Color.Black
        End If

        DgvConversations.ClearSelection()

        Tabla.Dispose()


        'Catch ex As Exception
        '    ConMixta.Close()
        'End Try
    End Sub

    Private Sub PropiedadDgvRecordatorios()
        If DgvRecordatorios.Columns.Count > 0 Then
            Dim DatagridWidth As Double = (DgvRecordatorios.Width) / 100
            With DgvRecordatorios
                .Columns(0).Visible = False
                .Columns(1).Width = (DatagridWidth * 100) - 5
            End With
        End If
    End Sub

    Private Sub PropiedadDgvChat()
        If DgvConversations.Columns.Count > 0 Then
            Dim DatagridWidth As Double = ((DgvConversations.Width) - 70) / 100
            With DgvConversations
                .Columns(0).Visible = False
                .Columns(1).Width = 70
                .Columns(2).Width = DatagridWidth * 70
                .Columns(5).Width = DatagridWidth * 30
            End With
        End If
    End Sub

    Private Sub PropiedadesDgvs()
        PropiedadDgvAlertas()
        PropiedadDgvCumpleanos()
        PropiedadNovedades()
        PropiedadDgvChat()
        PropiedadDgvRecordatorios()
    End Sub

    Private Sub PropiedadDgvAlertas()
        If DgvAlertas.Columns.Count > 0 Then
            With DgvAlertas
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Width = DgvAlertas.Width - 4
                .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End If
    End Sub

    Private Sub PropiedadDgvCumpleanos()
        If DgvCumpleanos.Columns.Count > 0 Then
            With DgvCumpleanos
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Width = DgvCumpleanos.Width - 4
                .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End If
    End Sub

    Private Sub PropiedadNovedades()
        If DgvNovedades.Columns.Count > 0 Then
            With DgvNovedades
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Width = DgvNovedades.Width - 4
                .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End If
    End Sub

    Private Sub PropiedadSolicitudes()
        If DgvSolicitudes.Columns.Count > 0 Then
            With DgvSolicitudes
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(2).Visible = True
                .Columns(2).Width = 5
                .Columns(3).Width = DgvSolicitudes.Width - DgvSolicitudes.Columns(2).Width - 4
                .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        End If
    End Sub

    Private Sub CargarSolicitudes()
        Dim Dstemp As New DataSet

        QtSolicitudes = 0
        DgvSolicitudes.Rows.Clear()

        'Cargar propiedades
        PropiedadSolicitudes()

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM libregco.tiposmemos", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "tiposmemos")

        Dim Tabla As DataTable = Ds.Tables("tiposmemos")

        For Each itm As DataRow In Tabla.Rows
            Dstemp.Clear()
            cmd = New MySqlCommand("SELECT MemosClientes.SecondID,Fecha,Hora,MemosClientes.IDCliente,Clientes.Nombre,TiposMemos.Clase,Prioridad.Prioridad,FechaLimite,Clientes.IDEmpleado,Empleados.Nombre,if(FechaLimite<Now(),1,0) as Vencido FROM libregco.memosclientes INNER JOIN Libregco.Clientes on MemosClientes.IDCliente=Clientes.IDCliente INNER JOIN Libregco.TiposMemos on MemosClientes.IDTipoMemo=TiposMemos.IDTiposMemos INNER JOIN Libregco.Prioridad on MemosCLientes.IDPrioridad=Prioridad.IDPrioridad INNER JOIN Libregco.Empleados on Clientes.IDEmpleado=Empleados.IDEmpleado where IDTipoMemo='" + itm.Item("IDTiposMemos").ToString + "' AND Finalizado=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp, "Memos")

            Dim Tablab As DataTable = Dstemp.Tables("Memos")

            DgvSolicitudes.Rows.Add("0", 0, "", itm.Item("Clase"))
            If Tablab.Rows.Count = 0 Then
                DgvSolicitudes.Rows.Add("1", 0, "", "No hay solicitudes pendientes.", 0)
            End If

            For Each itmmem As DataRow In Tablab.Rows
                If CDate(itmmem.Item(7)) <= Today Then
                    DgvSolicitudes.Rows.Add("1", itmmem.Item(10), "", "¡VENCIDA! hace " & DateDiff(DateInterval.Day, CDate(itmmem.Item(7)), Today) & " día(s) • " & itmmem.Item(0) & " del " & CDate(itmmem.Item(1)) & " " & CDate(Convert.ToString(itmmem.Item(2))).ToString("hh:mm:ss"), 1)

                    If chkNotificacionSolicitudes.IsOn = True Then
                        QtSolicitudes += 1
                    Else
                        QtSolicitudes = 0
                    End If
                Else
                    DgvSolicitudes.Rows.Add("1", itmmem.Item(10), "", "• " & itmmem.Item(0) & " realizada el día " & CDate(itmmem.Item(1)) & " " & CDate(Convert.ToString(itmmem.Item(2))).ToString("hh:mm:ss") & " con vencimiento el " & itmmem.Item(7), 0)
                End If

                DgvSolicitudes.Rows.Add("1", itmmem.Item(10), "", itmmem.Item(4), 0)
                DgvSolicitudes.Rows.Add("1", itmmem.Item(10), "", "Cobrador asignado (" & itmmem.Item(8) & ") " & itmmem.Item(9) & " - Prioridad: " & itmmem.Item(6), 0)
            Next

            DgvSolicitudes.Rows.Add("1", 0, "", "", 0)
        Next


        Con.Close()

        For Each Row As DataGridViewRow In DgvSolicitudes.Rows

            If Row.Cells(0).Value = 0 Then
                Row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold Or FontStyle.Underline)
                Row.DefaultCellStyle.ForeColor = SystemColors.Highlight
            End If

            If Row.Cells(1).Value = 1 Then
                Row.Cells(2).Style.BackColor = Color.Red
            End If
            If Row.Cells(4).Value = 1 Then
                Row.Cells(3).Style.ForeColor = Color.Red
            End If
        Next


        DgvSolicitudes.ClearSelection()
        Tabla.Dispose()
        Dstemp.Dispose()
    End Sub

    Private Sub CargarNovedades()
        'Cargar propiedades
        PropiedadNovedades()

        Ds.Clear()
        ConUtilitarios.Open()
        cmd = New MySqlCommand("Select * from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "version_sys")

        Dim Tabla As DataTable = Ds.Tables("version_sys")

        If Tabla.Rows.Count > 0 Then
            'Conseguir informacion general
            Label2.Text = "Libregco® v" & (Tabla.Rows(0).Item("VersionMayor")) & "." & (Tabla.Rows(0).Item("VersionMenor")) & "." & (Tabla.Rows(0).Item("VersionCompilacion")) & "." & (Tabla.Rows(0).Item("VersionVersion"))
            Label16.Text = CDate(Tabla.Rows(0).Item("FechaLanzamiento")).ToLongDateString
            Label45.Text = CDate(Tabla.Rows(0).Item("FechaLanzamiento")).ToString("yyyy") & "-" & CDate((Tabla.Rows(0).Item("FechaLanzamiento")).AddYears(1)).ToString("yyyy")
            RichExtras.Rtf = My.Resources.ExtrasLibregco
            DgvNovedades.Rows.Clear()

            'Conseguir detalles
            DgvNovedades.Rows.Add("0", "", (Tabla.Rows(0).Item("VersionMayor")) & "." & (Tabla.Rows(0).Item("VersionMenor")) & "." & (Tabla.Rows(0).Item("VersionCompilacion")) & "." & (Tabla.Rows(0).Item("VersionVersion")))

            Dim DsTmp As New DataSet
            DsTmp.Clear()
            cmd = New MySqlCommand("SELECT idUpdate_sys,Notes FROM libregco_utilitarios.update_sys inner join Libregco_utilitarios.version_sys on update_sys.idbuild=version_sys.IDBuild where VersionMayor='" + (Tabla.Rows(0).Item("VersionMayor")).ToString + "' and VersionMenor='" + (Tabla.Rows(0).Item("VersionMenor")).ToString + "' and VersionCompilacion='" + (Tabla.Rows(0).Item("VersionCompilacion")).ToString + "' ORDER BY Rate DESC", ConUtilitarios)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTmp, "version")

            Dim Tablab As DataTable = DsTmp.Tables("version")

            For Each DataRow As DataRow In Tablab.Rows
                DgvNovedades.Rows.Add("1", DataRow.Item("idUpdate_sys"), "- " & DataRow.Item("Notes"))
            Next

            ConUtilitarios.Close()

            DgvNovedades.Rows.Add("2", "", "Para ver el historial de las actualizaciones del sistema da un click aquí o dirígete a la pestaña de 'Notas de la Versión'.")

            Tablab.Dispose()

            For Each Row As DataGridViewRow In DgvNovedades.Rows
                If CInt(Row.Cells(0).Value) = 0 Then
                    Row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold Or FontStyle.Underline)
                    Row.DefaultCellStyle.ForeColor = SystemColors.Highlight
                ElseIf CInt(Row.Cells(0).Value) = 2 Then
                    Row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Italic)
                    Row.DefaultCellStyle.ForeColor = SystemColors.GrayText
                End If
            Next

            DgvNovedades.ClearSelection()
        End If
        Tabla.Dispose()

    End Sub

    Private Sub CargarCumpleanos()
        'Buscar existencia de cumpleaños
        DgvCumpleanos.Rows.Clear()

        Dim Finded As Integer

        Con.Open()

        'Buscando cumpleaños de hoy
        cmd = New MySqlCommand("SELECT count(IDEmpleado) FROM Libregco.empleados WHERE MONTH(FechaNacimiento) = MONTH(CURDATE()) AND  DAY(FechaNacimiento) = DAY(CURDATE()) and Empleados.Nulo=0 order by day(FechaNacimiento) asc", Con)
        Finded = Convert.ToString(cmd.ExecuteScalar())

        If Finded = 0 Then
            DgvCumpleanos.Rows.Add("0", "", "No hay cumpleaños hoy.")
        Else

            DgvCumpleanos.Rows.Add("0", "", "Hoy están de cumpleaños.!")

            Dim AnexoCumplesHoy As New MySqlCommand("select IDEmpleado,Nombre,FechaNacimiento from libregco.empleados where DAY(FechaNacimiento) = DAY(CURDATE()) and MONTH(FechaNacimiento) = MONTH(CURDATE()) AND Empleados.Nulo=0 ORDER BY Nombre ASC", Con)

            Dim LectorCumplesHoy As MySqlDataReader = AnexoCumplesHoy.ExecuteReader

            While LectorCumplesHoy.Read
                DgvCumpleanos.Rows.Add("1", LectorCumplesHoy.GetValue(0), "Felicidades! " & LectorCumplesHoy.GetValue(1) & " en tu " & DateDiff(DateInterval.Year, CDate(LectorCumplesHoy.GetValue(2)), Today) & " cumpleaños.!")
            End While
            LectorCumplesHoy.Close()

            DgvCumpleanos.Rows.Add("0", "", "")
        End If

        'Si eres tu quien cumple
        For Each Rw As DataGridViewRow In DgvCumpleanos.Rows
            If CStr(Rw.Cells(1).Value) = DTEmpleado.Rows(0).Item("IDEmpleado").ToString Then
                DgvCumpleanos.Visible = False
                Panel22.BackgroundImage = My.Resources.HappyBirthdayGIF
                Panel22.BackgroundImageLayout = ImageLayout.Stretch
                Label3.Visible = True
                Label28.Visible = False
                Label27.Visible = False
                Con.Close()
                Exit Sub
            End If
        Next


        '-----------------------------------------------------------------------

        'Buscando cumpleaños del mes
        cmd = New MySqlCommand("SELECT COUNT(IDEmpleado) FROM Libregco.empleados WHERE MONTH(FechaNacimiento) = MONTH(CURDATE()) and Empleados.Nulo=0 AND DAY(fechanacimiento)>DAY(CURDATE()) AND Empleados.Nulo=0 order by day(FechaNacimiento) asc", Con)
        Finded = Convert.ToString(cmd.ExecuteScalar())

        If Finded = 0 Then
            DgvCumpleanos.Rows.Add("0", "", "No hay más cumpleaños en este mes.")
        Else

            DgvCumpleanos.Rows.Add("0", "", "Cumpleaños del mes.")

            Dim AnexoCumplesMes As New MySqlCommand("SELECT IDEmpleado,Nombre,FechaNacimiento FROM Libregco.empleados WHERE MONTH(FechaNacimiento) = MONTH(CURDATE()) and Empleados.Nulo=0 AND DAY(fechanacimiento)>DAY(CURDATE()) AND Empleados.Nulo=0 order by day(FechaNacimiento) asc", Con)

            Dim LectorCumplesMes As MySqlDataReader = AnexoCumplesMes.ExecuteReader

            While LectorCumplesMes.Read
                DgvCumpleanos.Rows.Add("2", LectorCumplesMes.GetValue(0), "• " & LectorCumplesMes.GetValue(1))
                DgvCumpleanos.Rows.Add("2", "", "  - Está de cumpleaños en " & DateDiff(DateInterval.Day, Today, DateSerial(Today.Year, Today.Month, CInt(CDate(LectorCumplesMes.GetValue(2)).ToString("dd")))) & " día(s) (" & CDate(LectorCumplesMes.GetValue(2)).ToString("dd/MM/yyyy") & ")")

                If Finded > 1 Then
                    DgvCumpleanos.Rows.Add("2", "", "")
                End If
                If chkNotificacionCumpleanos.IsOn = True Then
                    QtCumpleanos += 1
                Else
                    QtCumpleanos = 0
                End If
            End While

            LectorCumplesMes.Close()

        End If

        Con.Close()

        For Each Row As DataGridViewRow In DgvCumpleanos.Rows
            If CInt(Row.Cells(0).Value) = 0 Then
                Row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold Or FontStyle.Underline)
                Row.DefaultCellStyle.ForeColor = SystemColors.Highlight
            End If
        Next

        DgvCumpleanos.ClearSelection()

    End Sub

    Private Sub CargarAlertas()
        QtChat = 0

        'Propiedades del datagrid
        PropiedadDgvAlertas()

        'Consultas
        DgvAlertas.Rows.Clear()

        AlertasArticulosStocks()
        AlertasArticulosPromocion()
        AlertasNotasOrdenesCompra()
        AlertasSolicitudesMemos()
        AlertasAcuerdosPago()
        AlertasChequesFuturos()

        'Estilos
        MarcarDetalles()
        MarcarEncabezados()

        If DgvAlertas.Rows.Count = 0 Then
            DgvAlertas.Rows.Add("", "", "No se encontraron alertas...")
        End If

        DgvAlertas.ClearSelection()
    End Sub

    Private Sub MarcarEncabezados()
        'Try

        For Each Row As DataGridViewRow In DgvAlertas.Rows
            If CStr(Row.Cells(1).Value) = "ENC" Then
                Row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            End If
        Next
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub MarcarDetalles()
        'Try
        For Each Row As DataGridViewRow In DgvAlertas.Rows
            If CStr(Row.Cells(1).Value) = "RES" Then
                Row.DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub AlertasArticulosStocks()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDArticulo,Descripcion,Referencia,IDSuplidor,IDDepartamento,ExistenciaMin,ExistenciaTotal,ExistenciaMax from articulos WHERE PreAlertar=1 and Desactivar=0 AND ExistenciaTotal<=ExistenciaMin AND Descontinuar=0 LIMIT 50", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Stocks")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Stocks")

        If Tabla.Rows.Count = 0 Then
            Exit Sub
        ElseIf Tabla.Rows.Count = 1 Then
            DgvAlertas.Rows.Add("1", "ENC", "Stocks Mínimos en Inventario.")
            DgvAlertas.Rows.Add("1", "RES", "---------Se encontró: " & Tabla.Rows.Count & " resultado.")
        ElseIf Tabla.Rows.Count > 1 Then
            DgvAlertas.Rows.Add("1", "ENC", "Stocks Mínimos en Inventario")
            DgvAlertas.Rows.Add("1", "RES", "---------Se encontraron: " & Tabla.Rows.Count & " resultados.")
        End If

        For Each Fila As DataRow In Tabla.Rows
            DgvAlertas.Rows.Add("1", "DET", "[" & (Fila.Item("IDArticulo") & "] " & (Fila.Item("Descripcion") & " / Exist: " & (Fila.Item("ExistenciaTotal")))))
            If chkNotificacionAlertas.IsOn = True Then
                QtAlertas += 1
            Else
                QtAlertas = 0
            End If
        Next

        DgvAlertas.Rows.Add("1", "FIN", "__________________________________________________")

        Tabla.Dispose()

    End Sub

    Private Sub AlertasArticulosPromocion()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDArticulo,Descripcion,ExistenciaTotal from articulos WHERE Desactivar=0 AND Promocion=1 LIMIT 50", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Promocion")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Promocion")

        If Tabla.Rows.Count = 0 Then
            Exit Sub
        ElseIf Tabla.Rows.Count = 1 Then
            DgvAlertas.Rows.Add("2", "ENC", "Artículos en Oferta.")
            DgvAlertas.Rows.Add("2", "RES", "---------Se encontró: " & Tabla.Rows.Count & " resultado.")
        ElseIf Tabla.Rows.Count > 1 Then
            DgvAlertas.Rows.Add("2", "ENC", "Artículos en Oferta")
            DgvAlertas.Rows.Add("2", "RES", "---------Se encontraron: " & Tabla.Rows.Count & " resultados.")
        End If

        For Each Fila As DataRow In Tabla.Rows
            DgvAlertas.Rows.Add("2", "DET", "[" & (Fila.Item("IDArticulo") & "] " & (Fila.Item("Descripcion") & " / Exist: " & (Fila.Item("ExistenciaTotal")))))
            If chkNotificacionAlertas.IsOn = True Then
                QtAlertas += 1
            Else
                QtAlertas = 0
            End If
        Next
        DgvAlertas.Rows.Add("2", "FIN", "__________________________________________________")
        Tabla.Dispose()
    End Sub

    Private Sub AlertasNotasOrdenesCompra()
        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDOrdenCompra,Fecha,Suplidor,Total FROM" & SysName.Text & "OrdenCompra INNER JOIN Libregco.Suplidor on OrdenCompra.IDSuplidor=Suplidor.IDSuplidor Where OrdenCompra.Nulo=0 and OrdenCompra.IDTipoOrden=1 LIMIT 50", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "OrdenesCompra")
        ConMixta.Close()
        Dim Tabla As DataTable = Ds.Tables("OrdenesCompra")

        If Tabla.Rows.Count = 0 Then
            Exit Sub
        ElseIf Tabla.Rows.Count = 1 Then
            DgvAlertas.Rows.Add("3", "ENC", "Orden de Compra Pendiente.")
            DgvAlertas.Rows.Add("3", "RES", "---------Se encontró: " & Tabla.Rows.Count & " resultado.")
        ElseIf Tabla.Rows.Count > 1 Then
            DgvAlertas.Rows.Add("3", "ENC", "Ordenes de Compras Pendientes.")
            DgvAlertas.Rows.Add("3", "RES", "---------Se encontraron: " & Tabla.Rows.Count & " resultados.")
        End If

        For Each Fila As DataRow In Tabla.Rows
            DgvAlertas.Rows.Add("3", "DET", "[" & (Fila.Item("IDOrdenCompra") & "] - " & (Fila.Item("Fecha") & " - " & (Fila.Item("Suplidor") & " - " & CDbl(Fila.Item("Total")).ToString("C")))))
            If chkNotificacionAlertas.IsOn = True Then
                QtAlertas += 1
            Else
                QtAlertas = 0
            End If
        Next
        DgvAlertas.Rows.Add("3", "FIN", "__________________________________________________")
        Tabla.Dispose()
    End Sub

    Private Sub AlertasSolicitudesMemos()
        Ds.Dispose()

        Con.Open()
        cmd = New MySqlCommand("SELECT IDMemoC,Fecha,Nombre,Clase,Prioridad,FechaLimite FROM" & SysName.Text & "memosclientes INNER JOIN Libregco.Clientes on MemosClientes.IDCliente=Clientes.IDCliente INNER JOIN Libregco.tiposmemos on MemosClientes.IDTipoMemo=TiposMemos.IDTiposMemos INNER JOIN Libregco.Prioridad on MemosClientes.IDPrioridad=Prioridad.IDPrioridad Where Fecha <= '" + CDate(DateAdd(DateInterval.Day, DTConfiguracion.Rows(10 - 1).Item("Value2Int"), Today)).ToString("yyyy-MM-dd") + "' and Finalizado=0 LIMIT 50", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Solicitudes")
        Con.Close()

        If Ds.Tables("Solicitudes").Rows.Count = 0 Then
            Exit Sub
        ElseIf Ds.Tables("Solicitudes").Rows.Count = 1 Then
            DgvAlertas.Rows.Add("4", "ENC", "Solicitudes Pendientes.")
            DgvAlertas.Rows.Add("4", "RES", "---------Se encontró: " & Ds.Tables("Solicitudes").Rows.Count & " resultado.")
        ElseIf Ds.Tables("Solicitudes").Rows.Count > 1 Then
            DgvAlertas.Rows.Add("4", "ENC", "Solicitudes Pendientes.")
            DgvAlertas.Rows.Add("4", "RES", "---------Se encontraron: " & Ds.Tables("Solicitudes").Rows.Count & " resultados.")
        End If

        For Each Fila As DataRow In Ds.Tables("Solicitudes").Rows
            DgvAlertas.Rows.Add("4", "DET", "[" & (Fila.Item("IDMemoC") & "] - " & (Fila.Item("Fecha") & " - " & (Fila.Item("Nombre")))))
            DgvAlertas.Rows.Add("4", "DET", (Fila.Item("Clase") & " / Priod: " & (Fila.Item("Prioridad") & " / Venc: " & (Fila.Item("FechaLimite")))))
            If chkNotificacionAlertas.IsOn = True Then
                QtAlertas += 1
            Else
                QtAlertas = 0
            End If
        Next
        DgvAlertas.Rows.Add("4", "FIN", "__________________________________________________")
        Ds.Dispose()
    End Sub

    Private Sub AlertasAcuerdosPago()
        Ds.Dispose()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAcuerdoPago,FechaPago,AcuerdosPago.IDCliente,Nombre,Monto FROM" & SysName.Text & "acuerdospago INNER JOIN Libregco.Clientes on AcuerdosPago.IDCliente=Clientes.IDCliente Where FechaPago <= '" + CDate(DateAdd(DateInterval.Day, DTConfiguracion.Rows(182 - 1).Item("Value2Int"), Today)).ToString("yyyy-MM-dd") + "' and AcuerdosPago.Status=0 and AcuerdosPago.Nulo=0 LIMIT 50", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "AcuerdosPago")
        Con.Close()

        If Ds.Tables("AcuerdosPago").Rows.Count = 0 Then
            Exit Sub
        ElseIf Ds.Tables("AcuerdosPago").Rows.Count = 1 Then
            DgvAlertas.Rows.Add("5", "ENC", "Acuerdos de Pagos Próximos.")
            DgvAlertas.Rows.Add("5", "RES", "---------Se encontró: " & Ds.Tables("AcuerdosPago").Rows.Count & " resultado.")
        ElseIf Ds.Tables("AcuerdosPago").Rows.Count > 1 Then
            DgvAlertas.Rows.Add("5", "ENC", "Acuerdos de Pagos Próximos.")
            DgvAlertas.Rows.Add("5", "RES", "---------Se encontraron: " & Ds.Tables("AcuerdosPago").Rows.Count & " resultados.")
        End If

        For Each Fila As DataRow In Ds.Tables("AcuerdosPago").Rows
            DgvAlertas.Rows.Add("5", "DET", "[" & (Fila.Item("IDAcuerdoPago") & "] - " & (Fila.Item("IDCliente") & "  " & (Fila.Item("Nombre") & " - " & CDbl(Fila.Item("Monto")).ToString("C")))))
            If chkNotificacionAlertas.IsOn = True Then
                QtAlertas += 1
            Else
                QtAlertas = 0
            End If
        Next
        DgvAlertas.Rows.Add("5", "FIN", "__________________________________________________")
        Ds.Dispose()
    End Sub

    Private Sub AlertasChequesFuturos()
        Ds.Dispose()
        Con.Open()
        cmd = New MySqlCommand("Select IDChequesFuturos,FechaDeposito,NoCheque,MontoCheque from chequesfuturos WHERE Procesado=0 and Nulo=0 LIMIT 50", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Cheques")
        Con.Close()

        If Ds.Tables("Cheques").Rows.Count = 0 Then
            Exit Sub
        ElseIf Ds.Tables("Cheques").Rows.Count = 1 Then
            DgvAlertas.Rows.Add("6", "ENC", "Cheques Futuros.")
            DgvAlertas.Rows.Add("6", "RES", "---------Se encontró: " & Ds.Tables("Cheques").Rows.Count & " resultado.")
        ElseIf Ds.Tables("Cheques").Rows.Count > 1 Then
            DgvAlertas.Rows.Add("6", "ENC", "Cheques Futuros.")
            DgvAlertas.Rows.Add("6", "RES", "---------Se encontraron: " & Ds.Tables("Cheques").Rows.Count & " resultados.")
        End If

        For Each Fila As DataRow In Ds.Tables("Cheques").Rows
            DgvAlertas.Rows.Add("6", "DET", "[" & (Fila.Item("IDChequesFuturos") & "] " & "Fecha Dep:" & (Fila.Item("FechaDeposito") & " CK:" & (Fila.Item("NoCheque") & " Monto: " & CDbl(Fila.Item("MontoCheque")).ToString("C")))))
            If chkNotificacionAlertas.IsOn = True Then
                QtAlertas += 1
            Else
                QtAlertas = 0
            End If
        Next
        DgvAlertas.Rows.Add("6", "FIN", "__________________________________________________")
        Ds.Dispose()

    End Sub

    Private Sub DeleteAllBicatoraDetalleEquipo()
        Con.Open()
        sqlQ = "Delete from" & SysName.Text & "BitacoraDetalle Where IDEquipo= (" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + ")"
        cmd = New MySqlCommand(sqlQ, Con)
        cmd.ExecuteNonQuery()
        Con.Close()
    End Sub

    Private Sub LeerBitacoraID()
        lblStatusBar.Text = "Registrando user log en sistema."
        Dim Dstemp As New DataSet

        If Con.State = ConnectionState.Open Then
            Con.Close()
        End If

        Con.Open()

        'Obtengo ID
        cmd = New MySqlCommand("Select IDEntrada from Bitacora where IDEntrada= (Select Max(IDEntrada) from Bitacora)", Con)
        IDBitacora.Text = Convert.ToDouble(cmd.ExecuteScalar())

        'Insertar bitacora detalle
        Dstemp.Clear()
        cmd = New MySqlCommand("SELECT IDEntrada,IDEquipo FROM libregco.bitacora where IDPermiso=1 and Abierta=1 and IDEquipo<>'" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "' GROUP BY IDEquipo", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Dstemp, "bitacora")

        Dim Tabla As DataTable = Dstemp.Tables("bitacora")

        For Each Row As DataRow In Tabla.Rows
            sqlQ = "INSERT INTO BitacoraDetalle (IDBitacora,IDEquipo,Mostrado) VALUES ('" + IDBitacora.Text + "','" + Row.Item("IDEquipo").ToString + "','0')"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
        Next

        Con.Close()
        Tabla.Dispose()
        Dstemp.Dispose()
    End Sub

    Private Sub CargarConfiguracion()
        Try
            TabControl1.SelectedIndex = 0
            SplitContainer1.Panel1Collapsed = False
            CargarEmpresa()
            CargarLibregco()
            CargarConfiguraciones()
            AddChangeofTSMColors()
            AddPanelMensajesClicks()
            FillEmpFastPassword()

        Catch ex As Exception
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LeerPermisosdeUsuarios()
        Try
            lblStatusBar.Text = "Cargando permisos del usuario."
            Dim Acceso, Crear, Modificar, Imprimir As New Label

            If NuevaEstructuracion = True Then
                Exit Sub
            End If

            ConMixta.Open()
            Ds.Clear()
            cmd = New MySqlCommand("Select IDPermisoEmpleado,IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir,Explicacion from" & SysName.Text & " PermisosEmpleados INNER JOIN" & SysName.Text & "Permisos on PermisosEmpleados.IDPermiso=Permisos.IDPermisos Where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "PermisosEmpleados")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("PermisosEmpleados")
            If Tabla.Rows.Count = 0 Then
                MenuBar.Enabled = False
                If DTEmpleado.Rows(0).Item("IDEmpleado").ToString <> 1 Then
                    InformaciónDisplayToolStripMenuItem.Enabled = False
                End If
                MessageBox.Show("El empleado [" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString & "] " & lblNombre.Text & " no tiene ningún tipo de permiso registrado y hábil en la base de datos.", "No se encontraron permisos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            For Each TStrip As ToolStripMenuItem In MenuBar.Items
                For Each SubStrip As ToolStripMenuItem In TStrip.DropDownItems
                    For Each Strip As Object In SubStrip.DropDownItems

                        If Not Strip.ToString.Contains("Separator") Then
                            If DirectCast(Strip, ToolStripMenuItem).Tag <> vbEmpty Then

                                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & DirectCast(Strip, ToolStripMenuItem).Tag & "' AND IDEmpleado= '" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString & "'")
                                If results.Count = 0 Then
                                    DirectCast(Strip, ToolStripMenuItem).Enabled = False
                                Else
                                    If results(0).Item("Acceso") = 1 Then
                                        DirectCast(Strip, ToolStripMenuItem).Enabled = True
                                        DirectCast(Strip, ToolStripMenuItem).ToolTipText = results(0).Item("Explicacion")
                                    Else
                                        DirectCast(Strip, ToolStripMenuItem).Enabled = False
                                    End If
                                End If
                            End If

                        End If

                    Next
                Next
            Next


            For Each TStrip As ToolStripMenuItem In ActionMenu.Items
                For Each SubStrip As ToolStripMenuItem In TStrip.DropDownItems
                    If Not SubStrip.ToString.Contains("Separator") Then
                        If DirectCast(SubStrip, ToolStripMenuItem).Tag <> vbEmpty Then
                            Dim results As DataRow() = Tabla.Select("IDPermiso= '" & DirectCast(SubStrip, ToolStripMenuItem).Tag & "' AND IDEmpleado= '" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString & "'")
                            If results.Count = 0 Then
                            Else
                                If results(0).Item("Acceso") = 1 Then
                                    DirectCast(SubStrip, ToolStripMenuItem).Visible = True
                                Else
                                    DirectCast(SubStrip, ToolStripMenuItem).Visible = False
                                End If
                            End If
                        End If
                    End If

                    For Each Strip As Object In SubStrip.DropDownItems
                        If Not Strip.ToString.Contains("Separator") Then
                            If DirectCast(Strip, ToolStripMenuItem).Tag <> vbEmpty Then
                                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & DirectCast(Strip, ToolStripMenuItem).Tag & "' AND IDEmpleado= '" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString & "'")
                                If results.Count = 0 Then
                                Else
                                    If results(0).Item("Acceso") = 1 Then
                                        DirectCast(Strip, ToolStripMenuItem).Visible = True
                                    Else
                                        DirectCast(Strip, ToolStripMenuItem).Visible = False
                                    End If
                                End If
                            End If
                        End If

                    Next
                Next
            Next

            If NuevaEstructuracion = True Then
                AjustesDelSistemaToolStripMenuItem.Visible = True
                RealizarBackUpToolStripMenuItem1.Visible = True
            Else
                AjustesDelSistemaToolStripMenuItem.Visible = False
                RealizarBackUpToolStripMenuItem1.Visible = False
            End If

            Tabla.Dispose()
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarConfiguraciones()
        Try
            lblStatusBar.Text = "Cargando configuraciones de la UI y el punto de aplicación."
            'Iconos de notificaciones
            MainNotifyIcon.Icon = My.Resources.Libregco_Icon

            If chkHabilitarNotify.Checked = True Then
                'Notify Icon
                Dim VersionSys As String
                ConUtilitarios.Open()
                cmd = New MySqlCommand("Select concat(VersionMayor,'.',VersionMenor,'.',VersionCompilacion,'.',VersionVersion) from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
                VersionSys = Convert.ToString(cmd.ExecuteScalar()) & "v"
                ConUtilitarios.Close()

                With MainNotifyIcon
                    .Visible = True
                    .Text = "Libregco " & VersionSys
                    .BalloonTipTitle = "Libregco Sistema Modular Integral " & VersionSys
                    .BalloonTipText = "El sistema se ha iniciado satisfactoriamente."
                    .ShowBalloonTip(3)
                End With
            End If

            Con.Open()

            If CInt(DTAreaImpresion.Rows(0).Item("LiteMode")) = 0 Then
                'Cargar Fondo de Pantalla
                'Dim ShowWallp As String = DTConfiguracion.Rows(67 - 1).Item("Value2Int")

                If TypeConnection.Text = 1 Then
                    If CInt(DTConfiguracion.Rows(67 - 1).Item("Value2Int")) = 1 Then
                        'Dim BackGroundStr As String = DTConfiguracion.Rows(1 - 1).Item("Value1Var")

                        If My.Computer.FileSystem.FileExists(DTConfiguracion.Rows(1 - 1).Item("Value1Var")) Then
                            'Cargar Color Promedio
                            cmd = New MySqlCommand("SELECT ArgbColor FROM FondosPantalla WHERE Ruta='" + Replace(DTConfiguracion.Rows(1 - 1).Item("Value1Var"), "\", "\\") + "'", Con)
                            Dim ColorSave As String = Convert.ToString(cmd.ExecuteScalar())

                            If ColorSave <> "" Then
                                AverageColor = Color.FromArgb(ColorSave)
                                lblSeleccion.BackColor = AverageColor
                                PanelBussInfo.BackColor = Color.FromArgb(160, AverageColor)
                                PanelBackGround.BackgroundImage = Image.FromFile(DTConfiguracion.Rows(1 - 1).Item("Value1Var"))
                            Else
                                'Cargar color primario
                                lblSeleccion.BackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                                PanelBussInfo.BackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                                PanelBackGround.BackgroundImage = Nothing

                                'Cargar color secundario
                                Me.BackColor = Color.FromArgb(DTConfiguracion.Rows(65 - 1).Item("Value1Var"))

                            End If
                        Else
                            'Cargar color primario
                            lblSeleccion.BackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                            PanelBussInfo.BackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                            PanelBackGround.BackgroundImage = Nothing

                            'Cargar color secundario
                            Me.BackColor = Color.FromArgb(DTConfiguracion.Rows(65 - 1).Item("Value1Var"))
                        End If
                    Else
                        'Cargar color primario
                        lblSeleccion.BackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                        PanelBussInfo.BackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                        PanelBackGround.BackgroundImage = Nothing

                        'Cargar color secundario
                        PanelBackGround.BackColor = Color.FromArgb(DTConfiguracion.Rows(65 - 1).Item("Value1Var"))

                    End If

                Else
                    'Cargar color primario
                    lblSeleccion.BackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                    PanelBussInfo.BackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                    PanelBackGround.BackgroundImage = Nothing

                    'Cargar color secundario
                    Me.BackColor = Color.FromArgb(DTConfiguracion.Rows(65 - 1).Item("Value1Var"))
                End If


                'Mostrar Usuarios Conectados
                'Dim ShowUsersLogin As String = cint(DTConfiguracion.Rows(22 - 1).Item("Value2Int"))

                If CInt(DTConfiguracion.Rows(22 - 1).Item("Value2Int")) = 0 Then
                    DgvEmplCon.Visible = False
                Else
                    PEmployeesOnline.Visible = True
                    ConMixta.Open()
                    Dim Consulta As New MySqlCommand("Select IDEmpleado,Nombre,Cargo from" & SysName.Text & "Empleados INNER JOIN Libregco.cargosemp on Empleados.IDCargo=CargosEmp.IDCargo Where Conectado=1", ConMixta)
                    Dim LectorUsuarios As MySqlDataReader = Consulta.ExecuteReader

                    While LectorUsuarios.Read
                        DgvEmplCon.Rows.Add(LectorUsuarios.GetValue(1) & " (" & LectorUsuarios.GetValue(2) & ")")
                    End While
                    LectorUsuarios.Close()
                    ConMixta.Close()
                    DgvEmplCon.ClearSelection()
                End If
            Else
                'Cargar color primario
                lblSeleccion.BackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                PanelBussInfo.BackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                PanelBackGround.BackgroundImage = Nothing

                'Cargar color secundario
                Me.BackColor = Color.FromArgb(DTConfiguracion.Rows(65 - 1).Item("Value1Var"))

            End If

            If ContrastReadableIs(lblSistemaModular.ForeColor, PanelBussInfo.BackColor) Then
                For Each ctl As Control In PanelBussInfo.Controls
                    If (TypeOf ctl Is Label) Then
                        ctl.ForeColor = Color.White
                    End If
                Next
                lblSeleccion.ForeColor = Color.White
            Else
                For Each ctl As Control In PanelBussInfo.Controls
                    If (TypeOf ctl Is Label) Then
                        ctl.ForeColor = Color.Black
                    End If
                Next
                lblSeleccion.ForeColor = Color.Black
            End If

            'Limite de cantidad de registros en consultas
            'LimitQuery.Text = DTConfiguracion.Rows(28 - 1).Item("Value2Int")

            'Palabra clave de costos
            'PalabraClaveCosto.Text = DTConfiguracion.Rows(78 - 1).Item("Value1Var")

            'Mostrar formulario de acceso rapido
            'ShowSearchingFast.Text = DTConfiguracion.Rows(102 - 1).Item("Value2Int")

            'Tipo de Bordes de Formulario
            If DTConfiguracion.Rows(48 - 1).Item("Value2Int") = 0 Then
                Me.FormBorderStyle = FormBorderStyle.Sizable
            ElseIf DTConfiguracion.Rows(48 - 1).Item("Value2Int") = 1 Then
                Me.FormBorderStyle = FormBorderStyle.None
            End If

            'Ocultar Iconos de Barra de Inicio
            If DTConfiguracion.Rows(38 - 1).Item("Value2Int") = 0 Then
                For Each OptionMenu As ToolStripMenuItem In MenuBar.Items
                    OptionMenu.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                Next
            Else
                For Each OptionMenu As ToolStripMenuItem In MenuBar.Items
                    OptionMenu.DisplayStyle = ToolStripItemDisplayStyle.Text
                Next
            End If

            'Habilitar modulo inventario
            InventarioToolStripMenuItem.Enabled = Convert.ToBoolean(CInt(DTModulos.Rows(1 - 1).Item("Habilitar")))
            InventarioToolStripMenuItem.Visible = Convert.ToBoolean(CInt(DTModulos.Rows(1 - 1).Item("Habilitar")))


            'Habilitar modulo facturacion
            FacturaciónToolStripMenuItem.Enabled = Convert.ToBoolean(CInt(DTModulos.Rows(2 - 1).Item("Habilitar")))
            FacturaciónToolStripMenuItem.Visible = Convert.ToBoolean(CInt(DTModulos.Rows(1 - 1).Item("Habilitar")))

            'Habilitar modulo CXC
            CuentasPorCobrarToolStripMenuItem.Enabled = Convert.ToBoolean(CInt(DTModulos.Rows(3 - 1).Item("Habilitar")))
            CuentasPorCobrarToolStripMenuItem.Visible = Convert.ToBoolean(CInt(DTModulos.Rows(3 - 1).Item("Habilitar")))

            'Habilitar modulo CXP
            CuentasPorPagarToolStripMenuItem.Enabled = Convert.ToBoolean(CInt(DTModulos.Rows(4 - 1).Item("Habilitar")))
            CuentasPorPagarToolStripMenuItem.Visible = Convert.ToBoolean(CInt(DTModulos.Rows(4 - 1).Item("Habilitar")))

            'Habilitar modulo Nómina
            RecursosHumanosToolStripMenuItem.Enabled = Convert.ToBoolean(CInt(DTModulos.Rows(5 - 1).Item("Habilitar")))
            RecursosHumanosToolStripMenuItem.Visible = Convert.ToBoolean(CInt(DTModulos.Rows(5 - 1).Item("Habilitar")))

            'Habilitar modulo Bancos
            BancosToolStripMenuItem.Enabled = Convert.ToBoolean(CInt(DTModulos.Rows(6 - 1).Item("Habilitar")))
            BancosToolStripMenuItem.Visible = Convert.ToBoolean(CInt(DTModulos.Rows(6 - 1).Item("Habilitar")))

            'Habilitar modulo supervisión
            SupervisiónToolStripMenuItem.Enabled = Convert.ToBoolean(CInt(DTModulos.Rows(7 - 1).Item("Habilitar")))
            SupervisiónToolStripMenuItem.Visible = Convert.ToBoolean(CInt(DTModulos.Rows(7 - 1).Item("Habilitar")))

            'Habilitar modulo caja chica
            CajaChicaToolStripMenuItem.Enabled = Convert.ToBoolean(CInt(DTModulos.Rows(8 - 1).Item("Habilitar")))
            CajaChicaToolStripMenuItem.Visible = Convert.ToBoolean(CInt(DTModulos.Rows(8 - 1).Item("Habilitar")))

            'Habilitar modulo contabilidad
            ContabilidadToolStripMenuItem.Enabled = Convert.ToBoolean(CInt(DTModulos.Rows(9 - 1).Item("Habilitar")))
            ContabilidadToolStripMenuItem.Visible = Convert.ToBoolean(CInt(DTModulos.Rows(9 - 1).Item("Habilitar")))

            'Habilitar modulo servicios
            ServiciosWebToolStripMenuItem.Enabled = Convert.ToBoolean(CInt(DTModulos.Rows(10 - 1).Item("Habilitar")))
            ServiciosWebToolStripMenuItem.Visible = Convert.ToBoolean(CInt(DTModulos.Rows(10 - 1).Item("Habilitar")))

            'Habilitar modulo estadisticicas
            EstadisticasToolStripMenuItem.Enabled = Convert.ToBoolean(CInt(DTModulos.Rows(11 - 1).Item("Habilitar")))
            EstadisticasToolStripMenuItem.Visible = Convert.ToBoolean(CInt(DTModulos.Rows(11 - 1).Item("Habilitar")))

            'Habilitar modulo ayuda
            AyudaToolStripMenuItem.Enabled = Convert.ToBoolean(CInt(DTModulos.Rows(12 - 1).Item("Habilitar")))
            AyudaToolStripMenuItem.Visible = Convert.ToBoolean(CInt(DTModulos.Rows(12 - 1).Item("Habilitar")))

            'Tipo de ventana
            cbxEstadoVentana.SelectedIndex = CInt(DTAreaImpresion.Rows(0).Item("SizeMode"))

            'Tamaño de UI
            CbxSizes.SelectedIndex = CInt(DTAreaImpresion.Rows(0).Item("SizeIndex"))

            'PrintMode
            cbxPrintMode.Tag = CInt(DTAreaImpresion.Rows(0).Item("PrinterMode"))
            If cbxPrintMode.Tag = 1 Then
                cbxPrintMode.Text = "Controlado por diseñador"
            ElseIf cbxPrintMode.Tag = 2 Then
                cbxPrintMode.Text = "Controlado por driver"
            ElseIf cbxPrintMode.Tag = 0 Then
                cbxPrintMode.Text = "Controlado por sistema"
            End If

            'Automatic StartUP
            chkAbrirAutomatico.Checked = Convert.ToBoolean(CInt(DTAreaImpresion.Rows(0).Item("AutomaticStartup")))

            'Mute App
            chkMuteApp.Checked = Convert.ToBoolean(CInt(DTAreaImpresion.Rows(0).Item("MuteApp")))

            'PreviewMode
            chkPreviewMode.Checked = Convert.ToBoolean(CInt(DTAreaImpresion.Rows(0).Item("PreviewMode")))

            'Permitir deshabilitar las notificaciones
            If CInt(DTConfiguracion.Rows(105 - 1).Item("Value2Int")) = 1 Then
                chkHabilitarNotify.Enabled = True
            Else
                chkHabilitarNotify.Enabled = False
                chkHabilitarNotify.Checked = False
            End If

            'Permitir deshabilitar el contenido de las notificaciones
            If CInt(DTConfiguracion.Rows(106 - 1).Item("Value2Int")) = 1 Then
                chkMostrarContenidoNotificacion.Enabled = True
            Else
                chkMostrarContenidoNotificacion.Enabled = False
                chkMostrarContenidoNotificacion.Checked = False
            End If

            'Permitir deshabilitar los consejos
            If CInt(DTConfiguracion.Rows(107 - 1).Item("Value2Int")) = 1 Then
                chkShowConsejos.Enabled = True
            Else
                chkShowConsejos.Enabled = False
                chkShowConsejos.Checked = False
            End If

            'Permitir deshabilitar el inicio automatico
            If CInt(DTConfiguracion.Rows(108 - 1).Item("Value2Int")) = 1 Then
                chkAbrirAutomatico.Enabled = True
            Else
                chkAbrirAutomatico.Enabled = False
                chkAbrirAutomatico.Checked = False
            End If

            'Permitir deshabilitar el bloqueo por inactividad
            If CInt(DTConfiguracion.Rows(109 - 1).Item("Value2Int")) = 1 Then
                ChkBloqueoInactividad.Enabled = True
            Else
                ChkBloqueoInactividad.Enabled = False
                ChkBloqueoInactividad.Checked = False
            End If

            'Tiempo de bloqueo en segundos
            'InactivityBlockTime = CInt(DTConfiguracion.Rows(110 - 1).Item("Value2Int"))

            'Permitir deshabilitar el audio
            If CInt(DTConfiguracion.Rows(111 - 1).Item("Value2Int")) = 1 Then
                chkMuteApp.Enabled = True
            Else
                chkMuteApp.Enabled = False
                chkMuteApp.Checked = False
            End If

            'Permitir contraer el encabezado del inicio
            If CInt(DTConfiguracion.Rows(112 - 1).Item("Value2Int")) = 0 Then
                Label41.Visible = False
                Label40.Visible = False
            End If

            'Permitir modificar modal del sistema
            If CInt(DTConfiguracion.Rows(113 - 1).Item("Value2Int")) = 1 Then
                chkMantenerDelante.Enabled = True
            Else
                chkMantenerDelante.Enabled = False
                chkMantenerDelante.Checked = False
            End If

            'Mostrar boton de asistencia en inicio
            PanelAsistencias.Visible = Convert.ToBoolean(CInt(DTConfiguracion.Rows(153 - 1).Item("Value2Int")))


            'Control de despacho en facturación
            'ControlDespacho.Text = DTConfiguracion.Rows(202 - 1).Item("Value2Int")

            'Tipo de consulta en el formulario de búsqueda de artículos
            'TipoConsulta.Text = DTConfiguracion.Rows(194 - 1).Item("Value2Int")

            'Verificar si hay black friday este año
            If CDate(DTConfiguracion.Rows(133 - 1).Item("Value4DateTime")).Year = Now.Year Then
                If CDate(DTConfiguracion.Rows(133 - 1).Item("Value4DateTime")).Month = Now.Month Then
                    If CDate(DTConfiguracion.Rows(133 - 1).Item("Value4DateTime")).Day > Now.Day Then
                        lblStatusBar.ForeColor = Color.Red
                        lblStatusBar.Text = "Black Friday: En sólo " & DateDiff("d", Now, CDate(DTConfiguracion.Rows(133 - 1).Item("Value4DateTime"))) & " día(s). Desde el " & CDate(DTConfiguracion.Rows(133 - 1).Item("Value4DateTime")) & " con grandes ofertas."
                    Else
                        'Si ya se liberaron los precios de black friday
                        If CInt(DTConfiguracion.Rows(132 - 1).Item("Value2Int")) = 1 Then
                            'Verifico la fecha de termino
                            If CDate(DTConfiguracion.Rows(134 - 1).Item("Value4DateTime")).Day > Now.Day Then
                                lblStatusBar.ForeColor = Color.Red
                                lblStatusBar.Text = "Estamos de Black Friday. Faltan " & DateDiff("d", Now, CDate(DTConfiguracion.Rows(134 - 1).Item("Value4DateTime"))) & " día(s) para finalizar el evento."
                            End If
                        End If

                    End If
                End If
            End If

            Hora.Enabled = True
            UpdateConUserTimer.Enabled = True

            Con.Close()


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CargarLibregco()
        Try
            lblStatusBar.Text = "Cargando volúmenes de Libregco."
            If TypeConnection.Text = 1 Then
                ConUtilitarios.Open()
                cmd = New MySqlCommand("Select LocacionLogo from libregco_utilitarios.version_sys where IDBuild=(Select Max(IDBuild) from version_sys)", ConUtilitarios)
                Dim Path As String = Convert.ToString(cmd.ExecuteScalar())
                ConUtilitarios.Close()

                'Mostrar aviso de mantenimiento
                If CInt(DTAjustes.Rows(7 - 1).Item("Value")) = 0 Then
                    FlowLayoutPanel1.Controls.Remove(PanelAviso)
                End If

                If Path = "" Then
                    PicLogo.Image = My.Resources.LibregcoCircle_x256
                    PicMinLogo.Image = My.Resources.LibregcoCircle_x256
                Else

                    Dim ExistFile As Boolean = System.IO.File.Exists("\\" & PathServidor.Text & Path)
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream("\\" & PathServidor.Text & Path, FileMode.Open, FileAccess.Read)
                        PicLogo.Image = System.Drawing.Image.FromStream(wFile)
                        PicMinLogo.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    End If
                End If
            Else

                PicLogo.Image = My.Resources.LibregcoCircle_x256
                PicMinLogo.Image = My.Resources.LibregcoCircle_x256
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarEmpresa()
        Try
            lblStatusBar.Text = "Cargando informaciones de la empresa."

            If DTEmpresa.Rows.Count > 0 Then
                lblRazon.Text = DTEmpresa.Rows(0).Item("NombreEmpresa")
                lblSlogan.Text = DTEmpresa.Rows(0).Item("Eslogan")

                lblRNC.Text = "RNC " & DTEmpresa.Rows(0).Item("RNC")

                PicBoxLogo.Image = ConseguirLogoEmpresa()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub SelectUsuario()
        'Try
        lblStatusBar.Text = "Cargando perfil del usuario."
        If DTEmpleado.Rows.Count > 0 Then

            If NuevaEstructuracion = True Then
                UserInfoPanel.Visible = True
                lblBienvenido.Text = "Bienvenido: SYSADMIN"
                lblNombre.Text = "ADMIN GRANT ALL RIGHTS"
                Button3.Text = "ADMIN"
                Button3.Image = My.Resources.ManUserx24
                lblCargo.Text = "DESIGNER"
                lblSucursal.ForeColor = PanelBussInfo.BackColor
                lblSucursal.Text = DTEmpleado.Rows(0).Item("Sucursal").ToString.ToUpper
                lblSucursal.BackColor = lblSeleccion.BackColor
                lblSucursal.Location = New Point(lblRazon.Right + 10, lblSucursal.Top + 4)
                lblSucursal.Visible = True
                txtNotas.Text = DTEmpleado.Rows(0).Item("Memos")

                If DTEmpleado.Rows(0).Item("NotificacionStart") = "" Then
                    ArNotificaciones = ("0,0,0,0,0,0,0").ToString.Split(",")
                Else
                    ArNotificaciones = DTEmpleado.Rows(0).Item("NotificacionStart").ToString.Split(",")
                End If

                If ArNotificaciones(0) = 0 Then
                    chkNotificacionChat.IsOn = False
                Else
                    chkNotificacionChat.IsOn = True
                End If
                If ArNotificaciones(1) = 0 Then
                    chkNotificacionCumpleanos.IsOn = False
                Else
                    chkNotificacionCumpleanos.IsOn = True
                End If
                If ArNotificaciones(2) = 0 Then
                    chkNotificacionRecordatorio.IsOn = False
                Else
                    chkNotificacionRecordatorio.IsOn = True
                End If
                If ArNotificaciones(3) = 0 Then
                    chkNotificacionSolicitudes.IsOn = False
                Else
                    chkNotificacionSolicitudes.IsOn = True
                End If
                If ArNotificaciones(4) = 0 Then
                    chkNotificacionAlertas.IsOn = False
                Else
                    chkNotificacionAlertas.IsOn = True
                End If
                If ArNotificaciones(5) = 0 Then
                    chkNotificacionAgenda.IsOn = False
                Else
                    chkNotificacionAgenda.IsOn = True
                End If

                If ArNotificaciones.Count < 7 Then
                    chkBoucher.IsOn = True
                    ArNotificaciones = Split(Join(ArNotificaciones, ",") + ",1")
                Else
                    If ArNotificaciones(6) = 0 Then
                        chkBoucher.IsOn = False
                    Else
                        chkBoucher.IsOn = True
                    End If
                End If

                If DTEmpleado.Rows(0).Item("DireccionSucursal") <> "" Then
                    lblDireccion.Text = DTEmpleado.Rows(0).Item("DireccionSucursal")
                End If
                If DTEmpleado.Rows(0).Item("Telefono") <> "" Then
                    lblDireccion.Text = lblDireccion.Text & ", " & DTEmpleado.Rows(0).Item("Telefono")
                End If
                If DTEmpleado.Rows(0).Item("Telefono1") <> "" Then
                    lblDireccion.Text = lblDireccion.Text & ", " & DTEmpleado.Rows(0).Item("Telefono1")
                End If
                If DTEmpleado.Rows(0).Item("Telefono2") <> "" Then
                    lblDireccion.Text = lblDireccion.Text & ", " & DTEmpleado.Rows(0).Item("Telefono2")
                End If
                If DTEmpleado.Rows(0).Item("Fax") <> "" Then
                    lblDireccion.Text = lblDireccion.Text & ", Fax: " & DTEmpleado.Rows(0).Item("Fax")
                End If

                UsuariosToolStripMenuItem.Image = My.Resources.People_User
                PicEmpleado.Image = My.Resources.LibregcoCircle_x256

            Else
                If DTEmpleado.Rows(0).Item("ColorMode") = 1 Then
                    rdbOscuro.Checked = True
                    Panel5.BackColor = Color.FromArgb(255, 88, 88, 88)
                    Panel7.BackColor = Color.FromArgb(255, 88, 88, 88)
                    Label6.ForeColor = SystemColors.ButtonFace
                    Label8.ForeColor = SystemColors.ButtonFace
                    MenúToolStripMenuItem.ForeColor = SystemColors.ControlLight
                    InfoToolStripMenuItem.ForeColor = SystemColors.ControlLight
                    MenúToolStripMenuItem.Image = My.Resources.MenuWhitex26
                    InfoToolStripMenuItem.Image = My.Resources.InfoWhitex26
                    ConfiguraciónToolStripMenuItem.ForeColor = SystemColors.ControlLight
                    ConfiguraciónToolStripMenuItem.Image = My.Resources.SettingsWhitex26
                    ToolStripMenuItem2.Image = My.Resources.Networkx26
                    ToolStripMenuItem2.ForeColor = SystemColors.ControlLight
                    Label40.Image = My.Resources.ExpandArrowWhitex26
                    Label41.Image = My.Resources.CompressWhitex26
                    TabPage1.BackColor = Color.FromArgb(255, 88, 88, 88)
                    TabPage2.BackColor = Color.FromArgb(255, 88, 88, 88)
                    TabPage3.BackColor = Color.FromArgb(255, 88, 88, 88)
                    TabPage4.BackColor = Color.FromArgb(255, 88, 88, 88)
                    TabPage5.BackColor = Color.FromArgb(255, 88, 88, 88)
                    TabPage6.BackColor = Color.FromArgb(255, 88, 88, 88)
                    FlowLayoutPanel1.BackColor = Panel7.BackColor
                    Me.BackColor = Color.FromArgb(255, 88, 88, 88)
                    SplitContainer1.Panel1.BackColor = Color.FromArgb(255, 88, 88, 88)
                    SplitContainer1.Panel2.BackColor = Color.FromArgb(255, 88, 88, 88)
                    SplitContainer1.BackColor = Color.FromArgb(255, 88, 88, 88)
                    Label8.ForeColor = Color.White
                    Label9.ForeColor = Color.White
                    lblFecha.ForeColor = SystemColors.ControlLight
                    lblHora.ForeColor = SystemColors.ControlLight
                    DgvConversations.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 88, 88, 88)
                    DgvConversations.DefaultCellStyle.SelectionForeColor = SystemColors.ControlLight
                    PictureBox1.Image = My.Resources.BusquedaMenuWhitex48
                    NavigationPane2.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
                    NavBarControl4.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
                    NavigationPane2.Pages(0).ImageOptions.Image = My.Resources.Social1White
                    NavigationPane2.Pages(1).ImageOptions.Image = My.Resources.NotesWhite
                    NavigationPane2.Pages(2).ImageOptions.Image = My.Resources.ClockWhite
                    NavigationPane2.Pages(3).ImageOptions.Image = My.Resources.WarningWhite
                    NavigationPane2.Pages(4).ImageOptions.Image = My.Resources.ScheduleWhite
                    NavigationPane2.Pages(5).ImageOptions.Image = My.Resources.chartwhite
                    NavBarMensajeria.ImageOptions.LargeImage = My.Resources.chat32White
                    NavBarCumpleanos.ImageOptions.LargeImage = My.Resources.Cake32White
                    NavBarNotas.ImageOptions.LargeImage = My.Resources.notes32White
                    NavBarRecordatorios.ImageOptions.LargeImage = My.Resources.reminder32White
                    NavBarSolicitudes.ImageOptions.LargeImage = My.Resources.solicitudes32White
                    NavBarContactos.ImageOptions.LargeImage = My.Resources.Contact32White
                    NavAlertas.ImageOptions.LargeImage = My.Resources.clockwhite_32
                    NavBouchers.ImageOptions.LargeImage = My.Resources.boucherwhite_32
                    btnIrAgenda.ImageOptions.Image = My.Resources.Calendar32White
                    LabelControl6.ForeColor = Color.White
                    LabelControl7.ForeColor = Color.White
                    LabelControl8.ForeColor = Color.White
                    LabelControl9.ForeColor = Color.White
                    LabelControl10.ForeColor = Color.White

                    frm_agenda.BarAndDockingController1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
                    frm_agenda.RangeControl1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
                    frm_agenda.SchedulerControl1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
                    txtNotas.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
                    SimpleButton1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
                    LabelControl6.ForeColor = Color.White
                Else
                    rdbClaro.Checked = True
                    Panel5.BackColor = Color.FromArgb(255, 250, 250, 250)
                    Panel7.BackColor = Color.FromArgb(255, 230, 230, 230)
                    FlowLayoutPanel1.BackColor = Panel7.BackColor
                    Label6.ForeColor = Color.Black
                    Label8.ForeColor = Color.Black
                    MenúToolStripMenuItem.ForeColor = Color.Black
                    InfoToolStripMenuItem.ForeColor = Color.Black
                    ConfiguraciónToolStripMenuItem.ForeColor = Color.Black
                    MenúToolStripMenuItem.Image = My.Resources.MenuBlackx26
                    InfoToolStripMenuItem.Image = My.Resources.InfoBlackx26
                    ConfiguraciónToolStripMenuItem.Image = My.Resources.SettingsBlack26
                    ToolStripMenuItem2.Image = My.Resources.Networkx26Black
                    ToolStripMenuItem2.ForeColor = Color.Black
                    Label40.Image = My.Resources.ExpandArrowBlackx26
                    Label41.Image = My.Resources.CompressBackx26
                    TabPage1.BackColor = SystemColors.ControlLight
                    TabPage2.BackColor = SystemColors.ControlLight
                    TabPage3.BackColor = SystemColors.ControlLight
                    TabPage4.BackColor = SystemColors.ControlLight
                    TabPage5.BackColor = SystemColors.ControlLight
                    TabPage6.BackColor = SystemColors.ControlLight
                    SplitContainer1.Panel1.BackColor = SystemColors.ControlLight
                    SplitContainer1.Panel2.BackColor = SystemColors.ControlLight
                    SplitContainer1.BackColor = SystemColors.ControlLight
                    Label8.ForeColor = Color.Black
                    Label9.ForeColor = Color.Black
                    lblFecha.ForeColor = Color.Black
                    lblHora.ForeColor = Color.Black
                    Me.BackColor = SystemColors.ControlLight
                    DgvConversations.DefaultCellStyle.SelectionBackColor = SystemColors.ControlLight
                    DgvConversations.DefaultCellStyle.SelectionForeColor = Color.Black
                    PictureBox1.Image = My.Resources.BusquedaMenux48
                    NavigationPane2.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
                    NavigationPane2.Pages(0).ImageOptions.Image = My.Resources.Social1Black
                    NavigationPane2.Pages(1).ImageOptions.Image = My.Resources.NotesBlack
                    NavigationPane2.Pages(2).ImageOptions.Image = My.Resources.ClockBlack
                    NavigationPane2.Pages(3).ImageOptions.Image = My.Resources.WarningBlack
                    NavigationPane2.Pages(4).ImageOptions.Image = My.Resources.ScheduleBlack
                    NavigationPane2.Pages(5).ImageOptions.Image = My.Resources.chartblack
                    NavBarMensajeria.ImageOptions.LargeImage = My.Resources.chat32Black
                    NavBarCumpleanos.ImageOptions.LargeImage = My.Resources.Cake32Black
                    NavBarControl4.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
                    NavBarNotas.ImageOptions.LargeImage = My.Resources.Notes32Black
                    NavBarRecordatorios.ImageOptions.LargeImage = My.Resources.reminder32Black
                    NavBarSolicitudes.ImageOptions.LargeImage = My.Resources.solicitudes32Black
                    NavBarContactos.ImageOptions.LargeImage = My.Resources.Contact32Black
                    btnIrAgenda.ImageOptions.Image = My.Resources.Calendar32Black
                    NavAlertas.ImageOptions.LargeImage = My.Resources.clockblack_32
                    NavBouchers.ImageOptions.LargeImage = My.Resources.boucherblack_32
                    frm_agenda.BarAndDockingController1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
                    frm_agenda.RangeControl1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
                    frm_agenda.SchedulerControl1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
                    txtNotas.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
                    SimpleButton1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
                    LabelControl6.ForeColor = Color.Black
                    LabelControl7.ForeColor = Color.Black
                    LabelControl8.ForeColor = Color.Black
                    LabelControl9.ForeColor = Color.Black
                    LabelControl10.ForeColor = Color.Black
                End If

                ToolStripMenuItem2.Visible = True

                Button3.Text = DTEmpleado.Rows(0).Item("Login")
                lblBienvenido.Text = "Bienvenido: " & DTEmpleado.Rows(0).Item("Login") & " [ " & DTEmpleado.Rows(0).Item("IDEmpleado") & " ]"
                lblNombre.Text = DTEmpleado.Rows(0).Item("Nombre")
                lblCargo.Text = UCase(DTEmpleado.Rows(0).Item("Cargo"))
                lblSucursal.ForeColor = PanelBussInfo.BackColor
                lblSucursal.Text = DTEmpleado.Rows(0).Item("Sucursal").ToString.ToUpper
                lblSucursal.BackColor = Color.WhiteSmoke
                lblSucursal.Location = New Point(lblRazon.Right + 10, lblSucursal.Top + 4)
                lblSucursal.Visible = True
                txtNotas.Text = DTEmpleado.Rows(0).Item("Memos")

                If DTEmpleado.Rows(0).Item("NotificacionStart") = "" Then
                    ArNotificaciones = ("0,0,0,0,0,0,0").ToString.Split(",")
                Else
                    ArNotificaciones = DTEmpleado.Rows(0).Item("NotificacionStart").ToString.Split(",")
                End If

                If ArNotificaciones(0) = 0 Then
                    chkNotificacionChat.IsOn = False
                Else
                    chkNotificacionChat.IsOn = True
                End If
                If ArNotificaciones(1) = 0 Then
                    chkNotificacionCumpleanos.IsOn = False
                Else
                    chkNotificacionCumpleanos.IsOn = True
                End If
                If ArNotificaciones(2) = 0 Then
                    chkNotificacionRecordatorio.IsOn = False
                Else
                    chkNotificacionRecordatorio.IsOn = True
                End If
                If ArNotificaciones(3) = 0 Then
                    chkNotificacionSolicitudes.IsOn = False
                Else
                    chkNotificacionSolicitudes.IsOn = True
                End If
                If ArNotificaciones(4) = 0 Then
                    chkNotificacionAlertas.IsOn = False
                Else
                    chkNotificacionAlertas.IsOn = True
                End If
                If ArNotificaciones(5) = 0 Then
                    chkNotificacionAgenda.IsOn = False
                Else
                    chkNotificacionAgenda.IsOn = True
                End If

                If ArNotificaciones.Count < 7 Then
                    chkBoucher.IsOn = True
                    ArNotificaciones = Split(Join(ArNotificaciones, ",") + ",1")
                Else
                    If ArNotificaciones(6) = 0 Then
                        chkBoucher.IsOn = False
                    Else
                        chkBoucher.IsOn = True
                    End If
                End If

                If DTEmpleado.Rows(0).Item("DireccionSucursal") <> "" Then
                    lblDireccion.Text = DTEmpleado.Rows(0).Item("DireccionSucursal")
                End If
                If DTEmpleado.Rows(0).Item("Telefono") <> "" Then
                    lblDireccion.Text = lblDireccion.Text & ", " & DTEmpleado.Rows(0).Item("Telefono")
                End If
                If DTEmpleado.Rows(0).Item("Telefono1") <> "" Then
                    lblDireccion.Text = lblDireccion.Text & ", " & DTEmpleado.Rows(0).Item("Telefono1")
                End If
                If DTEmpleado.Rows(0).Item("Telefono2") <> "" Then
                    lblDireccion.Text = lblDireccion.Text & ", " & DTEmpleado.Rows(0).Item("Telefono2")
                End If
                If DTEmpleado.Rows(0).Item("Fax") <> "" Then
                    lblDireccion.Text = lblDireccion.Text & ", Fax: " & DTEmpleado.Rows(0).Item("Fax")
                End If

                If DTEmpleado.Rows(0).Item("IDGenero") = 1 Then
                    UsuariosToolStripMenuItem.Image = My.Resources.Women_User
                    UsuariosToolStripMenuItem.Tag = 1
                    Button3.Image = My.Resources.FemaleUserx24
                    Button3.BackColor = Color.Purple
                    Button3.FlatAppearance.BorderColor = Button3.BackColor
                    Button3.FlatAppearance.MouseOverBackColor = Button3.BackColor
                    Button3.FlatAppearance.MouseDownBackColor = Color.DarkMagenta

                ElseIf DTEmpleado.Rows(0).Item("IDGenero") = 2 Then
                    UsuariosToolStripMenuItem.Image = My.Resources.Men_User
                    UsuariosToolStripMenuItem.Tag = 2
                    Button3.Image = My.Resources.ManUserx24
                    Button3.BackColor = Color.FromArgb(255, 25, 40, 40)
                    Button3.FlatAppearance.BorderColor = Button3.BackColor
                    Button3.FlatAppearance.MouseOverBackColor = Button3.BackColor
                    Button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 25, 60, 40)

                Else
                    UsuariosToolStripMenuItem.Image = My.Resources.People_User
                    UsuariosToolStripMenuItem.Tag = 2
                    Button3.Image = My.Resources.ManUserx24
                    Button3.BackColor = Color.FromArgb(255, 25, 40, 40)
                    Button3.FlatAppearance.BorderColor = Button3.BackColor
                    Button3.FlatAppearance.MouseOverBackColor = Button3.BackColor
                    Button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 25, 60, 40)
                End If

                If TypeConnection.Text = 1 Then
                    If DTEmpleado.Rows(0).Item("ImagenChat") = "" Then
                        If DTEmpleado.Rows(0).Item("RutaFoto") = "" Then
                            'xUserInfoPanel.Visible = False
                        Else
                            Dim ExistFile As Boolean = System.IO.File.Exists(DTEmpleado.Rows(0).Item("RutaFoto"))
                            If ExistFile = True Then
                                UserInfoPanel.Visible = True
                                Dim wFile As System.IO.FileStream = New FileStream(DTEmpleado.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                                MakeRoundedImage(System.Drawing.Image.FromStream(wFile), PicEmpleado)
                                NormalPicture = System.Drawing.Image.FromStream(wFile)
                                NormalPicturePath = DTEmpleado.Rows(0).Item("RutaFoto")
                                wFile.Close()
                            Else
                                NormalPicturePath = ""
                            End If
                        End If

                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists(DTEmpleado.Rows(0).Item("ImagenChat"))
                        If ExistFile = True Then
                            UserInfoPanel.Visible = True
                            Dim wFile As System.IO.FileStream = New FileStream(DTEmpleado.Rows(0).Item("ImagenChat"), FileMode.Open, FileAccess.Read)
                            MakeRoundedImage(System.Drawing.Image.FromStream(wFile), PicEmpleado)
                            NormalPicture = System.Drawing.Image.FromStream(wFile)
                            NormalPicturePath = DTEmpleado.Rows(0).Item("ImagenChat")
                            wFile.Close()
                        Else
                            NormalPicturePath = ""
                        End If
                    End If


                    'Verificando GrayPictureFile
                    If DTEmpleado.Rows(0).Item("GrayPictureFile") <> "" Then
                        If System.IO.File.Exists(DTEmpleado.Rows(0).Item("GrayPictureFile")) = True Then
                            Dim CFile As System.IO.FileStream = New FileStream(DTEmpleado.Rows(0).Item("GrayPictureFile"), FileMode.Open, FileAccess.Read)
                            GrayPicture = System.Drawing.Image.FromStream(CFile)
                            GrayPicturePath = DTEmpleado.Rows(0).Item("GrayPictureFile")
                            CFile.Close()
                        Else
                            If NormalPicturePath <> "" And System.IO.File.Exists(NormalPicturePath) = True Then
                                Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Empleados\Chat\[" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString & "] " & "Gray-" & lblNombre.Text & ".png"
                                Dim GrayBitmap As Bitmap = ConvertToGrayScale(Image.FromFile(NormalPicturePath))

                                GrayBitmap.Save(RutaDestino, System.Drawing.Imaging.ImageFormat.Jpeg)

                                sqlQ = "UPDATE Empleados SET GrayPictureFile='" + Replace(RutaDestino, "\", "\\") + "' WHERE IDEmpleado= '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"

                                ConLibregco.Open()
                                cmd = New MySqlCommand(sqlQ, ConLibregco)
                                cmd.ExecuteNonQuery()
                                ConLibregco.Close()

                                ConLibregcoMain.Open()
                                cmd = New MySqlCommand(sqlQ, ConLibregcoMain)
                                cmd.ExecuteNonQuery()
                                ConLibregcoMain.Close()

                                Dim CFile As System.IO.FileStream = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                                GrayPicture = System.Drawing.Image.FromStream(CFile)
                                GrayPicturePath = RutaDestino
                                CFile.Close()
                            End If

                        End If

                    Else
                        If NormalPicturePath <> "" And System.IO.File.Exists(NormalPicturePath) = True Then
                            Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Empleados\Chat\[" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString & "] " & "Gray-" & lblNombre.Text & ".png"
                            Dim GrayBitmap As Bitmap = ConvertToGrayScale(Image.FromFile(NormalPicturePath))

                            GrayBitmap.Save(RutaDestino, System.Drawing.Imaging.ImageFormat.Jpeg)

                            sqlQ = "UPDATE Empleados SET GrayPictureFile='" + Replace(RutaDestino, "\", "\\") + "' WHERE IDEmpleado= '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"

                            ConLibregco.Open()
                            cmd = New MySqlCommand(sqlQ, ConLibregco)
                            cmd.ExecuteNonQuery()
                            ConLibregco.Close()

                            ConLibregcoMain.Open()
                            cmd = New MySqlCommand(sqlQ, ConLibregcoMain)
                            cmd.ExecuteNonQuery()
                            ConLibregcoMain.Close()

                            Dim CFile As System.IO.FileStream = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                            GrayPicture = System.Drawing.Image.FromStream(CFile)
                            GrayPicturePath = RutaDestino
                            CFile.Close()
                        End If

                    End If


                Else
                    'xUserInfoPanel.Visible = False
                End If

                DgvAlertas.Visible = Convert.ToBoolean(CInt(DTEmpleado.Rows(0).Item("Alertas")))

                'Configuraciones
                If chkMantenerDelante.Enabled = True Then
                    chkMantenerDelante.Checked = Convert.ToBoolean(CInt(DTEmpleado.Rows(0).Item("MostrarenTope")))
                End If

                If chkHabilitarNotify.Enabled = True Then
                    chkHabilitarNotify.Checked = Convert.ToBoolean(CInt(DTEmpleado.Rows(0).Item("HabilitarNotificaciones")))
                End If

                If chkMostrarContenidoNotificacion.Enabled = True Then
                    chkMostrarContenidoNotificacion.Checked = Convert.ToBoolean(CInt(DTEmpleado.Rows(0).Item("MostrarContenido")))
                End If

                If chkShowConsejos.Enabled = True Then
                    chkShowConsejos.Checked = Convert.ToBoolean(CInt(DTEmpleado.Rows(0).Item("MostrarConsejos")))
                End If

                If ChkBloqueoInactividad.Enabled = True Then
                    ChkBloqueoInactividad.Checked = Convert.ToBoolean(CInt(DTEmpleado.Rows(0).Item("BloqueoInactividad")))
                End If

            End If

        End If

        Button4.Text = DTAreaImpresion.Rows(0).Item("ComputerName").ToString.ToUpper

        'Catch ex As Exception

        '    If Con.State = ConnectionState.Open Then
        '        Con.Close()
        '    End If

        'MessageBox.Show(ex.Message.ToString)
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub CambiarUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarUsuarioToolStripMenuItem.Click
        CerrarSistemaToolStripMenuItem.Tag = 1
        Me.Close()
    End Sub

    Private Sub CerrarSistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSistemaToolStripMenuItem.Click
        CerrarSistemaToolStripMenuItem.Tag = 0
        Me.Close()
    End Sub

    Private Sub UsuariosToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem.MouseEnter
        lblSeleccion.Text = UsuariosToolStripMenuItem.Text
    End Sub

    Private Sub UsuariosToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles UsuariosToolStripMenuItem.MouseLeave
        lblSeleccion.Text = "Inicio"
    End Sub

    Private Sub AjustesToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles AjustesToolStripMenuItem.MouseEnter
        lblSeleccion.Text = AjustesToolStripMenuItem.Text
    End Sub

    Private Sub AjustesToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles AjustesToolStripMenuItem.MouseLeave
        lblSeleccion.Text = "Inicio"
    End Sub

    Private Sub SalirToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.MouseLeave
        lblSeleccion.Text = "Inicio"
    End Sub

    Private Sub SalirToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.MouseEnter
        lblSeleccion.Text = SalirToolStripMenuItem.Text
    End Sub

    Private Sub CambiarFondoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarFondoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cambiar_fondoinicio.Visible = True Then
            If frm_cambiar_fondoinicio.WindowState = FormWindowState.Minimized Then
                frm_cambiar_fondoinicio.WindowState = FormWindowState.Normal
            Else
                frm_cambiar_fondoinicio.Activate()
            End If
        Else
            frm_cambiar_fondoinicio.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SuplidorToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_suplidor.Visible = True Then
            If frm_mant_suplidor.WindowState = FormWindowState.Minimized Then
                frm_mant_suplidor.WindowState = FormWindowState.Normal
            Else
                frm_mant_suplidor.Activate()
            End If
        Else
            frm_mant_suplidor.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub FacturaciónConInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturaciónConInventarioToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_facturacion.Visible = True Then
            If frm_facturacion.WindowState = FormWindowState.Minimized Then
                frm_facturacion.WindowState = FormWindowState.Normal
            Else
                frm_facturacion.Activate()
            End If
        Else
            frm_facturacion.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ReciboDeIngresoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReciboDeIngresoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_recibo_pagos.Visible = True Then
            If frm_recibo_pagos.WindowState = FormWindowState.Minimized Then
                frm_recibo_pagos.WindowState = FormWindowState.Normal
            Else
                frm_recibo_pagos.Activate()
            End If
        Else
            frm_recibo_pagos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SecuenciasNCFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SecuenciasNCFToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_ncf.Visible = True Then
            If frm_mant_ncf.WindowState = FormWindowState.Minimized Then
                frm_mant_ncf.WindowState = FormWindowState.Normal
            Else
                frm_mant_ncf.Activate()
            End If
        Else
            frm_mant_ncf.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RegistrarAlmacenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarAlmacenToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_almacen.Visible = True Then
            If frm_mant_almacen.WindowState = FormWindowState.Minimized Then
                frm_mant_almacen.WindowState = FormWindowState.Normal
            Else
                frm_mant_almacen.Activate()
            End If
        Else
            frm_mant_almacen.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RegistrarProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarProductoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_articulos.Visible = True Then
            If frm_mant_articulos.WindowState = FormWindowState.Minimized Then
                frm_mant_articulos.WindowState = FormWindowState.Normal
            Else
                frm_mant_articulos.Activate()
            End If
        Else
            frm_mant_articulos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RegistrarDepartamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarDepartamentoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_departamentos.Visible = True Then
            If frm_mant_departamentos.WindowState = FormWindowState.Minimized Then
                frm_mant_departamentos.WindowState = FormWindowState.Normal
            Else
                frm_mant_departamentos.Activate()
            End If
        Else
            frm_mant_departamentos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RegistrarITBISToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarITBISToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_itbis.Visible = True Then
            If frm_mant_itbis.WindowState = FormWindowState.Minimized Then
                frm_mant_itbis.WindowState = FormWindowState.Normal
            Else
                frm_mant_itbis.Activate()
            End If
        Else
            frm_mant_itbis.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RegistrarMedidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarMedidaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_medidas.Visible = True Then
            If frm_mant_medidas.WindowState = FormWindowState.Minimized Then
                frm_mant_medidas.WindowState = FormWindowState.Normal
            Else
                frm_mant_medidas.Activate()
            End If
        Else
            frm_mant_medidas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub VehículosToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles VehículosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_vehiculos.Visible = True Then
            If frm_mant_vehiculos.WindowState = FormWindowState.Minimized Then
                frm_mant_vehiculos.WindowState = FormWindowState.Normal
            Else
                frm_mant_vehiculos.Activate()
            End If
        Else
            frm_mant_vehiculos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ClientesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_clientes.Visible = True Then
            If frm_mant_clientes.WindowState = FormWindowState.Minimized Then
                frm_mant_clientes.WindowState = FormWindowState.Normal
            Else
                frm_mant_clientes.Activate()
            End If
        Else
            frm_mant_clientes.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ReferenciasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReferenciasToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_referencias.Visible = True Then
            If frm_mant_referencias.WindowState = FormWindowState.Minimized Then
                frm_mant_referencias.WindowState = FormWindowState.Normal
            Else
                frm_mant_referencias.Activate()
            End If
        Else
            frm_mant_referencias.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SuplidorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuplidorToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_suplidor.Visible = True Then
            If frm_mant_suplidor.WindowState = FormWindowState.Minimized Then
                frm_mant_suplidor.WindowState = FormWindowState.Normal
            Else
                frm_mant_suplidor.Activate()
            End If
        Else
            frm_mant_suplidor.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EmpleadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpleadosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_empleados.Visible = True Then
            If frm_mant_empleados.WindowState = FormWindowState.Minimized Then
                frm_mant_empleados.WindowState = FormWindowState.Normal
            Else
                frm_mant_empleados.Activate()
            End If
        Else
            frm_mant_empleados.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PrestacionesLaboralesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrestacionesLaboralesToolStripMenuItem.Click
        LlamarPrestacionesLaborales()
    End Sub

    Private Sub TSSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSSToolStripMenuItem.Click
        LlamarWebTSS()
    End Sub

    Private Sub ConsultasDeRNCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultasDeRNCToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_rnc.Visible = True Then
            If frm_consulta_rnc.WindowState = FormWindowState.Minimized Then
                frm_consulta_rnc.WindowState = FormWindowState.Normal
            Else
                frm_consulta_rnc.Activate()
            End If
        Else
            frm_consulta_rnc.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub AjusteDeInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjusteDeInventarioToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_ajuste_inventario.Visible = True Then
            If frm_ajuste_inventario.WindowState = FormWindowState.Minimized Then
                frm_ajuste_inventario.WindowState = FormWindowState.Normal
            Else
                frm_ajuste_inventario.Activate()
            End If
        Else
            frm_ajuste_inventario.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_registro_compras.Visible = True Then
            If frm_registro_compras.WindowState = FormWindowState.Minimized Then
                frm_registro_compras.WindowState = FormWindowState.Normal
            Else
                frm_registro_compras.Activate()
            End If
        Else
            frm_registro_compras.Show(Me)
        End If

        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RegistrarFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarFacturaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_factura_cxp.Visible = True Then
            If frm_factura_cxp.WindowState = FormWindowState.Minimized Then
                frm_factura_cxp.WindowState = FormWindowState.Normal
            Else
                frm_factura_cxp.Activate()
            End If
        Else
            frm_factura_cxp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PagosDeFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagosDeFacturaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_pago_compras.Visible = True Then
            If frm_pago_compras.WindowState = FormWindowState.Minimized Then
                frm_pago_compras.WindowState = FormWindowState.Normal
            Else
                frm_pago_compras.Activate()
            End If
        Else
            frm_pago_compras.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ChequesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChequesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cheques.Visible = True Then
            If frm_cheques.WindowState = FormWindowState.Minimized Then
                frm_cheques.WindowState = FormWindowState.Normal
            Else
                frm_cheques.Activate()
            End If
        Else
            frm_cheques.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CuentasBancariasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuentasBancariasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_registro_cuentasbancarias.Visible = True Then
            If frm_registro_cuentasbancarias.WindowState = FormWindowState.Minimized Then
                frm_registro_cuentasbancarias.WindowState = FormWindowState.Normal
            Else
                frm_registro_cuentasbancarias.Activate()
            End If
        Else
            frm_registro_cuentasbancarias.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub HistorialSuplidorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialSuplidorToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_historial_suplidor.Visible = True Then
            If frm_historial_suplidor.WindowState = FormWindowState.Minimized Then
                frm_historial_suplidor.WindowState = FormWindowState.Normal
            Else
                frm_historial_suplidor.Activate()
            End If
        Else
            frm_historial_suplidor.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub HistorialDePagosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialDePagosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_historialpagos.Visible = True Then
            If frm_historialpagos.WindowState = FormWindowState.Minimized Then
                frm_historialpagos.WindowState = FormWindowState.Normal
            Else
                frm_historialpagos.Activate()
            End If
        Else
            frm_historialpagos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub MonedasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonedasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_tipo_moneda.Visible = True Then
            If frm_mant_tipo_moneda.WindowState = FormWindowState.Minimized Then
                frm_mant_tipo_moneda.WindowState = FormWindowState.Normal
            Else
                frm_mant_tipo_moneda.Activate()
            End If
        Else
            frm_mant_tipo_moneda.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ConsultaDeMemosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeMemosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_memosclientes.Visible = True Then
            If frm_consulta_memosclientes.WindowState = FormWindowState.Minimized Then
                frm_consulta_memosclientes.WindowState = FormWindowState.Normal
            Else
                frm_consulta_memosclientes.Activate()
            End If
        Else
            frm_consulta_memosclientes.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub MemosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_memos_cliente.Visible = True Then
            If frm_mant_memos_cliente.WindowState = FormWindowState.Minimized Then
                frm_mant_memos_cliente.WindowState = FormWindowState.Normal
            Else
                frm_mant_memos_cliente.Activate()
            End If
        Else
            frm_mant_memos_cliente.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CotizaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CotizaciónToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cotizacion.Visible = True Then
            If frm_cotizacion.WindowState = FormWindowState.Minimized Then
                frm_cotizacion.WindowState = FormWindowState.Normal
            Else
                frm_cotizacion.Activate()
            End If
        Else
            frm_cotizacion.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_ventas.Visible = True Then
            If frm_consulta_ventas.WindowState = FormWindowState.Minimized Then
                frm_consulta_ventas.WindowState = FormWindowState.Normal
            Else
                frm_consulta_ventas.Activate()
            End If
        Else
            frm_consulta_ventas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TransferenciaDeInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransferenciaDeInventarioToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_transferencia_arts.Visible = True Then
            If frm_transferencia_arts.WindowState = FormWindowState.Minimized Then
                frm_transferencia_arts.WindowState = FormWindowState.Normal
            Else
                frm_transferencia_arts.Activate()
            End If
        Else
            frm_transferencia_arts.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub InventarioInicialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventarioInicialToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_inv_inicial.Visible = True Then
            If frm_inv_inicial.WindowState = FormWindowState.Minimized Then
                frm_inv_inicial.WindowState = FormWindowState.Normal
            Else
                frm_inv_inicial.Activate()
            End If
        Else
            frm_inv_inicial.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EntCuadreDeCajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntCuadreDeCajaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_conteo_cuadre_de_caja.Visible = True Then
            If frm_conteo_cuadre_de_caja.WindowState = FormWindowState.Minimized Then
                frm_conteo_cuadre_de_caja.WindowState = FormWindowState.Normal
            Else
                frm_conteo_cuadre_de_caja.Activate()
            End If
        Else
            frm_conteo_cuadre_de_caja.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub BancosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BancosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_bancos.Visible = True Then
            If frm_mant_bancos.WindowState = FormWindowState.Minimized Then
                frm_mant_bancos.WindowState = FormWindowState.Normal
            Else
                frm_mant_bancos.Activate()
            End If
        Else
            frm_mant_bancos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DevoluciónDeVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevoluciónDeVentaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_devolucion_fact.Visible = True Then
            If frm_devolucion_fact.WindowState = FormWindowState.Minimized Then
                frm_devolucion_fact.WindowState = FormWindowState.Normal
            Else
                frm_devolucion_fact.Activate()
            End If
        Else
            frm_devolucion_fact.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DevolucionesDeVentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevolucionesDeVentaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_devolucion_venta.Visible = True Then
            If frm_consulta_devolucion_venta.WindowState = FormWindowState.Minimized Then
                frm_consulta_devolucion_venta.WindowState = FormWindowState.Normal
            Else
                frm_consulta_devolucion_venta.Activate()
            End If
        Else
            frm_consulta_devolucion_venta.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub MovimientosBancariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosBancariosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_movimientos_bancarios.Visible = True Then
            If frm_consulta_movimientos_bancarios.WindowState = FormWindowState.Minimized Then
                frm_consulta_movimientos_bancarios.WindowState = FormWindowState.Normal
            Else
                frm_consulta_movimientos_bancarios.Activate()
            End If
        Else
            frm_consulta_movimientos_bancarios.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub MovimientosBancarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosBancarioToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_movimientos_bancarios.Visible = True Then
            If frm_movimientos_bancarios.WindowState = FormWindowState.Minimized Then
                frm_movimientos_bancarios.WindowState = FormWindowState.Normal
            Else
                frm_movimientos_bancarios.Activate()
            End If
        Else
            frm_movimientos_bancarios.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub MarcasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_marcas.Visible = True Then
            If frm_mant_marcas.WindowState = FormWindowState.Minimized Then
                frm_mant_marcas.WindowState = FormWindowState.Normal
            Else
                frm_mant_marcas.Activate()
            End If
        Else
            frm_mant_marcas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CategoríasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoríasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_categorias.Visible = True Then
            If frm_mant_categorias.WindowState = FormWindowState.Minimized Then
                frm_mant_categorias.WindowState = FormWindowState.Normal
            Else
                frm_mant_categorias.Activate()
            End If
        Else
            frm_mant_categorias.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SubCategoríasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubCategoríasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_subcategorias.Visible = True Then
            If frm_mant_subcategorias.WindowState = FormWindowState.Minimized Then
                frm_mant_subcategorias.WindowState = FormWindowState.Normal
            Else
                frm_mant_subcategorias.Activate()
            End If
        Else
            frm_mant_subcategorias.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PuestosDeTrabajoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PuestosDeTrabajoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_cargos_emp.Visible = True Then
            If frm_mant_cargos_emp.WindowState = FormWindowState.Minimized Then
                frm_mant_cargos_emp.WindowState = FormWindowState.Normal
            Else
                frm_mant_cargos_emp.Activate()
            End If
        Else
            frm_mant_cargos_emp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DepartamentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartamentosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_departamentosemp.Visible = True Then
            If frm_mant_departamentosemp.WindowState = FormWindowState.Minimized Then
                frm_mant_departamentosemp.WindowState = FormWindowState.Normal
            Else
                frm_mant_departamentosemp.Activate()
            End If
        Else
            frm_mant_departamentosemp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TipoDeNóminaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoDeNóminaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_tipo_nomina.Visible = True Then
            If frm_mant_tipo_nomina.WindowState = FormWindowState.Minimized Then
                frm_mant_tipo_nomina.WindowState = FormWindowState.Normal
            Else
                frm_mant_tipo_nomina.Activate()
            End If
        Else
            frm_mant_tipo_nomina.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TandasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TandasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_tandas.Visible = True Then
            If frm_mant_tandas.WindowState = FormWindowState.Minimized Then
                frm_mant_tandas.WindowState = FormWindowState.Normal
            Else
                frm_mant_tandas.Activate()
            End If
        Else
            frm_mant_tandas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PréstamosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PréstamosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_prestamos_emp.Visible = True Then
            If frm_mant_prestamos_emp.WindowState = FormWindowState.Minimized Then
                frm_mant_prestamos_emp.WindowState = FormWindowState.Normal
            Else
                frm_mant_prestamos_emp.Activate()
            End If
        Else
            frm_mant_prestamos_emp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TiposDePréstamosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiposDePréstamosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_tipo_prestamos.Visible = True Then
            If frm_mant_tipo_prestamos.WindowState = FormWindowState.Minimized Then
                frm_mant_tipo_prestamos.WindowState = FormWindowState.Normal
            Else
                frm_mant_tipo_prestamos.Activate()
            End If
        Else
            frm_mant_tipo_prestamos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PagoDePrToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagoDePrToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_descontar_prestamos.Visible = True Then
            If frm_descontar_prestamos.WindowState = FormWindowState.Minimized Then
                frm_descontar_prestamos.WindowState = FormWindowState.Normal
            Else
                frm_descontar_prestamos.Activate()
            End If
        Else
            frm_descontar_prestamos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PréstamosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PréstamosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_prestamos_emp.Visible = True Then
            If frm_consulta_prestamos_emp.WindowState = FormWindowState.Minimized Then
                frm_consulta_prestamos_emp.WindowState = FormWindowState.Normal
            Else
                frm_consulta_prestamos_emp.Activate()
            End If
        Else
            frm_consulta_prestamos_emp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TablaRetenciónISRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TablaRetenciónISRToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_ret_isr.Visible = True Then
            If frm_mant_ret_isr.WindowState = FormWindowState.Minimized Then
                frm_mant_ret_isr.WindowState = FormWindowState.Normal
            Else
                frm_mant_ret_isr.Activate()
            End If
        Else
            frm_mant_ret_isr.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub GenerarNóminaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarNóminaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_proceso_nomina.Visible = True Then
            If frm_proceso_nomina.WindowState = FormWindowState.Minimized Then
                frm_proceso_nomina.WindowState = FormWindowState.Normal
            Else
                frm_proceso_nomina.Activate()
            End If
        Else
            frm_proceso_nomina.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DeduccionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeduccionesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_ing_dec.Visible = True Then
            If frm_mant_ing_dec.WindowState = FormWindowState.Minimized Then
                frm_mant_ing_dec.WindowState = FormWindowState.Normal
            Else
                frm_mant_ing_dec.Activate()
            End If
        Else
            frm_mant_ing_dec.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub StocksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StocksToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_stocks.Visible = True Then
            If frm_consulta_stocks.WindowState = FormWindowState.Minimized Then
                frm_consulta_stocks.WindowState = FormWindowState.Normal
            Else
                frm_consulta_stocks.Activate()
            End If
        Else
            frm_consulta_stocks.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub FacturacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturacionToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_facturacion.Visible = True Then
            If frm_facturacion.WindowState = FormWindowState.Minimized Then
                frm_facturacion.WindowState = FormWindowState.Normal
            Else
                frm_facturacion.Activate()
            End If
        Else
            frm_facturacion.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ConduceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConduceToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_conduce.Visible = True Then
            If frm_conduce.WindowState = FormWindowState.Minimized Then
                frm_conduce.WindowState = FormWindowState.Normal
            Else
                frm_conduce.Activate()
            End If
        Else
            frm_conduce.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub OrdenDeComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenDeComprasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_orden_compras.Visible = True Then
            If frm_orden_compras.WindowState = FormWindowState.Minimized Then
                frm_orden_compras.WindowState = FormWindowState.Normal
            Else
                frm_orden_compras.Activate()
            End If
        Else
            frm_orden_compras.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub MotivosDeDevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MotivosDeDevolucionesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_mot_devolucion.Visible = True Then
            If frm_mant_mot_devolucion.WindowState = FormWindowState.Minimized Then
                frm_mant_mot_devolucion.WindowState = FormWindowState.Normal
            Else
                frm_mant_mot_devolucion.Activate()
            End If
        Else
            frm_mant_mot_devolucion.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub NotaDePedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotaDePedidoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_pedidos.Visible = True Then
            If frm_pedidos.WindowState = FormWindowState.Minimized Then
                frm_pedidos.WindowState = FormWindowState.Normal
            Else
                frm_pedidos.Activate()
            End If
        Else
            frm_pedidos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CalificacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalificacionesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_calificacion.Visible = True Then
            If frm_mant_calificacion.WindowState = FormWindowState.Minimized Then
                frm_mant_calificacion.WindowState = FormWindowState.Normal
            Else
                frm_mant_calificacion.Activate()
            End If
        Else
            frm_mant_calificacion.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EstadoCivilToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadoCivilToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_estado_civil.Visible = True Then
            If frm_mant_estado_civil.WindowState = FormWindowState.Minimized Then
                frm_mant_estado_civil.WindowState = FormWindowState.Normal
            Else
                frm_mant_estado_civil.Activate()
            End If
        Else
            frm_mant_estado_civil.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ProvinciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProvinciasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_provincias.Visible = True Then
            If frm_mant_provincias.WindowState = FormWindowState.Minimized Then
                frm_mant_provincias.WindowState = FormWindowState.Normal
            Else
                frm_mant_provincias.Activate()
            End If
        Else
            frm_mant_provincias.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub OcupacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OcupacionesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_ocupaciones.Visible = True Then
            If frm_mant_ocupaciones.WindowState = FormWindowState.Minimized Then
                frm_mant_ocupaciones.WindowState = FormWindowState.Normal
            Else
                frm_mant_ocupaciones.Activate()
            End If
        Else
            frm_mant_ocupaciones.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub MunicipiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MunicipiosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_municipios.Visible = True Then
            If frm_mant_municipios.WindowState = FormWindowState.Minimized Then
                frm_mant_municipios.WindowState = FormWindowState.Normal
            Else
                frm_mant_municipios.Activate()
            End If
        Else
            frm_mant_municipios.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub NacionalidadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NacionalidadesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_nacionalidades.Visible = True Then
            If frm_mant_nacionalidades.WindowState = FormWindowState.Minimized Then
                frm_mant_nacionalidades.WindowState = FormWindowState.Normal
            Else
                frm_mant_nacionalidades.Activate()
            End If
        Else
            frm_mant_nacionalidades.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SerialesYGarantíasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SerialesYGarantíasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_introducir_seriales.Visible = True Then
            If frm_introducir_seriales.WindowState = FormWindowState.Minimized Then
                frm_introducir_seriales.WindowState = FormWindowState.Normal
            Else
                frm_introducir_seriales.Activate()
            End If
        Else
            frm_introducir_seriales.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CalculadoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculadoraToolStripMenuItem.Click
        LlamarCalculadora()
    End Sub

    Private Sub PaintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaintToolStripMenuItem.Click
        LlamarPaint()
    End Sub

    Private Sub BlockDeNotasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlockDeNotasToolStripMenuItem.Click
        LlamarBlockNotas()
    End Sub

    Private Sub WordPadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WordPadToolStripMenuItem.Click
        LlamarWordPad()
    End Sub

    Private Sub TipoTarjetaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoTarjetaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_tipo_tarjeta.Visible = True Then
            If frm_mant_tipo_tarjeta.WindowState = FormWindowState.Minimized Then
                frm_mant_tipo_tarjeta.WindowState = FormWindowState.Normal
            Else
                frm_mant_tipo_tarjeta.Activate()
            End If
        Else
            frm_mant_tipo_tarjeta.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub VentasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_ventas.Visible = True Then
            If frm_consulta_ventas.WindowState = FormWindowState.Minimized Then
                frm_consulta_ventas.WindowState = FormWindowState.Normal
            Else
                frm_consulta_ventas.Activate()
            End If
        Else
            frm_consulta_ventas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub AjustesDeInventarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjustesDeInventarioToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_ajuste_inventario.Visible = True Then
            If frm_consulta_ajuste_inventario.WindowState = FormWindowState.Minimized Then
                frm_consulta_ajuste_inventario.WindowState = FormWindowState.Normal
            Else
                frm_consulta_ajuste_inventario.Activate()
            End If
        Else
            frm_consulta_ajuste_inventario.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ConducesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConducesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_conduces.Visible = True Then
            If frm_consulta_conduces.WindowState = FormWindowState.Minimized Then
                frm_consulta_conduces.WindowState = FormWindowState.Normal
            Else
                frm_consulta_conduces.Activate()
            End If
        Else
            frm_consulta_conduces.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub InventarioInicialToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles InventarioInicialToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_ajuste_inventario.Visible = True Then
            If frm_consulta_ajuste_inventario.WindowState = FormWindowState.Minimized Then
                frm_consulta_ajuste_inventario.WindowState = FormWindowState.Normal
            Else
                frm_consulta_ajuste_inventario.Activate()
            End If
        Else
            frm_consulta_ajuste_inventario.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TransferenciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransferenciasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_transferencias.Visible = True Then
            If frm_consulta_transferencias.WindowState = FormWindowState.Minimized Then
                frm_consulta_transferencias.WindowState = FormWindowState.Normal
            Else
                frm_consulta_transferencias.Activate()
            End If
        Else
            frm_consulta_transferencias.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub NotasDePedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotasDePedidoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_pedidos.Visible = True Then
            If frm_consulta_pedidos.WindowState = FormWindowState.Minimized Then
                frm_consulta_pedidos.WindowState = FormWindowState.Normal
            Else
                frm_consulta_pedidos.Activate()
            End If
        Else
            frm_consulta_pedidos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ComprasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_compras.Visible = True Then
            If frm_consulta_compras.WindowState = FormWindowState.Minimized Then
                frm_consulta_compras.WindowState = FormWindowState.Normal
            Else
                frm_consulta_compras.Activate()
            End If
        Else
            frm_consulta_compras.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub OrdenesDeComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenesDeComprasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_orden_compra.Visible = True Then
            If frm_consulta_orden_compra.WindowState = FormWindowState.Minimized Then
                frm_consulta_orden_compra.WindowState = FormWindowState.Normal
            Else
                frm_consulta_orden_compra.Activate()
            End If
        Else
            frm_consulta_orden_compra.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub AcuerdosDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcuerdosDePagoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_acuerdos_pago.Visible = True Then
            If frm_acuerdos_pago.WindowState = FormWindowState.Minimized Then
                frm_acuerdos_pago.WindowState = FormWindowState.Normal
            Else
                frm_acuerdos_pago.Activate()
            End If
        Else
            frm_acuerdos_pago.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub TiposDeAjusteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiposDeAjusteToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_ajustes_inventario.Visible = True Then
            If frm_mant_ajustes_inventario.WindowState = FormWindowState.Minimized Then
                frm_mant_ajustes_inventario.WindowState = FormWindowState.Normal
            Else
                frm_mant_ajustes_inventario.Activate()
            End If
        Else
            frm_mant_ajustes_inventario.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DevoluciónDeComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevoluciónDeComprasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_devolucion_compras.Visible = True Then
            If frm_devolucion_compras.WindowState = FormWindowState.Minimized Then
                frm_devolucion_compras.WindowState = FormWindowState.Normal
            Else
                frm_devolucion_compras.Activate()
            End If
        Else
            frm_devolucion_compras.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ClasesDeDocumentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClasesDeDocumentosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_clase_documentos.Visible = True Then
            If frm_mant_clase_documentos.WindowState = FormWindowState.Minimized Then
                frm_mant_clase_documentos.WindowState = FormWindowState.Normal
            Else
                frm_mant_clase_documentos.Activate()
            End If
        Else
            frm_mant_clase_documentos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EnviarEmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarEmailToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_enviar_correo.Visible = True Then
            If frm_enviar_correo.WindowState = FormWindowState.Minimized Then
                frm_enviar_correo.WindowState = FormWindowState.Normal
            Else
                frm_enviar_correo.Activate()
            End If
        Else
            frm_enviar_correo.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub AjustesDeLaEmpresaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjustesDeLaEmpresaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_ajustes.Visible = True Then
            If frm_ajustes.WindowState = FormWindowState.Minimized Then
                frm_ajustes.WindowState = FormWindowState.Normal
            Else
                frm_ajustes.Activate()
            End If
        Else
            frm_ajustes.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub AjustesDelSistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjustesDelSistemaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_ajustes_tecnicos.Visible = True Then
            If frm_ajustes_tecnicos.WindowState = FormWindowState.Minimized Then
                frm_ajustes_tecnicos.WindowState = FormWindowState.Normal
            Else
                frm_ajustes_tecnicos.Activate()
            End If
        Else
            frm_ajustes_tecnicos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TalonarioDeCobroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TalonarioDeCobroToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_talonarios_cobro.Visible = True Then
            If frm_talonarios_cobro.WindowState = FormWindowState.Minimized Then
                frm_talonarios_cobro.WindowState = FormWindowState.Normal
            Else
                frm_talonarios_cobro.Activate()
            End If
        Else
            frm_talonarios_cobro.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EntregaDeCobroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntregaDeCobroToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_entrega_cobro.Visible = True Then
            If frm_entrega_cobro.WindowState = FormWindowState.Minimized Then
                frm_entrega_cobro.WindowState = FormWindowState.Normal
            Else
                frm_entrega_cobro.Activate()
            End If
        Else
            frm_entrega_cobro.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CotizacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CotizacionesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_cotizacion.Visible = True Then
            If frm_consulta_cotizacion.WindowState = FormWindowState.Minimized Then
                frm_consulta_cotizacion.WindowState = FormWindowState.Normal
            Else
                frm_consulta_cotizacion.Activate()
            End If
        Else
            frm_consulta_cotizacion.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RegistroDeFacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeFacturasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_registro_factura_sd.Visible = True Then
            If frm_registro_factura_sd.WindowState = FormWindowState.Minimized Then
                frm_registro_factura_sd.WindowState = FormWindowState.Normal
            Else
                frm_registro_factura_sd.Activate()
            End If
        Else
            frm_registro_factura_sd.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RelaciónFamiliarToolStripMenuItem_Click_(sender As Object, e As EventArgs) Handles RelaciónFamiliarToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_relacion_familiar.Visible = True Then
            If frm_mant_relacion_familiar.WindowState = FormWindowState.Minimized Then
                frm_mant_relacion_familiar.WindowState = FormWindowState.Normal
            Else
                frm_mant_relacion_familiar.Activate()
            End If
        Else
            frm_mant_relacion_familiar.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CierreDeFacturaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CierreDeFacturaciónToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cierre_facturas.Visible = True Then
            If frm_cierre_facturas.WindowState = FormWindowState.Minimized Then
                frm_cierre_facturas.WindowState = FormWindowState.Normal
            Else
                frm_cierre_facturas.Activate()
            End If
        Else
            frm_cierre_facturas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub HistorialDeRecibosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistorialDeRecibosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_historial_recibos_cliente.Visible = True Then
            If frm_historial_recibos_cliente.WindowState = FormWindowState.Minimized Then
                frm_historial_recibos_cliente.WindowState = FormWindowState.Normal
            Else
                frm_historial_recibos_cliente.Activate()
            End If
        Else
            frm_historial_recibos_cliente.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ProcesarCobroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProcesarCobroToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_registro_recibos_cobro.Visible = True Then
            If frm_registro_recibos_cobro.WindowState = FormWindowState.Minimized Then
                frm_registro_recibos_cobro.WindowState = FormWindowState.Normal
            Else
                frm_registro_recibos_cobro.Activate()
            End If
        Else
            frm_registro_recibos_cobro.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CierreDeRecibosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CierreDeRecibosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_numero_recibo.Visible = True Then
            If frm_consulta_numero_recibo.WindowState = FormWindowState.Minimized Then
                frm_consulta_numero_recibo.WindowState = FormWindowState.Normal
            Else
                frm_consulta_numero_recibo.Activate()
            End If
        Else
            frm_consulta_numero_recibo.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ComisionesDeCobrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComisionesDeCobrosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_comision_cobros.Visible = True Then
            If frm_mant_comision_cobros.WindowState = FormWindowState.Minimized Then
                frm_mant_comision_cobros.WindowState = FormWindowState.Normal
            Else
                frm_mant_comision_cobros.Activate()
            End If
        Else
            frm_mant_comision_cobros.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub GruposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GruposToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_grupos_cxc.Visible = True Then
            If frm_mant_grupos_cxc.WindowState = FormWindowState.Minimized Then
                frm_mant_grupos_cxc.WindowState = FormWindowState.Normal
            Else
                frm_mant_grupos_cxc.Activate()
            End If
        Else
            frm_mant_grupos_cxc.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TiposDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiposDeClientesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_tipo_credito.Visible = True Then
            If frm_mant_tipo_credito.WindowState = FormWindowState.Minimized Then
                frm_mant_tipo_credito.WindowState = FormWindowState.Normal
            Else
                frm_mant_tipo_credito.Activate()
            End If
        Else
            frm_mant_tipo_credito.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub OtrosIngresosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtrosIngresosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_otros_ingresos.Visible = True Then
            If frm_otros_ingresos.WindowState = FormWindowState.Minimized Then
                frm_otros_ingresos.WindowState = FormWindowState.Normal
            Else
                frm_otros_ingresos.Activate()
            End If
        Else
            frm_otros_ingresos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RegistroDeFacturasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RegistroDeFacturasToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_registro_factura.Visible = True Then
            If frm_consulta_registro_factura.WindowState = FormWindowState.Minimized Then
                frm_consulta_registro_factura.WindowState = FormWindowState.Normal
            Else
                frm_consulta_registro_factura.Activate()
            End If
        Else
            frm_consulta_registro_factura.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SerialesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SerialesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_serie_garantia.Visible = True Then
            If frm_consulta_serie_garantia.WindowState = FormWindowState.Minimized Then
                frm_consulta_serie_garantia.WindowState = FormWindowState.Normal
            Else
                frm_consulta_serie_garantia.Activate()
            End If
        Else
            frm_consulta_serie_garantia.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ConceptosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConceptosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_tipo_documento.Visible = True Then
            If frm_mant_tipo_documento.WindowState = FormWindowState.Minimized Then
                frm_mant_tipo_documento.WindowState = FormWindowState.Normal
            Else
                frm_mant_tipo_documento.Activate()
            End If
        Else
            frm_mant_tipo_documento.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ChequesFuturosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChequesFuturosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cheques_futuristas.Visible = True Then
            If frm_cheques_futuristas.WindowState = FormWindowState.Minimized Then
                frm_cheques_futuristas.WindowState = FormWindowState.Normal
            Else
                frm_cheques_futuristas.Activate()
            End If
        Else
            frm_cheques_futuristas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ChequesDevueltosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChequesDevueltosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cheques_devueltos.Visible = True Then
            If frm_cheques_devueltos.WindowState = FormWindowState.Minimized Then
                frm_cheques_devueltos.WindowState = FormWindowState.Normal
            Else
                frm_cheques_devueltos.Activate()
            End If
        Else
            frm_cheques_devueltos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ChequesFuturosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChequesFuturosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_cheques_futuros.Visible = True Then
            If frm_consulta_cheques_futuros.WindowState = FormWindowState.Minimized Then
                frm_consulta_cheques_futuros.WindowState = FormWindowState.Normal
            Else
                frm_consulta_cheques_futuros.Activate()
            End If
        Else
            frm_consulta_cheques_futuros.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub OtrosIngresosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OtrosIngresosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_otros_ingresos.Visible = True Then
            If frm_consulta_otros_ingresos.WindowState = FormWindowState.Minimized Then
                frm_consulta_otros_ingresos.WindowState = FormWindowState.Normal
            Else
                frm_consulta_otros_ingresos.Activate()
            End If
        Else
            frm_consulta_otros_ingresos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ChequesDevueltosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChequesDevueltosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_cheques_devueltos.Visible = True Then
            If frm_consulta_cheques_devueltos.WindowState = FormWindowState.Minimized Then
                frm_consulta_cheques_devueltos.WindowState = FormWindowState.Normal
            Else
                frm_consulta_cheques_devueltos.Activate()
            End If
        Else
            frm_consulta_cheques_devueltos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        lblHora.Text = TimeOfDay()
        lblFecha.Text = Today.ToLongDateString

        If chkLiberarMemoria.Checked = True Then
            FreeMemory.FlushMemory()
        End If

        If ChkBloqueoInactividad.Checked = True Then

            Dim it As Integer = GetLastInputTime()

            If LastLastIdletime > it Then
                CounterIdleTime = 0
            Else
                CounterIdleTime = GetLastInputTime()

                '2500 son los segundos de inactivdad
                If CounterIdleTime > CInt(DTConfiguracion.Rows(110 - 1).Item("Value2Int")) Then
                    CerrarSistemaToolStripMenuItem.Tag = 2
                    Hora.Enabled = False
                    Me.Close()

                End If
            End If

            LastLastIdletime = it

        End If

    End Sub

    Private Sub TiposDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiposDeProductosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_tipo_productos.Visible = True Then
            If frm_mant_tipo_productos.WindowState = FormWindowState.Minimized Then
                frm_mant_tipo_productos.WindowState = FormWindowState.Normal
            Else
                frm_mant_tipo_productos.Activate()
            End If
        Else
            frm_mant_tipo_productos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ControlDeVentasComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlDeVentasComprasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_controles_ventas_compras.Visible = True Then
            If frm_controles_ventas_compras.WindowState = FormWindowState.Minimized Then
                frm_controles_ventas_compras.WindowState = FormWindowState.Normal
            Else
                frm_controles_ventas_compras.Activate()
            End If
        Else
            frm_controles_ventas_compras.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub NotasDeDébitoCréditoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NotasDeDébitoCréditoToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_nota_debito_credito_cxp.Visible = True Then
            If frm_nota_debito_credito_cxp.WindowState = FormWindowState.Minimized Then
                frm_nota_debito_credito_cxp.WindowState = FormWindowState.Normal
            Else
                frm_nota_debito_credito_cxp.Activate()
            End If
        Else
            frm_nota_debito_credito_cxp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub GenerarNuevosRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarNuevosRToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_generacion_nuevos_recibos.Visible = True Then
            If frm_generacion_nuevos_recibos.WindowState = FormWindowState.Minimized Then
                frm_generacion_nuevos_recibos.WindowState = FormWindowState.Normal
            Else
                frm_generacion_nuevos_recibos.Activate()
            End If
        Else
            frm_generacion_nuevos_recibos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RealizarBackUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RealizarBackUpToolStripMenuItem.Click
        RealizarBackup()
    End Sub

    Private Sub TiposDeRecibosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiposDeRecibosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_tipo_recibos.Visible = True Then
            If frm_mant_tipo_recibos.WindowState = FormWindowState.Minimized Then
                frm_mant_tipo_recibos.WindowState = FormWindowState.Normal
            Else
                frm_mant_tipo_recibos.Activate()
            End If
        Else
            frm_mant_tipo_recibos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ListaDeCobrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDeCobrosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cargo_pagareses.Visible = True Then
            If frm_cargo_pagareses.WindowState = FormWindowState.Minimized Then
                frm_cargo_pagareses.WindowState = FormWindowState.Normal
            Else
                frm_cargo_pagareses.Activate()
            End If
        Else
            frm_cargo_pagareses.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CargarPagaréToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarPagaréToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cargar_pagare_individual.Visible = True Then
            If frm_cargar_pagare_individual.WindowState = FormWindowState.Minimized Then
                frm_cargar_pagare_individual.WindowState = FormWindowState.Normal
            Else
                frm_cargar_pagare_individual.Activate()
            End If
        Else
            frm_cargar_pagare_individual.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TraspasoDePagaréToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TraspasoDePagaréToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_traspasar_pagare.Visible = True Then
            If frm_traspasar_pagare.WindowState = FormWindowState.Minimized Then
                frm_traspasar_pagare.WindowState = FormWindowState.Normal
            Else
                frm_traspasar_pagare.Activate()
            End If
        Else
            frm_traspasar_pagare.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_notas_debito_credito.Visible = True Then
            If frm_notas_debito_credito.WindowState = FormWindowState.Minimized Then
                frm_notas_debito_credito.WindowState = FormWindowState.Normal
            Else
                frm_notas_debito_credito.Activate()
            End If
        Else
            frm_notas_debito_credito.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ReciboDeEgresosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReciboDeEgresosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_recibos_egresos.Visible = True Then
            If frm_recibos_egresos.WindowState = FormWindowState.Minimized Then
                frm_recibos_egresos.WindowState = FormWindowState.Normal
            Else
                frm_recibos_egresos.Activate()
            End If
        Else
            frm_recibos_egresos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub AseguradorasDeRiesgosLaboralesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AseguradorasDeRiesgosLaboralesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_afp.Visible = True Then
            If frm_mant_afp.WindowState = FormWindowState.Minimized Then
                frm_mant_afp.WindowState = FormWindowState.Normal
            Else
                frm_mant_afp.Activate()
            End If
        Else
            frm_mant_afp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub AdministradoraDeFondoDePensionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdministradoraDeFondoDePensionesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_ARS.Visible = True Then
            If frm_mant_ARS.WindowState = FormWindowState.Minimized Then
                frm_mant_ARS.WindowState = FormWindowState.Normal
            Else
                frm_mant_ARS.Activate()
            End If
        Else
            frm_mant_ARS.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DevolucionesDeComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevolucionesDeComprasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_devolucion_compra.Visible = True Then
            If frm_consulta_devolucion_compra.WindowState = FormWindowState.Minimized Then
                frm_consulta_devolucion_compra.WindowState = FormWindowState.Normal
            Else
                frm_consulta_devolucion_compra.Activate()
            End If
        Else
            frm_consulta_devolucion_compra.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarToolStripMenuItem.Click
        CerrarSistemaToolStripMenuItem.PerformClick()
    End Sub

    Private Sub RealizarBackUpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RealizarBackUpToolStripMenuItem1.Click
        RealizarBackUpToolStripMenuItem.PerformClick()
    End Sub

    Private Sub CambiarUsuarioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CambiarUsuarioToolStripMenuItem1.Click
        CambiarUsuarioToolStripMenuItem.PerformClick()
    End Sub

    Private Sub MostrarLibregcoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarLibregcoToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub MainNotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles MainNotifyIcon.MouseDoubleClick
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub VentasToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_ventas.Visible = True Then
            If frm_reporte_ventas.WindowState = FormWindowState.Minimized Then
                frm_reporte_ventas.WindowState = FormWindowState.Normal
            Else
                frm_reporte_ventas.Activate()
            End If
        Else
            frm_reporte_ventas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TiposDeMovimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiposDeMovimientosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_tipo_mov_bancario.Visible = True Then
            If frm_mant_tipo_mov_bancario.WindowState = FormWindowState.Minimized Then
                frm_mant_tipo_mov_bancario.WindowState = FormWindowState.Normal
            Else
                frm_mant_tipo_mov_bancario.Activate()
            End If
        Else
            frm_mant_tipo_mov_bancario.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArtículosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_productos.Visible = True Then
            If frm_reporte_productos.WindowState = FormWindowState.Minimized Then
                frm_reporte_productos.WindowState = FormWindowState.Normal
            Else
                frm_reporte_productos.Activate()
            End If
        Else
            frm_reporte_productos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CambiarContraseñaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarContraseñaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cambiar_password.Visible = True Then
            If frm_cambiar_password.WindowState = FormWindowState.Minimized Then
                frm_cambiar_password.WindowState = FormWindowState.Normal
            Else
                frm_cambiar_password.Activate()
            End If
        Else
            frm_cambiar_password.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DevolucionesDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevolucionesDeVentasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_devolucion_ventas.Visible = True Then
            If frm_reporte_devolucion_ventas.WindowState = FormWindowState.Minimized Then
                frm_reporte_devolucion_ventas.WindowState = FormWindowState.Normal
            Else
                frm_reporte_devolucion_ventas.Activate()
            End If
        Else
            frm_reporte_devolucion_ventas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TiposDeSuplidoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiposDeSuplidoresToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_tipo_suplidor.Visible = True Then
            If frm_mant_tipo_suplidor.WindowState = FormWindowState.Minimized Then
                frm_mant_tipo_suplidor.WindowState = FormWindowState.Normal
            Else
                frm_mant_tipo_suplidor.Activate()
            End If
        Else
            frm_mant_tipo_suplidor.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DetalleDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleDeVentasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_detalle_ventas.Visible = True Then
            If frm_reporte_detalle_ventas.WindowState = FormWindowState.Minimized Then
                frm_reporte_detalle_ventas.WindowState = FormWindowState.Normal
            Else
                frm_reporte_detalle_ventas.Activate()
            End If
        Else
            frm_reporte_detalle_ventas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ComprasToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem3.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_compras.Visible = True Then
            If frm_reporte_compras.WindowState = FormWindowState.Minimized Then
                frm_reporte_compras.WindowState = FormWindowState.Normal
            Else
                frm_reporte_compras.Activate()
            End If
        Else
            frm_reporte_compras.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DetalleDeComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalleDeComprasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_detalle_compras.Visible = True Then
            If frm_reporte_detalle_compras.WindowState = FormWindowState.Minimized Then
                frm_reporte_detalle_compras.WindowState = FormWindowState.Normal
            Else
                frm_reporte_detalle_compras.Activate()
            End If
        Else
            frm_reporte_detalle_compras.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub btnRestaurar_Click(sender As Object, e As EventArgs) Handles btnRestaurar.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            btnRestaurar.Text = "Restaurar"
        Else
            Me.WindowState = FormWindowState.Normal
            btnRestaurar.Text = "Maximizar"
        End If

        SplitContainer1.SplitterDistance = 235
    End Sub

    Private Sub DevolucionesDeComprasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DevolucionesDeComprasToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_devolucion_compras.Visible = True Then
            If frm_reporte_devolucion_compras.WindowState = FormWindowState.Minimized Then
                frm_reporte_devolucion_compras.WindowState = FormWindowState.Normal
            Else
                frm_reporte_devolucion_compras.Activate()
            End If
        Else
            frm_reporte_devolucion_compras.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub OrdenesDeComprasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OrdenesDeComprasToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_orden_compra.Visible = True Then
            If frm_reporte_orden_compra.WindowState = FormWindowState.Minimized Then
                frm_reporte_orden_compra.WindowState = FormWindowState.Normal
            Else
                frm_reporte_orden_compra.Activate()
            End If
        Else
            frm_reporte_orden_compra.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub InventarioAUnaFechaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventarioAUnaFechaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_inventario_fecha.Visible = True Then
            If frm_reporte_inventario_fecha.WindowState = FormWindowState.Minimized Then
                frm_reporte_inventario_fecha.WindowState = FormWindowState.Normal
            Else
                frm_reporte_inventario_fecha.Activate()
            End If
        Else
            frm_reporte_inventario_fecha.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub MovimientosPorProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosPorProductosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_movimientos_inventario.Visible = True Then
            If frm_reporte_movimientos_inventario.WindowState = FormWindowState.Minimized Then
                frm_reporte_movimientos_inventario.WindowState = FormWindowState.Normal
            Else
                frm_reporte_movimientos_inventario.Activate()
            End If
        Else
            frm_reporte_movimientos_inventario.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub AjustesDeInventarioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AjustesDeInventarioToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_ajustes_inventario.Visible = True Then
            If frm_reporte_ajustes_inventario.WindowState = FormWindowState.Minimized Then
                frm_reporte_ajustes_inventario.WindowState = FormWindowState.Normal
            Else
                frm_reporte_ajustes_inventario.Activate()
            End If
        Else
            frm_reporte_ajustes_inventario.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TransferenciasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TransferenciasToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_transferencias_inventario.Visible = True Then
            If frm_reporte_transferencias_inventario.WindowState = FormWindowState.Minimized Then
                frm_reporte_transferencias_inventario.WindowState = FormWindowState.Normal
            Else
                frm_reporte_transferencias_inventario.Activate()
            End If
        Else
            frm_reporte_transferencias_inventario.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub UpdateConUserTimer_Tick(sender As Object, e As EventArgs) Handles UpdateConUserTimer.Tick
        Try

            Dim DsTemp As New DataSet

            UpdateConUserTimer.Enabled = False

            Connon.Open()
            Dim Consulta As New MySqlCommand("Select IDEmpleado,Nombre,Cargo from Empleados INNER JOIN cargosemp on Empleados.IDCargo=CargosEmp.IDCargo Where Conectado=1", Connon)
            Dim LectorUsuarios As MySqlDataReader = Consulta.ExecuteReader
            DgvEmplCon.Rows.Clear()

            While LectorUsuarios.Read
                DgvEmplCon.Rows.Add(LectorUsuarios.GetValue(1) & " (" & LectorUsuarios.GetValue(2) & ")")
            End While

            LectorUsuarios.Close()
            DgvEmplCon.ClearSelection()

            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT IDBitacoraDetalle,BitaCoraDetalle.IDBitacora,Bitacora.IDEmpleado,Empleados.Nombre,Empleados.Login,BitacoraDetalle.IDEquipo,AreaImpresion.ComputerName,Bitacora.Fecha FROM libregco.bitacoradetalle INNER JOIN Libregco.Bitacora on Bitacora.IDEntrada=BitacoraDetalle.IDBitacora INNER JOIN Libregco.AreaImpresion on Bitacora.IDEquipo=AreaImpresion.IDEquipo INNER JOIN Libregco.Empleados on Bitacora.IDEmpleado=Empleados.IDEmpleado Where BitacoraDetalle.IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "' and Bitacora.Abierta=1 and BitacoraDetalle.Mostrado=0 GROUP BY BitacoraDetalle.IDEquipo", Connon)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "bitacora")

            Dim Tabla As DataTable = DsTemp.Tables("bitacora")

            For Each row As DataRow In Tabla.Rows
                sqlQ = "UPDATE BitacoraDetalle SET Mostrado=1 Where IDBitacoraDetalle='" + row.Item("IDBitacoraDetalle").ToString + "'"
                cmd = New MySqlCommand(sqlQ, Connon)
                cmd.ExecuteNonQuery()

                If chkHabilitarNotify.Checked = True Then
                    Dim NotifyUsers As New NotifyIcon

                    NotifyUsers.Visible = False
                    NotifyUsers.Icon = My.Resources.Libregco_Icon
                    NotifyUsers.BalloonTipIcon = ToolTipIcon.Info

                    With NotifyUsers
                        .Visible = True
                        .Text = "Inicio de sesión"
                        .BalloonTipTitle = "[" & row.Item("IDEmpleado") & "] " & row.Item("Nombre") & " se ha conectado al sistema."
                        .BalloonTipText = "Conexión desde: " & row.Item("ComputerName")
                        .ShowBalloonTip(3)
                        .Visible = False
                    End With

                    NotifyUsers.Dispose()
                End If
            Next
            Tabla.Dispose()

            If chkHabilitarNotify.Checked = True Then
                'Refrescar Conversaciones
                Dim NotReadMessage As String
                cmd = New MySqlCommand("Select COUNT(Leido) from Mensajes INNER JOIN Libregco.UsuariosConversacion on Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosConversacion INNER JOIN Libregco.Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado INNER JOIN Libregco.Conversaciones on UsuariosConversacion.IDConversacion=Conversaciones.IDConversacion Where UsuariosConversacion.IDEmpleado <> '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' and Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosCOnversacion and (SELECT 1 FROM Libregco.UsuariosConversacion WHERE Conversaciones.IDConversacion = UsuariosConversacion.IDConversacion AND UsuariosConversacion.IDEmpleado = '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "') and Leido=0", Connon)
                NotReadMessage = Convert.ToString(cmd.ExecuteScalar())

                If NotReadMessage > 0 Then
                    lblCantMensajes.Text = NotReadMessage

                    If chkNotificacionChat.IsOn = True Then
                        QtChat = NotReadMessage
                    Else
                        QtChat = 0
                    End If

                    OverLoadNotification()
                    PanelAvisoMensajes.Visible = True
                    CargarChat()
                    Label46.Visible = True

                    'Avisando mensajes

                    DsTemp.Clear()
                    cmd = New MySqlCommand("Select IDMensaje,Conversaciones.IDConversacion,UsuariosConversacion.IDUsuariosConversacion,UsuariosConversacion.IDEmpleado,Empleados.Nombre,Mensaje,Mensajes.FechaEnvio,Leido from Mensajes INNER JOIN Libregco.UsuariosConversacion on Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosConversacion INNER JOIN Libregco.Empleados on UsuariosConversacion.IDEmpleado=Empleados.IDEmpleado INNER JOIN Libregco.Conversaciones on UsuariosConversacion.IDConversacion=Conversaciones.IDConversacion Where UsuariosConversacion.IDEmpleado <> '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' and Mensajes.IDUsuarioConversacion=UsuariosConversacion.IDUsuariosCOnversacion and (SELECT 1 FROM Libregco.UsuariosConversacion WHERE Conversaciones.IDConversacion = UsuariosConversacion.IDConversacion AND UsuariosConversacion.IDEmpleado = '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "') and Leido=0 and Avisado=0 ORDER BY FechaEnvio ASC", Connon)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "Conversaciones")

                    Dim Tbl As DataTable = DsTemp.Tables("Conversaciones")

                    For Each Rw As DataRow In Tbl.Rows
                        sqlQ = "UPDATE Mensajes SET Avisado=1 Where IDMensaje='" + Rw.Item(0).ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Connon)
                        cmd.ExecuteNonQuery()

                        Dim NotificacionMessage As New NotifyIcon
                        NotificacionMessage.Icon = My.Resources.Libregco_Icon
                        NotificacionMessage.BalloonTipIcon = ToolTipIcon.Info
                        NotificacionMessage.Visible = True

                        AddHandler NotificacionMessage.BalloonTipClicked, AddressOf GotoMessage
                        AddHandler NotificacionMessage.Click, AddressOf GotoMessage

                        With NotificacionMessage
                            .Tag = Rw.Item("IDUsuariosConversacion")

                            If chkMostrarContenidoNotificacion.Checked = True Then
                                .Text = "Has recibido un mensaje"
                                .BalloonTipTitle = CDate(Rw.Item("FechaEnvio")).ToString("dd/MM/yyyy hh:mm:ss tt") & vbNewLine & " [" & Rw.Item("IDEmpleado") & "] " & Rw.Item("Nombre") & " dice:"
                                .BalloonTipText = Rw.Item("Mensaje")
                            Else
                                .Text = "Has recibido un mensaje"
                                .BalloonTipTitle = CDate(Rw.Item("FechaEnvio")).ToString("dd/MM/yyyy hh:mm:ss tt") & vbNewLine & " [" & Rw.Item("IDEmpleado") & "] " & Rw.Item("Nombre")
                                .BalloonTipText = ""
                            End If

                            .ShowBalloonTip(3)

                            If frm_messenger.Visible = False Then
                                frm_new_message.IDUsuarioConversacion = Rw.Item("IDUsuariosConversacion")
                                frm_new_message.lblEnvia.Text = Rw.Item("Nombre")
                                frm_new_message.lblFecha.Text = CDate(Rw.Item("FechaEnvio")).ToString("dd/MM/yyyy hh:mm:ss tt")

                                If frm_new_message.Visible = True Then
                                    If frm_new_message.WindowState = FormWindowState.Minimized Then
                                        frm_new_message.WindowState = FormWindowState.Normal
                                    Else
                                        frm_new_message.Activate()
                                    End If
                                Else
                                    frm_new_message.Show(Me)
                                End If
                            End If
                        End With

                        NotificacionMessage.Visible = False
                    Next

                    Tbl.Dispose()

                Else
                    Label46.Visible = False
                    PanelAvisoMensajes.Visible = False
                End If
            End If


            If chkHabilitarNotify.Checked = True Then
                'Avisar solicitudes
                Dim SolicitudesPendientes As String
                cmd = New MySqlCommand("SELECT count(IDSolicitudAutorizacion) FROM libregco.solicitudautorizacion where Aprobado=0 and Avisado=0 and IDUsuarioSolicitud<>'" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' and IDEmpleadoEnviado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'", Connon)
                SolicitudesPendientes = Convert.ToString(cmd.ExecuteScalar())

                If SolicitudesPendientes > 0 Then
                    DsTemp.Clear()
                    cmd = New MySqlCommand("SELECT IDSolicitudAutorizacion,solicitudautorizacion.IDEquipo,ComputerName,AreaImpresion.IDAlmacen,Almacen.Almacen,Almacen.IDSucursal,Sucursal.Sucursal,IDUsuarioSolicitud,Solicitante.Nombre as Solicitante,SolicitudAutorizacion.Fecha,IDPermisos,Permisos.Descripcion,Modulos.IDModulo,Modulo,Proceso,AccionesModulos.IDAccionesSuperClave,AccionesModulos.Descripcion as Acciones FROM Libregco.Solicitudautorizacion INNER JOIN Libregco.AreaImpresion on SolicitudAutorizacion.IDEquipo=AreaImpresion.IDEquipo INNER JOIN Libregco.Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.Empleados as Solicitante on SolicitudAutorizacion.IDUsuarioSolicitud=Solicitante.IDEmpleado INNER JOIN Libregco.Permisos on SolicitudAutorizacion.IDPermiso=Permisos.IDPermisos INNER JOIN Libregco.Modulos on Permisos.IDModulo=Modulos.IDModulo INNER JOIN Libregco.ProcesosModulo on Permisos.IDProceso=ProcesosModulo.IDProcesosModulo INNER JOIN Libregco.AccionesModulos on SolicitudAutorizacion.IDAccion=AccionesModulos.IDAccionesSuperClave where Aprobado=0 and Avisado=0 and IDEmpleadoEnviado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' and IDUsuarioSolicitud<>'" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'", Connon)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "SolicitudAutorizacion")

                    Dim Tblc As DataTable = DsTemp.Tables("SolicitudAutorizacion")

                    For Each Rt As DataRow In Tblc.Rows
                        sqlQ = "UPDATE SolicitudAutorizacion SET Avisado=1 Where IDSolicitudAutorizacion='" + Rt.Item(0).ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Connon)
                        cmd.ExecuteNonQuery()

                        Dim NotificacionAutorizacion As New NotifyIcon

                        AddHandler NotificacionAutorizacion.BalloonTipClicked, AddressOf GotoSolicitud
                        AddHandler NotificacionAutorizacion.Click, AddressOf GotoSolicitud

                        With NotificacionAutorizacion
                            .Tag = Rt.Item("IDSolicitudAutorizacion")
                            .Visible = True
                            .Icon = My.Resources.Libregco_Icon
                            .BalloonTipIcon = ToolTipIcon.Info
                            .Text = "Solicitud de autorización"
                            .BalloonTipTitle = "[" & Rt.Item("IDUsuarioSolicitud") & "] " & Rt.Item("Solicitante") & " te solicita una autorización"

                            If chkMostrarContenidoNotificacion.Checked = True Then
                                .BalloonTipText = Rt.Item("Modulo") & "\" & Rt.Item("Proceso") & "\" & Rt.Item("Descripcion") & vbNewLine & Rt.Item("Acciones")
                            Else
                                .BalloonTipText = "'Consulta el formulario de solicitudes para visualizar'"
                            End If

                            .ShowBalloonTip(3)
                        End With

                        NotificacionAutorizacion.Visible = False
                    Next
                    Tblc.Dispose()
                End If
            End If

            cmd = New MySqlCommand("Select Suspender from" & SysName.Text & "AreaImpresion where IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "'", Connon)
            If Convert.ToString(cmd.ExecuteScalar()) = 1 Then
                CerrarSistemaToolStripMenuItem.Tag = 3
                Me.Close()
            End If

            DsTemp.Dispose()
            Connon.Close()
            UpdateConUserTimer.Enabled = True

        Catch ex As Exception
            Connon.Close()
        End Try

    End Sub

    Private Sub GotoSolicitud(Sendr As Object, e As EventArgs)
        Dim Nhy As New NotifyIcon
        Nhy = CType(Sendr, NotifyIcon)

        If IsNumeric(Nhy.Tag) Then
            If frm_solicitud_autorizacion_ventas.Visible = True Then
                If frm_solicitud_autorizacion_ventas.WindowState = FormWindowState.Minimized Then
                    frm_solicitud_autorizacion_ventas.WindowState = FormWindowState.Normal
                    frm_solicitud_autorizacion_ventas.Activate()
                Else
                    frm_solicitud_autorizacion_ventas.Activate()
                End If
            Else
                frm_solicitud_autorizacion_ventas.Show(Me)
                frm_solicitud_autorizacion_ventas.Activate()
            End If

            frm_solicitud_autorizacion_ventas.txtIDSolicitud.Text = Nhy.Tag
            frm_solicitud_autorizacion_ventas.btnBuscar.PerformClick()

        End If

        Nhy.Visible = False
        Nhy.Dispose()


    End Sub

    Private Sub GotoMessage(Sendr As Object, e As EventArgs)
        Try
            Dim Nfth As New NotifyIcon
            Nfth = CType(Sendr, NotifyIcon)

            If IsNumeric(Nfth.Tag) Then

                Con.Open()
                cmd = New MySqlCommand("Select IDConversacion from UsuariosConversacion where IDUsuariosConversacion='" + Nfth.Tag.ToString + "'", Con)
                Dim IDConvs As String = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If frm_messenger.Visible = True Then
                    If frm_messenger.WindowState = FormWindowState.Minimized Then
                        frm_messenger.WindowState = FormWindowState.Normal
                        frm_messenger.Activate()
                    Else
                        frm_messenger.Activate()
                    End If
                Else
                    frm_messenger.Show(Me)
                    frm_messenger.Activate()
                End If

                For Each row As DataGridViewRow In frm_messenger.DgvConversations.Rows
                    If row.Cells(0).Value = Nfth.Tag.ToString Then
                        frm_messenger.IDConversacion = IDConvs
                        frm_messenger.DgvConversations.Rows(row.Index).Cells(2).Selected = True
                        frm_messenger.DgvConversations.Focus()
                        frm_messenger.FillPreInfo()
                    End If
                Next
            End If

            Nfth.Visible = False
            Nfth.Dispose()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvConversations_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvConversations.CellDoubleClick
        UpdateConUserTimer.Enabled = False

        If e.RowIndex >= 0 Then
            If IsNumeric(DgvConversations.CurrentRow.Cells(0).Value) Then
                Dim IDSelectedConversationUser, IDConvs As String

                IDSelectedConversationUser = DgvConversations.CurrentRow.Cells(0).Value
                IDConvs = DgvConversations.CurrentRow.Cells(7).Value

                If frm_messenger.Visible = True Then
                    If frm_messenger.WindowState = FormWindowState.Minimized Then
                        frm_messenger.WindowState = FormWindowState.Normal
                        frm_messenger.Activate()
                    Else
                        frm_messenger.Activate()
                    End If
                Else
                    frm_messenger.Show(Me)
                    frm_messenger.Activate()
                End If

                For Each row As DataGridViewRow In frm_messenger.DgvConversations.Rows
                    If row.Cells(0).Value = IDSelectedConversationUser Then
                        frm_messenger.IDConversacion = DgvConversations.CurrentRow.Cells(7).Value
                        frm_messenger.DgvConversations.Rows(row.Index).Cells(2).Selected = True
                        'frm_messenger.Updater.Enabled = False
                        'frm_messenger.NTimer.Enabled = False
                        frm_messenger.DgvConversations.Focus()
                        frm_messenger.FillPreInfo()
                        'frm_messenger.Updater.Enabled = True
                        'frm_messenger.NTimer.Enabled = True
                    End If
                Next
            End If
        End If

        UpdateConUserTimer.Enabled = True
    End Sub

    Private Sub ConducesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConducesToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_conduces.Visible = True Then
            If frm_reporte_conduces.WindowState = FormWindowState.Minimized Then
                frm_reporte_conduces.WindowState = FormWindowState.Normal
            Else
                frm_reporte_conduces.Activate()
            End If
        Else
            frm_reporte_conduces.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CobrosAdelantadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CobrosAdelantadosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cobros_adelantados.Visible = True Then
            If frm_cobros_adelantados.WindowState = FormWindowState.Minimized Then
                frm_cobros_adelantados.WindowState = FormWindowState.Normal
            Else
                frm_cobros_adelantados.Activate()
            End If
        Else
            frm_cobros_adelantados.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CuadreDeCajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuadreDeCajaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_cuadre_de_caja.Visible = True Then
            If frm_reporte_cuadre_de_caja.WindowState = FormWindowState.Minimized Then
                frm_reporte_cuadre_de_caja.WindowState = FormWindowState.Normal
            Else
                frm_reporte_cuadre_de_caja.Activate()
            End If
        Else
            frm_reporte_cuadre_de_caja.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TiposDeGastosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiposDeGastosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_tipo_gasto.Visible = True Then
            If frm_mant_tipo_gasto.WindowState = FormWindowState.Minimized Then
                frm_mant_tipo_gasto.WindowState = FormWindowState.Normal
            Else
                frm_mant_tipo_gasto.Activate()
            End If
        Else
            frm_mant_tipo_gasto.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_notas_pedidos.Visible = True Then
            If frm_reporte_notas_pedidos.WindowState = FormWindowState.Minimized Then
                frm_reporte_notas_pedidos.WindowState = FormWindowState.Normal
            Else
                frm_reporte_notas_pedidos.Activate()
            End If
        Else
            frm_reporte_notas_pedidos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ListasDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListasDeProductosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_listado_articulos.Visible = True Then
            If frm_reporte_listado_articulos.WindowState = FormWindowState.Minimized Then
                frm_reporte_listado_articulos.WindowState = FormWindowState.Normal
            Else
                frm_reporte_listado_articulos.Activate()
            End If
        Else
            frm_reporte_listado_articulos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RestablecerOriginalToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim Mensaje, Titulo, DefaultValue As String
        Dim MyValue As Object

        Mensaje = "Ingrese el No. de Factura que desea establecer su estatus de impresión Original."
        Titulo = "Status de impresión de factura"
        DefaultValue = ""

        MyValue = InputBox(Mensaje, Titulo, DefaultValue)

        If MyValue = "" Then
            MyValue = DefaultValue
        Else
            Dim NoFactura As New Label
            NoFactura.Text = MyValue

            Con.Open()
            cmd = New MySqlCommand("Select Impreso from FacturaDatos where SecondID='" + NoFactura.Text + "'", Con)
            Dim CheckifExist As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If CheckifExist = "" Then
                MessageBox.Show("No existe factura cuya número sea: " & NoFactura.Text & "." & vbNewLine & vbNewLine & " Por favor verifique el número e inténtelo de nuevo.", "No se encontró la factura", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                sqlQ = "UPDATE FacturaDatos SET Impreso=0 WHERE SecondID='" + NoFactura.Text + "'"
                GuardarDatos()
                MessageBox.Show("Se ha restablecido en número de factura: " & NoFactura.Text & ".")
            End If
        End If


    End Sub

    Private Sub RestablecerOriginalEnCotizaciónToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim Mensaje, Titulo, DefaultValue As String
        Dim MyValue As Object

        Mensaje = "Ingrese el No. de Cotización que desea establecer su estatus de impresión Original."
        Titulo = "Status de impresión de cotización"
        DefaultValue = ""

        MyValue = InputBox(Mensaje, Titulo, DefaultValue)

        If MyValue = "" Then
            MyValue = DefaultValue
        Else
            Dim NoCotizacion As New Label
            NoCotizacion.Text = MyValue

            Con.Open()
            cmd = New MySqlCommand("Select Impreso from Cotizacion where SecondID='" + NoCotizacion.Text + "'", Con)
            Dim CheckifExist As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If CheckifExist = "" Then
                MessageBox.Show("No existe cotización cuyo número sea: " & NoCotizacion.Text & "." & vbNewLine & vbNewLine & " Por favor verifique el número e inténtelo de nuevo.", "No se encontró la cotización", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                sqlQ = "UPDATE Cotizacion SET Impreso=0 WHERE SecondID='" + NoCotizacion.Text + "'"
                GuardarDatos()
                MessageBox.Show("Se ha restablecido en número de cotización: " & NoCotizacion.Text & ".")
            End If
        End If
    End Sub

    Private Sub ReparacionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReparacionesToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_conduce_reparacion.Visible = True Then
            If frm_reporte_conduce_reparacion.WindowState = FormWindowState.Minimized Then
                frm_reporte_conduce_reparacion.WindowState = FormWindowState.Normal
            Else
                frm_reporte_conduce_reparacion.Activate()
            End If
        Else
            frm_reporte_conduce_reparacion.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ReparacionesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ReparacionesToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_conduce_reparacion.Visible = True Then
            If frm_consulta_conduce_reparacion.WindowState = FormWindowState.Minimized Then
                frm_consulta_conduce_reparacion.WindowState = FormWindowState.Normal
            Else
                frm_consulta_conduce_reparacion.Activate()
            End If
        Else
            frm_consulta_conduce_reparacion.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ReparacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReparacionesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_conduce_reparaciones.Visible = True Then
            If frm_conduce_reparaciones.WindowState = FormWindowState.Minimized Then
                frm_conduce_reparaciones.WindowState = FormWindowState.Normal
            Else
                frm_conduce_reparaciones.Activate()
            End If
        Else
            frm_conduce_reparaciones.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PuntoLiteDeFacturaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PuntoLiteDeFacturaciónToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_punto_venta_lite.Visible = True Then
            If frm_punto_venta_lite.WindowState = FormWindowState.Minimized Then
                frm_punto_venta_lite.WindowState = FormWindowState.Normal
            Else
                frm_punto_venta_lite.Activate()
            End If
        Else
            frm_punto_venta_lite.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub BúsquedaCombinadaDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BúsquedaCombinadaDeClientesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_combinada_clientes.Visible = True Then
            If frm_consulta_combinada_clientes.WindowState = FormWindowState.Minimized Then
                frm_consulta_combinada_clientes.WindowState = FormWindowState.Normal
            Else
                frm_consulta_combinada_clientes.Activate()
            End If
        Else
            frm_consulta_combinada_clientes.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CondicionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CondicionesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_condicion.Visible = True Then
            If frm_mant_condicion.WindowState = FormWindowState.Minimized Then
                frm_mant_condicion.WindowState = FormWindowState.Normal
            Else
                frm_mant_condicion.Activate()
            End If
        Else
            frm_mant_condicion.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TipoDeNCFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoDeNCFToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_comp_fiscal.Visible = True Then
            If frm_mant_comp_fiscal.WindowState = FormWindowState.Minimized Then
                frm_mant_comp_fiscal.WindowState = FormWindowState.Normal
            Else
                frm_mant_comp_fiscal.Activate()
            End If
        Else
            frm_mant_comp_fiscal.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub GénerosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GénerosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_genero.Visible = True Then
            If frm_mant_genero.WindowState = FormWindowState.Minimized Then
                frm_mant_genero.WindowState = FormWindowState.Normal
            Else
                frm_mant_genero.Activate()
            End If
        Else
            frm_mant_genero.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TiposDeIdentificaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiposDeIdentificaciónToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_tipo_identificacion.Visible = True Then
            If frm_mant_tipo_identificacion.WindowState = FormWindowState.Minimized Then
                frm_mant_tipo_identificacion.WindowState = FormWindowState.Normal
            Else
                frm_mant_tipo_identificacion.Activate()
            End If
        Else
            frm_mant_tipo_identificacion.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DistribuciónDeMonedasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DistribuciónDeMonedasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_distribucion_monedas.Visible = True Then
            If frm_distribucion_monedas.WindowState = FormWindowState.Minimized Then
                frm_distribucion_monedas.WindowState = FormWindowState.Normal
            Else
                frm_distribucion_monedas.Activate()
            End If
        Else
            frm_distribucion_monedas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SucursalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SucursalesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_sucursal.Visible = True Then
            If frm_mant_sucursal.WindowState = FormWindowState.Minimized Then
                frm_mant_sucursal.WindowState = FormWindowState.Normal
            Else
                frm_mant_sucursal.Activate()
            End If
        Else
            frm_mant_sucursal.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EtiquetasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EtiquetasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_etiquetas_productos.Visible = True Then
            If frm_reporte_etiquetas_productos.WindowState = FormWindowState.Minimized Then
                frm_reporte_etiquetas_productos.WindowState = FormWindowState.Normal
            Else
                frm_reporte_etiquetas_productos.Activate()
            End If
        Else
            frm_reporte_etiquetas_productos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub


    Private Sub RegistrosDeFacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrosDeFacturasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_registro_facturas.Visible = True Then
            If frm_reporte_registro_facturas.WindowState = FormWindowState.Minimized Then
                frm_reporte_registro_facturas.WindowState = FormWindowState.Normal
            Else
                frm_reporte_registro_facturas.Activate()
            End If
        Else
            frm_reporte_registro_facturas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub FacturasPendientesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FacturasPendientesToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_cuentas_por_cobrar.Visible = True Then
            If frm_reporte_cuentas_por_cobrar.WindowState = FormWindowState.Minimized Then
                frm_reporte_cuentas_por_cobrar.WindowState = FormWindowState.Normal
            Else
                frm_reporte_cuentas_por_cobrar.Activate()
            End If
        Else
            frm_reporte_cuentas_por_cobrar.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_clientes.Visible = True Then
            If frm_reporte_clientes.WindowState = FormWindowState.Minimized Then
                frm_reporte_clientes.WindowState = FormWindowState.Normal
            Else
                frm_reporte_clientes.Activate()
            End If
        Else
            frm_reporte_clientes.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ReferenciasToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ReferenciasToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_clientes_referecias.Visible = True Then
            If frm_reporte_clientes_referecias.WindowState = FormWindowState.Minimized Then
                frm_reporte_clientes_referecias.WindowState = FormWindowState.Normal
            Else
                frm_reporte_clientes_referecias.Activate()
            End If
        Else
            frm_reporte_clientes_referecias.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub NotasDeDébitoCréditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotasDeDébitoCréditoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_nota_debito_credito_cxc.Visible = True Then
            If frm_reporte_nota_debito_credito_cxc.WindowState = FormWindowState.Minimized Then
                frm_reporte_nota_debito_credito_cxc.WindowState = FormWindowState.Normal
            Else
                frm_reporte_nota_debito_credito_cxc.Activate()
            End If
        Else
            frm_reporte_nota_debito_credito_cxc.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub NotasDeDébitoCréditoToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles NotasDeDébitoCréditoToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_nota_debito_credito.Visible = True Then
            If frm_consulta_nota_debito_credito.WindowState = FormWindowState.Minimized Then
                frm_consulta_nota_debito_credito.WindowState = FormWindowState.Normal
            Else
                frm_consulta_nota_debito_credito.Activate()
            End If
        Else
            frm_consulta_nota_debito_credito.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PagaresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagaresToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_pagares.Visible = True Then
            If frm_reporte_pagares.WindowState = FormWindowState.Minimized Then
                frm_reporte_pagares.WindowState = FormWindowState.Normal
            Else
                frm_reporte_pagares.Activate()
            End If
        Else
            frm_reporte_pagares.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PagarésToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagarésToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_proceso_pagares.Visible = True Then
            If frm_proceso_pagares.WindowState = FormWindowState.Minimized Then
                frm_proceso_pagares.WindowState = FormWindowState.Normal
            Else
                frm_proceso_pagares.Activate()
            End If
        Else
            frm_proceso_pagares.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SeriesYGarantíasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeriesYGarantíasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_series_garantias.Visible = True Then
            If frm_reporte_series_garantias.WindowState = FormWindowState.Minimized Then
                frm_reporte_series_garantias.WindowState = FormWindowState.Normal
            Else
                frm_reporte_series_garantias.Activate()
            End If
        Else
            frm_reporte_series_garantias.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CotizaciónToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CotizaciónToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_cotizacion.Visible = True Then
            If frm_reporte_cotizacion.WindowState = FormWindowState.Minimized Then
                frm_reporte_cotizacion.WindowState = FormWindowState.Normal
            Else
                frm_reporte_cotizacion.Activate()
            End If
        Else
            frm_reporte_cotizacion.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub


    Private Sub EntradasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntradasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_conduce_reparacion_entrada.Visible = True Then
            If frm_conduce_reparacion_entrada.WindowState = FormWindowState.Minimized Then
                frm_conduce_reparacion_entrada.WindowState = FormWindowState.Normal
            Else
                frm_conduce_reparacion_entrada.Activate()
            End If
        Else
            frm_conduce_reparacion_entrada.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EntradasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EntradasToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_entradas_reparacion.Visible = True Then
            If frm_reporte_entradas_reparacion.WindowState = FormWindowState.Minimized Then
                frm_reporte_entradas_reparacion.WindowState = FormWindowState.Normal
            Else
                frm_reporte_entradas_reparacion.Activate()
            End If
        Else
            frm_reporte_entradas_reparacion.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EntradasToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles EntradasToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_entradas_reparaciones.Visible = True Then
            If frm_consulta_entradas_reparaciones.WindowState = FormWindowState.Minimized Then
                frm_consulta_entradas_reparaciones.WindowState = FormWindowState.Normal
            Else
                frm_consulta_entradas_reparaciones.Activate()
            End If
        Else
            frm_consulta_entradas_reparaciones.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ProgresosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProgresosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_progreso_solicitudes.Visible = True Then
            If frm_progreso_solicitudes.WindowState = FormWindowState.Minimized Then
                frm_progreso_solicitudes.WindowState = FormWindowState.Normal
            Else
                frm_progreso_solicitudes.Activate()
            End If
        Else
            frm_progreso_solicitudes.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SolicitudesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SolicitudesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_solicitudes_clientes.Visible = True Then
            If frm_reporte_solicitudes_clientes.WindowState = FormWindowState.Minimized Then
                frm_reporte_solicitudes_clientes.WindowState = FormWindowState.Normal
            Else
                frm_reporte_solicitudes_clientes.Activate()
            End If
        Else
            frm_reporte_solicitudes_clientes.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ProgresosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProgresosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_progreso_solicitud.Visible = True Then
            If frm_reporte_progreso_solicitud.WindowState = FormWindowState.Minimized Then
                frm_reporte_progreso_solicitud.WindowState = FormWindowState.Normal
            Else
                frm_reporte_progreso_solicitud.Activate()
            End If
        Else
            frm_reporte_progreso_solicitud.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RecibosDeIngresosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecibosDeIngresosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_cobros_facturas.Visible = True Then
            If frm_reporte_cobros_facturas.WindowState = FormWindowState.Minimized Then
                frm_reporte_cobros_facturas.WindowState = FormWindowState.Normal
            Else
                frm_reporte_cobros_facturas.Activate()
            End If
        Else
            frm_reporte_cobros_facturas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub MovimientosPorClientesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MovimientosPorClientesToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_movimientos_clientes.Visible = True Then
            If frm_reporte_movimientos_clientes.WindowState = FormWindowState.Minimized Then
                frm_reporte_movimientos_clientes.WindowState = FormWindowState.Normal
            Else
                frm_reporte_movimientos_clientes.Activate()
            End If
        Else
            frm_reporte_movimientos_clientes.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub OtrosIngresosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles OtrosIngresosToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_otros_ingresos.Visible = True Then
            If frm_reporte_otros_ingresos.WindowState = FormWindowState.Minimized Then
                frm_reporte_otros_ingresos.WindowState = FormWindowState.Normal
            Else
                frm_reporte_otros_ingresos.Activate()
            End If
        Else
            frm_reporte_otros_ingresos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub


    Private Sub CobrosAdelantadosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CobrosAdelantadosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_cobros_adelantados.Visible = True Then
            If frm_reporte_cobros_adelantados.WindowState = FormWindowState.Minimized Then
                frm_reporte_cobros_adelantados.WindowState = FormWindowState.Normal
            Else
                frm_reporte_cobros_adelantados.Activate()
            End If
        Else
            frm_reporte_cobros_adelantados.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ChequesDevueltosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ChequesDevueltosToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_cheques_devueltos.Visible = True Then
            If frm_reporte_cheques_devueltos.WindowState = FormWindowState.Minimized Then
                frm_reporte_cheques_devueltos.WindowState = FormWindowState.Normal
            Else
                frm_reporte_cheques_devueltos.Activate()
            End If
        Else
            frm_reporte_cheques_devueltos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ChequesFuturosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ChequesFuturosToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_cheques_futuros.Visible = True Then
            If frm_reporte_cheques_futuros.WindowState = FormWindowState.Minimized Then
                frm_reporte_cheques_futuros.WindowState = FormWindowState.Normal
            Else
                frm_reporte_cheques_futuros.Activate()
            End If
        Else
            frm_reporte_cheques_futuros.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub AcuerdosDePagosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcuerdosDePagosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_acuerdos_pago.Visible = True Then
            If frm_reporte_acuerdos_pago.WindowState = FormWindowState.Minimized Then
                frm_reporte_acuerdos_pago.WindowState = FormWindowState.Normal
            Else
                frm_reporte_acuerdos_pago.Activate()
            End If
        Else
            frm_reporte_acuerdos_pago.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RecibosDeIngresoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecibosDeIngresoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_recibos_ingresos.Visible = True Then
            If frm_consulta_recibos_ingresos.WindowState = FormWindowState.Minimized Then
                frm_consulta_recibos_ingresos.WindowState = FormWindowState.Normal
            Else
                frm_consulta_recibos_ingresos.Activate()
            End If
        Else
            frm_consulta_recibos_ingresos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub AcuerdosDePagoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AcuerdosDePagoToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_acuerdo_pago.Visible = True Then
            If frm_consulta_acuerdo_pago.WindowState = FormWindowState.Minimized Then
                frm_consulta_acuerdo_pago.WindowState = FormWindowState.Normal
            Else
                frm_consulta_acuerdo_pago.Activate()
            End If
        Else
            frm_consulta_acuerdo_pago.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SuplidoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuplidoresToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_suplidor.Visible = True Then
            If frm_reporte_suplidor.WindowState = FormWindowState.Minimized Then
                frm_reporte_suplidor.WindowState = FormWindowState.Normal
            Else
                frm_reporte_suplidor.Activate()
            End If
        Else
            frm_reporte_suplidor.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RegistrosDeFacturasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RegistrosDeFacturasToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_registro_facturas_cxp.Visible = True Then
            If frm_reporte_registro_facturas_cxp.WindowState = FormWindowState.Minimized Then
                frm_reporte_registro_facturas_cxp.WindowState = FormWindowState.Normal
            Else
                frm_reporte_registro_facturas_cxp.Activate()
            End If
        Else
            frm_reporte_registro_facturas_cxp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub FacturasPendientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturasPendientesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_cuentas_por_pagar.Visible = True Then
            If frm_reporte_cuentas_por_pagar.WindowState = FormWindowState.Minimized Then
                frm_reporte_cuentas_por_pagar.WindowState = FormWindowState.Normal
            Else
                frm_reporte_cuentas_por_pagar.Activate()
            End If
        Else
            frm_reporte_cuentas_por_pagar.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PagosDeFacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagosDeFacturasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_pagos_facturas.Visible = True Then
            If frm_reporte_pagos_facturas.WindowState = FormWindowState.Minimized Then
                frm_reporte_pagos_facturas.WindowState = FormWindowState.Normal
            Else
                frm_reporte_pagos_facturas.Activate()
            End If
        Else
            frm_reporte_pagos_facturas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub NotasDeDébitoCréditoToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles NotasDeDébitoCréditoToolStripMenuItem3.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_notas_debito_credito_cxp.Visible = True Then
            If frm_reporte_notas_debito_credito_cxp.WindowState = FormWindowState.Minimized Then
                frm_reporte_notas_debito_credito_cxp.WindowState = FormWindowState.Normal
            Else
                frm_reporte_notas_debito_credito_cxp.Activate()
            End If
        Else
            frm_reporte_notas_debito_credito_cxp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EstadoDeCuentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadoDeCuentasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_estado_cuenta_cxp.Visible = True Then
            If frm_reporte_estado_cuenta_cxp.WindowState = FormWindowState.Minimized Then
                frm_reporte_estado_cuenta_cxp.WindowState = FormWindowState.Normal
            Else
                frm_reporte_estado_cuenta_cxp.Activate()
            End If
        Else
            frm_reporte_estado_cuenta_cxp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RecibosDeEgresosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RecibosDeEgresosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_egresos.Visible = True Then
            If frm_reporte_egresos.WindowState = FormWindowState.Minimized Then
                frm_reporte_egresos.WindowState = FormWindowState.Normal
            Else
                frm_reporte_egresos.Activate()
            End If
        Else
            frm_reporte_egresos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ComprasToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_compras.Visible = True Then
            If frm_consulta_compras.WindowState = FormWindowState.Minimized Then
                frm_consulta_compras.WindowState = FormWindowState.Normal
            Else
                frm_consulta_compras.Activate()
            End If
        Else
            frm_consulta_compras.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RegistroDeComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeComprasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_facturas_cxp.Visible = True Then
            If frm_consulta_facturas_cxp.WindowState = FormWindowState.Minimized Then
                frm_consulta_facturas_cxp.WindowState = FormWindowState.Normal
            Else
                frm_consulta_facturas_cxp.Activate()
            End If
        Else
            frm_consulta_facturas_cxp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PagosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_pagos_cxp.Visible = True Then
            If frm_consulta_pagos_cxp.WindowState = FormWindowState.Minimized Then
                frm_consulta_pagos_cxp.WindowState = FormWindowState.Normal
            Else
                frm_consulta_pagos_cxp.Activate()
            End If
        Else
            frm_consulta_pagos_cxp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RecibosDeEgresosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecibosDeEgresosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_egresos_cxp.Visible = True Then
            If frm_consulta_egresos_cxp.WindowState = FormWindowState.Minimized Then
                frm_consulta_egresos_cxp.WindowState = FormWindowState.Normal
            Else
                frm_consulta_egresos_cxp.Activate()
            End If
        Else
            frm_consulta_egresos_cxp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub NotasDeDébitoCréditoToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles NotasDeDébitoCréditoToolStripMenuItem4.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_nota_debito_credito_cxp.Visible = True Then
            If frm_consulta_nota_debito_credito_cxp.WindowState = FormWindowState.Minimized Then
                frm_consulta_nota_debito_credito_cxp.WindowState = FormWindowState.Normal
            Else
                frm_consulta_nota_debito_credito_cxp.Activate()
            End If
        Else
            frm_consulta_nota_debito_credito_cxp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub AntiguedadDeSaldoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AntiguedadDeSaldoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_antiguedad_saldos_cxp.Visible = True Then
            If frm_antiguedad_saldos_cxp.WindowState = FormWindowState.Minimized Then
                frm_antiguedad_saldos_cxp.WindowState = FormWindowState.Normal
            Else
                frm_antiguedad_saldos_cxp.Activate()
            End If
        Else
            frm_antiguedad_saldos_cxp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub MovimientosPorFacturasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosPorFacturasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_movimiento_facturas_cxp.Visible = True Then
            If frm_movimiento_facturas_cxp.WindowState = FormWindowState.Minimized Then
                frm_movimiento_facturas_cxp.WindowState = FormWindowState.Normal
            Else
                frm_movimiento_facturas_cxp.Activate()
            End If
        Else
            frm_movimiento_facturas_cxp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PermisosAUsuariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PermisosAUsuariosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_permisos_usuarios.Visible = True Then
            If frm_permisos_usuarios.WindowState = FormWindowState.Minimized Then
                frm_permisos_usuarios.WindowState = FormWindowState.Normal
            Else
                frm_permisos_usuarios.Activate()
            End If
        Else
            frm_permisos_usuarios.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EmpleadosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EmpleadosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_empleados.Visible = True Then
            If frm_reporte_empleados.WindowState = FormWindowState.Minimized Then
                frm_reporte_empleados.WindowState = FormWindowState.Normal
            Else
                frm_reporte_empleados.Activate()
            End If
        Else
            frm_reporte_empleados.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub NóminasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NóminasToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_nomina.Visible = True Then
            If frm_reporte_nomina.WindowState = FormWindowState.Minimized Then
                frm_reporte_nomina.WindowState = FormWindowState.Normal
            Else
                frm_reporte_nomina.Activate()
            End If
        Else
            frm_reporte_nomina.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub IngresosYDeduccionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresosYDeduccionesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_registro_ingresos_deducciones.Visible = True Then
            If frm_registro_ingresos_deducciones.WindowState = FormWindowState.Minimized Then
                frm_registro_ingresos_deducciones.WindowState = FormWindowState.Normal
            Else
                frm_registro_ingresos_deducciones.Activate()
            End If
        Else
            frm_registro_ingresos_deducciones.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub IngresosDeduccionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresosDeduccionesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_deducciones.Visible = True Then
            If frm_reporte_deducciones.WindowState = FormWindowState.Minimized Then
                frm_reporte_deducciones.WindowState = FormWindowState.Normal
            Else
                frm_reporte_deducciones.Activate()
            End If
        Else
            frm_reporte_deducciones.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PréstamosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PréstamosToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_prestamos_empleados.Visible = True Then
            If frm_reporte_prestamos_empleados.WindowState = FormWindowState.Minimized Then
                frm_reporte_prestamos_empleados.WindowState = FormWindowState.Normal
            Else
                frm_reporte_prestamos_empleados.Activate()
            End If
        Else
            frm_reporte_prestamos_empleados.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CobrosDePréstamosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CobrosDePréstamosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_cobros_prestamos.Visible = True Then
            If frm_reporte_cobros_prestamos.WindowState = FormWindowState.Minimized Then
                frm_reporte_cobros_prestamos.WindowState = FormWindowState.Normal
            Else
                frm_reporte_cobros_prestamos.Activate()
            End If
        Else
            frm_reporte_cobros_prestamos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub NóminasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NóminasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_nomina.Visible = True Then
            If frm_consulta_nomina.WindowState = FormWindowState.Minimized Then
                frm_consulta_nomina.WindowState = FormWindowState.Normal
            Else
                frm_consulta_nomina.Activate()
            End If
        Else
            frm_consulta_nomina.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub IngresosYDeduccionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles IngresosYDeduccionesToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_ingresos_deducciones.Visible = True Then
            If frm_consulta_ingresos_deducciones.WindowState = FormWindowState.Minimized Then
                frm_consulta_ingresos_deducciones.WindowState = FormWindowState.Normal
            Else
                frm_consulta_ingresos_deducciones.Activate()
            End If
        Else
            frm_consulta_ingresos_deducciones.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PagosAPréstamosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagosAPréstamosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_pagos_prestamos.Visible = True Then
            If frm_consulta_pagos_prestamos.WindowState = FormWindowState.Minimized Then
                frm_consulta_pagos_prestamos.WindowState = FormWindowState.Normal
            Else
                frm_consulta_pagos_prestamos.Activate()
            End If
        Else
            frm_consulta_pagos_prestamos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ContratosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ContratosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_contratos_clientes.Visible = True Then
            If frm_contratos_clientes.WindowState = FormWindowState.Minimized Then
                frm_contratos_clientes.WindowState = FormWindowState.Normal
            Else
                frm_contratos_clientes.Activate()
            End If
        Else
            frm_contratos_clientes.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ContratosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContratosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_plazo_contratos.Visible = True Then
            If frm_mant_plazo_contratos.WindowState = FormWindowState.Minimized Then
                frm_mant_plazo_contratos.WindowState = FormWindowState.Normal
            Else
                frm_mant_plazo_contratos.Activate()
            End If
        Else
            frm_mant_plazo_contratos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub MovimientosBancarisoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosBancarisoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_movimientos_bancarios.Visible = True Then
            If frm_reporte_movimientos_bancarios.WindowState = FormWindowState.Minimized Then
                frm_reporte_movimientos_bancarios.WindowState = FormWindowState.Normal
            Else
                frm_reporte_movimientos_bancarios.Activate()
            End If
        Else
            frm_reporte_movimientos_bancarios.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ChequesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChequesToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_cheques.Visible = True Then
            If frm_reporte_cheques.WindowState = FormWindowState.Minimized Then
                frm_reporte_cheques.WindowState = FormWindowState.Normal
            Else
                frm_reporte_cheques.Activate()
            End If
        Else
            frm_reporte_cheques.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SolicitudDeChequesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SolicitudDeChequesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_solicitud_cheques.Visible = True Then
            If frm_solicitud_cheques.WindowState = FormWindowState.Minimized Then
                frm_solicitud_cheques.WindowState = FormWindowState.Normal
            Else
                frm_solicitud_cheques.Activate()
            End If
        Else
            frm_solicitud_cheques.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub NotasDeCréditoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotasDeCréditoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_nota_credito_bancos.Visible = True Then
            If frm_nota_credito_bancos.WindowState = FormWindowState.Minimized Then
                frm_nota_credito_bancos.WindowState = FormWindowState.Normal
            Else
                frm_nota_credito_bancos.Activate()
            End If
        Else
            frm_nota_credito_bancos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SolicitudDeChequesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SolicitudDeChequesToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_solicitud_cheques.Visible = True Then
            If frm_consulta_solicitud_cheques.WindowState = FormWindowState.Minimized Then
                frm_consulta_solicitud_cheques.WindowState = FormWindowState.Normal
            Else
                frm_consulta_solicitud_cheques.Activate()
            End If
        Else
            frm_consulta_solicitud_cheques.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ChequesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ChequesToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_cheques.Visible = True Then
            If frm_consulta_cheques.WindowState = FormWindowState.Minimized Then
                frm_consulta_cheques.WindowState = FormWindowState.Normal
            Else
                frm_consulta_cheques.Activate()
            End If
        Else
            frm_consulta_cheques.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub SolicitudDeChequesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SolicitudDeChequesToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_solicitud_cheques.Visible = True Then
            If frm_reporte_solicitud_cheques.WindowState = FormWindowState.Minimized Then
                frm_reporte_solicitud_cheques.WindowState = FormWindowState.Normal
            Else
                frm_reporte_solicitud_cheques.Activate()
            End If
        Else
            frm_reporte_solicitud_cheques.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PermisosAUsuariosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PermisosAUsuariosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_permisos_usuarios.Visible = True Then
            If frm_permisos_usuarios.WindowState = FormWindowState.Minimized Then
                frm_permisos_usuarios.WindowState = FormWindowState.Normal
            Else
                frm_permisos_usuarios.Activate()
            End If
        Else
            frm_permisos_usuarios.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub


    Private Sub VerificarPermisosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerificarPermisosToolStripMenuItem.Click
        'Con.Open()
        'Ds.Clear()
        'cmd = New MySqlCommand("SELECT IDPermisos,Descripcion,IDModulo,IDProceso,Orden FROM permisos", Con)
        'Adaptador = New MySqlDataAdapter(cmd)
        'Adaptador.Fill(Ds, "Permisos")
        'Con.Close()

        'Dim Tabla As DataTable = Ds.Tables("Permisos")

        'For Each TStrip As ToolStripMenuItem In MenuBar.Items
        '    For Each SubStrip As ToolStripMenuItem In TStrip.DropDownItems
        '        For Each Strip As Object In SubStrip.DropDownItems

        '            If Not Strip.ToString.Contains("Separator") Then

        '                'Para marcar el tag number en el texto de cada opción del menú
        '                'DirectCast(Strip, ToolStripMenuItem).Text = "[" & DirectCast(Strip, ToolStripMenuItem).Tag & "] " & DirectCast(Strip, ToolStripMenuItem).Text


        '                ''Para verificar si el nombre de los menús es igual a los nombres en la base de datos.
        '                'If DirectCast(Strip, ToolStripMenuItem).Tag <> vbEmpty Then
        '                'Dim results As DataRow() = Tabla.Select("IDPermisos= '" & DirectCast(Strip, ToolStripMenuItem).Tag & "'")

        '                'If results(0).Item("Descripcion") <> DirectCast(Strip, ToolStripMenuItem).Text Then
        '                '    MessageBox.Show(TStrip.Text & "/" & SubStrip.Text & "/" & DirectCast(Strip, ToolStripMenuItem).Text & vbNewLine & vbNewLine & results(0).Item("Descripcion"))
        '                'End If
        '                'End If

        '            End If

        '        Next
        '    Next

        'Next
    End Sub

    Private Sub MessengerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MessengerToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_messenger.Visible = True Then
            If frm_messenger.WindowState = FormWindowState.Minimized Then
                frm_messenger.WindowState = FormWindowState.Normal
            Else
                frm_messenger.Activate()
            End If
        Else
            frm_messenger.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ProgresosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ProgresosToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_progreso_solicitud.Visible = True Then
            If frm_consulta_progreso_solicitud.WindowState = FormWindowState.Minimized Then
                frm_consulta_progreso_solicitud.WindowState = FormWindowState.Normal
            Else
                frm_consulta_progreso_solicitud.Activate()
            End If
        Else
            frm_consulta_progreso_solicitud.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EstadoDeFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadoDeFacturaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_estados_facturas.Visible = True Then
            If frm_mant_estados_facturas.WindowState = FormWindowState.Minimized Then
                frm_mant_estados_facturas.WindowState = FormWindowState.Normal
            Else
                frm_mant_estados_facturas.Activate()
            End If
        Else
            frm_mant_estados_facturas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EstadoDeFacturaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EstadoDeFacturaToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cambiar_estado_factura.Visible = True Then
            If frm_cambiar_estado_factura.WindowState = FormWindowState.Minimized Then
                frm_cambiar_estado_factura.WindowState = FormWindowState.Normal
            Else
                frm_cambiar_estado_factura.Activate()
            End If
        Else
            frm_cambiar_estado_factura.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub AutorizaciónesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutorizaciónesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_solicitud_autorizacion_ventas.Visible = True Then
            If frm_solicitud_autorizacion_ventas.WindowState = FormWindowState.Minimized Then
                frm_solicitud_autorizacion_ventas.WindowState = FormWindowState.Normal
            Else
                frm_solicitud_autorizacion_ventas.Activate()
            End If
        Else
            frm_solicitud_autorizacion_ventas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub RestablecerPagaréToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestablecerPagaréToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_restablecer_pagare.Visible = True Then
            If frm_restablecer_pagare.WindowState = FormWindowState.Minimized Then
                frm_restablecer_pagare.WindowState = FormWindowState.Normal
            Else
                frm_restablecer_pagare.Activate()
            End If
        Else
            frm_restablecer_pagare.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PagarésToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PagarésToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_pagares.Visible = True Then
            If frm_pagares.WindowState = FormWindowState.Minimized Then
                frm_pagares.WindowState = FormWindowState.Normal
            Else
                frm_pagares.Activate()
            End If
        Else
            frm_pagares.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub GruposDeCierresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GruposDeCierresToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_grupo_cierre_recibos.Visible = True Then
            If frm_grupo_cierre_recibos.WindowState = FormWindowState.Minimized Then
                frm_grupo_cierre_recibos.WindowState = FormWindowState.Normal
            Else
                frm_grupo_cierre_recibos.Activate()
            End If
        Else
            frm_grupo_cierre_recibos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ControlDeFichasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlDeFichasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_control_fichas.Visible = True Then
            If frm_control_fichas.WindowState = FormWindowState.Minimized Then
                frm_control_fichas.WindowState = FormWindowState.Normal
            Else
                frm_control_fichas.Activate()
            End If
        Else
            frm_control_fichas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Function OverlayImages(ByVal BackgroundImg As System.Drawing.Bitmap, ByVal OverlayImg As System.Drawing.Bitmap, Position As System.Drawing.Point) As System.Drawing.Bitmap
        Dim g = System.Drawing.Graphics.FromImage(BackgroundImg)
        g.DrawImage(OverlayImg, Position)
        Return BackgroundImg
    End Function

    Private Sub CargarAccesosRapidos()
        'Try
        lblStatusBar.Text = "Cargando accesos rápidos del usuario."

        'Verificar si se muestra la barra de acceso rapido
        'ShowFastBar = DTConfiguracion.Rows(99 - 1).Item("Value2Int")
        'LimitAcces = DTConfiguracion.Rows(100 - 1).Item("Value2Int")

        If CInt(DTConfiguracion.Rows(99 - 1).Item("Value2Int")) = 0 Then
            AccesosRapidos.Visible = False
            Label1.Visible = False

        Else

            Dim DsTmp As New DataSet
            AccesosRapidos.Items.Clear()
            DsTmp.Clear()

            Con.Open()
            cmd = New MySqlCommand("SELECT count(IDEntrada) as Entradas,Bitacora.IDEquipo,AreaImpresion.ComputerName,Fecha,Bitacora.IDPermiso,Descripcion,FormName,FormularioFondo,Permisos.IDModulo,Modulos.Modulo,Modulos.ModuloFondo,Permisos.IDProceso,ProcesosModulo.Proceso,ProcesosModulo.ProcesosFondo,Orden FROM bitacora INNER JOIN AreaImpresion on Bitacora.IDEquipo=AreaImpresion.IDEquipo INNER JOIN Permisos on Bitacora.IDPermiso=Permisos.IDPermisos INNER JOIN Modulos on Permisos.IDModulo=Modulos.IDModulo INNER JOIN ProcesosModulo on Permisos.IDProceso=ProcesosModulo.IDProcesosModulo Where IDEmpleado= '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' And Permisos.MostrarIcono ='1' Group By IDPermiso Order by Entradas DESC" & " LIMIT " & CInt(DTConfiguracion.Rows(100 - 1).Item("Value2Int")), Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTmp, "Entradas")
            Con.Close()

            Dim Tabla As DataTable = DsTmp.Tables("Entradas")

            If Tabla.Rows.Count > 0 Then

                For Each row As DataRow In Tabla.Rows
                    Dim NewToolStrip As New ToolStripMenuItem

                    AddHandler NewToolStrip.Click, AddressOf ClickMe

                    NewToolStrip.AutoSize = True
                    NewToolStrip.Text = row.Item("Descripcion")

                    If TypeConnection.Text = 1 Then
                        Dim ExistFile As Boolean = System.IO.File.Exists(row.Item("FormularioFondo"))

                        If ExistFile = True Then
                            NewToolStrip.Image = OverlayImages(ResizeImage(New Bitmap("\\" & PathServidor.Text & row.Item("FormularioFondo").ToString), 32), ResizeImage(New Bitmap("\\" & PathServidor.Text & row.Item("ProcesosFondo").ToString), 16), New Point(15, 15))
                        Else
                            Dim ExistFile1 As Boolean = System.IO.File.Exists("\\" & PathServidor.Text & row.Item("FormularioFondo"))

                            If ExistFile1 = True Then
                                NewToolStrip.Image = OverlayImages(ResizeImage(New Bitmap("\\" & PathServidor.Text & row.Item("FormularioFondo").ToString), 32), ResizeImage(New Bitmap("\\" & PathServidor.Text & row.Item("ProcesosFondo").ToString), 16), New Point(15, 15))
                            Else
                                NewToolStrip.Image = My.Resources.Search_x32
                            End If
                        End If

                        NewToolStrip.ImageAlign = ContentAlignment.MiddleCenter
                        NewToolStrip.ImageScaling = ToolStripItemImageScaling.None
                    Else
                        NewToolStrip.Image = My.Resources.Search_x32
                        NewToolStrip.ImageAlign = ContentAlignment.MiddleCenter
                        NewToolStrip.ImageScaling = ToolStripItemImageScaling.None
                    End If

                    NewToolStrip.Tag = row.Item("IDPermiso")
                    AccesosRapidos.Items.Add(NewToolStrip)
                Next

                AccesosRapidos.Visible = True
                Label1.Visible = True
                Label1.Text = "Panel de accesos directos"
                Label1.BackColor = lblSeleccion.BackColor
                Label1.Size = New Size(AccesosRapidos.Width, Label1.Height)
                Label1.Location = New Point(Label1.Location.X, AccesosRapidos.Location.Y - Label1.Size.Height)

                If ContrastReadableIs(Label1.ForeColor, Label1.BackColor) Then
                    Label1.ForeColor = Color.White
                Else

                    Label1.ForeColor = Color.Black
                End If
            Else
                AccesosRapidos.Visible = False
                Label1.Visible = False
            End If
        End If


        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub ClickMe(Sendr As Object, e As EventArgs)
        Try

            Dim btn As ToolStripMenuItem
            Dim lblIDPermiso, ModuloInt As New Label

            btn = CType(Sendr, ToolStripMenuItem)
            lblIDPermiso.Text = btn.Tag


            Con.Open()
            Ds.Clear()
            cmd = New MySqlCommand("SELECT Descripcion,IDModulo,IDProceso FROM Permisos where IDPermisos='" + lblIDPermiso.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "permisos")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("permisos")

            For Each TStrip As ToolStripMenuItem In MenuBar.Items 'Nombre de modulo

                If TStrip.Tag = (Tabla.Rows(0).Item("IDModulo")) Then

                    For Each SubStrip As ToolStripMenuItem In TStrip.DropDownItems 'Nombre de proceso

                        If SubStrip.Tag = (Tabla.Rows(0).Item("IDProceso")) Then

                            For Each Strip As Object In SubStrip.DropDownItems  'Nombre de permiso
                                If Not Strip.ToString.Contains("Separator") Then

                                    If DirectCast(Strip, ToolStripMenuItem).Tag = lblIDPermiso.Text Then
                                        DirectCast(Strip, ToolStripMenuItem).PerformClick()
                                        Exit For
                                    End If

                                End If
                            Next

                            Exit For  'Si el proceso es encontrado salgo del bucle
                        End If
                    Next

                    Exit For  'Si el modulo es encontrado salgo del bucle

                End If

            Next

            Tabla.Dispose()
        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub RecibosDeCobroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecibosDeCobroToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_recibos_cobros.Visible = True Then
            If frm_reporte_recibos_cobros.WindowState = FormWindowState.Minimized Then
                frm_reporte_recibos_cobros.WindowState = FormWindowState.Normal
            Else
                frm_reporte_recibos_cobros.Activate()
            End If
        Else
            frm_reporte_recibos_cobros.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TalonariosDeCobrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TalonariosDeCobrosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_talonarios.Visible = True Then
            If frm_reporte_talonarios.WindowState = FormWindowState.Minimized Then
                frm_reporte_talonarios.WindowState = FormWindowState.Normal
            Else
                frm_reporte_talonarios.Activate()
            End If
        Else
            frm_reporte_talonarios.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EntregaDeCobrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntregaDeCobrosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_entrega_cobros.Visible = True Then
            If frm_reporte_entrega_cobros.WindowState = FormWindowState.Minimized Then
                frm_reporte_entrega_cobros.WindowState = FormWindowState.Normal
            Else
                frm_reporte_entrega_cobros.Activate()
            End If
        Else
            frm_reporte_entrega_cobros.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ListadosDeCobrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadosDeCobrosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_listado_cobros.Visible = True Then
            If frm_reporte_listado_cobros.WindowState = FormWindowState.Minimized Then
                frm_reporte_listado_cobros.WindowState = FormWindowState.Normal
            Else
                frm_reporte_listado_cobros.Activate()
            End If
        Else
            frm_reporte_listado_cobros.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TitulazToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TitulazToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_titulaciones.Visible = True Then
            If frm_reporte_titulaciones.WindowState = FormWindowState.Minimized Then
                frm_reporte_titulaciones.WindowState = FormWindowState.Normal
            Else
                frm_reporte_titulaciones.Activate()
            End If
        Else
            frm_reporte_titulaciones.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub GruposDeCierreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GruposDeCierreToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_grupo_cierre.Visible = True Then
            If frm_reporte_grupo_cierre.WindowState = FormWindowState.Minimized Then
                frm_reporte_grupo_cierre.WindowState = FormWindowState.Normal
            Else
                frm_reporte_grupo_cierre.Activate()
            End If
        Else
            frm_reporte_grupo_cierre.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub NotasDeLaVersiónToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NotasDeLaVersiónToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_current_version_sys.Visible = True Then
            If frm_current_version_sys.WindowState = FormWindowState.Minimized Then
                frm_current_version_sys.WindowState = FormWindowState.Normal
            Else
                frm_current_version_sys.Activate()
            End If
        Else
            frm_current_version_sys.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub


    Private Sub RecibosDeCobrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecibosDeCobrosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_recibos_cobros.Visible = True Then
            If frm_consulta_recibos_cobros.WindowState = FormWindowState.Minimized Then
                frm_consulta_recibos_cobros.WindowState = FormWindowState.Normal
            Else
                frm_consulta_recibos_cobros.Activate()
            End If
        Else
            frm_consulta_recibos_cobros.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TalonariosDeCobrosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TalonariosDeCobrosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_talonarios_cobros.Visible = True Then
            If frm_consulta_talonarios_cobros.WindowState = FormWindowState.Minimized Then
                frm_consulta_talonarios_cobros.WindowState = FormWindowState.Normal
            Else
                frm_consulta_talonarios_cobros.Activate()
            End If
        Else
            frm_consulta_talonarios_cobros.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub


    Private Sub EntregaDeCobrosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EntregaDeCobrosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_entrega_cobros.Visible = True Then
            If frm_consulta_entrega_cobros.WindowState = FormWindowState.Minimized Then
                frm_consulta_entrega_cobros.WindowState = FormWindowState.Normal
            Else
                frm_consulta_entrega_cobros.Activate()
            End If
        Else
            frm_consulta_entrega_cobros.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub TitulacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TitulacionesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_titulaciones_cobros.Visible = True Then
            If frm_consulta_titulaciones_cobros.WindowState = FormWindowState.Minimized Then
                frm_consulta_titulaciones_cobros.WindowState = FormWindowState.Normal
            Else
                frm_consulta_titulaciones_cobros.Activate()
            End If
        Else
            frm_consulta_titulaciones_cobros.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub GruposDeCierresToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GruposDeCierresToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_grupos_cierre.Visible = True Then
            If frm_consulta_grupos_cierre.WindowState = FormWindowState.Minimized Then
                frm_consulta_grupos_cierre.WindowState = FormWindowState.Normal
            Else
                frm_consulta_grupos_cierre.Activate()
            End If
        Else
            frm_consulta_grupos_cierre.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ChangeTSMBlack_DropDownOpened(sender As Object, e As EventArgs)
        DirectCast(sender, ToolStripMenuItem).ForeColor = Color.Black
    End Sub

    Private Sub ChangeTSMGainsgoro_DropDownClosed(sender As Object, e As EventArgs)
        DirectCast(sender, ToolStripMenuItem).ForeColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub GotoInfoMessages_Click(sender As Object, e As EventArgs)

        If TabControl1.SelectedIndex <> 1 Then
            InfoToolStripMenuItem.PerformClick()
            DgvConversations.Focus()
        Else
            If frm_messenger.Visible = True Then
                If frm_messenger.WindowState = FormWindowState.Minimized Then
                    frm_messenger.WindowState = FormWindowState.Normal
                Else
                    frm_messenger.Activate()
                End If
            Else
                frm_messenger.Show(Me)
            End If
            frm_messenger.TabControl1.SelectedIndex = 1
        End If

    End Sub

    Private Sub AddPanelMensajesClicks()
        lblStatusBar.Text = "Cargando eventos dinámicos."
        AddHandler PanelAvisoMensajes.Click, AddressOf GotoInfoMessages_Click
        AddHandler PictureBox2.Click, AddressOf GotoInfoMessages_Click
        AddHandler Label37.Click, AddressOf GotoInfoMessages_Click
        AddHandler lblCantMensajes.Click, AddressOf GotoInfoMessages_Click
        AddHandler Label50.Click, AddressOf GotoInfoMessages_Click
    End Sub

    Private Sub AddChangeofTSMColors()
        lblStatusBar.Text = "Cargando eventos dinámicos."
        AddHandler InventarioToolStripMenuItem.DropDownOpened, AddressOf ChangeTSMBlack_DropDownOpened
        AddHandler FacturaciónToolStripMenuItem.DropDownOpened, AddressOf ChangeTSMBlack_DropDownOpened
        AddHandler CuentasPorCobrarToolStripMenuItem.DropDownOpened, AddressOf ChangeTSMBlack_DropDownOpened
        AddHandler CuentasPorPagarToolStripMenuItem.DropDownOpened, AddressOf ChangeTSMBlack_DropDownOpened
        AddHandler RecursosHumanosToolStripMenuItem.DropDownOpened, AddressOf ChangeTSMBlack_DropDownOpened
        AddHandler BancosToolStripMenuItem.DropDownOpened, AddressOf ChangeTSMBlack_DropDownOpened
        AddHandler SupervisiónToolStripMenuItem.DropDownOpened, AddressOf ChangeTSMBlack_DropDownOpened
        AddHandler CajaChicaToolStripMenuItem.DropDownOpened, AddressOf ChangeTSMBlack_DropDownOpened
        AddHandler ContabilidadToolStripMenuItem.DropDownOpened, AddressOf ChangeTSMBlack_DropDownOpened
        AddHandler ServiciosWebToolStripMenuItem.DropDownOpened, AddressOf ChangeTSMBlack_DropDownOpened
        AddHandler EstadisticasToolStripMenuItem.DropDownOpened, AddressOf ChangeTSMBlack_DropDownOpened
        AddHandler AyudaToolStripMenuItem.DropDownOpened, AddressOf ChangeTSMBlack_DropDownOpened

        AddHandler InventarioToolStripMenuItem.DropDownClosed, AddressOf ChangeTSMGainsgoro_DropDownClosed
        AddHandler FacturaciónToolStripMenuItem.DropDownClosed, AddressOf ChangeTSMGainsgoro_DropDownClosed
        AddHandler CuentasPorCobrarToolStripMenuItem.DropDownClosed, AddressOf ChangeTSMGainsgoro_DropDownClosed
        AddHandler CuentasPorPagarToolStripMenuItem.DropDownClosed, AddressOf ChangeTSMGainsgoro_DropDownClosed
        AddHandler RecursosHumanosToolStripMenuItem.DropDownClosed, AddressOf ChangeTSMGainsgoro_DropDownClosed
        AddHandler BancosToolStripMenuItem.DropDownClosed, AddressOf ChangeTSMGainsgoro_DropDownClosed
        AddHandler SupervisiónToolStripMenuItem.DropDownClosed, AddressOf ChangeTSMGainsgoro_DropDownClosed
        AddHandler CajaChicaToolStripMenuItem.DropDownClosed, AddressOf ChangeTSMGainsgoro_DropDownClosed
        AddHandler ContabilidadToolStripMenuItem.DropDownClosed, AddressOf ChangeTSMGainsgoro_DropDownClosed
        AddHandler ServiciosWebToolStripMenuItem.DropDownClosed, AddressOf ChangeTSMGainsgoro_DropDownClosed
        AddHandler EstadisticasToolStripMenuItem.DropDownClosed, AddressOf ChangeTSMGainsgoro_DropDownClosed
        AddHandler AyudaToolStripMenuItem.DropDownClosed, AddressOf ChangeTSMGainsgoro_DropDownClosed
    End Sub

    Private Sub GarantíasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GarantíasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_garantias.Visible = True Then
            If frm_mant_garantias.WindowState = FormWindowState.Minimized Then
                frm_mant_garantias.WindowState = FormWindowState.Normal
            Else
                frm_mant_garantias.Activate()
            End If
        Else
            frm_mant_garantias.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CorrespondenciaToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CorrespondenciaToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cartas_modelos_clientes.Visible = True Then
            If frm_cartas_modelos_clientes.WindowState = FormWindowState.Minimized Then
                frm_cartas_modelos_clientes.WindowState = FormWindowState.Normal
            Else
                frm_cartas_modelos_clientes.Activate()
            End If
        Else
            frm_cartas_modelos_clientes.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub


    Private Sub ActualizaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizaciónToolStripMenuItem.Click
        frm_copiar_actualizacion_sys.ShowDialog(Me)
    End Sub

    Private Sub frm_inicio_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Alt = True And e.KeyCode = Keys.F4 Then
            e.Handled = True
            CerrarSistemaToolStripMenuItem.PerformClick()

        ElseIf e.Control = True And e.KeyCode = Keys.M Then
            If Panel5.Height = 67 Then
                e.Handled = True
                MenúToolStripMenuItem.PerformClick()
            End If

        ElseIf e.Control = True And e.KeyCode = Keys.I Then
            If Panel5.Height = 67 Then
                e.Handled = True
                InfoToolStripMenuItem.PerformClick()
            End If

        ElseIf e.Control = True And e.KeyCode = Keys.C Then
            If Panel5.Height = 67 Then
                e.Handled = True
                ConfiguraciónToolStripMenuItem.PerformClick()
            End If

        ElseIf e.Control = True And e.KeyCode = Keys.L Then
            If Panel5.Height = 67 Then
                TabControl1.SelectedIndex = 0
                DgvNovedades.ClearSelection()
                DgvEmplCon.ClearSelection()
            End If

        ElseIf e.Control = True And e.KeyCode = Keys.U Then
            Button3.PerformClick()

        ElseIf e.Control = True And e.KeyCode = Keys.B Then
            btnMenuBusqueda.PerformClick()
        End If

    End Sub

    Private Sub RegistroDeCobrosSecuencialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeCobrosSecuencialToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_registro_recibos_cobro_secuencial.Visible = True Then
            If frm_registro_recibos_cobro_secuencial.WindowState = FormWindowState.Minimized Then
                frm_registro_recibos_cobro_secuencial.WindowState = FormWindowState.Normal
            Else
                frm_registro_recibos_cobro_secuencial.Activate()
            End If
        Else
            frm_registro_recibos_cobro_secuencial.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub


    Private Sub ControlDePreciosYCostosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlDePreciosYCostosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_actualizar_precios_costos.Visible = True Then
            If frm_actualizar_precios_costos.WindowState = FormWindowState.Minimized Then
                frm_actualizar_precios_costos.WindowState = FormWindowState.Normal
            Else
                frm_actualizar_precios_costos.Activate()
            End If
        Else
            frm_actualizar_precios_costos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CuentasPorCobrarToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles CuentasPorCobrarToolStripMenuItem.MouseEnter
        CuentasPorCobrarToolStripMenuItem.Image = My.Resources.creditcard_flatx48
        CuentasPorCobrarToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub CuentasPorCobrarToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles CuentasPorCobrarToolStripMenuItem.MouseLeave
        CuentasPorCobrarToolStripMenuItem.Image = My.Resources.creditcard_flatx32
        CuentasPorCobrarToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub FacturaciónToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles FacturaciónToolStripMenuItem.MouseLeave
        FacturaciónToolStripMenuItem.Image = My.Resources.Facturacion_x32
        FacturaciónToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub FacturaciónToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles FacturaciónToolStripMenuItem.MouseEnter
        FacturaciónToolStripMenuItem.Image = My.Resources.Facturacionx48
        FacturaciónToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub InventarioToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles InventarioToolStripMenuItem.MouseLeave
        InventarioToolStripMenuItem.Image = My.Resources.Stocks_x32
        InventarioToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub InventarioToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles InventarioToolStripMenuItem.MouseEnter
        InventarioToolStripMenuItem.Image = My.Resources.Inventariox48
        InventarioToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub CuentasPorPagarToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles CuentasPorPagarToolStripMenuItem.MouseLeave
        CuentasPorPagarToolStripMenuItem.Image = My.Resources.BillToPay_x32
        CuentasPorPagarToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub CuentasPorPagarToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles CuentasPorPagarToolStripMenuItem.MouseEnter
        CuentasPorPagarToolStripMenuItem.Image = My.Resources.CuentasporPagarx48
        CuentasPorPagarToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub BancosToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles BancosToolStripMenuItem.MouseLeave
        BancosToolStripMenuItem.Image = My.Resources.Bank_x32
        BancosToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub BancosToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles BancosToolStripMenuItem.MouseEnter
        BancosToolStripMenuItem.Image = My.Resources.Bancosx48
        BancosToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub RecursosHumanosToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles RecursosHumanosToolStripMenuItem.MouseLeave
        RecursosHumanosToolStripMenuItem.Image = My.Resources.HumanResources_x32
        RecursosHumanosToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub RecursosHumanosToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles RecursosHumanosToolStripMenuItem.MouseEnter
        RecursosHumanosToolStripMenuItem.Image = My.Resources.Nominax48
        RecursosHumanosToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub SupervisiónToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles SupervisiónToolStripMenuItem.MouseEnter
        SupervisiónToolStripMenuItem.Image = My.Resources.Supervisionx48
        SupervisiónToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub SupervisiónToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles SupervisiónToolStripMenuItem.MouseLeave
        SupervisiónToolStripMenuItem.Image = My.Resources.Supervisor_x32
        SupervisiónToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub CajaChicaToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles CajaChicaToolStripMenuItem.MouseLeave
        CajaChicaToolStripMenuItem.Image = My.Resources.PittyBill_x32
        CajaChicaToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub CajaChicaToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles CajaChicaToolStripMenuItem.MouseEnter
        CajaChicaToolStripMenuItem.Image = My.Resources.CajaChicax48
        CajaChicaToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub ContabilidadToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles ContabilidadToolStripMenuItem.MouseEnter
        ContabilidadToolStripMenuItem.Image = My.Resources.Contabilidadx48
        ContabilidadToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub ContabilidadToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles ContabilidadToolStripMenuItem.MouseLeave
        ContabilidadToolStripMenuItem.Image = My.Resources.Accounts_x32
        ContabilidadToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub ServiciosWebToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles ServiciosWebToolStripMenuItem.MouseLeave
        ServiciosWebToolStripMenuItem.Image = My.Resources.Utilities_x32
        ServiciosWebToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub ServiciosWebToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles ServiciosWebToolStripMenuItem.MouseEnter
        ServiciosWebToolStripMenuItem.Image = My.Resources.Utilidadesx48
        ServiciosWebToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub EstadisticasToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles EstadisticasToolStripMenuItem.MouseLeave
        EstadisticasToolStripMenuItem.Image = My.Resources.Stadistic_x32
        EstadisticasToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub EstadisticasToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles EstadisticasToolStripMenuItem.MouseEnter
        EstadisticasToolStripMenuItem.Image = My.Resources.Stadistics1x48
        EstadisticasToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub AyudaToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem.MouseEnter
        AyudaToolStripMenuItem.Image = My.Resources.LibregcoCirclex48
        AyudaToolStripMenuItem.ForeColor = Color.White
    End Sub

    Private Sub AyudaToolStripMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem.MouseLeave
        AyudaToolStripMenuItem.Image = My.Resources.LibregcoCircle_x32
        AyudaToolStripMenuItem.ForeColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub btnPerfil_Click(sender As Object, e As EventArgs) Handles btnPerfil.Click
        If NuevaEstructuracion = False Then
            SplashScreenManager1.ShowWaitForm()
            If frm_informacion_empleado.Visible = True Then
                If frm_informacion_empleado.WindowState = FormWindowState.Minimized Then
                    frm_informacion_empleado.WindowState = FormWindowState.Normal
                Else
                    frm_informacion_empleado.Activate()
                End If
            Else
                frm_informacion_empleado.Show(Me)
            End If
            SplashScreenManager1.CloseWaitForm()
        End If
    End Sub

    Private Sub PrefacturaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrefacturaciónToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_prefacturacion.Visible = True Then
            If frm_prefacturacion.WindowState = FormWindowState.Minimized Then
                frm_prefacturacion.WindowState = FormWindowState.Normal
            Else
                frm_prefacturacion.Activate()
            End If
        Else
            frm_prefacturacion.Show(Me)
        End If

        If SplashScreenManager1.IsSplashFormVisible Then
            SplashScreenManager1.CloseWaitForm()
        End If

    End Sub

    Private Sub BalanceInicialToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BalanceInicialToolStripMenuItem.Click

    End Sub

    Private Sub ConciliaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConciliaciónToolStripMenuItem.Click

    End Sub

    Private Sub ConciliaciToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConciliaciToolStripMenuItem.Click

    End Sub

    Private Sub ConciliaciToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConciliaciToolStripMenuItem1.Click

    End Sub

    Private Sub MainNotifyIcon_Click(sender As Object, e As EventArgs) Handles MainNotifyIcon.Click
        Me.Activate()
    End Sub

    Private Sub MenúToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenúToolStripMenuItem.Click
        TabControl1.SelectedIndex = 2
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        TabControl1.SelectedIndex = 1
        PropiedadesDgvs()
        DgvAlertas.ClearSelection()
        DgvConversations.ClearSelection()
        DgvCumpleanos.ClearSelection()
        DgvSolicitudes.ClearSelection()
        DgvRecordatorios.ClearSelection()
        DgvContactos.ClearSelection()

        FillContactos()
    End Sub

    Private Sub FillContactos()
        Try
            DgvContactos.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDEmpleados_contactos,Nombre,Correo,Telefono,Observacion FROM libregco.empleados_contactos where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' and Nombre like '%" & Watermark1.Text & "%' Order by Nombre ASC ", Con)
            Dim LectorContactos As MySqlDataReader = Consulta.ExecuteReader

            While LectorContactos.Read
                DgvContactos.Rows.Add(LectorContactos.GetValue(0), ReturnNotificationImage(New Font("Verdana", 18, FontStyle.Regular), New Size(48, 48), Brushes.Red, LectorContactos.GetValue(1).Substring(0, 1), Brushes.White), LectorContactos.GetValue(1), LectorContactos.GetValue(2), LectorContactos.GetValue(3), LectorContactos.GetValue(4))
            End While

            LectorContactos.Close()
            Con.Close()

            DgvContactos.ClearSelection()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub ConfiguraciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguraciónToolStripMenuItem.Click
        TabControl1.SelectedIndex = 5
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If CInt(DTAreaImpresion.Rows(0).Item("LiteMode")) = 0 Then
                If SplitContainer1.Panel1Collapsed = False Then
                    SplitContainer1.Panel1Collapsed = True
                Else
                    SplitContainer1.Panel1Collapsed = False
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If CInt(DTAreaImpresion.Rows(0).Item("LiteMode")) = 0 Then
            CargarEquipos()

            ConMixta.Open()
            Ds.Clear()
            cmd = New MySqlCommand("Select IDPermisoEmpleado,IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir,Explicacion from" & SysName.Text & " PermisosEmpleados INNER JOIN" & SysName.Text & "Permisos on PermisosEmpleados.IDPermiso=Permisos.IDPermisos Where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' and IDPermiso=261", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "PermisosEmpleados")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("PermisosEmpleados")

            If NuevaEstructuracion = True Then
                DgvEquipos.Enabled = True
            Else
                If Tabla.Rows.Count = 0 Then
                    DgvEquipos.Enabled = False
                Else
                    If Tabla.Rows(0).Item(3) = 1 Then
                        DgvEquipos.Enabled = True
                    Else
                        DgvEquipos.Enabled = False
                    End If
                End If
            End If

            TabControl1.SelectedIndex = 4

            Tabla.Dispose()
        End If

    End Sub

    Private Sub PicMinLogo_Click(sender As Object, e As EventArgs) Handles PicMinLogo.Click
        If CInt(DTAreaImpresion.Rows(0).Item("LiteMode")) = 0 Then
            TabControl1.SelectedIndex = 0
            DgvNovedades.ClearSelection()
            DgvEmplCon.ClearSelection()
        End If
    End Sub

    Private Sub Label40_Click(sender As Object, e As EventArgs) Handles Label40.Click
        TabControl1.SelectedIndex = 2
        Panel5.Height = 67
        Label40.Visible = False
    End Sub

    Private Function VScrollBarVisible() As Boolean
        Dim ctrl As New Control
        For Each ctrl In SplitContainer1.Panel1.Controls
            If ctrl.GetType() Is GetType(VScrollBar) Then
                If ctrl.Visible = True Then
                    Return True
                Else
                    Return False
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnMenuBusqueda.Click
        If TabControl1.SelectedIndex <> 3 Then
            TabControl1.SelectedIndex = 3
        Else
            TabControl1.SelectedIndex = 2
        End If
    End Sub

    Private Sub rdbOscuro_CheckedChanged(sender As Object, e As EventArgs) Handles rdbOscuro.CheckedChanged
        If FormIsLoaded Then
            ChangeColors()
        End If
    End Sub

    'Private Sub SetColorsByCheck()
    '    Dim ColorLeft As New Color
    '    Dim ColorTop As New Color
    '    Dim ColorBackGround As New Color
    '    Dim ColorFont As New Color

    '    If rdbOscuro.Checked = True Then
    '        ColorFont = SystemColors.ControlLight
    '        ColorLeft = Color.FromArgb(255, 88, 88, 88)
    '        ColorTop = Color.FromArgb(255, 88, 88, 88)
    '        ColorBackGround = Color.FromArgb(255, 88, 88, 88)

    '    ElseIf rdbClaro.Checked = True Then

    '    End If
    'End Sub
    Private Sub ChangeColors()


        If rdbOscuro.Checked = True Then
            Panel5.BackColor = Color.FromArgb(255, 88, 88, 88)
            Panel7.BackColor = Color.FromArgb(255, 88, 88, 88)
            FlowLayoutPanel1.BackColor = Panel7.BackColor
            Label6.ForeColor = SystemColors.ButtonFace
            Label8.ForeColor = SystemColors.ButtonFace
            MenúToolStripMenuItem.ForeColor = SystemColors.ControlLight
            InfoToolStripMenuItem.ForeColor = SystemColors.ControlLight
            MenúToolStripMenuItem.Image = My.Resources.MenuWhitex26
            InfoToolStripMenuItem.Image = My.Resources.InfoWhitex26
            ConfiguraciónToolStripMenuItem.ForeColor = SystemColors.ControlLight
            ConfiguraciónToolStripMenuItem.Image = My.Resources.SettingsWhitex26
            ToolStripMenuItem2.Image = My.Resources.Networkx26
            ToolStripMenuItem2.ForeColor = SystemColors.ControlLight
            Label40.Image = My.Resources.ExpandArrowWhitex26
            Label41.Image = My.Resources.CompressWhitex26
            TabPage1.BackColor = Color.FromArgb(255, 88, 88, 88)
            TabPage2.BackColor = Color.FromArgb(255, 88, 88, 88)
            TabPage3.BackColor = Color.FromArgb(255, 88, 88, 88)
            TabPage4.BackColor = Color.FromArgb(255, 88, 88, 88)
            TabPage5.BackColor = Color.FromArgb(255, 88, 88, 88)
            TabPage6.BackColor = Color.FromArgb(255, 88, 88, 88)
            Me.BackColor = Color.FromArgb(255, 88, 88, 88)
            SplitContainer1.Panel1.BackColor = Color.FromArgb(255, 88, 88, 88)
            SplitContainer1.Panel2.BackColor = Color.FromArgb(255, 88, 88, 88)
            SplitContainer1.BackColor = Color.FromArgb(255, 88, 88, 88)
            Label8.ForeColor = Color.White
            Label9.ForeColor = Color.White
            lblFecha.ForeColor = SystemColors.ControlLight
            lblHora.ForeColor = SystemColors.ControlLight
            DgvConversations.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 88, 88, 88)
            DgvConversations.DefaultCellStyle.SelectionForeColor = SystemColors.ControlLight
            PictureBox1.Image = My.Resources.BusquedaMenuWhitex48
            NavigationPane2.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
            NavBarControl4.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
            NavigationPane2.Pages(0).ImageOptions.Image = My.Resources.Social1White
            NavigationPane2.Pages(1).ImageOptions.Image = My.Resources.NotesWhite
            NavigationPane2.Pages(2).ImageOptions.Image = My.Resources.ClockWhite
            NavigationPane2.Pages(3).ImageOptions.Image = My.Resources.WarningWhite
            NavigationPane2.Pages(4).ImageOptions.Image = My.Resources.ScheduleWhite
            NavigationPane2.Pages(5).ImageOptions.Image = My.Resources.chartwhite
            NavBarMensajeria.ImageOptions.LargeImage = My.Resources.chat32White
            NavBarCumpleanos.ImageOptions.LargeImage = My.Resources.Cake32White
            NavBarNotas.ImageOptions.LargeImage = My.Resources.notes32White
            NavBarRecordatorios.ImageOptions.LargeImage = My.Resources.reminder32White
            NavBarSolicitudes.ImageOptions.LargeImage = My.Resources.solicitudes32White
            NavAlertas.ImageOptions.LargeImage = My.Resources.clockwhite_32
            NavBouchers.ImageOptions.LargeImage = My.Resources.boucherwhite_32
            NavBarContactos.ImageOptions.LargeImage = My.Resources.Contact32White
            btnIrAgenda.ImageOptions.Image = My.Resources.Calendar32White
            NavBarControl4.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
            frm_agenda.BarAndDockingController1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
            frm_agenda.RangeControl1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
            frm_agenda.SchedulerControl1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
            txtNotas.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
            SimpleButton1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
            LabelControl6.ForeColor = Color.White
            LabelControl7.ForeColor = Color.White
            LabelControl8.ForeColor = Color.White
            LabelControl9.ForeColor = Color.White
            LabelControl10.ForeColor = Color.White

            If DTEmpleado.Rows.Count <> 0 Then
                ConMixta.Open()
                sqlQ = "UPDATE" & SysName.Text & "Empleados SET ColorMode=1 Where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConMixta)
                cmd.ExecuteNonQuery()
                ConMixta.Close()
            End If

        ElseIf rdbClaro.Checked = True Then
            Panel5.BackColor = Color.FromArgb(255, 250, 250, 250)
            Panel7.BackColor = Color.FromArgb(255, 230, 230, 230)
            FlowLayoutPanel1.BackColor = Panel7.BackColor
            Label6.ForeColor = Color.Black
            Label8.ForeColor = Color.Black
            MenúToolStripMenuItem.ForeColor = Color.Black
            InfoToolStripMenuItem.ForeColor = Color.Black
            ConfiguraciónToolStripMenuItem.ForeColor = Color.Black
            MenúToolStripMenuItem.Image = My.Resources.MenuBlackx26
            InfoToolStripMenuItem.Image = My.Resources.InfoBlackx26
            ConfiguraciónToolStripMenuItem.Image = My.Resources.SettingsBlack26
            ToolStripMenuItem2.Image = My.Resources.Networkx26Black
            ToolStripMenuItem2.ForeColor = Color.Black
            Label40.Image = My.Resources.ExpandArrowBlackx26
            Label41.Image = My.Resources.CompressBackx26
            TabPage1.BackColor = SystemColors.ControlLight
            TabPage2.BackColor = SystemColors.ControlLight
            TabPage3.BackColor = SystemColors.ControlLight
            TabPage4.BackColor = SystemColors.ControlLight
            TabPage5.BackColor = SystemColors.ControlLight
            TabPage6.BackColor = SystemColors.ControlLight
            SplitContainer1.Panel1.BackColor = SystemColors.ControlLight
            SplitContainer1.Panel2.BackColor = SystemColors.ControlLight
            SplitContainer1.BackColor = SystemColors.ControlLight
            Label8.ForeColor = Color.Black
            Label9.ForeColor = Color.Black
            lblFecha.ForeColor = Color.Black
            lblHora.ForeColor = Color.Black
            Me.BackColor = SystemColors.ControlLight
            DgvConversations.DefaultCellStyle.SelectionBackColor = SystemColors.ControlLight
            DgvConversations.DefaultCellStyle.SelectionForeColor = Color.Black
            PictureBox1.Image = My.Resources.BusquedaMenux48
            NavigationPane2.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
            NavBarControl4.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
            NavigationPane2.Pages(0).ImageOptions.Image = My.Resources.Social1Black
            NavigationPane2.Pages(1).ImageOptions.Image = My.Resources.NotesBlack
            NavigationPane2.Pages(2).ImageOptions.Image = My.Resources.ClockBlack
            NavigationPane2.Pages(3).ImageOptions.Image = My.Resources.WarningBlack
            NavigationPane2.Pages(4).ImageOptions.Image = My.Resources.ScheduleBlack
            NavigationPane2.Pages(5).ImageOptions.Image = My.Resources.chartblack
            NavBarMensajeria.ImageOptions.LargeImage = My.Resources.chat32Black
            NavBarCumpleanos.ImageOptions.LargeImage = My.Resources.Cake32Black
            NavBarNotas.ImageOptions.LargeImage = My.Resources.Notes32Black
            NavBarRecordatorios.ImageOptions.LargeImage = My.Resources.reminder32Black
            NavBarSolicitudes.ImageOptions.LargeImage = My.Resources.solicitudes32Black
            NavAlertas.ImageOptions.LargeImage = My.Resources.clockblack_32
            NavBouchers.ImageOptions.LargeImage = My.Resources.boucherblack_32
            NavBarContactos.ImageOptions.LargeImage = My.Resources.Contact32Black
            btnIrAgenda.ImageOptions.Image = My.Resources.Calendar32Black

            NavBarControl4.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
            frm_agenda.BarAndDockingController1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
            frm_agenda.RangeControl1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
            frm_agenda.SchedulerControl1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
            txtNotas.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
            SimpleButton1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
            LabelControl6.ForeColor = Color.Black
            LabelControl7.ForeColor = Color.Black
            LabelControl8.ForeColor = Color.Black
            LabelControl9.ForeColor = Color.Black
            LabelControl10.ForeColor = Color.Black

            If DTEmpleado.Rows.Count <> 0 Then
                ConMixta.Open()
                sqlQ = "UPDATE" & SysName.Text & "Empleados SET ColorMode=2 Where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConMixta)
                cmd.ExecuteNonQuery()
                ConMixta.Close()
            End If
        End If

        OverLoadNotification()
        txtBuscarModulos.Text = ""
    End Sub

    Private Sub txtBuscarModulos_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarModulos.TextChanged
        Try

            Dim DsTemp As New DataSet

            If txtBuscarModulos.Text = "" Then
                MenuNuevo.Items.Clear()
                Button6.Visible = False
            Else
                Button6.Visible = True
                MenuNuevo.Items.Clear()

                DsTemp.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDPermisos,Descripcion,Explicacion,IDProceso,Proceso,Modulo FROM" & SysName.Text & "permisos inner join" & SysName.Text & "modulos on permisos.IDModulo=Modulos.IDModulo inner join libregco.procesosmodulo on permisos.idproceso=procesosmodulo.idprocesosmodulo where Modulos.Habilitar=1 and MostrarIcono=1 and permisos.Descripcion like '%" & txtBuscarModulos.Text & "%' LIMIT 15", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "permisos")
                Con.Close()

                Dim Tabla As DataTable = DsTemp.Tables("permisos")
                If Tabla.Rows.Count = 0 Then

                    If rdbOscuro.Checked = True Then
                        PictureBox1.Image = My.Resources.BusquedaMenuWhitex48
                    Else
                        PictureBox1.Image = My.Resources.BusquedaMenux48
                    End If

                    PictureBox1.Visible = True
                    Label9.Visible = False
                    Label8.Visible = True
                Else
                    PictureBox1.Visible = False
                    Label9.Visible = True
                    Label8.Visible = False

                    For Each row As DataRow In Tabla.Rows
                        Dim NewToolStrip As New ToolStripMenuItem
                        Dim InfoToolStrip As New ToolStripMenuItem
                        Dim Separt As New ToolStripSeparator

                        AddHandler NewToolStrip.Click, AddressOf ClickModulo

                        NewToolStrip.AutoSize = True
                        NewToolStrip.Text = row.Item("Descripcion")
                        NewToolStrip.Tag = row.Item("IDPermisos")
                        NewToolStrip.ToolTipText = row.Item("Explicacion")
                        NewToolStrip.TextAlign = ContentAlignment.MiddleLeft
                        NewToolStrip.ForeColor = Label6.ForeColor
                        NewToolStrip.Font = New Font("Segoe UI", 12, FontStyle.Regular)
                        NewToolStrip.Enabled = True

                        MenuNuevo.Items.Add(NewToolStrip)

                        InfoToolStrip.AutoSize = True
                        InfoToolStrip.Text = row.Item("Modulo") & "\" & row.Item("Proceso")
                        InfoToolStrip.TextAlign = ContentAlignment.MiddleLeft
                        InfoToolStrip.Enabled = False
                        InfoToolStrip.Font = New Font("Segoe UI", 9, FontStyle.Italic)
                        InfoToolStrip.ForeColor = Label6.ForeColor

                        MenuNuevo.Items.Add(InfoToolStrip)
                        MenuNuevo.Items.Add(Separt)
                    Next

                End If

                DsTemp.Dispose()
                Tabla.Dispose()
            End If




        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
            Con.Close()
            MenuNuevo.Items.Clear()
        End Try
    End Sub

    Private Sub ClickModulo(Sendr As Object, e As EventArgs)
        Try

            Dim btn As ToolStripMenuItem
            Dim lblIDPermiso, ModuloInt As New Label

            btn = CType(Sendr, ToolStripMenuItem)
            lblIDPermiso.Text = btn.Tag


            Con.Open()
            Ds.Clear()
            cmd = New MySqlCommand("SELECT Descripcion,IDModulo,IDProceso FROM Permisos where IDPermisos='" + lblIDPermiso.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "permisos")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("permisos")

            For Each TStrip As ToolStripMenuItem In MenuBar.Items 'Nombre de modulo

                If TStrip.Tag = (Tabla.Rows(0).Item("IDModulo")) Then

                    For Each SubStrip As ToolStripMenuItem In TStrip.DropDownItems 'Nombre de proceso

                        If SubStrip.Tag = (Tabla.Rows(0).Item("IDProceso")) Then

                            For Each Strip As Object In SubStrip.DropDownItems  'Nombre de permiso
                                If Not Strip.ToString.Contains("Separator") Then

                                    If DirectCast(Strip, ToolStripMenuItem).Tag = lblIDPermiso.Text Then
                                        DirectCast(Strip, ToolStripMenuItem).PerformClick()
                                        Exit For
                                    End If

                                End If
                            Next

                            Exit For  'Si el proceso es encontrado salgo del bucle
                        End If
                    Next

                    Exit For  'Si el modulo es encontrado salgo del bucle

                End If

            Next

            Tabla.Dispose()
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        SplashScreenManager1.ShowWaitForm()
        If frm_messenger.Visible = True Then
            If frm_messenger.WindowState = FormWindowState.Minimized Then
                frm_messenger.WindowState = FormWindowState.Normal
            Else
                frm_messenger.Activate()
            End If
        Else
            frm_messenger.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ActualizaLibregcoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizaLibregcoToolStripMenuItem.Click
        frm_copiar_actualizacion_sys.ShowDialog(Me)
    End Sub

    Private Sub RichExtras_MouseEnter(sender As Object, e As EventArgs) Handles RichExtras.MouseEnter
        If RichExtras.ScrollBars = ScrollBars.None Then
            RichExtras.ScrollBars = ScrollBars.Vertical
        End If
    End Sub

    Private Sub RichExtras_MouseLeave(sender As Object, e As EventArgs) Handles RichExtras.MouseLeave
        If RichExtras.ScrollBars = ScrollBars.Vertical Then
            RichExtras.ScrollBars = ScrollBars.None
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txtBuscarModulos.Text = ""
        txtBuscarModulos.Focus()
    End Sub

    Private Sub CbxSizes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxSizes.SelectedIndexChanged
        If cbxEstadoVentana.SelectedIndex = 0 Then
            Dim NewHeight, NewWidth As String

            NewWidth = Replace(Split(CbxSizes.Text, "x", 2)(0), " ", "")
            NewHeight = Replace(Split(CbxSizes.Text, "x", 2)(1), " ", "")
            Me.Size = New Size(NewWidth, NewHeight)

            SplitContainer1.SplitterDistance = 251
            PropiedadesDgvs()
            Me.CenterToScreen()
        End If

        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "AreaImpresion SET SizeIndex='" + CbxSizes.SelectedIndex.ToString + "' WHERE IDEquipo= '" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()

    End Sub

    Private Sub AgendaDeChequesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgendaDeChequesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_agenda_cheques.Visible = True Then
            If frm_agenda_cheques.WindowState = FormWindowState.Minimized Then
                frm_agenda_cheques.WindowState = FormWindowState.Normal
            Else
                frm_agenda_cheques.Activate()
            End If
        Else
            frm_agenda_cheques.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CursosEnVídeoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CursosEnVídeoToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_tutoriales.Visible = True Then
            If frm_tutoriales.WindowState = FormWindowState.Minimized Then
                frm_tutoriales.WindowState = FormWindowState.Normal
            Else
                frm_tutoriales.Activate()
            End If
        Else
            frm_tutoriales.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub chkMantenerDelante_CheckedChanged(sender As Object, e As EventArgs) Handles chkMantenerDelante.CheckedChanged
        Me.TopMost = chkMantenerDelante.CheckState

        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "Empleados SET MostrarenTope='" + Convert.ToInt16(chkMantenerDelante.CheckState).ToString + "' Where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()

    End Sub

    Private Sub chkAbrirAutomatico_CheckedChanged(sender As Object, e As EventArgs) Handles chkAbrirAutomatico.CheckedChanged

        If chkAbrirAutomatico.Checked = True Then
            Dim RegKey As Microsoft.Win32.RegistryKey
            Dim KeyName As String = "Software\Microsoft\Windows\CurrentVersion\Run"
            Dim ValueName As String = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Application.ProductName)
            Dim Value As String = Application.ExecutablePath

            RegKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(KeyName, True)
            RegKey.SetValue(ValueName, Value, RegistryValueKind.String)

        Else

            Dim RegKey As Microsoft.Win32.RegistryKey
            Dim KeyName As String = "Software\Microsoft\Windows\CurrentVersion\Run"
            Dim ValueName As String = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Application.ProductName)
            Dim Value As String = Application.ExecutablePath

            RegKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(KeyName, True)
            RegKey.DeleteValue(ValueName)
        End If

        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "AreaImpresion SET AutomaticStartup='" + Convert.ToInt16(chkAbrirAutomatico.CheckState).ToString + "' Where IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()

    End Sub


    Private Sub TimerConsejos_Tick(sender As Object, e As EventArgs) Handles TimerConsejos.Tick
        Try
            If chkHabilitarNotify.Checked = True Then
                If chkShowConsejos.Checked = True Then
                    If ConMixta.State = ConnectionState.Open Then
                        ConMixta.Close()
                    End If

                    Ds.Clear()
                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT IDConsejos,IDPermiso,Modulo,Descripcion,Consejo FROM libregco_utilitarios.consejos INNER JOIN" & SysName.Text & "Permisos on Consejos.IDPermiso=Permisos.IDPermisos INNER JOIN" & SysName.Text & "Modulos on Permisos.IDModulo=Modulos.IDModulo", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "Consejo")
                    ConMixta.Close()

                    Dim Tabla As DataTable = Ds.Tables("Consejo")

                    Randomize()
                    Dim RandomValue As Integer = CInt(Math.Floor(Tabla.Rows.Count - 1) * Rnd())

                    Dim NotifyUsers As New NotifyIcon

                    NotifyUsers.Visible = False
                    NotifyUsers.Icon = My.Resources.Libregco_Icon
                    NotifyUsers.BalloonTipIcon = ToolTipIcon.Info

                    With NotifyUsers
                        .Visible = True
                        .Text = "Consejos para el usuario"
                        .BalloonTipTitle = Tabla.Rows(RandomValue).Item("Modulo") & "/" & Tabla.Rows(RandomValue).Item("Descripcion")
                        .BalloonTipText = "« " & Tabla.Rows(RandomValue).Item("Consejo") & " »"
                        .ShowBalloonTip(5)
                        .Visible = False
                    End With

                    NotifyUsers.Dispose()
                    Tabla.Dispose()
                End If

            End If


        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub chkHabilitarNotify_CheckedChanged(sender As Object, e As EventArgs) Handles chkHabilitarNotify.CheckedChanged
        If chkHabilitarNotify.Checked = True Then
            chkShowConsejos.Enabled = True
        Else
            chkShowConsejos.Checked = False
            chkShowConsejos.Enabled = False
            TimerConsejos.Enabled = False
        End If

        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "Empleados SET HabilitarNotificaciones='" + Convert.ToInt16(chkHabilitarNotify.CheckState).ToString + "' Where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()
    End Sub

    Private Sub chkMostrarContenidoNotificacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarContenidoNotificacion.CheckedChanged

        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "Empleados SET MostrarContenido='" + Convert.ToInt16(chkMostrarContenidoNotificacion.CheckState).ToString + "' Where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()

    End Sub

    Private Sub chkShowConsejos_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowConsejos.CheckedChanged
        If chkShowConsejos.Checked = True Then
            If chkHabilitarNotify.Checked = True Then
                TimerConsejos.Enabled = True
            End If

        Else
            TimerConsejos.Enabled = False
        End If

        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "Empleados SET MostrarConsejos='" + Convert.ToInt16(chkShowConsejos.CheckState).ToString + "' Where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()

    End Sub

    Private Sub ChkBloqueoInactividad_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBloqueoInactividad.CheckedChanged
        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "Empleados SET BloqueoInactividad='" + Convert.ToInt16(ChkBloqueoInactividad.CheckState).ToString + "' Where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()
    End Sub

    Private Sub chkMuteApp_CheckedChanged(sender As Object, e As EventArgs) Handles chkMuteApp.CheckedChanged
        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "AreaImpresion SET MuteApp='" + Convert.ToInt16(chkMuteApp.CheckState).ToString + "' Where IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()
    End Sub

    Private Sub frm_inicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If CerrarSistemaToolStripMenuItem.Tag = 0 Then
                Me.Focus()
                Me.Activate()

                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea salir del sistema?", "Salir del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then

                    If IsNumeric(DTEmpleado.Rows(0).Item("IDEmpleado").ToString) Then

                        Dim lista As New FormCollection
                        lista = Application.OpenForms
                        For Each a As Form In lista
                            If a.Name <> Me.Name Then
                                a.Close()
                            End If
                        Next

                        If ArNotificaciones.Count < 7 Then
                            ArNotificaciones = Split(Join(ArNotificaciones, ",") + ",1")
                        End If


                        Con.Open()
                        sqlQ = "UPDATE" & SysName.Text & "Empleados SET Conectado=0,NotificacionStart='" + String.Join(",", ArNotificaciones).ToString + "' WHERE IDEmpleado= '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()


                        sqlQ = "UPDATE" & SysName.Text & "Bitacora SET Abierta=0 WHERE IDEntrada= '" + IDBitacora.Text + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()

                        sqlQ = "DELETE FROM" & SysName.Text & "BitacoraDetalle Where IDBitacora = (" + IDBitacora.Text + ")"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                        Con.Close()

                        DeleteAllBicatoraDetalleEquipo()
                    End If

                Else
                    e.Cancel = True
                End If

            ElseIf CerrarSistemaToolStripMenuItem.Tag = 1 Then

                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea cambiar el usuario del sistema?", "Cambiar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    If IsNumeric(DTEmpleado.Rows(0).Item("IDEmpleado").ToString) Then
                        Con.Open()
                        sqlQ = "UPDATE" & SysName.Text & "Empleados SET Conectado=0,NotificacionStart='" + String.Join(",", ArNotificaciones).ToString + "' WHERE IDEmpleado= '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()


                        sqlQ = "UPDATE" & SysName.Text & "Bitacora SET Abierta=0 WHERE IDEntrada= '" + IDBitacora.Text + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()

                        sqlQ = "Delete from" & SysName.Text & "BitacoraDetalle Where IDBitacora = (" + IDBitacora.Text + ")"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                        Con.Close()

                        DeleteAllBicatoraDetalleEquipo()

                        frm_LoginSistema.Show()
                    End If
                Else
                    e.Cancel = True
                End If

            ElseIf CerrarSistemaToolStripMenuItem.Tag = 2 Then

                If IsNumeric(DTEmpleado.Rows(0).Item("IDEmpleado").ToString) Then
                    Con.Open()
                    sqlQ = "UPDATE" & SysName.Text & "Empleados SET Conectado=0,NotificacionStart='" + String.Join(",", ArNotificaciones).ToString + "' WHERE IDEmpleado= '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()


                    sqlQ = "UPDATE" & SysName.Text & "Bitacora SET Abierta=0 WHERE IDEntrada= '" + IDBitacora.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()

                    sqlQ = "Delete from" & SysName.Text & "BitacoraDetalle Where IDBitacora = (" + IDBitacora.Text + ")"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    Con.Close()

                    DeleteAllBicatoraDetalleEquipo()

                    frm_LoginSistema.Show()
                    frm_LoginSistema.lblInformacion.ForeColor = Color.Black
                    frm_LoginSistema.lblInformacion.Text = "El sistema ha sido suspendido por inactividad"
                End If

            ElseIf CerrarSistemaToolStripMenuItem.Tag = 3 Then

                If IsNumeric(DTEmpleado.Rows(0).Item("IDEmpleado").ToString) Then

                    frm_cierre_equipos.ShowDialog(Me)

                    Con.Open()
                    sqlQ = "UPDATE" & SysName.Text & "Empleados SET Conectado=0,NotificacionStart='" + String.Join(",", ArNotificaciones).ToString + "' WHERE IDEmpleado= '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()

                    sqlQ = "UPDATE" & SysName.Text & "AreaImpresion SET Suspender=0 Where IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "'"
                    cmd = New MySqlCommand(sqlQ, Connon)
                    cmd.ExecuteNonQuery()

                    sqlQ = "UPDATE" & SysName.Text & "Bitacora SET Abierta=0 WHERE IDEntrada= '" + IDBitacora.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()

                    sqlQ = "Delete from" & SysName.Text & "BitacoraDetalle Where IDBitacora = (" + IDBitacora.Text + ")"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    Con.Close()

                    DeleteAllBicatoraDetalleEquipo()
                End If

            ElseIf CerrarSistemaToolStripMenuItem.Tag = 4 Then

                If IsNumeric(DTEmpleado.Rows(0).Item("IDEmpleado").ToString) Then
                    Con.Open()
                    sqlQ = "UPDATE" & SysName.Text & "Empleados SET Conectado=0,NotificacionStart='" + String.Join(",", ArNotificaciones).ToString + "' WHERE IDEmpleado= '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()

                    sqlQ = "UPDATE" & SysName.Text & "AreaImpresion SET Suspender=0 Where IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "'"
                    cmd = New MySqlCommand(sqlQ, Connon)
                    cmd.ExecuteNonQuery()

                    sqlQ = "UPDATE" & SysName.Text & "Bitacora SET Abierta=0 WHERE IDEntrada= '" + IDBitacora.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()

                    sqlQ = "Delete from" & SysName.Text & "BitacoraDetalle Where IDBitacora = (" + IDBitacora.Text + ")"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    Con.Close()

                    DeleteAllBicatoraDetalleEquipo()
                End If


            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ReportarUnErrorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportarUnErrorToolStripMenuItem.Click
        frm_reporte_bugs.ShowDialog(Me)
    End Sub

    Private Sub CorrespondenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorrespondenciaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cartas_modelos_facturas.Visible = True Then
            If frm_cartas_modelos_facturas.WindowState = FormWindowState.Minimized Then
                frm_cartas_modelos_facturas.WindowState = FormWindowState.Normal
            Else
                frm_cartas_modelos_facturas.Activate()
            End If
        Else
            frm_cartas_modelos_facturas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EntregaDeCuentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntregaDeCuentasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_entrega_cuentas.Visible = True Then
            If frm_entrega_cuentas.WindowState = FormWindowState.Minimized Then
                frm_entrega_cuentas.WindowState = FormWindowState.Normal
            Else
                frm_entrega_cuentas.Activate()
            End If
        Else
            frm_entrega_cuentas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub label41_Click(sender As Object, e As EventArgs) Handles Label41.Click
        SplitContainer1.Panel1Collapsed = True
        TabControl1.SelectedIndex = 2
        Panel5.Height = 0
        Label40.Visible = True
        Me.CenterToScreen()
    End Sub


    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        TabControl1.SelectedIndex = 6
    End Sub

    Private Sub InventarioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles InventarioToolStripMenuItem1.Click
        frm_incompletos_clientes.ShowDialog(Me)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub Label48_Click(sender As Object, e As EventArgs) Handles Label48.Click
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub EventosDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EventosDeToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_eventos_boleteria.Visible = True Then
            If frm_eventos_boleteria.WindowState = FormWindowState.Minimized Then
                frm_eventos_boleteria.WindowState = FormWindowState.Normal
            Else
                frm_eventos_boleteria.Activate()
            End If
        Else
            frm_eventos_boleteria.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub cbxPrintMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPrintMode.SelectedIndexChanged
        If cbxPrintMode.Text = "Controlado por diseñador" Then
            cbxPrintMode.Tag = 1
        ElseIf cbxPrintMode.Text = "Controlado por driver" Then
            cbxPrintMode.Tag = 2
        ElseIf cbxPrintMode.Text = "Controlado por sistema" Then
            cbxPrintMode.Tag = 0
        End If

        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "AreaImpresion SET PrinterMode='" + cbxPrintMode.Tag.ToString + "' WHERE IDEquipo= '" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()

    End Sub

    Private Sub DepósitoDeFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepósitoDeFacturaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_deposito_factura.Visible = True Then
            If frm_deposito_factura.WindowState = FormWindowState.Minimized Then
                frm_deposito_factura.WindowState = FormWindowState.Normal
            Else
                frm_deposito_factura.Activate()
            End If
        Else
            frm_deposito_factura.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub GToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_gestiones_clientes.Visible = True Then
            If frm_gestiones_clientes.WindowState = FormWindowState.Minimized Then
                frm_gestiones_clientes.WindowState = FormWindowState.Normal
            Else
                frm_gestiones_clientes.Activate()
            End If
        Else
            frm_gestiones_clientes.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        If CInt(DTAreaImpresion.Rows(0).Item("LiteMode")) = 0 Then
            TabControl1.SelectedIndex = 0
            DgvNovedades.ClearSelection()
            DgvEmplCon.ClearSelection()
        End If
    End Sub


    Private Sub PrestacionesLaboralesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrestacionesLaboralesToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_prestaciones_laborales.Visible = True Then
            If frm_prestaciones_laborales.WindowState = FormWindowState.Minimized Then
                frm_prestaciones_laborales.WindowState = FormWindowState.Normal
            Else
                frm_prestaciones_laborales.Activate()
            End If
        Else
            frm_prestaciones_laborales.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DíasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DíasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_mant_dias_esp.Visible = True Then
            If frm_mant_dias_esp.WindowState = FormWindowState.Minimized Then
                frm_mant_dias_esp.WindowState = FormWindowState.Normal
            Else
                frm_mant_dias_esp.Activate()
            End If
        Else
            frm_mant_dias_esp.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub VacacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VacacionesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_empleados_vacaciones.Visible = True Then
            If frm_empleados_vacaciones.WindowState = FormWindowState.Minimized Then
                frm_empleados_vacaciones.WindowState = FormWindowState.Normal
            Else
                frm_empleados_vacaciones.Activate()
            End If
        Else
            frm_empleados_vacaciones.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub VacacionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VacacionesToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_vacaciones.Visible = True Then
            If frm_reporte_vacaciones.WindowState = FormWindowState.Minimized Then
                frm_reporte_vacaciones.WindowState = FormWindowState.Normal
            Else
                frm_reporte_vacaciones.Activate()
            End If
        Else
            frm_reporte_vacaciones.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub VacacionesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles VacacionesToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_vacaciones.Visible = True Then
            If frm_consulta_vacaciones.WindowState = FormWindowState.Minimized Then
                frm_consulta_vacaciones.WindowState = FormWindowState.Normal
            Else
                frm_consulta_vacaciones.Activate()
            End If
        Else
            frm_consulta_vacaciones.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub AsistenciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsistenciasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_asistencias.Visible = True Then
            If frm_asistencias.WindowState = FormWindowState.Minimized Then
                frm_asistencias.WindowState = FormWindowState.Normal
            Else
                frm_asistencias.Activate()
            End If
        Else
            frm_asistencias.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        frm_entrada_asistencia.ShowDialog(Me)
    End Sub

    Private Sub ColoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColoresToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_colores.Visible = True Then
            If frm_colores.WindowState = FormWindowState.Minimized Then
                frm_colores.WindowState = FormWindowState.Normal
            Else
                frm_colores.Activate()
            End If
        Else
            frm_colores.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub Watermark1_TextChanged(sender As Object, e As EventArgs) Handles Watermark1.TextChanged
        If Watermark1.Text = "" Then
            Button1.Visible = False
        Else
            Button1.Visible = True
            FillContactos()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Watermark1.Text = ""
        FillContactos()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Con.Open()
        sqlQ = "UPDATE" & SysName.Text & "Empleados SET Memos='" + Replace(txtNotas.Text.ToString, "'", "") + "' WHERE IDEmpleado= '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
        cmd = New MySqlCommand(sqlQ, Con)
        cmd.ExecuteNonQuery()
        Con.Close()
    End Sub

    Private Sub chkNotificacionAgenda_Toggled(sender As Object, e As EventArgs) Handles chkNotificacionAgenda.Toggled
        If FormIsLoaded = True Then
            ArNotificaciones(5) = Convert.ToInt16(chkNotificacionAgenda.IsOn)

            LoadSchedule()

            OverLoadNotification()
        End If

    End Sub

    Private Sub chkNotificacionAlertas_Toggled(sender As Object, e As EventArgs) Handles chkNotificacionAlertas.Toggled
        If FormIsLoaded = True Then
            ArNotificaciones(4) = Convert.ToInt16(chkNotificacionAlertas.IsOn)

            CargarAlertas()

            OverLoadNotification()
        End If

    End Sub

    Private Sub chkNotificacionSolicitudes_Toggled(sender As Object, e As EventArgs) Handles chkNotificacionSolicitudes.Toggled
        If FormIsLoaded = True Then
            ArNotificaciones(3) = Convert.ToInt16(chkNotificacionSolicitudes.IsOn)

            CargarSolicitudes()

            OverLoadNotification()
        End If
    End Sub

    Private Sub chkNotificacionRecordatorio_Toggled(sender As Object, e As EventArgs) Handles chkNotificacionRecordatorio.Toggled
        If FormIsLoaded = True Then
            ArNotificaciones(2) = Convert.ToInt16(chkNotificacionRecordatorio.IsOn)

            CargarRecordatorios()

            OverLoadNotification()
        End If
    End Sub

    Private Sub chkNotificacionCumpleanos_Toggled(sender As Object, e As EventArgs) Handles chkNotificacionCumpleanos.Toggled
        If FormIsLoaded = True Then
            ArNotificaciones(1) = Convert.ToInt16(chkNotificacionCumpleanos.IsOn)

            CargarCumpleanos()

            OverLoadNotification()
        End If
    End Sub

    Private Sub chkNotificacionChat_Toggled(sender As Object, e As EventArgs) Handles chkNotificacionChat.Toggled
        If FormIsLoaded = True Then
            ArNotificaciones(0) = Convert.ToInt16(chkNotificacionChat.IsOn)

            CargarChat()

            OverLoadNotification()
        End If
    End Sub

    Private Sub chkBoucher_Toggled(sender As Object, e As EventArgs) Handles chkBoucher.Toggled
        If FormIsLoaded = True Then

            If ArNotificaciones.Count < 7 Then
                chkBoucher.IsOn = True
                ArNotificaciones = Split(Join(ArNotificaciones, ",") + ",1")

            Else
                ArNotificaciones(6) = Convert.ToInt16(chkBoucher.IsOn)
            End If

            CargarBouchers()

            OverLoadNotification()
        End If
    End Sub

    Private Sub cbxEstadoVentana_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEstadoVentana.SelectedIndexChanged
        If cbxEstadoVentana.SelectedIndex = 0 Then
            CbxSizes.Enabled = True
            Label23.Enabled = True
            Me.WindowState = FormWindowState.Normal
        ElseIf cbxEstadoVentana.SelectedIndex = 1 Then
            Me.WindowState = FormWindowState.Maximized
            CbxSizes.Enabled = False
            Label23.Enabled = False
        End If

        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "AreaImpresion SET SizeMode='" + cbxEstadoVentana.SelectedIndex.ToString + "' WHERE IDEquipo= '" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()
    End Sub

    Private Sub NavigationPane2_StateChanged(sender As Object, e As DevExpress.XtraBars.Navigation.StateChangedEventArgs) Handles NavigationPane2.StateChanged
        If Me.WindowState = FormWindowState.Normal Then
            If NavigationPane2.State = DevExpress.XtraBars.Navigation.NavigationPaneState.Expanded Then
                NavigationPane2.Size = New Size(TabPage2.Width * 0.85, NavigationPane2.Height)
            End If
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub FinanciamientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinanciamientosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_financiamiento.Visible = True Then
            If frm_financiamiento.WindowState = FormWindowState.Minimized Then
                frm_financiamiento.WindowState = FormWindowState.Normal
            Else
                frm_financiamiento.Activate()
            End If
        Else
            frm_financiamiento.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PagosAFinanciamientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagosAFinanciamientosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_cuotas_financiamientos.Visible = True Then
            If frm_cuotas_financiamientos.WindowState = FormWindowState.Minimized Then
                frm_cuotas_financiamientos.WindowState = FormWindowState.Normal
            Else
                frm_cuotas_financiamientos.Activate()
            End If
        Else
            frm_cuotas_financiamientos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub FinanciamientosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FinanciamientosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_financiamientos.Visible = True Then
            If frm_reporte_financiamientos.WindowState = FormWindowState.Minimized Then
                frm_reporte_financiamientos.WindowState = FormWindowState.Normal
            Else
                frm_reporte_financiamientos.Activate()
            End If
        Else
            frm_reporte_financiamientos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CuotasFinanciamientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuotasFinanciamientosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_reporte_cuotas_financiamientos.Visible = True Then
            If frm_reporte_cuotas_financiamientos.WindowState = FormWindowState.Minimized Then
                frm_reporte_cuotas_financiamientos.WindowState = FormWindowState.Normal
            Else
                frm_reporte_cuotas_financiamientos.Activate()
            End If
        Else
            frm_reporte_cuotas_financiamientos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub FinanciamientosToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles FinanciamientosToolStripMenuItem2.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_financiamientos.Visible = True Then
            If frm_consulta_financiamientos.WindowState = FormWindowState.Minimized Then
                frm_consulta_financiamientos.WindowState = FormWindowState.Normal
            Else
                frm_consulta_financiamientos.Activate()
            End If
        Else
            frm_consulta_financiamientos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CuotasFinanciamientosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CuotasFinanciamientosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_consulta_pagos_financiamientos.Visible = True Then
            If frm_consulta_pagos_financiamientos.WindowState = FormWindowState.Minimized Then
                frm_consulta_pagos_financiamientos.WindowState = FormWindowState.Normal
            Else
                frm_consulta_pagos_financiamientos.Activate()
            End If
        Else
            frm_consulta_pagos_financiamientos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub chkModoBajoRendimiento_CheckedChanged(sender As Object, e As EventArgs) Handles chkModoBajoRendimiento.CheckedChanged
        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "AreaImpresion SET LiteMode='" + Convert.ToInt16(chkModoBajoRendimiento.CheckState).ToString + "' Where IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()
    End Sub

    Private Sub ListadoDeProductosToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ListadoDeProductosToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_listado_articulos.Visible = True Then
            If frm_listado_articulos.WindowState = FormWindowState.Minimized Then
                frm_listado_articulos.WindowState = FormWindowState.Normal
            Else
                frm_listado_articulos.Activate()
            End If
        Else
            frm_listado_articulos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CorteDeCajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorteDeCajaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_corte_caja.Visible = True Then
            If frm_corte_caja.WindowState = FormWindowState.Minimized Then
                frm_corte_caja.WindowState = FormWindowState.Normal
            Else
                frm_corte_caja.Activate()
            End If
        Else
            frm_corte_caja.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub PicEmpleado_MouseEnter(sender As Object, e As EventArgs) Handles PicEmpleado.MouseEnter
        Try
            If TypeConnection.Text = 1 Then
                MakeRoundedImage(OverlayImages(ResizeImageWXH(Image.FromFile(GrayPicturePath.ToString), 102, 90), ResizeImageWXH(My.Resources.Plusx48, 48, 48), New Point(((PicEmpleado.Width - 48) / 2), (45 / 2))), PicEmpleado)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub PicEmpleado_MouseLeave(sender As Object, e As EventArgs) Handles PicEmpleado.MouseLeave
        Try

            If TypeConnection.Text = 1 Then
                MakeRoundedImage(Image.FromFile(NormalPicturePath), PicEmpleado)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ChangePictureProfile()
        Try
            If TypeConnection.Text = 1 Then
                Dim wFile As System.IO.FileStream
                Dim OfdRutaCedula As New OpenFileDialog

                OfdRutaCedula.RestoreDirectory = True
                OfdRutaCedula.Title = ("Seleccionar de imagen para el chat")
                OfdRutaCedula.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
                OfdRutaCedula.FileName = ""

                If OfdRutaCedula.ShowDialog = Windows.Forms.DialogResult.OK Then

                    If System.IO.File.Exists(OfdRutaCedula.FileName) Then
                        wFile = New FileStream(OfdRutaCedula.FileName, FileMode.Open, FileAccess.Read)
                        MakeRoundedImage(System.Drawing.Image.FromStream(wFile), PicEmpleado)
                        NormalPicture = System.Drawing.Image.FromStream(wFile)
                        GrayPicture = ConvertToGrayScale(System.Drawing.Image.FromStream(wFile))
                        wFile.Close()

                        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Empleados\Chat\[" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString & "] " & lblNombre.Text & ".png"
                        Dim RutaDestinoGray As String = "\\" & PathServidor.Text & "\Libregco\Files\Empleados\Chat\[" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString & "] " & "Gray-" & lblNombre.Text & ".png"

                        If RutaDestino <> OfdRutaCedula.FileName Then
                            My.Computer.FileSystem.MoveFile(OfdRutaCedula.FileName, RutaDestino, FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
                            OfdRutaCedula.FileName = RutaDestino

                            GrayPicture.Save(RutaDestinoGray, System.Drawing.Imaging.ImageFormat.Jpeg)

                            sqlQ = "UPDATE Empleados SET ImagenChat='" + Replace(RutaDestino, "\", "\\") + "',GrayPictureFile='" + Replace(RutaDestinoGray, "\", "\\") + "' WHERE IDEmpleado= '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"

                            NormalPicturePath = RutaDestino
                            GrayPicturePath = RutaDestinoGray

                            ConLibregco.Open()
                            cmd = New MySqlCommand(sqlQ, ConLibregco)
                            cmd.ExecuteNonQuery()
                            ConLibregco.Close()

                            ConLibregcoMain.Open()
                            cmd = New MySqlCommand(sqlQ, ConLibregcoMain)
                            cmd.ExecuteNonQuery()
                            ConLibregcoMain.Close()
                        End If
                    End If

                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PicEmpleado_Click(sender As Object, e As EventArgs) Handles PicEmpleado.Click
        ChangePictureProfile()
    End Sub

    Private Sub CortesDeCajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CortesDeCajaToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()

        If frm_reporte_cortes_caja.Visible = True Then
            If frm_reporte_cortes_caja.WindowState = FormWindowState.Minimized Then
                frm_reporte_cortes_caja.WindowState = FormWindowState.Normal
            Else
                frm_reporte_cortes_caja.Activate()
            End If
        Else
            frm_reporte_cortes_caja.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub CortesDeCajaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CortesDeCajaToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()

        If frm_consulta_cortedecaja.Visible = True Then
            If frm_consulta_cortedecaja.WindowState = FormWindowState.Minimized Then
                frm_consulta_cortedecaja.WindowState = FormWindowState.Normal
            Else
                frm_consulta_cortedecaja.Activate()
            End If
        Else
            frm_consulta_cortedecaja.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EnvíoDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvíoDeToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_envio_606.Visible = True Then
            If frm_envio_606.WindowState = FormWindowState.Minimized Then
                frm_envio_606.WindowState = FormWindowState.Normal
            Else
                frm_envio_606.Activate()
            End If
        Else
            frm_envio_606.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EníoDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EníoDeVentasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_envio_607.Visible = True Then
            If frm_envio_607.WindowState = FormWindowState.Minimized Then
                frm_envio_607.WindowState = FormWindowState.Normal
            Else
                frm_envio_607.Activate()
            End If
        Else
            frm_envio_607.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub EnvíoDeComprobantesAnulados608ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnvíoDeComprobantesAnulados608ToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_envio_608.Visible = True Then
            If frm_envio_608.WindowState = FormWindowState.Minimized Then
                frm_envio_608.WindowState = FormWindowState.Normal
            Else
                frm_envio_608.Activate()
            End If
        Else
            frm_envio_608.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub Label45_Click(sender As Object, e As EventArgs) Handles Label45.Click
        frm_cotizacion_nw.ShowDialog(Me)
    End Sub

    Private Sub txtBuscarModulos_Leave(sender As Object, e As EventArgs) Handles txtBuscarModulos.Leave
        MenuNuevo.Focus()
    End Sub

    Private Sub txtBuscarModulos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscarModulos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            MenuNuevo.Focus()

        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            txtBuscarModulos.Clear()
        End If
    End Sub

    Private Sub MenuNuevo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MenuNuevo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            MenuNuevo.Items(0).PerformClick()
        End If
    End Sub

    Private Sub PropiedadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropiedadesToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_propiedades.Visible = True Then
            If frm_propiedades.WindowState = FormWindowState.Minimized Then
                frm_propiedades.WindowState = FormWindowState.Normal
            Else
                frm_propiedades.Activate()
            End If
        Else
            frm_propiedades.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub chkPreviewMode_CheckedChanged(sender As Object, e As EventArgs) Handles chkPreviewMode.CheckedChanged
        ConMixta.Open()
        sqlQ = "UPDATE" & SysName.Text & "AreaImpresion SET PreviewMode='" + Convert.ToInt16(chkPreviewMode.CheckState).ToString + "' Where IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConMixta)
        cmd.ExecuteNonQuery()
        ConMixta.Close()
    End Sub

    Private Sub LoadSchedule()
        If TypeConnection.Text = 1 Then
            If DTEmpleado.Rows(0).Item("IDEmpleado").ToString <> "" Then
                If DTEmpleado.Rows(0).Item("AgendaFilePath").ToString = "" Then
                    Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Empleados\Agenda")
                    If Exists = False Then
                        System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Empleados\Agenda")
                    End If

                    Dim ExistFile As Boolean = System.IO.File.Exists("\\" & PathServidor.Text & "\Libregco\Files\Agenda\Default Schedule.ics")
                    Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Agenda\Schedule_" & DTEmpleado.Rows(0).Item("IDEmpleado").ToString & ".ics"

                    If ExistFile = True Then
                        My.Computer.FileSystem.CopyFile("\\" & PathServidor.Text & "\Libregco\Files\Agenda\Default Schedule.ics", RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                        DTEmpleado.Rows(0).Item("AgendaFilePath") = RutaDestino

                        ConMixta.Open()
                        sqlQ = "UPDATE Libregco.Empleados SET AgendaFilePath='" + Replace(RutaDestino, "\", "\\") + "' Where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
                        cmd = New MySqlCommand(sqlQ, ConMixta)
                        cmd.ExecuteNonQuery()

                        sqlQ = "UPDATE Libregco_Main.Empleados SET AgendaFilePath='" + Replace(RutaDestino, "\", "\\") + "' Where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
                        cmd = New MySqlCommand(sqlQ, ConMixta)
                        cmd.ExecuteNonQuery()

                        ConMixta.Close()
                    End If

                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(DTEmpleado.Rows(0).Item("AgendaFilePath").ToString)
                    If ExistFile = True Then
                        Using stream As FileStream = File.OpenRead(DTEmpleado.Rows(0).Item("AgendaFilePath").ToString)
                            ImportAppointments(stream)
                        End Using
                        SchedulerControl1.GoToToday()

                        ''Hacer backup si la agenda tiene ventos
                        'Dim appointments As List(Of Appointment) = SchedulerControl1.Storage.GetAppointments(1,)
                        'If appointments.Count > 0 Then

                        'End If
                    End If
                End If
            End If

        End If

    End Sub

    Sub ImportAppointments(ByVal stream As Stream)
        Try
            If stream Is Nothing Then
                Return
            End If
            SchedulerStorage1.Appointments.Clear()
            Dim importer As New iCalendarImporter(SchedulerStorage1)
            importer.Import(stream)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ExportAppointments(ByVal stream As Stream)
        If stream Is Nothing Then
            Return
        End If
        Dim exporter As New iCalendarExporter(SchedulerStorage1)
        exporter.ProductIdentifier = "-//Developer Express Inc.//DXScheduler iCalendarExchange Example//EN"
        exporter.Export(stream)

    End Sub

    Private Sub NavigationPane2_Validated(sender As Object, e As EventArgs) Handles NavigationPane2.Validated
        DgvAlertas.ClearSelection()
        DgvConversations.ClearSelection()
        DgvCumpleanos.ClearSelection()
        DgvSolicitudes.ClearSelection()
        DgvRecordatorios.ClearSelection()
    End Sub

    Private Sub btnIrAgenda_Click(sender As Object, e As EventArgs) Handles btnIrAgenda.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_agenda.Visible = True Then
            frm_agenda.Close()
        End If

        frm_agenda.Show(Me)
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub NavigationPane2_SelectedPageIndexChanged(sender As Object, e As EventArgs) Handles NavigationPane2.SelectedPageIndexChanged
        If NavigationPane2.SelectedPageIndex = 0 Then
            DgvConversations.ClearSelection()
            DgvCumpleanos.ClearSelection()
        ElseIf NavigationPane2.SelectedPageIndex = 2 Then
            DgvSolicitudes.ClearSelection()
            DgvRecordatorios.ClearSelection()
        ElseIf NavigationPane2.SelectedPageIndex = 3 Then
            DgvAlertas.ClearSelection()

        ElseIf NavigationPane2.SelectedPageIndex = 5 Then
            If NavigationPage4.Controls.Count = 0 Then
                SplashScreenManager1.ShowWaitForm()

                Dim f As New frm_estadisticas()
                f.TopLevel = False
                f.WindowState = FormWindowState.Normal
                f.FormBorderStyle = FormBorderStyle.None
                f.Visible = True
                f.Dock = DockStyle.Fill
                NavigationPage4.Controls.Add(f)

                f.cbxUsuarios.EditValue = CInt(DTEmpleado.Rows(0).Item("IDEmpleado"))
                f.lblPuesto.Text = lblCargo.Text
                f.PicFoto.Image = NormalPicture
                f.PicFoto.Tag = CInt(DTEmpleado.Rows(0).Item("IDEmpleado"))

                SplashScreenManager1.CloseWaitForm()

            End If
        End If
    End Sub

    Private Sub ArtículosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ArtículosToolStripMenuItem1.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_actualizar_propiedades_articulos.Visible = True Then
            If frm_actualizar_propiedades_articulos.WindowState = FormWindowState.Minimized Then
                frm_actualizar_propiedades_articulos.WindowState = FormWindowState.Normal
            Else
                frm_actualizar_propiedades_articulos.Activate()
            End If
        Else
            frm_actualizar_propiedades_articulos.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DgvEquipos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEquipos.CellEndEdit
        DgvEquipos.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvEquipos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvEquipos.CurrentCellDirtyStateChanged
        If DgvEquipos.IsCurrentCellDirty Then
            DgvEquipos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvEquipos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEquipos.CellValueChanged
        Try
            If e.RowIndex >= 0 Then
                Con.Open()
                sqlQ = "UPDATE AreaImpresion SET Nulo='" + Convert.ToInt16(DgvEquipos.CurrentRow.Cells(6).Value).ToString + "',AutomaticStartUp='" + Convert.ToInt16(DgvEquipos.CurrentRow.Cells(8).Value).ToString + "',MuteApp='" + Convert.ToInt16(DgvEquipos.CurrentRow.Cells(9).Value).ToString + "',Suspender='" + Convert.ToInt16(DgvEquipos.CurrentRow.Cells(10).Value).ToString + "' Where IDEquipo='" + DgvEquipos.CurrentRow.Cells(1).Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
                Con.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        CargarBouchers()
    End Sub

    Private Sub PrefacturaciónV2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrefacturaciónV2ToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()


        If frm_mdi_prefacturacion.Visible = True Then
            If frm_mdi_prefacturacion.WindowState = FormWindowState.Minimized Then
                frm_mdi_prefacturacion.WindowState = FormWindowState.Normal
            Else
                frm_mdi_prefacturacion.Activate()
            End If
        Else
            frm_mdi_prefacturacion.Show(Me)
        End If


        SplashScreenManager1.CloseWaitForm()

    End Sub

    Private Sub CatálogoDeCuentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatálogoDeCuentasToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        If frm_catalogo_cuentas.Visible = True Then
            If frm_catalogo_cuentas.WindowState = FormWindowState.Minimized Then
                frm_catalogo_cuentas.WindowState = FormWindowState.Normal
            Else
                frm_catalogo_cuentas.Activate()
            End If
        Else
            frm_catalogo_cuentas.Show(Me)
        End If
        SplashScreenManager1.CloseWaitForm()
    End Sub


    Private Sub FlowLayoutPanel1_ControlAdded(sender As Object, e As ControlEventArgs) Handles FlowLayoutPanel1.ControlAdded
        For Each pn As Panel In FlowLayoutPanel1.Controls
            If FlowLayoutPanel1.VerticalScroll.Visible Then
                pn.Width = 225
            Else
                pn.Width = 245
            End If
        Next
    End Sub

    Private Sub FlowLayoutPanel1_ControlRemoved(sender As Object, e As ControlEventArgs) Handles FlowLayoutPanel1.ControlRemoved
        For Each pn As Panel In FlowLayoutPanel1.Controls
            If FlowLayoutPanel1.VerticalScroll.Visible Then
                pn.Width = 225
            Else
                pn.Width = 245
            End If
        Next
    End Sub

    Private Sub DgvNovedades_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvNovedades.CellMouseClick
        If e.RowIndex >= 0 Then
            If DgvNovedades.CurrentRow.Cells(0).Value = 2 Then
                NotasDeLaVersiónToolStripMenuItem1.PerformClick()
                DgvNovedades.ClearSelection()
            End If
        End If
    End Sub

    Private Sub DgvEquipos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEquipos.CellDoubleClick
        If Button4.Text <> DgvEquipos.CurrentRow.Cells(11).Value.ToString Then
            If e.ColumnIndex = 2 Then
                If e.RowIndex >= 0 Then
                    If DgvEquipos.CurrentRow.Cells(12).Value = "" Then
                        System.Diagnostics.Process.Start("mstsc", "/v:" + DgvEquipos.CurrentRow.Cells(11).Value.ToString)
                    Else
                        System.Diagnostics.Process.Start("mstsc", "/v:" + DgvEquipos.CurrentRow.Cells(11).Value.ToString + " /u:" + DgvEquipos.CurrentRow.Cells(12).Value.ToString + " /p:" + DgvEquipos.CurrentRow.Cells(13).Value.ToString)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button4_MouseEnter(sender As Object, e As EventArgs) Handles Button4.MouseEnter
        GradientBackColorButton(Button4, SystemColors.Highlight, Color.Black, LinearGradientMode.Horizontal)
    End Sub

    Public Sub GradientBackColorButton(ByVal aControl As Control, ByVal Color1 As Color, ByVal Color2 As Color,
   Optional ByVal mode As System.Drawing.Drawing2D.LinearGradientMode = Drawing2D.LinearGradientMode.Horizontal)

        Dim bmp As New Bitmap(aControl.Width, aControl.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        Dim Rect1 As New RectangleF(0, 0, aControl.Width, aControl.Height)

        Dim lineGBrush As New System.Drawing.Drawing2D.LinearGradientBrush(Rect1, Color1, Color2, mode)
        g.FillRectangle(lineGBrush, Rect1)

        aControl.BackgroundImage = bmp
        g.Dispose()
    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Button4.BackgroundImage = Nothing
    End Sub

    Private Sub Button3_MouseEnter(sender As Object, e As EventArgs) Handles Button3.MouseEnter
        If Button3.BackColor = Color.FromArgb(255, 25, 40, 40) Then
            GradientBackColorButton(Button3, Color.Black, Color.Green, LinearGradientMode.Horizontal)
        ElseIf Button3.BackColor = Color.Purple Then
            GradientBackColorButton(Button3, Color.Black, Color.Purple, LinearGradientMode.Horizontal)
        End If
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Button3.BackgroundImage = Nothing
    End Sub

    Private Sub AdjustarMenuPrincipal()
        Dim AutoWidth As Integer = 0
        For Each Button As ToolStripMenuItem In MenuStrip2.Items
            If Button.Visible = True Then
                AutoWidth = AutoWidth + Button.Width
            End If
        Next
        MenuStrip2.Size = New Size(AutoWidth + 10, MenuStrip2.Size.Height)
        Panel27.Size = New Size(AutoWidth + 10, MenuStrip2.Size.Height)
    End Sub
End Class