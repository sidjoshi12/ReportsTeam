Public Class Class1
    Public Function getDateDiff(ByVal startDate As DateTime, ByVal endDate As DateTime) As String
        Dim endY As Integer = endDate.Year
        Dim startY As Integer = startDate.Year
        Dim tempY As Integer = 0
        Dim endM As Integer = endDate.Month
        Dim startM As Integer = startDate.Month
        Dim tempM As Integer = 0
        Dim endD As Integer = endDate.Day
        Dim startD As Integer = startDate.Day
        Dim tempD As Integer = 0

        If endD > startD Then
            tempD = endD - startD
        Else
            endD += DateTime.DaysInMonth(endY, endM)
            endM -= 1
            tempD = endD - startD
        End If

        If endM > startM Then
            tempM = endM - startM
        Else
            endM += 12
            tempM = endM - startM
            endY -= 1
        End If

        tempY = endY - startY
        Return PadTwo(tempY) & ":" & PadTwo(tempM) & ":" & PadTwo(tempD)
    End Function
    Public Function PadTwo(ByVal num As Integer) As String
        If num < 10 Then
            Return "0" & num.ToString()
        Else
            Return num.ToString()
        End If
    End Function
End Class
