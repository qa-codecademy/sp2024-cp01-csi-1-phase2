using FenixCoin.Domain.Enums;

namespace FenixCoin.Domain.Models
{
    public class Trade : BaseEntity
    {
        public TradeType TradeType { get; set; }
        public TradeRole TradeRole { get; set; }
        public decimal? AmountTradedInUSD { get; set; }
        public decimal? AmountTradedInCryptos { get; set; }
        public DateTime TimeOfTrade { get; set; }

        // Foreign properties

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
