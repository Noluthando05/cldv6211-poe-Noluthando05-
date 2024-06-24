CREATE TABLE [dbo].[Products] (
    [Id]          INT         IDENTITY (1, 1) NOT NULL,
    [product_name]        NCHAR (50)  NOT NULL,
    [price]       NCHAR (50)  NOT NULL,
    [category]    NCHAR (50)  NOT NULL,
    [availablity] NCHAR (100) NOT NULL,
    [raitings] NCHAR(10) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

