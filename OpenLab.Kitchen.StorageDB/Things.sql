CREATE TABLE [dbo].[Things]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[LocationId] INT NOT NULL, 
    [ThingTypeId] INT NOT NULL,
	[Name] NVARCHAR(MAX) NOT NULL, 
	CONSTRAINT [FK_Things_Location] FOREIGN KEY ([LocationId]) REFERENCES [Locations]([Id]),
    CONSTRAINT [FK_Things_ThingTypes] FOREIGN KEY ([ThingTypeId]) REFERENCES [ThingTypes]([Id])
)
