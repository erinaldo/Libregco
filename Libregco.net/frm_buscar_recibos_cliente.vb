Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_recibos_cliente

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet
    Friend lblIDUsuario, Privilegio As New Label

    Private Sub frm_buscar_recibos_cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ColumnsHistorial()
        'Me.WindowState = CheckWindowState()
        ActualizarText()
    End Sub

    Private Sub ColumnsHistorial()
        DgvHistorial.Columns.Clear()

        With DgvHistorial
            .Columns.Add("IDAbono", "Código") '0
            .Columns.Add("IDCliente", "Cód. Cliente") '1
            .Columns.Add("Fecha", "Fecha") '2
            .Columns.Add("Concepto", "Concepto") '3
            .Columns.Add("Debito", "Débito")   '4
            .Columns.Add("Descuento", "Descuento") '5
            .Columns.Add("Total", "Total")  '6
            .Columns.Add("Nulo", "Nulo")    '7
            .Columns.Add("SecondID", "No. Recibo") '8
        End With
        PropiedadColumnsDgv()
    End Sub

    Private Sub PropiedadColumnsDgv()
        With DgvHistorial

            .Columns("IDAbono").Visible = False

            .Columns("IDCliente").Visible = False

            .Columns("Fecha").Width = 80
            .Columns("Fecha").DefaultCellStyle.Format = ("dd/MM/yyyy")
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns("Concepto").Width = 290
            .Columns("Concepto").SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns("Debito").Width = 100
            .Columns("Debito").DefaultCellStyle.Format = ("C")
            .Columns("Debito").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Debito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Descuento").Width = 100
            .Columns("Descuento").DefaultCellStyle.Format = ("C")
            .Columns("Descuento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Descuento").SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns("Total").Width = 100
            .Columns("Total").DefaultCellStyle.Format = ("C")
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Total").SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns("Nulo").Visible = False

            .Columns("SecondID").DisplayIndex = 0
            .Columns("SecondID").Width = 100
            .Columns("SecondID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("SecondID").SortMode = DataGridViewColumnSortMode.NotSortable
        End With
    End Sub

    Private Sub ActualizarText()
        Try

            If Me.Owner.Name = frm_recibo_pagos.Name Then
                txtIDCliente.Text = frm_recibo_pagos.txtIDCliente.Text
                txtNombreCliente.Text = frm_recibo_pagos.txtNombre.Text
                txtCalificacion.Text = frm_recibo_pagos.lblCalificacion.Text
                lblIDUsuario.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
                ControlSuperClave = 1
                RefrescarTabla()
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub RefrescarTabla()
        Try
            ''''''Abonos a facturas
            Con.Open()
            DgvHistorial.Rows.Clear()

            Dim AnexoAbonos As New MySqlCommand("SELECT IDAbono,IDCliente,Fecha,Concepto,Debito,Descuento,Total,Nulo,SecondID FROM Abonos Where IDCliente='" + txtIDCliente.Text + "' ORDER BY FECHA ASC", Con)
            Dim Lector As MySqlDataReader = AnexoAbonos.ExecuteReader

            While Lector.Read
                DgvHistorial.Rows.Add(Lector.GetValue(0), Lector.GetValue(1), Lector.GetValue(2), Lector.GetValue(3), Lector.GetValue(4), Lector.GetValue(5), Lector.GetValue(6), Lector.GetValue(7), Lector.GetValue(8))
            End While
            Lector.Close()
            Con.Close()

            For Each Row As DataGridViewRow In DgvHistorial.Rows
                If CStr(Row.Cells(7).Value) = "1" Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                    Row.Cells(3).Value = "NULO"
                End If
            Next

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub DgvHistorial_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvHistorial.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvHistorial.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvHistorial.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvHistorial.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub DgvHistorial_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvHistorial.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub VerificarPrivilegios()
        Try
            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDPrivilegios FROM" & SysName.Text & "Empleados Where IDEmpleado='" + lblIDUsuario.Text + "'", ConMixta)
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

    Private Sub LlenarFormularios()
        Dim IDAbono As New Label

        'Try
        IDAbono.Text = DgvHistorial.CurrentRow.Cells(0).Value

            Ds.clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT * FROM Abonos Where IDAbono='" + IDAbono.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Abonos")
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Abonos")

            '''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.Owner.Name = frm_recibo_pagos.Name Then

                VerificarPrivilegios()
                If Privilegio.Text = 2 Or Privilegio.Text = 3 Then
                    Exit Sub
                End If
                frm_superclave.IDAccion.Text = 5
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If
                frm_recibo_pagos.Hora.Enabled = False
                frm_recibo_pagos.txtFechaPago.Value = CDate(Tabla.Rows(0).Item("Fecha"))
                frm_recibo_pagos.txtIDPago.Text = IDAbono.Text
                frm_recibo_pagos.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_recibo_pagos.lblTransaccion.Text = (Tabla.Rows(0).Item("IDTransaccion"))
            frm_recibo_pagos.txtMontoAplicar.EditValue = CDbl(Tabla.Rows(0).Item("Debito"))
            frm_recibo_pagos.txtConceptoPago.Text = (Tabla.Rows(0).Item("Concepto"))
            frm_recibo_pagos.lblDescuento.Text = (Tabla.Rows(0).Item("Descuento"))
            frm_recibo_pagos.lbltotalAbono.Text = (Tabla.Rows(0).Item("Total"))

                If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                    frm_recibo_pagos.ChkNulo.Checked = True
                Else
                    frm_recibo_pagos.ChkNulo.Checked = False
                End If

                RefrescarTablaFacturas()
                frm_recibo_pagos.btnBuscarCliente.Enabled = False
            End If

            Close()
            Exit Sub
      '  Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        '  End Try

    End Sub

    Private Sub RemoveSavedRows(ByVal IDFactura As Integer)
        Try
            Dim iterateIndex As Integer = 0
            Dim newDataTable As DataTable = frm_recibo_pagos.DTFacturas.Copy
            For Each RT As DataRow In newDataTable.Rows
                If IDFactura = RT.Item("IDFacturaDatos") Then
                    frm_recibo_pagos.DTFacturas.Rows.RemoveAt(iterateIndex)
                Else
                    iterateIndex += 1
                End If
            Next
            newDataTable.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Sub RefrescarTablaFacturas()
        'Try
        If frm_recibo_pagos.Visible = True Then

                frm_recibo_pagos.DTFacturas.Rows.Clear()
                frm_recibo_pagos.DTPagares.Rows.Clear()
                frm_recibo_pagos.RefrescarTablaFacturas()

                ConMixta.Open()

            Dim CmdFacts As New MySqlCommand("Select IDDetalleAbono,FacturaDatos.NombreFactura,IDFactura as IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.IDTipoDocumento,FacturaDatos.Fecha,FechaVencimiento,DATEDIFF(Abonos.Fecha,FacturaDatos.Fecha) as DiasVencidos,FacturaDatos.TotalNeto,DetalleAbonos.BalanceAnterior as Balance,DetalleAbonos.CargosAnterior as CargosFactura,EstadoFactura,EstadoFactura.Color as ColorColumn,(DetalleAbonos.BalanceAnterior-DetalleAbonos.Debito-DetalleAbonos.Descuento) as Balance ,DetalleAbonos.CargosExcento,'0' as Incluir,DetalleAbonos.Cargos,DetalleAbonos.Debito as Aplicar,DetalleAbonos.Descuento,1 as Info FROM" & SysName.Text & "detalleabonos INNER JOIN" & SysName.Text & "FacturaDatos on DetalleAbonos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN" & SysName.Text & "Abonos on DetalleAbonos.IDAbono=Abonos.IDAbono INNER JOIN Libregco.EstadoFactura ON FacturaDatos.IDEstadoFactura=EstadoFactura.IDEstadoFactura WHERE DetalleAbonos.IDAbono='" + frm_recibo_pagos.txtIDPago.Text + "'", ConMixta)
            Dim LectorFacturas As MySqlDataReader = CmdFacts.ExecuteReader

            While LectorFacturas.Read                       'IDDETALLEABONO              'IDFACTURA '                '''''''''SECONDID            IDTIPODOCUMENTO                              FECHA                                                         VENCIMIENTO                             DIAS VENCIDOS                        NETO                  BALANCE ANTERIOR               CARGOS                      DEBITO                      DESCUENTO            CHECKBOX                                              BALANCE FINAL                                                   CARGOS ACUMULADOS             CARGOS EXCENTOS           ESTADO                           COLOR                                     
                RemoveSavedRows(LectorFacturas.GetValue(2))

                frm_recibo_pagos.DTFacturas.Rows.Add(LectorFacturas.GetValue(0), LectorFacturas.GetValue(1), LectorFacturas.GetValue(2), LectorFacturas.GetValue(3), LectorFacturas.GetValue(4), LectorFacturas.GetValue(5), LectorFacturas.GetValue(6), (LectorFacturas.GetValue(7)), LectorFacturas.GetValue(8), LectorFacturas.GetValue(9), LectorFacturas.GetValue(10), LectorFacturas.GetValue(11), LectorFacturas.GetValue(12), LectorFacturas.GetValue(13), LectorFacturas.GetValue(14), LectorFacturas.GetValue(15), LectorFacturas.GetValue(16), LectorFacturas.GetValue(17), LectorFacturas.GetValue(18), LectorFacturas.GetValue(19))
            End While

                LectorFacturas.Close()
                ConMixta.Close()

            frm_recibo_pagos.CheckCargos()
            frm_recibo_pagos.ResetHeaderCheckBoxLocation(frm_recibo_pagos.AdvBandedGridView1.Columns("Incluir").ColIndex, -1)
            'frm_recibo_pagos.DgvFacturas.Sort(frm_recibo_pagos.DgvFacturas.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            'For Each Rows As DataGridViewRow In frm_recibo_pagos.DgvFacturas.Rows
            '    Rows.Cells(13).Value = CDbl(CDbl(Rows.Cells(8).Value) - CDbl(Rows.Cells(10).Value) - CDbl(Rows.Cells(11).Value)).ToString("C")
            '    Rows.Cells(16).Style.ForeColor = Color.FromArgb(Rows.Cells(17).Value)
            'Next


        End If


        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try
    End Sub

    Private Sub DgvHistorial_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvHistorial.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvHistorial.ColumnCount
                Dim NumRows As Integer = DgvHistorial.RowCount
                Dim CurCell As DataGridViewCell = DgvHistorial.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvHistorial.CurrentCell = DgvHistorial.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvHistorial.CurrentCell = DgvHistorial.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvHistorial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvHistorial.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub
End Class