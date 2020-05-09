using MvcCustomerManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MvcCustomerManager.Repositories;

namespace MvcCustomerManager.Services.Impl
{
    public class ProvinceServiceImpl : GeneralServiceImpl<Province, IProvinceRepository>, IProvinceService
    {
        public ProvinceServiceImpl(IProvinceRepository repository) : base(repository)
        {

        }
    }
}
