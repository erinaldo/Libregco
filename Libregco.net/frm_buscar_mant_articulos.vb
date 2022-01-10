Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid

Public Class frm_buscar_mant_articulos
    Dim sqlQ As String = ""
    Dim cmd, cmd1 As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds2, Ds3 As New DataSet 'Para mantener los dataviewgrids
    Dim Ds1 As New DataSet 'Para Operaciones al llenarformularios

    Private Sub frm_buscar_mant_articulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        DgvArticulos.MultiSelect = False
        'Me.WindowState = CheckWindowState()
        TabMenus.Location = New Point(-8, -26)
        TabMenus.Size = New Size(1026, 667)
        TabMenus.SelectedIndex = 0
        btnFiltrar.Visible = True
        btnEspecificaciones.Visible = True
        btnImagenes.Visible = True
        BindingNavigatorSeparator2.Visible = True
        ToolStripSeparator2.Visible = True
        VistaTabla.Image = My.Resources.listvieworange
        VistaDinamica.Image = My.Resources.imageviewgray
        OptionVisibleBingingNavigator()
        TabArticulos.SelectedIndex = 0
        CargarEmpresa()
        LimpiarDgvSelection()
        LimpiartxtBuscar()
        PicImagen.Image = Nothing
        RefrescarTablaArticulos()
        PropiedadColumnsDvg()
        RefrescarTablaPrecios()
        PropiedadColumnsPrecioDgv()
        RefrescarTablaExistencia()
        PropiedadColumnsExistencia()
        TabClasico.SelectedIndex = 0
        txtIDSuplidor.Clear()
        txtSuplidor.Clear()
        txtIDTipo.Clear()
        txtTipo.Clear()
        txtIDDepartamento.Clear()
        txtDepartamento.Clear()
        txtIDCategoria.Clear()
        txtCategoria.Clear()
        txtIDSubCategoria.Clear()
        txtSubcategoria.Clear()
        txtIDMarca.Clear()
        txtMarca.Clear()
        FlowCategorias.Controls.Clear()
        FlowSubCategoria.Controls.Clear()
        ListControl1.Clear()
        RefrescarTablaArticulos()
        FillDepartments()
        FillPropiedades()

        If DTConfiguracion.Rows(194 - 1).Item("Value2Int") = "0" Then
            rdbDirecto.Checked = True
        Else
            rdbPredictivo.Checked = True
        End If

        txtBuscar.Focus()
    End Sub

    Private Sub FillPropiedades()
        Try
            TKPropiedades.Properties.Tokens.Clear()

            Dim dstemp As New DataSet

            Con.Open()
            cmd = New MySqlCommand("SELECT idArticulos_propiedad,Propiedad FROM libregco.articulos_propiedad where Nulo=0 and IDParent is not null ORDER BY IDParent ASC,Orden ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(dstemp, "articulos_propiedad")
            Con.Close()

            Dim Tabla As DataTable = dstemp.Tables("articulos_propiedad")

            For Each Fila As DataRow In Tabla.Rows
                Dim Tk As New DevExpress.XtraEditors.TokenEditToken

                Tk.Value = Fila.Item("idArticulos_propiedad")
                Tk.Description = Fila.Item("Propiedad")

                TKPropiedades.Properties.Tokens.Add(Tk)
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Function GetSqlQuery(ByVal St As String) As String
        St.Replace("'", "")

        If rdbPredictivo.Checked = True Then

            If St = "" Then
                Return "SELECT IDArticulo,Descripcion,Referencia,CodigoBarra,ExistenciaTotal,Articulos.RutaFoto,(SELECT coalesce(group_concat(IDPropiedad_propiedad separator ', '),'') FROM libregco.articulos_has_propiedad inner join libregco.articulos_propiedad on articulos_has_propiedad.IDPropiedad_propiedad=articulos_propiedad.idArticulos_propiedad WHERE Articulos_has_propiedad.IDArticulo=Articulos.IDArticulo) as Propiedades FROM Libregco.Articulos where (IDArticulo like '%" + St + "%' or Descripcion like '%" + St + "%' or Referencia like '%" + St + "%' or CodigoBarra like '%" + St + "%') AND IF('" + txtIDSuplidor.Text + "'='',true,IDSuplidor='" + txtIDSuplidor.Text + "') and IF('" + txtIDTipo.Text + "'='',true,IDTipoProducto='" + txtIDTipo.Text + "')  and IF('" + txtIDDepartamento.Text + "'='',true,IDDepartamento='" + txtIDDepartamento.Text + "') and IF('" + txtIDCategoria.Text + "'='',true,IDCategoria='" + txtIDCategoria.Text + "') and IF('" + txtIDSubCategoria.Text + "'='',true,IDSubCategoria='" + txtIDSubCategoria.Text + "')  and IF('" + txtIDMarca.Text + "'='',true,IDMarca='" + txtIDMarca.Text + "') and Articulos.Desactivar=0  " & If(CInt(DTConfiguracion.Rows(217 - 1).Item("Value2Int")) = 1, If(Me.Owner.Name = frm_prefacturacion.Name Or Me.Owner.Name = frm_facturacion.Name, " and Articulos.VecesVendido>0 and Articulos.VecesComprado>0", ""), "") & " ORDER BY Descripcion ASC LIMIT " & DTConfiguracion.Rows(28 - 1).Item("Value2Int").ToString

            ElseIf St.Contains("%") Then

                Return "SELECT IDArticulo,Descripcion,Referencia,CodigoBarra,ExistenciaTotal,Articulos.RutaFoto,(SELECT coalesce(group_concat(IDPropiedad_propiedad separator ', '),'') FROM libregco.articulos_has_propiedad inner join libregco.articulos_propiedad on articulos_has_propiedad.IDPropiedad_propiedad=articulos_propiedad.idArticulos_propiedad WHERE Articulos_has_propiedad.IDArticulo=Articulos.IDArticulo) as Propiedades FROM Libregco.Articulos where (IDArticulo like '%" + St + "%' or Descripcion like '%" + St + "%' or Referencia like '%" + St + "%' or CodigoBarra like '%" + St + "%') AND IF('" + txtIDSuplidor.Text + "'='',true,IDSuplidor='" + txtIDSuplidor.Text + "') and IF('" + txtIDTipo.Text + "'='',true,IDTipoProducto='" + txtIDTipo.Text + "')  and IF('" + txtIDDepartamento.Text + "'='',true,IDDepartamento='" + txtIDDepartamento.Text + "') and IF('" + txtIDCategoria.Text + "'='',true,IDCategoria='" + txtIDCategoria.Text + "') and IF('" + txtIDSubCategoria.Text + "'='',true,IDSubCategoria='" + txtIDSubCategoria.Text + "')  and IF('" + txtIDMarca.Text + "'='',true,IDMarca='" + txtIDMarca.Text + "') and Articulos.Desactivar=0 " & If(CInt(DTConfiguracion.Rows(217 - 1).Item("Value2Int")) = 1, If(Me.Owner.Name = frm_prefacturacion.Name Or Me.Owner.Name = frm_facturacion.Name, " and Articulos.VecesVendido>0 and Articulos.VecesComprado>0", ""), "") & " ORDER BY Descripcion ASC LIMIT " & DTConfiguracion.Rows(28 - 1).Item("Value2Int").ToString
            Else

                Dim words As String() = St.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
                Dim DinamicPart1 As String = "SELECT IDArticulo,Descripcion,Referencia,CodigoBarra,ExistenciaTotal,Articulos.RutaFoto,(SELECT coalesce(group_concat(IDPropiedad_propiedad separator ', '),'') FROM libregco.articulos_has_propiedad inner join libregco.articulos_propiedad on articulos_has_propiedad.IDPropiedad_propiedad=articulos_propiedad.idArticulos_propiedad WHERE Articulos_has_propiedad.IDArticulo=Articulos.IDArticulo) as Propiedades,("
                Dim DinamicPart2 As String
                Dim Counter As Integer = 0

                For Each word As String In words
                    If words.Count - 1 > Counter Then
                        DinamicPart1 = DinamicPart1 & "(Descripcion LIKE '%" & word & "%') + " & "(Referencia LIKE '%" & word & "%') + " & "(CodigoBarra LIKE '%" & word & "%') + " & "(IDArticulo LIKE '%" & word & "%') + "
                        DinamicPart2 = DinamicPart2 & " Descripcion LIKE '%" & word & "%' OR" & " Referencia LIKE '%" & word & "%' OR" & " CodigoBarra LIKE '%" & word & "%' OR" & " IDArticulo LIKE '%" & word & "%' OR"
                    Else
                        DinamicPart1 = DinamicPart1 & "(Descripcion LIKE '%" & word & "%') + (Referencia LIKE '%" & word & "%') + (CodigoBarra LIKE '%" & word & "%') + (IDArticulo LIKE '%" & word & "%') "
                        DinamicPart2 = DinamicPart2 & " Descripcion Like '%" & word & "%' OR Referencia Like '%" & word & "%' OR CodigoBarra Like '%" & word & "%' OR IDArticulo Like '%" & word & "%' "
                    End If
                    Counter += 1
                Next

                DinamicPart1 = DinamicPart1 & ") as Results FROM Libregco.Articulos WHERE (" & DinamicPart2 & " ) AND IF('" + txtIDSuplidor.Text + "'='',true,IDSuplidor='" + txtIDSuplidor.Text + "') and IF('" + txtIDTipo.Text + "'='',true,IDTipoProducto='" + txtIDTipo.Text + "')  and IF('" + txtIDDepartamento.Text + "'='',true,IDDepartamento='" + txtIDDepartamento.Text + "') and IF('" + txtIDCategoria.Text + "'='',true,IDCategoria='" + txtIDCategoria.Text + "') and IF('" + txtIDSubCategoria.Text + "'='',true,IDSubCategoria='" + txtIDSubCategoria.Text + "')  and IF('" + txtIDMarca.Text + "'='',true,IDMarca='" + txtIDMarca.Text + "') and Articulos.Desactivar=0 " & If(CInt(DTConfiguracion.Rows(217 - 1).Item("Value2Int")) = 1, If(Me.Owner.Name = frm_prefacturacion.Name Or Me.Owner.Name = frm_facturacion.Name, " and Articulos.VecesVendido>0 and Articulos.VecesComprado>0", ""), "") & " ORDER BY Results DESC LIMIT " & DTConfiguracion.Rows(28 - 1).Item("Value2Int").ToString

                Return DinamicPart1

            End If
        Else
            If IsNumeric(St) Then
                Return "SELECT IDArticulo,Descripcion,Referencia,CodigoBarra,ExistenciaTotal,Articulos.RutaFoto,(SELECT coalesce(group_concat(IDPropiedad_propiedad separator ', '),'') FROM libregco.articulos_has_propiedad inner join libregco.articulos_propiedad on articulos_has_propiedad.IDPropiedad_propiedad=articulos_propiedad.idArticulos_propiedad WHERE Articulos_has_propiedad.IDArticulo=Articulos.IDArticulo) as Propiedades FROM Libregco.Articulos where (IDArticulo like '%" + St + "%' or Referencia like '%" + St + "%' or CodigoBarra like '%" + St + "%') AND IF('" + txtIDSuplidor.Text + "'='',true,IDSuplidor='" + txtIDSuplidor.Text + "') and IF('" + txtIDTipo.Text + "'='',true,IDTipoProducto='" + txtIDTipo.Text + "')  and IF('" + txtIDDepartamento.Text + "'='',true,IDDepartamento='" + txtIDDepartamento.Text + "') and IF('" + txtIDCategoria.Text + "'='',true,IDCategoria='" + txtIDCategoria.Text + "') and IF('" + txtIDSubCategoria.Text + "'='',true,IDSubCategoria='" + txtIDSubCategoria.Text + "')  and IF('" + txtIDMarca.Text + "'='',true,IDMarca='" + txtIDMarca.Text + "') and Articulos.Desactivar=0  " & If(CInt(DTConfiguracion.Rows(217 - 1).Item("Value2Int")) = 1, If(Me.Owner.Name = frm_prefacturacion.Name Or Me.Owner.Name = frm_facturacion.Name, " and Articulos.VecesVendido>0 and Articulos.VecesComprado>0", ""), "") & " ORDER BY IDArticulo DESC LIMIT " & DTConfiguracion.Rows(28 - 1).Item("Value2Int").ToString
            Else
                Return "SELECT IDArticulo,Descripcion,Referencia,CodigoBarra,ExistenciaTotal,Articulos.RutaFoto,(SELECT coalesce(group_concat(IDPropiedad_propiedad separator ', '),'') FROM libregco.articulos_has_propiedad inner join libregco.articulos_propiedad on articulos_has_propiedad.IDPropiedad_propiedad=articulos_propiedad.idArticulos_propiedad WHERE Articulos_has_propiedad.IDArticulo=Articulos.IDArticulo) as Propiedades FROM Libregco.Articulos where (IDArticulo like '%" + St + "%' or Descripcion like '%" + St + "%' or Referencia like '%" + St + "%' or CodigoBarra like '%" + St + "%') AND IF('" + txtIDSuplidor.Text + "'='',true,IDSuplidor='" + txtIDSuplidor.Text + "') and IF('" + txtIDTipo.Text + "'='',true,IDTipoProducto='" + txtIDTipo.Text + "')  and IF('" + txtIDDepartamento.Text + "'='',true,IDDepartamento='" + txtIDDepartamento.Text + "') and IF('" + txtIDCategoria.Text + "'='',true,IDCategoria='" + txtIDCategoria.Text + "') and IF('" + txtIDSubCategoria.Text + "'='',true,IDSubCategoria='" + txtIDSubCategoria.Text + "')  and IF('" + txtIDMarca.Text + "'='',true,IDMarca='" + txtIDMarca.Text + "') and Articulos.Desactivar=0  " & If(CInt(DTConfiguracion.Rows(217 - 1).Item("Value2Int")) = 1, If(Me.Owner.Name = frm_prefacturacion.Name Or Me.Owner.Name = frm_facturacion.Name, " and Articulos.VecesVendido>0 and Articulos.VecesComprado>0", ""), "") & " ORDER BY Descripcion ASC LIMIT " & DTConfiguracion.Rows(28 - 1).Item("Value2Int").ToString
            End If
        End If

        'Mejorar esta consulta para busquedas exactas en el metodo predictivo

    End Function


    Sub RefrescarTablaArticulos()
        'Try
        Dim Bs As New BindingSource
        cmd = New MySqlCommand(GetSqlQuery(CStr(txtBuscar.Text).Replace("'", "")), ConLibregco)
        Ds.Clear()
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Articulos")

        Bs.DataMember = "Articulos"
        Bs.DataSource = Ds
        BindingNavigator.BindingSource = Bs
        DgvArticulos.DataSource = Bs
        PropiedadColumnsDvg()

        txtBuscar.Focus()

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Sub RefrescarTablaPrecios()
        Try

            Dim IDArticulo As String
            Dim ConTmp As New MySqlConnection(CnString)

            If DgvArticulos.SelectedRows.Count > 0 Then
                IDArticulo = DgvArticulos.CurrentRow.Cells(0).Value

                DgvPrecioArticulo.Rows.Clear()

                ConTmp.Open()
                Dim con2sulta As New MySqlCommand("SELECT IDPrecios,medida.Medida,contenido,PrecioCredito,Preciocontado,Precio3,Precio4,Costo,CostoFinal,PrecioArticulo.IDMoneda FROM PrecioArticulo INNER JOIN Medida ON PrecioArticulo.IDMedida=Medida.IDMedida WHERE IDArticulo='" + IDArticulo + "' AND Nulo=0", ConTmp)
                Dim LectorPrecios As MySqlDataReader = con2sulta.ExecuteReader

                While LectorPrecios.Read
                    DgvPrecioArticulo.Rows.Add(LectorPrecios.GetValue(0), LectorPrecios.GetValue(1), LectorPrecios.GetValue(2), LectorPrecios.GetValue(3), LectorPrecios.GetValue(4), LectorPrecios.GetValue(5), LectorPrecios.GetValue(6), LectorPrecios.GetValue(7), LectorPrecios.GetValue(8), LectorPrecios.GetValue(9))
                End While
                LectorPrecios.Close()
                ConTmp.Close()

                DgvPrecioArticulo.ClearSelection()
            Else
                If DgvArticulos.Rows.Count = 0 Then
                    DgvPrecioArticulo.Rows.Clear()
                End If

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub PropiedadColumnsPrecioDgv()
        Try
            If DgvPrecioArticulo.Rows.Count > 0 Then
                Dim DatagridWidth As Double = (DgvPrecioArticulo.Width - DgvPrecioArticulo.RowHeadersWidth) / 100

                With DgvPrecioArticulo
                    .Columns(0).Visible = False

                    .Columns(1).Width = DatagridWidth * 25
                    .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(2).Width = DatagridWidth * 15

                    .Columns(5).Visible = False
                    .Columns(6).Visible = False

                    .Columns(3).HeaderText = "Precio A"
                    .Columns(4).HeaderText = "Precio B"
                    .Columns(8).HeaderText = "Costo final"

                    If Me.Owner.Name = frm_registro_compras.Name Then
                        .Columns(3).Visible = False
                        .Columns(4).Visible = False
                        .Columns(7).Visible = True
                        .Columns(8).Visible = True

                        .Columns(7).Width = DatagridWidth * 30
                        .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns(7).DefaultCellStyle.BackColor = Color.LightGray
                        .Columns(7).DefaultCellStyle.Format = ("C")

                        .Columns(8).Width = DatagridWidth * 30
                        .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns(8).DefaultCellStyle.BackColor = Color.LightGray
                        .Columns(8).DefaultCellStyle.Format = ("C")

                    Else
                        .Columns(3).Visible = True
                        .Columns(4).Visible = True

                        .Columns(3).Width = DatagridWidth * 30
                        .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns(3).DefaultCellStyle.BackColor = Color.LightGray
                        .Columns(3).DefaultCellStyle.Format = ("C")

                        .Columns(4).Width = DatagridWidth * 30
                        .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Columns(4).DefaultCellStyle.BackColor = Color.LightGray
                        .Columns(4).DefaultCellStyle.Format = ("C")

                        .Columns(7).Visible = False
                        .Columns(8).Visible = False
                    End If

                End With

                DgvPrecioArticulo.ClearSelection()
            End If


        Catch ex As Exception
        End Try
    End Sub

    Sub RefrescarTablaExistencia()
        Try
            Dim IDArticulo As String

            Dim cmdTemp As New MySqlCommand

            If DgvArticulos.SelectedRows.Count > 0 Then
                IDArticulo = DgvArticulos.CurrentRow.Cells(0).Value

                DgvExistencia.Rows.Clear()

                If ConTemporal.State = ConnectionState.Open Then
                    ConTemporal.Close()
                End If

                ConTemporal.Open()

                If DTEmpleado.Rows(0).Item("IDSucursal").ToString = "" Then
                    cmdTemp = New MySqlCommand("SELECT Almacen.IDAlmacen,Almacen.Almacen,Sum(Existencia) FROM Libregco.Existencia INNER JOIN" & SysName.Text & "Almacen on Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios Where PrecioArticulo.IDArticulo= '" + IDArticulo + "' and Almacen.Desactivar=0 Group BY Almacen.IDAlmacen", ConTemporal)
                Else
                    cmdTemp = New MySqlCommand("SELECT Almacen.IDAlmacen,Almacen.Almacen,Sum(Existencia) FROM Libregco.Existencia INNER JOIN" & SysName.Text & "Almacen on Existencia.IDAlmacen=Almacen.IDAlmacen INNER JOIN Libregco.PrecioArticulo on Existencia.IDPrecioArticulo=PrecioArticulo.IDPrecios Where PrecioArticulo.IDArticulo= '" + IDArticulo + "' and Almacen.Desactivar=0 and Almacen.IDSucursal='" + DTEmpleado.Rows(0).Item("IDSucursal").ToString + "' Group BY Almacen.IDAlmacen", ConTemporal)
                End If

                    Dim LectorExistencia As MySqlDataReader = cmdTemp.ExecuteReader

                    While LectorExistencia.Read
                        DgvExistencia.Rows.Add(LectorExistencia.GetValue(0), LectorExistencia.GetValue(1), LectorExistencia.GetValue(2))
                    End While
                    LectorExistencia.Close()
                    ConTemporal.Close()

                    DgvExistencia.ClearSelection()
                Else
                    If DgvArticulos.Rows.Count = 0 Then
                    DgvExistencia.Rows.Clear()
                End If
            End If


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub PropiedadColumnsDvg()
        Try
            If DgvArticulos.Rows.Count > 0 Then
                Dim DatagridWidth As Double = (DgvArticulos.Width - DgvArticulos.RowHeadersWidth) / 100

                With DgvArticulos
                    .Columns(0).HeaderText = "Código"
                    .Columns(0).Width = DatagridWidth * 10
                    .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Columns(1).HeaderText = "Descripción"
                    .Columns(1).Width = DatagridWidth * 60
                    .Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    .Columns(2).Width = DatagridWidth * 15
                    .Columns(3).Visible = False
                    .Columns(4).Width = DatagridWidth * 15
                    .Columns(4).HeaderText = "Existencia"
                    .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns(5).Visible = False
                    .Columns(6).Visible = False
                    .Columns(7).Visible = False
                End With
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub PropiedadColumnsExistencia()
        Try
            Dim DatagridWidth As Double = (DgvExistencia.Width - DgvExistencia.RowHeadersWidth) / 100

            With DgvExistencia
                .Columns(0).Visible = False
                .Columns(1).Width = DatagridWidth * 65
                .Columns(1).HeaderText = "Almacén"
                .Columns(2).Width = DatagridWidth * 35
                .Columns(2).HeaderText = "Existencia"
            End With
            DgvExistencia.ClearSelection()
        Catch ex As Exception

        End Try

    End Sub

    Sub LimpiartxtBuscar()
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbNombre_CheckedChanged(sender As Object, e As EventArgs)
        RefrescarTablaArticulos()
        RefrescarTablaPrecios()
        RefrescarTablaExistencia()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs)
        RefrescarTablaArticulos()
        RefrescarTablaPrecios()
        RefrescarTablaExistencia()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbReferencia_CheckedChanged(sender As Object, e As EventArgs)
        RefrescarTablaArticulos()
        RefrescarTablaPrecios()
        RefrescarTablaExistencia()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCodigoBarra_CheckedChanged(sender As Object, e As EventArgs)
        RefrescarTablaArticulos()
        RefrescarTablaPrecios()
        RefrescarTablaExistencia()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If CInt(DTConfiguracion.Rows(90 - 1).Item("Value2Int")) = 1 Then
            If txtBuscar.Text.Contains("1/2") Then
                txtBuscar.Text = txtBuscar.Text.Replace("1/2", "½")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            ElseIf txtBuscar.Text.Contains("1 / 2") Then
                txtBuscar.Text = txtBuscar.Text.Replace("1 / 2", "½")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            ElseIf txtBuscar.Text.Contains("3/4") Then
                txtBuscar.Text = txtBuscar.Text.Replace("3/4", "¾")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            ElseIf txtBuscar.Text.Contains("3 / 4") Then
                txtBuscar.Text = txtBuscar.Text.Replace("3 / 4", "¾")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            ElseIf txtBuscar.Text.Contains("1/4") Then
                txtBuscar.Text = txtBuscar.Text.Replace("1/4", "¼")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            ElseIf txtBuscar.Text.Contains("1 / 4") Then
                txtBuscar.Text = txtBuscar.Text.Replace("1 / 4", "¼")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            ElseIf txtBuscar.Text.Contains("3/8") Then
                txtBuscar.Text = txtBuscar.Text.Replace("3/8", "⅜")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            ElseIf txtBuscar.Text.Contains("3 / 8") Then
                txtBuscar.Text = txtBuscar.Text.Replace("3 / 8", "⅜")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            ElseIf txtBuscar.Text.Contains("5/8") Then
                txtBuscar.Text = txtBuscar.Text.Replace("5/8", "⅝")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            ElseIf txtBuscar.Text.Contains("5 / 8") Then
                txtBuscar.Text = txtBuscar.Text.Replace("5 / 8", "⅝")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            ElseIf txtBuscar.Text.Contains("7/8") Then
                txtBuscar.Text = txtBuscar.Text.Replace("7/8", "⅞")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            ElseIf txtBuscar.Text.Contains("7 / 8") Then
                txtBuscar.Text = txtBuscar.Text.Replace("7 / 8", "⅞")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            ElseIf txtBuscar.Text.Contains("1/8") Then
                txtBuscar.Text = txtBuscar.Text.Replace("1/8", "⅛")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            ElseIf txtBuscar.Text.Contains("1 / 8") Then
                txtBuscar.Text = txtBuscar.Text.Replace("1 / 8", "⅛")
                txtBuscar.SelectionStart = txtBuscar.TextLength
            End If
        End If

        RefrescarTablaArticulos()
        RefrescarTablaPrecios()
        RefrescarTablaExistencia()

        If txtBuscar.Text.Length > 0 Then
            Button6.Visible = True
        Else
            Button6.Visible = False
        End If

    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvArticulos.Focus()
    End Sub

    Private Sub LlenarFormularios()
        'Try

        Dim ExistenciaTotal, ExistenciaAlmacen As Double
            Dim IDArticulo As New Label
            Dim DsTemp As New DataSet

            If TabMenus.SelectedIndex = 0 Then
                IDArticulo.Text = DgvArticulos.CurrentRow.Cells(0).Value
            Else
                IDArticulo.Text = ListControl1.Tag
            End If

            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT IDArticulo,Articulos.Descripcion,Referencia,IDTipoProducto,TipoArticulo,Articulos.IDSuplidor,Suplidor,Articulos.IDDepartamento,Departamento,Articulos.IDItbis,Tipo,Articulos.IDCategoria,Categoria,Articulos.IDSubCategoria,SubCategoria,Articulos.IDMarca,Marca,IDGarantia,TiempoGarantia,CodigoBarra,Serial,Promocion,Devolucion,VenderCosto,Descontinuar,NoPagoTarjeta,BloqueoCredito,PreAlertar,Revisado,ExistenciaMin,ExistenciaMax,ExistenciaTotal,Articulos.RutaFoto,Articulos.Desactivar,Articulos.IDParentesco,ParentescoProducto.Descripcion as Parentesco,CobrarComision,PorcentajeComision,NoPermitirCambiarPrecio,OrdenPrecios,Articulos.IDColor,Color.Color,Color.BigColorPath,Articulos.IDColectivo FROM articulos INNER JOIN TipoArticulo on Articulos.IDTipoProducto=TipoArticulo.IDTipoArticulo INNER JOIN Suplidor on Articulos.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Departamentos on Articulos.IDDepartamento=Departamentos.IDDepartamento INNER JOIN TipoItbis on Articulos.IDItbis=TipoItbis.IDTipoItbis INNER JOIN Categoria on Articulos.IDCategoria=Categoria.IDCategoria INNER JOIN SubCategoria on Articulos.IDSubCategoria=SubCategoria.IDSubCategoria INNER JOIN Marca on Articulos.IDMarca=Marca.IDMarca INNER JOIN Garantiaarticulos ON Articulos.IDGarantia=GarantiaArticulos.IDGarantiaArticulos INNER JOIN Libregco.ParentescoProducto on Articulos.IDParentesco=ParentescoProducto.IDParentesco INNER JOIN Libregco.Color on Articulos.IDColor=Color.IDColor Where IDArticulo='" + IDArticulo.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Articulos")

            Dim Tabla As DataTable = DsTemp.Tables("Articulos")

            If Me.Owner.Name = frm_facturacion.Name Then
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT Existencia FROM Libregco.Existencia Where IDAlmacen= '" + frm_facturacion.cbxAlmacen.Tag.ToString + "'", ConLibregco)
                ExistenciaAlmacen = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()

                If ExistenciaAlmacen > 0 Then
                    frm_facturacion.txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                    frm_facturacion.SetInformacionArticulo()
                    frm_facturacion.lblIDAlmacenArticulo.Text = frm_facturacion.cbxAlmacen.Tag.ToString
                    Close()
                    Exit Sub
                Else
                    For Each Row As DataGridViewRow In DgvExistencia.Rows
                        ExistenciaTotal = ExistenciaTotal + Row.Cells(2).Value
                    Next

                    If ExistenciaTotal > 0 Then
                        For Each Row As DataGridViewRow In DgvExistencia.Rows
                            If Row.Cells(2).Value > 0 Then
                                frm_facturacion.txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                                frm_facturacion.SetInformacionArticulo()
                                frm_facturacion.lblIDAlmacenArticulo.Text = Row.Cells(0).Value
                                Close()
                                Exit Sub
                            End If
                        Next
                    Else
                        frm_facturacion.txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                        frm_facturacion.SetInformacionArticulo()
                        frm_facturacion.lblIDAlmacenArticulo.Text = frm_facturacion.cbxAlmacen.Tag.ToString
                        Close()
                        Exit Sub
                    End If
                End If

                If frm_facturacion.CbxMedida.Items.Count = 1 Then
                    frm_facturacion.txtCantidadArticulo.Focus()
                    frm_facturacion.txtCantidadArticulo.SelectAll()
                Else
                    frm_facturacion.CbxMedida.Focus()
                End If

            ElseIf Me.Owner.Name = frm_punto_venta_lite.Name Then
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT Existencia FROM existencia Where IDAlmacen= '" + frm_punto_venta_lite.lblIDAlmacen.Text + "'", ConLibregco)
                ExistenciaAlmacen = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()

                If ExistenciaAlmacen > 0 Then
                    frm_punto_venta_lite.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                    frm_punto_venta_lite.lblIDAlmacenArticulo.Text = frm_punto_venta_lite.lblIDAlmacen.Text
                    frm_punto_venta_lite.SetInformacionArticulo()
                    frm_punto_venta_lite.cbxMedida.Focus()
                    Close()
                    Exit Sub
                Else
                    For Each Row As DataGridViewRow In DgvExistencia.Rows
                        ExistenciaTotal = ExistenciaTotal + Row.Cells(2).Value
                    Next

                    If ExistenciaTotal > 0 Then
                        For Each Row As DataGridViewRow In DgvExistencia.Rows
                            If Row.Cells(2).Value > 0 Then
                                frm_punto_venta_lite.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                                frm_punto_venta_lite.lblIDAlmacenArticulo.Text = Row.Cells(0).Value
                                frm_punto_venta_lite.SetInformacionArticulo()
                                frm_punto_venta_lite.cbxMedida.Focus()
                                Close()
                                Exit Sub
                            End If
                        Next
                    Else
                        frm_punto_venta_lite.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                        frm_punto_venta_lite.lblIDAlmacenArticulo.Text = frm_punto_venta_lite.lblIDAlmacen.Text
                        frm_punto_venta_lite.SetInformacionArticulo()
                        frm_punto_venta_lite.cbxMedida.Focus()
                        Close()
                        Exit Sub
                    End If
                End If
            ElseIf Me.Owner.Name = frm_cotizacion.Name Then
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT Existencia FROM existencia Where IDAlmacen= '" + frm_cotizacion.lblIDAlmacen.Text + "'", ConLibregco)
                ExistenciaAlmacen = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()

                If ExistenciaAlmacen > 0 Then
                    frm_cotizacion.txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                    frm_cotizacion.SetInformacionArticulo()
                    frm_cotizacion.lblIDAlmacenArticulo.Text = frm_cotizacion.lblIDAlmacen.Text
                    Close()
                    Exit Sub
                Else
                    For Each Row As DataGridViewRow In DgvExistencia.Rows
                        ExistenciaTotal = ExistenciaTotal + Row.Cells(2).Value
                    Next

                    If ExistenciaTotal > 0 Then
                        For Each Row As DataGridViewRow In DgvExistencia.Rows
                            If Row.Cells(2).Value > 0 Then
                                frm_cotizacion.txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                                frm_cotizacion.SetInformacionArticulo()
                                frm_cotizacion.lblIDAlmacenArticulo.Text = Row.Cells(0).Value
                                Close()
                                Exit Sub
                            End If
                        Next
                    Else
                        frm_cotizacion.txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                        frm_cotizacion.SetInformacionArticulo()
                        frm_cotizacion.lblIDAlmacenArticulo.Text = frm_cotizacion.lblIDAlmacen.Text
                        Close()
                        Exit Sub
                    End If
                End If

            ElseIf Me.Owner.Name = frm_cotizacion_nw.Name Then
                frm_cotizacion_nw.GridView1.AddNewRow()
                frm_cotizacion_nw.GridView1.SetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "IDArticulo", Tabla.Rows(0).Item("IDArticulo"))
                frm_cotizacion_nw.GridView1.Focus()
                frm_cotizacion_nw.GridView1.FocusedColumn = frm_cotizacion_nw.GridView1.Columns("IDArticulo")
                frm_cotizacion_nw.GridView1.ShowEditor()

                Close()
                Exit Sub




            ElseIf Me.Owner.Name = frm_mant_articulos.Name Then

                If frm_mant_articulos.ControlParent = 0 Then
                    frm_mant_articulos.txtIDProducto.Text = (Tabla.Rows(0).Item("IDArticulo"))
                    frm_mant_articulos.FillAllDatafromID()

                ElseIf frm_mant_articulos.ControlParent = 1 Then

                    If frm_mant_articulos.txtIDProducto.Text <> "" Then
                        If frm_mant_articulos.TbcProductos.SelectedIndex = 8 Then
                            If frm_mant_articulos.TabControl2.SelectedIndex = 1 Then

                                If frm_mant_articulos.txtIDSubCategoria.Text <> (Tabla.Rows(0).Item("IDSubCategoria")) Then
                                    MessageBox.Show("Las subcategorías del producto seleccionado y el producto abierto en el mantenimiento de artículos difiere.")
                                    Exit Sub
                                ElseIf frm_mant_articulos.txtIDProducto.text = Tabla.Rows(0).Item("IDArticulo") Then
                                    MessageBox.Show("El artículo que ha seleccionado es el mismo artículo al que desea asignare un grupo.")
                                    Exit Sub
                                End If

                                If CStr(Tabla.Rows(0).Item("IDColectivo")) <> 1 Then
                                    If CStr(Tabla.Rows(0).Item("IDColectivo")) = frm_mant_articulos.txtIDGrupo.Tag.ToString Then
                                        MessageBox.Show("El producto seleccionado ya pertenece al grupo actual.")
                                        Exit Sub
                                    ElseIf CInt(Tabla.Rows(0).Item("IDColectivo")) <> 1 Then

                                        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea agregar el artículo " & vbNewLine & vbNewLine & frm_mant_articulos.txtDescrip.Text & " [" & frm_mant_articulos.txtReferencia.Text & "]" & vbNewLine & vbNewLine & " al grupo del artículo " & vbNewLine & vbNewLine & DgvArticulos.CurrentRow.Cells(1).Value & " [" & DgvArticulos.CurrentRow.Cells(2).Value & "] ?", "Duplicar precios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                        If Result = MsgBoxResult.Yes Then

                                            ConLibregco.Open()
                                            cmd = New MySqlCommand("UPDATE Libregco.Articulos SET IDColectivo='" + CStr(Tabla.Rows(0).Item("IDColectivo")).ToString + "' WHERE IDArticulo= (" + DgvArticulos.CurrentRow.Cells(0).Value.ToString + ")", ConLibregco)
                                            cmd.ExecuteNonQuery()
                                            ConLibregco.Close()

                                            frm_mant_articulos.txtIDGrupo.Tag = CStr(Tabla.Rows(0).Item("IDColectivo"))
                                            frm_mant_articulos.txtIDGrupo.Text = CStr(Tabla.Rows(0).Item("IDColectivo"))

                                            frm_mant_articulos.RefrescarTablaColectivos()

                                            MessageBox.Show("El artículo se ha agrupado con el grupo del artículo " & vbNewLine & vbNewLine & DgvArticulos.CurrentRow.Cells(1).Value & " [" & DgvArticulos.CurrentRow.Cells(2).Value & "] satisfactoriamente.")
                                            Me.Close()
                                            Exit Sub
                                        End If
                                    End If

                                Else

                                    For Each rw As DataGridViewRow In frm_mant_articulos.DgvGrupos.Rows
                                        If rw.Cells(0).Value <> frm_mant_articulos.txtIDProducto.Text Then
                                            If rw.Cells(0).Value = (Tabla.Rows(0).Item("IDArticulo")) Then
                                                MessageBox.Show("El artículo que ha seleccionado ya se encuentra establecido en el grupo de artículos.")
                                                Exit Sub
                                            End If
                                        End If
                                    Next

                                    Dim wFilePath, wFileColor As System.IO.FileStream
                                    Dim RutaImage, RutaColor As Image

                                    If System.IO.File.Exists(Tabla.Rows(0).Item("RutaFoto")) = True Then
                                        wFilePath = New FileStream((Tabla.Rows(0).Item("RutaFoto")), FileMode.Open, FileAccess.Read)
                                        RutaImage = System.Drawing.Image.FromStream(wFilePath)
                                        wFilePath.Close()
                                    Else
                                        RutaImage = My.Resources.No_Image
                                    End If

                                    If System.IO.File.Exists(Tabla.Rows(0).Item("BigColorPath")) = True Then
                                        wFileColor = New FileStream((Tabla.Rows(0).Item("BigColorPath")), FileMode.Open, FileAccess.Read)
                                        RutaColor = System.Drawing.Image.FromStream(wFileColor)
                                        wFileColor.Close()
                                    Else
                                        RutaColor = Nothing
                                    End If

                                    frm_mant_articulos.DgvGrupos.Rows.Add(Tabla.Rows(0).Item("IDArticulo"), RutaImage, Tabla.Rows(0).Item("Descripcion"), Tabla.Rows(0).Item("Referencia"), RutaColor)
                                    frm_mant_articulos.DgvGrupos.ClearSelection()

                                    ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

                                    If frm_mant_articulos.chkNoCerrarBuscarArticulo.Checked Then
                                        Exit Sub
                                    End If
                                End If
                            End If
                        End If
                    End If


                ElseIf frm_mant_articulos.ControlParent = 2 Then
                    MessageBox.Show("Para agregar un producto complementario debe seleccionar el artículo desde la tabla de precios de este formulario.")
                    Exit Sub

                ElseIf frm_mant_articulos.ControlParent = 3 Then
                    If DgvArticulos.CurrentRow.Cells(0).Value <> frm_mant_articulos.txtIDProducto.Text Then
                        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea duplicar los precios del artículo " & DgvArticulos.CurrentRow.Cells(1).Value & " en el artículo " & frm_mant_articulos.txtDescrip.Text & "?", "Duplicar precios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If Result = MsgBoxResult.Yes Then
                            Dim DsTemp1 As New DataSet
                            DsTemp1.Clear()

                            ConLibregco.Open()
                            cmd = New MySqlCommand("Select IDPrecios,IDMedida,Contenido,Costo,CostoFinal,PrecioCredito,PrecioContado,Precio3,Precio4,CostoClave,PrecioBlackFriday,Piezaje,IDMoneda FROM precioarticulo where IDArticulo='" + DgvArticulos.CurrentRow.Cells(0).Value.ToString + "'", ConLibregco)
                            Adaptador = New MySqlDataAdapter(cmd)
                            Adaptador.Fill(DsTemp1, "precioarticulo")
                            ConLibregco.Close()

                            Dim TablaPrecios As DataTable = DsTemp1.Tables("precioarticulo")

                            If TablaPrecios.Rows.Count > 0 Then

                                For Each dt As DataRow In TablaPrecios.Rows
                                    ConLibregco.Open()
                                    cmd = New MySqlCommand("SELECT count(IDPrecios) FROM precioarticulo Where IDArticulo= '" + frm_mant_articulos.txtIDProducto.Text + "' and IDMedida='" + dt.Item("IDMedida").ToString + "'", ConLibregco)
                                    Dim CantPrecio As Integer = Convert.ToInt16(cmd.ExecuteScalar())
                                    ConLibregco.Close()

                                    If CantPrecio = 0 Then
                                        ConLibregco.Open()
                                        sqlQ = "INSERT INTO Libregco.PrecioArticulo (IDArticulo,IDMedida,Contenido,Costo,CostoFinal,DescuentoMaximo,PrecioCredito,PrecioContado,Precio3,Precio4,Nulo,CostoClave,PrecioBlackFriday,Piezaje,IDMoneda) VALUES ('" + frm_mant_articulos.txtIDProducto.Text + "','" + dt.Item("IDMedida").ToString + "', '" + dt.Item("Contenido").ToString + "','" + dt.Item("Costo").ToString + "', '" + dt.Item("CostoFinal").ToString + "',0,'" + dt.Item("PrecioCredito").ToString + "', '" + dt.Item("PrecioContado").ToString + "','" + dt.Item("Precio3").ToString + "','" + dt.Item("Precio4").ToString + "',0,'" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(dt.Item("Costo").ToString)).ToString + "','" + dt.Item("PrecioBlackFriday").ToString + "','" + dt.Item("Piezaje").ToString + "','" + dt.Item("IDMoneda").ToString + "')"
                                        cmd = New MySqlCommand(sqlQ, ConLibregco)
                                        cmd.ExecuteNonQuery()

                                        cmd = New MySqlCommand("Select IDPrecios from PrecioArticulo where IDPrecios= (Select Max(IDPrecios) from PrecioArticulo)", ConLibregco)
                                        frm_mant_articulos.lblIDPrecio.Text = Convert.ToDouble(cmd.ExecuteScalar())
                                        ConLibregco.Close()

                                        frm_mant_articulos.ProcesarExistencia()
                                    Else
                                    ConLibregco.Open()
                                    sqlQ = "UPDATE Libregco.PrecioArticulo SET Costo='" + dt.Item("Costo").ToString + "',CostoFinal='" + dt.Item("CostoFinal").ToString + "',PrecioContado='" + dt.Item("PrecioContado").ToString + "',PrecioCredito='" + dt.Item("PrecioCredito").ToString + "',Precio3='" + dt.Item("Precio3").ToString + "',Precio4='" + dt.Item("Precio4").ToString + "',Nulo=0,CostoClave='" + ConvertCostKey(DTConfiguracion.Rows(78 - 1).Item("Value1Var").ToString, CInt(dt.Item("Costo").ToString)).ToString + "',PrecioBlackFriday='" + dt.Item("PrecioBlackFriday").ToString + "',Piezaje='" + dt.Item("Piezaje").ToString + "',IDMoneda='" + dt.Item("IDMoneda").ToString + "' WHERE IDPrecios=(" + frm_mant_articulos.DgvPrecios.CurrentRow.Cells("IDPrecios").Value.ToString + ")"
                                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                                    cmd.ExecuteNonQuery()
                                    ConLibregco.Close()

                                    Con.Open()
                                    UpdateLastUpdatePrices(frm_mant_articulos.DgvPrecios.CurrentRow.Cells("IDPrecios").Value.ToString)
                                    Con.Close()
                                End If
                                Next

                                frm_mant_articulos.RefrescarTablaPrecios()

                                MessageBox.Show("El precio ha sido duplicado satisfactoriamente.", "Precio duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)


                            Else
                                MsgBox("No se encontraron precios en el artículo seleccionado para duplicar.")
                            End If

                        End If
                    End If

                ElseIf frm_mant_articulos.ControlParent = 4 Then
                    If DgvArticulos.CurrentRow.Cells(0).Value <> frm_mant_articulos.txtIDProducto.Text Then
                        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea duplicar las propiedades del artículo " & DgvArticulos.CurrentRow.Cells(1).Value & " en el artículo " & frm_mant_articulos.txtDescrip.Text & "?", "Duplicar propiedades", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        If Result = MsgBoxResult.Yes Then
                            Dim DsTemp1 As New DataSet

                            ConLibregco.Open()
                            cmd = New MySqlCommand("SELECT IDPropiedad_Propiedad FROM libregco.articulos_has_propiedad where IDArticulo='" + DgvArticulos.CurrentRow.Cells(0).Value.ToString + "'", ConLibregco)
                            Adaptador = New MySqlDataAdapter(cmd)
                            Adaptador.Fill(DsTemp1, "HasPropiedades")
                            ConLibregco.Close()

                            Dim TablaPropiedades As DataTable = DsTemp1.Tables("HasPropiedades")

                            If TablaPropiedades.Rows.Count > 0 Then
                                ConLibregco.Open()


                                For Each dt As DataRow In TablaPropiedades.Rows
                                    cmd = New MySqlCommand("SELECT count(IDPropiedad_Propiedad) FROM articulos_has_propiedad Where IDArticulo= '" + frm_mant_articulos.txtIDProducto.Text + "' and IDPropiedad_propiedad='" + dt.Item("IDPropiedad_Propiedad").ToString + "'", ConLibregco)
                                    Dim CantPropiedad As Integer = Convert.ToInt16(cmd.ExecuteScalar())

                                    If CantPropiedad = 0 Then
                                        sqlQ = "INSERT INTO Libregco.articulos_has_propiedad (IDPropiedad_propiedad,IDArticulo) VALUES ('" + dt.Item("IDPropiedad_Propiedad").ToString + "','" + frm_mant_articulos.txtIDProducto.Text + "')"
                                        cmd = New MySqlCommand(sqlQ, ConLibregco)
                                        cmd.ExecuteNonQuery()
                                    End If
                                Next

                                cmd = New MySqlCommand("Select coalesce(group_concat(IDPropiedad_propiedad separator ', '),'') FROM libregco.articulos_has_propiedad inner join libregco.articulos_propiedad on articulos_has_propiedad.IDPropiedad_propiedad=articulos_propiedad.idArticulos_propiedad  WHERE Articulos_has_propiedad.IDArticulo= '" + frm_mant_articulos.txtIDProducto.Text + "'", ConLibregco)
                                frm_mant_articulos.TKPropiedades.EditValue = Convert.ToString(cmd.ExecuteScalar())

                                ConLibregco.Close()

                                MessageBox.Show("Las propiedades ha sido duplicadas satisfactoriamente.", "Propiedades duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)


                            Else
                                MsgBox("No se encontraron propiedades en el artículo seleccionado para duplicar.")
                            End If
                        End If
                    End If
                End If

            ElseIf Me.Owner.Name = frm_ajuste_inventario.Name Then
                Dim ds As New DataSet

                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT IDPrecios,Articulos.IDArticulo,Articulos.Descripcion,Articulos.Referencia,PrecioArticulo.IDMedida,Articulos.ExistenciaTotal,Fraccionamiento,Costo FROM libregco.articulos INNER JOIN Libregco.PrecioArticulo on Articulos.IDArticulo=PrecioArticulo.IDArticulo INNER JOIN Libregco.Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where PrecioArticulo.Contenido=1 and PrecioArticulo.IDArticulo='" + IDArticulo.Text + "'", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(ds, "Precios")
                ConLibregco.Close()

                For Each dt As DataRow In ds.Tables("Precios").Rows
                    frm_ajuste_inventario.TablaArticulos.Rows.Add("", dt.Item("IDPrecios"), dt.Item("IDArticulo"), dt.Item("Descripcion"), dt.Item("Referencia"), dt.Item("IDMedida"), dt.Item("ExistenciaTotal"), 0, dt.Item("ExistenciaTotal"), "", dt.Item("Fraccionamiento"), dt.Item("Costo"), 0)
                Next

            ElseIf Me.Owner.Name = frm_mdi_prefacturacion.name Then
                'frm_prefacturacion_new.AdvBandedGridView1.Focus()
                'frm_prefacturacion_new.AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                'frm_prefacturacion_new.AdvBandedGridView1.FocusedColumn = frm_prefacturacion_new.AdvBandedGridView1.Columns("Busqueda")
                'frm_prefacturacion_new.AdvBandedGridView1.ShowEditor()

                'frm_prefacturacion_new.AdvBandedGridView1.AddNewRow()
                'frm_prefacturacion_new.AdvBandedGridView1.SetRowCellValue(frm_prefacturacion_new.AdvBandedGridView1.FocusedRowHandle, frm_prefacturacion_new.AdvBandedGridView1.Columns("Busqueda"), Tabla.Rows(0).Item("IDArticulo"))


                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.Focus()
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.FocusedColumn = DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.Columns("Busqueda")
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.ShowEditor()

                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.AddNewRow()
                DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.SetRowCellValue(DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.FocusedRowHandle, DirectCast(Owner.ActiveMdiChild, frm_prefacturacion_new).AdvBandedGridView1.Columns("Busqueda"), Tabla.Rows(0).Item("IDArticulo"))

            ElseIf Me.Owner.Name = frm_prefacturacion.Name Then
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT Existencia FROM existencia Where IDAlmacen= '" + frm_prefacturacion.lblIDAlmacen.Text + "'", ConLibregco)
                ExistenciaAlmacen = Convert.ToDouble(cmd.ExecuteScalar())
                ConLibregco.Close()

                If ExistenciaAlmacen > 0 Then
                    frm_prefacturacion.txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                    frm_prefacturacion.SetInformacionArticulo()
                    frm_prefacturacion.lblIDAlmacenArticulo.Text = DTEmpleado.Rows(0).Item("IDAlmacen").ToString
                    frm_prefacturacion.txtCantidadArticulo.Focus()
                    frm_prefacturacion.txtCantidadArticulo.SelectAll()
                    Close()
                    Exit Sub
                Else
                    For Each Row As DataGridViewRow In DgvExistencia.Rows
                        ExistenciaTotal = ExistenciaTotal + Row.Cells(2).Value
                    Next

                    If ExistenciaTotal > 0 Then
                        For Each Row As DataGridViewRow In DgvExistencia.Rows
                            If Row.Cells(2).Value > 0 Then
                                frm_prefacturacion.txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                                frm_prefacturacion.SetInformacionArticulo()
                                frm_prefacturacion.lblIDAlmacenArticulo.Text = Row.Cells(0).Value
                                frm_prefacturacion.txtCantidadArticulo.Focus()
                                frm_prefacturacion.txtCantidadArticulo.SelectAll()
                                Close()
                                Exit Sub
                            End If
                        Next
                    Else
                        frm_prefacturacion.txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                        frm_prefacturacion.SetInformacionArticulo()
                        frm_prefacturacion.lblIDAlmacenArticulo.Text = frm_prefacturacion.lblIDAlmacen.Text
                        frm_prefacturacion.txtCantidadArticulo.Focus()
                        frm_prefacturacion.txtCantidadArticulo.SelectAll()
                        Close()
                        Exit Sub
                    End If
                End If

                frm_prefacturacion.txtCantidadArticulo.Focus()
                frm_prefacturacion.txtCantidadArticulo.SelectAll()

            ElseIf Me.Owner.Name = frm_inv_inicial.Name Then
                frm_inv_inicial.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_inv_inicial.IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_inv_inicial.SetInformacionArticulo()
                frm_inv_inicial.lblIDAlmacenArticulo.Text = frm_inv_inicial.lblIDAlmacen.Text

            ElseIf Me.Owner.Name = frm_registro_compras.Name Then
                frm_registro_compras.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_registro_compras.SetInformacionArticulo()
                frm_registro_compras.lblIDAlmacenArticulo.Text = frm_registro_compras.LUEAlmacen.EditValue.ToString
                frm_registro_compras.CbxMedida.Focus()

            ElseIf Me.Owner.Name = frm_orden_compras.Name Then
                frm_orden_compras.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_orden_compras.IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_orden_compras.SetInformacionArticulo()

            ElseIf Me.Owner.Name = frm_transferencia_arts.Name Then
                frm_transferencia_arts.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_transferencia_arts.IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_transferencia_arts.SetInformacionArticulo()

            ElseIf Me.Owner.Name = frm_conduce_reparaciones.Name Then
                frm_conduce_reparaciones.txtCodigoArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_conduce_reparaciones.SetInformacionArticulo()

            ElseIf Me.Owner.Name = frm_listado_articulos.Name Then
                frm_listado_articulos.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_listado_articulos.SetInformacionArticulo()

            ElseIf Me.Owner.Name = frm_consulta_serie_garantia.Name Then
                frm_consulta_serie_garantia.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_consulta_serie_garantia.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_productos.Name Then
                If frm_reporte_productos.txtCodigoArtDesde.Text = "" Then
                    frm_reporte_productos.txtCodigoArtDesde.Text = (Tabla.Rows(0).Item("IDArticulo"))
                Else
                    frm_reporte_productos.txtCodigoArtHasta.Text = (Tabla.Rows(0).Item("IDArticulo"))
                End If

            ElseIf Me.Owner.Name = frm_reporte_detalle_ventas.Name Then
                frm_reporte_detalle_ventas.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_detalle_ventas.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_devolucion_ventas.Name Then
                frm_reporte_devolucion_ventas.txtIDProducto.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_devolucion_ventas.txtProducto.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_detalle_compras.Name Then
                frm_reporte_detalle_compras.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_detalle_compras.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_devolucion_compras.Name Then
                frm_reporte_devolucion_compras.txtIDProducto.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_devolucion_compras.txtProducto.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_orden_compra.Name Then
                frm_reporte_orden_compra.txtIDProducto.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_orden_compra.txtProducto.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_inventario_fecha.Name Then
                frm_reporte_inventario_fecha.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_inventario_fecha.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_movimientos_inventario.Name Then
                frm_reporte_movimientos_inventario.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_movimientos_inventario.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_conduce_reparacion.Name Then
                frm_reporte_conduce_reparacion.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_conduce_reparacion.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_ajustes_inventario.Name Then
                frm_reporte_ajustes_inventario.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_ajustes_inventario.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_transferencias_inventario.Name Then
                frm_reporte_transferencias_inventario.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_transferencias_inventario.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_conduces.Name Then
                frm_reporte_conduces.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_conduces.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_notas_pedidos.Name Then
                frm_reporte_notas_pedidos.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_notas_pedidos.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_listado_articulos.Name Then
                frm_reporte_listado_articulos.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_listado_articulos.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_etiquetas_productos.Name Then
                frm_reporte_etiquetas_productos.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_etiquetas_productos.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_reporte_etiquetas_productos.FillMedida()

            ElseIf Me.Owner.Name = frm_reporte_series_garantias.Name Then
                frm_reporte_series_garantias.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_series_garantias.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_reporte_entradas_reparacion.Name Then
                frm_reporte_entradas_reparacion.txtIDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                frm_reporte_entradas_reparacion.txtArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))

            ElseIf Me.Owner.Name = frm_actualizar_precios_costos.Name Then
                frm_actualizar_precios_costos.TablaArticulos.Rows.Add(ResizeImage(PicImagen.Image, 45), DgvArticulos.CurrentRow.Cells(0).Value, DgvArticulos.CurrentRow.Cells(2).Value, DgvArticulos.CurrentRow.Cells(1).Value, DgvPrecioArticulo.CurrentRow.Cells(1).Value, CDbl(DgvPrecioArticulo.CurrentRow.Cells(7).Value).ToString("C"), CDbl(DgvPrecioArticulo.CurrentRow.Cells(8).Value).ToString("C"), CDbl(DgvPrecioArticulo.CurrentRow.Cells(3).Value).ToString("C"), CDbl(DgvPrecioArticulo.CurrentRow.Cells(4).Value).ToString("C"), CDbl(DgvPrecioArticulo.CurrentRow.Cells(5).Value).ToString("C"), CDbl(DgvPrecioArticulo.CurrentRow.Cells(6).Value).ToString("C"), "", "", "", "", "", "", DgvPrecioArticulo.CurrentRow.Cells(0).Value)

            ElseIf Me.Owner.Name = frm_actualizar_propiedades_articulos.Name Then

                frm_actualizar_propiedades_articulos.TablaArticulos.Rows.Add(ResizeImage(PicImagen.Image, 45), Tabla.Rows(0).Item("IDArticulo"), Tabla.Rows(0).Item("Descripcion"), Tabla.Rows(0).Item("Referencia"), Tabla.Rows(0).Item("IDTipoProducto"), Tabla.Rows(0).Item("IDSuplidor"), Tabla.Rows(0).Item("IDDepartamento"), Tabla.Rows(0).Item("IDCategoria"), Tabla.Rows(0).Item("IDSubcategoria"), Tabla.Rows(0).Item("IDMarca"), Tabla.Rows(0).Item("IDParentesco"), Tabla.Rows(0).Item("IDGarantia"), Tabla.Rows(0).Item("IDItbis"), Tabla.Rows(0).Item("CodigoBarra"), Tabla.Rows(0).Item("Serial"), Tabla.Rows(0).Item("Promocion"), Tabla.Rows(0).Item("Devolucion"), Tabla.Rows(0).Item("Vendercosto"), Tabla.Rows(0).Item("Descontinuar"), Tabla.Rows(0).Item("BloqueoCredito"), Tabla.Rows(0).Item("PreAlertar"), Tabla.Rows(0).Item("NoPagoTarjeta"), Tabla.Rows(0).Item("Revisado"), Tabla.Rows(0).Item("Desactivar"))

            ElseIf Me.Owner.Name = frm_historial_modificaciones_precios.Name Then
                frm_historial_modificaciones_precios.txtDescripcion.Text = (Tabla.Rows(0).Item("Descripcion"))
                frm_historial_modificaciones_precios.txtDescripcion.Tag = (Tabla.Rows(0).Item("IDArticulo"))
                frm_historial_modificaciones_precios.FillArticulos()
            End If

            Close()
            Exit Sub

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        'End Try

    End Sub

    Private Sub DgvArticulos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvArticulos.KeyPress
        If DgvArticulos.Rows.Count > 0 Then
            If e.KeyChar = ChrW(Keys.Enter) Then
                LlenarFormularios()
            End If
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvArticulos.Focus()
        End If
    End Sub

    Private Sub DgvArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvArticulos.KeyDown
        Try
            If DgvArticulos.Rows.Count > 0 Then
                If e.KeyCode = Keys.Enter Then
                    Dim NumCols As Integer = DgvArticulos.ColumnCount
                    Dim NumRows As Integer = DgvArticulos.RowCount
                    Dim CurCell As DataGridViewCell = DgvArticulos.CurrentCell
                    If CurCell.ColumnIndex = NumCols - 1 Then
                        If CurCell.RowIndex < NumRows - 1 Then
                            DgvArticulos.CurrentCell = DgvArticulos.Item(0, CurCell.RowIndex + 1)
                        End If
                    Else
                        DgvArticulos.CurrentCell = DgvArticulos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                    End If
                    e.Handled = True

                ElseIf e.KeyCode = Keys.F2 Then
                    e.Handled = True
                    txtBuscar.Focus()
                End If
            End If


        Catch ex As Exception
        End Try

    End Sub

    Private Sub DgvArticulos_SelectionChanged(sender As Object, e As EventArgs) Handles DgvArticulos.SelectionChanged
        RefrescarTablaPrecios()
        RefrescarTablaExistencia()
        PutImagePictureBox()
        PutPropiedades()
    End Sub

    Private Sub PutPropiedades()
        Try
            If DgvArticulos.Rows.Count > 0 Then
                TKPropiedades.EditValue = DgvArticulos.CurrentRow.Cells(6).Value
            Else
                TKPropiedades.EditValue = ""
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub PutImagePictureBox()
        Try
            If DgvArticulos.Rows.Count > 0 Then
                If DgvArticulos.CurrentRow.Cells(5).Value <> "" Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(DgvArticulos.CurrentRow.Cells(5).Value)
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        lblNotaImagen.Visible = False
                        wFile = New FileStream(DgvArticulos.CurrentRow.Cells(5).Value, FileMode.Open, FileAccess.Read)
                        PicImagen.Image = System.Drawing.Image.FromStream(wFile)
                        wFile.Close()
                        lblNotaImagen.Text = ""
                        PicImagen.BackColor = Color.White
                    End If
                Else
                    PicImagen.Image = Nothing
                    lblNotaImagen.Visible = True
                    lblNotaImagen.Text = "No se encuentra una imagen disponible del artículo."
                    PicImagen.BackColor = SystemColors.Control
                End If
            Else
                PicImagen.Image = Nothing
                lblNotaImagen.Visible = True
                lblNotaImagen.Text = "No se encuentra una imagen disponible del artículo."
                PicImagen.BackColor = SystemColors.Control
            End If

        Catch ex As Exception
            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub LimpiarDgvSelection()
        DgvArticulos.ClearSelection()
        DgvPrecioArticulo.ClearSelection()
        DgvExistencia.ClearSelection()
    End Sub

    Private Sub txtBuscar_Enter(sender As Object, e As EventArgs) Handles txtBuscar.Enter
        LimpiarDgvSelection()
    End Sub

    Private Sub DgvArticulos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub frm_buscar_mant_articulos_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadColumnsDvg()
        PropiedadColumnsExistencia()
        PropiedadColumnsPrecioDgv()
    End Sub

    Private Sub PicImagen_Click(sender As Object, e As EventArgs) Handles PicImagen.Click
        If DgvArticulos.Rows.Count > 0 Then
            If DgvArticulos.CurrentRow.Cells(5).Value <> "" Then
                Dim ExistFile As Boolean = System.IO.File.Exists(DgvArticulos.CurrentRow.Cells(5).Value)
                If ExistFile = True Then
                    System.Diagnostics.Process.Start(DgvArticulos.CurrentRow.Cells(5).Value)
                End If
            End If
        End If
    End Sub

    Private Sub btnImagenes_Click(sender As Object, e As EventArgs) Handles btnImagenes.Click
        If DgvArticulos.Rows.Count > 0 Then
            frm_visualizar_imagenes.ShowDialog(Me)
        End If

    End Sub

    Private Sub btnEspecificaciones_Click(sender As Object, e As EventArgs) Handles btnEspecificaciones.Click
        If DgvArticulos.Rows.Count > 0 Then
            frm_visualizar_especificaciones.ShowDialog(Me)
        End If
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        TabClasico.SelectedIndex = 1
    End Sub

    Private Sub frm_buscar_mant_articulos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()

        If Me.Owner.Name = frm_prefacturacion.Name Then
            frm_prefacturacion.txtCodigoArticulo.Focus()
            frm_prefacturacion.txtCodigoArticulo.SelectAll()

        ElseIf Me.Owner.Name = frm_prefacturacion_new.name Then
            frm_prefacturacion_new.AdvBandedGridView1.Focus()
            frm_prefacturacion_new.AdvBandedGridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
            frm_prefacturacion_new.AdvBandedGridView1.FocusedColumn = frm_prefacturacion_new.AdvBandedGridView1.Columns("Busqueda")
            frm_prefacturacion_new.AdvBandedGridView1.ShowEditor()
        End If
    End Sub

    Private Sub frm_buscar_mant_articulos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Control.ModifierKeys = Keys.F2 Then
            e.Handled = True
            txtBuscar.Focus()

        ElseIf e.KeyCode = Keys.Down Then
            If DgvArticulos.Focused = False Then
                BindingNavigatorMoveNextItem.PerformClick()

            End If

        ElseIf e.KeyCode = Keys.Up Then
            If DgvArticulos.Focused = False Then
                BindingNavigatorMovePreviousItem.PerformClick()
            End If

        ElseIf e.KeyCode = Keys.Escape Then
            If txtBuscar.Text.Length = 0 Then
                Me.Close()
            Else
                txtBuscar.Clear()
                txtBuscar.Focus()
            End If
        End If
    End Sub

    Private Sub DgvPrecioArticulo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPrecioArticulo.CellDoubleClick
        If e.RowIndex >= 0 Then
            If Me.Owner.Name = frm_mant_articulos.Name Then
                If frm_mant_articulos.txtIDProducto.Text <> "" Then

                    If frm_mant_articulos.TbcProductos.SelectedIndex = 6 Then
                        If DgvArticulos.CurrentRow.Cells(0).Value = frm_mant_articulos.txtIDProducto.Text Then
                            MessageBox.Show("El artículo seleccionado es el mismo producto padre." & vbNewLine & vbNewLine & "Por favor seleccione un artículo válido para agregar como hijo.", "Artículo no válido", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        Else
                            frm_mant_articulos.lblIDArticuloComplementario.Text = DgvArticulos.CurrentRow.Cells(0).Value
                            frm_mant_articulos.lblArticuloComplementario.Text = DgvArticulos.CurrentRow.Cells(1).Value
                            frm_mant_articulos.lblReferenciaComplementario.Text = DgvArticulos.CurrentRow.Cells(2).Value
                            frm_mant_articulos.txtCantParaActivar.Value = 1
                            frm_mant_articulos.cbxMonedaComplementario.EditValue = CInt(DgvPrecioArticulo.CurrentRow.Cells(9).Value)
                            If frm_mant_articulos.cbxMedidaActivar.Items.Count = 1 Then
                                frm_mant_articulos.cbxMedidaActivar.SelectedIndex = 0
                            End If
                            frm_mant_articulos.txtCantidadIncluirComplementario.Value = 1
                            frm_mant_articulos.chkIncluirPrecioComplementario.Checked = False
                            frm_mant_articulos.cbxNivelPrecioComplementario.Text = "A"
                            frm_mant_articulos.txtPrecioComplementario.Text = CDbl(DgvPrecioArticulo.CurrentRow.Cells(3).Value).ToString("C")
                            frm_mant_articulos.chkLimitarVidaComplementario.Checked = False
                            frm_mant_articulos.dtpFechaVidaComplementario.Value = Today.AddDays(1)
                            frm_mant_articulos.FillCbxMedidaPadres()
                            frm_mant_articulos.DgvHijos.ClearSelection()
                        End If
                    End If

                    Me.Close()
                End If
            End If

        End If
    End Sub

    Private Sub txtIDSuplidor_Leave(sender As Object, e As EventArgs) Handles txtIDSuplidor.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Suplidor from Suplidor Where IDSuplidor='" + txtIDSuplidor.Text + "'", ConLibregco)
        txtSuplidor.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        If txtSuplidor.Text = "" Then txtIDSuplidor.Clear()
        RefrescarTablaArticulos()
    End Sub

    Private Sub txtIDTipoArticulo_Leave(sender As Object, e As EventArgs) Handles txtIDTipo.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select TipoArticulo from TipoArticulo Where IDTipoArticulo='" + txtIDTipo.Text + "'", ConLibregco)
        txtTipo.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        If txtTipo.Text = "" Then txtIDTipo.Clear()
        RefrescarTablaArticulos()
    End Sub

    Private Sub txtIDDepartamento_Leave(sender As Object, e As EventArgs) Handles txtIDDepartamento.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Departamento from Departamentos Where IDDepartamento='" + txtIDDepartamento.Text + "'", ConLibregco)
        txtDepartamento.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        If txtDepartamento.Text = "" Then txtIDDepartamento.Clear()
        RefrescarTablaArticulos()
    End Sub

    Private Sub txtIDCategoria_Leave(sender As Object, e As EventArgs) Handles txtIDCategoria.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Categoria from Categoria Where IDCategoria='" + txtIDCategoria.Text + "'", ConLibregco)
        txtCategoria.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        If txtCategoria.Text = "" Then txtIDCategoria.Clear()
        RefrescarTablaArticulos()
    End Sub

    Private Sub txtIDSubCategoria_Leave(sender As Object, e As EventArgs) Handles txtIDSubCategoria.Leave
        If txtIDCategoria.Text = "" Then
            MessageBox.Show("Seleccione la categoría del producto para proceder con el registro de artículos.", "Seleccionar categoría", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtIDCategoria.Focus()
        Else
            ConLibregco.Open()
            cmd = New MySqlCommand("Select SubCategoria from SubCategoria INNER JOIN Categoria on SubCategoria.IDCategoria=Categoria.IDCategoria Where SubCategoria.IDSubCategoria='" + txtIDSubCategoria.Text + "' and SubCategoria.IDCategoria='" + txtIDCategoria.Text + "'", ConLibregco)
            txtSubcategoria.Text = Convert.ToString(cmd.ExecuteScalar())
            ConLibregco.Close()

            If txtSubcategoria.Text = "" Then txtIDSubCategoria.Clear()
            RefrescarTablaArticulos()
        End If

    End Sub

    Private Sub txtIDMarca_Leave(sender As Object, e As EventArgs) Handles txtIDMarca.Leave
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Marca from Marca Where IDMarca='" + txtIDMarca.Text + "'", ConLibregco)
        txtMarca.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        If txtMarca.Text = "" Then txtIDMarca.Clear()
        RefrescarTablaArticulos()
    End Sub

    Private Sub btn_Suplidor_Click(sender As Object, e As EventArgs) Handles btn_Suplidor.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub btnTipo_Click(sender As Object, e As EventArgs) Handles btnTipo.Click
        frm_buscar_tipo_articulo.ShowDialog(Me)
    End Sub

    Private Sub btnDepartamento_Click(sender As Object, e As EventArgs) Handles btnDepartamento.Click
        frm_buscar_departamentos.ShowDialog(Me)
    End Sub

    Private Sub btnCategoria_Click(sender As Object, e As EventArgs) Handles btnCategoria.Click
        If txtIDDepartamento.Text = "" Then
            MessageBox.Show("Seleccione el departamento correspondiente para posteriormente elegir la categoría del producto.", "Elegir Departamento", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        frm_buscar_categorias.ShowDialog(Me)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        txtIDSuplidor.Clear()
        txtSuplidor.Clear()
        txtIDTipo.Clear()
        txtTipo.Clear()
        txtIDDepartamento.Clear()
        txtDepartamento.Clear()
        txtIDCategoria.Clear()
        txtCategoria.Clear()
        txtIDSubCategoria.Clear()
        txtSubcategoria.Clear()
        txtIDMarca.Clear()
        txtMarca.Clear()
        RefrescarTablaArticulos()
        txtBuscar.Focus()
        txtBuscar.SelectAll()
    End Sub

    Private Sub btnSubcategoria_Click(sender As Object, e As EventArgs) Handles btnSubcategoria.Click
        If txtIDCategoria.Text = "" Then
            MessageBox.Show("Seleccione la categoría correspondiente para posteriormente elegir la sub-categoría del producto.", "Elegir Categoría", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        frm_buscar_subcategorias.ShowDialog(Me)
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        frm_buscar_marcas.ShowDialog(Me)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        TabClasico.SelectedIndex = 0
        txtBuscar.Focus()
        txtBuscar.SelectAll()
    End Sub

    Private Sub FillDepartments()
        Try
            Dim DsTemp As New DataSet

            FlowDepartamentos.Controls.Clear()

            DsTemp.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDDepartamento,Departamento,DepartamentoFilePath FROM libregco.departamentos ORDER BY Departamento ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Departamento")

            Dim Tabla As DataTable = DsTemp.Tables("Departamento")

            For Each itm As DataRow In Tabla.Rows

                Dim DMen As New DinamicMenu

                DMen.ParentID = itm(0)
                DMen.Picture.Tag = itm(0)
                DMen.TypeParent = 0
                DMen.Description = itm(1)
                DMen.Height = FlowDepartamentos.Height
                DMen.Width = FlowDepartamentos.Width / 4

                Dim ExistFile As Boolean = System.IO.File.Exists(itm(2))
                If ExistFile = True Then
                    Dim wFile As System.IO.FileStream
                    lblNotaImagen.Visible = False
                    wFile = New FileStream(itm(2), FileMode.Open, FileAccess.Read)
                    DMen.PutImage = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                Else
                    DMen.PutImage = My.Resources.No_Image
                End If

                Dim Dstemp1 As New DataSet
                cmd = New MySqlCommand("SELECT IDCategoria,Categoria,CategoriaFilePath FROM libregco.categoria where IDDepartamento='" + DMen.ParentID.ToString + "' ORDER BY Categoria ASC", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Dstemp1, "Categoria")

                Dim TablaCategoria As DataTable = Dstemp1.Tables("Categoria")

                DMen.RowsIndeed = TablaCategoria

                AddHandler DMen.DgvCategorias.Click, AddressOf GotoMessage
                AddHandler DMen.Picture.Click, AddressOf GotoMessage

                FlowDepartamentos.Controls.Add(DMen)



            Next


            ConLibregco.Close()
            DsTemp.Dispose()
        Catch ex As Exception
            ConLibregco.Close()

            'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub frm_buscar_mant_articulos_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtBuscar.Focus()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles VistaTabla.Click
        TabMenus.Location = New Point(-8, -29)
        TabMenus.Size = New Size(1026, 663)
        TabMenus.SelectedIndex = 0
        btnFiltrar.Visible = True
        btnEspecificaciones.Visible = True
        btnImagenes.Visible = True
        BindingNavigatorSeparator2.Visible = True
        ToolStripSeparator2.Visible = True

        OptionVisibleBingingNavigator()

        VistaTabla.Image = My.Resources.listvieworange
        VistaDinamica.Image = My.Resources.imageviewgray
        txtBuscar.Focus()
    End Sub

    Private Sub OptionVisibleBingingNavigator()
        If TabMenus.SelectedIndex = 0 Then
            BindingNavigatorMoveFirstItem.Visible = True
            BindingNavigatorMovePreviousItem.Visible = True
            BindingNavigatorSeparator.Visible = True
            BindingNavigatorPositionItem.Visible = True
            BindingNavigatorCountItem.Visible = True
            BindingNavigatorSeparator1.Visible = True
            BindingNavigatorMoveNextItem.Visible = True
            BindingNavigatorMoveLastItem.Visible = True
            lblStatus.Visible = True
        Else
            BindingNavigatorMoveFirstItem.Visible = False
            BindingNavigatorMovePreviousItem.Visible = False
            BindingNavigatorSeparator.Visible = False
            BindingNavigatorPositionItem.Visible = False
            BindingNavigatorCountItem.Visible = False
            BindingNavigatorSeparator1.Visible = False
            BindingNavigatorMoveNextItem.Visible = False
            BindingNavigatorMoveLastItem.Visible = False
            lblStatus.Visible = False
        End If
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles VistaDinamica.Click
        TabMenus.Location = New Point(-8, -50)
        TabMenus.Size = New Size(1026, 684)
        TabMenus.SelectedIndex = 1

        btnFiltrar.Visible = False
        btnEspecificaciones.Visible = False
        btnImagenes.Visible = False
        BindingNavigatorSeparator2.Visible = False
        ToolStripSeparator2.Visible = False
        OptionVisibleBingingNavigator()

        TabArticulos.SelectedIndex = 0
        VistaTabla.Image = My.Resources.listviewgray
        VistaDinamica.Image = My.Resources.imagevieworange
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        If FlowSubCategoria.Controls.Count = 0 Then
            TabArticulos.SelectedIndex = 1
        Else
            TabArticulos.SelectedIndex = 2
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If FlowCategorias.Controls.Count = 0 Then
            TabArticulos.SelectedIndex = 0
        Else
            TabArticulos.SelectedIndex = 1
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        TabArticulos.SelectedIndex = 0
    End Sub

    Private Sub ListControl1_CurrentTag(TagValue As String) Handles ListControl1.CurrentTag
        LlenarFormularios()
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = Keys.Up Then
            e.Handled = True
        ElseIf e.KeyCode = Keys.Down Then
            e.Handled = True
        End If
    End Sub

    Private Sub PicBoxLogo_Click(sender As Object, e As EventArgs) Handles PicBoxLogo.Click
        Clipboard.SetText(cmd.CommandText)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbPredictivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbPredictivo.CheckedChanged
        txtBuscar.Focus()
        txtBuscar.SelectAll()
    End Sub

    Private Sub GotoSubCat(Sender As Object, e As EventArgs)
        If TypeOf DirectCast(Sender, Control) Is PictureBox Then
            Dim DsTemp As New DataSet

            FlowSubCategoria.Controls.Clear()

            DsTemp.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDSubCategoria,SubCategoria,SubCategoriaFilePath FROM libregco.subcategoria where IDCategoria='" + DirectCast(Sender, PictureBox).Tag.ToString + "' ORDER BY SubCategoria ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "SubCategoria")

            Dim Tabla As DataTable = DsTemp.Tables("SubCategoria")

            For Each itm As DataRow In Tabla.Rows
                Dim DMen As New DinamicMenu

                DMen.ParentID = itm(0)
                DMen.TypeParent = 0
                DMen.Description = itm(1)
                DMen.Height = CInt(FlowSubCategoria.Height) - 25
                DMen.Width = CInt(FlowSubCategoria.Width / 4)
                DMen.IsCollapsable = False
                DMen.Picture.Tag = itm(0)

                Dim ExistFile As Boolean = System.IO.File.Exists(itm(2))
                If ExistFile = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(itm(2), FileMode.Open, FileAccess.Read)
                    DMen.PutImage = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                Else
                    DMen.PutImage = My.Resources.No_Image
                End If

                Dim Dstemp1 As New DataSet
                cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.Articulos where IDSubCategoria='" + DMen.ParentID.ToString + "' ORDER BY Descripcion ASC LIMIT 50", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Dstemp1, "Articulos")

                Dim TablaArticulos As DataTable = Dstemp1.Tables("Articulos")

                DMen.RowsIndeed = TablaArticulos

                AddHandler DMen.Picture.Click, AddressOf FillArticulos
                FlowSubCategoria.Controls.Add(DMen)
            Next

            ConLibregco.Close()
            DsTemp.Dispose()
            TabArticulos.SelectedIndex = 2

        End If
    End Sub

    Private Sub FillArticulos(Sender As Object, e As EventArgs)
        If TypeOf DirectCast(Sender, Control) Is PictureBox Then
            ListControl1.Clear()

            Ds1.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT Articulos.IDArticulo,Descripcion,Referencia,Articulos.RutaFoto,Articulos.IDMarca,Marca.Marca,Precio3,Precio4,Promocion,ExistenciaTotal from Libregco.Articulos INNER JOIN Libregco.PrecioArticulo on Articulos.IDArticulo=PrecioArticulo.IDArticulo INNER JOIN Libregco.Marca on Articulos.IDMarca=Marca.IDMarca Where IDSubCategoria='" + DirectCast(Sender, PictureBox).Tag.ToString + "' ORDER BY Descripcion ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Articulos")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds1.Tables("Articulos")
            Dim ImagePic As Image

            For Each itm As DataRow In Tabla.Rows

                If System.IO.File.Exists(itm("RutaFoto")) Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(itm("RutaFoto"), FileMode.Open, FileAccess.Read)
                    ImagePic = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                Else
                    ImagePic = My.Resources.No_Image
                End If

                ListControl1.Add(itm("IDArticulo"), itm("Descripcion"), itm("Marca"), itm("Referencia"), CDbl(itm("Precio3")).ToString("C"), If(itm("Promocion") = 1, True, False), CDbl(itm("Precio4")).ToString("C"), "Envíos sólo a Santiago y Santo Domingo", If(CDbl(itm("ExistenciaTotal")) < 10, "Quedan pocas unidades", "Hay más de 15 unidades disponibles"), ImagePic, If(itm("Promocion") = 1, True, False))

            Next

            Ds1.Clear()
            TabArticulos.SelectedIndex = 3
        End If



    End Sub

    Private Sub GotoMessage(Sender As Object, e As EventArgs)
        If TypeOf DirectCast(Sender, Control) Is DataGridView Then
            Dim DsTemp As New DataSet

            FlowSubCategoria.Controls.Clear()

            DsTemp.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDSubCategoria,SubCategoria,SubCategoriaFilePath FROM libregco.subcategoria where IDCategoria='" + DirectCast(Sender, DataGridView).CurrentRow.Cells(0).Value.ToString + "' ORDER BY SubCategoria ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "SubCategoria")

            Dim Tabla As DataTable = DsTemp.Tables("SubCategoria")

            For Each itm As DataRow In Tabla.Rows
                Dim DMen As New DinamicMenu

                DMen.ParentID = itm(0)
                DMen.Picture.Tag = itm(0)
                DMen.TypeParent = 0
                DMen.Description = itm(1)
                DMen.Height = CInt(FlowSubCategoria.Height) - 25
                DMen.Width = CInt(FlowSubCategoria.Width / 4)
                DMen.Picture.Tag = itm(0)
                DMen.IsCollapsable = False

                Dim ExistFile As Boolean = System.IO.File.Exists(itm(2))
                If ExistFile = True Then
                    Dim wFile As System.IO.FileStream
                    wFile = New FileStream(itm(2), FileMode.Open, FileAccess.Read)
                    DMen.PutImage = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                Else
                    DMen.PutImage = My.Resources.No_Image
                End If

                Dim Dstemp1 As New DataSet
                cmd = New MySqlCommand("SELECT IDArticulo,Descripcion FROM libregco.Articulos where IDSubCategoria='" + DMen.ParentID.ToString + "' ORDER BY Descripcion ASC LIMIT 50", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Dstemp1, "Articulos")

                Dim TablaArticulos As DataTable = Dstemp1.Tables("Articulos")

                DMen.RowsIndeed = TablaArticulos

                AddHandler DMen.Picture.Click, AddressOf FillArticulos
                FlowSubCategoria.Controls.Add(DMen)
            Next

            ConLibregco.Close()
            TabArticulos.SelectedIndex = 2

        ElseIf TypeOf DirectCast(Sender, Control) Is PictureBox Then

            Dim DsTemp As New DataSet

            FlowCategorias.Controls.Clear()

            DsTemp.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("Select IDCategoria,Categoria,CategoriaFilePath FROM libregco.categoria where IDDepartamento='" + DirectCast(Sender, PictureBox).Tag.ToString + "' ORDER BY Categoria ASC", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Categoria")

            Dim Tabla As DataTable = DsTemp.Tables("Categoria")

            For Each itm As DataRow In Tabla.Rows
                Dim DMen As New DinamicMenu

                DMen.ParentID = itm(0)
                DMen.TypeParent = 0
                DMen.Description = itm(1)
                DMen.Height = CInt(FlowCategorias.Height) - 25
                DMen.Width = CInt(FlowCategorias.Width / 5)
                DMen.Picture.Tag = itm(0)

                Dim ExistFile As Boolean = System.IO.File.Exists(itm(2))
                If ExistFile = True Then
                    Dim wFile As System.IO.FileStream
                    lblNotaImagen.Visible = False
                    wFile = New FileStream(itm(2), FileMode.Open, FileAccess.Read)
                    DMen.PutImage = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                Else
                    DMen.PutImage = My.Resources.No_Image
                End If



                Dim Dstemp1 As New DataSet
                cmd = New MySqlCommand("SELECT IDSubCategoria,SubCategoria FROM libregco.subcategoria where IDCategoria='" + DMen.ParentID.ToString + "' ORDER BY SubCategoria ASC", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Dstemp1, "SubCategoria")

                Dim TablaSubCategoria As DataTable = Dstemp1.Tables("SubCategoria")

                DMen.RowsIndeed = TablaSubCategoria

                AddHandler DMen.DgvCategorias.Click, AddressOf GotoSubCat
                AddHandler DMen.Picture.Click, AddressOf GotoSubCat
                FlowCategorias.Controls.Add(DMen)
            Next

            ConLibregco.Close()
            TabArticulos.SelectedIndex = 1

        End If

    End Sub
End Class