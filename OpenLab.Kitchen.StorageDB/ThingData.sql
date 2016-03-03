CREATE TABLE [dbo].[ThingData]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ThingDataTypeId] INT NOT NULL, 
	[ThingId] INT NOT NULL,
    [Name] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_ThingData_ThingDataTypes] FOREIGN KEY ([ThingDataTypeId]) REFERENCES [ThingDataTypes]([Id]), 
    CONSTRAINT [FK_ThingData_Things] FOREIGN KEY ([ThingId]) REFERENCES [Things]([Id])
)
