Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Net
Imports System.IO

Public Class frm_LoginSistema
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet
    Dim TablesImage As New DataTable
    Dim RandomValue, CheckRandom As Integer
    Dim DatabaseChecked As Boolean = False
    Private ActualVersion, DataIngress As String
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal WParam As Integer, ByVal Iparam As Integer) As Integer
    Dim countConexiones As Integer = 0

    Private Sub frm_LoginSistema_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Activate()
        CheckRegionalWindows
        CheckConnectionMySQL()

        If DatabaseChecked = True Then
            CargarPathServidor()
            UseDoubleBuffer()
            ActualizarDatos()
            CargarconfiguracionLibregco()
            CargarEquipo()
            BuscarActualizaciones()
            CheckNewBussiness()
            CheckSecurePrinting()
        End If
    End Sub

    Sub CheckRegionalWindows()
        MessageBox.Show("asd")
        If CDate(Today).ToString <> Today.ToString("dd/MM/yyyy") Then
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy")
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortTime", "hh:mm tt")
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sDecimal", ".")
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sThousand", ",")
        End If
    End Sub

    Sub CheckSecurePrinting()
        'Try
        If DTAreaImpresion.Rows.Count > 0 Then
            Ds.Dispose()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT * FROM" & SysName.Text & "bitacora INNER JOIN" & SysName.Text & "AreaImpresion on Bitacora.IDEquipo=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Empleados on Bitacora.IDEmpleado=Empleados.IDEmpleado where IDPermiso=1 AND Bitacora.IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "' AND Bitacora.Abierta=1 and PrintingSecure=1 ORDER BY IDEntrada DESC LIMIT 1", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "SecurePrinting")
            ConMixta.Close()

            If Ds.Tables("SecurePrinting").Rows.Count = 1 Then
                ConMixta.Open()
                cmd = New MySqlCommand("Select IDEmpleado,Nombre,Apodo,Empleados.IDNacionalidad,Nacionalidad.Nacionalidad,Cedula,FechaNacimiento,Empleados.IDMunicipio,Municipios.Municipio,Municipios.IDProvincia,Provincias.Provincia,Empleados.Direccion,Empleados.TelefonoPersonal,Empleados.TelefonoHogar,Empleados.IDGenero,Genero.Genero,Empleados.CorreoElectronico,CorreoVerificado,ClaveVerificacion,Login,Password,FactorNumerico,FechaPassword,RutaFoto,GrayPictureFile,RutaCedula,ImagenChat,Cargo,Alertas,Empleados.IDSucursal,Empleados.IDAlmacen,Almacen.Almacen,Sucursal.Sucursal,Sucursal.Municipio,Sucursal.Direccion as DireccionSucursal,Sucursal.Telefono,Sucursal.Telefono1,Sucursal.Telefono2,Sucursal.Fax,Sucursal.Email as CorreoSucursal,Empleados.IDTipoNomina,TipoNomina.Descripcion as TipoNomina,Empleados.Nulo,Empleados.Disponible,Empleados.Salario,Empleados.Cotizable,Empleados.IDCargo,CargosEmp.Cargo,Puesto,Empleados.IDPeriodoPago,PeriodoPago.Descripcion as PeriodoPago,Empleados.IDTanda,Tandas.Descripcion as Tanda,Empleados.IDArs,ARS.Descripcion as ARS,Empleados.IDAFP,AFP.Descripcion as AFP,Empleados.FechaIngreso,Carnet,CuentaBancaria,CuotaPrestamo,CuotaCuenta,ConsumoFlota,CobrarTSS,SeguroComplementario,CobrarISR,Empleados.IDPrivilegios,Privilegios.Privilegios,HabilitarNomina,IDChatStatus,Empleados.Status,Empleados.Balance,Empleados.Conectado,VacacionInicia,VacacionTermina,ColorMode,MostrarenTope,HabilitarNotificaciones,MostrarContenido,MostrarConsejos,BloqueoInactividad,IDPrivilegios,NotificacionStart,AgendaFilePath,Memos,NotificacionStart,EsVendedor,EsCobrador from" & SysName.Text & "Empleados INNER JOIN Libregco.CargosEmp ON Empleados.IDCargo=CargosEmp.IDCargo INNER JOIN Libregco.Genero on Empleados.IDGenero=Genero.IDGenero INNER JOIN Libregco.Nacionalidad on Empleados.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN Libregco.Municipios on Empleados.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.Provincias on Municipios.IDProvincia=Provincias.IDProvincia INNER JOIN" & SysName.Text & "Almacen on Empleados.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.TipoNomina on Empleados.IDTipoNomina=TipoNomina.IDTipoNomina INNER JOIN Libregco.PeriodoPago on Empleados.IDPeriodoPago=PeriodoPago.IDPeriodoPago INNER JOIN Libregco.Tandas on Empleados.IDTanda=Tandas.IDTanda INNER JOIN Libregco.ARS ON Empleados.IDARs=Ars.IDARS INNER JOIN Libregco.AFP ON Empleados.IDAFP=AFP.IDAFP INNER JOIN Libregco.Privilegios on Empleados.IDPrivilegios=Privilegios.IDPrivilegio Where Empleados.IDEmpleado='" + Ds.Tables("SecurePrinting").Rows(0).Item("IDEmpleado").ToString + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Empleados")
                ConMixta.Close()

                DTEmpleado = Ds.Tables("Empleados")

                ' PanelLogin.Visible = False

                lblInformacion.Text = "Ha ocurrido un error en la ultima sesión." & vbNewLine & "Recuperando sesión..."
                lblInformacion.ForeColor = Color.Black
                frm_inicio.Button4.Text = My.Computer.Name
                txtUser.Text = (DTEmpleado.Rows(0).Item("Login"))
                txtPassword.Text = (DTEmpleado.Rows(0).Item("Password"))
                PasarCredencial()

                BarradeProgreso.Value = BarradeProgreso.Value + 40
                lblInformacion.ForeColor = btn_Iniciar.BackColor
                lblInformacion.Text = "Insertado registro a bitáctora..."
                lblInformacion.Refresh()


                lblInformacion.Text = "Verificando status de la base de datos..."
                BarradeProgreso.Value = BarradeProgreso.Value + 35
                lblInformacion.Refresh()


                lblInformacion.Text = "Transmitiendo credenciales al sistema..."
                lblInformacion.Refresh()

                BarradeProgreso.Value = BarradeProgreso.Value + 25

                lblInformacion.Text = "Se ha iniciado el sistema satisfactoriamente."
                lblInformacion.Refresh()
                BarradeProgreso.Value = BarradeProgreso.Maximum
                AverageColor = btn_Iniciar.BackColor

                ChangetoFalsePrintSecureEmployee()
                Ds.Dispose()

                frm_inicio.Show()
                Me.Close()
            End If

        End If

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Function readNthLine(fileAndPath As String, lineNumber As Integer) As String
        Dim nthLine As String = Nothing
        Dim n As Integer
        Try
            Using sr As StreamReader = New StreamReader(fileAndPath)
                n = 0
                Do While (sr.Peek() >= 0) And (n < lineNumber)
                    sr.ReadLine()
                    n += 1
                Loop
                If sr.Peek() >= 0 Then
                    nthLine = sr.ReadLine()
                End If
            End Using
        Catch ex As Exception
            Throw
        End Try
        Return nthLine
    End Function

    Sub CheckConnectionMySQL()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Determinacion de Host
        Try
            If IO.File.Exists(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt")) Then
                Dim lines() As String = IO.File.ReadAllLines(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"))
                Dim ReadedLine As String = readNthLine(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"), CInt(lines(0).Substring(lines(0).IndexOf("=") + 1)) + 1)

                Dim obj As StreamReader = New StreamReader(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"))
                Do Until obj.ReadLine Is Nothing
                    countConexiones = countConexiones + 1
                Loop
                countConexiones = countConexiones - 2
                obj.Close()

                HostNameServer = Before(Between(ReadedLine, "HostName=", ";"), ";")
                DDNS = Before(Between(ReadedLine, "DDNS=", ";"), ";")
                UserServer = Between(ReadedLine, "User=", ";")
                Port = After(ReadedLine, "Port=")
            Else
                'Creacion de server host
                frm_introduccion_servidor.ShowDialog(Me)

                Dim lines() As String = IO.File.ReadAllLines(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"))
                Dim ReadedLine As String = readNthLine(IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Libregco Docs", "AppPath.txt"), CInt(lines(0).Substring(lines(0).IndexOf("=") + 1)) + 1)

                HostNameServer = Before(Between(ReadedLine, "HostName=", ";"), ";")
                DDNS = Before(Between(ReadedLine, "DDNS=", ";"), ";")
                UserServer = Between(ReadedLine, "User=", ";")
                Port = After(ReadedLine, "Port=")
            End If

        Catch ex As Exception
            DatabaseChecked = False
            frm_mensaje_desconexion.ShowDialog()
            Me.Visible = False
            Application.Exit()
        End Try




        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Intentos de conexión
        Dim CLocal As String = "database=Libregco" & ";server=" & HostNameServer & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"
        Dim CnOnline As String = "database=Libregco;server=" & DDNS & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim Dta As String
        Dim ConOnline As New MySqlConnection(CnOnline) 'Conexión de Online
        Dim ConLocal As New MySqlConnection(CLocal)

        'Intentando conexión local
        Try
            ConLocal.Open()
            cmd = New MySqlCommand("Select Now()", ConLocal)
            Dta = Convert.ToString(cmd.ExecuteScalar())
            ConLocal.Close()

            TypeConnection.Text = 1
            lblConnection.Text = "CONEXIÓN LOCAL"

            CnString = "database=Libregco;server=" & HostNameServer & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"
            CnString1 = "database=Libregco_Main;server=" & HostNameServer & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"
            CnUtilitarios = "database=Libregco_Utilitarios;server=" & HostNameServer & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"
            CnGeneral = "server=" & HostNameServer & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"

            DatabaseChecked = True
            GoTo Denominacion

        Catch ex As Exception
            DatabaseChecked = False
            ConLocal.Close()
        End Try

        'Intentando conexión online
        Try
            ConOnline.Open()
            cmd = New MySqlCommand("Select Now()", ConOnline)
            Dta = Convert.ToString(cmd.ExecuteScalar())
            ConOnline.Close()

            TypeConnection.Text = 2
            lblConnection.Text = "CONEXIÓN EN LÍNEA"

            CnString = "database=Libregco;server=" & DDNS & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"
            CnString1 = "database=Libregco_Main;server=" & DDNS & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"
            CnUtilitarios = "database=Libregco_Utilitarios;server=" & DDNS & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"
            CnGeneral = "server=" & DDNS & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"

            lblInformacion.ForeColor = SystemColors.Highlight
            lblInformacion.Text = "IMPORTANTE! " & vbNewLine & "La conexión que está utilizando es remota."

            DatabaseChecked = True
            GoTo Denominacion

        Catch ex As Exception
            DatabaseChecked = False
            ConOnline.Close()
            frm_mensaje_desconexion.ShowDialog()

            Me.Visible = False
            Application.Exit()

        End Try

Denominacion:
        Con = New MySqlConnection(CnString)  'Conexión a base de datos seleccionada
        ConErrores = New MySqlConnection(CnString)
        ConLibregco = New MySqlConnection(CnString) 'Conexion a Libregco
        ConLibregcoMain = New MySqlConnection(CnString1) 'Conexion a LibregcoMain
        ConMixta = New MySqlConnection(CnGeneral) 'Conexion mixta
        ConUtilitarios = New MySqlConnection(CnUtilitarios) 'Conexión de utilitarios
        ConTemporal = New MySqlConnection(CnGeneral) 'Conexion mixta para procesos en segundo plano

    End Sub

    Private Sub BuscarActualizaciones()
        Try
            If TypeConnection.Text = 1 Then
                'Conseguir la versión del ejecutable

                ConUtilitarios.Open()
                cmd = New MySqlCommand("Select IDBuild FROM libregco_utilitarios.version_sys where concat(VersionMayor,'.',VersionMenor,'.',VersionCompilacion,'.',VersionVersion)='" + ActualVersion + "'", ConUtilitarios)
                IDBuild.Text = Convert.ToString(cmd.ExecuteScalar())
                ConUtilitarios.Close()

                If IDBuild.Text = "" Then
                    ConUtilitarios.Open()
                    cmd = New MySqlCommand("Select IDBuild FROM libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
                    IDBuild.Text = Convert.ToString(cmd.ExecuteScalar())
                    ConUtilitarios.Close()
                Else

                    Dim DsTmp As New DataSet

                    DsTmp.Clear()
                    ConUtilitarios.Open()
                    cmd = New MySqlCommand("Select * from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTmp, "version_sys")
                    ConUtilitarios.Close()

                    Dim Tabla As DataTable = DsTmp.Tables("version_sys")

                    If CInt(Tabla.Rows(0).Item("IDBuild")) > CInt(IDBuild.Text) Then
                        Dim ExistFile As Boolean = System.IO.File.Exists("\\" & PathServidor.Text & Tabla.Rows(0).Item("Locacion"))

                        If ExistFile = True Then       'Verifico si existe
                            Dim PathInfo As New System.IO.FileInfo("\\" & PathServidor.Text & Tabla.Rows(0).Item("Locacion"))

                            If System.IO.Directory.Exists("C:\" & PathInfo.Directory.Name) Then
                            Else
                                frm_copiar_actualizacion_sys.var_originfilepath = "\\" & PathServidor.Text & Tabla.Rows(0).Item("LocacionDirectorio")
                                frm_copiar_actualizacion_sys.var_filepathexecutable = "\\" & PathServidor.Text & Tabla.Rows(0).Item("Locacion")
                                frm_copiar_actualizacion_sys.ShowDialog(Me)
                            End If
                        End If

                        Tabla.Dispose()
                    End If
                End If
            End If



        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


    Sub CheckNewBussiness()
        'Try
        Dim Razon, Sucursal, Almacen, Usuario, Moneda As String

        'Si el sistema ha sido abierto cargo la configuracion de la empresa
        If IsDate(DTConfiguracion.Rows(101 - 1).Item("Value1Var").ToString()) Then
            CargarConfiguracionEmpresa()

            NuevaEstructuracion = False
        Else
            NuevaEstructuracion = True

            Con.Open()
            ConLibregco.Open()

            cmd = New MySqlCommand("Select count(RazonSocial.IDRazon) from razonsocial", Con)
            If CInt(Convert.ToString(cmd.ExecuteScalar())) = 0 Then
                Razon = "• "
            Else
                Razon = "√ "
            End If

            cmd = New MySqlCommand("Select count(Sucursal.IDSucursal) from Sucursal where Nulo=0", Con)
            If CInt(Convert.ToString(cmd.ExecuteScalar())) = 0 Then
                Sucursal = "• "
            Else
                Sucursal = "√ "
            End If

            cmd = New MySqlCommand("Select count(Almacen.IDAlmacen) from Almacen where Desactivar=0", Con)
            If CInt(Convert.ToString(cmd.ExecuteScalar())) = 0 Then
                Almacen = "• "
            Else
                Almacen = "√ "
            End If

            cmd = New MySqlCommand("Select count(Empleados.IDEmpleado) from Empleados", Con)
            If CInt(Convert.ToString(cmd.ExecuteScalar())) = 0 Then
                Usuario = "• "
            Else
                Usuario = "√ "
            End If

            cmd = New MySqlCommand("Select count(IDTipoMoneda) from TipoMoneda", ConLibregco)
            If CInt(Convert.ToString(cmd.ExecuteScalar())) = 0 Then
                Moneda = "• "
            Else
                Moneda = "√ "
            End If

            Con.Close()
            ConLibregco.Close()

            MessageBox.Show("Bienvenido al sistema de gestión empresarial integral Libregco®" & vbNewLine & vbNewLine & "Para dar inicio al sistema es necesario validar algunos registros de control de información. Por favor complete la información integramente ya que los datos quedarán prefijados permanentemente en la base de datos." & vbNewLine & vbNewLine & "Datos a prefijar" & vbNewLine & vbNewLine & Razon & "Razón social del negocio." & vbNewLine & Sucursal & "Sucursales." & vbNewLine & Almacen & "Almacenes." & vbNewLine & Usuario & "Usuarios administrativos" & vbNewLine & Moneda & "Tipo de moneda.", "Establecimiento de datos prefijados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            'Registro de razon social
            Con.Open()
            cmd = New MySqlCommand("Select count(RazonSocial.IDRazon) from razonsocial", Con)
            DataIngress = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If CInt(DataIngress) = 0 Then
RazonSocial:
                frm_razon_social.ShowDialog(Me)

                Con.Open()
                cmd = New MySqlCommand("Select count(RazonSocial.IDRazon) from razonsocial", Con)
                DataIngress = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If CInt(DataIngress) = 0 Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Registre el nombre comercial y la información de su negocio para continuar con el proceso de establecimiento de los datos prefijados.", "Aún no se encuentra un registro de razón social", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Ok Then
                        GoTo RazonSocial
                    Else
                        MessageBox.Show("Ha cancelado el proceso de establecimiento de datos prefijados." & vbNewLine & vbNewLine & "El sistema se cerrará automáticamente.", "Proceso cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Close()
                        Exit Sub
                    End If
                End If
            End If

            CargarEmpresa()

            'Registro de sucursal
            Con.Open()
            cmd = New MySqlCommand("Select count(Sucursal.IDSucursal) from Sucursal where Nulo=0", Con)
            DataIngress = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If CInt(DataIngress) = 0 Then
Sucursal:
                frm_mant_sucursal.ShowDialog(Me)

                Con.Open()
                cmd = New MySqlCommand("Select count(Sucursal.IDSucursal) from Sucursal where Nulo=0", Con)
                DataIngress = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If CInt(DataIngress) = 0 Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Registre el nombre de su negocio como sucursal, para delimitar las acciones comerciales en caso de que su negocio se expande." & vbNewLine & vbNewLine & "La información de la sucursal sirve para hacer un control fiscal general de las operaciones del sistema, y además será la información que será mostrada en la mayoría de los reportes del sistema." & vbNewLine & vbNewLine & "Por favor complete integramente los campos requeridos.", "Aún no se encuentra un registro de sucursal", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Ok Then
                        GoTo Sucursal
                    Else
                        MessageBox.Show("Ha cancelado el proceso de establecimiento de datos prefijados." & vbNewLine & vbNewLine & "El sistema se cerrará automáticamente.", "Proceso cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Close()
                        Exit Sub
                    End If
                End If
            End If

            'Registro de almacen
            Con.Open()
            cmd = New MySqlCommand("Select count(Almacen.IDAlmacen) from Almacen where Desactivar=0", Con)
            DataIngress = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If CInt(DataIngress) = 0 Then
Almacen:
                frm_mant_almacen.ShowDialog(Me)

                Con.Open()
                cmd = New MySqlCommand("Select count(Almacen.IDAlmacen) from Almacen where Desactivar=0", Con)
                DataIngress = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If CInt(DataIngress) = 0 Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Registre la/las subdivisione(s) de las sucursales a través de los almacenes. Esta opción hace posible los cálculos de inventario y los rastreos de los puntos de emisión de documentos y registros del sistema." & vbNewLine & vbNewLine & "La información del almacén servirán de base para la implementación de NCF estructurados por puntos de emisión y darán paso a la configuración de los mismos.", "Aún no se encuentra un registro de almacén", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Ok Then
                        GoTo Almacen
                    Else
                        MessageBox.Show("Ha cancelado el proceso de establecimiento de datos prefijados." & vbNewLine & vbNewLine & "El sistema se cerrará automáticamente.", "Proceso cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Close()
                        Exit Sub
                    End If
                End If
            End If

            'Usuarios administrativos
            Con.Open()
            cmd = New MySqlCommand("Select count(Empleados.IDEmpleado) from Empleados", Con)
            DataIngress = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If CInt(DataIngress) = 0 Then
Usuarios:
                frm_mant_empleados.ShowDialog(Me)

                Con.Open()
                cmd = New MySqlCommand("Select count(Empleados.IDEmpleado) from Empleados", Con)
                DataIngress = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If CInt(DataIngress) = 0 Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Registre el primer usuario y/o empleado administrador de su negocio." & vbNewLine & vbNewLine & "Este empleado será hábil para crear y modificar estructuras de configuración del sistema, registrar otros usuarios y otorgar permisos de acceso, creación y modificación de registros.", "Registrar empleado administrador", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Ok Then
                        GoTo Usuarios
                    Else
                        MessageBox.Show("Ha cancelado el proceso de establecimiento de datos prefijados." & vbNewLine & vbNewLine & "El sistema se cerrará automáticamente.", "Proceso cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Close()
                        Exit Sub
                    End If
                Else
                    Ds.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("Select * from Empleados where IDEmpleado= (Select Max(IDEmpleado) from Empleados)", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "Empleados")
                    Con.Close()

                    Dim Tabla As DataTable = Ds.Tables("Empleados")

                    frm_permisos_usuarios.Show(Me)
                    frm_permisos_usuarios.txtIDUsuario.Text = (Tabla.Rows(0).Item("IDEmpleado"))
                    frm_permisos_usuarios.txtUsuario.Text = (Tabla.Rows(0).Item("Nombre"))
                    frm_permisos_usuarios.chkTodos.Checked = True
                    frm_permisos_usuarios.btnGuardar.PerformClick()
                End If
            End If

            'Monedas
            ConLibregco.Open()
            cmd = New MySqlCommand("Select count(IDTipoMoneda) from TipoMoneda", ConLibregco)
            DataIngress = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

            If CInt(DataIngress) = 0 Then
Monedas:
                frm_mant_tipo_moneda.ShowDialog(Me)

                ConLibregco.Open()
                cmd = New MySqlCommand("Select count(IDTipoMoneda) from TipoMoneda", ConLibregco)
                DataIngress = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()

                If CInt(DataIngress) = 0 Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Registre el/los tipos de moneda que serán hábiles para las transacciones de su negocio. Actualmente el sistema está preestablecido para trabajar con el peso dominicano RD$. " & vbNewLine & vbNewLine & "La implementación de diversas monedas facilita la simplificación de transacciones llevadas al sistema.", "Registrar monedas hábiles", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Ok Then
                        GoTo Monedas
                    Else
                        MessageBox.Show("Ha cancelado el proceso de establecimiento de datos prefijados." & vbNewLine & vbNewLine & "El sistema se cerrará automáticamente.", "Proceso cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Close()
                        Exit Sub
                    End If
                End If
            End If

            sqlQ = "UPDATE Configuracion SET Value1Var='" + Today.ToString("yyyy-MM-dd") + "' WHERE IDConfiguracion=101"
            GuardarDatos()

            MessageBox.Show("Felicidades.!" & vbNewLine & vbNewLine & "Ya ha terminado de configurar los requisitos mínimos de control, para empezar a trabajar en el sistema.", "Configuración finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            NuevaEstructuracion = False
            CargarConfiguracionEmpresa()
        End If


        '  Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        '  End Try
    End Sub

    Sub CargarPathServidor()
        Try
            If TypeConnection.Text = 1 Then
                ConUtilitarios.Open()
                cmd = New MySqlCommand("Select Value from Libregco_Utilitarios.Ajustes where IDAjuste=1", ConUtilitarios)
                PathServidor.Text = Convert.ToString(cmd.ExecuteScalar())
                ConUtilitarios.Close()

                Dim dir As New IO.DirectoryInfo("\\" & PathServidor.Text & "\Libregco")

                If dir.Exists Then
                Else
                    Dim Mensaje, Titulo, DefaultValue As String
                    Dim MyValue As Object

                    Mensaje = "La UNC o la localización de recursos de red con la denominación " & "'\\" & PathServidor.Text & "\Libregco' no coincide con los recursos suministrados en la base de datos. Establezca el nombre del servidor para poder hacer la conexión."
                    Titulo = "Escriba el nombre del servidor"
                    DefaultValue = PathServidor.Text

                    MyValue = InputBox(Mensaje, Titulo, DefaultValue)

                    If MyValue = "" Then
                        MessageBox.Show("Ha cancelado un proceso vital al intentar el establecimiento de conexión al servidor." & vbNewLine & vbNewLine & "A continuación el sistema va a cerrase.", "El sistema se cerrará", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Application.Exit()

                    Else
                        Dim ServerPath As New Label
                        ServerPath.Text = MyValue

                        Dim dir1 As New IO.DirectoryInfo("\\" & MyValue & "\Libregco")

                        If dir1.Exists Then

                            PathServidor.Text = ServerPath.Text

                            ConUtilitarios.Open()
                            sqlQ = "UPDATE libregco_utilitarios.ajustes SET Value='" + Replace(ServerPath.Text, "\", "") + "' WHERE IDAjuste=1"
                            cmd = New MySqlCommand(sqlQ, ConUtilitarios)
                            cmd.ExecuteNonQuery()
                            ConUtilitarios.Close()

                            MessageBox.Show("La UNC o localización de recursos de red establecida fue encontrada satisfactoriamente.", "UNC actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                        Else

                            MessageBox.Show("La UNC o localización de recursos de red escrita no fue encontrada como un recurso de red hábil." & vbNewLine & vbNewLine & "El sistema va a cerrase.", "El sistema se cerrará", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            Application.Exit()
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Sub UseDoubleBuffer()
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.UserPaint Or
                    ControlStyles.OptimizedDoubleBuffer,
                    True)
        Me.UpdateStyles()
        DoubleBuffered = True
    End Sub

    Private Sub CargarConfiguracionEmpresa()
        'Try
        CargarEmpresa()
        CargarFondos()

        '  Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        '  End Try

    End Sub

    Sub CargarEquipo()
        'Try

        ''Tipo de ventana
        'cmd = New MySqlCommand("SELECT SizeMode FROM AreaImpresion WHERE ComputerName='" + My.Computer.Name + "'", Con)
        'Dim TypeWindowState As String = Convert.ToString(cmd.ExecuteScalar())

        'If TypeWindowState = 0 Then
        '    Me.WindowState = FormWindowState.Normal
        '    btnChangeWindows.Text = "Maximizar"
        'Else
        '    Me.WindowState = FormWindowState.Maximized
        '    btnChangeWindows.Text = "Restaurar"
        'End If
        Dim dstemp As New DataSet
        Con.Open()
        cmd = New MySqlCommand("Select * from AreaImpresion Where ComputerName='" + My.Computer.Name + "' and Nulo=0", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "AreaImpresion")
        Con.Close()

        DTAreaImpresion = dstemp.Tables("AreaImpresion")

        If DTAreaImpresion.Rows.Count > 0 Then
            lblEquipo.Visible = True
            lblEquipo.Text = My.Computer.Name
            lblDesktopAccess.Visible = True
        Else
            lblEquipo.Text = "Este equipo no está autorizado al acceso."
            lblEquipo.Visible = True
            lblDesktopAccess.Visible = False
        End If

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Sub CargarconfiguracionLibregco()
        'Try
        CargarLibregco()
        SetToolTipHelps()
        CargarEspecSistema()

        '  Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        '  End Try
    End Sub

    Private Sub SetToolTipHelps()
        HelperTT.ToolTipTitle = "Asistencia al usuario " & Label1.Text & " " & lblVersionTop.Text
        HelperTT.SetToolTip(btn_Iniciar, "Presione aquí para solicitar acceso al sistema ")
        HelperTT.SetToolTip(IrAyuda, "Tienes problemas?" & vbNewLine & vbNewLine & "Presiona aquí para resolver problemas de conexión y acceso al sistema.")
        HelperTT.SetToolTip(txtPassword, "Introduzca su contraseña para acceder a la base de datos.")
        HelperTT.SetToolTip(txtUser, "Escriba su nombre de usuario para acceder al sistema.")
        HelperTT.SetToolTip(lblUnderBare, "Notificaciones del sistema.")
    End Sub

    Sub ActualizarDatos()
        Try
            txtUser.Focus()

            ConUtilitarios.Open()
            cmd = New MySqlCommand("Select Value from Libregco_Utilitarios.Ajustes where IDAjuste=5", ConUtilitarios)
            Sys = Convert.ToString(cmd.ExecuteScalar())

            If Sys = 1 Then
                Con = New MySqlConnection(CnString1)
                SysName.Text = " Libregco_Main."

                If TypeConnection.Text = 1 Then
                    cmd = New MySqlCommand("Select LocacionLogo from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
                    Dim Path As String = Convert.ToString(cmd.ExecuteScalar())

                    If Path = "" Then
                        LogoLibregco.Image = My.Resources.LibregcoCircle_x256
                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists("\\" & PathServidor.Text & Path)
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream("\\" & PathServidor.Text & Path, FileMode.Open, FileAccess.Read)
                            LogoLibregco.Image = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                        Else
                            LogoLibregco.Image = My.Resources.LibregcoCircle_x256
                        End If
                    End If
                Else
                    LogoLibregco.Image = My.Resources.LibregcoCircle_x256
                End If


            Else
                Con = New MySqlConnection(CnString)
                LogoLibregco.Image = Nothing
                Sys = 0
                SysName.Text = " Libregco."
            End If

            ConUtilitarios.Close()

            'LinkLabel1.Text = SysName.Text
            'TextBox1.Text = Con.ConnectionString
        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarFondos()
        Try
            Dim DsImages As New DataSet
            Dim Counter As Integer = 0

            If TypeConnection.Text = 2 Then
                DTConfiguracion.Rows(49 - 1).Item("Value2Int") = 0
            End If

            If DTConfiguracion.Rows(49 - 1).Item("Value2Int").ToString = 1 Then
                Con.Open()
                DsImages.Clear()
                cmd = New MySqlCommand("Select * from fondospantalla where Desactivar=0", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsImages, "fondospantalla")
                Con.Close()

                TablesImage.Clear()
                TablesImage = DsImages.Tables("fondospantalla")         'Llenos las rutas de los fondos cargados en la base de datos

                If TablesImage.Rows.Count = 1 Then

                    Dim ExistFile As Boolean = System.IO.File.Exists(TablesImage.Rows(0).Item("Ruta"))
                    If ExistFile = True Then       'Verifico si existe el fondo de pantalla 
                        PanelInferior.BackColor = Color.FromArgb(100, Color.FromArgb(TablesImage.Rows(0).Item("ArgbColor")))
                        btn_Iniciar.BackColor = Color.FromArgb(TablesImage.Rows(0).Item("ArgbColor"))
                        btn_Iniciar.FlatAppearance.BorderColor = Color.FromArgb(TablesImage.Rows(0).Item("ArgbColor"))
                        btn_Iniciar.FlatAppearance.MouseDownBackColor = Color.FromArgb(TablesImage.Rows(0).Item("ArgbColor"))
                        btn_Iniciar.FlatAppearance.MouseOverBackColor = Color.FromArgb(TablesImage.Rows(0).Item("ArgbColor"))
                        'LBoxDatosPC.BackColor = Color.FromArgb(ColorSave.Text)
                        PanelIzquierdo.BackColor = Color.FromArgb(100, Color.FromArgb(TablesImage.Rows(0).Item("ArgbColor")))
                        txtUser.SetDefaultBackColor = Color.FromArgb(100, Color.FromArgb(TablesImage.Rows(0).Item("ArgbColor")))
                        txtPassword.SetDefaultBackColor = Color.FromArgb(100, Color.FromArgb(TablesImage.Rows(0).Item("ArgbColor")))
                        Me.BackgroundImage = Image.FromFile(TablesImage.Rows(0).Item("Ruta"))
                    Else                                                    'Si no existe entonces empiezo el proceso buscando una fila aleatoria
                        Counter = Counter + 1
                        GoTo GetRandomValue
                    End If

                ElseIf TablesImage.Rows.Count > 1 Then
GetRandomValue:
                    If Counter >= 4 Then
                        Exit Sub
                    End If

                    Randomize()
                    RandomValue = CInt(Math.Floor(TablesImage.Rows.Count - 1) * Rnd())
                    CheckRandom = RandomValue

                    Dim ExistFile As Boolean = System.IO.File.Exists(TablesImage.Rows(RandomValue).Item("Ruta"))

                    If ExistFile = True Then       'Verifico si existe el fondo de pantalla 
                        PanelInferior.BackColor = Color.FromArgb(TablesImage.Rows(RandomValue).Item("ArgbColor"))
                        btn_Iniciar.BackColor = Color.FromArgb(TablesImage.Rows(RandomValue).Item("ArgbColor"))
                        btn_Iniciar.FlatAppearance.BorderColor = Color.FromArgb(TablesImage.Rows(RandomValue).Item("ArgbColor"))
                        btn_Iniciar.FlatAppearance.MouseDownBackColor = Color.FromArgb(TablesImage.Rows(RandomValue).Item("ArgbColor"))
                        btn_Iniciar.FlatAppearance.MouseOverBackColor = Color.FromArgb(TablesImage.Rows(RandomValue).Item("ArgbColor"))
                        'LBoxDatosPC.BackColor = Color.FromArgb(ColorSave.Text)
                        PanelIzquierdo.BackColor = Color.FromArgb(100, Color.FromArgb(TablesImage.Rows(RandomValue).Item("ArgbColor")))
                        txtUser.SetDefaultBackColor = Color.FromArgb(100, Color.FromArgb(TablesImage.Rows(RandomValue).Item("ArgbColor")))
                        txtPassword.SetDefaultBackColor = Color.FromArgb(100, Color.FromArgb(TablesImage.Rows(RandomValue).Item("ArgbColor")))
                        Me.BackgroundImage = Image.FromFile(TablesImage.Rows(RandomValue).Item("Ruta"))
                    Else                                                    'Si no existe entonces empiezo el proceso buscando una fila aleatoria
                        Counter = Counter + 1
                        GoTo GetRandomValue
                    End If
                End If
            Else

                'Cargar color primario
                PanelIzquierdo.BackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                txtUser.SetDefaultBackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                txtPassword.SetDefaultBackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))

                btn_Iniciar.BackColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                btn_Iniciar.FlatAppearance.BorderColor = Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var"))
                btn_Iniciar.FlatAppearance.MouseDownBackColor = BlendColors(Color.FromArgb(DTConfiguracion.Rows(64 - 1).Item("Value1Var")), PanelInferior.BackColor)
                Me.BackgroundImage = Nothing

                'Cargar color secundario
                PanelInferior.BackColor = Color.FromArgb(DTConfiguracion.Rows(65 - 1).Item("Value1Var"))
                ''LBoxDatosPC.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

                'Cargar color terciario
                lblUnderBare.BackColor = Color.FromArgb(DTConfiguracion.Rows(66 - 1).Item("Value1Var"))
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub CargarEmpresa()
        'Try
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select * from razonsocial where IDRazon= (Select Max(IDRazon) from razonsocial)", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "razonsocial")
        Con.Close()

        DTEmpresa = Ds.Tables("razonsocial")

        If DTEmpresa.Rows.Count > 0 Then
            lblEmpresa.Text = DTEmpresa.Rows(0).Item("NombreEmpresa")

            If TypeConnection.Text = 1 Then
                If DTEmpresa.Rows.Count > 0 Then
                    If DTEmpresa.Rows(0).Item("RutaLogo") <> "" Then
                        If (DTEmpresa.Rows(0).Item("MostrarLogoSistema")) = 0 Then
                            BussinessLogo = Nothing
                        Else
                            Dim ExistFile As Boolean = System.IO.File.Exists(DTEmpresa.Rows(0).Item("RutaLogo"))

                            If ExistFile = True Then
                                Dim wFile As System.IO.FileStream
                                wFile = New FileStream(DTEmpresa.Rows(0).Item("RutaLogo"), FileMode.Open, FileAccess.Read)
                                BussinessLogo = System.Drawing.Image.FromStream(wFile)
                                wFile.Close()
                            Else
                                BussinessLogo = Nothing
                            End If

                        End If
                    Else
                        BussinessLogo = Nothing
                    End If

                Else
                    BussinessLogo = Nothing
                End If

            Else

                If IsDBNull(DTEmpresa.Rows(0).Item("LogoBlob")) Then
                    BussinessLogo = Nothing
                Else
                    Dim Img() As Byte

                    Img = DTEmpresa.Rows(0).Item("LogoBlob")

                    Dim Ms As New MemoryStream(Img)

                    BussinessLogo = Image.FromStream(Ms)
                End If
            End If

            PicBoxLogo.Image = ConseguirLogoEmpresa()
        End If

        Ds.Dispose()

        '  Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        '  End Try
    End Sub

    Private Sub CargarLibregco()
        'Try
        Dim CurrentDate As Date

        SetLogoSistema()
        LogoLibregco.Image = ConseguirLogoSistema()

        ConUtilitarios.Open()
        Con.Open()
        ConLibregco.Open()

        'Conseguir hora del servidor
        cmd = New MySqlCommand("SELECT CURDATE()", Con)
        CurrentDate = Convert.ToDateTime(cmd.ExecuteScalar())

        If Today <> CurrentDate Then
            MessageBox.Show("Existe un conflicto entre la fecha actual del equipo y la fecha del servidor." & vbNewLine & vbNewLine & "Por favor verifique la fecha del equipo o la del servidor para acceder al sistema.", "Diferencias en fechas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

            ConUtilitarios.Close()
            Con.Close()
            ConLibregco.Close()
            Close()
        End If

        Dim dstemp As New DataSet

        'Cargando configuracion del sistema
        DTConfiguracion.Dispose()
        cmd = New MySqlCommand("Select * from Configuracion", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Configuracion")

        DTConfiguracion = dstemp.Tables("Configuracion")

        DTModulos.Dispose()
        cmd = New MySqlCommand("Select * from Modulos", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Modulos")
        DTModulos = dstemp.Tables("Modulos")
        dstemp.Dispose()

        'Cargando configuracion del servidor -ajustes
        DTAjustes.Dispose
        cmd = New MySqlCommand("Select * from Libregco_Utilitarios.Ajustes", ConUtilitarios)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dstemp, "Ajustes")

        DTAjustes = dstemp.Tables("Ajustes")
        dstemp.Dispose()


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Permitir cambiar database
        LogoLibregco.Tag = DTAjustes.Rows(6 - 1).Item("Value").ToString

        'Mostrar aviso de mantenimiento
        PanelAviso.Visible = Convert.ToBoolean(CInt(DTAjustes.Rows(7 - 1).Item("Value")))

        'Color de la barra de progreso
        If DTConfiguracion.Rows(74 - 1).Item("Value2Int").ToString = 1 Then
            SendMessage(BarradeProgreso.Handle, 1040, 1, 0)
        ElseIf DTConfiguracion.Rows(74 - 1).Item("Value2Int").ToString = 2 Then
            SendMessage(BarradeProgreso.Handle, 1040, 2, 0)
        ElseIf DTConfiguracion.Rows(74 - 1).Item("Value2Int").ToString = 3 Then
            SendMessage(BarradeProgreso.Handle, 1040, 3, 0)
        End If

        'Animacion de moneda
        If DTConfiguracion.Rows(72 - 1).Item("Value2Int").ToString = 1 Then
            cmd = New MySqlCommand("Select count(IDTipoMoneda) from TipoMoneda where MostrarAnimacion=1 and Nulo=0", ConLibregco)
            Dim ExistMoney As Integer = Convert.ToString(cmd.ExecuteScalar())

            If ExistMoney > 0 Then
                Ds.Clear()
                cmd = New MySqlCommand("Select * from TipoMoneda where MostrarAnimacion=1 and Nulo=0", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "TipoMoneda")

                Dim Tabla As DataTable = Ds.Tables("TipoMoneda")

                For Each row As DataRow In Tabla.Rows
                    lblUnderBare.Text = lblUnderBare.Text + " | " + row.Item("Moneda") + " " + row.Item("Signo") + ": Compra " & CDbl(row.Item("TasaCompra")).ToString("C") + " Venta " & CDbl(row.Item("TasaVenta")).ToString("C")
                Next

                lblUnderBare.Text = lblUnderBare.Text + " |"
                TimeAnimationMoney.Enabled = True
                lblUnderBare.ForeColor = Color.Red
                Tabla.Dispose()
            End If
        End If

        Try
            'Verificar version
            ActualVersion = Replace(My.Application.Info.DirectoryPath, My.Application.Info.DirectoryPath.Substring(0, My.Application.Info.DirectoryPath.IndexOf("libregco_")).Trim, "").Replace("_", ".").Replace("libregco.", "")
            lblVersionTop.Text = ActualVersion & "v"

        Catch ex As Exception
            ActualVersion = "No implementada"
            lblVersionTop.Text = ""
        End Try

        cmd = New MySqlCommand("Select concat(VersionMayor,'.',VersionMenor,'.',VersionCompilacion,'.',VersionVersion) from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
        If Convert.ToString(cmd.ExecuteScalar()) = ActualVersion Then
            lblVersion.Text = "Versión: " & ActualVersion
        Else
            lblVersion.Text = "Última versión: " & Convert.ToString(cmd.ExecuteScalar()) & vbNewLine & "Ejecutando versión: " & ActualVersion
        End If

        Label2.Location = New Point(Label4.Location.X, lblVersion.Location.Y + lblVersion.Size.Height + 5)

        'LimitLifeTimePassword = DTConfiguracion.Rows(68 - 1).Item("Value2Int").ToString()
        'MultipleUsuarios = DTConfiguracion.Rows(187 - 1).Item("Value2Int").ToString()
        'DeshabilitarVerificacionCorreo = DTConfiguracion.Rows(210 - 1).Item("Value2Int").ToString()

        ConLibregco.Close()
        ConUtilitarios.Close()
        Con.Close()


        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub CargarEspecSistema()
        Try
            lblIP.Text = Dns.GetHostEntry(My.Computer.Name).AddressList.FirstOrDefault(Function(i) i.AddressFamily = Sockets.AddressFamily.InterNetwork).ToString()

            Try
                If DTConfiguracion.Rows(2 - 1).Item("Value2Int").ToString = "1" Then
                    If My.Computer.Network.IsAvailable = True Then
                        Dim Client As New WebClient
                        lblAccesoInternet.Text = Client.DownloadString("http://icanhazip.com")
                        lblInternetIco.Visible = True
                    Else
                        lblAccesoInternet.Text = "No se encontró acceso a Internet"
                    End If
                Else
                    lblAccesoInternet.Text = "No se ha comprobado el acceso a Internet"
                End If

            Catch ex As Exception
                lblAccesoInternet.Text = "Se ha encontrado un problema persistente para el acceso al internet."
            End Try

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub lblIcoConnection_Click(sender As Object, e As EventArgs) Handles lblIcoConnection.Click
        Dim MousePosition As Point = Cursor.Position

        frm_connection_hosts.Show(Me)
        frm_connection_hosts.Location = New Point(MousePosition.X, MousePosition.Y - 150)

    End Sub

    Private Sub txtUser_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
        MessageBox.Show("qwq")
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Async Sub btn_Iniciar_Click(sender As Object, e As EventArgs) Handles btn_Iniciar.Click
        If txtUser.Text = "" And txtPassword.Text = "" Then
            lblInformacion.ForeColor = Color.Red
            lblInformacion.Text = "Nombre de usuario vacío y/o contraseña vacía."
            txtUser.Focus()
            Exit Sub
        ElseIf txtUser.Text = "" Then
            txtUser.TextMessage = "Escriba el nombre de usuario para acceder."
            txtUser.Focus()
            Exit Sub
        ElseIf txtPassword.Text = "" Then
            txtPassword.TextMessage = "La contraseña está en blanco."
            txtPassword.Focus()
            Exit Sub
        End If

        If txtUser.Text IsNot String.Empty And txtPassword.Text IsNot String.Empty Then
            If DTAjustes.Rows(4 - 1).Item("Value").ToString = 1 Then
                If DTAjustes.Rows(2 - 1).Item("Value").ToString = txtUser.Text And DTAjustes.Rows(3 - 1).Item("Value").ToString = txtPassword.Text Then

                    DTEmpleado.Dispose()
                    Ds.Dispose()
                    Con.Open()
                    cmd = New MySqlCommand("Select IDEmpleado,Nombre,Apodo,Empleados.IDNacionalidad,Nacionalidad.Nacionalidad,Cedula,FechaNacimiento,Empleados.IDMunicipio,Municipios.Municipio,Municipios.IDProvincia,Provincias.Provincia,Empleados.Direccion,Empleados.TelefonoPersonal,Empleados.TelefonoHogar,Empleados.IDGenero,Genero.Genero,Empleados.CorreoElectronico,CorreoVerificado,ClaveVerificacion,Login,Password,FactorNumerico,FechaPassword,RutaFoto,GrayPictureFile,RutaCedula,ImagenChat,Cargo,Alertas,Empleados.IDSucursal,Empleados.IDAlmacen,Almacen.Almacen,Sucursal.Sucursal,Sucursal.Municipio,Sucursal.Direccion as DireccionSucursal,Sucursal.Telefono,Sucursal.Telefono1,Sucursal.Telefono2,Sucursal.Fax,Sucursal.Email as CorreoSucursal,Empleados.IDTipoNomina,TipoNomina.Descripcion as TipoNomina,Empleados.Nulo,Empleados.Disponible,Empleados.Salario,Empleados.Cotizable,Empleados.IDCargo,CargosEmp.Cargo,Puesto,Empleados.IDPeriodoPago,PeriodoPago.Descripcion as PeriodoPago,Empleados.IDTanda,Tandas.Descripcion as Tanda,Empleados.IDArs,ARS.Descripcion as ARS,Empleados.IDAFP,AFP.Descripcion as AFP,Empleados.FechaIngreso,Carnet,CuentaBancaria,CuotaPrestamo,CuotaCuenta,ConsumoFlota,CobrarTSS,SeguroComplementario,CobrarISR,Empleados.IDPrivilegios,Privilegios.Privilegios,HabilitarNomina,IDChatStatus,Empleados.Status,Empleados.Balance,Empleados.Conectado,VacacionInicia,VacacionTermina,ColorMode,MostrarenTope,HabilitarNotificaciones,MostrarContenido,MostrarConsejos,BloqueoInactividad,IDPrivilegios,NotificacionStart,AgendaFilePath,Memos,NotificacionStart,EsVendedor,EsCobrador from" & SysName.Text & "Empleados INNER JOIN Libregco.CargosEmp ON Empleados.IDCargo=CargosEmp.IDCargo INNER JOIN Libregco.Genero on Empleados.IDGenero=Genero.IDGenero INNER JOIN Libregco.Nacionalidad on Empleados.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN Libregco.Municipios on Empleados.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.Provincias on Municipios.IDProvincia=Provincias.IDProvincia INNER JOIN" & SysName.Text & "Almacen on Empleados.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.TipoNomina on Empleados.IDTipoNomina=TipoNomina.IDTipoNomina INNER JOIN Libregco.PeriodoPago on Empleados.IDPeriodoPago=PeriodoPago.IDPeriodoPago INNER JOIN Libregco.Tandas on Empleados.IDTanda=Tandas.IDTanda INNER JOIN Libregco.ARS ON Empleados.IDARs=Ars.IDARS INNER JOIN Libregco.AFP ON Empleados.IDAFP=AFP.IDAFP INNER JOIN Libregco.Privilegios on Empleados.IDPrivilegios=Privilegios.IDPrivilegio Where Empleados.IDEmpleado=1", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Ds, "Empleados")
                    Con.Close()

                    DTEmpleado = Ds.Tables("Empleados")

                    lblInformacion.ForeColor = Color.Green
                    lblInformacion.Text = "Acceso directo del administrador."
                    BarradeProgreso.Value = 100

                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))
                    frm_inicio.Button4.Text = My.Computer.Name
                    NuevaEstructuracion = True
                    frm_inicio.Show()
                    Me.Close()
                    Exit Sub
                End If
            End If

            lblInformacion.Text = ""

            DTEmpleado.Dispose()
            Ds.Dispose()
            Con.Open()
            cmd = New MySqlCommand("Select IDEmpleado,Nombre,Apodo,Empleados.IDNacionalidad,Nacionalidad.Nacionalidad,Cedula,FechaNacimiento,Empleados.IDMunicipio,Municipios.Municipio,Municipios.IDProvincia,Provincias.Provincia,Empleados.Direccion,Empleados.TelefonoPersonal,Empleados.TelefonoHogar,Empleados.IDGenero,Genero.Genero,Empleados.CorreoElectronico,CorreoVerificado,ClaveVerificacion,Login,Password,FactorNumerico,FechaPassword,RutaFoto,GrayPictureFile,RutaCedula,ImagenChat,Cargo,Alertas,Empleados.IDSucursal,Empleados.IDAlmacen,Almacen.Almacen,Sucursal.Sucursal,Sucursal.Municipio,Sucursal.Direccion as DireccionSucursal,Sucursal.Telefono,Sucursal.Telefono1,Sucursal.Telefono2,Sucursal.Fax,Sucursal.Email as CorreoSucursal,Empleados.IDTipoNomina,TipoNomina.Descripcion as TipoNomina,Empleados.Nulo,Empleados.Disponible,Empleados.Salario,Empleados.Cotizable,Empleados.IDCargo,CargosEmp.Cargo,Puesto,Empleados.IDPeriodoPago,PeriodoPago.Descripcion as PeriodoPago,Empleados.IDTanda,Tandas.Descripcion as Tanda,Empleados.IDArs,ARS.Descripcion as ARS,Empleados.IDAFP,AFP.Descripcion as AFP,Empleados.FechaIngreso,Carnet,CuentaBancaria,CuotaPrestamo,CuotaCuenta,ConsumoFlota,CobrarTSS,SeguroComplementario,CobrarISR,Empleados.IDPrivilegios,Privilegios.Privilegios,HabilitarNomina,IDChatStatus,Empleados.Status,Empleados.Balance,Empleados.Conectado,VacacionInicia,VacacionTermina,ColorMode,MostrarenTope,HabilitarNotificaciones,MostrarContenido,MostrarConsejos,BloqueoInactividad,IDPrivilegios,NotificacionStart,AgendaFilePath,Memos,NotificacionStart,EsVendedor,EsCobrador from" & SysName.Text & "Empleados INNER JOIN Libregco.CargosEmp ON Empleados.IDCargo=CargosEmp.IDCargo INNER JOIN Libregco.Genero on Empleados.IDGenero=Genero.IDGenero INNER JOIN Libregco.Nacionalidad on Empleados.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN Libregco.Municipios on Empleados.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.Provincias on Municipios.IDProvincia=Provincias.IDProvincia INNER JOIN" & SysName.Text & "Almacen on Empleados.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.TipoNomina on Empleados.IDTipoNomina=TipoNomina.IDTipoNomina INNER JOIN Libregco.PeriodoPago on Empleados.IDPeriodoPago=PeriodoPago.IDPeriodoPago INNER JOIN Libregco.Tandas on Empleados.IDTanda=Tandas.IDTanda INNER JOIN Libregco.ARS ON Empleados.IDARs=Ars.IDARS INNER JOIN Libregco.AFP ON Empleados.IDAFP=AFP.IDAFP INNER JOIN Libregco.Privilegios on Empleados.IDPrivilegios=Privilegios.IDPrivilegio Where Empleados.Login= '" + txtUser.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Empleados")
            Con.Close()

            DTEmpleado = Ds.Tables("Empleados")

            If DTEmpleado.Rows.Count = 0 Then
                txtUser.TextMessage = "No se encontró el usuario introducido."
                lblInformacion.ForeColor = Color.Brown
                lblInformacion.Text = "Empleado no encontrado en la base de datos."
                txtUser.Focus()
            Else
                If DTEmpleado.Rows(0).Item("Nulo").ToString = "1" Then
                    lblInformacion.ForeColor = Color.Blue
                    lblInformacion.Text = "El usuario está desactivado del sistema."
                    OcultarIntentos()
                    Exit Sub
                End If

                If DTEmpleado.Rows(0).Item("Status").ToString = "3" Then
                    lblInformacion.ForeColor = Color.Black
                    lblInformacion.Text = "El usuario está bloqueado."
                    OcultarIntentos()
                    Exit Sub
                End If

                If DTEmpleado.Rows(0).Item("Password").ToString <> txtPassword.Text Then
                    txtPassword.TextMessage = "La contraseña es incorrecta."
                    lblInformacion.ForeColor = Color.Red
                    lblInformacion.Text = "Inténtelo de nuevo."
                    txtPassword.Focus()

                    If CInt(DTConfiguracion.Rows(216 - 1).Item("Value2Int")) = 1 Then
                        IntentosInicios()
                    End If

                    Exit Sub
                End If

                If txtPassword.Text = "" Then
                    txtPassword.TextMessage = "La contraseña está en blanco."
                    txtPassword.Focus()
                    Exit Sub
                End If

                If DTEmpleado.Rows(0).Item("Password").ToString = txtPassword.Text Then
                    If DTConfiguracion.Rows(187 - 1).Item("Value2Int").ToString() = 1 Then
                    Else
                        If DTEmpleado.Rows(0).Item("Conectado").ToString = 1 Then
                            MessageBox.Show("El usuario " & DTEmpleado.Rows(0).Item("Login").ToString & " tiene una sesión abierta del sistema.", "Se encontró sección activa", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If

                    OcultarIntentos()
                    PanelLogin.Visible = False
                    lblInformacion.ForeColor = Color.Green
                    lblInformacion.Text = "La contraseña es correcta."
                    BarradeProgreso.Visible = True
                    BarradeProgreso.Value = 0
                    BarradeProgreso.Value = BarradeProgreso.Value + 20

                    If DTEmpleado.Rows(0).Item("Status").ToString = 1 Then
                        frm_cambiar_nuevo_password.ShowDialog(Me)
                    End If

                    If DTAreaImpresion.Rows.Count = 0 Then
                        MessageBox.Show("Este equipo [" & My.Computer.Name & "] no está autorizado para acceder al sistema.")
                        BarradeProgreso.Value = 0
                        lblInformacion.Text = "El equipo no está autorizado para el acceso."
                        lblInformacion.ForeColor = Color.Red
                        PanelLogin.Visible = True
                        Exit Sub
                    End If

                    If CInt(DTConfiguracion.Rows(68 - 1).Item("Value2Int")) = 1 Then
                        If IsDate(DTEmpleado.Rows(0).Item("FechaPassword")) Then
                            Dim DaysSumated As String = DateDiff(DateInterval.Day, CDate(DTEmpleado.Rows(0).Item("FechaPassword")), Today)
                            If (CInt(DTConfiguracion.Rows(69 - 1).Item("Value2Int").ToString()) - CInt(DTConfiguracion.Rows(71 - 1).Item("Value2Int").ToString())) < CInt(DaysSumated) And CInt(DTConfiguracion.Rows(69 - 1).Item("Value2Int").ToString()) > CInt(DaysSumated) Then
                                MessageBox.Show("Es recomendable cambiar la contraseña ya que se está por vencer el plazo de [" & DTConfiguracion.Rows(69 - 1).Item("Value2Int").ToString() & " días de antiguedad] establecido en el sistema." & vbNewLine & vbNewLine & "Su contraseña tiene " & DateDiff(DateInterval.Day, CDate(DTEmpleado.Rows(0).Item("FechaPassword")), Today) & " días de antiguedad.", "Nueva contraseña por antiguedad", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                frm_cambiar_nuevo_password.ShowDialog(Me)
                            ElseIf CInt(DTConfiguracion.Rows(69 - 1).Item("Value2Int").ToString()) <= CInt(DaysSumated) Then
                                MessageBox.Show("Es obligatoria el cambio de contraseña ya que se ha vencido totalmente el plazo de [" & DTConfiguracion.Rows(69 - 1).Item("Value2Int").ToString() & " días de antiguedad] establecido en el sistema." & vbNewLine & vbNewLine & "Su contraseña tiene " & DaysSumated & " días de antiguedad.", "Nueva contraseña por antiguedad", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                frm_cambiar_nuevo_password.ShowDialog(Me)

                                Con.Open()
                                cmd = New MySqlCommand("Select FechaPassword from Empleados where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado") + "'", Con)
                                Dim NewFechaPassword As String = Convert.ToString(cmd.ExecuteScalar())
                                Con.Close()

                                If CDate(NewFechaPassword) = CDate(DTEmpleado.Rows(0).Item("FechaPassword")) Then
                                    BarradeProgreso.Value = 0
                                    lblInformacion.Text = "El sistema ha bloqueado el acceso por antiguedad de contraseña."
                                    lblInformacion.ForeColor = Color.Fuchsia
                                    PanelLogin.Visible = True
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If

                    If DTEmpleado.Rows(0).Item("FactorNumerico").ToString = "" Then
                        frm_contraseña_factores.ShowDialog(Me)
                        If ControlSuperClave = 0 Then
                            BarradeProgreso.Value = 0
                            lblInformacion.Text = "El inicio del sistema ha sido cancelado."
                            lblInformacion.ForeColor = Color.Brown
                            PanelLogin.Visible = True
                            Exit Sub
                        End If
                    End If

                    If DTConfiguracion.Rows(210 - 1).Item("Value2Int").ToString() = "1" Then
                        If DTEmpleado.Rows(0).Item("CorreoVerificado").ToString = "0" Then
                            If My.Computer.Network.IsAvailable = True Then
                                frm_verificacion_correo.ShowDialog(Me)
                            End If
                        End If
                    End If

                    If DTAreaImpresion.Rows(0).Item("isServer").ToString = 1 Then
                        ClearOldBackUp()
                    End If

                    BarradeProgreso.Value = BarradeProgreso.Value + 25
                    lblInformacion.ForeColor = btn_Iniciar.BackColor
                    lblInformacion.Text = "Insertado registro a bitáctora..."
                    lblInformacion.Refresh()

                    lblInformacion.Text = "Verificando status de la base de datos..."
                    ControldeActualizacionxFecha()
                    BarradeProgreso.Value = BarradeProgreso.Value + 40
                    lblInformacion.Refresh()

                    lblInformacion.Text = "Transmitiendo credenciales al sistema..."
                    PasarCredencial()
                    lblInformacion.Refresh()
                    BarradeProgreso.Value = BarradeProgreso.Value + 15

                    lblInformacion.Text = "Se ha iniciado el sistema satisfactoriamente."
                    lblInformacion.Refresh()
                    BarradeProgreso.Value = BarradeProgreso.Maximum
                    AverageColor = btn_Iniciar.BackColor

                    frm_inicio.Show()
                    Me.Close()

                End If
            End If
        End If
    End Sub

    Private Sub IntentosInicios()
        Try
            'Status de los Empleados
            'Status=0 Empleado en condición normal
            'Status=1 Empleado en condición de cambio de contraseña
            'Status=2 Empleado con primera alerta de intentos fallidos en contraseña
            'Status3=Empleado bloqueado
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lblIntentos.Visible = True
            lblIntentosFallidos.Visible = True

            lblIntentos.Text = CInt(lblIntentos.Text) + 1

            If lblIntentos.Text = 4 Then
                If DTEmpleado.Rows(0).Item("Status") = 0 Or DTEmpleado.Rows(0).Item("Status") = 2 Then
                    MessageBox.Show("El próximo intento es el último, por favor verífique su contraseña para continuar.", "No coincide la contraseña.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                ElseIf DTEmpleado.Rows(0).Item("Status") = 3 Then
                    MessageBox.Show("El próximo intento es el último para evitar que el usuario sea bloqueado. Por favor verífique su contraseña para continuar.", "No coincide la contraseña.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If

            If lblIntentos.Text = 5 Then
                If DTEmpleado.Rows(0).Item("Status") = 0 Then
                    MessageBox.Show("Ha excedido la cantidad de intentos a la base de datos, el sistema se cerrará.", "No coincide la contraseña.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    sqlQ = "UPDATE Empleados SET Status=2 WHERE Login='" + txtUser.Text + "'"
                    GuardarDatos()
                ElseIf DTEmpleado.Rows(0).Item("Status") = 2 Then
                    MessageBox.Show("Ha excedido la cantidad de intentos a la base de datos." & vbNewLine & vbNewLine & "El usuario " & txtUser.Text & " está bloqueado.", "Ha excedido la cantidad de veces", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    sqlQ = "UPDATE Empleados SET Status=3 WHERE Login='" + txtUser.Text + "'"
                    GuardarDatos()
                End If
                Me.Close()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub OcultarIntentos()
        lblIntentos.Text = CInt(0)
        lblIntentos.Visible = False
        lblIntentosFallidos.Visible = False
    End Sub

    Sub PasarCredencial()
        Try
            Con.Open()
            sqlQ = "UPDATE Empleados SET Conectado=1 WHERE IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()

            If Len(lblAccesoInternet.Text) < 30 Then
                sqlQ = "UPDATE AreaImpresion SET IPPublica='" + lblAccesoInternet.Text + "',IPPrivada='" + lblIP.Text + "',PrintingSecure=0 WHERE IDEquipo= '" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
            End If

            Con.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ColorearLogo()
        Dim RandomClass As New Random

        Dim intR, intG, IntB As Integer
        intR = RandomClass.Next(0, 256)
        intG = RandomClass.Next(0, 256)
        IntB = RandomClass.Next(0, 256)

        Label1.ForeColor = Drawing.Color.FromArgb(intR, intG, IntB)
        lblVersionTop.ForeColor = Drawing.Color.FromArgb(intR, intG, IntB)
        PanelInferior.BackColor = Drawing.Color.FromArgb(intR, intG, IntB)
        'LBoxDatosPC.BackColor = Drawing.Color.FromArgb(intR, intG, IntB)
        PanelIzquierdo.BackColor = Drawing.Color.FromArgb(intR, intG, IntB, 10)
        btn_Iniciar.BackColor = Drawing.Color.FromArgb(intR, intG, IntB)
        btn_Iniciar.FlatAppearance.MouseDownBackColor = BlendColors(PanelIzquierdo.BackColor, PanelInferior.BackColor)
    End Sub

    Private Sub IrAyuda_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles IrAyuda.LinkClicked
        frm_recuperar_cuenta.ShowDialog(Me)
    End Sub


    Private Sub txtUser_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Return) Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub lblInternetIco_Click(sender As Object, e As EventArgs) Handles lblInternetIco.Click
        Dim Proceso As New Process()
        Proceso.StartInfo.FileName = "http://ipaddress.com/"
        Proceso.StartInfo.Arguments = ""
        Proceso.Start()
    End Sub

    Private Sub TimeAnimationMoney_Tick(sender As Object, e As EventArgs) Handles TimeAnimationMoney.Tick
        If lblUnderBare.Left < -(lblUnderBare.Width) Then
            lblUnderBare.Left = Panel1.Width
        Else
            lblUnderBare.Left -= 5
        End If
    End Sub

    Private Sub LogoLibregco_DoubleClick(sender As Object, e As EventArgs) Handles LogoLibregco.DoubleClick
        Try
            If LogoLibregco.Tag.ToString = "1" Then

                If Sys = 0 Then
                    Con = New MySqlConnection(CnString1)
                    SysName.Text = " Libregco_Main."

                    If TypeConnection.Text = 1 Then
                        ConUtilitarios.Open()
                        cmd = New MySqlCommand("Select LocacionLogo from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
                        Dim Path As String = Convert.ToString(cmd.ExecuteScalar())
                        ConUtilitarios.Close()

                        If Path = "" Then
                            LogoLibregco.Image = My.Resources.LibregcoCircle_x256
                        Else
                            Dim ExistFile As Boolean = System.IO.File.Exists("\\" & PathServidor.Text & Path)
                            If ExistFile = True Then
                                LogoLibregco.Image = Image.FromFile("\\" & PathServidor.Text & Path)
                            End If
                        End If
                    Else
                        LogoLibregco.Image = My.Resources.LibregcoCircle_x256
                    End If

                    Sys = 1

                Else
                    Con = New MySqlConnection(CnString)
                    SysName.Text = " Libregco."
                    LogoLibregco.Image = Nothing
                    Sys = 0
                End If



                'Cargando configuracion del sistema
                DTConfiguracion.Dispose()

                Con.Open()
                Dim dstemp As New DataSet
                cmd = New MySqlCommand("Select * from Configuracion", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(dstemp, "Configuracion")

                DTConfiguracion = dstemp.Tables("Configuracion")

                DTModulos.Dispose()
                cmd = New MySqlCommand("Select * from Modulos", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(dstemp, "Modulos")
                DTModulos = dstemp.Tables("Modulos")
                dstemp.Dispose()

                Con.Close()

                'LimitLifeTimePassword = DTConfiguracion.Rows(68 - 1).Item("Value2Int").ToString()
                'ColorPrimario = DTConfiguracion.Rows(64 - 1).Item("Value1Var").ToString()
                'ColorSecundario = DTConfiguracion.Rows(65 - 1).Item("Value1Var").ToString()
                'ColorTerciario = DTConfiguracion.Rows(66 - 1).Item("Value1Var").ToString()
                'DateIngress = DTConfiguracion.Rows(101 - 1).Item("Value1Var").ToString()


                NuevaEstructuracion = False
                CargarEquipo()
                CheckNewBussiness()
                CargarFondos()

                CheckSecurePrinting()

            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub


End Class