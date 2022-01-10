Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_grupo_ingreso_deducciones

    Dim sqlQ As String=""
    Dim cmd, cmd1 As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_grupo_ingreso_deducciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDeduccionesProcesadas,SecondID,Fecha,Hora FROM deduccionesprocesadas where SecondID like '%" + txtBuscar.Text + "%' ORDER BY IDeduccionesProcesadas DESC", Con)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Deduccion")

            Bs.DataMember = "Deduccion"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvDeducciones.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()
        rdbCodigo.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        DgvDeducciones.Columns(0).Visible = False
        DgvDeducciones.Columns(1).HeaderText = "Código"
        DgvDeducciones.Columns(1).Width = 240
        DgvDeducciones.Columns(2).Width = 200
        DgvDeducciones.Columns(2).HeaderText = "Fecha"
        DgvDeducciones.Columns(3).Width = 200
        DgvDeducciones.Columns(3).HeaderText = "Hora"
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvDeducciones_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDeducciones.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvDeducciones.Focus()
    End Sub


    Private Sub LlenarFormularios()
        Dim IDDeduccionProcesada As New Label
        IDDeduccionProcesada.Text = DgvDeducciones.CurrentRow.Cells(0).Value
        Try

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDeduccionesProcesadas,SecondID,Fecha,Hora,Nulo,Impreso FROM deduccionesprocesadas Where deduccionesprocesadas.IDeduccionesProcesadas='" + IDDeduccionProcesada.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "DeduccionesProcesadas")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("DeduccionesProcesadas")

            If Me.Owner.Name = frm_registro_ingresos_deducciones.Name Then
                frm_registro_ingresos_deducciones.txtIDDeduccionProc.Text = (Tabla.Rows(0).Item("IDeduccionesProcesadas"))
                frm_registro_ingresos_deducciones.txtSecondID.Text = (Tabla.Rows(0).Item("SecondID"))
                frm_registro_ingresos_deducciones.txtFechaPago.Text = CDate(Tabla.Rows(0).Item("Fecha")).ToString("yyyy-MM-dd")
                'frm_registro_ingresos_deducciones.txtHora.Text = Convert.ToString(Tabla.Rows(0).Item("Hora")).ToString("HH:mm:ss")

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_registro_ingresos_deducciones.chkNulo.Checked = False
                Else
                    frm_registro_ingresos_deducciones.chkNulo.Checked = True
                End If

                frm_registro_ingresos_deducciones.RefrescarDeducciones()

            ElseIf Me.Owner.Name = frm_reporte_deducciones.Name Then
                frm_reporte_deducciones.txtIDRegistro.Text = DgvDeducciones.CurrentRow.Cells(0).Value
                frm_reporte_deducciones.txtRegistroDeduccion.Text = DgvDeducciones.CurrentRow.Cells(1).Value
            End If

            Close()
            Exit Sub


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try

    End Sub

    Private Sub DgvDeducciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvDeducciones.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvDeducciones.Focus()
        End If
    End Sub

    Private Sub frm_buscar_clientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LimpiartxtBuscar()
    End Sub

    Private Sub DgvDeducciones_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvDeducciones.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim NumCols As Integer = DgvDeducciones.ColumnCount
            Dim NumRows As Integer = DgvDeducciones.RowCount
            Dim CurCell As DataGridViewCell = DgvDeducciones.CurrentCell
            If CurCell.ColumnIndex = NumCols - 1 Then
                If CurCell.RowIndex < NumRows - 1 Then
                    DgvDeducciones.CurrentCell = DgvDeducciones.Item(0, CurCell.RowIndex + 1)
                End If
            Else
                DgvDeducciones.CurrentCell = DgvDeducciones.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
            End If
            e.Handled = True
        End If

    End Sub
End Class