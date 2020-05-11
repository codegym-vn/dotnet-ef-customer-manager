using System.Threading.Tasks;
using System.Collections.Generic;
using MvcCustomerManager.Models;

namespace MvcCustomerManager.Services
{
    public interface ICustomerService : IGeneralService<Customer>
    {
        Task<List<Customer>> GetCustomersIncludeProvince();
        Task<Customer> GetSingleCustomerIncludeProvince(int id);
    }

}