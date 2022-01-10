Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Public Class frm_prestaciones_laborales
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim arrTiempoCalculo(2) As Integer
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim IDReport, DescripcionReport, PathReport, OrdenCampo, OrdenFormula As New Label
    Dim Permisos As New ArrayList
    Private Sub frm_prestaciones_laborales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        Permisos = PasarPermisos(Me.Tag)
        CargarLibregco()
        FillReporte
        dtpFechaIngreso.MaxDate = Today
        dtpFechaSalida.MinDate = dtpFechaIngreso.Value

        FillAllMonths()
        SelectedAvailablesMonths()
    End Sub

    Private Sub FillReporte()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT * FROM Reportes Where MenuString='PrestacionesLaborales'", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Reportes")
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Reportes")

        IDReport.Text = (Tabla.Rows(0).Item("IDReportes"))
        DescripcionReport.Text = (Tabla.Rows(0).Item("Descripcion"))
        PathReport.Text = (Tabla.Rows(0).Item("Path"))
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub FillAllMonths()
        DgvSalarios.Rows.Clear()

        DgvSalarios.Rows.Add(1, "", "", "")
        DgvSalarios.Rows.Add(2, "", "", "")
        DgvSalarios.Rows.Add(3, "", "", "")
        DgvSalarios.Rows.Add(4, "", "", "")
        DgvSalarios.Rows.Add(5, "", "", "")
        DgvSalarios.Rows.Add(6, "", "", "")
        DgvSalarios.Rows.Add(7, "", "", "")
        DgvSalarios.Rows.Add(8, "", "", "")
        DgvSalarios.Rows.Add(9, "", "", "")
        DgvSalarios.Rows.Add(10, "", "", "")
        DgvSalarios.Rows.Add(11, "", "", "")
        DgvSalarios.Rows.Add(12, "", "", "")
    End Sub

    Private Sub BtnCalcular_Click(sender As Object, e As EventArgs) Handles BtnCalcular.Click
        Dim TiempoLaborado(2) As Integer
        calcDifFechas(dtpFechaIngreso.Value, dtpFechaSalida.Value, arrTiempoCalculo)
        calcDifFechas(dtpFechaIngreso.Value, dtpFechaSalida.Value, TiempoLaborado)
        '(0)       año (1) mes (2) dia

        Dim Mensaje As String = ""

        If TiempoLaborado(0) > 0 Then
            Mensaje += TiempoLaborado(0) & If(TiempoLaborado(0) > 1, " años", " año")

            If TiempoLaborado(1) > 0 Then

                If TiempoLaborado(2) > 0 Then
                    Mensaje += ", " & TiempoLaborado(1) & If(TiempoLaborado(1) > 1, " meses", " mes")
                    Mensaje += " y " & TiempoLaborado(2) & If(TiempoLaborado(2) > 1, " días", " día")
                Else

                    Mensaje += " y " & TiempoLaborado(1) & If(TiempoLaborado(1) > 1, " meses", " mes")

                End If


            ElseIf TiempoLaborado(2) > 0 Then
                Mensaje += " y " & TiempoLaborado(2) & If(TiempoLaborado(2) > 1, " días", " día")
            End If

        ElseIf TiempoLaborado(1) > 0 Then
            If TiempoLaborado(2) > 0 Then
                Mensaje += TiempoLaborado(1) & If(TiempoLaborado(1) > 1, " meses", " mes")
                Mensaje += " y " & TiempoLaborado(2) & If(TiempoLaborado(2) > 1, " días", " día")

            Else

                Mensaje += TiempoLaborado(1) & If(TiempoLaborado(1) > 1, " meses", " mes")
            End If

        ElseIf TiempoLaborado(2) > 0 Then
            Mensaje += TiempoLaborado(2) & If(TiempoLaborado(2) > 1, " días", " día")
        End If

        txtTiempoLaborado.Text = Mensaje

        CalcularSueldos()
    End Sub

    Private Sub SelectedAvailablesMonths()
        Try
            If dtpFechaIngreso.Value > Today Then
                MessageBox.Show("La fecha de ingreso no puede exceder el día de hoy.")
                Exit Sub
            ElseIf dtpFechaIngreso.Value > dtpFechaSalida.Value Then
                MessageBox.Show("La fecha de ingreso no puede ser mayor a la fecha de salida")
                Exit Sub
            End If

            calcDifFechas(dtpFechaIngreso.Value, dtpFechaSalida.Value, arrTiempoCalculo)

            FillAllMonths()

            For Each row As DataGridViewRow In DgvSalarios.Rows

                If CDbl(row.Cells(0).Value) > arrTiempoCalculo(1) And arrTiempoCalculo(0) < 1 Then
                    If arrTiempoCalculo(1) = 0 And CDbl(row.Cells(0).Value) = 1 Then
                        row.Cells(1).Value = CDbl(0).ToString("C")
                        row.Cells(1).ReadOnly = False
                        row.Cells(2).Value = CDbl(0).ToString("C")
                        row.Cells(2).ReadOnly = False
                        row.Cells(3).Value = CDbl(0).ToString("C")
                        row.DefaultCellStyle.BackColor = Color.White
                        row.Cells(4).ReadOnly = False
                    Else
                        row.Cells(1).Value = "N/A"
                        row.Cells(1).ReadOnly = True
                        row.Cells(2).Value = "N/A"
                        row.Cells(2).ReadOnly = True
                        row.Cells(3).Value = "N/A"
                        row.DefaultCellStyle.BackColor = SystemColors.Control
                        row.Cells(4).ReadOnly = True
                    End If

                Else
                    row.Cells(1).Value = CDbl(0).ToString("C")
                    row.Cells(1).ReadOnly = False
                    row.Cells(2).Value = CDbl(0).ToString("C")
                    row.Cells(2).ReadOnly = False
                    row.Cells(3).Value = CDbl(0).ToString("C")
                    row.DefaultCellStyle.BackColor = Color.White
                    row.Cells(4).ReadOnly = False
                End If
            Next

            DgvSalarios.ClearSelection()
        Catch ex As Exception

        End Try
        'MessageBox.Show(arrTiempoCalculo(1))

    End Sub

    Private Sub CalcularSueldos()
        Try
            If dtpFechaIngreso.Value <> dtpFechaSalida.Value Then
                Dim SueldoAcumulado As Double = 0
                Dim promediodiario As Double = 0


                For Each row As DataGridViewRow In DgvSalarios.Rows
                    If row.Cells(1).ReadOnly = False Then
                        SueldoAcumulado += CDbl(row.Cells(3).Value)
                    End If
                Next

                txtSumaSalarios.Text = SueldoAcumulado.ToString("C")

                Dim Coeficiente As Double = 0
                If rdbMensual.Checked = True Then
                    Coeficiente = 1
                ElseIf rdbQuincenal.Checked = True Then
                    Coeficiente = 2
                ElseIf rdbSemanal.Checked = True Then
                    Coeficiente = 4.3333
                ElseIf rdbDiario.Checked = True Then
                    Coeficiente = 23.83
                End If

                Dim promedioMensual As Double = 0
                If arrTiempoCalculo(0) > 0 Then
                    promedioMensual = (SueldoAcumulado / 12) * Coeficiente

                ElseIf arrTiempoCalculo(1) > 0 Then
                    promedioMensual = (SueldoAcumulado / arrTiempoCalculo(1)) * Coeficiente

                Else
                    promedioMensual = SueldoAcumulado * Coeficiente
                End If

                txtSalarioPromedioMensual.Text = promedioMensual.ToString("C")








                promediodiario = (promedioMensual / 23.83)
                txtSalarioPromedioDiario.Text = (promediodiario).ToString("C")
                'txtSalarioPromedioDiario.Tag = (promedioMensual)



                ' Calcular Preaviso

                Dim mesesPreaviso As Integer = ((arrTiempoCalculo(0) * 12) + arrTiempoCalculo(1))
                Dim diaspreaviso As Integer = 0
                Dim totalpreaviso As Double = 0

                Select Case (True)
                    Case (mesesPreaviso >= 12)
                        diaspreaviso = 28
                    Case (mesesPreaviso >= 6)
                        diaspreaviso = 14
                    Case (mesesPreaviso >= 3)
                        diaspreaviso = 7
                End Select

                totalpreaviso = (CDbl(promedioMensual / 23.83)) * diaspreaviso

                If TsPreaviso.IsOn = True Then
                    txtPreaviso.Text = CDbl(0).ToString("C")
                    txtPreaviso.Tag = CDbl(0)
                Else

                    txtPreaviso.Text = CDbl(totalpreaviso).ToString("C") & " (" & diaspreaviso & ") " & If(diaspreaviso > 1, "días", "día")
                    txtPreaviso.Tag = CDbl(totalpreaviso)
                End If


                ' Cesantia
                Dim fechaingreso(2) As Integer

                fechaingreso(0) = dtpFechaIngreso.Value.Day
                fechaingreso(1) = dtpFechaIngreso.Value.Month
                fechaingreso(2) = dtpFechaIngreso.Value.Year

                Dim fechasalida(2) As Integer
                fechasalida(0) = dtpFechaSalida.Value.Day
                fechasalida(1) = dtpFechaSalida.Value.Month
                fechasalida(2) = dtpFechaSalida.Value.Year

                Dim fecha1 As Date = New Date(fechaingreso(2), fechaingreso(1), fechaingreso(0))
                Dim fecha2 As Date = New Date(fechasalida(2), fechasalida(1), fechasalida(0))

                Dim d1 As Date = New Date(1992, 5, 17)
                Dim d2 As Date = New Date(fechaingreso(2), fechaingreso(1), fechaingreso(0))

                Dim TiempoAntesCodigo(3) As Integer
                Dim TiempoDespuesCodigo(3) As Integer
                Dim iDiasCensantiaAnterior = 0

                If d1 > d2 Then
                    calcDifFechas(d2, d1, TiempoAntesCodigo)
                    d2 = New Date(fechasalida(2), fechasalida(1), fechasalida(0))

                    calcDifFechas(d1, d2, TiempoDespuesCodigo)

                    If (TiempoAntesCodigo(0) > 0) Then
                        iDiasCensantiaAnterior = TiempoAntesCodigo(0) * 15
                    End If

                    ''Ajuste en los meses despues del codigo con la suma de los dias antes y despues
                    If ((TiempoAntesCodigo(2) + TiempoDespuesCodigo(2)) >= 30) Then
                        TiempoDespuesCodigo(1) = TiempoDespuesCodigo(1) + 1
                    End If

                    'Ajuste en los anos despues del codigo con la suma de los anos antes y despues

                    If ((TiempoDespuesCodigo(1) + TiempoAntesCodigo(1)) >= 12) Then
                        TiempoDespuesCodigo(1) = TiempoDespuesCodigo(1) + TiempoAntesCodigo(1) - 12
                        TiempoDespuesCodigo(0) = TiempoDespuesCodigo(0) + 1
                    End If

                Else

                    TiempoDespuesCodigo(0) = arrTiempoCalculo(0)
                    TiempoDespuesCodigo(1) = arrTiempoCalculo(1)
                    TiempoDespuesCodigo(2) = arrTiempoCalculo(2)
                End If

                Dim iDiasCesantiaNueva As Integer = 0

                If (TiempoDespuesCodigo(0) >= 5) Then
                    iDiasCesantiaNueva = iDiasCesantiaNueva + (23 * TiempoDespuesCodigo(0))
                ElseIf (TiempoDespuesCodigo(0) >= 1) Then
                    iDiasCesantiaNueva = iDiasCesantiaNueva + (21 * TiempoDespuesCodigo(0))
                End If

                If (TiempoDespuesCodigo(1) >= 6) Then
                    iDiasCesantiaNueva = (iDiasCesantiaNueva + 13)
                ElseIf (TiempoDespuesCodigo(1) >= 3) Then
                    iDiasCesantiaNueva = (iDiasCesantiaNueva + 6)
                End If

                Dim cCesantiaAnterior As Double = (iDiasCensantiaAnterior * promediodiario * 100) / 100
                Dim cCesantiaNueva As Double = (iDiasCesantiaNueva * promediodiario * 100) / 100

                If TSCesantia.IsOn = False Then
                    txtCensantiaAntes.Text = CDbl(0).ToString("C")
                    txtCensantiaAntes.Tag = 0
                    txtCesantiaNuevo.Text = CDbl(0).ToString("C")
                    txtCesantiaNuevo.Tag = 0
                    cCesantiaAnterior = 0
                    cCesantiaAnterior = 0

                Else
                    If (iDiasCensantiaAnterior > 0) Then
                        txtCensantiaAntes.Text = CDbl(cCesantiaAnterior).ToString("C") & " (" & iDiasCensantiaAnterior & " días)"
                        txtCensantiaAntes.Tag = cCesantiaAnterior
                    Else
                        txtCensantiaAntes.Text = CDbl(0).ToString("C") & " (" & iDiasCensantiaAnterior & " días)"
                        txtCensantiaAntes.Tag = 0
                    End If


                    If (iDiasCesantiaNueva > 0) Then
                        txtCesantiaNuevo.Text = CDbl(cCesantiaNueva).ToString("C") & " (" & iDiasCesantiaNueva & " días)"
                        txtCesantiaNuevo.Tag = cCesantiaNueva
                    Else
                        txtCesantiaNuevo.Text = CDbl(0).ToString("C")
                        txtCesantiaNuevo.Tag = 0
                    End If
                End If


                'Vacaciones
                Dim diasvacaciones As Integer = 0

                If TSVacaciones.IsOn = False Then
                    Select Case (True)
                        Case (mesesPreaviso >= 60)
                            diasvacaciones = 18
                            Exit Select
                        Case (mesesPreaviso >= 12)
                            diasvacaciones = 14
                            Exit Select
                        Case (mesesPreaviso >= 5)
                            diasvacaciones = mesesPreaviso + 1
                            Exit Select
                    End Select

                Else

                    Select Case (True)
                        Case (arrTiempoCalculo(1) > 11)
                            diasvacaciones = 12
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 10)
                            diasvacaciones = 11
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 9)
                            diasvacaciones = 10
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 8)
                            diasvacaciones = 9
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 7)
                            diasvacaciones = 8
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 6)
                            diasvacaciones = 7
                            Exit Select
                        Case (arrTiempoCalculo(1) >= 5)
                            diasvacaciones = 6
                            Exit Select
                    End Select

                End If

                Dim salarioVacaciones As Double = 0
                Dim valorDiaVacaciones As Double = 0

                If (arrTiempoCalculo(0) > 0) Then
                    'Tomamos el valor para el dia de vacaciones cuando tenga el ano acumulado
                    valorDiaVacaciones = CDbl(DgvSalarios.Rows(11).Cells(3).Value) / 23.83
                    salarioVacaciones = diasvacaciones * valorDiaVacaciones

                ElseIf (arrTiempoCalculo(1) > 0) Then
                    'Tomamos el valor para el dia de vacaciones con el ultimo salario
                    valorDiaVacaciones = CDbl(DgvSalarios.Rows(arrTiempoCalculo(1) - 1).Cells(3).Value) / 23.83
                    salarioVacaciones = diasvacaciones * valorDiaVacaciones


                Else

                    valorDiaVacaciones = CDbl(DgvSalarios.Rows(0).Cells(3).Value) / 23.83
                    salarioVacaciones = diasvacaciones * valorDiaVacaciones

                End If

                If (diasvacaciones > 0) Then
                    txtVacaciones.Text = CDbl(salarioVacaciones).ToString("C") & " (" & diasvacaciones & If(diasvacaciones > 1, " días", " día") & ")"
                    txtVacaciones.Tag = salarioVacaciones

                Else
                    txtVacaciones.Text = CDbl(0).ToString("C")
                    txtVacaciones.Tag = 0
                End If

                If txtVacaciones.Text = "" Then
                    txtVacaciones.Text = CDbl(0).ToString("C")
                    txtVacaciones.Tag = 0
                End If

                txtSubtotal.Text = (CDbl(txtPreaviso.Tag) + CDbl(txtCensantiaAntes.Tag) + CDbl(txtCesantiaNuevo.Tag) + CDbl(txtVacaciones.Tag)).ToString("C")

                'Salario de navidad
                Dim SalarioNavidad As Double = 0

                If TSNavidad.IsOn = False Then
                    txtNavidad.Text = CDbl(0).ToString("C")
                    txtNavidad.Tag = 0

                Else

                    Dim arrTiempoNavidad(2) As Integer
                    'Dim dd1 As New Date

                    'If (fechaingreso(2) <> fechasalida(2)) Then
                    '    dd1 = New Date(1990, 1, 1)
                    'Else
                    '    If (fechaingreso(1) = 1) Then
                    '        dd1 = New Date(1899, 12, fechaingreso(0))
                    '    Else
                    '        dd1 = New Date(1900, (fechaingreso(1) - 1), fechaingreso(0))
                    '    End If

                    'End If


                    'Dim dd2 As Date
                    'If fechasalida(1) = 1 Then
                    '    dd2 = New Date(1899, 12, fechasalida(0))
                    'Else
                    '    dd2 = New Date(1900, 12, fechasalida(0))
                    'End If

                    'dd2.AddDays(1)

                    Dim dd1 As New Date
                    If dtpFechaIngreso.Value > DateSerial(Today.Year, 1, 1) Then
                        dd1 = dtpFechaIngreso.Value
                    Else
                        dd1 = DateSerial(Today.Year, 1, 1)
                    End If

                    Dim dd2 As New Date
                    dd2 = dtpFechaSalida.Value

                    calcDifFechas(dd1, dd2, arrTiempoNavidad)

                    Dim totaldiasmes As Integer = diasMes(fechasalida(1), fechasalida(2))

                    If (arrTiempoNavidad(0) > 0) Then
                        SalarioNavidad = promedioMensual

                    Else
                        SalarioNavidad = ((arrTiempoNavidad(1) * promedioMensual) + (((arrTiempoNavidad(2) * 23.83) / totaldiasmes) * promediodiario)) / 12
                    End If

                    'Mostrar el tiempo de navidad
                    Dim tiempoNavidad As String = ""

                    If (arrTiempoNavidad(0) > 0) Then
                        tiempoNavidad = " (1 Año)"

                    ElseIf (arrTiempoNavidad(1) > 0) Then
                        tiempoNavidad = " ("
                        tiempoNavidad += arrTiempoNavidad(1) & If(arrTiempoNavidad(1) > 1, " meses", " mes")

                        If (arrTiempoNavidad(2) > 0) Then
                            tiempoNavidad += " y " & arrTiempoNavidad(2) & If(arrTiempoNavidad(2) > 1, " días", " día")
                        End If

                        tiempoNavidad += ")"

                    Else

                        tiempoNavidad = " " & arrTiempoNavidad(2) & If(arrTiempoNavidad(2) > 1, " días", " día")
                    End If

                    txtNavidad.Text = CDbl(SalarioNavidad).ToString("C") & tiempoNavidad
                    txtNavidad.Tag = SalarioNavidad

                End If

                txtTotalRecibir.Text = (CDbl(txtPreaviso.Tag) + CDbl(txtCensantiaAntes.Tag) + CDbl(txtCesantiaNuevo.Tag) + CDbl(txtVacaciones.Tag) + CDbl(txtNavidad.Tag)).ToString("C")

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function diasMes(ByVal mes As Integer, ByVal anno As Integer) As Integer
        Select Case (mes)
            Case 1, 3, 5, 7, 8, 10, 12
                Return 31

            Case 2
                If Date.IsLeapYear(anno) Then
                    Return 29
                Else
                    Return 28
                End If

            Case Else
                Return 30
        End Select

    End Function

    Private Sub dtpFechaIngreso_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaIngreso.ValueChanged
        dtpFechaSalida.MinDate = dtpFechaIngreso.Value
        SelectedAvailablesMonths()

    End Sub

    Private Sub dtpFechaSalida_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaSalida.ValueChanged
        dtpFechaSalida.MinDate = dtpFechaIngreso.Value
        SelectedAvailablesMonths()
    End Sub

    Private Sub DgvSalarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSalarios.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Then
                DgvSalarios.EditMode = DataGridViewEditMode.EditOnEnter

            ElseIf e.ColumnIndex = 4 Then

                For i As Integer = e.RowIndex To DgvSalarios.Rows.Count - 1
                    If DgvSalarios.Rows(i).Cells(1).Value = "N/A" Then
                    Else
                        DgvSalarios.Rows(i).Cells(1).Value = DgvSalarios.Rows(e.RowIndex).Cells(1).Value
                        DgvSalarios.Rows(i).Cells(2).Value = DgvSalarios.Rows(e.RowIndex).Cells(2).Value
                        DgvSalarios.Rows(i).Cells(3).Value = (CDbl(DgvSalarios.Rows(e.RowIndex).Cells(1).Value) + CDbl(DgvSalarios.Rows(e.RowIndex).Cells(2).Value)).ToString("C")
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub DgvSalarios_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvSalarios.CurrentCellDirtyStateChanged
        If DgvSalarios.IsCurrentCellDirty Then
            DgvSalarios.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvSalarios_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSalarios.CellEndEdit
        DgvSalarios.CommitEdit(DataGridViewDataErrorContexts.Commit)

    End Sub

    Private Sub DgvSalarios_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvSalarios.CellValueChanged
        Try
            If e.ColumnIndex = 1 Then
                If IsNumeric(CDbl(DgvSalarios.CurrentRow.Cells(1).Value)) Then
                    DgvSalarios.CurrentRow.Cells(1).Value = CDbl(DgvSalarios.CurrentRow.Cells(1).Value).ToString("C")
                    DgvSalarios.CurrentRow.Cells(3).Value = (CDbl(DgvSalarios.CurrentRow.Cells(1).Value) + CDbl(DgvSalarios.CurrentRow.Cells(2).Value)).ToString("C")
                Else
                    DgvSalarios.CurrentRow.Cells(1).Value = CDbl(0).ToString("C")
                    DgvSalarios.CurrentRow.Cells(3).Value = (CDbl(DgvSalarios.CurrentRow.Cells(1).Value) + CDbl(DgvSalarios.CurrentRow.Cells(2).Value)).ToString("C")
                End If
            End If
        Catch ex As Exception
            If DgvSalarios.Rows.Count > 0 Then
                DgvSalarios.CurrentRow.Cells(1).Value = CDbl(0).ToString("C")
            End If

        End Try

        Try

            If e.ColumnIndex = 2 Then
                If IsNumeric(CDbl(DgvSalarios.CurrentRow.Cells(2).Value)) Then
                    DgvSalarios.CurrentRow.Cells(2).Value = CDbl(DgvSalarios.CurrentRow.Cells(2).Value).ToString("C")
                    DgvSalarios.CurrentRow.Cells(3).Value = (CDbl(DgvSalarios.CurrentRow.Cells(1).Value) + CDbl(DgvSalarios.CurrentRow.Cells(2).Value)).ToString("C")
                Else
                    DgvSalarios.CurrentRow.Cells(2).Value = CDbl(0).ToString("C")
                    DgvSalarios.CurrentRow.Cells(3).Value = (CDbl(DgvSalarios.CurrentRow.Cells(1).Value) + CDbl(DgvSalarios.CurrentRow.Cells(2).Value)).ToString("C")
                End If
            End If

        Catch ex As Exception

            If DgvSalarios.Rows.Count > 0 Then
                DgvSalarios.CurrentRow.Cells(2).Value = CDbl(0).ToString("C")
            End If

        End Try


    End Sub

    Private Sub DgvSalarios_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvSalarios.EditingControlShowing
        Dim Validar As TextBox = CType(e.Control, TextBox)
        AddHandler Validar.KeyPress, AddressOf Validar_KeyPress


    End Sub

    Private Sub Validar_KeyPress(sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Columna As Integer = DgvSalarios.CurrentCell.ColumnIndex


        If Columna = 1 Or Columna = 2 Then
            Dim Caracter As Char = e.KeyChar
            Dim Txt As TextBox = CType(sender, TextBox)

            If (Char.IsNumber(Caracter)) Or (Caracter = ChrW(Keys.Back)) Then

                e.Handled = False
            Else
                e.Handled = True
            End If

        End If
    End Sub

    Private Sub TsPreaviso_Toggled(sender As Object, e As EventArgs) Handles TsPreaviso.Toggled
        BtnCalcular.PerformClick()
    End Sub

    Private Sub TSCesantia_Toggled(sender As Object, e As EventArgs) Handles TSCesantia.Toggled
        BtnCalcular.PerformClick()
    End Sub

    Private Sub TSVacaciones_Toggled(sender As Object, e As EventArgs) Handles TSVacaciones.Toggled
        BtnCalcular.PerformClick()
    End Sub

    Private Sub TSNavidad_Toggled(sender As Object, e As EventArgs) Handles TSNavidad.Toggled
        BtnCalcular.PerformClick()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnBuscarEmpleado.Click
        frm_buscar_mant_empleados.ShowDialog(Me)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        dtpFechaIngreso.Enabled = True
        btnCleanEmpleado.Visible = False
        lblNombre.Visible = False
        lblCedula.Visible = False
        lblFechaIngreso.Visible = False
        PicImagen.Visible = False
        btnBuscarEmpleado.Visible = True

        dtpFechaIngreso.Value = Today
        dtpFechaSalida.Value = Today

        rdbMensual.Checked = True
        txtSumaSalarios.Text = CDbl(0).ToString("C")
        txtSalarioPromedioDiario.Text = CDbl(0).ToString("C")
        txtSalarioPromedioMensual.Text = CDbl(0).ToString("C")

        txtPreaviso.Text = CDbl(0).ToString("C")
        txtCensantiaAntes.Text = CDbl(0).ToString("C")
        txtCesantiaNuevo.Text = CDbl(0).ToString("C")

        txtVacaciones.Text = CDbl(0).ToString("C")
        txtNavidad.Text = CDbl(0).ToString("C")
        txtSubtotal.Text = CDbl(0).ToString("C")
        txtTotalRecibir.Text = CDbl(0).ToString("C")
        txtTiempoLaborado.Clear()

        TsPreaviso.IsOn = False
        TSCesantia.IsOn = True
        TSVacaciones.IsOn = True
        TSNavidad.IsOn = True


        FillAllMonths()
        SelectedAvailablesMonths()
    End Sub

    Private Sub btnCleanEmpleado_Click(sender As Object, e As EventArgs) Handles btnCleanEmpleado.Click
        btnLimpiar.PerformClick()
    End Sub

    Private Sub LoadAnimation()
        If PicLogo.Visible = False Then
            PicLogo.Visible = True
            lblStatusBar.Text = "Cargando..."
        Else
            PicLogo.Visible = False
            lblStatusBar.Text = "Listo"
        End If

    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Permisos(3) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para realizar impresiones de este tipo de registro.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue
            Dim ObjRpt As New ReportDocument

            If TypeConnection.Text = 1 Then ObjRpt.Load("\\" & PathServidor.Text & PathReport.Text) Else ObjRpt.Load("C:" & PathReport.Text.Replace("\Libregco\Libregco.net", ""))


            crParameterValues.Clear()
            frm_reportView.CrystalViewer.Cursor = Cursors.AppStarting
            LoadAnimation()

            'Setting Info 
            ObjRpt.SetParameterValue("@Cedula", lblCedula.Text)
            ObjRpt.SetParameterValue("@Nombre", lblNombre.Text)
            ObjRpt.SetParameterValue("@Lugar", frm_inicio.lblRazon.Text)
            ObjRpt.SetParameterValue("@Ingreso", dtpFechaIngreso.Value.ToString("dd/MM/yyyy"))
            ObjRpt.SetParameterValue("@Salida", dtpFechaSalida.Value.ToString("dd/MM/yyyy"))
            ObjRpt.SetParameterValue("@TiempoLaborando", txtTiempoLaborado.Text)
            ObjRpt.SetParameterValue("@SalarioPromedioMensual", txtSalarioPromedioMensual.Text)

            Dim RowsFilled As Integer = 0
            For Each row As DataGridViewRow In DgvSalarios.Rows
                If row.Cells(3).Value <> "N/A" Then
                    If CDbl(row.Cells(3).Value) > 0 Then
                        RowsFilled += 1
                    End If
                End If
            Next
            ObjRpt.SetParameterValue("@SalarioActual", DgvSalarios.Rows(RowsFilled - 1).Cells(3).Value)

            ObjRpt.SetParameterValue("@SalarioPromedioDiario", txtSalarioPromedioMensual.Text)
            ObjRpt.SetParameterValue("@Preaviso", txtPreaviso.Text)
            ObjRpt.SetParameterValue("@CesantiaAntes", txtCensantiaAntes.Text)
            ObjRpt.SetParameterValue("@CesantiaDespues", txtCesantiaNuevo.Text)
            ObjRpt.SetParameterValue("@Vacaciones", txtVacaciones.Text)
            ObjRpt.SetParameterValue("@Subtotal", txtSubtotal.Text)
            ObjRpt.SetParameterValue("@Navidad", txtNavidad.Text)
            ObjRpt.SetParameterValue("@GranTotal", txtTotalRecibir.Text)

            LoadAnimation()


            lblStatusBar.Text = "Reporte en impresión..."
            Dim PrintDialog As New PrintDialog
            With PrintDialog
                .AllowSelection = True
                .AllowSomePages = True
                .AllowPrintToFile = True
            End With

            lblStatusBar.Text = "Visualizando el reporte..."
            Dim TmpForm = New frm_reportView
            TmpForm.Show(Me)
            TmpForm.CrystalViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
            TmpForm.CrystalViewer.ReportSource = ObjRpt
            TmpForm.CrystalViewer.Refresh()
            TmpForm.CrystalViewer.Cursor = Cursors.Default
            lblStatusBar.Text = "Listo"


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
End Class