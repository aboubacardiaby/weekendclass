using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NBL.BPA.Domain.Entities
{
    public class Customer:BaseEntity
    {

        [Key]
        public string CustId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }       
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}