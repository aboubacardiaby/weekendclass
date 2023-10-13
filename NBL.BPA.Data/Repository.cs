using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NBL.BPA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task Addloan(Loan loan, string custId)
        {
            try
            {
                object[] paramItems = new object[]
                   {
                        new SqlParameter("@LoanName", loan.LoanName),
                        new SqlParameter("@LoanAmount", loan.LoanAmount),
                        new SqlParameter("@LoanType", loan.LoanType),
                        new SqlParameter("@LoanNumber", loan.LoandNumber),
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
                
                throw exec;
            }

}

        public async Task<Customer> GetCustomerById(string customerid)
        {

            var customer = await _context.tblCustomer.FindAsync(customerid);
            return customer;
        }

        public async Task<Customer> GetCustomerDetails(string customerid)
        {
            var customer = await _context.tblCustomer.FirstOrDefaultAsync(m => m.CustId == customerid);
            if (customer == null)
            {
                return null;
            }
            return customer;
        }
        public List<Customer> GetCustomers()
        {
            var customers = _context?.tblCustomer?.FromSqlRaw<Customer>($"Usp_GetAllCustomer").ToList();
            return _context.tblCustomer.ToList();
        }
        #region Loan Repos
        public async Task<Loan> GetLoanInfobyCustomerAsync(string customerid)
        {
            return null;
            //return _context.tblCustomer.
        }
        #endregion
    }
}
