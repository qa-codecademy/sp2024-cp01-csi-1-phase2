using AutoMapper;
using FenixCoin.DataAccess.Repositories;
using FenixCoin.Domain.Models;
using FenixCoin.Dto.WalletDTO;
using FenixCoin.Services.Interfaces;

namespace FenixCoin.Services.Implementation
{
    public class WalletService : IWalletService
    {
        private readonly IRepository<Wallet> _walletRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public WalletService(IRepository<Wallet> walletRepository, IUserRepository userRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<WalletDto> AddFundsToWallet(int id, decimal amount)
        {
            var userDb = await _userRepository.GetById(id);
            if (userDb == null)
            {
                throw new NotImplementedException();
            }
            var wallet = await _walletRepository.GetById(id);
            if (wallet == null) { throw new NotImplementedException(); }
            if (wallet.Id != id) { throw new NotImplementedException(); }

            decimal AmountToAdd = amount;
            wallet.WalletBalanceInUSD += AmountToAdd;
            await _walletRepository.Update(wallet);
            var walletDto = _mapper.Map<WalletDto>(wallet);
            return walletDto;

        }

        public async Task<WalletDto> GetWalletById(int id)
        {
            var wallet = await _walletRepository.GetById(id);
            if (wallet == null) { throw new NotImplementedException(); }
            var walletDto = _mapper.Map<WalletDto>(wallet);
            return walletDto;
        }

        public async Task<List<WalletDto>> GetWallets()
        {
            var wallets = await _walletRepository.GetAll();
            var walletDtos = _mapper.Map<List<WalletDto>>(wallets);
            return walletDtos;
        }
    }
}
