Imports MySql.Data.MySqlClient
Imports System
Imports System.Globalization
Imports System.Threading
Public Class frmPulsa
    Dim bindingSource As New BindingSource()
    Dim statusEdit As Boolean

    Sub showGridData()
        dgvPaket.DataSource = ""
        Try
            cmd = New MySqlCommand("SELECT * FROM tblpaket;", conn)
            Dim da = New MySqlDataAdapter(cmd)
            Dim dt = New DataTable()
            da.Fill(dt)
            bindingSource.DataSource = dt
            With Me.dgvPaket
                .AutoGenerateColumns = True
                .DataSource = bindingSource
                .Columns(0).HeaderText = "ID Paket"
                .Columns(1).HeaderText = "ID Provider"
                .Columns(2).HeaderText = "Nama Paket"
                .Columns(3).HeaderText = "Jumlah Pulsa"
                .Columns(4).HeaderText = "ID Penjual"
                .Columns(5).HeaderText = "Status"
                .AllowUserToAddRows = False
                .ReadOnly = True
            End With
            dgvPaket.DataSource = bindingSource
        Catch ex As Exception
            MessageBox.Show("Failed to Retrieve Data")
        End Try
    End Sub
    Sub clearForm()
        txtIDPaket.Clear()
        txtIDPenjual.Clear()
        txtIDProvider.Clear()
        txtPaket.Clear()
        txtPulsa.Clear()
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

    Private Sub frmPulsa_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        disconnectDb()
    End Sub

    Private Sub frmPulsa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            If IsNumeric(txtIDPaket.Text) And IsNumeric(txtIDPenjual.Text) And
            IsNumeric(txtIDProvider.Text) And IsNumeric(txtPulsa.Text) Then
                sqlQuery = ""
                sqlQuery = "INSERT INTO tblpaket(ID_Paket,ID_Provider,Nama_Paket,Jumlah_Pulsa,ID_Penjual,Status)" &
                    " VALUES(" & CInt(txtIDPaket.Text) & ",'" & CInt(txtIDProvider.Text) & "','" &
                    txtPaket.Text & "','" & CInt(txtPulsa.Text) & "','" & txtIDPenjual.Text & "','" & CStr(cbStatus.Text.ToString) & "')"
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
            If IsNumeric(txtIDPaket.Text) And IsNumeric(txtIDPenjual.Text) And
            IsNumeric(txtIDProvider.Text) And IsNumeric(txtPulsa.Text) Then
                sqlQuery = ""
                sqlQuery = "Update(tblpaket) SET " &
                            "ID_Provider = '" & txtIDProvider.Text & "'," &
                            "Nama_Paket = '" & txtPaket.Text & "'," &
                            "Jumlah_Pulsa = '" & txtPulsa.Text & "'," &
                            "ID_Penjual = '" & txtIDPenjual.Text & "' " &
                            "WHERE ID_Paket = " & CInt(txtIDPaket.Text)
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

    Private Sub dgvPaket_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPaket.CellClick
        Dim reader As MySqlDataReader
        sqlQuery = ""
        sqlQuery = "SELECT * FROM tblpaket;"
        cmd.Connection = conn
        cmd.CommandText = sqlQuery
        reader = cmd.ExecuteReader
        If reader.HasRows = True Then
            btnEdit.Enabled = True
            btnDelete.Enabled = True
            btnAdd.Enabled = False
            btnCancel.Enabled = True
            Dim i As Integer = dgvPaket.CurrentRow.Index
            txtIDPaket.Text = dgvPaket.Item(0, i).Value
            txtIDProvider.Text = dgvPaket.Item(1, i).Value
            txtPaket.Text = dgvPaket.Item(2, i).Value
            txtPulsa.Text = dgvPaket.Item(3, i).Value
            txtIDPenjual.Text = dgvPaket.Item(4, i).Value
            txtIDPaket.ReadOnly = True
        End If
        reader.Close()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim result As DialogResult = MessageBox.Show("Edit data with Paket ID Of = " &
                                                     txtIDPaket.Text,
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
        Dim result As DialogResult = MessageBox.Show("Delete data with ID_Paket = " &
                                                     txtIDPaket.Text,
                                                     "Notification Delete Data",
                                                     MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            MessageBox.Show("Cancel Delete Data")
        ElseIf result = DialogResult.Yes Then
            sqlQuery = ""
            sqlQuery = "DELETE FROM tblpaket" &
                        " WHERE ID_Paket = " & CInt(txtIDPaket.Text)
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