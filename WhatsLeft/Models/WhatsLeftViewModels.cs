using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsLeft.Domain;

namespace WhatsLeft.Models
{
    public class BankAccountsViewModel
    {
        public BankAccountsViewModel()
        {
            BankAccounts = new List<BankAccountViewModel>();
        }

        public List<BankAccountViewModel> BankAccounts { get; set; }
    }

    public class BankAccountViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public virtual ICollection<Fund> Funds { get; set; }

        public int WhatsLeft { get; set; }

        public int FromFundId { get; set; }
        public int ToFundId { get; set; }
        public int Amount { get; set; }

        public DateTime NextPayDate { get; set; }
    }

    public class FundViewModel
    {
        public int FundId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; } 
        public int BankAccountId { get; set; }
    }
}