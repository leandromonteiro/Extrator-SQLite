Imports Microsoft.Office.Interop
Imports System.Data.OleDb
Public Class Frm_Carregar
    Dim ArquivoExcel As String
    Dim ArquivoSQL As String

    Private Sub Frm_Carregar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Frm_Extrator.Show()
    End Sub
    Private Sub Frm_Carregar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnCarregar.Enabled = False
        BtnCarga.Enabled = True
        PB.Visible = False
        ArquivoSQL = Frm_Extrator.ArquivoSQL
    End Sub

    Private Sub BtnCarga_Click(sender As Object, e As EventArgs) Handles BtnCarga.Click
        OFD.Title = "Selecione a carga"
        OFD.Filter = "SQLite (*.xlsx)|*.xlsx"
        OFD.ShowDialog()
        ArquivoExcel = OFD.FileName

        'Sem o arquivo a aplicação fecha
        If ArquivoExcel = "" Then
            Application.Exit()
        End If

        Try
            Dim con As New OleDbConnection
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & ArquivoExcel & "';Extended Properties= 'Excel 12.0';"
            Dim cmd As New OleDbCommand
            Dim DA As New OleDbDataAdapter
            con.Open()
            DA.SelectCommand = New OleDbCommand("SELECT * FROM [Carga$];", con)
            Dim DS As New DataSet
            DA.Fill(DS, "TB_Carga")
            DGV_Carga.DataSource = DS.Tables("TB_Carga")
            con.Close()
            BtnCarregar.Enabled = True
            BtnCarga.Enabled = False
        Catch
            MsgBox("Erro ao Carregar os Dados", MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub BtnCarregar_Click(sender As Object, e As EventArgs) Handles BtnCarregar.Click
        Dim r As Integer
        r = DGV_Carga.RowCount
        Dim Resultado As DialogResult = MsgBox("Deseja excluir base anterior?", MsgBoxStyle.YesNo)
        If Resultado = Windows.Forms.DialogResult.Yes Then
            Try
                Dim conexao1 As New SQLite.SQLiteConnection
                conexao1.ConnectionString = "Data Source=" & ArquivoSQL & "; Version=3"
                Dim Cmd1 As New SQLite.SQLiteCommand
                conexao1.Open()
                Cmd1.Connection = conexao1
                Cmd1.CommandText = "Delete from base_fisica"
                Cmd1.ExecuteNonQuery()
                conexao1.Close()
            Catch
                MsgBox("Base Limpa!", MsgBoxStyle.Information)
            End Try
        End If
        PB.Visible = True

        Try
            Dim conexao As New SQLite.SQLiteConnection
            conexao.ConnectionString = "Data Source=" & ArquivoSQL & "; Version=3"
            Dim Cmd As New SQLite.SQLiteCommand
            conexao.Open()
            Cmd.Connection = conexao
            For i = 0 To r - 1
                Cmd.CommandText = "insert into base_fisica values(null" & _
                    ",'" & DGV_Carga.Item(1, i).Value & _
                    "','" & DGV_Carga.Item(2, i).Value & _
                    "','" & DGV_Carga.Item(3, i).Value & _
                    "','" & DGV_Carga.Item(4, i).Value & _
                    "','" & DGV_Carga.Item(5, i).Value & _
                    "','" & DGV_Carga.Item(6, i).Value & _
                    "','" & DGV_Carga.Item(7, i).Value & _
                    "','" & DGV_Carga.Item(8, i).Value & _
                    "','" & DGV_Carga.Item(9, i).Value & _
                    "','" & DGV_Carga.Item(10, i).Value & _
                    "','" & DGV_Carga.Item(11, i).Value & _
                    "','" & DGV_Carga.Item(12, i).Value & _
                    "','" & DGV_Carga.Item(13, i).Value & _
                    "','" & DGV_Carga.Item(14, i).Value & _
                    "','" & DGV_Carga.Item(15, i).Value & _
                    "','" & DGV_Carga.Item(16, i).Value & _
                    "','" & DGV_Carga.Item(17, i).Value & _
                    "','" & DGV_Carga.Item(18, i).Value & _
                    "','" & DGV_Carga.Item(19, i).Value & _
                    "','" & DGV_Carga.Item(20, i).Value & _
                    "','" & DGV_Carga.Item(21, i).Value & _
                    "','" & DGV_Carga.Item(22, i).Value & _
                    "','" & DGV_Carga.Item(23, i).Value & _
                    "','" & DGV_Carga.Item(24, i).Value & _
                    "','" & DGV_Carga.Item(25, i).Value & _
                    "','" & DGV_Carga.Item(26, i).Value & _
                    "','" & DGV_Carga.Item(27, i).Value & _
                    "','" & DGV_Carga.Item(28, i).Value & _
                    "','" & DGV_Carga.Item(29, i).Value & _
                    "','" & DGV_Carga.Item(30, i).Value & _
                    "','" & DGV_Carga.Item(31, i).Value & _
                    "','" & DGV_Carga.Item(32, i).Value & _
                    "','" & DGV_Carga.Item(33, i).Value & _
                    "','" & DGV_Carga.Item(34, i).Value & _
                    "','" & DGV_Carga.Item(35, i).Value & _
                    "','" & DGV_Carga.Item(36, i).Value & _
                    "','" & DGV_Carga.Item(37, i).Value & _
                    "','" & DGV_Carga.Item(38, i).Value & _
                    "','" & DGV_Carga.Item(39, i).Value & _
                    "','" & DGV_Carga.Item(40, i).Value & _
                    "','" & DGV_Carga.Item(41, i).Value & _
                    "','" & DGV_Carga.Item(42, i).Value & _
                    "','" & DGV_Carga.Item(43, i).Value & _
                    "');"
                Cmd.ExecuteNonQuery()
                PB.Value = CInt((i / (r - 1)) * 100)
            Next
            conexao.Close()
            PB.Visible = False
            MsgBox("Dados inseridos com sucesso.", MsgBoxStyle.Information)
            Frm_Extrator.Show()
            Me.Close()
        Catch
            MsgBox("Os dados não foram inseridos. Verifique os possíveis problemas de carga abaixo:" & vbCrLf & vbCrLf & _
                   "* Iduc: Não duplicada." & vbCrLf & _
                   "* TI, A1, A2, A3, A4, A5 E A6: Máximo 2 caracteres." & vbCrLf & _
                   "* A1, A2, A3, A4, A5 E A6: Colocar '0' antes de 1, 2, 3, 4, 5, 6, 7, 8 e 9." & vbCrLf & _
                   "* Quantidade: Formato número com no máximo 11 caracteres." & vbCrLf & _
                   "* TUC: Máximo 3 caracteres.", MsgBoxStyle.Critical)
        End Try
    End Sub


End Class