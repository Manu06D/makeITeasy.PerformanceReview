CREATE TABLE [dbo].[EvaluationItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EvaluationId] INT NOT NULL, 
    [FormItemId] INT NOT NULL, 
    [UserIdentityId] NVARCHAR(450) NOT NULL, 
    [Rating] INT NOT NULL, 
    [CreationDate] DATETIME2 NULL, 
    [LastModificationDate] DATETIME2 NULL, 
    CONSTRAINT [FK_PerformanceReviewEvaluationItem_ToPerformanceReviewEvalution] FOREIGN KEY ([EvaluationId]) REFERENCES [Evaluation]([Id]), 
    CONSTRAINT [FK_PerformanceReviewEvaluationItem_ToPerformanceReviewItem] FOREIGN KEY ([FormItemId]) REFERENCES [FormItem]([Id])
)
