CREATE TABLE [dbo].[Rentals]
(
	[RentId] INT NOT NULL, 
    [CarId] INT NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [RentDate] DATETIME NULL, 
    [ReturnDate] DATETIME NULL, 
    CONSTRAINT [PK_Rentals] PRIMARY KEY ([RentId]) 
)
