

--/*
--CREATED BY		:	AKASH
--CREATED DATE	:	20-04-2019
--MODIFIED BY     :   LIPSA ON 22-11-2019

--*/

--ALTER PROC [dbo].[Rpt-Legal-Plus-16B]
--	@UserName AS Varchar(20),
--	@AdminValue as varchar(Max),
--	@DynamicGrp AS VARCHAR(20),
--	@SubDynamicGrp AS VARCHAR(20),
--	@MisLocation AS VARCHAR(20),
--	@cost as float,
--	@Range INT, 
--	@DtEnter as varchar(20),
--	@From as varchar(20),
--	@to as varchar(20),
--	@Recordstatus AS int,
--	@Tier INT,
--	@Amount INT

--AS

DECLARE 
	@UserName AS Varchar(20)='legal',
	@AdminValue as varchar(Max)='0',
	@DynamicGrp AS VARCHAR(20)='bank',
	@SubDynamicGrp AS VARCHAR(20)='bank',
	@MisLocation AS VARCHAR(20)='',
	@cost as float=1,
    @Range INT=0, ------YEARS
    @DtEnter as varchar(20)='25/11/2019',
	@From as varchar(20)=null,
	@to as varchar(20)='25/11/2019',
	@Recordstatus AS int=0,
	@Tier INT =3,
	@Amount AS INT=9
	

IF @From=''
BEGIN
	SET @From=NULL
END
IF @to=''
BEGIN
	SET @to=NULL
END

SET NOCOUNT ON;

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
							SET @Code = (SELECT TOP(1)UserLocationCode FROM DimUserInfo WHERE UserLoginID = @UserName		AND EffectiveToTimeKey=49999) 
							End				
						ELSE IF @AuthenFlag = 'N'
							Begin
								SET @Department = 'RI'
								SET @Code       = '03'
							End
					End

DECLARE @DtEnter1 date ,@From1 date,@to1 date 

SET @DtEnter1=(SELECT Rdate FROM dbo.DateConvert(@DtEnter))
SET @From1=(SELECT * FROM dbo.DateConvert(@From))
SET @to1=(SELECT * FROM dbo.DateConvert(@to))
DECLARE @toTimekey as int =(select TimeKey from SysDayMatrix where SysDayMatrix.Date=CASE WHEN @to is null THEN @DtEnter1 ELSE @to1 END)

Declare @TimeKey as int=(select TimeKey from SysDayMatrix where date=@DtEnter1)
DECLARE  @CurrentDate DATETIME
SET @CurrentDate=@to1



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
	AND((@AdminValue = '0')
  	OR (
			CASE WHEN  @AdminValue <> '0'
				 THEN (CASE WHEN @Flag = 'N' OR @Department = 'HO' AND @AdminValue <> '0'
					        THEN (CASE WHEN @DynamicGrp = 'ZO' THEN CAST(QRYBRANCH.ZoneCode AS VARCHAR(10))
	   						           WHEN @DynamicGrp = 'RO' THEN CAST(QRYBRANCH.RegionCode AS VARCHAR(10))
	   							       WHEN @DynamicGrp = 'BO' THEN CAST(QRYBRANCH.BranchCode AS VARCHAR(10)) 
	   							       END)
	   						  END)
				 END )IN(SELECT * FROM dbo.Split(@AdminValue,','))          
OR
	      
	      ((
	         CASE WHEN @AdminValue <> '0'
	              THEN (CASE WHEN @Flag <> 'N' AND @Department <> 'HO' AND @AdminValue <> '0' 
				             THEN (CASE WHEN @DynamicGrp = 'ZO' THEN  CAST(QRYBRANCH.ZoneCode AS VARCHAR(10))
	   									WHEN @DynamicGrp = 'RO' THEN  CAST(QRYBRANCH.RegionCode AS VARCHAR(10))
	   									WHEN @DynamicGrp = 'BO' THEN  CAST(QRYBRANCH.BranchCode AS VARCHAR(10))
	   									
	   		    				   END) 
	       	            END)
	              END)IN(SELECT * FROM dbo.Split(@AdminValue,','))

	     AND ( CASE WHEN @AdminValue <> '0'
	                THEN (CASE WHEN @Department = 'ZO' THEN  CAST(QRYBRANCH.ZoneCode AS VARCHAR(10))
					           WHEN @Department = 'RO' THEN  CAST(QRYBRANCH.RegionCode AS VARCHAR(10))
					           WHEN @Department = 'BO' THEN   CAST(QRYBRANCH.BranchCode AS VARCHAR(10))
					      END)
					END ) = @Code) 
     
				)
--select * from #TempBranch


				CREATE UNIQUE CLUSTERED INDEX IX_BRANCHKEY ON #TempBranch(BranchCode)

				CREATE NONCLUSTERED INDEX IX_BranchCode ON #TempBranch(BranchCode)
									INCLUDE (
												 BranchName
												,BranchZone
												,BranchRegion
												
											)


---------------------DRT AND SUIT CASES
IF(OBJECT_ID('tempdb..#Cases') is not null)
DROP TABLE #Cases

SELECT	ACBD.BranchCode,
		PD.CustomerEntityId,
		PD.CaseEntityId,
		PD.PermissionNatureAlt_Key,
		AD.AcceptanceDate,
		AD.SuitAppNo,
		AD.SuitAmount

INTO	#Cases
FROM	LEGALVW.PermissionDetails PD

INNER JOIN LEGALVW.PlaintAdmissionDetails	AD	ON	PD.CaseEntityId=AD.CaseEntityId
													AND AD.EffectiveFromTimeKey<=@TimeKey
													AND AD.EffectiveToTimeKey>=@TimeKey
													AND AD.AcceptanceDate IS NOT NULL

INNER JOIN AdvAcBasicDetail ACBD				ON	ACBD.CustomerEntityID=PD.CustomerEntityID
													AND ACBD.EffectiveFromTimeKey<=@TimeKey
													AND ACBD.EffectiveToTimeKey>=@TimeKey

LEFT JOIN LEGALVW.WithdrawalDtls WD				ON	WD.CaseEntityId=PD.CaseEntityId
													AND WD.EffectiveFromTimeKey<=@TimeKey
													AND WD.EffectiveToTimeKey>=@TimeKey


WHERE	PD.EffectiveFromTimeKey<=@TimeKey AND
		PD.EffectiveToTimeKey>=@TimeKey AND 
		PD.PermissionNatureAlt_Key=105 AND 
		PD.CaseEntityId<>0 AND 
		((@Recordstatus=0) OR (@Recordstatus=1 AND WD.CaseEntityId IS NULL)) AND

		(	(CAST(AD.AcceptanceDate AS DATE) BETWEEN @From1 AND @to1 AND @From1 IS NOT NULL ) 
		OR	(@From1 IS NULL AND @to1 IS NOT NULL AND CAST(AD.AcceptanceDate  AS DATE) <=@to1 ) 
		OR	(@From1 IS NOT NULL AND @to1 IS  NULL AND CAST(AD.AcceptanceDate AS DATE) >=@From1 )
		) AND

		 
		(	(@Amount=0) OR
			(@Amount=1 and ISNULL(AD.SuitAmount,0)<=5000000) OR 
			(@Amount=2 and ISNULL(AD.SuitAmount,0) > 5000000 and ISNULL(AD.SuitAmount,0)<=10000000)OR
			(@Amount=3 and ISNULL(AD.SuitAmount,0) > 10000000 and ISNULL(AD.SuitAmount,0)<=50000000)OR
			(@Amount=4 and ISNULL(AD.SuitAmount,0) > 50000000 and ISNULL(AD.SuitAmount,0)<=100000000)OR
			(@Amount=5 and ISNULL(AD.SuitAmount,0) >100000000 and ISNULL(AD.SuitAmount,0)<=250000000)OR
			(@Amount=6 and ISNULL(AD.SuitAmount,0)> 250000000 and ISNULL(AD.SuitAmount,0)<= 500000000)OR
			(@Amount=7 and ISNULL(AD.SuitAmount,0)>500000000)OR
-----------added by lipsa on 22/11/2019 as per client's requirement and discussed with Kamthe sir---------
			(@Amount=8 and ISNULL(AD.SuitAmount,0)<10000000 )OR
			(@Amount=9 and ISNULL(AD.SuitAmount,0)>=10000000 )

		) AND


		(	(@Range=1 AND DATEDIFF(DD,AD.AcceptanceDate,@CurrentDate)<=365) OR
			(@Range=2 AND (DATEDIFF(DD,AD.AcceptanceDate,@CurrentDate)>365 AND DATEDIFF(DD,AD.AcceptanceDate,@CurrentDate)<=730 )) OR
			(@Range=3 AND (DATEDIFF(DD,AD.AcceptanceDate,@CurrentDate)>730 AND DATEDIFF(DD,AD.AcceptanceDate,@CurrentDate)<=1095 )) OR
			(@Range=4 AND (DATEDIFF(DD,AD.AcceptanceDate,@CurrentDate)>1095 AND DATEDIFF(DD,AD.AcceptanceDate,@CurrentDate)<=1825 )) OR
			(@Range=5 AND (DATEDIFF(DD,AD.AcceptanceDate,@CurrentDate)>1825 AND DATEDIFF(DD,AD.AcceptanceDate,@CurrentDate)<=3650 )) OR
			(@Range=6 AND DATEDIFF(DD,AD.AcceptanceDate,@CurrentDate)>3650) OR
			@Range=0
		)




GROUP BY	PD.CustomerEntityId,
			PD.CaseEntityId,
			PD.PermissionNatureAlt_Key,
			AD.AcceptanceDate,
			ACBD.BranchCode,
			AD.SuitAppNo,
			AD.SuitAmount

OPTION (RECOMPILE)


------==============================
IF (OBJECT_ID('tempdb..#Proceeding') IS NOT NULL)
					DROP TABLE #Proceeding

SELECT	C.CaseEntityId
		,NextHearingDt
		,JudgementDate
		,ROW_NUMBER()OVER(PARTITION BY C.CaseEntityId ORDER BY P.EntityKey DESC) RN

INTO	#Proceeding
FROM	#Cases C

INNER JOIN LEGALVW.SuitProceedingDtls P			ON	C.CaseEntityId=P.CaseEntityId
													AND P.EffectiveFromTimeKey<=@TimeKey
													AND P.EffectiveToTimeKey>=@TimeKey




SELECT 
          @DynamicGrp,  @SubDynamicGrp,                   
   CASE             
            
    ------======== FOR Summary Report           
	 WHEN  @DynamicGrp in ('BANK','ZO') and @SubDynamicGrp in ('RO','ZO','BO')
	 THEN TB.BranchZone

     WHEN  @DynamicGrp in ('RO') and @SubDynamicGrp in ('RO','BO')
	 THEN TB.BranchRegion

     END AS DynamicGrp,            
                             
                        
  CASE             
 
     ----=========================            
     ----======== FOR Summary Report            
      WHEN   @DynamicGrp in ('BANK','ZO') and @SubDynamicGrp in ('ZO')
	  THEN TB.BranchZone  

	  WHEN  @DynamicGrp in ('BANK','ZO') and @SubDynamicGrp in ('RO','BO')
	  THEN TB.BranchRegion
	
	  WHEN  @DynamicGrp in ('BANK','RO') and @SubDynamicGrp in ('BO')
	  THEN TB.BranchName

	  WHEN  @DynamicGrp in ('RO') and @SubDynamicGrp in ('RO')
	  THEN TB.BranchRegion

      END AS SubDynamicGrp

,TB.BranchZone				AS	ZoneName
,TB.BranchRegion			AS	RegionName
,TB.BranchName				AS	BranchName


,COUNT(CASE		WHEN	Proceeding.JudgementDate IS NULL OR JudgementDtls.PostJudStatusAlt_Key=42
				THEN	Cases.CaseEntityId
		END)												AS	PendingCases

,SUM(CASE		WHEN	Proceeding.JudgementDate IS NULL OR JudgementDtls.PostJudStatusAlt_Key=42
				THEN	ISNULL(Cases.SuitAmount,0)
				ELSE	0
		END)/@cost											AS	PendingAmt



,COUNT(CASE		WHEN	Proceeding.JudgementDate IS NOT NULL AND ISNULL(JudgementDtls.PostJudStatusAlt_Key,0)<>42
				THEN	Cases.CaseEntityId
		END)												AS	DecreeCases

,SUM(CASE		WHEN	Proceeding.JudgementDate IS NOT NULL AND ISNULL(JudgementDtls.PostJudStatusAlt_Key,0)<>42
				THEN	ISNULL(Cases.SuitAmount,0)
				ELSE	0
		END)/@cost											AS	DecreeAmt




FROM	#TempBranch TB 
		
INNER JOIN #Cases Cases						ON	Cases.BranchCode =TB.BranchCode


LEFT JOIN #Proceeding	Proceeding			ON	Proceeding.CaseEntityId=Cases.CaseEntityId
												AND Proceeding.RN=1

LEFT JOIN LEGALVW.JudgementDtls				ON	JudgementDtls.CaseEntityId=Cases.CaseEntityID
												AND JudgementDtls.EffectiveFromTimeKey<=@TimeKey
												AND JudgementDtls.EffectiveToTimeKey>=@TimeKey        

			  
GROUP BY
 TB.BranchZone 
,TB.BranchRegion 
,TB.BranchName

  

