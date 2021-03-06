using MvcCustomerManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MvcCustomerManager.Repositories.Impl
{
    public class CustomerRepositoryImpl : GeneralRepositoryImpl<Customer, DataContext>, ICustomerRepository
    {
        public CustomerRepositoryImpl(DataContext context) : base(context)
        {

        }
    }
}
