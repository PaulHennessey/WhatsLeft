using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsLeft.Domain;

namespace WhatsLeft.Models
{
    public class CreateRegularPaymentViewModel
    {
        public int RegularPaymentId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int PaymentDay { get; set; }
        public int BankAccountId { get; set; }
    }

    public class EditRegularPaymentViewModel
    {
        public EditRegularPaymentViewModel()
        {}

        public EditRegularPaymentViewModel(RegularPayment regularPayment)
        {
            RegularPaymentId = regularPayment.RegularPaymentId;
            Name = regularPayment.Name;
            Amount = regularPayment.Amount;
            PaymentDay = regularPayment.PaymentDay;
            BankAccountId = regularPayment.BankAccountId;
        }

        public int RegularPaymentId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int PaymentDay { get; set; }
        public int BankAccountId { get; set; }
    }
}