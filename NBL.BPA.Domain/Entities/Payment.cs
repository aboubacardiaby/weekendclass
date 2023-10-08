using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL.BPA.Domain.Entities
{
    public class Payment
    {
        public string LoanNumber { get; set; }
        public DateTime DueDate { get; set; }
        public string PaymentAmount { get; set; }
        public string PaymentType { get; set; }
        public string Comment { get; set; }
    }
}
