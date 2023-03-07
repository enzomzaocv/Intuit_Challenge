IF(NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME LIKE 'Customer'))
BEGIN
    CREATE TABLE [dbo].[Customer](
        [IdCustomer] INT IDENTITY(1,1) NOT NULL,
        [Name] NVARCHAR(70) NOT NULL,
        [Surname] NVARCHAR(70) NOT NULL,
        [Birthdate] DATETIME NULL,
        [IdentificationNumber] NVARCHAR(13) NOT NULL,
        [Adress] NVARCHAR(100) NULL,
        [Phone] NVARCHAR(13) NOT NULL,
        [Email] NVARCHAR(70) NOT NULL
        CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
        (
	        [IdCustomer] ASC
        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO


INSERT INTO [Customer]
    ([Name],
    [Surname],
    [Birthdate],
    [IdentificationNumber],
    [Adress],
    [Phone],
    [Email])
VALUES
    ('Pedro',
    'Aguilar',
    DATEADD(YEAR, -10, GETDATE()),
    '20-11111111-8',
    'San juan 1234, Mendoza',
    '261-5760564',
    'pedro@gmail.com'),
    ('Pablo',
    'Aguinaga',
    DATEADD(YEAR, -11, GETDATE()),
    '20-11118811-8',
    'San juan 34, Mendoza',
    '261-5168564',
    'pablo@gmail.com'),
    ('Ariana',
    'Salar',
    DATEADD(YEAR, -18, GETDATE()),
    '20-38118811-8',
    'San Pedro 1234, Mendoza',
    '261-5192564',
    'ariana@gmail.com'),
    ('Samanta',
    'Camba',
    DATEADD(YEAR, -22, GETDATE()),
    '20-39618811-8',
    'San Martin 1234, Mendoza',
    '261-5192954',
    'samanta@gmail.com')