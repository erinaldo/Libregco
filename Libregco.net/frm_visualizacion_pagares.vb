Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_visualizacion_pagares

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_visualizacion_pagares_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = CheckWindowState()
        DgvPagares.Columns.Clear()
        ColumnasDgvPagares()
        RefrescarTablaPagares()
    End Sub

    Private Sub ColumnasDgvPagares()
        Try
            DgvPagares.Columns.Clear()
            With DgvPagares
                .Columns.Add("IDPagare", "IDPagare") '0
                .Columns.Add("IDFactura", "ID Factura") '1
                .Columns.Add("NoPagare", "No.") '2
                .Columns.Add("FechaVencimiento", "Vencimiento") '3
                .Columns.Add("DiasVencidos", "Días")  '4
                .Columns.Add("Monto", "Monto") '5
                .Columns.Add("BalancePagare", "Balance") '6
                .Columns.Add("IDEmpleado", "Empleado")  '7
                .Columns.Add("Estado", "Estado")    '8
            End With

            PropiedadesDgvPagares()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PropiedadesDgvPagares()
        Try
            Dim Condicion As String = False
            Dim DatagridWidth As Double = (DgvPagares.Width - DgvPagares.RowHeadersWidth) / 100

            With DgvPagares
                .Columns(0).Visible = Condicion
                .Columns(1).Visible = Condicion
                .Columns(2).Width = DatagridWidth * 8
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(3).Width = DatagridWidth * 10
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(3).DefaultCellStyle.Format = ("yyyy-MM-dd")
                .Columns(4).Width = DatagridWidth * 10
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(5).Width = DatagridWidth * 10
                .Columns(5).DefaultCellStyle.Format = ("C")
                .Columns(6).DefaultCellStyle.Format = ("C")
                .Columns(6).Width = DatagridWidth * 12
                .Columns(7).Width = DatagridWidth * 30
                .Columns(8).Width = DatagridWidth * 20
            End With

            For Each Column As DataGridViewColumn In DgvPagares.Columns
                Column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MarcarPagaresVencidos()
        For Each Row As DataGridViewRow In DgvPagares.Rows
            If CDate(Row.Cells(3).Value) < Today Then
                Row.Cells(3).Style.ForeColor = Color.Red
            End If
        Next
    End Sub

    Sub RefrescarTablaPagares()
        Try
            Dim IDFactura As New Label
            DgvPagares.Rows.Clear()

            If frm_recibo_pagos.DTFacturas.Rows.Count > 0 Then
                IDFactura.Text = frm_recibo_pagos.AdvBandedGridView1.GetFocusedRowCellValue("IDFacturaDatos")

                Con.Open()
                Dim CmdPagares As New MySqlCommand("SELECT IDPagare,IDFactura,NoPagare,FechaVencimiento,DiasVencidos,Monto,Pagares.Balance,Nombre,Descripcion from pagares INNER JOIN empleados ON pagares.IDEmpleado=Empleados.IDEmpleado  INNER JOIN StatusPagare on Pagares.IDStatusPagare=StatusPagare.IDStatusPagare WHERE Pagares.Balance>0 AND IDFactura='" + IDFactura.Text + "' ORDER BY FechaVencimiento ASC", Con)
                Dim Lectorpagare As MySqlDataReader = CmdPagares.ExecuteReader

                While Lectorpagare.Read
                    DgvPagares.Rows.Add(Lectorpagare.GetValue(0), Lectorpagare.GetValue(1), Lectorpagare.GetValue(2), CDate(Lectorpagare.GetValue(3)), Lectorpagare.GetValue(4), Lectorpagare.GetValue(5), Lectorpagare.GetValue(6), Lectorpagare.GetValue(7), Lectorpagare.GetValue(8))
                End While
                Lectorpagare.Close()
                Con.Close()

                DgvPagares.Sort(DgvPagares.Columns("FechaVencimiento"), System.ComponentModel.ListSortDirection.Ascending)
                MarcarPagaresVencidos()
                DgvPagares.ClearSelection()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " RefrescasrTablaPAgares")
        End Try

    End Sub

    Private Sub frm_visualizacion_pagares_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadesDgvPagares()
    End Sub

End Class