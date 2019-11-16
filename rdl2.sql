


select 
Advacdetail.BranchCode
,QryBranch.BranchName
,Advacdetail.CustomerID
,CustomerID.CustomerName
,Advacdetail.Acid
,Advacdetail.FacilityExposure
,Advacdetail.LimitSanctioned
,AdvAcDetail.FacilitiesStatus
,Advacdetail.FormatGroup
,AdvacDetail.Activity
,mstActivity.Description as ActivityDesc
from Advacdetail 
inner join QryBranch
on QryBranch.RegionCode=AdvAcDetail.RegionCode
and QryBranch.BranchCode=AdvAcDetail.BranchCode
inner join CustomerID
on Advacdetail.BranchCode=CustomerID.BranchCode
and Advacdetail.CustomerID=CustomerID.CustomerID
inner join mstActivity on mstActivity.code=AdvAcDetail.Activity
where Advacdetail.delsta is null and FormatGroup<>'N'
and Advacdetail.FacilityExposure>0
and AdvacDetail.BranchCode=@BranchCode
order by AdvacDetail.BranchCode,AdvAcDetail.CustomerID,AdvAcDetail.AcID