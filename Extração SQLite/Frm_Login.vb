Imports MySql.Data.MySqlClient
Imports Extração_SQLite.Cripto

Public Class Frm_Login
    Dim connstr As String = "Database=DCT; Datasource=187.45.202.59;User ID=flavio;Password=D&l05dgn"
    Dim connection As New MySqlConnection(connstr)
    Dim IDConfSenha As String
    Dim Cripto As New Cripto
    Public Perfil As Integer
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If TxtSenha.Text = IDConfSenha Then
            'Buscar Perfil
            Try
                Dim leitor As MySqlDataReader
                Dim connection As New MySqlConnection(connstr)
                Dim cmd As New MySqlCommand("select perfil_ID from colaborador where email='" & CmbEmail.Text & "'", connection)
                connection.Open()
                leitor = cmd.ExecuteReader
                leitor.Read()
                Perfil = leitor("perfil_ID")
                connection.Close()
            Catch
                MsgBox("Erro ao Buscar Perfil", MsgBoxStyle.Critical)
            End Try

            Frm_Extrator.Show()
            Me.Close()
        Else
            MsgBox("Senha Incorreta", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Frm_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Console.WriteLine(Carrega_cmdemail("Select email from Colaborador where status='ATIVO' order by email"))
    End Sub

    Function Carrega_cmdemail(ByVal Query As String) As Integer
        CmbEmail.Items.Clear()
        Try
            Dim leitor As MySqlDataReader
            Dim connection As New MySqlConnection(connstr)
            Dim cmd As New MySqlCommand(Query, connection)

            connection.Open()
            leitor = cmd.ExecuteReader
            Do While leitor.Read
                CmbEmail.Items.Add(leitor("email"))
            Loop

            connection.Close()

        Catch
            MsgBox("Erro ao carregar dados", MsgBoxStyle.Critical)

        End Try
        Return 0
    End Function

    Private Sub CmbEmail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEmail.SelectedIndexChanged
        TxtSenha.Text = ""
        Try
            Dim leitor As MySqlDataReader
            Dim connection As New MySqlConnection(connstr)
            Dim cmd As New MySqlCommand

            connection.Open()
            cmd.CommandText = "Select * from Colaborador where email = '" & CmbEmail.Text & "'"
            cmd.Connection = connection
            leitor = cmd.ExecuteReader
            leitor.Read()
            IDConfSenha = leitor("Senha")
            connection.Close()

        Catch
            MsgBox("Erro ao carregar ID", MsgBoxStyle.Critical)

        End Try
        'Descriptografar senha
        IDConfSenha = Cripto.Decrypt(IDConfSenha.Trim())

    End Sub
End Class

