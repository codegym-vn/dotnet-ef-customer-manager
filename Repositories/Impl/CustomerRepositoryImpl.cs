using MvcCustomerManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MvcCustomerManager.Repositories.Impl
{
    public class CustomerRepositoryImpl : GeneralRepositoryImpl<Customer, DataContext>, ICustomerRepository
    {
        private readonly DataContext context;
        public CustomerRepositoryImpl(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Customer>> GetCustomersIncludeProvince()
        {
            return await context.Customers
                    .Include(c => c.Province)
                    .AsNoTracking().ToListAsync();
        }
    }
}
