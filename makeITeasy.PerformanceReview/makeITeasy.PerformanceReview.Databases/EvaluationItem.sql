CREATE TABLE [perfReview].[EvaluationItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EvaluationId] INT NOT NULL, 
    [FormItemId] INT NOT NULL, 
    [UserIdentityId] NVARCHAR(450) NOT NULL, 
    [Rating] INT NOT NULL, 
    [Comments] NVARCHAR(MAX) NULL, 
    [CreationDate] DATETIME2 NULL, 
    [LastModificationDate] DATETIME2 NULL, 
    CONSTRAINT [FK_PerformanceReviewEvaluationItem_ToPerformanceReviewEvalution] FOREIGN KEY ([EvaluationId]) REFERENCES [perfReview].[Evaluation]([Id]), 
    CONSTRAINT [FK_PerformanceReviewEvaluationItem_ToPerformanceReviewItem] FOREIGN KEY ([FormItemId]) REFERENCES [perfReview].[FormItem]([Id]), 
    CONSTRAINT [FK_EvaluationItem_ToTable] FOREIGN KEY ([UserIdentityId]) REFERENCES [perfReview].[AppUser]([Id])
)
