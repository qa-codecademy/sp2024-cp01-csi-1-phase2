namespace FenixCoin.Domain.Models
{
    public class Crypto : BaseEntity
    {
        public string CryptoName { get; set; }
        public decimal CryptoValueInUSD { get; set; }
        public string ShortName { get; set; }

    }
}
