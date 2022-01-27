Imports MySql.Data.MySqlClient

Public Class Form2
    Dim sqlCon As New DBModule()
    Dim sqlCmd As New MySqlCommand



    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        affichage()

    End Sub

    Public Sub affichage()
        Dim conn = sqlCon.Open()
        Dim query As String = " Select * from enseignant"
        Dim SqlDa As New MySqlDataAdapter(query, conn)
        Dim Ds As New DataSet()
        SqlDa.Fill(Ds)
        DataGridEnseignant.DataSource = Ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn = sqlCon.Open()

        Try
            sqlCmd = conn.CreateCommand
            sqlCmd.CommandText = "Insert Into enseignant(nom,prenoms,contacts) values(@nom,@prenoms,@contacts)"
            sqlCmd.Parameters.AddWithValue("@nom", nom.Text)
            sqlCmd.Parameters.AddWithValue("@prenoms", prenoms.Text)
            sqlCmd.Parameters.AddWithValue("@contacts", contacts.Text)
            sqlCmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            affichage()
        Catch ex As Exception
            MessageBox.Show("Insert Fail")
        End Try
    End Sub

    Private Sub DataGridEnseignant_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridEnseignant.CellContentClick
        Dim Datas As DataGridViewRow = DataGridEnseignant.CurrentRow
        Try
            id.Text = Datas.Cells(0).Value.ToString()
            nom.Text = Datas.Cells(1).Value.ToString()
            prenoms.Text = Datas.Cells(2).Value.ToString()
            contacts.Text = Datas.Cells(3).Value.ToString()

        Catch ex As Exception
            MessageBox.Show("DATAS row get Fail")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim conn = sqlCon.Open()

        Try
            sqlCmd = conn.CreateCommand()
            sqlCmd.CommandText = "Delete from enseignant where id=@id"
            sqlCmd.Parameters.AddWithValue("@id", id.Text)
            sqlCmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            affichage()
        Catch ex As Exception
            MessageBox.Show("Fail to Delete")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conn = sqlCon.Open()
        Try
            sqlCmd = conn.CreateCommand
            sqlCmd.CommandText = "update enseignant set nom=@nom,prenoms=@prenoms,contacts=@contacts where id=@id"
            sqlCmd.Parameters.AddWithValue("@id", id.Text)
            sqlCmd.Parameters.AddWithValue("@nom", nom.Text)
            sqlCmd.Parameters.AddWithValue("@prenoms", prenoms.Text)
            sqlCmd.Parameters.AddWithValue("@contacts", contacts.Text)
            sqlCmd.ExecuteNonQuery()
            conn.Close()
            affichage()

        Catch ex As Exception

        End Try
    End Sub
End Class