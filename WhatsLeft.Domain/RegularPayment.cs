using System;

namespace WhatsLeft.Domain
{
    public class RegularPayment
    {
        // Primary key
        public int RegularPaymentId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int PaymentDay { get; set; }

        // Foreign key
        public int BankAccountId { get; set; }

        // Navigation property
        public virtual BankAccount BankAccount { get; set; }
    }
}
