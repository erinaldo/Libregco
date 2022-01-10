Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frm_buscar_pago_cuotas_financiamientos
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Friend Privilegio As New Label

    Private Sub frm_buscar_pago_cuotas_financiamientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()

        If Me.Owner.Name = frm_cuotas_financiamientos.Name Then
            ControlSuperClave = 1
            RefrescarTabla()
        End If
    End Sub

    Private Sub RefrescarTabla()
        Try
            Con.Open()
            DgvPagos.Rows.Clear()

            Dim AnexoAbonos As New MySqlCommand("SELECT IDPagosFInanciamientos,pagosfinanciamientos.SecondID,pagosfinanciamientos.Fecha,Financiamientos.SecondID,pagosfinanciamientos.Concepto,Debitos,Descuentos,pagosfinanciamientos.Nulo FROM pagosfinanciamientos INNER JOIN Financiamientos on PagosFinanciamientos.IDFinanciamiento=Financiamientos.IDFinanciamientos where Financiamientos.IDCliente='" + frm_cuotas_financiamientos.txtIDCliente.Text + "' ORDER BY FECHA ASC", Con)
            Dim Lector As MySqlDataReader = AnexoAbonos.ExecuteReader

            While Lector.Read
                DgvPagos.Rows.Add(Lector.GetValue(0), Lector.GetValue(1), Lector.GetValue(2), Lector.GetValue(3), Lector.GetValue(4), CDbl(Lector.GetValue(5)).ToString("C"), CDbl(Lector.GetValue(6)).ToString("C"), Lector.GetValue(7))
            End While
            Lector.Close()
            Con.Close()

            For Each Row As DataGridViewRow In DgvPagos.Rows
                If CStr(Row.Cells(7).Value) = "1" Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                    Row.Cells(4).Value = "NULO"
                End If
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub DgvPagos_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvPagos.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvPagos.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvPagos.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvPagos.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvPagos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPagos.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDAbono As New Label

        Try
            IDAbono.Text = DgvPagos.CurrentRow.Cells(0).Value

            Dim DsTemp As New DataSet

        ConMixta.Open()
        cmd = New MySqlCommand("SELECT pagosfinanciamientos.idpagosfinanciamientos,pagosfinanciamientos.idtipodocumento,tipodocumento.documento,pagosfinanciamientos.SecondID,pagosfinanciamientos.Fecha,pagosfinanciamientos.IDAreaImpresion,AreaImpresion.ComputerName,Almacen.Almacen,Sucursal.Sucursal,pagosfinanciamientos.IDUSuario,Usuarios.Nombre as NombreUsuario,pagosfinanciamientos.IDTransaccion,Transaccion.Efectivo,Transaccion.Cheque,Transaccion.Deposito,Transaccion.Informacion,Transaccion.Tarjeta,Transaccion.NoAprobacion,Recibido,Devuelta,pagosfinanciamientos.IDFinanciamiento,Financiamientos.SecondID as SecondIDFinanciamiento,Financiamientos.Fecha as FechaFinanciamiento,Financiamientos.Descripcion as DescripcionFinanciamiento,Financiamientos.IDTipoFinanciamiento,TipoFinanciamiento.Descripcion as TipoFinanciamiento,Financiamientos.IDCliente,Clientes.Nombre,Clientes.Direccion,Municipios.Municipio,Provincias.Provincia,ClaseAnexa.Descripcion as ClaseAnexa,Clientes.Identificacion,Clientes.TelefonoPersonal,Clientes.TelefonoHogar,Financiamientos.InteresMensual,Financiamientos.Balance as BalanceFinanciamiento,Financiamientos.BalanceLetra,PagosFinanciamientos.BalanceAnterior,PagosFinanciamientos.Concepto,PagosFinanciamientos.Debitos,pagosfinanciamientos.Descuentos,pagosfinanciamientos.TotalAplicado,pagosfinanciamientos.SumaLetra,pagosfinanciamientos.Impreso,pagosfinanciamientos.Nulo,idPagosFinanciamientos_Detalles,Financiamientos_cuotas.IDFinanciamientos_cuotas,Financiamientos_cuotas.NoCuota,Financiamientos_cuotas.FechaVencimiento,Financiamientos_cuotas.DiasVencidos,Financiamientos_cuotas.Monto,Financiamientos_cuotas.Capital,Financiamientos_cuotas.Interes,Cargo,Financiamientos_cuotas.Balance as BalanceCuota,BceCapitalAnterior,BceInteresAnterior,BceCargosAnterior,CapitalAplicado,InteresAplicado,CargosAplicados,DescuentosAplicado,InteresExonerado,CargosExonerado FROM" & SysName.Text & " pagosfinanciamientos INNER JOIN" & SysName.Text & "TipoDocumento on PagosFinanciamientos.IDTipoDocumento=TipoDocumento.IDTipoDocumento INNER JOIN" & SysName.Text & "Empleados as Usuarios on PagosFinanciamientos.IDUsuario=Usuarios.IDEmpleado INNER JOIN" & SysName.Text & "Financiamientos on PagosFinanciamientos.IDFinanciamiento=Financiamientos.IDFinanciamientos INNER JOIN Libregco.TipoFinanciamiento on Financiamientos.IDTipoFinanciamiento=TipoFinanciamiento.IDTipoFinanciamiento INNER JOIN" & SysName.Text & "AreaImpresion on PagosFinanciamientos.IDAreaImpresion=AreaImpresion.IDEquipo INNER JOIN" & SysName.Text & "Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN" & SysName.Text & "Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN Libregco.Clientes on Financiamientos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Municipios on Clientes.IDMunicipio=Municipios.IDMunicipio INNER JOIN Libregco.Provincias on Municipios.IDProvincia=Provincias.IDProvincia INNER JOIN Libregco.ClaseAnexa on Clientes.IDTipoIdentificacion=ClaseAnexa.IDClaseAnexa INNER JOIN" & SysName.Text & "Transaccion on Financiamientos.IDTransaccion=Transaccion.IDTransaccion INNER JOIN" & SysName.Text & "PagosFinanciamientos_detalles on PagosFinanciamientos.IDPagosFinanciamientos=PagosFinanciamientos_detalles.idPagosFinanciamientos INNER JOIN" & SysName.Text & "financiamientos_cuotas on PagosFinanciamientos_detalles.IDFinanciamientoCuota=Financiamientos_cuotas.idFinanciamientos_cuotas Where pagosfinanciamientos.IDPagosFinanciamientos='" + IDAbono.Text + "'", ConMixta)

        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(DsTemp, "pagosfinanciamientos")
        ConMixta.Close()

        Dim Tabla As DataTable = DsTemp.Tables("pagosfinanciamientos")

            '''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.Owner.Name = frm_cuotas_financiamientos.Name Then

                VerificarPrivilegios()
                If Privilegio.Text = 2 Or Privilegio.Text = 3 Then
                    Exit Sub
                End If
                frm_superclave.IDAccion.Text = 125
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                If Tabla.Rows.Count > 0 Then

                    frm_cuotas_financiamientos.cbxFinanciamientos.Text = Tabla.Rows(0).Item("SecondIDFinanciamiento")
                    frm_cuotas_financiamientos.txtConceptoPago.Text = Tabla.Rows(0).Item("Concepto")
                    frm_cuotas_financiamientos.txtIDPagoFinanciamiento.Text = Tabla.Rows(0).Item("idpagosfinanciamientos")
                    frm_cuotas_financiamientos.txtSecondID.Text = Tabla.Rows(0).Item("SecondID")
                    frm_cuotas_financiamientos.txtMontoAplicar.Text = CDbl(Tabla.Rows(0).Item("Debitos")).ToString("C")
                    frm_cuotas_financiamientos.lblDescuento.Text = Tabla.Rows(0).Item("Descuentos")
                    frm_cuotas_financiamientos.lblTotalAbono.Text = CDbl(Tabla.Rows(0).Item("Debitos")) + CDbl(Tabla.Rows(0).Item("Descuentos"))
                    frm_cuotas_financiamientos.lblIDTransaccion.Text = Tabla.Rows(0).Item("IDTransaccion")
                    frm_cuotas_financiamientos.txtFecha.Value = CDate(Tabla.Rows(0).Item("Fecha"))
                    frm_cuotas_financiamientos.chkNulo.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))

                    For Each dt As DataRow In Tabla.Rows
                        RemoveSavedRows(dt.Item("IDFinanciamientos_cuotas"))
                        frm_cuotas_financiamientos.DgvCuotas.Rows.Add(dt.Item("idPagosFinanciamientos_Detalles"), dt.Item("IDFinanciamientos_cuotas"), dt.Item("NoCuota"), CDate(dt.Item("FechaVencimiento")).ToString("dd/MM/yyyy"), CDbl(dt.Item("Monto")).ToString("C4"), CDbl(dt.Item("BceCapitalAnterior")).ToString("C4"), CDbl(dt.Item("BceInteresAnterior")).ToString("C4"), CDbl(dt.Item("BceCargosAnterior")).ToString("C4"), CDbl(dt.Item("BalanceCuota")).ToString("C4"), CDbl(dt.Item("CapitalAplicado")).ToString("C4"), CDbl(dt.Item("InteresAplicado")).ToString("C4"), CDbl(dt.Item("CargosAplicados")).ToString("C4"), CDbl(dt.Item("DescuentosAplicado")).ToString("C4"), CDbl(dt.Item("InteresExonerado")).ToString("C4"), CDbl(dt.Item("CargosExonerado")).ToString("C4"), False, CDbl(CDbl(dt.Item("BceCapitalAnterior")) + CDbl(dt.Item("BceInteresAnterior")) + CDbl(dt.Item("BceCargosAnterior")) - CDbl(dt.Item("CapitalAplicado")) - CDbl(dt.Item("InteresAplicado")) - CDbl(dt.Item("CargosAplicados")) - CDbl(dt.Item("DescuentosAplicado")) - CDbl(dt.Item("InteresExonerado")) - CDbl(dt.Item("CargosExonerado"))).ToString("C4"))
                    Next



                    frm_cuotas_financiamientos.DgvCuotas.Sort(frm_cuotas_financiamientos.DgvCuotas.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                End If
            End If

            DsTemp.Dispose()
            Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & " LlenarFormularios")
        End Try

    End Sub

    Private Sub RemoveSavedRows(ByVal IDCuota As Integer)
        Try
            For Each rw As DataGridViewRow In frm_cuotas_financiamientos.DgvCuotas.Rows
                If IDCuota = rw.Cells(1).Value Then
                    frm_cuotas_financiamientos.DgvCuotas.Rows.Remove(rw)
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub VerificarPrivilegios()
        Try
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDPrivilegios FROM" & SysName.Text & "Empleados Where IDEmpleado='" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "'", ConMixta)
            Privilegio.Text = Convert.ToString(cmd.ExecuteScalar())
            ConMixta.Close()

            If Privilegio.Text = "" Then
                MessageBox.Show("No se han detectado privilegios cargados en el sistema. Por favor vuelva a iniciar su login.")
                Exit Sub
            ElseIf Privilegio.Text = 2 Or Privilegio.Text = 3 Then
                MessageBox.Show("No posee los permisos necesarios para poder accesar y modificar los recibos ya procesados en el sistema.", "No se encontraron los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvPagos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvPagos.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvPagos.ColumnCount
                Dim NumRows As Integer = DgvPagos.RowCount
                Dim CurCell As DataGridViewCell = DgvPagos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvPagos.CurrentCell = DgvPagos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvPagos.CurrentCell = DgvPagos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvPagos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvPagos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub
End Class