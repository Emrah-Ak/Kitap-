CREATE TABLE [dbo].[Müşteri]
(
	[MüşterID] INT NOT NULL PRIMARY KEY, 
    [Adı] VARCHAR(50) NULL, 
    [Soyadı] VARCHAR(50) NULL, 
    [Tel No] NCHAR(15) NULL, 
    [Adres] VARCHAR(50) NULL, 
    [Kitap Adı] VARCHAR(50) NULL, 
    [Fiyat] SMALLMONEY NULL	
)
