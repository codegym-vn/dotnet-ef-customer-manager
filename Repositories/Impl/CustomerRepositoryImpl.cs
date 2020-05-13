using MvcCustomerManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


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
            var s = from c in context.Customers.Include(c => c.Province) select c;
            return await s.ToListAsync();

        }

        public async Task<Customer> GetSingleCustomerIncludeProvince(int id)
        {
            return await context.Customers.Where(c => c.Id == id)
                    .Include(c => c.Province)
                    .AsNoTracking().SingleAsync();
        }
    }
}
