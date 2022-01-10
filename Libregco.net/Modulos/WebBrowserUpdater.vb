Imports Microsoft.Win32
''' <summary>
''' Creates registry entry to allow standard WebBrowser control to operate at maximum compatibility instead of IE7
''' NOTE: the entry is specific to an application so must be done for any program that uses WebBrowser
''' </summary>
''' <remarks></remarks>
Public Class WebBrowserUpdater

    Public Shared Sub FixBrowserVersion()
        Try
            Dim BrowserVer As Integer, RegVal As Integer

            ' get the installed IE version
            Using Wb As New WebBrowser()
                BrowserVer = Wb.Version.Major
            End Using

            ' set the appropriate IE version
            If BrowserVer >= 11 Then
                RegVal = 11001
            ElseIf BrowserVer = 10 Then
                RegVal = 10001
            ElseIf BrowserVer = 9 Then
                RegVal = 9999
            ElseIf BrowserVer = 8 Then
                RegVal = 8888
            Else
                RegVal = 7000
            End If

            ' set the actual key
            Using Key As RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", RegistryKeyPermissionCheck.ReadWriteSubTree)
                If Key.GetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe") Is Nothing Then
                    Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class
