Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing

Public Class frm_consulta_combinada_clientes

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, DsClientes As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim ClientesCommand As String = "SELECT FacturaDatos.IDFacturaDatos,FacturaDatos.SecondID,FacturaDatos.Fecha,Clientes.IDCliente,Clientes.Nombre,Clientes.Apodo,FacturaArticulos.Cantidad,Medida.Medida,FacturaArticulos.IDFactArt,FacturaArticulos.IDArticulo,Articulos.Descripcion,FacturaArticulos.Importe FROM" & SysName.Text & "FacturaArticulos INNER JOIN" & SysName.Text & "FacturaDatos on FacturaArticulos.IDFactura=FacturaDatos.IDFacturaDatos INNER JOIN Libregco.Clientes on FacturaDatos.IDCliente=Clientes.IDCliente INNER JOIN Libregco.Calificacion on Clientes.IDCalificacion=Calificacion.IDCalificacion INNER JOIN Libregco.Articulos on FacturaArticulos.IDArticulo=Articulos.IDArticulo INNER JOIN Libregco.Medida on FacturaArticulos.IDMedida=Medida.IDMedida"
    Dim Permisos As New ArrayList
 
    'Set ID's of cbx
    Dim FullCommand, Nombre, Direccion, IDTipoIdentificacion, IDGenero, IDNacionalidad, IDEstadoCivil, IDOcupacion, IDProvincia, IDMunicipio, IDTipodeCredito, IDGrupoClientes, IDTipoNCF, IDCalificacion, IDCobrador, IDVendedor, IDUsuario, IDCondicion, IDAlmacen, IDChofer, IDVehiculo, IDArticulo, IDMedida As String
    Dim A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, A15, A16, A17, A18, A19, A20, A21 As String
    'Query values
    Dim NombreValue, DireccionValue, TipoIdentificacionValue, GeneroValue, NacionalidadValue, EstadoCivilValue, OcupacionValue, ProvinciaValue, MunicipioValue, TipodeCreditoValue, GrupoClientesValue, TipoNCFValue, CalificacionValue, CobradorValue, VendedorValue, UsuarioValue, CondicionValue, AlmacenValue, ChoferValue, VehiculoValue, ArticuloValue, MedidaValue As String


    Private Sub frm_consulta_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarLibregco()
        'Me.WindowState = CheckWindowState()
        ActualizarTodo()
        Permisos = PasarPermisos(Me.Tag)
        cmd = New MySqlCommand(ClientesCommand & " LIMIT " & DTConfiguracion.Rows(28 - 1).Item("Value2Int"), ConMixta)
        RefrescarTabla()
    End Sub

    Private Sub ActualizarTodo()
        FillTipoIdentificacion()
        FillGenero()
        FillNacionalidad()
        FillEstadoCivil()
        FillOcupacion()
        FillProvincia()
        FillTipodeCredito()
        FillGrupoClientes()
        FillTipodeNCF()
        FillCalificacion()
        FillCobrador()
        FillVendedor()
        FillUsuario()
        FillCondicion()
        FillAlmacen()
        FillChofer()
        FillVehiculo()
        FillArticulo()
        FillMedida()
        Panel1.BackColor = frm_inicio.lblSeleccion.BackColor
    End Sub

    Private Sub FillGrupoClientes()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM grupocxc ORDER BY Descripcion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "grupocxc")
        cbxGrupoClientes.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("grupocxc")
        For Each Fila As DataRow In Tabla.Rows
            cbxGrupoClientes.Items.Add(Fila.Item("Descripcion"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se encontraron grupos de clientes hábiles en la base de datos. Inserte grupo de clientes hábiles para procesar los registros de los clientes.", "No se encontraron estados civiles", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If

    End Sub

    Private Sub FillTipodeCredito()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM tipocredito ORDER BY Descripcion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "tipocredito")
        cbxTipoCredito.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("tipocredito")
        For Each Fila As DataRow In Tabla.Rows
            cbxTipoCredito.Items.Add(Fila.Item("Descripcion"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se encontraron tipos de créditos hábiles en la base de datos. Inserte tipos de créditos hábiles para procesar los registros de los clientes.", "No se encontraron estados civiles", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If

    End Sub

    Private Sub FillCalificacion()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Calificacion FROM Calificacion ORDER BY IDCalificacion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Calificacion")
        cbxCalificacion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Calificacion")
        For Each Fila As DataRow In Tabla.Rows
            cbxCalificacion.Items.Add(Fila.Item("Calificacion"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se encontraron calificaciones hábiles en la base de datos. Inserte calificaciones hábiles para procesar los registros de los clientes.", "No se encontraron estados civiles", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If

    End Sub

    Private Sub FillMedida()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Abreviatura from Medida", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Medida")
        cbxMedida.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Medida")
        For Each Fila As DataRow In Tabla.Rows
            cbxMedida.Items.Add(Fila.Item("Abreviatura"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se encontraron medidas hábiles en la base de datos. Inserte medidas hábiles para procesar los registros de los clientes.", "No se encontraron estados civiles", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If
    End Sub

    Private Sub FillArticulo()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Descripcion from Articulos", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Articulos")
        cbxArticulos.Items.Clear()
        ConLibregco.Close()
        Dim Tabla As DataTable = Ds.Tables("Articulos")

        For Each Fila As DataRow In Tabla.Rows
            cbxArticulos.Items.Add(Fila.Item("Descripcion"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se encontraron artículos hábiles en la base de datos. Inserte productos hábiles para procesar los registros de los clientes.", "No se encontraron estados civiles", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If

    End Sub

    Private Sub FillCondicion()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("Select Condicion from Condicion", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Condicion")
        cbxCondicion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Condicion")
        For Each Fila As DataRow In Tabla.Rows
            cbxCondicion.Items.Add(Fila.Item("Condicion"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se encontraron condiciones hábiles en la base de datos. Inserte condiciones hábiles para procesar los registros de los clientes.", "No se encontraron estados civiles", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If

    End Sub

    Private Sub FillVehiculo()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT DatoVehiculo FROM Vehiculo ORDER BY Marca ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Vehiculo")
        cbxVehiculo.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Vehiculo")
        For Each Fila As DataRow In Tabla.Rows
            cbxVehiculo.Items.Add(Fila.Item("DatoVehiculo"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se pudo cargar un vehículo para definirlo en la factura ya que no se encontraron resultados de vehículos activos. Por favor cree un registros de vehículos." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If

    End Sub

    Private Sub FillAlmacen()

        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Almacen FROM Almacen ORDER BY Almacen ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Almacen")
        cbxAlmacen.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Almacen")
        For Each Fila As DataRow In Tabla.Rows
            cbxAlmacen.Items.Add(Fila.Item("Almacen"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se pudo cargar un almacén para definirla en la factura ya que no se encontraron resultados de almacenes. Por favor cree un registro de almacén." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If


    End Sub

    Private Sub FillUsuario()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Nombre FROM Empleados ORDER BY Nombre ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Empleados")
        cbxUsuario.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Empleados")
        For Each Fila As DataRow In Tabla.Rows
            cbxUsuario.Items.Add(Fila.Item("Nombre"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se encontraron registros de usuarios activos en el sistema. Registre al mnenos un empleado para poder procesar los registros de clientes.", "No se encontraron cobradores", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        End If

    End Sub

    Private Sub FillChofer()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT Nombre FROM Empleados ORDER BY Nombre ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "Empleados")
            cbxChofer.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("Empleados")
            For Each Fila As DataRow In Tabla.Rows
                cbxChofer.Items.Add(Fila.Item("Nombre"))
            Next

            If Tabla.Rows.Count > 0 Then
            Else
                MessageBox.Show("No se pudo cargar un chofer para definirla en la factura ya que no se encontraron resultados de empleados bajo esa condición." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillVendedor()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Nombre FROM Empleados ORDER BY Nombre ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Empleados")
        cbxVendedor.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Empleados")
        For Each Fila As DataRow In Tabla.Rows
            cbxVendedor.Items.Add(Fila.Item("Nombre"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se pudo cargar un vendedor para definirla en la factura ya que no se encontraron resultados de empleados bajo esa condición." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If

    End Sub

    Private Sub FillTipodeNCF()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT TipoComprobante FROM ComprobanteFiscal where IDContexto=1 ORDER BY TipoComprobante ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "ComprobanteFiscal")
            cbxTipoComprobante.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("ComprobanteFiscal")
            For Each Fila As DataRow In Tabla.Rows
                cbxTipoComprobante.Items.Add(Fila.Item("TipoComprobante"))
            Next

            If Tabla.Rows.Count > 0 Then
            Else
                MessageBox.Show("No se pudo cargar ningún tipo de comprobante fiscal para definirla en la factura ya que no se encontraron resultados en la base de datos. Cree los tipos de comprobantes fiscales." & vbNewLine & vbNewLine & "La factura no se podrá generar hasta que se cumpla la condición.", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Close()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillCobrador()
        Ds.Clear()
        Con.Open()
        cmd = New MySqlCommand("SELECT Nombre FROM Empleados ORDER BY Nombre ASC", Con)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Empleados")
        cbxCobrador.Items.Clear()
        Con.Close()

        Dim Tabla As DataTable = Ds.Tables("Empleados")
        For Each Fila As DataRow In Tabla.Rows
            cbxCobrador.Items.Add(Fila.Item("Nombre"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se encontraron registros de cobrador activos en el sistema. Registre un cobrador para poder procesar los registros de clientes.", "No se encontraron cobradores", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        End If

    End Sub

    Private Sub FillProvincia()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Provincia FROM Provincias ORDER BY Provincia ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Provincias")
        cbxProvincia.Items.Clear()
        cbxMunicipio.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Provincias")

        For Each Fila As DataRow In Tabla.Rows
            cbxProvincia.Items.Add(Fila.Item("Provincia"))
        Next

        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron provincias hábiles en la base de datos. Inserte provincias para procesar los registros de los clientes.", "No se encontraron provincias", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If
    End Sub

    Private Sub FillMunicipio()

        Ds1.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Municipio FROM Municipios INNER JOIN Provincias on Municipios.IDProvincia=Provincias.IDProvincia  WHERE Provincias.Provincia= '" + cbxProvincia.SelectedItem + "' ORDER BY Municipio ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds1, "Municipios")
        cbxMunicipio.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds1.Tables("Municipios")
        For Each Fila As DataRow In Tabla.Rows
            cbxMunicipio.Items.Add(Fila.Item("Municipio"))
        Next

        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron municipios hábiles en la base de datos. Inserte municipios para procesar los registros de los clientes.", "No se encontraron municipios", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        ElseIf Tabla.Rows.Count = 1 Then
            cbxMunicipio.SelectedIndex = 0
        End If

    End Sub

    Private Sub FillTipoIdentificacion()

        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Descripcion FROM TipoIdentificacion ORDER BY Descripcion", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "TipoIdentificacion")
        cbxTipoIdentificacion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("TipoIdentificacion")
        For Each Fila As DataRow In Tabla.Rows
            cbxTipoIdentificacion.Items.Add(Fila.Item("Descripcion"))
        Next

        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron tipos de indentifiación hábiles en la base de datos. Inserte tipos de identificación hábiles para procesar los registros de los clientes.", "No se encontraron municipios", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If
    End Sub

    Private Sub FillNacionalidad()

        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Nacionalidad FROM Nacionalidad ORDER BY Nacionalidad ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Nacionalidad")
        cbxNacionalidad.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Nacionalidad")
        For Each Fila As DataRow In Tabla.Rows
            cbxNacionalidad.Items.Add(Fila.Item("Nacionalidad"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se encontraron nacionalidades hábiles en la base de datos. Inserte nacionalidades para procesar los registros de los clientes.", "No se encontraron nacionalidades", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If

    End Sub

    Private Sub FillGenero()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Genero FROM Genero ORDER BY Genero ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Genero")
        cbxGenero.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Genero")
        For Each Fila As DataRow In Tabla.Rows
            cbxGenero.Items.Add(Fila.Item("Genero"))
        Next

        If Tabla.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron géneros hábiles en la base de datos. Inserte géneros hábiles para procesar los registros de los clientes.", "No se encontraron géneros", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If
    End Sub

    Private Sub FillOcupacion()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT Ocupacion FROM Ocupacion ORDER BY Ocupacion ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "Ocupacion")
        cbxOcupacion.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("Ocupacion")

        For Each Fila As DataRow In Tabla.Rows
            cbxOcupacion.Items.Add(Fila.Item("Ocupacion"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se encontraron ocupaciones hábiles en la base de datos. Inserte ocupaciones hábiles para procesar los registros de los clientes.", "No se encontraron ocupaciones", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If

    End Sub

    Private Sub FillEstadoCivil()
        Ds.Clear()
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT EstadoCivil FROM EstadoCivil ORDER BY EstadoCivil ASC", ConLibregco)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "EstadoCivil")
        cbxEstadoCivil.Items.Clear()
        ConLibregco.Close()

        Dim Tabla As DataTable = Ds.Tables("EstadoCivil")

        For Each Fila As DataRow In Tabla.Rows
            cbxEstadoCivil.Items.Add(Fila.Item("EstadoCivil"))
        Next

        If Tabla.Rows.Count > 0 Then
        Else
            MessageBox.Show("No se encontraron estados civiles hábiles en la base de datos. Inserte estados civiles hábiles para procesar los registros de los clientes.", "No se encontraron estados civiles", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End If

    End Sub

    Private Sub RefrescarTabla()
        Try
            DsClientes.Clear()
            ConMixta.Open()
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsClientes, "Clientes")
            DgvClientes.DataSource = DsClientes
            DgvClientes.DataMember = "Clientes"
            ConMixta.Close()
            PropiedadColumnsDgv()
            lblStatusBar.Text = "Se encontraron: " & DgvClientes.Rows.Count & " resultados"
            DgvClientes.ClearSelection()
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
            Con.Close()
        End Try
    End Sub

    Private Sub PropiedadColumnsDgv()
        Dim DatagridWidth As Double = (DgvClientes.Width - DgvClientes.RowHeadersWidth) / 100
        With DgvClientes
            .Columns("IDFacturaDatos").Visible = False

            .Columns("SecondID").HeaderText = "No. Factura"
            .Columns("SecondID").Width = DatagridWidth * 8

            .Columns("Fecha").Width = DatagridWidth * 7
            .Columns("Fecha").HeaderText = "Fecha"

            .Columns("IDCliente").HeaderText = "Código"
            .Columns("IDCliente").Width = DatagridWidth * 5

            .Columns("Nombre").HeaderText = "Nombre"
            .Columns("Nombre").Width = DatagridWidth * 22

            .Columns("Apodo").HeaderText = "Apodo"
            .Columns("Apodo").Width = DatagridWidth * 7

            .Columns("Cantidad").Width = DatagridWidth * 4
            .Columns("Cantidad").HeaderText = "Cant."

            .Columns("Medida").Width = DatagridWidth * 5
            .Columns("Medida").HeaderText = "Medida"

            .Columns("IDFactArt").Visible = False

            .Columns("IDArticulo").Width = DatagridWidth * 5
            .Columns("IDArticulo").HeaderText = "Código"

            .Columns("Descripcion").Width = DatagridWidth * 25
            .Columns("Descripcion").HeaderText = "Descripción"

            .Columns("Importe").Width = DatagridWidth * 12
            .Columns("Importe").HeaderText = "Importe"
            .Columns("Importe").DefaultCellStyle.Format = "C"

        End With

        If Me.WindowState = FormWindowState.Normal Then
            DgvClientes.DefaultCellStyle.Font = New Font("Segoe UI", 7, FontStyle.Regular)
            DgvClientes.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 7, FontStyle.Regular)
        Else
            DgvClientes.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            DgvClientes.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)

        End If
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub Fecha_Tick(sender As Object, e As EventArgs) Handles Fecha.Tick
        lblDate.Text = Today.ToLongDateString & " " & TimeOfDay
    End Sub

    Private Sub frm_consulta_clientes_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Try
            PropiedadColumnsDgv()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgvClientes_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DgvClientes.RowPostPaint
        Try
            'Captura el numero de filas del datagridview
            Dim RowsNumber As String = (e.RowIndex + 1).ToString
            While RowsNumber.Length < DgvClientes.RowCount.ToString.Length
                RowsNumber = "0" & RowsNumber
            End While
            Dim size As SizeF = e.Graphics.MeasureString(RowsNumber, Me.Font)
            If DgvClientes.RowHeadersWidth < CInt(size.Width + 20) Then
                DgvClientes.RowHeadersWidth = CInt(size.Width + 20)
            End If
            Dim ob As Brush = SystemBrushes.ControlText
            e.Graphics.DrawString(RowsNumber, Me.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        VerificarNombre()
    End Sub

    Private Sub VerificarNombre()
        If txtNombre.Text = "" Then
            NombreValue = ""
        Else
            NombreValue = " Clientes.Nombre like '%" & txtNombre.Text & "%' or Clientes.Apodo like '%" & txtNombre.Text & "%'"
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxProvincia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProvincia.SelectedIndexChanged
        FillMunicipio()

        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDProvincia FROM Provincias WHERE Provincia= '" + cbxProvincia.SelectedItem + "'", ConLibregco)
        IDProvincia = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        VerificarProvincia()
    End Sub

    Private Sub VerificarProvincia()
        If IDProvincia = "" Then
            ProvinciaValue = ""
        Else
            ProvinciaValue = " Clientes.IDProvincia=" & IDProvincia & " "
        End If

        ConstructorSQL()
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoRegistroToolStripMenuItem.Click
        btnLimpiar.PerformClick()
    End Sub

    Private Sub cbxTipoIdentificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoIdentificacion.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoIdentificacion FROM TipoIdentificacion WHERE Descripcion= '" + cbxTipoIdentificacion.SelectedItem + "'", ConLibregco)
        IDTipoIdentificacion = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        VerificarTipoIdentificacion()
    End Sub

    Private Sub VerificarTipoIdentificacion()
        If IDTipoIdentificacion = "" Then
            TipoIdentificacionValue = ""
        Else
            TipoIdentificacionValue = " Clientes.IDTipoIdentificacion=" & IDTipoIdentificacion & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxGenero_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxGenero.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDGenero FROM Genero WHERE Genero= '" + cbxGenero.SelectedItem + "'", ConLibregco)
        IDGenero = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        VerificarGenero()
    End Sub

    Private Sub VerificarGenero()
        If IDGenero = "" Then
            GeneroValue = ""
        Else
            GeneroValue = " Clientes.IDGenero=" & IDGenero & " "
        End If
        ConstructorSQL()

    End Sub

    Private Sub cbxNacionalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNacionalidad.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDNacionalidad FROM Nacionalidad WHERE Nacionalidad= '" + cbxNacionalidad.SelectedItem + "'", ConLibregco)
        IDNacionalidad = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

    End Sub

    Private Sub VerificarNacionalidad()
        If IDNacionalidad = "" Then
            NacionalidadValue = ""
        Else
            NacionalidadValue = " Clientes.IDNacionalidad=" & IDNacionalidad & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxEstadoCivil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEstadoCivil.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCivil FROM EstadoCivil WHERE EstadoCivil= '" + cbxEstadoCivil.SelectedItem + "'", ConLibregco)
        IDEstadoCivil = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        VerificarEstadoCivil()
    End Sub

    Private Sub VerificarEstadoCivil()
        If IDEstadoCivil = "" Then
            EstadoCivilValue = ""
        Else
            EstadoCivilValue = " Clientes.IDCivil=" & IDEstadoCivil & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxOcupacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxOcupacion.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDOcupacion FROM Ocupacion WHERE Ocupacion= '" + cbxOcupacion.SelectedItem + "'", ConLibregco)
        IDOcupacion = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        VerificarOcupacion()
    End Sub

    Private Sub VerificarOcupacion()
        If IDOcupacion = "" Then
            OcupacionValue = ""
        Else
            OcupacionValue = " Clientes.IDOcupacion=" & IDOcupacion & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoComprobante.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDComprobanteFiscal FROM ComprobanteFiscal WHERE TipoComprobante= '" + cbxTipoComprobante.SelectedItem + "'", Con)
        IDTipoNCF = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()
        VerificarTipoComprobante()
    End Sub

    Private Sub VerificarTipoComprobante()

        If IDTipoNCF = "" Then
            TipoNCFValue = ""
        Else
            TipoNCFValue = " FacturaDatos.IDComprobanteFiscal=" & IDTipoNCF & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxTipoCredito_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoCredito.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDTipoCredito FROM TipoCredito WHERE Descripcion= '" + cbxTipoCredito.SelectedItem + "'", ConLibregco)
        IDTipodeCredito = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        VerificarTipoCredito()
    End Sub

    Private Sub VerificarTipoCredito()
        If IDTipodeCredito = "" Then
            TipodeCreditoValue = ""
        Else
            TipodeCreditoValue = " Clientes.IDTipoCredito=" & IDTipodeCredito & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxMunicipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMunicipio.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDMunicipio FROM Municipios WHERE Municipio= '" + cbxMunicipio.SelectedItem + "'", ConLibregco)
        IDMunicipio = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()
        VerificarMunicipio()
    End Sub

    Private Sub VerificarMunicipio()

        If IDMunicipio = "" Then
            MunicipioValue = ""
        Else
            MunicipioValue = " Clientes.IDMunicipio=" & IDMunicipio & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxGrupoClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxGrupoClientes.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDGrupocxc FROM Grupocxc WHERE Descripcion= '" + cbxGrupoClientes.SelectedItem + "'", ConLibregco)
        IDGrupoClientes = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        VerificarGrupoClientes()
    End Sub


    Private Sub VerificarGrupoClientes()
        If IDGrupoClientes = "" Then
            GrupoClientesValue = ""
        Else
            GrupoClientesValue = " Clientes.IDGrupocxc=" & IDGrupoClientes & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxCalificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCalificacion.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCalificacion FROM Calificacion WHERE Calificacion= '" + cbxCalificacion.SelectedItem + "'", ConLibregco)
        IDCalificacion = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        VerificarCalificacion()
    End Sub

    Private Sub VerificarCalificacion()
        If IDCalificacion = "" Then
            CalificacionValue = ""
        Else
            CalificacionValue = " Clientes.IDCalificacion=" & IDCalificacion & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxCobrador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCobrador.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + cbxCobrador.SelectedItem + "'", Con)
        IDCobrador = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        VerificarCobrador()
    End Sub

    Private Sub VerificarCobrador()
        If IDCobrador = "" Then
            CobradorValue = ""
        Else
            CobradorValue = " Clientes.IDEmpleado=" & IDCobrador & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxVendedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxVendedor.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + cbxVendedor.SelectedItem + "'", Con)
        IDVendedor = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        VerificarVendedor()
    End Sub

    Private Sub VerificarVendedor()
        If IDVendedor = "" Then
            VendedorValue = ""
        Else
            VendedorValue = " FacturaDatos.IDVendedor=" & IDVendedor & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxUsuario.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + cbxUsuario.SelectedItem + "'", Con)
        IDUsuario = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        VerificarUsuario()
    End Sub

    Private Sub VerificarUsuario()
        If IDUsuario = "" Then
            UsuarioValue = ""
        Else
            UsuarioValue = " FacturaDatos.IDUsuario=" & IDUsuario & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxChofer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxChofer.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDEmpleado FROM Empleados WHERE Nombre= '" + cbxChofer.SelectedItem + "'", Con)
        IDChofer = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        VerificarChofer()
    End Sub

    Private Sub VerificarChofer()
        If IDChofer = "" Then
            ChoferValue = ""
        Else
            ChoferValue = " FacturaDatos.IDChofer=" & IDChofer & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxCondicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCondicion.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDCondicion FROM Condicion WHERE Condicion= '" + cbxCondicion.SelectedItem + "'", ConLibregco)
        IDCondicion = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        VerificarCondicion()
    End Sub

    Private Sub VerificarCondicion()
        If IDCondicion = "" Then
            CondicionValue = ""
        Else
            CondicionValue = " FacturaDatos.IDCondicion=" & IDCondicion & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAlmacen.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDAlmacen FROM Almacen WHERE Almacen= '" + cbxAlmacen.SelectedItem + "'", Con)
        IDAlmacen = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        VerificarAlmacen()
    End Sub

    Private Sub VerificarAlmacen()
        If IDAlmacen = "" Then
            AlmacenValue = ""
        Else
            AlmacenValue = " FacturaDatos.IDAlmacen=" & IDAlmacen & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxVehiculo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxVehiculo.SelectedIndexChanged
        Con.Open()
        cmd = New MySqlCommand("SELECT IDVehiculo FROM Vehiculo WHERE DatoVehiculo= '" + cbxVehiculo.SelectedItem + "'", Con)
        IDVehiculo = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        VerificarVehiculo()
    End Sub

    Private Sub VerificarVehiculo()
        If IDVehiculo = "" Then
            VehiculoValue = ""
        Else
            VehiculoValue = " FacturaDatos.IDVehiculo=" & IDVehiculo & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxArticulos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxArticulos.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDArticulo FROM Articulos WHERE Descripcion= '" + cbxArticulos.SelectedItem + "'", ConLibregco)
        IDArticulo = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        VerificarArticulo()
    End Sub

    Private Sub VerificarArticulo()
        If IDArticulo = "" Then
            ArticuloValue = ""
        Else
            ArticuloValue = " FacturaArticulos.IDArticulo=" & IDArticulo & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub cbxMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMedida.SelectedIndexChanged
        ConLibregco.Open()
        cmd = New MySqlCommand("SELECT IDMedida FROM Medida WHERE Abreviatura= '" + cbxMedida.SelectedItem + "'", ConLibregco)
        IDMedida = Convert.ToString(cmd.ExecuteScalar())
        ConLibregco.Close()

        VerificarMedida()
    End Sub

    Private Sub VerificarMedida()
        If IDMedida = "" Then
            MedidaValue = ""
        Else
            MedidaValue = " FacturaArticulos.IDMedida=" & IDMedida & " "
        End If
        ConstructorSQL()
    End Sub

    Private Sub txtDireccion_TextChanged(sender As Object, e As EventArgs) Handles txtDireccion.TextChanged
        VerificarDireccion()
    End Sub

    Private Sub VerificarDireccion()
        If txtDireccion.Text = "" Then
            DireccionValue = ""
        Else
            DireccionValue = " Clientes.Direccion like '%" & txtDireccion.Text & "%' "
        End If
        ConstructorSQL()
    End Sub

    Private Sub ConstructorSQL()
        Dim PutWhere As String

        If NombreValue <> "" Or DireccionValue <> "" Or TipoIdentificacionValue <> "" Or GeneroValue <> "" Or NacionalidadValue <> "" Or EstadoCivilValue <> "" Or OcupacionValue <> "" Or ProvinciaValue <> "" Or MunicipioValue <> "" Or TipodeCreditoValue <> "" Or GrupoClientesValue <> "" Or TipoNCFValue <> "" Or IDCalificacion <> "" Or CobradorValue <> "" Or VendedorValue <> "" Or UsuarioValue <> "" Or CondicionValue <> "" Or AlmacenValue <> "" Or ChoferValue <> "" Or VehiculoValue <> "" Or ArticuloValue <> "" Or MedidaValue <> "" Then
            PutWhere = " WHERE"
        Else
            PutWhere = ""
        End If

        If NombreValue <> "" And DireccionValue & TipoIdentificacionValue & GeneroValue & NacionalidadValue & EstadoCivilValue & OcupacionValue & ProvinciaValue & MunicipioValue & TipodeCreditoValue & GrupoClientesValue & TipoNCFValue & IDCalificacion & CobradorValue & VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A1 = " AND"
        Else
            A1 = ""
        End If

        If DireccionValue <> "" And TipoIdentificacionValue & GeneroValue & NacionalidadValue & EstadoCivilValue & OcupacionValue & ProvinciaValue & MunicipioValue & TipodeCreditoValue & GrupoClientesValue & TipoNCFValue & IDCalificacion & CobradorValue & VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A2 = " AND"
        Else
            A2 = ""
        End If

        If TipoIdentificacionValue <> "" And GeneroValue & NacionalidadValue & EstadoCivilValue & OcupacionValue & ProvinciaValue & MunicipioValue & TipodeCreditoValue & GrupoClientesValue & TipoNCFValue & IDCalificacion & CobradorValue & VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A3 = " AND"
        Else
            A3 = ""
        End If

        If GeneroValue <> "" And NacionalidadValue & EstadoCivilValue & OcupacionValue & ProvinciaValue & MunicipioValue & TipodeCreditoValue & GrupoClientesValue & TipoNCFValue & IDCalificacion & CobradorValue & VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A4 = " AND"
        Else
            A4 = ""
        End If

        If NacionalidadValue <> "" And EstadoCivilValue & OcupacionValue & ProvinciaValue & MunicipioValue & TipodeCreditoValue & GrupoClientesValue & TipoNCFValue & IDCalificacion & CobradorValue & VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A5 = " AND"
        Else
            A5 = ""
        End If

        If EstadoCivilValue <> "" And OcupacionValue & ProvinciaValue & MunicipioValue & TipodeCreditoValue & GrupoClientesValue & TipoNCFValue & IDCalificacion & CobradorValue & VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A6 = " AND"
        Else
            A6 = ""
        End If

        If OcupacionValue <> "" And ProvinciaValue & MunicipioValue & TipodeCreditoValue & GrupoClientesValue & TipoNCFValue & IDCalificacion & CobradorValue & VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A7 = " AND"
        Else
            A7 = ""
        End If

        If ProvinciaValue <> "" And MunicipioValue & TipodeCreditoValue & GrupoClientesValue & TipoNCFValue & IDCalificacion & CobradorValue & VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A8 = " AND"
        Else
            A8 = ""
        End If

        If MunicipioValue <> "" And TipodeCreditoValue & GrupoClientesValue & TipoNCFValue & IDCalificacion & CobradorValue & VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A9 = " AND"
        Else
            A9 = ""
        End If

        If TipodeCreditoValue <> "" And GrupoClientesValue & TipoNCFValue & IDCalificacion & CobradorValue & VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A10 = " AND"
        Else
            A10 = ""
        End If

        If GrupoClientesValue <> "" And TipoNCFValue & IDCalificacion & CobradorValue & VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A11 = " AND"
        Else
            A11 = ""
        End If

        If TipoNCFValue <> "" And IDCalificacion & CobradorValue & VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A12 = " AND"
        Else
            A12 = ""
        End If

        If IDCalificacion <> "" And CobradorValue & VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A13 = " AND"
        Else
            A13 = ""
        End If

        If CobradorValue <> "" And VendedorValue & UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A14 = " AND"
        Else
            A14 = ""
        End If

        If VendedorValue <> "" And UsuarioValue & CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A15 = " AND"
        Else
            A15 = ""
        End If

        If UsuarioValue <> "" And CondicionValue & AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A16 = " AND"
        Else
            A16 = ""
        End If

        If CondicionValue <> "" And AlmacenValue & ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A17 = " AND"
        Else
            A17 = ""
        End If

        If AlmacenValue <> "" And ChoferValue & VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A18 = " AND"
        Else
            A18 = ""
        End If

        If ChoferValue <> "" And VehiculoValue & ArticuloValue & MedidaValue <> "" Then
            A19 = " AND"
        Else
            A19 = ""
        End If

        If VehiculoValue <> "" And ArticuloValue & MedidaValue <> "" Then
            A20 = " AND"
        Else
            A20 = ""
        End If

        If ArticuloValue <> "" And MedidaValue <> "" Then
            A21 = " AND"
        Else
            A21 = ""
        End If

        FullCommand = ClientesCommand & PutWhere & NombreValue & A1 & DireccionValue & A2 & TipoIdentificacionValue & A3 & GeneroValue & A4 & NacionalidadValue & A5 & EstadoCivilValue & A6 & OcupacionValue & A7 & ProvinciaValue & A8 & MunicipioValue & A9 & TipodeCreditoValue & A10 & GrupoClientesValue & A11 & TipoNCFValue & A12 & CalificacionValue & A13 & CobradorValue & A14 & VendedorValue & A15 & UsuarioValue & A16 & CondicionValue & A17 & AlmacenValue & A18 & ChoferValue & A19 & VehiculoValue & A20 & ArticuloValue & A21 & MedidaValue
    End Sub

    Private Sub BuscarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarToolStripMenuItem.Click
        btnBuscarCons.PerformClick()
    End Sub


    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        ActualizarTodo()
        txtNombre.Clear()
        txtDireccion.Clear()
        Nombre = ""
        Direccion = ""
        IDTipoIdentificacion = ""
        IDGenero = ""
        IDNacionalidad = ""
        IDEstadoCivil = ""
        IDOcupacion = ""
        IDProvincia = ""
        IDMunicipio = ""
        IDTipodeCredito = ""
        IDGrupoClientes = ""
        IDTipoNCF = ""
        IDCalificacion = ""
        IDCobrador = ""
        IDVendedor = ""
        IDUsuario = ""
        IDCondicion = ""
        IDAlmacen = ""
        IDChofer = ""
        IDVehiculo = ""
        IDArticulo = ""
        IDMedida = ""
        SummaQuery()
        btnBuscarCons.PerformClick()
    End Sub

    Private Sub btnBuscarCons_Click(sender As Object, e As EventArgs) Handles btnBuscarCons.Click
        cmd = New MySqlCommand(FullCommand & " LIMIT " & DTConfiguracion.Rows(28 - 1).Item("Value2Int"), Con)
        RefrescarTabla()
    End Sub

    Private Sub btnStructure_Click(sender As Object, e As EventArgs) Handles btnStructure.Click
        frm_query_structure.txtQuery.Text = "SQL Query: " & FullCommand
        frm_query_structure.ShowDialog()
    End Sub

    Private Sub EstructuiraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstructuiraToolStripMenuItem.Click
        btnStructure.PerformClick()
    End Sub

    Private Sub SummaQuery()
        VerificarNombre()
        VerificarDireccion()
        VerificarTipoIdentificacion()
        VerificarGenero()
        VerificarNacionalidad()
        VerificarEstadoCivil()
        VerificarOcupacion()
        VerificarProvincia()
        VerificarMunicipio()
        VerificarTipoCredito()
        VerificarGrupoClientes()
        VerificarTipoComprobante()
        VerificarCalificacion()
        VerificarCobrador()
        VerificarVendedor()
        VerificarUsuario()
        VerificarCondicion()
        VerificarAlmacen()
        VerificarChofer()
        VerificarVehiculo()
        VerificarArticulo()
        VerificarMedida()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
End Class