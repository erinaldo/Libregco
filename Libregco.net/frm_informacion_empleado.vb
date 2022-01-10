Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class frm_informacion_empleado
    Dim IDEmpleado As New Label

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_informacion_empleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.CenterToParent()
            'Me.WindowState = CheckWindowState()
            CargarInformacionArticulo()
            RefrescarHistorial()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub RefrescarHistorial()
        Ds.Clear()
        cmd = New MySqlCommand("SELECT IDEntrada,Bitacora.IDEquipo,Fecha,AreaImpresion.ComputerName,Permisos.FormName FROM bitacora INNER JOIN AreaImpresion on Bitacora.IDEquipo=AreaImpresion.IDEquipo INNER JOIN Permisos on Bitacora.IDPermiso=Permisos.IDPermisos Where IDEmpleado='" + IDEmpleado.Text + "'", Con)
        Con.Open()
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Bitacora")
        DgvAccesos.DataSource = Ds
        DgvAccesos.DataMember = "Bitacora"
        Con.Close()
        PropiedadColumnsDgv()
        DgvAccesos.ClearSelection()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvAccesos
            .Columns(0).HeaderText = "Código Entrada"
            .Columns(0).Width = 120
            .Columns(1).Width = 90
            .Columns(2).Width = 200
            .Columns(3).HeaderText = "Equipo"
            .Columns(3).Width = 160
            .Columns(4).HeaderText = "Formulario"
            .Columns(4).Width = 170
        End With
    End Sub

    Private Sub CargarInformacionArticulo()
        IDEmpleado.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Apodo,Empleados.IDNacionalidad,Nacionalidad.Nacionalidad,Cedula,Empleados.IDGenero,Genero.Genero,FechaNacimiento,Empleados.IDProvincia,Provincias.Provincia,Empleados.IDMunicipio,Municipios.Municipio,Direccion,TelefonoPersonal,TelefonoHogar,CorreoElectronico,RutaFoto,Empleados.IDTipoNomina,TipoNomina.Descripcion as TipoNomina,Salario,Empleados.IDCargo,CargosEMp.Cargo,Empleados.IDPeriodoPago,PeriodoPago.Descripcion as PeriodoPago,Empleados.IDTanda,Tandas.Descripcion as Tandas,IDArs,IDAfp,FechaIngreso,Carnet,CuentaBancaria,CuotaPrestamo,ConsumoFlota,Empleados.IDPrivilegios,Privilegios.Privilegios,RutaCedula,Login,Status,Balance,Alertas,Conectado,Empleados.Nulo FROM" & SysName.Text & "empleados INNER JOIN Libregco.Nacionalidad on Empleados.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN Libregco.Genero on Empleados.IDGenero=Genero.IDGenero INNER JOIN Libregco.Provincias on Empleados.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Empleados.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.TipoNomina on Empleados.IDTipoNomina=TipoNomina.IDTipoNomina INNER JOIN Libregco.CargosEmp on Empleados.IDCargo=CargosEmp.IDCargo INNER JOIN Libregco.PeriodoPago on Empleados.IDPeriodoPago=PeriodoPago.IDPeriodoPago INNER JOIN Libregco.Tandas on Empleados.IDTanda=Tandas.IDTanda INNER JOIN Libregco.Privilegios on EMpleados.IDPrivilegios=Privilegios.IDPrivilegio Where Empleados.IDEmpleado='" + IDEmpleado.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Empleados")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds.Tables("Empleados")
        lblNombre.Text = (Tabla.Rows(0).Item("Nombre")) & " [" & (Tabla.Rows(0).Item("IDEmpleado")) & "]"

        If (Tabla.Rows(0).Item("Apodo")) <> "" Then
            lblAlias.Text = (Tabla.Rows(0).Item("Apodo"))
        Else
            Label2.Visible = False
            lblAlias.Visible = False
        End If

        lblGenero.Text = (Tabla.Rows(0).Item("Genero"))
        lblIdentificacion.Text = (Tabla.Rows(0).Item("Cedula"))
        lblCargo.Text = (Tabla.Rows(0).Item("Cargo"))
        lblNacionalidad.Text = (Tabla.Rows(0).Item("Nacionalidad"))
        lblNacimiento.Text = (Tabla.Rows(0).Item("FechaNacimiento"))

        If IsDate(Tabla.Rows(0).Item("FechaNacimiento")) Then
            Dim Fecha As Date = CDate(Tabla.Rows(0).Item("FechaNacimiento"))
            lblEdad.Text = CalcularFecha(Fecha, Today)

            Dim AñodeCumpleaños As New Date

            If DateSerial(Today.Year, Fecha.Month, Fecha.Day) < Today Then
                AñodeCumpleaños = DateSerial(Today.Year + 1, Fecha.Month, Fecha.Day)
            Else
                AñodeCumpleaños = DateSerial(Today.Year, Fecha.Month, Fecha.Day)
            End If

            lblCumpleanos.Text = CalcularFecha(Today, AñodeCumpleaños)
        End If

        lblDomicilio.Text = (Tabla.Rows(0).Item("Direccion")) & ", " & (Tabla.Rows(0).Item("Municipio")) & ", " & (Tabla.Rows(0).Item("Provincia"))
        lblTelefonoPersonal.Text = (Tabla.Rows(0).Item("TelefonoPersonal"))
        lblTelefonoHogar.Text = (Tabla.Rows(0).Item("TelefonoHogar"))
        lblCorreo.Text = (Tabla.Rows(0).Item("CorreoElectronico"))
        lblFechaIngreso.Text = (Tabla.Rows(0).Item("FechaIngreso"))

        If (Tabla.Rows(0).Item("RutaFoto")) <> "" Then
            If TypeConnection.Text = 1 Then
                If System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto")) Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream((Tabla.Rows(0).Item("RutaFoto")), FileMode.Open, FileAccess.Read)
                    PicEmpleado.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                End If
            End If
        Else
            PicEmpleado.Image = My.Resources.no_photo
        End If


    End Sub

    Private Sub PicEmpleado_Paint(sender As Object, e As PaintEventArgs) Handles PicEmpleado.Paint
        'Dim Figura As GraphicsPath = New GraphicsPath
        'Dim x, y, ancho, alto As Integer


        'ancho = 300
        'alto = 300

        'x = (PicEmpleado.Width - ancho) / 2
        'y = (PicEmpleado.Height - alto) / 2

        'Figura.AddEllipse(New Rectangle(x, y, ancho, alto))

        'PicEmpleado.Region = New Region(Figura)

        'e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
    End Sub

   
End Class