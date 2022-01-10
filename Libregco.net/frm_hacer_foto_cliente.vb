Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Imports System.Drawing.Drawing2D

Public Class frm_hacer_foto_cliente

    Dim tempCnt As Boolean         'check weather the roller is used or not

    Dim bm_dest As Bitmap
    Dim bm_source As Bitmap
    Dim i As Int16 = 0.5

#Region "Image Cropping"
    Dim cropX As Integer
    Dim cropY As Integer
    Dim cropWidth As Integer
    Dim cropHeight As Integer

    Dim oCropX As Integer
    Dim oCropY As Integer
    Dim cropBitmap As Bitmap

    Public cropPen As Pen
    Public cropPenSize As Integer = 1 '2
    Public cropDashStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid
    Public cropPenColor As Color = Color.Yellow
    Dim Offset As Point

    

    Dim tmppoint As Point

   

#End Region
    Private Sub frm_hacer_foto_cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarFoto()
    End Sub

    Private Sub CargarFoto()

        If Me.Owner.Name = frm_mant_clientes.Name Then
            Dim wFile As System.IO.FileStream
            wFile = New FileStream(lblPath.Text, FileMode.Open, FileAccess.Read)
            crobPictureBox.Image = System.Drawing.Image.FromStream(wFile)
            wFile.Close()
        End If

    End Sub

    Private Sub RotateBtn_Click(sender As System.Object, e As EventArgs) Handles RotateBtn.Click

        'RotateImage(PreviewPictureBox.Image, offset:=, angle:=90)
        crobPictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)

        PreviewPictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
        '(45, PreviewPictureBox.Image)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim tempFileName As String
        Dim svdlg As New SaveFileDialog()

        svdlg.Filter = "JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*"
        svdlg.FilterIndex = 1
        svdlg.RestoreDirectory = True

        If svdlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tempFileName = svdlg.FileName           'check the file exist else save the cropped image
            Try
                Dim img As Image = PreviewPictureBox.Image

                SavePhoto(img, tempFileName, 225)

                MessageBox.Show("La imagen ha sido guardada satisfactoriamente.", "Foto seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Catch exc As Exception

            End Try
        End If
    End Sub

    Public Function SavePhoto(ByVal src As Image, ByVal dest As String, ByVal w As Integer) As Boolean
        Try
            Dim imgTmp As System.Drawing.Image
            Dim imgFoto As System.Drawing.Bitmap

            imgTmp = src
            imgFoto = New System.Drawing.Bitmap(w, 225)
            Dim recDest As New Rectangle(0, 0, w, imgFoto.Height)
            Dim gphCrop As Graphics = Graphics.FromImage(imgFoto)
            gphCrop.SmoothingMode = SmoothingMode.HighQuality
            gphCrop.CompositingQuality = CompositingQuality.HighQuality
            gphCrop.InterpolationMode = InterpolationMode.High

            gphCrop.DrawImage(imgTmp, recDest, 0, 0, imgTmp.Width, imgTmp.Height, GraphicsUnit.Pixel)

            Dim myEncoder As System.Drawing.Imaging.Encoder
            Dim myEncoderParameter As System.Drawing.Imaging.EncoderParameter
            Dim myEncoderParameters As System.Drawing.Imaging.EncoderParameters

            Dim arrayICI() As System.Drawing.Imaging.ImageCodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
            Dim jpegICI As System.Drawing.Imaging.ImageCodecInfo = Nothing
            Dim x As Integer = 0
            For x = 0 To arrayICI.Length - 1
                If (arrayICI(x).FormatDescription.Equals("JPEG")) Then
                    jpegICI = arrayICI(x)
                    Exit For
                End If
            Next
            myEncoder = System.Drawing.Imaging.Encoder.Quality
            myEncoderParameters = New System.Drawing.Imaging.EncoderParameters(1)
            myEncoderParameter = New System.Drawing.Imaging.EncoderParameter(myEncoder, 60L)
            myEncoderParameters.Param(0) = myEncoderParameter
            imgFoto.Save(dest, jpegICI, myEncoderParameters)
            imgFoto.Dispose()
            imgTmp.Dispose()

        Catch ex As Exception

        End Try
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim openDlg As New System.Windows.Forms.OpenFileDialog
        openDlg.Filter = "JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|Bitmap Files (*.bmp)|*.bmp"
        If openDlg.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        If Not openDlg.FileName Is Nothing Then
            PreviewPictureBox.Image = System.Drawing.Bitmap.FromFile(openDlg.FileName)
            crobPictureBox.Image = System.Drawing.Bitmap.FromFile(openDlg.FileName)
            lblPath.Text = openDlg.FileName
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lblPath.Text = "" Then
            MessageBox.Show("No hay imagen anexa para hacer zoom.", "Falta Anexar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            crobPictureBox.Width += 300%
            crobPictureBox.Height += 300%
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If lblPath.Text = "" Then
            MessageBox.Show("No hay imagen anexa para hacer zoom.", "Falta Anexar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            crobPictureBox.Width -= 100%
            crobPictureBox.Height -= 100%
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tempFileName As String
        Dim svdlg As New SaveFileDialog()
        Dim wFile As System.IO.FileStream

        svdlg.Filter = "JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*"
        svdlg.FilterIndex = 1
        svdlg.RestoreDirectory = True

        If svdlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            tempFileName = svdlg.FileName           'check the file exist else save the cropped image
            Try
                Dim img As Image = PreviewPictureBox.Image

                SavePhoto(img, tempFileName, 225)

                wFile = New FileStream(tempFileName, FileMode.Open, FileAccess.Read)
                frm_mant_clientes.DgvRutasAnexas.Rows.Add("", "", "", tempFileName, "", GetFileSizes(tempFileName), System.Drawing.Image.FromStream(wFile))
                wFile.Close()
                Close()

            Catch exc As Exception

            End Try
        End If

    End Sub

    Private Sub crobPictureBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles crobPictureBox.MouseDown
        Try

            If rdbCortar.Checked = True Then
                If e.Button = Windows.Forms.MouseButtons.Left Then

                    cropX = e.X
                    cropY = e.Y

                    cropPen = New Pen(cropPenColor, cropPenSize)
                    cropPen.DashStyle = DashStyle.DashDotDot
                    Cursor = Cursors.Cross

                End If
                crobPictureBox.Refresh()

            Else

                Try
                    Cursor = Cursors.Hand
                    Offset = New Point(-e.X, -e.Y)
                Catch ex As Exception

                End Try
            End If

        Catch exc As Exception
        End Try
    End Sub


    Private Sub crobPictureBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles crobPictureBox.MouseMove
        Try
            If rdbCortar.Checked = True Then
                If crobPictureBox.Image Is Nothing Then Exit Sub

                If e.Button = Windows.Forms.MouseButtons.Left Then

                    crobPictureBox.Refresh()
                    cropWidth = e.X - cropX
                    cropHeight = e.Y - cropY
                    crobPictureBox.CreateGraphics.DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight)
                End If
                ' GC.Collect()

            Else

                If PanelPic.VerticalScroll.Visible = True Or PanelPic.HorizontalScroll.Visible = True Then
                    If e.Button = Windows.Forms.MouseButtons.Left Then
                        Dim Pos As Point = Me.PointToClient(MousePosition)
                        Pos.Offset(Offset.X, Offset.Y)
                        crobPictureBox.Location = Pos
                    End If
                Else
                    crobPictureBox.Width = 423
                    crobPictureBox.Height = 547
                    crobPictureBox.Location = New Point(0, 0)
                End If
            End If


        Catch exc As Exception

            If Err.Number = 5 Then Exit Sub
        End Try

    End Sub

    Private Sub crobPictureBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles crobPictureBox.MouseUp
        Try


            If rdbCortar.Checked = True Then
                Cursor = Cursors.Default
                Try

                    If cropWidth < 1 Then
                        Exit Sub
                    End If

                    Dim rect As Rectangle = New Rectangle(cropX, cropY, cropWidth, cropHeight)
                    Dim bit As Bitmap = New Bitmap(crobPictureBox.Image, crobPictureBox.Width, crobPictureBox.Height)

                    cropBitmap = New Bitmap(cropWidth, cropHeight)
                    Dim g As Graphics = Graphics.FromImage(cropBitmap)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                    g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                    g.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel)
                    PreviewPictureBox.Image = cropBitmap

                Catch exc As Exception
                End Try

            Else

            End If

        Catch exc As Exception

        End Try
    End Sub
End Class