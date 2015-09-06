using System.Collections.Generic;
using System.Linq;
using WhatsLeft.Data;
using WhatsLeft.Domain;

namespace WhatsLeft.Repositories
{
    public class UserRepository
    {
        readonly WhatsLeftContext context = new WhatsLeftContext();

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }

        //public BankAccount GetBankAccountById(int id)
        //{
        //    return context.Accounts.Where(a => a.BankAccountId == id).FirstOrDefault();
        //}

        //public void DeleteAccount(int accountId)
        //{
        //    BankAccount account = context.Accounts.Where(a => a.BankAccountId == accountId).FirstOrDefault();
        //    context.Accounts.Remove(account);
        //    context.SaveChanges();
        //}

        //public void InsertBankAccount(BankAccount bankAccount)
        //{
        //    context.Accounts.Add(bankAccount);
        //    context.SaveChanges();
        //}

        public void UpdateUser(User newUser)
        {
            User user = context.Users.Where(u => u.UserId == newUser.UserId).FirstOrDefault();
            user.NextPayDay = newUser.NextPayDay;
            context.SaveChanges();
        }
    }
}
