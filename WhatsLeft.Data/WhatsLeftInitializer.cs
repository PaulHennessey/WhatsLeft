using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsLeft.Domain;

namespace WhatsLeft.Data
{
    public class WhatsLeftInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WhatsLeftContext>
    {
        protected override void Seed(WhatsLeftContext context)
        {
            var accounts = new List<BankAccount>
            {
                new BankAccount{Name = "PaulCurrent", Balance = 1000},
                new BankAccount{Name = "FretwireCurrent", Balance = 10000}
            };

            accounts.ForEach(s => context.Accounts.Add(s));
            context.SaveChanges();

            var funds = new List<Fund>
            {
                new Fund{Name = "What's left?", Balance = 300, BankAccountId = 1},
                new Fund{Name = "Holiday", Balance = 200, BankAccountId = 1},
                new Fund{Name = "Bike", Balance = 500, BankAccountId = 1},
                new Fund{Name = "What's left?", Balance = 3000, BankAccountId = 2},
                new Fund{Name = "Tax", Balance = 2000, BankAccountId = 2},
                new Fund{Name = "Emergencies", Balance = 5000, BankAccountId = 2}
            };

            funds.ForEach(s => context.Funds.Add(s));
            context.SaveChanges();
        }
    }
}
