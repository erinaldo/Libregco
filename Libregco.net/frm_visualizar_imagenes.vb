Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_visualizar_imagenes

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend RutaDocumento, lblchkSerial, lblchkPromocion, lblchkDevolucion, lblchkVenderCosto, lblchkDescontinuar, lblchkDesactivar, lblIDMedida, lblIDPrecio, lblAnularPrecio, lblCheckDuplicates As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue

    Private Sub frm_visualizar_imagenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        RefrescarImagenes()
    End Sub

    Private Sub CargarLibregco()
         PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub RefrescarImagenes()
        Try
            Dim wFile As System.IO.FileStream
            Dim IDArticulo, RutaArchivo As New Label

            If Me.Owner.Name = frm_buscar_mant_articulos.Name Then
                IDArticulo.Text = frm_buscar_mant_articulos.DgvArticulos.CurrentRow.Cells(0).Value
            Else
                IDArticulo.Text = frm_facturacion.txtCodigoArticulo.Text
            End If

            DgvImagenes.Rows.Clear()

            ConLibregco.Open()
            Dim consulta As New MySqlCommand("SELECT Descripcion,RutaImagen FROM articulos_fotos where IDArticulo='" + IDArticulo.Text + "' ORDER BY Orden ASC", ConLibregco)
            Dim LectorImagenes As MySqlDataReader = consulta.ExecuteReader

            While LectorImagenes.Read
                Dim ExistFile As Boolean = System.IO.File.Exists(LectorImagenes.GetValue(1))
                If ExistFile = True Then
                    RutaArchivo.Text = LectorImagenes.GetValue(1)
                    wFile = New FileStream(RutaArchivo.Text, FileMode.Open, FileAccess.Read)
                    DgvImagenes.Rows.Add(LectorImagenes.GetValue(0), System.Drawing.Image.FromStream(wFile))
                    wFile.Close()
                End If

            End While

            LectorImagenes.Close()
            ConLibregco.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

End Class