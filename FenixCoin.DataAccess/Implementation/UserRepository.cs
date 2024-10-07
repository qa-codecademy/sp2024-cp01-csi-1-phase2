using FenixCoin.DataAccess.Context;
using FenixCoin.DataAccess.Repositories;
using FenixCoin.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FenixCoin.DataAccess.Implementation
{
    public class UserRepository : IUserRepository
    {

        private readonly FenixDbContext _context;

        public UserRepository(FenixDbContext context)
        {
            _context = context;
        }
        public async Task Add(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User entity)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Include(x => x.Wallet).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<User> LoginUser(string username, string hashPassword)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == hashPassword);
        }

        public async Task Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
