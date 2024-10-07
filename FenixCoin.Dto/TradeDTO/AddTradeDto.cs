using FenixCoin.Domain.Enums;

namespace FenixCoin.Dto.TradeDTO
{
    public class AddTradeDto
    {
        public TradeType TradeType { get; set; }
        public TradeRole TradeRole { get; set; }
        public decimal? AmountTradedInUSD { get; set; }
        public decimal? AmountTradedInCryptos { get; set; }
        public DateTime TimeOfTrade { get; set; }
        
    }
}
