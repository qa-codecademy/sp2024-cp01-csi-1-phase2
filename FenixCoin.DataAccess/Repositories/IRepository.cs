using FenixCoin.Domain.Models;

namespace FenixCoin.DataAccess.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        // CRUD Operations

        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);

    }
}
