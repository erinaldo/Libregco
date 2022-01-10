Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_tipo_comprobantes

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_tipo_comprobantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        LimpiartxtBuscar()
        RefrescarTabla()
    End Sub

    Private Sub CargarEmpresa()
      PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDComprobanteFiscal,TipoComprobante from ComprobanteFiscal where IDComprobanteFiscal like '%" + txtBuscar.Text + "%' ORDER BY IDComprobanteFiscal Desc", Con)
            ElseIf rdbTipoComprobante.Checked = True Then
                cmd = New MySqlCommand("SELECT IDComprobanteFiscal,TipoComprobante from ComprobanteFiscal where TipoComprobante like '%" + txtBuscar.Text + "%' ORDER BY TipoComprobante ASC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoComprobante")

            Bs.DataMember = "TipoComprobante"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvTipoComprobante.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbTipoComprobante.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvTipoComprobante
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 110
            .Columns(1).Width = 400
            .Columns(1).HeaderText = "Tipo de Comprobante"
        End With
    End Sub

    Private Sub rdbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTipoComprobante.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvTipoComprobante_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTipoComprobante.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvTipoComprobante.Focus()
    End Sub

    Private Sub DgvTipoComprobante_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvTipoComprobante.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvTipoComprobante.Focus()
        End If
    End Sub

    Private Sub DgvTipoComprobante_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvTipoComprobante.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvTipoComprobante.ColumnCount
                Dim NumRows As Integer = DgvTipoComprobante.RowCount
                Dim CurCell As DataGridViewCell = DgvTipoComprobante.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvTipoComprobante.CurrentCell = DgvTipoComprobante.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvTipoComprobante.CurrentCell = DgvTipoComprobante.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim lblIDComprobante As New Label
            lblIDComprobante.Text = DgvTipoComprobante.CurrentRow.Cells(0).Value

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select * from ComprobanteFiscal where IDComprobanteFiscal='" + lblIDComprobante.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "ComprobanteFiscal")
            Con.Close()

            Dim Tabla As DataTable= Ds1.Tables("ComprobanteFiscal")

            If Me.Owner.Name = frm_mant_comp_fiscal.Name Then
                frm_mant_comp_fiscal.txtIDNCF.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_mant_comp_fiscal.txtNCF.Text = (Tabla.Rows(0).Item("TipoComprobante"))
                frm_mant_comp_fiscal.txtInicial.Text = (Tabla.Rows(0).Item("Inicial"))
                frm_mant_comp_fiscal.txtHasta.Text = (Tabla.Rows(0).Item("Hasta"))
                frm_mant_comp_fiscal.txtUltimo.Text = (Tabla.Rows(0).Item("Ultimo"))
                frm_mant_comp_fiscal.NoTCF.Text = CStr((Tabla.Rows(0).Item("NoTCF"))).PadLeft(2, "0")

                If (Tabla.Rows(0).Item("IDContexto")) = 1 Then
                    frm_mant_comp_fiscal.chkMostrarenFact.Checked = True
                Else
                    frm_mant_comp_fiscal.chkMostrarenFact.Checked = False
                End If

                If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                    frm_mant_comp_fiscal.chkNulo.Checked = True
                Else
                    frm_mant_comp_fiscal.chkNulo.Checked = False
                End If

            ElseIf Me.Owner.Name = frm_consulta_compras.Name Then
                frm_consulta_compras.txtIDTipoComprobante.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_consulta_compras.txtComprobanteFiscal.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            ElseIf Me.Owner.Name = frm_mant_suplidor.Name Then
                frm_mant_suplidor.txtIDNcf.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_mant_suplidor.txtNCF.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            ElseIf Me.Owner.Name = frm_reporte_clientes.Name Then
                frm_reporte_clientes.txtIDNcf.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_reporte_clientes.txtNCF.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            ElseIf Me.Owner.Name = frm_prefacturacion_detalles.Name Then
                frm_prefacturacion_detalles.txtIDNcf.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_prefacturacion_detalles.txtTipoNcf.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas.Name Then
                frm_reporte_registro_facturas.txtIDNcf.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_reporte_registro_facturas.txtNCF.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            ElseIf Me.Owner.Name = frm_reporte_cobros_facturas.Name Then
                frm_reporte_cobros_facturas.txtIDNcf.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_reporte_cobros_facturas.txtNCF.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_cobrar.Name Then
                frm_reporte_cuentas_por_cobrar.txtIDNcf.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_reporte_cuentas_por_cobrar.txtNCF.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            ElseIf Me.Owner.Name = frm_reporte_suplidor.Name Then
                frm_reporte_suplidor.txtIDNCF.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_reporte_suplidor.txtNCF.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            ElseIf Me.Owner.Name = frm_reporte_registro_facturas_cxp.Name Then
                frm_reporte_registro_facturas_cxp.txtIDNCF.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_reporte_registro_facturas_cxp.txtNCF.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            ElseIf Me.Owner.Name = frm_reporte_cuentas_por_pagar.Name Then
                frm_reporte_cuentas_por_pagar.txtIDNCF.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_reporte_cuentas_por_pagar.txtNCF.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            ElseIf Me.Owner.Name = frm_reporte_notas_debito_credito_cxp.Name Then
                frm_reporte_notas_debito_credito_cxp.txtIDNCF.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_reporte_notas_debito_credito_cxp.txtNCF.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            ElseIf Me.Owner.Name = frm_reporte_financiamientos.name Then
                frm_reporte_financiamientos.txtIDNcf.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_reporte_financiamientos.txtNCF.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            ElseIf Me.Owner.Name = frm_consulta_facturas_cxp.Name Then
                frm_consulta_facturas_cxp.txtIDTipoComprobante.Text = (Tabla.Rows(0).Item("IDComprobanteFiscal"))
                frm_consulta_facturas_cxp.txtComprobanteFiscal.Text = (Tabla.Rows(0).Item("TipoComprobante"))

            End If

            
            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

End Class