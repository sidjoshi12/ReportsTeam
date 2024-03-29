
use DENAMISDBOCT2017
go
/*
--============================================================================================
-Created By    :- Shubham Jain
-Creation Date :- 06/05/2010
-Modified Date :- MNS
-Modified Date :-21/06/2013
-Description   :- This Sp is Used to Fecth Value for Parameter Select Admin Group (DynamicGrp)
--============================================================================================
*/

ALTER Proc [dbo].[Rpt-SysDynamicGrp]

	
	@UserName AS Varchar(20),
	@UserLoginID AS Varchar(20),
	@UserLocation AS VARCHAR(10),
	@UserLocationCode AS NVARCHAR(10),
	@MisLocation AS VARCHAR(20) 

AS

	DECLARE @Flag AS CHAR(5)
	DECLARE @Department AS VARCHAR(10)
	DECLARE @Code AS INT
	DECLARE @AuthenFlag AS CHAR(5)
	DECLARE @Tier AS INT

	SET @Tier = (SELECT Tier FROM SysReportformat) 
	SET @Flag = (SELECT dbo.ADflag())
    SET @AuthenFlag = (SELECT dbo.AuthenticationFlag())
 
 	IF @Flag='Y' 
	BEGIN
			SET @Department = (LEFT(@MisLocation,2))
			SET @Code = (RIGHT(@MisLocation,3))
	END

	ELSE IF @Flag='SQL'
	BEGIN
			IF @AuthenFlag = 'Y'
				BEGIN
					SET @Department = (SELECT TOP(1)UserLocation FROM DimUserInfo WHERE UserLoginID = @UserName	AND EffectiveToTimeKey>=9999)
					SET @Code = (SELECT TOP(1)UserLocationCode FROM DimUserInfo WHERE UserLoginID = @UserName	AND EffectiveToTimeKey>=9999)
				END
				
			ELSE IF @AuthenFlag = 'N'
			    BEGIN
					SET @Department = 'RO'
					SET @Code       = '07'
			    END
	END	
 
------------------------------------------------------------------------------------- 
IF (@Flag= 'N' OR ((@Flag= 'Y' OR @Flag= 'SQL') AND @Department ='HO'))    
BEGIN 
	IF (@Tier = 4)
	BEGIN
	SELECT DynamicGroup_Key,DynamicGroupName,DynamicGroupValue,DynamicGroupLabel 
	FROM SysDynamicGroup   WHERE DynamicGroupType='MainGroup'
	END
	
	IF (@Tier = 3)
	BEGIN
	SELECT DynamicGroup_Key,DynamicGroupName,DynamicGroupValue,DynamicGroupLabel 
	FROM Dbo.SysDynamicGroup WHERE DynamicGroupType='MainGroup' AND DynamicGroupAlt_Key NOT IN (20) 
	END
	
	IF (@Tier = 2)
	BEGIN
	SELECT DynamicGroup_Key,DynamicGroupName,DynamicGroupValue,DynamicGroupLabel 
	FROM SysDynamicGroup WHERE DynamicGroupType='MainGroup' AND DynamicGroupAlt_Key NOT IN (20,30) 
	END
	
END
-------------------------------------------------------------------------------------
------------------------------------------------------------------------------------- 
IF (@Flag= 'N' OR ((@Flag= 'Y' OR @Flag= 'SQL') AND @Department ='ZO') AND @Tier IN (4))    
 
SELECT DynamicGroup_Key,DynamicGroupName,DynamicGroupValue,DynamicGroupLabel 
FROM SysDynamicGroup WHERE DynamicGroupAlt_Key NOT IN (10) AND DynamicGroupType='MainGroup'
-------------------------------------------------------------------------------------
------------------------------------------------------------------------------------- 
IF (@Flag= 'N' OR ((@Flag= 'Y' OR @Flag= 'SQL') AND @Department ='RO') AND @Tier  IN (4,3))    
 
SELECT DynamicGroup_Key,DynamicGroupName,DynamicGroupValue,DynamicGroupLabel 
FROM SysDynamicGroup WHERE DynamicGroupAlt_Key NOT IN (10,20) AND DynamicGroupType='MainGroup'
-------------------------------------------------------------------------------------
------------------------------------------------------------------------------------- 
IF ((@Flag= 'Y' OR @Flag= 'SQL') AND @Department ='BO' AND @Tier  IN (4,3,2))    
SELECT DynamicGroup_Key,DynamicGroupName,DynamicGroupValue,DynamicGroupLabel 
FROM SysDynamicGroup WHERE DynamicGroupAlt_Key NOT IN (10,20,30) AND DynamicGroupType='MainGroup'
-------------------------------------------------------------------------------------


