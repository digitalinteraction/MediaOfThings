CREATE TABLE [dbo].[ThingTypesToFields]
(
    [ThingTypeId] INT NOT NULL, 
    [FieldId] INT NOT NULL, 
    CONSTRAINT [PK_ThingTypeToFields] PRIMARY KEY ([ThingTypeId],[FieldId]), 
    CONSTRAINT [FK_ThingTypesToFields_ThingTypes] FOREIGN KEY ([ThingTypeId]) REFERENCES [ThingTypes]([Id]), 
    CONSTRAINT [FK_ThingTypesToFields_Fields] FOREIGN KEY ([FieldId]) REFERENCES [Fields]([Id])
)
