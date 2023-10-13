using NBL.BPA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL.BPA.Data
{
    public interface IRepository
    {
        Task AddCustomer(Customer customer);
        Task Addloan(Loan loan, string custId);
        Task<Customer> GetCustomerById(string id);
        // Task<Customer> GetCustomerDa

        Task<Customer> GetCustomerDetails(string customerid);
        List<Customer> GetCustomers();

        Task<Loan> GetLoanInfobyCustomerAsync(string customerid);
    }
}
