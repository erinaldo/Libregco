Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_conduce_reparaciones

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend IDArticulo, lblIDUsuario, lblIDTipoOrden, lblIDStatusReparacion, lblIDMedida, lblIDPrecio, lblCheckDuplicates, lblDesactivar As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_conduce_reparaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        ColumnasDgvArticulos()
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub LimpiarDatos()
        txtIDSuplidor.Clear()
        txtNombreSuplidor.Clear()
        txtBalanceSup.Clear()
        txtUltimoMonto.Clear()
        txtUltimoPago.Clear()
        txtIDReparacion.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        txtSecondID.Clear()
        txtMotivo.Clear()
        txtComentario.Clear()
        cbxTipoOrden.Items.Clear()
        cbxStatus.Items.Clear()
        lblIDTipoOrden.Text = ""
        lblIDStatusReparacion.Text = ""
        IDArticulo.Text = ""
        txtConcepto.Clear()
    End Sub

    Private Sub ActualizarTodo()
        lblDesactivar.Text = 0
        lblStatusBar.ForeColor = Color.Black
        lblStatusBar.Text = "Listo"
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        DtpFechaPrometida.Value = Today
        FillTipoOrden()
        FillStatus()
        cbxStatus.Text = "No Recibida"
        dgvArticulosFactura.Rows.Clear()
        HabilitarControles()
        cbxStatus.Enabled = False
        btnBuscarSup.Focus()
    End Sub

    Private Sub FillTipoOrden()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM TipoOrdenReparacion Where Nulo=0", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoOrdenReparacion")
        cbxTipoOrden.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoOrdenReparacion")
        For Each Fila As DataRow In Tabla.Rows
            cbxTipoOrden.Items.Add(Fila.Item("Descripcion"))
        Next

    End Sub

    Private Sub FillStatus()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM StatusReparacion Where Nulo=0", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "StatusReparacion")
        cbxStatus.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("StatusReparacion")
        For Each Fila As DataRow In Tabla.Rows
            cbxStatus.Items.Add(Fila.Item("Descripcion"))
        Next
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
      PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ColumnasDgvArticulos()
        dgvArticulosFactura.Columns.Clear()
        With dgvArticulosFactura
            .Columns.Add("IDArt", "ID Art")   '0
            .Columns.Add("IDReparacion", "ID Reparacion") '1
            .Columns.Add("IDPrecios", "ID Precio") '2
            .Columns.Add("IDMedida", "ID Medida")   '3
            .Columns.Add("Cantidad", "Cant.")       '4
            .Columns.Add("Medida", "Medida")        '5
            .Columns.Add("IDArticulo", "Código")    '6
            .Columns.Add("Descripcion", "Descripción")  '7
            .Columns.Add("Concepto", "Concepto") '8
            PropiedadesDgvArticulos()
        End With
    End Sub

    Sub PropiedadesDgvArticulos()
        Try
            Dim Condicion As String = False
            Dim DatagridWidth As Double = (dgvArticulosFactura.Width - dgvArticulosFactura.RowHeadersWidth) / 100

            With dgvArticulosFactura
                .Columns("IDArt").Visible = Condicion
                .Columns("IDReparacion").Visible = Condicion
                .Columns("IDMedida").Visible = Condicion
                .Columns("IDPrecios").Visible = Condicion
                .Columns("Medida").Width = DatagridWidth * 15
                .Columns("Cantidad").HeaderText = "Cant."
                .Columns("Cantidad").Width = DatagridWidth * 7
                .Columns("IDArticulo").Width = DatagridWidth * 8
                .Columns("IDArticulo").HeaderText = "Código"
                .Columns("Descripcion").Width = DatagridWidth * 40
                .Columns("Descripcion").HeaderText = "Descripción"
                .Columns("Concepto").Width = DatagridWidth * 30
            End With

        Catch ex As Exception
        End Try
    End Sub

    Private Sub frm_conduce_reparaciones_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadesDgvArticulos()
    End Sub

    Private Sub btnBuscarSup_Click(sender As Object, e As EventArgs) Handles btnBuscarSup.Click
        frm_buscar_suplidor.ShowDialog(Me)
    End Sub

    Private Sub btnBuscarArticulo_Click(sender As Object, e As EventArgs) Handles btnBuscarArticulo.Click
        frm_buscar_mant_articulos.ShowDialog(Me)
    End Sub

    Sub SetInformacionArticulo()
        Try
            Ds.Clear()
            ConLibregco.Open()
            cmd = New MySqlCommand("SELECT IDArticulo,Descripcion,ExistenciaTotal,RutaFoto FROM Articulos WHERE IDArticulo='" + txtCodigoArticulo.Text + "' or CodigoBarra='" + txtCodigoArticulo.Text + "' or Articulos.Referencia='" + txtCodigoArticulo.Text + "'", ConLibregco)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Articulos")
            ConLibregco.Close()

            Dim Tabla As DataTable = Ds.Tables("Articulos")

            If CInt(Tabla.Rows.Count) = 0 Then
                MessageBox.Show("No se encontró el artículo.", "Producto no encontrado en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtCodigoArticulo.Focus()
            Else
                IDArticulo.Text = (Tabla.Rows(0).Item("IDArticulo"))
                txtDescripcionArticulo.Text = (Tabla.Rows(0).Item("Descripcion"))
                txtCantidadArticulo.Text = 1
                FillMedida()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub FillMedida()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida,Abreviatura FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida INNER JOIN Articulos on PrecioArticulo.IDArticulo=Articulos.IDArticulo Where PrecioArticulo.IDArticulo = '" + IDArticulo.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "PrecioArticulo")
        CbxMedida.Items.Clear()
        ConLibregco.Close()
        Dim Tabla As DataTable = Ds.Tables("PrecioArticulo")
        For Each Fila As DataRow In Tabla.Rows
            CbxMedida.Items.Add(Fila.Item("Abreviatura"))
        Next

        If Tabla.Rows.Count > 0 Then
            CbxMedida.SelectedIndex = 0
        End If
    End Sub

    Private Sub CbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxMedida.SelectedIndexChanged
        SetIDMedida()
        SetPrecioVenta()
    End Sub

    Private Sub SetIDMedida()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT PrecioArticulo.IDMedida FROM precioarticulo INNER JOIN Medida on PrecioArticulo.IDMedida=Medida.IDMedida Where Abreviatura='" + CbxMedida.SelectedItem + "' and PrecioArticulo.Nulo=0", ConLibregco)
        lblIDMedida.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub txtCodigoArticulo_Leave(sender As Object, e As EventArgs) Handles txtCodigoArticulo.Leave
        Try
            If txtCodigoArticulo.Text = "" Then
                LimpiarDatosArticulo2()
            Else
                SetInformacionArticulo()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Sub LimpiarDatosArticulo2() 'Para limpiar si crear error al salir del txtIDCodigoArticulo en el evento Leave
        CbxMedida.Items.Clear()
        txtCantidadArticulo.Clear()
        txtCodigoArticulo.Clear()
        txtDescripcionArticulo.Clear()
        txtCantidadArticulo.Clear()
        lblIDMedida.Text = ""
        lblIDPrecio.Text = ""
    End Sub

    Sub SetPrecioVenta()
        Try
            If txtDescripcionArticulo.Text = "" Then
            Else
                Ds.Clear()
                ConLibregco.Open()
                cmd = New MySqlCommand("SELECT IDPrecios,PrecioContado,PrecioCredito FROM PrecioArticulo WHERE IDArticulo= '" + txtCodigoArticulo.Text + "' AND IDMedida='" + lblIDMedida.Text + "' and PrecioArticulo.Nulo=0", ConLibregco)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(Ds, "PrecioArticulo")
                ConLibregco.Close()

                Dim Tabla As DataTable = Ds.Tables("PrecioArticulo")

                lblIDPrecio.Text = (Tabla.Rows(0).Item("IDPrecios"))

            End If
        Catch ex As Exception
            LimpiarDatosArticulos()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Sub LimpiarDatosArticulos()
        CbxMedida.Items.Clear()
        txtCantidadArticulo.Clear()
        txtCodigoArticulo.Clear()
        txtDescripcionArticulo.Clear()
        txtCantidadArticulo.Clear()
        lblIDMedida.Text = ""
        lblIDPrecio.Text = ""
        IDArticulo.Text = ""
        txtConcepto.Clear()
        txtCodigoArticulo.Focus()
    End Sub

    Private Sub VerificarDuplicados()
        Dim x As Integer = 0

Inicio:
        If x = dgvArticulosFactura.Rows.Count Or dgvArticulosFactura.Rows.Count = 0 Then
            lblCheckDuplicates.Text = 0
            Exit Sub
        End If

        If CInt(dgvArticulosFactura.Rows(x).Cells(2).Value) = CInt(lblIDPrecio.Text) Then
            MessageBox.Show("Este artículo ya se encuentra en la factura con la misma medida." & vbNewLine & "No es posible duplicar la existencia del mismo artículo.", "Producto ya introducido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txtCodigoArticulo.Focus()
            lblCheckDuplicates.Text = 1
            Exit Sub
        Else
            x = x + 1
            GoTo Inicio
        End If

    End Sub

    Private Sub txtCantidadArticulo_Leave(sender As Object, e As EventArgs) Handles txtCantidadArticulo.Leave
        Try
            If txtCantidadArticulo.Text = CStr("") And txtCodigoArticulo.Text <> "" Then
                txtCantidadArticulo.Text = 1
            End If
            If txtCantidadArticulo.Text = 0 Then
                txtCantidadArticulo.Text = 1
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCodigoArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoArticulo.KeyPress
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

    Private Sub btnInsertarArticulo_Click(sender As Object, e As EventArgs) Handles btnInsertarArticulo.Click
        Try

            If txtCodigoArticulo.Text = "" Then
                MessageBox.Show("El producto no es válido para insertar.", "No se encontraron resultados de artículos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                txtCodigoArticulo.Focus()
            Else
                If CbxMedida.Items.Count = 0 Then
                    MessageBox.Show("El artículo " & txtDescripcionArticulo.Text & " no tiene unidades de medidas válidas para registrar. Por favor verifique el artículo e inserte unidades de ventas.", "Medidas no encontradas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    CbxMedida.Focus()
                    Exit Sub
                End If

                VerificarDuplicados()
                If lblCheckDuplicates.Text = 1 Then
                    Exit Sub
                End If

                With dgvArticulosFactura
                    .Rows.Add("", "", lblIDPrecio.Text, lblIDMedida.Text, txtCantidadArticulo.Text, CbxMedida.Text, IDArticulo.Text, txtDescripcionArticulo.Text, txtConcepto.Text)
                End With

                LimpiarDatosArticulos()
                btnModificar.Enabled = True
                txtCodigoArticulo.Focus()

            End If
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub dgvArticulosFactura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulosFactura.CellDoubleClick

        If e.RowIndex >= 0 Then
            Dim Result As MsgBoxResult = MessageBox.Show("Desea eliminar este artículo del conduce?", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If Result = MsgBoxResult.Yes Then
                dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.CurrentRow)
            End If
        End If
    End Sub

    Private Sub dgvArticulosFactura_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvArticulosFactura.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < dgvArticulosFactura.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If dgvArticulosFactura.RowHeadersWidth < CInt(size.Width + 20) Then
                dgvArticulosFactura.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub chkDesactivar_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesactivar.CheckedChanged
        If chkDesactivar.Checked = True Then
            lblDesactivar.Text = 1
            DeshabilitarControles()
        Else
            lblDesactivar.Text = 0
            HabilitarControles()
        End If
    End Sub

    Private Sub HabilitarControles()
        txtCodigoArticulo.Enabled = True
        btnBuscarArticulo.Enabled = True
        txtCantidadArticulo.Enabled = True
        txtDescripcionArticulo.Enabled = True
        dgvArticulosFactura.Enabled = True
        CbxMedida.Enabled = True
        btnInsertarArticulo.Enabled = True
        btnBuscarSup.Enabled = True
        Hora.Enabled = True
        DtpFechaPrometida.Enabled = True
        txtMotivo.Enabled = True
        txtComentario.Enabled = True
        cbxTipoOrden.Enabled = True
        cbxStatus.Enabled = True
        txtConcepto.Enabled = True
    End Sub

    Private Sub DeshabilitarControles()
        txtCodigoArticulo.Enabled = False
        btnBuscarArticulo.Enabled = False
        txtCantidadArticulo.Enabled = False
        txtDescripcionArticulo.Enabled = False
        dgvArticulosFactura.Enabled = False
        CbxMedida.Enabled = False
        btnInsertarArticulo.Enabled = False
        btnBuscarSup.Enabled = False
        Hora.Enabled = False
        DtpFechaPrometida.Enabled = False
        txtMotivo.Enabled = False
        txtComentario.Enabled = False
        cbxTipoOrden.Enabled = False
        cbxStatus.Enabled = False
        txtConcepto.Enabled = False
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=39", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE Reparacion SET SecondID='" + lblSecondID.Text + "' WHERE IDReparacion='" + txtIDReparacion.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=39"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImprimirDocumento()

        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDReparacion.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea imprimir el conduce de reparación?", "Imprimir Conduce", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
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
            Con.Close()
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
        End Try
    End Sub

    Private Sub UltReparacion()
        If txtIDReparacion.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDReparacion from Reparacion where IDReparacion= (Select Max(IDReparacion) from Reparacion)", Con)
            txtIDReparacion.Text = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()
        End If
    End Sub

    Private Sub InsertArticulos()
        Dim IDReparacionArt, IDReparacion, IDPrecio, IDMedida, CantidadArticulos, Medida, IDArticulo, Descripcion, Concepto As New Label

        Dim x As Integer = 0
        Dim Counter As Integer = dgvArticulosFactura.RowCount

Inicio:

        If x = Counter Then
            GoTo Fin
        End If

        IDReparacionArt.Text = dgvArticulosFactura.Rows(x).Cells(0).Value
        IDReparacion.Text = dgvArticulosFactura.Rows(x).Cells(1).Value
        IDPrecio.Text = dgvArticulosFactura.Rows(x).Cells(2).Value
        IDMedida.Text = dgvArticulosFactura.Rows(x).Cells(3).Value
        CantidadArticulos.Text = dgvArticulosFactura.Rows(x).Cells(4).Value
        Medida.Text = dgvArticulosFactura.Rows(x).Cells(5).Value
        IDArticulo.Text = dgvArticulosFactura.Rows(x).Cells(6).Value
        Descripcion.Text = dgvArticulosFactura.Rows(x).Cells(7).Value
        Concepto.Text = dgvArticulosFactura.Rows(x).Cells(8).Value

        If IDReparacion.Text = "" Then
            sqlQ = "INSERT INTO ReparacionDetalle (IDReparacion,IDPrecio,IDArticulo,Descripcion,Cantidad,IDMedida,Medida,Concepto) VALUES ('" + txtIDReparacion.Text + "', '" + IDPrecio.Text + "','" + IDArticulo.Text + "','" + Descripcion.Text + "','" + CantidadArticulos.Text + "','" + IDMedida.Text + "','" + Medida.Text + "','" + Concepto.Text + "')"
            GuardarDatos()
        Else
            sqlQ = "UPDATE ReparacionDetalle SET IDReparacion='" + IDReparacion.Text + "',IDPrecio='" + IDPrecio.Text + "',IDMedida='" + IDMedida.Text + "',Medida='" + Medida.Text + "',Cantidad='" + CantidadArticulos.Text + "',Descripcion='" + Descripcion.Text + "',Concepto='" + Concepto.Text + "' Where IDReparacionDetalle='" + IDReparacionArt.Text + "'"
            GuardarDatos()
        End If

        x = x + 1
        GoTo Inicio
Fin:
    End Sub

    Sub RefrescarTablaConsulta()
        Try
            dgvArticulosFactura.Rows.Clear()
            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT IDReparacionDetalle,IDReparacion,IDPrecio,ReparacionDetalle.IDMedida,Cantidad,Medida.Abreviatura,ReparacionDetalle.IDArticulo,Articulos.Descripcion,ReparacionDetalle.Concepto from ReparacionDetalle INNER JOIN Articulos on ReparacionDetalle.IDArticulo=Articulos.IDArticulo INNER JOIN Medida on ReparacionDetalle.IDMedida=Medida.IDMedida WHERE IDReparacion='" + txtIDReparacion.Text + "'", Con)
            Dim LectorArticulos As MySqlDataReader = Consulta.ExecuteReader

            While LectorArticulos.Read
                dgvArticulosFactura.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8))
            End While

            LectorArticulos.Close()
            Con.Close()
            PropiedadesDgvArticulos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarSup.PerformClick()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub LimpiarArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarArtículosToolStripMenuItem.Click
        btnBlanquear.PerformClick()
    End Sub

    Private Sub QuitarArtículoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarArtículoToolStripMenuItem.Click
        btnQuitarArticulo.PerformClick()
    End Sub

    Private Sub ModificarArtículoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarArtículoToolStripMenuItem.Click
        btnModificar.PerformClick()
    End Sub

    Private Sub BuscarFacturaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarFacturaToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub btnBlanquear_Click(sender As Object, e As EventArgs) Handles btnBlanquear.Click
        Try
            If dgvArticulosFactura.Rows.Count = 0 Then
                MessageBox.Show("No hay productos para eliminar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If txtIDReparacion.Text = "" And dgvArticulosFactura.Rows.Count >= 1 Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea limpiar todos los registros insertados?", "Blanquear Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    dgvArticulosFactura.Rows.Clear()
                    txtCodigoArticulo.Focus()
                    Exit Sub
                End If
            End If

            If txtIDReparacion.Text > 0 And dgvArticulosFactura.Rows.Count >= 1 Then
                MessageBox.Show("No se pueden eliminar todos los artículos ya procesados en una factura.", "Función No Habilitada", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnQuitarArticulo_Click(sender As Object, e As EventArgs) Handles btnQuitarArticulo.Click
        Try
            If dgvArticulosFactura.Rows.Count = 0 Then
                MessageBox.Show("No hay articulos para eliminar.", "No se encontraron registros", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                If txtIDReparacion.Text = "" Then
                    Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el artículo [" & dgvArticulosFactura.CurrentRow.Cells(7).Value & "] del listado?", "Quitar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result = MsgBoxResult.Yes Then
                        dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.CurrentRow)
                    End If
                Else
                    Dim IDReparacionDetalle As New Label
                    IDReparacionDetalle.Text = dgvArticulosFactura.CurrentRow.Cells(0).Value
                    sqlQ = "Delete from ReparacionDetalle Where IDReparacionDetalle= (" + IDReparacionDetalle.Text + ")"
                    GuardarDatos()
                    MessageBox.Show("Se ha eliminado el artículo satisfactoriamente del conduce.", "Artículo eliminado satisfactoriamente", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        Try
            If dgvArticulosFactura.Rows.Count = 0 And txtIDReparacion.Text = "" Then
                MessageBox.Show("No hay artículos para modificar.", "No se encontraron artículos", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If dgvArticulosFactura.Rows.Count > 0 Then
                IDArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(6).Value
                txtCodigoArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(6).Value
                FillMedida()
                txtDescripcionArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(7).Value
                CbxMedida.Text = dgvArticulosFactura.CurrentRow.Cells(5).Value
                lblIDMedida.Text = dgvArticulosFactura.CurrentRow.Cells(3).Value
                txtCantidadArticulo.Text = dgvArticulosFactura.CurrentRow.Cells(4).Value
                lblIDPrecio.Text = dgvArticulosFactura.CurrentRow.Cells(2).Value
                txtConcepto.Text = dgvArticulosFactura.CurrentRow.Cells(8).Value
                dgvArticulosFactura.Rows.Remove(dgvArticulosFactura.CurrentRow)
                btnModificar.Enabled = False
                Exit Sub
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub


    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor para procesar el condude de reparación.", "No se ha específicado el suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSup.PerformClick()
            Exit Sub
        ElseIf dgvArticulosFactura.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran artículos en el conduce.", "No hay artículos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarArticulo.Focus()
            Exit Sub
        End If

        If txtIDReparacion.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo conduce a nombre del suplidor " & txtNombreSuplidor.Text & " [" & txtIDSuplidor.Text & "] en la base de datos?", "Guardar Nuevo Conduce de Reparación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Reparacion (IDTipoDocumento,Fecha,Hora,IDUsuario,IDSuplidor,FechaPrometida,Comentario,Motivo,Impreso,Nulo) VALUES (39,'" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDUsuario.Text + "','" + txtIDSuplidor.Text + "','" + DtpFechaPrometida.Text + "','" + txtComentario.Text + "','" + txtMotivo.Text + "',0,'" + lblDesactivar.Text + "')"
                GuardarDatos()
                UltReparacion()
                SetSecondID()
                InsertArticulos()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
                btnNuevo.PerformClick()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el conduce de reparación?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Reparacion SET IDUsuario='" + lblIDUsuario.Text + "',IDSuplidor='" + txtIDSuplidor.Text + "',FechaPrometida='" + DtpFechaPrometida.Text + "',Comentario='" + txtComentario.Text + "',Motivo='" + txtMotivo.Text + "',Nulo='" + lblDesactivar.Text + "' WHERE IDReparacion= '" + txtIDReparacion.Text + "'"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
                btnNuevo.PerformClick()
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub DtpFechaPrometida_ValueChanged(sender As Object, e As EventArgs) Handles DtpFechaPrometida.ValueChanged
        If txtIDReparacion.Text = "" Then
            If DtpFechaPrometida.Value < Today Then
                MessageBox.Show("La fecha prometida no puede ser menor que hoy. Por favor seleccione una fecha válida.", "Fecha no válida", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DtpFechaPrometida.Value = Today
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor para procesar el condude de reparación.", "No se ha específicado el suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSup.PerformClick()
            Exit Sub
        ElseIf cbxTipoOrden.Text = "" Then
            MessageBox.Show("Seleccione el tipo de orden de reparación.", "Tipo de Reparación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxTipoOrden.Focus()
            cbxTipoOrden.DroppedDown = True
            Exit Sub
        ElseIf dgvArticulosFactura.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran artículos en el conduce.", "No hay artículos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarArticulo.Focus()
            Exit Sub
        ElseIf cbxStatus.Text = "" Then
            MessageBox.Show("Seleccione el status de la reparación.", "Estatus de la reparación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxStatus.Focus()
            cbxStatus.DroppedDown = True
            Exit Sub
        End If

        If txtIDReparacion.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el nuevo conduce a nombre del suplidor " & txtNombreSuplidor.Text & " [" & txtIDSuplidor.Text & "] en la base de datos?", "Guardar Nuevo Conduce de Reparación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO Reparacion (IDTipoDocumento,Fecha,Hora,IDUsuario,IDSuplidor,IDSucursal,IDAlmacen,IDTipoOrden,IDStatusReparacion,FechaPrometida,Comentario,Motivo,Impreso,Nulo) VALUES (39,'" + txtFecha.Text + "','" + txtHora.Text + "','" + lblIDUsuario.Text + "','" + txtIDSuplidor.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDTipoOrden.Text + "','" + lblIDStatusReparacion.Text + "','" + DtpFechaPrometida.Text + "','" + txtComentario.Text + "','" + txtMotivo.Text + "',0,'" + lblDesactivar.Text + "')"
                GuardarDatos()
                UltReparacion()
                SetSecondID()
                InsertArticulos()
                CalcularExistencias()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el conduce de reparación?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE Reparacion SET IDUsuario='" + lblIDUsuario.Text + "',IDSuplidor='" + txtIDSuplidor.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDTipoOrden='" + lblIDTipoOrden.Text + "',IDStatusReparacion='" + lblIDStatusReparacion.Text + "',FechaPrometida='" + DtpFechaPrometida.Text + "',Comentario='" + txtComentario.Text + "',Motivo='" + txtMotivo.Text + "',Nulo='" + lblDesactivar.Text + "' WHERE IDReparacion= '" + txtIDReparacion.Text + "'"
                GuardarDatos()
                CalcularExistencias()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                DeshabilitarControles()
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub CalcularExistencias()
        CalcExistencia()
        CalcExistenciaAlm()
    End Sub

    Private Sub CalcExistenciaAlm()
        Dim IDArticulo, IDPrecio As String

        For Each Row As DataGridViewRow In dgvArticulosFactura.Rows
            IDArticulo = Row.Cells(6).Value
            IDPrecio = Row.Cells(2).Value
            FunctCalcInvAlmacenes(IDArticulo, IDPrecio)
        Next
    End Sub

    Private Sub CalcExistencia()
        Dim IDArticulo As String

        For Each Row As DataGridViewRow In dgvArticulosFactura.Rows
            IDArticulo = Row.Cells(6).Value
            FunctCalcInventarioGral(IDArticulo)
        Next

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_conduce_reparacion.ShowDialog(Me)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If txtIDSuplidor.Text = "" Then
            MessageBox.Show("Seleccione el suplidor para procesar el condude de reparación.", "No se ha específicado el suplidor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarSup.PerformClick()
            Exit Sub
        ElseIf cbxTipoOrden.Text = "" Then
            MessageBox.Show("Seleccione el tipo de orden de reparación.", "Tipo de Reparación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxTipoOrden.Focus()
            cbxTipoOrden.DroppedDown = True
            Exit Sub
        ElseIf dgvArticulosFactura.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran artículos en el conduce.", "No hay artículos para facturar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            btnBuscarArticulo.Focus()
            Exit Sub
        ElseIf cbxStatus.Text = "" Then
            MessageBox.Show("Seleccione el status de la reparación.", "Estatus de la reparación", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxStatus.Focus()
            cbxStatus.DroppedDown = True
            Exit Sub
        End If

        If Permisos(1) = 0 Then
            MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkDesactivar.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El conduce de reparación No. " & txtIDReparacion.Text & " del suplidor " & txtNombreSuplidor.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Conduce de Reparación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkDesactivar.Checked = False
                sqlQ = "UPDATE Reparacion SET IDUsuario='" + lblIDUsuario.Text + "',IDSuplidor='" + txtIDSuplidor.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',TipoOrden='" + lblIDTipoOrden.Text + "',IDStatusReparacion='" + lblIDStatusReparacion.Text + "',FechaPrometida='" + DtpFechaPrometida.Text + "',Comentario='" + txtComentario.Text + "',Motivo='" + txtMotivo.Text + "',Nulo='" + lblDesactivar.Text + "' WHERE IDReparacion= '" + txtIDReparacion.Text + "'"
                GuardarDatos()
                CalcularExistencias()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDReparacion.Text = "" Then
            MessageBox.Show("No hay un registro de conduce de reparación abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el conduce de reparación No. " & txtIDReparacion.Text & " del suplidor " & txtNombreSuplidor.Text & " del sistema?", "Anular Conduce", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkDesactivar.Checked = True
                sqlQ = "UPDATE Reparacion SET IDUsuario='" + lblIDUsuario.Text + "',IDSuplidor='" + txtIDSuplidor.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',TipoOrden='" + lblIDTipoOrden.Text + "',IDStatusReparacion='" + lblIDStatusReparacion.Text + "',FechaPrometida='" + DtpFechaPrometida.Text + "',Comentario='" + txtComentario.Text + "',Motivo='" + txtMotivo.Text + "',Nulo='" + lblDesactivar.Text + "' WHERE IDReparacion= '" + txtIDReparacion.Text + "'"
                GuardarDatos()
                CalcularExistencias()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub cbxTipoOrden_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoOrden.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDTipoOrdenReparacion FROM TipoOrdenReparacion WHERE Descripcion= '" + cbxTipoOrden.SelectedItem + "'", Con)
        lblIDTipoOrden.Text = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT AfectaInventario FROM TipoOrdenReparacion WHERE Descripcion= '" + cbxTipoOrden.SelectedItem + "'", Con)
        Dim AfectaNcf As String = Convert.ToString(cmd.ExecuteScalar())

        If txtIDReparacion.Text = "" Then
            If AfectaNcf = 1 Then
                lblStatusBar.Text = "Esta reparación afectará al inventario."
                lblStatusBar.ForeColor = Color.Red
            Else
                lblStatusBar.Text = "Esta reparación NO afectará al inventario."
                lblStatusBar.ForeColor = Color.Blue
            End If
        Else
            If AfectaNcf = 1 Then
                lblStatusBar.Text = "Esta reparación está afectando al inventario."
                lblStatusBar.ForeColor = Color.Red
            Else
                lblStatusBar.Text = "Esta reparación NO está afectando al inventario."
                lblStatusBar.ForeColor = Color.Blue
            End If
        End If

        Con.Close()
    End Sub

    Private Sub cbxStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxStatus.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDStatusReparacion FROM StatusReparacion WHERE Descripcion= '" + cbxStatus.SelectedItem + "'", ConLibregco)
        lblIDStatusReparacion.Text = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
    End Sub

    Private Sub BuscarArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarArtículosToolStripMenuItem.Click
        frm_buscar_mant_articulos.Show(Me)
    End Sub
End Class