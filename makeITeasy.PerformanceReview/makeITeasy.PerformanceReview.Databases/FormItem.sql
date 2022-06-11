CREATE TABLE [perfReview].[FormItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FormId] INT NOT NULL, 
    [FormItemType] INT NULL DEFAULT 0, 
    --[PerformanceReviewCategoryId] INT NOT NULL, 
    [Description] VARCHAR(512) NOT NULL
    CONSTRAINT [FK_PerformanceReviewQuestion_ToPerformanceReview] FOREIGN KEY ([FormId]) REFERENCES [perfReview].[Form]([Id]), 
        [Category] VARCHAR(50) NULL, 
    [LevelId] INT NULL, 
    CONSTRAINT [FK_FormItem_ToTable] FOREIGN KEY ([LevelId]) REFERENCES [perfReview].[Level]([Id])
    --CONSTRAINT [FK_PerformanceReviewQuestion_ToPerformanceReviewCategory] FOREIGN KEY ([PerformanceReviewCAtegoryId]) REFERENCES [PerformanceReviewCategory]([Id]), 
    --CONSTRAINT [FK_PerformanceReviewItem_ToEmployee] FOREIGN KEY ([Id]) REFERENCES [Employee]([Id]), 
)
