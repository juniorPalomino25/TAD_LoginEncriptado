Public Class CreateLogin
    Dim Usuario As String
    Dim Clave As String

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        VerificaUsuario(txtUsuario.Text) : Usuario = Resultado
        VerificaUsuario(txtClave.Text) : Clave = Resultado

        If VerificaExistencia() = False Then
            Dim cmd As New OleDb.OleDbCommand("insert into usuarios(usuario,clave) values(@user,@password)", Conexion)
            cmd.Parameters.AddWithValue("@user", OleDb.OleDbType.Variant).Value = Usuario
            cmd.Parameters.AddWithValue("@password", OleDb.OleDbType.Variant).Value = Clave
            cmd.ExecuteNonQuery()

            PoblarGrid()
        Else
            MessageBox.Show("Usuario ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub PoblarGrid()
        Dim da As New OleDb.OleDbDataAdapter("select * from usuarios", Conexion)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            DataGridView1.DataSource = ds.Tables(0)
        Else
            DataGridView1.DataSource = Nothing
        End If
    End Sub

    Private Function VerificaExistencia() As Boolean
        Dim cmd As New OleDb.OleDbCommand("select * from usuarios where usuario=@user", Conexion)
        cmd.Parameters.AddWithValue("@user", OleDb.OleDbType.Variant).Value = Usuario

        Dim da As New OleDb.OleDbDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim cmd As New OleDb.OleDbCommand("delete * from usuarios where id=" & DataGridView1.CurrentRow.Cells("ID").Value, Conexion)
        cmd.ExecuteNonQuery()

        PoblarGrid()
    End Sub

    Private Sub CreateLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PoblarGrid()
    End Sub
End Class