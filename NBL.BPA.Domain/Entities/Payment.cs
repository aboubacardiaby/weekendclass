namespace NBL.BPA.Domain.Entities
{
    public partial class Payment : BaseEntity
    {
        public string LoanNumber { get; set; }
        public DateTime DueDate { get; set; }
        public string PaymentAmount { get; set; }
        public string PaymentType { get; set; }
        public string Comment { get; set; }
    }
}
