﻿CREATE TABLE [dbo].[FormItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FormId] INT NOT NULL, 
    --[PerformanceReviewCategoryId] INT NOT NULL, 
    [Description] VARCHAR(512) NOT NULL
    CONSTRAINT [FK_PerformanceReviewQuestion_ToPerformanceReview] FOREIGN KEY ([FormId]) REFERENCES [Form]([Id]), 
        [Category] VARCHAR(50) NULL, 
    --CONSTRAINT [FK_PerformanceReviewQuestion_ToPerformanceReviewCategory] FOREIGN KEY ([PerformanceReviewCAtegoryId]) REFERENCES [PerformanceReviewCategory]([Id]), 
    --CONSTRAINT [FK_PerformanceReviewItem_ToEmployee] FOREIGN KEY ([Id]) REFERENCES [Employee]([Id]), 
)