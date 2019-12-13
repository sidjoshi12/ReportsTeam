Imports System.IO

Public Class Form1
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Application.Exit()
        'Engine.cnstring = "data source=" + cmbServer.Text + ";user id=" + cmbUID.Text + ";password=" + cmbPass.Text + ";initial catalog=" + cmbDB.Text
        'Dim bcp As New ImpExp(cmbServer.Text, cmbUID.Text, cmbPass.Text, cmbDB.Text)

        'Dim test As String() = {"dbo.DimCase"}
        'For Each tab As String In test
        '    CreateView(tab, " EffectiveToTimeKey=49999 ")
        '    bcp.priBCPExport("backup\" & tab & ".txt", "bcpview")
        'Next
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
        SaveSettings()

        Engine.cnstring = "data source=" + cmbServer.Text + ";user id=" + cmbUID.Text + ";password=" + cmbPass.Text + ";initial catalog=" + cmbDB.Text
        If cmbAction.Text = "Import" Then
            ImportData()
        ElseIf cmbAction.Text = "Export" Then
            ExportData()
        End If
    End Sub
    Private Sub ImportData()
        Dim bcp As New ImpExp(cmbServer.Text, cmbUID.Text, cmbPass.Text, cmbDB.Text)

        Dim imp As New SSFB
        For Each row As DataRow In imp.getTables().Rows
            Dim tab As String
            tab = row("Schema").ToString() & "." & row("TableName")
            bcp.priBCPImport("backup\" & tab & ".txt", row("Schema").ToString() & "." & row("TableName"))
        Next

        For Each row As DataRow In imp.getdataTables().Rows
            Dim tab As String
            tab = row("Schema").ToString() & "." & row("TableName")
            bcp.priBCPImport("backup\" & tab & ".txt", row("Schema").ToString() & "." & row("TableName"))
        Next
        MessageBox.Show("Done!!")
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
        Dim TimeKey As String = "25202"
        Dim BranchCode As String = "3112"

        Dim imp As New SSFB
        For Each row As DataRow In imp.getTables().Rows
            Dim tab, filter As String
            tab = row("Schema").ToString() & "." & row("TableName")
            filter = row("Filter").ToString().Replace("EffectiveFromTimeKey", " EffectiveFromTimeKey<= " & TimeKey)
            filter = filter.Replace("EffectiveToTimeKey", " EffectiveToTimeKey>= " & TimeKey)
            CreateView(tab, filter)
            bcp.priBCPExport("backup\" & tab & ".txt", "bcpview")
        Next

        For Each row As DataRow In imp.getdataTables().Rows
            Dim tab, filter As String
            tab = row("Schema").ToString() & "." & row("TableName")
            filter = row("Filter").ToString().Replace("BranchCode", " and BranchCode=" & BranchCode)
            filter = filter.Replace("EffectiveFromTimeKey", " EffectiveFromTimeKey<= " & TimeKey)
            filter = filter.ToString().Replace("EffectiveToTimeKey", " EffectiveToTimeKey>= " & TimeKey)
            CreateView(tab, filter)
            bcp.priBCPExport("backup\" & tab & ".txt", "bcpview")
        Next


        'For Each deleteFile In System.IO.Directory.GetFiles("backup", "*.*", SearchOption.TopDirectoryOnly)
        '    File.Delete(deleteFile)
        'Next
        MessageBox.Show("Done!!")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initDB()
        ds = New DataSet()
        ds.ReadXml(Application.StartupPath & "\ds.xml")
        dt = ds.Tables(0)

        AddItems("Server", cmbServer)
        AddItems("UID", cmbUID)
        AddItems("Pass", cmbPass)
        AddItems("TimeKey", cmbTimeKey)
        AddItems("DB", cmbDB)

        cmbAction.Text = dt.Rows(0)("Action")
    End Sub
    Dim ds As DataSet
    Dim dt As DataTable
    Private Sub initDB()

        If Not System.IO.File.Exists("ds.xml") Then

            dt = New DataTable()
            dt.Columns.Add("Server", GetType(String))
            dt.Columns.Add("UID", GetType(String))
            dt.Columns.Add("Pass", GetType(String))
            dt.Columns.Add("DB", GetType(String))
            dt.Columns.Add("TimeKey", GetType(String))
            dt.Columns.Add("Action", GetType(String))

            'dt.Rows.Add("DBSERVER\DBSERVER", "dm085", "1808", "JKGB_MISDB_DEV", "25202", "Export")
            dt.Rows.Add("D2K62\SQLEXPRESS", "sa", "sa123", "SSFB", "25202", "Import")
            ds = New DataSet()
            ds.Tables.Add(dt)
            ds.WriteXml("ds.xml")
        End If
    End Sub
    Private Sub AddItems(ByVal col As String, ByRef cbo As ComboBox)
        cbo.Items.Clear()
        For Each dr As DataRow In dt.Rows
            cbo.Items.Add(dr(col).ToString())
        Next
        cbo.Text = dt.Rows(0)(col).ToString()
    End Sub
    Private Sub SaveSettings()
        Dim dr As DataRow
        dr = dt.NewRow()
        dr("Server") = cmbServer.Text
        dr("UID") = cmbUID.Text
        dr("Pass") = cmbPass.Text
        dr("DB") = cmbDB.Text
        dr("TimeKey") = cmbTimeKey.Text
        dr("Action") = cmbAction.Text
        dt.Rows.InsertAt(dr, 0)

        Dim columns() As String = {"Server", "UID", "Pass", "DB", "TimeKey", "Action"}
        dt = SelectTopFrom(dt, columns, 5)

        ds.Tables.Clear()
        ds.Tables.Add(dt)

        ds.WriteXml("ds.xml")
    End Sub
    Public Function SelectTopFrom(ByVal dataSource As DataTable, ByVal distinctColumns() As String, ByVal rowCount As Integer) As DataTable
        Dim view As New DataView(dataSource)
        dataSource = view.ToTable("Table1", True, distinctColumns)
        rowCount = If(dataSource.Rows.Count < rowCount, dataSource.Rows.Count, rowCount)
        Dim dtn As DataTable = dataSource.Clone()
        For i As Integer = 0 To rowCount - 1
            dtn.ImportRow(dataSource.Rows(i))
        Next
        Return dtn
    End Function
End Class