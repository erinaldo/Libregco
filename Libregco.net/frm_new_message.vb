Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Microsoft.Win32
Imports System.Globalization
Imports System.Runtime.InteropServices

Public Class frm_new_message
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend IDUsuarioConversacion As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Con.Open()
        cmd = New MySqlCommand("Select IDConversacion from UsuariosConversacion where IDUsuariosConversacion='" + IDUsuarioConversacion + "'", Con)
        Dim IDConvs As String = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If frm_messenger.Visible = True Then
            If frm_messenger.WindowState = FormWindowState.Minimized Then
                frm_messenger.WindowState = FormWindowState.Normal
                frm_messenger.Activate()
            Else
                frm_messenger.Activate()
            End If
        Else
            frm_messenger.Show(frm_inicio)
            frm_messenger.Activate()
        End If

        For Each row As DataGridViewRow In frm_messenger.DgvConversations.Rows
            If row.Cells(0).Value = IDUsuarioConversacion Then
                frm_messenger.IDConversacion = IDConvs
                frm_messenger.DgvConversations.Rows(row.Index).Cells(2).Selected = True
                'frm_messenger.Updater.Enabled = False
                'frm_messenger.NTimer.Enabled = False
                frm_messenger.DgvConversations.Focus()
                frm_messenger.FillPreInfo()
                'frm_messenger.Updater.Enabled = True
                'frm_messenger.NTimer.Enabled = True
            End If
        Next


    End Sub

    Private Sub frm_new_message_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = CheckWindowState()
    End Sub
End Class