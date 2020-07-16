IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [curso] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(15) NULL,
    CONSTRAINT [PK_curso] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [profesores] (
    [Id] int NOT NULL IDENTITY,
    [nombre] nvarchar(50) NULL,
    [apellido] nvarchar(50) NULL,
    [Edad] int NOT NULL,
    CONSTRAINT [PK_profesores] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [secciones] (
    [Id] int NOT NULL IDENTITY,
    [hora] datetime2 NOT NULL,
    [Aula] nvarchar(5) NULL,
    [cursoId] int NULL,
    [profesoresId] int NULL,
    CONSTRAINT [PK_secciones] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_secciones_curso_cursoId] FOREIGN KEY ([cursoId]) REFERENCES [curso] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_secciones_profesores_profesoresId] FOREIGN KEY ([profesoresId]) REFERENCES [profesores] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [estudiantes] (
    [Id] int NOT NULL IDENTITY,
    [nombre] nvarchar(50) NULL,
    [apellido] nvarchar(50) NULL,
    [edad] int NOT NULL,
    [correo] nvarchar(50) NULL,
    [telefono] nvarchar(25) NULL,
    [seccionesId] int NULL,
    CONSTRAINT [PK_estudiantes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_estudiantes_secciones_seccionesId] FOREIGN KEY ([seccionesId]) REFERENCES [secciones] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_estudiantes_seccionesId] ON [estudiantes] ([seccionesId]);

GO

CREATE INDEX [IX_secciones_cursoId] ON [secciones] ([cursoId]);

GO

CREATE INDEX [IX_secciones_profesoresId] ON [secciones] ([profesoresId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200714141845_inicial', N'3.1.5');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[secciones]') AND [c].[name] = N'idcurso');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [secciones] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [secciones] DROP COLUMN [idcurso];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[secciones]') AND [c].[name] = N'idprofesor');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [secciones] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [secciones] DROP COLUMN [idprofesor];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[estudiantes]') AND [c].[name] = N'idseccion');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [estudiantes] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [estudiantes] DROP COLUMN [idseccion];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200714181233_2migracion', N'3.1.5');

GO

