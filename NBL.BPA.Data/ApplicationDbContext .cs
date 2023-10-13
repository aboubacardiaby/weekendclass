using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NBL.BPA.Domain.Entities;

namespace NBL.BPA.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _config;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder bldr)
        //{
        //    base.OnConfiguring(bldr);

        //    bldr.UseSqlServer(_config.GetConnectionString("ConnectionStrings"));
        //}

        public DbSet<Customer> tblCustomer { get; set; }
        public DbSet<Loan> tblLoan { get; set; }
        public DbSet<Payment> tblPayment { get; set; }
       
    }
}