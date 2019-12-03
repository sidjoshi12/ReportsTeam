
Imports System.Data.SqlClient

Class Engine
    Public Shared ErrorMsg As String = ""
    Public Shared cnstring As String = "data source=d2k62\sqlexpress;user id=sa;password=sa123;initial catalog=OVSepPOST"

    Public Shared Function ExecuteQry(ByVal qry As String) As Boolean
        ErrorMsg = ""
        Dim cn As SqlConnection = New SqlConnection(cnstring)
        Dim cmd As SqlCommand = New SqlCommand()
        cn.Open()
        cmd.Connection = cn
        cmd.CommandText = qry

        Try
            cmd.ExecuteNonQuery()
            cn.Close()
            Return True
        Catch ex As Exception
            cn.Close()
            ErrorMsg = ex.Message
            Return False
        End Try
    End Function

    Public Shared Function getDataTable(ByVal sql As String, Optional ByVal tableName As String = "Table1") As DataTable
        Dim cn As SqlConnection = New SqlConnection(cnstring)
        cn.Open()
        Dim ad As SqlDataAdapter = New SqlDataAdapter(sql, cn)
        Dim dt As DataTable = New DataTable(tableName)
        ad.Fill(dt)
        cn.Close()

        If dt.Rows.Count > 0 Then
            Return dt
        Else
            Return Nothing
        End If
    End Function
End Class

