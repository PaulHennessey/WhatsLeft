
namespace WhatsLeft.Domain
{
    public class Fund
    {
        // Primary key
        public int FundId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }

        // Foreign key
        public int BankAccountId { get; set; }

        // Navigation property
        public virtual BankAccount BankAccount { get; set; }
    }
}
