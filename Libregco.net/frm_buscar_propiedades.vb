Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_buscar_propiedades
    Dim sqlQ As String = ""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_propiedades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDArticulos_propiedad,Propiedad,NotaPropiedad,PropiedadImagen,Nulo FROM articulos_propiedad where IDArticulos_propiedad like '%" + txtBuscar.Text + "%' and IDParent is NULL ORDER BY IDArticulos_propiedad ASC", ConLibregco)
            ElseIf rdbSubCategoria.Checked = True Then
                cmd = New MySqlCommand("SELECT IDArticulos_propiedad,Propiedad,NotaPropiedad,PropiedadImagen,Nulo FROM articulos_propiedad where Propiedad like '%" + txtBuscar.Text + "%' and IDParent is NULL ORDER BY Propiedad ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Propiedades")

            Bs.DataMember = "Propiedades"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvPropiedades.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try

    End Sub


    Sub LimpiartxtBuscar()
        rdbSubCategoria.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()
    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvPropiedades
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 70
            .Columns(1).HeaderText = "Propiedades"
            .Columns(1).Width = 220
            .Columns(2).HeaderText = "Descripción"
            .Columns(2).Width = 240
            .Columns(2).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .Columns(2).DefaultCellStyle.ForeColor = Color.DarkGray
            .Columns(3).Visible = False
            .Columns(4).Visible = False
        End With
    End Sub


    Private Sub LlenarFormularios()
        'Try
        If Me.Owner.Name = frm_propiedades.Name Then
            frm_propiedades.IsLimitedByFilter = True
            frm_propiedades.isParenttoFilter = DgvPropiedades.CurrentRow.Cells(0).Value
            frm_propiedades.FillPropiedadesLimitada
            frm_propiedades.PopulateLimitada()

        End If

            Close()
            Exit Sub

        'Catch ex As Exception
        '    InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try

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

    Private Sub DgvSubCategoria_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPropiedades.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvPropiedades.Focus()
    End Sub


    Private Sub DgvSubCategoria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvPropiedades.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvPropiedades.Focus()
        End If
    End Sub

    Private Sub DgvSubCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvPropiedades.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.Handled = True
            End If
            'If e.KeyCode = Keys.Enter Then
            '    Dim NumCols As Integer = DgvSubCategoria.ColumnCount
            '    Dim NumRows As Integer = DgvSubCategoria.RowCount
            '    Dim CurCell As DataGridViewCell = DgvSubCategoria.CurrentCell
            '    If CurCell.ColumnIndex = NumCols - 1 Then
            '        If CurCell.RowIndex < NumRows - 1 Then
            '            DgvSubCategoria.CurrentCell = DgvSubCategoria.Item(0, CurCell.RowIndex + 1)
            '        End If
            '    Else
            '        DgvSubCategoria.CurrentCell = DgvSubCategoria.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
            '    End If
            '    e.Handled = True
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm_buscar_subcategorias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        txtBuscar.Focus()
    End Sub

End Class