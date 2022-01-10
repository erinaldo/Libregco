Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_buscar_afp
    '
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet

    Private Sub frm_buscar_afp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                cmd = New MySqlCommand("SELECT IDAFP,Descripcion,Direccion,Telefono,Nulo from AFP Where IDAFP like '%" + txtBuscar.Text + "%' ORDER BY IDAFP DESC", ConLibregco)
            ElseIf rdbDescripcion.Checked = True Then
                cmd = New MySqlCommand("SELECT IDAFP,Descripcion,Direccion,Telefono,Nulo from AFP Where Descripcion like '%" + txtBuscar.Text + "%' ORDER BY Descripcion DESC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "AFP")

            Bs.DataMember = "AFP"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvAFP.DataSource = Bs

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
        With DgvAFP
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 80
            .Columns(1).HeaderText = "Descripción"
            .Columns(1).Width = 340
            .Columns(2).Visible = False
            .Columns(3).HeaderText = "Teléfono"
            .Columns(3).Width = 100
            .Columns(4).Visible = False
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

    Private Sub DgvAFP_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvAfp.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvAFP.Focus()
    End Sub

    Private Sub DgvAFP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvAfp.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvAFP.Focus()
        End If
    End Sub

    Private Sub DgvAFP_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvAfp.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvAFP.ColumnCount
                Dim NumRows As Integer = DgvAFP.RowCount
                Dim CurCell As DataGridViewCell = DgvAFP.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvAFP.CurrentCell = DgvAFP.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvAFP.CurrentCell = DgvAFP.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try

            If Me.Owner.Name = frm_mant_afp.Name Then
                frm_mant_afp.txtIDAfp.Text = DgvAfp.CurrentRow.Cells(0).Value
                frm_mant_afp.txtAFP.Text = DgvAfp.CurrentRow.Cells(1).Value
                frm_mant_afp.txtDireccion.Text = DgvAfp.CurrentRow.Cells(2).Value
                frm_mant_afp.txtTelefono.Text = DgvAfp.CurrentRow.Cells(3).Value
                FillChkBox()

            ElseIf Me.Owner.Name = frm_mant_empleados.Name Then
                frm_mant_empleados.txtIDAfp.Text = DgvAfp.CurrentRow.Cells(0).Value
                frm_mant_empleados.txtAfp.Text = DgvAfp.CurrentRow.Cells(1).Value

            ElseIf Me.Owner.Name = frm_reporte_empleados.Name Then
                frm_reporte_empleados.txtIDAfp.Text = DgvAfp.CurrentRow.Cells(0).Value
                frm_reporte_empleados.txtAFP.Text = DgvAfp.CurrentRow.Cells(1).Value

            End If
            Close()

        Catch ex As Exception

      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub FillChkBox()
        If DgvAFP.CurrentRow.Cells(4).Value = 0 Then
            frm_mant_AFP.chkNulo.Checked = False
        Else
            frm_mant_AFP.chkNulo.Checked = True
        End If
    End Sub



End Class