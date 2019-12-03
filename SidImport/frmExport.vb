Public Class frmExport
    Dim ds As New DataSet
    Private Sub frmExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim branchDt As DataTable = Engine.getDataTable("select BranchCode,BranchName from mstBranch where delsta is null", "BranchCode")
        Dim regionDt As DataTable = Engine.getDataTable("select RegionCode,RegionName from mstRegion where delsta is null", "RegionCode")
        Dim zoneDt As DataTable = Engine.getDataTable("select ZoneCode,ZoneName from mstZone where delsta is null", "ZoneCode")

        ds.Tables.Add(branchDt)
        ds.Tables.Add(regionDt)
        ds.Tables.Add(zoneDt)

        optBranch.Checked = True
        txtBranchCode.setDataSource(ds.Tables("BranchCode"), "BranchCode")
        txtBranchName.setDataSource(ds.Tables("BranchCode"), "BranchName")
    End Sub

    Private Sub optBranch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBranch.CheckedChanged, optZone.CheckedChanged, optRegion.CheckedChanged, optBank.CheckedChanged
        Dim rad As RadioButton = DirectCast(sender, RadioButton)
        If rad.Text <> "Bank" Then
            lblBranchCode.Enabled = True
            lblBranchName.Enabled = True
            txtBranchCode.Enabled = True
            txtBranchName.Enabled = True

            txtBranchCode.Text = ""
            txtBranchName.Text = ""
            lblBranchCode.Text = rad.Text & " Code"
            lblBranchName.Text = rad.Text & " Name"

            txtBranchCode.setDataSource(ds.Tables(rad.Text & "Code"), rad.Text & "Code")
            txtBranchName.setDataSource(ds.Tables(rad.Text & "Code"), rad.Text & "Name")
        Else
            lblBranchCode.Enabled = False
            lblBranchName.Enabled = False
            txtBranchCode.Enabled = False
            txtBranchName.Enabled = False
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

    End Sub
End Class