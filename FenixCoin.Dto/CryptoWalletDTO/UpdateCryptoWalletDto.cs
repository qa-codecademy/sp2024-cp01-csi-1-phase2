namespace FenixCoin.Dto.CryptoWalletDTO
{
    public class UpdateCryptoWalletDto
    {
        public int Id { get; set; }
        public decimal? Amount { get; set; }
        public int CryptoId { get; set; }
        public int WalletId { get; set; }
    }
}
