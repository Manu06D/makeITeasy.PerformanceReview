CREATE TABLE [dbo].[Evaluation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FormId] INT NOT NULL, 
    [UserIdentityId] NVARCHAR(450) NULL, 
    [ManagerIdentityId] NVARCHAR(450) NULL, 
    [CreationDate] DATETIME2 NULL, 
    [LastModificationDate] DATETIME2 NULL, 
    CONSTRAINT [FK_Evaluation_ToForm] FOREIGN KEY ([FormId]) REFERENCES [Form]([Id]) ,
    CONSTRAINT [FK_Evaluation_ToEmployee] FOREIGN KEY ([UserIdentityId]) REFERENCES [Employee]([UserIdentityId])
)
