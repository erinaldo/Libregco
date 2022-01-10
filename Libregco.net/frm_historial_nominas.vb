Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frm_historial_nominas

    Dim sqlQ As String=""
    Dim cmd, cmd1 As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1, Ds2 As New DataSet      'Usual sin interrupcion
    Friend IDUsuario, Privilegio, CriterioenClave As New Label

    Private Sub frm_historial_nominas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        RefrescarDgvs()
    End Sub

    Private Sub RefrescarDgvs()
        RefrescarNomina()
        RefrescarDetalleNomina()
    End Sub

    Private Sub RefrescarNomina()
        Try
            Ds.Clear()
            cmd = New MySqlCommand("SELECT IDNomina,SecondID,Descripcion,FechaInicial,FechaFinal,CantEmp,TotalBruto,Corrientes,Deducciones,Neto,Nomina.Nulo FROM nomina INNER JOIN TipoNomina on Nomina.IDTipoNomina=TipoNomina.IDTipoNomina ORDER BY IDNomina DESC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Nomina")
            DgvNominas.DataSource = Ds
            DgvNominas.DataMember = "Nomina"
            DgvNominas.ClearSelection()
            PropiedadDgvNomina()
            MarcarCanceladas()
            SumarTotales()
        Catch ex As Exception
            'MessageBox.Show(ex.Message.ToString & "Desde RefrescarTabla")
        End Try
    End Sub

    Private Sub SumarTotales()
        Dim x As Integer = 0
        Dim Bruto As Double = 0
        Dim Deducciones As Double = 0
        Dim Corrientes As Double = 0
        Dim Neto As Double = 0

Inicio:
        If x = DgvNominas.Rows.Count Then
            GoTo Final
        Else
            Bruto = (Bruto + CDbl(DgvNominas.Rows(x).Cells(6).Value))
            Corrientes = (Corrientes + CDbl(DgvNominas.Rows(x).Cells(7).Value))
            Deducciones = (Deducciones + CDbl(DgvNominas.Rows(x).Cells(8).Value))
            Neto = (Neto + CDbl(DgvNominas.Rows(x).Cells(9).Value))

            x = x + 1
            GoTo Inicio
        End If
Final:
        lblBruto.Text = "Bruto: " & Bruto.ToString("C")
        lblCorrientes.Text = "Corrientes: " & Corrientes.ToString("C")
        lblDeducciones.Text = "Deducciones: " & Deducciones.ToString("C")
        lblNeto.Text = "Total Neto: " & Neto.ToString("C")
    End Sub

    Private Sub RefrescarDetalleNomina()
        Try
            Dim IDNomina As New Label
            IDNomina.Text = DgvNominas.CurrentRow.Cells(0).Value

            Ds1.Clear()
            cmd = New MySqlCommand("SELECT NominaDetalle.IDEmpleado,Nombre,Cargo,Bruto,Prestamos,CXC,Flota,TSS,ISR,Deducciones,Neto FROM nominadetalle INNER JOIN Empleados on NominaDetalle.IDEmpleado=Empleados.IDEmpleado INNER JOIN cargosemp on Empleados.IDCargo=CargosEmp.IDCargo Where IDNomina='" + IDNomina.Text + "' ORDER BY NominaDetalle.IDEmpleado DESC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "DetalleNomina")
            DgvDetalleNominas.DataSource = Ds1
            DgvDetalleNominas.DataMember = "DetalleNomina"
            PropiedadDgvDetalleNomina()

        Catch ex As Exception
            DgvDetalleNominas.DataSource = Nothing
            DgvDetalleNominas.Rows.Clear()
        End Try
    End Sub

    Private Sub DgvNominas_SelectionChanged(sender As Object, e As EventArgs) Handles DgvNominas.SelectionChanged
        RefrescarDetalleNomina()
    End Sub

    Private Sub PropiedadDgvDetalleNomina()
        With DgvDetalleNominas
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 70
            .Columns(1).HeaderText = "Empleado"
            .Columns(1).Width = 200
            .Columns(2).Width = 120
            .Columns(3).Width = 100
            .Columns(3).DefaultCellStyle.Format = ("C")
            .Columns(4).Width = 100
            .Columns(4).DefaultCellStyle.Format = ("C")
            .Columns(5).Width = 100
            .Columns(5).DefaultCellStyle.Format = ("C")
            .Columns(6).Width = 100
            .Columns(6).DefaultCellStyle.Format = ("C")
            .Columns(7).Width = 100
            .Columns(7).DefaultCellStyle.Format = ("C")
            .Columns(8).Width = 100
            .Columns(8).DefaultCellStyle.Format = ("C")
            .Columns(9).Width = 100
            .Columns(9).DefaultCellStyle.Format = ("C")
            .Columns(10).Width = 100
            .Columns(10).DefaultCellStyle.Format = ("C")
        End With
    End Sub

    Private Sub PropiedadDgvNomina()
        With DgvNominas
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Código"
            .Columns(1).Width = 100
            .Columns(2).HeaderText = "Nómina"
            .Columns(2).Width = 120
            .Columns(3).HeaderText = "F. Inicial"
            .Columns(3).Width = 70
            .Columns(4).HeaderText = "F. Final"
            .Columns(4).Width = 70
            .Columns(5).HeaderText = "Cant."
            .Columns(5).Width = 40
            .Columns(6).Width = 100
            .Columns(6).DefaultCellStyle.Format = ("C")
            .Columns(6).HeaderText = "Total bruto"
            .Columns(7).Width = 100
            .Columns(7).DefaultCellStyle.Format = ("C")
            .Columns(7).HeaderText = "Corrientes"
            .Columns(8).Width = 100
            .Columns(8).DefaultCellStyle.Format = ("C")
            .Columns(8).HeaderText = "Deducciones"
            .Columns(9).Width = 100
            .Columns(9).DefaultCellStyle.Format = ("C")
            .Columns(9).HeaderText = "Neto"
            .Columns(10).Visible = False

        End With
    End Sub

    Private Sub DgvNominas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNominas.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub LlenarFormularios()
        Dim IDNomina As New Label
        IDNomina.Text = DgvNominas.CurrentRow.Cells(0).Value
        Try
            Ds2.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDNomina,SecondID,Fecha,Hora,IDUsuario,Nomina.IDTipoNomina,Descripcion,FechaInicial,FechaFinal,Diario,Semanal,Quincenal,Mensual,TotalBruto,Corrientes,Deducciones,Neto,CantEmp,Nomina.Nulo FROM nomina INNER JOIN tiponomina on Nomina.IDTipoNomina=TipoNomina.IDTipoNomina Where IDNomina='" + IDNomina.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds2, "Nomina")
            Con.Close()

            Dim Tabla As DataTable = Ds2.Tables("Nomina")

            If Me.Owner.Name = frm_proceso_nomina.Name Then
                With frm_proceso_nomina
                    .txtIDNomina.Text = (Tabla.Rows(0).Item("IDNomina"))
                    .txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                    .txtFecha.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                    .txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora"))
                    .lblIDUsuario.Text = (Tabla.Rows(0).Item("IDUsuario"))
                    .txtIDTipoNomina.Text = (Tabla.Rows(0).Item("IDTipoNomina"))
                    .txtTipoNomina.Text = (Tabla.Rows(0).Item("Descripcion"))
                    .DtpFechaInicial.Value = (Tabla.Rows(0).Item("FechaInicial"))
                    .DtpFechaFinal.Value = (Tabla.Rows(0).Item("FechaFinal"))
                    .chkDiario.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Diario"))
                    .chkSemanal.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Semanal"))
                    .chkQuincenal.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Quincenal"))
                    .chkMensual.Checked = Convert.ToBoolean(Tabla.Rows(0).Item("Mensual"))
                    .txtTotalBruto.Text = CDbl(Tabla.Rows(0).Item("TotalBruto")).ToString("C")
                    .txtDeduccionesCorrientes.Text = CDbl(Tabla.Rows(0).Item("Corrientes")).ToString("C")
                    .txtTotalDeducciones.Text = CDbl(Tabla.Rows(0).Item("Deducciones")).ToString("C")
                    .txtTotalNeto.Text = CDbl(Tabla.Rows(0).Item("Neto")).ToString("C")
                    .txtCantidadEmpleados.Text = (Tabla.Rows(0).Item("CantEmp"))
                    .chkNulo.Text = Convert.ToBoolean(Tabla.Rows(0).Item("Nulo"))

                    If CDate(Tabla.Rows(0).Item("FechaFinal")).Month = 12 Then
                        If CDbl(Tabla.Rows(0).Item("Corrientes")) + CDbl(Tabla.Rows(0).Item("Deducciones")) = 0 Then
                            frm_proceso_nomina.DgvEmpleados.Columns(4).ReadOnly = False
                            frm_proceso_nomina.DgvEmpleados.Columns(5).Visible = False
                            frm_proceso_nomina.DgvEmpleados.Columns(6).Visible = False
                            frm_proceso_nomina.DgvEmpleados.Columns(7).Visible = False
                            frm_proceso_nomina.DgvEmpleados.Columns(8).Visible = False
                            frm_proceso_nomina.DgvEmpleados.Columns(9).Visible = False
                            frm_proceso_nomina.DgvEmpleados.Columns(10).Visible = False
                            frm_proceso_nomina.DgvEmpleados.Columns(11).Visible = False
                            frm_proceso_nomina.DgvEmpleados.Columns(12).Width = 600
                        End If
                    End If



                    If (Tabla.Rows(0).Item("Diario")) = 1 Then
                        frm_proceso_nomina.chkDiario.Checked = True
                    Else
                        frm_proceso_nomina.chkDiario.Checked = False
                    End If

                    If (Tabla.Rows(0).Item("Semanal")) = 1 Then
                        frm_proceso_nomina.chkSemanal.Checked = True
                    Else
                        frm_proceso_nomina.chkSemanal.Checked = False
                    End If

                    If (Tabla.Rows(0).Item("Quincenal")) = 1 Then
                        frm_proceso_nomina.chkQuincenal.Checked = True
                    Else
                        frm_proceso_nomina.chkQuincenal.Checked = False
                    End If

                    If (Tabla.Rows(0).Item("Mensual")) = 1 Then
                        frm_proceso_nomina.chkMensual.Checked = True
                    Else
                        frm_proceso_nomina.chkMensual.Checked = False
                    End If

                    If (Tabla.Rows(0).Item("Nulo")) = 1 Then
                        frm_proceso_nomina.chkNulo.Checked = True
                    Else
                        frm_proceso_nomina.chkNulo.Checked = False
                    End If

                    RefrescarEmpleados()


                End With

            ElseIf Me.Owner.Name = frm_reporte_nomina.Name Then
                frm_reporte_nomina.txtIDNomina.Text = DgvNominas.CurrentRow.Cells(0).Value
                frm_reporte_nomina.txtNomina.Text = DgvNominas.CurrentRow.Cells(1).Value
            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub RefrescarEmpleados()
        Try
            If Me.Owner.Name = frm_proceso_nomina.Name Then
                With frm_proceso_nomina
                    .DgvEmpleados.Rows.Clear()
                    Con.Open()

                    Dim CmdEmpleados As New MySqlCommand("Select IDNominaDetalle,NominaDetalle.IDEmpleado,Empleados.Nombre,CargosEmp.Cargo,Bruto,Prestamos,CXC,Flota,TSS,ISR,Deducciones,Neto,Nota FROM NominaDetalle INNER JOIN Empleados on NominaDetalle.IDEmpleado=Empleados.IDEmpleado INNER JOIN CargosEmp on Empleados.IDCargo=CargosEmp.IDCargo WHERE IDNomina='" + frm_proceso_nomina.txtIDNomina.Text + "'", Con)
                    Dim LectorEmpleados As MySqlDataReader = CmdEmpleados.ExecuteReader

                    While LectorEmpleados.Read
                        .DgvEmpleados.Rows.Add(LectorEmpleados.GetValue(0), LectorEmpleados.GetValue(1), LectorEmpleados.GetValue(2), LectorEmpleados.GetValue(3), CDbl(LectorEmpleados.GetValue(4)).ToString("C"), CDbl(LectorEmpleados.GetValue(5)).ToString("C"), CDbl(LectorEmpleados.GetValue(6)).ToString("C"), CDbl(LectorEmpleados.GetValue(7)).ToString("C"), CDbl(LectorEmpleados.GetValue(8)).ToString("C"), CDbl(LectorEmpleados.GetValue(9)).ToString("C"), CDbl(LectorEmpleados.GetValue(10)).ToString("C"), CDbl(LectorEmpleados.GetValue(11)).ToString("C"), LectorEmpleados.GetValue(12))
                    End While
                    LectorEmpleados.Close()
                    Con.Close()
                End With
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub MarcarCanceladas()
        Try
            For Each Row As DataGridViewRow In DgvNominas.Rows
                If CInt(Row.Cells(10).Value) = 1 Then
                    Row.DefaultCellStyle.BackColor = Color.LightGray
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgvNominas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvNominas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub DgvNominas_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvNominas.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvNominas.ColumnCount
                Dim NumRows As Integer = DgvNominas.RowCount
                Dim CurCell As DataGridViewCell = DgvNominas.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvNominas.CurrentCell = DgvNominas.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvNominas.CurrentCell = DgvNominas.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

  
End Class