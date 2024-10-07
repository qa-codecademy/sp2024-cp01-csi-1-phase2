using FenixCoin.DataAccess.Context;
using FenixCoin.DataAccess.Repositories;
using FenixCoin.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FenixCoin.DataAccess.Implementation
{
    public class WalletRepository : IRepository<Wallet>
    {
        private readonly FenixDbContext _context;

        public WalletRepository(FenixDbContext context)
        {
            _context = context;
        }
        public async Task Add(Wallet entity)
        {
            _context.Wallets.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Wallet entity)
        {
            _context.Wallets.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Wallet>> GetAll()
        {
            return await _context.Wallets.ToListAsync();
        }

        public async Task<Wallet> GetById(int id)
        {
            return await _context.Wallets.Include(x => x.CryptosInWallet).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Wallet entity)
        {
            _context.Wallets.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
