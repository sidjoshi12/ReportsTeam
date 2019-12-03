Imports System.IO

Public Class Form1
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Application.Exit()
        Engine.cnstring = "data source=" + cmbServer.Text + ";user id=" + cmbUID.Text + ";password=" + cmbPass.Text + ";initial catalog=" + cmbDB.Text
        Dim bcp As New ImpExp(cmbServer.Text, cmbUID.Text, cmbPass.Text, cmbDB.Text)

        Dim test As String() = {"dbo.DimCase"}
        For Each tab As String In test
            CreateView(tab, " EffectiveToTimeKey=49999 ")
            bcp.priBCPExport("backup\" & tab & ".txt", "bcpview")
        Next
    End Sub

    Private Sub CreateView(tableName As String, Optional condition As String = "")
        Dim sql As String
        If condition <> "" Then
            condition = " where " & condition
        End If

        sql = "if object_id('bcpview')is not null drop view bcpview "
        Engine.ExecuteQry(sql)
        sql = " create view bcpview as select * from " & tableName & condition
        Engine.ExecuteQry(sql)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Engine.cnstring = "data source=" + cmbServer.Text + ";user id=" + cmbUID.Text + ";password=" + cmbPass.Text + ";initial catalog=" + cmbDB.Text
        If cmbAction.Text = "Import" Then
            ImportData()
        ElseIf cmbAction.Text = "Export" Then
            ExportData()
        End If
    End Sub
    Private Sub ImportData()

    End Sub
    Private Sub ExportData()
        If System.IO.Directory.Exists("backup") Then
            'System.IO.Directory.Delete("backup")

            For Each deleteFile In System.IO.Directory.GetFiles("backup", "*.*", SearchOption.TopDirectoryOnly)
                File.Delete(deleteFile)
            Next
        End If
        System.IO.Directory.CreateDirectory("backup")

        Dim bcp As New ImpExp(cmbServer.Text, cmbUID.Text, cmbPass.Text, cmbDB.Text)

        ''master table backups
        'Dim masterTables As DataTable = Engine.getDataTable("select schema_name(schema_id)as [Schema],Name from sys.tables where name like 'dim%'", "masters")
        'For Each table As DataRow In masterTables.Rows
        '    CreateView(table("Schema").ToString() & "." & table("Name").ToString())
        '    bcp.priBCPExport("backup\" & table("Schema").ToString() & "." & table("Name").ToString() & ".txt", "bcpview")
        'Next

        Dim imp As New UKOLegalPlus
        For Each row As DataRow In imp.getTables().Rows
            Dim tab, filter As String
            tab = row("Schema").ToString() & "." & row("TableName")
            filter = row("Filter").ToString().Replace("EffectiveToTimeKey", " EffectiveToTimeKey=49999 ")
            CreateView(tab, filter)
            bcp.priBCPExport("backup\" & tab & ".txt", "bcpview")
        Next

        For Each row As DataRow In imp.getdataTables().Rows
            Dim tab, filter As String
            tab = row("Schema").ToString() & "." & row("TableName")
            filter = row("Filter").ToString().Replace("EffectiveToTimeKey", " EffectiveToTimeKey=49999 ")
            filter = row("Filter").ToString().Replace("BranchCode", " and BranchCode='1093' ")
            CreateView(tab, filter)
            bcp.priBCPExport("backup\" & tab & ".txt", "bcpview")
        Next


        'For Each deleteFile In System.IO.Directory.GetFiles("backup", "*.*", SearchOption.TopDirectoryOnly)
        '    File.Delete(deleteFile)
        'Next
        MessageBox.Show("Done!!")
    End Sub
End Class