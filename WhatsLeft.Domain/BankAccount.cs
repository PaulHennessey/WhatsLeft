using System.Collections.Generic;

namespace WhatsLeft.Domain
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public virtual ICollection<Fund> Funds { get; set; }
    }
}
