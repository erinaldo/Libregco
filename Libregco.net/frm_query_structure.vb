Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_query_structure

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_query_structure_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class