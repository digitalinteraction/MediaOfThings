CREATE TABLE [dbo].[Fields]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FieldDataTypeId] INT NOT NULL, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Fields_FieldTypes] FOREIGN KEY ([FieldDataTypeId]) REFERENCES [FieldDataTypes]([Id])
)
