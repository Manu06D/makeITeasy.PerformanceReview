CREATE TABLE [dbo].[PerformanceReviewCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PerformanceFormId] INT NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_PerformanceReviewCategory_ToTable] FOREIGN KEY ([PerformanceFormId]) REFERENCES [PerformanceReviewForm]([Id])
)
