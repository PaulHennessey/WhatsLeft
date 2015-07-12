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

        //public void InsertAccountAndSave(ref Account account)
        //{
        //    context.Accounts.Add(account);
        //    context.SaveChanges();
        //}

        //public List<Account> GetAccounts()
        //{
        //    return context.Accounts.ToList();
        //}

        public List<BankAccount> GetAccounts()
        {
            List<BankAccount> accounts = new List<BankAccount>();

            accounts.Add(new BankAccount
                {
                    Id = 1,
                    Name = "PaulCurrent",
                    Balance = 1000,
                    Funds = new List<Fund>
                    {
                        new Fund
                        {
                            Id = 1,
                            Name = "What's left?",
                            Balance = 300
                        },
                        new Fund
                        {
                            Id = 2,
                            Name = "Holiday",
                            Balance = 200
                        },
                        new Fund
                        {
                            Id = 3,
                            Name = "Bike",
                            Balance = 500
                        }
                    }
                });

            //accounts.Add(new Account
            //{
            //    Id = 2,
            //    Name = "FretwireCurrent",
            //    Balance = 10000,
            //    Funds = new List<Fund>
            //        {
            //            new Fund
            //            {
            //                Id = 1,
            //                Name = "What's left?",
            //                Balance = 3000
            //            },
            //            new Fund
            //            {
            //                Id = 2,
            //                Name = "Tax",
            //                Balance = 2000
            //            },
            //            new Fund
            //            {
            //                Id = 3,
            //                Name = "Emergencies",
            //                Balance = 5000
            //            }
            //        }
            //});

            return accounts;
        }

        public BankAccount GetAccountById(int id)
        {
            return new BankAccount
            {
                Id = 1,
                Name = "PaulCurrent",
                Balance = 1000,
                Funds = new List<Fund>
                    {
                        new Fund
                        {
                            Id = 1,
                            Name = "What's left?",
                            Balance = 300
                        },
                        new Fund
                        {
                            Id = 2,
                            Name = "Holiday",
                            Balance = 200
                        },
                        new Fund
                        {
                            Id = 3,
                            Name = "Bike",
                            Balance = 500
                        }
                    }
            };
        }

        //public Account GetAccountById(int id)
        //{
        //    return context.Accounts.Find(id);
        //}

        //public void UpdateAccountAndSave(ref Account account)
        //{
        //    int i = account.Id;
        //    var acc = context.Accounts.FirstOrDefault(a => a.Id == i);
        //    acc.Name = account.Name;
        //    acc.VirtualAccounts = account.VirtualAccounts;

        //    context.SaveChanges();
        //}

    }
}
