
--==========================================================================
--Created by :-
--Created Date:-
--Modified By:- MNS
--Modified Date:- 19-06-2012
--SP Disc:- Used to Fecth Dates in Report Parameter (Select Month)

--==========================================================================
ALTER Procedure [dbo].[Rpt-SysDates]
AS
BEGIN
SELECT
		TimeKey AS DateKey,
		CONVERT(VARCHAR(10),DataEffectiveToDate,103) AS 'DateCaption' 
		
FROM Dbo.SysDataMatrix  SYDM

WHERE 
		SYDM.DataEffectiveFromTimeKey IS NOT NULL 
		AND SYDM.CurrentStatus IN('U','C')
		
ORDER BY SYDM.DataEffectiveToDate DESC 

END



