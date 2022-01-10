Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_introducir_seriales

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim ActiveSeries, LblIDFactura, lblIDFactArt As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_introducir_seriales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        CreateColumns()
        LimpiartxtBuscar()
        btnNuevo.Enabled = True
        CheckForms()

    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub CheckForms()
        If Me.Owner.Name = frm_facturacion.Name Then
            txtFactura.Text = frm_facturacion.txtSecondID.Text
            LblIDFactura.Text = frm_facturacion.txtIDFactura.Text
            txtClienteFact.Text = frm_facturacion.txtNombre.Text
            txtFecha.Text = frm_facturacion.txtFecha.Value
            txtFactura.Enabled = False
            btnBuscar.Enabled = False
            btnNuevo.Enabled = False
            BuscarDatosFactura()
            BuscarArticulos()
        ElseIf Me.Owner.Name = frm_punto_venta_lite.Name Then
            txtFactura.Text = frm_punto_venta_lite.lblSecondID.Text
            LblIDFactura.Text = frm_punto_venta_lite.lblIDFactura.Text
            txtClienteFact.Text = frm_punto_venta_lite.txtNombre.Text
            txtFecha.Text = frm_punto_venta_lite.lblFecha.Text
            txtFactura.Enabled = False
            btnBuscar.Enabled = False
            BuscarDatosFactura()
            BuscarArticulos()
        End If

    End Sub
    Private Sub CreateColumns()
        Dim ImageColumn As New DataGridViewImageColumn
        DgvArticulosSerial.Columns.Clear()

        With DgvArticulosSerial
            .Columns.Add("IDSerie", "Código Tarjeta")   '0
            .Columns.Add("FactArt", "Cód. Fact. Art.") '1
            .Columns.Add("IDArticulo", "Código") '2
            .Columns.Add("Serie", "No. Serial") '3
            .Columns.Add("Vencimiento", "Vencimiento") '4
            .Columns.Add("IDTipoUso", "ID Uso") '5
            .Columns.Add("VariacionValor", "Variar Valor") '6
            .Columns.Add("CManoObra", "Cubrir Mano Obra") '7
            .Columns.Add("CTransporteRep", "Cubrir Transportacion") '8
            .Columns.Add("CMantenimiento", "Cubrir Mantenimiento") '9
            .Columns.Add("CInstalacion", "Cubrir Instalación") '10
            .Columns.Add("CServicioRes", "Cubrir Serv. Residencial") '11
            .Columns.Add("CTaller", "Cubrir Taller") '12
            .Columns.Add("SMaterialesArt", "Sólo materiales incluidos") '13
            .Columns.Add("Descripcion", "Descripción") '14
            .Columns.Add("Referencia", "Referencia") '15
            .Columns.Add("TipoUso", "Tipo de Uso") '16
            .Columns.Add("IDGarantia", "IDGarantia") '17
            .Columns.Add("Garantia", "Garantía") '18
            .Columns.Add(ImageColumn)        '19
        End With

        ImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
        DgvArticulosSerial.Columns(14).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        PropiedadesDgvArticulosSerial()
    End Sub

    Private Sub PropiedadesDgvArticulosSerial()
        Try
            If DgvArticulosSerial.ColumnCount > 0 Then
                With DgvArticulosSerial
                    .Columns(0).Visible = False
                    .Columns(0).Width = 120
                    .Columns(0).DefaultCellStyle.BackColor = SystemColors.Control
                    .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(1).Visible = False
                    .Columns(2).Width = 100
                    .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(3).Width = 230
                    .Columns(4).Width = 110
                    .Columns(5).Visible = False
                    .Columns(6).Width = 100
                    .Columns(7).Width = 150
                    .Columns(8).Width = 150
                    .Columns(9).Width = 150
                    .Columns(10).Width = 150
                    .Columns(11).Width = 170
                    .Columns(12).Width = 150
                    .Columns(13).Width = 180
                    .Columns(14).Width = 245
                    .Columns(15).Width = 120
                    .Columns(16).Width = 200
                    .Columns(14).DisplayIndex = 3
                    .Columns(15).DisplayIndex = 4
                    .Columns(16).DisplayIndex = 8
                    .Columns(17).Visible = False
                    .Columns(18).Width = 200
                    .Columns(18).DisplayIndex = 9
                    .Columns(19).Width = 100
                    .Columns(19).Visible = True
                    .Columns(19).DisplayIndex = 0
                End With
            End If

        Catch ex As Exception

        End Try

    End Sub

    Sub LimpiartxtBuscar()
        LblIDFactura.Text = ""
        DgvArticulosSerial.Rows.Clear()
        txtFactura.Clear()
        txtIDArticulo.Clear()
        txtClienteFact.Clear()
        txtFecha.Clear()
        txtDescripcion.Clear()
        txtNoSerial.Clear()
        txtVencimiento.Clear()
        CheckBox1.Checked = False
        DgvArticulosSerial.Enabled = True
        txtFactura.Enabled = True
        btnBuscar.Enabled = True
        Label10.Visible = False
        PictureBox1.Image = My.Resources.No_Image
        GroupBox2.Visible = False
        GroupBox1.Size = New Size(935, 411)
        txtFactura.Focus()
    End Sub

    Private Sub CleanToFind()
        DgvArticulosSerial.Rows.Clear()
        txtClienteFact.Clear()
        txtFecha.Clear()
        txtDescripcion.Clear()
        txtNoSerial.Clear()
    End Sub

    Private Sub BuscarDatosFactura()
        Try
            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT Nombre,Fecha FROM" & SysName.Text & "FacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where FacturaDatos.SecondID='" + txtFactura.Text + "'  and FacturaDatos.Nulo=0", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "FacturaDatos")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("FacturaDatos")

            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron resultados.", "No se encontró", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtFactura.Focus()
                ControlSuperClave = 1
            Else
                ControlSuperClave = 0
                txtClienteFact.Text = (Tabla.Rows(0).Item("Nombre"))
                txtFecha.Text = (Tabla.Rows(0).Item("Fecha"))
                txtCantidadDias.Text = " (" & DateDiff(DateInterval.Day, CDate(Tabla.Rows(0).Item("Fecha")), Today) & ") días"
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub BuscarArticulos()
        Try
            Dim SelectedImage As Image
            Ds.Clear()

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT FacturaArticulos.IDFactArt,Cantidad,FacturaArticulos.IDArticulo,FacturaArticulos.Descripcion,Articulos.Referencia,IDGarantia,TiempoGarantia,Dias,Articulos.RutaFoto FROM" & SysName.Text & "facturaarticulos INNER JOIN Libregco.Articulos on FacturaArticulos.IDArticulo=Articulos.IDArticulo INNER JOIN" & SysName.Text & "FacturaDatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.GarantiaArticulos on Articulos.IDGarantia=GarantiaArticulos.IDGarantiaArticulos Where FacturaDatos.IDFacturaDatos='" + LblIDFactura.Text + "' and Articulos.Serial=1", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "FacturaArticulos")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("FacturaArticulos")

            For Each row As DataRow In Tabla.Rows

                If TypeConnection.Text = 1 Then
                    If System.IO.File.Exists(row.Item("RutaFoto")) = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(row.Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                        SelectedImage = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()

                    Else
                        SelectedImage = My.Resources.No_Image
                    End If

                Else
                    SelectedImage = My.Resources.No_Image
                End If


                For i As Integer = 1 To CDbl(row.Item("Cantidad"))
                    DgvArticulosSerial.Rows.Add("", row.Item("IDFactArt"), row.Item("IDArticulo"), "", "", "", "No", "No", "No", "No", "No", "No", "No", "No", row.Item("Descripcion"), row.Item("Referencia"), "", row.Item("IDGarantia"), row.Item("TiempoGarantia"), SelectedImage)
                Next
            Next

            'SelectedImage.Dispose()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


    Private Sub DgvArticulosSerial_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvArticulosSerial.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvArticulosSerial.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvArticulosSerial.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvArticulosSerial.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
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

    Private Sub DgvArticulosSerial_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvArticulosSerial.CellMouseDoubleClick
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim ObjRpt As New ReportDocument

        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 0 Then
                Dim IDTarjeta As New Label
                IDTarjeta.Text = DgvArticulosSerial.CurrentRow.Cells(0).Value

                If IDTarjeta.Text = "" Then
                    MessageBox.Show("Complete los datos de la serie y posteriormente guárdela para la impresión de la garantía.", "Aún no se ha generado la garantía", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Dim NoSerial As String = DgvArticulosSerial.CurrentRow.Cells(3).Value
                    If NoSerial = "" Then
                        LlenarFormulario()
                    End If
                Else

                    Con.Open()
                    cmd = New MySqlCommand("Select Path from Reportes where IDReportes=100", Con)
                    Dim Path As String = Convert.ToString(cmd.ExecuteScalar())
                    Con.Close()

                    If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & Path) Else ObjRpt.Load("C:" & Path.Replace("\Libregco\Libregco.net", ""))

                    crParameterValues.Clear()

                    crParameterDiscreteValue.Value = IDTarjeta.Text
                    crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDSerial")
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    LoadAnimation()

                    lblStatusBar.Text = "Visualizando el reporte..."
                    Dim TmpForm = New frm_reportView
                    TmpForm.Show(Me)
                    TmpForm.CrystalViewer.ReportSource = ObjRpt
                    TmpForm.CrystalViewer.Refresh()
                    TmpForm.CrystalViewer.Cursor = Cursors.Default
                    lblStatusBar.Text = "Listo"

                    LoadAnimation()

                End If

            ElseIf e.ColumnIndex > 1 Then
                LlenarFormulario()
            End If
        End If
    End Sub

    Private Sub LlenarFormulario()
        Dim IDSerial As New Label
        Dim SelectedImage As Image
        IDSerial.Text = DgvArticulosSerial.CurrentRow.Cells(0).Value

        GroupBox2.Visible = True
        GroupBox1.Size = New Size(935, 195)

        Dim IDArticulo As New Label
        IDArticulo.Text = DgvArticulosSerial.CurrentRow.Cells(2).Value

        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,Referencia,IDGarantia,TiempoGarantia,Dias,RutaFoto FROM Libregco.articulos INNER JOIN Libregco.GarantiaArticulos on Articulos.IDGarantia=GarantiaArticulos.IDGarantiaArticulos Where IDArticulo='" + IDArticulo.Text + "'", ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Articulos")
        ConMixta.Close()

        Dim Tabla As DataTable = Ds.Tables("Articulos")

        If IDSerial.Text = "" Then

            txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
            txtDescripcion.Text = (Tabla.Rows(0).Item("Descripcion"))
            txtReferencia.Text = (Tabla.Rows(0).Item("Referencia"))
            txtIDGarantia.Text = (Tabla.Rows(0).Item("IDGarantia"))
            txtGarantia.Text = (Tabla.Rows(0).Item("TiempoGarantia"))
            txtVencimiento.Text = DateAdd(DateInterval.Day, CDbl(Tabla.Rows(0).Item("Dias")), CDate(txtFecha.Text)).ToString("yyyy-MM-dd")

            If TypeConnection.Text = 1 Then
                If System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto")) = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream((Tabla.Rows(0).Item("RutaFoto")), FileMode.Open, FileAccess.Read)
                    PictureBox1.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                Else
                    PictureBox1.Image = My.Resources.No_Image
                End If
            Else
                PictureBox1.Image = My.Resources.No_Image
            End If



        Else
            txtIDTarjeta.Text = DgvArticulosSerial.CurrentRow.Cells(0).Value
            txtIDArticulo.Text = DgvArticulosSerial.CurrentRow.Cells(2).Value
            txtVencimiento.Text = CDate(DgvArticulosSerial.CurrentRow.Cells(4).Value).ToString("yyyy-MM-dd")
            txtDescripcion.Text = DgvArticulosSerial.CurrentRow.Cells(14).Value
            txtReferencia.Text = DgvArticulosSerial.CurrentRow.Cells(15).Value


            If TypeConnection.Text = 1 Then
                If System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto")) = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream((Tabla.Rows(0).Item("RutaFoto")), FileMode.Open, FileAccess.Read)
                    PictureBox1.Image = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                Else
                    PictureBox1.Image = My.Resources.No_Image
                End If
            Else
                PictureBox1.Image = My.Resources.No_Image
            End If
        End If

        Label10.Visible = True
        lblIDFactArt.Text = DgvArticulosSerial.CurrentRow.Cells(1).Value
        txtNoSerial.Text = DgvArticulosSerial.CurrentRow.Cells(3).Value
        txtIDTipoUso.Text = DgvArticulosSerial.CurrentRow.Cells(5).Value
        txtTipoUso.Text = DgvArticulosSerial.CurrentRow.Cells(16).Value
        txtIDGarantia.Text = DgvArticulosSerial.CurrentRow.Cells(17).Value
        txtGarantia.Text = DgvArticulosSerial.CurrentRow.Cells(18).Value

        If DgvArticulosSerial.CurrentRow.Cells(6).Value = "No" Then
            chkTrasladoRes.Checked = False
        Else
            chkTrasladoRes.Checked = True
        End If
        If DgvArticulosSerial.CurrentRow.Cells(7).Value = "No" Then
            chkManoObra.Checked = False
        Else
            chkManoObra.Checked = True
        End If
        If DgvArticulosSerial.CurrentRow.Cells(8).Value = "No" Then
            chkTransporteRep.Checked = False
        Else
            chkTransporteRep.Checked = True
        End If
        If DgvArticulosSerial.CurrentRow.Cells(9).Value = "No" Then
            ChkMantenimiento.Checked = False
        Else
            ChkMantenimiento.Checked = True
        End If
        If DgvArticulosSerial.CurrentRow.Cells(10).Value = "No" Then
            chkServInstalacion.Checked = False
        Else
            chkServInstalacion.Checked = True
        End If
        If DgvArticulosSerial.CurrentRow.Cells(11).Value = "No" Then
            chkServResidencial.Checked = False
        Else
            chkServResidencial.Checked = True
        End If
        If DgvArticulosSerial.CurrentRow.Cells(12).Value = "No" Then
            ChkServTaller.Checked = False
        Else
            ChkServTaller.Checked = True
        End If
        If DgvArticulosSerial.CurrentRow.Cells(13).Value = "No" Then
            chkSoloMaterialesIndicado.Checked = False
        Else
            chkSoloMaterialesIndicado.Checked = True
        End If

        DgvArticulosSerial.Rows.Remove(DgvArticulosSerial.CurrentRow)
        DgvArticulosSerial.ClearSelection()
        DgvArticulosSerial.Enabled = False
        txtNoSerial.Focus()
    End Sub

    Private Sub btnAplicarMonto_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
        If txtIDArticulo.Text <> "" Then
            Dim ManoObra, Transporte, Mantenimiento, Instalacion, SerResidencia, SerTaller, TrasladoRes, SoloMateriales As String

            If txtIDTipoUso.Text = "" Then
                MessageBox.Show("Seleccione el tipo de uso de artículo " & txtDescripcion.Text & ".", "Tipo de uso bajo garantía", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                btnTipoUso.PerformClick()
                Exit Sub
            End If

            If txtNoSerial.Text = "" Then
                Dim Result As MsgBoxResult = MessageBox.Show("No ha ingresado un número de serie para generar la garantía del artículo " & txtDescripcion.Text & vbNewLine & vbNewLine & "Está seguro que no desea registrar garantía para el producto?", "No se ha ingresado No. Serial", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.No Then
                    txtNoSerial.Focus()
                    Exit Sub
                End If
            End If


            If chkManoObra.Checked = True Then
                ManoObra = "Sí"
            Else
                ManoObra = "No"
            End If
            If chkTransporteRep.Checked = True Then
                Transporte = "Sí"
            Else
                Transporte = "No"
            End If
            If ChkMantenimiento.Checked = True Then
                Mantenimiento = "Sí"
            Else
                Mantenimiento = "No"
            End If
            If chkServResidencial.Checked = True Then
                SerResidencia = "Sí"
            Else
                SerResidencia = "No"
            End If
            If ChkServTaller.Checked = True Then
                SerTaller = "Sí"
            Else
                SerTaller = "No"
            End If
            If chkServInstalacion.Checked = True Then
                Instalacion = "Sí"
            Else
                Instalacion = "No"
            End If
            If chkTrasladoRes.Checked = True Then
                TrasladoRes = "Sí"
            Else
                TrasladoRes = "No"
            End If
            If chkSoloMaterialesIndicado.Checked = True Then
                SoloMateriales = "Sí"
            Else
                SoloMateriales = "No"
            End If

            DgvArticulosSerial.Rows.Add(txtIDTarjeta.Text, lblIDFactArt.Text, txtIDArticulo.Text, txtNoSerial.Text, CDate(txtVencimiento.Text).ToString("yyyy-MM-dd"), txtIDTipoUso.Text, TrasladoRes, ManoObra, Transporte, Mantenimiento, Instalacion, SerResidencia, SerTaller, SoloMateriales, txtDescripcion.Text, txtReferencia.Text, txtTipoUso.Text, txtIDGarantia.Text, txtGarantia.Text, PictureBox1.Image)
            LimpiarSerial()
        End If

    End Sub

    Private Sub LimpiarSerial()
        txtIDArticulo.Clear()
        txtDescripcion.Clear()
        txtNoSerial.Clear()
        txtIDTarjeta.Clear()
        txtReferencia.Clear()
        txtIDGarantia.Clear()
        txtGarantia.Clear()
        txtVencimiento.Clear()
        txtIDTipoUso.Clear()
        txtTipoUso.Clear()
        CheckBox1.Checked = False
        chkManoObra.Checked = False
        chkTransporteRep.Checked = False
        ChkMantenimiento.Checked = False
        chkServResidencial.Checked = False
        ChkServTaller.Checked = False
        chkServInstalacion.Checked = False
        chkTrasladoRes.Checked = False
        chkSoloMaterialesIndicado.Checked = False
        Label10.Visible = False
        DgvArticulosSerial.Enabled = True
        PictureBox1.Image = My.Resources.No_Image
        GroupBox2.Visible = False
        GroupBox1.Size = New Size(935, 411)
    End Sub

    Private Sub InsertarSeries()
        Dim IDSerial, IDFactArt, IDArticulo, Serie, Vencimiento, IDTipoUso, IDGarantia, VariacionValor, CManoObra, CTransporteRep, CMantenimiento, CInstalacion, CServiciosRes, CTaller, SMaterialesArt As New Label
        Dim x As Integer = 0

Inicio:
        If x = DgvArticulosSerial.RowCount Then
            GoTo Fin
        End If

        IDSerial.Text = DgvArticulosSerial.Rows(x).Cells(0).Value
        IDFactArt.Text = DgvArticulosSerial.Rows(x).Cells(1).Value
        IDArticulo.Text = DgvArticulosSerial.Rows(x).Cells(2).Value
        Serie.Text = DgvArticulosSerial.Rows(x).Cells(3).Value
        If IsDate(DgvArticulosSerial.Rows(x).Cells(4).Value) Then
            Vencimiento.Text = CDate(DgvArticulosSerial.Rows(x).Cells(4).Value).ToString("yyyy-MM-dd")
        End If
        IDTipoUso.Text = DgvArticulosSerial.Rows(x).Cells(5).Value
        IDGarantia.Text = DgvArticulosSerial.Rows(x).Cells(17).Value

        If (DgvArticulosSerial.Rows(x).Cells(6).Value) = "Sí" Then
            VariacionValor.Text = 1
        Else
            VariacionValor.Text = 0
        End If

        If (DgvArticulosSerial.Rows(x).Cells(7).Value) = "Sí" Then
            CManoObra.Text = 1
        Else
            CManoObra.Text = 0
        End If

        If (DgvArticulosSerial.Rows(x).Cells(8).Value) = "Sí" Then
            CTransporteRep.Text = 1
        Else
            CTransporteRep.Text = 0
        End If

        If (DgvArticulosSerial.Rows(x).Cells(9).Value) = "Sí" Then
            CMantenimiento.Text = 1
        Else
            CMantenimiento.Text = 0
        End If

        If (DgvArticulosSerial.Rows(x).Cells(10).Value) = "Sí" Then
            CInstalacion.Text = 1
        Else
            CInstalacion.Text = 0
        End If

        If (DgvArticulosSerial.Rows(x).Cells(11).Value) = "Sí" Then
            CServiciosRes.Text = 1
        Else
            CServiciosRes.Text = 0
        End If

        If (DgvArticulosSerial.Rows(x).Cells(12).Value) = "Sí" Then
            CTaller.Text = 1
        Else
            CTaller.Text = 0
        End If

        If (DgvArticulosSerial.Rows(x).Cells(13).Value) = "Sí" Then
            SMaterialesArt.Text = 1
        Else
            SMaterialesArt.Text = 0
        End If

        If IDSerial.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Serie.Text <> "" Then
                sqlQ = "INSERT INTO SerialArticulo (IDFactArt,IDArticulo,NoSerie,Vencimiento,IDTipoUso,IDGarantia,VariacionValor,CManoObra,CTransporteRep,CMantenimiento,CInstalacion,CServicioRes,CTaller,SMaterialesArt) VALUES ('" + IDFactArt.Text + "', '" + IDArticulo.Text + "','" + Serie.Text + "','" + Vencimiento.Text + "','" + IDTipoUso.Text + "','" + IDGarantia.Text + "','" + VariacionValor.Text + "','" + CManoObra.Text + "','" + CTransporteRep.Text + "','" + CMantenimiento.Text + "','" + CInstalacion.Text + "','" + CServiciosRes.Text + "','" + CTaller.Text + "','" + SMaterialesArt.Text + "')"
                GuardarDatos()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            sqlQ = "UPDATE SerialArticulo SET IDArticulo='" + IDArticulo.Text + "',NoSerie='" + Serie.Text + "',Vencimiento='" + Vencimiento.Text + "',IDFactArt='" + IDFactArt.Text + "',IDTipoUso='" + IDTipoUso.Text + "',IDGarantia='" + IDGarantia.Text + "',VariacionValor='" + VariacionValor.Text + "',CManoObra='" + CManoObra.Text + "',CTransporteRep='" + CTransporteRep.Text + "',CMantenimiento='" + CMantenimiento.Text + "',CInstalacion='" + CInstalacion.Text + "',CServicioRes='" + CServiciosRes.Text + "',CTaller='" + CTaller.Text + "',SMaterialesArt='" + SMaterialesArt.Text + "' WHERE IDSerial='" + IDSerial.Text + "'"
            GuardarDatos()
        End If

        x = x + 1
        GoTo Inicio
Fin:
        RefrescarSeriales()

        If DgvArticulosSerial.Rows.Count > 0 Then
            MessageBox.Show("Series introducidas satisfactoriamente", "Series guardadas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Con.Open()
            cmd = New MySqlCommand("SELECT count(IDSerial) FROM serialarticulo INNER JOIN FacturaArticulos on SerialArticulo.IDFactArt=FacturaArticulos.IDFactArt INNER JOIN FacturaDatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos where IDFactura='" + LblIDFactura.Text + "'", Con)
            Dim InsertedRow As Integer = (Convert.ToDouble(cmd.ExecuteScalar()))
            Con.Close()

            If InsertedRow = DgvArticulosSerial.Rows.Count Then
                Close()
            End If


        End If



    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub ActiveSeriesCount()
        Try
            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDSerial,SerialArticulo.IDFactArt,SerialArticulo.IDArticulo,NoSerie,Vencimiento,SerialArticulo.IDTipoUso,TipoUsoGarantia.TipoUsoGarantia,VariacionValor,CManoObra,CTransporteRep,CMantenimiento,CInstalacion,CServicioRes,CTaller,SMaterialesArt,SerialArticulo.IDGarantia,GarantiaArticulos.TiempoGarantia FROM" & SysName.Text & "serialarticulo INNER JOIN Libregco.Articulos on SerialArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN" & SysName.Text & "FacturaArticulos on SerialArticulo.IDFactArt=FacturaArticulos.IDFactArt INNER JOIN Libregco.TipoUsoGarantia on SerialArticulo.IDTipoUso=TipoUsoGarantia.IDTipoUsoGarantia INNER JOIN Libregco.GarantiaArticulos on SerialArticulo.IDGarantia=GarantiaArticulos.IDGarantiaArticulos Where IDFactura='" + LblIDFactura.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "SerialArticulo")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("SerialArticulo")

            For Each DgvRow As DataGridViewRow In DgvArticulosSerial.Rows
                For Each Dtrow As DataRow In Tabla.Rows
                    If DgvRow.Cells(2).Value = Dtrow.Item("IDArticulo") Then
                        DgvRow.Cells(0).Value = Dtrow.Item("IDSerial")
                        DgvRow.Cells(3).Value = Dtrow.Item("NoSerie")
                        DgvRow.Cells(4).Value = CDate(Dtrow.Item("Vencimiento")).ToString("dd/MM/yyyy")
                        DgvRow.Cells(5).Value = Dtrow.Item("IDTipoUso")

                        If Dtrow.Item("VariacionValor") = 1 Then
                            DgvRow.Cells(6).Value = "Sí"
                        Else
                            DgvRow.Cells(6).Value = "No"
                        End If

                        If Dtrow.Item("CManoObra") = 1 Then
                            DgvRow.Cells(7).Value = "Sí"
                        Else
                            DgvRow.Cells(7).Value = "No"
                        End If

                        If Dtrow.Item("CTransporteRep") = 1 Then
                            DgvRow.Cells(8).Value = "Sí"
                        Else
                            DgvRow.Cells(8).Value = "No"
                        End If

                        If Dtrow.Item("CMantenimiento") = 1 Then
                            DgvRow.Cells(9).Value = "Sí"
                        Else
                            DgvRow.Cells(9).Value = "No"
                        End If

                        If Dtrow.Item("CInstalacion") = 1 Then
                            DgvRow.Cells(10).Value = "Sí"
                        Else
                            DgvRow.Cells(10).Value = "No"
                        End If

                        If Dtrow.Item("CServicioRes") = 1 Then
                            DgvRow.Cells(11).Value = "Sí"
                        Else
                            DgvRow.Cells(11).Value = "No"
                        End If

                        If Dtrow.Item("CTaller") = 1 Then
                            DgvRow.Cells(12).Value = "Sí"
                        Else
                            DgvRow.Cells(12).Value = "No"
                        End If

                        If Dtrow.Item("SMaterialesArt") = 1 Then
                            DgvRow.Cells(13).Value = "Sí"
                        Else
                            DgvRow.Cells(13).Value = "No"
                        End If

                        DgvRow.Cells(16).Value = Dtrow.Item("TipoUsoGarantia")
                        DgvRow.Cells(17).Value = Dtrow.Item("IDGarantia")
                        DgvRow.Cells(18).Value = Dtrow.Item("TiempoGarantia")

                        Tabla.Rows.Remove(Dtrow)
                        Exit For
                    End If
                Next
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub RefrescarSeriales()
        Try
            Dim SelectedImage As Image

            DgvArticulosSerial.Rows.Clear()
            ConMixta.Open()
            Dim Consulta As New MySqlCommand("SELECT IDSerial,SerialArticulo.IDFactArt,SerialArticulo.IDArticulo,NoSerie,Vencimiento,SerialArticulo.IDTipoUso,VariacionValor,CManoObra,CTransporteRep,CMantenimiento,CInstalacion,CServicioRes,CTaller,SMaterialesArt,Articulos.Descripcion,Articulos.Referencia,TipoUsoGarantia,SerialArticulo.IDGarantia,TiempoGarantia,RutaFoto FROM" & SysName.Text & "serialarticulo INNER JOIN Libregco.Articulos on SerialArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN" & SysName.Text & "FacturaArticulos on SerialArticulo.IDFactArt=FacturaArticulos.IDFactArt INNER JOIN Libregco.TipoUsoGarantia on SerialArticulo.IDTipoUso=TipoUsoGarantia.IDTipoUsoGarantia INNER JOIN Libregco.GarantiaArticulos on SerialArticulo.IDGarantia=GarantiaArticulos.IDGarantiaArticulos Where IDFactura='" + LblIDFactura.Text + "'", ConMixta)
            Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

            While LectorArticulos.Read
                If TypeConnection.Text = 1 Then
                    If System.IO.File.Exists(LectorArticulos.GetValue(19)) = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(LectorArticulos.GetValue(19), FileMode.Open, FileAccess.Read)
                        SelectedImage = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()

                    Else
                        SelectedImage = My.Resources.No_Image
                    End If

                Else
                    SelectedImage = My.Resources.No_Image
                End If

                DgvArticulosSerial.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), CDate(LectorArticulos.GetValue(4)).ToString("yyyy-MM-dd"), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), LectorArticulos.GetValue(10), LectorArticulos.GetValue(11), LectorArticulos.GetValue(12), LectorArticulos.GetValue(13), LectorArticulos.GetValue(14), LectorArticulos.GetValue(15), LectorArticulos.GetValue(16), LectorArticulos.GetValue(17), LectorArticulos.GetValue(18), SelectedImage)
            End While
            LectorArticulos.Close()
            ConMixta.Close()

            PropiedadesDgvArticulosSerial()
            ChangeBoleanValues()
            'SelectedImage.Dispose()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ChangeBoleanValues()
        For xt = 6 To 13
            For Each row As DataGridViewRow In DgvArticulosSerial.Rows
                If row.Cells(xt).Value = 1 Then
                    row.Cells(xt).Value = "Sí"
                Else
                    row.Cells(xt).Value = "No"
                End If
            Next
        Next

    End Sub

    Private Sub frm_introducir_seriales_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadesDgvArticulosSerial()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub btnTipoUso_Click(sender As Object, e As EventArgs) Handles btnTipoUso.Click
        frm_buscar_tipo_uso_garantia.ShowDialog(Me)
    End Sub

    Private Sub btnGarantia_Click(sender As Object, e As EventArgs) Handles btnGarantia.Click
        frm_buscar_tipo_garantia.ShowDialog(Me)
    End Sub

    Private Sub txtIDTipoUso_Leave(sender As Object, e As EventArgs) Handles txtIDTipoUso.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select TipoUsoGarantia from TipoUsoGarantia Where IDTipoUsoGarantia='" + txtIDTipoUso.Text + "'", ConLibregco)
        txtTipoUso.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtTipoUso.Text = "" Then txtIDTipoUso.Clear()
    End Sub

    Private Sub txtIDGarantia_Leave(sender As Object, e As EventArgs) Handles txtIDGarantia.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select TiempoGarantia from GarantiaArticulos Where IDGarantiaArticulos='" + txtIDGarantia.Text + "'", ConLibregco)
        txtGarantia.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        If txtGarantia.Text = "" Then
            txtIDGarantia.Clear()
        Else
            If txtFecha.Text <> "" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("Select Dias from GarantiaArticulos Where IDGarantiaArticulos='" + txtIDGarantia.Text + "'", ConLibregco)
                Dim Dias As Integer = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()

                txtVencimiento.Text = CDate(DateAdd(DateInterval.Day, Dias, CDate(txtFecha.Text))).ToString("yyyy-MM-dd")
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            chkManoObra.Checked = True
            chkTransporteRep.Checked = True
            ChkMantenimiento.Checked = True
            chkServResidencial.Checked = True
            ChkServTaller.Checked = True
            chkServInstalacion.Checked = True
            chkTrasladoRes.Checked = True
            chkSoloMaterialesIndicado.Checked = True
        Else
            chkManoObra.Checked = False
            chkTransporteRep.Checked = False
            ChkMantenimiento.Checked = False
            chkServResidencial.Checked = False
            ChkServTaller.Checked = False
            chkServInstalacion.Checked = False
            chkTrasladoRes.Checked = False
            chkSoloMaterialesIndicado.Checked = False
        End If
    End Sub

    Private Sub DgvArticulosSerial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvArticulosSerial.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormulario()
        End If
    End Sub

    Private Sub DgvArticulosSerial_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvArticulosSerial.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvArticulosSerial.ColumnCount
                Dim NumRows As Integer = DgvArticulosSerial.RowCount
                Dim CurCell As DataGridViewCell = DgvArticulosSerial.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvArticulosSerial.CurrentCell = DgvArticulosSerial.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvArticulosSerial.CurrentCell = DgvArticulosSerial.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiartxtBuscar()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtFactura.Text = "" Then
            If frm_consulta_ventas.Visible = True Then
                frm_consulta_ventas.Close()
            Else
                frm_consulta_ventas.ShowDialog(Me)
            End If
        End If

        Con.Open()
        cmd = New MySqlCommand("Select IDFacturaDatos from FacturaDatos Where SecondID= '" + txtFactura.Text + "'", Con)
        LblIDFactura.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        CleanToFind()
        BuscarDatosFactura()

        If ControlSuperClave = 1 Then
            Exit Sub
        End If

        BuscarArticulos()
        ActiveSeriesCount()
        DgvArticulosSerial.ClearSelection()
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If DgvArticulosSerial.Rows.Count > 0 Then
            If DgvArticulosSerial.SelectedRows.Count > 0 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar la serie correspondiente al ID " & DgvArticulosSerial.CurrentRow.Cells(0).Value & " de la base de datos?" & vbNewLine & vbNewLine & "Eliminar este registro podría ocasionar que no se encuentren los registros precisos de las condiciones de venta y la garantía específica dle artículo.", "Eliminar registro de garantía", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    If CStr(DgvArticulosSerial.CurrentRow.Cells(0).Value) <> "" Then
                        sqlQ = "Delete from SerialArticulo Where IDSerial = (" + DgvArticulosSerial.CurrentRow.Cells(0).Value.ToString + ")"
                        GuardarDatos()
                    End If
                    DgvArticulosSerial.Rows.Remove(DgvArticulosSerial.CurrentRow)
                    MessageBox.Show("El registro de serie y/o tarjeta de garantía ha sido eliminado satisfactoriamente de la venta.", "Eliminado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                End If
        End If
    End Sub

    Private Sub DgvArticulosSerial_MouseEnter(sender As Object, e As EventArgs) Handles DgvArticulosSerial.MouseEnter
        DgvArticulosSerial.ScrollBars = ScrollBars.Both
    End Sub

    Private Sub DgvArticulosSerial_MouseLeave(sender As Object, e As EventArgs) Handles DgvArticulosSerial.MouseLeave
        DgvArticulosSerial.ScrollBars = ScrollBars.Vertical
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim ObjRpt As New ReportDocument

        If DgvArticulosSerial.Rows.Count > 0 Then

            Con.Open()
            cmd = New MySqlCommand("Select Path from Reportes where IDReportes=248", Con)
            Dim Path As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & Path) Else ObjRpt.Load("C:" & Path.Replace("\Libregco\Libregco.net", ""))

            crParameterValues.Clear()

            crParameterDiscreteValue.Value = LblIDFactura.Text
            crParameterFiledDefinitions = ObjRpt.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFiledDefinitions.Item("@IDFactura")
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            ObjRpt.SetParameterValue("@Usuario", "Usuario: " & DtEmpleado.Rows(0).item("Login").ToString() & " [" & DtEmpleado.Rows(0).item("IDEmpleado").ToString() & "]")

            LoadAnimation()

            lblStatusBar.Text = "Visualizando el reporte..."

            Dim TmpForm = New frm_reportView
            TmpForm.Show(Me)

            TmpForm.CrystalViewer.ReportSource = ObjRpt
            TmpForm.CrystalViewer.Refresh()
            TmpForm.CrystalViewer.Cursor = Cursors.Default
            lblStatusBar.Text = "Listo"

            LoadAnimation()

        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub frm_introducir_seriales_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Con.Open()
        cmd = New MySqlCommand("SELECT Value2Int FROM libregco.configuracion where IDConfiguracion=139", Con)
        Dim Obligation As Integer = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If DgvArticulosSerial.Rows.Count > 0 Or txtIDArticulo.Text <> "" Then
            If txtIDArticulo.Text <> "" Then
                If Obligation = 1 Then
                    e.Cancel = True
                    lblStatusBar.Text = "La introducción de series es obligatoria. Inserte este registro para cerrar el formulario."
                End If
            End If

            If DgvArticulosSerial.Rows.Count > 0 Then
                If CStr(Convert.ToString(DgvArticulosSerial.Rows(0).Cells(0).Value)).ToString = "" Then
                    If Obligation = 1 Then
                        e.Cancel = True
                        lblStatusBar.Text = "La introducción de series es obligatoria."
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        InsertarSeries()
    End Sub


    Private Sub DgvArticulosSerial_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvArticulosSerial.CellMouseMove
        If e.ColumnIndex = 0 Then
            If DgvArticulosSerial.Rows.Count > 0 Then
                Cursor.Current = Cursors.Hand
            End If
        End If
    End Sub

End Class