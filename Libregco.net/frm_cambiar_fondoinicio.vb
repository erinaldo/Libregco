Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_cambiar_fondoinicio

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim GotIDColor As String
    Dim GotColor As New Color
    Dim ImageColumn As New DataGridViewImageColumn
    Dim CheckColumn As New DataGridViewCheckBoxColumn

    Private Sub frm_cambiar_fondoinicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        AddColumns()
        CargarLibregco()
        FondoActual()
        RefrescarTablaFondos()
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub PropiedadDgvFondos()
        Try
            Dim DatagridWith As Double = (DgvFondos.Width - DgvFondos.RowHeadersWidth) / 100

            With DgvFondos
                .Columns(0).Visible = False
                .Columns(1).Width = DatagridWith * 45
                .Columns(1).ReadOnly = True
                .Columns(2).Width = DatagridWith * 15
                .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(3).Width = DatagridWith * 15
                .Columns(4).HeaderText = "Fondo"
                .Columns(4).Width = DatagridWith * 20
                .Columns(5).Width = DatagridWith * 10
            End With

        Catch ex As Exception

        End Try

    End Sub

    Private Sub AddColumns()
        Try
            DgvFondos.Columns.Clear()

            With DgvFondos
                .Columns.Add("IDFondo", "ID Fondo") '0
                .Columns.Add("Ruta", "Ruta Documento") '1
                .Columns.Add("IDColor", "ID Color") '2
                .Columns.Add("Color", "Color") '3
                .Columns.Add(ImageColumn) '4
                .Columns.Add(CheckColumn) '5

            End With

            ImageColumn.Image = Nothing
            ImageColumn.Name = "Fondo"
            ImageColumn.DisplayIndex = 2
            ImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom

            With CheckColumn
                .HeaderText = "Desactivar"
                .Name = "CheckColumn"
                .ThreeState = False
                .TrueValue = 1
                .FalseValue = 0
                .FlatStyle = FlatStyle.Standard
                .DataPropertyName = "CheckColumn"
            End With

            PropiedadDgvFondos()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub FondoActual()
        Try
            If TypeConnection.Text = 1 Then
                Con.Open()
                cmd = New MySqlCommand("Select Value1Var from Configuracion where IDConfiguracion=1", Con)
                lblFondoInicio.Text = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                If lblFondoInicio.Text = "" Then
                Else
                    Dim ExistFile As Boolean = System.IO.File.Exists(lblFondoInicio.Text)
                    If ExistFile = True Then
                        Dim wFile As System.IO.FileStream
                        wFile = New FileStream(lblFondoInicio.Text, FileMode.Open, FileAccess.Read)


                        PicBackGround.Image = System.Drawing.Image.FromStream(wFile)

                        Con.Open()
                        cmd = New MySqlCommand("SELECT ArgbColor FROM FondosPantalla WHERE Ruta='" + Replace(lblFondoInicio.Text, "\", "\\") + "'", Con)
                        lblColor.Text = Convert.ToString(cmd.ExecuteScalar())
                        Con.Close()
                    Else
                        MessageBox.Show("La imagen " & vbNewLine & vbNewLine & lblFondoInicio.Text & vbNewLine & vbNewLine & "ha sido movida o eliminada de su ubicación.", "No se encontró la imagen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If


            End If
            
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "FondoActual")
        End Try
    End Sub

    Sub RefrescarTablaFondos()
        If TypeConnection.Text = 1 Then
            Dim wFile As System.IO.FileStream

            DgvFondos.Rows.Clear()
            DgvFondosDisponibles.Rows.Clear()

            Con.Open()
            Dim Consulta As New MySqlCommand("SELECT * from FondosPantalla", Con)
            Dim LectorFondos As MySqlDataReader = Consulta.ExecuteReader



            While LectorFondos.Read
                Dim ExistFile As Boolean = System.IO.File.Exists(LectorFondos.GetValue(1))
                If ExistFile = True Then
                    wFile = New FileStream(LectorFondos.GetValue(1), FileMode.Open, FileAccess.Read)

                    DgvFondos.Rows.Add(LectorFondos.GetValue(0), LectorFondos.GetValue(1), LectorFondos.GetValue(2), "", System.Drawing.Image.FromStream(wFile), CBool(LectorFondos.GetValue(3)), LectorFondos.GetValue(2))
                    DgvFondosDisponibles.Rows.Add(LectorFondos.GetValue(1), System.Drawing.Image.FromStream(wFile), LectorFondos.GetValue(2))

                    wFile.Close()
                Else
                    ConLibregco.Open()
                    sqlQ = "Delete from FondosPantalla Where IDFondosPantalla= '" + LectorFondos.GetValue(0).ToString + "'"
                    cmd = New MySqlCommand(sqlQ, ConLibregco)
                    cmd.ExecuteNonQuery()
                    ConLibregco.Close()
                End If
            End While


            Con.Close()
            LectorFondos.Close()

            For Each Row As DataGridViewRow In DgvFondos.Rows
                Row.Cells(3).Style.BackColor = Color.FromArgb(Convert.ToString(Row.Cells(2).Value))
            Next

            DgvFondos.ClearSelection()
            DgvFondosDisponibles.ClearSelection()

        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim OfdImagen As New OpenFileDialog
        Dim wFile As System.IO.FileStream

        With OfdImagen
            '.InitialDirectory = "\\" & PathServidor.Text & "\Libregco\Pictures\Wallpapers"
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Title = "Buscar Fondo de Pantalla"
            .Filter = "Imágenes(*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png"
            .FileName = ""
        End With

        If OfdImagen.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            lblStatusBar.Text = "Insertado nueva imagen para fondo de pantalla. Por favor espere..."

            wFile = New FileStream(OfdImagen.FileName, FileMode.Open, FileAccess.Read)
            GotColor = GetAverageColor(OfdImagen.FileName)
            GotIDColor = GotColor.ToArgb.ToString

            With DgvFondos
                .Rows.Add("", OfdImagen.FileName, GotIDColor, "", System.Drawing.Image.FromStream(wFile))
            End With
            wFile.Close()
        End If


        For Each Row As DataGridViewRow In DgvFondos.Rows
            Row.Cells(3).Style.BackColor = Color.FromArgb(Convert.ToString(Row.Cells(2).Value))
        Next

        DgvFondos.ClearSelection()

        lblStatusBar.Text = "Listo"

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnChangeWindows_Click(sender As Object, e As EventArgs) Handles btnChangeWindows.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
            btnChangeWindows.Text = "Restaurar"
        Else
            Me.WindowState = FormWindowState.Normal
            btnChangeWindows.Text = "Maximizar"
        End If
    End Sub

    Private Sub btnBuscarFondoInicio_Click(sender As Object, e As EventArgs) Handles btnBuscarFondoInicio.Click
        Try
            Dim OfdImagen As New OpenFileDialog
            Dim wFile As System.IO.FileStream
            With OfdImagen
                '.InitialDirectory = "\\" & PathServidor.Text & "\Libregco\Pictures\Wallpapers"
                .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                .Title = ("Buscar Fondo de Pantalla")
                .Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
                .FileName = ""
            End With

            If OfdImagen.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor

                lblFondoInicio.Text = OfdImagen.FileName
                wFile = New FileStream(OfdImagen.FileName, FileMode.Open, FileAccess.Read)
                PicBackGround.Image = System.Drawing.Image.FromStream(wFile)
                wFile.Close()

                GotColor = GetAverageColor(lblFondoInicio.Text)
                lblColor.Text = GotColor.ToArgb.ToString

                Cursor = Cursors.Default
            End If


        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnVisualizarFondoInicio_Click(sender As Object, e As EventArgs) Handles btnVisualizarFondoInicio.Click
        If lblFondoInicio.Text = "" Then
            MessageBox.Show("No se ha encontrado una imagen para poder abrirla.", "Falta Anexar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            lblStatusBar.Text = "Visualizando imagen anexa..."
            Dim Result As MsgBoxResult = MessageBox.Show("Desea abrir la imagen?", "Abrir Imagen", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                System.Diagnostics.Process.Start(lblFondoInicio.Text)
            End If
            lblStatusBar.Text = "Listo"
        End If
    End Sub

    Private Sub btnGuardarFondoInicio_Click(sender As Object, e As EventArgs) Handles btnGuardarFondoInicio.Click
        If lblFondoInicio.Text = "" Then
            MessageBox.Show("No se ha seleccionado una imagen para colocar el fondo de pantalla.", "No se encontró una imagen", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar el fondo seleccionado para el formulario?", "Guardar BackGroundImage", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                lblStatusBar.Text = "Guardando imagen..."
                Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Pictures\Wallpapers")
                If Exists = False Then
                    System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Pictures\Wallpapers")
                End If

                Dim ExistFile As Boolean = System.IO.File.Exists(lblFondoInicio.Text)
                If ExistFile = True Then
                    Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Pictures\Wallpapers\" & Path.GetFileName(lblFondoInicio.Text)

                    If RutaDestino <> lblFondoInicio.Text Then
                        My.Computer.FileSystem.CopyFile(lblFondoInicio.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                        sqlQ = "INSERT INTO FondosPantalla (Ruta,ArgbColor,Desactivar) VALUES ('" + Replace(RutaDestino, "\", "\\") + "','" + lblColor.Text + "',0)"
                        GuardarDatos()
                    End If

                    sqlQ = "UPDATE Configuracion SET Value1Var='" + Replace(RutaDestino, "\", "\\") + "' WHERE IDConfiguracion=1"
                    GuardarDatos()

                    MessageBox.Show("El fondo de pantalla de inicio ha sido establecido satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    'Verificar fondos de pantallas en inicio
                    Con.Open()
                    cmd = New MySqlCommand("SELECT Value2Int FROM Configuracion WHERE IDConfiguracion=67", Con)
                    Dim ShowWallp As String = Convert.ToString(cmd.ExecuteScalar())
                    Con.Close()

                    If ShowWallp = 1 Then
                        Dim AverageColor As Color = Color.FromArgb(lblColor.Text)
                        frm_inicio.PanelBackGround.BackgroundImage = Image.FromFile(RutaDestino)
                        frm_inicio.lblSeleccion.BackColor = AverageColor
                        frm_inicio.Label1.BackColor = AverageColor
                        frm_inicio.PanelBussInfo.BackColor = Color.FromArgb(100, AverageColor)
                        lblFondoInicio.Text = RutaDestino
                    End If
                    RefrescarTablaFondos()
                Else
                    MessageBox.Show("El archivo " & lblFondoInicio.Text & " ha sido eliminado o movido de la ruta anexada. Su anexo no será registrado.", "No se encontró archivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End If
            End If
            lblStatusBar.Text = "Listo"
        End If
    End Sub

    Private Sub TabPagesFondos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabPagesFondos.SelectedIndexChanged
        DgvFondos.ClearSelection()
        DgvFondosDisponibles.ClearSelection()
    End Sub

    Private Sub DgvFondosDisponibles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFondosDisponibles.CellClick
        Try
            Dim wFile As System.IO.FileStream

            If e.ColumnIndex = 1 Then
                Cursor = Cursors.WaitCursor
                wFile = New FileStream(DgvFondosDisponibles.CurrentRow.Cells(0).Value, FileMode.Open, FileAccess.Read)
                lblFondoInicio.Text = DgvFondosDisponibles.CurrentRow.Cells(0).Value
                lblColor.Text = DgvFondosDisponibles.CurrentRow.Cells(2).Value
                PicBackGround.Image = System.Drawing.Image.FromStream(wFile)
                wFile.Close()
                Cursor = Cursors.Default
            End If

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub btnGuardarFondos_Click(sender As Object, e As EventArgs) Handles btnGuardarFondos.Click
        Dim IDFondo, Ruta, Color As New Label

        Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el fondo seleccionado?", "Fondo de Pantalla", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If Result = MsgBoxResult.Yes Then
            lblStatusBar.Text = "Guardando nueva imagen para fondo de pantalla. Por favor espere..."

            Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Pictures\Wallpapers")
            If Exists = False Then
                System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Pictures\Wallpapers")
            End If

            For Each Rows As DataGridViewRow In DgvFondos.Rows
                IDFondo.Text = Rows.Cells(0).Value
                Ruta.Text = Rows.Cells(1).Value
                Color.Text = Rows.Cells(2).Value

                If IDFondo.Text = "" Then
                    Dim ExistFile As Boolean = System.IO.File.Exists(Ruta.Text)
                    If ExistFile = True Then
                        Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Pictures\Wallpapers\" & Path.GetFileName(Ruta.Text)

                        If RutaDestino <> Ruta.Text Then
                            My.Computer.FileSystem.CopyFile(Ruta.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                            sqlQ = "INSERT INTO FondosPantalla (Ruta,ArgbColor) VALUES ('" + Replace(RutaDestino, "\", "\\") + "','" + Color.Text + "')"
                            GuardarDatos()
                        End If

                    End If
                End If
            Next
            MessageBox.Show("Los fondos han sido insertados satisfactoriamente.", "Se han guardado las pantallas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            RefrescarTablaFondos()
            lblStatusBar.Text = "Listo"

        End If

    End Sub


    Private Sub btnVerFondos_Click(sender As Object, e As EventArgs) Handles btnVerFondos.Click
        Dim RutaDestino As String
        Dim Exists As Boolean

        Cursor.Current = Cursors.WaitCursor

        If DgvFondos.Rows.Count = 0 Then
            MessageBox.Show("No se encuentran rutas para abrir documentos.", "No se encontraron rutas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            RutaDestino = DgvFondos.CurrentRow.Cells(1).Value
            lblStatusBar.Text = "Visualizando imagen anexa..."

            Exists = System.IO.File.Exists(RutaDestino)
            If Exists = False Then
                MessageBox.Show("El archivo específicado en la ruta " & RutaDestino & " se ha modificado o eliminado.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                DgvFondos.Rows.Remove(DgvFondos.CurrentRow)
            Else
                System.Diagnostics.Process.Start(RutaDestino)
            End If
        End If

        lblStatusBar.Text = "Listo"
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If DgvFondos.Rows.Count = 0 Then
            MessageBox.Show("No hay fondos insertados para eliminar.", "No se encontraron fondos", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            Dim IDFondo As String = DgvFondos.CurrentRow.Cells(0).Value
            Dim RutaFondo As String = DgvFondos.CurrentRow.Cells(1).Value
            If IDFondo = "" Then
                DgvFondos.Rows.Remove(DgvFondos.CurrentRow)
            Else
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea eliminar el fondo de pantalla " & DgvFondos.CurrentRow.Cells(1).Value & " del sistema?", "Eliminar Fondo de Pantalla", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    lblStatusBar.Text = "Eliminado imagen fondo de pantalla..."

                    My.Computer.FileSystem.DeleteFile(RutaFondo, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
                    sqlQ = "Delete from FondosPantalla Where IDFondosPantalla= '" + IDFondo + "'"
                    GuardarDatos()
                    RefrescarTablaFondos()
                End If
            End If
        End If
        lblStatusBar.Text = "Listo"

    End Sub

    Private Sub frm_cambiar_fondoinicio_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PropiedadDgvFondos()
    End Sub

    Private Sub DgvFondos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFondos.CellEndEdit
        DgvFondos.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvFondoss_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvFondos.CurrentCellDirtyStateChanged
        If DgvFondos.IsCurrentCellDirty Then
            DgvFondos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvFondos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvFondos.CellValueChanged
        If DgvFondos.Rows.Count > 0 Then
            If e.ColumnIndex = 5 Then
                Dim IsTicked As Boolean = CBool(DgvFondos.CurrentRow.Cells(5).Value)
              
                If IsTicked Then
                    sqlQ = "UPDATE FondosPantalla SET Desactivar=1 WHERE IDFondosPantalla= (" + DgvFondos.CurrentRow.Cells(0).Value.ToString + ")"
                    GuardarDatos()
                Else
                    sqlQ = "UPDATE FondosPantalla SET Desactivar=0 WHERE IDFondosPantalla= (" + DgvFondos.CurrentRow.Cells(0).Value.ToString + ")"
                    GuardarDatos()
                End If

            End If
        End If
    End Sub
End Class