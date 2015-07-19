using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsLeft.Data;
using WhatsLeft.Domain;

namespace WhatsLeft.Repositories
{
    public class WhatsLeftRepository
    {
        readonly WhatsLeftContext context = new WhatsLeftContext();

        public void DeleteFund(int fundId)
        {
            Fund fund = context.Funds.Where(f => f.FundId == fundId).FirstOrDefault();
            context.Funds.Remove(fund);
            context.SaveChanges();
        }

        public void DeleteAccount(int accountId)
        {
            BankAccount account = context.Accounts.Where(a => a.BankAccountId == accountId).FirstOrDefault();
            context.Accounts.Remove(account);
            context.SaveChanges();
        }

        public void InsertBankAccount(BankAccount bankAccount)
        {
            context.Accounts.Add(bankAccount);
            context.SaveChanges();
        }

        public void UpdateBankAccount(BankAccount bankAccount)
        {
            BankAccount account = context.Accounts.Where(b => b.BankAccountId == bankAccount.BankAccountId).FirstOrDefault();
            account.Name = bankAccount.Name;
            account.Balance = bankAccount.Balance;
            account.Funds = bankAccount.Funds;
            context.SaveChanges();
        }

        public void InsertFund(Fund fund)
        {
            context.Funds.Add(fund);
            context.SaveChanges();
        }

        public List<BankAccount> GetBankAccounts()
        {
            return context.Accounts.ToList();
        }

        public BankAccount GetBankAccountById(int id)
        {
            return context.Accounts.Where(a => a.BankAccountId == id).FirstOrDefault();
        }
    }
}
