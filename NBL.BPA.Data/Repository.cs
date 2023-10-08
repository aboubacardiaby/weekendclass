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
            bool IsCustomerExist = false;

            Customer customerfromDb = await _context.tblCustomer.FindAsync(customer.CustId);

            if (customerfromDb != null)
            {
                IsCustomerExist = true;
            }
            else
            {
                customerfromDb = new Customer();
            }

            try
            {

                await _context.Database.ExecuteSqlInterpolatedAsync($"Usp_AddOrEditCustomer  @CustId ={customer.CustId}, @FirstName ={customer.FirstName}, @LastName ={customer.LastName}, @Genre= {customer.Genre},@Email ={customer.Email}, @PhoneNumber = {customer.PhoneNumber},@Address = {customer.Address},@Region ={customer.Region}, @NationalIdNumber = {customer.NationalIdNumber}, @JoinDate={customer.JoinDate}");

                //if (IsCustomerExist)
                //{
                //    _context.tblCustomer.Update(customerfromDb);
                //}
                //else
                //{
                //  await   _context.tblCustomer.AddAsync(customer);
                //}
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
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
