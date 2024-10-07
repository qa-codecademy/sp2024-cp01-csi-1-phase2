using FenixCoin.DataAccess.Context;
using FenixCoin.DataAccess.Repositories;
using FenixCoin.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FenixCoin.DataAccess.Implementation
{
    public class CryptoWalletRepository : IRepository<CryptoWallet>
    {

        private readonly FenixDbContext _context;

        public CryptoWalletRepository(FenixDbContext context)
        {
            _context = context;
        }
        public async Task Add(CryptoWallet entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(CryptoWallet entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CryptoWallet>> GetAll()
        {
            return await _context.CryptoWallets.ToListAsync();
        }

        public async Task<CryptoWallet> GetById(int id)
        {
            return await _context.CryptoWallets.Include(x => x.Wallet).Include(x => x.Crypto).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(CryptoWallet entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
