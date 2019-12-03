Public Class ImpExp
    Dim strSqlServer As SQLDMO.SQLServer
    Dim strTable As New SQLDMO.Table
    Dim sqlView As New SQLDMO.View
    Dim sqlDataBase As New SQLDMO.Database
    Dim xBCP As New SQLDMO.BulkCopy

    Public Sub New(ServerName As String, UserID As String, pwd As String, DatabaseName As String)
        On Error Resume Next
        sqlDataBase = Nothing
        strSqlServer = Nothing
        xBCP = Nothing
        On Error GoTo 0
        strSqlServer = New SQLDMO.SQLServer
        strSqlServer.Connect(ServerName, UserID, pwd)
        sqlDataBase = strSqlServer.Databases.Item(DatabaseName)

        xBCP = New SQLDMO.BulkCopy
        xBCP.DataFileType = SQLDMO.SQLDMO_DATAFILE_TYPE.SQLDMODataFile_SpecialDelimitedChar 'SQLDMODataFile_TabDelimitedChar  ' 'SQLDMODataFile_SpecialDelimtedChar
        xBCP.ColumnDelimiter = "|"
        xBCP.RowDelimiter = vbCrLf
    End Sub

    Sub New()
        ' TODO: Complete member initialization 
    End Sub

    Public Sub priBCPExport(ByRef txtFileName As String, ByRef ViewName As String)
        'If UserID = "sa" Then
        '    UserID = "dbo"
        'End If

        sqlView = sqlDataBase.Views.Item(ViewName)
        xBCP.DataFilePath = txtFileName
        sqlView.ExportData(xBCP)
    End Sub
End Class
