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
Imports DevExpress.Utils

Public Class frm_niveles_desarrollo_facturacion
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Friend TablaCotizacion, TablaPrefactura, TablaFacturaDatos As DataTable
    Dim RepositorySecondID As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}
    Friend IDFactura As String
    Private Sub frm_niveles_desarrollo_facturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        SetRegistrosTable()
        RefrescarTabla()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim ds As New DataSet

            TablaCotizacion.Rows.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT 'Cotizacion' as Documento,Cotizacion.SecondID,timestamp(Cotizacion.Fecha,Cotizacion.Hora) as Fecha,Cotizacion.IDCliente,Cotizacion.NombreCotizacion as NombreFactura,Cotizacion.IDVendedor,Vendedor.Nombre as Vendedor,Cotizacion.TotalNeto FROM" & SysName.Text & "Cotizacion INNER JOIN" & SysName.Text & "Prefactura on Cotizacion.IDCotizacion=Prefactura.IDCotizacion INNER JOIN" & SysName.Text & "Empleados as Vendedor on Cotizacion.IDVendedor=Vendedor.IDEmpleado where Prefactura.IDFacturaDatos='" + IDFactura + "' order by timestamp(Fecha,Hora) asc", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "Cotizacion")

            Dim TB As DataTable = ds.Tables("Cotizacion")

            For Each itm As DataRow In TB.Rows
                TablaCotizacion.Rows.Add(itm.Item("Documento"), itm.Item("SecondID"), CDate(itm.Item("Fecha")).ToString("dd/MM/yyyy hh:mm:ss tt"), itm.Item("IDCliente"), itm.Item("NombreFactura"), itm.Item("IDVendedor"), itm.Item("Vendedor"), itm.Item("TotalNeto"))
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''
            TablaPrefactura.Rows.Clear()
            ds.Clear()

            cmd = New MySqlCommand("SELECT 'Prefactura' as Documento,SecondID,timestamp(Fecha,Hora) as Fecha,IDCliente,NombreFactura,IDVendedor,Vendedor.Nombre as Vendedor,TotalNeto FROM" & SysName.Text & "prefactura INNER JOIN" & SysName.Text & "Empleados as Vendedor on Prefactura.IDVendedor=Vendedor.IDEmpleado where IDFacturaDatos='" + IDFactura + "' ORDER BY timestamp(Fecha,Hora) ASC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "Prefacturas")

            Dim PF As DataTable = ds.Tables("Prefacturas")

            For Each itm As DataRow In PF.Rows
                TablaPrefactura.Rows.Add(itm.Item("Documento"), itm.Item("SecondID"), CDate(itm.Item("Fecha")).ToString("dd/MM/yyyy hh:mm:ss tt"), itm.Item("IDCliente"), itm.Item("NombreFactura"), itm.Item("IDVendedor"), itm.Item("Vendedor"), itm.Item("TotalNeto"))
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''

            TablaFacturaDatos.Rows.Clear()
            ds.Clear()

            cmd = New MySqlCommand("SELECT 'Facturación' as Documento,FacturaDatos.SecondID,timestamp(Fecha,Hora) as Fecha,IDCliente,FacturaDatos.NombreFactura,IDVendedor,Vendedor.Nombre as Vendedor,FacturaDatos.TotalNeto from" & SysName.Text & "FacturaDatos INNER JOIN" & SysName.Text & "Empleados as Vendedor on FacturaDatos.IDVendedor=Vendedor.IDEmpleado Where IDFacturaDatos='" + IDFactura + "' ORDER BY timestamp(Fecha,Hora) ASC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(ds, "Facturas")

            Dim FD As DataTable = ds.Tables("Facturas")

            For Each itm As DataRow In FD.Rows
                TablaFacturaDatos.Rows.Add(itm.Item("Documento"), itm.Item("SecondID"), CDate(itm.Item("Fecha")).ToString("dd/MM/yyyy hh:mm:ss tt"), itm.Item("IDCliente"), itm.Item("NombreFactura"), itm.Item("IDVendedor"), itm.Item("Vendedor"), itm.Item("TotalNeto"))
            Next

            ConMixta.Close()

            GridCotizacion.BestFitColumns()
            GridPrefacturas.BestFitColumns()
            GridFacturacion.BestFitColumns()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub SetRegistrosTable()
        TablaCotizacion = New DataTable("TablaCotizacion")

        TablaCotizacion.Columns.Add("Documento", System.Type.GetType("System.String"))
        TablaCotizacion.Columns.Add("Numero", System.Type.GetType("System.String"))
        TablaCotizacion.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
        TablaCotizacion.Columns.Add("IDCliente", System.Type.GetType("System.String"))
        TablaCotizacion.Columns.Add("Nombre", System.Type.GetType("System.String"))
        TablaCotizacion.Columns.Add("IDVendedor", System.Type.GetType("System.String"))
        TablaCotizacion.Columns.Add("Vendedor", System.Type.GetType("System.String"))
        TablaCotizacion.Columns.Add("TotalNeto", System.Type.GetType("System.Double"))

        GridControl1.DataSource = TablaCotizacion
        GridCotizacion.Columns("Numero").ColumnEdit = RepositorySecondID

        'Propiedades
        GridCotizacion.Columns("Documento").Visible = False
        GridCotizacion.Columns("Numero").Caption = "Documento"
        GridCotizacion.Columns("Fecha").Visible = True
        GridCotizacion.Columns("Fecha").Caption = "Fecha de registro"
        GridCotizacion.Columns("Fecha").DisplayFormat.FormatType = FormatType.DateTime
        GridCotizacion.Columns("Fecha").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"
        GridCotizacion.Columns("IDCliente").Caption = "ID"
        GridCotizacion.Columns("Nombre").Caption = "Nombre"
        GridCotizacion.Columns("IDVendedor").Caption = "ID del vendedor"
        GridCotizacion.Columns("IDVendedor").Visible = False
        GridCotizacion.Columns("Vendedor").Visible = False
        GridCotizacion.Columns("TotalNeto").DisplayFormat.FormatType = FormatType.Numeric
        GridCotizacion.Columns("TotalNeto").DisplayFormat.FormatString = "C2"

        For i = 0 To GridCotizacion.Columns.Count - 1
            GridCotizacion.Columns(i).OptionsColumn.ReadOnly = True
            GridCotizacion.Columns(i).OptionsColumn.AllowEdit = False
        Next

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        TablaPrefactura = New DataTable("TablaPrefactura")

        TablaPrefactura.Columns.Add("Documento", System.Type.GetType("System.String"))
        TablaPrefactura.Columns.Add("Numero", System.Type.GetType("System.String"))
        TablaPrefactura.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
        TablaPrefactura.Columns.Add("IDCliente", System.Type.GetType("System.String"))
        TablaPrefactura.Columns.Add("Nombre", System.Type.GetType("System.String"))
        TablaPrefactura.Columns.Add("IDVendedor", System.Type.GetType("System.String"))
        TablaPrefactura.Columns.Add("Vendedor", System.Type.GetType("System.String"))
        TablaPrefactura.Columns.Add("TotalNeto", System.Type.GetType("System.Double"))

        GridControl2.DataSource = TablaPrefactura
        GridPrefacturas.Columns("Numero").ColumnEdit = RepositorySecondID

        'Propiedades
        GridPrefacturas.Columns("Documento").Visible = False
        GridPrefacturas.Columns("Numero").Caption = "Documento"
        GridPrefacturas.Columns("Fecha").Visible = True
        GridPrefacturas.Columns("Fecha").Caption = "Fecha de registro"
        GridPrefacturas.Columns("Fecha").DisplayFormat.FormatType = FormatType.DateTime
        GridPrefacturas.Columns("Fecha").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"
        GridPrefacturas.Columns("IDCliente").Caption = "ID"
        GridPrefacturas.Columns("Nombre").Caption = "Nombre"
        GridPrefacturas.Columns("IDVendedor").Caption = "ID del vendedor"
        GridPrefacturas.Columns("IDVendedor").Visible = False
        GridPrefacturas.Columns("Vendedor").Visible = False
        GridPrefacturas.Columns("TotalNeto").DisplayFormat.FormatType = FormatType.Numeric
        GridPrefacturas.Columns("TotalNeto").DisplayFormat.FormatString = "C2"

        For i = 0 To GridPrefacturas.Columns.Count - 1
            GridPrefacturas.Columns(i).OptionsColumn.ReadOnly = True
            GridPrefacturas.Columns(i).OptionsColumn.AllowEdit = False
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        TablaFacturaDatos = New DataTable("TablaFactura")

        TablaFacturaDatos.Columns.Add("Documento", System.Type.GetType("System.String"))
        TablaFacturaDatos.Columns.Add("Numero", System.Type.GetType("System.String"))
        TablaFacturaDatos.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
        TablaFacturaDatos.Columns.Add("IDCliente", System.Type.GetType("System.String"))
        TablaFacturaDatos.Columns.Add("Nombre", System.Type.GetType("System.String"))
        TablaFacturaDatos.Columns.Add("IDVendedor", System.Type.GetType("System.String"))
        TablaFacturaDatos.Columns.Add("Vendedor", System.Type.GetType("System.String"))
        TablaFacturaDatos.Columns.Add("TotalNeto", System.Type.GetType("System.Double"))

        GridControl3.DataSource = TablaFacturaDatos
        GridFacturacion.Columns("Numero").ColumnEdit = RepositorySecondID

        'Propiedades
        GridFacturacion.Columns("Documento").Visible = False
        GridFacturacion.Columns("Numero").Caption = "Documento"
        GridFacturacion.Columns("Fecha").Visible = True
        GridFacturacion.Columns("Fecha").Caption = "Fecha de registro"
        GridFacturacion.Columns("Fecha").DisplayFormat.FormatType = FormatType.DateTime
        GridFacturacion.Columns("Fecha").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"
        GridFacturacion.Columns("IDCliente").Caption = "ID"
        GridFacturacion.Columns("Nombre").Caption = "Nombre"
        GridFacturacion.Columns("IDVendedor").Caption = "ID del vendedor"
        GridFacturacion.Columns("IDVendedor").Visible = False
        GridFacturacion.Columns("Vendedor").Visible = False
        GridFacturacion.Columns("TotalNeto").DisplayFormat.FormatType = FormatType.Numeric
        GridFacturacion.Columns("TotalNeto").DisplayFormat.FormatString = "C2"

        For i = 0 To GridFacturacion.Columns.Count - 1
            GridFacturacion.Columns(i).OptionsColumn.ReadOnly = True
            GridFacturacion.Columns(i).OptionsColumn.AllowEdit = False
        Next



    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub


End Class