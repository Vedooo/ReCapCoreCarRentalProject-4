CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL, 
    [FirstName] NCHAR(10) NULL, 
    [LastName] NCHAR(10) NULL, 
    [Email] NCHAR(10) NULL, 
    [Password] NCHAR(10) NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId]) 
)
