Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frm_listado_cobros
    Friend CnString As String = "database=Libregco;server=localhost;port=3309;user id=root;password=iLM14PC1191;sslmode=None"
    Friend CnString1 As String = "database=Libregco_Main;server=localhost;port=3309;user id=root;password=iLM14PC1191;sslmode=None"
    Friend CnUtilitarios As String = "database=Libregco_Utilitarios;server=localhost;port=3309;user id=root;password=iLM14PC1191;sslmode=None"
    Friend CnGeneral As String = "server=localhost;port=3309;user id=root;password=iLM14PC1191;sslmode=None"
    Friend CnAdminLibregco As String = "server=localhost;port=3309;user id=root;password=iLM14PC1191;sslmode=None"
    Friend Con As New MySqlConnection(CnString) 'Conexión a base de datos seleccionada
    Friend ConLibregco As New MySqlConnection(CnString) 'Conexion a Libregco
    Friend ConLibregcoMain As New MySqlConnection(CnString1) 'Conexion a LibregcoMain                               
    Friend ConMixta As New MySqlConnection(CnGeneral) 'Conexion mixta

    Friend Facturas As DataTable
    Friend Pagares As DataTable
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter




    Public Sub ExpandAllRows(ByVal View As GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, True)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub

    Private Sub frm_listado_cobros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillCalificacion()

        SysName.Text = " Libregco."

        Dim dataset As New DataSet

        'Dim Clientes As DataTable = GetData("SELECT Clientes.IDCliente,Clientes.Nombre,Clientes.BalanceGeneral,Clientes.Direccion,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.IDProvincia,Provincias.Provincia,Clientes.IDMunicipio,Municipios.Municipio,Clientes.IDEmpleadoSub,SubCobrador.Nombre as SubCobradorNombre,Clientes.IDCalificacion,Clientes.CerrarCredito FROM Libregco.Clientes INNER JOIN Libregco.FacturaDatos on Clientes.IDCliente=FacturaDatos.IDCliente INNER JOIN Libregco.Empleados as SubCobrador on Clientes.IDEmpleadoSub=SubCobrador.IDEmpleado INNER JOIN Libregco.Estadofactura on FacturaDatos.IDEstadoFactura=EstadoFactura.IDEstadoFactura INNER JOIN Libregco.Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio Where FacturaDatos.Balance>0 and Clientes.BalanceGeneral>0 and FacturaDatos.Nulo=0 and Clientes.IDEmpleado=7 GROUP BY Clientes.IDCliente", ConLibregco)
        'Facturas = GetData("SELECT FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID as SecondIDFactura,FacturaDatos.Fecha,FacturaDatos.FechaVencimiento as VencFactura,FacturaDatos.IDCliente,FacturaDatos.Balance,FacturaDatos.Cargos,FacturaDatos.IDEstadoFactura,EstadoFactura.EstadoFactura,ifnull((Select Abonos.Fecha from Libregco.DetalleAbonos INNER JOIN Libregco.Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono where DetalleAbonos.IDFactura=Pagares.IDFactura and Abonos.Nulo=0 ORDER BY Abonos.IDAbono DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Abonos.Debito from Libregco.DetalleAbonos INNER JOIN Libregco.Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono where DetalleAbonos.IDFactura=Pagares.IDFactura and Abonos.Nulo=0 ORDER BY Abonos.IDAbono DESC LIMIT 1),0) AS UltimoMonto,FacturaDatos.DireccionFactura,FacturaDatos.TelefonosFactura FROM Libregco.pagares INNER JOIN Libregco.FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Empleados as SubCobrador on Clientes.IDEmpleadoSub=SubCobrador.IDEmpleado INNER JOIN Libregco.Estadofactura on FacturaDatos.IDEstadoFactura=EstadoFactura.IDEstadoFactura INNER JOIN Libregco.Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio Where FacturaDatos.Balance>0 and Clientes.BalanceGeneral>0 and FacturaDatos.Nulo=0 and Clientes.IDEmpleado=7 GROUP BY FacturaDatos.IDFacturaDatos", Con)
        Facturas = GetDataTable("SELECT FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID as SecondIDFactura,FacturaDatos.Fecha,FacturaDatos.FechaVencimiento as VencFactura,FacturaDatos.IDCliente,Clientes.Nombre,FacturaDatos.NombreFactura,Clientes.BalanceGeneral,FacturaDatos.Balance,FacturaDatos.Cargos,FacturaDatos.IDEstadoFactura,EstadoFactura.EstadoFactura,ifnull((Select Abonos.Fecha from Libregco.DetalleAbonos INNER JOIN Libregco.Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono where DetalleAbonos.IDFactura=Pagares.IDFactura and Abonos.Nulo=0 ORDER BY Abonos.IDAbono DESC LIMIT 1),'') AS UltimoPago,ifnull((Select Abonos.Debito from Libregco.DetalleAbonos INNER JOIN Libregco.Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono where DetalleAbonos.IDFactura=Pagares.IDFactura and Abonos.Nulo=0 ORDER BY Abonos.IDAbono DESC LIMIT 1),0) AS UltimoMonto,FacturaDatos.DireccionFactura,FacturaDatos.TelefonosFactura,Clientes.IDProvincia,Provincias.Provincia,Clientes.IDMunicipio,Municipios.Municipio,Clientes.IDEmpleadoSub,SubCobrador.Nombre as SubCobradorNombre,Clientes.IDCalificacion,Clientes.CerrarCredito FROM Libregco.pagares INNER JOIN Libregco.FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Empleados as SubCobrador on Clientes.IDEmpleadoSub=SubCobrador.IDEmpleado INNER JOIN Libregco.Estadofactura on FacturaDatos.IDEstadoFactura=EstadoFactura.IDEstadoFactura INNER JOIN Libregco.Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio Where FacturaDatos.Balance>0 and Clientes.BalanceGeneral>0 and FacturaDatos.Nulo=0 and Clientes.IDEmpleado=7 GROUP BY FacturaDatos.IDFacturaDatos", Con)
        Pagares = GetDataTable("SELECT Pagares.IDPagare,Pagares.IDFactura as IDFacturaDatos,FacturaDatos.SecondID as SecondIDFactura,FacturaDatos.Fecha,FacturaDatos.FechaVencimiento as VencFactura,FacturaDatos.IDCliente,Pagares.NoPagare,Pagares.Cantidad,Pagares.FechaVencimiento,Pagares.Monto,Pagares.Balance as BcePagare,Pagares.BalanceCerrado,Pagares.IDListaPagare,ListaPagares.SecondID,ListaPagares.Fecha as FechaCargado,ListaPagares.Descripcion as DescripcionListado,ListaPagares.IDTipoCargado,TipoCargadoPagare.Descripcion as TipoCargado,Pagares.IDEmpleado as IDCobrador,Cobrador.Nombre as NombreCobrador,Pagares.DiasVencidos,Pagares.IDStatusPagare,StatusPagare.Descripcion as StatusPagare,Pagares.Cargado FROM Libregco.pagares INNER JOIN Libregco.FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Empleados as Cobrador on Pagares.IDEmpleado=Cobrador.IDEmpleado INNER JOIN Libregco.StatusPagare on Pagares.IDStatusPagare=StatusPagare.IDStatusPagare INNER JOIN Libregco.ListaPagares on Pagares.IDListaPagare=ListaPagares.IDControlPagares INNER JOIN Libregco.TipoCargadoPagare on ListaPagares.IDTipoCargado=TipoCargadoPagare.IDTipoCargadoPagare INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where Pagares.BalanceCerrado>0 and FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and Clientes.IDEmpleado=7", Con)

        'Clientes.TableName = "Clientes"
        Facturas.TableName = "Facturas"
        Pagares.TableName = "Pagares"

        'dataset.Tables.Add(Clientes)
        dataset.Tables.Add(Facturas)
        dataset.Tables.Add(Pagares)

        'dataset.Relations.Add("IDCliente", Clientes.Columns("IDCliente"), Facturas.Columns("IDCliente"))
        dataset.Relations.Add("IDFacturaDatos", Facturas.Columns("IDFacturaDatos"), Pagares.Columns("IDFacturaDatos"), False)

        GridControl1.DataSource = dataset
        GridControl1.DataMember = "Facturas"
        'AdvBandedGridView2.DataSource = Pagares

        ExpandAllRows(AdvBandedGridView1)

        AddHandler RepositoryItemCheckEdit1.EditValueChanged, AddressOf OnEditValueChanged
    End Sub

    Private Sub OnEditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        'AdvBandedGridView1.SetFocusedRowCellValue("CerrarCredito", Convert.ToInt16(CType(sender, CheckEdit).CheckState))
        'MessageBox.Show(CType(sender, CheckEdit).CheckState)
        AdvBandedGridView1.PostEditor()

    End Sub

    Private Sub FillCalificacion()
        Dim dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDCalificacion,Calificacion FROM Libregco.Calificacion Order by IDCalificacion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Calificacion")
        ConLibregco.Close()

        Dim TablaCalificacion As DataTable = dstemp.Tables("Calificacion")

        RepositoryItemLookUpEdit1.DataSource = TablaCalificacion
        RepositoryItemLookUpEdit1.ValueMember = "IDCalificacion"
        RepositoryItemLookUpEdit1.DisplayMember = "Calificacion"

        RepositoryItemLookUpEdit1.PopulateColumns()
        RepositoryItemLookUpEdit1.Columns(RepositoryItemLookUpEdit1.ValueMember).Visible = False
        RepositoryItemLookUpEdit1.ShowHeader = False
    End Sub

    Private Sub AdvBandedGridView1_MasterRowExpanded(sender As Object, e As XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles AdvBandedGridView1.MasterRowExpanded
        Dim detailView As XtraGrid.Views.BandedGrid.AdvBandedGridView = CType(sender, XtraGrid.Views.BandedGrid.AdvBandedGridView).GetDetailView(e.RowHandle, e.RelationIndex)

        detailView.OptionsBehavior.ReadOnly = True
        detailView.Columns("IDPagare").Visible = False
        detailView.Columns("IDFacturaDatos").Visible = False
        detailView.Columns("SecondIDFactura").Visible = False
        detailView.Columns("Fecha").Visible = False
        detailView.Columns("VencFactura").Visible = False
        detailView.Columns("IDCliente").Visible = False
        detailView.Columns("IDListaPagare").Visible = False
        detailView.Columns("IDTipoCargado").Visible = False
        detailView.Columns("DescripcionListado").Visible = False
        detailView.Columns("IDCobrador").Visible = False
        detailView.Columns("NombreCobrador").Visible = False
        detailView.Columns("IDStatusPagare").Visible = False
        detailView.Columns("Cargado").Visible = False
        detailView.Columns("IDPagare").Visible = False
        detailView.Columns("FechaVencimiento").Caption = "Vencimiento"
        detailView.Columns("BcePagare").Caption = "Balance"
        detailView.Columns("BalanceCerrado").Caption = "Cerrado"
        detailView.Columns("SecondID").Caption = "Titulación"
        detailView.Columns("FechaCargado").Caption = "Fecha"
        detailView.Columns("TipoCargado").Caption = "T/Tit."
        detailView.Columns("DiasVencidos").Caption = "Días"
        detailView.Columns("StatusPagare").Caption = "Status"


        detailView.Bands.RemoveAt(1)
        detailView.Bands.RemoveAt(1)
        detailView.Bands.RemoveAt(1)

        AdvBandedGridView1.OptionsDetail.ShowDetailTabs = False
        detailView.OptionsView.ShowFilterPanelMode = XtraGrid.Views.Base.ShowFilterPanelMode.Never


        If detailView IsNot Nothing Then
            Dim RepositoryMonto As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
            Dim RepositoryBcePagare As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
            Dim RepositoryBalanceCerrado As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()

            RepositoryMonto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            RepositoryMonto.Mask.EditMask = "c"
            RepositoryMonto.Mask.UseMaskAsDisplayFormat = True
            RepositoryMonto.NullText = CDbl(0).ToString("C")
            RepositoryMonto.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

            RepositoryBcePagare.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            RepositoryBcePagare.Mask.EditMask = "c"
            RepositoryBcePagare.Mask.UseMaskAsDisplayFormat = True
            RepositoryBcePagare.NullText = CDbl(0).ToString("C")
            RepositoryBcePagare.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

            RepositoryBalanceCerrado.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            RepositoryBalanceCerrado.Mask.EditMask = "c"
            RepositoryBalanceCerrado.Mask.UseMaskAsDisplayFormat = True
            RepositoryBalanceCerrado.NullText = CDbl(0).ToString("C")
            RepositoryBalanceCerrado.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

            detailView.Columns("Monto").ColumnEdit = RepositoryMonto
            detailView.Columns("BcePagare").ColumnEdit = RepositoryBcePagare
            detailView.Columns("BalanceCerrado").ColumnEdit = RepositoryBalanceCerrado

            For i = 0 To detailView.Columns.Count - 1
                detailView.Columns(i).OptionsColumn.AllowEdit = False
                detailView.Columns(i).OptionsColumn.AllowGroup = False
            Next

            detailView.BestFitColumns()
        End If
    End Sub


End Class