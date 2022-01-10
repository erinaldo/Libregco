Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.IO

Public Class frm_current_version_sys

    Dim sqlQ As String=""
    Dim cmd As MySqlCommand
    Dim Ds As New DataSet
    Dim Adaptador As MySqlDataAdapter
    Dim Server As New Label

    Private Sub frm_current_version_sys_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        GetServer()
        CargarLibregco()
        GetLastBuild()
    End Sub

    Private Sub GetServer()
        ConUtilitarios.Open()
        cmd = New MySqlCommand("Select Value from Libregco_Utilitarios.Ajustes where IDAjuste=1", ConUtilitarios)
        PathServidor.Text = Convert.ToString(cmd.ExecuteScalar())
        ConUtilitarios.Close()

    End Sub

    Private Sub GetLastBuild()
        Dim wFile As System.IO.FileStream

        Ds.Clear()
        ConUtilitarios.Open()
        cmd = New MySqlCommand("Select * from libregco_utilitarios.version_sys where IDBuild= (Select Max(IDBuild) from version_sys)", ConUtilitarios)
        Adaptador = New MySqlDataAdapter(cmd)
        Adaptador.Fill(Ds, "version_sys")
        ConUtilitarios.Close()

        Dim Tabla As DataTable = Ds.Tables("version_sys")

        If Tabla.Rows.Count > 0 Then
            lblBuild.Text = (Tabla.Rows(0).Item("IDBuild"))
            lblversion.Text = (Tabla.Rows(0).Item("VersionMayor")) & "." & (Tabla.Rows(0).Item("VersionMenor")) & "." & (Tabla.Rows(0).Item("VersionCompilacion")) & "." & (Tabla.Rows(0).Item("VersionVersion"))
            lblLanzamiento.Text = CDate(Tabla.Rows(0).Item("FechaLanzamiento")).ToLongDateString
            lblAño.Text = CDate(Tabla.Rows(0).Item("FechaLanzamiento")).ToString("yyyy") & "-" & CDate((Tabla.Rows(0).Item("FechaLanzamiento")).AddYears(1)).ToString("yyyy")
            lblSize.Text = (Tabla.Rows(0).Item("Tamano")) & " megabytes."
           

            Dim ExistFile As Boolean = System.IO.File.Exists(Tabla.Rows(0).Item("LocacionLogo"))

            If ExistFile = True Then
                wFile = New FileStream((Tabla.Rows(0).Item("LocacionLogo")), FileMode.Open, FileAccess.Read)
                PicImagenLogo.Image = System.Drawing.Image.FromStream(wFile)
                wFile.Close()
            Else
                PicImagenLogo.Image = My.Resources.LibregcoCircle_x256
            End If

            RefrescarDgvNotificaciones()
        End If

    End Sub
   
    Private Sub CargarLibregco()
        PicLogo.Image = ConseguirLogoSistema()
    End Sub

    Private Sub RefrescarDgvNotificaciones()
        Try
            DgvNotas.Rows.Clear()

            Dim DsTmp As New DataSet

            DsTmp.Clear()
            ConUtilitarios.Open()
            cmd = New MySqlCommand("SELECT * FROM libregco_utilitarios.version_sys ORDER BY IDBUILD DESC", ConUtilitarios)
            Adaptador = New MySqlDataAdapter(cmd)
            Adaptador.Fill(DsTmp, "version")


            Dim Tabla As DataTable = DsTmp.Tables("version")


            For Each DataRow As DataRow In Tabla.Rows
                DgvNotas.Rows.Add("", "     " & DataRow.Item("VersionMayor") & "." & DataRow.Item("VersionMenor") & "." & DataRow.Item("VersionCompilacion") & "." & DataRow.Item("VersionVersion") & "                                                                                                                                  Fecha lanzamiento: " & CDate(DataRow.Item("FechaLanzamiento")).ToLongDateString)

                Dim SQLNovedades As New MySqlCommand("SELECT idUpdate_sys,Notes FROM libregco_utilitarios.update_sys where IDBuild='" + DataRow.Item("IDBuild").ToString + "' ORDER BY Rate DESC", ConUtilitarios)
                Dim LectorNovedades As MySqlDataReader = SQLNovedades.ExecuteReader

                While LectorNovedades.Read
                    DgvNotas.Rows.Add(LectorNovedades.GetValue(0), "- " & LectorNovedades.GetValue(1))
                End While
                LectorNovedades.Close()

                DgvNotas.Rows.Add(" ")
                DgvNotas.Rows.Add("", "_____________________________________________________________________________________________________________________________________________")
            Next

         
            ConUtilitarios.Close()

        Catch ex As Exception
      InsertException(System.Reflection.MethodBase.GetCurrentMethod.DeclaringType.Name, System.Reflection.MethodInfo.GetCurrentMethod.Name, ex.Message.ToString & vbNewLine & "sqlQ Query:" & sqlQ.ToString, ex.TargetSite.ToString, ex.HelpLink, Me)
        End Try
    End Sub


End Class