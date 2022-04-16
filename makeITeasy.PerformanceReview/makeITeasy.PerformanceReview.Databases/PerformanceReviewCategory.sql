CREATE TABLE [dbo].[PerformanceReviewCategory]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PerformanceReviewId] INT NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_PerformanceReviewCategory_ToTable] FOREIGN KEY ([PerformanceReviewId]) REFERENCES [PerformanceReviewMain]([Id])
)
