IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Username] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [TokensAvailable] int NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Books] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Rating] float NOT NULL,
    [Author] nvarchar(max) NOT NULL,
    [Genre] nvarchar(max) NOT NULL,
    [IsBookAvailable] bit NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [LentByUserId] nvarchar(450) NOT NULL,
    [CurrentlyBorrowedById] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Books_Users_CurrentlyBorrowedById] FOREIGN KEY ([CurrentlyBorrowedById]) REFERENCES [Users] ([Id]),
    CONSTRAINT [FK_Books_Users_LentByUserId] FOREIGN KEY ([LentByUserId]) REFERENCES [Users] ([Id])
);
GO

CREATE INDEX [IX_Books_CurrentlyBorrowedById] ON [Books] ([CurrentlyBorrowedById]);
GO

CREATE INDEX [IX_Books_LentByUserId] ON [Books] ([LentByUserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231124080709_init', N'8.0.0');
GO

COMMIT;
GO

