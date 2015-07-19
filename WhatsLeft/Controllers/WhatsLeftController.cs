using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WhatsLeft.Domain;
using WhatsLeft.Models;
using WhatsLeft.Repositories;

namespace WhatsLeft.Controllers
{
    public class WhatsLeftController : Controller
    {
        private WhatsLeftRepository repo = new WhatsLeftRepository();

        // GET: WhatsLeft
        public ActionResult Index()
        {
            BankAccountsViewModel bankAccountsViewModel = new BankAccountsViewModel();

            //model.BankAccounts = repo.GetBankAccounts();
            var accounts = repo.GetBankAccounts();
            foreach (var account in accounts)
            {
                BankAccountViewModel model = new BankAccountViewModel
                {
                    Id = account.BankAccountId,
                    Name = account.Name,
                    Balance = account.Balance,
                    Funds = account.Funds
                };

                bankAccountsViewModel.BankAccounts.Add(model);
            }

            return View(bankAccountsViewModel);
        }


        [HttpGet]
        public ViewResult CreateAccount()
        {
            BankAccountViewModel model = new BankAccountViewModel()
            {
                Name = String.Empty,
                Balance = 0,
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult CreateAccount(BankAccountViewModel bankAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                // Maybe use mapper here like this
                // Product product = Mapper.Map<ProductViewModel, Product>(productViewModel);

                BankAccount bankAccount = new BankAccount
                {
                    Name = bankAccountViewModel.Name,
                    Balance = bankAccountViewModel.Balance,
                    Funds = new List<Fund>()
                };

                // Note that EF automatically updates the object with the new ID after db insert.
                repo.InsertBankAccount(bankAccount);

                Fund whatsleft = new Fund
                {
                    Name = "What's Left",
                    Balance = bankAccountViewModel.Balance,
                    BankAccountId = bankAccount.BankAccountId
                };

                bankAccount.Funds.Add(whatsleft);
                repo.UpdateBankAccount(bankAccount);

                return RedirectToAction("Index");
            }
            else
            {
                return View(bankAccountViewModel);
            }
        }


        [HttpGet]
        public ViewResult CreateFund(int id)
        {
            FundViewModel model = new FundViewModel()
            {
                Name = String.Empty,
                Balance = 0,
                BankAccountId = id
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult CreateFund(FundViewModel fundViewModel)
        {
            if (ModelState.IsValid)
            {
                // Maybe use mapper here like this
                // Product product = Mapper.Map<ProductViewModel, Product>(productViewModel);

                Fund fund = new Fund
                {
                    Name = fundViewModel.Name,
                    //Balance = fundViewModel.Balance,
                    BankAccountId = fundViewModel.BankAccountId
                };

                repo.InsertFund(fund);

                return RedirectToAction("Edit", new {accountId = fundViewModel.BankAccountId});
            }
            else
            {
                return View(fundViewModel);
            }
        }


        [HttpPost]
        public ActionResult Transfer(BankAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Maybe use mapper here like this
                // Product product = Mapper.Map<ProductViewModel, Product>(productViewModel);

                BankAccount bankAccount = repo.GetBankAccountById(model.Id);

                Fund fromFund = bankAccount.Funds.Where(f => f.FundId == model.FromFundId).FirstOrDefault();
                Fund toFund = bankAccount.Funds.Where(f => f.FundId == model.ToFundId).FirstOrDefault();

                if (fromFund.Balance >= model.Amount)
                {
                    fromFund.Balance -= model.Amount;
                    toFund.Balance += model.Amount;
                    repo.UpdateBankAccount(bankAccount);
                }

                return RedirectToAction("Edit", new { accountId = model.Id });
            }
            else
            {
                return View(model);
            }
        }


        public ActionResult Update(int bankAccountId, int balance)
        {
            BankAccount bankAccount = repo.GetBankAccountById(bankAccountId);
            bankAccount.Balance = balance;

            int fundsTotal = bankAccount.Funds.Where(f => f.Name != "What's Left").Sum(f => f.Balance);

            Fund whatsleft = bankAccount.Funds.Where(f => f.Name == "What's Left").FirstOrDefault();
            whatsleft.Balance = balance - fundsTotal;

            repo.UpdateBankAccount(bankAccount);

            return RedirectToAction("Edit", new { accountId = bankAccountId });
        }


        public ActionResult Edit(int accountId)
        {
            BankAccount bankAccount = repo.GetBankAccountById(accountId);

            BankAccountViewModel model = new BankAccountViewModel
            {
                Id = bankAccount.BankAccountId,
                Name = bankAccount.Name,
                Balance = bankAccount.Balance,
                Funds = bankAccount.Funds
            };

            return View(model);
        }


        public ActionResult DeleteAccount(int accountId)
        {
            repo.DeleteAccount(accountId);

            return RedirectToAction("Index");
        }


        public ActionResult DeleteFund(int accountId, int fundId)
        {
            repo.DeleteFund(fundId);

            return RedirectToAction("Edit", new { accountId = accountId });
        }

    }
}