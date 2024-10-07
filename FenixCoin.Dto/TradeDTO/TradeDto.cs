using FenixCoin.Domain.Enums;

namespace FenixCoin.Dto.TradeDTO
{
    public class TradeDto
    {
        public int Id { get; set; }
        public TradeType TradeType { get; set; }
        public TradeRole TradeRole { get; set; }
        public decimal? AmountTradedInUSD { get; set; }
        public decimal? AmountTradedInCryptos { get; set; }
        public DateTime TimeOfTrade { get; set; }
        public int UserId { get; set; }
    }
}
