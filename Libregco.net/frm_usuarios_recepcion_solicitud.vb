Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.IO

Public Class frm_usuarios_recepcion_solicitud
    Dim IDSucursal, IDAlmacen, IDEmpleadoA As String
    Friend Con As New MySqlConnection(CnString)
    Friend sqlQ As String
    Friend cmd As MySqlCommand
    Friend Ds, DsConversaciones As New DataSet
    Friend Adaptador As MySqlDataAdapter
    Dim Arrastre As Boolean
    Dim ex, ey As Integer

    Private Sub frm_usuarios_recepcion_solicitud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        txtBuscarUsuarios.Text = ""
        txtDescripcion.Text = ""
        FillSucursal()
        FillAlmacen()
        FillUsers()
        ControlSuperClave = 0
    End Sub

    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub lblEncabezado_MouseMove(sender As Object, e As MouseEventArgs)
        'Si el formulario no tiene borde (FormBorderStyle = none) la siguiente linea funciona bien
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
            If Arrastre Then Me.Location = Me.PointToScreen(New Point(MousePosition.X - Me.Location.X - ex, MousePosition.Y - Me.Location.Y - ey))
        End If

        'pero si quieres dejar los bordes y la barra de titulo entonces es necesario descomentar la siguiente linea y comentar la anterior, osea ponerle el apostrofe
        'If Arrastre Then Me.Location = Me.PointToScreen(New Point(Me.MousePosition.X - Me.Location.X - ex - 8, Me.MousePosition.Y - Me.Location.Y - ey - 60))
    End Sub

    Private Sub lblEncabezado_MouseDown(sender As Object, e As MouseEventArgs)
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
            ex = e.X
            ey = e.Y
            Arrastre = True
        End If
    End Sub

    Private Sub lblEncabezado_MouseUp(sender As Object, e As MouseEventArgs)
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
            Arrastre = False
        End If
    End Sub

    Private Sub txtBuscarUsuarios_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarUsuarios.TextChanged
        If txtBuscarUsuarios.Text <> "" Then
            Button6.Visible = True
        Else
            Button6.Visible = False
        End If

        FillUsers()
    End Sub

    Private Sub FillUsers()
        DgvEmpleados.Rows.Clear()
        ConMixta.Open()
        Dim Consulta As New MySqlCommand("Select IDEmpleado,Nombre,concat(CargosEmp.Cargo,'/',Puesto) as Puesto,if(Conectado=1,'Conectado','Desconectado')  as Estado from" & SysName.Text & "Empleados INNER JOIN Libregco.CargosEmp on Empleados.IDCargo=CargosEmp.IDCargo Where Empleados.Nulo=0 and IDSucursal like '%" + IDSucursal + "%' and IDAlmacen like '%" + IDAlmacen + "%' and Nombre like '%" + txtBuscarUsuarios.Text + "%' and IDEmpleado<>'" + DtEmpleado.Rows(0).item("IDEmpleado").ToString() + "' ORDER BY Nombre ASC", ConMixta)
        Dim LectorDocumentos As MySqlDataReader = Consulta.ExecuteReader

        While LectorDocumentos.Read
            DgvEmpleados.Rows.Add(LectorDocumentos.GetValue(0), LectorDocumentos.GetValue(1), LectorDocumentos.GetValue(2), LectorDocumentos.GetValue(3))
        End While

        LectorDocumentos.Close()
        ConMixta.Close()
    End Sub

    Private Sub FillSucursal()

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Sucursal FROM Sucursal Where Nulo=0 ORDER BY Sucursal ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Sucursal")
        cbxSucursal.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Sucursal")

        For Each Fila As DataRow In Tabla.Rows
            cbxSucursal.Items.Add(Fila.Item("Sucursal"))
        Next

        If Tabla.Rows.Count = 1 Then
            cbxSucursal.SelectedIndex = 0

        ElseIf Tabla.Rows.Count > 1 Then
            Con.Open()
            cmd = New MySqlCommand("SELECT Sucursal FROM Sucursal WHERE IDSucursal= '" + DtEmpleado.Rows(0).item("IDSucursal").ToString() + "'", Con)
            Dim UserSucursal As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            cbxSucursal.Text = UserSucursal
        Else
            MessageBox.Show("No se detectaron sucursales disponibles. Esto se puede deber a que no se encuentra un usuario definido en el formulario o porque no se encontraron almacenes en la base de datos." & vbNewLine & vbNewLine & "Por favor revise las condiciones o el sistema generará errores en la facturación.", "Sé detectó un fallo crítico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub FillAlmacen()

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Almacen FROM Almacen Where Desactivar=0 ORDER BY Almacen.Almacen ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Almacen")
        cbxAlmacen.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Almacen")

        For Each Fila As DataRow In Tabla.Rows
            cbxAlmacen.Items.Add(Fila.Item("Almacen"))
        Next

        If Tabla.Rows.Count = 1 Then
            cbxAlmacen.SelectedIndex = 0

        ElseIf Tabla.Rows.Count > 1 Then
            Con.Open()
            cmd = New MySqlCommand("SELECT Almacen FROM Almacen WHERE IDAlmacen= '" + DtEmpleado.Rows(0).item("IDAlmacen").ToString() + "'", Con)
            Dim UserAlmacen As String = Convert.ToString(cmd.ExecuteScalar())
            Con.Close()

            cbxAlmacen.Text = UserAlmacen

        Else
            MessageBox.Show("No se detectaron almacenes disponibles. Esto se puede deber a que no se encuentra un usuario definido en el formulario o porque no se encontraron almacenes en la base de datos." & vbNewLine & vbNewLine & "Por favor revise las condiciones o el sistema generará errores en la facturación.", "Sé detectó un fallo crítico", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub cbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAlmacen.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + cbxAlmacen.SelectedItem + "'", Con)
        IDAlmacen = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        FillUsers()
    End Sub

    Private Sub cbxSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSucursal.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDSucursal FROM Sucursal WHERE Sucursal= '" + cbxSucursal.SelectedItem + "'", Con)
        IDSucursal = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        FillUsers()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtDescripcion.Text = "" Then
            MessageBox.Show("Por favor haga una breve descripción del caso y/o coloque las informaciones del cliente para verificar los motivos y razones del control de autorizacines.", "Coloque una breve descripción", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If DgvEmpleados.SelectedRows.Count > 0 Then
            frm_autorizacion_acciones.IDEmpleadoAvisa.Text = DgvEmpleados.CurrentRow.Cells(0).Value
            frm_autorizacion_acciones.Descripcion.Text = txtDescripcion.Text
            ControlSuperClave = 1
            Close()
        Else
            MessageBox.Show("Seleccione el usuario a quien desea notificar la solicitud de autorización.", "Seleccione el usuario a enviar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frm_autorizacion_acciones.IDEmpleadoAvisa.Text = DtEmpleado.Rows(0).item("IDEmpleado").ToString()
        frm_autorizacion_acciones.Descripcion.Text = txtDescripcion.Text
        ControlSuperClave = 1
        Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        ControlSuperClave = 0
        Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txtBuscarUsuarios.Text = ""
        txtBuscarUsuarios.Focus()
    End Sub
End Class