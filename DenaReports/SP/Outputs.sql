
use DENAMISDBOCT2017

exec [Rpt-SysDates]
exec [Rpt-SysAD] @UserName=N'dm400'

exec [Rpt-SysDynamicGrp]
	@UserName=N'D2K'
	,@UserLoginID=N'D2K'
	,@UserLocation=N'D2K'
	,@UserLocationCode=N'D2K'
	,@MisLocation=NULL


declare @ReportName AS VARCHAR(MAX)='Rpt-10536-Progress Under Dena Niwas Housing Loan Scheme'
declare @reptitle AS VARCHAR(MAX)=RIGHT(@reportname,charindex('-',reverse(@reportname))-1)  
select @reptitle
SELECT *  FROM SysReportDirectory where reportrdlname=@reptitle
SELECT *  FROM SysReportDirectory where reportID='Rpt-10536'


exec [Rpt-SysReportVersion] 
@ReportName='Rpt-10536-Progress Under Dena Niwas Housing Loan Scheme'
,@TimeKey=4655

SELECT *  FROM SysReportDirectory where reportID='Rpt-10536' order by seqno desc
