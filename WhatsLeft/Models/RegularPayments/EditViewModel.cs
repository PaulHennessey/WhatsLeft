using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WhatsLeft.Domain;
using WhatsLeft.Repositories;
using System.Linq;

namespace WhatsLeft.Models.RegularPayments
{
    public class EditViewModel
    {
        private BankAccountRepository bankAccountRepository = new BankAccountRepository();

        public EditViewModel()
        { }

        public EditViewModel(RegularPayment regularPayment)
        {
            var accounts = bankAccountRepository.GetBankAccounts();

            Id = regularPayment.RegularPaymentId;
            Name = regularPayment.Name;
            Amount = regularPayment.Amount;
            PaymentDay = regularPayment.PaymentDay;
            Accounts = accounts.Select(a => new SelectListItem
            {
                Value = a.BankAccountId.ToString(),
                Text = a.Name
            });
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int PaymentDay { get; set; }

        [Display(Name = "Account")]
        public int SelectedAccountId { get; set; }
        public IEnumerable<SelectListItem> Accounts;
    }
}
