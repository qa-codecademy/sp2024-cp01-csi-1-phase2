using AutoMapper;
using FenixCoin.DataAccess.Repositories;
using FenixCoin.Domain.Models;
using FenixCoin.Dto.TradeDTO;
using FenixCoin.Dto.WalletDTO;
using FenixCoin.Services.Interfaces;

namespace FenixCoin.Services.Implementation
{
    public class TradeService : ITradeService
    {
        private readonly IRepository<Trade> _tradeRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public TradeService(IRepository<Trade> tradeRepository, IMapper mapper, IUserRepository userRepository)
        {
            _tradeRepository = tradeRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public Task AddTrade(AddTradeDto addTradeDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<TradeDto>> GetAllTrades()
        {
            throw new NotImplementedException();
        }

        public Task GetTradeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task TradeBetweenWallets(WalletDto senderWalletDto, WalletDto receiverWalletDto)
        {
            throw new NotImplementedException();
        }
    }
}
