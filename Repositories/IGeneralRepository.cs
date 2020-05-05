using System.Threading.Tasks;
using System.Collections.Generic;

namespace MvcCustomerManager.Repositories
{
    public interface IGeneralRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Get(int id);
        Task<T> Delete(int id);
    }

}