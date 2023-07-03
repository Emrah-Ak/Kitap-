CREATE TABLE [dbo].[Kitaplar]
(
	[Id] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [Kitap Adı] VARCHAR(40) NULL, 
    [Türü] VARCHAR(50) NULL, 
    [Yazarı] VARCHAR(50) NULL, 
    [Fiyatı] SMALLMONEY NULL
)
