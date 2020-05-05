using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcCustomerManager.Models;
using MvcCustomerManager.Repositories.Impl;

namespace MvcCustomerManager.Controllers
{
    public class CustomerController : GeneralController<Customer, CustomerRepositoryImpl>
    {
        public CustomerController(CustomerRepositoryImpl repository) : base(repository)
        {

        }
    }
}