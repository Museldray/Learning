CREATE TABLE [dbo].[FizzBuzz]
(
	[Id]    INT        IDENTITY (1, 1) NOT NULL,
	[Number]	INT		NOT NULL,
    [Result]	VARCHAR (50)	NOT NULL,
    [Date]	datetime     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
