using AutoMapper;
using FenixCoin.Domain.Models;
using FenixCoin.Dto.CryptoDTO;
using FenixCoin.Dto.CryptoWalletDTO;
using FenixCoin.Dto.TradeDTO;
using FenixCoin.Dto.UserDTO;
using FenixCoin.Dto.WalletDTO;

namespace FenixCoin.Mappers
{
    public class FenixMapper : Profile
    {


        public FenixMapper()
        {
            // User Mapping

            CreateMap<User, LoginUserDto>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();

            // Crypto Mapping

            CreateMap<Crypto, CryptoDto>().ReverseMap();
            CreateMap<Crypto, AddCryptoDto>().ReverseMap();
            CreateMap<Crypto, UpdateCryptoDto>().ReverseMap();

            // Wallet Mapping

            CreateMap<Wallet, WalletDto>().ReverseMap();
            CreateMap<Wallet, UpdateWalletDto>().ReverseMap();

            // Trade Mapping

            CreateMap<Trade, TradeDto>().ReverseMap();
            CreateMap<Trade, AddTradeDto>().ReverseMap();

            // CryptoWallet Mapping

            CreateMap<CryptoWallet, CryptoWalletDto>().ReverseMap();
            CreateMap<CryptoWallet, UpdateCryptoWalletDto>().ReverseMap();
        }


    }
}
