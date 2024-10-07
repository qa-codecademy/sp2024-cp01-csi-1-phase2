namespace FenixCoin.Shared.TradeExceptions
{
    public class TradeNotFoundException : Exception
    {
        public TradeNotFoundException(string message) : base(message) { }
    }
}
