using System.Collections.Generic;
using System.Linq;
using WhatsLeft.Data;
using WhatsLeft.Domain;

namespace WhatsLeft.Repositories
{
    public class FundsRepository
    {
        readonly WhatsLeftContext context = new WhatsLeftContext();


        public List<Fund> GetFunds()
        {
            return context.Funds.ToList();
        }


        public Fund GetFundById(int id)
        {
            return context.Funds.Where(f => f.FundId == id).FirstOrDefault();
        }


        public void InsertFund(Fund fund)
        {
            context.Funds.Add(fund);
            context.SaveChanges();
        }


        public void UpdateFund(Fund newFund)
        {
            Fund fund = context.Funds.Where(f => f.FundId == newFund.FundId).FirstOrDefault();
            fund.Name = newFund.Name;
            fund.Balance = newFund.Balance;
            context.SaveChanges();
        }


        public void DeleteFund(int fundId)
        {
            Fund fund = context.Funds.Where(f => f.FundId == fundId).FirstOrDefault();
            context.Funds.Remove(fund);
            context.SaveChanges();
        }

    }
}
