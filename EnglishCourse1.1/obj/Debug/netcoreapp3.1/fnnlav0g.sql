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
    [Nombre] nvarchar(max) NULL,
    CONSTRAINT [PK_curso] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [profesores] (
    [Id] int NOT NULL IDENTITY,
    [nombre] nvarchar(max) NULL,
    [apellido] nvarchar(max) NULL,
    [Edad] int NOT NULL,
    CONSTRAINT [PK_profesores] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [secciones] (
    [Id] int NOT NULL IDENTITY,
    [hora] datetime2 NOT NULL,
    [Aula] nvarchar(max) NULL,
    [idcurso] int NOT NULL,
    [idprofesor] int NOT NULL,
    [cursoId] int NULL,
    [profesoresId] int NULL,
    CONSTRAINT [PK_secciones] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_secciones_curso_cursoId] FOREIGN KEY ([cursoId]) REFERENCES [curso] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_secciones_profesores_profesoresId] FOREIGN KEY ([profesoresId]) REFERENCES [profesores] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [estudiantes] (
    [Id] int NOT NULL IDENTITY,
    [nombre] nvarchar(max) NULL,
    [apellido] nvarchar(max) NULL,
    [edad] int NOT NULL,
    [correo] nvarchar(max) NULL,
    [telefono] nvarchar(max) NULL,
    [idseccion] int NOT NULL,
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

