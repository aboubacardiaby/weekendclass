using NBL.BPA.Domain.Entities;

namespace NBL.BPA.Data
{
    public interface IRepository
    {
        Task AddCustomer(Customer customer);
        Task Addloan(Loan loan, string custId);

        Task AddLogger(Logger logger);
    }
}
