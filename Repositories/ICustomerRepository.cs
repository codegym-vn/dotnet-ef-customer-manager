using System.Threading.Tasks;
using System.Collections.Generic;
using MvcCustomerManager.Models;

namespace MvcCustomerManager.Repositories
{
    public interface ICustomerRepository : IGeneralRepository<Customer>
    {
         Task<List<Customer>> GetCustomersIncludeProvince();

    }

}