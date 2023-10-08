CREATE TABLE [dbo].[tblLoan]
(
	[Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [LoanNumber] NVARCHAR (100) NOT NULL,
    [LoanName]    NVARCHAR (100) NOT NULL,
    [LoanType]    NVARCHAR (75)  NOT NULL,
    [LoanAmount]  DECIMAL        NOT NULL,
    [CustId]  NVARCHAR(100)      NOT NULL,
    [CreateDate] DATETIME     NOT NULL CONSTRAINT [DF_tblLoan_CreateDate] DEFAULT (getdate()),
    [CreatedBy]	 VARCHAR (60) NOT NULL CONSTRAINT [DF_tblLoan_CreatedBy] DEFAULT (suser_sname()),
    
    CONSTRAINT [PK_tblLoan] PRIMARY KEY CLUSTERED ([LoanNumber] ASC),
    CONSTRAINT [FK_tblLoan_tblCustomer_CustomerId] FOREIGN KEY ([CustId]) REFERENCES [dbo].[tblCustomer] ([CustId])
);