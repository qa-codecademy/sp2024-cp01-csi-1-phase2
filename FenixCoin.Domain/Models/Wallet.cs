namespace FenixCoin.Domain.Models
{
    public class Wallet : BaseEntity
    {
        public decimal WalletBalanceInUSD { get; set; }
        public virtual List<CryptoWallet>? CryptosInWallet { get; set; } = new List<CryptoWallet>();


        // Foreign properties
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Wallet()
        {
            WalletBalanceInUSD = 100000.00M;
        }
    }
}
