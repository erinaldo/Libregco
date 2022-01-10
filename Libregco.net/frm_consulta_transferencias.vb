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

Public Class frm_consulta_transferencias

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Friend lblNulo, lblIDUsuario, IDReport, NameReport, PathReport As New Label
    Dim SelectCommand As String = "SELECT IDTransferenciaArt,SecondID,Fecha,Referencia,AlmacenEnt.Almacen as AlmEnt,AlmacenSal.Almacen as AlmSal,Total,transfenciaarticulos.Nulo FROM" & SysName.Text & "transfenciaarticulos INNER JOIN" & SysName.Text & "Almacen as AlmacenEnt on transfenciaarticulos.IDAlmacenEntrada=AlmacenEnt.IDAlmacen INNER JOIN" & SysName.Text & "Almacen as AlmacenSal on transfenciaarticulos.IDAlmacenSalida=AlmacenSal.IDAlmacen"
    Dim FullCommand, FechaValue, AlmacenEntValue, AlmacenSalValue, ImporteValue, NuloValue As String
    Friend AlmControl As String
    Dim A1, A2, A3, A4 As String
    Dim Permisos As New ArrayList

    Private Sub frm_consulta_transferencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarDatos()
        Actualizar()
        cmd = New MySqlCommand("SELECT IDTransferenciaArt,SecondID,Fecha,Referencia,AlmacenEnt.Almacen as AlmEnt,AlmacenSal.Almacen as AlmSal,Total,transfenciaarticulos.Nulo FROM" & SysName.Text & "transfenciaarticulos INNER JOIN" & SysName.Text & "Almacen as AlmacenEnt on transfenciaarticulos.IDAlmacenEntrada=AlmacenEnt.IDAlmacen INNER JOIN" & SysName.Text & "Almacen as AlmacenSal on transfenciaarticulos.IDAlmacenSalida=AlmacenSal.IDAlmacen WHERE Fecha Between '" + txtFechaInicial.Value.ToString("yyyy-MM-dd") + "' and '" + txtFechaFinal.Value.ToString("yyyy-MM-dd") + "' and transfenciaarticulos.Nulo=0 ORDER BY IDTransferenciaArt DESC", Con)
        RefrescarTabla()
        ConstructorSQL()
        FillReportes()
        Permisos = PasarPermisos(Me.Tag)
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillReportes()
        Try
            Ds1.Clear()
            Con.Open()
            If rdbEspecifico.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='TransferenciasInv' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            ElseIf rdbGeneral.Checked = True Then
                cmd = New MySqlCommand("SELECT Descripcion FROM Reportes INNER JOIN PaperSize on Reportes.IDPaperName=PaperSize.IDPaperSize Where MenuString='Transferencias Inventario' and Reportes.Activo=1 and PaperSize.Activo=1 ORDER BY NoOrden ASC", Con)
            End If

            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Reportes")
            CbxFormato.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Reportes")

            For Each Fila As DataRow In Tabla.Rows
                CbxFormato.Items.Add(Fila.Item("Descripcion"))
            Next

            If Tabla.Rows.Count > 0 Then
                CbxFormato.SelectedIndex = 0
            Else
                MessageBox.Show("No se encontraron reportes que involucren este vínculo del módulo.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub

    Private Sub LimpiarDatos()
        txtIDAlmacenEnt.Clear()
        txtAlmacenEnt.Clear()
        txtIDAlmacenSal.Clear()
        txtAlmacenSal.Clear()
        txtImporte.Clear()
        txtIDAlmacenEnt.Focus()
        chkNulos.Checked = False
        lblNulo.Text = 0
        SummaCond()
    End Sub

    Private Sub Actualizar()
        txtFechaFinal.Text = Today
        txtFechaInicial.Text = Today
    End Sub

    Private Sub RefrescarTabla()
        Try
            Ds.Clear()
            ConMixta.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Transferencias")
            DgvTransferencias.DataSource = Ds
            DgvTransferencias.DataMember = "Transferencias"
            ConMixta.Close()
            PropiedadColumnsDgv()
            SumarRows()
            MarcarCanceladas()
            DgvTransferencias.ClearSelection()
        Catch ex As Exception
            ConMixta.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvTransferencias

            .Columns(0).Visible = False

            .Columns(1).Width = 125
            .Columns(1).HeaderText = "No. Transferencia"

            .Columns(2).HeaderText = "Fecha"
            .Columns(2).DefaultCellStyle.Format = ("dd/MM/yyyy")
            .Columns(2).Width = 90

            .Columns(3).Width = 120

            .Columns(4).Width = 150
            .Columns(4).HeaderText = "Entrada"

            .Columns(5).Width = 150
            .Columns(5).HeaderText = "Salida"

            .Columns(6).Width = 120
            .Columns(6).HeaderText = "Importe"
            .Columns(6).DefaultCellStyle.Format = ("C")

            .Columns(7).Visible = False
        End With
    End Sub

    Private Sub SumarRows()
        Dim x As Integer = 0
        Dim Monto As Double = 0

Inicio:
        If x = DgvTransferencias.Rows.Count Then
            GoTo FIn
        End If

        Monto = Monto + CDbl(DgvTransferencias.Rows(x).Cells(6).Value)
        x = x + 1
        GoTo Inicio
Fin:
        lblCantidad.Text = "Registros Encontrados: " & DgvTransferencias.Rows.Count
        lblSumaTotal.Text = "Suma Total: " & Monto.ToString("C")
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub SelectAlmEnt()
        Try
            Con.Open()
            cmd = New MySqlCommand("SELECT Almacen FROM Almacen Where IDAlmacen='" + txtIDAlmacenEnt.Text + "'", Con)
            txtAlmacenEnt.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " Desde SelectCliente")
            txtAlmacenEnt.Text = ""
        End Try
    End Sub

    Private Sub SelectAlmSal()
        Try
            Con.Open()
            cmd = New MySqlCommand("SELECT Almacen FROM Almacen Where IDAlmacen='" + txtIDAlmacenSal.Text + "'", Con)
            txtAlmacenSal.Text = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & " Desde SelectCliente")
            txtAlmacenSal.Text = ""
        End Try
    End Sub

    Private Sub txtIDAlmacenEnt_Leave(sender As Object, e As EventArgs) Handles txtIDAlmacenEnt.Leave
        SelectAlmEnt()
        VerificarCondicionAlmEnt()
    End Sub

    Private Sub txtIDAlmacenSal_Leave(sender As Object, e As EventArgs) Handles txtIDAlmacenSal.Leave
        SelectAlmSal()
        VerificarCondicionAlmSal()
    End Sub

    Private Sub chkNulos_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulos.CheckedChanged
        If chkNulos.Checked = True Then
            lblNulo.Text = 1
        Else
            lblNulo.Text = 0
        End If

        VerificarCondicionNulo()
    End Sub

    Private Sub txtImporte_Leave(sender As Object, e As EventArgs) Handles txtImporte.Leave
        VerificarCondicionImporte()
    End Sub

    Private Sub txtFechaFinal_Leave(sender As Object, e As EventArgs)
        If IsDate(txtFechaFinal.Text) Then
        Else
            txtFechaFinal.Text = ""
        End If
    End Sub

    Private Sub txtFechaInicial_Leave(sender As Object, e As EventArgs)
        If IsDate(txtFechaInicial.Text) Then
        Else
            txtFechaInicial.Text = ""
        End If
    End Sub

    Private Sub txtFechaFinal_TextChanged(sender As Object, e As EventArgs)
        VerificarCondicionFecha()
    End Sub

    Private Sub txtFechaInicial_TextChanged(sender As Object, e As EventArgs)
        VerificarCondicionFecha()
    End Sub

    Private Sub VerificarCondicionFecha()
        If IsDate(txtFechaFinal.Text) And IsDate(txtFechaInicial.Text) Then
            FechaValue = " transfenciaarticulos.Fecha BETWEEN '" & txtFechaInicial.Value.ToString("yyyy-MM-dd") & "' AND '" & txtFechaFinal.Value.ToString("yyyy-MM-dd") & "'"
        Else
            FechaValue = ""
        End If
        ConstructorSQL()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cmd = New MySqlCommand(FullCommand, Con)
        RefrescarTabla()
    End Sub

    Private Sub btnStructure_Click(sender As Object, e As EventArgs) Handles btnStructure.Click
        frm_query_structure.txtQuery.Text = "SQL Query: " & FullCommand
        frm_query_structure.ShowDialog()
    End Sub

    Private Sub VerificarCondicionNulo()
        If lblNulo.Text = 1 = True Then
            NuloValue = ""
        Else
            NuloValue = " transfenciaarticulos.Nulo=0 "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionImporte()
        Try
            If txtImporte.Text = "" Then
                ImporteValue = ""
            Else
                ImporteValue = " Total='" + txtImporte.Text + "'" & " "
            End If

            ConstructorSQL()
            txtImporte.Text = CDbl(txtImporte.Text).ToString("C")

        Catch ex As Exception
            txtImporte.Text = ""
        End Try
    End Sub

    Private Sub txtImporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporte.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub SummaCond()
        VerificarCondicionAlmEnt()
        VerificarCondicionAlmSal()
        VerificarCondicionFecha()
        VerificarCondicionImporte()
        VerificarCondicionNulo()
    End Sub

    Private Sub VerificarCondicionAlmEnt()
        If txtAlmacenEnt.Text = "" Then
            AlmacenEntValue = ""
        Else
            AlmacenEntValue = " AlmacenEnt.IDAlmacen='" + txtIDAlmacenEnt.Text + "'" & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub VerificarCondicionAlmSal()
        If txtAlmacenSal.Text = "" Then
            AlmacenSalValue = ""
        Else
            AlmacenSalValue = " AlmacenSal.IDAlmacen='" + txtIDAlmacenSal.Text + "'" & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If FechaValue <> "" Or AlmacenEntValue <> "" Or AlmacenSalValue <> "" Or ImporteValue <> "" Or NuloValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If FechaValue <> "" And AlmacenEntValue & AlmacenSalValue & ImporteValue & NuloValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If AlmacenEntValue <> "" And AlmacenSalValue & ImporteValue & NuloValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If AlmacenSalValue <> "" And ImporteValue & NuloValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If ImporteValue <> "" And NuloValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        FullCommand = SelectCommand & PutWhere & FechaValue & A1 & AlmacenEntValue & A2 & AlmacenSalValue & A3 & ImporteValue & A4 & NuloValue
    End Sub


    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvTransferencias.Rows
                If CInt(Row.Cells(6).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtImporte_Enter(sender As Object, e As EventArgs) Handles txtImporte.Enter
        If txtImporte.Text = "" Then
        Else
            txtImporte.Text = CDbl(txtImporte.Text)
        End If
    End Sub

    Private Sub btnBuscarAlmEnt_Click(sender As Object, e As EventArgs) Handles btnBuscarAlmEnt.Click
        AlmControl = 0
        frm_buscar_almacen_mant.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarAlmSal_Click(sender As Object, e As EventArgs) Handles btnBuscarAlmSal.Click
        AlmControl = 1
        frm_buscar_almacen_mant.ShowDialog(Me)
    End Sub

    Private Sub rdbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEspecifico.CheckedChanged
        FillReportes()
    End Sub

    Private Sub txtFechaInicial_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaInicial.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub txtFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaFinal.ValueChanged
        VerificarCondicionFecha()
    End Sub

    Private Sub CbxFormato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFormato.SelectedIndexChanged
        Ds1.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM Reportes Where Descripcion= '" + CbxFormato.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Reportes")
        Con.Close()

        Dim Tabla As DataTable = Ds1.Tables("Reportes")
        IDReport.Text = (Tabla.Rows(0).Item("IDReportes"))
        NameReport.Text = (Tabla.Rows(0).Item("Reporte"))
        PathReport.Text = (Tabla.Rows(0).Item("Path"))

        If (Tabla.Rows(0).Item("HabilitadoResumen")) = 0 Then
            chkResumir.Visible = False
        Else
            chkResumir.Visible = True
        End If
    End Sub


    Private Sub btnPresentar_Click(sender As Object, e As EventArgs) Handles btnPresentar.Click
        Try
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


            If DgvTransferencias.Rows.Count = 0 Then
                MessageBox.Show("No se encuentran registros para presentar.", "No hay resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting

            If rdbGeneral.Checked = True Then
                '@IDUsuario
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDUsuario")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@AlmacenEnt
                If txtIDAlmacenEnt.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDAlmacenEnt.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@AlmacenEnt")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@AlmacenSal
                If txtIDAlmacenSal.Text = "" Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtIDAlmacenSal.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@AlmacenSal")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Producto
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Producto")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Medida
                crParameterDiscreteValue.Value = 0
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Medida")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Estado
                If chkNulos.Checked = True Then
                    crParameterDiscreteValue.Value = 2
                Else
                    crParameterDiscreteValue.Value = 0
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Estado")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Fecha
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Fecha")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterRangeValue = New ParameterRangeValue

                With crParameterRangeValue
                    .StartValue = txtFechaInicial.Value.ToString("yyyy-MM-dd")
                    .UpperBoundType = RangeBoundType.BoundInclusive
                    .EndValue = txtFechaFinal.Value.ToString("yyyy-MM-dd")
                    .LowerBoundType = RangeBoundType.BoundInclusive
                End With

                crParameterValues.Add(crParameterRangeValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                '@Importe
                If txtImporte.Text = "" Or txtImporte.Text = CDbl(0).ToString("C") Then
                    crParameterDiscreteValue.Value = 0
                Else
                    crParameterDiscreteValue.Value = txtImporte.Text
                End If
                crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                crParameterFieldDefinition = crParameterFiledDefinitions.Item("@Importe")
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                'Setting Info 
                'Resumir Reporte
                If chkResumir.Checked = True Then
                    ObjRpt.SetParameterValue("@Resumir", 1)
                Else
                    ObjRpt.SetParameterValue("@Resumir", 0)
                End If
                'Ordenamiento de Reporte
                ObjRpt.SetParameterValue("@SortedField", "")
                ObjRpt.SetParameterValue("Ordenado", "Ordenado por: " & "No. Cotización")
                'RangoFechas()
                ObjRpt.SetParameterValue("@RangoFechas", "Desde " & txtFechaInicial.Value.ToString("dd/MM/yyyy") & " Hasta " & txtFechaFinal.Value.ToString("dd/MM/yyyy"))
                'Usuario Info
                ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")
                ''Almacenes
                If txtIDAlmacenEnt.Text = "" Then
                    ObjRpt.SetParameterValue("AlmacenesEnt", "Entrada: Todos los almacenes")
                Else
                    ObjRpt.SetParameterValue("AlmacenesEnt", "Entrada: " & txtAlmacenEnt.Text)
                End If
                If txtIDAlmacenSal.Text = "" Then
                    ObjRpt.SetParameterValue("AlmacenesSal", "Salida: Todos los almacenes")
                Else
                    ObjRpt.SetParameterValue("AlmacenesSal", "Salida: " & txtAlmacenSal.Text)
                End If
                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf rdbEspecifico.Checked = True Then
                If DgvTransferencias.SelectedRows.Count > 0 Then
                    Dim IDTransferencia As New Label
                    IDTransferencia.Text = DgvTransferencias.SelectedRows(0).Cells(0).Value

                    If DgvTransferencias.SelectedRows(0).Cells(7).Value = 1 Then
                        MessageBox.Show("La transferencia No. " & DgvTransferencias.SelectedRows(0).Cells(1).Value & " de fecha " & DgvTransferencias.SelectedRows(0).Cells(2).Value & " está nulo, por lo que no se puede visualizar.", "Documento no activo en el sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    crParameterDiscreteValue.Value = IDTransferencia.Text
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDDocumento")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                Else
                    MessageBox.Show("No hay una fila seleccionada.")
                    Exit Sub
                End If
            End If

            LoadAnimation()

            If rdbPresentacion.Checked = True Then
                lblStatusBar.Text = "Visualizando el reporte..."
                Dim TmpForm = New frm_reportView
                TmpForm.Show(Me)
                TmpForm.CrystalViewer.ReportSource = ObjRpt
                TmpForm.CrystalViewer.Refresh()
                TmpForm.CrystalViewer.Cursor = Cursors.Default
                lblStatusBar.Text = "Listo"

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
                    ObjRpt.SummaryInfo.ReportTitle = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy")
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
                    .FileName = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
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
                    .FileName = CbxFormato.Text & " " & Today.ToString("dd-MM-yyyy-") & Now.ToString("HHmmss")
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
            LoadAnimation()
            lblStatusBar.Text = "Listo"

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
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

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim DsTemp As New DataSet
            If DgvTransferencias.SelectedRows.Count > 0 Then
                Dim IDTransferencia As New Label
                IDTransferencia.Text = DgvTransferencias.SelectedRows(0).Cells(0).Value

                DsTemp.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("Select IDTransferenciaArt,IDTipoDocumento,TransfenciaArticulos.IDSucursal,Sucursal.Sucursal,TransfenciaArticulos.IDAlmacen,Almacen.Almacen as AlmacenRealizado,IDAlmacenEntrada,AlmacenEntrada.Almacen as AlmacenEntrada,IDAlmacenSalida,AlmacenSalida.Almacen as AlmacenSalida,SecondID,Fecha,Hora,IDUsuario,Referencia,Comentario,Total,Impreso,TransfenciaArticulos.Nulo from" & SysName.Text & "transfenciaarticulos INNER JOIN" & SysName.Text & "Sucursal on TransfenciaArticulos.IDSucursal=Sucursal.IDSucursal INNER JOIN" & SysName.Text & "Almacen on TransfenciaArticulos.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Almacen as AlmacenEntrada on TransfenciaArticulos.IDAlmacenEntrada=AlmacenEntrada.IDAlmacen INNER JOIN" & SysName.Text & "Almacen as AlmacenSalida on TransfenciaArticulos.IDAlmacenSalida=AlmacenSalida.IDAlmacen Where IDTransferenciaArt='" + IDTransferencia.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "TransferenciaArt")
                ConMixta.Close()

                Dim Tabla As DataTable = DsTemp.Tables("TransferenciaArt")

                frm_transferencia_arts.Show(Me)
                frm_superclave.IDAccion.Text = 31
                frm_superclave.ShowDialog(Me)

                If ControlSuperClave = 1 Then
                    frm_transferencia_arts.Close()
                    Exit Sub
                End If

                frm_transferencia_arts.txtIDTransferenciaArt.Text = (Tabla.Rows(0).Item("IDTransferenciaArt"))
                frm_transferencia_arts.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_transferencia_arts.cbxAlmacen.Text = (Tabla.Rows(0).Item("AlmacenRealizado"))
                frm_transferencia_arts.cbxAlmacenEntrada.Text = (Tabla.Rows(0).Item("AlmacenEntrada"))
                frm_transferencia_arts.CbxAlmacenSalida.Text = (Tabla.Rows(0).Item("AlmacenSalida"))
                frm_transferencia_arts.txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
                frm_transferencia_arts.txtComentario.Text = (Tabla.Rows(0).Item("Comentario"))
                frm_transferencia_arts.txtNeto.Text = CDbl(Tabla.Rows(0).Item("Total")).ToString("C")
                frm_transferencia_arts.RefrescarTablaArticulos()


                Close()
                Exit Sub
            Else
                MessageBox.Show("No hay una fila seleccionada.")
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class