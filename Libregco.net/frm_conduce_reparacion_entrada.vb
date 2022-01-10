Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_conduce_reparacion_entrada

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend lblIDUsuario, lblIDReparacion, lblNulo As New Label
    Dim Permisos As New ArrayList

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("HH:mm:ss")
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub frm_conduce_reparacion_entrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        Permisos = PasarPermisos(Me.Tag)
        SelectUsuario()
        LimpiarDatos()
        ActualizarTodo()
        ColumnsDgvArticulos()
    End Sub

    Private Sub CargarLibregco()
          PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub ColumnsDgvArticulos()
        DgvArticulos.Columns.Clear()
        With DgvArticulos
            .Columns.Add("EntradaDetalle", "EntradaDetalle") '0
            .Columns.Add("IDReparacionDetalle", "IDReparacionDetalle") '1
            .Columns.Add("IDReparacion", "IDReparacion")    '2
            .Columns.Add("IDPrecio", "IDPrecio")    '3
            .Columns.Add("IDArticulo", "Código")    '4
            .Columns.Add("Descripcion", "Descripción")    '5
            .Columns.Add("IDMedida", "IDMedida")    '6
            .Columns.Add("Medida", "Medida")    '7
            .Columns.Add("Cantidad", "Cant. Pendiente") '8
            .Columns.Add("CantidadDev", "Cant. a Recibir.")   '9
            PropiedadDgvArticulos()
        End With
    End Sub

    Private Sub PropiedadDgvArticulos()

        Dim DatagridWith As Double = (DgvArticulos.Width - DgvArticulos.RowHeadersWidth) / 100

        With DgvArticulos
            .Columns(0).Visible = False

            .Columns(1).Visible = False

            .Columns(2).Visible = False

            .Columns(3).Visible = False

            .Columns(4).Width = DatagridWith * 15
            .Columns(4).ReadOnly = True

            .Columns(5).Width = DatagridWith * 45
            .Columns(5).HeaderText = "Descripción"
            .Columns(5).ReadOnly = True

            .Columns(6).Visible = False

            .Columns(7).Width = DatagridWith * 10
            .Columns(7).ReadOnly = True

            .Columns(8).Width = DatagridWith * 15
            .Columns(8).ReadOnly = True

            .Columns(9).Width = DatagridWith * 15

        End With
    End Sub

    Private Sub LimpiarDatos()
        txtReparacion.Clear()
        txtTipoOrden.Clear()
        txtStatusOrden.Clear()
        txtMotivoGeneral.Clear()
        txtIDSuplidor.Clear()
        txtNombreSuplidor.Clear()
        txtBalanceSup.Clear()
        txtUltimoMonto.Clear()
        txtUltimoPago.Clear()
        txtIDEntrada.Clear()
        txtSecondID.Clear()
        txtFecha.Clear()
        txtHora.Clear()
        txtObservaciones.Clear()
        DgvArticulos.Rows.Clear()
    End Sub

    Private Sub ActualizarTodo()
        txtFecha.Text = Today.ToString("yyyy-MM-dd")
        chkNulo.Checked = False
        lblStatusBar.Text = "Listo"
        lblNulo.Text = 0
        lblStatusBar.ForeColor = Color.Black
        HabilitarControles()
        txtReparacion.Focus()
    End Sub

    Private Sub HabilitarControles()
        txtReparacion.Enabled = True
        txtObservaciones.Enabled = True
        DgvArticulos.Enabled = True
        btnBuscarReparacion.Enabled = True
        FactStatus()
    End Sub

    Private Sub Deshabilitarcontroles()
        txtReparacion.Enabled = False
        txtObservaciones.Enabled = False
        DgvArticulos.Enabled = False
        btnBuscarReparacion.Enabled = False
        FactStatus()
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub SelectUsuario()
        Try
            lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()

            Con.Open()
            cmd = New MySqlCommand("Select Login from Empleados Where IDEmpleado = '" + lblIDUsuario.Text + "'", Con)
            GbxUserInfo.Text = "User Info --> " & Convert.ToString(cmd.ExecuteScalar()) & " [" & lblIDUsuario.Text & "]"
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Sub RefrescarDgvArticulos()
        Try
            DgvArticulos.Rows.Clear()
            Con.Open()

            If txtIDEntrada.Text = "" Then
                Dim Cmd As New MySqlCommand("SELECT ReparacionDetalle.IDReparacionDetalle,ReparacionDetalle.IDReparacion,ReparacionDetalle.IDPrecio,ReparacionDetalle.IDArticulo,ReparacionDetalle.Descripcion,ReparacionDetalle.IDMedida,ReparacionDetalle.Medida,ReparacionDetalle.Cantidad FROM reparaciondetalle Where ReparacionDetalle.IDReparacion='" + lblIDReparacion.Text + "'", Con)
                Dim LectorArticulos As MySqlDataReader = Cmd.ExecuteReader

                While LectorArticulos.Read
                    DgvArticulos.Rows.Add("", LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), 0)
                End While
                LectorArticulos.Close()
            Else
                Dim Cmd As New MySqlCommand("SELECT EntradaReparacionDetalle.IDEntradaReparacionDetalle,EntradaReparacionDetalle.IDReparacionDetalle,EntradaReparacion.IDReparacion,EntradaReparacionDetalle.IDPrecio,EntradaReparacionDetalle.IDArticulo,EntradaReparacionDetalle.Descripcion,EntradaReparacionDetalle.IDMedida,EntradaReparacionDetalle.Medida,CantidadPendiente,CantidadRecibida FROM entradareparaciondetalle INNER JOIN EntradaReparacion on EntradaReparacionDetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion INNER JOIN ReparacionDetalle on EntradaReparacionDetalle.IDReparacionDetalle=ReparacionDetalle.IDReparacionDetalle Where EntradaReparacionDetalle.IDEntradaReparacion='" + txtIDEntrada.Text + "'", Con)
                Dim LectorArticulos As MySqlDataReader = Cmd.ExecuteReader

                While LectorArticulos.Read
                    DgvArticulos.Rows.Add(LectorArticulos.GetValue(0), LectorArticulos.GetValue(1), LectorArticulos.GetValue(2), LectorArticulos.GetValue(3), LectorArticulos.GetValue(4), LectorArticulos.GetValue(5), LectorArticulos.GetValue(6), LectorArticulos.GetValue(7), LectorArticulos.GetValue(8), LectorArticulos.GetValue(9))
                End While
                LectorArticulos.Close()
            End If

            Con.Close()
            PropiedadDgvArticulos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub btnBuscarReparacion_Click(sender As Object, e As EventArgs) Handles btnBuscarReparacion.Click
        Try
            If txtReparacion.Text = "" Then
                MessageBox.Show("Escriba el número de la reparación en la que desea generar el conduce de recepción de reparación.", "No. de reparación vacío", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                frm_consulta_conduce_reparacion.ShowDialog(Me)
            Else
                Con.Open()
                cmd = New MySqlCommand("Select IDReparacion from Reparacion Where SecondID='" + txtReparacion.Text + "'", Con)
                lblIDReparacion.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If lblIDReparacion.Text = "" Then
                    MessageBox.Show("No se encontró ningun resultado en la búsqueda.", "No existe reparación con esa numeración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    BuscarDatosdeReparacion()
                    RefrescarDgvArticulos()
                    BuscarEntradas()
                    FactStatus()
                End If

            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub BuscarEntradas()

        Try
            Dim x As Integer = 0
            Dim IDArticulo, IDReparacion, CantRecibida As New Label

Inicio:
            If x = DgvArticulos.Rows.Count Then
                GoTo Fin
            End If

            IDReparacion.Text = DgvArticulos.Rows(x).Cells(2).Value
            IDArticulo.Text = DgvArticulos.Rows(x).Cells(4).Value
            CantRecibida.Text = DgvArticulos.Rows(x).Cells(9).Value

            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT EntradaReparacionDetalle.IDEntradaReparacion,EntradaReparacionDetalle.IDArticulo,CantidadRecibida FROM EntradaReparacionDetalle INNER JOIN EntradaReparacion on EntradaReparacionDetalle.IDEntradaReparacion=EntradaReparacion.IDEntradaReparacion INNER JOIN Reparacion on EntradaReparacion.IDReparacion=Reparacion.IDReparacion Where Reparacion.SecondID='" + txtReparacion.Text + "' and IDArticulo='" + IDArticulo.Text + "' and Reparacion.Nulo=0", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "EntradaDetalle")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("EntradaDetalle")
            Dim ContarFilas As Integer = Tabla.Rows.Count

            If ContarFilas = 0 Then
                x = x + 1
                GoTo Inicio
            Else
                CantRecibida.Text = Tabla.Compute("Sum(CantidadRecibida)", "")
                DgvArticulos.Rows(x).Cells(8).Value = CDbl(DgvArticulos.Rows(x).Cells(8).Value) - CDbl(CantRecibida.Text)
                lblStatusBar.Text = "El conduce No." & txtReparacion.Text.ToUpper & " ya tiene recepciones."
            End If

            x = x + 1
            GoTo Inicio
Fin:
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
    Sub BuscarDatosdeReparacion()
        Try
            Ds.Clear()
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDReparacion,Reparacion.SecondID,Reparacion.IDTipoDocumento,TipoDocumento.Documento,SecondID,Fecha,Hora,IDUsuario,Usuarios.Nombre as NombreUsuario,Reparacion.IDSuplidor,Suplidor.Suplidor as NombreSuplidor,Suplidor.Balance,ifnull((Select Neto from" & SysName.Text & "PagoCompra where IDSuplidor=Suplidor.IDSuplidor and PagoCompra.Nulo=0 ORDER BY IDPagoCompra DESC LIMIT 1),0) AS UltimoMonto,Reparacion.IDAlmacen,Almacen.Almacen,Reparacion.IDTipoOrden,TipoOrdenReparacion.Descripcion,Reparacion.IDStatusReparacion,StatusReparacion.Descripcion as StatusReparacion,FechaPrometida,Comentario,Motivo,Impreso,Reparacion.Nulo FROM" & SysName.Text & "reparacion INNER JOIN" & SysName.Text & "TipoDocumento on Reparacion.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Empleados as Usuarios on Reparacion.IDUSuario=Usuarios.IDEmpleado INNER JOIN Libregco.Suplidor on Reparacion.IDSuplidor=Suplidor.IDSuplidor INNER JOIN Libregco.TipoOrdenReparacion on Reparacion.IDTipoOrden=TipoOrdenReparacion.IDTipoOrdenReparacion INNER JOIN Libregco.StatusReparacion on Reparacion.IDStatusReparacion=StatusReparacion.IDStatusReparacion INNER JOIN" & SysName.Text & "Almacen on Reparacion.IDAlmacen=Almacen.IDAlmacen Where Reparacion.IDReparacion='" + lblIDReparacion.Text + "'", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Reparacion")
            ConMixta.Close()

            Dim Tabla As DataTable = Ds.Tables("Reparacion")

            If Tabla.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron resultados.", "No se encontró", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                txtIDSuplidor.Text = (Tabla.Rows(0).Item("IDSuplidor"))
                txtNombreSuplidor.Text = (Tabla.Rows(0).Item("NombreSuplidor"))
                txtBalanceSup.Text = CDbl(Tabla.Rows(0).Item("Balance")).ToString("C")
                txtUltimoMonto.Text = (Tabla.Rows(0).Item("UltimoMonto"))
                txtTipoOrden.Text = (Tabla.Rows(0).Item("Descripcion"))
                txtStatusOrden.Text = (Tabla.Rows(0).Item("StatusReparacion"))
                txtMotivoGeneral.Text = (Tabla.Rows(0).Item("Motivo"))
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Sub FactStatus()
        Dim Counter As Integer = DgvArticulos.Rows.Count

        If txtReparacion.Text <> "" Then
            If Counter > 0 Then
                txtReparacion.Enabled = False
                btnBuscarReparacion.Enabled = False
            End If
        Else
            txtReparacion.Enabled = True
            btnBuscarReparacion.Enabled = True
        End If
    End Sub

    Private Sub DgvArticulos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellContentClick
        Try
            If e.RowIndex < 0 Then
                Exit Sub
            End If

            If e.ColumnIndex = 9 Then
                DgvArticulos.EndEdit()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvArticulos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvArticulos.CurrentCellDirtyStateChanged
        If DgvArticulos.IsCurrentCellDirty Then
            DgvArticulos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvArticulos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellClick
        DgvArticulos.EditMode = DataGridViewEditMode.EditOnEnter
    End Sub

    Private Sub DgvArticulos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellValueChanged
        Try

            If e.ColumnIndex = 9 Then
                If DgvArticulos.CurrentRow.Cells(9).Value = "" Then
                    DgvArticulos.CurrentRow.Cells(9).Value = CDbl(0)
                Else
                End If

                If CDbl(DgvArticulos.CurrentRow.Cells(9).Value) > CDbl(DgvArticulos.CurrentRow.Cells(8).Value) Then
                    MessageBox.Show("La cantidad específicada excede la cantidad del conduce.", "Excede la cant. despachada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    DgvArticulos.CurrentRow.Cells(9).Value = CDbl(0)
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = DgvArticulos.CurrentCell.ColumnIndex

        If Columna = 12 Or Columna = 13 Then
            Dim Caracter As Char = e.KeyChar
            Dim Txt As TextBox = CType(sender, TextBox)

            If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Or (Caracter = ".") And (Txt.Text.Contains(",") = False) Then

                e.Handled = False
            Else
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub DgvArticulos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvArticulos.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)

        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            lblNulo.Text = 1
            DeshabilitarControles()
        Else
            lblNulo.Text = 0
            HabilitarControles()
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

    Private Sub UltEntrada()
        Try

            If txtIDEntrada.Text = "" Then
                Con.Open()
                cmd = New MySqlCommand("Select IDEntradaReparacion from EntradaReparacion where IDEntradaReparacion= (Select Max(IDEntradaReparacion) from EntradaReparacion)", Con)
                txtIDEntrada.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub InsertEntradaDetalle()
        Dim x As Integer = 0
        Dim Counter As Integer = DgvArticulos.Rows.Count
        Dim EntradaDetalle, IDReparacionDetalle, IDReparacion, IDPrecio, IDArticulo, Descripcion, IDMedida, Medida, CantidadPendiente, CantidadRecibida As New Label

Inicio:
        If x = Counter Then
            GoTo Fin
        End If

        EntradaDetalle.Text = DgvArticulos.Rows(x).Cells(0).Value
        IDReparacionDetalle.Text = DgvArticulos.Rows(x).Cells(1).Value
        IDReparacion.Text = DgvArticulos.Rows(x).Cells(2).Value
        IDPrecio.Text = DgvArticulos.Rows(x).Cells(3).Value
        IDArticulo.Text = DgvArticulos.Rows(x).Cells(4).Value
        Descripcion.Text = DgvArticulos.Rows(x).Cells(5).Value
        IDMedida.Text = DgvArticulos.Rows(x).Cells(6).Value
        Medida.Text = DgvArticulos.Rows(x).Cells(7).Value
        CantidadPendiente.Text = DgvArticulos.Rows(x).Cells(8).Value
        CantidadRecibida.Text = DgvArticulos.Rows(x).Cells(9).Value

        If EntradaDetalle.Text = "" Then
            If CDbl(CantidadRecibida.Text) > CDbl(0) Then
                sqlQ = "INSERT INTO EntradaReparacionDetalle (IDEntradaReparacion,IDReparacionDetalle,IDPrecio,IDArticulo,Descripcion,IDMedida,Medida,CantidadPendiente,CantidadRecibida) VALUES ('" + txtIDEntrada.Text + "','" + IDReparacionDetalle.Text + "','" + IDPrecio.Text + "','" + IDArticulo.Text + "','" + Descripcion.Text + "','" + IDMedida.Text + "','" + Medida.Text + "','" + CantidadPendiente.Text + "','" + CantidadRecibida.Text + "')"
                GuardarDatos()
            End If
        Else
            If CDbl(CantidadRecibida.Text) > 0 Then
                sqlQ = "UPDATE EntradaReparacionDetalle SET IDEntradaReparacion='" + txtIDEntrada.Text + "',IDReparacionDetalle='" + IDReparacionDetalle.Text + "',IDPrecio='" + IDPrecio.Text + "',IDArticulo='" + IDArticulo.Text + "',Descripcion='" + Descripcion.Text + "',IDMedida='" + IDMedida.Text + "',Medida='" + Medida.Text + "',CantidadPendiente='" + CantidadPendiente.Text + "',CantidadRecibida='" + CantidadRecibida.Text + "' WHERE IDEntradaReparacionDetalle='" + IDReparacionDetalle.Text + "'"
                GuardarDatos()
            ElseIf CDbl(CantidadRecibida.Text) = 0 Then
                sqlQ = "Delete from EntradaReparacionDetalle WHERE IDEntradaReparacionDetalle='" + IDReparacionDetalle.Text + "'"
                GuardarDatos()
            End If
        End If

        x = x + 1
        GoTo Inicio
Fin:
    End Sub

    Private Sub ImprimirDocumento()
        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDEntrada.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea imprimir el recibo de recepción de mercancía?", "Imprimir Conduce de Entrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
        ActualizarTodo()
    End Sub

    Private Sub btnGuardaryLimpiar_Click(sender As Object, e As EventArgs) Handles btnGuardaryLimpiar.Click
        Dim ItemsDevueltos As Double = 0
        For Each Rows As DataGridViewRow In DgvArticulos.Rows
            ItemsDevueltos = ItemsDevueltos + (CDbl(Rows.Cells(9).Value))
        Next

        If txtReparacion.Text = "" Then
            MessageBox.Show("Escriba el No. de reparación  buscar para procesar la entrada de conduces.", "Escriba el Número del Conduce", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtReparacion.Focus()
            Exit Sub
        ElseIf ItemsDevueltos = 0 Then
            MessageBox.Show("No se han específicado artículos para entradas de reparación.", "Especificar Cant. a devolver", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDEntrada.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el conduce de recepción de reparación No. " & txtReparacion.Text & " en la base de datos?", "Guardar Nueva Recepción", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO EntradaReparacion (IDTipoDocumento,IDUsuario,Fecha,Hora,IDSucursal,IDAlmacen,IDReparacion,Observaciones,Impreso,Nulo) VALUES (40,'" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDReparacion.Text + "','" + txtObservaciones.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                UltEntrada()
                SetSecondID()
                InsertEntradaDetalle()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                btnNuevo.PerformClick()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el conduce?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE EntradaReparacion SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDReparacion='" + lblIDReparacion.Text + "',Observaciones='" + txtObservaciones.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDEntradaReparacion= (" + txtIDEntrada.Text + ")"
                GuardarDatos()
                InsertEntradaDetalle()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                btnNuevo.PerformClick()
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim ItemsDevueltos As Double = 0
        For Each Rows As DataGridViewRow In DgvArticulos.Rows
            ItemsDevueltos = ItemsDevueltos + (CDbl(Rows.Cells(9).Value))
        Next

        If txtReparacion.Text = "" Then
            MessageBox.Show("Escriba el No. de reparación  buscar para procesar la entrada de conduces.", "Escriba el Número del Conduce", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtReparacion.Focus()
            Exit Sub
        ElseIf ItemsDevueltos = 0 Then
            MessageBox.Show("No se han específicado artículos para entradas de reparación.", "Especificar Cant. a devolver", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If txtIDEntrada.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el conduce de recepción de reparación No. " & txtReparacion.Text & " en la base de datos?", "Guardar Nueva Recepción", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO EntradaReparacion (IDTipoDocumento,IDUsuario,Fecha,Hora,IDSucursal,IDAlmacen,IDReparacion,Observaciones,Impreso,Nulo) VALUES (40,'" + lblIDUsuario.Text + "','" + txtFecha.Text + "','" + txtHora.Text + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','" + lblIDReparacion.Text + "','" + txtObservaciones.Text + "',0,'" + lblNulo.Text + "')"
                GuardarDatos()
                UltEntrada()
                SetSecondID()
                InsertEntradaDetalle()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
                Deshabilitarcontroles()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el conduce?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "UPDATE EntradaReparacion SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDReparacion='" + lblIDReparacion.Text + "',Observaciones='" + txtObservaciones.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDEntradaReparacion= (" + txtIDEntrada.Text + ")"
                GuardarDatos()
                InsertEntradaDetalle()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ImprimirDocumento()
            End If
        End If
    End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=40", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE EntradaReparacion SET SecondID='" + lblSecondID.Text + "' WHERE IDEntradaReparacion='" + txtIDEntrada.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=40"
            GuardarDatos()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub frm_conduce_reparacion_entrada_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Try
            PropiedadDgvArticulos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_conduce_entrada.ShowDialog(Me)
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardar.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click

    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub BuscarDevoluciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarDevoluciónToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AnularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnularToolStripMenuItem.Click
        btnEliminar.PerformClick()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim ItemsDevueltos As Double = 0
        For Each Rows As DataGridViewRow In DgvArticulos.Rows
            ItemsDevueltos = ItemsDevueltos + (CDbl(Rows.Cells(9).Value))
        Next

        If txtReparacion.Text = "" Then
            MessageBox.Show("Escriba el No. de reparación  buscar para procesar la entrada de conduces.", "Escriba el Número del Conduce", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtReparacion.Focus()
            Exit Sub
        ElseIf ItemsDevueltos = 0 Then
            MessageBox.Show("No se han específicado artículos para entradas de reparación.", "Especificar Cant. a devolver", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("La entrada de reparación No. " & txtIDEntrada.Text & " del suplidor " & txtNombreSuplidor.Text & "  ya está anulada en el sistema. Desea activarla?", "Recuperar Entrada de Reparaci{on", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE EntradaReparacion SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDReparacion='" + lblIDReparacion.Text + "',Observaciones='" + txtObservaciones.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDEntradaReparacion= (" + txtIDEntrada.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        ElseIf txtIDEntrada.Text = "" Then
            MessageBox.Show("No hay un registro de entrada de reparación abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular la entrada de reparación No. " & txtIDEntrada.Text & " del suplidor " & txtNombreSuplidor.Text & " del sistema?", "Anular Entrada", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE EntradaReparacion SET IDUsuario='" + lblIDUsuario.Text + "',Fecha='" + txtFecha.Text + "',Hora='" + txtHora.Text + "',IDSucursal='" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "',IDAlmacen='" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',IDReparacion='" + lblIDReparacion.Text + "',Observaciones='" + txtObservaciones.Text + "',Nulo='" + lblNulo.Text + "' WHERE IDEntradaReparacion= (" + txtIDEntrada.Text + ")"
                GuardarDatos()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub
End Class