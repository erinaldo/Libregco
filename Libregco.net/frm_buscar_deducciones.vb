Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_deducciones

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_deducciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDDeduccion,Deducciones.Descripcion,Deducciones.IDTipoFuncion,Porciento,Deducciones.Nulo,TipoFuncion.Descripcion FROM" & SysName.Text & "deducciones INNER JOIN Libregco.Tipofuncion on Deducciones.IDTipoFuncion=TipoFuncion.IDTipoFuncion WHERE IDDeduccion like '%" + txtBuscar.Text + "%' ORDER BY IDDeduccion ASC", ConMixta)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDDeduccion,Deducciones.Descripcion,Deducciones.IDTipoFuncion,Porciento,Deducciones.Nulo,TipoFuncion.Descripcion FROM" & SysName.Text & "deducciones INNER JOIN Libregco.Tipofuncion on Deducciones.IDTipoFuncion=TipoFuncion.IDTipoFuncion where Deducciones.Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Deducciones.Descripcion DESC", ConMixta)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Deducciones")

            Bs.DataMember = "Deducciones"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvDeduccion.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbDescripcion.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvDeduccion
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 100
            .Columns(1).Width = 305
            .Columns(1).HeaderText = "Descripción"
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False
        End With
    End Sub

    Private Sub rdbDescripcion_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDescripcion.CheckedChanged
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

    Private Sub DgvDeduccion_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvDeduccion.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvDeduccion.Focus()
    End Sub

    Private Sub DgvDeduccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvDeduccion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvDeduccion.Focus()
        End If
    End Sub

    Private Sub DgvDeduccion_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvDeduccion.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvDeduccion.ColumnCount
                Dim NumRows As Integer = DgvDeduccion.RowCount
                Dim CurCell As DataGridViewCell = DgvDeduccion.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvDeduccion.CurrentCell = DgvDeduccion.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvDeduccion.CurrentCell = DgvDeduccion.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_ing_dec.Name Then
                frm_mant_ing_dec.txtIDDeduccion.Text = DgvDeduccion.CurrentRow.Cells(0).Value
                frm_mant_ing_dec.txtDescripcion.Text = DgvDeduccion.CurrentRow.Cells(1).Value
                frm_mant_ing_dec.lblIDFuncion.Text = DgvDeduccion.CurrentRow.Cells(2).Value
                frm_mant_ing_dec.txtPorcentaje.Text = CDbl(DgvDeduccion.CurrentRow.Cells(3).Value).ToString("P2")
                frm_mant_ing_dec.lblNulo.Text = DgvDeduccion.CurrentRow.Cells(4).Value
                frm_mant_ing_dec.CbxFuncion.Text = DgvDeduccion.CurrentRow.Cells(5).Value
                FillChkBox()
            End If

            Close()
            Exit Sub
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillChkBox()
        If frm_mant_ing_dec.Visible = True Then
            If frm_mant_ing_dec.lblNulo.Text = 1 Then
                frm_mant_ing_dec.ChkNulo.Checked = True
            Else
                frm_mant_ing_dec.ChkNulo.Checked = False
            End If
        End If
    End Sub
End Class