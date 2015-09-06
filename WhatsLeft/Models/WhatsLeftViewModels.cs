using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int BankAccountId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        
        public List<Fund> Funds { get; set; }
        public List<RegularPayment> RegularPayments { get; set; }

        [Display(Name = "What's Left?")]
        public int WhatsLeft { get; set; }
        public int FromFundId { get; set; }
        public int ToFundId { get; set; }
        public int Amount { get; set; }

        [Display(Name="Next Pay Day")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NextPayDay { get; set; }
    }

    public class FundViewModel
    {
        public int FundId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; } 
        public int BankAccountId { get; set; }
    }

    public class RegularPaymentViewModel
    {
        public int RegularPaymentId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int PaymentDay { get; set; }
        public int BankAccountId { get; set; }
    }
}