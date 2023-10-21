using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NBL.BPA.Domain.Entities;

namespace NBL.BPA.Data
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task AddCustomer(Customer customer)
        {
            var query = _context.tblCustomer.Find(customer.CustId);
            if (query == null)
            {
                try
                {

                    object[] paramItems = new object[]
                       {
                        new SqlParameter("@CustId", customer.CustId),
                        new SqlParameter("@FirstName", customer.FirstName),
                        new SqlParameter("@LastName", customer.LastName),
                        new SqlParameter("@Email", customer.Email),
                        new SqlParameter("@PhoneNumber", customer.PhoneNumber),
                        new SqlParameter("@Address", customer.Address),
                        new SqlParameter("@City", customer.City),
                        new SqlParameter("@State", customer.State),
                        };

                    _context.Database.ExecuteSqlRaw(@"INSERT INTO tblCustomer
                                                               ([CustId]
                                                               ,[FirstName]
                                                               ,[LastName]
                                                               ,[Email]
                                                               ,[PhoneNumber]
                                                               ,[Address]
                                                               ,[City]
                                                               ,[State]
                                                               )
                                                         VALUES
                                                               (@CustId 
                                                               ,@FirstName 
                                                               ,@LastName 
                                                               ,@Email 
                                                               ,@PhoneNumber 
                                                               ,@Address 
                                                               ,@City
                                                               ,@State
                                                               )", paramItems);




                }
                catch (Exception exec)
                {

                    throw exec;
                }
            }


        }

        public async Task Addloan(Loan loan, string custId)
        {

            try
            {
                object[] paramItems = new object[]
                   {
                        new SqlParameter("@LoanName", loan.LoanName),
                        new SqlParameter("@LoanAmount", loan.LoanAmount),
                        new SqlParameter("@LoanType", loan.LoanType),
                        new SqlParameter("@LoanNumber", loan.LoanNumber),
                        new SqlParameter("CustId", custId),

                    };


                _context.Database.ExecuteSqlRaw(@"INSERT INTO [dbo].[tblLoan]
                                                       ([LoanNumber]
                                                       ,[LoanName]
                                                       ,[LoanType]
                                                       ,[LoanAmount]
                                                       ,[CustId]
                                                     )
                                                 VALUES
                                                       (@LoanNumber
                                                       ,@LoanName
                                                       ,@LoanType
                                                       ,@LoanAmount
                                                       ,@CustId
                                                     )", paramItems);




            }
            catch (Exception exec)
            {


            }




        }

        public async Task AddLogger(Logger logger)
        {
            _context.tblLogger.Add(logger);
            _context.SaveChanges();
        }
        public async Task UpdateLogger(Logger logger)
        {
            _context.tblLogger.Update(logger);
            _context.SaveChanges();
        }

    }
}
