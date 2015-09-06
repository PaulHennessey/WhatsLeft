using WhatsLeft.Domain;

namespace WhatsLeft.Models.RegularPayments
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {}

        public IndexViewModel(RegularPayment regularPayment)
        {
            RegularPaymentId = regularPayment.RegularPaymentId;
            Amount = regularPayment.Amount;
            Name = regularPayment.Name;
            PaymentDay = regularPayment.PaymentDay;
        }


        public int RegularPaymentId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int PaymentDay { get; set; }
    }
}
