Imports DevExpress.XtraGrid.Views.Grid

Public Class frm_articulos_nousados
    Dim TablaDatos As DataTable = New DataTable("Datos")
    Dim RepositorySeleccionar As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit() With {.Name = "Seleccionar"}
    Dim RepositoryID As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit() With {.LinkColor = SystemColors.Highlight}
    Private Sub frm_articulos_nousados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TablaDatos.Columns.Clear()

        TablaDatos.Clear()

        RepositorySeleccionar.Buttons(0).Caption = "Seleccionar"
        RepositorySeleccionar.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.OK
        RepositorySeleccionar.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        RepositorySeleccionar.LookAndFeel.UseDefaultLookAndFeel = False
        RepositorySeleccionar.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress)


        TablaDatos.Columns.Add("IDArticulo", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Descripcion", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Referencia", System.Type.GetType("System.String"))
        TablaDatos.Columns.Add("Seleccionar", System.Type.GetType("System.String"))

        GridControl1.DataSource = TablaDatos

        GridView1.Columns("IDArticulo").ColumnEdit = RepositoryID
        GridView1.Columns("IDArticulo").Caption = "Código del artículo"
        GridView1.Columns("IDArticulo").Width = 80
        GridView1.Columns("IDArticulo").OptionsColumn.AllowEdit = False
        GridView1.Columns("IDArticulo").OptionsColumn.ReadOnly = True
        GridView1.Columns("Descripcion").Caption = "Descripción"
        GridView1.Columns("Descripcion").Width = 405
        GridView1.Columns("Descripcion").OptionsColumn.AllowEdit = False
        GridView1.Columns("Descripcion").OptionsColumn.ReadOnly = True
        GridView1.Columns("Referencia").Width = 150
        GridView1.Columns("Referencia").OptionsColumn.AllowEdit = False
        GridView1.Columns("Referencia").OptionsColumn.ReadOnly = True
        GridView1.Columns("Seleccionar").ColumnEdit = RepositorySeleccionar

        RefrescarDatos()
    End Sub

    Private Sub RefrescarDatos()
        TablaDatos.Clear()

        Using ConMixta As MySqlConnection = New MySqlConnection(CnGeneral)
            Using myCommand As MySqlCommand = New MySqlCommand("Select IDArticulo,Descripcion,Referencia from Libregco.Articulos Where VecesVendido=0 and VecesComprado=0 ORDER BY RAND() LIMIT " & NumericUpDown1.Value.ToString, ConMixta)
                ConMixta.Open()

                Using myReader As MySqlDataReader = myCommand.ExecuteReader

                    TablaDatos.Load(myReader, LoadOption.Upsert)

                    ConMixta.Close()

                End Using
            End Using
        End Using

        TablaDatos.EndLoadData()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefrescarDatos()
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
        If e.RowHandle >= 0 Then
            If GridView1.FocusedColumn.FieldName = "Seleccionar" Then
                frm_mant_articulos.txtIDProducto.Text = GridView1.GetFocusedRow("IDArticulo").ToString
                frm_mant_articulos.FillAllDatafromID()

                frm_mant_articulos.chkDesactivar.Checked = False

                frm_mant_articulos.btNoUsedIDs.Tag = ""
                frm_mant_articulos.btNoUsedIDs.Text = ""

                frm_mant_articulos.btNoUsedIDs.Size = New Size(101, 18)
                frm_mant_articulos.btNoUsedIDs.Location = New Point(546, 145)
                Me.Close()

            ElseIf GridView1.FocusedColumn.FieldName = "IDArticulo" Then
                frm_mant_articulos.txtIDProducto.Text = GridView1.GetFocusedRow("IDArticulo").ToString
                frm_mant_articulos.FillAllDatafromID()

                frm_mant_articulos.chkDesactivar.Checked = False

                frm_mant_articulos.btNoUsedIDs.Tag = ""
                frm_mant_articulos.btNoUsedIDs.Text = ""

                frm_mant_articulos.btNoUsedIDs.Size = New Size(101, 18)
                frm_mant_articulos.btNoUsedIDs.Location = New Point(546, 145)

                Me.Close()
            End If
        End If
    End Sub

End Class