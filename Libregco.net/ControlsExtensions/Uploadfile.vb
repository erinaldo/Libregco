Imports System.ComponentModel
Imports System.IO

Public Class Uploadfile
    Dim FilePath As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    <Category("UploadFileCustom"), Description(""), Browsable(True)>
    Property FilePathRoute() As String
        Get
            Return FilePath
        End Get
        Set(value As String)
            FilePath = value
        End Set
    End Property

    Public Sub Clear()
        ResetPicImage()
        FilePath = ""
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If FilePath = "" Then
            MessageBox.Show("No existe documentación anexa al registro.", "No existe archivo adjunto", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea eliminar el archivo adjunto al registro?", "Eliminar archivo adjunto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                FilePath = ""
                ResetPicImage()
            End If
        End If
    End Sub

    Sub ResetPicImage()
        Try
            PicDocumento.Width = 423
            PicDocumento.Height = 295
            PicDocumento.Location = New Point(0, 0)
            PicDocumento.Image = My.Resources.No_Image

        Catch ex As Exception
        End Try
    End Sub


    Private Sub AbrirUbicaciToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        If FilePath <> "" Then
            Dim ExistFile As Boolean = System.IO.File.Exists(FilePath)
            If ExistFile = True Then
                Dim directory As String = Path.GetDirectoryName(FilePath)
                Process.Start("explorer.exe", directory)
            End If
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim OfdRutaDocumento As New OpenFileDialog
        Dim wFile As System.IO.FileStream
        OfdRutaDocumento.Title = ("Buscar imagen")
        OfdRutaDocumento.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
        OfdRutaDocumento.FileName = ""
        OfdRutaDocumento.RestoreDirectory = True

        If OfdRutaDocumento.ShowDialog = Windows.Forms.DialogResult.OK Then
            FilePath = OfdRutaDocumento.FileName
            wFile = New FileStream(OfdRutaDocumento.FileName, FileMode.Open, FileAccess.Read)
            PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
            wFile.Close()
        Else
            ResetPicImage()
        End If

    End Sub

    Private Sub btnEscanear_Click(sender As Object, e As EventArgs) Handles btnEscanear.Click
        Try
            Dim CD As New WIA.CommonDialog
            Dim F As WIA.ImageFile = CD.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType)
            Dim wFile As System.IO.FileStream
            Dim FileName As String = Today.ToString("ddMMyyyy") & TimeOfDay.ToString("hhmmss")

            F.SaveFile(Path.GetTempPath & FileName & "." & F.FileExtension)

            FilePath = Path.GetTempPath & FileName & "." & F.FileExtension

            wFile = New FileStream(FilePath, FileMode.Open, FileAccess.Read)
            PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
            wFile.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim PrintShow As New PrintDialog

        If FilePath = "" Then
            MessageBox.Show("No se pudo imprimir debido a que no existe documentación anexa al registro.", "Falta Anexar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            If PrintShow.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc.PrinterSettings = PrintShow.PrinterSettings
                PrintDoc.Print()
            End If
        End If
    End Sub
End Class
