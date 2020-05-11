using MvcCustomerManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MvcCustomerManager.Repositories;
using System.Collections.Generic;

namespace MvcCustomerManager.Services.Impl
{
    public class CustomerServiceImpl : GeneralServiceImpl<Customer, ICustomerRepository>, ICustomerService
    {
        private ICustomerRepository repository;
        public CustomerServiceImpl(ICustomerRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<List<Customer>> GetCustomersIncludeProvince()
        {
            return await repository.GetCustomersIncludeProvince();
        }
    }
}
