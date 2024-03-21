Public Class frmUserOrAdmin

    Private Sub btnUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUser.Click
        frmPesanan.ShowDialog()
    End Sub

    Private Sub btnAdmin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdmin.Click
        frmDashboard.ShowDialog()
    End Sub
End Class