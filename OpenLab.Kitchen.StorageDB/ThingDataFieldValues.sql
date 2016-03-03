CREATE TABLE [dbo].[ThingDataFieldValues]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ThingDataId] INT NOT NULL, 
    [FieldId] INT NOT NULL, 
    [Value] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_ThingDataFieldValues_ThingData] FOREIGN KEY ([ThingDataId]) REFERENCES [ThingData]([Id]), 
    CONSTRAINT [FK_ThingDataFieldValues_Fields] FOREIGN KEY ([FieldId]) REFERENCES [Fields]([Id])
)
