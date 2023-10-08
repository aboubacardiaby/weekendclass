CREATE TABLE [dbo].[tblPayment]
(
   [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [LoanNumber]    NVARCHAR (100) NOT NULL,
    [DueDate]       DATETIME2 (7)  NOT NULL,
    [PaymentAmount] decimal(18,0)  NOT NULL,
    [PaymentType]   NVARCHAR (100) NOT NULL,
    [Comment]       NVARCHAR (MAX) NOT NULL,
    [CreateDate] DATETIME     NOT NULL CONSTRAINT [DF_tblPayment_CreateDate] DEFAULT (getdate()),
    [CreatedBy]	 VARCHAR (60) NOT NULL CONSTRAINT [DF_tblPayment_CreatedBy] DEFAULT (suser_sname()),
  
    CONSTRAINT [PK_tblPayment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_tblLoan_tblPayment_Loanumber] FOREIGN KEY ([LoanNumber]) REFERENCES [dbo].[tblLoan] ([LoanNumber])
);