Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_buscar_financiamientos
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_financiamientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT idFinanciamientos,Financiamientos.SecondID,Fecha,Financiamientos.IDCliente,Clientes.Nombre,Financiamientos.Descripcion FROM" & SysName.Text & "financiamientos inner join libregco.clientes on financiamientos.idcliente=clientes.idcliente where Financiamientos.SecondID like '%" + txtBuscar.Text + "%' ORDER BY SecondID DESC", ConMixta)
            ElseIf rdbFinanciamientos.Checked = True Then
                cmd = New MySqlCommand("SELECT idFinanciamientos,Financiamientos.SecondID,Fecha,Financiamientos.IDCliente,Clientes.Nombre,Financiamientos.Descripcion FROM" & SysName.Text & "financiamientos inner join libregco.clientes on financiamientos.idcliente=clientes.idcliente where Financiamientos.SecondID like '%" + txtBuscar.Text + "%' ORDER BY Descripcion ASC", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Financiamientos")

            Bs.DataMember = "Financiamientos"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvFinanciamientos.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbFinanciamientos.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvFinanciamientos
            .Columns(0).HeaderText = "IDFinanciamiento"
            .Columns(0).Visible = False

            .Columns(1).HeaderText = "ID"
            .Columns(1).Width = 100

            .Columns(2).Width = 125

            .Columns(3).Width = 80
            .Columns(3).HeaderText = "ID Cliente"
            .Columns(4).Width = 260
            .Columns(5).Width = 360
            .Columns(5).HeaderText = "Descripción"

        End With
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

    Private Sub DgvFinanciamientos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFinanciamientos.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvFinanciamientos.Focus()
    End Sub


    Private Sub DgvFinanciamientos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvFinanciamientos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvFinanciamientos.Focus()
        End If
    End Sub

    Private Sub DgvFinanciamientos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvFinanciamientos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_financiamiento.Name Then
                Dim DsLlenarFormulario As New DataSet
                Dim IDFinanciamiento As New Label
                IDFinanciamiento.Text = DgvFinanciamientos.CurrentRow.Cells(0).Value

                DsLlenarFormulario.Clear()
                ConMixta.Open()
                cmd = New MySqlCommand("SELECT idfinanciamientos,financiamientos.idtipodocumento,tipodocumento.documento,financiamientos.SecondID,financiamientos.Fecha,financiamientos.IDAreaImpresion,AreaImpresion.ComputerName,financiamientos.IDUsuario,Usuarios.Nombre as NombreUsuario,financiamientos.IDVendedor,Vendedor.Nombre as NombreVendedor,financiamientos.IDCliente,Clientes.Nombre,Clientes.Direccion,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Clientes.Identificacion,financiamientos.Descripcion,financiamientos.IDTipoFinanciamiento,TipoFinanciamiento.Descripcion as TipoFinanciamiento,financiamientos.IDFormaPago,PeriodoPago.Descripcion as PeriodoPago,FechaInicio,FechaFinal,CantidadCuotas,InteresMensual,EvitSabado,EvitDomingo,PoseeGarantias,Valor,Financiamientos.Inicial,Financiamiento,Tramites,MontoPrestamo,TotalAPagar,MesesAplicables,Financiamientos.MontoPagos,Subtotal,ItbisPorcentaje,Itbis,TotalNeto,Clientes.BalanceGeneral,Calificacion.Calificacion,Transaccion.IDTransaccion,RedondearCuotas,ifnull((Select Fecha from" & SysName.Text & "Abonos where IDCliente=Clientes.IDCliente and Nulo=0 ORDER BY IDAbono DESC LIMIT 1),'No Encontrado') AS UltimoPago,(LimiteCredito-BalanceGeneral) as CreditoDisponible,Financiamientos.IDTipoNCF,ComprobanteFiscal.TipoComprobante,financiamientos.Nulo,(SELECT Ruta FROM Libregco.documentosclientes Where DocumentosClientes.IDCliente=Clientes.IDCliente and IDClase=1 LIMIT 1) as Foto FROM" & SysName.Text & "financiamientos INNER JOIN" & SysName.Text & "TipoDocumento on Financiamientos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Transaccion on Financiamientos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN" & SysName.Text & "Empleados as Vendedor on Financiamientos.IDVendedor=Vendedor.IDEmpleado INNER JOIN" & SysName.Text & "Empleados as Usuarios on Financiamientos.IDUsuario=Usuarios.IDEmpleado INNER JOIN Libregco.TipoFinanciamiento on Financiamientos.IDTipoFinanciamiento=TipoFinanciamiento.idTipoFinanciamiento INNER JOIN Libregco.PeriodoPago on Financiamientos.IDFormaPago=PeriodoPago.IDPeriodoPago INNER JOIN" & SysName.Text & "AreaImpresion on Financiamientos.IDAreaImpresion=AreaImpresion.IDEquipo INNER JOIN Libregco.Clientes on Financiamientos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN" & SysName.Text & "ComprobanteFiscal on Financiamientos.IDTipoNCF=ComprobanteFiscal.IDComprobanteFiscal Where Financiamientos.IDFinanciamientos= '" + IDFinanciamiento.Text + "'", ConMixta)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsLlenarFormulario, "financiamientos")
                ConMixta.Close()

                Dim Tabla As DataTable = DsLlenarFormulario.Tables("financiamientos")

                If Me.Owner.Name = frm_financiamiento.Name Then
                    frm_financiamiento.IsSaved = True
                    frm_financiamiento.Hora.Enabled = False
                    frm_financiamiento.lblIDTransaccion.Text = Tabla.Rows(0).Item("IDTransaccion")
                    frm_financiamiento.txtIDCliente.Text = Tabla.Rows(0).Item("IDCliente")
                    frm_financiamiento.txtNombre.Text = Tabla.Rows(0).Item("Nombre")
                    frm_financiamiento.txtDireccion.Text = Tabla.Rows(0).Item("Direccion")
                    frm_financiamiento.txtTelefonos.Text = Tabla.Rows(0).Item("TelefonoPersonal") & " " & Tabla.Rows(0).Item("TelefonoHogar")
                    frm_financiamiento.txtBalanceGeneral.Text = CDbl(Tabla.Rows(0).Item("BalanceGeneral")).ToString("C")
                    frm_financiamiento.txtUltimoPago.Text = Tabla.Rows(0).Item("UltimoPago")
                    frm_financiamiento.txtCalificacion.Text = Tabla.Rows(0).Item("Calificacion")



                    frm_financiamiento.txtIDFinanciamiento.Text = Tabla.Rows(0).Item("IDFinanciamientos")
                    frm_financiamiento.txtSecondID.Text = Tabla.Rows(0).Item("SecondID")
                    frm_financiamiento.txtFecha.Value = CDate(Tabla.Rows(0).Item("Fecha"))
                    frm_financiamiento.txtHora.Text = Convert.ToString(CDate(Tabla.Rows(0).Item("Fecha")).ToString("hh:mm:ss"))
                    frm_financiamiento.txtDescripcion.Text = Tabla.Rows(0).Item("Descripcion")
                    frm_financiamiento.txtMonto.Text = CDbl(Tabla.Rows(0).Item("Valor")).ToString("C")
                    frm_financiamiento.txtInicial.Text = CDbl(Tabla.Rows(0).Item("Inicial")).ToString("C")
                    frm_financiamiento.txtGranTotal.Text = CDbl(Tabla.Rows(0).Item("Financiamiento")).ToString("C")
                    frm_financiamiento.txtCostoTramite.Text = CDbl(Tabla.Rows(0).Item("Tramites")).ToString("C")
                    frm_financiamiento.txtMontoPrestamo.Text = CDbl(Tabla.Rows(0).Item("MontoPrestamo")).ToString("C")
                    frm_financiamiento.txtMeses.Text = Tabla.Rows(0).Item("MesesAplicables")
                    frm_financiamiento.txtMontoPagos.Text = CDbl(Tabla.Rows(0).Item("MontoPagos")).ToString("C")
                    frm_financiamiento.txtTotalAPagar.Text = CDbl(Tabla.Rows(0).Item("TotalAPagar")).ToString("C")
                    frm_financiamiento.cbxMetodo.Text = Tabla.Rows(0).Item("TipoFinanciamiento")
                    frm_financiamiento.cbxMetodo.Tag = Tabla.Rows(0).Item("IDTipoFinanciamiento")
                    frm_financiamiento.cbxFormaPago.Text = Tabla.Rows(0).Item("PeriodoPago")
                    frm_financiamiento.cbxFormaPago.Tag = Tabla.Rows(0).Item("IDFormaPago")
                    frm_financiamiento.txtPorcInteres.Text = CDbl(Tabla.Rows(0).Item("InteresMensual")).ToString("P")
                    frm_financiamiento.dtpFechaInicio.Value = Tabla.Rows(0).Item("FechaInicio")
                    frm_financiamiento.txtCantidadCuotas.Text = Tabla.Rows(0).Item("CantidadCuotas")
                    frm_financiamiento.dtpFechaFinal.Value = Tabla.Rows(0).Item("FechaFinal")
                    frm_financiamiento.ChkEvitSaturday.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("EvitSabado"))
                    frm_financiamiento.ChkEvitSunday.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("EvitDomingo"))
                    frm_financiamiento.chkRedondearCuotas.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("RedondearCuotas"))
                    frm_financiamiento.chkPoseeGarantia.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("PoseeGarantias"))
                    frm_financiamiento.CbxTipoComprobante.Text = Tabla.Rows(0).Item("TipoComprobante")
                    frm_financiamiento.CbxTipoComprobante.Tag = Tabla.Rows(0).Item("IDTipoNCF")
                    frm_financiamiento.cbxVendedor.Text = Tabla.Rows(0).Item("NombreVendedor")
                    frm_financiamiento.cbxVendedor.Tag = Tabla.Rows(0).Item("IDVendedor")
                    frm_financiamiento.txtSubTotal.Text = CDbl(Tabla.Rows(0).Item("Subtotal")).ToString("C")
                    frm_financiamiento.txtITBIS.Text = CDbl(Tabla.Rows(0).Item("Itbis")).ToString("C")
                    frm_financiamiento.txtTasaItbis.Text = CDbl(Tabla.Rows(0).Item("ItbisPorcentaje")).ToString("P")
                    frm_financiamiento.txtNeto.Text = CDbl(Tabla.Rows(0).Item("TotalNeto")).ToString("C")
                    frm_financiamiento.chkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))

                    ConMixta.Open()
                    frm_financiamiento.DgvCuotas.Rows.Clear()
                    Dim Consulta As New MySqlCommand("SELECT IdFinanciamientos_cuotas,NoCuota,Monto,FechaVencimiento,Capital,Interes FROM" & SysName.Text & "Financiamientos_cuotas Where IDFinanciamiento='" + Tabla.Rows(0).Item("IDFinanciamientos").ToString + "' Order by NoCuota ASC", ConMixta)
                    Dim LectorCuotas As MySqlDataReader = Consulta.ExecuteReader

                    While LectorCuotas.Read
                        frm_financiamiento.DgvCuotas.Rows.Add(LectorCuotas.GetValue(0), LectorCuotas.GetValue(1), CDbl(LectorCuotas.GetValue(2)).ToString("C"), CDate(LectorCuotas.GetValue(3)).ToString("dd/MM/yyyy"), CDbl(LectorCuotas.GetValue(4)).ToString("C"), CDbl(LectorCuotas.GetValue(5)).ToString("C"))
                    End While
                    LectorCuotas.Close()
                    ConMixta.Close()

                    Dim BceAPagar As Double = frm_financiamiento.txtTotalAPagar.Text
                    For Each rw As DataGridViewRow In frm_financiamiento.DgvCuotas.Rows
                        rw.Cells(6).Value = BceAPagar.ToString("C")

                        BceAPagar = BceAPagar - CDbl(frm_financiamiento.txtMontoPagos.Text)
                    Next

                    frm_financiamiento.IsSaved = False

                    frm_financiamiento.txtTiempoPeriodos.Text = CalcularFecha(Tabla.Rows(0).Item("FechaInicio"), Tabla.Rows(0).Item("FechaFinal"))

                End If
            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


    Private Sub frm_buscar_categorias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub
End Class