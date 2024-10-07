using FenixCoin.Dto.CryptoWalletDTO;
using FenixCoin.Dto.UserDTO;

namespace FenixCoin.Dto.WalletDTO
{
    public class WalletDto
    {
        public int Id { get; set; }
        public decimal WalletBalanceInUSD { get; set; }
        public List<CryptoWalletDto>? CryptosInWallet { get; set; } = new List<CryptoWalletDto>();
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}
