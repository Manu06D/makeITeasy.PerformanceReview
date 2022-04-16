CREATE TABLE [dbo].[PerformanceReviewEvaluationItem]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PerformanceReviewEvalutionId] INT NOT NULL, 
    [PerformanceReviewItemId] INT NOT NULL, 
    CONSTRAINT [FK_PerformanceReviewEvaluationItem_ToPerformanceReviewEvalution] FOREIGN KEY ([PerformanceReviewEvalutionId]) REFERENCES [PerformanceReviewEvalutation]([Id]), 
    CONSTRAINT [FK_PerformanceReviewEvaluationItem_ToPerformanceReviewItem] FOREIGN KEY ([PerformanceReviewItemId]) REFERENCES [PerformanceReviewItem]([Id])
)
