Imports Microsoft.Office.Interop
Imports System.Text
Imports System.Data

Public Class Frm_Extrator
    Public ArquivoSQL As String
    Dim DS As New DataSet
    Dim DA As New SQLite.SQLiteDataAdapter
    Dim dt As New DataTable
    Dim ColunaGrid As Integer
    Dim Perfil As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OFD.Title = "Selecione o arquivo SQLite"
        OFD.Filter = "SQLite (*.db)|*.db"
        OFD.ShowDialog()
        ArquivoSQL = OFD.FileName

        'Sem o arquivo a aplicação fecha
        If ArquivoSQL = "" Then
            Application.Exit()
        End If

        Perfil = Frm_Login.Perfil
        If Perfil = 2 Or Perfil = 3 Or Perfil = 6 Then
            Try
                Dim conexao As New SQLite.SQLiteConnection
                conexao.ConnectionString = "Data Source=" & ArquivoSQL & "; Version=3"
                Dim Cmd As New SQLite.SQLiteCommand
                Dim leitor As SQLite.SQLiteDataReader
                conexao.Open()
                Cmd.Connection = conexao
                Cmd.CommandText = "select name from sqlite_master where type='table' order by name;"
                leitor = Cmd.ExecuteReader
                Do While leitor.Read
                    CmbColaborador.Items.Add(leitor("name"))
                Loop
                conexao.Close()
            Catch
                MsgBox("Erro ao Carregar os Dados", MsgBoxStyle.Critical)
            End Try
        Else
            CmbColaborador.Items.Add("consultor")
            CmbColaborador.Items.Add("local")
        End If

    End Sub

    Private Sub CmbColaborador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbColaborador.SelectedIndexChanged
        If CmbColaborador.Text = "DGA ELETRIC" Then
            Try
                DS.Reset()
                Dim connection As New SQLite.SQLiteConnection
                connection.ConnectionString = "Data Source=" & ArquivoSQL & "; Version=3"
                Dim cmd As New SQLite.SQLiteCommand
                DA.SelectCommand = New SQLite.SQLiteCommand("SELECT id as 'ID', " & _
                "(SELECT descricao FROM ti WHERE cod = ti) as 'TI',bay as 'Bay'," & _
                "(SELECT sigla FROM local_instalacao WHERE cod = local_instalacao) as 'Local de Instalacao'," & _
                "(SELECT descricao FROM centro_modular WHERE cod = centro_modular) as 'Centro Modular'," & _
                "(SELECT sigla FROM arranjo_fisico WHERE cod = arranjo_fisico) as 'Arranjo Fisico',tuc as 'TUC'," & _
                "(SELECT descricao FROM tuc WHERE cod = tuc) as 'Descrição da TUC',uar as 'Código da UAR'," & _
                "(SELECT descricao FROM uar where tuc_id = tuc AND cod = base_fisica.uar) as 'Descrição da UAR',tipo_bem as 'Código do Tipo de Bem'," & _
                "(SELECT descricao FROM tipo_bem WHERE tuc = base_fisica.tuc AND cod = base_fisica.tipo_bem) as 'Descrição do Tipo de Bem'," & _
                "(SELECT descricao FROM codigos WHERE cod = a2 AND tabela_id = (SELECT id FROM tabelas_367 WHERE id = (SELECT tabela_id FROM relacionamentos WHERE tuc = base_fisica.tuc AND a1 = base_fisica.tipo_bem AND num_atributo = 2))) as 'Descrição do a2',a3 as 'Código do a3'," & _
                "(SELECT descricao FROM codigos WHERE cod = a3 AND tabela_id = (SELECT id FROM tabelas_367 WHERE id = (SELECT tabela_id FROM relacionamentos WHERE tuc = base_fisica.tuc AND a1 = base_fisica.tipo_bem AND num_atributo = 3))) as 'Descrição do a3',a4 as 'Código do a4'," & _
                "(SELECT descricao FROM codigos WHERE cod = a4 AND tabela_id = (SELECT id FROM tabelas_367 WHERE id = (SELECT tabela_id FROM relacionamentos WHERE tuc = base_fisica.tuc AND a1 = base_fisica.tipo_bem AND num_atributo = 4))) as 'Descrição do  a4',a5 as 'Código do a5'," & _
                "(SELECT descricao FROM codigos WHERE cod = a5 AND tabela_id = (SELECT id FROM tabelas_367 WHERE id = (SELECT tabela_id FROM relacionamentos WHERE tuc = base_fisica.tuc AND a1 = base_fisica.tipo_bem AND num_atributo = 5))) as 'Descrição do a5',a6 as 'Código do a6'," & _
                "(SELECT descricao FROM codigos WHERE cod = a6 AND tabela_id = (SELECT id FROM tabelas_367 WHERE id = (SELECT tabela_id FROM relacionamentos WHERE tuc = base_fisica.tuc AND a1 = base_fisica.tipo_bem AND num_atributo = 6))) as 'Descrição do a6'," & _
                "qtde as 'Quantidade', um as 'Unidade de Medida', plaqueta as 'Plaqueta', Tag, fabricante as 'Fabricante', modelo as 'Modelo', serie as 'Série', dia_fabricacao as 'Dia de Fabricação', mes_fabricacao as 'Mês de Fabricação', ano_fabricacao as 'Ano de Fabricação', foto as 'Foto'," & _
                "status_bem as 'Status do Bem', estado_bem as 'Estado do Bem', descricao as 'Descrição', observacao as 'Observação', altura as 'Altura', largura as 'Largura', comprimento as 'Comprimento', bitola as 'Bitola', espessura as 'Espessura', area_construida as 'Área Construída', pe_direito as 'Pé Direito'," & _
                " observacao_civil as 'Observação Civil', descricao_edificacao as 'Descrição Edificação', local as 'Local', status as 'Status'," & _
                "(SELECT max(num_atributo)  FROM relacionamentos WHERE tuc = base_fisica.tuc AND a1 = base_fisica.tipo_bem) as 'Quantidade de Atributos' " & _
                "FROM base_fisica;", connection)
                DA.Fill(DS, "TB_SQLite")
                DGV.DataSource = DS.Tables("TB_SQLite")
                connection = Nothing
            Catch
            End Try
        Else
            DS.Reset()
            Dim connection As New SQLite.SQLiteConnection
            connection.ConnectionString = "Data Source=" & ArquivoSQL & "; Version=3"
            Dim cmd As New SQLite.SQLiteCommand
            cmd.CommandType = CommandType.Text
            DA.SelectCommand = New SQLite.SQLiteCommand("select * from " & CmbColaborador.Text & ";", connection)
            Dim DTBuilder As New SQLite.SQLiteCommandBuilder(DA)
            DA.Fill(DS, "TB_SQLite")
            DGV.DataSource = DS.Tables("TB_SQLite")
            connection = Nothing
        End If
    End Sub

    Private Sub EXCELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCELToolStripMenuItem.Click

        If DGV.DataSource Is Nothing Then
            MsgBox("Base Vazia!", MsgBoxStyle.Information)
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("plan1")
            For k As Integer = 1 To DGV.Columns.Count
                xlWorkSheet.Cells(1, k) = DGV.Columns(k - 1).HeaderText
            Next
            For i = 0 To DGV.RowCount - 1
                For j = 0 To DGV.ColumnCount - 1
                    xlWorkSheet.Cells(i + 2, j + 1) = DGV(j, i).Value
                Next
            Next

            xlWorkSheet.Columns.AutoFit()
            xlWorkSheet.Name = CmbColaborador.Text
            xlApp.Visible = True
            Me.Close()
        Catch
            MsgBox("Erro ao exportar para Excel", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub INSERIRToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim cd As New SQLite.SQLiteCommandBuilder(DA)
        DA.Update(DS, "TB_SQLite")

    End Sub
  
    Private Sub CRIARToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CRIARToolStripMenuItem.Click
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim Sh_T As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim salvar As String
        Try
            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            Sh_T = xlWorkBook.Sheets("plan1")
            Sh_T.Name = "Carga"
            Sh_T.Range("a1").Value = "id"
            Sh_T.Range("b1").Value = "iduc"
            Sh_T.Range("c1").Value = "ti"
            Sh_T.Range("d1").Value = "bay"
            Sh_T.Range("e1").Value = "local_instalacao"
            Sh_T.Range("f1").Value = "centro_modular"
            Sh_T.Range("g1").Value = "arranjo_fisico"
            Sh_T.Range("h1").Value = "TUC"
            Sh_T.Range("i1").Value = "uar"
            Sh_T.Range("j1").Value = "tipo_bem"
            Sh_T.Range("k1").Value = "a2"
            Sh_T.Range("l1").Value = "a3"
            Sh_T.Range("m1").Value = "a4"
            Sh_T.Range("n1").Value = "a5"
            Sh_T.Range("o1").Value = "a6"
            Sh_T.Range("p1").Value = "qtde"
            Sh_T.Range("q1").Value = "um"
            Sh_T.Range("r1").Value = "plaqueta"
            Sh_T.Range("s1").Value = "tag"
            Sh_T.Range("t1").Value = "fabricante"
            Sh_T.Range("u1").Value = "modelo"
            Sh_T.Range("v1").Value = "Nº Série"
            Sh_T.Range("w1").Value = "dia_fabricacao"
            Sh_T.Range("x1").Value = "mes_fabricacao"
            Sh_T.Range("y1").Value = "ano_fabricacao"
            Sh_T.Range("z1").Value = "foto"
            Sh_T.Range("aa1").Value = "status_bem"
            Sh_T.Range("ab1").Value = "estado_bem"
            Sh_T.Range("ac1").Value = "descricao"
            Sh_T.Range("ad1").Value = "observação"
            Sh_T.Range("ae1").Value = "altura"
            Sh_T.Range("af1").Value = "largura"
            Sh_T.Range("ag1").Value = "comprimento"
            Sh_T.Range("ah1").Value = "bitola"
            Sh_T.Range("ai1").Value = "espessura"
            Sh_T.Range("aj1").Value = "area_construida"
            Sh_T.Range("ak1").Value = "pe_direito"
            Sh_T.Range("al1").Value = "observacao_civil"
            Sh_T.Range("am1").Value = "descricao_edificacao"
            Sh_T.Range("an1").Value = "local"
            Sh_T.Range("ao1").Value = "consultor"
            Sh_T.Range("ap1").Value = "status"
            Sh_T.Range("aq1").Value = "criado_em"
            Sh_T.Range("ar1").Value = "atualizado_em"
            Sh_T.Columns.AutoFit()
            Sh_T.Range("a1:ar1").Font.Bold = True
            Sh_T.Range("a1:ar1").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray)

            SFD.Title = "Selecione o local para Salvar em Excel"
            SFD.Filter = "Excel (*.xlsx)|*.xlsx"
            If SFD.ShowDialog = Windows.Forms.DialogResult.OK Then
                salvar = SFD.FileName
                xlWorkBook.SaveAs(salvar)
                xlApp.Visible = True
            Else
                xlApp.Workbooks(1).Close(False)
            End If
            
        Catch
            MsgBox("Erro ao Carregar Excel!", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CARREGARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CARREGARToolStripMenuItem.Click
        Frm_Carregar.Show()
        Me.Hide()
    End Sub

    Private Sub DGV_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.RowLeave
        Try
            DA.Update(DGV.DataSource)
        Catch
            MsgBox("Erro ao Alterar os Dados!", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
