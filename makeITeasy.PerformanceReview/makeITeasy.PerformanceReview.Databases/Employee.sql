CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL  IDENTITY, 
    [UserIdentityId] NVARCHAR(450) NOT NULL,
    [ManagerIdentityId] NVARCHAR(450) NOT NULL, 
    PRIMARY KEY ([UserIdentityId]), 
    CONSTRAINT [FK_Employee_ToTable] FOREIGN KEY ([UserIdentityId]) REFERENCES [AppUser]([Id]), 
    CONSTRAINT [FK_Employee_ToTable_1] FOREIGN KEY ([ManagerIdentityId]) REFERENCES [AppUser]([Id])
)
