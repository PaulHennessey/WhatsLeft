using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WhatsLeft.Domain;
using WhatsLeft.Repositories;
using System.Linq;

namespace WhatsLeft.Models.Funds
{
    public class EditViewModel
    {
        private BankAccountRepository bankAccountRepository = new BankAccountRepository();

        public EditViewModel()
        { }

        public EditViewModel(Fund fund)
        {
            var accounts = bankAccountRepository.GetBankAccounts();

            Id = fund.FundId;
            Name = fund.Name;
            Balance = fund.Balance;
            Accounts = accounts.Select(a => new SelectListItem
            {
                Value = a.BankAccountId.ToString(),
                Text = a.Name
            });
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }

        [Display(Name = "Account")]
        public int SelectedAccountId { get; set; }
        public IEnumerable<SelectListItem> Accounts;
    }
}
