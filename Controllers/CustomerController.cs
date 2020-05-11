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
        private ICustomerService service;

        public CustomerController(ICustomerService service, [FromServices] IProvinceService provinceServiceImpl) 
            : base(service)
        {
            this.provinceServiceImpl = provinceServiceImpl;
            this.service = service;
        }

        [HttpGet()]
        public override async Task<IActionResult> Create()
        {
          
            ViewBag.Provinces = await provinceServiceImpl.GetAll();
            return View();
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<Customer>>> Index()
        {
            var entities = await service.GetCustomersIncludeProvince();
            return View(entities);
        }

        [HttpGet]
        public override async Task<ActionResult<Customer>> Edit(int id)
        {
            ViewBag.Provinces = await provinceServiceImpl.GetAll();
            var t = await service.GetSingleCustomerIncludeProvince(id);
            if (t == null)
            {
                return NotFound();
            }
            return View(t);
        }
    }
}