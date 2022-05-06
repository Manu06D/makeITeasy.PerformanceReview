CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL  IDENTITY, 
    [UserIdentityId] NVARCHAR(450) NOT NULL,
    [Name] VARCHAR(50) NOT NULL, 
    [ManagerIdentityId] NVARCHAR(450) NOT NULL, 
    PRIMARY KEY ([UserIdentityId])
)
