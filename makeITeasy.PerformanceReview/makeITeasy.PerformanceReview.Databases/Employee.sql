CREATE TABLE [perfReview].[Employee]
(
	[Id] INT NOT NULL  IDENTITY, 
    [UserIdentityId] NVARCHAR(450) NOT NULL,
    [ManagerIdentityId] NVARCHAR(450) NOT NULL, 
    [HiredOnDate] DATETIME2 NULL, 
    [Comments] NVARCHAR(MAX) NULL, 
    [SecretComments] NVARCHAR(MAX) NULL, 
    PRIMARY KEY ([UserIdentityId]), 
    CONSTRAINT [FK_Employee_ToTable] FOREIGN KEY ([UserIdentityId]) REFERENCES [perfReview].[AppUser]([Id]), 
    CONSTRAINT [FK_Employee_ToTable_1] FOREIGN KEY ([ManagerIdentityId]) REFERENCES [perfReview].[AppUser]([Id])
)
