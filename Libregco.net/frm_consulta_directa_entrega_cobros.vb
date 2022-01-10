Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_consulta_directa_entrega_cobros

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDEntrega As New Label

    Private Sub frm_consulta_directa_entrega_cobros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        GetIDEntrega()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub GetIDEntrega()
        Dim Ds1, Ds2 As New DataSet
        Dim MyNode() As TreeNode
        Dim lblIDRecibo As New Label

        TreeView1.Nodes.Clear()

        If Me.Owner.Name = frm_registro_recibos_cobro.Name Then
            lblIDEntrega.Text = frm_registro_recibos_cobro.lblIDEntrega.Text
        ElseIf Me.Owner.Name = frm_registro_recibos_cobro_secuencial.Name Then
            lblIDEntrega.Text = frm_registro_recibos_cobro_secuencial.lblIDEntrega.Text
        End If

        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDEntregaCobro,EntregaCobro.SecondID,NoEntrega,Descripcion,FechaEntrega,Hora,IDCobrador,Nombre,Cantidad,NoInicial,NoFinal,Monto,Comision,Cierre,EntregaCobro.Nulo FROM entregacobro INNER JOIN Empleados on EntregaCobro.IDCobrador=Empleados.IDEmpleado where IDEntregaCobro='" + lblIDEntrega.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Entregacobro")


        Dim Tabla As DataTable = Ds1.Tables("Entregacobro")

        txtIDEntrega.Text = (Tabla.Rows(0).Item("IDEntregaCobro"))
        txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
        txtNoEntrega.Text = (Tabla.Rows(0).Item("NoEntrega"))
        txtCobrador.Text = "[" & (Tabla.Rows(0).Item("IDCobrador")) & "] " & (Tabla.Rows(0).Item("Nombre"))
        txtRango.Text = (Tabla.Rows(0).Item("NoInicial")) & "-" & (Tabla.Rows(0).Item("NoFinal")) & " [" & (Tabla.Rows(0).Item("Cantidad")) & "]"
        txtMonto.Text = CDbl(Tabla.Rows(0).Item("Monto")).ToString("C")
        txtFecha.Text = CDate(Tabla.Rows(0).Item("FechaEntrega")).ToString("dd/MM/yyyy")
        txtHora.Text = CDate(Convert.ToString(Tabla.Rows(0).Item("Hora"))).ToString("hh:mm:ss tt")

        'Lleno datatable con los recibos de la entrega

        cmd = New MySqlCommand("SELECT IDReciboCobro,PreRecibo,NoRecibo,Fecha,RecibosCobro.IDTipoRecibo,TipoRecibos.Descripcion,Monto FROM reciboscobro INNER JOIN TipoRecibos on RecibosCobro.IDTipoRecibo=TipoRecibos.IDTipoRecibo where IDEntregaCobro='" + lblIDEntrega.Text + "' ORDER BY NoRecibo ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds2, "Recibos")

        Dim Tabla1 As DataTable = Ds2.Tables("Recibos")

        For Each row As DataRow In Tabla1.Rows
            lblIDRecibo.Text = row.Item("IDReciboCobro")

            TreeView1.Nodes.Add(row.Item("IDReciboCobro"), "ID: " & row.Item("IDReciboCobro") & " | " & row.Item("PreRecibo") & " " & row.Item("NoRecibo") & " | " & " | " & CDate(row.Item("Fecha")).ToString("dd/MM/yyyy") & " | [" & row.Item("IDTipoRecibo") & "] " & row.Item("Descripcion") & " | " & CDbl(row.Item("Monto")).ToString("C"))

            'Búsqueda de detalle de recibos
            Ds1.Clear()
            cmd = New MySqlCommand("SELECT FacturaDatos.IDCliente,FacturaDatos.NombreFactura,Pagares.IDFactura,FacturaDatos.SecondID,RecibosDetalle.IDPagare,Pagares.NoPagare,Pagares.Cantidad,RecibosDetalle.Debito,RecibosDetalle.Descuento,IDComision,ComisionCobro.Descripcion as TipoComision,RecibosDetalle.Comision FROM recibosdetalle INNER JOIN Pagares on RecibosDetalle.IDPagare=Pagares.IDPagare INNER JOIN ComisionCobro on RecibosDetalle.IDComision=ComisionCobro.IDComisionCobro INNER JOIN FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where RecibosDetalle.IDReciboCobro='" + lblIDRecibo.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "RecibosDetalle")

            Dim TablaDetalle As DataTable = Ds1.Tables("RecibosDetalle")

            For Each Rowx As DataRow In TablaDetalle.Rows
                MyNode = TreeView1.Nodes.Find(lblIDRecibo.Text, True)
                MyNode(0).Nodes.Add("[" & Rowx.Item("IDCliente") & "] " & Rowx.Item("NombreFactura") & " | " & "No. de factura: " & Rowx.Item("SecondID") & " | " & " Pagaré No.: [" & Rowx.Item("IDPagare") & "] " & Rowx.Item("NoPagare") & "/" & Rowx.Item("Cantidad"))
                MyNode(0).Nodes.Add("Débito: " & CDbl(Rowx.Item("Debito")).ToString("C") & " Descuento: " & CDbl(Rowx.Item("Descuento")).ToString("C") & " Total aplicado: " & CDbl((Rowx.Item("Debito")) + CDbl(Rowx.Item("Descuento"))).ToString("C") & " | " & "Comisión: " & CDbl(Rowx.Item("Comision")).ToString("C") & " [" & Rowx.Item("IDComision") & "] " & Rowx.Item("TipoComision"))
                MyNode(0).Nodes.Add("")

            Next
        Next

        TreeView1.ExpandAll()

        Con.Close()
    End Sub

    Private Sub txtTamañoLetra_ValueChanged(sender As Object, e As EventArgs) Handles txtTamañoLetra.ValueChanged
        TreeView1.Font = New Font("Segoe UI", CInt(txtTamañoLetra.Value), FontStyle.Regular)
        TreeView1.Refresh()
    End Sub
End Class