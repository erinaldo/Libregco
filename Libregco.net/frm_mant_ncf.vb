Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Public Class frm_mant_ncf

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim IDEquipo As New Label

    Private Sub frm_mant_ncf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        CargarEmpresa()
        ColumnasNCF()
        FillEquipos()
        RefrescarComprobantes()
        ControlSuperClave = 1
    End Sub

    Private Sub FillEquipos()
        Try
            Ds.Clear()
            Con.Open()
            cmd = New MySqlCommand("SELECT ComputerName FROM areaimpresion ORDER BY ComputerName ASC", Con)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(Ds, "areaimpresion")
            CbxEquipos.Items.Clear()
            Con.Close()

            Dim Tabla As DataTable = Ds.Tables("areaimpresion")
            For Each Fila As DataRow In Tabla.Rows
                CbxEquipos.Items.Add(Fila.Item("ComputerName"))
            Next

            CbxEquipos.Text = My.Computer.Name

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CargarLibregco()
        PicMinLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub ColumnasNCF()
        Dim PorcColumn As New DataGridViewPercentageColumn

        With PorcColumn
            .HeaderText = "% Uso"
            .Width = 60
            .Visible = True
        End With

        DgvNCF.Columns.Clear()
        With DgvNCF
            .Columns.Add("IDTipoComprobante", "Código") '0
            .Columns.Add("Serie", "Serie")  '1
            .Columns.Add("TipoComprobante", "Comprobante") '2
            .Columns.Add("Inicial", "General")  '3
            .Columns.Add("Hasta", "Hasta")  '4
            .Columns.Add("Ultimo", "Último")    '5
            .Columns.Add("Autorizacion", "Autorización") '6
            .Columns.Add("FechaAutorizacion", "Fecha Autorización") '7
            .Columns.Add("Caducidad", "Caducidad") '8
            .Columns.Add(PorcColumn)                '9
        End With
        PropiedadDGVNCF()

        DgvNCFArea.Columns.Clear()
        With DgvNCFArea
            .Columns.Add("IDAreaImpresionNCF", "IDAreaImpresionNCF") '0
            .Columns.Add("IDAreaImpresion", "IDAreaImpresion") '1
            .Columns.Add("Serie", "Serie") '2
            .Columns.Add("DivisionNegocio", "División de Negocios [DN]") '3
            .Columns.Add("PuntoEmision", "Punto de Emisión [PE]") '4
            .Columns.Add("AreaImpresion", "Área de Impresión [AI]") '5
            .Columns.Add("TipoComprobante", "Tipo de Comprobante [TC]") '6
            .Columns.Add("Secuencia", "Secuencia") '7
            .Columns.Add("Inicial", "Inicia" & vbNewLine & "[Sólo para referencia]") '8
            .Columns.Add("Final", "Hasta") '9
        End With
        PropiedadDgvAreaNCF()
    End Sub

    Private Sub PropiedadDgvAreaNCF()
        With DgvNCFArea
            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(2).Width = 50
            .Columns(2).ReadOnly = True
            .Columns(3).Width = 90
            .Columns(3).ReadOnly = True
            .Columns(4).Width = 90
            .Columns(4).ReadOnly = True
            .Columns(5).Width = 90
            .Columns(5).ReadOnly = True
            .Columns(6).Width = 200
            .Columns(6).ReadOnly = True

            .Columns(7).Width = 125
            .Columns(8).Width = 110
            .Columns(9).Width = 110
        End With
    End Sub

    Private Sub PropiedadDGVNCF()
        With DgvNCF
            .Columns("IDTipoComprobante").Visible = False
            .Columns("Serie").Width = 55
            .Columns("Serie").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("TipoComprobante").Width = 240
            .Columns("Inicial").Width = 75
            .Columns("Inicial").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("IDTipoComprobante").ReadOnly = True
            .Columns("Serie").ReadOnly = True
            .Columns("TipoComprobante").ReadOnly = True
            .Columns("Inicial").ReadOnly = True
            .Columns("IDTipoComprobante").DefaultCellStyle.BackColor = Color.LightGray
            .Columns("Serie").DefaultCellStyle.BackColor = Color.LightGray
            .Columns("TipoComprobante").DefaultCellStyle.BackColor = Color.LightGray
            .Columns("Inicial").DefaultCellStyle.BackColor = Color.LightGray

            .Columns("IDTipoComprobante").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Serie").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("TipoComprobante").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Inicial").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Hasta").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Ultimo").SortMode = DataGridViewColumnSortMode.NotSortable

            .Columns("Hasta").Width = 105
            .Columns("Hasta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ultimo").Width = 105
            .Columns("Ultimo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Autorizacion").Width = 85
            .Columns("Autorizacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Autorizacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Autorizacion").DefaultCellStyle.BackColor = SystemColors.Info

            .Columns("FechaAutorizacion").Width = 75
            .Columns("FechaAutorizacion").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("FechaAutorizacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("FechaAutorizacion").DefaultCellStyle.BackColor = SystemColors.Info

            .Columns("Caducidad").Width = 75
            .Columns("Caducidad").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("Caducidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Caducidad").DefaultCellStyle.BackColor = SystemColors.Info
        End With
    End Sub

    Sub RefrescarComprobantes()
        Try
            'Seleccionar tipo de metodo de NCFs
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

            Con.Open()
        cmd = New MySqlCommand("Select Value2Int from Configuracion where IDConfiguracion=75", Con)
        Dim TypeofMetode As String = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        If TypeofMetode = 1 Then
            cbxEsctructuracion.SelectedIndex = 0
            CbxEquipos.Visible = False
            Label2.Visible = False
            DgvNCF.Visible = True
            DgvNCFArea.Visible = False
        ElseIf TypeofMetode = 2 Then
            cbxEsctructuracion.SelectedIndex = 1
            CbxEquipos.Visible = True
            Label2.Visible = True
            DgvNCF.Visible = False
            DgvNCFArea.Visible = True

        ElseIf TypeofMetode = 3 Then
            cbxEsctructuracion.SelectedIndex = 2
            CbxEquipos.Visible = False
            Label2.Visible = False
            DgvNCF.Visible = True
            DgvNCFArea.Visible = False
        End If

        DgvNCF.Rows.Clear()
        Con.Open()

        If TypeofMetode = 1 Then
            Dim Cmd1 As New MySqlCommand("SELECT IDComprobanteFiscal,Serie,TipoComprobante,Inicial,Hasta,Ultimo,NoAutorizacion,FechaAutorizacion,Caducidad FROM ComprobanteFiscal", Con)
            Dim LectorNCF As MySqlDataReader = Cmd1.ExecuteReader

            While LectorNCF.Read
                DgvNCF.Rows.Add(LectorNCF.GetValue(0), LectorNCF.GetValue(1), LectorNCF.GetValue(2), LectorNCF.GetValue(3), LectorNCF.GetValue(4), LectorNCF.GetValue(5), LectorNCF.GetValue(6), LectorNCF.GetValue(7), LectorNCF.GetValue(8), CDbl(LectorNCF.GetValue(5)) / CDbl(LectorNCF.GetValue(4)))
            End While
            LectorNCF.Close()


        ElseIf TypeofMetode = 3 Then
            Dim Cmd1 As New MySqlCommand("SELECT IDComprobanteFiscal,Serie,TipoComprobante,NoTcf,Hasta,Ultimo,NoAutorizacion,FechaAutorizacion,Caducidad FROM ComprobanteFiscal", Con)
            Dim LectorNCF As MySqlDataReader = Cmd1.ExecuteReader

            While LectorNCF.Read
                DgvNCF.Rows.Add(LectorNCF.GetValue(0), LectorNCF.GetValue(1), LectorNCF.GetValue(2), LectorNCF.GetValue(3), LectorNCF.GetValue(4), LectorNCF.GetValue(5), LectorNCF.GetValue(6), LectorNCF.GetValue(7), LectorNCF.GetValue(8), CDbl(LectorNCF.GetValue(5)) / CDbl(LectorNCF.GetValue(4)))
            End While
            LectorNCF.Close()
        End If

        Con.Close()

        DgvNCFArea.Rows.Clear()
        Con.Open()
        Dim Cmd2 As New MySqlCommand("SELECT IDAreaImpresionNCF,AreaImpresionNCF.IDAreaImpresion,Serie,DivisionNegocio,Almacen.PuntoEmision,AreaImpresion.NodeImpresion,NoTCF,ComprobanteFiscal.TipoComprobante,AreaImpresionNCF.Actual,AreaImpresionNCF.Inicial,AreaImpresionNCF.Final FROM areaimpresionncf INNER JOIN AreaImpresion on AreaImpresionNCF.IDAreaImpresion=AreaImpresion.IDEquipo INNER JOIN Almacen on AreaImpresion.IDAlmacen=Almacen.IDAlmacen INNER JOIN Sucursal on Almacen.IDSucursal=Sucursal.IDSucursal INNER JOIN ComprobanteFiscal on AreaImpresionNCF.IDNCF=ComprobanteFiscal.IDComprobanteFiscal Where AreaImpresion.IDEquipo='" + IDEquipo.Text + "'", Con)
        Dim LectorNCFPunto As MySqlDataReader = Cmd2.ExecuteReader

        While LectorNCFPunto.Read
            DgvNCFArea.Rows.Add(LectorNCFPunto.GetValue(0), LectorNCFPunto.GetValue(1), LectorNCFPunto.GetValue(2), LectorNCFPunto.GetValue(3), LectorNCFPunto.GetValue(4), LectorNCFPunto.GetValue(5), "[" & LectorNCFPunto.GetValue(6) & "] " & LectorNCFPunto.GetValue(7), LectorNCFPunto.GetValue(8), LectorNCFPunto.GetValue(9), LectorNCFPunto.GetValue(10))
        End While
        LectorNCFPunto.Close()
        Con.Close()

        Catch ex As Exception
  InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try

    End Sub

    Private Sub CargarEmpresa()
        PicBoxLogo.Image = ConseguirLogoEmpresa()
    End Sub

    Private Sub DgvNCF_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNCF.CellValueChanged
        If e.ColumnIndex = 4 Then

        End If
    End Sub

    Private Sub DgvNCF_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DgvNCF.EditingControlShowing
        Try

            Dim Validar As TextBox = CType(e.Control, TextBox)
            ' agregar el controlador de eventos para el KeyPress 
            AddHandler Validar.KeyPress, AddressOf Validar_Keypress

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' obtener indice de la columna 
        Dim columna As Integer = DgvNCF.CurrentCell.ColumnIndex
        ' comprobar si la celda en edicin corresponde a la columna 0 o 1
        If columna = 4 Or columna = 5 Then
            ' Obtener caracter 
            Dim caracter As Char = e.KeyChar
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar 
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim Result As MsgBoxResult = MessageBox.Show("Está seguro que desea guardar los cambios realizados en el módulo de la secuencia de los comprobantes Fiscales?", "Guardar Cambios en Secuencia NCF", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If Result = MsgBoxResult.Yes Then

                'Verificacion de ultimos comprobantes fiscales
                Con.Open()
                For Each rw As DataGridViewRow In DgvNCF.Rows
                    cmd = New MySqlCommand("SELECT Ultimo FROM comprobantefiscal WHERE IDComprobanteFiscal= '" + rw.Cells(0).Value.ToString + "'", Con)
                    If Convert.ToDouble(cmd.ExecuteScalar()) <> CDbl(rw.Cells(5).Value) Then
                        MessageBox.Show("El tipo de comprobante fiscal " & vbNewLine & vbNewLine & rw.Cells(2).Value.ToString.ToUpper & vbNewLine & vbNewLine & "no se puede guardar en esta ocasión porque se han emitido nuevos comprobantes fiscales después de la apertura de este formulario.", "El comprobante ya ha sido modificado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Con.Close()
                        Exit Sub
                    End If
                Next
                Con.Close()

                frm_superclave.IDAccion.Text = 64
                frm_superclave.ShowDialog(Me)
                If ControlSuperClave = 1 Then
                    Exit Sub
                End If

                For Each Row As DataGridViewRow In DgvNCF.Rows
                    sqlQ = "UPDATE ComprobanteFiscal SET Serie='" + Row.Cells(1).Value.ToString + "',Hasta='" + Row.Cells(4).Value.ToString + "',Ultimo='" + Row.Cells(5).Value.ToString + "',NoAutorizacion='" + Row.Cells(6).Value.ToString + "',FechaAutorizacion='" + Row.Cells(7).Value.ToString + "',Caducidad='" + Row.Cells(8).Value.ToString + "' WHERE IDComprobanteFiscal='" + Row.Cells(0).Value.ToString + "'"
                    GuardarDatos()
                Next


                For Each RowNCF As DataGridViewRow In DgvNCFArea.Rows
                    sqlQ = "UPDATE AreaImpresionNCF SET Inicial='" + RowNCF.Cells(8).Value.ToString + "',Final='" + RowNCF.Cells(9).Value.ToString + "',Actual='" + RowNCF.Cells(7).Value.ToString + "' WHERE IDAreaImpresionNCF='" + RowNCF.Cells(0).Value.ToString + "'"
                    GuardarDatos()
                Next

                MessageBox.Show("Los cambios han sido guardados satisfactoriamente.", "Se guardaron los cambios", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If


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
            Con.Close()
            MessageBox.Show(ex.Message & " Desde Guardar Datos")
        End Try
    End Sub

    Private Sub CbxEquipos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxEquipos.SelectedIndexChanged
        If Con.State = ConnectionState.Open Then
            Con.Close()
        End If

        Con.Open()
        cmd = New MySqlCommand("SELECT IDEquipo FROM AreaImpresion WHERE ComputerName= '" + CbxEquipos.Text + "'", Con)
        IDEquipo.Text = Convert.ToString(cmd.ExecuteScalar())
        Con.Close()

        RefrescarComprobantes()
    End Sub


    Private Sub DgvNCF_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNCF.CellEndEdit
        DgvNCF.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DgvNCF_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DgvNCF.CurrentCellDirtyStateChanged
        If DgvNCF.IsCurrentCellDirty Then
            DgvNCF.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DgvNCF_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvNCF.CellClick
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5 Or e.ColumnIndex = 6 Or e.ColumnIndex = 7 Or e.ColumnIndex = 8 Then
                DgvNCF.EditMode = DataGridViewEditMode.EditOnEnter
            End If
        End If
    End Sub


End Class