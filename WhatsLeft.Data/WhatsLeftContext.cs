﻿using System.Data.Entity;
using WhatsLeft.Domain;

namespace WhatsLeft.Data
{
    public class WhatsLeftContext : DbContext
    {
        public WhatsLeftContext() : base("WhatsLeft")
        {}

        public DbSet<BankAccount> Accounts { get; set; }
        public DbSet<Fund> Funds { get; set; }
    }
}
