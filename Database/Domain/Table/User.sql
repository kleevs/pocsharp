CREATE TABLE [Domain].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Login] NCHAR(50) NOT NULL, 
    [Password] NCHAR(10) NOT NULL
)
