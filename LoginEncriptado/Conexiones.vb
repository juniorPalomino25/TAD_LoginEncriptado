Imports System.Text
Imports System.Security.Cryptography

Module Conexiones

    Public Resultado As String

    Public Conexion As OleDb.OleDbConnection
    Public Comando As OleDb.OleDbCommand
    Public Adaptador As OleDb.OleDbDataAdapter


    Public Sub AbrirConexion()
        Conexion = New OleDb.OleDbConnection
        Conexion.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=basedatos.mdb;"

        If Conexion.State = ConnectionState.Closed Then
            Conexion.Open()
        End If

    End Sub

    'AQUI ENCRIPTAMOS A LOS USUARIOS'
    Public Function VerificaUsuario(ByVal SourceText As String) As String
        'Create an encoding object to ensure the encoding standard for the source text
        Dim Ue As New UnicodeEncoding()
        'Retrieve a byte array based on the source text
        Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
        'Instantiate an MD5 Provider object
        Dim Md5 As New MD5CryptoServiceProvider()
        'Compute the hash value from the source
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        'And convert it to String format for return
        Resultado = Convert.ToBase64String(ByteHash)
        Return Convert.ToBase64String(ByteHash)
    End Function

End Module
