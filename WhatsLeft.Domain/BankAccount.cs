using System.Collections.Generic;
using System.Linq;

namespace WhatsLeft.Domain
{
    public class BankAccount
    {
        // Primary key
        public int BankAccountId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }

        // Navigation property
        public virtual ICollection<Fund> Funds { get; set; }
        public virtual ICollection<RegularPayment> RegularPayments { get; set; }
    }
}
