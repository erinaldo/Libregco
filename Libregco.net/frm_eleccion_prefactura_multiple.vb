Imports System.IO
Imports DevExpress.XtraGrid.Views.BandedGrid

Public Class frm_eleccion_prefactura_multiple
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim sqlQ As String
    Friend TablaPrefacturasElegidas As DataTable
    Dim RepositoryImagenCliente As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit() With {.PictureAlignment = ContentAlignment.MiddleCenter, .SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom}
    Dim RepositorySecondID As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}
    Private ConMixPrefactura As New MySqlConnection(CnGeneral) 'Conexion mixta

    Private Sub frm_eleccion_prefactura_multiple_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarLibregco()
        SetTablaPrefacturas()
        RefrescarTabla()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub SetTablaPrefacturas()
        RepositoryImagenCliente.OptionsMask.MaskType = DevExpress.XtraEditors.Controls.PictureEditMaskType.Circle

        TablaPrefacturasElegidas = New DataTable("Prefacturas")

        TablaPrefacturasElegidas.Columns.Add("IDPrefactura", System.Type.GetType("System.String"))
        TablaPrefacturasElegidas.Columns.Add("SecondID", System.Type.GetType("System.String"))
        TablaPrefacturasElegidas.Columns.Add("Fecha", System.Type.GetType("System.String"))

        TablaPrefacturasElegidas.Columns.Add("ImagenCliente", System.Type.GetType("System.Object"))
        TablaPrefacturasElegidas.Columns.Add("IDCliente", System.Type.GetType("System.String"))
        TablaPrefacturasElegidas.Columns.Add("NombreFactura", System.Type.GetType("System.String"))
        TablaPrefacturasElegidas.Columns.Add("Identificacion", System.Type.GetType("System.String"))
        TablaPrefacturasElegidas.Columns.Add("Direccion", System.Type.GetType("System.String"))
        TablaPrefacturasElegidas.Columns.Add("Telefonos", System.Type.GetType("System.String"))

        GridPrefacturas.DataSource = TablaPrefacturasElegidas

        GridView2.Columns("SecondID").ColumnEdit = RepositorySecondID
        GridView2.Columns("ImagenCliente").ColumnEdit = RepositoryImagenCliente

        GridView2.Columns("IDPrefactura").Visible = False
        GridView2.Columns("SecondID").Caption = "Prefactura"
        GridView2.Columns("SecondID").Visible = False
        GridView2.Columns("Fecha").Visible = False

        GridView2.Columns("IDCliente").Caption = "Cliente"
        GridView2.Columns("ImagenCliente").Caption = "Cliente"
        GridView2.Columns("ImagenCliente").OptionsColumn.FixedWidth = 20
        GridView2.Columns("IDCliente").Caption = "ID"
        GridView2.Columns("NombreFactura").Caption = " "

        GridView2.Columns("Identificacion").Caption = "RNC"
        GridView2.Columns("Direccion").Caption = "Dirección"
        GridView2.Columns("Telefonos").Caption = "Tels."

        For i = 0 To GridView2.Columns.Count - 1
            GridView2.Columns(i).OptionsColumn.ReadOnly = True
            GridView2.Columns(i).OptionsColumn.AllowEdit = False
        Next
    End Sub

    Private Sub RefrescarTabla()
        Dim dstemp As New DataSet
        Dim imgCliente As Image

        Dim RNCLenght, DirLenght, TelLenght As Integer
        If ConMixPrefactura.State = ConnectionState.Open Then
            ConMixPrefactura.Close()
        End If

        ConMixPrefactura.Open()

        RNCLenght = 0
        DirLenght = 0
        TelLenght = 0

        For Each rw As DataRow In frm_cierre_facturas.TablaPrefacturas.Rows


            If rw.Item("Incluir") = 1 Then
                dstemp.Clear()
                cmd = New MySqlCommand("Select IDPrefactura,Prefactura.SecondID,TIMESTAMP(Fecha,Hora) As FechaHora,Prefactura.IDCliente,IFNULL((SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente And IDClase=1 LIMIT 1),'') as Foto,Prefactura.NombreFactura,Prefactura.IdentificacionFactura,Prefactura.DireccionFactura,Prefactura.TelefonosFactura,Prefactura.IDComprobanteFiscal,ComprobanteFiscal.TipoComprobante,Prefactura.IDVendedor,Vendedor.RutaFoto,Vendedor.Nombre as NombreVendedor,Prefactura.IDCondicion,Condicion.Condicion FROM" & SysName.Text & "prefactura INNER JOIN Libregco.Clientes on Prefactura.IDCliente=Clientes.IDCliente INNER JOIN" & SysName.Text & "Empleados as Vendedor on Prefactura.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "ComprobanteFiscal on Prefactura.IDComprobanteFiscal=ComprobanteFiscal.IDComprobanteFiscal INNER JOIN Libregco.Condicion on Prefactura.IDCondicion=Condicion.IDCondicion Where Prefactura.IDPrefactura='" + rw.Item("ID").ToString + "'", ConMixPrefactura)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(dstemp, "PreFactura")

                Dim Tabla As DataTable = dstemp.Tables("PreFactura")

                RNCLenght += Tabla.Rows(0).Item("IdentificacionFactura").Length
                DirLenght += Tabla.Rows(0).Item("DireccionFactura").Length
                TelLenght += Tabla.Rows(0).Item("TelefonosFactura").Length

                If Tabla.Rows(0).Item("Foto") <> "" Then
                    If System.IO.File.Exists(Tabla.Rows(0).Item("Foto")) = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(Tabla.Rows(0).Item("Foto"), FileMode.Open, FileAccess.Read)
                        imgCliente = ResizeImage(System.Drawing.Image.FromStream(wFile), 50)
                        wFile.Close()
                    Else
                        imgCliente = ResizeImage(My.Resources.No_Image, 50)
                    End If
                Else
                    imgCliente = ResizeImage(My.Resources.No_Image, 50)
                End If

                TablaPrefacturasElegidas.Rows.Add(Tabla.Rows(0).Item("IDPrefactura"), Tabla.Rows(0).Item("SecondID"), CDate(Tabla.Rows(0).Item("FechaHora")).ToString("dd/MM/yyyy hh:mm:ss tt"), imgCliente, Tabla.Rows(0).Item("IDCliente"), Tabla.Rows(0).Item("NombreFactura"), Tabla.Rows(0).Item("IdentificacionFactura"), Tabla.Rows(0).Item("DireccionFactura"), Tabla.Rows(0).Item("TelefonosFactura"))
            End If
        Next

        ConMixPrefactura.Close()

        If DirLenght = 0 Then
            GridView2.Columns("Direccion").Visible = False
        Else
            GridView2.Columns("Direccion").Visible = True
        End If
        If RNCLenght = 0 Then
            GridView2.Columns("Identificacion").Visible = False
        Else
            GridView2.Columns("Identificacion").Visible = True
        End If

        If TelLenght = 0 Then
            GridView2.Columns("Telefonos").Visible = False
        Else
            GridView2.Columns("Telefonos").Visible = True
        End If


        GridView2.BestFitColumns()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        frm_cierre_facturas.SelectedIDPrefacturaMultiple = GridView2.GetFocusedRowCellValue("IDPrefactura").ToString

        Me.Close()

    End Sub

    Private Sub GridView2_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView2.RowClick
        If e.RowHandle >= 0 Then
            frm_cierre_facturas.SelectedIDPrefacturaMultiple = GridView2.GetFocusedRowCellValue("IDPrefactura").ToString

            Me.Close()
        End If
    End Sub

    Private Sub frm_eleccion_prefactura_multiple_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        CType(Me.Owner, Form).Activate()
    End Sub
End Class