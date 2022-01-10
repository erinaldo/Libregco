Imports System.IO

Public Class frm_seleccion_iconos
    Dim PixelSize As String

    Private Sub frm_seleccion_iconos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSelectedPixcel()

    End Sub

    Private Sub LoadSelectedPixcel()
        If System.Diagnostics.Debugger.IsAttached Then
            GaleriaImagenes1.Directorypath = "C:\Libregco\Release\Application Files\libregco_1_4_1_0\Resources\IcoFlat\x72"
        Else

            If rdbx20.Checked = True Then
                PixelSize = "/IcoFlat/x20"
            ElseIf rdbx32.Checked = True Then
                PixelSize = "/IcoFlat/x32"
            ElseIf rdbx48.Checked = True Then
                PixelSize = "/IcoFlat/x48"
            ElseIf rdbx72.Checked = True Then
                PixelSize = "/IcoFlat/x72"
            ElseIf rdbx256.Checked = True Then
                PixelSize = "/IcoFlat/x256"
            End If

            GaleriaImagenes1.Directorypath = Path.GetFullPath(My.Resources.ResourceManager.BaseName.Replace("Libregco.Resources", "Resources") & PixelSize)
        End If
       
    End Sub

    Private Sub rdbx20_CheckedChanged(sender As Object, e As EventArgs) Handles rdbx20.CheckedChanged
        LoadSelectedPixcel()
    End Sub

    Private Sub rdbx32_CheckedChanged(sender As Object, e As EventArgs) Handles rdbx32.CheckedChanged
        LoadSelectedPixcel()
    End Sub

    Private Sub rdbx48_CheckedChanged(sender As Object, e As EventArgs) Handles rdbx48.CheckedChanged
        LoadSelectedPixcel()
    End Sub

    Private Sub rdbx72_CheckedChanged(sender As Object, e As EventArgs) Handles rdbx72.CheckedChanged
        LoadSelectedPixcel()
    End Sub

    Private Sub rdbx256_CheckedChanged(sender As Object, e As EventArgs) Handles rdbx256.CheckedChanged
        LoadSelectedPixcel()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
     
            If Me.Owner.Name = frm_ajustes_tecnicos.Name Then
                frm_ajustes_tecnicos.DgvIconos.CurrentRow.Cells(6).Value = GaleriaImagenes1.SelectedImage
                frm_ajustes_tecnicos.DgvIconos.CurrentRow.Cells(8).Value = "\Libregco\Libregco.net" & Mid(GaleriaImagenes1.SelectedPath, 55)
            End If

            Close()



        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class