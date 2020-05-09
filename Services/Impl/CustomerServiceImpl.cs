using MvcCustomerManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MvcCustomerManager.Repositories;

namespace MvcCustomerManager.Services.Impl
{
    public class CustomerServiceImpl : GeneralServiceImpl<Customer, ICustomerRepository>, ICustomerService
    {
        public CustomerServiceImpl(ICustomerRepository repository) : base(repository)
        {

        }
    }
}
