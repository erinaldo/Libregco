Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frm_show_ruta_imagen
    Dim wFile As System.IO.FileStream

    Private Sub frm_show_ruta_imagen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frm_mant_clientes.Visible = True Then
            Dim Ruta As String = frm_mant_clientes.DgvRutasAnexas.CurrentRow.Cells(3).Value
            Me.Text = Ruta

            Dim ExistFile As Boolean = System.IO.File.Exists(Ruta)
            If ExistFile = True Then
                wFile = New FileStream(Ruta, FileMode.Open, FileAccess.Read)
                PicVisual.Image = System.Drawing.Image.FromStream(wFile)
                wFile.Close()
            End If

        End If
    End Sub
End Class