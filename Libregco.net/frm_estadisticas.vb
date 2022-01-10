Imports System.IO
Imports DevExpress.Utils
Imports DevExpress.XtraCharts
Imports MySql.Data.MySqlClient
Public Class frm_estadisticas
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim IDPrivilegio As Integer = 1
    Dim FlagToLoaded As Boolean = False
    '1 es Admin, 2 Supervisor, 3 Usuario

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarTodo()
        CargarUsuarios
        GetVentasDiarias()
        GetVentasBeneficios()
        GetVentasPastel()
        GetArticulosmasVendidos()
        FlagToLoaded = True

        If frm_inicio.rdbOscuro.Checked Then
            LayoutControl1.BackColor = SystemColors.ControlDarkDark
            LayoutControl1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
            frm_inicio.NavigationPage4.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpressDark)
        Else
            LayoutControl1.BackColor = SystemColors.Control
            LayoutControl1.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
            frm_inicio.NavigationPage4.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)
        End If


    End Sub

    Private Sub CargarUsuarios()
        'Cargar monedas habiles
        Dim dstemp As New DataSet
        cbxUsuarios.Properties.Items.Clear()
        cmd = New MySqlCommand("SELECT IDEmpleado,Nombre FROM" & SysName.Text & "Empleados Where Empleados.Nulo=0 order by Nombre ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Empleados")

        Dim Tabla1 As DataTable = dstemp.Tables("Empleados")

        For Each Fila As DataRow In Tabla1.Rows
            Dim nvmoneda As New DevExpress.XtraEditors.Controls.ImageComboBoxItem

            nvmoneda.Description = Fila.Item("Nombre")
            nvmoneda.Value = Fila.Item("IDEmpleado")

            'If Fila.Item("IDTipoMoneda") = 1 Then
            '    nvmoneda.ImageIndex = 0
            'ElseIf Fila.Item("IDTipoMoneda") = 2 Then
            '    nvmoneda.ImageIndex = 1
            'ElseIf Fila.Item("IDTipoMoneda") = 3 Then
            '    nvmoneda.ImageIndex = 2
            'End If

            cbxUsuarios.Properties.Items.Add(nvmoneda)
        Next

        cbxUsuarios.EditValue = CInt(DtEmpleado.Rows(0).item("IDEmpleado").ToString())
    End Sub


    Private Sub ActualizarTodo()
        cbxTiempo.SelectedIndex = 0
        cbxAgrupacionVentasPeriodos.SelectedIndex = 0
        ComboBoxEdit2.SelectedIndex = 0
        dtpInicial.EditValue = Now.AddDays(-30)
        DtpFinal.EditValue = Now
    End Sub

    Private Function GetValueofTime(ByVal TiempString As String) As Integer
        If TiempString = "Días" Then
            Return 4
        ElseIf TiempString = "Semanas" Then
            Return 5
        ElseIf TiempString = "Meses" Then
            Return 6
        ElseIf TiempString = "Cuartos" Then
            Return 7
        ElseIf TiempString = "Años" Then
            Return 8
        Else
            Return 4
        End If
    End Function

    Private Sub GetVentasDiarias()
        Dim dstmp As New DataSet

        GvVentasEmpleados.Columns.Clear()

        With GraficoVentasEmpleados
            .DataSource = Nothing
            .Titles.Clear()
            .Series.Clear()
            .SeriesTemplate.ArgumentDataMember = ""
            .Legends.Clear()
            .ClearCache()
            .ClearSelection()
        End With

        Dim TablaDatos As DataTable = New DataTable("Datos")
        TablaDatos.Columns.Add("IDEmpleado", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Nombre", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Dia", System.Type.GetType("System.DateTime"))
        TablaDatos.Columns.Add("Ventas", System.Type.GetType("System.Double"))

        GcVentasEmpleados.DataSource = TablaDatos

        GvVentasEmpleados.Columns("IDEmpleado").Visible = False
        GvVentasEmpleados.Columns("Ventas").DisplayFormat.FormatType = FormatType.Numeric
        GvVentasEmpleados.Columns("Ventas").DisplayFormat.FormatString = "C"


        'Consigo los vendedores del periodo de ventas
        ConMixta.Open()
        cmd = New MySqlCommand("Select Resultados.IDVendedor,Resultados.Nombre from (Select FacturaDatos.IDVendedor,Empleados.Nombre as Nombre from Libregco.FacturaDatos INNER JOIN Libregco.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " GROUP BY FacturaDatos.IDVendedor UNION ALL Select FacturaDatos.IDVendedor,Empleados.Nombre as Nombre from Libregco_Main.FacturaDatos INNER JOIN Libregco_Main.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " GROUP BY FacturaDatos.IDVendedor) as Resultados GROUP BY Resultados.IDVendedor", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstmp, "FacturaDatos")
        ConMixta.Close()

        Dim TablaVentas As DataTable = dstmp.Tables("FacturaDatos")

        If TablaVentas.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron ventas durante el período específicado.")
            Exit Sub
        Else
            For Each itm As DataRow In TablaVentas.Rows
                Dim series1 As New Series(itm.Item("Nombre"), ViewType.Line)

                series1.Tag = itm.Item("IDVendedor")
                CType(series1.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True
                CType(series1.View, LineSeriesView).LineMarkerOptions.Kind = MarkerKind.Circle
                CType(series1.View, LineSeriesView).LineStyle.DashStyle = DashStyle.Solid

                series1.CheckableInLegend = True
                series1.CheckedInLegend = True
                series1.CrosshairLabelPattern = "{a} {v:c}"
                GraficoVentasEmpleados.Series.Add(series1)

                GraficoVentasEmpleados.Series(itm.Item("Nombre")).ArgumentScaleType = ScaleType.DateTime
                GraficoVentasEmpleados.Series(itm.Item("Nombre")).ValueScaleType = ScaleType.Numerical
            Next

            Dim diagram As XYDiagram = TryCast(GraficoVentasEmpleados.Diagram, XYDiagram)
            diagram.AxisX.DateTimeScaleOptions.MeasureUnit = GetValueofTime(cbxTiempo.SelectedItem)
            diagram.AxisX.DateTimeScaleOptions.GridAlignment = GetValueofTime(cbxTiempo.SelectedItem)

            If GetValueofTime(cbxTiempo.SelectedItem) < 6 Then
                diagram.AxisX.Label.TextPattern = "{a:dd MMM}"
            Else
                diagram.AxisX.Label.TextPattern = "{a:MMM yyyy}"
            End If

            diagram.AxisY.Label.TextPattern = "{v:c}"

            CType(GraficoVentasEmpleados.Diagram, XYDiagram).EnableAxisXZooming = True

            'Consigo los datos de las ventas
            TablaDatos.Clear()
            Using ConMixta As MySqlConnection = New MySqlConnection(CnString)
                Using myCommand As MySqlCommand = New MySqlCommand(GetQueryVentas, ConMixta)
                    ConMixta.Open()
                    Using myReader As MySqlDataReader = myCommand.ExecuteReader
                        TablaDatos.Load(myReader, LoadOption.Upsert)
                        ConMixta.Close()
                    End Using
                End Using
            End Using
            TablaDatos.EndLoadData()
            GvVentasEmpleados.BestFitColumns()


            For Each rw As DataRow In TablaDatos.Rows
                GraficoVentasEmpleados.Series(rw.Item(1)).Points.AddPoint(CDate(rw.Item(2)), CDbl(rw.Item(3)))
            Next

            If IDPrivilegio = 3 Then
                GraficoVentasEmpleados.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
                chkTodos.Visible = False
            End If

            GraficoVentasEmpleados.Legend.Direction = LegendDirection.LeftToRight
        End If

        dstmp.Dispose()
    End Sub

    Private Function GetQueryVentas() As String
        Dim Value As String = GetValueofTime(cbxTiempo.SelectedItem)

        If Value = 4 Then
            Return "Select IDEmpleado,Nombre,Dia,Sum(Ventas) AS Ventas from (Select FacturaDatos.IDVendedor as IDEmpleado,Empleados.Nombre,FacturaDatos.Fecha as Dia,SUM(FacturaDatos.TotalNeto) as Ventas from Libregco.FacturaDatos INNER JOIN Libregco.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and FacturaDatos.Nulo=0 GROUP BY FacturaDatos.IDVendedor,Date(FacturaDatos.Fecha) UNION ALL Select FacturaDatos.IDVendedor as IDEmpleado,Empleados.Nombre,FacturaDatos.Fecha as Dia,SUM(FacturaDatos.TotalNeto) as Ventas from Libregco_Main.FacturaDatos INNER JOIN Libregco_Main.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and FacturaDatos.Nulo=0 GROUP BY FacturaDatos.IDVendedor,Date(FacturaDatos.Fecha)) as Resultados GROUP BY Resultados.IDEmpleado,Date(Resultados.Dia) ORDER BY Resultados.Dia ASC"
        ElseIf Value = 5 Then
            Return "Select IDEmpleado,Nombre,Dia,Sum(Ventas) AS Ventas from (Select FacturaDatos.IDVendedor as IDEmpleado,Empleados.Nombre,FacturaDatos.Fecha as Dia,SUM(FacturaDatos.TotalNeto) as Ventas from Libregco.FacturaDatos INNER JOIN Libregco.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and FacturaDatos.Nulo=0 GROUP BY FacturaDatos.IDVendedor,Year(FacturaDatos.Fecha),Week(FacturaDatos.Fecha) UNION ALL Select FacturaDatos.IDVendedor as IDEmpleado,Empleados.Nombre,FacturaDatos.Fecha as Dia,SUM(FacturaDatos.TotalNeto) as Ventas from Libregco_Main.FacturaDatos INNER JOIN Libregco_Main.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and FacturaDatos.Nulo=0 GROUP BY FacturaDatos.IDVendedor,Year(FacturaDatos.Fecha),Week(FacturaDatos.Fecha)) as Resultados GROUP BY Resultados.IDEmpleado,Date(Resultados.Dia) ORDER BY Resultados.Dia ASC"
        ElseIf Value = 6 Then
            Return "Select IDEmpleado,Nombre,Dia,Sum(Ventas) AS Ventas from (Select FacturaDatos.IDVendedor as IDEmpleado,Empleados.Nombre,FacturaDatos.Fecha as Dia,SUM(FacturaDatos.TotalNeto) as Ventas from Libregco.FacturaDatos INNER JOIN Libregco.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and FacturaDatos.Nulo=0 GROUP BY FacturaDatos.IDVendedor,Year(FacturaDatos.Fecha),Month(FacturaDatos.Fecha) UNION ALL Select FacturaDatos.IDVendedor as IDEmpleado,Empleados.Nombre,FacturaDatos.Fecha as Dia,SUM(FacturaDatos.TotalNeto) as Ventas from Libregco_Main.FacturaDatos INNER JOIN Libregco_Main.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and FacturaDatos.Nulo=0 GROUP BY FacturaDatos.IDVendedor,Year(FacturaDatos.Fecha),Month(FacturaDatos.Fecha)) as Resultados GROUP BY Resultados.IDEmpleado,Date(Resultados.Dia) ORDER BY Resultados.Dia ASC"
        ElseIf Value = 7 Then
            Return "Select IDEmpleado,Nombre,Dia,Sum(Ventas) AS Ventas from (Select FacturaDatos.IDVendedor as IDEmpleado,Empleados.Nombre,FacturaDatos.Fecha as Dia,SUM(FacturaDatos.TotalNeto) as Ventas from Libregco.FacturaDatos INNER JOIN Libregco.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and FacturaDatos.Nulo=0 GROUP BY FacturaDatos.IDVendedor,Year(FacturaDatos.Fecha),Quarter(FacturaDatos.Fecha) UNION ALL Select FacturaDatos.IDVendedor as IDEmpleado,Empleados.Nombre,FacturaDatos.Fecha as Dia,SUM(FacturaDatos.TotalNeto) as Ventas from Libregco_Main.FacturaDatos INNER JOIN Libregco_Main.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and FacturaDatos.Nulo=0 GROUP BY FacturaDatos.IDVendedor,Year(FacturaDatos.Fecha),Quarter(FacturaDatos.Fecha)) as Resultados GROUP BY Resultados.IDEmpleado,Date(Resultados.Dia) ORDER BY Resultados.Dia ASC"
        ElseIf Value = 8 Then
            Return "Select IDEmpleado,Nombre,Dia,Sum(Ventas) AS Ventas from (Select FacturaDatos.IDVendedor as IDEmpleado,Empleados.Nombre,FacturaDatos.Fecha as Dia,SUM(FacturaDatos.TotalNeto) as Ventas from Libregco.FacturaDatos INNER JOIN Libregco.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and FacturaDatos.Nulo=0 GROUP BY FacturaDatos.IDVendedor,Year(FacturaDatos.Fecha) UNION ALL Select FacturaDatos.IDVendedor as IDEmpleado,Empleados.Nombre,FacturaDatos.Fecha as Dia,SUM(FacturaDatos.TotalNeto) as Ventas from Libregco_Main.FacturaDatos INNER JOIN Libregco_Main.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and FacturaDatos.Nulo=0 GROUP BY FacturaDatos.IDVendedor,Year(FacturaDatos.Fecha)) as Resultados GROUP BY Resultados.IDEmpleado,Date(Resultados.Dia) ORDER BY Resultados.Dia ASC"
        Else
            Return "Select IDEmpleado,Nombre,Dia,Sum(Ventas) AS Ventas from (Select FacturaDatos.IDVendedor as IDEmpleado,Empleados.Nombre,FacturaDatos.Fecha as Dia,SUM(FacturaDatos.TotalNeto) as Ventas from Libregco.FacturaDatos INNER JOIN Libregco.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and FacturaDatos.Nulo=0 GROUP BY FacturaDatos.IDVendedor,Date(FacturaDatos.Fecha) UNION ALL Select FacturaDatos.IDVendedor as IDEmpleado,Empleados.Nombre,FacturaDatos.Fecha as Dia,SUM(FacturaDatos.TotalNeto) as Ventas from Libregco_Main.FacturaDatos INNER JOIN Libregco_Main.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and FacturaDatos.Nulo=0 GROUP BY FacturaDatos.IDVendedor,Date(FacturaDatos.Fecha)) as Resultados GROUP BY Resultados.IDEmpleado,Date(Resultados.Dia) ORDER BY Resultados.Dia ASC"
        End If


    End Function

    Private Function GetQueryVentasComparacionPeriodos() As String
        Dim Value As String = GetValueofTime(cbxAgrupacionVentasPeriodos.SelectedItem)
        If Value = 4 Then
            Return "Select Resultados.Fecha,Resultados.Semana,Resultados.Dia,Resultados.Mes,Resultados.Cuarto,Resultados.Ano,Sum(Resultados.TotalNeto) as TotalNeto,Sum(Resultados.Efectivo) as Efectivo,Sum(Resultados.Cheque) as Cheque,Sum(Resultados.Deposito) as Deposito,Sum(Resultados.Tarjeta) as Tarjeta,Sum(Resultados.Credito) as Credito,Sum(Resultados.Bonos) as Bonos,Sum(Resultados.Permuta) as Permuta,Sum(Resultados.Otras) as Otras from (SELECT FacturaDatos.Fecha,Week(FacturaDatos.Fecha) as Semana,Day(FacturaDatos.Fecha) as Dia,Month(FacturaDatos.Fecha) as Mes,Quarter(FacturaDatos.Fecha) as Cuarto,Year(FacturaDatos.Fecha) as Ano,Sum(FacturaDatos.TotalNeto) as TotalNeto,Sum(Efectivo-Devuelta) as Efectivo,Sum(Cheque) as Cheque,Sum(Deposito) as Deposito,Sum(Tarjeta) as Tarjeta,Sum(Credito) as Credito,Sum(Bonos) as Bonos,Sum(Permuta) as Permuta,Sum(Otras) as Otras FROM Libregco.facturadatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and Condicion.Dias=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " Group By Date(FacturaDatos.Fecha) UNION ALL SELECT FacturaDatos.Fecha,Week(FacturaDatos.Fecha) as Semana,Day(FacturaDatos.Fecha) as Dia,Month(FacturaDatos.Fecha) as Mes,Quarter(FacturaDatos.Fecha) as Cuarto,Year(FacturaDatos.Fecha) as Ano,Sum(FacturaDatos.TotalNeto) as TotalNeto,Sum(Efectivo-Devuelta) as Efectivo,Sum(Cheque) as Cheque,Sum(Deposito) as Deposito,Sum(Tarjeta) as Tarjeta,Sum(Credito) as Credito,Sum(Bonos) as Bonos,Sum(Permuta) as Permuta,Sum(Otras) as Otras FROM Libregco_Main.facturadatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and Condicion.Dias=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " Group By Date(FacturaDatos.Fecha)) as Resultados Group By Date(Resultados.Fecha) Order By Resultados.Fecha ASC"
        ElseIf Value = 5 Then
            Return "Select Resultados.Fecha,Resultados.Semana,Resultados.Dia,Resultados.Mes,Resultados.Cuarto,Resultados.Ano,Sum(Resultados.TotalNeto) as TotalNeto,Sum(Resultados.Efectivo) as Efectivo,Sum(Resultados.Cheque) as Cheque,Sum(Resultados.Deposito) as Deposito,Sum(Resultados.Tarjeta) as Tarjeta,Sum(Resultados.Credito) as Credito,Sum(Resultados.Bonos) as Bonos,Sum(Resultados.Permuta) as Permuta,Sum(Resultados.Otras) as Otras from (SELECT FacturaDatos.Fecha,Week(FacturaDatos.Fecha) as Semana,Day(FacturaDatos.Fecha) as Dia,Month(FacturaDatos.Fecha) as Mes,Quarter(FacturaDatos.Fecha) as Cuarto,Year(FacturaDatos.Fecha) as Ano,Sum(FacturaDatos.TotalNeto) as TotalNeto,Sum(Efectivo-Devuelta) as Efectivo,Sum(Cheque) as Cheque,Sum(Deposito) as Deposito,Sum(Tarjeta) as Tarjeta,Sum(Credito) as Credito,Sum(Bonos) as Bonos,Sum(Permuta) as Permuta,Sum(Otras) as Otras FROM Libregco.facturadatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and Condicion.Dias=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & "  Group By concat(Week(FacturaDatos.Fecha),'/',Year(FacturaDatos.Fecha)) UNION ALL SELECT FacturaDatos.Fecha,Week(FacturaDatos.Fecha) as Semana,Day(FacturaDatos.Fecha) as Dia,Month(FacturaDatos.Fecha) as Mes,Quarter(FacturaDatos.Fecha) as Cuarto,Year(FacturaDatos.Fecha) as Ano,Sum(FacturaDatos.TotalNeto) as TotalNeto,Sum(Efectivo-Devuelta) as Efectivo,Sum(Cheque) as Cheque,Sum(Deposito) as Deposito,Sum(Tarjeta) as Tarjeta,Sum(Credito) as Credito,Sum(Bonos) as Bonos,Sum(Permuta) as Permuta,Sum(Otras) as Otras FROM Libregco_Main.facturadatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and Condicion.Dias=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & "  Group By concat(Week(FacturaDatos.Fecha),'/',Year(FacturaDatos.Fecha))) as Resultados Group By Date(Resultados.Fecha) Order By Resultados.Fecha ASC"
        ElseIf Value = 6 Then
            Return "Select Resultados.Fecha,Resultados.Semana,Resultados.Dia,Resultados.Mes,Resultados.Cuarto,Resultados.Ano,Sum(Resultados.TotalNeto) as TotalNeto,Sum(Resultados.Efectivo) as Efectivo,Sum(Resultados.Cheque) as Cheque,Sum(Resultados.Deposito) as Deposito,Sum(Resultados.Tarjeta) as Tarjeta,Sum(Resultados.Credito) as Credito,Sum(Resultados.Bonos) as Bonos,Sum(Resultados.Permuta) as Permuta,Sum(Resultados.Otras) as Otras from (SELECT FacturaDatos.Fecha,Week(FacturaDatos.Fecha) as Semana,Day(FacturaDatos.Fecha) as Dia,Month(FacturaDatos.Fecha) as Mes,Quarter(FacturaDatos.Fecha) as Cuarto,Year(FacturaDatos.Fecha) as Ano,Sum(FacturaDatos.TotalNeto) as TotalNeto,Sum(Efectivo-Devuelta) as Efectivo,Sum(Cheque) as Cheque,Sum(Deposito) as Deposito,Sum(Tarjeta) as Tarjeta,Sum(Credito) as Credito,Sum(Bonos) as Bonos,Sum(Permuta) as Permuta,Sum(Otras) as Otras FROM Libregco.facturadatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and Condicion.Dias=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " Group By concat(Month(FacturaDatos.Fecha),'/',Year(FacturaDatos.Fecha)) UNION ALL SELECT FacturaDatos.Fecha,Week(FacturaDatos.Fecha) as Semana,Day(FacturaDatos.Fecha) as Dia,Month(FacturaDatos.Fecha) as Mes,Quarter(FacturaDatos.Fecha) as Cuarto,Year(FacturaDatos.Fecha) as Ano,Sum(FacturaDatos.TotalNeto) as TotalNeto,Sum(Efectivo-Devuelta) as Efectivo,Sum(Cheque) as Cheque,Sum(Deposito) as Deposito,Sum(Tarjeta) as Tarjeta,Sum(Credito) as Credito,Sum(Bonos) as Bonos,Sum(Permuta) as Permuta,Sum(Otras) as Otras FROM Libregco_Main.facturadatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and Condicion.Dias=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & "  Group By concat(Month(FacturaDatos.Fecha),'/',Year(FacturaDatos.Fecha))) as Resultados Group By Date(Resultados.Fecha) Order By Resultados.Fecha ASC"

        ElseIf Value = 7 Then
            Return "Select Resultados.Fecha,Resultados.Semana,Resultados.Dia,Resultados.Mes,Resultados.Cuarto,Resultados.Ano,Sum(Resultados.TotalNeto) as TotalNeto,Sum(Resultados.Efectivo) as Efectivo,Sum(Resultados.Cheque) as Cheque,Sum(Resultados.Deposito) as Deposito,Sum(Resultados.Tarjeta) as Tarjeta,Sum(Resultados.Credito) as Credito,Sum(Resultados.Bonos) as Bonos,Sum(Resultados.Permuta) as Permuta,Sum(Resultados.Otras) as Otras from (SELECT FacturaDatos.Fecha,Week(FacturaDatos.Fecha) as Semana,Day(FacturaDatos.Fecha) as Dia,Month(FacturaDatos.Fecha) as Mes,Quarter(FacturaDatos.Fecha) as Cuarto,Year(FacturaDatos.Fecha) as Ano,Sum(FacturaDatos.TotalNeto) as TotalNeto,Sum(Efectivo-Devuelta) as Efectivo,Sum(Cheque) as Cheque,Sum(Deposito) as Deposito,Sum(Tarjeta) as Tarjeta,Sum(Credito) as Credito,Sum(Bonos) as Bonos,Sum(Permuta) as Permuta,Sum(Otras) as Otras FROM Libregco.facturadatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and Condicion.Dias=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " Group By concat(Quarter(FacturaDatos.Fecha),'/',Year(FacturaDatos.Fecha)) UNION ALL SELECT FacturaDatos.Fecha,Week(FacturaDatos.Fecha) as Semana,Day(FacturaDatos.Fecha) as Dia,Month(FacturaDatos.Fecha) as Mes,Quarter(FacturaDatos.Fecha) as Cuarto,Year(FacturaDatos.Fecha) as Ano,Sum(FacturaDatos.TotalNeto) as TotalNeto,Sum(Efectivo-Devuelta) as Efectivo,Sum(Cheque) as Cheque,Sum(Deposito) as Deposito,Sum(Tarjeta) as Tarjeta,Sum(Credito) as Credito,Sum(Bonos) as Bonos,Sum(Permuta) as Permuta,Sum(Otras) as Otras FROM Libregco_Main.facturadatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and Condicion.Dias=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & "  Group By concat(Quarter(FacturaDatos.Fecha),'/',Year(FacturaDatos.Fecha))) as Resultados Group By Date(Resultados.Fecha) Order By Resultados.Fecha ASC"

        ElseIf Value = 8 Then
            Return "Select Resultados.Fecha,Resultados.Semana,Resultados.Dia,Resultados.Mes,Resultados.Cuarto,Resultados.Ano,Sum(Resultados.TotalNeto) as TotalNeto,Sum(Resultados.Efectivo) as Efectivo,Sum(Resultados.Cheque) as Cheque,Sum(Resultados.Deposito) as Deposito,Sum(Resultados.Tarjeta) as Tarjeta,Sum(Resultados.Credito) as Credito,Sum(Resultados.Bonos) as Bonos,Sum(Resultados.Permuta) as Permuta,Sum(Resultados.Otras) as Otras from (SELECT FacturaDatos.Fecha,Week(FacturaDatos.Fecha) as Semana,Day(FacturaDatos.Fecha) as Dia,Month(FacturaDatos.Fecha) as Mes,Quarter(FacturaDatos.Fecha) as Cuarto,Year(FacturaDatos.Fecha) as Ano,Sum(FacturaDatos.TotalNeto) as TotalNeto,Sum(Efectivo-Devuelta) as Efectivo,Sum(Cheque) as Cheque,Sum(Deposito) as Deposito,Sum(Tarjeta) as Tarjeta,Sum(Credito) as Credito,Sum(Bonos) as Bonos,Sum(Permuta) as Permuta,Sum(Otras) as Otras FROM Libregco.facturadatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and Condicion.Dias=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " Group By Year(FacturaDatos.Fecha) UNION ALL SELECT FacturaDatos.Fecha,Week(FacturaDatos.Fecha) as Semana,Day(FacturaDatos.Fecha) as Dia,Month(FacturaDatos.Fecha) as Mes,Quarter(FacturaDatos.Fecha) as Cuarto,Year(FacturaDatos.Fecha) as Ano,Sum(FacturaDatos.TotalNeto) as TotalNeto,Sum(Efectivo-Devuelta) as Efectivo,Sum(Cheque) as Cheque,Sum(Deposito) as Deposito,Sum(Tarjeta) as Tarjeta,Sum(Credito) as Credito,Sum(Bonos) as Bonos,Sum(Permuta) as Permuta,Sum(Otras) as Otras FROM Libregco_Main.facturadatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and Condicion.Dias=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & "  Group By Year(FacturaDatos.Fecha)) as Resultados Group By Date(Resultados.Fecha) Order By Resultados.Fecha ASC"

        Else
            Return "Select Resultados.Fecha,Resultados.Semana,Resultados.Dia,Resultados.Mes,Resultados.Cuarto,Resultados.Ano,Sum(Resultados.TotalNeto) as TotalNeto,Sum(Resultados.Efectivo) as Efectivo,Sum(Resultados.Cheque) as Cheque,Sum(Resultados.Deposito) as Deposito,Sum(Resultados.Tarjeta) as Tarjeta,Sum(Resultados.Credito) as Credito,Sum(Resultados.Bonos) as Bonos,Sum(Resultados.Permuta) as Permuta,Sum(Resultados.Otras) as Otras from (SELECT FacturaDatos.Fecha,Week(FacturaDatos.Fecha) as Semana,Day(FacturaDatos.Fecha) as Dia,Month(FacturaDatos.Fecha) as Mes,Quarter(FacturaDatos.Fecha) as Cuarto,Year(FacturaDatos.Fecha) as Ano,Sum(FacturaDatos.TotalNeto) as TotalNeto,Sum(Efectivo-Devuelta) as Efectivo,Sum(Cheque) as Cheque,Sum(Deposito) as Deposito,Sum(Tarjeta) as Tarjeta,Sum(Credito) as Credito,Sum(Bonos) as Bonos,Sum(Permuta) as Permuta,Sum(Otras) as Otras FROM Libregco.facturadatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and Condicion.Dias=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " Group By Date(FacturaDatos.Fecha) UNION ALL SELECT FacturaDatos.Fecha,Week(FacturaDatos.Fecha) as Semana,Day(FacturaDatos.Fecha) as Dia,Month(FacturaDatos.Fecha) as Mes,Quarter(FacturaDatos.Fecha) as Cuarto,Year(FacturaDatos.Fecha) as Ano,Sum(FacturaDatos.TotalNeto) as TotalNeto,Sum(Efectivo-Devuelta) as Efectivo,Sum(Cheque) as Cheque,Sum(Deposito) as Deposito,Sum(Tarjeta) as Tarjeta,Sum(Credito) as Credito,Sum(Bonos) as Bonos,Sum(Permuta) as Permuta,Sum(Otras) as Otras FROM Libregco_Main.facturadatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and Condicion.Dias=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " Group By Date(FacturaDatos.Fecha)) as Resultados Group By Date(Resultados.Fecha) Order By Resultados.Fecha ASC"
        End If
    End Function


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        GetVentasDiarias()
        GetVentasBeneficios()
        GetVentasPastel()
        GetArticulosmasVendidos()

        If XTabVentas.SelectedTabPageIndex = 1 Then
            GetVentasComparativas()
        ElseIf XTabVentas.SelectedTabPageIndex = 2 Then
            GetIngresosVsGastos()
        End If

    End Sub

    Private Sub GetVentasBeneficios()
        GridBeneficios.Columns.Clear()
        GridBeneficios.GroupSummary.Clear()

        NavBarControl2.ActiveGroup = NavFacturas

        Dim RepositorySecondID As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}
        Dim RepositoryCostoVenta As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Dim RepositoryTotalNeto As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Dim RepositoryBeneficioMonetario As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Dim RepositoryBeneficioPorcentual As New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()

        RepositoryCostoVenta.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryCostoVenta.Mask.EditMask = "c"
        RepositoryCostoVenta.Mask.UseMaskAsDisplayFormat = True
        RepositoryCostoVenta.NullText = CDbl(0).ToString("C")
        RepositoryCostoVenta.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryTotalNeto.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryTotalNeto.Mask.EditMask = "c"
        RepositoryTotalNeto.Mask.UseMaskAsDisplayFormat = True
        RepositoryTotalNeto.NullText = CDbl(0).ToString("C")
        RepositoryTotalNeto.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryBeneficioMonetario.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryBeneficioMonetario.Mask.EditMask = "c"
        RepositoryBeneficioMonetario.Mask.UseMaskAsDisplayFormat = True
        RepositoryBeneficioMonetario.NullText = CDbl(0).ToString("C")
        RepositoryBeneficioMonetario.NullValuePromptShowForEmptyValue = CDbl(0).ToString("C")

        RepositoryBeneficioPorcentual.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        RepositoryBeneficioPorcentual.Mask.EditMask = "P"
        RepositoryBeneficioPorcentual.Mask.UseMaskAsDisplayFormat = True
        RepositoryBeneficioPorcentual.NullText = CDbl(0).ToString("P")


        Dim TablaDatos As DataTable = New DataTable("Datos")
        TablaDatos.Columns.Add("IDFacturaDatos", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("SecondID", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
        TablaDatos.Columns.Add("CostoVenta", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("TotalNeto", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("BeneficioMonetario", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("BeneficioPorcentual", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("DB", System.Type.GetType("System.String"))

        GridVentasBeneficios.DataSource = TablaDatos
        GridBeneficios.Columns("SecondID").ColumnEdit = RepositorySecondID
        GridBeneficios.Columns("CostoVenta").ColumnEdit = RepositoryCostoVenta
        GridBeneficios.Columns("TotalNeto").ColumnEdit = RepositoryTotalNeto
        GridBeneficios.Columns("BeneficioMonetario").ColumnEdit = RepositoryBeneficioMonetario
        GridBeneficios.Columns("BeneficioPorcentual").ColumnEdit = RepositoryBeneficioPorcentual
        GridBeneficios.Columns("DB").Visible = False


        GridBeneficios.Columns(0).Visible = False

        TablaDatos.Clear()
        Using ConMixta As MySqlConnection = New MySqlConnection(CnString)
            Using mycommand As MySqlCommand = New MySqlCommand("Select FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.Fecha,sum(CostoImporte) as CostoVenta,FacturaDatos.TotalNeto,coalesce((FacturaDatos.TotalNeto-sum(FacturaArticulos.CostoImporte)),0) as BeneficioMonetario,coalesce(((FacturaDatos.TotalNeto-sum(FacturaArticulos.CostoImporte))/sum(FacturaArticulos.CostoImporte)),0)*100 as BeneficioPorcentual,' Libregco.' as DB from Libregco.FacturaDatos INNER JOIN Libregco.FacturaArticulos on FacturaDatos.IDFacturaDatos=FacturaArticulos.IDFactura INNER JOIN Libregco.PrecioArticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and Condicion.Dias=0 and FacturaDatos.Nulo=0 and FacturaArticulos.CostoImporte>0 GRoup By FacturaDatos.IDFacturaDatos UNION ALL Select FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.Fecha,sum(CostoImporte) as CostoVenta,FacturaDatos.TotalNeto,coalesce((FacturaDatos.TotalNeto-sum(FacturaArticulos.CostoImporte)),0) as BeneficioMonetario,coalesce(((FacturaDatos.TotalNeto-sum(FacturaArticulos.CostoImporte))/sum(FacturaArticulos.CostoImporte)),0)*100 as BeneficioPorcentual,' Libregco_Main.' as DB from Libregco_Main.FacturaDatos INNER JOIN Libregco_Main.FacturaArticulos on FacturaDatos.IDFacturaDatos=FacturaArticulos.IDFactura INNER JOIN Libregco.PrecioArticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "'" & If(CBool(chkTodos.EditValue) = True, "", " AND FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'") & " and Condicion.Dias=0 and FacturaDatos.Nulo=0 and FacturaArticulos.CostoImporte>0 GRoup By FacturaDatos.IDFacturaDatos ", ConMixta)
                ConMixta.Open()
                Using myReader As MySqlDataReader = mycommand.ExecuteReader
                    TablaDatos.Load(myReader, LoadOption.Upsert)
                    ConMixta.Close()
                End Using
            End Using
        End Using
        TablaDatos.EndLoadData()

        GridBeneficios.Columns("Fecha").GroupIndex = 0

        GridBeneficios.BestFitColumns()

        GridBeneficios.Columns(0).Visible = False
        GridBeneficios.Columns(1).Caption = "Documento"
        GridBeneficios.Columns(1).Width = 100
        GridBeneficios.Columns(2).DisplayFormat.FormatType = FormatType.DateTime
        GridBeneficios.Columns(2).DisplayFormat.FormatString = "dd/MMM "
        GridBeneficios.Columns(3).Visible = False
        GridBeneficios.Columns(4).Visible = False
        GridBeneficios.Columns(5).Caption = "$ Ingresos"
        GridBeneficios.Columns(5).DisplayFormat.FormatType = FormatType.Numeric
        GridBeneficios.Columns(5).DisplayFormat.FormatString = "C2"
        GridBeneficios.Columns(5).Width = 85
        GridBeneficios.Columns(6).Caption = "% Margen"
        GridBeneficios.Columns(6).DisplayFormat.FormatString = "P"
        GridBeneficios.Columns(6).DisplayFormat.FormatType = FormatType.Numeric
        GridBeneficios.Columns(6).Width = 70

        GridBeneficios.Columns("CostoVenta").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "CostoVenta", "{0:c2}")
        GridBeneficios.Columns("TotalNeto").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalNeto", "{0:c2}")
        GridBeneficios.Columns("BeneficioMonetario").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "BeneficioMonetario", "{0:c2}")

        lblCantidadVentas.Text = TablaDatos.Rows.Count

        Dim Porc As Double = 0

        For Each rw As DataRow In TablaDatos.Rows
            Porc += (CDbl(rw.Item("BeneficioPorcentual")) / 100)
        Next

        lblBeneficioPromedioGeneral.Text = CDbl(Porc / CDbl(TablaDatos.Rows.Count)).ToString("P")
        lblAVGRendimiento.Text = CDbl(CDbl(GridBeneficios.Columns("BeneficioMonetario").SummaryItem.SummaryValue) / CDbl(TablaDatos.Rows.Count)).ToString("C")
        lblAVGventas.Text = CDbl(CDbl(GridBeneficios.Columns("TotalNeto").SummaryItem.SummaryValue) / CDbl(TablaDatos.Rows.Count)).ToString("C")

    End Sub


    Private Sub GetVentasPastel()
        With GraficoParticipacionVentas
            .DataSource = Nothing
            .Titles.Clear()
            .Series.Clear()
            .SeriesTemplate.ArgumentDataMember = ""
            .Legends.Clear()
            .ClearCache()
            .ClearSelection()
        End With

        Dim TablaDatos As DataTable = New DataTable("Datos")
        TablaDatos.Columns.Add("IDVendedor", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Nombre", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("TotalVendido", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("TotalGeneralPeriodo", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("Porcentaje", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("CantidadFacturasVendedor", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("CantidadFacturas", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("RankVentas", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("RankCantidad", System.Type.GetType("System.String"))


        TablaDatos.Clear()
        Using ConMixta As MySqlConnection = New MySqlConnection(CnString)
            Using myCommand As MySqlCommand = New MySqlCommand("Select Resultados.IDVendedor,Resultados.Nombre,Sum(Resultados.TotalVendido) as TotalVendido,Sum(Resultados.TotalGeneralPeriodo) as TotalGeneralPeriodo,(Resultados.TotalVendido/Resultados.TotalGeneralPeriodo) AS Porcentaje,Sum(CantidadFacturasVendedor) as CantidadFacturasVendedor,Sum(Resultados.CantidadFacturas) as CantidadFacturas from (Select FacturaDatos.IDVendedor,Empleados.Nombre,Sum(FacturaDatos.TotalNeto) as TotalVendido,(Select sum(FacturaDatos.TotalNeto) from Libregco.FacturaDatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' and Condicion.Dias=0) as TotalGeneralPeriodo,(Sum(FacturaDatos.TotalNeto)/(Select sum(FacturaDatos.TotalNeto) from Libregco.FacturaDatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCOndicion Where FacturaDatos.Nulo=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' and Condicion.Dias=0)) as Porcentaje,Count(FacturaDatos.IDFacturaDatos) as CantidadFacturasVendedor,(Select count(FacturaDatos.IDFacturaDatos) from Libregco.FacturaDatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' and Condicion.Dias=0 and FacturaDatos.Nulo=0) as CantidadFacturas from Libregco.FacturaDatos INNER JOIN Libregco.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' and Condicion.Dias=0 and FacturaDatos.Nulo=0 GRoup By FacturaDatos.IDVendedor UNION ALL  Select FacturaDatos.IDVendedor,Empleados.Nombre,Sum(FacturaDatos.TotalNeto) as TotalVendido,(Select sum(FacturaDatos.TotalNeto) from Libregco_Main.FacturaDatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCOndicion Where FacturaDatos.Nulo=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' and Condicion.Dias=0) as TotalGeneralPeriodo,(Sum(FacturaDatos.TotalNeto)/(Select sum(FacturaDatos.TotalNeto) from Libregco_Main.FacturaDatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCOndicion Where FacturaDatos.Nulo=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' and Condicion.Dias=0)) as Porcentaje,Count(FacturaDatos.IDFacturaDatos) as CantidadFacturasVendedor,(Select count(FacturaDatos.IDFacturaDatos) from Libregco_Main.FacturaDatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' and Condicion.Dias=0 and FacturaDatos.Nulo=0) as CantidadFacturas from Libregco_Main.FacturaDatos INNER JOIN Libregco_Main.Empleados on FacturaDatos.IDVendedor=Empleados.IDEmpleado INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion WHERE FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' and Condicion.Dias=0 and FacturaDatos.Nulo=0 GRoup By FacturaDatos.IDVendedor) as Resultados Group by Resultados.IDVendedor ORDER BY Resultados.Porcentaje DESC", ConMixta)
                ConMixta.Open()
                Using myReader As MySqlDataReader = myCommand.ExecuteReader
                    TablaDatos.Load(myReader, LoadOption.Upsert)
                    ConMixta.Close()
                End Using
            End Using
        End Using
        TablaDatos.EndLoadData()

        If TablaDatos.Rows.Count > 0 Then
            Dim series1 As New Series("Ventas", ViewType.Pie)

            Dim legend1 As New Legend("Porcentajes")
            legend1.AlignmentHorizontal = LegendAlignmentHorizontal.Center
            legend1.AlignmentVertical = LegendAlignmentVertical.Bottom
            legend1.Direction = LegendDirection.LeftToRight
            series1.LegendText = series1.ArgumentDataMember

            GraficoParticipacionVentas.Legends.Add(legend1)
            GraficoParticipacionVentas.Series.Add(series1)

            Dim titles1 As New ChartTitle()
            titles1.Text = "Participación en ventas durante período"
            titles1.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            titles1.Alignment = StringAlignment.Near
            GraficoParticipacionVentas.Titles.Add(titles1)

            For Each itm As DataRow In TablaDatos.Rows
                series1.Points.Add(New SeriesPoint(itm.Item("Nombre"), CDbl(itm.Item("Porcentaje"))))
            Next

            'ChartControl2.Series(0).LegendTextPattern = "{a} {V:0.00%}"
            GraficoParticipacionVentas.Series(0).Label.TextPattern = "{v:0.00%}"
            GraficoParticipacionVentas.Series(0).LegendTextPattern = "{a}"

            If chkTodos.Checked = False Then
                'Determinar posiciones de ventas

                'Determinando posicion sobre montos
                TablaDatos.DefaultView.Sort = "TotalVendido DESC"
                TablaDatos = TablaDatos.DefaultView.ToTable

                For Each rw As DataRow In TablaDatos.Rows
                    rw.Item("RankVentas") = TablaDatos.Rows.IndexOf(rw) + 1 & GetOrdinal(TablaDatos.Rows.IndexOf(rw) + 1)

                    If rw.Item("IDVendedor").ToString = PicFoto.Tag.ToString Then
                        lblLugarVenta.Text = rw.Item("RankVentas").ToString
                    End If
                Next

                'Determinando posicion sobre cantidad
                TablaDatos.DefaultView.Sort = "CantidadFacturasVendedor DESC"
                TablaDatos = TablaDatos.DefaultView.ToTable

                For Each rw As DataRow In TablaDatos.Rows
                    rw.Item("RankCantidad") = TablaDatos.Rows.IndexOf(rw) + 1 & GetOrdinal(TablaDatos.Rows.IndexOf(rw) + 1)

                    If rw.Item("IDVendedor").ToString = PicFoto.Tag.ToString Then
                        lblLugarCantidadVentas.Text = rw.Item("RankCantidad").ToString
                    End If
                Next

                'Determinando posicion sobre montos
                TablaDatos.DefaultView.Sort = "TotalVendido DESC"
                TablaDatos = TablaDatos.DefaultView.ToTable

                GcParticipacionVentas.DataSource = TablaDatos

                GvParticipacionVentas.Columns("IDVendedor").Visible = False
                GvParticipacionVentas.Columns("TotalGeneralPeriodo").Visible = False
                GvParticipacionVentas.Columns("TotalGeneralPeriodo").DisplayFormat.FormatType = FormatType.Numeric
                GvParticipacionVentas.Columns("TotalGeneralPeriodo").DisplayFormat.FormatString = "C"
                GvParticipacionVentas.Columns("TotalVendido").DisplayFormat.FormatType = FormatType.Numeric
                GvParticipacionVentas.Columns("TotalVendido").DisplayFormat.FormatString = "C"
                GvParticipacionVentas.Columns("TotalVendido").Caption = "Total de ventas"
                GvParticipacionVentas.Columns("Porcentaje").DisplayFormat.FormatType = FormatType.Numeric
                GvParticipacionVentas.Columns("Porcentaje").DisplayFormat.FormatString = "P"
                GvParticipacionVentas.Columns("CantidadFacturas").Visible = False
                GvParticipacionVentas.Columns("CantidadFacturasVendedor").Caption = "Cant. Facts."
            End If




        End If




        'If IDPrivilegio = 3 Then
        '    ChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False
        '    chkTodos.Visible = False
        'End If


    End Sub

    Private Sub GetArticulosmasVendidos()
        Dim dstmp As New DataSet

        GridView3.Columns.Clear()
        GridView3.GroupSummary.Clear()

        With GraficoArticulosMasVendidos
            .DataSource = Nothing
            .Titles.Clear()
            .Series.Clear()
            .SeriesTemplate.ArgumentDataMember = ""
            .Legends.Clear()
            .ClearCache()
            .ClearSelection()
        End With

        Dim TablaDatos As DataTable = New DataTable("Datos")
        TablaDatos.Columns.Add("IDPrecio", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Medida", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Cantidad", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Referencia", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("PrecioVentaPromedio", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("MontoVendidoArticuloPeriodo", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("VentasTotalesdelPeriodo", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("PorcentajeArticuloenVentas", System.Type.GetType("System.Double"))


        'Consigo los datos de las ventas
        Using ConMixta As MySqlConnection = New MySqlConnection(CnString)
            Using mycommand As MySqlCommand = New MySqlCommand("Select Resultados.IDPrecio,Resultados.IDArticulo,Sum(Resultados.Cantidad) as Cantidad,Resultados.Descripcion,Resultados.Referencia,Resultados.Medida,Sum(Resultados.PrecioVentaPromedio)/2 as PrecioVentaPromedio,Sum(Resultados.MontoVendidoArticuloPeriodo) as MontoVendidoArticuloPeriodo,(Select Sum(FacturaDatos.TotalNeto) from Libregco.FacturaDatos Where FacturaDatos.Nulo=0 And FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' " & If(chkTodos.Checked = False, " and FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'", "") & ")+(Select Sum(FacturaDatos.TotalNeto) from Libregco_Main.FacturaDatos Where FacturaDatos.Nulo=0 And FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' " & If(chkTodos.Checked = False, " and FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'", "") & ") as VentasTotalesdelPeriodo,(Sum(Resultados.MontoVendidoArticuloPeriodo)/Sum(Resultados.VentasTotalesdelPeriodo)) As PorcentajeArticuloenVentas from ((Select FacturaArticulos.IDPrecio,FacturaArticulos.IDArticulo,Sum(Cantidad) As Cantidad,Articulos.Descripcion,Articulos.Referencia,Medida.Medida,Round((Sum(FacturaArticulos.Importe)/Sum(Cantidad)),2) As PrecioVentaPromedio,Sum(FacturaArticulos.Importe) As MontoVendidoArticuloPeriodo,(Select Sum(FacturaDatos.TotalNeto) from Libregco.FacturaDatos Where FacturaDatos.Nulo=0 And FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' " & If(chkTodos.Checked = False, " and FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'", "") & ") as VentasTotalesdelPeriodo,Sum(FacturaArticulos.Importe)/(Select Sum(FacturaDatos.TotalNeto) from Libregco.FacturaDatos  Where FacturaDatos.Nulo=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' " & If(chkTodos.Checked = False, " and FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'", "") & ") as PorcentajeArticuloenVentas FROM libregco.facturaarticulos INNER JOIN Libregco.FacturaDatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos  INNER JOIN Libregco.PrecioArticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos  on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where FacturaArticulos.IDArticulo<>1 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' " & If(chkTodos.Checked = False, " and FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'", "") & " GROUP BY FacturaArticulos.IDPrecio ORDER BY Sum(FacturaArticulos.Importe) DESC LIMIT 10) UNION ALL (SELECT FacturaArticulos.IDPrecio,FacturaArticulos.IDArticulo,Sum(Cantidad) as Cantidad,Articulos.Descripcion,Articulos.Referencia,Medida.Medida,Round((Sum(FacturaArticulos.Importe)/Sum(Cantidad)),2) as PrecioVentaPromedio,Sum(FacturaArticulos.Importe) as MontoVendidoArticuloPeriodo,(Select Sum(FacturaDatos.TotalNeto) from Libregco_Main.FacturaDatos  Where FacturaDatos.Nulo=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' " & If(chkTodos.Checked = False, " and FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'", "") & ") as VentasTotalesdelPeriodo,Sum(FacturaArticulos.Importe)/(Select Sum(FacturaDatos.TotalNeto) from libregco_MAIN.FacturaDatos  Where FacturaDatos.Nulo=0 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' " & If(chkTodos.Checked = False, " and FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'", "") & ") as PorcentajeArticuloenVentas FROM libregco_MAIN.facturaarticulos INNER JOIN libregco_MAIN.FacturaDatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.PrecioArticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos  on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where FacturaArticulos.IDArticulo<>1 and FacturaDatos.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' " & If(chkTodos.Checked = False, " and FacturaDatos.IDVendedor='" + PicFoto.Tag.ToString + "'", "") & " GROUP BY FacturaArticulos.IDPrecio ORDER BY Sum(FacturaArticulos.Importe) DESC LIMIT 10)) as Resultados GROUP BY Resultados.IDPrecio ORDER BY Resultados.MontoVendidoArticuloPeriodo DESC LIMIT 10", ConMixta)
                ConMixta.Open()
                Using myReader As MySqlDataReader = mycommand.ExecuteReader
                    TablaDatos.Load(myReader, LoadOption.Upsert)
                    ConMixta.Close()
                End Using
            End Using
        End Using
        TablaDatos.EndLoadData()

        GridControl3.DataSource = TablaDatos

        GridView3.BestFitColumns()

        Dim titles1 As New ChartTitle()

        titles1.Text = "Artículos más vendidos"
        titles1.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        titles1.Alignment = StringAlignment.Near
        GraficoArticulosMasVendidos.Titles.Add(titles1)

        Dim series1 As New Series("Artículos", ViewType.Bar)
        CType(series1.View, BarSeriesView).ColorEach = True

        GraficoArticulosMasVendidos.Series.Add(series1)
        GraficoArticulosMasVendidos.Series(0).ValueScaleType = ScaleType.Numerical
        GraficoArticulosMasVendidos.Series(0).ArgumentScaleType = ScaleType.Qualitative


        GraficoArticulosMasVendidos.Series(0).Points.Clear()
        For Each rw As DataRow In TablaDatos.Rows
            GraficoArticulosMasVendidos.Series(0).Points.Add(New SeriesPoint(rw.Item("Medida") & "/ " & rw.Item("Descripcion"), CDbl(rw.Item("Cantidad"))))
        Next

        'ChartControl3.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.LeftOutside
        'ChartControl3.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside
        'ChartControl3.Legend.Direction = LegendDirection.LeftToRight

        GridView3.Columns("IDPrecio").Visible = False
        GridView3.Columns("IDArticulo").Visible = False
        GridView3.Columns("Descripcion").Caption = "Descripción"
        GridView3.Columns("Cantidad").Caption = "Vendidos"
        GridView3.Columns("PrecioVentaPromedio").Caption = "Precio Prom."
        GridView3.Columns("PrecioVentaPromedio").DisplayFormat.FormatType = FormatType.Numeric
        GridView3.Columns("PrecioVentaPromedio").DisplayFormat.FormatString = "n"
        GridView3.Columns("VentasTotalesdelPeriodo").Visible = False
        GridView3.Columns("MontoVendidoArticuloPeriodo").Caption = "Total vendido"
        GridView3.Columns("MontoVendidoArticuloPeriodo").DisplayFormat.FormatType = FormatType.Numeric
        GridView3.Columns("MontoVendidoArticuloPeriodo").DisplayFormat.FormatString = "C2"
        GridView3.Columns("PorcentajeArticuloenVentas").Caption = "% (del Total de ventas)"
        GridView3.Columns("PorcentajeArticuloenVentas").DisplayFormat.FormatType = FormatType.Numeric
        GridView3.Columns("PorcentajeArticuloenVentas").DisplayFormat.FormatString = "P"

        GridView3.Columns("MontoVendidoArticuloPeriodo").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "MontoVendidoArticuloPeriodo", "{0:c2}")
        GridView3.Columns("PorcentajeArticuloenVentas").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "PorcentajeArticuloenVentas", "{0:p2}")

        Dim xyDiagram As XYDiagram = CType(GraficoArticulosMasVendidos.Diagram, XYDiagram)
        xyDiagram.EnableAxisXZooming = True
        xyDiagram.EnableAxisYZooming = True

        dstmp.Dispose()
    End Sub


    Public Function GetOrdinal(ByVal Number As Integer) As String
        ' Accepts an integer, returns the ordinal suffix

        ' Handles special case three digit numbers ending
        ' with 11, 12 or 13 - ie, 111th, 112th, 113th, 211th, et al
        If CType(Number, String).Length > 2 Then
            Dim intEndNum As Integer = CType(CType(Number, String).
                Substring(CType(Number, String).Length - 2, 2), Integer)
            If intEndNum >= 11 And intEndNum <= 13 Then
                Select Case intEndNum
                    Case 11, 12, 13
                        Return "th"
                End Select
            End If
        End If
        If Number >= 21 Then
            ' Handles 21st, 22nd, 23rd, et al
            Select Case CType(Number.ToString.Substring(
                Number.ToString.Length - 1, 1), Integer)
                Case 1
                    Return "st"
                Case 2
                    Return "nd"
                Case 3
                    Return "rd"
                Case 0, 4 To 9
                    Return "th"
            End Select
        Else
            ' Handles 1st to 20th
            Select Case Number
                Case 1
                    Return "st"
                Case 2
                    Return "nd"
                Case 3
                    Return "rd"
                Case 4 To 20
                    Return "th"
            End Select
        End If
    End Function


    Private Sub GridView4_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridBeneficios.RowCellClick
        Try
            If GridBeneficios.FocusedRowHandle >= 0 Then

                If GridBeneficios.FocusedColumn.FieldName = "SecondID" Then
                    GvArticulosBeneficios.Columns.Clear()
                    GvArticulosBeneficios.GroupSummary.Clear()

                    Dim TablaArticulos As DataTable = New DataTable("Articulos")
                    TablaArticulos.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
                    TablaArticulos.Columns.Add("Cantidad", System.Type.GetType("System.Double"))
                    TablaArticulos.Columns.Add("Medida", System.Type.GetType("System.String"))
                    TablaArticulos.Columns.Add("Descripcion", System.Type.GetType("System.String"))
                    TablaArticulos.Columns.Add("Importe", System.Type.GetType("System.Double"))
                    TablaArticulos.Columns.Add("CostoImporte", System.Type.GetType("System.Double"))
                    TablaArticulos.Columns.Add("Ingresos", System.Type.GetType("System.Double"))
                    TablaArticulos.Columns.Add("Margen", System.Type.GetType("System.Double"))

                    GcArticulosBeneficios.DataSource = TablaArticulos

                    GvArticulosBeneficios.Columns("IDArticulo").Caption = "Código"
                    GvArticulosBeneficios.Columns("IDArticulo").Visible = False
                    GvArticulosBeneficios.Columns("Cantidad").DisplayFormat.FormatType = FormatType.Numeric
                    GvArticulosBeneficios.Columns("Cantidad").DisplayFormat.FormatString = "n"
                    GvArticulosBeneficios.Columns("Cantidad").Width = 80
                    GvArticulosBeneficios.Columns("Descripcion").Caption = "Descripción"
                    GvArticulosBeneficios.Columns("Descripcion").Width = 220
                    GvArticulosBeneficios.Columns("Importe").DisplayFormat.FormatType = FormatType.Numeric
                    GvArticulosBeneficios.Columns("Importe").DisplayFormat.FormatString = "C2"
                    GvArticulosBeneficios.Columns("CostoImporte").Caption = "Costo total"
                    GvArticulosBeneficios.Columns("CostoImporte").DisplayFormat.FormatType = FormatType.Numeric
                    GvArticulosBeneficios.Columns("CostoImporte").DisplayFormat.FormatString = "C2"
                    GvArticulosBeneficios.Columns("CostoImporte").Width = 100
                    GvArticulosBeneficios.Columns("Ingresos").DisplayFormat.FormatType = FormatType.Numeric
                    GvArticulosBeneficios.Columns("Ingresos").DisplayFormat.FormatString = "C2"
                    GvArticulosBeneficios.Columns("Ingresos").Width = 100
                    GvArticulosBeneficios.Columns("Margen").Caption = "%"
                    GvArticulosBeneficios.Columns("Margen").DisplayFormat.FormatType = FormatType.Numeric
                    GvArticulosBeneficios.Columns("Margen").DisplayFormat.FormatString = "p"
                    GvArticulosBeneficios.Columns("Margen").Width = 60

                    GvArticulosBeneficios.Columns("Importe").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:c2}")
                    GvArticulosBeneficios.Columns("CostoImporte").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "CostoImporte", "{0:c2}")
                    GvArticulosBeneficios.Columns("Ingresos").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Ingresos", "{0:c2}")

                    'Consigo los datos de las ventas
                    Using ConMixta As MySqlConnection = New MySqlConnection(CnString)
                        Using myCommand As MySqlCommand = New MySqlCommand("SELECT FacturaArticulos.IDArticulo,Cantidad,Medida.Medida,Descripcion,Importe,CostoImporte,(Importe-CostoImporte) as Ingresos,((Importe-CostoImporte)/CostoImporte) as Margen FROM" & GridBeneficios.GetFocusedRowCellValue("DB").ToString & "facturaarticulos INNER JOIN Libregco.PrecioArticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida WHERE FacturaArticulos.IDFactura='" + GridBeneficios.GetFocusedRowCellValue("IDFacturaDatos").ToString + "'", ConMixta)
                            ConMixta.Open()
                            Using myReader As MySqlDataReader = myCommand.ExecuteReader
                                TablaArticulos.Load(myReader, LoadOption.Upsert)
                                ConMixta.Close()
                            End Using
                        End Using
                    End Using
                    TablaArticulos.EndLoadData()

                    GcArticulosBeneficios.DataSource = TablaArticulos

                    NavBarControl2.ActiveGroup = NavArticulos
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        PicFoto.Enabled = Not chkTodos.Checked

    End Sub

    Private Sub GetVentasComparativas()
        Dim dstmp As New DataSet
        GvVentasPeriodos.Columns.Clear()
        GvVentasPeriodos.GroupSummary.Clear()

        With GraficoComparacionPeriodos
            .DataSource = Nothing
            .Titles.Clear()
            .Series.Clear()
            .SeriesTemplate.ArgumentDataMember = ""
            .Legends.Clear()
            .ClearCache()
            .ClearSelection()
        End With

        Dim TablaDatos As DataTable = New DataTable("Datos")
        TablaDatos.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
        TablaDatos.Columns.Add("Semana", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Dia", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Mes", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Cuarto", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Ano", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("TotalNeto", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("Efectivo", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("Cheque", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("Deposito", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("Tarjeta", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("Credito", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("Bonos", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("Permuta", System.Type.GetType("System.Double"))
        TablaDatos.Columns.Add("Otras", System.Type.GetType("System.Double"))

        GcVentasPeriodos.DataSource = TablaDatos

        GvVentasPeriodos.Columns("Semana").Visible = False
        GvVentasPeriodos.Columns("Dia").Visible = False
        GvVentasPeriodos.Columns("Mes").Visible = False
        GvVentasPeriodos.Columns("Cuarto").Visible = False
        GvVentasPeriodos.Columns("Ano").Visible = False

        GvVentasPeriodos.Columns("TotalNeto").DisplayFormat.FormatType = FormatType.Numeric
        GvVentasPeriodos.Columns("TotalNeto").DisplayFormat.FormatString = "C"

        GvVentasPeriodos.Columns("Efectivo").DisplayFormat.FormatType = FormatType.Numeric
        GvVentasPeriodos.Columns("Efectivo").DisplayFormat.FormatString = "C"

        GvVentasPeriodos.Columns("Cheque").DisplayFormat.FormatType = FormatType.Numeric
        GvVentasPeriodos.Columns("Cheque").DisplayFormat.FormatString = "C"

        GvVentasPeriodos.Columns("Deposito").DisplayFormat.FormatType = FormatType.Numeric
        GvVentasPeriodos.Columns("Deposito").DisplayFormat.FormatString = "C"

        GvVentasPeriodos.Columns("Tarjeta").DisplayFormat.FormatType = FormatType.Numeric
        GvVentasPeriodos.Columns("Tarjeta").DisplayFormat.FormatString = "C"

        GvVentasPeriodos.Columns("Credito").DisplayFormat.FormatType = FormatType.Numeric
        GvVentasPeriodos.Columns("Credito").DisplayFormat.FormatString = "C"

        GvVentasPeriodos.Columns("Bonos").DisplayFormat.FormatType = FormatType.Numeric
        GvVentasPeriodos.Columns("Bonos").DisplayFormat.FormatString = "C"

        GvVentasPeriodos.Columns("Permuta").DisplayFormat.FormatType = FormatType.Numeric
        GvVentasPeriodos.Columns("Permuta").DisplayFormat.FormatString = "C"

        GvVentasPeriodos.Columns("Otras").DisplayFormat.FormatType = FormatType.Numeric
        GvVentasPeriodos.Columns("Otras").DisplayFormat.FormatString = "C"

        GvVentasPeriodos.Columns("TotalNeto").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalNeto", "{0:c2}")
        GvVentasPeriodos.Columns("Efectivo").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Efectivo", "{0:c2}")
        GvVentasPeriodos.Columns("Cheque").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cheque", "{0:c2}")
        GvVentasPeriodos.Columns("Deposito").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Deposito", "{0:c2}")
        GvVentasPeriodos.Columns("Tarjeta").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Tarjeta", "{0:c2}")
        GvVentasPeriodos.Columns("Credito").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Credito", "{0:c2}")
        GvVentasPeriodos.Columns("Bonos").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Bonos", "{0:c2}")
        GvVentasPeriodos.Columns("Permuta").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Permuta", "{0:c2}")
        GvVentasPeriodos.Columns("Otras").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Otras", "{0:c2}")

        TablaDatos.Clear()
        Using ConMixta As MySqlConnection = New MySqlConnection(CnString)
            Using myCommand As MySqlCommand = New MySqlCommand(GetQueryVentasComparacionPeriodos, ConMixta)
                ConMixta.Open()
                Using myReader As MySqlDataReader = myCommand.ExecuteReader
                    TablaDatos.Load(myReader, LoadOption.Upsert)
                    ConMixta.Close()
                End Using
            End Using
        End Using
        TablaDatos.EndLoadData()

        GvVentasPeriodos.BestFitColumns()
        With GraficoComparacionPeriodos
            .DataSource = Nothing
            .Titles.Clear()
            .Series.Clear()
            .SeriesTemplate.ArgumentDataMember = ""
            .Legends.Clear()
            .ClearCache()
            .ClearSelection()
        End With


        If GetValueofTime(cbxAgrupacionVentasPeriodos.SelectedItem) = 4 Then
            Dim series1 As New Series("Ventas por día", ViewType.Line)
            CType(series1.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True
            CType(series1.View, LineSeriesView).LineMarkerOptions.Kind = MarkerKind.Circle
            CType(series1.View, LineSeriesView).LineStyle.DashStyle = DashStyle.Solid
            series1.CrosshairLabelPattern = "{a} {v:c}"
            series1.CheckableInLegend = True
            series1.CheckedInLegend = True
            GraficoComparacionPeriodos.Series.Add(series1)

            ''''''
            Dim diagram As XYDiagram = TryCast(GraficoComparacionPeriodos.Diagram, XYDiagram)
            diagram.AxisX.DateTimeScaleOptions.MeasureUnit = GetValueofTime(cbxAgrupacionVentasPeriodos.SelectedItem)
            diagram.AxisX.DateTimeScaleOptions.GridAlignment = GetValueofTime(cbxAgrupacionVentasPeriodos.SelectedItem)

            If GetValueofTime(cbxAgrupacionVentasPeriodos.SelectedItem) = 4 Then
                diagram.AxisX.Label.TextPattern = "{a:dd/MMM/yyyy}"
            ElseIf GetValueofTime(cbxAgrupacionVentasPeriodos.SelectedItem) = 5 Then
                diagram.AxisX.Label.TextPattern = "{a:MMM yyyy}"
            ElseIf GetValueofTime(cbxAgrupacionVentasPeriodos.SelectedItem) = 6 Then
                diagram.AxisX.Label.TextPattern = "{a:MMM yyyy}"
            ElseIf GetValueofTime(cbxAgrupacionVentasPeriodos.SelectedItem) = 7 Then
                diagram.AxisX.Label.TextPattern = "{a:MMM yyyy}"
            ElseIf GetValueofTime(cbxAgrupacionVentasPeriodos.SelectedItem) = 7 Then
                diagram.AxisX.Label.TextPattern = "{a:yyyy}"
            Else
                diagram.AxisX.Label.TextPattern = "{a:dd/MMM/yyyy}"
            End If

            diagram.AxisY.Label.TextPattern = "{v:c}"

            CType(GraficoComparacionPeriodos.Diagram, XYDiagram).EnableAxisXZooming = True
            ''''

            GraficoComparacionPeriodos.Series("Ventas por día").ArgumentScaleType = ScaleType.DateTime
            GraficoComparacionPeriodos.Series("Ventas por día").ValueScaleType = ScaleType.Numerical

            For Each rw As DataRow In TablaDatos.Rows
                GraficoComparacionPeriodos.Series("Ventas por día").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("TotalNeto")))
            Next


            If chkEfectivo.CheckState = CheckState.Checked Then
                Dim seriesEfectivo As New Series("Efectivo", ViewType.Line)
                seriesEfectivo.ShowInLegend = False
                GraficoComparacionPeriodos.Series.Add(seriesEfectivo)

                For Each rt As DataRow In TablaDatos.Rows
                    GraficoComparacionPeriodos.Series("Efectivo").Points.AddPoint(CDate(rt.Item("Fecha")), CDbl(rt.Item("Efectivo")))
                Next
            End If

            If chkTarjeta.CheckState = CheckState.Checked Then
                Dim seriesTarjta As New Series("Tarjeta", ViewType.Line)
                seriesTarjta.ShowInLegend = False
                GraficoComparacionPeriodos.Series.Add(seriesTarjta)

                For Each rt As DataRow In TablaDatos.Rows
                    GraficoComparacionPeriodos.Series("Tarjeta").Points.AddPoint(CDate(rt.Item("Fecha")), CDbl(rt.Item("Tarjeta")))
                Next
            End If

            If ChkDeposito.CheckState = CheckState.Checked Then
                Dim seriesDeposito As New Series("Deposito", ViewType.Line)
                seriesDeposito.ShowInLegend = False
                GraficoComparacionPeriodos.Series.Add(seriesDeposito)

                For Each rt As DataRow In TablaDatos.Rows
                    GraficoComparacionPeriodos.Series("Deposito").Points.AddPoint(CDate(rt.Item("Fecha")), CDbl(rt.Item("Deposito")))
                Next
            End If

            If chkCheque.CheckState = CheckState.Checked Then
                Dim seriesCheques As New Series("Cheques", ViewType.Line)
                seriesCheques.ShowInLegend = False
                GraficoComparacionPeriodos.Series.Add(seriesCheques)

                For Each rt As DataRow In TablaDatos.Rows
                    GraficoComparacionPeriodos.Series("Cheques").Points.AddPoint(CDate(rt.Item("Fecha")), CDbl(rt.Item("Cheque")))
                Next
            End If

        ElseIf GetValueofTime(cbxAgrupacionVentasPeriodos.SelectedItem) = 5 Then
            Dim DateCode As String = 0

            For Each rw As DataRow In TablaDatos.Rows
                If DateCode <> rw.Item("Semana") & "/" & rw.Item("Ano") Then
                    DateCode = rw.Item("Semana") & "/" & rw.Item("Ano")

                    Dim series1 As New Series("Semana " & rw.Item("Semana") & "/" & rw.Item("Ano"), ViewType.Bar)
                    series1.CrosshairLabelPattern = "{a:Año: " & rw.Item("Ano") & "} {v:c}"
                    series1.CheckableInLegend = True
                    series1.CheckedInLegend = True
                    GraficoComparacionPeriodos.Series.Add(series1)

                    ''''''
                    Dim diagram As XYDiagram = TryCast(GraficoComparacionPeriodos.Diagram, XYDiagram)
                    diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Week
                    diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Week
                    diagram.AxisX.Label.TextPattern = "{a:Semana: " & rw.Item("Semana") & "}"
                    diagram.AxisY.Label.TextPattern = "{v:c}"

                    GraficoComparacionPeriodos.Series("Semana " & rw.Item("Semana") & "/" & rw.Item("Ano")).ArgumentScaleType = ScaleType.Qualitative
                    GraficoComparacionPeriodos.Series("Semana " & rw.Item("Semana") & "/" & rw.Item("Ano")).ValueScaleType = ScaleType.Numerical

                    GraficoComparacionPeriodos.Legend.Direction = LegendDirection.LeftToRight
                    GraficoComparacionPeriodos.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center
                    GraficoComparacionPeriodos.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside

                    GraficoComparacionPeriodos.Series("Semana " & rw.Item("Semana") & "/" & rw.Item("Ano")).Points.Add(New SeriesPoint("Semana " & rw.Item("Semana") & "/" & rw.Item("Ano"), CDbl(rw.Item("TotalNeto"))))

                    If chkEfectivo.CheckState = CheckState.Checked Then
                        Dim seriesEfectivo As New Series("Efectivo", ViewType.Line)
                        seriesEfectivo.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesEfectivo)
                        GraficoComparacionPeriodos.Series("Efectivo").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Efectivo")))
                    End If

                    If chkTarjeta.CheckState = CheckState.Checked Then
                        Dim seriesTarjta As New Series("Tarjeta", ViewType.Line)
                        seriesTarjta.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesTarjta)
                        GraficoComparacionPeriodos.Series("Tarjeta").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Tarjeta")))
                    End If

                    If ChkDeposito.CheckState = CheckState.Checked Then
                        Dim seriesDeposito As New Series("Deposito", ViewType.Line)
                        seriesDeposito.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesDeposito)
                        GraficoComparacionPeriodos.Series("Deposito").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Deposito")))
                    End If

                    If chkCheque.CheckState = CheckState.Checked Then
                        Dim seriesCheques As New Series("Cheques", ViewType.Line)
                        seriesCheques.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesCheques)
                        GraficoComparacionPeriodos.Series("Cheques").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Cheque")))
                    End If
                End If
            Next

        ElseIf GetValueofTime(cbxAgrupacionVentasPeriodos.SelectedItem) = 6 Then
            Dim DateCode As String = 0

            For Each rw As DataRow In TablaDatos.Rows
                If DateCode <> rw.Item("Mes") & "/" & rw.Item("Ano") Then
                    DateCode = rw.Item("Mes") & "/" & rw.Item("Ano")

                    Dim series1 As New Series("Mes " & rw.Item("Mes") & "/" & rw.Item("Ano"), ViewType.Bar)
                    series1.CrosshairLabelPattern = "{a:Año: " & rw.Item("Ano") & "} {v:c}"

                    series1.CheckableInLegend = True
                    series1.CheckedInLegend = True

                    GraficoComparacionPeriodos.Series.Add(series1)

                    ''''''
                    Dim diagram As XYDiagram = TryCast(GraficoComparacionPeriodos.Diagram, XYDiagram)
                    diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Week
                    diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Week
                    diagram.AxisX.Label.TextPattern = "{a:Mes: " & rw.Item("Mes") & "}"
                    diagram.AxisY.Label.TextPattern = "{v:c}"

                    GraficoComparacionPeriodos.Series("Mes " & rw.Item("Mes") & "/" & rw.Item("Ano")).ArgumentScaleType = ScaleType.Qualitative
                    GraficoComparacionPeriodos.Series("Mes " & rw.Item("Mes") & "/" & rw.Item("Ano")).ValueScaleType = ScaleType.Numerical

                    GraficoComparacionPeriodos.Legend.Direction = LegendDirection.LeftToRight
                    GraficoComparacionPeriodos.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center
                    GraficoComparacionPeriodos.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside

                    GraficoComparacionPeriodos.Series("Mes " & rw.Item("Mes") & "/" & rw.Item("Ano")).Points.Add(New SeriesPoint("Mes " & rw.Item("Mes") & "/" & rw.Item("Ano"), CDbl(rw.Item("TotalNeto"))))

                    If chkEfectivo.CheckState = CheckState.Checked Then
                        Dim seriesEfectivo As New Series("Efectivo", ViewType.Line)
                        seriesEfectivo.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesEfectivo)
                        GraficoComparacionPeriodos.Series("Efectivo").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Efectivo")))
                    End If

                    If chkTarjeta.CheckState = CheckState.Checked Then
                        Dim seriesTarjta As New Series("Tarjeta", ViewType.Line)
                        seriesTarjta.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesTarjta)
                        GraficoComparacionPeriodos.Series("Tarjeta").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Tarjeta")))
                    End If

                    If ChkDeposito.CheckState = CheckState.Checked Then
                        Dim seriesDeposito As New Series("Deposito", ViewType.Line)
                        seriesDeposito.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesDeposito)
                        GraficoComparacionPeriodos.Series("Deposito").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Deposito")))
                    End If

                    If chkCheque.CheckState = CheckState.Checked Then
                        Dim seriesCheques As New Series("Cheques", ViewType.Line)
                        seriesCheques.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesCheques)
                        GraficoComparacionPeriodos.Series("Cheques").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Cheque")))
                    End If
                End If
            Next

        ElseIf GetValueofTime(cbxAgrupacionVentasPeriodos.SelectedItem) = 7 Then
            Dim DateCode As String = 0

            For Each rw As DataRow In TablaDatos.Rows
                If DateCode <> rw.Item("Cuarto") & "/" & rw.Item("Ano") Then
                    DateCode = rw.Item("Cuarto") & "/" & rw.Item("Ano")

                    Dim series1 As New Series("Cuarto " & rw.Item("Cuarto") & "/" & rw.Item("Ano"), ViewType.Bar)
                    series1.CheckableInLegend = True
                    series1.CheckedInLegend = True
                    series1.CrosshairLabelPattern = "{a:Año: " & rw.Item("Ano") & "} {v:c}"
                    GraficoComparacionPeriodos.Series.Add(series1)

                    ''''''
                    Dim diagram As XYDiagram = TryCast(GraficoComparacionPeriodos.Diagram, XYDiagram)
                    diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Week
                    diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Week
                    diagram.AxisX.Label.TextPattern = "{a:Cuarto: " & rw.Item("Cuarto") & "}"
                    diagram.AxisY.Label.TextPattern = "{v:c}"

                    GraficoComparacionPeriodos.Series("Cuarto " & rw.Item("Cuarto") & "/" & rw.Item("Ano")).ArgumentScaleType = ScaleType.Qualitative
                    GraficoComparacionPeriodos.Series("Cuarto " & rw.Item("Cuarto") & "/" & rw.Item("Ano")).ValueScaleType = ScaleType.Numerical

                    GraficoComparacionPeriodos.Legend.Direction = LegendDirection.LeftToRight
                    GraficoComparacionPeriodos.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center
                    GraficoComparacionPeriodos.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside

                    GraficoComparacionPeriodos.Series("Cuarto " & rw.Item("Cuarto") & "/" & rw.Item("Ano")).Points.Add(New SeriesPoint("Cuarto " & rw.Item("Cuarto") & "/" & rw.Item("Ano"), CDbl(rw.Item("TotalNeto"))))

                    If chkEfectivo.CheckState = CheckState.Checked Then
                        Dim seriesEfectivo As New Series("Efectivo", ViewType.Line)
                        seriesEfectivo.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesEfectivo)
                        GraficoComparacionPeriodos.Series("Efectivo").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Efectivo")))
                    End If

                    If chkTarjeta.CheckState = CheckState.Checked Then
                        Dim seriesTarjta As New Series("Tarjeta", ViewType.Line)
                        seriesTarjta.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesTarjta)
                        GraficoComparacionPeriodos.Series("Tarjeta").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Tarjeta")))
                    End If

                    If ChkDeposito.CheckState = CheckState.Checked Then
                        Dim seriesDeposito As New Series("Deposito", ViewType.Line)
                        seriesDeposito.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesDeposito)
                        GraficoComparacionPeriodos.Series("Deposito").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Deposito")))
                    End If

                    If chkCheque.CheckState = CheckState.Checked Then
                        Dim seriesCheques As New Series("Cheques", ViewType.Line)
                        seriesCheques.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesCheques)
                        GraficoComparacionPeriodos.Series("Cheques").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Cheque")))
                    End If
                End If
            Next

        ElseIf GetValueofTime(cbxAgrupacionVentasPeriodos.SelectedItem) = 8 Then
            Dim DateCode As String = 0

            For Each rw As DataRow In TablaDatos.Rows
                If DateCode <> rw.Item("Ano") Then
                    DateCode = rw.Item("Ano")

                    Dim series1 As New Series(rw.Item("Ano"), ViewType.Bar)
                    'CType(series1.View, BarSeriesView).ColorEach = True

                    series1.CheckableInLegend = True
                    series1.CheckedInLegend = True

                    series1.CrosshairLabelPattern = "{a:Año: " & rw.Item("Ano") & "} {v:c}"
                    GraficoComparacionPeriodos.Series.Add(series1)

                    ''''''
                    Dim diagram As XYDiagram = TryCast(GraficoComparacionPeriodos.Diagram, XYDiagram)
                    diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Week
                    diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Week
                    diagram.AxisX.Label.TextPattern = "{a:Año: " & rw.Item("Ano") & "}"
                    diagram.AxisY.Label.TextPattern = "{v:c}"


                    GraficoComparacionPeriodos.Series(rw.Item("Ano")).ArgumentScaleType = ScaleType.Qualitative
                    GraficoComparacionPeriodos.Series(rw.Item("Ano")).ValueScaleType = ScaleType.Numerical

                    GraficoComparacionPeriodos.Legend.Direction = LegendDirection.LeftToRight
                    GraficoComparacionPeriodos.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center
                    GraficoComparacionPeriodos.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside

                    GraficoComparacionPeriodos.Series(rw.Item("Ano")).Points.Add(New SeriesPoint("Año " & rw.Item("Ano"), CDbl(rw.Item("TotalNeto"))))

                    If chkEfectivo.CheckState = CheckState.Checked Then
                        Dim seriesEfectivo As New Series("Efectivo", ViewType.Line)
                        seriesEfectivo.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesEfectivo)
                        GraficoComparacionPeriodos.Series("Efectivo").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Efectivo")))
                    End If

                    If chkTarjeta.CheckState = CheckState.Checked Then
                        Dim seriesTarjta As New Series("Tarjeta", ViewType.Line)
                        seriesTarjta.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesTarjta)
                        GraficoComparacionPeriodos.Series("Tarjeta").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Tarjeta")))
                    End If

                    If ChkDeposito.CheckState = CheckState.Checked Then
                        Dim seriesDeposito As New Series("Deposito", ViewType.Line)
                        seriesDeposito.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesDeposito)
                        GraficoComparacionPeriodos.Series("Deposito").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Deposito")))
                    End If

                    If chkCheque.CheckState = CheckState.Checked Then
                        Dim seriesCheques As New Series("Cheques", ViewType.Line)
                        seriesCheques.ShowInLegend = False
                        GraficoComparacionPeriodos.Series.Add(seriesCheques)
                        GraficoComparacionPeriodos.Series("Cheques").Points.AddPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Cheque")))
                    End If
                End If
            Next
        End If
    End Sub
    Private Sub XTabVentas_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTabVentas.SelectedPageChanged
        If XTabVentas.SelectedTabPageIndex = 1 Then
            GetVentasComparativas()

        ElseIf XTabVentas.SelectedTabPageIndex = 2 Then
            GetIngresosVsGastos()
        End If
    End Sub

    Private Sub GetIngresosVsGastos()
        Dim dstmp As New DataSet
        GvIngresosVsGastos.Columns.Clear()
        GvIngresosVsGastos.GroupSummary.Clear()
        GVGastos.Columns.Clear()
        GVGastos.GroupSummary.Clear()

        With GraficoIngresovsGastos
            .DataSource = Nothing
            .Titles.Clear()
            .Series.Clear()
            .SeriesTemplate.ArgumentDataMember = ""
            .Legends.Clear()
            .ClearCache()
            .ClearSelection()
        End With

        Dim TablaDatos As DataTable = New DataTable("Datos")
        TablaDatos.Columns.Add("IDMoneda", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Documento", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
        TablaDatos.Columns.Add("Resultado", System.Type.GetType("System.Double"))
        GcIngresosVsGastos.DataSource = TablaDatos

        GvIngresosVsGastos.Columns("Resultado").DisplayFormat.FormatType = FormatType.Numeric
        GvIngresosVsGastos.Columns("Resultado").DisplayFormat.FormatString = "C"
        GvIngresosVsGastos.Columns("Resultado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Resultado", "{0:c2}")

        TablaDatos.Clear()
        Using ConMixta As MySqlConnection = New MySqlConnection(CnString)
            Using myCommand As MySqlCommand = New MySqlCommand("Select IDMoneda,Documento,Date(Fecha) as Fecha,(Sum(Débito)-Sum(Crédito)) as Resultado FROM Libregco.cuadresview WHERE Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' and cuadresview.Nulo=0 GROUP BY IDTipoDocumento,day(Fecha),month(Fecha) ASC UNION ALL Select IDMoneda,Documento,Date(Fecha) as Fecha,(Sum(Débito)-Sum(Crédito)) as Resultado FROM Libregco_Main.cuadresview WHERE Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' and cuadresview.Nulo=0 GROUP BY IDTipoDocumento,day(Fecha),month(Fecha)", ConMixta)
                ConMixta.Open()
                Using myReader As MySqlDataReader = myCommand.ExecuteReader
                    TablaDatos.Load(myReader, LoadOption.Upsert)
                    ConMixta.Close()
                End Using
            End Using
        End Using
        TablaDatos.EndLoadData()

        TablaDatos.DefaultView.Sort = "Fecha ASC"
        TablaDatos = TablaDatos.DefaultView.ToTable

        GvIngresosVsGastos.BestFitColumns()

        Dim Lista As New ArrayList
        Dim Acumulado As Double = 0

        Dim seriesAcumulado As New Series("Ingresos (Todos)", ViewType.Line)

        CType(seriesAcumulado.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True
        CType(seriesAcumulado.View, LineSeriesView).LineMarkerOptions.Kind = MarkerKind.Plus
        CType(seriesAcumulado.View, LineSeriesView).LineStyle.DashStyle = DashStyle.Dash
        CType(seriesAcumulado.View, LineSeriesView).Color = Color.Blue

        seriesAcumulado.CheckableInLegend = True
        seriesAcumulado.CheckedInLegend = True
        seriesAcumulado.CrosshairLabelPattern = "{a} {v:c}"

        GraficoIngresovsGastos.Series.Add(seriesAcumulado)

        For Each rw As DataRow In TablaDatos.Rows
            Acumulado += CDbl(rw.Item("Resultado"))

            GraficoIngresovsGastos.Series("Ingresos (Todos)").Points.Add(New SeriesPoint(CDate(rw.Item("Fecha")), Acumulado))

            If Lista.Contains(rw.Item("Documento")) Then
                GraficoIngresovsGastos.Series(rw.Item("Documento")).Points.Add(New SeriesPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Resultado"))))
            Else
                Lista.Add(rw.Item("Documento"))
                Dim series1 As New Series(rw.Item("Documento"), ViewType.Line)

                'CType(series1.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True
                'CType(series1.View, LineSeriesView).LineStyle.DashStyle = DashStyle.Solid

                series1.CheckableInLegend = True
                series1.CheckedInLegend = True
                series1.CrosshairLabelPattern = "{a} {v:c}"

                GraficoIngresovsGastos.Series.Add(series1)

                GraficoIngresovsGastos.Series(rw.Item("Documento")).ArgumentScaleType = ScaleType.DateTime
                GraficoIngresovsGastos.Series(rw.Item("Documento")).ValueScaleType = ScaleType.Numerical

                GraficoIngresovsGastos.Series(rw.Item("Documento")).Points.Add(New SeriesPoint(CDate(rw.Item("Fecha")), CDbl(rw.Item("Resultado"))))
            End If

        Next

        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDMoneda,SecondID,TipoDocumento.Documento,Compras.Fecha as Fecha,TotalNeto as Resultado FROM Libregco.compras INNER JOIN Libregco.TipoDocumento on Compras.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion Where Compras.Nulo=0 and Condicion.Dias=0 and Compras.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' UNION ALL Select Compras.IDMoneda,PagoCompra.SecondID,TipoDocumento.Documento,PagoCompra.Fecha as Fecha,Importe as TotalNeto From Libregco.PagoCompra INNER JOIN Libregco.TipoDocumento on PagoCompra.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.pagocomprasdetalle on PagoCompra.IDPagoCompra=pagocomprasdetalle.IDPagoCompra INNER JOIN Libregco.Compras on pagocomprasdetalle.IDCompra=Compras.IDCompra Where PagoCompra.Nulo=0 and PagoCompra.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' GROUP By PagoCompra.IDPagoCompra UNION ALL SELECT IDMoneda,SecondID,TipoDocumento.Documento,Compras.Fecha,TotalNeto as TotalNeto FROM Libregco_Main.compras INNER JOIN Libregco_Main.TipoDocumento on Compras.IDTipoDocumento=TipoDocumento.IDTipoDocumento  INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion Where Compras.Nulo=0 and Condicion.Dias=0 and Compras.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' UNION ALL Select Compras.IDMoneda,PagoCompra.SecondID,TipoDocumento.Documento,PagoCompra.Fecha as Fecha,Importe as TotalNeto From Libregco_Main.PagoCompra INNER JOIN Libregco_Main.TipoDocumento on PagoCompra.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco_Main.pagocomprasdetalle on PagoCompra.IDPagoCompra=pagocomprasdetalle.IDPagoCompra INNER JOIN Libregco_Main.Compras on pagocomprasdetalle.IDCompra=Compras.IDCompra Where PagoCompra.Nulo=0 and PagoCompra.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' GROUP By PagoCompra.IDPagoCompra UNION ALL Select 1 as IDMoneda,Nomina.SecondID,TipoDocumento.Documento,Nomina.Fecha,Nomina.Neto from Libregco.Nomina INNER JOIN Libregco.TipoDocumento on Nomina.IDTipoDocumento=TipoDocumento.IDTipoDocumento Where Nomina.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' and Nomina.Nulo=0 UNION ALL select 1 as IDMoneda,Nomina.SecondID,TipoDocumento.Documento,Nomina.Fecha,Nomina.Neto from Libregco_Main.Nomina INNER JOIN Libregco_Main.TipoDocumento on Nomina.IDTipoDocumento=TipoDocumento.IDTipoDocumento Where Nomina.Fecha Between '" + CDate(dtpInicial.EditValue).ToString("yyyy-MM-dd") + "' and '" + CDate(DtpFinal.EditValue).ToString("yyyy-MM-dd") + "' and Nomina.Nulo=0", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstmp, "Gastos")
        ConMixta.Close()

        Dim seriesEgresos As New Series("Egresos (Todos)", ViewType.Line)

        CType(seriesEgresos.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True
        CType(seriesEgresos.View, LineSeriesView).LineMarkerOptions.Kind = MarkerKind.Cross
        CType(seriesEgresos.View, LineSeriesView).LineStyle.DashStyle = DashStyle.Dash
        CType(seriesEgresos.View, LineSeriesView).Color = Color.Red

        seriesEgresos.CheckableInLegend = True
        seriesEgresos.CheckedInLegend = True
        seriesEgresos.CrosshairLabelPattern = "{a} {v:c}"

        GraficoIngresovsGastos.Series.Add(seriesEgresos)


        Dim TablaEgresos As DataTable = dstmp.Tables("Gastos")
        TablaEgresos.DefaultView.Sort = "Fecha ASC"
        TablaEgresos = TablaEgresos.DefaultView.ToTable

        GDGastos.DataSource = TablaEgresos
        GVGastos.Columns("Resultado").DisplayFormat.FormatType = FormatType.Numeric
        GVGastos.Columns("Resultado").DisplayFormat.FormatString = "C"

        GVGastos.Columns("Resultado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Resultado", "{0:c2}")

        Dim AcumuladoGastos As Double = 0
        Dim ListaGastos As New ArrayList

        For Each rt As DataRow In TablaEgresos.Rows
            AcumuladoGastos += CDbl(rt.Item("Resultado"))

            GraficoIngresovsGastos.Series("Egresos (Todos)").Points.Add(New SeriesPoint(CDate(rt.Item("Fecha")), AcumuladoGastos))

            If ListaGastos.Contains(rt.Item("Documento")) Then
                GraficoIngresovsGastos.Series(rt.Item("Documento")).Points.Add(New SeriesPoint(CDate(rt.Item("Fecha")), CDbl(rt.Item("Resultado"))))
            Else
                ListaGastos.Add(rt.Item("Documento"))
                Dim series1 As New Series(rt.Item("Documento"), ViewType.Line)

                'CType(series1.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True
                'CType(series1.View, LineSeriesView).LineStyle.DashStyle = DashStyle.Solid

                series1.CheckableInLegend = True
                series1.CheckedInLegend = True
                series1.CrosshairLabelPattern = "{a} {v:c}"

                GraficoIngresovsGastos.Series.Add(series1)

                GraficoIngresovsGastos.Series(rt.Item("Documento")).ArgumentScaleType = ScaleType.DateTime
                GraficoIngresovsGastos.Series(rt.Item("Documento")).ValueScaleType = ScaleType.Numerical

                GraficoIngresovsGastos.Series(rt.Item("Documento")).Points.Add(New SeriesPoint(CDate(rt.Item("Fecha")), CDbl(rt.Item("Resultado"))))
            End If

        Next


        Dim diagram As XYDiagram = TryCast(GraficoIngresovsGastos.Diagram, XYDiagram)
        diagram.AxisX.DateTimeScaleOptions.MeasureUnit = GetValueofTime(ComboBoxEdit2.SelectedItem)
        diagram.AxisX.DateTimeScaleOptions.GridAlignment = GetValueofTime(ComboBoxEdit2.SelectedItem)

        If GetValueofTime(ComboBoxEdit2.SelectedItem) = 4 Then
            diagram.AxisX.Label.TextPattern = "{a:dd/MMM/yyyy}"
        ElseIf GetValueofTime(ComboBoxEdit2.SelectedItem) = 5 Then
            diagram.AxisX.Label.TextPattern = "{a:MMM yyyy}"
        ElseIf GetValueofTime(ComboBoxEdit2.SelectedItem) = 6 Then
            diagram.AxisX.Label.TextPattern = "{a:MMM yyyy}"
        ElseIf GetValueofTime(ComboBoxEdit2.SelectedItem) = 7 Then
            diagram.AxisX.Label.TextPattern = "{a:MMM yyyy}"
        ElseIf GetValueofTime(ComboBoxEdit2.SelectedItem) = 7 Then
            diagram.AxisX.Label.TextPattern = "{a:yyyy}"
        Else
            diagram.AxisX.Label.TextPattern = "{a:dd/MMM/yyyy}"
        End If

        diagram.AxisY.Label.TextPattern = "{v:c}"

        CType(GraficoIngresovsGastos.Diagram, XYDiagram).EnableAxisXZooming = True

        GraficoIngresovsGastos.Legend.Visibility = DefaultBoolean.True
        GraficoIngresovsGastos.Legend.Direction = LegendDirection.LeftToRight
        GraficoIngresovsGastos.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Center
        GraficoIngresovsGastos.Legend.AlignmentVertical = LegendAlignmentVertical.BottomOutside
    End Sub

    Private Function GetWeekNumber(ByVal startMonth As Integer, ByVal startDay As Integer, ByVal endDate As Date) As Integer
        Dim span As TimeSpan = endDate - New Date(endDate.Year, startMonth, startDay)
        Return (CInt(span.TotalDays) \ 7) + 1
    End Function

    Private Sub ComboBoxEdit1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAgrupacionVentasPeriodos.SelectedIndexChanged
        If FlagToLoaded = True Then
            GetVentasComparativas()
        End If
    End Sub

    Private Sub ComboBoxEdit2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit2.SelectedIndexChanged
        If FlagToLoaded = True Then
            GetIngresosVsGastos()
        End If
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ShowChartPreview(GraficoVentasEmpleados)
    End Sub

    Sub ShowChartPreview(ByVal chart As ChartControl)
        ' Check whether the ChartControl can be previewed.
        If Not chart.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting.v7.2.dll' is not found", "Error")
            Return
        End If

        ' Opens the Preview window.
        chart.ShowPrintPreview()
    End Sub

    Sub PrintChart(ByVal chart As ChartControl)
        ' Check whether the ChartControl can be printed.
        If Not chart.IsPrintingAvailable Then
            MessageBox.Show("The 'DevExpress.XtraPrinting.v7.2.dll' is not found", "Error")
            Return
        End If

        ' Print.
        chart.Print()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        ShowChartPreview(GraficoArticulosMasVendidos)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        ShowChartPreview(GraficoParticipacionVentas)
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        ShowChartPreview(GraficoComparacionPeriodos)
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        ShowChartPreview(GraficoIngresovsGastos)
    End Sub

    Private Sub cbxUsuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxUsuarios.SelectedIndexChanged
        Dim dstemp As New DataSet

        Con.Open()
        cmd = New MySqlCommand("Select Puesto,RutaFoto from" & SysName.Text & "Empleados where IDEmpleado='" + cbxUsuarios.EditValue.ToString + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Empleados")
        Con.Close()

        Dim Tabla As DataTable = dstemp.Tables("Empleados")

        lblPuesto.Text = Tabla.Rows(0).Item("Puesto").ToString.ToUpper
        PicFoto.Tag = cbxUsuarios.EditValue.ToString

        If (Tabla.Rows(0).Item("RutaFoto")) <> "" Then
            If TypeConnection.Text = 1 Then
                Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                If ExistFile = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream((Tabla.Rows(0).Item("RutaFoto")), FileMode.Open, FileAccess.Read)
                    PicFoto.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                Else
                    PicFoto.Image = My.Resources.no_photo
                End If
            Else
                PicFoto.Image = My.Resources.no_photo
            End If
        Else
            PicFoto.Image = My.Resources.no_photo
        End If

        btnActualizar.Focus()
    End Sub
End Class