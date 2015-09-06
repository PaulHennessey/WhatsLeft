using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsLeft.Domain;

namespace WhatsLeft.Data
{
    public class WhatsLeftInitializer : System.Data.Entity.DropCreateDatabaseAlways<WhatsLeftContext>
    {
        protected override void Seed(WhatsLeftContext context)
        {
            var users = new List<User>
            {
                new User{NextPayDay = new DateTime(2015, 9, 10)}
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var accounts = new List<BankAccount>
            {
                new BankAccount{Name = "PaulCurrent", Balance = 1000},
                new BankAccount{Name = "FretwireCurrent", Balance = 10000}
            };

            accounts.ForEach(s => context.Accounts.Add(s));
            context.SaveChanges();

            var funds = new List<Fund>
            {
                new Fund{Name = "What's Left", Balance = 300, BankAccountId = 1},
                new Fund{Name = "Holiday", Balance = 200, BankAccountId = 1},
                new Fund{Name = "Bike", Balance = 500, BankAccountId = 1},       
                new Fund{Name = "What's Left", Balance = 3000, BankAccountId = 2},      
                new Fund{Name = "Tax", Balance = 2000, BankAccountId = 2},
                new Fund{Name = "Emergencies", Balance = 5000, BankAccountId = 2}
            };

            funds.ForEach(s => context.Funds.Add(s));
            context.SaveChanges();

            var regularPayments = new List<RegularPayment>
            {
                new RegularPayment { Name = "Mortgage", Amount = 400, PaymentDay = 1, BankAccountId = 1},
                new RegularPayment { Name = "Council Tax", Amount = 100, PaymentDay = 10, BankAccountId = 1},
                new RegularPayment { Name = "Gym", Amount = 40, PaymentDay = 20, BankAccountId = 2}
            };

            regularPayments.ForEach(s => context.RegularPayments.Add(s));
            context.SaveChanges();
        }
    }
}
