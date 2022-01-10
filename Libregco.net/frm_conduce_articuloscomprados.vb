Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_conduce_articuloscomprados
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_conduce_articuloscomprados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()

        dgvArticulos.Rows.Clear()
        ConMixta.Open()
        Dim Consulta As New MySqlCommand("Select IDFactArt,FacturaArticulos.IDArticulo,FacturaArticulos.IDPrecio,PrecioArticulo.IDMedida,Descripcion,Cantidad,round(((Cantidad*contenido)-(select coalesce(Sum(Entregar*PrecioArticuloConduce.Contenido),0) from" & SysName.Text & "ConduceDetalle inner join Libregco.PrecioArticulo as PrecioArticuloConduce on ConduceDetalle.IDPrecio=PrecioArticuloConduce.IDPrecios INNER JOIN" & SysName.Text & "Conduce on ConduceDetalle.IDConduce=Conduce.IDConduce Where FacturaArticulos.IDFactArt=ConduceDetalle.IDFactArt and Conduce.Nulo=0))/PrecioArticulo.Contenido,4) as Disponible,Medida.Medida,Importe/Cantidad,Itbis,Importe,PrecioArticulo.Contenido,FacturaArticulos.Itbis,(Select coalesce(sum(cantDevuelta),0) from" & SysName.Text & "DevolucionVentadetalle inner join" & SysName.Text & "DevolucionVenta on DevolucionVentaDetalle.IDDevolucionVenta=DevolucionVenta.IDDevolucionVenta where FacturaArticulos.IDFactArt=DevolucionVentaDetalle.IDFactArt and DevolucionVenta.Nulo=0) as Devueltos from" & SysName.Text & "FacturaArticulos INNER JOIN Libregco.PrecioArticulo on FacturaArticulos.IDPrecio=PrecioArticulo.IDPrecios INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where IDFactura='" + frm_conduce.lblIDFactura.Text + "'", ConMixta)
        Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

        While LectorArticulos.Read
            dgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), (CDbl(LectorArticulos.GetValue(6)) - CDbl(LectorArticulos.GetValue(13))), LectorArticulos.GetValue(7), CDbl(LectorArticulos.GetValue(8)).ToString("C"), CDbl(LectorArticulos.GetValue(9)).ToString("C"), CDbl(LectorArticulos.GetValue(10)).ToString("C"), LectorArticulos.GetValue(11), LectorArticulos.GetValue(12))

            If CDbl(LectorArticulos.GetValue(13)) > 0 Then
                lblStatusBar.Text = "Esta factura tiene devoluciones realizadas."
            End If
        End While

        LectorArticulos.Close()
        ConMixta.Close()
        dgvArticulos.ClearSelection()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub dgvArticulos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulos.CellClick
        If e.RowIndex >= 0 Then
            If CDbl(dgvArticulos.CurrentRow.Cells(6).Value) > 0 Then
                frm_conduce.lblIDFactArt.Text = dgvArticulos.CurrentRow.Cells(0).Value
                frm_conduce.lblIDArticulo.Text = dgvArticulos.CurrentRow.Cells(1).Value
                frm_conduce.lblDescripcion.Text = dgvArticulos.CurrentRow.Cells(4).Value
                frm_conduce.lblCantidad.Text = dgvArticulos.CurrentRow.Cells(6).Value
                frm_conduce.lblMedida.Text = dgvArticulos.CurrentRow.Cells(7).Value
                frm_conduce.lblPrecioArticulo.Text = CDbl(dgvArticulos.CurrentRow.Cells(8).Value)
                frm_conduce.lblItbisArticulo.Text = CDbl(dgvArticulos.CurrentRow.Cells(9).Value)
                frm_conduce.ContenidoArticulo.Text = dgvArticulos.CurrentRow.Cells(11).Value
                frm_conduce.FillMedidaAplicables()
                frm_conduce.MostrarDetalleArticulos()
                frm_conduce.cbxMedida.Focus()
                frm_conduce.cbxMedida.DroppedDown = True

                Me.Close()
            Else
                MessageBox.Show("El artículo seleccionado no posee cantidades disponibles para seleccionar.")
            End If
        End If
    End Sub
End Class