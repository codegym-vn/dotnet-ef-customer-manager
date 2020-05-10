using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcCustomerManager.Models;
using MvcCustomerManager.Repositories.Impl;
using MvcCustomerManager.Services;
using System.Threading.Tasks;
using MvcCustomerManager.Repositories;

namespace MvcCustomerManager.Controllers
{
    public class CustomerController : GeneralController<Customer, ICustomerService>
    {

        /*public CustomerController(ICustomerService service) : base(service)
        {

        }*/

        private IProvinceService provinceServiceImpl;
        public CustomerController(ICustomerService service, [FromServices] IProvinceService provinceServiceImpl) 
            : base(service)
        {
            this.provinceServiceImpl = provinceServiceImpl;
        }

        [HttpGet()]
        public override async Task<IActionResult> Create()
        {
          
            ViewBag.Provinces = await provinceServiceImpl.GetAll();
            return View();
        }
    }
}