Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Public Class frm_buscar_tipo_documento

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Adaptador As MySqlDataAdapter
    Dim Ds, Ds1 As New DataSet

    Private Sub frm_buscar_tipo_documento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarEmpresa()
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
                cmd = New MySqlCommand("SELECT * FROM TipoDocumento where IDTipoDocumento like '%" + txtBuscar.Text + "%' ORDER BY IDTipoDocumento DESC", ConLibregco)
            ElseIf rdbDocumento.Checked = True Then
                cmd = New MySqlCommand("SELECT * FROM TipoDocumento where Documento like '%" + txtBuscar.Text + "%' ORDER BY Documento ASC", ConLibregco)
            End If

            Ds.Clear()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "TipoDocumento")

            Bs.DataMember = "TipoDocumento"
            Bs.DataSource = Ds
            BindingNavigator.BindingSource = Bs
            DgvConceptos.DataSource = Bs

            PropiedadColumnsDvg()

        Catch ex As Exception

        End Try
    End Sub

    Sub LimpiartxtBuscar()

        rdbDocumento.Checked = True
        txtBuscar.Clear()
        txtBuscar.Focus()

    End Sub

    Private Sub PropiedadColumnsDvg()
        With DgvConceptos
            .Columns(0).HeaderText = "Código"
            .Columns(0).Width = 115
            .Columns(1).Visible = False
            .Columns(2).Width = 350

        End With
    End Sub

    Private Sub rdbDocumento_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDocumento.CheckedChanged
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

    Private Sub DgvConceptos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvConceptos.CellClick
        If e.RowIndex >= 0 Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_Leave(sender As Object, e As EventArgs) Handles txtBuscar.Leave
        DgvConceptos.Focus()
    End Sub

    Private Sub DgvConceptos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DgvConceptos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LlenarFormularios()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DgvConceptos.Focus()
        End If
    End Sub

    Private Sub DgvConceptos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvConceptos.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                Dim NumCols As Integer = DgvConceptos.ColumnCount
                Dim NumRows As Integer = DgvConceptos.RowCount
                Dim CurCell As DataGridViewCell = DgvConceptos.CurrentCell
                If CurCell.ColumnIndex = NumCols - 1 Then
                    If CurCell.RowIndex < NumRows - 1 Then
                        DgvConceptos.CurrentCell = DgvConceptos.Item(0, CurCell.RowIndex + 1)
                    End If
                Else
                    DgvConceptos.CurrentCell = DgvConceptos.Item(CurCell.ColumnIndex + 1, CurCell.RowIndex)
                End If
                e.Handled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LlenarFormularios()
        Try
            Dim lblIDTipoDocumento As New Label
            lblIDTipoDocumento.Text = DgvConceptos.CurrentRow.Cells(0).Value

            Ds1.Clear()
            Con.Open()
            cmd = New MySqlCommand("Select * from TipoDocumento where IDTipoDocumento='" + lblIDTipoDocumento.Text + "'", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds1, "TipoDocumento")
            Con.Close()

            Dim Tabla As DataTable = Ds1.Tables("TipoDocumento")

            If Me.Owner.Name = frm_mant_tipo_documento.Name Then
                frm_mant_tipo_documento.txtIDTipoDocumento.Text = (Tabla.Rows(0).Item("IDTipoDocumento"))
                frm_mant_tipo_documento.txtTipoDocumento.Text = (Tabla.Rows(0).Item("Documento"))
                frm_mant_tipo_documento.txtLetra.Text = (Tabla.Rows(0).Item("Letra"))
                frm_mant_tipo_documento.txtRepeticiones.Text = (Tabla.Rows(0).Item("CantCharacter"))
                frm_mant_tipo_documento.txtUltimaSecuencia.Text = (Tabla.Rows(0).Item("UltimaSecuencia"))
                frm_mant_tipo_documento.txtCaracterRelleno.Text = (Tabla.Rows(0).Item("Filler"))
                frm_mant_tipo_documento.HacerMuestra()

                If (Tabla.Rows(0).Item("Nulo")) = 0 Then
                    frm_mant_tipo_documento.chkNulo.Checked = False
                Else
                    frm_mant_tipo_documento.chkNulo.Checked = True
                End If

                Close()
                Exit Sub
            End If

        Catch ex As Exception
        End Try
    End Sub

End Class