using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WhatsLeft.Domain;
using WhatsLeft.Models;
using WhatsLeft.Models.Home;
using WhatsLeft.Repositories;

namespace WhatsLeft.Controllers
{
    public class HomeController : Controller
    {
        private BankAccountRepository bankAccountRepository = new BankAccountRepository();
        private FundsRepository fundRepository = new FundsRepository();
        private UserRepository userRepository = new UserRepository();
        private RegularPaymentsRepository regularPaymentsRepository = new RegularPaymentsRepository();

        
        public ActionResult Index()
        {
            var accounts = bankAccountRepository.GetBankAccounts();            

            var model = accounts.Select(
                a => new WhatsLeft.Models.Home.IndexViewModel
                { 
                    Id = a.BankAccountId,
                    Balance = a.Balance, 
                    Name = a.Name,
                    WhatsLeft = a.Funds.Where(f => f.Name == "What's Left").FirstOrDefault().Balance
                }).ToList();

            return View(model);
        }


        [HttpGet]
        public ViewResult Create()
        {
            CreateViewModel model = new CreateViewModel()
            {
                Name = String.Empty,
                Balance = 0,
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                BankAccount bankAccount = new BankAccount
                {
                    Name = model.Name,
                    Balance = model.Balance
                };

                bankAccountRepository.InsertBankAccount(bankAccount);

                Fund fund = new Fund
                {
                    Name = "What's Left",
                    Balance = bankAccount.Balance,
                    BankAccountId = bankAccount.BankAccountId
                };

                fundRepository.InsertFund(fund);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }


        [HttpGet]
        public ActionResult Edit(int accountId)
        {
            BankAccount bankAccount = bankAccountRepository.GetBankAccountById(accountId);

            EditViewModel model = new EditViewModel(bankAccount);

            return View(model);
        }


        [HttpGet]
        public ViewResult CreateFund(int accountId)
        {
            CreateFundViewModel model = new CreateFundViewModel()
            {
                Name = String.Empty,
                BankAccountId = accountId
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult CreateFund(CreateFundViewModel model)
        {
            if (ModelState.IsValid)
            {
                Fund fund = new Fund
                {
                    Name = model.Name,
                    BankAccountId = model.BankAccountId
                };

                fundRepository.InsertFund(fund);

                return RedirectToAction("Details", new { accountId = model.BankAccountId });
            }
            else
            {
                return View(model);
            }
        }


        [HttpGet]
        public ViewResult CreateRegularPayment(int accountId)
        {
            CreateRegularPaymentViewModel model = new CreateRegularPaymentViewModel()
            {
                Name = String.Empty,
                Amount = 0,
                PaymentDay = 1,
                BankAccountId = accountId
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult CreateRegularPayment(CreateRegularPaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                RegularPayment regularPayment = new RegularPayment
                {
                    Name = model.Name,
                    Amount = model.Amount,
                    PaymentDay = model.PaymentDay,
                    BankAccountId = model.BankAccountId
                };

                regularPaymentsRepository.InsertRegularPayment(regularPayment);

                return RedirectToAction("Details", new { accountId = model.BankAccountId });
            }
            else
            {
                return View(model);
            }
        }


        [HttpGet]
        public ActionResult EditRegularPayment(int accountId, int regularPaymentId)
        {
            RegularPayment regularPayment = regularPaymentsRepository.GetRegularPaymentById(regularPaymentId);

            EditRegularPaymentViewModel model = new EditRegularPaymentViewModel(regularPayment);

            return View(model);
        }


        [HttpPost]
        public ActionResult EditRegularPayment(EditRegularPaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                RegularPayment regularPayment = new RegularPayment
                {
                    RegularPaymentId = model.RegularPaymentId,
                    Name = model.Name,
                    Amount = model.Amount,
                    PaymentDay = model.PaymentDay,
                    BankAccountId = model.BankAccountId
                };

                regularPaymentsRepository.UpdateRegularPayment(regularPayment);

                return RedirectToAction("Details", new { accountId = model.BankAccountId });
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Details(int accountId)
        {
            BankAccount bankAccount = bankAccountRepository.GetBankAccountById(accountId);
            User user = userRepository.GetUsers().FirstOrDefault();

            BankAccountViewModel model = new BankAccountViewModel
            {
                BankAccountId = bankAccount.BankAccountId,
                UserId = user.UserId,
                Name = bankAccount.Name,
                Balance = bankAccount.Balance,
                Funds = bankAccount.Funds.ToList(),
                RegularPayments = bankAccount.RegularPayments.ToList(),
                WhatsLeft = bankAccount.Funds.Where(f => f.Name == "What's Left").FirstOrDefault().Balance,
                NextPayDay = user.NextPayDay                
            };

            return View(model);
        }


        [HttpPost]
        public ActionResult Details(BankAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                BankAccount bankAccount = new BankAccount
                {
                    BankAccountId = model.BankAccountId,
                    Balance = model.Balance,
                    Name = model.Name
                };
                bankAccountRepository.UpdateBankAccount(bankAccount);

                User user = new User
                {
                    UserId = model.UserId,
                    NextPayDay = model.NextPayDay
                };
                userRepository.UpdateUser(user);

                return RedirectToAction("Details", new { accountId = model.BankAccountId });
            }
            else
            {
                return View(model);
            }
        }


        [HttpPost]
        public ActionResult Transfer(BankAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                BankAccount bankAccount = bankAccountRepository.GetBankAccountById(model.BankAccountId);

                Fund fromFund = bankAccount.Funds.Where(f => f.FundId == model.FromFundId).FirstOrDefault();
                Fund toFund = bankAccount.Funds.Where(f => f.FundId == model.ToFundId).FirstOrDefault();

                if (fromFund.Balance >= model.Amount)
                {
                    fromFund.Balance -= model.Amount;
                    toFund.Balance += model.Amount;
                    bankAccountRepository.UpdateBankAccount(bankAccount);
                }

                return RedirectToAction("Details", new { accountId = model.BankAccountId });
            }
            else
            {
                return View(model);
            }
        }


        private int CalculateWhatsLeft(int accountId)
        {
            BankAccount bankAccount = bankAccountRepository.GetBankAccountById(accountId);
            int balance = bankAccount.Balance;
            int fundsTotal = bankAccount.Funds.Where(f => f.Name != "What's Left").Sum(f => f.Balance);
            int regularPaymentsTotal = GetRegularPaymentsTotal(bankAccount.RegularPayments.ToList());

            return balance - regularPaymentsTotal - fundsTotal;
        }


        private int GetRegularPaymentsTotal(List<RegularPayment> regularPayments)
        {
            int regularPaymentsTotal = 0;
            DateTime nextPayDay = userRepository.GetUsers().FirstOrDefault().NextPayDay;

            foreach (var payment in regularPayments)
            {
                DateTime nextPaymentDate = GetNextPaymentDate(payment.PaymentDay);
                if (nextPaymentDate > DateTime.Today && 
                    nextPaymentDate < nextPayDay)
                {
                    regularPaymentsTotal += payment.Amount;
                }
            }

            return regularPaymentsTotal;
        }


        /// <summary>
        /// Note we're assuming that if the paymentDay is 31, and we're in April, it'll go out on the
        /// 30th.
        /// </summary>
        /// <param name="paymentDay"></param>
        /// <returns></returns>
        private DateTime GetNextPaymentDate(int paymentDay)
        {
            DateTime nextPaymentDate = new DateTime();

            try
            {
                nextPaymentDate = new DateTime(
                    DateTime.Today.Year,
                    DateTime.Today.Month,
                    paymentDay);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                nextPaymentDate = new DateTime(
                    DateTime.Today.Year,
                    DateTime.Today.Month,
                    DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            }

            if (nextPaymentDate < DateTime.Today)
            {
                nextPaymentDate = nextPaymentDate.AddMonths(1);
            }

            return nextPaymentDate;
        }


        public ActionResult Delete(int accountId)
        {
            bankAccountRepository.DeleteAccount(accountId);

            return RedirectToAction("Index");
        }


        public ActionResult DeleteFund(int accountId, int fundId)
        {
            fundRepository.DeleteFund(fundId);

            return RedirectToAction("Details", new { accountId = accountId });
        }


        public ActionResult DeleteRegularPayment(int accountId, int regularPaymentId)
        {
            regularPaymentsRepository.DeleteRegularPayment(regularPaymentId);

            return RedirectToAction("Details", new { accountId = accountId });
        }

    }
}