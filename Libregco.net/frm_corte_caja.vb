Imports DevExpress.XtraScheduler
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_corte_caja
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet
    Friend Permisos As New ArrayList
    Friend Privilegios, PermitirFiltrado As Integer
    Dim UtilizarHora As String
    Private Sub frm_corte_caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarLibregco()
        CargarEmpresa()
        CargarConfiguracion()
        Permisos = PasarPermisos(Me.Tag)
        CargarLibregco()
        ActualizarTodo()
        VerificarPermisos()
        PropiedadColumnsDvg()
        PropiedadColumnasHistorial()
        PropiedadColumnasMovimientos()
    End Sub

    Private Sub CargarConfiguracion()
        ConMixta.Open()
        'Hacer revisión de subtotales durante el registro de compras
        cmd = New MySqlCommand("Select Value2Int from" & SysName.Text & "Configuracion where IDConfiguracion=173", ConMixta)
        UtilizarHora = Convert.ToString(cmd.ExecuteScalar())
        ConMixta.Close()

        If UtilizarHora = 0 Then
            dtpDesde.CustomFormat = "dd/MM/yyyy"
            dtpHasta.CustomFormat = "dd/MM/yyyy"
        Else
            dtpDesde.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
            dtpHasta.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        End If

    End Sub

    Private Function VScrollBarVisible() As Boolean
        Dim ctrl As New Control
        For Each ctrl In DgvTransacciones.Controls
            If ctrl.GetType() Is GetType(VScrollBar) Then
                If ctrl.Visible = True Then
                    Return True
                Else
                    Return False
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub VerificarPermisos()
        Con.Open()

        'Permitir visualizar cálculos de corte de caja a todos los usuarios
        cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=166", Con)
        Dim PermitirTodosUsuarios As Integer = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("SELECT IDPrivilegios FROM empleados where IDEmpleado='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "'", Con)
        Privilegios = Convert.ToString(cmd.ExecuteScalar())

        cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=167", Con)
        PermitirFiltrado = Convert.ToString(cmd.ExecuteScalar())

        Con.Close()

        If PermitirTodosUsuarios = 1 Then
            Label8.Visible = True
            Label9.Visible = True
            txtEfectivoCalculado.Visible = True
            txtChequeCalculado.Visible = True
            txtTarjetaCalculado.Visible = True
            txtTransferenciaCalculado.Visible = True
            txtEgresosCalculado.Visible = True
            txtTotalCalculado.Visible = True
            txtDepositoCalculado.Visible = True
            txtBonosCalculado.Visible = True
            txtPermutaCalculado.Visible = True
            txtOtrasCalculado.Visible = True
            txtEfectivoDiferencia.Visible = True
            txtChequeRetirar.Visible = True
            txtDepositoRetirar.Visible = True
            txtTarjetaRetirar.Visible = True
            txtTransferenciaRetirar.Visible = True
            txtEgresosRetirar.Visible = True
            txtBonosRetirar.Visible = True
            txtPermutaRetirar.Visible = True
            txtOtrasRetirar.Visible = True
            txtTotalDiferencia.Visible = True

            XtraTabPage2.PageVisible = True
            XtraTabPage7.PageEnabled = True
        Else

            If Privilegios = 1 Then
                Label8.Visible = True
                Label9.Visible = True
                txtEfectivoCalculado.Visible = True
                txtChequeCalculado.Visible = True
                txtTarjetaCalculado.Visible = True
                txtTransferenciaCalculado.Visible = True
                txtEgresosCalculado.Visible = True
                txtTotalCalculado.Visible = True
                txtDepositoCalculado.Visible = True
                txtBonosCalculado.Visible = True
                txtPermutaCalculado.Visible = True
                txtOtrasCalculado.Visible = True
                txtEfectivoDiferencia.Visible = True
                txtChequeRetirar.Visible = True
                txtDepositoRetirar.Visible = True
                txtTarjetaRetirar.Visible = True
                txtTransferenciaRetirar.Visible = True
                txtEgresosRetirar.Visible = True
                txtBonosRetirar.Visible = True
                txtPermutaRetirar.Visible = True
                txtOtrasRetirar.Visible = True
                txtTotalDiferencia.Visible = True

                XtraTabPage2.PageVisible = True
                XtraTabPage7.PageEnabled = True

            ElseIf Privilegios = 2 Then
                Label8.Visible = False
                Label9.Visible = False
                txtEfectivoCalculado.Visible = False
                txtChequeCalculado.Visible = False
                txtTarjetaCalculado.Visible = False
                txtTransferenciaCalculado.Visible = False
                txtEgresosCalculado.Visible = False
                txtTotalCalculado.Visible = False
                txtDepositoCalculado.Visible = False
                txtBonosCalculado.Visible = False
                txtPermutaCalculado.Visible = False
                txtOtrasCalculado.Visible = False
                txtEfectivoDiferencia.Visible = False
                txtChequeRetirar.Visible = False
                txtDepositoRetirar.Visible = False
                txtTarjetaRetirar.Visible = False
                txtTransferenciaRetirar.Visible = False
                txtEgresosRetirar.Visible = False
                txtBonosRetirar.Visible = False
                txtPermutaRetirar.Visible = False
                txtOtrasRetirar.Visible = False
                txtTotalDiferencia.Visible = False

                XtraTabPage2.PageVisible = False
                XtraTabPage7.PageEnabled = False

                NavBarControl2.Enabled = False
                'BuscarTransacciones()

            ElseIf Privilegios = 3 Then
                Label8.Visible = False
                Label9.Visible = False
                txtEfectivoCalculado.Visible = False
                txtChequeCalculado.Visible = False
                txtTarjetaCalculado.Visible = False
                txtTransferenciaCalculado.Visible = False
                txtEgresosCalculado.Visible = False
                txtTotalCalculado.Visible = False

                txtEfectivoDiferencia.Visible = False
                txtChequeDiferencia.Visible = False
                txtTarjetaDiferencia.Visible = False
                txtTransferenciaDiferencia.Visible = False
                txtEgresosDiferencia.Visible = False
                txtTotalDiferencia.Visible = False

                XtraTabPage2.PageVisible = False
                XtraTabPage7.PageEnabled = False

                NavBarControl2.Enabled = False
                'BuscarTransacciones()

            ElseIf Privilegios = 4 Then
                Label8.Visible = True
                Label9.Visible = True
                txtEfectivoCalculado.Visible = True
                txtChequeCalculado.Visible = True
                txtDepositoCalculado.Visible = True
                txtTarjetaCalculado.Visible = True
                txtTransferenciaCalculado.Visible = True
                txtEgresosCalculado.Visible = True
                txtBonosCalculado.Visible = True
                txtPermutaCalculado.Visible = True
                txtOtrasCalculado.Visible = True
                txtTotalCalculado.Visible = True

                txtEfectivoDiferencia.Visible = True
                txtChequeDiferencia.Visible = True
                txtDepositoDiferencia.Visible = True
                txtTarjetaDiferencia.Visible = True
                txtTransferenciaDiferencia.Visible = True
                txtEgresosDiferencia.Visible = True
                txtBonosDiferencia.Visible = True
                txtPermutaDiferencia.Visible = True
                txtOtrasDiferencia.Visible = True
                txtTotalDiferencia.Visible = True

                XtraTabPage2.PageVisible = True
                XtraTabPage7.PageEnabled = True
            End If


        End If

        If PermitirFiltrado = 1 Then
            'chkTodoRango.Visible = True
            'chkTodoRango.CheckState = CheckState.Checked
            'chkTodoRango.Enabled = True

            'dtpDesde.Enabled = True
            'dtpHasta.Enabled = True
            'cbxEmpleado.Text = "Todos"
            'cbxEmpleado.Enabled = True
            'cbxAreaImpresion.Text = "Todos"
            'cbxAreaImpresion.Enabled = True
            NavBarGroup4.Visible = True
        Else
            'chkTodoRango.Visible = False
            'chkTodoRango.CheckState = CheckState.Checked
            'chkTodoRango.Enabled = False
            'dtpDesde.Enabled = False
            'dtpHasta.Enabled = False
            'cbxEmpleado.Text = "Todos"
            'cbxEmpleado.Enabled = False
            'cbxAreaImpresion.Text = "Todos"
            'cbxAreaImpresion.Enabled = False
            NavBarGroup4.Visible = False
        End If

    End Sub

    Private Sub FillAreaImpresion()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT ComputerName FROM areaimpresion ORDER BY ComputerName ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "areaimpresion")
            cbxAreaImpresion.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("areaimpresion")

            cbxAreaImpresion.Items.Add("Todos")

            For Each Fila As DataRow In Tabla.Rows
                cbxAreaImpresion.Items.Add(Fila.Item("ComputerName"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxAreaImpresion.Text = "Todos"
            Else
                Close()
                MessageBox.Show("No se pudo cargar ningúna area de impresión ya que no se encontraron resultados en la base de datos. Cree los registros de area de impresión." & vbNewLine & vbNewLine & "El corte de cajano se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

            Tabla.Dispose()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillEmpleados()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM empleados ORDER BY Nombre ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "empleados")
            cbxEmpleado.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("empleados")

            cbxEmpleado.Items.Add("Todos")

            For Each Fila As DataRow In Tabla.Rows
                cbxEmpleado.Items.Add(Fila.Item("Nombre"))
            Next

            If Tabla.Rows.Count > 0 Then
                cbxEmpleado.Text = "Todos"
            Else
                MessageBox.Show("No se pudo cargar ningún empleado ya que no se encontraron resultados en la base de datos. Cree los registros de empleados." & vbNewLine & vbNewLine & "El corte de cajano se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

            Tabla.Dispose()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub ActualizarTodo()
        NavBarGroup4.Expanded = False
        NavBarControl2.Size = New Size(542, 124)
        XtraTabControl1.SelectedTabPage = XtraTabPage1
        Hora.Enabled = True
        chkTodoRango.Enabled = True
        ChkNulo.CheckState = False
        FillAreaImpresion()
        FillEmpleados()

        txtIDCorte.Clear()
        txtSecondID.Clear()
        chkTodoRango.Checked = True
        cbxAreaImpresion.Enabled = True
        cbxEmpleado.Enabled = True
        dtpDesde.Enabled = True
        dtpHasta.Enabled = True
        btnBuscar.Enabled = True
        dtpDesde.MaxDate = Today.AddDays(1).AddSeconds(-1)

        txtEfectivoContado.Text = CDbl(0).ToString("C")
        txtChequeContado.Text = CDbl(0).ToString("C")
        txtDepositoContado.Text = CDbl(0).ToString("C")
        txtTarjetaContado.Text = CDbl(0).ToString("C")
        txtTransferenciaContado.Text = CDbl(0).ToString("C")
        txtEgresosContado.Text = CDbl(0).ToString("C")
        txtBonosContado.Text = CDbl(0).ToString("C")
        txtPermutaContado.Text = CDbl(0).ToString("C")
        txtOtrasContado.Text = CDbl(0).ToString("C")
        txtTotalContado.Text = CDbl(0).ToString("C")

        txtEfectivoCalculado.Text = CDbl(0).ToString("C")
        txtChequeCalculado.Text = CDbl(0).ToString("C")
        txtDepositoCalculado.Text = CDbl(0).ToString("C")
        txtTarjetaCalculado.Text = CDbl(0).ToString("C")
        txtTransferenciaCalculado.Text = CDbl(0).ToString("C")
        txtEgresosCalculado.Text = CDbl(0).ToString("C")
        txtBonosCalculado.Text = CDbl(0).ToString("C")
        txtPermutaCalculado.Text = CDbl(0).ToString("C")
        txtOtrasCalculado.Text = CDbl(0).ToString("C")
        txtTotalCalculado.Text = CDbl(0).ToString("C")

        txtEfectivoDiferencia.Text = CDbl(0).ToString("C")
        txtChequeDiferencia.Text = CDbl(0).ToString("C")
        txtDepositoDiferencia.Text = CDbl(0).ToString("C")
        txtTarjetaDiferencia.Text = CDbl(0).ToString("C")
        txtTransferenciaDiferencia.Text = CDbl(0).ToString("C")
        txtEgresosDiferencia.Text = CDbl(0).ToString("C")
        txtBonosDiferencia.Text = CDbl(0).ToString("C")
        txtPermutaDiferencia.Text = CDbl(0).ToString("C")
        txtOtrasDiferencia.Text = CDbl(0).ToString("C")
        txtTotalDiferencia.Text = CDbl(0).ToString("C")

        txtEfectivoRetirar.Text = CDbl(0).ToString("C")
        txtChequeRetirar.Text = CDbl(0).ToString("C")
        txtDepositoRetirar.Text = CDbl(0).ToString("C")
        txtTarjetaRetirar.Text = CDbl(0).ToString("C")
        txtTransferenciaRetirar.Text = CDbl(0).ToString("C")
        txtEgresosRetirar.Text = CDbl(0).ToString("C")
        txtBonosRetirar.Text = CDbl(0).ToString("C")
        txtPermutaRetirar.Text = CDbl(0).ToString("C")
        txtOtrasRetirar.Text = CDbl(0).ToString("C")
        txtTotalRetirar.Text = CDbl(0).ToString("C")

        txtCantTransaccion.Text = 0
        txtVentaContado.Text = CDbl(0).ToString("C")
        txtVentaCredito.Text = CDbl(0).ToString("C")
        txtReciboIngreso.Text = CDbl(0).ToString("C")
        txtOtrosIngresos.Text = CDbl(0).ToString("C")
        txtCobrosAdelantados.Text = CDbl(0).ToString("C")
        txtFinanciamientos.Text = CDbl(0).ToString("C")
        txtPagosFinanciamientos.Text = CDbl(0).ToString("C")

        txtDevoluciones.Text = CDbl(0).ToString("C")
        txtDevolucionesEfectivo.Text = CDbl(0).ToString("C")
        txtDevolucionesCredito.Text = CDbl(0).ToString("C")
        txtDevolucionesBoucher.Text = CDbl(0).ToString("C")

        txtEfectivo.Text = CDbl(0).ToString("C")
        txtCheque.Text = CDbl(0).ToString("C")
        txtTarjeta.Text = CDbl(0).ToString("C")
        txtDeposito.Text = CDbl(0).ToString("C")
        txtSubtotal.Text = CDbl(0).ToString("C")
        txtDevolucionesEfect.Text = CDbl(0).ToString("C")
        txtRecibosEgresos.Text = CDbl(0).ToString("C")
        txtTotalEgresos.Text = CDbl(0).ToString("C")
        txtGranTotal.Text = CDbl(0).ToString("C")

        If chkTodoRango.Checked = True Then
            dtpDesde.Enabled = False
            dtpHasta.Enabled = False
        Else
            dtpDesde.Enabled = True
            dtpHasta.Enabled = True
        End If

        'Get Datetime Server
        Con.Open()
        cmd = New MySqlCommand("SELECT NOW()", Con)
        Dim Dt As New DateTime
        Dt = Convert.ToDateTime(cmd.ExecuteScalar())
        dtpHasta.MaxDate = Dt
        dtpHasta.Value = Dt
        Con.Close()

        SumTransferenciasalDay()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        frm_conteo_cuadre_de_caja.ShowDialog(Me)
    End Sub

    Private Sub Hora_Tick(sender As Object, e As EventArgs) Handles Hora.Tick
        txtHora.Text = TimeOfDay.ToString("hh:mm:ss tt")
        lblDate.Text = Today.ToString("dd/MM/yyyy") & " " & TimeOfDay.ToString("hh:mm:ss tt")
    End Sub

    Private Sub Label2_MouseHover(sender As Object, e As EventArgs) Handles Label2.MouseHover
        Label2.Text = "+ Efectivo"
    End Sub

    Private Sub Label2_MouseLeave(sender As Object, e As EventArgs) Handles Label2.MouseLeave
        Label2.Text = "Efectivo"
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        frm_buscar_corte_caja.ShowDialog(Me)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        ActualizarTodo()
        If Privilegios = 1 Then
            Label8.Visible = True
            Label9.Visible = True
            txtEfectivoCalculado.Visible = True
            txtChequeCalculado.Visible = True
            txtTarjetaCalculado.Visible = True
            txtTransferenciaCalculado.Visible = True
            txtEgresosCalculado.Visible = True
            txtTotalCalculado.Visible = True
            txtDepositoCalculado.Visible = True
            txtBonosCalculado.Visible = True
            txtPermutaCalculado.Visible = True
            txtOtrasCalculado.Visible = True
            txtEfectivoDiferencia.Visible = True
            txtChequeRetirar.Visible = True
            txtDepositoRetirar.Visible = True
            txtTarjetaRetirar.Visible = True
            txtTransferenciaRetirar.Visible = True
            txtEgresosRetirar.Visible = True
            txtBonosRetirar.Visible = True
            txtPermutaRetirar.Visible = True
            txtOtrasRetirar.Visible = True
            txtTotalDiferencia.Visible = True

            XtraTabPage2.PageVisible = True
            XtraTabPage7.PageEnabled = True

        ElseIf Privilegios = 2 Then
            Label8.Visible = False
            Label9.Visible = False
            txtEfectivoCalculado.Visible = False
            txtChequeCalculado.Visible = False
            txtTarjetaCalculado.Visible = False
            txtTransferenciaCalculado.Visible = False
            txtEgresosCalculado.Visible = False
            txtTotalCalculado.Visible = False
            txtDepositoCalculado.Visible = False
            txtBonosCalculado.Visible = False
            txtPermutaCalculado.Visible = False
            txtOtrasCalculado.Visible = False
            txtEfectivoDiferencia.Visible = False
            txtChequeRetirar.Visible = False
            txtDepositoRetirar.Visible = False
            txtTarjetaRetirar.Visible = False
            txtTransferenciaRetirar.Visible = False
            txtEgresosRetirar.Visible = False
            txtBonosRetirar.Visible = False
            txtPermutaRetirar.Visible = False
            txtOtrasRetirar.Visible = False
            txtTotalDiferencia.Visible = False

            XtraTabPage2.PageVisible = False
            XtraTabPage7.PageEnabled = False

            NavBarControl2.Enabled = False
            'BuscarTransacciones()

        ElseIf Privilegios = 3 Then
            Label8.Visible = False
            Label9.Visible = False
            txtEfectivoCalculado.Visible = False
            txtChequeCalculado.Visible = False
            txtTarjetaCalculado.Visible = False
            txtTransferenciaCalculado.Visible = False
            txtEgresosCalculado.Visible = False
            txtTotalCalculado.Visible = False

            txtEfectivoDiferencia.Visible = False
            txtChequeDiferencia.Visible = False
            txtTarjetaDiferencia.Visible = False
            txtTransferenciaDiferencia.Visible = False
            txtEgresosDiferencia.Visible = False
            txtTotalDiferencia.Visible = False

            XtraTabPage2.PageVisible = False
            XtraTabPage7.PageEnabled = False

            NavBarControl2.Enabled = False
            'BuscarTransacciones()

        ElseIf Privilegios = 4 Then
            Label8.Visible = True
            Label9.Visible = True
            txtEfectivoCalculado.Visible = True
            txtChequeCalculado.Visible = True
            txtDepositoCalculado.Visible = True
            txtTarjetaCalculado.Visible = True
            txtTransferenciaCalculado.Visible = True
            txtEgresosCalculado.Visible = True
            txtBonosCalculado.Visible = True
            txtPermutaCalculado.Visible = True
            txtOtrasCalculado.Visible = True
            txtTotalCalculado.Visible = True

            txtEfectivoDiferencia.Visible = True
            txtChequeDiferencia.Visible = True
            txtDepositoDiferencia.Visible = True
            txtTarjetaDiferencia.Visible = True
            txtTransferenciaDiferencia.Visible = True
            txtEgresosDiferencia.Visible = True
            txtBonosDiferencia.Visible = True
            txtPermutaDiferencia.Visible = True
            txtOtrasDiferencia.Visible = True
            txtTotalDiferencia.Visible = True

            XtraTabPage2.PageVisible = True
            XtraTabPage7.PageEnabled = True
        End If


    End Sub

    Sub PropiedadColumnsDvg()
        Try
            Dim VScrollBarWidht As Integer = 0

            If VScrollBarVisible(DgvTransacciones) = True Then
                VScrollBarWidht = 16
            Else
                VScrollBarWidht = 0
            End If



            Dim DatagridWith As Double = (DgvTransacciones.Width - DgvTransacciones.RowHeadersWidth - VScrollBarWidht) / 100

            With DgvTransacciones
                .Columns(0).Visible = False
                .Columns(1).Width = DatagridWith * 20
                .Columns(2).Visible = False
                .Columns(3).Width = DatagridWith * 12
                .Columns(3).HeaderText = "Transacción"
                .Columns(4).Visible = False
                .Columns(5).Visible = False
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .Columns(8).Visible = False
                .Columns(9).Visible = False
                .Columns(10).Visible = False
                .Columns(11).Visible = False
                .Columns(12).Visible = False
                .Columns(13).Visible = False
                .Columns(14).Width = DatagridWith * 17
                .Columns(14).HeaderText = "Fecha Hora"
                .Columns(15).Visible = False
                .Columns(16).HeaderText = "Cliente / Suplidor"
                .Columns(16).Width = DatagridWith * 32
                .Columns(17).Width = DatagridWith * 12
                .Columns(17).HeaderText = "Débito"
                .Columns(17).DefaultCellStyle.Format = "C"
                .Columns(18).Width = DatagridWith * 12
                .Columns(18).HeaderText = "Crédito"
                .Columns(18).DefaultCellStyle.Format = "C"
                .Columns(19).Visible = False
                .Columns(20).Visible = False
                .Columns(21).Visible = False
                .Columns(22).Visible = False
                .Columns(23).Visible = False
                .Columns(24).Visible = False
                .Columns(25).Visible = False
                .Columns(26).Visible = False
                .Columns(27).Visible = False
                .Columns(28).Visible = False
                .Columns(29).Visible = False
                .Columns(30).Visible = False
                .Columns(31).Visible = False
                .Columns(32).Visible = False
                .Columns(33).Visible = False
                .Columns(34).Visible = False
                .Columns(35).Visible = False
                .Columns(36).Visible = False
                .Columns(37).Visible = False
                .Columns(38).Visible = False
                .Columns(39).Visible = False
                .Columns(40).Visible = False
                .Columns(41).Visible = False
                '.ScrollBars = ScrollBars.Both
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BuscarTransacciones()
        Dim SQLSetence As String = "Select * from" & SysName.Text & "cortecajadetalleview"
        Dim Bs As New BindingSource

        Con.Open()
        cmd = New MySqlCommand("SELECT NOW()", Con)
        Dim Dt As New DateTime
        Dt = Convert.ToDateTime(cmd.ExecuteScalar())
        dtpHasta.MaxDate = Dt
        Con.Close()

        If UtilizarHora = 1 Then
            If chkTodoRango.Checked = True Then
                SQLSetence = SQLSetence & " WHERE FechaHora Between '" + dtpDesde.MinDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + dtpHasta.MaxDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND IDCorteCaja IS NULL"
            Else
                SQLSetence = SQLSetence & " WHERE FechaHora Between '" + dtpDesde.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + dtpHasta.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND IDCorteCaja IS NULL"
            End If
        Else
            If chkTodoRango.Checked = True Then
                SQLSetence = SQLSetence & " WHERE DATE(FechaHora) Between '" + dtpDesde.MinDate.ToString("yyyy-MM-dd") + "' and '" + dtpHasta.MaxDate.ToString("yyyy-MM-dd") + "' AND IDCorteCaja IS NULL"
            Else
                SQLSetence = SQLSetence & " WHERE DATE(FechaHora) Between '" + dtpDesde.Value.ToString("yyyy-MM-dd") + "' and '" + dtpHasta.Value.ToString("yyyy-MM-dd") + "' AND IDCorteCaja IS NULL"
            End If
        End If

        If cbxEmpleado.Text <> "Todos" Then
            SQLSetence = SQLSetence & " And IDUsuario='" + cbxEmpleado.Tag.ToString + "'"
        End If

        If cbxAreaImpresion.Text <> "Todos" Then
            SQLSetence = SQLSetence & " AND IDEquipo='" + cbxAreaImpresion.Tag.ToString + "'"
        End If

        Ds.Clear()
        ConMixta.Open()
        cmd = New MySqlCommand(SQLSetence, ConMixta)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "cortecajadetalleview")
        ConMixta.Close()

        Bs.DataMember = "cortecajadetalleview"
        Bs.DataSource = Ds
        BindingNavigator.BindingSource = Bs
        DgvTransacciones.DataSource = Bs
        DgvTransacciones.ClearSelection()
        PropiedadColumnsDvg()

        dtpDesde.Enabled = False
        dtpHasta.Enabled = False

        cbxAreaImpresion.Enabled = False
        cbxEmpleado.Enabled = False
        chkTodoRango.Enabled = False

        SumarTransacciones()

        txtEfectivoContado.Focus()
        txtEfectivoContado.SelectAll()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBuscarTransacciones.Click
        BuscarTransacciones()

        If NavBarGroup4.Expanded Then
            NavBarGroup4.Expanded = False
            NavBarControl2.Size = New Size(542, 124)
        End If

    End Sub


    Sub SumarTransacciones()
        Try

            txtCantTransaccion.Text = 0
            txtVentaContado.Text = CDbl(0).ToString("C")
            txtVentaCredito.Text = CDbl(0).ToString("C")
            txtReciboIngreso.Text = CDbl(0).ToString("C")
            txtOtrosIngresos.Text = CDbl(0).ToString("C")
            txtCobrosAdelantados.Text = CDbl(0).ToString("C")
            txtFinanciamientos.Text = CDbl(0).ToString("C")
            txtPagosFinanciamientos.Text = CDbl(0).ToString("C")

            txtDevoluciones.Text = CDbl(0).ToString("C")
            txtDevolucionesEfectivo.Text = CDbl(0).ToString("C")
            txtDevolucionesCredito.Text = CDbl(0).ToString("C")
            txtDevolucionesBoucher.Text = CDbl(0).ToString("C")

            txtEfectivo.Text = CDbl(0).ToString("C")
            txtCheque.Text = CDbl(0).ToString("C")
            txtTarjeta.Text = CDbl(0).ToString("C")
            txtDeposito.Text = CDbl(0).ToString("C")
            txtSubtotal.Text = CDbl(0).ToString("C")
            txtDevolucionesEfect.Text = CDbl(0).ToString("C")
            txtRecibosEgresos.Text = CDbl(0).ToString("C")
            txtBonos.Text = CDbl(0).ToString("C")
            txtPermutas.Text = CDbl(0).ToString("C")
            txtOtras.Text = CDbl(0).ToString("C")
            txtTotalEgresos.Text = CDbl(0).ToString("C")
            txtGranTotal.Text = CDbl(0).ToString("C")

            For Each rw As DataGridViewRow In DgvTransacciones.Rows

                If rw.Cells("Nulo").Value = 0 Then
                    txtVentaContado.Text = CDbl(txtVentaContado.Text) + CDbl(rw.Cells("FacturasContado").Value)
                    txtVentaCredito.Text = CDbl(txtVentaCredito.Text) + CDbl(rw.Cells("FacturasCredito").Value)
                    txtReciboIngreso.Text = CDbl(txtReciboIngreso.Text) + CDbl(rw.Cells("AbonosPago").Value)
                    txtOtrosIngresos.Text = CDbl(txtOtrosIngresos.Text) + CDbl(rw.Cells("OtrosIngresos").Value)
                    txtCobrosAdelantados.Text = CDbl(txtCobrosAdelantados.Text) + CDbl(rw.Cells("CobrosAdelantados").Value)
                    txtDevolucionesEfectivo.Text = CDbl(txtDevolucionesEfectivo.Text) + CDbl(rw.Cells("DevolucionesEfect").Value)
                    txtDevolucionesCredito.Text = CDbl(txtDevolucionesCredito.Text) + CDbl(rw.Cells("DevolucionesCred").Value)
                    txtDevolucionesBoucher.Text = CDbl(txtDevolucionesBoucher.Text) + CDbl(rw.Cells("DevolucionBoucher").Value)
                    txtDevoluciones.Text = CDbl(txtDevoluciones.Text) + CDbl(rw.Cells("DevolucionesTotal").Value)
                    txtFinanciamientos.Text = CDbl(txtFinanciamientos.Text) + CDbl(rw.Cells("Financiamientos").Value)
                    txtPagosFinanciamientos.Text = CDbl(txtPagosFinanciamientos.Text) + CDbl(rw.Cells("PagosFinanciamientos").Value)

                    txtEfectivo.Text = CDbl(txtEfectivo.Text) + (CDbl(rw.Cells("Efectivo").Value) - CDbl(rw.Cells("Devuelta").Value))
                    txtCheque.Text = CDbl(txtCheque.Text) + CDbl(rw.Cells("Cheque").Value)
                    txtDeposito.Text = CDbl(txtDeposito.Text) + CDbl(rw.Cells("Deposito").Value)
                    txtTarjeta.Text = CDbl(txtTarjeta.Text) + CDbl(rw.Cells("Tarjeta").Value)
                    txtBonos.Text = CDbl(txtBonos.Text) + CDbl(rw.Cells("Bonos").Value)
                    txtPermutas.Text = CDbl(txtPermutas.Text) + CDbl(rw.Cells("Permuta").Value)
                    txtOtras.Text = CDbl(txtOtras.Text) + CDbl(rw.Cells("Otras").Value)

                    txtSubtotal.Text = CDbl(txtEfectivo.Text) + CDbl(txtCheque.Text) + CDbl(txtTarjeta.Text) + CDbl(txtDeposito.Text)
                    txtDevolucionesEfect.Text = CDbl(txtDevolucionesEfectivo.Text)
                    txtRecibosEgresos.Text = CDbl(txtRecibosEgresos.Text) + CDbl(rw.Cells("Egresos").Value)
                    txtTotalEgresos.Text = CDbl(txtDevolucionesEfect.Text) + CDbl(txtRecibosEgresos.Text)
                End If

            Next

            txtCantTransaccion.Text = DgvTransacciones.Rows.Count
            txtGranTotal.Text = CDbl(txtSubtotal.Text) - CDbl(txtTotalEgresos.Text)
            txtVentaContado.Text = CDbl(txtVentaContado.Text).ToString("C")
            txtVentaCredito.Text = CDbl(txtVentaCredito.Text).ToString("C")
            txtReciboIngreso.Text = CDbl(txtReciboIngreso.Text).ToString("C")
            txtOtrosIngresos.Text = CDbl(txtOtrosIngresos.Text).ToString("C")
            txtCobrosAdelantados.Text = CDbl(txtCobrosAdelantados.Text).ToString("C")
            txtDevolucionesEfectivo.Text = CDbl(txtDevolucionesEfectivo.Text).ToString("C")
            txtDevolucionesCredito.Text = CDbl(txtDevolucionesCredito.Text).ToString("C")
            txtDevolucionesBoucher.Text = CDbl(txtDevolucionesBoucher.Text).ToString("C")
            txtDevoluciones.Text = CDbl(txtDevoluciones.Text).ToString("C")
            txtFinanciamientos.Text = CDbl(txtFinanciamientos.Text).ToString("C")
            txtPagosFinanciamientos.Text = CDbl(txtPagosFinanciamientos.Text).ToString("C")

            txtEfectivo.Text = CDbl(txtEfectivo.Text).ToString("C")
            txtCheque.Text = CDbl(txtCheque.Text).ToString("C")
            txtDeposito.Text = CDbl(txtDeposito.Text).ToString("C")
            txtTarjeta.Text = CDbl(txtTarjeta.Text).ToString("C")
            txtBonos.Text = CDbl(txtBonos.Text).ToString("C")
            txtPermutas.Text = CDbl(txtPermutas.Text).ToString("C")
            txtOtras.Text = CDbl(txtOtras.Text).ToString("C")

            'txtEfectivoCalculado.Text = (CDbl(txtEfectivo.Text) - CDbl(txtRecibosEgresos.Text) - CDbl(txtTotalEgresos.Text)).ToString("C")
            txtEfectivoCalculado.Text = CDbl(txtEfectivo.Text).ToString("C")
            txtChequeCalculado.Text = CDbl(txtCheque.Text).ToString("C")
            txtTarjetaCalculado.Text = CDbl(txtTarjeta.Text).ToString("C")
            txtTransferenciaCalculado.Text = CDbl(0).ToString("C")
            txtDepositoCalculado.Text = CDbl(txtDeposito.Text).ToString("C")
            txtEgresosCalculado.Text = CDbl(txtTotalEgresos.Text).ToString("C")
            txtBonosCalculado.Text = CDbl(txtBonos.Text).ToString("C")
            txtPermutaCalculado.Text = CDbl(txtPermutas.Text).ToString("C")
            txtOtrasCalculado.Text = CDbl(txtOtras.Text).ToString("C")
            txtTotalCalculado.Text = CDbl(txtGranTotal.Text).ToString("C")

            txtEfectivoDiferencia.Text = (CDbl(txtEfectivoContado.Text) - CDbl(txtEfectivoCalculado.Text)).ToString("C")
            txtChequeDiferencia.Text = (CDbl(txtChequeContado.Text) - CDbl(txtChequeCalculado.Text)).ToString("C")
            txtTarjetaDiferencia.Text = (CDbl(txtTarjetaContado.Text) - CDbl(txtTarjetaCalculado.Text)).ToString("C")
            txtTransferenciaDiferencia.Text = (CDbl(txtTransferenciaContado.Text) - CDbl(txtTransferenciaCalculado.Text)).ToString("C")
            txtDepositoDiferencia.Text = (CDbl(txtDepositoContado.Text) - CDbl(txtDepositoCalculado.Text)).ToString("C")
            txtEgresosDiferencia.Text = (CDbl(txtEgresosContado.Text) - CDbl(txtEgresosCalculado.Text)).ToString("C")
            txtBonosDiferencia.Text = (CDbl(txtBonosContado.Text) - CDbl(txtBonosCalculado.Text)).ToString("C")
            txtPermutaDiferencia.Text = (CDbl(txtPermutaContado.Text) - CDbl(txtPermutaCalculado.Text)).ToString("C")
            txtOtrasDiferencia.Text = (CDbl(txtOtrasContado.Text) - CDbl(txtOtrasCalculado.Text)).ToString("C")
            txtTotalDiferencia.Text = (CDbl(txtEfectivoDiferencia.Text) + CDbl(txtChequeDiferencia.Text) + CDbl(txtTarjetaDiferencia.Text) + CDbl(txtTransferenciaDiferencia.Text) + CDbl(txtDepositoDiferencia.Text) - CDbl(txtBonosDiferencia.Text) - CDbl(txtPermutaDiferencia.Text) - CDbl(txtOtrasDiferencia.Text) - CDbl(txtEgresosDiferencia.Text)).ToString("C")


            txtSubtotal.Text = CDbl(txtSubtotal.Text).ToString("C")
            txtDevolucionesEfect.Text = CDbl(txtDevolucionesEfect.Text).ToString("C")
            txtRecibosEgresos.Text = CDbl(txtRecibosEgresos.Text).ToString("C")
            txtTotalEgresos.Text = CDbl(txtTotalEgresos.Text).ToString("C")
            txtGranTotal.Text = CDbl(txtGranTotal.Text).ToString("C")

            SumTransferenciasalDay()


        Catch ex As Exception
                 MessageBox.Show(ex.Message.ToString )
        End Try
    End Sub
    Private Sub cbxEmpleado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEmpleado.SelectedIndexChanged

        If cbxEmpleado.Text <> "Todos" Then
            Con.Open()
            cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + cbxEmpleado.SelectedItem + "'", Con)
            cbxEmpleado.Tag = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            lblUsuario.ForeColor = Color.Red
            lblUsuario.Text = "       La consulta de sido especificada para un solo usuario"
            lblUsuario.Image = My.Resources.Notx16
        Else
            cbxEmpleado.Tag = 1

            lblUsuario.ForeColor = SystemColors.Highlight
            lblUsuario.Text = "       La consulta incluye a todos los usuarios"
            lblUsuario.Image = My.Resources.Plux16
        End If


        LlenarHistorial()
        LlenarMovimientos()

    End Sub

    Private Sub cbxAreaImpresion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAreaImpresion.SelectedIndexChanged
        If cbxAreaImpresion.Text <> "Todos" Then
            Con.Open()
            cmd = New MySqlCommand("SELECT IDEquipo FROM areaimpresion WHERE ComputerName= '" + cbxAreaImpresion.SelectedItem + "'", Con)
            cbxAreaImpresion.Tag = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            lblAreaImpresion.ForeColor = Color.Red
            lblAreaImpresion.Text = "       La consulta de sido especificada para un sola caja"
            lblAreaImpresion.Image = My.Resources.Notx16
        Else
            cbxAreaImpresion.Tag = 1

            lblAreaImpresion.ForeColor = SystemColors.Highlight
            lblAreaImpresion.Text = "       La consulta incluye todos las cajas o áreas de impresión"
            lblAreaImpresion.Image = My.Resources.Plux16
        End If
    End Sub

    Private Sub VerificarFechaSistema()
        Dim CurrentDate As New Date
        Con.Open()
        cmd = New MySqlCommand("SELECT CURDATE()", Con)
        CurrentDate = Convert.ToDateTime(cmd.ExecuteScalar())
        Con.Close()

        If Today <> CurrentDate Then
            MessageBox.Show("Existe un conflicto entre la fecha actual del equipo y la fecha del servidor." & vbNewLine & vbNewLine & "Por favor verifique la fecha del equipo o la del servidor para acceder al sistema.", "Diferencias en fechas", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Application.Exit()
        End If

    End Sub

    Private Sub GuardarDatos()
        Try

            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
            '--------------------------------------------------------

            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
            Con.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub UltCorte()
        If txtIDCorte.Text = "" Then
            Con.Open()
            cmd = New MySqlCommand("Select IDCorteCaja from CorteCaja where IDCorteCaja= (Select Max(IDCorteCaja) from CorteCaja)", Con)
            txtIDCorte.Text = Convert.ToDouble(cmd.ExecuteScalar())
            Con.Close()
        End If
    End Sub

    Private Sub DgvTransacciones_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DgvTransacciones.RowsAdded
        If DgvTransacciones.Rows(e.RowIndex).Cells("Nulo").Value = 1 Then
            DgvTransacciones.Rows(e.RowIndex).Cells("NombreCliente").Value = "[Transacción Anulada]"
            'DgvTransacciones.Rows(e.RowIndex).Style.BackColor = Color.Red
            'DgvTransacciones.Rows(e.RowIndex).Cells("NombreCliente").Style.ForeColor = Color.White
        End If
    End Sub

    Private Sub SumTransferenciasalDay()
        Dim EmpleadoSQL, CajaSQL As String

        ' And IDUsuario=1 And IDAreaImpresion=1

        If cbxEmpleado.Text = "Todos" Then
            EmpleadoSQL = ""
        Else
            EmpleadoSQL = " AND IDUsuario='" + cbxEmpleado.Tag.ToString + "'"
        End If

        If cbxAreaImpresion.Text = "Todos" Then
            CajaSQL = ""
        Else
            CajaSQL = " AND IDUsuario='" + cbxAreaImpresion.Tag.ToString + "'"
        End If

        Con.Open()
        cmd = New MySqlCommand("Select coalesce(sum(RetiroTotal), 0) FROM Cortecaja where Nulo=0 And Date(Fecha)=curdate()" & EmpleadoSQL & CajaSQL, Con)
        txtTransferenciadeCaja.Text = CDbl(Convert.ToDouble(cmd.ExecuteScalar())).ToString("C")

        cmd = New MySqlCommand("Select Fecha FROM Cortecaja where Nulo=0 And Date(Fecha)=curdate()" & EmpleadoSQL & CajaSQL & " order by IDCorteCaja DESC LIMIT 1", Con)
        Label22.Text = Convert.ToString(cmd.ExecuteScalar())

        Con.Close()
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        VerificarFechaSistema()

        If cbxEmpleado.Text = "" Then
            MessageBox.Show("Seleccione el empleado para realizar el corte de caja.", "No se ha específicado el empleado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxEmpleado.Focus()
            cbxEmpleado.DroppedDown = True
            Exit Sub
        ElseIf cbxAreaImpresion.Text = "" Then
            MessageBox.Show("Seleccione la caja o el area de impresión para realizar el corte de caja.", "Seleccione area de impresión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxAreaImpresion.Focus()
            cbxAreaImpresion.DroppedDown = True
            Exit Sub
        ElseIf DgvTransacciones.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran transacciones para realizar el corte de caja.", "No hay transacciones para realizar el corte", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Exit Sub
        ElseIf chkTodoRango.CheckState = CheckState.Unchecked Then
            If dtpDesde.Value > dtpHasta.Value Then
                MessageBox.Show("No se puede realizar el corte de caja porque el período inicial excede el período final.", "Período de tiempo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                dtpDesde.Focus()
                Exit Sub
            End If
        ElseIf CDbl(txtTotalContado.Text) = 0 Then
            MessageBox.Show("Escriba la cantidad CONTADA en el corte de caja.", "No se ha escrito la cantidad contada del corte", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtEfectivoContado.Focus()
            Exit Sub
        End If


        If txtIDCorte.Text = "" Then 'Si no hay factura
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea realizar el corte de caja?", "Guardar corte de caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                Con.Open()
                cmd = New MySqlCommand("SELECT NOW()", Con)
                Dim Dat As New DateTime
                Dat = Convert.ToDateTime(cmd.ExecuteScalar())
                Con.Close()

                Dim SQLSetence As String = "SELECT COUNT(*) FROM cortecajadetalleview"

                If chkTodoRango.Checked = True Then
                    SQLSetence = SQLSetence & " WHERE FechaHora Between '" + dtpDesde.MinDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + Dat.ToString("yyyy-MM-dd HH:mm:ss") + "' AND IDCorteCaja IS NULL"
                Else
                    SQLSetence = SQLSetence & " WHERE FechaHora Between '" + dtpDesde.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + dtpHasta.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND IDCorteCaja IS NULL"
                End If

                If cbxEmpleado.Text <> "Todos" Then
                    SQLSetence = SQLSetence & " And IDUsuario='" + cbxEmpleado.Tag.ToString + "'"
                End If

                If cbxAreaImpresion.Text <> "Todos" Then
                    SQLSetence = SQLSetence & " AND IDEquipo='" + cbxAreaImpresion.Tag.ToString + "'"
                End If

                Con.Open()
                cmd = New MySqlCommand(SQLSetence, Con)
                Dim Cant As Double = Convert.ToDouble(cmd.ExecuteScalar())
                Con.Close()

                If DgvTransacciones.Rows.Count <> Cant Then
                    Dim Result1 As MsgBoxResult = MessageBox.Show("Se han encontrado transacciones o modificaciones en la cantidad de transacciones válidas para realizar el corte de caja." & vbNewLine & vbNewLine & "Está seguro que desea realizar el corte de caja?", "Existencia de transacciones o modificaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    If Result1 = MsgBoxResult.No Then
                        BuscarTransacciones()
                        txtEfectivoContado.Focus()
                        txtEfectivoContado.SelectAll()
                        Exit Sub
                    End If
                End If

                sqlQ = "INSERT INTO CorteCaja (IDTipoDocumento,Fecha,IDAreaImpresionCreador,IDCreadorUsuario,TodosUsuarios,IDUsuario,TodasCajas,IDAreaImpresion,TodoRango,DesdeFecha,HastaFecha,ContadoEfectivo,ContadoCheque,ContadoDeposito,ContadoTarjeta,ContadoTrans,ContadoVales,ContadoBonos,ContadoPermuta,ContadoOtros,ContadoTotal,CalculadoEfectivo,CalculadoCheque,CalculadoDeposito,CalculadoTarjeta,CalculadoTrans,CalculadoVales,CalculadoBonos,CalculadoPermuta,CalculadoOtros,CalculadoTotal,DiferenciaEfectivo,DiferenciaCheque,DiferenciaDeposito,DiferenciaTarjeta,DiferenciaTrans,DiferenciaVales,DiferenciaBonos,DiferenciaPermuta,DiferenciaOtros,DiferenciaTotal,TransferidoaFechas,RetiroEfectivo,RetiroCheque,RetiroDeposito,RetiroTarjeta,RetiroTrans,RetiroVales,RetiroBonos,RetiroPermuta,RetiroOtros,RetiroTotal,CantidadTransacciones,Nulo) VALUES (59,NOW(),'" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + If(cbxEmpleado.Text = "Todos", 1, 0).ToString + "','" + cbxEmpleado.Tag.ToString + "','" + If(cbxAreaImpresion.Text = "Todos", 1, 0).ToString + "','" + cbxAreaImpresion.Tag.ToString + "','" + Convert.ToInt16(chkTodoRango.CheckState).ToString + "','" + dtpDesde.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + dtpHasta.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','" + CDbl(txtEfectivoContado.Text).ToString + "','" + CDbl(txtChequeContado.Text).ToString + "','" + CDbl(txtDepositoContado.Text).ToString + "','" + CDbl(txtTarjetaContado.Text).ToString + "','" + CDbl(txtTransferenciaContado.Text).ToString + "','" + CDbl(txtEgresosContado.Text).ToString + "','" + CDbl(txtBonosContado.Text).ToString + "','" + CDbl(txtPermutaContado.Text).ToString + "','" + CDbl(txtOtrasContado.Text).ToString + "','" + CDbl(txtTotalContado.Text).ToString + "','" + CDbl(txtEfectivoCalculado.Text).ToString + "','" + CDbl(txtChequeCalculado.Text).ToString + "','" + CDbl(txtDepositoCalculado.Text).ToString + "','" + CDbl(txtTarjetaCalculado.Text).ToString + "','" + CDbl(txtTransferenciaCalculado.Text).ToString + "','" + CDbl(txtEgresosCalculado.Text).ToString + "','" + CDbl(txtBonosCalculado.Text).ToString + "','" + CDbl(txtPermutaCalculado.Text).ToString + "','" + CDbl(txtOtrasCalculado.Text).ToString + "','" + CDbl(txtTotalCalculado.Text).ToString + "','" + CDbl(txtEfectivoDiferencia.Text).ToString + "','" + CDbl(txtChequeDiferencia.Text).ToString + "','" + CDbl(txtDepositoDiferencia.Text).ToString + "','" + CDbl(txtTarjetaDiferencia.Text).ToString + "','" + CDbl(txtTransferenciaDiferencia.Text).ToString + "','" + CDbl(txtEgresosDiferencia.Text).ToString + "','" + CDbl(txtBonosDiferencia.Text).ToString + "','" + CDbl(txtPermutaDiferencia.Text).ToString + "','" + CDbl(txtOtrasDiferencia.Text).ToString + "','" + CDbl(txtTotalDiferencia.Text).ToString + "','" + CDbl(txtTransferenciadeCaja.Text).ToString + "','" + CDbl(txtEfectivoRetirar.Text).ToString + "','" + CDbl(txtChequeRetirar.Text).ToString + "','" + CDbl(txtDepositoRetirar.Text).ToString + "','" + CDbl(txtTarjetaRetirar.Text).ToString + "','" + CDbl(txtTransferenciaDiferencia.Text).ToString + "','" + CDbl(txtEgresosRetirar.Text).ToString + "','" + CDbl(txtBonosRetirar.Text).ToString + "','" + CDbl(txtPermutaRetirar.Text).ToString + "','" + CDbl(txtOtrasRetirar.Text).ToString + "','" + CDbl(txtTotalRetirar.Text).ToString + "','" + txtCantTransaccion.Text + "',0)"
                GuardarDatos()
                UltCorte()

                SetSecondID()
                InsertDetails()
                LlenarHistorial()

                ToastNotificationsManager1.Notifications(0).Body = "El corte de caja " & txtSecondID.Text & " ha sido guardada satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

                Hora.Enabled = False

                ImprimirDocumento()
            End If
        Else

            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el corte de caja?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                sqlQ = "UPDATE CorteCaja SET Fecha=NOW(),IDAreaImpresionCreador='" + DTAreaImpresion.Rows(0).Item("IDEquipo").ToString + "',IDCreadorUsuario='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "',TodosUsuarios='" + If(cbxEmpleado.Text = "Todos", 1, 0).ToString + "',IDUsuario='" + cbxEmpleado.Tag.ToString + "',TodasCajas='" + If(cbxAreaImpresion.Text = "Todos", 1, 0).ToString + "',IDAreaImpresion='" + cbxAreaImpresion.Tag.ToString + "',TodoRango='" + Convert.ToInt16(chkTodoRango.CheckState).ToString + "',DesdeFecha='" + dtpDesde.Value.ToString("yyyy-MM-dd HH:mm:ss") + "',HastaFecha='" + dtpHasta.Value.ToString("yyyy-MM-dd HH:mm:ss") + "',ContadoEfectivo='" + CDbl(txtEfectivoContado.Text).ToString + "',ContadoCheque='" + CDbl(txtChequeContado.Text).ToString + "',ContadoDeposito='" + CDbl(txtDepositoContado.Text).ToString + "',ContadoTarjeta='" + CDbl(txtTarjetaContado.Text).ToString + "',ContadoTrans='" + CDbl(txtTransferenciaContado.Text).ToString + "',ContadoVales='" + CDbl(txtEgresosContado.Text).ToString + "',ContadoBonos='" + CDbl(txtBonosContado.Text).ToString + "',ContadoPermuta='" + CDbl(txtPermutaContado.Text).ToString + "',ContadoOtros='" + CDbl(txtOtrasContado.Text).ToString + "',ContadoTotal='" + CDbl(txtTotalContado.Text).ToString + "',CalculadoEfectivo='" + CDbl(txtEfectivoCalculado.Text).ToString + "',CalculadoCheque='" + CDbl(txtChequeCalculado.Text).ToString + "',CalculadoDeposito='" + CDbl(txtDepositoCalculado.Text).ToString + "',CalculadoTarjeta='" + CDbl(txtTarjetaCalculado.Text).ToString + "',CalculadoTrans='" + CDbl(txtTransferenciaCalculado.Text).ToString + "',CalculadoVales='" + CDbl(txtEgresosCalculado.Text).ToString + "',CalculadoBonos='" + CDbl(txtBonosCalculado.Text).ToString + "',CalculadoPermuta='" + CDbl(txtPermutaCalculado.Text).ToString + "',CalculadoOtros='" + CDbl(txtOtrasCalculado.Text).ToString + "',CalculadoTotal='" + CDbl(txtTotalCalculado.Text).ToString + "',DiferenciaEfectivo='" + CDbl(txtEfectivoDiferencia.Text).ToString + "',DiferenciaCheque='" + CDbl(txtChequeDiferencia.Text).ToString + "',DiferenciaDeposito='" + CDbl(txtDepositoDiferencia.Text).ToString + "',DiferenciaTarjeta='" + CDbl(txtTarjetaDiferencia.Text).ToString + "',DiferenciaTrans='" + CDbl(txtTransferenciaDiferencia.Text).ToString + "',DiferenciaVales='" + CDbl(txtEgresosDiferencia.Text).ToString + "',DiferenciaBonos='" + CDbl(txtBonosDiferencia.Text).ToString + "',DiferenciaPermuta='" + CDbl(txtPermutaDiferencia.Text).ToString + "',DiferenciaOtros='" + CDbl(txtOtrasDiferencia.Text).ToString + "',DiferenciaTotal='" + CDbl(txtTotalDiferencia.Text).ToString + "',TransferidoaFechas='" + CDbl(txtTransferenciadeCaja.Text).ToString + "',RetiroEfectivo='" + CDbl(txtEfectivoRetirar.Text).ToString + "',RetiroCheque='" + CDbl(txtChequeRetirar.Text).ToString + "',RetiroDeposito='" + CDbl(txtDepositoRetirar.Text).ToString + "',RetiroTarjeta='" + CDbl(txtTarjetaRetirar.Text).ToString + "',RetiroTrans='" + CDbl(txtTransferenciaDiferencia.Text).ToString + "',RetiroVales='" + CDbl(txtEgresosRetirar.Text).ToString + "',RetiroBonos='" + CDbl(txtBonosRetirar.Text).ToString + "',RetiroPermuta='" + CDbl(txtPermutaRetirar.Text).ToString + "',RetiroOtros='" + CDbl(txtOtrasRetirar.Text).ToString + "',RetiroTotal='" + CDbl(txtTotalRetirar.Text).ToString + "',CantidadTransacciones='" + txtCantTransaccion.Text + "' WHERE IDCorteCaja='" + txtIDCorte.Text + "'"
                GuardarDatos()

                LlenarHistorial()

                ToastNotificationsManager1.Notifications(1).Body = "El corte de caja " & txtSecondID.Text & " ha sido modificado satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(1))

                Hora.Enabled = False

                ImprimirDocumento()
            End If
        End If

    End Sub

    Private Sub ImprimirDocumento()

        If Permisos(3) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDCorte.Text = "" Then
            MessageBox.Show("El formulario está vacío. No se encontraron datos para imprimir.", "No se encontraron datos para imprimir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea imprimir el corte de caja?", "Imprimir Corte de caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                frm_impresiones_directas.ShowDialog(Me)
            End If
        End If
    End Sub

    'Private Sub InsertDetails()
    '    afs

    'End Sub

    Private Sub SetSecondID()
        Try
            Dim DsTemp As New DataSet

            Con.Open()
            DsTemp.Clear()
            cmd = New MySqlCommand("Select * FROM TipoDocumento WHERE IDTipoDocumento=59", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
            Dim lblSecondID, UltSecuencia As New Label

            lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
            UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)
            txtSecondID.Text = lblSecondID.Text

            sqlQ = "UPDATE CorteCaja Set SecondID='" + lblSecondID.Text + "' WHERE IDCorteCaja='" + txtIDCorte.Text + "'"
            GuardarDatos()

            sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=59"
            GuardarDatos()

            DsTemp.Dispose()
            Tabla.Dispose()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtEfectivoContado_Enter(sender As Object, e As EventArgs) Handles txtEfectivoContado.Enter
        If txtEfectivoContado.Text = "" Then
        Else
            txtEfectivoContado.Text = CDbl(txtEfectivoContado.Text)
            txtEfectivoContado.SelectAll()
        End If
    End Sub

    Private Sub txtChequeContado_Enter(sender As Object, e As EventArgs) Handles txtChequeContado.Enter
        If txtChequeContado.Text = "" Then
        Else
            txtChequeContado.Text = CDbl(txtChequeContado.Text)
            txtChequeContado.SelectAll()
        End If
    End Sub

    Private Sub txtTarjetaContado_Enter(sender As Object, e As EventArgs) Handles txtTarjetaContado.Enter
        If txtTarjetaContado.Text = "" Then
        Else
            txtTarjetaContado.Text = CDbl(txtTarjetaContado.Text)
            txtTarjetaContado.SelectAll()
        End If
    End Sub

    Private Sub txtTransferenciaContado_Enter(sender As Object, e As EventArgs) Handles txtTransferenciaContado.Enter
        If txtTransferenciaContado.Text = "" Then
        Else
            txtTransferenciaContado.Text = CDbl(txtTransferenciaContado.Text)
            txtTransferenciaContado.SelectAll()
        End If
    End Sub

    Private Sub txtEgresosContado_Enter(sender As Object, e As EventArgs) Handles txtEgresosContado.Enter
        If txtEgresosContado.Text = "" Then
        Else
            txtEgresosContado.Text = CDbl(txtEgresosContado.Text)
            txtEgresosContado.SelectAll()
        End If
    End Sub

    Private Sub txtEfectivoRetirar_Enter(sender As Object, e As EventArgs) Handles txtEfectivoRetirar.Enter
        If txtEfectivoRetirar.Text = "" Then
        Else
            txtEfectivoRetirar.Text = CDbl(txtEfectivoRetirar.Text)
            txtEfectivoRetirar.SelectAll()
        End If
    End Sub

    Private Sub txtChequeRetirar_Enter(sender As Object, e As EventArgs) Handles txtChequeRetirar.Enter
        If txtChequeRetirar.Text = "" Then
        Else
            txtChequeRetirar.Text = CDbl(txtChequeRetirar.Text)
            txtChequeRetirar.SelectAll()
        End If
    End Sub

    Private Sub txtTarjetaRetirar_Enter(sender As Object, e As EventArgs) Handles txtTarjetaRetirar.Enter
        If txtTarjetaRetirar.Text = "" Then
        Else
            txtTarjetaRetirar.Text = CDbl(txtTarjetaRetirar.Text)
            txtTarjetaRetirar.SelectAll()
        End If
    End Sub

    Private Sub txtTransferenciaRetirar_Enter(sender As Object, e As EventArgs) Handles txtTransferenciaRetirar.Enter
        If txtTransferenciaRetirar.Text = "" Then
        Else
            txtTransferenciaRetirar.Text = CDbl(txtTransferenciaRetirar.Text)
            txtTransferenciaRetirar.SelectAll()
        End If
    End Sub

    Private Sub txtEgresosRetirar_Enter(sender As Object, e As EventArgs) Handles txtEgresosRetirar.Enter
        If txtEgresosRetirar.Text = "" Then
        Else
            txtEgresosRetirar.Text = CDbl(txtEgresosRetirar.Text)
            txtEgresosRetirar.SelectAll()
        End If
    End Sub

    Private Sub txtEfectivoContado_Leave(sender As Object, e As EventArgs) Handles txtEfectivoContado.Leave
        Try
            If txtEfectivoContado.Text = "" Then
                txtEfectivoContado.Text = (0).ToString("C")
            Else
                txtEfectivoContado.Text = CDbl(txtEfectivoContado.Text).ToString("C")
            End If
        Catch ex As Exception
            txtEfectivoContado.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtChequeContado_Leave(sender As Object, e As EventArgs) Handles txtChequeContado.Leave
        Try
            If txtChequeContado.Text = "" Then
                txtChequeContado.Text = (0).ToString("C")
            Else
                txtChequeContado.Text = CDbl(txtChequeContado.Text).ToString("C")
            End If
        Catch ex As Exception
            txtChequeContado.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtTarjetaContado_Leave(sender As Object, e As EventArgs) Handles txtTarjetaContado.Leave
        Try
            If txtTarjetaContado.Text = "" Then
                txtTarjetaContado.Text = (0).ToString("C")
            Else
                txtTarjetaContado.Text = CDbl(txtTarjetaContado.Text).ToString("C")
            End If
        Catch ex As Exception
            txtTarjetaContado.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtTransferenciaContado_Leave(sender As Object, e As EventArgs) Handles txtTransferenciaContado.Leave
        Try
            If txtTransferenciaContado.Text = "" Then
                txtTransferenciaContado.Text = (0).ToString("C")
            Else
                txtTransferenciaContado.Text = CDbl(txtTransferenciaContado.Text).ToString("C")
            End If
        Catch ex As Exception
            txtTransferenciaContado.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtEgresosContado_Leave(sender As Object, e As EventArgs) Handles txtEgresosContado.Leave
        Try
            If txtEgresosContado.Text = "" Then
                txtEgresosContado.Text = (0).ToString("C")
            Else
                txtEgresosContado.Text = CDbl(txtEgresosContado.Text).ToString("C")
            End If
        Catch ex As Exception
            txtEgresosContado.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtEfectivoRetirar_Leave(sender As Object, e As EventArgs) Handles txtEfectivoRetirar.Leave
        Try
            If txtEfectivoRetirar.Text = "" Then
                txtEfectivoRetirar.Text = (0).ToString("C")
            Else
                txtEfectivoRetirar.Text = CDbl(txtEfectivoRetirar.Text).ToString("C")
            End If
        Catch ex As Exception
            txtEfectivoRetirar.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtChequeRetirar_Leave(sender As Object, e As EventArgs) Handles txtChequeRetirar.Leave
        Try
            If txtChequeRetirar.Text = "" Then
                txtChequeRetirar.Text = (0).ToString("C")
            Else
                txtChequeRetirar.Text = CDbl(txtChequeRetirar.Text).ToString("C")
            End If
        Catch ex As Exception
            txtChequeRetirar.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtTarjetaRetirar_Leave(sender As Object, e As EventArgs) Handles txtTarjetaRetirar.Leave
        Try
            If txtTarjetaRetirar.Text = "" Then
                txtTarjetaRetirar.Text = (0).ToString("C")
            Else
                txtTarjetaRetirar.Text = CDbl(txtTarjetaRetirar.Text).ToString("C")
            End If
        Catch ex As Exception
            txtTarjetaRetirar.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtTransferenciaRetirar_Leave(sender As Object, e As EventArgs) Handles txtTransferenciaRetirar.Leave
        Try
            If txtTransferenciaRetirar.Text = "" Then
                txtTransferenciaRetirar.Text = (0).ToString("C")
            Else
                txtTransferenciaRetirar.Text = CDbl(txtTransferenciaRetirar.Text).ToString("C")
            End If
        Catch ex As Exception
            txtTransferenciaRetirar.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtEgresosRetirar_Leave(sender As Object, e As EventArgs) Handles txtEgresosRetirar.Leave
        Try
            If txtEgresosRetirar.Text = "" Then
                txtEgresosRetirar.Text = (0).ToString("C")
            Else
                txtEgresosRetirar.Text = CDbl(txtEgresosRetirar.Text).ToString("C")
            End If
        Catch ex As Exception
            txtEgresosRetirar.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtEfectivoContado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEfectivoContado.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtChequeContado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtChequeContado.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtTarjetaContado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarjetaContado.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtTransferenciaContado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransferenciaContado.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtEgresosContado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEgresosContado.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtEfectivoRetirar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEfectivoRetirar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtChequeRetirar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtChequeRetirar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtTarjetaRetirar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarjetaRetirar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtTransferenciaRetirar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransferenciaRetirar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtEgresosRetirar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEgresosRetirar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtEfectivoContado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivoContado.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtEfectivoContado.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtChequeContado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChequeContado.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtChequeContado.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTarjetaContado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarjetaContado.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtTarjetaContado.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTransferenciaContado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTransferenciaContado.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtTransferenciaContado.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtEgresosContado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEgresosContado.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtEgresosContado.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtEfectivoRetirar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivoRetirar.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtEfectivoRetirar.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtChequeRetirar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChequeRetirar.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtChequeRetirar.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTarjetaRetirar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarjetaRetirar.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtTarjetaRetirar.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTransferenciaRetirar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTransferenciaRetirar.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtTransferenciaRetirar.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtEgresosRetirar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEgresosRetirar.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtEgresosRetirar.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtEfectivoContado_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivoContado.TextChanged
        Try
            If txtEfectivoContado.Text = "" Then
                txtEfectivoContado.Text = 0
                txtEfectivoContado.SelectAll()
            End If

            txtTotalContado.Text = (CDbl(txtEfectivoContado.Text) + CDbl(txtChequeContado.Text) + CDbl(txtDepositoContado.Text) + CDbl(txtTarjetaContado.Text) + CDbl(txtTransferenciaContado.Text) - CDbl(txtEgresosContado.Text)).ToString("C")
            txtEfectivoDiferencia.Text = (CDbl(txtEfectivoContado.Text) - CDbl(txtEfectivoCalculado.Text)).ToString("C")

            txtEfectivoRetirar.Text = CDbl(txtEfectivoContado.Text).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtChequeContado_TextChanged(sender As Object, e As EventArgs) Handles txtChequeContado.TextChanged
        Try
            If txtChequeContado.Text = "" Then
                txtChequeContado.Text = 0
                txtChequeContado.SelectAll()
            End If

            txtTotalContado.Text = (CDbl(txtEfectivoContado.Text) + CDbl(txtChequeContado.Text) + CDbl(txtDepositoContado.Text) + CDbl(txtTarjetaContado.Text) - CDbl(txtTransferenciaContado.Text) - CDbl(txtEgresosContado.Text)).ToString("C")
            txtChequeDiferencia.Text = (CDbl(txtChequeContado.Text) - CDbl(txtChequeCalculado.Text)).ToString("C")
            txtChequeRetirar.Text = CDbl(txtChequeContado.Text).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTarjetaContado_TextChanged(sender As Object, e As EventArgs) Handles txtTarjetaContado.TextChanged
        Try
            If txtTarjetaContado.Text = "" Then
                txtTarjetaContado.Text = 0
                txtTarjetaContado.SelectAll()
            End If

            txtTotalContado.Text = (CDbl(txtEfectivoContado.Text) + CDbl(txtChequeContado.Text) + CDbl(txtDepositoContado.Text) + CDbl(txtTarjetaContado.Text) + CDbl(txtTransferenciaContado.Text) - CDbl(txtEgresosContado.Text)).ToString("C")
            txtTarjetaDiferencia.Text = (CDbl(txtTarjetaContado.Text) - CDbl(txtTarjetaCalculado.Text)).ToString("C")
            txtTarjetaRetirar.Text = CDbl(txtTarjetaContado.Text).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTransferenciaContado_TextChanged(sender As Object, e As EventArgs) Handles txtTransferenciaContado.TextChanged
        Try
            If txtTransferenciaContado.Text = "" Then
                txtTransferenciaContado.Text = 0
                txtTransferenciaContado.SelectAll()
            End If

            txtTotalContado.Text = (CDbl(txtEfectivoContado.Text) + CDbl(txtChequeContado.Text) + CDbl(txtDepositoContado.Text) + CDbl(txtTarjetaContado.Text) + CDbl(txtTransferenciaContado.Text) - CDbl(txtEgresosContado.Text)).ToString("C")
            txtTransferenciaDiferencia.Text = (CDbl(txtTransferenciaContado.Text) - CDbl(txtTransferenciaCalculado.Text)).ToString("C")
            txtTransferenciaRetirar.Text = CDbl(txtTransferenciaContado.Text).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtEgresosContado_TextChanged(sender As Object, e As EventArgs) Handles txtEgresosContado.TextChanged
        Try
            If txtEgresosContado.Text = "" Then
                txtEgresosContado.Text = 0
                txtEgresosContado.SelectAll()
            End If

            txtTotalContado.Text = (CDbl(txtEfectivoContado.Text) + CDbl(txtChequeContado.Text) + CDbl(txtDepositoContado.Text) + CDbl(txtTarjetaContado.Text) + CDbl(txtTransferenciaContado.Text) - CDbl(txtEgresosContado.Text)).ToString("C")
            txtEgresosDiferencia.Text = (CDbl(txtEgresosContado.Text) - CDbl(txtEgresosCalculado.Text)).ToString("C")
            txtEgresosRetirar.Text = CDbl(txtEgresosContado.Text).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtEfectivoDiferencia_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivoDiferencia.TextChanged
        Try
            If txtEfectivoDiferencia.Text = "" Then
                txtEfectivoDiferencia.Text = 0
            End If
            txtTotalDiferencia.Text = (CDbl(txtEfectivoDiferencia.Text) + CDbl(txtChequeDiferencia.Text) + CDbl(txtDepositoRetirar.Text) + CDbl(txtTarjetaDiferencia.Text) + CDbl(txtTransferenciaDiferencia.Text) - CDbl(txtBonosDiferencia.Text) - CDbl(txtPermutaDiferencia.Text) - CDbl(txtOtrasDiferencia.Text) - CDbl(txtEgresosDiferencia.Text)).ToString("C")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtChequeDiferencia_TextChanged(sender As Object, e As EventArgs) Handles txtChequeDiferencia.TextChanged
        Try
            If txtChequeDiferencia.Text = "" Then
                txtChequeDiferencia.Text = 0
            End If

            txtTotalDiferencia.Text = (CDbl(txtEfectivoDiferencia.Text) + CDbl(txtChequeDiferencia.Text) + CDbl(txtDepositoRetirar.Text) + CDbl(txtTarjetaDiferencia.Text) + CDbl(txtTransferenciaDiferencia.Text) - CDbl(txtBonosDiferencia.Text) - CDbl(txtPermutaDiferencia.Text) - CDbl(txtOtrasDiferencia.Text) - CDbl(txtEgresosDiferencia.Text)).ToString("C")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtTarjetaDiferencia_TextChanged(sender As Object, e As EventArgs) Handles txtTarjetaDiferencia.TextChanged
        Try
            If txtTarjetaDiferencia.Text = "" Then
                txtTarjetaDiferencia.Text = 0
            End If

            txtTotalDiferencia.Text = (CDbl(txtEfectivoDiferencia.Text) + CDbl(txtChequeDiferencia.Text) + CDbl(txtDepositoRetirar.Text) + CDbl(txtTarjetaDiferencia.Text) + CDbl(txtTransferenciaDiferencia.Text) - CDbl(txtBonosDiferencia.Text) - CDbl(txtPermutaDiferencia.Text) - CDbl(txtOtrasDiferencia.Text) - CDbl(txtEgresosDiferencia.Text)).ToString("C")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtTransferenciaDiferencia_TextChanged(sender As Object, e As EventArgs) Handles txtTransferenciaDiferencia.TextChanged
        Try
            If txtTransferenciaDiferencia.Text = "" Then
                txtTransferenciaDiferencia.Text = 0
            End If

            txtTotalDiferencia.Text = (CDbl(txtEfectivoDiferencia.Text) + CDbl(txtChequeDiferencia.Text) + CDbl(txtDepositoRetirar.Text) + CDbl(txtTarjetaDiferencia.Text) + CDbl(txtTransferenciaDiferencia.Text) - CDbl(txtBonosDiferencia.Text) - CDbl(txtPermutaDiferencia.Text) - CDbl(txtOtrasDiferencia.Text) - CDbl(txtEgresosDiferencia.Text)).ToString("C")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtEgresosDiferencia_TextChanged(sender As Object, e As EventArgs) Handles txtEgresosDiferencia.TextChanged
        Try
            If txtEgresosDiferencia.Text = "" Then
                txtEgresosDiferencia.Text = 0
            End If

            txtTotalDiferencia.Text = (CDbl(txtEfectivoDiferencia.Text) + CDbl(txtChequeDiferencia.Text) + CDbl(txtDepositoRetirar.Text) + CDbl(txtTarjetaDiferencia.Text) + CDbl(txtTransferenciaDiferencia.Text) - CDbl(txtBonosDiferencia.Text) - CDbl(txtPermutaDiferencia.Text) - CDbl(txtOtrasDiferencia.Text) - CDbl(txtEgresosDiferencia.Text)).ToString("C")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtEfectivoRetirar_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivoRetirar.TextChanged
        Try
            If txtEfectivoRetirar.Text = "" Then
                txtEfectivoRetirar.Text = 0
                txtEfectivoRetirar.SelectAll()
            End If

            txtTotalRetirar.Text = (CDbl(txtEfectivoRetirar.Text) + CDbl(txtChequeRetirar.Text) + CDbl(txtDepositoRetirar.Text) + CDbl(txtTarjetaRetirar.Text) + CDbl(txtTransferenciaRetirar.Text) - CDbl(txtBonosRetirar.Text) - CDbl(txtPermutaRetirar.Text) - CDbl(txtOtrasRetirar.Text) - CDbl(txtEgresosRetirar.Text)).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtChequeRetirar_TextChanged(sender As Object, e As EventArgs) Handles txtChequeRetirar.TextChanged
        Try
            If txtChequeRetirar.Text = "" Then
                txtChequeRetirar.Text = 0
                txtChequeRetirar.SelectAll()
            End If

            txtTotalRetirar.Text = (CDbl(txtEfectivoRetirar.Text) + CDbl(txtChequeRetirar.Text) + CDbl(txtDepositoRetirar.Text) + CDbl(txtTarjetaRetirar.Text) + CDbl(txtTransferenciaRetirar.Text) - CDbl(txtBonosRetirar.Text) - CDbl(txtPermutaRetirar.Text) - CDbl(txtOtrasRetirar.Text) - CDbl(txtEgresosRetirar.Text)).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTarjetaRetirar_TextChanged(sender As Object, e As EventArgs) Handles txtTarjetaRetirar.TextChanged
        Try
            If txtTarjetaRetirar.Text = "" Then
                txtTarjetaRetirar.Text = 0
                txtTarjetaRetirar.SelectAll()
            End If

            txtTotalRetirar.Text = (CDbl(txtEfectivoRetirar.Text) + CDbl(txtChequeRetirar.Text) + CDbl(txtDepositoRetirar.Text) + CDbl(txtTarjetaRetirar.Text) + CDbl(txtTransferenciaRetirar.Text) - CDbl(txtBonosRetirar.Text) - CDbl(txtPermutaRetirar.Text) - CDbl(txtOtrasRetirar.Text) - CDbl(txtEgresosRetirar.Text)).ToString("C")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtTransferenciaRetirar_TextChanged(sender As Object, e As EventArgs) Handles txtTransferenciaRetirar.TextChanged

        Try
            If txtTransferenciaRetirar.Text = "" Then
                txtTransferenciaRetirar.Text = 0
                txtTransferenciaRetirar.SelectAll()
            End If

            txtTotalRetirar.Text = (CDbl(txtEfectivoRetirar.Text) + CDbl(txtChequeRetirar.Text) + CDbl(txtDepositoRetirar.Text) + CDbl(txtTarjetaRetirar.Text) + CDbl(txtTransferenciaRetirar.Text) - CDbl(txtBonosRetirar.Text) - CDbl(txtPermutaRetirar.Text) - CDbl(txtOtrasRetirar.Text) - CDbl(txtEgresosRetirar.Text)).ToString("C")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtEgresosRetirar_TextChanged(sender As Object, e As EventArgs) Handles txtEgresosRetirar.TextChanged
        Try
            If txtEgresosRetirar.Text = "" Then
                txtEgresosRetirar.Text = 0
                txtEgresosRetirar.SelectAll()
            End If

            txtTotalRetirar.Text = (CDbl(txtEfectivoRetirar.Text) + CDbl(txtChequeRetirar.Text) + CDbl(txtDepositoRetirar.Text) + CDbl(txtTarjetaRetirar.Text) + CDbl(txtTransferenciaRetirar.Text) - CDbl(txtBonosRetirar.Text) - CDbl(txtPermutaRetirar.Text) - CDbl(txtOtrasRetirar.Text) - CDbl(txtEgresosRetirar.Text)).ToString("C")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        DgvTransacciones.ClearSelection()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnNuevo.PerformClick()
    End Sub

    Private Sub GuardarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarRegistroToolStripMenuItem.Click
        btnGuardarC.PerformClick()
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub QuitarArtículoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarArtículoToolStripMenuItem.Click
        btnAnular.PerformClick()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodoRango.CheckedChanged
        If chkTodoRango.Checked = True Then
            dtpDesde.Enabled = False
            dtpHasta.Enabled = False
            lblRango.ForeColor = SystemColors.Highlight
            lblRango.Text = "       El rango de fechas está completado"
            lblRango.Image = My.Resources.Plux16
        Else
            lblRango.ForeColor = Color.Red
            lblRango.Text = "       El rango de fechas ha sido intervenido por el usuario"
            lblRango.Image = My.Resources.Notx16
            dtpDesde.Enabled = True
            dtpHasta.Enabled = True
        End If
    End Sub

    Private Sub frm_corte_caja_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadColumnsDvg()
        PropiedadColumnasHistorial()
        PropiedadColumnasMovimientos()
    End Sub

    Private Sub PropiedadColumnasHistorial()
        Try
            Dim VScrollBarWidht As Double = 0

            If VScrollBarVisible(DgvHistorial) = True Then
                VScrollBarWidht = 16
            Else
                VScrollBarWidht = 0
            End If


            Dim DatagridWith As Double = (DgvHistorial.Width - 40 - DgvHistorial.RowHeadersWidth - VScrollBarWidht) / 100


            If Privilegios = 1 Or Privilegios = 4 Then
                With DgvHistorial
                    .Columns(1).Width = DatagridWith * 10
                    .Columns(2).Width = DatagridWith * 14
                    .Columns(4).Width = DatagridWith * 16
                    .Columns(5).Width = DatagridWith * 20
                    .Columns(6).Width = DatagridWith * 10
                    .Columns(7).Visible = True
                    .Columns(7).Width = DatagridWith * 10
                    .Columns(8).Width = DatagridWith * 10
                    .Columns(9).Width = DatagridWith * 10
                    .Columns(9).Visible = True
                End With
            Else
                With DgvHistorial
                    .Columns(1).Width = DatagridWith * 14
                    .Columns(2).Width = DatagridWith * 16
                    .Columns(4).Width = DatagridWith * 16
                    .Columns(5).Width = DatagridWith * 30
                    .Columns(6).Width = DatagridWith * 12
                    .Columns(7).Visible = False
                    .Columns(8).Width = DatagridWith * 12
                    .Columns(9).Visible = True
                End With

            End If



        Catch ex As Exception

        End Try
    End Sub

    Private Function VScrollBarVisible(ByVal Dgv As DataGridView) As Boolean
        Dim ctrl As New Control
        For Each ctrl In Dgv.Controls
            If ctrl.GetType() Is GetType(VScrollBar) Then
                If ctrl.Visible = True Then
                    Return True
                Else
                    Return False
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Sub PropiedadColumnasMovimientos()
        Try
            Dim VScrollBarWidht As Integer = 0

            If VScrollBarVisible(DgvMovimientos) = True Then
                VScrollBarWidht = 16
            Else
                VScrollBarWidht = 0
            End If

            Dim DatagridWith As Double = (DgvMovimientos.Width - DgvMovimientos.RowHeadersWidth - VScrollBarWidht) / 100

            With DgvMovimientos
                .Columns(0).Width = DatagridWith * 16
                .Columns(1).Width = DatagridWith * 20
                .Columns(2).Width = DatagridWith * 20
                .Columns(3).Width = DatagridWith * 8
                .Columns(4).Width = DatagridWith * 12
                .Columns(5).Width = DatagridWith * 12
                .Columns(6).Width = DatagridWith * 12
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarHistorial()

        Dim EmployeePhoto As Image

        DgvHistorial.Rows.Clear()
        Con.Open()
        Dim Consulta As New MySqlCommand("SELECT IDCorteCaja,SecondID,Fecha,if(TodasCajas=1,'Todas las cajas',AreaImpresion.ComputerName) as Equipo,Empleados.RutaFoto,if(TodosUsuarios=1,'Todos los usuarios',Empleados.Nombre) as Usuario,if(TodoRango=1,'Todo el rango disponible',Concat('Del ',DATE_FORMAT(DesdeFecha,'%d/%m/%Y %r'), ' hasta ' ,DATE_FORMAT(HastaFecha,'%d/%m/%Y %r'))) as RangoFecha,ContadoTotal,CalculadoTotal,DiferenciaTotal,RetiroTotal,CorteCaja.Nulo FROM cortecaja INNER JOIN Empleados on CorteCaja.IDUsuario=Empleados.IDEmpleado  INNER JOIN AreaImpresion on CorteCaja.IDAreaImpresion=AreaImpresion.IDEquipo Where CorteCaja.Nulo=0" + If(cbxEmpleado.Text = "Todos", "", " AND CorteCaja.IDCreadorUsuario='" + DTEmpleado.Rows(0).Item("IDEmpleado").ToString() + "'") + " AND DATE(Fecha)=CURDATE() ORDER BY IDCorteCaja DESC", Con)
        Dim LectorCortes As MySqlDataReader = Consulta.ExecuteReader

        While LectorCortes.Read
            If TypeConnection.Text = 1 Then
                If LectorCortes.GetValue(4) = "" Then
                    EmployeePhoto = My.Resources.No_Image
                Else
                    If LectorCortes.GetValue(5) = "Todos los usuarios" Then
                        EmployeePhoto = My.Resources.No_Image
                    Else
                        Dim ExistFile As Boolean = System.IO.File.Exists(LectorCortes.GetValue(4))
                        If ExistFile = True Then
                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(LectorCortes.GetValue(4), FileMode.Open, FileAccess.Read)
                            EmployeePhoto = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                        Else
                            EmployeePhoto = My.Resources.No_Image
                        End If
                    End If

                End If
            End If


            DgvHistorial.Rows.Add(LectorCortes.GetValue(0), LectorCortes.GetValue(1), LectorCortes.GetValue(2), EmployeePhoto, LectorCortes.GetValue(5), LectorCortes.GetValue(6), CDbl(LectorCortes.GetValue(7)).ToString("C"), CDbl(LectorCortes.GetValue(8)).ToString("C"), CDbl(LectorCortes.GetValue(9)).ToString("C"), CDbl(LectorCortes.GetValue(10)).ToString("C"))

        End While

        LectorCortes.Close()
        Con.Close()
    End Sub

    Private Sub LlenarMovimientos()
        DgvMovimientos.Rows.Clear()

        Con.Open()

        Dim dsTemp As New DataSet
        cmd = New MySqlCommand("SELECT IDCorteCaja,SecondID,Fecha,ContadoTotal,CalculadoTotal,DiferenciaTotal,RetiroTotal From CorteCaja where date(Fecha)=CurDate() ORDER BY Fecha ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(dsTemp, "CorteCaja")


        Dim Tabla As DataTable = dsTemp.Tables("CorteCaja")

        For Each dt As DataRow In Tabla.Rows
            Dim Consulta As New MySqlCommand("SELECT FechaHora,Documento,NombreUsuario,if(Nulo=0,'Activo','Cancelado') as Estado,Débito,Crédito,Nulo FROM" & SysName.Text & "movimientoscortecajaview where IDCorteCaja='" + dt.Item("IDCorteCaja").ToString + "' ORDER BY FechaHora ASC", Con)
            Dim LectorCortes As MySqlDataReader = Consulta.ExecuteReader

            While LectorCortes.Read
                DgvMovimientos.Rows.Add(CDate(LectorCortes.GetValue(0)).ToString("dd/MM/yyyy hh:mm:ss tt"), LectorCortes.GetValue(1), LectorCortes.GetValue(2), LectorCortes.GetValue(3), CDbl(LectorCortes.GetValue(4)).ToString("C"), CDbl(LectorCortes.GetValue(5)).ToString("C"), LectorCortes.GetValue(6))
            End While

            LectorCortes.Close()
        Next

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Tabla.Rows.Clear()
        dsTemp.Clear()

        cmd = New MySqlCommand("SELECT NOW()", Con)
        Dim Dat As New DateTime
        Dat = Convert.ToDateTime(cmd.ExecuteScalar())
        dtpHasta.MaxDate = Dat

        Dim SQLSetence As String = "SELECT FechaHora,Documento,NombreUsuario,if(Nulo=0,'Activo','Cancelado') as Estado,Débito,Crédito,Nulo FROM cortecajadetalleview"

        If chkTodoRango.Checked = True Then
            SQLSetence = SQLSetence & " WHERE FechaHora Between '" + dtpDesde.MinDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + dtpHasta.MaxDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND IDCorteCaja IS NULL ORDER BY FechaHora ASC"
        Else
            SQLSetence = SQLSetence & " WHERE FechaHora Between '" + dtpDesde.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + dtpHasta.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' AND IDCorteCaja IS NULL ORDER BY FechaHora ASC"
        End If

        If cbxEmpleado.Text <> "Todos" Then
            SQLSetence = SQLSetence & " And IDUsuario='" + cbxEmpleado.Tag.ToString + "'"
        End If

        If cbxAreaImpresion.Text <> "Todos" Then
            SQLSetence = SQLSetence & " AND IDEquipo='" + cbxAreaImpresion.Tag.ToString + "'"
        End If

        Dim Consulta1 As New MySqlCommand(SQLSetence, Con)
        Dim LectorCortes1 As MySqlDataReader = Consulta1.ExecuteReader

        While LectorCortes1.Read
            DgvMovimientos.Rows.Add(CDate(LectorCortes1.GetValue(0)).ToString("dd/MM/yyyy hh:mm:ss tt"), LectorCortes1.GetValue(1), LectorCortes1.GetValue(2), LectorCortes1.GetValue(3), CDbl(LectorCortes1.GetValue(4)).ToString("C"), CDbl(LectorCortes1.GetValue(5)).ToString("C"), LectorCortes1.GetValue(6))
        End While

        LectorCortes1.Close()

        Con.Close()

        Dim Total As Double = 0
        For Each rw As DataGridViewRow In DgvMovimientos.Rows
            If rw.Cells(6).Value = 0 Then
                Total = Total + CDbl(rw.Cells(4).Value) - CDbl(rw.Cells(5).Value)
                rw.Cells(6).Value = CDbl(Total).ToString("C")
            Else
                rw.Cells(6).Value = CDbl(Total).ToString("C")
            End If

        Next

    End Sub

    Private Sub NavBarGroup4_ItemChanged(sender As Object, e As EventArgs) Handles NavBarGroup4.ItemChanged
        If NavBarGroup4.Expanded Then
            If NavBarGroup3.Expanded Then
                NavBarControl2.Size = New Size(542, 276)
            End If
        Else
            NavBarControl2.Size = New Size(542, 124)
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        ImprimirDocumento()
    End Sub

    Private Sub DgvMovimientos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DgvMovimientos.RowsAdded
        If DgvMovimientos.Rows(e.RowIndex).Cells(3).Value = "Activo" Then
            DgvMovimientos.Rows(e.RowIndex).Cells(3).Style.BackColor = SystemColors.Highlight
            DgvMovimientos.Rows(e.RowIndex).Cells(3).Style.ForeColor = Color.White
        Else
            DgvMovimientos.Rows(e.RowIndex).Cells(3).Style.BackColor = Color.Red
            DgvMovimientos.Rows(e.RowIndex).Cells(3).Style.ForeColor = Color.Black
        End If

        If CDbl(DgvMovimientos.Rows(e.RowIndex).Cells(5).Value) > 0 Then
            DgvMovimientos.Rows(e.RowIndex).Cells(5).Style.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If txtIDCorte.Text = "" Then
            MessageBox.Show("No hay un registro de depósito de factura abierto para desactivar.", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else
            If ChkNulo.Checked = True Then

                Dim Result1 As MsgBoxResult = MessageBox.Show("El corte de caja ya está desactivado del sistema. Desea volver a activarlo?", "Activar corte de caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result1 = MsgBoxResult.Yes Then
                    ChkNulo.Checked = False
                    sqlQ = "UPDATE cortecaja SET Nulo='" + Convert.ToInt16(ChkNulo.CheckState).ToString + "' WHERE idCorteCaja= (" + txtIDCorte.Text + ")"
                    InsertDetails()
                    GuardarDatos()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Else

                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea anular el registro de corte de caja?", "Desactivar corte de caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    ChkNulo.Checked = True
                    sqlQ = "UPDATE cortecaja SET Nulo='" + Convert.ToInt16(ChkNulo.CheckState).ToString + "' WHERE idCorteCaja= (" + txtIDCorte.Text + ")"
                    GuardarDatos()
                    AnularDetails()
                    MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If
        End If
    End Sub

    Private Sub AnularDetails()
        Dim ConB As New MySqlConnection(CnString)

        ConB.Open()

        For Each rw As DataGridViewRow In DgvTransacciones.Rows
            'VENTAS DE CONTADO
            If rw.Cells("IDTipoDocumento").Value = 1 Then
                sqlQ = "UPDATE FacturaDatos SET IDCorteCaja=NULL WHERE IDCorteCaja='" + txtIDCorte.Text + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'VENTAS A CREDITO
            ElseIf rw.Cells("IDTipoDocumento").Value = 2 Then
                sqlQ = "UPDATE FacturaDatos SET IDCorteCaja=NULL WHERE IDCorteCaja='" + txtIDCorte.Text + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'REGISTROS DE FACTURAS SIN INVENTARIO
            ElseIf rw.Cells("IDTipoDocumento").Value = 12 Then
                sqlQ = "UPDATE FacturaDatos SET IDCorteCaja=NULL WHERE IDCorteCaja='" + txtIDCorte.Text + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'RECIBOS DE ABONO
            ElseIf rw.Cells("IDTipoDocumento").Value = 3 Then
                sqlQ = "UPDATE Abonos SET IDCorteCaja=NULL WHERE IDCorteCaja='" + txtIDCorte.Text + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                ''OTROS INGRESOS
            ElseIf rw.Cells("IDTipoDocumento").Value = 16 Then
                sqlQ = "UPDATE OtrosIngresos SET IDCorteCaja=NULL WHERE IDCorteCaja='" + txtIDCorte.Text + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'COBROS ADELANTADOS
            ElseIf rw.Cells("IDTipoDocumento").Value = 35 Then
                sqlQ = "UPDATE Cobrosadelantados SET IDCorteCaja=NULL WHERE IDCorteCaja='" + txtIDCorte.Text + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'DEVOLUCIONES
            ElseIf rw.Cells("IDTipoDocumento").Value = 13 Then
                sqlQ = "UPDATE devolucionventa SET IDCorteCaja=NULL WHERE IDCorteCaja='" + txtIDCorte.Text + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'EGRESOS
            ElseIf rw.Cells("IDTipoDocumento").Value = 23 Then
                sqlQ = "UPDATE egresos SET IDCorteCaja=NULL WHERE IDCorteCaja='" + txtIDCorte.Text + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'Financiamientos
            ElseIf rw.Cells("IDTipoDocumento").Value = 57 Then
                sqlQ = "UPDATE financiamientos SET IDCorteCaja=NULL WHERE IDCorteCaja='" + txtIDCorte.Text + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'Pagos a financiamientos
            ElseIf rw.Cells("IDTipoDocumento").Value = 58 Then
                sqlQ = "UPDATE pagosfinanciamientos SET IDCorteCaja=NULL WHERE IDCorteCaja='" + txtIDCorte.Text + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()
            End If

        Next

        ConB.Close()
    End Sub

    Private Sub DgvTransacciones_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvTransacciones.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvTransacciones.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvTransacciones.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvTransacciones.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvMovimientos_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvMovimientos.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvMovimientos.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvMovimientos.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvMovimientos.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))


        Catch ex As Exception
            InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub ChkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkNulo.CheckedChanged
        If ChkNulo.CheckState = CheckState.Checked Then
            NavBarControl2.Enabled = False
            XtraTabControl1.Enabled = False
        Else
            NavBarControl2.Enabled = True
            XtraTabControl1.Enabled = True
        End If

    End Sub

    Private Sub txtDepositoContado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDepositoContado.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub txtDepositoContado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDepositoContado.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtDepositoContado.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDepositoContado_Leave(sender As Object, e As EventArgs) Handles txtDepositoContado.Leave
        Try
            If txtDepositoContado.Text = "" Then
                txtDepositoContado.Text = (0).ToString("C")
            Else
                txtDepositoContado.Text = CDbl(txtDepositoContado.Text).ToString("C")
            End If
        Catch ex As Exception
            txtDepositoContado.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtDepositoContado_TextChanged(sender As Object, e As EventArgs) Handles txtDepositoContado.TextChanged
        Try
            If txtDepositoContado.Text = "" Then
                txtDepositoContado.Text = 0
                txtDepositoContado.SelectAll()
            End If

            txtTotalContado.Text = (CDbl(txtEfectivoContado.Text) + CDbl(txtChequeContado.Text) + CDbl(txtDepositoContado.Text) + CDbl(txtTarjetaContado.Text) + CDbl(txtTransferenciaContado.Text) - CDbl(txtEgresosContado.Text)).ToString("C")
            txtDepositoDiferencia.Text = (CDbl(txtDepositoContado.Text) - CDbl(txtDepositoCalculado.Text)).ToString("C")

            txtDepositoRetirar.Text = CDbl(txtDepositoContado.Text).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBonosContado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBonosContado.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtBonosContado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBonosContado.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtBonosContado.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtBonosContado_Leave(sender As Object, e As EventArgs) Handles txtBonosContado.Leave
        Try
            If txtBonosContado.Text = "" Then
                txtBonosContado.Text = (0).ToString("C")
            Else
                txtBonosContado.Text = CDbl(txtBonosContado.Text).ToString("C")
            End If
        Catch ex As Exception
            txtBonosContado.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtBonosContado_TextChanged(sender As Object, e As EventArgs) Handles txtBonosContado.TextChanged
        Try
            If txtBonosContado.Text = "" Then
                txtBonosContado.Text = 0
                txtBonosContado.SelectAll()
            End If

            txtTotalContado.Text = (CDbl(txtEfectivoContado.Text) + CDbl(txtChequeContado.Text) + CDbl(txtDepositoContado.Text) + CDbl(txtTarjetaContado.Text) + CDbl(txtTransferenciaContado.Text) - CDbl(txtEgresosContado.Text)).ToString("C")
            txtBonosDiferencia.Text = (CDbl(txtBonosContado.Text) - CDbl(txtBonosCalculado.Text)).ToString("C")

            txtBonosRetirar.Text = CDbl(txtBonosContado.Text).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPermutaContado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPermutaContado.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPermutaContado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPermutaContado.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtPermutaContado.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPermutaContado_Leave(sender As Object, e As EventArgs) Handles txtPermutaContado.Leave
        Try
            If txtPermutaContado.Text = "" Then
                txtPermutaContado.Text = (0).ToString("C")
            Else
                txtPermutaContado.Text = CDbl(txtPermutaContado.Text).ToString("C")
            End If
        Catch ex As Exception
            txtPermutaContado.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtPermutaContado_TextChanged(sender As Object, e As EventArgs) Handles txtPermutaContado.TextChanged
        Try
            If txtPermutaContado.Text = "" Then
                txtPermutaContado.Text = 0
                txtPermutaContado.SelectAll()
            End If

            txtTotalContado.Text = (CDbl(txtEfectivoContado.Text) + CDbl(txtChequeContado.Text) + CDbl(txtDepositoContado.Text) + CDbl(txtTarjetaContado.Text) + CDbl(txtTransferenciaContado.Text) - CDbl(txtEgresosContado.Text)).ToString("C")
            txtPermutaDiferencia.Text = (CDbl(txtPermutaContado.Text) - CDbl(txtPermutaCalculado.Text)).ToString("C")

            txtPermutaRetirar.Text = CDbl(txtPermutaContado.Text).ToString("C")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtOtrasContado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtrasContado.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtOtrasContado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOtrasContado.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = ".0123456789"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If

        If (txtOtrasContado.Text.IndexOf("-") >= 0 And e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtOtrasContado_Leave(sender As Object, e As EventArgs) Handles txtOtrasContado.Leave
        Try
            If txtOtrasContado.Text = "" Then
                txtOtrasContado.Text = (0).ToString("C")
            Else
                txtOtrasContado.Text = CDbl(txtOtrasContado.Text).ToString("C")
            End If
        Catch ex As Exception
            txtOtrasContado.Text = (0).ToString("C")
        End Try
    End Sub

    Private Sub txtOtrasContado_TextChanged(sender As Object, e As EventArgs) Handles txtOtrasContado.TextChanged
        Try
            If txtOtrasContado.Text = "" Then
                txtOtrasContado.Text = 0
                txtOtrasContado.SelectAll()
            End If

            txtTotalContado.Text = (CDbl(txtEfectivoContado.Text) + CDbl(txtChequeContado.Text) + CDbl(txtDepositoContado.Text) + CDbl(txtTarjetaContado.Text) + CDbl(txtTransferenciaContado.Text) - CDbl(txtEgresosContado.Text)).ToString("C")
            txtOtrasDiferencia.Text = (CDbl(txtOtrasContado.Text) - CDbl(txtOtrasCalculado.Text)).ToString("C")

            txtOtrasRetirar.Text = CDbl(txtOtrasContado.Text).ToString("C")

        Catch ex As Exception

        End Try
    End Sub


    Private Sub InsertDetails()
        Dim ConB As New MySqlConnection(CnString)

        ConB.Open()

        For Each rw As DataGridViewRow In DgvTransacciones.Rows
            'VENTAS DE CONTADO
            If rw.Cells("IDTipoDocumento").Value = 1 Then
                sqlQ = "UPDATE FacturaDatos SET IDCorteCaja='" + txtIDCorte.Text + "' WHERE IDFacturaDatos='" + rw.Cells("Codigo").Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'VENTAS A CREDITO
            ElseIf rw.Cells("IDTipoDocumento").Value = 2 Then
                sqlQ = "UPDATE FacturaDatos SET IDCorteCaja='" + txtIDCorte.Text + "' WHERE IDFacturaDatos='" + rw.Cells("Codigo").Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'REGISTROS DE FACTURAS SIN INVENTARIO
            ElseIf rw.Cells("IDTipoDocumento").Value = 12 Then
                sqlQ = "UPDATE FacturaDatos SET IDCorteCaja='" + txtIDCorte.Text + "' WHERE IDFacturaDatos='" + rw.Cells("Codigo").Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'RECIBOS DE ABONO
            ElseIf rw.Cells("IDTipoDocumento").Value = 3 Then
                sqlQ = "UPDATE Abonos SET IDCorteCaja='" + txtIDCorte.Text + "' WHERE IDAbono='" + rw.Cells("Codigo").Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                ''OTROS INGRESOS
            ElseIf rw.Cells("IDTipoDocumento").Value = 16 Then
                sqlQ = "UPDATE OtrosIngresos SET IDCorteCaja='" + txtIDCorte.Text + "' WHERE IDOtrosIngresos='" + rw.Cells("Codigo").Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'COBROS ADELANTADOS
            ElseIf rw.Cells("IDTipoDocumento").Value = 35 Then
                sqlQ = "UPDATE Cobrosadelantados SET IDCorteCaja='" + txtIDCorte.Text + "' WHERE IDCobrosAdelantados='" + rw.Cells("Codigo").Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'DEVOLUCIONES
            ElseIf rw.Cells("IDTipoDocumento").Value = 13 Then
                sqlQ = "UPDATE devolucionventa SET IDCorteCaja='" + txtIDCorte.Text + "' WHERE IDDevolucionVenta='" + rw.Cells("Codigo").Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'EGRESOS
            ElseIf rw.Cells("IDTipoDocumento").Value = 23 Then
                sqlQ = "UPDATE egresos SET IDCorteCaja='" + txtIDCorte.Text + "' WHERE IDEgresos='" + rw.Cells("Codigo").Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'Financiamientos
            ElseIf rw.Cells("IDTipoDocumento").Value = 57 Then
                sqlQ = "UPDATE financiamientos SET IDCorteCaja='" + txtIDCorte.Text + "' WHERE idFinanciamientos='" + rw.Cells("Codigo").Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()

                'Pagos a financiamientos
            ElseIf rw.Cells("IDTipoDocumento").Value = 58 Then
                sqlQ = "UPDATE pagosfinanciamientos SET IDCorteCaja='" + txtIDCorte.Text + "' WHERE idPagosFinanciamientos='" + rw.Cells("Codigo").Value.ToString + "'"
                cmd = New MySqlCommand(sqlQ, ConB)
                cmd.ExecuteNonQuery()
            End If

        Next

        ConB.Close()
    End Sub

End Class