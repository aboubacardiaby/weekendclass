using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBL.BPA.Domain.Entities
{
    public  class Loan:BaseEntity
    {
        public string LoandNumber { get; set; }
        public string LoanName { get; set; }
        public string LoanType { get; set; }
        public string LoanAmount { get; set; }
       
        private ICollection<Payment> Payments { get; set; }

    }
}
