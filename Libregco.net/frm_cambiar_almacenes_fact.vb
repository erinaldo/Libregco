Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_cambiar_almacenes_fact

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend IDPrecios As New Label

    Private Sub frm_cambiar_almacenes_fact_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        PropiedadDgvAlmacen()
        DgvAlmacen.Rows.Clear()
        ConMixta.Open()
        Dim Consulta As New MySqlCommand("SELECT Almacen.IDAlmacen,Almacen.Almacen,Medida.Medida,Existencia FROM Libregco.existencia INNER JOIN" & SysName.Text & "Almacen on Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "' AND IDPrecios='" + IDPrecios.Text + "' AND PrecioArticulo.Nulo=0", ConMixta)
        Dim LectorAlmacenes As MySqlDataReader = Consulta.ExecuteReader

        While LectorAlmacenes.Read
            DgvAlmacen.Rows.Add(LectorAlmacenes.GetValue(0), LectorAlmacenes.GetValue(1), LectorAlmacenes.GetValue(2), LectorAlmacenes.GetValue(3))
        End While

        LectorAlmacenes.Close()
        ConMixta.Close()
    End Sub

    Private Sub PropiedadDgvAlmacen()
        Try
            Dim DatagridWith As Double = (DgvAlmacen.Width - DgvAlmacen.RowHeadersWidth) / 100

            With DgvAlmacen
                .Columns(0).HeaderText = "Código"
                .Columns(0).Width = DatagridWith * 20
                .Columns(1).HeaderText = "Almacén"
                .Columns(1).Width = DatagridWith * 40
                .Columns(2).HeaderText = "Medida"
                .Columns(2).Width = DatagridWith * 20
                .Columns(3).HeaderText = "Existencia"
                .Columns(3).Width = DatagridWith * 20
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DgvAlmacen_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvAlmacen.CellClick
        If e.RowIndex >= 0 Then
            If Me.Owner.Name = frm_facturacion.Name Then
                frm_facturacion.dgvArticulosFactura.CurrentRow.Cells(12).Value = DgvAlmacen.CurrentRow.Cells(0).Value
            ElseIf Me.Owner.Name = frm_prefacturacion.Name Then
                frm_prefacturacion.dgvArticulosFactura.CurrentRow.Cells(12).Value = DgvAlmacen.CurrentRow.Cells(0).Value
            ElseIf Me.Owner.Name = frm_punto_venta_lite.Name Then
                frm_punto_venta_lite.DgvArticulos.CurrentRow.Cells(12).Value = DgvAlmacen.CurrentRow.Cells(0).Value
            ElseIf Me.Owner.Name = frm_cotizacion.Name Then
                frm_cotizacion.dgvArticulos.CurrentRow.Cells(12).Value = DgvAlmacen.CurrentRow.Cells(0).Value
            ElseIf Me.Owner.Name = frm_ajuste_inventario.Name Then

            ElseIf Me.Owner.Name = frm_inv_inicial.Name Then
                frm_inv_inicial.DgvArticulos.CurrentRow.Cells(10).Value = DgvAlmacen.CurrentRow.Cells(0).Value
            ElseIf Me.Owner.Name = frm_devolucion_compras.Name Then
                frm_devolucion_compras.DgvArticulos.CurrentRow.Cells(14).Value = DgvAlmacen.CurrentRow.Cells(0).Value
            End If
            Close()
        End If
    End Sub
End Class