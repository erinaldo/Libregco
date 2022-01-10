Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_ret_isr

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim IDRetISR, Nulo As New Label
    Dim Permisos As New ArrayList

    Private Sub frm_mant_ret_isr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        CargarLibregco()
        Permisos = PasarPermisos(Me.Tag)
        ActualizarTodo()
        RefrescarISR()
    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub ActualizarTodo()
        ControlSuperClave = 1
        Nulo.Text = 0
    End Sub

    Private Sub PropiedadDgvISR()
        With DgvISR
            .Columns(0).Width = 75
            .Columns(0).HeaderText = "Código"
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).Width = 100
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).DefaultCellStyle.Format = ("C")
            .Columns(2).Width = 100
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).DefaultCellStyle.Format = ("C")
            .Columns(3).Width = 80
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).DefaultCellStyle.Format = ("P2")
            .Columns(4).Visible = False
        End With
    End Sub

    Sub RefrescarISR()
        Try
            Dim DsRetISR As New DataSet
            Dim AnexarISR As New MySqlDataAdapter("SELECT * FROM RetISR WHERE Nulo=0", Con)
            AnexarISR.Fill(DsRetISR)
            DgvISR.DataSource = DsRetISR.Tables(0)
            PropiedadDgvISR()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DgvISR_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DgvISR.CellMouseDoubleClick
       
        If e.RowIndex >= 0 Then
            IDRetISR.Text = DgvISR.CurrentRow.Cells(0).Value
            txtDesde.Text = CDbl(DgvISR.CurrentRow.Cells(1).Value).ToString("C")
            txtHasta.Text = CDbl(DgvISR.CurrentRow.Cells(2).Value).ToString("C")
            txtTasa.Text = CDbl(DgvISR.CurrentRow.Cells(3).Value).ToString("P2")
            Nulo.Text = DgvISR.CurrentRow.Cells(4).Value
        End If
    End Sub

    Private Sub LimpiarDatos()
        IDRetISR.Text = ""
        txtDesde.Clear()
        txtHasta.Clear()
        txtTasa.Clear()
        Nulo.Text = 0
        txtDesde.Focus()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarDatos()
    End Sub

    Private Sub txtDesde_Enter(sender As Object, e As EventArgs) Handles txtDesde.Enter
        If txtDesde.Text = "" Then
        Else
            txtDesde.Text = CDbl(txtDesde.Text)
        End If
    End Sub

    Private Sub txtHasta_Enter(sender As Object, e As EventArgs) Handles txtHasta.Enter
        If txtHasta.Text = "" Then
        Else
            txtHasta.Text = CDbl(txtHasta.Text)
        End If
    End Sub

    Private Sub txtDesde_Leave(sender As Object, e As EventArgs) Handles txtDesde.Leave
        Try
            If txtDesde.Text = "" Then
            Else
                txtDesde.Text = CDbl(txtDesde.Text).ToString("C")
            End If

        Catch ex As Exception
            txtDesde.Text = ""
        End Try
    End Sub

    Private Sub txtHasta_Leave(sender As Object, e As EventArgs) Handles txtHasta.Leave
        Try
            If txtHasta.Text = "" Then
            Else
                txtHasta.Text = CDbl(txtHasta.Text).ToString("C")
            End If

        Catch ex As Exception
            txtHasta.Text = ""
        End Try
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        If IDRetISR.Text = "" Then 'Si no hay un producto seleccionado
            If Permisos(1) = 0 Then
                MessageBox.Show("Usted no tiene los privilegios y/o permisos suficientes para guardar nuevos registros en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar la nueva retención de ISR?", "Guardar Rango Retención ISR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "INSERT INTO RetISR (Desde,Hasta,Tasa,Nulo) VALUES ('" + txtDesde.Text + "','" + txtHasta.Text + "','" + txtTasa.Text + "','" + Nulo.Text + "')"
                GuardarDatos1()
                ConvertCurrent()
                MessageBox.Show("Registro guardado satisfactoriamente", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                RefrescarISR()
                LimpiarDatos()
            End If
        Else
            If Permisos(2) = 0 Then
                MessageBox.Show("Usted no posee los privilegios y/o permisos suficientes para modificar los registros existentes en la base de datos.", "No tiene los permisos necesarios", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim Result As MsgBoxResult = MessageBox.Show("Desea guardar los cambios realizados en el registro?", "Guardar Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then
                ConvertDouble()
                sqlQ = "UPDATE RETISR SET Desde='" + txtDesde.Text + "',Hasta='" + txtHasta.Text + "',Tasa='" + txtTasa.Text + "',Nulo='" + Nulo.Text + "' WHERE IDRetISR= (" + IDRetISR.Text + ")"
                GuardarDatos1()
                ConvertCurrent()
                MessageBox.Show("Los cambios se realizaron satisfactoriamente.", "Guardado Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                RefrescarISR()
                LimpiarDatos()
            End If
        End If

   
    End Sub

    Private Sub GuardarDatos1()
        Try
            Con.Open()
            cmd = New MySqlCommand(sqlQ, Con)
            cmd.ExecuteNonQuery()
            Con.Close()
        Catch ex As Exception
            Con.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try


    End Sub

    Private Sub ConvertDouble()
        txtDesde.Text = CDbl(txtDesde.Text)
        txtHasta.Text = CDbl(txtHasta.Text)
        txtTasa.Text = CDbl(Replace(txtTasa.Text, "%", "")) / 100
    End Sub

    Private Sub ConvertCurrent()
        txtDesde.Text = CDbl(txtDesde.Text).ToString("C")
        txtHasta.Text = CDbl(txtHasta.Text).ToString("C")
        txtTasa.Text = CDbl(txtTasa.Text).ToString("P2")
    End Sub

    Private Sub txtTasa_Enter(sender As Object, e As EventArgs) Handles txtTasa.Enter
        Try
            If txtTasa.Text = "" Then
            Else
                txtTasa.Text = CDbl(Replace(txtTasa.Text, "%", "")) / 100
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtTasa_Leave(sender As Object, e As EventArgs) Handles txtTasa.Leave
        Try
            If txtTasa.Text = "" Then
            Else
                txtTasa.Text = CDbl(txtTasa.Text).ToString("P2")
            End If
        Catch ex As Exception
            txtTasa.Text = ""
        End Try
    End Sub

    Private Sub BuscarRango()
        Dim x As Integer = 0
        Dim Counter As Integer = DgvISR.Rows.Count
        Dim Desde, Hasta As Double

        Try

Inicio:
            If x = Counter Then
                GoTo Fin
            End If

            Desde = CDbl(DgvISR.Rows(x).Cells(1).Value)
            Hasta = CDbl(DgvISR.Rows(x).Cells(2).Value)

            If CDbl(txtDesde.Text) <= Desde Or CDbl(txtHasta.Text) <= Hasta Then
                MessageBox.Show("El rango especificado repetiría con el valor indicado en el código No. " & DgvISR.Rows(x).Cells(0).Value)
                Exit Sub
            Else
            End If


            x = x + 1
            GoTo Inicio
Fin:

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDesde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDesde.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub txtHasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHasta.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

    Private Sub txtTasa_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTasa.KeyPress
        Dim Car% = Asc(e.KeyChar)
        Select Case Car

            Case 8, 46
            Case 48 To 57
            Case Else
                e.KeyChar = Nothing
        End Select

    End Sub

End Class