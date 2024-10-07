using FenixCoin.DataAccess.Context;
using FenixCoin.DataAccess.Repositories;
using FenixCoin.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FenixCoin.DataAccess.Implementation
{
    public class CryptoRepository : IRepository<Crypto>
    {
        private readonly FenixDbContext _context;

        public CryptoRepository(FenixDbContext context)
        {
            _context = context;
        }
        public async Task Add(Crypto entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Crypto entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Crypto>> GetAll()
        {
            return await _context.Cryptos.ToListAsync();
        }

        public async Task<Crypto> GetById(int id)
        {
            return await _context.Cryptos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Crypto entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
