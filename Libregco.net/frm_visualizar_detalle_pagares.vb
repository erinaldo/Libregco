Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_visualizar_detalle_pagares

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_visualizar_detalle_pagares_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = CheckWindowState()
        If frm_facturacion.Visible = True Then
            DgvPagares.Rows.Clear()
            For Each Row As DataGridViewRow In frm_facturacion.DgvPagares.Rows
                DgvPagares.Rows.Add((Row.Cells(2).Value), CDate(Row.Cells(4).Value).ToLongDateString, (Row.Cells(5).Value), CDbl(Row.Cells(6).Value).ToString("C"))
            Next
        End If

    End Sub
End Class