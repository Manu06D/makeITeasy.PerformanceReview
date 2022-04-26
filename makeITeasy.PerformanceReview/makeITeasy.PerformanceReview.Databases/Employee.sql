CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [ManagerId] NVARCHAR(450) NULL, 
    [UserIdentityId] NVARCHAR(450) NULL
)
