Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_consulta_numero_recibo

    Dim sqlQ As String=""
    Dim Ds, Ds1 As New DataSet
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim ChkCerrar As New DataGridViewCheckBoxColumn
    Dim Permisos As New ArrayList
    Dim Connon As New MySqlConnection(CnString)

    Private Sub frm_consulta_numero_recibo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        LimpiarTxtBuscar()
        CreateColumns()
        cmd = New MySqlCommand("Select IDReciboCobro,NoEntrega,RecibosCobro.Fecha,PreRecibo,NoRecibo,TipoRecibos.Descripcion,RecibosCobro.Monto,RecibosCobro.Cierre from RecibosCobro INNER JOIN Entregacobro on RecibosCobro.IDEntregaCobro=EntregaCobro.IDEntregaCobro INNER JOIN TipoRecibos on RecibosCobro.IDTipoRecibo=TipoRecibos.IDTipoRecibo Where RecibosCobro.IDCierre GROUP BY IDReciboCobro ORDER BY NoRecibo LIMIT 50", Con)
        RefrescarTabla()
    End Sub

    Private Sub CargarEmpresa()
     PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            DgvRecibos.Rows.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select RecibosCobro.IDReciboCobro,NoEntrega,RecibosCobro.Fecha,PreRecibo,NoRecibo,TipoRecibos.Descripcion,RecibosCobro.Monto,RecibosCobro.Cierre from" & SysName.Text & "RecibosCobro INNER JOIN" & SysName.Text & "Entregacobro on RecibosCobro.IDEntregaCobro=EntregaCobro.IDEntregaCobro INNER JOIN Libregco.TipoRecibos on RecibosCobro.IDTipoRecibo=TipoRecibos.IDTipoRecibo INNER JOIN" & SysName.Text & "RecibosDetalle on RecibosCobro.IDReciboCobro=RecibosDetalle.IDReciboCobro INNER JOIN" & SysName.Text & "Pagares on RecibosDetalle.IDPagare=Pagares.IDPagare INNER JOIN" & SysName.Text & "FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente where NoRecibo like '%" + txtBuscar.Text + "%' and RecibosCobro.IDCierre is null and Clientes.IDEmpleado='" + txtIDCobrador.Text + "' GROUP BY RecibosDetalle.IDReciboCobro UNION ALL Select RecibosCobro.IDReciboCobro,NoEntrega,RecibosCobro.Fecha,PreRecibo,NoRecibo,TipoRecibos.Descripcion,RecibosCobro.Monto,RecibosCobro.Cierre from" & SysName.Text & "RecibosCobro INNER JOIN" & SysName.Text & "Entregacobro on RecibosCobro.IDEntregaCobro=EntregaCobro.IDEntregaCobro INNER JOIN Libregco.TipoRecibos on RecibosCobro.IDTipoRecibo=TipoRecibos.IDTipoRecibo INNER JOIN" & SysName.Text & "RecibosDetalle on RecibosCobro.IDReciboCobro=RecibosDetalle.IDReciboCobro INNER JOIN" & SysName.Text & "Pagares on RecibosDetalle.IDPagare=Pagares.IDPagare INNER JOIN" & SysName.Text & "FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Clientes on FacturaDatos.IDCliente=Clientes.IDCliente Where NoRecibo like '%" + txtBuscar.Text + "%' AND RecibosCobro.IDCierre='" + txtIDGrupo.Text + "' and Clientes.IDEmpleado='" + txtIDCobrador.Text + "' GROUP BY RecibosDetalle.IDReciboCobro ORDER BY NoRecibo ASC LIMIT 50", Con)

            Dim LectorReciboss As MySqlDataReader = cmd.ExecuteReader
            While LectorReciboss.Read
                DgvRecibos.Rows.Add(LectorReciboss.GetValue(0), LectorReciboss.GetValue(1), CDate(LectorReciboss.GetValue(2)).ToString("dd/MM/yyyy"), LectorReciboss.GetValue(3), LectorReciboss.GetValue(4), LectorReciboss.GetValue(5), LectorReciboss.GetValue(6), CBool(LectorReciboss.GetValue(7)))
            End While

            LectorReciboss.Close()
            Con.Close()

            PropiedadColumnsDvg()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub LimpiarTxtBuscar()
        txtBuscar.Clear()
        HabilitarDgv()
        txtBuscar.Focus()
    End Sub

    Private Sub CreateColumns()
        With DgvRecibos
            .Columns.Clear()
            .Columns.Add("IDReciboCobro", "Código") '0
            .Columns.Add("NoEntrega", "No. Entrega") '1
            .Columns.Add("Fecha", "Fecha") '2
            .Columns.Add("PreRecibo", "") '3
            .Columns.Add("NoRecibo", "No. Recibo") '4
            .Columns.Add("Descripcion", "Tipo de Recibo") '5
            .Columns.Add("Monto", "Monto") '6
            .Columns.Add(ChkCerrar) '7
        End With

        PropiedadColumnsDvg()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvRecibos
            .Columns(0).Width = 100
            .Columns(0).ReadOnly = True
            .Columns(0).HeaderText = "Código"
            .Columns(0).DefaultCellStyle.BackColor = Color.LightGray
            .Columns(1).Width = 100
            .Columns(1).ReadOnly = True
            .Columns(1).HeaderText = "No. Entrega"
            .Columns(2).Width = 80
            .Columns(2).ReadOnly = True
            .Columns(3).Width = 40
            .Columns(3).HeaderText = ""
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).ReadOnly = True
            .Columns(4).Width = 100
            .Columns(4).ReadOnly = True
            .Columns(4).HeaderText = "No. Recibo"
            .Columns(5).Width = 170
            .Columns(5).HeaderText = "Descripción"
            .Columns(5).ReadOnly = True
            .Columns(6).Width = 90
            .Columns(6).DefaultCellStyle.Format = ("C")
            .Columns(6).ReadOnly = True
        End With

        With ChkCerrar
            .HeaderText = "Cerrado"
            .Name = "ChkCerrar"
            .Width = 60
            .ThreeState = False
            .TrueValue = 1
            .FalseValue = 0
            .FlatStyle = FlatStyle.Standard
            .DataPropertyName = "ChkCerrar"
            .DefaultCellStyle.BackColor = Color.Gray
        End With

    End Sub

    Private Sub txtNoRecibo_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Sub HabilitarDgv()
        If txtIDGrupo.Text = "" Then
            DgvRecibos.Enabled = False
            lblStatusBar.Text = "Seleccione el grupo de recibos para habilitar la consulta de recibos de cobros."
            lblStatusBar.ForeColor = Color.Red
        Else
            DgvRecibos.Enabled = True
            lblStatusBar.ForeColor = Color.Black
            lblStatusBar.Text = "Listo"
        End If
    End Sub

    Private Sub DgvRecibos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRecibos.CellValueChanged
        Try
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If DgvRecibos.Rows.Count > 0 Then
                If e.ColumnIndex = 7 Then
                    Dim IDCodigo, IDFactura As New Label
                    Dim IsTicked As Boolean = CBool(DgvRecibos.CurrentRow.Cells(7).Value)
                    IDCodigo.Text = DgvRecibos.CurrentRow.Cells(0).Value

                    If IsTicked Then
                        sqlQ = "UPDATE RecibosCobro SET Cierre=1,IDCierre='" + txtIDGrupo.Text + "',FechaCierre='" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE IDReciboCobro= (" + IDCodigo.Text + ")"
                        GuardarDatos()
                    Else
                        sqlQ = "UPDATE RecibosCobro SET Cierre=0,IDCierre=NULL,FechaCierre=NULL WHERE IDReciboCobro= (" + IDCodigo.Text + ")"
                        GuardarDatos()
                    End If

                    For Each row As DataGridViewRow In DgvDetalle.Rows
                        IDFactura.Text = row.Cells(0).Value
                        CalcBceCerrado(IDFactura.Text)
                    Next

                    txtBuscar.Focus()
                    txtBuscar.SelectAll()

                End If
            End If
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
            Con.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvRecibos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvRecibos.CellEndEdit
        DgvRecibos.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvRecibos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvRecibos.CurrentCellDirtyStateChanged
        If DgvRecibos.IsCurrentCellDirty Then
            DgvRecibos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub btnBuscarCierre_Click(sender As Object, e As EventArgs) Handles btnBuscarCierre.Click
        frm_buscar_cierre_recibos.ShowDialog(Me)
    End Sub

    Private Sub txtIDGrupo_Leave(sender As Object, e As EventArgs) Handles txtIDGrupo.Leave
        Dim DsTmp As New DataSet

        DsTmp.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT IDRecibosCobroCierre,SecondID,Fecha,IDUsuario,Usuarios.Nombre as NombreUsuario,CierreRecibos.IDTipoDocumento,TipoDocumento.Documento,CierreRecibos.IDCobrador,Empleados.Nombre as NombreCobrador,CierreRecibos.Descripcion,CierreRecibos.Nulo FROM cierrerecibos INNER JOIN Empleados on CierreRecibos.IDCobrador=Empleados.IDEmpleado INNER JOIN Empleados as Usuarios on CierreRecibos.IDUsuario=Usuarios.IDEmpleado INNER JOIN TipoDocumento on CierreRecibos.IDTipoDocumento=TipoDocumento.IDTipoDocumento Where IDRecibosCobroCierre= '" + txtIDGrupo.Text + "'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTmp, "CierreGrupo")
        Con.Close()

        Dim Tabla As DataTable = DsTmp.Tables("CierreGrupo")

        If Tabla.Rows.Count = 0 Then
            txtIDGrupo.Clear()
            txtGrupo.Clear()
            txtCobrador.Clear()
            txtFechaGrupo.Clear()
            txtIDCobrador.Clear()
            txtDescripcion.Clear()
            DgvDetalle.Rows.Clear()
            HabilitarDgv()
            RefrescarTabla()
        Else
            txtIDGrupo.Text = (Tabla.Rows(0).Item("IDRecibosCobroCierre"))
            txtGrupo.Text = (Tabla.Rows(0).Item("SecondID"))
            txtIDCobrador.Text = (Tabla.Rows(0).Item("IDCobrador"))
            txtCobrador.Text = (Tabla.Rows(0).Item("NombreCobrador"))
            txtFechaGrupo.Text = CDate(Tabla.Rows(0).Item("Fecha"))
            txtDescripcion.Text = (Tabla.Rows(0).Item("Descripcion"))
            HabilitarDgv()
            RefrescarTabla()
        End If

    End Sub

    Private Sub LoadAnimation()
        If PicLoading.Visible = False Then
            PicLoading.Visible = True
            ToolSeparator.Visible = True
            lblStatusBar.Text = "Cargando..."
        Else
            PicLoading.Visible = False
            ToolSeparator.Visible = False
            lblStatusBar.Text = "Listo"
        End If
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        If txtIDGrupo.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            frm_impresiones_directas.ShowDialog(Me)
        End If
    End Sub

    Private Sub DgvRecibos_SelectionChanged(sender As Object, e As EventArgs) Handles DgvRecibos.SelectionChanged
        Try
            Dim IDRecibo As New Label

            If DgvRecibos.Rows.Count > 0 Then
                IDRecibo.Text = DgvRecibos.CurrentRow.Cells(0).Value
                DgvDetalle.Rows.Clear()

                Connon.Open()
                cmd = New MySqlCommand("SELECT Pagares.IDFactura,FacturaDatos.SecondID,Pagares.IDPagare,Pagares.NoPagare,Pagares.Cantidad,RecibosDEtalle.Debito,RecibosDetalle.Descuento,Pagares.Balance,Pagares.BalanceCerrado FROM libregco.recibosdetalle INNER JOIN Libregco.Pagares on RecibosDetalle.IDPagare=Pagares.IDPagare INNER JOIN Libregco.FacturaDatos on Pagares.IDFactura=FacturaDatos.IDFacturaDatos Where RecibosDetalle.IDReciboCobro='" + IDRecibo.Text + "'", Connon)
                Dim LectorDetalles As MySqlDataReader = cmd.ExecuteReader

                While LectorDetalles.Read
                    DgvDetalle.Rows.Add(LectorDetalles.GetValue(0), LectorDetalles.GetValue(1), LectorDetalles.GetValue(2), LectorDetalles.GetValue(3) & "/" & LectorDetalles.GetValue(4), CDbl(LectorDetalles.GetValue(5)).ToString("C"), CDbl(LectorDetalles.GetValue(6)).ToString("C"), CDbl(LectorDetalles.GetValue(7)).ToString("C"), CDbl(LectorDetalles.GetValue(8)).ToString("C"))
                End While

                LectorDetalles.Close()
                Connon.Close()

                DgvDetalle.ClearSelection()
            Else
                DgvDetalle.Rows.Clear()
            End If


        Catch ex As Exception
            MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name & System.Reflection.MethodInfo.GetCurrentMethod.Name & ex.Message.ToString & ex.TargetSite.ToString, ex.HelpLink)
        End Try
    End Sub
End Class