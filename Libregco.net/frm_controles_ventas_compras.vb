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
Public Class frm_controles_ventas_compras

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim IDReport, NameReport, PathReport, OrdenCampo, OrdenFormula As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_controles_ventas_compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarDatos()
        Actualizar()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='ControlVentaCompra' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Reportes")
            CbxFormato.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Reportes")

            For Each Fila As DataRow In Tabla.Rows
                CbxFormato.Items.Add(Fila.Item("Descripcion"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxFormato.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron reportes que involucren este vínculo del módulo.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CalcGeneral()
        Try
            Con.Open()

            'Ventas Sin Valor Fiscal
            cmd = New MySqlCommand("Select Coalesce(Sum(TotalNeto),0) From FacturaDatos Where IDComprobanteFiscal=1 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtVSinValorFiscal.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Ventas Credito Fiscal
            cmd = New MySqlCommand("Select Coalesce(Sum(TotalNeto),0) From FacturaDatos Where IDComprobanteFiscal=2 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtVCreditoFiscal.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Ventas Consumidor Final
            cmd = New MySqlCommand("Select Coalesce(Sum(TotalNeto),0) From FacturaDatos Where IDComprobanteFiscal=3 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtVConsumidorFinal.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Ventas Gubernamental
            cmd = New MySqlCommand("Select Coalesce(Sum(TotalNeto),0) From FacturaDatos Where IDComprobanteFiscal=10 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtVGubernamental.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Ventas Operaciones Especiales
            cmd = New MySqlCommand("Select Coalesce(Sum(TotalNeto),0) From FacturaDatos Where IDComprobanteFiscal=9 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtVOperacionEspecial.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Ventas Generales
            cmd = New MySqlCommand("Select Coalesce(Sum(TotalNeto),0) From FacturaDatos Where Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtVTotal.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Ventas ITBIS
            cmd = New MySqlCommand("Select Coalesce(Sum(Itbis),0) From FacturaDatos Where Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtVItbis.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Notas de Debito de Ventas con Comprobante
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocredito Where IDTipoNota=1 AND NCF<>'' AND Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            txtVNotDebNCF.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Notas de Debito de Ventas sin Comprobante
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocredito Where IDTipoNota=1 AND NCF='' AND Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            txtVNotDeb.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Notas de Credito de Ventas con Comprobante
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocredito Where IDTipoNota=2 and AND NCF<>''Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            txtVNotaCredNCF.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            cmd = New MySqlCommand("Select Coalesce(Sum(Devolver),0) From devolucionventa Where IDTipoNota=2 AND NCF<>'' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            Dim DevolucionVentaComprobante As Double = Convert.ToDouble(cmd.ExecuteScalar())
            txtVNotaCredNCF.Text = (CDbl(txtVNotaCredNCF.Text) + DevolucionVentaComprobante).ToString("C")

            'Notas de Credito de Ventas sin Comprobante
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocredito Where IDTipoNota=2 AND NCF='' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            txtVNotaCred.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            cmd = New MySqlCommand("Select Coalesce(Sum(Devolver),0) From devolucionventa Where GenerarNCF=0 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            Dim DevolucionVentaSinComprobante = Convert.ToDouble(cmd.ExecuteScalar())
            txtVNotaCred.Text = (CDbl(txtVNotaCred.Text) + DevolucionVentaSinComprobante).ToString("C")

            'Compras sin Valor Fiscal
            cmd = New MySqlCommand("SELECT Coalesce(Sum(TotalNeto),0) FROM compras Where IDComprobanteFiscal=1 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtCSinValorFiscal.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Compras Credito Fiscal
            cmd = New MySqlCommand("SELECT Coalesce(Sum(TotalNeto),0) FROM compras Where IDComprobanteFiscal=2 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtCCreditoFiscal.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Compras Consumidor Final
            cmd = New MySqlCommand("SELECT Coalesce(Sum(TotalNeto),0) FROM compras Where IDComprobanteFiscal=3 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtCConsumidorFinal.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Compras Gubernamental
            cmd = New MySqlCommand("SELECT Coalesce(Sum(TotalNeto),0) FROM compras Where IDComprobanteFiscal=10 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtCGubernamental.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Compras Operaciones Especiales
            cmd = New MySqlCommand("SELECT Coalesce(Sum(TotalNeto),0) FROM compras Where IDComprobanteFiscal=9 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtCOperacionesEsp.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Compras Generales
            cmd = New MySqlCommand("SELECT Coalesce(Sum(TotalNeto),0) FROM compras Where FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtCTotalGeneral.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Compras ITBIS
            cmd = New MySqlCommand("SELECT Coalesce(Sum(Itbis),0) FROM compras Where FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            txtCItbis.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Notas de Debito de Compras con Comprobante
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocreditocxp Where IDTipoNota=1 and GenerarNCF=1 AND Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            txtCNotDebNCF.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Notas de Debito de Compras sin Comprobante
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocreditocxp Where IDTipoNota=1 and GenerarNCF=0 AND Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            txtCNotDeb.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

            'Notas de Credito de Compras con Comprobante
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocreditocxp Where IDTipoNota=2 and GenerarNCF=1 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            txtCNotaCredNCF.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            cmd = New MySqlCommand("Select Coalesce(Sum(Devolver),0) From devolucionCompra Where NCF<>'' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            Dim NotaCreditoComprobanteCompra As Double = Convert.ToDouble(cmd.ExecuteScalar())
            'txtCNotaCredNCF.Text = (CDbl(txtCNotaCredNCF.Text) + NotaCreditoComprobanteCompra).ToString("C")

            'Notas de Credito de Compras sin Comprobante
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocreditocxp Where IDTipoNota=2 and GenerarNCF=0 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            txtCNotaCred.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            cmd = New MySqlCommand("Select Coalesce(Sum(Devolver),0) From devolucionCompra Where NCF='' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            Dim NotaCreditoSinComprobante As Double = Convert.ToDouble(cmd.ExecuteScalar())
            txtCNotaCred.Text = (CDbl(txtCNotaCred.Text) + NotaCreditoSinComprobante).ToString("C")

            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CalcDetalle()
        Try
            Dim Monto As Double = 0
            Dim MyNode() As TreeNode

            TreeView1.Nodes.Clear()

            Con.Open()

            'Ventas Todos
            cmd = New MySqlCommand("Select Coalesce(Sum(TotalNeto),0) From FacturaDatos Where Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            TreeView1.Nodes.Add("Ventas", "Ventas: " & Monto.ToString("C"))

            'Ventas sin Valor Fiscal
            cmd = New MySqlCommand("Select Coalesce(Sum(TotalNeto),0) From FacturaDatos Where IDComprobanteFiscal=1 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0 ", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Ventas", True)
            MyNode(0).Nodes.Add("VSinValorFiscal", "Sin Valor Fiscal: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,TotalNeto,Balance FROM facturadatos Where IDComprobanteFiscal=1 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "VentaSinValorFiscal")

            Dim TablaSinValorFiscal As DataTable = Ds.Tables("VentaSinValorFiscal")

            For Each Row As DataRow In TablaSinValorFiscal.Rows
                MyNode = TreeView1.Nodes.Find("VSinValorFiscal", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("TotalNeto")).ToString("C") & " | " & "Balance: " & CDbl(Row.Item("Balance")).ToString("C"))
            Next

            'Ventas Consumidor Final
            cmd = New MySqlCommand("Select Coalesce(Sum(TotalNeto),0) From FacturaDatos Where IDComprobanteFiscal=3 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0 ", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Ventas", True)
            MyNode(0).Nodes.Add("VConsumidorFinal", "Consumidor Final: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,NCF,TotalNeto,Balance FROM facturadatos Where IDComprobanteFiscal=3 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "VentaConsumidorFinal")

            Dim TablaConsumidorFinal As DataTable = Ds.Tables("VentaConsumidorFinal")

            For Each Row As DataRow In TablaConsumidorFinal.Rows
                MyNode = TreeView1.Nodes.Find("VConsumidorFinal", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("TotalNeto")).ToString("C") & " | " & "Balance: " & CDbl(Row.Item("Balance")).ToString("C"))
            Next

            'Ventas Credito Fiscal
            cmd = New MySqlCommand("Select Coalesce(Sum(TotalNeto),0) From FacturaDatos Where IDComprobanteFiscal=2 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0 ", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Ventas", True)
            MyNode(0).Nodes.Add("VCreditoFiscal", "Crédito Fiscal: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,NCF,TotalNeto,Balance FROM facturadatos Where IDComprobanteFiscal=2 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "VentaCreditoFiscal")

            Dim TablaCreditoFiscal As DataTable = Ds.Tables("VentaCreditoFiscal")

            For Each Row As DataRow In TablaCreditoFiscal.Rows
                MyNode = TreeView1.Nodes.Find("VCreditoFiscal", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("TotalNeto")).ToString("C") & " | " & "Balance: " & CDbl(Row.Item("Balance")).ToString("C"))
            Next

            'Ventas Gubernamental
            cmd = New MySqlCommand("Select Coalesce(Sum(TotalNeto),0) From FacturaDatos Where IDComprobanteFiscal=10 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0 ", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Ventas", True)
            MyNode(0).Nodes.Add("VGubernamental", "Comprobante Gubernamental: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,NCF,TotalNeto,Balance FROM facturadatos Where IDComprobanteFiscal=10 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "VentaGubernamental")

            Dim TablaGubernametal As DataTable = Ds.Tables("VentaGubernamental")

            For Each Row As DataRow In TablaGubernametal.Rows
                MyNode = TreeView1.Nodes.Find("VGubernamental", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("TotalNeto")).ToString("C") & " | " & "Balance: " & CDbl(Row.Item("Balance")).ToString("C"))
            Next

            'Ventas Operaciones Especiales
            cmd = New MySqlCommand("Select Coalesce(Sum(TotalNeto),0) From FacturaDatos Where IDComprobanteFiscal=9 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0 ", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Ventas", True)
            MyNode(0).Nodes.Add("VOperacionesEspeciales", "Operaciones Especiales: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,NCF,TotalNeto,Balance FROM facturadatos Where IDComprobanteFiscal=9 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "VentaOperacionesEspeciales")

            Dim TablaOperacionesEspeciales As DataTable = Ds.Tables("VentaOperacionesEspeciales")

            For Each Row As DataRow In TablaOperacionesEspeciales.Rows
                MyNode = TreeView1.Nodes.Find("VOperacionesEspeciales", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("TotalNeto")).ToString("C") & " | " & "Balance: " & CDbl(Row.Item("Balance")).ToString("C"))
            Next

            'ITbis Todos
            cmd = New MySqlCommand("Select Coalesce(Sum(Itbis),0) From FacturaDatos Where Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Ventas", True)
            MyNode(0).Nodes.Add("VItbis", " I.T.B.I.S.: " & Monto.ToString("C"))

            'Ventas Nota Debito NCF
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocredito Where GenerarNCF=1 AND IDTipoNota=1 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Ventas", True)
            MyNode(0).Nodes.Add("VNotaDebitoNCF", "Notas de débito NCF: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,NCF,Neto From notadebitocredito Where GenerarNCF=1 AND IDTipoNota=1 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "VentaNotaDebitoNCF")

            Dim TablaNotaDebitoNCF As DataTable = Ds.Tables("VentaNotaDebitoNCF")

            For Each Row As DataRow In TablaNotaDebitoNCF.Rows
                MyNode = TreeView1.Nodes.Find("VNotaDebitoNCF", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("Neto")).ToString("C"))
            Next

            'Ventas Nota Debito
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocredito Where GenerarNCF=0 AND IDTipoNota=1 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Ventas", True)
            MyNode(0).Nodes.Add("VNotaDebito", "Notas de débito: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,Neto From notadebitocredito Where GenerarNCF=0 AND IDTipoNota=1 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "VentaNotaDebito")

            Dim TablaNotaDebito As DataTable = Ds.Tables("VentaNotaDebito")

            For Each Row As DataRow In TablaNotaDebito.Rows
                MyNode = TreeView1.Nodes.Find("VNotaDebito", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("Neto")).ToString("C"))
            Next

            'Ventas Nota Credito NCF
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocredito Where GenerarNCF=1 AND IDTipoNota=2 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = Convert.ToDouble(cmd.ExecuteScalar())
            cmd = New MySqlCommand("Select Coalesce(Sum(Devolver),0) From devolucionventa Where GenerarNCF=1 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            Dim Monto2 As Double = Convert.ToDouble(cmd.ExecuteScalar())
            Monto = Monto + Monto2
            MyNode = TreeView1.Nodes.Find("Ventas", True)
            MyNode(0).Nodes.Add("VNotaCreditoNCF", "Notas de crédito NCF: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,NCF,Neto From notadebitocredito Where GenerarNCF=1 AND IDTipoNota=2 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "VentaNotaCreditoNCF")

            Dim TablaNotaCreditoNCF As DataTable = Ds.Tables("VentaNotaCreditoNCF")

            For Each Row As DataRow In TablaNotaCreditoNCF.Rows
                MyNode = TreeView1.Nodes.Find("VNotaCreditoNCF", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("Neto")).ToString("C"))
            Next

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,NCF,Devolver From DevolucionVenta Where GenerarNCF=1 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "DevolucionVentaNCF")

            Dim TablaDevolucionesNCF As DataTable = Ds.Tables("DevolucionVentaNCF")

            For Each Row As DataRow In TablaDevolucionesNCF.Rows
                MyNode = TreeView1.Nodes.Find("VNotaCreditoNCF", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("Devolver")).ToString("C"))
            Next

            'Ventas Nota Credito
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocredito Where GenerarNCF=0 AND IDTipoNota=2 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = Convert.ToDouble(cmd.ExecuteScalar())
            cmd = New MySqlCommand("Select Coalesce(Sum(Devolver),0) From devolucionventa Where GenerarNCF=0 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            Monto2 = Convert.ToDouble(cmd.ExecuteScalar())
            Monto = Monto + Monto2
            MyNode = TreeView1.Nodes.Find("Ventas", True)
            MyNode(0).Nodes.Add("VNotaCredito", "Notas de crédito: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,IDNotaDebCred,Neto From notadebitocredito Where GenerarNCF=0 AND IDTipoNota=2 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "VentaNotaCredito")

            Dim TablaNotaCredito As DataTable = Ds.Tables("VentaNotaCredito")

            For Each Row As DataRow In TablaNotaCredito.Rows
                MyNode = TreeView1.Nodes.Find("VNotaCredito", True)
                MyNode(0).Nodes.Add(Row.Item("IDNotaDebCred"), Row.Item("IDNotaDebCred") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("Neto")).ToString("C"))
            Next

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,NCF,Devolver From DevolucionVenta Where GenerarNCF=0 and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "DevolucionVenta")

            Dim TablaDevoluciones As DataTable = Ds.Tables("DevolucionVenta")

            For Each Row As DataRow In TablaDevoluciones.Rows
                MyNode = TreeView1.Nodes.Find("VNotaCreditoNCF", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("Devolver")).ToString("C"))
            Next

            'Compras Todos
            cmd = New MySqlCommand("SELECT Coalesce(Sum(TotalNeto),0) FROM compras Where FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            TreeView1.Nodes.Add("Compras", "Compras: " & Monto.ToString("C"))

            'Compras sin Valor Fiscal
            cmd = New MySqlCommand("SELECT Coalesce(Sum(TotalNeto),0) FROM compras Where IDComprobanteFiscal=1 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Compras", True)
            MyNode(0).Nodes.Add("CSinValorFiscal", "Sin Valor Fiscal: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,IDCompra,TotalNeto,Balance FROM compras Where IDComprobanteFiscal=1 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CompraSinValorFiscal")

            Dim TablaCSinValorFiscal As DataTable = Ds.Tables("CompraSinValorFiscal")

            For Each Row As DataRow In TablaCSinValorFiscal.Rows
                MyNode = TreeView1.Nodes.Find("CSinValorFiscal", True)
                MyNode(0).Nodes.Add(Row.Item("IDCompra"), Row.Item("IDCompra") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("TotalNeto")).ToString("C") & " | " & "Balance: " & CDbl(Row.Item("Balance")).ToString("C"))
            Next

            'Compras Consumidor Final
            cmd = New MySqlCommand("SELECT Coalesce(Sum(TotalNeto),0) FROM compras Where IDComprobanteFiscal=3 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Compras", True)
            MyNode(0).Nodes.Add("CConsumidorFinal", "Consumidor Final: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,IDCompra,TotalNeto,Balance,NCF FROM compras Where IDComprobanteFiscal=3 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CompraConsumidorFinal")

            Dim TablaCConsumidorFinal As DataTable = Ds.Tables("CompraConsumidorFinal")

            For Each Row As DataRow In TablaCConsumidorFinal.Rows
                MyNode = TreeView1.Nodes.Find("CConsumidorFinal", True)
                MyNode(0).Nodes.Add(Row.Item("IDCompra"), Row.Item("IDCompra") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("TotalNeto")).ToString("C") & " | " & "Balance: " & CDbl(Row.Item("Balance")).ToString("C"))
            Next

            'Compras Credito Fiscal
            cmd = New MySqlCommand("SELECT Coalesce(Sum(TotalNeto),0) FROM compras Where IDComprobanteFiscal=2 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Compras", True)
            MyNode(0).Nodes.Add("CCreditoFiscal", "Crédito Fiscal: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,IDCompra,TotalNeto,Balance,NCF FROM compras Where IDComprobanteFiscal=2 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CompraCreditoFiscal")

            Dim TablaCCreditoFiscal As DataTable = Ds.Tables("CompraCreditoFiscal")

            For Each Row As DataRow In TablaCCreditoFiscal.Rows
                MyNode = TreeView1.Nodes.Find("CCreditoFiscal", True)
                MyNode(0).Nodes.Add(Row.Item("IDCompra"), Row.Item("IDCompra") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("TotalNeto")).ToString("C") & " | " & "Balance: " & CDbl(Row.Item("Balance")).ToString("C"))
            Next

            'Compras Gubernamental
            cmd = New MySqlCommand("SELECT Coalesce(Sum(TotalNeto),0) FROM compras Where IDComprobanteFiscal=10 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Compras", True)
            MyNode(0).Nodes.Add("CGubernamental", "Comprobante Gubernamental: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,IDCompra,NCF,TotalNeto,Balance,NCF FROM Compras Where IDComprobanteFiscal=10 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CompraGubernamental")

            Dim TablaCGubernametal As DataTable = Ds.Tables("CompraGubernamental")

            For Each Row As DataRow In TablaCGubernametal.Rows
                MyNode = TreeView1.Nodes.Find("CGubernamental", True)
                MyNode(0).Nodes.Add(Row.Item("IDCompra"), Row.Item("IDCompra") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("TotalNeto")).ToString("C") & " | " & "Balance: " & CDbl(Row.Item("Balance")).ToString("C"))
            Next

            'Compras Operaciones Especiales
            cmd = New MySqlCommand("SELECT Coalesce(Sum(TotalNeto),0) FROM compras Where IDComprobanteFiscal=9 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Compras", True)
            MyNode(0).Nodes.Add("COperacionesEspeciales", "Operaciones Especiales: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,IDCompra,NCF,TotalNeto,Balance,NCF FROM Compras Where IDComprobanteFiscal=9 and FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CompraOperacionesEspeciales")

            Dim TablaCOperacionesEspeciales As DataTable = Ds.Tables("CompraOperacionesEspeciales")

            For Each Row As DataRow In TablaCOperacionesEspeciales.Rows
                MyNode = TreeView1.Nodes.Find("COperacionesEspeciales", True)
                MyNode(0).Nodes.Add(Row.Item("IDCompra"), Row.Item("IDCompra") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("TotalNeto")).ToString("C") & " | " & "Balance: " & CDbl(Row.Item("Balance")).ToString("C"))
            Next

            'ITbis Todos
            cmd = New MySqlCommand("Select Coalesce(Sum(Itbis),0) From Compras Where FechaFactura Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Compras", True)
            MyNode(0).Nodes.Add("CItbis", " I.T.B.I.S.: " & Monto.ToString("C"))


            'Compras Nota Debito NCF
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocreditoCXP Where IDNCF=3 AND NCF<>'' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Compras", True)
            MyNode(0).Nodes.Add("CNotaDebitoNCF", "Notas de débito NCF: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,IDNotaDebitoCreditoCXP,NCF,Neto From notadebitocreditocxp Where IDNCF=3 AND NCF<>'' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CompraNotaDebitoNCF")

            Dim TablaCNotaDebitoNCF As DataTable = Ds.Tables("CompraNotaDebitoNCF")

            For Each Row As DataRow In TablaCNotaDebitoNCF.Rows
                MyNode = TreeView1.Nodes.Find("cNotaDebitoNCF", True)
                MyNode(0).Nodes.Add(Row.Item("IDNotaDebitoCreditoCXP"), Row.Item("IDNotaDebitoCreditoCXP") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("Neto")).ToString("C"))
            Next

            'Compras Nota Debito
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocreditocxp Where IDNCF=4 AND NCF<>'' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")
            MyNode = TreeView1.Nodes.Find("Compras", True)
            MyNode(0).Nodes.Add("CNotaDebito", "Notas de débito: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,IDNotaDebitoCreditoCXP,Neto From notadebitocreditocxp Where IDNCF=4 AND NCF<>'' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CompraNotaDebito")

            Dim TablaCNotaDebito As DataTable = Ds.Tables("VentaNotaDebito")

            For Each Row As DataRow In TablaNotaDebito.Rows
                MyNode = TreeView1.Nodes.Find("CNotaDebito", True)
                MyNode(0).Nodes.Add(Row.Item("IDNotaDebitoCreditoCXP"), Row.Item("IDNotaDebitoCreditoCXP") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("Neto")).ToString("C"))
            Next

            'Compras Nota Credito NCF
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocreditocxp Where IDNCF=4 AND NCF<>'' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = Convert.ToDouble(cmd.ExecuteScalar())
            cmd = New MySqlCommand("Select Coalesce(Sum(Devolver),0) From devolucionCompra Where NCF<>'' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            Monto2 = Convert.ToDouble(cmd.ExecuteScalar())
            Monto = Monto + Monto2

            MyNode = TreeView1.Nodes.Find("Compras", True)
            MyNode(0).Nodes.Add("cNotaCreditoNCF", "Notas de crédito NCF: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,NCF,Neto From notadebitocreditocxp Where IDNCF=4 AND NCF<>'' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CompraNotaCreditoNCF")

            Dim TablaCNotaCreditoNCF As DataTable = Ds.Tables("CompraNotaCreditoNCF")

            For Each Row As DataRow In TablaCNotaCreditoNCF.Rows
                MyNode = TreeView1.Nodes.Find("CNotaCreditoNCF", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("Neto")).ToString("C"))
            Next

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,NCF,Devolver From DevolucionCompra Where NCF<>'' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "DevolucionCompraNCF")

            Dim TablaDevolucionCompraNCF As DataTable = Ds.Tables("DevolucionCompraNCF")

            For Each Row As DataRow In TablaDevolucionCompraNCF.Rows
                MyNode = TreeView1.Nodes.Find("CNotaCreditoNCF", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("Devolver")).ToString("C"))
            Next

            'Compras Nota Credito
            cmd = New MySqlCommand("Select Coalesce(Sum(Neto),0) From notadebitocreditocxp Where IDNCF=4 AND NCF<>'' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Monto = Convert.ToDouble(cmd.ExecuteScalar())
            cmd = New MySqlCommand("Select Coalesce(Sum(Devolver),0) From devolucionCompra Where NCF='' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' AND Nulo=0", Con)
            Monto2 = Convert.ToDouble(cmd.ExecuteScalar())
            Monto = Monto + Monto2
            MyNode = TreeView1.Nodes.Find("Compras", True)
            MyNode(0).Nodes.Add("CNotaCredito", "Notas de crédito: " & Monto.ToString("C"))

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,Neto From notadebitocreditocxp Where IDNCF=4 AND NCF='' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "CompraNotaCredito")

            Dim TablaCNotaCredito As DataTable = Ds.Tables("CompraNotaCredito")

            For Each Row As DataRow In TablaCNotaCredito.Rows
                MyNode = TreeView1.Nodes.Find("CNotaCredito", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("Neto")).ToString("C"))
            Next

            Ds.Clear()
            cmd = New MySqlCommand("SELECT Fecha,SecondID,NCF,Devolver From DevolucionCompra Where NCF='' and Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "DevolucionCompra")

            Dim TablaDevolucionCompra As DataTable = Ds.Tables("DevolucionCompra")

            For Each Row As DataRow In TablaDevolucionCompra.Rows
                MyNode = TreeView1.Nodes.Find("CNotaCredito", True)
                MyNode(0).Nodes.Add(Row.Item("SecondID"), Row.Item("SecondID") & " | " & Row.Item("NCF") & " | " & Row.Item("Fecha") & " | " & "Neto: " & CDbl(Row.Item("Devolver")).ToString("C"))
            Next

            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LimpiarDatos()
        txtFechaInicial.Value = Today
        txtFechaFinal.Value = Today
        txtVSinValorFiscal.Clear()
        txtVConsumidorFinal.Clear()
        txtVCreditoFiscal.Clear()
        txtVGubernamental.Clear()
        txtVOperacionEspecial.Clear()
        txtVTotal.Clear()
        txtVItbis.Clear()
        txtVNotDebNCF.Clear()
        txtVNotaCredNCF.Clear()
        txtCSinValorFiscal.Clear()
        txtCConsumidorFinal.Clear()
        txtCCreditoFiscal.Clear()
        txtCGubernamental.Clear()
        txtCOperacionesEsp.Clear()
        txtCTotalGeneral.Clear()
        txtCItbis.Clear()
        txtCNotDebNCF.Clear()
        txtCNotaCredNCF.Clear()
        txtCNotaCred.Clear()
        txtCNotDeb.Clear()
        txtVNotaCred.Clear()
        txtVNotDeb.Clear()
        txtTamañoLetra.Text = 9
    End Sub

    Private Sub Actualizar()
        FillReportes()
        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
        cbxTipoOrden.SelectedIndex = 0
        TreeView1.Nodes.Clear()
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            CalcGeneral()
            CalcDetalle()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
        Actualizar()
    End Sub


    Private Sub txtTamañoLetra_ValueChanged(sender As Object, e As EventArgs) Handles txtTamañoLetra.ValueChanged
        TreeView1.Font = New Font("Segoe UI", CInt(txtTamañoLetra.Value), FontStyle.Regular)
        TreeView1.Refresh()
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Ds.Clear()
        chkResumir.Checked = False
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Reportes")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Reportes")
        IDReport.Text = (Tabla.Rows(0).Item("IDReportes"))
        NameReport.Text = (Tabla.Rows(0).Item("Reporte"))
        PathReport.Text = (Tabla.Rows(0).Item("Path"))


        If (Tabla.Rows(0).Item("HabilitadoResumen")) = 0 Then
            chkResumir.Enabled = False
        Else
            chkResumir.Enabled = True
        End If

        FillOrdenamiento()
    End Sub

    Private Sub cbxTipoOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoOrden.SelectedIndexChanged
        If CbxOrden.Text = "Ascendente" Then
            OrdenFormula.Text = "crAscendingOrder"
        ElseIf CbxOrden.Text = "Descendiente" Then
            OrdenFormula.Text = "crDescendingOrder"
        End If
    End Sub

    Private Sub CbxOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxOrden.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("Select Campo from ReportesOrden where IDReporte='" + IDReport.Text + "' and Descripcion='" + CbxOrden.Text + "'", Con)
        OrdenCampo.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
    End Sub

    Private Sub FillOrdenamiento()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Descripcion FROM ReportesOrden where IDReporte='" + IDReport.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "OrdenReportes")
            CbxOrden.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("OrdenReportes")

            For Each Fila As DataRow In Tabla.Rows
                CbxOrden.Items.Add(Fila.Item("Descripcion"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxOrden.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron orden de reportes que involucren este vínculo del módulo.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "FillOrdenamiento()")
        End Try

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

    Private Sub ChangePictureRdb()
        If rdbPresentacion.Checked = True Then
            PicSalida.Image = My.Resources.Preview_x72
        ElseIf rdbImpresora.Checked = True Then
            PicSalida.Image = My.Resources.Printer_x72
        ElseIf rdbPDF.Checked = True Then
            PicSalida.Image = My.Resources.AdobeReader_x72
        ElseIf rdbExcel.Checked = True Then
            PicSalida.Image = My.Resources.Ms_Excel_x72
        End If
    End Sub

    Private Sub rdbImpresora_CheckedChanged(sender As Object, e As EventArgs) Handles rdbImpresora.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub rdbPDF_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPDF.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub rdbExcel_CheckedChanged(sender As Object, e As EventArgs) Handles rdbExcel.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub rdbPresentacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPresentacion.CheckedChanged
        ChangePictureRdb()
    End Sub


    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub


    Private Sub btnPresentar_Click(sender As Object, e As EventArgs) Handles btnPresentar.Click
        Try
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


            If CDate(txtFechaFinal.Value) < CDate(txtFechaInicial.Value) Then
                MessageBox.Show("La fecha inicial es mayor a la fecha inicial" & vbNewLine & vbNewLine & "Por favor revisar las fechas para procesar el reporte.", "Rangos de Fechas no válidos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            CalcGeneral()
            CalcDetalle()

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            '@Fecha
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
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

            'Setting Info 
            ObjRpt.SetParameterValue("VentasSinValorFiscal", CDbl(txtVSinValorFiscal.Text))
            ObjRpt.SetParameterValue("VentasConsumidorFinal", CDbl(txtVConsumidorFinal.Text))
            ObjRpt.SetParameterValue("VentasCreditoFiscal", CDbl(txtVCreditoFiscal.Text))
            ObjRpt.SetParameterValue("VentasGubernamental", CDbl(txtVGubernamental.Text))
            ObjRpt.SetParameterValue("VentasOperacionesEspecial", CDbl(txtVOperacionEspecial.Text))
            ObjRpt.SetParameterValue("VentasTotalGeneral", CDbl(txtVTotal.Text))
            ObjRpt.SetParameterValue("VentasItbis", CDbl(txtVItbis.Text))
            ObjRpt.SetParameterValue("VentasNotaDebitoSinValor", CDbl(txtVNotDeb.Text))
            ObjRpt.SetParameterValue("VentasNotaDebitoConValor", CDbl(txtVNotDebNCF.Text))
            ObjRpt.SetParameterValue("VentasNotaCreditoSinValor", CDbl(txtVNotaCred.Text))
            ObjRpt.SetParameterValue("VentasNotaCreditoConValor", CDbl(txtVNotaCredNCF.Text))

            ObjRpt.SetParameterValue("ComprasSinValorFiscal", CDbl(txtCSinValorFiscal.Text))
            ObjRpt.SetParameterValue("ComprasConsumidorFinal", CDbl(txtCConsumidorFinal.Text))
            ObjRpt.SetParameterValue("ComprasCreditoFiscal", CDbl(txtCCreditoFiscal.Text))
            ObjRpt.SetParameterValue("ComprasGubernamental", CDbl(txtCGubernamental.Text))
            ObjRpt.SetParameterValue("ComprasOperacionesEspecial", CDbl(txtCOperacionesEsp.Text))
            ObjRpt.SetParameterValue("ComprasTotalGeneral", CDbl(txtCTotalGeneral.Text))
            ObjRpt.SetParameterValue("ComprasItbis", CDbl(txtCItbis.Text))
            ObjRpt.SetParameterValue("ComprasNotaDebitoSinValor", CDbl(txtCNotDeb.Text))
            ObjRpt.SetParameterValue("ComprasNotaDebitoConValor", CDbl(txtCNotDebNCF.Text))
            ObjRpt.SetParameterValue("ComprasNotaCreditoSinValor", CDbl(txtCNotaCred.Text))
            ObjRpt.SetParameterValue("ComprasNotaCreditoConValor", CDbl(txtCNotaCredNCF.Text))

            'Resumir Reporte
            If chkResumir.Checked = True Then
                ObjRpt.SetParameterValue("@Resumir", 1)
            Else
                ObjRpt.SetParameterValue("@Resumir", 0)
            End If
            'Ordenamiento de Reporte
            ObjRpt.SetParameterValue("@SortedField", OrdenCampo.Text)
            ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & CbxOrden.Text)
            'RangoFechas()
            If txtFechaInicial.Value = txtFechaFinal.Value Then
                ObjRpt.SetParameterValue("@RangoFechas", "Del " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
            Else
                ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
            End If

            'Usuario Info
            ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadAnimation()

            If rdbPresentacion.Checked = True Then
                lblStatusBar.Text = "Visualizando el reporte..."
                Dim TmpForm = New frm_reportView
                TmpForm.Show(Me)
                TmpForm.CrystalViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                TmpForm.CrystalViewer.ReportSource = ObjRpt
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
                    ObjRpt.SummaryInfo.ReportTitle = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy")
                    ObjRpt.SummaryInfo.ReportAuthor = frm_inicio.lblNombre.Text & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "] "
                    ObjRpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName
                    Dim Settings As New PrinterSettings
                    Dim PrinterDefault As String = Settings.PrinterName
                    Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", PrintDialog.PrinterSettings.PrinterName))
                    ObjRpt.PrintToPrinter(PrintDialog.PrinterSettings.Copies, PrintDialog.PrinterSettings.Collate, PrintDialog.PrinterSettings.FromPage, PrintDialog.PrinterSettings.ToPage)
                    Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", PrinterDefault))
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
                    CrExportOptions = ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    ObjRpt.Export()
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
                    CrExportOptions = ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.Excel
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    ObjRpt.Export()
                    MessageBox.Show("La exportación ha finalizado.", "Exportación satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Process.Start(GetFileName.FileName)
                End If

            End If

            lblStatusBar.Text = "Listo"

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
End Class