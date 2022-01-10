Imports System.Drawing
Imports System.Drawing.Drawing2D
Module Aplicaciones
    Friend ControlSuperClave As String

    Sub LlamarCalculadora()
        Dim Proceso As New Process()
        Proceso.StartInfo.FileName = "Calc.exe"
        Proceso.StartInfo.Arguments = ""
        Proceso.Start()
    End Sub

    Sub LlamarPaint()
        Dim Proceso As New Process()
        Proceso.StartInfo.FileName = "MSPaint.exe"
        Proceso.StartInfo.Arguments = ""
        Proceso.Start()
    End Sub

    Function CalcularFecha(ByVal dDesde As Date, ByVal dHasta As Date)
        Dim iAnoDesde As Integer = dDesde.Year
        Dim iAnoHasta As Integer = dHasta.Year
        Dim iMesDesde As Integer = dDesde.Month
        Dim iMesHasta As Integer = dHasta.Month
        Dim iDiaDesde As Integer = dDesde.Day
        Dim iDiaHasta As Integer = dHasta.Day
        Dim Años, Meses, Dias As Integer

        If (iDiaHasta < iDiaDesde) Then
            iDiaHasta = iDiaHasta + 30
            iMesHasta = iMesHasta - 1
        End If

        Dias = iDiaHasta - iDiaDesde

        If (iMesHasta < iMesDesde) Then
            iMesHasta = iMesHasta + 12
            iAnoHasta = iAnoHasta - 1
        End If

        Meses = iMesHasta - iMesDesde
        Años = iAnoHasta - iAnoDesde

        'Retornamos los valores en una cadena string
        Dim AñoString, MesString, DiaString, A1, A2 As String
        If Años = 0 Then
            AñoString = ""
        ElseIf Años = 1 Then
            AñoString = Años & " año"
        Else
            AñoString = Años & " años"
        End If

        If Meses = 0 Then
            MesString = ""
        ElseIf Meses = 0 And Dias = 0 Then
        ElseIf Meses = 1 Then
            MesString = Meses & " mes"
        Else
            MesString = Meses & " meses"
        End If

        If Dias = 0 Then
            DiaString = ""
        ElseIf Dias = 1 Then
            DiaString = Dias & " día"
        Else
            DiaString = Dias & " días"
        End If

        If AñoString <> "" And MesString <> "" And DiaString <> "" Then
            A1 = ", "
        ElseIf AñoString = "" Then
            A1 = ""
        ElseIf MesString = "" And DiaString = "" Then
            A1 = ""
        Else
            A1 = " y "
        End If

        If AñoString <> "" And MesString <> "" And DiaString <> "" Then
            A2 = " y "
        ElseIf AñoString = "" And MesString <> "" And DiaString <> "" Then
            A2 = " y "
        ElseIf MesString = "" And DiaString = "" Then
            A2 = ""
        End If

        Return (AñoString & A1 & MesString & A2 & DiaString & ".")

    End Function

    Sub LlamarBlockNotas()
        Dim Proceso As New Process()
        Proceso.StartInfo.FileName = "Notepad.exe"
        Proceso.StartInfo.Arguments = ""
        Proceso.Start()
    End Sub

    Sub LlamarWordPad()
        Dim Proceso As New Process()
        Proceso.StartInfo.FileName = "Wordpad.exe"
        Proceso.StartInfo.Arguments = ""
        Proceso.Start()
    End Sub

    Sub LlamarPrestacionesLaborales()
        Dim Proceso As New Process()
        Proceso.StartInfo.FileName = "http://calculo.mt.gob.do"
        Proceso.StartInfo.Arguments = ""
        Proceso.Start()
    End Sub

    Sub LlamarWebTSS()
        Dim Proceso As New Process()
        Proceso.StartInfo.FileName = "http://www.tss.gov.do/"
        Proceso.StartInfo.Arguments = ""
        Proceso.Start()
    End Sub

    Public Function BlendColors(ByVal c1 As Color, ByVal c2 As Color) As Color
        Return Color.FromArgb((CInt(c1.A) + CInt(c2.A)) \ 2, _
            (CInt(c1.R) + CInt(c2.R)) \ 2, _
            (CInt(c1.G) + CInt(c2.G)) \ 2, _
            (CInt(c1.B) + CInt(c2.B)) \ 2)
    End Function

    Function MakeRounded(ByVal Img As Image) As Bitmap
        Try
            Using bm As New Bitmap(Img.Width, Img.Height)
                Using grx2 As Graphics = Graphics.FromImage(bm)
                    grx2.SmoothingMode = SmoothingMode.AntiAlias
                    Using tb As New TextureBrush(Img)
                        tb.TranslateTransform(0, 0)
                        Using gp As New GraphicsPath
                            gp.AddEllipse(0, 0, Img.Width, Img.Height)
                            grx2.FillPath(tb, gp)
                        End Using
                    End Using
                End Using
                Return Img

            End Using
        Catch ex As Exception

        End Try
    End Function

    Sub MakeRoundedImage(ByVal Img As Image, ByVal PicBox As PictureBox)
        Try
            Using bm As New Bitmap(Img.Width, Img.Height)
                Using grx2 As Graphics = Graphics.FromImage(bm)
                    grx2.SmoothingMode = SmoothingMode.AntiAlias
                    Using tb As New TextureBrush(Img)
                        tb.TranslateTransform(0, 0)
                        Using gp As New GraphicsPath
                            gp.AddEllipse(0, 0, Img.Width, Img.Height)
                            grx2.FillPath(tb, gp)
                        End Using
                    End Using
                End Using
                If PicBox.Image IsNot Nothing Then PicBox.Image.Dispose()
                PicBox.Image = New Bitmap(bm)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Sub MakeRoundedImageToPanel(ByVal Img As Image, ByVal PicBox As Panel)
        Try
            Using bm As New Bitmap(Img.Width, Img.Height)
                Using grx2 As Graphics = Graphics.FromImage(bm)
                    grx2.SmoothingMode = SmoothingMode.AntiAlias
                    Using tb As New TextureBrush(Img)
                        tb.TranslateTransform(0, 0)
                        Using gp As New GraphicsPath
                            gp.AddEllipse(0, 0, Img.Width, Img.Height)
                            grx2.FillPath(tb, gp)
                        End Using
                    End Using
                End Using
                If PicBox.BackgroundImage IsNot Nothing Then PicBox.BackgroundImage.Dispose()
                PicBox.BackgroundImage = New Bitmap(bm)
            End Using
        Catch ex As Exception
        End Try
    End Sub
End Module
