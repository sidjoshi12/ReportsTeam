
use BOBMISDB_June2016

--select max(EffectiveToTimeKey) from advacbasicDetail where EffectiveToTimeKey<9999
--select * from sysdaymatrix where timekey=4655

--use DENAMISDBOCT2017

declare @TimeKey int--=4655
set @TimeKey=(select TimeKey from sysdaymatrix where date='29/sep/2017')
declare @branchcode as int=948

select 
	AdvAcBasicDetail.BranchCode
	,AdvAcBasicDetail.CustomerEntityId
	,AdvAcBasicDetail.AccountEntityId
	,CustomerBasicDetail.CustomerName
	,AdvAcBasicDetail.AccountName
	,AdvAcBasicDetail.OriginalLimit
	,AdvAcBalanceDetail.Balance
	,AdvAcBasicDetail.ActivityAlt_Key
	,DimActivity.ActivityName
from AdvAcBasicDetail
inner join CustomerBasicDetail
on CustomerBasicDetail.CustomerEntityId=AdvAcBasicDetail.CustomerEntityId
and CustomerBasicDetail.EffectiveFromTimeKey<=@TimeKey and CustomerBasicDetail.EffectiveToTimeKey>=@TimeKey
inner join AdvAcBalanceDetail
on AdvAcBalanceDetail.AccountEntityId=AdvAcBasicDetail.AccountEntityId
and AdvAcBalanceDetail.EffectiveFromTimeKey<=@TimeKey and AdvAcBalanceDetail.EffectiveToTimeKey>=@TimeKey
inner join DimActivity
on DimActivity.ActivityAlt_Key=AdvAcBasicDetail.ActivityAlt_Key
where AdvAcBasicDetail.EffectiveFromTimeKey<=@TimeKey
and AdvAcBasicDetail.EffectiveToTimeKey>=@TimeKey and adjdt is  null
and AdvAcBasicDetail.BranchCode=@BranchCode
--and AccountEntityId=7
 





