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
Imports System.Net
Imports System.Xml
Imports System.Xml.XPath
Imports System.Text.RegularExpressions
Public Class frm_visualizar_mapas
    Private Const BrowserKeyPath As String = "\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION"

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim ReplaceDir As String
    Public URLseguimiento As New ArrayList
    Public numeroInstancia As Long

    Private Sub frm_visualizar_mapas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = CheckWindowState()
        CreateBrowserKey()
        CargarLibregco()

        If frm_mant_clientes.cbxProvincia.Text <> "" And frm_mant_clientes.cbxMunicipio.Text <> "" Then
            txtDireccion.Text = frm_mant_clientes.cbxMunicipio.Text & ", " & frm_mant_clientes.cbxProvincia.Text
        Else
            txtDireccion.Clear()
        End If
    End Sub

    Private Sub CreateBrowserKey(Optional ByVal IgnoreIDocDirective As Boolean = False)
        Dim basekey As String = Microsoft.Win32.Registry.CurrentUser.ToString
        Dim value As Int32
        Dim thisAppsName As String = My.Application.Info.AssemblyName & ".exe"
        ' Value reference: http://msdn.microsoft.com/en-us/library/ee330730%28v=VS.85%29.aspx
        ' IDOC Reference:  http://msdn.microsoft.com/en-us/library/ms535242%28v=vs.85%29.aspx
        Select Case (New WebBrowser).Version.Major
            Case 8
                If IgnoreIDocDirective Then
                    value = 8888
                Else
                    value = 8000
                End If
            Case 9
                If IgnoreIDocDirective Then
                    value = 9999
                Else
                    value = 9000
                End If
            Case 10
                If IgnoreIDocDirective Then
                    value = 10001
                Else
                    value = 10000
                End If

            Case 11
                If IgnoreIDocDirective Then
                    value = 11001
                Else
                    value = 11000
                End If
            Case Else
                Exit Sub
        End Select
        Microsoft.Win32.Registry.SetValue(Microsoft.Win32.Registry.CurrentUser.ToString & BrowserKeyPath, _
                                          Process.GetCurrentProcess.ProcessName & ".exe", _
                                          value, _
                                          Microsoft.Win32.RegistryValueKind.DWord)
    End Sub

    Private Sub RemoveBrowerKey()
        Dim key As Microsoft.Win32.RegistryKey
        key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(BrowserKeyPath.Substring(1), True)
        key.DeleteValue(Process.GetCurrentProcess.ProcessName & ".exe", False)
    End Sub

    Private Sub frm_visualizar_mapas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RemoveBrowerKey()
    End Sub

    Public Function ComprobarClaveAPI(ByVal clave As String) 'Comprobar clave de API Google Maps
        clave = "AIzaSyAbEdAWnc4yhK7VGK_Yy_mR6PGiJ3OKrCw "

        'Creamos la url con los datso
        Dim url = "https://maps.googleapis.com/maps/api/place/search/xml?location=0,0&radius=1000&sensor=false&key=" & clave
        Dim LatLong As New ArrayList()

        Dim req As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
        req.Timeout = 3000
        Dim valorRetorno As Boolean
        Try
            'Preparamos el archivo xml
            Dim res As System.Net.WebResponse = req.GetResponse()
            Dim responseStream As Stream = res.GetResponseStream()
            Dim NodeIter As XPathNodeIterator
            Dim docNav As New XPathDocument(responseStream)
            Dim nav = docNav.CreateNavigator

            Dim Exstatus As String
            Dim status As String = ""


            'Creamos los paths
            Exstatus = "PlaceSearchResponse/status"

            'Recorremos el xml
            NodeIter = nav.Select(Exstatus)
            While (NodeIter.MoveNext())
                status = (NodeIter.Current.Value)
                Exit While
            End While
            responseStream.Close()

            If status = "OK" Then
                valorRetorno = True
            Else
                valorRetorno = False
            End If

        Catch ex As Exception
            valorRetorno = False
        End Try
        Return valorRetorno
    End Function

    Public Function CodificacionGeografica(ByVal direccion As String, Optional ByVal regionBusqueda As String = "us") 'busca latitud/longitud a partir de dirección

        'Creamos la url con los datso
        Dim url = "http://maps.googleapis.com/maps/api/geocode/xml?address=" & direccion & "&region=" & regionBusqueda & "&sensor=false&language=es"
        Dim LatLong As New ArrayList()

        Dim req As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
        req.Timeout = 3000
        Try
            'Preparamos el archivo xml
            Dim res As System.Net.WebResponse = req.GetResponse()
            Dim responseStream As Stream = res.GetResponseStream()
            Dim NodeIter As XPathNodeIterator
            Dim docNav As New XPathDocument(responseStream)
            Dim nav = docNav.CreateNavigator

            Dim ExLatitud, ExLongitud, ExdatosDireccion As String

            'Creamos los paths
            ExLatitud = "GeocodeResponse/result/geometry/location/lat"
            ExLongitud = "GeocodeResponse/result/geometry/location/lng"
            ExdatosDireccion = "GeocodeResponse/result/formatted_address"
            'Recorremos el xml
            NodeIter = nav.Select(ExLatitud)
            While (NodeIter.MoveNext())
                LatLong.Add(NodeIter.Current.Value)
                Exit While
            End While

            NodeIter = nav.Select(ExLongitud)
            While (NodeIter.MoveNext())
                LatLong.Add(NodeIter.Current.Value)
                Exit While
            End While

            NodeIter = nav.Select(ExdatosDireccion)
            While (NodeIter.MoveNext())
                LatLong.Add(NodeIter.Current.Value)
                'Exit While
            End While
            responseStream.Close()
            Me.almacenarDatosHTTP(url, "Petición codificación geográfica directa", "OK") 'Almacenamos información
        Catch ex As Exception
            Me.almacenarDatosHTTP(url, "Petición codificación geográfica directa", "PERDIDO", ex.ToString) 'Almacenamos información
        End Try
        Return LatLong
    End Function

    Sub almacenarDatosHTTP(ByVal url As String, ByVal informacion As String, ByVal estatus As String, Optional ByVal excepcion As String = "sin excepción") 'Alamacén de información de las peticiones (con variable globales)
        numeroInstancia += 1
        URLseguimiento.Add(numeroInstancia)
        URLseguimiento.Add(Now)
        URLseguimiento.Add(estatus)
        URLseguimiento.Add(informacion)
        URLseguimiento.Add(url)
        URLseguimiento.Add(excepcion)
    End Sub

    Private Sub FindWorkPlaces()
        Try
            ReplaceDir = txtDireccion.Text.Replace(" ", "+") & "+" & txtPaís.Text.Replace(" ", "+")

            'Creamos variable para almacenar la url
            Dim urlMaps As String
            'Concatenamos la dirección con el Textbox
            If txtDireccion.Text = "" Then
                urlMaps = "http://maps.google.es/maps?q=" & "Santiago+De+Los+Caballeros+República+Dominicana"
            Else
                urlMaps = "http://maps.google.es/maps?q=" & ReplaceDir   'Creamos una variable direccion para que el WebBrowser lo pueda abrir puesto que no puede abrir directamente un string
            End If
            'Creamos una variable direccion para que el WebBrowser lo pueda abrir puesto que no puede abrir directamente un string
            Dim direccion As New Uri(urlMaps)
            'ASignamos como URL la direccion
            WebBrow.Url = direccion

            lblStatusBar.Text = urlMaps
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDireccion_TextChanged(sender As Object, e As EventArgs) Handles txtDireccion.TextChanged
        FindWorkPlaces()
    End Sub

    Private Sub txtPaís_TextChanged(sender As Object, e As EventArgs) Handles txtPaís.TextChanged
        FindWorkPlaces()
    End Sub

    Private Sub CargarLibregco()
      PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim region = "us" 'Region de búsqueda
        Dim direccionString As ArrayList

        ReplaceDir = txtDireccion.Text.Replace(" ", "+") & "+" & txtPaís.Text.Replace(" ", "+")

        direccionString = CodificacionGeografica(ReplaceDir, region) 'Recibimos datos

        Try
            txtLatitud.Text = direccionString(0)
            txtLongitud.Text = direccionString(1)
        Catch
            txtLatitud.Text = "El servidor no responde" 'Si no hay datos
            txtLongitud.Text = "El servidor no responde" 'Si no hay datos
        End Try
    End Sub
End Class