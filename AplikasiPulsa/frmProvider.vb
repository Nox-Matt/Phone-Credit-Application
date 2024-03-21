Imports MySql.Data.MySqlClient
Imports System
Imports System.Globalization
Imports System.Threading
Public Class frmProvider
    Dim bindingSource As New BindingSource()
    Dim statusEdit As Boolean
    Sub showGridData()
        dgvProvider.DataSource = ""
        Try
            cmd = New MySqlCommand("SELECT * FROM tblprovider;", conn)
            Dim da = New MySqlDataAdapter(cmd)
            Dim dt = New DataTable()
            da.Fill(dt)
            BindingSource.DataSource = dt
            With Me.dgvProvider
                .AutoGenerateColumns = True
                .DataSource = BindingSource
                .Columns(0).HeaderText = "ID Provider"
                .Columns(1).HeaderText = "Nama Provider"
                .Columns(2).HeaderText = "Asal Provider"
                .AllowUserToAddRows = False
                .ReadOnly = True
            End With
            dgvProvider.DataSource = BindingSource
        Catch ex As Exception
            MessageBox.Show("Failed to Retrieve Data")
        End Try
    End Sub
    Sub clearForm()
        txtIDProvider.Clear()
        txtIDProvider.Clear()
        txtNamaProvider.Clear()
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
        btnAdd.Enabled = True
    End Sub

    Private Sub frmProvider_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        disconnectDb()
    End Sub

    Private Sub frmProvider_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connectDb()
        startForm()
        showGridData()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        enableFillForm()
        btnAdd.Enabled = False
        btnClear.Enabled = True
        btnSave.Enabled = True
        txtIDProvider.Enabled = True
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
            If IsNumeric(txtIDProvider.Text) Then
                sqlQuery = ""
                sqlQuery = "INSERT INTO tblprovider(ID_Provider, Name_Provider ,Asal_Provider)" &
                    " VALUES(" & CInt(txtIDProvider.Text) & ",'" & txtNamaProvider.Text & "','" &
                    txtAsalProvider.Text & "')"
                cmd.Connection = conn
                cmd.CommandText = sqlQuery
                Dim i As Integer = cmd.ExecuteNonQuery()
                If (i > 0) Then
                    MessageBox.Show("Data Saved")
                Else
                    MessageBox.Show("Data Failed to Save")
                End If
            Else
                MessageBox.Show("Some input is not numeric.")
            End If
        Else
            If IsNumeric(txtIDProvider.Text) Then
                sqlQuery = ""
                sqlQuery = "Update(tblprovider) SET " &
                            "Name_Provider = '" & txtNamaProvider.Text & "' ," &
                            "Asal_Provider = '" & txtAsalProvider.Text & "' " &
                            "WHERE ID_Provider = " & CInt(txtIDProvider.Text)
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
        showGridData()
        startForm()
        clearForm()
    End Sub

    Private Sub dgvProvider_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProvider.CellClick
        Dim reader As MySqlDataReader
        sqlQuery = ""
        sqlQuery = "SELECT * FROM tblprovider;"
        cmd.Connection = conn
        cmd.CommandText = sqlQuery
        reader = cmd.ExecuteReader
        If reader.HasRows = True Then
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnAdd.Enabled = False
            btnCancel.Enabled = True
            Dim i As Integer = dgvProvider.CurrentRow.Index
            txtIDProvider.Text = dgvProvider.Item(0, i).Value
            txtNamaProvider.Text = dgvProvider.Item(1, i).Value
            txtAsalProvider.Text = dgvProvider.Item(2, i).Value
            txtIDProvider.ReadOnly = True
        End If
        reader.Close()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim result As DialogResult = MessageBox.Show("Edit data with Paket ID Of = " &
                                                     txtIDProvider.Text,
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
        Dim result As DialogResult = MessageBox.Show("Delete data with Employee ID = " &
                                                    txtIDProvider.Text,
                                                    "Notification Delete Data",
                                                    MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            MessageBox.Show("Cancel Delete Data")
        ElseIf result = DialogResult.Yes Then
            sqlQuery = ""
            sqlQuery = "DELETE FROM tblprovider" &
                        " WHERE ID_Provider = " & CInt(txtIDProvider.Text)
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