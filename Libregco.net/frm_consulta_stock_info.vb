Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frm_consulta_stock_info

    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim IDArticulo As New Label


    Private Sub frm_consulta_stock_info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        PicLogo.Image = ConseguirLogoSistema()
        Limpiar()
        TakeTextForm()
        PassIDArticulo()
        LlenarDescripcion()
    End Sub

    Private Sub Limpiar()
        Try
            DgvHistorialCompra.Rows.Clear()
            LboxDesc.Items.Clear()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PassIDArticulo()
        If Me.Owner.Name = frm_consulta_stocks.Name = True Then
            IDArticulo.Text = frm_consulta_stocks.DgvProductos.CurrentRow.Cells(0).Value
        ElseIf Me.Owner.Name = frm_mant_articulos.Name = True Then
            IDArticulo.Text = frm_mant_articulos.txtIDProducto.Text
        End If

        RefrescarHistoriaCompra()
    End Sub

    Private Sub LlenarDescripcion()
        Try

            Ds1.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT Referencia,TipoArticulo,Departamento,Tipo,Categoria,SubCategoria,Marca FROM Libregco.articulos INNER JOIN Libregco.tipoarticulo on Articulos.IDTipoProducto=TipoArticulo.IDTipoArticulo INNER JOIN Libregco.Departamentos on Articulos.IDDepartamento=Departamentos.IDDepartamento INNER JOIN Libregco.tipoitbis on Articulos.IDItbis=TipoItbis.IDTipoItbis INNER JOIN Libregco.Categoria on Articulos.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.SubCategoria on Articulos.IDSubCategoria=SubCategoria.IDSubCategoria INNER JOIN Libregco.Marca on Articulos.IDMarca=Marca.IDMarca Where IDArticulo='" + IDArticulo.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Articulos")
            ConMixta.Close()
            Dim Tabla As DataTable = Ds1.Tables("Articulos")

            With LboxDesc
                .Items.Add("Referencia y/o Modelo: " & Tabla.Rows(0).Item("Referencia"))
                .Items.Add("Tipo de Artículo: " & Tabla.Rows(0).Item("TipoArticulo"))
                .Items.Add("Departamento: " & Tabla.Rows(0).Item("Departamento") & " / Categoría: " & Tabla.Rows(0).Item("Categoria") & " / Sub-Categoría: " & Tabla.Rows(0).Item("SubCategoria"))
                .Items.Add("Marca: " & Tabla.Rows(0).Item("Marca"))
                .Items.Add("Impuesto al Consumo: " & Tabla.Rows(0).Item("Tipo"))
            End With


        Catch ex As Exception

        End Try
    End Sub

    Private Sub TakeTextForm()
        If frm_consulta_stocks.Visible = True Then
            Me.Text = "Stock Info: Producto [" & frm_consulta_stocks.DgvProductos.CurrentRow.Cells(0).Value & "] " & frm_consulta_stocks.DgvProductos.CurrentRow.Cells(1).Value
        End If
        If frm_mant_articulos.Visible = True Then
            Me.Text = "Stock Info: Producto [" & frm_mant_articulos.txtIDProducto.Text & "] " & frm_mant_articulos.txtDescrip.Text
        End If
    End Sub

    Private Sub RefrescarHistoriaCompra()
        'Try

        DgvHistorialCompra.Rows.Clear()

        If CInt(DTConfiguracion.Rows(185 - 1).Item("Value2Int")) = 0 Then
            ConMixta.Open()
            Dim SqlCompras As New MySqlCommand("SELECT Compras.SecondID,Suplidor,FechaFactura,Medida.Medida,Cantidad,Importe,Compras.RutaDocumento,Compras.IDCompra,DetalleCompra.IDPrecio FROM" & SysName.Text & "detallecompra INNER JOIN" & SysName.Text & "Compras on DetalleCompra.IDCompra=Compras.IDCompra INNER JOIN Libregco.Medida on DetalleCompra.IDMedida=Medida.IDMedida INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor WHERE IDArticulo='" + IDArticulo.Text + "' ORDER BY FechaFactura DESC", ConMixta)
            Dim LectorHistoria As MySqlDataReader = SqlCompras.ExecuteReader

            While LectorHistoria.Read
                DgvHistorialCompra.Rows.Add(LectorHistoria.GetValue(0), LectorHistoria.GetValue(1), CDate(LectorHistoria.GetValue(2)).ToString("dd/MM/yyyy"), LectorHistoria.GetValue(3), LectorHistoria.GetValue(4), CDbl(LectorHistoria.GetValue(5)).ToString("C"), LectorHistoria.GetValue(6), LectorHistoria.GetValue(7), LectorHistoria.GetValue(8))
            End While
            LectorHistoria.Close()
            ConMixta.Close()

        Else
            'Z
            ConMixta.Open()

            Dim SqlComprasz As New MySqlCommand("SELECT Compras.SecondID,Suplidor,FechaFactura,Medida.Medida,Cantidad,Importe,Compras.RutaDocumento,Compras.IDCompra,DetalleCompra.IDPrecio FROM Libregco.detallecompra INNER JOIN Libregco.Compras on DetalleCompra.IDCompra=Compras.IDCompra INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Medida on DetalleCompra.IDMedida=Medida.IDMedida WHERE IDArticulo='" + IDArticulo.Text + "' ORDER BY FechaFactura DESC", ConMixta)
            Dim LectorHistoriaZ As MySqlDataReader = SqlComprasz.ExecuteReader

            While LectorHistoriaZ.Read
                DgvHistorialCompra.Rows.Add(LectorHistoriaZ.GetValue(0), LectorHistoriaZ.GetValue(1), CDate(LectorHistoriaZ.GetValue(2)).ToString("dd/MM/yyyy"), LectorHistoriaZ.GetValue(3), LectorHistoriaZ.GetValue(4), CDbl(LectorHistoriaZ.GetValue(5)).ToString("C"), LectorHistoriaZ.GetValue(6), LectorHistoriaZ.GetValue(7), LectorHistoriaZ.GetValue(8))
            End While
            LectorHistoriaZ.Close()

            'A
            Dim SqlComprasA As New MySqlCommand("SELECT Compras.SecondID,Suplidor,FechaFactura,Medida.Medida,Cantidad,Importe,Compras.RutaDocumento,Compras.IDCompra,DetalleCompra.IDPrecio FROM Libregco_Main.detallecompra INNER JOIN Libregco_Main.Compras on DetalleCompra.IDCompra=Compras.IDCompra INNER JOIN Libregco.Suplidor on Compras.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Medida on DetalleCompra.IDMedida=Medida.IDMedida WHERE IDArticulo='" + IDArticulo.Text + "' ORDER BY FechaFactura DESC", ConMixta)
            Dim LectorHistoriaA As MySqlDataReader = SqlComprasA.ExecuteReader

            While LectorHistoriaA.Read
                DgvHistorialCompra.Rows.Add(LectorHistoriaA.GetValue(0), LectorHistoriaA.GetValue(1), CDate(LectorHistoriaA.GetValue(2)).ToString("dd/MM/yyyy"), LectorHistoriaA.GetValue(3), LectorHistoriaA.GetValue(4), CDbl(LectorHistoriaA.GetValue(5)).ToString("C"), LectorHistoriaA.GetValue(6), LectorHistoriaA.GetValue(7), LectorHistoriaA.GetValue(8))
            End While
            LectorHistoriaA.Close()

            ConMixta.Close()
        End If

        For Each row As DataGridViewRow In DgvHistorialCompra.Rows
            Dim ExistFile As Boolean = System.IO.File.Exists(row.Cells(6).Value)
            If ExistFile = True Then
                row.Cells(1).Value = row.Cells(1).Value & vbNewLine & "-> Factura disponible"
                row.Cells(1).Style.ForeColor = SystemColors.Highlight
                row.Cells(1).Style.Font = New Font("Tahoma", 8, FontStyle.Bold)
            End If
        Next

        DgvHistorialCompra.ClearSelection()
        DgvHistorialCompra.Sort(DgvHistorialCompra.Columns(7), System.ComponentModel.ListSortDirection.Ascending)
        DgvHistorialCompra.Columns(7).Visible = False


        Dim dstemp As New DataSet
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDPrecios,PrecioArticulo.IDMedida,Medida.Medida FROM libregco.precioarticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where IDArticulo='" + IDArticulo.Text + "'", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Medida")
        ConLibregco.Close()

        Chart1.Series.Clear()

        For Each rw As DataRow In Ds1.Tables("Medida").Rows
            Dim sr As New Series
            sr.Tag = rw.Item("IDPrecios")
            sr.Name = rw.Item("IDPrecios")
            sr.ChartType = SeriesChartType.Spline
            sr.XValueType = ChartValueType.Date
            sr.YValueType = ChartValueType.Double
            'sr.IsValueShownAsLabel = True

            Chart1.Series.Add(sr)
        Next

        For Each rt As DataGridViewRow In DgvHistorialCompra.Rows
            Chart1.Series(rt.Cells("IDPrecio").Value.ToString).Points.AddXY(CDate(rt.Cells(2).Value).ToString("MMMM-yyyy"), CDbl(rt.Cells(5).Value))
        Next


        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub DgvHistorialCompra_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvHistorialCompra.CellDoubleClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Then
                If DgvHistorialCompra.CurrentRow.Cells(6).Value <> "" Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(DgvHistorialCompra.CurrentRow.Cells(6).Value)
                    If ExistFile = True Then
                        System.Diagnostics.Process.Start(DgvHistorialCompra.CurrentRow.Cells(6).Value)
                        DgvHistorialCompra.ClearSelection()
                    End If
                End If
            End If

        End If
    End Sub


    Private Sub VerificarCantidadReg()
        If DgvHistorialCompra.Rows.Count = 0 Then
            MessageBox.Show("Este artículo no posee entradas por compras.", "No se encontraron resultados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

End Class