using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsLeft.Domain;

namespace WhatsLeft.Models
{
    public class BankAccountsViewModel
    {
        public List<BankAccount> BankAccounts { get; set; }
    }

    public class BankAccountViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public virtual ICollection<Fund> Funds { get; set; }
    }

    public class FundViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }     
    }
}