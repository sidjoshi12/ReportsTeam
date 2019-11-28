


declare @AdminValue as nvarchar(500)
set @AdminValue='0002,0003,0004,0005,0006,0007,0009,0010'
SELECT * FROM dbo.Split(@AdminValue,',')

