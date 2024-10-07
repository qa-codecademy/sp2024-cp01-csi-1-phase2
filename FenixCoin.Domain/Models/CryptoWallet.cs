namespace FenixCoin.Domain.Models
{
    public class CryptoWallet : BaseEntity
    {
        public int WalletId { get; set; }
        public int CryptoId { get; set; }
        public decimal Amount { get; set; }

        public virtual Wallet Wallet { get; set; }
        public virtual Crypto Crypto { get; set; }
    }
}
