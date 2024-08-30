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

CREATE TABLE [TURMA] (
    [ID] uniqueidentifier NOT NULL,
    [NUMERO] nvarchar(max) NOT NULL,
    [ANO_LETIVO] nvarchar(max) NOT NULL,
    [NIVEL] int NOT NULL,
    CONSTRAINT [PK_TURMA] PRIMARY KEY ([ID])
);
GO

CREATE TABLE [ALUNO] (
    [ID] uniqueidentifier NOT NULL,
    [NOME] nvarchar(100) NOT NULL,
    [CPF] nvarchar(max) NOT NULL,
    [EMAIL] nvarchar(max) NOT NULL,
    [TURMA_ID] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ALUNO] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_ALUNO_TURMA_TURMA_ID] FOREIGN KEY ([TURMA_ID]) REFERENCES [TURMA] ([ID]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ALUNO_TURMA_ID] ON [ALUNO] ([TURMA_ID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240827015026_Initial', N'7.0.20');
GO

COMMIT;
GO

