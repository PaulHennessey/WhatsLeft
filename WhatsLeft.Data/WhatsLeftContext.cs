using System.Data.Entity;
using WhatsLeft.Domain;

namespace WhatsLeft.Data
{
    public class WhatsLeftContext : DbContext
    {
        public WhatsLeftContext() : base("WhatsLeft")
        {}

        public DbSet<Account> Accounts { get; set; }
        public DbSet<VirtualAccount> VirtualAccounts { get; set; }
    }
}
