USE [NBLDB]
GO
DELETE [dbo].[tblCustomer]
INSERT INTO [dbo].[tblCustomer]
           ([CustId]
           ,[FirstName]
           ,[LastName]
           ,[Email]
           ,[PhoneNumber]
           ,[Address]
           ,[City]
           ,[State]
           )
  VALUES ('002','David','Johnson','david.johnson@gmail.com','612-239-6000','1 first street','Minneapolis','MN')
GO


