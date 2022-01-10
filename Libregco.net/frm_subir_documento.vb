Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Public Class frm_subir_documento

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend RutaDocumento As New Label
    Dim Offset As Point

    Private Sub frm_subir_documento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarLibregco()
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub EscanearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EscanearToolStripMenuItem.Click
        btnEscanear.PerformClick()
    End Sub

    Private Sub BuscarDocumentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarDocumentoToolStripMenuItem.Click
        btnBuscar.PerformClick()
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        btnAbrir.PerformClick()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirToolStripMenuItem.Click
        btnImprimir.PerformClick()
    End Sub

    Private Sub LimpiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarToolStripMenuItem.Click
        btnLimpiar.PerformClick()
    End Sub

    Private Sub btnEscanear_Click(sender As Object, e As EventArgs) Handles btnEscanear.Click
        Try
            Dim CD As New WIA.CommonDialog
            Dim F As WIA.ImageFile = CD.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType)
            Dim wFile As System.IO.FileStream
            Dim FileName As String = Today.ToString("ddMMyyyy") & TimeOfDay.ToString("hhmmss")

            F.SaveFile(Path.GetTempPath & FileName & "." & F.FileExtension)

            RutaDocumento.Text = Path.GetTempPath & FileName & "." & F.FileExtension

            wFile = New FileStream(RutaDocumento.Text, FileMode.Open, FileAccess.Read)
            PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
            wFile.Close()

            lblStatus.Text = "Imagen cargada satisfactoriamente desde " & RutaDocumento.Text

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim OfdRutaDocumento As New OpenFileDialog
        Dim wFile As System.IO.FileStream

        PicDocumento.Enabled = False

        OfdRutaDocumento.Title = ("Buscar Imagen")
        OfdRutaDocumento.Filter = "Imágenes(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
        OfdRutaDocumento.FileName = ""
        OfdRutaDocumento.RestoreDirectory = True

        If OfdRutaDocumento.ShowDialog = Windows.Forms.DialogResult.OK Then
            RutaDocumento.Text = OfdRutaDocumento.FileName
            wFile = New FileStream(OfdRutaDocumento.FileName, FileMode.Open, FileAccess.Read)
            PicDocumento.Enabled = False
            PicDocumento.Image = System.Drawing.Image.FromStream(wFile)
            PicDocumento.Location = New Point(0, 0)
            wFile.Close()
            lblStatus.Text = "Imagen Cargada"
            btnDownload.Visible = True
            btnRotar.Visible = True
        Else
            ResetPicImage()
            btnDownload.Visible = False
            btnRotar.Visible = False
        End If

        PicDocumento.Enabled = True
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        If RutaDocumento.Text = "" Then
            MessageBox.Show("No se ha encontrado una imagen anexa para abrirla.", "No hay documento anexo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea abrir la foto vinculada al registro?", "Abrir documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                System.Diagnostics.Process.Start(RutaDocumento.Text)
            End If
        End If
    End Sub

    Private Sub btnReducirZoom_Click(sender As Object, e As EventArgs) Handles btnReducirZoom.Click
        If RutaDocumento.Text = "" Then
            MessageBox.Show("No hay imagen anexa para hacer zoom.", "Falta Anexar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            PicDocumento.Width -= 100%
            PicDocumento.Height -= 100%
        End If
    End Sub

    Private Sub btnAumentarZoom_Click(sender As Object, e As EventArgs) Handles btnAumentarZoom.Click
        If RutaDocumento.Text = "" Then
            MessageBox.Show("No hay imagen anexa para hacer zoom.", "Falta Anexar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            PicDocumento.Width += 100%
            PicDocumento.Height += 100%
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim PrintShow As New PrintDialog

        If RutaDocumento.Text = "" Then
            MessageBox.Show("No se pudo imprimir debido a que no existe documentación anexa al registro.", "Falta Anexar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            If PrintShow.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc.PrinterSettings = PrintShow.PrinterSettings
                PrintDoc.Print()
            End If
        End If
    End Sub

    Private Sub btnVerRuta_Click(sender As Object, e As EventArgs) Handles btnVerRuta.Click
        If RutaDocumento.Text = "" Then
        Else
            MessageBox.Show(RutaDocumento.Text)
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If RutaDocumento.Text = "" Then
            MessageBox.Show("No existe documentación anexa al registro.", "No existe archivo adjunto", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Else
            Dim Result As MsgBoxResult = MessageBox.Show("Desea eliminar el archivo adjunto al registro?", "Eliminar archivo adjunto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                RutaDocumento.Text = ""
                ResetPicImage()
                lblStatus.Text = "Listo"
            End If
        End If
    End Sub

    Sub ResetPicImage()
        Try
            RutaDocumento.Text = ""
            PicDocumento.Width = PanelPic.Width
            PicDocumento.Height = PanelPic.Height
            PicDocumento.Location = New Point(0, 0)
            PicDocumento.Image = My.Resources.No_Image
            btnDownload.Visible = False
            btnRotar.Visible = False

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub ZoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem.Click
        btnAumentarZoom.PerformClick()
    End Sub

    Private Sub ZoomToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem1.Click
        btnReducirZoom.PerformClick()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If Me.Owner.Name = frm_registro_compras.Name Then
                frm_registro_compras.RutaDocumento.Text = RutaDocumento.Text

            ElseIf Me.Owner.Name = frm_factura_cxp.Name Then
                frm_factura_cxp.RutaDocumento.Text = RutaDocumento.Text

            ElseIf Me.Owner.Name = frm_movimientos_bancarios.Name Then
                frm_movimientos_bancarios.lblRutaDocumento.Text = RutaDocumento.Text

            ElseIf Me.Owner.Name = frm_cheques.Name Then
                frm_cheques.lblRutaDocumento.Text = RutaDocumento.Text

            ElseIf Me.Owner.Name = frm_empleados_vacaciones.name Then
                frm_empleados_vacaciones.RutaDocumento = RutaDocumento.Text

            ElseIf Me.Owner.Name = frm_consulta_compras.Name Then

                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el documento seleccionado como una copia del registro seleccionado" & vbNewLine & vbNewLine & "[" & frm_consulta_compras.GridView1.GetFocusedRowCellValue("IDSuplidor").ToString & "] " & frm_consulta_compras.GridView1.GetFocusedRowCellValue("Suplidor").ToString & vbNewLine & "Fact. No.: " & frm_consulta_compras.GridView1.GetFocusedRowCellValue("NoFactura").ToString & ", por un valor de " & CDbl(frm_consulta_compras.GridView1.GetFocusedRowCellValue("TotalNeto").ToString).ToString("C") & "?", "Subir copia de factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    'Verificamos si existe el folder del suplidor

                    If RutaDocumento.Text = "" Then
                    Else
                        'Verifico si existe la carpeta del suplidor
                        Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & frm_consulta_compras.GridView1.GetFocusedRowCellValue("IDSuplidor").ToString)
                        If Exists = False Then
                            System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & frm_consulta_compras.GridView1.GetFocusedRowCellValue("IDSuplidor").ToString)
                        End If


                        'Verifico si existe el archivo de por anexar
                        Dim ExistsFile As Boolean = System.IO.File.Exists(RutaDocumento.Text)

                        If ExistsFile = True Then
                            Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & frm_consulta_compras.GridView1.GetFocusedRowCellValue("IDSuplidor").ToString & "\" & frm_consulta_compras.GridView1.GetFocusedRowCellValue("ID").ToString & "-" & frm_consulta_compras.GridView1.GetFocusedRowCellValue("NoFactura").ToString & ".png"

                            If RutaDestino <> RutaDocumento.Text Then
                                My.Computer.FileSystem.MoveFile(RutaDocumento.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                            End If

                            sqlQ = "UPDATE Compras SET RutaDocumento='" + (Replace(RutaDestino, "\", "\\")) + "' WHERE IDCompra= '" + frm_consulta_compras.GridView1.GetFocusedRowCellValue("ID").ToString + "'"
                            GuardarDatos()

                            'Devolver Nueva Ruta al los controles
                            Dim myRow() As DataRow
                            myRow = frm_consulta_compras.TableCompras.Select("ID = '" + frm_consulta_compras.GridView1.GetFocusedRowCellValue("ID").ToString + "'")
                            myRow(0)("RutaFoto") = RutaDestino

                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                            myRow(0)("Imagen") = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()

                            frm_consulta_compras.btnImagen.Visible = True
                            frm_consulta_compras.btnSubir.Visible = False
                        End If

                    End If
                End If

            ElseIf Me.Owner.Name = frm_consulta_ventas.name Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el documento seleccionado como una copia del registro seleccionado" & vbNewLine & vbNewLine & "[" & frm_consulta_ventas.GridView1.GetFocusedRowCellValue("IDCliente").ToString & "] " & frm_consulta_ventas.GridView1.GetFocusedRowCellValue("Nombre").ToString & vbNewLine & "Documento #.: " & frm_consulta_ventas.GridView1.GetFocusedRowCellValue("SecondID").ToString & ", por un valor de " & CDbl(frm_consulta_ventas.GridView1.GetFocusedRowCellValue("TotalNeto").ToString).ToString("C") & "?", "Subir copia de factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    'Verificamos si existe el folder del suplidor

                    If RutaDocumento.Text = "" Then
                    Else
                        'Verifico si existe la carpeta del suplidor
                        Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Ventas")
                        If Exists = False Then
                            System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Ventas")
                        End If


                        'Verifico si existe el archivo de por anexar
                        Dim ExistsFile As Boolean = System.IO.File.Exists(RutaDocumento.Text)

                        If ExistsFile = True Then
                            Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Ventas\" & frm_consulta_ventas.GridView1.GetFocusedRowCellValue("ID").ToString & ".png"

                            If RutaDestino <> RutaDocumento.Text Then
                                My.Computer.FileSystem.MoveFile(RutaDocumento.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                            End If

                            sqlQ = "UPDATE FacturaDatos SET FacturaFilePath='" + (Replace(RutaDestino, "\", "\\")) + "' WHERE IDFacturaDatos= '" + frm_consulta_ventas.GridView1.GetFocusedRowCellValue("ID").ToString + "'"
                            GuardarDatos()

                            'Devolver Nueva Ruta al los controles
                            Dim myRow() As DataRow
                            myRow = frm_consulta_ventas.TablaVentas.Select("ID = '" + frm_consulta_ventas.GridView1.GetFocusedRowCellValue("ID").ToString + "'")
                            myRow(0)("FacturaFilePath") = RutaDestino

                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                            myRow(0)("Imagen") = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()

                            frm_consulta_ventas.btnImagen.Visible = True
                            frm_consulta_ventas.btnSubir.Visible = False
                        End If

                    End If
                End If

            ElseIf Me.Owner.Name = frm_consulta_facturas_cxp.name Then
                Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el documento seleccionado como una copia del registro seleccionado" & vbNewLine & vbNewLine & "[" & frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("IDSuplidor").ToString & "] " & frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("Suplidor").ToString & vbNewLine & "Fact. No.: " & frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("NoFactura").ToString & ", por un valor de " & CDbl(frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("TotalNeto").ToString).ToString("C") & "?", "Subir copia de factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If Result = MsgBoxResult.Yes Then
                    'Verificamos si existe el folder del suplidor

                    If RutaDocumento.Text = "" Then
                    Else
                        'Verifico si existe la carpeta del suplidor
                        Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("IDSuplidor").ToString)
                        If Exists = False Then
                            System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("IDSuplidor").ToString)
                        End If


                        'Verifico si existe el archivo de por anexar
                        Dim ExistsFile As Boolean = System.IO.File.Exists(RutaDocumento.Text)

                        If ExistsFile = True Then
                            Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Suplidores\" & frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("IDSuplidor").ToString & "\" & frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("ID").ToString & "-" & frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("NoFactura").ToString & ".png"

                            If RutaDestino <> RutaDocumento.Text Then
                                My.Computer.FileSystem.MoveFile(RutaDocumento.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                            End If

                            sqlQ = "UPDATE Compras SET RutaDocumento='" + (Replace(RutaDestino, "\", "\\")) + "' WHERE IDCompra= '" + frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("ID").ToString + "'"
                            GuardarDatos()

                            'Devolver Nueva Ruta al los controles
                            Dim myRow() As DataRow
                            myRow = frm_consulta_facturas_cxp.TableCompras.Select("ID = '" + frm_consulta_facturas_cxp.GridView1.GetFocusedRowCellValue("ID").ToString + "'")
                            myRow(0)("RutaFoto") = RutaDestino

                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                            myRow(0)("Imagen") = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()

                            frm_consulta_facturas_cxp.btnImagen.Visible = True
                            frm_consulta_facturas_cxp.btnSubir.Visible = False
                        End If

                    End If
                End If

            ElseIf Me.Owner.name = frm_formadepago.name Then
                frm_formadepago.RutaDocumento = RutaDocumento.Text

                'Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar el documento seleccionado como una copia del registro seleccionado" & vbNewLine & vbNewLine & "Boucher No: " & frm_formadepago.txtNoAprobacion.Text & vbNewLine & "Por un valor de: " & frm_formadepago.txtTarjeta.Text, "Boucher Digital", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                'If Result = MsgBoxResult.Yes Then
                '    'Verificamos si existe el folder del suplidor

                '    If RutaDocumento.Text = "" Then
                '    Else
                '        'Verifico si existe la carpeta del suplidor
                '        Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Verifone")
                '        If Exists = False Then
                '            System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Verifone")
                '        End If

                '        'Verifico si existe el archivo de por anexar
                '        Dim ExistsFile As Boolean = System.IO.File.Exists(RutaDocumento.Text)

                '        If ExistsFile = True Then
                '            Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Verifone\" & frm_formadepago.txtNoAprobacion.Text & ".png"

                '            If RutaDestino <> RutaDocumento.Text Then
                '                My.Computer.FileSystem.MoveFile(RutaDocumento.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                '            End If

                '            sqlQ = "UPDATE Compras Set RutaDocumento='" + (Replace(RutaDestino, "\", "\\")) + "' WHERE IDCompra= '" + frm_consulta_compras.DgvCompras.CurrentRow.Cells(0).Value.ToString + "'"
                '            GuardarDatos()

                '            'Devolver Nueva Ruta al los controles
                '            frm_consulta_compras.DgvCompras.CurrentRow.Cells(9).Value = RutaDestino
                '            frm_consulta_compras.btnStructure.Visible = True
                '            frm_consulta_compras.btnSubir.Visible = False
                '        End If

                '    End If
                'End If

            ElseIf Me.Owner.Name = frm_inicio.name Then
                'Verificamos si existe el folder del suplidor


                If RutaDocumento.Text <> "" Then

                    If TypeConnection.Text = 1 Then
                        Dim Exists As Boolean = System.IO.Directory.Exists("\\" & PathServidor.Text & "\Libregco\Files\Verifone")
                        If Exists = False Then
                            System.IO.Directory.CreateDirectory("\\" & PathServidor.Text & "\Libregco\Files\Verifone")
                        End If

                        'Verifico si existe el archivo de por anexar
                        Dim ExistsFile As Boolean = System.IO.File.Exists(RutaDocumento.Text)

                        If ExistsFile = True Then
                            Dim RutaDestino As String = "\\" & PathServidor.Text & "\Libregco\Files\Verifone\" & frm_inicio.GridView1.GetFocusedRowCellValue("NoAprobacion") & ".png"

                            If RutaDestino <> RutaDocumento.Text Then
                                My.Computer.FileSystem.MoveFile(RutaDocumento.Text, RutaDestino, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                            End If

                            sqlQ = "UPDATE Transaccion SET RutaBoucher='" + (Replace(RutaDestino, "\", "\\")) + "' WHERE IDTransaccion= '" + frm_inicio.GridView1.GetFocusedRowCellValue("IDTransaccion").ToString + "'"
                            GuardarDatos()

                            'Devolver Nueva Ruta al los controles
                            Dim myRow() As DataRow
                            myRow = TablaTransacciones.Select("IDTransaccion = '" + frm_inicio.GridView1.GetFocusedRowCellValue("IDTransaccion").ToString + "'")
                            myRow(0)("RutaBoucher") = RutaDestino

                            Dim wFile As System.IO.FileStream
                            wFile = New FileStream(RutaDestino, FileMode.Open, FileAccess.Read)
                            myRow(0)("Imagen") = System.Drawing.Image.FromStream(wFile)
                            wFile.Close()
                        End If

                    End If
                End If



            ElseIf Me.Owner.Name = frm_mant_clientes.name Then
                If RutaDocumento.Text <> "" Then

                    If TypeConnection.Text = 1 Then
                        frm_mant_clientes.GridView2.SetFocusedRowCellValue("RutaCarnet", RutaDocumento.Text)
                        frm_mant_clientes.GridView2.SetFocusedRowCellValue("Imagen", 1)

                        frm_mant_clientes.GridView2.AddNewRow()
                        frm_mant_clientes.GridView2.DeleteRow(frm_mant_clientes.GridView2.FocusedRowHandle)
                        'frm_mant_clientes.GridView2.Focus()
                        'frm_mant_clientes.GridView2.FocusedRowHandle = frm_mant_clientes.GridControl2.NewItemRowHandle
                        'frm_mant_clientes.GridView2.FocusedColumn = frm_mant_clientes.GridView2.VisibleColumns(6)
                        'frm_mant_clientes.GridView2.ShowEditor()
                        'frm_mant_clientes.GridView2.PostEditor()
                    End If
                End If
            End If

            Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
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
            Con.Close()
        End Try
    End Sub

    Private Sub PicDocumento_MouseDown(sender As Object, e As MouseEventArgs) Handles PicDocumento.MouseDown
        Try
            If RutaDocumento.Text <> "" Then
                Offset = New Point(-e.X, -e.Y)
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub PicDocumento_MouseMove(sender As Object, e As MouseEventArgs) Handles PicDocumento.MouseMove
        Try
            If RutaDocumento.Text <> "" Then
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    Dim Pos As Point = Me.PointToClient(MousePosition)
                    Pos.Offset(Offset.X, Offset.Y)
                    PicDocumento.Location = Pos
                End If
            End If
            'If PanelPic.VerticalScroll.Visible = True Or PanelPic.HorizontalScroll.Visible = True Then

            'End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "Archivo JPEG |*.jpg|Archivo BITMAP|*.bmp|Archivo PNG|*.png"
        saveFileDialog1.Title = "Guardar imagen"
        saveFileDialog1.ShowDialog()

        If saveFileDialog1.FileName <> "" Then
            My.Computer.FileSystem.CopyFile(RutaDocumento.Text, saveFileDialog1.FileName)
        End If
    End Sub

    Private Sub DescargarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescargarToolStripMenuItem.Click
        btnDownload.PerformClick()
    End Sub

    Private Sub PicDocumento_LoadCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles PicDocumento.LoadCompleted
        PicDocumento.Location = New Point(0, 0)
        PicDocumento.Enabled = True
    End Sub

    Private Sub btnRotar_Click(sender As Object, e As EventArgs) Handles btnRotar.Click
        '' Display the result.
        Dim wFile As System.IO.FileStream
        wFile = New FileStream(RutaDocumento.Text, FileMode.Open, FileAccess.Read)
        Dim picRotated As Bitmap = Image.FromStream(wFile)
        wFile.Close()

        'Rotate image clockwise 90 degrees
        picRotated.RotateFlip(RotateFlipType.Rotate90FlipNone)

        PicDocumento.Image = picRotated

        My.Computer.FileSystem.DeleteFile(RutaDocumento.Text)

        PicDocumento.Image.Save(RutaDocumento.Text)
    End Sub

    Private Sub AbrirUbicaciToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirUbicaciToolStripMenuItem.Click
        If RutaDocumento.Text <> "" Then
            Dim ExistFile As Boolean = System.IO.File.Exists(RutaDocumento.Text)
            If ExistFile = True Then
                Dim directory As String = Path.GetDirectoryName(RutaDocumento.Text)
                Process.Start("explorer.exe", directory)
            End If
        End If

    End Sub



End Class