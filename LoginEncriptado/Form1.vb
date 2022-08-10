Public Class MainForm

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AbrirConexion()
    End Sub

    Private Sub CrearUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearUsuarioToolStripMenuItem.Click
        CreateLogin.Show()
    End Sub

    Private Sub CrearUsuarioToolStripMenuItem_Disposed(sender As Object, e As EventArgs) Handles CrearUsuarioToolStripMenuItem.Disposed
        Application.Exit()
    End Sub
End Class
