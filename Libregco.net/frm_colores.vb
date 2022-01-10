Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer
Imports System.Drawing.Printing

Public Class frm_colores
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList
    Private fromIndex As Integer
    Private dragIndex As Integer
    Private dragRect As Rectangle
    Friend IDDetalleColor As String = ""
    Friend CallerColor As Integer
    Private Sub frm_colores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        LimpiarDatos()
        Permisos = PasarPermisos(Me.Tag)
    End Sub
    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub LimpiarDatos()
        txtIDColor.Clear()
        txtDescrip.Clear()
        txtNombreColor.Clear()
        DgvColoresDetallados.Rows.Clear()
        CPEColor.Reset()
        Panel1.Controls.Clear()
        CPEColor.Color = Color.White
        chkNulo.Checked = False
        chkNulo.Tag = 0
        IDDetalleColor = ""
        LabelStatus.Text = "Listo"
    End Sub


    Private Sub btnAgregarColor_Click(sender As Object, e As EventArgs) Handles btnAgregarColor.Click
        If txtNombreColor.Text = "" Then
            MessageBox.Show("Haga una breve descripción del nombre del color que desea insertar.", "Descripción del color", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNombreColor.Focus()
            Exit Sub
        End If

        DgvColoresDetallados.Rows.Add(IDDetalleColor, txtNombreColor.Text, CPEColor.Color.ToArgb.ToString)

        CPEColor.Color = Color.White
        txtNombreColor.Text = ""
        IDDetalleColor = ""

        For Each rw As DataGridViewRow In DgvColoresDetallados.Rows
            DgvColoresDetallados.Rows(rw.Index).Cells(3).Style.BackColor = Color.FromArgb(DgvColoresDetallados.Rows(rw.Index).Cells(2).Value)
        Next

        ConseguirSubColores()

        CPEColor.Focus()
        DgvColoresDetallados.ClearSelection()
    End Sub

    Sub ConseguirSubColores()
        If DgvColoresDetallados.Rows.Count > 0 Then
            Panel1.Controls.Clear()

            Dim xLoc As Double = 0
            Dim WidhtS As Double = CInt(Panel1.Width / DgvColoresDetallados.Rows.Count)

            For Each rw As DataGridViewRow In DgvColoresDetallados.Rows
                Dim CPanel As New Panel
                With CPanel
                    .BackColor = Color.FromArgb(rw.Cells(2).Value)
                    .Name = Now.ToString("yyyyMMddHHmmss")
                    .Location = New Point(xLoc, 0)
                    .Size = New Size(WidhtS, Panel1.Height)
                End With

                Panel1.Controls.Add(CPanel)
                xLoc = xLoc + WidhtS
            Next

            DgvColoresDetallados.ClearSelection()
        End If

    End Sub

    Private Sub btnNuevoColor_Click(sender As Object, e As EventArgs) Handles btnNuevoColor.Click
        CPEColor.Color = Color.White
        txtNombreColor.Clear()
    End Sub

    Private Sub btnBuscarColro_Click(sender As Object, e As EventArgs) Handles btnBuscarColro.Click
        CallerColor = 1
        frm_buscar_colores.ShowDialog(Me)
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarDatos()
    End Sub

    Private Sub DgvColoresDetallados_DragDrop(sender As Object, e As DragEventArgs) Handles DgvColoresDetallados.DragDrop
        Dim p As Point = DgvColoresDetallados.PointToClient(New Point(e.X, e.Y))

        dragIndex = DgvColoresDetallados.HitTest(p.X, p.Y).RowIndex

        If dragIndex > -1 Then
            If (e.Effect = DragDropEffects.Move) Then
                Dim dragRow As DataGridViewRow = e.Data.GetData(GetType(DataGridViewRow))
                DgvColoresDetallados.Rows.RemoveAt(fromIndex)
                DgvColoresDetallados.Rows.Insert(dragIndex, dragRow)
                ConseguirSubColores()
            End If
        End If

    End Sub

    Private Sub DgvColoresDetallados_DragOver(sender As Object, e As DragEventArgs) Handles DgvColoresDetallados.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub DgvColoresDetallados_MouseDown(sender As Object, e As MouseEventArgs) Handles DgvColoresDetallados.MouseDown
        fromIndex = DgvColoresDetallados.HitTest(e.X, e.Y).RowIndex
        If fromIndex > -1 Then
            Dim dragSize As Size = SystemInformation.DragSize
            dragRect = New Rectangle(New Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)

        Else
            dragRect = Rectangle.Empty
        End If

        DgvColoresDetallados.Cursor = Cursors.Default
    End Sub

    Private Sub DgvColoresDetallados_MouseMove(sender As Object, e As MouseEventArgs) Handles DgvColoresDetallados.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            If (dragRect <> Rectangle.Empty AndAlso Not dragRect.Contains(e.X, e.Y)) Then
                DgvColoresDetallados.DoDragDrop(DgvColoresDetallados.Rows(fromIndex), DragDropEffects.Move)
                DgvColoresDetallados.Cursor = Cursors.Default
            End If
        End If
    End Sub


    Private Sub DgvColoresDetallados_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles DgvColoresDetallados.GiveFeedback
        e.UseDefaultCursors = False

        If e.Effect And DragDropEffects.Move = DragDropEffects.Move Then
            Dim DgvSz As Size = DgvColoresDetallados.ClientSize
            Dim Rw As Integer = DgvColoresDetallados.SelectedRows(0).Index
            Dim RowRect As Rectangle = DgvColoresDetallados.GetRowDisplayRectangle(Rw, True)

            Using bmpDgv As Bitmap = New Bitmap(DgvSz.Width, DgvSz.Height)

                Using bmprow As Bitmap = New Bitmap(RowRect.Width, RowRect.Height)
                    DgvColoresDetallados.DrawToBitmap(bmpDgv, New Rectangle(Point.Empty, DgvSz))

                    Using g As Graphics = Graphics.FromImage(bmprow)
                        g.DrawImage(bmpDgv, New Rectangle(Point.Empty, RowRect.Size), RowRect, GraphicsUnit.Pixel)
                    End Using

                    Dim Cur As Cursor = New Cursor(bmprow.GetHicon())
                    DgvColoresDetallados.Cursor = Cur

                End Using
            End Using
        End If
    End Sub

    Private Sub DgvColoresDetallados_MouseUp(sender As Object, e As MouseEventArgs) Handles DgvColoresDetallados.MouseUp
        DgvColoresDetallados.Cursor = Cursors.Default
    End Sub

    Private Sub DgvColoresDetallados_Leave(sender As Object, e As EventArgs) Handles DgvColoresDetallados.Leave
        DgvColoresDetallados.Cursor = Cursors.Default
    End Sub

    Private Sub DgvColoresDetallados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvColoresDetallados.CellDoubleClick
        If e.RowIndex >= 0 Then
            IDDetalleColor = DgvColoresDetallados.CurrentRow.Cells(0).Value
            txtNombreColor.Text = DgvColoresDetallados.CurrentRow.Cells(1).Value
            CPEColor.Color = Color.FromArgb(DgvColoresDetallados.CurrentRow.Cells(2).Value)

            DgvColoresDetallados.Rows.Remove(DgvColoresDetallados.CurrentRow)

            ConseguirSubColores()

            DgvColoresDetallados.ClearSelection()
        End If
    End Sub

    Private Sub txtDescrip_Leave(sender As Object, e As EventArgs) Handles txtDescrip.Leave
        CPEColor.Focus()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CallerColor = 0
        frm_buscar_colores.ShowDialog(Me)
    End Sub

    Private Sub btnGuardarC_Click(sender As Object, e As EventArgs) Handles btnGuardarC.Click
        If txtDescrip.Text = "" Then
            MessageBox.Show("Escriba el nombre del grupo de colores a guardar.", "Nombre del grupo de colores", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            txtDescrip.Focus()
            Exit Sub

        ElseIf DgvColoresDetallados.Rows.Count = 0 Then
            MessageBox.Show("Inserte al menos un color para guardar el grupo de colores.", "No hay colores insertados", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CPEColor.Focus()
            Exit Sub
        End If

        If txtIDColor.Text = "" Then
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            sqlQ = "INSERT INTO Color (Color,BigColorPath,Nulo) VALUES ('" + txtDescrip.Text + "', '','" + chkNulo.Tag.ToString + "')"
            GuardarDatos()
            UltColor()
            GuardarSubColores()
            GenerateImageColor()
            LabelStatus.Text = "Se ha guardado el grupo de colores satisfactoriamente."

        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            sqlQ = "UPDATE Color SET Color='" + txtDescrip.Text + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDColor=(" + txtIDColor.Text + ")"
            GuardarDatos()
            GuardarSubColores()
            GenerateImageColor()
            LabelStatus.Text = "Los cambios se realizaron satisfactoriamente."

        End If
    End Sub

    Private Sub GenerateImageColor()
        Panel1.BorderStyle = BorderStyle.None
        Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Colors")
        If Exists = False Then
            System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Colors")
        End If

        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Colors\" & "GP" & txtIDColor.Text & ".png"

        If System.IO.Directory.Exists(RutaDestino) = True Then
            My.Computer.FileSystem.DeleteFile(RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

        Else
            TakeScreenShot(Panel1).Save(RutaDestino, System.Drawing.Imaging.ImageFormat.Png)
        End If
        Panel1.BorderStyle = BorderStyle.FixedSingle

        sqlQ = "UPDATE Color SET BigColorPath='" + Replace(RutaDestino, "\", "\\") + "' WHERE IDColor=(" + txtIDColor.Text + ")"
        GuardarDatos()
    End Sub

    Private Sub GuardarSubColores()
        Try
            ConLibregco.Open()

            For Each Rw As DataGridViewRow In DgvColoresDetallados.Rows
            If CStr(Rw.Cells(0).Value) = "" Then
                sqlQ = "INSERT INTO Libregco.Color_detalle (IDColor,ColorName,ColorDetalleARGB,ColorDetalleFilePath,Orden) VALUES ('" + txtIDColor.Text + "','" + Rw.Cells(1).Value.ToString + "','" + Rw.Cells(2).Value.ToString + "','','" + Rw.Index.ToString + "')"
                cmd = New MySqlCommand(sqlQ, ConLibregco)
                cmd.ExecuteNonQuery()

                cmd = New MySqlCommand("Select idColor_detalle from Color_detalle where idColor_detalle=(Select Max(idColor_detalle) from Color_detalle)", ConLibregco)
                Rw.Cells(0).Value = Convert.ToDouble(cmd.ExecuteScalar())
            Else

                sqlQ = "UPDATE Libregco.Color_detalle SET IDColor='" + txtIDColor.Text + "',ColorName='" + Rw.Cells(1).Value.ToString + "',ColorDetalleARGB='" + Rw.Cells(2).Value.ToString + "',ColorDetalleFilePath='',Orden='" + Rw.Index.ToString + "' WHERE IDColor_detalle= (" + Rw.Cells(0).Value.ToString + ")"
                cmd = New MySqlCommand(sqlQ, ConLibregco)
                cmd.ExecuteNonQuery()

            End If

        Next
            ConLibregco.Close()

        Catch ex As Exception
        'InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "CMD Text: " & If(cmd.CommandText = Nothing, "", cmd.CommandText.ToString) & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub
    Private Sub UltColor()
        Try

            If txtIDColor.Text = "" Then
                ConLibregco.Open()
                cmd = New MySqlCommand("Select IDColor from Color where IDColor=(Select Max(IDColor) from Color)", ConLibregco)
                txtIDColor.Text = Convert.ToString(cmd.ExecuteScalar())
                ConLibregco.Close()
            End If

        Catch ex As Exception
            ConLibregco.Close()

      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)

        End Try
    End Sub

    Private Sub GuardarDatos()
        Try
            ConLibregco.Open()
            cmd = New MySqlCommand(sqlQ, ConLibregco)
            cmd.ExecuteNonQuery()
            ConLibregco.Close()

        Catch ex As Exception
            ConLibregco.Close()
            MessageBox.Show(ex.Message & " Desde Guardar Datos")
        End Try
    End Sub

    Private Sub chkNulo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNulo.CheckedChanged
        If chkNulo.Checked = True Then
            chkNulo.Tag = 1
        Else
            chkNulo.Tag = 0
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Permisos(2) = 0 Then
            MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkNulo.Checked = True Then
            Dim Result1 As MsgBoxResult = MessageBox.Show("El grupo de colores ya está anulada en el sistema. Desea activarla?", "Recuperar grupo de colores", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result1 = MsgBoxResult.Yes Then
                chkNulo.Checked = False
                sqlQ = "UPDATE Color SET Color='" + txtDescrip.Text + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDColor=(" + txtIDColor.Text + ")"
                GuardarDatos()
                GuardarSubColores()
                LabelStatus.Text = "Los cambios se realizaron satisfactoriamente."
            End If

        ElseIf txtIDColor.Text = "" Then
            MessageBox.Show("No hay un registro de un grupo de color para desactivar", "No se encontró registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        Else

            Dim Result As MsgBoxResult = MessageBox.Show("Esta seguro que desea anular el grupo de colores del sistema?", "Anular grupo de colores", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                chkNulo.Checked = True
                sqlQ = "UPDATE Color SET Color='" + txtDescrip.Text + "',Nulo='" + chkNulo.Tag.ToString + "' WHERE IDColor=(" + txtIDColor.Text + ")"
                GuardarDatos()
                GuardarSubColores()
                LabelStatus.Text = "Los cambios se realizaron satisfactoriamente."
            End If
        End If
    End Sub

    Private Sub DgvArticulos_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvColoresDetallados.CellMouseUp
        If e.RowIndex >= 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                DgvColoresDetallados.Rows(e.RowIndex).Selected = True
                DgvColoresDetallados.CurrentCell = DgvColoresDetallados.Rows(e.RowIndex).Cells(1)
                CMenuProducts.Show(DgvColoresDetallados, e.Location)
                CMenuProducts.Show(Cursor.Position)
            End If
        End If

    End Sub

    Private Sub QuitarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QuitarToolStripMenuItem1.Click
        If DgvColoresDetallados.Rows.Count > 0 Then

            If CStr(DgvColoresDetallados.CurrentRow.Cells(0).Value) <> "" Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el color?", "Eliminar color", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    sqlQ = "Delete from Color_detalle WHERE IDColor_detalle='" + DgvColoresDetallados.CurrentRow.Cells(0).Value.ToString + "'"
                    ConLibregco.Open()
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()
                    ConLibregco.Close()
                    GenerateImageColor()
                    DgvColoresDetallados.Rows.Remove(DgvColoresDetallados.CurrentRow)

                    MessageBox.Show("El color ha sido eliminada satisfactoriamente.", "Color eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If

            Else
                DgvColoresDetallados.Rows.Remove(DgvColoresDetallados.CurrentRow)

            End If

            ConseguirSubColores()
        End If
    End Sub

    Private Sub ModificarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ModificarToolStripMenuItem1.Click
        IDDetalleColor = DgvColoresDetallados.CurrentRow.Cells(0).Value
        txtNombreColor.Text = DgvColoresDetallados.CurrentRow.Cells(1).Value
        CPEColor.Color = Color.FromArgb(DgvColoresDetallados.CurrentRow.Cells(2).Value)

        DgvColoresDetallados.Rows.Remove(DgvColoresDetallados.CurrentRow)

        ConseguirSubColores()

        DgvColoresDetallados.ClearSelection()

    End Sub
End Class