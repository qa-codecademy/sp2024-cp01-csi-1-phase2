using FenixCoin.Dto.WalletDTO;

namespace FenixCoin.Services.Interfaces
{
    public interface IWalletService
    {
        Task<List<WalletDto>> GetWallets();
        Task<WalletDto> GetWalletById(int id);
        Task<WalletDto> AddFundsToWallet(int id, decimal amount);
    }
}
