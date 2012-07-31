CREATE TABLE [dbo].[Items]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(200) NULL, 
    [Status] NVARCHAR(10) NOT NULL DEFAULT 'Pending', 
    [Deadline] DATE NULL
)
