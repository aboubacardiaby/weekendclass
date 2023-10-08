using Microsoft.EntityFrameworkCore;
using NBL.BPA.Domain.Entities;

namespace NBL.BPA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> tblCustomer { get; set; }
        public DbSet<Loan> tblLoan { get; set; }
        public DbSet<Payment> tblPayment { get; set; }
       
    }
}