using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcCustomerManager.Models;
using MvcCustomerManager.Repositories.Impl;
using MvcCustomerManager.Services;

namespace MvcCustomerManager.Controllers
{
    public class ProvinceController : GeneralController<Province, IProvinceService>
    {
        public ProvinceController(IProvinceService service) : base(service)
        {

        }
    }
}