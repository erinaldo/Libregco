Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_articulosnocomprados_listados
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend ProductImage As Image
    Dim Permisos As New ArrayList

    Private Sub frm_articulosnocomprados_listados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        ColumnasDgvArticulos()
        RefrescarTablaArticulos()
    End Sub

    Private Sub ColumnasDgvArticulos()
        Dim ImageColumn As New DataGridViewImageColumn

        DgvArticulos.Columns.Clear()
        With DgvArticulos
            .Columns.Add("IDListadoDetalle", "IDListadoDetalle")  '0
            .Columns.Add("IDListado", "IDListado")    '1
            .Columns.Add("IDArticulo", "Código")    '2
            .Columns.Add("Descripcion", "Descripción")  '3
            .Columns.Add("IDPrecio", "IDPrecio")    '4
            .Columns.Add("IDMedida", "IDMedida")    '5
            .Columns.Add("Medida", "Medida")        '6
            .Columns.Add("Cantidad", "Cant.")   '7
            .Columns.Add("PrecioUnitario", "Precio") '8
            .Columns.Add("Importe", "Importe")  '9
            .Columns.Add(ImageColumn)            '10
            .Columns.Add("IDSuplidor", "IDSuplidor") '11
            .Columns.Add("Informacion", "Info")     '12
        End With

        With ImageColumn
            .Width = 80
            .ImageLayout = DataGridViewImageCellLayout.Zoom
            .HeaderText = "Imagen"
            .Visible = True
        End With

        PropiedadesDgvArticulos()
    End Sub

    Sub PropiedadesDgvArticulos()
        Try
            Dim DatagridWith As Double = (DgvArticulos.Width - 80 - DgvArticulos.RowHeadersWidth) / 100
            Dim Condicion As String = False

            With DgvArticulos
                .Columns(0).Visible = Condicion
                .Columns(1).Visible = Condicion
                .Columns(2).Width = DatagridWith * 7
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(2).DefaultCellStyle.ForeColor = SystemColors.Highlight
                .Columns(3).Width = DatagridWith * 35
                .Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .Columns(4).Visible = Condicion
                .Columns(5).Visible = Condicion
                .Columns(6).Width = DatagridWith * 8
                .Columns(7).Width = DatagridWith * 6
                .Columns(8).DefaultCellStyle.Format = ("C")
                .Columns(8).Width = DatagridWith * 10
                .Columns(9).DefaultCellStyle.Format = ("C")
                .Columns(9).Width = DatagridWith * 10
                .Columns(10).DisplayIndex = 0
                .Columns(11).Visible = Condicion
                .Columns(12).Width = DatagridWith * 24
                .Columns(12).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Underline)
                .Columns(13).Visible = False
            End With

        Catch ex As Exception

        End Try
    End Sub

    Sub RefrescarTablaArticulos()

        Try
            Dim RecibidoValue As Integer

            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

            If rdbNoPedidos.Checked = True Then
                RecibidoValue = 0

            ElseIf rdbEnTransito.Checked = True Then
                RecibidoValue = 2
            ElseIf rdbRecibidos.Checked = True Then
                RecibidoValue = 1
            End If


            DgvArticulos.Rows.Clear()
            Con.Open()

            Dim Consulta As New MySqlCommand("Select IDListadoArticulosDetalle,IDListadoArticulo,ListadoArticulosDetalle.IDArticulo,Articulos.Descripcion,ListadoArticulosDetalle.IDPrecio,ListadoArticulosDetalle.IDMedida,Medida.Medida,ListadoArticulosDetalle.Cantidad,ListadoArticulosDetalle.Precio,ListadoArticulosDetalle.Importe,Articulos.RutaFoto,Articulos.IDSuplidor,Suplidor.Suplidor,Departamento,Categoria,SubCategoria FROM ListadoArticulosDetalle INNER JOIN Libregco.Articulos on ListadoArticulosDetalle.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Suplidor on Articulos.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Medida on ListadoArticulosDetalle.IDMedida=Medida.IDMedida INNER JOIN Libregco.SubCategoria on Articulos.IDSubCategoria=SubCategoria.IDSubCategoria INNER JOIN Libregco.Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria INNER JOIN Libregco.Departamentos on Categoria.IDDepartamento=Departamentos.IDDepartamento Where ListadoArticulosDetalle.Recibido='" + RecibidoValue.ToString + "' GROUP BY ListadoArticulosDetalle.IDArticulo ORDER BY Departamento,Categoria,SubCategoria,Descripcion ASC", Con)

            Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

            While LectorArticulos.Read

                If TypeConnection.Text = 1 Then
                    If CStr(LectorArticulos.GetValue(10)) = "" Then
                        ProductImage = My.Resources.No_Image
                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists(LectorArticulos.GetValue(10))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(LectorArticulos.GetValue(10), FileMode.Open, FileAccess.Read)
                            ProductImage = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                        Else
                            ProductImage = My.Resources.No_Image
                        End If
                    End If
                Else
                    ProductImage = My.Resources.No_Image
                End If

                DgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), ProductImage, LectorArticulos.GetValue(11), LectorArticulos.GetValue(12).ToString.ToUpper)

            End While
            LectorArticulos.Close()
            Con.Close()

            PropiedadesDgvArticulos()

            DgvArticulos.ClearSelection()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub frm_articulosnocomprados_listados_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadesDgvArticulos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMarcarRecibido.Click
        If DgvArticulos.Rows.Count > 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea marcar este producto como recibido?", "Guardar como recibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE" & SysName.Text & "ListadoArticulosDetalle SET Recibido=1 where IDArticulo='" + DgvArticulos.CurrentRow.Cells(2).Value.ToString + "'"
                ConMixta.Open()
                cmd = New MySqlCommand(sqlQ, ConMixta)
                cmd.ExecuteNonQuery()
                ConMixta.Close()

                DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)

                MessageBox.Show("El artículo se ha marcado como recibido satisfactoriamente.", "Marcado como recibido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


            End If
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If DgvArticulos.Rows.Count > 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea marcar este producto como recibido?", "Guardar como recibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE" & SysName.Text & "ListadoArticulosDetalle SET Recibido=2 where IDArticulo='" + DgvArticulos.CurrentRow.Cells(2).Value.ToString + "'"
                ConMixta.Open()
                cmd = New MySqlCommand(sqlQ, ConMixta)
                cmd.ExecuteNonQuery()
                ConMixta.Close()

                DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)

                MessageBox.Show("El artículo se ha marcado como recibido satisfactoriamente.", "Marcado como recibido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


            End If
        End If

    End Sub

    Private Sub rdbNoPedidos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoPedidos.CheckedChanged
        RefrescarTablaArticulos()
    End Sub

    Private Sub rdbEnTransito_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEnTransito.CheckedChanged
        RefrescarTablaArticulos()
    End Sub

    Private Sub rdbRecibidos_CheckedChanged(sender As Object, e As EventArgs) Handles rdbRecibidos.CheckedChanged
        RefrescarTablaArticulos()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DgvArticulos.Rows.Count > 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea marcar este producto como no recibido?", "Guardar como no recibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE" & SysName.Text & "ListadoArticulosDetalle SET Recibido=0 where IDArticulo='" + DgvArticulos.CurrentRow.Cells(2).Value.ToString + "'"
                ConMixta.Open()
                cmd = New MySqlCommand(sqlQ, ConMixta)
                cmd.ExecuteNonQuery()
                ConMixta.Close()

                DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)

                MessageBox.Show("El artículo se ha marcado como no recibido satisfactoriamente.", "Marcado como no recibido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


            End If
        End If
    End Sub
End Class