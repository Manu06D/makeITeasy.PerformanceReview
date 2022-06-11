CREATE TABLE [perfReview].[AppUser]
(
    [Id]                   NVARCHAR (450)     NOT NULL,
    [UserName]             NVARCHAR (256)     NULL,
    [NormalizedUserName]   NVARCHAR (256)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [NormalizedEmail]      NVARCHAR (256)     NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NOT NULL,
    [TwoFactorEnabled]     BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    [LockoutEnabled]       BIT                NOT NULL,
    [AccessFailedCount]    INT                NOT NULL,
    [Name] VARCHAR(250) NULL, 
    [ManagerId] NVARCHAR (450) NULL, 
    [LevelId] INT NULL, 
    [FirstYearOfWork] INT NULL, 
    [Education] NVARCHAR(255) NULL, 
    CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_AppUser_ToTable] FOREIGN KEY ([ManagerId]) REFERENCES [perfReview].[AppUser]([Id]),
    CONSTRAINT [FK_AppUser_ToLevel] FOREIGN KEY ([LevelId]) REFERENCES [perfReview].[Level]([Id])
)


GO
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex]
    ON [perfReview].[AppUser]([NormalizedUserName] ASC) WHERE ([NormalizedUserName] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [EmailIndex]
    ON [perfReview].[AppUser]([NormalizedEmail] ASC);
