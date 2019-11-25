

use DENAMISDBOCT2017
--dsAdminValue
go
alter Proc [dbo].[Rpt-SysAdminValue_Grp_20Nov19]
	@TimeKey as int,
	@UserName AS Varchar(20),
	@UserLoginID AS Varchar(20),
	@UserLocation AS VARCHAR(10),
	@UserLocationCode AS NVARCHAR(10),
	@MisLocation AS VARCHAR(20),
	@DynamicGrp AS VARCHAR(20)
AS

DECLARE @Flag AS CHAR(5)
DECLARE @Department AS VARCHAR(10)
DECLARE @Code AS VARCHAR(10)
DECLARE @Tier AS INT
DECLARE @AuthenFlag AS CHAR(5)
DECLARE @STR AS VARCHAR(MAX)
DECLARE @STRCode AS VARCHAR(MAX)
DECLARE @ExeSTR AS VARCHAR(MAX)
DECLARE @S AS CHAR(1)=''''

SET @Tier = (SELECT Tier FROM Dbo.SysReportformat)
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

SET @Department = (SELECT TOP(1)UserLocation FROM DimUserInfo WHERE UserLoginID = @UserName AND EffectiveToTimeKey=9999)

SET @Code = (SELECT TOP(1)UserLocationCode FROM DimUserInfo WHERE UserLoginID = @UserName AND EffectiveToTimeKey=9999)

END

ELSE IF @AuthenFlag = 'N'

BEGIN

SET @Department = 'RO'

SET @Code = '07'

END

END

SET
@STR = ' CASE WHEN ' +@S+ @DynamicGrp +@S+'= ''ZO'' THEN DimBranch.BranchZone

WHEN '
+@S+ @DynamicGrp +@S+'= ''RO'' THEN DimBranch.BranchRegion

WHEN '
+@S+ @DynamicGrp +@S+'= ''BO'' THEN DimBranch.BranchName

WHEN '
+@S+ @DynamicGrp +@S+'= ''ST'' THEN DimBranch.BranchStateName

WHEN '
+@S+ @DynamicGrp +@S+'= ''DS'' THEN DimBranch.BranchDistrictName

ELSE ''''

END '

------ modif by anil convert(varchar(10),StateAlt_Key)  previous --- only  StateAlt_Key

SET
@STRCode = ' CASE WHEN ' +@S+ @DynamicGrp +@S+'= ''ZO'' THEN Convert(Varchar(10),DimBranch.BranchZoneAlt_Key)

WHEN '
+@S+ @DynamicGrp +@S+'= ''RO'' THEN Convert(Varchar(10),DimBranch.BranchRegionAlt_Key)

WHEN '
+@S+ @DynamicGrp +@S+'= ''BO'' THEN Convert(Varchar(10),DimBranch.BranchCode)

WHEN '
+@S+ @DynamicGrp +@S+'= ''ST'' THEN Convert(Varchar(10),DimBranch.BranchStateAlt_Key)

WHEN '
+@S+ @DynamicGrp +@S+'= ''DS'' THEN  Convert(Varchar(10),DimBranch.BranchDistrictAlt_Key)

ELSE ''''

END '

IF
((@Flag= 'Y' OR @Flag= 'SQL') AND @Department <> 'HO')

BEGIN

IF (@DynamicGrp NOT IN ('ST' , 'DS'))

BEGIN

IF (@Department = 'ZO' AND @Tier IN (4))

BEGIN

SET @ExeSTR='SELECT DISTINCT ' + @STR + ' AS AdminValueLable, ' + @STRCode + ' AS AdminValue

FROM DimBranch
WHERE (DimBranch.EffectiveFromTimekey<= '
+ cast(@TimeKey as varchar) + ' AND DimBranch.EffectiveToTimekey>= ' + cast(@TimeKey as varchar) + ' )

AND DimBranch.BranchZoneAlt_Key IN ('
+ @Code + ')

ORDER BY AdminValueLable'

EXEC (@ExeSTR)

END

----------------------------------------------------------------------

IF (@Department='RO' AND @Tier IN (4,3))

BEGIN

SET @ExeSTR='SELECT DISTINCT ' + @STR + ' AS AdminValueLable, ' + @STRCode + ' AS AdminValue
FROM DimBranch
WHERE (DimBranch.Effectivefromtimekey<= '
+ cast(@TimeKey as varchar) + ' AND DimBranch.Effectivetotimekey>= ' + cast(@TimeKey as varchar) + ' )

AND DimBranch.BranchRegionAlt_Key IN ('
+ @Code + ')

ORDER BY AdminValueLable'

EXEC (@ExeSTR)

END

IF (@Department='BO')

BEGIN

SET @ExeSTR='SELECT DISTINCT '+@STRCode +'+''-''+' +@STR + ' AS AdminValueLable, ' + @STRCode + ' AS AdminValue

FROM DimBranch
WHERE (DimBranch.Effectivefromtimekey<= '
+ cast(@TimeKey as varchar) + ' AND DimBranch.Effectivetotimekey>= ' + cast(@TimeKey as varchar) + ')

AND DimBranch.BranchCode IN ('
+ @Code + ')

ORDER BY AdminValue '

EXEC (@ExeSTR)

END

END

ELSE IF (@DynamicGrp IN ('ST' , 'DS'))

BEGIN
Print 1
SET @ExeSTR='SELECT DISTINCT ' + @STR + ' AS AdminValueLable, ' + @STRCode + ' AS AdminValue

FROM DimBranch
WHERE (DimBranch.Effectivefromtimekey<= '
+ cast(@TimeKey as varchar) + ' AND DimBranch.Effectivetotimekey>= ' + cast(@TimeKey as varchar) + ')
AND DimBranch.BranchStateAlt_Key<>0
ORDER BY AdminValueLable '

EXEC(@ExeSTR)

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
 ,'<All>' AS AdminValue


ELSE  IF(@DynamicGrp = 'BO')  
  begin


SET @ExeSTR='SELECT DISTINCT  '+@STRCode +'+''-''+' +@STR + ' AS AdminValueLable, ' + @STRCode + ' AS AdminValue  
  
FROM DimBranch    
WHERE (DimBranch.Effectivefromtimekey<= '  
+ cast(@TimeKey as varchar) + ' AND DimBranch.Effectivetotimekey>= ' + cast(@TimeKey as varchar) + ')  
 and branchcode<>0000 

ORDER BY AdminValue '  
  
EXEC(@ExeSTR)  
  
END

ELSE 

SET @ExeSTR='SELECT DISTINCT  '/*+@STRCode +'+''-''+'*/+@STR + ' AS AdminValueLable, ' + @STRCode + ' AS AdminValue  
  
FROM DimBranch  
WHERE (DimBranch.Effectivefromtimekey<= '  
+ cast(@TimeKey as varchar) + ' AND DimBranch.Effectivetotimekey>= ' + cast(@TimeKey as varchar) + ')  
AND DimBranch.BranchStateAlt_Key<>0  
ORDER BY AdminValueLable '  
  
EXEC(@ExeSTR)  
  
END



