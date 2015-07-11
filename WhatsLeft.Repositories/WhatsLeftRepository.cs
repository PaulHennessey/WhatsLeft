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

        public void InsertAccountAndSave(ref Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();
        }

        public List<Account> GetAccounts()
        {
            return context.Accounts.ToList();
        }

        public Account GetAccountById(int id)
        {
            return context.Accounts.Find(id);
        }

        public void UpdateAccountAndSave(ref Account account)
        {
            int i = account.Id;
            var acc = context.Accounts.FirstOrDefault(a => a.Id == i);
            acc.Name = account.Name;
            acc.VirtualAccounts = account.VirtualAccounts;

            context.SaveChanges();
        }

    }
}
