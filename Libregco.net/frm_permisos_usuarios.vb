Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_permisos_usuarios
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Permisos As New ArrayList

    Private Sub frm_permisos_usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try
        Me.CenterToParent()
            'Me.WindowState = CheckWindowState()
            CargarLibregco()
            BuscarModulos()
            CheckForm()
            Permisos = PasarPermisos(Me.Tag)
            AddDatagridviewHeaderClick()
            AddDatagridviewHeaderDoubleClick()
            OpenPermisosOtogradoswithClick()

        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub CheckForm()
        Try
            If Me.Owner.Name = frm_inicio.Name Then
                txtIDUsuario.Text = DTEmpleado.Rows(0).Item("IDEmpleado")
                txtUsuario.Text = DTEmpleado.Rows(0).Item("Nombre")
                BuscarPermisosUsuarios()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BuscarModulos()
        BuscarModuloInventario()
        BuscarModuloFacturacion()
        BuscarModuloCXC()
        BuscarModuloCXP()
        BuscarModuloNomina()
        BuscarModuloBancos()
        BuscarModuloSupervision()
        BuscarModuloCajaChica()
        BuscarModuloContabilidad()
        BuscarModuloUtilidades()
    End Sub

    Private Sub BuscarModuloUtilidades()
        Try
            DgvUtilidades.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=13 and IDProceso=1 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvUtilidades.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarModuloFacturacion()
        BuscarFacturacionArchivos()
        BuscarFacturacionProcesos()
        BuscarFacturacionReportes()
        BuscarFacturacionConsultas()
    End Sub

    Private Sub BuscarModuloCXC()
        BuscarCXCArchivos()
        BuscarCXCProcesos()
        BuscarCXCReportes()
        BuscarCXCConsultas()
    End Sub

    Private Sub BuscarModuloCXP()
        BuscarCXPArchivos()
        BuscarCXPProcesos()
        BuscarCXPReportes()
        BuscarCXPConsultas()
    End Sub

    Private Sub BuscarModuloNomina()
        BuscarNominaArchivos()
        BuscarNominaProcesos()
        BuscarNominaReportes()
        BuscarNominaConsultas()
    End Sub

    Private Sub BuscarModuloSupervision()
        BuscarSupervisionArchivos()
        BuscarSupervisionProcesos()
        BuscarSupervisionReportes()
        BuscarSupervisionConsultas()
    End Sub

    Private Sub BuscarModuloBancos()
        BuscarBancosArchivos()
        BuscarBancosProcesos()
        BuscarBancosReportes()
        BuscarBancosConsultas()
    End Sub

    Private Sub BuscarModuloCajaChica()
        BuscarCajaChicaArchivos()
        BuscarCajaChicaProcesos()
        BuscarCajaChicaReportes()
        BuscarCajaChicaConsultas()
    End Sub

    Private Sub BuscarModuloContabilidad()
        BuscarContabilidadArchivos()
        BuscarContabilidadProcesos()
        BuscarContabilidadReportes()
        BuscarContabilidadConsultas()
    End Sub

    Private Sub BuscarCajaChicaArchivos()
        Try
            DgvCajaChicaArchivo.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=8 and IDProceso=1 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvCajaChicaArchivo.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarCajaChicaProcesos()
        Try
            DgvCajaChicaProcesos.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=8 and IDProceso=2 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvCajaChicaProcesos.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarCajaChicaReportes()
        Try
            DgvCajaChicaReportes.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=8 and IDProceso=3 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvCajaChicaReportes.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarCajaChicaConsultas()
        Try
            DgvCajaChicaConsultas.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=8 and IDProceso=4 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvCajaChicaConsultas.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarContabilidadArchivos()
        Try
            DgvContabilidadArchivos.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=9 and IDProceso=1 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvContabilidadArchivos.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarContabilidadProcesos()
        Try
            DgvContabilidadProcesos.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=9 and IDProceso=2 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvContabilidadProcesos.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarContabilidadReportes()
        Try
            DgvContabilidadReportes.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=9 and IDProceso=3 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvContabilidadReportes.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarContabilidadConsultas()
        Try
            DgvContabilidadConsultas.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=9 and IDProceso=4 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvContabilidadConsultas.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarSupervisionArchivos()
        Try
            DgvSupervisionArchivo.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=7 and IDProceso=1 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvSupervisionArchivo.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarSupervisionProcesos()
        Try
            DgvSupervisionProceso.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=7 and IDProceso=2 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvSupervisionProceso.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarSupervisionReportes()
        Try
            DgvSupervisionReportes.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=7 and IDProceso=3 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvSupervisionReportes.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarSupervisionConsultas()
        Try
            DgvSupervisionConsulta.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=7 and IDProceso=4 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvSupervisionConsulta.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarBancosArchivos()
        Try
            DgvBancoArchivo.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=6 and IDProceso=1 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvBancoArchivo.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarBancosProcesos()
        Try
            DgvBancoProceso.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=6 and IDProceso=2 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvBancoProceso.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarBancosReportes()
        Try
            DgvBancoReporte.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=6 and IDProceso=3 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvBancoReporte.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarBancosConsultas()
        Try
            DgvBancoConsulta.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=6 and IDProceso=4 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvBancoConsulta.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarNominaArchivos()
        Try
            DgvNominaArchivo.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=5 and IDProceso=1 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvNominaArchivo.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarNominaProcesos()
        Try
            DgvNominaProceso.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=5 and IDProceso=2 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvNominaProceso.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarNominaReportes()
        Try
            DgvNominaReporte.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=5 and IDProceso=3 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvNominaReporte.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub BuscarNominaConsultas()
        Try
            DgvNominaConsulta.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=5 and IDProceso=4 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvNominaConsulta.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub BuscarCXPArchivos()
        Try
            DgvCxpArchivo.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=4 and IDProceso=1 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvCxpArchivo.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarCXPProcesos()
        Try
            DgvCxPProceso.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=4 and IDProceso=2 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvCxPProceso.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarCXPReportes()
        Try
            DgvCxPReportes.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=4 and IDProceso=3 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvCxPReportes.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub BuscarCXPConsultas()
        Try
            DgvCXPConsultas.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=4 and IDProceso=4 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvCXPConsultas.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub BuscarCXCArchivos()
        Try
            DgvCXCArchivo.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=3 and IDProceso=1 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvCXCArchivo.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarCXCProcesos()
        Try
            DgvCxCProceso.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=3 and IDProceso=2 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvCxCProceso.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarCXCReportes()
        Try
            DgvCxcReportes.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=3 and IDProceso=3 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvCxcReportes.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub BuscarCXCConsultas()
        Try
            DgvCxcConsultas.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=3 and IDProceso=4 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvCxcConsultas.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub BuscarFacturacionArchivos()
        Try
            DgvFacturacionArchivo.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=2 and IDProceso=1 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvFacturacionArchivo.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarFacturacionProcesos()
        Try
            DgvFacturacionProceso.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=2 and IDProceso=2 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvFacturacionProceso.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarFacturacionReportes()
        Try
            DgvFacturacionReporte.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=2 and IDProceso=3 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvFacturacionReporte.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub BuscarFacturacionConsultas()
        Try
            DgvFacturacionConsulta.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=2 and IDProceso=4 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvFacturacionConsulta.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        chkInventario.Checked = chkTodos.Checked
        chkFacturacion.Checked = chkTodos.Checked
        ChkBancos.Checked = chkTodos.Checked
        ChkContabilidad.Checked = chkTodos.Checked
        chkCxC.Checked = chkTodos.Checked
        chkCxP.Checked = chkTodos.Checked
        ChkNomina.Checked = chkTodos.Checked
        ChkCajaChica.Checked = chkTodos.Checked
        ChkSupervision.Checked = chkTodos.Checked
        ChkUtilidades.Checked = chkTodos.Checked

        If txtIDUsuario.Text <> "" Then
            If DgvPrecios.Rows.Count > 0 Then
                DgvPrecios.Rows(0).Cells(4).Value = chkTodos.Checked
                DgvPrecios.Rows(0).Cells(5).Value = chkTodos.Checked
                DgvPrecios.Rows(0).Cells(6).Value = chkTodos.Checked
                DgvPrecios.Rows(0).Cells(7).Value = chkTodos.Checked
                DgvPrecios.Rows(0).Cells(8).Value = chkTodos.Checked
            End If
        End If
    End Sub

    Private Sub BuscarModuloInventario()
        BuscarInventarioArchivos()
        BuscarInventarioProcesos()
        BuscarInventarioReportes()
        BuscarInventarioConsultas()
    End Sub

    Private Sub BuscarInventarioArchivos()
        Try
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
            DgvInventarioArchivos.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM permisos Where IDModulo=1 and IDProceso=1 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvInventarioArchivos.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarInventarioProcesos()
        Try
            DgvInventarioProcesos.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM permisos Where IDModulo=1 and IDProceso=2 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvInventarioProcesos.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarInventarioReportes()
        Try
            DgvInventarioReportes.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=1 and IDProceso=3 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvInventarioReportes.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub BuscarInventarioConsultas()
        Try
            DgvInventarioConsultas.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDPermisos,Descripcion FROM Permisos Where IDModulo=1 and IDProceso=4 Order by Orden Asc", Con)
            Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

            While LectorDocumentos.Read
                DgvInventarioConsultas.Rows.Add("", LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), False, False, False)
            End While
            LectorDocumentos.Close()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btn_Suplidor_Click(sender As Object, e As EventArgs) Handles btn_Suplidor.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
        If txtIDUsuario.Text <> "" Then
            BuscarPermisosUsuarios()
        End If
    End Sub

    Private Sub BuscarPermisosUsuarios()
        Try
            Dim IDPermiso, Acceso, Crear, Modificar, Imprimir As New Label
            Dim ImgFile As Image

            Con.Open()
            Ds.Clear()
            cmd = New MySqlCommand("Select IDPermisoEmpleado,IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir from PermisosEmpleados Where IDEmpleado='" + txtIDUsuario.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "PermisosEmpleados")

            Dim Tabla As DataTable = Ds.Tables("PermisosEmpleados")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If txtIDUsuario.Text = "" Then
                'Buscando precios autorizados
                DgvPrecios.Rows.Clear()
                Dim Consulta As New MySqlCommand("SELECT IDPreciosEmpleados,Empleados.RutaFoto,Empleados.Nombre,'Precios autorizados por nivel',PrecioA,PrecioB,PrecioC,PrecioD,PrecioBlackFriday FROM preciosempleados inner join" & SysName.Text & "empleados on preciosempleados.idempleado=empleados.idempleado where Empleados.Nulo=0", Con)
                Dim LectorPrecios As MySqlDataReader = Consulta.ExecuteReader

                While LectorPrecios.Read
                    If LectorPrecios.GetValue(1) = "" Then
                        ImgFile = ResizeImage(My.Resources.No_Image, 50)
                    Else
                        If System.IO.File.Exists(LectorPrecios.GetValue(1)) Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(LectorPrecios.GetValue(1), FileMode.Open, FileAccess.Read)
                            ImgFile = ResizeImage(System.Drawing.Image.FromStream(wFile), 50)
                            wFile.Close()
                        Else
                            ImgFile = ResizeImage(My.Resources.No_Image, 50)
                        End If
                    End If

                    DgvPrecios.Rows.Add(LectorPrecios.GetValue(0), ImgFile, LectorPrecios.GetValue(2), "Niveles de precios autorizados", CBool(LectorPrecios.GetValue(4)), CBool(LectorPrecios.GetValue(5)), CBool(LectorPrecios.GetValue(6)), CBool(LectorPrecios.GetValue(7)), CBool(LectorPrecios.GetValue(8)))
                End While

                LectorPrecios.Close()

            Else
                'Buscando precios autorizados
                DgvPrecios.Rows.Clear()

                cmd = New MySqlCommand("SELECT count(IDPreciosEmpleados) FROM preciosempleados where IDEmpleado='" + txtIDUsuario.Text + "'", Con)
                Dim PreciosDados As Integer = Convert.ToString(cmd.ExecuteScalar)

                If PreciosDados = 1 Then
                    Dim Consulta As New MySqlCommand("SELECT IDPreciosEmpleados,Empleados.RutaFoto,Empleados.Nombre,'Precios autorizados por nivel',PrecioA,PrecioB,PrecioC,PrecioD,PrecioBlackFriday FROM preciosempleados inner join" & SysName.Text & "empleados on preciosempleados.idempleado=empleados.idempleado where preciosempleados.IDEmpleado='" + txtIDUsuario.Text + "'", Con)
                    Dim LectorPrecios As MySqlDataReader = Consulta.ExecuteReader

                    Dim wFile As System.IO.FileStream

                    While LectorPrecios.Read
                        If LectorPrecios.GetValue(1) = "" Then
                            ImgFile = ResizeImage(My.Resources.No_Image, 50)
                        Else
                            Dim ExistFile As Boolean = System.IO.File.Exists(LectorPrecios.GetValue(1))
                            If ExistFile = True Then
                                wFile = New FileStream(LectorPrecios.GetValue(1), FileMode.Open, FileAccess.Read)
                                ImgFile = ResizeImage(System.Drawing.Image.FromStream(wFile), 50)
                                wFile.Close()
                            Else
                                ImgFile = ResizeImage(My.Resources.No_Image, 50)
                            End If
                        End If

                        DgvPrecios.Rows.Add(LectorPrecios.GetValue(0), ImgFile, LectorPrecios.GetValue(2), "Niveles de precios autorizados", CBool(LectorPrecios.GetValue(4)), CBool(LectorPrecios.GetValue(5)), CBool(LectorPrecios.GetValue(6)), CBool(LectorPrecios.GetValue(7)), CBool(LectorPrecios.GetValue(8)))
                    End While

                    LectorPrecios.Close()

                ElseIf PreciosDados = 0 Then
                    DgvPrecios.Rows.Add("", Nothing, txtUsuario.Text, "Niveles de precios autorizados", False, False, False, False, False)
                End If
            End If



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("El empleado [" & txtIDUsuario.Text & "] " & txtUsuario.Text & " no tiene ningún tipo de permiso registrado y hábil en la base de datos.", "No se encontraron permisos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                BuscarModulos()
                Exit Sub
            End If

            For Each row As DataGridViewRow In DgvInventarioArchivos.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If

            Next

            For Each row As DataGridViewRow In DgvInventarioProcesos.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvInventarioReportes.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvInventarioConsultas.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvFacturacionArchivo.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvFacturacionProceso.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvFacturacionReporte.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvFacturacionConsulta.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvCXCArchivo.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvCxCProceso.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvCxcReportes.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvCxcConsultas.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvCxpArchivo.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next


            For Each row As DataGridViewRow In DgvCxPProceso.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvCxPReportes.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvCXPConsultas.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvNominaArchivo.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvNominaProceso.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvNominaReporte.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If

            Next

            For Each row As DataGridViewRow In DgvNominaConsulta.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvBancoArchivo.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvBancoProceso.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvBancoReporte.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvBancoConsulta.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvNominaArchivo.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvNominaProceso.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvNominaReporte.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvNominaConsulta.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvSupervisionArchivo.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvSupervisionProceso.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvSupervisionReportes.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvSupervisionConsulta.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvCajaChicaArchivo.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvCajaChicaProcesos.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvCajaChicaReportes.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvCajaChicaConsultas.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next


            For Each row As DataGridViewRow In DgvContabilidadArchivos.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvContabilidadProcesos.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvContabilidadReportes.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next

            For Each row As DataGridViewRow In DgvContabilidadConsultas.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next


            For Each row As DataGridViewRow In DgvUtilidades.Rows
                IDPermiso.Text = row.Cells(1).Value

                Dim results As DataRow() = Tabla.Select("IDPermiso= '" & IDPermiso.Text & "' AND IDEmpleado= '" & txtIDUsuario.Text & "'")

                If results.Count = 0 Then
                    row.Cells(0).Value = ""
                    row.Cells(3).Value = False
                    row.Cells(4).Value = False
                    row.Cells(5).Value = False
                    row.Cells(6).Value = False
                Else
                    row.Cells(0).Value = results(0).Item("IDPermisoEmpleado")
                    row.Cells(3).Value = Convert.ToBoolean(results(0).Item("Acceso"))
                    row.Cells(4).Value = Convert.ToBoolean(results(0).Item("Crear"))
                    row.Cells(5).Value = Convert.ToBoolean(results(0).Item("Modificar"))
                    row.Cells(6).Value = Convert.ToBoolean(results(0).Item("Imprimir"))
                End If
            Next


            Con.Close()

        Catch ex As Exception
            MessageBox.Show(vbNewLine & vbNewLine & ex.Message.ToString)
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim IDPermiso, IDPermisoEmpleado, Acceso, Crear, Modificar, Imprimir As New Label

            If txtIDUsuario.Text = "" Then
                MessageBox.Show("Seleccione un usuario para guardar los permisos.", "Seleccionar usuario", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btn_Suplidor.PerformClick()
                Exit Sub
            End If

            If txtIDUsuario.Text = 1 Or NuevaEstructuracion = True Then
                GoTo CruzarPermisos
            End If

            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

CruzarPermisos:

            Con.Open()
            '-------------------------------------------------------------------------------------------------------------------------------------
            'Permisos Inventario
            'Inventario -Archivos
            For Each row As DataGridViewRow In DgvInventarioArchivos.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Inventario-Procesos
            For Each row As DataGridViewRow In DgvInventarioProcesos.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from Permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Inventario-Reportes
            For Each row As DataGridViewRow In DgvInventarioReportes.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Inventario-Consultas
            For Each row As DataGridViewRow In DgvInventarioConsultas.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado=(Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            '-------------------------------------------------------------------------------------------------------------------------------------

            'Permisos Facturacion
            'Facturacion-Archivos
            For Each row As DataGridViewRow In DgvFacturacionArchivo.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from Permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Facturacion-Procesos
            For Each row As DataGridViewRow In DgvFacturacionProceso.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Facturacion-Reportes
            For Each row As DataGridViewRow In DgvFacturacionReporte.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Facturacion-Consultas
            For Each row As DataGridViewRow In DgvFacturacionConsulta.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from Permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next

            '-------------------------------------------------------------------------------------------------------------------------------------

            'Permisos CXC
            'CXC-Archivos
            For Each row As DataGridViewRow In DgvCXCArchivo.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'CXC-Procesos
            For Each row As DataGridViewRow In DgvCxCProceso.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'CXC-Reportes
            For Each row As DataGridViewRow In DgvCxcReportes.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'CXC-Consultas
            For Each row As DataGridViewRow In DgvCxcConsultas.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next

            '-------------------------------------------------------------------------------------------------------------------------------------

            'Permisos CXP
            'CXP-Archivos
            For Each row As DataGridViewRow In DgvCxpArchivo.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'CXP-Procesos
            For Each row As DataGridViewRow In DgvCxPProceso.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'CXP-Reportes
            For Each row As DataGridViewRow In DgvCxPReportes.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'CXP-Consultas
            For Each row As DataGridViewRow In DgvCXPConsultas.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            ''-------------------------------------------------------------------------------------------------------------------------------------

            'Permisos Nomina
            'Nomina-Archivos
            For Each row As DataGridViewRow In DgvNominaArchivo.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from Permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Nomina-Procesos
            For Each row As DataGridViewRow In DgvNominaProceso.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Nomina-Reportes
            For Each row As DataGridViewRow In DgvNominaReporte.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Nomina-Consultas
            For Each row As DataGridViewRow In DgvNominaConsulta.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            '-------------------------------------------------------------------------------------------------------------------------------------

            'Permisos Bancos
            'Bancos-Archivos
            For Each row As DataGridViewRow In DgvBancoArchivo.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Bancos-Procesos
            For Each row As DataGridViewRow In DgvBancoProceso.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Bancos-Reportes
            For Each row As DataGridViewRow In DgvBancoReporte.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Bancos-Consultas
            For Each row As DataGridViewRow In DgvBancoConsulta.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''
            'Supervision -Archivos
            For Each row As DataGridViewRow In DgvSupervisionArchivo.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Supervision-Procesos
            For Each row As DataGridViewRow In DgvSupervisionProceso.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from Permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Supervision-Reportes
            For Each row As DataGridViewRow In DgvSupervisionReportes.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Supervision-Consultas
            For Each row As DataGridViewRow In DgvSupervisionConsulta.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado=(Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            '-------------------------------------------------------------------------------------------------------------------------------------

            'CajaChica -Archivos
            For Each row As DataGridViewRow In DgvCajaChicaArchivo.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'CajaChica-Procesos
            For Each row As DataGridViewRow In DgvCajaChicaProcesos.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from Permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'CajaChica-Reportes
            For Each row As DataGridViewRow In DgvCajaChicaReportes.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'CajaChica-Consultas
            For Each row As DataGridViewRow In DgvCajaChicaConsultas.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado=(Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            '-------------------------------------------------------------------------------------------------------------------------------------

            'Contabilidad -Archivos
            For Each row As DataGridViewRow In DgvContabilidadArchivos.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Contabilidad-Procesos
            For Each row As DataGridViewRow In DgvContabilidadProcesos.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from Permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Contabilidad-Reportes
            For Each row As DataGridViewRow In DgvContabilidadReportes.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            'Contabilidad-Consultas
            For Each row As DataGridViewRow In DgvContabilidadConsultas.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado=(Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next
            '-------------------------------------------------------------------------------------------------------------------------------------

            'Utilidades
            For Each row As DataGridViewRow In DgvUtilidades.Rows
                IDPermisoEmpleado.Text = Convert.ToString(row.Cells(0).Value)
                IDPermiso.Text = row.Cells(1).Value
                Acceso.Text = Convert.ToInt16(row.Cells(3).Value)
                Crear.Text = Convert.ToInt16(row.Cells(4).Value)
                Modificar.Text = Convert.ToInt16(row.Cells(5).Value)
                Imprimir.Text = Convert.ToInt16(row.Cells(6).Value)

                If CStr(row.Cells(0).Value) = "" Then
                    sqlQ = "INSERT INTO PermisosEmpleados (IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir) VALUES ('" + txtIDUsuario.Text + "','" + IDPermiso.Text + "', '" + Acceso.Text + "','" + Crear.Text + "', '" + Modificar.Text + "','" + Imprimir.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado= (Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    row.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)
                Else
                    sqlQ = "UPDATE PermisosEmpleados SET IDPermiso='" + IDPermiso.Text + "',Acceso='" + Acceso.Text + "',Crear='" + Crear.Text + "',Modificar='" + Modificar.Text + "',Imprimir='" + Imprimir.Text + "' WHERE IDPermisoEmpleado='" + IDPermisoEmpleado.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next

            'Precios   .
            If DgvPrecios.Rows.Count = 0 Then
                DgvPrecios.Rows.Add("", Nothing, txtUsuario.Text, "Niveles de precios autorizados", False, False, False, False, False)
            End If
            If NuevaEstructuracion = True Then
                DgvPrecios.Rows(0).Cells(4).Value = chkTodos.Checked
                DgvPrecios.Rows(0).Cells(5).Value = chkTodos.Checked
                DgvPrecios.Rows(0).Cells(6).Value = chkTodos.Checked
                DgvPrecios.Rows(0).Cells(7).Value = chkTodos.Checked
                DgvPrecios.Rows(0).Cells(8).Value = chkTodos.Checked
            End If

            Dim IDPrecio, PrecioA, PrecioB, PrecioC, PrecioD, PrecioBlackFriday As New Label
            For Each rw As DataGridViewRow In DgvPrecios.Rows
                IDPrecio.Text = rw.Cells(0).Value
                PrecioA.Text = Convert.ToInt16(rw.Cells(4).Value)
                PrecioB.Text = Convert.ToInt16(rw.Cells(5).Value)
                PrecioC.Text = Convert.ToInt16(rw.Cells(6).Value)
                PrecioD.Text = Convert.ToInt16(rw.Cells(7).Value)
                PrecioBlackFriday.Text = Convert.ToInt16(rw.Cells(8).Value)

                If CStr(rw.Cells(0).Value).ToString = "" Then
                    sqlQ = "INSERT INTO PreciosEmpleados (IDEmpleado,PrecioA,PrecioB,PrecioC,PrecioD,PrecioBlackFriday) VALUES ('" + txtIDUsuario.Text + "','" + PrecioA.Text + "', '" + PrecioB.Text + "','" + PrecioC.Text + "', '" + PrecioD.Text + "','" + PrecioBlackFriday.Text + "')"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()

                    cmd = New MySqlCommand("Select IDPermisoEmpleado from permisosempleados where IDPermisoEmpleado=(Select Max(IDPermisoEmpleado) from permisosempleados)", Con)
                    rw.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar)

                Else
                    sqlQ = "UPDATE PreciosEmpleados SET PrecioA='" + PrecioA.Text + "',PrecioB='" + PrecioB.Text + "',PrecioC='" + PrecioC.Text + "',PrecioD='" + PrecioD.Text + "',PrecioBlackFriday='" + PrecioBlackFriday.Text + "' WHERE IDPreciosEmpleados='" + IDPrecio.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                End If
            Next

            Con.Close()

            MessageBox.Show("Los permisos se han guardado satisfactoriamente.", "Se han guardado los permisos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Me.Owner.Name = frm_LoginSistema.Name Then
                Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

    Private Sub chkAccesoInventarioArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoInventarioArchivo.CheckedChanged
        For Each row As DataGridViewRow In DgvInventarioArchivos.Rows
            row.Cells(3).Value = chkAccesoInventarioArchivo.Checked
        Next
    End Sub

    Private Sub chkCrearInventarioArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearInventarioArchivo.CheckedChanged
        For Each row As DataGridViewRow In DgvInventarioArchivos.Rows
            row.Cells(4).Value = chkCrearInventarioArchivo.Checked
        Next
    End Sub

    Private Sub chkModificarInventarioArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarInventarioArchivo.CheckedChanged
        For Each row As DataGridViewRow In DgvInventarioArchivos.Rows
            row.Cells(5).Value = chkModificarInventarioArchivo.Checked
        Next
    End Sub

    Private Sub chkImpimirInventarioArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkImpimirInventarioArchivo.CheckedChanged
        For Each row As DataGridViewRow In DgvInventarioArchivos.Rows
            row.Cells(6).Value = chkImpimirInventarioArchivo.Checked
        Next
    End Sub

    Private Sub chkInventario_CheckedChanged(sender As Object, e As EventArgs) Handles chkInventario.CheckedChanged
        chkAccesoInventarioArchivo.Checked = chkInventario.Checked
        chkCrearInventarioArchivo.Checked = chkInventario.Checked
        chkModificarInventarioArchivo.Checked = chkInventario.Checked
        chkImpimirInventarioArchivo.Checked = chkInventario.Checked
        chkAccesoInventarioProcesos.Checked = chkInventario.Checked
        chkCrearInventarioProcesos.Checked = chkInventario.Checked
        chkModificarInventarioProcesos.Checked = chkInventario.Checked
        chkImprimirInventarioProcesos.Checked = chkInventario.Checked
        chkAccesoInventarioReportes.Checked = chkInventario.Checked
        chkCrearInventarioReportes.Checked = chkInventario.Checked
        chkModificarInventarioReportes.Checked = chkInventario.Checked
        chkImprimirInventarioReportes.Checked = chkInventario.Checked
        chkAccesoInventarioConsulta.Checked = chkInventario.Checked
        chkCrearInventarioConsulta.Checked = chkInventario.Checked
        chkModificarInventarioConsulta.Checked = chkInventario.Checked
        chkImprimirInventarioConsulta.Checked = chkInventario.Checked
    End Sub

    Private Sub chkAccesoInventarioProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoInventarioProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvInventarioProcesos.Rows
            row.Cells(3).Value = chkAccesoInventarioProcesos.Checked
        Next
    End Sub

    Private Sub chkCrearInventarioProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearInventarioProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvInventarioProcesos.Rows
            row.Cells(4).Value = chkCrearInventarioProcesos.Checked
        Next
    End Sub

    Private Sub chkModificarInventarioProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarInventarioProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvInventarioProcesos.Rows
            row.Cells(5).Value = chkModificarInventarioProcesos.Checked
        Next
    End Sub

    Private Sub chkImprimirInventarioProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirInventarioProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvInventarioProcesos.Rows
            row.Cells(6).Value = chkImprimirInventarioProcesos.Checked
        Next
    End Sub

    Private Sub chkAccesoInventarioReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoInventarioReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvInventarioReportes.Rows
            row.Cells(3).Value = chkAccesoInventarioReportes.Checked
        Next
    End Sub

    Private Sub chkCrearInventarioReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearInventarioReportes.CheckedChanged
        'For Each row As DataGridViewRow In DgvInventarioReportes.Rows
        '    row.Cells(4).Value = chkCrearInventarioReportes.Checked
        'Next
    End Sub

    Private Sub chkModificarInventarioReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarInventarioReportes.CheckedChanged
        'For Each row As DataGridViewRow In DgvInventarioReportes.Rows
        '    row.Cells(5).Value = chkModificarInventarioReportes.Checked
        'Next
    End Sub

    Private Sub chkImprimirInventarioReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirInventarioReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvInventarioReportes.Rows
            row.Cells(6).Value = chkImprimirInventarioReportes.Checked
        Next
    End Sub

    Private Sub chkAccesoInventarioConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoInventarioConsulta.CheckedChanged
        For Each row As DataGridViewRow In DgvInventarioConsultas.Rows
            row.Cells(3).Value = chkAccesoInventarioConsulta.Checked
        Next
    End Sub

    Private Sub chkCrearInventarioConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearInventarioConsulta.CheckedChanged
        'For Each row As DataGridViewRow In DgvInventarioConsultas.Rows
        '    row.Cells(4).Value = chkCrearInventarioConsulta.Checked
        'Next
    End Sub

    Private Sub chkModificarInventarioConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarInventarioConsulta.CheckedChanged
        For Each row As DataGridViewRow In DgvInventarioConsultas.Rows
            row.Cells(5).Value = chkModificarInventarioConsulta.Checked
        Next
    End Sub

    Private Sub chkImprimirInventarioConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirInventarioConsulta.CheckedChanged
        For Each row As DataGridViewRow In DgvInventarioConsultas.Rows
            row.Cells(6).Value = chkImprimirInventarioConsulta.Checked
        Next
    End Sub

    Private Sub chkFacturacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkFacturacion.CheckedChanged
        chkAccesoFacturacionArchivo.Checked = chkFacturacion.Checked
        chkCrearFacturacionArchivo.Checked = chkFacturacion.Checked
        chkModificarFacturacionArchivo.Checked = chkFacturacion.Checked
        chkImprimirFacturacionArchivo.Checked = chkFacturacion.Checked
        chkAccesoFacturacionProceso.Checked = chkFacturacion.Checked
        chkCrearFacturacionProceso.Checked = chkFacturacion.Checked
        chkModificarFacturacionProceso.Checked = chkFacturacion.Checked
        chkImprimirFacturacionProceso.Checked = chkFacturacion.Checked
        chkAccesoFacturacionReporte.Checked = chkFacturacion.Checked
        'chkCrearFacturacionReporte.Checked = chkFacturacion.Checked
        'chkModificarFacturacionReporte.Checked = chkFacturacion.Checked
        chkImprimirFacturacionReporte.Checked = chkFacturacion.Checked
        chkAccesoFacturacionConsulta.Checked = chkFacturacion.Checked
        'chkCrearFacturacionConsulta.Checked = chkFacturacion.Checked
        chkModificarFacturacionConsulta.Checked = chkFacturacion.Checked
        chkImprimirFacturacionConsulta.Checked = chkFacturacion.Checked
    End Sub

    Private Sub chkAccesoFacturacionArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoFacturacionArchivo.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionArchivo.Rows
            row.Cells(3).Value = chkAccesoFacturacionArchivo.Checked
        Next
    End Sub

    Private Sub chkCrearFacturacionArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearFacturacionArchivo.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionArchivo.Rows
            row.Cells(4).Value = chkCrearFacturacionArchivo.Checked
        Next
    End Sub

    Private Sub chkModificarFacturacionArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarFacturacionArchivo.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionArchivo.Rows
            row.Cells(5).Value = chkModificarFacturacionArchivo.Checked
        Next
    End Sub

    Private Sub chkImprimirFacturacionArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirFacturacionArchivo.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionArchivo.Rows
            row.Cells(6).Value = chkImprimirFacturacionArchivo.Checked
        Next
    End Sub

    Private Sub chkCxC_CheckedChanged(sender As Object, e As EventArgs) Handles chkCxC.CheckedChanged
        chkAccesoCXCArchivo.Checked = chkCxC.Checked
        chkCrearCXCArchivo.Checked = chkCxC.Checked
        chkModificarCXCArchivo.Checked = chkCxC.Checked
        chkImprimirCXCArchivo.Checked = chkCxC.Checked
        chkAccesoCXCProcesos.Checked = chkCxC.Checked
        chkCrearCXCProcesos.Checked = chkCxC.Checked
        chkModificarCXCProcesos.Checked = chkCxC.Checked
        chkImprimirCXCProcesos.Checked = chkCxC.Checked
        chkAccesoCXCReportes.Checked = chkCxC.Checked
        'chkCrearCXCReportes.Checked = chkCxC.Checked
        'chkModificarCXCReportes.Checked = chkCxC.Checked
        chkImprimirCXCReportes.Checked = chkCxC.Checked
        chkAccesoCXCConsulta.Checked = chkCxC.Checked
        'chkCrearCXCConsulta.Checked = chkCxC.Checked
        chkModificarCXCConsulta.Checked = chkCxC.Checked
        chkImprimirCXCConsulta.Checked = chkCxC.Checked
    End Sub

    Private Sub chkAccesoCXCArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoCXCArchivo.CheckedChanged
        For Each row As DataGridViewRow In DgvCXCArchivo.Rows
            row.Cells(3).Value = chkAccesoCXCArchivo.Checked
        Next
    End Sub

    Private Sub chkCrearCXCArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearCXCArchivo.CheckedChanged
        For Each row As DataGridViewRow In DgvCXCArchivo.Rows
            row.Cells(4).Value = chkCrearCXCArchivo.Checked
        Next
    End Sub

    Private Sub chkModificarCXCArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarCXCArchivo.CheckedChanged
        For Each row As DataGridViewRow In DgvCXCArchivo.Rows
            row.Cells(5).Value = chkModificarCXCArchivo.Checked
        Next
    End Sub

    Private Sub chkImprimirCXCArchivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirCXCArchivo.CheckedChanged
        For Each row As DataGridViewRow In DgvCXCArchivo.Rows
            row.Cells(6).Value = chkImprimirCXCArchivo.Checked
        Next
    End Sub

    Private Sub chkAccesoCXCProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoCXCProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvCxCProceso.Rows
            row.Cells(3).Value = chkAccesoCXCProcesos.Checked
        Next
    End Sub

    Private Sub chkCrearCXCProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearCXCProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvCxCProceso.Rows
            row.Cells(4).Value = chkCrearCXCProcesos.Checked
        Next
    End Sub

    Private Sub chkModificarCXCProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarCXCProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvCxCProceso.Rows
            row.Cells(5).Value = chkModificarCXCProcesos.Checked
        Next
    End Sub

    Private Sub chkImprimirCXCProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirCXCProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvCxCProceso.Rows
            row.Cells(6).Value = chkImprimirCXCProcesos.Checked
        Next
    End Sub

    Private Sub chkAccesoCXCReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoCXCReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvCxcReportes.Rows
            row.Cells(3).Value = chkAccesoCXCReportes.Checked
        Next
    End Sub

    Private Sub chkCrearCXCReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearCXCReportes.CheckedChanged
        'For Each row As DataGridViewRow In DgvCxcReportes.Rows
        '    row.Cells(4).Value = chkCrearCXCReportes.Checked
        'Next
    End Sub

    Private Sub chkModificarCXCReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarCXCReportes.CheckedChanged
        'For Each row As DataGridViewRow In DgvCxcReportes.Rows
        '    row.Cells(5).Value = chkCrearCXCReportes.Checked
        'Next
    End Sub

    Private Sub chkImprimirCXCReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirCXCReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvCxcReportes.Rows
            row.Cells(6).Value = chkImprimirCXCReportes.Checked
        Next
    End Sub

    Private Sub chkAccesoCXCConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoCXCConsulta.CheckedChanged
        For Each row As DataGridViewRow In DgvCxcConsultas.Rows
            row.Cells(3).Value = chkAccesoCXCConsulta.Checked
        Next
    End Sub

    Private Sub chkCrearCXCConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearCXCConsulta.CheckedChanged
        For Each row As DataGridViewRow In DgvCxcConsultas.Rows
            row.Cells(4).Value = chkCrearCXCConsulta.Checked
        Next
    End Sub

    Private Sub chkModificarCXCConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarCXCConsulta.CheckedChanged
        For Each row As DataGridViewRow In DgvCxcConsultas.Rows
            row.Cells(5).Value = chkModificarCXCConsulta.Checked
        Next
    End Sub

    Private Sub chkImprimirCXCConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirCXCConsulta.CheckedChanged
        For Each row As DataGridViewRow In DgvCxcConsultas.Rows
            row.Cells(6).Value = chkImprimirCXCConsulta.Checked
        Next
    End Sub

    Private Sub chkCxP_CheckedChanged(sender As Object, e As EventArgs) Handles chkCxP.CheckedChanged
        chkAccesoCXPArchivos.Checked = chkCxP.Checked
        chkCrearCXPArchivos.Checked = chkCxP.Checked
        chkModificarCXPArchivos.Checked = chkCxP.Checked
        chkImprimirCXPArchivos.Checked = chkCxP.Checked
        chkAccesoCXPProcesos.Checked = chkCxP.Checked
        chkCrearCXPProcesos.Checked = chkCxP.Checked
        chkModificarCXPProcesos.Checked = chkCxP.Checked
        chkImprimirCXPProcesos.Checked = chkCxP.Checked
        chkAccesoCXPReporte.Checked = chkCxP.Checked
        'chkCrearCXPReporte.Checked = chkCxP.Checked
        'chkModificarCXPReporte.Checked = chkCxP.Checked
        chkImprimirCXPReporte.Checked = chkCxP.Checked
        chkAccesoCXPConsultas.Checked = chkCxP.Checked
        'chkCrearCXPConsultas.Checked = chkCxP.Checked
        chkModificarCXPConsultas.Checked = chkCxP.Checked
        chkImprimirCXPConsultas.Checked = chkCxP.Checked
    End Sub

    Private Sub ChkNomina_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNomina.CheckedChanged
        chkAccesoNominaArchivos.Checked = ChkNomina.Checked
        chkCrearNominaArchivos.Checked = ChkNomina.Checked
        chkModificarNominaArchivos.Checked = ChkNomina.Checked
        chkImprimirNominaArchivos.Checked = ChkNomina.Checked
        chkAccesoNominaProceso.Checked = ChkNomina.Checked
        chkCrearNominaProceso.Checked = ChkNomina.Checked
        chkModificarNominaProceso.Checked = ChkNomina.Checked
        chkImprimirNominaProceso.Checked = ChkNomina.Checked
        chkAccesoNominaReportes.Checked = ChkNomina.Checked
        'chkCrearNominaReportes.Checked = ChkNomina.Checked
        'chkModificarNominaReportes.Checked = ChkNomina.Checked
        chkImprimirNominaReportes.Checked = ChkNomina.Checked
        chkAccesoNominaConsultas.Checked = ChkNomina.Checked
        'chkCrearNominaConsultas.Checked = ChkNomina.Checked
        chkModificarNominaConsultas.Checked = ChkNomina.Checked
        chkImprimirNominaConsultas.Checked = ChkNomina.Checked
    End Sub

    Private Sub ChkBancos_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBancos.CheckedChanged
        chkAccesoBancosArchivos.Checked = ChkBancos.Checked
        chkCrearBancosArchivos.Checked = ChkBancos.Checked
        chkModificarBancosArchivos.Checked = ChkBancos.Checked
        chkImprimirBancosArchivos.Checked = ChkBancos.Checked
        chkAccesoBancosProcesos.Checked = ChkBancos.Checked
        chkCrearBancosProcesos.Checked = ChkBancos.Checked
        chkModificarBancosProcesos.Checked = ChkBancos.Checked
        chkImprimirBancosProcesos.Checked = ChkBancos.Checked
        chkAccesoBancosReportes.Checked = ChkBancos.Checked
        'chkCrearBancosReportes.Checked = ChkBancos.Checked
        'chkModificarBancosReportes.Checked = ChkBancos.Checked
        chkImprimirBancosReportes.Checked = ChkBancos.Checked
        chkAccesoBancosConsultas.Checked = ChkBancos.Checked
        'chkCrearBancosConsultas.Checked = ChkBancos.Checked
        chkModificarBancosConsultas.Checked = ChkBancos.Checked
        chkImprimirBancosConsultas.Checked = ChkBancos.Checked
    End Sub

    Private Sub chkAccesoCXPArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoCXPArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvCxpArchivo.Rows
            row.Cells(3).Value = chkAccesoCXPArchivos.Checked
        Next
    End Sub

    Private Sub chkCrearCXPArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearCXPArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvCxpArchivo.Rows
            row.Cells(4).Value = chkCrearCXPArchivos.Checked
        Next
    End Sub

    Private Sub chkModificarCXPArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarCXPArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvCxpArchivo.Rows
            row.Cells(5).Value = chkModificarCXPArchivos.Checked
        Next
    End Sub

    Private Sub chkImprimirCXPArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirCXPArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvCxpArchivo.Rows
            row.Cells(6).Value = chkImprimirCXPArchivos.Checked
        Next
    End Sub

    Private Sub chkAccesoCXPProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoCXPProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvCxPProceso.Rows
            row.Cells(3).Value = chkAccesoCXPProcesos.Checked
        Next
    End Sub

    Private Sub chkCrearCXPProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearCXPProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvCxPProceso.Rows
            row.Cells(4).Value = chkCrearCXPProcesos.Checked
        Next
    End Sub

    Private Sub chkModificarCXPProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarCXPProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvCxPProceso.Rows
            row.Cells(5).Value = chkModificarCXPProcesos.Checked
        Next
    End Sub

    Private Sub chkImprimirCXPProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirCXPProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvCxPProceso.Rows
            row.Cells(6).Value = chkImprimirCXPProcesos.Checked
        Next
    End Sub

    Private Sub chkAccesoCXPReporte_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoCXPReporte.CheckedChanged
        For Each row As DataGridViewRow In DgvCxPReportes.Rows
            row.Cells(3).Value = chkAccesoCXPReporte.Checked
        Next
    End Sub

    Private Sub chkModificarCXPReporte_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarCXPReporte.CheckedChanged
        'For Each row As DataGridViewRow In DgvCxPReportes.Rows
        '    row.Cells(5).Value = chkModificarCXPReporte.Checked
        'Next
    End Sub

    Private Sub chkCrearCXPReporte_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearCXPReporte.CheckedChanged
        'For Each row As DataGridViewRow In DgvCxPReportes.Rows
        '    row.Cells(4).Value = chkCrearCXPReporte.Checked
        'Next
    End Sub

    Private Sub chkImprimirCXPReporte_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirCXPReporte.CheckedChanged
        For Each row As DataGridViewRow In DgvCxPReportes.Rows
            row.Cells(6).Value = chkImprimirCXPReporte.Checked
        Next
    End Sub

    Private Sub chkAccesoCXPConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoCXPConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvCXPConsultas.Rows
            row.Cells(3).Value = chkAccesoCXPConsultas.Checked
        Next
    End Sub

    Private Sub chkCrearCXPConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearCXPConsultas.CheckedChanged
        'For Each row As DataGridViewRow In DgvCXPConsultas.Rows
        '    row.Cells(4).Value = chkCrearCXPConsultas.Checked
        'Next
    End Sub

    Private Sub chkModificarCXPConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarCXPConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvCXPConsultas.Rows
            row.Cells(5).Value = chkModificarCXPConsultas.Checked
        Next
    End Sub

    Private Sub chkImprimirCXPConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirCXPConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvCXPConsultas.Rows
            row.Cells(6).Value = chkImprimirCXPConsultas.Checked
        Next
    End Sub

    Private Sub chkAccesoNominaArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoNominaArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvNominaArchivo.Rows
            row.Cells(3).Value = chkAccesoNominaArchivos.Checked
        Next
    End Sub

    Private Sub chkCrearNominaArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearNominaArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvNominaArchivo.Rows
            row.Cells(4).Value = chkCrearNominaArchivos.Checked
        Next
    End Sub

    Private Sub chkModificarNominaArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarNominaArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvNominaArchivo.Rows
            row.Cells(5).Value = chkModificarNominaArchivos.Checked
        Next
    End Sub

    Private Sub chkImprimirNominaArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirNominaArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvNominaArchivo.Rows
            row.Cells(6).Value = chkImprimirNominaArchivos.Checked
        Next
    End Sub

    Private Sub chkAccesoNominaProceso_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoNominaProceso.CheckedChanged
        For Each row As DataGridViewRow In DgvNominaProceso.Rows
            row.Cells(3).Value = chkAccesoNominaProceso.Checked
        Next
    End Sub

    Private Sub chkCrearNominaProceso_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearNominaProceso.CheckedChanged
        For Each row As DataGridViewRow In DgvNominaProceso.Rows
            row.Cells(4).Value = chkCrearNominaProceso.Checked
        Next
    End Sub

    Private Sub chkModificarNominaProceso_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarNominaProceso.CheckedChanged
        For Each row As DataGridViewRow In DgvNominaProceso.Rows
            row.Cells(5).Value = chkModificarNominaProceso.Checked
        Next
    End Sub

    Private Sub chkImprimirNominaProceso_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirNominaProceso.CheckedChanged
        For Each row As DataGridViewRow In DgvNominaProceso.Rows
            row.Cells(6).Value = chkImprimirNominaProceso.Checked
        Next
    End Sub

    Private Sub chkAccesoNominaReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoNominaReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvNominaReporte.Rows
            row.Cells(3).Value = chkAccesoNominaReportes.Checked
        Next
    End Sub

    Private Sub chkCrearNominaReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearNominaReportes.CheckedChanged
        'For Each row As DataGridViewRow In DgvNominaReporte.Rows
        '    row.Cells(4).Value = chkCrearNominaReportes.Checked
        'Next
    End Sub

    Private Sub chkModificarNominaReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarNominaReportes.CheckedChanged
        'For Each row As DataGridViewRow In DgvNominaReporte.Rows
        '    row.Cells(5).Value = chkModificarNominaReportes.Checked
        'Next
    End Sub

    Private Sub chkImprimirNominaReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirNominaReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvNominaReporte.Rows
            row.Cells(6).Value = chkImprimirNominaReportes.Checked
        Next
    End Sub

    Private Sub chkAccesoNominaConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoNominaConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvNominaConsulta.Rows
            row.Cells(3).Value = chkAccesoNominaConsultas.Checked
        Next
    End Sub

    Private Sub chkCrearNominaConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearNominaConsultas.CheckedChanged
        'For Each row As DataGridViewRow In DgvNominaConsulta.Rows
        '    row.Cells(4).Value = chkCrearNominaConsultas.Checked
        'Next
    End Sub

    Private Sub chkModificarNominaConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarNominaConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvNominaConsulta.Rows
            row.Cells(5).Value = chkModificarNominaConsultas.Checked
        Next
    End Sub
   
    Private Sub chkImprimirNominaConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirNominaConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvNominaConsulta.Rows
            row.Cells(6).Value = chkImprimirNominaConsultas.Checked
        Next
    End Sub

    Private Sub chkAccesoBancosConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoBancosConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoConsulta.Rows
            row.Cells(3).Value = chkAccesoBancosConsultas.Checked
        Next
    End Sub

    Private Sub chkCrearBancosConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearBancosConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoConsulta.Rows
            row.Cells(4).Value = chkCrearBancosConsultas.Checked
        Next
    End Sub

    Private Sub chkModificarBancosConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarBancosConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoConsulta.Rows
            row.Cells(5).Value = chkModificarBancosConsultas.Checked
        Next
    End Sub

    Private Sub chkImprimirBancosConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirBancosConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoConsulta.Rows
            row.Cells(6).Value = chkImprimirBancosConsultas.Checked
        Next
    End Sub

    Private Sub chkAccesoBancosArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoBancosArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoArchivo.Rows
            row.Cells(3).Value = chkAccesoBancosArchivos.Checked
        Next
    End Sub

    Private Sub chkCrearBancosArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearBancosArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoArchivo.Rows
            row.Cells(4).Value = chkCrearBancosArchivos.Checked
        Next
    End Sub

    Private Sub chkModificarBancosArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarBancosArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoArchivo.Rows
            row.Cells(5).Value = chkModificarBancosArchivos.Checked
        Next
    End Sub

    Private Sub chkImprimirBancosArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirBancosArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoArchivo.Rows
            row.Cells(6).Value = chkImprimirBancosArchivos.Checked
        Next
    End Sub

    Private Sub chkAccesoBancosProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoBancosProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoProceso.Rows
            row.Cells(3).Value = chkAccesoBancosProcesos.Checked
        Next
    End Sub

    Private Sub chkCrearBancosProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearBancosProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoProceso.Rows
            row.Cells(4).Value = chkCrearBancosProcesos.Checked
        Next
    End Sub

    Private Sub chkModificarBancosProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarBancosProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoProceso.Rows
            row.Cells(5).Value = chkModificarBancosProcesos.Checked
        Next
    End Sub

    Private Sub chkImprimirBancosProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirBancosProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoProceso.Rows
            row.Cells(6).Value = chkImprimirBancosProcesos.Checked
        Next
    End Sub

    Private Sub chkAccesoFacturacionProceso_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoFacturacionProceso.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionProceso.Rows
            row.Cells(3).Value = chkAccesoFacturacionProceso.Checked
        Next
    End Sub

    Private Sub chkCrearFacturacionProceso_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearFacturacionProceso.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionProceso.Rows
            row.Cells(4).Value = chkCrearFacturacionProceso.Checked
        Next

    End Sub

    Private Sub chkModificarFacturacionProceso_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarFacturacionProceso.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionProceso.Rows
            row.Cells(5).Value = chkModificarFacturacionProceso.Checked
        Next
    End Sub

    Private Sub chkImprimirFacturacionProceso_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirFacturacionProceso.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionProceso.Rows
            row.Cells(6).Value = chkImprimirFacturacionProceso.Checked
        Next
    End Sub

    Private Sub chkAccesoFacturacionReporte_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoFacturacionReporte.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionReporte.Rows
            row.Cells(3).Value = chkAccesoFacturacionReporte.Checked
        Next
    End Sub

    Private Sub chkCrearFacturacionReporte_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearFacturacionReporte.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionReporte.Rows
            row.Cells(4).Value = chkCrearFacturacionReporte.Checked
        Next
    End Sub

    Private Sub chkModificarFacturacionReporte_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarFacturacionReporte.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionReporte.Rows
            row.Cells(5).Value = chkModificarFacturacionReporte.Checked
        Next
    End Sub

    Private Sub chkImprimirFacturacionReporte_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirFacturacionReporte.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionReporte.Rows
            row.Cells(6).Value = chkImprimirFacturacionReporte.Checked
        Next
    End Sub

    Private Sub chkAccesoFacturacionConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoFacturacionConsulta.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionConsulta.Rows
            row.Cells(3).Value = chkAccesoFacturacionConsulta.Checked
        Next
    End Sub

    Private Sub chkCrearFacturacionConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearFacturacionConsulta.CheckedChanged
        'For Each row As DataGridViewRow In DgvFacturacionConsulta.Rows
        '    row.Cells(4).Value = chkCrearFacturacionConsulta.Checked
        'Next
    End Sub

    Private Sub chkModificarFacturacionConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarFacturacionConsulta.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionConsulta.Rows
            row.Cells(5).Value = chkModificarFacturacionConsulta.Checked
        Next
    End Sub

    Private Sub chkImprimirFacturacionConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirFacturacionConsulta.CheckedChanged
        For Each row As DataGridViewRow In DgvFacturacionConsulta.Rows
            row.Cells(6).Value = chkImprimirFacturacionConsulta.Checked
        Next
    End Sub

    Private Sub chkAccesoBancosReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoBancosReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoReporte.Rows
            row.Cells(3).Value = chkAccesoBancosReportes.Checked
        Next
    End Sub

    Private Sub chkCrearBancosReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearBancosReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoReporte.Rows
            row.Cells(4).Value = chkCrearBancosReportes.Checked
        Next
    End Sub

    Private Sub chkModificarBancosReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarBancosReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoReporte.Rows
            row.Cells(5).Value = chkModificarBancosReportes.Checked
        Next
    End Sub

    Private Sub chkImprimirBancosReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirBancosReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvBancoReporte.Rows
            row.Cells(6).Value = chkImprimirBancosReportes.Checked
        Next
    End Sub

    Private Sub chkAccesoUtilitarios_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoUtilitarios.CheckedChanged
        For Each row As DataGridViewRow In DgvUtilidades.Rows
            row.Cells(3).Value = chkAccesoUtilitarios.Checked
        Next
    End Sub

    Private Sub ChkUtilidades_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUtilidades.CheckedChanged
        chkAccesoUtilitarios.Checked = ChkUtilidades.Checked
    End Sub

    Private Sub chkAccesoSupervisionArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoSupervisionArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionArchivo.Rows
            row.Cells(3).Value = chkAccesoSupervisionArchivos.Checked
        Next
    End Sub

    Private Sub chkAccesoSupervisionProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoSupervisionProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionProceso.Rows
            row.Cells(3).Value = chkAccesoSupervisionProcesos.Checked
        Next
    End Sub

    Private Sub chkAccesoSupervisionReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoSupervisionReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionReportes.Rows
            row.Cells(3).Value = chkAccesoSupervisionReportes.Checked
        Next
    End Sub

    Private Sub chkAccesoSupervisionConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoSupervisionConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionConsulta.Rows
            row.Cells(3).Value = chkAccesoSupervisionConsultas.Checked
        Next
    End Sub

    Private Sub chkCrearSupervisionArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearSupervisionArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionArchivo.Rows
            row.Cells(4).Value = chkCrearSupervisionArchivos.Checked
        Next
    End Sub

    Private Sub chkCrearSupervisionProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearSupervisionProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionProceso.Rows
            row.Cells(4).Value = chkCrearSupervisionProcesos.Checked
        Next
    End Sub

    Private Sub chkCrearSupervisionReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearSupervisionReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionReportes.Rows
            row.Cells(4).Value = chkCrearSupervisionReportes.Checked
        Next
    End Sub

    Private Sub chkCrearSupervisionConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearSupervisionConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionConsulta.Rows
            row.Cells(4).Value = chkCrearSupervisionConsultas.Checked
        Next
    End Sub

    Private Sub chkModificarSupervisionConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarSupervisionConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionConsulta.Rows
            row.Cells(5).Value = chkModificarSupervisionConsultas.Checked
        Next
    End Sub

    Private Sub chkModificarSupervisionReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarSupervisionReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionReportes.Rows
            row.Cells(5).Value = chkModificarSupervisionReportes.Checked
        Next
    End Sub

    Private Sub chkModificarSupervisionProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarSupervisionProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionProceso.Rows
            row.Cells(5).Value = chkModificarSupervisionProcesos.Checked
        Next
    End Sub

    Private Sub chkModificarSupervisionArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarSupervisionArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionArchivo.Rows
            row.Cells(5).Value = chkModificarSupervisionArchivos.Checked
        Next
    End Sub

    Private Sub ChkSupervision_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSupervision.CheckedChanged
        chkAccesoSupervisionArchivos.Checked = ChkSupervision.Checked
        chkCrearSupervisionArchivos.Checked = ChkSupervision.Checked
        chkModificarSupervisionArchivos.Checked = ChkSupervision.Checked
        chkImprimirSupervisionArchivos.Checked = ChkSupervision.Checked
        chkAccesoSupervisionProcesos.Checked = ChkSupervision.Checked
        chkCrearSupervisionProcesos.Checked = ChkSupervision.Checked
        chkModificarSupervisionProcesos.Checked = ChkSupervision.Checked
        chkImprimirSupervisionProcesos.Checked = ChkSupervision.Checked
        chkAccesoSupervisionReportes.Checked = ChkSupervision.Checked
        'chkCrearsupervisionReportes.Checked = Chksupervision.Checked
        'chkModificarsupervisionReportes.Checked = Chksupervision.Checked
        chkImprimirSupervisionReportes.Checked = ChkSupervision.Checked
        chkAccesoSupervisionConsultas.Checked = ChkSupervision.Checked
        'chkCrearsupervisionConsultas.Checked = Chksupervision.Checked
        chkModificarSupervisionConsultas.Checked = ChkSupervision.Checked
        chkImprimirSupervisionConsultas.Checked = ChkSupervision.Checked
    End Sub

    Private Sub chkImprimirSupervisionArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirSupervisionArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionArchivo.Rows
            row.Cells(6).Value = chkImprimirSupervisionArchivos.Checked
        Next
    End Sub

    Private Sub chkImprimirSupervisionProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirSupervisionProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionProceso.Rows
            row.Cells(6).Value = chkImprimirSupervisionProcesos.Checked
        Next
    End Sub

    Private Sub chkImprimirSupervisionReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirSupervisionReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionReportes.Rows
            row.Cells(6).Value = chkImprimirSupervisionReportes.Checked
        Next
    End Sub

    Private Sub chkImprimirSupervisionConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirSupervisionConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvSupervisionConsulta.Rows
            row.Cells(6).Value = chkImprimirSupervisionConsultas.Checked
        Next
    End Sub

    Private Sub ChkCajaChica_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCajaChica.CheckedChanged
        chkAccesoCajaChicaArchivos.Checked = ChkCajaChica.Checked
        chkCrearCajaChicaArchivos.Checked = ChkCajaChica.Checked
        chkModificarCajaChicaArchivos.Checked = ChkCajaChica.Checked
        chkImprimirCajaChicaArchivos.Checked = ChkCajaChica.Checked
        chkAccesoCajaChicaProcesos.Checked = ChkCajaChica.Checked
        chkCrearCajaChicaProcesos.Checked = ChkCajaChica.Checked
        chkModificarCajaChicaProcesos.Checked = ChkCajaChica.Checked
        chkImprimirCajaChicaProcesos.Checked = ChkCajaChica.Checked
        chkAccesoCajaChicaReportes.Checked = ChkCajaChica.Checked
        'chkCrearCajaChicaReportes.Checked = ChkCajaChica.Checked
        'chkModificarCajaChicaReportes.Checked =ChkCajaChica.Checked
        chkImprimirCajaChicaReportes.Checked = ChkCajaChica.Checked
        chkAccesoCajaChicaConsultas.Checked = ChkCajaChica.Checked
        'chkCrearCajaChicaConsultas.Checked = ChkCajaChica.Checked
        chkModificarCajaChicaConsultas.Checked = ChkCajaChica.Checked
        chkImprimirCajaChicaConsultas.Checked = ChkCajaChica.Checked
    End Sub

    Private Sub chkAccesoCajaChicaArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoCajaChicaArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaArchivo.Rows
            row.Cells(3).Value = chkAccesoCajaChicaArchivos.Checked
        Next
    End Sub

    Private Sub chkCrearCajaChicaArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearCajaChicaArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaArchivo.Rows
            row.Cells(4).Value = chkCrearCajaChicaArchivos.Checked
        Next
    End Sub

    Private Sub chkModificarCajaChicaArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarCajaChicaArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaArchivo.Rows
            row.Cells(5).Value = chkModificarCajaChicaArchivos.Checked
        Next
    End Sub

    Private Sub chkImprimirCajaChicaArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirCajaChicaArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaArchivo.Rows
            row.Cells(6).Value = chkImprimirCajaChicaArchivos.Checked
        Next
    End Sub

    Private Sub chkAccesoCajaChicaProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoCajaChicaProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaProcesos.Rows
            row.Cells(3).Value = chkAccesoCajaChicaProcesos.Checked
        Next
    End Sub

    Private Sub chkCrearCajaChicaProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearCajaChicaProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaProcesos.Rows
            row.Cells(4).Value = chkCrearCajaChicaProcesos.Checked
        Next
    End Sub

    Private Sub chkModificarCajaChicaProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarCajaChicaProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaProcesos.Rows
            row.Cells(5).Value = chkModificarCajaChicaProcesos.Checked
        Next
    End Sub

    Private Sub chkImprimirCajaChicaProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirCajaChicaProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaProcesos.Rows
            row.Cells(6).Value = chkImprimirCajaChicaProcesos.Checked
        Next
    End Sub

    Private Sub chkAccesoCajaChicaReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoCajaChicaReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaReportes.Rows
            row.Cells(3).Value = chkAccesoCajaChicaReportes.Checked
        Next
    End Sub

    Private Sub chkCrearCajaChicaReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearCajaChicaReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaReportes.Rows
            row.Cells(4).Value = chkCrearCajaChicaReportes.Checked
        Next
    End Sub

    Private Sub chkModificarCajaChicaReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarCajaChicaReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaReportes.Rows
            row.Cells(5).Value = chkModificarCajaChicaReportes.Checked
        Next
    End Sub

    Private Sub chkImprimirCajaChicaReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirCajaChicaReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaReportes.Rows
            row.Cells(6).Value = chkImprimirCajaChicaReportes.Checked
        Next
    End Sub

    Private Sub chkAccesoCajaChicaConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoCajaChicaConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaConsultas.Rows
            row.Cells(3).Value = chkAccesoCajaChicaConsultas.Checked
        Next
    End Sub

    Private Sub chkCrearCajaChicaConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearCajaChicaConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaConsultas.Rows
            row.Cells(4).Value = chkCrearCajaChicaConsultas.Checked
        Next
    End Sub

    Private Sub chkModificarCajaChicaConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarCajaChicaConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaConsultas.Rows
            row.Cells(5).Value = chkModificarCajaChicaConsultas.Checked
        Next
    End Sub

    Private Sub chkImprimirCajaChicaConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirCajaChicaConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvCajaChicaConsultas.Rows
            row.Cells(6).Value = chkImprimirCajaChicaConsultas.Checked
        Next
    End Sub

    Private Sub chkAccesoContabilidadArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoContabilidadArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadArchivos.Rows
            row.Cells(3).Value = chkAccesoContabilidadArchivos.Checked
        Next
    End Sub

    Private Sub chkCrearContabilidadArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearContabilidadArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadArchivos.Rows
            row.Cells(4).Value = chkCrearContabilidadArchivos.Checked
        Next
    End Sub

    Private Sub chkModificarContabilidadArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarContabilidadArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadArchivos.Rows
            row.Cells(5).Value = chkModificarContabilidadArchivos.Checked
        Next
    End Sub

    Private Sub chkImprimirContabilidadArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirContabilidadArchivos.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadArchivos.Rows
            row.Cells(6).Value = chkImprimirContabilidadArchivos.Checked
        Next
    End Sub

    Private Sub chkAccesoContabilidadProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoContabilidadProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadProcesos.Rows
            row.Cells(3).Value = chkAccesoContabilidadProcesos.Checked
        Next
    End Sub

    Private Sub chkCrearContabilidadProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearContabilidadProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadProcesos.Rows
            row.Cells(4).Value = chkCrearContabilidadProcesos.Checked
        Next
    End Sub

    Private Sub chkModificarContabilidadProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarContabilidadProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadProcesos.Rows
            row.Cells(5).Value = chkModificarContabilidadProcesos.Checked
        Next
    End Sub

    Private Sub chkImprimirContabilidadProcesos_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirContabilidadProcesos.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadProcesos.Rows
            row.Cells(6).Value = chkImprimirContabilidadProcesos.Checked
        Next
    End Sub

    Private Sub chkAccesoContabilidadReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoContabilidadReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadReportes.Rows
            row.Cells(3).Value = chkAccesoContabilidadReportes.Checked
        Next
    End Sub

    Private Sub chkCrearContabilidadReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearContabilidadReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadReportes.Rows
            row.Cells(4).Value = chkCrearContabilidadReportes.Checked
        Next
    End Sub

    Private Sub chkModificarContabilidadReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarContabilidadReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadReportes.Rows
            row.Cells(5).Value = chkModificarContabilidadReportes.Checked
        Next
    End Sub

    Private Sub chkImprimirContabilidadReportes_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirContabilidadReportes.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadReportes.Rows
            row.Cells(6).Value = chkImprimirContabilidadReportes.Checked
        Next
    End Sub

    Private Sub chkAccesoContabilidadConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkAccesoContabilidadConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadConsultas.Rows
            row.Cells(3).Value = chkAccesoContabilidadConsultas.Checked
        Next
    End Sub

    Private Sub chkCrearContabilidadConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrearContabilidadConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadConsultas.Rows
            row.Cells(4).Value = chkCrearContabilidadConsultas.Checked
        Next
    End Sub

    Private Sub chkModificarContabilidadConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkModificarContabilidadConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadConsultas.Rows
            row.Cells(5).Value = chkModificarContabilidadConsultas.Checked
        Next
    End Sub

    Private Sub chkImprimirContabilidadConsultas_CheckedChanged(sender As Object, e As EventArgs) Handles chkImprimirContabilidadConsultas.CheckedChanged
        For Each row As DataGridViewRow In DgvContabilidadConsultas.Rows
            row.Cells(6).Value = chkImprimirContabilidadConsultas.Checked
        Next
    End Sub

    Private Sub ChkContabilidad_CheckedChanged(sender As Object, e As EventArgs) Handles ChkContabilidad.CheckedChanged
        chkAccesoContabilidadArchivos.Checked = ChkContabilidad.Checked
        chkCrearContabilidadArchivos.Checked = ChkContabilidad.Checked
        chkModificarContabilidadArchivos.Checked = ChkContabilidad.Checked
        chkImprimirContabilidadArchivos.Checked = ChkContabilidad.Checked
        chkAccesoContabilidadProcesos.Checked = ChkContabilidad.Checked
        chkCrearContabilidadProcesos.Checked = ChkContabilidad.Checked
        chkModificarContabilidadProcesos.Checked = ChkContabilidad.Checked
        chkImprimirContabilidadProcesos.Checked = ChkContabilidad.Checked
        chkAccesoContabilidadReportes.Checked = ChkContabilidad.Checked
        'chkCrearContabilidadReportes.Checked = ChkContabilidad.Checked
        'chkModificarContabilidadReportes.Checked =ChkContabilidad.Checked
        chkImprimirContabilidadReportes.Checked = ChkContabilidad.Checked
        chkAccesoContabilidadConsultas.Checked = ChkContabilidad.Checked
        'chkCrearContabilidadConsultas.Checked = ChkContabilidad.Checked
        chkModificarContabilidadConsultas.Checked = ChkContabilidad.Checked
        chkImprimirContabilidadConsultas.Checked = ChkContabilidad.Checked
    End Sub

    Private Sub AddDatagridviewHeaderClick()
        AddHandler DgvInventarioArchivos.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvInventarioProcesos.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvInventarioReportes.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvInventarioConsultas.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick

        AddHandler DgvFacturacionArchivo.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvFacturacionProceso.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvFacturacionReporte.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvFacturacionConsulta.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick

        AddHandler DgvCXCArchivo.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvCxCProceso.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvCxcReportes.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvCxcConsultas.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick

        AddHandler DgvCxpArchivo.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvCxPProceso.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvCxPReportes.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvCXPConsultas.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick

        AddHandler DgvNominaArchivo.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvNominaProceso.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvNominaReporte.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvNominaConsulta.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick

        AddHandler DgvBancoArchivo.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvBancoProceso.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvBancoReporte.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvBancoConsulta.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick

        AddHandler DgvSupervisionArchivo.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvSupervisionProceso.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvSupervisionReportes.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvSupervisionConsulta.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick

        AddHandler DgvCajaChicaArchivo.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvCajaChicaProcesos.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvCajaChicaReportes.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvCajaChicaConsultas.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick

        AddHandler DgvContabilidadArchivos.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvContabilidadProcesos.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvContabilidadReportes.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
        AddHandler DgvContabilidadConsultas.RowHeaderMouseClick, AddressOf ChangeToTrue_DataGridViewHeaderClick
    End Sub
    Private Sub AddDatagridviewHeaderDoubleClick()
        AddHandler DgvInventarioArchivos.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvInventarioProcesos.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvInventarioReportes.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvInventarioConsultas.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick

        AddHandler DgvFacturacionArchivo.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvFacturacionProceso.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvFacturacionReporte.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvFacturacionConsulta.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick

        AddHandler DgvCXCArchivo.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvCxCProceso.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvCxcReportes.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvCxcConsultas.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick

        AddHandler DgvCxpArchivo.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvCxPProceso.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvCxPReportes.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvCXPConsultas.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick

        AddHandler DgvNominaArchivo.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvNominaProceso.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvNominaReporte.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvNominaConsulta.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick

        AddHandler DgvBancoArchivo.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvBancoProceso.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvBancoReporte.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvBancoConsulta.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick

        AddHandler DgvSupervisionArchivo.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvSupervisionProceso.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvSupervisionReportes.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvSupervisionConsulta.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick

        AddHandler DgvCajaChicaArchivo.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvCajaChicaProcesos.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvCajaChicaReportes.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvCajaChicaConsultas.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick

        AddHandler DgvContabilidadArchivos.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvContabilidadProcesos.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvContabilidadReportes.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
        AddHandler DgvContabilidadConsultas.RowHeaderMouseDoubleClick, AddressOf ChangeToFalse_DataGridViewHeaderDoubleClick
    End Sub

    Private Sub ChangeToTrue_DataGridViewHeaderClick(sender As Object, e As EventArgs)

        If DirectCast(sender, DataGridView).Name.Contains("Archivo") Then
            DirectCast(sender, DataGridView).CurrentRow.Cells(3).Value = True
            DirectCast(sender, DataGridView).CurrentRow.Cells(4).Value = True
            DirectCast(sender, DataGridView).CurrentRow.Cells(5).Value = True
            DirectCast(sender, DataGridView).CurrentRow.Cells(6).Value = True

        ElseIf DirectCast(sender, DataGridView).Name.Contains("Proceso") Then
            DirectCast(sender, DataGridView).CurrentRow.Cells(3).Value = True
            DirectCast(sender, DataGridView).CurrentRow.Cells(4).Value = True
            DirectCast(sender, DataGridView).CurrentRow.Cells(5).Value = True
            DirectCast(sender, DataGridView).CurrentRow.Cells(6).Value = True

        ElseIf DirectCast(sender, DataGridView).Name.Contains("Reporte") Then
            DirectCast(sender, DataGridView).CurrentRow.Cells(3).Value = True
            DirectCast(sender, DataGridView).CurrentRow.Cells(6).Value = True

        ElseIf DirectCast(sender, DataGridView).Name.Contains("Consulta") Then
            DirectCast(sender, DataGridView).CurrentRow.Cells(3).Value = True
            DirectCast(sender, DataGridView).CurrentRow.Cells(5).Value = True
            DirectCast(sender, DataGridView).CurrentRow.Cells(6).Value = True
        End If

    End Sub

    Private Sub ChangeToFalse_DataGridViewHeaderDoubleClick(sender As Object, e As EventArgs)

        If DirectCast(sender, DataGridView).Name.Contains("Archivo") Then
            DirectCast(sender, DataGridView).CurrentRow.Cells(3).Value = False
            DirectCast(sender, DataGridView).CurrentRow.Cells(4).Value = False
            DirectCast(sender, DataGridView).CurrentRow.Cells(5).Value = False
            DirectCast(sender, DataGridView).CurrentRow.Cells(6).Value = False

        ElseIf DirectCast(sender, DataGridView).Name.Contains("Proceso") Then
            DirectCast(sender, DataGridView).CurrentRow.Cells(3).Value = False
            DirectCast(sender, DataGridView).CurrentRow.Cells(4).Value = False
            DirectCast(sender, DataGridView).CurrentRow.Cells(5).Value = False
            DirectCast(sender, DataGridView).CurrentRow.Cells(6).Value = False

        ElseIf DirectCast(sender, DataGridView).Name.Contains("Reporte") Then
            DirectCast(sender, DataGridView).CurrentRow.Cells(3).Value = False
            DirectCast(sender, DataGridView).CurrentRow.Cells(6).Value = False

        ElseIf DirectCast(sender, DataGridView).Name.Contains("Consulta") Then
            DirectCast(sender, DataGridView).CurrentRow.Cells(3).Value = False
            DirectCast(sender, DataGridView).CurrentRow.Cells(5).Value = False
            DirectCast(sender, DataGridView).CurrentRow.Cells(6).Value = False
        End If

    End Sub

    Private Sub OpenPermisosOtogradoswithClick()
        AddHandler DgvInventarioArchivos.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvInventarioProcesos.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvInventarioReportes.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvInventarioConsultas.CellContentClick, AddressOf AbrirPermisosOtorgados

        AddHandler DgvFacturacionArchivo.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvFacturacionProceso.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvFacturacionReporte.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvFacturacionConsulta.CellContentClick, AddressOf AbrirPermisosOtorgados

        AddHandler DgvCXCArchivo.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvCxCProceso.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvCxcReportes.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvCxcConsultas.CellContentClick, AddressOf AbrirPermisosOtorgados

        AddHandler DgvCxpArchivo.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvCxPProceso.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvCxPReportes.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvCXPConsultas.CellContentClick, AddressOf AbrirPermisosOtorgados

        AddHandler DgvNominaArchivo.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvNominaProceso.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvNominaReporte.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvNominaConsulta.CellContentClick, AddressOf AbrirPermisosOtorgados

        AddHandler DgvBancoArchivo.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvBancoProceso.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvBancoReporte.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvBancoConsulta.CellContentClick, AddressOf AbrirPermisosOtorgados

        AddHandler DgvSupervisionArchivo.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvSupervisionProceso.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvSupervisionReportes.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvSupervisionConsulta.CellContentClick, AddressOf AbrirPermisosOtorgados

        AddHandler DgvCajaChicaArchivo.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvCajaChicaProcesos.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvCajaChicaReportes.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvCajaChicaConsultas.CellContentClick, AddressOf AbrirPermisosOtorgados

        AddHandler DgvContabilidadArchivos.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvContabilidadProcesos.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvContabilidadReportes.CellContentClick, AddressOf AbrirPermisosOtorgados
        AddHandler DgvContabilidadConsultas.CellContentClick, AddressOf AbrirPermisosOtorgados

        AddHandler DgvUtilidades.CellContentClick, AddressOf AbrirPermisosOtorgados
    End Sub

    Private Sub AbrirPermisosOtorgados(sender As Object, e As DataGridViewCellEventArgs)
        Try
            Dim EmployeePhoto As Image
            If e.ColumnIndex = 2 Then
                If DirectCast(sender, DataGridView).Rows.Count > 0 Then
                    If frm_bitacora_usuarios.Visible = True Then
                        frm_bitacora_usuarios.Close()
                    End If

                    frm_bitacora_usuarios.Show(Me)
                    frm_bitacora_usuarios.DgvPermisosOtorgados.Rows.Clear()
                    frm_bitacora_usuarios.TabControl1.SelectedIndex = 2


                    ConMixta.Open()
                    Dim Consulta As New MySqlCommand("SELECT idpermisoempleado,empleados.nombre,acceso,crear,modificar,imprimir,permisos.idpermisos,permisos.descripcion,formulariofondo,modulos.modulo,procesosmodulo.proceso,rutafoto FROM" & SysName.Text & "permisosempleados inner join" & SysName.Text & "permisos on permisosempleados.idpermiso=permisos.idpermisos inner join" & SysName.Text & "modulos on permisos.idmodulo=modulos.idmodulo  inner join" & SysName.Text & "procesosmodulo on permisos.idproceso=procesosmodulo.idprocesosmodulo inner join" & SysName.Text & "empleados on permisosempleados.idempleado=empleados.idempleado where permisos.idpermisos='" + DirectCast(sender, DataGridView).CurrentRow.Cells(1).Value.ToString + "' AND Empleados.Nulo=0", ConMixta)
                    Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

                    While LectorDocumentos.Read

                        If TypeConnection.Text = 1 Then
                            If LectorDocumentos.GetValue(11) = "" Then
                                EmployeePhoto = My.Resources.No_Image
                            Else
                                Dim ExistFile As Boolean = System.IO.File.Exists(LectorDocumentos.GetValue(11))
                                If ExistFile = True Then
                                    Dim wFile As System.IO.FileStream
                                    wFile = New FileStream(LectorDocumentos.GetValue(11), FileMode.Open, FileAccess.Read)
                                    EmployeePhoto = System.Drawing.Image.FromStream(wFile)
                                    wFile.Close()
                                Else
                                    EmployeePhoto = My.Resources.No_Image
                                End If
                            End If
                        Else
                            EmployeePhoto = My.Resources.No_Image
                        End If

                        frm_bitacora_usuarios.DgvPermisosOtorgados.Rows.Add(LectorDocumentos.GetValue(0), EmployeePhoto, LectorDocumentos.GetValue(1), Convert.ToBoolean(LectorDocumentos.GetValue(2)), Convert.ToBoolean(LectorDocumentos.GetValue(3)), Convert.ToBoolean(LectorDocumentos.GetValue(4)), Convert.ToBoolean(LectorDocumentos.GetValue(5)))

                        frm_bitacora_usuarios.lblPermiso.Text = LectorDocumentos.GetValue(7)
                        frm_bitacora_usuarios.lblModulo.Text = LectorDocumentos.GetValue(9)
                        frm_bitacora_usuarios.lblProceso.Text = LectorDocumentos.GetValue(10)
                    End While

                    LectorDocumentos.Close()
                    ConMixta.Close()

                    frm_bitacora_usuarios.cbxPermiso.Text = frm_bitacora_usuarios.lblModulo.Text & "->" & frm_bitacora_usuarios.lblProceso.Text & "->" & frm_bitacora_usuarios.lblPermiso.Text

                    'Cargar tipos de permisos
                    frm_bitacora_usuarios.DgvPermisosOtorgados.Columns(3).ReadOnly = DirectCast(sender, DataGridView).Columns(3).ReadOnly
                    frm_bitacora_usuarios.DgvPermisosOtorgados.Columns(3).DefaultCellStyle.BackColor = DirectCast(sender, DataGridView).Columns(3).DefaultCellStyle.BackColor
                    frm_bitacora_usuarios.chkAcceso.Enabled = Not DirectCast(sender, DataGridView).Columns(3).ReadOnly

                    frm_bitacora_usuarios.DgvPermisosOtorgados.Columns(4).ReadOnly = DirectCast(sender, DataGridView).Columns(4).ReadOnly
                    frm_bitacora_usuarios.DgvPermisosOtorgados.Columns(4).DefaultCellStyle.BackColor = DirectCast(sender, DataGridView).Columns(4).DefaultCellStyle.BackColor
                    frm_bitacora_usuarios.chkCrear.Enabled = Not DirectCast(sender, DataGridView).Columns(4).ReadOnly

                    frm_bitacora_usuarios.DgvPermisosOtorgados.Columns(5).ReadOnly = DirectCast(sender, DataGridView).Columns(5).ReadOnly
                    frm_bitacora_usuarios.DgvPermisosOtorgados.Columns(5).DefaultCellStyle.BackColor = DirectCast(sender, DataGridView).Columns(5).DefaultCellStyle.BackColor
                    frm_bitacora_usuarios.chkModificar.Enabled = Not DirectCast(sender, DataGridView).Columns(5).ReadOnly

                    frm_bitacora_usuarios.DgvPermisosOtorgados.Columns(6).ReadOnly = DirectCast(sender, DataGridView).Columns(6).ReadOnly
                    frm_bitacora_usuarios.DgvPermisosOtorgados.Columns(6).DefaultCellStyle.BackColor = DirectCast(sender, DataGridView).Columns(6).DefaultCellStyle.BackColor
                    frm_bitacora_usuarios.chkImprimir.Enabled = Not DirectCast(sender, DataGridView).Columns(6).ReadOnly


                    frm_bitacora_usuarios.DgvPermisosOtorgados.ClearSelection()

                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub frm_permisos_usuarios_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            Me.Close()
        End If
    End Sub

    Private Sub chkVisualizarTodoPrecio_CheckedChanged(sender As Object, e As EventArgs) Handles chkVisualizarTodoPrecio.CheckedChanged
        Dim ImgFile As Image

        Con.Open()

        If chkVisualizarTodoPrecio.Checked = True Then
            'Buscando precios autorizados
            DgvPrecios.Rows.Clear()
            Dim Consulta As New MySqlCommand("SELECT IDPreciosEmpleados,Empleados.RutaFoto,Empleados.Nombre,'Precios autorizados por nivel',PrecioA,PrecioB,PrecioC,PrecioD,PrecioBlackFriday FROM preciosempleados inner join" & SysName.Text & "empleados on preciosempleados.idempleado=empleados.idempleado where Empleados.Nulo=0", Con)
            Dim LectorPrecios As MySqlDataReader = Consulta.ExecuteReader

            While LectorPrecios.Read
                If LectorPrecios.GetValue(1) = "" Then
                    ImgFile = ResizeImage(My.Resources.No_Image, 50)
                Else
                    If System.IO.File.Exists(LectorPrecios.GetValue(1)) Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(LectorPrecios.GetValue(1), FileMode.Open, FileAccess.Read)
                        ImgFile = ResizeImage(System.Drawing.Image.FromStream(wFile), 50)
                        wFile.Close()
                    Else
                        ImgFile = ResizeImage(My.Resources.No_Image, 50)
                    End If
                End If

                DgvPrecios.Rows.Add(LectorPrecios.GetValue(0), ImgFile, LectorPrecios.GetValue(2), "Niveles de precios autorizados", CBool(LectorPrecios.GetValue(4)), CBool(LectorPrecios.GetValue(5)), CBool(LectorPrecios.GetValue(6)), CBool(LectorPrecios.GetValue(7)), CBool(LectorPrecios.GetValue(8)))
            End While

            LectorPrecios.Close()

        Else
            'Buscando precios autorizados
            DgvPrecios.Rows.Clear()

            cmd = New MySqlCommand("SELECT count(IDPreciosEmpleados) FROM preciosempleados where IDEmpleado='" + txtIDUsuario.Text + "'", Con)
            Dim PreciosDados As Integer = Convert.ToString(cmd.ExecuteScalar)
            If PreciosDados = 1 Then
                Dim Consulta As New MySqlCommand("SELECT IDPreciosEmpleados,Empleados.RutaFoto,Empleados.Nombre,'Precios autorizados por nivel',PrecioA,PrecioB,PrecioC,PrecioD,PrecioBlackFriday FROM preciosempleados inner join" & SysName.Text & "empleados on preciosempleados.idempleado=empleados.idempleado where preciosempleados.IDEmpleado='" + txtIDUsuario.Text + "'", Con)
                Dim LectorPrecios As MySqlDataReader = Consulta.ExecuteReader

                Dim wFile As System.IO.FileStream

                While LectorPrecios.Read
                    If LectorPrecios.GetValue(1) = "" Then
                        ImgFile = ResizeImage(My.Resources.No_Image, 50)
                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists(LectorPrecios.GetValue(1))
                        If ExistFile = True Then
                            wFile = New FileStream(LectorPrecios.GetValue(1), FileMode.Open, FileAccess.Read)
                            ImgFile = ResizeImage(System.Drawing.Image.FromStream(wFile), 50)
                            wFile.Close()
                        Else
                            ImgFile = ResizeImage(My.Resources.No_Image, 50)
                        End If
                    End If

                    DgvPrecios.Rows.Add(LectorPrecios.GetValue(0), ImgFile, LectorPrecios.GetValue(2), "Niveles de precios autorizados", CBool(LectorPrecios.GetValue(4)), CBool(LectorPrecios.GetValue(5)), CBool(LectorPrecios.GetValue(6)), CBool(LectorPrecios.GetValue(7)), CBool(LectorPrecios.GetValue(8)))
                End While

                LectorPrecios.Close()

            ElseIf PreciosDados = 0 Then
                DgvPrecios.Rows.Add("", Nothing, txtUsuario.Text, "Niveles de precios autorizados", False, False, False, False, False)
            End If
        End If

        Con.Close()

    End Sub


End Class