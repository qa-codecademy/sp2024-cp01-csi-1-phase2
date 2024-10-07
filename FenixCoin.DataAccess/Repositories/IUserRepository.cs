using FenixCoin.Domain.Models;

namespace FenixCoin.DataAccess.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> LoginUser(string username, string hashPassword);
        Task<User> GetByUsername(string username);
        Task<User> GetByEmail(string email);
    }
}
