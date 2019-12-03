

----/*
----CREATED BY   :-  AKASH
----CREATED DATE :- 17-10-2018
----*/

--ALTER PROCEDURE [dbo].[Rpt-Legal-Plus-170]
--    @UserName AS Varchar(20),
--	@AdminValue as varchar(Max),
--	@DynamicGrp AS VARCHAR(20),
--	@SubDynamicGrp AS VARCHAR(20),
--	@MisLocation AS VARCHAR(20),
--	@cost as float,
--	@DtEnter as varchar(20),
--	@From as varchar(20),
--	@to as varchar(20),
--	@Recordstatus AS int
--	,@Tier INT 
--	,@Filter	INT
--AS


DECLARE
@UserName AS Varchar(20)='legal',
@AdminValue as varchar(Max)='0',
@DynamicGrp AS VARCHAR(20)='HO',
@SubDynamicGrp AS VARCHAR(20)='ZO',
@MisLocation AS VARCHAR(20)='',
@cost as float=1,
@DtEnter as varchar(20)='30/11/2019',--'08-071-2019',
@From as varchar(20)='',
@to as varchar(20)='30/11/2019',--'08-071-2019',
@Recordstatus AS int=0,
@Tier INT=3,
@Filter	INT=0
	   


IF @From=''
BEGIN
	SET @From=NULL
END
IF @to=''
BEGIN
	SET @to=NULL
END


DECLARE @DtEnter1 date ,@From1 date,@to1 date 

SET @DtEnter1=(SELECT Rdate FROM dbo.DateConvert(@DtEnter))
SET @From1=(SELECT * FROM dbo.DateConvert(@From))
SET @to1=(SELECT * FROM dbo.DateConvert(@to))

DECLARE @TimeKey as int=(select TimeKey from SysDayMatrix where SysDayMatrix.Date=@DtEnter1)
DECLARE @toTimekey as int =(select TimeKey from SysDayMatrix where SysDayMatrix.Date=CASE WHEN @to is null THEN @DtEnter1 ELSE @to1 END)
 

 DECLARE @Flag AS CHAR(5)
			DECLARE @Department AS VARCHAR(10)
			DECLARE @AuthenFlag AS CHAR(5)
			DECLARE @Code AS VARCHAR(10)

	
	
					SET @AuthenFlag = (SELECT dbo.AuthenticationFlag())
					SET @Flag = (SELECT dbo.ADflag())
					IF @Flag='Y' 
					Begin
						SET @Department = (LEFT(@MisLocation,2))
						SET @Code = (RIGHT(@MisLocation,3))
					End
					ELSE IF @Flag='SQL'
					Begin
						IF @AuthenFlag = 'Y'
							Begin
							SET @Department = (SELECT TOP(1)UserLocation FROM DimUserInfo WHERE UserLoginID = @UserName	AND EffectiveToTimeKey=49999)            
							SET @Code = (SELECT TOP(1)UserLocationCode FROM DimUserInfo WHERE UserLoginID = @UserName AND EffectiveToTimeKey=49999) 
							End				
						ELSE IF @AuthenFlag = 'N'
							Begin
								SET @Department = 'RI'
								SET @Code       = '03'
							End
					End
				
----------------===============================================================================================
IF (OBJECT_ID('tempdb..#TempBranch') IS NOT NULL)
DROP TABLE #TempBranch

    
				SELECT   
						QRYBRANCH.BranchCode                    AS BranchCode
						,QRYBRANCH.BranchName                    AS BranchName
						,QRYBRANCH.ZoneName                      AS BranchZone
						,QRYBRANCH.RegionName                    AS BranchRegion
						
				INTO #TempBranch 	
				FROM DBO.QRYBRANCH 
				WHERE (QRYBRANCH.EffectiveFromTimeKey <=@TimeKey AND QRYBRANCH.EffectiveToTimeKey>=@TimeKey)
				AND 
  				(
  						(@AdminValue = '0')
  
	OR   (
			CASE WHEN  @AdminValue <> '0'
				 THEN (CASE WHEN @Flag = 'N' OR @Department = 'HO' AND @AdminValue <> '0'
					        THEN (CASE WHEN @DynamicGrp = 'ZO' THEN CAST(QRYBRANCH.ZoneCode AS VARCHAR(20))
	   						           WHEN @DynamicGrp = 'RO' THEN CAST(QRYBRANCH.RegionCode AS VARCHAR(20)) 
	   							       WHEN @DynamicGrp = 'BO' THEN CAST(QRYBRANCH.BranchCode AS VARCHAR(20)) 
	   							       END)
	   						  END)
				 END )IN(SELECT * FROM dbo.Split(@AdminValue,','))          
OR
	      
	      ((
	         CASE WHEN @AdminValue <> '0'
	              THEN (CASE WHEN @Flag <> 'N' AND @Department <> 'HO' AND @AdminValue <> '0' 
				             THEN (CASE WHEN @DynamicGrp = 'ZO' THEN  CAST(QRYBRANCH.ZoneCode AS VARCHAR(20))
	   									WHEN @DynamicGrp = 'RO' THEN  CAST(QRYBRANCH.RegionCode AS VARCHAR(20)) 
	   									WHEN @DynamicGrp = 'BO' THEN  CAST(QRYBRANCH.BranchCode AS VARCHAR(20)) 
	   									
	   		    				   END) 
	       	            END)
	              END)IN(SELECT * FROM dbo.Split(@AdminValue,','))

	     AND ( CASE WHEN @AdminValue <> '0'
	                THEN (CASE WHEN @Department = 'ZO' THEN  CAST(QRYBRANCH.ZoneCode AS VARCHAR(20))
					           WHEN @Department = 'RO' THEN  CAST(QRYBRANCH.RegionCode AS VARCHAR(20))
					           WHEN @Department = 'BO' THEN  CAST(QRYBRANCH.BranchCode AS VARCHAR(20))
					      END)
					END ) = @Code) 
     
				)




				CREATE CLUSTERED INDEX IX_BRANCHKEY ON #TempBranch(BranchCode)

				CREATE NONCLUSTERED INDEX IX_BranchCode ON #TempBranch(BranchCode)
									INCLUDE (
												 BranchName
												,BranchZone
												,BranchRegion
												
											)

----CUSTOMERB_BRANCH WISE OS----(As discussed with Mr.Kamthe Balance should be taken from AdvAcBalanceDetail for UCO reports )

IF (OBJECT_ID('tempdb..#ACBAL') IS NOT NULL)
DROP TABLE #ACBAL
SELECT	TB.BranchCode,
		ACBD.CustomerEntityID,
		SUM(ACBAL.Balance)	Total

INTO	#ACBAL

FROM	#TempBranch TB

INNER JOIN AdvAcBasicDetail	ACBD		                ON	TB.BranchCode=ACBD.BranchCOde
														AND ACBD.EffectiveFromTimeKey <=@TimeKey
														AND ACBD.EffectiveToTimeKey>=@TimeKey
LEFT JOIN AdvAcBalanceDetail ACBAL		                ON ACBD.AccountEntityID=ACBAL.AccountEntityId
														AND ACBAL.EffectiveFromTimeKey <=@TimeKey 
														AND ACBAL.EffectiveToTimeKey>=@TimeKey
GROUP BY TB.BranchCode,ACBD.CustomerEntityID

OPTION (RECOMPILE)

----------------------IN case if we want to take bal from AdvAcOtherBalanceDetail (BOB Specific Concept)
--IF (OBJECT_ID('tempdb..#ACBAL') IS NOT NULL)
--DROP TABLE #ACBAL

--SELECT	TB.BranchCode,
--       ACBD.CustomerEntityId,
--       SUM(ISNULL(ACBAL.Total,0))					AS	Total,
--	   SUM(ISNULL(ACBD.CurrentLimit,0))			AS	CurrentLimit

--INTO	#ACBAL
--FROM #TempBranch TB INNER JOIN	AdvAcBasicDetail	ACBD ON TB.BranchCode=ACBD.BranchCOde
--                                                        AND ACBD.EffectiveFromTimeKey<=@TimeKey
--														AND ACBD.EffectiveToTimeKey>=@TimeKey

--INNER JOIN LEGALVW.AdvAcOtherBalanceDetail ACBAL	ON	ACBD.AccountEntityId=ACBAL.AccountEntityID
--														AND ACBAL.EffectiveFromTimeKey<=@TimeKey
--														AND ACBAL.EffectiveToTimeKey>=@TimeKey
														
--GROUP BY TB.BranchCode, ACBD.CustomerEntityId


--OPTION(RECOMPILE)


--------------------------------------
SELECT DISTINCT
              
    CASE             
            
    ------======== FOR list Report           
	 WHEN  @DynamicGrp in ('BANK','ZO') and @SubDynamicGrp in ('RO','ZO','BO')
	 THEN ltrim(rtrim(TB.BranchZone))

     WHEN  @DynamicGrp in ('RO') and @SubDynamicGrp in ('RO','BO')
	 THEN ltrim(rtrim(TB.BranchRegion))

															END AS DynamicGrp,                              
  CASE             

     ----======== FOR list Report            

	  WHEN  @DynamicGrp in ('BANK','ZO') and @SubDynamicGrp in ('RO')
	  THEN ltrim(rtrim(TB.BranchRegion))
	
	  WHEN  @DynamicGrp in ('BANK','ZO','RO') and @SubDynamicGrp in ('BO')
	  THEN ltrim(rtrim(TB.BranchRegion))

	  WHEN  @DynamicGrp in ('RO') and @SubDynamicGrp in ('RO')
	  THEN ltrim(rtrim(TB.BranchRegion )) 

	  --WHEN  @DynamicGrp in ('BO') and @SubDynamicGrp in ('BO')
	  --THEN ltrim(rtrim(TB.BranchName )) 

      END AS SubDynamicGrp

,LTRIM(RTRIM(TB.BranchZone))			AS	 ZoneName
,LTRIM(RTRIM(TB.BranchRegion))			AS	RegionName
,LTRIM(RTRIM(TB.BranchName))			AS	BranchName 
,CBD.CustomerId
,CBD.CustomerName
,CASE	WHEN	NPA.StaffAccountability='Y'
		THEN 	'Yes'
		ELSE	'No'
		END																AS	StaffAccExamined
,CASE	WHEN	CSA.PresentStatusRemark IS NOT NULL
		THEN	'Yes'
		ELSE	'No'
		END																AS	StaffLapses
,ISNULL(ACBAL.Total,0)/@cost			AS	Balance
,CASE	WHEN	CBD.CustType='BORROWER'
		THEN	'NPA BORROWER'
		ELSE	CBD.CustType
		END								AS	CustType
,ISNULL(CSA.ActionInitiated,'No')		AS	StaffActionInitiated


FROM #TempBranch TB

INNER JOIN	#ACBAL	ACBAL							ON	ACBAL.BranchCode=TB.BranchCode

INNER JOIN CustomerBasicDetail	CBD					ON	CBD.CustomerEntityId=ACBAL.CustomerEntityId
														AND CBD.EffectiveFromTimeKey<=@TimeKey
														AND CBD.EffectiveToTimeKey>=@TimeKey

INNER JOIN AdvCustNPAdetail NPA						ON	NPA.CustomerEntityId=CBD.CustomerEntityId
														AND NPA.EffectiveFromTimeKey<=@TimeKey
														AND NPA.EffectiveToTimeKey>=@TimeKey

LEFT JOIN WARCustomer	WAR							ON	WAR.CustomerEntityId=CBD.CustomerEntityId
														AND	WAR.Branchcode=ACBAL.BranchCode



LEFT JOIN LEGAL.CustomerStaffAcctDtls CSA					ON	CSA.CustomerEntityID=CBD.CustomerEntityId
																AND CSA.EffectiveFromTimeKey<=@TimeKey 
																AND CSA.EffectiveToTimeKey>=@TimeKey

  
WHERE 

(
	(CAST	(NPA.NPADt AS DATE) BETWEEN CAST(@From1 AS DATE) AND CAST(@to1 AS DATE) AND @From1 IS NOT NULL ) OR
			(@From1 IS NULL AND @to1 IS NOT NULL AND CAST(ISNULL(NPA.NPADt,'1900-01-01') AS DATE) <=CAST(@to1 AS DATE)) OR
			(@From1 IS NOT NULL AND @to1 IS  NULL AND CAST(NPA.NPADt AS DATE) >=CAST(@From1 AS DATE))
)
		
AND (	(@Filter=0) OR
		(@Filter=1 AND WAR.CustomerEntityId IS NOT NULL) OR
		(@Filter=2 AND CBD.CustType='BORROWER') OR
		(@Filter=3 AND CBD.CustType='OTHERS') OR
		(@Filter=4 AND CBD.CustType='TWO') OR
		(@Filter=5 AND CBD.CustType='WRITTENOFF')
	)

