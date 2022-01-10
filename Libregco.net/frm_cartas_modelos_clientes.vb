Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_cartas_modelos_clientes
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList

    Private Sub frm_cartas_modelos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        ChangePictureRdb()
        FillReportes()
        Actualizar()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub ChangePictureRdb()
        If rdbPresentacion.Checked = True Then
            PicSalida.Image = My.Resources.Preview_x72
        ElseIf rdbImpresora.Checked = True Then
            PicSalida.Image = My.Resources.Printer_x72
        ElseIf rdbPDF.Checked = True Then
            PicSalida.Image = My.Resources.AdobeReader_x72
        ElseIf rdbExcel.Checked = True Then
            PicSalida.Image = My.Resources.Ms_Excel_x72
        End If
    End Sub

    Private Sub rdbImpresora_CheckedChanged(sender As Object, e As EventArgs) Handles rdbImpresora.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub rdbPDF_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPDF.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub rdbExcel_CheckedChanged(sender As Object, e As EventArgs) Handles rdbExcel.CheckedChanged
        ChangePictureRdb()
    End Sub

    Private Sub FillReportes()
        DgvReportes.Rows.Clear()
        Con.Open()
        Dim Consulta As New MySqlCommand("SELECT IDReportes,Descripcion,Path FROM reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='CorrespondenciaClientes' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
        Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

        While LectorArticulos.Read
            DgvReportes.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2))
        End While
        LectorArticulos.Close()
        Con.Close()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub txtIDCliente_Leave(sender As Object, e As EventArgs) Handles txtIDCliente.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Nombre from Clientes Where IDCliente='" + txtIDCliente.Text + "'", ConLibregco)
        txtCliente.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtCliente.Text = "" Then txtIDCliente.Clear()

        FillInfoClientes()
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        frm_buscar_clientes.ShowDialog(Me)

        FillInfoClientes()
    End Sub

    Private Sub Actualizar()
        LtCliente.Items.Add("Tipo de documento: ")
        LtCliente.Items.Add("No.")
        LtCliente.Items.Add("")
        LtCliente.Items.Add("Género:")
        LtCliente.Items.Add("Nacionalidad:")
        LtCliente.Items.Add("")
        LtCliente.Items.Add("Dirección:")
        LtCliente.Items.Add("Contacto:")
        LtCliente.Items.Add("")
        LtCliente.Items.Add("Grupo:")
        LtCliente.Items.Add("Tipo:")
        LtCliente.Items.Add("")
        LtCliente.Items.Add("Calificación:")
        LtCliente.Items.Add("Cobrador:")
        LtCliente.Items.Add("Balance:")
        LtCliente.Items.Add("Fecha de ingreso:")

        MakeRoundedImage(My.Resources.no_photo, PicFoto)
    End Sub

    Friend Sub FillInfoClientes()
        Dim Ds1 As New DataSet
        Dim wFile As System.IO.FileStream

        Ds1.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDCliente,Clientes.Nombre,Clientes.Apodo,Clientes.IDNacionalidad,Nacionalidad,Gentilicio,Clientes.IDTipoIdentificacion,Identificacion,TipoIdentificacion.Descripcion as TipoIdentificacion,Clientes.IDGenero,Genero,Clientes.FechaNacimiento,LugarNacimiento,Clientes.IDProvincia,Provincia,Clientes.IDMunicipio,Municipio,Clientes.Direccion,Referencia,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.Sueldo,Vivienda,Vehiculo,TrabajoActivo,SeguroMedico,CuentasBancaria,Tarjeta,Clientes.CorreoElectronico,Clientes.IDOcupacion,OcupacionCliente.Ocupacion as OcupacionCliente,LugarTrabajo,UbicacionTrabajo,TelefonoTrabajo,PadreCliente,MadreCliente,DomicilioPaternos,TelefonoPaternos,Clientes.IDCivil,Estadocivil,Conyuge,TelefonoConyuge,IDOcupacionConyuge,OcupacionConyuge.Ocupacion as OcupacionConyuge,LugarTrabajoConyuge,PadreConyuge,MadreConyuge,DomicilioPatConyuge,TelefonoPatConyuge,Clientes.IDCalificacion,Calificacion,CalificacionAutonoma,DiasCondicion,LimiteCredito,Clientes.IDGrupocxc,Grupocxc.Descripcion as GrupoCxc,Clientes.IDTipoCredito,Clientes.IDTipoCredito,TipoCredito.Descripcion as TipoCredito,Clientes.IDEmpleado,Empleados.Nombre as NombreEmpleado,Clientes.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Precio,InformacionAdc,Clientes.EntregarPorConduce,Clientes.Alertas,Clientes.FechaIngreso,NoRecibirCheques,CuentaIncobrable,GenerarCargo,CerrarCredito,BloqueoCobrador,EntregarPorConduce,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto,BalanceGeneral,(SELECT Coalesce(Sum(Cargos),0) from" & SysName.Text & "FacturaDatos Where FacturaDatos.Balance>0 and FacturaDatos.Nulo=0 and IDCliente=Clientes.IDCliente) as CargosCliente,Desactivar,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible FROM Libregco.clientes INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "Empleados on Clientes.IDEmpleado=Empleados.IDEmpleado INNER JOIN Libregco.Ocupacion as OcupacionConyuge on Clientes.IDOcupacionConyuge=OcupacionConyuge.IDOcupacion INNER JOIN Libregco.estadocivil on Clientes.IDCivil=EstadoCivil.IDCivil INNER JOIN Libregco.Ocupacion as OcupacionCliente on Clientes.IDOcupacion=OcupacionCliente.IDOcupacion INNER JOIN Libregco.Provincias on Clientes.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.genero on Clientes.IDGenero=Genero.IDGenero INNER JOIN Libregco.Nacionalidad on Clientes.IDNacionalidad=Nacionalidad.IDNacionalidad INNER JOIN Libregco.TipoIdentificacion on Clientes.IDTipoIdentificacion=TipoIdentificacion.IDTipoIdentificacion INNER JOIN Libregco.TipoCredito on Clientes.IDTipoCredito=TipoCredito.IDTipoCredito INNER JOIN Libregco.GrupoCxc on Clientes.IDGrupoCxc=GrupoCxc.IDGrupocxc INNER JOIN" & SysName.Text & "ComprobanteFiscal on Clientes.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal Where IDCliente='" + txtIDCliente.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Clientes")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds1.Tables("Clientes")

        If Tabla.Rows.Count = 0 Then
            Actualizar()
        Else
            LtCliente.Items.Clear()

            LtCliente.Items.Add("Tipo de documento: " & "[" & Tabla.Rows(0).Item("IDTipoIdentificacion") & "] " & Tabla.Rows(0).Item("TipoIdentificacion"))
            LtCliente.Items.Add("No. " & Tabla.Rows(0).Item("Identificacion"))
            LtCliente.Items.Add("")
            LtCliente.Items.Add("Género: " & "[" & Tabla.Rows(0).Item("IDGenero") & "] " & Tabla.Rows(0).Item("Genero"))
            LtCliente.Items.Add("Nacionalidad: " & "[" & Tabla.Rows(0).Item("IDNacionalidad") & "] " & Tabla.Rows(0).Item("Nacionalidad"))
            LtCliente.Items.Add("")
            LtCliente.Items.Add("Dirección: " & Tabla.Rows(0).Item("Direccion") & ", " & Tabla.Rows(0).Item("Municipio") & ", " & Tabla.Rows(0).Item("Provincia") & ".")
            LtCliente.Items.Add("Contacto: " & Tabla.Rows(0).Item("TelefonoPersonal") & " " & Tabla.Rows(0).Item("TelefonoHogar"))
            LtCliente.Items.Add("")
            LtCliente.Items.Add("Grupo: " & "[" & Tabla.Rows(0).Item("IDGrupocxc") & "] " & Tabla.Rows(0).Item("Grupocxc"))
            LtCliente.Items.Add("Tipo: " & "[" & Tabla.Rows(0).Item("IDTipoCredito") & "] " & Tabla.Rows(0).Item("TipoCredito"))
            LtCliente.Items.Add("")
            LtCliente.Items.Add("Calificación: " & "[" & Tabla.Rows(0).Item("IDCalificacion") & "] " & Tabla.Rows(0).Item("Calificacion"))
            LtCliente.Items.Add("Cobrador: " & "[" & Tabla.Rows(0).Item("IDEmpleado") & "] " & Tabla.Rows(0).Item("NombreEmpleado"))
            LtCliente.Items.Add("Balance: " & CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C"))
            LtCliente.Items.Add("Fecha de ingreso: " & CDate(Tabla.Rows(0).Item("FechaIngreso")).ToLongDateString)

            If IsDBNull(Tabla.Rows(0).Item("Foto")) Then
                MakeRoundedImage(My.Resources.no_photo, PicFoto)
            Else
                wFile = New FileStream((Tabla.Rows(0).Item("Foto")), FileMode.Open, FileAccess.Read)
                MakeRoundedImage(System.Drawing.Image.FromStream(wFile), PicFoto)
                wFile.Close()
            End If
        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtIDCliente.Clear()
        txtCliente.Clear()
        Actualizar()
        txtIDCliente.Focus()
    End Sub

    Private Sub LoadAnimation()
        If PicLoading.Visible = False Then
            PicLoading.Visible = True
            ToolSeparator.Visible = True
            lblStatusBar.Text = "Cargando..."
        Else
            PicLoading.Visible = False
            ToolSeparator.Visible = False
            lblStatusBar.Text = "Listo"
        End If
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try

            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & DgvReportes.CurrentRow.Cells(2).Value) Else ObjRpt.Load("C:" & DgvReportes.CurrentRow.Cells(2).Value.Replace("\Libregco\Libregco.net", ""))


            If txtIDCliente.Text = "" Then
                MessageBox.Show("Seleccione el cliente para generar los reportes de correspondencia.", "Seleccionar cliente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnCliente.PerformClick()
                Exit Sub
            End If

            If DgvReportes.SelectedRows.Count > 0 Then
                MessageBox.Show("Por favor seleccione el reporte de correspondencia que desea generar.", "Seleccionar reporte de correspondencia", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            '@IDCliente
            crParameterDiscreteValue.Value = txtIDCliente.Text
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDCliente")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            '@IDEmpleado
            crParameterDiscreteValue.Value = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDEmpleado")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            LoadAnimation()

            If rdbPresentacion.Checked = True Then
                lblStatusBar.Text = "Visualizando el reporte..."
                Dim TmpForm = New frm_reportView
                TmpForm.Show(Me)
                TmpForm.CrystalViewer.ReportSource = ObjRpt
                TmpForm.CrystalViewer.Refresh()
                TmpForm.CrystalViewer.Cursor = Cursors.Default

            ElseIf rdbImpresora.Checked = True Then
                lblStatusBar.Text = "Reporte en impresión..."
                Dim PrintDialog As New PrintDialog
                With PrintDialog
                    .AllowSelection = True
                    .AllowSomePages = True
                    .AllowPrintToFile = True
                End With

                If (PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    Me.Cursor = Cursors.WaitCursor
                    ObjRpt.SummaryInfo.ReportTitle = DgvReportes.CurrentRow.Cells(1).Value.ToString & " " & Today.ToString("dd-MM-yyyy")
                    ObjRpt.SummaryInfo.ReportAuthor = frm_inicio.lblNombre.Text & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "] "
                    ObjRpt.PrintOptions.PrinterName = PrintDialog.PrinterSettings.PrinterName
                    Dim Settings As New PrinterSettings
                    Dim PrinterDefault As String = Settings.PrinterName
                    Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", PrintDialog.PrinterSettings.PrinterName))
                    ObjRpt.PrintToPrinter(PrintDialog.PrinterSettings.Copies, PrintDialog.PrinterSettings.Collate, PrintDialog.PrinterSettings.FromPage, PrintDialog.PrinterSettings.ToPage)
                    Shell(String.Format("rundll32 printui.dll,PrintUIEntry /y /n ""{0}""", PrinterDefault))
                    Me.Cursor = Cursors.Default
                End If

            ElseIf rdbPDF.Checked = True Then
                lblStatusBar.Text = "Convirtiendo en PDF..."
                Dim GetFileName As New SaveFileDialog
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOtions As New PdfRtfWordFormatOptions

                With GetFileName
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                    .Title = ("Especifique Ubicación")
                    .Filter = "Portable Documento Format (*.pdf)|*.pdf"
                    .FileName = DgvReportes.CurrentRow.Cells(1).Value.ToString & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
                    .AddExtension = True
                End With

                If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
                    CrDiskFileDestinationOptions.DiskFileName = GetFileName.FileName
                    CrExportOptions = ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    ObjRpt.Export()
                    MessageBox.Show("La exportación ha finalizado.", "Exportación satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Process.Start(GetFileName.FileName)
                End If

            ElseIf rdbExcel.Checked = True Then
                lblStatusBar.Text = "Convirtiendo en archivo de Excel..."
                Dim GetFileName As New SaveFileDialog
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOtions As New ExcelFormatOptions

                With GetFileName
                    .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                    .Title = ("Especifique Ubicación")
                    .Filter = "Excel (*.xls)|*.xls"
                    .FileName = DgvReportes.CurrentRow.Cells(1).Value.ToString & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
                    .AddExtension = True
                End With

                If GetFileName.ShowDialog = Windows.Forms.DialogResult.OK Then
                    CrDiskFileDestinationOptions.DiskFileName = GetFileName.FileName
                    CrExportOptions = ObjRpt.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.Excel
                        .ExportDestinationOptions = CrDiskFileDestinationOptions
                        .ExportFormatOptions = CrFormatTypeOtions
                    End With
                    ObjRpt.Export()
                    MessageBox.Show("La exportación ha finalizado.", "Exportación satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Process.Start(GetFileName.FileName)
                End If

            End If

            lblStatusBar.Text = "Listo"
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub rdbPresentacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPresentacion.CheckedChanged
        ChangePictureRdb()
    End Sub

End Class