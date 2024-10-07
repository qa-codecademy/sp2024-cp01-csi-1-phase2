namespace FenixCoin.Shared.WalletExceptions
{
    public class WalletNotFoundException : Exception
    {
        public WalletNotFoundException(string message) : base(message) { }
    }
}
