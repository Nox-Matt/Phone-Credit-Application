Imports MySql.Data.MySqlClient
Imports System
Imports System.Globalization
Imports System.Threading
Public Class frmPegawai
    Dim bindingSource As New BindingSource()
    Dim statusEdit As Boolean
    Sub showGridData()
        dgvSaler.DataSource = ""
        Try
            cmd = New MySqlCommand("SELECT * FROM tblpenjual;", conn)
            Dim da = New MySqlDataAdapter(cmd)
            Dim dt = New DataTable()
            da.Fill(dt)
            BindingSource.DataSource = dt
            With Me.dgvSaler
                .AutoGenerateColumns = True
                .DataSource = BindingSource
                .Columns(0).HeaderText = "ID Penjual"
                .Columns(1).HeaderText = "Nama Depan"
                .Columns(2).HeaderText = "Nama Belakang"
                .Columns(3).HeaderText = "Nomor HP"
                .Columns(4).HeaderText = "Lokasi Toko"
                .AllowUserToAddRows = False
                .ReadOnly = True
            End With
            dgvSaler.DataSource = BindingSource
        Catch ex As Exception
            MessageBox.Show("Failed to Retrieve Data")
        End Try
    End Sub
    Sub clearForm()
        txtIDSaler.Clear()
        txtFirst.Clear()
        txtLast.Clear()
        txtHP.Clear()
        txtLokasi.Clear()
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
        btnClear.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = False
        btnEdit.Enabled = False
    End Sub

    Private Sub frmPegawai_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        disconnectDb()
    End Sub

    Private Sub frmPegawai_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connectDb()
        startForm()
        showGridData()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        enableFillForm()
        btnAdd.Enabled = False
        btnClear.Enabled = True
        btnSave.Enabled = True
    End Sub
    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        startForm()
        clearForm()
        btnAdd.Enabled = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        startForm()
        statusEdit = False
        btnAdd.Enabled = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If statusEdit = False Then
            If IsNumeric(txtIDSaler.Text) Then
                sqlQuery = ""
                sqlQuery = "INSERT INTO tblpenjual(ID_Penjual,First_Name,Last_Name,Nomor_HP,Lokasi_Toko)" &
                    " VALUES(" & CInt(txtIDSaler.Text) & ",'" & txtFirst.Text & "','" &
                    txtLast.Text & "','" & CInt(txtHP.Text) & "','" & txtLokasi.Text & "')"
                cmd.Connection = conn
                cmd.CommandText = sqlQuery
                Dim i As Integer = cmd.ExecuteNonQuery()
                If (i > 0) Then
                    MessageBox.Show("Data Saved")
                Else
                    MessageBox.Show("Data Failed to Save")
                End If
            Else
                MessageBox.Show("ID is not numeric.")
            End If
        Else
            If IsNumeric(txtIDSaler.Text) Then
                sqlQuery = ""
                sqlQuery = "Update(tblpenjual) SET " &
                            "First_Name = '" & txtFirst.Text & "'," &
                            "Last_Name = '" & txtLast.Text & "'," &
                            "Nomor_HP = '" & txtHP.Text & "'," &
                            "Lokasi_Toko = '" & txtLokasi.Text & "' " &
                            "WHERE ID_Penjual = " & CInt(txtIDSaler.Text)
                cmd.Connection = conn
                cmd.CommandText = sqlQuery
                Dim i As Integer = cmd.ExecuteNonQuery()
                If (i > 0) Then
                    MessageBox.Show("Data Update")
                Else
                    MessageBox.Show("Data Failed to Update")
                End If
            Else
                MessageBox.Show("Some input is not numeric.")
            End If
            statusEdit = False
        End If
        btnAdd.Enabled = True
        showGridData()
        startForm()
    End Sub

    Private Sub dgvSaler_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSaler.CellClick
        Dim reader As MySqlDataReader
        sqlQuery = ""
        sqlQuery = "SELECT * FROM tblpenjual;"
        cmd.Connection = conn
        cmd.CommandText = sqlQuery
        reader = cmd.ExecuteReader
        If reader.HasRows = True Then
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnAdd.Enabled = False
            btnCancel.Enabled = True
            Dim i As Integer = dgvSaler.CurrentRow.Index
            txtIDSaler.Text = dgvSaler.Item(0, i).Value
            txtFirst.Text = dgvSaler.Item(1, i).Value
            txtLast.Text = dgvSaler.Item(2, i).Value
            txtHP.Text = dgvSaler.Item(3, i).Value
            txtLokasi.Text = dgvSaler.Item(4, i).Value
            txtIDSaler.ReadOnly = True
        End If
        reader.Close()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim result As DialogResult = MessageBox.Show("Edit data with Paket ID Of = " &
                                                     txtIDSaler.Text,
                                                     "Notification Editing Data",
                                                     MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            MessageBox.Show("Cancel Edit Data")
        ElseIf result = DialogResult.Yes Then
            btnSave.Enabled = True
            btnEdit.Enabled = False
            statusEdit = True
            enableFillForm()
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim result As DialogResult = MessageBox.Show("Delete data with ID_Penjual = " &
                                                    txtIDSaler.Text,
                                                    "Notification Delete Data",
                                                    MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            MessageBox.Show("Cancel Delete Data")
        ElseIf result = DialogResult.Yes Then
            sqlQuery = ""
            sqlQuery = "DELETE FROM tblpenjual" &
                        " WHERE ID_Penjual = " & CInt(txtIDSaler.Text)
            cmd.Connection = conn
            cmd.CommandText = sqlQuery
            Dim i As Integer = cmd.ExecuteNonQuery()
            If (i > 0) Then
                MessageBox.Show("Data Deleted")
            Else
                MessageBox.Show("Data Failed to Delete")
            End If
        End If
        showGridData()
        startForm()
    End Sub

    Private Sub btnExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class