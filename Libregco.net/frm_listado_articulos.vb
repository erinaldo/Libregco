Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_listado_articulos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDUsuario, lblIDPrecio, lblIDMedida, lblNulo, lblCheckDuplicates, lblIDSuplidor, lblIDListaDetalle, IsReceived As New Label
    Friend ProductImage As Image
    Dim Permisos As New ArrayList

    Private Sub frm_listado_articulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        ColumnasDgvArticulos()
        LimpiarDatos()
        ActualizarTodo()
        Permisos = PasarPermisos(Me.Tag)
        GetUltimoRegistro()
    End Sub

    Private Sub GetUltimoRegistro()

        ''Llenar ultimo listado de articulos automaticamente
        If CInt(DTConfiguracion.Rows(215 - 1).Item("Value2Int")) = 1 Then

            Dim dstemp As New DataSet
            Con.Open()
            cmd = New MySqlCommand("Select * from ListasArticulos where IDListaArticulos=(Select Max(IDListaArticulos) from ListasArticulos)", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Listasarticulos")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Listasarticulos")

            Hora.Enabled = False
            txtIDListado.Text = (Tabla.Rows(0).Item("IDListaArticulos"))
            txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
            txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
            txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
            lblIDUsuario.Text = (Tabla.Rows(0).Item("IDUsuario"))
            txtDescripcion.Text = (Tabla.Rows(0).Item("Descripcion"))
            txtTotal.Text = CDbl(Tabla.Rows(0).Item("Total")).ToString("C")
            lblNulo.Text = (Tabla.Rows(0).Item("Nulo"))

            If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                ChkNulo.Checked = False
            Else
                ChkNulo.Checked = True
            End If

            RefrescarTablaArticulos()

            Tabla.Dispose()
            dstemp.Dispose()

        End If


        Dim PermisosArticulos As New ArrayList
        PermisosArticulos = PasarPermisos(3)

        If PermisosArticulos(0) = 0 Then
            txtPrecio.Visible = False
            DgvArticulos.Columns("PrecioUnitario").Visible = False
            DgvArticulos.Columns("Importe").Visible = False
            txtTotal.Visible = False
            txtDescripcionArticulo.Size = New Size(715, 23)
            Label2.Visible = False
        Else
            txtPrecio.Visible = True
            DgvArticulos.Columns("PrecioUnitario").Visible = True
            DgvArticulos.Columns("Importe").Visible = True
            txtTotal.Visible = True
            txtDescripcionArticulo.Size = New Size(579, 23)
            Label2.Visible = True
        End If
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub


    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
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
            .Columns.Add("Verificado", "Verificado")  '13
            .Columns.Add("Imagen", "") '14
            .Columns.Add("Estado", "Estado")    '15
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
            Dim DatagridWith As Double = (DgvArticulos.Width - 110 - DgvArticulos.RowHeadersWidth) / 100
            Dim Condicion As String = False
            'DgvArticulos.ScrollBars = ScrollBars.Both
            With DgvArticulos
                .Columns(0).Visible = Condicion
                .Columns(1).Visible = Condicion
                .Columns(2).Width = DatagridWith * 7
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(2).DefaultCellStyle.ForeColor = SystemColors.Highlight
                .Columns(3).Width = DatagridWith * 32
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
                .Columns(12).Width = DatagridWith * 19
                .Columns(12).DefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Underline)
                .Columns(13).Visible = Condicion
                .Columns(14).Width = 30
                .Columns(14).DefaultCellStyle.Font = New Font("Wingdings", 12)
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(15).Width = DatagridWith * 8
                .Columns(15).DefaultCellStyle.Font = New Font("Tahoma", 8)
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub txtIDArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIDArticulo.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtCantidadArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadArticulo.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub txtIDArticulo_Leave(sender As Object, e As EventArgs) Handles txtIDArticulo.Leave
        Try
            If txtIDArticulo.Text = "" Then
                LimpiarDatosArticulos()
            Else
                SetInformacionArticulo()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub SetDescripcionArt()
        Try
            Ds.clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Descripcion,Articulos.RutaFoto,Articulos.IDSuplidor,Suplidor.Suplidor FROM Articulos INNER JOIN Libregco.Suplidor on Articulos.IDSuplidor=Suplidor.IDSuplidor WHERE IDArticulo= '" + txtIDArticulo.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Articulos")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Articulos")

            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se encontró el artículo.", "Producto no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                LimpiarDatosArticulos()
                txtIDArticulo.Focus()
                ProductImage = My.Resources.No_Image
            Else
                If TypeConnection.Text = 1 Then
                    If (Tabla.Rows(0).Item("RutaFoto")) = "" Then
                        ProductImage = My.Resources.No_Image
                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto"))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(Tabla.Rows(0).Item("RutaFoto"), FileMode.Open, FileAccess.Read)
                            ProductImage = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                        Else
                            ProductImage = My.Resources.No_Image
                        End If
                    End If
                Else
                    ProductImage = My.Resources.No_Image
                End If


                txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
                lblIDSuplidor.Text = Tabla.Rows(0).Item("IDSuplidor")
                lblIDSuplidor.Tag = Tabla.Rows(0).Item("Suplidor")

            End If


        Catch ex As Exception
            MessageBox.Show("No se encontró el artículo.", "Producto no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        End Try
    End Sub

    Sub SetInformacionArticulo()
        Try
            SetDescripcionArt()
            txtCantidadArticulo.Text = 1
            FillMedida()
        Catch ex As Exception
            LimpiarDatosArticulos()
        End Try
    End Sub

    Private Sub FillMedida()
        Ds.clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select IDArticulo,Abreviatura from precioarticulo INNER JOIN medida ON precioarticulo.IDMedida=medida.IDMedida Where IDArticulo = '" + txtIDArticulo.Text + "' AND Nulo=0", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "PrecioArticulo")
        CbxMedida.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("PrecioArticulo")

        For Each Fila As DataRow In Tabla.Rows
            CbxMedida.Items.Add(Fila.Item("Abreviatura"))
        Next

        CbxMedida.SelectedIndex = 0
    End Sub

    Sub LimpiarDatosArticulos()
        txtIDArticulo.Clear()
        txtDescripcionArticulo.Clear()
        txtCantidadArticulo.Clear()
        txtPrecio.Clear()
        txtCantidadArticulo.Clear()
        CbxMedida.Items.Clear()
        ProductImage = My.Resources.No_Image
    End Sub

    Private Sub CbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMedida.SelectedIndexChanged
        SetIDMedida()
        SetPrecio()
    End Sub

    Private Sub SetIDMedida()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDMedida FROM Medida WHERE Abreviatura= '" + CbxMedida.SelectedItem + "'", ConLibregco)
        lblIDMedida.Text = Convert.ToDouble(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Sub SetPrecio()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDPrecios,Costo FROM PrecioArticulo WHERE IDArticulo= '" + txtIDArticulo.Text + "' AND IDMedida='" + lblIDMedida.Text + "' AND Nulo=0", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "PrecioArticulo")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("PrecioArticulo")

            txtPrecio.Text = CDbl(Tabla.Rows(0).Item("Costo")).ToString("C")
            lblIDPrecio.Text = (Tabla.Rows(0).Item("IDPrecios"))

        Catch ex As Exception
            LimpiarDatosArticulos()
        End Try
    End Sub

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.Checked = True Then
            DesHabilitarControles()
            lblNulo.Text = 1
        Else
            HabilitarControles()
            lblNulo.Text = 0
        End If
    End Sub

    Private Sub DesHabilitarControles()
        GbArticulos.Enabled = False
        txtDescripcion.Enabled = False
    End Sub

    Private Sub HabilitarControles()
        GbArticulos.Enabled = True
        txtDescripcion.Enabled = True
    End Sub

    Private Sub VerificarDuplicados()
        Dim x As Integer = 0
Inicio:
        If DgvArticulos.Rows.Count = 0 Or x = DgvArticulos.Rows.Count Then
            lblCheckDuplicates.Text = 0
            Exit Sub
        End If

        If CInt(DgvArticulos.Rows(x).Cells(4).Value) = CInt(lblIDPrecio.Text) Then
            MessageBox.Show("Este artículo ya se encuentra introducido en el listado." & vbNewLine & "No es posible duplicar la existencia del mismo artículo.", "Producto ya introducido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtIDArticulo.Focus()
            lblCheckDuplicates.Text = 1
            Exit Sub
        Else
            x = x + 1
            GoTo Inicio
        End If

    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        Try

            If txtIDArticulo.Text = "" Then
                MessageBox.Show("El producto no es válido para insertar.", "No se encontraron resultados de artículos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtIDArticulo.Focus()

            Else

                If CbxMedida.Items.Count = 0 Then
                    MessageBox.Show("El artículo " & txtDescripcionArticulo.Text & " no tiene unidades de medidas válidas para registrar. Por favor verifique el artículo e inserte unidades de ventas.", "Medidas no encontradas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    CbxMedida.Focus()
                    Exit Sub
                End If

                'VerificarDuplicados()
                'If lblCheckDuplicates.Text = 1 Then
                '    Exit Sub
                'End If

                With DgvArticulos
                    .Rows.Add(lblIDListaDetalle.Text, txtIDListado.Text, txtIDArticulo.Text, txtDescripcionArticulo.Text, lblIDPrecio.Text, lblIDMedida.Text, CbxMedida.Text, txtCantidadArticulo.Text, CDbl(txtPrecio.Text).ToString("C"), (CDbl(txtPrecio.Text) * CDbl(txtCantidadArticulo.Text)).ToString("C"), ProductImage, lblIDSuplidor.Text, lblIDSuplidor.Tag.ToString.ToUpper, IsReceived.Text)
                End With

                SumTotal()
                LimpiarTextInsert()
                DgvArticulos.FirstDisplayedScrollingRowIndex = DgvArticulos.Rows.Count - 1
                DgvArticulos.ClearSelection()
                IsReceived.Text = 0
                txtIDArticulo.Focus()

            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LimpiarTextInsert()
        CbxMedida.Items.Clear()
        txtCantidadArticulo.Clear()
        txtDescripcionArticulo.Clear()
        txtPrecio.Clear()
        txtIDArticulo.Clear()
        lblIDMedida.Text =
        lblIDPrecio.Text = ""
        lblIDListaDetalle.Text = ""
        txtIDArticulo.Focus()
    End Sub

    Private Sub DgvArticulos_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvArticulos.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvArticulos.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvArticulos.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvArticulos.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
            Con.Close()
        End Try
    End Sub

    Private Sub EliminarArticulo()
        Dim IDListadoArticuloDetalle As New Label
        IDListadoArticuloDetalle.Text = DgvArticulos.CurrentRow.Cells(0).Value

        If IDListadoArticuloDetalle.Text = "" Or txtIDListado.Text = "" Then
            Exit Sub
        Else
            sqlQ = "Delete from ListadoArticulosDetalle Where IDListadoArticulosDetalle = (" + IDListadoArticuloDetalle.Text + ")"
            GuardarDatos()

            MessageBox.Show("Artículo eliminado satisfactoriamente de la nota de pedido.", "Eliminado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub ActualizarTodo()
        HabilitarControles()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        txtTotal.Text = CDbl(0.0).ToString("C")
        lblNulo.Text = 0
        ChkNulo.Checked = False
        ControlSuperClave = 1
        lblCheckDuplicates.Text = 1
        IsReceived.Text = 0
        lblIDListaDetalle.Text = ""
        DgvArticulos.Rows.Clear()
        Hora.Enabled = True
        txtDescripcion.Focus()
    End Sub

    Private Sub LiberarDgvArticulos()
        Try
            If DgvArticulos.Columns.Count = 0 Then
                DgvArticulos.DataSource = Nothing
                DgvArticulos.Rows.Clear()
                ColumnasDgvArticulos()
                PropiedadesDgvArticulos()
            Else
                DgvArticulos.DataSource = Nothing
                DgvArticulos.Rows.Clear()
                DgvArticulos.Columns.Clear()
                ColumnasDgvArticulos()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "Desde LiberarDgvArticulos")
        End Try
    End Sub

    Private Sub LimpiarDatos()
        txtDescripcion.Clear()
        txtFecha.Clear()
        txtSecondID.Clear()
        txtHora.Clear()
        txtIDListado.Clear()
        CbxMedida.Items.Clear()
        txtTotal.Clear()
        LimpiarTextInsert()
    End Sub

    Private Sub ConvertDouble()
        txtTotal.Text = CDbl(txtTotal.Text)
    End Sub

    Private Sub ConvertCurrent()
        txtTotal.Text = CDbl(txtTotal.Text).ToString("C")
    End Sub

    Private Sub UltListado()
        Try
            If txtIDListado.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDListaArticulos from ListasArticulos where IDListaArticulos= (Select Max(IDListaArticulos) from ListasArticulos)", Con)
                txtIDListado.Text = Convert.ToDouble(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car
            Case 8
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select
    End Sub

    Private Sub ImprimirDocumento()
        If txtIDListado.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que sea desea imprimir el listado de productos?", "Imprimir Listado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub InsertArticulos()
        For Each rw As DataGridViewRow In DgvArticulos.Rows
            If CStr(rw.Cells(0).Value) = "" Then
                sqlQ = "INSERT INTO ListadoArticulosDetalle (IDListadoArticulo,IDArticulo,Descripcion,IDPrecio,IDMedida,Medida,Cantidad,Precio,Importe,Recibido) VALUES ('" + txtIDListado.Text + "','" + rw.Cells(2).Value.ToString + "','" + rw.Cells(3).Value.ToString + "','" + rw.Cells(4).Value.ToString + "','" + rw.Cells(5).Value.ToString + "','" + rw.Cells(6).Value.ToString + "','" + rw.Cells(7).Value.ToString + "','" + CDbl(rw.Cells(8).Value).ToString + "','" + CDbl(rw.Cells(9).Value).ToString + "','" + rw.Cells(13).Value.ToString + "')"
                GuardarDatos()
            Else
                sqlQ = "UPDATE " & "ListadoArticulosDetalle SET IDListadoArticulo='" + txtIDListado.Text + "',IDArticulo='" + rw.Cells(2).Value.ToString + "',Descripcion='" + rw.Cells(3).Value.ToString + "',IDPrecio='" + rw.Cells(4).Value.ToString + "',IDMedida='" + rw.Cells(5).Value.ToString + "',Medida='" + rw.Cells(6).Value.ToString + "',Cantidad='" + rw.Cells(7).Value.ToString + "',Precio='" + CDbl(rw.Cells(8).Value).ToString + "',Importe='" + CDbl(rw.Cells(9).Value).ToString + "',Recibido='" + rw.Cells(13).Value.ToString + "' WHERE IDListadoArticulosDetalle='" + rw.Cells(0).Value.ToString + "'"
                GuardarDatos()
            End If
        Next

        RefrescarTablaArticulos()
    End Sub

    Sub SumTotal()
        Dim x As Integer = 0
        Dim Importe As Double = 0

Inicio:
        If x = DgvArticulos.Rows.Count Then
            GoTo Final
        Else
            Importe = (Importe + CDbl(DgvArticulos.Rows(x).Cells(9).Value))
            x = x + 1
            GoTo Inicio
        End If
Final:
        txtTotal.Text = (Importe).ToString("C")

    End Sub

    Sub RefrescarTablaArticulos()

        Try
            If txtIDListado.Text = "" Then
            Else
                DgvArticulos.Rows.Clear()
                Con.Open()
                Dim Consulta As New MySqlCommand("Select IDListadoArticulosDetalle,IDListadoArticulo,ListadoArticulosDetalle.IDArticulo,Articulos.Descripcion,ListadoArticulosDetalle.IDPrecio,ListadoArticulosDetalle.IDMedida,Medida.Medida,ListadoArticulosDetalle.Cantidad,ListadoArticulosDetalle.Precio,ListadoArticulosDetalle.Importe,Articulos.RutaFoto,Articulos.IDSuplidor,Suplidor.Suplidor,Recibido FROM ListadoArticulosDetalle INNER JOIN Libregco.Articulos on ListadoArticulosDetalle.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Suplidor on Articulos.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.Medida on ListadoArticulosDetalle.IDMedida=Medida.IDMedida Where IDListadoArticulo='" + txtIDListado.Text + "' and Recibido<>1", Con)
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

                    DgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9), ProductImage, LectorArticulos.GetValue(11), LectorArticulos.GetValue(12).ToString.ToUpper, LectorArticulos.GetValue(13))

                End While
                LectorArticulos.Close()
                Con.Close()

                PropiedadesDgvArticulos()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub txtPrecio_Enter(sender As Object, e As EventArgs) Handles txtPrecio.Enter
        If txtPrecio.Text = "" Then
            txtPrecio.Text = CDbl(0).ToString("C")
        Else
            txtPrecio.Text = CDbl(txtPrecio.Text)
        End If

    End Sub

    Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
        If txtPrecio.Text = "" Then
            txtPrecio.Text = CDbl(0).ToString("C")
        Else
            txtPrecio.Text = CDbl(txtPrecio.Text).ToString("C")
        End If
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub LimpiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarToolStripMenuItem.Click
        btnBlanquear.PerformClick()
    End Sub

    Private Sub QuitarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem.Click
        btnQuitarArticulo.PerformClick()
    End Sub

    Private Sub ModificarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem.Click
        btnModificar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub btnBlanquear_Click(sender As Object, e As EventArgs) Handles btnBlanquear.Click
        Try
            If DgvArticulos.Rows.Count = 0 Then
                MessageBox.Show("No hay productos para eliminar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDListado.Text = "" And DgvArticulos.Rows.Count >= 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea limpiar todos los registros insertados?", "Blanquear Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    DgvArticulos.Rows.Clear()
                    SumTotal()
                    Exit Sub
                End If
            End If

            If txtIDListado.Text > 0 And DgvArticulos.Rows.Count >= 1 Then
                MessageBox.Show("No se pueden eliminar todos los artículos ya insertados a través de esta función." & vbNewLine & "Para proceder a la eliminación de artículos utilice la función F2-Quitar Artículos.", "Función No Habilitada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnQuitarArticulo_Click(sender As Object, e As EventArgs) Handles btnQuitarArticulo.Click
        Try
            Dim Counter = DgvArticulos.Rows.Count

            If Counter >= 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo [" & DgvArticulos.CurrentRow.Cells(3).Value & "] del listado?", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    EliminarArticulo()
                    DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)
                    SumTotal()
                End If
            Else
                MessageBox.Show("No hay articulos para eliminar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            Dim Counter As Integer = DgvArticulos.Rows.Count

            If Counter > 0 Then
                lblIDListaDetalle.Text = DgvArticulos.CurrentRow.Cells(0).Value
                txtIDArticulo.Text = DgvArticulos.CurrentRow.Cells(2).Value
                FillMedida()
                CbxMedida.Text = DgvArticulos.CurrentRow.Cells(6).Value
                lblIDMedida.Text = DgvArticulos.CurrentRow.Cells(5).Value
                txtCantidadArticulo.Text = DgvArticulos.CurrentRow.Cells(7).Value
                txtDescripcionArticulo.Text = DgvArticulos.CurrentRow.Cells(3).Value
                txtPrecio.Text = CDbl(DgvArticulos.CurrentRow.Cells(8).Value).ToString("C")
                txtPrecio.Focus()
                ProductImage = DgvArticulos.CurrentRow.Cells(10).Value
                IsReceived.Text = DgvArticulos.CurrentRow.Cells(13).Value

                DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)
                SumTotal()
            Else
                MessageBox.Show("No hay artículos para modificar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnBuscarArticulo_Click(sender As Object, e As EventArgs) Handles btnBuscarArticulo.Click
        frm_buscar_mant_articulos.Show(Me)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
        LiberarDgvArticulos()
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=38", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE ListasArticulos SET SecondID='" + lblSecondID.Text + "' WHERE IDListaArticulos='" + txtIDListado.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=38"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Haga una breve descripción de la lista de productos.", "Descripción de Lista de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf DgvArticulos.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado artículos para procesar el listado de artículos.", "No hay artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDListado.Text = "" Then 'Si no hay ajuste
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el nuevo listado de productos en la base de datos?", "Guardar Listado de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO ListasArticulos (IDTipoDocumento,IDUsuario,Fecha,Hora,IDSucursal,IDAlmacen,Descripcion,Total,Nulo) VALUES (38,'" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + txtDescripcion.Text + "','" + txtTotal.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltListado()
                SetSecondID()
                InsertArticulos()
                DesHabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la nota de pedido?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE ListasArticulos SET IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',Descripcion='" + txtDescripcion.Text + "',Total='" + txtTotal.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDListaArticulos= (" + txtIDListado.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertArticulos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub txtIDArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIDArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtIDArticulo.Text <> "" Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtIDArticulo.Text <> "" Then
                If txtIDArticulo.SelectionStart = txtIDArticulo.TextLength Then
                    e.Handled = True
                    CbxMedida.Focus()
                    CbxMedida.DroppedDown = True
                End If
            End If
        End If
    End Sub

    Private Sub txtCantidadArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            If txtCantidadArticulo.SelectionStart = 0 Then
                txtIDArticulo.Focus()
                txtIDArticulo.SelectAll()
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtCantidadArticulo.SelectionStart = txtCantidadArticulo.TextLength Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If

        ElseIf e.KeyCode = Keys.Up Then
            txtCantidadArticulo.Text = CDbl(txtCantidadArticulo.Text) + 1
            txtCantidadArticulo.SelectAll()

        ElseIf e.KeyCode = Keys.Down Then
            If CDbl(txtCantidadArticulo.Text) > 1 Then
                txtCantidadArticulo.Text = CDbl(txtCantidadArticulo.Text) - 1
                txtCantidadArticulo.SelectAll()
            End If

        End If
    End Sub

    Private Sub CbxMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxMedida.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Right Then
            e.Handled = True
            SendKeys.Send("{TAB}")

        ElseIf e.KeyCode = Keys.Left Then
            e.Handled = True
            txtCantidadArticulo.Focus()
            txtCantidadArticulo.SelectAll()

        End If
    End Sub

    Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")


        ElseIf e.KeyCode = Keys.Left Then
            If txtPrecio.SelectionStart = 0 Then
                CbxMedida.Focus()
                CbxMedida.DroppedDown = True
            End If

        ElseIf e.KeyCode = Keys.Right Then
            If txtPrecio.SelectionStart = txtPrecio.TextLength Then
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If txtIDArticulo.Focused = False Then
            txtIDArticulo.Focus()
        Else
            txtIDArticulo.Focus()

            btnBuscarArticulo.PerformClick()
        End If
    End Sub

    Private Sub DgvArticulos_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvArticulos.CellMouseUp
        If e.RowIndex >= 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                DgvArticulos.Rows(e.RowIndex).Selected = True
                DgvArticulos.CurrentCell = DgvArticulos.Rows(e.RowIndex).Cells(6)
                CMenuProducts.Show(DgvArticulos, e.Location)
                CMenuProducts.Show(Cursor.Position)
            End If


        End If
    End Sub

    Private Sub IrAArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IrAArtículosToolStripMenuItem.Click
        If frm_mant_articulos.Visible = True Then
            frm_mant_articulos.Close()
        End If

        frm_mant_articulos.Show(Me)
        frm_mant_articulos.txtIDProducto.Text = DgvArticulos.CurrentRow.Cells(2).Value
        frm_mant_articulos.FillAllDatafromID()
    End Sub

    Private Sub ModificarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem1.Click
        btnModificar.PerformClick()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frm_articulosnocomprados_listados.ShowDialog(Me)
    End Sub

    Private Sub MarcarNoRecibidoNoCompradoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcarNoRecibidoNoCompradoToolStripMenuItem.Click
        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea marcar este producto como NO recibido?", "Guardar como NO recibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            sqlQ = "UPDATE" & SysName.Text & "ListadoArticulosDetalle SET Recibido=0 where IDListadoArticulosDetalle='" + DgvArticulos.CurrentRow.Cells(0).Value.ToString + "'"
            ConMixta.Open()
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
            ConMixta.Close()

            DgvArticulos.CurrentRow.InheritedStyle.BackColor = SystemColors.Info

            MessageBox.Show("El artículo se ha marcado como NO recibido satisfactoriamente.", "Marcado como NO recibido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub MarcarComoRecibidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcarComoRecibidoToolStripMenuItem.Click
        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea marcar este producto como recibido?", "Guardar como recibido", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            sqlQ = "UPDATE" & SysName.Text & "ListadoArticulosDetalle SET Recibido=1 where IDListadoArticulosDetalle='" + DgvArticulos.CurrentRow.Cells(0).Value.ToString + "'"
            ConMixta.Open()
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
            ConMixta.Close()

            DgvArticulos.CurrentRow.Cells(14).Style.BackColor = Color.LightGray
            DgvArticulos.CurrentRow.Cells(15).Style.BackColor = Color.LightGray
            DgvArticulos.CurrentRow.Cells(15).Value = "Recibido"
            DgvArticulos.CurrentRow.Cells(14).Value = ChrW(254)

            MessageBox.Show("El artículo se ha marcado como recibido satisfactoriamente.", "Marcado como recibido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            DgvArticulos.Rows.Remove(DgvArticulos.CurrentRow)
        End If
    End Sub

    Private Sub PedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidoToolStripMenuItem.Click
        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea marcar este producto como pedido / en trásito?", "Guardar como en tránsito", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            sqlQ = "UPDATE" & SysName.Text & "ListadoArticulosDetalle SET Recibido=2 where IDListadoArticulosDetalle='" + DgvArticulos.CurrentRow.Cells(0).Value.ToString + "'"
            ConMixta.Open()
            cmd = New MySqlCommand(sqlQ, ConMixta)
            cmd.ExecuteNonQuery()
            ConMixta.Close()

            DgvArticulos.CurrentRow.Cells(14).Style.BackColor = Color.LightBlue
            DgvArticulos.CurrentRow.Cells(15).Style.BackColor = Color.LightBlue
            DgvArticulos.CurrentRow.Cells(15).Value = "En tránsito"
            DgvArticulos.CurrentRow.Cells(14).Value = ChrW(220)

            MessageBox.Show("El artículo se ha marcado como en tránsito satisfactoriamente.", "Marcado como tránsito", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub DgvArticulos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DgvArticulos.RowsAdded
        If DgvArticulos.Rows(e.RowIndex).Cells(13).Value = "1" Then
            DgvArticulos.Rows(e.RowIndex).Cells(14).Style.BackColor = Color.LightGray
            DgvArticulos.Rows(e.RowIndex).Cells(15).Style.BackColor = Color.LightGray
            DgvArticulos.Rows(e.RowIndex).Cells(15).Value = "Recibido"
            DgvArticulos.Rows(e.RowIndex).Cells(14).Value = ChrW(254)

        ElseIf DgvArticulos.Rows(e.RowIndex).Cells(13).Value = "2" Then
            DgvArticulos.Rows(e.RowIndex).Cells(14).Style.BackColor = Color.LightBlue
            DgvArticulos.Rows(e.RowIndex).Cells(15).Style.BackColor = Color.LightBlue
            DgvArticulos.Rows(e.RowIndex).Cells(15).Value = "En tránsito"
            DgvArticulos.Rows(e.RowIndex).Cells(14).Value = ChrW(220)

        ElseIf DgvArticulos.Rows(e.RowIndex).Cells(13).Value = "0" Then
            DgvArticulos.Rows(e.RowIndex).Cells(14).Style.BackColor = SystemColors.Info
            DgvArticulos.Rows(e.RowIndex).Cells(15).Style.BackColor = SystemColors.Info
            DgvArticulos.Rows(e.RowIndex).Cells(15).Value = "No solicitado"
            DgvArticulos.Rows(e.RowIndex).Cells(14).Value = ChrW(168)
        End If
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Haga una breve descripción de la lista de productos.", "Descripción de Lista de Productos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescripcion.Focus()
            Exit Sub
        ElseIf DgvArticulos.Rows.Count = 0 Then
            MessageBox.Show("No se han encontrado artículos para procesar el listado de artículos.", "No hay artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If txtIDListado.Text = "" Then 'Si no hay ajuste
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el nuevo listado de productos en la base de datos?", "Guardar Listado de Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO ListasArticulos (IDTipoDocumento,IDUsuario,Fecha,Hora,IDSucursal,IDAlmacen,Descripcion,Total,Nulo) VALUES (38,'" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + txtDescripcion.Text + "','" + txtTotal.Text + "','" + lblNulo.Text + "')"
                GuardarDatos()
                ConvertCurrent()
                UltListado()
                SetSecondID()
                InsertArticulos()
                DesHabilitarControles()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en la nota de pedido?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE ListasArticulos SET IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',Descripcion='" + txtDescripcion.Text + "',Total='" + txtTotal.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDListaArticulos= (" + txtIDListado.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                InsertArticulos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                LimpiarDatos()
                ActualizarTodo()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_listados_articulos.Show(Me)
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        ImprimirDocumento()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If ChkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El registro del listado No. " & txtIDListado.Text & " ya está anulado en el sistema. Desea activarla?", "Recuperar Listado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                ChkNulo.Checked = False
                ConvertDouble()
                sqlQ = "UPDATE ListasArticulos SET IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',Descripcion='" + txtDescripcion.Text + "',Total='" + txtTotal.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDListaArticulos= (" + txtIDListado.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDListado.Text = "" Then
            MessageBox.Show("No hay un registro de listado de articulos abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el registro de listado de artículos No. " & txtIDListado.Text & " del sistema?", "Anular Listado de Artículos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ChkNulo.Checked = True
                ConvertDouble()
                sqlQ = "UPDATE ListasArticulos SET IDUsuario='" + lblIDUsuario.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',Descripcion='" + txtDescripcion.Text + "',Total='" + txtTotal.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDListaArticulos= (" + txtIDListado.Text + ")"
                GuardarDatos()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub frm_listado_articulos_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadesDgvArticulos()
    End Sub
End Class