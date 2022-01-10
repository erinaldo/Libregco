Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_clase_documentos

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_clase_documentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarEmpresa()
        cmd = New MySqlCommand("SELECT * FROM ClaseAnexa ORDER BY Descripcion ASC", ConLibregco)
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub

    Private Sub CargarEmpresa()
       PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Bs As New BindingSource

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "ClaseAnexa")

            Bs.DataMember = "ClaseAnexa"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvClases.DataSource = Bs

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
        With DgvClases
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Descripción"
            .Columns(1).Width = 305
            .Columns(2).Visible = False
        End With
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Focus()

        If rdbCodigo.Checked = False Then
            txtBuscar.Clear()
            RefrescarTabla()
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged

        If txtBuscar.Text = "" Then
            cmd = New MySqlCommand("SELECT * FROM ClaseAnexa ORDER BY Descripcion ASC", ConLibregco)
            RefrescarTabla()
            Exit Sub
        End If

        If rdbCodigo.Checked = True Then
            cmd = New MySqlCommand("SELECT * FROM ClaseAnexa where IDClaseAnexa like '%" + txtBuscar.Text + "%' ORDER BY IDClaseAnexa DESC", ConLibregco)

        ElseIf rdbDescripcion.Checked = True Then
            cmd = New MySqlCommand("SELECT * FROM ClaseAnexa where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion ASC", ConLibregco)
        End If

        RefrescarTabla()
    End Sub

    Private Sub rdbDescripcion_CheckedChanged(sender As Object, e As EventArgs)
        txtBuscar.Focus()

        If rdbDescripcion.Checked = False Then
            txtBuscar.Clear()
            RefrescarTabla()
        End If
    End Sub

    Private Sub DgvCategorias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvClases.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvClases.Focus()
    End Sub

    Private Sub DgvClases_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvClases.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvClases.Focus()
        End If
    End Sub

    Private Sub DgvClases_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvClases.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvClases.ColumnCount
                Dim NumRows As Integer = DgvClases.RowCount
                Dim CurCell As DataGridViewCell = DgvClases.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvClases.CurrentCell = DgvClases.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvClases.CurrentCell = DgvClases.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            If Me.Owner.Name = frm_mant_clase_documentos.Name Then
                frm_mant_clase_documentos.txtIDClase.Text = DgvClases.CurrentRow.Cells(0).Value
                frm_mant_clase_documentos.txtClaseDocumento.Text = DgvClases.CurrentRow.Cells(1).Value
                If DgvClases.CurrentRow.Cells(2).Value = 0 Then
                    frm_mant_clase_documentos.chkNulo.Checked = False
                Else
                    frm_mant_clase_documentos.chkNulo.Checked = True
                End If
            End If

            Close()
            Exit Sub

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub


End Class