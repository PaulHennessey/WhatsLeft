using System;
using System.Collections.Generic;
using WhatsLeft.Domain;

namespace WhatsLeft.Models.Home
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {}

        public IndexViewModel(BankAccount account)
        {
            Id = account.BankAccountId;
            Name = account.Name;
            Balance = account.Balance;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public int WhatsLeft { get; set; }
    }
}
