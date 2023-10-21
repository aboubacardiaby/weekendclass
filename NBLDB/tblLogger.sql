CREATE TABLE [dbo].[tblLogger]
(
	[Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [LogFileName] NVARCHAR (100) NOT NULL,
    [LogFilePath]    NVARCHAR (100) NOT NULL,
    [FileStatus]    NVARCHAR (100)  NOT NULL,    
    [ProcessEndDate]  DATETIME       NULL,
    [CreateDate] DATETIME     NOT NULL CONSTRAINT [DF_tblLogger_CreateDate] DEFAULT (getdate()),
    [CreatedBy]	 VARCHAR (60) NOT NULL CONSTRAINT [DF_tblLogger_CreatedBy] DEFAULT (suser_sname()),
    
    
)
