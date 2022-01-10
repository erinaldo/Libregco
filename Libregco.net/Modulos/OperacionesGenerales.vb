Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.Drawing.Drawing2D
Imports CrystalDecisions.Shared
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Net.Mail
Imports System.Net

Module OperacionesGenerales
    Friend HostNameServer, DDNS, UserServer, Port As String
    Friend CnString As String = "database=Libregco;server=" & HostNameServer & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"
    Friend CnString1 As String = "database=Libregco_Main;server=" & HostNameServer & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"
    Friend CnUtilitarios As String = "database=Libregco_Utilitarios;server=" & HostNameServer & ";port=3306;user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"
    Friend CnGeneral As String = "server=" & HostNameServer & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"
    Friend CnAdminLibregco As String = "server=" & DDNS & ";port=" & Port & ";user id=" & UserServer & ";password=iLM14PC1191;sslmode=None"
    Friend Con As New MySqlConnection(CnString) 'Conexión a base de datos seleccionada
    Friend ConLibregco As New MySqlConnection(CnString) 'Conexion a Libregco
    Friend ConLibregcoMain As New MySqlConnection(CnString1) 'Conexion a LibregcoMain                               
    Friend ConMixta As New MySqlConnection(CnGeneral) 'Conexion mixta
    Friend ConErrores As New MySqlConnection(CnString)
    Friend ConTemporal As New MySqlConnection(CnGeneral)
    Private Correos As New MailMessage
    Private Envios As New SmtpClient

    Friend ConUtilitarios As New MySqlConnection(CnUtilitarios) 'Conexión de utilitarios
    Friend ConAdminLib As New MySqlConnection(CnAdminLibregco) 'Conexión a Servidor 
    Friend Sys As Integer = 1

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim CMDErrores As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend NewNCFValue, PathServidor, IDBuild, SysName, TypeConnection As New Label
    Friend NuevaEstructuracion As Boolean = False
    Friend SearchingFast As Boolean = False
    Friend SelectedPathGallery As String
    Friend EmpFastPassword As New DataTable
    Friend TablaTransacciones As DataTable = New DataTable("Transacciones")
    Friend AverageColor As Color
    Friend SysLogo As Image
    Friend BussinessLogo As Image

    ''' <summary>
    ''' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Friend DTConfiguracion As New DataTable
    Friend DTAjustes As New DataTable
    Friend DTEmpleado As New DataTable
    Friend DTEmpresa As New DataTable
    Friend DTAreaImpresion As New DataTable
    Friend DTModulos As New DataTable

    '''' </summary>

    Function GetRandomnumber(ByVal numeroCaracteres As Integer) As String
        Dim rndNumber As String = ""
        Dim rnd As New Random
        For n As Integer = 0 To numeroCaracteres
            rndNumber &= rnd.Next(0, 9)
        Next

        Return rndNumber
    End Function

    Public Function GetDataTable(Query As String, Connection As MySqlConnection) As DataTable
        Connection.Open()
        Dim Dtable As New DataTable
        Dim Adpt As New MySqlDataAdapter

        Adpt.SelectCommand = New MySqlCommand(Query, Con)
        Adpt.Fill(Dtable)

        Connection.Close()

        Return Dtable


    End Function

    Function GenerarCadena(ByVal numeroCaracteres As Integer) As String

        ' Dimensionamos un array para almacenar tanto las 
        ' letras mayúsculas como minúsculas (52 letras). 
        ' 
        Dim letras(51) As String

        ' Rellenamos el array. 
        ' 
        Dim n As Integer
        For item As Int32 = 65 To 90
            letras(n) = Chr(item)
            letras(n + 1) = letras(n).ToLower
            n += 2
        Next

        Dim cadenaAleatoria As String = String.Empty

        ' Iniciamos el generador de números aleatorios 
        ' 
        Dim rnd As New Random(DateTime.Now.Millisecond)

        For n = 0 To numeroCaracteres

            Dim numero As Integer = rnd.Next(0, 51)

            cadenaAleatoria &= letras(numero)

        Next

        Return cadenaAleatoria


    End Function

    Function ContrastReadableIs(ByVal color_1 As Color, ByVal color_2 As Color) As Boolean
        Dim minContrast As Single = 0.5F
        Dim brightness_1 As Single = color_1.GetBrightness()
        Dim brightness_2 As Single = color_2.GetBrightness()

        Return (Math.Abs(brightness_1 - brightness_2) >= minContrast)
    End Function

    Function readNthLine(fileAndPath As String, lineNumber As Integer) As String
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


    Public Function CheckEventosBoleteriaActuales(ByVal IDProveniencia As Integer)
        Dim DsTemp As New DataSet

        ConMixta.Open()

        If IDProveniencia = 1 Then
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT IDEvento,Evento,FechaInicio,FechaTermino,MontoBoleto,CantidadLetras,UltimaSecuencia,HastaSecuencia,AplicaenFact,AplicaEnCobro,Logo,Politicas FROM" & SysName.Text & "eventosboleteria Where FechaTermino>='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' and AplicaenFact=1", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Eventos")
        ElseIf IDProveniencia = 2 Then
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT IDEvento,Evento,FechaInicio,FechaTermino,MontoBoleto,CantidadLetras,UltimaSecuencia,HastaSecuencia,AplicaenFact,AplicaEnCobro,Logo,Politicas FROM" & SysName.Text & "eventosboleteria Where FechaTermino>='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' and AplicaEnCobro=1", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Eventos")
        End If

        ConMixta.Close()

        Dim Tabla As DataTable = DsTemp.Tables("Eventos")

        If Tabla.Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Function GenerateBoletosEventos(ByVal IDProveniente As String, ByVal IDTransaccion As Integer, ByVal Monto As Double, ByVal Nombre As String, ByVal Cedula As String, ByVal Direccion As String, ByVal Telefono As String)
        Try
            Dim DsTemp As New DataSet
            Dim RealValue, ValorDecimalRestante As Decimal
            Dim ValorEntero As Double

            ConMixta.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT IDEvento,Evento,FechaInicio,FechaTermino,MontoBoleto,CantidadLetras,UltimaSecuencia,HastaSecuencia,AplicaenFact,AplicaEnCobro,Logo,Politicas,IDReporte,IDPrinter FROM" & SysName.Text & "eventosboleteria Where FechaTermino>='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Eventos")
            ConMixta.Close()

            Dim Tabla As DataTable = DsTemp.Tables("Eventos")

            For Each Row As DataRow In Tabla.Rows
                If Monto >= CDbl(Row.Item(4)) Then
                    RealValue = CDbl(Monto) / CDbl(Row.Item(4))
                    ValorDecimalRestante = RealValue - Int(RealValue)
                    ValorEntero = RealValue - ValorDecimalRestante

                    ConMixta.Open()

                    sqlQ = "UPDATE" & SysName.Text & "EventosBoleteria Set UltimaSecuencia='" + (CDbl(Row.Item(6)) + ValorEntero).ToString + "' where IDEvento='" + Row.Item(0).ToString + "'"
                    cmd = New MySqlCommand(sqlQ, ConMixta)
                    cmd.ExecuteNonQuery()

                    For i = CDbl(Row.Item(6)) + 1 To (CDbl(Row.Item(6)) + ValorEntero)
                        sqlQ = "INSERT INTO" & SysName.Text & "Boletas (SecondID,IDEvento,IDTransaccion,IDRazonSocial,IDUsuario,IDEquipo,Fecha,Numeracion,NombreBoleto,CedulaBoleto,DireccionBoleto,TelefonoBoleto) VALUES ('" + GenerarCadena(16).ToString + "','" + Row.Item(0).ToString + "','" + IDTransaccion.ToString + "','" + DTEmpresa.Rows(0).Item("IDRazon").ToString + "','" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "','" + CStr(CInt(i)).PadLeft(CInt(Row.Item(5)), "0") + "','" + Nombre.ToString + "','" + Cedula.ToString + "','" + Direccion.ToString + "','" + Telefono.ToString + "')"
                        cmd = New MySqlCommand(sqlQ, ConMixta)
                        cmd.ExecuteNonQuery()
                    Next

                    ConMixta.Close()

                    Dim NewEvent As New frm_impresion_eventos_especiales

                    Dim ExistFile As Boolean = System.IO.File.Exists(Row.Item(10))
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Row.Item(10), FileMode.Open, FileAccess.Read)
                        NewEvent.PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    End If

                    NewEvent.lblEvento.Text = Row.Item(1).ToString.ToUpper
                    NewEvent.lblCantBoletos.Text = ValorEntero
                    NewEvent.FillInstaledPrinters()
                    NewEvent.CbxInstalledPrinters.Text = Tabla.Rows(0).Item("IDPrinter")
                    NewEvent.IDTransaccion = IDTransaccion
                    NewEvent.IDEvento = Row.Item(0)
                    NewEvent.Show()

                    ConMixta.Open()

                    cmd = New MySqlCommand("Select Path from" & SysName.Text & "Reportes where IDReportes='" + Tabla.Rows(0).Item("IDReporte").ToString + "'", ConMixta)
                    NewEvent.ReportPath = Convert.ToString(cmd.ExecuteScalar())
                    ConMixta.Close()

                    MessageBox.Show("Eventos Especiales: " & vbNewLine & Row.Item(1).ToString & vbNewLine & vbNewLine & "Se ha(n) generado " & ValorEntero & " boletos.", "Evento especial", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    If NewEvent.chkImpresionAutomatica.Checked = True Then
                        NewEvent.btnImprimir.PerformClick()
                    End If

                End If
            Next

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & ex.StackTrace & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try
    End Function

    Friend Sub FillEmpFastPassword()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            cmd = New MySqlCommand("SELECT IDEmpleado,0 As Validado from Empleados Where Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Empleados")
            Con.Close()

            EmpFastPassword = DsTemp.Tables("Empleados")


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try

    End Sub

    Public Function SaveEmployeesPassword(ByVal IDEmployee As String)
        For Each Dt As DataRow In EmpFastPassword.Rows
            If IDEmployee = Dt.Item(0) Then
                Dt.Item(1) = 1
            End If
        Next
    End Function

    Public Function LookEmployeesValidated(ByVal IDEmployee As String)
        For Each Dt As DataRow In EmpFastPassword.Rows
            If IDEmployee = Dt.Item(0).ToString Then
                If Dt.Item(1) = 1 Then
                    Return 1
                Else
                    Return 0
                End If
            End If
        Next

    End Function

    Public Function RemoveEmployeesValidated(ByVal IDEmployee As String)
        For Each Dt As DataRow In EmpFastPassword.Rows
            If IDEmployee = Dt.Item(0).ToString Then
                Dt.Item(1) = 0
            End If
        Next
    End Function

    Sub ActoTotal()
        'Try
        'Verifica si la mora esta activada en el sistema
        'Con.Open()
        'cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=23", Con)
        Dim HabMora As String = DTConfiguracion.Rows(23 - 1).Item("Value2Int")
            'Con.Close()

            If HabMora = 1 Then
                CargosFactura()
            End If

            ActualizarDiasPagares()
            GenerarPagosComprasxSolicitud()
            EliminarBitacora()
            GenerateAssistance()

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        'End Try
    End Sub

    Private Sub EliminarBitacora()
        Try
            ConMixta.Open()

            'cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=127", ConMixta)
            Dim CantiDias As Integer = DTConfiguracion.Rows(127 - 1).Item("Value2Int")

            sqlQ = "DELETE FROM" & SysName.Text & "Bitacora WHERE Fecha<Now()- INTERVAL '" + CantiDias.ToString + "' DAY"
            cmd = New MySqlCommand(sqlQ, ConMixta)

            cmd.ExecuteNonQuery()
            ConMixta.Close()

        Catch ex As Exception
            ConMixta.Close()
            Con.Close()
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try

    End Sub

    Sub UpdateMovimientosPagares(ByVal IDPagare As Integer, ByVal IDListado As Integer, ByVal StatusNulo As Integer)

        Con.Open()

        cmd = New MySqlCommand("Select count(IDMovimientoPagare) FROM movimientospagare Where IDListado=" + IDListado.ToString + " And IDPagare='" + IDPagare.ToString + "'", Con)

        If CDbl(Convert.ToString(cmd.ExecuteScalar())) = 0 Then
            sqlQ = "INSERT INTO MovimientosPagare (IDPagare,IDListado,Nulo) VALUES ('" + IDPagare.ToString + "','" + IDListado.ToString + "',0)"
            GuardarDatos()
        Else
            sqlQ = "Update MovimientosPagare Set Nulo='" + StatusNulo.ToString + "' Where IDPagare='" + IDPagare.ToString + "' and IDListado='" + IDListado.ToString + "'"
            GuardarDatos()
        End If

        Con.Close()

    End Sub

    Sub ControldeActualizacionxFecha()
        'Try
        'Con.Open()
        '    cmd = New MySqlCommand("Select Value1Var from Configuracion where IDConfiguracion=18", Con)
        'UltimaeFechaActualizada = Convert.ToString(cmd.ExecuteScalar())
        'Con.Close()

        If DTConfiguracion.Rows(18 - 1).Item("Value1Var").ToString = "" Then
            Con.Open()
            sqlQ = "Update Configuracion Set Value1Var='" + Today.ToString("yyyy-MM-dd") + "' Where IDConfiguracion=18"
            GuardarDatos()
            Con.Close()
            ActoTotal()
        Else
            If CDate(DTConfiguracion.Rows(18 - 1).Item("Value1Var").ToString) < Today Then
                Con.Open()
                sqlQ = "Update Configuracion Set Value1Var='" + Today.ToString("yyyy-MM-dd") + "' Where IDConfiguracion=18"
                GuardarDatos()
                Con.Close()
                ActoTotal()
            End If
        End If

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        'End Try

    End Sub

    Sub CargosFactura()
        'Try
        ConMixta.Open()

            'Cargos los tipos de monedas del sistema
            Dim dsTemp As New DataSet
            cmd = New MySqlCommand("SELECT IDTipoMoneda,Moneda,Signo FROM libregco.tipomoneda ORDER BY IDTipoMoneda ASC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dsTemp, "tipomoneda")

            For Each RowMoney As DataRow In dsTemp.Tables(0).Rows
                'Cargo el interes mensual
                Dim Interes As Double = DTConfiguracion.Rows(3 - 1).Item("Value3Double")

                'Cargo el tipo de agrupacion de los cargos
                Dim Agrupacion As Integer = DTConfiguracion.Rows(120 - 1).Item("Value2Int")

                Dim dstmp As New DataSet
                cmd = New MySqlCommand("SELECT IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.NombreFactura,DATEDIFF(now(),FacturaDatos.FechaVencimiento) as DiasVencidos,Cargos,Balance,FacturaDatos.IDCliente,if((Select count(*) from" & SysName.Text & "CargosFactura Where CargosFactura.IDFactura=FacturaDatos.IDFacturaDatos)=1,(Select IDCargosFactura from" & SysName.Text & "CargosFactura Where CargosFactura.IDFactura=FacturaDatos.IDFacturaDatos),0) as HaveCargosInserted,(Select Coalesce(Sum(DetalleAbonos.Cargos+DetalleAbonos.CargosExcento),0) From" & SysName.Text & "DetalleAbonos INNER JOIN" & SysName.Text & "Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono Where DetalleAbonos.IDFactura=FacturaDatos.IDFacturaDatos AND Abonos.Nulo=0) as CargosPagados from" & SysName.Text & "FacturaDatos INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where Transaccion.IDMoneda='" + RowMoney.Item("IDTipoMoneda").ToString + "' and FechaVencimiento<='" + Today.ToString("yyyy-MM-dd") + "' and FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and GenerarCargo=1 ORDER BY FacturaDatos.Cargos desc", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(dstmp, "FacturaDatos")

                For Each DtRow As DataRow In dstmp.Tables("FacturaDatos").Rows
                    Dim Cargos As Double = CDbl(CDbl(DtRow.Item("DiasVencidos")) * CDbl(Interes)) * CDbl(DtRow.Item("Balance"))

                    If CInt(DtRow.Item("HaveCargosInserted")) = 0 Then
                        cmd = New MySqlCommand("INSERT INTO" & SysName.Text & "CargosFactura (Fecha,Hora,BceAnterior,IDFactura,Monto,Nulo,NCF,Descripcion,Type) VALUES ('" + Today.ToString("yyyy-MM-dd") + "','" + Now.ToString("HH:mm:ss") + "','" + CDbl(DtRow.Item("Balance")).ToString + "','" + DtRow.Item("IDFacturaDatos").ToString + "','" + Cargos.ToString + "',0,'','" + "Cargos acumulados al " & Now.ToShortDateString + "',0)", ConMixta)
                        cmd.ExecuteNonQuery()
                    Else
                        cmd = New MySqlCommand("UPDATE" & SysName.Text & "CargosFactura Set Fecha='" + Today.ToString("yyyy-MM-dd") + "',Hora='" + Now.ToString("HH:mm:ss") + "',BceAnterior='" + CDbl(DtRow.Item("Balance")).ToString + "',Monto='" + Cargos.ToString + "',Descripcion='" + "Cargos acumulados al " & Now.ToShortDateString + "' WHERE IDCargosFactura='" + DtRow.Item("HaveCargosInserted").ToString + "'", ConMixta)
                        cmd.ExecuteNonQuery()
                    End If

                    cmd = New MySqlCommand("Select Coalesce(Sum(Cargos+CargosExcento),0) From" & SysName.Text & "DetalleAbonos INNER JOIN" & SysName.Text & "Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono Where IDFactura='" + DtRow.Item("IDFacturaDatos").ToString + "' AND Abonos.Nulo=0", ConMixta)
                    Dim CargosPagados As Double = Convert.ToDouble(cmd.ExecuteScalar())


                    Dim CargosCompuestos As Double = Cargos - CargosPagados
                    cmd = New MySqlCommand("UPDATE" & SysName.Text & "FacturaDatos Set DiasVencidos='" + DtRow.Item("DiasVencidos").ToString + "',Cargos='" + CargosCompuestos.ToString + "' WHERE IDFacturaDatos='" + DtRow.Item("IDFacturaDatos").ToString + "'", ConMixta)
                    cmd.ExecuteNonQuery()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    cmd = New MySqlCommand("SELECT Coalesce(Sum(Cargos),0) from Libregco.FacturaDatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.IDCliente='" + DtRow.Item("IDCliente").ToString + "' and Transaccion.IDMoneda='" + RowMoney.Item("IDTipoMoneda").ToString + "' and FacturaDatos.Balance>0 and FacturaDatos.Nulo=0", ConMixta)
                    Dim BceCargosZ As Double = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("SELECT Coalesce(Sum(Cargos),0) from Libregco_Main.FacturaDatos INNER JOIN Libregco_Main.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.IDCliente='" + DtRow.Item("IDCliente").ToString + "' and Transaccion.IDMoneda='" + RowMoney.Item("IDTipoMoneda").ToString + "' and FacturaDatos.Balance>0 and FacturaDatos.Nulo=0", ConMixta)
                Dim BceCargosa As Double = Convert.ToDouble(cmd.ExecuteScalar())

                    cmd = New MySqlCommand("UPDATE Libregco.Clientes_balances Set CargosGeneral='" + Math.Round(BceCargosZ + BceCargosa, 3).ToString + "' WHERE IDCliente='" + DtRow.Item("IDCliente").ToString + "' and IDMoneda='" + RowMoney.Item("IDTipoMoneda").ToString + "'", ConMixta)
                    cmd.ExecuteNonQuery()
                Next
            Next

            ConMixta.Close()

        'Try
        '    Dim lblIDFactura, lblFechaVencimiento, lblDiasVencidos, lblNuevoCargo, lblCargosCompuesto, lblNetoFactura, lblBalance As New Label
        '    Dim NuevosDiasVencidos As Integer
        '    Dim FechaVecyDias As Date

        '    ConMixta.Open()

        '    'Cargo el interes mensual
        '    Dim Interes As Double = DTConfiguracion.Rows(3 - 1).Item("Value3Double")

        '    'Cargo el tipo de agrupacion de los cargos
        '    Dim Agrupacion As Integer = DTConfiguracion.Rows(120 - 1).Item("Value2Int")

        '    'Cargos los tipos de monedas del sistema
        '    Dim dsTemp As New DataSet
        '    cmd = New MySqlCommand("SELECT IDTipoMoneda,Moneda,Signo FROM libregco.tipomoneda ORDER BY IDTipoMoneda ASC", ConMixta)
        '    Adaptador = New MySqlDataAdapter(cmd)
        '    Adaptador.Fill(dsTemp, "tipomoneda")

        '    For Each Row As DataRow In dsTemp.Tables(0).Rows
        '        Ds.Clear()
        '        cmd = New MySqlCommand("SELECT IDFacturaDatos,FechaVencimiento,DiasVencidos,Cargos,Balance,GenerarCargo,FacturaDatos.IDCliente from" & SysName.Text & "FacturaDatos INNER JOIN" & SysName.Text & "Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where Transaccion.IDMoneda='" + Row.Item("IDTipoMoneda").ToString + "' and FechaVencimiento<='" + Today.ToString("yyyy-MM-dd") + "' and Balance>0 and Nulo=0 and GenerarCargo=1", ConMixta)
        '        Adaptador = New MySqlDataAdapter(cmd)
        '        Adaptador.Fill(Ds, "FacturaDatos")

        '        Dim SumCargos, SumPagoCargos As Double

        '        For Each DtRow As DataRow In Ds.Tables("FacturaDatos").Rows
        '            lblIDFactura.Text = DtRow.Item("IDFacturaDatos")
        '            lblFechaVencimiento.Text = CDate(DtRow.Item("FechaVencimiento")).ToString("yyyy-MM-dd")
        '            lblDiasVencidos.Text = DtRow.Item("DiasVencidos")
        '            lblBalance.Text = DtRow.Item("Balance")

        '            FechaVecyDias = DateAdd("d", CDbl(lblDiasVencidos.Text), CDate(lblFechaVencimiento.Text))           'Establezco el parametro de la feha de vencimiento. Calcula la fecha de vencimiento mas lo dias vencidos

        '            If CDate(FechaVecyDias.ToShortDateString) < Today Then   'Si la fecha conseguida es menor a hoy, entonces se establece cuantos dias hay de diferencia
        '                NuevosDiasVencidos = DateDiff(DateInterval.Day, FechaVecyDias, Today)
        '                lblDiasVencidos.Text = CInt(lblDiasVencidos.Text) + NuevosDiasVencidos      'Los dias vencidos son igual a los que ya estaban mas lo nuevos dias vencidos
        '                lblNuevoCargo.Text = Math.Round((CDbl(lblBalance.Text) * Interes * NuevosDiasVencidos), 2)   'Se suman los nuevos cargos a los cargos ya existentes

        '                sqlQ = "INSERT INTO" & SysName.Text & "CargosFactura (Fecha,Hora,BceAnterior,IDFactura,Monto,Nulo,NCF,Descripcion,Type) VALUES ('" + Today.ToString("yyyy-MM-dd") + "','" + Now.ToString("HH:mm:ss") + "','" + lblBalance.Text + "','" + lblIDFactura.Text + "','" + lblNuevoCargo.Text + "',0,'','" + "Cargos aplicados del " & FechaVecyDias.ToShortDateString & " al " & Today.ToShortDateString + "',0)"
        '                cmd = New MySqlCommand(sqlQ, ConMixta)
        '                cmd.ExecuteNonQuery()

        '                'Agrupacion de cargos unicos
        '                If Agrupacion = 1 Then
        '                    cmd = New MySqlCommand("SELECT Coalesce(Sum(Monto),0) FROM" & SysName.Text & "cargosfactura Where cargosfactura.IDFactura='" + lblIDFactura.Text + "' and cargosfactura.Nulo=0 group by IDFactura ASC", ConMixta)
        '                    SumCargos = Convert.ToDouble(cmd.ExecuteScalar())

        '                    sqlQ = "Delete from" & SysName.Text & "CargosFactura Where IDFactura = (" + lblIDFactura.Text + ") and Type=0"
        '                    cmd = New MySqlCommand(sqlQ, ConMixta)
        '                    cmd.ExecuteNonQuery()

        '                    sqlQ = "INSERT INTO" & SysName.Text & "CargosFactura (Fecha,Hora,BceAnterior,IDFactura,Monto,Nulo,NCF,Descripcion,Type) VALUES ('" + Today.ToString("yyyy-MM-dd") + "','" + Now.ToString("HH:mm:ss") + "','" + lblBalance.Text + "','" + lblIDFactura.Text + "','" + SumCargos.ToString + "',0,'','" + "Cargos acumulados al " & FechaVecyDias.ToShortDateString + "',0)"
        '                    cmd = New MySqlCommand(sqlQ, ConMixta)
        '                    cmd.ExecuteNonQuery()
        '                End If

        '                cmd = New MySqlCommand("SELECT Coalesce(Sum(Monto),0) FROM" & SysName.Text & "cargosfactura Where IDFactura='" + lblIDFactura.Text + "' AND CargosFactura.Nulo=0", ConMixta)
        '                SumCargos = Convert.ToDouble(cmd.ExecuteScalar())

        '                cmd = New MySqlCommand("Select Coalesce(Sum(Cargos+CargosExcento),0) From" & SysName.Text & "DetalleAbonos INNER JOIN" & SysName.Text & "Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono Where IDFactura='" + lblIDFactura.Text + "' AND Abonos.Nulo=0", ConMixta)
        '                SumPagoCargos = Convert.ToDouble(cmd.ExecuteScalar())

        '                lblCargosCompuesto.Text = SumCargos - SumPagoCargos

        '                sqlQ = "UPDATE" & SysName.Text & "FacturaDatos Set DiasVencidos='" + lblDiasVencidos.Text + "',Cargos='" + lblCargosCompuesto.Text + "' WHERE IDFacturaDatos='" + lblIDFactura.Text + "'"
        '                cmd = New MySqlCommand(sqlQ, ConMixta)
        '                cmd.ExecuteNonQuery()

        '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '                cmd = New MySqlCommand("SELECT Coalesce(Sum(Cargos),0) from Libregco.FacturaDatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.IDCliente='" + DtRow.Item("IDCliente").ToString + "' and Transaccion.IDMoneda='" + Row.Item("IDTipoMoneda").ToString + "' and FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 ", ConMixta)
        '                Dim BceCargosZ As Double = Convert.ToDouble(cmd.ExecuteScalar())

        '                cmd = New MySqlCommand("SELECT Coalesce(Sum(Cargos),0) from Libregco_Main.FacturaDatos INNER JOIN Libregco_Main.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.IDCliente='" + DtRow.Item("IDCliente").ToString + "' and Transaccion.IDMoneda='" + Row.Item("IDTipoMoneda").ToString + "' and FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 ", ConMixta)
        '                Dim BceCargosa As Double = Convert.ToDouble(cmd.ExecuteScalar())

        '                sqlQ = "UPDATE Libregco.Clientes_balances Set CargosGeneral='" + Math.Round(BceCargosZ + BceCargosa, 3).ToString + "' WHERE IDCliente='" + DtRow.Item("IDCliente").ToString + "' and IDMoneda='" + Row.Item("IDTipoMoneda").ToString + "'"
        '                cmd = New MySqlCommand(sqlQ, ConMixta)
        '                cmd.ExecuteNonQuery()
        '            End If

        '        Next

        '    Next

        '    ConMixta.Close()

        '    AgruparCargosFactura()

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        'End Try
    End Sub

    Sub AgruparCargosFactura()
        'Try
        '    ConMixta.Open()

        '    'cmd = New MySqlCommand("SELECT Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=120", ConMixta)
        '    ''Dim Agrupacion As Integer = Convert.ToInt16(cmd.ExecuteScalar())

        '    If CInt(DTConfiguracion.Rows(120 - 1).Item("Value2Int")) = 0 Then
        '        If IsDate(DTConfiguracion.Rows(18 - 1).Item("Value1Var").ToString) Then
        '            If CDate(DTConfiguracion.Rows(18 - 1).Item("Value1Var").ToString).Month <> Today.Month Then
        '                Dim MonthSt As String = MonthName(Month(Today.AddMonths(-1)))
        '                Dim DsTmp As New DataSet

        '                'cmd = New MySqlCommand("SELECT Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=121", ConMixta)
        '                'Dim NCFMensual As Integer = Convert.ToInt16(cmd.ExecuteScalar())

        '                cmd = New MySqlCommand("SELECT IDCargosFactura,Type,cargosfactura.Fecha,cargosfactura.Hora,IDFactura,cargosfactura.BceAnterior,sum(Monto) as CargosSumados,cargosfactura.NCF,Descripcion,cargosfactura.Nulo,FacturaDatos.Balance FROM" & SysName.Text & "cargosfactura INNER JOIN" & SysName.Text & "FacturaDatos on CargosFactura.IDFactura=FacturaDatos.IDFacturaDatos WHERE YEAR(cargosfactura.Fecha)=YEAR(NOW()) AND MONTH(cargosfactura.Fecha)='" + Month(Today.AddMonths(-1)).ToString + "' AND FacturaDatos.Balance>0 and Type=0 and cargosfactura.Nulo=0 GROUP BY YEAR(cargosfactura.Fecha), MONTH(cargosfactura.Fecha), IDFactura asc", ConMixta)
        '                Adaptador = New MySqlDataAdapter(cmd)
        '                Adaptador.Fill(DsTmp, "Cargos")

        '                Dim Tabla As DataTable = DsTmp.Tables("Cargos")

        '                For Each Row As DataRow In Tabla.Rows
        '                    If CInt(DTConfiguracion.Rows(121 - 1).Item("Value2Int")) = 0 Then
        '                        sqlQ = "INSERT INTO" & SysName.Text & "CargosFactura (Fecha,Hora,BceAnterior,IDFactura,Monto,Nulo,NCF,Descripcion,Type) VALUES ('" + Today.AddDays(-1).ToString("yyyy-MM-dd") + "','" + Now.ToString("23:59:59") + "','" + Row.Item(10).ToString + "','" + Row.Item(4).ToString + "','" + Row.Item(6).ToString + "',0,'','" + "Cargos aplicados en el mes " & MonthSt.ToLower.ToString & " del " & Today.Year.ToString + "',1)"
        '                        cmd = New MySqlCommand(sqlQ, ConMixta)
        '                        cmd.ExecuteNonQuery()
        '                    Else
        '                        sqlQ = "INSERT INTO" & SysName.Text & "CargosFactura (Fecha,Hora,BceAnterior,IDFactura,Monto,Nulo,NCF,Descripcion,Type) VALUES ('" + Today.AddDays(-1).ToString("yyyy-MM-dd") + "','" + Now.ToString("23:59:59") + "','" + Row.Item(10).ToString + "','" + Row.Item(4).ToString + "','" + Row.Item(6).ToString + "',0,'" + GetNCFsNumbers(2).ToString + "','" + "Cargos aplicados en el mes " & MonthSt.ToLower.ToString & " del " & Today.Year.ToString + "',1)"
        '                        cmd = New MySqlCommand(sqlQ, ConMixta)
        '                        cmd.ExecuteNonQuery()
        '                    End If

        '                    sqlQ = "Delete from" & SysName.Text & "CargosFactura Where IDFactura = (" + Row.Item(4).ToString + ") and Type=0 And MONTH(cargosfactura.Fecha)='" + Month(Today.AddMonths(-1)).ToString + "'"
        '                    cmd = New MySqlCommand(sqlQ, ConMixta)
        '                    cmd.ExecuteNonQuery()
        '                Next
        '            End If
        '        End If

        '    End If

        '    ConMixta.Close()
        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        'End Try
    End Sub


    Sub ActualizarDiasPagares()
        Con.Open()
        Ds.Clear()
        cmd = New MySqlCommand("SELECT IDPagare,if(Pagares.FechaVencimiento<Now(),DATEDIFF(now(),Pagares.FechaVencimiento),0) as DiasVencidos FROM libregco.Pagares WHERE Pagares.Balance>0 and FechaVencimiento<Now()", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Pagares")

        Dim Tabla As DataTable = Ds.Tables("Pagares")

        For Each row As DataRow In Tabla.Rows
            sqlQ = "UPDATE Pagares Set DiasVencidos='" + row.Item("DiasVencidos").ToString + "' WHERE IDPagare='" + row.Item("IDPagare").ToString + "'"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
        Next

        Con.Close()
    End Sub

    Private Sub GuardarDatos()
        Try
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try

    End Sub

    Sub StatusConexion()
        MessageBox.Show("Estado de conexión" & vbNewLine & vbNewLine & vbNewLine & "Con State: " & Con.State.ToString & vbNewLine & "ConMixta State: " & ConMixta.State.ToString & vbNewLine & "ConLibregco State: " & ConLibregco.State.ToString & vbNewLine & "ConLibregcoMain State: " & ConLibregcoMain.State.ToString)
    End Sub

    Sub RealizarBackup()
        Try
            'Realizacion de Copia de Seguridad
            Dim StrDir, StrHost, strUser, strPass, strDbName, strPath As String
            Dim DaysToDelete As Integer
            Dim newDBName As String = Today.ToString("ddMMyyyy") & TimeOfDay.ToString("hhmmss") & ".sql"

            Con.Open()

            'Ruta Mysqldump.exe
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=29", Con)
            StrDir = Convert.ToString(cmd.ExecuteScalar())

            'Nombre Database
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=33", Con)
            strDbName = Convert.ToString(cmd.ExecuteScalar())

            'Host Database
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=30", Con)
            StrHost = Convert.ToString(cmd.ExecuteScalar())

            'User Database
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=31", Con)
            strUser = Convert.ToString(cmd.ExecuteScalar())

            'Password Database
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=32", Con)
            strPass = Convert.ToString(cmd.ExecuteScalar())

            'Localizacion de Backups
            cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=34", Con)
            strPath = "\\" & PathServidor.Text & Convert.ToString(cmd.ExecuteScalar())

            'Dias Eliminado
            cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=35", Con)
            DaysToDelete = Convert.ToInt16(cmd.ExecuteScalar())

            Con.Close()

            Process.Start(StrDir, " -h " & StrHost & " -u " & strUser & " -p" & strPass & " " & "--databases Libregco Libregco_Main" & " -r " & strPath & newDBName)

            EliminarArchivos()
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try
    End Sub

    Sub EliminarArchivos()
        'Realizacion de Copia de Seguridad
        Dim StrPath As String
        Dim DaysToDelete As Integer

        Con.Open()
        'Localizacion de Backups
        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=34", Con)
        StrPath = Convert.ToString(cmd.ExecuteScalar())

        'Dias Eliminado
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=35", Con)
        DaysToDelete = Convert.ToInt16(cmd.ExecuteScalar())

        Con.Close()

        'Eliminado de Archivos 
        For Each Archivo As String In My.Computer.FileSystem.GetFiles(StrPath, FileIO.SearchOption.SearchTopLevelOnly)
            Dim FechaArchivo As DateTime = My.Computer.FileSystem.GetFileInfo(Archivo).LastWriteTime
            Dim Diferencia = DateDiff(DateInterval.Day, FechaArchivo, DateTime.Now)

            If Diferencia > DaysToDelete Then
                File.Delete(Archivo)
            End If
        Next
    End Sub

    Public Function Validar_Mail(ByVal sMail As String) As Boolean
        'Retorna true o false   
        Return Regex.IsMatch(sMail, "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")
    End Function

    Public Function Validar_Password(ByVal sPassword As String) As Boolean
        'Retorna true o false   
        Return Regex.IsMatch(sPassword, "^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15}$")
    End Function

    Friend Function GetAverageColor(ByVal imageFilePath As String) As Color
        Try
            Dim bmp As New Bitmap(imageFilePath)
            Dim totalR As Integer = 0
            Dim totalG As Integer = 0
            Dim totalB As Integer = 0
            For x As Integer = 0 To bmp.Width - 1
                For y As Integer = 0 To bmp.Height - 1
                    Dim pixel As Color = bmp.GetPixel(x, y)
                    totalR += pixel.R
                    totalG += pixel.G
                    totalB += pixel.B
                Next
            Next
            Dim totalPixels As Integer = bmp.Height * bmp.Width
            Dim averageR As Integer = totalR \ totalPixels
            Dim averageg As Integer = totalG \ totalPixels
            Dim averageb As Integer = totalB \ totalPixels
            Return Color.FromArgb(averageR, averageg, averageb)
        Catch ex As Exception

        End Try

    End Function

    Function PasarPermisos(ByVal IDForm As Integer) As Object
        Try
            Dim PermisosOtorgados As New ArrayList
            Dim lblIDForm As New Label

            If NuevaEstructuracion = False Then
                lblIDForm.Text = IDForm

                'Inserto a la bitacora el acceso
                sqlQ = "INSERT INTO Bitacora (IDEmpleado,IDEquipo,Fecha,IDPermiso) VALUES ('" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + Today.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "','" + lblIDForm.Text + "')"
                Con.Open()
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
                Con.Close()


                'Busco los permisos otorgados del formulario
                Con.Open()
                Ds.Clear()
                cmd = New MySqlCommand("SELECT IDPermisoEmpleado,IDEmpleado,IDPermiso,Acceso,Crear,Modificar,Imprimir FROM permisosempleados Where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "' and IDPermiso='" + lblIDForm.Text + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Permisos")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("Permisos")

                PermisosOtorgados.Add(Tabla.Rows(0).Item("Acceso"))
                PermisosOtorgados.Add(Tabla.Rows(0).Item("Crear"))
                PermisosOtorgados.Add(Tabla.Rows(0).Item("Modificar"))
                PermisosOtorgados.Add(Tabla.Rows(0).Item("Imprimir"))

                Return PermisosOtorgados

                '0 Acceso
                '1 Crear
                '2 Modificar
                '3 Imprimir

            Else
                PermisosOtorgados.Add(1)
                PermisosOtorgados.Add(1)
                PermisosOtorgados.Add(1)
                PermisosOtorgados.Add(1)

                Return PermisosOtorgados

            End If

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Function


    Function FunctCalcBcesFactSuplidor(ByVal IDSuplidor As Integer, ByVal Optional ReturnScripts As Boolean = False)
        Try
            Dim ScriptFormula As String
            Dim IDCompra, BceFactura, MontoFactura, NotaDebito, NotaCredito, Devoluciones, Abonos, Contado As New Label

            ConMixta.Open()
            Ds.Clear()
            cmd = New MySqlCommand("SELECT IDCompra,TotalNeto,Dias,Suplidor.Suplidor,Compras.SecondID FROM" & SysName.Text & "Compras INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor where Compras.IDSuplidor='" + IDSuplidor.ToString + "' and Compras.Nulo=0", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Compras")

            Dim TablaCompras As DataTable = Ds.Tables("Compras")

            If TablaCompras.Rows.Count > 0 Then
                If ReturnScripts = True Then
                    ScriptFormula = "SUPLIDOR: " & TablaCompras.Rows(0).Item("Suplidor").ToString.ToUpper & vbNewLine
                End If
            End If

            For Each Row As DataRow In TablaCompras.Rows
                IDCompra.Text = Row.Item("IDCompra")

                If ReturnScripts = True Then
                    ScriptFormula = ScriptFormula & vbNewLine & "ID Transacción: " & IDCompra.Text & " / " & Row.Item("SecondID") & vbNewLine & "--------------------------------------------------------------------------------------------"
                End If

                MontoFactura.Text = Row.Item("TotalNeto")

                If ReturnScripts = True Then
                    ScriptFormula = ScriptFormula & vbNewLine & "Total Factura: " & MontoFactura.Text
                End If

                If CDbl(Row.Item("Dias")) = 0 Then
                    Contado.Text = Row.Item("TotalNeto")
                Else
                    Contado.Text = 0
                End If

                cmd = New MySqlCommand("Select Coalesce(Sum(Aplicado),0) From" & SysName.Text & "NotaDebitoCreditocxpDetalle INNER JOIN" & SysName.Text & "NotaDebitoCreditocxp on notadebitocreditocxpdetalle.IDNotaDebitoCreditocxp=NotaDebitoCreditocxp.IDNotaDebitoCreditocxp Where IDNCF=4 and IDCompra='" + IDCompra.Text + "' and NotaDebitoCreditocxp.Nulo=0", ConMixta)
                NotaCredito.Text = Convert.ToDouble(cmd.ExecuteScalar())

                If ReturnScripts = True Then
                    ScriptFormula = ScriptFormula & vbNewLine & "Notas de crédito: " & NotaCredito.Text
                End If

                cmd = New MySqlCommand("Select Coalesce(Sum(Aplicado),0) From" & SysName.Text & "NotaDebitoCreditocxpDetalle INNER JOIN" & SysName.Text & "NotaDebitoCreditocxp on notadebitocreditocxpdetalle.IDNotaDebitoCreditocxp=NotaDebitoCreditocxp.IDNotaDebitoCreditocxp Where IDNCF=3 and IDCompra='" + IDCompra.Text + "' and NotaDebitoCreditocxp.Nulo=0", ConMixta)
                NotaDebito.Text = Convert.ToDouble(cmd.ExecuteScalar())

                If ReturnScripts = True Then
                    ScriptFormula = ScriptFormula & vbNewLine & "Notas de débito: " & NotaDebito.Text
                End If


                cmd = New MySqlCommand("Select Coalesce(Sum(Devolver),0) From" & SysName.Text & "DevolucionCompra Where IDFactura='" + IDCompra.Text + "' and Nulo=0", ConMixta)
                Devoluciones.Text = Convert.ToDouble(cmd.ExecuteScalar())

                If ReturnScripts = True Then
                    ScriptFormula = ScriptFormula & vbNewLine & "Devoluciones: " & Devoluciones.Text
                End If

                cmd = New MySqlCommand("Select Coalesce(Sum(PagoComprasDetalle.Aplicado+PagoComprasDetalle.Descuento),0) From" & SysName.Text & "pagocomprasdetalle INNER JOIN" & SysName.Text & "PagoCompra on PagoComprasDetalle.IDPagoCompra=PagoCompra.IDPagoCompra Where IDCompra='" + IDCompra.Text + "' and PagoCompra.Nulo=0", ConMixta)
                Abonos.Text = Convert.ToDouble(cmd.ExecuteScalar())

                If ReturnScripts = True Then
                    ScriptFormula = ScriptFormula & vbNewLine & "Abonos: " & Abonos.Text
                End If

                BceFactura.Text = Math.Round(CDbl(MontoFactura.Text), 4) - Math.Round(CDbl(Contado.Text), 4) + Math.Round(CDbl(NotaDebito.Text), 4) - Math.Round(CDbl(NotaCredito.Text), 4) - Math.Round(CDbl(Devoluciones.Text), 4) - Math.Round(CDbl(Abonos.Text), 4)

                If CDbl(BceFactura.Text) < 0.1 Then
                    BceFactura.Text = 0
                End If

                If ReturnScripts = True Then
                    ScriptFormula = ScriptFormula & vbNewLine & "Balance: " & Math.Round(CDbl(BceFactura.Text), 2).ToString & vbNewLine & "--------------------------------------------------------------------------------------------"
                End If

                sqlQ = "UPDATE" & SysName.Text & "Compras Set Balance='" + Math.Round(CDbl(BceFactura.Text), 2).ToString + "' WHERE IDCompra='" + IDCompra.Text + "'"
                cmd = New MySqlCommand(sqlQ, ConMixta)
                cmd.ExecuteNonQuery()
            Next

            ConMixta.Close()


            If ReturnScripts = True Then
                If frm_scriptformula.Visible = True Then
                    frm_scriptformula.Close()
                End If
                frm_scriptformula.Show()
                frm_scriptformula.RichTextBox1.Text = ScriptFormula
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try
    End Function

    Function FunctCalcBcesEmpleados(ByVal IDEmpleado As Integer)
        Try

            Dim IDPrestamo, MontoPrestamo, MontoPago As New Label

            Con.Open()
            Ds.Clear()
            cmd = New MySqlCommand("SELECT IDPrestamosEmp,Monto,IDEmpleado FROM prestamosemp where IDEmpleado='" + IDEmpleado.ToString + "' and Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "prestamosemp")

            '//Lleno las facturas en un dataset para luego calcular fila x fila
            Dim TablaPrestamos As DataTable = Ds.Tables("prestamosemp")

            For Each Row As DataRow In TablaPrestamos.Rows
                IDPrestamo.Text = Row.Item("IDPrestamosEmp")
                MontoPrestamo.Text = Row.Item("Monto")

                cmd = New MySqlCommand("Select Coalesce(Sum(Aplicado),0) From abprestempdetalle INNER JOIN AbPrestemp on AbPrestempDetalle.IDAbPrestEmp=AbPrestemp.IDAbonoPrestamosEmp where AbPresTemp.Nulo=0 and AbPrestempdetalle.IDPrestamoEmp='" + IDPrestamo.Text + "'", Con)
                MontoPago.Text = Convert.ToDouble(cmd.ExecuteScalar())

                MontoPrestamo.Text = CDbl(MontoPrestamo.Text) - CDbl(MontoPago.Text)
                sqlQ = "UPDATE Prestamosemp Set Balance='" + MontoPrestamo.Text + "' WHERE IDPrestamosEmp='" + IDPrestamo.Text + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
            Next

            cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From PrestamosEmp where PrestamosEmp.Nulo=0 and PrestamosEmp.IDEmpleado='" + IDEmpleado.ToString + "'", Con)
            MontoPrestamo.Text = Convert.ToDouble(cmd.ExecuteScalar())

            sqlQ = "UPDATE Empleados Set Balance='" + MontoPrestamo.Text + "' WHERE IDEmpleado='" + IDEmpleado.ToString + "'"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()


        Catch ex As Exception

        End Try
    End Function

    Function IsFinanciamientoModifiable(ByVal IDFinanciamiento As String) As Boolean
        Try
            If IDFinanciamiento = "" Then
                Return True

            Else
                Dim Counter, Pagos As New Label

                Con.Open()

                cmd = New MySqlCommand("SELECT count(idPagosFinanciamientos) FROM pagosfinanciamientos where IDFinanciamiento='" + IDFinanciamiento + "' and Nulo=0", Con)
                Pagos.Text = Convert.ToDouble(cmd.ExecuteScalar())

                Con.Close()

                Counter.Text = Pagos.Text

                If Counter.Text > 0 Then
                    Return False
                Else
                    Return True
                End If

            End If
        Catch ex As Exception

        End Try
    End Function
    Function IsModifiable(ByVal IDFactura As String) As Boolean
        Try
            If IDFactura = "" Then
                Return True

            Else
                Dim Counter, NotasCreditos, Devoluciones, Abonos, Recibos, Conduces, Cargos As Double

                Con.Open()

                cmd = New MySqlCommand("Select Count(IDNotaDetalle) From NotaDebitoCreditoDetalle Inner join NotaDebitoCredito on NotaDebitoCreditoDetalle.IDNotaDebitoCredito=NotaDebitoCredito.IDNotaDebCred where IDFactura='" + IDFactura.ToString + "' and NotaDebitoCredito.Nulo=0", Con)
                NotasCreditos = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("SELECT count(IDDevolucionVenta) FROM devolucionventa where IDFactura='" + IDFactura.ToString + "' and Nulo=0", Con)
                Devoluciones = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("SELECT count(IDDetalleAbono) FROM detalleabonos INNER JOIN Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono where IDFactura='" + IDFactura.ToString + "' and Abonos.Nulo=0", Con)
                Abonos = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("Select count(IDCargosFactura) From CargosFactura Where IDFactura='" + IDFactura.ToString + "' and Nulo=0", Con)
                Cargos = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("SELECT count(IDDetalleRecibo) FROM recibosdetalle INNER JOIN Pagares on RecibosDEtalle.IDPagare=Pagares.IDPagare Where IDFactura='" + IDFactura.ToString + "'", Con)
                Recibos = Convert.ToDouble(cmd.ExecuteScalar())

                cmd = New MySqlCommand("SELECT COUNT(IDConduceDetalle) FROM conducedetalle INNER JOIN Conduce on conducedetalle.IDConduce=ConduceDetalle.IDConduce INNER JOIN FacturaArticulos on ConduceDetalle.IDFactart=FacturaArticulos.IDFactArt INNER JOIN FacturaDatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos Where FacturaDatos.IDFacturaDatos='" + IDFactura.ToString + "' and Conduce.Nulo=0", Con)
                Conduces = Convert.ToDouble(cmd.ExecuteScalar())

                Con.Close()

                Counter = CDbl(NotasCreditos) + CDbl(Devoluciones) + CDbl(Abonos) + CDbl(Recibos) + CDbl(Conduces) + CDbl(Cargos)

                If Counter > 0 Then
                    Return False
                Else
                    Return True
                End If
            End If

        Catch ex As Exception

        End Try
    End Function

    Function GetSecondID(ByVal IDTipoDocumento As String)
        Dim Connon As New MySqlConnection(CnGeneral)

        Connon.Open()
        Ds.Clear()
        cmd = New MySqlCommand("SELECT * FROM" & SysName.Text & "TipoDocumento WHERE IDTipoDocumento='" + IDTipoDocumento.ToString + "'", Connon)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoDocumento")

        Dim Tabla As DataTable = Ds.Tables("TipoDocumento")

        Dim lblSecondID, UltSecuencia As New Label

        lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
        UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)

        sqlQ = "UPDATE" & SysName.Text & "TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento='" + IDTipoDocumento.ToString + "'"
        cmd = New MySqlCommand(sqlQ, Connon)
        cmd.ExecuteNonQuery()
        Connon.Close()

        Return lblSecondID.Text

    End Function

    Friend Sub GenerarPagosComprasxSolicitud()
        Try
            Dim Dstemp As New DataSet
            Dim IDPago, IDSuplidor As New Label
            Dim Connon As New MySqlConnection(CnGeneral)

            Connon.Open()
            cmd = New MySqlCommand("SELECT IDSolicitudCheque,solicitudcheques.SecondID,solicitudcheques.IDUsuario,FechaPago,solicitudcheques.IDSuplidor,solicitudcheques.Beneficiario,Suplidor.Balance as BceSuplidor,Retencion,solicitudcheques.Monto,SolicitudCheques.Neto,SolicitudCheques.NoCheque,SolicitudCheques.IDCuenta,CuentasBancarias.NoCuenta,CuentasBancarias.IDBanco,Bancos.Identidad FROM" & SysName.Text & "solicitudcheques INNER JOIN Libregco.Suplidor on SolicitudCheques.IDSuplidor=Suplidor.IDSuplidor INNER JOIN" & SysName.Text & "CuentasBancarias on SolicitudCheques.IDCuenta=CuentasBancarias.IDCuenta INNER JOIN Libregco.Bancos on CuentasBancarias.IDBanco=Bancos.IDBanco where SolicitudCheques.Nulo=0 and Estado=0", Connon)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Dstemp, "Solicitud")

            Dim SolicitudTabla As DataTable = Dstemp.Tables("Solicitud")

            For Each row As DataRow In SolicitudTabla.Rows
                'Inserto el pago 
                sqlQ = "INSERT INTO" & SysName.Text & "PagoCompra (SecondID,IDTipoDocumento,Fecha,Hora,IDUsuario,IDSucursal,IDAlmacen,IDSuplidor,BceAnterior,MontoAplicado,Cheque,Efectivo,Transferencia,Importe,Retencion,Neto,Concepto,Comentario,TransferenciaReferencia,TransferenciaCuenta,TransferenciaBanco,ChequeNumero,ChequeFecha,ChequeBanco,ChequeCuenta,Nulo) VALUES ('" + GetSecondID(20).ToString + "',20,'" + Today.ToString("yyyy-MM-dd") + "','" + TimeOfDay.ToString("HH:mm:ss") + "', '" + row.Item("IDUsuario").ToString + "','" + DTEmpleado.Rows(0).Item("IDSucursal").ToString + "','" + DTEmpleado.Rows(0).Item("IDAlmacen").ToString + "','" + row.Item("IDSuplidor").ToString + "','" + row.Item("BceSuplidor").ToString + "','" + row.Item("Monto").ToString + "','" + row.Item("Monto").ToString + "','0','0','" + row.Item("Monto").ToString + "','" + row.Item("Retencion").ToString + "','" + row.Item("Neto").ToString + "','','PAGO DE FACTURA REALIZADO A TRAVES DE SOLICITUD DE CHEQUES','','','','" + row.Item("NoCheque").ToString + "','" + row.Item("FechaPago").ToString + "','" + row.Item("Identidad").ToString + "','" + row.Item("NoCuenta").ToString + "',0)"
                cmd = New MySqlCommand(sqlQ, Connon)
                cmd.ExecuteNonQuery()

                'Consulto ultimo ID
                cmd = New MySqlCommand("Select IDPagoCompra from" & SysName.Text & "PagoCompra where IDPagoCompra= (Select Max(IDPagoCompra) from" & SysName.Text & "PagoCompra)", Connon)
                IDPago.Text = Convert.ToDouble(cmd.ExecuteScalar)

                'Conseguir Suplidor
                IDSuplidor.Text = row.Item("IDSuplidor").ToString

                'Inserto el detalle del pago
                cmd = New MySqlCommand("SELECT SolicitudChequesDetalle.IDCompra,SolicitudChequesDetalle.RetISR,SolicitudChequesDetalle.RetItbis,SolicitudChequesDetalle.Descuento,SolicitudChequesDetalle.Monto,Compras.Balance FROM" & SysName.Text & "solicitudchequesdetalle INNER JOIN" & SysName.Text & "Compras on SolicitudChequesDetalle.IDCompra=Compras.IDCompra WHERE IDSolicitudCheque=(" + row.Item("IDSolicitudCheque").ToString + ")", Connon)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Dstemp, "DetalleSolicitud")

                Dim SolicitudDetalles As DataTable = Dstemp.Tables("DetalleSolicitud")

                For Each Rx As DataRow In SolicitudDetalles.Rows
                    sqlQ = "INSERT INTO" & SysName.Text & "PagoComprasDetalle (IDPagoCompra,IDCompra,BceAnterior,RetISR,RetITBIS,Descuento,Aplicado) VALUES ('" + IDPago.Text + "','" + Rx.Item("IDCompra").ToString + "','" + Rx.Item("Balance").ToString + "','" + Rx.Item("RetISR").ToString + "','" + Rx.Item("RetItbis").ToString + "','" + Rx.Item("Descuento").ToString + "','" + Rx.Item("Monto").ToString + "')"
                    cmd = New MySqlCommand(sqlQ, Connon)
                    cmd.ExecuteNonQuery()
                Next

                'Cambiando el estatus de las solicitudes
                sqlQ = "UPDATE" & SysName.Text & "SolicitudCheques SET Estado=1 WHERE IDSolicitudCheque=(" + row.Item("IDSolicitudCheque").ToString + ")"
                cmd = New MySqlCommand(sqlQ, Connon)
                cmd.ExecuteNonQuery()

                FunctCalcBcesFactSuplidor(IDSuplidor.Text)
                FunctCalcBceSuplidor(IDSuplidor.Text)
            Next

            Connon.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try
    End Sub

    Public Function RoundUp(ByVal val As Double, ByVal Redondear As Integer) As Double
        If Redondear = 1 Then
            Dim Posicion As Integer
            If CInt(val).ToString.Length = 1 Then
                Posicion = 1
            ElseIf CInt(val).ToString.Length = 2 Then
                Posicion = 0
            Else
                Posicion = -1
            End If

            Dim baseCalculo As Double = System.Math.Pow(DTConfiguracion.Rows(221 - 1).Item("Value2Int"), Posicion) 'pos +: right from float point, -: left from float point. 

            If val > 0 Then
                Return System.Math.Ceiling(val * baseCalculo) / baseCalculo
            Else
                Return System.Math.Floor(val * baseCalculo) / baseCalculo
            End If
        Else

            Return CDbl(val)
        End If

    End Function

    Function FunctCalcBcesFact(ByVal IDCliente As Integer)
        Try
            Dim IDFactura, BceFactura, CargosActualizados, MontoFactura, InicialFactura, NotaDebito, NotaCredito, Devoluciones, Abonos, CargosFactura, AbonosaCargos, PagosFinanciamientos As New Label
            Dim DsTemp, Ds1 As New DataSet


        '//Esta operación calcula el balance de todas las facturas válidas de un cliente 
        Con.Open()
        ConMixta.Open()

        DsTemp.Clear()
        cmd = New MySqlCommand("SELECT IDFacturaDatos,NetoFactura,FacturaDatos.SecondID FROM" & SysName.Text & "FacturaDatos Inner join Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion where IDCliente='" + IDCliente.ToString + "' and Condicion.Dias>0 and FacturaDatos.Nulo=0", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "FacturaDatos")

        '//Lleno las facturas en un dataset para luego calcular fila x fila
        Dim FacturasCliente As DataTable = DsTemp.Tables("FacturaDatos")

        For Each DtRow As DataRow In FacturasCliente.Rows

            '//Asignacion de valores
            IDFactura.Text = DtRow.Item("IDFacturaDatos")
            MontoFactura.Text = DtRow.Item("NetoFactura")

            cmd = New MySqlCommand("Select Coalesce(Sum(Aplicado),0) From NotaDebitoCreditoDetalle INNER JOIN NotaDebitoCredito on notadebitocreditodetalle.IDNotaDebitoCredito=NotaDebitoCredito.IDNotaDebCred Where IDTipoNota=2 and IDFactura='" + IDFactura.Text + "' and NotaDebitoCredito.Nulo=0", Con)
            NotaCredito.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select Coalesce(Sum(Aplicado),0) From NotaDebitoCreditoDetalle INNER JOIN NotaDebitoCredito on notadebitocreditodetalle.IDNotaDebitoCredito=NotaDebitoCredito.IDNotaDebCred Where IDTipoNota=1 and IDFactura='" + IDFactura.Text + "' and NotaDebitoCredito.Nulo=0", Con)
            NotaDebito.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select Coalesce(Sum(Devolver),0) From" & SysName.Text & "DevolucionVenta INNER JOIN" & SysName.Text & "FacturaDatos on DevolucionVenta.IDFActura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Condicion on FacturaDatos.IDCondicion=Condicion.IDCondicion Where DevolucionVenta.IDFactura='" + IDFactura.Text + "' and Condicion.Dias>0 and DevolucionVenta.Nulo=0", ConMixta)
            Devoluciones.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select Coalesce(Sum(DetalleAbonos.Debito+DetalleAbonos.Descuento),0) From DetalleAbonos INNER JOIN Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono Where IDFactura='" + IDFactura.Text + "' and Abonos.Nulo=0", Con)
            Abonos.Text = Convert.ToDouble(cmd.ExecuteScalar())

            BceFactura.Text = Math.Round(CDbl(MontoFactura.Text) + CDbl(NotaDebito.Text) - CDbl(NotaCredito.Text) - CDbl(Devoluciones.Text) - CDbl(Abonos.Text), 3)

            cmd = New MySqlCommand("Select Coalesce(Sum(Monto),0) From CargosFactura Where IDFactura='" + IDFactura.Text + "' and Nulo=0", Con)
            CargosFactura.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select Coalesce(Sum(Cargos+CargosExcento),0) From DetalleAbonos INNER JOIN Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono Where IDFactura='" + IDFactura.Text + "' and Nulo=0", Con)
            AbonosaCargos.Text = Convert.ToDouble(cmd.ExecuteScalar())

            CargosActualizados.Text = Math.Round(CDbl(CargosFactura.Text) - CDbl(AbonosaCargos.Text), 3)

            If CDbl(CargosActualizados.Text) < 0.1 Then
                CargosActualizados.Text = 0
            End If
            If CDbl(BceFactura.Text) < 0.1 Then
                BceFactura.Text = 0
            End If

            If CDbl(BceFactura.Text) < 0 Then
                MessageBox.Show("La factura " & DtRow.Item("SecondID") & " posee un error de integridad en el cálculo del balance. Por favor revise el histórico de la factura.")

            End If

            sqlQ = "UPDATE" & SysName.Text & "FacturaDatos Set Balance='" + BceFactura.Text + "',Cargos='" + CargosActualizados.Text + "',BalanceFacturaLetras='" + ConvertNumbertoString(CDbl(BceFactura.Text)).ToString + "' WHERE IDFacturaDatos='" + IDFactura.Text + "'"

            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
        Next


        'Busco financiamientos
        DsTemp.Clear()
        cmd = New MySqlCommand("SELECT IDFinanciamientos,TotalAPagar,(Select Coalesce(Sum(Financiamientos_cuotas.Cargo),0) From" & SysName.Text & "Financiamientos_cuotas where Financiamientos.IDFinanciamientos=Financiamientos_cuotas.IDFinanciamiento) as CargosAcumulados FROM" & SysName.Text & "financiamientos where IDCliente='" + IDCliente.ToString + "' and Financiamientos.Nulo=0", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "financiamientos")

        '//Lleno los financiamientos al mismo datatable
        FacturasCliente = DsTemp.Tables("financiamientos")

        For Each DtRow As DataRow In FacturasCliente.Rows
            IDFactura.Text = DtRow.Item("IDFinanciamientos")
            MontoFactura.Text = CDbl(DtRow.Item("TotalAPagar")) + CDbl(DtRow.Item("CargosAcumulados"))

            cmd = New MySqlCommand("Select Coalesce(Sum(TotalAplicado),0) From pagosfinanciamientos where IDFinanciamiento='" + IDFactura.Text + "' and pagosfinanciamientos.Nulo=0", Con)
            PagosFinanciamientos.Text = Convert.ToDouble(cmd.ExecuteScalar())

            BceFactura.Text = CDbl(MontoFactura.Text) - CDbl(PagosFinanciamientos.Text)

            sqlQ = "UPDATE" & SysName.Text & "financiamientos Set Balance='" + BceFactura.Text + "',BalanceLetra='" + ConvertNumbertoString(CDbl(BceFactura.Text)).ToString + "' WHERE IDFinanciamientos='" + IDFactura.Text + "'"
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()

            'Llenando cuotas de financiamientos
            Ds1.Clear()
            cmd = New MySqlCommand("Select IDFinanciamientos_cuotas,((Capital-(Select coalesce(sum(CapitalAplicado+DescuentosAplicado),0) from" & SysName.Text & " pagosfinanciamientos_detalles INNER JOIN" & SysName.Text & " PagosFinanciamientos on PagosFinanciamientos.IDPagosFinanciamientos=PagosFinanciamientos_detalles.IDPagosFinanciamientos Where Financiamientos_cuotas.idFinanciamientos_cuotas=pagosfinanciamientos_detalles.IDFinanciamientoCuota AND PagosFinanciamientos.Nulo=0))+(Interes-(Select coalesce(sum(InteresAplicado+InteresExonerado),0) from" & SysName.Text & " pagosfinanciamientos_detalles INNER JOIN" & SysName.Text & " PagosFinanciamientos on PagosFinanciamientos.IDPagosFinanciamientos=PagosFinanciamientos_detalles.IDPagosFinanciamientos Where Financiamientos_cuotas.idFinanciamientos_cuotas=pagosfinanciamientos_detalles.IDFinanciamientoCuota AND PagosFinanciamientos.Nulo=0))+(Cargo-(Select coalesce(sum(CargosAplicados+CargosExonerado),0) from" & SysName.Text & " pagosfinanciamientos_detalles INNER JOIN" & SysName.Text & " PagosFinanciamientos on PagosFinanciamientos.IDPagosFinanciamientos=PagosFinanciamientos_detalles.IDPagosFinanciamientos Where Financiamientos_cuotas.idFinanciamientos_cuotas=pagosfinanciamientos_detalles.IDFinanciamientoCuota AND PagosFinanciamientos.Nulo=0))) as Balance FROM" & SysName.Text & " Financiamientos_cuotas WHERE IDFinanciamiento='" + IDFactura.Text + "' Order by NoCuota ASC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Cuotas")

            Dim TablaCuotas As DataTable = Ds1.Tables("Cuotas")

            For Each drow As DataRow In TablaCuotas.Rows
                '//Actualizando balances de las cuotas
                sqlQ = "UPDATE" & SysName.Text & "financiamientos_cuotas Set Balance='" + CDbl(Math.Round(CDbl(drow.Item(1)), 4)).ToString + "' WHERE idFinanciamientos_cuotas='" + drow.Item(0).ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConMixta)
                cmd.ExecuteNonQuery()
            Next
        Next

        Con.Close()
        ConMixta.Close()


        Catch ex As Exception
        MessageBox.Show(ex.Message.ToString)
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        Con.Close()
        ConMixta.Close()
        End Try

    End Function

    Function FunctCalcBceGral(ByVal IDCliente As Integer)
        Try
            Dim SumaFacturasA, SumaFacturasB, CargosZ, CargosA, FinanciamientosA, FinanciamientosB As New Label
            Dim SumFact As Double

        ConLibregcoMain.Open()
        ConLibregco.Open()

        Dim ds As New DataSet
        cmd = New MySqlCommand("SELECT IDTipoMoneda,Moneda,Signo FROM libregco.tipomoneda ORDER BY IDTipoMoneda ASC", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(ds, "tipomoneda")

        For Each Row As DataRow In ds.Tables(0).Rows
            Dim idClientes_Balances As Double
            cmd = New MySqlCommand("SELECT COUNT(idclientes_balances) FROM libregco.clientes_balances where IDCliente='" + IDCliente.ToString + "' and IDMoneda='" + Row.Item("IDTipoMoneda").ToString + "'", ConLibregco)

            Dim IsNewBalance As Boolean = False
            Dim HayResultados As Integer = Convert.ToInt16(cmd.ExecuteScalar())


            If HayResultados = 0 Then
                IsNewBalance = True
            Else
                IsNewBalance = False
            End If

            If HayResultados = 0 Then
                sqlQ = "INSERT INTO Libregco.clientes_balances (IDCliente,IDMoneda,Balance,BalanceLetras,CargosGeneral,LimiteCredito) VALUES ('" + IDCliente.ToString + "','" + Row.Item("IDTipoMoneda").ToString + "',0,'" + ConvertNumbertoString(0, Row.Item("Moneda").ToString).ToString + "',0,0)"
                cmd = New MySqlCommand(sqlQ, ConLibregco)
                cmd.ExecuteNonQuery()
            End If

            cmd = New MySqlCommand("Select idClientes_Balances From clientes_balances Where IDCliente='" + IDCliente.ToString + "' and IDMoneda='" + Row.Item("IDTipoMoneda").ToString + "'", ConLibregco)
            idClientes_Balances = Convert.ToDouble(cmd.ExecuteScalar())

            If IsNewBalance Then
                'Actualizando limites de creditos en nueva estructura
                If Row.Item("IDTipoMoneda") = 1 Then
                    sqlQ = "UPDATE Libregco.clientes_balances SET LimiteCredito=(Select LimiteCredito from Libregco.Clientes Where IDCliente=Clientes_Balances.IDCliente) WHERE idClientes_Balances='" + idClientes_Balances.ToString + "'"
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()
                End If
            End If


            ''''''''''''''''''''''''''''''''''''''''
            cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From FacturaDatos INNER JOIN Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.IDCliente='" + IDCliente.ToString + "' AND Transaccion.IDMoneda='" + Row.Item("IDTipoMoneda").ToString + "' AND FacturaDatos.Nulo=0", ConLibregco)
            SumaFacturasA.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From FacturaDatos INNER JOIN Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.IDCliente='" + IDCliente.ToString + "' AND Transaccion.IDMoneda='" + Row.Item("IDTipoMoneda").ToString + "' AND FacturaDatos.Nulo=0", ConLibregcoMain)
            SumaFacturasB.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT Coalesce(Sum(Cargos),0) from Libregco.FacturaDatos INNER JOIN Libregco.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.Balance>0 and FacturaDatos.IDCliente='" + IDCliente.ToString + "' and Transaccion.IDMoneda='" + Row.Item("IDTipoMoneda").ToString + "' and FacturaDatos.Nulo=0", ConLibregco)
            CargosZ.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT Coalesce(Sum(Cargos),0) from Libregco_Main.FacturaDatos INNER JOIN Libregco_Main.Transaccion on FacturaDatos.IDTransaccion=Transaccion.IDTransaccion Where FacturaDatos.Balance>0 and FacturaDatos.IDCliente='" + IDCliente.ToString + "' and Transaccion.IDMoneda='" + Row.Item("IDTipoMoneda").ToString + "' and FacturaDatos.Nulo=0", ConLibregcoMain)
            CargosA.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From Financiamientos INNER JOIN Transaccion On Financiamientos.IDTransaccion=Transaccion.IDTransaccion Where IDCliente='" + IDCliente.ToString + "' AND Transaccion.IDMoneda='" + Row.Item("IDTipoMoneda").ToString + "' AND Financiamientos.Nulo=0", ConLibregco)
            FinanciamientosA.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From Financiamientos INNER JOIN Transaccion on Financiamientos.IDTransaccion=Transaccion.IDTransaccion Where IDCliente='" + IDCliente.ToString + "' AND Transaccion.IDMoneda='" + Row.Item("IDTipoMoneda").ToString + "' AND Financiamientos.Nulo=0", ConLibregcoMain)
            FinanciamientosB.Text = Convert.ToDouble(cmd.ExecuteScalar())

            SumFact = Math.Round(CDbl(SumaFacturasA.Text) + CDbl(SumaFacturasB.Text) + CDbl(FinanciamientosA.Text) + CDbl(FinanciamientosB.Text), 3)

            sqlQ = "UPDATE Libregco.clientes_balances SET Balance='" + SumFact.ToString + "',CargosGeneral='" + Math.Round(CDbl(CDbl(CargosZ.Text) + CDbl(CargosA.Text)), 3).ToString + "',BalanceLetras='" + ConvertNumbertoString(SumFact, Row.Item("Moneda").ToString).ToString + "' WHERE idClientes_Balances= '" + idClientes_Balances.ToString + "'"
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
        Next

        cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From FacturaDatos Where IDCliente='" + IDCliente.ToString + "' AND FacturaDatos.Nulo=0", ConLibregco)
        SumaFacturasA.Text = Convert.ToDouble(cmd.ExecuteScalar())

        cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From FacturaDatos Where IDCliente='" + IDCliente.ToString + "' AND FacturaDatos.Nulo=0", ConLibregcoMain)
        SumaFacturasB.Text = Convert.ToDouble(cmd.ExecuteScalar())

        cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From Financiamientos Where IDCliente='" + IDCliente.ToString + "' AND Financiamientos.Nulo=0", ConLibregco)
        FinanciamientosA.Text = Convert.ToDouble(cmd.ExecuteScalar())

        cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From Financiamientos Where IDCliente='" + IDCliente.ToString + "' AND Financiamientos.Nulo=0", ConLibregcoMain)
        FinanciamientosB.Text = Convert.ToDouble(cmd.ExecuteScalar())

        SumFact = Math.Round(CDbl(SumaFacturasA.Text) + CDbl(SumaFacturasB.Text) + CDbl(FinanciamientosA.Text) + CDbl(FinanciamientosB.Text), 3)

        sqlQ = "UPDATE Libregco.Clientes SET BalanceGeneral='" + SumFact.ToString + "',BalanceGeneralLetras='" + ConvertNumbertoString(CDbl(SumFact.ToString)).ToString + "' WHERE IDCliente= '" + IDCliente.ToString + "'"
        cmd = New MySqlCommand(sqlQ, ConLibregco)
        cmd.ExecuteNonQuery()

        ConLibregcoMain.Close()
        ConLibregco.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
            Con.Close()
        ConMixta.Close()
        End Try

    End Function

    Function FunctCalcBceSuplidor(ByVal IDSuplidor As Integer)
        Try
            Dim SumaTotal, SumaFacturaA, SumaFacturaB As New Label

            ConMixta.Open()

            cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From Libregco.Compras INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion Where IDSuplidor='" + IDSuplidor.ToString + "' and Dias>0 AND Compras.Nulo=0", ConMixta)
            SumaFacturaA.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select Coalesce(Sum(Balance),0) From Libregco_Main.Compras INNER JOIN Libregco.Condicion on Compras.IDCondicion=Condicion.IDCondicion Where IDSuplidor='" + IDSuplidor.ToString + "' and Dias>0 AND Compras.Nulo=0", ConMixta)
            SumaFacturaB.Text = Convert.ToDouble(cmd.ExecuteScalar())

            SumaTotal.Text = Math.Round(CDbl(SumaFacturaA.Text) + CDbl(SumaFacturaB.Text), 3)

            sqlQ = "UPDATE Libregco.Suplidor SET Balance='" + SumaTotal.Text + "' WHERE IDSuplidor= '" + IDSuplidor.ToString + "'"
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()

            ConMixta.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try

    End Function

    Function CalcBcePagares(ByVal CodigoFactura As String)
        Try
            Dim DsTemp As New DataSet
            Dim BalanceAbierto As Double

            DsTemp.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT * FROM" & SysName.Text & "pagares where idfactura='" + CodigoFactura.ToString + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "pagares")

            Dim Tabla As DataTable = DsTemp.Tables("pagares")

            If Tabla.Rows.Count = 0 Then
                'MessageBox.Show("No se encontraron resultados con el código de factura " & CodigoFactura.ToString)
            Else
                For Each dt As DataRow In Tabla.Rows
                    cmd = New MySqlCommand("Select Coalesce(Sum(Debito+Descuento),0) from" & SysName.Text & "RecibosDetalle INNER JOIN" & SysName.Text & "RecibosCobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro where IDPagare='" + dt.Item("IDPagare").ToString + "' and Nulo=0", ConMixta)
                    BalanceAbierto = CDbl(dt.Item("Monto")) - CDbl(Convert.ToDouble(cmd.ExecuteScalar()))

                    sqlQ = "UPDATE" & SysName.Text & "Pagares SET Balance='" + BalanceAbierto.ToString + "' WHERE IDPagare= '" + dt.Item("IDPagare").ToString + "'"
                    cmd = New MySqlCommand(sqlQ, ConMixta)
                    cmd.ExecuteNonQuery()
                Next

            End If

            ConMixta.Close()

            CalcBceCerrado(CodigoFactura)

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)

        End Try
    End Function
    Function FunctCalcInventarioGralSinConexion(ByVal IDArticulo As Integer)
        'Try
        cmd = New MySqlCommand("Select (ZCompras-ZVentas+ZEntradas-ZSalidas+ZDevolucionesVentas-ZDevolucionesCompras-ZReparaciones+ZEntradasReparaciones+ACompras-AVentas+AEntradas-ASalidas+ADevolucionesVentas-ADevolucionesCompras-AReparaciones+AEntradasReparaciones) from 
        (Select Coalesce(Sum(Cantidad * Contenido),0) as ZCompras from Libregco.DetalleCompra INNER JOIN Libregco.compras on DetalleCompra.IDCompra=Compras.IDCompra INNER JOIN Libregco.precioarticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios Where DetalleCompra.IDArticulo='" + IDArticulo.ToString + "' and Compras.Nulo=0) as ZCompras,
        (Select Coalesce(Sum(Cantidad * Contenido),0) as ZVentas from Libregco.FacturaArticulos INNER JOIN Libregco.facturadatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.precioarticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios where FacturaArticulos.IDArticulo='" + IDArticulo.ToString + "' and FacturaDatos.Nulo=0) as ZVentas,
        (Select Coalesce(Sum(Cantidad * Contenido),0) as ZEntradas from Libregco.Movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=1 AND movimientoinventario.Nulo=0) as ZEntradas,
        (Select Abs(Coalesce(Sum(Cantidad * Contenido),0)) as ZSalidas from Libregco.Movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=2 AND movimientoinventario.Nulo=0) as ZSalidas,
        (Select Coalesce(Sum(CantDevuelta * Contenido),0) as ZDevolucionesVentas from Libregco.Devolucionventadetalle INNER JOIN Libregco.devolucionventa on devolucionventadetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta INNER JOIN Libregco.precioarticulo on devolucionventadetalle.IDPrecio=PrecioArticulo.IDPrecios Where Devolucionventadetalle.IDArticulo='" + IDArticulo.ToString + "' and DevolucionVenta.Nulo=0) as ZDevolucionesVentas,
        (Select Coalesce(Sum(CantDevuelta * Contenido),0) as ZDevolucionesCompras from Libregco.DevolucionCompradetalle INNER JOIN Libregco.devolucionCompra on devolucionCompradetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra INNER JOIN Libregco.precioarticulo on devolucionCompradetalle.IDPrecio=PrecioArticulo.IDPrecios Where DevolucionCompradetalle.IDArticulo='" + IDArticulo.ToString + "' and DevolucionCompra.Nulo=0) as ZDevolucionesCompras,
        (Select Coalesce(Sum(Cantidad * Contenido),0) as ZReparaciones from Libregco.ReparacionDetalle INNER JOIN Libregco.Reparacion on ReparacionDetalle.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.precioarticulo on ReparacionDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and ReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and Reparacion.Nulo=0) as ZReparaciones,
        (Select Coalesce(Sum(CantidadRecibida * Contenido),0) as ZEntradasReparaciones from Libregco.EntradaReparaciondetalle INNER JOIN Libregco.EntradaReparacion on EntradaReparaciondetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Libregco.precioarticulo on EntradaReparaciondetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and EntradaReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and EntradaReparacion.Nulo=0 and Reparacion.Nulo=0) as ZEntradasReparaciones,


        (Select Coalesce(Sum(Cantidad * Contenido),0) as ACompras from Libregco_Main.DetalleCompra INNER JOIN Libregco_Main.compras on DetalleCompra.IDCompra=Compras.IDCompra INNER JOIN Libregco.precioarticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios Where DetalleCompra.IDArticulo='" + IDArticulo.ToString + "' and Compras.Nulo=0) as ACompras,
        (Select Coalesce(Sum(Cantidad * Contenido),0) as AVentas from Libregco_Main.FacturaArticulos INNER JOIN Libregco_Main.facturadatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.precioarticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios where FacturaArticulos.IDArticulo='" + IDArticulo.ToString + "' and FacturaDatos.Nulo=0) as AVentas,
        (Select Coalesce(Sum(Cantidad * Contenido),0) as AEntradas from Libregco_Main.Movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=1 AND movimientoinventario.Nulo=0) as AEntradas,
        (Select Abs(Coalesce(Sum(Cantidad * Contenido),0)) as ASalidas from Libregco_Main.Movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=2 AND movimientoinventario.Nulo=0) as ASalidas,
        (Select Coalesce(Sum(CantDevuelta * Contenido),0) as ADevolucionesVentas from Libregco_Main.Devolucionventadetalle INNER JOIN Libregco_Main.devolucionventa on devolucionventadetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta INNER JOIN Libregco.precioarticulo on devolucionventadetalle.IDPrecio=PrecioArticulo.IDPrecios Where Devolucionventadetalle.IDArticulo='" + IDArticulo.ToString + "' and DevolucionVenta.Nulo=0) as ADevolucionesVentas,
        (Select Coalesce(Sum(CantDevuelta * Contenido),0) as ADevolucionesCompras from Libregco_Main.DevolucionCompradetalle INNER JOIN Libregco_Main.devolucionCompra on devolucionCompradetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra INNER JOIN Libregco.precioarticulo on devolucionCompradetalle.IDPrecio=PrecioArticulo.IDPrecios Where DevolucionCompradetalle.IDArticulo='" + IDArticulo.ToString + "' and DevolucionCompra.Nulo=0) as ADevolucionesCompras,
        (Select Coalesce(Sum(Cantidad * Contenido),0) as AReparaciones from Libregco_Main.ReparacionDetalle INNER JOIN Libregco_Main.Reparacion on ReparacionDetalle.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.precioarticulo on ReparacionDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and ReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and Reparacion.Nulo=0) as AReparaciones,
        (Select Coalesce(Sum(CantidadRecibida * Contenido),0) as AEntradasReparaciones from Libregco_Main.EntradaReparaciondetalle INNER JOIN Libregco_Main.EntradaReparacion on EntradaReparaciondetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Libregco.precioarticulo on EntradaReparaciondetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco_Main.Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and EntradaReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and EntradaReparacion.Nulo=0 and Reparacion.Nulo=0) as AEntradasReparaciones", ConTemporal)
        Dim ExistenciaTotal As Double = Convert.ToDouble(cmd.ExecuteScalar())


        '''Veces comprado vendido
        Dim VecesVendido, VecesComprado As Integer
        cmd = New MySqlCommand("SELECT (Select Count(IDArticulo) from Libregco.FacturaArticulos Where FacturaArticulos.IDArticulo='" + IDArticulo.ToString + "')+(Select Count(IDArticulo) from Libregco_Main.FacturaArticulos Where FacturaArticulos.IDArticulo='" + IDArticulo.ToString + "')v", ConTemporal)
        VecesVendido = Convert.ToInt16(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT (Select Count(IDArticulo) from Libregco.DetalleCompra Where DetalleCompra.IDArticulo='" + IDArticulo.ToString + "')+(Select Count(IDArticulo) from Libregco_Main.DetalleCompra Where DetalleCompra.IDArticulo='" + IDArticulo.ToString + "')", ConTemporal)
        VecesComprado = Convert.ToInt16(cmd.ExecuteScalar())

        cmd = New MySqlCommand("UPDATE Libregco.Articulos SET ExistenciaTotal='" + ExistenciaTotal.ToString + "',VecesVendido='" + VecesVendido.ToString + "',VecesComprado='" + VecesComprado.ToString + "' WHERE IDArticulo= (" + IDArticulo.ToString + ")", ConTemporal)
        cmd.ExecuteNonQuery()


        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        'End Try
    End Function



    Function FunctCalcInventarioGral(ByVal IDArticulo As Integer)
        Try
            Dim CantidadAdq, CantidadVend, Salidas, Entradas, DevolucionesVenta, DevolucionesCompra, Reparaciones, ReparacionRecibidas, Total As Double

            ConTemporal.Open()

            '''''''''''''''''Z
            'Articulos Comprados / CantidadAdq
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado from Libregco.DetalleCompra INNER JOIN Libregco.compras on DetalleCompra.IDCompra=Compras.IDCompra INNER JOIN Libregco.precioarticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios Where DetalleCompra.IDArticulo= '" + IDArticulo.ToString + "' and Compras.Nulo=0", ConTemporal)
            CantidadAdq = Convert.ToDouble(cmd.ExecuteScalar())

            'Artículos Vendidos / CantidadVend
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado from Libregco.FacturaArticulos INNER JOIN Libregco.facturadatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.precioarticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios where FacturaArticulos.IDArticulo= '" + IDArticulo.ToString + "' and FacturaDatos.Nulo=0", ConTemporal)
            CantidadVend = Convert.ToDouble(cmd.ExecuteScalar())

            'Ajustes de Entrada y/o Función Suma / Entradas
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) from Libregco.Movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=1 AND movimientoinventario.Nulo=0", ConTemporal)
            Entradas = Convert.ToDouble(cmd.ExecuteScalar())

            'Ajustedes de Salida y/o Función Resta / Salidas                                         
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) from Libregco.Movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=2 AND movimientoinventario.Nulo=0", ConTemporal)
            Salidas = Convert.ToDouble(cmd.ExecuteScalar())

            'Devoluciones de Ventas
            cmd = New MySqlCommand("Select Coalesce(Sum(CantDevuelta * Contenido),0) as Resultado from Libregco.Devolucionventadetalle INNER JOIN Libregco.devolucionventa on devolucionventadetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta INNER JOIN Libregco.precioarticulo on devolucionventadetalle.IDPrecio=PrecioArticulo.IDPrecios Where Devolucionventadetalle.IDArticulo='" + IDArticulo.ToString + "' and DevolucionVenta.Nulo=0", ConTemporal)
            DevolucionesVenta = Convert.ToDouble(cmd.ExecuteScalar())

            ''Devoluciones en Copras
            cmd = New MySqlCommand("Select Coalesce(Sum(CantDevuelta * Contenido),0) as Resultado from Libregco.DevolucionCompradetalle INNER JOIN Libregco.devolucionCompra on devolucionCompradetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra INNER JOIN Libregco.precioarticulo on devolucionCompradetalle.IDPrecio=PrecioArticulo.IDPrecios Where DevolucionCompradetalle.IDArticulo='" + IDArticulo.ToString + "' and DevolucionCompra.Nulo=0", ConTemporal)
            DevolucionesCompra = Convert.ToDouble(cmd.ExecuteScalar())

            'Reparaciones afectando el inventario
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado from Libregco.ReparacionDetalle INNER JOIN Libregco.Reparacion on ReparacionDetalle.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.precioarticulo on ReparacionDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and ReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and Reparacion.Nulo=0", ConTemporal)
            Reparaciones = Convert.ToDouble(cmd.ExecuteScalar())

            'Reparaciones recibidas
            cmd = New MySqlCommand("Select Coalesce(Sum(CantidadRecibida * Contenido),0) as Resultado from Libregco.EntradaReparaciondetalle INNER JOIN Libregco.EntradaReparacion on EntradaReparaciondetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Libregco.precioarticulo on EntradaReparaciondetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and EntradaReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and EntradaReparacion.Nulo=0 and Reparacion.Nulo=0", ConTemporal)
            ReparacionRecibidas = Convert.ToDouble(cmd.ExecuteScalar())

            Total = CantidadAdq - CantidadVend + Salidas + Entradas + DevolucionesVenta - DevolucionesCompra - Reparaciones + ReparacionRecibidas

            '''''''''''''''''A

            'Articulos Comprados / CantidadAdq
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado from Libregco_Main.DetalleCompra INNER JOIN Libregco_Main.compras on DetalleCompra.IDCompra=Compras.IDCompra INNER JOIN Libregco.precioarticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios Where DetalleCompra.IDArticulo= '" + IDArticulo.ToString + "' and Compras.Nulo=0", ConTemporal)
            CantidadAdq = Convert.ToDouble(cmd.ExecuteScalar())

            'Artículos Vendidos / CantidadVend
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado from Libregco_Main.FacturaArticulos INNER JOIN Libregco_Main.facturadatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.precioarticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios where FacturaArticulos.IDArticulo= '" + IDArticulo.ToString + "' and FacturaDatos.Nulo=0", ConTemporal)
            CantidadVend = Convert.ToDouble(cmd.ExecuteScalar())

            'Ajustes de Entrada y/o Función Suma / Entradas
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) from Libregco_Main.Movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=1 AND movimientoinventario.Nulo=0", ConTemporal)
            Entradas = Convert.ToDouble(cmd.ExecuteScalar())

            'Ajustedes de Salida y/o Función Resta / Salidas
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) from Libregco_Main.Movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=2 AND movimientoinventario.Nulo=0", ConTemporal)
            Salidas = Convert.ToDouble(cmd.ExecuteScalar())

            'Devoluciones de Ventas
            cmd = New MySqlCommand("Select Coalesce(Sum(CantDevuelta * Contenido),0) as Resultado from Libregco_Main.Devolucionventadetalle INNER JOIN Libregco_Main.devolucionventa on devolucionventadetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta INNER JOIN Libregco.precioarticulo on devolucionventadetalle.IDPrecio=PrecioArticulo.IDPrecios Where Devolucionventadetalle.IDArticulo='" + IDArticulo.ToString + "' and DevolucionVenta.Nulo=0", ConTemporal)
            DevolucionesVenta = Convert.ToDouble(cmd.ExecuteScalar())

            ''Devoluciones en Copras
            cmd = New MySqlCommand("Select Coalesce(Sum(CantDevuelta * Contenido),0) as Resultado from Libregco_Main.DevolucionCompradetalle INNER JOIN Libregco_Main.devolucionCompra on devolucionCompradetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra INNER JOIN Libregco.precioarticulo on devolucionCompradetalle.IDPrecio=PrecioArticulo.IDPrecios Where DevolucionCompradetalle.IDArticulo='" + IDArticulo.ToString + "' and DevolucionCompra.Nulo=0", ConTemporal)
            DevolucionesCompra = Convert.ToDouble(cmd.ExecuteScalar())

            'Reparaciones afectando el inventario
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado from Libregco_Main.ReparacionDetalle INNER JOIN Libregco_Main.Reparacion on ReparacionDetalle.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.precioarticulo on ReparacionDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and ReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and Reparacion.Nulo=0", ConTemporal)
            Reparaciones = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("Select Coalesce(Sum(CantidadRecibida * Contenido),0) as Resultado from Libregco_Main.EntradaReparaciondetalle INNER JOIN Libregco_Main.EntradaReparacion on EntradaReparaciondetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Libregco.precioarticulo on EntradaReparaciondetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco_Main.Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and EntradaReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and EntradaReparacion.Nulo=0 and Reparacion.Nulo=0", ConTemporal)
            ReparacionRecibidas = Convert.ToDouble(cmd.ExecuteScalar())

            Total = Total + CantidadAdq - CantidadVend + Salidas + Entradas + DevolucionesVenta - DevolucionesCompra - Reparaciones + ReparacionRecibidas

            '''Veces comprado vendido
            Dim VecesVendido, VecesComprado As Integer
            cmd = New MySqlCommand("SELECT (Select Count(IDArticulo) from Libregco.FacturaArticulos Where FacturaArticulos.IDArticulo='" + IDArticulo.ToString + "')+(Select Count(IDArticulo) from Libregco_Main.FacturaArticulos Where FacturaArticulos.IDArticulo='" + IDArticulo.ToString + "')", ConTemporal)
            VecesVendido = Convert.ToInt16(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT (Select Count(IDArticulo) from Libregco.DetalleCompra Where DetalleCompra.IDArticulo='" + IDArticulo.ToString + "')+(Select Count(IDArticulo) from Libregco_Main.DetalleCompra Where DetalleCompra.IDArticulo='" + IDArticulo.ToString + "')", ConTemporal)
            VecesComprado = Convert.ToInt16(cmd.ExecuteScalar())

            cmd = New MySqlCommand("UPDATE Libregco.Articulos SET ExistenciaTotal='" + Total.ToString + "',VecesVendido='" + VecesVendido.ToString + "',VecesComprado='" + VecesComprado.ToString + "' WHERE IDArticulo= (" + IDArticulo.ToString + ")", ConTemporal)
            cmd.ExecuteNonQuery()
            ConTemporal.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try
    End Function

    Function FunctCalcInvAlmacenesSinConexion(ByVal IDArticulo As Integer, ByVal IDPrecio As Integer)
        'Try
        Dim Ds As New DataSet
        cmd = New MySqlCommand()

        Adaptador = New MySqlDataAdapter("SELECT IDAlmacen FROM" & SysName.Text & "Almacen WHERE Desactivar=0", ConTemporal)
        Adaptador.Fill(Ds, "Almacen")

        For Each dt As DataRow In Ds.Tables("Almacen").Rows
            cmd = New MySqlCommand("Select (ZEntradas-Abs(ZSalidas)+ZCompras-ZVentas-ZTransferenciasSalidas+ZTransferenciasEntradas+ZDevolucionesVentas-ZDevolucionesCompras-ZReparaciones+ZReparacionesRecibidas) from 
(Select Coalesce(Sum(Cantidad * Contenido),0) as ZEntradas from Libregco.Movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE Movimientoinvdetalle.IDAlmacen='1' AND MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDPrecio='" + IDPrecio.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=1 AND movimientoinventario.Nulo=0) as ZEntradas,
(Select Coalesce(Sum(Cantidad * Contenido),0) as ZSalidas from Libregco.Movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE Movimientoinvdetalle.IDAlmacen='1' AND MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDPrecio='" + IDPrecio.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=2 AND movimientoinventario.Nulo=0) as ZSalidas,
(Select Coalesce(Sum(Cantidad * Contenido),0) as ZCompras from Libregco.DetalleCompra INNER JOIN Libregco.Compras on DetalleCompra.IDCompra=compras.IDCompra INNER JOIN Libregco.precioarticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios Where DetalleCompra.IDAlmacen='1' AND DetalleCompra.IDArticulo='" + IDArticulo.ToString + "' AND IDPrecio='" + IDPrecio.ToString + "' AND Compras.Nulo=0) as ZCompras,
(Select Coalesce(Sum(Cantidad * Contenido),0) as ZVentas from Libregco.FacturaArticulos INNER JOIN Libregco.FacturaDatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.precioarticulo on facturaarticulos.IDPrecio=PrecioArticulo.IDPrecios Where FacturaArticulos.IDAlmacen='1' AND FacturaArticulos.IDArticulo='" + IDArticulo.ToString + "' AND IDPrecio='" + IDPrecio.ToString + "' AND FacturaDatos.Nulo=0) as ZVentas,
(Select Coalesce(Sum(Cantidad * Contenido),0) as ZTransferenciasSalidas From Libregco.transferenciaartdetalle INNER JOIN Libregco.transfenciaarticulos on transferenciaartdetalle.IDTransferenciaArticulo=transfenciaarticulos.IDTransferenciaArt INNER JOIN Libregco.precioarticulo on TransferenciaArtDetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE IDAlmacenSalida='1' and transferenciaartdetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and transfenciaarticulos.Nulo=0) as ZTransferenciasSalidas,
(Select Coalesce(Sum(Cantidad * Contenido),0) as ZTransferenciasEntradas From Libregco.transferenciaartdetalle INNER JOIN Libregco.transfenciaarticulos on transferenciaartdetalle.IDTransferenciaArticulo=transfenciaarticulos.IDTransferenciaArt INNER JOIN Libregco.precioarticulo on TransferenciaArtDetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE IDAlmacenEntrada='1' and transferenciaartdetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and transfenciaarticulos.Nulo=0) as ZTransferenciaEntradas,
(Select Coalesce(Sum(CantDevuelta * Contenido),0) as ZDevolucionesVentas from Libregco.Devolucionventadetalle INNER JOIN Libregco.devolucionventa on devolucionventadetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta INNER JOIN Libregco.facturadatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.precioarticulo on DevolucionVentaDetalle.IDPrecio=PrecioArticulo.IDPrecios Where Devolucionventadetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and Devolucionventadetalle.IDAlmacen='1' and DevolucionVenta.Nulo=0) as ZDevolucionesVentas,
(Select Coalesce(Sum(CantDevuelta * Contenido),0) as ZDevolucionesCompras from Libregco.DevolucionCompradetalle INNER JOIN Libregco.devolucionCompra on devolucionCompradetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra INNER JOIN Libregco.Compras on DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN Libregco.precioarticulo on DevolucionCompraDetalle.IDPrecio=PrecioArticulo.IDPrecios Where DevolucionCompradetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and DevolucionCompradetalle.IDAlmacen='1' and DevolucionCompra.Nulo=0) as ZDevolucionesCompras,
(Select Coalesce(Sum(Cantidad * Contenido),0) as ZReparaciones from Libregco.ReparacionDetalle INNER JOIN Libregco.Reparacion on ReparacionDetalle.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.precioarticulo on ReparacionDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and ReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and ReparacionDetalle.IDPrecio='" + IDPrecio.ToString + "' and Reparacion.IDAlmacen='1' and Reparacion.IDTipoOrden=1 and Reparacion.Nulo=0) as ZReparaciones,
(Select Coalesce(Sum(CantidadRecibida * Contenido),0) as ZReparacionesRecibidas from Libregco.EntradaReparaciondetalle INNER JOIN Libregco.EntradaReparacion on EntradaReparaciondetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Libregco.precioarticulo on EntradaReparaciondetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and EntradaReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and EntradaReparacionDetalle.IDPrecio='" + IDPrecio.ToString + "' and EntradaReparacion.IDAlmacen='1' and EntradaReparacion.Nulo=0 and Reparacion.Nulo=0) as ZReparacionesRecibidas", ConTemporal)
            Dim Z As Double = Convert.ToDouble(cmd.ExecuteScalar())


            cmd = New MySqlCommand("Select (AEntradas-Abs(ASalidas)+ACompras-AVentas-ATransferenciasSalidas+ATransferenciasEntradas+ADevolucionesVentas-ADevolucionesCompras-AReparaciones+AReparacionesRecibidas) from
(Select Coalesce(Sum(Cantidad * Contenido),0) as AEntradas from Libregco_Main.Movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE Movimientoinvdetalle.IDAlmacen='1' AND MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDPrecio='" + IDPrecio.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=1 AND movimientoinventario.Nulo=0) as AEntradas,
(Select Coalesce(Sum(Cantidad * Contenido),0) as ASalidas from Libregco_Main.Movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE Movimientoinvdetalle.IDAlmacen='1' AND MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDPrecio='" + IDPrecio.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=2 AND movimientoinventario.Nulo=0) as ASalidas,
(Select Coalesce(Sum(Cantidad * Contenido),0) as ACompras from Libregco_Main.DetalleCompra INNER JOIN Libregco_Main.Compras on DetalleCompra.IDCompra=compras.IDCompra INNER JOIN Libregco.precioarticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios Where DetalleCompra.IDAlmacen='1' AND DetalleCompra.IDArticulo='" + IDArticulo.ToString + "' AND IDPrecio='" + IDPrecio.ToString + "' AND Compras.Nulo=0) as ACompras,
(Select Coalesce(Sum(Cantidad * Contenido),0) as AVentas from Libregco_Main.FacturaArticulos INNER JOIN Libregco_Main.FacturaDatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.precioarticulo on facturaarticulos.IDPrecio=PrecioArticulo.IDPrecios Where FacturaArticulos.IDAlmacen='1' AND FacturaArticulos.IDArticulo='" + IDArticulo.ToString + "' AND IDPrecio='" + IDPrecio.ToString + "' AND FacturaDatos.Nulo=0) as AVentas,
(Select Coalesce(Sum(Cantidad * Contenido),0) as ATransferenciasSalidas From Libregco_Main.transferenciaartdetalle INNER JOIN Libregco_Main.transfenciaarticulos on transferenciaartdetalle.IDTransferenciaArticulo=transfenciaarticulos.IDTransferenciaArt INNER JOIN Libregco.precioarticulo on TransferenciaArtDetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE IDAlmacenSalida='1' and transferenciaartdetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and transfenciaarticulos.Nulo=0) as ATransferenciasSalidas,
(Select Coalesce(Sum(Cantidad * Contenido),0) as ATransferenciasEntradas From Libregco_Main.transferenciaartdetalle INNER JOIN Libregco_Main.transfenciaarticulos on transferenciaartdetalle.IDTransferenciaArticulo=transfenciaarticulos.IDTransferenciaArt INNER JOIN Libregco.precioarticulo on TransferenciaArtDetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE IDAlmacenEntrada='1' and transferenciaartdetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and transfenciaarticulos.Nulo=0) as ATransferenciaEntradas,
(Select Coalesce(Sum(CantDevuelta * Contenido),0) as ADevolucionesVentas from Libregco_Main.Devolucionventadetalle INNER JOIN Libregco_Main.devolucionventa on devolucionventadetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta INNER JOIN Libregco_Main.facturadatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.precioarticulo on DevolucionVentaDetalle.IDPrecio=PrecioArticulo.IDPrecios Where Devolucionventadetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and Devolucionventadetalle.IDAlmacen='1' and DevolucionVenta.Nulo=0) as ADevolucionesVentas,
(Select Coalesce(Sum(CantDevuelta * Contenido),0) as ADevolucionesCompras from Libregco_Main.DevolucionCompradetalle INNER JOIN Libregco_Main.devolucionCompra on devolucionCompradetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra INNER JOIN Libregco_Main.Compras on DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN Libregco.precioarticulo on DevolucionCompraDetalle.IDPrecio=PrecioArticulo.IDPrecios Where DevolucionCompradetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and DevolucionCompradetalle.IDAlmacen='1' and DevolucionCompra.Nulo=0) as ADevolucionesCompras,
(Select Coalesce(Sum(Cantidad * Contenido),0) as AReparaciones from Libregco_Main.ReparacionDetalle INNER JOIN Libregco_Main.Reparacion on ReparacionDetalle.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.precioarticulo on ReparacionDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and ReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and ReparacionDetalle.IDPrecio='" + IDPrecio.ToString + "' and Reparacion.IDAlmacen='1' and Reparacion.IDTipoOrden=1 and Reparacion.Nulo=0) as AReparaciones,
(Select Coalesce(Sum(CantidadRecibida * Contenido),0) as AReparacionesRecibidas from Libregco_Main.EntradaReparaciondetalle INNER JOIN Libregco_Main.EntradaReparacion on EntradaReparaciondetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Libregco.precioarticulo on EntradaReparaciondetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco_Main.Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and EntradaReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and EntradaReparacionDetalle.IDPrecio='" + IDPrecio.ToString + "' and EntradaReparacion.IDAlmacen='1' and EntradaReparacion.Nulo=0 and Reparacion.Nulo=0) as AReparacionesRecibidas", ConTemporal)
            Dim A As Double = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("UPDATE Libregco.Existencia SET Existencia='" + (A + Z).ToString + "' Where IDAlmacen='" + dt.Item("IDAlmacen").ToString + "' and IDPrecioArticulo='" + IDPrecio.ToString + "'", ConTemporal)
            cmd.ExecuteNonQuery()

        Next

        Ds.Dispose()

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        'End Try
    End Function

    Function FunctCalcInvAlmacenes(ByVal IDArticulo As Integer, ByVal IDPrecio As Integer)
        '\\Usar este evento para calcular los inventarios en cada almacen, debe utilarze con un for each rows, asignado el valor de la columna de articulo y del precio (CodigoArticulo=cdbl(row.cells(6).value)
        Try
            Dim y As Integer = 0
            Dim IDAlmacen, CantidadAdq, CantidadVend, Entradas, Salidas, TransfSalidas, TransfEntradas, DevolucionesVenta, DevolucionesCompra, Reparaciones, ReparacionRecibida, Total As New Label

            Ds.Clear()
            ConTemporal.Open()
            cmd = New MySqlCommand("SELECT IDAlmacen,Almacen,Desactivar FROM" & SysName.Text & "Almacen WHERE Desactivar=0", ConTemporal)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Almacen")
            ConTemporal.Close()

            Dim TablaAlm As DataTable = Ds.Tables("Almacen")
Almacen:
            If y = TablaAlm.Rows.Count Then
                GoTo Fin
            Else
                IDAlmacen.Text = (TablaAlm.Rows(y).Item("IDAlmacen"))
            End If

            ConTemporal.Open()

            'Buscando en Z
            'Entradas
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) from Libregco.Movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE Movimientoinvdetalle.IDAlmacen='" + IDAlmacen.Text + "' AND MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDPrecio='" + IDPrecio.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=1 AND movimientoinventario.Nulo=0", ConTemporal)
            Entradas.Text = Convert.ToString(cmd.ExecuteScalar())

            'Salidas
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) from Libregco.Movimientoinvdetalle INNER JOIN Libregco.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE Movimientoinvdetalle.IDAlmacen='" + IDAlmacen.Text + "' AND MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDPrecio='" + IDPrecio.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=2 AND movimientoinventario.Nulo=0", ConTemporal)
            Salidas.Text = Convert.ToString(cmd.ExecuteScalar())

            'Compras
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado from Libregco.DetalleCompra INNER JOIN Libregco.Compras on DetalleCompra.IDCompra=compras.IDCompra INNER JOIN Libregco.precioarticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios Where DetalleCompra.IDAlmacen='" + IDAlmacen.Text + "' AND DetalleCompra.IDArticulo='" + IDArticulo.ToString + "' AND IDPrecio='" + IDPrecio.ToString + "' AND Compras.Nulo=0", ConTemporal)
            CantidadAdq.Text = Convert.ToString(cmd.ExecuteScalar())

            'Ventas
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado from Libregco.FacturaArticulos INNER JOIN Libregco.FacturaDatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.precioarticulo on facturaarticulos.IDPrecio=PrecioArticulo.IDPrecios Where FacturaArticulos.IDAlmacen='" + IDAlmacen.Text + "' AND FacturaArticulos.IDArticulo='" + IDArticulo.ToString + "' AND IDPrecio='" + IDPrecio.ToString + "' AND FacturaDatos.Nulo=0", ConTemporal)
            CantidadVend.Text = Convert.ToString(cmd.ExecuteScalar())

            'Transferencias de Salidas
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado From Libregco.transferenciaartdetalle INNER JOIN Libregco.transfenciaarticulos on transferenciaartdetalle.IDTransferenciaArticulo=transfenciaarticulos.IDTransferenciaArt INNER JOIN Libregco.precioarticulo on TransferenciaArtDetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE IDAlmacenSalida='" + IDAlmacen.Text + "' and transferenciaartdetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and transfenciaarticulos.Nulo=0", ConTemporal)
            TransfSalidas.Text = Convert.ToString(cmd.ExecuteScalar())

            'Transferencias de Entradas
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado From Libregco.transferenciaartdetalle INNER JOIN Libregco.transfenciaarticulos on transferenciaartdetalle.IDTransferenciaArticulo=transfenciaarticulos.IDTransferenciaArt INNER JOIN Libregco.precioarticulo on TransferenciaArtDetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE IDAlmacenEntrada='" + IDAlmacen.Text + "' and transferenciaartdetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and transfenciaarticulos.Nulo=0", ConTemporal)
            TransfEntradas.Text = Convert.ToString(cmd.ExecuteScalar())

            'Devoluciones de Ventas
            cmd = New MySqlCommand("Select Coalesce(Sum(CantDevuelta * Contenido),0) as Resultado from Libregco.Devolucionventadetalle INNER JOIN Libregco.devolucionventa on devolucionventadetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta INNER JOIN Libregco.facturadatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.precioarticulo on DevolucionVentaDetalle.IDPrecio=PrecioArticulo.IDPrecios Where Devolucionventadetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and Devolucionventadetalle.IDAlmacen='" + IDAlmacen.Text + "' and DevolucionVenta.Nulo=0", ConTemporal)
            DevolucionesVenta.Text = Convert.ToString(cmd.ExecuteScalar())

            'Devoluciones en Compras
            cmd = New MySqlCommand("Select Coalesce(Sum(CantDevuelta * Contenido),0) as Resultado from Libregco.DevolucionCompradetalle INNER JOIN Libregco.devolucionCompra on devolucionCompradetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra INNER JOIN Libregco.Compras on DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN Libregco.precioarticulo on DevolucionCompraDetalle.IDPrecio=PrecioArticulo.IDPrecios Where DevolucionCompradetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and DevolucionCompradetalle.IDAlmacen='" + IDAlmacen.Text + "' and DevolucionCompra.Nulo=0", ConTemporal)
            DevolucionesCompra.Text = Convert.ToString(cmd.ExecuteScalar())

            'Reparaciones que afectan el inventario
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado from Libregco.ReparacionDetalle INNER JOIN Libregco.Reparacion on ReparacionDetalle.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.precioarticulo on ReparacionDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and ReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and ReparacionDetalle.IDPrecio='" + IDPrecio.ToString + "' and Reparacion.IDAlmacen='" + IDAlmacen.Text + "' and Reparacion.IDTipoOrden=1 and Reparacion.Nulo=0", ConTemporal)
            Reparaciones.Text = Convert.ToString(cmd.ExecuteScalar())

            'Reparaciones recibidas
            cmd = New MySqlCommand("Select Coalesce(Sum(CantidadRecibida * Contenido),0) as Resultado from Libregco.EntradaReparaciondetalle INNER JOIN Libregco.EntradaReparacion on EntradaReparaciondetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Libregco.precioarticulo on EntradaReparaciondetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and EntradaReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and EntradaReparacionDetalle.IDPrecio='" + IDPrecio.ToString + "' and EntradaReparacion.IDAlmacen='" + IDAlmacen.Text + "' and EntradaReparacion.Nulo=0 and Reparacion.Nulo=0", ConTemporal)
            ReparacionRecibida.Text = Convert.ToString(cmd.ExecuteScalar())

            Total.Text = CDbl(CantidadAdq.Text) - CDbl(CantidadVend.Text) + CDbl(Salidas.Text) - CDbl(TransfSalidas.Text) + CDbl(Entradas.Text) + CDbl(TransfEntradas.Text) + CDbl(DevolucionesVenta.Text) - CDbl(DevolucionesCompra.Text) - CDbl(Reparaciones.Text) + CDbl(ReparacionRecibida.Text)
            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            'Buscando en A
            'Entradas
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) from Libregco_Main.Movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE Movimientoinvdetalle.IDAlmacen='" + IDAlmacen.Text + "' AND MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDPrecio='" + IDPrecio.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=1 AND movimientoinventario.Nulo=0", ConTemporal)
            Entradas.Text = Convert.ToString(cmd.ExecuteScalar())

            'Salidas
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) from Libregco_Main.Movimientoinvdetalle INNER JOIN Libregco_Main.movimientoinventario on movimientoinvdetalle.IDMovimientoInventario=movimientoinventario.IDAjusteInventario INNER JOIN Libregco.precioarticulo on MovimientoInvDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.tipodeajuste on movimientoinvdetalle.IDTipoAjusteDetalle=TipodeAjuste.IDAjusteInventario WHERE Movimientoinvdetalle.IDAlmacen='" + IDAlmacen.Text + "' AND MovimientoinvDetalle.IDArticulo='" + IDArticulo.ToString + "' AND MovimientoinvDetalle.IDPrecio='" + IDPrecio.ToString + "' AND MovimientoinvDetalle.IDTipoAjusteDetalle=1 AND movimientoinventario.Nulo=0", ConTemporal)
            Salidas.Text = Convert.ToString(cmd.ExecuteScalar())

            'Compras
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado from Libregco_Main.DetalleCompra INNER JOIN Libregco_Main.Compras on DetalleCompra.IDCompra=compras.IDCompra INNER JOIN Libregco.precioarticulo on DetalleCompra.IDPrecio=PrecioArticulo.IDPrecios Where DetalleCompra.IDAlmacen='" + IDAlmacen.Text + "' AND DetalleCompra.IDArticulo='" + IDArticulo.ToString + "' AND IDPrecio='" + IDPrecio.ToString + "' AND Compras.Nulo=0", ConTemporal)
            CantidadAdq.Text = Convert.ToString(cmd.ExecuteScalar())

            'Ventas
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado from Libregco_Main.FacturaArticulos INNER JOIN Libregco_Main.FacturaDatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.precioarticulo on facturaarticulos.IDPrecio=PrecioArticulo.IDPrecios Where FacturaArticulos.IDAlmacen='" + IDAlmacen.Text + "' AND FacturaArticulos.IDArticulo='" + IDArticulo.ToString + "' AND IDPrecio='" + IDPrecio.ToString + "' AND FacturaDatos.Nulo=0", ConTemporal)
            CantidadVend.Text = Convert.ToString(cmd.ExecuteScalar())

            'Transferencias de Salidas
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado From Libregco_Main.transferenciaartdetalle INNER JOIN Libregco_Main.transfenciaarticulos on transferenciaartdetalle.IDTransferenciaArticulo=transfenciaarticulos.IDTransferenciaArt INNER JOIN Libregco.precioarticulo on TransferenciaArtDetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE IDAlmacenSalida='" + IDAlmacen.Text + "' and transferenciaartdetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and transfenciaarticulos.Nulo=0", ConTemporal)
            TransfSalidas.Text = Convert.ToString(cmd.ExecuteScalar())

            'Transferencias de Entradas
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado From Libregco_Main.transferenciaartdetalle INNER JOIN Libregco_Main.transfenciaarticulos on transferenciaartdetalle.IDTransferenciaArticulo=transfenciaarticulos.IDTransferenciaArt INNER JOIN Libregco.precioarticulo on TransferenciaArtDetalle.IDPrecio=PrecioArticulo.IDPrecios WHERE IDAlmacenEntrada='" + IDAlmacen.Text + "' and transferenciaartdetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and transfenciaarticulos.Nulo=0", ConTemporal)
            TransfEntradas.Text = Convert.ToString(cmd.ExecuteScalar())

            'Devoluciones de Ventas
            cmd = New MySqlCommand("Select Coalesce(Sum(CantDevuelta * Contenido),0) as Resultado from Libregco_Main.Devolucionventadetalle INNER JOIN Libregco_Main.devolucionventa on devolucionventadetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta INNER JOIN Libregco_Main.facturadatos on DevolucionVenta.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.precioarticulo on DevolucionVentaDetalle.IDPrecio=PrecioArticulo.IDPrecios Where Devolucionventadetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and Devolucionventadetalle.IDAlmacen='" + IDAlmacen.Text + "' and DevolucionVenta.Nulo=0", ConTemporal)
            DevolucionesVenta.Text = Convert.ToString(cmd.ExecuteScalar())

            'Devoluciones en Compras
            cmd = New MySqlCommand("Select Coalesce(Sum(CantDevuelta * Contenido),0) as Resultado from Libregco_Main.DevolucionCompradetalle INNER JOIN Libregco_Main.devolucionCompra on devolucionCompradetalle.IDDevolucionCompra=DevolucionCompra.IDDevolucionCompra INNER JOIN Libregco_Main.Compras on DevolucionCompra.IDFactura=Compras.IDCompra INNER JOIN Libregco.precioarticulo on DevolucionCompraDetalle.IDPrecio=PrecioArticulo.IDPrecios Where DevolucionCompradetalle.IDArticulo='" + IDArticulo.ToString + "' and IDPrecio='" + IDPrecio.ToString + "' and DevolucionCompradetalle.IDAlmacen='" + IDAlmacen.Text + "' and DevolucionCompra.Nulo=0", ConTemporal)
            DevolucionesCompra.Text = Convert.ToString(cmd.ExecuteScalar())

            'Reparaciones que afectan el inventario
            cmd = New MySqlCommand("Select Coalesce(Sum(Cantidad * Contenido),0) as Resultado from Libregco_Main.ReparacionDetalle INNER JOIN Libregco_Main.Reparacion on ReparacionDetalle.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.precioarticulo on ReparacionDetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and ReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and ReparacionDetalle.IDPrecio='" + IDPrecio.ToString + "' and Reparacion.IDAlmacen='" + IDAlmacen.Text + "' and Reparacion.IDTipoOrden=1 and Reparacion.Nulo=0", ConTemporal)
            Reparaciones.Text = Convert.ToString(cmd.ExecuteScalar())

            'Reparaciones recibidas
            cmd = New MySqlCommand("Select Coalesce(Sum(CantidadRecibida * Contenido),0) as Resultado from Libregco_Main.EntradaReparaciondetalle INNER JOIN Libregco_Main.EntradaReparacion on EntradaReparaciondetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Libregco.precioarticulo on EntradaReparaciondetalle.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco_Main.Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN Libregco.tipoordenreparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion Where TipoOrdenReparacion.AfectaInventario=1 and EntradaReparacionDetalle.IDArticulo='" + IDArticulo.ToString + "' and EntradaReparacionDetalle.IDPrecio='" + IDPrecio.ToString + "' and EntradaReparacion.IDAlmacen='" + IDAlmacen.Text + "' and EntradaReparacion.Nulo=0 and Reparacion.Nulo=0", ConTemporal)
            ReparacionRecibida.Text = Convert.ToString(cmd.ExecuteScalar())

            Total.Text = CDbl(Total.Text) + CDbl(CantidadAdq.Text) - CDbl(CantidadVend.Text) + CDbl(Salidas.Text) - CDbl(TransfSalidas.Text) + CDbl(Entradas.Text) + CDbl(TransfEntradas.Text) + CDbl(DevolucionesVenta.Text) - CDbl(DevolucionesCompra.Text) - CDbl(Reparaciones.Text) + CDbl(ReparacionRecibida.Text)

            cmd = New MySqlCommand("UPDATE Libregco.Existencia SET Existencia='" + Total.Text + "' Where IDAlmacen='" + IDAlmacen.Text + "' and IDPrecioArticulo='" + IDPrecio.ToString + "'", ConTemporal)
            cmd.ExecuteNonQuery()
            ConTemporal.Close()

            y = y + 1
            GoTo Almacen
Fin:
        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)

        End Try

    End Function

    Function InsertException(ByVal Formulario As String, ByVal Metodo As String, ByVal Descripcion As String, ByVal Metodobase As String, ByVal Enlace As String, ByVal ImagePath As Control)
        Try

            'frm_LoginSistema.ToastNotificationsManager1.ShowNotification(frm_LoginSistema.ToastNotificationsManager1.Notifications(1))

            Dim SQLException As String

            ConErrores.Open()
            Dim RutaFile As String = TakeFullScreenshotUNC(ImagePath)
            SQLException = "INSERT INTO Errores (Fecha,Formulario,Metodo,Descripcion,MetodoBase,Enlace,IDVersion,Imagen) VALUES (Now(),'" + Formulario + "','" + Metodo + "','" + Replace(Descripcion, "'", "*") + "','" + Metodobase + "','" + Enlace + "','" + IDBuild.Text + "','" + RutaFile + "')"
            CMDErrores = New MySqlCommand(SQLException, ConErrores)
            CMDErrores.ExecuteNonQuery()
            ConErrores.Close()


            Con.Close()
            ConLibregco.Close()
            ConMixta.Close()
            ConLibregcoMain.Close()


            If Descripcion.Contains("Unable to connect to any of the specified MySQL hosts") Then
                MessageBox.Show("No se ha encontrado la conexión con el servidor. Por favor verifique la conexión de RED de este equipo.")
            End If

            MessageBox.Show("En el procedimiento " & Metodo & " se ha producido un error." & vbNewLine & vbNewLine & Descripcion & vbNewLine & vbNewLine & Metodobase, "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)

            'Envío de errores por correo
            If My.Computer.Network.IsAvailable = True Then
                Correos.To.Clear()
                Correos.Subject = "Reporte de Errores: " & frm_inicio.lblRazon.Text
                Correos.IsBodyHtml = True
                Correos.Body = "<h3>ALERTA: Reporte de error/bugs Libregco.</h3><hr /><p>Se ha producido un error en la sesi&oacute;n del usuario <strong>" + frm_inicio.lblNombre.Text + "</strong>, en el equipo <strong>" + frm_inicio.Button4.Text + "</strong> &nbsp; de <strong>" + frm_inicio.lblRazon.Text + "</strong> en fecha <strong> " + Now.ToString("dd/MM/yyyy hh:mm:ss tt") + "</strong>.</p><p>Los datos recolectados son los siguientes:</p><p>Formulario: " + Formulario + "</p><p>M&eacute;todo: " + Metodo + "</p> <p>M&eacute;todo base: " + Metodobase + ".</p> <p>&nbsp;</p> <p><strong>Descripci&oacute;n</strong></p> <p>" + Descripcion + ".</p><p>&nbsp;</p><p><span style='text-decoration: underline;'><strong>Variables del entorno.</strong></span></p> <p><strong>Estado de las conexiones:</strong></p><ul> <li>Conexi&oacute;n local: " + Con.State.ToString + "</li> <li>Conexi&oacute;n principal: " + ConLibregcoMain.State.ToString + "</li><li>Conexi&oacute;n mixta: " + ConMixta.State.ToString + "</li><li>Conexi&oacute;n Utilitarios: " + ConUtilitarios.State.ToString + "</li></ul><p>&nbsp;</p><hr /><p>Versi&oacute;n de la aplicaci&oacute;n: " + frm_inicio.Label2.Text + "</p>"
                Correos.From = New System.Net.Mail.MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var"), DTConfiguracion.Rows(36 - 1).Item("Value1Var"), System.Text.Encoding.UTF8)
                Correos.Priority = System.Net.Mail.MailPriority.Normal
                Correos.To.Add(Trim(DTConfiguracion.Rows(36 - 1).Item("Value1Var")))
                Correos.Attachments.Clear()
                Dim Attach As New System.Net.Mail.Attachment(RutaFile)
                Correos.Attachments.Add(Attach)

                Correos.From = New MailAddress(DTConfiguracion.Rows(36 - 1).Item("Value1Var"))
                Envios.Credentials = New NetworkCredential(DTConfiguracion.Rows(36 - 1).Item("Value1Var").ToString, DTConfiguracion.Rows(37 - 1).Item("Value1Var").ToString)

                Envios.Host = "smtp.gmail.com"
                Envios.Port = 587
                Envios.EnableSsl = True
                Envios.Send(Correos)

                Attach.Dispose()
            End If


            Return Nothing

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try
    End Function

    Function GetFileSizes(ByVal Path As String)
        If TypeConnection.Text = 1 Then
            Dim ExistFile As Boolean = System.IO.File.Exists(Path)
            If ExistFile = True Then
                Dim infoReader As System.IO.FileInfo
                infoReader = My.Computer.FileSystem.GetFileInfo(Path)

                Return (Math.Round((infoReader.Length / 1024), 0))
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function

    Function GetIfBlockedNCFS(ByVal IDNCF As String)
        Try
            Dim Serie, General, Hasta, Ultimo As New Label

            'Con.Open()
            'cmd = New MySqlCommand("Select Value2Int FROM configuracion Where IDConfiguracion=75", Con)
            Dim TypeOfMetod As String = DTConfiguracion.Rows(75 - 1).Item("Value2Int")
            'Con.Close()

            If TypeOfMetod = 1 Then

                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("Select IDComprobanteFiscal,Serie,TipoComprobante,Inicial,Hasta,Ultimo from ComprobanteFiscal where IDComprobanteFiscal='" + IDNCF.ToString + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "ComprobanteFiscal")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")

                Serie.Text = (Tabla.Rows(0).Item("Serie"))
                General.Text = (Tabla.Rows(0).Item("Inicial"))
                Hasta.Text = (Tabla.Rows(0).Item("Hasta"))
                Ultimo.Text = CDbl(Tabla.Rows(0).Item("Ultimo"))

                If IsNumeric(Tabla.Rows(0).Item("Hasta")) Then
                    Dim Restantes As Integer = CInt(Tabla.Rows(0).Item("Hasta")) - CInt(Tabla.Rows(0).Item("Ultimo"))
                    Dim LimiteMinimoCantNCF As Integer

                    'Con.Open()
                    'cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=12", Con)
                    LimiteMinimoCantNCF = DTConfiguracion.Rows(12 - 1).Item("Value2Int")
                    'Con.Close()

                    If Restantes <= LimiteMinimoCantNCF Then
                        If Restantes <= 0 Then
                            'Con.Open()
                            'cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=24", Con)
                            Dim FactNCFAgotado As String = DTConfiguracion.Rows(24 - 1).Item("Value2Int")
                            'Con.Close()

                            If FactNCFAgotado = 0 Then
                                MessageBox.Show("El sistema tiene bloqueado el procesamiento de facturas con comprobantes fiscales agotados.", "Configuración de NCF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                ControlSuperClave = 1
                                Exit Function
                            End If
                        End If
                    Else
                        ControlSuperClave = 0
                    End If
                End If


            ElseIf TypeOfMetod = 2 Then

                'Método personalizado de estructuración
                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDAreaImpresionNCF,AreaImpresionNCF.IDAreaImpresion,Serie,DivisionNegocio,Almacen.PuntoEmision,AreaImpresion.NodeImpresion,NoTCF,AreaImpresionNCF.Actual,AreaImpresionNCF.Inicial,AreaImpresionNCF.Final,ComprobanteFiscal.TipoComprobante FROM areaimpresionncf INNER JOIN AreaImpresion on AreaImpresionNCF.IDAreaImpresion=AreaImpresion.IDEquipo INNER JOIN Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN ComprobanteFiscal on AreaImpresionNCF.IDNCF=ComprobanteFiscal.IDComprobanteFiscal Where IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "' and IDNCF='" + IDNCF.ToString + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "ComprobanteFiscal")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")
                Dim IDAreaImpresionNCF As New Label

                If IsNumeric(Tabla.Rows(0).Item("Final")) = "" Then
                    Dim Restantes As Integer = CInt(Tabla.Rows(0).Item("Final")) - CInt(Tabla.Rows(0).Item("Actual"))
                    Dim LimiteMinimoCantNCF As Integer

                    'Con.Open()
                    'cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=12", Con)
                    LimiteMinimoCantNCF = DTConfiguracion.Rows(12 - 1).Item("Value2Int")
                    'Con.Close()

                    If Restantes <= LimiteMinimoCantNCF Then
                        If Restantes <= 0 Then
                            'Con.Open()
                            'cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=24", Con)
                            Dim FactNCFAgotado As String = DTConfiguracion.Rows(24 - 1).Item("Value2Int")
                            'Con.Close()

                            If FactNCFAgotado = 0 Then
                                MessageBox.Show("El sistema tiene bloqueado el procesamiento de facturas con comprobantes fiscales agotados.", "Configuración de NCF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                ControlSuperClave = 1
                                Exit Function
                            End If

                        End If

                    Else
                        ControlSuperClave = 0
                    End If
                End If


            ElseIf TypeOfMetod = 3 Then

                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("Select IDComprobanteFiscal,Serie,NoTCF,TipoComprobante,Inicial,Hasta,Ultimo from ComprobanteFiscal where IDComprobanteFiscal='" + IDNCF.ToString + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "ComprobanteFiscal")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")

                Serie.Text = (Tabla.Rows(0).Item("Serie"))
                General.Text = (Tabla.Rows(0).Item("NoTCF"))
                Hasta.Text = (Tabla.Rows(0).Item("Hasta"))
                Ultimo.Text = CDbl(Tabla.Rows(0).Item("Ultimo"))

                If IsNumeric(Tabla.Rows(0).Item("Hasta")) Then
                    Dim Restantes As Integer = CInt(Tabla.Rows(0).Item("Hasta")) - CInt(Tabla.Rows(0).Item("Ultimo"))
                    Dim LimiteMinimoCantNCF As Integer

                    'Con.Open()
                    'cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=12", Con)
                    LimiteMinimoCantNCF = DTConfiguracion.Rows(12 - 1).Item("Value2Int")
                    'Con.Close()

                    If Restantes <= LimiteMinimoCantNCF Then
                        If Restantes <= 0 Then
                            'Con.Open()
                            'cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=24", Con)
                            Dim FactNCFAgotado As String = DTConfiguracion.Rows(24 - 1).Item("Value2Int")
                            'Con.Close()

                            If FactNCFAgotado = 0 Then
                                MessageBox.Show("El sistema tiene bloqueado el procesamiento de facturas con comprobantes fiscales agotados.", "Configuración de NCF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                ControlSuperClave = 1
                                Exit Function
                            End If
                        Else
                            ControlSuperClave = 0
                        End If
                    Else
                        ControlSuperClave = 0
                    End If
                End If
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try
    End Function

    Function GetNCFsNumbers(ByVal IDNCF As String)
        Try
            Dim Serie, General, Hasta, Ultimo As New Label
            Dim UltimoNCF As String

            'Con.Open()
            'cmd = New MySqlCommand("SELECT Value2Int FROM configuracion Where IDConfiguracion=75", Con)
            Dim TypeOfMetod As String = DTConfiguracion.Rows(75 - 1).Item("Value2Int")
            'Con.Close()

            If TypeOfMetod = 1 Then

                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("Select IDComprobanteFiscal,Serie,TipoComprobante,Inicial,Hasta,Ultimo from ComprobanteFiscal where IDComprobanteFiscal='" + IDNCF.ToString + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "ComprobanteFiscal")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")

                Serie.Text = (Tabla.Rows(0).Item("Serie"))
                General.Text = (Tabla.Rows(0).Item("Inicial"))
                Hasta.Text = (Tabla.Rows(0).Item("Hasta"))
                Ultimo.Text = CDbl(Tabla.Rows(0).Item("Ultimo"))

                If IsNumeric(Tabla.Rows(0).Item("Hasta")) Then
                    Dim Restantes As Integer = CInt(Tabla.Rows(0).Item("Hasta")) - CInt(Tabla.Rows(0).Item("Ultimo"))
                    Dim LimiteMinimoCantNCF As Integer

                    'Con.Open()
                    'cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=12", Con)
                    LimiteMinimoCantNCF = DTConfiguracion.Rows(12 - 1).Item("Value2Int")
                    'Con.Close()

                    If Restantes <= LimiteMinimoCantNCF Then
                        If Restantes <= 0 Then
                            'Con.Open()
                            'cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=24", Con)
                            Dim FactNCFAgotado As String = DTConfiguracion.Rows(24 - 1).Item("Value2Int")
                            'Con.Close()

                            If FactNCFAgotado = 0 Then
                                MessageBox.Show("El sistema tiene bloqueado el procesamiento de facturas con comprobantes fiscales agotados.", "Configuración de NCF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                ControlSuperClave = 1
                                Exit Function
                            End If

                            Dim Result As MsgBoxResult = MessageBox.Show("Los NCF del tipo " & (Tabla.Rows(0).Item("TipoComprobante")) & " se han agotado. " & vbNewLine & "Está seguro que desea generar la factura?", "Generar Factura con NCF Agotado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            If Result = MsgBoxResult.Yes Then
                                MessageBox.Show("El sistema seguirá generando los comprobantes fiscales siguientes. Solicite inmediatamente a la DGII los correspondientes comprobantes fiscales.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                                ControlSuperClave = 0
                            Else
                                ControlSuperClave = 1
                                Exit Function
                            End If
                        Else
                            MessageBox.Show("ADVERTENCIA: Solo quedan " & Restantes & " comprobantes disponibles del tipo " & (Tabla.Rows(0).Item("TipoComprobante")) & "." & vbNewLine & "Solicite a la DGII los correspondientes comprobantes fiscales.", "Advertencia de NCF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            ControlSuperClave = 0
                        End If
                    Else
                        ControlSuperClave = 0
                    End If
                End If

                If ControlSuperClave = 0 Then
                    UltimoNCF = CDbl(Ultimo.Text) + CDbl(1)

                    NewNCFValue.Text = Serie.Text & General.Text & (UltimoNCF.PadLeft(8, "0"))

                    Con.Open()
                    sqlQ = "UPDATE ComprobanteFiscal SET Ultimo='" + UltimoNCF + "' Where IDComprobanteFiscal='" + IDNCF.ToString + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    Con.Close()

                    Return NewNCFValue.Text
                End If


            ElseIf TypeOfMetod = 2 Then

                'Método personalizado de estructuración
                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("SELECT IDAreaImpresionNCF,AreaImpresionNCF.IDAreaImpresion,Serie,DivisionNegocio,Almacen.PuntoEmision,AreaImpresion.NodeImpresion,NoTCF,AreaImpresionNCF.Actual,AreaImpresionNCF.Inicial,AreaImpresionNCF.Final,ComprobanteFiscal.TipoComprobante FROM areaimpresionncf INNER JOIN AreaImpresion on AreaImpresionNCF.IDAreaImpresion=AreaImpresion.IDEquipo INNER JOIN Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN ComprobanteFiscal on AreaImpresionNCF.IDNCF=ComprobanteFiscal.IDComprobanteFiscal Where IDAreaImpresion='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "' and IDNCF='" + IDNCF.ToString + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "ComprobanteFiscal")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")
                Dim IDAreaImpresionNCF As New Label

                If IsNumeric(Tabla.Rows(0).Item("Final")) = "" Then
                    Dim Restantes As Integer = CInt(Tabla.Rows(0).Item("Final")) - CInt(Tabla.Rows(0).Item("Actual"))
                    Dim LimiteMinimoCantNCF As Integer

                    'Con.Open()
                    'cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=12", Con)
                    LimiteMinimoCantNCF = DTConfiguracion.Rows(12 - 1).Item("Value2Int")
                    'Con.Close()

                    If Restantes <= LimiteMinimoCantNCF Then

                        If Restantes <= 0 Then
                            'Con.Open()
                            'cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=24", Con)
                            Dim FactNCFAgotado As String = DTConfiguracion.Rows(24 - 1).Item("Value2Int")
                            'Con.Close()

                            If FactNCFAgotado = 0 Then
                                MessageBox.Show("El sistema tiene bloqueado el procesamiento de facturas con comprobantes fiscales agotados.", "Configuración de NCF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                ControlSuperClave = 1
                                Exit Function
                            End If

                            Dim Result As MsgBoxResult = MessageBox.Show("Los NCF del tipo " & (Tabla.Rows(0).Item("TipoComprobante")) & " se han agotado. " & vbNewLine & "Está seguro que desea generar la factura?", "Generar Factura con NCF Agotado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            If Result = MsgBoxResult.Yes Then
                                MessageBox.Show("El sistema seguirá generando los comprobantes fiscales siguientes. Solicite inmediatamente a la DGII los correspondientes comprobantes fiscales.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                                ControlSuperClave = 0
                            Else
                                ControlSuperClave = 1
                                Exit Function
                            End If
                        Else
                            MessageBox.Show("ADVERTENCIA: Solo quedan " & Restantes & " comprobantes disponibles del tipo " & (Tabla.Rows(0).Item("TipoComprobante")) & "." & vbNewLine & "Solicite a la DGII los correspondientes comprobantes fiscales.", "Advertencia de NCF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            ControlSuperClave = 0
                        End If

                    Else
                        ControlSuperClave = 0
                    End If
                End If


                If ControlSuperClave = 0 Then
                    IDAreaImpresionNCF.Text = (Tabla.Rows(0).Item("IDAreaImpresionNCF"))
                    UltimoNCF = CDbl(Tabla.Rows(0).Item("Actual")) + CDbl(1)
                    NewNCFValue.Text = (Tabla.Rows(0).Item("Serie")) & (Tabla.Rows(0).Item("DivisionNegocio")) & (Tabla.Rows(0).Item("PuntoEmision")) & (Tabla.Rows(0).Item("NodeImpresion")) & (Tabla.Rows(0).Item("NoTCF") & (Tabla.Rows(0).Item("Actual")).PadLeft(8, "0"))

                    Con.Open()
                    sqlQ = "UPDATE AreaImpresionNCF SET Actual='" + UltimoNCF + "' Where IDAreaImpresionNCF='" + IDAreaImpresionNCF.Text + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    Con.Close()
                    Return NewNCFValue.Text
                End If

            ElseIf TypeOfMetod = 3 Then

                Ds.Clear()
                Con.Open()
                cmd = New MySqlCommand("Select IDComprobanteFiscal,Serie,NoTCF,TipoComprobante,Inicial,Hasta,Ultimo,Longitud from ComprobanteFiscal where IDComprobanteFiscal='" + IDNCF.ToString + "'", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "ComprobanteFiscal")
                Con.Close()

                Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")

                Serie.Text = (Tabla.Rows(0).Item("Serie"))
                General.Text = (Tabla.Rows(0).Item("NoTCF"))
                Hasta.Text = (Tabla.Rows(0).Item("Hasta"))
                Ultimo.Text = CDbl(Tabla.Rows(0).Item("Ultimo"))

                If IsNumeric(Tabla.Rows(0).Item("Hasta")) Then
                    Dim Restantes As Integer = CInt(Tabla.Rows(0).Item("Hasta")) - CInt(Tabla.Rows(0).Item("Ultimo"))
                    Dim LimiteMinimoCantNCF As Integer

                    'Con.Open()
                    'cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=12", Con)
                    LimiteMinimoCantNCF = DTConfiguracion.Rows(12 - 1).Item("Value2Int")
                    'Con.Close()

                    If Restantes <= LimiteMinimoCantNCF Then
                        If Restantes <= 0 Then
                            'Con.Open()
                            'cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=24", Con)
                            Dim FactNCFAgotado As String = DTConfiguracion.Rows(24 - 1).Item("Value2Int")
                            'Con.Close()

                            If FactNCFAgotado = 0 Then
                                MessageBox.Show("El sistema tiene bloqueado el procesamiento de facturas con comprobantes fiscales agotados.", "Configuración de NCF", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                ControlSuperClave = 1
                                Exit Function
                            End If

                            Dim Result As MsgBoxResult = MessageBox.Show("Los NCF del tipo " & (Tabla.Rows(0).Item("TipoComprobante")) & " se han agotado. " & vbNewLine & "Está seguro que desea generar la factura?", "Generar Factura con NCF Agotado", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            If Result = MsgBoxResult.Yes Then
                                MessageBox.Show("El sistema seguirá generando los comprobantes fiscales siguientes. Solicite inmediatamente a la DGII los correspondientes comprobantes fiscales.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                                ControlSuperClave = 0
                            Else
                                ControlSuperClave = 1
                                Exit Function
                            End If
                        Else
                            MessageBox.Show("ADVERTENCIA: Sólo quedan " & Restantes & " comprobantes disponibles del tipo " & (Tabla.Rows(0).Item("TipoComprobante")) & "." & vbNewLine & "Solicite a la DGII los correspondientes comprobantes fiscales.", "Advertencia de NCF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            ControlSuperClave = 0
                        End If
                    Else
                        ControlSuperClave = 0
                    End If
                End If

                If ControlSuperClave = 0 Then
                    UltimoNCF = CDbl(Ultimo.Text) + CDbl(1)
                    'AQUI ES QUE TENGO QUE MODIFICAR
                    NewNCFValue.Text = Serie.Text & General.Text & (UltimoNCF.PadLeft(Tabla.Rows(0).Item("Longitud"), "0"))

                    Con.Open()
                    sqlQ = "UPDATE ComprobanteFiscal SET Ultimo='" + UltimoNCF + "' Where IDComprobanteFiscal='" + IDNCF.ToString + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                    Con.Close()

                    Return NewNCFValue.Text
                End If
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try
    End Function

    Sub CalcBceCerrado(IDFactura As String)
        Try
            Dim MontoAplicado As Double
            Dim DsTmp As New DataSet

            Con.Open()
            cmd = New MySqlCommand("SELECT coalesce(sum(recibosdetalle.Debito+recibosdetalle.Descuento),0) as TotalPagado FROM recibosdetalle INNER JOIN RecibosCobro on RecibosDetalle.IDReciboCobro=RecibosCobro.IDReciboCobro INNER JOIN Pagares on RecibosDetalle.IDPagare=Pagares.IDPagare where Pagares.IDFactura='" + IDFactura + "' and RecibosCobro.Nulo=0 and RecibosCobro.Cierre=1", Con)
            MontoAplicado = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT IDPagare,NoPagare,FechaVencimiento,Monto FROM pagares where IDFactura='" + IDFactura + "' ORDER BY FechaVencimiento ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTmp, "Pagares")

            Dim Tabla As DataTable = DsTmp.Tables("Pagares")

            For Each Fila As DataRow In Tabla.Rows

                If MontoAplicado = 0 Then
                    sqlQ = "UPDATE Pagares SET BalanceCerrado=Monto WHERE IDPagare= '" + Fila.Item(0).ToString + "'"
                    cmd = New MySqlCommand(sqlQ, Con)
                    cmd.ExecuteNonQuery()
                Else
                    If MontoAplicado >= CDbl(Fila.Item(3)) Then
                        sqlQ = "UPDATE Pagares SET BalanceCerrado=0 WHERE IDPagare= '" + Fila.Item(0).ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()

                        MontoAplicado = MontoAplicado - CDbl(Fila.Item(3))
                    Else
                        MontoAplicado = CDbl(Fila.Item(3)) - MontoAplicado
                        sqlQ = "UPDATE Pagares SET BalanceCerrado='" + MontoAplicado.ToString + "' WHERE IDPagare= '" + Fila.Item(0).ToString + "'"
                        cmd = New MySqlCommand(sqlQ, Con)
                        cmd.ExecuteNonQuery()
                        MontoAplicado = 0
                    End If

                End If

            Next

            Con.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try

    End Sub

    Sub CalcularBceCuentaBancaria(IDCuenta As String)
        Try
            Dim Ingresos, Egresos, Total As New Label

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT Coalesce(Sum(Monto),0) FROM" & SysName.Text & "movimientosbanco INNER JOIN Libregco.tipomovbancario on MovimientosBanco.IDTipoMovimientoBanc=TipoMovBancario.IDTipoMovBancario INNER JOIN Libregco.tipofuncion on tipomovbancario.IDTipoFuncion=TipoFuncion.IDTipoFuncion Where TipoMovBancario.IDTipoFuncion=1 and IDCuentaBancaria='" + IDCuenta.ToString + "' and movimientosbanco.fechamovimiento<='" + Today.ToString("yyyy-MM-dd") + "' and MovimientosBanco.Nulo=0", ConMixta)
            Ingresos.Text = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT Coalesce(Sum(Monto),0) FROM" & SysName.Text & "movimientosbanco INNER JOIN Libregco.tipomovbancario on MovimientosBanco.IDTipoMovimientoBanc=TipoMovBancario.IDTipoMovBancario INNER JOIN Libregco.tipofuncion on tipomovbancario.IDTipoFuncion=TipoFuncion.IDTipoFuncion Where TipoMovBancario.IDTipoFuncion=2 and IDCuentaBancaria='" + IDCuenta.ToString + "' and movimientosbanco.fechamovimiento<='" + Today.ToString("yyyy-MM-dd") + "' and MovimientosBanco.Nulo=0", ConMixta)
            Egresos.Text = Convert.ToDouble(cmd.ExecuteScalar())
            ConMixta.Close()

            Total.Text = CDbl(Ingresos.Text) - CDbl(Egresos.Text)

            Con.Open()
            sqlQ = "UPDATE CuentasBancarias SET Balance='" + Total.Text + "' WHERE IDCuenta= '" + IDCuenta.ToString + "'"
            GuardarDatos()
            Con.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try
    End Sub

    Sub InsertarBitacora(IDPermiso As String)
        frm_inicio.lblStatusBar.Text = "Registrando log de usuario."
        Con.Open()
        sqlQ = "INSERT INTO Bitacora (IDEmpleado,IDEquipo,Fecha,IDPermiso,Abierta) VALUES ('" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "','" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + Today.ToString("yyyy-MM-dd") & " " & TimeOfDay.ToString("HH:mm:ss") + "','" + IDPermiso.ToString + "',1)"
        cmd = New MySqlCommand(sqlQ, Con)
        cmd.ExecuteNonQuery()
        Con.Close()

    End Sub

    Function GetRangePrices()
        Dim PreciosAutorizados As New ArrayList

        If DTEmpleado.Rows(0).Item("IDEmpleado").ToString = "" Then
            DTEmpleado.Rows(0).Item("IDEmpleado") = 1
        End If

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDPreciosEmpleados,PrecioA,PrecioB,PrecioC,PrecioD,PrecioBlackFriday FROM preciosempleados Where IDEmpleado='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "precios")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("precios")
        If Tabla.Rows.Count = 0 Then
            PreciosAutorizados.Add("A")
            PreciosAutorizados.Add("B")
        Else

            If Tabla.Rows(0).Item("PrecioA") = "1" Then
                PreciosAutorizados.Add("A")
            End If
            If Tabla.Rows(0).Item("PrecioB") = "1" Then
                PreciosAutorizados.Add("B")
            End If
            If Tabla.Rows(0).Item("PrecioC") = "1" Then
                PreciosAutorizados.Add("C")
            End If
            If Tabla.Rows(0).Item("PrecioD") = "1" Then
                PreciosAutorizados.Add("D")
            End If
            If Tabla.Rows(0).Item("PrecioBlackFriday") = "1" Then

                'Con.Open()

                'Si el viernes negro esta activado
                'cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion WHERE IDConfiguracion=131", Con)
                If CInt(DTConfiguracion.Rows(131 - 1).Item("Value2Int")) = 1 Then

                    'Si ya se liberaron los precios
                    'cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion WHERE IDConfiguracion=132", Con)
                    If CInt(DTConfiguracion.Rows(132 - 1).Item("Value2Int")) = 1 Then

                        'Fecha de Inicio
                        'cmd = New MySqlCommand("SELECT Value4DateTime FROM Configuracion WHERE IDConfiguracion=133", Con)
                        Dim StartDate As Date = CDate(DTConfiguracion.Rows(133 - 1).Item("Value4DateTime"))

                        'Fecha de termino
                        'cmd = New MySqlCommand("SELECT Value4DateTime FROM Configuracion WHERE IDConfiguracion=134", Con)
                        Dim EndDate As Date = CDate(DTConfiguracion.Rows(134 - 1).Item("Value4DateTime"))

                        If DateTime.Now > StartDate And DateTime.Now < EndDate Then
                            PreciosAutorizados.Add("BlackFriday")
                        End If

                    End If

                End If


                'Con.Close()
            End If

        End If

        Return PreciosAutorizados

    End Function

    Function GetPricesWithIDPrecio(ByVal Nivel As String, IDPrecio As String, ByVal IDMoneda As String, Optional TipoPago As Integer = 1, Optional CobrarComision As Integer = 0, Optional PorcentajeComision As Double = 0) As Double
        Dim DsPrecios As New DataSet

        ConTemporal.Open()
        cmd = New MySqlCommand("SELECT IDPrecios,Costo,CostoFinal,PrecioContado,PrecioCredito,Precio3,Precio4,IDMoneda,TasaCompra as TasaArticulo,CobrarComision,PorcentajeComision FROM Libregco.PrecioArticulo INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda WHERE IDPrecios= '" + IDPrecio.ToString + "' and PrecioArticulo.Nulo=0", ConTemporal)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsPrecios, "Precios")

        Dim Tabla As DataTable = DsPrecios.Tables("Precios")

        cmd = New MySqlCommand("SELECT TasaCompra FROM Libregco.tipomoneda where IDTipoMoneda='" + IDMoneda.ToString + "'", ConTemporal)
        Dim TasaFactura As Double = Convert.ToDouble(cmd.ExecuteScalar())
        ConTemporal.Close()

        If TipoPago <> 2 Then
            If Nivel = "A" Then
                Return CDbl(Tabla.Rows(0).Item("PrecioCredito")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            ElseIf Nivel = "B" Then
                Return CDbl(Tabla.Rows(0).Item("PrecioContado")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            ElseIf Nivel = "C" Then
                Return CDbl(Tabla.Rows(0).Item("Precio3")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            ElseIf Nivel = "D" Then
                Return CDbl(Tabla.Rows(0).Item("Precio4")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            ElseIf Nivel = "E" Then
                Return CDbl(Tabla.Rows(0).Item("Costo")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            ElseIf Nivel = "F" Then
                Return (Tabla.Rows(0).Item("CostoFinal")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            ElseIf Nivel = "BlackFriday" Then
                Return CDbl(Tabla.Rows(0).Item("PrecioBlackFriday")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            Else
                Return CDbl(Tabla.Rows(0).Item("PrecioCredito")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            End If

        Else

            If CInt(Tabla.Rows(0).Item("CobrarComision")) = 0 Then

                If Nivel = "A" Then
                    Return CDbl(Tabla.Rows(0).Item("PrecioCredito")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                ElseIf Nivel = "B" Then
                    Return CDbl(Tabla.Rows(0).Item("PrecioContado")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                ElseIf Nivel = "C" Then
                    Return CDbl(Tabla.Rows(0).Item("Precio3")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                ElseIf Nivel = "D" Then
                    Return CDbl(Tabla.Rows(0).Item("Precio4")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                ElseIf Nivel = "E" Then
                    Return CDbl(Tabla.Rows(0).Item("Costo")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                ElseIf Nivel = "F" Then
                    Return (Tabla.Rows(0).Item("CostoFinal")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                ElseIf Nivel = "BlackFriday" Then
                    Return CDbl(Tabla.Rows(0).Item("PrecioBlackFriday")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                Else
                    Return CDbl(Tabla.Rows(0).Item("PrecioCredito")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                End If

            Else
                If Nivel = "A" Then
                    Return CDbl(Tabla.Rows(0).Item("PrecioCredito")) * (1 + CDbl(Tabla.Rows(0).Item("PorcentajeComision"))) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                ElseIf Nivel = "B" Then
                    Return CDbl(Tabla.Rows(0).Item("PrecioContado")) * (1 + CDbl(Tabla.Rows(0).Item("PorcentajeComision"))) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                ElseIf Nivel = "C" Then
                    Return CDbl(Tabla.Rows(0).Item("Precio3")) * (1 + CDbl(Tabla.Rows(0).Item("PorcentajeComision"))) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                ElseIf Nivel = "D" Then
                    Return CDbl(Tabla.Rows(0).Item("Precio4")) * (1 + CDbl(Tabla.Rows(0).Item("PorcentajeComision"))) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                ElseIf Nivel = "E" Then
                    Return CDbl(Tabla.Rows(0).Item("Costo")) * (1 + CDbl(Tabla.Rows(0).Item("PorcentajeComision"))) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                ElseIf Nivel = "F" Then
                    Return (Tabla.Rows(0).Item("CostoFinal")) * (1 + CDbl(Tabla.Rows(0).Item("PorcentajeComision"))) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                ElseIf Nivel = "BlackFriday" Then
                    Return CDbl(Tabla.Rows(0).Item("PrecioBlackFriday")) * (1 + CDbl(Tabla.Rows(0).Item("PorcentajeComision"))) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                Else
                    Return CDbl(Tabla.Rows(0).Item("PrecioCredito")) * (1 + CDbl(Tabla.Rows(0).Item("PorcentajeComision"))) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
                End If
            End If
        End If



    End Function

    Function GetMinimoPrecio(ByVal Nivel As String, ByVal IDArticulo As String, ByVal IDMedida As String, ByVal IDMoneda As String) As Double
        Try
            Dim DsPrecios As New DataSet

            If IDArticulo = "" Then
                MessageBox.Show("El valor retornado del código del producto es nulo.")
                Exit Function
            ElseIf IDMedida = "" Then
                MessageBox.Show("El valor retornado del código de la medida es nulo.")
                Exit Function
            End If

            DsPrecios.Clear()
            ConLibregco.Open()

            cmd = New MySqlCommand("SELECT IDPrecios,DescuentoMaximo,Costo,CostoFinal,PrecioContado,PrecioCredito,Precio3,Precio4,PrecioBlackFriday,IDMoneda,TasaCompra as TasaArticulo FROM PrecioArticulo INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda WHERE Articulos.IDArticulo= '" + IDArticulo.ToString + "' AND PrecioArticulo.IDMedida='" + IDMedida.ToString + "' and PrecioArticulo.Nulo=0", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsPrecios, "Precios")

            Dim Tabla As DataTable = DsPrecios.Tables("Precios")

            cmd = New MySqlCommand("SELECT TasaCompra FROM tipomoneda where IDTipoMoneda='" + IDMoneda.ToString + "'", ConLibregco)
            Dim TasaFactura As Double = Convert.ToDouble(cmd.ExecuteScalar())

            ConLibregco.Close()

            If Nivel = "A" Then
                Return Math.Round((CDbl(CDbl(Tabla.Rows(0).Item("PrecioCredito")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura))) - CDbl(CDbl(CDbl(Tabla.Rows(0).Item("PrecioCredito")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)) * CDbl(Tabla.Rows(0).Item("DescuentoMaximo"))), 2)
            ElseIf Nivel = "B" Then
                Return Math.Round((CDbl(CDbl(Tabla.Rows(0).Item("PrecioContado")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura))) - CDbl(CDbl(CDbl(Tabla.Rows(0).Item("PrecioContado")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)) * CDbl(Tabla.Rows(0).Item("DescuentoMaximo"))), 2)
            ElseIf Nivel = "C" Then
                Return Math.Round(CDbl(Tabla.Rows(0).Item("Precio3")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura), 2)
            ElseIf Nivel = "D" Then
                Return Math.Round(CDbl(Tabla.Rows(0).Item("Precio4")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura), 2)
            ElseIf Nivel = "E" Then
                Return Math.Round(CDbl(Tabla.Rows(0).Item("Costo")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura), 2)
            ElseIf Nivel = "F" Then
                Return Math.Round((Tabla.Rows(0).Item("CostoFinal")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura), 2)
            ElseIf Nivel = "BlackFriday" Then
                Return Math.Round(CDbl(Tabla.Rows(0).Item("PrecioBlackFriday")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura), 2)
            Else
                Return Math.Round((CDbl(CDbl(Tabla.Rows(0).Item("PrecioCredito")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura))) - CDbl(CDbl(CDbl(Tabla.Rows(0).Item("PrecioCredito")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)) * CDbl(Tabla.Rows(0).Item("DescuentoMaximo"))), 2)
            End If

            DsPrecios.Dispose()

        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Function GetAmountinCurrencyConvert(ByVal Amount As Double, ByVal IDMonedaHasta As Double) As Double
        Dim Ds As New DataSet

        Con.Open()

        cmd = New MySqlCommand("SELECT TasaCompra FROM Libregco.tipomoneda where IDTipoMoneda=(Select Value2Int from Libregco.Configuracion Where IDConfiguracion=209)", Con)
        Dim TasaDesde As Double = Convert.ToDouble(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT TasaCompra FROM Libregco.tipomoneda where IDTipoMoneda='" + IDMonedaHasta.ToString + "'", Con)
        Dim TasaHasta As Double = Convert.ToDouble(cmd.ExecuteScalar())

        Con.Close()

        Return Amount * (TasaDesde / TasaHasta)

    End Function
    Function GetPrices(ByVal Nivel As String, ByVal IDArticulo As String, ByVal IDMedida As String, ByVal IDMoneda As String) As Double
        Try
            Dim DsPrecios As New DataSet

            If IDArticulo = "" Then
                MessageBox.Show("El valor retornado del código del producto es nulo.")
                Exit Function
            ElseIf IDMedida = "" Then
                MessageBox.Show("El valor retornado del código de la medida es nulo.")
                Exit Function
            End If

            DsPrecios.Clear()
            ConTemporal.Open()

            'cmd = New MySqlCommand("SELECT Itbis FROM libregco.tipoitbis INNER JOIN Libregco.Articulos on TipoItbis.IDTipoItbis=Articulos.IDItbis where Articulos.IDArticulo='" + IDArticulo.ToString + "'", ConTemporal)
            'Dim Itbis As Double = Convert.ToDouble(cmd.ExecuteScalar())

            cmd = New MySqlCommand("SELECT IDPrecios,Costo,CostoFinal,PrecioContado,PrecioCredito,Precio3,Precio4,PrecioBlackFriday,IDMoneda,TasaCompra as TasaArticulo FROM Libregco.PrecioArticulo INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda WHERE Articulos.IDArticulo= '" + IDArticulo.ToString + "' AND PrecioArticulo.IDMedida='" + IDMedida.ToString + "' and PrecioArticulo.Nulo=0", ConTemporal)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsPrecios, "Precios")

            Dim Tabla As DataTable = DsPrecios.Tables("Precios")

            cmd = New MySqlCommand("SELECT TasaCompra FROM Libregco.tipomoneda where IDTipoMoneda='" + IDMoneda.ToString + "'", ConTemporal)
            Dim TasaFactura As Double = Convert.ToDouble(cmd.ExecuteScalar())

            ConTemporal.Close()

            If Nivel = "A" Then
                Return CDbl(Tabla.Rows(0).Item("PrecioCredito")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            ElseIf Nivel = "B" Then
                Return CDbl(Tabla.Rows(0).Item("PrecioContado")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            ElseIf Nivel = "C" Then
                Return CDbl(Tabla.Rows(0).Item("Precio3")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            ElseIf Nivel = "D" Then
                Return CDbl(Tabla.Rows(0).Item("Precio4")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            ElseIf Nivel = "E" Then
                Return CDbl(Tabla.Rows(0).Item("Costo")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            ElseIf Nivel = "F" Then
                Return (Tabla.Rows(0).Item("CostoFinal")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            ElseIf Nivel = "BlackFriday" Then
                Return CDbl(Tabla.Rows(0).Item("PrecioBlackFriday")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)
            End If

            DsPrecios.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Function

    Function FindSimilaritiesCompras(ByVal IDSuplidor As Integer, ByVal Fecha As Date, ByVal NCF As String, ByVal NoFactura As String)
        Dim DsTemp As New DataSet
        Dim Tabla As DataTable

        ConMixta.Open()
        DsTemp.Clear()
        cmd = New MySqlCommand("SELECT IDCompra,SecondID,FechaFactura,Compras.IDSuplidor,Suplidor.Suplidor,NoFactura,NCF,TotalNeto FROM" & SysName.Text & "compras INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor where Compras.IDSuplidor='" + IDSuplidor.ToString + "' and FechaFactura='" + CDate(Fecha).ToString("yyyy-MM-dd") + "' and NCF='" + NCF.ToString + "' AND NoFactura='" + NoFactura.ToString + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "Compras")
        ConMixta.Close()

        Tabla = DsTemp.Tables("Compras")

        If Tabla.Rows.Count > 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("Se ha encontrado una compra que posee las mismas caracteristicas." & vbNewLine & vbNewLine & "La factura específicada corresponde a la siguiente:" & vbNewLine & "ID: " & Tabla.Rows(0).Item("SecondID") & vbNewLine & "No. Factura: " & Tabla.Rows(0).Item("NoFactura") & vbNewLine & "Fecha: " & CDate(Tabla.Rows(0).Item("FechaFactura")).ToString("dd/MM/yyyy") & vbNewLine & "Suplidor: [" & Tabla.Rows(0).Item("IDSuplidor") & "] " & Tabla.Rows(0).Item("Suplidor") & vbNewLine & "Total: " & CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C") & vbNewLine & vbNewLine & "¿Está seguro que desea continuar la operación?", "Se ha encontrado una similitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ControlSuperClave = 0
            Else
                ControlSuperClave = 1
            End If
        Else
            ControlSuperClave = 0
        End If


    End Function

    Function FindSimilarities(ByVal IDTipoDocumento As Integer, ByVal IDCliente As Integer, ByVal Total As Double, ByVal Fecha As Date)
        Dim DsTemp As New DataSet
        Dim Tabla As DataTable

        If IDTipoDocumento = 1 Then
            ConMixta.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT IDFacturaDatos,FacturaDatos.SecondID,Fecha,FacturaDatos.IDCliente,Clientes.Nombre,Fecha,TotalNeto,FacturaDatos.IDTipoDocumento,TipoDocumento.Documento FROM" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento where FacturaDatos.Nulo=0 and FacturaDatos.IDTipoDocumento=1 and FacturaDatos.IDCliente='" + IDCliente.ToString + "' and FacturaDatos.Fecha='" + Fecha.ToString("yyyy-MM-dd") + "' and FacturaDatos.TotalNeto='" + Total.ToString + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "FacturaDatos")
            ConMixta.Close()

            Tabla = DsTemp.Tables("FacturaDatos")

            If Tabla.Rows.Count > 0 Then
                frm_check_duplicados.lblDatos.Text = "Se ha encontrado una " & Tabla.Rows(0).Item("Documento") & " que posee las mismas caracteristicas." & vbNewLine & "No: " & Tabla.Rows(0).Item("SecondID") & vbNewLine & "Fecha: " & CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy") & vbNewLine & "Cliente: [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & vbNewLine & "Total: " & CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
                frm_check_duplicados.ShowDialog(frm_facturacion)
            Else
                ControlSuperClave = 0
            End If

        ElseIf IDTipoDocumento = 2 Then
            ConMixta.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT IDFacturaDatos,FacturaDatos.SecondID,Fecha,FacturaDatos.IDCliente,Clientes.Nombre,Fecha,TotalNeto,FacturaDatos.IDTipoDocumento,TipoDocumento.Documento FROM" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.TipoDocumento on FacturaDatos.IDTipoDocumento=TipoDocumento.IDTipoDocumento where FacturaDatos.Nulo=0 and FacturaDatos.IDTipoDocumento=2 and FacturaDatos.IDCliente='" + IDCliente.ToString + "' and FacturaDatos.Fecha='" + Fecha.ToString("yyyy-MM-dd") + "' and FacturaDatos.TotalNeto='" + Total.ToString + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "FacturaDatos")
            ConMixta.Close()

            Tabla = DsTemp.Tables("FacturaDatos")

            If Tabla.Rows.Count > 0 Then
                frm_check_duplicados.lblDatos.Text = "Se ha encontrado una " & Tabla.Rows(0).Item("Documento") & " que posee las mismas caracteristicas." & vbNewLine & "No: " & Tabla.Rows(0).Item("SecondID") & vbNewLine & "Fecha: " & CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy") & vbNewLine & "Cliente: [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & vbNewLine & "Total: " & CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
                frm_check_duplicados.ShowDialog(frm_facturacion)

                'Dim Result As MsgBoxResult = MessageBox.Show("Se ha encontrado una factura a crédito que posee las mismas caracteristicas." & vbNewLine & vbNewLine & "La factura específicada corresponde a la siguiente:" & vbNewLine & "No: " & Tabla.Rows(0).Item("SecondID") & vbNewLine & "Fecha: " & CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy") & vbNewLine & "Cliente: [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & vbNewLine & "Total: " & CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C") & vbNewLine & vbNewLine & "¿Está seguro que desea continuar la operación?", "Se ha encontrado una similitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If Result = MsgBoxResult.Yes Then
                '    ControlSuperClave = 0
                'Else
                '    ControlSuperClave = 1
                'End If
            Else
                ControlSuperClave = 0
            End If



        ElseIf IDTipoDocumento = 3 Then

            ConMixta.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT IDAbono,Abonos.SecondID,Fecha,Abonos.IDCliente,Clientes.Nombre,Fecha,Concepto,Total,Abonos.IDTipoDocumento,TipoDocumento.Documento FROM" & SysName.Text & "abonos INNER JOIN Libregco.Clientes on Abonos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.TipoDocumento on Abonos.IDTipoDocumento=TipoDocumento.IDTipoDocumento where Abonos.Nulo=0 and Abonos.IDCliente='" + IDCliente.ToString + "' and Abonos.Fecha='" + Fecha.ToString("yyyy-MM-dd") + "' and Abonos.Total='" + Total.ToString + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Abonos")
            ConMixta.Close()

            Tabla = DsTemp.Tables("Abonos")

            If Tabla.Rows.Count > 0 Then
                frm_check_duplicados.lblDatos.Text = "Se ha encontrado un " & Tabla.Rows(0).Item("Documento") & " que posee las mismas caracteristicas." & vbNewLine & vbNewLine & "No: " & Tabla.Rows(0).Item("SecondID") & vbNewLine & "Fecha: " & CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy") & vbNewLine & "Cliente: [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & vbNewLine & "Total: " & CDbl(Tabla.Rows(0).Item("Total")).ToString("C") & vbNewLine & "Concepto: " & Tabla.Rows(0).Item("Concepto")
                frm_check_duplicados.ShowDialog(frm_facturacion)
                'Dim Result As MsgBoxResult = MessageBox.Show("Se ha encontrado un recibo de ingreso que posee las mismas caracteristicas." & vbNewLine & vbNewLine & "El recibo específicado corresponde al siguiente:" & vbNewLine & "No: " & Tabla.Rows(0).Item("SecondID") & vbNewLine & "Fecha: " & CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy") & vbNewLine & "Cliente: [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & vbNewLine & "Total: " & CDbl(Tabla.Rows(0).Item("Total")).ToString("C") & vbNewLine & "Concepto: " & Tabla.Rows(0).Item("Concepto") & vbNewLine & vbNewLine & "¿Está seguro que desea continuar la operación?", "Se ha encontrado una similitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If Result = MsgBoxResult.Yes Then
                '    ControlSuperClave = 0
                'Else
                '    ControlSuperClave = 1
                'End If
            Else
                ControlSuperClave = 0
            End If


        ElseIf IDTipoDocumento = 58 Then

            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM" & SysName.Text & "pagosfinanciamientos INNER JOIN" & SysName.Text & "Financiamientos on PagosFinanciamientos.IDFinanciamiento=Financiamientos.IDFinanciamientos INNER JOIN" & SysName.Text & "TipoDocumento on PagosFinanciamientos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN Libregco.Clientes on Financiamientos.IDCliente=Clientes.IDCliente where pagosfinanciamientos.Nulo=0 and Financiamientos.IDCliente='" + IDCliente.ToString + "' and Date(PagosFinanciamientos.Fecha)='" + Fecha.ToString("yyyy-MM-dd") + "' and PagosFinanciamientos.TotalAplicado='" + Total.ToString + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "pagosfinanciamientos")
            ConMixta.Close()

            Tabla = DsTemp.Tables("pagosfinanciamientos")

            If Tabla.Rows.Count > 0 Then
                frm_check_duplicados.lblDatos.Text = "Se ha encontrado un " & Tabla.Rows(0).Item("Documento") & " que posee las mismas caracteristicas." & vbNewLine & vbNewLine & "No:  " & Tabla.Rows(0).Item("SecondID") & vbNewLine & "Fecha: " & CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy") & vbNewLine & "Cliente: [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & vbNewLine & "Total: " & CDbl(Tabla.Rows(0).Item("TotalAplicado")).ToString("C") & vbNewLine & "Concepto: " & Tabla.Rows(0).Item("Concepto")
                frm_check_duplicados.ShowDialog(frm_cuotas_financiamientos)
                'Dim Result As MsgBoxResult = MessageBox.Show("Se ha encontrado un recibo de ingreso que posee las mismas caracteristicas." & vbNewLine & vbNewLine & "El recibo específicado corresponde al siguiente:" & vbNewLine & "No: " & Tabla.Rows(0).Item("SecondID") & vbNewLine & "Fecha: " & CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy") & vbNewLine & "Cliente: [" & Tabla.Rows(0).Item("IDCliente") & "] " & Tabla.Rows(0).Item("Nombre") & vbNewLine & "Total: " & CDbl(Tabla.Rows(0).Item("Total")).ToString("C") & vbNewLine & "Concepto: " & Tabla.Rows(0).Item("Concepto") & vbNewLine & vbNewLine & "¿Está seguro que desea continuar la operación?", "Se ha encontrado una similitud", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If Result = MsgBoxResult.Yes Then
                '    ControlSuperClave = 0
                'Else
                '    ControlSuperClave = 1
                'End If
            Else
                ControlSuperClave = 0
            End If
        End If


    End Function

    Function ConseguirLogoEmpresa() As Image
        Return BussinessLogo
    End Function

    Function SetLogoSistema()
        Try
            If TypeConnection.Text = 1 Then
                ConUtilitarios.Open()
                cmd = New MySqlCommand("Select LocacionLogo from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from libregco_utilitarios.version_sys)", ConUtilitarios)
                Dim Path As String = Convert.ToString(cmd.ExecuteScalar())
                ConUtilitarios.Close()

                If Path = "" Then
                    SysLogo = My.Resources.LibregcoCircle_x256
                Else

                    Dim ExistFile As Boolean = System.IO.File.Exists("\\" & PathServidor.Text & Path)
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream("\\" & PathServidor.Text & Path, FileMode.Open, FileAccess.Read)
                        SysLogo = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                    End If
                End If

            Else
                SysLogo = My.Resources.LibregcoCircle_x256
            End If


        Catch ex As Exception
            ConUtilitarios.Close()
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try
    End Function

    Function ConseguirLogoSistema() As Image
        Return SysLogo
    End Function

    Function ConvertNumbertoString(ByVal Number As String, Optional ByVal Moneda As String = "PESOS")
        Try

            If IsNumeric(Number) Then
                If Number > 0 Then
                    Dim CvtLetra As New Label
                    Dim MontoDecimal As Decimal = Number
                    Dim DecimalResult As Decimal = MontoDecimal - Int(MontoDecimal)
                    Dim DecimalResulttoString As String
                    Dim Monto As Integer = MontoDecimal - DecimalResult

                    If DecimalResult > 0 Then
                        DecimalResulttoString = "CON " & CInt(DecimalResult * 100) & "/100"
                    Else
                        DecimalResulttoString = ""
                    End If

                    CvtLetra.Text = Num2Text(CInt(Monto))

                    Return CvtLetra.Text & " " & DecimalResulttoString & " " & Moneda.ToUpper

                    MessageBox.Show(CvtLetra.Text & " " & DecimalResulttoString & " " & Moneda.ToUpper)
                Else
                    Return ""
                End If
            Else
                Return ""
            End If

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Function ConvertNumbertoStringinBank(ByVal Number As String)
        Try

            If IsNumeric(Number) Then
                Dim CvtLetra As New Label
                Dim MontoDecimal As Decimal = Number
                Dim DecimalResult As Decimal = MontoDecimal - Int(MontoDecimal)
                Dim DecimalResulttoString As String
                Dim Monto As Integer = MontoDecimal - DecimalResult

                If DecimalResult > 0 Then
                    DecimalResulttoString = " CON " & CInt(DecimalResult * 100) & "/100"
                Else
                    DecimalResulttoString = ""
                End If

                CvtLetra.Text = Num2Text(CInt(Monto))

                Return CvtLetra.Text & " " & DecimalResulttoString

            Else
                Return ""
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function MakeCircleImagefromDgv(img As Image) As Image
        Dim bmp As New Bitmap(img.Width, img.Height)

        Using gpImg As New GraphicsPath()
            gpImg.AddEllipse(0, 0, img.Width, img.Height)
            Using grp As Graphics = Graphics.FromImage(bmp)
                grp.Clear(Color.WhiteSmoke)
                grp.SetClip(gpImg)
                grp.DrawImage(img, Point.Empty)
            End Using
        End Using
        Return bmp

    End Function

    Public Function ConvertCostKey(ByVal PalabraClave As String, ByVal Costo As String)
        Dim Resultado As String = ""
        If PalabraClave = "" Then
            Return Nothing
            Exit Function
        ElseIf PalabraClave.Length < Costo.Length Then
            MsgBox("La palabra clave establecida para la conversión de costos es muy corta para abarcar la colección de números del 0 al 9." & vbNewLine & vbNewLine & "Por favor utilize otra palabra para habilitar la conversión.")
            Return Nothing
            Exit Function
        End If

        For Each Caracter As Char In Costo
            If IsNumeric(Caracter) Then
                Resultado = Resultado & PalabraClave.Substring(Caracter.ToString, 1)
            Else
                Resultado = Resultado & Caracter
            End If
        Next

        Return Resultado

    End Function

    Public Function FilenameIsOK(ByVal fileNameAndPath As String) As Boolean
        Dim fileName = Path.GetFileName(fileNameAndPath)
        Dim directory = Path.GetDirectoryName(fileNameAndPath)
        For Each c In Path.GetInvalidFileNameChars()
            If fileName.Contains(c) Then
                Return False
            End If
        Next
        For Each c In Path.GetInvalidPathChars()
            If directory.Contains(c) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function ConvertBooltoInt(ByVal Bool As Boolean) As Integer
        If Bool = True Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Function TakeScreenShot(ByVal Control As Control) As Bitmap
        Dim tmpImg As New Bitmap(Control.Width, Control.Height)
        Using g As Graphics = Graphics.FromImage(tmpImg)
            g.CopyFromScreen(Control.PointToScreen(New Point(0, 0)), New Point(0, 0), New Size(Control.Width, Control.Height))
        End Using

        Return tmpImg
    End Function

    Function TakePartialScreenFormReturningUNC(ByVal Control As Control) As String
        Dim tmpImg As New Bitmap(Control.Width, Control.Height)
        Using g As Graphics = Graphics.FromImage(tmpImg)
            g.CopyFromScreen(Control.PointToScreen(New Point(0, 0)), New Point(0, 0), New Size(Control.Width, Control.Height))
        End Using

        'Verificar si existe carpeta para guardar Logs
        Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\LibregcoLogs")
        If Exists = False Then
            System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\LibregcoLogs")
        End If

        'Creando dirección para guardar archivo
        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\LibregcoLogs\" & Today.ToString("yyyymmdd") & Now.ToString("hhmmss") & ".jpg"

        tmpImg.Save(RutaDestino)

        Return Replace(RutaDestino, "\", "\\")

        tmpImg.Dispose()

    End Function

    Function TakeFullScreenshotUNC(ByVal Control As Control) As String
        Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)

        Using g As Graphics = Graphics.FromImage(screenGrab)
            g.CopyFromScreen(New Point(0, 0), New Point(0, 0), screenSize)
        End Using

        'Verificar si existe carpeta para guardar Logs
        Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\LibregcoLogs")
        If Exists = False Then
            System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\LibregcoLogs")
        End If

        'Creando dirección para guardar archivo
        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\LibregcoLogs\" & Today.ToString("yyyymmdd") & Now.ToString("hhmmss") & ".jpg"

        screenGrab.Save(RutaDestino)

        Return Replace(RutaDestino, "\", "\\")

        screenGrab.Dispose()
    End Function

    Sub ChangetoTruePrintSecureEmployee()
        Try
            ConMixta.Open()
            sqlQ = "UPDATE" & SysName.Text & "AreaImpresion SET PrintingSecure=1 WHERE IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "'"
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
            ConMixta.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try

    End Sub

    Sub ChangetoFalsePrintSecureEmployee()
        Try
            ConMixta.Open()
            sqlQ = "UPDATE" & SysName.Text & "AreaImpresion SET PrintingSecure=0 WHERE IDEquipo='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "'"
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
            ConMixta.Close()

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try

    End Sub

    Function TakeReportViewImage(ByVal ControlCrystal As CrystalDecisions.Windows.Forms.CrystalReportViewer, ByVal IDReporte As String, ByVal ReportName As String) As String
        Try

            'Verifico si el reporte tiene visualizaciones
            ConMixta.Open()
            cmd = New MySqlCommand("Select Visualizacion from" & SysName.Text & "Reportes where IDReportes='" + IDReporte + "'", ConMixta)
            Dim Visual As String = Convert.ToString(cmd.ExecuteScalar())
            ConMixta.Close()

            'Si no tiene visualizaciones
            If Visual = "" Then

                'Determino que tipo de captura esta seleccionada  JPGE VS PDF
                ConMixta.Open()
                cmd = New MySqlCommand("Select Value1Var from" & SysName.Text & "Configuracion where IDConfiguracion=130", ConMixta)
                Dim TypeofFormat As String = Convert.ToString(cmd.ExecuteScalar())
                ConMixta.Close()

                If TypeofFormat = "JPGE" Then
                    Dim tmpImg As New Bitmap(ControlCrystal.Width, ControlCrystal.Height)
                    Using g As Graphics = Graphics.FromImage(tmpImg)
                        'g.CopyFromScreen(ControlCrystal.PointToScreen(New Point(0, 0)), New Point(0, 0), New Size(ControlCrystal.Width, ControlCrystal.Height))
                        g.CopyFromScreen(ControlCrystal.PointToScreen(New Point(15, 32)), New Point(17, 32), New Size(ControlCrystal.Width - 32, ControlCrystal.Height - 64))

                    End Using

                    '-------------------------------------------------------------------------
                    'Verificar si existe carpeta para guardar Logs
                    Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\ReportSamples")
                    If Exists = False Then
                        System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\ReportSamples")
                    End If
                    '-------------------------------------------------------------------------

                    'Creando dirección para guardar archivo
                    Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\ReportSamples\" & ReportName & ".jpg"
                    Dim NewFileName As String = "\Libregco\Files\ReportSamples\" & ReportName & ".jpg"

                    tmpImg.Save(RutaDestino)

                    ConMixta.Open()
                    sqlQ = "UPDATE" & SysName.Text & "Reportes Set Visualizacion='" + Replace(NewFileName, "\", "\\") + "' Where IDReportes='" + IDReporte + "'"
                    cmd = New MySqlCommand(sqlQ, ConMixta)
                    cmd.ExecuteNonQuery()
                    ConMixta.Close()

                    tmpImg.Dispose()

                    Return Replace(RutaDestino, "\", "\\")

                ElseIf TypeofFormat = "PDF" Then

                    Dim CrExportOptions As ExportOptions
                    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                    Dim CrFormatTypeOtions As New PdfRtfWordFormatOptions

                    '-------------------------------------------------------------------------
                    'Verificar si existe carpeta para guardar Logs
                    Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\ReportSamples")
                    If Exists = False Then
                        System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\ReportSamples")
                    End If
                    '-------------------------------------------------------------------------

                    'Creando dirección para guardar archivo
                    Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\ReportSamples\" & ReportName & ".pdf"
                    Dim NewFileName As String = "\Libregco\Files\ReportSamples\" & ReportName & ".jpg"

                    CrDiskFileDestinationOptions.DiskFileName = RutaDestino
                    CrExportOptions = ControlCrystal.ReportSource.ExportOptions

                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With

                    ControlCrystal.ReportSource.Export()

                    ConMixta.Open()
                    sqlQ = "UPDATE" & SysName.Text & "Reportes Set Visualizacion='" + Replace(NewFileName, "\", "\\") + "' Where IDReportes='" + IDReporte + "'"
                    cmd = New MySqlCommand(sqlQ, ConMixta)
                    cmd.ExecuteNonQuery()
                    ConMixta.Close()

                    Return Replace(RutaDestino, "\", "\\")
                End If

            Else

                Return Nothing
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try
    End Function

    Function OverlayImages(ByVal BackgroundImg As System.Drawing.Bitmap, ByVal OverlayImg As System.Drawing.Bitmap, Position As System.Drawing.Point) As System.Drawing.Bitmap
        Dim g = System.Drawing.Graphics.FromImage(BackgroundImg)
        g.DrawImage(OverlayImg, Position)
        Return BackgroundImg
    End Function

    Public Function ResizeImage(ByVal image As Bitmap, height As Integer) As Bitmap
        Try
            Dim RelatPic As Double = height / image.Height
            Dim nHeight As Integer = image.Height * RelatPic
            Dim nWidth As Integer = image.Width * RelatPic

            Dim destRect = New Rectangle(0, 0, nWidth, nHeight)
            Dim destImage = New Bitmap(nWidth, nHeight)

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution)

            Using graphics__1 = Graphics.FromImage(destImage)
                graphics__1.CompositingMode = CompositingMode.SourceCopy
                graphics__1.CompositingQuality = CompositingQuality.HighQuality
                graphics__1.InterpolationMode = InterpolationMode.HighQualityBicubic
                graphics__1.SmoothingMode = SmoothingMode.HighQuality
                graphics__1.PixelOffsetMode = PixelOffsetMode.HighQuality

                Using wrapMode__2 = New ImageAttributes()
                    wrapMode__2.SetWrapMode(WrapMode.TileFlipXY)
                    graphics__1.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode__2)
                End Using
            End Using

            Return destImage
        Catch ex As Exception
            Return My.Resources.No_Image
        End Try

    End Function

    Public Function ResizeImageWithWidth(ByVal image As Bitmap, width As Integer) As Bitmap
        Try
            Dim RelatPic As Double = width / image.Width
            Dim nHeight As Integer = image.Height * RelatPic
            Dim nWidth As Integer = image.Width * RelatPic

            Dim destRect = New Rectangle(0, 0, nWidth, nHeight)
            Dim destImage = New Bitmap(nWidth, nHeight)

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution)

            Using graphics__1 = Graphics.FromImage(destImage)
                graphics__1.CompositingMode = CompositingMode.SourceCopy
                graphics__1.CompositingQuality = CompositingQuality.HighQuality
                graphics__1.InterpolationMode = InterpolationMode.HighQualityBicubic
                graphics__1.SmoothingMode = SmoothingMode.HighQuality
                graphics__1.PixelOffsetMode = PixelOffsetMode.HighQuality

                Using wrapMode__2 = New ImageAttributes()
                    wrapMode__2.SetWrapMode(WrapMode.TileFlipXY)
                    graphics__1.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode__2)
                End Using
            End Using

            Return destImage
        Catch ex As Exception
            Return My.Resources.No_Image
        End Try

    End Function
    Public Function ResizeImageWXH(ByVal image As Bitmap, width As Integer, height As Integer) As Bitmap
        Dim destRect = New Rectangle(0, 0, width, height)
        Dim destImage = New Bitmap(width, height)

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution)

        Using graphics__1 = Graphics.FromImage(destImage)
            graphics__1.CompositingMode = CompositingMode.SourceCopy
            graphics__1.CompositingQuality = CompositingQuality.HighQuality
            graphics__1.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphics__1.SmoothingMode = SmoothingMode.HighQuality
            graphics__1.PixelOffsetMode = PixelOffsetMode.HighQuality

            Using wrapMode__2 = New ImageAttributes()
                wrapMode__2.SetWrapMode(WrapMode.TileFlipXY)
                graphics__1.DrawImage(image, destRect, 0, 0, image.Width, image.Height,
                GraphicsUnit.Pixel, wrapMode__2)
            End Using
        End Using

        Return destImage
    End Function

    Public Function SetDefaultPhoto(ByVal IDArticulo As String)
        Dim DsTemp As New DataSet

        Con.Open()
        DsTemp.Clear()
        cmd = New MySqlCommand("SELECT idimagen,rutaimagen,descripcion,orden FROM libregco.articulos_fotos where idarticulo='" + IDArticulo + "' Order by Orden ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "Imagenes")

        Dim Tabla As DataTable = DsTemp.Tables("Imagenes")

        If Tabla.Rows.Count = 0 Then
            sqlQ = "UPDATE Libregco.Articulos SET RutaFoto='' WHERE IDArticulo= (" + IDArticulo + ")"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
        Else
            sqlQ = "UPDATE Libregco.Articulos SET RutaFoto='" + (Replace(Tabla.Rows(0).Item(1).ToString, "\", "\\")) + "' WHERE IDArticulo= (" + IDArticulo + ")"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
        End If

        Con.Close()
        DsTemp.Dispose()
    End Function


    Function TruncateDecimal(ByVal Number As Double)
        Dim MontoDecimal As Decimal = Number
        Dim DecimalResult As Decimal = MontoDecimal - Int(MontoDecimal)
        Dim Monto As Integer = MontoDecimal - DecimalResult

        Return Monto

    End Function

    Function CalcDiasVacaciones(ByVal FechaInicio As Date) As Date

        For i As Integer = 0 To 13
            If FechaInicio.DayOfWeek = DayOfWeek.Sunday Then
                FechaInicio = FechaInicio.AddDays(1)
            End If

            If Not IsLaborableDay(FechaInicio) Then
                FechaInicio = FechaInicio.AddDays(1)
            End If

            FechaInicio = FechaInicio.AddDays(1)


        Next


        Return FechaInicio

    End Function

    Function IsLaborableDay(ByVal TheDay As Date) As Boolean
        Dim Labor As Integer = 0

        Con.Open()
        cmd = New MySqlCommand("SELECT count(Laborable) FROM DiasEspeciales WHERE Dia='" + TheDay.ToString("yyyy-MM-dd") + "' and Laborable=0", Con)
        Labor = Convert.ToInt16(cmd.ExecuteScalar())
        Con.Close()

        If Labor = 0 Then
            Return True
        Else

            Return False

        End If



    End Function

    Function calcDifFechas(ByVal dDesde As Date, ByVal dHasta As Date, ByVal ArrR() As Integer)
        Dim iAnoDesde As Integer = dDesde.Year
        Dim iAnoHasta As Integer = dHasta.Year
        Dim iMesDesde As Integer = dDesde.Month
        Dim iMesHasta As Integer = dHasta.Month
        Dim iDiaDesde As Integer = dDesde.Day
        Dim iDiaHasta As Integer = dHasta.Day

        If iDiaHasta < iDiaDesde Then
            iDiaHasta = iDiaHasta + 30
            iMesHasta = iMesHasta - 1
        End If

        ArrR(2) = iDiaHasta - iDiaDesde + 1

        If iMesHasta < iMesDesde Then
            iMesHasta = iMesHasta + 12
            iAnoHasta = iAnoHasta - 1
        End If

        ArrR(1) = iMesHasta - iMesDesde
        ArrR(0) = iAnoHasta - iAnoDesde

        Return ArrR
    End Function


    Function CheckDoubleBilling(ByVal IDCliente As String) As Boolean
        Dim DsTemp As New DataSet


        'Dim BloqueoActivoFacturacionSimultanea As String = cint(DTConfiguracion.Rows(149 - 1).Item("Value2Int"))

        If CInt(DTConfiguracion.Rows(149 - 1).Item("Value2Int")) = 1 Then

            If SysName.Text = " Libregco." Then
                ConLibregcoMain.Open()
                cmd = New MySqlCommand("SELECT IDFacturaDatos,SecondID,IDTipoDocumento,Fecha,FechaVencimiento,if(FacturaDatos.Fecha<Now(),DATEDIFF(now(),FacturaDatos.Fecha),0) as DiasVencidos,TotalNeto,Balance,Cargos FROM FacturaDatos WHERE IDCliente='" + IDCliente + "' and FacturaDatos.Balance>0 AND FacturaDatos.Nulo=0", ConLibregcoMain)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "FacturaDatos")
                ConLibregcoMain.Close()

                Dim Tabla As DataTable = Ds.Tables("FacturaDatos")
                If Tabla.Rows.Count > 0 Then
                    Return True

                Else
                    Return False
                End If

            Else

                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT IDFacturaDatos,SecondID,IDTipoDocumento,Fecha,FechaVencimiento,if(FacturaDatos.Fecha<Now(),DATEDIFF(now(),FacturaDatos.Fecha),0) as DiasVencidos,TotalNeto,Balance,Cargos FROM FacturaDatos WHERE IDCliente='" + IDCliente + "' and FacturaDatos.Balance>0 AND FacturaDatos.Nulo=0", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "FacturaDatos")
                ConLibregco.Close()

                Dim Tabla As DataTable = Ds.Tables("FacturaDatos")
                If Tabla.Rows.Count > 0 Then
                    Return True

                Else
                    Return False
                End If
            End If

        Else

            Return False
        End If
    End Function

    Sub GenerateAssistance()
        Try

            ConLibregco.Open()
            cmd = New MySqlCommand("Select count(IDAsistencia) from Asistencias where DiaHabil=CURDATE()", ConLibregco)
            Dim CantidadAsistencias As Integer = Convert.ToInt16(cmd.ExecuteScalar())
            ConLibregco.Close()

            If CantidadAsistencias = 0 Then
                Dim DsTemp As New DataSet

                ConMixta.Open()
                cmd = New MySqlCommand("SELECT IDEmpleado,Nombre,Empleados.IDTanda,Tandas.Descripcion FROM" & SysName.Text & "Empleados INNER JOIN Libregco.Tandas on Empleados.IDTanda=Tandas.IDTanda where Empleados.Nulo=0", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "Empleado")

                Dim Tabla As DataTable = DsTemp.Tables("Empleado")

                For Each dt As DataRow In Tabla.Rows
                    sqlQ = "INSERT INTO Libregco.Asistencias (IDEmpleado,DiaHabil,DiaEfectivo,IDTipoPresencia,Observacion) VALUES ('" + dt.Item("IDEmpleado").ToString + "',CURDATE(),0,1,'')"
                    cmd = New MySqlCommand(sqlQ, ConMixta)
                    cmd.ExecuteNonQuery()

                    sqlQ = "UPDATE" & SysName.Text & "Empleados Set Disponible=0 WHERE IDEmpleado='" + dt.Item("IDEmpleado").ToString + "'"
                    cmd = New MySqlCommand(sqlQ, ConMixta)
                    cmd.ExecuteNonQuery()
                Next

                ConMixta.Close()
            End If

        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        End Try
    End Sub


    Function After(value As String, a As String) As String
        ' Get index of argument and return substring after its position.
        Dim posA As Integer = value.LastIndexOf(a)
        If posA = -1 Then
            Return ""
        End If
        Dim adjustedPosA As Integer = posA + a.Length
        If adjustedPosA >= value.Length Then
            Return ""
        End If
        Return value.Substring(adjustedPosA)
    End Function

    Function Between(value As String, a As String, b As String) As String
        ' Get positions for both string arguments.
        Dim posA As Integer = value.IndexOf(a)
        Dim posB As Integer = value.LastIndexOf(b)
        If posA = -1 Then
            Return ""
        End If
        If posB = -1 Then
            Return ""
        End If

        Dim adjustedPosA As Integer = posA + a.Length
        If adjustedPosA >= posB Then
            Return ""
        End If

        ' Get the substring between the two positions.
        Return value.Substring(adjustedPosA, posB - adjustedPosA)
    End Function

    Function Before(value As String, a As String) As String
        ' Get index of argument and return substring up to that point.
        Dim posA As Integer = value.IndexOf(a)
        If posA = -1 Then
            Return ""
        End If
        Return value.Substring(0, posA)
    End Function

    Function CheckProductListStatus(ByVal IDArticulo As Integer, ByVal Status As Integer)
        cmd = New MySqlCommand("SELECT count(idlistadoarticulosdetalle) FROM" & SysName.Text & "listadoarticulosdetalle where IDArticulo='" + IDArticulo.ToString + "' and Recibido<>0", Con)
        If Convert.ToInt16(cmd.ExecuteScalar()) > 0 Then
            sqlQ = "UPDATE" & SysName.Text & "ListadoArticulosDetalle SET Recibido='" + Status.ToString + "' where IDArticulo='" + IDArticulo.ToString + "'"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
        End If

    End Function

    Function ClearOldBackUp()
        Dim DiasValidos As Integer
        Dim UltimaLimpieza As String

        Con.Open()
        cmd = New MySqlCommand("Select Value2Int from Configuracion Where IDConfiguracion=35", Con)
        DiasValidos = Convert.ToString(cmd.ExecuteScalar())
        cmd = New MySqlCommand("Select Value1Var from Configuracion Where IDConfiguracion=34", Con)
        UltimaLimpieza = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If CDate(UltimaLimpieza) < Today Then
            frm_LoginSistema.lblInformacion.Text = "Limpiando backups antiguos..."
            Dim DsTemp As New DataSet

            ConUtilitarios.Open()
            cmd = New MySqlCommand("SELECT idDirectoryBackup,Directory FROM Libregco_Utilitarios.DirectoryBackup ORDER BY idDirectoryBackup ASC", ConUtilitarios)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Directory")
            ConUtilitarios.Close()

            Dim Tabla As DataTable = DsTemp.Tables("Directory")
            For Each tb As DataRow In Tabla.Rows

                If Directory.Exists(tb.Item("Directory")) Then
                    Dim fileEntries As String() = Directory.GetFiles(tb.Item("Directory"), "*.*")
                    '' Process the list of .txt files found in the directory. '
                    Dim fileName As String

                    For Each fileName In fileEntries
                        If DateDiff(DateInterval.Day, File.GetLastWriteTime(fileName), Today) >= DiasValidos Then
                            My.Computer.FileSystem.DeleteFile(fileName, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                        End If
                    Next
                End If
            Next

            Con.Open()
            sqlQ = "UPDATE Configuracion Set Value1Var='" + Today.ToString("yyyy-MM-dd") + "' where IDConfiguracion=34"
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        End If
    End Function

    Function ReturnNotificationImage(ByVal nFont As Font, ByVal nSize As Size, ByVal FillColor As SolidBrush, ByVal SText As String, ByVal ForeColorS As Brush) As Image
        Dim flag As New Bitmap(nSize.Width, nSize.Height)
        Dim flagGraphics As Graphics = Graphics.FromImage(flag)

        flagGraphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        flagGraphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        flagGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        flagGraphics.FillEllipse(FillColor, 0, 0, flag.Width - 5, flag.Height - 5)

        CenterTextAt(flagGraphics, SText, (flag.Width - 5) / 2, (flag.Height - 5) / 2, ForeColorS, nFont)

        Return flag
    End Function

    Private Sub CenterTextAt(ByVal gr As Graphics, ByVal txt As String, ByVal x As Single, ByVal y As Single, ByVal ForeColorT As Brush, ByVal nFont As Font)
        ' Make a StringFormat object that centers.
        Dim sf As New StringFormat
        sf.LineAlignment = StringAlignment.Center
        sf.Alignment = StringAlignment.Center

        ' Draw the text.
        gr.DrawString(txt, nFont, ForeColorT, x, y, sf)
        sf.Dispose()
    End Sub

    Function ContarPalabras(ByVal str As String) As Integer
        Dim NumberOfWord As Integer = UBound(Split(Trim(Replace(str, Space(2), Space(1))))) + 1
        Return NumberOfWord
    End Function

    Function ConvertTimeSpantoLetter(ByVal span As TimeSpan) As String
        Dim Hours, Minutes, Seconds As String
        Hours = span.Hours

        If Hours = 1 Then
            Hours = Hours & " hora, "
        Else
            Hours = Hours & " horas, "
        End If

        Minutes = span.Minutes
        If Minutes = 1 Then
            Minutes = Minutes & " minuto y "
        Else
            Minutes = Minutes & " minutos y "
        End If

        Seconds = span.Seconds
        If Seconds = 1 Then
            Seconds = Seconds & " segundo"
        Else
            Seconds = Seconds & " segundos"
        End If

        Return Hours & Minutes & Seconds

    End Function

    Function CheckRequiredFieldsofCustomers(ByVal IDCliente As Integer) As Boolean

        If IDCliente > 1 Then
            If CInt(DTConfiguracion.Rows(83 - 1).Item("Value2Int")) = 1 Then
                If CInt(DTConfiguracion.Rows(84 - 1).Item("Value2Int")) = IDCliente Then
                    Return True
                    Exit Function
                End If
            End If

            Dim Solicitudes As New ArrayList
                'Index list
                '0 /55 Identificacion obligatoria
                '1 /138 Copia de cedula obligatoria
                '2 /155 Direccion completa
                '3 /156 Teléfono Personal 1
                '4 /157 Telefono Personal 2
                '5 /158 Garante
                '6 /159 Informacion Adicional

                ConMixta.Open()
                Ds.Clear()
                cmd = New MySqlCommand("SELECT IDConfiguracion,Object,Value2Int FROM" & SysName.Text & "configuracion where IDConfiguracion=55 UNION ALL SELECT IDConfiguracion,Object,Value2Int FROM" & SysName.Text & "configuracion where IDConfiguracion=138 UNION ALL SELECT IDConfiguracion,Object,Value2Int FROM" & SysName.Text & "configuracion where IDConfiguracion>154 and IDConfiguracion<160", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "configuracion")

                Dim TablaConfiguracion As DataTable = Ds.Tables("configuracion")

                For Each dt As DataRow In TablaConfiguracion.Rows
                    Solicitudes.Add(dt.Item(2))
                Next

                TablaConfiguracion.Dispose()

                Ds.Clear()
                cmd = New MySqlCommand("SELECT IDCliente,Nombre,Identificacion,(SELECT count(iddocumentosclientes) FROM libregco.documentosclientes where Documentosclientes.IDCliente=Clientes.IDCliente) as CantDocumentos,Direccion,TelefonoPersonal,TelefonoHogar,GaranteNombre,TipoIdentificacionGarante,IdentificacionGarante,DireccionGarante,TelefonoGarante,InformacionAdc from Libregco.Clientes Where IDCliente='" + IDCliente.ToString + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "Clientes")

                ConMixta.Close()

                Dim Tabla As DataTable = Ds.Tables("Clientes")

                If Tabla.Rows.Count > 0 Then
                    'Identificacion obligatoria
                    If Solicitudes(0) = "1" Then
                        If Replace(Tabla.Rows(0).Item("Identificacion"), "-", "") = "" Then
                            MessageBox.Show("Se ha indicado que el No. de identificación de los clientes es un campo obligatorio para la otorgación de créditos." & vbNewLine & vbNewLine & "Por favor complete la información para continuar.", "No. de identificación obligatoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Return False
                            Exit Function
                        End If
                    End If

                    'Copia de identificacion obligatoria
                    If Solicitudes(1) = "1" Then
                        If CInt(Tabla.Rows(0).Item("CantDocumentos")) = 0 Then
                            MessageBox.Show("Se ha indicado que es obligatorio registrar duplicados digitales del No. de identificación de los clientes para la otorgación de créditos." & vbNewLine & vbNewLine & "Por favor complete la información para continuar.", "Copia de identificación obligatoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Return False
                            Exit Function
                        End If
                    End If

                    'DireccionCompleta
                    If Solicitudes(2) = "1" Then
                        If Tabla.Rows(0).Item("Direccion") = "" Or Len(Tabla.Rows(0).Item("Direccion")) < 16 Then
                            MessageBox.Show("Se ha indicado que es obligatorio registrar una dirección o hacer una descripción con más detalle de la dirección del cliente del clientes para la otorgación de créditos." & vbNewLine & vbNewLine & "Por favor complete la información para continuar.", "Dirección obligatoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Return False
                            Exit Function
                        End If
                    End If


                    'TelefonoPersonal1
                    If Solicitudes(3) = "1" Then
                        If Replace(Tabla.Rows(0).Item("TelefonoPersonal"), "-", "") = "" Then
                            MessageBox.Show("Se ha indicado que es obligatorio registrar un número personal del cliente para la otorgación de créditos." & vbNewLine & vbNewLine & "Por favor complete la información para continuar.", "Teléfono personal 1 obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Return False
                            Exit Function
                        End If
                    End If

                    'TelefonoPersonal1
                    If Solicitudes(4) = "1" Then
                        If Replace(Tabla.Rows(0).Item("TelefonoHogar"), "-", "") = "" Then
                            MessageBox.Show("Se ha indicado que es obligatorio registrar un segundo número personal del cliente para la otorgación de créditos." & vbNewLine & vbNewLine & "Por favor complete la información para continuar.", "Teléfono personal 2 obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Return False
                            Exit Function
                        End If
                    End If


                    'Garante
                    If Solicitudes(5) = "1" Then
                        'NombreGarante
                        If Tabla.Rows(0).Item("GaranteNombre") = "" Or Len(Tabla.Rows(0).Item("GaranteNombre")) < 10 Then
                            MessageBox.Show("Se ha indicado que es obligatorio registrar un garante del cliente para la otorgación de créditos." & vbNewLine & vbNewLine & "Por favor complete la información para continuar.", "Garante obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Return False
                            Exit Function
                        End If
                        If Replace(Tabla.Rows(0).Item("IdentificacionGarante"), "-", "") = "" Then
                            MessageBox.Show("Se ha indicado que es obligatorio registrar el No. de identificación del garante del cliente para la otorgación de créditos." & vbNewLine & vbNewLine & "Por favor complete la información para continuar.", "Identificación del garante obligatoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Return False
                            Exit Function
                        End If
                        If Tabla.Rows(0).Item("DireccionGarante") = "" Or Len(Tabla.Rows(0).Item("DireccionGarante")) < 16 Then
                            MessageBox.Show("Se ha indicado que es obligatorio registrar la dirección del garante del cliente para la otorgación de créditos." & vbNewLine & vbNewLine & "Por favor complete la información para continuar.", "Dirección del garante obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Return False
                            Exit Function
                        End If
                        If Replace(Tabla.Rows(0).Item("TelefonoGarante"), "-", "") = "" Then
                            MessageBox.Show("Se ha indicado que es obligatorio registrar el número teléfonico del garante del cliente para la otorgación de créditos." & vbNewLine & vbNewLine & "Por favor complete la información para continuar.", "No. Teléfono del garante obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Return False
                            Exit Function
                        End If
                    End If

                    'Informacion Adicional
                    If Solicitudes(6) = "1" Then
                        If Tabla.Rows(0).Item("InformacionAdc") = "" Or Len(Tabla.Rows(0).Item("InformacionAdc")) < 16 Then
                            MessageBox.Show("Se ha indicado que es obligatorio registrar información adicional del cliente para la otorgación de créditos." & vbNewLine & vbNewLine & "Por favor complete la información para continuar.", "Información adicional obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Return False
                            Exit Function
                        End If
                    End If

                    Return True
                End If

                Tabla.Dispose()


            End If



    End Function

    Function HaveDuplicatesNumbers(ByVal TelefonoPersonal As String, ByVal TelefonoHogar As String, ByVal TelefonoTrabajo As String, ByVal TelefonoPaternos As String, ByVal TelefonoConyuge As String, ByVal TelefonoConyugePaternos As String, ByVal TelefonoGarante As String, ByVal TypeCustomer As String) As Boolean
        Dim Numbers As New ArrayList

        If TypeCustomer = "" Then
            TypeCustomer = 1
        End If

        If Trim(Replace(TelefonoPersonal, "-", "")) <> "" Then
            If Numbers.Contains(Replace(TelefonoPersonal, "-", "")) Then
                MessageBox.Show("El teléfono 1 introducido ya ha sido introducido en el registro del cliente.", "Teléfono Personal incluído", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return True
                Exit Function
            Else
                Numbers.Add(Replace(TelefonoPersonal, "-", "").Trim)
            End If
        End If

        If Trim(Replace(TelefonoHogar, "-", "")) <> "" Then
            If Numbers.Contains(Replace(TelefonoHogar, "-", "")) Then
                MessageBox.Show("El teléfono 1 introducido ya ha sido introducido en el registro del cliente.", "Teléfono Hogar incluído", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return True
                Exit Function
            Else
                Numbers.Add(Replace(TelefonoHogar, "-", ""))
            End If
        End If

        If TypeCustomer = 1 Then
            If Trim(Replace(TelefonoTrabajo, "-", "")) <> "" Then
                If Numbers.Contains(Replace(TelefonoTrabajo, "-", "")) Then
                    MessageBox.Show("El teléfono 2 introducido ya ha sido introducido en el registro del cliente.", "Teléfono del trabajo incluído", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Return True
                    Exit Function
                Else
                    Numbers.Add(Replace(TelefonoTrabajo, "-", ""))
                End If
            End If
        End If
        If TypeCustomer = 1 Then
            If Trim(Replace(TelefonoPaternos, "-", "")) <> "" Then
                If Numbers.Contains(Replace(TelefonoPaternos, "-", "")) Then
                    MessageBox.Show("El teléfono de los paternos introducido ya ha sido introducido en el registro del cliente.", "Teléfono Paternos incluído", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Return True
                    Exit Function
                Else
                    Numbers.Add(Replace(TelefonoPaternos, "-", ""))
                End If
            End If
        End If
        If TypeCustomer = 1 Then
            If Trim(Replace(TelefonoConyuge, "-", "")) <> "" Then
                If Numbers.Contains(Replace(TelefonoConyuge, "-", "")) Then
                    MessageBox.Show("El teléfono conyugue introducido ya ha sido introducido en el registro del cliente.", "Teléfono Conyugue incluído", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Return True
                    Exit Function
                Else
                    Numbers.Add(Replace(TelefonoConyuge, "-", ""))
                End If
            End If
        End If

        If TypeCustomer = 1 Then
            If Trim(Replace(TelefonoConyugePaternos, "-", "")) <> "" Then
                If Numbers.Contains(Replace(TelefonoConyugePaternos, "-", "")) Then
                    MessageBox.Show("El teléfono de los paternos del conyugue introducido ya ha sido introducido en el registro del cliente.", "Teléfono Paternos conyugue incluído", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Return True
                    Exit Function
                Else
                    Numbers.Add(Replace(TelefonoConyugePaternos, "-", ""))
                End If
            End If
        End If

        If TypeCustomer = 1 Then
            If Trim(Replace(TelefonoGarante, "-", "")) <> "" Then
                If Numbers.Contains(Replace(TelefonoGarante, "-", "")) Then
                    MessageBox.Show("El teléfono del garante introducido ya ha sido introducido en el registro del cliente.", "Teléfono Garante incluído", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Return True
                    Exit Function
                Else
                    Numbers.Add(Replace(TelefonoGarante, "-", ""))
                End If
            End If
        End If

        Return False

    End Function

    Function IsIntegratedBalance(ByVal IDCliente As String, ByVal AmountonForm As Double, ByVal IDMoneda As Double) As Boolean
        Dim CustomerBalance As Double = 0

        ConLibregco.Open()
        cmd = New MySqlCommand("Select Balance from Libregco.clientes_balances where IDCliente='" + IDCliente + "' and IDMoneda='" + IDMoneda.ToString + "'", ConLibregco)
        CustomerBalance = Convert.ToDouble(cmd.ExecuteScalar())
        ConLibregco.Close()

        'MessageBox.Show(CustomerBalance & vbNewLine & AmountonForm)
        If CustomerBalance <> AmountonForm Then
            MessageBox.Show("Se ha realizado una transacción que ha afectado el balance actual del cliente por lo que no es posible realizar esta operación en estos momentos." & vbNewLine & vbNewLine & "Vuelva a intentar esta operación en un nuevo registro.", "Balances no íntegros", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Return False
        Else
            Return True
        End If


    End Function

    Private Function VerifyChanges(ByVal P1 As Double, ByVal P2 As Double) As String
        If P2 > P1 Then
            Return " aumentó de " & CDbl(P1).ToString("C") & " a " & CDbl(P2).ToString("C") & " (+" & CDbl((P2 / P1) - 1).ToString("P") & ")"
        Else
            Return " redujo de " & CDbl(P1).ToString("C") & " a " & CDbl(P2).ToString("C") & " (" & CDbl((P2 / P1) - 1).ToString("P") & ")"
        End If
    End Function

    Private Function VerifyChangesContenido(ByVal P1 As Double, ByVal P2 As Double) As String
        If P2 > P1 Then
            Return " aumentó de " & (P1) & " a " & (P2)
        Else
            Return " redujo de " & (P1) & " a " & (P2)
        End If
    End Function

    Function CheckedUptadesinPrinces(ByVal IDPrecios As String, ByVal Optional Costo As Double = 0, ByVal Optional CostoFinal As Double = 0, ByVal Optional PrecioA As Double = 0, ByVal Optional PrecioB As Double = 0, ByVal Optional PrecioC As Double = 0, ByVal Optional PrecioD As Double = 0, ByVal Optional PrecioBlackFriday As Double = 0, ByVal Optional Contenido As Double = 0, ByVal Optional Medida As String = "") As String
        'Try

        Dim TextComposed As String = ""
            Dim IDArticulo, Cost, CostF, PrecA, PrecB, PrecC, PrecD, PrecBF, Cont, Medi As String
            'Dim ACost, ACostF, APrecioA, APrecioB, AprecioC, AprecioD As String

            Ds.Clear()
        cmd = New MySqlCommand("Select PrecioArticulo.IDArticulo,IDPrecios,PrecioArticulo.IDArticulo,Articulos.Descripcion,PrecioArticulo.IDMedida,Medida.Abreviatura,Contenido,Costo,CostoFinal,DescuentoMaximo,PrecioCredito,PrecioContado,Precio3,Precio4,PrecioArticulo.Nulo,CostoClave,PrecioBlackFriday,Articulos.Descripcion FROM libregco.precioarticulo INNER JOIN Libregco.Medida On PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Articulos On PrecioArticulo.IDArticulo=Articulos.IDArticulo where PrecioArticulo.IDPrecios='" + IDPrecios.ToString + "'", Con)      'Selecciono todas las facturas que su balance sea mayor a 0
        Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Precios")

            Dim Tabla As DataTable = Ds.Tables("Precios")

            If Tabla.Rows.Count > 0 Then
                '   Estos son los viejos
                IDArticulo = Tabla.Rows(0).Item("IDArticulo")
                Cost = Tabla.Rows(0).Item("Costo")
                CostF = Tabla.Rows(0).Item("CostoFinal")
                PrecA = Tabla.Rows(0).Item("PrecioCredito")
                PrecB = Tabla.Rows(0).Item("PrecioContado")
                PrecC = Tabla.Rows(0).Item("Precio3")
                PrecD = Tabla.Rows(0).Item("Precio4")
                PrecBF = Tabla.Rows(0).Item("PrecioBlackFriday")
                Cont = Tabla.Rows(0).Item("Contenido")
                Medi = Tabla.Rows(0).Item("Abreviatura")

                If Costo <> 0 Then
                    If Costo <> CDbl(Cost) Then
                        TextComposed = "El costo" & VerifyChanges(Cost, Costo) & "."
                    End If
                End If

                If CostoFinal <> 0 Then
                    If CostoFinal <> CDbl(CostF) Then
                        If TextComposed <> "" Then
                            TextComposed = TextComposed & vbNewLine
                        End If
                        TextComposed = TextComposed & "El costo final" & VerifyChanges(CostF, CostoFinal) & "."
                    End If
                End If

                If PrecioA <> 0 Then
                    If PrecioA <> CDbl(PrecA) Then
                        If TextComposed <> "" Then
                            TextComposed = TextComposed & vbNewLine
                        End If
                        TextComposed = TextComposed & "El precio A" & VerifyChanges(PrecA, PrecioA) & "."
                    End If
                End If

                If PrecioB <> 0 Then
                    If PrecioB <> CDbl(PrecB) Then
                        If TextComposed <> "" Then
                            TextComposed = TextComposed & vbNewLine
                        End If
                        TextComposed = TextComposed & "El precio B" & VerifyChanges(PrecB, PrecioB) & "."
                    End If
                End If

                If PrecioC <> 0 Then
                    If PrecioC <> CDbl(PrecC) Then
                        If TextComposed <> "" Then
                            TextComposed = TextComposed & vbNewLine
                        End If
                        TextComposed = TextComposed & "El precio C" & VerifyChanges(PrecC, PrecioC) & "."
                    End If
                End If

                If PrecioD <> 0 Then
                    If PrecioD <> CDbl(PrecD) Then
                        If TextComposed <> "" Then
                            TextComposed = TextComposed & vbNewLine
                        End If
                        TextComposed = TextComposed & "El precio D" & VerifyChanges(PrecD, PrecioD) & "."
                    End If
                End If

                If PrecioBlackFriday <> 0 Then
                    If PrecioBlackFriday <> CDbl(PrecBF) Then
                        If TextComposed <> "" Then
                            TextComposed = TextComposed & vbNewLine
                        End If
                        TextComposed = TextComposed & "El precio de Black Friday" & VerifyChanges(PrecBF, PrecioBlackFriday) & "."
                    End If
                End If

                If Contenido <> 0 Then
                    If Contenido <> Cont Then
                        If TextComposed <> "" Then
                            TextComposed = TextComposed & vbNewLine
                        End If
                        TextComposed = TextComposed & "El contenido varió" & VerifyChangesContenido(Cont, Contenido) & "."
                    End If
                End If


                If Medida <> "" Then
                    If Medida <> Medi Then
                        If TextComposed <> "" Then
                            TextComposed = TextComposed & vbNewLine
                        End If
                        TextComposed = TextComposed & "La medida se modificó de " & Medi & " a " & Medida & "."
                    End If
                End If

            End If

            If TextComposed <> "" Then
            sqlQ = "INSERT INTO Libregco.PrecioArticulo_historial (IDPrecioArticulo,Fecha,IDUsuario,Modificacion,ViejoCosto,NuevoCosto,ViejoCostoFinal,NuevoCostoFinal,ViejoA,NuevoA,ViejoB,NuevoB,ViejoC,NuevoC,ViejoD,NuevoD) VALUES ('" + IDPrecios + "',NOW(), '" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString + "','" + TextComposed + "','" + Cost.ToString + "','" + Costo.ToString + "','" + CostF.ToString + "','" + CostoFinal.ToString + "','" + PrecA.ToString + "','" + PrecioA.ToString + "','" + PrecB.ToString + "','" + PrecioB.ToString + "','" + PrecC.ToString + "','" + PrecioC.ToString + "','" + PrecD.ToString + "','" + PrecioD.ToString + "')"
            cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
            End If

            Ds.Dispose()
            Tabla.Dispose()

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & cmd.CommandText.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, frm_inicio)
        'End Try
    End Function

    Function ConvertToGrayScale(ByVal Pic As Image)
        Dim bm As New Bitmap(Pic)
        Dim X As Integer
        Dim Y As Integer
        Dim clr As Integer

        For X = 0 To bm.Width - 1
            For Y = 0 To bm.Height - 1
                clr = (CInt(bm.GetPixel(X, Y).R) +
                       bm.GetPixel(X, Y).G +
                       bm.GetPixel(X, Y).B) \ 3
                bm.SetPixel(X, Y, Color.FromArgb(clr, clr, clr))
            Next Y
        Next X

        Return bm
    End Function

    Function GetPriceLevel(ByVal Precio As Double, ByVal IDPrecio As Double, IDMoneda As String) As String
        Dim Dstemp As New DataSet

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDPrecios,Costo,CostoFinal,PrecioContado,PrecioCredito,Precio3,Precio4,IDMoneda,TasaCompra as TasaArticulo FROM Libregco.PrecioArticulo INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.TipoMoneda on PrecioArticulo.IDMoneda=TipoMoneda.IDTipoMoneda WHERE IDPrecios= '" + IDPrecio.ToString + "' and PrecioArticulo.Nulo=0", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Dstemp, "precioarticulo")

        Dim Tabla As DataTable = Dstemp.Tables("precioarticulo")

        cmd = New MySqlCommand("SELECT TasaCompra FROM Libregco.tipomoneda where IDTipoMoneda='" + IDMoneda.ToString + "'", ConLibregco)
        Dim TasaFactura As Double = Convert.ToDouble(cmd.ExecuteScalar())
        ConLibregco.Close()

        If (CDbl(Tabla.Rows(0).Item("PrecioCredito")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)) <= Precio Then
            Return "A"
        ElseIf (CDbl(Tabla.Rows(0).Item("PrecioContado")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)) <= Precio Then
            Return "B"
        ElseIf (CDbl(Tabla.Rows(0).Item("Precio3")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)) <= Precio Then
            Return "C"
        ElseIf (CDbl(Tabla.Rows(0).Item("Precio4")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)) <= Precio Then
            Return "D"
        ElseIf (CDbl(Tabla.Rows(0).Item("Costo")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)) <= Precio Then
            Return "E"
        ElseIf (CDbl(Tabla.Rows(0).Item("CostoFinal")) * (CDbl(Tabla.Rows(0).Item("TasaArticulo")) / TasaFactura)) <= Precio Then
            Return "F"
        Else
            Return "N/A"
        End If

        Tabla.Dispose()
        Dstemp.Dispose()

    End Function

    Public Iterator Function GetTreeNodes(Of T)(ByVal source As IEnumerable(Of T), ByVal isRoot As Func(Of T, Boolean), ByVal getChilds As Func(Of T, IEnumerable(Of T), IEnumerable(Of T)), ByVal getItem As Func(Of T, TreeNode)) As IEnumerable(Of TreeNode)
        Dim roots As IEnumerable(Of T) = source.Where(Function(x) isRoot(x))
        For Each root As T In roots
            Yield ConvertEntityToTreeNode(root, source, getChilds, getItem)
        Next
    End Function

    Public Function ConvertEntityToTreeNode(Of T)(ByVal entity As T, ByVal source As IEnumerable(Of T), ByVal getChilds As Func(Of T, IEnumerable(Of T), IEnumerable(Of T)), ByVal getItem As Func(Of T, TreeNode)) As TreeNode
        Dim node As TreeNode = getItem(entity)
        Dim childs = getChilds(entity, source)
        For Each child As T In childs
            node.Nodes.Add(ConvertEntityToTreeNode(child, source, getChilds, getItem))
        Next
        Return node
    End Function

    Public Function VerificarEntidadCosto(ByVal CostoAsignado As Double, ByVal IDPrecio As Double)
        If ConLibregco.State = ConnectionState.Open Then
            ConLibregco.Close()
        End If

        If IsNumeric(CostoAsignado) Then

            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT if(ROUND(Costo,2)=" & CostoAsignado & ",'El costo no posee variaciones',if(ROUND(Costo,2)>" & CostoAsignado & ",concat('El costo ha disminuido ',CONCAT(FORMAT(abs((" & CostoAsignado & "/Costo)-1)*100,2)),'%'),if(ROUND(Costo,2)<" & CostoAsignado & ",concat('El costo ha aumentado un ',CONCAT(FORMAT(abs((" & CostoAsignado & "/Costo)-1)*100,2)),'%'),'4'))) as Num from Libregco.PrecioArticulo where IDPrecios='" + IDPrecio.ToString + "'", ConLibregco)
            Dim Value As String = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

            Return Value

        Else

            Return 0
        End If

        ''1 Es que el CostoAsignado es igual al anterior costo                      'Blanco
        ''2 Es que el costoasignado es mayor al costo anterior                              'Rojo
        ''3 Es que el costoasignado es menor al costo anterior 

    End Function

    Public Sub UpdateLastUpdatePrices(ByVal IDPrecio As String)
        Dim Dstemp As New DataSet

        cmd = New MySqlCommand("SELECT IFNULL((Select FechaFactura from Libregco.Compras inner join Libregco.DetalleCompra on Compras.IDCompra=DetalleCompra.IDCompra Where DetalleCompra.IDArticulo=Articulos.IDArticulo ORDER BY Compras.FechaFactura DESC LIMIT 1),'1991-01-01') as UltimaCompraZ,IFNULL((Select DetalleCompra.Importe from Libregco.Compras INNER JOIN Libregco.DetalleCompra on Compras.IDCompra=DetalleCompra.IDCompra Where DetalleCompra.IDArticulo=Articulos.IDArticulo ORDER BY Compras.FechaFactura DESC LIMIT 1),0) as UltCostoCompraZ,IFNULL((Select FechaFactura from Libregco_Main.Compras inner join Libregco_Main.DetalleCompra on Compras.IDCompra=DetalleCompra.IDCompra Where DetalleCompra.IDArticulo=Articulos.IDArticulo ORDER BY Compras.FechaFactura DESC LIMIT 1),'1991-01-01') as UltimaCompraA,IFNULL((Select DetalleCompra.Importe from Libregco_Main.Compras INNER JOIN Libregco_Main.DetalleCompra on Compras.IDCompra=DetalleCompra.IDCompra Where DetalleCompra.IDArticulo=Articulos.IDArticulo ORDER BY Compras.FechaFactura DESC LIMIT 1),0) as UltCostoCompraA,IFNULL((Select DATE(Fecha) from Libregco.PrecioArticulo_historial where PrecioArticulo_historial.IDPrecioArticulo=PrecioArticulo.IDPrecios ORDER BY PrecioArticulo_historial.FechA DESC LIMIT 1),'1990-01-01') as UltimoCambioPrecios from Libregco.PrecioArticulo INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo where PrecioArticulo.IDPrecios='" + IDPrecio.ToString + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Dstemp, "precioarticulo")

        If Dstemp.Tables("precioarticulo").Rows.Count > 0 Then
            Dim ArrDates As New List(Of Date)

            If CDate(Dstemp.Tables("precioarticulo").Rows(0).Item("UltimaCompraZ")) > CDate(Dstemp.Tables("precioarticulo").Rows(0).Item("UltimaCompraA")) Then
                sqlQ = "UPDATE Libregco.precioarticulo Set UltimoCostoCompra='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltCostoCompraZ").ToString + "',UltimaActualizacion='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltimaCompraZ").ToString + "',UltimoCambioPrecios='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltimoCambioPrecios").ToString + "' where IDPrecios='" + IDPrecio.ToString + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
            Else
                sqlQ = "UPDATE Libregco.precioarticulo Set UltimoCostoCompra='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltCostoCompraA").ToString + "',UltimaActualizacion='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltimaCompraZ").ToString + "',UltimoCambioPrecios='" + Dstemp.Tables("precioarticulo").Rows(0).Item("UltimoCambioPrecios").ToString + "' where IDPrecios='" + IDPrecio.ToString + "'"
                cmd = New MySqlCommand(sqlQ, Con)
                cmd.ExecuteNonQuery()
            End If

        End If

        Dstemp.Dispose()

    End Sub
    Public Function VerificarEntidadPrecio(ByVal CostoAsignado As Double, ByVal IDPrecio As Double)
        Dim Precios As New ArrayList
        If ConLibregco.State = ConnectionState.Open Then
            ConLibregco.Close()
        End If

        Dim DSTemp As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioCredito,PrecioContado,Precio3,Precio4 FROM libregco.precioarticulo where IDPrecios='" + IDPrecio.ToString + "'", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DSTemp, "precioarticulo")
        ConLibregco.Close()

        Dim Tabla As DataTable = DSTemp.Tables("precioarticulo")

        If Tabla.Rows.Count > 0 Then
            Precios.Add(Tabla.Rows(0).Item("PrecioCredito"))
            Precios.Add(Tabla.Rows(0).Item("PrecioContado"))
            Precios.Add(Tabla.Rows(0).Item("Precio3"))
            Precios.Add(Tabla.Rows(0).Item("Precio4"))

            Precios.Sort()

            Dim MinPrecio As Double = Precios.Item(0)
            '1 El costo es menor que los precios
            '2 El costo es mayor que los precios 

            If Math.Round(MinPrecio, 2) > Math.Round(CostoAsignado, 2) Then
                Return "Beneficio sobre el precio mínimo " & CDbl(CDbl(CDbl(MinPrecio) / CDbl(CostoAsignado)) - 1).ToString("P2")
            Else
                Return "El costo es mayor al precio mínimo disponible"
            End If
        Else
            Return ""
        End If

        Tabla.Dispose()
        DSTemp.Dispose()
        Precios.Clear()
    End Function

    Function GetColumnBounds(ByVal column As DevExpress.XtraGrid.Columns.GridColumn) As Rectangle
        Dim gridInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo = CType(column.View.GetViewInfo(), DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo)
        Dim colInfo As DevExpress.XtraGrid.Drawing.GridColumnInfoArgs = gridInfo.ColumnsInfo(column)
        If Not colInfo Is Nothing Then
            Return colInfo.Bounds
        Else
            Return Rectangle.Empty
        End If
    End Function
End Module
