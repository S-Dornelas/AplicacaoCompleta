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

CREATE TABLE [Fornecedor] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Documento] varchar(14) NOT NULL,
    [TipoFornecedor] int NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Fornecedor] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Endereco] (
    [Id] uniqueidentifier NOT NULL,
    [FornecedorId] uniqueidentifier NULL,
    [Logradouro] varchar(200) NOT NULL,
    [Numero] varchar(50) NOT NULL,
    [Complemento] varchar(100) NOT NULL,
    [Cep] varchar(8) NOT NULL,
    [Bairro] varchar(100) NOT NULL,
    [Cidade] varchar(100) NOT NULL,
    [Estado] varchar(50) NOT NULL,
    CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Endereco_Fornecedor_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [Fornecedor] ([Id])
);
GO

CREATE TABLE [Produtos] (
    [Id] uniqueidentifier NOT NULL,
    [FornecedorId] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Descricao] varchar(1000) NOT NULL,
    [Imagem] varchar(200) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Produtos_Fornecedor_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [Fornecedor] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Endereco_FornecedorId] ON [Endereco] ([FornecedorId]) WHERE [FornecedorId] IS NOT NULL;
GO

CREATE INDEX [IX_Produtos_FornecedorId] ON [Produtos] ([FornecedorId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230524195013_Initial', N'7.0.5');
GO

COMMIT;
GO

