Imports MySql.Data.MySqlClient
Imports System
Imports System.Globalization
Imports System.Threading
Public Class frmPesanan
    Dim bindingSource As New BindingSource()
    Dim statusEdit As Boolean
    Sub showGridData()
        dgvPesanan.DataSource = ""
        Try
            cmd = New MySqlCommand("SELECT Nama_Paket,Jumlah_Pulsa,Status FROM tblpaket;", conn)
            Dim da = New MySqlDataAdapter(cmd)
            Dim dt = New DataTable()
            da.Fill(dt)
            bindingSource.DataSource = dt
            With Me.dgvPesanan
                .AutoGenerateColumns = True
                .DataSource = bindingSource
                .Columns(0).HeaderText = "Nama Paket"
                .Columns(1).HeaderText = "Jumlah Pulsa"
                .Columns(2).HeaderText = "Status"
                .AllowUserToAddRows = False
                .ReadOnly = True
            End With
            dgvPesanan.DataSource = bindingSource
        Catch ex As Exception
            MessageBox.Show("Failed to Retrieve Data")
        End Try
    End Sub
    Sub clearForm()
        txtPrice.Clear()
        txtNamaPaket.Clear()
        txtNamaPemesan.Clear()
    End Sub
    Sub disableFillForm()
        GroupBox1.Enabled = False
    End Sub
    Sub enableFillForm()
        GroupBox1.Enabled = True
    End Sub
    Sub startForm()
        clearForm()
        disableFillForm()
        btnClear.Enabled = True
        btnPesan.Enabled = False
    End Sub

    Private Sub frmPesanan_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        disconnectDb()
    End Sub

    Private Sub frmPesanan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connectDb()
        startForm()
        showGridData()
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        startForm()
        enableFillForm()
        clearForm()
        btnPesan.Enabled = True
    End Sub

    Private Sub btnPesan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPesan.Click
            If IsNumeric(txtHP.Text) Then
                sqlQuery = ""
            sqlQuery = "INSERT INTO tblpesanan(Nama_Pemesan, Nama_Paket , Nomor_HP)" &
                " VALUES(" & "'" & txtNamaPemesan.Text & "'" & ",'" & txtNamaPaket.Text & "','" &
                txtHP.Text & "')"
                cmd.Connection = conn
                cmd.CommandText = sqlQuery
                Dim i As Integer = cmd.ExecuteNonQuery()
                If (i > 0) Then
                    MessageBox.Show("Data Saved")
                Else
                    MessageBox.Show("Data Failed to Save")
                End If
            Else
                MessageBox.Show("Phone Number is not numeric.")
            End If
        btnPesan.Enabled = True
        showGridData()
        startForm()
    End Sub

    Private Sub dgvPesanan_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPesanan.CellClick
        Dim reader As MySqlDataReader
        sqlQuery = ""
        sqlQuery = "SELECT * FROM tblpaket;"
        cmd.Connection = conn
        cmd.CommandText = sqlQuery
        reader = cmd.ExecuteReader
        If reader.HasRows = True Then
            btnPesan.Enabled = True
            btnClear.Enabled = True
            Dim i As Integer = dgvPesanan.CurrentRow.Index
            If dgvPesanan.Item(0, i).Value = "Sakti" Then
                txtNamaPaket.Text = dgvPesanan.Item(0, i).Value
                txtPrice.Text = ((dgvPesanan.Item(1, i).Value * 11 / 100) + dgvPesanan.Item(1, i).Value) - (dgvPesanan.Item(1, i).Value * 5 / 100)
            ElseIf dgvPesanan.Item(0, i).Value = "Loopers" Then
                txtNamaPaket.Text = dgvPesanan.Item(0, i).Value
                txtPrice.Text = ((dgvPesanan.Item(1, i).Value * 11 / 100) + dgvPesanan.Item(1, i).Value) - (dgvPesanan.Item(1, i).Value * 10 / 100)
            Else
                txtNamaPaket.Text = dgvPesanan.Item(0, i).Value
                txtPrice.Text = ((dgvPesanan.Item(1, i).Value * 11 / 100) + dgvPesanan.Item(1, i).Value)
            End If
        End If
        reader.Close()
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class