CREATE TABLE [dbo].[Cars]
(
	[CarId] INT NOT NULL, 
    [BrandId] INT NOT NULL, 
    [ColorId] INT NOT NULL, 
    [ModelYear] NCHAR(10) NULL, 
    [DailyPrice] DECIMAL NULL, 
    [Description] NCHAR(10) NULL, 
    CONSTRAINT [PK_Cars] PRIMARY KEY ([CarId]) 
)
