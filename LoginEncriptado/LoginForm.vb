Public Class LoginForm
    Dim Usuario As String
    Dim Clave As String

    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        VerificaUsuario(txtUsuario.Text) : Usuario = Resultado
        VerificaUsuario(txtClave.Text) : Clave = Resultado

        If VerificaExistencia() = True Then
            Dim cmd As New OleDb.OleDbCommand("select * from usuarios where usuario=@user and clave=@password", Conexion)
            cmd.Parameters.AddWithValue("user", OleDb.OleDbType.Variant).Value = Usuario
            cmd.Parameters.AddWithValue("password", OleDb.OleDbType.Variant).Value = Clave
            Dim da As New OleDb.OleDbDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                MainForm.Show()
                Me.Hide()
            Else
                MessageBox.Show("Usuario o Clave incorrecto", "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MainForm.Show()
        End If

    End Sub

    Private Function VerificaExistencia() As Boolean
        Dim da As New OleDb.OleDbDataAdapter("select * from usuarios", Conexion)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        End
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AbrirConexion()
    End Sub
End Class