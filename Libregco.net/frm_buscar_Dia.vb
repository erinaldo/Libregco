Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frm_buscar_Dia
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_Dia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            If rdbDia.Checked = True Then
                cmd = New MySqlCommand("SELECT idDia,Celebracion,Dia FROM diasespeciales where IDDia like '%" + txtBuscar.Text + "%' ORDER BY IDDia DESC", ConLibregco)
            ElseIf rdbCelebracion.Checked = True Then
                cmd = New MySqlCommand("SELECT idDia,Celebracion,Dia FROM diasespeciales where Celebracion like '%" + txtBuscar.Text + "%' ORDER BY Dia ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Dias")

            Bs.DataMember = "Dias"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvDias.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Sub LimpiartxtBuscar()

        rdbCelebracion.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvDias
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 90
            .Columns(1).Width = 240
            .Columns(1).HeaderText = "Celebración"
            .Columns(2).Width = 100
            .Columns(2).HeaderText = "Día"
        End With
    End Sub

    Private Sub rdbDia_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDia.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub rdbCelebracion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCelebracion.CheckedChanged
        RefrescarTabla()
        txtBuscar.Focus()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvDias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDias.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvDias.Focus()
    End Sub

    Private Sub DgvDias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvDias.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvDias.Focus()
        End If
    End Sub

    Private Sub DgvProvincias_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvDias.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvDias.ColumnCount
                Dim NumRows As Integer = DgvDias.RowCount
                Dim CurCell As DataGridViewCell = DgvDias.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvDias.CurrentCell = DgvDias.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvDias.CurrentCell = DgvDias.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim IDDia As New Label
            Dim Ds1 As New DataSet

            IDDia.Text = DgvDias.CurrentRow.Cells(0).Value

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT IDDia,Dia,Celebracion,Laborable,IDMotivo,Estado,Nulo FROM libregco.diasespeciales where IDDia= '" + IDDia.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "Dia")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("Dia")


            If Me.Owner.Name = frm_mant_dias_esp.Name Then
                frm_mant_dias_esp.txtIDDia.Text = Tabla.Rows(0).Item("IDDia")
                frm_mant_dias_esp.dtpDia.Value = CDate(Convert.ToDateTime(Tabla.Rows(0).Item("Dia")))
                frm_mant_dias_esp.txtCelebracion.Text = Tabla.Rows(0).Item("Celebracion")
                frm_mant_dias_esp.txtEstado.Text = Tabla.Rows(0).Item("Estado")

                If Tabla.Rows(0).Item("Laborable") = 0 Then
                    frm_mant_dias_esp.TSLaborable.IsOn = False
                    frm_mant_dias_esp.TSLaborable.Tag = 0
                Else
                    frm_mant_dias_esp.TSLaborable.IsOn = True
                    frm_mant_dias_esp.TSLaborable.Tag = 1
                End If


                If Tabla.Rows(0).Item("IDMotivo") = 1 Then
                    frm_mant_dias_esp.rdbPatrio.Checked = True
                ElseIf Tabla.Rows(0).Item("IDMotivo") = 2 Then
                    frm_mant_dias_esp.rdbReligioso.Checked = True
                ElseIf Tabla.Rows(0).Item("IDMotivo") = 3 Then
                    frm_mant_dias_esp.rdbCultural.Checked = True
                End If
                frm_mant_dias_esp.GroupBox2.Tag = Tabla.Rows(0).Item("IDMotivo")

                If Tabla.Rows(0).Item("Nulo") = 0 Then
                    frm_mant_dias_esp.chkNulo.Checked = False
                    frm_mant_dias_esp.chkNulo.Tag = 0
                Else
                    frm_mant_dias_esp.chkNulo.Checked = True
                    frm_mant_dias_esp.chkNulo.Tag = 1
                End If

                Close()

            End If



        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub
End Class