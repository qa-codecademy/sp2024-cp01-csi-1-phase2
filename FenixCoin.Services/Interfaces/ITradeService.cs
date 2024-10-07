using FenixCoin.Dto.TradeDTO;
using FenixCoin.Dto.WalletDTO;

namespace FenixCoin.Services.Interfaces
{
    public interface ITradeService
    {
        Task AddTrade(AddTradeDto addTradeDto);
        Task<List<TradeDto>> GetAllTrades();
        Task TradeBetweenWallets(WalletDto senderWalletDto, WalletDto receiverWalletDto);
        Task GetTradeById(int id);
    }
}
