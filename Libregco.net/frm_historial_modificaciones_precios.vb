Imports System.IO

Public Class frm_historial_modificaciones_precios
    Dim cmd As MySqlCommand
    Dim sqlQ As String
    Dim Adaptador As MySqlDataAdapter
    Dim TablaPrecios As DataTable
    Private Sub frm_historial_modificaciones_precios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TablaPrecios = New DataTable("Precios")
        TablaPrecios.Columns.Add("idPrecioArticulo_historial", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
        TablaPrecios.Columns.Add("FotoArticulo", System.Type.GetType("System.Object"))
        TablaPrecios.Columns.Add("RutaFoto", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Articulo", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Medida", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("FotoUsuario", System.Type.GetType("System.Object"))
        TablaPrecios.Columns.Add("RutaFotoUsuario", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Usuario", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("Acciones", System.Type.GetType("System.String"))
        TablaPrecios.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
        GridControl1.DataSource = TablaPrecios
        FillArticulos()

    End Sub

    Sub FillArticulos()
        'Try
        TablaPrecios.Clear()

        Using ConMixta As MySqlConnection = New MySqlConnection(CnString)
            Using myCommand As MySqlCommand = New MySqlCommand("SELECT idPrecioArticulo_historial,precioarticulo_historial.Fecha,Articulos.RutaFoto,Articulos.Descripcion as Articulo,Medida.Medida,Empleados.RutaFoto as RutaFotoUsuario,Empleados.Nombre as Usuario,precioarticulo_historial.Modificacion as Descripcion,Articulos.IDArticulo FROM libregco.precioarticulo_historial INNER JOIN Libregco.PrecioArticulo on precioarticulo_historial.IDPrecioArticulo=PrecioArticulo.IDPrecios INNER JOIN Libregco.Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Libregco.Empleados on precioarticulo_historial.IDUsuario=Empleados.IDEmpleado Where Descripcion like '%" + txtDescripcion.Text + "%' ORDER BY idPrecioArticulo_historial DESC LIMIT " & SpinEdit1.Value.ToString, ConMixta)
                ConMixta.Open()
                Using myReader As MySqlDataReader = myCommand.ExecuteReader
                    TablaPrecios.Load(myReader, LoadOption.Upsert)
                    ConMixta.Close()
                    ConMixta.Dispose()
                End Using
            End Using
        End Using
        TablaPrecios.EndLoadData()

        For Each dt As DataRow In TablaPrecios.Rows
            Dim wFile As System.IO.FileStream
            Dim ImgFile, ImgUser As Image
            dt.Item("Acciones") = 0

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

            dt.Item("FotoArticulo") = ImgFile


            If dt.Item("RutaFotoUsuario") = "" Then
                ImgUser = ResizeImage(My.Resources.No_Image, 64)
            Else
                If System.IO.File.Exists(dt.Item("RutaFotoUsuario")) Then
                    wFile = New FileStream(dt.Item("RutaFotoUsuario"), FileMode.Open, FileAccess.Read)
                    ImgUser = ResizeImage(System.Drawing.Image.FromStream(wFile), 64)
                    wFile.Close()
                Else
                    ImgUser = ResizeImage(My.Resources.No_Image, 64)
                End If
            End If

            dt.Item("FotoUsuario") = ImgUser





        Next

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString)
        'End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        FillArticulos()
    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        If e.Button.Tag = "Delete" Then
            If AdvBandedGridView1.GetFocusedRowCellValue("idPrecioArticulo_historial").ToString <> "" Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar la transacción de modificación de precios y costos?", "Eliminar transacción", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ControlSuperClave = 1
                    frm_superclave.IDAccion.Text = 137
                    frm_superclave.ShowDialog(Me)

                    If ControlSuperClave = 1 Then
                        Exit Sub
                    End If

                    sqlQ = "Delete from precioarticulo_historial WHERE idPrecioArticulo_historial='" + AdvBandedGridView1.GetFocusedRowCellValue("idPrecioArticulo_historial").ToString + "'"
                    ConLibregco.Open()
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()
                    ConLibregco.Close()

                    AdvBandedGridView1.DeleteRow(AdvBandedGridView1.FocusedRowHandle)
                    MessageBox.Show("El registro de modificación de precios y costos ha sido eliminado", "Registro eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If
            End If
        End If
    End Sub

    Private Sub txtDescripcion_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txtDescripcion.ButtonClick
        If e.Button.Tag = "Buscar" Then
            frm_buscar_mant_articulos.ShowDialog(Me)

        ElseIf e.Button.Tag = "Actualizar" Then
            FillArticulos
        End If
    End Sub
End Class