Imports MySql.Data.MySqlClient

Public Class DBModule
    Dim Con As New MySqlConnection("Server=127.0.0.1;user=root;password=;database=SchoolGer")

    Public Function Open() As MySqlConnection
        Try
            Con.Open()
        Catch ex As Exception
            MessageBox.Show("DATA LOAD FAIL")
        End Try
        Return Con
    End Function

    Public Function Close() As MySqlConnection
        Try
            Con.Close()
        Catch ex As Exception
            MessageBox.Show("DATA CLOSE FAIL")
        End Try

        Return Con
    End Function
End Class