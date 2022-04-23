CREATE TABLE [dbo].[PerformanceReviewEvalutation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PerformanceReviewId] INT NOT NULL, 
    [EmployeeId] INT NULL, 
    [UserId] INT NULL, 
    CONSTRAINT [FK_PerformanceReviewEvalutation_ToEmployee] FOREIGN KEY ([EmployeeId]) REFERENCES [Employee]([Id]), 
    CONSTRAINT [FK_PerformanceReviewEvalutation_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]) 
)
