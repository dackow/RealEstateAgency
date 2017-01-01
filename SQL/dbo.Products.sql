CREATE TABLE [dbo].[Products] (
    [Id]          INT             NOT NULL IDENTITY,
    [Name]        VARCHAR (100)   NOT NULL,
    [Description] VARCHAR (1000)  NOT NULL,
    [Price]       DECIMAL (16, 2) NOT NULL,
    [Category]    NVARCHAR (1)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

