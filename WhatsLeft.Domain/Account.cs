using System.Collections.Generic;

namespace WhatsLeft.Domain
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<VirtualAccount> VirtualAccounts { get; set; }
    }
}
