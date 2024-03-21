Imports MySql.Data.MySqlClient
Imports System
Imports System.Globalization
Imports System.Threading
Module mdlConfig
    Public conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public sqlQuery As String
    'Module for connectivity to Database'

    Public Sub connectDb()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.ConnectionString = "DATABASE=dbltokopulsa;SERVER=localhost;" +
                    "user id=root;password=ukrida;port=3306;charset=utf8"
                conn.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Error Connecting to Database", "Error Database Server", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End Try
    End Sub

    Public Sub disconnectDb()
        Try
            conn.Open()
        Catch ex As MySql.Data.MySqlClient.MySqlException
        End Try
    End Sub
End Module
