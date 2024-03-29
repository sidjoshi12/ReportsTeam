﻿Public Class SSFB

    ''master tables
    Public Function getTables() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Schema")
        dt.Columns.Add("TableName")
        dt.Columns.Add("Filter")

        dt.Rows.Add("dbo", "SysReportformat")
        dt.Rows.Add("dbo", "SysReportDirectory", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimBusinessGroup", "EffectiveFromTimeKey AND EffectiveToTimeKey")

        dt.Rows.Add("dbo", "DimAcCategory", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimAcClosure", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimAcSplCategory", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimActivity", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimAddressCategory", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimArea", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimAssetClass", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimAssetsNature", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimAuthority", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DIMBANK", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimBranch", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimBranchDetail", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimCaste", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimCity", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimConsortiumType", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimConstitution", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimCountry", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimCurrency", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimDefaultReason", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimDesignation", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimDocument", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimFarmerCat", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimGeography", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimGL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DIMGLPRODUCT", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimInsuranceComp", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimInttType", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimMaritalStatus", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimMaxLoginAllow", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimOccupation", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimParameter", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimPassportLocation", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimPincode", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DIMPRODUCT", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimQualification", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimReasonForWillfulDefault", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimRegion", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimRelationEntities", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimReligion", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimRepaymentMode", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimReportFrequency", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimReportParameter", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimSalutation", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimScheme", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimSecurity", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimSplCategory", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimState", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimSubSector", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimTypeServiceSummon", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimUserDeletionReason", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimUserDeptGroup", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimUserInfo", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimUserLocation", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimUserParameters", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimUserRole", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("dbo", "DimZone", "EffectiveFromTimeKey AND EffectiveToTimeKey")

        Return dt
    End Function


    ''data tables
    Public Function getdataTables() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("Schema")
        dt.Columns.Add("TableName")
        dt.Columns.Add("Filter")

        dt.Rows.Add("CURDAT", "CUSTOMERBASICDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVCUSTFINANCIALDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey BranchCode")
        dt.Rows.Add("CURDAT", "ADVCUSTNONFINANCIALDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey BranchCode")
        dt.Rows.Add("CURDAT", "ADVCUSTNPADETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVCUSTOTHERDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVACBASICDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey BranchCode")
        dt.Rows.Add("CURDAT", "ADVFACBILLDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVFACPCDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVFACCCDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVFACDLDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVACFINANCIALDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVACOTHERDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVACRESTRUCTUREDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVACBALANCEDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ACDAILYTXNDETAIL", "")
        dt.Rows.Add("CURDAT", "ADVCUSTCAL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVACCAL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVACRELATIONS", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVCUSTRELATIONSHIP", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVCUSTCOMMUNICATIONDETAIL", "")
        dt.Rows.Add("CURDAT", "ADVNFACBASICDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVFACNFDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVNFACFINANCIALDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVSECURITYVALUEDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("DBO", "ADVSECURITYCRMDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        dt.Rows.Add("CURDAT", "ADVSECURITYINSURANCEDETAIL", "EffectiveFromTimeKey AND EffectiveToTimeKey")
        Return dt
    End Function
End Class
