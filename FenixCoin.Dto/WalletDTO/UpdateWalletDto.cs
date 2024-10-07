using FenixCoin.Dto.CryptoWalletDTO;

namespace FenixCoin.Dto.WalletDTO
{
    public class UpdateWalletDto
    {
        public int Id { get; set; }
        List<CryptoWalletDto> CryptosInWallet { get; set; }
        public int UserId { get; set; }
    }
}
