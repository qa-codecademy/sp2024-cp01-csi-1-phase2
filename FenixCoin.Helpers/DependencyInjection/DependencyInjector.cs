using FenixCoin.DataAccess.Implementation;
using FenixCoin.DataAccess.Repositories;
using FenixCoin.Domain.Models;
using FenixCoin.Services.Implementation;
using FenixCoin.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FenixCoin.Helpers.DependencyInjection
{
    public static class DependencyInjector
    {
        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRepository<Crypto>, CryptoRepository>();
            services.AddTransient<IRepository<Wallet>, WalletRepository>();
            services.AddTransient<IRepository<Trade>, TradeRepository>();
            services.AddTransient<IRepository<CryptoWallet>, CryptoWalletRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICryptoService, CryptoService>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<ITradeService, TradeService>();
        }
    }
}
