using System.Collections.Generic;
using System.Linq;
using WhatsLeft.Data;
using WhatsLeft.Domain;

namespace WhatsLeft.Repositories
{
    public class RegularPaymentsRepository
    {
        readonly WhatsLeftContext context = new WhatsLeftContext();


        public List<RegularPayment> GetRegularPayments()
        {
            return context.RegularPayments.ToList();
        }


        public RegularPayment GetRegularPaymentById(int id)
        {
            return context.RegularPayments.Where(f => f.RegularPaymentId == id).FirstOrDefault();
        }


        public void InsertRegularPayment(RegularPayment regularPayment)
        {
            context.RegularPayments.Add(regularPayment);
            context.SaveChanges();
        }


        public void UpdateRegularPayment(RegularPayment newRegularPayment)
        {
            RegularPayment regularPayment = context.RegularPayments.Where(f => f.RegularPaymentId == newRegularPayment.RegularPaymentId).FirstOrDefault();
            regularPayment.Name = newRegularPayment.Name;
            regularPayment.Amount = newRegularPayment.Amount;
            regularPayment.PaymentDay = newRegularPayment.PaymentDay;
            context.SaveChanges();
        }


        public void DeleteRegularPayment(int regularPaymentId)
        {
            RegularPayment regularPayment = context.RegularPayments.Where(f => f.RegularPaymentId == regularPaymentId).FirstOrDefault();
            context.RegularPayments.Remove(regularPayment);
            context.SaveChanges();
        }

    }
}
