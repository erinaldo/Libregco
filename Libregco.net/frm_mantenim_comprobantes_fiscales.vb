Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_mantenim_comprobantes_fiscales
    Dim CnString As String = ("Server=localhost;Uid=root;Pwd=iLM14PC1191;Database=libregco")
    Dim Con As New MySqlConnection(CnString)
    Dim sqlQ As String
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim lblchkMostrarenFact As New Label

    Private Sub chkMostrarFact_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarFact.CheckedChanged
        If chkMostrarFact.Checked = True Then
            lblchkMostrarenFact.Text = 1
        Else
            lblchkMostrarenFact.Text = 2
        End If
    End Sub

    Private Sub frm_mantenimiento_comprobantes_fiscales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtHasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHasta.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub
End Class