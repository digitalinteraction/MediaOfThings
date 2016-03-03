CREATE TABLE [dbo].[ThingDataTypesToFields]
(
	[ThingDataTypeId] INT NOT NULL , 
    [FieldId] INT NOT NULL, 
    PRIMARY KEY ([ThingDataTypeId], [FieldId]), 
    CONSTRAINT [FK_ThingDataTypesToFields_ThingDataTypes] FOREIGN KEY ([ThingDataTypeId]) REFERENCES [ThingDataTypes]([Id]), 
    CONSTRAINT [FK_ThingDataTypesToFields_Fields] FOREIGN KEY ([FieldId]) REFERENCES [Fields]([Id])
)
