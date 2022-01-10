Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_vendedor_prefacturacion
    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue
    Dim Permisos As New ArrayList
    Dim Connon As New MySqlConnection(CnGeneral)
    Dim Password, FactorNumerico As String
    Dim ex, ey As Integer
    Dim Arrastre As Boolean

    Private Sub FillVendedores()
        Try
            Dim DsTemp As New DataSet

            cbxVendedor.DataSource = Nothing
            cbxVendedor.Items.Clear()

            ConMixta.Open()
            cmd = New MySqlCommand("SELECT IDEmpleado,Nombre FROM" & SysName.Text & "Empleados WHERE Nulo=0 and EsVendedor=1 ORDER BY Nombre ASC", ConMixta)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTemp, "Empleados")
            cbxVendedor.ValueMember = "IDEmpleado"
            cbxVendedor.DisplayMember = "Nombre"
            cbxVendedor.DataSource = DsTemp.Tables("Empleados")
            ConMixta.Close()

            If cbxVendedor.Items.Count = 0 Then
                MessageBox.Show("No se pudieron cargar los vendedores para definirla en la factura." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
              
            Else
                cbxVendedor.Focus()
            End If

        Catch ex As Exception
            ConMixta.Close()
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub cbxVendedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxVendedor.SelectedIndexChanged
        Try
            If cbxVendedor.Text <> "" Then
                txtPassword.Text = ""
                lblStatusBar.Text = "Listo"
                lblStatusBar.ForeColor = Color.Black

                Dim DsTemp As New DataSet
                Connon.Open()
                cmd = New MySqlCommand("SELECT IDEmpleado,Password,FactorNumerico from" & SysName.Text & "Empleados where IDEmpleado='" + cbxVendedor.SelectedValue.ToString + "'", Connon)
                Adaptador = New MySqlDataAdapter(cmd)
                Adaptador.Fill(DsTemp, "Empleados")
                Connon.Close()

                Dim Tabla As DataTable = DsTemp.Tables("Empleados")

                Password = Tabla.Rows(0).Item(1)
                FactorNumerico = Tabla.Rows(0).Item(2)

                Tabla.Dispose()
                DsTemp.Dispose()
                txtPassword.Focus()

                If LookEmployeesValidated(cbxVendedor.SelectedValue.ToString) = 1 Then
                    txtPassword.Text = FactorNumerico
                    chkRecordarme.Checked = True
                    Button1.Focus()
                End If
             
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cbxVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxVendedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub chkRecordarme_KeyDown(sender As Object, e As KeyEventArgs) Handles chkRecordarme.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If cbxVendedor.Text = "" Then
            MessageBox.Show("Seleccione el vendedor que efectua la venta.", "Elija el vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            cbxVendedor.Focus()
            cbxVendedor.DroppedDown = True
            Exit Sub
        End If

        If txtPassword.Text = "" Then
            MessageBox.Show("Escriba la clave o contraseña del vendedor para autorizar el proceso.", "Credenciales del vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            lblStatusBar.ForeColor = Color.Black
            lblStatusBar.Text = "Escriba la clave o contraseña del vendedor para autorizar el proceso."
            txtPassword.Focus()
        Else
            If Password = txtPassword.Text Or FactorNumerico = txtPassword.Text Then
                If Me.Owner.Owner.Name = frm_prefacturacion.Name Then
                    frm_prefacturacion_detalles.txtIDVendedor.Text = cbxVendedor.SelectedValue.ToString
                    frm_prefacturacion_detalles.txtVendedor.Text = cbxVendedor.Text
                    frm_prefacturacion_detalles.ChangedCodeEmployee = False

                ElseIf Me.Owner.Owner.Name = frm_mdi_prefacturacion.Name Then
                    DirectCast(Owner, frm_prefacturacion_detalles).txtIDVendedor.Text = cbxVendedor.SelectedValue.ToString
                    DirectCast(Owner, frm_prefacturacion_detalles).txtVendedor.Text = cbxVendedor.Text
                    DirectCast(Owner, frm_prefacturacion_detalles).ChangedCodeEmployee = False

                End If


                If chkRecordarme.Checked = True Then
                    SaveEmployeesPassword(cbxVendedor.SelectedValue.ToString)
                Else
                    If LookEmployeesValidated(cbxVendedor.SelectedValue.ToString) = 1 Then
                        RemoveEmployeesValidated(cbxVendedor.SelectedValue.ToString)
                    End If
                End If

                Me.Close()

            Else
                MessageBox.Show("La contraseña es incorrecta. Por favor vuelva a intentarlo.", "Contraseña Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                lblStatusBar.ForeColor = Color.Red
                lblStatusBar.Text = "La contraseña es incorrecta. Por favor vuelva a intentarlo."
                txtPassword.Focus()
                txtPassword.SelectAll()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        cbxVendedor.DataSource = Nothing
        cbxVendedor.Items.Clear()

        txtPassword.Clear()

        If Me.Owner.Owner.Name = frm_prefacturacion.Name Then
            frm_prefacturacion_detalles.txtIDVendedor.Clear()
            frm_prefacturacion_detalles.txtVendedor.Clear()

        ElseIf Me.Owner.Owner.Name = frm_mdi_prefacturacion.Name Then
            DirectCast(Owner, frm_prefacturacion_detalles).txtIDVendedor.Clear()
            DirectCast(Owner, frm_prefacturacion_detalles).txtVendedor.Clear()

        End If




        Me.Close()
    End Sub

    Private Sub frm_vendedor_prefacturacion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            btnClose.PerformClick()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                Button1.PerformClick()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString & "txtPassword_KeyPress")
        End Try
    End Sub

    Private Sub chkRecordarme_CheckedChanged(sender As Object, e As EventArgs) Handles chkRecordarme.CheckedChanged
        If chkRecordarme.Checked = True Then
            Label3.Visible = True
        Else
            Label3.Visible = False
        End If
    End Sub

    Private Sub chkRecordarme_Click(sender As Object, e As EventArgs) Handles chkRecordarme.Click
        If chkRecordarme.Checked = False Then
            chkRecordarme.Checked = True

        Else
            chkRecordarme.Checked = False

        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If Password = txtPassword.Text Or FactorNumerico = txtPassword.Text Then
            chkRecordarme.Enabled = True
            lblStatusBar.ForeColor = Color.Green
            lblStatusBar.Text = "La contraseña es correcta."
        Else
            chkRecordarme.Enabled = False
            chkRecordarme.Checked = False
            Label3.Visible = False
        End If
    End Sub

    Private Sub Label2_MouseDown(sender As Object, e As MouseEventArgs) Handles Label2.MouseDown
        ex = e.X
        ey = e.Y
        Arrastre = True
    End Sub

    Private Sub Label2_MouseUp(sender As Object, e As MouseEventArgs) Handles Label2.MouseUp
        arrastre = False
    End Sub

    Private Sub Label2_MouseMove(sender As Object, e As MouseEventArgs) Handles Label2.MouseMove
        'Si el formulario no tiene borde (FormBorderStyle = none) la siguiente linea funciona bien

        If Arrastre Then Me.Location = Me.PointToScreen(New Point(MousePosition.X - Me.Location.X - ex, MousePosition.Y - Me.Location.Y - ey))

        'pero si quieres dejar los bordes y la barra de titulo entonces es necesario descomentar la siguiente linea y comentar la anterior, osea ponerle el apostrofe

        'If Arrastre Then Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - ex - 8, Me.MousePosition.Y - Me.Location.Y - ey - 60))

    End Sub

    Private Sub cbxVendedor_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cbxVendedor.DrawItem
        Dim TextColor As New Color
        Dim DisplayValue As String = ""

        Dim TmpCon As New MySqlConnection(CnGeneral)

        If e.Index > -1 Then
            DisplayValue = cbxVendedor.GetItemText(cbxVendedor.Items(e.Index))

            TmpCon.Open()

            cmd = New MySqlCommand("Select IDEmpleado From" & SysName.Text & "Empleados Where Nombre='" + DisplayValue + "'", TmpCon)
            Dim IDEmployee As String = Convert.ToString(cmd.ExecuteScalar())

            TmpCon.Close()

            If LookEmployeesValidated(IDEmployee) = 1 Then
                TextColor = Color.Green
            Else
                TextColor = Color.Black
            End If
        End If

        Dim myBrush As SolidBrush = New SolidBrush(TextColor)
    
        ' Draw the background of the item.
        e.DrawBackground()

        e.Graphics.DrawString(DisplayValue, cbxVendedor.Font, myBrush, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))

        ' Draw the focus rectangle if the mouse hovers over an item.
        e.DrawFocusRectangle()
    End Sub

    Private Sub frm_vendedor_prefacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Label2.BackColor = frm_inicio.lblSeleccion.BackColor
        chkRecordarme.Checked = False
        FillVendedores()

        If Me.Owner.Owner.Name = frm_prefacturacion.Name Then
            If frm_prefacturacion_detalles.txtIDVendedor.Text <> "" Then
                cbxVendedor.SelectedValue = frm_prefacturacion_detalles.txtIDVendedor.Text
            End If

        ElseIf Me.Owner.Owner.Name = frm_mdi_prefacturacion.name Then
            If DirectCast(Me.Owner, frm_prefacturacion_detalles).txtIDVendedor.Text <> "" Then
                cbxVendedor.SelectedValue = DirectCast(Me.Owner, frm_prefacturacion_detalles).txtIDVendedor.Text
            End If
        End If

        cbxVendedor.Focus()

    End Sub
End Class