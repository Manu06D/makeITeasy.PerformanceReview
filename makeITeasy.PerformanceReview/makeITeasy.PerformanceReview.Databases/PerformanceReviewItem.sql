CREATE TABLE [dbo].[PerformanceReviewItem]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PerformanceReviewId] INT NOT NULL, 
    [PerformanceReviewCategoryId] INT NOT NULL, 
    [Description] VARCHAR(512) NOT NULL, 
    CONSTRAINT [FK_PerformanceReviewQuestion_ToPerformanceReview] FOREIGN KEY ([PerformanceReviewId]) REFERENCES [PerformanceReviewMain]([Id]), 
        CONSTRAINT [FK_PerformanceReviewQuestion_ToPerformanceReviewCategory] FOREIGN KEY ([PerformanceReviewCAtegoryId]) REFERENCES [PerformanceReviewCategory]([Id]), 
)
