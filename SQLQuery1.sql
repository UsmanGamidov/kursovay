CREATE TABLE [dbo].[Klienti] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [FIO]      NVARCHAR (50) NOT NULL,
    [password] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Rabotniki] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [login]    NVARCHAR (50)  NOT NULL,
    [password] NVARCHAR (50)  NOT NULL,
    [rol]      NVARCHAR (200) NOT NULL,
    [FIO]      NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Turi] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [FIO_zakazchika]  NVARCHAR (50)  NOT NULL,
    [opisanie_roboti] NVARCHAR (500) NOT NULL,
    [price]           MONEY          NOT NULL,
    [date]            DATE           NOT NULL,
    [tyr_operator]    NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
