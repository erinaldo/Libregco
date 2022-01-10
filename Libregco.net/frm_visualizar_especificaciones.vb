Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.ReportAppServer

Public Class frm_visualizar_especificaciones

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds, Ds1, Ds2 As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Friend RutaDocumento, lblchkSerial, lblchkPromocion, lblchkDevolucion, lblchkVenderCosto, lblchkDescontinuar, lblchkDesactivar, lblIDMedida, lblIDPrecio, lblAnularPrecio, lblCheckDuplicates As New Label
    Dim crParameterFiledDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition
    Dim crParameterRangeValue As ParameterRangeValue

    Private Sub frm_visualizar_especificaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        'Me.WindowState = CheckWindowState()
        CargarLibregco()
        RefrescarEspecificaciones()
    End Sub

    Private Sub CargarLibregco()
       PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub RefrescarEspecificaciones()
        Try
            Dim IDArticulo, RutaArchivo As New Label

            IDArticulo.Text = frm_buscar_mant_articulos.DgvArticulos.CurrentRow.Cells(0).Value

            DgvEspecificaciones.Rows.Clear()

            ConLibregco.Open()
            Dim consulta As New MySqlCommand("SELECT Especificacion FROM articulos_especificaciones where IDArticulo='" + IDArticulo.Text + "'", ConLibregco)
            Dim LectorEspecificacion As MySqlDataReader = consulta.ExecuteReader

            While LectorEspecificacion.Read
                DgvEspecificaciones.Rows.Add(LectorEspecificacion.GetValue(0))
            End While

            LectorEspecificacion.Close()
            ConLibregco.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub

End Class