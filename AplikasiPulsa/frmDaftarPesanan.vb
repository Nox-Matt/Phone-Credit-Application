Imports MySql.Data.MySqlClient
Imports System
Imports System.Globalization
Imports System.Threading
Public Class frmDaftarPesanan
    Dim bindingSource As New BindingSource()
    Dim statusEdit As Boolean

    Sub showGridData()
        dgvDaftarPesanan.DataSource = ""
        Try
            cmd = New MySqlCommand("SELECT * FROM tblpesanan;", conn)
            Dim da = New MySqlDataAdapter(cmd)
            Dim dt = New DataTable()
            da.Fill(dt)
            bindingSource.DataSource = dt
            With Me.dgvDaftarPesanan
                .AutoGenerateColumns = True
                .DataSource = bindingSource
                .Columns(0).HeaderText = "Nama Pemesan"
                .Columns(1).HeaderText = "Nama Paket"
                .Columns(2).HeaderText = "Nomor HP"
                .AllowUserToAddRows = False
                .ReadOnly = True
            End With
            dgvDaftarPesanan.DataSource = bindingSource
        Catch ex As Exception
            MessageBox.Show("Failed to Retrieve Data")
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class