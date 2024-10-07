using FenixCoin.DataAccess.Context;
using FenixCoin.DataAccess.Repositories;
using FenixCoin.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FenixCoin.DataAccess.Implementation
{
    public class TradeRepository : IRepository<Trade>
    {
        private readonly FenixDbContext _context;

        public TradeRepository(FenixDbContext context)
        {
            _context = context;
        }
        public async Task Add(Trade entity)
        {
            _context.Trades.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Trade entity)
        {
            _context.Trades.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Trade>> GetAll()
        {
            return await _context.Trades.ToListAsync();
        }

        public async Task<Trade> GetById(int id)
        {
            return await _context.Trades.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Trade entity)
        {
            _context.Trades.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
