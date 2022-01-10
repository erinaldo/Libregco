Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.Shared

Public Class frm_ajustes_tecnicos
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim HabilitarCambio As String
    Dim lblColorBarraProgreso, DefaultCobrador As New Label
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal WParam As Integer, ByVal Iparam As Integer) As Integer
    Dim FormulaActiva As Integer = 0
    Dim ObjRpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim TablaEmpleados As DataTable
    Private Sub frm_ajustes_tecnicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarLibregco()
        'Me.WindowState = CheckWindowState()
        ActualizarTodo()
        CargarConfiguraciones()
        Control.CheckForIllegalCrossThreadCalls = False

        TablaEmpleados = New DataTable("Empleados")
        TablaEmpleados.Columns.Add("IDEmpleado", System.Type.GetType("System.String"))
        TablaEmpleados.Columns.Add("Nombre", System.Type.GetType("System.String"))
        TablaEmpleados.Columns.Add("Foto", System.Type.GetType("System.Object"))
        TablaEmpleados.Columns.Add("RutaFoto", System.Type.GetType("System.String"))
        TablaEmpleados.Columns.Add("Administrativo", System.Type.GetType("System.String"))
        GridControl1.DataSource = TablaEmpleados
        FillEmpleados
    End Sub

    Private Sub AdvBandedGridView1_CellValueChanged(sender As Object, e As XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AdvBandedGridView1.CellValueChanged
        Try
            If e.Column.FieldName = "Administrativo" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("UPDATE Empleados SET EsAdministrador='" + AdvBandedGridView1.GetDataRow(e.RowHandle)(4).ToString + "' WHERE IDEmpleado='" + AdvBandedGridView1.GetDataRow(e.RowHandle)(0).ToString + "'", ConLibregco)
                cmd.ExecuteNonQuery()
                ConLibregco.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

    Sub FillEmpleados()
        'Try
        TablaEmpleados.Clear()

        Using ConMixta As MySqlConnection = New MySqlConnection(CnString)
            Using myCommand As MySqlCommand = New MySqlCommand("SELECT IDEmpleado,Nombre,RutaFoto,Convert(EsAdministrador,CHAR) as Administrativo FROM libregco.empleados", ConMixta)
                ConMixta.Open()
                Using myReader As MySqlDataReader = myCommand.ExecuteReader
                    TablaEmpleados.Load(myReader, LoadOption.Upsert)
                    ConMixta.Close()
                    ConMixta.Dispose()
                End Using
            End Using
        End Using
        TablaEmpleados.EndLoadData()

        For Each dt As DataRow In TablaEmpleados.Rows
            Dim wFile As System.IO.FileStream
            Dim ImgFile As Image

            If dt.Item("RutaFoto") = "" Then
                ImgFile = ResizeImage(My.Resources.No_Image, 64)
            Else
                If System.IO.File.Exists(dt.Item("RutaFoto")) Then
                    wFile = New FileStream(dt.Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                    ImgFile = ResizeImage(System.Drawing.Image.FromStream(wFile), 64)
                    wFile.Close()
                Else
                    ImgFile = ResizeImage(My.Resources.No_Image, 64)
                End If
            End If

            dt.Item("Foto") = ImgFile

        Next

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString)
        'End Try
    End Sub

    Private Sub ActualizarTodo()
        ControlSuperClave = 1
        HabilitarCambio = 0
    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CargarConfiguraciones()
        'Try

        Con.Open()
        ConUtilitarios.Open()
        ConMixta.Open()

        'Nombre del Servidor
        cmd = New MySqlCommand("Select Value from Libregco_Utilitarios.Ajustes where IDAjuste=1", ConUtilitarios)
        txtServidor.Text = Convert.ToString(cmd.ExecuteScalar())

        'Version del Sistema
        cmd = New MySqlCommand("Select concat(VersionMayor,'.',VersionMenor,'.',VersionCompilacion,'.',VersionVersion) from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
        txtVersion.Text = Convert.ToString(cmd.ExecuteScalar())

        'Año del Sistema
        cmd = New MySqlCommand("Select FechaLanzamiento from libregco_utilitarios.version_sys where IDBuild=(Select Max(IDBuild) from version_sys)", ConUtilitarios)
        txtAñoSist.Text = Convert.ToString(cmd.ExecuteScalar())

        ''Logo del Sistema
        'cmd = New MySqlCommand("Select LocacionLogo from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
        'Dim SystemLogoPath As String = Convert.ToString(cmd.ExecuteScalar())

        'If TypeConnection.Text = 1 Then
        '    If SystemLogoPath = "" Then
        '        PicLogo.Image = My.Resources.LibregcoCircle_x256
        '    Else
        '        Dim ExistFile As Boolean = System.IO.File.Exists("\\" & PathServidor.Text & SystemLogoPath)
        '        If ExistFile = True Then
        '            PicLogo.Image = Image.FromFile("\\" & PathServidor.Text & SystemLogoPath)
        '        End If
        '    End If
        'Else
        '    PicLogo.Image = My.Resources.LibregcoCircle_x256
        'End If

        'Cargar Mostrar fondos de pantalla en inicio
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=2", Con)
        chkVerificarInternet.Checked = Convert.ToBoolean(cmd.ExecuteScalar())

        'Ruta Mysqldump.exe
        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=29", Con)
        txtRutaMysqldump.Text = Convert.ToString(cmd.ExecuteScalar())

        'Nombre Database
        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=33", Con)
        txtDatabase.Text = Convert.ToString(cmd.ExecuteScalar())

        'Host Database
        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=30", Con)
        txtHostDatabase.Text = Convert.ToString(cmd.ExecuteScalar())

        'User Database
        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=31", Con)
        txtUserDatabase.Text = Convert.ToString(cmd.ExecuteScalar())

        'Password Database
        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=32", Con)
        txtPasswordDatabase.Text = Convert.ToString(cmd.ExecuteScalar())

        'Ultima limpieza de backups
        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=34", Con)
        txtUltimaLimpieza.Text = Convert.ToString(cmd.ExecuteScalar())

        'Dias Eliminado
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=35", Con)
        txtDiasEliminado.Text = Convert.ToString(cmd.ExecuteScalar())

        'Admin User
        cmd = New MySqlCommand("Select Value from Ajustes where IDAjuste=2", ConUtilitarios)
        txtAdminUser.Text = Convert.ToString(cmd.ExecuteScalar())

        'Admin Password
        cmd = New MySqlCommand("Select Value from Ajustes where IDAjuste=3", ConUtilitarios)
        txtPasswordAdmin.Text = Convert.ToString(cmd.ExecuteScalar())
        txtConfirmPass.Text = Convert.ToString(cmd.ExecuteScalar())

        'Cargar Opcion de Iconos Ocultos en Barra de Inicio
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=38", Con)
        chkHideIcons.Checked = Convert.ToBoolean(cmd.ExecuteScalar())

        'Cargar Bordes formulario inicio
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=48", Con)
        chkfrminicioBordes.Checked = Convert.ToBoolean(cmd.ExecuteScalar())


        'Cargar Mostrar fondos de pantalla en login
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=49", Con)
        chkWallpapersLogin.Checked = Convert.ToBoolean(cmd.ExecuteScalar())

        'Cargar Mostrar fondos de pantalla en inicio
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=67", Con)
        chkWallpapersStart.Checked = Convert.ToBoolean(cmd.ExecuteScalar())

        'Permitir acceder al administrador
        cmd = New MySqlCommand("Select Value from libregco_utilitarios.Ajustes where IDAjuste=4", ConUtilitarios)
        chkHabLoginAdmin.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Cargar color primario
        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=64", Con)
        ColorPrimario.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        'Cargar color secundario
        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=65", Con)
        ColorSecundario.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        'Cargar color terciario
        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=66", Con)
        ColorTerciario.BackColor = Color.FromArgb(Convert.ToString(cmd.ExecuteScalar()))

        'Animacion de monedas en login
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=72", Con)
        chkAnimacionMonLogin.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Permitir el cambio de estructura del tipo de NCF
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=76", Con)
        ChkPerCambiarEstructuraNCF.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=74", Con)
        lblColorBarraProgreso.Text = Convert.ToInt16(cmd.ExecuteScalar())

        If lblColorBarraProgreso.Text = 1 Then
            rdbVerde.Checked = True
        ElseIf lblColorBarraProgreso.Text = 2 Then
            rdbRojo.Checked = True
        ElseIf lblColorBarraProgreso.Text = 3 Then
            rdbAmarillo.Checked = True
        End If

        'Habilitar modulo de inventario
        cmd = New MySqlCommand("Select Habilitar from modulos Where IDModulo=1", Con)
        chkModInventario.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Habilitar modulo de facturación
        cmd = New MySqlCommand("Select Habilitar from modulos Where IDModulo=2", Con)
        chkModFacturacion.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Habilitar modulo de cxc
        cmd = New MySqlCommand("Select Habilitar from modulos Where IDModulo=3", Con)
        chkModCXC.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Habilitar modulo de cxp
        cmd = New MySqlCommand("Select Habilitar from modulos Where IDModulo=4", Con)
        chkModCXP.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Habilitar modulo de nómina
        cmd = New MySqlCommand("Select Habilitar from modulos Where IDModulo=5", Con)
        chkModNomina.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Habilitar modulo de bancos
        cmd = New MySqlCommand("Select Habilitar from modulos Where IDModulo=6", Con)
        chkModBancos.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Habilitar modulo de supervisión
        cmd = New MySqlCommand("Select Habilitar from modulos Where IDModulo=7", Con)
        chkModSupervision.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Habilitar modulo de caja chica
        cmd = New MySqlCommand("Select Habilitar from modulos Where IDModulo=8", Con)
        chkModCajaChica.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))


        'Habilitar modulo de contabilidad
        cmd = New MySqlCommand("Select Habilitar from modulos Where IDModulo=9", Con)
        chkModContabilidad.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Habilitar modulo de servicios
        cmd = New MySqlCommand("Select Habilitar from modulos Where IDModulo=10", Con)
        chkModServicios.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Habilitar modulo de estadísticas
        cmd = New MySqlCommand("Select Habilitar from modulos Where IDModulo=11", Con)
        chkModEstadisticas.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Habilitar modulo de ayuda
        cmd = New MySqlCommand("Select Habilitar from modulos Where IDModulo=12", Con)
        chkModAyuda.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Mostrar barra de acceso rapido
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=99", Con)
        chkMostrarBarraAcceso.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))
        If chkMostrarBarraAcceso.CheckState = CheckState.Unchecked Then
            txtCantAccesosRapidos.Enabled = False
        Else
            txtCantAccesosRapidos.Enabled = True
        End If

        'Habilitar formulario de acceso rapido de clientes
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=102", Con)
        chkAccesoRapidoClientes.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Forzar actualizaciones
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=119", Con)
        chkForzarActualizacion.Checked = Convert.ToBoolean(Convert.ToInt16(cmd.ExecuteScalar()))

        'Cantidad de elementos a mostrar en la barra de accesos rapidos
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=100", Con)
        txtCantAccesosRapidos.Text = Convert.ToInt16(cmd.ExecuteScalar())

        'Cargar tipos de documentos
        DgvDocumentos.Rows.Clear()
        Dim CmdDocumentos As New MySqlCommand("SELECT IDTipoDocumento,Documento,Letra,UltimaSecuencia,Filler,CantCharacter FROM tipodocumento", Con)
        Dim LectorDocs As MySqlDataReader = CmdDocumentos.ExecuteReader

        While LectorDocs.Read
            DgvDocumentos.Rows.Add(LectorDocs.GetValue(0), LectorDocs.GetValue(1), LectorDocs.GetValue(2), LectorDocs.GetValue(3), LectorDocs.GetValue(4), LectorDocs.GetValue(5))
        End While
        LectorDocs.Close()
        MostrarEjemplosDocumentos()
        HabilitarCambio = 1
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''Cargar Errores
        Dim Img As Image
        Dim wFile As System.IO.FileStream

        DgvErrores.Rows.Clear()
        Dim CmdErrores As New MySqlCommand("SELECT Imagen,Fecha,Formulario,Metodo,Descripcion,MetodoBase,Concat(VersionMayor,'.',VersionMenor,'.',VersionCompilacion,'.',VersionVersion),IDError FROM" & SysName.Text & "errores INNER JOIN Libregco_Utilitarios.Version_sys on Errores.IDVersion=Version_sys.IDBuild", ConMixta)
        Dim LectorErrores As MySqlDataReader = CmdErrores.ExecuteReader

        While LectorErrores.Read
            Dim ExistFile As Boolean = System.IO.File.Exists(LectorErrores.GetValue(0))
            If ExistFile = True Then
                wFile = New FileStream(LectorErrores.GetValue(0), FileMode.Open, FileAccess.Read)
                Img = System.Drawing.Image.FromStream(wFile)
                wFile.Close()
            Else
                Img = My.Resources.No_Image
            End If

            DgvErrores.Rows.Add(Img, LectorErrores.GetValue(1), LectorErrores.GetValue(2), LectorErrores.GetValue(3), LectorErrores.GetValue(4), LectorErrores.GetValue(5), LectorErrores.GetValue(6), LectorErrores.GetValue(0), LectorErrores.GetValue(7))

        End While
        LectorErrores.Close()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If TypeConnection.Text = 1 Then
            'Cargar iconos
            Dim TruthPath As String
            Dim ExistFile As Boolean

            DgvIconos.Rows.Clear()
            Dim CmdIconos As New MySqlCommand("SELECT Permisos.IDModulo,Modulos.Modulo,Permisos.IDProceso,ProcesosModulo.Proceso,IDPermisos,Descripcion,FormularioFondo,Orden FROM permisos INNER JOIN Modulos on Permisos.IDModulo=Modulos.IDModulo INNER JOIN ProcesosModulo on Permisos.IDProceso=ProcesosModulo.IDProcesosModulo Where MostrarIcono=1 ORDER BY IDModulo ASC, IDProceso ASC, Orden ASC", Con)
            Dim LectorIconos As MySqlDataReader = CmdIconos.ExecuteReader

            While LectorIconos.Read
                ExistFile = System.IO.File.Exists(LectorIconos.GetValue(6))

                If ExistFile = True Then
                    TruthPath = LectorIconos.GetValue(6)
                Else
                    Dim ExistFileOne As Boolean = System.IO.File.Exists("\\" & PathServidor.Text & LectorIconos.GetValue(6))
                    If ExistFileOne = True Then
                        TruthPath = "\\" & PathServidor.Text & LectorIconos.GetValue(6)
                    Else
                        TruthPath = Path.GetFullPath(My.Resources.ResourceManager.GetObject("Searh x32"))
                    End If
                End If

                DgvIconos.Rows.Add(LectorIconos.GetValue(0), LectorIconos.GetValue(1), LectorIconos.GetValue(2), LectorIconos.GetValue(3), LectorIconos.GetValue(4), LectorIconos.GetValue(5), Image.FromFile(TruthPath), "", LectorIconos.GetValue(6), LectorIconos.GetValue(7))
            End While
            LectorIconos.Close()
        End If

        'Cargar reportes
        DgvReportes.Rows.Clear()
        Dim TmpImage As Image
        Dim wTmpImage As System.IO.FileStream

        Dim CmdReportes As New MySqlCommand("SELECT IDReportes,Descripcion,Path,NoOrden,Visualizacion FROM" & SysName.Text & "reportes ORDER BY MENUSTRING ASC, NoOrden asc", Con)
        Dim LectorReportes As MySqlDataReader = CmdReportes.ExecuteReader

        While LectorReportes.Read
            If TypeConnection.Text = 1 Then
                If LectorReportes.GetValue(4).ToString <> "" Then
                    If System.IO.File.Exists(LectorReportes.GetValue(4)) = True Then
                        wTmpImage = New FileStream(LectorReportes.GetValue(4), FileMode.Open, FileAccess.Read)
                        TmpImage = System.Drawing.Image.FromStream(wTmpImage)

                    Else
                        TmpImage = My.Resources.No_Image
                    End If
                End If

            Else
                TmpImage = My.Resources.No_Image
            End If

            DgvReportes.Rows.Add(TmpImage, LectorReportes.GetValue(0), LectorReportes.GetValue(1), "\\" & PathServidor.Text & LectorReportes.GetValue(2), LectorReportes.GetValue(3), "")

        End While
        LectorReportes.Close()

        'Cargar Directorios
        DgvDirectorios.Rows.Clear()
        Dim CmdDirectorios As New MySqlCommand("SELECT idDirectoryBackup,Directory FROM DirectoryBackup ORDER BY idDirectoryBackup ASC", ConUtilitarios)
        Dim LectorDirectories As MySqlDataReader = CmdDirectorios.ExecuteReader

        While LectorDirectories.Read
            DgvDirectorios.Rows.Add(LectorDirectories.GetValue(0), LectorDirectories.GetValue(1))
        End While
        LectorDirectories.Close()

        'Cargar facturas
        Dim AdcDate As String
        DgvFacturas.Rows.Clear()
        Dim CmdFacturas As New MySqlCommand("SELECT IDFacturaDatos,SecondID,Fecha,TotalNeto,Balance,CantidadPagos,MontoPagos,PagoAdicional,FechaAdicional,FechaVencimiento FROM" & SysName.Text & "facturadatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where FacturaDatos.Nulo=0 and FacturaDatos.Balance>0 and Condicion.Dias>0 ORDER BY IDFacturaDatos ASC", ConMixta)
        Dim LectorFacturas As MySqlDataReader = CmdFacturas.ExecuteReader

        While LectorFacturas.Read
            If IsDate(LectorFacturas.GetValue(8)) Then
                AdcDate = CDate(LectorFacturas.GetValue(8)).ToString("yyyy-MM-dd")
            Else
                AdcDate = ""
            End If

            DgvFacturas.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), CDate(LectorFacturas.GetValue(2)).ToString("yyyy-MM-dd"), CDbl(LectorFacturas.GetValue(3)).ToString("C"), CDbl(LectorFacturas.GetValue(4)).ToString("C"), LectorFacturas.GetValue(5), CDbl(LectorFacturas.GetValue(6)).ToString("C"), CDbl(LectorFacturas.GetValue(7)).ToString("C"), AdcDate, CDate(LectorFacturas.GetValue(9)))

        End While
        LectorFacturas.Close()

        'Cobrador Predeterminado
        cmd = New MySqlCommand("SELECT Value2Int FROM configuracion where IDConfiguracion=25", Con)
        DefaultCobrador.Text = Convert.ToString(cmd.ExecuteScalar())

        'Cargar Tablas
        DgvTables.Rows.Clear()
        Dim CmdTablas As New MySqlCommand("SELECT TableType,NameSchema,NameTable,NameColumn,Rows,Collation,IDTypesTables,Controlar from TypesTables ORDER BY TableType, NameTable", ConUtilitarios)
        Dim LectorTablas As MySqlDataReader = CmdTablas.ExecuteReader

        While LectorTablas.Read
            DgvTables.Rows.Add(LectorTablas.GetValue(0), LectorTablas.GetValue(1), LectorTablas.GetValue(2), LectorTablas.GetValue(3), LectorTablas.GetValue(4), LectorTablas.GetValue(5), LectorTablas.GetValue(6), CBool(LectorTablas.GetValue(7)))
        End While
        LectorTablas.Close()


        Con.Close()
        ConUtilitarios.Close()
        ConMixta.Close()

        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & cmd.CommandText.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        'End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
            Con.Close()
        End Try

    End Sub

    Private Sub btnActualizarDGII_Click(sender As Object, e As EventArgs) Handles btnActualizarDGII.Click

        Timer1.Enabled = True
        Cursor.Current = Cursors.WaitCursor

        Try
            ConUtilitarios.Open()
            ProgressBar1.PerformStep()
            cmd = New MySqlCommand("LOAD DATA LOCAL INFILE '" + Replace(txtPath.Text, "\", "\\") + "' INTO TABLE Libregco_Utilitarios.Rncdgii FIELDS TERMINATED BY '|' ENCLOSED BY '' LINES TERMINATED BY '\n'", ConUtilitarios)
            cmd.ExecuteNonQuery()
            ConUtilitarios.Close()

            MessageBox.Show("Importación del archivo " & txtPath.Text & " ha sido exitosa.", "Importación Satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Cursor.Current = Cursors.Default

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        Finally
            ProgressBar1.Value = 100
            Timer1.Enabled = False
        End Try
    End Sub


    Private Sub btOpenDialog_Click(sender As Object, e As EventArgs) Handles btOpenDialog.Click
        Try
            Dim OfDialog As New OpenFileDialog

            OfDialog.RestoreDirectory = True
            OfDialog.Title = ("Seleccione el archivo de Texto")
            OfDialog.Filter = "Archivo de texto (*.txt;*.csv)|*.txt;*.csv"
            OfDialog.Multiselect = False

            If OfDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtPath.Text = OfDialog.FileName
            End If

            If txtPath.Text = "" Then
                btnActualizarDGII.Enabled = False
            Else
                btnActualizarDGII.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
        Else
            ProgressBar1.Value = ProgressBar1.Value + 5
        End If

    End Sub

    Private Sub btnTruncate_Click(sender As Object, e As EventArgs) Handles btnTruncate.Click
        Try
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea vaciar la tabla de la DGII?", "Remover Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                Cursor.Current = Cursors.WaitCursor
                ConUtilitarios.Open()
                cmd = New MySqlCommand("TRUNCATE TABLE Libregco_Utilitarios.rncdgii", ConUtilitarios)
                cmd.ExecuteNonQuery()
                cmd = New MySqlCommand("Select count(RNC) from Libregco_Utilitarios.Rncdgii", ConUtilitarios)
                GboxDGII.Text = "Tabla DGII " & "----" & " Registros encontrados: " & Convert.ToString(cmd.ExecuteScalar())
                ConUtilitarios.Close()

                MessageBox.Show("La eliminación de los registros ha sido exitosa.", "Eliminado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Cursor.Current = Cursors.Default
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub


    Private Sub btnCambiarServidor_Click(sender As Object, e As EventArgs) Handles btnCambiarServidor.Click
        Try
            frm_superclave.IDAccion.Text = 4
            frm_superclave.ShowDialog(Me)

            If ControlSuperClave = 0 Then
                Dim Mensaje, Titulo, DefaultValue As String
                Dim MyValue As Object

                Mensaje = "Nombre del Servidor Actual: " & txtServidor.Text & vbNewLine & "Ingrese o modifique el nombre del servidor." & vbNewLine & "Coloque su nombre de dominio integramente." & vbNewLine & "No coloque el signo ""\\"" representativo de los dominios en red."
                Titulo = "Dominio del Servidor"
                DefaultValue = txtServidor.Text

                MyValue = InputBox(Mensaje, Titulo, DefaultValue)

                If MyValue Is "" Then
                    MyValue = DefaultValue
                Else
                    txtServidor.Text = MyValue
                End If

            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnRutaMysqldump_Click(sender As Object, e As EventArgs) Handles btnRutaMysqldump.Click
        Try
            Dim Ofdfile As New OpenFileDialog
            Ofdfile.InitialDirectory = "C:\Program Files\MySQL\MySQL Server 5.6\bin"
            Ofdfile.Title = ("Localización de Mysqldump")
            Ofdfile.Filter = "mysqldump(*mysqldump.exe)|*mysqldump.exe"

            If Ofdfile.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtRutaMysqldump.Text = Ofdfile.FileName
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en los ajustes?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                Con.Open()
                ConUtilitarios.Open()

                If txtAdminUser.Text <> "" Then
                    If txtPasswordAdmin.Text = "" Then
                        MessageBox.Show("Escriba la contraseña de administrador para acceder directamente al sistema.", "Escribir la contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Con.Close()
                        ConUtilitarios.Close()
                        Exit Sub
                    ElseIf txtPasswordAdmin.Text <> "" And txtConfirmPass.Text <> txtPasswordAdmin.Text Then
                        MessageBox.Show("Las contraseñas no coinciden. Por favor vuelva a intentarlo.", "No coinciden las contraseñas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        txtConfirmPass.Focus()
                        Con.Close()
                        ConUtilitarios.Close()
                        Exit Sub
                    Else
                        If txtAdminUser.Text = "" Then
                            txtAdminUser.Clear()
                            txtPasswordAdmin.Clear()
                            txtConfirmPass.Clear()
                        End If
                    End If
                Else
                    txtPasswordAdmin.Clear()
                    txtConfirmPass.Clear()
                End If

                ' Nombre del Servidor A UTILIZAR
                sqlQ = "UPDATE Libregco_Utilitarios.Ajustes SET Value='" + txtServidor.Text + "' WHERE IDAjuste=1"
                cmd = New MySqlCommand(sqlQ, ConUtilitarios)
                cmd.ExecuteNonQuery()

                ''Version del Sistema A UTILIZAR
                'sqlQ = "UPDATE Configuracion SET Value1Var='" + txtVersion.Text + "' WHERE IDConfiguracion=19"
                'GuardarDatos()

                ''Año del Sistema A UTILIZAR
                'sqlQ = "UPDATE Configuracion SET Value1Var='" + txtAñoSist.Text + "' WHERE IDConfiguracion=20"
                'GuardarDatos()

                'Verificacion de Internet
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkVerificarInternet.Checked).ToString + "' WHERE IDConfiguracion=2"
                GuardarDatos()

                'Ruta Mysqldump.exe
                sqlQ = "UPDATE Configuracion SET Value1Var='" + Replace(txtRutaMysqldump.Text, "\", "\\") + "' WHERE IDConfiguracion=29"
                GuardarDatos()

                'Nombre Database
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtDatabase.Text + "' WHERE IDConfiguracion=33"
                GuardarDatos()

                'Host Database
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtHostDatabase.Text + "' WHERE IDConfiguracion=30"
                GuardarDatos()

                'User Database
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtUserDatabase.Text + "' WHERE IDConfiguracion=31"
                GuardarDatos()

                'Password Database
                sqlQ = "UPDATE Configuracion SET Value1Var='" + txtPasswordDatabase.Text + "' WHERE IDConfiguracion=32"
                GuardarDatos()

                'Dias Eliminado Backups
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtDiasEliminado.Text + "' WHERE IDConfiguracion=35"
                GuardarDatos()

                'Ocultar Iconos
                With frm_inicio
                    sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkHideIcons.Checked).ToString + "' WHERE IDConfiguracion=38"
                    GuardarDatos()

                    cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion WHERE IDConfiguracion=38", Con)
                    Dim HideStartIco As String = Convert.ToString(cmd.ExecuteScalar())
                    If HideStartIco = 0 Then

                        For Each OptionMenu As ToolStripMenuItem In .MenuBar.Items
                            OptionMenu.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                        Next
                    Else
                        For Each OptionMenu As ToolStripMenuItem In .MenuBar.Items
                            OptionMenu.DisplayStyle = ToolStripItemDisplayStyle.Text
                        Next
                    End If
                End With

                'Bordes Formulario Inicio
                With frm_inicio
                    sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkfrminicioBordes.Checked).ToString + "' WHERE IDConfiguracion=48"
                    GuardarDatos()

                    cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion WHERE IDConfiguracion=48", Con)
                    Dim HideBourdes As String = Convert.ToString(cmd.ExecuteScalar())
                    If HideBourdes = 0 Then
                        .FormBorderStyle = FormBorderStyle.FixedSingle
                    Else
                        .FormBorderStyle = FormBorderStyle.None
                        Me.WindowState = FormWindowState.Normal
                    End If
                End With

                'Mostrar fondos de pantallas en login del programa
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkWallpapersLogin.Checked).ToString + "' WHERE IDConfiguracion=49"
                GuardarDatos()

                'Mostrar fondos de pantallas en inicio del programa
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkWallpapersStart.Checked).ToString + "' WHERE IDConfiguracion=67"
                GuardarDatos()

                'Permitir acceso directo a administradores
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkHabLoginAdmin.Checked).ToString + "' WHERE IDConfiguracion=56"
                GuardarDatos()

                'Usuario del administrador
                sqlQ = "UPDATE Libregco_Utilitarios.Ajustes SET Value='" + txtAdminUser.Text + "' WHERE IDAjuste=2"
                cmd = New MySqlCommand(sqlQ, ConUtilitarios)
                cmd.ExecuteNonQuery()

                'Password del administrador
                sqlQ = "UPDATE Libregco_Utilitarios.Ajustes SET Value='" + txtPasswordAdmin.Text + "' WHERE IDAjuste=3"
                cmd = New MySqlCommand(sqlQ, ConUtilitarios)
                cmd.ExecuteNonQuery()

                'Color primario
                sqlQ = "UPDATE Configuracion SET Value1Var='" + ColorPrimario.BackColor.ToArgb.ToString + "' WHERE IDConfiguracion=64"
                GuardarDatos()

                'Color Secundario
                sqlQ = "UPDATE Configuracion SET Value1Var='" + ColorSecundario.BackColor.ToArgb.ToString + "' WHERE IDConfiguracion=65"
                GuardarDatos()

                'Color Terciario
                sqlQ = "UPDATE Configuracion SET Value1Var='" + ColorTerciario.BackColor.ToArgb.ToString + "' WHERE IDConfiguracion=66"
                GuardarDatos()

                'Animacion de monedas en login
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkAnimacionMonLogin.Checked).ToString + "' WHERE IDConfiguracion=72"
                GuardarDatos()

                'Barra de progreso en inicio
                sqlQ = "UPDATE Configuracion SET Value2Int='" + lblColorBarraProgreso.Text + "' WHERE IDConfiguracion=74"
                GuardarDatos()

                'Permitir cambio de estructura de NCF           
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(ChkPerCambiarEstructuraNCF.Checked).ToString + "' WHERE IDConfiguracion=76"
                GuardarDatos()

                'Habilitar modulo inventario                          
                sqlQ = "UPDATE Modulos SET Habilitar='" + Convert.ToInt16(chkModInventario.Checked).ToString + "' WHERE IDModulo=1"
                GuardarDatos()

                'Habilitar modulo facturación                          
                sqlQ = "UPDATE Modulos SET Habilitar='" + Convert.ToInt16(chkModFacturacion.Checked).ToString + "' WHERE IDModulo=2"
                GuardarDatos()

                'Habilitar modulo cxc                            
                sqlQ = "UPDATE Modulos SET Habilitar='" + Convert.ToInt16(chkModCXC.Checked).ToString + "' WHERE IDModulo=3"
                GuardarDatos()

                'Habilitar modulo cxp                          
                sqlQ = "UPDATE Modulos SET Habilitar='" + Convert.ToInt16(chkModCXP.Checked).ToString + "' WHERE IDModulo=4"
                GuardarDatos()

                'Habilitar modulo nomina                              
                sqlQ = "UPDATE Modulos SET Habilitar='" + Convert.ToInt16(chkModNomina.Checked).ToString + "' WHERE IDModulo=5"
                GuardarDatos()

                'Habilitar modulo bancos                               
                sqlQ = "UPDATE Modulos SET Habilitar='" + Convert.ToInt16(chkModBancos.Checked).ToString + "' WHERE IDModulo=6"
                GuardarDatos()

                'Habilitar modulo supervisión                      
                sqlQ = "UPDATE Modulos SET Habilitar='" + Convert.ToInt16(chkModSupervision.Checked).ToString + "' WHERE IDModulo=7"
                GuardarDatos()

                'Habilitar modulo caja chica                              
                sqlQ = "UPDATE Modulos SET Habilitar='" + Convert.ToInt16(chkModCajaChica.Checked).ToString + "' WHERE IDModulo=8"
                GuardarDatos()

                'Habilitar modulo contabilidad                              
                sqlQ = "UPDATE Modulos SET Habilitar='" + Convert.ToInt16(chkModContabilidad.Checked).ToString + "' WHERE IDModulo=9"
                GuardarDatos()

                'Habilitar modulo servicios                                
                sqlQ = "UPDATE Modulos SET Habilitar='" + Convert.ToInt16(chkModServicios.Checked).ToString + "' WHERE IDModulo=10"
                GuardarDatos()

                'Habilitar modulo estadísticias                          
                sqlQ = "UPDATE Modulos SET Habilitar='" + Convert.ToInt16(chkModEstadisticas.Checked).ToString + "' WHERE IDModulo=11"
                GuardarDatos()

                'Habilitar modulo ayuda                            
                sqlQ = "UPDATE Modulos SET Habilitar='" + Convert.ToInt16(chkModAyuda.Checked).ToString + "' WHERE IDModulo=12"
                GuardarDatos()

                'Mostrar barra de acceso rapido                                 
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkMostrarBarraAcceso.Checked).ToString + "' WHERE IDConfiguracion=99"
                GuardarDatos()

                'Mostrar barra de acceso rapido de clientes                
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkAccesoRapidoClientes.Checked).ToString + "' WHERE IDConfiguracion=102"
                GuardarDatos()

                'Cantidad de elementos a mostrar en barra de acceso
                sqlQ = "UPDATE Configuracion SET Value2Int='" + txtCantAccesosRapidos.Text + "' WHERE IDConfiguracion=100"
                GuardarDatos()

                'Forzar actualizaciones                                     
                sqlQ = "UPDATE Configuracion SET Value2Int='" + Convert.ToInt16(chkForzarActualizacion.Checked).ToString + "' WHERE IDConfiguracion=119"
                GuardarDatos()

                Dim IDTipoDocumento, TipoDocumento, Letras, UltSec, Relleno, Caracter As New Label
                For Each row As DataGridViewRow In DgvDocumentos.Rows
                    IDTipoDocumento.Text = row.Cells(0).Value
                    TipoDocumento.Text = row.Cells(1).Value
                    Letras.Text = row.Cells(2).Value
                    UltSec.Text = row.Cells(3).Value
                    Relleno.Text = row.Cells(4).Value
                    Caracter.Text = row.Cells(5).Value

                    sqlQ = "UPDATE TipoDocumento SET Documento='" + TipoDocumento.Text + "',Letra='" + Letras.Text + "',UltimaSecuencia='" + UltSec.Text + "',Filler='" + Relleno.Text + "',CantCharacter='" + Caracter.Text + "' WHERE IDTipoDocumento='" + IDTipoDocumento.Text + "'"
                    GuardarDatos()
                Next

                Dim IDPermiso, NewPath, Descripcion As New Label
                For Each row As DataGridViewRow In DgvIconos.Rows
                    IDPermiso.Text = row.Cells(4).Value
                    Descripcion.Text = row.Cells(5).Value
                    NewPath.Text = row.Cells(8).Value

                    sqlQ = "UPDATE Permisos SET Descripcion='" + Descripcion.Text + "',FormularioFondo='" + Replace(NewPath.Text, "\", "\\") + "' WHERE IDPermisos='" + IDPermiso.Text + "'"
                    GuardarDatos()
                Next

                Dim IDReporte, Orden As New Label
                For Each rw As DataGridViewRow In DgvReportes.Rows
                    IDReporte.Text = rw.Cells(1).Value
                    Orden.Text = rw.Cells(4).Value

                    sqlQ = "UPDATE Reportes SET NoOrden='" + Orden.Text + "' WHERE IDReportes='" + IDReporte.Text + "'"
                    GuardarDatos()
                Next

                Dim IDDirectorio As New Label
                For Each rt As DataGridViewRow In DgvDirectorios.Rows
                    IDDirectorio.Text = rt.Cells(0).Value

                    If IDDirectorio.Text = "" Then
                        sqlQ = "INSERT INTO directorybackup (Directory) VALUES ('" + (Replace(rt.Cells(1).Value, "/", "//").Replace("\", "\\")).ToString + "')"
                        cmd = New MySqlCommand(sqlQ, ConUtilitarios)
                        cmd.ExecuteNonQuery()

                        cmd = New MySqlCommand("Select IDDirectoryBackup from libregco_utilitarios.DirectoryBackup where IDDirectoryBackup= (Select Max(IDDirectoryBackup) from DirectoryBackup)", ConUtilitarios)
                        rt.Cells(0).Value = Convert.ToString(cmd.ExecuteScalar())
                    End If
                Next

                Con.Close()
                ConUtilitarios.Close()

                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtConfirmPass_Leave(sender As Object, e As EventArgs) Handles txtConfirmPass.Leave
        If txtConfirmPass.Text = txtPasswordAdmin.Text Then
        Else
            MessageBox.Show("Las contraseñas no coinciden. Intente de nuevo.", "No coinciden las contraseñas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub ColorPrimario_Click(sender As Object, e As EventArgs) Handles ColorPrimario.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True

        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorPrimario.BackColor = CDialog.Color
        End If
    End Sub

    Private Sub ColorSecundario_Click(sender As Object, e As EventArgs) Handles ColorSecundario.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True

        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorSecundario.BackColor = CDialog.Color
        End If
    End Sub

    Private Sub ColorTerciario_Click(sender As Object, e As EventArgs) Handles ColorTerciario.Click
        Dim CDialog As New ColorDialog

        CDialog.AllowFullOpen = True
        CDialog.AnyColor = True
        CDialog.SolidColorOnly = False
        CDialog.ShowHelp = True

        If CDialog.ShowDialog() = DialogResult.OK Then
            ColorTerciario.BackColor = CDialog.Color
        End If
    End Sub

    Private Sub rdbVerde_CheckedChanged(sender As Object, e As EventArgs) Handles rdbVerde.CheckedChanged
        ChangeProgressBarColor()
    End Sub

    Private Sub ChangeProgressBarColor()
        If rdbVerde.Checked = True Then
            lblColorBarraProgreso.Text = 1
            SendMessage(ProgressBarInicio.Handle, 1040, 1, 0)
        ElseIf rdbRojo.Checked = True Then
            SendMessage(ProgressBarInicio.Handle, 1040, 2, 0)
            lblColorBarraProgreso.Text = 2
        ElseIf rdbAmarillo.Checked = True Then
            lblColorBarraProgreso.Text = 3
            SendMessage(ProgressBarInicio.Handle, 1040, 3, 0)
        End If

        For i = 0 To 100
            ProgressBarInicio.Value = i
        Next

    End Sub

    Private Sub rdbRojo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbRojo.CheckedChanged
        ChangeProgressBarColor()
    End Sub

    Private Sub rdbAmarillo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbAmarillo.CheckedChanged
        ChangeProgressBarColor()
    End Sub

    Private Sub DgvDocumentos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDocumentos.CellEndEdit
        DgvDocumentos.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvDocumentos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDocumentos.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
                DgvDocumentos.EditMode = DataGridViewEditMode.EditOnEnter
            End If
        End If
    End Sub

    Private Sub DgvDocumentos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvDocumentos.CurrentCellDirtyStateChanged
        If DgvDocumentos.IsCurrentCellDirty Then
            DgvDocumentos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvDocumentos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvDocumentos.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)
        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = DgvDocumentos.CurrentCell.ColumnIndex

        If Columna = 3 Or Columna = 5 Then
            Dim Caracter As Char = e.KeyChar
            Dim Txt As TextBox = CType(sender, TextBox)

            If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") And (Txt.Text.Contains(",") = False) Then

                e.Handled = False
            Else
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub MostrarEjemplosDocumentos()
        For Each row As DataGridViewRow In DgvDocumentos.Rows
            row.Cells(6).Value = row.Cells(2).Value & CStr(CInt(row.Cells(3).Value)).PadLeft(CInt(row.Cells(5).Value), row.Cells(4).Value)
        Next
    End Sub

    Private Sub DgvDocumentos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDocumentos.CellValueChanged
        If HabilitarCambio = 1 Then
            If e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Then
                DgvDocumentos.CurrentRow.Cells(6).Value = DgvDocumentos.CurrentRow.Cells(2).Value & CStr(CInt(DgvDocumentos.CurrentRow.Cells(3).Value)).PadLeft(CInt(DgvDocumentos.CurrentRow.Cells(5).Value), DgvDocumentos.CurrentRow.Cells(4).Value)
            End If
        End If

    End Sub

    Private Sub chkMostrarBarraAnimacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarBarraAcceso.CheckedChanged
        If chkMostrarBarraAcceso.Checked = True Then
            txtCantAccesosRapidos.Enabled = True
        Else
            txtCantAccesosRapidos.Enabled = False
        End If
    End Sub

    Private Sub txtCantAccesosRapidos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantAccesosRapidos.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCantAccesosRapidos_Leave(sender As Object, e As EventArgs) Handles txtCantAccesosRapidos.Leave
        If CDbl(txtCantAccesosRapidos.Text) > 8 Then
            txtCantAccesosRapidos.Text = 8
        End If
    End Sub

    Private Sub DgvIconos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvIconos.CellClick
        If TypeConnection.Text = 1 Then
            If e.RowIndex >= 0 Then
                If e.ColumnIndex = 5 Then
                    DgvDocumentos.EditMode = DataGridViewEditMode.EditOnEnter

                ElseIf e.ColumnIndex = 7 Then
                    frm_seleccion_iconos.ShowDialog(Me)
                End If
            End If
        End If
    End Sub

    Private Sub DgvIconos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvIconos.CurrentCellDirtyStateChanged
        If DgvIconos.IsCurrentCellDirty Then
            DgvIconos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If frm_create_new_version_sys.Visible = True Then
            If frm_create_new_version_sys.WindowState = FormWindowState.Minimized Then
                frm_create_new_version_sys.WindowState = FormWindowState.Normal
            Else
                frm_create_new_version_sys.Activate()
            End If
        Else
            frm_create_new_version_sys.Show(Me)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ExistFile As Boolean
        For Each Row As DataGridViewRow In DgvReportes.Rows
            ExistFile = System.IO.File.Exists(Row.Cells(3).Value)
            If ExistFile = True Then
                Row.Cells(5).Value = "Correcto"
            Else
                Row.Cells(5).Value = "No ha sido encontrado."
            End If
        Next
    End Sub

    Private Sub btnEliminarErrores_Click(sender As Object, e As EventArgs) Handles btnEliminarErrores.Click
        Try
            ConMixta.Open()

            For Each Rw As DataGridViewRow In DgvErrores.Rows
                If System.IO.File.Exists(Rw.Cells(7).Value) = True Then
                    My.Computer.FileSystem.DeleteFile(Rw.Cells(7).Value, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
                End If
                sqlQ = "Delete from" & SysName.Text & "Errores Where IDError = (" + Rw.Cells(8).Value.ToString + ")"
                cmd = New MySqlCommand(sqlQ, ConMixta)
                cmd.ExecuteNonQuery()
            Next

            'Cargar Errores
            Dim Img As Image
            Dim wFile As System.IO.FileStream
            DgvErrores.Rows.Clear()

            Dim CmdErrores As New MySqlCommand("SELECT Imagen,Fecha,Formulario,Metodo,Descripcion,MetodoBase,Concat(VersionMayor,'.',VersionMenor,'.',VersionCompilacion,'.',VersionVersion),IDError FROM" & SysName.Text & "errores INNER JOIN Libregco_Utilitarios.Version_sys on Errores.IDVersion=Version_sys.IDBuild", ConMixta)
            Dim LectorErrores As MySqlDataReader = CmdErrores.ExecuteReader

            While LectorErrores.Read

                Dim ExistFile As Boolean = System.IO.File.Exists(LectorErrores.GetValue(0))
                If ExistFile = True Then
                    wFile = New FileStream(LectorErrores.GetValue(0), FileMode.Open, FileAccess.Read)
                    Img = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                Else
                    Img = My.Resources.No_Image
                End If

                DgvErrores.Rows.Add(Img, LectorErrores.GetValue(1), LectorErrores.GetValue(2), LectorErrores.GetValue(3), LectorErrores.GetValue(4), LectorErrores.GetValue(5), LectorErrores.GetValue(6), LectorErrores.GetValue(0), LectorErrores.GetValue(7))

            End While
            LectorErrores.Close()

            ConMixta.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnActualizarCliente_Click(sender As Object, e As EventArgs) Handles btnActualizarCliente.Click
        Try
            If rdbIndividual.Checked = True Then
                Dim Mensaje, Titulo, DefaultValue As String
                Dim MyValue As Object

                Mensaje = "Escriba el código del cliente que desea actualizar."
                Titulo = "Calcular balance del cliente"
                DefaultValue = ""

                MyValue = InputBox(Mensaje, Titulo, DefaultValue)

                If MyValue Is "" Then
                    Exit Sub
                Else
                    FunctCalcBcesFact(MyValue)
                    FunctCalcBceGral(MyValue)

                    MessageBox.Show("Se ha actualizado el balance del cliente satisfactoriamente.", "Balance actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea ajustar el balance de todos los clientes en la base de datos?" & vbNewLine & vbNewLine & "Este proceso podría tardar varios minutos.", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then

                    Dim x As Integer = 0

                    Dim DsTemp As New DataSet
                    Con.Open()
                    cmd = New MySqlCommand("SELECT IDCliente,Nombre FROM libregco.Clientes", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "Clientes")
                    Con.Close()

                    Dim Tabla As DataTable = DsTemp.Tables("Clientes")

                    ProgressBar2.Value = 0
                    TextBox1.AppendText("Iniciando ajuste de balance de todos los clientes (" & Tabla.Rows.Count & ")" & Environment.NewLine)
                    ProgressBar2.Maximum = Tabla.Rows.Count

                    For Each Row As DataRow In Tabla.Rows
                        FunctCalcBcesFact(Row.Item(0))
                        FunctCalcBceGral(Row.Item(0))

                        x += 1
                        ProgressBar2.Value = x
                        Label19.Text = Math.Round(CDbl((x / ProgressBar2.Maximum) * 100), 3) & "%"
                        Label19.Refresh()
                        TextBox1.AppendText("(" & x & " de " & Tabla.Rows.Count & ") completado. {" & Row.Item(1) & "}" & Environment.NewLine)
                    Next

                    TextBox1.AppendText("Ajuste de balances de todos los clientes finalizada. ")

                    MessageBox.Show("Se han actualizado los balances satisfactoriamente.", "Balances actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            'MessageBox.Show("Se ha producido un error al intentar consultar con el valor específicado.", "Error en consulta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnActualizarSuplidor_Click(sender As Object, e As EventArgs) Handles btnActualizarSuplidor.Click
        Try
            If rdbIndividual.Checked = True Then

                Dim Mensaje, Titulo, DefaultValue As String
                Dim MyValue As Object

                Mensaje = "Escriba el código del suplidor que desea actualizar."
                Titulo = "Calcular balance del suplidor"
                DefaultValue = ""

                MyValue = InputBox(Mensaje, Titulo, DefaultValue)

                If MyValue Is "" Then
                    Exit Sub
                Else
                    FunctCalcBcesFactSuplidor(MyValue, True)
                    FunctCalcBceSuplidor(MyValue)

                    MessageBox.Show("Se ha actualizado el balance del suplidor satisfactoriamente.", "Balance actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea ajustar el balance de todos los suplidores en la base de datos?" & vbNewLine & vbNewLine & "Este proceso podría tardar varios minutos.", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    Dim DsTemp As New DataSet

                    DsTemp.Clear()
                    ConLibregco.Open()
                    cmd = New MySqlCommand("SELECT IDSuplidor FROM libregco.Suplidor", ConLibregco)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "Suplidor")
                    ConLibregco.Close()

                    Dim Tabla As DataTable = DsTemp.Tables("Suplidor")

                    For Each row As DataRow In Tabla.Rows
                        FunctCalcBcesFactSuplidor(row.Item(0))
                        FunctCalcBceSuplidor(row.Item(0))
                    Next

                    MessageBox.Show("Se ha actualizado el balance de los suplidores satisfactoriamente.", "Balances actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Se ha producido un error al intentar consultar con el valor específicado.", "Error en consulta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnActualizarEmpleados_Click(sender As Object, e As EventArgs) Handles btnActualizarEmpleados.Click
        Try

            If rdbIndividual.Checked = True Then

                Dim Mensaje, Titulo, DefaultValue As String
                Dim MyValue As Object

                Mensaje = "Escriba el código del empleado que desea actualizar."
                Titulo = "Calcular balance de empleado"
                DefaultValue = ""

                MyValue = InputBox(Mensaje, Titulo, DefaultValue)

                If MyValue Is "" Then
                Else
                    FunctCalcBcesEmpleados(MyValue)

                    MessageBox.Show("Se ha actualizado el balance del empleado satisfactoriamente.", "Balance actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea ajustar el balance de todos los empleados en la base de datos?" & vbNewLine & vbNewLine & "Este proceso podría tardar varios minutos.", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    Dim DsTemp As New DataSet

                    DsTemp.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT IDEmpleado FROM libregco.Empleados", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "Empleados")
                    Con.Close()

                    Dim Tabla As DataTable = DsTemp.Tables("Empleados")

                    For Each row As DataRow In Tabla.Rows
                        FunctCalcBcesEmpleados(row.Item(0))
                    Next

                    MessageBox.Show("Se ha actualizado el balance de los empleados satisfactoriamente.", "Balances actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Se ha producido un error al intentar consultar con el valor específicado.", "Error en consulta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnActualizarCuentaBancaria_Click(sender As Object, e As EventArgs) Handles btnActualizarCuentaBancaria.Click
        Try
            If rdbIndividual.Checked = True Then
                Dim Mensaje, Titulo, DefaultValue As String
                Dim MyValue As Object

                Mensaje = "Escriba el código de la cuenta bancaria que desea actualizar."
                Titulo = "Calcular balance del suplidor"
                DefaultValue = ""

                MyValue = InputBox(Mensaje, Titulo, DefaultValue)

                If MyValue Is "" Then
                Else
                    CalcularBceCuentaBancaria(MyValue)

                    MessageBox.Show("Se ha actualizado el balance de la cuenta bancaria satisfactoriamente.", "Balance actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea ajustar el balance de todos las cuentas bancarias en la base de datos?" & vbNewLine & vbNewLine & "Este proceso podría tardar varios minutos.", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    Dim DsTemp As New DataSet

                    DsTemp.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT IDCuenta FROM cuentasbancarias", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "cuentasbancarias")
                    Con.Close()

                    Dim Tabla As DataTable = DsTemp.Tables("cuentasbancarias")

                    For Each row As DataRow In Tabla.Rows
                        CalcularBceCuentaBancaria(row.Item(0))
                    Next

                    MessageBox.Show("Se ha actualizado el balance de las cuentas bancarias satisfactoriamente.", "Balances actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Se ha producido un error al intentar consultar con el valor específicado.", "Error en consulta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If rdbIndividual.Checked = True Then

            Dim Mensaje, Titulo, DefaultValue As String
            Dim MyValue As Object
            Dim DsTemp As New DataSet

            Mensaje = "Escriba el código del artículo que desea actualizar."
            Titulo = "Calcular balance del artículo"
            DefaultValue = ""

            MyValue = InputBox(Mensaje, Titulo, DefaultValue)

            If MyValue Is "" Then
                Exit Sub
            Else

                DsTemp.Clear()
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT IDPrecios,IDArticulo,IDMedida FROM libregco.precioarticulo where IDArticulo='" + MyValue.ToString + "'", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "Articulos")
                ConLibregco.Close()

                Dim Tabla As DataTable = DsTemp.Tables("Articulos")

                If Tabla.Rows.Count = 0 Then
                    MessageBox.Show("No se encontraron resultados del artículo.", "No se encontraron resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    FunctCalcInventarioGral(MyValue)

                    Dim IDPrecio As String

                    For Each row As DataRow In Tabla.Rows
                        IDPrecio = row.Item("IDPrecios")
                        FunctCalcInvAlmacenes(MyValue, IDPrecio)
                    Next

                    MessageBox.Show("Se ha actualizado el balance del artículo satisfactoriamente.", "Balance actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

        Else

            If BWArticulos.IsBusy <> True Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea ajustar el balance de todos los artículos en la base de datos?" & vbNewLine & vbNewLine & "Este proceso podría tardar varios minutos y no se puede cancelar.", "Ajustar balances de inventarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    BWArticulos.RunWorkerAsync()
                End If
            Else
                Dim Response As MsgBoxResult = MessageBox.Show("El operador de segundo plano esta ocupado." & vbNewLine & vbNewLine & "Desea detener la operación?", "Operaciones en segundo plano", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Response = MsgBoxResult.Yes Then
                        BWArticulos.CancelAsync()
                    End If
                End If






















                '    Dim DsTemp As New DataSet

                '    DsTemp.Clear()
                '    Con.Open()
                '    cmd = New MySqlCommand("SELECT articulos.IDArticulo,precioarticulo.idprecios,Articulos.Descripcion FROM libregco.Articulos inner join libregco.precioarticulo on articulos.idarticulo=precioarticulo.idarticulo", Con)
                '    Adaptador = New MySqlDataAdapter(cmd)
                '    Adaptador.Fill(DsTemp, "Articulos")
                '    Con.Close()

                '    ProgressBar2.Value = 0
                '    TextBox1.AppendText("Iniciando ajuste de existencia de todos los artículos (" & DsTemp.Tables("Articulos").Rows.Count & ")" & Environment.NewLine)
                '    ProgressBar2.Maximum = DsTemp.Tables("Articulos").Rows.Count - 1

                '    ConTemporal.Open()
                '    For i = 0 To DsTemp.Tables("Articulos").Rows.Count - 1
                '        FunctCalcInventarioGralSinConexion(DsTemp.Tables("Articulos").Rows(i).Item(0))
                '        FunctCalcInvAlmacenesSinConexion(DsTemp.Tables("Articulos").Rows(i).Item(0), DsTemp.Tables("Articulos").Rows(i).Item(1))

                '        ProgressBar2.Value = i
                '        Label19.Text = Math.Round(CDbl((i / ProgressBar2.Maximum) * 100), 3) & "%"
                '        Label19.Refresh()
                '        TextBox1.AppendText("(" & i & " de " & DsTemp.Tables("Articulos").Rows.Count - 1 & ") completado. {" & DsTemp.Tables("Articulos").Rows(i).Item(2) & "}" & Environment.NewLine)
                '    Next
                '    ConTemporal.Close()

                '    TextBox1.AppendText("Ajuste de existencia de todos los artículos finalizada. ")

                '    MessageBox.Show("Se ha actualizado el balance de los artículos satisfactoriamente.", "Balances actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            End If

    End Sub



    Private Sub BWArticulos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWArticulos.DoWork
        Dim DsTemp As New DataSet

        ProgressBar2.Value = 0

        DsTemp.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT articulos.IDArticulo,precioarticulo.idprecios,Articulos.Descripcion FROM libregco.Articulos inner join libregco.precioarticulo on articulos.idarticulo=precioarticulo.idarticulo", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "Articulos")
        Con.Close()

        ProgressBar2.Maximum = DsTemp.Tables("Articulos").Rows.Count

        ConTemporal.Open()

        For i As Integer = 0 To DsTemp.Tables("Articulos").Rows.Count - 1
            If BWArticulos.CancellationPending = True Then
                e.Cancel = True
                Exit For
            Else
                FunctCalcInventarioGralSinConexion(DsTemp.Tables("Articulos").Rows(i).Item(0))
                FunctCalcInvAlmacenesSinConexion(DsTemp.Tables("Articulos").Rows(i).Item(0), DsTemp.Tables("Articulos").Rows(i).Item(1))
                BWArticulos.ReportProgress(i)

                TextBox1.AppendText("(" & i & " de " & DsTemp.Tables("Articulos").Rows.Count - 1 & ") completado. {" & DsTemp.Tables("Articulos").Rows(i).Item(2) & "}" & Environment.NewLine)
            End If
        Next

        ConTemporal.Close()

    End Sub

    Private Sub IniciarCreacionPagares_Click(sender As Object, e As EventArgs) Handles IniciarCreacionPagares.Click
        Try

            Dim EvitSabado, EvitDomingo As String
            Dim IDFactura, Concepto, Numero, Cantidad As New Label
            Dim TablePagares As New DataTable
            Dim FechaFactura As Date
            Dim Monto, Balance, DiasVencidos As Double

            TablePagares.Columns.Clear()
            TablePagares.Columns.Add("Monto", Type.GetType("System.Double"))
            TablePagares.Columns.Add("Fecha", Type.GetType("System.String"))
            TablePagares.Columns.Add("Numero", Type.GetType("System.String"))
            TablePagares.Columns.Add("Cantidad", Type.GetType("System.String"))

            'Evitar Sabados en pagares
            Con.Open()
            cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=50", Con)
            EvitSabado = Convert.ToString(cmd.ExecuteScalar())

            'Evitar Domingos en pagares
            cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion where IDConfiguracion=51", Con)
            EvitDomingo = Convert.ToString(cmd.ExecuteScalar())

            For Each row As DataGridViewRow In DgvFacturas.Rows
                IDFactura.Text = row.Cells(0).Value
                FechaFactura = row.Cells(2).Value
                Balance = row.Cells(4).Value
                Cantidad.Text = row.Cells(5).Value
                Monto = row.Cells(6).Value


                'Verifico si tienes pagares
                cmd = New MySqlCommand("SELECT count(IDPagare) FROM libregco.pagares where IDFactura='" + IDFactura.Text + "'", Con)
                If CInt(Convert.ToString(cmd.ExecuteScalar())) = 0 Then

                    'Agrego los pagares iguales
                    For i As Integer = 1 To CDbl(row.Cells(5).Value)
                        FechaFactura = FechaFactura.AddDays(30)

                        If FechaFactura.DayOfWeek = DayOfWeek.Saturday Then
                            FechaFactura = FechaFactura.AddDays(1)
                        ElseIf FechaFactura.DayOfWeek = DayOfWeek.Sunday Then
                            FechaFactura = FechaFactura.AddDays(1)
                        End If

                        TablePagares.Rows.Add(Monto, FechaFactura.ToString("yyyy-MM-dd"), TablePagares.Rows.Count + 1, Cantidad.Text)
                    Next

                    'Ya terminados la insersion de los pagares iguales agrego el adicional y elimino los datos mal suministrados.
                    If IsDate(row.Cells(8).Value) Then
                        If CDbl(row.Cells(7).Value) > 0 Then
                            FechaFactura = row.Cells(8).Value
                            Monto = row.Cells(7).Value

                            TablePagares.Rows.Add(Monto, FechaFactura.ToString("yyyy-MM-dd"), "ADC", "ADC")
                        Else
                            sqlQ = "UPDATE FacturaDatos SET FechaAdicional='' WHERE IDFacturaDatos='" + IDFactura.Text + "'"
                            cmd = New MySqlCommand(sqlQ, Con)
                            cmd.ExecuteNonQuery()
                        End If
                    Else
                        sqlQ = "UPDATE FacturaDatos SET PagoAdicional=0 WHERE IDFacturaDatos='" + IDFactura.Text + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                    End If

                    'Organizo los pagares por fechas
                    TablePagares.DefaultView.Sort = "Fecha DESC"
                    TablePagares = TablePagares.DefaultView.ToTable

                    'Inserto los pagares
                    For Each Rx As DataRow In TablePagares.Rows
                        FechaFactura = Rx.Item("Fecha")
                        Monto = Rx.Item("Monto")
                        Numero.Text = Rx.Item("Numero")
                        Cantidad.Text = Rx.Item("Cantidad")

                        If FechaFactura < Today Then
                            DiasVencidos = DateDiff(DateInterval.Day, CDate(FechaFactura), Today)
                        Else
                            DiasVencidos = 0
                        End If

                        Concepto.Text = "BUENO Y VALIDO POR " & ConvertNumbertoString(Monto)

                        If Balance > 0 Then
                            sqlQ = "INSERT INTO Pagares (IDTipoPagare,IDFactura,NoPagare,Cantidad,FechaVencimiento,DiasVencidos,Concepto,Monto,Balance,BalanceCerrado,IDEmpleado,IDStatusPagare,Nota,Cargado,Nulo) VALUES (1,'" + IDFactura.Text + "','" + Numero.Text + "','" + Cantidad.Text + "','" + FechaFactura.ToString("yyyy-MM-dd") + "','" + DiasVencidos.ToString + "','" + Concepto.Text + "','" + Monto.ToString + "','" + Monto.ToString + "','" + Monto.ToString + "','" + DefaultCobrador.Text + "',1,'',0,0)"
                            cmd = New MySqlCommand(sqlQ, Con)
                            cmd.ExecuteNonQuery()

                            Balance = Balance - Monto
                        Else
                            TablePagares.Rows.Clear()
                            Exit For
                        End If
                    Next

                    TablePagares.Rows.Clear()
                End If
            Next

            Con.Close()

            MessageBox.Show("La operacion ha finalizado exitosamente.!")

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnModifyCollation.Click
        Try
            ConMixta.Open()
            For Each row As DataGridViewRow In DgvTables.Rows
            If row.Cells(0).Value = "BASE TABLE" Then
                If row.Cells(5).Value <> "utf8_general_ci" Then
                    sqlQ = "ALTER TABLE " & row.Cells(1).Value.ToString & "." & row.Cells(2).Value.ToString & " CONVERT TO CHARACTER SET UTF8 COLLATE utf8_general_ci;"
                    cmd = ConMixta.CreateCommand
                    cmd.CommandText = sqlQ
                    cmd.ExecuteNonQuery()
                End If
            End If

        Next

        ConMixta.Close()

        MessageBox.Show("Se ha finalizado exitosamente la conversión")

        Catch ex As Exception
  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            If rdbIndividual.Checked = True Then

                Dim Mensaje, Titulo, DefaultValue As String
                Dim MyValue As Object

                Mensaje = "Escriba el código de la factura correspondiente a los pagarés que desea actualizar."
                Titulo = "Calcular balance de pagarés"
                DefaultValue = ""

                MyValue = InputBox(Mensaje, Titulo, DefaultValue)

                If MyValue Is "" Then
                    Exit Sub
                Else
                    CalcBcePagares(MyValue)

                    MessageBox.Show("Se ha actualizado el balance de los pagarés satisfactoriamente.", "Balance actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Else

                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea ajustar el balance de todos los pagarés en la base de datos?" & vbNewLine & vbNewLine & "Este proceso podría tardar varios minutos.", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    Dim DsTemp As New DataSet

                    DsTemp.Clear()
                    Con.Open()
                    cmd = New MySqlCommand("SELECT IDPagare,IDFactura FROM Pagares", Con)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "Pagares")
                    Con.Close()

                    Dim Tabla As DataTable = DsTemp.Tables("Pagares")

                    For Each row As DataRow In Tabla.Rows
                        CalcBcePagares(row.Item(1))
                    Next

                    MessageBox.Show("Se ha actualizado el balance de los pagarés satisfactoriamente.", "Balances actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Se ha producido un error al intentar consultar con el valor específicado.", "Error en consulta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Ds As New DataSet

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select IDPrecios,Costo   from Libregco.PrecioArticulo", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "PrecioArticulo")


        Dim Tabla As DataTable = Ds.Tables("PrecioArticulo")

        For Each row As DataRow In Tabla.Rows
            sqlQ = "UPDATE Libregco.PrecioArticulo SET CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(row.Item("Costo"))).ToString + "' WHERE IDPrecios='" + row.Item("IDPrecios").ToString + "'"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()

        Next

        Con.Close()
        MessageBox.Show("Aplicacion finalizada.")
    End Sub


    Private Sub DgvErrores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvErrores.CellDoubleClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                If DgvErrores.Rows.Count > 0 Then
                    If System.IO.File.Exists(DgvErrores.CurrentRow.Cells(7).Value.ToString) = True Then
                        System.Diagnostics.Process.Start(DgvErrores.CurrentRow.Cells(7).Value.ToString)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            If DgvReportes.SelectedRows.Count > 0 Then
                If System.IO.File.Exists(DgvReportes.CurrentRow.Cells(3).Value) Then
                    DgvReportes.CurrentRow.Cells(4).Value = "Abriendo reporte"
                    Process.Start(DgvReportes.CurrentRow.Cells(3).Value.ToString)
                Else
                    DgvReportes.CurrentRow.Cells(5).Value = "El reporte no ha sido encontrado en la ubicación específicada"
                    DgvReportes.CurrentRow.Cells(5).InheritedStyle.ForeColor = Color.Red
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        If TypeConnection.Text = 1 Then

            If DgvReportes.SelectedRows.Count > 0 Then

                If System.IO.File.Exists(DgvReportes.CurrentRow.Cells(3).Value) Then
                    Dim crParameterValues As New ParameterValues
                    Dim crParameterDiscreteValue As New ParameterDiscreteValue

                    ObjRpt.Close()
                    ObjRpt.Dispose()
                    ObjRpt = New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    crParameterValues.Clear()

                    ObjRpt.Load(DgvReportes.CurrentRow.Cells(3).Value.ToString)

                    Dim TmpForm = New frm_reportView
                    TmpForm.Show(Me)
                    TmpForm.IDReport = DgvReportes.CurrentRow.Cells(1).Value
                    TmpForm.ReportName = DgvReportes.CurrentRow.Cells(2).Value
                    TmpForm.ReportPath = DgvReportes.CurrentRow.Cells(3).Value

                    TmpForm.CrystalViewer.DisplayToolbar = False
                    TmpForm.CrystalViewer.DisplayStatusBar = False
                    TmpForm.CrystalViewer.ReportSource = ObjRpt
                    TmpForm.CrystalViewer.Refresh()
                    TmpForm.CrystalViewer.Zoom(2)
                    TmpForm.HideReportTab(TmpForm.CrystalViewer)
                    TmpForm.Contador.Enabled = True
                End If

            Else
                DgvReportes.CurrentRow.Cells(5).Value = "El reporte no ha sido encontrado en la ubicación específicada"
                DgvReportes.CurrentRow.Cells(5).InheritedStyle.ForeColor = Color.Red
            End If

        End If

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim Ds As New DataSet

        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT idarticulo FROM articulos", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "articulos")
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("articulos")

        For Each row As DataRow In Tabla.Rows
            SetDefaultPhoto(row.Item(0).value.ToString)
        Next

        MessageBox.Show("El proceso ha finalizado satisfactoriamente.", "Proceso finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        MessageBox.Show("Con Connection: " & vbNewLine & Con.ConnectionString & vbNewLine & vbNewLine & "ConLibregco Connection: " & vbNewLine & ConLibregco.ConnectionString & vbNewLine & vbNewLine & "ConLibregcoMain Connection: " & vbNewLine & ConLibregcoMain.ConnectionString & vbNewLine & vbNewLine & "ConMixta Connection: " & vbNewLine & ConMixta.ConnectionString & vbNewLine & vbNewLine & "ConUtilitarios Connection: " & vbNewLine & ConUtilitarios.ConnectionString & vbNewLine & vbNewLine & "ConAdminLib Connection: " & vbNewLine & ConAdminLib.ConnectionString)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim Ds As New DataSet

        Con.Open()
        cmd = New MySqlCommand("Select IDFacturaDatos from FacturaDatos where Balance>0", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "FacturaDatos")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("FacturaDatos")

        For Each row As DataRow In Tabla.Rows
            CalcBceCerrado(row.Item(0))
        Next

        MessageBox.Show("El proceso ha finalizado satisfactoriamente.", "Proceso finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim Ofdfile As New FolderBrowserDialog
        Ofdfile.Description = "Seleccionar carpeta para backups"
        Ofdfile.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Ofdfile.ShowNewFolderButton = False
        Ofdfile.RootFolder = Environment.SpecialFolder.Desktop


        If Ofdfile.ShowDialog = Windows.Forms.DialogResult.OK Then
            DgvDirectorios.Rows.Add("", Ofdfile.SelectedPath)
        End If
    End Sub

    Private Sub DgvDirectorios_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvDirectorios.CellMouseUp
        If e.RowIndex >= 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                DgvDirectorios.Rows(e.RowIndex).Selected = True
                DgvDirectorios.CurrentCell = DgvDirectorios.Rows(e.RowIndex).Cells(1)
                CMenuBackup.Show(DgvDirectorios, e.Location)
                CMenuBackup.Show(Cursor.Position)
            End If


        End If
    End Sub

    Private Sub QuitarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem1.Click
        If CStr(DgvDirectorios.CurrentRow.Cells(0).Value) = "" Then
            DgvDirectorios.Rows.Remove(DgvDirectorios.CurrentRow)
        Else
            sqlQ = "Delete from DirectoryBackup Where IDDirectoryBackup=(" + DgvDirectorios.CurrentRow.Cells(0).Value.ToString + ")"
            ConUtilitarios.Open()
            cmd = New MySqlCommand(sqlQ, ConUtilitarios)
            cmd.ExecuteNonQuery()
            ConUtilitarios.Close()
            DgvDirectorios.Rows.Remove(DgvDirectorios.CurrentRow)
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Try

            If rdbIndividual.Checked = True Then

                Dim Mensaje, Titulo, DefaultValue As String
                Dim MyValue As Object

                Mensaje = "Escriba el código de la factura correspondiente a los pagarés que desea actualizar."
                Titulo = "Calcular balance de pagarés"
                DefaultValue = ""

                MyValue = InputBox(Mensaje, Titulo, DefaultValue)

                If MyValue Is "" Then
                    Exit Sub
                Else
                    CalcBceCerrado(MyValue)

                    MessageBox.Show("Se ha actualizado el balance de los pagarés satisfactoriamente.", "Balance actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Else

                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea ajustar el balance de todos los pagarés en la base de datos?" & vbNewLine & vbNewLine & "Este proceso podría tardar varios minutos.", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    Dim DsTemp As New DataSet

                    DsTemp.Clear()
                    ConMixta.Open()
                    cmd = New MySqlCommand("SELECT IDFacturaDatos FROM" & SysName.Text & "facturadatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente where FacturaDatos.Balance>0", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "facturadatos")
                    ConMixta.Close()

                    Dim Tabla As DataTable = DsTemp.Tables("facturadatos")

                    For Each row As DataRow In Tabla.Rows
                        CalcBceCerrado(row.Item(0))
                    Next

                    MessageBox.Show("Se ha actualizado el balance de los pagarés satisfactoriamente.", "Balances actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvTables_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTables.CellContentClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 2 Then
                Dim Dstemp As New DataSet

                DgvEstructura.Rows.Clear()
                ConUtilitarios.Open()
                ConMixta.Open()

                Dim CmdDocumentos As New MySqlCommand("SELECT Field,TypeName,Nullis from Libregco_Utilitarios.typestables_fields where IDTypesTables=" & DgvTables.CurrentRow.Cells(6).Value.ToString, ConUtilitarios)
                Dim LectorDocs As MySqlDataReader = CmdDocumentos.ExecuteReader

                While LectorDocs.Read
                    DgvEstructura.Rows.Add(LectorDocs.GetValue(0), LectorDocs.GetValue(1), LectorDocs.GetValue(2))
                End While
                LectorDocs.Close()
                ConUtilitarios.Close()

                For Each rt As DataGridViewRow In DgvEstructura.Rows
                    Dstemp.Clear()
                    cmd = New MySqlCommand("select * from information_schema.columns where TABLE_NAME='" + DgvTables.CurrentRow.Cells(2).Value.ToString + "' AND TABLE_SCHEMA='" + DgvTables.CurrentRow.Cells(1).Value.ToString + "' AND COLUMN_NAME='" + rt.Cells(0).Value.ToString + "' LIMIT 1;", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(Dstemp, "TablesFields")

                    Dim TableFields As DataTable = Dstemp.Tables("TablesFields")

                    If TableFields.Rows.Count = 0 Then
                        rt.Cells(3).Style.ForeColor = Color.Red
                        rt.Cells(3).Value = rt.Cells(0).Value & " / Columna no encontrada..."
                    Else
                        If rt.Cells("DataGridViewTextBoxColumn48").Value <> TableFields.Rows(0).Item("COLUMN_TYPE").ToString Then
                            rt.Cells(3).Style.ForeColor = Color.Red
                            rt.Cells(3).Value = rt.Cells(0).Value & " / Datatipo o longitud erróneo. Es " & TableFields.Rows(0).Item("COLUMN_TYPE").ToString & " y debería ser " & rt.Cells("DataGridViewTextBoxColumn48").Value & "."
                        End If
                    End If
                Next

                XtraTabControl2.SelectedTabPageIndex = 1

                ConMixta.Close()
            End If
        End If
    End Sub

    Function VerificarTablasControladas(ByVal TableName As String) As Boolean
        Dim TablasSeguras As New List(Of String)({"accionesmodulos", "configuracion", "papersize", "permisos", "reportes", "reportesorden"})

        If TablasSeguras.Contains(TableName) Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles btnUpdateStructure.Click
        Dim Result As MsgBoxResult = MessageBox.Show("Desea actualizar el respaldo de estructura?", "Guardar Estructura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            Cursor.Current = Cursors.WaitCursor

            ConUtilitarios.Open()
            ConMixta.Open()

            'Cargar Tablas
            DgvTables.Rows.Clear()
            Dim CmdTablas As New MySqlCommand("SELECT TABLE_TYPE,TABLE_SCHEMA,TABLE_NAME,AUTO_INCREMENT-1 as TABLE_ROWS,TABLE_COLLATION FROM `INFORMATION_SCHEMA`.`TABLES` where Table_Schema like '%Libregco%' ORDER BY TABLE_TYPE, TABLE_NAME", ConMixta)
            Dim LectorTablas As MySqlDataReader = CmdTablas.ExecuteReader

            While LectorTablas.Read
                DgvTables.Rows.Add(LectorTablas.GetValue(0), LectorTablas.GetValue(1), LectorTablas.GetValue(2), "", LectorTablas.GetValue(3), LectorTablas.GetValue(4), "", VerificarTablasControladas(LectorTablas.GetValue(2)))
            End While
            LectorTablas.Close()


            For Each rw As DataGridViewRow In DgvTables.Rows
                cmd = New MySqlCommand("SELECT count(*) as Cantidad FROM information_schema.columns where TABLE_NAME='" + rw.Cells(2).Value.ToString + "' and Table_Schema='" + rw.Cells(1).Value.ToString + "'", ConUtilitarios)
                rw.Cells(3).Value = Convert.ToString(cmd.ExecuteScalar())
            Next


            cmd = New MySqlCommand("TRUNCATE TABLE typestables", ConUtilitarios)
            cmd.ExecuteNonQuery()

            cmd = New MySqlCommand("ALTER TABLE typestables AUTO_INCREMENT = 1;", ConUtilitarios)
            cmd.ExecuteNonQuery()

            cmd = New MySqlCommand("TRUNCATE TABLE Libregco_Utilitarios.typestables_Fields", ConUtilitarios)
            cmd.ExecuteNonQuery()

            cmd = New MySqlCommand("ALTER TABLE Libregco_Utilitarios.typestables_Fields AUTO_INCREMENT = 1;", ConUtilitarios)
            cmd.ExecuteNonQuery()

            For Each rw As DataGridViewRow In DgvTables.Rows
                cmd = New MySqlCommand("INSERT INTO typestables (TableType,NameSchema,NameTable,NameColumn,Rows,Collation,Controlar) VALUES ('" + rw.Cells(0).Value.ToString + "','" + rw.Cells(1).Value.ToString + "','" + rw.Cells(2).Value.ToString + "','" + rw.Cells(3).Value.ToString + "','" + rw.Cells(4).Value.ToString + "','" + rw.Cells(5).Value.ToString + "','" + Convert.ToInt16(rw.Cells(7).Value).ToString + "')", ConUtilitarios)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("Select IDTypesTables from libregco_utilitarios.typestables where IDTypesTables= (Select Max(IDTypesTables) from typestables)", ConUtilitarios)
                rw.Cells(6).Value = Convert.ToString(cmd.ExecuteScalar())

                DgvEstructura.Rows.Clear()
                Dim CmdDocumentos As New MySqlCommand("DESCRIBE " & rw.Cells(1).Value.ToString & "." & rw.Cells(2).Value.ToString, ConMixta)
                Dim LectorDocs As MySqlDataReader = CmdDocumentos.ExecuteReader

                While LectorDocs.Read
                    DgvEstructura.Rows.Add(LectorDocs.GetValue(0), LectorDocs.GetValue(1), LectorDocs.GetValue(2))
                End While
                LectorDocs.Close()


                For Each rx As DataGridViewRow In DgvEstructura.Rows
                    cmd = New MySqlCommand("INSERT INTO typestables_fields (IDTypesTables,Field,TypeName,NullIs) VALUES ('" + rw.Cells(6).Value.ToString + "','" + rx.Cells(0).Value.ToString + "','" + rx.Cells(1).Value.ToString + "','" + rx.Cells(2).Value.ToString + "')", ConUtilitarios)
                    cmd.ExecuteNonQuery()
                Next
            Next



            ConUtilitarios.Close()
            ConMixta.Close()

            MessageBox.Show("Se ha actualizar la estructura de respaldo satisfactoriamente..", "Actualizado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles btnAnalyseStructure.Click
        Try
            Dim Result As MsgBoxResult = MessageBox.Show("Desea analizar la estructura de la base de datos?", "Analizar Estructura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                Dim ErroresEncontrados As String
                Dim ErroresdeEstructuras As String
                Dim SQLErroresRepair As String

                Cursor.Current = Cursors.WaitCursor

                XtraTabControl2.SelectedTabPageIndex = 2

                Dim DsTmp As New DataSet
                Dim Table, TableFields As New DataTable
                ConMixta.Open()
                ConUtilitarios.Open()

                For Each rw As DataGridViewRow In DgvTables.Rows
                    DsTmp.Clear()
                    Table.Clear()
                    cmd = New MySqlCommand("SELECT * FROM information_schema.tables WHERE table_schema='" + rw.Cells(1).Value.ToString + "'  AND table_name='" + rw.Cells(2).Value.ToString + "' LIMIT 1;", ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTmp, "Tables")

                    Table = DsTmp.Tables("Tables")

                    RichTextBox1.AppendText(vbNewLine & "Buscando " & rw.Cells(1).Value.ToString & "." & rw.Cells(2).Value.ToString & "...")

                    If Table.Rows.Count = 0 Then
                        RichTextBox1.AppendText(vbNewLine & "ATENCIÓN: No se encontró en la estructura de la base de datos..." & vbNewLine)
                    ElseIf Table.Rows.Count = 1 Then
                        'RichTextBox1.AppendText(vbNewLine & "Verificando columnas en la base de datos..." & vbNewLine)

                        DgvEstructura.Rows.Clear()

                        Dim CmdDocumentos As New MySqlCommand("SELECT Field,TypeName,Nullis from Libregco_Utilitarios.typestables_fields where IDTypesTables=" & rw.Cells(6).Value.ToString, ConUtilitarios)
                        Dim LectorDocs As MySqlDataReader = CmdDocumentos.ExecuteReader

                        While LectorDocs.Read
                            DgvEstructura.Rows.Add(LectorDocs.GetValue(0), LectorDocs.GetValue(1), LectorDocs.GetValue(2))
                        End While
                        LectorDocs.Close()

                        If CBool(rw.Cells(7).Value) = True Then
                            cmd = New MySqlCommand("SELECT COUNT(*) FROM " & rw.Cells(1).Value.ToString & "." & rw.Cells(2).Value.ToString, ConMixta)
                            Dim RowsFinded As Integer = Convert.ToString(cmd.ExecuteScalar())

                            If RowsFinded <> rw.Cells(4).Value Then
                                RichTextBox1.Select(RichTextBox1.TextLength, 0)
                                RichTextBox1.SelectionColor = Color.SandyBrown
                                RichTextBox1.SelectionFont = New Font("Consolas", 8, FontStyle.Bold)
                                RichTextBox1.AppendText(vbNewLine & "IMPORTANTE: La cantidad de filas en " & rw.Cells(1).Value.ToString & "." & rw.Cells(2).Value.ToString & " no está completa." & vbNewLine)
                            End If
                        End If

                        For Each rt As DataGridViewRow In DgvEstructura.Rows
                            TableFields.Clear()
                            cmd = New MySqlCommand("select * from information_schema.columns where TABLE_NAME='" + rw.Cells(2).Value.ToString + "' AND TABLE_SCHEMA='" + rw.Cells(1).Value.ToString + "' AND COLUMN_NAME='" + rt.Cells(0).Value.ToString + "' LIMIT 1;", ConMixta)
                            Adaptador = New MySqlDataAdapter(cmd)
                            Adaptador.Fill(DsTmp, "TablesFields")

                            TableFields = DsTmp.Tables("TablesFields")

                            'Try

                            If TableFields.Rows.Count = 0 Then
                                RichTextBox1.Select(RichTextBox1.TextLength, 0)
                                RichTextBox1.SelectionColor = Color.Red
                                RichTextBox1.SelectionFont = New Font("Consolas", 8, FontStyle.Bold)
                                RichTextBox1.AppendText(vbNewLine & "ATENCIÓN: No se encontró el campo " & rt.Cells(0).Value.ToString & " en la estructura " & rw.Cells(1).Value.ToString & "." & rw.Cells(2).Value.ToString & vbNewLine)

                                ErroresEncontrados = ErroresEncontrados & "Columna " & rt.Cells(0).Value.ToString & " en " & rw.Cells(1).Value.ToString & "." & rw.Cells(2).Value.ToString & vbNewLine

                                If rt.Cells(1).Value.ToString.Contains("var") Then
                                    SQLErroresRepair = SQLErroresRepair & "ALTER TABLE `" & rw.Cells(1).Value.ToString & "`.`" & rw.Cells(2).Value.ToString & "` ADD COLUMN `" & rt.Cells(0).Value.ToString & "` " & rt.Cells(1).Value.ToString.ToUpper & " NULL DEFAULT '';" & vbNewLine & "SET SQL_SAFE_UPDATES = 0;" & vbNewLine & "UPDATE `" & rw.Cells(1).Value.ToString & "`.`" & rw.Cells(2).Value.ToString & "` SET " & rt.Cells(0).Value.ToString & "='';" & vbNewLine
                                ElseIf rt.Cells(1).Value.ToString.Contains("double") Then
                                    SQLErroresRepair = SQLErroresRepair & "ALTER TABLE `" & rw.Cells(1).Value.ToString & "`.`" & rw.Cells(2).Value.ToString & "` ADD COLUMN `" & rt.Cells(0).Value.ToString & "` " & rt.Cells(1).Value.ToString.ToUpper & " NULL DEFAULT 0;" & vbNewLine & "SET SQL_SAFE_UPDATES = 0;" & vbNewLine & "UPDATE `" & rw.Cells(1).Value.ToString & "`.`" & rw.Cells(2).Value.ToString & "` SET " & rt.Cells(0).Value.ToString & "=0;" & vbNewLine
                                ElseIf rt.Cells(1).Value.ToString.Contains("int") Then
                                    SQLErroresRepair = SQLErroresRepair & "ALTER TABLE `" & rw.Cells(1).Value.ToString & "`.`" & rw.Cells(2).Value.ToString & "` ADD COLUMN `" & rt.Cells(0).Value.ToString & "` " & rt.Cells(1).Value.ToString.ToUpper & " NULL DEFAULT 0;" & vbNewLine & "SET SQL_SAFE_UPDATES = 0;" & vbNewLine & "UPDATE `" & rw.Cells(1).Value.ToString & "`.`" & rw.Cells(2).Value.ToString & "` SET " & rt.Cells(0).Value.ToString & "=0;" & vbNewLine
                                End If
                            Else
                                If TableFields.Rows(0).Item("TABLE_NAME").ToString.Contains("view") Then
                                Else
                                    If TableFields.Rows(0).Item("COLUMN_TYPE").ToString.Contains("int") Then
                                    Else
                                        If TableFields.Rows(0).Item("COLUMN_TYPE").ToString <> DgvEstructura.Rows(rt.Index).Cells("DataGridViewTextBoxColumn48").Value Then
                                            RichTextBox1.Select(RichTextBox1.TextLength, 0)
                                            RichTextBox1.SelectionColor = Color.Orange
                                            RichTextBox1.SelectionFont = New Font("Consolas", 8, FontStyle.Bold)
                                            RichTextBox1.AppendText(vbNewLine & "ATENCIÓN: La columna " & rt.Cells(0).Value & " tiene diferencias en su estructura." & vbNewLine)

                                            ErroresdeEstructuras = ErroresdeEstructuras & "Columna " & rw.Cells(2).Value & "." & rt.Cells(0).Value.ToString & " posee diferencias en el tipo de datos o en la longitud. La longitud programada es " & DgvEstructura.Rows(rt.Index).Cells("DataGridViewTextBoxColumn48").Value & " vs la actual " & TableFields.Rows(0).Item("COLUMN_TYPE").ToString & "." & vbNewLine

                                            If rt.Cells(1).Value.ToString.Contains("char") Then
                                                SQLErroresRepair = SQLErroresRepair & "ALTER TABLE `" & rw.Cells(1).Value.ToString & "`.`" & rw.Cells(2).Value.ToString & "` " & "CHANGE COLUMN " & "`" & rt.Cells(0).Value.ToString & "` " & "`" & rt.Cells(0).Value.ToString & "` " & rt.Cells(1).Value.ToString.ToUpper & " Not NULL DEFAULT '';" & vbNewLine
                                            ElseIf rt.Cells(1).Value.ToString.Contains("double") Then
                                                SQLErroresRepair = SQLErroresRepair & "ALTER TABLE `" & rw.Cells(1).Value.ToString & "`.`" & rw.Cells(2).Value.ToString & "` " & "CHANGE COLUMN " & "`" & rt.Cells(0).Value.ToString & "` " & "`" & rt.Cells(0).Value.ToString & "` " & rt.Cells(1).Value.ToString.ToUpper & " Not NULL DEFAULT 0;" & vbNewLine
                                            ElseIf rt.Cells(1).Value.ToString.Contains("int") Then
                                                SQLErroresRepair = SQLErroresRepair & "ALTER TABLE `" & rw.Cells(1).Value.ToString & "`.`" & rw.Cells(2).Value.ToString & "` " & "CHANGE COLUMN " & "`" & rt.Cells(0).Value.ToString & "` " & "`" & rt.Cells(0).Value.ToString & "` " & rt.Cells(1).Value.ToString.ToUpper & " Not NULL DEFAULT 0;" & vbNewLine
                                            End If
                                        End If
                                    End If
                                End If

                            End If


                            'Catch ex As Exception

                            'End Try
                        Next

                    End If

                    RichTextBox1.SelectionStart = Len(RichTextBox1.Text)
                    RichTextBox1.ScrollToCaret()
                    RichTextBox1.Select()
                Next

                ConMixta.Close()
                ConUtilitarios.Close()

                Cursor.Current = Cursors.Default

                RichTextBox1.Select(RichTextBox1.TextLength, 0)
                RichTextBox1.SelectionColor = SystemColors.Highlight
                RichTextBox1.SelectionFont = New Font("Consolas", 8, FontStyle.Italic)
                RichTextBox1.AppendText(vbNewLine & "ANÁLISIS COMPLETADO _________________________________________________________________________________" & vbNewLine)


                If ErroresEncontrados <> "" Then
                    RichTextBox1.Select(RichTextBox1.TextLength, 0)
                    RichTextBox1.SelectionColor = Color.Brown
                    RichTextBox1.SelectionFont = New Font("Consolas", 8, FontStyle.Regular)
                    RichTextBox1.AppendText(vbNewLine & "Errores encontrados..." & vbNewLine)
                    RichTextBox1.AppendText(ErroresEncontrados)
                End If
                If ErroresdeEstructuras <> "" Then
                    RichTextBox1.Select(RichTextBox1.TextLength, 0)
                    RichTextBox1.SelectionColor = Color.IndianRed
                    RichTextBox1.SelectionFont = New Font("Consolas", 8, FontStyle.Regular)
                    RichTextBox1.AppendText(vbNewLine & "Errores de estructura encontrados..." & vbNewLine)
                    RichTextBox1.AppendText(ErroresdeEstructuras)
                End If

                If SQLErroresRepair <> "" Then
                    RichTextBox1.Select(RichTextBox1.TextLength, 0)
                    RichTextBox1.SelectionColor = Color.Green
                    RichTextBox1.SelectionFont = New Font("Consolas", 8, FontStyle.Regular)
                    RichTextBox1.AppendText(vbNewLine & vbNewLine & "MYSQL Queryes" & vbNewLine)
                    RichTextBox1.AppendText(SQLErroresRepair)
                End If
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvTables_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTables.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 7 Then
                DgvTables.EditMode = DataGridViewEditMode.EditOnEnter
            End If
        End If
    End Sub

    Private Sub DgvTables_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvTables.CurrentCellDirtyStateChanged
        If DgvTables.IsCurrentCellDirty Then
            DgvTables.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvTables_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTables.CellEndEdit
        DgvTables.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvTables_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTables.CellValueChanged
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 7 Then
                ConUtilitarios.Open()
                sqlQ = "UPDATE  typestables SET Controlar='" + Convert.ToInt16(DgvTables.CurrentRow.Cells(7).Value).ToString + "' WHERE IDTypesTables='" + DgvTables.CurrentRow.Cells(6).Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConUtilitarios)
                cmd.ExecuteNonQuery()
                ConUtilitarios.Close()
            End If
        End If
    End Sub

    Private Sub DgvEstructura_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEstructura.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 4 Then
                'Verificacion de tipo de datos
                Dim ValueToSET As String
                If DgvEstructura.CurrentRow.Cells(1).Value.ToString.Contains("int") Then
                    If DgvEstructura.CurrentRow.Cells(5).Value = "" Then
                        ValueToSET = 0
                    Else
                        ValueToSET = DgvEstructura.CurrentRow.Cells(5).Value
                    End If

                ElseIf DgvEstructura.CurrentRow.Cells(1).Value.ToString.Contains("double") Then
                    If DgvEstructura.CurrentRow.Cells(5).Value = "" Then
                        ValueToSET = 0
                    Else
                        ValueToSET = DgvEstructura.CurrentRow.Cells(5).Value
                    End If

                ElseIf DgvEstructura.CurrentRow.Cells(1).Value.ToString.Contains("char") Then
                    If DgvEstructura.CurrentRow.Cells(5).Value = "" Then
                        ValueToSET = "''"
                    Else
                        ValueToSET = DgvEstructura.CurrentRow.Cells(5).Value
                    End If


                ElseIf DgvEstructura.CurrentRow.Cells(1).Value.ToString.Contains("date") Then
                    If DgvEstructura.CurrentRow.Cells(5).Value = "" Then
                        ValueToSET = "NULL"
                    Else
                        ValueToSET = CDate(DgvEstructura.CurrentRow.Cells(5).Value).ToString("yyyy-MM-dd")
                    End If
                End If

                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea actualizar el CONTENIDO de la columna " & DgvEstructura.CurrentRow.Cells(0).Value & " de la tabla " & DgvTables.CurrentRow.Cells(1).Value & "." & DgvTables.CurrentRow.Cells(2).Value & "?", "Actualizar Contenido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If Result = MsgBoxResult.Yes Then
                    Dim Result1 As MsgBoxResult = MessageBox.Show("ÚLTIMA ADVERTENCIA: " & vbNewLine & vbNewLine & "Está muy seguro que desea ACTUALIZAR el CONTENIDO de la columna " & DgvEstructura.CurrentRow.Cells(0).Value & " de la tabla " & DgvTables.CurrentRow.Cells(1).Value & "." & DgvTables.CurrentRow.Cells(2).Value & "?" & vbNewLine & vbNewLine & "El SCRIPT a implementar es: " & vbNewLine & vbNewLine & "SET SQL_SAFE_UPDATES = 0;" & vbNewLine & "UPDATE " & DgvTables.CurrentRow.Cells(1).Value & "." & DgvTables.CurrentRow.Cells(2).Value & " SET " & DgvEstructura.CurrentRow.Cells(0).Value & "=" & ValueToSET & ";", "Actualizar Contenido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If Result1 = MsgBoxResult.Yes Then
                        ConMixta.Open()
                        cmd = New MySqlCommand("SET SQL_SAFE_UPDATES = 0;" & vbNewLine & "UPDATE " & DgvTables.CurrentRow.Cells(1).Value & "." & DgvTables.CurrentRow.Cells(2).Value & " SET " & DgvEstructura.CurrentRow.Cells(0).Value & "=" & ValueToSET & ";", ConMixta)
                        cmd.ExecuteNonQuery()
                        ConMixta.Close()

                    End If
                End If

            End If

        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Ds As New DataSet

        Con.Open()
        cmd = New MySqlCommand("SELECT IDPrecios FROM libregco.precioarticulo", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "precioarticulo")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("precioarticulo")
        ConMixta.Open()

        For Each dt As DataRow In Tabla.Rows
            UpdateLastUpdatePrices(dt.Item(0))
        Next

        ConMixta.Close()

        Tabla.Dispose()
        Ds.Dispose()
    End Sub

    Public Sub UpdateLastUpdatePrices(ByVal IDPrecio As String)
        Dim Dstemp As New DataSet
        cmd = New MySqlCommand("SELECT IFNULL((Select FechaFactura from Libregco.Compras inner join Libregco.DetalleCompra on Compras.IDCompra=DetalleCompra.IDCompra Where DetalleCompra.IDArticulo=Articulos.IDArticulo ORDER BY Compras.FechaFactura DESC LIMIT 1),'1991-01-01') as UltimaCompraZ,IFNULL((Select DetalleCompra.Importe from Libregco.Compras INNER JOIN Libregco.DetalleCompra on Compras.IDCompra=DetalleCompra.IDCompra Where DetalleCompra.IDArticulo=Articulos.IDArticulo ORDER BY Compras.FechaFactura DESC LIMIT 1),0) as UltCostoCompraZ,IFNULL((Select FechaFactura from Libregco_Main.Compras inner join Libregco_Main.DetalleCompra on Compras.IDCompra=DetalleCompra.IDCompra Where DetalleCompra.IDArticulo=Articulos.IDArticulo ORDER BY Compras.FechaFactura DESC LIMIT 1),'1991-01-01') as UltimaCompraA,IFNULL((Select DetalleCompra.Importe from Libregco_Main.Compras INNER JOIN Libregco_Main.DetalleCompra on Compras.IDCompra=DetalleCompra.IDCompra Where DetalleCompra.IDArticulo=Articulos.IDArticulo ORDER BY Compras.FechaFactura DESC LIMIT 1),0) as UltCostoCompraA,IFNULL((Select DATE(Fecha) from Libregco.PrecioArticulo_historial where PrecioArticulo_historial.IDPrecioArticulo=PrecioArticulo.IDPrecios ORDER BY PrecioArticulo_historial.FechA DESC LIMIT 1),'1990-01-01') as UltimoCambioPrecios from Libregco.PrecioArticulo INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo where PrecioArticulo.IDPrecios='" + IDPrecio.ToString + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Dstemp, "precioarticulo")

        If Dstemp.Tables("precioarticulo").Rows.Count > 0 Then

            If CDate(Dstemp.Tables("precioarticulo").Rows(0).Item("UltimaCompraZ")) > CDate(Dstemp.Tables("precioarticulo").Rows(0).Item("UltimaCompraA")) Then
                sqlQ = "UPDATE Libregco.precioarticulo Set UltimoCostoCompra='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltCostoCompraZ").ToString + "',UltimaActualizacion='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltimaCompraZ").ToString + "',UltimoCambioPrecios='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltimoCambioPrecios").ToString + "' where IDPrecios='" + IDPrecio.ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConMixta)
                cmd.ExecuteNonQuery()
            Else
                sqlQ = "UPDATE Libregco.precioarticulo Set UltimoCostoCompra='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltCostoCompraA").ToString + "',UltimaActualizacion='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltimaCompraA").ToString + "',UltimoCambioPrecios='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltimoCambioPrecios").ToString + "' where IDPrecios='" + IDPrecio.ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConMixta)
                cmd.ExecuteNonQuery()
            End If

        End If

        Dstemp.Dispose()
    End Sub

    Private Sub Button18_Click_1(sender As Object, e As EventArgs) Handles Button18.Click
        Try

            'Libregco
            Dim Dstemp As New DataSet
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDMovimientoDetalle,movimientoinventario.IDTipodeAjuste,movimientoinvdetalle.Precio,movimientoinvdetalle.Importe,Movimientoinvdetalle.Cantidad FROM libregco.movimientoinvdetalle inner join Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario where IDTipodeAjuste is not null", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp, "movimientoinvdetalle")
            ConLibregco.Close()

            ConLibregco.Open()

            lblStatusBar.Text = "Libregco"
            For Each dt As DataRow In Dstemp.Tables("movimientoinvdetalle").Rows
                lblStatusBar.Text = dt.Item("IDMovimientoDetalle").ToString
                sqlQ = "UPDATE Libregco.movimientoinvdetalle Set Cantidad='" + If(dt.Item("IDTipodeAjuste") = 1, CDbl(Math.Abs(dt.Item("Cantidad"))).ToString, -Math.Abs(CDbl(dt.Item("Cantidad"))).ToString).ToString + "',IDTipoAjusteDetalle='" + dt.Item("IDTipodeAjuste").ToString + "',ExistenciaAnterior=0,Precio='" + dt.Item("Precio").ToString + "',Importe='" + If(dt.Item("IDTipodeAjuste") = 1, Math.Abs(CDbl(dt.Item("Importe"))).ToString, -Math.Abs(CDbl(dt.Item("Importe")))).ToString + "' where IDMovimientoDetalle='" + dt.Item("IDMovimientoDetalle").ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConLibregco)
                cmd.ExecuteNonQuery()

            Next

            ConLibregco.Close()


            'Libregco_Main
            Dstemp.Tables.Clear()
            Dstemp.Clear()
            ConLibregcoMain.Open()
            cmd = New MySqlCommand("SELECT IDMovimientoDetalle,movimientoinventario.IDTipodeAjuste,movimientoinvdetalle.Precio,movimientoinvdetalle.Importe,Movimientoinvdetalle.Cantidad FROM libregco_main.movimientoinvdetalle inner join libregco_main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario where IDTipodeAjuste is not null", ConLibregcoMain)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp, "movimientoinvdetalle")
            ConLibregcoMain.Close()

            ConLibregcoMain.Open()

            lblStatusBar.Text = "Libregco_Main"
            For Each dt As DataRow In Dstemp.Tables("movimientoinvdetalle").Rows
                lblStatusBar.Text = dt.Item("IDMovimientoDetalle").ToString
                sqlQ = "UPDATE Libregco_Main.movimientoinvdetalle Set Cantidad='" + If(dt.Item("IDTipodeAjuste") = 1, CDbl(Math.Abs(dt.Item("Cantidad"))).ToString, -Math.Abs(CDbl(dt.Item("Cantidad"))).ToString).ToString + "',IDTipoAjusteDetalle='" + dt.Item("IDTipodeAjuste").ToString + "',ExistenciaAnterior=0,Precio='" + dt.Item("Precio").ToString + "',Importe='" + If(dt.Item("IDTipodeAjuste") = 1, Math.Abs(CDbl(dt.Item("Importe"))).ToString, -Math.Abs(CDbl(dt.Item("Importe")))).ToString + "' where IDMovimientoDetalle='" + dt.Item("IDMovimientoDetalle").ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConLibregcoMain)
                cmd.ExecuteNonQuery()
            Next

            ConLibregcoMain.Close()

        Catch ex As Exception
            ConLibregco.Close()
            ConLibregcoMain.Close()
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Try
            Dim dsClientes As New DataSet

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDCliente,LimiteCredito FROM Libregco.Clientes", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dsClientes, "Clientes")
            ConLibregco.Close()

            For Each row As DataRow In dsClientes.Tables("Clientes").Rows
                FunctCalcBceGral(row.Item("IDCliente"))
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim Ds As New DataSet

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("Select IDCliente, BalanceGeneral from Libregco.Clientes", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Clientes")

        Dim Tabla As DataTable = Ds.Tables("Clientes")

        For Each row As DataRow In Tabla.Rows
            sqlQ = "UPDATE Libregco.Clientes SET BalanceGeneralLetras='" + ConvertNumbertoString(CDbl(row.Item(1))).ToString + "' WHERE IDCliente='" + row.Item(0).ToString + "'"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
        Next

        Con.Close()

        MessageBox.Show("El proceso ha finalizado satisfactoriamente.", "Proceso finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Dim IDFactura, BceFactura, CargosActualizados, MontoFactura, InicialFactura, NotaDebito, NotaCredito, Devoluciones, Abonos, CargosFactura, AbonosaCargos As New Label
            Dim Ds, Ds1 As New DataSet

            '//Esta operación calcula el balance de todas las facturas válidas de un cliente 
            Con.Open()
            ConMixta.Open()

            Ds.Clear()
            cmd = New MySqlCommand("SELECT IDCliente,Nombre FROM Clientes", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Clientes")

            Dim Cliente As DataTable = Ds.Tables("Clientes")

            For Each Rw As DataRow In Cliente.Rows
                Ds1.Clear()
                cmd = New MySqlCommand("SELECT IDFacturaDatos,NetoFactura FROM" & SysName.Text & "FacturaDatos where IDCliente='" + Rw.Item(0).ToString + "' and FacturaDatos.Nulo=0", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds1, "FacturaDatos")

                '//Lleno las facturas en un dataset para luego calcular fila x fila
                Dim FacturasCliente As DataTable = Ds1.Tables("FacturaDatos")

                For Each DtRow As DataRow In FacturasCliente.Rows
                    '//Asignacion de valores
                    IDFactura.Text = DtRow.Item(0)
                    MontoFactura.Text = DtRow.Item(1)

                    cmd = New MySqlCommand("Select Coalesce(Sum(Aplicado),0) From NotaDebitoCreditoDetalle INNER JOIN NotaDebitoCredito on notadebitocreditodetalle.IDNotaDebitoCredito=NotaDebitoCredito.IDNotaDebCred Where IDTipoNota=2 and IDFactura='" + IDFactura.Text + "' and NotaDebitoCredito.Nulo=0", Con)
                    NotaCredito.Text = Convert.ToDouble(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("Select Coalesce(Sum(Aplicado),0) From NotaDebitoCreditoDetalle INNER JOIN NotaDebitoCredito on notadebitocreditodetalle.IDNotaDebitoCredito=NotaDebitoCredito.IDNotaDebCred Where IDTipoNota=1 and IDFactura='" + IDFactura.Text + "' and NotaDebitoCredito.Nulo=0", Con)
                    NotaDebito.Text = Convert.ToDouble(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("Select Coalesce(Sum(Devolver),0) From" & SysName.Text & "DevolucionVenta INNER JOIN" & SysName.Text & "FacturaDatos on DevolucionVenta.IDFActura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where DevolucionVenta.IDFactura='" + IDFactura.Text + "' and Condicion.Dias>0 and DevolucionVenta.Nulo=0", ConMixta)
                    Devoluciones.Text = Convert.ToDouble(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("Select Coalesce(Sum(DetalleAbonos.Debito+DetalleAbonos.Descuento),0) From DetalleAbonos INNER JOIN Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono Where IDFactura='" + IDFactura.Text + "' and Abonos.Nulo=0", Con)
                    Abonos.Text = Convert.ToDouble(cmd.ExecuteScalar())

                    BceFactura.Text = CDbl(MontoFactura.Text) + CDbl(NotaDebito.Text) - CDbl(NotaCredito.Text) - CDbl(Devoluciones.Text) - CDbl(Abonos.Text)

                    cmd = New MySqlCommand("Select Coalesce(Sum(Monto),0) From CargosFactura Where IDFactura='" + IDFactura.Text + "' and Nulo=0", Con)
                    CargosFactura.Text = Convert.ToDouble(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("Select Coalesce(Sum(Cargos+CargosExcento),0) From DetalleAbonos INNER JOIN Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono Where IDFactura='" + IDFactura.Text + "' and Nulo=0", Con)
                    AbonosaCargos.Text = Convert.ToDouble(cmd.ExecuteScalar())

                    CargosActualizados.Text = CDbl(CargosFactura.Text) - CDbl(AbonosaCargos.Text)

                    sqlQ = "UPDATE FacturaDatos Set Balance='" + BceFactura.Text + "',Cargos='" + CargosActualizados.Text + "',BalanceFacturaLetras='" + ConvertNumbertoString(CDbl(BceFactura.Text)).ToString + "' WHERE IDFacturaDatos='" + IDFactura.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                Next
            Next

            Con.Close()
            ConMixta.Close()

            MessageBox.Show("El proceso ha finalizado satisfactoriamente.", "Proceso finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Ds.Dispose()
            Ds1.Dispose()
        Catch ex As Exception
            Con.Close()
            ConMixta.Close()
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub BWArticulos_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BWArticulos.ProgressChanged
        ProgressBar2.Value = e.ProgressPercentage
        Label19.Text = Math.Round(((ProgressBar2.Value / ProgressBar2.Maximum) * 100), 3) & "%"
    End Sub

    Private Sub BWArticulos_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BWArticulos.RunWorkerCompleted
        If e.Cancelled = True Then
            MessageBox.Show("Se ha detenido el procedimineto.!!")
        Else
            MessageBox.Show("Ha finalizado el procedimiento satisfactoriamente.!")
        End If
    End Sub



    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If frm_toast_divisas_popular.Visible = True Then
            frm_toast_divisas_popular.Activate()
        Else
            frm_toast_divisas_popular.Show(Me)
        End If
    End Sub
End Class