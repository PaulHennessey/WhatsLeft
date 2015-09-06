
namespace WhatsLeft.Domain
{
    public class Fund
    {
        public Fund()
        {}

        public Fund(int id, string name, int balance)
        {
            FundId = id;
            Name = name;
            Balance = balance;
        }

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
