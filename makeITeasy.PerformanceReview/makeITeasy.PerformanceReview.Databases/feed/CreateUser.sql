INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
     VALUES
           (NEWID()
           ,'Admin'
           ,'ADMIN'
           ,NEWID())