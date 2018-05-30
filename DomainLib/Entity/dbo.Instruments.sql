CREATE TABLE [dbo].[Instruments] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [NameInstrument] NVARCHAR (MAX) NULL,
    [Description]    NVARCHAR (MAX) NULL,
    [YearIssue]      NVARCHAR (MAX) NULL,
    [Characteristic] NVARCHAR (MAX) NULL,
    [Service_Id]     INT            NULL,
    
    CONSTRAINT [PK_dbo.Instruments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Instruments_dbo.Services_Service_Id] FOREIGN KEY ([Service_Id]) REFERENCES [dbo].[Services] ([Id]),
    );


GO
CREATE NONCLUSTERED INDEX [IX_Service_Id]
    ON [dbo].[Instruments]([Service_Id] ASC);

