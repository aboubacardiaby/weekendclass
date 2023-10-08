CREATE TABLE [dbo].[tblCustomer]
(
	[Id]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [CustId]           NVARCHAR (100) NOT NULL,
    [FirstName]        NVARCHAR (100) NOT NULL,
    [LastName]         NVARCHAR (100) NOT NULL,   
    [Email]            NVARCHAR (100)     NULL,
    [PhoneNumber]      NVARCHAR (100) NOT NULL,
    [Address]          NVARCHAR (100) NOT NULL, 
    [City]             NVARCHAR (100) NOT NULL,
    [State]            NVARCHAR (50) NOT NULL,    
    [CreateDate] DATETIME     NOT NULL CONSTRAINT [DF_tblCustomer_CreateDate] DEFAULT (getdate()),
    [CreatedBy]	 VARCHAR (60) NOT NULL CONSTRAINT [DF_tblCustomer_CreatedBy] DEFAULT (suser_sname()),
    
    CONSTRAINT [PK_tblCustomer] PRIMARY KEY CLUSTERED ([CustId] ASC)
);
