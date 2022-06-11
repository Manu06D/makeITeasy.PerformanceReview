CREATE TABLE [perfReview].[Evaluation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FormId] INT NOT NULL, 
    [UserIdentityId] NVARCHAR(450) NULL, 
    [ManagerIdentityId] NVARCHAR(450) NULL, 
    [State] INT NULL DEFAULT 0, 
    [CreationDate] DATETIME2 NULL, 
    [LastModificationDate] DATETIME2 NULL, 
    CONSTRAINT [FK_Evaluation_ToForm] FOREIGN KEY ([FormId]) REFERENCES [perfReview].[Form]([Id]) ,
    CONSTRAINT [FK_Evaluation_ToEmployee] FOREIGN KEY ([UserIdentityId]) REFERENCES [perfReview].[AppUser]([Id]), 
    CONSTRAINT [FK_Evaluation_ToTable] FOREIGN KEY ([ManagerIdentityId]) REFERENCES [perfReview].[AppUser]([Id])
)
