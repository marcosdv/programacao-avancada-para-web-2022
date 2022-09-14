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

CREATE TABLE [Editora] (
    [Id] int NOT NULL IDENTITY,
    [Nome] VARCHAR(80) NOT NULL,
    CONSTRAINT [PK_Editora] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Livro] (
    [Id] int NOT NULL IDENTITY,
    [Nome] VARCHAR(150) NOT NULL,
    [EditoraId] int NOT NULL,
    CONSTRAINT [PK_Livro] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Livro_Editora] FOREIGN KEY ([EditoraId]) REFERENCES [Editora] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Livro_EditoraId] ON [Livro] ([EditoraId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220913230939_CriacaoInicial', N'6.0.9');
GO

COMMIT;
GO

