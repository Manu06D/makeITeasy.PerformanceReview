CREATE TABLE [perfReview].[Form]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    --[UserId] INT NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    --CONSTRAINT [FK_PerformanceReview_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
)
