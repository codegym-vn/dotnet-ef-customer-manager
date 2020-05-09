using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcCustomerManager.Models;
using MvcCustomerManager.Repositories.Impl;
using MvcCustomerManager.Services;
using System.Threading.Tasks;

namespace MvcCustomerManager.Controllers
{
    public class CustomerController : GeneralController<Customer, ICustomerService>
    {

        public CustomerController(ICustomerService service) : base(service)
        {

        }

        /*private IProvinceRepository provinceRepositoryImpl;
        public CustomerController(ICustomerRepository repository, [FromServices] IProvinceRepository provinceRepositoryImpl) 
            : base(repository)
        {
            this.provinceRepositoryImpl = provinceRepositoryImpl;
        }

        [HttpGet()]
        public override IActionResult Create()
        {
            var lst = provinceRepositoryImpl.GetAll();
            ViewBag.Provinces = lst;
            return View();
        }*/
    }
}