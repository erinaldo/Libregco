Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_buscar_corte_caja
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_corte_caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub
    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbCodigo.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCorteCaja,SecondID,Fecha,UsuarioCreador.Nombre as Creador,if(TodoRango=1,'Todo el rango disponible',Concat('Del ',DATE_FORMAT(DesdeFecha,'%d/%m/%Y %r'), ' hasta ' ,DATE_FORMAT(HastaFecha,'%d/%m/%Y %r'))) as RangoFecha,if(TodosUsuarios=1,'Todos los usuarios',Empleados.Nombre) as Usuario,ContadoTotal,CalculadoTotal,DiferenciaTotal,RetiroTotal,CorteCaja.Nulo FROM " & SysName.Text & "cortecaja  INNER JOIN" & SysName.Text & "Empleados as UsuarioCreador on CorteCaja.IDCreadorUsuario=UsuarioCreador.IDEmpleado INNER JOIN" & SysName.Text & "Empleados on CorteCaja.IDUsuario=Empleados.IDEmpleado where CorteCaja.IDCorteCaja like '%" + txtBuscar.Text + "%' ORDER BY Fecha DESC", ConMixta)
            ElseIf rdbCorteCaja.Checked = True Then
                cmd = New MySqlCommand("SELECT IDCorteCaja,SecondID,Fecha,UsuarioCreador.Nombre as Creador,if(TodoRango=1,'Todo el rango disponible',Concat('Del ',DATE_FORMAT(DesdeFecha,'%d/%m/%Y %r'), ' hasta ' ,DATE_FORMAT(HastaFecha,'%d/%m/%Y %r'))) as RangoFecha,if(TodosUsuarios=1,'Todos los usuarios',Empleados.Nombre) as Usuario,ContadoTotal,CalculadoTotal,DiferenciaTotal,RetiroTotal,CorteCaja.Nulo FROM " & SysName.Text & "cortecaja  INNER JOIN" & SysName.Text & "Empleados as UsuarioCreador on CorteCaja.IDCreadorUsuario=UsuarioCreador.IDEmpleado INNER JOIN" & SysName.Text & "Empleados on CorteCaja.IDUsuario=Empleados.IDEmpleado where CorteCaja.SecondID like '%" + txtBuscar.Text + "%' ORDER BY SecondID DESC", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Financiamientos")

            Bs.DataMember = "Financiamientos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvCorteCaja.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCorteCaja.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        If frm_corte_caja.Privilegios = 1 Then
            With DgvCorteCaja
                .Columns(0).HeaderText = "IDFinanciamiento"
                .Columns(0).Visible = False

                .Columns(1).HeaderText = "Documento"
                .Columns(1).Width = 90

                .Columns(2).Width = 130
                .Columns(2).HeaderText = "Fecha"

                .Columns(3).Width = 160

                .Columns(4).Width = 310
                .Columns(4).HeaderText = "Rango de fechas"

                .Columns(5).Width = 180
                .Columns(5).HeaderText = "Usuario"

                .Columns(6).Width = 100
                .Columns(6).HeaderText = "Contado"
                .Columns(6).DefaultCellStyle.Format = "C"

                .Columns(7).Width = 100
                .Columns(7).HeaderText = "Cálculado"
                .Columns(7).DefaultCellStyle.Format = "C"
                .Columns(7).Visible = True

                .Columns(8).Width = 100
                .Columns(8).HeaderText = "Diferencia"
                .Columns(8).DefaultCellStyle.Format = "C"
                .Columns(8).Visible = True

                .Columns(9).Width = 100
                .Columns(9).HeaderText = "Retirado"
                .Columns(9).DefaultCellStyle.Format = "C"

                .Columns(10).Visible = False
            End With
        ElseIf frm_corte_caja.Privilegios = 2 Then

            With DgvCorteCaja
                .Columns(0).HeaderText = "IDFinanciamiento"
                .Columns(0).Visible = False

                .Columns(1).HeaderText = "Documento"
                .Columns(1).Width = 90

                .Columns(2).Width = 130
                .Columns(2).HeaderText = "Fecha"

                .Columns(3).Width = 160

                .Columns(4).Width = 310
                .Columns(4).HeaderText = "Rango de fechas"

                .Columns(5).Width = 180
                .Columns(5).HeaderText = "Usuario"

                .Columns(6).Width = 100
                .Columns(6).HeaderText = "Contado"
                .Columns(6).DefaultCellStyle.Format = "C"

                .Columns(7).Width = 100
                .Columns(7).HeaderText = "Cálculado"
                .Columns(7).DefaultCellStyle.Format = "C"
                .Columns(7).Visible = False

                .Columns(8).Width = 100
                .Columns(8).HeaderText = "Diferencia"
                .Columns(8).DefaultCellStyle.Format = "C"
                .Columns(8).Visible = False

                .Columns(9).Width = 100
                .Columns(9).HeaderText = "Retirado"
                .Columns(9).DefaultCellStyle.Format = "C"

                .Columns(10).Visible = False
            End With

        ElseIf frm_corte_caja.Privilegios = 3 Then

            With DgvCorteCaja
                .Columns(0).HeaderText = "IDFinanciamiento"
                .Columns(0).Visible = False

                .Columns(1).HeaderText = "Documento"
                .Columns(1).Width = 90

                .Columns(2).Width = 130
                .Columns(2).HeaderText = "Fecha"

                .Columns(3).Width = 160

                .Columns(4).Width = 310
                .Columns(4).HeaderText = "Rango de fechas"

                .Columns(5).Width = 180
                .Columns(5).HeaderText = "Usuario"

                .Columns(6).Width = 100
                .Columns(6).HeaderText = "Contado"
                .Columns(6).DefaultCellStyle.Format = "C"

                .Columns(7).Width = 100
                .Columns(7).HeaderText = "Cálculado"
                .Columns(7).DefaultCellStyle.Format = "C"
                .Columns(7).Visible = False

                .Columns(8).Width = 100
                .Columns(8).HeaderText = "Diferencia"
                .Columns(8).DefaultCellStyle.Format = "C"
                .Columns(8).Visible = False

                .Columns(9).Width = 100
                .Columns(9).HeaderText = "Retirado"
                .Columns(9).DefaultCellStyle.Format = "C"

                .Columns(10).Visible = False
            End With

        ElseIf frm_corte_caja.Privilegios = 4 Then
            With DgvCorteCaja
                .Columns(0).HeaderText = "IDFinanciamiento"
                .Columns(0).Visible = False

                .Columns(1).HeaderText = "Documento"
                .Columns(1).Width = 90

                .Columns(2).Width = 130
                .Columns(2).HeaderText = "Fecha"

                .Columns(3).Width = 160

                .Columns(4).Width = 310
                .Columns(4).HeaderText = "Rango de fechas"

                .Columns(5).Width = 180
                .Columns(5).HeaderText = "Usuario"

                .Columns(6).Width = 100
                .Columns(6).HeaderText = "Contado"
                .Columns(6).DefaultCellStyle.Format = "C"

                .Columns(7).Width = 100
                .Columns(7).HeaderText = "Cálculado"
                .Columns(7).DefaultCellStyle.Format = "C"
                .Columns(7).Visible = True

                .Columns(8).Width = 100
                .Columns(8).HeaderText = "Diferencia"
                .Columns(8).DefaultCellStyle.Format = "C"
                .Columns(7).Visible = True

                .Columns(9).Width = 100
                .Columns(9).HeaderText = "Retirado"
                .Columns(9).DefaultCellStyle.Format = "C"

                .Columns(10).Visible = False
            End With
        End If



    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub rdbCategoria_CheckedChanged(sender As Object, e As EventArgs)
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub DgvFinanciamientos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvCorteCaja.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvCorteCaja.Focus()
    End Sub


    Private Sub DgvFinanciamientos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvCorteCaja.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvCorteCaja.Focus()
        End If
    End Sub

    Private Sub DgvFinanciamientos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvCorteCaja.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_corte_caja.Name Then
                Dim DsLlenarFormulario As New DataSet
                Dim IDCorteCaja As New Label
                IDCorteCaja.Text = DgvCorteCaja.CurrentRow.Cells(0).Value

                DsLlenarFormulario.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT IDCorteCaja,CorteCaja.IDTipoDocumento,TipoDocumento.Documento,CorteCaja.SecondID,CorteCaja.Fecha,IDCreadorUsuario,CreadorUsuario.Nombre as NombreCreadorUsuario,TodosUsuarios,CorteCaja.IDUsuario,Usuarios.Nombre as UsuarioCerrador,TodasCajas,CorteCaja.IDAreaImpresion,AreaImpresion.ComputerName,TodoRango,DesdeFecha,HastaFecha,ContadoEfectivo,ContadoCheque,ContadoDeposito,ContadoTarjeta,ContadoTrans,ContadoVales,ContadoBonos,ContadoPermuta,ContadoOtros,ContadoTotal,CalculadoEfectivo,CalculadoCheque,CalculadoDeposito,CalculadoTarjeta,CalculadoTrans,CalculadoVales,CalculadoBonos,CalculadoPermuta,CalculadoOtros,CalculadoTotal,DiferenciaEfectivo,DiferenciaCheque,DiferenciaDeposito,DiferenciaTarjeta,DiferenciaTrans,DiferenciaVales,DiferenciaBonos,DiferenciaPermuta,DiferenciaOtros,DiferenciaTotal,RetiroEfectivo,RetiroCheque,RetiroCheque,RetiroTarjeta,RetiroTrans,RetiroVales,RetiroBonos,RetiroPermuta,RetiroOtros,RetiroTotal,CantidadTransacciones,CorteCaja.Nulo FROM" & SysName.Text & "cortecaja INNER JOIN" & SysName.Text & "AreaImpresion on CorteCaja.IDAreaImpresion=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Empleados as CreadorUsuario on CorteCaja.IDCreadorUsuario=CreadorUsuario.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Usuarios on CorteCaja.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "TipoDocumento on CorteCaja.IDTipoDocumento=TipoDocumento.IDTipoDocumento Where CorteCaja.IDCorteCaja= '" + IDCorteCaja.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsLlenarFormulario, "CorteCaja")
                ConMixta.Close()

                Dim Tabla As DataTable = DsLlenarFormulario.Tables("CorteCaja")

                If Me.Owner.Name = frm_corte_caja.Name Then
                    frm_corte_caja.Hora.Enabled = False

                    frm_corte_caja.txtIDCorte.Text = Tabla.Rows(0).Item("IDCorteCaja")
                    frm_corte_caja.txtSecondID.Text = Tabla.Rows(0).Item("SecondID")
                    frm_corte_caja.txtFecha.Value = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy")
                    frm_corte_caja.txtHora.Value = CDate(Tabla.Rows(0).Item("Fecha")).ToString("dd/MM/yyyy hh:mm:ss tt")

                    frm_corte_caja.cbxEmpleado.Text = If(Tabla.Rows(0).Item("TodosUsuarios") = 1, "Todos", Tabla.Rows(0).Item("UsuarioCerrador"))
                    frm_corte_caja.cbxAreaImpresion.Text = If(Tabla.Rows(0).Item("TodasCajas") = 1, "Todos", Tabla.Rows(0).Item("ComputerName"))

                    frm_corte_caja.chkTodoRango.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("TodoRango"))
                    frm_corte_caja.dtpDesde.Value = CDate(Tabla.Rows(0).Item("DesdeFecha")).ToString("dd/MM/yyyy hh:mm:ss tt")
                    frm_corte_caja.dtpHasta.Value = CDate(Tabla.Rows(0).Item("HastaFecha")).ToString("dd/MM/yyyy hh:mm:ss tt")

                    frm_corte_caja.txtEfectivoContado.Text = CDbl(Tabla.Rows(0).Item("ContadoEfectivo")).ToString("C")
                    frm_corte_caja.txtChequeContado.Text = CDbl(Tabla.Rows(0).Item("ContadoCheque")).ToString("C")
                    frm_corte_caja.txtDepositoContado.Text = CDbl(Tabla.Rows(0).Item("ContadoDeposito")).ToString("C")
                    frm_corte_caja.txtTarjetaContado.Text = CDbl(Tabla.Rows(0).Item("ContadoTarjeta")).ToString("C")
                    frm_corte_caja.txtTransferenciaContado.Text = CDbl(Tabla.Rows(0).Item("ContadoTrans")).ToString("C")
                    frm_corte_caja.txtEgresosContado.Text = CDbl(Tabla.Rows(0).Item("ContadoVales")).ToString("C")
                    frm_corte_caja.txtBonosContado.Text = CDbl(Tabla.Rows(0).Item("ContadoBonos")).ToString("C")
                    frm_corte_caja.txtPermutaContado.Text = CDbl(Tabla.Rows(0).Item("ContadoPermuta")).ToString("C")
                    frm_corte_caja.txtOtrasContado.Text = CDbl(Tabla.Rows(0).Item("ContadoOtros")).ToString("C")
                    frm_corte_caja.txtTotalContado.Text = CDbl(Tabla.Rows(0).Item("ContadoTotal")).ToString("C")

                    frm_corte_caja.txtEfectivoCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoEfectivo")).ToString("C")
                    frm_corte_caja.txtChequeCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoCheque")).ToString("C")
                    frm_corte_caja.txtDepositoCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoDeposito")).ToString("C")
                    frm_corte_caja.txtTarjetaCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoTarjeta")).ToString("C")
                    frm_corte_caja.txtTransferenciaCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoTrans")).ToString("C")
                    frm_corte_caja.txtEgresosCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoVales")).ToString("C")
                    frm_corte_caja.txtBonosCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoBonos")).ToString("C")
                    frm_corte_caja.txtPermutaCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoPermuta")).ToString("C")
                    frm_corte_caja.txtOtrasCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoOtros")).ToString("C")
                    frm_corte_caja.txtTotalCalculado.Text = CDbl(Tabla.Rows(0).Item("CalculadoTotal")).ToString("C")

                    frm_corte_caja.txtEfectivoDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaEfectivo")).ToString("C")
                    frm_corte_caja.txtChequeDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaCheque")).ToString("C")
                    frm_corte_caja.txtDepositoDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaDeposito")).ToString("C")
                    frm_corte_caja.txtTarjetaDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaTarjeta")).ToString("C")
                    frm_corte_caja.txtTransferenciaDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaTrans")).ToString("C")
                    frm_corte_caja.txtEgresosDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaVales")).ToString("C")
                    frm_corte_caja.txtBonosDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaBonos")).ToString("C")
                    frm_corte_caja.txtPermutaDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaPermuta")).ToString("C")
                    frm_corte_caja.txtOtrasDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaOtros")).ToString("C")
                    frm_corte_caja.txtTotalDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaTotal")).ToString("C")

                    frm_corte_caja.txtEfectivoRetirar.Text = CDbl(Tabla.Rows(0).Item("RetiroEfectivo")).ToString("C")
                    frm_corte_caja.txtChequeRetirar.Text = CDbl(Tabla.Rows(0).Item("RetiroCheque")).ToString("C")
                    frm_corte_caja.txtDepositoDiferencia.Text = CDbl(Tabla.Rows(0).Item("DiferenciaDeposito")).ToString("C")
                    frm_corte_caja.txtTarjetaRetirar.Text = CDbl(Tabla.Rows(0).Item("RetiroTarjeta")).ToString("C")
                    frm_corte_caja.txtTransferenciaRetirar.Text = CDbl(Tabla.Rows(0).Item("RetiroTrans")).ToString("C")
                    frm_corte_caja.txtEgresosRetirar.Text = CDbl(Tabla.Rows(0).Item("RetiroVales")).ToString("C")
                    frm_corte_caja.txtBonosDiferencia.Text = CDbl(Tabla.Rows(0).Item("RetiroBonos")).ToString("C")
                    frm_corte_caja.txtPermutaDiferencia.Text = CDbl(Tabla.Rows(0).Item("RetiroPermuta")).ToString("C")
                    frm_corte_caja.txtOtrasDiferencia.Text = CDbl(Tabla.Rows(0).Item("RetiroOtros")).ToString("C")
                    frm_corte_caja.txtTotalRetirar.Text = CDbl(Tabla.Rows(0).Item("RetiroTotal")).ToString("C")
                    frm_corte_caja.ChkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))

                    Dim SQLSetence As String = "Select * from" & SysName.Text & "cortecajadetalleview where IDCorteCaja='" + Tabla.Rows(0).Item("IDCorteCaja").ToString + "'"
                    Dim Bs As New BindingSource
                    Dim BN As New BindingNavigator
                    Dim DsTemp As New DataSet

                    ConMixta.Open()
                    cmd = New MySqlCommand(SQLSetence, ConMixta)
                    Adaptador = New MySqlDataAdapter(cmd)
                    Adaptador.Fill(DsTemp, "cortecajadetalleview")
                    ConMixta.Close()

                    Bs.DataMember = "cortecajadetalleview"
                    Bs.DataSource = DsTemp
                    BN.BindingSource = Bs
                    frm_corte_caja.DgvTransacciones.DataSource = Bs
                    frm_corte_caja.DgvTransacciones.ClearSelection()
                    frm_corte_caja.PropiedadColumnsDvg()

                    frm_corte_caja.dtpDesde.Enabled = False
                    frm_corte_caja.dtpHasta.Enabled = False

                    frm_corte_caja.cbxAreaImpresion.Enabled = False
                    frm_corte_caja.cbxEmpleado.Enabled = False
                    frm_corte_caja.chkTodoRango.Enabled = False

                    frm_corte_caja.SumarTransacciones()

                    frm_corte_caja.txtEfectivoContado.Focus()
                    frm_corte_caja.txtEfectivoContado.SelectAll()

                    DsTemp.Dispose()
                    Tabla.Dispose()

                End If
            End If

            Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


    Private Sub frm_buscar_categorias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub
End Class