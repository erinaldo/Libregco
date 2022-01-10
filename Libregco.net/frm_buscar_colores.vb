Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_buscar_colores
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds As New DataSet
    Dim Connon As New MySqlConnection(CnString)
    Dim PictureColumn As New DataGridViewImageColumn

    Private Sub frm_buscar_colores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        RefrescarTabla()
        LimpiartxtBuscar()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub RefrescarTabla()
        Try
            Dim Img As Image
            Dim wFile As System.IO.FileStream

            DgvColor.Rows.Clear()

            ConLibregco.Open()

            Dim SqlConsulta As New MySqlCommand
            If rdbCodigo.Checked = True Then
                SqlConsulta.CommandText = "SELECT IDColor,Color,BigColorPath FROM Color where IDColor like '%" + txtBuscar.Text + "%' ORDER BY IDColor DESC"
                SqlConsulta.Connection = ConLibregco
            ElseIf rdbColor.Checked = True Then
                SqlConsulta.CommandText = "SELECT IDColor,Color,BigColorPath FROM Color where Color like '%" + txtBuscar.Text + "%' ORDER BY Color ASC"
                SqlConsulta.Connection = ConLibregco
            End If

            Dim LectorColor As MySqlDataReader = SqlConsulta.ExecuteReader

            While LectorColor.Read
                Dim ExistFile As Boolean = System.IO.File.Exists(LectorColor.GetValue(2))

                If ExistFile = True Then
                    wFile = New FileStream(LectorColor.GetValue(2), FileMode.Open, FileAccess.Read)
                    Img = System.Drawing.Image.FromStream(wFile)
                    wFile.Close()
                Else
                    Img = My.Resources.No_Image
                End If

                DgvColor.Rows.Add(LectorColor.GetValue(0), LectorColor.GetValue(1), LectorColor.GetValue(2), Img)
            End While

            LectorColor.Close()
            ConLibregco.Close()

            DgvColor.ClearSelection()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbColor.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub rdbColor_CheckedChanged(sender As Object, e As EventArgs) Handles rdbColor.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub rdbCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbCodigo.CheckedChanged
        txtBuscar.Focus()
        RefrescarTabla()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        RefrescarTabla()
    End Sub

    Private Sub DgvColor_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvColor.CellDoubleClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvColor.Focus()
    End Sub

    Private Sub DgvColor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvColor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvColor.Focus()
        End If
    End Sub

    Private Sub DgvColor_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvColor.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvColor.ColumnCount
                Dim NumRows As Integer = DgvColor.RowCount
                Dim CurCell As DataGridViewCell = DgvColor.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvColor.CurrentCell = DgvColor.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvColor.CurrentCell = DgvColor.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        'Try
        If Me.Owner.Name = frm_mant_articulos.Name Then
            frm_mant_articulos.lblColorName.Text = DgvColor.CurrentRow.Cells(1).Value
            frm_mant_articulos.PColor.Tag = DgvColor.CurrentRow.Cells(0).Value
            ConseguirSubColores()

            Close()

        ElseIf Me.Owner.Name = frm_colores.Name Then

            If frm_colores.CallerColor = 0 Then
                frm_colores.txtIDColor.Text = DgvColor.CurrentRow.Cells(0).Value
                frm_colores.txtDescrip.Text = DgvColor.CurrentRow.Cells(1).Value
                frm_colores.DgvColoresDetallados.Rows.Clear()

                For Each Rw As DataGridViewRow In DgvColoresDetallados.Rows
                    frm_colores.DgvColoresDetallados.Rows.Add(Rw.Cells(0).Value, Rw.Cells(1).Value, Rw.Cells(2).Value)
                    frm_colores.DgvColoresDetallados.Rows(Rw.Index).Cells(3).Style.BackColor = Color.FromArgb(DgvColoresDetallados.Rows(Rw.Index).Cells(2).Value)
                Next

                frm_colores.ConseguirSubColores()


                Close()
            End If



        End If

        'Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd= Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        'End Try

    End Sub

    Private Sub ConseguirSubColores()
        frm_mant_articulos.PColor.Controls.Clear()

        Dim xLoc As Double = 0
        Dim WidhtS As Double = CInt(frm_mant_articulos.PColor.Width / DgvColoresDetallados.Rows.Count)

        For Each rw As DataGridViewRow In DgvColoresDetallados.Rows
            Dim CPanel As New Panel
            With CPanel
                .BackColor = Color.FromArgb(rw.Cells(2).Value)
                .Name = Now.ToString("yyyyMMddHHmmss")
                .Location = New Point(xLoc, 0)
                .Size = New Size(WidhtS, frm_mant_articulos.PColor.Height)
            End With

            frm_mant_articulos.PColor.Controls.Add(CPanel)
            xLoc = xLoc + WidhtS
        Next

    End Sub

    Private Sub DgvColor_SelectionChanged(sender As Object, e As EventArgs) Handles DgvColor.SelectionChanged
        If DgvColor.SelectedRows.Count > 0 Then

            DgvColoresDetallados.Rows.Clear()
            Connon.Open()
            Dim Consulta As New MySqlCommand("SELECT IDColor_Detalle,ColorName,ColorDetalleARGB FROM libregco.color_detalle where IDColor='" + DgvColor.CurrentRow.Cells(0).Value.ToString + "' Order by Orden ASC", Connon)
            Dim LectorColor As MySqlDataReader = Consulta.ExecuteReader

            While LectorColor.Read
                DgvColoresDetallados.Rows.Add(LectorColor.GetValue(0), LectorColor.GetValue(1), LectorColor.GetValue(2))
            End While
            LectorColor.Close()
            Connon.Close()

            For Each rw As DataGridViewRow In DgvColoresDetallados.Rows
                DgvColoresDetallados.Rows(rw.Index).Cells(3).Style.BackColor = Color.FromArgb(DgvColoresDetallados.Rows(rw.Index).Cells(2).Value)

            Next

            DgvColoresDetallados.ClearSelection()
        End If


    End Sub

    Private Sub DgvColoresDetallados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvColoresDetallados.CellClick
        If e.RowIndex >= 0 Then
            If Me.Owner.Name = frm_colores.Name Then
                If frm_colores.CallerColor = 1 Then

                    frm_colores.txtNombreColor.Text = DgvColoresDetallados.CurrentRow.Cells(1).Value
                    frm_colores.CPEColor.Color = Color.FromArgb(DgvColoresDetallados.CurrentRow.Cells(2).Value)
                    frm_colores.btnAgregarColor.PerformClick()
                    Me.Close()
                End If

            End If
        End If
    End Sub
End Class