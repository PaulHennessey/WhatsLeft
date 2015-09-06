using WhatsLeft.Domain;

namespace WhatsLeft.Models.Funds
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {}

        public IndexViewModel(Fund fund)
        {
            Id = fund.FundId;
            Name = fund.Name;
            Balance = fund.Balance;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
    }
}
