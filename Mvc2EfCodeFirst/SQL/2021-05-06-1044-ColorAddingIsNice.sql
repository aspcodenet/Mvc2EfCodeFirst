IF NOT EXISTS (
  SELECT * 
  FROM   sys.columns 
  WHERE  object_id = OBJECT_ID(N'[dbo].[Colors]') 
         AND name = 'IsNice'
)
BEGIN
	alter table Colors 
	add IsNice bit not null default(0)
END
