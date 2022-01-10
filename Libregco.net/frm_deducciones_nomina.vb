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
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns

Public Class frm_deducciones_nomina

    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim TablaDeducciones As DataTable

    Private Sub frm_deducciones_nomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        SetVentasTable()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        FillDeducciones()
    End Sub

    Private Sub SetVentasTable()
        TablaDeducciones = New DataTable("Deducciones")

        TablaDeducciones.Clear()
        TablaDeducciones.Columns.Clear()
        For Each column As GridColumn In GridView1.Columns
            Dim item As GridSummaryItem = column.SummaryItem
            If item IsNot Nothing Then
                column.Summary.Remove(item)
            End If
        Next column

        TablaDeducciones.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
        TablaDeducciones.Columns.Add("CodigoDeduccion", System.Type.GetType("System.String"))
        TablaDeducciones.Columns.Add("Deduccion", System.Type.GetType("System.String"))
        TablaDeducciones.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaDeducciones.Columns.Add("Monto", System.Type.GetType("System.Double"))
        TablaDeducciones.Columns.Add("Funcion", System.Type.GetType("System.String"))
        TablaDeducciones.Columns.Add("Acumulado", System.Type.GetType("System.Double"))
        TablaDeducciones.Columns.Add("Estado", System.Type.GetType("System.String"))

        GridControl1.DataSource = TablaDeducciones
        'GridView1.Columns("SecondID").ColumnEdit = RepositorySecondID
        'GridView1.Columns("CondicionContado").ColumnEdit = RepositoryCondicionContado

        'Propiedades
        GridView1.Columns("CodigoDeduccion").Caption = "Código de la deducción"
        GridView1.Columns("CodigoDeduccion").Visible = False
        GridView1.Columns("Deduccion").Caption = "Deducción"
        GridView1.Columns("Descripcion").Caption = "Descripción"
        GridView1.Columns("Funcion").Visible = False
        GridView1.Columns("Monto").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Monto").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Monto").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Monto", "{0:c2}")

        Dim item1 As GridGroupSummaryItem = New GridGroupSummaryItem()
        item1.FieldName = "Monto"
        item1.SummaryType = DevExpress.Data.SummaryItemType.Sum
        item1.DisplayFormat = "Total {0:c2}"
        item1.ShowInGroupColumnFooter = GridView1.Columns("Monto")
        GridView1.GroupSummary.Add(item1)


        GridView1.Columns("Acumulado").DisplayFormat.FormatType = FormatType.Numeric
        GridView1.Columns("Acumulado").DisplayFormat.FormatString = "C2"
        GridView1.Columns("Acumulado").Visible = False

        For i = 0 To GridView1.Columns.Count - 1
            GridView1.Columns(i).OptionsColumn.ReadOnly = True
            GridView1.Columns(i).OptionsColumn.AllowEdit = False
        Next
    End Sub

    Sub FillDeducciones()
        'Try
        TablaDeducciones.Rows.Clear()

        Con.Open()

        If frm_proceso_nomina.txtIDNomina.Text = "" Then
            Dim CmdFacts As New MySqlCommand("SELECT deduccionesprocdetalle.Fecha,deduccionesprocdetalle.IDDeduccion,Deducciones.Descripcion as Deduccion,deduccionesprocdetalle.Descripcion,IF(tipofuncion.Funcion='+',deduccionesprocdetalle.Monto,-deduccionesprocdetalle.Monto) AS Monto,tipofuncion.Funcion,IF(IDNominaEmpleados IS NULL,'Pendiente','Pagada') as Status FROM deduccionesprocdetalle INNER JOIN DeduccionesProcesadas on DeduccionesProcDetalle.IDDeduccionProcesada=DeduccionesProcesadas.IDeduccionesProcesadas INNER JOIN Empleados on DeduccionesProcDetalle.IDEmpleado=Empleados.IDEmpleado INNER JOIN Deducciones on DeduccionesProcDetalle.IDDeduccion=Deducciones.IDDeduccion INNER JOIN TipoFuncion on Deducciones.IDTipoFuncion=TipoFuncion.IDTipoFuncion WHERE deduccionesprocdetalle.IDEmpleado='" + frm_proceso_nomina.DgvEmpleados.CurrentRow.Cells(1).Value.ToString + "' AND deduccionesprocdetalle.Fecha Between '" + frm_proceso_nomina.DtpFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + frm_proceso_nomina.DtpFechaFinal.Value.ToString("yyyy-MM-dd") + "' and DeduccionesProcDetalle.IDNominaEmpleados IS NULL ORDER BY DeduccionesProcDetalle.IDDeduccionesProcDetalle ASC", Con)
            Dim LectorDeduccion As MySqlDataReader = CmdFacts.ExecuteReader

            While LectorDeduccion.Read
                TablaDeducciones.Rows.Add(CDate(LectorDeduccion.GetValue(0)).ToString("dd/MM/yyyy"), LectorDeduccion.GetValue(1), LectorDeduccion.GetValue(2), LectorDeduccion.GetValue(3), LectorDeduccion.GetValue(4), LectorDeduccion.GetValue(5), 0, LectorDeduccion.GetValue(6))
            End While
            LectorDeduccion.Close()

        Else
            Dim CmdFacts As New MySqlCommand("SELECT deduccionesprocdetalle.Fecha,deduccionesprocdetalle.IDDeduccion,Deducciones.Descripcion as Deduccion,deduccionesprocdetalle.Descripcion,IF(tipofuncion.Funcion='+',deduccionesprocdetalle.Monto,-deduccionesprocdetalle.Monto) AS Monto,tipofuncion.Funcion,IF(IDNominaEmpleados IS NULL,'Pendiente','Pagada') as Status FROM deduccionesprocdetalle INNER JOIN DeduccionesProcesadas on DeduccionesProcDetalle.IDDeduccionProcesada=DeduccionesProcesadas.IDeduccionesProcesadas INNER JOIN Empleados on DeduccionesProcDetalle.IDEmpleado=Empleados.IDEmpleado INNER JOIN Deducciones on DeduccionesProcDetalle.IDDeduccion=Deducciones.IDDeduccion INNER JOIN TipoFuncion on Deducciones.IDTipoFuncion=TipoFuncion.IDTipoFuncion WHERE deduccionesprocdetalle.IDEmpleado='" + frm_proceso_nomina.DgvEmpleados.CurrentRow.Cells(1).Value.ToString + "' AND deduccionesprocdetalle.Fecha Between '" + frm_proceso_nomina.DtpFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + frm_proceso_nomina.DtpFechaFinal.Value.ToString("yyyy-MM-dd") + "'  ORDER BY DeduccionesProcDetalle.IDDeduccionesProcDetalle ASC", Con)
            Dim LectorDeduccion As MySqlDataReader = CmdFacts.ExecuteReader

            While LectorDeduccion.Read
                TablaDeducciones.Rows.Add(CDate(LectorDeduccion.GetValue(0)).ToString("dd/MM/yyyy"), LectorDeduccion.GetValue(1), LectorDeduccion.GetValue(2), LectorDeduccion.GetValue(3), LectorDeduccion.GetValue(4), LectorDeduccion.GetValue(5), 0, LectorDeduccion.GetValue(6))
            End While
            LectorDeduccion.Close()
        End If

        Con.Close()


        Dim Debito, Credito, Total As Double
        Total = 0

        For Each rw As DataRow In TablaDeducciones.Rows
            If rw.Item(5) = "+" Then
                Debito = CDbl(rw.Item(4))
                Credito = 0
            Else
                Credito = CDbl(rw.Item(4))
                Debito = 0
            End If
            Total = Total + Debito - Credito

            rw.Item(6) = Total
        Next

        GridView1.Columns(2).GroupIndex = 0
        GridView1.ExpandAllGroups()
        GridView1.BestFitColumns()

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim currentView As GridView = TryCast(sender, GridView)
        If e.Column.FieldName = "Funcion" Then
            If currentView.GetRowCellValue(e.RowHandle, "Funcion") = "-" Then
                e.Appearance.ForeColor = Color.Red
            Else
                e.Appearance.ForeColor = Color.Black
            End If
        End If
    End Sub
End Class