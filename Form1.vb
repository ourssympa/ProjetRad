Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Sub PanelSwitcher(ByVal panel As Form)
        Home_panel.Controls.Clear()
        panel.TopLevel = False
        panel.Visible = True
        panel.WindowState = FormWindowState.Maximized
        Home_panel.Controls.Add(panel)
        Home_panel.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim enseignantPanel As New Form2()
        PanelSwitcher(enseignantPanel)

    End Sub
End Class
