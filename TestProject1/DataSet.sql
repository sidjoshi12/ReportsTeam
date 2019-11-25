

create proc DataSetTest as
select RegionCode,RegionName from mstRegion
select BranchCode,BranchName from mstBranch


exec DataSetTest