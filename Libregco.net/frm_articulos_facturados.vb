Imports System.IO

Public Class frm_articulos_facturados
    Dim DTArticulo As New DataTable

    Private Sub FillCategoria()
        Dim Ds As New DataSet
        Dim cmd As MySqlCommand
        Dim Adaptador As MySqlDataAdapter

        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDCategoria,Categoria FROM Categoria", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Categoria")
        ConLibregco.Close()

        Dim TablaCat As DataTable = Ds.Tables("Categoria")

        RepositoryItemLookUpEdit1Cat.DataSource = TablaCat
        RepositoryItemLookUpEdit1Cat.ValueMember = "IDCategoria"
        RepositoryItemLookUpEdit1Cat.DisplayMember = "Categoria"

        RepositoryItemLookUpEdit1Cat.PopulateColumns()
        RepositoryItemLookUpEdit1Cat.Columns(RepositoryItemLookUpEdit1Cat.ValueMember).Visible = False
        RepositoryItemLookUpEdit1Cat.ShowHeader = False
    End Sub

    Private Sub FillSubCategoria()
        Dim Ds As New DataSet
        Dim cmd As MySqlCommand
        Dim Adaptador As MySqlDataAdapter

        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDSubCategoria,SubCategoria FROM SubCategoria", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "SubCategoria")
        ConLibregco.Close()

        Dim TablaSub As DataTable = Ds.Tables("SubCategoria")

        RepositoryItemLookUpEdit2SubCat.DataSource = TablaSub
        RepositoryItemLookUpEdit2SubCat.ValueMember = "IDSubCategoria"
        RepositoryItemLookUpEdit2SubCat.DisplayMember = "SubCategoria"

        RepositoryItemLookUpEdit2SubCat.PopulateColumns()
        RepositoryItemLookUpEdit2SubCat.Columns(RepositoryItemLookUpEdit2SubCat.ValueMember).Visible = False
        RepositoryItemLookUpEdit2SubCat.ShowHeader = False
    End Sub


    Private Sub frm_articulos_facturados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try
        DTArticulo.Columns.Clear()
        DTArticulo.Rows.Clear()
        DTArticulo.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
        DTArticulo.Columns.Add("IDPrecio", System.Type.GetType("System.String"))
        DTArticulo.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        DTArticulo.Columns.Add("Referencia", System.Type.GetType("System.String"))
        DTArticulo.Columns.Add("IDMedida", System.Type.GetType("System.String"))
        DTArticulo.Columns.Add("Medida", System.Type.GetType("System.String"))
        DTArticulo.Columns.Add("RutaFoto", System.Type.GetType("System.String"))
        DTArticulo.Columns.Add("Cantidad", System.Type.GetType("System.String"))
        DTArticulo.Columns.Add("PrecioUnitario", System.Type.GetType("System.Double"))
        DTArticulo.Columns.Add("Importe", System.Type.GetType("System.Double"))
        DTArticulo.Columns.Add("IDCategoria", System.Type.GetType("System.String"))
        DTArticulo.Columns.Add("IDSubCategoria", System.Type.GetType("System.String"))
        DTArticulo.Columns.Add("Imagen", System.Type.GetType("System.Object"))
        GridControl1.DataSource = DTArticulo


        FillCategoria()
        FillSubCategoria()

        Using ConMixta As MySqlConnection = New MySqlConnection(CnString)
            Using myCommand As MySqlCommand = New MySqlCommand("SELECT FacturaArticulos.IDArticulo,IDPrecio,FacturaArticulos.Descripcion,Articulos.Referencia,FacturaArticulos.IDMedida,FacturaArticulos.Medida,Articulos.RutaFoto,FacturaArticulos.Cantidad,(Importe/Cantidad) as PrecioUnitario,FacturaArticulos.Importe,Articulos.IDCategoria,Articulos.IDSubCategoria,'' AS Imagen FROM" & SysName.Text & "FacturaArticulos INNER JOIN Libregco.Articulos ON FacturaArticulos.IDArticulo=Articulos.IDArticulo WHERE FacturaArticulos.IDFactura='" + frm_recibo_pagos.AdvBandedGridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString + "' ORDER BY FacturaArticulos.Orden ASC", ConMixta)
                ConMixta.Open()
                Using myReader As MySqlDataReader = myCommand.ExecuteReader
                    DTArticulo.Load(myReader, LoadOption.Upsert)
                    ConMixta.Close()
                    ConMixta.Dispose()
                End Using
            End Using
        End Using
            DTArticulo.EndLoadData()

            Me.Text = "Artículos asociados a " & frm_recibo_pagos.AdvBandedGridView1.GetFocusedRowCellValue("SecondID").ToString

            For Each dt As DataRow In DTArticulo.Rows
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

                dt.Item("Imagen") = ImgFile
            Next



            'DTArticulo.Rows.Clear()
        'DTArticulo = GetData("SELECT FacturaArticulos.IDArticulo,IDPrecio,FacturaArticulos.Descripcion,Articulos.Referencia,FacturaArticulos.IDMedida,FacturaArticulos.Medida,Articulos.RutaFoto,FacturaArticulos.Cantidad,(Importe/Cantidad) as PrecioUnitario,FacturaArticulos.Importe,Articulos.IDCategoria,Articulos.IDSubCategoria, FROM" & SysName.Text & "FacturaArticulos INNER JOIN Libregco.Articulos ON FacturaArticulos.IDArticulo=Articulos.IDArticulo WHERE FacturaArticulos.IDFactura='" + frm_recibo_pagos.AdvBandedGridView1.GetFocusedRowCellValue("IDFacturaDatos").ToString + "' ORDER BY FacturaArticulos.Orden ASC", ConMixta)
        'DTArticulo.Columns("Imagen").DataType = System.Type.GetType("System.Object")

        'Me.Text = "Artículos asociados a " & frm_recibo_pagos.AdvBandedGridView1.GetFocusedRowCellValue("SecondID").ToString
        'GridControl1.DataSource = DTArticulo


        'MessageBox.Show(DTArticulo.Columns("Imagen").DataType.ToString)
        'For Each dt As DataRow In DTArticulo.Rows
        '    Dim wFile As System.IO.FileStream
        '    Dim ImgFile As Image

        '    If dt.Item("RutaFoto") = "" Then
        '        ImgFile = ResizeImage(My.Resources.No_Image, 64)
        '    Else
        '        If System.IO.File.Exists(dt.Item("RutaFoto")) Then
        '            wFile = New FileStream(dt.Item("RutaFoto"), FileMode.Open, FileAccess.Read)
        '            ImgFile = ResizeImage(System.Drawing.Image.FromStream(wFile), 64)
        '            wFile.Close()
        '        Else
        '            ImgFile = ResizeImage(My.Resources.No_Image, 64)
        '        End If
        '    End If

        '    dt.Item("Imagen") = ImgFile
        '    'Next

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString)
        'End Try
    End Sub


End Class