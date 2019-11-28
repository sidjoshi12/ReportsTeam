



--ALTER PROCEDURE [dbo].[Rpt-SysAdminValue_Grp]

--@DtEnter AS VARCHAR(10)--='26-04-2017'
--,@UserName AS Varchar(20)--='LEGAL'
--,@UserLoginID AS Varchar(20)--='D2K'
--,@UserLocation AS VARCHAR(10)--='D2K'
--,@UserLocationCode AS NVARCHAR(10)--='D2K'
--,@MisLocation AS VARCHAR(20)--=''
--,@DynamicGrp AS VARCHAR(20)--='BANK'
--AS


Declare
@DtEnter AS VARCHAR(10)='27/11/2019'
,@UserName AS Varchar(20)='LEGAL'
,@UserLoginID AS Varchar(20)='LEGAL'
,@UserLocation AS VARCHAR(10)--=''
,@UserLocationCode AS NVARCHAR(10)--=''
,@MisLocation AS VARCHAR(20)--=''
,@DynamicGrp AS VARCHAR(20)='BO'


DECLARE @DtEnter1 date ,@From1 date,@to1 date 

SET @DtEnter1=(SELECT Rdate FROM dbo.DateConvert(@DtEnter))


DECLARE @TimeKey as Varchar(20)=(select TimeKey from SysDayMatrix where SysDayMatrix.Date=@DtEnter1)
DECLARE @Flag AS CHAR(5)

DECLARE @Department AS VARCHAR(10)

DECLARE @Code AS VARCHAR(10)

DECLARE @Tier AS INT

DECLARE @AuthenFlag AS CHAR(5)

DECLARE @STR AS VARCHAR(MAX)

DECLARE @STRCode AS VARCHAR(MAX)

DECLARE @ExeSTR AS VARCHAR(MAX)

DECLARE @S AS CHAR(1)=''''

SET @Tier =(SELECT Tier FROM Dbo.SysReportformat where Active='Y')

SET @Flag =(SELECT dbo.ADflag())

SET @AuthenFlag =(SELECT dbo.AuthenticationFlag())

--------------------------------------------------------

--------------------------------------------------------

IF @Flag='Y'

BEGIN

SET @Department = (LEFT(@MisLocation,2))

SET @Code = (RIGHT(@MisLocation,3))

END

ELSE IF @Flag='SQL'

BEGIN

IF @AuthenFlag = 'Y'

BEGIN

SET @Department = (SELECT TOP(1)UserLocation FROM DimUserInfo WHERE UserLoginID = @UserName AND EffectiveToTimeKey=49999)

SET @Code = (SELECT TOP(1)UserLocationCode FROM DimUserInfo WHERE UserLoginID = @UserName AND EffectiveToTimeKey=49999)

END

ELSE IF @AuthenFlag = 'N'

BEGIN

SET @Department = 'RO'

SET @Code = '07'

END

END

SET
@STR = ' CASE WHEN ' +@S+ @DynamicGrp +@S+'= ''ZO'' THEN QRYBRANCH.ZoneName

WHEN '
+@S+ @DynamicGrp +@S+'= ''RO'' THEN QRYBRANCH.RegionName

WHEN '
+@S+ @DynamicGrp +@S+'= ''BO'' THEN QRYBRANCH.BranchName

ELSE ''''

END' 



------ modify by anil convert(varchar(10),StateAlt_Key)  previous --- only  StateAlt_Key

SET
@STRCode = ' CASE WHEN ' +@S+ @DynamicGrp +@S+'= ''ZO'' THEN CAST(QRYBRANCH.ZoneCode AS VARCHAR(20))

WHEN '
+@S+ @DynamicGrp +@S+'= ''RO'' THEN CAST(QRYBRANCH.RegionCode AS VARCHAR(20))

WHEN '
+@S+ @DynamicGrp +@S+'= ''BO'' THEN CAST(QRYBRANCH.BranchCode AS VARCHAR(20))

ELSE ''''

END '

IF
((@Flag= 'Y' OR @Flag= 'SQL') AND @Department <> 'HO')

BEGIN


IF (@Department = 'ZO' AND @Tier IN (4))

BEGIN
PRINT 1
	SET @ExeSTR='SELECT DISTINCT ' + @STR + ' AS AdminValueLable, ' + @STRCode + ' AS AdminValue

	FROM QRYBRANCH
	WHERE (QRYBRANCH.EffectiveFromTimekey<= '
	+ @TimeKey + ' AND QRYBRANCH.EffectiveToTimekey>= ' + @TimeKey + ' )

	AND QRYBRANCH.ZoneCode IN ('''
	+ @Code + ''')

	ORDER BY AdminValue'

	EXEC (@ExeSTR)

END

----------------------------------------------------------------------

IF (@Department='RO' AND @Tier IN (4,3))

BEGIN
PRINT 2
SET @ExeSTR='SELECT DISTINCT ' + @STR + ' AS AdminValueLable, ' + @STRCode + ' AS AdminValue
FROM QRYBRANCH
WHERE (QRYBRANCH.Effectivefromtimekey<= '
+ @TimeKey + ' AND QRYBRANCH.Effectivetotimekey>= ' + @TimeKey + ' )

AND QRYBRANCH.RegionCode IN ('''
+ @Code + ''')

ORDER BY AdminValue'

EXEC (@ExeSTR)
--print 2
--print @ExeSTR
END

IF (@Department='BO')

BEGIN
PRINT 3
SET @ExeSTR='SELECT DISTINCT '+@STRCode +'+''-''+' +@STR + ' AS AdminValueLable, ' + @STRCode + ' AS AdminValue

FROM QRYBRANCH
WHERE (QRYBRANCH.Effectivefromtimekey<= '
+ @TimeKey + ' AND QRYBRANCH.Effectivetotimekey>= ' + @TimeKey + ')

AND QRYBRANCH.BranchCode IN ('''
+ @Code + ''')

ORDER BY AdminValue '

EXEC (@ExeSTR)

END

END



---------========== For UnAuthorised Users - 08/03/2010

ELSE
IF (@Flag= 'SQL' AND (@Department IS NULL) AND @AuthenFlag = 'Y' )

SELECT
'USER ' + @UserName + ' IS NOT AUTHORISED..' as AdminValue,'' AS AdminValueLable

---------========== For UnAuthorised Users - 08/03/2010

--------------------------------------------------------------------------------

ELSE
IF (@Flag= 'N' OR ((@Flag= 'Y' OR @Flag= 'SQL') AND @Department ='HO'))

BEGIN

IF(@DynamicGrp = 'BANK')

SELECT

 '<All>' AS AdminValueLable
 ,'0' AS AdminValue


ELSE  IF(@DynamicGrp = 'BO')  
  begin


SET @ExeSTR='SELECT DISTINCT  '+@STRCode +'+''-''+' +@STR + ' AS AdminValueLable, ' + @STRCode + ' AS AdminValue  
  
FROM QRYBRANCH    
WHERE (QRYBRANCH.Effectivefromtimekey<= '  
+ @TimeKey + ' AND QRYBRANCH.Effectivetotimekey>= ' + @TimeKey + ') 

UNION ALL

SELECT

 ''<All>'' AS AdminValueLable
 ,''0'' AS AdminValue
 
 ORDER BY AdminValue'  
  
EXEC(@ExeSTR)  
  --print 4
  --print @ExeSTR
END

ELSE 
PRINT 10
SET @ExeSTR='SELECT DISTINCT  '/*+@STRCode +'+''-''+'*/+@STR + ' AS AdminValueLable, ' + @STRCode + ' AS AdminValue  
  
FROM QRYBRANCH  
WHERE (QRYBRANCH.Effectivefromtimekey<= '  
+ @TimeKey + ' AND QRYBRANCH.Effectivetotimekey>= ' + @TimeKey + ')  

--ORDER BY AdminValue
UNION ALL

SELECT

 ''<All>'' AS AdminValueLable
 ,''0'' AS AdminValue
 
 ORDER BY AdminValue
 '  

EXEC(@ExeSTR)  

END



