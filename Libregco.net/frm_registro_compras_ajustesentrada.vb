Public Class frm_registro_compras_ajustesentrada
    Dim Permisos As New ArrayList
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter

    Private Sub frm_registro_compras_ajustesentrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        DgvArticulos.ClearSelection()
        Permisos = PasarPermisos(Me.Tag)

        Dim total As Double = 0
        For Each rw As DataGridViewRow In DgvArticulos.Rows
            If CBool(rw.Cells(8).Value) = True Then
                total += CDbl(CDbl(rw.Cells(6).Value) * Math.Abs(CDbl(rw.Cells(7).Value)))
            End If
        Next
        txtTotal.Text = CDbl(total).ToString("C")

        If total = 0 Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CDbl(txtTotal.Text) > 0 Then
            Dim IDAjuste As String
            Dim DsTemp As New DataSet

            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la guardar el ajuste de inventario de entrada en la base de datos?", "Guardar Ajuste de Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                sqlQ = "INSERT INTO MovimientoInventario (Fecha,Hora,IDTipoDocumento,IDUsuario,IDSucursal,IDAlmacen,Referencia,Comentario,Total,Impreso,Nulo) VALUES (CURDATE(),CURTIME(),'63','" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "','" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "','Ajuste desde compra','','" + CDbl(txtTotal.Text).ToString + "',0,'0')"
                GuardarDatos()

                Con.Open()
                cmd = New MySqlCommand("Select IDAjusteInventario from MovimientoInventario where IDAjusteInventario= (Select Max(IDAjusteInventario) from MovimientoInventario)", Con)
                IDAjuste = Convert.ToString(cmd.ExecuteScalar())
                Con.Close()

                DsTemp.Clear()
                cmd = New MySqlCommand("SELECT * FROM TipoDocumento WHERE IDTipoDocumento=63", Con)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "TipoDocumento")
                Con.Close()
                ConMixta.Close()

                Dim Tabla As DataTable = DsTemp.Tables("TipoDocumento")
                Dim lblSecondID, UltSecuencia As New Label

                lblSecondID.Text = (Tabla.Rows(0).Item("Letra")) & CStr(CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1).PadLeft(CInt(Tabla.Rows(0).Item("CantCharacter")), Tabla.Rows(0).Item("Filler"))
                UltSecuencia.Text = (CInt(Tabla.Rows(0).Item("UltimaSecuencia")) + 1)

                sqlQ = "UPDATE MovimientoInventario SET SecondID='" + lblSecondID.Text + "' WHERE IDAjusteInventario='" + IDAjuste + "'"
                GuardarDatos()

                sqlQ = "UPDATE TipoDocumento SET UltimaSecuencia='" + UltSecuencia.Text + "' WHERE IDTipoDocumento=63"
                GuardarDatos()

                'Insertando articulos
                For Each rw As DataGridViewRow In DgvArticulos.Rows
                    If CBool(rw.Cells(8).Value) = True Then
                        sqlQ = "INSERT INTO Movimientoinvdetalle (IDMovimientoInventario,IDPrecio,IDArticulo,Descripcion,IDMedida,Cantidad,Precio,Importe,IDAlmacen,IDTipoAjusteDetalle,ExistenciaAnterior) VALUES ('" + IDAjuste + "','" + rw.Cells(1).Value.ToString + "','" + rw.Cells(0).Value.ToString + "','" + rw.Cells(3).Value.ToString + "','" + rw.Cells(2).Value.ToString + "','" + Math.Abs(CDbl(rw.Cells(7).Value)).ToString + "','" + CDbl(rw.Cells(6).Value).ToString + "','" + (Math.Abs(CDbl(rw.Cells(7).Value)) * CDbl(rw.Cells(6).Value)).ToString + "','" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "',1,'" + CDbl(rw.Cells(7).Value).ToString + "')"
                        GuardarDatos()

                        FunctCalcInventarioGral(rw.Cells(0).Value.ToString)
                        FunctCalcInvAlmacenes(rw.Cells(0).Value.ToString, rw.Cells(1).Value.ToString)
                    End If

                Next

                ToastNotificationsManager1.Notifications(0).Body = "El ajuste de entrada " & lblSecondID.Text & " ha sido generado satisfactoriamente."
                ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))

                Me.Close()

            End If
        End If

    End Sub

    Private Sub GuardarDatos()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & "Desde GuardarDatos")
            Con.Close()
        End Try
    End Sub

    Private Sub DgvArticulos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellValueChanged
        Try
            If e.ColumnIndex = 8 Then
                Dim total As Double = 0
                For Each rw As DataGridViewRow In DgvArticulos.Rows
                    If CBool(rw.Cells(8).Value) = True Then
                        total += CDbl(CDbl(rw.Cells(6).Value) * Math.Abs(CDbl(rw.Cells(7).Value)))
                    End If
                Next
                txtTotal.Text = CDbl(total).ToString("C")

                If total = 0 Then
                    Button1.Visible = False
                Else
                    Button1.Visible = True
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgvArticulos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvArticulos.CurrentCellDirtyStateChanged
        If DgvArticulos.IsCurrentCellDirty Then
            DgvArticulos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvArticulos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvArticulos.CellEndEdit
        DgvArticulos.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub
End Class