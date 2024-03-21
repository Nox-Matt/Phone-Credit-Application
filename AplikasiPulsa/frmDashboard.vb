Public Class frmDashboard

    Private Sub btnPegawai_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPegawai.Click
        frmPegawai.ShowDialog()
    End Sub

    Private Sub btnProvider_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProvider.Click
        frmProvider.ShowDialog()
    End Sub

    Private Sub btnPulsa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPulsa.Click
        frmPulsa.ShowDialog()
    End Sub

    Private Sub btnPesanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesanan.Click
        frmDaftarPesanan.ShowDialog()
    End Sub
End Class