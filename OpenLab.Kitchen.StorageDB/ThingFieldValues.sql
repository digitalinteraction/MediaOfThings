CREATE TABLE [dbo].[ThingFieldValues]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ThingId] INT NOT NULL, 
    [FieldId] INT NOT NULL, 
    [Value] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_ThingFieldValues_Things] FOREIGN KEY ([ThingId]) REFERENCES [Things]([Id]), 
    CONSTRAINT [FK_ThingFieldValues_Fields] FOREIGN KEY ([FieldId]) REFERENCES [Fields]([Id])
)
